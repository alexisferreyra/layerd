using System;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Collections;
using LayerD.CodeDOM;
using System.CodeDom.Compiler;
using LayerD.ZOECompiler;
using System.Collections.Generic;
using System.Globalization;
using System.Collections.Specialized;

namespace LayerD.OutputModules
{
	/// <summary>
	/// </summary>
	public class SIFTAL_ZOERenderModule: ExtendedZOEProcessor, IEZOERender
    {
        string _outputPath, _outputFileName;

        #region code generation
        protected override void renderUsingDirective(XplName xplName, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            
        }

        protected override string renderWritecodeBlock(XplWriteCodeBody xplWriteCodeBody, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            return "";
        }

        protected override string renderWritecodeExpression(XplExpression xplExpression, string expStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderGetTypeExp(XplType xplType, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            return "";
        }

        protected override string renderTypeOfExp(XplType typeofExpNode, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            return "";
        }

        protected override string renderIsExp(XplCastexpression xplExpression, string expStr, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            return "";
        }

        protected override void processDocumentData(XplDocumentData documentData)
        {
            
        }

        protected override void renderBeginDocumentBody(XplDocumentBody documentBody)
        {
            
        }

        protected override void renderEndDocumentBody(XplDocumentBody documentBody)
        {
            
        }

        protected override void renderImportDirective(XplName importDirective)
        {
            
        }

        protected override void renderBeginNamespace(string namespaceName, XplNamespace namespaceDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndNamespace(string namespaceName, XplNamespace namespaceDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderBeginClass(ExtendedZOEProcessor.EZOEClassType classType, string className, string implementsStr, string inheritsStr, XplAccesstype_enum classAccess, bool isNew, bool isAbstract, bool isFinal, XplClass classDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            Console.WriteLine("Clase: " + classDecl.get_name());
        }

        protected override void renderEndClass(ExtendedZOEProcessor.EZOEClassType classType, string className, XplClass classDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override string renderImplements(XplClass classDecl, XplNodeList implements, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderInherits(XplClass classDecl, XplNodeList inherits, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override void renderBeginFunction(XplFunction functionDecl, string functionName, string returnTypeStr, string parametersStr, XplAccesstype_enum access, XplVarstorage_enum functionStorage, bool isAbstract, bool isFinal, bool isFp, bool isNew, bool isConst, bool isOverride, bool isVirtual, ExtendedZOEProcessor.EZOEContext context)
        {
            Console.WriteLine("Funcion: " + functionDecl.get_name());
        }

        protected override void renderEndFunction(XplFunction functionDecl, string functionName, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderBeginProperty(XplProperty propertyDecl, string propertyName, string typeStr, XplAccesstype_enum access, XplVarstorage_enum propertyStorage, bool isAbstract, bool isFinal, bool isNew, bool isConst, bool isOverride, bool isVirtual, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndProperty(XplProperty propertyDecl, string propertyName, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderBeginGetAccess(ExtendedZOEProcessor.EZOEContext context, XplFunctionBody body)
        {
            
        }

        protected override void renderEndGetAccess(ExtendedZOEProcessor.EZOEContext context, XplFunctionBody body)
        {
            
        }

        protected override void renderBeginSetAccess(ExtendedZOEProcessor.EZOEContext context, XplFunctionBody body)
        {
            
        }

        protected override void renderEndSetAccess(ExtendedZOEProcessor.EZOEContext context, XplFunctionBody body)
        {
            
        }

        protected override void renderField(XplField fieldDecl, string fieldName, string typeStr, string initializerStr, XplAccesstype_enum access, XplVarstorage_enum fieldStorage, bool isNew, bool isVolatile)
        {
            
        }

        protected override void renderBeginParameters(XplParameters parametersDecl, int maxParameter, XplFunction functionDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override string renderParameter(XplParameter parameter, string parameterName, string typeStr, string initializerStr, XplParameterdirection_enum parameterDirection, int parameterNumber, bool isParams, bool isVolatile)
        {
            return "";
        }

        protected override void renderEndParameters(XplParameters parametersDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override string renderType(XplType type, string declareName, ExtendedZOEProcessor.EZOETypeContext typeContext, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderBeginInitializerList(XplInitializerList initializerList, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderEndInitializerList(XplInitializerList initializerList, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderSimpleInitializer(XplExpression expression, string expressionStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderInitilizerItem(XplNode node, string nodeStr, int maxNodes, int count, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderEndArrayInitializer(XplInitializerList initializerList, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderBeginArrayInitializer(XplInitializerList initializerList, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override void renderBeginBlock(XplFunctionBody functionBody, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderLabel(XplNode label, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderSetonerror(XplSetonerror setOnerror, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndBlock(XplFunctionBody functionBody, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderExpressionStatement(XplExpression expression, string expressionString, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderThrow(XplExpression throwExpression, string expressionString, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderReturn(XplExpression returnExpression, string expressionString, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderLocalDeclarator(XplDeclarator decl, string varName, string typeStr, string initializerStr, bool isVolatile)
        {
            
        }

        protected override void renderBeginSwitch(XplSwitchStatement switchSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderCaseLabel(XplCase caseNode, string caseExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndSwitch(XplSwitchStatement switchSta, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderIfStatement(XplIfStatement ifSta, string boolExp, bool isElse, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderElseStatement(XplIfStatement ifSta, XplFunctionBody elseBody, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderForStatement(XplForStatement forSta, string initStr, string boolExpStr, string updateStr, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override string renderForDeclaration(XplDeclaratorlist decls, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override void renderWhileStatement(XplDowhileStatement doSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderBeginDoStatement(XplDowhileStatement doSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndDoStatement(XplDowhileStatement doSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderBeginTry(XplTryStatement trySta, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndTry(XplTryStatement trySta, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderCatchStatement(XplCatchStatement catchSta, string declExp, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderFinally(XplFunctionBody tryBk, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderBreak(XplJump jump, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderContinue(XplJump jump, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderGoto(XplJump jump, string label, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderResume(XplJump jump, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderResumeNext(XplJump jump, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderDirectOutput(XplDirectoutput directOutput, string outputStr, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderOnpointerStatement(XplFunctionBody functionBody, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override string renderBeginExpressionList(XplExpressionlist list, int expCount, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderExpressionListItem(XplExpression expNode, string expStr, int expNumber, int expCount, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderEndExpressionList(XplExpressionlist list, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderSimpleName(string name, ExtendedZOEProcessor.EZOEContext context)
        {
            return name;
        }

        protected override string renderLiteral(XplLiteral litNode, string litStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderDeleteExp(XplExpression deleteExp, string expStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderOnpointerExp(XplExpression onpointerExp, string expStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderAssingExp(XplAssing assing, string leftExpStr, string rightExpStr, XplAssingop_enum operation, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderBinOpExp(XplBinaryoperator bopExp, string leftExpStr, string rightExpStr, XplBinaryoperators_enum op, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderTernaryOpExp(XplTernaryoperator bopExp, string o1ExpStr, string o2ExpStr, string o3ExpStr, XplTernaryoperators_enum op, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderUnOpExp(XplUnaryoperator uopExp, string expStr, XplUnaryoperators_enum op, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderFunctionCallExp(XplFunctioncall fcallExp, string leftExpStr, string argsStr, bool useBrackets, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";            
        }

        protected override string renderCastExp(XplCastexpression castExp, string typeStr, string castExpStr, XplCasttype_enum castType, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override string renderNewExp(XplNewExpression newExp, string typeStr, string initializerStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return "";
        }

        protected override void renderDocumentation(XplDocumentation documentation, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderUnrecognizedNode(XplNode node, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }
        #endregion

        #region IEZOERender Members

        public void SetEZOEInputFileName(string EZOEInputFileName)
        {
            base.p_inputFileName = EZOEInputFileName;
        }

        public void SetEZOEInputDocument(XplDocument EZOEInputDocument)
        {
            this.p_XplDocument = EZOEInputDocument;
        }

        public bool StartParseDocument(bool renderOnly, string buildArguments, string renderArguments)
        {
            Console.WriteLine("Modulo de Salida a SIFTAL");
            Console.WriteLine("Archivo de Salida: " + _outputFileName);
            Console.WriteLine("Path de Salida: " + _outputPath);
            // start parse of document
            this.ParseDocument();
            return true;
        }

        public void SetOutputPath(string outputPath)
        {
            this._outputPath = outputPath;
        }

        public void SetOutputFileName(string outputFileName)
        {
            this._outputFileName = outputFileName;
        }

        public void SetOutputType(XplLayerDZoeProgramModuletype_enum moduleType)
        {

        }

        public IErrorCollection GetLastParseErrors()
        {
            return null;
        }

        public void SetDebug(bool isDebugMode)
        {
            
        }

        public bool SetZoeErrorListToMap(IErrorCollection zoeErrors)
        {
            return false;
        }

        #endregion
    }
}
