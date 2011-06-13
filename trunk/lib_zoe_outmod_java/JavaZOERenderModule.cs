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
using LayerD.CodeDOM;
using System.Diagnostics;
using System.Collections;
using LayerD.ZOECompiler;

///Modificaciones Necesarias para Procesar Throws
///.
///¿Que nos hace falta para procesar los throws?
///.
///- Listado de Todas las Funciones del programa con:
///         - Dependencias con otras funciones (para llamadas q no estan dentro de un try)
///         - Lugar en el ArrayList y el ZoeInfoClass donde comienza la funcion (o sea linea de declaracion)
///     Por tanto la estructura tendria q tener algo como:
///         class InfoFuncion{
///             string NombreFuncionCompleto;
///             ZoeInfoClass InfoClass;
///             int IndiceDeclaracion;
///             HashTable Dependencias;
///             //Adentro de la dependencia tendria:
///             //Clave: NombreCompleto de la funcion de la cual depende
///             //Valor: No hace falta mucho
///         }
///         
namespace LayerD.OutputModules
{
    /// <summary>
    /// JavaZOEOutputModule:
    /// 
    /// Modulo de Salida ZOE a código Java 2.
    /// Extiende la clase abstracta ExtendedZOEProcessor e implementa
    /// las funciones de renderización de elementos.
    /// </summary>
    public class JavaZOERenderModule : ExtendedZOEProcessor, IEZOERender
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
        #endregion

        #region Constants
        const string STATIC_JAVA_CLASS = "%STATIC_JAVA_CLASS%";
        const string PackagePC = "package ";
        const string NamespacePC = "namespace ";
        const string DefaultPC = "default ";
        const string UsingPC = "using ";
        const string ImportPC = "import ";//"Import"
        const string ClassPC = "class ";
        const string EnumPC = "enum ";
        const string StructPC = "struct "; //<-- No va en Java
        const string InterfacePC = "interface ";
        const string AbstractPC = "abstract ";
        const string FinalPC = "final "; //<-- "final" en Java
        const string NewPC = "new ";
        const string VolatilePC = "volatile ";
        const string ConstPC = "final "; //<-- me parece que no va, es "final"
        const string PrivatePC = "private ";
        const string ProtectedPC = "protected ";
        const string PublicPC = "public ";
        const string InternalPC = ""; //<-- me parece que tampoco tiene un equivalente en Java
        const string IndexerPC = "this ";
        const string DelegatePC = "delegate ";
        const string ExplicitPC = "explicit ";
        const string ImplicitPC = "implicit ";
        const string OperatorPC = "operator ";
        const string VirtualPC = "virtual ";
        const string ReturnPC = "return ";
        const string OverridePC = "override ";
        //const string IndexerPC = "this ";
        const string ParamsPC = "param ";
        const string InPC = "in ";
        const string InoutPC = "ref ";
        const string OutPC = "out ";
        const string GotoPC = "goto ";
        const string ThrowPC = "throw ";
        const string SwitchPC = "switch ";
        const string BreakPC = "break ";
        const string CatchPC = "catch ";
        const string ContinuePC = "continue ";
        const string FinallyPC = "finally ";
        const string TryPC = "try ";
        const string DoPC = "do ";
        const string WhilePC = "while ";
        const string DeletePC = "delete ";
        const string CasePC = "case ";
        const string ElsePC = "else ";
        const string ForPC = "for ";
        const string IfPC = "if ";
        const string ExternPC = ""; //<-- "native" o algo asi en Java
        const string StaticPC = "static ";
        //de Java para herencia e implementacion
        const string ExtendsPC = "extends ";
        const string ImplementsPC = "implements ";
        #endregion

        #region Datos Privados o Protegidos
        string p_outputFileName = "";
        string p_currentOutputDirectory = "";
        bool p_dontWriteCopyrightComment = false;
        bool p_writeDetailedComments = false;
        bool p_isUnsafeContext = false;
        bool p_applyFormat = true;
        bool p_checkTypes = true;
        bool p_newLineFlag = true;
        bool p_optimiseParenthesis = true;
        bool p_buildFullType = false;
        bool p_isDebugMode;
        string p_currentDocumentImportStr = "";
        string p_currentPackage = "";
        string p_currentClass = "";

        XplLayerDZoeProgramModuletype_enum p_outputModuleType = XplLayerDZoeProgramModuletype_enum.EXECUTABLE;

        ErrorCollection p_errors = new ErrorCollection();

        //Array a guardar las lineas de cada archivo
        ArrayList p_lineas = new ArrayList();
        ArrayList p_listInfoClase;
        ArrayList p_listInfoFuncion;
        ZoeInfoclase p_infoClaseActual;
        InfoFuncion p_infoFuncionActual;

        TextWriter p_currentWriter = null;
        System.Text.Encoding p_outputEncoding = System.Text.Encoding.UTF8;
        int p_nestingLevel = 0;
        int p_maxParameter = 0;
        int p_cuentaClases = 0;
        string p_tabString = "";
        string p_namespaceToRemove = "";
        string p_currentLine = "";//Linea actual guardada 
        FunctionType currentFunctionType = FunctionType.Method;
        /// Variables para el seguimiento de archivo y linea
        int p_currentRealLine = 0;
        /// Cadena para trabajo temporario
        string tempStr = "";
        //tabla hash de tipos nativos a procesar
        static Hashtable p_nativeTypes = null;
        int p_isExternalClass;

        #endregion

        #region Constructores
        static JavaZOERenderModule(){
            p_nativeTypes = new Hashtable();
            InitializeNativeTypes();
        }

        private class NativeTypesStr
        {
            public static string String = "zoe.lang.String";
            public static string String2 = "$STRING$";
            public static string Object = "zoe.lang.Object";
            public static string Object2 = "$OBJECT$";
        }
        private static void InitializeNativeTypes()
        {
            // PENDIENTE : completar esta lista
            p_nativeTypes.Add(NativeTypesStr.String, String.Empty);
            p_nativeTypes.Add(NativeTypesStr.String2, String.Empty);
            p_nativeTypes.Add(NativeTypesStr.Object, String.Empty);
            p_nativeTypes.Add(NativeTypesStr.Object2, String.Empty);

        }

        public JavaZOERenderModule()
            : base()
        {
        }
        public JavaZOERenderModule(string inputFileName)
            : base(inputFileName)
        {
        }
        public JavaZOERenderModule(string inputFileName, string outputFileName)
            : base(inputFileName)
        {
            p_outputFileName = outputFileName;
        }
        #endregion

        #region Miembros Privados Utilitarios

        #region PrepareOutput, CloseOutput, writeOut, writeNewLine, incNlevel, decNlevel, writeLineDirective
        private void writeLineDirective(string ldsrc, bool isMaxLine)
        {
            ///En java no sirve!!!
            return;

            /*
            ///Debo parsear ldsrc para obtener las lineas y los archivos origen
            int minLine = 0, maxLine = 0;
            string currentFile = "";
            parseLDSRC(ldsrc, ref minLine, ref  maxLine, ref currentFile);
            if (currentFile != "") currentFile = GetRelativeToOutputSourceFileName(currentFile);
            if (isMaxLine)
            {
                if (currentFile != "" && currentFile != p_currentSourceFile)
                {
                    p_currentSourceFile = currentFile;
                    if (maxLine != p_currentRealLine && maxLine > 0) { writeLineDirectiveText("//#line " + maxLine + " \"" + p_currentSourceFile + "\""); p_currentRealLine = maxLine; }
                }
                else
                    if (maxLine != p_currentRealLine && maxLine > 0) { writeLineDirectiveText("//#line " + maxLine); p_currentRealLine = maxLine; }
            }
            else
            {
                if (currentFile != "" && currentFile != p_currentSourceFile)
                {
                    p_currentSourceFile = currentFile;
                    if (minLine != p_currentRealLine && minLine > 0) { writeLineDirectiveText("//#line " + minLine + " \"" + p_currentSourceFile + "\""); p_currentRealLine = minLine; }
                }
                else
                    if (minLine != p_currentRealLine && minLine > 0) { writeLineDirectiveText("//#line " + minLine); p_currentRealLine = minLine; }
            }
            */
        }

        private void writeLineDirectiveText(string p)
        {
            if (p_newLineFlag)
            {
                //p_currentWriter.WriteLine(p);
                writeOut(p);
            }
            else
            {
                writeNewLine();
                writeOut(p);
                //p_currentWriter.WriteLine(p);
            }
            writeNewLine();
        }

        private string GetRelativeToOutputSourceFileName(string currentFile)
        {
            ///Se lo deberia mejorar para calcular un path relativo
            ///al archivo de entrada.
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
            }
        }



        private void CrearClase(string ClassName)
        {
            string tempFileName = p_currentOutputDirectory + ClassName + ".java";
            if (!File.Exists(tempFileName)) { }

            p_infoClaseActual = new ZoeInfoclase();
            p_lineas = p_infoClaseActual.Contenido;
            p_infoClaseActual.NameClass = ClassName;
            p_infoClaseActual.Filename = tempFileName;
            p_listInfoClase.Add(p_infoClaseActual);
            //*/
            //ImprimirMensajesdeCabezara(documentBody);
            ///Por mas que exista sobreescribir el archivo a lo sumo emitir una advertencia

        }

        protected override void renderBeginDocumentBody(XplDocumentBody documentBody)
        {
            /*
            string str1 = "--------------------------------------------------------------------------";
            string pad = " ";
            writeLineComment(str1);//Modificar encabezado
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
            writeLineComment(" Generado por: LayerD Java Generator - Modulo de Salida LayerD-Zoe a Java 2. ");
            writeLineComment("                                                                          ");
            if (!p_dontWriteCopyrightComment)
            {
                writeLineComment(" 2006(R)Alejandro Romero, Demian Odasso.                                                  ");
                writeLineComment("                                                                          ");
                writeLineComment(" Por favor visite http://layerd.net para obtener las últimas versiones    ");
                writeLineComment(" disponibles de las herramientas LayerD gratuitamente.                    ");
                writeLineComment("                                                                          ");
            }
            writeLineComment("--------------------------------------------------------------------------");
            writeNewLine();
            writeLineDirective(documentBody.get_ldsrc(), false);
             */
        }

        protected void ImprimirCabezera()
        {
            /*
            string str1 = "--------------------------------------------------------------------------";
            string pad = " ";
            writeLineComment(str1);//Modificar encabezado
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
            writeLineComment(" Generado por: LayerD Java Generator - Modulo de Salida ZOE a Java 2.     ");
            writeLineComment("                                                                          ");
            if (!p_dontWriteCopyrightComment)
            {
                writeLineComment(" 2006-2007(R)Alejandro Romero, Demian Odasso.                             ");
                writeLineComment("                                                                          ");
                writeLineComment(" Por favor visite http://layerd.net para obtener las últimas versiones    ");
                writeLineComment(" disponibles de las herramientas LayerD gratuitamente.                    ");
                writeLineComment("                                                                          ");
            }
            writeLineComment("--------------------------------------------------------------------------");
            writeNewLine();
             */
            //writeLineDirective(documentBody.get_ldsrc(), false);            
        }
        protected void ImprimirPie()
        {
            writeNewLine();
            //writeLineComment("--- Final del archivo generado a partir de '" + p_inputFileName + "' ---");
        }

        protected override void renderEndDocumentBody(XplDocumentBody documentBody)
        {
            ///Primero calculamos los Throws :-)

            CalcularThrows();
            ///Finalmente Guardamos los archivos, la parte facil!!!
            foreach (ZoeInfoclase infoClase in p_listInfoClase)
                infoClase.SaveFile();
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
            p_lineas.Add(p_currentLine + "\n");
            p_currentLine = "";
            p_newLineFlag = true;
            p_currentRealLine++;
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
            writeOut("/*" + comment + "*/"); writeNewLine();
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
                tempStr += "base";
                tempStr += "(" + processExpressionList(initializer.get_params(), EZOEContext.FunctionDecl) + ") ; ";
                //Sera un error cuando se posea mas de un inicializador de clase base
            }
            /*
			if(tempStr!="")
				return tempStr.Substring(0,tempStr.Length-2);
			else
				return "";
             * 
             */
            return tempStr;
        }
        #endregion

        #region processSimpleTypeName y processUserTypeName
        string processUserTypeName(string typeName)
        {
            typeName = typeName.Replace("::", ".");
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
                    retStr = "uint";
                    isValueType = true;
                    break;
                case "$LONG$":
                    retStr = "long";
                    isValueType = true;
                    break;
                case "$ULONG$":
                    retStr = "ulong";
                    isValueType = true;
                    break;
                case "$SHORT$":
                    retStr = "short";
                    isValueType = true;
                    break;
                case "$USHORT$":
                    retStr = "ushort";
                    isValueType = true;
                    break;
                case "$SBYTE$":
                    retStr = "sbyte";
                    isValueType = true;
                    break;
                case "$BYTE$":
                    retStr = "byte";
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
                    retStr = "double";
                    isValueType = true;
                    break;
                case "$DECIMAL$":
                    retStr = "decimal";
                    break;
                case "$FIXED$":
                    retStr = "decimal";
                    break;
                case "$BOOLEAN$":
                    retStr = "boolean";
                    break;
                case "$CHAR$":
                    retStr = "char";
                    isValueType = true;
                    break;
                case "$STRING$":
                    retStr = "String";
                    break;
                case "$ASCIISTRING$":
                    retStr = "String";
                    break;
                case "$ASCIICHAR$":
                    retStr = "char";
                    isValueType = true;
                    break;
                case "$DATE$":
                    retStr = "DateTime";
                    break;
                case "$VOID$":
                    retStr = "void";
                    break;
                case "$OBJECT$":
                    retStr = "Object";
                    break;
                case "$NONE$":
                    retStr = "";
                    break;
                case "$TYPE$":
                    AddError("No es posible procesar tipo 'type'. Usando tipo 'object'.");
                    retStr = "Object";
                    break;
                case "$BLOCK$":
                    AddError("No es posible procesar tipo 'block'. Usando tipo 'object'.");
                    retStr = "Object";
                    break;
                default:
                    AddError("No es posible procesar tipo '" + nt + "'. Usando tipo 'object'.");
                    retStr = "Object";
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
                else if (typeStr == "zoe.lang.DateTime") return "java.util.Date";
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
        /// <summary>
        /// Implementación vieja de getTypeName
        /// 
        /// -- NO USAR --
        /// </summary>
        string getTypeName2(XplType type, EZOETypeContext typeContext, ref bool isValueType)
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
        bool checkPointerType(XplType type, EZOETypeContext context)
        {
            ///PENDIENTE : hacer que funcione en modo depuracion,
            ///asi normalmente no relentiza la generación al vicio.
            return true;
        }
        string getArrayStr(XplType type, EZOETypeContext typeContext, EZOEContext context, bool isValueType)
        {
            ///Aca tendria que procesar lo siguiente:
            ///Cuando tengo:
            ///     ^[][][]int <-- int [,,]
            ///     ^[][][]^[][]int <-- int[,,][,]
            ///     
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
                    if (derived.get_isarray()) retStr += ",";
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
            string retStr = String.Empty;

            XplType currentType = type, derived = null;
            bool isRef = false;
            while (currentType != null)
            {
                derived = currentType.get_dt();
                if (!currentType.get_ispointer() && !currentType.get_isarray()) break;
                if (currentType.get_ispointer())
                {
                    if (currentType.get_pi().get_ref()) isRef = true;
                    if (derived != null
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
        protected override void processDocumentData(XplDocumentData documentData)
        {
            ///Por ahora no hago nada para procesar la info de configuración
        }
        #endregion

        #region Inicio y Fin de Documento
        //protected override void ImprimirMensajesdeCabezara(/*XplDocumentBody documentBody*/)
        /*{
		}
        protected override void ImprimirMensajedePie(/*XplDocumentBody documentBody*/
        //)
        //{
        //}

        #endregion

        #region Declaraciones
        protected override void renderImportDirective(XplName importDirective)
        {

            string importStr = "";
            foreach (XplNode node in importDirective.Children())
            {
                tempStr = node.get_StringValue();
                if (tempStr.IndexOf('=') == -1)
                {
                    importStr = ImportPC + tempStr + ".*;\n";
                }
                else
                {
                    string parameterName = tempStr.Substring(0, tempStr.IndexOf('=')).ToLower();
                    string parameterValue = tempStr.Substring(tempStr.IndexOf('=') + 1);
                    switch (parameterName)
                    {
                        case "platform":
                            if (!parameterValue.ToLower().Contains("java")) importStr = "";
                            break;
                        case "ns":
                            if (p_namespaceToRemove == "" && importStr!="")
                                p_namespaceToRemove = parameterValue;
                            break;
                        /*
                        case "assembly":
                            if(!parameterValue.EndsWith(".dll")) parameterValue += ".dll";
                            if (parameterValue.ToLower() != "mscorlib" && !p_assemblyList.Contains(parameterValue.ToLower()))
                                p_assemblyList.Add(parameterValue.ToLower());
                            break;
                        case "assemblyfilename":
                            if (parameterValue.ToLower() != "mscorlib" && !p_assemblyList.Contains(parameterValue.ToLower()))
                                p_assemblyList.Add(parameterValue.ToLower());
                            break;
                        */
                    }
                }
            }
            //p_currentDocumentImportStr += importStr;
        }
        protected override void renderBeginNamespace(string namespaceName, XplNamespace namespaceDecl, EZOEContext context)
        {
            //writeNewLine();
            //writeLineDirective(namespaceDecl.get_ldsrc(), false);
            //writeOut(NamespacePC + processUserTypeName(namespaceName) + "{");
            //incNLevel();

            string directorio = this.processUserTypeName(namespaceName);
            if (p_currentPackage == "")
                p_currentPackage += directorio;
            else
                p_currentPackage += "." + directorio;

            p_currentClass = p_currentPackage;

            directorio = directorio.Replace('.', '\\');
            Debug.WriteLine("Chequeando: " + p_currentOutputDirectory + directorio);
            if (!Directory.Exists(p_currentOutputDirectory + directorio))
            {
                Directory.CreateDirectory(p_currentOutputDirectory + directorio);
                if (!Directory.Exists(p_currentOutputDirectory + directorio))
                    throw new Exception("No se pudo crear la carpeta para el paquete " + namespaceName + ". Verifique que tenga los permisos adecuados.");
                else
                    Debug.WriteLine("Se creo la carpeta: " + p_currentOutputDirectory + directorio);
            }
            else
                Debug.WriteLine("Existe: " + p_currentOutputDirectory + directorio);
            p_currentOutputDirectory = p_currentOutputDirectory + directorio + "\\";

            ///writeNewLine();            

        }
        protected override void renderEndNamespace(string namespaceName, XplNamespace namespaceDecl, EZOEContext context)
        {
            p_currentOutputDirectory = p_currentOutputDirectory.Substring(0, p_currentOutputDirectory.Length - processUserTypeName(namespaceName).Length - 1);
            p_currentPackage = p_currentPackage.Substring(0, p_currentPackage.Length - processUserTypeName(namespaceName).Length);
            p_currentClass = p_currentPackage;

            if (p_currentPackage != "") p_currentPackage = p_currentPackage.Substring(0, p_currentPackage.Length - 1);
            // Tengo que cerrar las clases creadas?
        }
        //Tipos Definidos por el usuario
        protected override void renderBeginClass(EZOEClassType classType, string className, string implementsStr, string inheritsStr,
            XplAccesstype_enum classAccess, bool isNew, bool isAbstract, bool isFinal, XplClass classDecl, EZOEContext context)
        {

            //Si la clase es externa levanto la bandera y retorno
            if (classDecl.get_external())
            {
                p_isExternalClass++;
                return;
            }

            RenderComments(classDecl);

            writeLineDirective(classDecl.get_ldsrc(), false);

            p_currentClass += "." + className;

            if (classDecl.get_externalname() != "")
                className = classDecl.get_externalname();

            //Usamos el cuenta clases para saber
            if (p_cuentaClases == 0) //Es una clase externa
            {
                CrearClase(className);
                ImprimirCabezera();
                writeOut(PackagePC + p_currentPackage + ";");
                writeNewLine();
                writeNewLine();
                writeOut(p_currentDocumentImportStr);
                writeNewLine();
            }
            //Usamos "p_cuentaClases" para saber cuando estamos
            //en una clase anidada y no tenemos que crear un nuevo archivo
            p_cuentaClases++;

            //Primero los modificadores
            
            if (isAbstract) writeOut(AbstractPC);
            if (isFinal) writeOut(FinalPC);
            // if it's an internal class and is marked as static
            // if (p_cuentaClases>1 && classDecl.get_lddata().Contains(STATIC_JAVA_CLASS)) writeOut(StaticPC);
            // for now mark all inner classes as static because it's not supported not static inner classes
            if (p_cuentaClases > 1) writeOut(StaticPC);

            writeOut(getAccess(classAccess, context));
            //La declaracion del nombre
            switch (classType)
            {
                case EZOEClassType.Class:
                    writeOut(ClassPC + className);
                    break;
                case EZOEClassType.Interface:
                    writeOut(InterfacePC + className);
                    break;
                case EZOEClassType.Enum:
                    writeOut(EnumPC + className);
                    renderEnumType(classDecl);
                    break;
                default:
                    AddError("Valor interno inesperado renderizando clase.");
                    break;
            }
            if (inheritsStr != "") writeOut(" " + ExtendsPC + inheritsStr);
            if (implementsStr != "") writeOut(" " + ImplementsPC + implementsStr);
            writeOut("{");
            incNLevel();
            writeNewLine();
        }
        protected override void renderEndClass(EZOEClassType classType, string className, XplClass classDecl, EZOEContext context)
        {
            //Si la clase actual es externa retorno
            if (p_isExternalClass > 0)
            {
                if (classDecl.get_external()) p_isExternalClass--;
                return;
            }
            p_cuentaClases--;

            p_currentClass = p_currentClass.Substring(0, p_currentClass.Length - className.Length);
            if (p_currentClass.Length > 1) p_currentClass = p_currentClass.Substring(0, p_currentClass.Length - 1);

            writeLineDirective(classDecl.get_ldsrc(), true);
            decNLevel();
            writeOut("} ");
            if (p_writeDetailedComments) writeComment("End of class '" + className + "'");
            writeNewLine();

            if (p_cuentaClases == 0)
            {
                ImprimirPie();
            }
        }
        protected override string renderImplements(XplClass classDecl, XplNodeList implements, EZOEContext context)
        {
            string temp = "";
            XplInherit imp = null;
            XplInherits imps = null;
            foreach (XplNode node in implements)
            {
                imps = (XplInherits)node;
                foreach (XplNode node2 in imps.Children())
                {
                    imp = (XplInherit)node2;
                    temp += processUserTypeName(imp.get_type().get_typename()) + ", ";
                }
            }/*Este metodo implementa los Nodos*/
            if (temp != "") temp = temp.Substring(0, temp.Length - 2);
            return temp;
        }
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
                        temp += processUserTypeName(inh.get_type().get_typename()) + ", ";
                        if (inh.get_access() != XplAccesstype_enum.PUBLIC)
                            AddWarning("Modificador de acceso ignorado en declaración de herencia. El tipo real implementado utilizará acceso publico para la clase heredada.");
                        if (!inh.get_virtual())
                            AddWarning("Modificador virtual no aplicado en declaración de herencia, forzando herencia virtual.");
                    }
                }
            }
            if (temp != "") temp = temp.Substring(0, temp.Length - 2);
            return temp;
        }
        //Miembros de Tipos Definidos por el Usuario
        protected override void renderBeginFunction(XplFunction functionDecl, string functionName, string returnTypeStr, string parametersStr,
            XplAccesstype_enum access, XplVarstorage_enum functionStorage, bool isAbstract, bool isFinal, bool isFp, bool isNew, bool isConst,
            bool isOverride, bool isVirtual, EZOEContext context)
        {

            bool isStatic = functionStorage == XplVarstorage_enum.STATIC || functionStorage == XplVarstorage_enum.STATIC_EXTERN;
            bool isExtern = functionStorage == XplVarstorage_enum.EXTERN || functionStorage == XplVarstorage_enum.STATIC_EXTERN;
            //Si la clase actual es externa retorno
            if (p_isExternalClass > 0 || isExtern) return;

            writeLineDirective(functionDecl.get_ldsrc(), false);

            string baseInitializers = renderBaseInitializers(functionDecl.get_BaseInitializers());


            //Aqui creo el InfoFuncion que voy a utilizar para agregar las
            //dependecias
            p_infoFuncionActual = new InfoFuncion();
            p_infoFuncionActual.Class = p_infoClaseActual;
            p_infoFuncionActual.NombreFuncionCompleto = p_currentClass + functionDecl.get_internalname();
            p_infoFuncionActual.IndiceDeclaracion = p_infoClaseActual.Contenido.Count;
            p_listInfoFuncion.Add(p_listInfoFuncion);

            //Renderizo el inicio de la funcion
            //
            bool isInterface = functionDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplClass && functionDecl.CurrentClass.get_isinterface();

            //Ajusto el nombre de la funcion al nombre externo si es necesario
            if (functionDecl.get_externalname() != "")
                functionName = functionDecl.get_externalname();

            bool isConstructorName = ((XplClass)functionDecl.get_Parent()).get_name() == functionName;
            //Los miembros de las interfaces son siempre publicos no se debe hacer nada
            if (!isInterface)
            {
                if (!(isConstructorName && isStatic))
                {
                    writeOut(getAccess(access, context));
                }
            }
            // write storage (static / extern)
            writeOut(getStorage(functionStorage, context));

            if (isAbstract) writeOut(AbstractPC);
            if (isFinal) writeOut(FinalPC);
            if (isNew) writeOut(NewPC);
            if (isConst) AddWarning("Modificador de función 'const' no aplicado en implementacion.");

            if (isFp)
            { 
                // TODO : remove or change
                writeOut(DelegatePC);
            }
            if (functionName.IndexOf("%indexer%") >= 0)
            {
                /*Ver indexer*/
                AddError("Codigo LayerD-Zoe no valido, indexadores no se permiten en Java.");
            }
            else if (functionName.IndexOf("%op_") >= 0)
            {
                // remove ?????
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
                    case "%op_leq%":
                        functionName = OperatorPC + "<=";
                        break;
                    case "%op_geq%":
                        functionName = OperatorPC + ">=";
                        break;
                    case "%op_neq%":
                        functionName = OperatorPC + "!=";
                        break;
                    case "%op_andl":
                        AddError("No se puede sobrecargar el operador &&.");
                        functionName = OperatorPC + "_andl";
                        break;
                    case "%op_orl":
                        AddError("No se puede sobrecargar el operador ||.");
                        functionName = OperatorPC + "_orl";
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
                    case "%op_and%":
                        functionName = OperatorPC + "&";
                        break;
                    case "%op_or%":
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
                        functionName = "operator_NonRecognized";
                        AddError("No se pudo identificar el operador utilizado.");
                        break;
                }/*¿operadores logicos? se utilizan todos?*/
                #endregion //Ver operadores
            }
            else
            {
                functionName = processUserTypeName(functionName);
                currentFunctionType = FunctionType.Method;
            }
            // PENDIENTE : el cambio del nombre de la funcion de punto de entrada
            // lo hago aqui en el modulo o lo hace el compilador Zoe?.
            // TODO: must check that arguments are those of main and not any "main" function
            if (functionName == "Main" && functionDecl.get_storage() == XplVarstorage_enum.STATIC && functionDecl.get_Parameters()!=null && functionDecl.get_Parameters().Children().GetLength() == 1)
                functionName = "main";

            writeOut(returnTypeStr + " ");
            if (!(isStatic && isConstructorName))
            {
                writeOut(functionName);
                if (currentFunctionType == FunctionType.Indexer)
                    writeOut("[" + parametersStr + "]");
                else
                    writeOut("(" + parametersStr + ")");
            }
            
            // TODO : change this to function body
            if (baseInitializers != "") writeOut(":" + baseInitializers); 
            if (!isAbstract && functionStorage != XplVarstorage_enum.EXTERN && functionStorage != XplVarstorage_enum.STATIC_EXTERN
                && !isInterface)
            {
                writeNewLine();
                writeOut("{");
                incNLevel();
                //por aca iria el inicializador.
            }
            else
            {
                writeOut(";");
            }
            writeNewLine();
        }
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
                writeNewLine();
            }
        }
        protected override void renderBeginProperty(XplProperty propertyDecl, string propertyName, string typeStr,
            XplAccesstype_enum access, XplVarstorage_enum propertyStorage, bool isAbstract, bool isFinal, bool isNew, bool isConst,
            bool isOverride, bool isVirtual, EZOEContext context)
        {

            //Si la clase actual es externa retorno
            if (p_isExternalClass > 0 || propertyStorage == XplVarstorage_enum.EXTERN || propertyStorage == XplVarstorage_enum.STATIC_EXTERN) return;

            writeLineDirective(propertyDecl.get_ldsrc(), false);

            writeOut(getAccess(access, context));
            writeOut(getStorage(propertyStorage, context));

            if (isAbstract) writeOut(AbstractPC);
            if (isFinal) writeOut(FinalPC);
            if (isNew) writeOut(NewPC);
            if (isConst) AddWarning("Modificador de función 'const' no aplicado en implementacion.");
            if (isOverride) writeOut(OverridePC);
            if (isVirtual) writeOut(VirtualPC);
            writeOut(typeStr + " " + processUserTypeName(propertyName) + " {");
            incNLevel();
            writeNewLine();
            currentFunctionType = FunctionType.Property;
        }
        protected override void renderEndProperty(XplProperty propertyDecl, string propertyName, EZOEContext context)
        {
            //Si la clase actual es externa retorno
            XplVarstorage_enum propertyStorage = propertyDecl.get_storage();
            if (p_isExternalClass > 0 || propertyStorage == XplVarstorage_enum.EXTERN || propertyStorage == XplVarstorage_enum.STATIC_EXTERN) return;

            decNLevel();
            writeOut("} ");
            if (p_writeDetailedComments) writeComment("Final de propiedad '" + propertyName + "'.");
            writeNewLine();
        }
        protected override void renderBeginGetAccess(EZOEContext context, XplFunctionBody body)
        {
            bool isExtern = false;
            if (body.get_Parent().get_Parent().get_TypeName() == CodeDOMTypes.XplProperty)
            {
                XplProperty property = (XplProperty)body.get_Parent().get_Parent();
                isExtern = property.get_storage() == XplVarstorage_enum.EXTERN || property.get_storage() == XplVarstorage_enum.STATIC_EXTERN;
            }
            if (p_isExternalClass > 0 || isExtern) return;
            writeOut("get ");
            if (body.Children().GetLength() == 0) writeOut(";");
            else
            {
                writeOut("{");
                incNLevel();/*Que hace este metodo con get?*/
                writeNewLine();
            }
        }
        protected override void renderEndGetAccess(EZOEContext context, XplFunctionBody body)
        {
            bool isExtern = false;
            if (body.get_Parent().get_Parent().get_TypeName() == CodeDOMTypes.XplProperty)
            {
                XplProperty property = (XplProperty)body.get_Parent().get_Parent();
                isExtern = property.get_storage() == XplVarstorage_enum.EXTERN || property.get_storage() == XplVarstorage_enum.STATIC_EXTERN;
            }
            if (p_isExternalClass > 0 || isExtern) return;
            if (body.Children().GetLength() == 0)
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
        protected override void renderBeginSetAccess(EZOEContext context, XplFunctionBody body)
        {
            bool isExtern = false;
            if (body.get_Parent().get_Parent().get_TypeName() == CodeDOMTypes.XplProperty)
            {
                XplProperty property = (XplProperty)body.get_Parent().get_Parent();
                isExtern = property.get_storage() == XplVarstorage_enum.EXTERN || property.get_storage() == XplVarstorage_enum.STATIC_EXTERN;
            }
            if (p_isExternalClass > 0 || isExtern) return;
            writeOut("set ");
            if (body.Children().GetLength() == 0) writeOut(";");
            else
            {
                writeOut("{");
                incNLevel();
                writeNewLine();
            }
        }
        protected override void renderEndSetAccess(EZOEContext context, XplFunctionBody body)
        {
            bool isExtern = false;
            if (body.get_Parent().get_Parent().get_TypeName() == CodeDOMTypes.XplProperty)
            {
                XplProperty property = (XplProperty)body.get_Parent().get_Parent();
                isExtern = property.get_storage() == XplVarstorage_enum.EXTERN || property.get_storage() == XplVarstorage_enum.STATIC_EXTERN;
            }
            if (p_isExternalClass > 0 || isExtern) return;
            if (body.Children().GetLength() == 0)
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
            XplAccesstype_enum access, XplVarstorage_enum fieldStorage, bool isNew, bool isVolatile)
        {

            if (p_isExternalClass>0 || fieldStorage == XplVarstorage_enum.EXTERN || fieldStorage == XplVarstorage_enum.STATIC_EXTERN) return;

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

        protected override void renderBeginParameters(XplParameters parametersDecl, int maxParameter, XplFunction functionDecl, EZOEContext context)
        {
            p_maxParameter = maxParameter;
        }
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
                    retStr += InoutPC;
                    break;
                case XplParameterdirection_enum.OUT:
                    retStr += OutPC;
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
                AddError("Los parametros no pueden declarar valores por defecto en .NET.");
                retStr += "/*=" + initializerStr + "*/";
            }
            return retStr;
        }
        protected override void renderEndParameters(XplParameters parametersDecl, EZOEContext context)
        {
            p_maxParameter = 0;
        }
        protected override string renderType(XplType type, string declareName, EZOETypeContext typeContext, EZOEContext context)
        {
            string typeStr = "", arrayStr = "", pointerStr = "";
            bool isValueType = false;
            typeStr += getTypeName(type, typeContext, ref isValueType);
            if (p_checkTypes) checkPointerType(type, typeContext);
            pointerStr = getPointerStr(type, typeContext, isValueType);
            if (pointerStr != "") typeStr += pointerStr;
            arrayStr = getArrayStr(type, typeContext, context, isValueType);
            if (arrayStr != "") typeStr += arrayStr;
            switch (typeContext)
            {
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
            return typeStr;
        }
        protected override string renderBeginInitializerList(XplInitializerList initializerList, EZOEContext context)
        {
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
            return "}";
        }
        protected override string renderBeginArrayInitializer(XplInitializerList initializerList, EZOEContext context)
        {
            return "{";
        }
        #endregion

        #region Instrucciones
        protected override void renderBeginBlock(XplFunctionBody functionBody, EZOEContext context)
        {
            writeLineDirective(functionBody.get_ldsrc(), false);
            if (context == EZOEContext.FunctionBody)
            {
                if (context == EZOEContext.FunctionBody &&
                    functionBody.get_Parent().get_TypeName() != CodeDOMTypes.XplFunctionBody /*||
                    functionBody.get_Parent().get_TypeName() == CodeDOMTypes.XplFunctionBody &&
                    functionBody.get_DeclsNodeList().GetLength() > 0*/
                                                                      )
                {
                    writeNewLine();
                    writeOut("{");
                    incNLevel();
                    writeNewLine();
                }
                //writeOut("{");
                //incNLevel();
                //writeNewLine();
            }
        }
        protected override void renderEndBlock(XplFunctionBody functionBody, EZOEContext context)
        {
            if (context == EZOEContext.FunctionBody)
            {
                if (context == EZOEContext.FunctionBody &&
                    functionBody.get_Parent().get_TypeName() != CodeDOMTypes.XplFunctionBody /*||
                    functionBody.get_Parent().get_TypeName() == CodeDOMTypes.XplFunctionBody &&
                    functionBody.get_DeclsNodeList().GetLength() > 0*/
                                                                      )
                {
                    decNLevel();
                    writeOut("}");
                    writeNewLine();
                }
                //decNLevel();
                //writeOut("}");
                //writeNewLine();
            }
        }
        protected override void renderLabel(XplNode label, EZOEContext context)
        {
            writeOut(label.get_StringValue() + ":");
            writeNewLine();
        }
        protected override void renderSetonerror(XplSetonerror setOnerror, EZOEContext context)
        {
            AddError("Instrucción 'setonerror' no soportada por el modulo de salida.");
        }
        protected override void renderExpressionStatement(XplExpression expression, string expressionString, EZOEContext context)
        {
            if (expressionString != String.Empty)
            {
                writeLineDirective(expression.get_ldsrc(), false);
                writeOut(expressionString + ";");
                writeNewLine();
            }
        }
        protected override void renderThrow(XplExpression throwExpression, string expressionString, EZOEContext context)
        {
            writeLineDirective(throwExpression.get_ldsrc(), false);
            writeOut(ThrowPC + expressionString + ";");
            writeNewLine();
        }
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
            writeNewLine();
        }
        protected override void renderLocalDeclarator(XplDeclarator decl, string varName, string typeStr, string initializerStr, bool isVolatile)
        {
            writeLineDirective(decl.get_ldsrc(), false);
            RenderComments(decl);

            if (isVolatile) writeOut(VolatilePC);
            if (decl.get_type().get_const()) writeOut(ConstPC);
            writeOut(typeStr);
            if (initializerStr != "")
                if (decl.get_i().Children().FirstNode().get_ElementName() != "list" || initializerStr[0] != '(') writeOut(" = " + initializerStr);
                else writeOut(initializerStr);
            writeOut(";");
            writeNewLine();
        }
        bool p_isOnCase = false;
        protected override void renderBeginSwitch(XplSwitchStatement switchSta, string boolExpStr, EZOEContext context)
        {
            writeLineDirective(switchSta.get_ldsrc(), false);
            writeOut(SwitchPC + "(" + boolExpStr + "){");
            incNLevel();
            writeNewLine();
            tempStr = boolExpStr;
        }
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
            writeNewLine();
        }
        protected override void renderEndSwitch(XplSwitchStatement switchSta, EZOEContext context)
        {
            if (p_isOnCase) decNLevel();
            p_isOnCase = false;
            decNLevel();
            writeNewLine();
            writeOut("}");
            writeNewLine();
            if (p_writeDetailedComments) writeComment("Fin Switch '" + tempStr + "'");
        }
        protected override void renderIfStatement(XplIfStatement ifSta, string boolExp, bool isElse, EZOEContext context)
        {
            writeLineDirective(ifSta.get_ldsrc(), false);
            if (!isElse)
            {
                writeOut(IfPC + "(" + boolExp + ")");
            }
            else
            {
                writeOut(ElsePC + IfPC + "(" + boolExp + ")");
            }
        }
        protected override void renderElseStatement(XplIfStatement ifSta, XplFunctionBody elseBody, EZOEContext context)
        {
            if (elseBody != null) writeOut(ElsePC);
        }
        protected override void renderForStatement(XplForStatement forSta, string initStr, string boolExpStr, string updateStr, EZOEContext context)
        {
            writeLineDirective(forSta.get_ldsrc(), false);
            if (updateStr == "_FOR_EACH_")
                writeOut(ForPC + "(" + initStr + " : " + boolExpStr + ")");
            else
                writeOut(ForPC + "(" + initStr + "; " + boolExpStr + "; " + updateStr + ")");
        }
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
                //Agrego el nombre de la variable
                retStr += " " + varName;
                //Agrego el inicializador
                if (initStr != "")
                    if (initStr[0] != '(') retStr += "=" + initStr;
                    else retStr += initStr;
                //Agrego la coma
                if (n != listaDeclaraciones.GetLength() - 1) retStr += ",";
            }
            return retStr;
        }
        protected override void renderWhileStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context)
        {
            writeLineDirective(doSta.get_ldsrc(), false);
            writeOut(WhilePC + "(" + boolExpStr + ")");
            //while(expresion_booleana) instruccion
            //
            //do instruccion while(expresion_booleana);
            //
        }
        protected override void renderBeginDoStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context)
        {
            writeLineDirective(doSta.get_ldsrc(), false);
            writeOut(DoPC);
        }
        protected override void renderEndDoStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context)
        {
            writeLineDirective(doSta.get_ldsrc(), true);
            writeOut(WhilePC + "(" + boolExpStr + ");");
            writeNewLine();
        }
        protected override void renderBeginTry(XplTryStatement trySta, EZOEContext context)
        {
            /*try{
             * ....
             * }
             * catch(exp...){
             * }
             * ...
             * catch(exp...){
             * }
             * finally{
             * }
             * 
             * try{
             * }
             * finally{
             * }
             */
            writeLineDirective(trySta.get_ldsrc(), false);
            writeOut(TryPC);
        }
        protected override void renderEndTry(XplTryStatement trySta, EZOEContext context)
        {
            writeNewLine();
        }
        protected override void renderCatchStatement(XplCatchStatement catchSta, string declExp, EZOEContext context)
        {
            writeLineDirective(catchSta.get_ldsrc(), false);
            writeOut(CatchPC + "(" + declExp + ")");
        }
        protected override void renderFinally(XplFunctionBody tryBk, EZOEContext context)
        {
            writeLineDirective(tryBk.get_ldsrc(), false);
            writeOut(FinallyPC);
        }
        protected override void renderBreak(XplJump jump, EZOEContext context)
        {
            writeLineDirective(jump.get_ldsrc(), false);
            writeOut(BreakPC + ";");
            writeNewLine();
        }
        protected override void renderContinue(XplJump jump, EZOEContext context)
        {
            writeLineDirective(jump.get_ldsrc(), false);
            writeOut(ContinuePC + ";");//Ver continue como se usa en java
            writeNewLine();
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
                            writeOut("// " + comment);
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
        protected override void renderGoto(XplJump jump, string label, EZOEContext context)
        {
            writeLineDirective(jump.get_ldsrc(), false);
            writeOut(GotoPC + label + ";");
            writeNewLine();
        }
        protected override void renderResume(XplJump jump, EZOEContext context)
        {
            AddError("Instrucción 'resume' no soportada por el Modulo de Salida.");
        }
        protected override void renderResumeNext(XplJump jump, EZOEContext context)
        {
            AddError("Instrucción 'resume next' no soportada por el Modulo de Salida.");
        }
        protected override void renderDirectOutput(XplDirectoutput directOutput, string outputStr, EZOEContext context)
        {
            AddWarning("renderDirectOutput: no implementado en Modulo de Salida.");
        }
        protected override void renderOnpointerStatement(XplFunctionBody functionBody, EZOEContext context)
        {
            AddError("Instrucción 'onpointer' no soportada por el Modulo de Salida.");
        }
        #endregion

        #region Expresiones
        protected override string renderGetTypeExp(XplType xplType, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            //Una expresion zoe gettype nunca deberia llegar aquí
            return "ERROR_GETTYPE_EXPRESSION";
        }
        protected override string renderNewExp(XplNewExpression newExp, string typeStr, string initializerStr, EZOEContext context)
        {
            if (initializerStr != "" && initializerStr[0] != '(' && initializerStr[0] != '{')
            {
                AddWarning("No se permiten inicializadores de expresiones simples en expresiones 'new', sólo son validos inicializadores de matrices y objetos.");
                initializerStr = "";
            }
            //if (initializerStr == "" && newExp.get_type().get_typename() != "")
            if (initializerStr == "" && typeStr[typeStr.Length - 1] != ']' && typeStr[typeStr.Length - 1] != ')')
                return "new " + typeStr + "()";
            else
                return "new " + typeStr + initializerStr;
        }
        protected override string renderBeginExpressionList(XplExpressionlist list, int expCount, EZOEContext context)
        {
            return "";
        }
        protected override string renderExpressionListItem(XplExpression expNode, string expStr, int expNumber, int expCount, EZOEContext context)
        {
            if (expNumber != expCount) return expStr + ", ";
            else return expStr;
        }
        protected override string renderEndExpressionList(XplExpressionlist list, EZOEContext context)
        {
            return "";
        }
        protected override string renderSimpleName(string name, EZOEContext context)
        {
            //Simplemente asumo que todo es correcto y debo reemplazar "::" por "."
            name = processUserTypeName(name);
            if (name == "base") name = "super";
            return name;
        }
        protected override string renderLiteral(XplLiteral litNode, string litStr, EZOEContext context)
        {
            #region Switch de Tipos de Literal
            switch (litNode.get_type())
            {
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
                    tempStr = litStr + (litStr.EndsWith("f") ? "" : "f");
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
        protected override string renderDeleteExp(XplExpression deleteExp, string expStr, EZOEContext context)
        {
            return "DeletePC" + expStr;
        }
        protected override string renderOnpointerExp(XplExpression onpointerExp, string expStr, EZOEContext context)
        {
            AddError("Expresión 'onpointer' no soportada por el Modulo de Salida.");
            return "/*Expresion Onpointer No Soportada*/";
        }
        protected override string renderAssingExp(XplAssing assing, string leftExpStr, string rightExpStr, XplAssingop_enum operation, EZOEContext context)
        {
            if (p_optimiseParenthesis && (int)Precedences.AssingExp == getExpressionPrecedence(assing.get_l()))
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
        protected override string renderBinOpExp(XplBinaryoperator bopExp, string leftExpStr, string rightExpStr, XplBinaryoperators_enum op, EZOEContext context)
        {
            switch (op)
            {
                case XplBinaryoperators_enum.IMP: //Felcha "=>"
                case XplBinaryoperators_enum.M: //Member access "."
                case XplBinaryoperators_enum.MP: //Member Pointer Access ".*"
                case XplBinaryoperators_enum.PM: //Pointer Member Access "->"
                case XplBinaryoperators_enum.PMP: //Pointer To Member Pointer Access "->*"
                case XplBinaryoperators_enum.RM: //Reservado para Acceso a miembros
                    if (this.p_optimiseParenthesis && getOperatorPrecedence(op) > getExpressionPrecedence(bopExp.get_l()))
                    {
                        leftExpStr = "(" + leftExpStr + ")";
                    }
                    break;
                default:
                    if (p_optimiseParenthesis && getOperatorPrecedence(op) == getExpressionPrecedence(bopExp.get_r()))
                    {
                        rightExpStr = "(" + rightExpStr + ")";
                    }
                    break;
            }
            tempStr = bopExp.get_targetClass();
            if (tempStr != null && p_nativeTypes[tempStr] != null)
            {
                tempStr = processNativeTypeAccess(bopExp, leftExpStr, rightExpStr, tempStr);
                if (tempStr != null) return tempStr;
            }

            ///Bandera para evitar usar parentesis en accesos a miembros
            bool flag = false;
            #region Switch de Operadores Binarios
            switch (op)
            {
                case XplBinaryoperators_enum.ADD: //Suma
                    tempStr = leftExpStr + "+" + rightExpStr;
                    break;
                case XplBinaryoperators_enum.AND: //Y Logico
                    tempStr = leftExpStr + " && " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.BAND: //Y de Bits
                    tempStr = leftExpStr + "&" + rightExpStr;
                    break;
                case XplBinaryoperators_enum.BOR: //O de Bits
                    tempStr = leftExpStr + "|" + rightExpStr;
                    break;
                case XplBinaryoperators_enum.DIV: //Division
                    tempStr = leftExpStr + "/" + rightExpStr;
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
                    AddError("Operador binario 'IMP' ('=>') no soportado por el Modulo de Salida. Usando '.' en su lugar.");
                    tempStr = leftExpStr + "." + rightExpStr; flag = true;
                    break;
                case XplBinaryoperators_enum.LS: //Menor que
                    tempStr = leftExpStr + " < " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.LSEQ: //Menor o igual que
                    tempStr = leftExpStr + " <= " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.LSH: //Left shift
                    tempStr = leftExpStr + "<<" + rightExpStr;
                    break;
                case XplBinaryoperators_enum.M: //Member access "."
                    tempStr = leftExpStr + "." + rightExpStr; flag = true;
                    break;
                case XplBinaryoperators_enum.MIN: //Resta
                    tempStr = leftExpStr + "-" + rightExpStr;
                    break;
                case XplBinaryoperators_enum.MOD: //Modulo (resto)
                    tempStr = leftExpStr + "%" + rightExpStr;
                    break;
                case XplBinaryoperators_enum.MP: //Member Pointer Access ".*"
                    AddWarning("Operador binario 'MP' ('.*') no soportado por el Modulo de Salida. Usando '.' en su lugar.");
                    tempStr = leftExpStr + "." + rightExpStr; flag = true;
                    break;
                case XplBinaryoperators_enum.MUL: //Multiplicacion
                    tempStr = leftExpStr + "*" + rightExpStr;
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
                    tempStr = leftExpStr + ">>" + rightExpStr;
                    break;
                case XplBinaryoperators_enum.XOR: //Xor de Bits
                    tempStr = leftExpStr + "^" + rightExpStr;
                    break;
            }
            #endregion
            if (p_optimiseParenthesis)
            {
                if (!flag && requireParenthesis(bopExp)) tempStr = "(" + tempStr + ")";
            }
            else
                if (!flag) tempStr = "(" + tempStr + ")";
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
        /// Procesa un acceso a miembro de un tipo nativo de Zoe,
        /// si retorna nulo quiere decir que no lo proceso y se requiere procesamiento normal, 
        /// sino se usa lo que retorna
        /// </summary>
        private string processNativeTypeAccess(XplBinaryoperator bopExp, string leftExpStr, string rightExpStr, string targetClass)
        {
            if (targetClass == NativeTypesStr.String2 || targetClass == NativeTypesStr.String)
            {
                if (bopExp.get_targetMember().StartsWith("Length")) 
                    return leftExpStr + "." + "length()";
                if (bopExp.get_op() == XplBinaryoperators_enum.EQ && rightExpStr!="null")
                    return leftExpStr + ".equals( " + rightExpStr + " )";
            }
            return null;
        }
        protected override string renderUnOpExp(XplUnaryoperator uopExp, string expStr, XplUnaryoperators_enum op, EZOEContext context)
        {
            #region Switch de Operadores Unarios
            switch (op)
            {
                case XplUnaryoperators_enum.AOF: //Address of '&'
                    if (!p_isUnsafeContext) AddWarning("Operador 'Address of' usado en posible contexto no seguro, posible error.");
                    tempStr = "&" + expStr;
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
            if (p_optimiseParenthesis)
            {
                if (requireParenthesis(uopExp)) tempStr = "(" + tempStr + ")";
            }
            else tempStr = "(" + tempStr + ")";
            return tempStr;
        }
        protected override string renderFunctionCallExp(XplFunctioncall fcallExp, string leftExpStr, string argsStr, bool useBrackets, EZOEContext context)
        {
            string nombreDeFuncionCompleto = fcallExp.get_targetClass() + "." + fcallExp.get_targetMember();
            //AQUI tengo que agragar la info de dependencia al InfoFuncion
            if (!p_infoFuncionActual.Dependencias.ContainsKey(nombreDeFuncionCompleto))
            {
                p_infoFuncionActual.Dependencias.Add(nombreDeFuncionCompleto, nombreDeFuncionCompleto);
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
        protected override string renderCastExp(XplCastexpression castExp, string typeStr, string castExpStr, XplCasttype_enum castType, EZOEContext context)
        {
            tempStr = "(" + typeStr + ")" + castExpStr;
            if (p_optimiseParenthesis)
            {
                if (requireParenthesis(castExp)) tempStr = "(" + tempStr + ")";
            }
            else
            {
                tempStr = "(" + tempStr + ")";
            }
            //tempStr = "(" + tempStr + ")"; //Cuidado con esto al corregir lo superior
            return tempStr;
        }
        protected override void renderUsingDirective(XplName xplName, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        protected override string renderWritecodeExpression(XplExpression xplExpression, string expStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
            //throw new Exception("The method or operation is not implemented.");
        }

        protected override string renderWritecodeBlock(XplWriteCodeBody xplWriteCodeBody, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
            //throw new Exception("The method or operation is not implemented.");
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
        public bool OptimiseParenthesis
        {
            get { return p_optimiseParenthesis; }
            set { p_optimiseParenthesis = value; }
        }
        public bool checkTypes
        {
            get { return p_checkTypes; }
            set { p_checkTypes = value; }
        }
        public bool dontWriteCopyrightComment
        {
            get { return p_dontWriteCopyrightComment; }
            set { p_dontWriteCopyrightComment = value; }
        }
        public bool writeDetailedComments
        {
            get { return p_writeDetailedComments; }
            set { p_writeDetailedComments = value; }
        }
        public string OutputFileName
        {
            get { return p_outputFileName; }
            set { p_outputFileName = value; }
        }
        public bool ApplyFormat
        {
            get { return p_applyFormat; }
            set { p_applyFormat = value; }
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
            //Primero renderizo la representación intermedia en C#
            try
            {
                if (renderArguments != null)
                {
                    //Proceso los argumentos de renderizacion
                    //Por ahora solo considero la grabación del código recibido
                    if (renderArguments.ToLower() == "save_ezoe" && p_XplDocument != null)
                    {
                        XplWriter writer = null;
                        try
                        {
                            writer = new XplWriter("last_ezoe.xpl");
                            p_XplDocument.Write(writer);
                        }
                        finally
                        {
                            if (writer != null) writer.Close();
                        }
                    }
                }
                //PrepareOutput();
                p_listInfoClase = new ArrayList();
                p_listInfoFuncion = new ArrayList();
                parseResult = base.ParseDocument();
            }
            finally
            {
                if (p_currentWriter != null) p_currentWriter.Close();
                //CloseOutput();
            }
            //Construyo la salida
            if (!renderOnly && parseResult)
            {
                #region Compilar Java
                //PENDIENTE : Llamar al compilador de Java y construir el modulo.                
                string filesStr = "";
                foreach (ZoeInfoclase infoClase in p_listInfoClase)
                    filesStr += " \"" + Path.GetFullPath(infoClase.Filename) + "\"";

                Process p = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(
                    "javac.exe", " " + filesStr);
                startInfo.WorkingDirectory = Path.GetFullPath(p_currentOutputDirectory);
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardInput = true;
                startInfo.CreateNoWindow = true;

                startInfo.UseShellExecute = false;
                p.StartInfo = startInfo;
                try
                {
                    p.Start();

                    string output = p.StandardOutput.ReadToEnd();
                    string error = p.StandardError.ReadToEnd();
                    p.WaitForExit();
                    Debug.WriteLine(output + error);
                    parseResult = true;
                    Console.WriteLine("Ok compilando java.");
                }
                catch
                {
                    Console.WriteLine("Error compilando java.");
                    AddError("No se pudo compilar codigo java.");
                    parseResult = false;
                }
                #endregion
            }
            return parseResult;
        }
        public void SetOutputPath(string outputPath)
        {
            if (outputPath!=null && outputPath.Length>1 && outputPath[outputPath.Length-1] != Path.DirectorySeparatorChar)
                outputPath = outputPath + Path.DirectorySeparatorChar;

            p_currentOutputDirectory = outputPath;
        }
        public void SetOutputFileName(string outputFileName)
        {
            p_outputFileName = outputFileName;
            if (p_currentOutputDirectory == null || p_currentOutputDirectory == "")
                p_currentOutputDirectory = Path.GetDirectoryName(outputFileName);
        }
        public void SetOutputType(XplLayerDZoeProgramModuletype_enum moduleType)
        {
            p_outputModuleType = moduleType;
        }


        #endregion

        private void CalcularThrows()
        {
            //Esto es facil:
            //-Con la info de los throws originales de los tipos importados
            //de java y la lista de depedencias de las funciones en los
            //InfoFuncion en p_listInfoFuncion calculamos los throws para 
            //cada funcion y los incorporamos al archivo usando Content 
            //(o sea las lineas en memoria de los ZoeInfoClase
        }


        protected override string renderTypeOfExp(XplType typeofExpNode, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            AddError("The \"typeof\" expression is not implemented on Java Output Module.");
            return "__error__";
        }

        protected override string renderIsExp(XplCastexpression xplExpression, string expStr, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            AddError("The \"is\" expression is not implemented on Java Output Module.");
            return "__error__";
        }
    }
}
