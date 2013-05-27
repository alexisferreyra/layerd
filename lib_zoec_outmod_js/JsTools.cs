/*******************************************************************************
 * Copyright (c) 2012 Intel Corporation.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html
 *
 * Contributors:
 *    Alexis Ferreyra (Intel Corporation) - initial API and implementation and/or initial documentation
 *******************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using LayerD.CodeDOM;
using System.Globalization;

namespace LayerD.OutputModules
{
    internal enum Precedences
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

    class JsTools
    {
        static bool disableKeywordsReplacement;

        internal static int GetOperatorPrecedence(XplBinaryoperators_enum op)
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

        internal static int GetOperatorPrecedence(XplUnaryoperators_enum op)
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

        internal static int GetExpressionPrecedence(XplExpression exp)
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
                    retVal = GetOperatorPrecedence(((XplBinaryoperator)expNode).get_op());
                    break;
                case "uo":
                    retVal = GetOperatorPrecedence(((XplUnaryoperator)expNode).get_op());
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

        internal static bool RequireParenthesis(XplBinaryoperator bopExp)
        {
            XplNode parent = bopExp.get_Parent();
            if (parent != null) parent = parent.get_Parent();
            else return false;
            if (parent != null) parent = parent.get_Parent();
            if (parent != null && parent.get_TypeName() == CodeDOMTypes.XplExpression)
            {
                //Si el parent no es nulo y es otra expresion
                int parentPrec = GetExpressionPrecedence((XplExpression)parent);
                int expPrec = GetOperatorPrecedence(bopExp.get_op());
                if (parentPrec > expPrec)
                    return true;
            }
            return false;
        }

        internal static bool RequireParenthesis(XplUnaryoperator uopExp)
        {
            XplNode parent = uopExp.get_Parent();
            if (parent != null) parent = parent.get_Parent();
            else return false;
            if (parent != null) parent = parent.get_Parent();
            if (parent != null && parent.get_TypeName() == CodeDOMTypes.XplExpression)
            {
                //Si el parent no es nulo y es otra expresion
                if (GetExpressionPrecedence((XplExpression)parent) > GetOperatorPrecedence(uopExp.get_op()))
                    return true;
            }
            return false;
        }

        internal static bool RequireParenthesis(XplCastexpression exp)
        {
            XplNode parent = exp.get_Parent().get_Parent();
            if (parent != null && parent.get_TypeName() == CodeDOMTypes.XplExpression)
            {
                //Si el parent no es nulo y es otra expresion
                if (GetExpressionPrecedence((XplExpression)parent) > (int)Precedences.CastExp) return true;
            }
            return false;
        }

        internal static bool RequireParenthesis(XplAssing xAssign)
        {
            XplNode parent = xAssign.get_Parent().get_Parent().get_Parent();
            if (parent != null && parent.get_TypeName() == CodeDOMTypes.XplExpression)
            {
                //Si el parent no es nulo y es otra expresion
                if (GetExpressionPrecedence((XplExpression)parent) > (int)Precedences.AssingExp) return true;
            }
            return false;
        }

        internal static string ProcessUserTypeName(string name)
        {
            return ProcessUserTypeName(name, false);
        }

        internal static string ProcessUserTypeName(string name, bool isNamespace)
        {
            string tmp = name.Replace("::", ".");

            if (tmp.StartsWith(JSZoeImporter.GLOBAL_CLASS_PREFIX))
            {
                tmp = tmp.Substring(JSZoeImporter.GLOBAL_CLASS_PREFIX.Length);
            }
            else if (tmp.StartsWith(JSZoeImporter.GLOBAL_NS_PREFIX))
            {
                tmp = tmp.Substring(JSZoeImporter.GLOBAL_NS_PREFIX.Length);
            }

            if (tmp.IndexOf('.') < 0)
            {
                // if it is a simple name just process the single id
                return GetValidIdentifier(tmp, isNamespace);
            }
            else
            {
                if(!disableKeywordsReplacement) tmp = Keywords.GetValidQualifiedName(tmp);
            }

            return tmp;
        }
        
        /// <summary>
        /// returns a valid simple identifier for JS that doesn´t collide with a keyword
        /// </summary>
        /// <param name="name">Zoe simple name</param>
        /// <returns>Valid JS simple name</returns>
        internal static string GetValidIdentifier(string name, bool isNamespace)
        {
            if (!disableKeywordsReplacement) return Keywords.GetValidIdentifier(name, isNamespace);
            else return name;
        }

        internal static bool IsObjCDummyGlobalClass(XplClass classDecl)
        {
            return (classDecl.get_name().StartsWith(ObjectiveCFlags.GLOBAL_CLASS_NAME_PREFIX, StringComparison.InvariantCulture) &&
                    classDecl.get_lddata().Equals(ObjectiveCFlags.OBJC_GLOBAL_CLASS_TAG));
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


        internal static string GetDefaultInitForFieldDecl(XplType xplType)
        {
            if (xplType.get_ispointer()) return "null";
            else if (xplType.get_isarray()) return "[]";
            else return RenderValueTypesInitializer(xplType);
        }

        internal static string RenderValueTypesInitializer(XplType xplType)
        {
            if (xplType.get_ispointer()) return String.Empty;
            if (xplType.get_isarray()) return "[]";

            string typeName = xplType.get_typeStr();
            if (typeName == null) return String.Empty;

            if (typeName.StartsWith("$"))
            {
                // native type
                switch (typeName)
                {
                    case "$SBYTE$":
                    case "$BYTE$":
                    case "$SHORT$":
                    case "$USHORT$":
                    case "$INTEGER$":
                    case "$UNSIGNED$":
                    case "$LONG$":
                    case "$ULONG$":
                    case "$FLOAT$":
                    case "$DOUBLE$":
                    case "$LDOUBLE$":
                    case "$DECIMAL$":
                    case "$FIXED$":
                        return "0";

                    case "$BOOLEAN$":
                        return "false";

                    case "$STRING$":
                    case "$ASCIISTRING$":
                    case "$CHAR$":
                    case "$ASCIICHAR$":
                        return "\"\"";

                    case "$DATE$":
                        return Keywords.New + " Object()";
                    case "$VOID$":
                        return String.Empty;
                    case "$OBJECT$":
                        return Keywords.New + " Object()";
                    case "$NONE$":
                    case "$TYPE$":
                    case "$BLOCK$":
                        return "null";
                    default:
                        break;
                }
            }
            else
            {
                if (IsZoeFunctionPointerType(xplType)) return String.Empty;
                // custom type
                return Keywords.New + " " + JsTools.ProcessUserTypeName(typeName) + "()";
            }
            return String.Empty;
        }

        internal static string GetFullDeclarationName(XplNode zoeDeclarationNode)
        {
            string zoeFullName = String.Empty;
            bool isNamespace = false;
            XplNode temp = zoeDeclarationNode;

            while (temp != null)
            {
                string simpleName;
                switch (temp.get_TypeName())
                {
                    case CodeDOMTypes.XplClass:
                        isNamespace = false;
                        simpleName = ((XplClass)temp).get_name();
                        break;
                    case CodeDOMTypes.XplNamespace:
                        isNamespace = true;
                        simpleName = ((XplNamespace)temp).get_name().Replace("::", ".");
                        break;
                    case CodeDOMTypes.XplDocumentBody:
                        goto exit;
                    default:
                        isNamespace = false;
                        simpleName = "_error_";
                        break;
                }
                zoeFullName = GetValidIdentifier(simpleName, isNamespace) + (zoeFullName == String.Empty ? zoeFullName : "." + zoeFullName);
                temp = temp.get_Parent();
            }
        exit:

            return JsTools.ProcessUserTypeName(zoeFullName);
        }
        /// <summary>
        /// Parse a simple string into a dictionary of key/value pairs
        /// 
        /// To delimitate parameters use ' ', ';' or ','
        /// To delimitate key from value use '=' or ':'
        /// </summary>
        /// <param name="renderArguments">Plain string with arguments like "arg1=value1;arg1=value2"</param>
        /// <returns></returns>
        internal static Dictionary<string, string> ParseRenderArguments(string renderArguments)
        {
            var retVal = new Dictionary<string, string>();

            if (String.IsNullOrEmpty(renderArguments)) return retVal;

            string[] parts = renderArguments.Split(' ', ';', ',');

            foreach (string part in parts)
            {
                if (String.IsNullOrEmpty(part)) continue;

                string[] subparts = part.Split('=',':');
                if (subparts.Length == 1)
                {
                    retVal.Add(subparts[0], String.Empty);
                }
                else
                {
                    retVal.Add(subparts[0], subparts[1]);
                }
            }

            return retVal;
        }

        internal static string GetClosureTypeAnnotation(XplType xplType)
        {
            return GetClosureTypeAnnotation(xplType, xplType.get_typeStr(), false);
        }
        internal static string GetClosureTypeAnnotation(XplType xplType, bool isCast)
        {
            return GetClosureTypeAnnotation(xplType, xplType.get_typeStr(), isCast);
        }

        private static string GetClosureTypeAnnotation(XplType xplType, string typeStr, bool isCast)
        {
            if (String.IsNullOrEmpty(typeStr) || (String.IsNullOrEmpty(xplType.get_typename()) && xplType.get_dt() == null)) return "*";

            // check for array
            if (xplType.get_isarray())
            {
                return "Array";
            }
            if (xplType.get_ispointer())
            {
                return GetClosureTypeAnnotation(xplType.get_dt(), TypeString.RemovePointerIndirectionsFromType(typeStr,1), isCast);
            }
            // check for native type
            if (xplType.get_typename()[0] == '$')
            {
                return ZoeNativeTypeToClosure(xplType.get_typename());
            }

            return JsTools.ProcessUserTypeName(typeStr);
        }

        private static string ZoeNativeTypeToClosure(string zoeNativeType)
        {
            switch (zoeNativeType)
            {
                case "$SBYTE$":
                case "$BYTE$":
                case "$SHORT$":
                case "$USHORT$":
                case "$INTEGER$":
                case "$UNSIGNED$":
                case "$LONG$":
                case "$ULONG$":
                case "$FLOAT$":
                case "$DOUBLE$":
                case "$LDOUBLE$":
                case "$DECIMAL$":
                case "$FIXED$":
                    return "number";
                case "$BOOLEAN$":
                    return "boolean";
                case "$CHAR$":
                case "$STRING$":
                    return "string";
                case "$ASCIISTRING$":
                case "$ASCIICHAR$":
                case "$DATE$":
                case "$VOID$":
                case "$OBJECT$":
                case "$NONE$":
                case "$TYPE$":
                case "$BLOCK$":
                default:
                    return "*";
            }
        }

        internal static bool IsNativeType(XplType xplType)
        {
            if (xplType.get_dt() != null) return false;

            string typename = xplType.get_typename();
            if (!String.IsNullOrEmpty(typename) && typename.StartsWith("$")) return true;
            return false;
        }

        internal static bool IsCustomValueType(XplType xplType)
        {
            if (xplType.get_dt() != null) return false;

            string typename = xplType.get_typename();
            if (!String.IsNullOrEmpty(typename) && !typename.StartsWith("$") && !IsZoeFunctionPointerType(xplType)) return true;
            return false;
        }

        private static bool IsZoeFunctionPointerType(XplType type)
        {
            // TODO : change to better mark FP types reference in Zoe Core
            string typeName = type.get_typename();
            return typeName.StartsWith("application.__zoe_function_pointers__.") || typeName.StartsWith("zoe.lang.ClosureTypes.");
        }

        internal static bool IsCustomValueType(string typeStr)
        {
            if (String.IsNullOrEmpty(typeStr)) return false;

            if (TypeString.IsPointerType(typeStr) || TypeString.IsArrayType(typeStr)) return false;

            if (typeStr.StartsWith("$")) return false;

            return true;
        }

        internal static bool AllFieldsAreStatic(XplNodeList fields)
        {
            foreach (XplField field in fields)
            {
                if (field.get_storage() == XplVarstorage_enum.AUTO) return false;
            }
            return true;
        }

        internal static bool IsJSArray(string typeStr)
        {
            return typeStr == "^_js.Array";
        }

        internal static bool IsForeach(XplForStatement stmt)
        {
            var updateList = stmt.get_repeat();
            if (updateList != null && updateList.Children().GetLength() == 1)
            {
                var content = updateList.Children().GetNodeAt(0).get_Content();
                if (content != null && content.get_StringValue() == "_FOR_EACH_") return true;
            }
            return false;
        }

        internal static string GetTypeStringFromInnerTypeName(XplType xplType)
        {
            XplType tempType = xplType;
            while (tempType.get_dt() != null) tempType = tempType.get_dt();
            return JsTools.ProcessUserTypeName(tempType.get_typename());
        }

        /// <summary>
        /// Return true if typeStr is any signed or unsigned integer type
        /// </summary>
        internal static bool IsIntegerNativeType(string typeStr)
        {
            switch (typeStr)
            {
                case "$SBYTE$":
                case "$SHORT$":
                case "$INTEGER$":
                case "$LONG$":
                case "$BYTE$":
                case "$USHORT$":
                case "$UNSIGNED$":
                case "$ULONG$":
                    return true;
            }
            return false;
        }

        internal static string GetPointerObject(string expStr)
        {
            return "{ get value(){ return " + expStr + "; }, set value(v){ " + expStr + " = v; } }";
        }

        internal static bool IsZoeMainFunction(XplFunction functionDecl)
        {
            // TODO implement
            // ZOE main function is a function that:
            //  it is public, static, use the name "Main", with return type "int" or "void" and optionaly has one argument of type "string^[]"
            if (functionDecl.get_storage() != XplVarstorage_enum.STATIC) return false;
            if (functionDecl.get_access() != XplAccesstype_enum.PUBLIC) return false;
            if (functionDecl.get_name() != "Main") return false;
            if (functionDecl.get_ReturnType() == null) return false;
            if (functionDecl.get_ReturnType().get_typename() != "$VOID$" && functionDecl.get_ReturnType().get_typename() != "$INTEGER$") return false;

            return true;
        }

        internal static string GetBaseName(XplClass classDecl)
        {
            if (classDecl == null) return String.Empty;

            XplNodeList list = classDecl.get_InheritsNodeList();
            if (list.GetLength() == 0) return String.Empty;
            foreach (XplInherits inhList in list)
            {
                foreach (XplInherit inh in inhList.Children())
                {
                    string typename = inh.get_type().get_typename().Replace("::", ".");

                    if (typename == "js.Object" || typename == "$OBJECT$" || typename == "zoe.lang.Object") return String.Empty;

                    return JsTools.ProcessUserTypeName(typename);
                }
            }
            return String.Empty;
        }

        internal static void WriteForwardDeclarations(string fullDeclName, string baseClassStr, XplClass classDecl, RenderBuffer buffer)
        {
            var declStr = WriteForwardDeclarations(fullDeclName, baseClassStr, classDecl, buffer, String.Empty);
            if (!String.IsNullOrEmpty(declStr))
            {
                buffer.Write(declStr);
                buffer.WriteNewLine();
            }
        }

        private static string WriteForwardDeclarations(string fullDeclName, string baseClassStr, XplClass classDecl, RenderBuffer buffer, string currentForwardDeclStr)
        {
            if (classDecl == null) return currentForwardDeclStr;

            var documentBody = classDecl.CurrentDocumentBody;
            var baseClass = FindClass(baseClassStr, documentBody);

            if (baseClass != null && buffer.IsUserDefinedTypeRegistered(baseClass))
            {
                return currentForwardDeclStr;
            }

            string baseOfBaseStr = GetBaseName(baseClass);

            if (!String.IsNullOrEmpty(baseOfBaseStr))
            {
                string retStr = baseClassStr + " = Class.$define(\"" + baseClassStr + "\", " + baseOfBaseStr + ");\n" + currentForwardDeclStr;

                var baseOfBaseClass = FindClass(baseOfBaseStr, documentBody);

                return WriteForwardDeclarations(baseOfBaseStr, GetBaseName(baseOfBaseClass), baseOfBaseClass, buffer, retStr);
            }
            else
            {
                if (!String.IsNullOrEmpty(baseClassStr))
                {
                    return baseClassStr + " = Class.$define(\"" + baseClassStr + "\");\n" + currentForwardDeclStr;
                }
                else
                {
                    return fullDeclName + " = Class.$define(\"" + fullDeclName + "\");\n" + currentForwardDeclStr;
                }
            }
        }

        private static XplClass FindClass(string fullClassName, XplDocumentBody xplDocumentBody)
        {
            if (String.IsNullOrEmpty(fullClassName)) return null;

            string containerName = null;
            string simpleName = null;
            if (TypeString.IsQualifiedName(fullClassName))
            {
                containerName = TypeString.GetTypeNameFromQualified(fullClassName);
                simpleName = TypeString.GetSimpleNameFromQualified(fullClassName);
            }
            else
            {
                return null;
            }

            var namespaces = xplDocumentBody.get_NamespaceNodeList();

            foreach (XplNode node in namespaces)
            {
                var classNode = FindClass(containerName, simpleName, node);
                if (classNode != null) return classNode;
            }
            return null;
        }

        private static XplClass FindClass(string containerName, string simpleName, XplNode node)
        {
            XplNodeList innerList = null;
            switch (node.get_TypeName())
            {
                case CodeDOMTypes.XplNamespace:
                    innerList = node.Children();
                    break;
                case CodeDOMTypes.XplClass:
                    var classNode = node as XplClass;
                    if (classNode.get_name() == simpleName && containerName == JsTools.GetFullDeclarationName(node.get_Parent())) return classNode;
                    innerList = node.Children();
                    break;
            }
            if (innerList != null)
            {
                foreach (XplNode child in innerList)
                {
                    var classNode = FindClass(containerName, simpleName, child);
                    if (classNode != null) return classNode;
                }
            }
            return null;
        }


        internal static void DisableReplaceOfKeywords()
        {
            disableKeywordsReplacement = true;
        }

        internal static void EnableReplaceOfKeywords()
        {
            disableKeywordsReplacement = false;
        }

        internal static bool StaticFieldRequiresEncapsulation(XplField fieldDecl)
        {
            XplInitializerList init = fieldDecl.get_i();
            if (init == null) return false;
            if (init.get_array()) return true;
            if (init.Children().FirstNode() != null)
            {
                XplNode node = init.Children().FirstNode();
                if (node != null && node.IsA(CodeDOMTypes.XplExpression)) 
                {
                    // TODO improve logic to detect the need of field encapsulation
                    // i.e. detect when only names of the same class are used and those names are declared before the current field
                    if (node.get_Content().IsA(CodeDOMTypes.XplLiteral)) return false;
                    if (node.get_Content().IsA(CodeDOMTypes.XplUnaryoperator) && ((XplUnaryoperator)node.get_Content()).get_u().get_Content().IsA(CodeDOMTypes.XplLiteral)) return false;
                }
            }
            return true;
        }

        internal static bool IsAllStaticMembersClass(XplClass classDecl)
        {
            var nodeList = classDecl.Children();
            foreach (XplNode node in nodeList)
            {
                if (node.IsA(CodeDOMTypes.XplFunction))
                {
                    var storage = ((XplFunction)node).get_storage();
                    if (storage != XplVarstorage_enum.STATIC && storage != XplVarstorage_enum.STATIC_EXTERN) return false;
                }
                if (node.IsA(CodeDOMTypes.XplField))
                {
                    var storage = ((XplField)node).get_storage();
                    if (storage != XplVarstorage_enum.STATIC && storage != XplVarstorage_enum.STATIC_EXTERN) return false;
                }
            }
            return true;
        }

        internal static string BuildTruncateExpression(string castExpStr)
        {
            return TruncateFunction + "(" + castExpStr + ")";
        }

        internal static string TruncateFunction = "Zoe.truncate";
        internal static string CreateNamespaceFunction = "Zoe.createNamespace";


        internal static string BuildCreateNamespaceExpression(string namespaceJSName)
        {
            return CreateNamespaceFunction + "(\"" + namespaceJSName + "\");";
        }
    }
}
