/****************************************************************************
 
  Meta D++ Output Module for Zoe compiler (for interactive compiling)
  
  Original Author: Alexis Ferreyra
  Contact: alexis.ferreyra@layerd.net
  
  Please visit http://layerd.net to get the last version
  of the software and information about LayerD technology.

****************************************************************************/
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
using LayerD.ZOECompiler;

namespace LayerD.OutputModules
{
	/// <summary>
	/// Implementa la interfaz IEZOEOutputModuleServices, y 
	/// es la clase principal que implementa el Modulo de Salida
	/// operador por el Compilador LayerD-Zoe.
	/// </summary>
	public class DPP_ZOE_Output_Module: IEZOEOutputModuleServices
	{
		const string p_OutputModuleVersion="1.0";
		const string p_DefaultPlatform="Meta D++";

		#region Constructores
        public DPP_ZOE_Output_Module()
        {
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
			return new DPPZOERenderModule();
		}
		/// <summary>
		/// Devuelve una objeto que implementa "IEZOERender" para la plataforma indicada en el argumento.
		/// 
		/// Nulo si ocurre un error.
		/// </summary>
		/// <param name="platformName">Nombre de la plataforma para la que se requiere la implementación de "IEZOERender"</param>
		public IEZOERender GetEZOERenderModuleInstance(string platformName){
			return new DPPZOERenderModule();
		}
		/// <summary>
		/// Devuelve un objeto que implementa "IZOEImportsDirectiveProcessor" para la plataforma por defecto.
		/// 
		/// Nulo si ocurre un error.
		/// </summary>
		public IZOEImportsDirectiveProcessor GetZOEImportsDirectiveProcessorModuleInstance(){
            return new DummyImportDirectivesProcessor();
		}
		/// <summary>
		/// Devuelve un objeto que implementa "IZOEImportsDirectiveProcessor" para la plataforma indicada por el argumento.
		/// 
		/// Nulo si ocurre un error.
		/// </summary>
		/// <param name="platformName">Nombre de la platafora para la que se requiere la implementación de "IZOEImportsDirectiveProcessor"</param>
		public IZOEImportsDirectiveProcessor GetZOEImportsDirectiveProcessorModuleInstance(string platformName){
			return new DummyImportDirectivesProcessor();
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
    public class DummyImportDirectivesProcessor : IZOEImportsDirectiveProcessor
    {
        #region IZOEImportsDirectiveProcessor Members

        public bool ProcessImports(XplName[] imports, bool genereteOutputFiles)
        {
            return true;
        }

        public XplDocument[] GetLastImportProcessDocuments()
        {
            return null;
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
            return false; ;
        }

        public System.Collections.Hashtable GetCachedTypesIndex()
        {
            return null;
        }
        public void UseTypesCache(bool useTypesCache)
        {
            return;
        }

        #endregion

        #region Miembros de IZOEImportsDirectiveProcessor

        public void SetModulesSearchPath(string[] searchPaths)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
