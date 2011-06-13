/*******************************************************************************
* Copyright (c) 2007, 2008 Alexis Ferreyra.
* All rights reserved. This program and the accompanying materials
* are made available under the terms of the Eclipse Public License v1.0
* which accompanies this distribution, and is available at
* http://www.eclipse.org/legal/epl-v10.html
*
* Contributors:
*     Alexis Ferreyra - initial API and implementation
*******************************************************************************/
/****************************************************************************
* 
*  Zoe Compiler Core
*  
*  Original Author: Alexis Ferreyra
*  Contact: alexis.ferreyra@layerd.net
*  
*  Please visit http://layerd.net to get the last version
*  of the software and information about LayerD technology.
*
****************************************************************************/

///Archivo: lib_layerdxplc_factorylib.cs 
///
///Libreria de Classfactorys utilizada por el compilador ZOE
///para obtener los modulos compilados de Classfactorys, si los
///modulos no existen compilados utiliza los servicios del Generador
///de Modulos de Classfactorys para construirlos previamente.
///

///import "System", "ns=DotNET", "platform=DotNET";
///import "System.Collections", "ns=DotNET", "platform=DotNET";
///import "LayerD.CodeDOM", "ns=DotNET", "platform=DotNET";

using System;
using System.IO;
using System.Collections;
using LayerD.CodeDOM;
using LayerD.ZOECompiler;

namespace LayerD.ZOECompiler{
    /// <summary>
    /// Necesito poder hacer lo siguiente:
    /// - Solicitar la información de tipos de todos los plug-ins.
    /// - Poder hacer q secciones de extensión se compilen y agreguen a
    /// la libreria.
    /// - Poder quitar secciones de extensión de la libreria.
    /// - Poder copiar assemblys directamente en la carpeta de la libreria
    /// y hacer q se actualice la info automaticamente.
    /// 
    /// Lo complicado esta en el tema de las plataformas, y cuando
    /// recompilo una extensión pq se cambio algo, además debo
    /// conservar el código cuando se proporciona el código para
    /// poder combinar classfactorys parciales construidas para otras
    /// plataformas.
    /// 
    /// </summary>
    class ClassfactoryLibrary
    {
        // deprecated constants :-)
        // const string VSPDLL_FILENAME = "vspbase.dll";
        // const string CFBASES_DLL_FILENAME = "zoe_factorytypes_base.dll";

        const string DATABASE_FILE = "types_factory_library.xml";
        const string CODEDOM_DLL_FILENAME = "lib_layerd_xpl_codedom_net.dll";
        const string ZOEC_CORE_DLL_FILENAME = "lib_zoec_core.dll";
        const string CGINTERFACE_DLL_FILENAME = "lib_zoe_cginterface.dll";

        string p_lastModuleFileName = "";
        string p_libraryPath = "factorieslib";
        Hashtable p_index = new Hashtable();
        ZOECompilerCore p_currentClientCore;
        FactoryTypesDatabase p_database;

        public ZOECompilerCore CurrentClientCore
        {
            get { return p_currentClientCore; }
            set { 
                p_currentClientCore = value;
                p_libraryPath = Path.Combine(p_currentClientCore.WorkingPath, p_libraryPath);
            }
        }
        public ClassfactoryLibrary(string workingPath)
        {
            p_libraryPath = Path.Combine(workingPath, p_libraryPath);
            p_database = new FactoryTypesDatabase();
            string fullFileName = FullFileName();
            if (File.Exists(fullFileName))
                ZOEProgramLoader.LoadCDOMFile(p_database, fullFileName);
            else
            {
                SaveDatabase();
                p_database.set_ElementName("FactoryTypesDatabase");
            }
        }
        string FullFileName()
        {
            return Path.Combine(p_libraryPath, DATABASE_FILE);
        }
        public void SaveDatabase()
        {
            if (p_database == null) return;
            if (!File.Exists(p_libraryPath))
            {
                Directory.CreateDirectory(p_libraryPath);
            }
            ZOEProgramLoader.SaveCDOMFile(p_database, FullFileName());
        }
        /// <summary>
        /// Agrega una nueva extensión a la libreria de classfactorys
        /// compilada para la plataforma de tiempo de compilación
        /// indicada.
        /// </summary>
        public bool AddExtensionToLibrary(ExtensionData extension, int number, string compileTimePlatform)
        {
            string baseName = extension.Name + number.ToString();
            baseName = Path.Combine(p_libraryPath, baseName);
            RemoveFromLibrary(baseName + ".dll");
            SaveDatabase();
            if (CheckFileAndCompile(extension, baseName, compileTimePlatform))
                return AddToLibraryIndex(extension, baseName, compileTimePlatform);
            else
                return false;
        }

        private bool AddToLibraryIndex(ExtensionData extension, string baseName, string compileTimePlatform)
        {
            //Agrego los tipos al indice
            AddTypesToIndex(extension, baseName);
            //Guardo el programa en la libreria
            ZOEProgramLoader.SaveCDOMFile(extension.DocumentClone, baseName + ".zoe");
            return true;
        }

        private void RemoveFromLibrary(string moduleFileName)
        {
            ArrayList removeList = new ArrayList();
            foreach (ClassfactoryData cfd in p_database.Children())
                if (cfd.get_moduleFileName() == moduleFileName) 
                    removeList.Add(cfd);
            foreach (ClassfactoryData cfd in removeList)
                p_database.Children().Remove(cfd);
        }

        private void AddTypesToIndex(ExtensionData extension, string baseName)
        {
            IterateAndAddTypesToIndex(extension.DocumentClone.get_DocumentBody().Children(), "", baseName);
        }

        private void IterateAndAddTypesToIndex(XplNodeList list, string baseTypeName, string baseName)
        {
            if (list == null) return;
            foreach (XplNode node in list)
            {
                if (node.get_TypeName() == CodeDOMTypes.XplNamespace)
                {
                    if (node.get_ElementName()[0] == 'N')
                        if (baseTypeName != "")
                            IterateAndAddTypesToIndex(node.Children(), baseTypeName + "." + ((XplNamespace)node).get_name(), baseName);
                        else
                            IterateAndAddTypesToIndex(node.Children(), ((XplNamespace)node).get_name(),baseName);
                }
                else if (node.get_TypeName() == CodeDOMTypes.XplClass)
                {
                    XplClass clase = (XplClass)node;
                    string typeName = baseTypeName + "." + clase.get_name();
                    AddClassToIndex(clase, typeName, baseName);
                    IterateAndAddTypesToIndex(clase.Children(), typeName, baseName);
                }
            }
        }

        private void AddClassToIndex(XplClass clase, string fullName, string baseName)
        {
            ClassfactoryData cfd = new ClassfactoryData(fullName, clase.get_isinterface(), clase.get_isinteractive(), true,
                baseName + ".dll", baseName + ".zoe");
            string platformsStr = GetPlatformsString(clase);
            cfd.set_platforms(platformsStr);
            cfd.set_ElementName("Classfactory");
            p_database.Children().InsertAtEnd(cfd);
        }

        private string GetPlatformsString(XplClass clase)
        {
            string retStr = "";
            XplNodeList plats = clase.get_SetPlatformsNodeList();
            foreach (XplSetPlatforms splats in plats)
                if (splats.Children() != null)
                    foreach (XplPlatform plat in splats.Children())
                        retStr += plat.get_name() + plat.get_version() + ",";
            if (retStr != "") return retStr.Substring(0, retStr.Length - 1);
            else return retStr;
        }

        private bool CheckFileAndCompile(ExtensionData extension, string baseName, string compileTimePlatform)
        {
            baseName += ".dll";
            if (File.Exists(baseName)) File.Delete(baseName);
            //Clono el doc antes de compilar
            extension.CloneDoc();

            ClassfactoryModuleGenerator modgen = new ClassfactoryModuleGenerator();
            modgen.CurrentClientCore = p_currentClientCore;
            return modgen.CompileExtension(extension,
                compileTimePlatform, baseName, ClassfactoryModuleGenerator.ExtensionModuleType.dll);
        }
        /// <summary>
        /// Devuelve el path + nombre de archivo del ensamblado
        /// que implementa el tipo "fullTypeName" para la plataforma de ejecución "runtimePlatform".
        /// </summary>
        public string GetAssemblyNameForType(string fullTypeName, string runtimePlatform)
        {
            //PENDIENTE : hacer q esto funcione correctamente!!!
            return p_lastModuleFileName;
        }

        public string GetAssemblyReferencies(string prefix, string separator)
        {
            string retStr = "";
            char quote = '\"';

            retStr += prefix + quote + Path.GetFullPath(Path.Combine(p_currentClientCore.WorkingPath, CGINTERFACE_DLL_FILENAME)) + quote + separator;
            retStr += prefix + quote + Path.GetFullPath(Path.Combine(p_currentClientCore.WorkingPath, CODEDOM_DLL_FILENAME)) + quote + separator;
            retStr += prefix + quote + Path.GetFullPath(Path.Combine(p_currentClientCore.WorkingPath, ZOEC_CORE_DLL_FILENAME)) + quote + separator;

            Hashtable modules = new Hashtable();
            foreach (ClassfactoryData cfd in p_database.Children())
            {
                string fileName = Path.Combine(p_libraryPath, Path.GetFileName(cfd.get_moduleFileName()));
                if (modules[fileName] == null && cfd.get_active())
                {
                    retStr += prefix + quote + fileName + quote + separator;
                    modules.Add(fileName, cfd);
                }
            }
            return retStr;
        }
        public XplDocument LoadClassfactorys(string platform)
        {
            XplDocument doc = new XplDocument();
            doc.set_DocumentData(new XplDocumentData());
            XplDocumentBody body = new XplDocumentBody();
            doc.set_DocumentBody(body);
            Hashtable loaded = new Hashtable();
            foreach (ClassfactoryData cfd in p_database.Children())
            {
                string fileName = Path.Combine(p_libraryPath,Path.GetFileName( cfd.get_zoeDocFileName()));
                if (loaded[fileName] == null && cfd.get_active())
                {
                    if (File.Exists(fileName))
                    {
                        try
                        {
                            XplDocument temp = ZOEProgramLoader.LoadSingleSource(fileName);
                            XplNodeList.CopyNodesAtEnd(temp.get_DocumentBody().Children(), body.Children());
                            loaded.Add(fileName, cfd);
                        }
                        catch (Exception error)
                        {
                            Warning warning = new Warning("Error while trying to load extension \"" + cfd.get_moduleFileName() + "\". Error: " + error.Message,
                                "Error mientras se intentaba cargar extension \"" + cfd.get_moduleFileName() + "\". Error: " + error.Message);
                            warning.set_ErrorLevel(ErrorLevel.One);
                            warning.set_ErrorSource(ErrorSource.FactoryLibrary);
                            p_currentClientCore.get_ErrorCollection().AddError(warning);
                        }
                    }
                }
            }
            return doc;
        }
        /// <summary>
        /// Devuelve un XplNodeList con todas las extensiones registradas.
        /// Cada extension se describe con una instancia de ClassfactoryData,
        /// por tanto se devuelve un registro por cada clase, no por cada 
        /// modulo.
        /// </summary>
        public XplNodeList GetExtensionsList()
        {
            return p_database.Children();
        }
        /// <summary>
        /// Elimina todas las extensiones de la libreria actual.
        /// </summary>
        public bool RemoveAllExtensions()
        {
            Hashtable deleteds = new Hashtable();
            bool result = true;
            foreach (ClassfactoryData cfd in p_database.Children())
            {
                string fileName = Path.GetFileNameWithoutExtension(cfd.get_moduleFileName());
                if (deleteds[fileName] == null)
                {
                    try
                    {
                        File.Delete(GetFilePathOnCurrentLibrary(cfd.get_moduleFileName()));
                        File.Delete(GetFilePathOnCurrentLibrary(cfd.get_zoeDocFileName()));
                        deleteds.Add(fileName, cfd);
                    }
                    catch (Exception e)
                    {
                        result = false;
                        p_currentClientCore.get_ErrorCollection()
                            .AddError(new Error(e.Message));
                    }
                }
            }
            p_database.Children().Clear();
            SaveDatabase();
            return result;
        }
        private string GetFilePathOnCurrentLibrary(string relativeFilePath)
        {
            return Path.Combine(this.p_libraryPath, Path.GetFileName(relativeFilePath));
        }
        /// <summary>
        /// Elimina todas las extensiones que utilicen como nombre base el indicado
        /// en "extensionBaseName".
        /// Retorna la cantidad de classfactorys borradas con el modulo.
        /// </summary>
        public int RemoveExtension(string extensionBaseName)
        {
            int count = 0;
            Hashtable deleteds = new Hashtable();
            ArrayList toDelete = new ArrayList();
            foreach (ClassfactoryData cfd in p_database.Children())
            {
                string fileName = Path.GetFileNameWithoutExtension(Path.GetFileName(cfd.get_moduleFileName()));
                string number;
                if (fileName.StartsWith(extensionBaseName))
                {
                    number = fileName.Remove(0, extensionBaseName.Length);
                    bool isNumber = true;
                    for(int n=0;n<number.Length;n++)
                        if (!Char.IsNumber(number[n]))
                        {
                            isNumber = false;
                            break;
                        }
                    if (isNumber)
                    {
                        count++;
                        toDelete.Add(cfd);
                        if (deleteds[cfd.get_moduleFileName()] == null)
                        {
                            try
                            {
                                File.Delete(GetFilePathOnCurrentLibrary(cfd.get_moduleFileName()));
                                File.Delete(GetFilePathOnCurrentLibrary(cfd.get_zoeDocFileName()));
                                deleteds.Add(cfd.get_moduleFileName(), cfd);
                            }
                            catch (Exception e)
                            {
                                p_currentClientCore.get_ErrorCollection()
                                    .AddError(new Error(e.Message));
                            }
                        }
                    }
                }
            }
            //Borro de la base ahora:
            foreach (ClassfactoryData cfd in toDelete)
                p_database.Children().Remove(cfd);
            SaveDatabase();
            return count;
        }
    }
}
