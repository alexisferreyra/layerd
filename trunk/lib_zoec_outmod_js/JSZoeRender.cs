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
using LayerD.CodeDOM;
using System.Globalization;
using System.IO;

namespace LayerD.OutputModules
{
    class JSZoeRender : ExtendedZOEProcessor, IEZOERender
    {
        private class SpacesPrinter
        {
            const int RESETED = -1;
            JSZoeRender _renderModule;
            int _currentLine = RESETED;
            
            public SpacesPrinter(JSZoeRender renderModule)
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
        List<String> _currentClassStaticMembers;
        
        #region Tools
        void RenderComments(XplNode node)
        {
            if (_removeComments) return;

            if (node.get_doc() != null && node.get_doc() != String.Empty)
            {
                renderCommentFromString(node.get_doc(), false);
            }
        }

        private void PrepareOutput()
        {
            _buffer = new RenderBuffer(_outputPath);
        }

        private void CloseOutput()
        {
            _buffer.Close();
        }

        private void RenderMultipleFiles()
        {
            _buffer.ProgramName = Path.GetFileNameWithoutExtension(this._outputFileName);
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
            _buffer.ChangeBufferIfNeeded(node);
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

        public JSZoeRender()
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
                    Dictionary<string,string> arguments = JsTools.ParseRenderArguments(renderArguments.Trim().ToLowerInvariant());
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
            return JsTools.GetTypeStringFromInnerTypeName(xplType);
        }

        protected override string renderTypeOfExp(LayerD.CodeDOM.XplType typeofExpNode, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            return JsTools.GetTypeStringFromInnerTypeName(typeofExpNode);
        }

        protected override string renderIsExp(LayerD.CodeDOM.XplCastexpression xplExpression, string expStr, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            typeStr = JsTools.GetTypeStringFromInnerTypeName(xplExpression.get_type());

            return expStr + Space + Keywords.InstanceOf + Space + typeStr;
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
            _buffer.AddImportDirective(importDirective);
        }

        protected override void renderBeginNamespace(string namespaceName, LayerD.CodeDOM.XplNamespace namespaceDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            // Do nothing. Namespaces are processed in RenderBuffer
        }

        protected override void renderEndNamespace(string namespaceName, LayerD.CodeDOM.XplNamespace namespaceDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            
        }

        void WriteCommentLine(string comment)
        {
            if (_removeComments) return;
            WriteLine("//" + comment);
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

            _currentClassStaticMembers = new List<string>();
            bool isAllStaticMembers = JsTools.IsAllStaticMembersClass(classDecl);

            string fullDeclName = JsTools.GetFullDeclarationName(classDecl);
            if (classDecl.get_extension())
            {
                if (!isAllStaticMembers)
                {
                    WriteLine("// Extension to class \"" + fullDeclName + "\"");
                    WriteLine("// To extend a class add methods to .prototype property");
                }
                return;
            }

            string baseClassStr = JsTools.GetBaseName(classDecl);
            if (!String.IsNullOrEmpty(baseClassStr))
            {
                JsTools.WriteForwardDeclarations(fullDeclName, baseClassStr, classDecl, _buffer);
                baseClassStr = ", " + baseClassStr;
            }
            Write(fullDeclName + " = Class.$define(\"" + fullDeclName + "\"" + baseClassStr + ", {");

            if (isAllStaticMembers)
            {
                WriteLine("});");
                WriteNewLine();
                return;
            }

            WriteNewLine();
            IncreaseTabulation();

            // render constructors
            XplNodeList list = classDecl.get_FunctionNodeList();
            int count = 0;
            foreach (XplFunction function in list)
            {
                if (function.get_name() == className && function.get_storage() != XplVarstorage_enum.EXTERN)
                {
                    count++;
                    renderConstructorCommonCode(classType, implementsStr, inheritsStr, classDecl, fullDeclName, function, baseClassStr);
                }
            }

            if (count == 0)
            {
                // render automatic default constructor
                renderConstructorCommonCode(classType, implementsStr, inheritsStr, classDecl, fullDeclName, null, baseClassStr);
            }

            renderInternalCopyMethod( classDecl );

        }

        private void renderInternalCopyMethod(XplClass classDecl)
        {
            XplNodeList fields = classDecl.get_FieldNodeList();
            if (fields.GetLength() == 0 || JsTools.AllFieldsAreStatic(fields)) return;

            string functionName = "$copy";
            string fullDeclName = JsTools.GetFullDeclarationName(classDecl);

            // declaration line 
            Write(functionName + ": ");
            Write(Keywords.Function);
            Write("() {");
            WriteNewLine();
            IncreaseTabulation();

            // body
            Write("var copyObject = new " + fullDeclName + "();");
            WriteNewLine();

            foreach (XplField field in fields)
            {
                if (field.get_storage() == XplVarstorage_enum.AUTO)
                {
                    string fieldName = JsTools.GetValidIdentifier(field.get_name(), false);
                    Write("copyObject." + fieldName + " = " + Keywords.This + "." + fieldName);

                    if(JsTools.IsCustomValueType(field.get_type())) Write(".$copy();");
                    else Write(";");

                    WriteNewLine();
                }
            }

            // TODO : will not work for classes that inherits from other things
            // to support only C structs or enums where you cant inherit it is ok
            // but it will be an error for Zoe classes that has bases which define fields
            Write("return copyObject;");
            WriteNewLine();

            // close body
            DecreaseTabulation();
            Write("},");
            WriteNewLine();
            WriteNewLine();
        }

        private void renderConstructorCommonCode(ExtendedZOEProcessor.EZOEClassType classType, string implementsStr, string inheritsStr, LayerD.CodeDOM.XplClass classDecl, string fullDeclName, XplFunction function, string baseClassStr)
        {
            if (classDecl.get_isenum() || classDecl.get_isinterface()) return;

            WriteClosureAnnotationForClass(classType, inheritsStr, implementsStr, function != null && function.get_Parameters() != null ? function.get_Parameters().Children() : null);

            string parametersStr = function != null && function.get_Parameters() != null ? processParameters(function.get_Parameters(), function, EZOEContext.FunctionDecl) : String.Empty;

            Write("__init__: " + Keywords.Function + "(" + parametersStr + ") {");
            WriteNewLine();
            IncreaseTabulation();

            // render instance fields
            renderInstanceFields(classDecl.get_FieldNodeList());

            // call to base constructor
            if (baseClassStr != String.Empty)
            {
                WriteLine("this.$super(" + parametersStr + ");");
            }

            if (function != null && function.get_FunctionBody() != null)
            {
                if (!String.IsNullOrEmpty(parametersStr))
                {
                    WriteLine("if (arguments.length > 0)");
                    WriteLine("{");
                    IncreaseTabulation();
                }

                // render constructor body
                processFunctionBodyNodes(function.get_FunctionBody());
                // remove function body to avoid duplicated render
                function.set_FunctionBody(null);

                if (!String.IsNullOrEmpty(parametersStr))
                {
                    DecreaseTabulation();
                    WriteLine("}");
                }
            }

            DecreaseTabulation();
            WriteLine("},");
            WriteNewLine();
        }

        private void WriteClosureAnnotationForClass(EZOEClassType classType, string inheritsStr, string implementsStr, XplNodeList parameters)
        {
            if (!this._generateClosureTypeAnnotations) return;
            WriteLine("/**");
            if (classType == EZOEClassType.Class || classType == EZOEClassType.Struct || classType == EZOEClassType.Union)
            {
                WriteLine(" * @constructor");
            }
            else if (classType == EZOEClassType.Enum)
            {
                WriteLine(" * @enum {number}");
            }
            else if (classType == EZOEClassType.Interface)
            {
                WriteLine(" * @interface");
            }

            if (!String.IsNullOrEmpty(inheritsStr) && inheritsStr != "zoe.lang.Object" && inheritsStr != "Object")
            {
                WriteLine(" * @extends " + inheritsStr);
            }

            if (!String.IsNullOrEmpty(implementsStr))
            {
                string[] parts = implementsStr.Split(',');
                foreach (string implement in parts)
                {
                    WriteLine(" * @implements {" + implement + "}");
                }
            }
            if (parameters != null) WriteClosureAnnotationForParameters(parameters);
            WriteLine(" */");

        }

        private void renderInstanceFields(XplNodeList fields)
        {
            if (fields == null || fields.GetLength() == 0) return;

            WriteCommentLine(" instance fields");

            foreach (XplField field in fields)
            {
                if (field.get_storage() == XplVarstorage_enum.AUTO)
                {
                    string fieldName = JsTools.GetValidIdentifier(field.get_name(), false);
                    string initializerStr = processInitializer(field.get_i(), EZOEContext.ClassBody);
                    if (String.IsNullOrEmpty(initializerStr))
                    {
                        initializerStr = JsTools.GetDefaultInitForFieldDecl(field.get_type());
                    }
                    WriteClosureAnnotationForVar(field.get_type());
                    WriteLine(Keywords.This + "." + fieldName + " = " + initializerStr + ";");
                }
            }
        }

        protected override void renderEndClass(ExtendedZOEProcessor.EZOEClassType classType, string className, LayerD.CodeDOM.XplClass classDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            if (_isExternalClass > 0)
            {
                if (classDecl.get_external()) _isExternalClass--;
                return;
            }

            DecreaseTabulation();

            if (!classDecl.get_extension() && !JsTools.IsAllStaticMembersClass(classDecl))
            {
                WriteLine("});");
                WriteNewLine();
            }

            // render static members
            foreach (string member in _currentClassStaticMembers)
            {
                Write(member);
            }
            WriteNewLine();

            _currentClassStaticMembers.Clear();
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
            if (functionName == currentClass.get_name()) return;
            
            bool isStatic = functionStorage == XplVarstorage_enum.STATIC;
            bool isExtension = functionDecl.CurrentClass.get_extension();

            if (isStatic || isExtension) DecreaseTabulation();
            if (isStatic) _buffer.StartBuffering();

            string className = JsTools.GetValidIdentifier(currentClass.get_name(), false);
            string fullDeclName = JsTools.GetFullDeclarationName(currentClass);
            functionName = JsTools.GetValidIdentifier(functionName, false);
            
            WriteClosureAnnotationForFunction(functionDecl, access);

            // TODO : render all functions as public for now
            if (isStatic)
            {
                if (functionName == "main" && access == XplAccesstype_enum.PUBLIC && JsTools.IsObjCDummyGlobalClass(functionDecl.CurrentClass) || 
                    JsTools.IsZoeMainFunction(functionDecl))
                {
                    _buffer.MainFunctionName = fullDeclName + "." + functionName;
                }
                Write(fullDeclName + ".");
                Write(functionName + " = ");
            }
            else
            {
                if (isExtension)
                {
                    Write(fullDeclName + "." + Keywords.Prototype + "." + functionName + " = ");
                }
                else
                {
                    Write(functionName + ": ");
                }
            }

            Write(Keywords.Function);
            // parameters
            Write("(" + parametersStr + ") {");

            if (!currentClass.get_isinterface())
            {
                WriteNewLine();
                IncreaseTabulation();
            }

            renderCopyByValueParameters(functionDecl);

            if (!_buffer.IsBuffering())
            {
                _buffer.ClearThatRendered();
                _buffer.ClearThisUsedInsideClosureFlag();
            }
        }

        private void renderCopyByValueParameters(XplFunction functionDecl)
        {
            if(functionDecl.get_Parameters() == null) return;

            XplNodeList parameters = functionDecl.get_Parameters().Children();
            
            foreach(XplParameter parameter in parameters)
            {
                if(JsTools.IsCustomValueType(parameter.get_type()))
                {
                    string parameterName = JsTools.GetValidIdentifier(parameter.get_name(), false);

                    Write(parameterName + " = " + parameterName + ".$copy();");
                    WriteNewLine();
                }
            }
        }

        private void WriteClosureAnnotationForFunction(XplFunction functionDecl, XplAccesstype_enum access)
        {
            if (!this._generateClosureTypeAnnotations) return;

            WriteLine("/**");
            // parameters
            XplNodeList parameters = functionDecl.get_Parameters() != null ? functionDecl.get_Parameters().Children() : null;
            WriteClosureAnnotationForParameters(parameters);
            // return type
            XplType returnType = functionDecl.get_ReturnType();
            if (returnType != null && returnType.get_typeStr() != "$NONE$" && returnType.get_typeStr() != "$VOID$")
            {
                WriteLine(" * @return {" + JsTools.GetClosureTypeAnnotation(returnType) + "}");
            }
            WriteLine(" */");
        }

        private void WriteClosureAnnotationForParameters(XplNodeList parameters)
        {
            if (parameters != null)
            {
                foreach (XplParameter parameter in parameters)
                {
                    string parameterName = JsTools.GetValidIdentifier(parameter.get_name(), false);
                    string parameterType = JsTools.GetClosureTypeAnnotation(parameter.get_type());
                    WriteLine(" * @param {" + (parameter.get_params() ? "..." : String.Empty) + parameterType + "} " + parameterName);
                }
            }
        }

        private void WriteClosureAnnotationForVar(XplType varType)
        {
            if (!this._generateClosureTypeAnnotations) return;
            WriteLine("/** @type {" + JsTools.GetClosureTypeAnnotation(varType) + "} */");
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
            XplClass currentClass = functionDecl.CurrentClass;
            if(functionName == currentClass.get_name()) return;

            bool isInterface = currentClass.get_isinterface();
            bool isStatic = functionStorage == XplVarstorage_enum.STATIC;
            bool isExtension = currentClass.get_extension();

            if (!isAbstract && !(functionDecl.get_Parent().get_TypeName() == CodeDOMTypes.XplClass && isInterface))
            {
                string className = JsTools.GetValidIdentifier(currentClass.get_name(), false);
                functionName = JsTools.GetValidIdentifier(functionName, false);

                DecreaseTabulation();
                Write("}");
                if (isStatic || isExtension) Write(";");
                else Write(",");

                WriteNewLine();
                WriteNewLine();
            }

            // close methods for interface
            if (isInterface) WriteLine("},");

            if (isStatic && context == EZOEContext.ClassBody)
            {
                _currentClassStaticMembers.Add(_buffer.StopBuffering());
            }

            if(isStatic && !isExtension) IncreaseTabulation();
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

            string className = JsTools.GetValidIdentifier(fieldDecl.CurrentClass.get_name(), false);
            string fullDeclName = JsTools.GetFullDeclarationName(fieldDecl.CurrentClass);

            // TODO : all fields are public for now
            if (isStatic)
            {
                _buffer.DecreaseTabulation();
                _buffer.StartBuffering();

                WriteClosureAnnotationForVar(fieldDecl.get_type());
                string validFieldName = JsTools.GetValidIdentifier(fieldName, false);
                // render:
                // NamespaceName.ClassName.FieldName = 0
                if (String.IsNullOrEmpty(initializerStr))
                {
                    Write(fullDeclName + ".");
                    Write(validFieldName);
                    WriteLine(" = " + JsTools.GetDefaultInitForFieldDecl(fieldDecl.get_type()) + ";");
                }
                else
                {
                    if (JsTools.StaticFieldRequiresEncapsulation(fieldDecl))
                    {
                        WriteLine("Object.defineProperty(" + fullDeclName + ", \"" + validFieldName + "\", ");
                        if (fieldDecl.get_type().get_const())
                        {
                            IncreaseTabulation();
                            WriteLine("{ get : function(){ return " + initializerStr + "; } });");
                            DecreaseTabulation();
                        }
                        else
                        {
                            IncreaseTabulation();
                            WriteLine("{ get : function(){");
                            IncreaseTabulation();
                            WriteLine("if(" + fullDeclName + ".__" + validFieldName + " === undefined) " + fullDeclName + ".__" + validFieldName + " = " + initializerStr + ";");
                            IncreaseTabulation();
                            WriteLine("return " + fullDeclName + ".__" + validFieldName + ";");
                            DecreaseTabulation();
                            WriteLine("},");
                            WriteLine("set : function(newValue){ " + fullDeclName + ".__" + validFieldName + " = newValue; }");
                            DecreaseTabulation();
                            WriteLine("});");
                            DecreaseTabulation();
                        }
                    }
                    else
                    {
                        Write(fullDeclName + ".");
                        Write(validFieldName);
                        WriteLine(" = " + initializerStr + ";");
                    }
                }

                WriteNewLine();
                _currentClassStaticMembers.Add(_buffer.StopBuffering());
                IncreaseTabulation();
            }
            else
            {
                // it's rendered inside render Begin Class
                return;
            }
        }

        protected override void renderBeginParameters(LayerD.CodeDOM.XplParameters parametersDecl, int maxParameter, LayerD.CodeDOM.XplFunction functionDecl, ExtendedZOEProcessor.EZOEContext context)
        {
            _maxParameter = maxParameter;
        }

        protected override string renderParameter(LayerD.CodeDOM.XplParameter parameter, string parameterName, string typeStr, string initializerStr, LayerD.CodeDOM.XplParameterdirection_enum parameterDirection, int parameterNumber, bool isParams, bool isVolatile)
        {
            string retStr = String.Empty;

            parameterName = JsTools.GetValidIdentifier(parameterName, false);

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
                    return declareName;
                case EZOETypeContext.SizeofExp:
                    break;
                case EZOETypeContext.GettypeExp:
                    break;
                case EZOETypeContext.CastExp:
                    break;
                case EZOETypeContext.Expression:
                    return JsTools.ProcessUserTypeName(type.get_typename());
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
                return "{";
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
                return "}";
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
                WriteLine("{");
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

                var stmt = functionBody.get_Parent() as XplForStatement;
                if (stmt != null && JsTools.IsForeach(stmt))
                {
                    WriteLine("});");
                }
                else
                {
                    WriteLine("}");
                }

            }            
        }

        protected override void renderExpressionStatement(LayerD.CodeDOM.XplExpression expression, string expressionString, ExtendedZOEProcessor.EZOEContext context)
        {
            if (expressionString != String.Empty)
            {
                this._spacesPrinter.PrintSpace(expression);
                RenderComments(expression);
                WriteLine(expressionString + ";");
            }
        }

        protected override void renderThrow(LayerD.CodeDOM.XplExpression throwExpression, string expressionString, ExtendedZOEProcessor.EZOEContext context)
        {
            WriteLine(Keywords.Throw + Space + expressionString + ";");
        }

        protected override void renderReturn(LayerD.CodeDOM.XplExpression returnExpression, string expressionString, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(returnExpression);

            if (expressionString == String.Empty)
            {
                WriteLine(Keywords.Return + ";");
            }
            else
            {
                WriteLine(Keywords.Return + Space + expressionString + ";");
            }
        }

        protected override void renderLocalDeclarator(LayerD.CodeDOM.XplDeclarator decl, string varName, string typeStr, string initializerStr, bool isVolatile)
        {
            this._spacesPrinter.PrintSpace(decl);
            RenderComments(decl);

            if (decl.get_lddata().Equals(ObjectiveCFlags.StaticPC))
            {
                // TODO : implement static vars
            }

            WriteClosureAnnotationForVar(decl.get_type());

            Write(Keywords.Var + Space + JsTools.GetValidIdentifier(varName, false));

            // if there is initializer render it
            if (!String.IsNullOrEmpty(initializerStr) && decl.get_i() != null && decl.get_i().Children().FirstNode() != null)
            {
                if (decl.get_i().Children().FirstNode().get_ElementName() != "list" || initializerStr[0] != '(') Write(" = " + initializerStr);
                else Write(initializerStr);
            }
            else
            {
                initializerStr = JsTools.RenderValueTypesInitializer(decl.get_type());
                if(!String.IsNullOrEmpty(initializerStr)) Write(" = " + initializerStr);
            }
            WriteLine(";");
        }

        protected override void renderBeginSwitch(LayerD.CodeDOM.XplSwitchStatement switchSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(switchSta);

            WriteLine(Keywords.Switch + "(" + boolExpStr + ")");
            WriteLine("{");
            IncreaseTabulation();            
        }

        protected override void renderCaseLabel(LayerD.CodeDOM.XplCase caseNode, string caseExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(caseNode);

            if (_isOnCase) DecreaseTabulation();
            if (caseExpStr == String.Empty)
            {
                WriteLine(Keywords.Default + ":");
            }
            else
            {
                WriteLine(Keywords.Case + Space + caseExpStr + ":");
            }
            _isOnCase = true;
            IncreaseTabulation();
        }

        protected override void renderEndSwitch(LayerD.CodeDOM.XplSwitchStatement switchSta, ExtendedZOEProcessor.EZOEContext context)
        {
            if (_isOnCase) DecreaseTabulation();
            _isOnCase = false;
            DecreaseTabulation();
            Write("}");
            WriteNewLine();
        }

        protected override void renderIfStatement(LayerD.CodeDOM.XplIfStatement ifSta, string boolExp, bool isElse, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(ifSta);

            if (!isElse)
            {
                Write(Keywords.If + Space + "(" + boolExp + ")");
            }
            else
            {
                Write(Keywords.Else + Space + Keywords.If + Space + "(" + boolExp + ")");
            }
        }

        protected override void renderElseStatement(LayerD.CodeDOM.XplIfStatement ifSta, LayerD.CodeDOM.XplFunctionBody elseBody, ExtendedZOEProcessor.EZOEContext context)
        {
            if (elseBody != null) Write(Keywords.Else + Space);
        }

        protected override void renderForStatement(LayerD.CodeDOM.XplForStatement forSta, string initStr, string boolExpStr, string updateStr, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(forSta);

            if (JsTools.IsForeach(forSta))
            {
                if (JsTools.IsJSArray(forSta.get_condition().get_typeStr()))
                {
                    Write(boolExpStr + ".forEach( " + Keywords.Function + "(" + initStr + ")");
                }
                else
                {
                    Write("Object.keys(" + boolExpStr + ").forEach( " + Keywords.Function + "(" + initStr + ")");
                }
            }
            else
            {
                Write(Keywords.For + Space + "(" + initStr + "; " + boolExpStr + "; " + updateStr + ")");
            }

        }

        protected override string renderForDeclaration(LayerD.CodeDOM.XplDeclaratorlist decls, ExtendedZOEProcessor.EZOEContext context)
        {
            XplNodeList listaDeclaraciones = decls.Children();
            string varName = String.Empty, initStr = String.Empty, typeStr = String.Empty, backTypeStr = String.Empty;
            string retStr = JsTools.IsForeach(decls.get_Parent().get_Parent() as XplForStatement) ? String.Empty : Keywords.Var;

            // for(int a = 0, d, f;; ....
            for (int n = 0; n < listaDeclaraciones.GetLength(); n++)
            {
                XplDeclarator nodo = (XplDeclarator)listaDeclaraciones.GetNodeAt(n);
                varName = nodo.get_name();
                initStr = processInitializer(nodo.get_i(), EZOEContext.Statement);
                typeStr = renderType(nodo.get_type(), String.Empty, EZOETypeContext.ForVarDecl, EZOEContext.Statement);
                if (n == 0)
                {
                    backTypeStr = typeStr;
                    retStr += typeStr;
                }
                else
                {
                    if (typeStr != backTypeStr) //Error
                        AddError("ERROR: tipo inesperado en declaración de variables de bloque for.");
                }
                // Agrego el nombre de la variable
                retStr += " " + JsTools.GetValidIdentifier(varName, false);
                // Agrego el inicializador
                if (initStr != String.Empty)
                {
                    if (nodo.get_i().Children().FirstNode().get_ElementName() != "list")
                    {
                        retStr += " = " + initStr;
                    }
                    else
                    {
                        retStr += initStr;
                    }
                }
                // Agrego la coma
                if (n != listaDeclaraciones.GetLength() - 1)
                {
                    retStr += ", ";
                }
            }
            return retStr.Trim();
        }

        protected override void renderWhileStatement(LayerD.CodeDOM.XplDowhileStatement doSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(doSta);

            Write(Keywords.While + Space + "(" + boolExpStr + ")");
        }

        protected override void renderBeginDoStatement(LayerD.CodeDOM.XplDowhileStatement doSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(doSta);

            Write(Keywords.Do + Space);
        }

        protected override void renderEndDoStatement(LayerD.CodeDOM.XplDowhileStatement doSta, string boolExpStr, ExtendedZOEProcessor.EZOEContext context)
        {
            WriteLine(Keywords.While + Space + "(" + boolExpStr + ");");
        }

        protected override void renderBeginTry(LayerD.CodeDOM.XplTryStatement trySta, ExtendedZOEProcessor.EZOEContext context)
        {
            this._spacesPrinter.PrintSpace(trySta);

            Write(Keywords.Try);
        }

        protected override void renderEndTry(LayerD.CodeDOM.XplTryStatement trySta, ExtendedZOEProcessor.EZOEContext context)
        {
            WriteNewLine();            
        }

        protected override void renderCatchStatement(LayerD.CodeDOM.XplCatchStatement catchSta, string declExp, ExtendedZOEProcessor.EZOEContext context)
        {
            // TODO : add runtime support for multiple catches
            // that requires to save type information in objects
            // JS type information is not enought to decide which 
            // catch is the correct one to choose
            Write(Keywords.Catch + Space + "(" + declExp + ")");
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

            if (targetPlatform.ToUpperInvariant().Contains("JAVASCRIPT"))
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
                if (_buffer.IsInsideClosure())
                {
                    _buffer.ThisUsedInsideClosureFlag(); 
                    return "$that";
                }
                return name;
            }
            else if (name == "base")
            {
                if (node.get_Parent().get_Parent().IsA(CodeDOMTypes.XplFunctioncall) || node.get_Parent().get_Parent().get_Parent().get_Parent().IsA(CodeDOMTypes.XplFunctioncall))
                {
                    if (_buffer.IsInsideClosure())
                    {
                        _buffer.ThisUsedInsideClosureFlag();
                        return "$that.$super()";
                    }
                    return "this.$super()";
                }
                return "this";
            }
            else if (name == "js.global.@this" && node.CurrentExpression != null && node.CurrentExpression.get_targetClass() == "js.global")
            {
                // closure this
                return "this";
            }
            else
            {
                return JsTools.ProcessUserTypeName(name);
            }
        }

        protected override string renderLiteral(LayerD.CodeDOM.XplLiteral litNode, string litStr, ExtendedZOEProcessor.EZOEContext context)
        {
            string tempStr;

            switch (litNode.get_type())
            {
                case XplLiteraltype_enum.NULL:
                    tempStr = "null";
                    break;
                case XplLiteraltype_enum.ASCIICHAR:
                case XplLiteraltype_enum.CHAR:
                    tempStr = "'" + litStr + "'";
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
            return Keywords.Delete + Space + expStr;
        }

        protected override string renderOnpointerExp(LayerD.CodeDOM.XplExpression onpointerExp, string expStr, ExtendedZOEProcessor.EZOEContext context)
        {
            return String.Empty;
        }

        protected override string renderAssingExp(LayerD.CodeDOM.XplAssing assing, string leftExpStr, string rightExpStr, LayerD.CodeDOM.XplAssingop_enum operation, ExtendedZOEProcessor.EZOEContext context)
        {
            if ((int)Precedences.AssingExp == JsTools.GetExpressionPrecedence(assing.get_l()))
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

            if (JsTools.IsCustomValueType(assing.get_r().get_typeStr()) && !assing.get_r().get_Content().IsA(CodeDOMTypes.XplFunctioncall))
            {
                // requires copy
                tempStr += ".$copy()";
            }

            if (JsTools.RequireParenthesis(assing)) tempStr = "(" + tempStr + ")";

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
                    if (_optimizeParenthesis && JsTools.GetOperatorPrecedence(op) > JsTools.GetExpressionPrecedence(bopExp.get_l()))
                    {
                        leftExpStr = "(" + leftExpStr + ")";
                    }
                    break;
                default:
                    if (_optimizeParenthesis && JsTools.GetOperatorPrecedence(op) == JsTools.GetExpressionPrecedence(bopExp.get_r()))
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
                    tempStr = leftExpStr + " && " + rightExpStr;
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
                    tempStr = leftExpStr + " === " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.EXP: //Exponente
                    AddWarning("Operador binario 'EXP' (exponente) no soportado por el Modulo de Salida. Usando '*' en su lugar.");
                    tempStr = leftExpStr + " * " + rightExpStr;
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
                    tempStr = leftExpStr + " !== " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.OR: //O Logico
                    tempStr = leftExpStr + " || " + rightExpStr;
                    break;
                case XplBinaryoperators_enum.PM: //Pointer Member Access "->"
                    AddWarning("Pointer member access is not supported by JavaScript module.");
                    // check if left exp is new
                    if (bopExp.get_l().get_Content().IsA(CodeDOMTypes.XplNewExpression))
                    {
                        tempStr = "(" + leftExpStr + ")." + rightExpStr;
                    }
                    tempStr = leftExpStr + "." + rightExpStr; flag = true;
                    break;
                case XplBinaryoperators_enum.PMP: //Pointer To Member Pointer Access "->*"
                    AddWarning("Pointer to member pointer access is not supported by JavaScript module.");
                    tempStr = leftExpStr + "." + rightExpStr; flag = true;
                    break;
                case XplBinaryoperators_enum.RM: //Reservado para Acceso a miembros
                    AddWarning("Operador binario 'RM' (reservado para acceso a miembros) no soportado por el Modulo de Salida. Usando '.' en su lugar.");
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
                if (!flag && JsTools.RequireParenthesis(bopExp)) tempStr = "(" + tempStr + ")";
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
                return "((" + o1ExpStr + ") ? (" + o2ExpStr + ") : (" + o3ExpStr + "))";
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
                    tempStr = JsTools.GetPointerObject(expStr);
                    break;
                case XplUnaryoperators_enum.DEC: //Decremento postfijo 'e--'
                    tempStr = expStr + "--";
                    break;
                case XplUnaryoperators_enum.INC: //Incremento postfijo 'e++'
                    tempStr = expStr + "++";
                    break;
                case XplUnaryoperators_enum.IND: //Indireccion de puntero '*'
                    tempStr = expStr + ".value";
                    break;
                case XplUnaryoperators_enum.MIN: //Negativo '-'
                    tempStr = "-" + expStr;
                    break;
                case XplUnaryoperators_enum.NOT: //Negado logico '!'
                    tempStr = "!" + expStr;
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
                    tempStr = expStr + ".value";
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
                if (JsTools.RequireParenthesis(uopExp)) tempStr = "(" + tempStr + ")";
            }
            else tempStr = "(" + tempStr + ")";
            return tempStr;
        }

        protected override string renderFunctionCallExp(LayerD.CodeDOM.XplFunctioncall fcallExp, string leftExpStr, string argsStr, bool useBrackets, ExtendedZOEProcessor.EZOEContext context)
        {
            const string THIS_SUPER = "this.$super().";
            const string THAT_SUPER = "$that.$super().";

            var currentFunction = fcallExp.CurrentFunction;
            string currentFunctioName = currentFunction != null ? currentFunction.get_name() : String.Empty;
            string replaceSuperStr = null;
            string targetName = null;

            if (leftExpStr.StartsWith(THIS_SUPER))
            {
                replaceSuperStr = "this";
                targetName = leftExpStr.Substring(THIS_SUPER.Length);
            }
            if (leftExpStr.StartsWith(THAT_SUPER))
            {
                replaceSuperStr = "$that";
                targetName = leftExpStr.Substring(THAT_SUPER.Length);
            }

            string targetClass = fcallExp.get_targetClass();
            string targetMember = fcallExp.get_targetMember();

            if (replaceSuperStr != null)
            {
                if (currentFunctioName == targetName)
                {
                    leftExpStr = replaceSuperStr + ".$super";
                }
                else
                {
                    if (String.IsNullOrEmpty(targetClass))
                    {
                        // fallback to this object if there is an error
                        leftExpStr = "this." + Keywords.Prototype + "." + targetName + ".call";
                    }
                    else
                    {
                        leftExpStr = JsTools.ProcessUserTypeName(targetClass) + "." + Keywords.Prototype + "." + targetName + ".call";
                    }
                    argsStr = String.IsNullOrEmpty(argsStr) ? replaceSuperStr : replaceSuperStr + ", " + argsStr;
                }
            }

            if (targetClass == "js.global" && targetMember.StartsWith("S#", StringComparison.InvariantCulture))
            {
                // special $ function 
                // TODO : change this to use existing targetExternalName attribute
                leftExpStr = "$";
            }
            else if (targetClass == "js.global" && targetMember.StartsWith("typeof#", StringComparison.InvariantCulture))
            {
                leftExpStr = "typeof";
            }
            else if (targetClass == "js.global" && targetMember.StartsWith("F#", StringComparison.InvariantCulture))
            {
                // special function js::global::F (for closure literals)
                XplFunctionBody body = fcallExp.get_bk();
                if (body != null && body.Children().GetLength() == 1)
                {
                    XplNode innerExp = body.Children().FirstNode();
                    if (innerExp.IsA(CodeDOMTypes.XplExpression))
                    {
                        JsTools.DisableReplaceOfKeywords();
                        var blockLiteralString = processExpression((XplExpression)innerExp, context);
                        JsTools.EnableReplaceOfKeywords();
                        return blockLiteralString;
                    }
                }
            }
            else if (targetClass == "#intrinsic_closure#" && targetMember == "#IC_CALL#")
            {
                leftExpStr = Keywords.Function;
                argsStr = renderIntrinsicClosureParameters(fcallExp, context);
            }
            else if (targetClass == "js.Function" && targetMember.StartsWith("CALL#", StringComparison.InvariantCulture))
            {
                // special function js::Function::CALL (for () mimics)
                leftExpStr = leftExpStr.Substring(0, leftExpStr.Length - 5);
            }

            XplFunctionBody bk = fcallExp.get_bk();
            string bkstr = String.Empty;

            if (bk != null)
            {
                bool back = this._generateClosureTypeAnnotations;
                this._generateClosureTypeAnnotations = false;
                _buffer.StartBuffering();
                _buffer.BeginClosureBody();
                IncreaseTabulation();
                processFunctionBody(bk, context);
                DecreaseTabulation();
                Write("}");
                bkstr = " {\n" + _buffer.StopBuffering();
                _buffer.EndClosureBody();
                this._generateClosureTypeAnnotations = back;
                while (bkstr.EndsWith("\r", StringComparison.InvariantCulture) || bkstr.EndsWith("\n", StringComparison.InvariantCulture)) bkstr = bkstr.Remove(bkstr.Length - 1, 1);
            }

            // check if we need to add "new" when we are constructing a type by value from Zoe point of view
            if (!String.IsNullOrEmpty(targetClass) && !String.IsNullOrEmpty(targetMember))
            {
                if (targetMember != "?") targetMember = targetMember.Substring(0, targetMember.IndexOf('#'));
                if (targetClass.EndsWith("." + targetMember))
                {
                    leftExpStr = Keywords.New + Space + leftExpStr;
                }
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

        private string renderIntrinsicClosureParameters(XplFunctioncall fcallExp, EZOEContext context)
        {
            string retStr = String.Empty;

            var args = fcallExp.get_args();
            if (args != null)
            {
                int current = 0;
                int max = args.Children().GetLength();
                foreach (XplExpression arg in args.Children())
                {
                    var content = arg.get_Content();
                    var simpleName = String.Empty;
                    if (content.IsA(CodeDOMTypes.XplNode))
                    {
                        simpleName = content.get_StringValue();
                    }
                    else if(content.IsA(CodeDOMTypes.XplCastexpression))
                    {
                        simpleName = ((XplCastexpression)content).get_e().get_Content().get_StringValue();
                        if (String.IsNullOrEmpty(simpleName)) simpleName = "__error_in_parameter_for_closure__";
                    }
                    retStr += renderSimpleName(content, simpleName, context);
                    current++;
                    if (current < max) retStr += ", ";
                }
            }

            return retStr;
        }

        protected override string renderCastExp(LayerD.CodeDOM.XplCastexpression castExp, string typeStr, string castExpStr, LayerD.CodeDOM.XplCasttype_enum castType, ExtendedZOEProcessor.EZOEContext context)
        {
            string typeAnnotation = _generateClosureTypeAnnotations ? JsTools.GetClosureTypeAnnotation(castExp.get_type(), true) : String.Empty;
            if (!String.IsNullOrEmpty(typeAnnotation))
            {
                typeAnnotation = "/** @type{" + typeAnnotation + "} */";
            }
            if (castExp.get_e().get_typeStr() == "$FLOAT$" || castExp.get_e().get_typeStr() == "$DOUBLE$")
            {
                if (JsTools.IsIntegerNativeType(castExp.get_type().get_typeStr()))
                {
                    castExpStr = JsTools.BuildTruncateExpression(castExpStr);
                }
            }

            return typeAnnotation + castExpStr;
        }

        protected override string renderNewExp(LayerD.CodeDOM.XplNewExpression newExp, string typeStr, string initializerStr, ExtendedZOEProcessor.EZOEContext context)
        {
            // sanity check
            if (initializerStr != String.Empty && initializerStr[0] != '(' && initializerStr[0] != '[' && initializerStr[0] != '{')
            {
                initializerStr = String.Empty;
            }

            if (initializerStr == String.Empty && newExp.get_type().get_typename() != String.Empty && newExp.get_type().get_typename()[0] != '$')
            {
                return Keywords.New + Space + typeStr + "()";
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
                return (String.IsNullOrEmpty(initializerStr) || initializerStr[0] != '[') ? (Keywords.New + Space + typeStr + initializerStr) : initializerStr;
            }
        }

        protected override string renderSizeofExp(XplType xplType, string typeStr, ExtendedZOEProcessor.EZOEContext eZOEContext)
        {
            return "sizeof( " + typeStr + " )";
        }

        protected override void renderDocumentation(LayerD.CodeDOM.XplDocumentation documentation, ExtendedZOEProcessor.EZOEContext context)
        {
            if (_removeComments) return;
            if (_isExternalClass > 0) return;
            this._spacesPrinter.PrintSpace(documentation);

            if (documentation != null)
            {
                if (documentation.get_Parent().get_Parent().IsA(CodeDOMTypes.XplDocumentBody) ||
                    documentation.get_Parent().IsA(CodeDOMTypes.XplClass) && JsTools.IsObjCDummyGlobalClass(documentation.get_Parent() as XplClass))
                {
                    CheckBuffer(documentation);
                }

                string docStr = documentation.get_short();
                string ldsrcStr = documentation.get_ldsrc();
                int minLine = 0, maxLine = 0;
                string currentFile = String.Empty;

                if (!String.IsNullOrEmpty(ldsrcStr))
                {
                    JsTools.ParseZoeSourceInfo(ldsrcStr, ref minLine, ref  maxLine, ref currentFile);
                    if (currentFile != null && _buffer != null && _buffer.GetCurrentBufferFileName()!=null && !_buffer.GetCurrentBufferFileName().Equals(Path.GetFileNameWithoutExtension(currentFile), StringComparison.InvariantCultureIgnoreCase)) return;
                }

                
                if (!String.IsNullOrEmpty(docStr))
                {
                    bool mainComment = false;
                    switch (documentation.get_Parent().get_TypeName())
                    {
                        case CodeDOMTypes.XplDocumentBody:
                        case CodeDOMTypes.XplNamespace:
                        case CodeDOMTypes.XplClass:
                            mainComment = true;
                            break;
                    }
                    renderCommentFromString(docStr, mainComment);
                }
            }
        }

        private void renderCommentFromString(string docStr, bool isMainComment)
        {
            string[] comments = docStr.Split('\n');
            for (int n = 0; n < comments.Length; n++)
            {
                string comment = comments[n].Trim('\r');
                if (comment != String.Empty)
                {
                    if (isMainComment) Write("//" + comment);
                    else Write("//" + comment);
                    WriteNewLine();
                }
                else
                {
                    if (n < comments.Length - 1) WriteLine("//");
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
