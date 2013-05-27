/*******************************************************************************
* Copyright (c) 2007, 2012 Alexis Ferreyra, Intel Corporation.
* All rights reserved. This program and the accompanying materials
* are made available under the terms of the Eclipse Public License v1.0
* which accompanies this distribution, and is available at
* http://www.eclipse.org/legal/epl-v10.html
*
* Contributors:
*       Alexis Ferreyra - initial API and implementation
*       Alexis Ferreyra (Intel Corporation)
*******************************************************************************/
/****************************************************************************
* 
*  Zoe Compiler Core
*  
*  Original Author: Alexis Ferreyra
*  Contact: alexis.ferreyra@layerd.net
*  
*  Please visit http://layerd.net to get the last version
*  of the software and information about LayerD technology.
*
****************************************************************************/

//Archivo: lib_zoec_semantic.cs 
//
//Analizador semántico ZOE, realiza el analisis 
//semántico incluyendo la construccion de las tablas
//de tipos y simbolos, establece los tipos exactos
//de las expresiones, valida las declaraciones y mantiene
//la información de alcance (scope).
//Genera el Documento de Tiempo de Ejecución y los
//Documentos de secciones de extensión dinámica del programa
//analizado.
//

using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using LayerD.CodeDOM;
using LayerD.OutputModules;
using LayerD.OutputModules.Importers;
using LayerD.ZOEOutputModulesLibrary;
using System.Text.RegularExpressions;
using System.IO;

namespace LayerD.ZOECompiler
{
    #region NativeTypes
    public sealed class NativeTypes
    {
        /*
            INTEGER, UNSIGNED, LONG, ULONG, SHORT, USHORT, SBYTE, BYTE, FLOAT,
            DOUBLE, LDOUBLE, DECIMAL, FIXED, BOOLEAN, CHAR, STRING, ASCIICHAR,
            ASCIISTRING, DATE, UUID, VOID, OBJECT, TYPE, BLOCK
        */
        public const string SByte = "$SBYTE$";
        public const string Short = "$SHORT$";
        public const string Integer = "$INTEGER$";
        public const string Long = "$LONG$";
        public const string Byte = "$BYTE$";
        public const string UShort = "$USHORT$";
        public const string Unsigned = "$UNSIGNED$";
        public const string ULong = "$ULONG$";
        public const string Float = "$FLOAT$";
        public const string Double = "$DOUBLE$";
        public const string LDouble = "$LDOUBLE$";
        public const string Decimal = "$DECIMAL$";
        public const string String = "$STRING$";
        public const string Char = "$CHAR$";
        public const string ASCIIString = "$ASCIISTRING$";
        public const string ASCIIChar = "$ASCIICHAR$";
        public const string Void = "$VOID$";
        public const string Type = "$TYPE$";
        public const string Block = "$BLOCK$";
        public const string Boolean = "$BOOLEAN$";
        public const string Null = "$NULL$";
        public const string None = "$NONE$";

        public static string Object = "$OBJECT$";
        public static string Date = "$DATE$";
        public static string ExceptionClassTypeName = "DotNET.System.Exception";
        public static string ArrayClassTypeName = "zoe.lang.Array";

        /// <summary>
        /// Indica si la cadena "argTypeStr" se corresponde con un tipo nativo valido o no.
        /// </summary>
        static public bool IsValidNativeType(string argTypeStr)
        {
            switch (argTypeStr)
            {
                case SByte:
                case Short:
                case Integer:
                case Long:
                case Byte:
                case UShort:
                case Unsigned:
                case ULong:
                case Float:
                case Double:
                case LDouble:
                case Decimal:
                case String:
                case Char:
                case ASCIIString:
                case ASCIIChar:
                case Void:
                case Type:
                case Block:
                case Boolean:
                case Null:
                    return true;
            }
            if (argTypeStr == Object) return true;
            if (argTypeStr == Date) return true;
            return false;
        }
        static public bool IsNativeSByte(string argTypeStr)
        { return SByte == argTypeStr; }
        static public bool IsNativeShort(string argTypeStr)
        { return Short == argTypeStr; }
        static public bool IsNativeInteger(string argTypeStr)
        { return Integer == argTypeStr; }
        static public bool IsNativeLong(string argTypeStr)
        { return Long == argTypeStr; }
        static public bool IsNativeByte(string argTypeStr)
        { return Byte == argTypeStr; }
        static public bool IsNativeUShort(string argTypeStr)
        { return UShort == argTypeStr; }
        static public bool IsNativeUnsigned(string argTypeStr)
        { return Unsigned == argTypeStr; }
        static public bool IsNativeULong(string argTypeStr)
        { return ULong == argTypeStr; }
        static public bool IsNativeFloat(string argTypeStr)
        { return Float == argTypeStr; }
        static public bool IsNativeDouble(string argTypeStr)
        { return Double == argTypeStr; }
        static public bool IsNativeLDouble(string argTypeStr)
        { return LDouble == argTypeStr; }
        static public bool IsNativeDecimal(string argTypeStr)
        { return Decimal == argTypeStr; }
        static public bool IsNativeString(string argTypeStr)
        { return String == argTypeStr; }
        static public bool IsNativeChar(string argTypeStr)
        { return Char == argTypeStr; }
        static public bool IsNativeASCIIString(string argTypeStr)
        { return ASCIIString == argTypeStr; }
        static public bool IsNativeASCIIChar(string argTypeStr)
        { return ASCIIChar == argTypeStr; }
        static public bool IsNativeVoid(string argTypeStr)
        { return Void == argTypeStr; }
        static public bool IsNativeObject(string argTypeStr)
        { return Object == argTypeStr; }
        static public bool IsNativeType(string argTypeStr)
        { return Type == argTypeStr; }
        static public bool IsNativeBlock(string argTypeStr)
        { return Block == argTypeStr; }
        static public bool IsNativeBoolean(string argTypeStr)
        { return Boolean == argTypeStr; }
        static public bool IsExceptionType(string argTypeStr)
        { 
            // TODO : this is incorrect it must check for types allowed on the output module
            // return ExceptionClassTypeName == argTypeStr; 
            return true;
        }
        static public bool IsArrayType(string argTypeStr)
        { return ArrayClassTypeName == argTypeStr; }
        static public bool IsNativeNull(string argTypeStr)
        { return Null == argTypeStr; }

        static public string MakeLiteralNT(string argTypeStr)
        {
            return argTypeStr.Substring(0, argTypeStr.Length - 1) + "_LIT$";
        }
        /// <summary>
        /// Indica si el tipo representado por la cadena argumento es un tipo nativo que puede representarse con un literal, estos son:
        ///  sbyte, byte, short, ushort, int, uint, long, ulong, float, double, decimal, string, char, ASCIIChar, ASCIIString.
        /// Retorna verdadero si el tipo representa directamente un literal.
        /// Si el tipo no es un tipo nativo devuelve false incluyendo tipos derivados de tipos
        /// nativos como referencias a string.
        /// </summary>
        public static bool IsValidNativeLiteralType(string symTypeStr)
        {
            if (symTypeStr == null) return false;
            if (symTypeStr.Length == 0 || symTypeStr[0] != '$') return false;
            if (symTypeStr.Length > 3 && symTypeStr.EndsWith("_LIT$",StringComparison.InvariantCulture)) return true;
            if (IsNativeSByte(symTypeStr)       ||
                IsNativeByte(symTypeStr)        ||
                IsNativeShort(symTypeStr)       ||
                IsNativeUShort(symTypeStr)      ||
                IsNativeInteger(symTypeStr)     ||
                IsNativeUnsigned(symTypeStr)    ||
                IsNativeLong(symTypeStr)        ||
                IsNativeULong(symTypeStr)       ||
                IsNativeFloat(symTypeStr)       ||
                IsNativeDouble(symTypeStr)      ||
                IsNativeDecimal(symTypeStr)     ||
                IsNativeChar(symTypeStr)        ||
                IsNativeASCIIChar(symTypeStr)   ||
                IsNativeString(symTypeStr)      ||
                IsNativeASCIIString(symTypeStr))
            {
                return true;
            }
            return false;                
        }
    }
    #endregion

    partial class SemanticAnalizer
    {
        #region Tipos Internos
        enum SemanticAction
        {
            ReadTypes,
            CheckTypes,
            CheckInheritance,
            CheckImplementation,
            CreateDTE
        }
        sealed class ExpressionResult
        {
            string p_typeStr;
            ExpressionResultType p_expType;
            MemberInfo[] p_members;
            TypeInfo p_type;
            XplType p_typeNode;
            bool p_isConstant;
            object p_constantValue;

            public ExpressionResult(string typeStr)
            {
                p_expType = ExpressionResultType.Value;
                p_typeStr = typeStr;
            }
            public ExpressionResult(string typeStr, ExpressionResultType expType)
            {
                p_expType = expType;
                p_typeStr = typeStr;
            }
            public ExpressionResult(string typeStr, ExpressionResultType expType, XplType typeNode)
            {
                p_expType = expType;
                p_typeStr = typeStr;
                p_typeNode = typeNode;
            }
            public ExpressionResult(MemberInfo[] members)
            {
                p_expType = ExpressionResultType.TypeMembers;
                p_members = members;
            }
            public ExpressionResult(MemberInfo[] members, bool fromValue)
            {
                if (fromValue)
                    p_expType = ExpressionResultType.TypeMembersFromValue;
                else
                    p_expType = ExpressionResultType.TypeMembers;
                p_members = members;
            }
            public ExpressionResult(TypeInfo type)
            {
                p_expType = ExpressionResultType.Type;
                p_type = type;
            }
            public bool get_IsConstant()
            {
                return p_isConstant;
            }
            public void set_IsConstant(bool isConstant)
            {
                p_isConstant = isConstant;
            }
            public object get_ConstantValue()
            {
                return p_constantValue;
            }
            public void set_ConstantValue(object constantValue)
            {
                p_constantValue = constantValue;
            }
            public string get_TypeStr()
            {
                return p_typeStr;
            }
            public void set_TypeStr(string newTypeStr)
            {
                p_typeStr = newTypeStr;
            }
            public ExpressionResultType get_ExpType()
            {
                return p_expType;
            }
            public void set_ExpType(ExpressionResultType newExpType)
            {
                p_expType = newExpType;
            }
            public TypeInfo get_Type()
            {
                return p_type;
            }
            public void set_Type(TypeInfo newType)
            {
                p_type = newType;
            }
            public XplType get_TypeNode()
            {
                return p_typeNode;
            }
            public void set_TypeNode(XplType typeNode)
            {
                p_typeNode = typeNode;
            }
            public MemberInfo[] get_Members()
            {
                return p_members;
            }
            public void set_Members(MemberInfo[] newMembers)
            {
                p_members = newMembers;
            }
            /// <summary>
            /// Indica si es de tipo TypeMembers o TypeMembersFromValue
            /// </summary>
            public bool get_IsTypeMembers()
            {
                return p_expType == ExpressionResultType.TypeMembers || p_expType == ExpressionResultType.TypeMembersFromValue;
            }
            /// <summary>
            /// Indica si es de tipo Value o ValueOrLValue
            /// </summary>
            public bool get_IsValue()
            {
                return p_expType == ExpressionResultType.Value || p_expType == ExpressionResultType.ValueOrLValue;
            }
            /// <summary>
            /// Indica si es de tipo LValue o ValueOrLValue
            /// </summary>
            public bool get_IsLValue()
            {
                return p_expType == ExpressionResultType.LValue || p_expType == ExpressionResultType.ValueOrLValue;
            }

            /// <summary>
            /// Returns a string representation of constant value of expression result
            /// suitable to use on "valueStr" attribute of XplExpression Zoe element.
            /// </summary>
            /// <returns>Constant value converted to string. Throws exception if constant value is null.</returns>
            internal string get_ConstantValueAsString()
            {
                // TODO : use a platform neutral string representation of constants
                return Convert.ToString(p_constantValue, System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        enum ExpressionResultType
        {
            Value,                      // Un valor
            LValue,                     // Un valor asignable, como una variable, campo o propiedad
            ValueOrLValue,              // Un valor o valor asignable
            TypeMembers,                // Miembros de un Tipo filtrados a partir de un tipo
            TypeMembersFromValue,       // Miembros de un Tipo filtrados a partir de un valor
            Type                        // Un tipo como un espacio de nombres o una clase
        }
        enum ConversionType
        {
            NativeImplicitConversion,
            UserDefinedImplicitConversion,
            NativeExplicitConversion,
            UserDefinedExplicitConversion
        }
        sealed class ConversionData
        {
            public ConversionType ConversionType;
            public MemberInfo UserDefinedConversionUsed;
            public bool IsBoxing;
            public bool IsUnboxing;
            public ConversionData(ConversionType new_type, bool new_isBoxing, bool new_isUnboxing, MemberInfo new_userDefinedConversionUsed)
            {
                ConversionType = new_type;
                IsBoxing = new_isBoxing;
                IsUnboxing = new_isUnboxing;
                UserDefinedConversionUsed = new_userDefinedConversionUsed;
            }
        }
        #endregion

        #region Datos Privados / Protegidos
        const string CODEDOM_NAMESPACE = "DotNET.LayerD.CodeDOM";
        const string CLASSFACTORYBASE = "DotNET.LayerD.ZOECompiler.ClassfactoryBase";
        const string CLASSFACTORYINTERACTIVEBASE = "DotNET.LayerD.ZOECompiler.ClassfactoryInteractiveBase";
        const string OBJECT_CLASS_FULL_PATH = "zoe.lang.Object";
        const string OBJECT_CLASS_FULL_PATH2 = "zoe::lang::Object";

        // Determina la representación en tiempo de ejecución de un tipo, es decir para
        // reflexion en tiempo de ejecución.
        // PENDIENTE : Por ahora se utilizara la infraestructura disponible en las plataformas
        // de ejecución hasta que se cuente con un sistema reflectivo unificado en tiempo
        // de ejecución.
        string p_runtimeTypeForType = "^_$OBJECT$";

        IEZOEOutputModuleServices p_compileTimeOutputModule;
        IEZOEOutputModuleServices p_runtimeOutputModule;
        ErrorCollection p_errorCollection;
        Hashtable p_processedImports;
        Hashtable p_nativeImplicitConversions;
        Hashtable p_customImplicitConversions;
        Hashtable p_customExplicitConversions;
        Hashtable p_customBinaryOperators;
        Hashtable p_customUnaryOperators;
        Hashtable p_operatorsCache;
        Hashtable p_memberAccessCache;
        XplDocument p_lastParseDTE;
        ExtensionData[] p_lastParseExtensionSections;

        XplDocument[] p_programDocuments;
        XplDocument[] p_importedDocuments;
        XplDocument p_classfactorysDocument;
        bool p_currentDocumentIsImport;
        SectionCollection p_programSections;
        Section p_currentSection;
        bool p_currentSectionIsMissing;
        bool p_searchForImplicitSection;
        XplLayerDZoeProgramRequirements p_programRequirements;
        bool p_isExtensionModule;
        bool p_interactiveOnly;
        bool p_showFullDebugInfo;
        bool p_showInternalTimes;
        bool p_ignoreErrorsOnImportedTypes;
        bool p_isClassfactorysDoc;
        bool p_persistentStructures;
        CandidateStructuresCollection p_candidateStructures;

        XplFunctioncall p_dummyBinaryOperatorFunctioncall;
        XplFunctioncall p_dummyUnaryOperatorFunctioncall;
        XplFunctioncall p_dummyNewExpressionFunctioncall;

        TypesTable p_types;

        static ArrayList p_typesToDelete;
        static SemanticAnalizer p_currentParseInstance;

        #endregion

        #region Interfaz Publica
        public void set_PersistentStructures(bool persistent)
        {
            p_persistentStructures = persistent;
        }
        public void set_ClassfactorysDocument(XplDocument xplZOEDocument)
        {
            p_classfactorysDocument = xplZOEDocument;
        }
        public void set_IgnoreErrorsOnImportedTypes(bool arg)
        {
            p_ignoreErrorsOnImportedTypes = arg;
        }
        public void set_ShowFullDebugInfo(bool showFullDebugInfo)
        {
            p_showFullDebugInfo = showFullDebugInfo;
        }
        public void set_ShowInternalTimes(bool showInternalTimes)
        {
            p_showInternalTimes = showInternalTimes;
        }
        /// <summary>
        /// Establece la configuración del programa LayerD-Zoe a chequear.
        /// 
        /// Si es nulo se asigna una instancia con valores por defecto.
        /// </summary>
        public void set_ProgramConfig(XplLayerDZoeProgramRequirements config)
        {
            p_programRequirements = config;
            if (p_programRequirements == null) p_programRequirements = new XplLayerDZoeProgramRequirements();
        }
        public void set_CompileTimeOutputModule(IEZOEOutputModuleServices compileTimeOutputModule)
        {
            p_compileTimeOutputModule = compileTimeOutputModule;
        }
        public void set_RuntimeOutputModule(IEZOEOutputModuleServices runtimeOutputModule)
        {
            p_runtimeOutputModule = runtimeOutputModule;
        }
        public bool set_ErrorCollection(ErrorCollection newErrorCollection)
        {
            p_errorCollection = newErrorCollection;
            if (p_errorCollection != null) return true;
            return false;
        }
        public XplDocument get_LastParseDTE()
        {
            return p_lastParseDTE;
        }
        public ExtensionData[] get_LastParseExtensionSections()
        {
            return p_lastParseExtensionSections;
        }
        public bool ParseSemantic(XplDocument[] programDocuments,
                           bool isExtensionModule,
                           bool interactiveOnly)
        {
            p_programDocuments = programDocuments;
            p_isExtensionModule = isExtensionModule;
            p_interactiveOnly = interactiveOnly;
            return DoParse();
        }
        public TypesTable get_TypesTable()
        {
            return p_types;
        }
        public CandidateStructuresCollection get_CandidateStructuresCollection()
        {
            return p_candidateStructures;
        }
        #endregion

        #region Constructores
        public SemanticAnalizer()
        {
        }
        #endregion

        #region DoParse
        bool DoParse()
        {
            // timers
            DateTime lastTime = DateTime.Now;
            for(int n=0;n<p_timer.Length;n++) p_timer[n] = TimeSpan.Zero;

            if (p_programDocuments == null)
                throw new SemanticException("Internal Error: program documents are not set correctly.");
            
            InitializeParser();
            // 1º)Agrego todos los Documentos Importados al listado
            FillImportedDocuments();
            p_currentParseInstance = this;

            if (p_showInternalTimes) ZOECompilerCore.WriteDebugTextLine("FillImportedDocuments.: " + ((TimeSpan)(DateTime.Now - lastTime)).ToString());
            lastTime = DateTime.Now;
            // 2º)Controlo la corrección de los tipos declarados
            try
            {
                CheckTypes();
            }
            catch(Exception error)
            {
                AddNewError(SemanticError.New(SemanticErrorCode.UnspecifiedSemanticError,
                    p_programDocuments[1], " Internal Compiler error incorrectly managed while checking types. Please report this error to Zoe compiler Team - http://layerd.net. \nError Detail :" +
                    error.Message + "\nStack trace: " + error.StackTrace));
            }
            if (p_showInternalTimes) ShowTimers();

            if (p_showInternalTimes) ZOECompilerCore.WriteDebugTextLine("Full Check Types......: " + ((TimeSpan)(DateTime.Now - lastTime)).ToString());
            lastTime = DateTime.Now;
            // 4º)Creo el DTE
            CreateDTE();
            // 5º)Creo las Secciones de Extensión Dinámica
            CreateExtensionSections();
            if (p_showInternalTimes) ZOECompilerCore.WriteDebugTextLine("Create DTE And E.S....: " + ((TimeSpan)(DateTime.Now - lastTime)).ToString());
            if (p_showFullDebugInfo) ZOECompilerCore.WriteDebugTextLine("Types Count...........: " + p_types.Count);
            return true;
        }
        #endregion

        #region Initializers
        private void InitializeParser()
        {
            if (p_programRequirements == null || !p_persistentStructures)
            {
                // TODO : add a try-catch and emit an error when DocumentData or Config is missing
                XplNode config = p_programDocuments[0].get_DocumentData().get_Config().get_Content();
                if (config is XplLayerDZoeProgramConfig)
                {
                    p_programRequirements = ((XplLayerDZoeProgramConfig)config).get_ProgramRequirements();
                }
                else
                {
                    p_programRequirements = new XplLayerDZoeProgramRequirements();
                }
            }
            if (p_types == null || !p_persistentStructures)
            {
                p_types = new TypesTable();
                InitializeDefaultTypeMappings();
            }
            if (p_processedImports == null || !p_persistentStructures) 
                p_processedImports = new Hashtable();
            if (p_nativeImplicitConversions == null || !p_persistentStructures) 
                p_nativeImplicitConversions = new Hashtable();
            if (p_nativeImplicitConversions.Count==0 || !p_persistentStructures)
                InitializeNativeImplicitConversions();
            if (p_persistentStructures)
            {
                if (p_typesToDelete != null)
                    foreach (string fullTypeStr in p_typesToDelete)
                        p_types.Remove(fullTypeStr);
                p_typesToDelete = new ArrayList();
            }
            p_programSections = new SectionCollection();
            p_candidateStructures = new CandidateStructuresCollection(p_interactiveOnly);
            // Inicializo las cache de operadores y miembros
            // esto lo borro en cada ciclo para evitar considerar mal miembros
            // que se hayan corregido o agregado a miembros
            // Además tengo que eliminar todo porque se puede haber cambiado la estructura
            // de un tipo en tiempo de compilación
            p_operatorsCache = new Hashtable();
            p_memberAccessCache = new Hashtable();

            // clear custom conversions table
            p_customImplicitConversions = new Hashtable();
            p_customExplicitConversions = new Hashtable();

            // clear custom operators table
            p_customBinaryOperators = new Hashtable();
            p_customUnaryOperators = new Hashtable();

            // Inicializo el placeHolder para la resolucion de operadores binarios
            p_dummyBinaryOperatorFunctioncall = new XplFunctioncall();
            XplExpressionlist arguments = XplFunctioncall.new_args();
            p_dummyBinaryOperatorFunctioncall.set_args(arguments);
            p_dummyNewExpressionFunctioncall = p_dummyUnaryOperatorFunctioncall = p_dummyBinaryOperatorFunctioncall;
        }
        private void InitializeDefaultTypeMappings()
        {
            p_types.InsertTypeMapping(NativeTypes.Boolean, "zoe.lang.Boolean");

            p_types.InsertTypeMapping(NativeTypes.Byte, "zoe.lang.Byte");
            p_types.InsertTypeMapping(NativeTypes.Short, "zoe.lang.Short");
            p_types.InsertTypeMapping(NativeTypes.Integer, "zoe.lang.Integer");
            p_types.InsertTypeMapping(NativeTypes.Long, "zoe.lang.Long");

            p_types.InsertTypeMapping(NativeTypes.SByte, "zoe.lang.SByte");
            p_types.InsertTypeMapping(NativeTypes.UShort, "zoe.lang.UShort");
            p_types.InsertTypeMapping(NativeTypes.Unsigned, "zoe.lang.Unsigned");
            p_types.InsertTypeMapping(NativeTypes.ULong, "zoe.lang.ULong");

            p_types.InsertTypeMapping(NativeTypes.Char, "zoe.lang.Char");

            p_types.InsertTypeMapping(NativeTypes.Float, "zoe.lang.Float");
            p_types.InsertTypeMapping(NativeTypes.Double, "zoe.lang.Double");
            p_types.InsertTypeMapping(NativeTypes.LDouble, "zoe.lang.Double");
            p_types.InsertTypeMapping(NativeTypes.Decimal, "zoe.lang.Decimal");

            p_types.InsertTypeMapping(NativeTypes.Null, "zoe.lang.Null");
            p_types.InsertTypeMapping(NativeTypes.Object, OBJECT_CLASS_FULL_PATH);
            p_types.InsertTypeMapping(NativeTypes.String, "zoe.lang.String");
            p_types.InsertTypeMapping(NativeTypes.Date, "zoe.lang.DateTime");

            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.Boolean), "zoe.lang.Boolean");

            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.Byte), "zoe.lang.Byte");
            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.Short), "zoe.lang.Short");
            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.Integer), "zoe.lang.Integer");
            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.Long), "zoe.lang.Long");

            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.SByte), "zoe.lang.SByte");
            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.UShort), "zoe.lang.UShort");
            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.Unsigned), "zoe.lang.Unsigned");
            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.ULong), "zoe.lang.ULong");

            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.Char), "zoe.lang.Char");

            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.Float), "zoe.lang.Float");
            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.Double), "zoe.lang.Double");
            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.LDouble), "zoe.lang.Double");
            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.Decimal), "zoe.lang.Decimal");

            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.String), "zoe.lang.String");
            p_types.InsertTypeMapping(NativeTypes.MakeLiteralNT(NativeTypes.Date), "zoe.lang.DateTime");

            p_types.InsertTypeMapping(NativeTypes.Type, CODEDOM_NAMESPACE + ".XplType");
            p_types.InsertTypeMapping(NativeTypes.Block, CODEDOM_NAMESPACE + ".XplFunctionBody");
        }
        private void InitializeNativeImplicitConversions()
        {
            /*
                INTEGER, UNSIGNED, LONG, ULONG, SHORT, USHORT, SBYTE, BYTE, FLOAT,
                DOUBLE, LDOUBLE, DECIMAL, FIXED, BOOLEAN, CHAR, STRING, ASCIICHAR,
                ASCIISTRING, DATE, UUID, VOID, OBJECT, TYPE, BLOCK
            */
            //STRING_LIT
            p_nativeImplicitConversions.Add("$STRING_LIT$" + "¿TO?" + "^_$STRING$", String.Empty);
            p_nativeImplicitConversions.Add("$STRING_LIT$" + "¿TO?" + "^_$OBJECT$", String.Empty);
            //STRING
            p_nativeImplicitConversions.Add("$STRING$" + "¿TO?" + "^_$OBJECT$", String.Empty);
            p_nativeImplicitConversions.Add("^_$STRING$" + "¿TO?" + "^_$OBJECT$", String.Empty);
            //ASCIISTRING_LIT
            p_nativeImplicitConversions.Add("$ASCIISTRING_LIT$" + "¿TO?" + "$ASCIISTRING$", String.Empty);
            p_nativeImplicitConversions.Add("$ASCIISTRING_LIT$" + "¿TO?" + "^_$ASCIISTRING$", String.Empty);
            p_nativeImplicitConversions.Add("$ASCIISTRING_LIT$" + "¿TO?" + "$STRING$", String.Empty);
            p_nativeImplicitConversions.Add("$ASCIISTRING_LIT$" + "¿TO?" + "^_$STRING$", String.Empty);
            p_nativeImplicitConversions.Add("$ASCIISTRING_LIT$" + "¿TO?" + "^_$OBJECT$", String.Empty);
            //ASCIISTRING
            p_nativeImplicitConversions.Add("$ASCIISTRING$" + "¿TO?" + "$STRING$", String.Empty);
            p_nativeImplicitConversions.Add("$ASCIISTRING$" + "¿TO?" + "^_$STRING$", String.Empty);
            p_nativeImplicitConversions.Add("^_$ASCIISTRING$" + "¿TO?" + "^_$STRING$", String.Empty);
            p_nativeImplicitConversions.Add("^_$ASCIISTRING$" + "¿TO?" + "^_$OBJECT$", String.Empty);
            //BOOLEAN
            p_nativeImplicitConversions.Add("$BOOLEAN$" + "¿TO?" + "^_$OBJECT$", String.Empty);
            //CHAR
            p_nativeImplicitConversions.Add("$CHAR$" + "¿TO?" + "^_$OBJECT$", "BOXING");
            p_nativeImplicitConversions.Add("$CHAR$" + "¿TO?" + "$SHORT$", String.Empty);
            p_nativeImplicitConversions.Add("$CHAR$" + "¿TO?" + "$INTEGER$", String.Empty);
            p_nativeImplicitConversions.Add("$CHAR$" + "¿TO?" + "$LONG$", String.Empty);
            //ASCIICHAR
            p_nativeImplicitConversions.Add("$ASCIICHAR_LIT$" + "¿TO?" + "$ASCIICHAR$", String.Empty);
            p_nativeImplicitConversions.Add("$ASCIICHAR_LIT$" + "¿TO?" + "$CHAR$", String.Empty);
            p_nativeImplicitConversions.Add("$ASCIICHAR$" + "¿TO?" + "$CHAR$", String.Empty);
            p_nativeImplicitConversions.Add("$ASCIICHAR_LIT$" + "¿TO?" + "^_$OBJECT$", "BOXING");
            p_nativeImplicitConversions.Add("$ASCIICHAR$" + "¿TO?" + "^_$OBJECT$", "BOXING");
            //SBYTE
            p_nativeImplicitConversions.Add("$SBYTE$" + "¿TO?" + "$SHORT$", String.Empty);
            p_nativeImplicitConversions.Add("$SBYTE$" + "¿TO?" + "$INTEGER$", String.Empty);
            p_nativeImplicitConversions.Add("$SBYTE$" + "¿TO?" + "$LONG$", String.Empty);
            p_nativeImplicitConversions.Add("$SBYTE$" + "¿TO?" + "$FLOAT$", String.Empty);
            p_nativeImplicitConversions.Add("$SBYTE$" + "¿TO?" + "$DOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$SBYTE$" + "¿TO?" + "$LDOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$SBYTE$" + "¿TO?" + "$DECIMAL$", String.Empty);
            p_nativeImplicitConversions.Add("$SBYTE$" + "¿TO?" + "^_$OBJECT$", "BOXING");
            //BYTE
            p_nativeImplicitConversions.Add("$BYTE$" + "¿TO?" + "$SHORT$", String.Empty);
            p_nativeImplicitConversions.Add("$BYTE$" + "¿TO?" + "$INTEGER$", String.Empty);
            p_nativeImplicitConversions.Add("$BYTE$" + "¿TO?" + "$LONG$", String.Empty);
            p_nativeImplicitConversions.Add("$BYTE$" + "¿TO?" + "$USHORT$", String.Empty);
            p_nativeImplicitConversions.Add("$BYTE$" + "¿TO?" + "$UNSIGNED$", String.Empty);
            p_nativeImplicitConversions.Add("$BYTE$" + "¿TO?" + "$ULONG$", String.Empty);
            p_nativeImplicitConversions.Add("$BYTE$" + "¿TO?" + "$FLOAT$", String.Empty);
            p_nativeImplicitConversions.Add("$BYTE$" + "¿TO?" + "$DOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$BYTE$" + "¿TO?" + "$LDOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$BYTE$" + "¿TO?" + "$DECIMAL$", String.Empty);
            p_nativeImplicitConversions.Add("$BYTE$" + "¿TO?" + "^_$OBJECT$", "BOXING");
            //SHORT
            p_nativeImplicitConversions.Add("$SHORT$" + "¿TO?" + "$INTEGER$", String.Empty);
            p_nativeImplicitConversions.Add("$SHORT$" + "¿TO?" + "$LONG$", String.Empty);
            p_nativeImplicitConversions.Add("$SHORT$" + "¿TO?" + "$FLOAT$", String.Empty);
            p_nativeImplicitConversions.Add("$SHORT$" + "¿TO?" + "$DOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$SHORT$" + "¿TO?" + "$LDOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$SHORT$" + "¿TO?" + "$DECIMAL$", String.Empty);
            p_nativeImplicitConversions.Add("$SHORT$" + "¿TO?" + "^_$OBJECT$", "BOXING");
            //USHORT
            p_nativeImplicitConversions.Add("$USHORT$" + "¿TO?" + "$INTEGER$", String.Empty);
            p_nativeImplicitConversions.Add("$USHORT$" + "¿TO?" + "$LONG$", String.Empty);
            p_nativeImplicitConversions.Add("$USHORT$" + "¿TO?" + "$UINTEGER$", String.Empty);
            p_nativeImplicitConversions.Add("$USHORT$" + "¿TO?" + "$ULONG$", String.Empty);
            p_nativeImplicitConversions.Add("$USHORT$" + "¿TO?" + "$FLOAT$", String.Empty);
            p_nativeImplicitConversions.Add("$USHORT$" + "¿TO?" + "$DOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$USHORT$" + "¿TO?" + "$LDOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$USHORT$" + "¿TO?" + "$DECIMAL$", String.Empty);
            p_nativeImplicitConversions.Add("$USHORT$" + "¿TO?" + "^_$OBJECT$", "BOXING");
            //INTEGER
            p_nativeImplicitConversions.Add("$INTEGER$" + "¿TO?" + "$LONG$", String.Empty);
            p_nativeImplicitConversions.Add("$INTEGER$" + "¿TO?" + "$FLOAT$", String.Empty);
            p_nativeImplicitConversions.Add("$INTEGER$" + "¿TO?" + "$DOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$INTEGER$" + "¿TO?" + "$LDOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$INTEGER$" + "¿TO?" + "$DECIMAL$", String.Empty);
            p_nativeImplicitConversions.Add("$INTEGER$" + "¿TO?" + "^_$OBJECT$", "BOXING");
            //UNSIGNED
            p_nativeImplicitConversions.Add("$UNSIGNED$" + "¿TO?" + "$LONG$", String.Empty);
            p_nativeImplicitConversions.Add("$UNSIGNED$" + "¿TO?" + "$ULONG$", String.Empty);
            p_nativeImplicitConversions.Add("$UNSIGNED$" + "¿TO?" + "$FLOAT$", String.Empty);
            p_nativeImplicitConversions.Add("$UNSIGNED$" + "¿TO?" + "$DOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$UNSIGNED$" + "¿TO?" + "$LDOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$UNSIGNED$" + "¿TO?" + "$DECIMAL$", String.Empty);
            p_nativeImplicitConversions.Add("$UNSIGNED$" + "¿TO?" + "^_$OBJECT$", "BOXING");
            //LONG
            p_nativeImplicitConversions.Add("$LONG$" + "¿TO?" + "$FLOAT$", String.Empty);
            p_nativeImplicitConversions.Add("$LONG$" + "¿TO?" + "$DOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$LONG$" + "¿TO?" + "$LDOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$LONG$" + "¿TO?" + "$DECIMAL$", String.Empty);
            p_nativeImplicitConversions.Add("$LONG$" + "¿TO?" + "^_$OBJECT$", "BOXING");
            //ULONG
            p_nativeImplicitConversions.Add("$ULONG$" + "¿TO?" + "$FLOAT$", String.Empty);
            p_nativeImplicitConversions.Add("$ULONG$" + "¿TO?" + "$DOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$ULONG$" + "¿TO?" + "$LDOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$ULONG$" + "¿TO?" + "$DECIMAL$", String.Empty);
            p_nativeImplicitConversions.Add("$ULONG$" + "¿TO?" + "^_$OBJECT$", "BOXING");
            //FLOAT
            p_nativeImplicitConversions.Add("$FLOAT$" + "¿TO?" + "$DOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$FLOAT$" + "¿TO?" + "$LDOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$FLOAT$" + "¿TO?" + "^_$OBJECT$", "BOXING");
            //DOUBLE
            p_nativeImplicitConversions.Add("$DOUBLE$" + "¿TO?" + "$LDOUBLE$", String.Empty);
            p_nativeImplicitConversions.Add("$DOUBLE$" + "¿TO?" + "$DECIMAL$", String.Empty);
            p_nativeImplicitConversions.Add("$DOUBLE$" + "¿TO?" + "^_$OBJECT$", "BOXING");
            //LDOUBLE
            p_nativeImplicitConversions.Add("$LDOUBLE$" + "¿TO?" + "$DECIMAL$", String.Empty);
            p_nativeImplicitConversions.Add("$LDOUBLE$" + "¿TO?" + "^_$OBJECT$", "BOXING");
            //DECIMAL
            p_nativeImplicitConversions.Add("$DECIMAL$" + "¿TO?" + "^_$OBJECT$", "BOXING");

            // PENDIENTE : esta converison debe depender del modulo de salida utilizado,
            // es decir de acuerdo al tipo utilizado para implemenar Date.
            p_nativeImplicitConversions.Add(NativeTypes.Date + "¿TO?DotNET.System.DateTime", String.Empty);
            p_nativeImplicitConversions.Add("DotNET.System.DateTime¿TO?" + NativeTypes.Date, String.Empty);
            p_nativeImplicitConversions.Add("DotNET.System.DateTime" + "¿TO?" + "zoe.lang.DateTime", String.Empty);
            p_nativeImplicitConversions.Add("zoe.lang.DateTime" + "¿TO?" + "DotNET.System.DateTime", String.Empty);

            p_nativeImplicitConversions.Add(NativeTypes.Date + "¿TO?zoe.lang.DateTime", String.Empty);
            p_nativeImplicitConversions.Add("zoe.lang.DateTime¿TO?" + NativeTypes.Date, String.Empty);

            p_nativeImplicitConversions.Add(NativeTypes.Date + "¿TO?" + "^_$OBJECT$", "BOXING");

            p_nativeImplicitConversions.Add(NativeTypes.Type + "¿TO?^_$OBJECT$", String.Empty);
            p_nativeImplicitConversions.Add(NativeTypes.Type + "¿TO?^_" + CODEDOM_NAMESPACE + ".XplNode", String.Empty);
            p_nativeImplicitConversions.Add(NativeTypes.Type + "¿TO?^_" + CODEDOM_NAMESPACE + ".XplType", String.Empty);

            p_nativeImplicitConversions.Add(NativeTypes.Block + "¿TO?^_$OBJECT$", String.Empty);
            p_nativeImplicitConversions.Add(NativeTypes.Block + "¿TO?^_" + CODEDOM_NAMESPACE + ".XplNode", String.Empty);
            p_nativeImplicitConversions.Add(NativeTypes.Block + "¿TO?^_" + CODEDOM_NAMESPACE + ".XplFunctionBody", String.Empty);

        }
        #endregion

        /// <summary>
        /// Agrega un error a la colección de errores.
        /// </summary>
        private void AddNewError(Error error)
        {
            if(!(p_ignoreErrorsOnImportedTypes && p_currentDocumentIsImport))
                p_errorCollection.AddError(error);
        }

        #region CheckTypes, IterateDocuments
        bool p_enableDeferedTypeCheck = false;
        private void CheckTypes()
        {          
            DateTime lastTime = DateTime.Now;
            // bajo la bandera de chequeo de tipos diferidos, sino se arma lio
            // cuando se produce una excepcion en checkimplementation y se utiliza la misma
            // instancia del analizador para chequear otro programa
            p_enableDeferedTypeCheck = false;
            Scope currentScope = new Scope(p_types);
            // 1- Leo los tipos de los documentos
            IterateDocuments(currentScope, SemanticAction.ReadTypes);

            // Cargo los tipos bases desde la cache, sino despues tengo problemas :-P
            object temp = p_types[CODEDOM_NAMESPACE + ".XplType"];
            temp = p_types[CODEDOM_NAMESPACE + ".XplFunctionBody"];

            if (p_showInternalTimes) ZOECompilerCore.WriteDebugTextLine("Read Types............: " + ((TimeSpan)(DateTime.Now - lastTime)).ToString());
            lastTime = DateTime.Now;
            // 2- Primero controlo los miembros de los tipos
            IterateDocuments(currentScope, SemanticAction.CheckTypes);

            if (p_showInternalTimes) ZOECompilerCore.WriteDebugTextLine("Initial Types Check...: " + ((TimeSpan)(DateTime.Now - lastTime)).ToString());
            lastTime = DateTime.Now;
            // 3 - Controlo la herencia e implementación de interfaces
            IterateDocuments(currentScope, SemanticAction.CheckInheritance);

            if (p_showInternalTimes) ZOECompilerCore.WriteDebugTextLine("Check Inheritance.....: " + ((TimeSpan)(DateTime.Now - lastTime)).ToString());
            lastTime = DateTime.Now;
            p_enableDeferedTypeCheck = true;
            // 4 - Controlo la implementación - expresiones y cuerpos de funciones
            IterateDocuments(currentScope, SemanticAction.CheckImplementation);
            p_enableDeferedTypeCheck = false;

            if (p_showInternalTimes) ZOECompilerCore.WriteDebugTextLine("Check Implementation..: " + ((TimeSpan)(DateTime.Now - lastTime)).ToString());
        }

        private void IterateDocuments(Scope currentScope, SemanticAction semanticAction)
        {

            p_currentDocumentIsImport = true;
            if (semanticAction != SemanticAction.CheckImplementation)
            {
                p_isClassfactorysDoc = true;
                ProcessDocument(p_classfactorysDocument, currentScope, semanticAction);
                currentScope.ClearUsingDirectives();
                p_isClassfactorysDoc = false;
            }

            // PENDIENTE : ¡Ojo con esta optimización!, puedo tener cuerpo de funciones
            // en los tipos importados desde un modulo de salida, por tanto esto no
            // deberia obviar asi como asi el control de la implementación.
            if (p_importedDocuments != null && 
                semanticAction != SemanticAction.CheckImplementation && 
                semanticAction != SemanticAction.CheckInheritance)
            {
                foreach (XplDocument doc in p_importedDocuments)
                {
                    ProcessDocument(doc, currentScope, semanticAction);
                    currentScope.ClearUsingDirectives();
                }
            }

            p_currentDocumentIsImport = false;
            foreach (XplDocument doc in p_programDocuments)
            {
                ProcessDocument(doc, currentScope, semanticAction);
                // Al eliminar las directivas using del alcance, obtengo el efecto
                // de directivas using locales a cada documento Zoe.
                currentScope.ClearUsingDirectives();
            }

        }
        #endregion

        #region Proccess
        private void ProcessDocument(XplDocument xplDocument, Scope currentScope, SemanticAction semanticAction)
        {
            XplNodeList bodyList = xplDocument.get_DocumentBody().Children();
            // Estableco secciones implicitas por defecto            
            if (semanticAction == SemanticAction.ReadTypes)
            {
                Section tempSection = new Section(xplDocument.get_DocumentBody(), p_currentDocumentIsImport, false, !p_isExtensionModule);
                if (!p_isClassfactorysDoc) p_programSections.Insert(tempSection);
                p_currentSection = tempSection;
                if(!p_isExtensionModule)
                    p_searchForImplicitSection = true;
            }
            foreach (XplNode node in bodyList)
            {
                switch (node.get_ElementName())
                {
                    case "Namespace":
                        ProcessNamespace((XplNamespace)node, currentScope, semanticAction);
                        break;
                    case "Section":
                        ProcessSection((XplNamespace)node, currentScope, semanticAction);
                        break;
                    case "IdentifiersNamespace":
                        ProcessIdentifiersNamespace((XplNamespace)node, currentScope, semanticAction);
                        break;
                    case "Using":
                        ProcessUsing((XplName)node, currentScope, semanticAction);
                        break;
                    case "UsingIdentifiers":
                        ProcessUsingIdentifiers(node, currentScope, semanticAction);
                        break;
                    case "Import":
                        break;
                    case "BeginCFPermissions":
                        ProcessBeginCFPerimissions((XplClassfactorysPermissions)node, currentScope, semanticAction, null);
                        break;
                    case "EndCFPermissions":
                        ProcessEndCFPerimissions(node, currentScope, semanticAction, null);
                        break;
                    case "e":
                        if (semanticAction==SemanticAction.ReadTypes && p_searchForImplicitSection) 
                            p_searchForImplicitSection = false;
                        ProcessExpression((XplExpression)node, currentScope, null, null, semanticAction);
                        break;
                    case "documentation":
                        break;
                    default:
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.UnexpectedNode, node,
                            node.get_ElementName(), "DocumentBody"));
                        break;
                }
            }
        }

        private void ProcessSection(XplNamespace xplNamespace, Scope currentScope, SemanticAction semanticAction)
        {
            if (semanticAction == SemanticAction.ReadTypes)
            {
                if (p_currentSectionIsMissing)
                {
                    p_currentSectionIsMissing = false;
                    p_currentSection = null;
                }
                if (p_currentSection != null)
                {
                    // Puede ser que este usando seccion implicita
                    if (!p_currentSection.IsExplicitSection() && p_searchForImplicitSection)
                    {
                        p_programSections.Remove(p_currentSection);
                        p_searchForImplicitSection = false;
                        p_currentSection = null;
                    }
                    else
                    {
                        p_currentSection.set_IsBadSection(true);
                        // No puedo declarar secciones anidadas
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.InvalidNestedSectionDeclaration, xplNamespace));
                    }
                }
                if (p_currentSection == null)
                {
                    Section newSection = new Section(xplNamespace, p_currentDocumentIsImport, false, currentScope.get_FullNamespaceName());
                    // Chequeo el nombre
                    if (xplNamespace.get_name() != "ordinary" && xplNamespace.get_name() != "extension")
                    { 
                        // Error en el nombre de la sección
                        AddNewError(SemanticError.New(SemanticErrorCode.InvalidSectionName,
                            xplNamespace, xplNamespace.get_name()));
                        // intento corregir el error tratando la sección como ordinaria
                        xplNamespace.set_name("ordinary");
                        newSection.set_IsBadSection(true);
                    }                    
                    p_currentSection = newSection;
                    if (!p_isClassfactorysDoc) p_programSections.Insert(newSection);
                }
            }
            ProcessNamespaceInnerNodes(xplNamespace, currentScope, semanticAction);
            // Luego de procesar los nodos internos establezco a null el puntero de seccion
            // para controlar secciones anidadas y falta de declaración explicita de secciones.
            if (semanticAction == SemanticAction.ReadTypes)
                p_currentSection = null;
        }
        /// <summary>
        /// Utilidad para sobreponerse a una sección faltante.
        /// </summary>
        private void CorrectMissingSection()
        {
            p_currentSectionIsMissing = true;
            p_currentSection = p_programSections.get_LastSection();
            p_programSections.set_MissingSections(true);
        }

        private void ProcessIdentifiersNamespace(XplNamespace xplNamespace, Scope currentScope, SemanticAction semanticAction)
        {
            // PENDIENTE :Implementar los Espacios de Nombres de Identificadores.
            return;
        }

        private void ProcessNamespace(XplNamespace xplNamespace, Scope currentScope, SemanticAction semanticAction)
        {
            int scopeLevels = 0;
            string nsName = xplNamespace.get_name();
            if (TypeString.IsQualifiedName(nsName))
            {
                string[] nsNames = GetNamesFromQualified(nsName);
                if (nsNames != null)
                {
                    foreach (string simpleName in nsNames)
                    {
                        scopeLevels++;

                        if (semanticAction == SemanticAction.ReadTypes && scopeLevels == nsNames.Length)
                        {
                            InsertNamespaceType(currentScope.get_FullName(simpleName), xplNamespace);
                        }
                        else if (semanticAction == SemanticAction.ReadTypes)
                        {
                            nsName =  RemoveSimpleNameFromQualified(nsName);
                            XplNamespace auxNode = XplNamespace.new_Namespace();
                            auxNode.set_name(nsName);
                            InsertNamespaceType( GetInternalQualifiedName(nsName) , auxNode);
                        }

                        currentScope.EnterScope(ScopeType.Namespace, simpleName);
                    }
                }
            }
            else
            {
                if(semanticAction==SemanticAction.ReadTypes)InsertNamespaceType(currentScope.get_FullName(nsName), xplNamespace);
                currentScope.EnterScope(ScopeType.Namespace, nsName);
                scopeLevels++;
            }

            if (semanticAction == SemanticAction.CheckTypes)
            {
                // Bien, pero que debo chequear para un espacio de nombres? que no se utilice un nombre 
                // no permitido por estar reservado por ejemplo.

                //nsName = GetInternalQualifiedName(nsName);
                //TypeInfo nsType = p_types.get_TypeInfo(nsName);

                // Set full source information
                xplNamespace.PersistFullSourceFileInfo();
            }
            if (semanticAction == SemanticAction.CheckImplementation)
                EnterCandidateStructuresScope(xplNamespace);
            // Proceso los tipos anidados al Namespace
            ProcessNamespaceInnerNodes(xplNamespace, currentScope, semanticAction);
            // Retorno al alcance antes de procesar el Namespace
            if (semanticAction == SemanticAction.CheckImplementation)
                LeaveCandidateStructuresScope(xplNamespace);
            for (int i = 0; i < scopeLevels; i++)
            {
                currentScope.LeaveScope();
            }
        }
        private void EnterCandidateStructuresScope(XplNode node)
        {
            CandidateStructure cs = new CandidateStructure(CandidateStructureType.EnterBlock, node);
            p_candidateStructures.Add(cs);
        }
        private void LeaveCandidateStructuresScope(XplNode node)
        {
            CandidateStructure cs = new CandidateStructure(CandidateStructureType.LeaveBlock, node);
            p_candidateStructures.Add(cs);
        }
        private void ProcessNamespaceInnerNodes(XplNamespace xplNamespace, Scope currentScope, SemanticAction semanticAction)
        {
            foreach (XplNode node in xplNamespace.Children())
            {
                switch (node.get_ElementName())
                {
                    case "Section":
                        ProcessSection((XplNamespace)node, currentScope, semanticAction);
                        break;
                    case "Namespace":
                        ProcessNamespace((XplNamespace)node, currentScope, semanticAction);
                        break;
                    case "Class":
                        if (semanticAction == SemanticAction.ReadTypes && p_searchForImplicitSection)
                            p_searchForImplicitSection = false;
                        ProcessClass((XplClass)node, currentScope, semanticAction);
                        break;
                    case "e":
                        if (semanticAction == SemanticAction.ReadTypes && p_searchForImplicitSection)
                            p_searchForImplicitSection = false;
                        ProcessExpression((XplExpression)node, currentScope, null, null, semanticAction);
                        break;
                    case "BeginCFPermissions":
                        ProcessBeginCFPerimissions((XplClassfactorysPermissions)node, currentScope, semanticAction, null);
                        break;
                    case "EndCFPermissions":
                        ProcessEndCFPerimissions(node, currentScope, semanticAction, null);
                        break;
                    case "documentation":
                        break;
                    default:
                        if (semanticAction == SemanticAction.ReadTypes)
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.UnexpectedNode, node,
                                node.get_ElementName(), xplNamespace.get_ElementName()));
                        break;
                }
            }
        }

        private void ProcessEndCFPerimissions(XplNode xplCFPermissions, Scope currentScope, SemanticAction semanticAction, MemberInfo memberInfo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void ProcessBeginCFPerimissions(XplClassfactorysPermissions xplClassfactorysPermissions, Scope currentScope, SemanticAction semanticAction, MemberInfo memberInfo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void ProcessClass(XplClass xplClass, Scope currentScope, SemanticAction semanticAction)
        {
            bool result = false;
            // Si las clase es una classfactory y no estoy compilando un modulo de extension no chequeo la implementación,
            // ya que las classfactorys solo me interesa chequear la implementación
            // cuando las compile en una extensión
            if (semanticAction == SemanticAction.CheckImplementation && (!p_isExtensionModule || p_isClassfactorysDoc) && !p_interactiveOnly && (xplClass.get_isfactory() || xplClass.get_isinteractive()))
                return;

            string className = xplClass.get_name();
            
            if (String.IsNullOrEmpty(className))
            {
                AddNewError(SyntaxError.New(SyntaxErrorCode.UnspecifiedSyntaxError, xplClass, " Class name expected."));
                xplClass.set_name(new XplIName().Identifier);
                className = xplClass.get_name();
            }

            if (TypeString.IsQualifiedName(className))
            {
                if (semanticAction == SemanticAction.ReadTypes)
                {
                    AddNewError(
                        SemanticError.New(
                            SemanticErrorCode.UnexpectedQualifiedNameInTypeDeclaration, xplClass, className)
                        );
                    // Me recupero del error tratando al tipo introducido por
                    // el nombre simple.
                    className = GetSimpleNameFromQualified(className);
                    result = InsertType(currentScope.get_FullName(className), xplClass, null);
                }
                else
                {
                    className = GetSimpleNameFromQualified(className);
                    result = true;
                }
                if (result) currentScope.EnterScope(ScopeType.Class, className);
            }
            else
            {
                if (semanticAction == SemanticAction.ReadTypes && !xplClass.get_extension())
                {
                    result = InsertType(currentScope.get_FullName(className), xplClass, null);
                }
                else
                {
                    result = true;
                }
                if (result) currentScope.EnterScope(ScopeType.Class, className);
            }
            // Si no se pudo agregar el tipo regreso sin procesar el contenido
            if (!result) return;

            TypeInfo classType = p_types.get_TypeInfo(currentScope.get_FullClassName());

            if (classType == null)
            {
                currentScope.LeaveScope();
                return;
            }

            if (semanticAction == SemanticAction.ReadTypes)
            {
                // Primero verifico que ya no haya leido el tipo de forma diferida.
                if (classType.get_TypeReaded() && !xplClass.get_extension())
                {
                    currentScope.LeaveScope();
                    return;
                }
                // If classname contains "'" it's a duplicated class that was detected on other compile time
                if (className.IndexOf('\'') >= 0)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.TypeAlreadyExist,
                        xplClass, className.Substring(0, className.IndexOf('\''))));
                }
                // Si es una enumeración debo agregar los operadores
                if (classType.get_IsEnum() && !xplClass.get_lddata().Contains("$opsadded$"))
                {
                    // UNDONE : this is ugly find another way to flag that operators where added to enums
                    // in a previous compile time
                    xplClass.set_lddata(xplClass.get_lddata() + "$opsadded$");
                    AddEnumOperators(xplClass, currentScope);
                }
                // Levanto esta bandera en el tipo para evitar reentrada
                // cuando estoy leyendo un tipo importado de forma asincrona
                classType.set_IsOnDeferedTypeCheck(true);

                ClassSectionControl(xplClass, className);

                classType.set_Section(p_currentSection);
            }
            if (semanticAction == SemanticAction.CheckTypes)
            {
                // Controlo los modificadores aplicados a la clase sean validos
                XplClass typeNode = (XplClass)classType.get_TypeNode();
                int flagCount = 0;
                if (typeNode.get_isinterface()) flagCount++;
                if (typeNode.get_isstruct()) flagCount++;
                if (typeNode.get_isenum()) flagCount++;
                if (flagCount > 1)
                {
                    typeNode.set_isenum(false);
                    typeNode.set_isinterface(false);
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidCombinationOfClassModifiers, typeNode,
                        classType.get_FullName())
                    );
                }
                if (!typeNode.get_isfactory() && typeNode.get_isinteractive()) typeNode.set_isfactory(true);
                if (typeNode.get_abstract() && typeNode.get_final() && !p_currentDocumentIsImport)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.TypeCanNotBeAbstractAndFinal, typeNode,
                        classType.get_FullName())
                    );
                }
                
                xplClass.PersistFullSourceFileInfo();
            }
            // Creo un nuevo alcance en las estructuras candidatas
            if (semanticAction == SemanticAction.CheckImplementation)
                EnterCandidateStructuresScope(xplClass);
            // Proceso los tipos anidados al Tipo y sus miembros
            XplNodeList classChildren = xplClass.Children();
            if (classChildren != null)
            {
                for (int n = 0; n < classChildren.GetLength(); n++)
                {
                    XplNode node = classChildren.GetNodeAt(n);
                    int backErrorsCount = 0;
                    MemberInfo memberInfo = null;
                    if (semanticAction == SemanticAction.CheckTypes)
                    {
                        classType.set_TypeChequed(true);
                        backErrorsCount = p_errorCollection.Count;
                    }
                    if (semanticAction == SemanticAction.CheckTypes || semanticAction == SemanticAction.CheckImplementation)
                    {
                        memberInfo = classType.get_MemberInfoCollection().get_MemberFromNode(node);
                    }

                    ProcessClassMember(xplClass, currentScope, semanticAction, classType, node, memberInfo);

                    if (semanticAction == SemanticAction.CheckTypes && backErrorsCount < p_errorCollection.Count && memberInfo != null)
                    {
                        memberInfo.set_IsBadMember(true);
                    }
                }
            }
            // Una vez listo los miembros controlo la herencia e implementación
            if (semanticAction == SemanticAction.CheckInheritance) 
                CheckBasesAndInterfaces(classType, currentScope);
            // Retorno al alcance antes de procesar el Tipo
            if (semanticAction == SemanticAction.CheckImplementation)
            {
                if (!classType.get_IsFactory() && !classType.get_IsInteractive())
                {
                    BaseInfoCollection baseCollection = classType.get_BaseInfoCollection();
                    foreach (BaseInfo baseInfo in baseCollection.get_BaseInfoList())
                    {
                        TypeInfo baseTypeInfo = baseInfo.get_BaseTypeInfo();
                        if (baseTypeInfo != null && baseTypeInfo.get_IsFactory())
                            CheckForTypeConstructorCallOrSymbol(baseInfo, currentScope);
                    }
                }

                LeaveCandidateStructuresScope(xplClass);
            }
            if (semanticAction == SemanticAction.ReadTypes)
            {
                // Levanto esta bandera en el tipo para evitar reentrada
                // cuando estoy leyendo un tipo importado de forma asincrona
                classType.set_IsOnDeferedTypeCheck(false);
                classType.set_TypeReaded(true);
            }

            currentScope.LeaveScope();
        }

        private void ClassSectionControl(XplClass xplClass, string className)
        {
            // Debo controlar que la sección sea valida y que exista
            // -Primero controlo que exista una seccion, sino lo corrijo
            if (p_currentSection == null)
            {
                CorrectMissingSection();
                AddNewError(
                    SemanticError.New(SemanticErrorCode.MissingSectionDeclaration, xplClass));
            }
            if (xplClass.get_isfactory() || xplClass.get_isinteractive())
            {
                if (!p_currentSection.IsExtension() && !p_isExtensionModule)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidFactoryTypeDeclarationInOrdinarySection,
                        xplClass, className));
                    p_currentSection.set_IsBadSection(true);
                }
            }
            else if (!p_currentSection.IsOrdinary())
            {
                // Deberia permitir clases comunes en secciones de extension
                // explicitas                    
                if (!p_currentSection.IsExplicitSection())
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidTypeDeclarationInExtensionSection,
                        xplClass, className));
                    p_currentSection.set_IsBadSection(true);
                }
            }
        }

        private void ProcessClassMember(XplClass xplClass, Scope currentScope, SemanticAction semanticAction, TypeInfo classType, XplNode node, MemberInfo memberInfo)
        {
            try
            {
                switch (node.get_ElementName())
                {
                    case "Class":
                        // only process inner types if parent isn't on defered type check
                        //if(classType == null || (classType!=null && !classType.get_IsOnDeferedTypeCheck()) )
                        ProcessClass((XplClass)node, currentScope, semanticAction);
                        break;
                    case "Implements":
                    case "Inherits":
                        if (semanticAction == SemanticAction.ReadTypes)
                            ProcessInherits((XplInherits)node, classType, currentScope, semanticAction);
                        break;
                    case "SetPlatforms":
                        ProcessSetPlatforms((XplSetPlatforms)node, currentScope, semanticAction);
                        break;
                    case "AutoInstance":
                        ProcessAutoInstance((XplAutoInstance)node, currentScope, semanticAction);
                        break;
                    case "BeginCFPermissions":
                        ProcessBeginCFPerimissions((XplClassfactorysPermissions)node, currentScope, semanticAction, null);
                        break;
                    case "EndCFPermissions":
                        ProcessEndCFPerimissions(node, currentScope, semanticAction, null);
                        break;

                    case "Function":
                        if (semanticAction == SemanticAction.ReadTypes)
                        {
                            XplFunction function = null;
                            string typeName = null;
                            function = (XplFunction)node;
                            if (function.get_fp())
                            {
                                // Si es una declaración de puntero a función agrego el tipo.
                                typeName = function.get_name();
                                if (TypeString.IsQualifiedName(typeName))
                                    typeName = GetSimpleNameFromQualified(typeName);
                                MemberInfo fpMember = new MemberInfo(classType, classType, function);
                                classType.get_MemberInfoCollection().InsertMemberInfo(fpMember);
                                if (InsertType(currentScope.get_FullName(typeName), function, fpMember))
                                {
                                    Debug.Assert(p_currentSection != null, "p_currentSection NULO al insertar tipo de puntero a funcion.");
                                    TypeInfo funcPointerType = p_types.get_TypeInfo(currentScope.get_FullName(typeName));
                                    funcPointerType.set_Section(p_currentSection);
                                }
                            }
                        }
                        if (semanticAction != SemanticAction.CheckInheritance)
                            ProcessFunction((XplFunction)node, classType, currentScope, semanticAction, memberInfo);
                        break;
                    case "Operator":
                        if (semanticAction != SemanticAction.CheckInheritance)
                            ProcessOperator((XplFunction)node, classType, currentScope, semanticAction, memberInfo);
                        break;
                    case "Indexer":
                        if (semanticAction != SemanticAction.CheckInheritance)
                            ProcessIndexer((XplFunction)node, classType, currentScope, semanticAction, memberInfo);
                        break;
                    case "Property":
                        if (semanticAction != SemanticAction.CheckInheritance)
                            ProcessProperty((XplProperty)node, classType, currentScope, semanticAction, memberInfo);
                        break;
                    case "Field":
                        if (semanticAction != SemanticAction.CheckInheritance)
                            ProcessField((XplField)node, classType, currentScope, semanticAction, memberInfo);
                        break;
                    case "e":
                        if (semanticAction == SemanticAction.ReadTypes)
                            classType.get_MemberInfoCollection().InsertMemberInfo(
                                new MemberInfo(classType, classType, node));
                        // PENDIENTE : chequear, si en la accion "ReadTypes" sólo se controla
                        // que las expresiones no se encuentren fuera de secciones esta llamada
                        // no hace falta, es una perdida de tiempo.
                        if (semanticAction != SemanticAction.CheckInheritance)
                            ProcessExpression((XplExpression)node, currentScope, classType, memberInfo, semanticAction);
                        break;

                    case "documentation":
                        break;
                    default:
                        if (semanticAction == SemanticAction.ReadTypes)
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.UnexpectedNode, node,
                                node.get_ElementName(), xplClass.get_ElementName()));
                        break;
                }
            }
            catch (Exception error)
            {
                AddNewError(SemanticError.New(SemanticErrorCode.UnspecifiedSemanticError,
                    p_programDocuments[1], " Internal Compiler error incorrectly managed while checking types. Please report this error to Zoe compiler Team - http://layerd.net. \nError Detail :" +
                    error.Message + "\nStack trace: " + error.StackTrace + "\n\nProcessing member: " + (memberInfo != null ? memberInfo.FullName : "-null-") + "\n[" + node.FullSourceFileInfo + "]\n" + node.ZoeXmlString ));
            }
        }
        /// <summary>
        /// Add operators to a enum type
        /// </summary>
        /// <param name="xplClass">Class node of the enum type</param>
        /// <param name="currentScope">Current scope</param>
        private void AddEnumOperators(XplClass xplClass, Scope currentScope)
        {
            return;

            XplType enumType = new XplType();
            enumType.set_typename(currentScope.get_FullClassName());

            XplNodeList classMembers = xplClass.Children();

            //Operadores binarios aritmeticos y de bits
            classMembers.InsertAtEnd(
                CreateEnumBinaryOperator(enumType, XplBinaryoperators_enum.ADD)
            );
            classMembers.InsertAtEnd(
                CreateEnumBinaryOperator(enumType, XplBinaryoperators_enum.MIN)
            );
            classMembers.InsertAtEnd(
                CreateEnumBinaryOperator(enumType, XplBinaryoperators_enum.BOR)
            );
            classMembers.InsertAtEnd(
                CreateEnumBinaryOperator(enumType, XplBinaryoperators_enum.BAND)
            );
            classMembers.InsertAtEnd(
                CreateEnumBinaryOperator(enumType, XplBinaryoperators_enum.XOR)
            );
            //Operadores unarios
            classMembers.InsertAtEnd(
                CreateEnumUnaryOperator(enumType, XplUnaryoperators_enum.ONECOMP)
            );
            classMembers.InsertAtEnd(
                CreateEnumUnaryOperator(enumType, XplUnaryoperators_enum.INC)
            );
            classMembers.InsertAtEnd(
                CreateEnumUnaryOperator(enumType, XplUnaryoperators_enum.DEC)
            );
            //Operadores logicos
            classMembers.InsertAtEnd(
                CreateEnumLogicOperator(enumType, XplBinaryoperators_enum.EQ)
            );
            classMembers.InsertAtEnd(
                CreateEnumLogicOperator(enumType, XplBinaryoperators_enum.NOTEQ)
            );
            classMembers.InsertAtEnd(
                CreateEnumLogicOperator(enumType, XplBinaryoperators_enum.LS)
            );
            classMembers.InsertAtEnd(
                CreateEnumLogicOperator(enumType, XplBinaryoperators_enum.GR)
            );
            classMembers.InsertAtEnd(
                CreateEnumLogicOperator(enumType, XplBinaryoperators_enum.LSEQ)
            );
            classMembers.InsertAtEnd(
                CreateEnumLogicOperator(enumType, XplBinaryoperators_enum.GREQ)
            );
            
        }

        private static XplNode CreateEnumLogicOperator(XplType enumType, XplBinaryoperators_enum xplBinaryoperator_enum)
        {
		    // Operadores logicos
		    //extern static bool operator==(int opA, int OpB);
		    //extern static bool operator!=(int opA, int OpB);
		    //extern static bool operator>(int opA, int OpB);
		    //extern static bool operator<(int opA, int OpB);
		    //extern static bool operator>=(int opA, int OpB);
		    //extern static bool operator<=(int opA, int OpB);
            XplFunction operatorFunc = XplClass.new_Operator();
            operatorFunc.set_Parameters(XplFunction.new_Parameters());
            operatorFunc.set_storage(XplVarstorage_enum.STATIC_EXTERN);
            operatorFunc.set_access(XplAccesstype_enum.PUBLIC);
            operatorFunc.set_donotrender(true);
            XplType retType = new XplType();
            retType.set_typename(NativeTypes.Boolean);
            operatorFunc.set_ReturnType(retType);
            switch (xplBinaryoperator_enum)
            {
                case XplBinaryoperators_enum.EQ:
                    operatorFunc.set_name("%op_eq%");
                    break;
                case XplBinaryoperators_enum.NOTEQ:
                    operatorFunc.set_name("%op_noteq%");
                    break;
                case XplBinaryoperators_enum.LS:
                    operatorFunc.set_name("%op_lst%");
                    break;
                case XplBinaryoperators_enum.GR:
                    operatorFunc.set_name("%op_gtr%");
                    break;
                case XplBinaryoperators_enum.GREQ:
                    operatorFunc.set_name("%op_greq%");
                    break;
                case XplBinaryoperators_enum.LSEQ:
                    operatorFunc.set_name("%op_lseq%");
                    break;
                default:
                    Debug.Assert(false, "Funcion llamada con argumento incorrecto");
                    break;
            }
            XplParameter parameter = XplParameters.new_P();
            parameter.set_name("opA");
            parameter.set_type((XplType)enumType.Clone());
            operatorFunc.get_Parameters().Children().InsertAtEnd(parameter);
            parameter = XplParameters.new_P();
            parameter.set_name("opB");
            parameter.set_type((XplType)enumType.Clone());
            operatorFunc.get_Parameters().Children().InsertAtEnd(parameter);
            return operatorFunc;
        }

        private static XplNode CreateEnumUnaryOperator(XplType enumType, XplUnaryoperators_enum xplUnaryoperators_enum)
        {
		    // Operadores unarios
		    //extern static int operator~(int opA);
		    //extern static int operator++(int opA);
		    //extern static int operator--(int opA);
            XplFunction operatorFunc = XplClass.new_Operator();
            operatorFunc.set_Parameters(XplFunction.new_Parameters());
            operatorFunc.set_storage(XplVarstorage_enum.STATIC_EXTERN);
            operatorFunc.set_donotrender(true);
            operatorFunc.set_access(XplAccesstype_enum.PUBLIC);
            operatorFunc.set_ReturnType((XplType)enumType.Clone());
            switch (xplUnaryoperators_enum)
            {
                case XplUnaryoperators_enum.ONECOMP:
                    operatorFunc.set_name("%op_add%");
                    break;
                case XplUnaryoperators_enum.INC:
                    operatorFunc.set_name("%op_inc%");
                    break;
                case XplUnaryoperators_enum.DEC:
                    operatorFunc.set_name("%op_dec%");
                    break;
                default:
                    Debug.Assert(false, "Funcion llamada con argumento incorrecto");
                    break;
            }
            XplParameter parameter = XplParameters.new_P();
            parameter.set_name("opA");
            parameter.set_type((XplType)enumType.Clone());
            operatorFunc.get_Parameters().Children().InsertAtEnd(parameter);
            return operatorFunc;
        }

        private static XplNode CreateEnumBinaryOperator(XplType enumType, XplBinaryoperators_enum xplBinaryoperator_enum)
        {
		    // Operadores binarios
		    //extern static int operator+(int opA, int OpB);
		    //extern static int operator-(int opA, int OpB);
		    // Operadores de bits
		    //extern static int operator|(int opA, int OpB);
		    //extern static int operator&(int opA, int OpB);
		    //extern static int operator^(int opA, int OpB);
            XplFunction operatorFunc = XplClass.new_Operator();
            operatorFunc.set_Parameters(XplFunction.new_Parameters());
            operatorFunc.set_storage(XplVarstorage_enum.STATIC_EXTERN);
            operatorFunc.set_donotrender(true);
            operatorFunc.set_access(XplAccesstype_enum.PUBLIC);
            operatorFunc.set_ReturnType((XplType)enumType.Clone());
            switch (xplBinaryoperator_enum)
            {
                case XplBinaryoperators_enum.ADD:
                    operatorFunc.set_name("%op_add%");
                    break;
                case XplBinaryoperators_enum.MIN:
                    operatorFunc.set_name("%op_min%");
                    break;
                case XplBinaryoperators_enum.BOR:
                    operatorFunc.set_name("%op_bor%");
                    break;
                case XplBinaryoperators_enum.BAND:
                    operatorFunc.set_name("%op_band%");
                    break;
                case XplBinaryoperators_enum.XOR:
                    operatorFunc.set_name("%op_xor%");
                    break;
                default:
                    Debug.Assert(false, "Funcion llamada con argumento incorrecto");
                    break;
            }
            XplParameter parameter = XplParameters.new_P();
            parameter.set_name("opA");
            parameter.set_type((XplType)enumType.Clone());
            operatorFunc.get_Parameters().Children().InsertAtEnd(parameter);
            parameter = XplParameters.new_P();
            parameter.set_name("opB");
            parameter.set_type((XplType)enumType.Clone());
            operatorFunc.get_Parameters().Children().InsertAtEnd(parameter);
            return operatorFunc;
        }

        private void ProcessField(XplField xplField, TypeInfo classType, Scope currentScope, SemanticAction semanticAction, MemberInfo memberInfo)
        {
            string errorStr = "On declaration of field \"" + xplField.get_name() + "\".";
            if (semanticAction == SemanticAction.ReadTypes)
            {
                int backCount = p_errorCollection.Count;
                CheckValidIdentifier(xplField.get_name(), xplField, errorStr);
                //Chequeo el acceso antes de agregar el MemberInfo, todos los campos
                //se fuerzan a publicos
                if (classType.get_IsEnum())
                {
                    //Si no es el campo "_value$" es un campo común y debo
                    //establecer el tipo del campo al tipo de la enumeracion
                    if (xplField.get_name() != "_value$")
                    {
                        XplType fieldEnumType = new XplType();
                        fieldEnumType.set_typename(currentScope.get_FullClassName());
                        xplField.set_type(fieldEnumType);
                    }
                    if (xplField.get_access() == XplAccesstype_enum.PRIVATE || xplField.get_access() == XplAccesstype_enum.PROTECTED)
                        xplField.set_access(XplAccesstype_enum.PUBLIC);
                    else if (xplField.get_access() == XplAccesstype_enum.IPRIVATE || xplField.get_access() == XplAccesstype_enum.IPROTECTED)
                        xplField.set_access(XplAccesstype_enum.IPUBLIC);
                }
                if (classType.get_IsInterface())
                {
                    AddNewError(SemanticError.New(SemanticErrorCode.InvalidFieldAsMemberOfInterface,
                        xplField, xplField.get_name(), classType.get_Name()));
                }
                //Chequeo que no exista otro campo o propiedad con el mismo nombre
                MemberInfo[] members = classType.get_MemberInfoCollection().get_MembersInfoOfType(xplField.get_name());
                if (members != null)
                {
                    foreach (MemberInfo member in members)
                        if (member.get_MemberName() == xplField.get_name() && (member.IsField() || member.IsProperty()))
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.DuplicatedMemberName, xplField,
                                xplField.get_name(), classType.get_FullName(), errorStr)
                                );
                            break;
                        }
                }
                memberInfo = new MemberInfo(classType, classType, xplField);
                classType.get_MemberInfoCollection().InsertMemberInfo(memberInfo);
                //Lo marco si es un miembro con errores
                if (p_errorCollection.Count > backCount) memberInfo.set_IsBadMember(true);
            }
            else if (semanticAction == SemanticAction.CheckTypes)
            {
                XplType fieldType = xplField.get_type();
                //Calculo la cadena del tipo y que el tipo exista.
                CheckType(fieldType, xplField, currentScope, xplField.get_isfactory() || classType.get_IsFactory(), errorStr);
                if (fieldType.get_const())
                {
                    //Si es constante debo calcular el valor
                    object constantValue = null;
                    //PENDIENTE : procesar inicializador de campo constante
                    memberInfo.set_ConstantValue(constantValue);
                }
                //Chequeo los modificadores de declaracion del miembro.
            }
            else if (semanticAction == SemanticAction.CheckImplementation)
            {
                //Tengo que chequear el inicializador si existe
                if (xplField.get_i() != null) CheckInitializer(xplField, classType, currentScope, memberInfo);
                //Agrego la llamada al constructor de tipo si es necesario
                CheckForTypeConstructorCallOrSymbol(xplField.get_type(), currentScope, GetVirtualNameForField(xplField.get_name(), currentScope) );
            }
        }

        private static string GetVirtualNameForField(string fieldName, Scope currentScope)
        {
            string tempName = currentScope.get_FullClassName() + Scope.ScopeSeparator + fieldName;
            return tempName.Replace('.', '_');
        }

        private void ProcessProperty(XplProperty xplProperty, TypeInfo classType, Scope currentScope, SemanticAction semanticAction, MemberInfo memberInfo)
        {
            string errorStr = "On declaration of property \"" + xplProperty.get_name() + "\".";
            if (semanticAction == SemanticAction.ReadTypes)
            {
                int backCount = p_errorCollection.Count;
                CheckValidIdentifier(xplProperty.get_name(), xplProperty, errorStr);
                //Chequeo que no exista otro campo o propiedad con el mismo nombre
                MemberInfo[] members = classType.get_MemberInfoCollection().get_MembersInfoOfType(xplProperty.get_name());
                if (members != null)
                    foreach (MemberInfo member in members)
                        if (member.get_MemberName() == xplProperty.get_name() && (member.IsField() || member.IsProperty()))
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.DuplicatedMemberName, xplProperty,
                                xplProperty.get_name(), classType.get_FullName(), errorStr)
                                );
                            break;
                        }
                memberInfo = new MemberInfo(classType, classType, xplProperty);
                classType.get_MemberInfoCollection().InsertMemberInfo(memberInfo);

                //Lo marco si es un miembro con errores                
                if (p_errorCollection.Count > backCount) memberInfo.set_IsBadMember(true);
            }
            else if (semanticAction == SemanticAction.CheckTypes)
            {
                XplType propertyType = xplProperty.get_type();
                //Calculo la cadena del tipo y que el tipo exista.
                CheckType(propertyType, xplProperty, currentScope, xplProperty.get_isfactory() || classType.get_IsFactory(), errorStr);

                //Chequeo los modificadores de declaracion del miembro.
                CheckCommonMemberModifiers(xplProperty, xplProperty.get_abstract(), xplProperty.get_final(), xplProperty.get_virtual(), xplProperty.get_nonvirtual(), xplProperty.get_override(), errorStr, classType);

                //Chequeo que existan los accesos y que no haya accesos duplicados
                CheckCommonAccesorsControls(xplProperty, memberInfo, xplProperty.get_body(), xplProperty.get_storage(), xplProperty.get_abstract() || memberInfo.get_DeclarationClassType().get_IsInterface() || xplProperty.CurrentClass.get_external(), errorStr);
            }
            else if (semanticAction == SemanticAction.CheckImplementation)
            {
                //Agrego la llamada al constructor de tipo si es necesario
                CheckForTypeConstructorCallOrSymbol(xplProperty.get_type(), currentScope, null);
                XplFunctionBody body = xplProperty.get_body();
                if (body != null)
                    ProcessBlock(body, classType, currentScope, memberInfo);
            }
        }
        /// <summary>
        /// Crea el simbolo para "value" en los cuerpos de propiedades o
        /// indexadores "set".
        /// </summary>
        private void CreateValueSymbol(XplFunctionBody body, XplType xplType, MemberInfo memberInfo, Scope currentScope)
        {
            XplDeclarator decl = XplDeclaratorlist.new_d();
            decl.set_name("value");
            XplType type = (XplType)xplType.Clone();            
            decl.set_type(type);
            CheckType(type, body, currentScope, memberInfo.IsFactory() || memberInfo.get_ClassType().get_IsFactory() , null);
            currentScope.InsertSymbol(new Symbol(decl, decl.get_name()));
        }
        /// <summary>
        /// Crea el simbolo para "this".
        /// </summary>
        private void CreateThisSymbol(XplFunctionBody body, TypeInfo classType, Scope currentScope)
        {
            XplDeclarator decl = XplDeclaratorlist.new_d();
            decl.set_name("this");
            XplType type = XplDeclarator.new_type();
            type.set_ispointer(true);
            XplPointerinfo pi = XplType.new_pi();
            pi.set_ref(true);
            type.set_pi(pi);
            XplType innerType = XplType.new_dt();
            innerType.set_typename(classType.get_FullName());
            type.set_dt(innerType);
            decl.set_type(type);
            CheckType(type, body, currentScope, false, null);
            currentScope.InsertSymbol(new Symbol(decl, decl.get_name()));
            // Insert base symbol
            foreach (BaseInfo baseInfo in classType.get_BaseInfoCollection().get_BaseInfoList())
            {
                if (baseInfo.get_IsInherit() && baseInfo.get_BaseTypeInfo()!=null)
                {
                    decl = XplDeclaratorlist.new_d();
                    decl.set_name("base");
                    type = XplDeclarator.new_type();
                    type.set_ispointer(true);
                    pi = XplType.new_pi();
                    pi.set_ref(true);
                    type.set_pi(pi);
                    innerType = XplType.new_dt();
                    innerType.set_typename(baseInfo.get_BaseTypeInfo().get_FullName());
                    type.set_dt(innerType);
                    decl.set_type(type);
                    CheckType(type, body, currentScope, false, null);
                    currentScope.InsertSymbol(new Symbol(decl, decl.get_name()));
                    break;
                }
            }
        }


        private void ProcessIndexer(XplFunction xplFunction, TypeInfo classType, Scope currentScope, SemanticAction semanticAction, MemberInfo memberInfo)
        {
            string errorStr = "On declaration of indexer.";
            if (semanticAction == SemanticAction.ReadTypes)
            {
                classType.get_MemberInfoCollection().InsertMemberInfo(new MemberInfo(classType, classType, xplFunction));
                xplFunction.set_internalname(xplFunction.get_name() + "#" + classType.get_MemberInfoCollection().GetLenght());
            }
            else if (semanticAction == SemanticAction.CheckTypes)
            {
                //Chequeo el tipo de retorno
                CheckType(xplFunction.get_ReturnType(), xplFunction, currentScope, xplFunction.get_isfactory() || classType.get_IsFactory(), errorStr);

                //Chequeo los tipos de los parametros
                CheckParameters(xplFunction, classType, currentScope, xplFunction.get_access(), errorStr);

                //Chequeo que sea unica o una sobrecarga valida
                CheckMethodOverload(memberInfo, xplFunction, classType, currentScope);

                //Chequeo los modificadores de declaracion del miembro.
                CheckCommonMemberModifiers(xplFunction, xplFunction.get_abstract(), xplFunction.get_final(), xplFunction.get_virtual(), xplFunction.get_nonvirtual(), xplFunction.get_override(), errorStr, classType);

                //Chequeo que existan los accesos y que no haya accesos duplicados
                CheckCommonAccesorsControls(xplFunction, memberInfo, xplFunction.get_FunctionBody(), xplFunction.get_storage(), xplFunction.get_abstract() || memberInfo.get_DeclarationClassType().get_IsInterface() || xplFunction.CurrentClass.get_external(), errorStr);
            }
            else if (semanticAction == SemanticAction.CheckImplementation)
            {
                //Agrego la llamada al constructor de tipo si es necesario
                CheckForTypeConstructorCallOrSymbol(xplFunction.get_ReturnType(), currentScope, null);
                XplFunctionBody body = xplFunction.get_FunctionBody();
                if (body != null)
                {
                    CreateParametersSymbols(xplFunction.get_Parameters(), classType, memberInfo, currentScope);
                    ProcessBlock(body, classType, currentScope, memberInfo);
                }
            }
        }

        private void CheckMethodOverload(MemberInfo memberInfo, XplFunction xplFunction, TypeInfo classType, Scope currentScope)
        {
            MemberInfoCollection members = classType.get_MemberInfoCollection();
            MemberInfo[] sameNameMembers=members.get_MembersInfoOfType(xplFunction.get_name());
            if(sameNameMembers==null)return;
            foreach (MemberInfo member in sameNameMembers)
                if(member!=memberInfo  && (member.IsMethod() || member.IsIndexer()))
                    if (IsSameSignature(memberInfo, member, currentScope))
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.InvalidMemberOverloadSignatureAlreadyExists,
                            xplFunction, memberInfo.ToString()));
                        return;
                    }
        }

        private void ProcessOperator(XplFunction xplFunction, TypeInfo classType, Scope currentScope, SemanticAction semanticAction, MemberInfo memberInfo)
        {
            string errorStr = "On declaration of \"" + xplFunction.get_name() + "\" operator.";
            if (semanticAction == SemanticAction.ReadTypes)
            {
                // TODO : assert removed because of limited support for class extensions added
                // Debug.Assert(classType.get_TypeReaded() == false, "The type was already readed.");
                classType.get_MemberInfoCollection().InsertMemberInfo(new MemberInfo(classType, classType, xplFunction));
                xplFunction.set_internalname(xplFunction.get_name() + "#" + classType.get_MemberInfoCollection().GetLenght());
            }
            else if (semanticAction == SemanticAction.CheckTypes)
            {
                //Los operadores deben ser estáticos
                if(!memberInfo.IsStatic())
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidNonStaticOperatorDeclaration, xplFunction,
                        xplFunction.get_name(), classType.get_FullName()));

                //Chequeo el tipo de retorno
                CheckType(xplFunction.get_ReturnType(), xplFunction, currentScope, xplFunction.get_isfactory() || classType.get_IsFactory(), errorStr);

                //Chequeo los tipos de los parametros
                CheckParameters(xplFunction, classType, currentScope, xplFunction.get_access(), errorStr);

                // PENDIENTE : controlar la cantidad y tipo de parametros de acuerdo al tipo
                // de operador que estemos hablando.

                //Chequeo que la cantidad y tipo de parametros sean validos
                XplParameters parameters = memberInfo.get_Parameters();
                if (parameters == null || parameters.Children().GetLength() < 1 || parameters.Children().GetLength() > 2)
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidNumberOfParameters, xplFunction,
                        errorStr, "On type '" + classType.get_FullName() + "'."));

                if (!classType.get_IsFactory() || !p_isExtensionModule || classType.get_IsCompiledClassfactory())
                {
                    // if it's a conversion operator add to conversion tables
                    if (IsImplicitConversionOperator(xplFunction.get_name())) AddCustomImplicitConversion(xplFunction, memberInfo, currentScope);
                    else if (IsExplicitConversionOperator(xplFunction.get_name())) AddCustomExplicitConversion(xplFunction, memberInfo, currentScope);
                    else AddCustomOperator(xplFunction, memberInfo, currentScope);
                }

                //Chequeo los modificadores de declaracion del miembro.
                CheckCommonMemberModifiers(xplFunction, xplFunction.get_abstract(), xplFunction.get_final(), xplFunction.get_virtual(), xplFunction.get_nonvirtual(), xplFunction.get_override(), errorStr, classType);
            }
            else if (semanticAction == SemanticAction.CheckImplementation)
            {
                //Agrego la llamada al constructor de tipo si es necesario
                CheckForTypeConstructorCallOrSymbol(xplFunction.get_ReturnType(), currentScope, null);
                currentScope.EnterScope(ScopeType.Block, null);
                CreateParametersSymbols(xplFunction.get_Parameters(), classType, memberInfo, currentScope);
                if (xplFunction.get_FunctionBody() != null)
                {
                    if (!memberInfo.IsStatic())
                        CreateThisSymbol(xplFunction.get_FunctionBody(), classType, currentScope);
                    ProcessBlock(xplFunction.get_FunctionBody(), classType, currentScope, memberInfo);
                }
                currentScope.LeaveScope();
            }
        }

        private void AddCustomOperator(XplFunction xplFunction, MemberInfo memberInfo, Scope currentScope)
        {
            XplNodeList parameters = xplFunction.get_Parameters().Children();
            if (parameters == null) return;

            // check parameters count to determine if it is binary or unary operator
            int paramCount = xplFunction.get_Parameters().Children().GetLength();
            var operatorName = xplFunction.get_name();

            Hashtable table = null;
            if (paramCount == 1) table = p_customUnaryOperators;
            else if (paramCount == 2) table = p_customBinaryOperators;
            else return;

            ArrayList operatorList;
            if (table.ContainsKey(operatorName))
            {
                operatorList = (ArrayList)table[operatorName];
            }
            else
            {
                operatorList = new ArrayList();
                table.Add(operatorName, operatorList);
            }
            operatorList.Add(memberInfo);
        }

        private static bool IsExplicitConversionOperator(string operatorName)
        {
            return operatorName.EndsWith("_explicit%");
        }

        private void AddCustomExplicitConversion(XplFunction xplFunction, MemberInfo memberInfo, Scope currentScope)
        {
            string returnType = xplFunction.get_ReturnType().get_typeStr();
            string parameterType = ((XplParameter)xplFunction.get_Parameters().Children().FirstNode()).get_type().get_typeStr();
            
            if (String.IsNullOrEmpty(returnType) || String.IsNullOrEmpty(parameterType)) return;

            string conversionKey = parameterType + "¿TO?" + returnType;
            if (p_customExplicitConversions.ContainsKey(conversionKey))
            {
                AddNewError(SemanticError.New(SemanticErrorCode.CustomExplicitConversionOperationAlreadyDefined,
                    xplFunction, parameterType, returnType, ((MemberInfo)p_customExplicitConversions[conversionKey]).get_ClassTypeFullName()));
                return;
            }

            // add to conversion table
            p_customExplicitConversions.Add(conversionKey, memberInfo);
        }

        private static bool IsImplicitConversionOperator(string operatorName)
        {
            return operatorName.EndsWith("_implicit%");
        }

        private void AddCustomImplicitConversion(XplFunction xplFunction, MemberInfo memberInfo, Scope currentScope)
        {
            string returnType = xplFunction.get_ReturnType().get_typeStr();
            string parameterType = ((XplParameter)xplFunction.get_Parameters().Children().FirstNode()).get_type().get_typeStr();
            
            if (String.IsNullOrEmpty(returnType) || String.IsNullOrEmpty(parameterType)) return;

            string conversionKey = parameterType + "¿TO?" + returnType;
            if (p_customImplicitConversions.ContainsKey(conversionKey))
            {
                AddNewError(SemanticError.New(SemanticErrorCode.CustomImplicitConversionOperationAlreadyDefined,
                    xplFunction, parameterType, returnType, ((MemberInfo)p_customImplicitConversions[conversionKey]).get_ClassTypeFullName()));
                return;
            }

            // add to conversion table
            p_customImplicitConversions.Add(conversionKey, memberInfo);
        }

        private void ProcessFunction(XplFunction xplFunction, TypeInfo classType, Scope currentScope, SemanticAction semanticAction, MemberInfo memberInfo)
        {
            string errorStr = "On declaration of \"" + xplFunction.get_name() + "\" function.";
            if (semanticAction == SemanticAction.ReadTypes)
            {
                // TODO : assert removed because of limited support for class extensions added
                // Debug.Assert(classType.get_TypeReaded() == false, "The type was already readed.");
                if(!xplFunction.get_fp()) classType.get_MemberInfoCollection().InsertMemberInfo(new MemberInfo(classType, classType, xplFunction));
                xplFunction.set_internalname(xplFunction.get_name() + "#" + classType.get_MemberInfoCollection().GetLenght());
            }
            else if (semanticAction == SemanticAction.CheckTypes)
            {
                //Chequeo el tipo de retorno
                CheckType(xplFunction.get_ReturnType(), xplFunction, currentScope, xplFunction.get_isfactory() || classType.get_IsFactory(), errorStr);
                if (xplFunction.get_ReturnType() == null)
                {
                    xplFunction.set_ReturnType(new XplType());
                }

                //Chequeo los tipos de los parametros
                CheckParameters(xplFunction, classType, currentScope, xplFunction.get_access(), errorStr);

                //Chequeo que sea unica o una sobrecarga valida
                CheckMethodOverload(memberInfo, xplFunction, classType, currentScope);

                //Chequeo los modificadores de declaracion del miembro.
                CheckCommonMemberModifiers(xplFunction, xplFunction.get_abstract(), xplFunction.get_final(), xplFunction.get_virtual(), xplFunction.get_nonvirtual(), xplFunction.get_override(), errorStr, classType);

                //Controlo Constructores Validos.
                if (xplFunction.get_name() == classType.get_Name())
                {
                    // TODO add checks for constructors
                }
            }
            else if (semanticAction == SemanticAction.CheckImplementation)
            {
                CheckForTypeConstructorCallOrSymbol(xplFunction.get_ReturnType(), currentScope, null);
                currentScope.EnterScope(ScopeType.Block, null);
                EnterCandidateStructuresScope(xplFunction);
                CreateParametersSymbols(xplFunction.get_Parameters(), classType, memberInfo, currentScope);
                if (xplFunction.get_FunctionBody() != null)
                {
                    if (!memberInfo.IsStatic())
                        CreateThisSymbol(xplFunction.get_FunctionBody(), classType, currentScope);
                    ProcessBlock(xplFunction.get_FunctionBody(), classType, currentScope, memberInfo);
                }
                LeaveCandidateStructuresScope(xplFunction);
                currentScope.LeaveScope();
            }
        }
        private void CreateParametersSymbols(XplParameters xplParameters, TypeInfo classType, MemberInfo memberInfo, Scope currentScope)
        {
            if (xplParameters == null) return;
            XplNodeList declList = xplParameters.Children();
            foreach (XplParameter parameter in declList)
            {
                string errorStr = "On Declaration of parameter '" + parameter.get_name() + "'.";
                //int backErrorCount = p_errorCollection.Count;
                //CheckType(parameter.get_type(), parameter, currentScope, classType.get_IsFactory() || memberInfo.IsFactory(), errorStr);
                if (parameter.get_type()!=null && parameter.get_type().get_typeStr()!=null)
                {
                    CheckForTypeConstructorCallOrSymbol(parameter.get_type() , currentScope, parameter.get_name());

                    Symbol newSymbol = new Symbol(parameter, parameter.get_name());
                    if (!currentScope.InsertSymbol(newSymbol))
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.SymbolAlreadyDefinedInCurrentScope,
                            parameter, parameter.get_name(), errorStr + " Duplicated parameter declaration."));
                    }
                    //Tengo que chequear el inicializador si existe
                    if (parameter.get_i() != null) CheckInitializer(parameter, classType, memberInfo, currentScope);
                }
            }
        }

        #region Controles Comunes para metodos, tipos y accesos
        /// <summary>
        /// Emite errores generales para el tipo "xplType" como tipo inexistente
        /// o modificadores factory incorrectos de acuerdo a la bandera pasada como
        /// argumento. Establece el "typeStr" del tipo "xplType".
        /// 
        /// Acepta "xplType" nulo en cuyo caso emite un error de tipo requerido.
        /// </summary>
        private void CheckType(XplType xplType, XplNode nodeForError, Scope currentScope, bool allowFactoryModifiers, string errorStr)
        {
            if (xplType == null)
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.TypeRequired,
                    nodeForError, errorStr));                
            }
            else
            {
                xplType.set_typeStr(
                    CalculeTypeString(xplType, errorStr, true, currentScope));
                //Chequeo si devolvio NONE y no es un constructor, una funcion
                
                if (xplType.get_typeStr() == NativeTypes.None && xplType.get_Parent()!=null)
                {
                    switch (xplType.get_Parent().get_TypeName())
                    {
                        case CodeDOMTypes.XplField:
                        case CodeDOMTypes.XplProperty:
                        case CodeDOMTypes.XplDeclarator:
                        case CodeDOMTypes.XplParameter:
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.TypeRequired, nodeForError, errorStr));
                            break;
                    }
                }
                // Chequeo que solo utilice modificadores factory si el miembro es factory
                // o el tipo es factory o interactive
                if (!allowFactoryModifiers)
                {
                    if (xplType.get_exec()) AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidExecModifierInTypesOfNonfactoryMembers, nodeForError, errorStr));
                    if (xplType.get_ftype() == XplFactorytype_enum.EXPRESSION) AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidExpModifierInTypeOfNonfactoryMembers, nodeForError, errorStr));
                    if (xplType.get_ftype() == XplFactorytype_enum.INAME) AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidInameModifierInTypeOfNonfactoryMembers, nodeForError, errorStr));
                }
            }
        }
        /// <summary>
        /// Chequea si la utilización de xplType define la utilización de un
        /// constructor de tipo. En cuyo caso carga la estructura candidata
        /// para el proceso de separación.
        /// 
        /// Asume que el xplType es correcto.
        /// No llamar con xplType null o con un xplType incorrecto.
        /// </summary>
        private void CheckForTypeConstructorCallOrSymbol(XplType xplType, Scope currentScope, string symbolName)
        {
            if (p_interactiveOnly || xplType == null) return;
            //Primero debo obtener el TypeName del xplType
            //PENDIENTE : Controlar esto que me parece esta pesimamente lento ahora!
            //
            XplType walker = xplType;

            while (walker.get_typename() == "" && walker.get_dt()!=null) walker = walker.get_dt();
            if (walker.get_dt() == null && walker.get_typename() == "") return;
            if (walker.get_typename()[0]=='$') return;
            string typenameStr = p_types.get_ExistingTypeName(GetInternalQualifiedName(walker.get_typename()), currentScope);
            if (typenameStr == null) return;
            TypeInfo ctype = (TypeInfo)p_types[typenameStr];

            AddCandidateStructureForTypeOrSymbol(symbolName, walker, ctype);
        }

        /// <summary>
        /// Register a candidate structure for a type or symbol
        /// </summary>
        /// <param name="symbolName">Name of the symbol, or null if it is a type</param>
        /// <param name="typeNode">Type node of the symbol or type node to be registered</param>
        /// <param name="classfactoryTypeInfo">TypeInfo of target classfactory</param>
        private void AddCandidateStructureForTypeOrSymbol(string symbolName, XplType typeNode, TypeInfo classfactoryTypeInfo)
        {
            if (classfactoryTypeInfo.get_IsFactory() && classfactoryTypeInfo.get_IsCompiledClassfactory())
            {
                if (classfactoryTypeInfo.get_HasDefaultTypeConstructor())
                {
                    //Agrego la estructura candidata
                    CandidateStructure cs = new CandidateStructure(TypeNameContext.LocalVarDecl, typeNode, classfactoryTypeInfo);
                    p_candidateStructures.Add(cs);
                }
                if (symbolName != null)
                {
                    //PEDIENTE : revisar cuando se implemente full todo lo relacionado
                    //a ejecucion de miembros de instancias de classfactorys.
                    CandidateStructure cs = new CandidateStructure(classfactoryTypeInfo, symbolName);
                    p_candidateStructures.Add(cs);
                }
            }
        }
        /// <summary>
        /// Check type constructor for typeNameStr and add candidate structure if applicable
        /// </summary>
        /// <param name="baseInfo">BaseInfo of inherited class or implemented interface</param>
        /// <param name="currentScope">Current scope</param>
        private void CheckForTypeConstructorCallOrSymbol(BaseInfo baseInfo, Scope currentScope)
        {
            TypeInfo ctype = baseInfo.get_BaseTypeInfo();
            XplNode node = baseInfo.get_DeclarationNode();
            
            if (ctype == null)
            {
                // this must not happend
                return;
            }
            if (ctype.get_IsFactory() && ctype.get_IsCompiledClassfactory())
            {
                if (ctype.get_HasDefaultTypeConstructor())
                {
                    //Agrego la estructura candidata
                    CandidateStructure cs = new CandidateStructure(TypeNameContext.BaseOrInterface, node, ctype);
                    p_candidateStructures.Add(cs);
                }
            }
        }

        private void CheckParameters(XplFunction xplFunction, TypeInfo classType, Scope currentScope, XplAccesstype_enum memberAccess, string errorStr)
        {
            XplParameters parameters = xplFunction.get_Parameters();
            if (parameters == null || parameters.Children().GetLength() == 0) return;
            foreach (XplParameter parameter in parameters.Children())
            {
                XplType parameterType = parameter.get_type();
                // string parameterErrorStr = " On parameter \"" + parameter.get_name() + "\" declaration.";
                // Calculo la cadena del tipo y que el tipo exista.
                CheckType(parameterType, xplFunction, currentScope, xplFunction.get_isfactory() || classType.get_IsFactory(), errorStr); // + parameterErrorStr);
                if (parameterType == null)
                {
                    parameter.set_type(new XplType());
                }
                //PENDIENTE : Chequeo que los modificadores de parametro sean correctos
                //Los modificadores son: "in", "inout", "out", "params"
            }
        }
        private void CheckCommonAccesorsControls(XplNode node, MemberInfo memberInfo, XplFunctionBody body, XplVarstorage_enum storage, bool isAbstract, string errorStr)
        {
            XplFunctionBody fb = body;
            XplNodeList getsList = null, setsList = null;
            if (fb == null)
                AddNewError(
                    SemanticError.New(SemanticErrorCode.FunctionBodyRequired, node, errorStr));
            else
            {
                foreach (XplNode n in fb.Children())
                    if (n.get_ElementName() != "Set" && n.get_ElementName() != "Get" && n.get_ElementName() != "e")
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.UnexpectedStatement,
                            n, errorStr));
                getsList = fb.get_GetNodeList();
                setsList = fb.get_SetNodeList();
                if (getsList.GetLength() == 0 && setsList.GetLength() == 0)
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.AccesorRequired, node, errorStr)
                        );
                else
                {
                    fb = (XplFunctionBody)getsList.FirstNode();

                    if (fb != null && fb.get_lddata() == "%abstract%" &&
                        !isAbstract && (storage == XplVarstorage_enum.AUTO
                        || storage == XplVarstorage_enum.STATIC))
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.FunctionBodyRequired,
                            fb, errorStr + " On Get accesor declaration."));
                    if (fb != null && fb.get_lddata() != "%abstract%" &&
                        (isAbstract || storage == XplVarstorage_enum.EXTERN
                        || storage == XplVarstorage_enum.STATIC_EXTERN))
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.UnexpectedFunctionBody,
                            fb, errorStr + " On Get accesor declaration."));
                    
                    fb = (XplFunctionBody)setsList.FirstNode();

                    if (fb != null && fb.get_lddata() == "%abstract%" &&
                        !isAbstract && (storage == XplVarstorage_enum.AUTO
                        || storage == XplVarstorage_enum.STATIC))
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.FunctionBodyRequired,
                            fb, errorStr + " On Set accesor declaration."));
                    if (fb != null && fb.get_lddata() != "%abstract%" &&
                        (isAbstract || storage == XplVarstorage_enum.EXTERN
                        || storage == XplVarstorage_enum.STATIC_EXTERN))
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.UnexpectedFunctionBody,
                            fb, errorStr + " On Set accesor declaration."));

                    if (getsList.GetLength() > 1 || setsList.GetLength() > 1)
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.DuplicatedAccesor, node, errorStr));
                }
            }
        }
        private void CheckCommonMemberModifiers(XplNode node, bool isAbstract, bool isFinal, bool isVirtual, bool isNonVirtual, bool isOverride, string errorStr, TypeInfo typeDelarator)
        {
            if (isAbstract && isFinal && !p_currentDocumentIsImport)
                AddNewError(
                    SemanticError.New(SemanticErrorCode.MemberCanNotBeAbstractAndFinal, node, errorStr));
            if (isAbstract && isNonVirtual && !p_currentDocumentIsImport)
                AddNewError(
                    SemanticError.New(SemanticErrorCode.MemberCanNotBeAbstractAndNonVirtual, node, errorStr));
            if (isVirtual && isNonVirtual && !p_currentDocumentIsImport)
                AddNewError(
                    SemanticError.New(SemanticErrorCode.MemberCanNotBeVirtualAndNonVirtual, node, errorStr));
            if (isOverride && isNonVirtual && !p_currentDocumentIsImport)
                AddNewError(
                    SemanticError.New(SemanticErrorCode.MemberCanNotBeOverrideAndNonVirtual, node, errorStr));
            if (isAbstract && !((XplClass)typeDelarator.get_TypeNode()).get_abstract())
            {
                AddNewError(SemanticError.New(SemanticErrorCode.InvalidAbstractMemberOnNonAbstractType,
                    node, typeDelarator.get_Name(), errorStr));
            }
        }
        #endregion

        private void ProcessInherits(XplInherits xplInherits, TypeInfo classType, Scope currentScope, SemanticAction semanticAction)
        {
            if (semanticAction == SemanticAction.ReadTypes)
            {
                BaseInfoCollection baseCollection = classType.get_BaseInfoCollection();
                foreach (XplInherit xplInherit in xplInherits.Children())
                {
                    BaseInfo baseInfo = new BaseInfo(classType, null, xplInherit, true);
                    baseCollection.InsertBase(baseInfo);
                    ResolveBase(baseInfo, currentScope, true);
                    if (baseInfo.get_BaseTypeInfo() == null)
                        baseInfo.set_Tag(currentScope.get_UsingDirectives());
                }
                return;
            }
            else if (semanticAction == SemanticAction.CheckImplementation)
            {
            }
            else if (semanticAction == SemanticAction.CheckTypes)
            {
            }
        }

        private void ProcessSetPlatforms(XplSetPlatforms xplSetPlatforms, Scope currentScope, SemanticAction semanticAction)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void ProcessAutoInstance(XplAutoInstance xplAutoInstance, Scope currentScope, SemanticAction semanticAction)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void ProcessUsing(XplName node, Scope scope, SemanticAction semanticAction)
        {
            if (semanticAction != SemanticAction.ReadTypes)
            {
                string usingName;
                if (node.Children().GetLength() > 0) usingName = GetInternalQualifiedName(node.Children().FirstNode().get_StringValue());
                else usingName = "";
                TypeInfo ns = p_types.get_TypeInfo(usingName);
                if (ns != null )
                {
                    //OK, existe y es un espacio de nombres
                    scope.AddUsingDirective(usingName);
                }
                else
                {
                    if (node.get_lddata() != "ZOEC:BAD")
                    {
                        //PENDIENTE : Un using incorrecto deberia ser solo
                        //un warning? por el tema de cuando directivas import
                        //no son procesadas...
                        XplNode sourceDoc = node;
                        while (sourceDoc!=null && sourceDoc.get_TypeName() != CodeDOMTypes.XplDocument) sourceDoc = sourceDoc.get_Parent();
                        if (p_classfactorysDocument!=sourceDoc)
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.InvalidNamespaceinUsingDirective,
                                node, usingName));
                            node.set_lddata("ZOEC:BAD");
                        }
                    }
                }
            }
        }
        private void ProcessUsingIdentifiers(XplNode node, Scope scope, SemanticAction semanticAction)
        {
            //PENDIENTE :Implementar los Espacios de Nombres de Identificadores.
            return;
        }
        #endregion

        /// <summary>
        /// Crea una cadena de tipos de puntero a miembro con firma "memberInfo".
        /// 
        /// "instance" indica si es un puntero a un miembro de instancia, de lo contrario se asume un
        /// valor puntero a miembro estatico.
        /// 
        /// No llamar con memberInfo en nulo!
        /// </summary>
        private static string MakePointerTypeToMember(MemberInfo memberInfo, bool instance)
        {
            //La cadena de identificacion de puntero a funcion es como sigue:
            //*_NombreClaseCompleto/NombreMiembroInterno
            //
            //Es decir utilizo el "/" para indicar q nos referimos a un miembro.
            //Luego debo definir las conversiones.
            //
            return TypeString.MakePointerTypeTo(memberInfo.get_ClassTypeFullName() + "/" + memberInfo.get_MemberInternalName());
        }

        #region Calculo y Control de Herencia e Implementación de Interfaces
        private void CheckBasesAndInterfaces(TypeInfo classType, Scope currentScope)
        {
            /* Para la herencia:
             * - inicio con cada clase base directa agregando los miembros.
             * - chequeando con los miembros actuales por ocultación y alli controlo el new.
             * - hago el proceso recursivo para las bases indirectas agregando sólo los miembros directos.
             * 
             * Para las interfaces:
             * - chequeo cada miembro, primero debo poblar la herencia de la interfaz, uso el 
             * algoritmo para el mapeo de interfaces establecido.
             * 
             */
            BaseInfoCollection baseCollection = classType.get_BaseInfoCollection();
            if (baseCollection.BaseClassesCount() == 0)
                //Aqui chequeo si debo agregar la herencia de Object,
                //o clases bases para classfactorys
                AddStandardBaseClass(classType, baseCollection);


            foreach (BaseInfo baseInfo in baseCollection.get_BaseInfoList())
            {
                //Primero obtengo el tipo base si aún no fue encontrado
                ResolveBase(baseInfo, currentScope,false);
                //Si el tipo base si existia agrego sus miembros
                if (baseInfo.get_BaseTypeInfo() != null)
                {
                    AddInheritedMembers(classType, baseInfo, currentScope);
                }
                else
                {
                    //El tipo base no pudo ser resuelto debo emitir un error.
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.DeclaredTypeDoesnotExist, baseInfo.get_DeclarationNode(),
                        baseInfo.get_BaseName(), "In base declaration of \"" + classType.get_FullName() + "\" type.")
                    );
                }
            }
            // Cuando salgo de aquí seteo la bandera de herencia calculada
            classType.set_InheritanceCalculated(true);
            
            // Controlo la implementación de interfaces
            foreach (BaseInfo baseInfo in baseCollection.get_BaseInfoList())
            {
                if (!baseInfo.get_IsBadBase() && baseInfo.get_BaseTypeInfo().get_IsInterface())
                {
                    //Es una interfaz debo chequear si se implementan todos los miembros
                    CheckInterfaceImplementation(classType, baseInfo.get_BaseTypeInfo(), currentScope, baseInfo.get_DeclarationNode());
                }
            }
        }
        /// <summary>
        /// Check that classType implement interfaceType.
        /// </summary>
        /// <param name="classType">The type that must implement interfaceType.</param>
        /// <param name="typeInfo">The type of the interface.</param>
        /// <param name="currentScope">Current scope.</param>
        private void CheckInterfaceImplementation(TypeInfo classType, TypeInfo interfaceType, Scope currentScope, XplNode errorNode)
        {
            // I must iterate on each member of the interface type and check it on the class type
            ICollection interfaceMembers = interfaceType.get_MemberInfoCollection().get_MemberInfoList();
            MemberInfoCollection classMembers = classType.get_MemberInfoCollection();
            foreach (MemberInfo interfaceMember in interfaceMembers)
            {
                if (!interfaceMember.get_IsExternal() && !interfaceMember.IsStatic() && !interfaceMember.get_IsBadMember() && interfaceMember.get_DeclarationClassType().get_IsInterface())
                {
                    if (interfaceMember.IsMethod())
                    {
                        CheckMethodImplementation(interfaceType, interfaceMember, classMembers, currentScope, errorNode);
                    }
                    else if (interfaceMember.IsIndexer())
                    {
                        CheckMethodImplementation(interfaceType, interfaceMember, classMembers, currentScope, errorNode);
                    }
                    else if (interfaceMember.IsProperty())
                    {
                        CheckPropertyImplementation(interfaceType, interfaceMember, classMembers, currentScope, errorNode);
                    }
                    else
                    {
                        // Error, a interface member must be a Method, Indexer or Property
                        // this error must be detected while reading the interface
                    }
                }
            }
        }

        private void CheckPropertyImplementation(TypeInfo interfaceType, MemberInfo interfaceMember, MemberInfoCollection classMembers, Scope currentScope, XplNode errorNode)
        {
            bool addError = false;
            string searchName = interfaceType.get_Name() + "." + interfaceMember.get_MemberName();
            MemberInfo[] candidateMembers = classMembers.get_MembersInfo(searchName);
            if (candidateMembers == null)
            {
                searchName = interfaceMember.get_MemberName();
                candidateMembers = classMembers.get_MembersInfo(searchName);
            }
            if (candidateMembers == null)
            {
                addError = true;
            }
            else
            {
                addError = true;
                foreach (MemberInfo candidateMember in candidateMembers)
                {
                    // PENDIENTE : check for get; and set; accessors between interface member and class member
                    if (IsSameType(candidateMember.get_ReturnType(), interfaceMember.get_ReturnType(), currentScope) &&
                        !candidateMember.IsStatic() &&
                        candidateMember.get_Access() == XplAccesstype_enum.PUBLIC)
                    {
                        addError = false;
                        break;
                    }
                }
            }
            if (addError)
            {
                AddNewError(SemanticError.New(SemanticErrorCode.InterfaceMemberNotImplemented,
                    errorNode, interfaceMember.ToString(), interfaceType.get_Name()));
            }
        }

        private void CheckMethodImplementation(TypeInfo interfaceType, MemberInfo interfaceMember, MemberInfoCollection classMembers, Scope currentScope, XplNode errorNode)
        {
            // First search for explicit implementation I::M;
            bool addError = false;
            string searchName = interfaceType.get_Name() + "." + interfaceMember.get_MemberName();
            MemberInfo[] candidateMembers = classMembers.get_MembersInfo(searchName);
            if (candidateMembers == null)
            {
                searchName = interfaceMember.get_MemberName();
                candidateMembers = classMembers.get_MembersInfo(searchName);
            }
            if (candidateMembers == null)
            {
                addError = true;
            }
            else
            {
                addError = true;
                foreach (MemberInfo candidateMember in candidateMembers)
                {
                    if (IsSameSignature(candidateMember, interfaceMember, currentScope) &&
                        IsSameType(candidateMember.get_ReturnType(), interfaceMember.get_ReturnType(), currentScope) &&
                        !candidateMember.IsStatic() &&
                        candidateMember.get_Access()==XplAccesstype_enum.PUBLIC)
                    {
                        addError = false;
                        break;
                    }
                    
                }
            }
            if (addError)
            {
                AddNewError(SemanticError.New(SemanticErrorCode.InterfaceMemberNotImplemented,
                    errorNode, interfaceMember.ToString(), interfaceType.get_Name()));
            }
        }
        /// <summary>
        /// Agrega la clase base comun a clases, estructuras, classfactorys, etc.
        /// 
        /// Debe llamarse con un XplClass en classType, de lo contrario se producira
        /// un error
        /// </summary>
        private void AddStandardBaseClass(TypeInfo classType, BaseInfoCollection baseCollection)
        {
            if (classType.get_IsEnum())
            {
                // PENDIENTE : controlar esto fue copypasteado a las apuradas!!
                //Clase base para enumeraciones
                #region Base Enumeraciones
                //Las interfaces tambien deben tener como base a object cuando esta activada
                //la base universal

                //Clase base para interfaces
                BaseInfo baseInfo = null;
                XplInherit inhNode = XplInherits.new_c();
                inhNode.set_type(new XplType());
                inhNode.set_access(XplAccesstype_enum.PUBLIC);

                if (p_programRequirements.get_UseUniversalObjectBase())
                {
                    if (p_programRequirements.get_SetUniversalObjectBase() == "")
                    {
                        if (classType.get_FullName() == OBJECT_CLASS_FULL_PATH) return;
                        //Clase base universal comun OBJECT_CLASS_FULL_PATH
                        inhNode.get_type().set_typename(OBJECT_CLASS_FULL_PATH2);
                    }
                    else
                    {
                        if (classType.get_FullName() == GetInternalQualifiedName(p_programRequirements.get_SetUniversalObjectBase())) return;
                        //Clase universal base propia
                        inhNode.get_type().set_typename(p_programRequirements.get_SetUniversalObjectBase());
                    }
                }

                XplInherits inhNodes = XplClass.new_Inherits();
                inhNodes.Children().InsertAtEnd(inhNode);
                ((XplClass)classType.get_TypeNode()).Children().InsertAtEnd(inhNodes);

                baseInfo = new BaseInfo(classType, (TypeInfo)p_types[GetInternalQualifiedName(inhNode.get_type().get_typename())], inhNode, true);
                baseCollection.InsertBase(baseInfo);

                #endregion
            }
            else if (classType.get_IsInterface())
            {
                #region Base Interfaces
                //Las interfaces tambien deben tener como base a object cuando esta activada
                //la base universal

                //Clase base para interfaces
                BaseInfo baseInfo = null;
                XplInherit inhNode = XplInherits.new_c();
                inhNode.set_type(new XplType());
                inhNode.set_access(XplAccesstype_enum.PUBLIC);

                if (p_programRequirements.get_UseUniversalObjectBase())
                {
                    if (p_programRequirements.get_SetUniversalObjectBase() == "")
                    {
                        if (classType.get_FullName() == OBJECT_CLASS_FULL_PATH) return;
                        //Clase base universal comun OBJECT_CLASS_FULL_PATH
                        inhNode.get_type().set_typename(OBJECT_CLASS_FULL_PATH2);
                    }
                    else
                    {
                        if (classType.get_FullName() == GetInternalQualifiedName(p_programRequirements.get_SetUniversalObjectBase())) return;
                        //Clase universal base propia
                        inhNode.get_type().set_typename(p_programRequirements.get_SetUniversalObjectBase());
                    }
                }

                XplInherits inhNodes = XplClass.new_Inherits();
                inhNodes.Children().InsertAtEnd(inhNode);
                ((XplClass)classType.get_TypeNode()).Children().InsertAtEnd(inhNodes);

                baseInfo = new BaseInfo(classType, (TypeInfo)p_types[GetInternalQualifiedName(inhNode.get_type().get_typename())], inhNode, true);
                baseCollection.InsertBase(baseInfo);

                #endregion
            }
            else if (classType.get_IsStruct())
            {
                // PENDIENTE : controlar esto fue copypasteado a las apuradas!!
                //Clase base para estructuras
                #region Base Estructuras
                //Clase base para interfaces
                BaseInfo baseInfo = null;
                XplInherit inhNode = XplInherits.new_c();
                inhNode.set_type(new XplType());
                inhNode.set_access(XplAccesstype_enum.PUBLIC);

                if (p_programRequirements.get_UseUniversalObjectBase())
                {
                    if (p_programRequirements.get_SetUniversalObjectBase() == "")
                    {
                        if (classType.get_FullName() == OBJECT_CLASS_FULL_PATH) return;
                        //Clase base universal comun OBJECT_CLASS_FULL_PATH
                        inhNode.get_type().set_typename(OBJECT_CLASS_FULL_PATH2);
                    }
                    else
                    {
                        if (classType.get_FullName() == GetInternalQualifiedName(p_programRequirements.get_SetUniversalObjectBase())) return;
                        //Clase universal base propia
                        inhNode.get_type().set_typename(p_programRequirements.get_SetUniversalObjectBase());
                    }
                }

                XplInherits inhNodes = XplClass.new_Inherits();
                inhNodes.Children().InsertAtEnd(inhNode);
                ((XplClass)classType.get_TypeNode()).Children().InsertAtEnd(inhNodes);

                baseInfo = new BaseInfo(classType, (TypeInfo)p_types[GetInternalQualifiedName(inhNode.get_type().get_typename())], inhNode, true);
                baseCollection.InsertBase(baseInfo);

                #endregion
            }
            else
            {
                BaseInfo baseInfo = null;
                XplInherit inhNode = XplInherits.new_c();
                inhNode.set_type(new XplType());
                inhNode.set_access(XplAccesstype_enum.PUBLIC);
                if (classType.get_IsInteractive())
                {
                    if (classType.get_FullName() == CLASSFACTORYINTERACTIVEBASE) return;
                    inhNode.get_type().set_typename(CLASSFACTORYINTERACTIVEBASE);
                }
                else if (classType.get_IsFactory())
                {
                    if (classType.get_FullName() == CLASSFACTORYBASE) return;
                    inhNode.get_type().set_typename(CLASSFACTORYBASE);
                }
                else
                    if (p_programRequirements.get_UseUniversalObjectBase())
                    {
                        if (p_programRequirements.get_SetUniversalObjectBase() == "")
                        {
                            if (classType.get_FullName() == OBJECT_CLASS_FULL_PATH) return;
                            //Clase base universal comun OBJECT_CLASS_FULL_PATH
                            inhNode.get_type().set_typename(OBJECT_CLASS_FULL_PATH2);
                        }
                        else
                        {
                            if (classType.get_FullName() == GetInternalQualifiedName(p_programRequirements.get_SetUniversalObjectBase())) return;
                            //Clase universal base propia
                            inhNode.get_type().set_typename(p_programRequirements.get_SetUniversalObjectBase());
                        }
                    }
                XplInherits inhNodes = XplClass.new_Inherits();
                inhNodes.Children().InsertAtEnd(inhNode);
                ((XplClass)classType.get_TypeNode()).Children().InsertAtEnd(inhNodes);

                baseInfo = new BaseInfo(classType, (TypeInfo)p_types[GetInternalQualifiedName(inhNode.get_type().get_typename())], inhNode, true);
                baseCollection.InsertBase(baseInfo);
            }
        }
        /// <summary>
        /// Busca el TypeInfo para la clase base marcada en baseInfo,
        /// si el tipo ya existe asignado simplemente vuelve, de lo 
        /// contrario intenta resolver el tipo NO EMITE ERROR cuando no lo encuentra.
        /// 
        /// EMITE ERRORES DE BASES INCORRECTAS, como Interfaces con Clases bases.
        /// </summary>
        private void ResolveBase(BaseInfo baseInfo, Scope searchScope, bool firstCheck)
        {
            if (baseInfo.get_BaseTypeInfo() == null)
            {
                string baseTypeName = GetInternalQualifiedName(baseInfo.get_BaseName());
                string typeName = p_types.get_ExistingTypeName(baseTypeName, searchScope);
                if (typeName == null && !firstCheck)
                {
                    // Utilizo el ArrayList almacenado en el TAG del base info para
                    // buscar el tipo en dichos espacios de nombres.
                    if(baseInfo.get_Tag()!=null)
                        foreach (string usingStr in (ArrayList)baseInfo.get_Tag())
                        {
                            typeName = Scope.MakeFullTypeName(usingStr, baseTypeName);
                            typeName = p_types.get_ExistingTypeName(typeName);
                            if (typeName != null) break;
                        }
                }
                // El tipo declarado como base no existe definitivamente
                if (typeName == null)
                {
                    // Marco como Malo el baseInfo de la coleccion de bases por confirmarse la no existencia
                    // del tipo declarado.
                    // if(!firstCheck)baseInfo.get_DeclaratorTypeInfo().get_BaseInfoCollection().RemoveBase(baseInfo);
                    if (!firstCheck) baseInfo.set_IsBadBase(true);
                }
                else
                {
                    // El tipo existe por lo que lo puedo setear en el BaseInfo
                    TypeInfo baseType = p_types.get_TypeInfo(typeName);
                    baseInfo.set_BaseTypeInfo(baseType);
                    // Y puedo borrar el TAG para liberar el ArrayList de Usings
                    baseInfo.set_Tag(null);
                    // Ahora realizo los controles de herencia permitida o no
                    int backErrorsCount = p_errorCollection.Count;

                    #region Control de Errores entre relacion de tipos Tipo Base -> Tipo Derivado
                    TypeInfo derivedType = baseInfo.get_DeclaratorTypeInfo();
                    XplClass baseTypeNode = (XplClass)baseType.get_TypeNode();
                    XplClass derivedTypeNode = (XplClass)derivedType.get_TypeNode();                    

                    if (derivedType.get_IsEnum() && !CheckValidBaseTypeForEnum(baseInfo))
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.EnumCanNotHaveBaseTypes, baseInfo.get_DeclarationNode(),
                            derivedType.get_FullName())
                        );
                    if (derivedType.get_IsStruct() && !CheckValidBaseTypeForStruct(baseInfo) &&
                        baseInfo.get_IsInherit() && !p_programRequirements.get_UseInheritsAsImplements())
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.InvalidStructureBaseType, baseInfo.get_DeclarationNode(),
                            typeName)
                        );
                    if (baseType.get_IsNamespace() || baseType.get_IsStruct() || baseType.get_IsFPType() || baseType.get_IsEnum())
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.InvalidTypeForBaseClass, baseInfo.get_DeclarationNode(),
                            typeName)
                        );
                    if (baseTypeNode.get_final() && baseInfo.get_IsInherit() && !baseTypeNode.get_abstract())
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.InvalidInheritanceFromFinalClass, baseInfo.get_DeclarationNode(),
                            typeName)
                        );
                    if (baseType.get_IsInterface()) ///Es una interfaz
                    { 
                        //Si el tipo derivado es una Interfaz
                        if (derivedType.get_IsInterface())
                            if (baseInfo.get_IsInherit())
                                if (baseTypeNode.get_isfactory() && !derivedTypeNode.get_isfactory())
                                    AddNewError(
                                        SemanticError.New(SemanticErrorCode.InvalidFactoryInterfaceImplementer, baseInfo.get_DeclarationNode(),
                                        typeName, derivedType.get_FullName())
                                    );
                        else 
                            //El tipo derivado no es una interfaz
                            if(baseInfo.get_IsInherit() && !p_programRequirements.get_UseInheritsAsImplements()
                                && !baseInfo.get_DeclaratorTypeInfo().get_IsInterface())
                                AddNewError(
                                    SemanticError.New(SemanticErrorCode.InvalidTypeForBaseClass, baseInfo.get_DeclarationNode(),
                                    typeName)
                                );
                    }
                    else
                    { 
                        //Es una clase, o estructura la clase base!
                        if (derivedType.get_BaseInfoCollection().Contains(typeName, baseInfo))
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.DuplicatedBaseType, baseInfo.get_DeclarationNode(),
                                typeName, derivedType.get_FullName())
                            );
                        }
                        else
                        {
                            if (!p_isExtensionModule && !baseTypeNode.get_isfactory() && derivedTypeNode.get_isfactory())
                            {
                                if (!CheckValidBaseForClassfactory(baseTypeNode))
                                    AddNewError(
                                        SemanticError.New(SemanticErrorCode.InvalidBaseClassForClassfactory, baseInfo.get_DeclarationNode(),
                                        typeName, derivedType.get_FullName())
                                    );
                            }
                            if (!derivedTypeNode.get_isinteractive() && baseTypeNode.get_isinteractive())
                                AddNewError(
                                    SemanticError.New(SemanticErrorCode.ClassfactoryCanNotInheritFromInteractive, baseInfo.get_DeclarationNode(),
                                    derivedType.get_FullName(), typeName)
                                );

                            //if (!derivedTypeNode.get_isfactory() && baseTypeNode.get_isfactory())
                            //    AddNewError(
                            //        SemanticError.New(SemanticErrorCode.InvalidClassfactoryAsBaseClass, baseInfo.get_DeclarationNode(),
                            //        typeName, derivedType.get_FullName())
                            //    );
                        }
                    }
                    #endregion

                    if (backErrorsCount < p_errorCollection.Count)
                    {
                        //Si hay errores en la relacion entre clase base y tipo derivado marco como erroneo el baseInfo
                        baseInfo.set_IsBadBase(true);
                        //baseInfo.get_DeclaratorTypeInfo().get_BaseInfoCollection().RemoveBase(baseInfo);
                    }
                    else
                    {
                        //Establezco el nombre completo de la base para q 
                        //la generacion de codigo no dependa de los using existentes.
                        baseInfo.get_DeclarationNode().get_type().set_typename(baseType.get_FullName());
                    }
                }
            }
        }
        /// <summary>
        /// Controla si la clase es valida para base de una Classfactory, solo
        /// son validas las bases definidas por el lenguaje Zoe y ninugna otra.
        /// </summary>
        private static bool CheckValidBaseForClassfactory(XplClass baseTypeNode)
        {
            //PENDIENTE : Controlar esto!!, uno podria engañarlo
            //haciendo clases con el mismo nombre en otro espacio de nombres
            //diferente a "zoe::lang".
            if ((baseTypeNode.get_name() == "ClassfactoryBase" ||
                baseTypeNode.get_name() == "ClassfactoryInteractiveBase")) return true;
            return false;
        }
        /// <summary>
        /// Controla si "baseInfo" es una clase base valida para una estructura.
        /// 
        /// Las clases bases para estructuras las determinan los Modulos de Salida.
        /// </summary>
        private static bool CheckValidBaseTypeForStruct(BaseInfo baseInfo)
        {            
            //PENDIENTE : implementar correctamente control de bases para estructuras.
            return true;
        }
        /// <summary>
        /// Controla si "baseInfo" es una clase base valida para una enumeración.
        /// 
        /// Las clases bases para enumeraciones las determinan los Modulos de Salida.
        /// </summary>
        private static bool CheckValidBaseTypeForEnum(BaseInfo baseInfo)
        {
            //PENDIENTE : implementar correctamente control de bases para enumeraciones.
            return true;
        }
        /// <summary>
        /// Agrega a "classType" los miembros heredados de "baseInfo", chequea
        /// por la ocultación en "classType" y emite las advertencias si el miembro
        /// no fue declarado como "new".
        /// 
        /// Procesa todas las sub-bases de baseInfo si aun no fue procesado previamente.
        /// </summary>
        private void AddInheritedMembers(TypeInfo classType, BaseInfo baseInfo, Scope currentScope)
        {
            //Si el BaseInfo es nulo, no se habra encontrado la clase base, vuelvo
            if (baseInfo == null) return;
            //Si el BaseInfo es erroneo lo ignoro
            if (baseInfo.get_IsBadBase()) return;

            TypeInfo baseType = baseInfo.get_BaseTypeInfo();
            //Si baseType==classType hay circularidad en herencia
            if (baseType == classType)
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.InheritanceCircularity, baseInfo.get_DeclarationNode(),
                    classType.get_FullName(), baseInfo.get_DeclaratorTypeInfo().get_FullName())
                );
                //Si hay errores en la relacion entre clase base y tipo derivado marco el baseInfo como erroneo
                baseInfo.set_IsBadBase(true);
                return;
            }
            //Si es una interfaz simplemente retorno y lo ignoro
            //siempre que el classType tampoco sea una interfaz.
            if (baseType.get_IsInterface() && !classType.get_IsInterface()) return;
            bool inhCalc = baseType.get_InheritanceCalculated();
            MemberInfoCollection baseMembers = baseType.get_MemberInfoCollection();
            foreach (MemberInfo baseMember in baseMembers.get_MemberInfoList())
            {
                //Si es un miembro directo lo agrego
                if (inhCalc || baseMember.get_DeclarationClassType() == baseType)
                {
                    AddInheritedMember(classType, baseType, baseMember, classType.get_MemberInfoCollection(), baseInfo.get_Access(), currentScope);
                }
            }
            //Calculo la recursión de las sub-bases
            if (!inhCalc)
            {
                BaseInfoCollection baseCollection = baseType.get_BaseInfoCollection();
                if (baseCollection != null)
                    foreach (BaseInfo baseInf in baseCollection.get_BaseInfoList())
                    {
                        //Utilizo un Scope vacio, si todavia no se encontro el tipo 
                        //de la base es lo mismo!
                        ResolveBase(baseInf, new Scope(p_types), false);
                        AddInheritedMembers(classType, baseInf, currentScope);
                    }
            }
        }
        /// <summary>
        /// Acceder con "accessMatrix[ACCESO_HERENCIA, ACCESO_MIEMBRO]" determina
        /// acceso para miembro heredado.
        /// 
        /// Se asume que:
        /// PUBLIC = 0; PROTECTED = 1; PRIVATE = 2; IPUBLIC = 3; IPROTECTED = 4; IPRIVATE = 5;
        /// </summary>
        private XplAccesstype_enum[,] p_accessMatrix =
            { 
                {XplAccesstype_enum.PUBLIC, XplAccesstype_enum.PROTECTED, XplAccesstype_enum.PRIVATE, 
                 XplAccesstype_enum.IPUBLIC, XplAccesstype_enum.IPROTECTED, XplAccesstype_enum.IPRIVATE},                
                {XplAccesstype_enum.PROTECTED, XplAccesstype_enum.PROTECTED, XplAccesstype_enum.PRIVATE, 
                 XplAccesstype_enum.IPROTECTED, XplAccesstype_enum.IPROTECTED, XplAccesstype_enum.IPRIVATE},
                {XplAccesstype_enum.PRIVATE, XplAccesstype_enum.PRIVATE, XplAccesstype_enum.PRIVATE, 
                 XplAccesstype_enum.IPRIVATE, XplAccesstype_enum.IPRIVATE, XplAccesstype_enum.IPRIVATE},
            };
        private void AddInheritedMember(TypeInfo classType, TypeInfo baseType, MemberInfo baseMember, MemberInfoCollection classMembers, XplAccesstype_enum baseAccess, Scope currentScope)
        {
            //El proceso para agregar un miembro heredado debe ser:
            //- Si es una Expresion, un Permiso de Classfactory, Destructor o Finalizador o un Constructor no se hereda.
            //- Si es estático, si se hereda menos el constructor estático.
            //- De lo contrario si se hereda.
            //- Para chequear si el miembro heredado es ocultado por un miembro de la clase
            //se procede como sigue:
            //     - Se verifica que existan miembro originales de la clase con el mismo nombre que el miembro heredado.
            //     - Si el miembro heredado es un campo es ocultado.
            //     - Si el miembro heredado es un método y existe un método con la misma firma es ocultado.
            //     - Si el miembro heredado es una propiedad es ocultado.
            //     - Si el miembro heredado es un indexador y la firma conincide con un indexador en la clase es ocultado.
            //     - Si el miembro heredado es un operador nunca es ocultado ya que la firma de un operador valido nunca puede coincidir.
            //- Para determinar los miembros que requieren aplicar "new" en la clase:
            //     - Se obtiene el listado con los miembros de la clase cuyo nombre coincide.
            //     - Si el miembro heredado no era un metodo se requiere que todos los miembros 
            //     de la clase en la lista anterior usen new.
            //     - Si el miembro heredado es un metodo o un indexador se requiere que solo
            //     los miembros de la clase que ocultan el miembro heredado usen new pero no el resto.
            //     
            //PENDIENTE : Que los controles de New, Override, Virtual, Nonvirtual, Abstract funcionen bien.
            
            //Primero chequeo que el miembro pueda heredarse y no posea errores
            if (baseMember.IsExpression() ||
                baseMember.IsBeginCFPermissions() ||
                baseMember.IsEndCFPermissions()) return;
            if (baseMember.IsConstructor() || baseMember.IsDestructor() || baseMember.IsFinalizer()) return;
            bool isHiddenMember = false;
            int n = 0;
            string baseMemberName = baseMember.get_MemberName();
            MemberInfo[] newMembers = null;
            newMembers = classMembers.get_MembersInfo(baseMemberName);
            //Si el miembro que estoy heredando ya esta marcado como oculto no debo chequear por ocultación
            //O si el miembro que estoy heredando es override tampoco debo chequear
            if (baseMember.get_Hidden())
            {
                isHiddenMember = true;
            }
            else
            {
                //PENDIENTE : Revisar si utilizo "ExistAnyMemberInfoName" o
                //"ExistMemberInfoName" para controlar la ocultación de miembros,
                //el primero me busca en todos los miembros heredados o no,
                //el segundo me busca solo en los miembros declarados en la clase
                //actual.
                //para campos y propiedades es facil!
                if (baseMember.IsField() || baseMember.IsProperty())
                {
                    //Si el campo es estatico ó estatico externo no se hereda
                    if (!isHiddenMember && classMembers.ExistAnyMemberInfoName(baseMemberName))
                        isHiddenMember = true;
                }
                //para metodos e indexadores
                else if (baseMember.IsMethod() || baseMember.IsIndexer() || baseMember.IsOperator())
                {
                    //Si el metodo es un constructor tampoco se hereda
                    if (baseMember.get_MemberName() == baseType.get_Name())
                        return;
                    if (!isHiddenMember && classMembers.ExistAnyMemberInfoName(baseMemberName))
                    {
                        n = 0;
                        foreach (MemberInfo member in newMembers)
                        {
                            if (!(member.IsMethod() || member.IsIndexer()))
                            {
                                isHiddenMember = true;
                            }
                            else
                            { //Es un metodo tengo que chequear la firma
                                if (!isHiddenMember && IsSameSignature(member, baseMember, currentScope))
                                    isHiddenMember = true;
                                else
                                    newMembers[n] = null;
                            }
                            n++;
                        }
                    }
                }
            }
            //Chequeo que utilicen "new" los miembros oculto

            /* NO CHEQUEO NADA HASTA REVISAR COMPLETAMENTE EL ALGORITMO ESTE QUE NO FUNCA!!!
            if (isHiddenMember)
                foreach(MemberInfo newMember in newMembers)
                    //Solo chequeo por "new" en los miembros de la clase superior
                    if (newMember!=null && !newMember.IsNew() && !newMember.IsOverride() && newMember.get_DeclarationClassType()==classType)
                    {
                        AddNewError(
                            SemanticWarning.New(SemanticWarningCode.NewModifierRequiredOnMemberDeclaration,
                            newMember.get_MemberNode(), newMember.ToString(), baseMember.ToString())
                        );
                    }
             */
            //Si paso los controles agrego el miembro heredado
            MemberInfo inheritedMember = new MemberInfo(classType, baseMember.get_DeclarationClassType(), baseMember.get_MemberNode());
            //Establezco el nivel de acceso
            inheritedMember.set_Access(p_accessMatrix[((int)baseAccess)-1, ((int)baseMember.get_Access())-1]);
            //Seteo si es un miembro oculto
            inheritedMember.set_Hidden(isHiddenMember);

            //Si es un campo establezco virtual cuando la herencia es virtual
            if (baseMember.IsField() && baseMember.get_Virtual()) inheritedMember.set_Virtual(true);
            classMembers.InsertMemberInfo(inheritedMember);
        }
        #endregion

        #region IsSameSignature, IsSameType, CalculeTypeString
        /// <summary>
        /// Indica si "member" y "otherMember" poseen la misma firma.
        /// Se aplica a metodos, indexadores, constructores y operadores
        /// chequeandose la lista de parametros.
        /// 
        /// Sólo chequea la igualdad de tipos con "IsSameType", no importan los
        /// modificadores de declaracion del parametro.
        /// </summary>
        /// <returns>'true' si tienen la misma firma 'false' de lo contrario incluyendo cuando hay un miembro de tipo no valido como un campo.</returns>
        private bool IsSameSignature(MemberInfo member, MemberInfo otherMember, Scope currentScope)
        {
            if (member.get_MemberNode().get_TypeName() == CodeDOMTypes.XplFunction && otherMember.get_MemberNode().get_TypeName() == CodeDOMTypes.XplFunction)
            {
                XplParameters memberParams = ((XplFunction)member.get_MemberNode()).get_Parameters();
                XplParameters otherMemberParams = ((XplFunction)otherMember.get_MemberNode()).get_Parameters();
                //Por ahora permito parametros nulos, lo que indica que no declara parametros
                if (memberParams == null || otherMemberParams == null)
                {
                    if (memberParams != null && memberParams.Children().GetLength() > 0) return false;
                    if (otherMemberParams != null && otherMemberParams.Children().GetLength() > 0) return false;
                    return true;
                }
                //Debug.Assert(memberParams != null && otherMemberParams != null, "ERROR: info de parametros nulos al chequear firma de metodos.");
                if (memberParams.Children().GetLength() != otherMemberParams.Children().GetLength()) return false;
                else
                { 
                    //Tiene la misma cantidad de parametros, puede tener la misma firma.
                    XplNodeList memberParamsList = memberParams.Children();
                    XplNodeList otherMemberParamsList = otherMemberParams.Children();
                    XplParameter memberParam = null, otherMemberParam = null;
                    for (int n = 0; n < memberParamsList.GetLength(); n++)
                    {                        
                        memberParam = (XplParameter)memberParamsList.GetNodeAt(n);
                        otherMemberParam = (XplParameter)otherMemberParamsList.GetNodeAt(n);
                        if (!IsSameType(memberParam.get_type(), otherMemberParam.get_type(), currentScope) 
                            || memberParam.get_direction()!=otherMemberParam.get_direction()) return false;
                    }
                    //Todos los parametros son del mismo tipo y en el mismo orden.
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Indica si los tipos "xplType" y "otherXplType" son identicos
        /// incluyendo los modificadores de tipos derivados, es decir los
        /// modificadores de puntero y matriz.
        /// 
        /// Se considera tambien los modificadores "const" y "volatile" de los
        /// punteros pero no el modificador "ref" de puntero.
        /// 
        /// Se asume que los tipos deben ser correctos y validos. Por ejemplo,
        /// si el tipo es un puntero a matriz y define una dimensión constante,
        /// que es un tipo no valido, el resultado es indeterminado.
        /// </summary>
        /// <returns>'true' si los tipos son identicos, 'false' de lo contrario.</returns>
        private bool IsSameType(XplType xplType, XplType otherXplType, Scope currentScope)
        {
            if (xplType.get_typeStr() == String.Empty) CalculeTypeString(xplType, currentScope);
            if (otherXplType.get_typeStr() == String.Empty) CalculeTypeString(otherXplType, currentScope);
            return IsSameStringType(xplType.get_typeStr(), otherXplType.get_typeStr());
        }
        /// <summary>
        /// Indica si dos cadenas de descripcion de tipos son iguales, considerando
        /// referencias y punteros como tipos identicos.
        /// 
        /// No llamar con cadenas en null!!.
        /// Acepta cadenas vacias.
        /// </summary>
        private bool IsSameStringType(string typeString, string otherTypeString)
        {
            //Primero intento lo facil
            if (typeString == otherTypeString) return true;
            if (typeString.Length == 0 || otherTypeString.Length == 0) return false;
            if (typeString.Length != otherTypeString.Length) return false;
            //Luego lo dificil
            if (typeString[0] == '*' || typeString[0] == '^')
            {
                if (otherTypeString[0] == '*' || otherTypeString[0] == '^')
                {
                    if (typeString[1] == otherTypeString[1])
                    {
                        if (typeString[2] == ':')
                        {
                            if (otherTypeString[2] == ':')
                            {
                                int endIndex = typeString.IndexOf(':', 3);
                                if (otherTypeString.IndexOf(':', 3)!= endIndex) return false;
                                string className = typeString.Substring(3, endIndex - 3);
                                string otherClassName = typeString.Substring(3, endIndex - 3);
                                if (className != otherClassName) return false;
                                return IsSameStringType(typeString.Substring(endIndex + 1), otherTypeString.Substring(endIndex + 1));
                            }
                            else return false;
                        }
                        else
                        {
                            if (otherTypeString[2] == ':') return false;
                            else return IsSameStringType(typeString.Substring(2), otherTypeString.Substring(2));
                        }
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Establece el "typeStr" del tipo "xplType" asumiendo que es un tipo valido.
        /// 
        /// Devuelve "false" si no se encontro error en la definicion del tipo.
        /// Devuelve "true" si se encontro error en la definicion del tipo.
        /// </summary>
        private bool CalculeTypeString(XplType xplType, Scope currentScope)
        {
            int errorCount = p_errorCollection.Count;
            xplType.set_typeStr(CalculeTypeString(xplType, String.Empty, true, currentScope));
            return errorCount == p_errorCollection.Count;
        }


        /// <summary>
        /// Calcula el la cadena del tipo "xplType".
        /// </summary>
        /// <param name="xplType">El tipo al cual se le calculara la cadena.</param>
        /// <param name="extraErrorInfo">La cadena de error a anexar al encontrar un error en la declaracion del tipo.</param>
        /// <param name="checkForExistingType">Indica si debe generar el error por la inexistencia del tipo definido por el usuario en el contexto proporcionado.</param>
        /// <param name="currentScope">El alcance actual, no debe ser nulo.</param>
        /// <returns>Una descriptiva cadena equivalente al xplType.</returns>
        private string CalculeTypeString(XplType xplType, string extraErrorInfo, bool checkForExistingType, Scope currentScope)
        {
            return CalculeTypeString(xplType, String.Empty, extraErrorInfo, checkForExistingType, currentScope);
        }
        /// <summary>
        /// Calcula el la cadena del tipo "xplType".
        /// </summary>
        /// <param name="xplType">El tipo al cual se le calculara la cadena.</param>
        /// <param name="typeStr">La cadena parcial del tipo, usada internamente. Llamar con String.Empty.</param>
        /// <param name="extraErrorInfo">La cadena de error a anexar al encontrar un error en la declaracion del tipo.</param>
        /// <param name="checkForExistingType">Indica si debe generar el error por la inexistencia del tipo definido por el usuario en el contexto proporcionado.</param>
        /// <param name="currentScope">El alcance actual, no debe ser nulo.</param>
        /// <returns>Una descriptiva cadena equivalente al xplType.</returns>
        private string CalculeTypeString(XplType xplType, string typeStr, string extraErrorInfo, bool checkForExistingType, Scope currentScope)
        {
            if (this.p_isExtensionModule && !this.p_isClassfactorysDoc && (
                xplType.get_ftype()!= XplFactorytype_enum.NONE || 
                NativeTypes.IsNativeBlock(xplType.get_typename()) ||
                NativeTypes.IsNativeType(xplType.get_typename()) )
                )
            {
                return CalculeTypeStringForFactoryType(xplType);
            }

            if (xplType.get_ispointer() && xplType.get_isarray())
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.DerivedTypeCannotBePointerAndArrayAtSameTime,
                    xplType, extraErrorInfo));
                return String.Empty;
            }
            else if (xplType.get_ispointer())   ///Puntero
            {
                
                if (xplType.get_dt() == null)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.BaseTypeExpectedOnDerivedTypeDefinition,
                        xplType, extraErrorInfo));
                    return String.Empty;
                }
                else
                {
                    if (xplType.get_pi() == null)
                    {
                        AddNewError(SemanticError.New(SemanticErrorCode.PointerinfoExpectedOnPointerTypeDeclaration,
                            xplType, extraErrorInfo));
                        //Corrigo y continuo
                        xplType.set_pi(XplType.new_pi());
                        xplType.get_pi().set_ref(true);
                        //return String.Empty;
                    }
                    string pointerStr;
                    XplPointerinfo level = xplType.get_pi();
                    if (level.get_ref())
                        pointerStr = "^";
                    else
                        pointerStr = "*";
                    //Para el modificador de puntero se usara el siguiente código:
                    //- "v" indicando volatil
                    //- "c" indicando constante
                    //- "w" indicando volatil y constante
                    //- "_" sin modificador
                    //- ":" + "Class_Name" + ":" para punteros a miembros de clases
                    bool pVolatil = level.get_volatile();
                    bool pConst = level.get_const();
                    string pClassName = level.get_memberof();

                    if (pVolatil && pConst) pointerStr += "w";
                    else if (pVolatil) pointerStr += "v";
                    else if (pConst) pointerStr += "c";
                    else pointerStr += "_";

                    //Puntero a miembro de clase
                    if (pClassName != String.Empty)
                    {
                        pClassName = GetInternalQualifiedName(pClassName);
                        pClassName = p_types.get_ExistingTypeName(pClassName, currentScope);
                        if (pClassName == null && checkForExistingType)
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.DeclaredTypeDoesnotExist, xplType, GetInternalQualifiedName(level.get_memberof()), extraErrorInfo)
                            );
                        }
                        else if (pClassName == null)
                        {
                            pClassName = GetInternalQualifiedName(level.get_memberof());
                        }
                        pointerStr += ":" + pClassName + ":";
                    }
                    typeStr += pointerStr;
                    return CalculeTypeString(xplType.get_dt(), typeStr, extraErrorInfo, checkForExistingType, currentScope);
                }
            }
            else if (xplType.get_isarray())     //Matriz
            {
                if (xplType.get_dt() == null)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.BaseTypeExpectedOnDerivedTypeDefinition,
                        xplType, extraErrorInfo));
                    return String.Empty;
                }
                else
                {
                    if (xplType.get_ae() == null)
                        typeStr += "[]";
                    else
                        typeStr += "[" + GetStringOfExpressionForArrayType(xplType.get_ae()) + "]";

                    return CalculeTypeString(xplType.get_dt(), typeStr, extraErrorInfo, checkForExistingType, currentScope);
                }
            }
            else                                //Nombre de tipo
            {
                string typeName = GetInternalQualifiedName(xplType.get_typename());
                if (typeName == null || typeName == String.Empty)
                {
                    //return String.Empty;
                    //Por ahora devuelvo "$NONE$" por el tema de premitirlo en constructores.
                    return NativeTypes.None;
                }
                if (checkForExistingType)
                {
                    if (typeName[0] == '$')
                    {
                        if (!NativeTypes.IsValidNativeType(typeName))
                        {
                            AddNewError(SemanticError.New(SemanticErrorCode.InvalidNativeTypeDeclaration,
                                xplType, typeName, extraErrorInfo));
                            return String.Empty;
                        }
                    }
                    else
                    {
                        typeName = p_types.get_ExistingTypeName(typeName, currentScope);
                        if (typeName == null)
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.DeclaredTypeDoesnotExist, xplType, GetInternalQualifiedName(xplType.get_typename()), extraErrorInfo)
                            );
                            typeName = GetInternalQualifiedName(xplType.get_typename());
                        }
                    }
                }
                typeStr += typeName;
            }
            return typeStr;
        }

        /// <summary>
        /// Returns type string for provided XplType that is some kind of factory type
        /// (iname, exp, block)
        /// </summary>
        /// <param name="xplType">Type to calculate type string</param>
        /// <returns>Type string of xplType pointing to related CodeDOM class for factory class</returns>
        private static string CalculeTypeStringForFactoryType(XplType xplType)
        {
            switch (xplType.get_ftype())
            {
                case XplFactorytype_enum.NONE:
                    if(NativeTypes.IsNativeBlock(xplType.get_typename()))
                        return "^_" + SemanticAnalizer.CODEDOM_NAMESPACE + ".XplFunctionBody";
                    else if (NativeTypes.IsNativeType(xplType.get_typename()))
                        return "^_" + SemanticAnalizer.CODEDOM_NAMESPACE + ".XplType";
                    else
                        return String.Empty;
                case XplFactorytype_enum.INAME:
                    return "^_" + SemanticAnalizer.CODEDOM_NAMESPACE + ".XplIName";
                case XplFactorytype_enum.EXPRESSION:
                    return "^_" + SemanticAnalizer.CODEDOM_NAMESPACE + ".XplExpression";
                case XplFactorytype_enum.EXPRESSIONLIST:
                    return "^_" + SemanticAnalizer.CODEDOM_NAMESPACE + ".XplNodeList";
                case XplFactorytype_enum.STATEMENT:
                    return "^_" + SemanticAnalizer.CODEDOM_NAMESPACE + ".XplNode";
                default:
                    return String.Empty;
            }
        }

        private static string GetStringOfExpressionForArrayType(XplExpression xplExpression)
        {
            //PENDIENTE : devolver correctamente la cadena representando un array de dimensión estática.
            //-debo procesar la expresion, y si no retorna un valor constante entero es un error
            //en la declaracion del tipo.
            return "";
        }
        #endregion
       
        #region Procesamiento de Nombres Calificados e inserción de tipos en la tabla, Validacion de Identificadores
        /// <summary>
        /// Chequea si la cadena "identifierName" es un identificador valido, si no lo 
        /// es emite el error y agrega "errorStr" al error.
        /// </summary>
        /// <param name="identifierName">El identificador a chequear.</param>
        /// <param name="errorNode">El nodo al cual se agregara el error si existe.</param>
        /// <param name="errorStr">La cadena adicional de error.</param>
        private bool CheckValidIdentifier(string identifierName, XplNode errorNode, string errorStr)
        {
            // TODO correctly define valid identifiers and check
            if (String.IsNullOrEmpty(identifierName) || 
               !IsValidFirstIdentifierLetter(identifierName[0]) ||
               identifierName.LastIndexOfAny(new char[] { ' ' }) > -1)
            {
                AddNewError(
                    LexicalError.New(LexicalErrorCode.InvalidIdentifierName, errorNode, errorStr)
                    );
                return false;
            }
            return true;
        }
        /// <summary>
        /// Indica si "p" es un caracter valido como inicio para un identificador.
        /// </summary>
        private static bool IsValidFirstIdentifierLetter(char p)
        {
            if (p == '_' || Char.IsLetter(p))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Descompone el nombre calificado en una matriz
        /// de nombres simples ordenada comenzando por el nombre
        /// mas externo.
        /// No analiza semántica.
        /// Valida la correccion sintactica del nombre intentando procesarlo igual
        /// como correcto cuando es posible, pero emitiendo un error sintactico / lexico.
        /// </summary>
        private string[] GetNamesFromQualified(string fullName)
        {
            //PENDIENTE : El registro de errores no funcionara correctamente, se necesita
            //una forma de rastrear el error al documento Xpl.
            string[] retArray = null;
            int separatorType = 1;
            int n = 0;
            //Primero determino el separador utilizado en el nombre calificado
            //que puede ser "::", ":." o ".".
            // 
            //Utilizo "separatorType" con los codigos 1, 2 y 3 respectivamente.
            for (n = 0; n < fullName.Length; n++)
            {
                if (fullName[n] == ':')
                {
                    if (fullName[n + 1] == '.')
                    {
                        separatorType = 2;
                    }
                    else if (fullName[n + 1] != ':')
                    {
                        AddNewError(
                            SyntaxError.New(SyntaxErrorCode.InvalidSimpleNameSeparator, null)
                        );
                    }
                    break;
                }
                else if (fullName[n] == '.')
                {
                    separatorType = 3;
                    break;
                }
            }
            //Ahora que se el tipo de separador utilizado procedo a separar.
            Queue indexes = new Queue();
            int lastIndex = 0;
            if (separatorType == 3)
            {
                for (n = 0; n < fullName.Length; n++)
                {
                    if (fullName[n] == '.')
                        indexes.Enqueue(n);
                }
                retArray = new string[indexes.Count + 1];
                n = 0;
                //java.alg.ooo
                //4 8
                foreach (int index in indexes)
                {
                    retArray[n] = fullName.Substring(lastIndex, index - lastIndex);
                    lastIndex = index + 1;
                    n++;
                }
                retArray[n] = fullName.Substring(lastIndex);
            }
            else
            {
                for (n = 0; n < fullName.Length; n++)
                {
                    if (fullName[n] == ':')
                    {
                        if (separatorType == 1)
                        {
                            if (fullName[n + 1] != ':')
                                AddNewError(
                                    SyntaxError.New(SyntaxErrorCode.InvalidMixOfSimpleNameSeparators, null)
                                );
                        }
                        else
                        {
                            if (fullName[n + 1] != '.')
                                AddNewError(
                                    SyntaxError.New(SyntaxErrorCode.InvalidMixOfSimpleNameSeparators, null)
                                );
                        }
                        indexes.Enqueue(n);
                        n++;
                    }
                    if (fullName[n] == '.')
                    {
                        AddNewError(
                            SyntaxError.New(SyntaxErrorCode.InvalidMixOfSimpleNameSeparators, null)
                        );
                    }
                }
                retArray = new string[indexes.Count + 1];
                n = 0;
                foreach (int index in indexes)
                {
                    retArray[n] = fullName.Substring(lastIndex, index - lastIndex);
                    lastIndex = index + 2;
                    n++;
                }
                retArray[n] = fullName.Substring(lastIndex);
            }
            return retArray;
        }
        /// <summary>
        /// Extrae el nombre simple de un nombre calificado.
        /// Ej: "Ns1::Ns2::SimpleName" devuelve "SimpleName".
        /// No analiza semántica ni correccion sintáctica o léxica.
        /// Si "fullName" no es un nombre calificado el resultado es indeterminado.
        /// Usar sólo con nombres calificados.
        /// </summary>
        private static string GetSimpleNameFromQualified(string fullName)
        {
            Debug.Assert(
                TypeString.IsQualifiedName(fullName), 
                "Error de Diseño: funcion 'GetSimpleNameFromQualified' llamada con un nombre no calificado como argumento, resultado incorrecto. " + fullName
                );
            int index1 = fullName.LastIndexOf('.'),
                index2 = fullName.LastIndexOf(':');
            index1 = index1 > index2 ? index1 : index2;
            return fullName.Substring(index1 + 1);
        }
        /// <summary>
        /// Elimina el nombre simple de un nombre calificado.
        /// Ej: "Ns1::Ns2::SimpleName" devuelve "Ns1::Ns2".
        /// No analiza semántica ni correccion sintáctica o léxica.
        /// Si "fullName" no es un nombre calificado el resultado es indeterminado.
        /// Usar sólo con nombres calificados.
        /// </summary>
        private static string RemoveSimpleNameFromQualified(string fullName)
        {
            Debug.Assert(
                TypeString.IsQualifiedName(fullName),
                "Error de Diseño: funcion 'RemoveSimpleNameFromQualified' llamada con un nombre no calificado como argumento, resultado incorrecto."
                );
            int index1 = fullName.LastIndexOf('.'),
                index2 = fullName.LastIndexOf(':');
            index1 = index1 > index2 ? index1 : index2-1;
            return fullName.Substring(0, index1);
        }
        /// <summary>
        /// Si el espacio de nombres "fullName" no existe en la tabla de tipos
        /// lo inserta, de lo contrario no hace nada.
        /// </summary>
        private void InsertNamespaceType(string fullName, XplNamespace xplNamespace)
        {
            if(!p_types.Exists(fullName))
                p_types.InsertType(fullName, xplNamespace, XplAccesstype_enum.PUBLIC, null, false);
        }
        /// <summary>
        /// Si no existe el tipo en la tabla de tipos lo inserta,
        /// de lo contrario añade un error de compilación.
        /// 
        /// "fpMember" se utiliza solo al insertar un tipo de puntero a función.
        /// </summary>
        /// <param name="xplNode">El nodo que declara el tipo. Debe ser de tipos XplClass o XplFunction. Si el tipo no es correcto se lanza una excepción.</param>
        private bool InsertType(string fullName, XplNode xplNode, MemberInfo fpMember)
        {
            if (!(xplNode.get_TypeName()==CodeDOMTypes.XplClass || xplNode.get_TypeName()==CodeDOMTypes.XplFunction))
                throw new SemanticException("Unexpected xplNode type inserting Type.");
            XplAccesstype_enum accessOfType;
            if (xplNode.get_TypeName() == CodeDOMTypes.XplClass)
                accessOfType = ((XplClass)xplNode).get_access();
            else
                accessOfType = ((XplFunction)xplNode).get_access();
            if (!p_types.ExistsTypeInfo(fullName))
            {
                p_types.InsertType(fullName, xplNode, accessOfType, fpMember, p_isClassfactorysDoc);
            }
            else
            {
                XplNode node;
                node = ((TypeInfo)p_types[fullName]).get_TypeNode();
                if (node == xplNode) return true;
                int n = 0;
                while (p_types[fullName + "'" + n.ToString(CultureInfo.InvariantCulture)] != null) n++;

                if (xplNode.get_TypeName() == CodeDOMTypes.XplNamespace)
                    ((XplNamespace)xplNode).set_name(((XplNamespace)xplNode).get_name()+"'" + n.ToString(CultureInfo.InvariantCulture));
                else if (xplNode.get_TypeName() == CodeDOMTypes.XplClass)
                    ((XplClass)xplNode).set_name(((XplClass)xplNode).get_name() + "'" + n.ToString(CultureInfo.InvariantCulture));
                else
                    ((XplFunction)xplNode).set_name(((XplFunction)xplNode).get_name() + "'" + n.ToString(CultureInfo.InvariantCulture));

                fullName = fullName + "'" + n.ToString(CultureInfo.InvariantCulture);
                p_types.InsertType(fullName,
                    xplNode, accessOfType, fpMember, p_isClassfactorysDoc);

                AddNewError(
                    SemanticError.New(SemanticErrorCode.TypeAlreadyExist, xplNode, GetSimpleNameFromQualified(fullName))
                );
                if (p_persistentStructures && (!p_currentDocumentIsImport || p_isClassfactorysDoc))
                    p_typesToDelete.Add(fullName);

                return false;
            }
            if (p_persistentStructures && (!p_currentDocumentIsImport || p_isClassfactorysDoc))
                p_typesToDelete.Add(fullName);

            return true;
        }
        /// <summary>
        /// Obtiene un nombre calificado con un formato adecuado para su utilización
        /// interna en la tabla de simbolos.
        /// </summary>
        /// <param name="qualifiedName">Un nombre calificado como ocurre en un documento Zoe.</param>
        /// <returns>El mismo nombre calificado con formato adecuado para su uso interno.</returns>
        private static string GetInternalQualifiedName(string qualifiedName)
        {
            //Aquí debería chequear si el fuente utiliza como separador ".", "::" o ":.",
            //controlando en la información del lenguaje LayerD, que por ahora no tengo.
            //-
            //Por lo que simplemente, por ahora reemplazare "::" por "." :) .
            //
            return qualifiedName.Replace("::", ".");
        }
        #endregion

        #region FillImportedDocuments, NeedImportDirective, ProcessImport, AsyncTypeReader, DeferedTypeCheck
        private void FillImportedDocuments()
        {
            Hashtable importCache = new Hashtable();
            Scope currentScope = new Scope(p_types);
            ArrayList neededImportDirectives = new ArrayList();
            ArrayList zoeImportDirectives = new ArrayList();
            //Agrego el programa base por defecto donde tengo la
            //libreria base de ZOE.
            XplName import = XplDocumentBody.new_Import();
            XplNode imp = XplName.new_ns();
            if (!p_persistentStructures || p_types[OBJECT_CLASS_FULL_PATH] == null)
            {
                imp.set_Value("ZOEBase.pxpl");
                import.Children().InsertAtEnd(imp);
                zoeImportDirectives.Add(import);
            }

            foreach (XplDocument doc in p_programDocuments)
            {
                XplNodeList bodyList = doc.get_DocumentBody().get_ImportNodeList();
                foreach (XplNode node in bodyList)
                {
                    switch (node.get_ElementName())
                    {
                        case "Import":
                            if (NeedImportDirective((XplName)node))
                                if (((XplName)node).get_lddata() == "ZOE_IMPORT")
                                    zoeImportDirectives.Add(node);
                                else
                                    neededImportDirectives.Add(node);
                            break;
                    }
                }
            }
            //PENDIENTE : ¿que pasa cuando los programas importados
            //importan a su vez otros programas?, en realidad no los estoy
            //importando. Una opción sería realizar la importación directamente
            //en el ProgramLoader (o el InternalZOEImporter), y desligar al 
            //analizador semantico de dicha responsabilidad, por ahora lo 
            //vamos a dejar así :-).            
            //PENDIENTE : hacer q esto sea opcional :-P
            
            //El orden de esta importación debe conservarse de lo contrario revisar los metodos
            ProcessZoeImports(zoeImportDirectives);

            ProcessSupportImports();

            ProcessImports(neededImportDirectives, importCache, currentScope);
        }
        /// <summary>
        /// Importa los modulos de soporte de tiempo de compilación y classfactorysbase.
        /// </summary>
        private void ProcessSupportImports()
        {
            XplName[] imports = new XplName[3];
            // import "LayerD.CodeDOM", "platform=DotNET", "ns=DotNET", "assemblyfilename=lib_layerd_xpl_codedom_net.dll";
            XplName import = XplDocumentBody.new_Import();
            imports[0] = import;
            XplNode node = XplName.new_ns();
            node.set_Value("LayerD.CodeDOM");
            import.Children().InsertAtEnd(node);
            node = XplName.new_ns();
            node.set_Value("platform=DotNET");
            import.Children().InsertAtEnd(node);
            node = XplName.new_ns();
            node.set_Value("ns=DotNET");
            import.Children().InsertAtEnd(node);            
            node = XplName.new_ns();
            node.set_Value("assemblyfilename=" + Path.Combine(p_currentClientCore.WorkingPath, "lib_layerd_xpl_codedom_net.dll"));
            import.Children().InsertAtEnd(node);

            // import "LayerD.ZOECompiler", "platform=DotNET", "ns=DotNET", "assemblyfilename=lib_zoec_core.dll";
            import = XplDocumentBody.new_Import();
            imports[1] = import;
            node = XplName.new_ns();
            node.set_Value("LayerD.ZOECompiler");
            import.Children().InsertAtEnd(node);
            node = XplName.new_ns();
            node.set_Value("platform=DotNET");
            import.Children().InsertAtEnd(node);
            node = XplName.new_ns();
            node.set_Value("ns=DotNET");
            import.Children().InsertAtEnd(node);
            node = XplName.new_ns();
            node.set_Value("assemblyfilename=" + Path.Combine(p_currentClientCore.WorkingPath, "lib_zoec_core.dll"));
            import.Children().InsertAtEnd(node);

            // import "LayerD.ZOECompiler", "platform=DotNET", "ns=DotNET", "assemblyfilename=lib_zoe_cginterface.dll";
            import = XplDocumentBody.new_Import();
            imports[2] = import;
            node = XplName.new_ns();
            node.set_Value("LayerD.ZOECompiler");
            import.Children().InsertAtEnd(node);
            node = XplName.new_ns();
            node.set_Value("platform=DotNET");
            import.Children().InsertAtEnd(node);
            node = XplName.new_ns();
            node.set_Value("ns=DotNET");
            import.Children().InsertAtEnd(node);
            node = XplName.new_ns();
            node.set_Value("assemblyfilename=" + Path.Combine(p_currentClientCore.WorkingPath, "lib_zoe_cginterface.dll"));
            import.Children().InsertAtEnd(node);

            if (p_currentClientCore.get_BuildingExtension())
            {
                // Si estoy construyendo una extension las agrego a las referencias para que el generador
                // de codigo para que agregue las referencias a los ensamblados
                p_programDocuments[0].get_DocumentBody().Children().InsertAtBegin(imports[0]);
                p_programDocuments[0].get_DocumentBody().Children().InsertAtBegin(imports[1]);
                p_programDocuments[0].get_DocumentBody().Children().InsertAtBegin(imports[2]);
            }
            IZOEImportsDirectiveProcessor importerProcessor = p_compileTimeOutputModule.GetZOEImportsDirectiveProcessorModuleInstance();
            importerProcessor.UseTypesCache(false);
            if (importerProcessor.ProcessImports(imports, false))
            {
                p_importedDocuments = importerProcessor.GetLastImportProcessDocuments();
                if (p_importedDocuments == null && imports.Length > 0)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.UnableToObtainImportedDocument, imports[0])
                    );
                }
                else
                {
                }
                // Debo agregar los errores y advertencias del proceso de importación.
                IErrorCollection importerErrors = importerProcessor.GetLastImportErrors();
                if (importerErrors != null)
                    p_errorCollection.Merge(importerErrors);
            }
            else
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.ProcessingImportDirectiveError, imports[0])
                );
            }
            importerProcessor.UseTypesCache(importerProcessor.SupportCachedTypesIndex());
        }
        private void ProcessZoeImports(ArrayList zoeImportDirectives)
        {
            InternalZOETypeImporter importer = new InternalZOETypeImporter();
            InternalImportResult result;
            // XplName[] imports = (XplName[])zoeImportDirectives.ToArray(typeof(XplName));
            foreach (XplName import in zoeImportDirectives)
            {
                string importString = import.Children().FirstNode().get_StringValue();
                XplLayerDZoeProgramConfig config = (XplLayerDZoeProgramConfig)p_programDocuments[0].get_DocumentData().get_Config().get_Content();
                // PENDIENTE : Que soporte importar programas extendidos,
                // que proporcione correctamente la plataforma de tiempo de ejecución,
                // etc. Que tenga en cuenta cuando el programa importado no debe 
                // formar parte del DTE, etc.
                result = importer.ImportZOEProgram(importString, config, "", InternalZOETypeImporter.GetDirectoryFromSourceInfo(import.FullSourceFileInfo, p_currentClientCore.WorkingPath) );
                if (result.Success)
                {
                    if (result.IsInclude)
                    {
                        // include content
                        // first update source information
                        XplNode nextNode = import.CurrentDocumentBody.Children().NextSibling(import);
                        if (nextNode != null)
                        {
                            nextNode.PersistFullSourceFileInfo();
                        }
                        XplNodeList includeList = result.Program[0].get_DocumentBody().Children();
                        if (includeList != null)
                        {
                            includeList.FirstNode().PersistFullSourceFileInfo();
                            import.CurrentDocumentBody.InsertAtEnd(result.Program[0].get_DocumentBody().Children());
                        }
                        // remove import
                        import.CurrentDocumentBody.Children().Remove(import);
                    }
                    else
                    {
                        AddSourceFilesToActiveProgram(result.Program);
                    }
                }
                else
                {
                    Error error = new Error(result.DetailedErrorInfo, result.DetailedErrorInfo);
                    error.set_ErrorLayerDSourceFileData(import.FullSourceFileInfo);
                    AddNewError(error);
                }
            }            
        }

        private void AddSourceFilesToActiveProgram(XplDocument[] xplZOEDocument)
        {
            XplDocument[] backPrograms = (XplDocument[])p_programDocuments.Clone();
            p_programDocuments = new XplDocument[p_programDocuments.Length + xplZOEDocument.Length];

            backPrograms.CopyTo(p_programDocuments, 0);
            xplZOEDocument.CopyTo(p_programDocuments, backPrograms.Length);

            // xplZOEDocument.CopyTo(p_programDocuments, 0);
            // backPrograms.CopyTo(p_programDocuments, xplZOEDocument.Length);
        }
        private void ProcessImports(ArrayList neededImportDirectives, Hashtable importCache, Scope currentScope)
        {
            if (neededImportDirectives.Count == 0) return;
            // PENDIENTE : Falta chequear la correccion de la directiva import y 
            // el cumplimiento de los parametros estandar por parte del modulo de salida,
            // sobre todo chequear que posea los parametros de espacio de nombre base
            // para los tipos, de igual forma considerar que si no se especifica una
            // plataforma la directiva debe procesarse en todas las plataformas,
            // aunque esto sera muy raro que ocurra asi dice la especificación que
            // debe funcionar!
            IZOEImportsDirectiveProcessor importerProcessor = p_runtimeOutputModule.GetZOEImportsDirectiveProcessorModuleInstance();
            XplName[] imports = (XplName[])neededImportDirectives.ToArray( typeof(XplName) );

            try
            {
                if (importerProcessor.ProcessImports(imports, false))
                {
                    XplDocument[] importedDocs = importerProcessor.GetLastImportProcessDocuments();
                    if (importedDocs == null && imports.Length > 0)
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.UnableToObtainImportedDocument, imports[0])
                        );
                    }
                    else
                    {
                        if (importedDocs.Length > 0 && p_importedDocuments != null && p_importedDocuments.Length > 0)
                        {
                            XplDocument[] backImportedDocs = p_importedDocuments;
                            p_importedDocuments = new XplDocument[p_importedDocuments.Length + importedDocs.Length];
                            backImportedDocs.CopyTo(p_importedDocuments, 0);
                            importedDocs.CopyTo(p_importedDocuments, backImportedDocs.Length);
                        }
                    }
                    //Debo agregar los errores y advertencias del proceso de importación.
                    IErrorCollection importedErrors = importerProcessor.GetLastImportErrors();
                    if (importedErrors != null)
                        p_errorCollection.Merge(importedErrors);
                }
                else
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.ProcessingImportDirectiveError, imports[0])
                    );
                }
            }
            catch
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.ProcessingImportDirectiveError, imports[0], "Exception thrown.")
                );
            }
            p_types.set_AsyncTypeRead(new TypesTable.AsyncTypeRead(AsyncTypeReader));
            Hashtable importProcessorCachedTypes = importerProcessor.GetCachedTypesIndex();
            if (importProcessorCachedTypes != null) p_types.set_CachedTypesIndex(importProcessorCachedTypes);
        }
        /// <summary>
        /// Determina si una directiva import necesita ser procesada para la 
        /// plataforma de compilación actual o no y determina si una directiva
        /// import puede ser ignorada por tratarse de una duplicación.
        /// </summary>
        private bool NeedImportDirective(XplName xplImport)
        {
            int n = 0;
            //convierto los nodos en XplName a una matriz de cadenas
            string[] args = new string[xplImport.Children().GetLength()];
            foreach (XplNode node in xplImport.Children())
            {
                args[n] = node.get_StringValue(); n++;
            }
            string param = null, lastImport = null;
            int platformCount = 0;
            int lastIndex = 0;
            foreach (string arg in args)
            {
                lastIndex = arg.IndexOf('=');
                if (lastIndex < 0)
                {
                    //Si es el elemento principal armo una cadena para identificarla
                    foreach (string cad in args)
                        lastImport += cad.ToLower(CultureInfo.InvariantCulture).Trim();
                }
                else
                {
                    param = arg.Substring(0, lastIndex).ToLower(CultureInfo.InvariantCulture);
                    if (param == "platform")
                    {
                        platformCount++;
                        if (IsNeededImportPlatform(arg.Substring(lastIndex + 1))
                            && !p_processedImports.ContainsKey(lastImport))
                        {
                            p_processedImports.Add(lastImport, null);
                            return true;
                        }
                    }
                }
            }
            if (platformCount == 0)
            {
                xplImport.set_lddata("ZOE_IMPORT");
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Determina si la plataforma "platformName" debe procesarse
        /// para la plataforma de tiempo de ejecución actual, utilizar solo
        /// para directivas Import.
        /// </summary>
        private bool IsNeededImportPlatform(string platformName)
        {
            // PENDIENTE : hacerlo funcionar de verdad.
            return p_currentClientCore.get_OutputPlatform().ToLower(CultureInfo.InvariantCulture).Contains(platformName.ToLower(CultureInfo.InvariantCulture));
        }
        /// <summary>
        /// Ejecuta el ciclo ReadType para un tipo importado de forma asincrona.
        /// Esta funcion es llamada por la tabla de tipos cuando lo necesita.
        /// </summary>
        void AsyncTypeReader(XplNode node, string fullname)
        {
            // PENDIENTE : Tener en cuenta que al realizar el paso "ReadTypes" de forma
            // asincrona con los tipos importados las secciones que se asignan a la
            // clase son incorrectas, ya que se asignan a la seccion actual, ello
            // esta mal!!!.
            if (node.get_TypeName() == CodeDOMTypes.XplNamespace)
            {
                // No hago nada si es un espacio de nombres :-P
            }
            else if (node.get_TypeName() == CodeDOMTypes.XplClass)
            {
                Scope typeScope = new Scope(p_types);

                //Busco los usings y armo el scope
                XplNode docBody = node;
                while (docBody != null && docBody.get_TypeName() != CodeDOMTypes.XplDocumentBody) docBody = docBody.get_Parent();
                if (docBody != null)
                {
                    XplNodeList usings = ((XplDocumentBody)docBody).get_UsingNodeList();
                    foreach (XplName usingNode in usings)
                        ProcessUsing(usingNode, typeScope, SemanticAction.CheckTypes);
                }                
                typeScope.EnterScope(ScopeType.Namespace, fullname.Substring(0, fullname.LastIndexOf('.')));

                //Ejecuto el chequeo del tipo
                bool backState = p_currentDocumentIsImport;
                p_currentDocumentIsImport = true;                
                ProcessClass((XplClass)node, typeScope, SemanticAction.ReadTypes);
                p_currentDocumentIsImport = backState;
                
                typeScope.LeaveScope();
            }
            else
            { 
                //error
                throw new SemanticException("Internal compiler error. AsyncTypeReader unexpected node.");
            }
        }
        /// <summary>
        /// Implementa el chequeo diferido de tipos importados, lo que hace
        /// es ejecutar las pasadas de chequeo de tipos y calculo de herencia
        /// en el tipo importado que recibe como argumento.
        /// 
        /// No llamar con nulo.
        /// 
        /// Este método sólo debe ser llamado por la clase TypeInfo.
        /// </summary>
        internal static void DeferedTypeCheck(TypeInfo typeInfo)
        {
            // PENDIENTE : chequear esto para verificar el tema de la asignacion de
            // secciones a los tipos que son chequeados de forma diferida.
            // It always returns if it's a fp type, that is not necessarily the case
            if (!p_currentParseInstance.p_enableDeferedTypeCheck || typeInfo.get_IsFPType()) return;

            // if type is already in defered type check return
            if (typeInfo.get_IsOnDeferedTypeCheck()) return;

            if (typeInfo.get_BaseCheckeds() || typeInfo.get_InheritanceCalculated()) return;
            string fullname = typeInfo.get_FullName();
            Scope typeScope = new Scope(p_currentParseInstance.p_types);
            //Busco los usings y armo el scope
            XplNode docBody = typeInfo.get_TypeNode();
            while (docBody != null && docBody.get_TypeName() != CodeDOMTypes.XplDocumentBody) docBody = docBody.get_Parent();
            if (docBody != null)
            {
                XplNodeList usings = ((XplDocumentBody)docBody).get_UsingNodeList();
                foreach (XplName usingNode in usings)
                    p_currentParseInstance.ProcessUsing(usingNode, typeScope, SemanticAction.CheckTypes);
            }
            typeScope.EnterScope(ScopeType.Namespace, fullname.Substring(0, fullname.LastIndexOf('.')));
            typeInfo.set_IsOnDeferedTypeCheck(true);
            //Ejecuto el chequeo del tipo
            bool backState = p_currentParseInstance.p_currentDocumentIsImport;
            p_currentParseInstance.p_currentDocumentIsImport = true;
            if(!typeInfo.get_TypeChequed()) p_currentParseInstance.ProcessClass((XplClass)typeInfo.get_TypeNode(), typeScope, SemanticAction.CheckTypes);
            p_currentParseInstance.ProcessClass((XplClass)typeInfo.get_TypeNode(), typeScope, SemanticAction.CheckInheritance);            
            p_currentParseInstance.p_currentDocumentIsImport = backState;
            typeInfo.set_IsOnDeferedTypeCheck(false);
            typeScope.LeaveScope();            
        }
        #endregion

        #region CreateDTE
        private void CreateDTE()
        {
            XplDocument tempDTE = new XplDocument();
            XplDocumentBody bodyDTE = XplDocument.new_DocumentBody();
            tempDTE.set_ElementName("ZOEDocument");
            tempDTE.set_DocumentData(XplDocument.new_DocumentData());
            tempDTE.set_DocumentBody(bodyDTE);
            //Copio la configuración del programa fuente al EZOE
            //ATENCION el primer documento debe ser el archivo de programa!!
            tempDTE.get_DocumentData().set_Config((XplConfig)p_programDocuments[0].get_DocumentData().get_Config().Clone());

            foreach (Section section in p_programSections.get_IList())
                if (section.IsOrdinary() && !section.IsBadSection() && !section.IsExternalImportedSection()
                    || p_interactiveOnly && !section.IsBadSection() && !section.IsExternalImportedSection())
                {
                    XplNode firstNode = null;
                    XplNodeList sourceList = null;
                    if (section.IsExplicitSection())
                    {
                        //Esta en un espacio de nombres
                        sourceList = section.get_SectionNamespace().Children();
                    }
                    else
                    {
                        XplDocument docu = (XplDocument)section.get_SectionDocumentBody().get_Parent();
                        XplNode title = docu.get_DocumentData() != null ? docu.get_DocumentData().get_Title() : null;
                        //Es un cuerpo de programa
                        if (title != null && title.get_StringValue() == "__REMOVE_FROM_DTE__")
                            sourceList = new XplNodeList();
                        else
                            sourceList = section.get_SectionDocumentBody().Children();
                    }

                    if (sourceList.GetLength() > 0)
                    {
                        firstNode = sourceList.FirstNode();
                        firstNode.PersistFullSourceFileInfo();
                        if (bodyDTE.Children().GetLength() == 0 || bodyDTE.get_ldsrc() == "")
                            bodyDTE.PersistFullSourceFileInfo();
                    }
                    XplNodeList.CopyNodesAtEnd(sourceList, bodyDTE.Children());
                }
            p_lastParseDTE = tempDTE;
        }
        #endregion

        #region CreateExtensionSections
        public SectionCollection get_LastParseSections()
        {
            return p_programSections;
        }
        private void CreateExtensionSections()
        {
            // if this is a compilation of an extension module ignore the call
            if (p_isExtensionModule) return;

            int count = 0;
            //Si es la compilación interactiva no creo secciones de extensión
            if(!p_interactiveOnly)
                foreach (Section section in p_programSections.get_IList())
                    if (section.IsExtension() && !section.IsBadSection()) count++;
            string programName =
                ((XplLayerDZoeProgramConfig)p_programDocuments[0].get_DocumentData().get_Config().get_Content())
                .get_name();
            if (count > 0)
            {
                p_lastParseExtensionSections = new ExtensionData[count];
                count = 0;
                foreach (Section section in p_programSections.get_IList())
                    if (section.IsExtension() && !section.IsBadSection())
                    {
                        //PENDIENTE : que copie bien la info de fuente en los
                        //nodos del documento de seccion creado
                        XplDocument sectionDoc = new XplDocument();
                        sectionDoc.set_ElementName("ZOEDocument");
                        XplDocumentBody sectionBody;
                        XplNodeList list;
                        if (section.IsExplicitSection())
                        {   //Esta en un espacio de nombres
                            sectionBody = new XplDocumentBody();
                            //Copio los usings y los imports desde el fuente original
                            sectionBody.Children().InsertAtBegin(section.get_SectionNamespace().CurrentDocumentBody.get_UsingNodeList());
                            sectionBody.Children().InsertAtBegin(section.get_SectionNamespace().CurrentDocumentBody.get_ImportNodeList());

                            list = section.get_SectionNamespace().Children();
                            //Copio la info de codigo fuente
                            if (list.GetLength() > 0)
                            {
                                XplNode firstNode = list.FirstNode();
                                firstNode.PersistFullSourceFileInfo();
                                sectionBody.set_ldsrc(firstNode.get_ldsrc());
                            }
                            XplNamespace ns = new XplNamespace(section.get_NamespaceName(), false, false, list);
                            ns.set_ElementName("Namespace");
                            //debo copiar los usings y los imports del document
                            //XplNodeList.CopyNodesAtEnd(, sectionBody.Children());                            
                            //Luego inserto el espacio de nombres
                            sectionBody.Children().InsertAtEnd(ns);

                            //Creo una copia de los nodos en el namespace de la seccion
                            //luego borro el namespace y asigno la copia
                            XplNodeList copy = new XplNodeList();
                            foreach (XplNode node in list)
                                copy.InsertAtEnd(node.Clone());
                            list.Clear();
                            XplNodeList.CopyNodesAtEnd(copy, list);
                        }
                        else
                        {   //Es un cuerpo de programa
                            sectionBody = section.get_SectionDocumentBody();                            
                            ((XplDocument)sectionBody.get_Parent()).set_DocumentBody((XplDocumentBody)sectionBody.Clone());
                        }
                        sectionDoc.set_DocumentBody(sectionBody);
                        p_lastParseExtensionSections[count++] = new ExtensionData(programName, sectionDoc, section.WritecodeExpressions);
                    }
            }
            else p_lastParseExtensionSections = null;
        }
        #endregion

        #region Varios Depuracion
        /// <summary>
        /// Para depuración!
        /// </summary>
        public static string ViewNode(XplNode node)
        {
            CSZOERenderModule rm = new CSZOERenderModule();
            if (node is XplExpression)
                return rm.RenderExpression((XplExpression)node);
            else
                return node.ToString();
        }

        static DateTime[] p_timerInit = new DateTime[10];
        static bool[] p_timerOn = new bool[10];
        static TimeSpan[] p_timer = new TimeSpan[10];
        static int maxTimerUsed=-1;

        static void BeginTimer(int number)
        {
            if (number > maxTimerUsed) maxTimerUsed = number;
            if (p_timerOn[number]) return;
            p_timerInit[number] = DateTime.Now;
            p_timerOn[number] = true;
        }
        static void EndTimer(int number)
        {
            p_timer[number] += DateTime.Now - p_timerInit[number];
            p_timerOn[number] = false;
        }
        static private void ShowTimers()
        {
            if(maxTimerUsed>-1)
                for(int n=0;n<=maxTimerUsed;n++)
                    ZOECompilerCore.WriteDebugTextLine("Timer "+n+": " + p_timer[n]);
        }
        #endregion

        ZOECompilerCore p_currentClientCore;
        internal void set_CurrentClientCore(ZOECompilerCore compilerCore)
        {
            p_currentClientCore = compilerCore;
        }

        internal void UnregisterClassfactoryToIgnore(string fullClassfactoryNameToIngnore)
        {
            p_candidateStructures.UnregisterClassfactoryToIgnore(fullClassfactoryNameToIngnore);
        }

        internal void RegisterClassfactoryToIgnore(string fullClassfactoryNameToIngnore)
        {
            p_candidateStructures.RegisterClassfactoryToIgnore(fullClassfactoryNameToIngnore);
        }
    }

    #region ExtensionData
    public class ExtensionData
    {
        XplDocument p_document;
        XplDocument p_documentClone;
        ArrayList p_writecodeList;
        string p_name;
        public string Name
        {
            get { return p_name; }
            set { p_name = value; }
        }
        public XplDocument Document{
            get { return p_document; }
        }
        public XplDocument DocumentClone
        {
            get { return p_documentClone; }
        }
        public ArrayList WritecodeList
        {
            get { return p_writecodeList; }
        }
        public void CloneDoc(){
            p_documentClone = (XplDocument)p_document.Clone();
        }
        public ExtensionData(string programName, XplDocument doc, ArrayList writecodeList)
        {
            p_name = programName;
            p_document = doc;
            p_writecodeList = writecodeList;
        }
    }
    #endregion

    #region Tipos para Representación de Secciones
    public class Section
    {
        XplNode p_section;
        bool p_isExtension;
        bool p_isNamespace;
        bool p_badSection;
        bool p_isExternalImportedSection;
        bool p_isInternalImportedSection;
        string p_namespaceName;
        ArrayList p_writecodeExpressions = new ArrayList();

        public ArrayList WritecodeExpressions
        {
            get { return p_writecodeExpressions; }
        }
        /// <summary>
        /// Crea una Seccion a partir de un elemento "Section" de declaracion
        /// de seccion, controla por el nombre de la sección pero no emite errores,
        /// si el nombre es impropio lanza una Aserción.
        /// </summary>
        public Section(XplNamespace section, bool isExternalImportedSection, bool isInternalImportedSection, string namespaceName)
        {
            p_section = section;
            p_namespaceName = namespaceName;
            p_isNamespace = true;
            p_isExternalImportedSection = isExternalImportedSection;
            p_isInternalImportedSection = isInternalImportedSection;
            Debug.Assert(section.get_ElementName() == "Section", "El nombre del elemento de una sección debe ser 'Section'.");
            if (section.get_name() == "ordinary")
                p_isExtension = false;
            else if (section.get_name() == "extension")
                p_isExtension = true;
            else
                Debug.Assert(false, "El nombre de sección no es valido en el nodo.");

        }
        /// <summary>
        /// Construye una sección a partir de un DocumentBody, asume que el 
        /// documentbody no utiliza declaraciones explicitas de secciones sino
        /// implicitas, identifica el tipo de sección implicita buscando la primera 
        /// clase, si no hay clases definidas supone una sección ordinaria.
        /// </summary>
        public Section(XplDocumentBody section, bool isExternalImportedSection, bool isInternalImportedSection, bool searchForClassfactorys)
        {
            p_section = section;
            p_isNamespace = false;
            p_isExternalImportedSection = isExternalImportedSection;
            p_isInternalImportedSection = isInternalImportedSection;
            XplNodeList p_list = section.get_NamespaceNodeList();
            XplNodeList p_list2;
            p_isExtension = false;

            if (searchForClassfactorys)
            {
                foreach (XplNamespace ns in p_list)
                {
                    p_list2 = ns.get_ClassNodeList();
                    if (p_list2.GetLength() > 0)
                    {
                        if (((XplClass)p_list2.FirstNode()).get_isfactory()
                            || ((XplClass)p_list2.FirstNode()).get_isinteractive()) p_isExtension = true;
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Obtiene el XplNamespace de la sección siempre
        /// que sea una sección explicita, de lo contrario 
        /// retorna null.
        /// </summary>
        public XplNamespace get_SectionNamespace()
        {
            if (p_isNamespace) return (XplNamespace)p_section;
            else return null;
        }
        /// <summary>
        /// Obtiene el XplDocumentBody de la sección siempre
        /// que sea una sección implicita, de lo contrario 
        /// retorna null.
        /// </summary>
        public XplDocumentBody get_SectionDocumentBody()
        {
            if (!p_isNamespace) return (XplDocumentBody)p_section;
            else return null;
        }
        /// <summary>
        /// Indica si la sección es una declaración explicita con un
        /// espacio de nombres o sólo es un DocumentBody con
        /// un tipo de sección implicita.
        /// </summary>
        public bool IsExplicitSection()
        {
            return p_isNamespace;
        }
        public bool IsExtension()
        {
            return p_isExtension;
        }
        public bool IsOrdinary()
        {
            return !p_isExtension;
        }
        /// <summary>
        /// Indica si la seccion es "mala", es decir si 
        /// contiene errores y no debe considerarse en la
        /// composición del DTE o como una extensión valida.
        /// </summary>
        public bool IsBadSection()
        {
            return p_badSection;
        }
        /// <summary>
        /// Permite marcar la sección como "mala" cuando no 
        /// es una sección valida.
        /// </summary>
        public void set_IsBadSection(bool isBadSection)
        {
            p_badSection = isBadSection;
        }
        /// <summary>
        /// Indica si la sección actual corresponde a una sección importada desde
        /// un modulo de salida, es decir obtenida de un documento importado con 
        /// una directiva import procesada por un modulo de salida.
        /// </summary>
        public bool IsExternalImportedSection()
        {
            return p_isExternalImportedSection;
        }
        public bool IsInternalImportedSection()
        {
            return p_isInternalImportedSection;
        }
        public  string get_NamespaceName()
        {
            return p_namespaceName;
        }
    }
    public class SectionCollection
    {
        ArrayList p_sectionList;
        bool p_missingSections = false;

        public void set_MissingSections(bool missingSections)
        {
            p_missingSections = true;
        }
        public bool get_MissingSections()
        {
            return p_missingSections;
        }
        public SectionCollection()
        {
            p_sectionList = new ArrayList();
        }
        public void Insert(Section section)
        {
            p_sectionList.Add(section);
        }
        public void Remove(Section section)
        {
            p_sectionList.Remove(section);
        }
        public bool Contains(Section section)
        {
            return p_sectionList.Contains(section);
        }
        public int get_Length()
        {
            return p_sectionList.Count;
        }
        public IList get_IList()
        {
            return p_sectionList;
        }
        public Section get_LastSection()
        {
            if (p_sectionList.Count > 0)
                return (Section)p_sectionList[p_sectionList.Count - 1];
            else
                return null;
        }
    }
    #endregion

    #region Clase "SemanticException"
    public class SemanticException : Exception
    {
        public SemanticException(string errorMsg): base(errorMsg)
        {
        }
    }
    #endregion

}
