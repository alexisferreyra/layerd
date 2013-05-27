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
        const string ZOE_INVALID_IDENTIFIER = "_____zoe__invalid__identifier_____";
        Hashtable p_intrinsicClosureTypes = new Hashtable();

        #region Process para Expresiones
        /// <summary>
        /// Llama a "ProcessExpression" por cada expresión 
        /// en la lista, si la lista es nula retorna.
        /// </summary>
        private void ProcessExpressionList(XplExpressionlist el, Scope currentScope, TypeInfo classType, MemberInfo memberInfo)
        {
            if (el.Children() == null) return;
            XplNodeList list = el.Children();
            foreach (XplExpression exp in list)
                ProcessExpression(exp, currentScope, classType, memberInfo);
        }
        private void CheckForBoolExpression(XplExpression boolExp, Scope currentScope, TypeInfo classType, MemberInfo memberInfo, string errorStr, XplNode statementNode)
        {
            if (boolExp == null)
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.ExpressionRequired,
                    statementNode, errorStr));
            }
            else
            {
                ExpressionResult boolExpRes = ProcessExpression(boolExp, currentScope, classType, memberInfo);
                if (boolExpRes == null) return;
                if (boolExpRes.get_IsTypeMembers())
                {
                    boolExpRes = TryConvertTypeMembersToValueOrLValue(boolExpRes, currentScope, boolExp.get_Content());
                }
                if (!boolExpRes.get_IsValue() || boolExpRes.get_TypeStr() == null)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.ValueRequiredOnBooleanExpression,
                        boolExp, errorStr));
                }
                else
                {
                    string expTypeStr = boolExpRes.get_TypeStr();
                    if (!NativeTypes.IsNativeBoolean(expTypeStr))
                    {
                        ConversionData cdata = ExistsImplicitConversion(expTypeStr, NativeTypes.Boolean, boolExp, currentScope);
                        if (cdata == null)
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.BooleanValueRequiredOnBooleanExpression,
                                boolExp, expTypeStr, errorStr));
                        else
                            MarkConversion(cdata, expTypeStr, NativeTypes.Boolean, boolExp, currentScope);
                    }
                }
            }
        }
        private ExpressionResult ProcessExpression(XplExpression xplExpression, Scope currentScope, TypeInfo classType, MemberInfo memberInfo)
        {
            return ProcessExpression(xplExpression, currentScope, classType, memberInfo, SemanticAction.CheckImplementation);
        }
        private ExpressionResult ProcessExpression(XplExpression xplExpression, Scope currentScope, TypeInfo classType, MemberInfo memberInfo, SemanticAction semanticAction)
        {
            //Primero chequeo que sea una expresion en el cuerpo del programa o
            //miembro de un espacio de nombres.
            bool isProgramBodyOrNamespace = false;
            if (!currentScope.IsBlock()) isProgramBodyOrNamespace = true;
            //else if (scope. types.get_TypeInfo(scope.get_FullClassName()).get_IsNamespace()) isProgramBodyOrNamespace = true;

            if (isProgramBodyOrNamespace && semanticAction == SemanticAction.ReadTypes)
            {
                //Si es una expresion en el cuerpo del programa o miembro de un espacio de nombres
                //debo chequear que exista una seccion actual valida o emitir un error
                if (p_currentSection == null)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.MissingSectionDeclaration, xplExpression));
                    //Debo marcar que faltan secciones
                    CorrectMissingSection();
                }
            }
            //Debe procesar expresiones simples y llamadas a classfactorys dentro
            //de cuerpos de espacios de nombres, tipos y dentro de la unidad de traduccion.
            else if (semanticAction == SemanticAction.CheckImplementation)
            {
                XplNode exp = xplExpression.get_Content();
                if (exp == null)
                {
                    AddNewError(SemanticError.New(SemanticErrorCode.InvalidEmptyExpressionNode, xplExpression));
                    return null;
                }
                ExpressionResult expResult = null;
                switch (exp.get_ElementName())
                {
                    case "a":       //Asignacion
                        expResult = ProcessAssingExpression((XplAssing)exp, currentScope, classType, memberInfo);
                        break;
                    case "new":     //new
                        expResult = ProcessNewExpression((XplNewExpression)exp, currentScope, classType, memberInfo);
                        break;
                    case "bo":      //Operador Binario
                        expResult = ProcessBinaryOperatorExpression((XplBinaryoperator)exp, currentScope, classType, memberInfo);
                        break;
                    case "to":      //Operador Binario
                        expResult = ProcessTernaryOperatorExpression((XplTernaryoperator)exp, currentScope, classType, memberInfo);
                        break;
                    case "uo":      //Operador Unario
                        expResult = ProcessUnaryOperatorExpression((XplUnaryoperator)exp, currentScope, classType, memberInfo);
                        break;
                    case "b":       //Llamada a funcion con []
                        expResult = ProcessBracketExpression((XplFunctioncall)exp, currentScope, classType, memberInfo);
                        break;
                    case "n":       //Simple expression, nombre
                        expResult = ProcessSimpleNameExpression((XplNode)exp, currentScope);
                        break;
                    case "lit":     //literal
                        expResult = ProcessLiteralExpression((XplLiteral)exp, currentScope);
                        break;
                    case "fc":      //Llamada a funcion con ()
                        expResult = ProcessFunctioncallExpression((XplFunctioncall)exp, currentScope, classType, memberInfo);
                        break;
                    case "cfc":     //Llamada a funcion compleja
                        expResult = ProcessComplexFunctioncallExpression((XplComplexfunctioncall)exp, currentScope, classType, memberInfo);
                        break;
                    case "cast":    //cast
                        expResult = ProcessCastExpression((XplCastexpression)exp, currentScope, classType, memberInfo);
                        break;
                    case "delete":  //delete
                        expResult = ProcessDeleteExpression((XplExpression)exp, currentScope);
                        break;
                    case "onpointer":   //onpointer
                        expResult = ProcessOnpointerExpression((XplExpression)exp, currentScope, classType, memberInfo);
                        break;
                    case "empty":       //empty
                        break;
                    case "t":       //gettype(type)
                        expResult = ProcessGetTypeExpression((XplType)exp, currentScope);
                        break;
                    case "toft":    //typeof(type)
                        expResult = ProcessTypeOfExpression((XplType)exp, currentScope);
                        break;
                    case "is":      //exp IS type
                        expResult = ProcessIsExpression((XplCastexpression)exp, currentScope, classType, memberInfo);
                        break;
                    case "sizeof":
                        expResult = ProcessSizeofExpression((XplType)exp, currentScope);
                        break;
                    case "writecode":
                        expResult = ProcessWritecodeExpression((XplWriteCodeBody)exp, currentScope);
                        break;
                    default:
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.UnexpectedNode, xplExpression, "Unrecognized expression node.")
                            );
                        break;
                }
                if (expResult != null)
                {
                    if (expResult.get_IsValue() || expResult.get_IsLValue())
                    {
                        // remove references
                        if (!currentScope.get_IsOnPointerScope() && TypeString.IsReferencePointerType(expResult.get_TypeStr()))
                            expResult.set_TypeStr(TypeString.RemoveReferencesFromType(expResult.get_TypeStr(), TypeString.RemoveReferenciesType.SimpleExpression));
                        xplExpression.set_typeStr(expResult.get_TypeStr());
                        // save constant value on expression node
                        if (expResult.get_IsConstant())
                        {
                            xplExpression.set_valueStr(expResult.get_ConstantValueAsString());
                        }
                    }
                    else if (expResult.get_IsTypeMembers())
                    {
                        var members = expResult.get_Members();
                        var retType = members[0].get_ReturnType();
                        var expTypeStr = retType != null ? retType.get_typeStr() : String.Empty;
                        xplExpression.set_typeStr(expTypeStr);
                    }
                    else
                    {
                        xplExpression.set_typeStr(String.Empty);
                    }
                }
                return expResult;
            }
            return null;
        }

        private ExpressionResult ProcessSizeofExpression(XplType xplType, Scope currentScope)
        {
            ExpressionResult res = null;
            int backErrorCount = p_errorCollection.Count;
            CheckType(xplType, xplType, currentScope, true, "On \"sizeof\" expression.");

            if (backErrorCount == p_errorCollection.Count)
            {
                // build return result
                res = new ExpressionResult(NativeTypes.Integer);
                // check for type constructors
                CheckForTypeConstructorCallOrSymbol(xplType, currentScope, null);
            }
            else
            {
                res = null;
            }
 
            return res;
        }

        private ExpressionResult ProcessTernaryOperatorExpression(XplTernaryoperator xplTernaryoperator, Scope currentScope, TypeInfo classType, MemberInfo memberInfo)
        {
            if (xplTernaryoperator.get_o1() == null || xplTernaryoperator.get_o2() == null || xplTernaryoperator.get_o3() == null)
            {
                // error on ternary operator syntactic construction
                AddNewError(SyntaxError.New(SyntaxErrorCode.IncompleteTernaryOperator, xplTernaryoperator));
                return null;
            }
            if (xplTernaryoperator.get_op() == XplTernaryoperators_enum.BOOLEAN)
            {
                CheckForBoolExpression(
                    xplTernaryoperator.get_o1(),
                    currentScope,
                    classType,
                    memberInfo,
                    "First expression of ternary operator must be a boolean value.",
                    xplTernaryoperator.get_o1());

                // evaluate second and third operands
                ExpressionResult o2Res = ProcessExpression(xplTernaryoperator.get_o2(), currentScope, classType, memberInfo);
                ExpressionResult o3Res = ProcessExpression(xplTernaryoperator.get_o3(), currentScope, classType, memberInfo);
                // check that both operands are values and have the same type or implicit convertible type
                if (o2Res == null || o3Res == null)
                {
                    AddNewError(SemanticError.New(SemanticErrorCode.BooleanTernaryOperatorRequireValues, xplTernaryoperator));
                    return null;
                }
                // try to convert results to value if they aren't already
                if (!o2Res.get_IsValue()) TryConvertTypeMembersToValueOrLValue(o2Res, currentScope, xplTernaryoperator.get_o2().get_Content());
                if (!o3Res.get_IsValue()) TryConvertTypeMembersToValueOrLValue(o3Res, currentScope, xplTernaryoperator.get_o3().get_Content());
                // check that both operands are values and have the same type or implicit convertible type
                if (!o2Res.get_IsValue() || !o3Res.get_IsValue())
                {
                    AddNewError(SemanticError.New(SemanticErrorCode.BooleanTernaryOperatorRequireValues, xplTernaryoperator));
                    return null;
                }
                string o2TypeStr = o2Res.get_TypeStr();
                string o3TypeStr = o3Res.get_TypeStr();
                if (!IsSameStringType(o2TypeStr, o3TypeStr))
                {
                    // try implicit conversions
                    ConversionData convFromO2ToO3 = ExistsImplicitConversion(o2TypeStr, o3TypeStr, xplTernaryoperator.get_o2(), currentScope);
                    ConversionData convFromO3ToO2 = ExistsImplicitConversion(o3TypeStr, o2TypeStr, xplTernaryoperator.get_o3(), currentScope);
                    if (convFromO2ToO3 != null && convFromO3ToO2 != null || convFromO3ToO2 == null && convFromO2ToO3 == null)
                    {
                        // don't exists conversion between types or it's ambiguous
                        AddNewError(SemanticError.New(SemanticErrorCode.IncompatibleTypesOnBooleanTernaryOperator, xplTernaryoperator));
                        return null;
                    }
                    if (convFromO2ToO3 != null) o2TypeStr = o3TypeStr;
                    if (convFromO2ToO3 == null) convFromO2ToO3 = convFromO3ToO2;
                    MarkConversion(convFromO2ToO3, o2TypeStr, o3TypeStr, xplTernaryoperator.get_o2(), currentScope);
                }
                return new ExpressionResult(o2TypeStr, ExpressionResultType.Value);
            }
            else
            {
                // error unsupported ternary operator
                AddNewError(SemanticError.New(SemanticErrorCode.UnsupportedTernaryOperator, xplTernaryoperator));
                return null;
            }
        }

        private ExpressionResult ProcessWritecodeExpression(XplWriteCodeBody xplWriteCodeBody, Scope currentScope)
        {
            //PENDIENTE : el writecode deberia convertirse al final de todos los
            //ciclos de compilacion fuera del analizador semantico para evitar
            //no incluir simbolos erroneos temporalmente.
            TypeInfo currentType = (TypeInfo)p_types[currentScope.get_FullClassName()];
            if (currentType == null)
                //PENDIENTE : Aqui no deberia emitir una asercion al menos?
                return null;
            //PENDIENTE : falta chequear cuando la funcion actual es factory y no la clase jeje

            if (!currentType.get_IsFactory())
            {
                BaseInfoCollection bases = currentType.get_BaseInfoCollection();
                if (bases.get_DirectOrIndirectBase(CLASSFACTORYBASE) == null &&
                    bases.get_DirectOrIndirectBase(CLASSFACTORYINTERACTIVEBASE) == null)
                {
                    AddNewError(SemanticError.New(
                        SemanticErrorCode.InvalidWritecodeUseInNonFactoryMember, xplWriteCodeBody));
                    return null;
                }
            }
            XplNode wcContent = xplWriteCodeBody.get_Content();
            if (wcContent == null)
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.WritecodeExpressionEmpty, xplWriteCodeBody)
                );
                return null;
            }

            //1) Buscar todas las ocurrencias de identificadores $id en el bloque argumento de writecode
            XplInitializerList vars = FindWritecodeReemplazeCandidates(xplWriteCodeBody, currentScope);

            if (!p_interactiveOnly)
            {
                /*
                string tempCode = ZoeHelper.WriteToString(xplWriteCodeBody).Replace("\"", "\\\"").Replace("\\&quot;","\\\\&quot;");
                XplExpression targetNode = (XplExpression)xplWriteCodeBody.get_Parent();
                targetNode.set_Content(
                    MakeCastExpression(xplWriteCodeBody, MakeWritecodeCall(tempCode, vars)));
                 */
                currentType.get_Section().WritecodeExpressions.Add(xplWriteCodeBody);
                currentType.get_Section().WritecodeExpressions.Add(vars);
            }

            //Establezco la información de fuente completa en el nodo de contenido
            //PENDIENTE : Revisar porque se duplican las barras en la salida final
            wcContent.PersistFullSourceFileInfo();

            //PENDIENTE : hacer que si tengo un bloque de expresiones
            // que puede ser un FunctionBody o un DocumentBody, el 
            // resultado dependa del contexto de acuerdo a si
            // se requiere un functionbody o un documentbody....
            // ...o mejor si solo son expresiones que siempre
            // lo fuerze a que sea un function body... bueno
            // este cambio lo debo hacer en el compilador Meta D++
            // ya que no deberia ser incumbencia de Zoe
            // 
            //2)Determino q tipo voy a devolver
            ExpressionResult res = new ExpressionResult(TypeString.MakeReferenceTypeTo(
                    CODEDOM_NAMESPACE + "." + wcContent.get_TypeName()),
                    ExpressionResultType.Value);
            //PENDIENTE : REVISAR ESTOOOOOO, VER CON LA ESPECIFICACION META D++
            return res;
        }

        #region Utiles para Writecode
        /// <summary>
        /// Función de interfaz para buscar los nombres de los nodos candidatos a ser reemplazados por writecode.
        /// </summary>
        private XplInitializerList FindWritecodeReemplazeCandidates(XplWriteCodeBody xplWriteCodeBody, Scope currentScope)
        {
            XplInitializerList vars = XplInitializerList.new_list();
            InternalFindWritecodeReemplazeCandidates(xplWriteCodeBody.get_Content(), currentScope, vars, new Hashtable());
            return vars;
        }
        /// <summary>
        /// Implementa la busqueda real de nombres de nodos candidatos para la expresion writecode, solo debe
        /// ser llamada por la función de interfaz.
        /// </summary>
        private void InternalFindWritecodeReemplazeCandidates(XplNode xplNode, Scope currentScope, XplInitializerList vars, Hashtable currentIds)
        {
            if (xplNode == null) return;
            if (currentScope == null) throw new ArgumentException("El argumento no debe ser nulo.", "currentScope");
            if (vars == null) throw new ArgumentException("El argumento no debe ser nulo.", "vars");
            if (currentIds == null) throw new ArgumentException("El argumento no debe ser nulo.", "currentIds");
            string name = null;
            if (xplNode.get_TypeName() == CodeDOMTypes.XplNode)
                name = xplNode.get_StringValue();
            else if (xplNode.get_TypeName() == CodeDOMTypes.XplType)
                name = ((XplType)xplNode).get_typename();
            //If it is a comment we must check inside de text
            else if (xplNode.get_TypeName() == CodeDOMTypes.XplDocumentation)
            {
                Regex regex = new Regex("\\$(^( \t\n).)+?\\$");
                XplDocumentation docnode = (XplDocumentation)xplNode;
                string searchStr = docnode.get_short();
                if (searchStr != null)
                {
                    MatchCollection result = regex.Matches(searchStr);
                    if (result.Count > 0)
                    {
                        foreach (Match match in result)
                        {
                            string simpleMatch = match.Value;
                            simpleMatch = simpleMatch.Substring(0, simpleMatch.Length - 1);

                            InternalFindWritecodeReemplazeCandidatesCheckName(xplNode, currentScope, vars, currentIds, simpleMatch);
                        }
                    }
                }
            }
            else
                name = xplNode.AttributeValue("name");

            if (xplNode.get_TypeName() != CodeDOMTypes.XplDocumentation)
            {
                name = InternalFindWritecodeReemplazeCandidatesCheckName(xplNode, currentScope, vars, currentIds, name);
            }

            XplNodeList children = xplNode.ChildNodes();
            if (children != null && children.GetLength() > 0)
                foreach (XplNode childNode in children)
                    InternalFindWritecodeReemplazeCandidates(childNode, currentScope, vars, currentIds);
        }

        private string InternalFindWritecodeReemplazeCandidatesCheckName(XplNode xplNode, Scope currentScope, XplInitializerList vars, Hashtable currentIds, string name)
        {
            if (name != null && name.Length > 1 && name.IndexOf('$') >= 0 && name[name.Length - 1] != '$')
            {
                if (TypeString.IsQualifiedName(name))
                {
                    int initIndex = name.IndexOf('$');
                    int endIndex = name.IndexOfAny(new char[] { '.', ':' }, initIndex);
                    if (endIndex < 0)
                        name = name.Substring(initIndex + 1);
                    else
                        name = name.Substring(initIndex + 1, endIndex - initIndex - 1);
                }
                else
                {
                    name = name.Substring(1);
                }
                //Se encontro un identificador $ que solicita reemplazo

                if (CheckForValidWritecodeReemplazement(name, xplNode, currentScope))
                {
                    if (!currentIds.ContainsKey(name))
                    {
                        XplExpression expNode = new XplExpression();
                        ZoeHelper.ReadFromString("<e><lit str=\"$" + name + "\"></lit></e>", expNode);
                        vars.Children().InsertAtEnd(expNode);

                        expNode = new XplExpression();
                        ZoeHelper.ReadFromString("<e><n>" + name + "</n></e>", expNode);
                        vars.Children().InsertAtEnd(expNode);
                        currentIds.Add(name, null);
                    }
                }
            }
            return name;
        }
        /// <summary>
        /// Chequea si el nodo que se quiere reemplazar en una expresion writecode posee
        /// en el alcance un simbolo valido o no. Emite los errores correspondientes en el
        /// caso de que el simbolo no exista o no sea de un tipo valido para el contexto de 
        /// reemplazo.
        /// </summary>
        private bool CheckForValidWritecodeReemplazement(string symbolName, XplNode xplNode, Scope currentScope)
        {
            ExpressionResult expRes =
                ProcessSimpleNameExpression(new XplExpression(new XplNode("n", symbolName)).get_Content(), currentScope);
            if (expRes != null)
            {
                if (expRes.get_IsTypeMembers())
                    expRes = TryConvertTypeMembersToValueOrLValue(expRes, currentScope, null);
                if (!expRes.get_IsValue())
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.ValueRequiredForNamesOnWritecodeExpression,
                        xplNode, symbolName)
                    );
                    return false;
                }

                bool flagAddError = false;
                string symTypeStr = expRes.get_TypeStr();

                if (NativeTypes.IsNativeType(symTypeStr) ||
                    IsSameStringType(symTypeStr, TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplType")) /*||
                    IsSameStringType(symTypeStr, MakeReferenceTypeTo("XplType"))/*1*/
                                                                                      )
                {
                    //XplType
                    if (xplNode.get_TypeName() != CodeDOMTypes.XplType && xplNode.get_TypeName() != CodeDOMTypes.XplDocumentation)
                    {
                        flagAddError = true;
                    }
                    return true;
                }
                else if (NativeTypes.IsNativeBlock(symTypeStr) ||
                    IsSameStringType(symTypeStr, TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplFunctionBody")) /*||
                    IsSameStringType(symTypeStr, MakeReferenceTypeTo("XplFunctionBody"))/*1*/
                                                                                              )
                {
                    //XplFunctionBody
                    if (xplNode.get_Parent().get_TypeName() != CodeDOMTypes.XplExpression)
                    {
                        flagAddError = true;
                    }
                }
                else if (expRes.get_TypeNode() != null && expRes.get_TypeNode().get_ftype() == XplFactorytype_enum.EXPRESSION ||
                    IsSameStringType(symTypeStr, TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplExpression")) /*||
                    IsSameStringType(symTypeStr, MakeReferenceTypeTo("XplExpression"))/*1*/
                                                                                            )
                {
                    //XplExpression
                    if (xplNode.get_Parent().get_TypeName() != CodeDOMTypes.XplExpression)
                    {
                        flagAddError = true;
                    }
                }
                else if (expRes.get_TypeNode() != null && expRes.get_TypeNode().get_ftype() == XplFactorytype_enum.INAME ||
                   IsSameStringType(symTypeStr, TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplIName")) /*||
                   IsSameStringType(symTypeStr, MakeReferenceTypeTo("XplIName"))/*1*/
                                                                                      )
                {
                    //XplIName
                    //
                    //PENDIENTE : hace falta chequear si se utiliza un iname que no sea void
                    //en la declaracion de un campo o variable no void o como nombre en una declaracion?
                    //if (xplNode.get_TypeName() == "XplInherit" || xplNode.get_TypeName() == "XplImplement" )
                    //{
                    //    flagAddError = true;
                    //}
                }
                else if (NativeTypes.IsValidNativeLiteralType(symTypeStr) ||
                    IsSameStringType(symTypeStr, TypeString.MakeReferenceTypeTo(NativeTypes.String)) ||
                    IsSameStringType(symTypeStr, TypeString.MakeReferenceTypeTo(NativeTypes.ASCIIString)))
                {
                    if (xplNode.get_Parent().get_TypeName() != CodeDOMTypes.XplExpression)
                    {
                        flagAddError = true;
                    }
                }
                else
                {
                    //No es un tipo valido
                    flagAddError = true;
                }
                if (flagAddError)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidTypeReferencedOnWritecodeExpression, xplNode, symTypeStr, symbolName)
                    );
                    return false;
                }
                else
                {
                    return true;
                }
                //Las opciones "/*1*/" indican:
                //Esto es por una limitacion en el writecode
                //que deberia implementarse fuera del analizador semantico
                //luego de todos los ciclos de compilacion, o bien 
                //en el ultimo ciclo de compilacion.
                //Esto se debe a por ej el hecho de utilizar una classfactory para inyectar los imports,
                //el mismo comportamiento erroneo hace que los errores aqui detectados sean ignorados
                //si la classfactory posee mas de un tiempo de compilacion por el hecho
                //de que se procesara el writecode en el primer tiempo de compilacion y luego se
                //eliminaran los errores, pero la instrucción writecode no volvera a controlarse.
            }
            else
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.UnresolvedNameOnWritecodeExpression, xplNode, symbolName)
                );
                return false;
            }
        }
        #endregion


        /// <summary>
        /// Determina si "symType" es un tipo reemplazable por
        /// la expresion writecode.
        /// </summary>
        private bool IsWritecodeReemplazableType(XplType symType)
        {
            if (symType.get_ftype() != XplFactorytype_enum.NONE ||
                NativeTypes.IsNativeType(symType.get_typeStr()) ||
                NativeTypes.IsNativeBlock(symType.get_typeStr()) ||
                IsSameStringType(symType.get_typeStr(), TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplExpression")) ||
                IsSameStringType(symType.get_typeStr(), TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplType")) ||
                IsSameStringType(symType.get_typeStr(), TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplFunctionBody")) ||
                IsSameStringType(symType.get_typeStr(), TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplIName")) ||
                //Esto es por una limitacion en el writecode
                //que deberia implementarse fuera del analizador semantico
                //luego de todos los ciclos de compilacion, o bien 
                //en el ultimo ciclo de compilacion.
                IsSameStringType(symType.get_typeStr(), TypeString.MakeReferenceTypeTo("XplExpression")) ||
                IsSameStringType(symType.get_typeStr(), TypeString.MakeReferenceTypeTo("XplType")) ||
                IsSameStringType(symType.get_typeStr(), TypeString.MakeReferenceTypeTo("XplIName")) ||
                IsSameStringType(symType.get_typeStr(), TypeString.MakeReferenceTypeTo("XplFunctionBody")))
                return true;
            return false;
        }

        private ExpressionResult ProcessTypeOfExpression(XplType typeNode, Scope currentScope)
        {
            //La expresion typeof(exp) es implementada como un operador unario!
            ExpressionResult res = null;
            int backErrorCount = p_errorCollection.Count;
            CheckType(typeNode, typeNode, currentScope, false, "On \"typeof\" expression.");

            // check for type constructor
            CheckForTypeConstructorCallOrSymbol(typeNode, currentScope, null);

            if (backErrorCount == p_errorCollection.Count)
                //Devuelvo un valor del tipo utilizado en tiempo de ejecución para 
                //representar un tipo de datos.
                res = new ExpressionResult(p_runtimeTypeForType, ExpressionResultType.Value);
            else
                res = null;
            return res;
        }
        private ExpressionResult ProcessIsExpression(XplCastexpression xplCastexpression, Scope currentScope, TypeInfo classType, MemberInfo memberInfo)
        {
            //PENDINETE : revisar semantica de expresión IS cuando se posea la especificación más 
            //detallada del funcionamiento esperado.
            ExpressionResult res = null;
            int backErrorCount = p_errorCollection.Count;
            XplType typeNode = xplCastexpression.get_type();
            if (typeNode != null)
            {
                CheckType(typeNode, typeNode, currentScope, false, "On \"is\" expression.");

                // check for type constructor
                CheckForTypeConstructorCallOrSymbol(typeNode, currentScope, null);

                XplExpression isExp = xplCastexpression.get_e();
                if (isExp != null)
                {
                    ExpressionResult expRes = ProcessExpression(isExp, currentScope, classType, memberInfo);
                    if (expRes != null && !expRes.get_IsValue())
                    {
                        expRes = TryConvertTypeMembersToValueOrLValue(expRes, currentScope, isExp.get_Content());
                        if (!expRes.get_IsValue())
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.ValueRequiredOnIsExpression,
                                isExp));
                        }
                    }
                }
                else
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.ExpressionRequired,
                        xplCastexpression));
                }
                if (backErrorCount == p_errorCollection.Count)
                    res = new ExpressionResult(NativeTypes.Boolean, ExpressionResultType.Value);
                else
                    res = null;
            }
            else
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.TypeRequiredOnIsExpression,
                    xplCastexpression));
            }
            return res;
        }

        private ExpressionResult ProcessGetTypeExpression(XplType xplType, Scope currentScope)
        {
            ExpressionResult res = null;
            int backErrorCount = p_errorCollection.Count;
            CheckType(xplType, xplType, currentScope, false, "On \"gettype\" expression.");
            //xplType.set_typeStr( CalculeTypeString(xplType, "", false, currentScope) );
            //Lo convierto a un string :-)
            string nodeStr = xplType.get_typeStr();
            // typeStr cann't be empty on gettype
            if (nodeStr == "")
            {
                AddNewError(SemanticError.New(SemanticErrorCode.TypeRequired,
                    xplType, "On gettype expression."));
                return null;
            }
            //PENDIENTE : Revisar si siempre se van a convertir las expresiones gettype de una al
            //ser analizadas semanticamente.

            if (backErrorCount == p_errorCollection.Count)
            {
                XplFunctioncall fc = XplExpression.new_fc();
                XplNode n = XplExpression.new_n();
                XplLiteral lit = XplExpression.new_lit();
                //n.set_Value(CODEDOM_NAMESPACE + ".ZoeHelper.MakeTypeFromString");
                n.set_Value("DotNET.LayerD.CodeDOM.ZoeHelper.MakeTypeFromString");
                n.UpdateSourceInfoFrom(xplType);

                lit.set_str(nodeStr);
                fc.set_l(new XplExpression(n));
                XplNodeList args = new XplNodeList();
                XplExpression arg = XplExpressionlist.new_e();
                arg.set_Content(lit);
                args.InsertAtEnd(arg);
                fc.set_args(new XplExpressionlist(args));
                xplType.get_Parent().set_Content(fc);

                res = new ExpressionResult(NativeTypes.Type, ExpressionResultType.Value);
            }
            else
            {
                res = null;
            }

            return res;
        }
        private ExpressionResult ProcessDeleteExpression(XplExpression xplExpression, Scope currentScope)
        {
            //PENDIENTE : Expresión Delete.
            return null;
        }
        private ExpressionResult ProcessCastExpression(XplCastexpression xplCastexpression, Scope currentScope, TypeInfo classType, MemberInfo memberInfo)
        {
            if (!CalculeTypeString(xplCastexpression.get_type(), currentScope))
                //El tipo esta mal definido, la expresion es incorrecta por tanto.
                return null;
            string castToType = xplCastexpression.get_type().get_typeStr();

            // check for type constructor
            CheckForTypeConstructorCallOrSymbol(xplCastexpression.get_type(), currentScope, null);

            ExpressionResult castExpRes = ProcessExpression(xplCastexpression.get_e(), currentScope, classType, memberInfo);
            if (castExpRes == null) //La expresion a castear no se puede resolver, el cast menos
                return null;
            if (castExpRes.get_IsTypeMembers())
                castExpRes = TryConvertTypeMembersToValueOrLValue(castExpRes, currentScope, xplCastexpression.get_e().get_Content());
            if (!castExpRes.get_IsValue())
            {
                AddNewError(SemanticError.New(SemanticErrorCode.ValueRequiredOnCastExpression,
                    xplCastexpression.get_e()));
                return null;
            }
            //Trato de convertir del tipo de la expresion al tipo indicado por el cast
            string castFromType = castExpRes.get_TypeStr();
            if (IsSameStringType(castFromType, castToType))
            {
                AddNewError(
                    SemanticWarning.New(SemanticWarningCode.ExplicitCastUnnecessaryTargetTypeSameAsSource,
                    xplCastexpression));
            }
            else
            {
                ConversionData cdata = ExistsExplicitConversion(castFromType, castToType, xplCastexpression.get_e(), currentScope);
                if (cdata != null)
                    MarkConversion(cdata, castFromType, castToType, xplCastexpression.get_e(), currentScope);
                else
                {
                    //Error conversión explicita no definida
                    AddNewError(SemanticError.New(SemanticErrorCode.UndefinedExplicitConversion,
                        xplCastexpression, castFromType, castToType));
                    return null;
                }
            }
            return new ExpressionResult(castToType, ExpressionResultType.Value);
        }
        private ExpressionResult ProcessComplexFunctioncallExpression(XplComplexfunctioncall xplComplexfunctioncall, Scope currentScope, TypeInfo classType, MemberInfo memberInfo)
        {
            //PENDIENTE : Expresión de llamada a función compleja.
            ExpressionResult leftResult = ProcessExpression(xplComplexfunctioncall.get_l(), currentScope, classType, memberInfo);
            if (leftResult != null)
                if (leftResult.get_ExpType() != ExpressionResultType.TypeMembers &&
                    leftResult.get_ExpType() != ExpressionResultType.TypeMembersFromValue)
                    //PENDIENTE : chequear cuando la expresión izquierda es un valor de tipo puntero a función.
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidLeftExpressionOnFunctionCallOperator, xplComplexfunctioncall));
                else
                {
                    MemberInfo[] members = leftResult.get_Members();
                    //Seteo info provisoria
                    //xplFunctioncall.set_targetClass(members[0].get_DeclarationClassTypeFullName());
                    //xplFunctioncall.set_targetMember("?");

                    string memberName = members[0].get_MemberName();
                    if (leftResult.get_ExpType() == ExpressionResultType.TypeMembers)
                        members = FilterStaticMembers(members, currentScope, false);

                    if (members == null)
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.AValueIsRequiredToInvoqueInstanceMember,
                            xplComplexfunctioncall, memberName, "On function call expression."));
                        return null;
                    }
                    //Evaluo las expresiones de los argumentos
                    /*
                    if (xplFunctioncall.get_args() != null)
                    {
                        ProcessArguments(xplFunctioncall, scope);
                    }*/
                    if (members.Length > 1)
                    {
                        //PENDIENTE : cuando tengo funciones con argumentos complejos 
                        //q usa sobrecarga
                    }
                    else
                    {
                        //PENDIENTE : chequear el argumento
                    }
                    if (!members[0].IsMethod())
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.InvalidMemberTypeUsedAsMethod, xplComplexfunctioncall, members[0].get_MemberName()));
                    else
                    {
                        if (members[0].IsFactory() || members[0].get_ClassType().get_IsFactory())
                            this.p_candidateStructures.AddCandidateStructure(members[0], xplComplexfunctioncall, currentScope);
                        //PENDIENTE : controlar si en los requerimientos del modulo de salida
                        //es necesario marcar la clase de llamada y el miembro objetivo o no.
                        //xplFunctioncall.set_targetClass(members[0].get_DeclarationClassTypeFullName());
                        //xplFunctioncall.set_targetMember(members[0].get_MemberInternalName());
                        return new ExpressionResult(((XplFunction)members[0].get_MemberNode()).get_ReturnType().get_typeStr());
                    }
                }
            return null;
        }
        private ExpressionResult ProcessBracketExpression(XplFunctioncall xplFunctioncall, Scope currentScope, TypeInfo classType, MemberInfo memberInfo)
        {
            ExpressionResult leftResult = ProcessExpression(xplFunctioncall.get_l(), currentScope, classType, memberInfo);
            if (leftResult != null)
            {
                if (leftResult.get_ExpType() == ExpressionResultType.TypeMembers ||
                    leftResult.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
                    leftResult = TryConvertTypeMembersToValueOrLValue(leftResult, currentScope, xplFunctioncall.get_l().get_Content());

                if (leftResult.get_ExpType() != ExpressionResultType.TypeMembers &&
                    leftResult.get_ExpType() != ExpressionResultType.TypeMembersFromValue &&
                    leftResult.get_ExpType() != ExpressionResultType.Type)
                {
                    //Value o L-Value
                    //---------------
                    //Puede ser:
                    //- Un acceso a una matriz.
                    //- Una operación de indización en un puntero.
                    //- Una llamada a un indexador.
                    string typeStr = leftResult.get_TypeStr();
                    if (TypeString.IsPointerType(typeStr) && !TypeString.IsReferencePointerType(typeStr) ||
                        TypeString.IsPointerType(typeStr) && currentScope.get_IsOnPointerScope())
                    {
                        //Aquí es una indización en un puntero
                        //PENDIENTE : chequear si el modulo de salida permite aritmetica
                        //de puntero y emitir errores.
                        if (CheckValidArgumentForArrayAccessOrPointerIndexing(xplFunctioncall, currentScope, classType, memberInfo))
                            return new ExpressionResult(TypeString.RemovePointerIndirectionsFromType(typeStr, 1)
                                , ExpressionResultType.ValueOrLValue);
                    }
                    else
                    {
                        if (TypeString.IsReferencePointerType(typeStr))
                            typeStr = TypeString.RemoveReferencesFromType(typeStr, TypeString.RemoveReferenciesType.ArrayAccess);
                        if (TypeString.IsArrayType(typeStr))
                        {
                            //Es una matriz, debo devolver el tipo de elemento de la matriz y chequear que
                            //exista un único argumento y sea de tipo entero o long, o convertible.
                            //PENDIENTE : chequear accesos fuera de rango con matrices estaticas??
                            typeStr = TypeString.RemoveArrayTypeFromType(typeStr);
                            if (CheckValidArgumentForArrayAccessOrPointerIndexing(xplFunctioncall, currentScope, classType, memberInfo))
                                return new ExpressionResult(typeStr, ExpressionResultType.ValueOrLValue);
                        }
                        else
                        {
                            //No es un puntero, ni una matriz, por tanto se requiere un indexador
                            //exista en el tipo.
                            #region Acceso a Indexador
                            typeStr = p_types.get_ExistingTypeName(typeStr, currentScope);
                            if (typeStr == null)
                            {
                                AddNewError(
                                    SemanticError.New(SemanticErrorCode.TypeRequired,
                                    xplFunctioncall, "On indexer access expression."));
                                return null;
                            }
                            else
                            {
                                //Evaluo las expresiones de los argumentos
                                //Evaluate this before to allow classfactorys to consult type of arguments even
                                //if the member does not exist or is a undefined call
                                if (xplFunctioncall.get_args() != null)
                                {
                                    ProcessArguments(xplFunctioncall, currentScope, classType, memberInfo);
                                }
                                TypeInfo expType = (TypeInfo)p_types[typeStr];
                                MemberInfo[] members = expType.get_MemberInfoCollection().get_MembersInfo("%indexer%");
                                //Filtro los miembros inaccesibles por el nivel de acceso.
                                //PENDIENTE : emitir errores cuando los miembros no sean accesibles
                                members = FilterAccesibleMembers(members, currentScope);
                                if (members == null)
                                {
                                    AddNewError(
                                        SemanticError.New(SemanticErrorCode.InaccesibleTypeMember,
                                        xplFunctioncall, typeStr + "[...]", "On indexer access expression."));
                                    return null;
                                }
                                members = FilterNonHiddenMembers(members, currentScope);
                                if (members == null)
                                {
                                    AddNewError(
                                        SemanticError.New(SemanticErrorCode.IndexerWasNotFoundOnType,
                                        xplFunctioncall, typeStr, "On indexer access expression."));
                                    return null;
                                }
                                if (members.Length > 1)
                                {
                                    //Tengo sobrecarga, debo resolver
                                    members = ResolveFunctionOverload(xplFunctioncall, members, currentScope, null);
                                    //Si no obtengo como respuesta ningun miembro es un error
                                    if (members == null)
                                    {
                                        AddNewError(
                                            SemanticError.New(SemanticErrorCode.BestOverloadedFunctionHasSomeInvalidArguments,
                                            xplFunctioncall, "indexer"));
                                        return null;
                                    }
                                    //Si luego de resolver sigo teniendo varios miembros es ambiguo
                                    if (members.Length > 1)
                                    {
                                        AddNewError(
                                            SemanticError.New(SemanticErrorCode.AmbiguousFunctionCall, xplFunctioncall));
                                        return null;
                                    }
                                }
                                else
                                {
                                    if (members[0].IsIndexer())
                                        if (!CheckArgumentsForFunction(xplFunctioncall, members[0], currentScope, true, false, null)) return null;
                                }
                                if (!members[0].IsIndexer())
                                    AddNewError(
                                        SemanticError.New(SemanticErrorCode.InvalidMemberTypeUsedAsMethod, xplFunctioncall, members[0].get_MemberName()));
                                else
                                {
                                    //PENDIENTE : controlar si en los requerimientos del modulo de salida
                                    //es necesario marcar la clase de llamada y el miembro objetivo o no.
                                    xplFunctioncall.set_targetClass(members[0].get_DeclarationClassTypeFullName());
                                    xplFunctioncall.set_targetMember(members[0].get_MemberInternalName());

                                    return new ExpressionResult(members, true);
                                }
                            }
                            #endregion
                        }
                    }
                }
                else
                {
                    //TypeMembers o Type
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidLeftExpressionOfArrayAccessOperator, xplFunctioncall));
                }
            }
            return null;
        }
        private void ProcessArguments(XplNodeList arguments, Scope currentScope, TypeInfo classType, MemberInfo memberInfo)
        {
            XplExpression argExp;
            ExpressionResult expRes;
            foreach (XplExpression arg in arguments)
            {
                argExp = arg;
                if (IsNamedArgument(arg)) argExp = GetNamedArgumentExpression(arg);
                expRes = ProcessExpression(arg, currentScope, classType, memberInfo);
                if (expRes != null)
                {
                    //Si no es un valor intento convertirlo a un valor
                    //PENDIENTE : cuando se procesan tipos factory no se si siempre  haria 
                    //falta un valor para pasar como argumento
                    if (expRes.get_ExpType() != ExpressionResultType.ValueOrLValue && expRes.get_ExpType() != ExpressionResultType.Value)
                        TryConvertTypeMembersToValueOrLValue(expRes, currentScope, arg.get_Content());
                    //Remuevo la referencia automatica del tipo
                    if (expRes.get_ExpType() == ExpressionResultType.Value || expRes.get_ExpType() == ExpressionResultType.ValueOrLValue)
                    {
                        if (!currentScope.get_IsOnPointerScope() && TypeString.IsReferencePointerType(expRes.get_TypeStr()))
                            expRes.set_TypeStr(TypeString.RemoveReferencesFromType(expRes.get_TypeStr(), TypeString.RemoveReferenciesType.SimpleExpression));
                        argExp.set_typeStr(expRes.get_TypeStr());
                    }
                }

            }
        }
        private void ProcessArguments(XplFunctioncall xplFunctioncall, Scope currentScope, TypeInfo classType, MemberInfo memberInfo)
        {
            ProcessArguments(xplFunctioncall.get_args().Children(), currentScope, classType, memberInfo);
        }
        private bool CheckValidArgumentForArrayAccessOrPointerIndexing(XplFunctioncall xplFunctioncall, Scope scope, TypeInfo classType, MemberInfo memberInfo)
        {
            XplExpressionlist args = xplFunctioncall.get_args();
            if (args == null || args.Children() == null || args.Children().GetLength() > 1 || args.Children().GetLength() < 1)
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.InvalidArgumentsCountForArrayAccess,
                    xplFunctioncall));
                return false;
            }
            else
            {
                XplExpression arg = (XplExpression)args.Children().FirstNode();
                ExpressionResult argResult = ProcessExpression(arg, scope, classType, memberInfo);
                if (argResult != null)
                {
                    argResult = TryConvertTypeMembersToValueOrLValue(argResult, scope, arg.get_Content());
                    ExpressionResultType argResultType = argResult.get_ExpType();
                    if (argResultType == ExpressionResultType.Value || argResultType == ExpressionResultType.ValueOrLValue)
                    {
                        string argTypeStr = argResult.get_TypeStr();
                        if (!NativeTypes.IsNativeLong(argTypeStr) && !NativeTypes.IsNativeInteger(argTypeStr))
                        {
                            if (ExistsImplicitConversion(argTypeStr, NativeTypes.Long, arg, scope) == null)
                            {
                                AddNewError(
                                    SemanticError.New(SemanticErrorCode.InvalidExpressionTypeForArrayAccess,
                                    xplFunctioncall));
                                return false;
                            }
                        }
                    }
                    else
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.ValueOrLValueRequiredAsOperand,
                            xplFunctioncall, "On array access expression."));
                        return false;
                    }
                }
                else
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.ValueOrLValueRequiredAsOperand,
                        xplFunctioncall, "On array access expression."));
                    return false;
                }
            }
            return true;
        }

        private ExpressionResult ProcessFunctioncallExpression(XplFunctioncall xplFunctioncall, Scope scope, TypeInfo classType, MemberInfo memberInfo)
        {
            ExpressionResult leftResult = ProcessExpression(xplFunctioncall.get_l(), scope, classType, memberInfo);

            if (leftResult == null && xplFunctioncall.get_bk() != null && IsIntrinsicClosureFunctionCall(xplFunctioncall))
            {
                return ProcessIntrinsicClosureFunctionCall(xplFunctioncall, scope, classType, memberInfo);
            }

            //Evaluo las expresiones de los argumentos
            //Evaluate this before to allow classfactorys to consult type of arguments even
            //if the member does not exist or is a undefined call
            if (xplFunctioncall.get_args() != null)
            {
                ProcessArguments(xplFunctioncall, scope, classType, memberInfo);
            }
            if (leftResult != null)
            {
                MemberInfo[] members = leftResult.get_Members();

                if (leftResult.get_ExpType() != ExpressionResultType.TypeMembers &&
                    leftResult.get_ExpType() != ExpressionResultType.TypeMembersFromValue)
                {
                    if (leftResult.get_ExpType() == ExpressionResultType.Type)
                    {
                        // find constructors for type
                        members = leftResult.get_Type().get_MemberInfoCollection().get_MembersInfo(
                            leftResult.get_Type().get_Name());

                        // if it's a call to default constructor - for a class that don't explicitly define default contructor -
                        // then it's ok, otherwise is an error
                        if (members == null && (xplFunctioncall.get_args() == null || xplFunctioncall.get_args().Children().GetLength() == 0))
                        {
                            xplFunctioncall.set_targetClass(leftResult.get_Type().get_FullName());
                            xplFunctioncall.set_targetMember(leftResult.get_Type().get_Name());
                            return new ExpressionResult(leftResult.get_Type().get_FullName());
                        }
                        else if (members == null)
                        {
                            // this is an error
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.InvalidLeftExpressionOnFunctionCallOperator, xplFunctioncall));
                            return null;
                        }
                    }
                    else
                    {
                        TypeInfo typeInfo = p_types.get_TypeInfo(leftResult.get_TypeStr());
                        if (typeInfo != null && typeInfo.get_IsFPType())
                        {
                            members = new MemberInfo[] { typeInfo.get_FpMemberInfo() };
                        }
                        else
                        {
                            //PENDIENTE : chequear cuando la expresión izquierda es un valor de tipo puntero a función.
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.InvalidLeftExpressionOnFunctionCallOperator, xplFunctioncall));
                            return null;
                        }
                    }
                }

                //Seteo info provisoria
                xplFunctioncall.set_targetClass(members[0].get_DeclarationClassTypeFullName());
                xplFunctioncall.set_targetMember("?");

                string memberName = members[0].get_MemberName();
                if (leftResult.get_ExpType() == ExpressionResultType.TypeMembers)
                    members = FilterStaticMembers(members, scope, true);

                if (members == null)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.AValueIsRequiredToInvoqueInstanceMember,
                        xplFunctioncall, memberName, "On function call expression."));
                    return null;
                }

                if (members.Length > 1)
                {
                    //Tengo sobrecarga, debo resolver
                    members = ResolveFunctionOverload(xplFunctioncall, members, scope, null);
                    //Si no obtengo como respuesta ningun miembro es un error
                    if (members == null)
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.BestOverloadedFunctionHasSomeInvalidArguments,
                            xplFunctioncall, memberName));
                        return null;
                    }
                    //Si luego de resolver sigo teniendo varios miembros es ambiguo
                    if (members.Length > 1)
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.AmbiguousFunctionCall, xplFunctioncall, MemberInfo.ToString(members)));
                        return null;
                    }
                }
                else
                {
                    if (members[0].IsMethod())
                        if (!CheckArgumentsForFunction(xplFunctioncall, members[0], scope, true, false, null)) return null;
                }
                if (!members[0].IsMethod())
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidMemberTypeUsedAsMethod, xplFunctioncall, members[0].get_MemberName()));
                else
                {
                    return ProcessFunctioncallExpressionCommonEnd(xplFunctioncall, scope, members[0], classType, memberInfo);
                }
            }

            return null;
        }

        private ExpressionResult ProcessIntrinsicClosureFunctionCall(XplFunctioncall xplFunctioncall, Scope scope, TypeInfo classType, MemberInfo memberInfo)
        {
            ExpressionResult result = null;

            XplNodeList parameters = EnterIntrinsicClosureScopeAndValidateParameters(xplFunctioncall, scope, classType, memberInfo);

            // mark call for output modules
            xplFunctioncall.set_targetClass("#intrinsic_closure#");
            xplFunctioncall.set_targetMember("#IC_CALL#");

            // eval block argument if present 
            EvalFunctionCallBlock(xplFunctioncall.get_bk(), scope, classType, memberInfo);

            ExitIntrinsicClosureScope(scope);

            XplType returnType = GetIntrinsicClosureReturnType(xplFunctioncall.get_bk());

            // create fp type
            if (returnType == null) returnType = ZoeHelper.MakeTypeFromString(NativeTypes.Void);

            TypeInfo typeInfo = GetFunctionPointerTypeForIntrinsicClosure(returnType, parameters, xplFunctioncall);
            result = new ExpressionResult(typeInfo.get_FullName());

            return result;
        }

        private TypeInfo GetFunctionPointerTypeForIntrinsicClosure(XplType returnType, XplNodeList parameters, XplFunctioncall xplFunctioncall)
        {
            string key = returnType.get_typeStr() + "/";
            if (parameters != null)
            {
                foreach (XplDeclarator parameter in parameters)
                {
                    key += parameter.get_type().get_typeStr() + "/";
                }
            }

            if (!p_intrinsicClosureTypes.ContainsKey(key))
            {
                TypeInfo closureTypesClass = p_types.get_TypeInfo("zoe.lang.ClosureTypes");
                if (closureTypesClass == null)
                {
                    AddNewError(SemanticError.New(SemanticErrorCode.UnspecifiedSemanticError, xplFunctioncall, "Intrinsic closure type not found."));
                    return p_types.get_TypeInfo(NativeTypes.Object);
                }

                XplFunction function = XplClass.new_Function();
                function.set_name("FP" + (p_intrinsicClosureTypes.Count + 1));
                function.set_ReturnType(returnType);
                function.set_fp(true);

                if (parameters != null)
                {
                    function.set_Parameters(XplFunction.new_Parameters());

                    foreach (XplDeclarator declarator in parameters)
                    {
                        XplParameter parameter = XplParameters.new_P();
                        parameter.set_name(declarator.get_name());
                        parameter.set_type(declarator.get_type());
                        function.get_Parameters().InsertAtEnd(parameter);
                    }
                }

                var fpMember = new MemberInfo(closureTypesClass, closureTypesClass, function);
                closureTypesClass.get_MemberInfoCollection().InsertMemberInfo(fpMember);
                InsertType(fpMember.FullName, function, fpMember);

                p_intrinsicClosureTypes.Add(key, p_types.get_TypeInfo(fpMember.FullName));
            }
            return (TypeInfo)p_intrinsicClosureTypes[key];
        }

        private static XplType GetIntrinsicClosureReturnType(XplFunctionBody xplFunctionBody)
        {
            // TODO : find all return expressions and check that it has the same type
            XplExpression returnExp = null; 

            XplNodeList children = xplFunctionBody.Children();

            foreach (XplNode item in children)
            {
                if (item.IsA(CodeDOMTypes.XplExpression) && item.get_ElementName() == "return")
                {
                    returnExp = item as XplExpression;
                    break;
                }
            }

            if (returnExp == null || String.IsNullOrEmpty(returnExp.get_typeStr())) return null;

            return ZoeHelper.MakeTypeFromString(returnExp.get_typeStr());
        }

        private void ExitIntrinsicClosureScope(Scope scope)
        {
            scope.LeaveScope();
        }

        private XplNodeList EnterIntrinsicClosureScopeAndValidateParameters(XplFunctioncall xplFunctioncall, Scope scope, TypeInfo classType, MemberInfo memberInfo)
        {
            scope.EnterScope(ScopeType.Block, null);

            if (xplFunctioncall.get_args() == null) return null;

            XplNodeList arguments = xplFunctioncall.get_args().Children();
            XplNodeList declarators = new XplNodeList();
            bool error = false;

            foreach (XplExpression argument in arguments)
            {
                XplDeclarator symbol = ValidateIntrinsicClosureParameter(argument, scope);
                if (symbol == null) error = true;
                else declarators += symbol;
            }

            if (error) return null;

            return declarators;
        }

        private XplDeclarator ValidateIntrinsicClosureParameter(XplExpression argument, Scope scope)
        {
            // valid "parameter" expression are:
            //      <n>aSimpleName</n>
            //      <@XplCastexpression><e><n>aSimpleName</n></e><type>aType</type></@XplCastexpression>
            XplNode content = argument.get_Content();
            if (!content.IsA(CodeDOMTypes.XplNode) && !content.IsA(CodeDOMTypes.XplCastexpression)) return null;

            string symbolName = null;
            XplType symbolType = null;

            if (content.IsA(CodeDOMTypes.XplNode))
            {
                symbolName = content.get_StringValue();
                // TODO : support type inference from usage inside function block
                symbolType = ZoeHelper.MakeTypeFromString(TypeString.MakeReferenceTypeTo(NativeTypes.Object));
            }
            else
            {
                // this is a XplCastexpression
                XplCastexpression cast = content as XplCastexpression;
                if (!cast.get_e().get_Content().IsA(CodeDOMTypes.XplNode)) return null;
                CheckType(cast.get_type(), cast, scope, true, null);
                if (String.IsNullOrEmpty(cast.get_type().get_typeStr())) return null;
                CheckForTypeConstructorCallOrSymbol(cast.get_type(), scope, null);

                symbolName = cast.get_e().get_Content().get_StringValue();
                symbolType = (XplType)cast.get_type().Clone();
            }

            if (scope.ExistsSymbol(symbolName))
            {
                AddNewError(SemanticError.New(SemanticErrorCode.SymbolAlreadyDefinedInCurrentScope, argument, symbolName));
                return null;
            }

            XplDeclarator declarator = new XplDeclarator();
            declarator.set_name(symbolName);
            declarator.set_type(symbolType);

            scope.InsertSymbol(new Symbol(declarator, symbolName));

            return declarator;
        }

        private void EvalFunctionCallBlock(XplFunctionBody body, Scope scope, TypeInfo classType, MemberInfo memberInfo)
        {
            scope.set_IsInsideFunctionCallBlockArgument(true);
            this.ProcessBlock(body, classType, scope, memberInfo);
            scope.set_IsInsideFunctionCallBlockArgument(false);
        }

        private static bool IsIntrinsicClosureFunctionCall(XplFunctioncall xplFunctioncall)
        {
            if (xplFunctioncall.get_bk() == null) return false;
            if (!xplFunctioncall.get_l().get_Content().IsA(CodeDOMTypes.XplNode)) return false;
            string functionName = xplFunctioncall.get_l().get_Content().get_StringValue();
            if (IsIntrinsicClosureName(functionName)) return true;
            return true;
        }

        private ExpressionResult ProcessFunctioncallExpressionCommonEnd(XplFunctioncall xplFunctioncall, Scope scope, MemberInfo callTargetMember, TypeInfo currentClassType, MemberInfo currentMemberInfo)
        {
            if (callTargetMember.IsFactory() || callTargetMember.get_ClassType().get_IsFactory())
            {
                //Aqui primero debe chequear q no sea una funcion miembro de la clase actual :-)
                //estatica ni una función que se llame usando this, lo q puedo hacer es q directamente
                //al declarar el puntero this utilice el modificador exec.
                if (callTargetMember.get_ClassTypeFullName() != scope.get_FullClassName())
                    this.p_candidateStructures.AddCandidateStructure(callTargetMember, xplFunctioncall, scope);
            }
            else if (callTargetMember.get_DeclarationClassType().get_IsFactory())
            {
                if (callTargetMember.get_DeclarationClassTypeFullName() != scope.get_FullClassName())
                    this.p_candidateStructures.AddCandidateStructure(callTargetMember, xplFunctioncall, scope);
            }
            //PENDIENTE : controlar si en los requerimientos del modulo de salida
            //es necesario marcar la clase de llamada y el miembro objetivo o no.
            xplFunctioncall.set_targetClass(callTargetMember.get_DeclarationClassTypeFullName());
            xplFunctioncall.set_targetMember(callTargetMember.get_MemberInternalName());
            xplFunctioncall.set_targetMemberExternalName(callTargetMember.get_MemberExternalName());

            // eval block argument if present 
            if (xplFunctioncall.get_bk() != null && (xplFunctioncall.get_evaluateBlock() || callTargetMember.RequireEvalBlock))
            {
                EvalFunctionCallBlock(xplFunctioncall.get_bk(), scope, currentClassType, currentMemberInfo);
            }

            if (callTargetMember.IsConstructor())
            {
                return new ExpressionResult(callTargetMember.get_ClassTypeFullName());
            }
            else
            {
                string typeStr = callTargetMember.get_ReturnType().get_typeStr();
                if (String.IsNullOrEmpty(typeStr))
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.UnspecifiedSemanticError, xplFunctioncall, " Member \"" + callTargetMember.ToString() + "\" with invalid return type found."));
                    return null;
                }
                else
                {
                    return new ExpressionResult(typeStr);
                }
            }
        }

        #region Sobrecarga de Funciones, Chequeo de Argumentos, Conversiones Implicitas
        /// <summary>
        /// Intenta resolver la sobrecarga de funciones.
        /// </summary>
        private MemberInfo[] ResolveFunctionOverload(XplFunctioncall xplFunctioncall, MemberInfo[] members, Scope scope, XplNode errorNode)
        {
            int lastIndex = 0;
            MemberInfo member = null;
            System.Collections.Generic.List<MemberInfo> validMembers =
                new System.Collections.Generic.List<MemberInfo>();
            //Primero filtro los miembros adecuados para los argumentos proporcionados
            for (int n = 0; n < members.Length; n++)
            {
                member = members[n];
                if (member.IsFunction())
                    if (CheckArgumentsForFunction(xplFunctioncall, member, scope, false, true, errorNode))
                    {
                        validMembers.Add(member);
                        //members[lastIndex] = member;
                        lastIndex++;
                    }
            }
            if (lastIndex == 0) return null;
            if (lastIndex == 1) return new MemberInfo[] { validMembers[0] };
            //Si siguen sobrando metodos elijo el mejor metodo

            //Ahora elijo la mejor funcion de todas las restantes
            int[] results = new int[lastIndex];
            int bestFunc = -1;
            bool isExit;
            for (int i = 0; i < lastIndex; i++)
            {
                isExit = false;
                if (results[i] == 1) continue;
                for (int j = 0; j < lastIndex; j++)
                {
                    if (i != j)
                    {
                        if (IsBestMethod(validMembers[i], validMembers[j], xplFunctioncall, scope)) results[j] = 1;
                        else { isExit = true; break; }
                    }
                }
                if (isExit) continue;
                results[i] = 2;
                if (bestFunc >= 0) { bestFunc = -1; break; }
                else bestFunc = i;
            }
            if (bestFunc >= 0) return new MemberInfo[] { validMembers[bestFunc] };
            else return validMembers.ToArray();
        }
        /// <summary>
        /// Determina si "funcA" es mejor que "funcB" para los argumentos
        /// proporcionados en "xplFunctioncall".
        /// </summary>
        private bool IsBestMethod(MemberInfo funcA, MemberInfo funcB, XplFunctioncall xplFunctioncall, Scope scope)
        {
            //PENDIENTE : Modificar para realizar bien el calculo cuando una de las funciones es usada
            //con el formato extendido de parametros variables.
            XplNodeList argList = xplFunctioncall.get_args().Children();
            XplNodeList funcAParams = funcA.get_Parameters() != null ? funcA.get_Parameters().Children() : new XplNodeList();
            XplNodeList funcBParams = funcB.get_Parameters() != null ? funcB.get_Parameters().Children() : new XplNodeList();
            int maxArgs = argList.GetLength();
            int[] results = new int[maxArgs];
            string argType, paramAType, paramBType;
            bool someArgumentIsBetter = false;
            for (int n = 0; n < maxArgs; n++)
            {
                argType = ((XplExpression)argList.GetNodeAt(n)).get_typeStr();
                paramAType = ((XplParameter)funcAParams.GetNodeAt(n)).get_type().get_typeStr();
                paramBType = ((XplParameter)funcBParams.GetNodeAt(n)).get_type().get_typeStr();

                results[n] = IsBetterConversion(argType, paramAType, paramBType, scope);
                if (results[n] == 0) return false;
                if (results[n] == 1) someArgumentIsBetter = true;
            }
            return someArgumentIsBetter;
        }
        /// <summary>
        /// Determina si la conversion implicita de "FromTypeA" --> "ToType" es
        /// mejor que la conversión implicita de "FromTypeB" --> "ToType".
        /// 
        /// Devuelve:
        /// 0 - No es mejor, es mejor la conversion de "FromTypeB" --> "ToType".
        /// 1 - Es mejor, es mejor la conversion de "FromTypeA" --> "ToType".
        /// 2 - Ninguna es mejor.
        /// </summary>
        private int IsBetterConversion(string ToType, string FromTypeA, string FromTypeB, Scope scope)
        {
            if (IsSameStringType(FromTypeA, FromTypeB)) return 2;
            if (IsSameStringType(FromTypeA, ToType)) return 1;
            if (IsSameStringType(FromTypeB, ToType)) return 0;
            if (ExistsImplicitConversion(FromTypeA, FromTypeB, null, scope) != null
                && ExistsImplicitConversion(FromTypeB, FromTypeA, null, scope) == null) return 1;
            if (ExistsImplicitConversion(FromTypeB, FromTypeA, null, scope) != null
                && ExistsImplicitConversion(FromTypeA, FromTypeB, null, scope) == null) return 0;
            //PENDIENTE : revisar el tema de las conversiones implicitas entre
            //tipos nativos con signo y sin signo.
            return 2;
        }
        /// <summary>
        /// Indica si los argumentos de la llamada a función "xplFunctioncall" son adecuados para
        /// el "memberInfo", si "emitErrors" es "true" emite errores de tipo de argumento o numero
        /// incorrecto, de lo contrario no emite errores.
        /// - "canonizeArguments" indica si debe construir el listado de argumentos canonicos, para
        /// luego poder comparar más facilmente las funciones.
        /// 
        /// Devuelve true si los argumentos son aplicables al "memberInfo", false de lo contrario.
        /// </summary>
        private bool CheckArgumentsForFunction(XplFunctioncall xplFunctioncall, MemberInfo memberInfo, Scope scope, bool emitErrors, bool canonizeArguments, XplNode errorNode)
        {

            //****
            //- Si tiene argumentos nombrados se debe chequear que no falten o sobren argumentos y 
            //que los argumentos que falten tengan valor por defecto. Ademas que los tipos de 
            //los argumentos sean aplicables a los tipo de los parametos y sean expresion del 
            //tipo Valor (de no ser que el argumento sea de tipo exp, type, iname) ademas si se 
            //usan argumentos nombrados y el ultimo argumento es variable, este argumento no se 
            //debe nombrar y la lista de argumentos finales deben ser del tipo de los elementos 
            //de la matriz, si se nombra el tipo del argumento debe ser la matriz.
            //- Si los argumentos no son nombrados se deben escribir todos los argumentos en orden 
            //adecuado, si se proporciona una expresion vacia para un argumento el parametro correspondiente 
            //debe tener valor por defecto, si faltan argumentos al final los parametros deben tener 
            //valor por defecto, si sobran argumentos el ultimo parametro debe ser params, y los 
            //argumentos que sobran mas el ultimo deben ser del tipo de los elementos del array o 
            //convertibles implicitamente.
            //En todos los casos si un parametro es out o outin y en la config del lenguaje se 
            //requiere una variable se debe chequear dicha condicion en la expresion de argumento.
            //Si no se proporcionan argumentos debe procesarse como cuando no se utilizan argumentos nombrados.
            //****

            //Primero chequeo si los argumentos son nombrados o no.
            XplExpressionlist args = xplFunctioncall.get_args();
            XplParameters parameters = ((XplFunction)memberInfo.get_MemberNode()).get_Parameters();
            int maxParams = parameters != null ? parameters.Children().GetLength() : 0;
            int maxArgs = args == null ? 0 : args.Children().GetLength();
            bool isVarArgs = false;
            bool isLastArgumentABlock = false;
            if (maxParams > 0) isVarArgs = ((XplParameter)parameters.Children().LastNode()).get_params();

            if (maxArgs == 0 || (args != null && !IsNamedArgument((XplExpression)args.Children().FirstNode())))
            {   
                //Argumentos sin nombrar
                int currentParam = 0;
                int currentArg = 0;
                XplParameter lastParam = null;
                if (args != null)
                {
                    foreach (XplExpression arg in args.Children())
                    {
                        if (currentParam < maxParams)
                        {
                            lastParam = (XplParameter)parameters.Children().GetNodeAt(currentParam);
                            currentParam++;
                        }
                        currentArg++;
                        if (currentParam < currentArg && !isVarArgs)
                        {
                            if (emitErrors) AddNewError(
                                SemanticError.New(SemanticErrorCode.InvalidNumberOfArgumentsInFunctionCall, errorNode != null ? errorNode : xplFunctioncall,
                                  memberInfo.ToString(), "More arguments than expected."));
                            return false;
                        }

                        bool allowCheckAsVarArg = isVarArgs && maxArgs >= maxParams && currentArg >= maxParams - 1;
                        bool allowTypeOfArray = isVarArgs && maxArgs == maxParams && currentArg == maxParams;

                        if (!CheckValidArgumentForParameter(arg, lastParam, allowCheckAsVarArg, allowTypeOfArray, scope))
                        {
                            if (emitErrors) AddNewError(
                                SemanticError.New(SemanticErrorCode.InvalidArgumentTypeForActualParameter, errorNode != null ? errorNode : arg,
                                lastParam.get_name(), arg.get_typeStr(), lastParam.get_type().get_typeStr(), memberInfo.ToString()));
                            return false;
                        }
                    }
                }
                //Aqui debo chequear si me faltaron argumentos que los parametros faltantes posean valor por defecto
                if (currentParam < maxParams)
                {
                    for (int n = currentParam; n < maxParams; n++)
                    {
                        lastParam = (XplParameter)parameters.Children().GetNodeAt(n);
                        if (n == maxParams - 1 && NativeTypes.IsNativeBlock(lastParam.get_type().get_typeStr()))
                        {
                            isLastArgumentABlock = true;
                            //Si el último parametro es un bloque
                            if (xplFunctioncall.get_bk() == null)
                            {
                                if (emitErrors) AddNewError(
                                      SemanticError.New(SemanticErrorCode.BlockArgumentExpectedOnFunctionCall, errorNode != null ? errorNode : xplFunctioncall,
                                      memberInfo.ToString()));
                                return false;
                            }
                        }
                        else if (!IsParameterWithDefaultValue(lastParam) && !(isVarArgs && n == maxParams - 1))
                        {
                            if (emitErrors) AddNewError(
                                  SemanticError.New(SemanticErrorCode.InvalidNumberOfArgumentsInFunctionCall, errorNode != null ? errorNode : xplFunctioncall,
                                  memberInfo.ToString(), "Less arguments than expected."));
                            return false;
                        }
                    }
                }

                //finalmente controlo si se proporciono un bloque como argumento y 
                //la función no acepta un bloque como argumento.
                if (!isLastArgumentABlock && xplFunctioncall.get_bk() != null)
                {
                    if (emitErrors) AddNewError(
                          SemanticError.New(SemanticErrorCode.UnexpectedArgumentBlockOnFunctionCall, errorNode != null ? errorNode : xplFunctioncall,
                          memberInfo.ToString()));
                    return false;
                }
            }
            else
            {
                // Named arguments
            }
            return true;
        }
        /// <summary>
        /// Determina si "param" es un parametro con valor por defecto.
        /// </summary>
        private static bool IsParameterWithDefaultValue(XplParameter param)
        {
            //PENDIENTE : revisar si el chequeo actual de parametro con valor por defecto
            //es suficiente (o se supone que esto viene chequeado cuando se chequea la funcion)
            return param.get_i() != null;
        }
        /// <summary>
        /// Indica si el argumento proporcionado "argument" es aceptable para el parametro "param".
        /// "argument" debe ser la expresion con el valor (sin el nombre).
        /// "isVarParam" indica si "param" es el ultimo parametro variable, establecer solo cuando
        /// se llama para comprobar argumentos en la forma extendida del metodo no cuando el numero
        /// de parametros coincide con el numero de argumento (en cuyo caso se requiere una matriz.
        /// "allowTypeOfArray" indica si cuando "isVarParam" es true se permite que el arguento sea 
        /// del tipo del array (o mejor puntero a array).
        /// </summary>
        private bool CheckValidArgumentForParameter(XplExpression argument, XplParameter param, bool isVarParam, bool allowTypeOfArray, Scope scope)
        {
            string argTypeStr = argument.get_typeStr();
            string paramTypeStr = param.get_type().get_typeStr();
            XplFactorytype_enum ft = param.get_type().get_ftype();
            if (argTypeStr != null && argTypeStr != String.Empty)
            {
                //PENDIENTE : procesar correctamente cuando el parametro es OUT o INOUT
                XplParameterdirection_enum paramDirection = param.get_direction();
                if (paramDirection == XplParameterdirection_enum.INOUT)
                {
                    if (!argument.get_lddata().Contains("$INOUT_ARG$")) argument.set_lddata(argument.get_lddata() + "$INOUT_ARG$");
                }
                else if (paramDirection == XplParameterdirection_enum.OUT)
                {
                    if (!argument.get_lddata().Contains("$OUT_ARG$")) argument.set_lddata(argument.get_lddata() + "$OUT_ARG$");
                }
                //PENDIENTE : procesaro correctamente cuando el parametro es de tipo factory
                //bool isIname, isIn, isOut, isBlock, isExec;
                if (ft != XplFactorytype_enum.NONE && !p_isExtensionModule)
                {
                    //Si es un iname se requiere q la expresion sea un nombre simple
                    if (ft == XplFactorytype_enum.INAME && argument.get_Content().get_ElementName() != "n")
                        //PENDIENTE : argegar la emision de un error cuando la expresion no es un nombre simple
                        return false;
                    //Si el paremetro es void acepto cualquier tipo de argumento,
                    //aun argumentos no evaluados correctamente
                    if (NativeTypes.IsNativeVoid(paramTypeStr))
                        return true;
                }
                //Si el parametro es varParam (y el argumento debe funcionar como el tipo del elemento)
                if (isVarParam && allowTypeOfArray)
                    if (IsSameStringType(argTypeStr, paramTypeStr)) return true;
                if (isVarParam) paramTypeStr = TypeString.RemoveArrayTypeFromType(paramTypeStr);
                if (IsSameStringType(argTypeStr, paramTypeStr)) return true;
                //No es el mismo tipo, debo verificar si existe una conversion implicita
                if (ExistsImplicitConversion(argTypeStr, paramTypeStr, argument, scope) != null) return true;
                else return false;
            }
            else if (ft != XplFactorytype_enum.NONE)
            {
                //El argumento no se pudo evaluar o cadena de tipo vacia
                //Aqui solo será valido si el parametro es un tipo "void exp" de un miembro factory,
                //en cualquier otro caso es un error.
                if (NativeTypes.IsNativeVoid(paramTypeStr))
                {
                    if (ft == XplFactorytype_enum.INAME && argument.get_Content().get_ElementName() != "n")
                        //PENDIENTE : argegar la emision de un error cuando la expresion no es un nombre simple
                        return false;
                    else
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Indica si existe una conversion explícita en el alcance desde el tipo "fromType" al
        /// tipo "toType".
        /// 
        /// No llamar con cadenas nulas o vacias!!
        /// No tiene en cuenta la conversion identidad, es decir no identificara como correcta
        /// una conversion de un tipo a si mismo.
        /// </summary>
        private ConversionData ExistsExplicitConversion(string fromType, string toType, XplNode convertedExpression, Scope scope)
        {
            ConversionData res = null;
            //1) Lookfor native implicit conversion
            res = ExistNativeImplicitConversion(fromType, toType, scope);
            if (res != null)
            {
                res.ConversionType = ConversionType.NativeExplicitConversion;
                return res;
            }

            //2) Lookfor inverse native implicit conversion :-)
            res = ExistNativeImplicitConversion(toType, fromType, scope);
            if (res != null)
            {
                res.ConversionType = ConversionType.NativeExplicitConversion;
                return res;
            }
            
            //3) Look for a conversion between enumeration and integer types
            TypeInfo fromTypeInfo = (TypeInfo)p_types[fromType];
            if (fromTypeInfo != null && fromTypeInfo.get_IsEnum())
            {
                //Primero controlo si es una conversion a un tipo entero
                switch (toType)
                {
                    case NativeTypes.Byte:
                    case NativeTypes.SByte:
                    case NativeTypes.UShort:
                    case NativeTypes.Short:
                    case NativeTypes.Unsigned:
                    case NativeTypes.Integer:
                    case NativeTypes.ULong:
                    case NativeTypes.Long:
                        // Conversion de enumeracion a tipo entero
                        res = new ConversionData(ConversionType.NativeExplicitConversion, false, false, null);
                        return res;
                    default:
                        // Puede ser una conversion de un tipo enumeracion a otro tipo enumeración
                        TypeInfo toTypeInfo = (TypeInfo)p_types[toType];
                        if (toTypeInfo != null && toTypeInfo.get_IsEnum())
                        {
                            // Conversion de enumeracion a otro tipo enumeracion
                            res = new ConversionData(ConversionType.NativeExplicitConversion, false, false, null);
                            return res;
                        }
                        break;
                }
            }

            //5) Lookfor conversion between pointer and integer types
            res = IsConversionBetweenPointerAndIntegerTypes(fromType, toType);
            if (res != null) return res;

            //6) Lookfor a user defined explicit conversion
            return ExistUserExplicitConversion(fromType, toType, convertedExpression, scope);;
        }

        /// <summary>
        /// Check if there is a valid conversion integer/pointer conversion between "fromType" and "toType" arguments.
        /// </summary>
        /// <param name="fromType">Type string that denotes the source type.</param>
        /// <param name="toType">Type string that denotes the target type.</param>
        /// <returns>Null if there isn't a conversion, a ConversionData if there is a valid conversion.</returns>
        private static ConversionData IsConversionBetweenPointerAndIntegerTypes(string fromType, string toType)
        {
            ConversionData res = null;
            // Lookfor a conversion from integer type to pointer type
            if (TypeString.IsPointerType(toType) && !TypeString.IsReferencePointerType(toType))
            {
                switch (fromType)
                {
                    case NativeTypes.Byte:
                    case NativeTypes.SByte:
                    case NativeTypes.UShort:
                    case NativeTypes.Short:
                    case NativeTypes.Unsigned:
                    case NativeTypes.Integer:
                    case NativeTypes.ULong:
                    case NativeTypes.Long:
                        // integer to pointer conversion
                        // TODO : add warning about insecure conversion
                        res = new ConversionData(ConversionType.NativeExplicitConversion, false, false, null);
                        return res;
                }
            }

            // Lookfor a conversion from pointer to integer type
            if (TypeString.IsPointerType(fromType) && !TypeString.IsReferencePointerType(fromType))
            {
                switch (toType)
                {
                    case NativeTypes.Byte:
                    case NativeTypes.SByte:
                    case NativeTypes.UShort:
                    case NativeTypes.Short:
                    case NativeTypes.Unsigned:
                    case NativeTypes.Integer:
                    case NativeTypes.ULong:
                    case NativeTypes.Long:
                        // pointer to integer conversion
                        // TODO : add warning when converting to small integer types
                        res = new ConversionData(ConversionType.NativeExplicitConversion, false, false, null);
                        return res;
                }
            }

            return res;
        }
        private ConversionData ExistUserExplicitConversion(string fromType, string toType, XplNode convertedExpression, Scope scope)
        {
            ConversionData result = ExistsSimpleUserExplicitConversion(fromType, toType);
            if (result != null)
            {
                this.p_candidateStructures.AddCandidateStructure(result.UserDefinedConversionUsed, convertedExpression, scope);
                return result;
            }

            // if there isn't a direct conversion, check for a posible conversion using
            // a native implicit conversion first
            // TODO this is not correct, it must check for all possible conversions and verify that it's not ambiguous
            ConversionData intermediateConversionData = null;
            foreach (string customConversion in p_customExplicitConversions.Keys)
            {
                string toCType = customConversion.Substring(0, customConversion.IndexOf('¿'));
                intermediateConversionData = ExistNativeImplicitConversion(fromType, toCType, scope);
                if (intermediateConversionData != null)
                {
                    // TODO intermediate conversion data is lost
                    result = ExistsSimpleUserExplicitConversion(toCType, toType);
                    if (result != null)
                    {
                        this.p_candidateStructures.AddCandidateStructure(result.UserDefinedConversionUsed, convertedExpression, scope);
                        return result;
                    }
                }
            }
            return null;
        }

        private ConversionData ExistsSimpleUserExplicitConversion(string fromType, string toType)
        {
            string conversionKey = fromType + "¿TO?" + toType;
            if (p_customExplicitConversions.ContainsKey(conversionKey))
            {
                return new ConversionData(ConversionType.UserDefinedExplicitConversion, false, false, (MemberInfo)p_customExplicitConversions[conversionKey]);
            }
            return null;
        }

        /// <summary>
        /// Indica si existe una conversion implicita en el alcance desde el tipo "fromType" al
        /// tipo "toType".
        /// 
        /// No llamar con cadenas nulas o vacias!!
        /// </summary>
        private ConversionData ExistsImplicitConversion(string fromType, string toType, XplNode convertedExpression, Scope scope)
        {
            ConversionData res = null;
            //1°) Primero busco en las conversiones implicitas nativas
            res = ExistNativeImplicitConversion(fromType, toType, scope);
            //2°) Busco conversión implicita definida por el usuario
            if (res == null)
                res = ExistUserImplicitConversion(fromType, toType, convertedExpression, scope);
            return res;
        }
        private ConversionData ExistUserImplicitConversion(string fromType, string toType, XplNode convertedExpression, Scope scope)
        {
            ConversionData result = ExistsSimpleUserImplicitConversion(fromType, toType);
            if (result != null)
            {
                this.p_candidateStructures.AddCandidateStructure(result.UserDefinedConversionUsed, convertedExpression, scope);
                return result;
            }

            // if there isn't a direct conversion, check for a posible conversion using
            // a native implicit conversion first
            // TODO this is not correct, it must check for all possible conversions and verify that it's not ambiguous
            ConversionData intermediateConversionData = null;
            foreach (string customConversion in p_customImplicitConversions.Keys)
            {
                string toCType = customConversion.Substring(0, customConversion.IndexOf('¿'));
                intermediateConversionData = ExistNativeImplicitConversion(fromType, toCType, scope);
                if (intermediateConversionData != null)
                {
                    // TODO intermediate conversion data is lost
                    result = ExistsSimpleUserImplicitConversion(toCType, toType);
                    if (result != null)
                    {
                        this.p_candidateStructures.AddCandidateStructure(result.UserDefinedConversionUsed, convertedExpression, scope);
                        return result;
                    }
                }
            }
            return null;
        }

        private ConversionData ExistsSimpleUserImplicitConversion(string fromType, string toType)
        {
            string conversionKey = fromType + "¿TO?" + toType;
            if (p_customImplicitConversions.ContainsKey(conversionKey))
            {
                return new ConversionData(ConversionType.UserDefinedImplicitConversion, false, false, (MemberInfo)p_customImplicitConversions[conversionKey]);
            }
            return null;
        }
        private ConversionData ExistNativeImplicitConversion(string fromType, string toType, Scope scope)
        {
            string conversionString = null;
            //1º) Busco en las conversiones implicitas de tipos nativos nativas.
            conversionString = (string)p_nativeImplicitConversions[fromType + "¿TO?" + toType];
            if (conversionString != null)
            {
                //PENDIENTE : No permitir conversiones de empaquetado cuando
                //se desactivo el sistema de tipos unificado.
                return new ConversionData(ConversionType.NativeImplicitConversion,
                    conversionString != String.Empty, false, null);
            }
            if (NativeTypes.IsNativeNull(fromType) && TypeString.IsPointerType(toType))
                return new ConversionData(ConversionType.NativeImplicitConversion,
                    conversionString != String.Empty, false, null);
            //2º) Busco si es una conversion de referencia nativa (*Derivada -> *Base)
            if (TypeString.IsPointerType(fromType) && TypeString.IsPointerType(toType))
            {
                if (TypeString.IsPointerToArrayType(fromType) && TypeString.IsPointerToArrayType(toType))
                {
                    string fromTypeClass = TypeString.RemovePointerIndirectionsFromType(fromType, 1);
                    string toTypeClass = TypeString.RemovePointerIndirectionsFromType(toType, 1);
                    //Chequeo si se puede convertir implicitamente de un tipo puntero de matriz
                    //a otro.
                    if (TypeString.GetArrayDimensions(fromTypeClass) == TypeString.GetArrayDimensions(toTypeClass))
                    {
                        fromTypeClass = TypeString.RemoveAllDimensionsFromArrayType(fromTypeClass);
                        toTypeClass = TypeString.RemoveAllDimensionsFromArrayType(toTypeClass);
                        if (TypeString.IsPointerType(fromTypeClass) && TypeString.IsPointerType(toTypeClass))
                            if (IsPointerToBaseOrInterfaceOf(toTypeClass, fromTypeClass))
                                return new ConversionData(ConversionType.NativeImplicitConversion,
                                    false, false, null);
                    }
                }
                else
                    if (IsPointerToBaseOrInterfaceOf(toType, fromType))
                        return new ConversionData(ConversionType.NativeImplicitConversion,
                            false, false, null);
            }
            //3°) Busco si es una conversion entre punteros a funciones
            //PENDIENTE : Chequear esto y mejorar velocidad :-)
            if (!TypeString.IsPointerType(toType) && !TypeString.IsArrayType(toType) && IsExplicitPointerToMember(fromType))
            {
                TypeInfo fpType = p_types.get_TypeInfo(toType);
                if (fpType != null && fpType.get_IsFPType())
                {
                    if (ExistsConversionBetweenFP(fpType, TypeString.RemovePointerIndirectionsFromType(fromType, 1)))
                        return new ConversionData(ConversionType.NativeImplicitConversion, false, false, null);
                }
            }
            //4°) Determino si es una conversión de empaquetado
            if (IsSameStringType(toType, TypeString.MakePointerTypeTo(NativeTypes.Object))
                && !p_programRequirements.get_DisableUnifiedTypeSystem())
            {
                //Los empaquetados posibles son de un tipo Enum o Struct a ^_object y
                //de cualquier tipo puntero de más de un nivel a ^_object, los tipos
                //de clases, matrices no pueden convertirse implicitamente, por tanto
                //el sistema unificado de tipos no es tal!!!
                //¿No deberia permitir tambien el empaquetado de valores de clase y matrices,
                //en dicho caso podría emitir un warning informando de la penalidad en performance
                //por copiar clases y matrices, pero así lograria realmente tener un sistema de tipos
                //unificados real y completo.
                if (TypeString.IsPointerToArrayType(fromType))
                {
                    //PENDIENTE : Debo chequear que la clase base usada para matrices sea derivada 
                    //de object.¿¿???
                    return new ConversionData(ConversionType.NativeImplicitConversion,
                        false, false, null);
                }
                else if (TypeString.IsPointerType(fromType))
                {
                    //Debo ver si es de más de un nivel para que sea valido
                    if (TypeString.IsPointerType(TypeString.RemovePointerIndirectionsFromType(fromType, 1)))
                        return new ConversionData(ConversionType.NativeImplicitConversion,
                            true, false, null);
                }
                else if (!TypeString.IsArrayType(fromType))
                {
                    // its a value of class, struct, enum, union or function pointer
                    TypeInfo type = (TypeInfo)p_types[fromType];
                    if (type != null && (type.get_IsEnum() || type.get_IsStruct() || type.get_IsClass() || type.get_IsUnion() || type.get_IsFPType()))
                        return new ConversionData(ConversionType.NativeImplicitConversion,
                            true, false, null);
                }
            }
            //5°) Es una conversión de un puntero a *void?
            if (TypeString.IsPointerType(fromType) && IsSameStringType(TypeString.MakePointerTypeTo(NativeTypes.Void), toType)
                && !p_programRequirements.get_DisableAllPointerConversionsToVoid())
            {
                //Conversion a void*
                //PENDIENTE : que el nodo para el error exista
                AddNewError(SemanticWarning.New(
                    SemanticWarningCode.UnsafeConversionFromPointerToGenericVoidPointer, null, fromType));
                return new ConversionData(ConversionType.NativeImplicitConversion,
                    false, false, null);
            }

            //6) Lookfor  conversion between function pointer types
            // TODO : check by output platform that
            // this kind of conversion is supported
            TypeInfo fromTypeInfo = (TypeInfo)p_types[fromType];
            if (fromTypeInfo != null && fromTypeInfo.get_IsFPType())
            {
                TypeInfo toTypeInfo = (TypeInfo)p_types[toType];
                if (toTypeInfo != null && toTypeInfo.get_IsFPType())
                {
                    if (AreFunctionPointerCompatibleSignatures(fromTypeInfo.get_FpMemberInfo(), toTypeInfo.get_FpMemberInfo(), scope))
                    {
                        return new ConversionData(ConversionType.NativeExplicitConversion, false, false, null);
                    }
                }
            }

            return null;
        }

        private bool AreFunctionPointerCompatibleSignatures(MemberInfo member, MemberInfo otherMember, Scope scope)
        {
            // check return type
            var memberTypeStr = member.get_ReturnType().get_typeStr();
            var otherMemberTypeStr = otherMember.get_ReturnType().get_typeStr();

            if (String.IsNullOrEmpty(memberTypeStr) || String.IsNullOrEmpty(otherMemberTypeStr)) return false;

            if(!IsSameStringType(memberTypeStr, otherMemberTypeStr))
            {
                var conversionData = ExistNativeImplicitConversion(memberTypeStr, otherMemberTypeStr, scope);
                if (conversionData == null) return false;
            }

            // check signature
            if (this.IsSameSignature(member, otherMember, scope)) return true;

            // if one function pointer has arguments of type "param ^[]object" then, exists an implicit conversion
            if (member.HasObjectVariableParameters() || otherMember.HasObjectVariableParameters()) return true;

            return false;
        }

        private bool ExistsConversionBetweenFP(TypeInfo toFpType, string explicitFPType)
        {
            int index = explicitFPType.IndexOf('/');
            string className = explicitFPType.Substring(0, index);
            string internalMemberName = explicitFPType.Substring(index + 1);
            TypeInfo fromType = p_types.get_TypeInfo(className);
            if (fromType == null) return false;
            MemberInfo fromMember = fromType.get_MemberInfoCollection().get_MembersInfoFromInternalName(internalMemberName);
            if (fromMember == null) return false;
            MemberInfo toFpMember = toFpType.get_FpMemberInfo();

            return IsSameSignature(toFpMember, fromMember, null);
        }

        /// <summary>
        /// Indica si typeStr es un puntero a un miembro expresado de forma explicita, de la forma:
        /// *_ClassName/InternalMemberName
        /// </summary>
        /// <param name="fromType"></param>
        /// <returns></returns>
        private static bool IsExplicitPointerToMember(string typeStr)
        {
            if (!TypeString.IsPointerType(typeStr)) return false;
            string toTypeStr = TypeString.RemovePointerIndirectionsFromType(typeStr, 1);
            if (TypeString.IsPointerType(toTypeStr) || TypeString.IsArrayType(toTypeStr)) return false;
            //PENDIENTE : mejorar esto para q solo busque un caracter no una cadena
            return toTypeStr.Contains("/");
        }
        /// <summary>
        /// Determina si "pointerToBase" realmente es un puntero
        /// a una Base o Interface del tipo apuntado por
        /// "pointerToDerived".
        /// 
        /// Llamar sólo con tipos punteros, de lo contrario el resultado es indeterminado.
        /// Si luego de eliminar una indirección el tipo apuntado no es una clase se
        /// cancela la busqueda y retorna false.
        /// </summary>
        private bool IsPointerToBaseOrInterfaceOf(string pointerToBase, string pointerToDerived)
        {
            Debug.Assert(TypeString.IsPointerType(pointerToBase) && TypeString.IsPointerType(pointerToDerived), "ERROR INTERNO: mal uso de IsPointerToBaseOrInterfaceOf.");
            pointerToBase = TypeString.RemovePointerIndirectionsFromType(pointerToBase, 1);
            pointerToDerived = TypeString.RemovePointerIndirectionsFromType(pointerToDerived, 1);
            //PENDIENTE : Aca debo considerar cuando quiero convertir un puntero a una matriz
            //a un puntero a "object"
            if (TypeString.IsPointerType(pointerToBase) || TypeString.IsPointerType(pointerToDerived)
                || TypeString.IsArrayType(pointerToBase) || TypeString.IsArrayType(pointerToDerived)) return false;


            TypeInfo baseType = (TypeInfo)p_types[pointerToBase];
            if (baseType == null)
                //OJO! aca no se encontro el tipo en la tabla de simbolos
                return false;
            TypeInfo derivedType = (TypeInfo)p_types[pointerToDerived];
            if (derivedType == null)
                //OJO! aca no se encontro el tipo en la tabla de simbolos
                return false;
            BaseInfo baseOf = derivedType.get_BaseInfoCollection().get_DirectOrIndirectBase(baseType.get_FullName());
            return baseOf != null && !baseOf.get_IsBadBase();
        }

        #region Ayudas para Argumentos Nombrados
        /// <summary>
        /// Indica si "xplExpression" es un argumento nombrado o no,
        /// es decir si es una expresión binaria con el operador "IMP".
        /// </summary>
        private bool IsNamedArgument(XplExpression xplExpression)
        {
            if (xplExpression.get_Content() == null)
            {
                AddNewError(SemanticError.New(SemanticErrorCode.InvalidEmptyExpressionNode, xplExpression));                
                return false;
            }
            if (xplExpression.get_Content().get_ElementName() == "bo" && ((XplBinaryoperator)xplExpression.get_Content()).get_op() == XplBinaryoperators_enum.IMP)
                return true;
            return false;
        }
        /// <summary>
        /// Devuelve el "nombre" del argumento nombrado.
        /// 
        /// NO LLAMAR CON UNA EXPRESION QUE NO SEA UN ARGUMENTO NOMBRADO.
        /// </summary>
        private static string GetNamedArgumentName(XplExpression argExpression)
        {
            return ((XplBinaryoperator)argExpression.get_Content()).get_l().get_Content().get_StringValue();
        }
        /// <summary>
        /// Devuelve la "expresion" del argumento nombrado.
        /// 
        /// NO LLAMAR CON UNA EXPRESION QUE NO SEA UN ARGUMENTO NOMBRADO.
        /// </summary>
        private static XplExpression GetNamedArgumentExpression(XplExpression argExpression)
        {
            return ((XplBinaryoperator)argExpression.get_Content()).get_r();
        }
        #endregion

        #endregion

        #region FilterNonHiddenMembers, FilterStaticMembers, FilterInstanceMembers, FilterAccesibleMembers
        //PENDIENTE : Mejorar todos los filtrados de miembros para que el filtrado sea más rápido usando
        //banderas directamente, aprovechar que hace falta hacer una colección y que la misma colección 
        //maneje dichas cuestiones.


        /// <summary>
        /// Filtra los miembros marcados como "Hidden", ocultos.
        /// </summary>
        private static MemberInfo[] FilterNonHiddenMembers(MemberInfo[] members, Scope scope)
        {
            if (members == null) return null;
            int index = 0, currentIndex = 0;
            foreach (MemberInfo member in members)
            {
                if (!member.get_Hidden())
                {
                    if (index != currentIndex) members[index] = member;
                    index++;
                }
                currentIndex++;
            }
            if (index == 0) return null;
            if (index == members.Length) return members;
            MemberInfo[] newMembers = new MemberInfo[index];
            for (int n = 0; n < index; n++)
                newMembers[n] = members[n];
            return newMembers;
        }
        /// <summary>
        /// Quita del grupo de miembros los miembros que no sean estáticos,
        /// es decir los miembros de instancia.
        /// </summary>
        private static MemberInfo[] FilterStaticMembers(MemberInfo[] members, Scope scope, bool allowConstructors)
        {
            if (members == null) return null;
            int index = 0, currentIndex = 0;
            foreach (MemberInfo member in members)
            {
                if (member.IsStatic() || allowConstructors && member.IsConstructor())
                {
                    if (index != currentIndex) members[index] = member;
                    index++;
                }
                currentIndex++;
            }
            if (index == 0) return null;
            if (index == members.Length) return members;
            MemberInfo[] newMembers = new MemberInfo[index];
            for (int n = 0; n < index; n++)
                newMembers[n] = members[n];
            return newMembers;
        }
        /// <summary>
        /// Quita del grupo de miembros los miembros que no sean de instancia,
        /// es decir los miembros estáticos.
        /// </summary>
        private static MemberInfo[] FilterInstanceMembers(MemberInfo[] members, Scope scope)
        {
            if (members == null) return null;
            int index = 0, currentIndex = 0;
            foreach (MemberInfo member in members)
            {
                if (!member.IsStatic())
                {
                    if (index != currentIndex) members[index] = member;
                    index++;
                }
                currentIndex++;
            }
            if (index == 0) return null;
            if (index == members.Length) return members;
            MemberInfo[] newMembers = new MemberInfo[index];
            for (int n = 0; n < index; n++)
                newMembers[n] = members[n];
            return newMembers;
        }
        /// <summary>
        /// Quita del grupo de miembros los miembros no accesibles para 
        /// el alcance actual.
        /// 
        /// También filtra los miembros marcados como "erroneos", "Bad Member".
        /// </summary>
        private static MemberInfo[] FilterAccesibleMembers(MemberInfo[] members, Scope scope)
        {
            //PENDIENTE : Que funcione!, filtrar tambien los miembros "malos".
            if (members == null) return null;
            int index = 0, currentIndex = 0;
            foreach (MemberInfo member in members)
            {
                if (!member.get_IsBadMember() && member.get_IsAccesible(scope))
                {
                    if (index != currentIndex) members[index] = member;
                    index++;
                }
                currentIndex++;
            }
            if (index == 0) return null;
            if (index == members.Length) return members;
            MemberInfo[] newMembers = new MemberInfo[index];
            for (int n = 0; n < index; n++)
                newMembers[n] = members[n];
            return newMembers;
        }
        #endregion

        #region ProcessLiteralExpression, ProcessSimpleNameExpression
        const char REFERENCE_CHAR = '%';
        private ExpressionResult ProcessLiteralExpression(XplLiteral xplLiteral, Scope scope)
        {
            string typeOfExp = String.Empty;
            string literalStr = xplLiteral.get_str();
            char lastLetter = REFERENCE_CHAR;
            int literalLength = literalStr.Length;
            if (literalLength > 0) lastLetter = literalStr[literalLength - 1];
            object constantValue = null;

            #region Establecimiento del String del Tipo
            double doubleValue = 0;
            bool parseResult = false;

            typeOfExp = "$" + xplLiteral.get_type().ToString() + "$";
            switch (xplLiteral.get_type())
            {
                case XplLiteraltype_enum.BOOL:
                    typeOfExp = NativeTypes.Boolean;
                    constantValue = literalStr == "true" ? true : false;
                    break;
                case XplLiteraltype_enum.STRING:
                case XplLiteraltype_enum.ASCIISTRING:
                    // TODO : check all possible character escapes
                    typeOfExp = "$" + xplLiteral.get_type().ToString() + "_LIT$";
                    constantValue = literalStr;
                    break;
                case XplLiteraltype_enum.CHAR:
                case XplLiteraltype_enum.ASCIICHAR:
                    // TODO : check all possible character escapes
                    constantValue = literalStr[0];
                    break;
                case XplLiteraltype_enum.INTEGER:
                    char firstLetter = REFERENCE_CHAR;
                    if (literalLength > 2) firstLetter = literalStr[literalLength - 2];
                    switch (lastLetter)
                    {
                        case 'u':
                        case 'U':
                            typeOfExp = NativeTypes.Unsigned;
                            if (!Char.IsDigit(firstLetter) && firstLetter != REFERENCE_CHAR)
                            {
                                literalStr = literalStr.Substring(0, literalLength - 2);
                            }
                            else if (!Char.IsDigit(lastLetter) && lastLetter != REFERENCE_CHAR)
                            {
                                literalStr = literalStr.Substring(0, literalLength - 1);
                            }
                            constantValue = UInt64.Parse(literalStr, NumberStyles.Integer, NumberFormatInfo.InvariantInfo);
                            break;
                        case 'l':
                        case 'L':
                            if (!Char.IsDigit(firstLetter) && firstLetter != REFERENCE_CHAR)
                            {
                                literalStr = literalStr.Substring(0, literalLength - 2);
                            }
                            else if (!Char.IsDigit(lastLetter) && lastLetter != REFERENCE_CHAR)
                            {
                                literalStr = literalStr.Substring(0, literalLength - 1);
                            }

                            if (firstLetter == 'u' || firstLetter == 'U')
                            {
                                typeOfExp = NativeTypes.ULong;
                                constantValue = UInt64.Parse(literalStr, NumberStyles.Integer, NumberFormatInfo.InvariantInfo);
                            }
                            else
                            {
                                typeOfExp = NativeTypes.Long;
                                constantValue = Int64.Parse(literalStr, NumberStyles.Integer, NumberFormatInfo.InvariantInfo);
                            }
                            break;
                        default:
                            constantValue = Int64.Parse(literalStr, NumberStyles.Integer, NumberFormatInfo.InvariantInfo);
                            typeOfExp = GetTypeForIntegerLiteral((long)constantValue);
                            break;
                    }
                    break;
                case XplLiteraltype_enum.REAL:
                    if (!Char.IsDigit(lastLetter) && lastLetter != REFERENCE_CHAR)
                    {
                        literalStr = literalStr.Substring(0, literalLength - 1);
                    }
                    typeOfExp = NativeTypes.Double;
                    switch (lastLetter)
                    {
                        case 'f':
                        case 'F':
                            typeOfExp = NativeTypes.Float;
                            break;
                        case 'd':
                        case 'D':
                            break;
                        case 'M':
                        case 'm':
                            typeOfExp = NativeTypes.Decimal;
                            break;
                        case 'X':
                        case 'x':
                            // TODO : this must be of type "fixed" or "reserved float"
                            typeOfExp = NativeTypes.Double;
                            break;
                    }
                    parseResult = Double.TryParse(literalStr, NumberStyles.Number | NumberStyles.AllowExponent, NumberFormatInfo.InvariantInfo, out doubleValue);
                    constantValue = parseResult ? doubleValue : 0;
                    if (!parseResult)
                    {
                        AddNewError(LexicalError.New(LexicalErrorCode.InvalidFloatConstant, xplLiteral, literalStr));
                    }
                    break;
                case XplLiteraltype_enum.FLOAT:
                case XplLiteraltype_enum.DOUBLE:
                case XplLiteraltype_enum.DECIMAL:
                    if (!Char.IsDigit(lastLetter) && lastLetter != REFERENCE_CHAR)
                    {
                        literalStr = literalStr.Substring(0, literalLength - 1);
                    }
                    parseResult = Double.TryParse(literalStr, NumberStyles.Number | NumberStyles.AllowExponent, NumberFormatInfo.InvariantInfo, out doubleValue);
                    constantValue = parseResult ? doubleValue : 0;
                    if (!parseResult)
                    {
                        AddNewError(LexicalError.New(LexicalErrorCode.InvalidDecimalConstant, xplLiteral, literalStr));
                    }
                    break;
                case XplLiteraltype_enum.OCT:
                    //PENDIENTE : parseo de constantes octales
                    //constantValue = Int32.Parse(literalStr.Substring(2), NumberStyle);
                    typeOfExp = NativeTypes.Long;
                    break;
                case XplLiteraltype_enum.HEX:
                    constantValue = Int64.Parse(literalStr.Substring(2), NumberStyles.AllowHexSpecifier, NumberFormatInfo.InvariantInfo);
                    typeOfExp = NativeTypes.Long;
                    break;
                case XplLiteraltype_enum.DATETIME:
                    constantValue = DateTime.Parse(literalStr, DateTimeFormatInfo.InvariantInfo);
                    break;
                case XplLiteraltype_enum.UUID:
                //PENDIENTE : parseo de constantes UUID 
                case XplLiteraltype_enum.NULL:
                case XplLiteraltype_enum.OTHER:
                default:
                    constantValue = literalStr;
                    break;
            }
            #endregion
            ExpressionResult result = new ExpressionResult(typeOfExp);
            result.set_IsConstant(true);
            result.set_ConstantValue(constantValue);
            result.set_ExpType(ExpressionResultType.Value);
            return result;
        }

        /// <summary>
        /// Returns the shortest integer type for provided constant value
        /// </summary>
        /// <param name="constantValue">Constant value</param>
        /// <returns>The native shortest integer type that can contain the provided value.</returns>
        private static string GetTypeForIntegerLiteral(long constantValue)
        {
            // TODO : implement using target output module numeric limits
            if (constantValue <= Byte.MaxValue) return NativeTypes.Byte;
            else if (constantValue <= Int16.MaxValue) return NativeTypes.Short;
            else if (constantValue <= Int32.MaxValue) return NativeTypes.Integer;
            else if (constantValue <= Int64.MaxValue) return NativeTypes.Long;
            else
            {
                // TODO : warning, possible overflow of literal
                return NativeTypes.Long;
            }
        }

        private ExpressionResult ProcessSimpleNameExpression(XplNode xplNode, Scope scope)
        {
            string nameToSearch = xplNode.get_StringValue();

            if (!this.CheckValidIdentifier(nameToSearch, xplNode, "In simple expression."))
            {
                // provide some name to allow compilation to continue
                xplNode.set_lddata(xplNode.get_lddata() + "$ORIGINAL_CONTENT(" + nameToSearch != null ? nameToSearch : String.Empty + ")$");
                xplNode.set_Value(ZOE_INVALID_IDENTIFIER);

                // return null exp result
                return null;
            }

            if (TypeString.IsQualifiedName(nameToSearch))
            {
                return ProcessSimpleNameExpressionForQualifiedName(xplNode, scope, nameToSearch);
            }
            else
            {
                return ProcessSimpleNameExpressionForSimpleName(xplNode, scope, nameToSearch);
            }
        }

        private static bool IsIntrinsicName(string nameToSearch, XplNode xplNode)
        {
            if (IsIntrinsicClosureName(nameToSearch)) return true;
            return false;
        }

        private static bool IsIntrinsicClosureName(string name)
        {
            return name == "Func" || name == "zoe::Func" || name == "zoe.Func";
        }

        private ExpressionResult ProcessSimpleNameExpressionForSimpleName(XplNode xplNode, Scope scope, string nameToSearch)
        {
            Symbol symbol = scope.get_Symbol(nameToSearch);
            XplExpression expNode = xplNode.get_Parent() as XplExpression;
            // 1) Search symbols on scope
            if (symbol != null)
            {
                expNode.set_targetMember(symbol.get_SymbolName());

                XplType symType = symbol.get_SymbolType();
                string expTypeStr;
                expTypeStr = symType.get_typeStr();
                if (String.IsNullOrEmpty(expTypeStr)) return null;
                else return new ExpressionResult(expTypeStr, ExpressionResultType.ValueOrLValue, symbol.get_SymbolType());
            }
            // 2) search members of current class
            TypeInfo type = (TypeInfo)p_types[scope.get_FullClassName()];
            ExpressionResult expRes = ProcessSimpleNameOnScope(xplNode, scope, nameToSearch, type, true);
            if (expRes != null)
            {
                return expRes;
            }
            else
            {
                // try members on outer types
                Scope searchScope = (Scope)scope.Clone();
                while (searchScope.IsBlock()) searchScope.LeaveScope();
                while (searchScope.get_ScopeLevel() > 0)
                {
                    type = (TypeInfo)p_types[searchScope.get_FullClassName()];
                    expRes = ProcessSimpleNameOnScope(xplNode, searchScope, nameToSearch, type, false);
                    if (expRes != null)
                    {
                        return expRes;
                    }
                    else
                    {
                        // 3) finally, search if it's a type in current scope
                        string fullTypeName = p_types.get_ExistingTypeName(nameToSearch, searchScope);
                        if (fullTypeName != null)
                        {
                            // Actualizo el nombre en código para q corresponda con un
                            // el nombre de tipos completo
                            xplNode.set_Value(fullTypeName);
                            type = (TypeInfo)p_types[fullTypeName];
                            // Chequeo que el tipo sea accesible en el alcance actual
                            if (TypeInfo.IsAccesible(type, scope))
                            {
                                expNode.set_targetClass(fullTypeName);

                                return new ExpressionResult(type);
                            }
                            else
                            {
                                AddNewError(
                                    SemanticError.New(SemanticErrorCode.InaccesibleType,
                                    xplNode, nameToSearch, "On simple name expression."));
                            }
                        }
                    }
                    searchScope.LeaveScope();
                }
            }

            // check for intrinsic names
            if (IsIntrinsicName(nameToSearch, xplNode)) return null;

            AddNewError(SemanticError.New(SemanticErrorCode.UnresolvedNameOnExpression,
                xplNode, nameToSearch));

            return null;
        }

        private ExpressionResult ProcessSimpleNameExpressionForQualifiedName(XplNode xplNode, Scope scope, string nameToSearch)
        {
            nameToSearch = GetInternalQualifiedName(nameToSearch);
            string memberOrTypeToSearch = GetSimpleNameFromQualified(nameToSearch);
            string typeToSearch = RemoveSimpleNameFromQualified(nameToSearch);
            string fullTypeName = p_types.get_ExistingTypeName(typeToSearch, scope);
            XplExpression simpleExp = xplNode.get_Parent() as XplExpression;

            // if type was not found try outer types
            if (fullTypeName == null)
            {
                Scope searchScope = (Scope)scope.Clone();
                while (searchScope.LeaveScope())
                {
                    fullTypeName = p_types.get_ExistingTypeName(typeToSearch, searchScope);
                    if (fullTypeName != null || searchScope.get_ScopeLevel() <= 1) break;
                }
            }
            // search members into the type (if type was found)
            if (fullTypeName != null)
            {
                // update the name in the code to corresponding full type name
                xplNode.set_Value(fullTypeName.Replace(".", "::") + "::" + memberOrTypeToSearch);
                TypeInfo typeInfo = (TypeInfo)p_types[fullTypeName];
                // first, search an inner type
                string typeName = Scope.MakeFullTypeName(fullTypeName, memberOrTypeToSearch);
                typeName = p_types.get_ExistingTypeName(typeName, scope);
                if (typeName != null)
                {
                    simpleExp.set_targetClass(typeName);

                    typeInfo = (TypeInfo)p_types[typeName];
                    if (TypeInfo.IsAccesible(typeInfo, scope))
                    {
                        return new ExpressionResult(typeInfo);
                    }
                    else
                    {
                        // check for intrinsic names
                        if (IsIntrinsicName(nameToSearch, xplNode)) return null;

                        AddNewError(
                            SemanticError.New(SemanticErrorCode.InaccesibleType,
                            xplNode, nameToSearch, "On simple name expression."));

                        return null;
                    }
                }
                else
                {
                    simpleExp.set_targetClass(fullTypeName);
                    simpleExp.set_targetMember("?");
                    // find members inside resolved type
                    MemberInfo[] members = typeInfo.get_MemberInfoCollection().get_MembersInfo(memberOrTypeToSearch);
                    if (members != null && members.Length > 0)
                    {
                        simpleExp.set_targetMember(memberOrTypeToSearch);
                        // filter inaccesible member
                        members = FilterAccesibleMembers(members, scope);
                        if (members == null)
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.InaccesibleTypeMember,
                                xplNode, memberOrTypeToSearch));

                            return null;
                        }
                        if (members != null)
                        {
                            return new ExpressionResult(members);
                        }
                    }

                    // check for intrinsic names
                    if (IsIntrinsicName(nameToSearch, xplNode)) return null;

                    AddNewError(
                        SemanticError.New(SemanticErrorCode.NonexistentMemberOfType, xplNode,
                        memberOrTypeToSearch, fullTypeName, GetSimilarMembersNames(typeInfo, memberOrTypeToSearch) + " On primary expression."));

                    // Add candidate structure call if type is a factory and has a default type constructor
                    if (typeInfo.get_IsFactory() && typeInfo.get_IsClass() && typeInfo.get_HasDefaultTypeConstructor())
                    {
                        CandidateStructure cs = new CandidateStructure(TypeNameContext.LocalVarDecl, xplNode, typeInfo);
                        p_candidateStructures.Add(cs);
                    }

                    return null;
                }
            }
            else
            {
                // check for intrinsic names
                if (IsIntrinsicName(nameToSearch, xplNode)) return null;

                AddNewError(
                    SemanticError.New(SemanticErrorCode.DeclaredTypeDoesnotExist, xplNode,
                    typeToSearch, "On primary expression."));

                return null;
            }
        }

        private ExpressionResult ProcessSimpleNameOnScope(XplNode xplNode, Scope scope, string nameToSearch, TypeInfo type, bool tryThis)
        {
            if (type != null && !type.get_IsNamespace())
            {
                //Luego busco
                MemberInfo[] members = type.get_MemberInfoCollection().get_MembersInfo(nameToSearch);
                if (members != null && members.Length > 0)
                {
                    //Si el contexto es un miembro de instancia debo filtrar los miembros no
                    //estaticos.
                    Symbol pThis = tryThis ? scope.get_Symbol("this") : null;
                    if (pThis == null)
                    {
                        members = FilterStaticMembers(members, scope, true);
                        if (members == null)
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.CannotAccessInstanceMemberFromStatic,
                                xplNode, nameToSearch));
                            return null;
                        }
                    }
                    if (members != null)
                    {
                        //Filtro los miembros inaccesibles por el nivel de acceso.
                        members = FilterAccesibleMembers(members, scope);
                        if (members == null)
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.InaccesibleTypeMember,
                                xplNode, nameToSearch));

                            return null;
                        }
                        members = FilterNonHiddenMembers(members, scope);
                        if (members != null)
                        {
                            // set meta info
                            XplExpression expNode = xplNode.get_Parent() as XplExpression;
                            MemberInfo targetMember = members[0];
                            expNode.set_targetClass(targetMember.get_DeclarationClassTypeFullName());
                            expNode.set_targetMember(targetMember.get_MemberName());

                            if (targetMember.IsStatic())
                            {
                                xplNode.set_Value(targetMember.FullName);
                            }

                            return pThis != null ? new ExpressionResult(members, true)
                                : new ExpressionResult(members);
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Devuelve un string type de acuerdo al tipo factory de "symType".
        /// Si "symType" no posee un modificador factory adecuado devuelve el 
        /// string type del tipo.
        /// 
        /// NO LLAMAR CON SYMTYPE NULO.
        /// </summary>
        private static string GetTypeStringForFactoryTypeModifier(XplType symType, Scope scope)
        {
            switch (symType.get_ftype())
            {
                case XplFactorytype_enum.NONE:
                    break;
                case XplFactorytype_enum.INAME:
                    return TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".IName");
                case XplFactorytype_enum.EXPRESSION:
                    return TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplExpression");
                case XplFactorytype_enum.EXPRESSIONLIST:
                    return TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplExpressionlist");
                case XplFactorytype_enum.STATEMENT:
                    return TypeString.MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplFunctionBody");
                default:
                    break;
            }
            return symType.get_typeStr();
        }
        #endregion

        #region ProcessUnaryOperatorExpression, ProcessBinaryOperatorExpression
        private ExpressionResult ProcessUnaryOperatorExpression(XplUnaryoperator xplUnaryoperator, Scope scope, TypeInfo classType, MemberInfo memberInfo)
        {
            ExpressionResult res = null;
            string opStr = ""; //Indica el operador unario que debera procesarse
            XplExpression unaryExp = xplUnaryoperator.get_u();
            if (unaryExp == null)
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.ExpressionRequired,
                    xplUnaryoperator));
                return res;
            }
            ExpressionResult expRes = ProcessExpression(unaryExp, scope, classType, memberInfo);
            if (expRes == null) return res;
            ExpressionResultType expResType = expRes.get_ExpType();
            string errorStr = "On unary operator '" + xplUnaryoperator.get_op().ToString() + "' expression.";
            string typeStr = "";

            switch (xplUnaryoperator.get_op())
            {
                #region Operadores Sobrecargables
                case XplUnaryoperators_enum.MIN:
                    opStr = "min";
                    break;
                case XplUnaryoperators_enum.INC:
                    opStr = "inc";
                    break;
                case XplUnaryoperators_enum.DEC:
                    opStr = "dec";
                    break;
                case XplUnaryoperators_enum.PREINC:
                    opStr = "inc";
                    break;
                case XplUnaryoperators_enum.PREDEC:
                    opStr = "dec";
                    break;
                case XplUnaryoperators_enum.ONECOMP:
                    opStr = "comp";
                    break;
                case XplUnaryoperators_enum.NOT:
                    opStr = "bneg";
                    break;
                #endregion

                #region Dereferencia de Puntero '*'
                case XplUnaryoperators_enum.IND:
                    if (expResType == ExpressionResultType.TypeMembers ||
                        expResType == ExpressionResultType.TypeMembersFromValue)
                    {
                        expRes = TryConvertTypeMembersToValueOrLValue(expRes, scope, unaryExp.get_Content());
                        expResType = expRes.get_ExpType();
                    }
                    if (expResType != ExpressionResultType.LValue &&
                        expResType != ExpressionResultType.Value &&
                        expResType != ExpressionResultType.ValueOrLValue)
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.ValueOrLValueRequiredAsOperand,
                            xplUnaryoperator, errorStr));
                        return res;
                    }
                    typeStr = expRes.get_TypeStr();
                    if (!TypeString.IsPointerType(typeStr))
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.InvalidPointerDereference,
                            xplUnaryoperator, "A Pointer or Reference value required to apply dereference.", errorStr));
                        return res;
                    }
                    if (TypeString.IsReferencePointerType(typeStr) && !scope.get_IsOnPointerScope())
                        typeStr = TypeString.RemoveReferencesFromType(typeStr, TypeString.RemoveReferenciesType.IndirectionOperator);
                    else
                        typeStr = TypeString.RemovePointerIndirectionsFromType(typeStr, 1);
                    res = new ExpressionResult(typeStr, ExpressionResultType.LValue);
                    break;
                #endregion

                #region Address Of
                case XplUnaryoperators_enum.AOF:
                    // if expression is typemembers, try to convert to value
                    if (expResType == ExpressionResultType.TypeMembers ||
                        expResType == ExpressionResultType.TypeMembersFromValue)
                    {
                        expRes = TryConvertTypeMembersToValueOrLValue(expRes, scope, unaryExp.get_Content());
                        expResType = expRes.get_ExpType();
                    }
                    if (expResType != ExpressionResultType.LValue &&
                        expResType != ExpressionResultType.ValueOrLValue)
                    {
                        // if it's not a value, it's only valid if it denotes a member of a class
                        if (expRes.get_IsTypeMembers() && expRes.get_Members().Length == 1)
                        {
                            // a pointer to a class member
                            typeStr = MakePointerTypeToMember(expRes.get_Members()[0], expResType == ExpressionResultType.TypeMembersFromValue);
                            res = new ExpressionResult(typeStr);
                            break;
                        }
                        else
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.LValueRequiredAsOperandOfAddressOfOperator,
                                xplUnaryoperator));
                            return res;
                        }
                    }
                    
                    typeStr = expRes.get_TypeStr();
                    if (TypeString.IsReferencePointerType(typeStr) && !scope.get_IsOnPointerScope())
                        typeStr = TypeString.RemoveReferencesFromType(typeStr, TypeString.RemoveReferenciesType.SimpleExpression);
                    typeStr = TypeString.MakePointerTypeTo(typeStr);
                    res = new ExpressionResult(typeStr);
                    break;
                #endregion

                //PENDIENTE : operadores RAOF, SIZEOF, TYPEOF
                case XplUnaryoperators_enum.RAOF:
                    break;
                case XplUnaryoperators_enum.SIZEOF:
                    break;
                case XplUnaryoperators_enum.TYPEOF:
                    break;
                default:
                    break;
            }

            #region Operadores Sobrecargables
            if (opStr != "") //Si se cumple es un operador sobrecargable.
            {
                TypeInfo operandType = null;
                string typeName = "", functionName = "%op_" + opStr + "%";
                bool typeRequired = true;
                if (expResType == ExpressionResultType.TypeMembers
                    || expResType == ExpressionResultType.TypeMembersFromValue)
                {
                    expRes = TryConvertTypeMembersToValueOrLValue(expRes, scope, unaryExp.get_Content());
                    expResType = expRes.get_ExpType();
                }
                if (expResType != ExpressionResultType.TypeMembers
                    && expResType != ExpressionResultType.TypeMembersFromValue)
                {
                    //Tengo un tipo para el operando izquierdo.
                    if (expResType == ExpressionResultType.Type)
                        operandType = expRes.get_Type();
                    else
                    {
                        typeName = expRes.get_TypeStr();
                        //Aqui chequeo si es una referencia o un puntero elimino dicha referencia o puntero
                        if (TypeString.IsReferencePointerType(typeName) && !scope.get_IsOnPointerScope()) typeName = TypeString.RemoveReferencesFromType(typeName, TypeString.RemoveReferenciesType.ExtractType);
                        else if (TypeString.IsPointerType(typeName) && !scope.get_IsOnPointerScope()) typeName = TypeString.RemovePointerIndirectionsFromType(typeName, 1);

                        typeRequired = !TypeString.IsPointerType(typeName) && !TypeString.IsArrayType(typeName);
                        typeName = p_types.get_ExistingTypeName(typeName, scope);
                        //Si no se encontro el tipo quiere decir que no exite el tipo del valor
                        if (typeName == null && typeRequired)
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.TypeRequired,
                                xplUnaryoperator, "Type of operand for unary operator '" + opStr + "' was not found."));
                            return res;
                        }
                        if (typeRequired) operandType = (TypeInfo)p_types[typeName];
                    }
                }
                else
                {
                    //Si el operando es un grupo de miembros
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.ValueOrLValueRequiredAsOperand,
                        xplUnaryoperator));
                    return res;
                }

                //1- Filtro todos los operadores en el tipo del operando "Izq" y en el operando "Der",
                //hago una unión de dichos miembros.
                //Filtro los miembros accesibles.
                //2- Si no hay miembros es un error.
                //2.1- Si hay más de un miembro resuelvo sobrecarga de los miembros.
                //3- Chequeo sea valida la llamada a función.
                MemberInfo[] candidateMembers = null;
                if (operandType != null) candidateMembers = operandType.get_MemberInfoCollection().get_MembersInfo(functionName);
                if (candidateMembers == null)
                {
                    //Primero cheque si ambos son punteros
                    if (TypeString.IsPointerType(expRes.get_TypeStr()))
                    {
                        //PENDIENTE : obtener los miembros cuando se aplican los operadores a punteros
                    }
                    else
                    {
                        //No se encontro ningun operador para los operandos.
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.UnaryOperatorWasNotFoundForCurrentOperand,
                            xplUnaryoperator, opStr, expRes.get_TypeStr()));
                        return res;
                    }
                }
                //Filtro los miembros inaccesibles por el nivel de acceso.
                //PENDIENTE : emitir errores cuando los miembros no sean accesibles
                candidateMembers = FilterAccesibleMembers(candidateMembers, scope);
                if (candidateMembers == null)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InaccesibleTypeMember,
                        xplUnaryoperator, opStr));
                    return res;
                }
                candidateMembers = FilterNonHiddenMembers(candidateMembers, scope);
                if (candidateMembers == null)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.UnaryOperatorWasNotFoundForCurrentOperand,
                        xplUnaryoperator, opStr, expRes.get_TypeStr()));
                    return res;
                }

                //Aqui tengo todos los miembros en "candidateMembers"

                //Primero lleno los argumentos de la XplFunctioncall que utilizo como PlaceHolder
                p_dummyUnaryOperatorFunctioncall.get_args().Children().Clear();
                XplExpression e = XplExpressionlist.new_e();
                //PENDIENTE : No utilizar clone, esto es muy lento!!
                //cambiarlo de alguna forma para mejorar el rendimiento
                e.set_Content(unaryExp.get_Content().Clone());
                e.set_typeStr(expRes.get_TypeStr());
                p_dummyUnaryOperatorFunctioncall.get_args().Children().InsertAtEnd(e);

                if (candidateMembers.Length > 1)
                {
                    //Tengo sobrecarga, debo resolver
                    candidateMembers = ResolveFunctionOverload(p_dummyUnaryOperatorFunctioncall, candidateMembers, scope, xplUnaryoperator);
                    //Si no obtengo como respuesta ningun miembro es un error
                    if (candidateMembers == null)
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.BestOverloadedFunctionHasSomeInvalidArguments,
                            xplUnaryoperator, opStr, errorStr));
                        return null;
                    }
                    //Si luego de resolver sigo teniendo varios miembros es ambiguo
                    if (candidateMembers.Length > 1)
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.AmbiguousFunctionCall, xplUnaryoperator, errorStr));
                        return null;
                    }
                }
                else
                {
                    if (!CheckArgumentsForFunction(p_dummyUnaryOperatorFunctioncall, candidateMembers[0], scope, true, false, xplUnaryoperator))
                        return res;
                }
                //PENDIENTE : convertir a llamadas a funcion cuando es necesario.
                MemberInfo selectedMember = candidateMembers[0];
                xplUnaryoperator.set_targetClass(selectedMember.get_DeclarationClassTypeFullName());
                xplUnaryoperator.set_targetMember(selectedMember.get_MemberInternalName());

                this.p_candidateStructures.AddCandidateStructure(selectedMember, xplUnaryoperator, scope);

                res = new ExpressionResult(((XplFunction)selectedMember.get_MemberNode()).get_ReturnType().get_typeStr());
            }
            #endregion

            return res;
        }

        private ExpressionResult ProcessBinaryOperatorExpression(XplBinaryoperator xplBinaryoperator, Scope scope, TypeInfo classType, MemberInfo memberInfo)
        {
            ExpressionResult res = null;
            XplExpression rightExp = xplBinaryoperator.get_r();
            XplExpression leftExp = xplBinaryoperator.get_l();

            if (rightExp == null || leftExp == null)
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.ExpressionRequired,
                    xplBinaryoperator));

                return res;
            }

            ExpressionResult leftRes = ProcessExpression(leftExp, scope, classType, memberInfo), rightRes = null;
            //ExpressionResult rightRes = ProcessExpression(xplBinaryoperator.get_r(), scope);

            string opStr = ""; //Indica el operador binario que debera procesarse
            //Si una de las expresiones devolvio null quiere decir que se produjo un error
            //y por tanto tampoco se procesará esta expresion
            if (leftRes != null)
            {
                switch (xplBinaryoperator.get_op())
                {
                    #region Operadores Aritmeticos
                    case XplBinaryoperators_enum.ADD:    //"+"
                        opStr = "add";
                        break;
                    case XplBinaryoperators_enum.MIN:    //"-"
                        opStr = "min";
                        break;
                    case XplBinaryoperators_enum.MUL:    //"*"
                        opStr = "mul";
                        break;
                    case XplBinaryoperators_enum.DIV:    //"/"
                        opStr = "div";
                        break;
                    case XplBinaryoperators_enum.MOD:    //"%" (modulo)
                        opStr = "mod";
                        break;
                    case XplBinaryoperators_enum.EXP:    //Exponente
                        opStr = "exp";
                        break;
                    #endregion

                    #region Operadores booleanos
                    case XplBinaryoperators_enum.AND:    //"&&"
                        opStr = "and";
                        break;
                    case XplBinaryoperators_enum.OR:     //"||"
                        opStr = "or";
                        break;
                    case XplBinaryoperators_enum.EQ:     //"=="
                        opStr = "eq";
                        break;
                    case XplBinaryoperators_enum.NOTEQ:  //"!="
                        opStr = "noteq";
                        break;
                    case XplBinaryoperators_enum.GR:     //">"
                        opStr = "gtr";
                        break;
                    case XplBinaryoperators_enum.LS:     //"<"
                        opStr = "lst";
                        break;
                    case XplBinaryoperators_enum.GREQ:   //">="
                        opStr = "greq";
                        break;
                    case XplBinaryoperators_enum.LSEQ:   //"<="
                        opStr = "lseq";
                        break;
                    #endregion

                    #region Operadores de bits
                    case XplBinaryoperators_enum.LSH:    //"<<"
                        opStr = "lsh";
                        break;
                    case XplBinaryoperators_enum.RSH:    //">>"
                        opStr = "rsh";
                        break;
                    case XplBinaryoperators_enum.BAND:   //"&" AND binario
                        opStr = "band";
                        break;
                    case XplBinaryoperators_enum.BOR:    //"|" OR binario
                        opStr = "bor";
                        break;
                    case XplBinaryoperators_enum.XOR:    //"^" XOR binario
                        opStr = "xor";
                        break;
                    #endregion

                    #region Acceso a Miembro
                    case XplBinaryoperators_enum.M:      //"." Acceso a miembro 
                        //Si es un TypeMembers intento resolverlo a un campo o propiedad
                        return ProcessSimpleMemberAccessBinaryOperator(xplBinaryoperator, scope, rightExp, leftExp, leftRes);

                    case XplBinaryoperators_enum.PM:     //"->" Acceso a miembro 
                        //Esto deberia ser igual que el acceso a miembro pero aplicando
                        //primero una dereferencia, por lo cual el miembro izquierdo debe ser de
                        //tipo puntero, de lo contrario si es otro tipo es un error.
                        return ProcessPointerMemberAccessBinaryOperator(xplBinaryoperator, scope, rightExp, leftExp, leftRes);

                    case XplBinaryoperators_enum.MP:     //".*" Acceso a miembro 
                        break;
                    case XplBinaryoperators_enum.PMP:    //"->*" Acceso a miembro 
                        break;
                    case XplBinaryoperators_enum.RM:     //"Reservado" Acceso a miembro 
                        return ProcessReservedMemberAccessBinaryOperator(xplBinaryoperator, scope, leftExp, leftRes, classType, memberInfo);
                    #endregion

                    #region Operadores "=>"
                    case XplBinaryoperators_enum.IMP:    //"=>" Nombre de argumento
                        //El operador "=>" cuando es procesado fuera de una llamada a función 
                        //devuelve el operando derecho
                        return ProcessExpression(rightExp, scope, classType, memberInfo);
                    #endregion

                    case XplBinaryoperators_enum.COMMA:
                        // return the result from right operator
                        return ProcessExpression(xplBinaryoperator.get_r(), scope, classType, memberInfo);
                    default:
                        break;
                }
                //Si estoy aqui debo preguntar si se trata de un operador que no sea de acceso miembro
                //chequeando el valor de opStr

                if (opStr != "")
                {
                    res = ProcessBinaryOperatorExpressionForOperator(xplBinaryoperator, opStr, rightRes, leftRes, rightExp, leftExp, scope, classType, memberInfo);
                }
            }
            else
            {
                switch (xplBinaryoperator.get_op())
                {
                    case XplBinaryoperators_enum.M:
                    case XplBinaryoperators_enum.PM:
                    case XplBinaryoperators_enum.MP:     //".*" Acceso a miembro 
                    case XplBinaryoperators_enum.PMP:    //"->*" Acceso a miembro 
                    case XplBinaryoperators_enum.RM:     //"Reservado" Acceso a miembro 
                        break;
                    default:
                        // process right expression when left is null in order to
                        // catch any classfactory call
                        ProcessExpression(rightExp, scope, classType, memberInfo);
                        break;
                }
            }

            return res;
        }

        private ExpressionResult ProcessPointerMemberAccessBinaryOperator(XplBinaryoperator xplBinaryoperator, Scope scope, XplExpression rightExp, XplExpression leftExp, ExpressionResult leftRes)
        {
            ExpressionResult res = null;

            if (leftRes.get_ExpType() == ExpressionResultType.TypeMembers
                || leftRes.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
                leftRes = TryConvertTypeMembersToValueOrLValue(leftRes, scope, leftExp.get_Content());

            if (leftRes.get_ExpType() == ExpressionResultType.TypeMembers
                || leftRes.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
            {   //Error no se permite una expresion de este tipo como operando izq                            
                AddNewError(
                    SemanticError.New(SemanticErrorCode.InvalidLeftExpressionOnPointerMemberAccess,
                    xplBinaryoperator));

                return res;
            }
            else if (leftRes.get_ExpType() == ExpressionResultType.Type)
            {   //No se permite un tipo del lado Izq.
                AddNewError(
                    SemanticError.New(SemanticErrorCode.TypeNotAllowedAsLeftExpOnPointerMemberAccess,
                    xplBinaryoperator));

                return res;
            }
            else
            {   //Es un Value o LValue, cualquiera de los dos es aceptable
                #region Value Or LValue
                string typeStr = leftRes.get_TypeStr(), backType;

                //Verifico si es un puntero
                if (!TypeString.IsPointerType(typeStr))
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidLeftExpressionOnPointerMemberAccess,
                        xplBinaryoperator));

                    return res;
                }
                else if (TypeString.IsReferencePointerType(typeStr))
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidLeftExpressionOnPointerMemberAccess,
                        xplBinaryoperator, "You can not use pointer member access with referencies, instead use simple member access."));

                    return res;
                }
                else
                {
                    //Es un puntero el tipo, hago una indirección
                    typeStr = TypeString.RemovePointerIndirectionsFromType(typeStr, 1);
                    if (TypeString.IsPointerType(typeStr))
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.MoreIndirectionsRequiredOnPointerMemberAccess,
                            xplBinaryoperator));

                        return res;
                    }
                }
                if (TypeString.IsArrayType(typeStr))
                {
                    //PENDIENTE : considerar cuando el array es declarado como
                    //un array nativo de C sin encapsular (o bien debo usar
                    //punteros directamente en ese caso?)
                    typeStr = NativeTypes.ArrayClassTypeName;
                }
                backType = typeStr;
                typeStr = p_types.get_ExistingTypeName(typeStr, scope);
                if (typeStr != null)
                {
                    XplNode rightNode = rightExp.get_Content();

                    if (rightNode == null)
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.ExpressionRequired,
                            rightExp));
                        return null;
                    }

                    if (rightNode.get_ElementName() != "n")
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.ANameRequiredAsRightExpression,
                            xplBinaryoperator, "On pointer member access expression."));

                        return res;
                    }
                    TypeInfo type = (TypeInfo)p_types[typeStr];
                    xplBinaryoperator.set_targetClass(typeStr);
                    xplBinaryoperator.set_targetMember("?");
                    string memberName = rightNode.get_StringValue();

                    if (!this.CheckValidIdentifier(memberName, rightNode, "In member access expression."))
                    {
                        // provide some name to allow compilation to continue
                        rightNode.set_lddata(rightNode.get_lddata() + "$ORIGINAL_CONTENT(" + memberName != null ? memberName : String.Empty + ")$");
                        rightNode.set_Value(ZOE_INVALID_IDENTIFIER);

                        // return null exp result
                        return null;
                    }

                    string className;
                    if (TypeString.IsQualifiedName(memberName))
                    {
                        className = RemoveSimpleNameFromQualified(GetInternalQualifiedName(memberName));
                        memberName = GetSimpleNameFromQualified(memberName);
                    }
                    else
                    {
                        className = String.Empty;
                    }
                    MemberInfo[] members = null;
                    if (className != String.Empty)
                        members = type.get_MemberInfoCollection().get_MembersInfo(memberName, className);
                    else
                    {
                        members = type.get_MemberInfoCollection().get_MembersInfo(memberName);
                        members = FilterNonHiddenMembers(members, scope);
                    }
                    if (members != null && members.Length > 0)
                    {
                        members = FilterInstanceMembers(members, scope);
                        if (members == null)
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.CannotAccessStaticMemberUsingInstanceValue,
                                xplBinaryoperator, memberName));

                            return res;
                        }
                        members = FilterAccesibleMembers(members, scope);
                        if (members == null)
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.InaccesibleTypeMember,
                                xplBinaryoperator, memberName));

                            return res;
                        }
                        xplBinaryoperator.set_targetMember(memberName);
                        res = new ExpressionResult(members, true);
                    }
                    else
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.NonexistentMemberOfType, xplBinaryoperator,
                            memberName, typeStr));

                        return res;
                    }
                }
                else
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.TypeRequired, xplBinaryoperator,
                        "The type '" + backType + "' was not found on pointer member access expression."));

                    return res;
                }

                return res;

                #endregion
            }
        }

        private ExpressionResult ProcessReservedMemberAccessBinaryOperator(XplBinaryoperator xplBinaryoperator, Scope scope, XplExpression leftExp, ExpressionResult leftRes, TypeInfo classType, MemberInfo memberInfo)
        {
            if (leftRes.get_ExpType() == ExpressionResultType.TypeMembers
                || leftRes.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
                leftRes = TryConvertTypeMembersToValueOrLValue(leftRes, scope, leftExp.get_Content());

            // a value is required
            if (leftRes.get_ExpType() == ExpressionResultType.TypeMembers
                || leftRes.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.ValueOrLValueRequiredAsOperand,
                    xplBinaryoperator));
                return null;
            }
            else if (leftRes.get_ExpType() == ExpressionResultType.Type)
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.TypeNotAllowedAsLeftExpOnPointerMemberAccess,
                    xplBinaryoperator));
                return null;
            }
            else
            {
                // left exp its a value
                string leftTypeStr = leftRes.get_TypeStr();
                if (String.IsNullOrEmpty(leftTypeStr))
                {
                    // TODO : add new error code for this
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.ValueOrLValueRequiredAsOperand,
                        xplBinaryoperator, "Value type is not known on special member access."));
                    return null;
                }
                if (TypeString.IsPointerType(leftTypeStr) && !TypeString.IsReferencePointerType(leftTypeStr))
                {
                    xplBinaryoperator.set_op(XplBinaryoperators_enum.PM);
                }
                else
                {
                    xplBinaryoperator.set_op(XplBinaryoperators_enum.M);
                }
                return ProcessBinaryOperatorExpression(xplBinaryoperator, scope, classType, memberInfo);
            }
        }

        private ExpressionResult ProcessSimpleMemberAccessBinaryOperator(XplBinaryoperator xplBinaryoperator, Scope scope, XplExpression rightExp, XplExpression leftExp, ExpressionResult leftRes)
        {
            ExpressionResult res = null;

            if (leftRes.get_ExpType() == ExpressionResultType.TypeMembers
                || leftRes.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
                leftRes = TryConvertTypeMembersToValueOrLValue(leftRes, scope, leftExp.get_Content());

            if (leftRes.get_ExpType() == ExpressionResultType.TypeMembers
                || leftRes.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
            {
                //Error no se permite una expresion de este tipo como operando izq                            
                AddNewError(
                    SemanticError.New(SemanticErrorCode.InvalidLeftExpressionOnSimpleMemberAccess,
                    xplBinaryoperator, "A value or type required as left operand of simple member access operator."));

                return res;
            }
            else if (leftRes.get_ExpType() == ExpressionResultType.Type)
            {
                //Solo se permite un tipo del lado Izq si el lenguaje permite utilizar "." como "::"
                #region Tipo

                if (p_programRequirements.get_UseSimpleMemberAccessAsNamespaceSeparator())
                {
                    XplNode rightNode = rightExp.get_Content();
                    if (rightNode == null || rightNode.get_ElementName() != "n")
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.ANameRequiredAsRightExpression,
                            xplBinaryoperator, "On simple member access expression."));

                        return res;
                    }

                    #region OLD CODE
                    // TODO : Check this!
                    TypeInfo type = leftRes.get_Type();
                    xplBinaryoperator.set_targetClass(type.get_FullName());
                    xplBinaryoperator.set_targetMember("?");

                    string memberName = rightNode.get_StringValue();
                    if (!this.CheckValidIdentifier(memberName, rightNode, "In member access expression."))
                    {
                        // provide some name to allow compilation to continue
                        rightNode.set_lddata(rightNode.get_lddata() + "$ORIGINAL_CONTENT(" + memberName != null ? memberName : String.Empty + ")$");
                        rightNode.set_Value("___zoe_invalid_identifier___");

                        // return null exp result
                        return null;
                    }

                    string className, simpleName;
                    if (TypeString.IsQualifiedName(memberName))
                    {
                        className = RemoveSimpleNameFromQualified(GetInternalQualifiedName(memberName));
                        simpleName = GetSimpleNameFromQualified(memberName);
                    }
                    else
                    {
                        className = String.Empty;
                    }
                    MemberInfo[] members = null;
                    if (type.get_IsNamespace())
                    {
                        string typeNameToSearch = Scope.MakeFullTypeName(type.get_FullName(), memberName);
                        typeNameToSearch = p_types.get_ExistingTypeName(typeNameToSearch, scope);
                        if (typeNameToSearch != null)
                        {
                            // TODO : check that the type is accesible
                            // return the type found
                            return new ExpressionResult((TypeInfo)p_types[typeNameToSearch]);
                        }
                        else
                        {
                            // name not resolved
                            AddNewError(SemanticError.New(SemanticErrorCode.UnresolvedNameOnExpression, xplBinaryoperator,
                            "Member '" + memberName + "' was not found on type '" + type.get_FullName() + "'.", GetSimilarMembersNames(type, memberName)));
                            return null;
                        }
                    }
                    else
                    {
                        if (className != String.Empty)
                            members = type.get_MemberInfoCollection().get_MembersInfo(memberName, className);
                        else
                            members = type.get_MemberInfoCollection().get_MembersInfo(memberName);
                    }

                    if (members == null)
                    {
                        // maybe an inner class
                        if (!type.get_IsNamespace())
                        {
                            string typeNameToSearch = Scope.MakeFullTypeName(type.get_FullName(), memberName);
                            typeNameToSearch = p_types.get_ExistingTypeName(typeNameToSearch, scope);
                            if (typeNameToSearch != null)
                            {
                                // TODO : check that the type is accesible
                                // return the type found
                                return new ExpressionResult((TypeInfo)p_types[typeNameToSearch]);
                            }
                        }
                        AddNewError(
                        SemanticError.New(SemanticErrorCode.UnresolvedNameOnExpression, xplBinaryoperator,
                        "Member '" + memberName + "' was not found on type '" + type.get_FullName() + "'.", GetSimilarMembersNames(type, memberName)));
                    }
                    else
                    {
                        // filter instance members
                        members = FilterStaticMembers(members, scope, false);
                        if (members == null)
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.CannotAccessInstanceMemberFromStatic,
                                xplBinaryoperator, memberName));
                            return res;
                        }
                        //Filtro los miembros inaccesibles por el nivel de acceso.
                        members = FilterAccesibleMembers(members, scope);
                        if (members == null)
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.InaccesibleTypeMember,
                                xplBinaryoperator, memberName));
                            return res;
                        }
                    }
                    if (members != null)
                    {
                        xplBinaryoperator.set_targetMember(memberName);
                        //xplBinaryoperator.set_targetMemberExternalName(selectedMember.get_MemberExternalName());
                        res = new ExpressionResult(members);
                    }
                    #endregion
                }
                else
                {
                    //Es un error si el lenguaje no soporta "." como "::".
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidSimpleMemberAccessUsedAsScopeAccess,
                        xplBinaryoperator));

                    return res;
                }

                #endregion
            }
            else
            {
                //Es un Value o Value, cualquiera de los dos es aceptable
                #region Value Or LValue
                string typeStr = leftRes.get_TypeStr(), backType;
                //Verifico si es una referencia o un valor
                if (TypeString.IsPointerType(typeStr) && !TypeString.IsReferencePointerType(typeStr))
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidLeftExpressionOnSimpleMemberAccess,
                        xplBinaryoperator, "You can not use simple member access with pointers types, instead use pointer member access or a pointer type with reference semantic."));

                    return res;
                }
                else if (TypeString.IsReferencePointerType(typeStr))
                {
                    typeStr = TypeString.RemoveReferencesFromType(typeStr, TypeString.RemoveReferenciesType.MemberAccess);
                }
                if (TypeString.IsArrayType(typeStr))
                {
                    //PENDIENTE : considerar cuando el array es declarado como
                    //un array nativo de C sin encapsular (o bien debo usar
                    //punteros directamente en ese caso?)
                    typeStr = NativeTypes.ArrayClassTypeName;
                }
                backType = typeStr;
                typeStr = p_types.get_ExistingTypeName(typeStr, scope);
                if (typeStr != null)
                {
                    XplNode rightNode = rightExp.get_Content();

                    if (rightNode == null)
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.ExpressionRequired,
                            rightExp));
                        return null;
                    }

                    if (rightNode.get_ElementName() != "n")
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.ANameRequiredAsRightExpression,
                            xplBinaryoperator, "On simple member access expression."));

                        return res;
                    }
                    TypeInfo type = (TypeInfo)p_types[typeStr];
                    xplBinaryoperator.set_targetClass(typeStr);
                    xplBinaryoperator.set_targetMember("?");

                    string memberName = rightNode.get_StringValue();
                    // TODO : fix with cache issue
                    // string memberAccessCacheStr = type.get_FullName() + "." + memberName;

                    string className;
                    MemberInfo[] members = null;

                    // PENDIENTE : Revisar el funcionamiento del chache de acceso a miembros,
                    // en algunos casos no funciona bien posiblemente pq algun cliente sobreescribe
                    // la matriz de miembros al obtenerlo. Adicionalmente verificar si se gana
                    // tiempo relevante en el procesamiento de programas tipicos y no casos
                    // especiales algunas pruebas con DataModel.dpp (proyecto Janus) no se
                    // nota ganancias medibles.
                    //if (!p_memberAccessCache.ContainsKey(memberAccessCacheStr))
                    //{
                    if (!this.CheckValidIdentifier(memberName, rightNode, "In member access expression."))
                    {
                        // provide some name to allow compilation to continue
                        rightNode.set_lddata(rightNode.get_lddata() + "$ORIGINAL_CONTENT(" + memberName != null ? memberName : String.Empty + ")$");
                        rightNode.set_Value(ZOE_INVALID_IDENTIFIER);

                        // return null exp result
                        return null;
                    }
                    if (TypeString.IsQualifiedName(memberName))
                    {
                        className = RemoveSimpleNameFromQualified(GetInternalQualifiedName(memberName));
                        memberName = GetSimpleNameFromQualified(memberName);
                    }
                    else
                    {
                        className = String.Empty;
                    }
                    if (className != String.Empty)
                        members = type.get_MemberInfoCollection().get_MembersInfo(memberName, className);
                    else
                    {
                        members = type.get_MemberInfoCollection().get_MembersInfo(memberName);
                        members = FilterNonHiddenMembers(members, scope);
                    }

                    //p_memberAccessCache.Add(memberAccessCacheStr, members);
                    //}
                    //else
                    //{
                    //    members = (MemberInfo[])p_memberAccessCache[memberAccessCacheStr];
                    //}
                    if (members != null && members.Length > 0)
                    {
                        members = FilterInstanceMembers(members, scope);
                        if (members == null)
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.CannotAccessStaticMemberUsingInstanceValue,
                                xplBinaryoperator, memberName));

                            return res;
                        }
                        members = FilterAccesibleMembers(members, scope);
                        if (members == null)
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.InaccesibleTypeMember,
                                xplBinaryoperator, memberName));

                            return res;
                        }
                        if (members.Length == 1) xplBinaryoperator.set_targetClass(members[0].get_DeclarationClassTypeFullName());
                        xplBinaryoperator.set_targetMember(memberName);
                        res = new ExpressionResult(members, true);
                    }
                    else
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.NonexistentMemberOfType, xplBinaryoperator,
                            memberName, typeStr, GetSimilarMembersNames(type, memberName)));

                        return res;
                    }
                }
                else
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.TypeRequired, xplBinaryoperator,
                        "The type '" + backType + "' was not found on simple member access expression."));

                    return res;
                }

                return res;

                #endregion
            }
            return res;
        }

        private ExpressionResult ProcessBinaryOperatorExpressionForOperator(XplBinaryoperator xplBinaryoperator, string opStr, ExpressionResult rightRes, ExpressionResult leftRes, XplExpression rightExp, XplExpression leftExp, Scope scope, TypeInfo classType, MemberInfo memberInfo)
        {
            ExpressionResult res = null;
            //Primero proceso la expresión derecha que estaba pendiente de procesar
            rightRes = ProcessExpression(rightExp, scope, classType, memberInfo);
            if (rightRes == null || leftRes == null)
            {
                //PENDIENTE : Emitir error cuando uno de los operandos sea nulo!!
                return res;
            }
            //Luego debo tratar de obtener un tipo de cada uno de los operandos, al menos de
            //uno de los operandos, el tipo lo puedo obtener si tengo una expresion de valor "type",
            //o un "LValue" o "Value" del tipo de dicho value o lvalue, si es un grupo de miembros
            //no puedo obtener el tipo.
            //Solo es un error si ambos operandos son de tipo grupo de miembros, de lo contrario
            //abre podido encontrar al menos un tipo y usare dicho tipo para buscar operadores,
            //o bien la union de los miembros de los dos tipos si encontre un tipo para cada
            //operando.
            //De esta forma los operadores pueden tomar cualquier cosa, por ejemplo un tipo
            //o una "void exp".

            #region Obtención de Tipos de Operandos Izquierdo y Derecho

            TypeInfo leftType = null, rightType = null;
            string typeName = "", functionName = "%op_" + opStr + "%";

            if (leftRes != null)
            {
                if (leftRes.get_ExpType() == ExpressionResultType.TypeMembers
                    || leftRes.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
                {
                    leftRes = TryConvertTypeMembersToValueOrLValue(leftRes, scope, leftExp.get_Content());
                }

                if (leftRes.get_ExpType() != ExpressionResultType.TypeMembers
                    && leftRes.get_ExpType() != ExpressionResultType.TypeMembersFromValue)
                {
                    //Tengo un tipo para el operando izquierdo.
                    if (leftRes.get_ExpType() == ExpressionResultType.Type)
                    {
                        leftType = leftRes.get_Type();
                    }
                    else
                    {
                        typeName = leftRes.get_TypeStr();
                        //****************************************
                        // Aqui No es Tan Sencillo,
                        // debo tener cuidado con el tema de los punteros,
                        // la lógica deberia ser la siguiente:
                        //     - Si es un estado "onPointer", no se 
                        //     dereferencia el puntero ni la referencia, sin 
                        //     importar el tipo de puntero.
                        //     - Si no es un estado "onPointer" se dereferencia la referencia o
                        //     el puntero, sólo si el tipo apuntado por el puntero
                        //     es no es ni un puntero ni un array, si es otra cosa,
                        //     es decir un tipo definido por el usuario o un tipo
                        //     nativo, si se dereferencia el puntero o referencia.
                        //     Si es referencia tengo que sacar todos los niveles de referencia
                        //     para obtener el tipo.
                        //     - Tambien tengo que considerar cuando los dos operandos son de tipo
                        //     puntero, en dicho caso debo usar un tipo especial de operador o 
                        //     bien hacer un procesamiento especial para dicho caso.
                        //****************************************
                        //Aqui chequeo si es una referencia o un puntero elimino dicha referencia o puntero
                        if (TypeString.IsReferencePointerType(typeName) && !scope.get_IsOnPointerScope()) typeName = TypeString.RemoveReferencesFromType(typeName, TypeString.RemoveReferenciesType.ExtractType);
                        else if (TypeString.IsPointerType(typeName) && !scope.get_IsOnPointerScope()) typeName = TypeString.RemovePointerIndirectionsFromType(typeName, 1);

                        if (TypeString.IsArrayType(typeName))
                        {
                            //PENDIENTE : considerar cuando el array es declarado como
                            //un array nativo de C sin encapsular (o bien debo usar
                            //punteros directamente en ese caso?)
                            typeName = NativeTypes.ArrayClassTypeName;
                            leftType = (TypeInfo)p_types[typeName];
                        }
                        else if (TypeString.IsPointerType(typeName))
                        {
                            // don't need type for pointers
                        }
                        else
                        {
                            // type required
                            typeName = p_types.get_ExistingTypeName(typeName, scope);
                            //Si no se encontro el tipo quiere decir que no exite el tipo del valor
                            if (typeName == null)
                            {
                                AddNewError(
                                    SemanticError.New(SemanticErrorCode.TypeRequired,
                                    xplBinaryoperator, "Type of left operand of operator '" + opStr + "' value was not found."));

                                return res;
                            }
                            leftType = (TypeInfo)p_types[typeName];
                        }
                    }
                }
                else
                {
                    AddNewError(SemanticError.New(SemanticErrorCode.ValueOrLValueRequiredAsOperand, 
                        rightExp, "For right expression of binary operator " + opStr + ". In " + xplBinaryoperator.CurrentExpression.ReadableString));
                    return res;
                }
            }

            //Lo mismo para el operando derecho
            if (rightRes != null)
            {
                if (rightRes.get_ExpType() == ExpressionResultType.TypeMembers
                    || rightRes.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
                {
                    rightRes = TryConvertTypeMembersToValueOrLValue(rightRes, scope, rightExp.get_Content());
                }
                if (rightRes.get_ExpType() != ExpressionResultType.TypeMembers
                    && rightRes.get_ExpType() != ExpressionResultType.TypeMembersFromValue)
                {
                    //Tengo un tipo para el operando izquierdo.
                    if (rightRes.get_ExpType() == ExpressionResultType.Type)
                    {
                        rightType = rightRes.get_Type();
                    }
                    else
                    {
                        typeName = rightRes.get_TypeStr();
                        //Aqui chequeo si es una referencia o un puntero elimino dicha referencia o puntero
                        if (TypeString.IsReferencePointerType(typeName) && !scope.get_IsOnPointerScope()) typeName = TypeString.RemoveReferencesFromType(typeName, TypeString.RemoveReferenciesType.ExtractType);
                        // only remove pointer indirection if it's not inside on pointer scope
                        else if (TypeString.IsPointerType(typeName) && !scope.get_IsOnPointerScope()) typeName = TypeString.RemovePointerIndirectionsFromType(typeName, 1);

                        if (TypeString.IsArrayType(typeName))
                        {
                            //PENDIENTE : considerar cuando el array es declarado como
                            //un array nativo de C sin encapsular (o bien debo usar
                            //punteros directamente en ese caso?)
                            typeName = NativeTypes.ArrayClassTypeName;
                            rightType = (TypeInfo)p_types[typeName];
                        }
                        else if (TypeString.IsPointerType(typeName))
                        {
                            // don't need type for pointers
                        }
                        else
                        {
                            typeName = p_types.get_ExistingTypeName(typeName, scope);
                            //Si no se encontro el tipo quiere decir que no exite el tipo del valor
                            if (typeName == null)
                            {
                                AddNewError(SemanticError.New(SemanticErrorCode.TypeRequired,
                                    xplBinaryoperator, "Type of right operand of operator '" + opStr + "' value was not found."));
                                return res;
                            }
                            rightType = (TypeInfo)p_types[typeName];
                        }
                    }
                }
                else
                {
                    AddNewError(SemanticError.New(SemanticErrorCode.ValueOrLValueRequiredAsOperand, 
                        leftExp, "For left expression of binary operator " + opStr + ". In " + xplBinaryoperator.CurrentExpression.ReadableString));
                    return res;
                }
            }

            #endregion

            MemberInfo selectedMember = null;
            string cacheSearchString = null;

            // search in cache of operators if both types exists
            if (leftType != null && rightType != null)
            {
                cacheSearchString = leftType.get_FullName() + "%" + opStr + "%" + rightType.get_FullName();
                if (p_operatorsCache[cacheSearchString] != null)
                {
                    selectedMember = (MemberInfo)p_operatorsCache[cacheSearchString];
                    xplBinaryoperator.set_targetClass(selectedMember.get_DeclarationClassTypeFullName());
                    xplBinaryoperator.set_targetMember(selectedMember.get_MemberInternalName());
                    xplBinaryoperator.set_targetMemberExternalName(selectedMember.get_MemberExternalName());

                    this.p_candidateStructures.AddCandidateStructure(selectedMember, xplBinaryoperator, scope);

                    res = new ExpressionResult(((XplFunction)selectedMember.get_MemberNode()).get_ReturnType().get_typeStr());

                    return res;
                }
            }

            // Obtención de Miembros Candidatos
            MemberInfo[] candidateMembers = null;
            res = ObtainBinaryOperatorCandidateMembers(xplBinaryoperator, opStr, rightRes, leftRes, scope, leftType, rightType, functionName, out candidateMembers);
            if (res != null || candidateMembers == null) return res;

            return ResolveBinaryOperatorMembersOverloading(xplBinaryoperator, opStr, rightRes, leftRes, rightExp, leftExp, scope, selectedMember, cacheSearchString, candidateMembers);
        }

        private ExpressionResult ObtainBinaryOperatorCandidateMembers(XplBinaryoperator xplBinaryoperator, string opStr, ExpressionResult rightRes, ExpressionResult leftRes, Scope scope, TypeInfo leftType, TypeInfo rightType, string functionName, out MemberInfo[] candidateMembers)
        {
            candidateMembers = null;
            if (p_customBinaryOperators.ContainsKey(functionName))
            {
                ArrayList operators = (ArrayList)p_customBinaryOperators[functionName];
                candidateMembers = new MemberInfo[operators.Count];
                operators.CopyTo(candidateMembers);
            }
            candidateMembers = FilterAccesibleMembers(candidateMembers, scope);
            if (candidateMembers == null)
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.InaccesibleTypeMember,
                    xplBinaryoperator, opStr, leftRes != null ? leftRes.get_TypeStr() : ""));
                return null;
            }
            candidateMembers = FilterNonHiddenMembers(candidateMembers, scope);
            if (candidateMembers == null)
            {
                //No se encontro ningun operador para los operandos.
                AddNewError(
                    SemanticError.New(SemanticErrorCode.BinaryOperatorWasNotFoundForCurrentOperands,
                    xplBinaryoperator, opStr, leftRes != null ? leftRes.get_TypeStr() : "", rightRes != null ? rightRes.get_TypeStr() : ""));

                return null;
            }
            return null;
        }

        private ExpressionResult ResolveBinaryOperatorMembersOverloading(XplBinaryoperator xplBinaryoperator, string opStr, ExpressionResult rightRes, ExpressionResult leftRes, XplExpression rightExp, XplExpression leftExp, Scope scope, MemberInfo selectedMember, string cacheSearchString, MemberInfo[] candidateMembers)
        {
            ExpressionResult res = null;

            //Aqui tengo todos los miembros en "candidateMembers"
            MemberInfo[] backup = candidateMembers;

            //Primero lleno los argumentos de la XplFunctioncall que utilizo como PlaceHolder
            p_dummyBinaryOperatorFunctioncall.get_args().Children().Clear();
            XplExpression e = XplExpressionlist.new_e();
            //PENDIENTE : No utilizar clone, esto es muy lento!!
            //cambiarlo de alguna forma para mejorar el rendimiento
            e.set_Content(leftExp.get_Content().Clone());
            //e.set_typeStr(leftExp.get_typeStr());
            e.set_typeStr(leftRes.get_TypeStr());
            p_dummyBinaryOperatorFunctioncall.get_args().Children().InsertAtEnd(e);
            e = XplExpressionlist.new_e();
            //PENDIENTE : No utilizar clone, esto es muy lento!!
            //cambiarlo de alguna forma para mejorar el rendimiento
            e.set_Content(rightExp.get_Content().Clone());
            //e.set_typeStr(rightExp.get_typeStr());
            e.set_typeStr(rightRes.get_TypeStr());
            p_dummyBinaryOperatorFunctioncall.get_args().Children().InsertAtEnd(e);

            string errorStr = "On binary operator '" + opStr + "' expression.";
            if (candidateMembers.Length > 1)
            {
                // Tengo sobrecarga, debo resolver
                candidateMembers = ResolveFunctionOverload(p_dummyBinaryOperatorFunctioncall, candidateMembers, scope, xplBinaryoperator);
                // Si no obtengo como respuesta ningun miembro es un error
                if (candidateMembers == null)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.BestOverloadedFunctionHasSomeInvalidArguments,
                        xplBinaryoperator, opStr, errorStr /*+ MemberInfo.ToString(backup)*/ ));

                    return null;
                }
                //Si luego de resolver sigo teniendo varios miembros es ambiguo
                if (candidateMembers.Length > 1)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.AmbiguousFunctionCall, xplBinaryoperator, errorStr + MemberInfo.ToString(candidateMembers)));

                    return null;
                }
            }
            else
            {
                if (!CheckArgumentsForFunction(p_dummyBinaryOperatorFunctioncall, candidateMembers[0], scope, true, false, xplBinaryoperator))
                {

                    return res;
                }
            }
            //PENDIENTE : controlar si en los requerimientos del modulo de salida
            //es necesario marcar la clase de llamada y el miembro objetivo o no.
            //PENDIENTE : convertir a llamadas a funcion cuando es necesario.

            selectedMember = candidateMembers[0];
            this.p_candidateStructures.AddCandidateStructure(selectedMember, xplBinaryoperator, scope);
            if (cacheSearchString != null)
            {
                p_operatorsCache.Add(cacheSearchString, selectedMember);
            }

            xplBinaryoperator.set_targetClass(selectedMember.get_DeclarationClassTypeFullName());
            xplBinaryoperator.set_targetMember(selectedMember.get_MemberInternalName());
            xplBinaryoperator.set_targetMemberExternalName(selectedMember.get_MemberExternalName());

            res = new ExpressionResult(((XplFunction)selectedMember.get_MemberNode()).get_ReturnType().get_typeStr());

            return res;
        }

        private static string GetSimilarMembersNames(TypeInfo type, string memberName)
        {
            return null;
            // TODO : show similar member names?
            //
            /*
            string res = "";
            res = type.get_MemberInfoCollection().ExistAnyMemberInfoNameLike(memberName, 0.3);
            if (res != null)
                return "Similar member names are " + res + ".";
            else
                return "There are not similar member names.";
             */
        }
        #endregion

        private ExpressionResult ProcessNewExpression(XplNewExpression xplNewExpression, Scope scope, TypeInfo classType, MemberInfo memberInfo)
        {
            CheckType(xplNewExpression.get_type(), xplNewExpression, scope, false, "On 'new' expression.");
            if (xplNewExpression.get_type() == null) return null;
            string typeStr = xplNewExpression.get_type().get_typeStr();
            if (typeStr == null || typeStr == "") return null;
            string fullTypeStr = null;
            if (TypeString.IsArrayType(typeStr))
            {
                // it's an array
                CheckInitializer(xplNewExpression, scope, classType, memberInfo);
                // find the elements' type
                string elementTypeStr = TypeString.RemoveAllDimensionsFromArrayType(typeStr);
                while (TypeString.IsPointerType(elementTypeStr)) elementTypeStr = TypeString.RemovePointerIndirectionsFromType(elementTypeStr, 1);
                fullTypeStr = p_types.get_ExistingTypeName(elementTypeStr, scope);
                if (fullTypeStr == null)
                {
                    //Esto nunca deberia ocurrir! ya que se chequeo el tipo antes
                    AddNewError(SemanticError.New(SemanticErrorCode.TypeRequired,
                        xplNewExpression, "On 'new' expression, the type \"" + elementTypeStr + "\" was not found."));
                    return null;
                }
                // check type for elements
                TypeInfo type = (TypeInfo)p_types[fullTypeStr];
                if (type.get_IsClass() || type.get_IsStruct() || type.get_IsEnum() || type.get_IsFPType())
                {
                    if (!type.get_IsFPType())
                    {
                        XplClass clase = (XplClass)type.get_TypeNode();
                        if (clase.get_abstract())
                        {
                            AddNewError(SemanticError.New(SemanticErrorCode.InvalidInstantiationOfAbstractType,
                                xplNewExpression.get_type(), fullTypeStr));
                            return null;
                        }
                    }
                    //Aqui tengo que chequear que exista un constructor adecuado para el inicializador proporcionado.
                    CheckForConstructor(xplNewExpression, scope, type, null);
                }
                return new ExpressionResult(TypeString.MakeReferenceTypeTo(typeStr), ExpressionResultType.Value);
            }
            else if (TypeString.IsPointerType(typeStr))
            {
                // It's a pointer
                if (TypeString.IsReferencePointerType(typeStr)) typeStr = TypeString.ChangeReferenceToPointer(typeStr);
                // TODO : check base pointer type for typeconstructor, arguments (that will be an error)
                return new ExpressionResult(TypeString.MakeReferenceTypeTo(typeStr), ExpressionResultType.Value);
            }
            else
            {
                //Es una clase o tipo nativo
                if (NativeTypes.IsNativeVoid(typeStr))
                {
                    AddNewError(SemanticError.New(SemanticErrorCode.InvalidTypeForNewExpression,
                        xplNewExpression.get_type(), typeStr));
                    return null;
                }
                fullTypeStr = p_types.get_ExistingTypeName(typeStr, scope);
                if (fullTypeStr == null)
                {
                    //Esto nunca deberia ocurrir! ya que se chequeo el tipo antes
                    AddNewError(SemanticError.New(SemanticErrorCode.TypeRequired,
                        xplNewExpression, "On 'new' expression, the type \"" + typeStr + "\" was not found."));
                    return null;
                }
                TypeInfo type = (TypeInfo)p_types[fullTypeStr];
                if (type.get_IsClass() || type.get_IsStruct() || type.get_IsEnum() || type.get_IsFPType())
                {
                    if (!type.get_IsFPType())
                    {
                        XplClass clase = (XplClass)type.get_TypeNode();
                        if (clase.get_abstract())
                        {
                            AddNewError(SemanticError.New(SemanticErrorCode.InvalidInstantiationOfAbstractType,
                                xplNewExpression.get_type(), fullTypeStr));
                            return null;
                        }
                    }
                    //Aqui tengo que chequear que exista un constructor adecuado para el inicializador proporcionado.
                    CheckInitializer(xplNewExpression, scope, type);
                    // PENDIENTE : chequear si nunca voy a dejar crear instancias de estructuras en el monton
                    if (type.get_IsStruct())
                        return new ExpressionResult(typeStr, ExpressionResultType.Value);
                    else
                        return new ExpressionResult(TypeString.MakeReferenceTypeTo(typeStr), ExpressionResultType.Value);
                }
                else
                {
                    AddNewError(SemanticError.New(SemanticErrorCode.InvalidTypeForNewExpression,
                        xplNewExpression.get_type(), typeStr, "A class, struct, enum or function pointer is required."));
                    return null;
                }
            }
        }
        private void CheckInitializer(XplNewExpression xplNewExpression, Scope scope, TypeInfo type)
        {
            XplInitializerList init = xplNewExpression.get_init();
            if (init != null && init.get_array())
            {
                AddNewError(SemanticError.New(SemanticErrorCode.UnexpectedArrayInitializer,
                    init, "On new expression."));
                return;
            }
            CheckForConstructor(xplNewExpression, scope, type, init);
        }

        private void CheckForConstructor(XplNewExpression xplNewExpression, Scope scope, TypeInfo type, XplInitializerList init)
        {
            //set semantic info
            XplExpression newExpression = xplNewExpression.get_Parent() as XplExpression;
            newExpression.set_targetClass(type.get_FullName());
            newExpression.set_targetMember(String.Empty);

            //Resuelvo la sobrecarga de función
            XplNodeList args = p_dummyNewExpressionFunctioncall.get_args().Children();
            p_dummyNewExpressionFunctioncall.set_name(type.get_Name());
            args.Clear();
            if (init != null)
            {
                XplNodeList newArguments = ((XplInitializerList)init.Children().FirstNode()).Children();
                ProcessArguments(newArguments, scope, type, null);
                args.Clear();
                foreach (XplNode argument in newArguments)
                {
                    //PENDIENTE : No utilizar clone, esto es muy lento!!
                    //cambiarlo de alguna forma para mejorar el rendimiento
                    args.InsertAtEnd(argument.Clone());
                }
            }

            CheckForConstructor(xplNewExpression, scope, type, args, "On new expression.");
            
            //PENDIENTE : controlar si en los requerimientos del modulo de salida
            //es necesario marcar el constructor objetivo o no.
            //PENDIENTE : convertir a llamadas a funcion cuando es necesario.
            //            
            //xplFunctioncall.set_targetClass(constructors[0].get_DeclarationClassTypeFullName());
            //xplFunctioncall.set_targetMember(constructors[0].get_MemberName());
        }

        private void CheckForConstructor(XplNewExpression newExpressionNode, Scope scope, TypeInfo type, XplNodeList args, string errorStr)
        {
            // try to find a constructor
            MemberInfo[] constructors = type.get_MemberInfoCollection().get_MembersInfo(type.get_Name());
            constructors = FilterInstanceMembers(constructors, scope);
            if (constructors == null)
            {
                //Valido si utilizo constructor por defecto
                if (args == null || args.GetLength() == 0)
                    //OK usando constructor por defecto
                    return;
            }

            constructors = FilterAccesibleMembers(constructors, scope);
            if (constructors == null)
            {
                AddNewError(SemanticError.New(SemanticErrorCode.ConstructorNotAvailableDueToItsProtectionLevel,
                    newExpressionNode, type.get_Name()));
                return;
            }

            if (constructors.Length > 1)
            {
                //Tengo sobrecarga, debo resolver
                constructors = ResolveFunctionOverload(p_dummyNewExpressionFunctioncall, constructors, scope, null);
                //Si no obtengo como respuesta ningun miembro es un error
                if (constructors == null)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.BestOverloadedFunctionHasSomeInvalidArguments,
                        newExpressionNode, type.get_Name(), errorStr));
                    return;
                }
                //Si luego de resolver sigo teniendo varios miembros es ambiguo
                if (constructors.Length > 1)
                {
                    if (constructors.Length == 2)
                    {
                        // remove simple typeconstructor "type ClassName(){}"
                        if (constructors[0].get_ReturnType() != null && constructors[1].get_ReturnType() != null)
                        {
                            // TODO : implement this
                        }
                    }
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.AmbiguousFunctionCall, newExpressionNode, errorStr));
                    return;
                }

                // set semantic info
                (newExpressionNode.get_Parent() as XplExpression).set_targetMember(constructors[0].get_MemberInternalName());
            }
            else
            {
                // set semantic info
                (newExpressionNode.get_Parent() as XplExpression).set_targetMember(constructors[0].get_MemberInternalName());

                if (!CheckArgumentsForFunction(p_dummyNewExpressionFunctioncall, constructors[0], scope, true, false, newExpressionNode))
                    return;
            }

            XplType retType = constructors[0].get_ReturnType();
            if (retType != null && type.get_IsFactory() &&
                ((NativeTypes.IsNativeVoid(retType.get_typeStr()) && retType.get_ftype() == XplFactorytype_enum.EXPRESSION)
                || NativeTypes.IsNativeType(retType.get_typeStr())))
            {
                this.p_candidateStructures.AddCandidateStructure(constructors[0], newExpressionNode, scope);
            }
        }

        private ExpressionResult ProcessAssingExpression(XplAssing xplAssing, Scope scope, TypeInfo classType, MemberInfo memberInfo)
        {
            ExpressionResult leftRes = ProcessExpression(xplAssing.get_l(), scope, classType, memberInfo);
            ExpressionResult rightRes = null;

            if (xplAssing.get_operation() != XplAssingop_enum.NONE)
            {
                // create a binary expression with: left exp [+,*,/,..] right exp
                XplBinaryoperator bopExp = new XplBinaryoperator((XplExpression)xplAssing.get_l().Clone(), xplAssing.get_r());
                bopExp.set_ElementName("bo");
                bopExp.set_op(ConvertAssignOperatorToBinaryOperator(xplAssing.get_operation()));
                xplAssing.set_r(new XplExpression(bopExp));
                // process the expression
                rightRes = ProcessExpression(xplAssing.get_r(), scope, classType, memberInfo);
                // restore original structure of assign node
                xplAssing.set_r(bopExp.get_r());
            }
            else
            {
                rightRes = ProcessExpression(xplAssing.get_r(), scope, classType, memberInfo);
            }

            if (leftRes != null && rightRes != null)
            {
                if (leftRes.get_ExpType() == ExpressionResultType.TypeMembers
                    || leftRes.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
                    leftRes = TryConvertTypeMembersToValueOrLValue(leftRes, scope, xplAssing);
                if (rightRes.get_ExpType() == ExpressionResultType.TypeMembers
                    || rightRes.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
                    rightRes = TryConvertTypeMembersToValueOrLValue(rightRes, scope, xplAssing.get_r().get_Content());

                if (leftRes.get_ExpType() != ExpressionResultType.ValueOrLValue &&
                    leftRes.get_ExpType() != ExpressionResultType.LValue)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.LValueRequiredAsLeftOperatorOfAssingment, xplAssing));
                    return null;
                }
                if (rightRes.get_ExpType() != ExpressionResultType.Value
                    && rightRes.get_ExpType() != ExpressionResultType.ValueOrLValue)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.ValueRequiredAsRightOperatorOfAssingment, xplAssing));
                    return null;
                }
                // update type str of expressions
                xplAssing.get_l().set_typeStr(leftRes.get_TypeStr());
                xplAssing.get_r().set_typeStr(rightRes.get_TypeStr());

                if (!IsSameStringType(leftRes.get_TypeStr(), rightRes.get_TypeStr()))
                {
                    //Intento conversion implicita del operando derecho
                    ConversionData cdata = ExistsImplicitConversion(rightRes.get_TypeStr(), leftRes.get_TypeStr(), xplAssing.get_r(), scope);
                    if (cdata != null)
                    {
                        MarkConversion(cdata, rightRes.get_TypeStr(), leftRes.get_TypeStr(), xplAssing.get_r(), scope);
                    }
                    else
                    {
                        //Si sigo sin coincidir no puedo asignar
                        if (leftRes.get_TypeStr() != rightRes.get_TypeStr())
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.IncompatibleTypesForAssingment,
                                xplAssing, rightRes.get_TypeStr(), leftRes.get_TypeStr()));
                    }
                }
            }
            else
            {
                //PENDIENTE : que hacer cuando tenemos resultados nulos???
                if (rightRes != null)
                {
                    if (rightRes.get_ExpType() == ExpressionResultType.TypeMembers
                        || rightRes.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
                        rightRes = TryConvertTypeMembersToValueOrLValue(rightRes, scope, xplAssing.get_r().get_Content());
                    xplAssing.get_r().set_typeStr(rightRes.get_TypeStr());
                }
                if (leftRes != null)
                {
                    if (leftRes.get_ExpType() == ExpressionResultType.TypeMembers
                        || leftRes.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
                        leftRes = TryConvertTypeMembersToValueOrLValue(leftRes, scope, xplAssing);
                    xplAssing.get_l().set_typeStr(leftRes.get_TypeStr());
                }
            }
            return leftRes;
        }

        private static XplBinaryoperators_enum ConvertAssignOperatorToBinaryOperator(XplAssingop_enum xplAssingop_enum)
        {
            switch (xplAssingop_enum)
            {
                case XplAssingop_enum.NONE:
                    throw new ArgumentException();
                case XplAssingop_enum.ADD:
                    return XplBinaryoperators_enum.ADD;
                case XplAssingop_enum.SUB:
                    return XplBinaryoperators_enum.MIN;
                case XplAssingop_enum.MUL:
                    return XplBinaryoperators_enum.MUL;
                case XplAssingop_enum.DIV:
                    return XplBinaryoperators_enum.DIV;
                case XplAssingop_enum.MOD:
                    return XplBinaryoperators_enum.MOD;
                case XplAssingop_enum.LSH:
                    return XplBinaryoperators_enum.LSH;
                case XplAssingop_enum.RSH:
                    return XplBinaryoperators_enum.RSH;
                case XplAssingop_enum.AND:
                    return XplBinaryoperators_enum.BAND;
                case XplAssingop_enum.XOR:
                    return XplBinaryoperators_enum.XOR;
                case XplAssingop_enum.OR:
                    return XplBinaryoperators_enum.BOR;
                default:
                    throw new SemanticException("Internal error on ConvertAssignOperatorToBinaryOperator");
            }
        }

        private ExpressionResult ProcessOnpointerExpression(XplExpression xplExpression, Scope scope, TypeInfo classType, MemberInfo memberInfo)
        {
            scope.set_IsOnPointerScope(true);
            ExpressionResult result = ProcessExpression((XplExpression)xplExpression.get_Content(), scope, classType, memberInfo);
            scope.set_IsOnPointerScope(false);
            return result;
        }
        /// <summary>
        /// Marca la conversion aplicada en xplExpression
        /// para convertirla de "fromType" a "toType".
        /// Sólo tiene efecto en la generación de código extendido.
        /// </summary>
        private static void MarkConversion(ConversionData conversionData, string fromType, string toType, XplExpression xplExpression, Scope scope)
        {
            //PENDIENTE : Implementar marcado de conversión.
        }
        /// <summary>
        /// Intenta convertir el resultado de la expresion "xplExpression" del tipo
        /// TypeMembers al tipo LValue, ValueOrLValue o Value.
        /// </summary>
        private ExpressionResult TryConvertTypeMembersToValueOrLValue(ExpressionResult expRes, Scope scope, XplNode nodeForCandidateStructure)
        {
            if (expRes.get_ExpType() != ExpressionResultType.TypeMembers
                && expRes.get_ExpType() != ExpressionResultType.TypeMembersFromValue) return expRes;

            MemberInfo[] members = expRes.get_Members();
            if (members.Length > 1) return expRes;
            MemberInfo member = members[0];
            if (member.get_IsBadMember()) return expRes;
            if (member.IsProperty())
            {
                XplProperty property = (XplProperty)member.get_MemberNode();
                string typeStr = FixTypeStringForType(property.get_type());
                expRes.set_TypeStr(typeStr);
                expRes.set_TypeNode(property.get_type());
                if (nodeForCandidateStructure != null)
                {
                    // TODO : check this, must take into account exec types
                    if (member.get_DeclarationClassType().get_IsFactory() &&
                        member.get_DeclarationClassTypeFullName() != scope.get_FullClassName() &&
                        !property.get_isexec())
                    {
                        this.p_candidateStructures.AddCandidateStructure(member, nodeForCandidateStructure, scope);
                    }
                }
                //PENDIENTE : DEBO MARCAR EL RESULTADO PARA INDICAR QUE ES UNA PROPIEDAD Y POR
                //TANTO NO SE PUEDE OBTENER LA DIRECCION CON EL OPERADOR UNARIO '&'.
                ExpressionResultType result = ExpressionResultType.ValueOrLValue;
                if (member.get_GetBlock() == null) result = ExpressionResultType.LValue;
                if (member.get_SetBlock() == null) result = ExpressionResultType.Value;
                expRes.set_ExpType(result);
                expRes.set_Members(null);
            }
            else if (member.IsIndexer())
            {
                XplFunction indexer = (XplFunction)member.get_MemberNode();
                string typeStr = FixTypeStringForType(indexer.get_ReturnType());
                expRes.set_TypeStr(typeStr);
                expRes.set_TypeNode(indexer.get_ReturnType());
                // TODO : DEBO MARCAR EL RESULTADO PARA INDICAR QUE ES UNA PROPIEDAD Y POR
                //TANTO NO SE PUEDE OBTENER LA DIRECCION CON EL OPERADOR UNARIO '&'.
                // TODO : implement addcandidatestructure
                ExpressionResultType result = ExpressionResultType.ValueOrLValue;
                if (member.get_GetBlock() == null) result = ExpressionResultType.LValue;
                if (member.get_SetBlock() == null) result = ExpressionResultType.Value;
                expRes.set_ExpType(result);
                expRes.set_Members(null);
            }
            else if (member.IsField())
            {
                XplField field = (XplField)member.get_MemberNode();
                string typeStr = FixTypeStringForType(field.get_type());
                expRes.set_TypeStr(typeStr);
                expRes.set_TypeNode(field.get_type());
                expRes.set_ExpType(ExpressionResultType.ValueOrLValue);
                expRes.set_Members(null);
            }
            return expRes;
        }

        private string FixTypeStringForType(XplType type)
        {
            string typeStr = type.get_typeStr();
            if (String.IsNullOrEmpty(typeStr))
            {
                typeStr = CalculeTypeString(type, null, false, new Scope(p_types));
                type.set_typeStr(typeStr);
            }
            return typeStr;
        }
        #endregion
    }
}
