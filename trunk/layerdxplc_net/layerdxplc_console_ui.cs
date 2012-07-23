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
*  Zoe Console User Interface
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
using System.Collections;
using System.Globalization;
using LayerD.CodeDOM;
using LayerD.ZOECompiler;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace LayerD.ZOECompilerUI
{

    class ArgumentsData
    {
        public const bool BETA = true;

        #region Private Data
        /*Indica si se ejecuta sólo compilación interactiva.*/
        private bool p_interactive;
        /*Identifica el nombre de archivo del programa fuente.*/
        private string p_inputProgram;
        /*Indica los archivos fuentes cuando no se proporciona un archivo de programa ZOE.*/
        private ArrayList p_sourceFiles = new ArrayList();
        /*Indica si hubo errores en los argumentos proporcionados.*/
        private bool p_argumentsError;
        /*Una cadena con la descripción del error.*/
        private string p_errorStr;
        /*Cadena identificadora de la plataforma a construir, si no se indica
         se construye el programa para todas las plataformas indicadas en el archivo
         de programa ZOE, si no se proporciona un programa ZOE se construye para la
         plataforma por defecto*/
        private string p_outputPlatform;
        /*Indica si se construye el programa ZOE para los fuentes pasados como argumentos o no.*/
        private bool p_buildDefaultProgram;
        /*Indica el nombre del archivo de salida que se quiere construir, si no se 
         especifica se utiliza el indicado en el archivo de programa ZOE*/
        private string p_outputFileName;
        /*El nombre para el programa, se utiliza sólo cuando se construye el
         programa ZOE a partir de fuentes ordinarios*/
        private string p_programName;
        /*Indica el path de salida para el modulo a construir. Si no se proporciona se 
         utiliza el path por defecto*/
        private string p_outputPath;
        /*Indica que se quiere construir una libreria, en general una libreria dinámica*/
        private bool p_buildLibrary;
        /*Indica si se Construye el programa para todas las plataformas, por
         defecto es verdadero*/
        private bool p_buildAllPlatforms = true;
        /*Sólo genera el código de salida para cada plataforma sin construir el programa*/
        private bool p_renderIntermediateOutputOnly;
        /*Generar codigo inyectado para depuración*/
        private bool p_inyectedCodeDebug;
        /*Intenta construir el programa aún cuando existan errores.*/
        private bool p_buildWithErrors;
        /*No muestra los Errores si es verdadero.*/
        private bool p_donotShowErrors;
        /*No muestra los Warnings si es verdadero.*/
        private bool p_donotShowWarnings;
        /*Indica ignorar errores en tipos importados*/
        private bool p_ignoreErrorsOnImportedTypes;
        /*Indica si muestra las advertencias generadas por el Modulo de Salida*/
        private bool p_showOutputModulesWarning;
        /*Argumentos a pasar al Modulo de Salida durante la construcción.*/
        private string p_outputPlatformBuildArguments;
        /*Argumentos a pasar al Renderizador de Código durante la construcción.*/
        private string p_outputPlatformRenderArguments;
        /*Indica si se muestra información de depuración completa.*/
        private bool p_showFullDebugInfo;
        /*Indica si se muestra la información de los tiempos internos de procesamiento.*/
        private bool p_showInternalTimes;
        /*Mostrar el debuger grafico interno del compilador*/
        private bool p_showInternalDebuger;
        /*Indica si se oculta el copyright del compilador.*/
        private bool p_showCopyright;
        /*Indica si se muestra la información de versión de los componentes.*/
        private bool p_showComponentsInfo;
        /*Indica modo silencioso, sin mensajes abundantes.*/
        private bool p_silentMode;
        /*Indica que solo se compilar las extensiones del programa y anexaran a la librería de Classfactorys.*/
        private bool p_addExtensions;
        /*Indica modo de eliminación de extensiones*/
        private bool p_removeExtensions;
        /*Los nombres de base de las extensiones a remover*/
        private string[] p_extensionsToRemove;
        /*Indica remover todas las extensiones de la librería de Classfactorys.*/
        private bool p_clearAllExtensions;
        /*Indica listar información sobre todas las extensiones instaladas en la librería de Classfactorys.*/
        private bool p_listExtensions;
        /*If we must wait until a debbuger is attached*/
        private bool p_waitForDebugger;
        /*Set the compile time number in which the extensions added will work*/
        private int p_fromCompileTimeCycle;
        /*Dumps all compiles cycles errors and warnings*/
        private bool p_dumpAllCompileCyclesErrors;
        /*Dumps all compiles cycles Zoe current DTE*/
        private bool p_dumpAllCompileCyclesZoe;
        /*Dumps all compiles cycles current DTE rendered as Meta D++*/
        private bool p_dumpAllCompileCyclesDpp;
        /*Dumps all compiles cycles types table*/
        private bool p_dumpAllCompileCyclesTypesTable;
        /*Dumps all compiles cycles current DTE using specified platform output module.
         Used to render in other outputs than Zoe or Meta D++*/
        private string p_dumpAllCompileCyclesWithPlatform;
        /*Dumps compile time function call info for debugging porpuses.*/
        private bool p_dumpCompileTimeFunctionCalls;
        #endregion

        #region Constructor
        public ArgumentsData(string[] args)
        {
            string opcion = "", argData = ""; ;
            foreach (string arg in args)
            {
                if (arg[0] != '-')
                {
                    string extension = Path.GetExtension(arg).ToLower(CultureInfo.InvariantCulture);
                    //Es un nombre de archivo fuente
                    if (p_inputProgram == null && p_sourceFiles.Count==0 && (extension==".pzoe" || extension==".pxpl") )
                    {
                        p_inputProgram = arg;
                        if (!File.Exists(p_inputProgram))
                        {
                            if (!Util.IsSpanishCulture())
                                p_errorStr = "File \"" + p_inputProgram + "\" does not exists.";
                            else
                                p_errorStr = "El archivo \"" + p_inputProgram + "\" no existe.";
                            p_argumentsError = true;
                            return;
                        }
                    }
                    else
                    {
                        //Se proporciono más de un archivo fuente, es un listado
                        //de fuentes ZOE ordinarios, no se proporciona programa.
                        if (p_sourceFiles.Count == 0)
                        {
                            //p_sourceFiles.Add(arg);
                            p_inputProgram = null;
                            p_buildDefaultProgram = true;
                        }
                        if (!File.Exists(arg))
                        {
                            if (!Util.IsSpanishCulture())
                                p_errorStr = "File \"" + arg + "\" does not exists.";
                            else
                                p_errorStr = "El archivo \"" + arg + "\" no existe.";
                            p_argumentsError = true;
                            return;
                        }
                        p_sourceFiles.Add(arg);
                    }
                }
                else
                {
                    ProcessModifier(opcion, argData, arg);
                }
            }
            //PENDIENTE : Desactivar esto en versiones más avanzadas.
            if (BETA)
            {
                //banderas levantadas para falicitar el uso en modo beta.....
                p_ignoreErrorsOnImportedTypes = true;
            }

            if (p_inputProgram == null && p_sourceFiles.Count == 0
                && !p_removeExtensions && !p_clearAllExtensions && !p_listExtensions && !p_showComponentsInfo)
            {
                Util.Write(
                    "Must provide at least one source filename.",
                    "Debe proporcionar al menos un nombre de archivo fuente."
                    );
                p_argumentsError = true;
                return;
            }
            if (p_programName == null)
            {
                if (p_outputFileName == null && p_sourceFiles.Count > 0)
                {
                    p_programName = Path.GetFileNameWithoutExtension((string)p_sourceFiles[0]);
                }
                else
                {
                    p_programName = Path.GetFileNameWithoutExtension(p_outputFileName);
                }
            }
            if (p_buildDefaultProgram && p_outputFileName == null)
                if (!p_buildLibrary) p_outputFileName = p_programName + ".exe";
                else p_outputFileName = p_programName + ".dll";
            if (p_outputPlatform == null) p_outputPlatform = "DotNET 1.0";
        }

        private void ProcessModifier(string opcion, string argData, string arg)
        {
            int index = 0;
            //Es un modificador
            index = arg.IndexOf(':');
            if (index > 0)
            {
                opcion = arg.Substring(1, index - 1).ToLower(CultureInfo.InvariantCulture);
                argData = Clean(arg.Substring(index + 1));
            }
            else
            {
                opcion = arg.Substring(1).ToLower(CultureInfo.InvariantCulture);
                argData = "";
            }
            switch (opcion)
            {
                case "ae":
                case "addextensions":
                    p_addExtensions = true;
                    break;
                case "re":
                case "removeextensions":
                    p_removeExtensions = true;
                    if (argData != "")
                    {
                        p_extensionsToRemove = argData.Split(',');
                    }
                    else
                    {
                        p_argumentsError = true;
                        Util.Write("You must name comma separated extensions to remove.", "Debe indicar los nombres de las extensiones a remover separados por coma.");
                        p_errorStr = "You must name extensions to remove.";
                    }
                    break;
                case "cae":
                case "clearallextensions":
                    p_clearAllExtensions = true;
                    break;
                case "le":
                case "listextensions":
                    p_listExtensions = true;
                    break;
                case "i":
                case "interactive":
                    p_interactive = true;
                    break;
                case "p":
                case "platform":
                    p_outputPlatform = argData;
                    p_buildAllPlatforms = false;
                    break;
                case "bp":
                case "buildprogram":
                    p_buildDefaultProgram = true;
                    break;
                case "pn":
                case "programname":
                    p_programName = argData;
                    break;
                case "o":
                case "outputfilename":
                    p_outputFileName = argData;
                    break;
                case "opath":
                case "outputpath":
                    p_outputPath = argData;
                    break;
                case "lib":
                case "buildlibrary":
                    p_buildLibrary = true;
                    break;
                case "ball":
                case "buildall":
                    p_buildAllPlatforms = true;
                    break;
                case "ro":
                case "renderonly":
                    p_renderIntermediateOutputOnly = true;
                    break;
                case "icd":
                case "inyectedcodedebug":
                    p_inyectedCodeDebug = true;
                    break;
                case "bwe":
                case "buildwitherrors":
                    p_buildWithErrors = true;
                    break;
                case "he":
                case "hideerrors":
                    p_donotShowErrors = true;
                    break;
                case "hw":
                case "hidewarnings":
                    p_donotShowWarnings = true;
                    break;
                case "ieoit":
                case "ignoreerrorsonimportedtypes":
                    p_ignoreErrorsOnImportedTypes = true;
                    break;
                case "somw":
                case "showoutputmodulewarings":
                    p_showOutputModulesWarning = true;
                    break;
                case "ba":
                case "buildargs":
                    p_outputPlatformBuildArguments = argData;
                    break;
                case "ra":
                case "renderargs":
                    p_outputPlatformRenderArguments = argData;
                    break;
                case "sfd":
                case "showfulldebug":
                    p_showFullDebugInfo = true;
                    break;
                case "sit":
                case "showinternaltimes":
                    p_showInternalTimes = true;
                    break;
                case "sid":
                case "showinternaldebuger":
                    p_showInternalDebuger = true;
                    break;
                case "scopy":
                case "showcopyright":
                    p_showCopyright = true;
                    break;
                case "scomponents":
                case "showcomponents":
                    p_showComponentsInfo = true;
                    break;
                case "s":
                case "silent":
                    p_silentMode = true;
                    break;
                case "wfd":
                case "waitfordebbuger":
                    p_waitForDebugger = true;
                    break;
                case "ict":
                case "initcompiletime":
                    p_fromCompileTimeCycle = Convert.ToInt32(argData, CultureInfo.InvariantCulture);
                    break;
                case "dacce":
                case "dumpallcompilecycleserrors":
                    p_dumpAllCompileCyclesErrors = true;
                    break;
                case "daccz":
                case "dumpallcompilecycleszoe":
                    p_dumpAllCompileCyclesZoe = true;
                    break;
                case "daccd":
                case "dumpallcompilecyclesdpp":
                    p_dumpAllCompileCyclesDpp = true;
                    break;
                case "dacctt":
                case "dumpallcompilecyclestypestable":
                    p_dumpAllCompileCyclesTypesTable = true;
                    break;
                case "daccwp":
                case "dumpallcompilecycleswithplatform":
                    p_dumpAllCompileCyclesWithPlatform = argData;
                    break;
                case "dfc":
                case "dumpcompiletimefunctioncalls":
                    p_dumpCompileTimeFunctionCalls = true;
                    break;
                default:
                    Util.Write("Option -" + opcion + " unrecognized.", "Opción -" + opcion + " no reconozida.");
                    break;
            }
        }
        #endregion

        #region Metodos Varios de Ayuda
        public static void ShowArgumentsHelp()
        {
            Util.Write("Usage mode:","Modo de uso:");
            Util.Write("([ZOE Program Source] | [ZOE Source Files]) [Options]","([Programa ZOE] | [Archivos Fuente ZOE]) [Opciones]");
            Util.Write("");
            Util.Write("Options:","Opciones:");
            Util.Write("\t-i | -interactive");
            Util.Write("\t\tRun interactive compilation",
                "\t\tEjecutar compilación Interactiva.");
            Util.Write("\t-p:[platform] | -platform:[platform]");
            Util.Write("\t\tSet build target platform, default if not specified.",
                "\t\tEstablece la plataforma de construcción destino.");
            Util.Write("\t-bp | -buildprogram");
            Util.Write("\t\tAutogenerate ZOE Program for specified source files.\n\t\tUse when source ZOE Program is not provided."
                ,"\t\tAutogeneración del Programa ZOE para los fuentes especificados.\n\t\tUsado cuando no se proporciona un Programa ZOE.");
            Util.Write("\t-pn:[program name] | -programname:[program name]");
            Util.Write("\t\tA Name for the autogenerated ZOE Program.\n\t\tRequired when -bp is used.",
                "\t\tUn Nombre para el Programa ZOE autogenerado.\n\t\tRequerido cuando se usa la opción -bp.");
            Util.Write("\t-o:[output filename] | -outputfilename:[output filename]");
            Util.Write("\t\tOutput filename. Optional, not required.",
                "\t\tNombre del Archivo de Salida. Opcional, no requerido.");
            Util.Write("\t-opath:[output path] | -outputpath:[output path]");
            Util.Write("\t\tPath used as output for intermediate code and final generation.",
                "\t\tPath usado como salida para el código intermedio \n\t\ty la generación final.");
            Util.Write("\t-lib | -buildlibrary");
            Util.Write("\t\tBuild dynamic library. If not specified executable is default.",
                "\t\tConstruir una libreria dinámica.");
            Util.Write("\t-ball | -buildall");
            Util.Write("\t\tBuild all specified output platforms.",
                "\t\tConstruir para todas las plataformas de salida especificadas.");
            Util.Write("\t-ae | -addextensions");
            Util.Write("\t\tAdd extensions to Classfactorys library and exit.",
                "\t\tAgerga extensiones a la librería de Classfactorys y termina.");
            Util.Write("\t-re:[ext1,..,extn] | -removeextensions:[ext1,..,extn]");
            Util.Write("\t\tRemove extensions from Classfactorys library.",
                "\t\tElimina extensiones de la librería de Classfactorys.");
            Util.Write("\t-cae | -clearallextensions");
            Util.Write("\t\tRemove all extensions installed on Classfactorys library.",
                "\t\tEliminar todas las extensiones instaladas\n\t\ten la librería de Classfactorys.");
            Util.Write("\t-le | -listextensions");
            Util.Write("\t\tList all extensions installed on Classfatorys library.",
                "\t\tListar todas las extensiones instaladas\n\t\ten la librería de Classfactorys.");
            Util.Write("\t-ro | -renderonly");
            Util.Write("\t\tDo not generate module, intermediate code only.",
                "\t\tNo construye el modulo, sólo genera código intermedio.");
            Util.Write("\t-icd | -inyectedcodedebug");
            Util.Write("\t\tGenerate inyected code debug and related errors.",
                "\t\tGenerar codigo inyectado de depuración y errores relacionados.");
            Util.Write("\t-bwe | -buildwitherrors");
            Util.Write("\t\tTry to build even with errors. For debug purposes.",
                "\t\tIntenta construir aún con errores. Usado para depuración.");
            Util.Write("\t-he | -hideerrors");
            Util.Write("\t\tHide errors messages.",
                "\t\tOculta los mensajes de error.");
            Util.Write("\t-hw | -hidewarings");
            Util.Write("\t\tHide warnings messages.",
                "\t\tOculta los mensajes de advertencias.");
            Util.Write("\t-ieoit | -ignoreerrorsonimportedtypes");
            Util.Write("\t\tIgnore errors on imported types.",
                "\t\tIgnorar errores en los tipos importados.");
            Util.Write("\t-somw | -showoutputmodulewarings");
            Util.Write("\t\tShow output module warnings messages.",
                "\t\tMuestra los mensajes de advertencias generados\n\t\tpor el Modulo de Salida.");
            Util.Write("\t-ba:[build argmuents] | -buildargs:[build arguments]");
            Util.Write("\t\tOptional build arguments passed to ZOE code generator.",
                "\t\tArgumentos de construcción opcional pasados\n\t\tal Generador de Código ZOE.");
            Util.Write("\t-ra:[render argmuents] | -renderargs:[render arguments]");
            Util.Write("\t\tOptional render arguments passed to ZOE code generator.",
                "\t\tArgumentos de renderización opcional pasados\n\t\tal Generador de Código ZOE.");
            Util.Write("\t-sfd | -showfulldebug");
            Util.Write("\t\tShow all debug information.",
                "\t\tMuestra toda la información de depuración disponible.");
            Util.Write("\t-sit | -showinternaltimes");
            Util.Write("\t\tShow internal process times.",
                "\t\tMuestra los tiempos internos de procesamiento.");
            Util.Write("\t-sid | -showinternaldebuger");
            Util.Write("\t\tShow internal graphical debuger.",
                "\t\tMuestra el depurador grafico interno.");
            Util.Write("\t-scopy | -showcopyright");
            Util.Write("\t\tShow copyright info.",
                "\t\tMuestra la información de copyright.");
            Util.Write("\t-scomponents | -showcomponents");
            Util.Write("\t\tShow internal components version information.",
                "\t\tMuestra las versiones de los componentes internos.");
            Util.Write("\t-s | -silent");
            Util.Write("\t\tSilent mode. Without non critical messages.",
                "\t\tModo Silencioso, sin mensajes no criticos.");
            Util.Write("\t-wfd | -waitfordebbuger");
            Util.Write("\t\tWait for debbuger to be attached. Allows classfactory debbuging.",
                "\t\tEspera a que un debbuger se enganche al proceso. Permite depurar una classfactory.");
            Util.Write("\t-ict:[compile time] | -initcompiletime:[compile time]");
            Util.Write("\t\tSet the first compile time in which the classfatory will be active.",
                "\t\tEstablece el primer timepo de compilación en el que será activa la classfactory.");
            Util.Write("\t-dacce | -dumpallcompilecycleserrors");
            Util.Write("\t\tDumps errors for every compile cycle in the console output.");

            Util.Write("\t-daccz | -dumpallcompilecycleszoe");
            Util.Write("\t\tDumps Zoe for every compile cycle.");
            Util.Write("\t-daccd | -dumpallcompilecyclesdpp");
            Util.Write("\t\tDumps Meta D++ code for every compile cycle.");
            Util.Write("\t-dacctt | -dumpallcompilecyclestypestable");
            Util.Write("\t\tDumps Types Table info for every compile cycle.");

            // NOT IMPLEMENTED
            // Util.Write("\t-daccwp:[platform] | -dumpallcompilecycleswithplatform:[platform]");
            // Util.Write("\t\tDumps a render for every compile cycle using specified platform code generator.");
            Util.Write("\t-dfc | -dumpcompiletimefunctioncalls");
            Util.Write("\t\tDumps compile time function calls for debug purposes.");
            Util.Write("\t");
            Util.Write("Examples:","Ejemplos:");
            Util.Write("\t\tzoec MyProgram.pzoe -ball -s");
            Util.Write("\t\tzoec MySource1.zoe MySource2.zoe -bp -pn:MyTestProgram");
        }
        private string Clean(string argData)
        {
            argData = argData.Trim();
            if (argData.Length < 3) return argData;
            return argData[0] == '"' ? argData.Substring(1, argData.Length - 2) : argData;
        }
        #endregion

        #region Acceso a propiedades publicas
        public bool DumpCompileTimeFunctionCalls
        {
            get { return p_dumpCompileTimeFunctionCalls; }
        }
        public bool DumpAllCompileCyclesErrors
        {
            get { return p_dumpAllCompileCyclesErrors; }
        }

        public bool DumpAllCompileCyclesZoe
        {
            get { return p_dumpAllCompileCyclesZoe; }
        }
        public bool DumpAllCompileCyclesDpp
        {
            get { return p_dumpAllCompileCyclesDpp; }
        }

        public bool DumpAllCompileCyclesTypesTable
        {
            get { return p_dumpAllCompileCyclesTypesTable; }
        }

        public bool Interactive
        {
            get { return p_interactive; }
        }
        public string InputProgram
        {
            get { return p_inputProgram; }
        }
        public bool WaitForDebbuger
        {
            get { return p_waitForDebugger; }
        }
        public ArrayList SourceFiles
        {
            get { return p_sourceFiles; }
        }
        public bool ArgumentsError{
            get { return p_argumentsError; }
        }
        public string ErrorStr
        {
            get { return p_errorStr; }
        }
        public string OutputPlatform
        {
            get { return p_outputPlatform; }
        }
        public bool BuildLibrary
        {
            get { return p_buildLibrary; }
        }
        public bool BuildDefaultProgram
        {
            get { return p_buildDefaultProgram; }
        }
        public string ProgramName
        {
            get { return p_programName; }
        }
        public string OutputFileName
        {
            get { return p_outputFileName; }
        }
        public string OutputPath
        {
            get { return p_outputPath; }
        }
        public bool BuildAllPlatforms
        {
            get { return p_buildAllPlatforms; }
        }
        public bool RenderIntermediateOutputOnly
        {
            get { return p_renderIntermediateOutputOnly; }
        }
        public bool InyectedCodeDebug
        {
            get { return p_inyectedCodeDebug; }
        }
        public bool BuildWithErrors
        {
            get { return p_buildWithErrors; }
        }
        public bool DonotShowErrors
        {
            get { return p_donotShowErrors; }
        }
        public bool DonotShowWarnings
        {
            get { return p_donotShowWarnings; }
        }
        public bool IgnoreErrorsOnImportedTypes
        {
            get { return p_ignoreErrorsOnImportedTypes; }
        }
        public bool ShowOutputModulesWarning
        {
            get { return p_showOutputModulesWarning; }
        }
        public string OutputPlatformBuildArguments
        {
            get { return p_outputPlatformBuildArguments; }
        }
        public string OutputPlatformRenderArguments
        {
            get { return p_outputPlatformRenderArguments; }
        }
        public bool ShowFullDebugInfo
        {
            get { return p_showFullDebugInfo; }
        }
        public bool ShowInternalTimes
        {
            get { return p_showInternalTimes; }
        }
        public bool ShowInternalDebuger
        {
            get { return p_showInternalDebuger; }
        }
        public bool ShowCopyright
        {
            get { return p_showCopyright; }
        }
        public bool ShowComponentsInfo
        {
            get { return p_showComponentsInfo; }
        }
        public bool SilentMode
        {
            get { return p_silentMode; }
        }
        public bool AddExtensions
        {
            get { return p_addExtensions; }
        }
        public bool RemoveExtensions
        {
            get { return p_removeExtensions; }
        }
        public string[] ExtensionsToRemove
        {
            get { return p_extensionsToRemove; }
        }
        public bool ClearAllExtensions
        {
            get { return p_clearAllExtensions; }
        }
        public bool ListExtensions
        {
            get { return p_listExtensions; }
        }
        public int InitCompileTime
        {
            get { return p_fromCompileTimeCycle; }
        }
        #endregion
    }

    sealed class Util
    {
        public static bool IsSpanishCulture()
        {
            return CultureInfo.CurrentCulture.EnglishName.Contains("Spanish");
        }
        public static void Write()
        {
            Console.WriteLine();
        }
        public static void Write(string text)
        {
            Write(text, text);
        }
        public static void Write(string englishText, string spanishText)
        {
            if (!IsSpanishCulture()) Console.WriteLine(englishText);
            else Console.WriteLine(spanishText!=null && spanishText!=String.Empty ? spanishText : englishText);
        }
    }
	class ZOECConsoleUI{
        public const int TRUE = 0;
        public const int FALSE = 1;

        [STAThread]
        static int Main(string[] args)
        {
            bool exito = true;
            ZOECompilerCore compiler = null;
            ArgumentsData arguments = null;
            try
            {
                //Leo los argumentos
                arguments = new ArgumentsData(args);
                //Muestro info extra
                if (arguments.ShowCopyright) ShowCopyright();
                if (arguments.ShowComponentsInfo)
                {
                    ShowComponentsInfo();
                    return TRUE;
                }

                if (arguments.ArgumentsError)
                {
                    Util.Write("Invalid Arguments!", "¡Argumentos Invalidos!");
                    Util.Write("\t-" + arguments.ErrorStr);
                    Util.Write();
                    ArgumentsData.ShowArgumentsHelp();
                    return FALSE;
                }
                if (!arguments.SilentMode) Util.Write("ZOE Compiler Console User Interface.", "Compilador ZOE - Interfaz de Usuario de Consola.");
                //Si los argumentos son correcto verifico si se debe crear un archivo 
                //de programa.
                XplDocument program = null;
                if (arguments.BuildDefaultProgram)
                {
                    program = BuildDefaultProgram(arguments);
                }
                // create zoe compiler instance
                compiler = new ZOECompilerCore();
                // set compiler working path
                compiler.WorkingPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (arguments.RemoveExtensions)
                {
                    //Modo eliminar extensiones
                    XplNodeList list = compiler.get_InstalledExtensions();
                    foreach (string extBaseName in arguments.ExtensionsToRemove)
                    {
                        int count = compiler.RemoveExtension(extBaseName);
                        if (count > 0)
                        {
                            Util.Write("Extension " + extBaseName + " removed. Classfactorys removed: " + count,
                                "Extension " + extBaseName + " eliminada. Classfactorys eliminadas: " + count);
                        }
                    }
                }
                else if (arguments.ClearAllExtensions)
                {
                    //Modo borrar todas las extensiones
                    if (compiler.ClearAllExtensions())
                    {
                        Util.Write("All extensions were cleared from Classfactorys library.",
                            "Todas las extensiones fueron borradas de la librería de Classfactorys.");
                    }
                    else
                    {
                        ShowErrors(arguments, compiler);
                    }
                }
                else if (arguments.ListExtensions)
                {
                    //Modo listar las extensiones instaladas
                    XplNodeList list = compiler.get_InstalledExtensions();
                    Util.Write("Installed Extensions: " + list.GetLength(), "Extensiones Instaladas: " + list.GetLength());
                    Util.Write();
                    Util.Write("Type FullName, Module Filename, Interactive, Activa",
                        "Nombre de Tipo, Archivo del Modulo, Interactive, Active");
                    Util.Write("---------------------------------------------------",
                        "-------------------------------------------------------");
                    foreach (ClassfactoryData cfd in list)
                    {
                        Util.Write(cfd.get_typeFullName() + ", " +
                        cfd.get_moduleFileName() + ", " +
                        cfd.get_isInteractive().ToString() + ", " +
                        cfd.get_active().ToString());
                    }
                }
                else
                {
                    // set events handler
                    ZoeEventsHandler eventsHandler = new ZoeEventsHandler(arguments);
                    compiler.CoreEvents = eventsHandler;

                    //Seteo los switchs en el compilador
                    compiler.set_TextOutputStream(Console.Out);
                    compiler.set_BuildAllPlatforms(arguments.BuildAllPlatforms);
                    if (!arguments.BuildAllPlatforms)
                        compiler.set_OutputPlatform(arguments.OutputPlatform);
                    compiler.set_IgnoreErrorsAndBuild(arguments.BuildWithErrors);
                    compiler.set_InteractiveOnly(arguments.Interactive);
                    compiler.set_RenderIntermediateOutputOnly(arguments.RenderIntermediateOutputOnly);
                    compiler.set_InyectedCodeDebug(arguments.InyectedCodeDebug);
                    compiler.set_OutputPath(arguments.OutputPath);
                    compiler.set_OutputPlatformBuildArguments(arguments.OutputPlatformBuildArguments);
                    compiler.set_OutputPlatformRenderArguments(arguments.OutputPlatformRenderArguments);
                    compiler.set_ShowFullDebugInfo(arguments.ShowFullDebugInfo);
                    compiler.DumpCompileTimeFunctionCalls = arguments.DumpCompileTimeFunctionCalls;
                    if (arguments.ShowInternalTimes)
                    {
                        compiler.DumpCompileCycleProgress = true;
                        compiler.set_ShowInternalTimes(arguments.ShowInternalTimes);
                    }
                    compiler.ShowInternalDebuger = arguments.ShowInternalDebuger;
                    compiler.set_IgnoreErrorsOnImportedTypes(arguments.IgnoreErrorsOnImportedTypes);
                    compiler.set_SilentMode(arguments.SilentMode);
                    compiler.set_AddExtensions(arguments.AddExtensions);
                    compiler.AddExtensionFromCompileTimeIndex = arguments.InitCompileTime;

                    WaitForDebbuger(arguments.WaitForDebbuger);

                    DateTime initTime = DateTime.Now;
                    //Compilo
                    if (program != null)
                        exito = compiler.CompileProgram(program);
                    else
                        exito = compiler.CompileProgram(arguments.InputProgram);

                    if (exito && arguments.ShowInternalTimes && !arguments.SilentMode)
                        Util.Write("Total Compile Time: " + (DateTime.Now - initTime).ToString(), "Tiempo Total de Compilación: " + (DateTime.Now - initTime).ToString());
                    //Muestro estado
                    if (exito && !arguments.SilentMode) Util.Write("Build success.", "Compilación exitosa.");
                    else if (!exito && !arguments.SilentMode) Util.Write("Unsuccessful build.", "No se pudo compilar con exito.");

                    if (compiler.Errors.get_TotalErrorsCount()>0)
                        ShowErrors(arguments, compiler);
                }
            }
            catch (Exception error)
            {
                Util.Write();
                Util.Write("Error: " + error);

                if (compiler != null && arguments != null)
                    ShowErrors(arguments, compiler);

                exito = false;
            }
            finally
            {
                Console.Out.Flush();
                if (arguments!=null && arguments.ShowFullDebugInfo) Console.ReadKey();
            }
            //Salgo
            if (exito) return TRUE;
            else return FALSE;
        }

        private static void WaitForDebbuger(bool wait)
        {
            if (wait)
            {
                Util.Write(
                    "Waiting for a debbuger to attach. Press Ctrl+C to terminate.",
                    "Esperando a que un depurador se conecte. Presiones Ctrl+C para terminar.");
                while (!System.Diagnostics.Debugger.IsAttached)
                {
                    Thread.Sleep(1000);
                }
                Util.Write("Debbuger connected.", "Depurador conectado.");
            }
        }

        public static void ShowErrors(ArgumentsData arguments, ZOECompilerCore compiler)
        {
            //Muestro los errores
            IErrorCollection errors = compiler.get_ErrorCollection();
            Hashtable currentErrors = new Hashtable();
            if (errors == null) return;
            int count = errors.get_ErrorsCount();
            if (count > 0 && !arguments.DonotShowErrors)
            {
                Util.Write("\nErrors: (" + count + ")\n", "\nErrores: (" + count + ")");
                IError[] allErrors = errors.get_Errors();
                foreach (IError error in allErrors) ShowError(error, currentErrors, arguments.InyectedCodeDebug);
            }
            //Muestro los warnings
            currentErrors.Clear();
            count = errors.get_WarningsCount();
            if (count > 0 && !arguments.DonotShowWarnings)
            {
                Util.Write("\nWarnings: (" + count + ")\n", "\nAdvertencias: (" + count + ")");
                IError[] allWarnings = errors.get_Warnings();
                foreach (IError warning in allWarnings)
                    if (warning.get_ErrorSource() != ErrorSource.OutputModule
                        || (warning.get_ErrorSource() == ErrorSource.OutputModule
                        && arguments.ShowOutputModulesWarning)) ShowError(warning, currentErrors, arguments.InyectedCodeDebug);
            }
        }

        private static void ShowError(IError error, Hashtable currentErrors, bool inyectedCodeDebug)
        {
            ShowError(error, currentErrors, "", inyectedCodeDebug);
        }
        private static void ShowError(IError error, Hashtable currentErrors, string prefix, bool inyectedCodeDebug)
        {
            string[] parts = error.get_ErrorLayerDSourceFileData() != null ? error.get_ErrorLayerDSourceFileData().Split(new char[] { ',' }) : new string[] { "" };
            if (parts.Length > 2) parts[0] = parts[2] + "(" + parts[1] + ")";
            if (parts[0] == String.Empty)
                parts[0] = error.get_ErrorSource().ToString();

            string englishStr = parts[0] + " : " + (error.get_ErrorClass()==ErrorClass.Warning ? "warning" : "error") + " " + error.get_ErrorCode() + " - " + prefix + error.get_ErrorMessage();
            if (!currentErrors.ContainsKey(englishStr))
            {
                string localeStr = parts[0] + " : " + (error.get_ErrorClass() == ErrorClass.Warning ? "warning" : "error") + " " + error.get_ErrorCode() + " - " + prefix + (error.get_LocaleErrorMessage() != "" ? error.get_LocaleErrorMessage() : error.get_ErrorMessage());
                Util.Write(englishStr, localeStr);
                if(!inyectedCodeDebug) currentErrors.Add(englishStr, null);
            }
            if (error.get_RelatedError() != null)
                ShowError(error.get_RelatedError(), currentErrors, prefix + "--> ", inyectedCodeDebug);
        }

        private static void ShowCopyright()
        {
            Util.Write();
            Util.Write("ZOE Compiler (C)2007 Alexis Ferreyra.", "Compilador ZOE (R)2007 Alexis Ferreyra.");
            Util.Write("Please visit http://layerd.net to obtain last version and info.","Por favor visite http://layerd.net para obtener la última versión disponible y toda la información.");
        }

        private static void ShowComponentsInfo()
        {
            Util.Write("Zoe Compiler. Components Information:", "Compilador Zoe. Información de Componentes:");
            Util.Write();
            // Zoe CodeDOM
            PrintAssemblyInformation(Assembly.GetAssembly(typeof(XplNode)));
            // Zoe Compiler Core
            PrintAssemblyInformation(Assembly.GetAssembly(typeof(ZOECompilerCore)));
            // Zoe Compiler Interfaces
            PrintAssemblyInformation(Assembly.GetAssembly(typeof(LayerD.OutputModules.IEZOERender)));
            // Zoe Console User interface
            PrintAssemblyInformation(Assembly.GetAssembly(typeof(ZOECConsoleUI)));
        }

        private static void PrintAssemblyInformation(Assembly assembly)
        {
            Util.Write("Module: " + assembly.GetName().Name.PadRight(30) + "Version: " + assembly.GetName().Version.ToString(),
                "Modulo: " + assembly.GetName().Name.PadRight(30) + "Versión: " + assembly.GetName().Version.ToString());
        }

        private static XplDocument BuildDefaultProgram(ArgumentsData arguments)
        {
            XplDocument program = BuildDefaultProgramSkeleton(arguments);
            /*Los archivos fuentes*/
            AddSourceFilesToProgram(arguments, (XplLayerDZoeProgramConfig)program.get_DocumentData().get_Config().get_Content());
            return program;
        }

        private static XplDocument BuildDefaultProgramSkeleton(ArgumentsData arguments)
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

            progConfig.set_defaultPlatform(arguments.OutputPlatform);
            progConfig.set_defaultOutputFileName(arguments.OutputFileName);
            if (!arguments.BuildLibrary) progConfig.set_moduleType(XplLayerDZoeProgramModuletype_enum.EXECUTABLE);
            else progConfig.set_moduleType(XplLayerDZoeProgramModuletype_enum.DYNAMIC_LIB);
            progConfig.set_name(arguments.ProgramName);

            XplTargetPlatform defaultPlatform = XplLayerDZoeProgramConfig.new_OutputPlatform();
            defaultPlatform.set_uniqueName(arguments.OutputPlatform);
            defaultPlatform.set_simpleName(arguments.OutputPlatform.Split(new char[] { ' ' })[0]);
            progConfig.get_OutputPlatform().InsertAtEnd(defaultPlatform);
            /*El program config*/
            XplLayerDZoeProgramRequirements requirements = XplLayerDZoeProgramConfig.new_ProgramRequirements();
            progConfig.set_ProgramRequirements(requirements);
            return prog;
        }

        private static void AddSourceFilesToProgram(ArgumentsData arguments, XplLayerDZoeProgramConfig progConfig)
        {
            XplSourceFile sourceFile = null;
            if (arguments.SourceFiles.Count == 0)
            {
                sourceFile = XplLayerDZoeProgramConfig.new_SourceFile();
                sourceFile.set_fileName(arguments.InputProgram);
                progConfig.get_SourceFile().InsertAtEnd(sourceFile);
            }
            else
            {
                foreach (string file in arguments.SourceFiles)
                {
                    sourceFile = XplLayerDZoeProgramConfig.new_SourceFile();
                    sourceFile.set_fileName(file);
                    progConfig.get_SourceFile().InsertAtEnd(sourceFile);
                }
            }
        }
	}
}
