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
    partial class SemanticAnalizer
    {
        #region Process para Instrucciones
        private void ProcessBlock(XplFunctionBody xplFunctionBody, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            currentScope.EnterScope(ScopeType.Block, null);
            EnterCandidateStructuresScope(xplFunctionBody);
            XplNodeList nodeList = xplFunctionBody.Children();
            foreach (XplNode node in nodeList)
                switch (node.get_ElementName())
                {
                    case "label":
                        ProcessLabelStatement(node, classType, currentScope, memberInfo);
                        break;
                    case "setonerror":
                        ProcessSetonerrorStatement((XplSetonerror)node, classType, currentScope, memberInfo);
                        break;
                    case "Decls":
                        ProcessDeclsStatement((XplDeclaratorlist)node, classType, currentScope, memberInfo);
                        break;
                    case "e":
                        ProcessExpression((XplExpression)node, currentScope, classType, memberInfo, SemanticAction.CheckImplementation);
                        break;
                    case "switch":
                        ProcessSwitchStatement((XplSwitchStatement)node, classType, currentScope, memberInfo);
                        break;
                    case "if":
                        ProcessIfStatement((XplIfStatement)node, classType, currentScope, memberInfo);
                        break;
                    case "for":
                        ProcessForStatement((XplForStatement)node, classType, currentScope, memberInfo);
                        break;
                    case "do":
                    case "while":
                        ProcessDoStatement((XplDowhileStatement)node, classType, currentScope, memberInfo);
                        break;
                    case "bk":
                        ProcessBlock((XplFunctionBody)node, classType, currentScope, memberInfo);
                        break;
                    case "Get":
                    case "Set":

                        XplFunctionBody body = (XplFunctionBody)node;
                        if (node.get_ElementName() == "Set" && !memberInfo.get_IsBadMember())
                            CreateValueSymbol(body, memberInfo.get_ReturnType(), memberInfo, currentScope);
                        if (!memberInfo.IsStatic())
                            CreateThisSymbol(body, classType, currentScope);
                        ProcessBlock(body, classType, currentScope, memberInfo);
                        break;

                    case "onpointer":
                        ProcessOnpointerStatement((XplFunctionBody)node, classType, currentScope, memberInfo);
                        break;
                    case "try":
                        ProcessTryStatement((XplTryStatement)node, classType, currentScope, memberInfo);
                        break;
                    case "throw":
                        ProcessThrowStatement((XplExpression)node, classType, currentScope, memberInfo);
                        break;
                    case "return":
                        ProcessReturnStatement((XplExpression)node, classType, currentScope, memberInfo);
                        break;
                    case "jump":
                        ProcessJumpStatement((XplJump)node, classType, currentScope, memberInfo);
                        break;
                    case "directoutput":
                        ProcessDirectOutputStatement((XplDirectoutput)node, classType, currentScope, memberInfo);
                        break;
                    case "documentation":
                        break;
                    case "selectoutput":
                        ProcessSelectOutputStatement((XplFunctioncall)node, classType, currentScope, memberInfo);
                        break;
                    case "BeginCFPermisions":
                        break;
                    case "EndCFPermisions":
                        break;
                    default:
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.UnexpectedNode, node, "Unrecognized statement node.")
                            );
                        break;
                }
            LeaveCandidateStructuresScope(xplFunctionBody);
            currentScope.LeaveScope();
        }

        private void ProcessSelectOutputStatement(XplFunctioncall xplFunctioncall, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            if (!memberInfo.IsFactory() && !classType.get_IsFactory())
            {
                AddNewError(SemanticError.New(
                    SemanticErrorCode.InvalidSelectoutputUseInNonFactoryMember, xplFunctioncall));
                return;
            }
            //PENDIENTE : instrucción "Selectoutput"
        }
        private void ProcessDirectOutputStatement(XplDirectoutput xplDirectoutput, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            //Esta instrucción esta destinada a pasar información directamente
            //al modulo de salida, por tanto no se requiere comprobar nada!
        }
        private void ProcessJumpStatement(XplJump xplJump, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            switch (xplJump.get_type())
            {
                //Debo chequear me encuentre dentro de un ciclo.
                case XplJumptype_enum.BREAK:
                    //PENDIENTE : controlar que un break no salga fuera de un bloque finally, lo cual es un 
                    //error como en: do(true){ try{}finally{break;} }
                    if (!currentScope.get_IsOnBucleStatement())
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.InvalidUseOfBreakStatement,
                            xplJump, " Break must be used inside do, while, for loops or switchs only."));
                    break;
                case XplJumptype_enum.CONTINUE:
                    if (!currentScope.get_IsOnBucleStatement())
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.InvalidUseOfContinueStatement,
                            xplJump, " Continue must be used inside do, while or for loops only."));
                    break;
                //Debo chequear exista actualmente una declaración de control de
                //error previa en la rutina actual, de lo contrario es un error.
                case XplJumptype_enum.RESUME:
                    //PENDIENTE : controlar el resume y resume next, emitir los errores
                    //de uso invalido para cada una de de estas instrucciones, errores
                    //que ya estan definidos.
                    break;
                case XplJumptype_enum.RESUMENEXT:
                    break;
                //PENDIENTE : Debo chequear que exista el label definido en la rutina, puede
                //estar definido despues de la aparición del goto.
                case XplJumptype_enum.GOTO:
                    break;
                default:
                    break;
            }
        }
        private void ProcessReturnStatement(XplExpression xplExpression, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            //1°) Si posee una expresion no vacia la proceso para obtener el tipo.
            //2°) Si el tipo de la expresion no vacia es diferente al tipo de retorno del miembro,
            //o al tipo de puntero a la clase para constructores es un error.
            ExpressionResult expRes = xplExpression.get_Content() != null ? ProcessExpression(xplExpression, currentScope, classType, memberInfo) : null;
            string memberRetType = memberInfo.get_ReturnType() != null ? memberInfo.get_ReturnType().get_typeStr() : "";
            XplFactorytype_enum retTypeFT = XplFactorytype_enum.NONE;
            if (memberInfo.get_ReturnType() != null)
            {
                retTypeFT = memberInfo.get_ReturnType().get_ftype();
            }

            if (memberInfo.IsConstructor() && memberRetType == "")
                memberRetType = !classType.get_IsStruct() ? TypeString.MakePointerTypeTo(classType.get_FullName()) : classType.get_FullName();

            if (expRes == null && xplExpression.get_Content() == null)
            {
                //Es un "return;"
                if (memberRetType != "" && !NativeTypes.IsNativeVoid(memberRetType) ||
                    memberRetType != "" && NativeTypes.IsNativeVoid(memberRetType) &&
                    memberInfo.get_ReturnType().get_ftype() != XplFactorytype_enum.NONE)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.ReturnAValueIsRequired,
                        xplExpression, memberRetType));
                    return;
                }
            }
            else if (expRes != null && xplExpression.get_Content() != null)
            {
                //Es un "return EXPRESSION;"
                if (memberRetType != "" && NativeTypes.IsNativeVoid(memberRetType) &&
                    memberInfo.get_ReturnType().get_ftype() == XplFactorytype_enum.NONE &&
                    !currentScope.IsInsideFunctionCallBlockArgument())
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.ReturnAValueIsNotAllowed,
                        xplExpression));
                    return;
                }
                //Si no se pudo obtener el tipo de retorno del metodo fue un error en el la declaración
                //del metodo, salgo pero no emito un error.
                if (String.IsNullOrEmpty(memberRetType))
                    return;

                if (currentScope.IsInsideFunctionCallBlockArgument())
                {
                    // TODO : check types for return inside "closures"
                    return;
                }

                if (expRes == null)
                    //PENDIENTE : ¿Cuando la expresion de un return no se pudo evaluar, 
                    //deberia emitir un error también en la instrucción?
                    return;

                ExpressionResultType expType = expRes.get_ExpType();
                if (expType == ExpressionResultType.TypeMembers ||
                    expType == ExpressionResultType.TypeMembersFromValue)
                    expRes = TryConvertTypeMembersToValueOrLValue(expRes, currentScope, xplExpression.get_Content());
                expType = expRes.get_ExpType();
                if (expType != ExpressionResultType.Value &&
                    expType != ExpressionResultType.ValueOrLValue)
                {
                    if (!NativeTypes.IsNativeType(memberRetType) || expType != ExpressionResultType.Type)
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.ValueRequiredOnReturnStatement,
                            xplExpression));
                }
                if (NativeTypes.IsNativeType(memberRetType) && expType != ExpressionResultType.Type)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.TypeRequiredOnReturnStatement,
                        xplExpression));
                    return;
                }
                if (expType == ExpressionResultType.Value
                    || expType == ExpressionResultType.ValueOrLValue)
                {
                    string expTypeStr = expRes.get_TypeStr();
                    if (!IsSameStringType(memberRetType, expTypeStr))
                    {
                        CheckReturnStatementValueConversion(xplExpression, currentScope, memberRetType, retTypeFT, expTypeStr);
                    }
                }
            }
        }

        private void CheckReturnStatementValueConversion(XplExpression xplExpression, Scope currentScope, string memberRetType, XplFactorytype_enum retTypeFT, string expTypeStr)
        {
            ConversionData cdata = ExistsImplicitConversion(expTypeStr, memberRetType, xplExpression, currentScope);
            if (cdata == null)
            {
                //Primero debo chequear si el tipo de retorno es un tipo factory y si en cuyo 
                //caso existe una conversion explicita al tipo factory
                if (retTypeFT != XplFactorytype_enum.NONE)
                {
                    string retTypeFTStr = memberRetType;
                    switch (retTypeFT)
                    {
                        case XplFactorytype_enum.NONE:
                            break;
                        case XplFactorytype_enum.INAME:
                            retTypeFTStr = TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".IName");
                            break;
                        case XplFactorytype_enum.EXPRESSION:
                            retTypeFTStr = TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplExpression");
                            break;
                        case XplFactorytype_enum.EXPRESSIONLIST:
                            retTypeFTStr = TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplExpressionlist");
                            break;
                        case XplFactorytype_enum.STATEMENT:
                            retTypeFTStr = TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplFunctionBody");
                            break;
                        default:
                            break;
                    }
                    if (!IsSameStringType(retTypeFTStr, expTypeStr))
                    {
                        cdata = ExistsImplicitConversion(expTypeStr, retTypeFTStr, xplExpression, currentScope);
                        if (cdata == null)
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.InvalidReturnStatementExpressionValue,
                                xplExpression, expTypeStr, memberRetType));
                        }
                        else
                        {
                            MarkConversion(cdata, expTypeStr, retTypeFTStr, xplExpression, currentScope);
                        }
                    }
                }
                else
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidReturnStatementExpressionValue,
                        xplExpression, expTypeStr, memberRetType));
                }
            }
            else
            {
                MarkConversion(cdata, expTypeStr, memberRetType, xplExpression, currentScope);
            }
        }
        private void ProcessThrowStatement(XplExpression xplExpression, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            //Chequear que la expresión sea un valor y sea de un tipo valido a lanzar.
            if (xplExpression.get_Content() == null)
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.ExpressionRequired,
                    xplExpression, " On throw statement."));
                return;
            }
            ExpressionResult expRes = ProcessExpression(xplExpression, currentScope, classType, memberInfo);
            if (expRes != null)
            {
                if (expRes.get_IsTypeMembers())
                    expRes = TryConvertTypeMembersToValueOrLValue(expRes, currentScope, xplExpression.get_Content());
                if (!expRes.get_IsValue())
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.ValueRequiredOnThrowStatementExpression,
                        xplExpression));
                    return;
                }
                string typeStr = expRes.get_TypeStr();
                if (!NativeTypes.IsExceptionType(typeStr))
                {
                    // PENDIENTE : Comprobar si el modulo de salida de tiempo de ejecución
                    // permite lanzar excepciones que no deriven de "Exception" y si permite
                    // lanzar valores directamente.
                    string targetType = TypeString.MakePointerTypeTo(NativeTypes.ExceptionClassTypeName);
                    //verifico que typeStr no sea una referencia en lugar de un puntero ordinario
                    if (TypeString.IsReferencePointerType(typeStr) && IsSameStringType(typeStr, targetType)) return;
                    ConversionData cdata = ExistsImplicitConversion(typeStr, targetType, xplExpression, currentScope);
                    if (cdata == null)
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.ValueOfTypeExceptionRequiredOnThrowStatement,
                            xplExpression, " The type '" + typeStr + "' is not natively implicit convertible to type '" + targetType + "'."));
                    else
                        MarkConversion(cdata, typeStr, targetType, xplExpression, currentScope);
                }
            }
        }
        private void ProcessTryStatement(XplTryStatement xplTryStatement, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            //PENDIENTE : Controlar que si el modulo de salida soporta excepciones por terminación y
            //si permite mezclar ambos modelos de excepciones en un único miembro.
            //Proceso el bloque try;
            XplFunctionBody block = xplTryStatement.get_trybk();
            if (block == null)
                AddNewError(
                    SemanticError.New(SemanticErrorCode.StatementRequired,
                    xplTryStatement, "On try statement."));
            ProcessBlock(block, classType, currentScope, memberInfo);
            //Luego los bloques catch
            bool requireFinallyOrCatch = false;
            XplNodeList catchs = xplTryStatement.get_catchbk();
            if (catchs != null)
            {
                bool defaultCatch = false, scopeUsed = false; ;
                foreach (XplCatchStatement catchSta in catchs)
                {
                    scopeUsed = false;
                    //Verifico la declaración de variable
                    XplCatchinit catchInit = catchSta.get_init();
                    if (catchInit != null && catchInit.get_Content() != null)
                    {
                        if (catchInit.get_Content().get_ElementName() == "d")
                        {
                            //PEDIENTE : Chequear que el tipo declarado no sea una clase abstracta
                            //ni una interface, en todo caso si puede ser un puntero a una clase abstracta
                            //o una interface.
                            XplDeclarator decl = (XplDeclarator)catchInit.get_Content();
                            int backErrorCount = p_errorCollection.Count;
                            CheckType(decl.get_type(), decl, currentScope, classType.get_IsFactory() || memberInfo.IsFactory(), "On catch statement.");
                            CheckForTypeConstructorCallOrSymbol(decl.get_type(), currentScope, decl.get_name());

                            if (backErrorCount == p_errorCollection.Count)
                                if (CheckValidIdentifier(decl.get_name(), decl, " On catch statement."))
                                {
                                    //PENDIENTE : Controlar que el tipo de la variable catch sea derivada
                                    //de ^_Exception cuando así lo requiere el modulo de salida.
                                    scopeUsed = true;
                                    currentScope.EnterScope(ScopeType.Block, null);
                                    Symbol newSymbol = new Symbol(decl, decl.get_name());
                                    if (!currentScope.InsertSymbol(newSymbol))
                                    {
                                        AddNewError(
                                            SemanticError.New(SemanticErrorCode.SymbolAlreadyDefinedInCurrentScope,
                                            decl, decl.get_name(), " On Catch statement."));
                                    }
                                }
                        }
                        else
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.UnspecifiedSemanticError, catchInit,
                                "Expression used in catch block is not supported by ZOE compiler."));
                    }
                    else
                    {
                        if (defaultCatch)
                            AddNewError(SemanticError.New(SemanticErrorCode.InvalidGlobalCatch, catchSta));
                        else
                            defaultCatch = true;
                    }
                    //Proceso el bloque catch
                    block = catchSta.get_bk();
                    if (block == null)
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.StatementRequired,
                            xplTryStatement, "On catch statement."));
                    else
                    {
                        ProcessBlock(block, classType, currentScope, memberInfo);
                        if (scopeUsed) currentScope.LeaveScope();
                    }
                }
            }
            else
                requireFinallyOrCatch = true;
            //Finalmente el bloque finally
            block = xplTryStatement.get_finallybk();
            if (block != null) ProcessBlock(block, classType, currentScope, memberInfo);
            else if (requireFinallyOrCatch) AddNewError(
                SemanticError.New(SemanticErrorCode.CatchOrFinallyBlockRequiredOnTryStatement,
                xplTryStatement));
        }
        private void ProcessOnpointerStatement(XplFunctionBody xplFunctionBody, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            currentScope.set_IsOnPointerScope(true);
            ProcessBlock(xplFunctionBody, classType, currentScope, memberInfo);
            currentScope.set_IsOnPointerScope(false);
        }
        private void ProcessDoStatement(XplDowhileStatement xplDowhileStatement, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            //1°) Compruebo que la expresión sea de tipo valor bool.
            CheckForBoolExpression(xplDowhileStatement.get_boolean(), currentScope, classType, memberInfo, "On do/while statement.", xplDowhileStatement);
            //2°) Proceso el bloque
            XplFunctionBody block = xplDowhileStatement.get_dobk();
            if (block == null)
                AddNewError(
                    SemanticError.New(SemanticErrorCode.StatementRequired,
                    xplDowhileStatement, "On do/while statement."));

            bool flag = currentScope.get_IsOnBucleStatement();
            currentScope.set_IsOnBucleStatement(true);
            ProcessBlock(block, classType, currentScope, memberInfo);
            if (!flag) currentScope.set_IsOnBucleStatement(false);
        }
        private void ProcessForStatement(XplForStatement xplForStatement, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            //1) Check for initialization statement
            XplForinit init = xplForStatement.get_init();
            currentScope.EnterScope(ScopeType.Block, null);
            if (init != null && init.get_Content().get_ElementName() == "dl")
            {
                // declarators list
                XplDeclaratorlist dl = (XplDeclaratorlist)init.get_Content();
                ProcessDeclsStatement(dl, classType, currentScope, memberInfo);
            }
            else if (init != null && init.get_Content().get_ElementName() == "el")
            {
                // expression list
                XplExpressionlist el = (XplExpressionlist)init.get_Content();
                ProcessExpressionList(el, currentScope, classType, memberInfo);
            }

            //2) Check repeat expression
            bool isForEach = false;
            XplExpressionlist repeat = xplForStatement.get_repeat();
            if (repeat != null)
            {
                XplNode tempNode = null;
                if (repeat.Children().GetLength() == 1 && (tempNode = repeat.Children().GetNodeAt(0).get_Content()) != null && tempNode.get_StringValue() == "_FOR_EACH_")
                {
                    isForEach = true;
                }
                else
                {
                    ProcessExpressionList(xplForStatement.get_repeat(), currentScope, classType, memberInfo);
                }
            }

            //3) Check boolean expression
            XplExpression conditionExp = xplForStatement.get_condition();
            if (conditionExp != null)
            {
                if (isForEach)
                {
                    XplNode initContent = init == null ? null : init.get_Content();
                    // Foreach cycle
                    // TODO : this check was removed, but in some platforms like .NET
                    // you need that iteration variable to be declared in the for statement
                    //
                    //if (init == null || initContent == null || initContent.get_ElementName() != "dl" ||
                    //    initContent.get_ElementName() == "dl" && initContent.Children().GetLength() != 1)
                    //{
                    //    AddNewError(
                    //        SemanticError.New(SemanticErrorCode.VariableDeclarationRequiredOnForeach,
                    //        xplForStatement));
                    //}
                    //else
                    //{

                    ExpressionResult condExpRes = ProcessExpression(conditionExp, currentScope, classType, memberInfo);
                    if (condExpRes == null)
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.ValidExpressionRequiredOnForeach,
                            conditionExp));
                    }
                    else
                    {
                        //Debo chequear que la expresión sea un valor y de un tipo adecuado
                        if (!condExpRes.get_IsValue() && condExpRes.get_IsTypeMembers())
                            condExpRes = TryConvertTypeMembersToValueOrLValue(condExpRes, currentScope, conditionExp.get_Content());
                        if (!condExpRes.get_IsValue())
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.ArrayOrCollectionExpressionRequiredOnForeach,
                                conditionExp));
                        }
                        else
                        {
                            string iterationVarTypeStr = null;
                            if (initContent.IsA(CodeDOMTypes.XplDeclaratorlist))
                            {
                                XplDeclarator iterationDeclarator = (XplDeclarator)initContent.Children().FirstNode();
                                iterationVarTypeStr = iterationDeclarator.get_type().get_typeStr();
                            }
                            else
                            {
                                iterationVarTypeStr = (initContent.Children().FirstNode() as XplExpression).get_typeStr();
                            }
                            CheckValidTypeForForeachCollection(iterationVarTypeStr, condExpRes, conditionExp, currentScope);
                        }
                    }

                    //}
                }
                else
                {
                    //Ciclo for común
                    CheckForBoolExpression(conditionExp, currentScope, classType, memberInfo, "On for/foreach block.", xplForStatement);
                }
            }
            //4) Proceso el bloque
            XplFunctionBody block = xplForStatement.get_forblock();
            if (block == null)
                AddNewError(
                    SemanticError.New(SemanticErrorCode.StatementRequired,
                    xplForStatement, "On for/foreach statement."));

            bool flag = currentScope.get_IsOnBucleStatement();
            currentScope.set_IsOnBucleStatement(true);
            ProcessBlock(block, classType, currentScope, memberInfo);
            if (!flag) currentScope.set_IsOnBucleStatement(false);
            currentScope.LeaveScope();
        }
        private void CheckValidTypeForForeachCollection(string declaratorTypeStr, ExpressionResult condExpRes, XplExpression conditionExp, Scope currentScope)
        {
            // Check that collection expression is an array or iterable collection type
            string condExpTypeStr = condExpRes.get_TypeStr();
            string elementTypeStr = null;
            bool flagError = false;
            if (condExpTypeStr == null || condExpTypeStr == "")
            {
                flagError = true;
            }
            else
            {
                if (TypeString.IsArrayType(condExpTypeStr))
                {
                    elementTypeStr = TypeString.RemoveArrayTypeFromType(condExpTypeStr);
                }
                else if (TypeString.IsPointerType(condExpTypeStr) && TypeString.IsPointerToArrayType(condExpTypeStr))
                {
                    elementTypeStr = TypeString.RemoveArrayTypeFromType(TypeString.RemovePointerIndirectionsFromType(condExpTypeStr, 1));
                }
                else
                {
                    // TODO : Check that it must be a valid collection type
                }
            }
            if (flagError)
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.ArrayOrCollectionExpressionRequiredOnForeach,
                    conditionExp));
            }

            // Check that type of items from collection to be iterated are the same or convertible to the type of iteration variable
            if (declaratorTypeStr != null && declaratorTypeStr != "" && elementTypeStr != null)
            {
                if (!IsSameStringType(elementTypeStr, declaratorTypeStr))
                    if (ExistsExplicitConversion(elementTypeStr, declaratorTypeStr, null, currentScope) == null)
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.AdecuateConversionDoesnotExistsOnForeach,
                            conditionExp, elementTypeStr, declaratorTypeStr));
                    }
            }
        }

        private void ProcessIfStatement(XplIfStatement xplIfStatement, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            //1°) Compruebo que la expresión sea de tipo valor bool.
            CheckForBoolExpression(xplIfStatement.get_boolean(), currentScope, classType, memberInfo, "On if statement.", xplIfStatement);
            //2°) Proceso los bloques anidados.
            XplFunctionBody block = xplIfStatement.get_ifbk();
            if (block == null)
                AddNewError(
                    SemanticError.New(SemanticErrorCode.StatementRequired,
                    xplIfStatement, "On if statement."));
            ProcessBlock(block, classType, currentScope, memberInfo);
            XplNodeList list = xplIfStatement.get_elseif();
            if (list != null)
                foreach (XplIfStatement elseSta in list)
                    ProcessIfStatement(elseSta, classType, currentScope, memberInfo);
            block = xplIfStatement.get_else();
            if (block != null) ProcessBlock(block, classType, currentScope, memberInfo);
        }
        private void ProcessSwitchStatement(XplSwitchStatement xplSwitchStatement, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            XplExpression switchExp = xplSwitchStatement.get_e();
            ExpressionResult switchExpRes = null;
            if (switchExp == null)
                AddNewError(
                    SemanticError.New(SemanticErrorCode.ExpressionRequired, xplSwitchStatement, " Expression of type byte, short, int, long, char or string is required on Switch statement."));
            else
                switchExpRes = ProcessExpression(switchExp, currentScope, classType, memberInfo);
            string switchExpResStr = switchExpRes == null ? null : switchExpRes.get_TypeStr();
            if (switchExpResStr != null)
            {
                //Si pude obtener el tipo de la expresión switch compruebo el tipo sea valido:
                //byte, short, int, long, char, string, ASCIIString, sbyte, 
                //ushort, uint, ulong, char, *string, *ASCIIString
                #region Control y Conversion Implicita del tipo de la Expresion Switch
                switch (switchExpResStr)
                {
                    case NativeTypes.Byte:
                    case NativeTypes.SByte:
                    case NativeTypes.Short:
                    case NativeTypes.UShort:
                    case NativeTypes.Integer:
                    case NativeTypes.Unsigned:
                    case NativeTypes.Long:
                    case NativeTypes.ULong:
                    case NativeTypes.Char:
                    case NativeTypes.ASCIIChar:
                    case NativeTypes.String:
                    case NativeTypes.ASCIIString:
                        break;
                    default:
                        // Si es un tipo enumeracion
                        TypeInfo switchTypeInfo = (TypeInfo)p_types[switchExpResStr];
                        if (switchTypeInfo != null && switchTypeInfo.get_IsEnum())
                        {
                            break;
                        }
                        // Si es tipo string o convertible implicitamente a un tipo entero o un tipo string
                        if (!IsSameStringType(TypeString.MakePointerTypeTo(NativeTypes.String), switchExpResStr) &&
                            !IsSameStringType(TypeString.MakePointerTypeTo(NativeTypes.ASCIIString), switchExpResStr))
                        {
                            //Aqui debo intentar convertir a alguno de los tipos validos
                            string toTypeStr = null;
                            ConversionData cdata = null;
                            cdata = ExistsImplicitConversion(switchExpResStr, toTypeStr = NativeTypes.Byte, switchExp, currentScope);
                            if (cdata == null)
                                cdata = ExistsImplicitConversion(switchExpResStr, toTypeStr = NativeTypes.SByte, switchExp, currentScope);
                            if (cdata == null)
                                cdata = ExistsImplicitConversion(switchExpResStr, toTypeStr = NativeTypes.Short, switchExp, currentScope);
                            if (cdata == null)
                                cdata = ExistsImplicitConversion(switchExpResStr, toTypeStr = NativeTypes.UShort, switchExp, currentScope);
                            if (cdata == null)
                                cdata = ExistsImplicitConversion(switchExpResStr, toTypeStr = NativeTypes.Integer, switchExp, currentScope);
                            if (cdata == null)
                                cdata = ExistsImplicitConversion(switchExpResStr, toTypeStr = NativeTypes.Unsigned, switchExp, currentScope);
                            if (cdata == null)
                                cdata = ExistsImplicitConversion(switchExpResStr, toTypeStr = NativeTypes.Long, switchExp, currentScope);
                            if (cdata == null)
                                cdata = ExistsImplicitConversion(switchExpResStr, toTypeStr = NativeTypes.ULong, switchExp, currentScope);
                            if (cdata == null)
                                cdata = ExistsImplicitConversion(switchExpResStr, toTypeStr = NativeTypes.Char, switchExp, currentScope);
                            if (cdata == null)
                                cdata = ExistsImplicitConversion(switchExpResStr, toTypeStr = NativeTypes.ASCIIChar, switchExp, currentScope);
                            if (cdata == null)
                                cdata = ExistsImplicitConversion(switchExpResStr, toTypeStr = NativeTypes.String, switchExp, currentScope);
                            if (cdata == null)
                                cdata = ExistsImplicitConversion(switchExpResStr, toTypeStr = NativeTypes.ASCIIString, switchExp, currentScope);
                            if (cdata == null)
                                cdata = ExistsImplicitConversion(switchExpResStr, toTypeStr = TypeString.MakePointerTypeTo(NativeTypes.String), switchExp, currentScope);
                            if (cdata == null)
                                cdata = ExistsImplicitConversion(switchExpResStr, toTypeStr = TypeString.MakePointerTypeTo(NativeTypes.ASCIIString), switchExp, currentScope);
                            if (cdata == null)
                                AddNewError(
                                    SemanticError.New(SemanticErrorCode.InvalidTypeOfSwitchExpression, switchExp));
                            else
                                MarkConversion(cdata, switchExpResStr, toTypeStr, switchExp, currentScope);
                        }
                        break;
                }
                #endregion
            }
            XplNodeList list = xplSwitchStatement.get_case();
            if (list == null || list.GetLength() < 1)
                AddNewError(SemanticError.New(SemanticErrorCode.CaseElementRequiredOnSwitchStatement, xplSwitchStatement));
            else
            {
                bool defaultCase = false;
                foreach (XplCase caseOp in list)
                {
                    XplExpression caseExp = caseOp.get_e();
                    ExpressionResult caseRes = null;
                    if (caseExp == null || caseExp.get_Content() == null || caseExp.get_Content().get_ElementName() == "empty")
                    {
                        if (defaultCase) AddNewError(SemanticError.New(SemanticErrorCode.DuplicatedDefaultCaseOnSwitchStatement, caseOp));
                        else defaultCase = true;
                    }
                    else caseRes = ProcessExpression(caseExp, currentScope, classType, memberInfo);
                    if (switchExpResStr != null && caseRes != null)
                    {
                        string caseExpResStr = null;
                        //Evaluo que la expresión del case sea de un tipo valido.
                        if (!caseRes.get_IsValue())
                            caseRes = TryConvertTypeMembersToValueOrLValue(caseRes, currentScope, caseExp.get_Content());
                        if (!caseRes.get_IsValue())
                            AddNewError(SemanticError.New(SemanticErrorCode.ValueRequiredOnCaseExpression, caseExp));
                        else
                        {
                            //PENDIENTE : detectar constantes duplicadas en el switch, emitir
                            //error cuando la expresión no es constante, estos errores ya estan
                            //agregados a la tabla de errores!!.
                            caseExpResStr = caseRes.get_TypeStr();
                            if (!IsSameStringType(switchExpResStr, caseExpResStr))
                            {
                                ConversionData cdata = ExistsImplicitConversion(caseExpResStr, switchExpResStr, caseExp, currentScope);
                                if (cdata == null)
                                    AddNewError(SemanticError.New(SemanticErrorCode.InvalidTypeOfCaseExpression, caseExp,
                                        caseExpResStr, switchExpResStr));
                                else
                                    MarkConversion(cdata, caseExpResStr, switchExpResStr, caseExp, currentScope);
                            }
                        }
                    }
                    //PENDIENTE : levantar alguna bandera en el alcance que permita la utilización
                    //del break pero no del continue.
                    if (caseOp.get_bk() != null)
                    {
                        bool flag = currentScope.get_IsOnBucleStatement();
                        currentScope.set_IsOnBucleStatement(true); //<-- Esto ESTA MAL, es temporal hasta corregir como dice lo pendiente!
                        ProcessBlock(caseOp.get_bk(), classType, currentScope, memberInfo);
                        if (!flag) currentScope.set_IsOnBucleStatement(false);
                    }
                }
            }
        }
        private void ProcessDeclsStatement(XplDeclaratorlist xplDeclaratorlist, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            XplNodeList declList = xplDeclaratorlist.Children();
            foreach (XplDeclarator decl in declList)
            {
                //PEDIENTE : Chequear que el tipo declarado no sea una clase abstracta
                //ni una interface, en todo caso si puede ser un puntero a una clase abstracta
                //o una interface.
                string errorStr = "On Declaration of local variable '" + decl.get_name() + "'.";
                int backErrorCount = p_errorCollection.Count;
                CheckType(decl.get_type(), decl, currentScope, classType.get_IsFactory() || memberInfo.IsFactory(), errorStr);
                CheckForTypeConstructorCallOrSymbol(decl.get_type(), currentScope, decl.get_name());
                if (CheckValidIdentifier(decl.get_name(), decl, " On local variable declaration."))
                {
                    Symbol newSymbol = new Symbol(decl, decl.get_name());

                    if (backErrorCount > p_errorCollection.Count) newSymbol.set_IsBadSymbol(true);

                    if (!currentScope.InsertSymbol(newSymbol))
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.SymbolAlreadyDefinedInCurrentScope,
                            decl, decl.get_name()));
                    }
                    //Tengo que chequear el inicializador si existe
                    if (decl.get_i() != null) CheckInitializer(decl, classType, memberInfo, currentScope);
                }
            }
        }
        private void ProcessSetonerrorStatement(XplSetonerror xplSetonerror, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            //PENDIENTE : Chequear instrucción "Set on error"
        }
        private void ProcessLabelStatement(XplNode node, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            //PENDIENTE: Etiquetas!!
        }
        private void CheckExpressionsOnInitializer(XplNodeList list, Scope scope, TypeInfo classType, MemberInfo memberInfo)
        {
            if (list == null) return;
            foreach (XplNode e in list)
                if (e.get_TypeName() == CodeDOMTypes.XplExpression)
                {
                    ExpressionResult result = ProcessExpression((XplExpression)e, scope, classType, memberInfo);
                    if (result != null && !result.get_IsValue())
                    {
                        TryConvertTypeMembersToValueOrLValue(result, scope, e.get_Content());
                    }
                }
                else
                {
                    CheckExpressionsOnInitializer(e.Children(), scope, classType, memberInfo);
                }
        }
        private void CheckInitializer(XplNewExpression xplNewExpression, Scope scope, TypeInfo classType, MemberInfo memberInfo)
        {
            XplInitializerList init = xplNewExpression.get_init();
            if (init != null && !init.get_array())
            {
                AddNewError(SemanticError.New(SemanticErrorCode.ArrayInitializerRequired,
                    init, "On new expression."));
                return;
            }
            else if (init != null && init.get_array())
            {
                CheckExpressionsOnInitializer(init.Children(), scope, classType, memberInfo);
                // TODO check items are convertible to array items type
            }
        }
        private void CheckInitializer(XplDeclarator decl, TypeInfo classType, MemberInfo memberInfo, Scope currentScope)
        {
            //TODO complete this method
            XplInitializerList list = decl.get_i();
            if (list == null) return;

            CheckExpressionsOnInitializer(list.Children(), currentScope, classType, memberInfo);

            string requiredTypeStr = decl.get_type().get_typeStr();
            // if typestr is null or empty it means unresolved type for declarator; can't check initialization correctness
            if(String.IsNullOrEmpty(requiredTypeStr)) return;

            if (list.get_array())
            {
                if (TypeString.IsPointerToArrayType(requiredTypeStr)) requiredTypeStr = TypeString.RemovePointerIndirectionsFromType(requiredTypeStr, 1);
                if (TypeString.IsArrayType(requiredTypeStr)) requiredTypeStr = TypeString.RemoveArrayTypeFromType(requiredTypeStr);
                // TODO check array
            }
            else{
                // check if type is the same than declaration
                XplExpression initExp = list.Children().FirstNode() as XplExpression;
                if (initExp != null)
                {
                    string currentTypeStr = initExp.get_typeStr();
                    if (!String.IsNullOrEmpty(currentTypeStr) && !IsSameStringType(currentTypeStr, requiredTypeStr))
                    {
                        var conversionResult = ExistsImplicitConversion(currentTypeStr, requiredTypeStr, initExp, currentScope);
                        if (conversionResult == null)
                        {
                            AddNewError(SemanticError.New(SemanticErrorCode.IncompatibleTypesForAssignmentInInitialization,
                                list, currentTypeStr, requiredTypeStr, "In function \"" + decl.CurrentFunction.get_name() + "\" of class \"" + classType.get_FullName() + "\"."));
                        }
                        else
                        {
                            // TODO mark implicit conversion in zoe
                        }
                    }
                }
                else
                {
                    // TODO consider when it isn't a simple initialization
                }
            }

        }
        private void CheckInitializer(XplField decl, TypeInfo classType, Scope currentScope, MemberInfo memberInfo)
        {
            //PENDIENTE : Chequear las expresiones de inicialización.
            //ESTO Q ESTA HECHO ESTA MAL, SOLO PROCESA LAS EXPRESIONES SIMPLES DE 
            //INICIALIZACIÓN Y NO CHEQUEA QUE EL TIPO SEA CONVERTIBLE A LA VARIABLE
            XplInitializerList list = decl.get_i();
            if (list != null)
            {
                CheckExpressionsOnInitializer(list.Children(), currentScope, classType, memberInfo);
            }
        }
        private void CheckInitializer(XplParameter parameter, TypeInfo classType, MemberInfo memberInfo, Scope currentScope)
        {
            //PENDIENTE : Chequear las expresiones de inicialización.
            //ESTO Q ESTA HECHO ESTA MAL, SOLO PROCESA LAS EXPRESIONES SIMPLES DE 
            //INICIALIZACIÓN Y NO CHEQUEA QUE EL TIPO SEA CONVERTIBLE AL PARAMETRO
            XplInitializerList list = parameter.get_i();
            if (list != null)
            {
                CheckExpressionsOnInitializer(list.Children(), currentScope, classType, memberInfo);
            }
        }
        #endregion
    }
}
