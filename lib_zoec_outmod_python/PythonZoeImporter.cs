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
using LayerD.OutputModules.Importers;
using LayerD.CodeDOM;
using System.IO;
using System.Diagnostics;

namespace LayerD.OutputModules
{
    class PythonZoeImporter : IZOEImportsDirectiveProcessor
    {
        public const string GLOBAL_CLASS_PREFIX = "py.global.",
            GLOBAL_NS_PREFIX = "py.";

        XplDocument[] _importedDocuments;

        public void SetModulesSearchPath(string[] searchPaths)
        {
            
        }

        public bool ProcessImports(LayerD.CodeDOM.XplName[] imports, bool generateOutputFiles)
        {
            List<XplDocument> importedDocuments = new List<XplDocument>();

            foreach (XplName import in imports)
            {
                ProcessImports(import, importedDocuments);
            }

            // convert list to array
            if (importedDocuments.Count > 0)
            {
                _importedDocuments = importedDocuments.ToArray();
            }

            return true;
        }

        private void ProcessImports(XplName import, List<XplDocument> importedDocuments)
        {
            var data = ImportDirectiveData.ParseImportDirective(import);
            if (data == null) return;

            if (data.Externs.Count > 0)
            {
                string rootPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

                foreach (string externFile in data.Externs)
                {
                    string filename = Path.Combine(rootPath, externFile);
                    if (File.Exists(filename))
                    {
                        Debug.WriteLine("Python Module: Loading extern file \"" + filename + "\"");
                        var zoeDoc = ZoeHelper.LoadSingleSource(filename);
                        if (zoeDoc != null) importedDocuments.Add(zoeDoc);
                    }
                    else
                    {
                        AddError("Extern file (" + externFile + ") \"" + filename + "\" not found.", import);
                    }
                }
            }
        }

        private void AddError(string errorMessage, XplName import)
        {
            // TODO 
            Console.WriteLine("Python Module Error: " + errorMessage);
        }

        public LayerD.CodeDOM.XplDocument[] GetLastImportProcessDocuments()
        {
            if (_importedDocuments == null)
            {
                _importedDocuments = new XplDocument[0];
            }
            return _importedDocuments;
        }

        public string GetLastImportFileName()
        {
            return String.Empty;
        }

        public LayerD.ZOECompiler.IErrorCollection GetLastImportErrors()
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
            return null;
        }
    }
}
