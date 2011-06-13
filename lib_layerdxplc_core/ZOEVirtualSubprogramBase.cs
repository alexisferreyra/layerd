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
using LayerD.CodeDOM;

namespace zoe.lang{
    /// <summary>
    /// Base class for Zoe Subprograms (compile time linear program)
    /// </summary>
	public class SubprogramBase{
        /// <summary>
        /// Merges returned node from classfactory <paramref name="node"/> into Return Instruction Point node <paramref name="RIP"/>
        /// </summary>
        /// <param name="RIP">Return Instruction Point node on Parameter Document that originates classfactory call</param>
        /// <param name="node">Returned node from classfactory to replace RIP node</param>
	    protected void MergeRIP(object RIP, XplNode node){
            XplNode ripNode = (XplNode)RIP;

            CodeDOMTypes ripType = ripNode.get_TypeName();
            if (ripType == CodeDOMTypes.XplFunctioncall || ripType == CodeDOMTypes.XplComplexfunctioncall)
            {
                MergeFunctioncall(node, ripNode);
                return;
            }
            else if(ripType == CodeDOMTypes.XplType)
            {
                MergeType(node, ripNode);
                return;
            }
			else if(ripType == CodeDOMTypes.XplNewExpression){
                MergeNewExpression(node, ripNode);
                return;
			}
            else if(ripType == CodeDOMTypes.XplInherit)
            {
                MergeInherit(node, ripNode);
                return;
            }
            else if (ripType == CodeDOMTypes.XplNode || ripType == CodeDOMTypes.XplBinaryoperator || ripType == CodeDOMTypes.XplAssing)
            {
                // these are Properties rips
                MergeFunctioncall(node, ripNode);
                return;
            }

            throw new Exception("Internal error while merging nodes. Please contact Zoe Compiler development team at http://layerd.net."
                + " Rip Node: " + (ripNode != null ? ripNode.get_ContentTypeNameString() : "") + " Node: " + (node != null ? node.get_ContentTypeNameString() : ""));
		}

        private static void MergeInherit(XplNode node, XplNode ripNode)
        {
            if (node != null && node.get_TypeName() == CodeDOMTypes.XplType)
            {
                ((XplInherit)ripNode).get_type().set_typename(((XplType)node).get_typename());
                return;
            }
            else if (node == null)
            {
                // wants to remove xplinherit
                ripNode.get_Parent().Children().Remove(ripNode);
                return;
            }
            else
            {
                //error
            }
            throw new Exception("Internal error while merging nodes. Please contact Zoe Compiler development team at http://layerd.net."
                + " Rip Node: " + (ripNode != null ? ripNode.get_ContentTypeNameString() : "") + " Node: " + (node != null ? node.get_ContentTypeNameString() : ""));
        }

        private static void MergeNewExpression(XplNode node, XplNode ripNode)
        {
            if (node != null && node.get_TypeName() == CodeDOMTypes.XplType)
            {
                //expresion new con constructor sin parametros (usando constructor de tipo por defecto)
                XplType newType = (XplType)node;
                if (newType.get_replaceParent())
                {
                    //wants to replace full parent type
                    ((XplNewExpression)ripNode).set_type((XplType)node);
                }
                else
                {
                    // find the most derivef type 
                    XplType ripType = ((XplNewExpression)ripNode).get_type();
                    if (ripType.get_dt() == null)
                    {
                        // if it's not a derived type
                        ((XplNewExpression)ripNode).set_type((XplType)node);
                    }
                    else
                    {
                        // if it's a derived type find most derived
                        XplType prevType = ripType;
                        while (ripType.get_dt() != null)
                        {
                            prevType = ripType;
                            ripType = ripType.get_dt();
                        }
                        prevType.set_dt((XplType)node);
                    }
                    
                }
                return;
            }
            else if (node != null && node.get_TypeName() == CodeDOMTypes.XplExpression)
            {
                //expresion new con constructor con parametros
                ((XplNewExpression)ripNode).set_type(
                    ((XplNewExpression)node.get_Content()).get_type());
                ((XplNewExpression)ripNode).set_init(
                    ((XplNewExpression)node.get_Content()).get_init());
                return;
            }
            else if (node == null)
            {
                // wants to remove xplnewexpression
                ripNode.get_Parent().set_Content(XplExpression.new_empty());
                return;
            }
            else
            {
                //error
            }
            throw new Exception("Internal error while merging nodes. Please contact Zoe Compiler development team at http://layerd.net."
                + " Rip Node: " + (ripNode != null ? ripNode.get_ContentTypeNameString() : "") + " Node: " + (node != null ? node.get_ContentTypeNameString() : ""));
        }

        private static void MergeType(XplNode node, XplNode ripNode)
        {
            XplNode parent = ripNode.get_Parent();
            if (node != null && node.get_TypeName() == CodeDOMTypes.XplType)
            {
                XplType newType = (XplType)node;
                if (newType.get_replaceParent())
                {
                    //wants to replace full parent type
                    while (parent.get_TypeName() == CodeDOMTypes.XplType) parent = parent.get_Parent();
                }

                switch (parent.get_TypeName())
                {
                    case CodeDOMTypes.XplDeclarator:
                        ((XplDeclarator)parent).set_type((XplType)node);
                        return;
                    case CodeDOMTypes.XplParameter:
                        ((XplParameter)parent).set_type((XplType)node);
                        return;
                    case CodeDOMTypes.XplField:
                        ((XplField)parent).set_type((XplType)node);
                        return;
                    case CodeDOMTypes.XplProperty:
                        ((XplProperty)parent).set_type((XplType)node);
                        return;
                    case CodeDOMTypes.XplFunction:
                        ((XplFunction)parent).set_ReturnType((XplType)node);
                        return;
                    case CodeDOMTypes.XplType:
                        ((XplType)parent).set_dt((XplType)node);
                        return;
                    default:
                        break;
                }
            }
            else if (node == null)
            {
                // wants to remove type
                while (parent.get_TypeName() == CodeDOMTypes.XplType) parent = parent.get_Parent();
                switch (parent.get_TypeName())
                {
                    case CodeDOMTypes.XplDeclarator:
                        ((XplDeclarator)parent).set_type(null);
                        return;
                    case CodeDOMTypes.XplParameter:
                        ((XplParameter)parent).set_type(null);
                        return;
                    case CodeDOMTypes.XplField:
                        ((XplField)parent).set_type(null);
                        return;
                    case CodeDOMTypes.XplProperty:
                        ((XplProperty)parent).set_type(null);
                        return;
                    case CodeDOMTypes.XplFunction:
                        ((XplFunction)parent).set_ReturnType(null);
                        return;
                    default:
                        //error
                        break;
                }
            }
            else
            {
                //error
            }
            throw new Exception("Internal error while merging nodes. Please contact Zoe Compiler development team at http://layerd.net."
                + " Rip Node: " + (ripNode != null ? ripNode.get_ContentTypeNameString() : "") + " Node: " + (node != null ? node.get_ContentTypeNameString() : ""));
        }

        private static void MergeFunctioncall(XplNode node, XplNode ripNode)
        {
            if (node == null)
            {
                ripNode.get_Parent().set_Content(XplExpression.new_empty());
            }
            else
            {                
                CodeDOMTypes contextTypename = ripNode.get_Parent().get_Parent().get_TypeName();
                XplNode content = node.get_Content();
                if (content == null) content = XplExpression.new_empty();

                switch (contextTypename)
                {
                    case CodeDOMTypes.XplDocumentBody:
                    case CodeDOMTypes.XplNamespace:
                    case CodeDOMTypes.XplClass:
                    case CodeDOMTypes.XplFunctionBody:
                        string ripNodeParent = ripNode.get_Parent().get_ElementName();
                        if (ripNodeParent == "return" || ripNodeParent == "throw")
                        {
                            ripNode.get_Parent().set_Content(content);
                        }
                        else
                        {
                            ripNode.get_Parent().get_Parent().Children().InsertAfter(node, ripNode.get_Parent());
                            ripNode.get_Parent().set_Content(XplExpression.new_empty());
                        }
                        break;
                    default:
                        ripNode.get_Parent().set_Content(content);
                        break;
                }
            }
        }
	}
}