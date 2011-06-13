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
	public class SIFTAL_ZOE_Output_Module: IEZOEOutputModuleServices
	{
		const string p_OutputModuleVersion="1.0";
		const string p_DefaultPlatform="siftal";

		#region Constructores
        public SIFTAL_ZOE_Output_Module()
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
			return new SIFTAL_ZOERenderModule();
		}
		/// <summary>
		/// Devuelve una objeto que implementa "IEZOERender" para la plataforma indicada en el argumento.
		/// 
		/// Nulo si ocurre un error.
		/// </summary>
		/// <param name="platformName">Nombre de la plataforma para la que se requiere la implementación de "IEZOERender"</param>
		public IEZOERender GetEZOERenderModuleInstance(string platformName){
            return new SIFTAL_ZOERenderModule();
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
