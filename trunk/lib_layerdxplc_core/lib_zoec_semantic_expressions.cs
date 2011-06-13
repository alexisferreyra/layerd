/*******************************************************************************
* Copyright (c) 2007, 2008 Alexis Ferreyra.
* All rights reserved. This program and the accompanying materials
* are made available under the terms of the Eclipse Public License v1.0
* which accompanies this distribution, and is available at
* http://www.eclipse.org/legal/epl-v10.html
*
* Contributors:
*     Alexis Ferreyra - initial API and implementation
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
        #region Process para Expresiones
        /// <summary>
        /// Llama a "ProcessExpression" por cada expresión 
        /// en la lista, si la lista es nula retorna.
        /// </summary>
        private void ProcessExpressionList(XplExpressionlist el, Scope currentScope)
        {
            if (el.Children() == null) return;
            XplNodeList list = el.Children();
            foreach (XplExpression exp in list)
                ProcessExpression(exp, currentScope);
        }
        private void CheckForBoolExpression(XplExpression boolExp, Scope currentScope, string errorStr, XplNode statementNode)
        {
            if (boolExp == null)
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.ExpressionRequired,
                    statementNode, errorStr));
            }
            else
            {
                ExpressionResult boolExpRes = ProcessExpression(boolExp, currentScope);
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
                        ConversionData cdata = ExistsImplicitConversion(expTypeStr, NativeTypes.Boolean, currentScope);
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
        private ExpressionResult ProcessExpression(XplExpression xplExpression, Scope currentScope)
        {
            return ProcessExpression(xplExpression, currentScope, SemanticAction.CheckImplementation);
        }
        private ExpressionResult ProcessExpression(XplExpression xplExpression, Scope currentScope, SemanticAction semanticAction)
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
                        expResult = ProcessAssingExpression((XplAssing)exp, currentScope);
                        break;
                    case "new":     //new
                        expResult = ProcessNewExpression((XplNewExpression)exp, currentScope);
                        break;
                    case "bo":      //Operador Binario
                        expResult = ProcessBinaryOperatorExpression((XplBinaryoperator)exp, currentScope);
                        break;
                    case "to":      //Operador Binario
                        expResult = ProcessTernaryOperatorExpression((XplTernaryoperator)exp, currentScope);
                        break;
                    case "uo":      //Operador Unario
                        expResult = ProcessUnaryOperatorExpression((XplUnaryoperator)exp, currentScope);
                        break;
                    case "b":       //Llamada a funcion con []
                        expResult = ProcessBracketExpression((XplFunctioncall)exp, currentScope);
                        break;
                    case "n":       //Simple expression, nombre
                        expResult = ProcessSimpleNameExpression((XplNode)exp, currentScope);
                        break;
                    case "lit":     //literal
                        expResult = ProcessLiteralExpression((XplLiteral)exp, currentScope);
                        break;
                    case "fc":      //Llamada a funcion con ()
                        expResult = ProcessFunctioncallExpression((XplFunctioncall)exp, currentScope);
                        break;
                    case "cfc":     //Llamada a funcion compleja
                        expResult = ProcessComplexFunctioncallExpression((XplComplexfunctioncall)exp, currentScope);
                        break;
                    case "cast":    //cast
                        expResult = ProcessCastExpression((XplCastexpression)exp, currentScope);
                        break;
                    case "delete":  //delete
                        expResult = ProcessDeleteExpression((XplExpression)exp, currentScope);
                        break;
                    case "onpointer":   //onpointer
                        expResult = ProcessOnpointerExpression((XplExpression)exp, currentScope);
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
                        expResult = ProcessIsExpression((XplCastexpression)exp, currentScope);
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
                        if (!currentScope.get_IsOnPointerScope() && IsReferencePointerType(expResult.get_TypeStr()))
                            expResult.set_TypeStr(RemoveReferencesFromType(expResult.get_TypeStr(), RemoveReferenciesType.SimpleExpression));
                        xplExpression.set_typeStr(expResult.get_TypeStr());
                        // save constant value on expression node
                        if (expResult.get_IsConstant())
                        {
                            xplExpression.set_valueStr(expResult.get_ConstantValueAsString());
                        }
                    }
                }
                return expResult;
            }
            return null;
        }

        private ExpressionResult ProcessTernaryOperatorExpression(XplTernaryoperator xplTernaryoperator, Scope currentScope)
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
                    "First expression of ternary operator must be a boolean value.",
                    xplTernaryoperator.get_o1());

                // evaluate second and third operands
                ExpressionResult o2Res = ProcessExpression(xplTernaryoperator.get_o2(), currentScope);
                ExpressionResult o3Res = ProcessExpression(xplTernaryoperator.get_o3(), currentScope);
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
                    ConversionData convFromO2ToO3 = ExistsImplicitConversion(o2TypeStr, o3TypeStr, currentScope);
                    ConversionData convFromO3ToO2 = ExistsImplicitConversion(o3TypeStr, o2TypeStr, currentScope);
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
            ExpressionResult res = new ExpressionResult(MakeReferenceTypeTo(
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
                if (IsQualifiedName(name))
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
                ProcessSimpleNameExpression(new XplNode("n", symbolName), currentScope);
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
                    IsSameStringType(symTypeStr, MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplType")) /*||
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
                    IsSameStringType(symTypeStr, MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplFunctionBody")) /*||
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
                    IsSameStringType(symTypeStr, MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplExpression")) /*||
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
                   IsSameStringType(symTypeStr, MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplIName")) /*||
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
                    IsSameStringType(symTypeStr, MakeReferenceTypeTo(NativeTypes.String)) ||
                    IsSameStringType(symTypeStr, MakeReferenceTypeTo(NativeTypes.ASCIIString)))
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
                IsSameStringType(symType.get_typeStr(), MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplExpression")) ||
                IsSameStringType(symType.get_typeStr(), MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplType")) ||
                IsSameStringType(symType.get_typeStr(), MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplFunctionBody")) ||
                IsSameStringType(symType.get_typeStr(), MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplIName")) ||
                //Esto es por una limitacion en el writecode
                //que deberia implementarse fuera del analizador semantico
                //luego de todos los ciclos de compilacion, o bien 
                //en el ultimo ciclo de compilacion.
                IsSameStringType(symType.get_typeStr(), MakeReferenceTypeTo("XplExpression")) ||
                IsSameStringType(symType.get_typeStr(), MakeReferenceTypeTo("XplType")) ||
                IsSameStringType(symType.get_typeStr(), MakeReferenceTypeTo("XplIName")) ||
                IsSameStringType(symType.get_typeStr(), MakeReferenceTypeTo("XplFunctionBody")))
                return true;
            return false;
        }

        private ExpressionResult ProcessTypeOfExpression(XplType typeNode, Scope currentScope)
        {
            //La expresion typeof(exp) es implementada como un operador unario!
            ExpressionResult res = null;
            int backErrorCount = p_errorCollection.Count;
            CheckType(typeNode, typeNode, currentScope, false, "On \"typeof\" expression.");

            if (backErrorCount == p_errorCollection.Count)
                //Devuelvo un valor del tipo utilizado en tiempo de ejecución para 
                //representar un tipo de datos.
                res = new ExpressionResult(p_runtimeTypeForType, ExpressionResultType.Value);
            else
                res = null;
            return res;
        }
        private ExpressionResult ProcessIsExpression(XplCastexpression xplCastexpression, Scope currentScope)
        {
            //PENDINETE : revisar semantica de expresión IS cuando se posea la especificación más 
            //detallada del funcionamiento esperado.
            ExpressionResult res = null;
            int backErrorCount = p_errorCollection.Count;
            XplType typeNode = xplCastexpression.get_type();
            if (typeNode != null)
            {
                CheckType(typeNode, typeNode, currentScope, false, "On \"is\" expression.");

                XplExpression isExp = xplCastexpression.get_e();
                if (isExp != null)
                {
                    ExpressionResult expRes = ProcessExpression(isExp, currentScope);
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
        private ExpressionResult ProcessCastExpression(XplCastexpression xplCastexpression, Scope currentScope)
        {
            if (!CalculeTypeString(xplCastexpression.get_type(), currentScope))
                //El tipo esta mal definido, la expresion es incorrecta por tanto.
                return null;
            string castToType = xplCastexpression.get_type().get_typeStr();

            // check for type constructor
            CheckForTypeConstructorCallOrSymbol(xplCastexpression.get_type(), currentScope, null);

            ExpressionResult castExpRes = ProcessExpression(xplCastexpression.get_e(), currentScope);
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
                ConversionData cdata = ExistsExplicitConversion(castFromType, castToType, currentScope);
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
        private ExpressionResult ProcessComplexFunctioncallExpression(XplComplexfunctioncall xplComplexfunctioncall, Scope currentScope)
        {
            //PENDIENTE : Expresión de llamada a función compleja.
            ExpressionResult leftResult = ProcessExpression(xplComplexfunctioncall.get_l(), currentScope);
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
                        members = FilterStaticMembers(members, currentScope);
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
                            AddCandidateStructure(members[0], xplComplexfunctioncall, currentScope);
                        //PENDIENTE : controlar si en los requerimientos del modulo de salida
                        //es necesario marcar la clase de llamada y el miembro objetivo o no.
                        //xplFunctioncall.set_targetClass(members[0].get_DeclarationClassTypeFullName());
                        //xplFunctioncall.set_targetMember(members[0].get_MemberInternalName());
                        return new ExpressionResult(((XplFunction)members[0].get_MemberNode()).get_ReturnType().get_typeStr());
                    }
                }
            return null;
        }
        private ExpressionResult ProcessBracketExpression(XplFunctioncall xplFunctioncall, Scope currentScope)
        {
            ExpressionResult leftResult = ProcessExpression(xplFunctioncall.get_l(), currentScope);
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
                    if (IsPointerType(typeStr) && !IsReferencePointerType(typeStr) ||
                        IsPointerType(typeStr) && currentScope.get_IsOnPointerScope())
                    {
                        //Aquí es una indización en un puntero
                        //PENDIENTE : chequear si el modulo de salida permite aritmetica
                        //de puntero y emitir errores.
                        if (CheckValidArgumentForArrayAccessOrPointerIndexing(xplFunctioncall, currentScope))
                            return new ExpressionResult(RemovePointerIndirectionsFromType(typeStr, 1)
                                , ExpressionResultType.ValueOrLValue);
                    }
                    else
                    {
                        if (IsReferencePointerType(typeStr))
                            typeStr = RemoveReferencesFromType(typeStr, RemoveReferenciesType.ArrayAccess);
                        if (IsArrayType(typeStr))
                        {
                            //Es una matriz, debo devolver el tipo de elemento de la matriz y chequear que
                            //exista un único argumento y sea de tipo entero o long, o convertible.
                            //PENDIENTE : chequear accesos fuera de rango con matrices estaticas??
                            typeStr = RemoveArrayTypeFromType(typeStr);
                            if (CheckValidArgumentForArrayAccessOrPointerIndexing(xplFunctioncall, currentScope))
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
                                    ProcessArguments(xplFunctioncall, currentScope);
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
        private void ProcessArguments(XplNodeList arguments, Scope currentScope)
        {
            XplExpression argExp;
            ExpressionResult expRes;
            foreach (XplExpression arg in arguments)
            {
                argExp = arg;
                if (IsNamedArgument(arg)) argExp = GetNamedArgumentExpression(arg);
                expRes = ProcessExpression(arg, currentScope);
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
                        if (!currentScope.get_IsOnPointerScope() && IsReferencePointerType(expRes.get_TypeStr()))
                            expRes.set_TypeStr(RemoveReferencesFromType(expRes.get_TypeStr(), RemoveReferenciesType.SimpleExpression));
                        argExp.set_typeStr(expRes.get_TypeStr());
                    }
                }

            }
        }
        private void ProcessArguments(XplFunctioncall xplFunctioncall, Scope currentScope)
        {
            ProcessArguments(xplFunctioncall.get_args().Children(), currentScope);
        }
        private bool CheckValidArgumentForArrayAccessOrPointerIndexing(XplFunctioncall xplFunctioncall, Scope scope)
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
                ExpressionResult argResult = ProcessExpression(arg, scope);
                if (argResult != null)
                {
                    argResult = TryConvertTypeMembersToValueOrLValue(argResult, scope, arg.get_Content());
                    ExpressionResultType argResultType = argResult.get_ExpType();
                    if (argResultType == ExpressionResultType.Value || argResultType == ExpressionResultType.ValueOrLValue)
                    {
                        string argTypeStr = argResult.get_TypeStr();
                        if (!NativeTypes.IsNativeLong(argTypeStr) && !NativeTypes.IsNativeInteger(argTypeStr))
                        {
                            if (ExistsImplicitConversion(argTypeStr, NativeTypes.Long, scope) == null)
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
        private ExpressionResult ProcessFunctioncallExpression(XplFunctioncall xplFunctioncall, Scope scope)
        {
            ExpressionResult leftResult = ProcessExpression(xplFunctioncall.get_l(), scope);
            //Evaluo las expresiones de los argumentos
            //Evaluate this before to allow classfactorys to consult type of arguments even
            //if the member does not exist or is a undefined call
            if (xplFunctioncall.get_args() != null)
            {
                ProcessArguments(xplFunctioncall, scope);
            }
            if (leftResult != null)
                if (leftResult.get_ExpType() != ExpressionResultType.TypeMembers &&
                    leftResult.get_ExpType() != ExpressionResultType.TypeMembersFromValue)
                    //PENDIENTE : chequear cuando la expresión izquierda es un valor de tipo puntero a función.
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.InvalidLeftExpressionOnFunctionCallOperator, xplFunctioncall));
                else
                {
                    MemberInfo[] members = leftResult.get_Members();
                    //Seteo info provisoria
                    xplFunctioncall.set_targetClass(members[0].get_DeclarationClassTypeFullName());
                    xplFunctioncall.set_targetMember("?");

                    string memberName = members[0].get_MemberName();
                    if (leftResult.get_ExpType() == ExpressionResultType.TypeMembers)
                        members = FilterStaticMembers(members, scope);
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
                            if (!CheckArgumentsForFunction(xplFunctioncall, members[0], scope, true, false, xplFunctioncall)) return null;
                    }
                    if (!members[0].IsMethod())
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.InvalidMemberTypeUsedAsMethod, xplFunctioncall, members[0].get_MemberName()));
                    else
                    {
                        return ProcessFunctioncallExpressionCommonEnd(xplFunctioncall, scope, members[0]);
                    }
                }
            return null;
        }

        private ExpressionResult ProcessFunctioncallExpressionCommonEnd(XplFunctioncall xplFunctioncall, Scope scope, MemberInfo member)
        {
            if (member.IsFactory() || member.get_ClassType().get_IsFactory())
            {
                //Aqui primero debe chequear q no sea una funcion miembro de la clase actual :-)
                //estatica ni una función que se llame usando this, lo q puedo hacer es q directamente
                //al declarar el puntero this utilice el modificador exec.
                if (member.get_ClassTypeFullName() != scope.get_FullClassName())
                    AddCandidateStructure(member, xplFunctioncall, scope);
            }
            else if (member.get_DeclarationClassType().get_IsFactory())
            {
                if (member.get_DeclarationClassTypeFullName() != scope.get_FullClassName())
                    AddCandidateStructure(member, xplFunctioncall, scope);
            }
            //PENDIENTE : controlar si en los requerimientos del modulo de salida
            //es necesario marcar la clase de llamada y el miembro objetivo o no.
            xplFunctioncall.set_targetClass(member.get_DeclarationClassTypeFullName());
            xplFunctioncall.set_targetMember(member.get_MemberInternalName());
            xplFunctioncall.set_targetMemberExternalName(member.get_MemberExternalName());
            return new ExpressionResult(((XplFunction)member.get_MemberNode()).get_ReturnType().get_typeStr());
        }

        /// <summary>
        /// Adds a new candidate structure for a property or indexer
        /// </summary>
        /// <param name="memberInfo">Member info that must be a property or an indexer</param>
        /// <param name="xplNode">Node that reference to a left expression of an assignment, to a simple name expression, or to a member access expression</param>
        /// <param name="scope">scope information</param>
        private void AddCandidateStructure(MemberInfo memberInfo, XplNode xplNode, Scope scope)
        {
            if (memberInfo.get_IsExternal()) return;
            if (p_interactiveOnly && !memberInfo.get_DeclarationClassType().get_IsInteractive()) return;
            CandidateStructure cs = null;
            if (memberInfo.get_ClassType().get_IsFactory())
                cs = new CandidateStructure(xplNode, memberInfo.get_ClassType(), memberInfo);
            else
                cs = new CandidateStructure(xplNode, memberInfo.get_DeclarationClassType(), memberInfo);
            p_candidateStructures.Add(cs);
        }
        /// <summary>
        /// Agrega una estructura candidata a la colección.
        /// 
        /// memberInfo: miembro de classfactory llamado
        /// xplFunctioncall: la llamada a función
        /// scope: el alcance actual
        /// </summary>
        private void AddCandidateStructure(MemberInfo memberInfo, XplFunctioncall xplFunctioncall, Scope scope)
        {
            if (memberInfo.get_IsExternal()) return;
            if (p_interactiveOnly && !memberInfo.get_DeclarationClassType().get_IsInteractive()) return;
            CandidateStructure cs = null;
            if (memberInfo.get_ClassType().get_IsFactory())
                cs = new CandidateStructure(xplFunctioncall, memberInfo.get_ClassType(), memberInfo);
            else
                cs = new CandidateStructure(xplFunctioncall, memberInfo.get_DeclarationClassType(), memberInfo);
            p_candidateStructures.Add(cs);
        }
        /// <summary>
        /// Agrega una estructura candidata a la colección.
        /// </summary>
        private void AddCandidateStructure(MemberInfo memberInfo, XplNewExpression xplNewExpression, Scope scope)
        {
            if (p_interactiveOnly && !memberInfo.get_DeclarationClassType().get_IsInteractive()) return;
            CandidateStructure cs = new CandidateStructure(xplNewExpression, memberInfo.get_ClassType(), memberInfo);
            p_candidateStructures.Add(cs);
        }
        /// <summary>
        /// Agrega una estructura candidata a la colección.
        /// </summary>
        private void AddCandidateStructure(MemberInfo memberInfo, XplComplexfunctioncall xplFunctioncall, Scope scope)
        {
            if (p_interactiveOnly && !memberInfo.get_DeclarationClassType().get_IsInteractive()) return;
            CandidateStructure cs = new CandidateStructure(xplFunctioncall, memberInfo.get_ClassType(), memberInfo);
            p_candidateStructures.Add(cs);
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
            else return members;
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
            if (ExistsImplicitConversion(FromTypeA, FromTypeB, scope) != null
                && ExistsImplicitConversion(FromTypeB, FromTypeA, scope) == null) return 1;
            if (ExistsImplicitConversion(FromTypeB, FromTypeA, scope) != null
                && ExistsImplicitConversion(FromTypeA, FromTypeB, scope) == null) return 0;
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
            //parameters.Children().getLenght()
            if (maxArgs == 0 || (args != null && !IsNamedArgument((XplExpression)args.Children().FirstNode())))
            {   //Argumentos sin nombrar
                #region Argumentos Sin Nombrar
                int currentParam = 0;
                int currentArg = 0;
                XplParameter lastParam = null;
                if (args != null)
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
                                  memberInfo.get_MemberName(), "More arguments than expected."));
                            return false;
                        }
                        if (!CheckValidArgumentForParameter(arg, lastParam, isVarArgs && maxArgs >= maxParams && currentArg >= maxParams, isVarArgs && maxArgs == maxParams && currentArg == maxParams, scope))
                        {
                            if (emitErrors) AddNewError(
                                SemanticError.New(SemanticErrorCode.InvalidArgumentTypeForActualParameter, errorNode != null ? errorNode : arg,
                                lastParam.get_name(), arg.get_typeStr(), lastParam.get_type().get_typeStr()));
                            return false;
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
                #endregion
            }
            else
            {
                //Argumentos Nombrados
                #region Argumentos Nombrados
                #endregion
            }
            return true;
        }
        /// <summary>
        /// Determina si "param" es un parametro con valor por defecto.
        /// </summary>
        private bool IsParameterWithDefaultValue(XplParameter param)
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
                    argument.set_lddata(argument.get_lddata() + "$INOUT_ARG$");
                }
                else if (paramDirection == XplParameterdirection_enum.OUT)
                {
                    argument.set_lddata(argument.get_lddata() + "$OUT_ARG$");
                }
                //PENDIENTE : procesaro correctamente cuando el parametro es de tipo factory
                //bool isIname, isIn, isOut, isBlock, isExec;
                if (ft != XplFactorytype_enum.NONE)
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
                if (isVarParam) paramTypeStr = RemoveArrayTypeFromType(paramTypeStr);
                if (IsSameStringType(argTypeStr, paramTypeStr)) return true;
                //No es el mismo tipo, debo verificar si existe una conversion implicita
                if (ExistsImplicitConversion(argTypeStr, paramTypeStr, scope) != null) return true;
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
        private ConversionData ExistsExplicitConversion(string fromType, string toType, Scope scope)
        {
            ConversionData res = null;
            //1°) Primero busco en las conversiones implicitas nativas
            res = ExistNativeImplicitConversion(fromType, toType, scope);
            if (res != null)
            {
                res.ConversionType = ConversionType.NativeExplicitConversion;
                return res;
            }
            //2º) Busco en conversion implicitas inversamente :-)
            res = ExistNativeImplicitConversion(toType, fromType, scope);
            if (res != null)
                res.ConversionType = ConversionType.NativeExplicitConversion;
            //3°) Busco si es una conversion de enumeracion a entero o de enumeracion a otro tipo enumeracion
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
            //4°) Busco conversión implicita definida por el usuario
            if (res == null)
                res = ExistUserExplicitConversion(fromType, toType, scope);
            return res;
        }
        private ConversionData ExistUserExplicitConversion(string fromType, string toType, Scope scope)
        {
            //PENDIENTE : Conversiones Explicitas definidas por el usuario
            return null;
        }
        /// <summary>
        /// Indica si existe una conversion implicita en el alcance desde el tipo "fromType" al
        /// tipo "toType".
        /// 
        /// No llamar con cadenas nulas o vacias!!
        /// </summary>
        private ConversionData ExistsImplicitConversion(string fromType, string toType, Scope scope)
        {
            ConversionData res = null;
            //1°) Primero busco en las conversiones implicitas nativas
            res = ExistNativeImplicitConversion(fromType, toType, scope);
            //2°) Busco conversión implicita definida por el usuario
            if (res == null)
                res = ExistUserImplicitConversion(fromType, toType, scope);
            return res;
        }
        private ConversionData ExistUserImplicitConversion(string fromType, string toType, Scope scope)
        {
            //PENDIENTE : Conversiones Implicitas definidas por el usuario
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
            if (NativeTypes.IsNativeNull(fromType) && IsPointerType(toType))
                return new ConversionData(ConversionType.NativeImplicitConversion,
                    conversionString != String.Empty, false, null);
            //2º) Busco si es una conversion de referencia nativa (*Derivada -> *Base)
            if (IsPointerType(fromType) && IsPointerType(toType))
            {
                if (IsPointerToArrayType(fromType) && IsPointerToArrayType(toType))
                {
                    string fromTypeClass = RemovePointerIndirectionsFromType(fromType, 1);
                    string toTypeClass = RemovePointerIndirectionsFromType(toType, 1);
                    //Chequeo si se puede convertir implicitamente de un tipo puntero de matriz
                    //a otro.
                    if (GetArrayDimensions(fromTypeClass) == GetArrayDimensions(toTypeClass))
                    {
                        fromTypeClass = RemoveAllDimensionsFromArrayType(fromTypeClass);
                        toTypeClass = RemoveAllDimensionsFromArrayType(toTypeClass);
                        if (IsPointerType(fromTypeClass) && IsPointerType(toTypeClass))
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
            if (!IsPointerType(toType) && !IsArrayType(toType) && IsExplicitPointerToMember(fromType))
            {
                TypeInfo fpType = p_types.get_TypeInfo(toType);
                if (fpType != null && fpType.get_IsFPType())
                {
                    if (ExistsConversionBetweenFP(fpType, RemovePointerIndirectionsFromType(fromType, 1)))
                        return new ConversionData(ConversionType.NativeImplicitConversion, false, false, null);
                }
            }
            //4°) Determino si es una conversión de empaquetado
            if (IsSameStringType(toType, MakePointerTypeTo(NativeTypes.Object))
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
                if (IsPointerToArrayType(fromType))
                {
                    //PENDIENTE : Debo chequear que la clase base usada para matrices sea derivada 
                    //de object.¿¿???
                    return new ConversionData(ConversionType.NativeImplicitConversion,
                        false, false, null);
                }
                else if (IsPointerType(fromType))
                {
                    //Debo ver si es de más de un nivel para que sea valido
                    if (IsPointerType(RemovePointerIndirectionsFromType(fromType, 1)))
                        return new ConversionData(ConversionType.NativeImplicitConversion,
                            true, false, null);
                }
                else if (!IsArrayType(fromType))
                {
                    //Es un valor, ya sea una structura o enumeracion, tipo basico no
                    //porque debe de haber encontrado la conversión implicita antes.
                    TypeInfo type = (TypeInfo)p_types[fromType];
                    if (type != null && (type.get_IsEnum() || type.get_IsStruct()))
                        return new ConversionData(ConversionType.NativeImplicitConversion,
                            true, false, null);
                }
            }
            //5°) Es una conversión de un puntero a *void?
            if (IsPointerType(fromType) && IsSameStringType(MakePointerTypeTo(NativeTypes.Void), toType)
                && !p_programRequirements.get_DisableAllPointerConversionsToVoid())
            {
                //Conversion a void*
                //PENDIENTE : que el nodo para el error exista
                AddNewError(SemanticWarning.New(
                    SemanticWarningCode.UnsafeConversionFromPointerToGenericVoidPointer, null, fromType));
                return new ConversionData(ConversionType.NativeImplicitConversion,
                    false, false, null);
            }
            return null;
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
        private bool IsExplicitPointerToMember(string typeStr)
        {
            if (!IsPointerType(typeStr)) return false;
            string toTypeStr = RemovePointerIndirectionsFromType(typeStr, 1);
            if (IsPointerType(toTypeStr) || IsArrayType(toTypeStr)) return false;
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
            Debug.Assert(IsPointerType(pointerToBase) && IsPointerType(pointerToDerived), "ERROR INTERNO: mal uso de IsPointerToBaseOrInterfaceOf.");
            pointerToBase = RemovePointerIndirectionsFromType(pointerToBase, 1);
            pointerToDerived = RemovePointerIndirectionsFromType(pointerToDerived, 1);
            //PENDIENTE : Aca debo considerar cuando quiero convertir un puntero a una matriz
            //a un puntero a "object"
            if (IsPointerType(pointerToBase) || IsPointerType(pointerToDerived)
                || IsArrayType(pointerToBase) || IsArrayType(pointerToDerived)) return false;


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
            if (xplExpression.get_Content().get_ElementName() == "bo" && ((XplBinaryoperator)xplExpression.get_Content()).get_op() == XplBinaryoperators_enum.IMP)
                return true;
            return false;
        }
        /// <summary>
        /// Devuelve el "nombre" del argumento nombrado.
        /// 
        /// NO LLAMAR CON UNA EXPRESION QUE NO SEA UN ARGUMENTO NOMBRADO.
        /// </summary>
        private string GetNamedArgumentName(XplExpression argExpression)
        {
            return ((XplBinaryoperator)argExpression.get_Content()).get_l().get_Content().get_StringValue();
        }
        /// <summary>
        /// Devuelve la "expresion" del argumento nombrado.
        /// 
        /// NO LLAMAR CON UNA EXPRESION QUE NO SEA UN ARGUMENTO NOMBRADO.
        /// </summary>
        private XplExpression GetNamedArgumentExpression(XplExpression argExpression)
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
        private MemberInfo[] FilterNonHiddenMembers(MemberInfo[] members, Scope scope)
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
        private MemberInfo[] FilterStaticMembers(MemberInfo[] members, Scope scope)
        {
            if (members == null) return null;
            int index = 0, currentIndex = 0;
            foreach (MemberInfo member in members)
            {
                if (member.IsStatic())
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
        private MemberInfo[] FilterInstanceMembers(MemberInfo[] members, Scope scope)
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
        private MemberInfo[] FilterAccesibleMembers(MemberInfo[] members, Scope scope)
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
                            typeOfExp = NativeTypes.Integer;
                            break;
                    }
                    break;
                case XplLiteraltype_enum.REAL:
                    if (!Char.IsDigit(lastLetter) && lastLetter != REFERENCE_CHAR)
                        literalStr = literalStr.Substring(0, literalLength - 1);
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
                    constantValue = Double.Parse(literalStr, NumberStyles.Number | NumberStyles.AllowExponent, NumberFormatInfo.InvariantInfo);
                    break;
                case XplLiteraltype_enum.FLOAT:
                case XplLiteraltype_enum.DOUBLE:
                case XplLiteraltype_enum.DECIMAL:
                    if (!Char.IsDigit(lastLetter) && lastLetter != REFERENCE_CHAR)
                        literalStr = literalStr.Substring(0, literalLength - 1);
                    constantValue = Double.Parse(literalStr, NumberStyles.Number | NumberStyles.AllowExponent, NumberFormatInfo.InvariantInfo);
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
        private ExpressionResult ProcessSimpleNameExpression(XplNode xplNode, Scope scope)
        {

            string nameToSearch = xplNode.get_StringValue();
            if (IsQualifiedName(nameToSearch))
            {
                #region Cuando es un Nombre Calificado
                nameToSearch = GetInternalQualifiedName(nameToSearch);
                string memberOrTypeToSearch = GetSimpleNameFromQualified(nameToSearch);
                string typeToSearch = RemoveSimpleNameFromQualified(nameToSearch);
                string fullTypeName = p_types.get_ExistingTypeName(typeToSearch, scope);
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
                    //Actualizo el nombre en código para q corresponda con un
                    //el nombre de tipos completo
                    xplNode.set_Value(fullTypeName.Replace(".", "::") + "::" + memberOrTypeToSearch);
                    TypeInfo type = (TypeInfo)p_types[fullTypeName];
                    //Primero busco un tipo anidado
                    string typeName = Scope.MakeFullTypeName(fullTypeName, memberOrTypeToSearch);
                    typeName = p_types.get_ExistingTypeName(typeName, scope);
                    if (typeName != null)
                    {
                        type = (TypeInfo)p_types[typeName];
                        if (TypeInfo.IsAccesible(type, scope))
                        {

                            return new ExpressionResult(type);
                        }
                        else
                        {
                            AddNewError(
                                SemanticError.New(SemanticErrorCode.InaccesibleType,
                                xplNode, nameToSearch, "On simple name expression."));

                            return null;
                        }
                    }
                    else
                    {   //Si no busco miembros dentro del tipo obtenido
                        MemberInfo[] members = type.get_MemberInfoCollection().get_MembersInfo(memberOrTypeToSearch);
                        if (members != null && members.Length > 0)
                        {
                            //Filtro los miembros inaccesibles por el nivel de acceso.
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
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.NonexistentMemberOfType, xplNode,
                            memberOrTypeToSearch, fullTypeName, GetSimilarMembersNames(type, memberOrTypeToSearch) + " On primary expression."));

                        return null;
                    }
                }
                else
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.DeclaredTypeDoesnotExist, xplNode,
                        typeToSearch, "On primary expression."));

                    return null;
                }
                #endregion
            }
            else
            {
                #region Cuando es un Nombre Simple
                Symbol symbol = scope.get_Symbol(nameToSearch);
                // 1) Primero busco en los simbolos en el alcance
                if (symbol != null)
                {
                    XplType symType = symbol.get_SymbolType();
                    string expTypeStr;
                    expTypeStr = symType.get_typeStr();
                    if (String.IsNullOrEmpty(expTypeStr)) return null;
                    else return new ExpressionResult(expTypeStr, ExpressionResultType.ValueOrLValue, symbol.get_SymbolType());
                }
                // 2) luego busco si es un miembro de la clase actual
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
                            // 3) Finalmente buscar si se trata de un tipo en el alcance
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

                // PENDIENTE : falta controlar cuando tengo por ejemplo A(12) y
                // "A" es una clase q tiene un constructor q toma un entero :-)
                // debo en este caso retornar los constructores accesibles de A.
                AddNewError(SemanticError.New(SemanticErrorCode.UnresolvedNameOnExpression,
                    xplNode, nameToSearch));

                return null;
                #endregion
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
                        members = FilterStaticMembers(members, scope);
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
        private string GetTypeStringForFactoryTypeModifier(XplType symType, Scope scope)
        {
            switch (symType.get_ftype())
            {
                case XplFactorytype_enum.NONE:
                    break;
                case XplFactorytype_enum.INAME:
                    return MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".IName");
                case XplFactorytype_enum.EXPRESSION:
                    return MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplExpression");
                case XplFactorytype_enum.EXPRESSIONLIST:
                    return MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplExpressionlist");
                case XplFactorytype_enum.STATEMENT:
                    return MakeReferenceTypeTo(CODEDOM_NAMESPACE + ".XplFunctionBody");
                default:
                    break;
            }
            return symType.get_typeStr();
        }
        #endregion

        #region ProcessUnaryOperatorExpression, ProcessBinaryOperatorExpression
        private ExpressionResult ProcessUnaryOperatorExpression(XplUnaryoperator xplUnaryoperator, Scope scope)
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
            ExpressionResult expRes = ProcessExpression(unaryExp, scope);
            if (expRes == null) return res;
            ExpressionResultType expResType = expRes.get_ExpType();
            string errorStr = "On unary operator '" + xplUnaryoperator.get_op().ToString() + "' expression.";
            string typeStr = "";

            #region Switch de UnaryOperator
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
                    opStr = "preinc";
                    break;
                case XplUnaryoperators_enum.PREDEC:
                    opStr = "predec";
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
                    if (!IsPointerType(typeStr))
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.InvalidPointerDereference,
                            xplUnaryoperator, "A Pointer or Reference value required to apply dereference.", errorStr));
                        return res;
                    }
                    if (IsReferencePointerType(typeStr) && !scope.get_IsOnPointerScope())
                        typeStr = RemoveReferencesFromType(typeStr, RemoveReferenciesType.IndirectionOperator);
                    else
                        typeStr = RemovePointerIndirectionsFromType(typeStr, 1);
                    res = new ExpressionResult(typeStr, ExpressionResultType.LValue);
                    break;
                #endregion

                #region Address Of
                case XplUnaryoperators_enum.AOF:
                    //PENDIENTE : revisar aqui todo el funcionamiento, se
                    //realizo rápidamente sin controlarlo demasiado, comparar
                    //con C++.
                    if (expResType == ExpressionResultType.TypeMembers ||
                        expResType == ExpressionResultType.TypeMembersFromValue)
                    {
                        if (expRes.get_Members().Length == 1)
                        {
                            //Aqui devuelvo un puntero a funcion
                            typeStr = MakePointerTypeToMember(expRes.get_Members()[0], expResType == ExpressionResultType.TypeMembersFromValue);
                            res = new ExpressionResult(typeStr);
                            break;
                        }
                        else
                        {
                            expRes = TryConvertTypeMembersToValueOrLValue(expRes, scope, unaryExp.get_Content());
                            expResType = expRes.get_ExpType();
                        }
                    }
                    if (expResType != ExpressionResultType.LValue &&
                        expResType != ExpressionResultType.ValueOrLValue)
                    {
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.LValueRequiredAsOperandOfAddressOfOperator,
                            xplUnaryoperator));
                        return res;
                    }
                    typeStr = expRes.get_TypeStr();
                    if (IsReferencePointerType(typeStr) && !scope.get_IsOnPointerScope())
                        typeStr = RemoveReferencesFromType(typeStr, RemoveReferenciesType.SimpleExpression);
                    typeStr = MakePointerTypeTo(typeStr);
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
            #endregion

            #region Operadores Sobrecargables
            if (opStr != "") //Si se cumple es un operador sobrecargable.
            {
                #region Obtención de Tipos de Operandos Izquierdo y Derecho
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
                        if (IsReferencePointerType(typeName) && !scope.get_IsOnPointerScope()) typeName = RemoveReferencesFromType(typeName, RemoveReferenciesType.ExtractType);
                        else if (IsPointerType(typeName) && !scope.get_IsOnPointerScope()) typeName = RemovePointerIndirectionsFromType(typeName, 1);

                        typeRequired = !IsPointerType(typeName) && !IsArrayType(typeName);
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
                #endregion

                #region Obtención de Miembros Candidatos
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
                    if (IsPointerType(expRes.get_TypeStr()))
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
                #endregion

                #region Resolusion de Sobrecarga y chequeo de argumentos
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
                xplUnaryoperator.set_targetClass(candidateMembers[0].get_DeclarationClassTypeFullName());
                xplUnaryoperator.set_targetMember(candidateMembers[0].get_MemberInternalName());

                res = new ExpressionResult(((XplFunction)candidateMembers[0].get_MemberNode()).get_ReturnType().get_typeStr());

                #endregion

            }
            #endregion

            return res;
        }

        private ExpressionResult ProcessBinaryOperatorExpression(XplBinaryoperator xplBinaryoperator, Scope scope)
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
            ExpressionResult leftRes = ProcessExpression(leftExp, scope), rightRes = null;

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
                                if (rightExp.get_Content().get_ElementName() != "n")
                                {
                                    AddNewError(
                                        SemanticError.New(SemanticErrorCode.ANameRequiredAsRightExpression,
                                        xplBinaryoperator, "On simple member access expression."));

                                    return res;
                                }
                                #region VIEJO
                                ///PENDIENTE : chequear esto!
                                TypeInfo type = leftRes.get_Type();
                                xplBinaryoperator.set_targetClass(type.get_FullName());
                                xplBinaryoperator.set_targetMember("?");

                                string memberName = rightExp.get_Content().get_StringValue();
                                string className, simpleName;
                                if (IsQualifiedName(memberName))
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
                                    members = FilterStaticMembers(members, scope);
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
                            if (IsPointerType(typeStr) && !IsReferencePointerType(typeStr))
                            {
                                AddNewError(
                                    SemanticError.New(SemanticErrorCode.InvalidLeftExpressionOnSimpleMemberAccess,
                                    xplBinaryoperator, "You can not use simple member access with pointers types, instead use pointer member access or a pointer type with reference semantic."));

                                return res;
                            }
                            else if (IsReferencePointerType(typeStr))
                            {
                                typeStr = RemoveReferencesFromType(typeStr, RemoveReferenciesType.MemberAccess);
                            }
                            if (IsArrayType(typeStr))
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
                                if (rightExp.get_Content().get_ElementName() != "n")
                                {
                                    AddNewError(
                                        SemanticError.New(SemanticErrorCode.ANameRequiredAsRightExpression,
                                        xplBinaryoperator, "On simple member access expression."));

                                    return res;
                                }
                                TypeInfo type = (TypeInfo)p_types[typeStr];
                                xplBinaryoperator.set_targetClass(typeStr);
                                xplBinaryoperator.set_targetMember("?");
                                string memberName = rightExp.get_Content().get_StringValue();
                                string memberAccessCacheStr = type.get_FullName() + "." + memberName;

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
                                if (memberName == null)
                                {
                                    AddNewError(
                                        SemanticError.New(SemanticErrorCode.ExpressionRequired,
                                        rightExp));
                                    return null;
                                }
                                if (IsQualifiedName(memberName))
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
                        break;
                    case XplBinaryoperators_enum.PM:     //"->" Acceso a miembro 
                        //Esto deberia ser igual que el acceso a miembro pero aplicando
                        //primero una dereferencia, por lo cual el miembro izquierdo debe ser de
                        //tipo puntero, de lo contrario si es otro tipo es un error.

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
                            if (!IsPointerType(typeStr))
                            {
                                AddNewError(
                                    SemanticError.New(SemanticErrorCode.InvalidLeftExpressionOnPointerMemberAccess,
                                    xplBinaryoperator));

                                return res;
                            }
                            else if (IsReferencePointerType(typeStr))
                            {
                                AddNewError(
                                    SemanticError.New(SemanticErrorCode.InvalidLeftExpressionOnPointerMemberAccess,
                                    xplBinaryoperator, "You can not use pointer member access with referencies, instead use simple member access."));

                                return res;
                            }
                            else
                            {
                                //Es un puntero el tipo, hago una indirección
                                typeStr = RemovePointerIndirectionsFromType(typeStr, 1);
                                if (IsPointerType(typeStr))
                                {
                                    AddNewError(
                                        SemanticError.New(SemanticErrorCode.MoreIndirectionsRequiredOnPointerMemberAccess,
                                        xplBinaryoperator));

                                    return res;
                                }
                            }
                            if (IsArrayType(typeStr))
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
                                if (rightExp.get_Content().get_ElementName() != "n")
                                {
                                    AddNewError(
                                        SemanticError.New(SemanticErrorCode.ANameRequiredAsRightExpression,
                                        xplBinaryoperator, "On pointer member access expression."));

                                    return res;
                                }
                                TypeInfo type = (TypeInfo)p_types[typeStr];
                                xplBinaryoperator.set_targetClass(typeStr);
                                xplBinaryoperator.set_targetMember("?");
                                string memberName = rightExp.get_Content().get_StringValue();
                                string className;
                                if (IsQualifiedName(memberName))
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

                    case XplBinaryoperators_enum.MP:     //".*" Acceso a miembro 
                        break;
                    case XplBinaryoperators_enum.PMP:    //"->*" Acceso a miembro 
                        break;
                    case XplBinaryoperators_enum.RM:     //"Reservado" Acceso a miembro 
                        break;
                    #endregion

                    #region Operadores "=>"
                    case XplBinaryoperators_enum.IMP:    //"=>" Nombre de argumento
                        //El operador "=>" cuando es procesado fuera de una llamada a función 
                        //devuelve el operando derecho
                        return ProcessExpression(rightExp, scope);
                    #endregion

                    default:
                        break;
                }
                //Si estoy aqui debo preguntar si se trata de un operador que no sea de acceso miembro
                //chequeando el valor de opStr

                if (opStr != "")
                {
                    res = ProcessBinaryOperatorExpressionForOperator(xplBinaryoperator, opStr, rightRes, leftRes, rightExp, leftExp, scope);
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
                        ProcessExpression(rightExp, scope);
                        break;
                }
            }

            return res;
        }

        private ExpressionResult ProcessBinaryOperatorExpressionForOperator(XplBinaryoperator xplBinaryoperator, string opStr, ExpressionResult rightRes, ExpressionResult leftRes, XplExpression rightExp, XplExpression leftExp, Scope scope)
        {
            ExpressionResult res = null;
            //Primero proceso la expresión derecha que estaba pendiente de procesar
            rightRes = ProcessExpression(rightExp, scope);
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
            bool typeRequired = true;
            if (leftRes != null)
            {
                if (leftRes.get_ExpType() == ExpressionResultType.TypeMembers
                    || leftRes.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
                    leftRes = TryConvertTypeMembersToValueOrLValue(leftRes, scope, leftExp.get_Content());
                if (leftRes.get_ExpType() != ExpressionResultType.TypeMembers
                    && leftRes.get_ExpType() != ExpressionResultType.TypeMembersFromValue)
                {
                    //Tengo un tipo para el operando izquierdo.
                    if (leftRes.get_ExpType() == ExpressionResultType.Type)
                        leftType = leftRes.get_Type();
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
                        if (IsReferencePointerType(typeName) && !scope.get_IsOnPointerScope()) typeName = RemoveReferencesFromType(typeName, RemoveReferenciesType.ExtractType);
                        else if (IsPointerType(typeName) && !scope.get_IsOnPointerScope()) typeName = RemovePointerIndirectionsFromType(typeName, 1);

                        if (IsArrayType(typeName))
                        {
                            //PENDIENTE : considerar cuando el array es declarado como
                            //un array nativo de C sin encapsular (o bien debo usar
                            //punteros directamente en ese caso?)
                            typeName = NativeTypes.ArrayClassTypeName;
                            leftType = (TypeInfo)p_types[typeName];
                        }
                        else if (IsPointerType(typeName))
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
            }
            //Lo mismo para el operando derecho
            if (rightRes != null)
            {
                if (rightRes.get_ExpType() == ExpressionResultType.TypeMembers
                    || rightRes.get_ExpType() == ExpressionResultType.TypeMembersFromValue)
                    rightRes = TryConvertTypeMembersToValueOrLValue(rightRes, scope, rightExp.get_Content());
                if (rightRes.get_ExpType() != ExpressionResultType.TypeMembers
                    && rightRes.get_ExpType() != ExpressionResultType.TypeMembersFromValue)
                {
                    //Tengo un tipo para el operando izquierdo.
                    if (rightRes.get_ExpType() == ExpressionResultType.Type)
                        rightType = rightRes.get_Type();
                    else
                    {
                        typeName = rightRes.get_TypeStr();
                        //Aqui chequeo si es una referencia o un puntero elimino dicha referencia o puntero
                        if (IsReferencePointerType(typeName) && !scope.get_IsOnPointerScope()) typeName = RemoveReferencesFromType(typeName, RemoveReferenciesType.ExtractType);
                        // only remove pointer indirection if it's not inside on pointer scope
                        else if (IsPointerType(typeName) && !scope.get_IsOnPointerScope()) typeName = RemovePointerIndirectionsFromType(typeName, 1);

                        if (IsArrayType(typeName))
                        {
                            //PENDIENTE : considerar cuando el array es declarado como
                            //un array nativo de C sin encapsular (o bien debo usar
                            //punteros directamente en ese caso?)
                            typeName = NativeTypes.ArrayClassTypeName;
                            rightType = (TypeInfo)p_types[typeName];
                        }
                        else if (IsPointerType(typeName))
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
                    res = new ExpressionResult(((XplFunction)selectedMember.get_MemberNode()).get_ReturnType().get_typeStr());

                    return res;
                }
            }

            #region Obtención de Miembros Candidatos
            //1- Filtro todos los operadores en el tipo del operando "Izq" y en el operando "Der",
            //hago una unión de dichos miembros.
            //Filtro los miembros accesibles.
            //2- Si no hay miembros es un error.
            //2.1- Si hay más de un miembro resuelvo sobrecarga de los miembros.
            //3- Chequeo sea valida la llamada a función.
            MemberInfo[] leftCandidateMembers = null, rightCandidateMembers = null, candidateMembers = null;
            //Si son los dos tipos iguales elimino uno!
            if (leftType == rightType) rightType = null;
            if (leftType != null) leftCandidateMembers = leftType.get_MemberInfoCollection().get_MembersInfo(functionName);
            if (rightType != null) rightCandidateMembers = rightType.get_MemberInfoCollection().get_MembersInfo(functionName);
            if (leftCandidateMembers == null && rightCandidateMembers == null)
            {
                //Primero cheque si ambos son punteros
                if (leftRes != null && rightRes != null && IsPointerType(leftRes.get_TypeStr()) && IsPointerType(rightRes.get_TypeStr()))
                {
                    if (opStr == "eq" || opStr == "noteq")
                    {
                        // Si son punteros del mismo tipo es seguro comparar
                        if (IsSameStringType(leftRes.get_TypeStr(), rightRes.get_TypeStr()))
                        {
                            //PENDIENTE : es necesario marcar esta operación para 
                            //los modulos de salida??
                            return new ExpressionResult(NativeTypes.Boolean);
                        }
                    }
                    else
                    {
                        //PENDIENTE : falta considerar otros operadores que trabajen con dos punteros
                        //y operadores que trabajan con un puntero y un entero
                        // *A + *B ??? <-- do not have sense!!
                        AddNewError(
                            SemanticError.New(SemanticErrorCode.BinaryOperatorWasNotFoundForCurrentOperands,
                            xplBinaryoperator, opStr, leftRes != null ? leftRes.get_TypeStr() : "", rightRes != null ? rightRes.get_TypeStr() : ""));
                    }
                }
                else
                {
                    // TODO : check operators for pointer aritmetic: 
                    // * + int
                    // * - int
                    //No se encontro ningun operador para los operandos.
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.BinaryOperatorWasNotFoundForCurrentOperands,
                        xplBinaryoperator, opStr, leftRes != null ? leftRes.get_TypeStr() : "", rightRes != null ? rightRes.get_TypeStr() : ""));

                    return res;
                }
            }
            if (leftCandidateMembers != null && rightCandidateMembers != null)
            {
                //Copio todos los miembros a un solo array
                candidateMembers = new MemberInfo[leftCandidateMembers.Length + rightCandidateMembers.Length];
                leftCandidateMembers.CopyTo(candidateMembers, 0);
                rightCandidateMembers.CopyTo(candidateMembers, leftCandidateMembers.Length);
            }
            else if (leftCandidateMembers == null) candidateMembers = rightCandidateMembers;
            else candidateMembers = leftCandidateMembers;

            candidateMembers = FilterAccesibleMembers(candidateMembers, scope);
            if (candidateMembers == null)
            {
                AddNewError(
                    SemanticError.New(SemanticErrorCode.InaccesibleTypeMember,
                    xplBinaryoperator, opStr, leftRes != null ? leftRes.get_TypeStr() : ""));
                return res;
            }
            candidateMembers = FilterNonHiddenMembers(candidateMembers, scope);
            if (candidateMembers == null)
            {
                //No se encontro ningun operador para los operandos.
                AddNewError(
                    SemanticError.New(SemanticErrorCode.BinaryOperatorWasNotFoundForCurrentOperands,
                    xplBinaryoperator, opStr, leftRes != null ? leftRes.get_TypeStr() : "", rightRes != null ? rightRes.get_TypeStr() : ""));

                return res;
            }
            #endregion

            #region Resolusion de Sobrecarga y chequeo de argumentos
            //Aqui tengo todos los miembros en "candidateMembers"

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
                        xplBinaryoperator, opStr, errorStr));

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

            //xplFunctioncall.set_targetClass(candidateMembers[0].get_DeclarationClassTypeFullName());
            //xplFunctioncall.set_targetMember(candidateMembers[0].get_MemberName());
            selectedMember = candidateMembers[0];
            if (cacheSearchString != null)
                p_operatorsCache.Add(cacheSearchString, selectedMember);

            xplBinaryoperator.set_targetClass(selectedMember.get_DeclarationClassTypeFullName());
            xplBinaryoperator.set_targetMember(selectedMember.get_MemberInternalName());
            xplBinaryoperator.set_targetMemberExternalName(selectedMember.get_MemberExternalName());

            res = new ExpressionResult(((XplFunction)selectedMember.get_MemberNode()).get_ReturnType().get_typeStr());

            #endregion
            return res;
        }

        private string GetSimilarMembersNames(TypeInfo type, string memberName)
        {
            return null;
            //PENDIENTE : muestro o no muestro los nombres de miembros similares?
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

        private ExpressionResult ProcessNewExpression(XplNewExpression xplNewExpression, Scope scope)
        {
            CheckType(xplNewExpression.get_type(), xplNewExpression, scope, false, "On 'new' expression.");
            if (xplNewExpression.get_type() == null) return null;
            string typeStr = xplNewExpression.get_type().get_typeStr();
            if (typeStr == null || typeStr == "") return null;
            string fullTypeStr = null;
            if (IsArrayType(typeStr))
            {
                // it's an array
                CheckInitializer(xplNewExpression, scope);
                // find the elements' type
                string elementTypeStr = RemoveAllDimensionsFromArrayType(typeStr);
                while (IsPointerType(elementTypeStr)) elementTypeStr = RemovePointerIndirectionsFromType(elementTypeStr, 1);
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
                return new ExpressionResult(MakeReferenceTypeTo(typeStr), ExpressionResultType.Value);
            }
            else if (IsPointerType(typeStr))
            {
                // It's a pointer
                if (IsReferencePointerType(typeStr)) typeStr = ChangeReferenceToPointer(typeStr);
                // TODO : check base pointer type for typeconstructor, arguments (that will be an error)
                return new ExpressionResult(MakeReferenceTypeTo(typeStr), ExpressionResultType.Value);
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
                        return new ExpressionResult(MakeReferenceTypeTo(typeStr), ExpressionResultType.Value);
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
            MemberInfo[] constructors = type.get_MemberInfoCollection().get_MembersInfo(type.get_Name());
            constructors = FilterInstanceMembers(constructors, scope);
            if (constructors == null)
            {
                //Valido si utilizo constructor por defecto
                if (init == null || init.Children().GetLength() == 0)
                    //OK usando constructor por defecto
                    return;
            }
            constructors = FilterAccesibleMembers(constructors, scope);
            if (constructors == null)
            {
                AddNewError(SemanticError.New(SemanticErrorCode.ConstructorNotAvailableDueToItsProtectionLevel,
                    xplNewExpression, type.get_Name()));
                return;
            }
            //Resuelvo la sobrecarga de función
            XplNodeList args = p_dummyNewExpressionFunctioncall.get_args().Children();
            p_dummyNewExpressionFunctioncall.set_name(type.get_Name());
            args.Clear();
            if (init != null)
            {
                XplNodeList newArguments = ((XplInitializerList)init.Children().FirstNode()).Children();
                ProcessArguments(newArguments, scope);
                args.Clear();
                foreach (XplNode argument in newArguments)
                {
                    //PENDIENTE : No utilizar clone, esto es muy lento!!
                    //cambiarlo de alguna forma para mejorar el rendimiento
                    args.InsertAtEnd(argument.Clone());
                }
            }

            string errorStr = "On new expression.";
            if (constructors.Length > 1)
            {
                //Tengo sobrecarga, debo resolver
                constructors = ResolveFunctionOverload(p_dummyNewExpressionFunctioncall, constructors, scope, xplNewExpression);
                //Si no obtengo como respuesta ningun miembro es un error
                if (constructors == null)
                {
                    AddNewError(
                        SemanticError.New(SemanticErrorCode.BestOverloadedFunctionHasSomeInvalidArguments,
                        xplNewExpression, type.get_Name(), errorStr));
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
                        SemanticError.New(SemanticErrorCode.AmbiguousFunctionCall, xplNewExpression, errorStr));
                    return;
                }
            }
            else
            {
                if (!CheckArgumentsForFunction(p_dummyNewExpressionFunctioncall, constructors[0], scope, true, false, xplNewExpression))
                    return;
            }
            XplType retType = constructors[0].get_ReturnType();
            if (retType != null && type.get_IsFactory() &&
                ((NativeTypes.IsNativeVoid(retType.get_typeStr()) && retType.get_ftype() == XplFactorytype_enum.EXPRESSION)
                || NativeTypes.IsNativeType(retType.get_typeStr())))
            {
                AddCandidateStructure(constructors[0], xplNewExpression, scope);
            }
            //PENDIENTE : controlar si en los requerimientos del modulo de salida
            //es necesario marcar el constructor objetivo o no.
            //PENDIENTE : convertir a llamadas a funcion cuando es necesario.
            //            
            //xplFunctioncall.set_targetClass(constructors[0].get_DeclarationClassTypeFullName());
            //xplFunctioncall.set_targetMember(constructors[0].get_MemberName());
        }
        private ExpressionResult ProcessAssingExpression(XplAssing xplAssing, Scope scope)
        {
            ExpressionResult leftRes = ProcessExpression(xplAssing.get_l(), scope);
            ExpressionResult rightRes = null;

            if (xplAssing.get_operation() != XplAssingop_enum.NONE)
            {
                // create a binary expression with: left exp [+,*,/,..] right exp
                XplBinaryoperator bopExp = new XplBinaryoperator((XplExpression)xplAssing.get_l().Clone(), xplAssing.get_r());
                bopExp.set_ElementName("bo");
                bopExp.set_op(ConvertAssignOperatorToBinaryOperator(xplAssing.get_operation()));
                xplAssing.set_r(new XplExpression(bopExp));
                // process the expression
                rightRes = ProcessExpression(xplAssing.get_r(), scope);
                // restore original structure of assign node
                xplAssing.set_r(bopExp.get_r());
            }
            else
            {
                rightRes = ProcessExpression(xplAssing.get_r(), scope);
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
                if (!IsSameStringType(leftRes.get_TypeStr(), rightRes.get_TypeStr()))
                {
                    //Intento conversion implicita del operando derecho
                    ConversionData cdata = ExistsImplicitConversion(rightRes.get_TypeStr(), leftRes.get_TypeStr(), scope);
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
            }
            return leftRes;
        }

        private XplBinaryoperators_enum ConvertAssignOperatorToBinaryOperator(XplAssingop_enum xplAssingop_enum)
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
                    return XplBinaryoperators_enum.AND;
                case XplAssingop_enum.XOR:
                    return XplBinaryoperators_enum.XOR;
                case XplAssingop_enum.OR:
                    return XplBinaryoperators_enum.OR;
                default:
                    throw new SemanticException("Internal error on ConvertAssignOperatorToBinaryOperator");
            }
        }

        private ExpressionResult ProcessOnpointerExpression(XplExpression xplExpression, Scope scope)
        {
            scope.set_IsOnPointerScope(true);
            ExpressionResult result = ProcessExpression((XplExpression)xplExpression.get_Content(), scope);
            scope.set_IsOnPointerScope(false);
            return result;
        }
        /// <summary>
        /// Marca la conversion aplicada en xplExpression
        /// para convertirla de "fromType" a "toType".
        /// Sólo tiene efecto en la generación de código extendido.
        /// </summary>
        private void MarkConversion(ConversionData conversionData, string fromType, string toType, XplExpression xplExpression, Scope scope)
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
                expRes.set_TypeStr(property.get_type().get_typeStr());
                expRes.set_TypeNode(property.get_type());
                if (nodeForCandidateStructure != null)
                {
                    // TODO : check this, must take into account exec types
                    if (member.get_DeclarationClassType().get_IsFactory() &&
                        member.get_DeclarationClassTypeFullName() != scope.get_FullClassName() &&
                        !property.get_isexec())
                    {
                        AddCandidateStructure(member, nodeForCandidateStructure, scope);
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
                expRes.set_TypeStr(indexer.get_ReturnType().get_typeStr());
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
                expRes.set_TypeStr(field.get_type().get_typeStr());
                expRes.set_TypeNode(field.get_type());
                expRes.set_ExpType(ExpressionResultType.ValueOrLValue);
                expRes.set_Members(null);
            }
            return expRes;
        }
        #endregion
    }
}
