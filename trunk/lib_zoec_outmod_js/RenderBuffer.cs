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
using System.IO;
using System.Globalization;
using System.Diagnostics;

namespace LayerD.OutputModules
{
    class CompilationUnit
    {
        class Section
        {
            private string _namespace;

            public XplNode ZoeNode;
            public int FirstLine;

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

        // const string TABULATION = "\t";
        const string TABULATION = "    ";
        static Encoding _saveEncoding = Encoding.ASCII;

        string _sourceTabulation = String.Empty;

        List<string> _sourceLines;
        List<string> _declaredTypes;
        List<Section> _sections;

        public CompilationUnit()
        {
            _sourceLines = new List<string>();
            _sections = new List<Section>();
            _declaredTypes = new List<string>();
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

        internal string Tabulation
        {
            get
            {
                return _sourceTabulation;
            }
            set
            {
                _sourceTabulation = value;
            }
        }

        internal void AddSection(XplNode zoeNode)
        {
            var section = new Section();
            section.FirstLine = _sourceLines.Count;
            section.ZoeNode = zoeNode;
            _sections.Add(section);
        }

        internal void AddNewLine(string line)
        {
            _sourceLines.Add(_sourceTabulation + line);
        }

        internal void IncreaseTabulation()
        {
            _sourceTabulation += TABULATION;
        }

        internal void DecreaseTabulation()
        {
            if (_sourceTabulation.Length <= TABULATION.Length)
                _sourceTabulation = String.Empty;
            else
                _sourceTabulation = _sourceTabulation.Substring(0, _sourceTabulation.Length - TABULATION.Length);
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
            return this.FileName + "\n\n" + this.SourceText;
        }

        internal void RenderCode(string outputFolder)
        {
            if (!IsRenderized()) return;

            StringBuilder outputBuffer = new StringBuilder();
            var lines = _sourceLines;

            RenderDebugInfo(outputBuffer);

            RenderLines(outputBuffer, lines);

            SaveToDisk(outputBuffer, Path.ChangeExtension(Path.Combine(outputFolder != null ? outputFolder : String.Empty, FileName), "js"));
        }

        private void RenderDebugInfo(StringBuilder outputBuffer)
        {
            if (!Debug) return;

            outputBuffer.AppendLine("/* DEBUG INFORMATION ");
            outputBuffer.AppendLine("");
            outputBuffer.AppendLine("*/");
        }

        internal static void SaveToDisk(StringBuilder outputBuffer, string filename)
        {
            File.WriteAllText(filename, outputBuffer.ToString(), _saveEncoding);
        }

        private void RenderLines(StringBuilder outputBuffer, List<string> lines)
        {
            int currentSection = 0;
            int firstLine = _sections.Count > 0 ? _sections[currentSection].FirstLine : -1;

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
                            firstLine = nextSection.FirstLine;
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
                var name = ((XplNamespace)node).get_name();
                // break if it's the external namespace and its "js"
                if (name == "js" && node.get_Parent().CurrentNamespace == null) break;

                namespaces.Enqueue(name);
                node = node.get_Parent();
            }

            foreach (string namespaceName in namespaces)
            {
                outputBuffer.AppendLine("APT.createNamespace(\"" + JsTools.processUserTypeName(namespaceName) + "\");");
                outputBuffer.AppendLine();
                outputBuffer.AppendLine(); 
            }

        }

        private static void CloseNamespaces(Section section, StringBuilder outputBuffer)
        {
            //var node = section.ZoeNode;
            //while (node.CurrentNamespace != null)
            //{
            //    outputBuffer.AppendLine("}");
            //    node = node.CurrentNamespace.get_Parent();
            //}
        }


        internal void RegisterUserDefinedType(XplNode zoeDeclarationNode)
        {
            _declaredTypes.Add(JsTools.GetFullDeclarationName(zoeDeclarationNode));
        }

        internal bool IsRenderized()
        {
            return this._declaredTypes.Count > 0;
        }
    }

    class RenderBuffer
    {
        const string HTML_PREFIX =
            "<!doctype html>" + "\n" +
            "<html>" + "\n" +
            "\t" + "<head>" + "\n" +
            "\t\t" + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">" + "\n" +
            "\t\t" + "<title></title>" + "\n";

        const string HTML_SUFFIX =
            "\t" + "</head>" + "\n" +
            "\t" + "<body >" + "\n" +
            "\t\t" + "<div data-role=\"page\" id=\"main-page\">" + "\n" +
            "\t\t" + "</div>" + "\n" +
            "\t\t" + "<script  type=\"text/javascript\" >$$main({});</script>" + "\n" +
            "\t" + "</body>" + "\n" +
            "</html>";

        string _currentLine;
        Dictionary<string, CompilationUnit> _buffers = new Dictionary<string, CompilationUnit>();
        Stack<CompilationUnit> _backupBufferingBuffer = new Stack<CompilationUnit>();

        CompilationUnit _currentBuffer;
        List<ImportDirectiveData> _importDirectives;
        
        public RenderBuffer(string outputFolder)
        {
            this.OutputFolder = outputFolder;
            this.ProgramName = "default";
            _currentLine = String.Empty;
            _currentBuffer = new CompilationUnit();
            _importDirectives = new List<ImportDirectiveData>();
        }

        public string ProgramName
        {
            get;
            set;
        }

        List<CompilationUnit> Buffers
        {
            get
            {
                var list = new List<CompilationUnit>(this._buffers.Values);
                return list;
            }
        }

        internal void RegisterUserDefinedType(XplNode zoeDeclarationNode)
        {
            _currentBuffer.RegisterUserDefinedType(zoeDeclarationNode);
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
                _buffers[filename].RenderCode(OutputFolder);
            }
            RenderHTML();
        }

        private void RenderHTML()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.Append(HTML_PREFIX);

            if (_importDirectives != null)
            {
                foreach (ImportDirectiveData data in _importDirectives)
                {
                    data.Render(buffer, OutputFolder);
                }
            }

            foreach (string filename in _buffers.Keys)
            {
                if (_buffers[filename].IsRenderized())
                {
                    AddJavaScriptFileReference(buffer, filename);
                }
            }
            
            buffer.Append(HTML_SUFFIX);

            CompilationUnit.SaveToDisk(buffer, Path.ChangeExtension(Path.Combine(this.OutputFolder != null ? this.OutputFolder : String.Empty, ProgramName), "html"));
        }

        private void AddJavaScriptFileReference(StringBuilder buffer, string filename)
        {
            string jsfilename = Path.ChangeExtension(filename, "js");
            buffer.AppendLine("\t\t" + "<script type=\"text/javascript\" src=\"" + jsfilename + "\"></script>");
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
        /// Adds current line to code file in current file buffer
        /// </summary>
        internal void WriteNewLine()
        {
            _currentBuffer.AddNewLine(_currentLine);
            _currentLine = String.Empty;
        }

        /// <summary>
        /// Increase tabulation in header file only for current file buffer
        /// </summary>
        internal void IncreaseTabulation()
        {
            _currentBuffer.IncreaseTabulation();
        }

        /// <summary>
        /// Decrease tabulation in current file buffer
        /// </summary>
        internal void DecreaseTabulation()
        {
            _currentBuffer.DecreaseTabulation();
        }

        internal void ChangeBufferIfNeeded(XplNode node)
        {
            int line = 0;
            string filename = null;
            JsTools.ParseZoeSourceInfo(node.FullSourceFileInfo, ref line, ref line, ref filename);

            if (filename == null) return;

            filename = Path.GetFileNameWithoutExtension(filename).ToLowerInvariant();

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
                    _currentBuffer = new CompilationUnit();
                    _currentBuffer.FileName = filename;
                    _buffers.Add(filename, _currentBuffer);
                }
            }
            // add new section to current buffer
            _currentBuffer.AddSection(node);
        }

        internal void AddImportDirective(XplName importDirective)
        {
            ImportDirectiveData data = ImportDirectiveData.ParseImportDirective(importDirective);
            if (data != null)
            {
                _importDirectives.Add(data);
            }
        }


        internal string GetCurrentBufferFileName()
        {
            if (_currentBuffer == null) return String.Empty;
            return _currentBuffer.FileName;
        }

        internal void StartBuffering()
        {
            var back = this._currentBuffer;
            this._backupBufferingBuffer.Push(this._currentBuffer);
            this._currentBuffer = new CompilationUnit();
            this._currentBuffer.Tabulation = back.Tabulation;
        }

        internal string StopBuffering()
        {
            if (this._backupBufferingBuffer.Count == 0) return String.Empty;
            
            if (!String.IsNullOrEmpty(_currentLine)) WriteNewLine();

            string val = this._currentBuffer.SourceText;
            this._currentBuffer = this._backupBufferingBuffer.Pop();
            return val;
        }
    }

    internal class ImportDirectiveData
    {
        List<string> _externs = new List<string>();

        string MainParameter
        {
            get;
            set;
        }

        bool IsStyleSheet
        {
            get;
            set;
        }
        bool IsScript
        {
            get;
            set;
        }
        bool IsResource
        {
            get;
            set;
        }
        bool Copy
        {
            set;
            get;
        }
        string OutputSubfolder
        {
            get;
            set;
        }

        internal List<string> Externs
        {
            get
            {
                return _externs;
            }
        }

        internal static ImportDirectiveData ParseImportDirective(XplName importDirective)
        {
            ImportDirectiveData data = new ImportDirectiveData();
            bool flag = false;
            foreach (XplNode node in importDirective.Children())
            {
                string tempStr = node.get_StringValue();
                if (tempStr.IndexOf('=') != -1)
                {
                    string parameterName = tempStr.Substring(0, tempStr.IndexOf('=')).ToLower(CultureInfo.InvariantCulture);
                    string parameterValue = tempStr.Substring(tempStr.IndexOf('=') + 1);
                    if (parameterName == "platform" && JS_ZOE_Output_Module.IsSupportedPlatform(parameterValue))
                    {
                        flag = true;
                    }
                    else if (parameterName == "type")
                    {
                        if (parameterValue == "stylesheet") data.IsStyleSheet = true;
                        if (parameterValue == "script") data.IsScript = true;
                        if (parameterValue == "resource") data.IsResource = true;
                    }
                    else if (parameterName == "copy")
                    {
                        if (parameterValue.ToLowerInvariant() == "true") data.Copy = true;
                    }
                    else if (parameterName == "extern")
                    {
                        data.Externs.Add(parameterValue);
                    }
                    else if (parameterName == "outputsubfolder") data.OutputSubfolder = parameterValue;
                }
                else
                {
                    data.MainParameter = tempStr;
                }
            }

            // check for missing type parameter
            if (flag && !data.IsScript && !data.IsStyleSheet && !data.IsResource && !String.IsNullOrEmpty(data.MainParameter))
            {
                if (data.MainParameter.EndsWith(".js", StringComparison.InvariantCultureIgnoreCase))
                {
                    data.IsScript = true;
                }
                else if (data.MainParameter.EndsWith(".css", StringComparison.InvariantCultureIgnoreCase))
                {
                    data.IsStyleSheet = true;
                }
                else
                {
                    flag = false;
                }
            }

            if (flag)
            {
                return data;
            }
            else
            {
                return null;
            }
        }

        internal void Render(StringBuilder buffer, string outputFolder)
        {
            if (this.IsStyleSheet)
            {
                buffer.AppendLine("\t\t" + "<link rel=\"stylesheet\" href=\"" + this.MainParameter + "\" />");
            }
            else if (this.IsScript)
            {
                buffer.AppendLine("\t\t" + "<script type=\"text/javascript\" src=\"" + this.MainParameter + "\"></script>");
            }

            if (this.IsResource || this.Copy)
            {
                this.CopyFile(outputFolder);
            }
            
        }

        private void CopyFile(string outputFolder)
        {

            // create output subfolder in case it does not exist
            if (this.OutputSubfolder != null)
            {
                outputFolder = outputFolder + "\\" + this.OutputSubfolder;
                if (!Directory.Exists(outputFolder))
                {
                    try 
                    {
                        Directory.CreateDirectory(outputFolder);
                    }
                    catch
                    {
                        Console.WriteLine("Could not create subfolder \"" + outputFolder + "\"");
                        return;
                    }
                    
                }
            }

            string sourceFolder = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            string sourceFile = Path.Combine(sourceFolder, this.MainParameter);
            

            if (File.Exists(sourceFile))
            {
                string targetFile = Path.Combine(outputFolder, Path.GetFileName(this.MainParameter));

                if (!File.Exists(targetFile))
                {

                    try
                    {
                        File.Copy(sourceFile, targetFile);
                    }
                    catch
                    {
                        Console.WriteLine("Could not copy file \"" + sourceFile + "\" to \"" + targetFile + "\".");
                    }
                }
            }
            else
            {
                Console.WriteLine("Warning: file \"" + sourceFile + "\" not found by JavaScript Output Module.");
            }
        }
    }
}
