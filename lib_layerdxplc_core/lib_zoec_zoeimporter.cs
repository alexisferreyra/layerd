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

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using LayerD.CodeDOM;
using LayerD.OutputModules;
using LayerD.OutputModules.Importers;

namespace LayerD.ZOECompiler
{
    #region InternalImporResult
    class InternalImportResult
    {
        public XplDocument[] Program
        {
            get;
            set;
        }
        public bool Success
        {
            get;
            set;
        }
        public bool CompatibleSemantic
        {
            get;
            set;
        }
        public bool CompatiblePlatform
        {
            get;
            set;
        }
        public bool ExcludeFromDTE
        {
            get;
            set;
        }
        public string DetailedErrorInfo
        {
            get;
            set;
        }
        public bool IsInclude
        {
            get;
            set;
        }
    }
    #endregion

    class InternalZOETypeImporter
    {
        const string DEFAULT_SEARCH_PATH = "programslib";
        /// <summary>
        /// Importa el programa "programFileName" buscando en la carpeta actual y 
        /// luego en la carpeta de busqueda común, el programa no debe ser un
        /// programa extendido.
        /// 
        /// Chequea que la semantica requerida en "currentProgramConfig" sea compatible
        /// con la semántica declarada en el programa importado, de lo contrario no importa
        /// el programa y emite los errores.
        /// Chequea que la plataforma "runtimePlatform" sea declarada como soportada
        /// por el programa.
        /// 
        /// El resultado es detallado en la instancia retornada de
        /// "InternalImportResult".
        /// </summary>
        /// <returns>Siempre devuelve una instancia de la clase de resultados.</returns>
        public InternalImportResult ImportZOEProgram(string programFileName, XplLayerDZoeProgramConfig currentProgramConfig, string runtimePlatform, string basePath)
        {
            string workFileName = programFileName;
            InternalImportResult result = new InternalImportResult();
            // try single filename
            if (!File.Exists(workFileName))
            {
                // try with basepath
                workFileName = Path.Combine(basePath, "." + Path.DirectorySeparatorChar + programFileName);
                if (!File.Exists(workFileName))
                {
                    // try with default search path
                    workFileName = Path.Combine(basePath, "." + Path.DirectorySeparatorChar + DEFAULT_SEARCH_PATH + Path.DirectorySeparatorChar + programFileName);
                    if (!File.Exists(workFileName))
                    {
                        result.DetailedErrorInfo = "File \"" + programFileName + "\" was not found on import process.";
                        return result;
                    }
                }
            }
            try
            {
                string extension = Path.GetExtension(programFileName);
                if (extension == ".pzoe" || extension == ".pxpl")
                {
                    // import a full zoe program
                    result.Program = ZOEProgramLoader.LoadProgram(workFileName);
                }
                else if (extension == ".zoe" || extension == ".xpl")
                {
                    // import single zoe source, use the source as simple include
                    result.Program = new XplDocument[1];
                    result.Program[0] = ZOEProgramLoader.LoadSingleSource(workFileName);
                    result.IsInclude = true;
                }
                else
                {
                    // extension not supported, it´s an error
                    result.Success = false;
                    result.DetailedErrorInfo = "Type of file not supported. Only Zoe programs and individual source files are supported.";
                    return result;
                }
            }
            catch (Exception error)
            {
                result.DetailedErrorInfo = error.Message;
                result.Success = false;
                return result;
            }
            //Aquí tengo el programa en memoria.
            if (!result.IsInclude && !CheckCompatibleSemantic(result.Program[0], currentProgramConfig))
            {
                result.Program = null;
                result.CompatibleSemantic = false;
                result.DetailedErrorInfo = "Incompatible semantic of imported program \"" + programFileName + "\". Program was not imported.";
                return result;
            }
            if (!result.IsInclude && !CheckCompatiblePlatform(result.Program[0], runtimePlatform))
            {
                result.Program = null;
                result.CompatiblePlatform = false;
                result.DetailedErrorInfo = "Incompatible platform of imported program \"" + programFileName + "\". Program was not imported.";
                return result;
            }
            result.Success = true;
            result.ExcludeFromDTE = false;
            result.CompatibleSemantic = true;
            result.CompatiblePlatform = true;
            return result;
        }

        private bool CheckCompatiblePlatform(XplDocument xplZOEDocument, string runtimePlatform)
        {
            //PENDIENTE : Implementar chequeo de plataformas validas para el programa importado.
            return true;
        }
        private bool CheckCompatibleSemantic(XplDocument xplZOEDocument, XplLayerDZoeProgramConfig currentProgramConfig)
        {
            //PENDIENTE : Implementar el chequeo de semantica valida.
            return true;
        }
        /// <summary>
        /// Importa el programa "extendedProgramName" buscando en la carpeta actual y 
        /// luego en la carpeta de busqueda común, el programa debe ser un
        /// programa extendido.
        /// 
        /// Chequea que la semantica requerida en "currentProgramConfig" sea compatible
        /// con la semántica declarada en el programa importado, de lo contrario no importa
        /// el programa y emite los errores. Chequea que la plataforma de tiempo de ejecución
        /// sea identica a la plataforma del programa extendido.
        /// 
        /// El resultado es detallado en la instancia retornada de
        /// "InternalImportResult".
        /// </summary>
        /// <returns>Siempre devuelve una instancia de la clase de resultados.</returns>
        public InternalImportResult ImportEZOEProgram(string extendedProgramName, XplLayerDZoeProgramConfig currentProgramConfig, string runtimePlatform, string basePath)
        {
            InternalImportResult result = new InternalImportResult();
            result.DetailedErrorInfo = "Internal Function not implemented. Sorry :-).";
            return result;
        }

        /// <summary>
        /// Returns a path to the directory of fullSourceInfo or fallbackPath if fullSourceInfo
        /// doesn't contain path information.
        /// </summary>
        /// <param name="fullSourceInfo">Source file info as used by XplNodes</param>
        /// <param name="fallbackPath">Fallback path when sourefile doesn't contain file info.</param>
        /// <returns>A path</returns>
        internal string GetDirectoryFromSourceInfo(string fullSourceInfo, string fallbackPath)
        {
            if (String.IsNullOrEmpty(fullSourceInfo)) return fallbackPath;

            string[] parts = fullSourceInfo.Split(',');

            try
            {
                return Path.GetDirectoryName(parts[parts.Length - 1]);
            }
            catch
            {
                return fallbackPath;
            }
        }
    }
}
