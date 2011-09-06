using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LayerD.CodeDOM;

namespace LayerD.OutputModules
{
    class JSZoeRender : ExtendedZOEProcessor, IEZOERender
    {
        #region IEZOERender Members

        public void SetEZOEInputFileName(string EZOEInputFileName)
        {
        }

        public void SetEZOEInputDocument(LayerD.CodeDOM.XplDocument EZOEInputDocument)
        {
        }

        public bool StartParseDocument(bool renderOnly, string buildArguments, string renderArguments)
        {
            return true;
        }

        public void SetOutputPath(string outputPath)
        {
        }

        public void SetOutputFileName(string outputFileName)
        {
        }

        public void SetOutputType(LayerD.CodeDOM.XplLayerDZoeProgramModuletype_enum moduleType)
        {
        }

        public LayerD.ZOECompiler.IErrorCollection GetLastParseErrors()
        {
            return null;
        }

        public void SetDebug(bool isDebugMode)
        {

        }

        public bool SetZoeErrorListToMap(LayerD.ZOECompiler.IErrorCollection zoeErrors)
        {
            return false;
        }

        #endregion

        protected override void renderUsingDirective(LayerD.CodeDOM.XplName xplName, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {

        }

        protected override string renderWritecodeBlock(LayerD.CodeDOM.XplWriteCodeBody xplWriteCodeBody, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            return String.Empty;
        }

        protected override string renderWritecodeExpression(LayerD.CodeDOM.XplExpression xplExpression, string expStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderGetTypeExp(LayerD.CodeDOM.XplType xplType, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            return String.Empty;
        }

        protected override string renderTypeOfExp(LayerD.CodeDOM.XplType typeofExpNode, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            return String.Empty;
        }

        protected override string renderIsExp(LayerD.CodeDOM.XplCastexpression xplExpression, string expStr, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            return String.Empty;
        }

        protected override void processDocumentData(LayerD.CodeDOM.XplDocumentData documentData)
        {
            
        }

        protected override void renderBeginDocumentBody(LayerD.CodeDOM.XplDocumentBody documentBody)
        {
            
        }

        protected override void renderEndDocumentBody(LayerD.CodeDOM.XplDocumentBody documentBody)
        {
            
        }

        protected override void renderImportDirective(LayerD.CodeDOM.XplName importDirective)
        {
            
        }

        protected override void renderBeginNamespace(string namespaceName, LayerD.CodeDOM.XplNamespace namespaceDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndNamespace(string namespaceName, LayerD.CodeDOM.XplNamespace namespaceDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderBeginClass(ExtendedZOEProcessor.EZOEClassType classType, string className, string implementsStr, string inheritsStr, LayerD.CodeDOM.XplAccesstype_enum classAccess, bool isNew, bool isAbstract, bool isFinal, LayerD.CodeDOM.XplClass classDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndClass(ExtendedZOEProcessor.EZOEClassType classType, string className, LayerD.CodeDOM.XplClass classDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override string renderImplements(LayerD.CodeDOM.XplClass classDecl, LayerD.CodeDOM.XplNodeList implements, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderInherits(LayerD.CodeDOM.XplClass classDecl, LayerD.CodeDOM.XplNodeList inherits, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override void renderBeginFunction(LayerD.CodeDOM.XplFunction functionDecl, string functionName, string returnTypeStr, string parametersStr, LayerD.CodeDOM.XplAccesstype_enum access, LayerD.CodeDOM.XplVarstorage_enum functionStorage, bool isAbstract, bool isFinal, bool isFp, bool isNew, bool isConst, bool isOverride, bool isVirtual, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndFunction(LayerD.CodeDOM.XplFunction functionDecl, string functionName, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderBeginProperty(LayerD.CodeDOM.XplProperty propertyDecl, string propertyName, string typeStr, LayerD.CodeDOM.XplAccesstype_enum access, LayerD.CodeDOM.XplVarstorage_enum propertyStorage, bool isAbstract, bool isFinal, bool isNew, bool isConst, bool isOverride, bool isVirtual, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndProperty(LayerD.CodeDOM.XplProperty propertyDecl, string propertyName, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderBeginGetAccess(ExtendedZOEProcessor.EZOEContext context, LayerD.CodeDOM.XplFunctionBody body)
        {
            
        }

        protected override void renderEndGetAccess(ExtendedZOEProcessor.EZOEContext context, LayerD.CodeDOM.XplFunctionBody body)
        {
            
        }

        protected override void renderBeginSetAccess(ExtendedZOEProcessor.EZOEContext context, LayerD.CodeDOM.XplFunctionBody body)
        {
            
        }

        protected override void renderEndSetAccess(ExtendedZOEProcessor.EZOEContext context, LayerD.CodeDOM.XplFunctionBody body)
        {
            
        }

        protected override void renderField(LayerD.CodeDOM.XplField fieldDecl, string fieldName, string typeStr, string initializerStr, LayerD.CodeDOM.XplAccesstype_enum access, LayerD.CodeDOM.XplVarstorage_enum fieldStorage, bool isNew, bool isVolatile)
        {
            
        }

        protected override void renderBeginParameters(LayerD.CodeDOM.XplParameters parametersDecl, int maxParameter, LayerD.CodeDOM.XplFunction functionDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override string renderParameter(LayerD.CodeDOM.XplParameter parameter, string parameterName, string typeStr, string initializerStr, LayerD.CodeDOM.XplParameterdirection_enum parameterDirection, int parameterNumber, bool isParams, bool isVolatile)
        {
            return String.Empty;
        }

        protected override void renderEndParameters(LayerD.CodeDOM.XplParameters parametersDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override string renderType(LayerD.CodeDOM.XplType type, string declareName, ExtendedZOEProcessor.EZOETypeContext typeContext, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderBeginInitializerList(LayerD.CodeDOM.XplInitializerList initializerList, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderEndInitializerList(LayerD.CodeDOM.XplInitializerList initializerList, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderSimpleInitializer(LayerD.CodeDOM.XplExpression expression, string expressionStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderInitilizerItem(LayerD.CodeDOM.XplNode node, string nodeStr, int maxNodes, int count, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderEndArrayInitializer(LayerD.CodeDOM.XplInitializerList initializerList, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderBeginArrayInitializer(LayerD.CodeDOM.XplInitializerList initializerList, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override void renderBeginBlock(LayerD.CodeDOM.XplFunctionBody functionBody, ExtendedZOEProcessor.EZOEContext context)
        {

        }

        protected override void renderLabel(LayerD.CodeDOM.XplNode label, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderSetonerror(LayerD.CodeDOM.XplSetonerror setOnerror, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndBlock(LayerD.CodeDOM.XplFunctionBody functionBody, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderExpressionStatement(LayerD.CodeDOM.XplExpression expression, string expressionString, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderThrow(LayerD.CodeDOM.XplExpression throwExpression, string expressionString, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderReturn(LayerD.CodeDOM.XplExpression returnExpression, string expressionString, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderLocalDeclarator(LayerD.CodeDOM.XplDeclarator decl, string varName, string typeStr, string initializerStr, bool isVolatile)
        {
            
        }

        protected override void renderBeginSwitch(LayerD.CodeDOM.XplSwitchStatement switchSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderCaseLabel(LayerD.CodeDOM.XplCase caseNode, string caseExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndSwitch(LayerD.CodeDOM.XplSwitchStatement switchSta, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderIfStatement(LayerD.CodeDOM.XplIfStatement ifSta, string boolExp, bool isElse, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderElseStatement(LayerD.CodeDOM.XplIfStatement ifSta, LayerD.CodeDOM.XplFunctionBody elseBody, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderForStatement(LayerD.CodeDOM.XplForStatement forSta, string initStr, string boolExpStr, string updateStr, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override string renderForDeclaration(LayerD.CodeDOM.XplDeclaratorlist decls, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;            
        }

        protected override void renderWhileStatement(LayerD.CodeDOM.XplDowhileStatement doSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderBeginDoStatement(LayerD.CodeDOM.XplDowhileStatement doSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndDoStatement(LayerD.CodeDOM.XplDowhileStatement doSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderBeginTry(LayerD.CodeDOM.XplTryStatement trySta, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndTry(LayerD.CodeDOM.XplTryStatement trySta, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderCatchStatement(LayerD.CodeDOM.XplCatchStatement catchSta, string declExp, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderFinally(LayerD.CodeDOM.XplFunctionBody tryBk, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderBreak(LayerD.CodeDOM.XplJump jump, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderContinue(LayerD.CodeDOM.XplJump jump, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderGoto(LayerD.CodeDOM.XplJump jump, string label, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderResume(LayerD.CodeDOM.XplJump jump, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderResumeNext(LayerD.CodeDOM.XplJump jump, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderDirectOutput(LayerD.CodeDOM.XplDirectoutput directOutput, string outputStr, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderOnpointerStatement(LayerD.CodeDOM.XplFunctionBody functionBody, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override string renderBeginExpressionList(LayerD.CodeDOM.XplExpressionlist list, int expCount, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;            
        }

        protected override string renderExpressionListItem(LayerD.CodeDOM.XplExpression expNode, string expStr, int expNumber, int expCount, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderEndExpressionList(LayerD.CodeDOM.XplExpressionlist list, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderSimpleName(string name, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderLiteral(LayerD.CodeDOM.XplLiteral litNode, string litStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderDeleteExp(LayerD.CodeDOM.XplExpression deleteExp, string expStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderOnpointerExp(LayerD.CodeDOM.XplExpression onpointerExp, string expStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderAssingExp(LayerD.CodeDOM.XplAssing assing, string leftExpStr, string rightExpStr, LayerD.CodeDOM.XplAssingop_enum operation, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderBinOpExp(LayerD.CodeDOM.XplBinaryoperator bopExp, string leftExpStr, string rightExpStr, LayerD.CodeDOM.XplBinaryoperators_enum op, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderTernaryOpExp(LayerD.CodeDOM.XplTernaryoperator bopExp, string o1ExpStr, string o2ExpStr, string o3ExpStr, LayerD.CodeDOM.XplTernaryoperators_enum op, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderUnOpExp(LayerD.CodeDOM.XplUnaryoperator uopExp, string expStr, LayerD.CodeDOM.XplUnaryoperators_enum op, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderFunctionCallExp(LayerD.CodeDOM.XplFunctioncall fcallExp, string leftExpStr, string argsStr, bool useBrackets, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderCastExp(LayerD.CodeDOM.XplCastexpression castExp, string typeStr, string castExpStr, LayerD.CodeDOM.XplCasttype_enum castType, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderNewExp(LayerD.CodeDOM.XplNewExpression newExp, string typeStr, string initializerStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override void renderDocumentation(LayerD.CodeDOM.XplDocumentation documentation, ExtendedZOEProcessor.EZOEContext context)
        {

        }

        protected override void renderUnrecognizedNode(LayerD.CodeDOM.XplNode node, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }
    }
}
