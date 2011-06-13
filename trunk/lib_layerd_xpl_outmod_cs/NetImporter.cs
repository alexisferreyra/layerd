/****************************************************************************
 
  C# Output Module for Zoe compiler
  
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
using System.IO;
using System.CodeDom;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using LayerD.CodeDOM;
using LayerD.ZOECompiler;
using System.Globalization;

namespace LayerD.OutputModules.Importers
{
	/// <summary>
	/// Importador de tipos de .NET a sus equivalentes en ZOE.
	/// 
	/// Procesa directivas "p_import" en código ZOE.
	/// </summary>
	/// <remarks>
	/// Por Hacer:
	///  - Procesamiento de atributos en Tipos, Miembros, Parametros y Tipos de retorno.
    ///  - Que importe los tipos de los cuales dependen los tipos importados.
    ///  - Que solucione cuando se proporciona una sobreescritura de miembro en base a diferencias
    ///  solo en tipo de parametro por referencia, por ejemplo "func(int* a) y func(ref int a)" en
    ///  ZOE son equivalentes, pero no en .NET.
	///  - Que procese los operadores, metodos de indexacion (propiedades con parametros), eventos
	///  y delegates de forma especial para los casos necesarios.
	///  - Que permita establecer un reemplazo de tipos basicos, como interfaces estandar por tipos
	///  definidos que puedan pasarse como parametro.
	///  - Que incluya o no los miembros heredados de los tipos e indique en dichos miembros el tipo que
	///  lo implementa, quizas puedan incluirse los mapeos de las interfaces.
	///  - Mejorar el cache de archivos que ahora funciona muy básico.
	/// </remarks>
	public class NetImporter: IZOEImportsDirectiveProcessor
	{
		#region Tipos privados
        /// <summary>
        /// Types of errors
        /// </summary>
		public enum ErrorType{
            /// <summary>
            /// Errors of Arguments
            /// </summary>
			Arguments,
            /// <summary>
            /// Value of argument
            /// </summary>
			ArgumentValue,
            /// <summary>
            /// Assembly
            /// </summary>
			Assembly,
            /// <summary>
            /// NET version
            /// </summary>
			NetVersion,
            /// <summary>
            /// internal
            /// </summary>
			Internal,
            /// <summary>
            /// unsupported
            /// </summary>
			Unsupported,
            /// <summary>
            /// not implemented
            /// </summary>
			NotImplemented
		}
		class ImportParams{
			public string Namespace="";
			public string BaseNamespace="";
			public string AssemblyName="";
			public string AssemblyFullName="";
			public string AssemblyFileName="";
			public string ExtraPath="";
			public string NetVersion="1.0";
			public bool IncludeBaseNamespace=true;
			public bool IgnoreEnums=false;
			public bool IncludeAttributes=true;
			public bool IncludeEvents=true;
			public bool IncludeDelegates=true;
			public bool IncludePrivateMembers=false;
			public bool IgnoreGenerics=true;
			public bool AllTypesFinal=false;
			public bool RemoveInheritedInterfaces=false;
			public string ConstantsNamespace="";
			public string GlobalsNamespace="";
            public XplNode ImportNode;
		}
		#endregion

		#region Variables Privadas
		Hashtable p_xplNamespaces=null;
		IErrorCollection p_Errors=null;
		ImportParams p_import=null;
        ArrayList p_currentImportedDocuments=null;
        static TypesCache p_cache = null;
        static Hashtable p_ignoredTypes = null;
        int p_TypesCount = 0;
        bool p_donotImportCachedTypes = true;
		#endregion

        #region Constructores
        /// <summary>
        /// Initializes a new instance of the <see cref="NetImporter"/> class.
        /// </summary>
        public NetImporter()
		{
            p_Errors = new ErrorCollection();

            if (p_cache == null)
            {
                p_cache = new TypesCache();
            }
            if (p_ignoredTypes== null)
            {
                p_ignoredTypes = new Hashtable();
                //Types to ignore on import
                p_ignoredTypes.Add("System.DateTime", null);
            }
		}
		#endregion

		#region RunImport
		bool RunImport(){
			Assembly assembly=null;
			//Primero intento cargar el assembly, con el FileName si existe, sino con el FullName, y sino con el nombre parcial
			try{
				if(p_import.AssemblyName=="")p_import.AssemblyName=p_import.Namespace;
				if(p_import.AssemblyFileName!=""){
                    if (File.Exists(Path.GetFullPath(p_import.AssemblyFileName)))
                    {
                        // If supplied filename exists import it
                        assembly = Assembly.LoadFrom(p_import.AssemblyFileName);
                    }
                    else
                    {
                        // If supplied filename doesn't exists try to search with relative path to source
                        // if source information is found.
                        string sourceFilename = p_import.ImportNode.FullSourceFileInfo;
                        if (sourceFilename != null && sourceFilename != "")
                        {
                            string[] parts = sourceFilename.Split(',');
                            sourceFilename = Path.GetDirectoryName(parts[parts.Length - 1]);
                            sourceFilename = Path.Combine(sourceFilename, p_import.AssemblyFileName);
                            if (File.Exists(sourceFilename))
                            {
                                // If relative filename exists import it
                                assembly = Assembly.LoadFrom(sourceFilename);
                            }
                        }
                    }
				}
				else if(p_import.AssemblyFullName!=""){
					assembly=Assembly.Load(p_import.AssemblyFullName);
				}
				else{
					assembly=Assembly.LoadWithPartialName(p_import.AssemblyName);
				}
                if (assembly == null)
                {
                    AddError("No se pudo cargar el Ensamblado para el tipo o espacio de nombres '" + p_import.AssemblyName + "'. Pruebe indicando el Nombre de Archivo completo si el Ensamblado no se encuentra en el directorio o en el almacenamiento global.", ErrorType.Assembly);
                    return false;
                }
            }
			catch(FileNotFoundException e){
				AddError("No se encontro el Ensamblado '"+p_import.ExtraPath+p_import.AssemblyName+"' a importar.\n\nError Original: "+e.Message,ErrorType.Assembly);
				return false;
			}
			catch(Exception e){
				AddError("Se produjo una excepción al intentar cargar el Ensamblado '"+p_import.AssemblyName+"'.\n\nError Original: "+e.Message,ErrorType.Assembly);
				return false;
			}

			XplNamespace ns=null;
			XplNode node=null;
			//Aqui tengo el assembly, ya puedo buscar el modulo o tipo a importar.            
            //Primero cargo la cache para el assembly (si existe)
            p_cache.LoadCache(assembly);
			if(p_xplNamespaces==null)p_xplNamespaces=new Hashtable();
			Type type=assembly.GetType(p_import.Namespace,false,false);
			if(type==null){ 
				//El tipo no existe, se supone que se esta importando un espacio de nombres
				Type []allTypes=assembly.GetTypes();
                
				p_TypesCount=0;
				foreach(Type type2 in allTypes){
					if(type2.Namespace!=null && type2.Namespace.StartsWith(p_import.Namespace)
                        && !type2.IsNested){                        
                        ns = getNamespaceFor(type2);
                        node = ImportType(type2);
                        if (node != null)
                        {
                            //Finalmente agrego la clase al espacio de nombres
                            ns.Children().InsertAtEnd(node);
                        }
						p_TypesCount++;
					}
				}
			}
			else{
				ns=getNamespaceFor(type);
				node=ImportType(type);
				//Finalmente agrego la clase al espacio de nombres
                if (node != null)
                {
                    ns.Children().InsertAtEnd(node);
                    p_TypesCount++;
                }
			}
			foreach(Module module in assembly.GetModules(false)){
				MethodInfo []globalMethods=module.GetMethods();
				if(globalMethods!=null && globalMethods.Length>0){
					//Esto no esta testeado!!!
					//No se encontro assembly con metodos globales !!!
					if(p_import.GlobalsNamespace=="")p_import.GlobalsNamespace="Globals";
					ns=new XplNamespace(p_import.BaseNamespace+"::"+p_import.GlobalsNamespace,true,true);
                    ns.set_ElementName("Namespace");
					XplClass newClass=XplNamespace.new_Class();
					newClass.set_name("GlobalsMethods");
					newClass.set_access(XplAccesstype_enum.PUBLIC);
					ns.Children().InsertAtEnd(newClass);
					foreach(MethodInfo globalMethod in globalMethods){
						ImportMethod(globalMethod,newClass);
					}
					p_xplNamespaces.Add(ns.get_name(),ns);
				}
			}
			return true;
		}
		#endregion

		#region ImportType
		XplNode ImportType(Type type){
            //Me fijo si existe en la cache
            XplNode cachedType = p_cache.GetType(type);
            if (cachedType != null)
            {
                if (p_donotImportCachedTypes) return null;
                else return cachedType;
            }
            //If it is on list of types to ignore return null;
            if (p_ignoredTypes.ContainsKey(type.FullName)) return null;
            //Si es generico lo ignoro
            if (type.IsGenericTypeDefinition || type.IsGenericType) return null;
			//Si no es un enum es una clase, estructura o interfaz
			XplClass newClass=XplNamespace.new_Class();
			newClass.set_name(type.Name);
			if(type.IsClass){}//Es una clase no seteo nada
			else if(type.IsInterface)newClass.set_isinterface(true);
			else if(type.IsValueType && !type.IsEnum)newClass.set_isstruct(true);
			else if(type.IsEnum)newClass.set_isenum(true);
			if(type.IsNotPublic)newClass.set_access(XplAccesstype_enum.PRIVATE);
			else newClass.set_access(XplAccesstype_enum.PUBLIC);
		
			if(type.IsAbstract)newClass.set_abstract(true);            
			if(type.IsSealed || (p_import.AllTypesFinal && !type.IsAbstract) )newClass.set_final(true);

			MemberInfo[] classMembers=type.GetMembers();
            Type enumMembersType = null;
            if (type.IsEnum)
            {
                enumMembersType = ((FieldInfo)type.GetMember("value__")[0]).FieldType;
            }
			foreach(MemberInfo member in classMembers){
				ImportMember(type,member,newClass,enumMembersType);
			}
			//Proceso la herencia 
			if(type.BaseType!=null && !type.BaseType.IsGenericType
                && !type.BaseType.ContainsGenericParameters)
            {
                if (type.BaseType.FullName != "System.Object")
                {
                    XplInherits ins = XplClass.new_Inherits();
                    XplInherit i = XplInherits.new_c();
                    i.set_access(XplAccesstype_enum.PUBLIC);
                    XplType inhtype = XplInherit.new_type();
                    inhtype.set_typename(processTypeName(type.BaseType.FullName));
                    i.set_type(inhtype);
                    ins.Children().InsertAtEnd(i);
                    newClass.Children().InsertAtEnd(ins);
                }
			}
			//y la implementación de interfaces
			ImportImplements(type,newClass);
			//Aca debo procesar los tipos anidados
            //PENDIENTE : Este procesamiento de tipos anidados no devuelve los tipos
            //anidados que no sean publicos lo cual en el modo actual de importación de 
            //tipos genera dos mensajes de error en ZOE por tipos no importados
            //de los cuales dependen tipos importados.
			/*XplNode node=null;
			foreach(Type nestedType in type.GetNestedTypes()){
				node=ImportType(nestedType);
				newClass.Children().InsertAtEnd(node);
			}*/
            p_cache.AddType(type, newClass,false);
			return newClass;
		}
		void ImportImplements(Type type, XplClass newClass){
			if(type.GetInterfaces().Length==0)return;
			XplInherits impls=XplClass.new_Implements();
			XplInherit impl=null;
			XplInherits ins=null;
			foreach(Type interFace in type.GetInterfaces()){
                if(!interFace.IsGenericType
                    && !interFace.ContainsGenericParameters)
				    if(type.IsInterface){
					    if(ins==null){
						    ins=XplClass.new_Inherits();
						    newClass.Children().InsertAtEnd(ins);
					    }
					    XplInherit i=XplInherits.new_c();
					    i.set_access(XplAccesstype_enum.PUBLIC);
                        XplType itype = new XplType();
                        itype.set_typename(processTypeName(interFace.FullName));
                        i.set_type(itype);
					    ins.Children().InsertAtEnd(i);
				    }
				    else{
					    if(!p_import.RemoveInheritedInterfaces || !isBaseOf(type.GetInterfaces(),interFace)){
						    impl=XplInherits.new_c();
                            XplType itype = new XplType();
                            itype.set_typename(processTypeName(interFace.FullName));
                            impl.set_type(itype);
						    impls.Children().InsertAtEnd(impl);
					    }
				    }
			}
			newClass.Children().InsertAtEnd(impls);
		}
		bool isBaseOf(Type[] tipos, Type tipo){
			foreach(Type t in tipos){
				if(tipo.FullName!=t.FullName){
					foreach(Type i in t.GetInterfaces()){
						if(i==tipo)return true;
					}
				}
			}
			return false;
		}
		#endregion

		#region ImportMember
		void ImportMember(Type type, MemberInfo member, XplClass newClass, Type enumMembersType){
			switch(member.MemberType){
				case MemberTypes.Constructor:
					if(type.FullName==member.DeclaringType.FullName)
						ImportConstructor((ConstructorInfo)member,newClass);
					break;
				case MemberTypes.Event:
					if(!p_import.IncludeEvents){
						AddError("Clase: '"+newClass.get_name()+"' - Evento '"+member.Name+"' no importado.",ErrorType.NotImplemented);
					}
					break;
				case MemberTypes.Field:
					if(type.FullName==member.DeclaringType.FullName)
						ImportField((FieldInfo)member,newClass, enumMembersType);
					break;
				case MemberTypes.Method:
					if(type.FullName==member.DeclaringType.FullName &&
                        !((MethodBase)member).IsGenericMethod ) //&& !((MethodInfo)member).ReturnType.IsGenericType)
						ImportMethod((MethodInfo)member,newClass);
					break;
				case MemberTypes.NestedType:
					//AddError("Clase: '"+newClass.get_name()+"' - Importación de miembros 'NestedType' no soportado ("+member.Name+").",ErrorType.Unsupported);
					//Se supone que lo importo por separado
                    XplNode node = ImportType((Type)member);
                    //Finalmente agrego la clase al espacio de nombres
                    if (node != null)
                    {
                        newClass.Children().InsertAtEnd(node);
                        p_TypesCount++;
                    }
                    break;
				case MemberTypes.Property:
					if(type.FullName==member.DeclaringType.FullName)
						ImportProperty((PropertyInfo)member,newClass);
					break;
				case MemberTypes.TypeInfo:
					AddError("Clase: '"+newClass.get_name()+"' - Importación de miembros 'TypeInfo' no soportado ("+member.Name+").",ErrorType.Unsupported);
					break;
				case MemberTypes.Custom:
					AddError("Clase: '"+newClass.get_name()+"' - Importación de miembros 'Custom' no soportado ("+member.Name+").",ErrorType.Unsupported);
					break;
			}
		}
		#endregion

		#region ImportConstructor, Method, Parameters
		void ImportConstructor(ConstructorInfo method,XplClass newClass){
			if(method.IsPrivate && !p_import.IncludePrivateMembers)return;

			XplFunction newFunc=XplClass.new_Function();
			//Aqui tendria que procesar el nombre del metodo para el caso de los operadores
			if(method.Name.StartsWith("op_")){
				newFunc.set_name(getOperatorName(method.Name));
			}
			else{
				newFunc.set_name(method.Name);
			}
			if(method.IsConstructor)newFunc.set_name(newClass.get_name());
			if(method.IsAbstract)newFunc.set_abstract(true);
			if(method.IsFinal)newFunc.set_final(true);
			if(method.IsStatic)newFunc.set_storage(XplVarstorage_enum.STATIC_EXTERN);
			else newFunc.set_storage(XplVarstorage_enum.EXTERN);
			if(method.IsVirtual)newFunc.set_virtual(true);
			//El tipo de retorno, no tiene!!
			newFunc.set_ReturnType(XplFunction.new_ReturnType());
			//Los parametros
            if (method.DeclaringType.IsSubclassOf(typeof(System.Delegate)))
            {
                newFunc.set_Parameters(ImportParametersForDelegate(method.DeclaringType, newClass));
            }
            else
            {
                newFunc.set_Parameters(ImportParameters(method.GetParameters()));
            }
			//Los atributos

			//Finalmente lo agrego a un classmember adecuado de acuerdo a la visibilidad
            if (method.IsPrivate) newFunc.set_access(XplAccesstype_enum.PRIVATE);
            else if (method.IsPublic) newFunc.set_access(XplAccesstype_enum.PUBLIC);
			else newFunc.set_access(XplAccesstype_enum.PROTECTED);
            AddMember(newClass, newFunc);
		}

        private XplParameters ImportParametersForDelegate(Type delegateType, XplClass newClass)
        {
            MethodInfo invokeMethod = (MethodInfo)delegateType.GetMember("Invoke")[0];
            ImportDelegateType(delegateType.Name, invokeMethod, newClass);
            XplParameters parameters = XplFunction.new_Parameters();
            XplParameter parameter = XplParameters.new_P();
            parameter.set_name("functionPointer");
            XplType tipoParametro = new XplType();
            tipoParametro.set_typename(delegateType.Name + "FPType");
            parameter.set_type(tipoParametro);
            parameters.Children().InsertAtEnd(parameter);
            return parameters;
        }

        void ImportDelegateType(string delegateName, MethodInfo method, XplClass newClass)
        {
            if (method.IsPrivate && !p_import.IncludePrivateMembers) return;

            XplFunction newFunc = XplClass.new_Function();
            newFunc.set_fp(true);
            newFunc.set_name(delegateName + "FPType");
            /*
            if (method.IsConstructor) newFunc.set_name(newClass.get_name());
            if (method.IsAbstract) newFunc.set_abstract(true);
            if (method.IsFinal) newFunc.set_final(true);
            if (method.IsStatic) newFunc.set_storage(XplVarstorage_enum.STATIC_EXTERN);
            else newFunc.set_storage(XplVarstorage_enum.EXTERN);
            if (method.IsVirtual) newFunc.set_virtual(true);
             */
            //El tipo de retorno
            newFunc.set_ReturnType(getXplType(method.ReturnType, false));
            //Los parametros
            newFunc.set_Parameters(ImportParameters(method.GetParameters()));
            //Los atributos

            //Finalmente lo agrego a un classmember adecuado de acuerdo a la visibilidad
            newFunc.set_access(XplAccesstype_enum.PUBLIC);
            /*
            if (method.IsPrivate) newFunc.set_access(XplAccesstype_enum.PRIVATE);
            else if (method.IsPublic) newFunc.set_access(XplAccesstype_enum.PUBLIC);
            else newFunc.set_access(XplAccesstype_enum.PROTECTED);
             */
            AddMember(newClass, newFunc);
        }


		void ImportMethod(MethodInfo method,XplClass newClass){
			if(method.IsPrivate && !p_import.IncludePrivateMembers)return;

			XplFunction newFunc=XplClass.new_Function();
            string mname=method.Name ;
            //No importo los metodos q implementan propiedades :-),
            //es decir que empiezan con "get_" o "set_"
            if ( (mname.StartsWith("get_") || mname.StartsWith("set_")) && method.IsSpecialName) 
                return;

            if (mname.StartsWith("op_"))
            {
                string funcName = "%op_";
                //Operadores en ZOE : 
                //Unary : MIN,INC,DEC,PREINC,PREDEC,IND,AOF,RAOF,SIZEOF,TYPEOF,ONECOMP,NOT
                //Binary : ADD,MIN,MUL,DIV,MOD,EXP,LSH,RSH,AND,OR,EQ,NOTEQ,GR,LS,GREQ,LSEQ,BAND,BOR,XOR,M,PM,MP,PMP,MS,MSM,RM,IMP
                //PENDIENTE : esto es temporal, falta chequear el funcionamiento
                //correcto de cada uno de los operadores importados.
                //Falta unificar en alguna estructura de datos los codigos usados para los operadores
                //por Zoe unificandolo con el lenguaje Meta D++.
                switch (method.Name)
                {
                    case "op_Addition":
                        if(method.GetParameters().Length==2)
                            funcName += "add%";
                        else
                            funcName += "uadd%";
                        break;
                    case "op_BitwiseAnd":
                        funcName += "band%";
                        break;
                    case "op_BitwiseOr":
                        funcName += "bor%";
                        break;
                    case "op_Decrement":
                        funcName += "dec%";
                        break;
                    case "op_Divition":
                        funcName += "div%";
                        break;
                    case "op_Equality":
                        funcName += "eq%";
                        break;
                    case "op_ExclusiveOr":
                        funcName += "xor%";
                        break;
                    case "op_Explicit":
                        funcName += "explicit%";
                        break;
                    case "op_GreaterThan":
                        funcName += "grt%";
                        break;
                    case "op_GreaterThanOrEqual":
                        funcName += "greq%";
                        break;
                    case "op_Implicit":
                        funcName += "implicit%";
                        break;
                    case "op_Increment":
                        funcName += "inc%";
                        break;
                    case "op_Inequality":
                        funcName += "noteq%";
                        break;
                    case "op_LessThan":
                        funcName += "lst%";
                        break;
                    case "op_LessThanOrEqual":
                        funcName += "lseq%";
                        break;
                    case "op_LogicalNot":
                        funcName += "bneg%";
                        break;
                    case "op_Modulus":
                        funcName += "mod%";
                        break;
                    case "op_Multiply":
                        funcName += "mul%";
                        break;
                    case "op_OneComplement":
                        funcName += "comp%";
                        break;
                    case "op_Subtraction":
                        if (method.GetParameters().Length == 2)
                            funcName += "min%";
                        else
                            funcName += "umin%";
                        break;
                    case "op_UnaryNegation":
                        funcName += "bneg%";
                        break;
                    case "op_UnaryPlus":
                        funcName += "uadd%";
                        break;
                    default:
                        funcName = method.Name;
                        break;
                }
                newFunc.set_name(funcName);
                //isOperator = true;
                newFunc.set_ElementName("Operator");
            }
            else newFunc.set_name(method.Name);
			if(method.IsConstructor)newFunc.set_name(newClass.get_name());
			if(method.IsAbstract)newFunc.set_abstract(true);
			if(method.IsFinal)newFunc.set_final(true);
			if(method.IsStatic)newFunc.set_storage(XplVarstorage_enum.STATIC_EXTERN);
			else newFunc.set_storage(XplVarstorage_enum.EXTERN);
			if(method.IsVirtual)newFunc.set_virtual(true);
			//El tipo de retorno
			newFunc.set_ReturnType(getXplType(method.ReturnType,false));
			//Los parametros
			newFunc.set_Parameters(ImportParameters(method.GetParameters()));
			//Los atributos

			//Finalmente lo agrego a un classmember adecuado de acuerdo a la visibilidad
            if (method.IsPrivate) newFunc.set_access(XplAccesstype_enum.PRIVATE);
            else if (method.IsPublic) newFunc.set_access(XplAccesstype_enum.PUBLIC);
			else newFunc.set_access(XplAccesstype_enum.PROTECTED);
            AddMember(newClass, newFunc);
		}
		XplParameters ImportParameters(ParameterInfo[] parameters){
			if(parameters==null || parameters.Length==0)return null;
			XplParameters xplParams=XplFunction.new_Parameters();
			foreach(ParameterInfo parameter in parameters){
				XplParameter xplParam=ImportParameter(parameter);
				xplParam.set_number((uint)xplParams.Children().GetLength()+1);
				xplParams.Children().InsertAtEnd(xplParam);
			}
			return xplParams;
		}
		XplParameter ImportParameter(ParameterInfo parameter){
			XplParameter xplParam=XplParameters.new_P();
			xplParam.set_name(parameter.Name);
			xplParam.set_type(getXplType(parameter.ParameterType,true));
			if(parameter.IsIn)xplParam.set_direction(XplParameterdirection_enum.IN);
			else if(parameter.IsOut)xplParam.set_direction(XplParameterdirection_enum.OUT);
			else {
				if(parameter.IsRetval || parameter.ParameterType.IsByRef){
					if(parameter.IsRetval && !parameter.ParameterType.IsByRef)
						AddWarning("El parametro '"+parameter.Name+"' parece ser 'retVal' pero el tipo asociado no es 'byRef'.");
					xplParam.set_direction(XplParameterdirection_enum.INOUT);
				}
			}
            if ((parameter.Attributes & ParameterAttributes.HasDefault )== ParameterAttributes.HasDefault)
            {
				//Posee valor por defecto
				AddWarning("Valor por defecto de Parametros no implementado.");
			}
			//Procesar Atributos
			return xplParam;
		}
		#endregion

		#region ImportProperty
		void ImportProperty(PropertyInfo property,XplClass newClass){
			//Si ambos accesos son privados y no importo privados retorno
			if( property.GetGetMethod()!=null && property.GetGetMethod().IsPrivate && !p_import.IncludePrivateMembers 
				&& property.GetSetMethod()!=null && property.GetSetMethod().IsPrivate )return;
            if (property.Name == "Item")
            {
                ImportIndexer(property, newClass);
            }
            //Si utiliza tipos genericos no la importo
            if (!p_import.IgnoreGenerics && property.PropertyType.IsGenericType) return;

            //Creo la propiedad y los datos basicos
			XplProperty newProperty=XplClass.new_Property();
			newProperty.set_name(property.Name);
			newProperty.set_type(getXplType(property.PropertyType,false));

			if(property.GetGetMethod()!=null && property.GetGetMethod().IsVirtual)newProperty.set_virtual(true);
			else if(property.GetSetMethod()!=null && property.GetSetMethod().IsVirtual)newProperty.set_virtual(true);

			if(property.GetGetMethod()!=null && property.GetGetMethod().IsFinal)newProperty.set_final(true);
			else if(property.GetSetMethod()!=null && property.GetSetMethod().IsFinal)newProperty.set_final(true);

			if(property.GetGetMethod()!=null && property.GetGetMethod().IsAbstract)newProperty.set_abstract(true);
			else if(property.GetSetMethod()!=null && property.GetSetMethod().IsAbstract)newProperty.set_abstract(true);

			if(property.GetGetMethod()!=null && property.GetGetMethod().IsStatic)newProperty.set_storage(XplVarstorage_enum.STATIC_EXTERN);
			else if(property.GetSetMethod()!=null && property.GetSetMethod().IsStatic)newProperty.set_storage(XplVarstorage_enum.STATIC_EXTERN);
			else newProperty.set_storage(XplVarstorage_enum.EXTERN);

			newProperty.set_external(true);
			if(property.GetIndexParameters()!=null)
				if(property.GetIndexParameters().Length>0){
					AddWarning("Parece que la propiedad de nombre '"+property.Name+"' es en realidad un indexer.");
					return;
				}

			//Anexo los bloques Get y/o Set si son necesarios
			newProperty.set_body(XplProperty.new_body());
            XplFunctionBody getOrSet = XplFunctionBody.new_Get();
            getOrSet.set_lddata("%abstract%");
			if(property.CanRead)newProperty.get_body().Children().InsertAtEnd(getOrSet);
            getOrSet = XplFunctionBody.new_Set();
            getOrSet.set_lddata("%abstract%");
            if (property.CanWrite) newProperty.get_body().Children().InsertAtEnd(getOrSet);
														
			if(property.GetGetMethod()!=null && property.GetGetMethod().IsPublic) newProperty.set_access(XplAccesstype_enum.PUBLIC);
            else if (property.GetSetMethod() != null && property.GetSetMethod().IsPublic) newProperty.set_access(XplAccesstype_enum.PUBLIC);
            else if (property.GetGetMethod() != null && property.GetGetMethod().IsPrivate) newProperty.set_access(XplAccesstype_enum.PRIVATE);
            else if (property.GetSetMethod() != null && property.GetSetMethod().IsPrivate) newProperty.set_access(XplAccesstype_enum.PRIVATE);
			else
                newProperty.set_access(XplAccesstype_enum.PROTECTED);			
            AddMember(newClass, newProperty);
		}
        private void ImportIndexer(PropertyInfo property, XplClass newClass)
        {
            if (property.GetGetMethod() != null && property.GetGetMethod().IsPrivate && !p_import.IncludePrivateMembers
                && property.GetSetMethod() != null && property.GetSetMethod().IsPrivate) return;

            XplFunction newFunc = XplClass.new_Indexer();
            newFunc.set_name("%indexer%");

            if (property.GetGetMethod() != null && property.GetGetMethod().IsVirtual) newFunc.set_virtual(true);
            else if (property.GetSetMethod() != null && property.GetSetMethod().IsVirtual) newFunc.set_virtual(true);

            if (property.GetGetMethod() != null && property.GetGetMethod().IsFinal) newFunc.set_final(true);
            else if (property.GetSetMethod() != null && property.GetSetMethod().IsFinal) newFunc.set_final(true);

            if (property.GetGetMethod() != null && property.GetGetMethod().IsAbstract) newFunc.set_abstract(true);
            else if (property.GetSetMethod() != null && property.GetSetMethod().IsAbstract) newFunc.set_abstract(true);

            if (property.GetGetMethod() != null && property.GetGetMethod().IsStatic) newFunc.set_storage(XplVarstorage_enum.STATIC_EXTERN);
            else if (property.GetSetMethod() != null && property.GetSetMethod().IsStatic) newFunc.set_storage(XplVarstorage_enum.STATIC_EXTERN);
            else newFunc.set_storage(XplVarstorage_enum.EXTERN);

            //El tipo de retorno
            newFunc.set_ReturnType(getXplType(property.PropertyType, false));
            //Los parametros
            newFunc.set_Parameters(ImportParameters(property.GetIndexParameters()));

            //Los atributos

            //Anexo los bloques Get y/o Set si son necesarios
            newFunc.set_FunctionBody(XplFunction.new_FunctionBody());
            XplFunctionBody getOrSet = XplFunctionBody.new_Get();
            getOrSet.set_lddata("%abstract%");
            if (property.CanRead) newFunc.get_FunctionBody().Children().InsertAtEnd(getOrSet);
            getOrSet = XplFunctionBody.new_Set();
            getOrSet.set_lddata("%abstract%");
            if (property.CanWrite) newFunc.get_FunctionBody().Children().InsertAtEnd(getOrSet);

            if (property.GetGetMethod() != null && property.GetGetMethod().IsPublic) newFunc.set_access(XplAccesstype_enum.PUBLIC);
            else if (property.GetSetMethod() != null && property.GetSetMethod().IsPublic) newFunc.set_access(XplAccesstype_enum.PUBLIC);
            else if (property.GetGetMethod() != null && property.GetGetMethod().IsPrivate) newFunc.set_access(XplAccesstype_enum.PRIVATE);
            else if (property.GetSetMethod() != null && property.GetSetMethod().IsPrivate) newFunc.set_access(XplAccesstype_enum.PRIVATE);
            else
                newFunc.set_access(XplAccesstype_enum.PROTECTED);
            AddMember(newClass, newFunc);
        }
		#endregion

		#region ImportField
		void ImportField(FieldInfo field,XplClass newClass, Type enumMembersType){
			if(field.IsPrivate && !p_import.IncludePrivateMembers)return;
            //Ignoro el miembro de valor interno de una enumeracion
            if (enumMembersType != null && field.Name == "value__") return;
			XplField newField=XplClass.new_Field();

			newField.set_name(field.Name);
			if(field.IsStatic)newField.set_storage(XplVarstorage_enum.STATIC_EXTERN);
			else newField.set_storage(XplVarstorage_enum.EXTERN);
			//El tipo
			newField.set_type(getXplType(field.FieldType,false));
			if(field.IsLiteral && field.GetRawConstantValue()!=null){
                XplLiteral lit=XplExpression.new_lit();
                string typeName = field.FieldType.Name;
                if (enumMembersType!=null)
                    typeName = enumMembersType.Name;
                switch (typeName)
                {
                    case "SByte":
                    case "Int16":
                    case "Int32":
                    case "Int64":
                        lit.set_type(XplLiteraltype_enum.INTEGER);
                        lit.set_str(ZoeHelper.Att_ToString(Convert.ToInt64(field.GetRawConstantValue())));
                        break;
                    case "Byte":
                    case "UInt16":
                    case "UInt32":
                    case "UInt64":
                        lit.set_type(XplLiteraltype_enum.INTEGER);                        
                        lit.set_str(ZoeHelper.Att_ToString(Convert.ToUInt64(field.GetRawConstantValue())));
                        break;
                    case "Single":
                        lit.set_type(XplLiteraltype_enum.FLOAT);
                        lit.set_str(Convert.ToSingle(field.GetRawConstantValue()).ToString(CultureInfo.InvariantCulture) + "f");
                        break;
                    case "Double":
                        lit.set_type(XplLiteraltype_enum.DOUBLE);
                        lit.set_str(Convert.ToDouble(field.GetRawConstantValue()).ToString(CultureInfo.InvariantCulture));
                        break;
                    case "Decimal":
                        lit.set_type(XplLiteraltype_enum.DECIMAL);
                        lit.set_str(Convert.ToDecimal(field.GetRawConstantValue()).ToString(CultureInfo.InvariantCulture));
                        break;
                    case "Char":
                        lit.set_type(XplLiteraltype_enum.CHAR);
                        lit.set_str(Convert.ToChar(field.GetRawConstantValue(), CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture));
                        break;
                    case "String":
                        lit.set_type(XplLiteraltype_enum.STRING);
                        lit.set_str(Convert.ToString(field.GetRawConstantValue(), CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture));
                        break;
                    case "Boolean":
                        lit.set_type(XplLiteraltype_enum.BOOL);
                        lit.set_str(ZoeHelper.Att_ToString((bool)field.GetRawConstantValue()));
                        break;
                    default:
                        AddWarning("El campo '" + field.Name + "' es constante, pero no se asigno un valor.");
                        break;
                }
                XplExpression initExp = XplInitializerList.new_e();
                initExp.set_Content(lit);
                XplInitializerList il = XplField.new_i();
                newField.set_i(il);
				//Es constante
				newField.get_type().set_const(true);
			}
			//Los atributos
			
			//Finalmente lo agrego a un classmember adecuado de acuerdo a la visibilidad
            if (field.IsPrivate) newField.set_access(XplAccesstype_enum.PRIVATE);
            else if (field.IsPublic) newField.set_access(XplAccesstype_enum.PUBLIC);
			else newField.set_access(XplAccesstype_enum.PROTECTED);
            AddMember(newClass, newField);
		}
		#endregion

		#region procesamiento de tipos
		XplType getXplType(Type netType,bool isParameter){
            
            if ((netType.IsPrimitive && netType.Name != "IntPtr" && netType.Name != "UIntPtr")
                || netType.Name == "Decimal")
                return getXplTypeFromNetPrimitive(netType);

            XplType type = new XplType();
            if (netType.IsPointer)
            {                
                if (!netType.GetElementType().IsValueType)
                    AddWarning("Tipo puntero que no es 'ValueType' procesado, nombre '" + netType.FullName + "'.");
                //Si es puntero
                //AddWarning("Tipo puntero no procesado.");
                XplType backType = getXplType(netType.GetElementType(), false);
                type.set_ispointer(true);
                XplPointerinfo pi = XplType.new_pi();
                type.set_pi(pi);
                type.set_dt(backType);
            }
            else if (netType.IsByRef)
            {
                //Si es por referencia
                //AddWarning("Tipo por referencia no procesado.");
                if (!isParameter) AddWarning("Tipo por referencia que no es parametro!");

                XplType backType = getXplType(netType.GetElementType(), false);
                if (backType.get_ispointer() && backType.get_pi().get_ref()) backType.get_pi().set_ref(false);
                type.set_ispointer(true);
                XplPointerinfo pi = XplType.new_pi();
                pi.set_ref(true);
                type.set_pi(pi);
                type.set_dt(backType);
            }
            else if (netType.IsArray)
            {
                //Si es un array
                //Seteo el puntero a Array
                type.set_ispointer(true);
                XplPointerinfo pi = XplType.new_pi();
                pi.set_ref(true);
                type.set_pi(pi);
                //Establezco el tipo de los elementos del Array como un tipo anidado en el typechoice
                XplType t2 = getXplType(netType.GetElementType(), false);

                int ndim = netType.GetArrayRank();
                XplType arrayType = new XplType();
                arrayType.set_isarray(true);
                type.set_dt(arrayType);
                for (int n = 1; n < ndim; n++)
                {
                    XplType subType = new XplType();
                    subType.set_isarray(true);
                    arrayType.set_dt(subType);                    
                    arrayType = subType;
                }
                arrayType.set_dt(t2);
            }
            else if (netType.IsGenericParameter)
            {
                //ERROR no se soportan tipos genericos
            }
            else
            {
                //Si no es un array, puntero o referencia
                if (netType.FullName == "System.Void")
                    type.set_typename("$VOID$");
                else if (netType.FullName == "System.String")
                    type.set_typename("$STRING$");
                else if (netType.FullName == "System.DateTime")
                    type.set_typename("zoe.lang.DateTime");
                else if (netType.FullName == "System.Object")
                    type.set_typename("$OBJECT$");
                else
                {
                    if(netType.IsGenericType)
                        type.set_typename(processTypeName( getGenericInstanceName(netType) ));
                    else
                        type.set_typename(processTypeName(netType.FullName));
                }
                //Seteo el puntero si es un tipo clase o interfaz
                if (!netType.IsValueType)
                {
                    XplType pointer = new XplType();
                    pointer.set_ispointer(true);
                    XplPointerinfo pi = XplType.new_pi();
                    pi.set_ref(true);
                    pointer.set_pi(pi);
                    pointer.set_dt(type);
                    type = pointer;
                }
            }
			return type;
		}

        private string getGenericInstanceName(Type netType)
        {
            string retName = netType.Namespace + "." + removeGenericSufix(netType.Name) + "Of";
            foreach(Type genericArgumentType in netType.GetGenericArguments()){
                if (genericArgumentType.IsGenericType)
                    retName += getGenericInstanceName(genericArgumentType);
                else
                    retName += genericArgumentType.Name;
            }
            return retName;
        }

        private string removeGenericSufix(string p)
        {
            int index = p.IndexOf('`');
            if (index >= 0)
                return p.Substring(0, index);
            else
                return p;
        }

		XplType getXplTypeFromNetPrimitive(Type netType){
            XplType type = new XplType();
			#region Switch de Simple Type Names
			switch(netType.Name){
				case "Boolean":
					type.set_typename("$BOOLEAN$");break;
				case "Byte":
					type.set_typename("$BYTE$");break;
				case "SByte":
					type.set_typename("$SBYTE$");break;
				case "Char":
					type.set_typename("$CHAR$");break;
				case "String":
					type.set_typename("$STRING$");break;
				case "Int16":
					type.set_typename("$SHORT$");break;
				case "Int32":
					type.set_typename("$INTEGER$");break;
				case "Int64":
					type.set_typename("$LONG$");break;
				case "IntPtr":
					type.set_typename("$INTEGER$");break;
				case "UInt16":
					type.set_typename("$USHORT$");break;
				case "UInt32":
					type.set_typename("$UNSIGNED$");break;
				case "UInt64":
					type.set_typename("$ULONG$");break;
				case "UIntPtr":
					type.set_typename("$UNSIGNED$");break;
				case "Single":
					type.set_typename("$FLOAT$");break;
				case "Double":
					type.set_typename("$DOUBLE$");break;
				case "Decimal":
					type.set_typename("$DECIMAL$");break;
				default:
					type.set_typename("$INTEGER$");
					AddError("El tipo basico '"+netType.Name+"' no pudo ser procesado.",ErrorType.Unsupported);
					break;
			}
			#endregion
			return type;
		}
		#endregion

		#region Miembros Privados Utilitarios
        string NAMESPACE_PREFIX = "DotNET";

		XplNamespace getNamespaceFor(Type type2){
            //string typeNs = NAMESPACE_PREFIX + "." + processTypeName(type2.Namespace);
            string typeNs = processTypeName(type2.Namespace);
            //Primero compruebo si su espacio de nombres ya esta creado o no
			if(p_xplNamespaces.ContainsKey(typeNs)){
				return (XplNamespace)p_xplNamespaces[typeNs];
			}
			else{
				XplNamespace ns=XplDocumentBody.new_Namespace();
                ns.set_name(typeNs);
                p_xplNamespaces.Add(typeNs, ns);

                //XplNamespace ns2 = XplDocumentBody.new_Namespace();
                //ns2.set_name(processTypeName(type2.Namespace));
                p_cache.AddType(type2, ns, true);

				return ns;
			}
		}
		void AddMember(XplClass newClass, XplNode newMember){
            newClass.Children().InsertAtEnd(newMember);
		}
		string getOperatorName(string original){
			return original;
		}
		string processTypeName(string typeName){
			//typeName=p_import.BaseNamespace+"::"+typeName.Replace(".","::");
            return NAMESPACE_PREFIX + "." + typeName.Replace("+", "."); //Esto para los tipos anidados
		}
        //string processTypeName2(string typeName)
        //{
        //    typeName = typeName.Replace(".", "::");
        //    return typeName.Replace("+", "::"); //Esto para los tipos anidados
        //}
        void AddError(string error, ErrorType type)
        {
            Error zoeError = new Error(error + " Type: " + type.ToString());
            zoeError.set_ErrorSource(ErrorSource.OutputModule);
            zoeError.set_ErrorLevel(ErrorLevel.Five);
			p_Errors.AddError(zoeError);
		}
		void AddWarning(string warning){
            Warning zoeError = new Warning(warning);
            zoeError.set_ErrorSource(ErrorSource.OutputModule);
            zoeError.set_ErrorLevel(ErrorLevel.Five);
            p_Errors.AddError(zoeError);
        }
		#endregion

		#region Propiedades
        /// <summary>
        /// Gets the types count.
        /// </summary>
        /// <value>The types count.</value>
		public int TypesCount{
			get{return p_TypesCount;}
		}
        /// <summary>
        /// Gets the Zoe namespaces.
        /// </summary>
        /// <value>The Zoe namespaces.</value>
		public Hashtable xplNamespaces{
			get{return p_xplNamespaces;}
		}
        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>The errors.</value>
		public IErrorCollection Errors{
			get{return p_Errors;}
		}
        /// <summary>
        /// Resets the cache.
        /// </summary>
        public void ResetCache()
        {
            p_cache.ClearCacheFiles();
        }
		#endregion

        #region IZOEImportsDirectiveProcessor Members

        private bool ProcessImport(string[] args, bool genereteOutputFile, XplNode importNode)
        {
            p_import = new ImportParams();
            p_import.ImportNode = importNode;
            string temp = "", temp2 = "";
            int index = 0, count = 0;
            try
            {
                foreach (string arg in args)
                {
                    count++;
                    index = arg.IndexOf("=");
                    if (index < 0)
                    { //Se trata del Espacio de nombres o Tipo a importar
                        p_import.Namespace = arg;
                    }
                    else
                    { //Es un argumento de configuracion
                        temp = arg.Substring(0, index).ToLower();
                        temp2 = arg.Substring(index + 1);
                        switch (temp)
                        {
                            case "ns":
                                p_import.BaseNamespace = temp2;
                                break;
                            case "platform":
                                //Ignoro, asumo que LayerD-Zoe lo proceso correctamente
                                break;
                            case "blockinheritance":
                                p_import.AllTypesFinal = Convert.ToBoolean(temp2);
                                break;
                            case "methodsclass":
                                p_import.GlobalsNamespace = temp2;
                                break;
                            case "constantsclass":
                                p_import.ConstantsNamespace = temp2;
                                break;
                            //Hasta aqui argumentos estandar definidos por LayerD-Zoe
                            //
                            //De aqui para abajo argumentos propios del modulo de salida
                            case "assembly":
                                p_import.AssemblyName = temp2;
                                break;
                            case "assemblyfilename":
                                p_import.AssemblyFileName = temp2;
                                break;
                            case "assemblyfullname":
                                p_import.AssemblyFullName = temp2;
                                break;
                            case "path":
                                p_import.ExtraPath = temp2;
                                break;
                            case "netversion":
                                p_import.NetVersion = temp2;
                                break;
                            case "omitattributes":
                                p_import.IncludeAttributes = Convert.ToBoolean(temp2);
                                break;
                            case "omitevents":
                                p_import.IncludeEvents = Convert.ToBoolean(temp2);
                                break;
                            case "omitdelegates":
                                p_import.IncludeDelegates = Convert.ToBoolean(temp2);
                                break;
                            case "omitenums":
                                p_import.IgnoreEnums = Convert.ToBoolean(temp2);
                                break;
                            case "includeprivatemembers":
                                p_import.IncludePrivateMembers = Convert.ToBoolean(temp2);
                                break;
                            case "ignoregenerics":
                                p_import.IgnoreGenerics = Convert.ToBoolean(temp2);
                                break;
                            default:
                                AddError("Argumento de importación desconocido. Argumento Nº" + count + ".", ErrorType.Arguments);
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                AddError("Error al procesar el argumento Nº" + count + " de la directiva p_import.\n\nConsulte la documentación del Modulo de Salida para información sobre los argumentos soportados.\n\nError Original:" + e.Message, ErrorType.Arguments);
                return false;
            }
            //Aqui tengo los argumentos procesados puedo invocar la importación
            RunImport();
            return true;
        }

        /// <summary>
        /// Processes the imports.
        /// </summary>
        /// <param name="importDirectives">The import directives.</param>
        /// <param name="genereteOutputFile">if set to <c>true</c> [generete output file].</param>
        /// <returns>A Boolean value.</returns>
        public bool ProcessImports(XplName[] importDirectives, bool genereteOutputFile)
        {
            //PENDIENTE : Revisar esto, faltan muchas cosas!!!
            p_currentImportedDocuments = new ArrayList();
            foreach (XplName importDirective in importDirectives)
            {
                string[] argsStr = new string[importDirective.Children().GetLength()];
                int n = 0;
                foreach (XplNode importArg in importDirective.Children())
                {
                    argsStr[n] = importArg.get_StringValue();
                    n++;
                }
                if (ProcessImport(argsStr, genereteOutputFile, importDirective))
                    AddImportedDocument();
            }
            //PENDIENTE : aqui tengo que importar todos los tipos pendientes de las
            //assembly relacionadas con la que importe
            
            //Grabo la cache
            p_cache.SaveCacheFiles();
            return true;
        }

        private void AddImportedDocument()
        {
            //Armo el documento con los espacios de nombres importados y retorno.
            //Falta armar correctamente la seccion "DocumentData" del documento Zoe.
            XplDocument doc = new XplDocument();
            XplDocumentData data = new XplDocumentData(XplDocumenttype_enum.LAYERD_ZOE_DOC, "1.0");
            XplDocumentBody body = new XplDocumentBody();
            doc.set_DocumentData(data);
            doc.set_DocumentBody(body);
            if (p_xplNamespaces != null)
                foreach (XplNamespace ns in p_xplNamespaces.Values)
                    body.Children().InsertAtEnd(ns);
            //Elimino los espacios de nombres importados
            p_xplNamespaces = null;
            p_currentImportedDocuments.Add(doc);
        }

        /// <summary>
        /// Devuelve un conjunto de XplDocument con los datos de las últimas directivas "Import" procesada.
        /// Retorna null si las últimas directivas no se procesaron con exito.
        /// </summary>
        /// <returns>Last imported documents</returns>
        public XplDocument[] GetLastImportProcessDocuments()
        {
            return (XplDocument[])p_currentImportedDocuments.ToArray(typeof(XplDocument));
        }
        /// <summary>
        /// Devuelve el nombre y path del archivo que se genero con el procesamiento de la
        /// última directiva "Import".
        /// </summary>
        /// <returns>
        /// Null si la última directiva no genero un archivo.
        /// </returns>
        public string GetLastImportFileName()
        {
            //En esta version directamente retorno null para indicar
            //que no se guardo ningun archivo
            return null;
        }
        /// <summary>
        /// Devuelve una coleccion con mensajes de Errores producidos al
        /// procesar la última directiva "Import".
        /// </summary>
        /// <returns>Ultimos errores de importacion</returns>
        public IErrorCollection GetLastImportErrors()
        {
            return Errors;
        }
        /// <summary>
        /// Debe retornar verdadero si soporta Indice de tipos en cache,
        /// funcionalidad con la cual el compilador Zoe puede optimizar la
        /// lectura de tipos importados.
        /// </summary>
        /// <returns>True if support cached types</returns>
        public bool SupportCachedTypesIndex()
        {
            return true;
        }

        /// <summary>
        /// Devuelve el Indice de tipos en cache.
        /// </summary>
        /// <returns>A Hashtable with the cached types</returns>
        public Hashtable GetCachedTypesIndex()
        {
            return p_cache.GetCacheIndex();
        }
        /// <summary>
        /// El cliente indica al importador de tipos si debe utilizar la cache de tipos o no.
        /// </summary>
        /// <param name="useTypesCache">Use cached types or not</param>
        public void UseTypesCache(bool useTypesCache)
        {
            p_donotImportCachedTypes = useTypesCache;
        }

        #endregion


        #region Miembros de IZOEImportsDirectiveProcessor

        /// <summary>
        /// Establece el conjunto de paths de busqueda de modulos a importar,
        /// procesamiento dependiente del modulo de salida.
        /// </summary>
        /// <param name="searchPaths">Search paths</param>
        public void SetModulesSearchPath(string[] searchPaths)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
