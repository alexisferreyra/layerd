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
            False = "False",
            Class = "class",
            Finally = "finally",
            Is = "is",
            Return = "return",
            None = "None",
            Continue = "continue",
            For = "for",
            Lambda = "lambda",
            Try = "try",
            True = "True",
            Def = "def",
            From = "from",
            Nonlocal = "nonlocal",
            While = "while",
            And = "and",
            Del = "del",
            Global = "global",
            Not = "not",
            With = "with",
            As = "as",
            Elif = "elif",
            If = "if",
            Or = "or",
            Yield = "yield",
            Assert = "assert",
            Else = "else",
            Import = "import",
            Pass = "pass",
            Break = "break",
            Except = "except",
            In = "in",
            Raise = "raise"
            ;

        internal static void Init()
        {
            _keywords = new HashSet<string>();
            _keywords.Add(False);
            _keywords.Add(Class);
            _keywords.Add(Finally);
            _keywords.Add(Is);
            _keywords.Add(Return);
            _keywords.Add(None);
            _keywords.Add(Continue);
            _keywords.Add(For);
            _keywords.Add(Lambda);
            _keywords.Add(Try);
            _keywords.Add(True);
            _keywords.Add(Def);
            _keywords.Add(From);
            _keywords.Add(Nonlocal);
            _keywords.Add(While);
            _keywords.Add(And);
            _keywords.Add(Del);
            _keywords.Add(Global);
            _keywords.Add(Not);
            _keywords.Add(With);
            _keywords.Add(As);
            _keywords.Add(Elif);
            _keywords.Add(If);
            _keywords.Add(Or);
            _keywords.Add(Yield);
            _keywords.Add(Assert);
            _keywords.Add(Else);
            _keywords.Add(Import);
            _keywords.Add(Pass);
            _keywords.Add(Break);
            _keywords.Add(Except);
            _keywords.Add(In);
            _keywords.Add(Raise);
        }

        internal static string GetValidIdentifier(string zoeIdentifier, bool isNamespace)
        {
            if (_keywords.Contains(zoeIdentifier))
            {
                return "_$" + zoeIdentifier;
            }
            else
            {
                return zoeIdentifier;
            }
        }
    }
}
