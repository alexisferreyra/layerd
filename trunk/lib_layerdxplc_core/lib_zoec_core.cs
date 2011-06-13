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

//Archivo: lib_layerdxplc_core.cs 
//
//Núcleo del compilador LayerD-Zoe, encargado
//de iniciar el proceso de compilación del programa LayerD-Zoe
//y controlar la ejecución completa del programa utilizando los 
//servicios de los restantes modulos.
//


using System;
using System.Collections;
using System.Diagnostics;
using LayerD.CodeDOM;
using LayerD.OutputModules;
using LayerD.ZOEOutputModulesLibrary;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace LayerD.ZOECompiler{
    public class ZOECompilerCore
    {
        #region Campos Privados / Protegidos
        bool p_interactiveOnly = false;
        string p_xplProgramFileName;
        string p_outputPlatform;
        string p_compilationPlatform;
        string p_returnErrorMessage;
        string p_workingPath = ".";
        int p_currentCompileCicle;
        OutputModulesLibrary p_outputModulesLibrary;
        IEZOEOutputModuleServices p_compileTimeOutputModule;
        IEZOEOutputModuleServices p_runtimeOutputModule;
        IEZOEOutputModuleServices p_interactiveOutputModule;
        ErrorCollection p_errorCollection;
        XplDocument p_lastResultDocument;
        XplDocument p_originalProgram;
        XplDocument[] p_lastProgram;
        XplDocument[] p_originalSourceProgram;
        /*Switch varios*/
        static TextWriter p_textOutputStream;
        bool p_ignoreAllErrorsAndBuild;
        bool p_renderIntermediateOutputOnly;
        bool p_renderOriginalProgram;
        string p_outputPath;
        string p_outputPlatformBuildArguments;
        string p_outputPlatformRenderArguments;
        bool p_showFullDebugInfo;
        bool p_showInternalTimes;
        bool p_silentMode;
        bool p_buildAllPlatforms;
        bool p_ignoreErrorsOnImportedTypes;
        bool p_donotBuildExtensions;
        bool p_addExtensions;
        bool p_showInternalDebuger;
        bool p_inyectedCodeDebug;
        //Indica si se esta construyendo una extension
        bool p_buildingExtension;
        static bool p_persistentSemanticAnalizer;
        static SemanticAnalizer p_currentSemanticAnalizer;
        bool p_checkSemanticOfExtensions;
        TypesTable p_lastTypesTable;
        DTEDebugWindow p_debugWindow;

        //Plataformas por defecto a utilizar si no se especifica otra
        readonly string p_defaultOutputPlatform = "DotNET 1.0";
        readonly string p_defaultCompilationPlatform = "DotNET 1.0";
        #endregion

        public ZOECompilerCore(){
            p_outputPlatform = p_defaultOutputPlatform;
        }

        #region Interfaz Publica

        #region Propiedades
        public bool ShowInternalDebuger
        {
            get
            {
                return p_showInternalDebuger;
            }
            set
            {
                p_showInternalDebuger = value;
            }
        }
        public string WorkingPath
        {
            get
            {
                return p_workingPath;
            }
            set
            {
                p_workingPath = value;
            }
        }
        public int CurrentCompileCicle
        {
            get 
            {
                return p_currentCompileCicle;
            }
        }
        public TypesTable LastTypesTable
        {
            get { return p_lastTypesTable; }
        }
        public XplDocument get_LastResultDocument()
        {
            return p_lastResultDocument;
        }
        public XplDocument[] get_LastProgram()
        {
            return p_lastProgram;
        }
        public string get_ReturnErrorMessage()
        {
            return p_returnErrorMessage;
        }
        public string get_CompilationPlatform()
        {
            return p_compilationPlatform;
        }
        public void set_CompilationPlatform(string CompilationPlatform)
        {
            p_compilationPlatform = CompilationPlatform;
        }
        public bool get_InteractiveOnly()
        {
            return p_interactiveOnly;
        }
        public void set_InteractiveOnly(bool InteractiveOnly)
        {
            p_interactiveOnly = InteractiveOnly;
        }
        public IErrorCollection get_ErrorCollection()
        {
            return p_errorCollection;
        }
        public IErrorCollection Errors
        {
            get
            {
                return p_errorCollection;
            }
        }

        /// <summary>
        /// Adds a new persistent IError to current compiler's error collection.
        /// </summary>
        /// <param name="newError">Error object to add as persistent</param>
        public void AddError(IError newError)
        {
            newError.set_PersistentError(true);
            this.Errors.AddError(newError);
        }

        /// <summary>
        /// Try to return TypeInfo object for provided Zoe node.
        /// <paramref name="typeNode"/> must be of type XplClass, XplNamespace or XplFunction
        /// </summary>
        /// <param name="typeNode">Zoe node that represents a type.</param>
        /// <returns>TypeInfo for provided Zoe node or null if type is not found for provided node.</returns>
        public TypeInfo GetTypeInfoFrom(XplNode typeNode)
        {
            if (typeNode.IsA(CodeDOMTypes.XplClass) || typeNode.IsA(CodeDOMTypes.XplNamespace) || typeNode.IsA(CodeDOMTypes.XplFunction))
            {
                // TODO : replace this for faster implementation!!!
                foreach (object item in p_lastTypesTable.Values)
                {
                    TypeInfo typeInfo = item as TypeInfo;
                    if (typeInfo != null && typeInfo.get_TypeNode()==typeNode)
                    {
                        return typeInfo;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Try to return TypeInfo from provided iname object.
        /// </summary>
        /// <param name="identifier">IName from which find the typeinfo on current types table.</param>
        /// <returns>The related TypeInfo or null if TypeInfo is not found for provided identifier.</returns>
        public TypeInfo GetTypeInfoFrom(XplIName identifier)
        {
            return p_lastTypesTable.get_TypeInfo(identifier.FullIdentifier);
        }

        public void set_OutputPlatform(string platform)
        {
            p_outputPlatform = platform;
        }
        public string get_OutputPlatform()
        {
            return p_outputPlatform;
        }
        public void set_TextOutputStream(TextWriter textWriter)
        {
            p_textOutputStream = textWriter;
        }
        public void set_IgnoreErrorsAndBuild(bool p)
        {
            p_ignoreAllErrorsAndBuild = p;
        }
        public bool get_IgnoreErrorsAndBuild()
        {
            return p_ignoreAllErrorsAndBuild;
        }
        public void set_RenderIntermediateOutputOnly(bool p)
        {
            p_renderIntermediateOutputOnly = p;
        }
        public bool get_RenderIntermediateOutputOnly()
        {
            return p_renderIntermediateOutputOnly;
        }
        /// <summary>
        /// Set if zoe compiler will generate rendered inyected code debug information or not.
        /// </summary>
        /// <param name="inyectedCodeDebug">True to generate inyected code debug information.</param>
        public void set_InyectedCodeDebug(bool inyectedCodeDebug)
        {
            this.p_inyectedCodeDebug = inyectedCodeDebug;
        }
        /// <summary>
        /// If zoe compiler will generate rendered inyected code debug information or not.
        /// </summary>
        /// <returns>True if inyected code debug information will be generated.</returns>
        public bool get_InyectedCodeDebug()
        {
            return this.p_inyectedCodeDebug;
        }
        public void set_OutputPath(string path)
        {
            p_outputPath = path;
        }
        public string get_OutputPath()
        {
            return p_outputPath;
        }
        public void set_OutputPlatformBuildArguments(string buildArguments)
        {
            p_outputPlatformBuildArguments = buildArguments;
        }
        public string get_OutputPlatformBuildArguments()
        {
            return p_outputPlatformBuildArguments;
        }
        public void set_OutputPlatformRenderArguments(string renderArguments)
        {
            p_outputPlatformRenderArguments = renderArguments;
        }
        public string get_OutputPlatformRenderArguments()
        {
            return p_outputPlatformRenderArguments;
        }
        public void set_ShowFullDebugInfo(bool p)
        {
            p_showFullDebugInfo = p;
        }
        public bool get_ShowFullDebugInfo()
        {
            return p_showFullDebugInfo;
        }
        public void set_ShowInternalTimes(bool p)
        {
            p_showInternalTimes = p;
        }
        public bool get_ShowInternalTimes()
        {
            return p_showInternalTimes;
        }
        public void set_SilentMode(bool p)
        {
            p_silentMode = p;
        }
        public bool get_SilentMode()
        {
            return p_silentMode;
        }
        public void set_BuildAllPlatforms(bool p)
        {
            p_buildAllPlatforms = p;
        }
        public bool get_BuildAllPlatforms()
        {
            return p_buildAllPlatforms;
        }
        public static TextWriter get_TextOutputStream()
        {
            return p_textOutputStream;
        }
        public void set_IgnoreErrorsOnImportedTypes(bool arg)
        {
            p_ignoreErrorsOnImportedTypes = arg;
        }
        public bool get_IgnoreErrorsOnImportedTypes()
        {
            return p_ignoreErrorsOnImportedTypes;
        }
        public XplDocument[] get_CurrentOriginalSourceProgram()
        {
            return p_originalSourceProgram;
        }
        public string get_DllBaseDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
        #endregion

        #region Ayudas para IntelliSense
        public bool CheckSemantic(XplDocument[] program, string platformName)
        {
            try
            {
                p_lastProgram = program;
                //if (p_runtimeOutputModule == null || p_compileTimeOutputModule == null)
                //    PrepareOutputModules();
                if (p_runtimeOutputModule == null || p_compileTimeOutputModule == null)
                {
                    p_runtimeOutputModule = p_compileTimeOutputModule = new DotNET_ZOE_Output_Module();
                    //return false;
                }
                p_errorCollection = new ErrorCollection();
                p_currentCompileCicle = 0;
                p_donotBuildExtensions = true;
                p_checkSemanticOfExtensions = true;
                p_persistentSemanticAnalizer = true;
                p_ignoreErrorsOnImportedTypes = true;
                
                //Compilo
                CompileCicle(program);

                p_currentCompileCicle = 0;
                p_donotBuildExtensions = false;
                p_checkSemanticOfExtensions = false;
                p_persistentSemanticAnalizer = false;
                p_ignoreErrorsOnImportedTypes = false;

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public static void WriteDebugTextLine(string debugTextLine)
        {
            if (p_textOutputStream!=null) p_textOutputStream.WriteLine(debugTextLine);
        }
        public bool CompileProgram(XplDocument [] fullZoeProgram)
        {
            return CompileProgram("", p_outputPlatform, null, fullZoeProgram);
        }
        public bool CompileProgram(XplDocument program)
        {
            return CompileProgram("", p_outputPlatform, program, null);
        }
        public bool CompileProgram(string ZOEProgramFileName)
        {
            return CompileProgram(ZOEProgramFileName, p_outputPlatform, null, null);
        }

        private void ShowDebugWindow()
        {
            // PENDIENTE : Mejorar esto!! es muy precario el manejo de hilos
            
            p_debugWindow = new DTEDebugWindow();
            p_debugWindow.CoreThread = Thread.CurrentThread;
            Thread debugWindowThread = new Thread(new ThreadStart(
                    delegate()
                    {
                        p_debugWindow.CurrentCore = this;
                        p_debugWindow.CurrentProgram = p_lastProgram;
                        p_debugWindow.EZOERender = p_interactiveOutputModule.GetEZOERenderModuleInstance();
                        Application.EnableVisualStyles();
                        Application.Run(p_debugWindow);
                    }
                ));
            debugWindowThread.ApartmentState = ApartmentState.STA;
            debugWindowThread.Start();
            
        }
        /// <summary>
        /// Compila un programa ZOE.
        /// 
        /// Se debe proporcionar el nombre del archivo del programa ZOE o un
        /// Programa ZOE en memoria.
        /// Si se proporciona un nombre de archivo se cargan en memoria, el programa
        /// y los fuentes. Si se proporciona un programa en memoria se cargan los
        /// fuentes de dicho programa.
        /// </summary>
        /// <param name="ZOEProgramFileName">El nombre de archivo del programa ZOE a compilar.</param>
        /// <param name="platform">La plataforma para la cual se compilara el programa.</param>
        /// <param name="zoeProgram">Un programa ZOE, si es nulo se usuara el nombre de archivo proporcionado en el primer parametro.</param>
        /// <param name="fullZoeProgram">Un programa ZOE completo en memoria, si es nulo se usuara el nombre de archivo proporcionado en el primer parametro o el programa en el parametro zoeProgram.</param>
        /// <returns>True si la compilación es exitosa, false de lo contrario.</returns>
        public bool CompileProgram(string ZOEProgramFileName, string platform, XplDocument zoeProgram, XplDocument []fullZoeProgram)
        {
            p_xplProgramFileName = ZOEProgramFileName;
            p_outputPlatform = platform;
            if (p_compilationPlatform == null) p_compilationPlatform = p_defaultCompilationPlatform;
            p_errorCollection = new ErrorCollection();            
            //Aqui deberia chequear que el nombre de la plataforma pasada
            //no sea un alias para alguno de los modulos de salida utilizados
            //y en algun lugar tengo que desambiguar para el caso de que dos o
            //mas modulos de salida soporten una misma plataforma.
            XplDocument[] program = null;
            try
            {
                //1º) Cargo el programa
                if (fullZoeProgram == null)
                {
                    if (zoeProgram == null)
                        p_lastProgram = program = ZOEProgramLoader.LoadProgram(p_xplProgramFileName);
                    else
                        p_lastProgram = program = ZOEProgramLoader.LoadSourceFiles(zoeProgram);
                }
                else
                    p_lastProgram = program = fullZoeProgram;
                if(p_interactiveOnly) MakeProgramBackup();
                //Falta chequear la version del programa coincida con la 
                //version soportada por el compilador.
                if (program != null)
                {
                    //2º) Obtengo interfaces a la los modulos de salida
                    if (!PrepareOutputModules()) return false;
                    if (p_interactiveOnly)
                    {
                        if (p_interactiveOutputModule == null)
                        {
                            p_errorCollection.AddError(new Error("Output module for interactive compilation not found."));
                            return false;
                        }
                    }
                    //If Show Debug DTE Window is enabled
                    if (p_showInternalDebuger) ShowDebugWindow();

                    //3º) Ejecuto los ciclos de compilación
                    p_currentCompileCicle = 0;
                    if (CompileCicle(program))
                    {
                        //Si solo estoy agregando extensiones retorno.
                        if (p_addExtensions) return true;
                        //Si no continuo :-)
                        if (!p_interactiveOnly)
                        {
                            //4º) Termino la compilación pasando el resultado a la libreria de modulos de salida
                            return RenderAndBuild();
                        }
                        else
                            return RenderInteractiveOnly();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    p_returnErrorMessage = "No se ha podido cargar el programa \""+p_xplProgramFileName+"\" indicado.";
                    return false;
                }
            }
            catch (Exception e)
            {
                //OK, no es muy util capturar para solo lanzar de nuevo el error
                throw e;
            }
        }

        private void MakeProgramBackup()
        {
            p_originalSourceProgram = new XplDocument[p_lastProgram.Length];
            for (int n = 0; n < p_lastProgram.Length; n++)
            {
                p_originalSourceProgram[n] =  (XplDocument) p_lastProgram[n].Clone();
            }
        }
        /// <summary>
        /// Renderiza el resultado de la compilación interactiva
        /// </summary>
        private bool RenderInteractiveOnly()
        {
            // PENDIENTE : Revisar esto!
            XplNodeList sourceFiles = ((XplLayerDZoeProgramConfig)p_lastProgram[0].get_DocumentData().get_Config().get_Content())
                .get_SourceFile();
            XplDocument sourceProgram = null;

            for (int n = 1; n < p_lastProgram.Length; n++) 
            {
                XplSourceFile sourceFile = (XplSourceFile)sourceFiles.GetNodeAt(n - 1);
                if (p_renderOriginalProgram) sourceProgram = p_originalSourceProgram[n];
                else sourceProgram = p_lastProgram[n];

                if (sourceProgram.get_DocumentData().get_DocumentType() == XplDocumenttype_enum.LAYERD_ZOE_DOC)
                {
                    if (!p_outputModulesLibrary.BuildSourceFile(
                        sourceFile.get_fileName(), sourceProgram, p_interactiveOutputModule, "Meta D++",
                        null, Path.GetDirectoryName(sourceFile.get_fileName()) ))
                        return false;
                }
            }
            return true;
        }

        private bool RenderAndBuild()
        {

            // PENDIETE: primero debo convertir el documento resultado en código
            // ZOE Extendido de acuerdo a los requerimientos del generador de código.

            if (p_errorCollection.get_ErrorsCount() > 0 && this.p_inyectedCodeDebug)
            {
                //generate inyected code detailed debug with the help of interactive output modules
                if (p_interactiveOutputModule != null)
                {
                    IEZOERender renderModule = p_interactiveOutputModule.GetEZOERenderModuleInstance();
                    if (renderModule != null)
                    {
                        string programName = Path.GetFileNameWithoutExtension(
                            ((XplLayerDZoeProgramConfig)p_lastProgram[0].get_DocumentData().get_Config().get_Content()).get_defaultOutputFileName() );
                        renderModule.SetOutputFileName(programName + ".debug.dpp");
                        renderModule.SetOutputPath(p_outputPath);
                        renderModule.SetEZOEInputDocument(p_lastResultDocument);
                        if (renderModule.SetZoeErrorListToMap(p_errorCollection))
                        {
                            if (!renderModule.StartParseDocument(true, null, null))
                            {
                                Error newError = new Error("Generation of inyected code debug information was unsuccessful.");
                                newError.set_ErrorLevel(ErrorLevel.Ten);
                                newError.set_ErrorSource(ErrorSource.Core);
                                p_errorCollection.AddError(newError);
                            }
                        }
                        else
                        {
                            Error newError = new Error("Interactive output module does not support generation of inyected code debug.");
                            newError.set_ErrorLevel(ErrorLevel.Ten);
                            newError.set_ErrorSource(ErrorSource.Core);
                            p_errorCollection.AddError(newError);
                        }
                    }
                }
                else
                {
                    Error newError = new Error("Interactive output module to generate detailed inyected code debug not found or not set.");
                    newError.set_ErrorLevel(ErrorLevel.Ten);
                    newError.set_ErrorSource(ErrorSource.Core);
                    p_errorCollection.AddError(newError);
                }
            }

            if (p_errorCollection.get_ErrorsCount() == 0 || p_ignoreAllErrorsAndBuild)
            {
                if (p_outputModulesLibrary.BuildProgram(
                    (XplLayerDZoeProgramConfig)p_lastProgram[0].get_DocumentData().get_Config().get_Content(),
                    p_lastResultDocument, p_runtimeOutputModule, p_outputPlatform,
                    p_outputPlatformBuildArguments, p_outputPlatformRenderArguments, p_outputPath, p_renderIntermediateOutputOnly))
                {
                    return true;
                }
                else
                {
                    //Hubo errores
                    IErrorCollection errores = p_outputModulesLibrary.GetLastParseErrors();
                    bool flagErrores = errores != null ? errores.get_TotalErrorsCount() > 0 : false;
                    if (flagErrores)
                        p_errorCollection.Merge(errores);

                    return !flagErrores;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region PrepareOutputModules, TryPlatformAliases
        /// <summary>
        /// Obtiene interfaces a los dos modulos de salida necesarios para la compilación
        /// del programa ZOE.
        /// 1 - El Modulo de Salida para la Plataforma de Tiempo de Compilación
        /// 2 - El Modulo de Salida para la Plataforma de Tiempo de Ejecución Final
        /// </summary>
        private bool PrepareOutputModules()
        {
            p_outputModulesLibrary = new OutputModulesLibrary();
            //PENDIENTE : hacer funcionar la libreria de modulos de salida.
            if (p_outputModulesLibrary.ReadOutputModulesInfo())
            {
                p_compileTimeOutputModule = p_outputModulesLibrary.get_OutputModuleForPlatform(p_compilationPlatform);
                if (p_compileTimeOutputModule == null)
                {
                    p_errorCollection.AddError(new Error("Output Module for Compile Time '" + p_compilationPlatform + "' Platform was not found.", "Modulo de salida para la plataforma \"" + p_compilationPlatform + "\" no fue encotnrado."));
                    return false;
                }
                p_runtimeOutputModule = p_outputModulesLibrary.get_OutputModuleForPlatform(p_outputPlatform);
                if (p_runtimeOutputModule == null)
                {
                    p_runtimeOutputModule = TryPlatformAliases();
                    if (p_runtimeOutputModule == null)
                    {
                        p_errorCollection.AddError(new Error("Output Module for '" + p_outputPlatform + "' Output Platform was not found.", "Modulo de salida para la plataforma \"" + p_outputPlatform + "\" no fue encontrado."));
                        return false;
                    }
                }
                //TODO : this doesn't have to be hardcoded!!! Must take this from source file or compiler parameter
                //maybe use compiler parameter and if it's not provided use information on source program
                p_interactiveOutputModule = p_outputModulesLibrary.get_OutputModuleForPlatform("Meta D++");
            }
            else
            {
                p_errorCollection.AddError(new Error("Error reading Output Modules info : "+p_outputModulesLibrary.get_ErrorStr(), ""));
                return false;
            }
            return true;
        }
        private IEZOEOutputModuleServices TryPlatformAliases()
        {
            //PENDIENTE : intentar obtener un modulo de salida para los
            //alias de plataforma declarado en el programa a compilar.
            return null;
        }
        #endregion

        #region CompileCicle, RecompileParameterDocument, RequireCicle
        protected bool CompileCicle(XplDocument[] program)
        {
            bool result;
            p_currentCompileCicle++;
            if (p_showFullDebugInfo) WriteDebugTextLine("Compiling Cicle Nº" + p_currentCompileCicle + ".");
            if (p_currentCompileCicle == 1)
            {
                Debug.Assert(
                    program[0].get_DocumentData().get_DocumentType() == XplDocumenttype_enum.LAYERD_ZOE_PROG,
                    "Error Interno: El primer documento en el grupo de compilación no es un Documento de Programa ZOE."
                    );
                p_originalProgram = program[0];
            }
            //1º) Realizo el analisis semántico
            SemanticAnalizer analizer;
            if (p_currentSemanticAnalizer != null && p_persistentSemanticAnalizer)
                analizer = p_currentSemanticAnalizer;
            else
                analizer = new SemanticAnalizer();
            if (p_persistentSemanticAnalizer) p_currentSemanticAnalizer = analizer;
            
            analizer.set_ShowFullDebugInfo(p_showFullDebugInfo);
            analizer.set_ShowInternalTimes(p_showInternalTimes);
            analizer.set_PersistentStructures(p_persistentSemanticAnalizer);
            analizer.set_CompileTimeOutputModule(p_compileTimeOutputModule);
            analizer.set_RuntimeOutputModule(p_runtimeOutputModule);
            analizer.set_ErrorCollection(p_errorCollection);
            analizer.set_IgnoreErrorsOnImportedTypes(p_ignoreErrorsOnImportedTypes);
            analizer.set_CurrentClientCore(this);
            ClassfactoryLibrary cflib = new ClassfactoryLibrary(WorkingPath);
            cflib.CurrentClientCore = this;
            analizer.set_ClassfactorysDocument(cflib.LoadClassfactorys(p_compilationPlatform));

            if (analizer.ParseSemantic(program, p_buildingExtension, p_interactiveOnly))
            {
                ExtensionData []extensions=analizer.get_LastParseExtensionSections();
                p_lastTypesTable = analizer.get_TypesTable();
                XplDocument programDTE = analizer.get_LastParseDTE();
                if (p_debugWindow != null)
                    p_debugWindow.CurrentDTE = programDTE;

                //2º) Genero los Modulos de Extension Dinámica
                if (!p_interactiveOnly)
                {
                    if (extensions != null && !p_donotBuildExtensions)
                    {
                        //Si estoy agregando extensiones limpio los errores.
                        if (p_addExtensions) p_errorCollection.Clear();
                        if (p_showFullDebugInfo) WriteDebugTextLine("Compiling Extensions (" + extensions.Length + ").");
                        int n = 0;
                        foreach (ExtensionData extension in extensions)
                        {
                            n++;
                            if (!cflib.AddExtensionToLibrary(extension, n, p_compilationPlatform))
                            {
                                if (p_showFullDebugInfo) WriteDebugTextLine("Error compiling extension (" + n + ").");
                                Error error = new Error("Error compiling extension (" + n + ").", "Error compilando la extension (" + n + ").");
                                error.set_ErrorType(ErrorType.CodeGenerationError);
                                error.set_ErrorSource(ErrorSource.Core);
                                p_errorCollection.AddError(error);
                                return false;
                            }
                            else
                            {
                                if (!p_silentMode)
                                    WriteDebugTextLine("Extension Added: " + extension.Name + ".");
                            }
                        }
                        cflib.SaveDatabase();
                        if (p_showFullDebugInfo) WriteDebugTextLine("End Compilation of Extensions.");
                        //Si solo estoy agregando extensiones retorno
                        if (p_addExtensions) return true;
                    }
                }
                //3º)Separo el DTE en Subprograma Virtual y Documento Parametro
                XplDocument virtualSubprogram = null;
                XplDocument parameterDocument = null;
                DTECodeSplitter splitter = new DTECodeSplitter();
                if (splitter.SplitDTE(programDTE, p_errorCollection, analizer.get_TypesTable(), analizer.get_CandidateStructuresCollection(), p_interactiveOnly))
                {
                    virtualSubprogram = splitter.get_LastSplitVirtualSubprogram();
                    parameterDocument = splitter.get_LastSplitParameterDocument();
                    //PENDIENTE : Elimino del documento parametro el espacio de nombre zoe.lang
                    //revisar si esto se hara de esta forma.
                    XplNodeList zoeNS = parameterDocument.FindNodes("/Namespace[name='zoe::lang']");
                    foreach (XplNode node in zoeNS)
                        parameterDocument.get_DocumentBody().Children().Remove(node);

                    //4º)Compilo el Subprograma Virtual
                    if (!splitter.IsLastSubprogramNull())
                    {
                        BuildingControler buildingControler = new BuildingControler();
                        buildingControler.FactoriesLibrary = cflib;
                        buildingControler.CurrentClientCore = this;
                        buildingControler.VSPArgumentVector = splitter.get_LastArgumentVector();
                        buildingControler.VSPRIPVector = splitter.get_LastRIPVector();
                        buildingControler.VSContextVector = splitter.get_LastContextVector();
                        if (p_showFullDebugInfo) WriteDebugTextLine("Running Compile Time Nº" + p_currentCompileCicle + ".");
                        if (buildingControler.RunCompileTime(
                            virtualSubprogram,
                            parameterDocument,
                            program,
                            p_outputPlatform,
                            p_compilationPlatform
                            ))
                        {
                            //elimino la referencia a la ultima tabla de tipos
                            p_lastTypesTable = null;
                            p_lastResultDocument = parameterDocument;
                            if (p_showFullDebugInfo) WriteDebugTextLine("End Compile Time Nº" + p_currentCompileCicle + ".");
                            //5º)Recompilo el Documento Parametro
                            //if (!p_interactiveOnly)
                            result = RecompileParameterDocument(parameterDocument, p_originalProgram);
                            //else
                            //    result = true;
                        }
                        else
                        {
                            if (p_showFullDebugInfo) WriteDebugTextLine("End Compile Time Nº" + p_currentCompileCicle + ".");
                            p_returnErrorMessage = "No se pudo realizar la Fabricación del Tiempo de Compilación Nº" + p_currentCompileCicle + ".";
                            result = false;
                        }
                    }
                    else
                    {
                        //Virtual Subprogram is null
                        if (p_buildingExtension)
                        {
                            SectionCollection sections = analizer.get_LastParseSections();
                            if (sections != null)
                            {
                                //Proceso las expresiones writecode
                                foreach(Section section in sections.get_IList())
                                    if(section.WritecodeExpressions.Count>0)
                                        ProcessWritecodeExpressions(section);
                            }
                        }
                        p_lastResultDocument = parameterDocument;
                        result = true;
                    }
                    if (extensions != null && p_donotBuildExtensions && p_checkSemanticOfExtensions)
                    {
                        foreach (ExtensionData extension in extensions)
                        {
                            ClassfactoryModuleGenerator mg = new ClassfactoryModuleGenerator();
                            mg.CurrentClientCore = this;
                            if (mg.CompileExtension(
                                extension, p_outputPlatform, "none",
                                ClassfactoryModuleGenerator.ExtensionModuleType.dll))
                            {
                                XplNodeList.CopyNodesAtEnd(extension.Document.get_DocumentBody().Children(),
                                    p_lastResultDocument.get_DocumentBody().Children());
                            }
                        }
                    }
                }
                else
                {
                    if (p_showFullDebugInfo) WriteDebugTextLine("Error while splitting of Compile Cicle Nº" + p_currentCompileCicle + ".");
                    p_returnErrorMessage = "No se pudo realizar la separación del Documento de Tiempo de Ejecución del Tiempo de Compilacion Nº" + p_currentCompileCicle + ".";
                    return false;
                }
            }
            else
            {   //Error no recuperable durante el analisis semántico
                return false; //<-- CORRECTO
            }
            return result;
        }
        protected bool RecompileParameterDocument(XplDocument parameterDocument, XplDocument originalProgram)
        {
            //Debe recompilar el documento parametro llamando CompileCicle pero
            //antes construir un programa Zoe Adecuado            
            XplDocument[] prog = new XplDocument[2];
            prog[0] = originalProgram; //Seteo el programa
            prog[1] = parameterDocument; //Establezco el código al contenido del doc parametro
            // Persisto los errores permanentes
            ErrorCollection newErrors = new ErrorCollection();
            foreach(IError newError in p_errorCollection)
                if(newError.get_PersistentError())newErrors.AddError(newError);
            p_errorCollection = newErrors;
            //Llamo a compilecicle
            return CompileCicle(prog);
        }
        #endregion

        #region Process Writecode expression
        private void ProcessWritecodeExpressions(Section section)
        {
            ArrayList wcs = section.WritecodeExpressions;
            XplWriteCodeBody wc = null;
            XplInitializerList args = null;
            for (int n = 0; n < wcs.Count;n+=2)
            {
                wc = (XplWriteCodeBody)wcs[n];
                args = (XplInitializerList)wcs[n + 1];
                //Transformo
                string tempCode = ZoeHelper.WriteToString(wc).Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\\&quot;", "\\\\&quot;"); ;
                XplExpression targetNode = (XplExpression)wc.get_Parent();
                targetNode.set_Content(
                    MakeCastExpression(wc, MakeWritecodeCall(tempCode, args)));
            }
        }

        private XplNode MakeCastExpression(XplWriteCodeBody wc, XplNode xplNode)
        {
            XplCastexpression cast = XplExpression.new_cast();
            cast.set_type(ZoeHelper.MakeTypeFromString("^_DotNET::LayerD::CodeDOM::" + wc.get_Content().get_TypeName()));
            cast.set_e(new XplExpression(xplNode));
            return cast;
        }
        /// <summary>
        /// Arma una llamada a funcion de la forma:
        ///  _writecode("contenido_tempCode", args1, args2, ..., argsn)
        /// </summary>
        private XplNode MakeWritecodeCall(string tempCode, XplInitializerList vars)
        {
            XplFunctioncall fc = XplExpression.new_fc();
            fc.set_l(ZoeHelper.MakeSimpleNameExpression("DotNET::LayerD::CodeDOM::ZoeHelper::InternalWritecodeImpl"));
            XplExpressionlist args = XplFunctioncall.new_args();
            //1º argumento el string
            XplLiteral lit = XplExpression.new_lit();
            lit.set_type(XplLiteraltype_enum.STRING);
            lit.set_str(tempCode);
            XplExpression exp = XplExpressionlist.new_e();
            exp.set_Content(lit);
            args.Children().InsertAtEnd(exp);
            //2º Ahora los nombres de las variables capturadas con el formato
            //new object[] { a, v, c, b }
            XplNewExpression nexp = XplExpression.new_new();
            nexp.set_type(ZoeHelper.MakeTypeFromString("[]^_$OBJECT$"));
            vars.set_array(true);
            nexp.set_init(vars);
            exp = XplExpressionlist.new_e();
            exp.set_Content(nexp);
            args.Children().InsertAtEnd(exp);
            //3º Agumento __context.Node
            //XplBinaryoperator bo = XplExpression.new_bo();
            //bo.set_op(XplBinaryoperators_enum.M);
            XplNode __context = XplExpression.new_n();
            //XplNode Node = XplExpression.new_n();
            __context.set_Value("__context");
            //Node.set_Value("Node");
            //bo.set_l(new XplExpression(__context));
            //bo.set_r(new XplExpression(Node));
            exp = XplExpressionlist.new_e();
            exp.set_Content(__context);
            args.Children().InsertAtEnd(exp);
            fc.set_args(args);
            return fc;
        }
        #endregion

        public void set_AddExtensions(bool value)
        {
            p_addExtensions = value;
        }

        public XplNodeList get_InstalledExtensions()
        {
            ClassfactoryLibrary cfl = new ClassfactoryLibrary(this.WorkingPath);
            return cfl.GetExtensionsList();
        }

        public bool ClearAllExtensions()
        {
            ClassfactoryLibrary cfl = new ClassfactoryLibrary(this.WorkingPath);
            return cfl.RemoveAllExtensions();
        }

        public int RemoveExtension(string extensionBaseName)
        {
            ClassfactoryLibrary cfl = new ClassfactoryLibrary(this.WorkingPath);
            return cfl.RemoveExtension(extensionBaseName);
        }

        internal bool get_CheckSemanticOfExtensions()
        {
            return p_checkSemanticOfExtensions;
        }

        internal bool get_DonotBuildExtensions()
        {
            return p_donotBuildExtensions;
        }

        /// <summary>
        /// Establece que se esta construyendo una extension (llamado desde ModuleGenerator).
        /// 
        /// Cuando se activa esta bandera se convierten las expresiones writecode.
        /// </summary>
        internal void set_BuildingExtension(bool value)
        {
            p_buildingExtension = value;
        }
        /// <summary>
        /// Retorna si se esta construllendo una extension
        /// </summary>
        internal bool get_BuildingExtension()
        {
            return p_buildingExtension;            
        }
    }
}
