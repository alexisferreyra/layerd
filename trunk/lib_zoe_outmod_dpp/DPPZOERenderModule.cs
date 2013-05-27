/****************************************************************************
 
  Meta D++ Output Module for Zoe compiler (for interactive compiling)
  
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
using LayerD.ZOECompiler;
using System.Collections.Generic;
using System.Globalization;
using System.Collections.Specialized;

namespace LayerD.OutputModules
{
	/// <summary>
	/// CSZOEOutputModule:
	/// 
	/// Generador de Código ZOE a código C#.
	/// Extiende la clase abstracta ExtendedZOEProcessor e implementa
	/// las funciones de renderización de elementos.
	/// </summary>
	public class DPPZOERenderModule: ExtendedZOEProcessor, IEZOERender
	{
		#region Tipos privados
		private enum FunctionType{
			Method,
			Indexer,
			Operator,
			Property
		}
		private enum Precedences{
			PrimaryExp=-1,
			BracketExp=-1,
			FunctionCallExp=-1,
			NewExp=-1,
			DeleteExp=-2,
			CastExp=-2,
			ConditionalExp=-13,
			AssingExp=-14
		}
		#endregion

		#region Datos Protegidos para Palabras Claves
        const string ImportPC = "import ";
		const string UsingPC="using ";
		const string NamespacePC="namespace ";
		const string ClassPC="class ";
		const string StructPC="struct ";
        const string EnumPC="enum ";
		const string InterfacePC="interface ";
        const string InheritsPC = "inherits ";
        const string ImplementsPC = "implements ";
		const string AbstractPC="abstract ";
		const string FinalPC="final ";
		const string NewPC="new ";
		const string VolatilePC="volatile ";
		const string ConstPC="const ";
		const string PrivatePC="private ";
		const string ProtectedPC="protected ";
		const string PublicPC="public ";
        const string IPrivatePC = "iprivate ";
        const string IProtectedPC = "iprotected ";
        const string IPublicPC = "ipublic ";
        const string InternalPC = "internal ";
        const string PropertyPC = "property ";
		const string FpPC = "fp ";
		const string ExplicitPC="explicit ";
		const string ImplicitPC="implicit ";
		const string OperatorPC="operator ";
		const string VirtualPC="virtual ";
		const string OverridePC="override ";
		const string IndexerPC="indexer ";
		const string ParamsPC="params ";
		const string InPC="in ";
		const string InoutPC="inout ";
		const string OutPC="out ";
		const string ReturnPC="return ";
		const string ThrowPC="throw ";
		const string SwitchPC="switch ";
		const string BreakPC="break ";
		const string CatchPC="catch ";
		const string ContinuePC="continue ";
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
        const string FactoryPC = "factory ";
        const string InteractivePC = "interactive ";
        const string ExecPC = "exec ";
        const string ExpPC = "exp ";
        const string INamePC = "iname ";
        const string WritecodePC = "writecode";
        const string GettypePC = "gettype";
        const string ExtensionPC = "extension ";
		#endregion

		#region Datos Privados o Protegidos
		string p_outputFileName="";
		bool p_dontWriteCopyrightComment=true;
		bool p_newFilePerClass=false;
		bool p_writeDetailedComments=false;
		bool p_isUnsafeContext=false;
		bool p_applyFormat=true;
		bool p_checkTypes=false;
		bool p_newLineFlag=true;
		bool p_OptimiseParenthesis=true;
        bool p_buildFullType = true;
        string p_namespaceToRemove = "";
        bool p_dontWriteLineDirectives = true;
        bool p_isDebugMode;

		TextWriter currentWriter=null;
		System.Text.Encoding p_outputEncoding=System.Text.Encoding.UTF8;
		int p_nestingLevel=0;
		int p_maxParameter=0;
		string p_tabString="";
		FunctionType currentFunctionType=FunctionType.Method;
        /// Variables para el seguimiento de archivo y linea
        string p_CurrentSourceFile = "";
        int p_CurrentRealLine = 0;
        /// Cadena para trabajo temporario
		string tempStr="";

        string p_outputPath=null;
        XplLayerDZoeProgramModuletype_enum p_outputModuleType = XplLayerDZoeProgramModuletype_enum.EXECUTABLE;
        string p_intermediateFile = "";
        ErrorCollection p_errors = new ErrorCollection();
        ArrayList p_assemblyList = new ArrayList();
        XplAccesstype_enum p_currentAccess = XplAccesstype_enum.PRIVATE;
        bool p_onWritecode = false;
        string p_currentWritecodeStr;
        string p_currentNamespace = "";
        SortedList p_usings = new SortedList();
        Dictionary<XplNode, IError> p_nodesToErrors;
        static Dictionary<string, string> p_keywordsToReplace = new Dictionary<string, string>();
        #endregion

		#region Constructores
        static DPPZOERenderModule()
        {
            // Meta D++ keywords initialization
            p_keywordsToReplace.Add("null", "@null");
            p_keywordsToReplace.Add("true", "@true");
            // p_keywordsToReplace.Add("TRUE", "@TRUE");
            p_keywordsToReplace.Add("false", "@false");
            // p_keywordsToReplace.Add("FALSE", "@FALSE");
            p_keywordsToReplace.Add("import", "@import");
            p_keywordsToReplace.Add("using", "@using");
            p_keywordsToReplace.Add("identifiers", "@identifiers");
            p_keywordsToReplace.Add("alias", "@alias");
            p_keywordsToReplace.Add("namespace", "@namespace");
            p_keywordsToReplace.Add("class", "@class");
            p_keywordsToReplace.Add("enum", "@enum");
            p_keywordsToReplace.Add("union", "@union");
            p_keywordsToReplace.Add("interface", "@interface");
            p_keywordsToReplace.Add("inherits", "@inherits");
            p_keywordsToReplace.Add("implements", "@implements");
            p_keywordsToReplace.Add("virtual", "@virtual");
            p_keywordsToReplace.Add("nonvirtual", "@nonvirtual");
            p_keywordsToReplace.Add("like", "@like");
            p_keywordsToReplace.Add("setplatforms", "@setplatforms");
            p_keywordsToReplace.Add("autoinstance", "@autoinstance");
            p_keywordsToReplace.Add("bycall", "@bycall");
            p_keywordsToReplace.Add("byclass", "@byclass");
            p_keywordsToReplace.Add("bynamespace", "@bynamespace");
            p_keywordsToReplace.Add("bycallto", "@bycallto");
            p_keywordsToReplace.Add("fp", "@fp");
            p_keywordsToReplace.Add("public", "@public");
            p_keywordsToReplace.Add("protected", "@protected");
            p_keywordsToReplace.Add("private", "@private");
            p_keywordsToReplace.Add("ipublic", "@ipublic");
            p_keywordsToReplace.Add("iprotected", "@iprotected");
            p_keywordsToReplace.Add("iprivate", "@iprivate");
            p_keywordsToReplace.Add("static", "@static");
            p_keywordsToReplace.Add("const", "@const");
            p_keywordsToReplace.Add("volatile", "@volatile");
            p_keywordsToReplace.Add("extern", "@extern");
            p_keywordsToReplace.Add("force", "@force");
            p_keywordsToReplace.Add("factory", "@factory");
            p_keywordsToReplace.Add("interactive", "@interactive");
            p_keywordsToReplace.Add("keyword", "@keyword");
            p_keywordsToReplace.Add("final", "@final");
            p_keywordsToReplace.Add("new", "@new");
            p_keywordsToReplace.Add("override", "@override");
            p_keywordsToReplace.Add("abstract", "@abstract");
            p_keywordsToReplace.Add("params", "@params");
            p_keywordsToReplace.Add("in", "@in");
            p_keywordsToReplace.Add("out", "@out");
            p_keywordsToReplace.Add("inout", "@inout");
            p_keywordsToReplace.Add("ref", "@ref");
            p_keywordsToReplace.Add("extension", "@extension");
            p_keywordsToReplace.Add("ordinary", "@ordinary");
            p_keywordsToReplace.Add("struct", "@struct");
            p_keywordsToReplace.Add("operator", "@operator");
            p_keywordsToReplace.Add("indexer", "@indexer");
            p_keywordsToReplace.Add("property", "@property");
            p_keywordsToReplace.Add("get", "@get");
            p_keywordsToReplace.Add("readonly", "@readonly");
            p_keywordsToReplace.Add("blocktofactorys", "@blocktofactorys");
            p_keywordsToReplace.Add("except", "@except");
            p_keywordsToReplace.Add("set", "@set");
            p_keywordsToReplace.Add("resume", "@resume");
            p_keywordsToReplace.Add("break", "@break");
            p_keywordsToReplace.Add("continue", "@continue");
            p_keywordsToReplace.Add("writecode", "@writecode");
            p_keywordsToReplace.Add("if", "@if");
            p_keywordsToReplace.Add("else", "@else");
            p_keywordsToReplace.Add("while", "@while");
            p_keywordsToReplace.Add("do", "@do");
            p_keywordsToReplace.Add("for", "@for");
            p_keywordsToReplace.Add("foreach", "@foreach");
            p_keywordsToReplace.Add("switch", "@switch");
            p_keywordsToReplace.Add("case", "@case");
            p_keywordsToReplace.Add("default", "@default");
            p_keywordsToReplace.Add("return", "@return");
            p_keywordsToReplace.Add("throw", "@throw");
            p_keywordsToReplace.Add("try", "@try");
            p_keywordsToReplace.Add("catch", "@catch");
            p_keywordsToReplace.Add("finally", "@finally");
            p_keywordsToReplace.Add("delete", "@delete");
            p_keywordsToReplace.Add("bool", "@bool");
            p_keywordsToReplace.Add("void", "@void");
            p_keywordsToReplace.Add("object", "@object");
            p_keywordsToReplace.Add("sbyte", "@sbyte");
            p_keywordsToReplace.Add("short", "@short");
            p_keywordsToReplace.Add("int", "@int");
            p_keywordsToReplace.Add("long", "@long");
            p_keywordsToReplace.Add("unsigned", "@unsigned");
            p_keywordsToReplace.Add("byte", "@byte");
            p_keywordsToReplace.Add("ushort", "@ushort");
            p_keywordsToReplace.Add("uint", "@uint");
            p_keywordsToReplace.Add("ulong", "@ulong");
            p_keywordsToReplace.Add("float", "@float");
            p_keywordsToReplace.Add("double", "@double");
            p_keywordsToReplace.Add("decimal", "@decimal");
            p_keywordsToReplace.Add("char", "@char");
            p_keywordsToReplace.Add("ASCIIChar", "@ASCIIChar");
            p_keywordsToReplace.Add("string", "@string");
            p_keywordsToReplace.Add("ASCIIString", "@ASCIIString");
            p_keywordsToReplace.Add("type", "@type");
            p_keywordsToReplace.Add("block", "@block");
            p_keywordsToReplace.Add("expression", "@expression");
            p_keywordsToReplace.Add("exp", "@exp");
            p_keywordsToReplace.Add("expressionlist", "@expressionlist");
            p_keywordsToReplace.Add("iname", "@iname");
            p_keywordsToReplace.Add("statement", "@statement");
            p_keywordsToReplace.Add("sizeof", "@sizeof");
            p_keywordsToReplace.Add("typeof", "@typeof");
            p_keywordsToReplace.Add("gettype", "@gettype");
            p_keywordsToReplace.Add("exec", "@exec");
            p_keywordsToReplace.Add("is", "@is");
        }
		public DPPZOERenderModule():base()
		{
		}
		public DPPZOERenderModule(string inputFileName):base(inputFileName){
		}
		public DPPZOERenderModule(string inputFileName, bool newFilePerClass):base(inputFileName){
			p_newFilePerClass=newFilePerClass;
		}
		public DPPZOERenderModule(string inputFileName, string outputFileName):base(inputFileName){
			p_outputFileName=outputFileName;
			p_newFilePerClass=false;
		}
		#endregion

		#region Miembros Privados Utilitarios

		#region PrepareOutput, CloseOutput, writeOut, writeNewLine, incNlevel, decNlevel, writeLineDirective
        private void writeLineDirective(string ldsrc,bool isMaxLine)
        {
            if(p_dontWriteLineDirectives) return;
            ///No escribo line directives para dpp :-)
            if (ldsrc == null) return;
            ///Debo parsear ldsrc para obtener las lineas y los archivos origen
            int minLine = 0, maxLine = 0;
            string currentFile = "";
            parseLDSRC(ldsrc, ref minLine,ref  maxLine, ref currentFile);
            if (currentFile != "") currentFile=GetRelativeToOutputSourceFileName(currentFile);
            
            if (isMaxLine)
            {
                if (currentFile != "" && currentFile != p_CurrentSourceFile)
                {
                    p_CurrentSourceFile = currentFile;
                    if (maxLine != p_CurrentRealLine && maxLine > 0) { writeLineDirectiveText("#line " + maxLine + " \"" + p_CurrentSourceFile + "\""); p_CurrentRealLine = maxLine; }
                }
                else
                    if (maxLine != p_CurrentRealLine && maxLine > 0) { writeLineDirectiveText("#line " + maxLine); p_CurrentRealLine = maxLine; }
            }
            else
            {
                if (currentFile != "" && currentFile != p_CurrentSourceFile)
                {
                    p_CurrentSourceFile = currentFile;
                    if (minLine != p_CurrentRealLine && minLine > 0) { writeLineDirectiveText("#line " + minLine + " \"" + p_CurrentSourceFile + "\""); p_CurrentRealLine = minLine; }
                }
                else
                    if (minLine != p_CurrentRealLine && minLine > 0) { writeLineDirectiveText("#line " + minLine); p_CurrentRealLine = minLine; }
            }
        }

        private void writeLineDirectiveText(string p)
        {
            if (p_newLineFlag)
            {
                currentWriter.WriteLine(p);
            }
            else
            {
                writeNewLine();
                currentWriter.WriteLine(p);
            }
        }

        private string GetRelativeToOutputSourceFileName(string currentFile)
        {
            ///Se lo deberia mejorar para calcular un path relativo
            ///al archivo de entrada.
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
                p_intermediateFile = p_outputPath + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(p_outputFileName) + ".dpp";
                if (File.Exists(p_intermediateFile))
                {
                    File.Delete(p_intermediateFile + ".bak");
                    File.Move(p_intermediateFile, p_intermediateFile + ".bak");
                }
				currentWriter=new StreamWriter(p_intermediateFile,false); //,p_outputEncoding);
			}
			else{
				throw new NotImplementedException("La capacidad para generar un archivo por clase no esta implementada.");
			}
		}
		private void CloseOutput(){
			if(!p_newFilePerClass){
				if(currentWriter!=null)currentWriter.Close();
			}
			else{
				throw new NotImplementedException("La capacidad para generar un archivo por clase no esta implementada.");
			}
		}
		private void writeOut(string str){
			//Super simple!!
            if (p_onWritecode)
            {
                if (p_newLineFlag)
                {
                    p_currentWritecodeStr += p_tabString;
                    p_newLineFlag = false;
                }
                p_currentWritecodeStr += str;
            }
            else
            {
                if (p_newLineFlag)
                {
                    currentWriter.Write(p_tabString);
                    p_newLineFlag = false;
                }
                currentWriter.Write(str);
            }
		}
		private void writeNewLine(){
            if (p_onWritecode)
            {
                p_currentWritecodeStr += "\n";
                p_newLineFlag = true;
                p_CurrentRealLine++;
            }
            else
            {
                currentWriter.WriteLine();
                p_newLineFlag = true;
                p_CurrentRealLine++;
            }
		}
		private void incNLevel(){
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
        void AddWarning(string message)
        {
            Warning warning = new Warning(message);
            warning.set_ErrorSource(ErrorSource.OutputModule);
            warning.set_ErrorType(ErrorType.CodeGenerationError);
            warning.set_ErrorLevel(ErrorLevel.Five);
            p_errors.AddError(warning);
        }
        void AddError(string message)
        {
            Error error = new Error(message);
            error.set_ErrorSource(ErrorSource.OutputModule);
            error.set_ErrorType(ErrorType.CodeGenerationError);
            error.set_ErrorLevel(ErrorLevel.Five);
            p_errors.AddError(error);
        }
        void CheckErrorForNode(XplNode node)
        {
            // TODO : this only takes the current line, it does not have into account the columns or ends lines/columns
            if (p_nodesToErrors == null) return;
            if (p_nodesToErrors.ContainsKey(node))
            {
                try
                {
                    IError error = p_nodesToErrors[node];
                    Error relatedError = new Error(error.get_ErrorMessage(), error.get_ErrorClass());
                    relatedError.set_LocaleErrorMessage(error.get_LocaleErrorMessage());
                    relatedError.set_ErrorSourceFileData(error.get_ErrorSourceFileData());
                    relatedError.set_ErrorSource(error.get_ErrorSource());
                    relatedError.set_ErrorLevel(error.get_ErrorLevel());
                    relatedError.set_ErrorCode(error.get_ErrorCode());

                    int lineToUse = p_CurrentRealLine + 1;

                    // build file line string
                    string fileLineStr = lineToUse.ToString(NumberFormatInfo.InvariantInfo) + "," +
                        lineToUse.ToString(NumberFormatInfo.InvariantInfo) + "," +
                        (p_outputPath == null ? p_outputFileName : Path.Combine(p_outputPath, p_outputFileName));

                    relatedError.set_ErrorLayerDSourceFileData(fileLineStr);
                    error.set_RelatedError(relatedError);
                }
                catch
                {
                    Debug.WriteLine("Internal Error on CheckForNode function. DPPZOERenderModule.");
                }
            }
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
					if(context==EZOEContext.NamespaceBody)retStr="";
					else retStr=PrivatePC;
					break;
				case XplAccesstype_enum.PROTECTED:
					if(context==EZOEContext.NamespaceBody)retStr=ProtectedPC;
					else retStr=ProtectedPC;
					break;
				case XplAccesstype_enum.PUBLIC:
                    if (context != EZOEContext.Inherits)
                        retStr = PublicPC;
                    else
                        retStr = "";
                    break;
				case XplAccesstype_enum.IPRIVATE:
					if(context==EZOEContext.NamespaceBody)retStr=IPrivatePC;
                    else retStr = IPrivatePC;
					break;
				case XplAccesstype_enum.IPROTECTED:
					if(context==EZOEContext.NamespaceBody)retStr=IProtectedPC;
					else retStr=IProtectedPC;
					break;
				case XplAccesstype_enum.IPUBLIC:
					if(context==EZOEContext.NamespaceBody)retStr=IPublicPC;
					else retStr=IPublicPC;
					break;
				default:
					AddWarning("Modificador de accesso 'desconocido' inesperado en código EZOE. Usando 'private' en su lugar.");
					if(context==EZOEContext.NamespaceBody)retStr=PrivatePC;
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
		string processUserTypeName(string typeName)
        {
            // check for keyword replace
            typeName = typeName.Replace("::", ".");
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
                            typeName += "::" + p_keywordsToReplace[temp];
                        else
                            typeName += "::" + temp;
                    }
                }
            }
            else
            {
                if (p_keywordsToReplace.ContainsKey(typeName))
                    typeName = p_keywordsToReplace[typeName];
            }
            return typeName;
        }
        private string processSimleName(string simpleName)
        {
            // check for keyword replace
            if (p_keywordsToReplace.ContainsKey(simpleName))
                simpleName = p_keywordsToReplace[simpleName];
            return simpleName;
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
					retStr="ASCIIString";
                    break;
				case "$ASCIICHAR$":
					retStr="ASCIIChar";
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
					retStr="type";
                    break;
				case "$BLOCK$":
					retStr="block";
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
            CheckErrorForNode(type);
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
            ///PENDIENTE : hacer que funcione en modo depuracion,
            ///asi normalmente no relentiza la generación al vicio.
            return true;
		}
		string getArrayStr(XplType type, EZOETypeContext typeContext, EZOEContext context, bool isValueType){
            ///Aca tendria que procesar lo siguiente:
            ///Cuando tengo:
            ///     ^[][][]int <-- int [,,]
            ///     ^[][][]^[][]int <-- int[,,][,]
            ///     
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
            ///NET Permite punteros a cualquier tipo de valor,
            ///ya sea tipos nativos int, long, etc. o tipos enumeracion
            ///y tipos estructura.
            ///.
            ///Por tanto a no ser que el compilador pase los tipos
            ///"decorados", algo como "MiTipo#" indicando una clase o
            ///"MiTipo@" indicando una estructura, no tengo forma
            ///de saber si un tipo de valor, por tanto lo que voy hacer por
            ///ahora es tomar los punteros por referencia como referencias
            ///y todos los punteros que no sean por referencia como punteros y
            ///ya, se supone que el compilador ZOE me pasara todos los punteros
            ///convertidos a referencias siempre que pueda realizarlo.
            string retStr = String.Empty ,ptrStr = String.Empty;

            XplType currentType = type, derived=null;
            XplPointerinfo pi = null;
            while (currentType != null)
            {
                derived = currentType.get_dt();
                if (!currentType.get_ispointer() && !currentType.get_isarray()) break;
                if (currentType.get_ispointer())
                {
                    pi = currentType.get_pi();
                    if (pi!=null && derived != null && !derived.get_isarray())
                    {
                        if (pi.get_ref()) ptrStr = "^";
                        else ptrStr = "*";
                        if (pi.get_const()) ptrStr+= " " + ConstPC;
                        if (pi.get_volatile()) ptrStr+= " " + VolatilePC;
                        retStr = ptrStr + retStr;
                    }
                }
                //else if (currentType.get_isarray()) isRef = false;
                currentType = derived;
            }
			return retStr;
		}
		#endregion
		
		#region Funciones: requireParenthesis
		bool requireParenthesis(XplBinaryoperator bopExp){
			XplNode parent=bopExp.get_Parent();
			if(parent!=null)parent=parent.get_Parent();
			else return false;
			if(parent!=null)parent=parent.get_Parent();
			if(parent!=null && parent.get_TypeName()==CodeDOMTypes.XplExpression){
				///Si el parent no es nulo y es otra expresion
				int parentPrec=getExpressionPrecedence((XplExpression)parent);
				int expPrec=getOperatorPrecedence(bopExp.get_op());
				if(parentPrec>expPrec)
					return true;
			}
			return false;
		}
		bool requireParenthesis(XplUnaryoperator uopExp){
			XplNode parent=uopExp.get_Parent();
			if(parent!=null)parent=parent.get_Parent();
			else return false;
			if(parent!=null)parent=parent.get_Parent();
			if(parent!=null && parent.get_TypeName()==CodeDOMTypes.XplExpression){
				///Si el parent no es nulo y es otra expresion
				if(getExpressionPrecedence((XplExpression)parent)>getOperatorPrecedence(uopExp.get_op()))
					return true;
			}
			return false;
		}
		bool requireParenthesis(XplCastexpression exp){
			XplNode parent=exp.get_Parent().get_Parent();
			if(parent!=null && parent.get_TypeName()==CodeDOMTypes.XplExpression){
				///Si el parent no es nulo y es otra expresion
				if(getExpressionPrecedence((XplExpression)parent)>(int)Precedences.CastExp)return true;
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
			}
			return retVal;
		}
		#endregion
		
		#region Precedencia de operadores binarios y unarios
		int getOperatorPrecedence(XplBinaryoperators_enum op){
			int retVal=0;
			#region Switch Binary Operators
			switch(op){
				case XplBinaryoperators_enum.M: //Member access "."
				case XplBinaryoperators_enum.MP: //Member Pointer Access ".*"
				case XplBinaryoperators_enum.IMP: //Felcha "=>"
				case XplBinaryoperators_enum.PM: //Pointer Member Access "->"
				case XplBinaryoperators_enum.PMP: //Pointer To Member Pointer Access "->*"
				case XplBinaryoperators_enum.RM: //Reservado para Acceso a miembros
					///New Exp
					retVal=-1;break;
					///Unary operators y Cast retVal=2
				case XplBinaryoperators_enum.DIV: //Division
				case XplBinaryoperators_enum.EXP: //Exponente
				case XplBinaryoperators_enum.MOD: //Modulo (resto)
				case XplBinaryoperators_enum.MUL: //Multiplicacion
					retVal=-3;break;
				case XplBinaryoperators_enum.ADD: //Suma
				case XplBinaryoperators_enum.MIN: //Resta
					retVal=-4;break;
				case XplBinaryoperators_enum.LSH: //Left shift
				case XplBinaryoperators_enum.RSH: //Right shift
					retVal=-5;break;
				case XplBinaryoperators_enum.GR: //Mayor que
				case XplBinaryoperators_enum.GREQ: //Mayor o igual que
				case XplBinaryoperators_enum.LS: //Menor que
				case XplBinaryoperators_enum.LSEQ: //Menor o igual que
					retVal=-6;break;
				case XplBinaryoperators_enum.EQ: //Igualdad Logico
				case XplBinaryoperators_enum.NOTEQ: //No Igual logico
					retVal=-7;break;
				case XplBinaryoperators_enum.AND: //Y Logico
					retVal=-8;break;
				case XplBinaryoperators_enum.XOR: //Xor de Bits
					retVal=-9;break;
				case XplBinaryoperators_enum.BOR: //O de Bits
					retVal=-10;break;
				case XplBinaryoperators_enum.BAND: //Y de Bits
					retVal=-11;break;
				case XplBinaryoperators_enum.OR: //O Logico
					retVal=-12;break;
					///Condicional retVal=13
					///Asignacion retVal=14
			}
			#endregion
			return retVal;
		}
		int getOperatorPrecedence(XplUnaryoperators_enum op){
			int retVal=0;
			switch(op){
				case XplUnaryoperators_enum.DEC: //Decremento postfijo 'e--'
				case XplUnaryoperators_enum.INC: //Incremento postfijo 'e++'
				case XplUnaryoperators_enum.SIZEOF:
				case XplUnaryoperators_enum.TYPEOF:
					///New Exp
					retVal=-1;break;
				case XplUnaryoperators_enum.MIN: //Negativo '-'
				case XplUnaryoperators_enum.NOT: //Negado logico '!'
				case XplUnaryoperators_enum.ONECOMP: //Complemento a Uno '~'
				case XplUnaryoperators_enum.PREDEC: //Decremento prefijo '--e'
				case XplUnaryoperators_enum.PREINC: //Incremento prefijo '++e'
				case XplUnaryoperators_enum.AOF: //Address of '&'
				case XplUnaryoperators_enum.IND: //Indireccion de puntero '*'
				case XplUnaryoperators_enum.RAOF: //Reference AddressOf '&&'
					///Cast
					retVal=-2;break;
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
            if (fieldDecl.get_Parent() == null || fieldDecl.get_Parent().get_TypeName()!=CodeDOMTypes.XplClass) return false;
            XplClass classNode = (XplClass)fieldDecl.get_Parent();
            return classNode.get_isenum();
        }
        #endregion

        #endregion

		#region Sobreescritura de miembros abstractos

		#region DocumentData
		protected override void processDocumentData(XplDocumentData documentData){
			///Por ahora no hago nada para procesar la info de configuración
		}
		#endregion
		
		#region Inicio y Fin de Documento
		protected override void renderBeginDocumentBody(XplDocumentBody documentBody){
            if (!p_dontWriteCopyrightComment)
            {
                string str1 = "--------------------------------------------------------------------------";
                string pad = " ";
                writeLineComment(str1);
                writeLineComment("                                                                          ");
                writeLineComment(" Documento generado automáticamente a partir del archivo:                 ");
                string str2 = "       '" + p_inputFileName + "'";
                for (int n = 1; n < (str1.Length - str2.Length); n++) pad += " ";
                writeLineComment(str2 + pad);
                writeLineComment(" NO MODIFIQUE ÉSTE ARCHIVO MANUALMENTE.                                   ");
                writeLineComment("                                                                          ");
                str2 = " Fecha: " + DateTime.Now.ToString();
                pad = " ";
                for (int n = 1; n < (str1.Length - str2.Length); n++) pad += " ";
                writeLineComment(str2 + pad);
                writeLineComment("                                                                          ");
                writeLineComment(" Generado por: DotNET LayerD Generator - Modulo de Salida Zoe a Meta D++ ");
                writeLineComment("                                                                          ");
                if (!p_dontWriteCopyrightComment)
                {
                    writeLineComment(" 2006(R)Alexis Ferreyra.                                                  ");
                    writeLineComment("                                                                          ");
                    writeLineComment(" Por favor visite http://layerd.net para obtener las últimas versiones    ");
                    writeLineComment(" disponibles de las herramientas LayerD gratuitamente.                    ");
                    writeLineComment("                                                                          ");
                }
                writeLineComment("--------------------------------------------------------------------------");
                writeNewLine();
                writeLineDirective(documentBody.get_ldsrc(), false);
            }
		}
		protected override void renderEndDocumentBody(XplDocumentBody documentBody){
            if (!p_dontWriteCopyrightComment)
            {
                writeNewLine();
                writeLineComment("--- Final del archivo generado a partir de '" + p_inputFileName + "' ---");
            }
            else
                writeNewLine();
        }
		#endregion
		
		#region Declaraciones
		protected override void renderImportDirective(XplName importDirective){
            CheckErrorForNode(importDirective);
            ///PENDIENTE : si el compilador ZOE me manda todos los import,
            ///solo debo procesar los que correspondan a este modulo de salida.
            string usingString = null;
            bool flag = false;
            foreach (XplNode node in importDirective.Children())
            {
				tempStr=node.get_StringValue();
                if (tempStr.IndexOf('=') == -1)
                {
                    usingString = ImportPC + "\"" + tempStr + "\", ";
                    //break;
                }
                else
                {
                    flag = true;
                    usingString += "\"" + tempStr + "\", ";
                    string parameterName = tempStr.Substring(0, tempStr.IndexOf('=')).ToLower();
                    string parameterValue = tempStr.Substring(tempStr.IndexOf('=') + 1);
                    switch (parameterName)
                    {
                        case "ns":
                            if (p_namespaceToRemove == "") 
                                p_namespaceToRemove = parameterValue;
                            break;
                        case "assembly":
                            parameterValue += ".dll";
                            if (parameterValue.ToLower() != "mscorlib" && !p_assemblyList.Contains(parameterValue.ToLower()))
                                p_assemblyList.Add(parameterValue.ToLower());
                            break;
                        case "assemblyfilename":
                            if (parameterValue.ToLower() != "mscorlib" && !p_assemblyList.Contains(parameterValue.ToLower()))
                                p_assemblyList.Add(parameterValue.ToLower());
                            break;
                    }
                }
			}
            if (flag)
            {
                //writeLineDirective(importDirective.get_ldsrc(), false);
                writeOut(usingString.Substring(0, usingString.Length - 2) + ";");
                writeNewLine();
            }
		}
        protected override void renderUsingDirective(XplName xplName, EZOEContext eZOEContext)
        {
            CheckErrorForNode(xplName);
            string usingStr = xplName.Children().FirstNode().get_StringValue();
            writeOut(UsingPC + usingStr + ";");
            if(p_usings[usingStr.Length]==null)
                p_usings.Add(usingStr.Length, usingStr);
            writeNewLine();
        }
		protected override void renderBeginNamespace(string namespaceName, XplNamespace namespaceDecl, EZOEContext context){
            CheckErrorForNode(namespaceDecl);
            writeNewLine();
            writeLineDirective(namespaceDecl.get_ldsrc(), false);
            string namespaceStr = processUserTypeName(namespaceName);
            writeOut(NamespacePC + namespaceStr + "{");
            if (p_currentNamespace == "")
                p_currentNamespace = namespaceStr;
            else
                p_currentNamespace += "::" + namespaceStr;
            incNLevel();
			writeNewLine();
		}
		protected override void renderEndNamespace(string namespaceName, XplNamespace namespaceDecl, EZOEContext context){
            namespaceName = processUserTypeName(namespaceName);
            if (p_currentNamespace.Length > namespaceName.Length)
                p_currentNamespace = p_currentNamespace.Substring(0, p_currentNamespace.Length - namespaceName.Length - 2);
            else
                p_currentNamespace = "";
            
            
            writeLineDirective(namespaceDecl.get_ldsrc(), true);
            decNLevel();
			writeOut("}");
			if(p_writeDetailedComments)writeComment("Fin Espacio de Nombres '"+namespaceName+"'");
			writeNewLine();
		}
		//Tipos Definidos por el usuario
		protected override void renderBeginClass(EZOEClassType classType, string className, string implementsStr, string inheritsStr, 
			XplAccesstype_enum classAccess,	bool isNew, bool isAbstract, bool isFinal, XplClass classDecl, EZOEContext context){
            RenderComments(classDecl);

            CheckErrorForNode(classDecl);
            writeLineDirective(classDecl.get_ldsrc(), false);
            //Primero los modificadores
            if (classDecl.get_external()) writeOut(ExternPC);
            if (classDecl.get_extension()) writeOut(ExtensionPC);
            if (isNew) writeOut(NewPC);
            if (isAbstract) writeOut(AbstractPC);
            if (isFinal) writeOut(FinalPC);
            writeOut(getAccess(classAccess, context));
            if (classDecl.get_isinteractive())
                writeOut(InteractivePC);
            else if (classDecl.get_isfactory())
                writeOut(FactoryPC);
            p_currentAccess = XplAccesstype_enum.PRIVATE;

            className = processSimleName(className);
            //La declaracion del nombre
			switch(classType){
				case EZOEClassType.Class:
					writeOut(ClassPC+className);
					break;
				case EZOEClassType.Interface:
					writeOut(InterfacePC+className);
					break;
				case EZOEClassType.Struct:
					writeOut(StructPC+className);
					break;
				case EZOEClassType.Union:
					writeOut(StructPC+className);
					break;
                case EZOEClassType.Enum:
                    writeOut(EnumPC + className);
                    renderEnumType(classDecl);
                    break;
				default:
					throw new Exception("Valor interno inesperado renderizando clase.");
			}
            /// PENDIENTE : chequear la ignoracion de Object en el caso de programas que utilicen 
            /// otra base que no sea la estandar
            if (inheritsStr != "" && inheritsStr != "zoe::lang::Object") writeOut(" " + InheritsPC + inheritsStr);
            if (implementsStr != "") writeOut(" " + ImplementsPC + implementsStr);
			writeOut("{");
			incNLevel();
			writeNewLine();
		}

        protected void RenderComments(XplNode node)
        {
            if (node.get_doc() != null && node.get_doc() != "")
            {
                string[] comments = node.get_doc().Split('\n');
                foreach (string comment in comments)
                {
                    writeOut("//" + comment.Replace('\r',' '));
                    writeNewLine();
                }
            }
        }
		protected override void renderEndClass(EZOEClassType classType, string className, XplClass classDecl, EZOEContext context){
            writeLineDirective(classDecl.get_ldsrc(), true);
            decNLevel();
			writeOut("}");
			if(p_writeDetailedComments)writeComment("Final de Clase '"+className+"'");
			writeNewLine();
		}
		protected override string renderImplements(XplClass classDecl, XplNodeList implements, EZOEContext context){
            string temp = "";
			XplInherit imp=null;
			XplInherits imps=null;
			foreach(XplNode node in implements){
				imps=(XplInherits)node;
				foreach(XplNode node2 in imps.Children()){
                    CheckErrorForNode(node2);
					imp=(XplInherit)node2;
                    temp += removeUsings(processUserTypeName(imp.get_type().get_typename())) + ", ";
				}
			}
			if(temp!="")temp=temp.Substring(0,temp.Length-2);
			return temp;
		}
		protected override string renderInherits(XplClass classDecl, XplNodeList inherits, EZOEContext context){
			string temp="";
			XplInherit inh=null;
			XplInherits inhs=null;
			foreach(XplNode node in inherits){
				inhs=(XplInherits)node;
				foreach(XplNode node2 in inhs.Children()){
                    CheckErrorForNode(node2);
                    inh = (XplInherit)node2;
                    string tempStr = inh.get_type().get_typename();
                    if (tempStr != "zoe::lang::Object" &&
                        tempStr != "DotNET.LayerD.ZOECompiler.ClassfactoryBase" &&
                        tempStr != "DotNET.LayerD.ZOECompiler.ClassfactoryInteractiveBase")
                    {
                        temp += getAccess(inh.get_access(), EZOEContext.Inherits) + removeUsings(processUserTypeName(tempStr)) + ", ";
                        if (!inh.get_virtual())
                            AddWarning("Modificador virtual no aplicado en declaración de herencia, forzando herencia virtual.");
                    }
				}
			}
			if(temp!="")temp=temp.Substring(0,temp.Length-2);
			return temp;
		}
		//Miembros de Tipos Definidos por el Usuario
		protected override void renderBeginFunction(XplFunction functionDecl, string functionName, string returnTypeStr, string parametersStr, 
			XplAccesstype_enum access, XplVarstorage_enum functionStorage,	bool isAbstract, bool isFinal, bool isFp, bool isNew, bool isConst,  
			bool isOverride, bool isVirtual, EZOEContext context){

            CheckErrorForNode(functionDecl);

            if (functionDecl.get_donotrender()) return;

            bool isInterface = functionDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplClass && functionDecl.CurrentClass.get_isinterface();
            bool isExternalClass = functionDecl.get_Parent().IsA(CodeDOMTypes.XplClass) && functionDecl.CurrentClass.get_external();
                //Los miembros de las interfaces son siempre publicos no se debe hacer nada
            if (!isInterface)
                if (p_currentAccess != access)
                {
                    renderMembersAccess(access, context);
                }

            RenderComments(functionDecl);
            writeLineDirective(functionDecl.get_ldsrc(), false);
			
			string baseInitializers=renderBaseInitializers(functionDecl.get_BaseInitializers());

			writeOut(getStorage(functionStorage,context));

			if(isAbstract)writeOut(AbstractPC);
			if(isFinal)writeOut(FinalPC);
			if(isNew)writeOut(NewPC);
            if (isConst) writeOut(ConstPC);
			if(isOverride)writeOut(OverridePC);
			if(isVirtual)writeOut(VirtualPC);
			if(isFp){ //Declaro un delegate
				writeOut(FpPC);
			}
			if(functionName.IndexOf("%indexer%")>=0){
                functionName = functionName = IndexerPC;
				//functionName+=IndexerPC;
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
			writeOut(returnTypeStr+" ");
			writeOut(functionName);
			if(currentFunctionType==FunctionType.Indexer)
				writeOut("("+parametersStr+")");
			else
				writeOut("("+parametersStr+")");
			if(baseInitializers!="")writeOut(":"+baseInitializers);
			if(!isExternalClass && !isAbstract && functionStorage!=XplVarstorage_enum.EXTERN && functionStorage!=XplVarstorage_enum.STATIC_EXTERN
                && !isInterface){
				writeOut("{");
				incNLevel();
			}
			else{
                if (currentFunctionType == FunctionType.Indexer)
                {
                    writeOut("{");
                    incNLevel();
                }
                else
                    writeOut(";");
			}
			writeNewLine();
		}

        private void renderMembersAccess(XplAccesstype_enum access, EZOEContext context)
        {
            string accessStr = getAccess(access, context);
            p_currentAccess = access;
            decNLevel();
            writeOut(accessStr.Substring(0, accessStr.Length - 1) + ":");
            incNLevel();
            writeNewLine();
        }
		protected override void renderEndFunction(XplFunction functionDecl, string functionName, EZOEContext context){
            if (functionDecl.get_donotrender()) return;

			bool isAbstract=functionDecl.get_abstract();
            bool isExternalClass = functionDecl.get_Parent().IsA(CodeDOMTypes.XplClass) && functionDecl.CurrentClass.get_external();
            bool isInterface = functionDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplClass && functionDecl.CurrentClass.get_isinterface();

            XplVarstorage_enum functionStorage = functionDecl.get_storage();
            if (!isExternalClass && !isAbstract && 
                functionStorage != XplVarstorage_enum.EXTERN && 
                functionStorage != XplVarstorage_enum.STATIC_EXTERN && 
                !isInterface)
            {
                decNLevel();
                writeOut("}");
                if (p_writeDetailedComments) writeComment("Final función '" + functionName + "'.");
                writeNewLine();
            }
            else
            {
                if (currentFunctionType == FunctionType.Indexer)
                {
                    decNLevel();
                    writeOut("}");
                    writeNewLine();
                }
            }
		}
		protected override void renderBeginProperty(XplProperty propertyDecl, string propertyName, string typeStr,  
			XplAccesstype_enum access, XplVarstorage_enum propertyStorage,	bool isAbstract, bool isFinal, bool isNew, bool isConst,  
			bool isOverride, bool isVirtual, EZOEContext context){

            if (propertyDecl.get_donotrender()) return;

            //Los miembros de las interfaces son siempre publicos no se debe hacer nada
            if (!(propertyDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplClass && propertyDecl.CurrentClass.get_isinterface()))
                if (p_currentAccess != access)
                    renderMembersAccess(access, context);

            RenderComments(propertyDecl);
            writeLineDirective(propertyDecl.get_ldsrc(), false);
            writeOut(getStorage(propertyStorage, context));
            CheckErrorForNode(propertyDecl);

			if(isAbstract)writeOut(AbstractPC);
			if(isFinal)writeOut(FinalPC);
			if(isNew)writeOut(NewPC);
			if(isConst)AddWarning(ConstPC);
			if(isOverride)writeOut(OverridePC);
			if(isVirtual)writeOut(VirtualPC);
			writeOut(typeStr+" "+PropertyPC+processUserTypeName(propertyName)+" {");
			incNLevel();
			writeNewLine();
			currentFunctionType=FunctionType.Property;
		}
		protected override void renderEndProperty(XplProperty propertyDecl, string propertyName, EZOEContext context){
            if (propertyDecl.get_donotrender()) return;

            decNLevel();
			writeOut("}");
			if(p_writeDetailedComments)writeComment("Final de propiedad '"+propertyName+"'.");
			writeNewLine();
		}
		protected override void renderBeginGetAccess(EZOEContext context, XplFunctionBody body){
			writeOut("get ");
            CheckErrorForNode(body);
            if (body.get_lddata().Contains("%abstract%")) writeOut(";");
            else
            {
				writeOut("{");
				incNLevel();
				writeNewLine();
			}
		}
		protected override void renderEndGetAccess(EZOEContext context, XplFunctionBody body){
            if (body.get_lddata().Contains("%abstract%"))
            {
                //writeOut(";");
                writeNewLine();
            }
            else
            {
                decNLevel();
                writeOut("}");
                writeNewLine();
            }
		}
		protected override void renderBeginSetAccess(EZOEContext context, XplFunctionBody body){
			writeOut("set ");
            CheckErrorForNode(body);
            if (body.get_lddata().Contains("%abstract%")) writeOut(";");
            else
            {
                writeOut("{");
                incNLevel();
                writeNewLine();
            }
		}
		protected override void renderEndSetAccess(EZOEContext context, XplFunctionBody body){
            if (body.get_lddata().Contains("%abstract%"))
            {
                //writeOut(";");
                writeNewLine();
            }
            else
            {
                decNLevel();
                writeOut("}");
                writeNewLine();
            }
		}
		protected override void renderField(XplField fieldDecl, string fieldName, string typeStr, string initializerStr, 
			XplAccesstype_enum access, XplVarstorage_enum fieldStorage, bool isNew, bool isVolatile){

            if (fieldDecl.get_donotrender()) return;

            if (!FieldIsFromEnum(fieldDecl))
            {
                if (p_currentAccess != access)
                    renderMembersAccess(access, EZOEContext.ClassDecl);
                RenderComments(fieldDecl);
                writeLineDirective(fieldDecl.get_ldsrc(), false);

                writeOut(getStorage(fieldStorage, EZOEContext.ClassBody));
                CheckErrorForNode(fieldDecl);

                if (isNew) writeOut(NewPC);
                if (isVolatile) writeOut(VolatilePC);
                if (fieldDecl.get_type().get_const()) writeOut(ConstPC);
                writeOut(typeStr);
                if (initializerStr != "")
                    if (initializerStr[0] != '(') writeOut(" = " + initializerStr);
                    else writeOut(initializerStr);
                writeOut(";");
                if (p_writeDetailedComments) writeComment("campo '" + fieldName + "'");
            }
            else
            { //Es un campo de una enumeración
                RenderComments(fieldDecl);
                writeLineDirective(fieldDecl.get_ldsrc(), false);
                writeOut(fieldDecl.get_name());
                if (initializerStr != "")
                    if (initializerStr[0] != '(') writeOut("=" + initializerStr);
                    else writeOut(initializerStr);
                writeOut(",");
            }
			writeNewLine();
		}
		protected override void renderBeginParameters(XplParameters parametersDecl,int maxParameter, XplFunction functionDecl, EZOEContext context){
			p_maxParameter=maxParameter;
		}
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
            CheckErrorForNode(parameter);
            return retStr;
		}
		protected override void renderEndParameters(XplParameters parametersDecl, EZOEContext context){
			p_maxParameter=0;
		}
		protected override string renderType(XplType type, string declareName, EZOETypeContext typeContext, EZOEContext context){
			string typeStr="",arrayStr="",pointerStr="";
            bool isValueType = false;
            if (type.get_exec()) typeStr += ExecPC;
            if (type.get_ftype() == XplFactorytype_enum.EXPRESSION) typeStr += ExpPC;
            else if (type.get_ftype() == XplFactorytype_enum.INAME) typeStr += INamePC;
            typeStr += getTypeName(type, typeContext, ref isValueType);
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
                    typeStr += " " + processSimleName(declareName);
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
        protected override string renderBeginInitializerList(XplInitializerList initializerList, EZOEContext context)
        {
            CheckErrorForNode(initializerList);
            return "(";
        }
        protected override string renderEndInitializerList(XplInitializerList initializerList, EZOEContext context)
        {
            return ")";
        }
        protected override string renderSimpleInitializer(XplExpression expression, string expressionStr, EZOEContext context)
        {
            return expressionStr;
        }
        protected override string renderInitilizerItem(XplNode node, string nodeStr, int maxNodes, int count, EZOEContext context)
        {
            if (count == maxNodes) return nodeStr;
            else return nodeStr + ",";
        }
        protected override string renderEndArrayInitializer(XplInitializerList initializerList, EZOEContext context)
        {
            CheckErrorForNode(initializerList);
            return "}";
        }
        protected override string renderBeginArrayInitializer(XplInitializerList initializerList, EZOEContext context)
        {
            return "{";
        }
        #endregion

		#region Instrucciones
		protected override void renderBeginBlock( XplFunctionBody functionBody, EZOEContext context ){
            CheckErrorForNode(functionBody);

            writeLineDirective(functionBody.get_ldsrc(), false);
            if (context == EZOEContext.FunctionBody)
            {
				writeOut("{");
				incNLevel();
				writeNewLine();
			}
		}
		protected override void renderEndBlock( XplFunctionBody functionBody, EZOEContext context ){
			if(context==EZOEContext.FunctionBody){
				decNLevel();
				writeOut("}");
				writeNewLine();
			}
		}
		protected override void renderLabel( XplNode label, EZOEContext context ){
            CheckErrorForNode(label);

            writeOut(label.get_StringValue()+":");
			writeNewLine();
		}
		protected override void renderSetonerror( XplSetonerror setOnerror , EZOEContext context ){
            CheckErrorForNode(setOnerror);
            AddError("Instrucción 'setonerror' no soportada por el modulo de salida.");
		}
		protected override void renderExpressionStatement(XplExpression expression, string expressionString,EZOEContext context){
            CheckErrorForNode(expression);
            if (expressionString != String.Empty)
            {
                RenderComments(expression);
                writeLineDirective(expression.get_ldsrc(), false);
                if (context==EZOEContext.ClassBody && expression.get_Content().get_TypeName() == CodeDOMTypes.XplFunctioncall)
                {
                    var functionNode = (XplFunctioncall)expression.get_Content();
                    XplExpressionlist args = functionNode.get_args();
                    if ( (args == null || args.Children().GetLength() == 0) && functionNode.get_bk() == null)
                        writeOut("::");
                }
                writeOut(expressionString + ";");
                writeNewLine();
            }
		}
		protected override void renderThrow(XplExpression throwExpression, string expressionString,EZOEContext context){
            CheckErrorForNode(throwExpression);

            writeLineDirective(throwExpression.get_ldsrc(), false);
            writeOut(ThrowPC + expressionString + ";");
			writeNewLine();
		}
		protected override void renderReturn(XplExpression returnExpression, string expressionString,EZOEContext context){
            CheckErrorForNode(returnExpression);

            writeLineDirective(returnExpression.get_ldsrc(), false);
            writeOut(ReturnPC + expressionString + ";");
			writeNewLine();
		}
		protected override void renderLocalDeclarator(XplDeclarator decl, string varName, string typeStr, string initializerStr, bool isVolatile){
            CheckErrorForNode(decl);

            RenderComments(decl);
            writeLineDirective(decl.get_ldsrc(), false);
            if (isVolatile) writeOut(VolatilePC);
            if (decl.get_type().get_const()) writeOut(ConstPC);
			writeOut(typeStr);
			if(initializerStr!="")
                if(decl.get_i().Children().FirstNode().get_ElementName()!="list")writeOut(" = "+initializerStr);
                else writeOut(initializerStr);
			writeOut(";");
			writeNewLine();
            decl.get_type().get_const();
		}
        bool p_isOnCase = false;
		protected override void renderBeginSwitch(XplSwitchStatement switchSta, string boolExpStr, EZOEContext context){
            CheckErrorForNode(switchSta);

            writeLineDirective(switchSta.get_ldsrc(), false);
            writeOut(SwitchPC + "(" + boolExpStr + "){");
			incNLevel();
			writeNewLine();
			tempStr=boolExpStr;
		}
		protected override void renderCaseLabel(XplCase caseNode, string caseExpStr, EZOEContext context){
            CheckErrorForNode(caseNode);

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
		protected override void renderEndSwitch(XplSwitchStatement switchSta, EZOEContext context){
            CheckErrorForNode(switchSta);

            if (p_isOnCase) decNLevel();
            p_isOnCase = false;
            decNLevel();
			writeNewLine();
			writeOut("} ");
            writeNewLine();
            if (p_writeDetailedComments) writeComment("Fin Switch '" + tempStr + "'");
		}
		protected override void renderIfStatement(XplIfStatement ifSta, string boolExp, bool isElse, EZOEContext context){
            CheckErrorForNode(ifSta);

            writeLineDirective(ifSta.get_ldsrc(), false);
            if (!isElse)
            {
				writeOut(IfPC+"("+boolExp+")");
			}
			else{
				writeOut(ElsePC+IfPC+"("+boolExp+")");
			}
		}
		protected override void renderElseStatement(XplIfStatement ifSta, XplFunctionBody elseBody, EZOEContext context){
            CheckErrorForNode(elseBody);

            if (elseBody != null) writeOut(ElsePC);
        }
		protected override void renderForStatement(XplForStatement forSta, string initStr, string boolExpStr, string updateStr, EZOEContext context){
            CheckErrorForNode(forSta);

            writeLineDirective(forSta.get_ldsrc(), false);
            if(updateStr == "_FOR_EACH_")
                writeOut(ForPC + "(" + initStr + " in " + boolExpStr + ")");
            else
                writeOut(ForPC + "(" + initStr + ";" + boolExpStr + ";" + updateStr + ")");
        }
		protected override string renderForDeclaration(XplDeclaratorlist decls, EZOEContext context){
            XplNodeList listaDeclaraciones = decls.Children();
            ///Usamos "varName" para nombre de variable
            ///"initStr" para el inicializador (ej: int n "=0")
            ///"typeStr" para el tipo (ej: "int[]" a = new int[] {3,4,5,5})
            string varName = "", initStr = "", typeStr = "", backTypeStr = ""; ;
            string retStr = "";
            ///for(int a = 0, d, f;; ....
            for (int n = 0; n < listaDeclaraciones.GetLength(); n++)
            {
                XplDeclarator nodo = (XplDeclarator)listaDeclaraciones.GetNodeAt(n);
                CheckErrorForNode(nodo);

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
                    ///Controlo que el tipo del declarador sea igual al tipo del primer declarador
                    if (typeStr != backTypeStr) ///Error
                        AddError("ERROR: tipo inesperado en declaración de variables de bloque for.");
                }
                ///Agrego el nombre de la variable
                retStr += " " + varName;
                ///Agrego el inicializador
                if (initStr != "")
                    if (nodo.get_i().Children().FirstNode().get_ElementName() != "list") retStr += "=" + initStr;
                    else retStr += initStr;
                ///Agrego la coma
                if (n != listaDeclaraciones.GetLength() - 1) retStr += ",";
            }
            return retStr;
        }
		protected override void renderWhileStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context){
            CheckErrorForNode(doSta);

            writeLineDirective(doSta.get_ldsrc(), false);
            writeOut(WhilePC + "(" + boolExpStr + ")");
		}
		protected override void renderBeginDoStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context){
            CheckErrorForNode(doSta);

            writeLineDirective(doSta.get_ldsrc(), false);
            writeOut(DoPC);
		}
		protected override void renderEndDoStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context){
            writeLineDirective(doSta.get_ldsrc(), true);
            writeOut(WhilePC + "(" + boolExpStr + ");");
            writeNewLine();
        }
		protected override void renderBeginTry(XplTryStatement trySta, EZOEContext context){
            CheckErrorForNode(trySta);

            writeLineDirective(trySta.get_ldsrc(), false);
            writeOut(TryPC);
		}
		protected override void renderEndTry(XplTryStatement trySta, EZOEContext context){
			writeNewLine();
		}
		protected override void renderCatchStatement(XplCatchStatement catchSta, string declExp, EZOEContext context){
            CheckErrorForNode(catchSta);

            writeLineDirective(catchSta.get_ldsrc(), false);
            writeOut(CatchPC + "(" + declExp + ")");
		}
		protected override void renderFinally(XplFunctionBody tryBk, EZOEContext context){
            writeLineDirective(tryBk.get_ldsrc(), false);
            writeOut(FinallyPC);
		}
		protected override void renderBreak(XplJump jump, EZOEContext context){
            CheckErrorForNode(jump);

            writeLineDirective(jump.get_ldsrc(), false);
            writeOut(BreakPC + ";");
			writeNewLine();
		}
		protected override void renderContinue(XplJump jump, EZOEContext context){
            CheckErrorForNode(jump);

            writeLineDirective(jump.get_ldsrc(), false);
            writeOut(ContinuePC + ";");
			writeNewLine();
		}
		protected override void renderGoto(XplJump jump, string label, EZOEContext context){
            CheckErrorForNode(jump);

            writeLineDirective(jump.get_ldsrc(), false);
            writeOut(GotoPC + label + ";");
			writeNewLine();
		}
		protected override void renderResume(XplJump jump, EZOEContext context){
            CheckErrorForNode(jump);

			AddError("Instrucción 'resume' no soportada por el Modulo de Salida.");
		}
		protected override void renderResumeNext(XplJump jump, EZOEContext context){
            CheckErrorForNode(jump);
            AddError("Instrucción 'resume next' no soportada por el Modulo de Salida.");
		}
		protected override void renderDirectOutput(XplDirectoutput directOutput, string outputStr, EZOEContext context){
            CheckErrorForNode(directOutput);
            AddWarning("renderDirectOutput: no implementado en Modulo de Salida.");
		}
		protected override void renderOnpointerStatement(XplFunctionBody functionBody, EZOEContext context){
            CheckErrorForNode(functionBody);
            AddError("Instrucción 'onpointer' no soportada por el Modulo de Salida.");
		}
		#endregion

		#region Expresiones
        protected override string renderGetTypeExp(XplType xplType, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            CheckErrorForNode(xplType);
            return "gettype(" + typeStr + ")";
        }
        protected override string renderNewExp(XplNewExpression newExp, string typeStr, string initializerStr, EZOEContext context)
        {
            CheckErrorForNode(newExp);
            if (initializerStr != "" && initializerStr[0] != '(' && initializerStr[0] != '{')
            {
                AddWarning("No se permiten inicializadores de expresiones simples en expresiones 'new', sólo son validos inicializadores de matrices y objetos.");
                initializerStr = "";
            }
            //if (initializerStr == "" && newExp.get_type().get_typename() != "" && newExp.get_type().get_typename()[0] != '$')
            if (initializerStr == "" && newExp.get_type().get_typename() != "")
            {
                return "new " + typeStr + "()";
            }
            else if (initializerStr != "" && initializerStr[0] == '{')
            {
                return "new " + typeStr + " = " + initializerStr;
            }
            else
            {
                return "new " + typeStr + initializerStr;
            }
        }
        protected override string renderBeginExpressionList(XplExpressionlist list, int expCount, EZOEContext context)
        {
            CheckErrorForNode(list);
            return "";
		}
		protected override string renderExpressionListItem(XplExpression expNode, string expStr, int expNumber, int expCount, EZOEContext context){
            CheckErrorForNode(expNode);
            if (expNumber != expCount) return expStr + ", ";
			else return expStr;
		}
		protected override string renderEndExpressionList(XplExpressionlist list, EZOEContext context){
			return "";
		}
		protected override string renderSimpleName(XplNode node, string name, EZOEContext context){
            CheckErrorForNode(node);

            if (String.IsNullOrEmpty(name))
                return "+error_empty_node+";

			///Simplemente asumo que todo es correcto y debo reemplazar "::" por "."
            if (name.IndexOf(':') > -1 || name.IndexOf('.') > -1)
                return removeUsings(processUserTypeName(name));
            else
                return processUserTypeName(name);
		}
        private string removeUsings(string name)
        {
            for(int n=p_usings.Count-1;n>-1;n--)
            {
                string usingStr = (string)p_usings.GetByIndex(n);
                if (name.StartsWith(usingStr) && name!=usingStr) 
                    return name.Remove(0, usingStr.Length+2);
            }
            if (p_currentNamespace != String.Empty && name.StartsWith(p_currentNamespace))
                return name.Remove(0, p_currentNamespace.Length+2);
            return name;
        }
		protected override string renderLiteral(XplLiteral litNode, string litStr, EZOEContext context){
			#region Switch de Tipos de Literal
			switch(litNode.get_type()){
                case XplLiteraltype_enum.NULL:
                    tempStr = "null";
                    break;
				case XplLiteraltype_enum.ASCIICHAR:
				case XplLiteraltype_enum.CHAR:
					tempStr="'"+litStr+"'";
					break;
				case XplLiteraltype_enum.BOOL:
				case XplLiteraltype_enum.HEX:
				case XplLiteraltype_enum.INTEGER:
				case XplLiteraltype_enum.OCT:
				case XplLiteraltype_enum.REAL:
                case XplLiteraltype_enum.FLOAT:
                case XplLiteraltype_enum.DOUBLE:
                case XplLiteraltype_enum.DECIMAL:
					tempStr=litStr;
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
            CheckErrorForNode(litNode);
            return tempStr;
		}
		protected override string renderDeleteExp(XplExpression deleteExp, string expStr, EZOEContext context){
            CheckErrorForNode(deleteExp);
            return DeletePC + expStr;
		}
		protected override string renderOnpointerExp(XplExpression onpointerExp, string expStr, EZOEContext context){
            CheckErrorForNode(onpointerExp);
            AddError("Expresión 'onpointer' no soportada por el Modulo de Salida.");
			return "/*Expresion Onpointer No Soportada*/";
		}
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
            CheckErrorForNode(assing);
            return tempStr;
		}
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
			///Bandera para evitar usar parentesis en accesos a miembros
			bool flag=false;
			#region Switch de Operadores Binarios
			switch(op){
				case XplBinaryoperators_enum.ADD: //Suma
					tempStr=leftExpStr+" + "+rightExpStr;
					break;
				case XplBinaryoperators_enum.AND: //Y Logico
					tempStr=leftExpStr+" && "+rightExpStr;
					break;
				case XplBinaryoperators_enum.BAND: //Y de Bits
					tempStr=leftExpStr+" & "+rightExpStr;
					break;
				case XplBinaryoperators_enum.BOR: //O de Bits
					tempStr=leftExpStr+" | "+rightExpStr;
					break;
				case XplBinaryoperators_enum.DIV: //Division
					tempStr=leftExpStr+" / "+rightExpStr;
					break;
				case XplBinaryoperators_enum.EQ: //Igualdad Logico
					tempStr=leftExpStr+" == "+rightExpStr;
					break;
				case XplBinaryoperators_enum.EXP: //Exponente
					AddWarning("Operador binario 'EXP' (exponente) no soportado por el Modulo de Salida. Usando '*' en su lugar.");
					tempStr=leftExpStr+" * "+rightExpStr;
					break;
				case XplBinaryoperators_enum.GR: //Mayor que
					tempStr=leftExpStr+" > "+rightExpStr;
					break;
				case XplBinaryoperators_enum.GREQ: //Mayor o igual que
					tempStr=leftExpStr+" >= "+rightExpStr;
					break;
				case XplBinaryoperators_enum.IMP: //Felcha "=>"
					//AddError("Operador binario 'IMP' ('=>') no soportado por el Modulo de Salida. Usando '.' en su lugar.");
					tempStr=leftExpStr+" => "+rightExpStr;
					break;
				case XplBinaryoperators_enum.LS: //Menor que
					tempStr=leftExpStr+" < "+rightExpStr;
					break;
				case XplBinaryoperators_enum.LSEQ: //Menor o igual que
					tempStr=leftExpStr+" <= "+rightExpStr;
					break;
				case XplBinaryoperators_enum.LSH: //Left shift
					tempStr=leftExpStr+" << "+rightExpStr;
					break;
				case XplBinaryoperators_enum.M: //Member access "."
					tempStr=leftExpStr+"."+rightExpStr;flag=true;
					break;
				case XplBinaryoperators_enum.MIN: //Resta
					tempStr=leftExpStr+" - "+rightExpStr;
					break;
				case XplBinaryoperators_enum.MOD: //Modulo (resto)
					tempStr=leftExpStr+" % "+rightExpStr;
					break;
                case XplBinaryoperators_enum.MP: //Member Pointer Access ".*"
					tempStr=leftExpStr+".*"+rightExpStr;flag=true;
					break;
				case XplBinaryoperators_enum.MUL: //Multiplicacion
					tempStr=leftExpStr+" * "+rightExpStr;
					break;
				case XplBinaryoperators_enum.NOTEQ: //No Igual logico
					tempStr=leftExpStr+" != "+rightExpStr;
					break;
				case XplBinaryoperators_enum.OR: //O Logico
					tempStr=leftExpStr+" || "+rightExpStr;
					break;
                case XplBinaryoperators_enum.PM: //Pointer Member Access "->"
					tempStr=leftExpStr+"->"+rightExpStr;flag=true;
					break;
                case XplBinaryoperators_enum.PMP: //Pointer To Member Pointer Access "->*"
					tempStr=leftExpStr+"->*"+rightExpStr;flag=true;
					break;
                case XplBinaryoperators_enum.RM: //Reservado para Acceso a miembros
					AddWarning("Operador binario 'RM' (reservado para acceso a miembros) no soportado por el Modulo de Salida. Usando '.' en su lugar.");
					tempStr=leftExpStr+"."+rightExpStr;flag=true;
					break;
				case XplBinaryoperators_enum.RSH: //Right shift
					tempStr=leftExpStr+" >> "+rightExpStr;
					break;
				case XplBinaryoperators_enum.XOR: //Xor de Bits
					tempStr=leftExpStr+" ^ "+rightExpStr;
					break;
                case XplBinaryoperators_enum.COMMA:
                    tempStr = leftExpStr + "+" + rightExpStr;
                    AddError("Comma operator not supported in Meta D++.");
                    break;
                default:
                    tempStr = leftExpStr + "+" + rightExpStr;
                    AddError("Unrecognized binary operator in expression.");
                    break;
            }
			#endregion
			if(p_OptimiseParenthesis){
				if(!flag && requireParenthesis(bopExp))tempStr="("+tempStr+")";
			}
			else
				if(!flag)tempStr="("+tempStr+")";

            CheckErrorForNode(bopExp);
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
            CheckErrorForNode(bopExp);
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

		protected override string renderUnOpExp(XplUnaryoperator uopExp, string expStr, XplUnaryoperators_enum op, EZOEContext context){
            CheckErrorForNode(uopExp);
            #region Switch de Operadores Unarios
			switch(op){
				case XplUnaryoperators_enum.AOF: //Address of '&'
					if(!p_isUnsafeContext)AddWarning("Operador 'Address of' usado en posible contexto no seguro, posible error.");
                    ///AQUI no debo usar el operador cuando es aplicado para obtenera la direccion de una funcion
                    XplExpression parentExp = (XplExpression)uopExp.get_Parent();
                    if (!parentExp.get_typeStr().Contains("/")) tempStr = "&" + expStr;
                    else tempStr = expStr;
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
		protected override string renderFunctionCallExp(XplFunctioncall fcallExp, string leftExpStr, string argsStr, bool useBrackets, EZOEContext context){
            CheckErrorForNode(fcallExp);
            XplFunctionBody bloque = fcallExp.get_bk();
            string blockArgStr = "";
            bool onWritecode = p_onWritecode;
            XplFunctionBody bk = fcallExp.get_bk();
            if (bk != null)
            {
                string backWCS = p_currentWritecodeStr;
                bool backIsNewLine = p_newLineFlag;
                p_currentWritecodeStr = "{";
                p_onWritecode = true;
                writeNewLine();
                incNLevel();
                processFunctionBody(bk, context);
                decNLevel();
                writeOut("}");
                p_onWritecode = onWritecode;
                blockArgStr = p_currentWritecodeStr;
                p_newLineFlag = backIsNewLine;
                p_currentWritecodeStr = backWCS;
            }
            if (!useBrackets)
            {
                if(fcallExp.get_args()==null)
                    return leftExpStr + blockArgStr;
                else
                    return leftExpStr + "(" + argsStr + ")" + blockArgStr;
            }
            else
            {
                return leftExpStr + "[" + argsStr + "]" + blockArgStr;
            }
		}
		protected override string renderCastExp(XplCastexpression castExp, string typeStr, string castExpStr, XplCasttype_enum castType, EZOEContext context){
            CheckErrorForNode(castExp);

            tempStr = "(" + typeStr + ")" + castExpStr;
			if(p_OptimiseParenthesis){
				if(requireParenthesis(castExp))tempStr="("+tempStr+")";
			}
			else tempStr="("+tempStr+")";
            //tempStr = "(" + tempStr + ")"; //Cuidado con esto al corregir lo superior
			return tempStr;
		}		
		#endregion

		#region Documentacion, UnrecognizedNode y Otros
		protected override void renderDocumentation(XplDocumentation documentation, EZOEContext context){
            string[] comments=documentation.get_short().Split('\n');
            for (int n = 0; n < comments.Length; n++)
            {
                string comment = comments[n].Replace('\r', ' ').Trim();
                if (comment != String.Empty)
                {
                    writeOut("// " + comment);
                    writeNewLine();
                }
            }
        }
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
		public bool OptimiseParenthesis{
			get{return p_OptimiseParenthesis;}
			set{p_OptimiseParenthesis=value;}
		}
		public bool checkTypes{
			get{return p_checkTypes;}
			set{p_checkTypes=value;}
		}
		public bool dontWriteCopyrightComment{
			get{return p_dontWriteCopyrightComment;}
			set{p_dontWriteCopyrightComment=value;}
		}
		public bool writeDetailedComments{
			get{return p_writeDetailedComments;}
			set{p_writeDetailedComments=value;}
		}
		public string OutputFileName{
			get{return p_outputFileName;}
			set{p_outputFileName=value;p_newFilePerClass=false;}
		}
		public bool NewFilePerClass{
			get{return p_newFilePerClass;}
			set{p_newFilePerClass=value;}
		}
		public bool ApplyFormat{
			get{return p_applyFormat;}
			set{p_applyFormat=value;}
		}
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
            if (zoeErrors != null)
            {
                p_nodesToErrors = new Dictionary<XplNode, IError>();
                foreach (IError error in zoeErrors)
                {
                    if (error.get_ErrorNode() != null)
                    {
                        if (!p_nodesToErrors.ContainsKey(error.get_ErrorNode()))
                        {
                            p_nodesToErrors.Add(error.get_ErrorNode(), error);
                        }
                    }
                }
            }
            else
            {
                p_nodesToErrors = null;
            }
            return true;
        }

        public void SetEZOEInputFileName(string EZOEInputFileName)
        {
            p_inputFileName = EZOEInputFileName;
        }
        public void SetEZOEInputDocument(XplDocument EZOEInputDocument)
        {
            p_XplDocument = EZOEInputDocument;
        }
        public bool StartParseDocument(bool renderOnly, string buildArguments, string renderArguments)
        {
            bool parseResult = false;
            ///Primero renderizo la representación intermedia en C#
            try
            {
                if (renderArguments != null)
                {
                    ///Proceso los argumentos de renderizacion
                    ///Por ahora solo considero la grabación del código recibido
                    if (renderArguments.ToLower() == "save_ezoe" && p_XplDocument!=null)
                    {
                        XplWriter writer = null;
                        try
                        {
                            writer = new XplWriter(Path.Combine(p_outputPath, Path.GetFileNameWithoutExtension(p_outputFileName) + "_dotnet.ezoe"));
                            p_XplDocument.Write(writer);
                        }
                        finally
                        {
                            if (writer != null) writer.Close();
                        }
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
            ///Construyo la salida
            if (!renderOnly && parseResult)
            {
                return BuildModule(buildArguments);
            }
            return parseResult;
        }

        #region Construccion de Modulos
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
            cp.OutputAssembly = Path.Combine(p_outputPath != null ? p_outputPath : "", Path.GetFileName(p_outputFileName));
            // Generate debug information.
            cp.IncludeDebugInformation = true;
            // Add an assembly reference.
            cp.ReferencedAssemblies.Add("System.dll");
            foreach (string assemblyName in p_assemblyList)
                cp.ReferencedAssemblies.Add(assemblyName);
            // Save the assembly as a physical file.
            cp.GenerateInMemory = false;
            // Set the level at which the compiler 
            // should start displaying warnings.
            cp.WarningLevel = 3;
            // Set whether to treat all warnings as errors.
            cp.TreatWarningsAsErrors = false;
            // Set compiler argument to optimize output.
            cp.CompilerOptions = buildArguments;
            CodeDomProvider provider = Microsoft.CSharp.CSharpCodeProvider.CreateProvider("CSharp");
            if (provider == null) return false;

            CompilerResults cr = provider.CompileAssemblyFromFile(cp, p_intermediateFile);

            if (cr.Errors.Count > 0)
            {
                // Display compilation errors.
                //Console.WriteLine("Errors building {0} into {1}",
                    //sourceFile, cr.PathToAssembly);
                foreach (CompilerError ce in cr.Errors)
                {
                    string errStr = ce.FileName + "(" + ce.Line + "):" + ce.ErrorNumber + " - " + ce.ErrorText;
                    if (ce.IsWarning)
                        AddWarning(errStr);
                    else
                        AddError(errStr);
                }
            }
            // Return the results of compilation.
            if (cr.Errors.Count > 0)
                return false;
            else
                return true;            
        }
        #endregion

        public void SetOutputPath(string outputPath)
        {
            p_outputPath = outputPath;
        }
        public void SetOutputFileName(string EZOEOutputFileName)
        {
            p_outputFileName = EZOEOutputFileName;
        }
        public void SetOutputType(XplLayerDZoeProgramModuletype_enum moduleType)
        {
            p_outputModuleType = moduleType;
        }

        #endregion

        public string RenderExpression(XplExpression xplExpression)
        {
            CheckErrorForNode(xplExpression);
            return processExpression(xplExpression, EZOEContext.FunctionBody);
        }

        protected override string renderWritecodeExpression(XplExpression xplExpression, string expStr, ExtendedZOEProcessor.EZOEContext context)
        {
            CheckErrorForNode(xplExpression);
            return WritecodePC + "( " + expStr + " )";
        }

        protected override string renderWritecodeBlock(XplWriteCodeBody xplWriteCodeBody, ExtendedZOEProcessor.EZOEContext context)
        {
            CheckErrorForNode(xplWriteCodeBody);
            string retStr = null;
            bool onWritecode = p_onWritecode;
            string backWCS = p_currentWritecodeStr;
            bool backIsNewLine = p_newLineFlag;

            switch (xplWriteCodeBody.get_Content().get_ElementName())
            {
                case "bk":
                    p_currentWritecodeStr = WritecodePC + "{";
                    p_onWritecode = true;
                    writeNewLine();
                    incNLevel();
                    processFunctionBody((XplFunctionBody)xplWriteCodeBody.get_Content(), context);
                    break;
                case "progunit":
                    p_currentWritecodeStr = WritecodePC + "{";
                    p_onWritecode = true;
                    writeNewLine();
                    incNLevel();
                    processDocumentBody((XplDocumentBody)xplWriteCodeBody.get_Content());
                    break;
                case "namespace":
                    p_currentWritecodeStr = WritecodePC + "{";
                    p_onWritecode = true;
                    writeNewLine();
                    incNLevel();
                    processNamespace((XplNamespace)xplWriteCodeBody.get_Content());
                    break;
                case "class":
                    p_currentWritecodeStr = WritecodePC + "{";
                    p_onWritecode = true;
                    writeNewLine();
                    incNLevel();
                    processClass((XplClass)xplWriteCodeBody.get_Content(),context);
                    break;
                case "classmembers":
                    p_currentWritecodeStr = WritecodePC + "{%";
                    p_onWritecode = true;
                    writeNewLine();
                    incNLevel();
                    processClassMembers(((XplClassMembersList)xplWriteCodeBody.get_Content()).Children(),context);
                    break;
                case "e":
                    break;
            }
            decNLevel();
            if(xplWriteCodeBody.get_Content().get_ElementName()=="classmembers")
                writeOut("%}");
            else
                writeOut("}");
            p_onWritecode = onWritecode;
            retStr = p_currentWritecodeStr;
            p_newLineFlag = backIsNewLine;
            p_currentWritecodeStr = backWCS;

            return retStr;
        }

        protected override string renderTypeOfExp(XplType typeofExpNode, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            CheckErrorForNode(typeofExpNode);
            return "typeof( " + typeStr + " )";
        }

        protected override string renderIsExp(XplCastexpression xplExpression, string expStr, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            CheckErrorForNode(xplExpression);
            return expStr + " is " + typeStr;
        }

        protected override string renderSizeofExp(XplType xplType, string typeStr, EZOEContext eZOEContext)
        {
            CheckErrorForNode(xplType);
            return "sizeof( " + typeStr + " )";
        }

        public virtual string ConvertToString(XplNode node)
        {
            string retStr = null;
            bool onWritecode = p_onWritecode;
            string backWCS = p_currentWritecodeStr;
            bool backIsNewLine = p_newLineFlag;

            p_currentWritecodeStr = String.Empty;
            p_onWritecode = true;

            switch (node.get_TypeName())
            {
                case CodeDOMTypes.XplDocumentBody:
                    processDocumentBody((XplDocumentBody)node);
                    break;
                case CodeDOMTypes.XplNamespace:
                    processNamespace((XplNamespace)node);
                    break;
                case CodeDOMTypes.XplClass:
                    processClass((XplClass)node, EZOEContext.NamespaceBody);
                    break;
                case CodeDOMTypes.XplClassMembersList:
                    processClassMembers(((XplClassMembersList)node).Children(), EZOEContext.ClassBody);
                    break;
                case CodeDOMTypes.XplFunction:
                    processFunction((XplFunction)node,((XplFunction)node).get_access(), EZOEContext.ClassBody);
                    break;
                case CodeDOMTypes.XplField:
                    processField((XplField)node, ((XplField)node).get_access(), EZOEContext.ClassBody);
                    break;
                case CodeDOMTypes.XplProperty:
                    processProperty((XplProperty)node, ((XplProperty)node).get_access(), EZOEContext.ClassBody);
                    break;
                case CodeDOMTypes.XplFunctionBody:
                    processFunctionBody((XplFunctionBody)node, EZOEContext.FunctionBody);
                    break;
                case CodeDOMTypes.XplParameter:
                    processParameter((XplParameter)node, EZOEContext.FunctionDecl);
                    break;
                case CodeDOMTypes.XplType:
                    p_onWritecode = false;
                    return renderType((XplType)node, String.Empty, EZOETypeContext.Unknow, EZOEContext.FunctionBody);
                case CodeDOMTypes.XplExpression:
                    p_onWritecode = false;
                    return RenderExpression((XplExpression)node);
                default:
                    return "## Can't convert to string this node.";
            }

            p_onWritecode = onWritecode;
            retStr = p_currentWritecodeStr;
            p_newLineFlag = backIsNewLine;
            p_currentWritecodeStr = backWCS;

            return retStr;
        }

    }
}
