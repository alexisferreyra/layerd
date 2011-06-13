/****************************************************************************
 
  Base library for Zoe Output Modules
  
  Original Author: Alexis Ferreyra
  Contact: alexis.ferreyra@layerd.net
  
  Please visit http://layerd.net to get the last version
  of the software and information about LayerD technology.

****************************************************************************/
/*-
 * Copyright (c) 2008 Alexis Ferreyra
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 * 3. Neither the name of copyright holders nor the names of its
 *    contributors may be used to endorse or promote products derived
 *    from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
 * TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
 * PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL COPYRIGHT HOLDERS OR CONTRIBUTORS
 * BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Xml;
using System.Collections;
using LayerD.CodeDOM;

namespace LayerD.OutputModules
{
	/// <summary>
	/// ExtendedZOEProcessor.
	/// 
	/// Procesa archivos XML de código ZOE Extendido y genera eventos 
	/// para renderizar cada elemento. Es una clase abstracta que debe ser
	/// heredada por un generador en particular, por ejemplo un generador
	/// para C#.
	/// </summary>
	public abstract class ExtendedZOEProcessor 
	{
		#region Tipos Anidados Publicos
		public enum EZOEClassType{
			Class,
			Struct,
			Interface,
            Enum,
			Union
		}
		public enum EZOEContext{
			DocumentBody,
			NamespaceBody,
			ClassBody,
			ClassDecl,
			FunctionBody,
			FunctionDecl,
			PropertyBody,
			PropertyDecl,
			Statement,
			Expression,
			CaseLabel,
            Inherits,
		}
		public enum EZOETypeContext{
			ReturnTypeDecl,
			ParameterDecl,
			FieldDecl,
			LocalVarDecl,
			ForVarDecl,
			CatchVarDecl,
			PropertyDecl,
			SizeofExp,
			GettypeExp,
			CastExp,
			Expression,
			Unknow
		}
		#endregion

		#region Datos Privados o Protegidos
		protected string p_inputFileName="";
        protected string p_currentNS = "";
		protected XplDocument p_XplDocument=null;
		protected XplReader p_reader=null;
        protected Hashtable p_ignoredClasses = null;
		#endregion

		#region Constructores
		public ExtendedZOEProcessor(){
            Initialize();
		}
		public ExtendedZOEProcessor(string new_inputFileName){
			p_inputFileName=new_inputFileName;
            Initialize();
		}
        private void Initialize()
        {
            p_ignoredClasses = new Hashtable();
            //El formato de las clases a ignorar es 
            //[NombreClase]=Clave;[NombreEspaciodeNombres]=Valor;
            //
            p_ignoredClasses.Add("String", "zoe.lang");
            p_ignoredClasses.Add("Object", "zoe.lang");
            p_ignoredClasses.Add("Null", "zoe.lang");
            p_ignoredClasses.Add("Char", "zoe.lang");
            p_ignoredClasses.Add("ASCIIChar", "zoe.lang");
            p_ignoredClasses.Add("ASCIIString", "zoe.lang");
            p_ignoredClasses.Add("DateTime", "zoe.lang");
            p_ignoredClasses.Add("TimeSpan", "zoe.lang");
            p_ignoredClasses.Add("Array", "zoe.lang");

            p_ignoredClasses.Add("Boolean", "zoe.lang");
            p_ignoredClasses.Add("Byte", "zoe.lang");
            p_ignoredClasses.Add("Short", "zoe.lang");
            p_ignoredClasses.Add("Integer", "zoe.lang");
            p_ignoredClasses.Add("Long", "zoe.lang");
            p_ignoredClasses.Add("SByte", "zoe.lang");
            p_ignoredClasses.Add("UShort", "zoe.lang");
            p_ignoredClasses.Add("Unsigned", "zoe.lang");
            p_ignoredClasses.Add("ULong", "zoe.lang");
            p_ignoredClasses.Add("Float", "zoe.lang");
            p_ignoredClasses.Add("Double", "zoe.lang");
            p_ignoredClasses.Add("LDouble", "zoe.lang");
            p_ignoredClasses.Add("Decimal", "zoe.lang");
        }
		#endregion

		#region Parse
		protected bool ParseDocument(){
			p_reader=null;
            if (p_XplDocument == null)
            {
                if (p_inputFileName == "") throw new Exception("Primero establezca el archivo a compilar.");
                try
                {
                    p_reader = new XplReader(p_inputFileName);
                    p_reader.WhitespaceHandling = WhitespaceHandling.None;
                    p_XplDocument = new XplDocument();
                    p_reader.Read();
                    if (p_XplDocument.Read(p_reader) != null)
                    {
                        //Proceso primero la configuracion del documento
                        processDocumentData(p_XplDocument.get_DocumentData());
                        processDocumentBody(p_XplDocument.get_DocumentBody());
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    if (p_reader != null) p_reader.Close();
                }
            }
            else
            {
                processDocumentData(p_XplDocument.get_DocumentData());
                processDocumentBody(p_XplDocument.get_DocumentBody());
                return true;
            }
			return false;
		}
		#endregion

		#region Funciones de Procesamiento de cada tipo elemento

		#region Documento
		protected void processDocumentBody(XplDocumentBody documentBody){
            renderBeginDocumentBody(documentBody);
			XplNamespace p_namespace;
            XplNodeList imports = documentBody.get_ImportNodeList();
            foreach (XplNode node in imports)
            {
                switch (node.get_ElementName())
                {
                    case "Import":
                        renderImportDirective((XplName)node);
                        break;
                }
            }

			foreach(XplNode node in documentBody.Children()){
				switch(node.get_ElementName()){
					case "Import":
						//renderImportDirective((XplName)node);
						break;
                    case "Section":
                    case "Namespace":
						p_namespace=(XplNamespace)node;
						renderBeginNamespace( p_namespace.get_name() , p_namespace, EZOEContext.DocumentBody );
						processNamespace( p_namespace );
						renderEndNamespace( p_namespace.get_name() , p_namespace, EZOEContext.DocumentBody );
						break;
                    case "Using":
                        renderUsingDirective((XplName)node, EZOEContext.DocumentBody);
                        break;
                    case "e":
                        processExpressionStatement((XplExpression)node, EZOEContext.DocumentBody);
                        break;
                    case "documentation":
                        renderDocumentation((XplDocumentation)node, EZOEContext.DocumentBody);
                        break;
                    default:
						renderUnrecognizedNode( node , EZOEContext.DocumentBody );
						break;
				}
			}
            renderEndDocumentBody(documentBody);
		}

        protected abstract void renderUsingDirective(XplName xplName, EZOEContext eZOEContext);
		#endregion

		#region Declaraciones
		protected void processNamespace(XplNamespace namespaceDecl){
			XplNamespace p_namespace=null;
            p_currentNS = namespaceDecl.get_name().Replace("::", ".");
			foreach(XplNode node in namespaceDecl.Children()){
				switch(node.get_ElementName()){
					case "Class":
						processClass( (XplClass)node, EZOEContext.NamespaceBody );
						break;
                    case "Section":
					case "Namespace":
						p_namespace=(XplNamespace)node;
						renderBeginNamespace( p_namespace.get_name() , p_namespace, EZOEContext.NamespaceBody );
						processNamespace( p_namespace );
						renderEndNamespace( p_namespace.get_name() , p_namespace, EZOEContext.NamespaceBody );
						break;
                    case "e":
                        processExpressionStatement((XplExpression)node, EZOEContext.NamespaceBody);
                        break;
                    case "documentation":
                        renderDocumentation((XplDocumentation)node, EZOEContext.NamespaceBody);
                        break;
                    default:
						renderUnrecognizedNode( node , EZOEContext.NamespaceBody );
						break;
				}
			}
		}
		protected void processClass(XplClass classDecl, EZOEContext context){
            //Primero chequeo si es una clase q debo ignorar
            string checkStr = (string)p_ignoredClasses[classDecl.get_name()];
            if (checkStr != null && checkStr == p_currentNS) return;
			//Preparo varaibles temporales
			string implementsStr=renderImplements(classDecl,classDecl.get_ImplementsNodeList(), context);
			string inheritsStr=renderInherits(classDecl,classDecl.get_InheritsNodeList(), context);
			EZOEClassType classType=EZOEClassType.Class;
            if (classDecl.get_isinterface()) classType = EZOEClassType.Interface;
            else if (classDecl.get_isstruct()) classType = EZOEClassType.Struct;
            else if (classDecl.get_isunion()) classType = EZOEClassType.Union;
            else if (classDecl.get_isenum()) classType = EZOEClassType.Enum;
			//Renderizo
			renderBeginClass(classType, classDecl.get_name(),implementsStr,inheritsStr,
				classDecl.get_access(),classDecl.get_new(),classDecl.get_abstract(),
				classDecl.get_final(),classDecl,context);

            processClassMembers(classDecl.Children(), EZOEContext.ClassDecl);

			renderEndClass(classType, classDecl.get_name(),classDecl,context);
		}

        protected void processClassMembers(XplNodeList membersNodeList, EZOEContext eZOEContext)
        {
            foreach (XplNode node in membersNodeList)
            {
                switch (node.get_ElementName())
                {
                    case "Inherits":
                    case "Implements":
                        //Ignoro estos nodos que ya procese durante "renderBeginClass".
                        break;
                    case "Class":
                        processClass((XplClass)node, EZOEContext.ClassBody);
                        break;
                    case "Function":
                    case "Operator":
                    case "Indexer":
                        processFunction((XplFunction)node, ((XplFunction)node).get_access(), EZOEContext.ClassBody);
                        break;
                    case "Property":
                        processProperty((XplProperty)node, ((XplProperty)node).get_access(), EZOEContext.ClassBody);
                        break;
                    case "Field":
                        processField((XplField)node, ((XplField)node).get_access(), EZOEContext.ClassBody);
                        break;
                    case "e":
                        processExpressionStatement((XplExpression)node, EZOEContext.ClassBody);
                        break;
                    case "documentation":
                        renderDocumentation((XplDocumentation)node, EZOEContext.ClassBody);
                        break;
                    default:
                        renderUnrecognizedNode(node, EZOEContext.ClassBody);
                        break;
                }
            }
        }
		protected void processFunction(XplFunction functionDecl, XplAccesstype_enum access , EZOEContext context){
			//variables temporales
			string returnTypeStr=renderType(functionDecl.get_ReturnType(), "", EZOETypeContext.ReturnTypeDecl, context);
			string parametersStr=processParameters(functionDecl.get_Parameters(), functionDecl, context);
			//Renderizo
			renderBeginFunction(functionDecl, functionDecl.get_name(), returnTypeStr, parametersStr, access,
				functionDecl.get_storage(),	functionDecl.get_abstract(), functionDecl.get_final(), 
				functionDecl.get_fp(), functionDecl.get_new(), functionDecl.get_isconst(), 
				functionDecl.get_override(), functionDecl.get_virtual(), context);
			
			processFunctionBody( functionDecl.get_FunctionBody(), context );
			
			renderEndFunction(functionDecl, functionDecl.get_name(), context);
		}
		protected void processProperty(XplProperty propertyDecl, XplAccesstype_enum access , EZOEContext context){
			//variables temporales
			string typeStr=renderType(propertyDecl.get_type(), propertyDecl.get_name(), EZOETypeContext.PropertyDecl, context);
			//Renderizo
			renderBeginProperty(propertyDecl, propertyDecl.get_name(), typeStr, access, propertyDecl.get_storage(),	
				propertyDecl.get_abstract(), propertyDecl.get_final(), propertyDecl.get_new(), 
				propertyDecl.get_isconst(), propertyDecl.get_override(), propertyDecl.get_virtual(), context);
			
			if(propertyDecl.get_body()!=null)
			foreach(XplNode node in propertyDecl.get_body().Children()){
				if(node.get_ElementName()=="Get"){
					renderBeginGetAccess( EZOEContext.PropertyBody, (XplFunctionBody)node);
					processFunctionBody( (XplFunctionBody)node, EZOEContext.PropertyBody );
					renderEndGetAccess( EZOEContext.PropertyBody, (XplFunctionBody)node);
				}
				else if(node.get_ElementName()=="Set"){
					renderBeginSetAccess( EZOEContext.PropertyBody, (XplFunctionBody)node);
					processFunctionBody( (XplFunctionBody)node, EZOEContext.PropertyBody );
					renderEndSetAccess( EZOEContext.PropertyBody, (XplFunctionBody)node);
				}
				else if(node.get_ElementName()=="documentation"){
					renderDocumentation( (XplDocumentation)node, EZOEContext.PropertyBody );
				}
				else{
					renderUnrecognizedNode( node , EZOEContext.PropertyBody );
				}
			}

			renderEndProperty(propertyDecl, propertyDecl.get_name(), context);
		}

		protected void processField(XplField fieldDecl, XplAccesstype_enum access , EZOEContext context){
			string typeStr=renderType(fieldDecl.get_type(), fieldDecl.get_name(), EZOETypeContext.FieldDecl, context);
			string initializerStr=processInitializer(fieldDecl.get_i(), context);
			renderField(fieldDecl, fieldDecl.get_name(),typeStr, initializerStr, access,
				fieldDecl.get_storage(), fieldDecl.get_new(), fieldDecl.get_type().get_volatile())	;
		}
		protected string processParameters(XplParameters parametersDecl, XplFunction functionDecl, EZOEContext context){
			if(parametersDecl==null)return "";
			string returnStr="";
			renderBeginParameters(parametersDecl, parametersDecl.Children().GetLength(), functionDecl, context);
			foreach(XplNode node in parametersDecl.Children()){
				switch(node.get_ElementName()){
					case "P":
						returnStr+=processParameter( (XplParameter)node, EZOEContext.ClassBody );
						break;
					default:
						renderUnrecognizedNode( node , EZOEContext.FunctionDecl );
						break;
				}
			}
			renderEndParameters(parametersDecl,context);
            if(returnStr!="")
            if (returnStr[returnStr.Length-2] == ',') returnStr = returnStr.Substring(0, returnStr.Length - 2);
			return returnStr;
		}

		protected string processParameter(XplParameter parameter, EZOEContext context){
			if(parameter==null)return "";
			string typeStr=renderType(parameter.get_type(), parameter.get_name(), EZOETypeContext.ParameterDecl, context);
			string initializerStr=processInitializer(parameter.get_i(), EZOEContext.FunctionDecl);
			return renderParameter(parameter, parameter.get_name(), typeStr, initializerStr, parameter.get_direction(), 
				(int)parameter.get_number(), parameter.get_params(), parameter.get_type().get_volatile());
		}
		#endregion

		#region Instrucciones
		protected void processFunctionBody(XplFunctionBody functionBody, EZOEContext context){
			if(functionBody==null)return;
			renderBeginBlock(functionBody,context);
            processFunctionBodyNodes(functionBody);
			renderEndBlock(functionBody,context);
		}

        protected void processFunctionBodyNodes(XplFunctionBody functionBody)
        {
            foreach (XplNode node in functionBody.Children())
            {
                switch (node.get_ElementName())
                {
                    case "label":
                        renderLabel((XplNode)node, EZOEContext.FunctionBody);
                        break;
                    case "setonerror":
                        renderSetonerror((XplSetonerror)node, EZOEContext.FunctionBody);
                        break;
                    case "Decls":
                        processDecls((XplDeclaratorlist)node, EZOEContext.FunctionBody);
                        break;
                    case "e":
                        processExpressionStatement((XplExpression)node, EZOEContext.FunctionBody);
                        break;
                    case "switch":
                        processSwitch((XplSwitchStatement)node, EZOEContext.FunctionBody);
                        break;
                    case "if":
                        processIf((XplIfStatement)node, EZOEContext.FunctionBody, false);
                        break;
                    case "for":
                        processFor((XplForStatement)node, EZOEContext.FunctionBody);
                        break;
                    case "do":
                        processDo((XplDowhileStatement)node, EZOEContext.FunctionBody, true);
                        break;
                    case "while":
                        processDo((XplDowhileStatement)node, EZOEContext.FunctionBody, false);
                        break;
                    case "Get":
                        renderBeginGetAccess(EZOEContext.PropertyBody, (XplFunctionBody)node);
                        processFunctionBody((XplFunctionBody)node, EZOEContext.PropertyBody);
                        renderEndGetAccess(EZOEContext.PropertyBody, (XplFunctionBody)node);
                        break;
                    case "Set":
                        renderBeginSetAccess(EZOEContext.PropertyBody, (XplFunctionBody)node);
                        processFunctionBody((XplFunctionBody)node, EZOEContext.PropertyBody);
                        renderEndSetAccess(EZOEContext.PropertyBody, (XplFunctionBody)node);
                        break;
                    case "bk":
                        processFunctionBody((XplFunctionBody)node, EZOEContext.FunctionBody);
                        break;
                    case "onpointer":
                        processOnpointer((XplFunctionBody)node, EZOEContext.FunctionBody);
                        break;
                    case "try":
                        processTry((XplTryStatement)node, EZOEContext.FunctionBody);
                        break;
                    case "throw":
                        processThrow((XplExpression)node, EZOEContext.FunctionBody);
                        break;
                    case "return":
                        processReturn((XplExpression)node, EZOEContext.FunctionBody);
                        break;
                    case "jump":
                        processJump((XplJump)node, EZOEContext.FunctionBody);
                        break;
                    case "directoutput":
                        processDirectoutput((XplDirectoutput)node, EZOEContext.FunctionBody);
                        break;
                    case "documentation":
                        renderDocumentation((XplDocumentation)node, EZOEContext.FunctionBody);
                        break;
                    default:
                        renderUnrecognizedNode(node, EZOEContext.FunctionBody);
                        break;
                }
            }
        }
		protected void processDecls( XplDeclaratorlist decls , EZOEContext context ){
			foreach(XplDeclarator decl in decls.Children()){
				processLocalDeclarator( decl , EZOETypeContext.LocalVarDecl, context );
			}
		}
		protected void processLocalDeclarator( XplDeclarator decl, EZOETypeContext typeContext, EZOEContext context ){
			string typeStr=renderType(decl.get_type(), decl.get_name(), typeContext, context);
			string initializerStr=processInitializer(decl.get_i(), context);
			renderLocalDeclarator(decl, decl.get_name(),typeStr, initializerStr, decl.get_type().get_volatile())	;
		}
        protected string processInitializer(XplInitializerList initializerList, EZOEContext context)
        {
            if (initializerList == null) return "";
            string retStr = "";
            int maxNodes=0,count=0;
            if (initializerList.get_array())
            {   //Inicializador de arrays
                retStr+=renderBeginArrayInitializer(initializerList, context);
                maxNodes=initializerList.Children().GetLength();
                foreach (XplNode node in initializerList.Children())
                {
                    count++;
                    switch (node.get_ElementName())
                    {
                        case "e":
                            retStr += renderInitilizerItem(node, processExpression((XplExpression)node, context), maxNodes, count, context);
                            break;
                        case "list":
                            retStr += renderInitilizerItem(node, processInitializer((XplInitializerList)node, context), maxNodes, count, context);
                            break;
                    }
                }
                retStr += renderEndArrayInitializer(initializerList, context);
            }
            else
            {
                XplNode node = initializerList.Children().FirstNode();
                if (node != null)
                    if (node.get_ElementName() == "e")
                    {   //Inicializador de expresion simple
                        XplExpression exp=(XplExpression)node;
                        retStr += renderSimpleInitializer(exp, processExpression(exp, context), context);
                    }
                    else
                    {
                        XplInitializerList list = (XplInitializerList)node;
                        retStr += renderBeginInitializerList(initializerList, context);
                        maxNodes = list.Children().GetLength();
                        count = 0;
                        foreach (XplNode node2 in list.Children())
                        {
                            count++;
                            switch (node2.get_ElementName())
                            {
                                case "e":
                                    retStr += renderInitilizerItem(node2, processExpression((XplExpression)node2, context), maxNodes, count, context);
                                    break;
                                case "list":
                                    retStr += renderInitilizerItem(node2, processInitializer((XplInitializerList)node2, context), maxNodes, count, context);
                                    break;
                            }
                        }
                        retStr += renderEndInitializerList(initializerList, context);
                    }
            }
            return retStr;
        }
		protected void processExpressionStatement( XplExpression expression , EZOEContext context ){
			string expStr=processExpression(expression,context);
			renderExpressionStatement(expression, expStr, context);
		}
		protected void processSwitch( XplSwitchStatement switchSta , EZOEContext context ){
			string boolExpStr=processExpression(switchSta.get_e(),context);
			renderBeginSwitch(switchSta, boolExpStr, context);
			foreach(XplCase caseNode in switchSta.get_case()){
				renderCaseLabel(caseNode, processExpression(caseNode.get_e(),context),context);
				processFunctionBody(caseNode.get_bk(),EZOEContext.CaseLabel);
			}
			renderEndSwitch(switchSta, context);
		}
		protected void processIf( XplIfStatement ifSta , EZOEContext context, bool isElse ){
			string boolExp=processExpression(ifSta.get_boolean(),context);
			renderIfStatement(ifSta, boolExp, isElse,context);
			processFunctionBody(ifSta.get_ifbk(), context);
			foreach(XplIfStatement elseSta in ifSta.get_elseif()){
				processIf(elseSta, context, true);
			}
			renderElseStatement(ifSta, ifSta.get_else(),context);
			processFunctionBody(ifSta.get_else(),context);
		}
		protected void processFor( XplForStatement forSta , EZOEContext context ){
			string initStr=processForInit(forSta.get_init(),context);
			string boolExpStr=processExpression(forSta.get_condition(),context);
			string updateStr=processExpressionList(forSta.get_repeat(),context);
			renderForStatement(forSta, initStr, boolExpStr, updateStr, context);
			processFunctionBody(forSta.get_forblock(),context);
		}
		protected string processForInit(XplForinit forInit, EZOEContext context){
			string retStr="";
			if(forInit==null)return retStr;
			switch(forInit.get_Content().get_ElementName()){
				case "dl": //XplDeclaratorlist
					retStr=renderForDeclaration((XplDeclaratorlist)forInit.get_Content(),context);
					break;
				case "el": //XplExpressionlist
					retStr=processExpressionList((XplExpressionlist)forInit.get_Content(),context);
					break;
			}
			return retStr;
		}
		protected void processDo( XplDowhileStatement doSta , EZOEContext context , bool isDo ){
			string boolExpStr=processExpression(doSta.get_boolean(),context);
			if(!isDo){
				renderWhileStatement(doSta,boolExpStr,context);
				processFunctionBody(doSta.get_dobk(),context);
			}
			else{ //Es Do
				renderBeginDoStatement(doSta,boolExpStr,context);
				processFunctionBody(doSta.get_dobk(),context);
				renderEndDoStatement(doSta,boolExpStr,context);
			}
		}
		protected void processTry( XplTryStatement trySta , EZOEContext context ){
			renderBeginTry(trySta,context);
			processFunctionBody(trySta.get_trybk(),context);
			foreach(XplCatchStatement catchSta in trySta.get_catchbk()){
				processCatchStatement(catchSta, context);
			}
			if(trySta.get_finallybk()!=null){
				renderFinally(trySta.get_finallybk(),context);
				processFunctionBody(trySta.get_finallybk(),context);
			}
		}
		protected void processCatchStatement(XplCatchStatement catchSta, EZOEContext context){
			XplCatchinit cinit=catchSta.get_init();
			XplDeclarator decl=null;
			string declExp="";
			if(cinit!=null){
				switch(cinit.get_Content().get_ElementName()){
					case "d": //XplDeclarator
						decl=(XplDeclarator)cinit.get_Content();
						declExp=renderType(decl.get_type(), decl.get_name(), EZOETypeContext.CatchVarDecl, context);
						break;
					case "e": //XplExpression
						declExp=processExpression((XplExpression)cinit.get_Content(),context);
						break;
				}
			}
			renderCatchStatement(catchSta,declExp,context);
			processFunctionBody(catchSta.get_bk(),context);
		}
		protected void processThrow( XplExpression expression , EZOEContext context ){
			string expStr=processExpression(expression,context);
			renderThrow(expression, expStr, context);
		}
		protected void processReturn( XplExpression expression , EZOEContext context ){
            string expStr = expression != null ? processExpression(expression, context) : "";
			renderReturn(expression, expStr, context);
		}
		protected void processJump( XplJump jump , EZOEContext context ){
			switch(jump.get_type()){
				case XplJumptype_enum.BREAK:
					renderBreak(jump,context);
					break;
				case XplJumptype_enum.CONTINUE:
					renderContinue(jump,context);
					break;
				case XplJumptype_enum.GOTO:
					renderGoto(jump,jump.get_label(),context);
					break;
				case XplJumptype_enum.RESUME:
					renderResume(jump,context);
					break;
				case XplJumptype_enum.RESUMENEXT:
					renderResumeNext(jump,context);
					break;
			}
		}
		protected void processDirectoutput( XplDirectoutput directoutput , EZOEContext context ){
			renderDirectOutput(directoutput, directoutput.get_output(), context);
		}
		protected void processOnpointer( XplFunctionBody functionBody , EZOEContext context ){
			renderOnpointerStatement(functionBody,context);
			processFunctionBody(functionBody,context);
		}
		#endregion

		#region Expresiones
		protected string processExpressionList(XplExpressionlist list, EZOEContext context){
			string retStr="",expStr="";
			if(list==null)return retStr;
			int n=0;int max=list.Children().GetLength();
			retStr+=renderBeginExpressionList(list,max,context);
			foreach(XplExpression expNode in list.Children()){
				n++;
				expStr=processExpression(expNode,context);
				retStr+=renderExpressionListItem(expNode,expStr,n,max,context);
			}
			retStr+=renderEndExpressionList(list, context);
			return retStr;
		}
		protected string processExpression(XplExpression exp, EZOEContext context){
			if(exp==null)return "";
			string expStr="";
			XplNode expNode=exp.get_Content();
            if (expNode != null)
			switch(expNode.get_ElementName()){
				case "a":
					expStr=processAssingExp((XplAssing)expNode, EZOEContext.Expression );
					break;
				case "new":
					expStr=processNewExp((XplNewExpression)expNode, EZOEContext.Expression );
					break;
				case "bo":
					expStr=processBinOpExp((XplBinaryoperator)expNode, EZOEContext.Expression );
					break;
                case "to":
                    expStr = processTernaryOpExp((XplTernaryoperator)expNode, EZOEContext.Expression);
                    break;
                case "uo":
					expStr=processUnOpExp((XplUnaryoperator)expNode, EZOEContext.Expression );
					break;
				case "b":
					expStr=processBFCExp((XplFunctioncall)expNode, EZOEContext.Expression );
					break;
				case "n":
					expStr=renderSimpleName(expNode.get_StringValue(), EZOEContext.Expression );
					break;
				case "lit":
					expStr=renderLiteral((XplLiteral)expNode, ((XplLiteral)expNode).get_str(), EZOEContext.Expression );
					break;
				case "fc":
					expStr=processFunctionCall((XplFunctioncall)expNode, EZOEContext.Expression );
					break;
                case "cfc":
                    expStr=processComplexFunctionCall((XplComplexfunctioncall)expNode, EZOEContext.Expression);
                    break;
                case "cast":
					expStr=processCastExp((XplCastexpression)expNode, EZOEContext.Expression );
					break;
				case "delete":
					expStr=renderDeleteExp((XplExpression)expNode, processExpression((XplExpression)expNode,EZOEContext.Expression) , EZOEContext.Expression );
					break;
				case "onpointer":
					expStr=renderOnpointerExp((XplExpression)expNode, processExpression((XplExpression)expNode,EZOEContext.Expression) , EZOEContext.Expression );
					break;
                case "writecode":
                    expStr=processWritecodeExp((XplWriteCodeBody)expNode, EZOEContext.Expression);
                    break;
                case "t": //gettype(tipo)
                    expStr = processGetTypeExp((XplType)expNode, EZOEContext.Expression);
                    break;
                case "toft": //typeof(type)
                    expStr = processGetTypeOfExp((XplType)expNode, EZOEContext.Expression);
                    break;
                case "is": //exp is type
                    expStr = processIsExp((XplCastexpression)expNode, EZOEContext.Expression);
                    break;
                case "empty":
					expStr="";
					break;
				default:
					renderUnrecognizedNode( expNode , EZOEContext.Expression );
					break;
			}
			return expStr;
		}

        private string processIsExp(XplCastexpression xplExpression, EZOEContext eZOEContext)
        {
            string expStr = processExpression(xplExpression.get_e(), eZOEContext);
            string typeStr = renderType(xplExpression.get_type(), "", EZOETypeContext.Expression, eZOEContext);
            return renderIsExp(xplExpression, expStr, typeStr, eZOEContext);
        }

        private string processGetTypeOfExp(XplType xplExpression, EZOEContext eZOEContext)
        {
            string typeStr = renderType(xplExpression, "", EZOETypeContext.Expression, eZOEContext);
            return renderTypeOfExp(xplExpression, typeStr, eZOEContext);
        }

        private string processGetTypeExp(XplType xplType, EZOEContext eZOEContext)
        {
            string typeStr = renderType(xplType, "", EZOETypeContext.GettypeExp, eZOEContext);
            return renderGetTypeExp(xplType, typeStr, eZOEContext);
        }

        private string processWritecodeExp(XplWriteCodeBody xplWriteCodeBody, EZOEContext eZOEContext)
        {
            XplNode content = xplWriteCodeBody.get_Content();
            string retStr = String.Empty;
            switch (content.get_ElementName())
            {
                case "bk":
                    retStr = renderWritecodeBlock(xplWriteCodeBody, eZOEContext);
                    break;
                case "progunit":
                    retStr = renderWritecodeBlock(xplWriteCodeBody, eZOEContext);
                    break;
                case "namespace":
                    retStr = renderWritecodeBlock(xplWriteCodeBody, eZOEContext);
                    break;
                case "classmembers":
                    retStr = renderWritecodeBlock(xplWriteCodeBody, eZOEContext);
                    break;
                case "class":
                    retStr = renderWritecodeBlock(xplWriteCodeBody, eZOEContext);
                    break;
                case "e":
                    retStr = renderWritecodeExpression((XplExpression)content, processExpression((XplExpression)content,eZOEContext), eZOEContext);
                    break;
            }
            return retStr;
        }

        protected abstract string renderWritecodeBlock(XplWriteCodeBody xplWriteCodeBody, EZOEContext eZOEContext);
        protected abstract string renderWritecodeExpression(XplExpression xplExpression, string expStr, EZOEContext context);
        protected abstract string renderGetTypeExp(XplType xplType, string typeStr, EZOEContext eZOEContext);
        protected abstract string renderTypeOfExp(XplType typeofExpNode, string typeStr, EZOEContext eZOEContext);
        protected abstract string renderIsExp(XplCastexpression xplExpression, string expStr, string typeStr, EZOEContext eZOEContext);

        protected string processComplexFunctionCall(XplComplexfunctioncall xplFunctioncall, EZOEContext context)
        {
            throw new Exception("The method or operation is not implemented.");
        }

		protected string processAssingExp(XplAssing assing, EZOEContext context){
			string leftExpStr=processExpression(assing.get_l(),context);
			string rightExpStr=processExpression(assing.get_r(),context);
			return renderAssingExp(assing,leftExpStr,rightExpStr,assing.get_operation(),context);
		}
		protected string processNewExp(XplNewExpression newExp, EZOEContext context){
            string typeStr = renderType(newExp.get_type(), "", EZOETypeContext.Expression, context);
            string initializerStr = processInitializer(newExp.get_init(), context);
			return renderNewExp(newExp,typeStr,initializerStr,context);
		}
		protected string processBinOpExp(XplBinaryoperator bopExp, EZOEContext context){
			string leftExpStr=processExpression(bopExp.get_l(),context);
			string rightExpStr=processExpression(bopExp.get_r(),context);
			return renderBinOpExp(bopExp,leftExpStr,rightExpStr,bopExp.get_op(),context);
		}
        protected string processTernaryOpExp(XplTernaryoperator topExp, EZOEContext context)
        {
            string o1ExpStr = processExpression(topExp.get_o1(), context);
            string o2ExpStr = processExpression(topExp.get_o2(), context);
            string o3ExpStr = processExpression(topExp.get_o3(), context);
            return renderTernaryOpExp(topExp, o1ExpStr, o2ExpStr, o3ExpStr, topExp.get_op(), context);
        }
        protected string processUnOpExp(XplUnaryoperator uopExp, EZOEContext context)
        {
			string expStr=processExpression(uopExp.get_u(),context);
			return renderUnOpExp(uopExp,expStr,uopExp.get_op(),context);
		}
		protected string processBFCExp(XplFunctioncall fcallExp, EZOEContext context){
			string leftExpStr=processExpression(fcallExp.get_l(),context);
			string argsStr=processExpressionList(fcallExp.get_args(),context);
			return renderFunctionCallExp(fcallExp,leftExpStr,argsStr,true,context);
		}
		protected string processFunctionCall(XplFunctioncall fcallExp, EZOEContext context){
			string leftExpStr=processExpression(fcallExp.get_l(),context);
			string argsStr=processExpressionList(fcallExp.get_args(),context);
			return renderFunctionCallExp(fcallExp,leftExpStr,argsStr,false,context);
		}
		protected string processCastExp(XplCastexpression castExp, EZOEContext context){
			string typeStr=renderType(castExp.get_type(),"",EZOETypeContext.CastExp,context);
			string castExpStr=processExpression(castExp.get_e(),context);
			return renderCastExp(castExp,typeStr,castExpStr,castExp.get_castType(),context);
		}
		#endregion

		#endregion

		#region Miembros Virtuales para Sobreescribir

		#region Documento
		protected abstract void processDocumentData(XplDocumentData documentData);
		//Inicio y Fin de Documento
        protected abstract void renderBeginDocumentBody(XplDocumentBody documentBody);
        protected abstract void renderEndDocumentBody(XplDocumentBody documentBody);
		#endregion

		#region Declaraciones
		//Import y Espacios de Nombres
		protected abstract void renderImportDirective(XplName importDirective);
		protected abstract void renderBeginNamespace(string namespaceName, XplNamespace namespaceDecl, EZOEContext context);
		protected abstract void renderEndNamespace(string namespaceName, XplNamespace namespaceDecl, EZOEContext context);
		//Tipos Definidos por el usuario
		protected abstract void renderBeginClass(EZOEClassType classType, string className, string implementsStr, string inheritsStr, 
			XplAccesstype_enum classAccess,	bool isNew, bool isAbstract, bool isFinal, XplClass classDecl, EZOEContext context);
		protected abstract void renderEndClass(EZOEClassType classType, string className, XplClass classDecl, EZOEContext context);
		protected abstract string renderImplements(XplClass classDecl, XplNodeList implements, EZOEContext context);
		protected abstract string renderInherits(XplClass classDecl, XplNodeList inherits, EZOEContext context);
		//Miembros de Tipos Definidos por el Usuario
		protected abstract void renderBeginFunction(XplFunction functionDecl, string functionName, string returnTypeStr, string parametersStr, 
			XplAccesstype_enum access, XplVarstorage_enum functionStorage,	bool isAbstract, bool isFinal, bool isFp, bool isNew, bool isConst,  
			bool isOverride, bool isVirtual, EZOEContext context);
		protected abstract void renderEndFunction(XplFunction functionDecl, string functionName, EZOEContext context);
		protected abstract void renderBeginProperty(XplProperty propertyDecl, string propertyName, string typeStr,  
			XplAccesstype_enum access, XplVarstorage_enum propertyStorage,	bool isAbstract, bool isFinal, bool isNew, bool isConst,  
			bool isOverride, bool isVirtual, EZOEContext context);
		protected abstract void renderEndProperty(XplProperty propertyDecl, string propertyName, EZOEContext context);
		protected abstract void renderBeginGetAccess(EZOEContext context, XplFunctionBody body);
		protected abstract void renderEndGetAccess(EZOEContext context, XplFunctionBody body);
		protected abstract void renderBeginSetAccess(EZOEContext context, XplFunctionBody body);
		protected abstract void renderEndSetAccess(EZOEContext context, XplFunctionBody body);
		protected abstract void renderField(XplField fieldDecl, string fieldName, string typeStr, string initializerStr, 
			XplAccesstype_enum access, XplVarstorage_enum fieldStorage, bool isNew, bool isVolatile);
		protected abstract void renderBeginParameters(XplParameters parametersDecl,int maxParameter, XplFunction functionDecl, EZOEContext context);
		protected abstract string renderParameter(XplParameter parameter, string parameterName, string typeStr, 
			string initializerStr, XplParameterdirection_enum parameterDirection, int parameterNumber, 
			bool isParams, bool isVolatile);
		protected abstract void renderEndParameters(XplParameters parametersDecl, EZOEContext context);
		protected abstract string renderType(XplType type, string declareName, EZOETypeContext typeContext, EZOEContext context);
        protected abstract string renderBeginInitializerList(XplInitializerList initializerList, EZOEContext context);
        protected abstract string renderEndInitializerList(XplInitializerList initializerList, EZOEContext context);
        protected abstract string renderSimpleInitializer(XplExpression expression, string expressionStr, EZOEContext context);
        protected abstract string renderInitilizerItem(XplNode node, string nodeStr, int maxNodes, int count, EZOEContext context);
        protected abstract string renderEndArrayInitializer(XplInitializerList initializerList, EZOEContext context);
        protected abstract string renderBeginArrayInitializer(XplInitializerList initializerList, EZOEContext context);
        #endregion

		#region Instrucciones
		protected abstract void renderBeginBlock( XplFunctionBody functionBody, EZOEContext context );
		protected abstract void renderLabel( XplNode label, EZOEContext context );
		protected abstract void renderSetonerror( XplSetonerror setOnerror , EZOEContext context );
		protected abstract void renderEndBlock( XplFunctionBody functionBody, EZOEContext context );
		protected abstract void renderExpressionStatement(XplExpression expression, string expressionString, EZOEContext context );
		protected abstract void renderThrow(XplExpression throwExpression, string expressionString, EZOEContext context );
		protected abstract void renderReturn(XplExpression returnExpression, string expressionString, EZOEContext context );
		protected abstract void renderLocalDeclarator(XplDeclarator decl, string varName, string typeStr, string initializerStr, bool isVolatile);
		protected abstract void renderBeginSwitch(XplSwitchStatement switchSta, string boolExpStr, EZOEContext context);
		protected abstract void renderCaseLabel(XplCase caseNode, string caseExpStr, EZOEContext context);
		protected abstract void renderEndSwitch(XplSwitchStatement switchSta, EZOEContext context);
		protected abstract void renderIfStatement(XplIfStatement ifSta, string boolExp, bool isElse, EZOEContext context);
		protected abstract void renderElseStatement(XplIfStatement ifSta, XplFunctionBody elseBody, EZOEContext context);
		protected abstract void renderForStatement(XplForStatement forSta, string initStr, string boolExpStr, string updateStr, EZOEContext context);
		protected abstract string renderForDeclaration(XplDeclaratorlist decls, EZOEContext context);
		protected abstract void renderWhileStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context);
		protected abstract void renderBeginDoStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context);
		protected abstract void renderEndDoStatement(XplDowhileStatement doSta, string boolExpStr, EZOEContext context);
		protected abstract void renderBeginTry(XplTryStatement trySta, EZOEContext context);
		protected abstract void renderEndTry(XplTryStatement trySta, EZOEContext context);
		protected abstract void renderCatchStatement(XplCatchStatement catchSta, string declExp, EZOEContext context);
		protected abstract void renderFinally(XplFunctionBody tryBk, EZOEContext context);
		protected abstract void renderBreak(XplJump jump, EZOEContext context);
		protected abstract void renderContinue(XplJump jump, EZOEContext context);
		protected abstract void renderGoto(XplJump jump, string label, EZOEContext context);
		protected abstract void renderResume(XplJump jump, EZOEContext context);
		protected abstract void renderResumeNext(XplJump jump, EZOEContext context);
		protected abstract void renderDirectOutput(XplDirectoutput directOutput, string outputStr, EZOEContext context);
		protected abstract void renderOnpointerStatement(XplFunctionBody functionBody, EZOEContext context);
		#endregion

		#region Expresiones
		protected abstract string renderBeginExpressionList(XplExpressionlist list, int expCount, EZOEContext context);
		protected abstract string renderExpressionListItem(XplExpression expNode, string expStr, int expNumber, int expCount, EZOEContext context);
		protected abstract string renderEndExpressionList(XplExpressionlist list, EZOEContext context);
		protected abstract string renderSimpleName(string name, EZOEContext context);
		protected abstract string renderLiteral(XplLiteral litNode, string litStr, EZOEContext context);
		protected abstract string renderDeleteExp(XplExpression deleteExp, string expStr, EZOEContext context);
		protected abstract string renderOnpointerExp(XplExpression onpointerExp, string expStr, EZOEContext context);
		protected abstract string renderAssingExp(XplAssing assing, string leftExpStr, string rightExpStr, XplAssingop_enum operation, EZOEContext context);
		protected abstract string renderBinOpExp(XplBinaryoperator bopExp, string leftExpStr, string rightExpStr, XplBinaryoperators_enum op, EZOEContext context);
        protected abstract string renderTernaryOpExp(XplTernaryoperator bopExp, string o1ExpStr, string o2ExpStr, string o3ExpStr, XplTernaryoperators_enum op, EZOEContext context);
        protected abstract string renderUnOpExp(XplUnaryoperator uopExp, string expStr, XplUnaryoperators_enum op, EZOEContext context);
		protected abstract string renderFunctionCallExp(XplFunctioncall fcallExp, string leftExpStr, string argsStr, bool useBrackets, EZOEContext context);
		protected abstract string renderCastExp(XplCastexpression castExp, string typeStr, string castExpStr, XplCasttype_enum castType, EZOEContext context);
        protected abstract string renderNewExp(XplNewExpression newExp, string typeStr, string initializerStr, EZOEContext context);
        #endregion

		#region Otros
		//Otros
		protected abstract void renderDocumentation(XplDocumentation documentation, EZOEContext context);
		protected abstract void renderUnrecognizedNode(XplNode node, EZOEContext context);
		#endregion

		#endregion

		#region Propiedades
		string InputFileName{
			get{return p_inputFileName;}
			set{p_inputFileName=value;}
		}
		#endregion
	}
}
