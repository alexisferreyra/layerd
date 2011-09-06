using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LayerD.OutputModules.Importers;
using LayerD.CodeDOM;

namespace LayerD.OutputModules
{
    class JSZoeImporter : IZOEImportsDirectiveProcessor
    {
        #region IZOEImportsDirectiveProcessor Members

        public void SetModulesSearchPath(string[] searchPaths)
        {
            
        }

        public bool ProcessImports(LayerD.CodeDOM.XplName[] imports, bool genereteOutputFiles)
        {
            return true;
        }

        public LayerD.CodeDOM.XplDocument[] GetLastImportProcessDocuments()
        {
            return null;
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

        #endregion
    }
}
