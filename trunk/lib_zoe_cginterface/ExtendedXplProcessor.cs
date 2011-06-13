using System;
using System.Xml;
using LayerD.CodeDOM;

namespace LayerD.OutputModules
{
	/// <summary>
	/// ExtendedXplProcessor.
	/// 
	/// Procesa archivos XML de código LayerD-XPL Extendido y genera eventos 
	/// para renderizar cada elemento. Es una clase abstracta que debe ser
	/// heredada por un generador en particular, por ejemplo un generador
	/// para C#.
	/// </summary>
	public abstract class ExtendedXplProcessor 
	{
		#region Tipos Anidados Publicos
		public enum EXPLClassType{
			Class,
			Struct,
			Interface,
            Enum,
			Union
		}
		public enum EXPLContext{
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
			CaseLabel
		}
		public enum EXPLTypeContext{
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
		protected string p_lastError="";
		protected XplXPLDocument p_XplDocument=null;
		protected XplReader p_reader=null;
		#endregion

		#region Constructores
		public ExtendedXplProcessor(){
		}
		public ExtendedXplProcessor(string new_inputFileName){
			p_inputFileName=new_inputFileName;
		}
		#endregion

		#region Parse
		protected bool ParseDocument(){
			p_reader=null;
			if(p_inputFileName=="")throw new Exception("Primero establezca el archivo a compilar.");
            //try
            //{
                p_reader = new XplReader(p_inputFileName);
                p_reader.WhitespaceHandling = WhitespaceHandling.None;
                p_XplDocument = new XplXPLDocument();
                p_reader.Read();
                if (p_XplDocument.Read(p_reader) != null)
                {
                    //Proceso primero la configuracion del documento
                    processDocumentData(p_XplDocument.get_DocumentData());
                    processDocumentBody(p_XplDocument.get_DocumentBody());
                    return true;
                }
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
			//finally{
				if(p_reader!=null)p_reader.Close();
			//}
			return false;
		}
		#endregion

		#region Funciones de Procesamiento de cada tipo elemento

		#region Documento
		protected void processDocumentBody(XplDocumentBody documentBody){
            renderBeginDocumentBody(documentBody);
			XplNamespace p_namespace;
			foreach(XplNode node in documentBody.Childs()){
				switch(node.get_Name()){
					case "Import":
						renderImportDirective((XplName)node);
						break;
					case "Namespace":
						p_namespace=(XplNamespace)node;
						renderBeginNamespace( p_namespace.get_name() , p_namespace, EXPLContext.DocumentBody );
						processNamespace( p_namespace );
						renderEndNamespace( p_namespace.get_name() , p_namespace, EXPLContext.DocumentBody );
						break;
					default:
						renderUnrecognizedNode( node , EXPLContext.DocumentBody );
						break;
				}
			}
            renderEndDocumentBody(documentBody);
		}
		#endregion

		#region Declaraciones
		protected void processNamespace(XplNamespace namespaceDecl){
			XplNamespace p_namespace=null;
			foreach(XplNode node in namespaceDecl.Childs()){
				switch(node.get_Name()){
					case "Class":
						processClass( (XplClass)node, EXPLContext.NamespaceBody );
						break;
					case "Namespace":
						p_namespace=(XplNamespace)node;
						renderBeginNamespace( p_namespace.get_name() , p_namespace, EXPLContext.NamespaceBody );
						processNamespace( p_namespace );
						renderEndNamespace( p_namespace.get_name() , p_namespace, EXPLContext.NamespaceBody );
						break;
					default:
						renderUnrecognizedNode( node , EXPLContext.NamespaceBody );
						break;
				}
			}
		}
		protected void processClass(XplClass classDecl, EXPLContext context){
			XplClassMembers members=null;
			XplAccesstype_enum membersAccess=XplAccesstype_enum.PRIVATE;
			//Preparo varaibles temporales
			string implementsStr=renderImplements(classDecl,classDecl.get_ImplementsNodeList(), context);
			string inheritsStr=renderInherits(classDecl,classDecl.get_InheritsNodeList(), context);
			EXPLClassType classType=EXPLClassType.Class;
            if (classDecl.get_isinterface()) classType = EXPLClassType.Interface;
            else if (classDecl.get_isstruct()) classType = EXPLClassType.Struct;
            else if (classDecl.get_isunion()) classType = EXPLClassType.Union;
            else if (classDecl.get_isenum()) classType = EXPLClassType.Enum;
			//Renderizo
			renderBeginClass(classType, classDecl.get_name(),implementsStr,inheritsStr,
				classDecl.get_access(),classDecl.get_new(),classDecl.get_abstract(),
				classDecl.get_final(),classDecl,context);
			
			foreach(XplNode node in classDecl.Childs()){
				switch(node.get_Name()){
					case "Inherits":
					case "Implements":
						///Ignoro estos nodos que ya procese durante "renderBeginClass".
						break;
					case "Class":
						processClass( (XplClass)node, EXPLContext.ClassBody );
						break;
					case "Members":
						members=(XplClassMembers)node;
						membersAccess=members.get_access();
						foreach(XplNode member in members.Childs()){
							switch(member.get_Name()){
								case "Function":
								case "Operator":
								case "Indexer":
									processFunction( (XplFunction)member , membersAccess , EXPLContext.ClassBody );
									break;
								case "Property":
									processProperty( (XplProperty)member , membersAccess , EXPLContext.ClassBody );
									break;
								case "Field":
									processField( (XplField)member , membersAccess , EXPLContext.ClassBody );
									break;
								default:
									renderUnrecognizedNode( member , EXPLContext.ClassBody );
									break;
							}
						}
						break;
					case "documentation":
						renderDocumentation( (XplDocumentation)node, EXPLContext.ClassBody );
						break;
					default:
						renderUnrecognizedNode( node , EXPLContext.ClassBody );
						break;
				}
			}
			renderEndClass(classType, classDecl.get_name(),classDecl,context);
		}
		protected void processFunction(XplFunction functionDecl, XplAccesstype_enum access , EXPLContext context){
			//variables temporales
			string returnTypeStr=renderType(functionDecl.get_ReturnType(), "", EXPLTypeContext.ReturnTypeDecl, context);
			string parametersStr=processParameters(functionDecl.get_Parameters(), functionDecl, context);
			//Renderizo
			renderBeginFunction(functionDecl, functionDecl.get_name(), returnTypeStr, parametersStr, access,
				functionDecl.get_storage(),	functionDecl.get_abstract(), functionDecl.get_final(), 
				functionDecl.get_fp(), functionDecl.get_new(), functionDecl.get_isconst(), 
				functionDecl.get_override(), functionDecl.get_virtual(), context);
			
			processFunctionBody( functionDecl.get_FunctionBody(), context );
			
			renderEndFunction(functionDecl, functionDecl.get_name(), context);
		}
		protected void processProperty(XplProperty propertyDecl, XplAccesstype_enum access , EXPLContext context){
			//variables temporales
			string typeStr=renderType(propertyDecl.get_Type(), propertyDecl.get_name(), EXPLTypeContext.PropertyDecl, context);
			//Renderizo
			renderBeginProperty(propertyDecl, propertyDecl.get_name(), typeStr, access, propertyDecl.get_storage(),	
				propertyDecl.get_abstract(), propertyDecl.get_final(), propertyDecl.get_new(), 
				propertyDecl.get_isconst(), propertyDecl.get_override(), propertyDecl.get_virtual(), context);
			
			if(propertyDecl.get_Body()!=null)
			foreach(XplNode node in propertyDecl.get_Body().Childs()){
				if(node.get_Name()=="Get"){
					renderBeginGetAccess( EXPLContext.PropertyBody, (XplFunctionBody)node);
					processFunctionBody( (XplFunctionBody)node, EXPLContext.PropertyBody );
					renderEndGetAccess( EXPLContext.PropertyBody, (XplFunctionBody)node);
				}
				else if(node.get_Name()=="Set"){
					renderBeginSetAccess( EXPLContext.PropertyBody, (XplFunctionBody)node);
					processFunctionBody( (XplFunctionBody)node, EXPLContext.PropertyBody );
					renderEndSetAccess( EXPLContext.PropertyBody, (XplFunctionBody)node);
				}
				else if(node.get_Name()=="documentation"){
					renderDocumentation( (XplDocumentation)node, EXPLContext.PropertyBody );
				}
				else{
					renderUnrecognizedNode( node , EXPLContext.PropertyBody );
				}
			}

			renderEndProperty(propertyDecl, propertyDecl.get_name(), context);
		}

		protected void processField(XplField fieldDecl, XplAccesstype_enum access , EXPLContext context){
			string typeStr=renderType(fieldDecl.get_type(), fieldDecl.get_name(), EXPLTypeContext.FieldDecl, context);
			string initializerStr=processInitializer(fieldDecl.get_i(), context);
			renderField(fieldDecl, fieldDecl.get_name(),typeStr, initializerStr, access,
				fieldDecl.get_storage(), fieldDecl.get_new(), fieldDecl.get_volatile())	;
		}
		protected string processParameters(XplParameters parametersDecl, XplFunction functionDecl, EXPLContext context){
			if(parametersDecl==null)return "";
			string returnStr="";
			renderBeginParameters(parametersDecl, parametersDecl.Childs().getLenght(), functionDecl, context);
			foreach(XplNode node in parametersDecl.Childs()){
				switch(node.get_Name()){
					case "P":
						returnStr+=processParameter( (XplParameter)node, EXPLContext.ClassBody );
						break;
					default:
						renderUnrecognizedNode( node , EXPLContext.FunctionDecl );
						break;
				}
			}
			renderEndParameters(parametersDecl,context);
			return returnStr;
		}

		protected string processParameter(XplParameter parameter, EXPLContext context){
			if(parameter==null)return "";
			string typeStr=renderType(parameter.get_type(), parameter.get_name(), EXPLTypeContext.ParameterDecl, context);
			string initializerStr=processInitializer(parameter.get_i(), EXPLContext.FunctionDecl);
			return renderParameter(parameter, parameter.get_name(), typeStr, initializerStr, parameter.get_direction(), 
				(int)parameter.get_number(), parameter.get_params(), parameter.get_volatile());
		}
		#endregion

		#region Instrucciones
		protected void processFunctionBody(XplFunctionBody functionBody, EXPLContext context){
			if(functionBody==null)return;
			renderBeginBlock(functionBody,context);
			foreach(XplNode node in functionBody.Childs()){
				switch(node.get_Name()){
					case "label":
						renderLabel( (XplNode)node, EXPLContext.FunctionBody );
						break;
					case "setonerror":
						renderSetonerror( (XplSetonerror)node, EXPLContext.FunctionBody );
						break;
					case "Decls":
						processDecls( (XplDeclaratorlist)node, EXPLContext.FunctionBody );
						break;
					case "e":
						processExpressionStatement( (XplExpression)node, EXPLContext.FunctionBody );
						break;
					case "switch":
						processSwitch( (XplSwitchStatement)node, EXPLContext.FunctionBody );
						break;
					case "if":
						processIf( (XplIfStatement)node, EXPLContext.FunctionBody, false );
						break;
					case "for":
						processFor( (XplForStatement)node, EXPLContext.FunctionBody );
						break;
					case "do":
						processDo( (XplDowhileStatement)node, EXPLContext.FunctionBody, true );
						break;
					case "while":
						processDo( (XplDowhileStatement)node, EXPLContext.FunctionBody, false );
						break;
					case "bk":
						processFunctionBody( (XplFunctionBody)node, EXPLContext.FunctionBody );
						break;
					case "onpointer":
						processOnpointer( (XplFunctionBody)node, EXPLContext.FunctionBody );
						break;
					case "try":
						processTry( (XplTryStatement)node, EXPLContext.FunctionBody );
						break;
					case "throw":
						processThrow( (XplExpression)node, EXPLContext.FunctionBody );
						break;
					case "return":
						processReturn( (XplExpression)node, EXPLContext.FunctionBody );
						break;
					case "jump":
						processJump( (XplJump)node, EXPLContext.FunctionBody );
						break;
					case "directoutput":
						processDirectoutput( (XplDirectoutput)node, EXPLContext.FunctionBody );
						break;
					case "documentation":
						renderDocumentation( (XplDocumentation)node, EXPLContext.FunctionBody );
						break;
					default:
						renderUnrecognizedNode( node , EXPLContext.FunctionBody );
						break;
				}
			}
			renderEndBlock(functionBody,context);
		}
		protected void processDecls( XplDeclaratorlist decls , EXPLContext context ){
			foreach(XplDeclarator decl in decls.Childs()){
				processLocalDeclarator( decl , EXPLTypeContext.LocalVarDecl, context );
			}
		}
		protected void processLocalDeclarator( XplDeclarator decl, EXPLTypeContext typeContext, EXPLContext context ){
			string typeStr=renderType(decl.get_type(), decl.get_name(), typeContext, context);
			string initializerStr=processInitializer(decl.get_i(), context);
			renderLocalDeclarator(decl, decl.get_name(),typeStr, initializerStr, decl.get_volatile())	;
		}
        protected string processInitializer(XplInitializerList initializerList, EXPLContext context)
        {
            if (initializerList == null) return "";
            string retStr = "";
            int maxNodes=0,count=0;
            if (initializerList.get_array())
            {   //Inicializador de arrays
                retStr+=renderBeginArrayInitializer(initializerList, context);
                maxNodes=initializerList.Childs().getLenght();
                foreach (XplNode node in initializerList.Childs())
                {
                    count++;
                    switch (node.get_Name())
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
                XplNode node = initializerList.Childs().FirstNode();
                if (node.get_Name() == "e")
                {   //Inicializador de expresion simple
                    XplExpression exp=(XplExpression)node;
                    retStr += renderSimpleInitializer(exp, processExpression(exp, context), context);
                }
                else
                {
                    XplInitializerList list = (XplInitializerList)node;
                    retStr += renderBeginInitializerList(initializerList, context);
                    maxNodes = list.Childs().getLenght();
                    count = 0;
                    foreach (XplNode node2 in list.Childs())
                    {
                        count++;
                        switch (node2.get_Name())
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
		protected void processExpressionStatement( XplExpression expression , EXPLContext context ){
			string expStr=processExpression(expression,context);
			renderExpressionStatement(expression, expStr, context);
		}
		protected void processSwitch( XplSwitchStatement switchSta , EXPLContext context ){
			string boolExpStr=processExpression(switchSta.get_e(),context);
			renderBeginSwitch(switchSta, boolExpStr, context);
			foreach(XplCase caseNode in switchSta.get_case()){
				renderCaseLabel(caseNode, processExpression(caseNode.get_e(),context),context);
				processFunctionBody(caseNode.get_bk(),EXPLContext.CaseLabel);
			}
			renderEndSwitch(switchSta, context);
		}
		protected void processIf( XplIfStatement ifSta , EXPLContext context, bool isElse ){
			string boolExp=processExpression(ifSta.get_boolean(),context);
			renderIfStatement(ifSta, boolExp, isElse,context);
			processFunctionBody(ifSta.get_ifbk(), context);
			foreach(XplIfStatement elseSta in ifSta.get_elseif()){
				processIf(elseSta, context, true);
			}
			renderElseStatement(ifSta, ifSta.get_else(),context);
			processFunctionBody(ifSta.get_else(),context);
		}
		protected void processFor( XplForStatement forSta , EXPLContext context ){
			string initStr=processForInit(forSta.get_init(),context);
			string boolExpStr=processExpression(forSta.get_condition(),context);
			string updateStr=processExpressionList(forSta.get_repeat(),context);
			renderForStatement(forSta, initStr, boolExpStr, updateStr, context);
			processFunctionBody(forSta.get_forblock(),context);
		}
		protected string processForInit(XplForinit forInit, EXPLContext context){
			string retStr="";
			if(forInit==null)return retStr;
			switch(forInit.get_tforinit().get_Name()){
				case "dl": //XplDeclaratorlist
					retStr=renderForDeclaration((XplDeclaratorlist)forInit.get_tforinit(),context);
					break;
				case "el": //XplExpressionlist
					retStr=processExpressionList((XplExpressionlist)forInit.get_tforinit(),context);
					break;
			}
			return retStr;
		}
		protected void processDo( XplDowhileStatement doSta , EXPLContext context , bool isDo ){
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
		protected void processTry( XplTryStatement trySta , EXPLContext context ){
			renderBeginTry(trySta,context);
			processFunctionBody(trySta.get_trybk(),context);
			foreach(XplCatchStatement catchSta in trySta.get_catchbk()){
				processCatchStatement(catchSta, context);
			}
			if(trySta.get_finalybk()!=null){
				renderFinally(trySta.get_finalybk(),context);
				processFunctionBody(trySta.get_finalybk(),context);
			}
		}
		protected void processCatchStatement(XplCatchStatement catchSta, EXPLContext context){
			XplCatchinit cinit=catchSta.get_init();
			XplDeclarator decl=null;
			string declExp="";
			if(cinit!=null){
				switch(cinit.get_tcatchinit().get_Name()){
					case "d": //XplDeclarator
						decl=(XplDeclarator)cinit.get_tcatchinit();
						declExp=renderType(decl.get_type(), decl.get_name(), EXPLTypeContext.CatchVarDecl, context);
						break;
					case "e": //XplExpression
						declExp=processExpression((XplExpression)cinit.get_tcatchinit(),context);
						break;
				}
			}
			renderCatchStatement(catchSta,declExp,context);
			processFunctionBody(catchSta.get_bk(),context);
		}
		protected void processThrow( XplExpression expression , EXPLContext context ){
			string expStr=processExpression(expression,context);
			renderThrow(expression, expStr, context);
		}
		protected void processReturn( XplExpression expression , EXPLContext context ){
            string expStr = expression != null ? processExpression(expression, context) : "";
			renderReturn(expression, expStr, context);
		}
		protected void processJump( XplJump jump , EXPLContext context ){
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
		protected void processDirectoutput( XplDirectoutput directoutput , EXPLContext context ){
			renderDirectOutput(directoutput, directoutput.get_output(), context);
		}
		protected void processOnpointer( XplFunctionBody functionBody , EXPLContext context ){
			renderOnpointerStatement(functionBody,context);
			processFunctionBody(functionBody,context);
		}
		#endregion

		#region Expresiones
		protected string processExpressionList(XplExpressionlist list, EXPLContext context){
			string retStr="",expStr="";
			if(list==null)return retStr;
			int n=0;int max=list.Childs().getLenght();
			retStr+=renderBeginExpressionList(list,max,context);
			foreach(XplExpression expNode in list.Childs()){
				n++;
				expStr=processExpression(expNode,context);
				retStr+=renderExpressionListItem(expNode,expStr,n,max,context);
			}
			retStr+=renderEndExpressionList(list, context);
			return retStr;
		}
		protected string processExpression(XplExpression exp, EXPLContext context){
			if(exp==null)return "";
			string expStr="";
			XplNode expNode=exp.get_texpression();
			switch(expNode.get_Name()){
				case "a":
					expStr=processAssingExp((XplAssing)expNode, EXPLContext.Expression );
					break;
				case "new":
					expStr=processNewExp((XplNewExpression)expNode, EXPLContext.Expression );
					break;
				case "bo":
					expStr=processBinOpExp((XplBinaryoperator)expNode, EXPLContext.Expression );
					break;
				case "uo":
					expStr=processUnOpExp((XplUnaryoperator)expNode, EXPLContext.Expression );
					break;
				case "b":
					expStr=processBFCExp((XplFunctioncall)expNode, EXPLContext.Expression );
					break;
				case "n":
					expStr=renderSimpleName(expNode.get_stringValue(), EXPLContext.Expression );
					break;
				case "lit":
					expStr=renderLiteral((XplLiteral)expNode, ((XplLiteral)expNode).get_str(), EXPLContext.Expression );
					break;
				case "fc":
					expStr=processFunctionCall((XplFunctioncall)expNode, EXPLContext.Expression );
					break;
				case "cast":
					expStr=processCastExp((XplCastexpression)expNode, EXPLContext.Expression );
					break;
				case "delete":
					expStr=renderDeleteExp((XplExpression)expNode, processExpression((XplExpression)expNode,EXPLContext.Expression) , EXPLContext.Expression );
					break;
				case "onpointer":
					expStr=renderOnpointerExp((XplExpression)expNode, processExpression((XplExpression)expNode,EXPLContext.Expression) , EXPLContext.Expression );
					break;
				case "empty":
					expStr="";
					break;
				default:
					renderUnrecognizedNode( expNode , EXPLContext.Expression );
					break;
			}
			return expStr;
		}
		protected string processAssingExp(XplAssing assing, EXPLContext context){
			string leftExpStr=processExpression(assing.get_l(),context);
			string rightExpStr=processExpression(assing.get_r(),context);
			return renderAssingExp(assing,leftExpStr,rightExpStr,assing.get_operation(),context);
		}
		protected string processNewExp(XplNewExpression newExp, EXPLContext context){
            string typeStr = renderType(newExp.get_type(), "", EXPLTypeContext.Expression, context);
            string initializerStr = processInitializer(newExp.get_init(), context);
			return renderNewExp(newExp,typeStr,initializerStr,context);
		}
		protected string processBinOpExp(XplBinaryoperator bopExp, EXPLContext context){
			string leftExpStr=processExpression(bopExp.get_l(),context);
			string rightExpStr=processExpression(bopExp.get_r(),context);
			return renderBinOpExp(bopExp,leftExpStr,rightExpStr,bopExp.get_op(),context);
		}
		protected string processUnOpExp(XplUnaryoperator uopExp, EXPLContext context){
			string expStr=processExpression(uopExp.get_u(),context);
			return renderUnOpExp(uopExp,expStr,uopExp.get_op(),context);
		}
		protected string processBFCExp(XplFunctioncall fcallExp, EXPLContext context){
			string leftExpStr=processExpression(fcallExp.get_l(),context);
			string argsStr=processExpressionList(fcallExp.get_params(),context);
			return renderFunctionCallExp(fcallExp,leftExpStr,argsStr,true,context);
		}
		protected string processFunctionCall(XplFunctioncall fcallExp, EXPLContext context){
			string leftExpStr=processExpression(fcallExp.get_l(),context);
			string argsStr=processExpressionList(fcallExp.get_params(),context);
			return renderFunctionCallExp(fcallExp,leftExpStr,argsStr,false,context);
		}
		protected string processCastExp(XplCastexpression castExp, EXPLContext context){
			string typeStr=renderType(castExp.get_type(),"",EXPLTypeContext.CastExp,context);
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
		protected abstract void renderBeginNamespace(string namespaceName, XplNamespace namespaceDecl, EXPLContext context);
		protected abstract void renderEndNamespace(string namespaceName, XplNamespace namespaceDecl, EXPLContext context);
		//Tipos Definidos por el usuario
		protected abstract void renderBeginClass(EXPLClassType classType, string className, string implementsStr, string inheritsStr, 
			XplAccesstype_enum classAccess,	bool isNew, bool isAbstract, bool isFinal, XplClass classDecl, EXPLContext context);
		protected abstract void renderEndClass(EXPLClassType classType, string className, XplClass classDecl, EXPLContext context);
		protected abstract string renderImplements(XplClass classDecl, XplNodeList implements, EXPLContext context);
		protected abstract string renderInherits(XplClass classDecl, XplNodeList inherits, EXPLContext context);
		//Miembros de Tipos Definidos por el Usuario
		protected abstract void renderBeginFunction(XplFunction functionDecl, string functionName, string returnTypeStr, string parametersStr, 
			XplAccesstype_enum access, XplVarstorage_enum functionStorage,	bool isAbstract, bool isFinal, bool isFp, bool isNew, bool isConst,  
			bool isOverride, bool isVirtual, EXPLContext context);
		protected abstract void renderEndFunction(XplFunction functionDecl, string functionName, EXPLContext context);
		protected abstract void renderBeginProperty(XplProperty propertyDecl, string propertyName, string typeStr,  
			XplAccesstype_enum access, XplVarstorage_enum propertyStorage,	bool isAbstract, bool isFinal, bool isNew, bool isConst,  
			bool isOverride, bool isVirtual, EXPLContext context);
		protected abstract void renderEndProperty(XplProperty propertyDecl, string propertyName, EXPLContext context);
		protected abstract void renderBeginGetAccess(EXPLContext context, XplFunctionBody body);
		protected abstract void renderEndGetAccess(EXPLContext context, XplFunctionBody body);
		protected abstract void renderBeginSetAccess(EXPLContext context, XplFunctionBody body);
		protected abstract void renderEndSetAccess(EXPLContext context, XplFunctionBody body);
		protected abstract void renderField(XplField fieldDecl, string fieldName, string typeStr, string initializerStr, 
			XplAccesstype_enum access, XplVarstorage_enum fieldStorage, bool isNew, bool isVolatile);
		protected abstract void renderBeginParameters(XplParameters parametersDecl,int maxParameter, XplFunction functionDecl, EXPLContext context);
		protected abstract string renderParameter(XplParameter parameter, string parameterName, string typeStr, 
			string initializerStr, XplParameterdirection_enum parameterDirection, int parameterNumber, 
			bool isParams, bool isVolatile);
		protected abstract void renderEndParameters(XplParameters parametersDecl, EXPLContext context);
		protected abstract string renderType(XplType type, string declareName, EXPLTypeContext typeContext, EXPLContext context);
        protected abstract string renderBeginInitializerList(XplInitializerList initializerList, EXPLContext context);
        protected abstract string renderEndInitializerList(XplInitializerList initializerList, EXPLContext context);
        protected abstract string renderSimpleInitializer(XplExpression expression, string expressionStr, EXPLContext context);
        protected abstract string renderInitilizerItem(XplNode node, string nodeStr, int maxNodes, int count, EXPLContext context);
        protected abstract string renderEndArrayInitializer(XplInitializerList initializerList, EXPLContext context);
        protected abstract string renderBeginArrayInitializer(XplInitializerList initializerList, EXPLContext context);
        #endregion

		#region Instrucciones
		protected abstract void renderBeginBlock( XplFunctionBody functionBody, EXPLContext context );
		protected abstract void renderLabel( XplNode label, EXPLContext context );
		protected abstract void renderSetonerror( XplSetonerror setOnerror , EXPLContext context );
		protected abstract void renderEndBlock( XplFunctionBody functionBody, EXPLContext context );
		protected abstract void renderExpressionStatement(XplExpression expression, string expressionString, EXPLContext context );
		protected abstract void renderThrow(XplExpression throwExpression, string expressionString, EXPLContext context );
		protected abstract void renderReturn(XplExpression returnExpression, string expressionString, EXPLContext context );
		protected abstract void renderLocalDeclarator(XplDeclarator decl, string varName, string typeStr, string initializerStr, bool isVolatile);
		protected abstract void renderBeginSwitch(XplSwitchStatement switchSta, string boolExpStr, EXPLContext context);
		protected abstract void renderCaseLabel(XplCase caseNode, string caseExpStr, EXPLContext context);
		protected abstract void renderEndSwitch(XplSwitchStatement switchSta, EXPLContext context);
		protected abstract void renderIfStatement(XplIfStatement ifSta, string boolExp, bool isElse, EXPLContext context);
		protected abstract void renderElseStatement(XplIfStatement ifSta, XplFunctionBody elseBody, EXPLContext context);
		protected abstract void renderForStatement(XplForStatement forSta, string initStr, string boolExpStr, string updateStr, EXPLContext context);
		protected abstract string renderForDeclaration(XplDeclaratorlist decls, EXPLContext context);
		protected abstract void renderWhileStatement(XplDowhileStatement doSta, string boolExpStr, EXPLContext context);
		protected abstract void renderBeginDoStatement(XplDowhileStatement doSta, string boolExpStr, EXPLContext context);
		protected abstract void renderEndDoStatement(XplDowhileStatement doSta, string boolExpStr, EXPLContext context);
		protected abstract void renderBeginTry(XplTryStatement trySta, EXPLContext context);
		protected abstract void renderEndTry(XplTryStatement trySta, EXPLContext context);
		protected abstract void renderCatchStatement(XplCatchStatement catchSta, string declExp, EXPLContext context);
		protected abstract void renderFinally(XplFunctionBody tryBk, EXPLContext context);
		protected abstract void renderBreak(XplJump jump, EXPLContext context);
		protected abstract void renderContinue(XplJump jump, EXPLContext context);
		protected abstract void renderGoto(XplJump jump, string label, EXPLContext context);
		protected abstract void renderResume(XplJump jump, EXPLContext context);
		protected abstract void renderResumeNext(XplJump jump, EXPLContext context);
		protected abstract void renderDirectOutput(XplDirectoutput directOutput, string outputStr, EXPLContext context);
		protected abstract void renderOnpointerStatement(XplFunctionBody functionBody, EXPLContext context);
		#endregion

		#region Expresiones
		protected abstract string renderBeginExpressionList(XplExpressionlist list, int expCount, EXPLContext context);
		protected abstract string renderExpressionListItem(XplExpression expNode, string expStr, int expNumber, int expCount, EXPLContext context);
		protected abstract string renderEndExpressionList(XplExpressionlist list, EXPLContext context);
		protected abstract string renderSimpleName(string name, EXPLContext context);
		protected abstract string renderLiteral(XplLiteral litNode, string litStr, EXPLContext context);
		protected abstract string renderDeleteExp(XplExpression deleteExp, string expStr, EXPLContext context);
		protected abstract string renderOnpointerExp(XplExpression onpointerExp, string expStr, EXPLContext context);
		protected abstract string renderAssingExp(XplAssing assing, string leftExpStr, string rightExpStr, XplAssingop_enum operation, EXPLContext context);
		protected abstract string renderBinOpExp(XplBinaryoperator bopExp, string leftExpStr, string rightExpStr, XplBinaryoperator_enum op, EXPLContext context);
		protected abstract string renderUnOpExp(XplUnaryoperator uopExp, string expStr, XplUnaryoperators_enum op, EXPLContext context);
		protected abstract string renderFunctionCallExp(XplFunctioncall fcallExp, string leftExpStr, string argsStr, bool useBrackets, EXPLContext context);
		protected abstract string renderCastExp(XplCastexpression castExp, string typeStr, string castExpStr, XplCasttype_enum castType, EXPLContext context);
        protected abstract string renderNewExp(XplNewExpression newExp, string typeStr, string initializerStr, EXPLContext context);
        #endregion

		#region Otros
		//Otros
		protected abstract void renderDocumentation(XplDocumentation documentation, EXPLContext context);
		protected abstract void renderUnrecognizedNode(XplNode node, EXPLContext context);
		#endregion

		#endregion

		#region Propiedades
		string LastError{
			get{return p_lastError;}
		}
		string InputFileName{
			get{return p_inputFileName;}
			set{p_inputFileName=value;}
		}
		#endregion
	}
}
