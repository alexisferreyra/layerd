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

///
///Lista de Errores semánticos Lanzados por el Analizador Semantico.
///
using System;
using System.Collections;
using LayerD.CodeDOM;
using System.Globalization;

namespace LayerD.ZOECompiler
{
    #region Errores Semánticos
    /// <summary>
    /// Indices para la Tabla de Errores Semanticos, tener en cuenta
    /// lo siguiente:
    /// 
    /// El código 1000 es solo una plantilla, los errores semánticos
    /// deben codificarse desde el código 1001 hasta el 1999.
    /// </summary>
    public enum SemanticErrorCode
    {
        FirstSemanticError                              = 1000,
        //Aquí los Códigos de Error
        
        UnspecifiedSemanticError                        = 1001,
        UnexpectedNode                                  = 1002,
        UnexpectedQualifiedNameInTypeDeclaration        = 1003,
        TypeAlreadyExist                                = 1004,
        ProcessingImportDirectiveError                  = 1005,
        UnableToObtainImportedDocument                  = 1006,
        InvalidNamespaceinUsingDirective                = 1007,
        DeclaredTypeDoesnotExist                        = 1008,
        InvalidTypeForBaseClass                         = 1009,
        InvalidInheritanceFromFinalClass                = 1010,
        DuplicatedBaseType                              = 1011,
        InheritanceCircularity                          = 1012,
        InvalidStructureBaseType                        = 1013,
        InvalidBaseClassForClassfactory                 = 1014,
        ClassfactoryCanNotInheritFromInteractive        = 1015,
        InvalidClassfactoryAsBaseClass                  = 1016,
        InvalidBaseTypeForInterface                     = 1017,
        InvalidFactoryInterfaceImplementer              = 1018,
        InvalidCombinationOfClassModifiers              = 1019,
        TypeCanNotBeAbstractAndFinal                    = 1020,
        EnumCanNotHaveBaseTypes                         = 1021,
        DuplicatedMemberName                            = 1022,
        InvalidSectionName                              = 1023,
        InvalidFactoryTypeDeclarationInOrdinarySection  = 1024,
        InvalidTypeDeclarationInExtensionSection        = 1025,
        MissingSectionDeclaration                       = 1026,
        InvalidNestedSectionDeclaration                 = 1027,
        DerivedTypeCannotBePointerAndArrayAtSameTime    = 1028,
        TypeNameRequiredOnTypeDeclaration               = 1029,
        TypeRequired                                    = 1030,
        FunctionBodyRequired                            = 1031,
        AccesorRequired                                 = 1032,
        DuplicatedAccesor                               = 1033,
        UnexpectedFunctionBody                          = 1034,
        UnexpectedStatement                             = 1035,
        MemberCanNotBeAbstractAndFinal                  = 1036,
        MemberCanNotBeVirtualAndNonVirtual              = 1037,
        MemberCanNotBeAbstractAndNonVirtual             = 1038,
        MemberCanNotBeOverrideAndNonVirtual             = 1039,
        InvalidExecModifierInTypesOfNonfactoryMembers   = 1040,
        InvalidInameModifierInTypeOfNonfactoryMembers   = 1041,
        InvalidExpModifierInTypeOfNonfactoryMembers     = 1042,
        BaseTypeExpectedOnDerivedTypeDefinition         = 1043,
        InvalidMemberOverloadSignatureAlreadyExists     = 1044,
        SymbolAlreadyDefinedInCurrentScope              = 1045,
        UnresolvedNameOnExpression                      = 1046,
        InvalidLeftExpressionOnFunctionCallOperator     = 1047,
        AmbiguousFunctionCall                           = 1048,
        InvalidMemberTypeUsedAsMethod                   = 1049,
        LValueRequiredAsLeftOperatorOfAssingment        = 1050,
        IncompatibleTypesForAssingment                  = 1051,
        InvalidSimpleMemberAccessUsedAsScopeAccess      = 1052,
        InvalidLeftExpressionOnSimpleMemberAccess       = 1053,
        ANameRequiredAsRightExpression                  = 1054,
        ExpressionRequired                              = 1055,
        InvalidUseOfRefModifierOnPointerTypeDeclaration = 1056,
        InaccesibleType                                 = 1057,
        InaccesibleTypeMember                           = 1058,
        NonexistentMemberOfType                         = 1059,
        CannotAccessInstanceMemberFromStatic            = 1060,
        CannotAccessStaticMemberUsingInstanceValue      = 1061,
        AValueIsRequiredToInvoqueInstanceMember         = 1062,
        ValueRequiredAsRightOperatorOfAssingment        = 1063,
        InvalidArgumentTypeForActualParameter           = 1064,
        InvalidNumberOfArgumentsInFunctionCall          = 1065,
        NonexistentParameterNameInFunctionCall          = 1066,
        NamedArgumentRequired                           = 1067,
        BestOverloadedFunctionHasSomeInvalidArguments   = 1068,
        InvalidLeftExpressionOnPointerMemberAccess      = 1069,
        TypeNotAllowedAsLeftExpOnPointerMemberAccess    = 1070,
        MoreIndirectionsRequiredOnPointerMemberAccess   = 1071,
        BinaryOperatorWasNotFoundForCurrentOperands     = 1072,
        UnaryOperatorWasNotFoundForCurrentOperand       = 1073,
        InvalidNonStaticOperatorDeclaration             = 1074,
        InvalidNumberOfParameters                       = 1075,
        ValueOrLValueRequiredAsOperand                  = 1076,
        InvalidPointerDereference                       = 1077,
        LValueRequiredAsOperandOfAddressOfOperator      = 1078,
        InvalidLeftExpressionOfArrayAccessOperator      = 1079,
        InvalidArgumentsCountForArrayAccess             = 1080,
        InvalidExpressionTypeForArrayAccess             = 1081,
        IndexerWasNotFoundOnType                        = 1082,
        ValueRequiredOnBooleanExpression                = 1083,
        BooleanValueRequiredOnBooleanExpression         = 1084,
        StatementRequired                               = 1085,
        ReturnAValueIsRequired                          = 1086,
        ReturnAValueIsNotAllowed                        = 1087,
        ValueRequiredOnReturnStatement                  = 1088,
        TypeRequiredOnReturnStatement                   = 1089,
        InvalidReturnStatementExpressionValue           = 1090,
        InvalidUseOfBreakStatement                      = 1091,
        InvalidUseOfContinueStatement                   = 1092,
        InvalidUseOfResumeStatement                     = 1093,
        InvalidUseOfResumeNextStatement                 = 1094,
        ValueRequiredOnThrowStatementExpression         = 1095,
        ValueOfTypeExceptionRequiredOnThrowStatement    = 1096,
        CatchOrFinallyBlockRequiredOnTryStatement       = 1097,
        CatchVariableMustBeOfTypeException              = 1098,
        CatchVariableUndeclared                         = 1099,
        InvalidWritecodeUseInNonFactoryMember           = 1100,
        InvalidSelectoutputUseInNonFactoryMember        = 1101,
        InvalidGlobalCatch                              = 1102,
        CaseElementRequiredOnSwitchStatement            = 1103,
        InvalidTypeOfSwitchExpression                   = 1104,
        DuplicatedDefaultCaseOnSwitchStatement          = 1105,
        InvalidTypeOfCaseExpression                     = 1106,
        DuplicatedConstantCaseExpressionValue           = 1107,
        ValueRequiredOnCaseExpression                   = 1108,
        ConstantExpressionRequiredOnCaseExpression      = 1109,
        InvalidInstantiationOfAbstractType              = 1110,
        InvalidTypeForNewExpression                     = 1111,
        TypeForNewExpressionNotSupportedByCodeGenerator = 1112,
        InvalidInitializerForArrayType                  = 1113,
        ConstructorNotFoundForSuppliedArguments         = 1114,
        InvalidNativeTypeDeclaration                    = 1115,
        PointerinfoExpectedOnPointerTypeDeclaration     = 1116,
        ValueRequiredOnCastExpression                   = 1117,
        UndefinedExplicitConversion                     = 1118,
        UnexpectedArrayInitializer                      = 1119,
        ConstructorNotAvailableDueToItsProtectionLevel  = 1120,
        ArrayInitializerRequired                        = 1121,
        BlockArgumentExpectedOnFunctionCall             = 1122,
        UnexpectedArgumentBlockOnFunctionCall           = 1123,
        UnresolvedNameOnWritecodeExpression             = 1124,
        InvalidTypeReferencedOnWritecodeExpression      = 1125,
        ValueRequiredForNamesOnWritecodeExpression      = 1126,
        ValidExpressionRequiredOnForeach                = 1127,
        ArrayOrCollectionExpressionRequiredOnForeach    = 1128,
        AdecuateConversionDoesnotExistsOnForeach        = 1129,
        VariableDeclarationRequiredOnForeach            = 1130,
        TypeRequiredOnIsExpression                      = 1131,
        ValueRequiredOnIsExpression                     = 1132,
        WritecodeExpressionEmpty                        = 1133,
        InvalidEmptyExpressionNode                      = 1134,
        InterfaceMemberNotImplemented                   = 1135,
        InvalidFieldAsMemberOfInterface                 = 1136,
        InvalidAbstractMemberOnNonAbstractType          = 1137,
        BooleanTernaryOperatorRequireValues             = 1138,
        UnsupportedTernaryOperator                      = 1139,
        IncompatibleTypesOnBooleanTernaryOperator       = 1140,
        IncompatibleTypesForAssignmentInInitialization  = 1141,
        CustomExplicitConversionOperationAlreadyDefined = 1142,
        CustomImplicitConversionOperationAlreadyDefined = 1143,
        PointerTypesCannotBeCompared                    = 1144,

        //Fin de los Códigos de Error
        LastSemanticError                               = 2000,
    }
    class SemanticErrorsList
    {
        private const int offset = 1000;
        /// <summary>
        /// Tabla de Errores Semanticos, utilizar el formato indicado y tener en cuenta
        /// lo siguiente:
        /// 
        /// Para los "placement" utilizar "%1", "%2", ... "%5".
        /// 
        /// El código 1000 es solo una plantilla, los errores semánticos
        /// deben codificarse desde el código 1001 hasta el 1999.
        /// 
        /// El mensaje de error debe ser en ingles y el mensaje local en 
        /// Castellano o el idioma nativo del compilador.
        /// </summary>
        static object[,] Errors =
        {
            ///Error Code   | ErrorMsg  | ErrorUrl  | ErrorHelp | LocaleMsg
            {SemanticErrorCode.FirstSemanticError,"ErrorMsg","ErrorUrl","ErrorHelp","LocaleMsg"},

            //Inicio Errores Reales
            {SemanticErrorCode.UnspecifiedSemanticError,"Unspecified semantic error. %1","","","Error semántico sin especificar. %1"},
            {SemanticErrorCode.UnexpectedNode,"Unexpected Node \"%1\" found as child of \"%2\". %3","","","Nodo inesperado \"%1\" encontrado como hijo de \"%2\"."},
            {SemanticErrorCode.UnexpectedQualifiedNameInTypeDeclaration,"Unexpected qualified name \"%1\" in type declaration. Use only a simple names to declare types. %2","","","Nombre calificado \"%1\" usado inesperadamente en declaración de tipo. Utilice un nombre simple."},
            {SemanticErrorCode.TypeAlreadyExist,"The type \"%1\" already exists in current scope. Use another name for the type. %2","","","El tipo \"%1\" ya existe en el alcance actual. Utilice otro nombre para el tipo."},
            {SemanticErrorCode.ProcessingImportDirectiveError,"Error processing import directive %1. Check correctness for supplied arguments. %2","","","Error procesando la directiva de importación %1. Controle la correción de los argumentos proporcionados."},
            {SemanticErrorCode.UnableToObtainImportedDocument,"Error obtaining imported document from ZOE Output Module. Check for Output Module correct instalation. %1","","","Error obteniendo los documentos importados del Modulo de Salida ZOE. Controle la correcta instalación de los módulos."},
            {SemanticErrorCode.InvalidNamespaceinUsingDirective,"Invalid Namespace \"%1\" in using directive.\"%1\" is not a namespace, using directive require an existing namespace. %2","","","Nombre de espacio de nombre \"%1\" invalido en directiva using. Se requiere un espacio de nombres existente."},
            {SemanticErrorCode.DeclaredTypeDoesnotExist,"Declared Type \"%1\" does not exist in current scope. %2","","","El tipo \"%1\" no existe en el alcance actual."},
            {SemanticErrorCode.InvalidTypeForBaseClass,"Namespaces, Structs, Enums or Function Pointer Types types are invalid as base classes. \"%1\" is not a Class or Interface type. %2","","","Espacios de Nombres, Estructuras, Enumeraciones o Punteros a Función son invalidos como tipos bases. \"%1\" no es una Clase o Interfaz."},
            {SemanticErrorCode.InvalidInheritanceFromFinalClass,"Is not allowed to inherit from final Class or Interface. \"%1\" is a final Class or Interface. %2","","","No es posible heredar de una clase o interface final. \"%1\" es una Clase o Interface final."},
            {SemanticErrorCode.DuplicatedBaseType,"The type \"%1\" is currently a base type of \"%2\". %3","","","El tipo \"%1\" es actualmente una base del tipo \"%2\"."},
            {SemanticErrorCode.InheritanceCircularity,"The type \"%1\" circulary dependes on \"%2\". %3","","","El tipo \"%1\" depende circularmente de \"%2\"."},
            {SemanticErrorCode.InvalidStructureBaseType,"Structures can not inherit from other classes or structures. \"%1\" is not an Interface type. %2","","","Estructuras no pueden heredar de otras Clases o Estructuras. \"%1\" no es un tipo Interfaz."},
            {SemanticErrorCode.InvalidBaseClassForClassfactory,"The type \"%1\" can not be a base of type \"%2\". Classfactorys can only inherit from others classfactorys. %3","","","El tipo \"%1\" no puede ser base del tipo \"%2\". Classfactorys sólo pueden heredar de otras Classfactorys."},
            {SemanticErrorCode.ClassfactoryCanNotInheritFromInteractive,"Classfactory \"%1\" can not inherit from \"%2\" Interactive Classfactory. Interactive Classfactory can only be inherited by others Interactive Classfactorys. %3","","","La Classfactory \"%1\" no puede heredar de la Classfactory Interactiva \"%2\". Las Classfactorys Interactivas sólo pueden ser heredadas por otras classfactorys interactivas."},
            {SemanticErrorCode.InvalidClassfactoryAsBaseClass,"The Classfactory type \"%1\" can not be a base of \"%2\" type. Non factory types can not inherit from factory types. %3","","","La classfactory \"%1\" no puede ser base del tipo \"%2\". Tipos No-Factory no puede heredar de tipos factory."},
            {SemanticErrorCode.InvalidBaseTypeForInterface,"The type \"%1\" can not be a base for \"%2\" Interface type. Interfaces can only inherit from others interfaces. %3","","","El tipo \"%1\" no puede usarse como base del tipo interfaz \"%2\". Las Interfaces sólo pueden heredar de otras interfaces."},
            {SemanticErrorCode.InvalidFactoryInterfaceImplementer,"Factory Interface \"%1\" can not be implemented or inherited by \"%2\" type. Factory Interfaces can only be implemented or inherited by Classfatorys or other Factory Interfaces. %3","","","Interfaces Factory \"%1\" no puede ser heredada o implementada por el tipo \"%2\". Interfaces Factory sólo pueden ser heredadas o implementadas por otros Tipos Factory."},
            {SemanticErrorCode.InvalidCombinationOfClassModifiers,"The type \"%1\" have invalid combination of declaration modifiers. %2","","","El tipo \"%1\" posee una combinación invalida de modificadores de declaración."},
            {SemanticErrorCode.TypeCanNotBeAbstractAndFinal,"Type \"%1\" can not be declared both Abstract and Final. %2","","","El tipo \"%1\" no puede ser declarado final y abstracto simultaneamente."},
            {SemanticErrorCode.EnumCanNotHaveBaseTypes,"The Enum \"%1\" type can not have non-system base types. %2","","","El tipo Enumeración \"%1\" no puede tener tipos bases que no sean definidos por el sistema."},
            {SemanticErrorCode.DuplicatedMemberName,"Duplicated member name \"%1\" in type \"%2\". %3","","","Nombre de miembro \"%1\" duplicado en el tipo \"%2\"."},
            {SemanticErrorCode.InvalidSectionName,"Invalid section name \"%1\". %2","","","Nombre de sección \"%1\" invaludo."},
            {SemanticErrorCode.InvalidFactoryTypeDeclarationInOrdinarySection,"Invalid \"%1\" Factory Type declaration in ordinary section. %2","","","Declaración de Tipo Factory \"%1\" invalido en sección ordinaria. %2"},
            {SemanticErrorCode.InvalidTypeDeclarationInExtensionSection,"Invalid \"%1\" Type declaration in extension section. %2","","","Declaración del Tipo \"%1\" invalida en sección de extensión. %2"},
            {SemanticErrorCode.MissingSectionDeclaration,"Missing explicit section declaration. %1","","","Declaración de sección omitida. %1"},
            {SemanticErrorCode.InvalidNestedSectionDeclaration,"Invalid nested section declaration. %1","","","Declaración de sección anidada invalida. No se pueden declarar secciones anidadas. %1"},
            {SemanticErrorCode.DerivedTypeCannotBePointerAndArrayAtSameTime,"Dervied type can not be array and pointer at same time. %1","","","Un tipo derivado no puede ser puntero y matriz simultaneamente. %1"},
            {SemanticErrorCode.TypeNameRequiredOnTypeDeclaration,"A Typename is required on type declaration. %1","","","Se requiere un nombre de tipo en la declaración del tipo. %1"},
            {SemanticErrorCode.TypeRequired,"A type is required. %1","","","Se requiere un tipo. %1"},
            {SemanticErrorCode.FunctionBodyRequired,"A non-empty function body is required. %1","","","Se requiere un cuerpo de función no vacio. %1"},
            {SemanticErrorCode.AccesorRequired,"At least one accesor is required. %1","","","Por lo menos un bloque de acceso (get o set) es requerido. %1"},
            {SemanticErrorCode.DuplicatedAccesor,"Duplicated accesor declaration. %1","","","Declaración de bloque de acceso duplicada. %1"},
            {SemanticErrorCode.UnexpectedFunctionBody,"Unexpected function body. %1","","","Cuerpo de función inesperado. %1"},
            {SemanticErrorCode.UnexpectedStatement,"Unexpected statement. %1","","","Instrucción inesperada. %1"},
            {SemanticErrorCode.MemberCanNotBeAbstractAndFinal,"Member can not be declared both Abstract and Final. %1","","","El miembro no puede ser declarado abstracto y final simultaneamente."},
            {SemanticErrorCode.MemberCanNotBeAbstractAndNonVirtual,"Member can not be declared both Abstract and Non-Virtual. %1","","","El miembro no puede ser declarado abstracto y no virtual."},
            {SemanticErrorCode.MemberCanNotBeVirtualAndNonVirtual,"Member can not be declared both Virtual and Non-Virtual. %1","","","El miembro no puede ser declarado virtual y no virtual."},
            {SemanticErrorCode.MemberCanNotBeOverrideAndNonVirtual,"Member can not be declared both Override and Non-Virtual. %1","","","El miembro no puede ser declarado de sobre-escritura y no virtual simultaneamente."},
            {SemanticErrorCode.InvalidExecModifierInTypesOfNonfactoryMembers,"Invalid \"exec\" modifier in types of non-factory members. %1","","","Modificador \"exec\" invalido en miembros de tipos no factory."},
            {SemanticErrorCode.InvalidInameModifierInTypeOfNonfactoryMembers,"Invalid \"iname\" modifier in types of non-factory members. %1","","","Modificador \"iname\" invalido en miembros de tipos no factory."},
            {SemanticErrorCode.InvalidExpModifierInTypeOfNonfactoryMembers,"Invalid 'expression' modifier in types of non-factory members. %1","","","Modificador \"expression\" invalido en miembros de tipos no factory."},
            {SemanticErrorCode.BaseTypeExpectedOnDerivedTypeDefinition,"Base type expected on pointer or array derived type definition. %1","","","Se esperaba un \"tipo base\" en la definición del tipo derivado puntero o matriz. %1"},
            {SemanticErrorCode.InvalidMemberOverloadSignatureAlreadyExists,"Invalid member overload on '%1'. Member signature already have been defined. %2","","","Sobrecarga de miembro \"%1\" invalida. Ya existe otro miembro con la misma firma. %2"},
            {SemanticErrorCode.SymbolAlreadyDefinedInCurrentScope,"Symbol \"%1\" already defined in current scope. %2","","","El símbolo \"%1\" ya fue definido en el alcance actual."},
            {SemanticErrorCode.UnresolvedNameOnExpression,"Unresolved name \"%1\" on expression. %2","","","Nombre \"%1\" no resuelto en expresión. %2"},
            {SemanticErrorCode.InvalidLeftExpressionOnFunctionCallOperator,"Invalid left expression on function call operator. %1","","","Expresión izquierda invalida en llamada a función. %1"},
            {SemanticErrorCode.AmbiguousFunctionCall,"Ambiguous function call, explicit disambiguation required. %1","","","Llamada a función ambigua, se requiere desambiguar explícitamente. %1"},
            {SemanticErrorCode.InvalidMemberTypeUsedAsMethod,"Invalid member type used as method. You can not use \"%1\" member as a method. %2","","","Tipo de miembro invalido usado como metodo. No puede utilizar el miembro \"%1\" como metodo. %2"},
            {SemanticErrorCode.LValueRequiredAsLeftOperatorOfAssingment,"Variable or l-value required as left operator of an assingment expression. %1","","","Se requiere un l-value (valor asignable) como operador izquierdo en la expresión de asignación. %1"},
            {SemanticErrorCode.IncompatibleTypesForAssingment,"Incompatibles types for assingment. Type \"%1\" is not implicitly convertible to type \"%2\". %3","","","Tipos incopatibles para la asignación. El tipo \"%1\" no es implícitamente convertible al tipo \"%2\". %3"},
            {SemanticErrorCode.InvalidSimpleMemberAccessUsedAsScopeAccess ,"Invalid simple member access expression used as scope access. %1","","","Operador \".\" usado erroneamente como operador de alcance. %1"},
            {SemanticErrorCode.InvalidLeftExpressionOnSimpleMemberAccess ,"Invalid left expression on simple member access expression. %1","","","Expresión izquierda invalida en expresión de acceso a miembro. %1"},
            {SemanticErrorCode.ANameRequiredAsRightExpression,"A name is required as right expression. %1","","","Un nombre se requiere como expresión derecha. %1"},
            {SemanticErrorCode.ExpressionRequired,"An expression is required. %1","","","Una expresión es requerida. %1"},
            {SemanticErrorCode.InvalidUseOfRefModifierOnPointerTypeDeclaration,"Invalid use of \"ref\" modifier on pointer-type declaration. %1","","","Uso invalido del modificador \"ref\" en la declaración puntero. %1"},
            {SemanticErrorCode.InaccesibleType ,"The type '%1' is inaccesible in current context due to his access level. %2","","","El tipo \"%1\" es inaccesible en el alcance actual debido a su nivel de acceso. %2"},
            {SemanticErrorCode.InaccesibleTypeMember ,"Type member '%1' is inaccesible in current context due to his access level. %2","","","El miembro \"%1\" es inaccesible en el alcance actual debido a su nivel de acceso. %2"},
            {SemanticErrorCode.NonexistentMemberOfType,"The member '%1' was not found as member of type \"%2\". %3","","","El miembro \"%1\" no fue encontrado como miembro del tipo \"%2\". %3"},
            {SemanticErrorCode.CannotAccessInstanceMemberFromStatic,"Can not access instance member \"%1\" from static member. %2","","","No puede acceder a miembro de instancia \"%1\" desde un miembro estático. %2"},
            {SemanticErrorCode.CannotAccessStaticMemberUsingInstanceValue,"Can not access static member \"%1\" using an instance value. Use static member classname. %2","","","No se puede acceder al miembro estático \"%1\" usando un valor de instancia. Utilice el nombre de la clase más el nombre del miembro."},
            {SemanticErrorCode.AValueIsRequiredToInvoqueInstanceMember,"A value is required to invoque instance member \"%1\". %2","","","Se requiere un valor para invocar el miembro de instancia \"%1\". %2"},
            {SemanticErrorCode.ValueRequiredAsRightOperatorOfAssingment,"Variable or value required as right operand of an assingment expression. %1","","","Se requiere una variable o un valor como operando derecho de una expresión de asignación. %1"},
            {SemanticErrorCode.InvalidArgumentTypeForActualParameter,"Invalid argument type for parameter \"%1\". The type \"%2\" is not implicitly convertible to type \"%3\". %4","","","Tipo de argumento invalido para el parámetro \"%1\". El tipo \"%2\" no es implicitamente convertible al tipo \"%3\". %4"},
            {SemanticErrorCode.InvalidNumberOfArgumentsInFunctionCall,"Invalid number of arguments to invoke \"%1\" member. %2","","","Número de argumentos invalidos para invocar al miembro \"%1\". %2"},
            {SemanticErrorCode.NonexistentParameterNameInFunctionCall,"The parameter \"%1\" was not found on member \"%2\". %3","","","El parámetro \"%1\" no fue encontrado el miembro \"%2\". %3"},
            {SemanticErrorCode.NamedArgumentRequired,"Is required to name all arguments in a named arguments function call. %1","","","Debe nombrar todos los argumentos en una llamada a función con argumentos nombrados. %1"},
            {SemanticErrorCode.BestOverloadedFunctionHasSomeInvalidArguments,"The best overloaded function \"%1\" has some invalid arguments. %2","","","La mejor sobrecarga de la función \"%1\" tiene algunos argumentos inválidos. %2"},
            {SemanticErrorCode.InvalidLeftExpressionOnPointerMemberAccess,"Invalid left expression on pointer member access expression. A pointer value is required. %1","","","Expresión izquierda invalida en expresión de acceso a miembro de puntero. Se requiere un valor de puntero. %1"},
            {SemanticErrorCode.TypeNotAllowedAsLeftExpOnPointerMemberAccess,"Type is not allowed as left operand on pointer member access. A pointer value is required. %1","","","El tipo no es permitido como operando izquierdo en la expresión de acceso a miembro de puntero. Se requiere un valor de puntero. %1"},
            {SemanticErrorCode.MoreIndirectionsRequiredOnPointerMemberAccess,"More than one indirection required on left operand of pointer member access. Use the indirection operator first. %1","","","Más de una indirección requerida en operando izquierdo de acceso a miembro de puntero. Utilice primero el operador de indirección. %1"},
            {SemanticErrorCode.BinaryOperatorWasNotFoundForCurrentOperands,"Binary operator \"%1\" was not found for operands of type \"%2\" and \"%3\". %4","","","Operador binario \"%1\" no fue encontrado para operandos de tipo \"%2\" y \"%3\". %4"},
            {SemanticErrorCode.UnaryOperatorWasNotFoundForCurrentOperand,"Unary operator \"%1\" was not found for operand of type \"%2\". %3","","","Operador unario \"%1\" no fue encontrado para operando de tipo \"%2\". %3"},
            {SemanticErrorCode.InvalidNonStaticOperatorDeclaration,"Operator \"%1\" declared as non-static on class \"%2\". Use \"static\" declaration modificer. %3","","","Operador \"%1\" declarado como no estático en clase \"%2\". Utilice el modificador \"static\" en la declaración del operador. %3"},
            {SemanticErrorCode.InvalidNumberOfParameters,"Invalid number of parameters. %1","","","Número invalido de parámetros. %1"},
            {SemanticErrorCode.ValueOrLValueRequiredAsOperand,"A value or l-value is required as operand. %1","","","Se requiere un l-valor o un valor como operando. %1"},
            {SemanticErrorCode.InvalidPointerDereference,"Invalid Pointer dereference. %1","","","Dereferencia de puntero inválida. %1"},
            {SemanticErrorCode.LValueRequiredAsOperandOfAddressOfOperator,"A l-value is required as operand of address of \"&\" operator. %1","","",""},
            {SemanticErrorCode.InvalidLeftExpressionOfArrayAccessOperator,"Invalid left expression on array access operator. A value or l-value is required. %1","","",""},
            {SemanticErrorCode.InvalidArgumentsCountForArrayAccess,"Only one argument is allowed on array access expression. %1","","",""},
            {SemanticErrorCode.InvalidExpressionTypeForArrayAccess,"Only \"long\", \"int\" or implicitly convertible types are allowed on array access expression. %1","","",""},
            {SemanticErrorCode.IndexerWasNotFoundOnType,"Indexer was not found on type \"%1\". %2","","",""},
            {SemanticErrorCode.ValueRequiredOnBooleanExpression,"A Value is required on boolean expression. %1","","",""},
            {SemanticErrorCode.BooleanValueRequiredOnBooleanExpression,"A boolean Value is required on boolean expression. The type \"%1\" is not implicitly convertible to \"bool\". %2","","",""},
            {SemanticErrorCode.StatementRequired,"A statement is required. %1","","",""},
            {SemanticErrorCode.ReturnAValueIsRequired,"Return a value of type \"%1\" is required on return statement. %2","","",""},
            {SemanticErrorCode.ReturnAValueIsNotAllowed,"Return a value is not allowed. %1","","",""},
            {SemanticErrorCode.ValueRequiredOnReturnStatement,"A Value is required on return statement. %1","","",""},
            {SemanticErrorCode.TypeRequiredOnReturnStatement,"A Type is required on return statement. %1","","",""},
            {SemanticErrorCode.InvalidReturnStatementExpressionValue,"The type \"%1\" is not implicitly convertible to \"%2\" type. On return statement. %3","","",""},
            {SemanticErrorCode.InvalidUseOfBreakStatement,"Invalid use of \"break\" statement. %1","","","Uso invalido de la instrucción \"break\". %1"},
            {SemanticErrorCode.InvalidUseOfContinueStatement,"Invalid use of \"continue\" statement. %1","","","Uso invalido de la instrucción \"continue\". %1"},
            {SemanticErrorCode.InvalidUseOfResumeStatement,"Invalid use of \"resume\" statement. %1","","","Uso invalido de la instrucción \"resume\". %1"},
            {SemanticErrorCode.InvalidUseOfResumeNextStatement,"Invalid use of \"resume next\" statement. %1","","","Uso invalido de la instrucción \"resume next\". %1"},
            {SemanticErrorCode.ValueRequiredOnThrowStatementExpression,"Value required on throw statement. %1","","","Se requiere un valor en la instrucción throw. %1"},
            {SemanticErrorCode.ValueOfTypeExceptionRequiredOnThrowStatement,"Value of \"^Exception\" type, or implicitly convertible, is required on throw statement. %1","","","Un valor de tipo \"^Exception\", o convertible implicitamente, se requiere en la instrucción throw. %1"},
            {SemanticErrorCode.CatchOrFinallyBlockRequiredOnTryStatement,"Catch or Finally block is required on try statement. %1","","","Se requiere un bloque Catch o un bloque Finally en la instrucción Try. %1"},
            {SemanticErrorCode.CatchVariableMustBeOfTypeException,"Catch variable must be of type \"Exception\" or type implictly convertible. %1","","","La variable del bloque Catch debe ser de tipo \"Exception\" o de un tipo convertible implicitamente. %1"},
            {SemanticErrorCode.CatchVariableUndeclared,"Must declare a catch variable on Catch blocks. %1","","","Debe declarar una variable de captura en el bloque Catch. %1"},
            {SemanticErrorCode.InvalidWritecodeUseInNonFactoryMember,"Invalid use of Writecode expression on Non-Factory member. %1","","","Uso invalido de la expresión Writecode en un miembro no Factory. %1"},
            {SemanticErrorCode.InvalidSelectoutputUseInNonFactoryMember,"Invalid use of Selectoutput statement on Non-Factory member. %1","","","Uso invalido de la instrucción Selectoutput en un miembro no Factory. %1"},
            {SemanticErrorCode.InvalidGlobalCatch,"Use only one global catch for every Try-Catch statement. It must be the last catch block. %1","","","Catch global erroneo. Sólo puede definir un único bloque catch global por cada instrucción Try-Catch y debe ser el último bloque catch. %1"},
            {SemanticErrorCode.CaseElementRequiredOnSwitchStatement,"At least one case element is required on Switch statement. %1","","","Se requiere al menos un elemento case en la instrucción Switch. %1"},
            {SemanticErrorCode.InvalidTypeOfSwitchExpression,"Invalid type of switch expression, byte, short, int, long, char or string type is required. %1","","","Tipo invalido en la expresión switch. Se requiere un tipo byte, short, int, long, char o string. %1"},
            {SemanticErrorCode.DuplicatedDefaultCaseOnSwitchStatement,"Default case duplicated on switch statement. %1","","","Case por defecto duplicado en la instrucción Switch. %1"},
            {SemanticErrorCode.InvalidTypeOfCaseExpression,"Invalid type of case expression. The type \"%1\" is not implicitly convertible to type \"%2\". %3","","","Tipo de expresión case invalido. El tipo \"%1\" no es convertible al tipo \"%2\". %3"},
            {SemanticErrorCode.DuplicatedConstantCaseExpressionValue,"Duplicated value \"%1\" on switch statement. %2","","","Valor \"%1\" duplicado en instrucción switch. %2"},
            {SemanticErrorCode.ValueRequiredOnCaseExpression,"Value required on case expression. %1","","","Se requiere un valor en la expresión case. %1"},
            {SemanticErrorCode.ConstantExpressionRequiredOnCaseExpression,"A constant expression is required on case element. %1","","","Se requiere una expresión constante en el elemento case. %1"},
            {SemanticErrorCode.InvalidInstantiationOfAbstractType,"The type \"%1\" is abstract. Is not possible to instantiate abstract type. %2","","","El tipo \"%1\" es abstracto. No se puede instanciar un tipo abstracto. %2"},
            {SemanticErrorCode.InvalidTypeForNewExpression,"The type \"%1\" is invalid on new expression. %2","","","El tipo \"%1\" no es valido en una expresión new. %2"},
            {SemanticErrorCode.TypeForNewExpressionNotSupportedByCodeGenerator,"The type \"%1\" for new expression is not supported by code generator. %2","","","El tipo \"%1\" para la expresión new no es soportado por el generador de código. %2"},
            {SemanticErrorCode.InvalidInitializerForArrayType,"Invalid initializer for array type. %1","","","Inicializador invalido para el tipo de matriz. %1"},
            {SemanticErrorCode.ConstructorNotFoundForSuppliedArguments,"Constructor for type \"%1\" not found for supplied arguments. %2","","","Constructor para el tipo \"%1\" no encontrado para los argumentos proporcionados. %2"},
            {SemanticErrorCode.InvalidNativeTypeDeclaration,"Invalid Native type declaration, the native type \"%1\" does not exists. %2","","","Declaración de tipo nativo invalida, el tipo nativo \"%1\" no existe. %2"},
            {SemanticErrorCode.PointerinfoExpectedOnPointerTypeDeclaration,"Pointer info expected on pointer type declaration. %1","","","Se esperaba un pointer info en la declaración del tipo puntero. %1"},
            {SemanticErrorCode.ValueRequiredOnCastExpression,"A value is required on cast expression. %1","","","Se requiere un valor en la expresión de conversión explícita. %1"},
            {SemanticErrorCode.UndefinedExplicitConversion,"Undefined explícit conversion from type \"%1\" to type \"%2\". %3","","","Conversión explícita del tipo \"%1\" al tipo \"%2\" no definida. %3"},
            {SemanticErrorCode.UnexpectedArrayInitializer,"Unexpected array initializer. %1","","","Inicializador de Array inesperado. %1"},
            {SemanticErrorCode.ConstructorNotAvailableDueToItsProtectionLevel,"Constructor for type \"%1\" not available in current scope due to his protection level. %2","","","Constructor para el tipo \"%1\" no disponible en el alcance actual por su nivel de acceso. %2"},
            {SemanticErrorCode.ArrayInitializerRequired,"Array initializer required. %1","","","Se requiere un inicializador de Array. %1"},
            {SemanticErrorCode.BlockArgumentExpectedOnFunctionCall,"Block argument was expected on function call in \"%1\". %2","","","Se esperaba un bloque argumento en la llamada a función en \"%1\". %2"},
            {SemanticErrorCode.UnexpectedArgumentBlockOnFunctionCall,"Unexpected argument block on function call in \"%1\". %2","","","Bloque argumento inesperado en la llamada a función en \"%1\". %2"},
            {SemanticErrorCode.UnresolvedNameOnWritecodeExpression,"Unresolved name \"%1\" on writecode expression. %2","","","Nombre \"%1\" no resuelto en expresión writecode. %2"},
            {SemanticErrorCode.InvalidTypeReferencedOnWritecodeExpression,"Type \"%1\" invalid on writecode expression for \"%2\" symbol. %3","","","Tipo \"%1\" invalido en expresión writecode para el simbolo \"%2\". %3"},
            {SemanticErrorCode.ValueRequiredForNamesOnWritecodeExpression,"The name \"%1\" is required to be a value on writecode expression. %2","","","El nombre \"%1\" se requiere sea un valor en la expresion writecode. %2"},
            {SemanticErrorCode.ValidExpressionRequiredOnForeach,"A valid array or collection expression is required on foreach statement. %1","","","Se requiere un expresión de array o colección valida en la instrucción foreach. %1"},
            {SemanticErrorCode.ArrayOrCollectionExpressionRequiredOnForeach,"An array or collection value is required on foreach statement. %1","","","Se requiere un valor de tipo matriz o colección en la instrucción foreach. %1"},
            {SemanticErrorCode.AdecuateConversionDoesnotExistsOnForeach,"Adecuate conversión from type \"%1\" to type \"%2\" doesn't exists on foreach statement. %3","","","No existe una conversión adecuada del tipo \"%1\" al tipo \"%2\" en la instrucción foreach. %3"},
            {SemanticErrorCode.VariableDeclarationRequiredOnForeach,"A variable declaration is required on foreach statement. %1","","","Se requiere una declaración de variable en la instrucción foreach. %1"},
            {SemanticErrorCode.TypeRequiredOnIsExpression,"A type is required on \"is\" expression. %1","","","Se requiere un tipo en la expresion \"is\". %1"},
            {SemanticErrorCode.ValueRequiredOnIsExpression,"A value is required on \"is\" expression. %1","","","Se requiere un valor en la expresión \"is\". %1"},
            {SemanticErrorCode.WritecodeExpressionEmpty,"Invalid writecode expression empty. %1","","","Expresión writecode vacia invalida. %1"},
            {SemanticErrorCode.InvalidEmptyExpressionNode,"Invalid empty expression node. Check that high level LayerD compiler Zoe generation is correct. %1","","","Nodo expresion vacio invalido. Controle que el compilador de alto nivel LayerD genere correctamente el código Zoe. %1"},
            {SemanticErrorCode.InterfaceMemberNotImplemented,"Member \"%1\" of \"%2\" interface not implemented. %3","","","Miembro \"%1\" de la interfaz \"%2\" no implementado. %3"},
            {SemanticErrorCode.InvalidFieldAsMemberOfInterface,"Field \"%1\" invalid as member of interface type \"%2\". %3","","","Campo \"%1\" invalido como miembro de la interfaz \"%2\". %3"},
            {SemanticErrorCode.InvalidAbstractMemberOnNonAbstractType,"Invalid abstract member of non abstract type \"%1\". %2","","","Miembro abstracto invalido como miembro de tipo no abstracto \"%1\". %2"},
            {SemanticErrorCode.BooleanTernaryOperatorRequireValues,"Boolean ternary operator requires return expression to be values. %1","","","Operador booleano requiere valores como expresiones de retorno. %1"},
            {SemanticErrorCode.UnsupportedTernaryOperator,"Ternary operator unsupported. %1","","","Operador ternario no soportado. %1"},
            {SemanticErrorCode.IncompatibleTypesOnBooleanTernaryOperator,"Incompatible types on boolean operator. Types must be the same or implicit convertible. %1","","","Tipos incompatibles en operador booleano. Los tipos deben ser iguales o implicitamente convertibles. %1"},
            {SemanticErrorCode.IncompatibleTypesForAssignmentInInitialization,"Incompatible types for assignment in initialization. Type \"%1\" is not implicitly convertible to \"%2\". %3","","","Tipos incompatibles para la asignación en la inicialización. Los tipos \"%1\" y \"%2\" no son implicitamente convertibles. %3"},
            {SemanticErrorCode.CustomExplicitConversionOperationAlreadyDefined,"Custom explicit conversion from type \"%1\" to type \"%2\" already defined in type \"%3\". %4","","","Conversion explicita del tipo \"%1\" al tipo \"%2\" ya definida en el tipo \"%3\". %4"},
            {SemanticErrorCode.CustomImplicitConversionOperationAlreadyDefined,"Custom implicit conversion from type \"%1\" to type \"%2\" already defined in type \"%3\". %4","","","Conversion implicita del tipo \"%1\" al tipo \"%2\" ya definida en el tipo \"%3\". %4"},
            {SemanticErrorCode.PointerTypesCannotBeCompared,"Pointer types \"%1\" and \"%2\" can not be compared. Try casting one pointer. %3","","","Pointer types \"%1\" and \"%2\" can not be compared. Try casting one pointer. %3"},

            
            //Fin Errores Reales

            {SemanticErrorCode.LastSemanticError,"ErrorMsg","ErrorUrl","ErrorHelp","LocaleMsg"},
        };

        public static string get_ErrorMsg(SemanticErrorCode errorCode)
        {
            return (string)Errors[(int)errorCode - offset, 1];
        }
        public static string get_ErrorUrl(SemanticErrorCode errorCode)
        {
            return (string)Errors[(int)errorCode - offset, 2];
        }
        public static string get_ErrorHelp(SemanticErrorCode errorCode)
        {
            return (string)Errors[(int)errorCode - offset, 3];
        }
        public static string get_ErrorLocale(SemanticErrorCode errorCode)
        {
            return (string)Errors[(int)errorCode - offset, 4];
        }
    }
    public class SemanticError
    {
        public static Error New(SemanticErrorCode errorCode, XplNode sourceNode, params string[] Params)
        {
            string errorMsg = SemanticErrorsList.get_ErrorMsg(errorCode);
            string errorUrl = SemanticErrorsList.get_ErrorUrl(errorCode);
            string errorHelp = SemanticErrorsList.get_ErrorHelp(errorCode);
            string errorLocale = SemanticErrorsList.get_ErrorLocale(errorCode);
            int n = 1;
            foreach (string param in Params)
            {
                errorMsg = errorMsg.Replace("%" + n, param);
                if (errorLocale != "") errorLocale = errorLocale.Replace("%" + n, param);
                n++;
            }
            if (n < 10) for (; n < 11; n++)
                {
                    errorMsg = errorMsg.Replace("%" + n, "");
                    if (errorLocale != "") errorLocale = errorLocale.Replace("%" + n, "");
                }
            errorMsg = ErrorUtils.AdaptErrorMessage(errorMsg);
            errorLocale = ErrorUtils.AdaptErrorMessage(errorLocale);
            Error retError = new Error(errorMsg, errorLocale);
            retError.set_ErrorCode("Z" + Convert.ToString((int)errorCode, CultureInfo.InvariantCulture));
            retError.set_ErrorNode(sourceNode);
            retError.set_UrlErrorDescription(errorUrl);
            retError.set_UrlErrorHelp(errorHelp);
            retError.set_ErrorType(ErrorType.SemanticError);
            retError.set_ErrorLayerDSourceFileData(ErrorUtils.ConvertSourceFileData(sourceNode.FullSourceFileInfo));
            return retError;
        }
    }
    #endregion

    class ErrorUtils
    {
        public static string AdaptErrorMessage(string error)
        {
            error = error.Replace("$BOOLEAN$", "bool");

            error = error.Replace("$BYTE$", "byte");
            error = error.Replace("$SHORT$", "short");
            error = error.Replace("$INTEGER$", "int");
            error = error.Replace("$LONG$", "long");

            error = error.Replace("$SBYTE$", "byte");
            error = error.Replace("$USHORT$", "ushort");
            error = error.Replace("$UNSIGNED$", "unsigned");
            error = error.Replace("$ULONG$", "ulong");

            error = error.Replace("$FLOAT$", "float");
            error = error.Replace("$DOUBLE$", "double");
            error = error.Replace("$LDOUBLE$", "ldouble");
            error = error.Replace("$DECIMAL$", "decimal");

            error = error.Replace("$CHAR$", "char");
            error = error.Replace("$ASCIICHAR$", "ASCIIChar");
            error = error.Replace("$STRING$", "string");
            error = error.Replace("$ASCIISTRING$", "ASCIIString");
            error = error.Replace("$OBJECT$", "object");
            error = error.Replace("$DATETIME$", "zoe.lang.DateTime");
            error = error.Replace("$DATE$", "zoe.lang.DateTime");
            error = error.Replace("$VOID$", "void");
            error = error.Replace("$TYPE$", "type");
            error = error.Replace("$BLOCK$", "block");

            error = error.Replace("$CHAR_LIT$", "char");
            error = error.Replace("$ASCIICHAR_LIT$", "ASCIIChar");
            error = error.Replace("$STRING_LIT$", "string");
            error = error.Replace("$ASCIISTRING_LIT$", "ASCIIString");

            error = error.Replace("$NULL$", "null");
            error = error.Replace("$NONE$", "");
            
            error = error.Replace("^c", "^const ");
            error = error.Replace("^v", "^volatile ");
            error = error.Replace("^w", "^const volatile ");
            error = error.Replace("^_", "^");

            error = error.Replace("*c", "*const ");
            error = error.Replace("*v", "*volatile ");
            error = error.Replace("*w", "*const volatile ");
            error = error.Replace("*_", "*");
            return error;
        }
        public static string ConvertSourceFileData(string str)
        {
            if (str == null || str == String.Empty) return "No File Data";
            string[] parts = str.Split(new char[] { ',' });
            if (parts.Length == 3)
                str = parts[2] + "(" + parts[0] + ")";
            else if (parts.Length == 5)
                str = parts[4] + "(" + parts[0] + "," + parts[1] + ")";
            return str;
        }
    }

    #region Warnings Semánticos
    /// <summary>
    /// Indices para la Tabla de Warnings Semanticos, tener en cuenta
    /// lo siguiente:
    /// 
    /// El código 1000 es solo una plantilla, los errores semánticos
    /// deben codificarse desde el código 1001 hasta el 1999.
    /// </summary>
    public enum SemanticWarningCode
    {
        FirstSemanticWarning = 1000,
        //Aquí los Códigos de Warning

        UnspecifiedSemanticWarning                              = 1001,
        NewModifierRequiredOnMemberDeclaration                  = 1002,
        UnsafeConversionFromPointerToGenericVoidPointer         = 1003,
        ExplicitCastUnnecessaryTargetTypeSameAsSource           = 1004,

        //Fin de los Códigos de Warning
        LastSemanticWarning = 2000,
    }
    public class SemanticWarningsList
    {
        private const int offset = 1000;
        /// <summary>
        /// Tabla de Warnings Semanticos, utilizar el formato indicado y tener en cuenta
        /// lo siguiente:
        /// 
        /// Para los "placement" utilizar "%1", "%2", ... "%5".
        /// 
        /// El mensaje de error debe ser en ingles y el mensaje local en 
        /// Castellano o el idioma nativo del compilador.
        /// </summary>
        static object[,] Warnings =
        {
            ///Warning Code   | WarningMsg  | WarningUrl  | WarningHelp | LocaleMsg
            {SemanticWarningCode.FirstSemanticWarning,"ErrorMsg","ErrorUrl","ErrorHelp","LocaleMsg"},

            //Inicio Warnings Reales
            {SemanticWarningCode.UnspecifiedSemanticWarning,"Unspecified warning. %1","","",""},
            {SemanticWarningCode.NewModifierRequiredOnMemberDeclaration,"Member \"%1\" hides inherited member \"%2\". Set \"new\" atributte on member declaration. %3","","",""},
            {SemanticWarningCode.UnsafeConversionFromPointerToGenericVoidPointer,"Unsafe conversion from '%1' to generic 'void*' pointer. %2","","","Conversión no segura de puntero '%1' a puntero generico 'void*'."},
            {SemanticWarningCode.ExplicitCastUnnecessaryTargetTypeSameAsSource,"Explicit cast unnecessary. Source type same as target type. %1","","","Conversion explicita innecesaria. El tipo de origen es igual al tipo de destino. %1"},
            //Fin Warnings Reales

            {SemanticWarningCode.LastSemanticWarning,"ErrorMsg","ErrorUrl","ErrorHelp","LocaleMsg"},
        };

        public static string get_WarningMsg(SemanticWarningCode errorCode)
        {
            return (string)Warnings[(int)errorCode - offset, 1];
        }
        public static string get_WarningUrl(SemanticWarningCode errorCode)
        {
            return (string)Warnings[(int)errorCode - offset, 2];
        }
        public static string get_WarningHelp(SemanticWarningCode errorCode)
        {
            return (string)Warnings[(int)errorCode - offset, 3];
        }
        public static string get_WarningLocale(SemanticWarningCode errorCode)
        {
            return (string)Warnings[(int)errorCode - offset, 4];
        }
    }
    public class SemanticWarning
    {
        public static Warning New(SemanticWarningCode warningCode, XplNode sourceNode, params string[] Params)
        {
            string errorMsg = SemanticWarningsList.get_WarningMsg(warningCode);
            string errorUrl = SemanticWarningsList.get_WarningUrl(warningCode);
            string errorHelp = SemanticWarningsList.get_WarningHelp(warningCode);
            string errorLocale = SemanticWarningsList.get_WarningLocale(warningCode);
            int n = 1;
            foreach (string param in Params)
            {
                errorMsg = errorMsg.Replace("%" + n, param);
                n++;
            }
            if (n < 10) for (; n < 11; n++)
                {
                    errorMsg = errorMsg.Replace("%" + n, "");
                    if (errorLocale != "") errorLocale = errorLocale.Replace("%" + n, "");
                }
            errorMsg = ErrorUtils.AdaptErrorMessage(errorMsg);
            errorLocale = ErrorUtils.AdaptErrorMessage(errorLocale);

            Warning retError = new Warning(errorMsg, errorLocale, sourceNode);
            retError.set_ErrorCode("ZW" + Convert.ToString((int)warningCode, CultureInfo.InvariantCulture));
            retError.set_ErrorNode(sourceNode);
            retError.set_UrlErrorDescription(errorUrl);
            retError.set_UrlErrorHelp(errorHelp);
            retError.set_ErrorType(ErrorType.SemanticError);
            return retError;
        }
    }
    #endregion

    #region Errores Sintacticos
    /// <summary>
    /// Indices para la Tabla de Errores Sintacticos, tener en cuenta
    /// lo siguiente:
    /// 
    /// El código 500 es solo una plantilla, los errores sintacticos
    /// deben codificarse desde el código 501 hasta el 599.
    /// </summary>
    public enum SyntaxErrorCode
    {
        FirstSyntaxError = 500,
        //Aquí los Códigos de Error

        UnspecifiedSyntaxError = 501,
        InvalidSimpleNameSeparator = 502,
        InvalidMixOfSimpleNameSeparators = 503,
        IncompleteTernaryOperator = 504,

        //Fin de los Códigos de Error
        LastSyntaxError = 599,
    }
    class SyntaxErrorsList
    {
        private const int offset = 500;
        /// <summary>
        /// Tabla de Errores Sintacticos, utilizar el formato indicado y tener en cuenta
        /// lo siguiente:
        /// 
        /// Para los "placement" utilizar "%1", "%2", ... "%5".
        /// 
        /// El código 500 es solo una plantilla, los errores semánticos
        /// deben codificarse desde el código 501 hasta el 599.
        /// 
        /// El mensaje de error debe ser en ingles y el mensaje local en 
        /// Castellano o el idioma nativo del compilador.
        /// </summary>
        static object[,] Errors =
        {
            ///Error Code   | ErrorMsg  | ErrorUrl  | ErrorHelp | LocaleMsg
            {SyntaxErrorCode.FirstSyntaxError,"ErrorMsg","ErrorUrl","ErrorHelp","LocaleMsg"},

            //Inicio Errores Reales
            {SyntaxErrorCode.UnspecifiedSyntaxError,"Unspecified Syntax Error.%1","","",""},
            {SyntaxErrorCode.InvalidSimpleNameSeparator,"Invalid simple name separator in qualified name. Valid simple name separators are '::', '.:' and '.'.","","",""},
            {SyntaxErrorCode.InvalidMixOfSimpleNameSeparators,"Invalid mix of simple name separators. Do not mix diferent simple name separators in a qualified name.","","",""},
            {SyntaxErrorCode.IncompleteTernaryOperator,"Incomplete ternary operator.%1","","",""},
            //Fin Errores Reales

            {SyntaxErrorCode.LastSyntaxError,"ErrorMsg","ErrorUrl","ErrorHelp","LocaleMsg"},
        };

        public static string get_ErrorMsg(SyntaxErrorCode errorCode)
        {
            return (string)Errors[(int)errorCode - offset, 1];
        }
        public static string get_ErrorUrl(SyntaxErrorCode errorCode)
        {
            return (string)Errors[(int)errorCode - offset, 2];
        }
        public static string get_ErrorHelp(SyntaxErrorCode errorCode)
        {
            return (string)Errors[(int)errorCode - offset, 3];
        }
        public static string get_ErrorLocale(SyntaxErrorCode errorCode)
        {
            return (string)Errors[(int)errorCode - offset, 4];
        }
    }
    public class SyntaxError
    {
        public static Error New(SyntaxErrorCode errorCode, XplNode sourceNode, params string[] Params)
        {
            string errorMsg = SyntaxErrorsList.get_ErrorMsg(errorCode);
            string errorUrl = SyntaxErrorsList.get_ErrorUrl(errorCode);
            string errorHelp = SyntaxErrorsList.get_ErrorHelp(errorCode);
            string errorLocale = SyntaxErrorsList.get_ErrorLocale(errorCode);
            int n = 1;
            foreach (string param in Params)
            {
                errorMsg = errorMsg.Replace("%" + n, param);
                n++;
            }
            if (n < 10) for (; n < 11; n++) errorMsg = errorMsg.Replace("%" + n, "");
            Error retError = new Error(errorMsg, errorLocale);
            retError.set_ErrorCode("Z" + Convert.ToString((int)errorCode, CultureInfo.InvariantCulture));
            retError.set_ErrorNode(sourceNode);
            retError.set_UrlErrorDescription(errorUrl);
            retError.set_UrlErrorHelp(errorHelp);
            retError.set_ErrorType(ErrorType.SyntaxError);
            return retError;
        }
    }
    #endregion

    #region Errores Lexicos
    /// <summary>
    /// Indices para la Tabla de Errores Lexicos, tener en cuenta
    /// lo siguiente:
    /// 
    /// El código 400 es solo una plantilla, los errores sintacticos
    /// deben codificarse desde el código 401 hasta el 499.
    /// </summary>
    public enum LexicalErrorCode
    {
        FirstLexicalError = 400,
        //Aquí los Códigos de Error

        UnspecifiedLexicalError = 401,
        InvalidIdentifierName = 402,
        InvalidIntegerConstant = 403,
        InvalidFloatConstant = 404,
        InvalidDecimalConstant = 405,
        InvalidCharConstant = 406,
        InvalidStringConstant = 407,
        InvalidBooleanConstant = 408,
        InvalidDateTimeConstant = 409,

        //Fin de los Códigos de Error
        LastLexicalError = 499,
    }
    class LexicalErrorsList
    {
        private const int offset = 400;
        /// <summary>
        /// Tabla de Errores Lexicos, utilizar el formato indicado y tener en cuenta
        /// lo siguiente:
        /// 
        /// Para los "placement" utilizar "%1", "%2", ... "%5".
        /// 
        /// El código 400 es solo una plantilla, los errores semánticos
        /// deben codificarse desde el código 401 hasta el 499.
        /// 
        /// El mensaje de error debe ser en ingles y el mensaje local en 
        /// Castellano o el idioma nativo del compilador.
        /// </summary>
        static object[,] Errors =
        {
            ///Error Code   | ErrorMsg  | ErrorUrl  | ErrorHelp | LocaleMsg
            {LexicalErrorCode.FirstLexicalError,"ErrorMsg","ErrorUrl","ErrorHelp","LocaleMsg"},

            //Inicio Errores Reales
            {LexicalErrorCode.UnspecifiedLexicalError,"Unspecified Lexical Error. %1","","",""},
            {LexicalErrorCode.InvalidIdentifierName,"Invalid identifier name. %1","","",""},
            {LexicalErrorCode.InvalidIntegerConstant,"Invalid constant \"%1\".","","",""},
            {LexicalErrorCode.InvalidFloatConstant,"Invalid constant \"%1\".","","",""},
            {LexicalErrorCode.InvalidDecimalConstant,"Invalid constant \"%1\".","","",""},
            {LexicalErrorCode.InvalidCharConstant,"Invalid constant \"%1\".","","",""},
            {LexicalErrorCode.InvalidStringConstant,"Invalid constant \"%1\".","","",""},
            {LexicalErrorCode.InvalidBooleanConstant,"Invalid constant \"%1\".","","",""},
            {LexicalErrorCode.InvalidDateTimeConstant,"Invalid constant \"%1\".","","",""},
            //Fin Errores Reales

            {LexicalErrorCode.LastLexicalError,"ErrorMsg","ErrorUrl","ErrorHelp","LocaleMsg"},
        };

        public static string get_ErrorMsg(LexicalErrorCode errorCode)
        {
            return (string)Errors[(int)errorCode - offset, 1];
        }
        public static string get_ErrorUrl(LexicalErrorCode errorCode)
        {
            return (string)Errors[(int)errorCode - offset, 2];
        }
        public static string get_ErrorHelp(LexicalErrorCode errorCode)
        {
            return (string)Errors[(int)errorCode - offset, 3];
        }
        public static string get_ErrorLocale(LexicalErrorCode errorCode)
        {
            return (string)Errors[(int)errorCode - offset, 4];
        }
    }
    public class LexicalError
    {
        public static Error New(LexicalErrorCode errorCode, XplNode sourceNode, params string[] Params)
        {
            string errorMsg = LexicalErrorsList.get_ErrorMsg(errorCode);
            string errorUrl = LexicalErrorsList.get_ErrorUrl(errorCode);
            string errorHelp = LexicalErrorsList.get_ErrorHelp(errorCode);
            string errorLocale = LexicalErrorsList.get_ErrorLocale(errorCode);
            int n = 1;
            foreach (string param in Params)
            {
                errorMsg = errorMsg.Replace("%" + n, param);
                if (errorLocale != "") errorLocale = errorLocale.Replace("%" + n, param);
                n++;
            }
            if (n < 10) for (; n < 11; n++)
                {
                    errorMsg = errorMsg.Replace("%" + n, "");
                    if (errorLocale != "") errorLocale = errorLocale.Replace("%" + n, "");
                }
            errorMsg = ErrorUtils.AdaptErrorMessage(errorMsg);
            errorLocale = ErrorUtils.AdaptErrorMessage(errorLocale);
            Error retError = new Error(errorMsg, errorLocale);
            retError.set_ErrorCode("Z" + Convert.ToString((int)errorCode, CultureInfo.InvariantCulture));
            retError.set_ErrorNode(sourceNode);
            retError.set_UrlErrorDescription(errorUrl);
            retError.set_UrlErrorHelp(errorHelp);            
            retError.set_ErrorType(ErrorType.LexicalError);
            retError.set_ErrorLayerDSourceFileData(ErrorUtils.ConvertSourceFileData(sourceNode.FullSourceFileInfo));
            return retError;
        }
    }
    #endregion

}
