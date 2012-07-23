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
using System.Collections.Generic;
using System.Text;
using LayerD.CodeDOM;
using LayerD.ZOECompiler;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace LayerD.OutputModules.Importers
{
    public class CPPImportDirectivesProcessor : IZOEImportsDirectiveProcessor
    {
        class ImportParameters
        {
            public string Namespace = "";
            public string MockClassName = "MockClass";
            public string Platform = "";
            public string HeaderFile = "";
            public XplName ImportDirective = null;
        }

        private List<ImportParameters> importDirectives = new List<ImportParameters>();
        private List<XplDocument> processedDocuments = new List<XplDocument>();

        #region IZOEImportsDirectiveProcessor Members

        public void SetModulesSearchPath(string[] searchPaths)
        {
            throw new NotImplementedException();
        }

        public bool ProcessImports(XplName[] imports, bool genereteOutputFiles)
        {
            foreach (XplName importDirective in imports)
            {
                string[] arguments = new string[importDirective.Children().GetLength()];

                for (int i = 0; i < arguments.Length; i++)
                {
                    arguments[i] = importDirective.Children().GetNodeAt(i).get_StringValue();
                }

                ProcessImport(arguments, genereteOutputFiles, importDirective);
            }

            return true;
        }

        public XplDocument[] GetLastImportProcessDocuments()
        {
            return new XplDocument[0];
        }

        public string GetLastImportFileName()
        {
            return null;
        }

        public IErrorCollection GetLastImportErrors()
        {
            return null;
        }

        public void UseTypesCache(bool useTypesCache)
        {
        }

        public bool SupportCachedTypesIndex()
        {
            return false;
        }

        public System.Collections.Hashtable GetCachedTypesIndex()
        {
            return new System.Collections.Hashtable();
        }

        #endregion

        private void ProcessImport(string[] importDirectiveArguments, bool genereteOutputFiles, XplName importDirective)
        {
            ImportParameters ip = new ImportParameters();
            ip.ImportDirective = importDirective;

            foreach (string parameter in importDirectiveArguments)
            {
                if (parameter.StartsWith("ns", StringComparison.InvariantCulture))
                {
                    ip.Namespace = parameter.Replace(' ', '\0').Substring(3);
                }
                else if (parameter.StartsWith("platform", StringComparison.InvariantCulture))
                {
                    ip.Platform = parameter.Replace(' ', '\0').Substring(9);
                }
                else if (parameter.StartsWith("header", StringComparison.InvariantCulture))
                {
                    ip.HeaderFile = parameter.Replace(' ', '\0').Substring(7);
                }
                else if (parameter.StartsWith("mockClass", StringComparison.InvariantCulture))
                {
                    ip.MockClassName = parameter.Replace(' ', '\0').Substring(10);
                }
            }

            importDirectives.Add(ip);
        }

        /// <summary>
        /// Obtains a document with the types described.
        /// </summary>
        /// <param name="import">The header file to process.</param>
        /// <returns>A XplDocument ZOE format.</returns>
        private void processHeaderFile(ImportParameters import)
        {
            string xmlHeaderFile = import.HeaderFile.Replace(".h", ".xml");

            Process gccXmlProcess = new Process();
            gccXmlProcess.StartInfo = new ProcessStartInfo("gccxml", import.HeaderFile + " -fxml=" + xmlHeaderFile);
            gccXmlProcess.EnableRaisingEvents = false;
            gccXmlProcess.Start();
            gccXmlProcess.WaitForExit();

            if (gccXmlProcess.ExitCode != 0)
            {
                //AddError(gccXmlProcess.StandardOutput.ReadToEnd());
            }
            else
            {
                using (XmlTextReader reader = new XmlTextReader(xmlHeaderFile))
                {
                    // Initialize useful variables.
                    XplDocumentData data = new XplDocumentData(XplDocumenttype_enum.LAYERD_ZOE_DOC, "1.0");
                    XplDocumentBody body = new XplDocumentBody();

                    Dictionary<string, XplNamespace> namespaces = new Dictionary<string, XplNamespace>();
                    Dictionary<string, List<string>> typesByNamespace = new Dictionary<string, List<string>>();
                    Dictionary<string, XplNode> typesById = new Dictionary<string, XplNode>();

                    // Start to read the xml document.
                    reader.MoveToContent();
                    reader.ReadStartElement();
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            // If it is a Namespace entry.
                            #region Namespace
                            if (reader.Name == "Namespace")
                            {
                                string lastId = string.Empty;
                                string contextId = string.Empty;

                                // Iterate through attributes.
                                reader.MoveToFirstAttribute();
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "id")
                                    {
                                        // Insert a new namespace.
                                        lastId = reader.Value;
                                        XplNamespace ns = new XplNamespace();
                                        namespaces[lastId] = ns;
                                        body.get_NamespaceNodeList().InsertAtEnd(ns);
                                    }
                                    else if (reader.Name == "context")
                                    {
                                        // This namespace is encased inside another namespace, this is its parent.
                                        contextId = reader.Value;
                                    }
                                    else if (reader.Name == "name")
                                    {
                                        XplNamespace ns = namespaces[lastId];

                                        // If it is the non-existing namespace, erase it and assume it's blank,
                                        // otherwise just concatenate it to the base namespace.
                                        if (reader.Value != "::")
                                        {
                                            ns.set_name(import.Namespace);
                                        }
                                        else
                                        {
                                            // Get the full namespace name from the context Id.
                                            ns.set_name(namespaces[contextId].get_name() + "::" + reader.Value);
                                        }

                                        ns.set_internalname(reader.Value);
                                    }
                                    else if (reader.Name == "members")
                                    {
                                        typesByNamespace[lastId] = new List<string>(reader.Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                                    }
                                }
                            }
                            #endregion
                            // If it is a Struct entry.
                            #region Struct
                            else if (reader.Name == "Struct")
                            {
                                // Create a base Struct.
                                XplClass structure = new XplClass();
                                structure.set_isstruct(true);

                                // Store the name, since it appears before the context.
                                string structName = string.Empty;

                                // Iterate through attributes.
                                reader.MoveToFirstAttribute();
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "id")
                                    {
                                        // Insert on the correct namespace.
                                        typesById[reader.Value] = structure;
                                    }
                                    else if (reader.Name == "name")
                                    {
                                        structName = reader.Value;
                                    }
                                    else if (reader.Name == "context")
                                    {
                                        if (namespaces.ContainsKey(reader.Value))
                                        {
                                            // If the context is a namespace.
                                            namespaces[reader.Value].get_ClassNodeList().InsertAtEnd(structure);
                                            structure.set_name(namespaces[reader.Value].get_name() + "::" + structName);
                                        }
                                        else
                                        {
                                            // If the context is another class/struct/union.                                            
                                            ((XplClass)typesById[reader.Value]).get_ClassNodeList().InsertAtEnd(structure);
                                            structure.set_name(((XplClass)structure.get_Parent()).get_name() + "::" + structName);
                                        }

                                        structure.set_internalname(structName);
                                    }
                                }
                            }
                            #endregion
                            // If it is a Function entry.
                            #region Function
                            else if (reader.Name == "Function")
                            {
                                // Create a base Struct.
                                XplFunction function = new XplFunction();

                                // Store the name, since it appears before the context.
                                string functionName = string.Empty;

                                // Iterate through attributes.
                                reader.MoveToFirstAttribute();
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "id")
                                    {
                                        // Insert on the types table.
                                        typesById[reader.Value] = function;
                                    }
                                    else if (reader.Name == "name")
                                    {
                                        functionName = reader.Value;
                                    }
                                    else if (reader.Name == "returns")
                                    {
                                        // Acá me dí cuenta que el tipo no iba a aparecer hasta la segunda pasada.
                                        // Por lo tanto, cortar por hoy acá.
                                        //function.get_ReturnType = reader.Value;
                                    }
                                    else if (reader.Name == "context")
                                    {
                                        if (namespaces.ContainsKey(reader.Value))
                                        {
                                            // The context is a namespace. Put a mock class for them if it doesn't exist,
                                            // and make the function static.
                                            typesById.ContainsKey(import.MockClassName);
                                            XplClass mockClass;

                                            if (namespaces[reader.Value].get_ClassNodeList().FirstNode().get_ElementName() == import.MockClassName)
                                            {
                                                // A mock class exists, just append it to the first class.
                                                ((XplClass)namespaces[reader.Value].get_ClassNodeList().FirstNode()).get_FunctionNodeList().InsertAtEnd(function);
                                            }
                                            else
                                            {
                                                // No mock class present, create one.
                                                mockClass = new XplClass(import.MockClassName, XplAccesstype_enum.IPUBLIC, false, false,
                                                        false, false, false, false, false, false, false, false, false, false, 
                                                        XplBitorder_enum.IGNORE, XplBitorder_enum.IGNORE);
                                                namespaces[reader.Value].get_ClassNodeList().InsertAtBegin(mockClass);
                                                mockClass.get_FunctionNodeList().InsertAtEnd(function);
                                            }
                                        }
                                        else
                                        {
                                            // If the context is another class/struct/union.                                            
                                            ((XplClass)typesById[reader.Value]).get_FunctionNodeList().InsertAtEnd(function);                                            
                                        }

                                        function.set_name(((XplClass)function.CurrentClass).get_name() + "::" + functionName);
                                        function.set_internalname(functionName);
                                    }
                                }
                            }
                            #endregion
                        }
                    }

                    // Close the reader to release resources.
                    reader.Close();
                }
            }
        }
    }
}
