/*******************************************************************************
* Copyright (c) 2009, 2012 Mateo Bengualid, Intel Corporation.
* All rights reserved. This program and the accompanying materials
* are made available under the terms of the Eclipse Public License v1.0
* which accompanies this distribution, and is available at
* http://www.eclipse.org/legal/epl-v10.html
*
* Contributors:
*       Mateo Bengualid - initial API and implementation
*       Julieta Alvarez (Intel Corporation)
*       Alexis Ferreyra (Intel Corporation)
*******************************************************************************/
using System;
namespace LayerD.OutputModules
{
	public class CppKeywords
	{
		//#region Datos Protegidos para Palabras Claves
		public const string InitializerMethodName = "__layerd_init_fields__";
        public const string IncludePC = "#include ";
        public const string NamespacePC = "namespace ";
        public const string ClassPC = "class ";
        public const string StructPC = "struct ";
        public const string UnionPC = "union ";
        public const string EnumPC = "enum ";
        public const string InterfacePC = "interface ";// <-- Use a .h file or a class with abstract methods.
        public const string AbstractPC = "abstract ";// <-- Use a .h file or a class with abstract methods.
        public const string FinalPC = "sealed ";// <-- Simulated with a private constructor.
        public const string NewPC = "new ";
        public const string VolatilePC = "volatile ";
        public const string ConstPC = "const ";
        public const string PrivatePC = "private: "; // The ":" serves to emulate other language definitions.
        public const string ProtectedPC = "protected: "; // The ":" serves to emulate other language definitions.
        public const string PublicSlotsPC = "public slots: "; // The ":" serves to emulate other language definitions.
        public const string PublicPC = "public: ";
        public const string InternalPC = "";// <-- Non C++ related.
        public const string DelegatePC = "";// <-- Simulated with member function pointers or templatized functors.
        public const string ExplicitPC = "";// <-- Simulated with old C-style cast definition with Y(const X& x)
        public const string ImplicitPC = "implicit ";// <-- Simulated with old C-style cast definition with Y(const X& x)
        public const string OperatorPC = "operator ";
        public const string VirtualPC = "virtual ";
        public const string OverridePC = "override ";
        public const string IndexerPC = "this ";
        public const string ParamsPC = "... ";// <-- Used in a different position.
        public const string InPC = "in ";
        public const string InoutPC = "&";// <-- In fact, it is just the use of a pointer.
        public const string OutPC = "&";// <-- In fact, it is just the use of a pointer.
        public const string ReturnPC = "return";
        public const string ThrowPC = "throw ";
        public const string SwitchPC = "switch ";
        public const string BreakPC = "break";
        public const string CatchPC = "catch ";
        public const string ContinuePC = "continue";
        public const string FinallyPC = "finally ";
        public const string GotoPC = "goto ";
        public const string TryPC = "try ";
        public const string DoPC = "do ";
        public const string WhilePC = "while ";
        public const string CasePC = "case ";
        public const string DeletePC = "delete ";
        public const string ElsePC = "else ";
        public const string ForPC = "for ";
        public const string IfPC = "if ";
        public const string ExternPC = "extern ";
        public const string StaticPC = "static ";
        public const string DefaultPC = "default ";
		public const string PartialPC = "";// <-- Glue the whole bunch at the end.
        public const string UniversalMockClassName = "__MockClass";
        public const string UniversalMockNamespaceName = "__MockNS";
        //TODO: Add here the rest of the C++ dependant reserved words.
        public const string FriendPC = "friend ";// Not yet supported.
        public const string ScopePC = "::";
        //#endregion

		public CppKeywords ()
		{
			
		}
	}
}

