/*******************************************************************************
 * Copyright (c) 2012 Intel Corporation, Alexis Ferreyra.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html
 *
 * Contributors:
 *    Alexis Ferreyra (Intel Corporation) - initial API and implementation and/or initial documentation
 *    Alexis Ferreyra  - initial branch from Javascript code generator into new Python code generator
*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using LayerD.CodeDOM;
using System.Globalization;
using System.IO;

namespace LayerD.OutputModules
{
    class PythonZoeRender : ExtendedZOEProcessor, IEZOERender
    {
        private class SpacesPrinter
        {
            const int RESETED = -1;
            PythonZoeRender _renderModule;
            int _currentLine = RESETED;
            
            public SpacesPrinter(PythonZoeRender renderModule)
            {
                this._renderModule = renderModule;
            }

            internal void Restart()
            {
                _currentLine = RESETED;
            }

            internal void PrintSpace(XplNode node)
            {
                string ldsrc = node.get_ldsrc();
                if (String.IsNullOrEmpty(ldsrc)) return;

                int index = ldsrc.IndexOf(',');
                
                int newLine = _currentLine;

                if (index < 0) newLine = Int32.Parse(ldsrc, NumberFormatInfo.InvariantInfo);
                else newLine = Int32.Parse(ldsrc.Substring(0, index), NumberFormatInfo.InvariantInfo);

                if (_currentLine != RESETED && newLine > _currentLine + 1)
                {
                    _renderModule.WriteNewLine();
                }
                if(newLine > _currentLine) _currentLine = newLine;
            }
        }

        const char Space = ' ';

        // output path and Extended Zoe output filename
        string _outputPath, _outputFileName;
        // output module type
        XplLayerDZoeProgramModuletype_enum _outputModuleType;
        // holds current number of nested external classes
        int _isExternalClass;
        // holds number of parameters for current function beign rendered
        int _maxParameter;
        // output buffer
        RenderBuffer _buffer;
        // flag when is on case rendering
        bool _isOnCase;
        // flag to optimize parenthesis use in expressions
        bool _optimizeParenthesis = true;
        // flag to generate Google Closure type annotations in comments
        bool _generateClosureTypeAnnotations = false;
        // flag to remove generation of comments
        bool _removeComments;
        // holds the state for printing spaces between statements
        SpacesPrinter _spacesPrinter;

        XplFunction _mainFunction;
        
        #region Tools
        void RenderComments(XplNode node)
        {
            if (_removeComments) return;

            if (node.get_doc() != null && node.get_doc() != String.Empty)
            {
                string[] comments = node.get_doc().Split('\n');
                for (int n = 0; n < comments.Length; n++)
                {
                    string comment = comments[n].Replace('\r', ' ').Trim();
                    if (comment != String.Empty)
                    {
                        if (node.get_TypeName() == CodeDOMTypes.XplClass ||
                            node.get_TypeName() == CodeDOMTypes.XplNamespace)
                        {
                            Write("# " + comment);
                        }
                        else
                        {
                            Write("# " + comment);
                        }
                        WriteNewLine();
                    }
                }
            }
        }

        private void PrepareOutput()
        {
            _buffer = new RenderBuffer(_outputPath);
            _buffer.ProgramName = Path.GetFileName(this._outputFileName);
        }

        private void CloseOutput()
        {
            _buffer.Close();
        }

        private void RenderMultipleFiles()
        {
            _buffer.Render();
        }

        void AddError(string errorString)
        {
            // TODO
        }

        void AddWarning(string warningMessage)
        {
            // TODO
        }

        private void CheckBuffer(XplNode node)
        {
            //_buffer.ChangeBufferIfNeeded(node);
        }

        private void Write(string str)
        {
            _buffer.Write(str);
        }

        private void WriteNewLine()
        {
            _buffer.WriteNewLine();
        }

        private void IncreaseTabulation()
        {
            _buffer.IncreaseTabulation();
        }

        private void DecreaseTabulation()
        {
            _buffer.DecreaseTabulation();
        }

        private void WriteLine(string str)
        {
            Write(str);
            WriteNewLine();
        }
        #endregion

        public PythonZoeRender()
        {
            this._spacesPrinter = new SpacesPrinter(this);
            Keywords.Init();
        }

        public void SetEZOEInputFileName(string EZOEInputFileName)
        {
            p_inputFileName = EZOEInputFileName;
        }

        public void SetEZOEInputDocument(LayerD.CodeDOM.XplDocument EZOEInputDocument)
        {
            p_XplDocument = EZOEInputDocument;
        }

        public bool StartParseDocument(bool renderOnly, string buildArguments, string renderArguments)
        {
            bool parseResult = false;

            try
            {
                if (!String.IsNullOrEmpty(renderArguments))
                {
                    Dictionary<string,string> arguments = PythonTools.ParseRenderArguments(renderArguments.Trim().ToLowerInvariant());
                    if (arguments.ContainsKey("removecomments"))
                    {
                        _removeComments = true;
                    }
                    if(arguments.ContainsKey("closureannotations"))
                    {
                        _generateClosureTypeAnnotations = !_generateClosureTypeAnnotations;
                    }
                }

                PrepareOutput();

                parseResult = base.ParseDocument();
            }
            finally
            {
                CloseOutput();
            }

            RenderMultipleFiles();

            return parseResult;
        }

        public void SetOutputPath(string outputPath)
        {
            if (outputPath == null) return;
            if (outputPath[outputPath.Length - 1] != Path.DirectorySeparatorChar)
                outputPath += Path.DirectorySeparatorChar;
            _outputPath = outputPath;
        }

        public void SetOutputFileName(string EZOEOutputFileName)
        {
            _outputFileName = EZOEOutputFileName;
        }

        public void SetOutputType(LayerD.CodeDOM.XplLayerDZoeProgramModuletype_enum moduleType)
        {
            _outputModuleType = moduleType;
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
            //XplType tempType = xplExpression.get_type();
            //while (tempType.get_dt() != null) tempType = tempType.get_dt();
            //typeStr = PythonTools.processUserTypeName(tempType.get_typename());

            return expStr + Space + Keywords.Is + Space + typeStr;
        }

        protected override void processDocumentData(LayerD.CodeDOM.XplDocumentData documentData)
        {
            
        }

        protected override void renderBeginDocumentBody(LayerD.CodeDOM.XplDocumentBody documentBody)
        {
            
        }

        protected override void renderEndDocumentBody(LayerD.CodeDOM.XplDocumentBody documentBody)
        {
            if (this._mainFunction != null)
            {
                string parameters = String.Empty;
                if (this._mainFunction.get_Parameters() != null)
                {
                    // TODO use "sys.argv"
                    // will need to add the import to sys
                    parameters = "None";
                }
                WriteNewLine();
                WriteLine("# CALL MAIN FUNCTION");
                WriteLine(PythonTools.GetFullDeclarationName(this._mainFunction) + "(" + parameters + ")");
            }
        }

        protected override void renderImportDirective(LayerD.CodeDOM.XplName importDirective)
        {
            _buffer.AddImportDirective(importDirective);
        }

        protected override void renderBeginNamespace(string namespaceName, LayerD.CodeDOM.XplNamespace namespaceDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            if (PythonTools.IsEmptyNamespace(namespaceDecl)) return;

            // Do nothing. Namespaces are processed in RenderBuffer
            WriteNewLine();
            WriteLine("# BEGIN NAMESPACE " + namespaceName);
            WriteLine(Keywords.Class + Space + namespaceName + ":");
            IncreaseTabulation();
            WriteNewLine();
        }

        protected override void renderEndNamespace(string namespaceName, LayerD.CodeDOM.XplNamespace namespaceDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            if (PythonTools.IsEmptyNamespace(namespaceDecl)) return;

            DecreaseTabulation();
            WriteLine("# END NAMESPACE " + namespaceName);
        }

        void WriteCommentLine(string comment)
        {
            if (_removeComments) return;
            WriteLine("# " + comment);
        }

        protected override void renderBeginClass(ExtendedZOEProcessor.EZOEClassType classType, string className, string implementsStr, string inheritsStr, LayerD.CodeDOM.XplAccesstype_enum classAccess, bool isNew, bool isAbstract, bool isFinal, LayerD.CodeDOM.XplClass classDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            if (classDecl.get_external())
            {
                _isExternalClass++;
                return;
            }

            // check if is needed to change output buffer
            CheckBuffer(classDecl);
            _buffer.RegisterUserDefinedType(classDecl);
            
            string fullDeclName = PythonTools.GetFullDeclarationName(classDecl);

            Write(Keywords.Class + Space + className);

            WriteLine(":");
            IncreaseTabulation();

            // render constructors
            renderInternalCopyMethod( classDecl );

        }

        private void renderInternalCopyMethod(XplClass classDecl)
        {
            // TODO
        }

        private void CloseFunction()
        {
            DecreaseTabulation();
            WriteNewLine();
        }

        protected override void renderEndClass(ExtendedZOEProcessor.EZOEClassType classType, string className, LayerD.CodeDOM.XplClass classDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            if (_isExternalClass > 0)
            {
                if (classDecl.get_external()) _isExternalClass--;
                return;
            }

            DecreaseTabulation();
            WriteNewLine();
        }

        protected override string renderImplements(LayerD.CodeDOM.XplClass classDecl, LayerD.CodeDOM.XplNodeList implements, ExtendedZOEProcessor.EZOEContext context)
        {
            string retVal = String.Empty;
            foreach (XplInherits inhs in implements)
            {
                var typeList = inhs.FindNodes("@XplType");
                foreach (XplType type in typeList)
                {
                    string typeStr = renderType(type, String.Empty, EZOETypeContext.Expression, EZOEContext.Expression);
                    if (typeStr != "zoe.lang.Object" && typeStr != "js.Object")
                    {
                        retVal += String.IsNullOrEmpty(retVal) ? typeStr : "," + typeStr;
                    }
                }
            }
            return retVal;
        }

        protected override string renderInherits(LayerD.CodeDOM.XplClass classDecl, LayerD.CodeDOM.XplNodeList inherits, ExtendedZOEProcessor.EZOEContext context)
        {
            return renderImplements(classDecl, inherits, context);
        }

        protected override void renderBeginFunction(LayerD.CodeDOM.XplFunction functionDecl, string functionName, string returnTypeStr, string parametersStr, LayerD.CodeDOM.XplAccesstype_enum access, LayerD.CodeDOM.XplVarstorage_enum functionStorage, bool isAbstract, bool isFinal, bool isFp, bool isNew, bool isConst, bool isOverride, bool isVirtual, ExtendedZOEProcessor.EZOEContext context)
        {
            if (_isExternalClass > 0 || functionStorage == XplVarstorage_enum.EXTERN || functionStorage == XplVarstorage_enum.STATIC_EXTERN) return;

            XplClass currentClass = functionDecl.CurrentClass;

            // if is constructor return
            if (functionName == currentClass.get_name()) functionName = "__init__";
            
            bool isStatic = functionStorage == XplVarstorage_enum.STATIC;
            string className = PythonTools.GetValidIdentifier(currentClass.get_name(), false);
            string fullDeclName = PythonTools.GetFullDeclarationName(currentClass);
            functionName = PythonTools.GetValidIdentifier(functionName, false);
            
            if (!isStatic)
            {
                if (String.IsNullOrEmpty(parametersStr)) parametersStr = "self";
                else parametersStr = "self, " + parametersStr;
            }
            else
            {
                if (functionDecl.get_access() == XplAccesstype_enum.PUBLIC && functionName == "Main")
                {
                    _mainFunction = functionDecl;
                }

                WriteLine("@staticmethod");
            }

            Write(Keywords.Def + Space + functionName);
            //Write(Keywords.Function);

            // parameters
            Write("(" + parametersStr + ") :");

            if (!currentClass.get_isinterface())
            {
                WriteNewLine();
                IncreaseTabulation();
            }

            //renderCopyByValueParameters(functionDecl);
        }

        private void renderCopyByValueParameters(XplFunction functionDecl)
        {
            if(functionDecl.get_Parameters() == null) return;

            XplNodeList parameters = functionDecl.get_Parameters().Children();
            
            foreach(XplParameter parameter in parameters)
            {
                if(PythonTools.IsCustomValueType(parameter.get_type()))
                {
                    string parameterName = PythonTools.GetValidIdentifier(parameter.get_name(), false);

                    Write(parameterName + " = " + parameterName + "._copy()");
                    WriteNewLine();
                }
            }
        }

        protected override void renderEndFunction(LayerD.CodeDOM.XplFunction functionDecl, string functionName, ExtendedZOEProcessor.EZOEContext context)
        {
            bool isAbstract = functionDecl.get_abstract();
            XplVarstorage_enum functionStorage = functionDecl.get_storage();

            if (_isExternalClass > 0 || functionStorage == XplVarstorage_enum.EXTERN || functionStorage == XplVarstorage_enum.STATIC_EXTERN)
            {
                return;
            }

            // if its a constructor return
            if(functionName == functionDecl.CurrentClass.get_name()) return;

            bool isInterface = functionDecl.CurrentClass.get_isinterface();

            if (!isAbstract && functionStorage != XplVarstorage_enum.EXTERN && functionStorage != XplVarstorage_enum.STATIC_EXTERN)
            {
                DecreaseTabulation();
                WriteNewLine();
            }

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
            if (_isExternalClass > 0 || fieldStorage == XplVarstorage_enum.EXTERN || fieldStorage == XplVarstorage_enum.STATIC_EXTERN) return;

            bool isStatic = fieldStorage == XplVarstorage_enum.STATIC;

            string className = PythonTools.GetValidIdentifier(fieldDecl.CurrentClass.get_name(), false);
            string fullDeclName = PythonTools.GetFullDeclarationName(fieldDecl.CurrentClass);

            Write(PythonTools.GetValidIdentifier(fieldName, false));

            if (String.IsNullOrEmpty(initializerStr))
            {
                WriteLine(" = " + PythonTools.GetDefaultInitForFieldDecl(fieldDecl.get_type()));
            }
            else
            {
                WriteLine(" = " + initializerStr);
            }
        }

        protected override void renderBeginParameters(LayerD.CodeDOM.XplParameters parametersDecl, int maxParameter, LayerD.CodeDOM.XplFunction functionDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            _maxParameter = maxParameter;
        }

        protected override string renderParameter(LayerD.CodeDOM.XplParameter parameter, string parameterName, string typeStr, string initializerStr, LayerD.CodeDOM.XplParameterdirection_enum parameterDirection, int parameterNumber, bool isParams, bool isVolatile)
        {
            string retStr = String.Empty;

            parameterName = PythonTools.GetValidIdentifier(parameterName, false);

            if (parameterNumber != _maxParameter) retStr += parameterName + ", ";
            else retStr += parameterName;

            return retStr;
        }

        protected override void renderEndParameters(LayerD.CodeDOM.XplParameters parametersDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            _maxParameter = 0;
        }

        protected override string renderType(LayerD.CodeDOM.XplType type, string declareName, ExtendedZOEProcessor.EZOETypeContext typeContext, ExtendedZOEProcessor.EZOEContext context)
        {
            switch (typeContext)
            {
                case EZOETypeContext.ReturnTypeDecl:
                case EZOETypeContext.ParameterDecl:
                case EZOETypeContext.FieldDecl:
                case EZOETypeContext.LocalVarDecl:
                case EZOETypeContext.ForVarDecl:
                case EZOETypeContext.PropertyDecl:
                    break;
                case EZOETypeContext.CatchVarDecl:
                    while (type.get_dt() != null) type = type.get_dt();
                    string typeStr = PythonTools.processUserTypeName(type.get_typename());
                    return typeStr + Space + Keywords.As + Space + declareName;
                case EZOETypeContext.SizeofExp:
                    break;
                case EZOETypeContext.GettypeExp:
                    break;
                case EZOETypeContext.CastExp:
                    break;
                case EZOETypeContext.Expression:
                    return PythonTools.processUserTypeName(type.get_typename());
                case EZOETypeContext.Unknow:
                    break;
                default:
                    break;
            }
            return String.Empty;
        }

        protected override string renderBeginInitializerList(LayerD.CodeDOM.XplInitializerList initializerList, ExtendedZOEProcessor.EZOEContext context)
        {
            XplNode parent = initializerList.get_Parent();
            if (parent.IsA(CodeDOMTypes.XplNewExpression) && ((XplNewExpression)parent).get_type().get_typeStr() == "js.Object")
            {
                return "[";
            }
            else
            {
                return "(";
            }
        }

        protected override string renderEndInitializerList(LayerD.CodeDOM.XplInitializerList initializerList, ExtendedZOEProcessor.EZOEContext context)
        {
            XplNode parent = initializerList.get_Parent();
            if (parent.IsA(CodeDOMTypes.XplNewExpression) && ((XplNewExpression)parent).get_type().get_typeStr() == "js.Object")
            {
                return "]";
            }
            else
            {
                return ")";
            }
        }

        protected override string renderSimpleInitializer(LayerD.CodeDOM.XplExpression expression, string expressionStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return expressionStr;
        }

        protected override string renderInitilizerItem(LayerD.CodeDOM.XplNode node, string nodeStr, int maxNodes, int count, ExtendedZOEProcessor.EZOEContext context)
        {
            if (count == maxNodes)
            {
                return nodeStr;
            }
            else
            {
                XplNode parent = node.get_Parent().get_Parent().get_Parent();
                if (parent.IsA(CodeDOMTypes.XplNewExpression) && ((XplNewExpression)parent).get_type().get_typeStr() == "js.Object")
                {
                    if (count % 2 == 0) return nodeStr + ", ";
                    else return nodeStr + " : ";
                }
                else
                {
                    return nodeStr + ", ";
                }
            }
        }

        protected override string renderEndArrayInitializer(LayerD.CodeDOM.XplInitializerList initializerList, ExtendedZOEProcessor.EZOEContext context)
        {
            return "]";
        }

        protected override string renderBeginArrayInitializer(LayerD.CodeDOM.XplInitializerList initializerList, ExtendedZOEProcessor.EZOEContext context)
        {
            return "[";
        }

        protected override void renderBeginBlock(LayerD.CodeDOM.XplFunctionBody functionBody, ExtendedZOEProcessor.EZOEContext context)
        {
            if (context == EZOEContext.FunctionBody &&
                functionBody.get_Parent().get_TypeName() != CodeDOMTypes.XplFunctionBody ||
                functionBody.get_Parent().get_TypeName() == CodeDOMTypes.XplFunctionBody &&
                functionBody.get_DeclsNodeList().GetLength() > 0)
            {
                WriteNewLine();
                IncreaseTabulation();
            }
            this._spacesPrinter.Restart();
        }

        protected override void renderLabel(LayerD.CodeDOM.XplNode label, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(label);
        }

        protected override void renderSetonerror(LayerD.CodeDOM.XplSetonerror setOnerror, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        protected override void renderEndBlock(LayerD.CodeDOM.XplFunctionBody functionBody, ExtendedZOEProcessor.EZOEContext context)
        {
            if (context == EZOEContext.FunctionBody &&
                functionBody.get_Parent().get_TypeName() != CodeDOMTypes.XplFunctionBody ||
                functionBody.get_Parent().get_TypeName() == CodeDOMTypes.XplFunctionBody &&
                functionBody.get_DeclsNodeList().GetLength() > 0)
            {
                DecreaseTabulation();
            }            
        }

        protected override void renderExpressionStatement(LayerD.CodeDOM.XplExpression expression, string expressionString, ExtendedZOEProcessor.EZOEContext context)
        {
            if (expressionString != String.Empty)
            {
                this._spacesPrinter.PrintSpace(expression);
                RenderComments(expression);
                WriteLine(expressionString);
            }
        }

        protected override void renderThrow(LayerD.CodeDOM.XplExpression throwExpression, string expressionString, ExtendedZOEProcessor.EZOEContext context)
        {
            WriteLine(Keywords.Raise + Space + expressionString);
        }

        protected override void renderReturn(LayerD.CodeDOM.XplExpression returnExpression, string expressionString, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(returnExpression);

            if (expressionString == String.Empty)
            {
                WriteLine(Keywords.Return);
            }
            else
            {
                WriteLine(Keywords.Return + Space + expressionString);
            }
        }

        protected override void renderLocalDeclarator(LayerD.CodeDOM.XplDeclarator decl, string varName, string typeStr, string initializerStr, bool isVolatile)
        {
            this._spacesPrinter.PrintSpace(decl);
            RenderComments(decl);

            Write(PythonTools.GetValidIdentifier(varName, false));

            // if there is initializer render it
            if (!String.IsNullOrEmpty(initializerStr) && decl.get_i() != null && decl.get_i().Children().FirstNode() != null)
            {
                if (decl.get_i().Children().FirstNode().get_ElementName() != "list" || initializerStr[0] != '(') Write(" = " + initializerStr);
                else Write(initializerStr);
            }
            else
            {
                initializerStr = PythonTools.RenderValueTypesInitializer(decl.get_type());
                if(!String.IsNullOrEmpty(initializerStr)) Write(" = " + initializerStr);
            }
            WriteNewLine();
        }

        protected override void renderBeginSwitch(LayerD.CodeDOM.XplSwitchStatement switchSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(switchSta);

            WriteLine("_switchValue = " + boolExpStr);
        }

        protected override void renderCaseLabel(LayerD.CodeDOM.XplCase caseNode, string caseExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(caseNode);

            if (_isOnCase) DecreaseTabulation();
            if (caseExpStr == String.Empty)
            {
                WriteLine(Keywords.Else + ":");
            }
            else
            {
                WriteLine(Keywords.Elif + Space + caseExpStr + ":");
            }
            _isOnCase = true;
            IncreaseTabulation();
        }

        protected override void renderEndSwitch(LayerD.CodeDOM.XplSwitchStatement switchSta, ExtendedZOEProcessor.EZOEContext context)
        {
            if (_isOnCase) DecreaseTabulation();
            _isOnCase = false;
            WriteNewLine();
        }

        protected override void renderIfStatement(LayerD.CodeDOM.XplIfStatement ifSta, string boolExp, bool isElse, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(ifSta);

            if (!isElse)
            {
                Write(Keywords.If + Space + boolExp + ":");
            }
            else
            {
                Write(Keywords.Elif + Space + boolExp + ":");
            }
        }

        protected override void renderElseStatement(LayerD.CodeDOM.XplIfStatement ifSta, LayerD.CodeDOM.XplFunctionBody elseBody, ExtendedZOEProcessor.EZOEContext context)
        {
            if (elseBody != null) Write(Keywords.Else + ":");
        }

        protected override void renderForStatement(LayerD.CodeDOM.XplForStatement forSta, string initStr, string boolExpStr, string updateStr, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(forSta);

            if (PythonTools.IsForeach(forSta))
            {
                //if (PythonTools.IsPythonArray(forSta.get_condition().get_typeStr()))
                //{
                //    Write(boolExpStr + ".forEach( " + Keywords.Function + "(" + initStr + ")");
                //}
                //else
                //{
                //    Write("Object.keys(" + boolExpStr + ").forEach( " + Keywords.Function + "(" + initStr + ")");
                //}
            }
            else
            {
                Write(Keywords.For + Space + "(" + initStr + "; " + boolExpStr + "; " + updateStr + ")");
            }

        }

        protected override string renderForDeclaration(LayerD.CodeDOM.XplDeclaratorlist decls, ExtendedZOEProcessor.EZOEContext context)
        {
            //XplNodeList listaDeclaraciones = decls.Children();
            //string varName = String.Empty, initStr = String.Empty, typeStr = String.Empty, backTypeStr = String.Empty;
            //string retStr = PythonTools.IsForeach(decls.get_Parent().get_Parent() as XplForStatement) ? String.Empty : Keywords.Var;

            //// for(int a = 0, d, f;; ....
            //for (int n = 0; n < listaDeclaraciones.GetLength(); n++)
            //{
            //    XplDeclarator nodo = (XplDeclarator)listaDeclaraciones.GetNodeAt(n);
            //    varName = nodo.get_name();
            //    initStr = processInitializer(nodo.get_i(), EZOEContext.Statement);
            //    typeStr = renderType(nodo.get_type(), String.Empty, EZOETypeContext.ForVarDecl, EZOEContext.Statement);
            //    if (n == 0)
            //    {
            //        backTypeStr = typeStr;
            //        retStr += typeStr;
            //    }
            //    else
            //    {
            //        if (typeStr != backTypeStr) //Error
            //            AddError("ERROR: tipo inesperado en declaración de variables de bloque for.");
            //    }
            //    // Agrego el nombre de la variable
            //    retStr += " " + PythonTools.GetValidIdentifier(varName, false);
            //    // Agrego el inicializador
            //    if (initStr != String.Empty)
            //    {
            //        if (nodo.get_i().Children().FirstNode().get_ElementName() != "list")
            //        {
            //            retStr += " = " + initStr;
            //        }
            //        else
            //        {
            //            retStr += initStr;
            //        }
            //    }
            //    // Agrego la coma
            //    if (n != listaDeclaraciones.GetLength() - 1)
            //    {
            //        retStr += ", ";
            //    }
            //}
            //return retStr.Trim();
            return String.Empty;
        }

        protected override void renderWhileStatement(LayerD.CodeDOM.XplDowhileStatement doSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(doSta);

            Write(Keywords.While + Space + boolExpStr + ":");
        }

        protected override void renderBeginDoStatement(LayerD.CodeDOM.XplDowhileStatement doSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(doSta);

            // Write(Keywords.While + Space);
        }

        protected override void renderEndDoStatement(LayerD.CodeDOM.XplDowhileStatement doSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            // WriteLine(Keywords.While + Space + "(" + boolExpStr + ");");
        }

        protected override void renderBeginTry(LayerD.CodeDOM.XplTryStatement trySta, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(trySta);

            Write(Keywords.Try + ":");
        }

        protected override void renderEndTry(LayerD.CodeDOM.XplTryStatement trySta, ExtendedZOEProcessor.EZOEContext context)
        {
            WriteNewLine();            
        }

        protected override void renderCatchStatement(LayerD.CodeDOM.XplCatchStatement catchSta, string declExp, ExtendedZOEProcessor.EZOEContext context)
        {
            Write(Keywords.Except + Space + declExp + ":");
        }

        protected override void renderFinally(LayerD.CodeDOM.XplFunctionBody tryBk, ExtendedZOEProcessor.EZOEContext context)
        {
            Write(Keywords.Finally);
        }

        protected override void renderBreak(LayerD.CodeDOM.XplJump jump, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(jump);

            Write(Keywords.Break + ";");
            WriteNewLine();
        }

        protected override void renderContinue(LayerD.CodeDOM.XplJump jump, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(jump);

            Write(Keywords.Continue + ";");
            WriteNewLine();
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
            // Please, don't use this !!! (It's like unrestricted GOTO... BAD BAD BAD PRACTICE !!!)
            //
            string targetPlatform = directOutput.get_TargetPlatform();
            if (String.IsNullOrEmpty(targetPlatform)) return;

            if (targetPlatform.ToUpperInvariant().Contains("PYTHON"))
            {
                WriteLine(directOutput.get_output());
            }
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
            if (expNumber != expCount) return expStr + ", ";
            else return expStr;
        }

        protected override string renderEndExpressionList(LayerD.CodeDOM.XplExpressionlist list, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderSimpleName(XplNode node, string name, ExtendedZOEProcessor.EZOEContext context)
        {
            if (name == "this")
            {
                return "self";
            }
            else if (name == "base")
            {
                return "base";
            }
            else
            {
                return PythonTools.processUserTypeName(name);
            }
        }

        protected override string renderLiteral(LayerD.CodeDOM.XplLiteral litNode, string litStr, ExtendedZOEProcessor.EZOEContext context)
        {
            string tempStr;

            switch (litNode.get_type())
            {
                case XplLiteraltype_enum.NULL:
                    tempStr = "None";
                    break;
                case XplLiteraltype_enum.ASCIICHAR:
                case XplLiteraltype_enum.CHAR:
                    tempStr = "b'" + litStr + "'";
                    break;
                case XplLiteraltype_enum.BOOL:
                case XplLiteraltype_enum.HEX:
                case XplLiteraltype_enum.INTEGER:
                case XplLiteraltype_enum.OCT:
                case XplLiteraltype_enum.REAL:
                case XplLiteraltype_enum.DOUBLE:
                case XplLiteraltype_enum.DECIMAL:
                    tempStr = litStr;
                    break;
                case XplLiteraltype_enum.FLOAT:
                    tempStr = litStr.EndsWith("f", StringComparison.InvariantCulture) ? litStr.Substring(0, litStr.Length - 1) : litStr;
                    break;
                case XplLiteraltype_enum.DATETIME:
                case XplLiteraltype_enum.ASCIISTRING:
                case XplLiteraltype_enum.STRING:
                    tempStr = "\"" + litStr + "\"";
                    break;
                case XplLiteraltype_enum.OTHER:
                    AddWarning("Literal type 'OTHER' not supported.");
                    tempStr = "\"" + litStr + "\"";
                    break;
                case XplLiteraltype_enum.UUID:
                    AddWarning("Literal type 'UUID' not supported.");
                    tempStr = "\"" + litStr + "\"";
                    break;
                default:
                    AddWarning("Literal type not supported.");
                    tempStr = "\"" + litStr + "\"";
                    break;
            }

            return tempStr;
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
            if ((int)Precedences.AssingExp == PythonTools.getExpressionPrecedence(assing.get_l()))
            {
                leftExpStr = "(" + leftExpStr + ")";
            }

            #region Switch de Operadores de Asignación
            string tempStr = String.Empty;

            switch (operation)
            {
                case XplAssingop_enum.ADD:
                    tempStr = leftExpStr + " += " + rightExpStr;
                    break;
                case XplAssingop_enum.AND:
                    tempStr = leftExpStr + " &= " + rightExpStr;
                    break;
                case XplAssingop_enum.DIV:
                    tempStr = leftExpStr + " /= " + rightExpStr;
                    break;
                case XplAssingop_enum.LSH:
                    tempStr = leftExpStr + " <<= " + rightExpStr;
                    break;
                case XplAssingop_enum.MOD:
                    tempStr = leftExpStr + " %= " + rightExpStr;
                    break;
                case XplAssingop_enum.MUL:
                    tempStr = leftExpStr + " *= " + rightExpStr;
                    break;
                case XplAssingop_enum.NONE:
                    tempStr = leftExpStr + " = " + rightExpStr;
                    break;
                case XplAssingop_enum.OR:
                    tempStr = leftExpStr + " |= " + rightExpStr;
                    break;
                case XplAssingop_enum.RSH:
                    tempStr = leftExpStr + " >>= " + rightExpStr;
                    break;
                case XplAssingop_enum.SUB:
                    tempStr = leftExpStr + " -= " + rightExpStr;
                    break;
                case XplAssingop_enum.XOR:
                    tempStr = leftExpStr + " ^= " + rightExpStr;
                    break;
            }
            #endregion

            if (PythonTools.IsCustomValueType(assing.get_r().get_typeStr()) && !assing.get_r().get_Content().IsA(CodeDOMTypes.XplFunctioncall))
            {
                // TODO review for python
                // requires copy
                tempStr += "._copy()";
            }

            if (PythonTools.requireParenthesis(assing)) tempStr = "(" + tempStr + ")";

            return tempStr;
        }

        protected override string renderBinOpExp(LayerD.CodeDOM.XplBinaryoperator bopExp, string leftExpStr, string rightExpStr, LayerD.CodeDOM.XplBinaryoperators_enum op, ExtendedZOEProcessor.EZOEContext context)
        {
            string tempStr = String.Empty;

            switch (op)
            {
                case XplBinaryoperators_enum.IMP: //Flecha "=>"
                case XplBinaryoperators_enum.M: //Member access "."
                case XplBinaryoperators_enum.MP: //Member Pointer Access ".*"
                case XplBinaryoperators_enum.PM: //Pointer Member Access "->"
                case XplBinaryoperators_enum.PMP: //Pointer To Member Pointer Access "->*"
                case XplBinaryoperators_enum.RM: //Reservado para Acceso a miembros
                    if (_optimizeParenthesis && PythonTools.getOperatorPrecedence(op) > PythonTools.getExpressionPrecedence(bopExp.get_l()))
                    {
                        leftExpStr = "(" + leftExpStr + ")";
                    }
                    break;
                default:
                    if (_optimizeParenthesis && PythonTools.getOperatorPrecedence(op) == PythonTools.getExpressionPrecedence(bopExp.get_r()))
                    {
                        rightExpStr = "(" + rightExpStr + ")";
                    }
                    break;
            }
            //Bandera para evitar usar parentesis en accesos a miembros
            bool flag = false;

            switch (op)
            {
                case XplBinaryoperators_enum.ADD: //Suma
                    tempStr = leftExpStr + " + " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.AND: //Y Logico
                    tempStr = leftExpStr + Keywords.And + rightExpStr;
                    break;
                case XplBinaryoperators_enum.BAND: //Y de Bits
                    tempStr = leftExpStr + " & " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.BOR: //O de Bits
                    tempStr = leftExpStr + " | " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.DIV: //Division
                    tempStr = leftExpStr + " / " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.EQ: //Igualdad Logico
                    tempStr = leftExpStr + " == " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.EXP: //Exponente
                    tempStr = leftExpStr + " ** " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.GR: //Mayor que
                    tempStr = leftExpStr + " > " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.GREQ: //Mayor o igual que
                    tempStr = leftExpStr + " >= " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.IMP: //Felcha "=>"
                    tempStr = rightExpStr;
                    break;
                case XplBinaryoperators_enum.LS: //Menor que
                    tempStr = leftExpStr + " < " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.LSEQ: //Menor o igual que
                    tempStr = leftExpStr + " <= " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.LSH: //Left shift
                    tempStr = leftExpStr + " << " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.M: //Member access "."
                    tempStr = leftExpStr + "." + rightExpStr;
                    flag = true;
                    break;
                case XplBinaryoperators_enum.MIN: //Resta
                    tempStr = leftExpStr + " - " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.MOD: //Modulo (resto)
                    tempStr = leftExpStr + " % " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.MP: //Member Pointer Access ".*"
                    tempStr = leftExpStr + "." + rightExpStr; 
                    flag = true;
                    break;
                case XplBinaryoperators_enum.MUL: //Multiplicacion
                    tempStr = leftExpStr + " * " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.NOTEQ: //No Igual logico
                    tempStr = leftExpStr + " != " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.OR: //O Logico
                    tempStr = leftExpStr + Keywords.Or + rightExpStr;
                    break;
                case XplBinaryoperators_enum.PM: //Pointer Member Access "->"
                    AddWarning("Pointer member access is not supported by Python module.");
                    // check if left exp is new
                    if (bopExp.get_l().get_Content().IsA(CodeDOMTypes.XplNewExpression))
                    {
                        tempStr = "(" + leftExpStr + ")." + rightExpStr;
                    }
                    tempStr = leftExpStr + "." + rightExpStr; flag = true;
                    break;
                case XplBinaryoperators_enum.PMP: //Pointer To Member Pointer Access "->*"
                    AddWarning("Pointer to member pointer access is not supported by Python module.");
                    tempStr = leftExpStr + "." + rightExpStr; flag = true;
                    break;
                case XplBinaryoperators_enum.RM: //Reservado para Acceso a miembros
                    tempStr = leftExpStr + "." + rightExpStr; flag = true;
                    break;
                case XplBinaryoperators_enum.RSH: //Right shift
                    tempStr = leftExpStr + " >> " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.XOR: //Xor de Bits
                    tempStr = leftExpStr + " ^ " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.COMMA:
                    tempStr = leftExpStr + ", " + rightExpStr;
                    break;
                default:
                    tempStr = leftExpStr + "+" + rightExpStr;
                    AddError("Unrecognized binary operator in expression.");
                    break;
            }

            if (_optimizeParenthesis)
            {
                if (!flag && PythonTools.requireParenthesis(bopExp)) tempStr = "(" + tempStr + ")";
            }
            else
            {
                if (!flag) tempStr = "(" + tempStr + ")";
            }

            return tempStr;
        }

        protected override string renderTernaryOpExp(LayerD.CodeDOM.XplTernaryoperator bopExp, string o1ExpStr, string o2ExpStr, string o3ExpStr, LayerD.CodeDOM.XplTernaryoperators_enum op, ExtendedZOEProcessor.EZOEContext context)
        {
            if (op == XplTernaryoperators_enum.BOOLEAN)
            {
                return "(" + o1ExpStr + Space + Keywords.If + Space + o2ExpStr + Space + Keywords.Else + Space + o3ExpStr + ")";
            }
            else
            {
                AddError("Ternary operator not supported.");
                return "__error__ternary_operator_not_supported__(" + o1ExpStr + ", " + o2ExpStr + ", " + o3ExpStr + ")";
            }
        }

        protected override string renderUnOpExp(LayerD.CodeDOM.XplUnaryoperator uopExp, string expStr, LayerD.CodeDOM.XplUnaryoperators_enum op, ExtendedZOEProcessor.EZOEContext context)
        {
            String tempStr = String.Empty;

            switch (op)
            {
                case XplUnaryoperators_enum.AOF: //Address of '&'                    
                    tempStr = "addressOf(" + expStr + ")";
                    break;
                case XplUnaryoperators_enum.DEC: //Decremento postfijo 'e--'
                    tempStr = expStr + "--";
                    break;
                case XplUnaryoperators_enum.INC: //Incremento postfijo 'e++'
                    tempStr = expStr + "++";
                    break;
                case XplUnaryoperators_enum.IND: //Indireccion de puntero '*'
                    tempStr = "*" + expStr;
                    break;
                case XplUnaryoperators_enum.MIN: //Negativo '-'
                    tempStr = "-" + expStr;
                    break;
                case XplUnaryoperators_enum.NOT: //Negado logico '!'
                    tempStr = Keywords.Not + Space + expStr;
                    break;
                case XplUnaryoperators_enum.ONECOMP: //Complemento a Uno '~'
                    tempStr = "~" + expStr;
                    break;
                case XplUnaryoperators_enum.PREDEC: //Decremento prefijo '--e'
                    tempStr = "--" + expStr;
                    break;
                case XplUnaryoperators_enum.PREINC: //Incremento prefijo '++e'
                    tempStr = "++" + expStr;
                    break;
                case XplUnaryoperators_enum.RAOF: //Reference AddressOf '&&'
                    tempStr = "referenceAddressOf(" + expStr + ")";
                    break;
                case XplUnaryoperators_enum.SIZEOF:
                    tempStr = "sizeof(" + expStr + ")";
                    break;
                case XplUnaryoperators_enum.TYPEOF:
                    tempStr = "typeof(" + expStr + ")";
                    break;
            }

            if (_optimizeParenthesis)
            {
                if (PythonTools.requireParenthesis(uopExp)) tempStr = "(" + tempStr + ")";
            }
            else tempStr = "(" + tempStr + ")";
            return tempStr;
        }

        protected override string renderFunctionCallExp(LayerD.CodeDOM.XplFunctioncall fcallExp, string leftExpStr, string argsStr, bool useBrackets, ExtendedZOEProcessor.EZOEContext context)
        {
            XplFunctionBody bk = fcallExp.get_bk();
            string bkstr = String.Empty;

            if (bk != null)
            {
                // TODO
            }

            if (!useBrackets)
            {
                return leftExpStr + "(" + argsStr + ")" + bkstr;
            }
            else
            {
                return leftExpStr + "[" + argsStr + "]" + bkstr;
            }
        }

        protected override string renderCastExp(LayerD.CodeDOM.XplCastexpression castExp, string typeStr, string castExpStr, LayerD.CodeDOM.XplCasttype_enum castType, ExtendedZOEProcessor.EZOEContext context)
        {
            return castExpStr;
        }

        protected override string renderNewExp(LayerD.CodeDOM.XplNewExpression newExp, string typeStr, string initializerStr, ExtendedZOEProcessor.EZOEContext context)
        {
            if (!String.IsNullOrEmpty(newExp.get_type().get_typeStr()))
            {
                typeStr = PythonTools.processUserTypeName(newExp.get_type().get_typeStr());
            }

            // char[]
            if (newExp.get_type().get_isarray() && PythonTools.IsNativeTypeSuitableForByteArray(newExp.get_type().get_dt().get_typename()))
            {
                if (newExp.get_type().get_ae() != null)
                {
                    return "bytearray(" + processExpression(newExp.get_type().get_ae(), context) + ")";
                }
            }

            // sanity check
            if (initializerStr != String.Empty && initializerStr[0] != '(' && initializerStr[0] != '[' && initializerStr[0] != '{')
            {
                initializerStr = String.Empty;
            }

            if (initializerStr == String.Empty && newExp.get_type().get_typename() != String.Empty && newExp.get_type().get_typename()[0] != '$')
            {
                return typeStr + "()";
            }
            else if (typeStr == "Object")
            {
                return initializerStr;
            }
            else if (typeStr == "Array" && initializerStr[0] == '(')
            {
                return "[" + initializerStr.Substring(1, initializerStr.Length - 2) + "]";
            }
            else
            {
                return (String.IsNullOrEmpty(initializerStr) || initializerStr[0] != '[') ? (typeStr + initializerStr) : initializerStr;
            }
        }

        protected override string renderSizeofExp(XplType xplType, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            return "sizeof( " + typeStr + " )";
        }

        protected override void renderDocumentation(LayerD.CodeDOM.XplDocumentation documentation, ExtendedZOEProcessor.EZOEContext context)
        {
            if (_removeComments) return;

            if (documentation != null)
            {
                if (documentation.get_Parent().get_Parent().IsA(CodeDOMTypes.XplDocumentBody) ||
                    documentation.get_Parent().IsA(CodeDOMTypes.XplClass))
                {
                    CheckBuffer(documentation);
                }

                string docStr = documentation.get_short();
                string ldsrcStr = documentation.get_ldsrc();
                int minLine = 0, maxLine = 0;
                string currentFile = String.Empty;

                if (!String.IsNullOrEmpty(ldsrcStr))
                {
                    PythonTools.ParseZoeSourceInfo(ldsrcStr, ref minLine, ref  maxLine, ref currentFile);
                    if (_buffer.GetCurrentBufferFileName() != Path.GetFileNameWithoutExtension(currentFile)) return;
                }

                
                if (!String.IsNullOrEmpty(docStr))
                {
                    string[] comments = docStr.Split('\n');
                    for (int n = 0; n < comments.Length; n++)
                    {
                        string comment = comments[n].Replace('\r', ' ').Trim();
                        if (comment != String.Empty)
                        {
                            Write("# " + comment);
                            WriteNewLine();
                        }
                    }
                }
            }
        }

        protected override void renderUnrecognizedNode(LayerD.CodeDOM.XplNode node, ExtendedZOEProcessor.EZOEContext context)
        {
            if (context == EZOEContext.DocumentBody && node.get_ElementName() == "Using")
            {
                // Reconozco un "Using", no hago nada.
            }
            else
            {
                if (node != null) AddWarning("renderUnrecognizedNode: node not recognized. DATA: Name:'" + node.get_ElementName() + "' Type:'" + node.get_TypeName() + "' Context:'" + context.ToString() + "'.");
            }            
        }

    }
}
