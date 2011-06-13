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
using System.Collections;
using LayerD.CodeDOM;
using System.IO;
using System.Reflection;
using LayerD.OutputModules;

namespace LayerD.ZOECompiler{
    class BuildingControler
    {
        //const string ZOE_VIRTUAL_SUBPROGRAM_BASE_SOURCEFILE = "ZOEVirtualSubprogramBase.xpl";
        readonly string VSP_FILENAME = "factorieslib" + Path.DirectorySeparatorChar + "CurrentVSP";
        const string VSP_TYPENAME = "lang.spns.Subprogram";

        ClassfactoryLibrary p_factoriesLibrary;
        ZOECompilerCore p_currentClientCore;
        XplDocument p_virtualSubprogram;
        XplDocument p_parameterDocument;
        XplDocument[] p_originalProgram;
        string p_compiletimePlatform;
        string p_runtimePlatform;
        Type p_VSPType;
        Object p_VSPObject;
        ArgumentVector p_argumentsVector;
        ContextVector p_contextVector;
        RIPVector p_RIPVector;
        Assembly p_vspModule;
        string p_VSPfileName;
        static int p_subprogramCounter = 0;
        static bool flagAddPath;

        public ClassfactoryLibrary FactoriesLibrary
        {
            get { return p_factoriesLibrary; }
            set { p_factoriesLibrary = value; }
        }
        public ZOECompilerCore CurrentClientCore
        {
            get { return p_currentClientCore; }
            set { p_currentClientCore = value; }
        }
        public ArgumentVector VSPArgumentVector
        {
            get { return p_argumentsVector; }
            set { p_argumentsVector = value; }
        }
        public RIPVector VSPRIPVector
        {
            get { return p_RIPVector; }
            set { p_RIPVector = value; }
        }
        public ContextVector VSContextVector
        {
            get { return p_contextVector; }
            set { p_contextVector = value; }
        }

        public bool RunCompileTime(XplDocument virtualSubprogramDocument,
                            XplDocument parameterDocument,
                            XplDocument[] originalProgram,
                            string compiletimePlatform,
                            string runtimePlatform)
        {
            p_virtualSubprogram = virtualSubprogramDocument;
            p_parameterDocument = parameterDocument;
            p_originalProgram = originalProgram;
            p_compiletimePlatform = compiletimePlatform;
            p_runtimePlatform = runtimePlatform;
            DateTime initTime = DateTime.Now;
            ///1º) Compilo el subprograma virtual 
            ///referenciando todos los assemblies con los
            ///plug-ins utilizados.
            if (!flagAddPath)
            {
                AppDomain.CurrentDomain.AppendPrivatePath(Path.Combine( p_currentClientCore.WorkingPath, "factorieslib"));
                flagAddPath = true;
            }
            CompileSubprogram();
            ///2º) Creo una instancia del subprograma virtual.
            ///y seteo las referencias al documento parametro
            ///y a la instancia del compilador actual.
            if (p_vspModule != null)
            {
                PrepareSubProgram();
                ///3º) Ejecuto la función principal del subprograma virtual.
                bool res = RunSubProgram();
                if (p_currentClientCore.get_ShowInternalTimes() && !p_currentClientCore.get_SilentMode())
                {
                    ZOECompilerCore.WriteDebugTextLine("Subprogram build and exec time: " + (DateTime.Now - initTime).ToString());
                }
                return res;
            }
            else
            {
                p_currentClientCore.get_ErrorCollection().AddError(
                    new Error("Error during compilation of Virtual Subprogram. ",
                    "Error durante la compilación del Subprograma Virtual. " 
                ));
                return false;
            }
        }

        private bool RunSubProgram()
        {
            if (p_VSPType == null || p_VSPObject == null) return false;
            try
            {
                if (p_currentClientCore.get_ShowFullDebugInfo())
                    ZOECompilerCore.WriteDebugTextLine("Begin Execution of Subprogram.");
                p_VSPType.InvokeMember("Run", BindingFlags.InvokeMethod, null, p_VSPObject, new object[] { p_argumentsVector, p_RIPVector, p_contextVector });
                if (p_currentClientCore.get_ShowFullDebugInfo())
                    ZOECompilerCore.WriteDebugTextLine("End Execution of Subprogram.");
            }
            catch (Exception error)
            {
                p_currentClientCore.get_ErrorCollection().AddError(
                    new Error("Error on execution of Virtual Subprogram. " + error.InnerException.Message + " Trace:" + error.InnerException.StackTrace,
                    "Error durante la ejecución del Subprograma Virtual. " + error.InnerException.Message + " Trace:" + error.InnerException.StackTrace)
                );
                if (p_currentClientCore.get_ShowFullDebugInfo())
                    ZOECompilerCore.WriteDebugTextLine("Error on execution of Virtual Subprogram.");
                return false;
            }
            finally
            {
                p_VSPObject = null;
                p_VSPType = null;
                p_vspModule = null;
            }
            return true;
        }

        private void PrepareSubProgram()
        {
            try
            {
                //AppDomainSetup ads = new AppDomainSetup();
                //ads.PrivateBinPath = ".;.\\FactoriesLib";
                //AppDomain.CurrentDomain.RelativeSearchPath = "";                

                //p_vspModule = Assembly.LoadFrom(Path.GetFullPath(p_VSPfileName));
                //AppDomain domain = new AppDomain();
                
                Type cgVSPType = p_vspModule.GetType(VSP_TYPENAME);
                Object cgVSP = cgVSPType.GetConstructor(Type.EmptyTypes).Invoke(null);
                p_VSPType = cgVSPType;
                p_VSPObject = cgVSP;
                //Seteo el objeto ZOECompilerCore
                Type CFBase = null;
                //if (!p_currentClientCore.get_InteractiveOnly())
                //    CFBase = Type.GetType("zoe.lang.ClassfactoryBase,FactoryLib");
                //else
                CFBase = typeof(ClassfactoryBase);
                CFBase.InvokeMember("__compiler", BindingFlags.SetField, null, null, new object[] { p_currentClientCore });
                //Seteo el objeto CurrentDTE
                CFBase.InvokeMember("__currentDTE", BindingFlags.SetField, null, null, new object[] { p_parameterDocument });
                //Seteo el objeto CurrentDTE
                CFBase.InvokeMember("__program", BindingFlags.SetField, null, null, new object[] { p_currentClientCore.get_LastProgram() });
                //Si es interactivo seteo los campos de la clase interactiva
                if (p_currentClientCore.get_InteractiveOnly())
                {
                    Type CFBase2 = typeof(ClassfactoryInteractiveBase);
                    CFBase2.InvokeMember("__compiler", BindingFlags.SetField, null, null, new object[] { p_currentClientCore });
                    //Seteo el objeto CurrentDTE
                    CFBase2.InvokeMember("__currentDTE", BindingFlags.SetField, null, null, new object[] { p_parameterDocument });
                    //Seteo el objeto CurrentDTE
                    CFBase2.InvokeMember("__program", BindingFlags.SetField, null, null, new object[] { p_currentClientCore.get_LastProgram() });
                }
            }
            catch (Exception error)
            {
                if (error.InnerException != null) error = error.InnerException;
                p_currentClientCore.get_ErrorCollection().AddError(
                    new Error("Error while loading Virtual Subprogram." + error.Message,
                    "Error durante la carga del Subprograma Virtual." + error.Message)
                );
            }
        }
        private void CompileSubprogram()
        {
            p_subprogramCounter++;
            //if (p_subprogramCounter > 10) p_subprogramCounter = 0;
            XplDocument[] virtualSubprogramProgram = new XplDocument[3];
            ///1º)Creo un programa ZOE adecuado para el documento de extension.
            virtualSubprogramProgram[0] = BuildProgram();
            //virtualSubprogramProgram[1] = ZOEProgramLoader.LoadLibrarySource(ZOE_VIRTUAL_SUBPROGRAM_BASE_SOURCEFILE);
            virtualSubprogramProgram[2] = p_virtualSubprogram;            
#if FULL_COMPILE 
            ///2º)Creo una instancia del compilador.
            ZOECompilerCore zoec = new ZOECompilerCore();

            if (p_currentClientCore.get_ShowFullDebugInfo())
                ZOECompilerCore.WriteDebugTextLine("Begin Compilation of Subprogram.");
            
            ///PENDIENTE : esto esta mal!!!
            File.Delete(VSP_FILENAME);

            string omparams = p_factoriesLibrary.GetAssemblyNameForType("", "");
            zoec.set_OutputPlatformBuildArguments(" /reference:\"" + omparams + "\"");
            zoec.set_OutputPlatform(p_compiletimePlatform);
            zoec.set_ShowFullDebugInfo(p_currentClientCore.get_ShowFullDebugInfo());
            zoec.set_ShowInternalTimes(p_currentClientCore.get_ShowInternalTimes());
            zoec.set_SilentMode(p_currentClientCore.get_SilentMode());
            zoec.set_OutputPath(Path.GetDirectoryName(VSP_FILENAME)+"\\");
            ///¿¿¿Tal vez no deberia permitir esto, no???
            //zoec.set_IgnoreErrorsAndBuild(p_currentClientCore.get_IgnoreErrorsAndBuild());
            //zoec.set_IgnoreErrorsOnImportedTypes(p_currentClientCore.get_IgnoreErrorsOnImportedTypes());
            ///Los errores en el subprograma virtual no me importan pq en realidad
            ///deberia pasarlo directamente por el modulo de salida e ignorar el compilador zoe,
            ///además los errores generados son pq no se incluye info semantica sobre las 
            ///librerias de classfactorys q usa el subprograma virtual.
            zoec.set_IgnoreErrorsAndBuild(true);
            zoec.set_IgnoreErrorsOnImportedTypes(true);

            ///3º)Intento compilar el programa de extensión.
            if (zoec.CompileProgram(virtualSubprogramProgram))
            {
                //OK se compilo con exito
                ///No agrego los errores por ahora
                //if (zoec.get_IgnoreErrorsAndBuild())
                //    p_currentClientCore.get_ErrorCollection().Merge(zoec.get_ErrorCollection());
            }
            else
            {
                //No se compilo con exito
                p_currentClientCore.get_ErrorCollection().Merge(zoec.get_ErrorCollection());
            }
            if (p_currentClientCore.get_ShowFullDebugInfo())
                ZOECompilerCore.WriteDebugTextLine("End Compilation of Subprogram.");
#else
            //XplNodeList.CopyNodesAtEnd(virtualSubprogramProgram[1].get_DocumentBody().Children(), virtualSubprogramProgram[0].get_DocumentBody().Children());
            XplNodeList.CopyNodesAtEnd(virtualSubprogramProgram[2].get_DocumentBody().Children(), virtualSubprogramProgram[0].get_DocumentBody().Children());

            p_VSPfileName = Path.Combine(p_currentClientCore.WorkingPath, VSP_FILENAME + p_subprogramCounter.ToString() + ".dll");
            CSZOERenderModule rm = new CSZOERenderModule();
            rm.CheckTypes = false;
            rm.CompileInMemory = true;
            rm.SetEZOEInputDocument(virtualSubprogramProgram[0]);
            rm.SetOutputFileName(Path.GetFileName(p_VSPfileName));
            rm.SetOutputPath(Path.GetDirectoryName(p_VSPfileName) + Path.DirectorySeparatorChar);
            rm.SetOutputType(XplLayerDZoeProgramModuletype_enum.DYNAMIC_LIB);
            rm.BuildFullTypes = true;
            string omparams = p_factoriesLibrary.GetAssemblyReferencies( "/reference:"," " );
            //Borro el viejo ensamblado si existe
            if (File.Exists(p_VSPfileName)) File.Delete(p_VSPfileName);
            p_vspModule = null;

            if (!rm.StartParseDocument(false, omparams, ""))
            {
                //hubo errores
                if (rm.GetLastParseErrors() != null)
                    foreach (IError error in rm.GetLastParseErrors())
                    {
                        p_currentClientCore.get_ErrorCollection().AddError(error);
                    }
            }
            else
            {
                p_vspModule = rm.LastInMemoryCompiledAssembly;
            }
#endif
        }

        private XplDocument BuildProgram()
        {
            XplDocument prog = new XplDocument();
            prog.set_ElementName("ZOEDocument");
            XplDocumentData docData = XplDocument.new_DocumentData();
            docData.set_DocumentType(XplDocumenttype_enum.LAYERD_ZOE_PROG);
            prog.set_DocumentData(docData);
            prog.set_DocumentBody(XplDocument.new_DocumentBody());
            XplConfig config = XplDocumentData.new_Config();
            docData.set_Config(config);
            XplLayerDZoeProgramConfig progConfig = XplConfig.new_LayerD_Zoe_Program_Config();
            config.set_Content(progConfig);

            progConfig.set_defaultPlatform(p_compiletimePlatform);
            progConfig.set_defaultOutputFileName(Path.GetFileName(p_VSPfileName));
            progConfig.set_moduleType(XplLayerDZoeProgramModuletype_enum.DYNAMIC_LIB);
            progConfig.set_name("CurrentVSP");

            XplTargetPlatform defaultPlatform = XplLayerDZoeProgramConfig.new_OutputPlatform();
            defaultPlatform.set_uniqueName(p_compiletimePlatform);
            defaultPlatform.set_simpleName(p_compiletimePlatform.Split(new char[] { ' ' })[0]);
            progConfig.get_OutputPlatform().InsertAtEnd(defaultPlatform);
            /*Los archivos fuentes*/
            XplSourceFile sourceFile = XplLayerDZoeProgramConfig.new_SourceFile();
            sourceFile.set_fileName("in memory program - no filename");
            progConfig.get_SourceFile().InsertAtEnd(sourceFile);
            /*El program config*/
            XplLayerDZoeProgramRequirements requirements = XplLayerDZoeProgramConfig.new_ProgramRequirements();
            progConfig.set_ProgramRequirements(requirements);
            return prog;
        }

    }
}
