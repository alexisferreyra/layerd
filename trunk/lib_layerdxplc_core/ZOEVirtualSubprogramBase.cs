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
using LayerD.CodeDOM;

namespace zoe.lang{
    /// <summary>
    /// Base class for Zoe Subprograms (compile time linear program)
    /// </summary>
	public class SubprogramBase{
        public static bool DebugRipProgress = false;
        public static bool DebugFunctioncallMerges = false;
        public static int DebugRipReportIncrement = 1;

        /// <summary>
        /// Merges returned node from classfactory <paramref name="node"/> into Return Instruction Point node <paramref name="RIP"/>
        /// </summary>
        /// <param name="RIP">Return Instruction Point node on Parameter Document that originates classfactory call</param>
        /// <param name="node">Returned node from classfactory to replace RIP node</param>
	    protected void MergeRIP(object RIP, XplNode node, int ripIndex){
            XplNode ripNode = (XplNode)RIP;

            if (DebugRipProgress)
            {
                if (ripIndex > 0 && ripIndex % DebugRipReportIncrement == 0)
                {
                    System.GC.Collect();
                    Console.WriteLine("[rN]" + ripIndex + " : " + ripNode.FullSourceFileInfo);
                    Console.Out.Flush();
                }
            }

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
            else if (ripType == CodeDOMTypes.XplExpression)
            {
                MergeExpression(node, ripNode);
                return;
            }
            else if (ripType == CodeDOMTypes.XplNode || ripType == CodeDOMTypes.XplUnaryoperator || ripType == CodeDOMTypes.XplBinaryoperator || ripType == CodeDOMTypes.XplAssing)
            {
                // these are Properties rips
                MergeFunctioncall(node, ripNode);
                return;
            }

            throw new Exception("Internal error while merging nodes. Please contact Zoe Compiler development team at http://layerd.net."
                + " Rip Node: " + (ripNode != null ? ripNode.get_ContentTypeNameString() : "") + " Node: " + (node != null ? node.get_ContentTypeNameString() : ""));
		}

        private static void MergeExpression(XplNode node, XplNode ripNode)
        {
            ripNode.set_Content(node.get_Content());
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
                if (node.get_Content().IsA(CodeDOMTypes.XplNewExpression))
                {
                    XplNewExpression newExp = (XplNewExpression)node.get_Content();
                    //expresion new con constructor con parametros
                    ((XplNewExpression)ripNode).set_type(
                        newExp.get_type());
                    ((XplNewExpression)ripNode).set_init(
                        newExp.get_init());
                }
                else
                {
                    // replace new expression with new one
                    ripNode.get_Parent().set_Content(node.get_Content());
                }
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
                    while (parent.get_TypeName() == CodeDOMTypes.XplType)
                    {
                        parent = parent.get_Parent();
                    }
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
                    case CodeDOMTypes.XplCastexpression:
                        ((XplCastexpression)parent).set_type((XplType)node);
                        return;
                    case CodeDOMTypes.XplInherit:
                        ((XplInherit)parent).set_type((XplType)node);
                        return;
                    case CodeDOMTypes.XplExpression:
                        XplExpression parentExp = parent as XplExpression;
                        node.set_ElementName(parentExp.get_Content().get_ElementName());
                        parentExp.set_Content(node);
                        return;
                    default:
                        break;
                }
            }
            else if (node == null)
            {
                // wants to remove type
                while (parent.get_TypeName() == CodeDOMTypes.XplType)
                {
                    parent = parent.get_Parent();
                }

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
                    /*
                     * TODO : must remove types/expressions
                    case CodeDOMTypes.XplType:
                        ((XplType)parent).set_dt((XplType)node);
                        return;
                    case CodeDOMTypes.XplCastexpression:
                        ((XplCastexpression)parent).set_type((XplType)node);
                        return;
                    case CodeDOMTypes.XplInherit:
                        ((XplInherit)parent).set_type((XplType)node);
                        return;
                    case CodeDOMTypes.XplExpression:
                        XplExpression parentExp = parent as XplExpression;
                        node.set_ElementName(parentExp.get_Content().get_ElementName());
                        parentExp.set_Content(node);
                        return;
                     **/
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
            if (DebugFunctioncallMerges)
            {
                Console.WriteLine(ripNode.FullSourceFileInfo + ":");
                Console.WriteLine("\t" + ripNode.CurrentExpression.ReadableString);
            }

            if (node == null)
            {
                ripNode.get_Parent().set_Content(XplExpression.new_empty());
                if (DebugFunctioncallMerges) Console.WriteLine("To: <emtpy>");
            }
            else if (ripNode.IsA(CodeDOMTypes.XplNode) && node.IsA(CodeDOMTypes.XplType))
            {
                // this is a merge between a typename and a qualified name which member was not found as part of target classfactory
                // like in: "ns::myCFType::myNonExistingMember"

                XplType typeNode = (XplType)node;
                while(typeNode.get_dt() != null) typeNode = typeNode.get_dt();

                string newTypeName = typeNode.get_typename();
                ripNode.set_Value(newTypeName + "." + TypeString.GetSimpleNameFromQualified(ripNode.get_StringValue()));
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

                if (DebugFunctioncallMerges)
                {
                    Console.WriteLine("To:");
                    Console.WriteLine("\t" + node.CurrentExpression.ReadableString);
                }
            }
        }

        public bool BreakCompileTime
        {
            get
            {
                return (LayerD.ZOECompiler.ClassfactoryBase.compiler != null
                    && LayerD.ZOECompiler.ClassfactoryBase.compiler.BreakCompileTime)
                    || (LayerD.ZOECompiler.ClassfactoryInteractiveBase.compiler != null
                    && LayerD.ZOECompiler.ClassfactoryInteractiveBase.compiler.BreakCompileTime);
            }
        }

        public virtual void Run(LayerD.ZOECompiler.ArgumentVector AV, LayerD.ZOECompiler.RIPVector RIPV, LayerD.ZOECompiler.ContextVector CV)
        {

        }
    }
}