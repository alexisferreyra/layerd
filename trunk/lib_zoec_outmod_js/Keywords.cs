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

namespace LayerD.OutputModules
{
    class Keywords
    {
        static Dictionary<string,object> _keywords;

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

            // future reserved words on strict context (ECMA-262 7.6.1.2)
            Implements = "implements",
            Let = "let",
            Private = "private",
            Public = "public",
            Yield = "yield",
            Interface = "interface",
            Package = "package",
            Protected = "protected",
            Static = "static",

            // Not Keywords but special identifiers
            Prototype = "prototype",

            // Not Keywords but special identifiers for Zoe JS Code Generator
            Application = "application"
            ;

        internal static void Init()
        {
            _keywords = new Dictionary<string,object>();
            _keywords.Add(Break, null);
            _keywords.Add(Case, null);
            _keywords.Add(Catch, null);
            _keywords.Add(Continue, null);
            _keywords.Add(Debugger, null);
            _keywords.Add(Default, null);
            _keywords.Add(Delete, null);
            _keywords.Add(Do, null);
            _keywords.Add(Else, null);
            _keywords.Add(Finally, null);
            _keywords.Add(For, null);
            _keywords.Add(Function, null);
            _keywords.Add(If, null);
            _keywords.Add(In, null);
            _keywords.Add(InstanceOf, null);
            _keywords.Add(New, null);
            _keywords.Add(Return, null);
            _keywords.Add(Switch, null);
            _keywords.Add(This, null);
            _keywords.Add(Throw, null);
            _keywords.Add(Try, null);
            _keywords.Add(TypeOf, null);
            _keywords.Add(Var, null);
            _keywords.Add(Void, null);
            _keywords.Add(While, null);
            _keywords.Add(With, null);

            // future reserved words
            _keywords.Add(Class, null);
            _keywords.Add(Const, null);
            _keywords.Add(Enum, null);
            _keywords.Add(Export, null);
            _keywords.Add(Extends, null);
            _keywords.Add(Import, null);
            _keywords.Add(Super, null);

            // future reserved words in strict mode
            _keywords.Add(Implements, null);
            _keywords.Add(Let, null);
            _keywords.Add(Private, null);
            _keywords.Add(Public, null);
            _keywords.Add(Yield, null);
            _keywords.Add(Interface, null);
            _keywords.Add(Package, null);
            _keywords.Add(Protected, null);
            _keywords.Add(Static, null);

            // Not Keywords but special identifiers
            // Prototype is not added as reserved keyword to avoid replacing it by escaped version
            // because it is not a reserved keyword, but a special member
            // _keywords.Add(Prototype, null);

            // Not Keywords but special identifiers for Zoe JS Code Generator
            _keywords.Add(Application, null);
        }

        internal static string GetValidIdentifier(string zoeIdentifier, bool isNamespace)
        {
            if (_keywords.ContainsKey(zoeIdentifier))
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

        /// <summary>
        /// Process a qualified id like "a.b.c" to escape keywords.
        /// </summary>
        /// <param name="qualifiedName">The qualified name, use dot as separator and do not call with a simple name</param>
        /// <returns>Qualified name with escaped keywords like a._$function._$var for input a.function.var</returns>
        internal static string GetValidQualifiedName(string qualifiedName)
        {
            string[] qualifiedNameParts = qualifiedName.Split('.');
            int count = 0;
            foreach (var part in qualifiedNameParts)
            {
                string validPart = GetValidIdentifier(part, count == 0);
                if (count == 0) qualifiedName = validPart;
                else qualifiedName = qualifiedName + "." + validPart;
                count++;
            }
            return qualifiedName;
        }
    }
}
