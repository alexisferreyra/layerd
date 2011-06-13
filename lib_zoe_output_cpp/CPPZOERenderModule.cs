/****************************************************************************
 
  C++ Output Module for Zoe compiler
  
  Original Author: Mateo Bengualid
  Contact: apoteoticos@gmail.com
  
  Please visit http://layerd.net to get the last version
  of the software and information about LayerD technology.

****************************************************************************/
/*-
 * Copyright (c) 2009 Mateo Bengualid
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
using System.Collections.Generic;

namespace LayerD.OutputModules
{
    /// <summary>
    /// Generador de Código ZOE a código C#.
    /// Extiende la clase abstracta ExtendedZOEProcessor e implementa
    /// las funciones de renderización de elementos.
    /// </summary>
    public class CPPZOERenderModule : ExtendedZOEProcessor, IEZOERender
    {
        #region Tipos privados
        private enum FunctionType
        {
            Method,
            Indexer,
            Operator,
            Property
        }
        private enum Precedences
        {
            PrimaryExp = -1,
            BracketExp = -1,
            FunctionCallExp = -1,
            NewExp = -1,
            DeleteExp = -2,
            CastExp = -2,
            IsExp = -6,
            ConditionalExp = -13,
            AssingExp = -14
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
        const string InitializerMethodName = "__layerd_init_fields__";
        const string IncludePC = "#include ";
        const string NamespacePC = "namespace ";
        const string ClassPC = "class ";
        const string StructPC = "struct ";
        const string UnionPC = "struct ";
        const string EnumPC = "enum ";
        const string InterfacePC = "interface ";// <-- Use a .h file or a class with abstract methods.
        const string AbstractPC = "abstract ";// <-- Use a .h file or a class with abstract methods.
        const string FinalPC = "sealed ";// <-- Simulated with a private constructor.
        const string NewPC = "new ";
        const string VolatilePC = "volatile ";
        const string ConstPC = "const ";
        const string PrivatePC = "private: "; // The ":" serves to emulate other language definitions.
        const string ProtectedPC = "protected: "; // The ":" serves to emulate other language definitions.
        const string PublicPC = "public: "; // The ":" serves to emulate other language definitions.
        const string InternalPC = "";// <-- Non C++ related.
        const string DelegatePC = "";// <-- Simulated with member function pointers or templatized functors.
        const string ExplicitPC = "";// <-- Simulated with old C-style cast definition with Y(const X& x)
        const string ImplicitPC = "implicit ";// <-- Simulated with old C-style cast definition with Y(const X& x)
        const string OperatorPC = "operator ";
        const string VirtualPC = "virtual ";
        const string OverridePC = "override ";
        const string IndexerPC = "this ";
        const string ParamsPC = "... ";// <-- Used in a different position.
        const string InPC = "in ";
        const string InoutPC = "&";// <-- In fact, it  is just the use of a pointer.
        const string OutPC = "&";// <-- In fact, it  is just the use of a pointer.
        const string ReturnPC = "return";
        const string ThrowPC = "throw ";
        const string SwitchPC = "switch ";
        const string BreakPC = "break";
        const string CatchPC = "catch ";
        const string ContinuePC = "continue";
        const string FinallyPC = "finally ";
        const string GotoPC = "goto ";
        const string TryPC = "try ";
        const string DoPC = "do ";
        const string WhilePC = "while ";
        const string CasePC = "case ";
        const string DeletePC = "delete ";
        const string ElsePC = "else ";
        const string ForPC = "for ";
        const string IfPC = "if ";
        const string ExternPC = "extern ";
        const string StaticPC = "static ";
        const string DefaultPC = "default ";
        const string PartialPC = "";// <-- Glue the whole bunch at the end.
        const string UniversalMockClassName = "MockClass";
        const string UniversalMockNamespaceName = "MockNS";
        //TODO: Add here the rest of the C++ dependant reserved words.
        const string FriendPC = "friend ";// Not yet supported.
        const string ScopePC = "::";

        const string PARTIAL_CLASS_FLAG = "$DOTNET_MARK_PARTIAL$";//Assume that this will only mean to join classes.
        #endregion

        #region Datos Privados o Protegidos

        string p_outputFileName = "";
        bool p_dontWriteCopyrightComment = true;
        bool p_newFilePerClass = false;
        bool p_writeDetailedComments = false;
        bool p_isUnsafeContext = false;
        bool p_applyFormat = true;
        bool p_checkTypes = true;
        bool p_newLineFlag = true;
        bool p_OptimiseParenthesis = true;
        bool p_buildFullType = false;
        bool p_prettyOutput = false;
        bool p_isDebugMode;
        string p_namespaceToRemove = "";

        bool aStaticMainMethodExists = false;
        bool aStaticMainMethodWithArgumentsExists = false;
        string mainMethodSignature = "";
        bool atLeastOneConstructor;
        List<string> mockClasses = new List<string>();
        List<string> currentClassConstructorInitializers = new List<string>();
        TextWriter currentCodeWriter = null;
        TextWriter currentHeaderWriter = null;

        // Linux has issues with UTF8 encoding, so ASCII will be fine.
        System.Text.Encoding p_outputEncoding = System.Text.Encoding.ASCII;//System.Text.Encoding.UTF8;
        int p_nestingLevel = 0;
        int p_maxParameter = 0;
        string p_tabString = "";
        FunctionType currentFunctionType = FunctionType.Method;
        // Variables para el seguimiento de archivo y linea
        string p_CurrentCodeFile = "";
        int p_currentCodeRealLine = 0;
        int p_lastCodeStatementLine;

        string p_CurrentHeaderFile = "";
        int p_currentHeaderRealLine = 0;
        int p_lastHeaderStatementLine;
        // Cadena para trabajo temporario
        string tempStr = "";

        string p_outputPath = null;
        bool p_dontWriteLineDirecties;
        XplLayerDZoeProgramModuletype_enum p_outputModuleType = XplLayerDZoeProgramModuletype_enum.EXECUTABLE;
        string p_intermediateFile = "";
        string p_currentLine = "";
        ArrayList p_currentCodeFileLines;
        ArrayList p_currentHeaderFileLines;
        ErrorCollection p_errors = new ErrorCollection();
        ArrayList p_assemblyList = new ArrayList();
        int p_isExternalClass;
        Hashtable p_usedTemplateInstances = new Hashtable();
        SortedList p_includes = new SortedList();
        ClassInfo p_currentClassInfo = ClassInfo.New();
        ArrayList p_classInfos = new ArrayList();

        string p_currentPackage = "";
        string p_currentClass = "";

        #endregion

        #region Constructores
        /// <summary>
        /// Initializes a new instance of the <see cref="CPPZOERenderModule"/> class.
        /// </summary>
        public CPPZOERenderModule()
            : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CPPZOERenderModule"/> class.
        /// </summary>
        /// <param name="inputFileName">Name of the input file.</param>
        public CPPZOERenderModule(string inputFileName)
            : base(inputFileName)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CPPZOERenderModule"/> class.
        /// </summary>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <param name="newFilePerClass">if set to <c>true</c> a new file per class is created.</param>
        public CPPZOERenderModule(string inputFileName, bool newFilePerClass)
            : base(inputFileName)
        {
            p_newFilePerClass = newFilePerClass;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CPPZOERenderModule"/> class.
        /// </summary>
        /// <param name="inputFileName">Name of the input file.</param>
        /// <param name="outputFileName">Name of the output file.</param>
        public CPPZOERenderModule(string inputFileName, string outputFileName)
            : base(inputFileName)
        {
            p_outputFileName = outputFileName;
            p_newFilePerClass = false;
        }
        #endregion

        #region Miembros Privados Utilitarios

        #region PrepareOutput, CloseOutput, writeOut, writeNewLine, incNlevel, decNlevel, writeLineDirective
        private string getHeaderFileVersion(string currentFile)
        {
            // Remove any extension of three or less letters that the file may have.
            int lastDot = currentFile.LastIndexOf(".");
            if (currentFile.Length - lastDot <= 4)
            {
                return currentFile.Substring(0, lastDot) + ".h";
            }
            else
            {
                return currentFile + ".h";
            }
        }

        private string getCodeFileVersion(string currentFile)
        {
            // Remove any extension of three or less letters that the file may have.
            int lastDot = currentFile.LastIndexOf(".");
            if (currentFile.Length - lastDot <= 4)
            {
                return currentFile.Substring(0, lastDot) + ".cpp";
            }
            else
            {
                return currentFile + ".cpp";
            }
        }

        private void writeLineDirective(string ldsrc, bool isMaxLine)
        {
            if (p_dontWriteLineDirecties) return;
            if (ldsrc == null) return;
            //Debo parsear ldsrc para obtener las lineas y los archivos origen
            int minLine = 0, maxLine = 0;
            string currentFile = "";
            parseLDSRC(ldsrc, ref minLine, ref  maxLine, ref currentFile);
            if (currentFile != "") currentFile = getCodeFileVersion(GetRelativeToOutputSourceFileName(currentFile));

            if (isMaxLine)
            {
                if (currentFile != "" && currentFile != p_CurrentCodeFile)
                {
                    p_CurrentCodeFile = currentFile;
                    if (maxLine != p_currentCodeRealLine && maxLine > 0) { writeLineDirectiveText("#line " + maxLine + " \"" + p_CurrentCodeFile + "\""); p_currentCodeRealLine = maxLine; }
                }
                else
                    if (maxLine != p_currentCodeRealLine && maxLine > 0) { writeLineDirectiveText("#line " + maxLine); p_currentCodeRealLine = maxLine; }
            }
            else
            {
                if (currentFile != "" && currentFile != p_CurrentCodeFile)
                {
                    p_CurrentCodeFile = currentFile;
                    if (minLine != p_currentCodeRealLine && minLine > 0) { writeLineDirectiveText("#line " + minLine + " \"" + p_CurrentCodeFile + "\""); p_currentCodeRealLine = minLine; }
                }
                else
                    if (minLine != p_currentCodeRealLine && minLine > 0) { writeLineDirectiveText("#line " + minLine); p_currentCodeRealLine = minLine; }
            }
        }

        private void writeLineDirectiveText(string p)
        {
            if (p_dontWriteLineDirecties) return;
            if (!p_newLineFlag)
            {
                writeNewLineOfCode();
            }
            writeOut(p);
            writeNewLineOfCode();
        }

        private string GetRelativeToOutputSourceFileName(string currentFile)
        {
            //Se lo deberia mejorar para calcular un path relativo
            //al archivo de entrada.
            return Path.GetFullPath(currentFile);
        }
        private void parseLDSRC(string ldsrc, ref int minLine, ref int maxLine, ref string currentFile)
        {
            string[] data = ldsrc.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            switch (data.Length)
            {
                case 1:
                    minLine = maxLine = Int32.Parse(data[0]);
                    break;
                case 2:
                    minLine = Int32.Parse(data[0]);
                    maxLine = Int32.Parse(data[1]);
                    break;
                case 3:
                    minLine = Int32.Parse(data[0]);
                    maxLine = Int32.Parse(data[1]);
                    currentFile = data[2];
                    break;
                case 5:
                    // Parser dpp no te da info de la columna.
                    minLine = Int32.Parse(data[0]);
                    maxLine = Int32.Parse(data[2]);
                    currentFile = data[4];
                    break;
            }
        }
        private void PrepareOutput()
        {
            if (!p_newFilePerClass)
            {
                p_currentCodeFileLines = new ArrayList();
                p_currentHeaderFileLines = new ArrayList();
            }
            else
            {
                throw new NotImplementedException("La capacidad para generar un archivo por clase no esta implementada.");
            }
        }
        private void CloseOutput()
        {
            if (!p_newFilePerClass)
            {
            }
            else
            {
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
        private void writeNewLineOfCode()
        {
            // trick to remove additional tab from .cpp
            if(p_currentLine.Length>0 && p_currentLine[0]=='\t') 
                p_currentCodeFileLines.Add(p_currentLine.Substring(1));
            else
                p_currentCodeFileLines.Add(p_currentLine);

            p_currentLine = "";
            p_newLineFlag = true;
            p_currentCodeRealLine++;
        }
        private void writeNewLineOfHeader()
        {
            p_currentHeaderFileLines.Add(p_currentLine);
            p_currentLine = "";
            p_newLineFlag = true;
            p_currentHeaderRealLine++;
        }
        private void writeNewLineOfBothFiles()
        {
            string previousLine = p_currentLine;
            bool previousLineFlag = p_newLineFlag;

            writeNewLineOfCode();
            p_currentLine = previousLine;
            p_newLineFlag = previousLineFlag;
            writeNewLineOfHeader();
        }
        private void incNLevel()
        {
            p_nestingLevel++;
            p_tabString += "\t";
        }
        private void decNLevel()
        {
            if (p_nestingLevel != 0)
            {
                p_nestingLevel--;
                p_tabString = p_tabString.Remove(p_tabString.Length - 1, 1);
            }
        }

        #endregion

        #region AddError,Warning,Comments
        private void writeComment(string comment)
        {
            writeOut("/*" + comment + "*/");
        }
        private void writeLineComment(string comment)
        {
            writeOut("/*" + comment + "*/");
            writeNewLineOfBothFiles();
        }
        private void writeLineCommentHeader(string comment)
        {
            writeOut("/*" + comment + "*/");
            writeNewLineOfHeader();
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
        #endregion

        #region getAccess, Storage y BaseInitializers
        string getStorage(XplVarstorage_enum storage, EZOEContext context)
        {
            tempStr = "";
            switch (storage)
            {
                case XplVarstorage_enum.AUTO:
                    break;
                case XplVarstorage_enum.EXTERN:
                    tempStr = ExternPC; break;
                case XplVarstorage_enum.STATIC:
                    tempStr = StaticPC; break;
                case XplVarstorage_enum.STATIC_EXTERN:
                    tempStr = ExternPC + StaticPC; break;
                default:
                    AddWarning("Constante de almacenamiento desconocida '" + storage.ToString() + "'.");
                    break;
            }
            return tempStr;
        }
        string getAccess(XplAccesstype_enum access, EZOEContext context)
        {
            string retStr = "";
            switch (access)
            {
                case XplAccesstype_enum.PRIVATE:
                    if (context == EZOEContext.NamespaceBody) retStr = InternalPC;
                    else retStr = PrivatePC;
                    break;
                case XplAccesstype_enum.PROTECTED:
                    if (context == EZOEContext.NamespaceBody) retStr = ProtectedPC + InternalPC;
                    else retStr = ProtectedPC;
                    break;
                case XplAccesstype_enum.PUBLIC:
                    retStr = PublicPC; break;
                // Estas son protectores para código inyectado.
                case XplAccesstype_enum.IPRIVATE:
                    AddWarning("Modificador de accesso 'iprivate' inesperado en código EZOE. Usando 'private' en su lugar.");
                    if (context == EZOEContext.NamespaceBody) retStr = InternalPC;
                    else retStr = PrivatePC;
                    break;
                case XplAccesstype_enum.IPROTECTED:
                    AddWarning("Modificador de accesso 'iprotected' inesperado en código EZOE. Usando 'private' en su lugar.");
                    if (context == EZOEContext.NamespaceBody) retStr = InternalPC;
                    else retStr = PrivatePC;
                    break;
                case XplAccesstype_enum.IPUBLIC:
                    AddWarning("Modificador de accesso 'ipublic' inesperado en código EZOE. Usando 'private' en su lugar.");
                    if (context == EZOEContext.NamespaceBody) retStr = InternalPC;
                    else retStr = PrivatePC;
                    break;
                default:
                    AddWarning("Modificador de accesso 'desconocido' inesperado en código EZOE. Usando 'private' en su lugar.");
                    if (context == EZOEContext.NamespaceBody) retStr = InternalPC;
                    else retStr = PrivatePC;
                    break;
            }
            return retStr;
        }
        private string renderBaseInitializers(XplBaseInitializers initializers)
        {
            tempStr = "";
            if (initializers == null) return "";
            foreach (XplBaseInitializer initializer in initializers.Children())
            {
                //tempStr+=processUserTypeName(initializer.get_className());
                // TODO: Verificar que no rompe algo la simple concatenación en lugar de procesarlo.
                tempStr += initializer.get_className();
                tempStr += "(" + processExpressionList(initializer.get_params(), EZOEContext.FunctionDecl) + ") : ";
                //Sera un error cuando se posea mas de un inicializador de clase base
            }
            if (tempStr != "")
                return tempStr.Substring(0, tempStr.Length - 2);
            else
                return "";
        }
        #endregion

        #region processSimpleTypeName y processUserTypeName

        string processUserTypeName(string typeName)
        {
            if (p_namespaceToRemove != "" && typeName.StartsWith(p_namespaceToRemove))
                typeName = typeName.Remove(0, p_namespaceToRemove.Length + 2);

            // If it contains the mock class name, just cut the name and scope operator.
            foreach (string mockClass in mockClasses)
            {
                int lastIndex = typeName.LastIndexOf(mockClass);
                if (lastIndex >= 0)
                {
                    typeName = typeName.Remove(lastIndex, mockClass.Length + 2);
                }
            }

            // TODO : warning!! this is for .NET templates
            //if (p_usedTemplateInstances.ContainsKey(typeName))
            //{
            //    typeName = (string)p_usedTemplateInstances[typeName];
            //    if (p_prettyOutput)
            //    {
            //        for (int n = p_includes.Count - 1; n >= 0; n--)
            //        {
            //            string usingStr = (string)p_includes.GetByIndex(n) + ".";
            //            if (typeName.Contains(usingStr))
            //            {
            //                typeName = typeName.Replace(usingStr, String.Empty);
            //                if (p_currentClassInfo.Usings[usingStr.Substring(0, usingStr.Length - 1)] == null)
            //                    p_currentClassInfo.Usings.Add(usingStr.Substring(0, usingStr.Length - 1), usingStr.Substring(0, usingStr.Length - 1));
            //                //break;
            //            }
            //        }
            //    }
            //}

            //if (p_prettyOutput)
            //{
            //    for (int n = p_includes.Count - 1; n >= 0; n--)
            //    {
            //        string usingStr = (string)p_includes.GetByIndex(n);
            //        if (typeName.StartsWith(usingStr))
            //        {
            //            typeName = typeName.Substring(usingStr.Length + 1);
            //            if (p_currentClassInfo.Usings[usingStr] == null)
            //                p_currentClassInfo.Usings.Add(usingStr, usingStr);
            //            break;
            //        }
            //    }
            //}

            // TODO: Agregar referencia a time.h
            if (typeName.StartsWith("zoe.lang.DateTime")) typeName = typeName.Replace("zoe.lang.DateTime", "time_t");

            typeName = typeName.Replace(".", ScopePC);

            if (typeName.StartsWith(UniversalMockNamespaceName))
                typeName = typeName.Substring(UniversalMockNamespaceName.Length + 2);
            if (typeName.StartsWith(UniversalMockClassName))
                typeName = typeName.Substring(UniversalMockClassName.Length + 2);
            // if (typeName.StartsWith("zoe::lang::Object")) typeName = typeName.Replace("zoe::lang::Object", "zoe.lang.Object");

            return typeName;
        }
        /// <summary>
        /// A usar por declaracion de namespaces
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        string processUserTypeName2(string typeName)
        {
            if (p_namespaceToRemove != "" && typeName.StartsWith(p_namespaceToRemove))
                typeName = typeName.Remove(0, p_namespaceToRemove.Length + 1);

            return typeName;
        }

        string processSimpleTypeName(string nt, ref bool isValueType)
        {
            string retStr = "";
            #region switch simple type name
            switch (nt)
            {
                case "$INTEGER$":
                    retStr = "int";
                    isValueType = true;
                    break;
                case "$UNSIGNED$":
                    retStr = "unsigned int";
                    isValueType = true;
                    break;
                case "$LONG$":
                    retStr = "long";
                    isValueType = true;
                    break;
                case "$ULONG$":
                    retStr = "unsigned long";
                    isValueType = true;
                    break;
                case "$SHORT$":
                    retStr = "short";
                    isValueType = true;
                    break;
                case "$USHORT$":
                    retStr = "unsigned short";
                    isValueType = true;
                    break;
                case "$SBYTE$":
                    retStr = "char";
                    isValueType = true;
                    break;
                case "$BYTE$":
                    retStr = "unsigned char";
                    isValueType = true;
                    break;
                case "$FLOAT$":
                    retStr = "float";
                    isValueType = true;
                    break;
                case "$DOUBLE$":
                    retStr = "double";
                    isValueType = true;
                    break;
                case "$LDOUBLE$":
                    retStr = "long double";
                    isValueType = true;
                    break;
                // Sin equivalencia en C++
                case "$DECIMAL$":
                    retStr = "long double";
                    break;
                case "$FIXED$":
                    retStr = "double";
                    break;
                // Dependiendo de la implementación, existe o no un bool.
                case "$BOOLEAN$":
                    retStr = "bool";
                    break;
                case "$CHAR$":
                    retStr = "char";
                    isValueType = true;
                    break;
                case "$STRING$":
                    retStr = "string";
                    break;
                case "$ASCIISTRING$":
                    retStr = "string";
                    break;
                case "$ASCIICHAR$":
                    retStr = "char";
                    isValueType = true;
                    break;
                case "$DATE$":
                    retStr = "time_t";
                    break;
                case "$VOID$":
                    retStr = "void";
                    break;
                case "$OBJECT$":
                    retStr = "object";
                    break;
                case "$NONE$":
                    retStr = "";
                    break;
                case "$TYPE$":
                    AddError("No es posible procesar tipo 'type'. Usando tipo 'object'.");
                    retStr = "object";
                    break;
                case "$BLOCK$":
                    AddError("No es posible procesar tipo 'block'. Usando tipo 'object'.");
                    retStr = "object";
                    break;
                default:
                    AddError("No es posible procesar tipo '" + nt + "'. Usando tipo 'object'.");
                    retStr = "object";
                    break;
            }
            #endregion
            return retStr;
        }

        #endregion

        #region Ayudas para Procesar Tipos
        string getTypeName(XplType type, EZOETypeContext typeContext, ref bool isValueType)
        {
            if (type == null)
            {
                if (typeContext == EZOETypeContext.ReturnTypeDecl)
                    return "";
                else
                {
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
                else if (typeStr == "zoe.lang.DateTime") return "time_t";
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
        bool checkPointerType(XplType type, EZOETypeContext context)
        {
            // PENDIENTE : hacer que funcione en modo depuracion,
            // asi normalmente no relentiza la generación al vicio.
            return true;
        }
        string getArrayStr(XplType type, EZOETypeContext typeContext, EZOEContext context, bool isValueType)
        {
            //Aca tendria que procesar lo siguiente:
            //Cuando tengo:
            //     ^[][][]int <-- int [,,]
            //     ^[][][]^[][]int <-- int[,,][,]
            //     
            string retStr = String.Empty;

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
                    //if (derived.get_isarray()) retStr += ",";
                    // TODO: Chequear que esto no sea jagged matrix, sino otra cosa.
                    if (derived.get_isarray()) retStr += "][";
                    else if (isInArray)
                    {
                        retStr += "]";
                        isInArray = false;
                    }
                }
                currentType = derived;
            }
            if (isInArray) retStr += "]";
            return retStr;
        }
        string getPointerStr(XplType type, EZOETypeContext context, bool isValueType)
        {
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

            XplType currentType = type, derived = null;
            bool isRef = false;
            while (currentType != null)
            {
                derived = currentType.get_dt();
                if (!currentType.get_ispointer() && !currentType.get_isarray()) break;
                if (currentType.get_ispointer())
                {
                    isRef = currentType.get_pi().get_ref();
                    if (derived != null
                        && !derived.get_isarray()
                        && !isRef)
                    {
                        retStr += "*";
                        if (currentType.get_pi().get_const()) retStr += " const";
                        if (currentType.get_pi().get_volatile()) retStr += " volatile";
                    }
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
        int getExpressionPrecedence(XplExpression exp)
        {
            int retVal = 0;
            XplNode expNode = exp.get_Content();
            switch (expNode.get_ElementName())
            {
                case "a":
                    retVal = (int)Precedences.AssingExp;
                    break;
                case "new":
                    retVal = (int)Precedences.NewExp;
                    break;
                case "bo":
                    retVal = getOperatorPrecedence(((XplBinaryoperator)expNode).get_op());
                    break;
                case "uo":
                    retVal = getOperatorPrecedence(((XplUnaryoperator)expNode).get_op());
                    break;
                case "b":
                    retVal = (int)Precedences.BracketExp;
                    break;
                case "n":
                    retVal = (int)Precedences.PrimaryExp;
                    break;
                case "lit":
                    retVal = (int)Precedences.PrimaryExp;
                    break;
                case "fc":
                    retVal = (int)Precedences.FunctionCallExp;
                    break;
                case "cast":
                    retVal = (int)Precedences.CastExp;
                    break;
                case "delete":
                    retVal = (int)Precedences.DeleteExp;
                    break;
                case "onpointer":
                    retVal = (int)Precedences.PrimaryExp;
                    break;
                case "empty":
                    retVal = (int)Precedences.PrimaryExp;
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
        protected override void processDocumentData(XplDocumentData documentData)
        {
            //Por ahora no hago nada para procesar la info de configuración
        }
        #endregion

        #region Inicio y Fin de Documento
        /// <summary>
        /// Renders the begin document body.
        /// </summary>
        /// <param name="documentBody">The document body.</param>
        protected override void renderBeginDocumentBody(XplDocumentBody documentBody)
        {
            string temp =
              "---------------------------------------------------------------------\n"
            + " This file was autogenerated.\n"
            + " DO NOT MODIFY THIS FILE MANUALLY.\n"
            + " Date: " + DateTime.Now.ToString() + ".\n\n"
            + " Generated by: Cpp LayerD Generator - ZOE Output Module to C++\n"
            + " 2009(R)Mateo Bengualid, Alexis Ferreyra\n\n"
            + " Please visit http://layerd.net to get last version of LayerD tools.\n"
            + "---------------------------------------------------------------------";
            if (!p_dontWriteCopyrightComment)
            {
                writeLineComment(temp);
                writeNewLineOfBothFiles();
            }

            // Print the import of the header file, in the code file.
            writeOut(IncludePC + " \"" + getHeaderFileVersion(p_outputFileName) + "\"");
            writeNewLineOfCode();

            writeLineDirective(documentBody.get_ldsrc(), false);
        }
        /// <summary>
        /// Renders the end document body.
        /// </summary>
        /// <param name="documentBody">The document body.</param>
        protected override void renderEndDocumentBody(XplDocumentBody documentBody)
        {
            // If a static main function was provided in at least
            // one class, call it at the end.
            if (aStaticMainMethodWithArgumentsExists)
            {
                renderIntMainFunctionWithParameters(mainMethodSignature);
            }
            else if (aStaticMainMethodExists)
            {
                renderIntMainFunction(mainMethodSignature);
            }
            
            writeNewLineOfBothFiles();
        }
        #endregion

        #region Declaraciones
        /// <summary>
        /// Renders the import directive.
        /// </summary>
        /// <param name="importDirective">The import directive.</param>
        protected override void renderImportDirective(XplName importDirective)
        {
            // PENDIENTE : si el compilador ZOE me manda todos los import,
            // solo debo procesar los que correspondan a este modulo de salida.
            writeLineDirective(importDirective.get_ldsrc(), false);
            string usingString = null;
            bool flag = false;
            bool externC = false;
            foreach (XplNode node in importDirective.Children())
            {
                tempStr = node.get_StringValue();
                // Ignore the namespace inclusion. Only do the #include and assume inlining.
                /*
                if (tempStr.IndexOf('=') == -1)
                {
                    usingString = IncludePC + tempStr + ";";
                    //break;
                }
                else */
                if (tempStr.IndexOf('=') != -1)
                {
                    flag = true;
                    string parameterName = tempStr.Substring(0, tempStr.IndexOf('=')).ToLower();
                    string parameterValue = tempStr.Substring(tempStr.IndexOf('=') + 1);
                    switch (parameterName)
                    {
                        case "header":
                            if(parameterValue[0]=='<')
                                usingString = IncludePC + parameterValue;
                            else
                                usingString = IncludePC + "\"" + parameterValue + "\"";
                            break;
                        case "mockclass":
                            mockClasses.Add(parameterValue);
                            break;
                        case "externc":
                            externC = true;
                            break;
                        case "ns":
                            if (p_namespaceToRemove == "")
                                p_namespaceToRemove = parameterValue;
                            break;
                    }
                }
            }
            if (flag)
            {
                if (externC)
                {
                    writeOut("extern \"C\" {");
                    writeNewLineOfHeader();
                    writeOut(usingString);
                    writeNewLineOfHeader();
                    writeOut("}");
                    writeNewLineOfHeader();
                    writeNewLineOfHeader();
                }
                else
                {
                    writeOut(usingString);
                    writeNewLineOfHeader();
                    writeNewLineOfHeader();
                }
            }
        }
        /// <summary>
        /// Renders the begin namespace.
        /// </summary>
        /// <param name="namespaceName">Name of the namespace.</param>
        /// <param name="namespaceDecl">The namespace decl.</param>
        /// <param name="context">The context.</param>
        protected override void renderBeginNamespace(string namespaceName, XplNamespace namespaceDecl, EZOEContext context)
        {
            // If the class name is the universal mock class, then ignore further processing.
            if (namespaceName == UniversalMockNamespaceName)
            {
                return;
            }

            // If the namespace is the namespace of an import, and its parent is
            // the document body, then don't render it.
            if( namespaceDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplDocumentBody
                && namespaceName == p_namespaceToRemove)
            {
                p_isExternalClass++;
                return;
            }

            string directorio = processUserTypeName2(namespaceName);
            if (p_currentPackage == "")
                p_currentPackage += directorio;
            else
                p_currentPackage += ScopePC + directorio;

            p_currentClass = p_currentPackage;

            if (namespaceDecl.Children().GetLength() == 0) return;
            writeNewLineOfBothFiles();
            writeLineDirective(namespaceDecl.get_ldsrc(), false);
            writeOut(NamespacePC + processUserTypeName2(namespaceName));
            writeNewLineOfBothFiles();
            writeOut("{");
            incNLevel();
            writeNewLineOfBothFiles();

            // init new class info
            p_currentClassInfo = ClassInfo.New();
            p_currentClassInfo.FirstLine = p_currentCodeFileLines.Count;
        }
        /// <summary>
        /// Renders the end namespace.
        /// </summary>
        /// <param name="namespaceName">Name of the namespace.</param>
        /// <param name="namespaceDecl">The namespace decl.</param>
        /// <param name="context">The context.</param>
        protected override void renderEndNamespace(string namespaceName, XplNamespace namespaceDecl, EZOEContext context)
        {
            // If the class name is the universal mock class, then ignore further processing.
            if (namespaceName == UniversalMockNamespaceName)
            {
                return;
            }

            // If the namespace was the namespace of an import, and its parent is
            // the document body, then don't render it.
            if (namespaceDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplDocumentBody
                && namespaceName == p_namespaceToRemove)
            {
                p_isExternalClass--;
                return;
            }

            p_currentPackage = p_currentPackage.Substring(0, p_currentPackage.Length - processUserTypeName2(namespaceName).Length);
            p_currentClass = p_currentPackage;

            if (p_currentPackage != "") p_currentPackage = p_currentPackage.Substring(0, p_currentPackage.Length - 1);

            if (namespaceDecl.Children().GetLength() == 0) return;

            writeLineDirective(namespaceDecl.get_ldsrc(), true);
            decNLevel();
            writeOut("} ");
            if (p_writeDetailedComments) writeComment("Fin Espacio de Nombres '" + namespaceName + "'");
            writeNewLineOfBothFiles();
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
            // Clean up the initializers' chain list.
            currentClassConstructorInitializers = new List<string>();

            // Clean up the constructor presence flag.
            atLeastOneConstructor = false;

            p_currentClass += ScopePC + className;

            if (classDecl.get_externalname() != "")
                className = classDecl.get_externalname();

            {
                //Para clases que simulan instancias de genericos
                //asumo el formato $TEMPLATE[ZoeClassName|NetGenericName<With,Generic,Params>]$
                string lddata = classDecl.get_lddata();
                int index = lddata.IndexOf("$TEMPLATE"), index2;
                if (index >= 0)
                {
                    string netGenericName;
                    index = lddata.IndexOf('[', index);
                    index2 = lddata.IndexOf(']', index);
                    netGenericName = lddata.Substring(index + 1, index2 - index - 1);
                    p_usedTemplateInstances.Add(p_currentClass, netGenericName);
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
                // If the class name is the universal mock class, then ignore further processing.
                if (className == UniversalMockClassName)
                {
                    return;
                }

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
            if (classDecl.get_lddata().Contains(PARTIAL_CLASS_FLAG)) writeOut(PartialPC);

            //La declaracion del nombre
            switch (classType)
            {
                case EZOEClassType.Class:
                    writeOut(ClassPC + className);
                    break;
                case EZOEClassType.Interface:
                    writeOut(ClassPC + className);
                    break;
                case EZOEClassType.Struct:
                    writeOut(StructPC + className);
                    break;
                case EZOEClassType.Union:
                    writeOut(UnionPC + className);
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
            writeNewLineOfHeader();
            writeOut("{");
            incNLevel();
            writeNewLineOfHeader();

            if (p_prettyOutput)
            {
                p_lastCodeStatementLine = 0;
                p_lastHeaderStatementLine = 0;
            }
        }
        /// <summary>
        /// Renders the end class.
        /// </summary>
        /// <param name="classType">Type of the class.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="classDecl">The class decl.</param>
        /// <param name="context">The context.</param>
        protected override void renderEndClass(EZOEClassType classType, string className, XplClass classDecl, EZOEContext context)
        {
            p_currentClass = p_currentClass.Substring(0, p_currentClass.Length - className.Length);
            if (p_currentClass.Length > 1) p_currentClass = p_currentClass.Substring(0, p_currentClass.Length - 1);

            // Si la clase actual es externa retorno
            if (p_isExternalClass > 0)
            {
                if (classDecl.get_external()) p_isExternalClass--;
                return;
            }

            // If the class name is the universal mock class, then ignore further processing.
            if (className == UniversalMockClassName)
            {
                return;
            }

            // render initializer of fields and default constructor if not provided
            if (!classDecl.get_isenum() && !classDecl.get_isstruct() && !classDecl.get_isinteractive() && !classDecl.get_isunion())
            {

                // Render the initializer method in the header.
                if (currentClassConstructorInitializers.Count > 0)
                {
                    writeLineComment("This method is provided to initialize all variables.");
                    writeOut(PrivatePC + "inline void " + InitializerMethodName + "();");
                    writeNewLineOfHeader();

                    // Render the initializer method in the code.

                    if (className != UniversalMockClassName
                        && !mockClasses.Contains(className))
                    {
                        writeOut("inline void " + className + ScopePC + InitializerMethodName + "() {");
                    }
                    else
                    {
                        writeOut("inline void " + InitializerMethodName + "() {");
                    }
                    incNLevel();
                    foreach (string initialization in currentClassConstructorInitializers)
                    {
                        writeOut(initialization);
                    }
                    decNLevel();
                    writeOut("}");
                    writeNewLineOfCode();

                    // If a constructor was not included, provide a default one.
                    if (!atLeastOneConstructor && !classDecl.get_isinterface())
                    {
                        // Define in the header file.
                        writeLineCommentHeader("This default constructor is provided to initialize all variables.");
                        writeOut(PublicPC + className + "();");
                        writeNewLineOfHeader();

                        // Implement in the code file.
                        writeOut(className + ScopePC + className + "() { " + InitializerMethodName + "(); }");
                        writeNewLineOfCode();
                    }
                }
            }

            writeLineDirective(classDecl.get_ldsrc(), true);
            decNLevel();
            writeOut("}; ");
            if (p_writeDetailedComments) writeComment("End of class '" + className + "'");
            writeNewLineOfHeader();

            // If it is a first level class add CurrentClassInfo data
            if (classDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplNamespace)
            {
                p_currentClassInfo.LastLine = p_currentCodeFileLines.Count;
                p_classInfos.Add(p_currentClassInfo);
                // Create a new ClassInfo
                p_currentClassInfo = ClassInfo.New();
                p_currentClassInfo.FirstLine = p_currentCodeFileLines.Count;
            }
        }
        /// <summary>
        /// Render a implements.
        /// </summary>
        /// <param name="classDecl">The class decl.</param>
        /// <param name="implements">The implements.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderImplements(XplClass classDecl, XplNodeList implements, EZOEContext context)
        {
            string temp = "";
            XplInherit imp = null;
            XplInherits imps = null;
            foreach (XplInherits node in implements)
            {
                imps = node;
                foreach (XplInherit node2 in imps.Children())
                {
                    imp = node2;
                    temp += "public " + processUserTypeName(imp.get_type().get_typename()) + ", ";
                }
            }
            if (temp != "") temp = temp.Substring(0, temp.Length - 2);
            return temp;
        }
        /// <summary>
        /// Render a inherits.
        /// </summary>
        /// <param name="classDecl">The class decl.</param>
        /// <param name="inherits">The inherits.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderInherits(XplClass classDecl, XplNodeList inherits, EZOEContext context)
        {
            string temp = "";
            XplInherit inh = null;
            XplInherits inhs = null;
            foreach (XplNode node in inherits)
            {
                inhs = (XplInherits)node;
                foreach (XplNode node2 in inhs.Children())
                {
                    inh = (XplInherit)node2;
                    if (processUserTypeName(inh.get_type().get_typename()) != "zoe.lang.Object")
                    {
                        string accessStr = "public ";
                        switch (inh.get_access())
                        {
                            case XplAccesstype_enum.INTERNAL:
                            case XplAccesstype_enum.PUBLIC:
                                break;
                            case XplAccesstype_enum.PROTECTED:
                                accessStr = "protected "; 
                                break;
                            case XplAccesstype_enum.PRIVATE:
                                accessStr = "private "; 
                                break;
                            case XplAccesstype_enum.IINTERNAL:
                            case XplAccesstype_enum.IPUBLIC:
                            case XplAccesstype_enum.IPROTECTED:
                            case XplAccesstype_enum.IPRIVATE:
                            default:
                                AddWarning("Inherit access modifiers iinternal, ipublic, iprotected and iprivate not supported. Using private access.");
                                accessStr = "private ";
                                break;
                        }
                        if (inh.get_virtual()) temp += "virtual ";
                        temp += accessStr + processUserTypeName(inh.get_type().get_typename()) + ", ";
                    }
                }
            }
            if (temp != "") temp = temp.Substring(0, temp.Length - 2);
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
            XplAccesstype_enum access, XplVarstorage_enum functionStorage, bool isAbstract, bool isFinal, bool isFp, bool isNew, bool isConst,
            bool isOverride, bool isVirtual, EZOEContext context)
        {
            //Si la clase actual es externa retorno
            if (p_isExternalClass > 0 || functionStorage == XplVarstorage_enum.EXTERN || functionStorage == XplVarstorage_enum.STATIC_EXTERN) return;

            writeLineDirective(functionDecl.get_ldsrc(), false);

            string baseInitializers = renderBaseInitializers(functionDecl.get_BaseInitializers());

            bool isInterface = functionDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplClass && functionDecl.CurrentClass.get_isinterface();

            //Ajusto el nombre de la funcion al nombre externo si es necesario
            if (functionDecl.get_externalname() != "")
                functionName = functionDecl.get_externalname();

            // Si el nombre de la clase es el de la función y la función no es estática,
            // o si tanto la clase como el ns no son ficticios, imprimir el modificador de
            // acceso.
            if (functionDecl.CurrentNamespace.get_name() != UniversalMockNamespaceName ||
                functionDecl.CurrentClass.get_name() != UniversalMockClassName)
            {
                writeOut(getAccess(access, context));
            }

            // Output the comments of the method declaration.
            RenderComments(functionDecl);
            writeOut(getStorage(functionStorage, context));

            // TODO: Agregar esto a la lista de métodos en el .h
            if (isAbstract) writeOut(AbstractPC);
            if (isFinal) writeOut(FinalPC);
            if (isNew) writeOut(NewPC);
            if (isConst) AddWarning("Modificador de función 'const' no aplicado en implementacion.");
            if (isOverride) writeOut(OverridePC);
            if (isVirtual || isInterface) writeOut(VirtualPC);
            if (isFp)
            { //Declaro un delegate
                // TODO: Esto está mal, utilizar delegados requiere una implementación aparte, no una palabra reservada.
                //writeOut(DelegatePC);
                AddError("Wait for delegate implementation soon.");
            }
            if (functionName.IndexOf("%indexer%") >= 0)
            {
                functionName = functionName.Replace("%indexer%", "");
                functionName += IndexerPC;
                currentFunctionType = FunctionType.Indexer;
            }
            else if (functionName.IndexOf("%op_") >= 0)
            {
                currentFunctionType = FunctionType.Operator;
                #region Nombres de Operadores
                switch (functionName)
                {
                    case "%op_gtr%":
                        functionName = OperatorPC + ">";
                        break;
                    case "%op_lst%":
                        functionName = OperatorPC + "<";
                        break;
                    case "%op_bneg%":
                        functionName = OperatorPC + "!";
                        break;
                    case "%op_comp%":
                        functionName = OperatorPC + "~";
                        break;
                    case "%op_eq%":
                        functionName = OperatorPC + "==";
                        break;
                    case "%op_lseq%":
                        functionName = OperatorPC + "<=";
                        break;
                    case "%op_greq%":
                        functionName = OperatorPC + ">=";
                        break;
                    case "%op_noteq%":
                        functionName = OperatorPC + "!=";
                        break;
                    case "%op_and%":
                        functionName = OperatorPC + "&&";
                        break;
                    case "%op_or%":
                        functionName = OperatorPC + "||";
                        break;
                    case "%op_inc%":
                        functionName = OperatorPC + "++";
                        break;
                    case "%op_dec%":
                        functionName = OperatorPC + "--";
                        break;
                    case "%op_add%":
                        functionName = OperatorPC + "+";
                        break;
                    case "%op_min%":
                        functionName = OperatorPC + "-";
                        break;
                    case "%op_mul%":
                        functionName = OperatorPC + "*";
                        break;
                    case "%op_div%":
                        functionName = OperatorPC + "/";
                        break;
                    case "%op_band%":
                        functionName = OperatorPC + "&";
                        break;
                    case "%op_bor%":
                        functionName = OperatorPC + "|";
                        break;
                    case "%op_xor%":
                        functionName = OperatorPC + "^";
                        break;
                    case "%op_mod%":
                        functionName = OperatorPC + "%";
                        break;
                    case "%op_lsh%":
                        functionName = OperatorPC + "<<";
                        break;
                    case "%op_rsh%":
                        functionName = OperatorPC + ">>";
                        break;
                    case "%op_new%":
                        AddError("No se puede sobrecargar el operador 'new'.");
                        functionName = OperatorPC + "_new";
                        break;
                    case "%op_delete%":
                        AddError("No se puede sobrecargar el operador 'delete'.");
                        functionName = OperatorPC + "_delete";
                        break;
                    case "%op_explicit%":
                        AddWarning("Operadores de conversion no implementados en el modulo de salida.");
                        functionName = ExplicitPC + OperatorPC + "T";
                        break;
                    case "%op_implicit%":
                        AddWarning("Operadores de conversion no implementados en el modulo de salida.");
                        functionName = ImplicitPC + OperatorPC + "T";
                        break;
                    default:
                        AddError("No se pudo identificar el operador \"" + functionName + "\" utilizado.");
                        functionName = "operator_NonRecognized";
                        break;
                }
                #endregion
            }
            else
            {
                functionName = processUserTypeName(functionName);
                currentFunctionType = FunctionType.Method;
            }
            writeOut(returnTypeStr + " ");
            writeOut(functionName);
            if (currentFunctionType == FunctionType.Indexer)
                writeOut("[" + parametersStr + "]");
            else
                writeOut("(" + parametersStr + ")");
            if (baseInitializers != "") writeOut(":" + baseInitializers);

            if (isInterface) writeOut(" = 0");
            writeOut(";");

            // The header has the whole signature.
            writeNewLineOfHeader();

            if (!isAbstract && functionStorage != XplVarstorage_enum.EXTERN && functionStorage != XplVarstorage_enum.STATIC_EXTERN
                && !isInterface)
            {
                // The code file has the following: TYPE CLASS::METHOD(parameters){
                writeOut(returnTypeStr + " ");

                // If the class that contains the function is the universal mock class, ignore the class name.
                if (functionDecl.CurrentClass.get_name() != UniversalMockClassName)
                {
                    writeOut(functionDecl.CurrentClass.get_name() + ScopePC);
                }

                writeOut(functionName);

                if (currentFunctionType == FunctionType.Indexer)
                    writeOut("[" + parametersStr + "]");
                else
                    writeOut("(" + parametersStr + ")");

                writeNewLineOfCode();
                writeOut("{");
                incNLevel();
                writeNewLineOfCode();
            }

            // If the name of the function is the same as the name of the class, then
            // assume a constructor and include the call to the initializer after the
            // first line.
            if (functionName == functionDecl.CurrentClass.get_name())
            {
                atLeastOneConstructor = true;

                // Include the call to the initializer. If there is no initialization,
                // then the compiler will remove the call to the empty function.
                writeOut(InitializerMethodName + "();");
                writeNewLineOfCode();
            }

            // Should the method be static, its name be Main, and the invoke it as
            // the main function.
            if(functionStorage == XplVarstorage_enum.STATIC && functionName == "Main")
            {
                // The method is a static Main. Check for the arguments
                if(parametersStr.Trim() == "")
                {
                    // The method contains no arguments, record this call.
                    aStaticMainMethodExists = true;
                    mainMethodSignature = functionDecl.CurrentNamespace.get_name() +
                                        ScopePC + 
                                        functionDecl.CurrentClass.get_name() +
                                        ScopePC +
                                        functionName;
                }
                else
                {
                    // Check that there are two parameters: int argc, and char** argv.
                    string[] parameters = parametersStr.Split(',');
                    if(parametersStr.Length == 2)
                    {
                        string[] firstParameter = parameters[0].Split(' ');
                        string[] secondParameter = parameters[1].Split(' ');

                        if(firstParameter.Length == 2 && secondParameter.Length == 2
                            && firstParameter[0] == "int" && firstParameter[1] == "argc"
                            && secondParameter[0] == "char**" && secondParameter[1] == "argv")
                        {
                            // The method contains both correct arguments, record this call.
                            aStaticMainMethodWithArgumentsExists = true;
                            mainMethodSignature = functionDecl.CurrentNamespace.get_name() +
                                        ScopePC + 
                                        functionDecl.CurrentClass.get_name() +
                                        ScopePC +
                                        functionName;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Renders the end function.
        /// </summary>
        /// <param name="functionDecl">The function decl.</param>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="context">The context.</param>
        protected override void renderEndFunction(XplFunction functionDecl, string functionName, EZOEContext context)
        {
            bool isAbstract = functionDecl.get_abstract();
            XplVarstorage_enum functionStorage = functionDecl.get_storage();

            if (p_isExternalClass > 0 || functionStorage == XplVarstorage_enum.EXTERN || functionStorage == XplVarstorage_enum.STATIC_EXTERN) return;

            if (!isAbstract && functionStorage != XplVarstorage_enum.EXTERN && functionStorage != XplVarstorage_enum.STATIC_EXTERN
                && !(functionDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplClass && functionDecl.CurrentClass.get_isinterface()))
            {
                decNLevel();
                writeOut("} ");
                if (p_writeDetailedComments) writeComment("Final función '" + functionName + "'.");
                writeNewLineOfCode();
                writeNewLineOfCode();
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
            XplAccesstype_enum access, XplVarstorage_enum propertyStorage, bool isAbstract, bool isFinal, bool isNew, bool isConst,
            bool isOverride, bool isVirtual, EZOEContext context)
        {

            if (p_isExternalClass > 0 || propertyStorage == XplVarstorage_enum.EXTERN || propertyStorage == XplVarstorage_enum.STATIC_EXTERN) return;

            writeLineDirective(propertyDecl.get_ldsrc(), false);

            if (propertyDecl.get_externalname() != "")
                propertyName = propertyDecl.get_externalname();

            RenderComments(propertyDecl);

            //Los miembros de las interfaces son siempre publicos no se debe hacer nada
            // TODO: Considerar el reemplazo de esto por un template Property que implemente el operador =, aunque
            // de todos modos termine usando dos métodos set y get.
            if (!(propertyDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplClass && propertyDecl.CurrentClass.get_isinterface()))
                writeOut(getAccess(access, context));

            writeOut(getStorage(propertyStorage, context));

            if (isAbstract) writeOut(AbstractPC);
            if (isFinal) writeOut(FinalPC);
            if (isNew) writeOut(NewPC);
            if (isConst) AddWarning("Modificador de función 'const' no aplicado en implementacion.");
            if (isOverride) writeOut(OverridePC);
            if (isVirtual) writeOut(VirtualPC);
            // Medio feo, pero funciona.
            writeOut("@" + typeStr + "@" + processUserTypeName(propertyName));

            // The set and get must be assembled manually, so store the definition on the temporal variable.
            tempStr = p_currentLine;
            p_currentLine = string.Empty;

            //writeOut(typeStr + " " + processUserTypeName(propertyName));
            //writeNewLineOfBothFiles();

            // En el caso del archivo de cabecera, no definir la apertura.
            //writeOut("{");
            //incNLevel();
            //writeNewLineOfCode();
            //currentFunctionType = FunctionType.Property;
        }
        /// <summary>
        /// Renders the end property.
        /// </summary>
        /// <param name="propertyDecl">The property decl.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="context">The context.</param>
        protected override void renderEndProperty(XplProperty propertyDecl, string propertyName, EZOEContext context)
        {
            XplVarstorage_enum propertyStorage = propertyDecl.get_storage();
            if (p_isExternalClass > 0 || propertyStorage == XplVarstorage_enum.EXTERN || propertyStorage == XplVarstorage_enum.STATIC_EXTERN) return;

            //decNLevel();
            //writeOut("} ");
            if (p_writeDetailedComments) writeComment("Final de propiedad '" + propertyName + "'.");
            writeNewLineOfBothFiles();
            writeNewLineOfBothFiles();
        }
        /// <summary>
        /// Renders the begin get access.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="body">The body.</param>
        protected override void renderBeginGetAccess(EZOEContext context, XplFunctionBody body)
        {
            if (p_isExternalClass > 0) return;
            string[] splittedProperty = tempStr.Split(new char[] { '@' });
            writeOut(splittedProperty[0] + splittedProperty[1] + " get" + splittedProperty[1] + "()");
            if (body.Children().GetLength() != 0)
            {
                writeNewLineOfBothFiles();
                writeOut("{");
                incNLevel();
                writeNewLineOfCode();
            }

            // This is the end for the header declaration.
            writeOut(";");
            writeNewLineOfHeader();
            writeNewLineOfHeader();
        }
        /// <summary>
        /// Renders the end get access.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="body">The body.</param>
        protected override void renderEndGetAccess(EZOEContext context, XplFunctionBody body)
        {
            if (p_isExternalClass > 0) return;
            if (body.Children().GetLength() != 0)
            {
                decNLevel();
                writeOut("}");
                writeNewLineOfCode();
            }
        }
        /// <summary>
        /// Renders the begin set access.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="body">The body.</param>
        protected override void renderBeginSetAccess(EZOEContext context, XplFunctionBody body)
        {
            if (p_isExternalClass > 0) return;

            string[] splittedProperty = tempStr.Split(new char[] { '@' });
            writeOut(splittedProperty[0] + "void set" + splittedProperty[2] + "(" + splittedProperty[1] + " value)");
            if (body.Children().GetLength() != 0)
            {
                writeNewLineOfBothFiles();
                writeOut("{");
                incNLevel();
                writeNewLineOfCode();
            }
            writeOut(";");
            writeNewLineOfHeader();
            writeNewLineOfHeader();
        }
        /// <summary>
        /// Renders the end set access.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="body">The body.</param>
        protected override void renderEndSetAccess(EZOEContext context, XplFunctionBody body)
        {
            if (p_isExternalClass > 0) return;
            if (body.Children().GetLength() != 0)
            {
                decNLevel();
                writeOut("}");
                writeNewLineOfCode();
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
            XplAccesstype_enum access, XplVarstorage_enum fieldStorage, bool isNew, bool isVolatile)
        {

            if (p_isExternalClass > 0 || fieldStorage == XplVarstorage_enum.EXTERN || fieldStorage == XplVarstorage_enum.STATIC_EXTERN) return;

            if (fieldDecl.get_externalname() != "")
                fieldName = fieldDecl.get_externalname();

            writeLineDirective(fieldDecl.get_ldsrc(), false);

            if (!FieldIsFromEnum(fieldDecl))
            {
                RenderComments(fieldDecl);
                writeOut(getAccess(access, EZOEContext.ClassDecl));
                writeOut(getStorage(fieldStorage, EZOEContext.ClassBody));

                if (isNew) writeOut(NewPC);
                if (isVolatile) writeOut(VolatilePC);
                if (fieldDecl.get_type().get_const()) writeOut(ConstPC);
                writeOut(typeStr);
                
                // Check if an initializer string is employed.                
                if (initializerStr != "")
                {
                    if (initializerStr[0] != '(')
                    {
                        // Load the initialization string into the constructor initialization method.
                        currentClassConstructorInitializers.Add(fieldName + " = " + initializerStr + ";\n");
                    }
                    else
                    {
                        writeOut(initializerStr);
                    }
                }
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
            writeNewLineOfHeader();
        }
        /// <summary>
        /// Renders the begin parameters.
        /// </summary>
        /// <param name="parametersDecl">The parameters decl.</param>
        /// <param name="maxParameter">The max parameter.</param>
        /// <param name="functionDecl">The function decl.</param>
        /// <param name="context">The context.</param>
        protected override void renderBeginParameters(XplParameters parametersDecl, int maxParameter, XplFunction functionDecl, EZOEContext context)
        {
            p_maxParameter = maxParameter;
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
            bool isParams, bool isVolatile)
        {
            string retStr = "";
            switch (parameterDirection)
            {
                case XplParameterdirection_enum.IN:
                    //retStr+=InPC;
                    //como es por defecto no hago nada
                    break;
                case XplParameterdirection_enum.INOUT:
                    // Esto es la indirección.
                    // retStr += InoutPC;
                    break;
                case XplParameterdirection_enum.OUT:
                    // Esto es la indirección.
                    // retStr += OutPC;
                    break;
            }
            if (isParams) retStr += ParamsPC;
            if (isVolatile)
            {
                AddWarning("Modificador 'volatile' en parametros no soportado en el tipo implementado.");
            }
            if (parameterNumber != p_maxParameter) retStr += typeStr + ", ";
            else retStr += typeStr;
            if (initializerStr != "")
            {
                // AddError("Los parametros no pueden declarar valores por defecto en .NET.");
                retStr += " = " + initializerStr;
            }
            return retStr;
        }
        /// <summary>
        /// Renders the end parameters.
        /// </summary>
        /// <param name="parametersDecl">The parameters decl.</param>
        /// <param name="context">The context.</param>
        protected override void renderEndParameters(XplParameters parametersDecl, EZOEContext context)
        {
            p_maxParameter = 0;
        }
        /// <summary>
        /// Render a type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="declareName">Name of the declare.</param>
        /// <param name="typeContext">The type context.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderType(XplType type, string declareName, EZOETypeContext typeContext, EZOEContext context)
        {
            string typeStr = "", arrayStr = "", pointerStr = "";
            bool isValueType = false;
            typeStr += getTypeName(type, typeContext, ref isValueType);

            if (p_checkTypes) checkPointerType(type, typeContext);
            pointerStr = getPointerStr(type, typeContext, isValueType);
            if (pointerStr != "") typeStr += pointerStr;
            arrayStr = getArrayStr(type, typeContext, context, isValueType);
            switch (typeContext)
            {
                // TODO: Qué es esto.
                case EZOETypeContext.CatchVarDecl:
                case EZOETypeContext.FieldDecl:
                case EZOETypeContext.ForVarDecl:
                case EZOETypeContext.LocalVarDecl:
                case EZOETypeContext.ParameterDecl:
                    typeStr += " " + declareName;
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
            if (arrayStr != "") typeStr += arrayStr;
            return typeStr;
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
        protected override void renderBeginBlock(XplFunctionBody functionBody, EZOEContext context)
        {
            writeLineDirective(functionBody.get_ldsrc(), false);
            if (p_prettyOutput) p_lastCodeStatementLine = 0;
            if (p_prettyOutput)
            {
                //PENDIENTE : La modificación de eliminar el bloque cuando no se poseen declaraciones dentro
                //es solo para el proyecto Janus!! OJO!!
                if (context == EZOEContext.FunctionBody &&
                    functionBody.get_Parent().get_TypeName() != CodeDOMTypes.XplFunctionBody ||
                    functionBody.get_Parent().get_TypeName() == CodeDOMTypes.XplFunctionBody &&
                    functionBody.get_DeclsNodeList().GetLength() > 0)
                {
                    writeNewLineOfCode();
                    writeOut("{");
                    incNLevel();
                    writeNewLineOfCode();
                }
            }
            else
            {
                if (context == EZOEContext.FunctionBody &&
                    functionBody.get_Parent().get_TypeName() != CodeDOMTypes.XplFunctionBody ||
                    functionBody.get_Parent().get_TypeName() == CodeDOMTypes.XplFunctionBody &&
                    functionBody.get_DeclsNodeList().GetLength() > 0)
                {
                    writeNewLineOfCode();
                    writeOut("{");
                    incNLevel();
                    writeNewLineOfCode();
                }
            }
        }
        /// <summary>
        /// Renders the end block.
        /// </summary>
        /// <param name="functionBody">The function body.</param>
        /// <param name="context">The context.</param>
        protected override void renderEndBlock(XplFunctionBody functionBody, EZOEContext context)
        {
            if (p_prettyOutput)
            {
                //PENDIENTE : La modificación de eliminar el bloque cuando no se poseen declaraciones dentro
                //es solo para el proyecto Janus!! OJO!!
                if (context == EZOEContext.FunctionBody &&
                    functionBody.get_Parent().get_TypeName() != CodeDOMTypes.XplFunctionBody ||
                    functionBody.get_Parent().get_TypeName() == CodeDOMTypes.XplFunctionBody &&
                    functionBody.get_DeclsNodeList().GetLength() > 0)
                {
                    decNLevel();
                    writeOut("}");
                    writeNewLineOfCode();
                }
            }
            else
            {
                if (context == EZOEContext.FunctionBody &&
                    functionBody.get_Parent().get_TypeName() != CodeDOMTypes.XplFunctionBody ||
                    functionBody.get_Parent().get_TypeName() == CodeDOMTypes.XplFunctionBody &&
                    functionBody.get_DeclsNodeList().GetLength() > 0)
                {
                    decNLevel();
                    writeOut("}");
                    writeNewLineOfCode();
                }
            }
        }
        /// <summary>
        /// Renders the label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="context">The context.</param>
        protected override void renderLabel(XplNode label, EZOEContext context)
        {
            writeOut(label.get_StringValue() + ":");
            writeNewLineOfCode();
        }
        /// <summary>
        /// Renders the setonerror.
        /// </summary>
        /// <param name="setOnerror">The set onerror.</param>
        /// <param name="context">The context.</param>
        protected override void renderSetonerror(XplSetonerror setOnerror, EZOEContext context)
        {
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
                        writeNewLineOfBothFiles();
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
                    //es un atributo, hacerlo annotation.
                    expressionString.Replace('[', '@');
                    expressionString = expressionString.Remove(expressionString.Length - 1);
                    writeOut(expressionString);
                }
                else
                {
                    writeOut(expressionString + ";");
                }

                // Verify that the context allows the line in both the header and the file, or for only one of them.
                if (context == EZOEContext.FunctionBody)
                {
                    // Print only in the code file.
                    writeNewLineOfCode();
                }
                else
                {
                    // Print in both files.
                    writeNewLineOfBothFiles();
                }
            }
        }
        /// <summary>
        /// Updates the last statement line.
        /// </summary>
        /// <param name="node">The node.</param>
        private void UpdateLastStatementLine(XplNode node)
        {
            int minLine = 0, maxLine = 0;
            int backupLine = p_lastCodeStatementLine;
            if (!String.IsNullOrEmpty(node.get_ldsrc()))
            {
                string trashData = null;
                parseLDSRC(node.get_ldsrc(), ref minLine, ref  maxLine, ref trashData);
                if (minLine != 0)
                {
                    p_lastCodeStatementLine = minLine;
                    if (minLine > backupLine + 1 && backupLine != 0)
                    {
                        writeNewLineOfBothFiles();
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
        protected override void renderThrow(XplExpression throwExpression, string expressionString, EZOEContext context)
        {
            writeLineDirective(throwExpression.get_ldsrc(), false);
            writeOut(ThrowPC + expressionString + ";");
            writeNewLineOfCode();
        }
        /// <summary>
        /// Renders the return.
        /// </summary>
        /// <param name="returnExpression">The return expression.</param>
        /// <param name="expressionString">The expression string.</param>
        /// <param name="context">The context.</param>
        protected override void renderReturn(XplExpression returnExpression, string expressionString, EZOEContext context)
        {
            writeLineDirective(returnExpression.get_ldsrc(), false);
            if (expressionString == String.Empty)
            {
                writeOut(ReturnPC + ";");
            }
            else
            {
                writeOut(ReturnPC + " " + expressionString + ";");
            }
            writeNewLineOfCode();
        }
        /// <summary>
        /// Renders the local declarator.
        /// </summary>
        /// <param name="decl">The decl.</param>
        /// <param name="varName">Name of the var.</param>
        /// <param name="typeStr">The type STR.</param>
        /// <param name="initializerStr">The initializer STR.</param>
        /// <param name="isVolatile">if set to <c>true</c> [is volatile].</param>
        protected override void renderLocalDeclarator(XplDeclarator decl, string varName, string typeStr, string initializerStr, bool isVolatile)
        {
            writeLineDirective(decl.get_ldsrc(), false);
            if (p_prettyOutput) UpdateLastStatementLine(decl);
            RenderComments(decl);

            if (isVolatile) writeOut(VolatilePC);
            if (decl.get_type().get_const()) writeOut(ConstPC);
            writeOut(typeStr);
            if (initializerStr != "")
                if (decl.get_i().Children().FirstNode().get_ElementName() != "list" || initializerStr[0] != '(') writeOut(" = " + initializerStr);
                else writeOut(initializerStr);
            writeOut(";");
            // The local declarator is only in the header. (?)
            writeNewLineOfCode();
            decl.get_type().get_const();
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
            writeNewLineOfCode();
            writeOut("{");
            incNLevel();
            writeNewLineOfCode();
            tempStr = boolExpStr;
        }
        /// <summary>
        /// Renders the case label.
        /// </summary>
        /// <param name="caseNode">The case node.</param>
        /// <param name="caseExpStr">The case exp STR.</param>
        /// <param name="context">The context.</param>
        protected override void renderCaseLabel(XplCase caseNode, string caseExpStr, EZOEContext context)
        {
            writeLineDirective(caseNode.get_ldsrc(), false);
            if (p_isOnCase) decNLevel();
            if (caseExpStr == "")
                writeOut(DefaultPC + ":");
            else
                writeOut(CasePC + caseExpStr + ":");
            p_isOnCase = true;
            incNLevel();
            writeNewLineOfCode();
        }
        /// <summary>
        /// Renders the end switch.
        /// </summary>
        /// <param name="switchSta">The switch sta.</param>
        /// <param name="context">The context.</param>
        protected override void renderEndSwitch(XplSwitchStatement switchSta, EZOEContext context)
        {
            if (p_isOnCase) decNLevel();
            p_isOnCase = false;
            decNLevel();
            writeOut("} ");
            writeNewLineOfCode();
            if (p_writeDetailedComments) writeComment("Fin Switch '" + tempStr + "'");
        }
        /// <summary>
        /// Renders if statement.
        /// </summary>
        /// <param name="ifSta">If sta.</param>
        /// <param name="boolExp">The bool exp.</param>
        /// <param name="isElse">if set to <c>true</c> [is else].</param>
        /// <param name="context">The context.</param>
        protected override void renderIfStatement(XplIfStatement ifSta, string boolExp, bool isElse, EZOEContext context)
        {
            writeLineDirective(ifSta.get_ldsrc(), false);
            if (p_prettyOutput) UpdateLastStatementLine(ifSta);
            if (!isElse)
            {
                writeOut(IfPC + "(" + boolExp + ")");
            }
            else
            {
                writeOut(ElsePC + IfPC + "(" + boolExp + ")");
            }
        }
        /// <summary>
        /// Renders the else statement.
        /// </summary>
        /// <param name="ifSta">If sta.</param>
        /// <param name="elseBody">The else body.</param>
        /// <param name="context">The context.</param>
        protected override void renderElseStatement(XplIfStatement ifSta, XplFunctionBody elseBody, EZOEContext context)
        {
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
        protected override void renderForStatement(XplForStatement forSta, string initStr, string boolExpStr, string updateStr, EZOEContext context)
        {
            writeLineDirective(forSta.get_ldsrc(), false);
            if (p_prettyOutput) UpdateLastStatementLine(forSta);
            if (updateStr == "_FOR_EACH_")
            {
                // Exchange the foreach to a for equivalent, for now, it depends on indentation.
                // foreach(initStr in boolExpStr) ==> (Assuming initStr = type + name) ==>
                // type::const_iterator name;
                // for(name=boolExpStr.rbegin(); name!=boolExpStr.rend(); ++name)
                AddWarning("Foreach for-replacement only for stl structures.");

                string trimmed = initStr.Trim();
                string type = trimmed.Remove(trimmed.IndexOf(' '));
                string name = trimmed.Substring(trimmed.IndexOf(' ') + 1, trimmed.Length - trimmed.IndexOf(' ') - 1);

                writeOut(type + "::const_iterator " + name + ";");
                writeNewLineOfCode();
                writeOut(ForPC + "(" + name + "=" + boolExpStr + ".rbegin(); " + name + "!=" + boolExpStr + ".rend(); ++" + name + ")");
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
        protected override string renderForDeclaration(XplDeclaratorlist decls, EZOEContext context)
        {
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
        protected override void renderWhileStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context)
        {
            writeLineDirective(doSta.get_ldsrc(), false);
            writeOut(WhilePC + "(" + boolExpStr + ")");
        }
        /// <summary>
        /// Renders the begin do statement.
        /// </summary>
        /// <param name="doSta">The do sta.</param>
        /// <param name="boolExpStr">The bool exp STR.</param>
        /// <param name="context">The context.</param>
        protected override void renderBeginDoStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context)
        {
            writeLineDirective(doSta.get_ldsrc(), false);
            writeOut(DoPC);
        }
        /// <summary>
        /// Renders the end do statement.
        /// </summary>
        /// <param name="doSta">The do sta.</param>
        /// <param name="boolExpStr">The bool exp STR.</param>
        /// <param name="context">The context.</param>
        protected override void renderEndDoStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context)
        {
            writeLineDirective(doSta.get_ldsrc(), true);
            writeOut(WhilePC + "(" + boolExpStr + ");");
            writeNewLineOfCode();
        }
        /// <summary>
        /// Renders the begin try.
        /// </summary>
        /// <param name="trySta">The try sta.</param>
        /// <param name="context">The context.</param>
        protected override void renderBeginTry(XplTryStatement trySta, EZOEContext context)
        {
            writeLineDirective(trySta.get_ldsrc(), false);
            if (p_prettyOutput) UpdateLastStatementLine(trySta);
            writeOut(TryPC);
        }
        /// <summary>
        /// Renders the end try.
        /// </summary>
        /// <param name="trySta">The try sta.</param>
        /// <param name="context">The context.</param>
        protected override void renderEndTry(XplTryStatement trySta, EZOEContext context)
        {
            writeNewLineOfCode();
        }
        /// <summary>
        /// Renders the catch statement.
        /// </summary>
        /// <param name="catchSta">The catch sta.</param>
        /// <param name="declExp">The decl exp.</param>
        /// <param name="context">The context.</param>
        protected override void renderCatchStatement(XplCatchStatement catchSta, string declExp, EZOEContext context)
        {
            writeLineDirective(catchSta.get_ldsrc(), false);
            writeOut(CatchPC + "(" + declExp + ")");
        }
        /// <summary>
        /// Renders the finally.
        /// </summary>
        /// <param name="tryBk">The try bk.</param>
        /// <param name="context">The context.</param>
        protected override void renderFinally(XplFunctionBody tryBk, EZOEContext context)
        {
            writeLineDirective(tryBk.get_ldsrc(), false);
            writeOut(FinallyPC);
        }
        /// <summary>
        /// Renders the break.
        /// </summary>
        /// <param name="jump">The jump.</param>
        /// <param name="context">The context.</param>
        protected override void renderBreak(XplJump jump, EZOEContext context)
        {
            writeLineDirective(jump.get_ldsrc(), false);
            writeOut(BreakPC + ";");
            writeNewLineOfCode();
        }
        /// <summary>
        /// Renders the continue.
        /// </summary>
        /// <param name="jump">The jump.</param>
        /// <param name="context">The context.</param>
        protected override void renderContinue(XplJump jump, EZOEContext context)
        {
            writeLineDirective(jump.get_ldsrc(), false);
            writeOut(ContinuePC + ";");
            writeNewLineOfCode();
        }
        /// <summary>
        /// Renders the goto.
        /// </summary>
        /// <param name="jump">The jump.</param>
        /// <param name="label">The label.</param>
        /// <param name="context">The context.</param>
        protected override void renderGoto(XplJump jump, string label, EZOEContext context)
        {
            writeLineDirective(jump.get_ldsrc(), false);
            writeOut(GotoPC + label + ";");
            writeNewLineOfCode();
        }

        /// <summary>
        /// Renders the resume.
        /// </summary>
        /// <param name="jump">The jump.</param>
        /// <param name="context">The context.</param>
        protected override void renderResume(XplJump jump, EZOEContext context)
        {
            AddError("Instrucción 'resume' no soportada por el Modulo de Salida.");
        }
        /// <summary>
        /// Renders the resume next.
        /// </summary>
        /// <param name="jump">The jump.</param>
        /// <param name="context">The context.</param>
        protected override void renderResumeNext(XplJump jump, EZOEContext context)
        {
            AddError("Instrucción 'resume next' no soportada por el Modulo de Salida.");
        }
        /// <summary>
        /// Renders the direct output.
        /// </summary>
        /// <param name="directOutput">The direct output.</param>
        /// <param name="outputStr">The output STR.</param>
        /// <param name="context">The context.</param>
        protected override void renderDirectOutput(XplDirectoutput directOutput, string outputStr, EZOEContext context)
        {
            AddWarning("renderDirectOutput: no implementado en Modulo de Salida.");
        }
        /// <summary>
        /// Renders the onpointer statement.
        /// </summary>
        /// <param name="functionBody">The function body.</param>
        /// <param name="context">The context.</param>
        protected override void renderOnpointerStatement(XplFunctionBody functionBody, EZOEContext context)
        {
            AddError("Instrucción 'onpointer' no soportada por el Modulo de Salida.");
        }
        #endregion

        #region Expresiones
        /// <summary>
        /// Render a get type exp.
        /// </summary>
        /// <param name="xplType">Type of the XPL.</param>
        /// <param name="typeStr">The type STR.</param>
        /// <param name="EZOEContext">The e XPL context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderGetTypeExp(XplType xplType, string typeStr, ExtendedZOEProcessor.EZOEContext EZOEContext)
        {
            AddWarning("The typeof operator is an extension and is not part of the standard, although many compilers implement it.");
            return "typeof( " + typeStr + " )";
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
            if (initializerStr == "" && newExp.get_type().get_typename() != "" && newExp.get_type().get_typename()[0] != '$')
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
        protected override string renderExpressionListItem(XplExpression expNode, string expStr, int expNumber, int expCount, EZOEContext context)
        {
            if (expNumber != expCount) return expStr + ", ";
            else return expStr;
        }
        /// <summary>
        /// Render a end expression list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderEndExpressionList(XplExpressionlist list, EZOEContext context)
        {
            return "";
        }
        /// <summary>
        /// Render a simple name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderSimpleName(string name, EZOEContext context)
        {
            //Simplemente asumo que todo es correcto y debo reemplazar "::" por "."
            return processUserTypeName(name);
        }
        /// <summary>
        /// Render a literal.
        /// </summary>
        /// <param name="litNode">The lit node.</param>
        /// <param name="litStr">The lit STR.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderLiteral(XplLiteral litNode, string litStr, EZOEContext context)
        {
            #region Switch de Tipos de Literal
            switch (litNode.get_type())
            {
                case XplLiteraltype_enum.NULL:
                    tempStr = "NULL";
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
                    tempStr = litStr.EndsWith("f") ? litStr.Substring(0, litStr.Length-1) : litStr;
                    break;
                case XplLiteraltype_enum.DATETIME:
                case XplLiteraltype_enum.ASCIISTRING:
                case XplLiteraltype_enum.STRING:
                    tempStr = "\"" + litStr + "\"";
                    break;
                case XplLiteraltype_enum.OTHER:
                    AddWarning("Literal de tipo 'OTHER' traducida como literal de cadena.");
                    tempStr = "\"" + litStr + "\"";
                    break;
                case XplLiteraltype_enum.UUID:
                    AddWarning("Literal de tipo 'UUID' traducida como literal de cadena.");
                    tempStr = "\"" + litStr + "\"";
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
        protected override string renderDeleteExp(XplExpression deleteExp, string expStr, EZOEContext context)
        {
            return DeletePC + expStr;
        }
        /// <summary>
        /// Render a onpointer exp.
        /// </summary>
        /// <param name="onpointerExp">The onpointer exp.</param>
        /// <param name="expStr">The exp STR.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderOnpointerExp(XplExpression onpointerExp, string expStr, EZOEContext context)
        {
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
        protected override string renderAssingExp(XplAssing assing, string leftExpStr, string rightExpStr, XplAssingop_enum operation, EZOEContext context)
        {
            if (p_OptimiseParenthesis && (int)Precedences.AssingExp == getExpressionPrecedence(assing.get_l()))
            {
                leftExpStr = "(" + leftExpStr + ")";
            }
            #region Switch de Operadores de Asignación
            switch (operation)
            {
                case XplAssingop_enum.ADD:
                    tempStr = leftExpStr + " += " + rightExpStr;
                    break;
                case XplAssingop_enum.AND:
                    tempStr = leftExpStr + " &= " + rightExpStr;
                    break;
                case XplAssingop_enum.DIV:
                    tempStr = leftExpStr + " /= " + rightExpStr;
                    break;
                case XplAssingop_enum.LSH:
                    tempStr = leftExpStr + " <<= " + rightExpStr;
                    break;
                case XplAssingop_enum.MOD:
                    tempStr = leftExpStr + " %= " + rightExpStr;
                    break;
                case XplAssingop_enum.MUL:
                    tempStr = leftExpStr + " *= " + rightExpStr;
                    break;
                case XplAssingop_enum.NONE:
                    tempStr = leftExpStr + " = " + rightExpStr;
                    break;
                case XplAssingop_enum.OR:
                    tempStr = leftExpStr + " |= " + rightExpStr;
                    break;
                case XplAssingop_enum.RSH:
                    tempStr = leftExpStr + " >>= " + rightExpStr;
                    break;
                case XplAssingop_enum.SUB:
                    tempStr = leftExpStr + " -= " + rightExpStr;
                    break;
                case XplAssingop_enum.XOR:
                    tempStr = leftExpStr + " ^= " + rightExpStr;
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
        protected override string renderBinOpExp(XplBinaryoperator bopExp, string leftExpStr, string rightExpStr, XplBinaryoperators_enum op, EZOEContext context)
        {
            switch (op)
            {
                case XplBinaryoperators_enum.IMP: //Flecha "=>"
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
            switch (op)
            {
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
                    if(leftExpStr=="this")
                        tempStr = leftExpStr + "->" + rightExpStr;
                    else
                        tempStr = leftExpStr + "." + rightExpStr;
                    flag = true;
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
                    tempStr = leftExpStr + "->*" + rightExpStr; flag = true;
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
            if (p_OptimiseParenthesis)
            {
                if (!flag && requireParenthesis(bopExp)) tempStr = "(" + tempStr + ")";
            }
            else
                if (!flag) tempStr = "(" + tempStr + ")";
            return tempStr;
        }
        /// <summary>
        /// Render a un op exp.
        /// </summary>
        /// <param name="uopExp">The uop exp.</param>
        /// <param name="expStr">The exp STR.</param>
        /// <param name="op">The op.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderUnOpExp(XplUnaryoperator uopExp, string expStr, XplUnaryoperators_enum op, EZOEContext context)
        {
            #region Switch de Operadores Unarios
            switch (op)
            {
                case XplUnaryoperators_enum.AOF: //Address of '&'
                    if (!p_isUnsafeContext) AddWarning("Operador 'Address of' usado en posible contexto no seguro, posible error.");
                    XplExpression parentExp = (XplExpression)uopExp.get_Parent();
                    if (!parentExp.get_typeStr().Contains("/")) tempStr = "&" + expStr;
                    else tempStr = expStr;
                    break;
                case XplUnaryoperators_enum.DEC: //Decremento postfijo 'e--'
                    tempStr = expStr + "--";
                    break;
                case XplUnaryoperators_enum.INC: //Incremento postfijo 'e++'
                    tempStr = expStr + "++";
                    break;
                case XplUnaryoperators_enum.IND: //Indireccion de puntero '*'
                    if (!p_isUnsafeContext) AddWarning("Operador 'Indirección de Puntero' ('*') usado en posible contexto no seguro, posible error.");
                    tempStr = "*" + expStr;
                    break;
                case XplUnaryoperators_enum.MIN: //Negativo '-'
                    tempStr = "-" + expStr;
                    break;
                case XplUnaryoperators_enum.NOT: //Negado logico '!'
                    tempStr = "!" + expStr;
                    break;
                case XplUnaryoperators_enum.ONECOMP: //Complemento a Uno '~'
                    tempStr = "~" + expStr;
                    break;
                case XplUnaryoperators_enum.PREDEC: //Decremento prefijo '--e'
                    tempStr = "--" + expStr;
                    break;
                case XplUnaryoperators_enum.PREINC: //Incremento prefijo '++e'
                    tempStr = "++" + expStr;
                    break;
                case XplUnaryoperators_enum.RAOF: //Reference AddressOf '&&'
                    AddError("Operador unario 'Dirección de Referencia' ('&&') no soportado por el Modulo de Salida.");
                    tempStr = "&" + expStr;
                    break;
                case XplUnaryoperators_enum.SIZEOF:
                    AddWarning("Operador unario 'Tamaño de' ('sizeof') no soportado completamente por el Modulo de Salida. Sólo valido para tipos por valor y referenciando el tipo no una expresión.");
                    tempStr = "sizeof(" + expStr + ")";
                    break;
                case XplUnaryoperators_enum.TYPEOF:
                    AddWarning("Operador unario 'Tipo de' ('typeof') posiblemente no implementado correctamente por el Modulo de Salida. Se requiere un tipo, no una expresión.");
                    tempStr = "typeof(" + expStr + ")";
                    break;
            }
            #endregion
            if (p_OptimiseParenthesis)
            {
                if (requireParenthesis(uopExp)) tempStr = "(" + tempStr + ")";
            }
            else tempStr = "(" + tempStr + ")";
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
        protected override string renderFunctionCallExp(XplFunctioncall fcallExp, string leftExpStr, string argsStr, bool useBrackets, EZOEContext context)
        {
            // PENDIENTE : eliminar esto cuando se implemente correctamente el tema de atributos en Zoe
            if (leftExpStr == "Zoe.Attribute.Add")
            {
                AddWarning("The support for attributes in methods is still not fully implemented. Assuming [${Attribute}]class, not class __atribute__((${Attribute}))");
                return "[" + argsStr.Substring(1, argsStr.Length - 2).Replace("\\\"", "\"") + "]";
            }

            string internalName = fcallExp.get_targetMember();
            if (fcallExp.get_targetMemberExternalName() != "")
            {
                // Debo modificar el leftExpStr.
                int indexDot = leftExpStr.LastIndexOf('.');
                int indexPrecedence = leftExpStr.LastIndexOf(ScopePC);
                int index = Math.Max(indexDot, indexPrecedence);

                if (index > 0)
                {
                    // La expresion izquierda es un acceso a miembro. Chequear si corresponde a la mock class,
                    // en cuyo caso, obviar la inserción del nombre de expresión del lado izquierdo.
                    if (leftExpStr.Substring(0, index) != "MockClass")
                    {
                        leftExpStr = leftExpStr.Substring(0, index) + ScopePC + fcallExp.get_targetMemberExternalName();
                    }
                    else
                    {
                        leftExpStr = fcallExp.get_targetMemberExternalName();
                    }
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

            if (!useBrackets)
            {
                return leftExpStr + "(" + argsStr + ")";
            }
            else
            {
                return leftExpStr + "[" + argsStr + "]";
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
        protected override string renderCastExp(XplCastexpression castExp, string typeStr, string castExpStr, XplCasttype_enum castType, EZOEContext context)
        {
            tempStr = "(" + typeStr + ")" + castExpStr;
            tempStr = "(" + tempStr + ")"; //Cuidado con esto al corregir lo superior
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
        #endregion

        #region Documentacion, UnrecognizedNode y Otros
        /// <summary>
        /// Renders the documentation.
        /// </summary>
        /// <param name="documentation">The documentation.</param>
        /// <param name="context">The context.</param>
        protected override void renderDocumentation(XplDocumentation documentation, EZOEContext context)
        {
            if (documentation != null)
            {
                string docStr = documentation.get_short();
                if (!String.IsNullOrEmpty(docStr))
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
                    for (int n = 0; n < comments.Length; n++)
                    {
                        string comment = comments[n].Replace('\r', ' ').Trim();
                        if (comment != String.Empty)
                        {
                            if (mainComment)
                                writeOut("// " + comment);
                            else
                                writeOut("// " + comment);
                            
                            if(documentation.CurrentBlock==null)
                                writeNewLineOfHeader();
                            else
                                writeNewLineOfCode();
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
        protected override void renderUnrecognizedNode(XplNode node, EZOEContext context)
        {
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
        public bool OptimiseParenthesis
        {
            get { return p_OptimiseParenthesis; }
            set { p_OptimiseParenthesis = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [check types].
        /// </summary>
        /// <value><c>true</c> if [check types]; otherwise, <c>false</c>.</value>
        public bool CheckTypes
        {
            get { return p_checkTypes; }
            set { p_checkTypes = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [dont write copyright comment].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [dont write copyright comment]; otherwise, <c>false</c>.
        /// </value>
        public bool DontWriteCopyrightComment
        {
            get { return p_dontWriteCopyrightComment; }
            set { p_dontWriteCopyrightComment = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [write detailed comments].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [write detailed comments]; otherwise, <c>false</c>.
        /// </value>
        public bool WriteDetailedComments
        {
            get { return p_writeDetailedComments; }
            set { p_writeDetailedComments = value; }
        }
        /// <summary>
        /// Gets or sets the name of the output file.
        /// </summary>
        /// <value>The name of the output file.</value>
        public string OutputFileName
        {
            get { return p_outputFileName; }
            set { p_outputFileName = value; p_newFilePerClass = false; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [new file per class].
        /// </summary>
        /// <value><c>true</c> if [new file per class]; otherwise, <c>false</c>.</value>
        public bool NewFilePerClass
        {
            get { return p_newFilePerClass; }
            set { p_newFilePerClass = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [apply format].
        /// </summary>
        /// <value><c>true</c> if [apply format]; otherwise, <c>false</c>.</value>
        public bool ApplyFormat
        {
            get { return p_applyFormat; }
            set { p_applyFormat = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [build full types].
        /// </summary>
        /// <value><c>true</c> if [build full types]; otherwise, <c>false</c>.</value>
        public bool BuildFullTypes
        {
            get { return p_buildFullType; }
            set { p_buildFullType = value; }
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
        /// <param name="EXPLInputFileName">Name of the EXPL input file.</param>
        public void SetEZOEInputFileName(string EXPLInputFileName)
        {
            p_inputFileName = EXPLInputFileName;
        }
        /// <summary>
        /// Sets the EZOE input document.
        /// </summary>
        /// <param name="EXPLInputDocument">The EXPL input document.</param>
        public void SetEZOEInputDocument(XplDocument EXPLInputDocument)
        {
            p_XplDocument = EXPLInputDocument;
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
            string outputFolder = Path.GetFullPath(Path.Combine(p_outputPath, classInfo.Namespace));
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }
            string outputCodeFile = Path.Combine(outputFolder, classInfo.ClassName + ".cpp");
            string outputHeaderFile = Path.Combine(outputFolder, classInfo.ClassName + ".h");

            StreamWriter currentCodeWriter = null;
            StreamWriter currentHeaderWriter = null;
            try
            {
                currentCodeWriter = new StreamWriter(outputCodeFile, false, p_outputEncoding);
                currentHeaderWriter = new StreamWriter(outputHeaderFile, false, p_outputEncoding);

                // TODO : check this for C++, this code was inherited from C# code generator!!!
                foreach (string usingStr in classInfo.Usings.Keys)
                {
                    string usingStr2 = usingStr;
                    if (usingStr2.StartsWith(p_namespaceToRemove)) usingStr2 = usingStr2.Substring(p_namespaceToRemove.Length + 1);
                    {
                        currentCodeWriter.WriteLine(IncludePC + usingStr2 + ";");
                        currentHeaderWriter.WriteLine(IncludePC + usingStr2 + ";");
                    }
                }

                // Copy the code lines.
                currentCodeWriter.WriteLine();
                currentCodeWriter.WriteLine(NamespacePC + classInfo.Namespace);
                currentCodeWriter.WriteLine("{");
                currentCodeWriter.WriteLine();

                for (int n = classInfo.FirstLine; n < classInfo.LastLine; n++)
                {
                    currentCodeWriter.WriteLine(p_currentCodeFileLines[n]);
                }
                currentCodeWriter.WriteLine();
                currentCodeWriter.WriteLine("}");
                currentCodeWriter.WriteLine();

                // Copy the header lines.
                currentHeaderWriter.WriteLine();
                currentHeaderWriter.WriteLine(NamespacePC + classInfo.Namespace);
                currentHeaderWriter.WriteLine("{");
                currentHeaderWriter.WriteLine();

                for (int n = classInfo.FirstLine; n < classInfo.LastLine; n++)
                {
                    currentHeaderWriter.WriteLine(p_currentHeaderFileLines[n]);
                }
                currentHeaderWriter.WriteLine();
                currentHeaderWriter.WriteLine("}");
                currentHeaderWriter.WriteLine();
            }
            catch (IOException ioError)
            {
                AddWarning("IO Error while saving intermediate files. " + ioError.Message);
            }
            finally
            {
                if (currentCodeWriter != null) currentCodeWriter.Close();
                if (currentHeaderWriter != null) currentHeaderWriter.Close();
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
                string outputCodeFileName = getCodeFileVersion(outputFileName);
                string outputHeaderFileName = getHeaderFileVersion(outputFileName);

                // Render the code file.
                currentCodeWriter = new StreamWriter(outputCodeFileName, false, p_outputEncoding);
                foreach (string line in p_currentCodeFileLines)
                    currentCodeWriter.WriteLine(line);
                if (currentCodeWriter != null) currentCodeWriter.Close();

                // Render the header file.
                currentHeaderWriter = new StreamWriter(outputHeaderFileName, false, p_outputEncoding);
                foreach (string line in p_currentHeaderFileLines)
                    currentHeaderWriter.WriteLine(line);
                if (currentHeaderWriter != null) currentHeaderWriter.Close();
            }
            catch (IOException ioError)
            {
                AddWarning("IO Error while saving intermediate files. " + ioError.Message);
                return false;
            }
            return true;
        }

        #region Construccion de Modulos
        bool p_compileInMemory;

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
            try
            {
                XplLayerDZoeProgramConfig config = null;
                string buildCommand = string.Empty;
                if (p_XplDocument.get_DocumentData().get_Config() != null)
                {
                    config = (XplLayerDZoeProgramConfig)p_XplDocument.get_DocumentData().get_Config().get_Content();
                    switch (config.get_moduleType())
                    {
                        case XplLayerDZoeProgramModuletype_enum.EXECUTABLE:
                            buildCommand = "gcc.exe";
                            break;
                        case XplLayerDZoeProgramModuletype_enum.DYNAMIC_LIB:
                            buildCommand = "ld.exe";
                            break;
                        case XplLayerDZoeProgramModuletype_enum.STATIC_LIB:
                            // For the moment, don't diferentiate static from dynamic linking.
                            buildCommand = "ar.exe";
                            break;
                        case XplLayerDZoeProgramModuletype_enum.SCRIPT:
                        case XplLayerDZoeProgramModuletype_enum.OTHER:
                        default:
                            AddError("Program Module Type not supported by C++ Output Module.");
                            break;
                    }
                }

                Process compilerProcess = new Process();
                compilerProcess.StartInfo = new ProcessStartInfo(buildCommand, buildArguments);
                compilerProcess.StartInfo.RedirectStandardOutput = true;
                compilerProcess.StartInfo.RedirectStandardError = true;
                compilerProcess.StartInfo.UseShellExecute = false;
                compilerProcess.EnableRaisingEvents = false;
                compilerProcess.Start();
                compilerProcess.WaitForExit();

                if (compilerProcess.ExitCode != 0)
                {
                    AddError(compilerProcess.StandardError.ReadToEnd());
                }

                return (compilerProcess.ExitCode == 0);
            }
            catch (Exception e)
            {
                AddError("An error has occurred while compiling the file: " + e.Message);
            }
            return false;
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
        /// <param name="EXPLOutputFileName">Name of the EXPL output file.</param>
        public void SetOutputFileName(string EXPLOutputFileName)
        {
            p_outputFileName = EXPLOutputFileName;
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
        /// <param name="xplExpression">The XPL expression.</param>
        /// <returns>A String value.</returns>
        public string RenderExpression(XplExpression xplExpression)
        {
            return processExpression(xplExpression, EZOEContext.FunctionBody);
        }

        /// <summary>
        /// Renders the using directive.
        /// </summary>
        /// <param name="xplName">Name of the XPL.</param>
        /// <param name="EZOEContext">The e XPL context.</param>
        protected override void renderUsingDirective(XplName xplName, ExtendedZOEProcessor.EZOEContext EZOEContext)
        {
            writeLineDirective(xplName.get_ldsrc(), false);

            // TODO : implement this for C++ | using namesace fullname;
            //if (p_prettyOutput)
            //{
            //    string usingStr = xplName.Children().FirstNode().get_StringValue();
            //    if (usingStr.StartsWith(p_namespaceToRemove))
            //    {
            //        usingStr = usingStr.Replace("::", ".");
            //        if (p_namespaceToRemove != "" && usingStr.StartsWith(p_namespaceToRemove))
            //            usingStr = usingStr.Remove(0, p_namespaceToRemove.Length + 1);

            //        if (!p_includes.ContainsValue(usingStr))
            //        {
            //            p_includes.Add(usingStr.Length + Convert.ToSingle("." + p_includes.Count.ToString(NumberFormatInfo.InvariantInfo), NumberFormatInfo.InvariantInfo), usingStr);
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Render a writecode expression.
        /// </summary>
        /// <param name="xplExpression">The XPL expression.</param>
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
        /// <param name="xplWriteCodeBody">The XPL write code body.</param>
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
        /// <param name="EZOEContext">The e XPL context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderTypeOfExp(XplType typeofExpNode, string typeStr, ExtendedZOEProcessor.EZOEContext EZOEContext)
        {
            return "typeof( " + typeStr + " )";
        }

        /// <summary>
        /// Render a is exp.
        /// </summary>
        /// <param name="xplExpression">The XPL expression.</param>
        /// <param name="expStr">The exp STR.</param>
        /// <param name="typeStr">The type STR.</param>
        /// <param name="EZOEContext">The e XPL context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderIsExp(XplCastexpression xplExpression, string expStr, string typeStr, ExtendedZOEProcessor.EZOEContext EZOEContext)
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
        
        /// <summary>
        /// Prints an enveloping function to be called at the starting of the program.
        /// </summary>
        /// <param name="localMainInvocation">A single method signature, with no parenthesis.</param>
        private void renderIntMainFunction(string localMainInvocation)
        {
            // Print a line of comment on the main method.
            writeComment("This method is given to run any class that is named Main and has a main method.");
            writeNewLineOfBothFiles();

            // Print the header prototype.
            writeOut("int main();");
            writeNewLineOfHeader();

            // Print the code.
            writeOut("int main(){ " + localMainInvocation  + "(); " + ReturnPC + " 0; }");
            writeNewLineOfCode();
        }

        /// <summary>
        /// Prints an enveloping function to be called at the starting of the program.
        /// </summary>
        /// <param name="localMainInvocation">A single method signature, with no parenthesis.</param>
        private void renderIntMainFunctionWithParameters(string localMainInvocation)
        {
            // Print a line of comment on the main method.
            writeComment("This method is given to run any class that is named Main and has a main method.");
            writeNewLineOfBothFiles();

            // Print the header prototype.
            writeOut("int main(int argc, char** argv);");
            writeNewLineOfHeader();

            // Print the code.
            writeOut("int main(int argc, char** argv){ " + localMainInvocation + "(argc,argv); " + ReturnPC + " 0; }");
            writeNewLineOfCode();
        }
    }
}