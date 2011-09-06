using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayerD.OutputModules
{
	/// <summary>
	/// Implementa la interfaz IEZOEOutputModuleServices, y 
	/// es la clase principal que implementa el Modulo de Salida
	/// operador por el Compilador ZOE.
	/// </summary>
	public class JS_ZOE_Output_Module: IEZOEOutputModuleServices
	{
        const string _outputModuleVersion = "1.0 Beta";
        const string _defaultPlatform = "Javascript";

        #region IEZOEOutputModuleServices Members

        public string GetOutputModuleDefaultPlatformString()
        {
            return _defaultPlatform;
        }

        public string GetLayerDOutputMouduleVersion()
        {
            return _outputModuleVersion;
        }

        public IEZOERender GetEZOERenderModuleInstance()
        {
            return new JSZoeRender();
        }

        public IEZOERender GetEZOERenderModuleInstance(string platformName)
        {
            return new JSZoeRender();
        }

        public LayerD.OutputModules.Importers.IZOEImportsDirectiveProcessor GetZOEImportsDirectiveProcessorModuleInstance()
        {
            return new JSZoeImporter();
        }

        public LayerD.OutputModules.Importers.IZOEImportsDirectiveProcessor GetZOEImportsDirectiveProcessorModuleInstance(string platformName)
        {
            return new JSZoeImporter();
        }

        public LayerD.CodeDOM.XplConfig GetOutputModuleInfo()
        {
            return null;
        }

        public LayerD.CodeDOM.XplConfig GetOutputModuleInfo(string platformName)
        {
            return null;
        }

        public LayerD.CodeDOM.XplConfig GetExtendedZOERequirements()
        {
            return null;
        }

        public LayerD.CodeDOM.XplConfig GetExtendedZOERequirements(string platformName)
        {
            return null;
        }

        public bool SetZOEProgramInfo(LayerD.CodeDOM.XplConfig programInfo)
        {
            return true;
        }

        #endregion
    }

}
