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

//Archivo: lib_layerdxplc_modgenerator.cs 
//
//Generador de Modulos de Classfactorys del compilador LayerD-Zoe,
//encargado de construir los componentes de extensión dinámica para
//una plataforma en particular, es llamado por la Libreria de
//Classfactorys para compilar los modulos.
//

//import "System", "ns=DotNET", "platform=DotNET";
//import "System.Collections", "ns=DotNET", "platform=DotNET";
//import "LayerD.CodeDOM", "ns=DotNET", "platform=DotNET";

using System;
using System.IO;
using System.Collections;
using LayerD.CodeDOM;

namespace LayerD.ZOECompiler{
    class ClassfactoryModuleGenerator
    {
        internal const string TYPECONSTRUCTOR_PREFIX = "_tc_internalimpl_";
        internal const string INSTANCE_TYPECONSTRUCTOR_PREFIX = "_itc_internalimpl_";

        string p_runtimePlatform;
        string p_moduleFileName;
        ZOECompilerCore p_currentClientCore;
        ExtensionModuleType p_moduleType;

        public enum ExtensionModuleType { dll, exe }
        public ZOECompilerCore CurrentClientCore
        {
            get { return p_currentClientCore; }
            set { p_currentClientCore = value; }
        }
        public bool CompileExtension(ExtensionData extension,
                              string runtimePlatform,
                              string moduleFileName,
                              ExtensionModuleType moduleType)
        {
            p_runtimePlatform = runtimePlatform;
            p_moduleFileName = moduleFileName;
            p_moduleType = moduleType;

            return CompileZOEExtension(extension);
        }

        static public void RefactorZOEExtensionDocument(XplDocument document){
            ChangeTypes(document.get_DocumentBody().Children());
        }

        static private void ChangeTypes(XplNodeList source)
        {
            if (source == null) return;

            XplNodeList nodesToAdd = new XplNodeList();

            foreach (XplNode node in source)
            {
                if (node.get_TypeName() == CodeDOMTypes.XplNamespace)
                {
                    ChangeTypes(node.Children());
                }
                else if (node.get_TypeName() == CodeDOMTypes.XplClass)
                {
                    XplClass classNode = (XplClass)node;
                    
                    if (classNode.get_isfactory() && !classNode.get_isinteractive())
                    {
                        classNode.set_isfactory(false);
                    }
                    else if (classNode.get_isinteractive())
                    {
                        classNode.set_isinteractive(false);
                        classNode.set_isfactory(false);
                    }
                    
                    ChangeTypes(node.Children());
                }
                else if (node.get_TypeName() == CodeDOMTypes.XplFunction)
                {
                    // TODO : when the function is an indexer
                    
                    XplFunction func = (XplFunction)node;

                    if (func.get_Parameters() != null)
                    {
                        foreach (XplParameter p in func.get_Parameters().Children())
                            ChangeType(p.get_type());
                    }
                    ChangeTypes(func.Children());

                    string funcReturnType = func.get_ReturnType() != null ? func.get_ReturnType().get_typename() : null;

                    // TODO : what if the developer uses "XplType^", in that case it wont work :P
                    if (func.get_name() == ((XplClass)func.get_Parent()).get_name() &&
                        funcReturnType != null &&
                        (NativeTypes.IsNativeType(funcReturnType) ||
                        NativeTypes.IsNativeVoid(funcReturnType)))
                    {
                        //Es un constructor de tipos, le tengo q cambiar el nombre y setearlo como 
                        //estatico?
                        if (NativeTypes.IsNativeType(funcReturnType))
                        {
                            func.set_name(TYPECONSTRUCTOR_PREFIX + func.get_name());
                        }
                        else
                        {
                            func.set_name(INSTANCE_TYPECONSTRUCTOR_PREFIX + func.get_name());
                        }
                        if(func.get_storage()==XplVarstorage_enum.EXTERN)
                            func.set_storage(XplVarstorage_enum.STATIC_EXTERN);
                        else
                            func.set_storage(XplVarstorage_enum.STATIC);
                    }
                    if (func.get_ElementName() == "Operator")
                    {
                        // convert operators to normal functions
                        func.set_ElementName("Function");
                        func.set_name(GetFunctionNameFromOperator(func.get_name()));
                    }

                    ChangeType(func.get_ReturnType());
                }
                else if (node.get_TypeName()==CodeDOMTypes.XplProperty)
                {
                    XplProperty property = (XplProperty)node;
                    if (property.get_type().get_ftype() != XplFactorytype_enum.NONE ||
                        property.get_type().get_typename()== NativeTypes.Block ||
                        property.get_type().get_typename() == NativeTypes.Type)
                    {
                        ChangeType(property.get_type());
                        ChangeTypes(node.Children());
                        nodesToAdd.InsertAtEnd(CreateGetFunction(property));
                        nodesToAdd.InsertAtEnd(CreateSetFunction(property));
                    }
                }
                else if (node.get_TypeName() == CodeDOMTypes.XplField)
                {
                    ChangeType(((XplField)node).get_type());
                }
                else if (node.get_TypeName() == CodeDOMTypes.XplDeclaratorlist)
                {
                    // TODO : on functions and properties continue iterating to find local declarations
                    // and replace factory types on local declarations
                }
                else
                {
                    //No hago nada
                }
            }
            source.InsertAtEnd(nodesToAdd);
        }

        internal static string GetFunctionNameFromOperator(string operatorFunctionName)
        {
            return "___zoe_ct_op_" + operatorFunctionName.Replace("%", "__");
        }

        static private XplFunction CreateSetFunction(XplProperty node)
        {
            if (node.get_body() == null) return null;
            XplFunctionBody setBody = (XplFunctionBody)node.get_body().FindNode("Set");
            if (setBody == null) return null;

            XplFunction function = XplClass.new_Function();
            function.set_name("__set_" + node.get_name());
            function.set_access(node.get_access());
            function.set_storage(node.get_storage());
            function.set_final(node.get_final());
            function.set_virtual(node.get_virtual());
            function.set_new(node.get_new());
            function.set_override(node.get_override());

            function.set_ReturnType((XplType)node.get_type().Clone());
            // add value parameter
            function.set_Parameters(XplFunction.new_Parameters());
            XplParameter valueParam = XplParameters.new_P();
            valueParam.set_name("value");
            valueParam.set_type((XplType)node.get_type().Clone());
            valueParam.set_number(1);
            function.get_Parameters().Children().InsertAtEnd(valueParam);

            // add function body
            function.set_FunctionBody((XplFunctionBody)setBody.Clone());
            setBody.Children().Clear();
            return function;
        }

        static private XplFunction CreateGetFunction(XplProperty node)
        {
            if (node.get_body() == null) return null;
            XplFunctionBody getBody = (XplFunctionBody)node.get_body().FindNode("Get");
            if (getBody == null) return null;

            XplFunction function = XplClass.new_Function();
            function.set_name("__get_" + node.get_name());
            function.set_access(node.get_access());
            function.set_storage(node.get_storage());
            function.set_final(node.get_final());
            function.set_virtual(node.get_virtual());
            function.set_new(node.get_new());
            function.set_override(node.get_override());

            function.set_ReturnType((XplType)node.get_type().Clone());
            // add value parameter
            function.set_Parameters(XplFunction.new_Parameters());

            // add function body
            function.set_FunctionBody((XplFunctionBody)getBody.Clone());
            return function;
        }

        
        static private void ChangeType(XplType type)
        {
            if (type == null) return;
            XplType clase = null;
            if (type.get_ftype() != XplFactorytype_enum.NONE)
            {
                clase = new XplType();
                if (type.get_ftype() == XplFactorytype_enum.INAME)
                {
                    clase.set_typename("XplIName");
                    type.set_lddata("1" + type.get_typeStr());
                }
                else if (type.get_ftype() == XplFactorytype_enum.EXPRESSION)
                {
                    clase.set_typename("XplExpression");
                    type.set_lddata("2" + type.get_typeStr());
                }
                else
                {
                    //No hago nada, por ahora no soporto tipos de lista de expresiones
                    //o instrucciones
                }
                type.set_ftype(XplFactorytype_enum.NONE);
            }
            else if (type.get_typename() == NativeTypes.Type)
            {
                clase = new XplType();
                clase.set_typename("XplType");
                type.set_lddata("3");
            }
            else if (type.get_typename() == NativeTypes.Block)
            {
                clase = new XplType();
                clase.set_typename("XplFunctionBody");
                type.set_lddata("4");
            }
            else
            {
                type.set_lddata("0");
                return;
            }
            type.set_dt(clase);
            type.set_ispointer(true);
            type.set_isarray(false);
            type.set_ae(null);
            XplPointerinfo pi = new XplPointerinfo();
            pi.set_ref(true);
            type.set_pi(pi);
            type.set_exec(false);
            type.set_const(false);
            type.set_customTypeCheck(false);
            type.set_volatile(false);
        }
        

        //const string ZOE_FACTORY_BASE_DLL = ".\\FactoriesLib\\zoe_factorytypes_base.dll";

        private bool CompileZOEExtension(ExtensionData extension)
        {
            XplDocument[] extensionProgram = new XplDocument[2];
            //1º)Creo un programa ZOE adecuado para el documento de extension.
            extensionProgram[0] = BuildExtensionProgram();
            //extensionProgram[2] = ZOEProgramLoader.LoadLibrarySource(ZOE_FACTORY_TYPES_BASE_SOURCEFILE);
            //Esto es una bandera para q durante la construccion
            //del DTE el analizador semanticno no lo incluya
            //extensionProgram[2].get_DocumentData().set_Title(new XplNode("Title", "__REMOVE_FROM_DTE__"));
            extensionProgram[1] = extension.Document;
            //2º)Creo una instancia del compilador.
            ZOECompilerCore zoec = new ZOECompilerCore();

            if(p_currentClientCore.get_ShowFullDebugInfo())
                ZOECompilerCore.WriteDebugTextLine("Begin Compilation of Extension.");
            zoec.set_OutputPlatform(p_runtimePlatform);
            zoec.set_OutputPath(Path.GetDirectoryName(p_moduleFileName) + Path.DirectorySeparatorChar);
            zoec.set_ShowFullDebugInfo(p_currentClientCore.get_ShowFullDebugInfo());
            zoec.set_ShowInternalTimes(p_currentClientCore.get_ShowInternalTimes());
            zoec.set_SilentMode(p_currentClientCore.get_SilentMode());
            zoec.ShowInternalDebuger = p_currentClientCore.ShowInternalDebuger;
            zoec.WorkingPath = p_currentClientCore.WorkingPath;
            zoec.set_RenderIntermediateOutputOnly(p_currentClientCore.get_RenderIntermediateOutputOnly());
            //zoec.set_OutputPlatformBuildArguments(" /reference:\""+Path.GetFullPath(ZOE_FACTORY_BASE_DLL)+"\" ");
            zoec.set_BuildingExtension(true);

            //¿¿¿Tal vez no deberia permitir esto, no???
            zoec.set_IgnoreErrorsAndBuild(p_currentClientCore.get_IgnoreErrorsAndBuild());
            zoec.set_IgnoreErrorsOnImportedTypes(p_currentClientCore.get_IgnoreErrorsOnImportedTypes());

            if (p_currentClientCore.get_DonotBuildExtensions() && p_currentClientCore.get_CheckSemanticOfExtensions())
            {
                //Esto para las utilidades semanticas solamente
                return zoec.CheckSemantic(extensionProgram, p_runtimePlatform);
            }
            else
            {
                //3º)Intento compilar el programa de extensión.
                bool result = zoec.CompileProgram(extensionProgram);
                if (result)
                {
                    //OK se compilo con exito
                    if (zoec.get_IgnoreErrorsAndBuild() && zoec.get_ErrorCollection().get_ErrorsCount() > 0)
                    {
                        if (p_currentClientCore.get_ShowFullDebugInfo())
                            ZOECompilerCore.WriteDebugTextLine("Errors on compilation of extension.");
                        p_currentClientCore.get_ErrorCollection().Clear();
                        p_currentClientCore.get_ErrorCollection().Merge(zoec.get_ErrorCollection());
                    }
                }
                else
                {
                    //No se compilo con exito
                    p_currentClientCore.get_ErrorCollection().Clear();
                    p_currentClientCore.get_ErrorCollection().Merge(zoec.get_ErrorCollection());
                    if (p_currentClientCore.get_ShowFullDebugInfo())
                        ZOECompilerCore.WriteDebugTextLine("Errors on compilation of extension.");
                }
                if (p_currentClientCore.get_ShowFullDebugInfo())
                    ZOECompilerCore.WriteDebugTextLine("End Compilation of Extension.");
                return result;
            }
        }

        private XplDocument BuildExtensionProgram()
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

            progConfig.set_defaultPlatform(p_runtimePlatform);
            progConfig.set_defaultOutputFileName(p_moduleFileName);            
            progConfig.set_moduleType(XplLayerDZoeProgramModuletype_enum.DYNAMIC_LIB);
            progConfig.set_name(Path.GetFileName(p_moduleFileName));

            XplTargetPlatform defaultPlatform = XplLayerDZoeProgramConfig.new_OutputPlatform();
            defaultPlatform.set_uniqueName(p_runtimePlatform);
            defaultPlatform.set_simpleName(p_runtimePlatform.Split(new char[] { ' ' })[0]);
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
