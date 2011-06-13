/*-
 * Copyright (c) 2008 Alexis Ferreyra
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 * 3. Neither the name of copyright holders nor the names of its
 *    contributors may be used to endorse or promote products derived
 *    from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
 * TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
 * PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL COPYRIGHT HOLDERS OR CONTRIBUTORS
 * BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using LayerD.OutputModules.Importers;
using LayerD.CodeDOM;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Globalization;
using LayerD.ZOECompiler;

namespace LayerD.OutputModules
{
	/// <summary>
	/// Implementa la interfaz IEZOEOutputModuleServices, y 
	/// es la clase principal que implementa el Modulo de Salida
	/// operador por el Compilador ZOE.
	/// </summary>
	public class Java2_ZOE_Output_Module: IEZOEOutputModuleServices
	{
		const string p_OutputModuleVersion="1.0";
		const string p_DefaultPlatform="Java";

		#region Constructores
		public Java2_ZOE_Output_Module(){
		}
		#endregion

		#region Implementación de "IEZOEOutputModuleServices"
		/// <summary>
		/// Interroga al Modulo de Salida por la plataforma por defecto que procesa.
		/// Luego se asume dicha plataforma en los metodos que no indican plataforma
		/// en los argumentos.
		/// </summary>
		/// <returns>Una cadena identificando a la plataforma por defecto.</returns>
		public string GetOutputModuleDefaultPlatformString(){
			return p_DefaultPlatform;
		}
		/// <summary>
		/// Interroga la versión estandar a la que se adiere.
		/// </summary>
		/// <returns>Una cadena con formato "MajorNumber.MinorNumer".</returns>
		public string GetLayerDOutputMouduleVersion(){
			return p_OutputModuleVersion;
		}
		/// <summary>
		/// Devuelve una objeto que implementa "IEZOERender" para la plataforma por defecto soportada.
		/// 
		/// Nulo si ocurre un error.
		/// </summary>
		public IEZOERender GetEZOERenderModuleInstance(){
			return new JavaZOERenderModule();
		}
		/// <summary>
		/// Devuelve una objeto que implementa "IEZOERender" para la plataforma indicada en el argumento.
		/// 
		/// Nulo si ocurre un error.
		/// </summary>
		/// <param name="platformName">Nombre de la plataforma para la que se requiere la implementación de "IEZOERender"</param>
		public IEZOERender GetEZOERenderModuleInstance(string platformName){
			return new JavaZOERenderModule();
		}
		/// <summary>
		/// Devuelve un objeto que implementa "IZOEImportsDirectiveProcessor" para la plataforma por defecto.
		/// 
		/// Nulo si ocurre un error.
		/// </summary>
		public IZOEImportsDirectiveProcessor GetZOEImportsDirectiveProcessorModuleInstance(){
			return new JavaImportDirectivesProcessor();
		}
		/// <summary>
		/// Devuelve un objeto que implementa "IZOEImportsDirectiveProcessor" para la plataforma indicada por el argumento.
		/// 
		/// Nulo si ocurre un error.
		/// </summary>
		/// <param name="platformName">Nombre de la platafora para la que se requiere la implementación de "IZOEImportsDirectiveProcessor"</param>
		public IZOEImportsDirectiveProcessor GetZOEImportsDirectiveProcessorModuleInstance(string platformName){
			return new JavaImportDirectivesProcessor();
		}
		/// <summary>
		/// Devuelve un objeto XplConfig con la información del Modulo de Salida para la plataforma por defecto.
		/// </summary>
		public XplConfig GetOutputModuleInfo(){
			return null;
		}
		/// <summary>
		/// Devuelve un objeto XplConfig con la información del Modulo de Salida para la plataforma indicada por el argumento.
		/// </summary>
		/// <param name="platformName">Indica la plataforma para la que se requiere información.</param>
		public XplConfig GetOutputModuleInfo(string platformName){
			return null;
		}
		/// <summary>
		/// Devuelve un objeto XplConfig con la información de requerimientos para el código Extended LayerD-Zoe
		/// requerido por el Modulo de Salida para la plataforma por defecto.
		/// </summary>
		public XplConfig GetExtendedZOERequirements(){
			return null;
		}
		/// <summary>
		/// Devuelve un objeto XplConfig con la información de requerimientos para el código Extended LayerD-Zoe
		/// requerido por el Modulo de Salida para la plataforma indicada por el argumento.
		/// </summary>
		/// <param name="platformName">Indica la plataforma para la que se requiere el tipo especificado de código EZOE.</param>
		public XplConfig GetExtendedZOERequirements(string platformName){
			return null;
		}
		/// <summary>
		/// Indica al modulo de salida la información del programa que se ésta generando.
		/// </summary>
		/// <param name="programInfo">Objeto con la información del programa.</param>
		/// <returns>true: si se proceso la información con exito. false: de lo contrario.</returns>
		public bool SetZOEProgramInfo(XplConfig programInfo){
			return true;
		}
		#endregion
	}
    public class JavaImportDirectivesProcessor : IZOEImportsDirectiveProcessor
    {
        XplDocument[] _lastDocuments;
        static XplDocument[] _lastCachedDocuments;
        static string _lastCachedDocumentsFileName;

        ArrayList _errors = new ArrayList();

        void AddError(string errorMsg)
        {
            _errors.Add(errorMsg);
        }

        #region IZOEImportsDirectiveProcessor Members

        static string importerJarFileName = "outputmodules" + Path.DirectorySeparatorChar + "JavaImporter.jar";
        static string importedTypesFileName = "java_imported_types.xml";

        string GetCacheFileName(string importArguments)
        {
            string retStr = "javaimporter_" + importArguments.GetHashCode().ToString(NumberFormatInfo.InvariantInfo) + ".cache";
            return Path.Combine(Path.GetTempPath(), retStr);
        }

        public bool ProcessImports(XplName[] imports, bool genereteOutputFiles)
        {
            string str = "";

            foreach (XplName import in imports)
            {
                str += "\"";
                foreach (XplNode node in import.Children())
                {
                    str += node.get_StringValue() + ";";
                }
                str += "\" ";
            }

            string cacheFileName = GetCacheFileName(str), importedCurrentFileName = null;
            bool saveCache = false;

            // Check if it is the same file that is on memory
            if (cacheFileName == _lastCachedDocumentsFileName)
            {
                _lastDocuments = _lastCachedDocuments;
                return true;
            }
            _lastCachedDocumentsFileName = cacheFileName;

            // Check if cache on disk exists
            if (File.Exists(cacheFileName))
            {
                importedCurrentFileName = cacheFileName;
            }
            else
            {
                saveCache = true;
                importedCurrentFileName = importedTypesFileName;

                Process p = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo("java.exe",
                    "  -Xms128m -Xmx1024m -jar \"" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, importerJarFileName) + "\" " + str);

                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardInput = true;
                startInfo.CreateNoWindow = true;

                startInfo.UseShellExecute = false;
                p.StartInfo = startInfo;

                try
                {
                    p.Start();
                    p.WaitForExit();
                    if (p.ExitCode > 0)
                    {
                        AddError("Error while processiong Java platform import directives.");
                        return false;
                    }
                }
                catch
                {
                    AddError("Error executing Java platform import directives.");
                    return false;
                }
            }

            return LoadImportedZoe(importedCurrentFileName, saveCache, cacheFileName);
            
        }

        private bool LoadImportedZoe(string importedCurrentFileName, bool saveCache, string cacheFileName)
        {
            XplReader reader = null;
            try
            {
                // Cargar el archivo en memoria
                XplDocument retDoc = new XplDocument();
                reader = new XplReader(importedCurrentFileName);
                reader.Read();
                retDoc.Read(reader);
                _lastDocuments = new XplDocument[] { retDoc };
                _lastCachedDocuments = _lastDocuments;

                // If saveCache copy imported types to new file name
                if (saveCache)
                {
                    File.Copy(importedCurrentFileName, cacheFileName, true);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }

        public XplDocument[] GetLastImportProcessDocuments()
        {
            return _lastDocuments;
        }

        public string GetLastImportFileName()
        {
            return "";
        }

        public IErrorCollection GetLastImportErrors()
        {
            return null;
        }
        public bool SupportCachedTypesIndex()
        {
            return false;
        }
        public System.Collections.Hashtable GetCachedTypesIndex()
        {
            return new System.Collections.Hashtable();
        }
        public void UseTypesCache(bool useTypesCache)
        {
            return;
        }
        public void SetModulesSearchPath(string[] searchPaths)
        {
            // PENDIENTE : ojo no implementado en el modulo de importación java
            return;
        }

        #endregion
    }
}
