/*******************************************************************************
* Copyright (c) 2011-2012 Intel Corporation.
* All rights reserved. This program and the accompanying materials
* are made available under the terms of the Eclipse Public License v1.0
* which accompanies this distribution, and is available at
* http://www.eclipse.org/legal/epl-v10.html
*
* Contributors:
*       Julieta Alvarez (Intel Corporation)
*       Alexis Ferreyra (Intel Corporation)
*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using LayerD.CodeDOM;
using System.IO;

namespace LayerD.OutputModules
{
    class CompilationUnit
    {
        class Section
        {
            private string _namespace;

            public XplNode ZoeNode;
            public int FirstLineHeader;
            public int FirstLineSource;

            public string Namespace
            {
                get
                {
                    if (_namespace == null && ZoeNode != null)
                    {
                        var ns = ZoeNode.CurrentNamespace;

                        if (ns != null)
                        {
                            _namespace = ns.get_name();
                        }
                    }
                    return _namespace;
                }
            }
        }

        class TypeUsage
        {
            public string TypeStr;
            public bool UseInHeaderRequireFullType;
            public bool UseInSourceRequireFullType;
            public bool UseInHeader;
            public bool UseInSource;
        }

        internal class UserDefinedType
        {
            public string TypeStr;
            public XplNode ZoeNode;
            public bool RemovedAnonymousType;
        }

        // const string TABULATION = "\t";
        const string TABULATION = "    ";
        Encoding _saveEncoding = Encoding.ASCII;
        RenderBuffer _buffer;

        string _headerTabulation = String.Empty;
        string _sourceTabulation = String.Empty;

        List<string> _headerLines;
        List<string> _sourceLines;
        List<Section> _sections;

        Dictionary<string, TypeUsage> _usedTypes;
        Dictionary<string, UserDefinedType> _declaredTypes;
        string _globalVarForwardDecl = String.Empty;

        public CompilationUnit(RenderBuffer buffer)
        {
            _buffer = buffer;
            _headerLines = new List<string>();
            _sourceLines = new List<string>();
            _sections = new List<Section>();
            _usedTypes = new Dictionary<string, TypeUsage>();
            _declaredTypes = new Dictionary<string, UserDefinedType>();
#if DEBUG_TYPES
            this.Debug = true;
#endif
        }

        internal string FileName
        {
            get;
            set;
        }

        internal bool Debug
        {
            get;
            set;
        }

        internal void RegisterUserDefinedType(XplNode zoeDeclarationNode)
        {
            string zoeTypeName = GetZoeFullName(zoeDeclarationNode);
            UserDefinedType userDefinedType = new UserDefinedType();
            userDefinedType.TypeStr = zoeTypeName;
            userDefinedType.ZoeNode = zoeDeclarationNode;

            _declaredTypes.Add(zoeTypeName, userDefinedType);

            XplClass zoeNode = zoeDeclarationNode as XplClass;
            if (zoeNode != null && CPPZOERenderModule.IsObjCDummyGlobalClass(zoeNode))
            {
                XplNodeList fields = zoeNode.get_FieldNodeList();
                foreach (XplField field in fields)
                {
                    // if the global variable was not rendered in the header may need forward decl in the source
                    if (!field.FullSourceFileInfo.EndsWith(".h", StringComparison.InvariantCulture))
                    {
                        _globalVarForwardDecl += _buffer.RenderGlobalVar(field);
                    }
                }
            }            
        }

        internal static string GetZoeFullName(XplNode zoeDeclarationNode)
        {
            string zoeFullName = String.Empty;

            XplNode temp = zoeDeclarationNode;

            while (temp != null)
            {
                string simpleName;
                switch (temp.get_TypeName())
                {
                    case CodeDOMTypes.XplClass:
                        simpleName = ((XplClass)temp).get_name();
                        break;
                    case CodeDOMTypes.XplNamespace:
                        simpleName = ((XplNamespace)temp).get_name().Replace(CppKeywords.ScopePC, ".");
                        break;
                    case CodeDOMTypes.XplDocumentBody:
                        goto exit;
                    default:
                        simpleName = "_error_";
                        break;
                }
                zoeFullName = simpleName + (zoeFullName == String.Empty ? zoeFullName : "." + zoeFullName);
                temp = temp.get_Parent();
            }
            exit:

            return zoeFullName;
        }

        internal UserDefinedType GetUserDefinedType(string zoeTypeStr)
        {
            if (_declaredTypes.ContainsKey(zoeTypeStr))
                return _declaredTypes[zoeTypeStr];
            else
                return null;
        }

        internal string HeaderForUserDefinedType(string zoeTypeName)
        {
            if (_declaredTypes.ContainsKey(zoeTypeName))
                return HeaderForMySelf();
            else
                return null;
        }

        private string HeaderForMySelf()
        {
            return Path.ChangeExtension(Path.GetFileName(this.FileName), "h");
        }

        internal void AddSection(XplNode zoeNode)
        {
            var section = new Section();
            section.FirstLineHeader = _headerLines.Count;
            section.FirstLineSource = _sourceLines.Count;
            section.ZoeNode = zoeNode;
            _sections.Add(section);
        }

        internal void AddNewLineToSource(string line)
        {
            _sourceLines.Add(_sourceTabulation + line);
        }

        internal void AddNewLineToHeader(string line)
        {
            _headerLines.Add(_headerTabulation + line);
        }

        internal void AddNewBlankLineToHeader()
        {
            if (_headerLines.Count > 0 && !String.IsNullOrEmpty(_headerLines[_headerLines.Count - 1]))
            {
                _headerLines.Add(String.Empty);
            }
        }

        internal void IncreaseTabulationSource()
        {
            _sourceTabulation += TABULATION;
        }

        internal void DecreaseTabulationSource()
        {
            if (_sourceTabulation.Length <= TABULATION.Length)
                _sourceTabulation = String.Empty;
            else
                _sourceTabulation = _sourceTabulation.Substring(0, _sourceTabulation.Length - TABULATION.Length);
        }

        internal void IncreaseTabulationHeader()
        {
            _headerTabulation += TABULATION;
        }

        internal void DecreaseTabulationHeader()
        {
            if (_headerTabulation.Length <= TABULATION.Length)
                _headerTabulation = String.Empty;
            else
                _headerTabulation = _headerTabulation.Substring(0, _headerTabulation.Length - TABULATION.Length);
        }

        internal string HeaderText
        {
            get
            {
                return LinesToString(_headerLines);
            }
        }

        internal string SourceText
        {
            get
            {
                return LinesToString(_sourceLines);
            }
        }

        string LinesToString<T>(T lines) where T : IEnumerable<string>
        {
            StringBuilder builder = new StringBuilder();
            foreach (string line in lines)
                builder.AppendLine(line);
            return builder.ToString();
        }

        public override string ToString()
        {
            return this.FileName + "\n\n" + this.HeaderText;
        }

        internal void Render(string outputFolder, List<string> importDirectives)
        {
            if (this._declaredTypes.Count == 0) return;

            RenderHeader(outputFolder, importDirectives);

            RenderCode(outputFolder, importDirectives);
        }

        private void RenderCode(string outputFolder, List<string> importDirectives)
        {
            StringBuilder outputBuffer = new StringBuilder();
            var lines = _sourceLines;

            RenderDebugInfo(outputBuffer);

            RenderIncludesAndForwardDecl(outputBuffer, false, importDirectives);

            RenderLines(outputBuffer, lines, false);

            SaveToDisk(outputBuffer, Path.ChangeExtension(Path.Combine(outputFolder != null ? outputFolder : String.Empty, FileName), "cpp"));
        }

        private void RenderDebugInfo(StringBuilder outputBuffer)
        {
            if (!Debug) return;

            outputBuffer.AppendLine("/* DEBUG INFORMATION ");
            outputBuffer.AppendLine("");
            outputBuffer.AppendLine("    Declared Types:");

            foreach (UserDefinedType userDefinedType in _declaredTypes.Values)
            {
                outputBuffer.AppendLine("        " + userDefinedType.TypeStr);
            }

            outputBuffer.AppendLine("");
            outputBuffer.AppendLine("    Used Types:".PadRight(50) + "[Use in Header] [Use in Source] [Req in Header] [Req in Source]");

            foreach (TypeUsage typeUsage in _usedTypes.Values)
            {
                outputBuffer.AppendLine(("        " + typeUsage.TypeStr).PadRight(51) + (typeUsage.UseInHeader + " ").PadRight(16) + (typeUsage.UseInSource + " ").PadRight(16) + (typeUsage.UseInHeaderRequireFullType + " ").PadRight(16) + typeUsage.UseInSourceRequireFullType);
            }

            outputBuffer.AppendLine("*/");
        }

        private void RenderHeader(string outputFolder, List<string> importDirectives)
        {
            StringBuilder outputBuffer = new StringBuilder();
            var lines = _headerLines;

            RenderIfDefGuard(outputBuffer);

            RenderDebugInfo(outputBuffer);

            RenderIncludesAndForwardDecl(outputBuffer, true, importDirectives);

            RenderLines(outputBuffer, lines, true);

            // close ifdefguard
            outputBuffer.AppendLine("#endif");

            SaveToDisk(outputBuffer, Path.ChangeExtension( Path.Combine(outputFolder != null ? outputFolder : String.Empty, FileName), "h"));
        }

        private void RenderIfDefGuard(StringBuilder outputBuffer)
        {
            string temp = Path.ChangeExtension(Path.GetFileName(FileName), "h").ToUpperInvariant().Replace('.', '_').Replace("-","_");
            outputBuffer.AppendLine("#ifndef " + temp);
            outputBuffer.AppendLine("#define " + temp);
        }

        private void SaveToDisk(StringBuilder outputBuffer, string filename)
        {
            File.WriteAllText(filename, outputBuffer.ToString(), _saveEncoding);
        }

        private void RenderIncludesAndForwardDecl(StringBuilder outputBuffer, bool isHeader, List<string> importDirectives)
        {
            string forwardDeclarations = String.Empty;
            var listOfIncludes = new List<string>();
            string mySelfHeader = HeaderForMySelf();
            listOfIncludes.Add(mySelfHeader);

            // render global import directives
            if (isHeader)
            {
                foreach (string importDirective in importDirectives)
                {
                    outputBuffer.AppendLine(importDirective);
                }
            }

            if (!isHeader) outputBuffer.AppendLine("#include \"" + mySelfHeader + "\"");

            foreach (TypeUsage usage in _usedTypes.Values)
            {
                bool needInclude = false;

                if (!usage.UseInHeader && isHeader) continue;
                if (!usage.UseInSource && !isHeader) continue;

                UserDefinedType typeInfo = CanIgnore(usage.TypeStr);
                if (typeInfo == null) continue;

                // if typeinfo is empty it's an external type
                if (String.IsNullOrEmpty(typeInfo.TypeStr))
                {
                    needInclude = true;
                }

                if (isHeader)
                {
                    if (usage.UseInHeaderRequireFullType) needInclude = true;
                }
                else
                {
                    if (usage.UseInSourceRequireFullType && !usage.UseInHeaderRequireFullType) needInclude = true;
                }

                if (needInclude)
                {
                    string includeFile = _buffer.HeaderForUserDefinedType(usage.TypeStr);
                    string includeText = includeFile[0] == '<' ? "#include " + includeFile : "#include \"" + includeFile + "\"";
                    if (!listOfIncludes.Contains(includeFile) && isHeader ||
                        (!isHeader && !listOfIncludes.Contains(includeFile) && !GlobalImportDirectivesContains(includeText, importDirectives)))
                    {
                        outputBuffer.AppendLine(includeText);
                        listOfIncludes.Add(includeFile);
                    }
                }
                else
                {
                    forwardDeclarations += GetForwardDeclarationForType(typeInfo);
                }
            }

            outputBuffer.AppendLine();

#if RENDER_GLOBAL_VARS_FORWARD_DECL
            if(!isHeader) forwardDeclarations += _globalVarForwardDecl;
#endif

            if (!String.IsNullOrEmpty(forwardDeclarations))
            {
                // TODO : use the correct namespace for types!! 
                // this is using the same namespace than for the first type

                var nsName = "application";
                foreach (var key in this._declaredTypes.Keys)
                {
                    nsName = this._declaredTypes[key].ZoeNode.CurrentNamespace.get_name();
                    break;
                }
                outputBuffer.AppendLine(CppKeywords.NamespacePC + nsName);
                outputBuffer.AppendLine("{");
                outputBuffer.AppendLine();
                outputBuffer.Append(forwardDeclarations);
                outputBuffer.AppendLine();
                outputBuffer.AppendLine("}");
                outputBuffer.AppendLine();
            }
        }

        private bool GlobalImportDirectivesContains(string includeFile, List<string> importDirectives)
        {
            foreach (string importDirective in importDirectives)
            {
                if (importDirective.Contains(includeFile)) return true;
            }
            return false;
        }

        private string GetForwardDeclarationForType(UserDefinedType typeInfo)
        {
            if (typeInfo.RemovedAnonymousType) return String.Empty;

            string retStr = String.Empty;
            string prefix = String.Empty;

            var zoeNode = typeInfo.ZoeNode as XplClass;

            if (zoeNode.get_Parent().IsA(CodeDOMTypes.XplClass))
            {
                if (zoeNode.get_access() != XplAccesstype_enum.PUBLIC)
                {
                    // if class is not public inner class must return
                    return String.Empty;
                }
                else
                {
                    prefix = (zoeNode.get_Parent() as XplClass).get_name() + CppKeywords.ScopePC;
                }
            }

            if (zoeNode.get_isenum())
            {
                retStr += CppKeywords.EnumPC;
            }
            else if (zoeNode.get_isstruct())
            {
                retStr += CppKeywords.StructPC;
            }
            else if (zoeNode.get_isunion())
            {
                retStr += CppKeywords.UnionPC;
            }
            else
            {
                retStr += CppKeywords.ClassPC;
            }
            return retStr + prefix + zoeNode.get_name() + ";\n";
        }

        private UserDefinedType CanIgnore(string zoeTypeStr)
        {
            // if is native
            if (zoeTypeStr[0] == '$') return null;
            // if is black listed
            if (IsBlacklistedType(zoeTypeStr)) return null;

            return _buffer.GetUserDefinedType(zoeTypeStr);
        }

        private bool IsBlacklistedType(string zoeTypeStr)
        {
            if(zoeTypeStr == "zoe.lang.Object") return true;
            return false;
        }

        private void RenderLines(StringBuilder outputBuffer, List<string> lines, bool header)
        {
            int currentSection = 0;
            int firstLine = _sections.Count > 0 ? (header ? _sections[currentSection].FirstLineHeader : _sections[currentSection].FirstLineSource)  : -1;

            for (int n = 0; n < lines.Count; n++)
            {
                if (n == firstLine)
                {
                    if (currentSection < _sections.Count)
                    {
                        Section previousSection = _sections[currentSection], nextSection = null;

                        if (currentSection + 1 < _sections.Count)
                        {
                            nextSection = _sections[currentSection + 1];
                        }

                        if (currentSection > 0 && nextSection != null && previousSection.Namespace != nextSection.Namespace)
                        {
                            CloseNamespaces(previousSection, outputBuffer);
                        }

                        if (currentSection == 0 && (nextSection != null || _sections.Count == 1) || nextSection != null && previousSection.Namespace != nextSection.Namespace)
                        {
                            OpenNamespaces(nextSection != null ? nextSection : previousSection, outputBuffer);
                        }

                        currentSection += 1;

                        if (nextSection != null)
                        {
                            firstLine = header ? nextSection.FirstLineHeader : nextSection.FirstLineSource;
                        }
                    }
                }

                outputBuffer.AppendLine(lines[n]);
            }
            // close external namespace

            if (_sections.Count > 0 && currentSection > 0)
            {
                CloseNamespaces(_sections[currentSection - 1], outputBuffer);
            }
        }

        private static void OpenNamespaces(Section section, StringBuilder outputBuffer)
        {
            string fullname = String.Empty;

            var node = section.ZoeNode;
            var namespaces = new Queue<string>();

            while (node.CurrentNamespace != null)
            {
                node = node.CurrentNamespace;
                namespaces.Enqueue(((XplNamespace)node).get_name());
                node = node.get_Parent();
            }

            foreach (string namespaceName in namespaces)
            {
                outputBuffer.AppendLine(CppKeywords.NamespacePC + namespaceName);
                outputBuffer.AppendLine("{");
                outputBuffer.AppendLine(String.Empty);
            }

        }

        private static void CloseNamespaces(Section section, StringBuilder outputBuffer)
        {
            var node = section.ZoeNode;
            while(node.CurrentNamespace != null)
            {
                outputBuffer.AppendLine("}");
                node = node.CurrentNamespace.get_Parent();
            }
        }

        internal void AddTypeUsage(string typeStr, bool requiredInHeader, bool requiredInSource, CPPZOERenderModule.UseofType use)
        {
            typeStr = RemovePointerAndArrayModifiers(typeStr);

            TypeUsage typeUsage;

            if (!_usedTypes.ContainsKey(typeStr))
            {
                typeUsage = new TypeUsage();
                typeUsage.TypeStr = typeStr;
                _usedTypes.Add(typeStr, typeUsage);
            }
            else
            {
                typeUsage = _usedTypes[typeStr];
            }

            switch (use)
            {
                case CPPZOERenderModule.UseofType.InHeader:
                    typeUsage.UseInHeaderRequireFullType = typeUsage.UseInHeaderRequireFullType | requiredInHeader;
                    typeUsage.UseInHeader = true;
                    break;
                case CPPZOERenderModule.UseofType.InSource:
                    typeUsage.UseInSourceRequireFullType = typeUsage.UseInSourceRequireFullType | requiredInSource;
                    typeUsage.UseInSource = true;
                    break;
                case CPPZOERenderModule.UseofType.Both:
                    typeUsage.UseInHeaderRequireFullType = typeUsage.UseInHeaderRequireFullType | requiredInHeader;
                    typeUsage.UseInSourceRequireFullType = typeUsage.UseInSourceRequireFullType | requiredInSource;
                    typeUsage.UseInHeader = true;
                    typeUsage.UseInSource = true;
                    break;
                default:
                    break;
            }
        }

        private static string RemovePointerAndArrayModifiers(string typeStr)
        {
            if (String.IsNullOrEmpty(typeStr)) return typeStr;

            int aPosition = typeStr.LastIndexOf(']');
            int pPosition = typeStr.LastIndexOf('*');
            int rPosition = typeStr.LastIndexOf('^');

            int maxIndex = Math.Max(aPosition, pPosition);
            maxIndex = Math.Max(maxIndex, rPosition);

            if (maxIndex >= 0)
            {
                if (typeStr[maxIndex] == '*' || typeStr[maxIndex] == '^')
                {
                    return typeStr.Substring(maxIndex + 2);
                }
                else
                {
                    return typeStr.Substring(maxIndex + 1);
                }
            }

            return typeStr;
        }


        internal void RegisterAnonymousType(XplClass classDecl)
        {
            var typeInfo = _buffer.GetUserDefinedType(GetZoeFullName(classDecl));
            typeInfo.RemovedAnonymousType = true;
        }

    }

    class RenderBuffer
    {
        string _currentLine;
        Dictionary<string,CompilationUnit> _buffers = new Dictionary<string,CompilationUnit>();
        Dictionary<string, string> _externTypesToHeaders = new Dictionary<string, string>();
        readonly CompilationUnit.UserDefinedType _dummyUserDefinedType = new CompilationUnit.UserDefinedType();

        CompilationUnit _currentBuffer;
        List<string> _importDirectives;
        CPPZOERenderModule _renderModule;

        public RenderBuffer(string outputFolder, CPPZOERenderModule renderModule)
        {
            this.OutputFolder = outputFolder;
            _currentLine = String.Empty;
            _currentBuffer = new CompilationUnit(this);
            _renderModule = renderModule;
        }

        internal void RegisterUserDefinedType(XplNode zoeDeclarationNode)
        {
            _currentBuffer.RegisterUserDefinedType(zoeDeclarationNode);
        }

        List<CompilationUnit> Buffers
        {
            get
            {
                var list = new List<CompilationUnit>(this._buffers.Values);
                return list;
            }
        }

        internal string OutputFolder
        {
            get;
            set;
        }

        // Close buffer
        internal void Close()
        {

        }

        /// <summary>
        /// Saves files to disk
        /// </summary>
        internal void Render()
        {
            foreach (string filename in _buffers.Keys)
            {
                _buffers[filename].Render(OutputFolder, _importDirectives);
            }
        }

        /// <summary>
        /// Append simple string to current line. Line is not added to buffer until newline is called
        /// </summary>
        /// <param name="str">String to append</param>
        internal void Write(string str)
        {
            _currentLine += str;
        }

        /// <summary>
        /// Adds current line to code file (.cpp) in current file buffer
        /// </summary>
        internal void WriteNewLineOfCode()
        {
            _currentBuffer.AddNewLineToSource(_currentLine);
            _currentLine = String.Empty;
        }

        /// <summary>
        /// Adds current line to header file (.h) in current file buffer
        /// </summary>
        internal void WriteNewLineOfHeader()
        {
            _currentBuffer.AddNewLineToHeader(_currentLine);
            _currentLine = String.Empty;
        }

        /// <summary>
        /// Adds current line to both header and code files in current file buffer
        /// </summary>
        internal void WriteNewLine()
        {
            _currentBuffer.AddNewLineToHeader(_currentLine);
            _currentBuffer.AddNewLineToSource(_currentLine);
            _currentLine = String.Empty;
        }

        /// <summary>
        /// Increase tabulation in header file only for current file buffer
        /// </summary>
        internal void IncreaseTabulationHeader()
        {
            _currentBuffer.IncreaseTabulationHeader();
        }

        /// <summary>
        /// Decrease tabulation in header file only for current file buffer
        /// </summary>
        internal void DecreaseTabulationHeader()
        {
            _currentBuffer.DecreaseTabulationHeader();
        }

        internal void DecreaseTabulationSource()
        {
            _currentBuffer.DecreaseTabulationSource();
        }

        internal void IncreaseTabulationSource()
        {
            _currentBuffer.IncreaseTabulationSource();
        }

        internal void ChangeBufferIfNeeded(XplNode node)
        {
            int line = 0;
            string filename = null;
            CPPZOERenderModule.ParseZoeSourceInfo(node.FullSourceFileInfo, ref line, ref line, ref filename);

            if (filename == null) return;

            filename = Path.GetFileNameWithoutExtension(filename);

            if (_currentBuffer.FileName == filename)
            {
                // add new section to current buffer
                _currentBuffer.AddSection(node);
                return;
            }

            if (_currentBuffer.FileName == null)
            {
                // this is the first buffer!
                _currentBuffer.FileName = filename;
                _buffers.Add(filename, _currentBuffer);
            }
            else
            {
                if (_buffers.ContainsKey(filename))
                {
                    _currentBuffer = _buffers[filename];
                }
                else
                {
                    _currentBuffer = new CompilationUnit(this);
                    _currentBuffer.FileName = filename;
                    _buffers.Add(filename, _currentBuffer);
                }
            }
            // add new section to current buffer
            _currentBuffer.AddSection(node);
        }


        internal void AddRequiredTypeUsage(string typeStr, bool requiredInHeader, bool requiredInSource, CPPZOERenderModule.UseofType use)
        {
            _currentBuffer.AddTypeUsage(typeStr, requiredInHeader, requiredInSource, use);
        }

        internal CompilationUnit.UserDefinedType GetUserDefinedType(string zoeTypeStr)
        {
            CompilationUnit.UserDefinedType temp = null;

            if (_externTypesToHeaders.ContainsKey(zoeTypeStr))
            {
                return _dummyUserDefinedType;
            }

            foreach (CompilationUnit compilationUnit in _buffers.Values)
            {
                temp = compilationUnit.GetUserDefinedType(zoeTypeStr);
                if (temp != null) return temp;
            }

            return temp;
        }

        internal string HeaderForUserDefinedType(string zoeTypeName)
        {
            if (_externTypesToHeaders.ContainsKey(zoeTypeName))
            {
                return _externTypesToHeaders[zoeTypeName];
            }

            CompilationUnit.UserDefinedType temp = null;

            foreach (CompilationUnit compilationUnit in _buffers.Values)
            {
                temp = compilationUnit.GetUserDefinedType(zoeTypeName);
                if (temp != null)
                {
                    return compilationUnit.HeaderForUserDefinedType(zoeTypeName);
                }
            }
            return "typenotfound.h";
        }

        internal void SetGlobalImportDirectives(List<string> importDirectives)
        {
            _importDirectives = importDirectives;
        }

        internal void RegisterAnonymousType(XplClass classDecl)
        {
            _currentBuffer.RegisterAnonymousType(classDecl);
        }

        internal string RenderGlobalVar(XplField field)
        {
            return _renderModule.renderGlobalVarForwardDecl(field);
        }

        internal void WriteNewBlankLineOfHeader()
        {
            _currentBuffer.AddNewBlankLineToHeader();
        }

        internal void RegisterExternType(XplClass classDecl)
        {
            string fulltypeName = CompilationUnit.GetZoeFullName(classDecl);
            string metadata = classDecl.get_lddata();
            int index = metadata.IndexOf(CPPZOERenderModule.CPP_HEADER_METADATA_BEGIN, StringComparison.InvariantCulture);
            int indexTo = metadata.IndexOf(CPPZOERenderModule.CPP_HEADER_METADATA_END, index, StringComparison.InvariantCulture);
            if(index > -1 && indexTo > 0 && indexTo > index)
            {
                string headerName = metadata.Substring(index + CPPZOERenderModule.CPP_HEADER_METADATA_BEGIN.Length, indexTo - index - CPPZOERenderModule.CPP_HEADER_METADATA_BEGIN.Length);
                _externTypesToHeaders.Add(fulltypeName, headerName);
            }
        }
    }
}
