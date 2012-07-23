/*******************************************************************************
* Copyright (c) 2009, 2012 Mateo Bengualid, Intel Corporation.
* All rights reserved. This program and the accompanying materials
* are made available under the terms of the Eclipse Public License v1.0
* which accompanies this distribution, and is available at
* http://www.eclipse.org/legal/epl-v10.html
*
* Contributors:
*       Mateo Bengualid - initial API and implementation
*       Julieta Alvarez (Intel Corporation)
*       Alexis Ferreyra (Intel Corporation)
*******************************************************************************/
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

        internal enum UseofType
        {
            InHeader, InSource, Both
        }
     
        //Class added for support multiple files output - Julieta Alvarez
        public List<string> p_globalImportDirectives = new List<string>();

        #region Datos Privados o Protegidos

        string p_outputFileName = String.Empty;
        bool p_dontWriteCopyrightComment = true;
        bool p_writeDetailedComments = false;
        bool p_applyFormat = true;
        bool p_checkTypes = true;
        bool p_OptimiseParenthesis = true;
        bool p_buildFullType = false;
        bool p_prettyOutput = false;
        bool p_multipleFiles = false;
        bool p_isDebugMode;
        string p_currentFirstBase = "object";
        bool p_generateFieldInitialization = false;

        bool atLeastOneConstructor;
        List<string> currentClassConstructorInitializers = new List<string>();
        List<string> p_classNamesToRemove = new List<string>();

        int p_maxParameter;
        int p_lastCodeStatementLine;

        FunctionType p_currentFunctionType = FunctionType.Method;

        string p_outputPath = null;

        bool p_dontWriteLineDirecties;
        bool p_newFilePerClass;

        XplLayerDZoeProgramModuletype_enum p_outputModuleType = XplLayerDZoeProgramModuletype_enum.EXECUTABLE;
        RenderBuffer p_buffer;

        ErrorCollection p_errors = new ErrorCollection();
        int p_isExternalClass;

        /// <summary>
        /// Key is the name of ObjC anonymous struct/enum like "__apt_anonymous_decl__" or the name of ObjC global dummy class that contain the field declaration
        /// Value is the list of rendered fields (global vars) associated
        /// </summary>
        Dictionary<string, List<XplField>> _anonymousGlobalVars = new Dictionary<string,List<XplField>>();


        string p_globalSourceFile = "main.h";
        static string p_globalClassName = "_global_";
		internal const string CPP_HEADER_METADATA_BEGIN = "%CPP_H[";
		internal const string CPP_HEADER_METADATA_END = "]%";

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
            return Path.GetFileNameWithoutExtension(currentFile) + ".h";
        }

        private string getCodeFileVersion(string currentFile)
        {
            // Remove any extension of three or less letters that the file may have.
            return Path.GetFileNameWithoutExtension(currentFile) + ".cpp";
        }

        private void writeLineDirective(string ldsrc, bool isMaxLine)
        {
            if (!p_dontWriteLineDirecties)
            {
                // TODO : implement
            }
        }

        internal static void ParseZoeSourceInfo(string zoeSourceInfoStr, ref int minLine, ref int maxLine, ref string currentFile)
        {
            string[] data = zoeSourceInfoStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            switch (data.Length)
            {
                case 1:
                    minLine = maxLine = Int32.Parse(data[0], CultureInfo.InvariantCulture);
                    break;
                case 2:
                    minLine = Int32.Parse(data[0], CultureInfo.InvariantCulture);
                    maxLine = Int32.Parse(data[1], CultureInfo.InvariantCulture);
                    break;
                case 3:
                    minLine = Int32.Parse(data[0], CultureInfo.InvariantCulture);
                    maxLine = Int32.Parse(data[1], CultureInfo.InvariantCulture);
                    currentFile = data[2];
                    break;
                case 5:
                    // Parser dpp no te da info de la columna.
                    minLine = Int32.Parse(data[0], CultureInfo.InvariantCulture);
                    maxLine = Int32.Parse(data[2], CultureInfo.InvariantCulture);
                    currentFile = data[4];
                    break;
            }
        }

        private void Write(string str)
        {
            p_buffer.Write(str);
        }
        private void WriteNewLineOfCode()
        {
            p_buffer.WriteNewLineOfCode();
        }
        private void WriteNewLineOfHeader()
        {
            p_buffer.WriteNewLineOfHeader();
        }
        private void WriteNewLineOfBothFiles()
        {
            p_buffer.WriteNewLine();
        }
        private void IncreaseTabulationHeader()
        {
            p_buffer.IncreaseTabulationHeader();
        }
        private void DecreaseTabulationHeader()
        {
            p_buffer.DecreaseTabulationHeader();
        }
        private void DecreaseTabulationSource()
        {
            p_buffer.DecreaseTabulationSource();
        }

        private void IncreaseTabulationSource()
        {
            p_buffer.IncreaseTabulationSource();
        }

        #endregion

        #region AddError,Warning,Comments
        private void writeComment(string comment)
        {
            Write("/*" + comment + "*/");
        }
        private void writeLineComment(string comment)
        {
            Write("/*" + comment + "*/");
            WriteNewLineOfBothFiles();
        }
        private void writeLineCommentHeader(string comment)
        {
            Write("/*" + comment + "*/");
            WriteNewLineOfHeader();
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
            string tempStr = String.Empty;
            switch (storage)
            {
                case XplVarstorage_enum.AUTO:
                    break;
                case XplVarstorage_enum.EXTERN:
                    tempStr = CppKeywords.ExternPC; break;
                case XplVarstorage_enum.STATIC:
                    tempStr = CppKeywords.StaticPC; break;
                case XplVarstorage_enum.STATIC_EXTERN:
                    tempStr = CppKeywords.ExternPC + CppKeywords.StaticPC; break;
                default:
                    AddWarning("Constante de almacenamiento desconocida '" + storage.ToString() + "'.");
                    break;
            }
            return tempStr;
        }

        string getAccess(XplAccesstype_enum access, EZOEContext context, bool bIsMethod)
        {
            return getAccess(access, context, bIsMethod, false);
        }

        string getAccess(XplAccesstype_enum access, EZOEContext context, bool bIsMethod, bool isConstructorOrInterface)
        {
            string retStr = String.Empty;
            switch (access)
            {
                case XplAccesstype_enum.PRIVATE:
                    if (context == EZOEContext.NamespaceBody) retStr = CppKeywords.InternalPC;
                    else retStr = CppKeywords.PrivatePC;
                    break;
                case XplAccesstype_enum.PROTECTED:
                    if (context == EZOEContext.NamespaceBody) retStr = CppKeywords.ProtectedPC + CppKeywords.InternalPC;
                    else retStr = CppKeywords.ProtectedPC;
                    break;
                case XplAccesstype_enum.PUBLIC:
                    {
                        // TODO : change this, slot qt keyword must be rendered taking into account additional meta info and not 
                        // only because we have a method that is not a constructor
                        if (bIsMethod && !isConstructorOrInterface)
                        {
                            retStr = CppKeywords.PublicSlotsPC;
                        }
                        else
                        {
                            retStr = CppKeywords.PublicPC;
                        }
                        break;
                    }

                // Estas son protectores para código inyectado.
                case XplAccesstype_enum.IPRIVATE:
                    AddWarning("Modificador de accesso 'iprivate' inesperado en código EZOE. Usando 'private' en su lugar.");
                    if (context == EZOEContext.NamespaceBody) retStr = CppKeywords.InternalPC;
                    else retStr = CppKeywords.PrivatePC;
                    break;
                case XplAccesstype_enum.IPROTECTED:
                    AddWarning("Modificador de accesso 'iprotected' inesperado en código EZOE. Usando 'private' en su lugar.");
                    if (context == EZOEContext.NamespaceBody) retStr = CppKeywords.InternalPC;
                    else retStr = CppKeywords.PrivatePC;
                    break;
                case XplAccesstype_enum.IPUBLIC:
                    AddWarning("Modificador de accesso 'ipublic' inesperado en código EZOE. Usando 'private' en su lugar.");
                    if (context == EZOEContext.NamespaceBody) retStr = CppKeywords.InternalPC;
                    else retStr = CppKeywords.PrivatePC;
                    break;
                default:
                    AddWarning("Modificador de accesso 'desconocido' inesperado en código EZOE. Usando 'private' en su lugar.");
                    if (context == EZOEContext.NamespaceBody) retStr = CppKeywords.InternalPC;
                    else retStr = CppKeywords.PrivatePC;
                    break;
            }
            return retStr;
        }
        private string renderBaseInitializers(XplBaseInitializers initializers)
        {
            string tempStr = String.Empty;
            if (initializers == null) return String.Empty;
            foreach (XplBaseInitializer initializer in initializers.Children())
            {
                // TODO : Verificar que no rompe algo la simple concatenación en lugar de procesarlo.
                tempStr += initializer.get_className();
                tempStr += "(" + processExpressionList(initializer.get_params(), EZOEContext.FunctionDecl) + ") : ";
                // TODO : Sera un error cuando se posea mas de un inicializador de clase base
            }
            if (tempStr != String.Empty)
                return tempStr.Substring(0, tempStr.Length - 2);
            else
                return String.Empty;
        }
        #endregion

        #region processSimpleTypeName y processUserTypeName

        string processUserTypeName(string typeName)
        {
            typeName = typeName.Replace(".", CppKeywords.ScopePC);

            foreach (string classNameToRemove in p_classNamesToRemove)
            {
                if (typeName.StartsWith(classNameToRemove, StringComparison.InvariantCulture) && typeName.Length > classNameToRemove.Length)
                {
                    typeName = typeName.Substring(classNameToRemove.Length);
                }
            }

            return typeName;
        }

        string processSimpleTypeName(string nt, ref bool isValueType)
        {
            return  processSimpleTypeName(nt, ref isValueType, string.Empty);
        }

        private void AddTypeUsage(string typeStr, bool requiredInHeader, bool requiredInSource, UseofType use)
        {
            if (String.IsNullOrEmpty(typeStr)) return;

            p_buffer.AddRequiredTypeUsage(typeStr, requiredInHeader, requiredInSource, use);
        }

        private bool IsDerivedType(string typeStr)
        {
            return typeStr.Contains("*") || typeStr.Contains("^") || typeStr.Contains("[");
        }

        #endregion

        #region Ayudas para Procesar Tipos
        string getTypeName(XplType type, EZOETypeContext typeContext, ref bool isValueType)
        {
            if (type == null)
            {
                if (typeContext == EZOETypeContext.ReturnTypeDecl)
                    return String.Empty;
                else
                {
                    AddError("Se ha omitido el tipo cuando es requerido. Sólo es posible omitir el tipo en en la declaracion de tipos de retorno de constructores o destructores.");
                    return "__error";
                }
            }
            if (!p_buildFullType)
            {
                string typeStr = type.get_typeStr();
                if (typeStr == String.Empty) return "__error";
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
                if (typeStr[0] == '$') return processSimpleTypeName(typeStr, ref isValueType, type.get_lddata());
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

        private string processSimpleTypeName(string nt, ref bool isValueType, string strLddata)
        {
            string retStr = String.Empty;
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
                    {
                        retStr = "long";
                        if (strLddata.Equals("long long"))
                            retStr += " long";
                        isValueType = true;
                        break;
                    }
                case "$ULONG$":
                    {
                        retStr = "unsigned long";
                        if (strLddata.Equals("unsigned long long"))
                            retStr += " long";

                        isValueType = true;
                        break;
                    }
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
                    {
                        if (strLddata == string.Empty)
                            retStr = "char";
                        else
                            retStr = "signed char";
                        isValueType = true;
                        break;
                    }
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
                    retStr = String.Empty;
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
        static string getPointerStr(XplType type, EZOETypeContext context, bool isValueType)
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
                        if (currentType.get_pi().get_const()) retStr += CppKeywords.ConstPC;
                        if (currentType.get_pi().get_volatile()) retStr += CppKeywords.VolatilePC;                        
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
        private bool requireParenthesis(XplAssing xAssign)
        {
            XplNode parent = xAssign.get_Parent().get_Parent().get_Parent();
            if (parent != null && parent.get_TypeName() == CodeDOMTypes.XplExpression)
            {
                //Si el parent no es nulo y es otra expresion
                if (getExpressionPrecedence((XplExpression)parent) > (int)Precedences.AssingExp) return true; 
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
        static int getOperatorPrecedence(XplBinaryoperators_enum op)
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
                case XplBinaryoperators_enum.COMMA:// Comma Operator
                    retVal = -15; break;
                
                //Condicional retVal=13
                //Asignacion retVal=14
            }
            #endregion
            return retVal;
        }
        static int getOperatorPrecedence(XplUnaryoperators_enum op)
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

        private bool FieldIsFromEnum(XplField fieldDecl, out bool bIsTheLastField)
        {
            bIsTheLastField = false; //Is this the last field of enum?

            XplClass classNode = (XplClass)fieldDecl.get_Parent();
            if (classNode.get_isenum())
            {
                int iCount = 0;
                foreach (XplField field in classNode.get_FieldNodeList())
                {
                    iCount++;
                    if (fieldDecl.get_name() == field.get_name())
                        break;
                }
                bIsTheLastField = iCount == classNode.get_FieldNodeList().GetLength();
            }
            return classNode.get_isenum();
        }

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
            + " Generated by: C++ LayerD Generator - ZOE Output Module to C++\n"
            + " Please visit http://layerd.net to get last version of LayerD tools.\n"
            + "---------------------------------------------------------------------";

            if (!p_dontWriteCopyrightComment)
            {
                writeLineComment(temp);
                WriteNewLineOfBothFiles();
            }

            writeLineDirective(documentBody.get_ldsrc(), false);
        }

        /// <summary>
        /// Renders the end document body.
        /// </summary>
        /// <param name="documentBody">The document body.</param>
        protected override void renderEndDocumentBody(XplDocumentBody documentBody)
        {            
            WriteNewLineOfBothFiles();
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
            foreach (XplNode node in importDirective.Children())
            {
                string tempStr = node.get_StringValue();

                if (tempStr.IndexOf('=') != -1)
                {
                    flag = true;
                    string parameterName = tempStr.Substring(0, tempStr.IndexOf('=')).ToLower(CultureInfo.InvariantCulture);
                    string parameterValue = tempStr.Substring(tempStr.IndexOf('=') + 1);
                    switch (parameterName)
                    {
                        case "header":
                            if(parameterValue[0]=='<')
                                usingString = CppKeywords.IncludePC + parameterValue;
                            else
                                usingString = CppKeywords.IncludePC + "\"" + parameterValue + "\"";
                            break;
                        case "mockclass":
                            p_classNamesToRemove.Add(parameterValue.Replace(".", CppKeywords.ScopePC) + CppKeywords.ScopePC);
                            break;
                        case "externc":
                            // TODO: complete
                            break;
                        case "ns":
                            parameterValue = parameterValue.Replace(".", CppKeywords.ScopePC) + CppKeywords.ScopePC;
                            if (!p_classNamesToRemove.Contains(parameterValue))
                                p_classNamesToRemove.Add(parameterValue);
                            break;
                    }
                }
            }
            if (flag && usingString != null)
            {
                AddNewImportDirective(usingString);
            }
        }

        private void AddNewImportDirective(string strImportDirective)
        {
            if (!p_globalImportDirectives.Contains(strImportDirective))
                p_globalImportDirectives.Add(strImportDirective);
        }
        /// <summary>
        /// Renders the begin namespace.
        /// </summary>
        /// <param name="namespaceName">Name of the namespace.</param>
        /// <param name="namespaceDecl">The namespace decl.</param>
        /// <param name="context">The context.</param>
        protected override void renderBeginNamespace(string namespaceName, XplNamespace namespaceDecl, EZOEContext context)
        {

        }

        /// <summary>
        /// Renders the end namespace.
        /// </summary>
        /// <param name="namespaceName">Name of the namespace.</param>
        /// <param name="namespaceDecl">The namespace decl.</param>
        /// <param name="context">The context.</param>
        protected override void renderEndNamespace(string namespaceName, XplNamespace namespaceDecl, EZOEContext context)
        {

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

            if (classDecl.get_externalname() != String.Empty)
                className = classDecl.get_externalname();

            //Si la clase es externa levanto la bandera y retorno
            if (classDecl.get_external())
            {
                if (IsObjCDummyGlobalClass(classDecl))
                {
                    CheckBuffer(classDecl);
                }
                if (classDecl.get_lddata().Contains(CPP_HEADER_METADATA_BEGIN))
                {
                    RegisterExternClassMetadata(classDecl);
                }
                p_isExternalClass++;
                return;
            }

            // check for new buffer
            CheckBuffer(classDecl);

            // register user type in buffer
            p_buffer.RegisterUserDefinedType(classDecl);

            // If the class name is the universal mock class, then ignore further processing.
            if (className == CppKeywords.UniversalMockClassName)
            {
                return;
            }

            WriteNewBlankLineOfHeader();

            RenderComments(classDecl);

            // If the className is the name of the global class, It is ignored for the output
            if(IsObjCDummyGlobalClass(classDecl))
            {	
                return; 
            }

            writeLineDirective(classDecl.get_ldsrc(), false);

            // Modifiers
            if (isNew) Write(CppKeywords.NewPC);
            if (isAbstract) Write(CppKeywords.AbstractPC);

            //name declaration
            switch (classType)
            {
                case EZOEClassType.Class:
                    Write(CppKeywords.ClassPC + className);
                    break;
                case EZOEClassType.Interface:
                    Write(CppKeywords.ClassPC + className);
                    break;
                case EZOEClassType.Enum:
                case EZOEClassType.Union:
                case EZOEClassType.Struct:
                    string keyword = classType == EZOEClassType.Struct ? CppKeywords.StructPC : (classType == EZOEClassType.Union ? CppKeywords.UnionPC : CppKeywords.EnumPC);
                    if (CanRemoveClassNameFromDeclaration(classDecl))
                    {
                        RegisterAnonymousType(classDecl);
                        className = String.Empty;
                    }
                    if (classDecl.get_access() == XplAccesstype_enum.PRIVATE)
                    {
                        Write(CppKeywords.PrivatePC + keyword + className);
                    }
                    else
                    {
                        Write(keyword + className);
                    }
                    break;
                default:
                    throw new Exception("unexpected internal value rendering a class node.");
            }

            //Inherits
            if (inheritsStr != String.Empty || implementsStr != String.Empty)
            {
                Write(": " + inheritsStr);
                RegisterInheritsTypes(classDecl.get_InheritsNodeList());
            }
            if (implementsStr != String.Empty)
            {
                if (inheritsStr != String.Empty) Write(", " + implementsStr);
                else Write(implementsStr);
                RegisterInheritsTypes(classDecl.get_ImplementsNodeList());
            }
            WriteNewLineOfHeader();
            Write("{");
            WriteNewLineOfHeader();
            IncreaseTabulationHeader();

            // if it´s originally an ObjC interface we want to implement Q_OBJECT
            // and default constructor
            if (classDecl.get_lddata().Contains("%OBJC_INTERFACE_DECL%"))
            {
                Write("Q_OBJECT");
                WriteNewLineOfHeader();
                WriteNewLineOfHeader();
                XplNodeList fields = classDecl.get_FieldNodeList();
                if (fields.GetLength() > 0)
                {
                    writeDefaultConstructorForObjC(className, fields);
                }
            }

            if (p_prettyOutput)
            {
                p_lastCodeStatementLine = 0;
            }
        }

        private void RegisterExternClassMetadata(XplClass classDecl)
        {
            p_buffer.RegisterExternType(classDecl);
        }

        private void WriteNewBlankLineOfHeader()
        {
            p_buffer.WriteNewBlankLineOfHeader();
        }

        private void RegisterAnonymousType(XplClass classDecl)
        {
            p_buffer.RegisterAnonymousType(classDecl);
        }

        private bool CanRemoveClassNameFromDeclaration(XplClass classDecl)
        {
            // needs to be anonymn and not moved from original context
            if (IsObjCAnonymousType(classDecl) && MantainOriginalObjCDeclarationContext(classDecl))
            {
                return true;
            }
            return false;
        }

        private static bool IsObjCAnonymousType(XplClass classDecl)
        {
            return classDecl.get_name().Contains(ObjectiveCFlags.ANONYMOUS_DECL);
        }

        private void RegisterInheritsTypes(XplNodeList list)
        {
            foreach (XplInherits inhs in list)
            {
                var typeList = inhs.FindNodes("@XplType");
                foreach (XplType type in typeList)
                {
                    //The user type is added to a buffer of UserTypes
                    AddTypeUsage(type.get_typename(), true, false, UseofType.InHeader);
                }
            }
        }

        private void writeDefaultConstructorForObjC(string className, XplNodeList fields)
        {
            // header
            Write(CppKeywords.PublicPC + className + "();");
            WriteNewLineOfHeader();

            // implementation
            Write(className + "::" + className + "()");
            WriteNewLineOfCode();
            Write("{");
            WriteNewLineOfCode();
            IncreaseTabulationSource();

            foreach (XplField field in fields)
            {
                XplType fieldType = field.get_type();
                string fieldName = field.get_name();

                // do not initialize if its const, static or extern
                if (fieldType.get_const() || field.get_storage() != XplVarstorage_enum.AUTO) continue;

                if (fieldType.get_ispointer())
                {
                    Write("this->" + fieldName + " = NULL;");
                    WriteNewLineOfCode();
                }
                else if (fieldType.get_isarray())
                {
                    // do not initialize...
                }
                else if(fieldType.get_typename().StartsWith("$", StringComparison.InvariantCulture))
                {
                    switch (fieldType.get_typename())
                    {
                        case "$INTEGER$":
                        case "$UNSIGNED$":
                        case "$LONG$":
                        case "$ULONG$":
                        case "$SHORT$":
                        case "$USHORT$":
                        case "$SBYTE$":
                        case "$BYTE$":
                        case "$FLOAT$":
                        case "$DOUBLE$":
                        case "$LDOUBLE$":
                        case "$DECIMAL$":
                        case "$FIXED$":
                        case "$CHAR$":
                            Write("this->" + fieldName + " = 0;");
                            break;
                        case "$BOOLEAN$":
                            Write("this->" + fieldName + " = false;");
                            break;
                        default:
                            // do nothing for other types
                            break;
                    }
                    WriteNewLineOfCode();
                }
            }

            DecreaseTabulationSource();
            Write("}");
            WriteNewLineOfCode();
            WriteNewLineOfCode();
        }

        private void CheckBuffer(XplNode node)
        {
            p_buffer.ChangeBufferIfNeeded(node);
        }

        private int getFirstLineOfBuffer(ArrayList bufferList)
        {
			for (int n = bufferList.Count - 1; n >= 0; n--)
            {
                var line = (string)(bufferList[n]);
                line = line.Trim('\t', ' '); 
                if (! (line.StartsWith("//", StringComparison.CurrentCulture) || line.Equals(string.Empty)) )
				return n+1;
			}
			
			return 0;
        }

        private string FixFileName(string strSourceFile)
        {
            if (Path.DirectorySeparatorChar == '/')
            {
                return strSourceFile.Replace('\\', '/');
            }
            else
            {
                return strSourceFile.Replace('/', '\\');
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
            // Si la clase actual es externa retorno
            if (p_isExternalClass > 0)
            {
                if (classDecl.get_external()) p_isExternalClass--;
                return;
            }

            // I remove the class creation for the global class because is an artificial class used by zoe - Commented by Julieta Alvarez
            if (!IsObjCDummyGlobalClass(classDecl))
            {
                // If the class name is the universal mock class, then ignore further processing.
                if (className == CppKeywords.UniversalMockClassName)
                {
                    return;
                }

                // render initializer of fields and default constructor if not provided
                if (!classDecl.get_isenum() && !classDecl.get_isstruct() && !classDecl.get_isinteractive() && !classDecl.get_isunion())
                {
                    //With the comment added in renderField method, currentClassConstructorInitializers should not have initializations - Julieta Alvarez 
                    // Render the initializer method in the header.
                    if (currentClassConstructorInitializers.Count > 0)
                    {
                        writeLineComment("This method is provided to initialize all variables.");
                        Write(CppKeywords.PrivatePC + "inline void " + CppKeywords.InitializerMethodName + "();");
                        WriteNewLineOfHeader();

                        // Render the initializer method in the code.

                        if (className != CppKeywords.UniversalMockClassName
                            && !p_classNamesToRemove.Contains(className))
                        {
                            Write("inline void " + className + CppKeywords.ScopePC + CppKeywords.InitializerMethodName + "() {");
                        }
                        else
                        {
                            Write("inline void " + CppKeywords.InitializerMethodName + "() {");
                        }
                        IncreaseTabulationHeader();
                        foreach (string initialization in currentClassConstructorInitializers)
                        {
                            Write(initialization);
                        }
                        DecreaseTabulationHeader();
                        Write("}");
                        WriteNewLineOfCode();

                        // If a constructor was not included, provide a default one.
                        if (!atLeastOneConstructor && !classDecl.get_isinterface())
                        {
                            // Define in the header file.
                            writeLineCommentHeader("This default constructor is provided to initialize all variables.");
                            Write(CppKeywords.PublicPC + className + "();");
                            WriteNewLineOfHeader();

                            // Implement in the code file.
                            Write(className + CppKeywords.ScopePC + className + "() { " + CppKeywords.InitializerMethodName + "(); }");
                            WriteNewLineOfCode();
                        }
                    }
                }

                writeLineDirective(classDecl.get_ldsrc(), true);
                DecreaseTabulationHeader();
                if (IsObjCAnonymousType(classDecl))
                {
                    Write("}");
                    renderObjCGlobalVarsForAnonymousType(classDecl, className);
                }
                else
                {
                    Write("};");
                }
                WriteNewLineOfHeader();
                WriteNewLineOfHeader();
            }
        }

        private void renderObjCGlobalVarsForAnonymousType(XplClass classDecl, string className)
        {
            var list = _anonymousGlobalVars.ContainsKey(className) ? _anonymousGlobalVars[className] : null;
            if (list == null)
            {
                Write(";");
                return;
            }

            int count = 0;
            foreach (var field in list)
            {
                if (count > 0) Write(", ");
                else Write(" ");
                Write(field.get_name());
                string initializerStr = processInitializer(field.get_i(), EZOEContext.ClassBody);
                // Check if an initializer string is employed.                
                if (initializerStr != String.Empty)
                {
                    if (initializerStr[0] != '(')
                    {
                        Write(" = " + initializerStr);
                    }
                    else
                    {
                        Write(initializerStr);
                    }
                }
                count++;
            }
            Write(";");
        }

        internal static bool IsObjCDummyGlobalClass(XplClass classDecl)
        {
            return (classDecl.get_name().StartsWith(p_globalClassName, StringComparison.InvariantCulture) &&
                    classDecl.get_lddata().Equals(ObjectiveCFlags.OBJC_GLOBAL_CLASS_TAG));
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
            string temp = String.Empty;
            XplInherit imp = null;
            XplInherits imps = null;
            foreach (XplInherits node in implements)
            {
                imps = node;
                foreach (XplInherit node2 in imps.Children())
                {
                    imp = node2;
                    string typeNameStr = imp.get_type().get_typename();
                    temp += "public " + (node2.get_virtual() ? CppKeywords.VirtualPC : String.Empty) + processUserTypeName(typeNameStr) + ", ";
                }
            }
            if (!String.IsNullOrEmpty(temp)) temp = temp.Substring(0, temp.Length - 2);
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
            string temp = String.Empty;
            bool isFirstBase = true;

            // The enumerations and structures don't have inheritance 
            if (!classDecl.get_isenum() && !classDecl.get_isstruct() && !classDecl.get_isunion())
            {
                XplInherit inh = null;
                XplInherits inhs = null;
                foreach (XplNode node in inherits)
                {
                    inhs = (XplInherits)node;
                    foreach (XplNode node2 in inhs.Children())
                    {
                        inh = (XplInherit)node2;
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
                        
                        string processedUserTypeName = processUserTypeName(inh.get_type().get_typename());
                        if (processedUserTypeName.Equals("zoe::lang::Object"))
                        {
                            if (classDecl.get_isinterface() && classDecl.get_lddata().Contains(ObjectiveCFlags.OBJC_PROTOCOL_TAG))
                            {
                                // for ObjC protocols ignore default base class
                                continue;
                            }
                            processedUserTypeName = "QObject";
                        }
                        else
                        {
                            if (inh.get_virtual()) temp += CppKeywords.VirtualPC;
                        }

                        temp += accessStr + processedUserTypeName + ", ";
                        if (isFirstBase)
                        {
                            p_currentFirstBase = processedUserTypeName;
                            isFirstBase = false;
                        }
                    }
                }
                if (temp != String.Empty) temp = temp.Substring(0, temp.Length - 2);
            }
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
			bool isGlobalClass = IsObjCDummyGlobalClass((XplClass)functionDecl.get_Parent());
			
            //Si la clase actual es externa retorno
            if (p_isExternalClass > 0 || functionStorage == XplVarstorage_enum.EXTERN || functionStorage == XplVarstorage_enum.STATIC_EXTERN)
            {
                return;
            }

            // check for new buffer
            if (IsObjCDummyGlobalClass(functionDecl.CurrentClass))
            {
                CheckBuffer(functionDecl);
            }

            writeLineDirective(functionDecl.get_ldsrc(), false);

            string baseInitializers = renderBaseInitializers(functionDecl.get_BaseInitializers());

            bool isInterface = functionDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplClass && functionDecl.CurrentClass.get_isinterface();

            //Ajusto el nombre de la funcion al nombre externo si es necesario
            if (functionDecl.get_externalname() != String.Empty)
            {
                functionName = functionDecl.get_externalname();
            }

            // Si el nombre de la clase es el de la función y la función no es estática,
            // o si tanto la clase como el ns no son ficticios, imprimir el modificador de
            // acceso.
            if ((functionDecl.CurrentNamespace.get_name() != CppKeywords.UniversalMockNamespaceName ||
                functionDecl.CurrentClass.get_name() != CppKeywords.UniversalMockClassName) &&
                !isGlobalClass)
            {
                Write(getAccess(access, context, true, IsConstructor(functionDecl, functionName) || isInterface ));
            }

            // Output the comments of the method declaration.
            RenderComments(functionDecl);

            // render storage class if it's not a global function
            if (!isGlobalClass)
            {
				Write(getStorage(functionStorage, context));
            }

            if (isVirtual || isInterface) Write(CppKeywords.VirtualPC);

            if (isFp)
            { 
                // function pointer type decl
                // TODO : Remove for C++
                AddError("Wait for delegate implementation soon.");
            }
            if (functionName.IndexOf("%indexer%", StringComparison.InvariantCulture) >= 0)
            {
                // TODO : remove, this is for C#
                functionName = functionName.Replace("%indexer%", String.Empty);
                functionName += CppKeywords.IndexerPC;
                p_currentFunctionType = FunctionType.Indexer;
            }
            else if (functionName.IndexOf("%op_", StringComparison.InvariantCulture) >= 0)
            {
                // TODO : this code is from C# code generation, won't work for C++
                p_currentFunctionType = FunctionType.Operator;
                #region Nombres de Operadores
                switch (functionName)
                {
                    case "%op_gtr%":
                        functionName = CppKeywords.OperatorPC + ">";
                        break;
                    case "%op_lst%":
                        functionName = CppKeywords.OperatorPC + "<";
                        break;
                    case "%op_bneg%":
                        functionName = CppKeywords.OperatorPC + "!";
                        break;
                    case "%op_comp%":
                        functionName = CppKeywords.OperatorPC + "~";
                        break;
                    case "%op_eq%":
                        functionName = CppKeywords.OperatorPC + "==";
                        break;
                    case "%op_lseq%":
                        functionName = CppKeywords.OperatorPC + "<=";
                        break;
                    case "%op_greq%":
                        functionName = CppKeywords.OperatorPC + ">=";
                        break;
                    case "%op_noteq%":
                        functionName = CppKeywords.OperatorPC + "!=";
                        break;
                    case "%op_and%":
                        functionName = CppKeywords.OperatorPC + "&&";
                        break;
                    case "%op_or%":
                        functionName = CppKeywords.OperatorPC + "||";
                        break;
                    case "%op_inc%":
                        functionName = CppKeywords.OperatorPC + "++";
                        break;
                    case "%op_dec%":
                        functionName = CppKeywords.OperatorPC + "--";
                        break;
                    case "%op_add%":
                        functionName = CppKeywords.OperatorPC + "+";
                        break;
                    case "%op_min%":
                        functionName = CppKeywords.OperatorPC + "-";
                        break;
                    case "%op_mul%":
                        functionName = CppKeywords.OperatorPC + "*";
                        break;
                    case "%op_div%":
                        functionName = CppKeywords.OperatorPC + "/";
                        break;
                    case "%op_band%":
                        functionName = CppKeywords.OperatorPC + "&";
                        break;
                    case "%op_bor%":
                        functionName = CppKeywords.OperatorPC + "|";
                        break;
                    case "%op_xor%":
                        functionName = CppKeywords.OperatorPC + "^";
                        break;
                    case "%op_mod%":
                        functionName = CppKeywords.OperatorPC + "%";
                        break;
                    case "%op_lsh%":
                        functionName = CppKeywords.OperatorPC + "<<";
                        break;
                    case "%op_rsh%":
                        functionName = CppKeywords.OperatorPC + ">>";
                        break;
                    case "%op_new%":
                        AddError("No se puede sobrecargar el operador 'new'.");
                        functionName = CppKeywords.OperatorPC + "_new";
                        break;
                    case "%op_delete%":
                        AddError("No se puede sobrecargar el operador 'delete'.");
                        functionName = CppKeywords.OperatorPC + "_delete";
                        break;
                    case "%op_explicit%":
                        AddWarning("Operadores de conversion no implementados en el modulo de salida.");
                        functionName = CppKeywords.ExplicitPC + CppKeywords.OperatorPC + "T";
                        break;
                    case "%op_implicit%":
                        AddWarning("Operadores de conversion no implementados en el modulo de salida.");
                        functionName = CppKeywords.ImplicitPC + CppKeywords.OperatorPC + "T";
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
                p_currentFunctionType = FunctionType.Method;
            }
            Write(returnTypeStr + " ");

            // register type usage
            if (functionDecl.get_ReturnType() != null)
            {
                string typeStr = functionDecl.get_ReturnType().get_typeStr();
                bool required = !IsDerivedType(typeStr);
                AddTypeUsage(typeStr, required, required, UseofType.Both);
            }

            Write(functionName);
            if (p_currentFunctionType == FunctionType.Indexer)
            {
                Write("[" + parametersStr + "]");
            }
            else
            {
                Write("(" + parametersStr + ")");
            }

            if (isConst) Write(CppKeywords.ConstPC);

            if (isInterface || functionDecl.get_abstract()) Write(" = 0");
            Write(";");

            // The header has the whole signature.
            WriteNewLineOfHeader();

            if (!isAbstract && functionStorage != XplVarstorage_enum.EXTERN && functionStorage != XplVarstorage_enum.STATIC_EXTERN
                && !isInterface)
            {
                // The code file has the following: TYPE CLASS::METHOD(parameters){
                Write(returnTypeStr + " ");

                // If the class that contains the function is the universal mock class, ignore the class name.
                if (functionDecl.CurrentClass.get_name() != CppKeywords.UniversalMockClassName &&
                    !IsObjCDummyGlobalClass(functionDecl.CurrentClass))
                {
                    Write(functionDecl.CurrentClass.get_name() + CppKeywords.ScopePC);
                }

                Write(functionName);

                if (p_currentFunctionType == FunctionType.Indexer)
                    Write("[" + parametersStr + "]");
                else
                    Write("(" + parametersStr + ")");


                if (baseInitializers != "") Write(": " + baseInitializers);

                WriteNewLineOfCode();
                Write("{");
                WriteNewLineOfCode();
                IncreaseTabulationSource();
            }

            // If the name of the function is the same as the name of the class, then
            // assume a constructor and include the call to the initializer after the
            // first line.
            if (p_generateFieldInitialization && IsConstructor(functionDecl, functionName))
            {
                atLeastOneConstructor = true;

                // Include the call to the initializer. If there is no initialization,
                // then the compiler will remove the call to the empty function.
                Write(CppKeywords.InitializerMethodName + "();");
                WriteNewLineOfCode();
            }
        }

        private static bool IsConstructor(XplFunction functionDecl, string functionName)
        {
            // TODO : if it's a constructor must be defined by zoe compiler with additional metainfo
            // or queried from the last types table
            return functionName == functionDecl.CurrentClass.get_name();
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

            if (p_isExternalClass > 0 || functionStorage == XplVarstorage_enum.EXTERN || functionStorage == XplVarstorage_enum.STATIC_EXTERN)
            {
                return;
            }

            if (!isAbstract && functionStorage != XplVarstorage_enum.EXTERN && functionStorage != XplVarstorage_enum.STATIC_EXTERN
                && !(functionDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplClass && functionDecl.CurrentClass.get_isinterface()))
            {
                DecreaseTabulationSource();
                Write("}");
                WriteNewLineOfCode();
                WriteNewLineOfCode();
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

        }

        /// <summary>
        /// Renders the end property.
        /// </summary>
        /// <param name="propertyDecl">The property decl.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="context">The context.</param>
        protected override void renderEndProperty(XplProperty propertyDecl, string propertyName, EZOEContext context)
        {

        }

        /// <summary>
        /// Renders the begin get access.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="body">The body.</param>
        protected override void renderBeginGetAccess(EZOEContext context, XplFunctionBody body)
        {

        }

        /// <summary>
        /// Renders the end get access.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="body">The body.</param>
        protected override void renderEndGetAccess(EZOEContext context, XplFunctionBody body)
        {

        }

        /// <summary>
        /// Renders the begin set access.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="body">The body.</param>
        protected override void renderBeginSetAccess(EZOEContext context, XplFunctionBody body)
        {

        }
        /// <summary>
        /// Renders the end set access.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="body">The body.</param>
        protected override void renderEndSetAccess(EZOEContext context, XplFunctionBody body)
        {

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

            bool isFromObjCGlobalClass = IsObjCDummyGlobalClass(fieldDecl.CurrentClass);

            if (isFromObjCGlobalClass && IsFieldFromObjCAnonymousType(fieldDecl))
            {
                return;
            }

            if (fieldDecl.get_externalname() != String.Empty)
            {
                fieldName = fieldDecl.get_externalname();
            }

            // check for new buffer
            if (IsObjCDummyGlobalClass(fieldDecl.CurrentClass))
            {
                CheckBuffer(fieldDecl);
            }

            writeLineDirective(fieldDecl.get_ldsrc(), false);

            bool bIsTheLastFieldOfEnum;

            if (!FieldIsFromEnum(fieldDecl, out bIsTheLastFieldOfEnum))
            {
                //The new user type is added
                AddTypeUsage(fieldDecl.get_type().get_typeStr(), !IsDerivedType(fieldDecl.get_type().get_typeStr()), true, UseofType.Both);

                RenderComments(fieldDecl);

                if (!isFromObjCGlobalClass)
                {
                    Write(getAccess(access, EZOEContext.ClassDecl, false));
                }

                if (fieldDecl.get_lddata().Equals("extern"))
                {
                    Write(CppKeywords.ExternPC);
                }

                Write(getStorage(fieldStorage, EZOEContext.ClassBody));
                if (isNew) Write(CppKeywords.NewPC);

                XplType xType = fieldDecl.get_type();
                if (xType.get_const()) Write(CppKeywords.ConstPC);
                if (xType.get_volatile()) Write(CppKeywords.VolatilePC);

                Write(typeStr);
                
                // Check if an initializer string is employed.                
                if (initializerStr != String.Empty)
                {
                    if (initializerStr[0] != '(')
                    {
                        Write(" = " + initializerStr);
                        // I commented this lines because I don't need an artificial constructor to initialize global variables - Commented by Julieta Alvarez
                        // Load the initialization string into the constructor initialization method.
                        // currentClassConstructorInitializers.Add(fieldName + " = " + initializerStr + ";\n");
                    }
                    else
                    {
                        Write(initializerStr);
                    }
                }
                Write(";");
                if (p_writeDetailedComments)
                {
                    writeComment("campo '" + fieldName + "'");
                }
            }
            else
            { //Es un campo de una enumeración
                RenderComments(fieldDecl);
                Write(fieldDecl.get_name());
                if (initializerStr != String.Empty)
                {
                    if (initializerStr[0] != '(') Write(" = " + initializerStr);
                    else Write(initializerStr);
                }
                if (!bIsTheLastFieldOfEnum)
                {
                    Write(", ");
                }
            }

            if (!IsObjCDummyGlobalClass(fieldDecl.CurrentClass) || fieldDecl.get_ldsrc().EndsWith(".h", StringComparison.InvariantCulture))
            {
                WriteNewLineOfHeader();
            }
            else
            {
                WriteNewLineOfCode();
            }

        }

        private bool IsFieldFromObjCAnonymousType(XplField fieldDecl)
        {
            string className = fieldDecl.CurrentClass.get_name();
            var list = _anonymousGlobalVars.ContainsKey(className) ? _anonymousGlobalVars[className] : null;
            if (list == null) return false;

            return list.Contains(fieldDecl);
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
            string retStr = String.Empty;
            if (isParams) retStr += CppKeywords.ParamsPC;
            
            if (isVolatile)
                retStr += CppKeywords.VolatilePC;

            if (parameter.get_type() != null && parameter.get_type().get_const())
                retStr += CppKeywords.ConstPC;

            if (parameterNumber != p_maxParameter) retStr += typeStr + ", ";
            else retStr += typeStr;
            
            if (initializerStr != String.Empty)
            {
                // AddError("Los parametros no pueden declarar valores por defecto en .NET.");
                retStr += " = " + initializerStr;
            }

            //The new user type is added to a list
            AddTypeUsage(parameter.get_type().get_typeStr(), IsINParameterDirection(parameterDirection) && IsATypeByValue(parameter.get_type()), true, UseofType.Both);
            return retStr;

        }

        private bool IsATypeByValue(XplType type)
        {
            return type.get_typename() != string.Empty && type.get_dt() == null;
        }

        private bool IsINParameterDirection(XplParameterdirection_enum parameterDirection)
        {
            return parameterDirection == XplParameterdirection_enum.IN;
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
            if (typeContext == EZOETypeContext.CatchVarDecl)
            {
                AddTypeUsage(type.get_typeStr(), false, true, UseofType.InSource);
            }

            string typeStr = String.Empty, arrayStr = String.Empty, pointerStr = String.Empty;
            bool isValueType = false;
            typeStr += getTypeName(type, typeContext, ref isValueType);

            if (p_checkTypes) checkPointerType(type, typeContext);
            pointerStr = getPointerStr(type, typeContext, isValueType);
            if (pointerStr != String.Empty) typeStr += pointerStr;
            arrayStr = getArrayStr(type, typeContext, context, isValueType);
            switch (typeContext)
            {
                case EZOETypeContext.CatchVarDecl:
                case EZOETypeContext.FieldDecl:
                case EZOETypeContext.ForVarDecl:
                case EZOETypeContext.LocalVarDecl:
                    typeStr += " " + declareName;
                    break;
                case EZOETypeContext.ParameterDecl:
                    if (type.get_Parent().get_TypeName() == CodeDOMTypes.XplParameter)
                    {
                        XplParameter parameter = (XplParameter)type.get_Parent();
                        switch (parameter.get_direction())
                        {
                            case XplParameterdirection_enum.IN:
                                typeStr += " " + declareName;
                                break;
                            case XplParameterdirection_enum.INOUT:
                            case XplParameterdirection_enum.OUT:
                                typeStr += "& " + declareName;
                                break;
                        }
                    }
                    else
                    {
                        // THIS IS AN ERROR, THE PARENT MUST ALWAYS BE A PARAMETER
                        typeStr += " " + declareName;
                    }
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

            if (arrayStr != String.Empty) typeStr += arrayStr;

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

            if (context == EZOEContext.FunctionBody &&
                functionBody.get_Parent().get_TypeName() != CodeDOMTypes.XplFunctionBody ||
                functionBody.get_Parent().get_TypeName() == CodeDOMTypes.XplFunctionBody &&
                functionBody.get_DeclsNodeList().GetLength() > 0)
            {
                WriteNewLineOfCode();
                Write("{");
                WriteNewLineOfCode();
                IncreaseTabulationSource();
            }
        }
        /// <summary>
        /// Renders the end block.
        /// </summary>
        /// <param name="functionBody">The function body.</param>
        /// <param name="context">The context.</param>
        protected override void renderEndBlock(XplFunctionBody functionBody, EZOEContext context)
        {
            if (context == EZOEContext.FunctionBody &&
                functionBody.get_Parent().get_TypeName() != CodeDOMTypes.XplFunctionBody ||
                functionBody.get_Parent().get_TypeName() == CodeDOMTypes.XplFunctionBody &&
                functionBody.get_DeclsNodeList().GetLength() > 0)
            {
                DecreaseTabulationSource();
                Write("}");
                WriteNewLineOfCode();
            }
        }
        /// <summary>
        /// Renders the label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="context">The context.</param>
        protected override void renderLabel(XplNode label, EZOEContext context)
        {
            Write(label.get_StringValue() + ":");
            WriteNewLineOfCode();
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
            if (node.get_doc() != null && node.get_doc() != String.Empty)
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
                            Write("// " + comment);
                        }
                        else
                        {
                            Write("// " + comment);
                        }
                        WriteNewLineOfBothFiles();
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
            if (expressionString != String.Empty)
            {
                if (p_prettyOutput) UpdateLastStatementLine(expression);
                RenderComments(expression);
                writeLineDirective(expression.get_ldsrc(), false);
                if (expressionString[0] == '[')
                {
                    //es un atributo, hacerlo annotation.
                    expressionString.Replace('[', '@');
                    expressionString = expressionString.Remove(expressionString.Length - 1);
                    Write(expressionString);
                }
                else
                {
                    Write(expressionString + ";");
                }

                // Verify that the context allows the line in both the header and the file, or for only one of them.
                if (context == EZOEContext.FunctionBody)
                {
                    // Print only in the code file.
                    WriteNewLineOfCode();
                }
                else
                {
                    // Print in both files.
                    WriteNewLineOfBothFiles();
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
                ParseZoeSourceInfo(node.get_ldsrc(), ref minLine, ref  maxLine, ref trashData);
                if (minLine != 0)
                {
                    p_lastCodeStatementLine = minLine;
                    if (minLine > backupLine + 1 && backupLine != 0)
                    {
                        WriteNewLineOfCode();
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
            Write(CppKeywords.ThrowPC + expressionString + ";");
            WriteNewLineOfCode();
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
            if (p_prettyOutput) UpdateLastStatementLine(returnExpression);

            if (expressionString == String.Empty)
            {
                Write(CppKeywords.ReturnPC + ";");
            }
            else
            {
                Write(CppKeywords.ReturnPC + " " + expressionString + ";");
            }
            WriteNewLineOfCode();
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

            //I added the static word for local variables' declaration - Commented by Julieta Alvarez
            if (decl.get_lddata().Equals(ObjectiveCFlags.StaticPC)) Write(CppKeywords.StaticPC);
            
            XplType type = decl.get_type();
                        
            if (type.get_const()) Write(CppKeywords.ConstPC);
            if (type.get_volatile()) Write(CppKeywords.VolatilePC); //if (isVolatile) writeOut(CppKeywords.VolatilePC);
            Write(typeStr);

            // if there is initializer render it
            if (!String.IsNullOrEmpty(initializerStr) && decl.get_i() != null && decl.get_i().Children().FirstNode() != null)
            {
                if (decl.get_i().Children().FirstNode().get_ElementName() != "list" || initializerStr[0] != '(') Write(" = " + initializerStr);
                else Write(initializerStr);
            }
            Write(";");
            // The local declarator is only in the header. (?)
            WriteNewLineOfCode();
            AddTypeUsage(type.get_typeStr(), false, true, UseofType.InSource);
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
            Write(CppKeywords.SwitchPC + "(" + boolExpStr + ")");
            WriteNewLineOfCode();
            Write("{");
            WriteNewLineOfCode();
            IncreaseTabulationSource();
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
            if (p_isOnCase) DecreaseTabulationSource();
            if (caseExpStr == String.Empty)
                Write(CppKeywords.DefaultPC + ":");
            else
                Write(CppKeywords.CasePC + caseExpStr + ":");
            p_isOnCase = true;
            WriteNewLineOfCode();
            IncreaseTabulationSource();
        }
        /// <summary>
        /// Renders the end switch.
        /// </summary>
        /// <param name="switchSta">The switch sta.</param>
        /// <param name="context">The context.</param>
        protected override void renderEndSwitch(XplSwitchStatement switchSta, EZOEContext context)
        {
            if (p_isOnCase) DecreaseTabulationSource();
            p_isOnCase = false;
            DecreaseTabulationSource();
            Write("}");
            WriteNewLineOfCode();
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
                Write(CppKeywords.IfPC + "(" + boolExp + ")");
            }
            else
            {
                Write(CppKeywords.ElsePC + CppKeywords.IfPC + "(" + boolExp + ")");
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
            if (elseBody != null) Write(CppKeywords.ElsePC);
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
            Write(CppKeywords.ForPC + "(" + initStr + "; " + boolExpStr + "; " + updateStr + ")");
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
            string varName = String.Empty, initStr = String.Empty, typeStr = String.Empty, backTypeStr = String.Empty; ;
            string retStr = String.Empty;
            //for(int a = 0, d, f;; ....
            for (int n = 0; n < listaDeclaraciones.GetLength(); n++)
            {
                XplDeclarator nodo = (XplDeclarator)listaDeclaraciones.GetNodeAt(n);
                varName = nodo.get_name();
                initStr = processInitializer(nodo.get_i(), EZOEContext.Statement);
                typeStr = renderType(nodo.get_type(), String.Empty, EZOETypeContext.ForVarDecl, EZOEContext.Statement);
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
                if (initStr != String.Empty)
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
            Write(CppKeywords.WhilePC + "(" + boolExpStr + ")");
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
            Write(CppKeywords.DoPC);
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
            Write(CppKeywords.WhilePC + "(" + boolExpStr + ");");
            WriteNewLineOfCode();
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
            Write(CppKeywords.TryPC);
        }
        /// <summary>
        /// Renders the end try.
        /// </summary>
        /// <param name="trySta">The try sta.</param>
        /// <param name="context">The context.</param>
        protected override void renderEndTry(XplTryStatement trySta, EZOEContext context)
        {
            WriteNewLineOfCode();
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
            Write(CppKeywords.CatchPC + "(" + declExp + ")");
        }
        /// <summary>
        /// Renders the finally.
        /// </summary>
        /// <param name="tryBk">The try bk.</param>
        /// <param name="context">The context.</param>
        protected override void renderFinally(XplFunctionBody tryBk, EZOEContext context)
        {
            writeLineDirective(tryBk.get_ldsrc(), false);
            Write(CppKeywords.FinallyPC);
        }
        /// <summary>
        /// Renders the break.
        /// </summary>
        /// <param name="jump">The jump.</param>
        /// <param name="context">The context.</param>
        protected override void renderBreak(XplJump jump, EZOEContext context)
        {
            writeLineDirective(jump.get_ldsrc(), false);
            Write(CppKeywords.BreakPC + ";");
            WriteNewLineOfCode();
        }
        /// <summary>
        /// Renders the continue.
        /// </summary>
        /// <param name="jump">The jump.</param>
        /// <param name="context">The context.</param>
        protected override void renderContinue(XplJump jump, EZOEContext context)
        {
            writeLineDirective(jump.get_ldsrc(), false);
            Write(CppKeywords.ContinuePC + ";");
            WriteNewLineOfCode();
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
            Write(CppKeywords.GotoPC + label + ";");
            WriteNewLineOfCode();
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
            if (initializerStr != String.Empty && initializerStr[0] != '(' && initializerStr[0] != '{')
            {
                AddWarning("No se permiten inicializadores de expresiones simples en expresiones 'new', sólo son validos inicializadores de matrices y objetos.");
                initializerStr = String.Empty;
            }

            // check for user type
            AddTypeUsage(newExp.get_type().get_typeStr(), false, true, UseofType.InSource);

            if (initializerStr == String.Empty && newExp.get_type().get_typename() != String.Empty && newExp.get_type().get_typename()[0] != '$')
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
            return String.Empty;
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
            return String.Empty;
        }
        /// <summary>
        /// Render a simple name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderSimpleName(XplNode node, string name, EZOEContext context)
        {
            if (name == "base")
            {
                return "this";
            }
            else
            {
                if (TypeString.IsQualifiedName(name) && !node.get_Parent().get_Parent().IsA(CodeDOMTypes.XplFunctioncall))
                {
                    string typeName = TypeString.GetTypeNameFromQualified(name).Replace(CppKeywords.ScopePC, ".");
                    AddTypeUsage(typeName, false, true, UseofType.InSource);
                }
                
                return processUserTypeName(name);
            }
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
            string tempStr;

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
                    tempStr = litStr.EndsWith("f", StringComparison.InvariantCulture) ? litStr.Substring(0, litStr.Length - 1) : litStr;
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
            return CppKeywords.DeletePC + expStr;
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
            return "/* Expresion Onpointer No Soportada */";
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
            string tempStr = String.Empty;

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
            
            // Quitar Julieta 
            if (p_OptimiseParenthesis && requireParenthesis(assing)) tempStr = "(" + tempStr + ")";
            
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
            string tempStr = String.Empty;

            switch (op)
            {
                case XplBinaryoperators_enum.IMP: //Flecha "=>"
                case XplBinaryoperators_enum.M: //Member access "."
                case XplBinaryoperators_enum.MP: //Member Pointer Access ".*"
                case XplBinaryoperators_enum.PM: //Pointer Member Access "->"
                case XplBinaryoperators_enum.PMP: //Pointer To Member Pointer Access "->*"
                case XplBinaryoperators_enum.RM: //Reservado para Acceso a miembros
                    if (bopExp.get_targetClass() != String.Empty)
                    {
                        //add to used typenames
                        AddTypeUsage(bopExp.get_targetClass(), false, true, UseofType.InSource);
                    }

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
                    if (bopExp.get_l().get_Content().IsA(CodeDOMTypes.XplNewExpression))
                    {
                        tempStr = "(" + leftExpStr + ")->" + rightExpStr;
                    }
                    else if (leftExpStr == "this")
                    {
                        // check if it's base
                        if (bopExp.get_l().get_Content().get_StringValue()=="base")
                        {
                            tempStr = leftExpStr + "->" + p_currentFirstBase + "::" + rightExpStr;
                            break;
                        }
                        tempStr = leftExpStr + "->" + rightExpStr;
                    }
                    else if (bopExp.get_l().get_typeStr().StartsWith("^", StringComparison.InvariantCulture))
                    {
                        tempStr = leftExpStr + "->" + rightExpStr;
                    }
                    else
                    {
                        tempStr = leftExpStr + "." + rightExpStr;
                    }
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
                    // check if left exp is new
                    if (bopExp.get_l().get_Content().IsA(CodeDOMTypes.XplNewExpression))
                    {
                        tempStr = "(" + leftExpStr + ")->" + rightExpStr;
                    }
                    // check if it's base
                    else if (bopExp.get_l().get_Content().get_StringValue() == "base")
                    {
                        tempStr = leftExpStr + "->" + p_currentFirstBase + "::" + rightExpStr;
                    }
                    else
                    {
                        tempStr = leftExpStr + "->" + rightExpStr; flag = true;
                    }
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
                case XplBinaryoperators_enum.COMMA:
                    tempStr = leftExpStr + ", " + rightExpStr;
                    break;
                default:
                    tempStr = leftExpStr + "+" + rightExpStr;
                    AddError("Unrecognized binary operator in expression.");
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
            String tempStr = String.Empty;
            #region Switch de Operadores Unarios
            switch (op)
            {
                case XplUnaryoperators_enum.AOF: //Address of '&'                    
                    tempStr = "&" + expStr;
                    break;
                case XplUnaryoperators_enum.DEC: //Decremento postfijo 'e--'
                    tempStr = expStr + "--";
                    break;
                case XplUnaryoperators_enum.INC: //Incremento postfijo 'e++'
                    tempStr = expStr + "++";
                    break;
                case XplUnaryoperators_enum.IND: //Indireccion de puntero '*'
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
            if (fcallExp.get_targetClass() != String.Empty)
            {
                //add to used typenames
                AddTypeUsage(fcallExp.get_targetClass(), false, true, UseofType.InSource);
            }

            //string internalName = fcallExp.get_targetMember();
            //if (fcallExp.get_targetMemberExternalName() != String.Empty)
            //{
            //    // Debo modificar el leftExpStr.
            //    int indexDot = leftExpStr.LastIndexOf('.');
            //    int indexPrecedence = leftExpStr.LastIndexOf(CppKeywords.ScopePC, StringComparison.InvariantCulture);
            //    int index = Math.Max(indexDot, indexPrecedence);

            //    if (index > 0)
            //    {
            //        // La expresion izquierda es un acceso a miembro. Chequear si corresponde a la mock class,
            //        // en cuyo caso, obviar la inserción del nombre de expresión del lado izquierdo.
            //        if (leftExpStr.Substring(0, index) != "MockClass")
            //        {
            //            leftExpStr = leftExpStr.Substring(0, index) + CppKeywords.ScopePC + fcallExp.get_targetMemberExternalName();
            //        }
            //        else
            //        {
            //            leftExpStr = fcallExp.get_targetMemberExternalName();
            //        }
            //    }
            //    else
            //    {
            //        index = leftExpStr.LastIndexOf("->", StringComparison.InvariantCulture);
            //        if (index > 0)
            //        {
            //            //La expresion izquierda es un acceso a miembro de puntero
            //            leftExpStr = leftExpStr.Substring(0, index) + "->" + fcallExp.get_targetMemberExternalName();
            //        }
            //        else
            //        {
            //        }
            //    }
            //}

            if (!useBrackets)
            {
                // Qt SIGNAL and SLOT macros special cases
                if ((leftExpStr == "SIGNAL" || leftExpStr == "SLOT") && argsStr.Length > 1 && argsStr[0] == '\"')
                {
                    return leftExpStr + "(" + argsStr.Substring(1, argsStr.Length - 2) +")";
                }
                else
                {
                    return leftExpStr + "(" + argsStr + ")";
                }
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
            string tempStr = String.Empty;
            switch (castExp.get_castType())
            {
                case XplCasttype_enum.REINTERPRET:
                    tempStr = "reinterpret_cast<" + typeStr + ">(" + castExpStr + ")";
                    break;
                case XplCasttype_enum.STATIC:
                    tempStr = "(" + typeStr + ")" + castExpStr;
                    tempStr = "(" + tempStr + ")"; //Cuidado con esto al corregir lo superior
                    break;
                case XplCasttype_enum.DYNAMIC:
                    tempStr = "dynamic_cast<" + typeStr + ">(" + castExpStr + ")";
                    break;
                case XplCasttype_enum.CONST:
                    tempStr = "const_cast<" + typeStr + ">(" + castExpStr + ")";
                    break;
                case XplCasttype_enum.OTHER:
                default:
                    tempStr = "(" + typeStr + ")" + castExpStr;
                    tempStr = "(" + tempStr + ")"; //Cuidado con esto al corregir lo superior
                    break;
            }
            AddTypeUsage(castExp.get_type().get_typeStr(), false, true, UseofType.InSource);
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
                return "__error__ternary_operator_not_supported__(" + o1ExpStr + ", " + o2ExpStr + ", " + o3ExpStr + ")";
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
                if (documentation.get_Parent().get_Parent().IsA(CodeDOMTypes.XplDocumentBody) ||
                    documentation.get_Parent().IsA(CodeDOMTypes.XplClass) && IsObjCDummyGlobalClass(documentation.get_Parent() as XplClass))
                {
                    CheckBuffer(documentation);
                }

                string docStr = documentation.get_short();
                string ldsrcStr = documentation.get_ldsrc();
                int minLine = 0, maxLine = 0;
                string currentFile = String.Empty;

                if (!String.IsNullOrEmpty(ldsrcStr))
                    ParseZoeSourceInfo(ldsrcStr, ref minLine, ref  maxLine, ref currentFile);
                
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
                                Write("// " + comment);
                            else
                                Write("// " + comment);

                            /* Old decision : if (documentation.CurrentBlock == null) writeNewLineOfHeader(); else .... */
                            if (currentFile.Contains(".h"))                                
                                WriteNewLineOfHeader();
                            else
                                WriteNewLineOfCode();
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
                    //Proceso los argumentos de renderizacion
                    string[] renderArgs = renderArguments.Split(' ');
                    foreach (string renderArgument in renderArgs)
                    {
                        string[] strArg = renderArgument.Split('=');
                        switch (strArg[0].ToLower(CultureInfo.InvariantCulture))
                        {
                            case "output":
                                {
                                    if (strArg[1].ToLower(CultureInfo.InvariantCulture) == "pretty")
                                    {
                                        p_prettyOutput = true;
                                        p_dontWriteLineDirecties = true;
                                    }
                                    else if (strArg[1].ToLower(CultureInfo.InvariantCulture) == "mf")
                                    {
                                        renderOnly = false; 
                                        p_multipleFiles = true;
                                        p_prettyOutput = true;
                                    }
                                    break;
                                }
                            case "global_class":
                                {
                                    p_globalClassName = strArg[1];
                                    break;
                                }
                            case "global_file":
                                {
                                    p_globalSourceFile = strArg[1];
                                    if (!p_globalClassName.Contains(".h")) p_globalSourceFile += ".h";
                                    break;
                                }
                            case "save_ezoe":
                                {
                                    SaveExtendedZoe();
                                    break;
                                }
                            default:
                                {
                                    renderOnly = true;
                                    break;
                                }
                        }
                        
                    }
                }

                PrepareOutput();

                // index global classes and enum
                IndexGlobalClassesAndEnums();

                parseResult = base.ParseDocument();
            }
            finally
            {
                CloseOutput();
            }

            p_buffer.SetGlobalImportDirectives(p_globalImportDirectives);

            if (renderOnly)
            {
                RenderIntermediateOutputFiles();
            }
            if (p_prettyOutput)
            {
                RenderPrettyOutput();
            }
            if (p_multipleFiles)
            {
                RenderMultipleFiles();
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

        private void IndexGlobalClassesAndEnums()
        {
            var children = p_XplDocument.get_DocumentBody().Children();
            foreach (XplNode child in children)
            {
                IndexGlobalClassesAndEnums(child);
            }
        }
        private void IndexGlobalClassesAndEnums(XplNode node)
        {
            XplNodeList children = null;

            if (node.IsA(CodeDOMTypes.XplNamespace))
            {
                children = node.Children();
            }
            else if (node.IsA(CodeDOMTypes.XplClass))
            {
                RegisterEnumOrGlobalClass(node as XplClass);
                children = node.Children();
            }
            else if (node.IsA(CodeDOMTypes.XplField))
            {
                var parentClass = node.get_Parent() as XplClass;
                if(IsObjCDummyGlobalClass(parentClass)) IndexGlobalVar(parentClass, node as XplField);
            }

            if (children != null)
            {
                foreach (XplNode child in children)
                {
                    IndexGlobalClassesAndEnums(child);
                }
            }
        }

        private void IndexGlobalVar(XplClass parentClass, XplField field)
        {
            if (MantainOriginalObjCDeclarationContext(parentClass))
            {
                if (field.get_type().get_typename().Contains(ObjectiveCFlags.ANONYMOUS_DECL))
                {
                    // add global class name --> field association
                    string className = parentClass.get_name();
                    List<XplField> list = null;
                    if (_anonymousGlobalVars.ContainsKey(className))
                    {
                        list = _anonymousGlobalVars[className];
                    }
                    else
                    {
                        list = new List<XplField>();
                        _anonymousGlobalVars.Add(className, list);
                    }

                    list.Add(field);

                    // add anonymous type name --> field association
                    string fieldAnonymType = TypeString.GetSimpleNameFromQualified(field.get_type().get_typename());
                    if (_anonymousGlobalVars.ContainsKey(fieldAnonymType))
                    {
                        list = _anonymousGlobalVars[fieldAnonymType];
                    }
                    else
                    {
                        list = new List<XplField>();
                        _anonymousGlobalVars.Add(fieldAnonymType, list);
                    }
                    list.Add(field);
                }
            }
        }

        private bool MantainOriginalObjCDeclarationContext(XplClass parentClass)
        {
            return !parentClass.get_lddata().Contains(ObjectiveCFlags.TAG_CONTEXT_CHANGES_PREFIX);
        }

        private void RegisterEnumOrGlobalClass(XplClass classNode)
        {
            if (classNode.get_isenum() || IsObjCDummyGlobalClass(classNode))
            {
                string fullName = CompilationUnit.GetZoeFullName(classNode);
                p_classNamesToRemove.Add(fullName.Replace(".", CppKeywords.ScopePC) + CppKeywords.ScopePC);
            }
        }
        private void PrepareOutput()
        {
            p_buffer = new RenderBuffer(p_outputPath, this);
        }

        private void CloseOutput()
        {
            p_buffer.Close();
        }

        private void RenderMultipleFiles()
        {
            p_buffer.Render();
        }

        private void RenderPrettyOutput()
        {
            p_buffer.Render();
        }

        private void RenderIntermediateOutputFiles()
        {
            p_buffer.Render();
        }

        private void SaveExtendedZoe()
        {
            if (p_XplDocument != null)
            {
                //Por ahora solo considero la grabación del código recibido
                XplWriter writer = null;
                try
                {
                    if (p_outputPath == null) p_outputPath = String.Empty;
                    writer = new XplWriter(Path.Combine(p_outputPath, Path.GetFileNameWithoutExtension(p_outputFileName) + "_dotnet.ezoe"));
                    p_XplDocument.Write(writer);
                }
                finally
                {
                    if (writer != null) writer.Close();
                }
            }
        }

        private string GetFileNameFromLdsrc(string strFullSourceFileInfo)
        {
            if (strFullSourceFileInfo != string.Empty)
            {
                //The file path with .h extension is returned
                string[] strComponentsOfFileInfo = strFullSourceFileInfo.Split(',');
                strFullSourceFileInfo = strComponentsOfFileInfo[strComponentsOfFileInfo.Length - 1];
                strFullSourceFileInfo = Path.GetFileNameWithoutExtension(strFullSourceFileInfo);
            }
            return strFullSourceFileInfo;
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
            return "__EXPRESSION_WRITECODE_NOT_SUPPORTED_IN_CPP__";
        }

        /// <summary>
        /// Render a writecode block.
        /// </summary>
        /// <param name="xplWriteCodeBody">The XPL write code body.</param>
        /// <param name="context">The context.</param>
        /// <returns>A string with the rendered item.</returns>
        protected override string renderWritecodeBlock(XplWriteCodeBody xplWriteCodeBody, ExtendedZOEProcessor.EZOEContext context)
        {
            return "__EXPRESSION_WRITECODE_NOT_SUPPORTED_IN_CPP__";
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

        protected override string renderSizeofExp(XplType xplType, string typeStr, EZOEContext eZOEContext)
        {
            AddTypeUsage(xplType.get_typeStr(), false, !IsDerivedType(xplType.get_typeStr()), UseofType.InSource);
            return "sizeof( " + typeStr + " )";
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
        /// Renders a external declaration for a global variable (field inside special ObjC Global class)
        /// </summary>
        internal string renderGlobalVarForwardDecl(XplField field)
        {
            string temp = String.Empty;
            if (field.get_type().get_const()) temp = CppKeywords.ConstPC;
            if (field.get_type().get_volatile()) temp += CppKeywords.VolatilePC;

            return CppKeywords.ExternPC + temp + renderType(field.get_type(), field.get_name(), EZOETypeContext.LocalVarDecl, EZOEContext.FunctionBody) + ";\n";
        }
    }
}