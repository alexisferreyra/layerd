/*******************************************************************************
* Copyright (c) 2007, 2012 Alexis Ferreyra, Intel Corporation.
* All rights reserved. This program and the accompanying materials
* are made available under the terms of the Eclipse Public License v1.0
* which accompanies this distribution, and is available at
* http://www.eclipse.org/legal/epl-v10.html
*
* Contributors:
*       Alexis Ferreyra - initial API and implementation
*       Alexis Ferreyra (Intel Corporation)
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
using System.Globalization;

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
            set { p_factoriesLibrary = value; }
        }
        public ZOECompilerCore CurrentClientCore
        {
            set { p_currentClientCore = value; }
        }
        public ArgumentVector VSPArgumentVector
        {
            set { p_argumentsVector = value; }
        }
        public RIPVector VSPRIPVector
        {
            set { p_RIPVector = value; }
        }
        public ContextVector VSContextVector
        {
            set { p_contextVector = value; }
        }

        public bool RunCompileTime(XplDocument virtualSubprogramDocument,
                            XplDocument parameterDocument)
        {
            p_virtualSubprogram = virtualSubprogramDocument;
            p_parameterDocument = parameterDocument;
            DateTime initTime = DateTime.Now;
            ///1º) Compilo el subprograma virtual 
            ///referenciando todos los assemblies con los
            ///plug-ins utilizados.
            if (!flagAddPath)
            {
                AppDomain.CurrentDomain.AppendPrivatePath(Path.Combine( p_currentClientCore.WorkingPath, "factorieslib"));
                flagAddPath = true;
            }
            
            p_currentClientCore.WriteDetailedDebugLine("Compiling Subprogram...");

            CompileSubprogram();

            p_currentClientCore.WriteDetailedDebugLine("Subprogram build time: " + (DateTime.Now - initTime).ToString());

            ///2º) Creo una instancia del subprograma virtual.
            ///y seteo las referencias al documento parametro
            ///y a la instancia del compilador actual.
            if (p_vspModule != null)
            {
                PrepareSubProgram();
                ///3º) Ejecuto la función principal del subprograma virtual.
                bool res = RunSubProgram();
                p_currentClientCore.WriteDetailedDebugLine("Subprogram build and exec time: " + (DateTime.Now - initTime).ToString());
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
                p_currentClientCore.WriteDetailedDebugLine("Begin Execution of Subprogram.");
                
                var target = p_VSPObject as zoe.lang.SubprogramBase;
                target.Run(p_argumentsVector, p_RIPVector, p_contextVector);

                if (p_currentClientCore.get_ShowFullDebugInfo())
                    ZOECompilerCore.WriteDebugTextLine("End Execution of Subprogram.");
            }
            catch (Exception error)
            {
                error = error.InnerException != null ? error.InnerException : error;

                p_currentClientCore.get_ErrorCollection().AddError(
                    new Error("Error on execution of Virtual Subprogram. " + error.Message + " Trace:" + error.StackTrace,
                    "Error durante la ejecución del Subprograma Virtual. " + error.Message + " Trace:" + error.StackTrace)
                );
                p_currentClientCore.WriteDetailedDebugLine("Error on execution of Virtual Subprogram.");
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
                Type cgVSPType = p_vspModule.GetType(VSP_TYPENAME);
                Object cgVSP = cgVSPType.GetConstructor(Type.EmptyTypes).Invoke(null);
                p_VSPType = cgVSPType;
                p_VSPObject = cgVSP;
                //Seteo el objeto ZOECompilerCore
                ClassfactoryBase.__compiler = p_currentClientCore;
                ClassfactoryBase.__currentDTE = p_parameterDocument;
                ClassfactoryBase.__program = p_currentClientCore.get_LastProgram();

                //Si es interactivo seteo los campos de la clase interactiva
                if (p_currentClientCore.get_InteractiveOnly())
                {
                    ClassfactoryInteractiveBase.__compiler = p_currentClientCore;
                    ClassfactoryInteractiveBase.__currentDTE = p_parameterDocument;
                    ClassfactoryInteractiveBase.__program = p_currentClientCore.get_LastProgram();
                }
            }
            catch (Exception error)
            {
                if (error.InnerException != null) error = error.InnerException;
                p_currentClientCore.get_ErrorCollection().AddError(
                    new Error("Error while preparing Virtual Subprogram." + error.Message)
                );
            }
        }

        private void CompileSubprogram()
        {
            p_subprogramCounter++;

            XplDocument[] virtualSubprogramProgram = new XplDocument[3];
            virtualSubprogramProgram[0] = BuildProgram();
            virtualSubprogramProgram[2] = p_virtualSubprogram;

            XplNodeList.CopyNodesAtEnd(virtualSubprogramProgram[2].get_DocumentBody().Children(), virtualSubprogramProgram[0].get_DocumentBody().Children());

            p_VSPfileName = Path.Combine(p_currentClientCore.WorkingPath, VSP_FILENAME + p_subprogramCounter.ToString(CultureInfo.InvariantCulture) + ".dll");
            CSZOERenderModule rm = new CSZOERenderModule();
            rm.CheckTypes = false;
            rm.CompileInMemory = true;
            rm.SetEZOEInputDocument(virtualSubprogramProgram[0]);
            rm.SetOutputFileName(Path.GetFileName(p_VSPfileName));
            rm.SetOutputPath(Path.GetDirectoryName(p_VSPfileName) + Path.DirectorySeparatorChar);
            rm.SetOutputType(XplLayerDZoeProgramModuletype_enum.DYNAMIC_LIB);
            rm.BuildFullTypes = true;
            string omparams = p_factoriesLibrary.GetAssemblyReferencies( "/reference:"," " );

            // clean old assembly
            if (File.Exists(p_VSPfileName)) File.Delete(p_VSPfileName);
            p_vspModule = null;

            if (!rm.StartParseDocument(false, omparams, "") && rm.GetLastParseErrors() != null)
            {
                foreach (IError error in rm.GetLastParseErrors())
                {
                    p_currentClientCore.get_ErrorCollection().AddError(error);
                }
            }
            else
            {
                p_vspModule = rm.LastInMemoryCompiledAssembly;
            }
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

            progConfig.set_defaultPlatform(p_currentClientCore.get_CompilationPlatform());
            progConfig.set_defaultOutputFileName(Path.GetFileName(p_VSPfileName));
            progConfig.set_moduleType(XplLayerDZoeProgramModuletype_enum.DYNAMIC_LIB);
            progConfig.set_name("CurrentVSP");

            XplTargetPlatform defaultPlatform = XplLayerDZoeProgramConfig.new_OutputPlatform();
            defaultPlatform.set_uniqueName(p_currentClientCore.get_CompilationPlatform());
            defaultPlatform.set_simpleName(p_currentClientCore.get_CompilationPlatform().Split(new char[] { ' ' })[0]);
            progConfig.get_OutputPlatform().InsertAtEnd(defaultPlatform);

            XplSourceFile sourceFile = XplLayerDZoeProgramConfig.new_SourceFile();
            sourceFile.set_fileName("in memory program - no filename");
            progConfig.get_SourceFile().InsertAtEnd(sourceFile);

            XplLayerDZoeProgramRequirements requirements = XplLayerDZoeProgramConfig.new_ProgramRequirements();
            progConfig.set_ProgramRequirements(requirements);
            return prog;
        }

    }
}
