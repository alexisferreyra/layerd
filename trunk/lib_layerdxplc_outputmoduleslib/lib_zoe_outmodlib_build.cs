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
*  Zoe Output Modules Library
*  
*  Original Author: Alexis Ferreyra
*  Contact: alexis.ferreyra@layerd.net
*  
*  Please visit http://layerd.net to get the last version
*  of the software and information about LayerD technology.
*
****************************************************************************/

///Archivo: lib_zoe_building.cs 
///
///Servicio de Información y Acceso a Modulos de Salida ZOE.
///Permite construir programas ZOE Extendido.
///


using System;
using System.Collections;
using System.Reflection;
using System.Xml;
using LayerD.CodeDOM;
using LayerD.OutputModules;
using LayerD.ZOECompiler;
using System.IO;

namespace LayerD.ZOEOutputModulesLibrary{
    class OutputModuleInfo : IZOEOutputModuleInfo
    {
        string p_name;
        string p_interfaceFileName;
        bool p_isDynamic;

        public OutputModuleInfo(string name, string interfaceFileName, bool isDinamyc)
        {
            p_name = name;
            p_interfaceFileName = interfaceFileName;
            p_isDynamic = isDinamyc;
        }

        #region IZOEOutputModuleInfo Members
        public string get_Name()
        {
            return p_name;
        }
        public string get_InterfaceFileName()
        {
            return p_interfaceFileName;
        }
        public bool get_IsDynamic()
        {
            return p_isDynamic;
        }
        #endregion
    }
    public class OutputModulesLibrary: IZOEOutputModuleLibrary
    {
        Hashtable p_outputModules = null;
        string p_errorStr = null;
        IErrorCollection p_lastParseErrores = null;
        readonly string p_codegenerators_xml_file = "zoe_codegenerators.xml";
        
        public OutputModulesLibrary()
        {
            p_outputModules = new Hashtable();
        }

        #region IZOEOutputModuleLibrary Members
        /// <summary>
        /// Return error string while processing
        /// </summary>
        /// <returns>error string</returns>
        public string get_ErrorStr()
        {
            return p_errorStr;
        }
        /// <summary>
        /// Read output modules configuration file
        /// </summary>
        /// <returns>True if successful</returns>
        public bool ReadOutputModulesInfo()
        {
            XmlTextReader reader = null;
            try
            {
                p_outputModules.Clear();
                // use assembly path as root
                string rootpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string configfile = Path.Combine(rootpath, p_codegenerators_xml_file);
                // open xmlreader
                reader = new XmlTextReader(configfile);
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.NodeType != XmlNodeType.Element) reader.Read();
                if (reader.IsStartElement())
                    while (reader.NodeType != XmlNodeType.Element) reader.Read();
                if (reader.Name != "ZOECodeGenerators")
                {
                    p_errorStr = "Invalid Code Generators config file. Element 'ZOECodeGenerators' was not found.";
                }
                else
                {
                    reader.Read();
                    while (!(reader.Name == "ZOECodeGenerators" && reader.NodeType == XmlNodeType.EndElement))
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name != "ZOECodeGenerator")
                            {
                                p_errorStr = "Invalid Code Generators config file. Element 'ZOECodeGenerator' was not found.";
                                break;
                            }
                            OutputModuleInfo module = new OutputModuleInfo(
                                reader.GetAttribute("name"),
                                Path.Combine(rootpath, reader.GetAttribute("interfaceFileName")),
                                Boolean.Parse(reader.GetAttribute("isDynamic")));
                            p_outputModules.Add(module.get_Name(), module);
                        }
                        reader.Read();
                    }
                }
            }
            catch (Exception e)
            {
                if (reader != null) p_errorStr = e.Message + " Linea:" + reader.LineNumber + " Col:" + reader.LinePosition + ".";
                else p_errorStr = e.Message;
                return false;
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            return true;
        }

        public bool BuildProgram(
            XplLayerDZoeProgramConfig programConfig, 
            XplDocument explDocument, 
            IEZOEOutputModuleServices outputModule, 
            string targetPlatform, 
            string buildArguments, 
            string renderArguments,
            string outputPath, 
            bool renderOnly)
        {
            IEZOERender render = outputModule.GetEZOERenderModuleInstance();
            render.SetEZOEInputDocument(explDocument);
            render.SetOutputFileName(programConfig.get_defaultOutputFileName());
            render.SetOutputPath(outputPath);
            render.SetOutputType(programConfig.get_moduleType());
            if (render.StartParseDocument(renderOnly, buildArguments, renderArguments))
            {
                p_lastParseErrores = null;
                return true;
            }
            else
            {
                //hubo errores
                p_lastParseErrores = render.GetLastParseErrors();
                return false;
            }
        }
        public bool BuildSourceFile(
            string outputFileName,
            XplDocument explDocument,
            IEZOEOutputModuleServices outputModule,
            string targetPlatform,
            string renderArguments,
            string outputPath)
        {
            IEZOERender render = outputModule.GetEZOERenderModuleInstance();
            render.SetEZOEInputDocument(explDocument);
            render.SetOutputFileName(outputFileName);
            render.SetOutputPath(outputPath);
            //render.SetOutputType(programConfig.get_moduleType());
            if (render.StartParseDocument(true, null, renderArguments))
            {
                p_lastParseErrores = null;
                return true;
            }
            else
            {
                //hubo errores
                p_lastParseErrores = render.GetLastParseErrors();
                return false;
            }
        }
        public IErrorCollection GetLastParseErrors()
        {
            return p_lastParseErrores;
        }
        public IZOEOutputModuleInfo[] get_OutputModulesInfo()
        {
            IZOEOutputModuleInfo[] modules = new IZOEOutputModuleInfo[p_outputModules.Count];
            int n = 0;
            foreach (IZOEOutputModuleInfo module in p_outputModules.Values)
            {
                modules[n] = module;
                n++;
            }
            return modules;
        }
        public IEZOEOutputModuleServices get_OutputModule(string outputModuleName)
        {
            if (outputModuleName == null) return null;
            return LoadOutputModule((IZOEOutputModuleInfo)p_outputModules[outputModuleName]);
        }
        public IEZOEOutputModuleServices get_OutputModule(IZOEOutputModuleInfo outputModuleInfo)
        {
            if (outputModuleInfo == null) return null;
            return LoadOutputModule((IZOEOutputModuleInfo)p_outputModules[outputModuleInfo.get_Name()]);
        }
        public IEZOEOutputModuleServices get_OutputModuleForPlatform(string platform)
        {
            //PENDIENTE : comprobar todas las plataformas soportadas
            //por el modulo de salida y no solo la plataforma por defecto.
            foreach (IZOEOutputModuleInfo module in p_outputModules.Values)
            {
                IEZOEOutputModuleServices services = LoadOutputModule(module);
                if (services != null)
                {
                    string modulePlatform = services.GetOutputModuleDefaultPlatformString().ToLower();
                    platform = platform.ToLower();
                    if (modulePlatform == platform)
                        return services;
                }
            }
            return null;
        }
        /// <summary>
        /// Check if there is an output module for specified platform
        /// </summary>
        /// <param name="platform">platform name</param>
        /// <returns>true if it</returns>
        public bool ExistsOutputModule(string platform)
        {
            return get_OutputModuleForPlatform(platform) != null;
        }
        #endregion

        private IEZOEOutputModuleServices LoadOutputModule(IZOEOutputModuleInfo outputModuleInfo)
        {
            if (outputModuleInfo.get_IsDynamic())
            {
                //It's a dynamic library
                try
                {                    
                    Assembly module = Assembly.LoadFile(System.IO.Path.GetFullPath(outputModuleInfo.get_InterfaceFileName()));
                    Type cgFactoryType = module.GetType("LayerD.OutputModules.CGFactory_" + outputModuleInfo.get_Name());
                    Object cgFactory = cgFactoryType.GetConstructor(new Type[0]).Invoke(new object[0]);
                    if (cgFactory != null)
                    {
                        IEZOEOutputModuleServices services = (IEZOEOutputModuleServices)cgFactoryType.InvokeMember("GetServices", BindingFlags.InvokeMethod, null, cgFactory, null);
                        if (services != null) return services;
                    }
                }
                catch (Exception e)
                {
                    p_errorStr = e.Message;
                    //Was not possible to load module
                    return null;
                }
            }
            else
            {
                //Es un ejecutable
            }
            return null;
        }

    }
    /// <summary>
    /// Interface to Zoe Output Modules Library
    /// May exists multiple implementations of Zoe Output Modules
    /// </summary>
    public interface IZOEOutputModuleLibrary
    {
        /// <summary>
        /// Return the last processing error
        /// </summary>
        /// <returns>Error</returns>
        string get_ErrorStr();
        /// <summary>
        /// Carga la información de los Modulos de Salida disponibles sin cargar en memoria
        /// los modulos de libreria dinamica.
        /// </summary>
        /// <returns>True si tiene exito, false si ocurre un error.</returns>
        bool ReadOutputModulesInfo();
        /// <summary>
        /// Construye el programa ZOE extendido pasado en el primer argumento
        /// para la plataforma "targetPlatform".
        /// </summary>
        /// <returns>True si tiene exito, false de lo contrario.</returns>
        bool BuildProgram(XplLayerDZoeProgramConfig programConfig, XplDocument explDocument, IEZOEOutputModuleServices outputModule, string targetPlatform, string buildArguments, string renderArguments, string outputPath, bool renderOnly);
        /// <summary>
        /// Devuelve los errores de la última llamada a "BuildProgram".
        /// </summary>
        /// <returns>Nulo si no hubo errores.</returns>
        IErrorCollection GetLastParseErrors();
        /// <summary>
        /// Devuelve una matriz con información de todos los modulos de salida disponibles.
        /// </summary>
        IZOEOutputModuleInfo[] get_OutputModulesInfo();
        /// <summary>
        /// Devuelve una interfaz al Modulo de Salida de nombre "outputModuleName".
        /// </summary>
        IEZOEOutputModuleServices get_OutputModule(string outputModuleName);
        /// <summary>
        /// Get an interface to an output module based on provided information
        /// </summary>
        /// <param name="outputModuleInfo">Output module information</param>
        /// <returns>An interface to available output module or null</returns>
        IEZOEOutputModuleServices get_OutputModule(IZOEOutputModuleInfo outputModuleInfo);
        /// <summary>
        /// Devuelve una interfaz a un modulo 
        /// para la plataforma "platform", si no encuentra uno devuelve null.
        /// </summary>
        IEZOEOutputModuleServices get_OutputModuleForPlatform(string platform);
        /// <summary>
        /// Indica si existe un modulo de salida para la plataforma "platform"
        /// </summary>
        bool ExistsOutputModule(string platform);
    }
    /// <summary>
    /// Interface for output module information 
    /// </summary>
    public interface IZOEOutputModuleInfo
    {
        /// <summary>
        /// Name of the output module
        /// </summary>
        /// <returns>The name of the output module</returns>
        string get_Name();
        /// <summary>
        /// Binary file that implements output module
        /// </summary>
        /// <returns>full path to output module implementation</returns>
        string get_InterfaceFileName();
        /// <summary>
        /// If output module is a dynamic library
        /// </summary>
        /// <returns>True if it's a dynamic library</returns>
        bool get_IsDynamic();
    }
}
