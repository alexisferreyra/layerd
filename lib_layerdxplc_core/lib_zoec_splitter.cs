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

//Archivo: lib_layerdxplc_splitter.cs 
//
//Separador de programas LayerD-Zoe,
//genera el Subprograma Virtual y el Documento Parametro
//a partir de un Documento de Tiempo de Ejecución.
//

using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;

using LayerD.CodeDOM;
using System.Collections.Generic;

namespace LayerD.ZOECompiler
{
    #region CandidateStructureType, CandidateStructure, CandidateStructureCollection
    enum CandidateStructureType
    {
        MemberInvocation,
        TypeName,
        Symbol,
        EnterBlock,
        LeaveBlock,
    }
    enum TypeNameContext
    {
        BaseOrInterface,
        FieldDecl,
        ReturnType,
        ParameterType,
        LocalVarDecl,
    }
    enum ExistenceType
    {
        Document,
        Virtual,
        Dual,
    }
    class CandidateStructure
    {
        CandidateStructureType p_type;
        TypeNameContext p_typeNameContext;
        XplNode p_node;
        TypeInfo p_classfactoryType;
        MemberInfo p_targetMember;
        ExistenceType p_existence = ExistenceType.Document;
        string p_symbolName;
        int p_isPropertySet;

        /// <summary>
        /// Crea una estructura candidata de entrada o salida de bloque de alcance,
        /// el parametro node puede ser nulo y representa el nodo que define el bloque,
        /// por ejemplo un espacio de nombres, clase o funcion.
        /// </summary>
        public CandidateStructure(CandidateStructureType cstype, XplNode node)
        {
            Debug.Assert(cstype == CandidateStructureType.EnterBlock || cstype == CandidateStructureType.LeaveBlock, "cstype debe ser de tipo entrada o salida de bloque!!!");
            p_node = node;
            p_type = cstype;
            p_existence = ExistenceType.Virtual;
        }
        public CandidateStructure(TypeInfo symbolType, string symbolName)
        {
            p_classfactoryType = symbolType;
            p_symbolName = symbolName;
            p_type = CandidateStructureType.Symbol;
        }
        public CandidateStructure(TypeNameContext context, XplNode node, TypeInfo classfactoryType)
        {
            Debug.Assert(node != null, "El nodo no debe ser nulo en la estructura candidata");
            p_type = CandidateStructureType.TypeName;
            p_typeNameContext = context;
            p_node = node;
            p_classfactoryType = classfactoryType;
        }
        public CandidateStructure(XplNode node, TypeInfo classfactoryType, MemberInfo memberInfo){
            //Tipo de Nodo Zoe para una invocacion a un miembro puede ser:
            //- XplFunctioncall
            //- XplComplexFunctioncall
            //- XplBinaryOperator -- Cuando se sobrecarga operadores binarios o se accede a propieades
            //- XplAssing -- When writing properties
            //- XplNode -- When it´s a simple expression and is accesing a property
            //- XplUnaryOperator -- Cuando se sobrecarga operadores unarios
            //- XplNewExpression -- Para expresiones new
            //- XplExpression when overloading conversion operators
            //
            Debug.Assert(node != null, "El nodo no debe ser nulo en la estructura candidata");
            /*Debug.Assert(node is XplFunctioncall || node is XplComplexfunctioncall
                || node is XplBinaryoperator || node is XplUnaryoperator || node is XplNewExpression
                ,"Error en el tipo de nodo pasado al constructor.");*/
            p_type = CandidateStructureType.MemberInvocation;
            p_node = node;
            p_classfactoryType = classfactoryType;
            p_targetMember = memberInfo;
        }
        public CandidateStructureType CSType
        {
            get { return p_type; }
        }
        public TypeNameContext TypeNameContext
        {
            get { return p_typeNameContext; }
        }
        public XplNode Node
        {
            get { return p_node; }
        }
        public TypeInfo CFTypeInfo
        {
            get { return p_classfactoryType; }
        }
        public MemberInfo CFMemberInfo
        {
            get { return p_targetMember; }
        }
        public ExistenceType Existence
        {
            get { return p_existence; }
            set { p_existence = value; }
        }
        public string SymbolName
        {
            get { return p_symbolName; }
            set { p_symbolName = value; }
        }
        /// <summary>
        /// Indica si los argumentos proporcionados para la llamada a función
        /// son todos validos, si no son validos querra decir que se debe postergar
        /// la ejecución de la estructura candidata al proximo tiempo de compilación.
        /// 
        /// NO LLAMAR CON ESTRUCTURAS CANDIDATAS QUE NO SEAN DE TIPO LLAMADA A FUNCION
        /// </summary>
        public bool CheckArgumentsForFunction()
        {
            if (p_type != CandidateStructureType.MemberInvocation) return false;
            //PENDIENTE : hacer que funcione!!!
            switch (p_node.get_TypeName())
            {
                case CodeDOMTypes.XplFunctioncall:
                case CodeDOMTypes.XplComplexfunctioncall:
                case CodeDOMTypes.XplBinaryoperator:
                case CodeDOMTypes.XplUnaryoperator:
                case CodeDOMTypes.XplNewExpression:
                case CodeDOMTypes.XplAssing:
                case CodeDOMTypes.XplExpression:
                case CodeDOMTypes.XplNode:
                    return true;
                default:
                    return false;
            }
        }
        /// <summary>
        /// Returns if this is a property or indexer set
        /// </summary>
        public bool IsPropertySet
        {
            get
            {
                if (p_isPropertySet == 0)
                {
                    //calculate
                    //XplNode parent = p_node.get_Parent().get_Parent();
                    //if (parent.get_TypeName() == CodeDOMTypes.XplAssing)
                    //{
                    //    if (((XplAssing)parent).get_l().get_Content() == p_node) p_isPropertySet = 1;
                    //    else p_isPropertySet = -1;
                    //}
                    if (p_node.get_TypeName() == CodeDOMTypes.XplAssing)
                    {
                        p_isPropertySet = 1;
                    }
                    else
                    {
                        p_isPropertySet = -1;
                    }
                }
                return p_isPropertySet > 0;
            }
        }

        public XplFunctionBody BlockArgument
        {
            get
            {
                if (p_type != CandidateStructureType.MemberInvocation) return null;
                switch (p_node.get_TypeName())
                {
                    case CodeDOMTypes.XplFunctioncall:
                        return ((XplFunctioncall)p_node).get_bk();
                    case CodeDOMTypes.XplComplexfunctioncall:
                        return ((XplComplexfunctioncall)p_node).get_fbk();
                    case CodeDOMTypes.XplBinaryoperator:
                    case CodeDOMTypes.XplUnaryoperator:
                    case CodeDOMTypes.XplNewExpression:
                    case CodeDOMTypes.XplAssing:
                    case CodeDOMTypes.XplNode:
                        return null;
                    default:
                        return null;
                }
            }
        }
        /// <summary>
        /// Devuelve los argumentos en el caso de que es una llamada a funcion.
        /// </summary>
        public XplNodeList CallArguments
        {
            get{
                if (p_type != CandidateStructureType.MemberInvocation)
                {
                    return null;
                }

                XplNodeList retList = null;
                XplNode temp = null;

                switch (p_node.get_TypeName())
                {
                    case CodeDOMTypes.XplFunctioncall:
                        XplExpressionlist args = ((XplFunctioncall)p_node).get_args();
                        return args == null ? null : args.Children();

                    case CodeDOMTypes.XplComplexfunctioncall:
                        return null;

                    case CodeDOMTypes.XplBinaryoperator:
                        retList = new XplNodeList();
                        temp = ((XplBinaryoperator)p_node).get_l().Clone();
                        temp.set_ElementName("e");
                        retList += temp;
                        temp = ((XplBinaryoperator)p_node).get_r().Clone();
                        temp.set_ElementName("e");
                        retList += temp;
                        return retList;

                    case CodeDOMTypes.XplUnaryoperator:
                        retList = new XplNodeList();
                        temp = ((XplUnaryoperator)p_node).get_u().Clone();
                        temp.set_ElementName("e");
                        retList += temp;
                        return retList;

                    case CodeDOMTypes.XplExpression:
                        retList = new XplNodeList();
                        retList += p_node.Clone();
                        return retList;

                    case CodeDOMTypes.XplNewExpression:
                        if (((XplNewExpression)p_node).get_init() == null) return null;
                        return ((XplInitializerList)((XplNewExpression)p_node).get_init().Children().FirstNode()).Children();
                    case CodeDOMTypes.XplNode:
                    case CodeDOMTypes.XplAssing:
                        return null;
                    default:
                        return null;
                }
            }
        }
        public bool IsComplexFunctionCall
        {
            get {
                return p_node.get_TypeName() == CodeDOMTypes.XplComplexfunctioncall;
            }
        }
        /// <summary>
        /// Devuelve el tipo de retorno en el caso de que es una llamada a función.
        /// </summary>
        public XplType CallReturnType
        {
            get
            {
                if (p_type != CandidateStructureType.MemberInvocation) return null;
                return p_targetMember.get_ReturnType();
            }
        }
    }
    class CandidateStructuresCollection: ArrayList 
    {
        bool p_interactiveOnly;
        IDictionary<string, string> p_classfactoriesToIgnore = new Dictionary<string, string>();

        public CandidateStructuresCollection(bool interactiveOnly)
        {
            p_interactiveOnly = interactiveOnly;
        }

        public new CandidateStructure this[int n]
        {
            get
            {
                return (CandidateStructure)base[n];
            }
            set
            {
                base[n] = value;
            }
        }

        bool IgnoreFactoryType(TypeInfo typeInfo)
        {
            return this.p_classfactoriesToIgnore.ContainsKey(typeInfo.get_FullName());
        }

        /// <summary>
        /// Adds a new candidate structure for a property or indexer
        /// </summary>
        /// <param name="memberInfo">Member info that must be a property or an indexer</param>
        /// <param name="xplNode">Node that reference to a left expression of an assignment, to a simple name expression, or to a member access expression</param>
        /// <param name="scope">scope information</param>
        public void AddCandidateStructure(MemberInfo memberInfo, XplNode xplNode, Scope scope)
        {
            if (IgnoreFactoryType(memberInfo.get_DeclarationClassType())) return;

            // for type conversion operators it can be null when querying for better method
            if (xplNode == null) return;

            if (!memberInfo.get_DeclarationClassType().get_IsCompiledClassfactory()) return;
            if (memberInfo.get_IsExternal()) return;
            if (p_interactiveOnly && !memberInfo.get_DeclarationClassType().get_IsInteractive()) return;
            CandidateStructure cs = null;
            if (memberInfo.get_ClassType().get_IsFactory())
            {
                cs = new CandidateStructure(xplNode, memberInfo.get_ClassType(), memberInfo);
            }
            else
            {
                cs = new CandidateStructure(xplNode, memberInfo.get_DeclarationClassType(), memberInfo);
            }
            this.Add(cs);
        }

        /// <summary>
        /// Agrega una estructura candidata a la colección.
        /// 
        /// memberInfo: miembro de classfactory llamado
        /// xplFunctioncall: la llamada a función
        /// scope: el alcance actual
        /// </summary>
        public void AddCandidateStructure(MemberInfo memberInfo, XplFunctioncall xplFunctioncall, Scope scope)
        {
            if (IgnoreFactoryType(memberInfo.get_DeclarationClassType())) return;

            if (!memberInfo.get_DeclarationClassType().get_IsCompiledClassfactory()) return;
            if (memberInfo.get_IsExternal()) return;
            if (p_interactiveOnly && !memberInfo.get_DeclarationClassType().get_IsInteractive()) return;
            CandidateStructure cs = null;
            if (memberInfo.get_ClassType().get_IsFactory())
                cs = new CandidateStructure(xplFunctioncall, memberInfo.get_ClassType(), memberInfo);
            else
                cs = new CandidateStructure(xplFunctioncall, memberInfo.get_DeclarationClassType(), memberInfo);
            this.Add(cs);
        }

        /// <summary>
        /// Agrega una estructura candidata a la colección.
        /// </summary>
        public void AddCandidateStructure(MemberInfo memberInfo, XplNewExpression xplNewExpression, Scope scope)
        {
            if (IgnoreFactoryType(memberInfo.get_DeclarationClassType())) return;

            if (!memberInfo.get_DeclarationClassType().get_IsCompiledClassfactory()) return;
            if (p_interactiveOnly && !memberInfo.get_DeclarationClassType().get_IsInteractive()) return;
            CandidateStructure cs = new CandidateStructure(xplNewExpression, memberInfo.get_ClassType(), memberInfo);
            this.Add(cs);
        }

        /// <summary>
        /// Agrega una estructura candidata a la colección.
        /// </summary>
        public void AddCandidateStructure(MemberInfo memberInfo, XplComplexfunctioncall xplFunctioncall, Scope scope)
        {
            if (IgnoreFactoryType(memberInfo.get_DeclarationClassType())) return;

            if (!memberInfo.get_DeclarationClassType().get_IsCompiledClassfactory()) return;
            if (p_interactiveOnly && !memberInfo.get_DeclarationClassType().get_IsInteractive()) return;
            CandidateStructure cs = new CandidateStructure(xplFunctioncall, memberInfo.get_ClassType(), memberInfo);
            this.Add(cs);
        }


        internal void RegisterClassfactoryToIgnore(string fullClassfactoryNameToIngnore)
        {
            p_classfactoriesToIgnore.Add(fullClassfactoryNameToIngnore, null);
        }

        internal void UnregisterClassfactoryToIgnore(string fullClassfactoryNameToIngnore)
        {
            p_classfactoriesToIgnore.Remove(fullClassfactoryNameToIngnore);
        }
    }
    #endregion

    #region Implementaciones de ArgumentVector, RIPVector, ContextVector
    public class ArgumentVector : ArrayList
    {
        public void Add(XplNode node)
        {
            node.PersistFullSourceFileInfo();
            base.Add(node);
        }
    }
    public class RIPVector : ArrayList
    {
    }
    public class ContextVector : ArrayList
    {
        public void Add(XplNode node)
        {
            node.PersistFullSourceFileInfo();
            base.Add(node);
        }
    }
    #endregion

    class DTECodeSplitter
    {
        XplDocument p_virtualSubprogram;
        XplDocument p_parameterDocument;
        CandidateStructuresCollection p_structures;
        ArgumentVector p_argumentVector;
        RIPVector p_ripVector;
        ContextVector p_contextVector;
        bool p_interactiveOnly;
        bool p_isLastSubprogramNull;
        bool p_dumpProgress;

        public DTECodeSplitter(bool dumpProgress)
        {
            p_dumpProgress = dumpProgress;
            zoe.lang.SubprogramBase.DebugRipProgress = dumpProgress;
        }

        public XplDocument get_LastSplitVirtualSubprogram()
        {
            return p_virtualSubprogram;
        }
        public XplDocument get_LastSplitParameterDocument()
        {
            return p_parameterDocument;
        }
        public ArgumentVector get_LastArgumentVector()
        {
            return p_argumentVector;
        }
        public ContextVector get_LastContextVector()
        {
            return p_contextVector;
        }
        public RIPVector get_LastRIPVector()
        {
            return p_ripVector;
        }
        public bool IsLastSubprogramNull()
        {
            if (p_virtualSubprogram == null) return true;
            return p_isLastSubprogramNull;
        }
        public bool SplitDTE(XplDocument dteDocument, CandidateStructuresCollection candidateStructuresCollection, bool interactiveOnly)
        {
            if (dteDocument == null || candidateStructuresCollection==null) return false;
            
            //OJO, por ahora uso la misma instancia ¿deberia clonar y trabajar sobre la copia?
            p_parameterDocument = dteDocument;
            p_interactiveOnly = interactiveOnly;
            p_structures = candidateStructuresCollection;

            RunSplitProcess();
            return true;
        }

        private void RunSplitProcess()
        {
            p_isLastSubprogramNull = false;
            //1º Marco de las estructuras candidatas que usare determinando las existencias.
            MarkCandidateStructures();
            //2º Construyo el Subprograma.
            BuildSubprogram();
            //3º Construyo el Documento Parametro.
            BuildParameterDocument();
        }

        #region BuildParameterDocument
        /// <summary>
        /// Con la colección de estructuras candidatas marcadas confecciona
        /// el documento parametro y las estructuras necesarias para
        /// su procesamiento durante la fabricación.
        /// </summary>
        private void BuildParameterDocument()
        {
        }
        #endregion

        #region BuildSubprogram
        /// <summary>
        /// Con la colección de estructuras candidatas marcadas
        /// confecciona el subprograma virtual.
        /// </summary>
        private void BuildSubprogram()
        {
            MakeSubprogramSkeleton();
            XplFunction main = BuildSubprogramClass();
            XplFunctionBody currentBlockNode = main.get_FunctionBody();
            XplNodeList currentBlock = currentBlockNode.Children();
            int avcount = 0, ripcount = 0, cvcount = 0;
            p_argumentVector = new ArgumentVector();
            p_ripVector = new RIPVector();
            p_contextVector = new ContextVector();
            foreach (CandidateStructure cs in p_structures)
            {
                if (cs.Existence == ExistenceType.Virtual || cs.Existence == ExistenceType.Dual)
                {
                    if (cs.CSType == CandidateStructureType.MemberInvocation)
                    {   //Llamada a función
                        if (cs.CFMemberInfo.IsStatic())
                        {
                            // Static
                            ProcessStaticMemberInvocation(currentBlock, ref avcount, ref ripcount, ref cvcount, cs);
                        }
                        else
                        {
                            // Instance
                            ProcessInstanceMemberInvocation(currentBlock, ref avcount, ref ripcount, ref cvcount, cs);
                        }
                    }
                    else if (cs.CSType == CandidateStructureType.TypeName)
                    {   //Tipo
                        ProcessTypeName(currentBlock, ref ripcount, ref cvcount, cs);
                    }
                    else if (cs.CSType == CandidateStructureType.EnterBlock)
                    {   //Entrada a Bloque
                        XplFunctionBody block = XplFunctionBody.new_bk();
                        currentBlock.InsertAtEnd(block);
                        currentBlockNode = block;
                        currentBlock = currentBlockNode.Children();
                    }
                    else if (cs.CSType == CandidateStructureType.LeaveBlock)
                    {   //Salida de Bloque
                        currentBlockNode = (XplFunctionBody)currentBlockNode.get_Parent();
                        currentBlock = currentBlockNode.Children();
                    }
                    else if (cs.CSType == CandidateStructureType.Symbol)
                    {
                        const string symbolDecl = "<Decls><d name=\"var\" ><type ispointer=\"true\"><dt typename=\"_MiTipo\" /><pi ref=\"true\" /></type><i><e ><new><type typename=\"MiTipo\" /></new></e></i></d></Decls>";
                        XplDeclaratorlist decls = XplFunctionBody.new_Decls();
                        ZoeHelper.ReadFromString(symbolDecl, decls);
                        XplDeclarator d = (XplDeclarator)decls.Children().FirstNode();
                        // d.set_name(cs.SymbolName);
                        // TODO : review when implementing full support for instance members
                        d.set_name(new XplIName().Identifier);

                        d.get_type().get_dt().set_typename(cs.CFTypeInfo.get_FullName());
                        ((XplNewExpression)d.FindNode("/new")).get_type().set_typename(cs.CFTypeInfo.get_FullName());
                        currentBlock.InsertAtEnd(decls);
                    }
                    else
                    {
                        // this must never happend
                        Debug.WriteLine("Missing CandidateStructureType on BuildSubprogram()");
                    }
                }
            }
            if (p_dumpProgress)
            {
                zoe.lang.SubprogramBase.DebugRipReportIncrement = Math.Max((int)Math.Ceiling(ripcount / 100.0), 1);
                Console.WriteLine("Total Return Instruction Points: " + ripcount);
            }

            if (avcount == 0 && ripcount == 0) p_isLastSubprogramNull = true;
            else p_isLastSubprogramNull = false;
        }

        private void ProcessTypeName(XplNodeList currentBlock, ref int ripcount, ref int cvcount, CandidateStructure cs)
        {
            //Por ahora lo proceso igual q una llamada a un metodo estatico :-) con
            //nombre _tc_internalimpl_NOMBRECLASE(...)
            XplNodeList args = cs.CallArguments;

            //Agrego el nodo de contexto al CV
            p_contextVector.Add(cs.Node);
            //Creo la expresion para asignar el contexto
            //"__context = (XplNode)RIPV[n1];
            currentBlock.InsertAtEnd(
                CreateSetContextExpression(cs, cvcount));
            //Creo la expresion "node = cf.call(AV[n1], AV[n2]..);"
            //pendiente ca cuando es void el tipo de retorno...
            currentBlock.InsertAtEnd(
                CreateSPCallExpression(cs, null));
            //Agrego el nodo de la estructura candidata a la lista de RIPs
            p_ripVector.Add(cs.Node);
            //Creo la expresion "MergeRIP(RIPV[n1], node);"
            currentBlock.InsertAtEnd(
                CreateSPMergeCallExpression(ripcount));
            cvcount++;
            ripcount++;
        }

        private void ProcessStaticMemberInvocation(XplNodeList currentBlock, ref int avcount, ref int ripcount, ref int cvcount, CandidateStructure cs)
        {
            XplNodeList args = cs.CallArguments;
            XplParameters miParams = cs.CFMemberInfo.get_Parameters();
            XplParameter miParam = null;
            XplNodeList callArgs = new XplNodeList();
            if (cs.CFMemberInfo.IsFunction() && !cs.IsComplexFunctionCall)
            {
                int n = 0;
                if (args != null)
                {
                    foreach (XplExpression argumentNode in args)
                    {
                        miParam = (XplParameter)miParams.Children().GetNodeAt(n);
                        XplType tparam = miParam.get_type();

                        if (tparam.get_ftype() == XplFactorytype_enum.NONE || tparam.get_typename() == NativeTypes.Type) //Tipo comun o "type"
                        {
                            callArgs.InsertAtEnd(argumentNode);
                        }
                        else if (tparam.get_ftype() == XplFactorytype_enum.INAME) //IName
                        {
                            XplType t;
                            if (argumentNode.get_typeStr() == "")
                            {
                                t = ZoeHelper.MakeTypeFromString(NativeTypes.Void);
                            }
                            else
                            {
                                t = ZoeHelper.MakeTypeFromString(argumentNode.get_typeStr());
                            }
                            p_argumentVector.Add(t);
                            callArgs.InsertAtEnd(CreateINameExp(argumentNode, CreateVectorAccessExpression("AV", avcount)));
                            avcount++;
                        }
                        else   //Tipo "expression" o "block" (en realidad tipo expresion, block no entra)
                        {
                            p_argumentVector.Add(GetArgumentNode(argumentNode));
                            callArgs.InsertAtEnd(
                                CreateCastExpression(
                                    CreateVectorAccessExpression("AV", avcount),
                                    "^_LayerD.CodeDOM.XplExpression"));
                            avcount++;
                        }
                        n++;
                    }
                }

                //Si el la funcion toma un bloque como argumento
                XplFunctionBody blockArgument = cs.BlockArgument;
                if (blockArgument != null)
                {
                    p_argumentVector.Add(blockArgument);
                    callArgs.InsertAtEnd(
                        CreateCastExpression(
                            CreateVectorAccessExpression("AV", avcount),
                            "^_LayerD.CodeDOM.XplFunctionBody"));
                    avcount++;
                }
            }
            else if (cs.IsComplexFunctionCall)
            {
                p_argumentVector.Add(((XplComplexfunctioncall)cs.Node).get_ce());
                callArgs.InsertAtEnd(
                    CreateCastExpression(
                        CreateVectorAccessExpression("AV", avcount),
                        "^_LayerD.CodeDOM.XplCexpression"));
                avcount++;
            }
            else if (cs.CFMemberInfo.IsProperty())
            {
                if (cs.IsPropertySet)
                {
                    // this is a property assignment (has "value argument")
                    p_argumentVector.Add(((XplAssing)cs.Node).get_r());
                    callArgs.InsertAtEnd(
                        CreateCastExpression(
                            CreateVectorAccessExpression("AV", avcount),
                            "^_LayerD.CodeDOM.XplExpression"));
                    avcount++;
                }
                else
                {
                    // this is a property read access (do not has argument)
                }
            }
            else if (cs.CFMemberInfo.IsIndexer())
            {
                // TODO : implement for indexers
            }
            //Agrego el nodo de contexto al CV
            p_contextVector.Add(cs.Node);
            //Creo la expresion para asignar el contexto
            //"__context = (XplNode)RIPV[n1];
            currentBlock.InsertAtEnd(
                CreateSetContextExpression(cs, cvcount));
            //Creo la expresion "node = cf.call(AV[n1], AV[n2]..);"
            //pendiente aca cuando es void el tipo de retorno...
            currentBlock.InsertAtEnd(
                CreateSPCallExpression(cs, callArgs));
            //Agrego el nodo de la estructura candidata a la lista de RIPs
            p_ripVector.Add(cs.Node);
            //Creo la expresion "MergeRIP(RIPV[n1], node);"
            currentBlock.InsertAtEnd(
                CreateSPMergeCallExpression(ripcount));
            cvcount++;
            ripcount++;

            // insert break check
            currentBlock.InsertAtEnd(CreateBreakCheck());
        }

        private void ProcessInstanceMemberInvocation(XplNodeList currentBlock, ref int avcount, ref int ripcount, ref int cvcount, CandidateStructure cs)
        {
            XplNodeList args = cs.CallArguments;
            XplParameters miParams = cs.CFMemberInfo.get_Parameters();
            XplParameter miParam = null;
            XplNodeList callArgs = new XplNodeList();
            if (cs.CFMemberInfo.IsFunction() && !cs.IsComplexFunctionCall)
            {
                int n = 0;
                if (args != null)
                {
                    foreach (XplExpression argumentNode in args)
                    {
                        miParam = (XplParameter)miParams.Children().GetNodeAt(n);
                        XplType tparam = miParam.get_type();

                        if (tparam.get_ftype() == XplFactorytype_enum.NONE || tparam.get_typename() == NativeTypes.Type) //Tipo comun o "type"
                        {
                            callArgs.InsertAtEnd(argumentNode);
                        }
                        else if (tparam.get_ftype() == XplFactorytype_enum.INAME)  //IName
                        {
                            XplType t;
                            if (argumentNode.get_typeStr() == "")
                            {
                                t = ZoeHelper.MakeTypeFromString(NativeTypes.Void);
                            }
                            else
                            {
                                t = ZoeHelper.MakeTypeFromString(argumentNode.get_typeStr());
                            }
                            p_argumentVector.Add(t);
                            callArgs.InsertAtEnd(CreateINameExp(argumentNode, CreateVectorAccessExpression("AV", avcount)));
                            avcount++;
                        }
                        else   //Tipo "expression" o "block"
                        {
                            p_argumentVector.Add(GetArgumentNode(argumentNode));
                            callArgs.InsertAtEnd(
                                CreateCastExpression(
                                    CreateVectorAccessExpression("AV", avcount),
                                    "^_LayerD.CodeDOM.XplExpression"));
                            avcount++;
                        }
                        n++;
                    }
                }

                //Si el la funcion toma un bloque como argumento
                XplFunctionBody blockArgument = cs.BlockArgument;
                if (blockArgument != null)
                {
                    p_argumentVector.Add(blockArgument);
                    callArgs.InsertAtEnd(
                        CreateCastExpression(
                            CreateVectorAccessExpression("AV", avcount),
                            "^_LayerD.CodeDOM.XplFunctionBody"));
                    avcount++;
                }
            }
            else if (cs.IsComplexFunctionCall)
            {
                p_argumentVector.Add(((XplComplexfunctioncall)cs.Node).get_ce());
                callArgs.InsertAtEnd(
                    CreateCastExpression(
                        CreateVectorAccessExpression("AV", avcount),
                        "^_LayerD.CodeDOM.XplCexpression"));
                avcount++;
            }
            else if (cs.CFMemberInfo.IsProperty())
            {
                if (cs.IsPropertySet)
                {
                    // this is a property assignment (has "value argument")
                    p_argumentVector.Add(((XplAssing)cs.Node).get_r());
                    callArgs.InsertAtEnd(
                        CreateCastExpression(
                            CreateVectorAccessExpression("AV", avcount),
                            "^_LayerD.CodeDOM.XplExpression"));
                    avcount++;
                }
                else
                {
                    // this is a property read access (do not has argument)
                }
            }
            else if (cs.CFMemberInfo.IsIndexer())
            {
                // TODO : implement for indexers
            }

            //Agrego el nodo de contexto al CV
            p_contextVector.Add(cs.Node);
            //Creo la expresion para asignar el contexto
            //"__context = (XplNode)RIPV[n1];
            currentBlock.InsertAtEnd(
                CreateSetContextExpression(cs, cvcount));
            //Creo la expresion "node = cf.call(AV[n1], AV[n2]..);"
            //pendiente aca cuando es void el tipo de retorno...
            currentBlock.InsertAtEnd(
                CreateSPCallExpression(cs, callArgs));
            //Agrego el nodo de la estructura candidata a la lista de RIPs
            p_ripVector.Add(cs.Node);
            //Creo la expresion "MergeRIP(RIPV[n1], node);"
            currentBlock.InsertAtEnd(
                CreateSPMergeCallExpression(ripcount));

            cvcount++;
            ripcount++;

            // insert break check
            currentBlock.InsertAtEnd(CreateBreakCheck());
        }

        private XplNode CreateBreakCheck()
        {
            var breakExp = XplFunctionBody.new_if();

            ZoeHelper.ReadFromString(
                "<if><boolean><bo op=\"m\"><l><n>this</n></l><r>" +
                "<n>BreakCompileTime</n></r></bo></boolean><ifbk>" +
                "<return></return></ifbk></if>", 
                breakExp);

            return breakExp;
        }

        private XplNode CreateINameExp(XplExpression argumentNode, XplExpression paramTypeExp)
        {
            XplNewExpression ne = XplExpression.new_new();
            ne.set_type(ZoeHelper.MakeTypeFromString("^_LayerD::CodeDOM::XplIName"));
            XplInitializerList initList = XplNewExpression.new_init();
            XplInitializerList list = XplInitializerList.new_list();
            XplLiteral lit = XplExpression.new_lit();
            lit.set_str(argumentNode.get_Content().get_StringValue());
            XplExpression litExp = XplExpressionlist.new_e();
            litExp.set_Content(lit);
            list.Children().InsertAtEnd(litExp);
            list.Children().InsertAtEnd(CreateCastExpression(paramTypeExp,"^_LayerD::CodeDOM::XplType"));
            initList.Children().InsertAtEnd(list);
            ne.set_init(initList);
            XplExpression exp = XplExpressionlist.new_e();
            exp.set_Content(ne);
            return exp;
        }
        /// <summary>
        /// Crea la expresion "zoe::lang::ClassfactoryBase::context = CV[n];" para
        /// establecer el contexto antes de llamar a la función destino.
        /// </summary>
        private XplNode CreateSetContextExpression(CandidateStructure cs, int cvcount)
        {
            XplAssing assing = XplExpression.new_a();
            if(!p_interactiveOnly)
                assing.set_l(ZoeHelper.MakeSimpleNameExpression("LayerD::ZOECompiler::ClassfactoryBase::context"));
            else
                assing.set_l(ZoeHelper.MakeSimpleNameExpression("LayerD::ZOECompiler::ClassfactoryInteractiveBase::context"));
            XplExpression node = new XplExpression();
            //ZoeHelper.ReadFromString("<e><new><type typename=\"zoe::lang::Context\" /><init><list><e><cast><e><b><l><n>CV</n></l><args><e><lit str=\"" + cvcount + "\" type=\"integer\" /></e></args></b></e><type typeStr=\"^_LayerD::CodeDOM::XplNode\"  ispointer=\"true\"><dt typename=\"LayerD::CodeDOM::XplNode\" /><pi ref=\"true\" /></type></cast></e></list></init></new></e>", node);
            ZoeHelper.ReadFromString("<e><cast><e><b><l><n>CV</n></l><args><e><lit str=\"" + cvcount + "\" type=\"integer\" /></e></args></b></e><type typeStr=\"^_LayerD::CodeDOM::XplNode\"  ispointer=\"true\"><dt typename=\"LayerD::CodeDOM::XplNode\" /><pi ref=\"true\" /></type></cast></e>", node);
            assing.set_r(node);
            XplExpression retExp = XplFunctionBody.new_e();
            retExp.set_Content(assing);
            return retExp;
        }
        /// <summary>
        /// Devuelve el nodo adecuado a agregar al Argument Vector
        /// del subprograma virtual de acuerdo si la expresion es una 
        /// expresion, un tipo o un iname.
        /// </summary>
        private XplNode GetArgumentNode(XplExpression argumentNode)
        {
            if (argumentNode.get_typeStr() == NativeTypes.Type)
                return argumentNode.get_Content();
            else
                return argumentNode;
        }

        private XplExpression CreateCastExpression(XplExpression xplExpression, XplType xplType)
        {
            return CreateCastExpression(xplExpression, xplType.get_typeStr());
        }
        private XplExpression CreateCastExpression(XplExpression xplExpression, string xplType)
        {
            XplCastexpression cast = XplExpression.new_cast();
            cast.set_type(ZoeHelper.MakeTypeFromString(xplType));
            cast.get_type().set_typeStr(xplType);
            cast.set_e(xplExpression);
            XplExpression retExp = XplExpressionlist.new_e();
            retExp.set_Content(cast);
            return retExp;
        }
        /// <summary>
        /// Crea una expresion de la forma "vectorName[avcount]".
        /// </summary>
        private XplExpression CreateVectorAccessExpression(string vectorName, int avcount)
        {
            XplFunctioncall fc = XplExpression.new_b();
            XplNode name = XplExpression.new_n();
            name.set_Value(vectorName);
            fc.set_l(new XplExpression(name));
            XplExpressionlist args = new XplExpressionlist();
            XplExpression argExp = XplExpressionlist.new_e();
            XplLiteral lit = new XplLiteral(avcount.ToString(CultureInfo.InvariantCulture), "");
            lit.set_type(XplLiteraltype_enum.INTEGER);
            lit.set_ElementName("lit");
            argExp.set_Content(lit);
            args.Children().InsertAtEnd(argExp);
            fc.set_args(args);
            XplExpression retExp = XplExpressionlist.new_e();
            retExp.set_Content(fc);
            return retExp;
        }
        /// <summary>
        /// Crea la expresion "MergeRIP(RIPV[n1], node);"
        /// 
        /// Usando el valor de "ripCount" para indexar RIPV.
        /// </summary>
        private XplExpression CreateSPMergeCallExpression(int ripcount)
        {
            XplFunctioncall fc = XplExpression.new_fc();
            XplNode name = XplExpression.new_n();
            name.set_Value("MergeRIP");
            fc.set_l(new XplExpression(name));
            //Argumentos
            XplExpressionlist args = XplFunctioncall.new_args();
            XplExpression arg1 = CreateVectorAccessExpression("RIPV", ripcount);
            XplExpression arg2 = XplExpressionlist.new_e();
            XplExpression arg3 = XplExpressionlist.new_e();
            name = XplExpression.new_n();
            name.set_Value("node");
            arg2.set_Content(name);
            XplLiteral literal = XplExpression.new_lit();
            literal.set_str(Convert.ToString(ripcount, NumberFormatInfo.InvariantInfo));
            literal.set_type(XplLiteraltype_enum.INTEGER);
            arg3.set_Content(literal);

            args.Children().InsertAtEnd(arg1);
            args.Children().InsertAtEnd(arg2);
            args.Children().InsertAtEnd(arg3);
            fc.set_args(args);
            //retorno la expresion
            XplExpression retExp = XplExpressionlist.new_e();
            retExp.set_Content(fc);
            return retExp;
        }
        /// <summary>
        /// Crea la expresion "node = cf.call(AV[n1], AV[n2]..);"
        /// 
        /// "callArgs" es la lista de expresiones "AV[n1], AV[n2].." ya creada.
        /// </summary>
        private XplExpression CreateSPCallExpression(CandidateStructure cs, XplNodeList callArgs)
        {
            XplExpression retExp;
            MemberInfo mi = cs.CFMemberInfo;
            XplNode nodeNameExp = new XplNode("n", "node");

            XplFunctioncall callExp = XplExpression.new_fc();
            if (callArgs != null)
            {
                callExp.set_args(new XplExpressionlist(callArgs));
            }

            if (mi == null || mi != null && mi.IsConstructor() && mi.get_ReturnType() != null) //Constructor de tipo
            {
                string constructorPrefix = ClassfactoryModuleGenerator.TYPECONSTRUCTOR_PREFIX;
                if (mi!=null && !NativeTypes.IsNativeType(mi.get_ReturnType().get_typename())) constructorPrefix = ClassfactoryModuleGenerator.INSTANCE_TYPECONSTRUCTOR_PREFIX;

                XplNode leftName = new XplNode("n", cs.CFTypeInfo.get_FullName() + "." + constructorPrefix + cs.CFTypeInfo.get_Name());
                callExp.set_l(new XplExpression(leftName));
                callExp.set_targetClass(cs.CFTypeInfo.get_FullName());
                callExp.set_targetMember(constructorPrefix + cs.CFTypeInfo.get_Name());
                //callExp.set_virtualCall(false);
            }
            else
            {
                //Funcion
                if (mi.IsStatic())
                {
                    XplNode leftName = null;
                    if (mi.IsOperator())
                    {
                        leftName = new XplNode("n", cs.CFTypeInfo.get_FullName() + "::" + ClassfactoryModuleGenerator.GetFunctionNameFromOperator( mi.get_MemberName() ));
                    }
                    else if (mi.IsProperty() || mi.IsIndexer())
                    {
                        string memberName = mi.get_MemberName();
                        if (cs.IsPropertySet) memberName = "__set_" + memberName;
                        else memberName = "__get_" + memberName;
                        leftName = new XplNode("n", cs.CFTypeInfo.get_FullName() + "::" + memberName);
                        // TODO : warning, check this isn´t the real internal member name
                        callExp.set_targetMember(memberName);
                    }
                    else
                    {
                        leftName = new XplNode("n", cs.CFTypeInfo.get_FullName() + "::" + mi.get_MemberName());
                        callExp.set_targetMember(mi.get_MemberInternalName());
                    }
                    callExp.set_l(new XplExpression(leftName));
                    callExp.set_targetClass(mi.get_ClassTypeFullName());
                }
                else
                {
                    // PENDIENTE : implementar cuando no es un llamada a un miembro estatico.
                    XplExpression leftExp = null;
                    if (mi.IsProperty())
                    {
                        string memberName = mi.get_MemberName();
                        if (cs.IsPropertySet) memberName = "__set_" + memberName;
                        else memberName = "__get_" + memberName;

                        if (cs.Node.get_TypeName() == CodeDOMTypes.XplBinaryoperator)
                        {
                            // create a binary operator
                            XplBinaryoperator boexp = XplExpression.new_bo();
                            // set right to internal method name
                            boexp.set_r(new XplExpression(XplExpression.new_n()));
                            boexp.get_r().get_Content().set_Value(memberName);
                            // set left to context node left
                            boexp.set_l(((XplBinaryoperator)cs.Node).get_l());
                            leftExp = new XplExpression(boexp);
                        }
                        else
                        {
                            //it´s a XplNode, using implicit this
                            leftExp = new XplExpression(XplExpression.new_n());
                            leftExp.get_Content().set_Value(memberName);
                        }
                    }
                    else
                    {
                        leftExp = ((XplFunctioncall)cs.Node).get_l();
                    }
                    bool createInstance = false;
                    CodeDOMTypes leftExpNodeType = leftExp.get_Content().get_TypeName();
                    if (leftExpNodeType == CodeDOMTypes.XplNode)
                    {
                        // This is a call to inherited member by simple class using "this"
                        createInstance = true;
                    }
                    else if (leftExpNodeType == CodeDOMTypes.XplBinaryoperator)
                    {
                        string symbol = ((XplBinaryoperator)leftExp.get_Content()).get_l().get_Content().get_StringValue();

                        // PENDIENTE : urgente cambiar esto y evitar q cada llamada a 
                        // classfactory sea una nueva instancia
                        // if (symbol == "this" || symbol == "base")
                        {
                            createInstance = true;
                            leftExp = ((XplBinaryoperator)leftExp.get_Content()).get_r();
                        }
                    }

                    if (createInstance)
                    {
                        XplNewExpression newExp = XplExpression.new_new();
                        newExp.set_type(ZoeHelper.MakeTypeFromString(cs.CFTypeInfo.get_FullName()));
                        XplBinaryoperator bop = XplExpression.new_bo();
                        bop.set_l(new XplExpression(newExp));
                        bop.set_r(leftExp);
                        bop.set_op(XplBinaryoperators_enum.M);
                        callExp.set_l(new XplExpression(bop));
                    }
                    else
                    {
                        callExp.set_l(leftExp);
                    }

                    callExp.set_targetClass(mi.get_ClassTypeFullName());
                    callExp.set_targetMember(mi.get_MemberInternalName());
                    //callExp.set_virtualCall(false);
                }
            }

            XplAssing assingExp = new XplAssing(new XplExpression(nodeNameExp), new XplExpression(callExp));
            assingExp.set_ElementName("a");
            retExp = XplExpressionlist.new_e();
            retExp.set_Content(assingExp);
            return retExp;
        }
        #endregion

        #region MarkCandidateStructures
        /// <summary>
        /// Marca las estructuras candidatas determinando la existencia
        /// Documental (por defecto), Virtual o Dual.
        /// 
        /// También realiza el calculo de bloqueo de estructuras candidatas.
        /// Al finalizar el metodo deja la colección de estructuras candidatas
        /// lista para confeccionar el subprograma virtual.
        /// </summary>
        private void MarkCandidateStructures()
        {
            //PENDIENTE : que funcione correctamente en todos los casos
            //y no solo cuando son llamadas a funciones estaticas!!!!!!
            foreach (CandidateStructure cs in p_structures)
            {
                if (cs.CSType == CandidateStructureType.MemberInvocation)
                {   
                    //Es una llamada a función.
                    if (cs.CFMemberInfo.IsStatic())
                    {   
                        //Es un miembro estático
                        //Controlo los argumentos de la funcion, si todos
                        //son correctos entonces la marco como de existencia
                        //virtual.
                        if (cs.CheckArgumentsForFunction())
                        {
                            cs.Existence = ExistenceType.Virtual;
                        }
                    }
                    else
                    {   
                        //Es un miembro de instancia
                        if (cs.CheckArgumentsForFunction())
                        {
                            cs.Existence = ExistenceType.Virtual;
                        }
                    }
                }
                else if (cs.CSType == CandidateStructureType.TypeName)
                {   
                    //Es un tipo
                    cs.Existence = ExistenceType.Virtual;
                }
                else if (cs.CSType == CandidateStructureType.EnterBlock)
                {   
                    //Es una apertura bloque
                }
                else if (cs.CSType == CandidateStructureType.LeaveBlock)
                {   
                    //Es un cierre de bloque
                }
                else if (cs.CSType == CandidateStructureType.Symbol)
                {   
                    //Un simbolo
                    if (cs.CFTypeInfo.get_HasDefaultTypeConstructor())
                        cs.Existence = ExistenceType.Dual;
                    else
                        cs.Existence = ExistenceType.Virtual;
                }
            }
        }
        #endregion

        #region MakeSubprogramSkeleton, BuildSubprogramClass
        private void MakeSubprogramSkeleton()
        {
            p_virtualSubprogram = new XplDocument();
            p_virtualSubprogram.set_ElementName("ZOEDocument");
            XplDocumentData data = XplDocument.new_DocumentData();
            data.set_DocumentType(XplDocumenttype_enum.VIRTUAL_SUBPROGRAM_LAYERD_ZOE);
            XplDocumentBody body = XplDocument.new_DocumentBody();
            p_virtualSubprogram.set_DocumentData(data);
            p_virtualSubprogram.set_DocumentBody(body);
        }
        private XplFunction BuildSubprogramClass()
        {
            XplNodeList progBody = p_virtualSubprogram.get_DocumentBody().Children();
            //Imports y Usings
            // import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
            XplName import = XplDocumentBody.new_Import();
            XplNode node = XplName.new_ns();
            node.set_Value("System");
            import.Children().InsertAtEnd(node);
            node = XplName.new_ns();
            node.set_Value("platform=DotNET");
            import.Children().InsertAtEnd(node);
            node = XplName.new_ns();
            node.set_Value("ns=DotNET");
            import.Children().InsertAtEnd(node);            
            node = XplName.new_ns();
            node.set_Value("assembly=mscorlib");
            import.Children().InsertAtEnd(node);
            progBody.InsertAtEnd(import);
            
            XplName usng = XplDocumentBody.new_Using();
            XplNode usgName = new XplNode("ns", "LayerD::CodeDOM");
            usng.Children().InsertAtEnd(usgName);
            progBody.InsertAtEnd(usng);
            usng = XplDocumentBody.new_Using();
            usgName = new XplNode("ns", "LayerD::ZOECompiler");
            usng.Children().InsertAtEnd(usgName);
            progBody.InsertAtEnd(usng);

            //Espacio de nombres
            XplNamespace spns = XplDocumentBody.new_Namespace();
            progBody.InsertAtEnd(spns);
            spns.set_name("lang::spns");
            XplClass spclass = XplNamespace.new_Class();
            spns.Children().InsertAtEnd(spclass);
            spclass.set_name("Subprogram");
            XplInherits inhs = XplClass.new_Inherits();
            XplInherit inh = XplInherits.new_c();
            inh.set_type(new XplType());
            inh.get_type().set_typename("zoe::lang::SubprogramBase");
            inh.set_access(XplAccesstype_enum.PUBLIC);
            inhs.Children().InsertAtEnd(inh);
            spclass.Children().InsertAtEnd(inhs);
            XplFunction main = XplClass.new_Function();
            spclass.Children().InsertAtEnd(main);
            main.set_name("Run");
            main.set_access(XplAccesstype_enum.PUBLIC);
            main.set_FunctionBody(XplFunction.new_FunctionBody());
            //Tipo de retorno            
            main.set_ReturnType(ZoeHelper.MakeTypeFromString("$VOID$"));
            //Parametros
            XplParameters parameters = new XplParameters();
            main.set_Parameters(parameters);
            //Parametro 1
            XplParameter param = XplParameters.new_P();
            param.set_name("AV");
            param.set_number(1);
            param.set_type(ZoeHelper.MakeTypeFromString("^_LayerD::ZOECompiler::ArgumentVector"));
            parameters.Children().InsertAtEnd(param);
            //Parametro 2
            param = XplParameters.new_P();
            param.set_name("RIPV");
            param.set_number(2);
            param.set_type(ZoeHelper.MakeTypeFromString("^_LayerD::ZOECompiler::RIPVector"));
            parameters.Children().InsertAtEnd(param);
            //Parametro 3
            param = XplParameters.new_P();
            param.set_name("CV");
            param.set_number(3);
            param.set_type(ZoeHelper.MakeTypeFromString("^_LayerD::ZOECompiler::ContextVector"));
            parameters.Children().InsertAtEnd(param);
            //Declaracion de "node"
            XplDeclaratorlist dl = XplFunctionBody.new_Decls();
            XplDeclarator decl = XplDeclaratorlist.new_d();
            dl.Children().InsertAtEnd(decl);
            decl.set_name("node");
            decl.set_type(ZoeHelper.MakeTypeFromString("^_LayerD::CodeDOM::XplNode"));
            main.get_FunctionBody().Children().InsertAtEnd(dl);

            return main;
        }
        #endregion
    }
}
