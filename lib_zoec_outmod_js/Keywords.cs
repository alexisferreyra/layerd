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
using System.Linq;
using System.Text;

namespace LayerD.OutputModules
{
    class Keywords
    {
        static HashSet<string> _keywords;

        internal const string
            Break = "break",
            Case = "case",
            Catch = "catch",
            Continue = "continue",
            Debugger = "debugger",
            Default = "default",
            Delete = "delete",
            Do = "do",
            Else = "else",
            Finally = "finally",
            For = "for",
            Function = "function",
            If = "if",
            In = "in",
            InstanceOf = "instanceof",
            New = "new",
            Return = "return",
            Switch = "switch",
            This = "this",
            Throw = "throw",
            Try = "try",
            TypeOf = "typeof",
            Var = "var",
            Void = "void",
            While = "while",
            With = "with",

            // future reserved words (ECMA-262 7.6.1.2)
            Class = "class",
            Const = "const",
            Enum = "enum",
            Export = "export",
            Extends = "extends",
            Import = "import",
            Super = "super",

            // Not Keywords but special identifiers
            Prototype = "prototype",

            // Not Keywords but special identifiers for Zoe JS Code Generator
            Application = "application"
            ;

        internal static void Init()
        {
            _keywords = new HashSet<string>();
            _keywords.Add(Break);
            _keywords.Add(Case);
            _keywords.Add(Catch);
            _keywords.Add(Continue);
            _keywords.Add(Debugger);
            _keywords.Add(Default);
            _keywords.Add(Delete);
            _keywords.Add(Do);
            _keywords.Add(Else);
            _keywords.Add(Finally);
            _keywords.Add(For);
            _keywords.Add(Function);
            _keywords.Add(If);
            _keywords.Add(In);
            _keywords.Add(InstanceOf);
            _keywords.Add(New);
            _keywords.Add(Return);
            _keywords.Add(Switch);
            _keywords.Add(This);
            _keywords.Add(Throw);
            _keywords.Add(Try);
            _keywords.Add(TypeOf);
            _keywords.Add(Var);
            _keywords.Add(Void);
            _keywords.Add(While);
            _keywords.Add(With);

            // future reserved words
            _keywords.Add(Class);
            _keywords.Add(Const);
            _keywords.Add(Enum);
            _keywords.Add(Export);
            _keywords.Add(Extends);
            _keywords.Add(Import);
            _keywords.Add(Super);

            // Not Keywords but special identifiers
            _keywords.Add(Prototype);

            // Not Keywords but special identifiers for Zoe JS Code Generator
            _keywords.Add(Application);
        }

        internal static string GetValidIdentifier(string zoeIdentifier, bool isNamespace)
        {
            if (_keywords.Contains(zoeIdentifier))
            {
                if (isNamespace)
                {
                    return zoeIdentifier != Application ? "_$" + zoeIdentifier : zoeIdentifier;
                }
                else
                {
                    return "_$" + zoeIdentifier;
                }
            }
            else
            {
                return zoeIdentifier;
            }
        }
    }
}
