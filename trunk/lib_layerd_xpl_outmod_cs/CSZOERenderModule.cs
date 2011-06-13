/****************************************************************************
 
  C# Output Module for Zoe compiler
  
  Original Author: Alexis Ferreyra
  Contact: alexis.ferreyra@layerd.net
  
  Please visit http://layerd.net to get the last version
  of the software and information about LayerD technology.

****************************************************************************/
/*-
 * Copyright (c) 2008 Alexis Ferreyra
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 * 3. Neither the name of copyright holders nor the names of its
 *    contributors may be used to endorse or promote products derived
 *    from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
 * TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
 * PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL COPYRIGHT HOLDERS OR CONTRIBUTORS
 * BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 */
using System;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Collections;
using LayerD.CodeDOM;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Globalization;
using LayerD.ZOECompiler;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace LayerD.OutputModules
{
	/// <summary>
	/// Generador de Código ZOE a código C#.
	/// Extiende la clase abstracta ExtendedZOEProcessor e implementa
	/// las funciones de renderización de elementos.
	/// </summary>
	public class CSZOERenderModule: ExtendedZOEProcessor, IEZOERender
	{
		#region Tipos privados
		private enum FunctionType{
			Method,
			Indexer,
			Operator,
			Property
		}
        private enum Precedences
        {
			PrimaryExp=-1,
			BracketExp=-1,
			FunctionCallExp=-1,
			NewExp=-1,
			DeleteExp=-2,
			CastExp=-2,
            IsExp=-6,
			ConditionalExp=-13,
			AssingExp=-14
		}
        private struct ClassInfo
        {
            public string ClassName;
            public string Namespace;
            public int FirstLine;
            public int LastLine;
            public XplNode ClassNode;
            // A list of usings used in the class
            // builded while processing user types names
            public System.Collections.Specialized.ListDictionary Usings;

            internal static ClassInfo New()
            {
                ClassInfo retInfo = new ClassInfo();
                retInfo.Usings = new System.Collections.Specialized.ListDictionary();
                return retInfo;
            }
        }
		#endregion

		#region Datos Protegidos para Palabras Claves
		const string UsingPC="using ";
		const string NamespacePC="namespace ";
		const string ClassPC="class ";
		const string StructPC="struct ";
        const string EnumPC="enum ";
		const string InterfacePC="interface ";
		const string AbstractPC="abstract ";
		const string FinalPC="sealed ";
		const string NewPC="new ";
		const string VolatilePC="volatile ";
		const string ConstPC="const ";
		const string PrivatePC="private ";
		const string ProtectedPC="protected ";
		const string PublicPC="public ";
		const string InternalPC="internal ";
		const string DelegatePC="delegate ";
		const string ExplicitPC="explicit ";
		const string ImplicitPC="implicit ";
		const string OperatorPC="operator ";
		const string VirtualPC="virtual ";
		const string OverridePC="override ";
		const string IndexerPC="this ";
		const string ParamsPC="params ";
		const string InPC="in ";
		const string InoutPC="ref ";
		const string OutPC="out ";
		const string ReturnPC="return";
		const string ThrowPC="throw ";
		const string SwitchPC="switch ";
		const string BreakPC="break";
		const string CatchPC="catch ";
		const string ContinuePC="continue";
		const string FinallyPC="finally ";
		const string GotoPC="goto ";
		const string TryPC="try ";
		const string DoPC="do ";
		const string WhilePC="while ";
		const string CasePC="case ";
		const string DeletePC="delete ";
		const string ElsePC="else ";
		const string ForPC="for ";
		const string IfPC="if ";
		const string ExternPC="extern ";
		const string StaticPC="static ";
        const string DefaultPC = "default ";
        const string PartialPC = "partial ";

        const string PARTIAL_CLASS_FLAG = "$DOTNET_MARK_PARTIAL$";
		#endregion

		#region Datos Privados o Protegidos

		string p_outputFileName="";
		bool p_dontWriteCopyrightComment=false;
		bool p_newFilePerClass=false;
		bool p_writeDetailedComments=false;
		bool p_isUnsafeContext=false;
		bool p_applyFormat=true;
		bool p_checkTypes=true;
		bool p_newLineFlag=true;
		bool p_OptimiseParenthesis=true;
        bool p_buildFullType = false;
        bool p_prettyOutput = false;
        bool p_isDebugMode;
        string p_namespaceToRemove = "";

		TextWriter currentWriter=null;
		System.Text.Encoding p_outputEncoding=System.Text.Encoding.UTF8;
		int p_nestingLevel=0;
		int p_maxParameter=0;
		string p_tabString="";
		FunctionType currentFunctionType=FunctionType.Method;
        // Variables para el seguimiento de archivo y linea
        string p_CurrentSourceFile = "";
        int p_currentRealLine = 0;
        int p_lastStatementLine;
        // Cadena para trabajo temporario
		string tempStr="";

        string p_outputPath=null;
        bool p_dontWriteLineDirecties;
        XplLayerDZoeProgramModuletype_enum p_outputModuleType = XplLayerDZoeProgramModuletype_enum.EXECUTABLE;
        string p_intermediateFile = "";
        string p_currentLine = "";
        ArrayList p_currentFileLines;
        ErrorCollection p_errors = new ErrorCollection();
        ArrayList p_assemblyList = new ArrayList();
        int p_isExternalClass;
        Hashtable p_usedGenericInstances = new Hashtable();
        SortedList p_usings = new SortedList();
        ClassInfo p_currentClassInfo = ClassInfo.New();
        ArrayList p_classInfos = new ArrayList();
        static Dictionary<string, string> p_keywordsToReplace = new Dictionary<string, string>();

        string p_currentPackage = "";
        string p_currentClass = "";

        #endregion

		#region Constructores
        static CSZOERenderModule()
        {
            // C# keywords initialization
            p_keywordsToReplace.Add("abstract", "@abstract");
            p_keywordsToReplace.Add("as", "@as");
            p_keywordsToReplace.Add("base", "@base");
            p_keywordsToReplace.Add("bool", "@bool");
            p_keywordsToReplace.Add("break", "@break");
            p_keywordsToReplace.Add("byte", "@byte");
            p_keywordsToReplace.Add("case", "@case");
            p_keywordsToReplace.Add("catch", "@catch");
            p_keywordsToReplace.Add("char", "@char");
            p_keywordsToReplace.Add("checked", "@checked");
            p_keywordsToReplace.Add("class", "@class");
            p_keywordsToReplace.Add("const", "@const");
            p_keywordsToReplace.Add("continue", "@continue");
            p_keywordsToReplace.Add("decimal", "@decimal");
            p_keywordsToReplace.Add("default", "@default");
            p_keywordsToReplace.Add("delegate", "@delegate");
            p_keywordsToReplace.Add("do", "@do");
            p_keywordsToReplace.Add("double", "@double");
            p_keywordsToReplace.Add("else", "@else");
            p_keywordsToReplace.Add("enum", "@enum");
            p_keywordsToReplace.Add("event", "@event");
            p_keywordsToReplace.Add("explicit", "@explicit");
            p_keywordsToReplace.Add("extern", "@extern");
            p_keywordsToReplace.Add("false", "@false");
            p_keywordsToReplace.Add("finally", "@finally");
            p_keywordsToReplace.Add("fixed", "@fixed");
            p_keywordsToReplace.Add("float", "@float");
            p_keywordsToReplace.Add("for", "@for");
            p_keywordsToReplace.Add("foreach", "@foreach");
            p_keywordsToReplace.Add("goto", "@goto");
            p_keywordsToReplace.Add("if", "@if");
            p_keywordsToReplace.Add("implicit", "@implicit");
            p_keywordsToReplace.Add("in", "@in");
            p_keywordsToReplace.Add("int", "@int");
            p_keywordsToReplace.Add("interface", "@interface");
            p_keywordsToReplace.Add("internal", "@internal");
            p_keywordsToReplace.Add("is", "@is");
            p_keywordsToReplace.Add("lock", "@lock");
            p_keywordsToReplace.Add("long", "@long");
            p_keywordsToReplace.Add("namespace", "@namespace");
            p_keywordsToReplace.Add("new", "@new");
            p_keywordsToReplace.Add("null", "@null");
            p_keywordsToReplace.Add("object", "@object");
            p_keywordsToReplace.Add("operator", "@operator");
            p_keywordsToReplace.Add("out", "@out");
            p_keywordsToReplace.Add("override", "@override");
            p_keywordsToReplace.Add("params", "@params");
            p_keywordsToReplace.Add("private", "@private");
            p_keywordsToReplace.Add("protected", "@protected");
            p_keywordsToReplace.Add("public", "@public");
            p_keywordsToReplace.Add("readonly", "@readonly");
            p_keywordsToReplace.Add("ref", "@ref");
            p_keywordsToReplace.Add("return", "@return");
            p_keywordsToReplace.Add("sbyte", "@sbyte");
            p_keywordsToReplace.Add("sealed", "@sealed");
            p_keywordsToReplace.Add("short", "@short");
            p_keywordsToReplace.Add("sizeof", "@sizeof");
            p_keywordsToReplace.Add("stackalloc", "@stackalloc");
            p_keywordsToReplace.Add("static", "@static");
            p_keywordsToReplace.Add("string", "@string");
            p_keywordsToReplace.Add("struct", "@struct");
            p_keywordsToReplace.Add("switch", "@switch");
            p_keywordsToReplace.Add("this", "@this");
            p_keywordsToReplace.Add("throw", "@throw");
            p_keywordsToReplace.Add("true", "@true");
            p_keywordsToReplace.Add("try", "@try");
            p_keywordsToReplace.Add("typeof", "@typeof");
            p_keywordsToReplace.Add("uint", "@uint");
            p_keywordsToReplace.Add("ulong", "@ulong");
            p_keywordsToReplace.Add("unchecked", "@unchecked");
            p_keywordsToReplace.Add("unsafe", "@unsafe");
            p_keywordsToReplace.Add("ushort", "@ushort");
            p_keywordsToReplace.Add("using", "@using");
            p_keywordsToReplace.Add("virtual", "@virtual");
            p_keywordsToReplace.Add("void", "@void");
            p_keywordsToReplace.Add("volatile", "@volatile");
            p_keywordsToReplace.Add("while", "@while");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSZOERenderModule"/> class.
        /// </summary>
		public CSZOERenderModule():base()
		{
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="CSZOERenderModule"/> class.
        /// </summary>
        /// <param name="inputFileName">Name of the input file.</param>
		public CSZOERenderModule(string inputFileName):base(inputFileName){
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="CSZOERenderModule"/> class.
        /// </summary>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <param name="newFilePerClass">if set to <c>true</c> a new file per class is created.</param>
		public CSZOERenderModule(string inputFileName, bool newFilePerClass):base(inputFileName){
			p_newFilePerClass=newFilePerClass;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="CSZOERenderModule"/> class.
        /// </summary>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <param name="outputFileName">Name of the output file.</param>
		public CSZOERenderModule(string inputFileName, string outputFileName):base(inputFileName){
			p_outputFileName=outputFileName;
			p_newFilePerClass=false;
		}
		#endregion

		#region Miembros Privados Utilitarios

		#region PrepareOutput, CloseOutput, writeOut, writeNewLine, incNlevel, decNlevel, writeLineDirective
        private void writeLineDirective(string ldsrc,bool isMaxLine)
        {
            if (p_dontWriteLineDirecties) return;
            if (ldsrc == null) return;
            //Debo parsear ldsrc para obtener las lineas y los archivos origen
            int minLine = 0, maxLine = 0;
            string currentFile = "";
            parseLDSRC(ldsrc, ref minLine,ref  maxLine, ref currentFile);
            if (currentFile != "") currentFile=GetRelativeToOutputSourceFileName(currentFile);
            
            if (isMaxLine)
            {
                if (currentFile != "" && currentFile != p_CurrentSourceFile)
                {
                    p_CurrentSourceFile = currentFile;
                    if (maxLine != p_currentRealLine && maxLine > 0) { writeLineDirectiveText("#line " + maxLine + " \"" + p_CurrentSourceFile + "\""); p_currentRealLine = maxLine; }
                }
                else
                    if (maxLine != p_currentRealLine && maxLine > 0) { writeLineDirectiveText("#line " + maxLine); p_currentRealLine = maxLine; }
            }
            else
            {
                if (currentFile != "")
                {
                    p_CurrentSourceFile = currentFile;
                    if (minLine != p_currentRealLine && minLine > 0) { writeLineDirectiveText("#line " + minLine + " \"" + p_CurrentSourceFile + "\""); p_currentRealLine = minLine; }
                }
                else
                    if (minLine != p_currentRealLine && minLine > 0) { writeLineDirectiveText("#line " + minLine); p_currentRealLine = minLine; }
            }
        }

        private void writeLineDirectiveText(string p)
        {
            if (p_dontWriteLineDirecties) return;
            if (!p_newLineFlag)
            {
                writeNewLine();
            }
            writeOut(p);
            writeNewLine();
        }

        private string GetRelativeToOutputSourceFileName(string currentFile)
        {
            //Se lo deberia mejorar para calcular un path relativo
            //al archivo de entrada.
            return Path.GetFullPath(currentFile);
        }
        private void parseLDSRC(string ldsrc, ref int minLine, ref int maxLine, ref string currentFile)
        {
            string [] data = ldsrc.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            switch (data.Length)
            {
                case 1:
                    minLine=maxLine=Int32.Parse(data[0]);
                    break;
                case 2:
                    minLine=Int32.Parse(data[0]);
                    maxLine=Int32.Parse(data[1]);
                    break;
                case 3:
                    minLine = Int32.Parse(data[0]);
                    maxLine = Int32.Parse(data[1]);
                    currentFile = data[2];
                    break;
                case 5:
                    minLine = Int32.Parse(data[0]);
                    maxLine = Int32.Parse(data[2]);
                    currentFile = data[4];
                    break;
            }
        }
        private void PrepareOutput(){
			if(!p_newFilePerClass){
                p_currentFileLines = new ArrayList();
            }
			else{
				throw new NotImplementedException("La capacidad para generar un archivo por clase no esta implementada.");
			}
		}
		private void CloseOutput(){
			if(!p_newFilePerClass){
			}
			else{
				throw new NotImplementedException("La capacidad para generar un archivo por clase no esta implementada.");
			}
		}
        private void writeOut(string str)
        {
            //Super simple!!
            if (p_newLineFlag)
            {
                p_currentLine += p_tabString;
                p_newLineFlag = false;
            }
            p_currentLine += str;
        }
        private void writeNewLine()
        {
            p_currentFileLines.Add(p_currentLine);
            p_currentLine = "";
            p_newLineFlag = true;
            p_currentRealLine++;
        }
        private void incNLevel() {
			p_nestingLevel++;
			p_tabString+="\t";
		}
		private void decNLevel(){
			if(p_nestingLevel!=0){
				p_nestingLevel--;
				p_tabString=p_tabString.Remove(p_tabString.Length-1,1);
			}
		}
		#endregion

		#region AddError,Warning,Comments
		private void writeComment(string comment){
			writeOut("/*"+comment+"*/");
		}
		private void writeLineComment(string comment){
			writeOut("/*"+comment+"*/");writeNewLine();
		}
		void AddWarning(string message){
            Warning warning = new Warning(message);
            warning.set_ErrorSource(ErrorSource.OutputModule);
            warning.set_ErrorType(ErrorType.CodeGenerationError);
            warning.set_ErrorLevel(ErrorLevel.Five);
            p_errors.AddError(warning);
		}
		void AddError(string message){
            Error error = new Error(message);
            error.set_ErrorSource(ErrorSource.OutputModule);
            error.set_ErrorType(ErrorType.CodeGenerationError);
            error.set_ErrorLevel(ErrorLevel.Five);
            p_errors.AddError(error);
        }
		#endregion

		#region getAccess, Storage y BaseInitializers
		string getStorage(XplVarstorage_enum storage, EZOEContext context){
			tempStr="";
			switch(storage){
				case XplVarstorage_enum.AUTO:
					break;
				case XplVarstorage_enum.EXTERN:
					tempStr=ExternPC;break;
				case XplVarstorage_enum.STATIC:
					tempStr=StaticPC;break;
				case XplVarstorage_enum.STATIC_EXTERN:
					tempStr=ExternPC+StaticPC;break;
				default:
					AddWarning("Constante de almacenamiento desconocida '"+storage.ToString()+"'.");
					break;
			}
			return tempStr;
		}
		string getAccess(XplAccesstype_enum access,EZOEContext context){
			string retStr="";
			switch(access){
				case XplAccesstype_enum.PRIVATE:
					if(context==EZOEContext.NamespaceBody)retStr=InternalPC;
					else retStr=PrivatePC;
					break;
				case XplAccesstype_enum.PROTECTED:
					if(context==EZOEContext.NamespaceBody)retStr=ProtectedPC+InternalPC;
					else retStr=ProtectedPC;
					break;
				case XplAccesstype_enum.PUBLIC:
					retStr=PublicPC;break;
				case XplAccesstype_enum.IPRIVATE:
					AddWarning("Modificador de accesso 'iprivate' inesperado en código EZOE. Usando 'private' en su lugar.");
					if(context==EZOEContext.NamespaceBody)retStr=InternalPC;
					else retStr=PrivatePC;
					break;
				case XplAccesstype_enum.IPROTECTED:
					AddWarning("Modificador de accesso 'iprotected' inesperado en código EZOE. Usando 'private' en su lugar.");
					if(context==EZOEContext.NamespaceBody)retStr=InternalPC;
					else retStr=PrivatePC;
					break;
				case XplAccesstype_enum.IPUBLIC:
					AddWarning("Modificador de accesso 'ipublic' inesperado en código EZOE. Usando 'private' en su lugar.");
					if(context==EZOEContext.NamespaceBody)retStr=InternalPC;
					else retStr=PrivatePC;
					break;
				default:
					AddWarning("Modificador de accesso 'desconocido' inesperado en código EZOE. Usando 'private' en su lugar.");
					if(context==EZOEContext.NamespaceBody)retStr=InternalPC;
					else retStr=PrivatePC;
					break;
			}
			return retStr;
		}
		private string renderBaseInitializers(XplBaseInitializers initializers){
			tempStr="";
			if(initializers==null)return "";
			foreach(XplBaseInitializer initializer in initializers.Children()){
				//tempStr+=processUserTypeName(initializer.get_className());
				tempStr+="base";
				tempStr+="("+processExpressionList(initializer.get_params(),EZOEContext.FunctionDecl)+") : ";
				//Sera un error cuando se posea mas de un inicializador de clase base
			}
			if(tempStr!="")
				return tempStr.Substring(0,tempStr.Length-2);
			else
				return "";
		}
		#endregion

		#region processSimpleTypeName y processUserTypeName
		string processUserTypeName(string typeName){

            typeName = typeName.Replace("::", ".");

            // check for keyword replace
            string[] parts = typeName.Split('.');
            if (parts.Length > 1)
            {
                string temp;
                typeName = String.Empty;
                for (int n = 0; n < parts.Length; n++)
                {
                    temp = parts[n];
                    if (n == 0)
                    {
                        if (p_keywordsToReplace.ContainsKey(temp))
                            typeName += p_keywordsToReplace[temp];
                        else
                            typeName += temp;
                    }
                    else
                    {
                        if (p_keywordsToReplace.ContainsKey(temp))
                            typeName += "." + p_keywordsToReplace[temp];
                        else
                            typeName += "." + temp;
                    }
                }
            }
            else
            {
                if (p_keywordsToReplace.ContainsKey(typeName))
                    typeName = p_keywordsToReplace[typeName];
            }

            if (p_namespaceToRemove != "" && typeName.StartsWith(p_namespaceToRemove))
                if (typeName.Length == p_namespaceToRemove.Length) return String.Empty;
                else typeName = typeName.Remove(0, p_namespaceToRemove.Length + 1);

            if (p_usedGenericInstances.ContainsKey(typeName))
            {
                typeName = (string)p_usedGenericInstances[typeName];
                if (p_prettyOutput)
                {
                    for (int n = p_usings.Count - 1; n >= 0; n--)
                    {
                        string usingStr = (string)p_usings.GetByIndex(n) + ".";
                        if (typeName.Contains(usingStr))
                        {
                            typeName = typeName.Replace(usingStr, String.Empty);
                            if (p_currentClassInfo.Usings[usingStr.Substring(0,usingStr.Length-1)] == null)
                                p_currentClassInfo.Usings.Add(usingStr.Substring(0, usingStr.Length - 1), usingStr.Substring(0, usingStr.Length - 1));
                            //break;
                        }
                    }
                }
            }

            // TODO : check this, don't always function properly
            if (p_prettyOutput)
            {
                for (int n = p_usings.Count - 1; n >= 0; n--)
                {
                    string usingStr = (string)p_usings.GetByIndex(n);
                    if (typeName.StartsWith(usingStr))
                    {
                        typeName = typeName.Substring(usingStr.Length + 1);
                        if (p_currentClassInfo.Usings[usingStr] == null)
                            p_currentClassInfo.Usings.Add(usingStr, usingStr);
                        break;
                    }
                }
            }

            if (typeName.StartsWith("zoe.lang.DateTime")) typeName = typeName.Replace("zoe.lang.DateTime", "System.DateTime");

            return typeName;
		}
        /// <summary>
        /// A usar por declaracion de namespaces
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        string processUserTypeName2(string typeName)
        {
            typeName = typeName.Replace("::", ".");

            if (p_namespaceToRemove != "" && typeName.StartsWith(p_namespaceToRemove))
                typeName = typeName.Remove(0, p_namespaceToRemove.Length + 1);

            return typeName;
        }

        string processSimpleTypeName(string nt, ref bool isValueType)
        {
			string retStr="";
			#region switch simple type name
			switch(nt){
				case "$INTEGER$":
					retStr="int";
                    isValueType = true;
                    break;
				case "$UNSIGNED$":
					retStr="uint";
                    isValueType = true;
                    break;
				case "$LONG$":
					retStr="long";
                    isValueType = true;
                    break;
				case "$ULONG$":
					retStr="ulong";
                    isValueType = true;
                    break;
				case "$SHORT$":
					retStr="short";
                    isValueType = true;
                    break;
				case "$USHORT$":
					retStr="ushort";
                    isValueType = true;
                    break;
				case "$SBYTE$":
					retStr="sbyte";
                    isValueType = true;
                    break;
				case "$BYTE$":
					retStr="byte";
                    isValueType = true;
                    break;
				case "$FLOAT$":
					retStr="float";
                    isValueType = true;
                    break;
				case "$DOUBLE$":
					retStr="double";
                    isValueType = true;
                    break;
				case "$LDOUBLE$":
					retStr="double";
                    isValueType = true;
                    break;
				case "$DECIMAL$":
					retStr="decimal";
                    break;
				case "$FIXED$":
					retStr="decimal";
                    break;
				case "$BOOLEAN$":
					retStr="bool";
                    break;
				case "$CHAR$":
					retStr="char";
                    isValueType = true;
                    break;
				case "$STRING$":
					retStr="string";
                    break;
				case "$ASCIISTRING$":
					retStr="string";
                    break;
				case "$ASCIICHAR$":
					retStr="char";
                    isValueType = true;
                    break;
				case "$DATE$":
					retStr="DateTime";
                    break;
				case "$VOID$":
					retStr="void";
                    break;
				case "$OBJECT$":
					retStr="object";
                    break;
                case "$NONE$":
                    retStr = "";
                    break;
				case "$TYPE$":
					AddError("No es posible procesar tipo 'type'. Usando tipo 'object'.");
					retStr="object";
                    break;
				case "$BLOCK$":
					AddError("No es posible procesar tipo 'block'. Usando tipo 'object'.");
					retStr="object";
                    break;
				default:
					AddError("No es posible procesar tipo '"+nt+"'. Usando tipo 'object'.");
					retStr="object";
                    break;
			}
			#endregion
			return retStr;
		}
		#endregion

		#region Ayudas para Procesar Tipos
		string getTypeName(XplType type, EZOETypeContext typeContext, ref bool isValueType){
			if(type==null){
				if(typeContext==EZOETypeContext.ReturnTypeDecl)
					return ""; 
				else{
					AddError("Se ha omitido el tipo cuando es requerido. Sólo es posible omitir el tipo en en la declaracion de tipos de retorno de constructores o destructores.");
					return "";
				}
			}
            if (!p_buildFullType)
            {
                string typeStr = type.get_typeStr();
                if (typeStr == "") return "__error";
                if (typeStr.LastIndexOf(']') >= 0 || typeStr.LastIndexOf('*') >= 0 || typeStr.LastIndexOf('^') >= 0)
                {                    
                    //remuevo los array
                    if (typeStr.LastIndexOf(']') >= 0)
                        typeStr = typeStr.Substring(typeStr.LastIndexOf(']') + 1);
                    if (typeStr.LastIndexOf('*') >= 0)
                        typeStr = typeStr.Substring(typeStr.LastIndexOf('*') + 2);
                    if (typeStr.LastIndexOf('^') >= 0)
                        typeStr = typeStr.Substring(typeStr.LastIndexOf('^') + 2);
                }
                if (typeStr[0] == '$') return processSimpleTypeName(typeStr, ref isValueType);
                else if (typeStr == "zoe.lang.DateTime") return "System.DateTime";
                else return processUserTypeName(typeStr);
            }
            else
            {
                string retStr = String.Empty;
                if (!type.get_ispointer() && !type.get_isarray())
                {
                    retStr = type.get_typename();
                    if (retStr == null || retStr == String.Empty)
                        return String.Empty;
                    else
                    {
                        if (retStr[0] == '$')
                        {
                            return processSimpleTypeName(retStr, ref isValueType);
                        }
                        else return processUserTypeName(retStr);
                    }
                }
                else
                {
                    if (type.get_dt() == null)
                        return String.Empty;
                    else
                        return getTypeName(type.get_dt(), typeContext, ref isValueType);
                }
            }
		}
		bool checkPointerType(XplType type, EZOETypeContext context){
            // PENDIENTE : hacer que funcione en modo depuracion,
            // asi normalmente no relentiza la generación al vicio.
            return true;
		}
		string getArrayStr(XplType type, EZOETypeContext typeContext, EZOEContext context, bool isValueType){
            //Aca tendria que procesar lo siguiente:
            //Cuando tengo:
            //     ^[][][]int <-- int [,,]
            //     ^[][][]^[][]int <-- int[,,][,]
            //     
			string retStr=String.Empty;

            XplType currentType = type, derived = null;
            bool isInArray = false;
            while (currentType != null)
            {
                derived = currentType.get_dt();
                if (currentType.get_isarray())
                {
                    if (!isInArray)
                    {
                        retStr += "[";
                        isInArray = true;
                    }
                    if (currentType.get_ae() != null) retStr += processExpression(currentType.get_ae(), context);
                    if (derived.get_isarray()) retStr += ",";
                    else if (isInArray){
                        retStr += "]";
                        isInArray=false;
                    }                    
                }
                currentType = derived;
            }
            if (isInArray) retStr += "]";
            return retStr;
		}
		string getPointerStr(XplType type, EZOETypeContext context, bool isValueType){
            //NET Permite punteros a cualquier tipo de valor,
            //ya sea tipos nativos int, long, etc. o tipos enumeracion
            //y tipos estructura.
            //.
            //Por tanto a no ser que el compilador pase los tipos
            //"decorados", algo como "MiTipo#" indicando una clase o
            //"MiTipo@" indicando una estructura, no tengo forma
            //de saber si un tipo de valor, por tanto lo que voy hacer por
            //ahora es tomar los punteros por referencia como referencias
            //y todos los punteros que no sean por referencia como punteros y
            //ya, se supone que el compilador ZOE me pasara todos los punteros
            //convertidos a referencias siempre que pueda realizarlo.
            string retStr = String.Empty;

            XplType currentType = type, derived=null;
            bool isRef = false;
            while (currentType != null)
            {
                derived = currentType.get_dt();
                if (!currentType.get_ispointer() && !currentType.get_isarray()) break;
                if (currentType.get_ispointer())
                {
                    if (currentType.get_pi().get_ref()) isRef = true;
                    if (derived!=null 
                        && !derived.get_isarray()
                        && !isRef) retStr += "*";
                }
                else if (currentType.get_isarray()) isRef = false;
                currentType = derived;
            }
			return retStr;
		}
		#endregion
		
		#region Funciones: requireParenthesis
        bool requireParenthesis(XplBinaryoperator bopExp)
        {
            XplNode parent = bopExp.get_Parent();
            if (parent != null) parent = parent.get_Parent();
            else return false;
            if (parent != null) parent = parent.get_Parent();
            if (parent != null && parent.get_TypeName() == CodeDOMTypes.XplExpression)
            {
                //Si el parent no es nulo y es otra expresion
                int parentPrec = getExpressionPrecedence((XplExpression)parent);
                int expPrec = getOperatorPrecedence(bopExp.get_op());
                if (parentPrec > expPrec)
                    return true;
            }
            return false;
        }
        bool requireParenthesis(XplUnaryoperator uopExp)
        {
            XplNode parent = uopExp.get_Parent();
            if (parent != null) parent = parent.get_Parent();
            else return false;
            if (parent != null) parent = parent.get_Parent();
            if (parent != null && parent.get_TypeName() == CodeDOMTypes.XplExpression)
            {
                //Si el parent no es nulo y es otra expresion
                if (getExpressionPrecedence((XplExpression)parent) > getOperatorPrecedence(uopExp.get_op()))
                    return true;
            }
            return false;
        }
        bool requireParenthesis(XplCastexpression exp)
        {
            XplNode parent = exp.get_Parent().get_Parent();
            if (parent != null && parent.get_TypeName() == CodeDOMTypes.XplExpression)
            {
                //Si el parent no es nulo y es otra expresion
                if (getExpressionPrecedence((XplExpression)parent) > (int)Precedences.CastExp) return true;
            }
            return false;
        }

		#endregion

		#region Expression Precedence
		int getExpressionPrecedence(XplExpression exp){
			int retVal=0;
			XplNode expNode=exp.get_Content();
			switch(expNode.get_ElementName()){
				case "a":
					retVal=(int)Precedences.AssingExp;
					break;
				case "new":
					retVal=(int)Precedences.NewExp;
					break;
				case "bo":
					retVal=getOperatorPrecedence( ((XplBinaryoperator)expNode).get_op() );
					break;
				case "uo":
					retVal=getOperatorPrecedence( ((XplUnaryoperator)expNode).get_op() );
					break;
				case "b":
					retVal=(int)Precedences.BracketExp;
					break;
				case "n":
					retVal=(int)Precedences.PrimaryExp;
					break;
				case "lit":
					retVal=(int)Precedences.PrimaryExp;
					break;
				case "fc":
					retVal=(int)Precedences.FunctionCallExp;
					break;
				case "cast":
					retVal=(int)Precedences.CastExp;
					break;
				case "delete":
					retVal=(int)Precedences.DeleteExp;
					break;
				case "onpointer":
					retVal=(int)Precedences.PrimaryExp;
					break;
				case "empty":
					retVal=(int)Precedences.PrimaryExp;
					break;
                case "toft":
                    retVal = (int)Precedences.PrimaryExp;
                    break;
                case "is":
                    retVal = (int)Precedences.PrimaryExp;
                    break;
			}
			return retVal;
		}
		#endregion
		
		#region Precedencia de operadores binarios y unarios
        int getOperatorPrecedence(XplBinaryoperators_enum op)
        {
            int retVal = 0;
            #region Switch Binary Operators
            switch (op)
            {
                case XplBinaryoperators_enum.M: //Member access "."
                case XplBinaryoperators_enum.MP: //Member Pointer Access ".*"
                case XplBinaryoperators_enum.IMP: //Felcha "=>"
                case XplBinaryoperators_enum.PM: //Pointer Member Access "->"
                case XplBinaryoperators_enum.PMP: //Pointer To Member Pointer Access "->*"
                case XplBinaryoperators_enum.RM: //Reservado para Acceso a miembros
                    //New Exp
                    retVal = -1; break;
                //Unary operators y Cast retVal=2
                case XplBinaryoperators_enum.DIV: //Division
                case XplBinaryoperators_enum.EXP: //Exponente
                case XplBinaryoperators_enum.MOD: //Modulo (resto)
                case XplBinaryoperators_enum.MUL: //Multiplicacion
                    retVal = -3; break;
                case XplBinaryoperators_enum.ADD: //Suma
                case XplBinaryoperators_enum.MIN: //Resta
                    retVal = -4; break;
                case XplBinaryoperators_enum.LSH: //Left shift
                case XplBinaryoperators_enum.RSH: //Right shift
                    retVal = -5; break;
                case XplBinaryoperators_enum.GR: //Mayor que
                case XplBinaryoperators_enum.GREQ: //Mayor o igual que
                case XplBinaryoperators_enum.LS: //Menor que
                case XplBinaryoperators_enum.LSEQ: //Menor o igual que
                    retVal = -6; break;
                case XplBinaryoperators_enum.EQ: //Igualdad Logico
                case XplBinaryoperators_enum.NOTEQ: //No Igual logico
                    retVal = -7; break;
                case XplBinaryoperators_enum.AND: //Y Logico
                    retVal = -8; break;
                case XplBinaryoperators_enum.XOR: //Xor de Bits
                    retVal = -9; break;
                case XplBinaryoperators_enum.BOR: //O de Bits
                    retVal = -10; break;
                case XplBinaryoperators_enum.BAND: //Y de Bits
                    retVal = -11; break;
                case XplBinaryoperators_enum.OR: //O Logico
                    retVal = -12; break;
                //Condicional retVal=13
                //Asignacion retVal=14
            }
            #endregion
            return retVal;
        }
        int getOperatorPrecedence(XplUnaryoperators_enum op)
        {
            int retVal = 0;
            switch (op)
            {
                case XplUnaryoperators_enum.DEC: //Decremento postfijo 'e--'
                case XplUnaryoperators_enum.INC: //Incremento postfijo 'e++'
                case XplUnaryoperators_enum.SIZEOF:
                case XplUnaryoperators_enum.TYPEOF:
                    //New Exp
                    retVal = -1; break;
                case XplUnaryoperators_enum.MIN: //Negativo '-'
                case XplUnaryoperators_enum.NOT: //Negado logico '!'
                case XplUnaryoperators_enum.ONECOMP: //Complemento a Uno '~'
                case XplUnaryoperators_enum.PREDEC: //Decremento prefijo '--e'
                case XplUnaryoperators_enum.PREINC: //Incremento prefijo '++e'
                case XplUnaryoperators_enum.AOF: //Address of '&'
                case XplUnaryoperators_enum.IND: //Indireccion de puntero '*'
                case XplUnaryoperators_enum.RAOF: //Reference AddressOf '&&'
                    //Cast
                    retVal = -2; break;
            }
            return retVal;
        }

		#endregion

        #region Ayudas varias
        private void renderEnumType(XplClass classDecl)
        {
            AddWarning("Utilizando siempre 'int' para tipo base de enumeraciones.");
            return;
        }
        private bool FieldIsFromEnum(XplField fieldDecl)
        {
            XplClass classNode = (XplClass)fieldDecl.get_Parent();
            return classNode.get_isenum();
        }
        #endregion

        #endregion

		#region Sobreescritura de miembros abstractos

		#region DocumentData
        /// <summary>
        /// Processes the document data.
        /// </summary>
        /// <param name="documentData">The document data.</param>
		protected override void processDocumentData(XplDocumentData documentData){
			//Por ahora no hago nada para procesar la info de configuración
		}
		#endregion
		
		#region Inicio y Fin de Documento
        /// <summary>
        /// Renders the begin document body.
        /// </summary>
        /// <param name="documentBody">The document body.</param>
		protected override void renderBeginDocumentBody(XplDocumentBody documentBody){
            string temp =
              "---------------------------------------------------------------------\n"
            + " This file was autogenerated.\n"
            + " DO NOT MODIFY THIS FILE MANUALLY.\n"
            + " Date: " + DateTime.Now.ToString() + ".\n\n"
            + " Generated by: DotNET LayerD Generator - ZOE Output Module to C#\n"
            + " 2006(R)Alexis Ferreyra.\n\n"
            + " Please visit http://layerd.net to get last version of LayerD tools.\n"
            + "---------------------------------------------------------------------";
            writeLineComment(temp);
			writeNewLine();
            writeLineDirective(documentBody.get_ldsrc(), false);
		}
        /// <summary>
        /// Renders the end document body.
        /// </summary>
        /// <param name="documentBody">The document body.</param>
		protected override void renderEndDocumentBody(XplDocumentBody documentBody){
			writeNewLine();
			writeLineComment("--- Final del archivo generado ---");
		}
		#endregion
		
		#region Declaraciones
        /// <summary>
        /// Renders the import directive.
        /// </summary>
        /// <param name="importDirective">The import directive.</param>
		protected override void renderImportDirective(XplName importDirective){
            // PENDIENTE : si el compilador ZOE me manda todos los import,
            // solo debo procesar los que correspondan a este modulo de salida.
            writeLineDirective(importDirective.get_ldsrc(), false);
            string usingString = null;
            bool flag = false;
            foreach (XplNode node in importDirective.Children())
            {
				tempStr=node.get_StringValue();
                if (tempStr.IndexOf('=') == -1)
                {
                    usingString = UsingPC + tempStr + ";";
                    //break;
                }
                else
                {
                    flag = true;
                    string parameterName = tempStr.Substring(0, tempStr.IndexOf('=')).ToLower();
                    string parameterValue = tempStr.Substring(tempStr.IndexOf('=') + 1);
                    switch (parameterName)
                    {
                        case "ns":
                            if (p_namespaceToRemove == "") 
                                p_namespaceToRemove = parameterValue;
                            break;
                        case "assembly":
                            if(!parameterValue.EndsWith(".dll")) parameterValue += ".dll";
                            if (parameterValue.ToLower() != "mscorlib" && !p_assemblyList.Contains(parameterValue.ToLower()))
                                p_assemblyList.Add(parameterValue.ToLower());
                            break;
                        case "assemblyfilename":
                            string assemblyFilename = parameterValue.ToLower();
                            if (!Path.IsPathRooted(assemblyFilename))
                            {
                                // If supplied filename doesn't exists try to search with relative path to source
                                // if source information is found.
                                string sourceFilename = importDirective.FullSourceFileInfo;
                                if (sourceFilename != null && sourceFilename != "")
                                {
                                    string[] parts = sourceFilename.Split(',');
                                    sourceFilename = Path.GetDirectoryName(parts[parts.Length - 1]);
                                    assemblyFilename = Path.Combine(sourceFilename, assemblyFilename);
                                }
                            }
                            if (assemblyFilename != "mscorlib" && !p_assemblyList.Contains(assemblyFilename))
                                p_assemblyList.Add(assemblyFilename);
                            break;
                    }
                }
			}
            if (flag)
            {
                //writeOut(usingString);
                //writeNewLine();
            }
		}
        /// <summary>
        /// Renders the begin namespace.
        /// </summary>
        /// <param name="namespaceName">Name of the namespace.</param>
        /// <param name="namespaceDecl">The namespace decl.</param>
        /// <param name="context">The context.</param>
		protected override void renderBeginNamespace(string namespaceName, XplNamespace namespaceDecl, EZOEContext context){

            string directorio = processUserTypeName2(namespaceName);
            if (p_currentPackage == "")
                p_currentPackage += directorio;
            else
                p_currentPackage += "." + directorio;

            p_currentClass = p_currentPackage;

            if (namespaceDecl.Children().GetLength() == 0) return;
            writeNewLine();
            writeLineDirective(namespaceDecl.get_ldsrc(), false);
            writeOut(NamespacePC + processSimleName(processUserTypeName2(namespaceName)));
            writeNewLine();
            writeOut("{");
			incNLevel();
			writeNewLine();

            // init new class info
            p_currentClassInfo = ClassInfo.New();
            p_currentClassInfo.FirstLine = p_currentFileLines.Count;
		}
        /// <summary>
        /// Renders the end namespace.
        /// </summary>
        /// <param name="namespaceName">Name of the namespace.</param>
        /// <param name="namespaceDecl">The namespace decl.</param>
        /// <param name="context">The context.</param>
		protected override void renderEndNamespace(string namespaceName, XplNamespace namespaceDecl, EZOEContext context){
            p_currentPackage = p_currentPackage.Substring(0, p_currentPackage.Length - processUserTypeName2(namespaceName).Length);
            p_currentClass = p_currentPackage;

            if (p_currentPackage != "") p_currentPackage = p_currentPackage.Substring(0, p_currentPackage.Length - 1);

            if (namespaceDecl.Children().GetLength() == 0) return;

            writeLineDirective(namespaceDecl.get_ldsrc(), true);
            decNLevel();
			writeOut("} ");
			if(p_writeDetailedComments)writeComment("Fin Espacio de Nombres '"+namespaceName+"'");
			writeNewLine();
		}
		
        /// <summary>
        /// Renders the begin class.
        /// </summary>
        /// <param name="classType">Type of the class.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="implementsStr">The implements STR.</param>
        /// <param name="inheritsStr">The inherits STR.</param>
        /// <param name="classAccess">The class access.</param>
        /// <param name="isNew">if set to <c>true</c> [is new].</param>
        /// <param name="isAbstract">if set to <c>true</c> [is abstract].</param>
        /// <param name="isFinal">if set to <c>true</c> [is final].</param>
        /// <param name="classDecl">The class decl.</param>
        /// <param name="context">The context.</param>
		protected override void renderBeginClass(EZOEClassType classType, string className, string implementsStr, string inheritsStr,
            XplAccesstype_enum classAccess, bool isNew, bool isAbstract, bool isFinal, XplClass classDecl, EZOEContext context)
        {
            p_currentClass += "." + className;

            if (classDecl.get_externalname() != "")
                className = classDecl.get_externalname();

            {
                //Para clases que simulan instancias de genericos
                //asumo el formato $NET_GENERIC[ZoeClassName|NetGenericName<With,Generic,Params>]$
                string lddata = classDecl.get_lddata();
                int index = lddata.IndexOf("$NET_GENERIC"), index2;
                if (index >= 0)
                {
                    string netGenericName;
                    index = lddata.IndexOf('[', index);
                    index2 = lddata.IndexOf(']', index);
                    netGenericName = lddata.Substring(index + 1, index2 - index - 1);
                    p_usedGenericInstances.Add(p_currentClass, netGenericName);
                }
            }
            //Si la clase es externa levanto la bandera y retorno
            if (classDecl.get_external())
            {
                p_isExternalClass++;
                return;
            }
            else
            {
                RenderComments(classDecl);
                // If it is a first level class add CurrentClassInfo data
                if (classDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplNamespace)
                {
                    p_currentClassInfo.ClassName = className;
                    p_currentClassInfo.Namespace = p_currentPackage;
                    p_currentClassInfo.ClassNode = classDecl;
                }
            }

            writeLineDirective(classDecl.get_ldsrc(), false);
            //Primero los modificadores
            if (isNew) writeOut(NewPC);
            if (isAbstract) writeOut(AbstractPC);
            if (isFinal) writeOut(FinalPC);
            writeOut(getAccess(classAccess, context));
            if (classDecl.get_lddata().Contains(PARTIAL_CLASS_FLAG)) writeOut(PartialPC);

            className = processSimleName(className);
            //La declaracion del nombre
            switch (classType)
            {
                case EZOEClassType.Class:
                    writeOut(ClassPC + className);
                    break;
                case EZOEClassType.Interface:
                    writeOut(InterfacePC + className);
                    break;
                case EZOEClassType.Struct:
                    writeOut(StructPC + className);
                    break;
                case EZOEClassType.Union:
                    writeOut(StructPC + className);
                    break;
                case EZOEClassType.Enum:
                    writeOut(EnumPC + className);
                    renderEnumType(classDecl);
                    break;
                default:
                    throw new Exception("Valor interno inesperado renderizando clase.");
            }
            if (inheritsStr != "" || implementsStr != "") writeOut(": " + inheritsStr);
            if (implementsStr != "")
            {
                if (inheritsStr != "") writeOut(", " + implementsStr);
                else writeOut(implementsStr);
            }
            writeNewLine();
            writeOut("{");
            incNLevel();
            writeNewLine();

            if (p_prettyOutput)
            {
                p_lastStatementLine = 0;
            }
        }
        /// <summary>
        /// Renders the end class.
        /// </summary>
        /// <param name="classType">Type of the class.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="classDecl">The class decl.</param>
        /// <param name="context">The context.</param>
		protected override void renderEndClass(EZOEClassType classType, string className, XplClass classDecl, EZOEContext context){

            p_currentClass = p_currentClass.Substring(0, p_currentClass.Length - className.Length);
            if (p_currentClass.Length > 1) p_currentClass = p_currentClass.Substring(0, p_currentClass.Length - 1);

            //Si la clase actual es externa retorno
            if (p_isExternalClass > 0)
            {
                if (classDecl.get_external()) p_isExternalClass--;
                return;
            }

            writeLineDirective(classDecl.get_ldsrc(), true);
            decNLevel();
			writeOut("} ");
			if(p_writeDetailedComments)writeComment("End of class '"+className+"'");
			writeNewLine();
            // If it is a first level class add CurrentClassInfo data
            if (classDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplNamespace)
            {
                p_currentClassInfo.LastLine = p_currentFileLines.Count;
                p_classInfos.Add(p_currentClassInfo);
                // Create a new ClassInfo
                p_currentClassInfo = ClassInfo.New();                
                p_currentClassInfo.FirstLine = p_currentFileLines.Count;
            }

		}
        /// <summary>
        /// Render a implements.
        /// </summary>
        /// <param name="classDecl">The class decl.</param>
        /// <param name="implements">The implements.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderImplements(XplClass classDecl, XplNodeList implements, EZOEContext context){
			string temp="";
			XplInherit imp=null;
			XplInherits imps=null;
			foreach(XplInherits node in implements){
				imps = node;
				foreach(XplInherit node2 in imps.Children()){
					imp = node2;
					temp += processUserTypeName(imp.get_type().get_typename())+", ";
				}
			}
			if(temp!="")temp=temp.Substring(0,temp.Length-2);
			return temp;
		}
        /// <summary>
        /// Render a inherits.
        /// </summary>
        /// <param name="classDecl">The class decl.</param>
        /// <param name="inherits">The inherits.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderInherits(XplClass classDecl, XplNodeList inherits, EZOEContext context){
			string temp="";
			XplInherit inh=null;
			XplInherits inhs=null;
			foreach(XplInherits node in inherits){
				inhs = node;
                foreach (XplInherit node2 in inhs.Children())
                {
					inh = node2;
                    if (processUserTypeName(inh.get_type().get_typename()) != "zoe.lang.Object")
                    {
                        temp += processUserTypeName(inh.get_type().get_typename()) + ", ";
                        if (inh.get_access() != XplAccesstype_enum.PUBLIC)
                            AddWarning("Modificador de acceso ignorado en declaración de herencia. El tipo real implementado utilizará acceso publico para la clase heredada.");
                        if (!inh.get_virtual())
                            AddWarning("Modificador virtual no aplicado en declaración de herencia, forzando herencia virtual.");
                    }
				}
			}
			if(temp!="")temp=temp.Substring(0,temp.Length-2);
			return temp;
		}

        /// <summary>
        /// Renders the begin function.
        /// </summary>
        /// <param name="functionDecl">The function decl.</param>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="returnTypeStr">The return type STR.</param>
        /// <param name="parametersStr">The parameters STR.</param>
        /// <param name="access">The access.</param>
        /// <param name="functionStorage">The function storage.</param>
        /// <param name="isAbstract">if set to <c>true</c> [is abstract].</param>
        /// <param name="isFinal">if set to <c>true</c> [is final].</param>
        /// <param name="isFp">if set to <c>true</c> [is fp].</param>
        /// <param name="isNew">if set to <c>true</c> [is new].</param>
        /// <param name="isConst">if set to <c>true</c> [is const].</param>
        /// <param name="isOverride">if set to <c>true</c> [is override].</param>
        /// <param name="isVirtual">if set to <c>true</c> [is virtual].</param>
        /// <param name="context">The context.</param>
		protected override void renderBeginFunction(XplFunction functionDecl, string functionName, string returnTypeStr, string parametersStr, 
			XplAccesstype_enum access, XplVarstorage_enum functionStorage,	bool isAbstract, bool isFinal, bool isFp, bool isNew, bool isConst,  
			bool isOverride, bool isVirtual, EZOEContext context){
            
            //Si la clase actual es externa retorno
            if (p_isExternalClass>0 || functionStorage==XplVarstorage_enum.EXTERN || functionStorage==XplVarstorage_enum.STATIC_EXTERN) return;

            writeLineDirective(functionDecl.get_ldsrc(), false);
			
			string baseInitializers=renderBaseInitializers(functionDecl.get_BaseInitializers());

            bool isInterface = functionDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplClass && functionDecl.CurrentClass.get_isinterface();

            //Ajusto el nombre de la funcion al nombre externo si es necesario
            if (functionDecl.get_externalname() != "")
                functionName = processSimleName(functionDecl.get_externalname());

            RenderComments(functionDecl);

            //Los miembros de las interfaces son siempre publicos no se debe hacer nada
            if (!isInterface)
            {
                if (! ( ((XplClass)functionDecl.get_Parent()).get_name() == functionName && 
                    (functionStorage == XplVarstorage_enum.STATIC || 
                    functionStorage == XplVarstorage_enum.STATIC_EXTERN)) )
                {
                    writeOut(getAccess(access, context));
                }
            }

            writeOut(getStorage(functionStorage, context));

			if(isAbstract)writeOut(AbstractPC);
			if(isFinal)writeOut(FinalPC);
			if(isNew)writeOut(NewPC);
			if(isConst)AddWarning("Modificador de función 'const' no aplicado en implementacion.");
			if(isOverride)writeOut(OverridePC);
			if(isVirtual)writeOut(VirtualPC);
			if(isFp){ //Declaro un delegate
				writeOut(DelegatePC);
			}
			if(functionName.IndexOf("%indexer%")>=0){
				functionName=functionName.Replace("%indexer%","");
				functionName+=IndexerPC;
				currentFunctionType=FunctionType.Indexer;
			}
			else if(functionName.IndexOf("%op_")>=0){
				currentFunctionType=FunctionType.Operator;
				#region Nombres de Operadores
				switch(functionName){
					case "%op_gtr%":
						functionName=OperatorPC+">";
						break;
					case "%op_lst%":
						functionName=OperatorPC+"<";
						break;
					case "%op_bneg%":
						functionName=OperatorPC+"!";
						break;
					case "%op_comp%":
						functionName=OperatorPC+"~";
						break;
					case "%op_eq%":
						functionName=OperatorPC+"==";
						break;
					case "%op_lseq%":
						functionName=OperatorPC+"<=";
						break;
					case "%op_greq%":
						functionName=OperatorPC+">=";
						break;
					case "%op_noteq%":
						functionName=OperatorPC+"!=";
						break;
					case "%op_and%":
						AddError("No se puede sobrecargar el operador &&.");
						functionName=OperatorPC+"&&";
						break;
					case "%op_or%":
						AddError("No se puede sobrecargar el operador ||.");
						functionName=OperatorPC+"||";
						break;
					case "%op_inc%":
						functionName=OperatorPC+"++";
						break;
					case "%op_dec%":
						functionName=OperatorPC+"--";
						break;
					case "%op_add%":
						functionName=OperatorPC+"+";
						break;
					case "%op_min%":
						functionName=OperatorPC+"-";
						break;
					case "%op_mul%":
						functionName=OperatorPC+"*";
						break;
					case "%op_div%":
						functionName=OperatorPC+"/";
						break;
					case "%op_band%":
						functionName=OperatorPC+"&";
						break;
					case "%op_bor%":
						functionName=OperatorPC+"|";
						break;
					case "%op_xor%":
						functionName=OperatorPC+"^";
						break;
					case "%op_mod%":
						functionName=OperatorPC+"%";
						break;
					case "%op_lsh%":
						functionName=OperatorPC+"<<";
						break;
					case "%op_rsh%":
						functionName=OperatorPC+">>";
						break;
					case "%op_new%":
						AddError("No se puede sobrecargar el operador 'new'.");
						functionName=OperatorPC+"_new";
						break;
					case "%op_delete%":
						AddError("No se puede sobrecargar el operador 'delete'.");
						functionName=OperatorPC+"_delete";
						break;
					case "%op_explicit%":
						AddWarning("Operadores de conversion no implementados en el modulo de salida.");
						functionName=ExplicitPC+OperatorPC+"T";
						break;
					case "%op_implicit%":
						AddWarning("Operadores de conversion no implementados en el modulo de salida.");
						functionName=ImplicitPC+OperatorPC+"T";
						break;
					default:
                        AddError("No se pudo identificar el operador \"" + functionName + "\" utilizado.");
                        functionName = "operator_NonRecognized";
						break;
				}
				#endregion
			}
			else{
				functionName=processUserTypeName(functionName);
				currentFunctionType=FunctionType.Method;
			}

			if(returnTypeStr!=String.Empty) writeOut(returnTypeStr+" ");
			writeOut(functionName);
			if(currentFunctionType==FunctionType.Indexer)
				writeOut("["+parametersStr+"]");
			else
				writeOut("("+parametersStr+")");
			if(baseInitializers!="")writeOut(":"+baseInitializers);
			if(!isAbstract && functionStorage!=XplVarstorage_enum.EXTERN && functionStorage!=XplVarstorage_enum.STATIC_EXTERN
                && !isInterface && !isFp){
                writeNewLine();
                writeOut("{");
				incNLevel();
			}
			else{
				writeOut(";");
			}
			writeNewLine();
		}
        /// <summary>
        /// Renders the end of a function.
        /// </summary>
        /// <param name="functionDecl">The function decl.</param>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="context">The context.</param>
		protected override void renderEndFunction(XplFunction functionDecl, string functionName, EZOEContext context){
			bool isAbstract=functionDecl.get_abstract();
			XplVarstorage_enum functionStorage=functionDecl.get_storage();

            if (p_isExternalClass>0 || functionStorage==XplVarstorage_enum.EXTERN || functionStorage==XplVarstorage_enum.STATIC_EXTERN) return;

			if(!isAbstract && functionStorage!=XplVarstorage_enum.EXTERN && functionStorage!=XplVarstorage_enum.STATIC_EXTERN
                && !(functionDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplClass && functionDecl.CurrentClass.get_isinterface()) && !functionDecl.get_fp()){
				decNLevel();
				writeOut("} ");
				if(p_writeDetailedComments)writeComment("Final función '"+functionName+"'.");
				writeNewLine();
                writeNewLine();
            }
		}
        /// <summary>
        /// Renders the begin property.
        /// </summary>
        /// <param name="propertyDecl">The property decl.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="typeStr">The type STR.</param>
        /// <param name="access">The access.</param>
        /// <param name="propertyStorage">The property storage.</param>
        /// <param name="isAbstract">if set to <c>true</c> [is abstract].</param>
        /// <param name="isFinal">if set to <c>true</c> [is final].</param>
        /// <param name="isNew">if set to <c>true</c> [is new].</param>
        /// <param name="isConst">if set to <c>true</c> [is const].</param>
        /// <param name="isOverride">if set to <c>true</c> [is override].</param>
        /// <param name="isVirtual">if set to <c>true</c> [is virtual].</param>
        /// <param name="context">The context.</param>
		protected override void renderBeginProperty(XplProperty propertyDecl, string propertyName, string typeStr,  
			XplAccesstype_enum access, XplVarstorage_enum propertyStorage,	bool isAbstract, bool isFinal, bool isNew, bool isConst,  
			bool isOverride, bool isVirtual, EZOEContext context){

            if (p_isExternalClass>0 || propertyStorage == XplVarstorage_enum.EXTERN || propertyStorage == XplVarstorage_enum.STATIC_EXTERN) return;

            writeLineDirective(propertyDecl.get_ldsrc(), false);

            if (propertyDecl.get_externalname() != "")
                propertyName = processSimleName(propertyDecl.get_externalname());

            RenderComments(propertyDecl);
            //Los miembros de las interfaces son siempre publicos no se debe hacer nada
            if (!(propertyDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplClass && propertyDecl.CurrentClass.get_isinterface()))
                writeOut(getAccess(access, context));

			writeOut(getStorage(propertyStorage,context));

			if(isAbstract)writeOut(AbstractPC);
			if(isFinal)writeOut(FinalPC);
			if(isNew)writeOut(NewPC);
			if(isConst)AddWarning("Modificador de función 'const' no aplicado en implementacion.");
			if(isOverride)writeOut(OverridePC);
			if(isVirtual)writeOut(VirtualPC);
			writeOut(typeStr+" "+processUserTypeName(propertyName));
            writeNewLine();
            writeOut("{");
			incNLevel();
			writeNewLine();
			currentFunctionType=FunctionType.Property;
		}
        /// <summary>
        /// Renders the end property.
        /// </summary>
        /// <param name="propertyDecl">The property decl.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="context">The context.</param>
		protected override void renderEndProperty(XplProperty propertyDecl, string propertyName, EZOEContext context){
            XplVarstorage_enum propertyStorage = propertyDecl.get_storage();
            if (p_isExternalClass>0 || propertyStorage == XplVarstorage_enum.EXTERN || propertyStorage == XplVarstorage_enum.STATIC_EXTERN) return;

            decNLevel();
			writeOut("} ");
			if(p_writeDetailedComments)writeComment("Final de propiedad '"+propertyName+"'.");
			writeNewLine();
            writeNewLine();
        }
        /// <summary>
        /// Renders the begin get access.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="body">The body.</param>
		protected override void renderBeginGetAccess(EZOEContext context, XplFunctionBody body){
            bool isExtern = false;
            if (body.get_Parent().get_Parent().get_TypeName() == CodeDOMTypes.XplProperty)
            {
                XplProperty property = (XplProperty)body.get_Parent().get_Parent();
                isExtern = property.get_storage() == XplVarstorage_enum.EXTERN || property.get_storage() == XplVarstorage_enum.STATIC_EXTERN;
            }
            if (p_isExternalClass>0 || isExtern) return;
			writeOut("get ");
            if (body.get_lddata().Contains("%abstract%")) writeOut(";");
            else
            {
                writeNewLine();
				writeOut("{");
				incNLevel();
				writeNewLine();
			}
		}
        /// <summary>
        /// Renders the end get access.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="body">The body.</param>
		protected override void renderEndGetAccess(EZOEContext context, XplFunctionBody body){
            bool isExtern = false;
            if (body.get_Parent().get_Parent().get_TypeName() == CodeDOMTypes.XplProperty)
            {
                XplProperty property = (XplProperty)body.get_Parent().get_Parent();
                isExtern = property.get_storage() == XplVarstorage_enum.EXTERN || property.get_storage() == XplVarstorage_enum.STATIC_EXTERN;
            }
            if (p_isExternalClass > 0 || isExtern) return;
            if (body.get_lddata().Contains("%abstract%")) 
            {
				//writeOut(";");
				writeNewLine();
			}
			else {
				decNLevel();
				writeOut("}");
				writeNewLine();
			}
		}
        /// <summary>
        /// Renders the begin set access.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="body">The body.</param>
		protected override void renderBeginSetAccess(EZOEContext context, XplFunctionBody body){
            bool isExtern = false;
            if (body.get_Parent().get_Parent().get_TypeName() == CodeDOMTypes.XplProperty)
            {
                XplProperty property = (XplProperty)body.get_Parent().get_Parent();
                isExtern = property.get_storage() == XplVarstorage_enum.EXTERN || property.get_storage() == XplVarstorage_enum.STATIC_EXTERN;
            }
            if (p_isExternalClass > 0 || isExtern) return;

            writeOut("set ");
            if (body.get_lddata().Contains("%abstract%")) writeOut(";");
			else {
                writeNewLine();
				writeOut("{");
				incNLevel();
				writeNewLine();
			}
		}
        /// <summary>
        /// Renders the end set access.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="body">The body.</param>
		protected override void renderEndSetAccess(EZOEContext context, XplFunctionBody body){
            bool isExtern = false;
            if (body.get_Parent().get_Parent().get_TypeName() == CodeDOMTypes.XplProperty)
            {
                XplProperty property = (XplProperty)body.get_Parent().get_Parent();
                isExtern = property.get_storage() == XplVarstorage_enum.EXTERN || property.get_storage() == XplVarstorage_enum.STATIC_EXTERN;
            }
            if (p_isExternalClass > 0 || isExtern) return;

            if (body.get_lddata().Contains("%abstract%"))
            {
				//writeOut(";");
				writeNewLine();
			}
			else {
				decNLevel();
				writeOut("}");
				writeNewLine();
			}
		}
        /// <summary>
        /// Renders the field.
        /// </summary>
        /// <param name="fieldDecl">The field decl.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="typeStr">The type STR.</param>
        /// <param name="initializerStr">The initializer STR.</param>
        /// <param name="access">The access.</param>
        /// <param name="fieldStorage">The field storage.</param>
        /// <param name="isNew">if set to <c>true</c> [is new].</param>
        /// <param name="isVolatile">if set to <c>true</c> [is volatile].</param>
		protected override void renderField(XplField fieldDecl, string fieldName, string typeStr, string initializerStr, 
			XplAccesstype_enum access, XplVarstorage_enum fieldStorage, bool isNew, bool isVolatile){

            if (p_isExternalClass>0 || fieldStorage == XplVarstorage_enum.EXTERN || fieldStorage == XplVarstorage_enum.STATIC_EXTERN) return;

            if (fieldDecl.get_externalname() != "")
                fieldName = fieldDecl.get_externalname();

            writeLineDirective(fieldDecl.get_ldsrc(), false);

            if (!FieldIsFromEnum(fieldDecl))
            {
                RenderComments(fieldDecl);
                writeOut(getAccess(access, EZOEContext.ClassDecl));
                string storageStr = getStorage(fieldStorage, EZOEContext.ClassBody);
                if (fieldDecl.get_type().get_const()) storageStr = storageStr.Replace(StaticPC, "");
                writeOut(storageStr);

                if (isNew) writeOut(NewPC);
                if (isVolatile) writeOut(VolatilePC);
                if (fieldDecl.get_type().get_const()) writeOut(ConstPC);
                writeOut(typeStr);
                if (initializerStr != "")
                    if (initializerStr[0] != '(') writeOut(" = " + initializerStr);
                    else writeOut(initializerStr);
                writeOut("; ");
                if (p_writeDetailedComments) writeComment("campo '" + fieldName + "'");
            }
            else
            { //Es un campo de una enumeración
                RenderComments(fieldDecl);
                writeOut(fieldDecl.get_name());
                if (initializerStr != "")
                    if (initializerStr[0] != '(') writeOut(" = " + initializerStr);
                    else writeOut(initializerStr);
                writeOut(", ");
            }
			writeNewLine();
		}
        /// <summary>
        /// Renders the begin parameters.
        /// </summary>
        /// <param name="parametersDecl">The parameters decl.</param>
        /// <param name="maxParameter">The max parameter.</param>
        /// <param name="functionDecl">The function decl.</param>
        /// <param name="context">The context.</param>
		protected override void renderBeginParameters(XplParameters parametersDecl,int maxParameter, XplFunction functionDecl, EZOEContext context){
			p_maxParameter=maxParameter;
		}
        /// <summary>
        /// Render a parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="typeStr">The type STR.</param>
        /// <param name="initializerStr">The initializer STR.</param>
        /// <param name="parameterDirection">The parameter direction.</param>
        /// <param name="parameterNumber">The parameter number.</param>
        /// <param name="isParams">if set to <c>true</c> [is params].</param>
        /// <param name="isVolatile">if set to <c>true</c> [is volatile].</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderParameter(XplParameter parameter, string parameterName, string typeStr, 
			string initializerStr, XplParameterdirection_enum parameterDirection, int parameterNumber, 
			bool isParams, bool isVolatile){
			string retStr="";
			switch(parameterDirection){
				case XplParameterdirection_enum.IN:
					//retStr+=InPC;
					//como es por defecto no hago nada
					break;
				case XplParameterdirection_enum.INOUT:
					retStr+=InoutPC;
					break;
				case XplParameterdirection_enum.OUT:
					retStr+=OutPC;
					break;
			}
			if(isParams)retStr+=ParamsPC;
			if(isVolatile){
				AddWarning("Modificador 'volatile' en parametros no soportado en el tipo implementado.");
			}
			if(parameterNumber!=p_maxParameter)retStr+=typeStr+", ";
			else retStr+=typeStr;
			if(initializerStr!=""){
				AddError("Los parametros no pueden declarar valores por defecto en .NET.");
				retStr+="/*="+initializerStr+"*/";
			}
			return retStr;
		}
        /// <summary>
        /// Renders the end parameters.
        /// </summary>
        /// <param name="parametersDecl">The parameters decl.</param>
        /// <param name="context">The context.</param>
		protected override void renderEndParameters(XplParameters parametersDecl, EZOEContext context){
			p_maxParameter=0;
		}
        /// <summary>
        /// Render a type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="declareName">Name of the declare.</param>
        /// <param name="typeContext">The type context.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderType(XplType type, string declareName, EZOETypeContext typeContext, EZOEContext context){
			string typeStr="",arrayStr="",pointerStr="";
            bool isValueType = false;
			typeStr+=getTypeName(type,typeContext, ref isValueType);

			if(p_checkTypes)checkPointerType(type,typeContext);
			pointerStr=getPointerStr(type,typeContext,isValueType);
			if(pointerStr!="")typeStr+=pointerStr;
			arrayStr=getArrayStr(type,typeContext,context,isValueType);
			if(arrayStr!="")typeStr+=arrayStr;
			switch(typeContext){
				case EZOETypeContext.CatchVarDecl:
				case EZOETypeContext.FieldDecl:
				case EZOETypeContext.ForVarDecl:
				case EZOETypeContext.LocalVarDecl:
				case EZOETypeContext.ParameterDecl:
					typeStr+=" " + processSimleName(declareName);
					break;
				case EZOETypeContext.PropertyDecl:
				case EZOETypeContext.ReturnTypeDecl:
					break;
				case EZOETypeContext.SizeofExp:
				case EZOETypeContext.GettypeExp:
				case EZOETypeContext.CastExp:
					break;
				case EZOETypeContext.Expression:
					break;
				case EZOETypeContext.Unknow:
					break;
			}
			return typeStr;
		}

        private string processSimleName(string simpleName)
        {
            // check for keyword replace
            if (p_keywordsToReplace.ContainsKey(simpleName))
                simpleName = p_keywordsToReplace[simpleName];
            return simpleName;
        }
        /// <summary>
        /// Render a begin initializer list.
        /// </summary>
        /// <param name="initializerList">The initializer list.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderBeginInitializerList(XplInitializerList initializerList, EZOEContext context)
        {
            return "(";
        }
        /// <summary>
        /// Render a end initializer list.
        /// </summary>
        /// <param name="initializerList">The initializer list.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderEndInitializerList(XplInitializerList initializerList, EZOEContext context)
        {
            return ")";
        }
        /// <summary>
        /// Render a simple initializer.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="expressionStr">The expression STR.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderSimpleInitializer(XplExpression expression, string expressionStr, EZOEContext context)
        {
            return expressionStr;
        }
        /// <summary>
        /// Render a initilizer item.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="nodeStr">The node STR.</param>
        /// <param name="maxNodes">The max nodes.</param>
        /// <param name="count">The count.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderInitilizerItem(XplNode node, string nodeStr, int maxNodes, int count, EZOEContext context)
        {
            if (count == maxNodes) return nodeStr;
            else return nodeStr + ", ";
        }
        /// <summary>
        /// Render a end array initializer.
        /// </summary>
        /// <param name="initializerList">The initializer list.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderEndArrayInitializer(XplInitializerList initializerList, EZOEContext context)
        {
            return "}";
        }
        /// <summary>
        /// Render a begin array initializer.
        /// </summary>
        /// <param name="initializerList">The initializer list.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderBeginArrayInitializer(XplInitializerList initializerList, EZOEContext context)
        {
            return "{";
        }
        #endregion

		#region Instrucciones
        /// <summary>
        /// Renders the begin block.
        /// </summary>
        /// <param name="functionBody">The function body.</param>
        /// <param name="context">The context.</param>
		protected override void renderBeginBlock( XplFunctionBody functionBody, EZOEContext context ){
            writeLineDirective(functionBody.get_ldsrc(), false);
            if (p_prettyOutput) p_lastStatementLine = 0;
            if (p_prettyOutput)
            {
                //PENDIENTE : La modificación de eliminar el bloque cuando no se poseen declaraciones dentro
                //es solo para el proyecto Janus!! OJO!!
                if (context == EZOEContext.FunctionBody &&
                    functionBody.get_Parent().get_TypeName() != CodeDOMTypes.XplFunctionBody /*||
                    functionBody.get_Parent().get_TypeName() == CodeDOMTypes.XplFunctionBody &&
                    functionBody.get_DeclsNodeList().GetLength() > 0*/)
                {
                    writeNewLine();
                    writeOut("{");
                    incNLevel();
                    writeNewLine();
                }
            }
            else
            {
                if (context == EZOEContext.FunctionBody)
                {
                    writeNewLine();
                    writeOut("{");
                    incNLevel();
                    writeNewLine();
                }
            }
		}
        /// <summary>
        /// Renders the end block.
        /// </summary>
        /// <param name="functionBody">The function body.</param>
        /// <param name="context">The context.</param>
		protected override void renderEndBlock( XplFunctionBody functionBody, EZOEContext context ){
            if (p_prettyOutput)
            {
                //PENDIENTE : La modificación de eliminar el bloque cuando no se poseen declaraciones dentro
                //es solo para el proyecto Janus!! OJO!!
                if (context == EZOEContext.FunctionBody &&
                    functionBody.get_Parent().get_TypeName() != CodeDOMTypes.XplFunctionBody /*||
                    functionBody.get_Parent().get_TypeName() == CodeDOMTypes.XplFunctionBody &&
                    functionBody.get_DeclsNodeList().GetLength() > 0*/)
                {
                    decNLevel();
                    writeOut("}");
                    writeNewLine();
                }
            }
            else
            {
                if (context == EZOEContext.FunctionBody)
                {
                    decNLevel();
                    writeOut("}");
                    writeNewLine();
                }
            }
		}
        /// <summary>
        /// Renders the label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="context">The context.</param>
		protected override void renderLabel( XplNode label, EZOEContext context ){
			writeOut(label.get_StringValue()+":");
			writeNewLine();
		}
        /// <summary>
        /// Renders the setonerror.
        /// </summary>
        /// <param name="setOnerror">The set onerror.</param>
        /// <param name="context">The context.</param>
		protected override void renderSetonerror( XplSetonerror setOnerror , EZOEContext context ){
			AddError("Instrucción 'setonerror' no soportada por el modulo de salida.");
		}
        /// <summary>
        /// Renders the comments.
        /// </summary>
        /// <param name="node">The node.</param>
        protected void RenderComments(XplNode node)
        {
            if (node.get_doc() != null && node.get_doc() != "")
            {
                string[] comments = node.get_doc().Split('\n');
                for (int n = 0; n < comments.Length; n++)
                {
                    string comment = comments[n].Replace('\r', ' ').Trim();
                    if (comment != String.Empty)
                    {
                        if (node.get_TypeName() == CodeDOMTypes.XplClass ||
                            node.get_TypeName() == CodeDOMTypes.XplNamespace)
                        {
                            writeOut("/// " + comment);
                        }
                        else
                        {
                            writeOut("// " + comment);
                        }
                        writeNewLine();
                    }
                }
            }
        }
        /// <summary>
        /// Renders the expression statement.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="expressionString">The expression string.</param>
        /// <param name="context">The context.</param>
        protected override void renderExpressionStatement(XplExpression expression, string expressionString, EZOEContext context)
        {
            if (expressionString != "")
            {
                if (p_prettyOutput) UpdateLastStatementLine(expression);
                RenderComments(expression);
                writeLineDirective(expression.get_ldsrc(), false);
                if (expressionString[0] == '[')
                {
                    //es un atributo
                    writeOut(expressionString);
                }
                else
                {
                    writeOut(expressionString + ";");
                }
                writeNewLine();
            }
		}
        /// <summary>
        /// Updates the last statement line.
        /// </summary>
        /// <param name="node">The node.</param>
        private void UpdateLastStatementLine(XplNode node)
        {
            int minLine = 0, maxLine = 0;
            int backupLine = p_lastStatementLine;
            if (!String.IsNullOrEmpty(node.get_ldsrc()))
            {
                string trashData = null;
                parseLDSRC(node.get_ldsrc(), ref minLine, ref  maxLine, ref trashData);
                if (minLine != 0)
                {
                    p_lastStatementLine = minLine;
                    if (minLine > backupLine + 1 && backupLine!=0)
                    {
                        writeNewLine();
                    }
                }
            }            
        }
        /// <summary>
        /// Renders the throw.
        /// </summary>
        /// <param name="throwExpression">The throw expression.</param>
        /// <param name="expressionString">The expression string.</param>
        /// <param name="context">The context.</param>
		protected override void renderThrow(XplExpression throwExpression, string expressionString,EZOEContext context){
            writeLineDirective(throwExpression.get_ldsrc(), false);
            writeOut(ThrowPC + expressionString + ";");
			writeNewLine();
		}
        /// <summary>
        /// Renders the return.
        /// </summary>
        /// <param name="returnExpression">The return expression.</param>
        /// <param name="expressionString">The expression string.</param>
        /// <param name="context">The context.</param>
		protected override void renderReturn(XplExpression returnExpression, string expressionString,EZOEContext context){
            writeLineDirective(returnExpression.get_ldsrc(), false);
            if (expressionString == String.Empty)
            {
                writeOut(ReturnPC + ";");
            }
            else
            {
                writeOut(ReturnPC + " " + expressionString + ";");
            }
			writeNewLine();
		}
        /// <summary>
        /// Renders the local declarator.
        /// </summary>
        /// <param name="decl">The decl.</param>
        /// <param name="varName">Name of the var.</param>
        /// <param name="typeStr">The type STR.</param>
        /// <param name="initializerStr">The initializer STR.</param>
        /// <param name="isVolatile">if set to <c>true</c> [is volatile].</param>
		protected override void renderLocalDeclarator(XplDeclarator decl, string varName, string typeStr, string initializerStr, bool isVolatile){
            writeLineDirective(decl.get_ldsrc(), false);
            if (p_prettyOutput) UpdateLastStatementLine(decl);
            RenderComments(decl);

            if (isVolatile) writeOut(VolatilePC);
            if (decl.get_type().get_const()) writeOut(ConstPC);
			writeOut(typeStr);
			if(initializerStr!="")
                if(decl.get_i().Children().FirstNode().get_ElementName()!="list" || initializerStr[0]!='(')writeOut(" = "+initializerStr);
                else writeOut(initializerStr);
			writeOut(";");
			writeNewLine();
		}
        bool p_isOnCase = false;
        /// <summary>
        /// Renders the begin switch.
        /// </summary>
        /// <param name="switchSta">The switch sta.</param>
        /// <param name="boolExpStr">The bool exp STR.</param>
        /// <param name="context">The context.</param>
        protected override void renderBeginSwitch(XplSwitchStatement switchSta, string boolExpStr, EZOEContext context)
        {
            writeLineDirective(switchSta.get_ldsrc(), false);
            if (p_prettyOutput) UpdateLastStatementLine(switchSta);
            writeOut(SwitchPC + "(" + boolExpStr + ")");
            writeNewLine();
            writeOut("{");
            incNLevel();
			writeNewLine();
			tempStr=boolExpStr;
		}
        /// <summary>
        /// Renders the case label.
        /// </summary>
        /// <param name="caseNode">The case node.</param>
        /// <param name="caseExpStr">The case exp STR.</param>
        /// <param name="context">The context.</param>
		protected override void renderCaseLabel(XplCase caseNode, string caseExpStr, EZOEContext context){
            writeLineDirective(caseNode.get_ldsrc(), false);
            if (p_isOnCase) decNLevel();
            if (caseExpStr == "")
                writeOut(DefaultPC + ":");
            else
                writeOut(CasePC + caseExpStr + ":");
            p_isOnCase = true;
            incNLevel();
            writeNewLine();
        }
        /// <summary>
        /// Renders the end switch.
        /// </summary>
        /// <param name="switchSta">The switch sta.</param>
        /// <param name="context">The context.</param>
		protected override void renderEndSwitch(XplSwitchStatement switchSta, EZOEContext context){
            if (p_isOnCase) decNLevel();
            p_isOnCase = false;
            decNLevel();
            writeOut("}");
            writeNewLine();
            if (p_writeDetailedComments) writeComment("Fin Switch '" + tempStr + "'");
        }
        /// <summary>
        /// Renders if statement.
        /// </summary>
        /// <param name="ifSta">If sta.</param>
        /// <param name="boolExp">The bool exp.</param>
        /// <param name="isElse">if set to <c>true</c> [is else].</param>
        /// <param name="context">The context.</param>
		protected override void renderIfStatement(XplIfStatement ifSta, string boolExp, bool isElse, EZOEContext context){
            writeLineDirective(ifSta.get_ldsrc(), false);
            if (p_prettyOutput) UpdateLastStatementLine(ifSta);
            if (!isElse)
            {
				writeOut(IfPC+"("+boolExp+")");
			}
			else{
				writeOut(ElsePC+IfPC+"("+boolExp+")");
			}
		}
        /// <summary>
        /// Renders the else statement.
        /// </summary>
        /// <param name="ifSta">If sta.</param>
        /// <param name="elseBody">The else body.</param>
        /// <param name="context">The context.</param>
		protected override void renderElseStatement(XplIfStatement ifSta, XplFunctionBody elseBody, EZOEContext context){
            if (elseBody != null) writeOut(ElsePC);
        }
        /// <summary>
        /// Renders for statement.
        /// </summary>
        /// <param name="forSta">For sta.</param>
        /// <param name="initStr">The init STR.</param>
        /// <param name="boolExpStr">The bool exp STR.</param>
        /// <param name="updateStr">The update STR.</param>
        /// <param name="context">The context.</param>
		protected override void renderForStatement(XplForStatement forSta, string initStr, string boolExpStr, string updateStr, EZOEContext context){
            writeLineDirective(forSta.get_ldsrc(), false);
            if (p_prettyOutput) UpdateLastStatementLine(forSta);
            if (updateStr == "_FOR_EACH_")
            {
                writeOut("foreach(" + initStr + " in " + boolExpStr + ")");
            }
            else
            {
                writeOut(ForPC + "(" + initStr + "; " + boolExpStr + "; " + updateStr + ")");
            }
		}
        /// <summary>
        /// Render a for declaration.
        /// </summary>
        /// <param name="decls">The decls.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderForDeclaration(XplDeclaratorlist decls, EZOEContext context){
            XplNodeList listaDeclaraciones = decls.Children();
            //Usamos "varName" para nombre de variable
            //"initStr" para el inicializador (ej: int n "=0")
            //"typeStr" para el tipo (ej: "int[]" a = new int[] {3,4,5,5})
            string varName = "", initStr = "", typeStr = "", backTypeStr = ""; ;
            string retStr = "";
            //for(int a = 0, d, f;; ....
            for (int n = 0; n < listaDeclaraciones.GetLength(); n++)
            {
                XplDeclarator nodo = (XplDeclarator)listaDeclaraciones.GetNodeAt(n);
                varName = nodo.get_name();
                initStr = processInitializer(nodo.get_i(), EZOEContext.Statement);
                typeStr = renderType(nodo.get_type(), "", EZOETypeContext.ForVarDecl, EZOEContext.Statement);
                if (n == 0)
                {
                    backTypeStr = typeStr;
                    retStr += typeStr;
                }
                else
                {
                    //Controlo que el tipo del declarador sea igual al tipo del primer declarador
                    if (typeStr != backTypeStr) //Error
                        AddError("ERROR: tipo inesperado en declaración de variables de bloque for.");
                }
                // Agrego el nombre de la variable
                retStr += " " + varName;
                // Agrego el inicializador
                if (initStr != "")
                    if (nodo.get_i().Children().FirstNode().get_ElementName() != "list") retStr += " = " + initStr;
                    else retStr += initStr;
                // Agrego la coma
                if (n != listaDeclaraciones.GetLength() - 1) retStr += ", ";
            }
            return retStr;
        }
        /// <summary>
        /// Renders the while statement.
        /// </summary>
        /// <param name="doSta">The do sta.</param>
        /// <param name="boolExpStr">The bool exp STR.</param>
        /// <param name="context">The context.</param>
		protected override void renderWhileStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context){
            writeLineDirective(doSta.get_ldsrc(), false);
            writeOut(WhilePC + "(" + boolExpStr + ")");
		}
        /// <summary>
        /// Renders the begin do statement.
        /// </summary>
        /// <param name="doSta">The do sta.</param>
        /// <param name="boolExpStr">The bool exp STR.</param>
        /// <param name="context">The context.</param>
		protected override void renderBeginDoStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context){
            writeLineDirective(doSta.get_ldsrc(), false);
            writeOut(DoPC);
		}
        /// <summary>
        /// Renders the end do statement.
        /// </summary>
        /// <param name="doSta">The do sta.</param>
        /// <param name="boolExpStr">The bool exp STR.</param>
        /// <param name="context">The context.</param>
		protected override void renderEndDoStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context){
            writeLineDirective(doSta.get_ldsrc(), true);
            writeOut(WhilePC + "(" + boolExpStr + ");");
            writeNewLine();
		}
        /// <summary>
        /// Renders the begin try.
        /// </summary>
        /// <param name="trySta">The try sta.</param>
        /// <param name="context">The context.</param>
		protected override void renderBeginTry(XplTryStatement trySta, EZOEContext context){
            writeLineDirective(trySta.get_ldsrc(), false);
            if (p_prettyOutput) UpdateLastStatementLine(trySta);
            writeOut(TryPC);
		}
        /// <summary>
        /// Renders the end try.
        /// </summary>
        /// <param name="trySta">The try sta.</param>
        /// <param name="context">The context.</param>
		protected override void renderEndTry(XplTryStatement trySta, EZOEContext context){
			writeNewLine();
		}
        /// <summary>
        /// Renders the catch statement.
        /// </summary>
        /// <param name="catchSta">The catch sta.</param>
        /// <param name="declExp">The decl exp.</param>
        /// <param name="context">The context.</param>
		protected override void renderCatchStatement(XplCatchStatement catchSta, string declExp, EZOEContext context){
            writeLineDirective(catchSta.get_ldsrc(), false);
            writeOut(CatchPC + "(" + declExp + ")");
		}
        /// <summary>
        /// Renders the finally.
        /// </summary>
        /// <param name="tryBk">The try bk.</param>
        /// <param name="context">The context.</param>
		protected override void renderFinally(XplFunctionBody tryBk, EZOEContext context){
            writeLineDirective(tryBk.get_ldsrc(), false);
            writeOut(FinallyPC);
		}
        /// <summary>
        /// Renders the break.
        /// </summary>
        /// <param name="jump">The jump.</param>
        /// <param name="context">The context.</param>
		protected override void renderBreak(XplJump jump, EZOEContext context){
            writeLineDirective(jump.get_ldsrc(), false);
            writeOut(BreakPC + ";");
			writeNewLine();
		}
        /// <summary>
        /// Renders the continue.
        /// </summary>
        /// <param name="jump">The jump.</param>
        /// <param name="context">The context.</param>
		protected override void renderContinue(XplJump jump, EZOEContext context){
            writeLineDirective(jump.get_ldsrc(), false);
            writeOut(ContinuePC + ";");
			writeNewLine();
		}
        /// <summary>
        /// Renders the goto.
        /// </summary>
        /// <param name="jump">The jump.</param>
        /// <param name="label">The label.</param>
        /// <param name="context">The context.</param>
		protected override void renderGoto(XplJump jump, string label, EZOEContext context){
            writeLineDirective(jump.get_ldsrc(), false);
            writeOut(GotoPC + label + ";");
			writeNewLine();
		}
        /// <summary>
        /// Renders the resume.
        /// </summary>
        /// <param name="jump">The jump.</param>
        /// <param name="context">The context.</param>
		protected override void renderResume(XplJump jump, EZOEContext context){
			AddError("Instrucción 'resume' no soportada por el Modulo de Salida.");
		}
        /// <summary>
        /// Renders the resume next.
        /// </summary>
        /// <param name="jump">The jump.</param>
        /// <param name="context">The context.</param>
		protected override void renderResumeNext(XplJump jump, EZOEContext context){
			AddError("Instrucción 'resume next' no soportada por el Modulo de Salida.");
		}
        /// <summary>
        /// Renders the direct output.
        /// </summary>
        /// <param name="directOutput">The direct output.</param>
        /// <param name="outputStr">The output STR.</param>
        /// <param name="context">The context.</param>
		protected override void renderDirectOutput(XplDirectoutput directOutput, string outputStr, EZOEContext context){
			AddWarning("renderDirectOutput: no implementado en Modulo de Salida.");
		}
        /// <summary>
        /// Renders the onpointer statement.
        /// </summary>
        /// <param name="functionBody">The function body.</param>
        /// <param name="context">The context.</param>
		protected override void renderOnpointerStatement(XplFunctionBody functionBody, EZOEContext context){
			AddError("Instrucción 'onpointer' no soportada por el Modulo de Salida.");
		}
		#endregion

		#region Expresiones
        /// <summary>
        /// Render a get type exp.
        /// </summary>
        /// <param name="xplType">Type of the Zoe.</param>
        /// <param name="typeStr">The type STR.</param>
        /// <param name="eZOEContext">The e Zoe context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderGetTypeExp(XplType xplType, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            return "typeof( "+typeStr+" )";
        }
        /// <summary>
        /// Render a new exp.
        /// </summary>
        /// <param name="newExp">The new exp.</param>
        /// <param name="typeStr">The type STR.</param>
        /// <param name="initializerStr">The initializer STR.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderNewExp(XplNewExpression newExp, string typeStr, string initializerStr, EZOEContext context)
        {
            if (initializerStr != "" && initializerStr[0] != '(' && initializerStr[0] != '{')
            {
                AddWarning("No se permiten inicializadores de expresiones simples en expresiones 'new', sólo son validos inicializadores de matrices y objetos.");
                initializerStr = "";
            }
            //if (initializerStr == "" && newExp.get_type().get_typename() != "" && newExp.get_type().get_typename()[0] != '$')
            if (initializerStr == "" && newExp.get_type().get_typename() != "" )
                return "new " + typeStr + "()";
            else
                return "new " + typeStr + initializerStr;
        }
        /// <summary>
        /// Render a begin expression list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="expCount">The exp count.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderBeginExpressionList(XplExpressionlist list, int expCount, EZOEContext context)
        {
			return "";
		}
        /// <summary>
        /// Render a expression list item.
        /// </summary>
        /// <param name="expNode">The exp node.</param>
        /// <param name="expStr">The exp STR.</param>
        /// <param name="expNumber">The exp number.</param>
        /// <param name="expCount">The exp count.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderExpressionListItem(XplExpression expNode, string expStr, int expNumber, int expCount, EZOEContext context){
			if(expNumber!=expCount)return expStr+", ";
			else return expStr;
		}
        /// <summary>
        /// Render a end expression list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderEndExpressionList(XplExpressionlist list, EZOEContext context){
			return "";
		}
        /// <summary>
        /// Render a simple name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderSimpleName(string name, EZOEContext context){
			//Simplemente asumo que todo es correcto y debo reemplazar "::" por "."
            if (name == "this" || name == "base") return name;
			return processUserTypeName(name);
		}
        /// <summary>
        /// Render a literal.
        /// </summary>
        /// <param name="litNode">The lit node.</param>
        /// <param name="litStr">The lit STR.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderLiteral(XplLiteral litNode, string litStr, EZOEContext context){
			#region Switch de Tipos de Literal
			switch(litNode.get_type()){
                case XplLiteraltype_enum.NULL:
                    tempStr = "null";
                    break;
				case XplLiteraltype_enum.ASCIICHAR:
				case XplLiteraltype_enum.CHAR:
                    tempStr = "'" + litStr + "'";
					break;
				case XplLiteraltype_enum.BOOL:
				case XplLiteraltype_enum.HEX:
				case XplLiteraltype_enum.INTEGER:
				case XplLiteraltype_enum.OCT:
				case XplLiteraltype_enum.REAL:
                case XplLiteraltype_enum.DOUBLE:
                case XplLiteraltype_enum.DECIMAL:
                    tempStr = litStr;
					break;
                case XplLiteraltype_enum.FLOAT:
                    tempStr = litStr + ( litStr.EndsWith("f") ? "" : "f" );
                    break;
                case XplLiteraltype_enum.DATETIME:
				case XplLiteraltype_enum.ASCIISTRING:
				case XplLiteraltype_enum.STRING:
					tempStr="\""+litStr+"\"";
					break;
				case XplLiteraltype_enum.OTHER:
					AddWarning("Literal de tipo 'OTHER' traducida como literal de cadena.");
					tempStr="\""+litStr+"\"";
					break;
				case XplLiteraltype_enum.UUID:
					AddWarning("Literal de tipo 'UUID' traducida como literal de cadena.");
					tempStr="\""+litStr+"\"";
					break;
                default:
                    AddWarning("Literal de tipo no reconocido traducida como literal de cadena.");
                    tempStr = "\"" + litStr + "\"";
                    break;
            }
			#endregion
			return tempStr;
		}
        /// <summary>
        /// Render a delete exp.
        /// </summary>
        /// <param name="deleteExp">The delete exp.</param>
        /// <param name="expStr">The exp STR.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderDeleteExp(XplExpression deleteExp, string expStr, EZOEContext context){
			return DeletePC+expStr;
		}
        /// <summary>
        /// Render a onpointer exp.
        /// </summary>
        /// <param name="onpointerExp">The onpointer exp.</param>
        /// <param name="expStr">The exp STR.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderOnpointerExp(XplExpression onpointerExp, string expStr, EZOEContext context){
			AddError("Expresión 'onpointer' no soportada por el Modulo de Salida.");
			return "/*Expresion Onpointer No Soportada*/";
		}
        /// <summary>
        /// Render a assing exp.
        /// </summary>
        /// <param name="assing">The assing.</param>
        /// <param name="leftExpStr">The left exp STR.</param>
        /// <param name="rightExpStr">The right exp STR.</param>
        /// <param name="operation">The operation.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderAssingExp(XplAssing assing, string leftExpStr, string rightExpStr, XplAssingop_enum operation, EZOEContext context){
			if(p_OptimiseParenthesis && (int)Precedences.AssingExp==getExpressionPrecedence(assing.get_l())){
				leftExpStr="("+leftExpStr+")";
			}
			#region Switch de Operadores de Asignación
			switch(operation){
				case XplAssingop_enum.ADD:
					tempStr=leftExpStr+" += "+rightExpStr;
					break;
				case XplAssingop_enum.AND:
					tempStr=leftExpStr+" &= "+rightExpStr;
					break;
				case XplAssingop_enum.DIV:
					tempStr=leftExpStr+" /= "+rightExpStr;
					break;
				case XplAssingop_enum.LSH:
					tempStr=leftExpStr+" <<= "+rightExpStr;
					break;
				case XplAssingop_enum.MOD:
					tempStr=leftExpStr+" %= "+rightExpStr;
					break;
				case XplAssingop_enum.MUL:
					tempStr=leftExpStr+" *= "+rightExpStr;
					break;
				case XplAssingop_enum.NONE:
					tempStr=leftExpStr+" = "+rightExpStr;
					break;
				case XplAssingop_enum.OR:
					tempStr=leftExpStr+" |= "+rightExpStr;
					break;
				case XplAssingop_enum.RSH:
					tempStr=leftExpStr+" >>= "+rightExpStr;
					break;
				case XplAssingop_enum.SUB:
					tempStr=leftExpStr+" -= "+rightExpStr;
					break;
				case XplAssingop_enum.XOR:
					tempStr=leftExpStr+" ^= "+rightExpStr;
					break;
			}
			#endregion
			//if(p_OptimiseParenthesis && requireParenthesis(assing))tempStr="("+tempStr+")";
			return tempStr;
		}
        /// <summary>
        /// Render a bin op exp.
        /// </summary>
        /// <param name="bopExp">The bop exp.</param>
        /// <param name="leftExpStr">The left exp STR.</param>
        /// <param name="rightExpStr">The right exp STR.</param>
        /// <param name="op">The op.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderBinOpExp(XplBinaryoperator bopExp, string leftExpStr, string rightExpStr, XplBinaryoperators_enum op, EZOEContext context){
			switch(op){
                case XplBinaryoperators_enum.IMP: //Felcha "=>"
                case XplBinaryoperators_enum.M: //Member access "."
                case XplBinaryoperators_enum.MP: //Member Pointer Access ".*"
                case XplBinaryoperators_enum.PM: //Pointer Member Access "->"
                case XplBinaryoperators_enum.PMP: //Pointer To Member Pointer Access "->*"
                case XplBinaryoperators_enum.RM: //Reservado para Acceso a miembros
                    if (p_OptimiseParenthesis && getOperatorPrecedence(op) > getExpressionPrecedence(bopExp.get_l()))
                    {
                        leftExpStr = "(" + leftExpStr + ")";
                    }
                    break;
                default:
                    if (p_OptimiseParenthesis && getOperatorPrecedence(op) == getExpressionPrecedence(bopExp.get_r()))
                    {
                        rightExpStr = "(" + rightExpStr + ")";
                    }
                    break;
            }
			//Bandera para evitar usar parentesis en accesos a miembros
            bool flag = false;
			#region Switch de Operadores Binarios
			switch(op){
				case XplBinaryoperators_enum.ADD: //Suma
                    if (p_prettyOutput)
                    {
                        if (leftExpStr[leftExpStr.Length - 1] == '\"' && rightExpStr[0] == '\"')
                        {
                            tempStr = leftExpStr.Substring(0, leftExpStr.Length - 1) + rightExpStr.Substring(1);
                        }
                        else
                        {
                            tempStr = leftExpStr + " + " + rightExpStr;
                        }
                    }
                    else
                    {
                        tempStr = leftExpStr + " + " + rightExpStr;
                    }
					break;
				case XplBinaryoperators_enum.AND: //Y Logico
                    tempStr = leftExpStr + " && " + rightExpStr;
					break;
				case XplBinaryoperators_enum.BAND: //Y de Bits
                    tempStr = leftExpStr + " & " + rightExpStr;
					break;
				case XplBinaryoperators_enum.BOR: //O de Bits
                    tempStr = leftExpStr + " | " + rightExpStr;
					break;
				case XplBinaryoperators_enum.DIV: //Division
                    tempStr = leftExpStr + " / " + rightExpStr;
					break;
				case XplBinaryoperators_enum.EQ: //Igualdad Logico
                    tempStr = leftExpStr + " == " + rightExpStr;
					break;
				case XplBinaryoperators_enum.EXP: //Exponente
					AddWarning("Operador binario 'EXP' (exponente) no soportado por el Modulo de Salida. Usando '*' en su lugar.");
                    tempStr = leftExpStr + " * " + rightExpStr;
					break;
				case XplBinaryoperators_enum.GR: //Mayor que
                    tempStr = leftExpStr + " > " + rightExpStr;
					break;
				case XplBinaryoperators_enum.GREQ: //Mayor o igual que
                    tempStr = leftExpStr + " >= " + rightExpStr;
					break;
				case XplBinaryoperators_enum.IMP: //Felcha "=>"
					//AddError("Operador binario 'IMP' ('=>') no soportado por el Modulo de Salida. Usando '.' en su lugar.");
					//tempStr=leftExpStr+"."+rightExpStr;flag=true;
                    tempStr = rightExpStr;
                    break;
				case XplBinaryoperators_enum.LS: //Menor que
                    tempStr = leftExpStr + " < " + rightExpStr;
					break;
				case XplBinaryoperators_enum.LSEQ: //Menor o igual que
                    tempStr = leftExpStr + " <= " + rightExpStr;
					break;
				case XplBinaryoperators_enum.LSH: //Left shift
                    tempStr = leftExpStr + " << " + rightExpStr;
					break;
				case XplBinaryoperators_enum.M: //Member access "."
                    //tempStr = leftExpStr + "." + bopExp.get_targetMember(); flag = true;
                    tempStr = (leftExpStr!=String.Empty ? leftExpStr + "." : leftExpStr) + rightExpStr; flag = true;
					break;
				case XplBinaryoperators_enum.MIN: //Resta
                    tempStr = leftExpStr + " - " + rightExpStr;
					break;
				case XplBinaryoperators_enum.MOD: //Modulo (resto)
                    tempStr = leftExpStr + " % " + rightExpStr;
					break;
                case XplBinaryoperators_enum.MP: //Member Pointer Access ".*"
					AddWarning("Operador binario 'MP' ('.*') no soportado por el Modulo de Salida. Usando '.' en su lugar.");
                    tempStr = leftExpStr + "." + rightExpStr; flag = true;
					break;
				case XplBinaryoperators_enum.MUL: //Multiplicacion
                    tempStr = leftExpStr + " * " + rightExpStr;
					break;
				case XplBinaryoperators_enum.NOTEQ: //No Igual logico
                    tempStr = leftExpStr + " != " + rightExpStr;
					break;
				case XplBinaryoperators_enum.OR: //O Logico
                    tempStr = leftExpStr + " || " + rightExpStr;
					break;
                case XplBinaryoperators_enum.PM: //Pointer Member Access "->"
                    tempStr = leftExpStr + "->" + rightExpStr; flag = true;
					break;
                case XplBinaryoperators_enum.PMP: //Pointer To Member Pointer Access "->*"
					AddWarning("Operador binario 'PMP' ('->*') no soportado por el Modulo de Salida. Usando '.' en su lugar.");
                    tempStr = leftExpStr + "." + rightExpStr; flag = true;
					break;
                case XplBinaryoperators_enum.RM: //Reservado para Acceso a miembros
					AddWarning("Operador binario 'RM' (reservado para acceso a miembros) no soportado por el Modulo de Salida. Usando '.' en su lugar.");
                    tempStr = leftExpStr + "." + rightExpStr; flag = true;
					break;
				case XplBinaryoperators_enum.RSH: //Right shift
                    tempStr = leftExpStr + " >> " + rightExpStr;
					break;
				case XplBinaryoperators_enum.XOR: //Xor de Bits
                    tempStr = leftExpStr + " ^ " + rightExpStr;
					break;
			}
			#endregion
			if(p_OptimiseParenthesis){
				if(!flag && requireParenthesis(bopExp))tempStr="("+tempStr+")";
			}
			else
				if(!flag)tempStr="("+tempStr+")";
			return tempStr;
		}
        /// <summary>
        /// Renders ternary operator ?:
        /// </summary>
        /// <param name="bopExp">Original Xpl Node</param>
        /// <param name="o1ExpStr">string for boolean expression</param>
        /// <param name="o2ExpStr">string for true expression</param>
        /// <param name="o3ExpStr">string for false expression</param>
        /// <param name="op">operator</param>
        /// <param name="context">context</param>
        /// <returns>rendered string</returns>
        protected override string renderTernaryOpExp(XplTernaryoperator bopExp, string o1ExpStr, string o2ExpStr, string o3ExpStr, XplTernaryoperators_enum op, EZOEContext context)
        {
            if (op == XplTernaryoperators_enum.BOOLEAN)
            {
                return "((" + o1ExpStr + ") ? (" + o2ExpStr + ") : (" + o3ExpStr + "))";
            }
            else
            {
                AddError("Ternary operator not supported.");
                return "__error__ternary_operator_not_supported__";
            }
        }

        /// <summary>
        /// Render a un op exp.
        /// </summary>
        /// <param name="uopExp">The uop exp.</param>
        /// <param name="expStr">The exp STR.</param>
        /// <param name="op">The op.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderUnOpExp(XplUnaryoperator uopExp, string expStr, XplUnaryoperators_enum op, EZOEContext context){
			#region Switch de Operadores Unarios
			switch(op){
				case XplUnaryoperators_enum.AOF: //Address of '&'
                    //AQUI no debo usar el operador cuando es aplicado para obtenera la direccion de una funcion
                    XplExpression parentExp = (XplExpression)uopExp.get_Parent();
                    if(parentExp.get_lddata().Contains("$INOUT_ARG$"))
                    {
                        tempStr = InoutPC + expStr;
                    }
                    else if (parentExp.get_lddata().Contains("$OUT_ARG$"))
                    {
                        tempStr = OutPC + expStr;
                    }
                    else
                    {
                        if (!p_isUnsafeContext) AddWarning("Operador 'Address of' usado en posible contexto no seguro, posible error.");

                        if (!parentExp.get_typeStr().Contains("/")) tempStr = "&" + expStr;
                        else tempStr = expStr;
                    }
					break;
				case XplUnaryoperators_enum.DEC: //Decremento postfijo 'e--'
					tempStr=expStr+"--";
					break;
				case XplUnaryoperators_enum.INC: //Incremento postfijo 'e++'
					tempStr=expStr+"++";
					break;
				case XplUnaryoperators_enum.IND: //Indireccion de puntero '*'
					if(!p_isUnsafeContext)AddWarning("Operador 'Indirección de Puntero' ('*') usado en posible contexto no seguro, posible error.");
					tempStr="*"+expStr;
					break;
				case XplUnaryoperators_enum.MIN: //Negativo '-'
					tempStr="-"+expStr;
					break;
				case XplUnaryoperators_enum.NOT: //Negado logico '!'
					tempStr="!"+expStr;
					break;
				case XplUnaryoperators_enum.ONECOMP: //Complemento a Uno '~'
					tempStr="~"+expStr;
					break;
				case XplUnaryoperators_enum.PREDEC: //Decremento prefijo '--e'
					tempStr="--"+expStr;
					break;
				case XplUnaryoperators_enum.PREINC: //Incremento prefijo '++e'
					tempStr="++"+expStr;
					break;
				case XplUnaryoperators_enum.RAOF: //Reference AddressOf '&&'
					AddError("Operador unario 'Dirección de Referencia' ('&&') no soportado por el Modulo de Salida.");
					tempStr="&"+expStr;
					break;
				case XplUnaryoperators_enum.SIZEOF:
					AddWarning("Operador unario 'Tamaño de' ('sizeof') no soportado completamente por el Modulo de Salida. Sólo valido para tipos por valor y referenciando el tipo no una expresión.");
					tempStr="sizeof("+expStr+")";
					break;
				case XplUnaryoperators_enum.TYPEOF:
					AddWarning("Operador unario 'Tipo de' ('typeof') posiblemente no implementado correctamente por el Modulo de Salida. Se requiere un tipo, no una expresión.");
					tempStr="typeof("+expStr+")";
					break;
			}
			#endregion
			if(p_OptimiseParenthesis){
				if(requireParenthesis(uopExp))tempStr="("+tempStr+")";
			}
			else tempStr="("+tempStr+")";
			return tempStr;
		}
        /// <summary>
        /// Render a function call exp.
        /// </summary>
        /// <param name="fcallExp">The fcall exp.</param>
        /// <param name="leftExpStr">The left exp STR.</param>
        /// <param name="argsStr">The args STR.</param>
        /// <param name="useBrackets">if set to <c>true</c> [use brackets].</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderFunctionCallExp(XplFunctioncall fcallExp, string leftExpStr, string argsStr, bool useBrackets, EZOEContext context){
            // PENDIENTE : eliminar esto cuando se implemente correctamente el tema de atributos en Zoe
            if (leftExpStr == "Zoe.Attribute.Add")
            {
                return "[" + argsStr.Substring(1, argsStr.Length - 2).Replace("\\\"", "\"") + "]";
            }

            string internalName = fcallExp.get_targetMember();
            if (fcallExp.get_targetMemberExternalName() != "")
            {
                //Debo modificar el leftExpStr
                int index = leftExpStr.LastIndexOf('.');
                if (index > 0)
                {
                    //La expresion izquierda es un acceso a miembro
                    leftExpStr = leftExpStr.Substring(0, index) + "." + fcallExp.get_targetMemberExternalName();
                }
                else
                {
                    index = leftExpStr.LastIndexOf("->");
                    if (index > 0)
                    {
                        //La expresion izquierda es un acceso a miembro de puntero
                        leftExpStr = leftExpStr.Substring(0, index) + "->" + fcallExp.get_targetMemberExternalName();
                    }
                    else
                    {
                    }
                }
            }
            //PENDIENTE : mejorar esto urgente para controlar eventos
            //no puede ser tan choto!!!!            
            if (internalName.Length>3 &&
                internalName.StartsWith("add_")
            ){
                return leftExpStr.Replace("add_","") + "+=" + argsStr;
            }
            else if (
                internalName.Length > 6 &&
                internalName.StartsWith("remove_")
            )
            {
                return leftExpStr.Replace("remove_", "") + "-=" + argsStr;
            }
            else
            {
                if (!useBrackets)
                {
                    return leftExpStr + "(" + argsStr + ")";
                }
                else
                {
                    return leftExpStr + "[" + argsStr + "]";
                }
            }
		}
        /// <summary>
        /// Render a cast exp.
        /// </summary>
        /// <param name="castExp">The cast exp.</param>
        /// <param name="typeStr">The type STR.</param>
        /// <param name="castExpStr">The cast exp STR.</param>
        /// <param name="castType">Type of the cast.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
		protected override string renderCastExp(XplCastexpression castExp, string typeStr, string castExpStr, XplCasttype_enum castType, EZOEContext context){
			tempStr="("+typeStr+")"+castExpStr;
			//if(p_OptimiseParenthesis){
			//	if(requireParenthesis(castExp))tempStr="("+tempStr+")";
			//}
			//else tempStr="("+tempStr+")";
            tempStr = "(" + tempStr + ")"; //Cuidado con esto al corregir lo superior
			return tempStr;
		}		
		#endregion

		#region Documentacion, UnrecognizedNode y Otros
        /// <summary>
        /// Renders the documentation.
        /// </summary>
        /// <param name="documentation">The documentation.</param>
        /// <param name="context">The context.</param>
		protected override void renderDocumentation(XplDocumentation documentation, EZOEContext context){
            if (documentation != null)
            {
                string docStr = documentation.get_short();
                if (!String.IsNullOrEmpty( docStr ) )
                {
                    bool mainComment = false;
                    switch (documentation.get_Parent().get_TypeName())
                    {
                        case CodeDOMTypes.XplDocumentBody:
                        case CodeDOMTypes.XplNamespace:
                        case CodeDOMTypes.XplClass:
                            mainComment = true;
                            break;
                    }
                    string[] comments = docStr.Split('\n');
                    for (int n = 0; n<comments.Length ; n++)
                    {
                        string comment = comments[n].Replace('\r', ' ').Trim();
                        if (comment != String.Empty)
                        {
                            if (mainComment)
                                writeOut("/// " + comment);
                            else
                                writeOut("// " + comment);
                            writeNewLine();
                        }
                    }
                }                
            }
		}
        /// <summary>
        /// Renders the unrecognized node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="context">The context.</param>
		protected override void renderUnrecognizedNode(XplNode node, EZOEContext context){
            writeLineDirective(node.get_ldsrc(), false);
            if (context == EZOEContext.DocumentBody && node.get_ElementName() == "Using")
            {
                //Reconozco un "Using", no hago nada.
            }
            else
            {
                if (node != null) AddWarning("renderUnrecognizedNode: no implementado aún. DATOS: Nombre:'" + node.get_ElementName() + "' Tipo:'" + node.get_TypeName() + "' Contexto:'" + context.ToString() + "'.");
            }
		}
		#endregion

		#endregion

		#region Propiedades
        /// <summary>
        /// Gets or sets a value indicating whether [optimise parenthesis].
        /// </summary>
        /// <value><c>true</c> if [optimise parenthesis]; otherwise, <c>false</c>.</value>
		public bool OptimiseParenthesis{
			get{return p_OptimiseParenthesis;}
			set{p_OptimiseParenthesis=value;}
		}
        /// <summary>
        /// Gets or sets a value indicating whether [check types].
        /// </summary>
        /// <value><c>true</c> if [check types]; otherwise, <c>false</c>.</value>
		public bool CheckTypes{
			get{return p_checkTypes;}
			set{p_checkTypes=value;}
		}
        /// <summary>
        /// Gets or sets a value indicating whether [dont write copyright comment].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [dont write copyright comment]; otherwise, <c>false</c>.
        /// </value>
		public bool DontWriteCopyrightComment{
			get{return p_dontWriteCopyrightComment;}
			set{p_dontWriteCopyrightComment=value;}
		}
        /// <summary>
        /// Gets or sets a value indicating whether [write detailed comments].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [write detailed comments]; otherwise, <c>false</c>.
        /// </value>
		public bool WriteDetailedComments{
			get{return p_writeDetailedComments;}
			set{p_writeDetailedComments=value;}
		}
        /// <summary>
        /// Gets or sets the name of the output file.
        /// </summary>
        /// <value>The name of the output file.</value>
		public string OutputFileName{
			get{return p_outputFileName;}
			set{p_outputFileName=value;p_newFilePerClass=false;}
		}
        /// <summary>
        /// Gets or sets a value indicating whether [new file per class].
        /// </summary>
        /// <value><c>true</c> if [new file per class]; otherwise, <c>false</c>.</value>
		public bool NewFilePerClass{
			get{return p_newFilePerClass;}
			set{p_newFilePerClass=value;}
		}
        /// <summary>
        /// Gets or sets a value indicating whether [apply format].
        /// </summary>
        /// <value><c>true</c> if [apply format]; otherwise, <c>false</c>.</value>
		public bool ApplyFormat{
			get{return p_applyFormat;}
			set{p_applyFormat=value;}
		}
        /// <summary>
        /// Gets or sets a value indicating whether [build full types].
        /// </summary>
        /// <value><c>true</c> if [build full types]; otherwise, <c>false</c>.</value>
        public bool BuildFullTypes{
            get{return p_buildFullType;}
            set{p_buildFullType=value;}
        }
		#endregion

        #region IEZOERender Members
        /// <summary>
        /// Returns the last parse error collection. It can return null if there isn't
        /// errors or an empty collection
        /// </summary>
        /// <returns>Last parse error colletion.</returns>
        public IErrorCollection GetLastParseErrors()
        {
            return this.p_errors;
        }

        /// <summary>
        /// Set if generation is for debug mode.
        /// </summary>
        /// <param name="isDebugMode">True for debug mode code generation.</param>
        public void SetDebug(bool isDebugMode)
        {
            this.p_isDebugMode = isDebugMode;
        }

        /// <summary>
        /// Called by Zoe compiler with an error list when need the generation
        /// of debug intermediate render file.
        /// If the Zoe output module does not support this mode return false,
        /// otherwise return true and generate intermediate debug render file
        /// and update error list adding one more error for each error in the
        /// collection to match the generated output lines/columns numbers.
        /// </summary>
        /// <param name="zoeErrors">The collection of errors supplied by Zoe compiler.</param>
        /// <returns>
        /// True if the Zoe Output Module support the generation
        /// of intermediate debug file and mapping of errors to generated
        /// code. False if Zoe Output Module does not support this mode.
        /// </returns>
        public bool SetZoeErrorListToMap(LayerD.ZOECompiler.IErrorCollection zoeErrors)
        {
            return false;
        }
        /// <summary>
        /// Sets the name of the EZOE input file.
        /// </summary>
        /// <param name="EZOEInputFileName">Name of the EZOE input file.</param>
        public void SetEZOEInputFileName(string EZOEInputFileName)
        {
            p_inputFileName = EZOEInputFileName;
        }
        /// <summary>
        /// Sets the EZOE input document.
        /// </summary>
        /// <param name="EZOEInputDocument">The EZOE input document.</param>
        public void SetEZOEInputDocument(XplDocument EZOEInputDocument)
        {
            p_XplDocument = EZOEInputDocument;
        }
        /// <summary>
        /// Inicia el proceso de renderización y/o construcción.
        /// "renderOnly" - Indica que no se debe construir el modulo, sólo generar el código intermedio.
        /// "buildArguments" - Una cadena con argumentos extra a pasar al proceso de construcción
        /// generalmente a un compilador.
        /// "renderArguments" - Una cadena con argumentos a ser porcesados por el renderizador
        /// de código. Ej: Indicarle que guarde el código ZOE recibido, etc.
        /// </summary>
        /// <param name="renderOnly">Indica si sólo renderiza el código intermedio usado pero no compila</param>
        /// <param name="buildArguments">Argumentos de compilación</param>
        /// <param name="renderArguments">Argumentos de renderización</param>
        /// <returns>True if succesful</returns>
        public bool StartParseDocument(bool renderOnly, string buildArguments, string renderArguments)
        {
            bool parseResult = false;
            if (renderOnly)
                p_dontWriteLineDirecties = true;
            //Primero renderizo la representación intermedia en C#
            try
            {
                if (renderArguments != null)
                {
                    string[] renderArgs = renderArguments.Split(',');
                    foreach (string renderArgument in renderArgs)
                    {
                        //Proceso los argumentos de renderizacion
                        //Por ahora solo considero la grabación del código recibido
                        if (renderArgument.ToLower() == "save_ezoe" && p_XplDocument != null)
                        {
                            XplWriter writer = null;
                            try
                            {
                                if (p_outputPath == null) p_outputPath = "";
                                writer = new XplWriter(Path.Combine(p_outputPath, Path.GetFileNameWithoutExtension(p_outputFileName) + "_dotnet.ezoe"));
                                p_XplDocument.Write(writer);
                            }
                            finally
                            {
                                if (writer != null) writer.Close();
                            }
                        }
                    }
                    if (renderArguments.ToLower() == "pretty")
                    {
                        p_prettyOutput = true;
                        p_dontWriteLineDirecties = true;
                    }
                }
                p_namespaceToRemove = "";
                p_assemblyList.Clear();
                PrepareOutput();
                parseResult = base.ParseDocument();
            }
            finally
            {
                CloseOutput();
            }
            if (renderOnly)
            {
                RenderIntermediateOutputFiles();
            }
            if (p_prettyOutput)
            {
                RenderPrettyOutput();
            }
            else
            {
                //Construyo la salida
                if (!renderOnly && parseResult)
                {
                    return BuildModule(buildArguments);
                }
            }
            return parseResult;
        }

        private void RenderPrettyOutput()
        {
            foreach (ClassInfo classInfo in p_classInfos)
            {
                RenderClassInfo(classInfo);
            }
        }

        private void RenderClassInfo(ClassInfo classInfo)
        {
            if (p_outputPath == null) p_outputPath = ".";
            string outputFolder = Path.GetFullPath( Path.Combine(p_outputPath, classInfo.Namespace) );
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }
            string outputFile = Path.Combine(outputFolder, classInfo.ClassName + ".cs");

            StreamWriter currentWriter = null;
            try
            {
                currentWriter = new StreamWriter(outputFile, false, p_outputEncoding);
                foreach (string usingStr in classInfo.Usings.Keys)
                {
                    string usingStr2 = usingStr;
                    if (usingStr2.StartsWith(p_namespaceToRemove)) usingStr2 = usingStr2.Substring(p_namespaceToRemove.Length + 1);
                    currentWriter.WriteLine(UsingPC + usingStr2 + ";");
                }
                currentWriter.WriteLine();
                currentWriter.WriteLine(NamespacePC + classInfo.Namespace);
                currentWriter.WriteLine("{");
                currentWriter.WriteLine();

                for (int n = classInfo.FirstLine; n < classInfo.LastLine; n++)
                {
                    currentWriter.WriteLine(p_currentFileLines[n]);
                }
                currentWriter.WriteLine();
                currentWriter.WriteLine("}");
                currentWriter.WriteLine();
            }
            catch (IOException ioError)
            {
                AddWarning("IO Error while saving intermediate files. " + ioError.Message);
            }
            finally
            {
                if (currentWriter != null) currentWriter.Close();
            }
        }

        /// <summary>
        /// Renders the intermediate output files.
        /// </summary>
        private void RenderIntermediateOutputFiles()
        {
            p_intermediateFile = p_outputPath + Path.GetFileNameWithoutExtension(p_outputFileName) + ".cs";
            RenderInternalIntermediateOutput(p_intermediateFile);
        }

        /// <summary>
        /// Renders the internal intermediate output.
        /// </summary>
        /// <param name="outputFileName">Name of the output file.</param>
        /// <returns>True if successful</returns>
        private bool RenderInternalIntermediateOutput(string outputFileName)
        {
            try
            {
                currentWriter = new StreamWriter(outputFileName, false, p_outputEncoding);
                foreach (string line in p_currentFileLines)
                    currentWriter.WriteLine(line);
                if (currentWriter != null) currentWriter.Close();
            }
            catch (IOException ioError)
            {
                AddWarning("IO Error while saving intermediate files. " + ioError.Message);
                return false;
            }
            return true;
        }

        #region Construccion de Modulos
        Assembly p_lastInMemoryCompiledAssembly;
        bool p_compileInMemory;

        /// <summary>
        /// Gets the last in memory compiled assembly.
        /// </summary>
        /// <value>The last in memory compiled assembly.</value>
        public Assembly LastInMemoryCompiledAssembly
        {
            get { return p_lastInMemoryCompiledAssembly; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether to compile in memory.
        /// </summary>
        /// <value><c>true</c> if true compile in memory otherwise on disk.</value>
        public bool CompileInMemory
        {
            get { return p_compileInMemory; }
            set { p_compileInMemory = value; }
        }

        private bool BuildModule(string buildArguments)
        {
            XplLayerDZoeProgramConfig config = null;
            bool buildDll = false;
            if (p_XplDocument.get_DocumentData().get_Config() != null)
            {
                config = (XplLayerDZoeProgramConfig)p_XplDocument.get_DocumentData().get_Config().get_Content();
                switch (config.get_moduleType())
                {
                    case XplLayerDZoeProgramModuletype_enum.EXECUTABLE:
                        buildDll = false;
                        break;
                    case XplLayerDZoeProgramModuletype_enum.DYNAMIC_LIB:
                        buildDll = true;
                        break;
                    case XplLayerDZoeProgramModuletype_enum.STATIC_LIB:
                    case XplLayerDZoeProgramModuletype_enum.SCRIPT:
                    case XplLayerDZoeProgramModuletype_enum.OTHER:
                    default:
                        AddError("Program Module Type not supported by C# Output Module.");
                        break;
                }
            }
            CompilerParameters cp = new CompilerParameters();
            // Generate an executable instead of 
            // a class library.
            cp.GenerateExecutable = !buildDll;
            // Set the assembly file name to generate.
            if (!p_compileInMemory)
                cp.OutputAssembly = Path.Combine(p_outputPath != null ? p_outputPath : "", Path.GetFileName(p_outputFileName));
            else
                cp.OutputAssembly = "";
            // Generate debug information.
            cp.IncludeDebugInformation = true;
            // Add an assembly reference.
            bool ignoreMscorlib = false;
            if(buildArguments!=null){
                ignoreMscorlib = buildArguments.ToUpperInvariant().Contains("MSCORLIB.DLL");
            }
            foreach (string assemblyName in p_assemblyList)
            {
                if (!ignoreMscorlib || !assemblyName.ToUpperInvariant().Contains("MSCORLIB.DLL"))
                    cp.ReferencedAssemblies.Add(assemblyName);
            }
            // Save the assembly as a physical file.
            cp.GenerateInMemory = p_compileInMemory;
            // Set the level at which the compiler 
            // should start displaying warnings.
            cp.WarningLevel = 3;
            // Set whether to treat all warnings as errors.
            cp.TreatWarningsAsErrors = false;
            // Set compiler argument to optimize output.
            cp.CompilerOptions = buildArguments;

            CodeDomProvider provider = Microsoft.CSharp.CSharpCodeProvider.CreateProvider("CSharp");
            if (provider == null) return false;

            string tempFile = Path.GetTempFileName();
            RenderInternalIntermediateOutput(tempFile);
            CompilerResults cr = provider.CompileAssemblyFromFile(cp, tempFile );

            if (cr.Errors.Count > 0)
            {
                // Add compilation errors.
                foreach (CompilerError ce in cr.Errors)
                {
                    string errStr = ce.FileName + "(" + ce.Line + "):" + ce.ErrorNumber + " - " + ce.ErrorText;
                    if (ce.IsWarning)
                        AddWarning(errStr);
                    else
                        AddError(errStr);
                }
                return p_errors.get_ErrorsCount()==0;
            }
            else{
                p_lastInMemoryCompiledAssembly = cr.CompiledAssembly;                
                return true;
            }
        }
        #endregion

        /// <summary>
        /// Establece el Path de salida para el archivo a construir o la
        /// representación intermedia cuando se llama a "StartParseDocument" con
        /// "renderOnly" en "true".
        /// Si no se llama a esta interfaz, se utilizará el path extraido
        /// del archivo de salida, si el archivo de salida no especifica
        /// ruta se usuara la ruta actual del proceso.
        /// </summary>
        /// <param name="outputPath">El path de salida</param>
        public void SetOutputPath(string outputPath)
        {
            if (outputPath == null) return;
            if (outputPath[outputPath.Length - 1] != Path.DirectorySeparatorChar)
                outputPath += Path.DirectorySeparatorChar;
            p_outputPath = outputPath;
        }
        /// <summary>
        /// Sets the name of the output file.
        /// </summary>
        /// <param name="EZOEOutputFileName">Name of the EZOE output file.</param>
        public void SetOutputFileName(string EZOEOutputFileName)
        {
            p_outputFileName = EZOEOutputFileName;
        }
        /// <summary>
        /// Establece el tipo de modulo a construir, en general
        /// un ejecutable, libreria dinamica o estática, script, etc.
        /// Si no se llama nunca a esta interfaz antes de llamar
        /// a "StartParseDocument" se debe asumir ejecutable.
        /// </summary>
        /// <param name="moduleType">Type of module to generate</param>
        public void SetOutputType(XplLayerDZoeProgramModuletype_enum moduleType)
        {
            p_outputModuleType = moduleType;
        }
        #endregion

        /// <summary>
        /// Renders the expression.
        /// </summary>
        /// <param name="xplExpression">The Zoe expression.</param>
        /// <returns>A String value.</returns>
        public string RenderExpression(XplExpression xplExpression)
        {
            return processExpression(xplExpression, EZOEContext.FunctionBody);
        }

        /// <summary>
        /// Renders the using directive.
        /// </summary>
        /// <param name="xplName">Name of the Zoe.</param>
        /// <param name="eZOEContext">The e Zoe context.</param>
        protected override void renderUsingDirective(XplName xplName, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            //No hago nada
            writeLineDirective(xplName.get_ldsrc(), false);

            //Add to full usings list
            if (p_prettyOutput)
            {
                string usingStr = xplName.Children().FirstNode().get_StringValue();
                if (usingStr.StartsWith(p_namespaceToRemove))
                {
                    usingStr = usingStr.Replace("::",".");
                    if (p_namespaceToRemove != "" && usingStr.StartsWith(p_namespaceToRemove))
                        usingStr = usingStr.Remove(0, p_namespaceToRemove.Length + 1);

                    if (!p_usings.ContainsValue(usingStr))
                    {
                        p_usings.Add(usingStr.Length + Convert.ToSingle("." + p_usings.Count.ToString(NumberFormatInfo.InvariantInfo), NumberFormatInfo.InvariantInfo) , usingStr);
                    }
                }
            }
        }

        /// <summary>
        /// Render a writecode expression.
        /// </summary>
        /// <param name="xplExpression">The Zoe expression.</param>
        /// <param name="expStr">The exp STR.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderWritecodeExpression(XplExpression xplExpression, string expStr, ExtendedZOEProcessor.EZOEContext context)
        {
            //throw new Exception("The method or operation is not implemented.");
            return "";
        }

        /// <summary>
        /// Render a writecode block.
        /// </summary>
        /// <param name="xplWriteCodeBody">The Zoe write code body.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderWritecodeBlock(XplWriteCodeBody xplWriteCodeBody, ExtendedZOEProcessor.EZOEContext context)
        {
            //throw new Exception("The method or operation is not implemented.");
            return "";
        }


        /// <summary>
        /// Render a type of exp.
        /// </summary>
        /// <param name="typeofExpNode">The typeof exp node.</param>
        /// <param name="typeStr">The type STR.</param>
        /// <param name="eZOEContext">The e Zoe context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderTypeOfExp(XplType typeofExpNode, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            return "typeof( " + typeStr + " )";
        }

        /// <summary>
        /// Render a is exp.
        /// </summary>
        /// <param name="xplExpression">The Zoe expression.</param>
        /// <param name="expStr">The exp STR.</param>
        /// <param name="typeStr">The type STR.</param>
        /// <param name="eZOEContext">The e Zoe context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderIsExp(XplCastexpression xplExpression, string expStr, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            if (p_OptimiseParenthesis)
            {
                XplNode parent = xplExpression.get_Parent().get_Parent();
                if (parent != null && parent.get_TypeName() == CodeDOMTypes.XplExpression)
                {
                    //Si el parent no es nulo y es otra expresion
                    if (getExpressionPrecedence((XplExpression)parent) > (int)Precedences.IsExp)
                        return "(" + expStr + " is " + typeStr + ")";
                    else
                        return expStr + " is " + typeStr;
                }                
            }
            return "(" + expStr + " is " + typeStr + ")";
        }

    }
}
