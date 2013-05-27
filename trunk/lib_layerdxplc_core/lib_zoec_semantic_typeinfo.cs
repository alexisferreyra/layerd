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
using System.Diagnostics;
using System.Collections;
using LayerD.CodeDOM;
using LayerD.ZOEOutputModulesLibrary;
using System.Globalization;

namespace LayerD.ZOECompiler
{
    public class TypeInfo
    {
        #region Tipos 
        enum XplNodeType
        {
            Namespace,
            Class,
            Function
        }
        #endregion

        #region Datos Privados/ Protegidos
        string p_fullName;
        XplNode p_typeNode;
        XplNodeType p_typeOfTypeNode;
        BaseInfoCollection p_baseInfoCollection;
        MemberInfoCollection p_memberInfoCollection;
        MemberInfo p_fpMemberInfo;
        Section p_sectionOfType;
        XplAccesstype_enum p_accessOfType;
        bool p_inheritanceCalculated;
        bool p_baseCheckeds;
        bool p_isOnDeferedTypeCheck;
        bool p_typeChequed;
        bool p_isCompiledClassfactory;
        #endregion

        #region Constructores
        public TypeInfo(string fullName, XplNode typeNode, XplAccesstype_enum accessOfType, MemberInfo fpMember, bool isCompiledClassfactory)
        {
            p_fullName = fullName;
            p_typeNode = typeNode;
            p_fpMemberInfo = fpMember;
            p_isCompiledClassfactory = isCompiledClassfactory;

            switch (typeNode.get_TypeName())
            {
                case CodeDOMTypes.XplNamespace:
                    p_typeOfTypeNode = XplNodeType.Namespace;
                    // Si es un espacio de nombres no necesita chequear herencia o bases
                    p_baseCheckeds = true;
                    p_inheritanceCalculated = true;
                    p_typeChequed = true;
                    break;
                case CodeDOMTypes.XplClass:
                    p_typeOfTypeNode = XplNodeType.Class;
                    break;
                case CodeDOMTypes.XplFunction:
                    p_typeOfTypeNode = XplNodeType.Function;
                    break;
                default:
                    throw new SemanticException("Invalid TypeNode provided to TypeInfo constructor.");
            }
            set_AccessOfType(accessOfType);
        }
        #endregion


        #region Interfaz Publica
        /// <summary>
        /// Returns if it´s a class in a compiled classfactory module.
        /// Only members from compiled classfactorys modules must be used in calls from virtual subprogram
        /// </summary>
        /// <returns>True if it´s a type from compiled classfactory module</returns>
        public bool get_IsCompiledClassfactory()
        {
            return this.p_isCompiledClassfactory;
        }

        /// <summary>
        /// Devuelve el MemberInfo para un Tipo Puntero a funcion, si no es un tipo puntero 
        /// devuelve nulo.
        /// </summary>
        public MemberInfo get_FpMemberInfo()
        {
            return p_fpMemberInfo;
        }
        /// <summary>
        /// Obtiene la sección en la que fue declarado el tipo.
        /// </summary>
        public Section get_Section()
        {
            return p_sectionOfType;
        }
        /// <summary>
        /// Establece la seccion a la que corresponde el tipo.
        /// </summary>
        public void set_Section(Section section)
        {
            p_sectionOfType = section;
        }
        public bool get_InheritanceCalculated()
        {
            return p_inheritanceCalculated;
        }
        public void set_InheritanceCalculated(bool calculated)
        {
            p_inheritanceCalculated = calculated;
        }
        public bool get_IsNamespace()
        {
            if (p_typeOfTypeNode == XplNodeType.Namespace) return true;
            return false;
        }

        /// <summary>
        /// Returns true if it is a Class. False if it is any other type including Enum, Interface, Struct or Union
        /// </summary>
        /// <returns>Returns true if it is a Class. False if it is any other type including Enum, Interface, Struct or Union</returns>
        public bool get_IsClass()
        {
            if (p_typeNode.get_TypeName() == CodeDOMTypes.XplClass)
            {
                XplClass xplClass = (XplClass)p_typeNode;
                if (p_typeOfTypeNode == XplNodeType.Class
                    && !xplClass.get_isenum()
                    && !xplClass.get_isinterface()
                    && !xplClass.get_isstruct()
                    && !xplClass.get_isunion()) return true;
            }
            return false;
        }
        /// <summary>
        /// Retorna la accesibilidad del tipo
        /// </summary>
        public XplAccesstype_enum get_AccessOfType()
        {
            return p_accessOfType;
        }
        /// <summary>
        /// Establece la accesibilidad del tipo.
        /// </summary>
        public void set_AccessOfType(XplAccesstype_enum newAccessOfType)
        {
            p_accessOfType = newAccessOfType;
        }
        public bool get_IsUnion()
        {
            if (p_typeOfTypeNode == XplNodeType.Class
                && ((XplClass)p_typeNode).get_isunion()) return true;
            return false;
        }
        public bool get_IsStruct()
        {
            if (p_typeOfTypeNode == XplNodeType.Class
                && ((XplClass)p_typeNode).get_isstruct()) return true;
            return false;
        }
        public bool get_IsInterface()
        {
            if (p_typeOfTypeNode == XplNodeType.Class
                && ((XplClass)p_typeNode).get_isinterface()) return true;
            return false;
        }
        /// <summary>
        /// Return true if it is a factory or interactive type
        /// </summary>
        /// <returns>True if it is a factory or itneractive type, false otherwise</returns>
        public bool get_IsFactory()
        {
            if (p_typeOfTypeNode == XplNodeType.Class)
                return ((XplClass)p_typeNode).get_isfactory() || ((XplClass)p_typeNode).get_isinteractive();
            else if (p_typeOfTypeNode == XplNodeType.Function)
                return ((XplFunction)p_typeNode).get_isfactory();
            else
                return false;
        }
        public bool get_IsInteractive()
        {
            if (p_typeOfTypeNode == XplNodeType.Class)
                return ((XplClass)p_typeNode).get_isinteractive();
            else if (p_typeOfTypeNode == XplNodeType.Function)
                return false;
            else
                return false;
        }
        public bool get_IsFPType()
        {
            if (p_typeOfTypeNode == XplNodeType.Function
                && ((XplFunction)p_typeNode).get_fp()) return true;
            return false;
        }
        public bool get_IsEnum()
        {
            if (p_typeOfTypeNode == XplNodeType.Class
                && ((XplClass)p_typeNode).get_isenum()) return true;
            return false;
        }
        /// <summary>
        /// Obtiene el nombre completo del Tipo.
        /// </summary>
        public string get_FullName()
        {
            return p_fullName;
        }
        /// <summary>
        /// Devuelve el nombre simple del tipo.
        /// </summary>
        public string get_Name()
        {
            if (p_typeOfTypeNode == XplNodeType.Class)
                return ((XplClass)p_typeNode).get_name();
            if (p_typeOfTypeNode == XplNodeType.Namespace)
                return ((XplNamespace)p_typeNode).get_name();
            if (p_typeOfTypeNode == XplNodeType.Function)
                return ((XplFunction)p_typeNode).get_name();
            throw new SemanticException("Unexpected internal type of TypeInfo data.");
        }
        /// <summary>
        /// Devuelve el nodo XplNode que declara el tipo.
        /// </summary>
        public XplNode get_TypeNode()
        {
            return p_typeNode;
        }
        public BaseInfoCollection get_BaseInfoCollection()
        {
            if (p_baseInfoCollection == null) p_baseInfoCollection = new BaseInfoCollection();
            if (!p_inheritanceCalculated && !p_isOnDeferedTypeCheck)
            {
                SemanticAnalizer.DeferedTypeCheck(this);
            }
            else if (!p_baseCheckeds && !p_isOnDeferedTypeCheck)
            {
                CheckBases(this);
            }
            return p_baseInfoCollection;
        }
        public MemberInfoCollection get_MemberInfoCollection()
        {
            if (!p_inheritanceCalculated && !p_isOnDeferedTypeCheck)
            {
                SemanticAnalizer.DeferedTypeCheck(this);
            }
            else if (!p_baseCheckeds && !p_isOnDeferedTypeCheck)
            {
                CheckBases(this);
                //CheckBases(this);
            }
            if (p_memberInfoCollection == null) p_memberInfoCollection = new MemberInfoCollection();
            return p_memberInfoCollection;
        }

        /// <summary>
        /// Returns members info collection
        /// </summary>
        public MemberInfoCollection Members
        {
            get
            {
                return this.get_MemberInfoCollection();
            }
        }

        /// <summary>
        /// Indica si el tipo se encuentra actualmente siendo procesado
        /// por el chequeo de tipo diferido.
        /// </summary>
        public bool get_IsOnDeferedTypeCheck()
        {
            return p_isOnDeferedTypeCheck;
        }
        /// <summary>
        /// Establece si el tipo se encuentra actualmente siendo procesado
        /// por el chequeo de tipo diferido.
        /// 
        /// SOLO USADO INTERNAMENTE POR EL ANALIZADOR SEMANTICO
        /// </summary>
        public void set_IsOnDeferedTypeCheck(bool value)
        {
            p_isOnDeferedTypeCheck = value;
        }
        /// <summary>
        /// Establece si el tipo fue chequeado completamente.
        /// </summary>
        internal void set_TypeChequed(bool value)
        {
            p_typeChequed = value;
        }
        internal bool get_TypeChequed()
        {
            return p_typeChequed;
        }

        /// <summary>
        /// Chequea si las bases directas o indirectas han sido completamente chequeadas,
        /// si no han sido completamente chequedas se inicia el chequeo diferido para
        /// dicha base.
        /// </summary>
        private void CheckBases(TypeInfo source)
        {
            if (source == null || source.p_baseCheckeds) return;
            if (source.p_baseInfoCollection == null) source.p_baseInfoCollection = new BaseInfoCollection();
            foreach (BaseInfo baseInfo in source.p_baseInfoCollection.get_BaseInfoList())
            {
                TypeInfo baseType = baseInfo.get_BaseTypeInfo();
                if (baseType != null)
                {
                    if (!baseType.p_baseCheckeds || !baseType.p_inheritanceCalculated)
                        SemanticAnalizer.DeferedTypeCheck(baseType);
                    if (baseType.p_baseInfoCollection != null)
                        foreach (BaseInfo base2 in baseType.p_baseInfoCollection.get_BaseInfoList())
                            CheckBases(base2.get_BaseTypeInfo());
                }
            }
            p_baseCheckeds = true;
        }
        public static bool IsAccesible(TypeInfo type, Scope scope)
        {
            //PENDIENTE : Hacer que esto funcione, EL CONTROL DE TIPOS POR SU NIVEL DE ACCESO!!!
            switch (type.get_AccessOfType())
            {
                case XplAccesstype_enum.PUBLIC:
                    return true;
                case XplAccesstype_enum.PROTECTED:
                    break;
                case XplAccesstype_enum.PRIVATE:
                    break;
                case XplAccesstype_enum.IPUBLIC:
                    break;
                case XplAccesstype_enum.IPROTECTED:
                    break;
                case XplAccesstype_enum.IPRIVATE:
                    break;
                default:
                    break;
            }
            return true;
        }
        #endregion
        
        public override string ToString()
        {
            return get_FullName();
        }

        /// <summary>
        /// Indica si el tipo posee constructor de tipo por defecto o no.
        /// </summary>
        bool p_hasDefaultTypeConstructor;
        bool p_defaultTypeConstructorCalculated;

        /// <summary>
        /// Return true if the Class has a constructor member which returns type type.
        /// </summary>
        /// <returns>Return true if the Class has a constructor member which returns type type.</returns>
        public bool get_HasDefaultTypeConstructor()
        {
            //PENDIENTE : Revisar esto!!! hacerlo mas rapido
            if (p_defaultTypeConstructorCalculated) return p_hasDefaultTypeConstructor;
            MemberInfoCollection mic = get_MemberInfoCollection();
            MemberInfo[] constructores = mic.get_MembersInfo(this.get_Name());
            if (constructores != null)
                foreach (MemberInfo minfo in constructores)
                {
                    XplType retType = minfo.get_ReturnType();
                    if (NativeTypes.IsNativeType(retType.get_typename()))
                    {
                        p_hasDefaultTypeConstructor = true;
                        break;
                    }
                }
            p_defaultTypeConstructorCalculated = true;
            return p_hasDefaultTypeConstructor;
        }

        public bool get_BaseCheckeds()
        {
            return p_baseCheckeds;
        }

        bool p_typeReaded;
        /// <summary>
        /// Devuelve la bandera que indica si el tipo ya realizo la pasada ""ReadTypes"
        /// </summary>
        public bool get_TypeReaded()
        {
            return p_typeReaded;
        }
        /// <summary>
        /// Establece si el tipo ya realizo la pasada "ReadTypes" del analizador semántico
        /// </summary>
        public void set_TypeReaded(bool readed)
        {
            p_typeReaded = readed;
        }

        internal MemberInfo get_DefaultTypeConstructorMemberInfo()
        {
            throw new NotImplementedException();
        }
    }

    #region Clases BaseInfoCollection, BaseInfo
    public class BaseInfoCollection
    {
        private ArrayList p_list;
        public BaseInfoCollection()
        {
            p_list = new ArrayList();
        }
        /// <summary>
        /// Inserta un nuevo tipo en la coleccion de Bases.
        /// 
        /// Si el BaseInfo ya existe devuelve false. 
        /// No chequea si existe un BaseInfo equivalente.
        /// </summary>
        /// <param name="baseTypeInfo">El BaseInfo de la base.</param>
        /// <returns>true si tiene exito. false si ya existe el tipo.</returns>
        public bool InsertBase(BaseInfo baseTypeInfo)
        {
            Debug.Assert(baseTypeInfo != null, "Error Interno: InserBase en BaseInfoCollection invocado con 'baseTypeInfo' nulo.");
            if (p_list.Contains(baseTypeInfo)) return false;
            p_list.Add(baseTypeInfo);
            return true;
        }
        /// <summary>
        /// Elimina 'baseTypeInfo' de la coleccion.
        /// </summary>
        public void RemoveBase(BaseInfo baseTypeInfo)
        {
            p_list.Remove(baseTypeInfo);
        }
        /// <summary>
        /// Elimina el tipo fullTypeName de la colección.
        /// Si el BaseInfo no posee informacion del Tipo Base,
        /// no se eliminara de la coleccion.
        /// 
        /// Sólo funciona si el TypeInfo de la clase base en
        /// BaseInfo esta seteado.
        /// </summary>
        public void RemoveBase(string fullTypeName)
        {
            TypeInfo type = null;
            foreach (BaseInfo baseInfo in p_list)
            {
                type = baseInfo.get_BaseTypeInfo();
                if (type != null && type.get_FullName() == fullTypeName)
                {
                    p_list.Remove(baseInfo);
                    break;
                }
            }
        }
        /// <summary>
        /// Indica si 'fullTypeName' existe en la coleccion.
        /// 
        /// Sólo lo detecta si el TypeInfo de la clase base
        /// en BaseInfo esta seteado.
        /// </summary>
        public bool Contains(string fullTypeName)
        {
            TypeInfo type = null;
            foreach (BaseInfo baseInfo in p_list)
            {
                type = baseInfo.get_BaseTypeInfo();
                if (type != null && type.get_FullName() == fullTypeName) return true;
            }
            return false;
        }
        /// <summary>
        /// Indica si 'fullTypeName' existe en la coleccion.
        /// Y no es el BaseInfo "excludeBase".
        /// 
        /// Sólo lo detecta si el TypeInfo de la clase base
        /// en BaseInfo esta seteado.
        /// </summary>
        public bool Contains(string fullTypeName, BaseInfo excludeBase)
        {
            TypeInfo type = null;
            foreach (BaseInfo baseInfo in p_list)
            {
                type = baseInfo.get_BaseTypeInfo();
                if (type != null && baseInfo!=excludeBase && type.get_FullName() == fullTypeName) return true;
            }
            return false;
        }
        /// <summary>
        /// Obtiene el BaseInfo para el fullTypeName proporcionado.
        /// 
        /// Sólo lo detecta si el TypeInfo de la clase base
        /// en BaseInfo esta seteado.
        /// 
        /// Null si no se encuentra.
        /// </summary>
        public BaseInfo get_Base(string fullTypeName)
        {
            TypeInfo type = null;
            foreach (BaseInfo baseInfo in p_list)
            {
                type = baseInfo.get_BaseTypeInfo();
                if (type != null && type.get_FullName() == fullTypeName) return baseInfo;
            }
            return null;
        }
        /// <summary>
        /// Obtiene una interfaz para iterar en la colección.
        /// </summary>
        public ICollection get_BaseInfoList()
        {
            return p_list;
        }
        /// <summary>
        /// Borra la colección.
        /// </summary>
        public void Clear()
        {
            p_list.Clear();
        }
        /// <summary>
        /// Devuelve la cantidad de BaseInfo en la colección.
        /// </summary>
        public int Count()
        {
            return p_list.Count;
        }
        /// <summary>
        /// Returns the count of base clases not counting interfaces
        /// </summary>
        /// <returns>The base clases count</returns>
        public int BaseClassesCount()
        {
            int count = 0;
            foreach (BaseInfo baseInfo in p_list)
                if (baseInfo.get_IsInherit()) count++;
            return count;
        }
        /// <summary>
        /// Returns the count of interfaces not counting clases
        /// </summary>
        /// <returns>The interfaces count</returns>
        public int InterfacesCount()
        {
            int count = 0;
            foreach (BaseInfo baseInfo in p_list)
                if (!baseInfo.get_IsInherit()) count++;
            return count;
        }
        /// <summary>
        /// Busca la base o interface implementada "directOrIndirectBase",
        /// ya sea directa o indirectamente, si no la encuentra retorna null;
        /// de lo contrario retorna el BaseInfo para la base o interface implementada.
        /// </summary>
        public BaseInfo get_DirectOrIndirectBase(string directOrIndirectBase)
        {
            if (p_list.Count == 0) return null;
            BaseInfo baseInfo = get_Base(directOrIndirectBase);
            if(baseInfo==null)
                foreach (BaseInfo baseOf in p_list)
                {
                    if (!baseOf.get_IsBadBase())
                    {
                        baseInfo = baseOf.get_BaseTypeInfo().get_BaseInfoCollection().get_DirectOrIndirectBase(directOrIndirectBase);
                        if (baseInfo != null) return baseInfo;
                    }                
                }
            return baseInfo;
        }
    }

    #region BaseInfo
    public class BaseInfo
    {
        private TypeInfo p_baseTypeInfo;
        private TypeInfo p_declaratorTypeInfo;
        private XplInherit p_inheritOrImplement;
        private bool p_isInherit;
        private bool p_direct;
        private bool p_isBadBase;
        private object p_tag;

        public override string ToString()
        {
            return get_BaseName();
        }

        public BaseInfo(TypeInfo declaratorTypeInfo, TypeInfo baseTypeInfo, XplInherit inheritNode, bool isDirectBase)
        {
            Debug.Assert(declaratorTypeInfo != null, "Error Interno: en constructor de BaseInfo se invoco con declaratorTypeInfo nulo.");
            p_declaratorTypeInfo = declaratorTypeInfo;
            p_baseTypeInfo = baseTypeInfo;
            p_inheritOrImplement = inheritNode;
            p_isInherit = inheritNode.get_Parent().get_ElementName().StartsWith("Inh",StringComparison.InvariantCulture);
            p_direct = isDirectBase;
        }
        /// <summary>
        /// Devuelve el XplNode "Implement" o "Inherit" en
        /// cual se declaro originalmente la base.
        /// </summary>
        public XplInherit get_DeclarationNode()
        {
            return p_inheritOrImplement;
        }
        /// <summary>
        /// Indica si la base es erronea, no procesada
        /// </summary>
        public bool get_IsBadBase()
        {
            return p_isBadBase;
        }
        /// <summary>
        /// Marca la base como erronea para no procesarla.
        /// </summary>
        public void set_IsBadBase(bool isBadBase)
        {
            p_isBadBase = isBadBase;
        }
        public bool get_IsInherit()
        {
            return p_isInherit;
        }
        public bool IsDirectBase()
        {
            return p_direct;
        }
        public TypeInfo get_BaseTypeInfo()
        {
            return p_baseTypeInfo;
        }
        public void set_BaseTypeInfo(TypeInfo baseTypeInfo)
        {
            p_baseTypeInfo = baseTypeInfo;
        }
        /// <summary>
        /// Devuelve el TypeInfo de la clase padre, nunca puede ser nulo.
        /// </summary>
        public TypeInfo get_DeclaratorTypeInfo()
        {
            return p_declaratorTypeInfo;
        }
        /// <summary>
        /// Devuelve el nombre de la base/interfaz especificado en el nodo
        /// Zoe original.
        /// </summary>
        public string get_BaseName()
        {
            return p_inheritOrImplement.get_type().get_typename();
        }
        public bool get_IsVirtual()
        {
            if (p_isInherit) return p_inheritOrImplement.get_virtual();
            return true;
        }
        public XplAccesstype_enum get_Access()
        {
            if (p_isInherit) return p_inheritOrImplement.get_access();
            return XplAccesstype_enum.PUBLIC;
        }
        public object get_Tag()
        {
            return p_tag;
        }
        public void set_Tag(object tag)
        {
            p_tag = tag;
        }
    }
    #endregion

    #endregion

    #region MemberInfo
    public class MemberInfo
    {
        private enum MemberType
        {
            Field,
            Property,
            Indexer,
            Operator,
            Method,
            Expression,
            BeginCFPermissions,
            EndCFPermissions
        }
        private XplNode p_memberNode;
        private string p_name;
        private bool p_hidden;
        private bool p_virtual;
        private bool p_isBadMember;
        private XplAccesstype_enum p_access;
        private MemberType p_type;
        private TypeInfo p_classType;
        private TypeInfo p_declarationClassType;
        private object p_constantValue;
        XplFunctionBody p_getFunctionBody, p_setFunctionBody;

        public XplFunctionBody get_GetBlock()
        {
            return p_getFunctionBody;
        }
        public XplFunctionBody get_SetBlock()
        {
            return p_setFunctionBody;
        }
        /// <summary>
        /// Indica si el miembro esta marcado como erroneo, en tal caso no debe considerarse como valido
        /// al analizar expresiones.
        /// </summary>
        public bool get_IsBadMember()
        {
            return p_isBadMember;
        }
        /// <summary>
        /// Establece el miembro como erroneo para no ser valido
        /// al analizar expresiones.
        /// </summary>
        public void set_IsBadMember(bool isBadMember)
        {
            p_isBadMember = isBadMember;
        }
        /// <summary>
        /// Establece si el miembro campo es virtual, cuando se usa herencia virtual
        /// </summary>
        public void set_Virtual(bool isvirtual)
        {
            Debug.Assert(isvirtual && !IsField(), "Un miembro no campo no deberia establecerse como de herencia virtual.");
            p_virtual = isvirtual;
        }
        /// <summary>
        /// Indica si el miembro campo es virtual, para cualquier otro tipo de miembro no campo debe ser false.
        /// </summary>
        public bool get_Virtual()
        {
            return p_virtual;
        }
        public XplAccesstype_enum get_Access()
        {
            return p_access;
        }
        public void set_Access(XplAccesstype_enum access)
        {
            p_access = access;
        }
        public TypeInfo get_ClassType()
        {
            return p_classType;
        }
        public TypeInfo get_DeclarationClassType()
        {
            return p_declarationClassType;
        }
        public XplNode get_MemberNode()
        {
            return p_memberNode;
        }
        public string get_MemberName()
        {
            return p_name;
        }
        /// <summary>
        /// Retorna el nombre interno del miembro,
        /// es un nombre único aún para funciones
        /// sobrecargadas.
        /// </summary>
        public string get_MemberInternalName()
        {
            switch (p_type)
            {
                case MemberType.Field:
                case MemberType.Property:
                    return p_name;
                case MemberType.Indexer:
                case MemberType.Operator:
                case MemberType.Method:
                    return ((XplFunction)p_memberNode).get_internalname();
                case MemberType.Expression:
                case MemberType.BeginCFPermissions:
                case MemberType.EndCFPermissions:
                default:
                    return p_name;
            }
        }
        public string get_MemberExternalName()
        {
            switch (p_type)
            {
                case MemberType.Field:
                case MemberType.Property:
                    return p_name;
                case MemberType.Indexer:
                case MemberType.Operator:
                case MemberType.Method:
                    return ((XplFunction)p_memberNode).get_externalname();
                case MemberType.Expression:
                case MemberType.BeginCFPermissions:
                case MemberType.EndCFPermissions:
                default:
                    return p_name;
            }
        }
        public bool get_Hidden()
        {
            return p_hidden;
        }
        public void set_Hidden(bool hidden)
        {
            p_hidden = hidden;
        }
        public void set_ConstantValue(object constantValue)
        {
            p_constantValue = constantValue;
        }
        public object get_ConstantValue()
        {
            return p_constantValue;
        }
        public bool IsStatic()
        {
            XplVarstorage_enum storage = XplVarstorage_enum.STATIC;
            if (p_type == MemberType.Field)
                storage = ((XplField)p_memberNode).get_storage();
            else if (p_type == MemberType.Property)
                storage = ((XplProperty)p_memberNode).get_storage();
            else if (p_type == MemberType.Method || p_type == MemberType.Indexer || p_type == MemberType.Operator)
                storage =((XplFunction)p_memberNode).get_storage();
            return storage == XplVarstorage_enum.STATIC || storage == XplVarstorage_enum.STATIC_EXTERN;
        }
        public bool IsExtern()
        {
            XplVarstorage_enum storage = XplVarstorage_enum.AUTO;
            if (p_type == MemberType.Field)
                storage = ((XplField)p_memberNode).get_storage();
            else if (p_type == MemberType.Property)
                storage = ((XplProperty)p_memberNode).get_storage();
            else if (p_type == MemberType.Method || p_type == MemberType.Indexer || p_type == MemberType.Operator)
                storage = ((XplFunction)p_memberNode).get_storage();
            return storage == XplVarstorage_enum.EXTERN || storage == XplVarstorage_enum.STATIC_EXTERN;
        }
        public bool IsField()
        {
            return p_type == MemberType.Field;
        }
        public bool IsProperty()
        {
            return p_type == MemberType.Property;
        }
        public bool IsIndexer()
        {
            return p_type == MemberType.Indexer;
        }
        public bool IsOperator()
        {
            return p_type == MemberType.Operator;
        }
        public bool IsMethod()
        {
            return p_type == MemberType.Method;
        }
        public bool IsExpression()
        {
            return p_type == MemberType.Expression;
        }
        public bool IsBeginCFPermissions()
        {
            return p_type == MemberType.BeginCFPermissions;
        }
        public bool IsEndCFPermissions()
        {
            return p_type == MemberType.EndCFPermissions;
        }
        /// <summary>
        /// Retorna el modificador "new" del miembro.
        /// Para el caso de expresiones y permisos de classfactorys
        /// retorna false.
        /// </summary>
        public bool IsNew()
        {
            if (p_type == MemberType.Field)
                return ((XplField)p_memberNode).get_new();
            else if (p_type == MemberType.Property)
                return ((XplProperty)p_memberNode).get_new();
            else if (p_type == MemberType.Method || p_type == MemberType.Indexer || p_type == MemberType.Operator)
                return ((XplFunction)p_memberNode).get_new();
            return false;
        }
        public bool IsOverride()
        {
            if (p_type == MemberType.Property)
                return ((XplProperty)p_memberNode).get_override();
            else if (p_type == MemberType.Method || p_type == MemberType.Indexer || p_type == MemberType.Operator)
                return ((XplFunction)p_memberNode).get_override();
            return false;
        }
        /// <summary>
        /// Crea un Member Info con información de un miembro de clase.
        /// </summary>
        /// <param name="classType">El TypeInfo del tipo al que pertenece el miembro, puede ser una clase derivada.</param>
        /// <param name="declarationClassType">El TypeInfo del tipo que declara el miembro, es decir la clase original que lo declara.</param>
        /// <param name="memberNode">El nodo Xpl que declara el miembro.</param>
        public MemberInfo(TypeInfo classType, TypeInfo declarationClassType, XplNode memberNode)
        {
            Debug.Assert(classType != null && declarationClassType != null && memberNode != null,
                "Interno: puntero nulo en la creación de un MemberInfo.");
            p_classType = classType;
            p_declarationClassType = declarationClassType;
            p_memberNode = memberNode;
            p_access = XplAccesstype_enum.PRIVATE;
            XplFunction functionNode = null;
            switch (p_memberNode.get_ElementName())
            {
                case "Function":
                    p_type = MemberType.Method;
                    functionNode = (XplFunction)memberNode;
                    p_name = functionNode.get_name();
                    p_access = functionNode.get_access();
                    break;
                case "Property":
                    p_type = MemberType.Property;
                    XplProperty propertyNode = (XplProperty)memberNode;
                    p_name = propertyNode.get_name();
                    p_access = propertyNode.get_access();
                    p_getFunctionBody = (XplFunctionBody)propertyNode.get_body().FindNode("/Get");
                    p_setFunctionBody = (XplFunctionBody)propertyNode.get_body().FindNode("/Set");
                    break;
                case "Indexer":
                    p_type = MemberType.Indexer;
                    functionNode = (XplFunction)memberNode;
                    p_name = functionNode.get_name();
                    p_access = functionNode.get_access();
                    p_getFunctionBody = (XplFunctionBody)functionNode.get_FunctionBody().FindNode("/Get");
                    p_setFunctionBody = (XplFunctionBody)functionNode.get_FunctionBody().FindNode("/Set");
                    break;
                case "Operator":
                    p_type = MemberType.Operator;
                    functionNode = (XplFunction)memberNode;
                    p_name = functionNode.get_name();
                    p_access = functionNode.get_access();
                    break;
                case "Field":
                    p_type = MemberType.Field;
                    XplField fieldNode = ((XplField)memberNode);
                    p_name = fieldNode.get_name();
                    p_access = fieldNode.get_access();
                    break;
                case "e":
                    p_type = MemberType.Expression;
                    p_name = null;
                    break;
                case "BeginCFPermissions":
                    p_type = MemberType.BeginCFPermissions;
                    p_name = null;
                    break;
                case "EndCFPermissions":
                    p_type = MemberType.EndCFPermissions;
                    p_name = null;
                    break;
            }
        }

        /// <summary>
        /// Obtiene el Nombre Completo del Tipo al que pertenece el Miembro, que puede ser un tipo diferente al tipo donde se declara el miembro.
        /// </summary>
        public string get_ClassTypeFullName()
        {
            return p_classType.get_FullName();
        }

        /// <summary>
        /// Obtiene el Nombre Completo del Tipo en el cual es Declarado el Miembro.
        /// </summary>
        public string get_DeclarationClassTypeFullName()
        {
            return p_declarationClassType.get_FullName();
        }

        public override string ToString()
        {
            return ToString(get_DeclarationClassTypeFullName() + Scope.ScopeSeparator);
        }

        string ToString(string prevName)
        {
            string str = prevName + get_MemberName();
            switch (p_type)
            {
                case MemberType.Field:
                    str += "["+((XplField)p_memberNode).get_type().get_typeStr() + "]";
                    break;
                case MemberType.Property:
                    str += "["+((XplProperty)p_memberNode).get_type().get_typeStr() + "]";
                    break;
                case MemberType.Indexer:
                case MemberType.Operator:
                case MemberType.Method:
                    XplParameters parameters = get_Parameters();
                    if (parameters != null) str += get_ParametersString(parameters);
                    str += "[" + ((XplFunction)p_memberNode).get_ReturnType().get_typeStr() + "]";
                    break;
                case MemberType.Expression:
                case MemberType.BeginCFPermissions:
                case MemberType.EndCFPermissions:
                default:
                    break;
            }
            return str;
        }

        /// <summary>
        /// Returns member full name including full declaration class type name + member name
        /// </summary>
        public string FullName
        {
            get
            {
                return this.get_DeclarationClassTypeFullName() + Scope.ScopeSeparator + this.get_MemberName();
            }
        }

        private static string get_ParametersString(XplParameters parameters)
        {
            string retStr = "(";
            XplNodeList list = parameters.Children();
            if (list != null)
            {
                int n = 0;
                foreach (XplParameter p in list)
                {
                    if (p.get_direction() == XplParameterdirection_enum.INOUT) retStr += "inout ";
                    else if (p.get_direction() == XplParameterdirection_enum.OUT) retStr += "out ";
                    if (p.get_params()) retStr += "params ";
                    retStr += p.get_type().get_typeStr() + " " + p.get_name();

                    n++;
                    if (n < list.GetLength()) retStr += ", ";
                }
            }
            return retStr + ")";
        }
        /// <summary>
        /// Devuelve si existe el modificador "factory" en la declaracion del miembro
        /// </summary>
        public bool IsFactory()
        {
            switch (p_type)
            {
                case MemberType.Field:
                    return ((XplField)p_memberNode).get_isfactory();
                case MemberType.Property:
                    return ((XplProperty)p_memberNode).get_isfactory();
                case MemberType.Indexer:
                case MemberType.Operator:
                case MemberType.Method:
                    return ((XplFunction)p_memberNode).get_isfactory();
                case MemberType.Expression:
                case MemberType.BeginCFPermissions:
                case MemberType.EndCFPermissions:
                default:
                    return false;
            }
        }
        /// <summary>
        /// Indica si el miembro es un Metodo, Indexador u Operador
        /// </summary>
        public bool IsFunction()
        {
            switch (p_type)
            {
                case MemberType.Indexer:
                case MemberType.Operator:
                case MemberType.Method:
                    return true;
                default:
                    return false;
            }
        }
        /// <summary>
        /// Devuelve los Parametros del Metodo, Indexador u Operador.
        /// 
        /// Devuelve null cuando no tiene parametros (aunque puede no
        /// tener parametros aún cuando no se devuelva null).
        /// Devuelve null cuando el miembro no es una funcion.
        /// </summary>
        public XplParameters get_Parameters()
        {
            switch (p_type)
            {
                case MemberType.Indexer:
                case MemberType.Operator:
                case MemberType.Method:
                    return ((XplFunction)p_memberNode).get_Parameters();
                default:
                    return null;
            }
        }
        /// <summary>
        /// Devuelve el tipo de retorno para una funcion,
        /// operador, indexador, propiedad o campo. Si no
        /// es uno de estos tipos de miembro devuelve null.
        /// Para las propiedades y campos devuelve el tipo de la propiedad o campo.
        /// </summary>
        public XplType get_ReturnType()
        {
            switch (p_type)
            {
                case MemberType.Property:
                    return ((XplProperty)p_memberNode).get_type();
                case MemberType.Indexer:
                case MemberType.Operator:
                case MemberType.Method:
                    return ((XplFunction)p_memberNode).get_ReturnType();
                case MemberType.Field:
                    return ((XplField)p_memberNode).get_type();
                default:
                    return null;
            }
        }
        /// <summary>
        /// Indica si posee implementación externa.
        /// </summary>
        public bool get_IsExternal()
        {
            XplVarstorage_enum storage;
            switch (p_type)
            {
                case MemberType.Property:
                    storage = ((XplProperty)p_memberNode).get_storage();
                    break;
                case MemberType.Indexer:
                case MemberType.Operator:
                case MemberType.Method:
                    storage = ((XplFunction)p_memberNode).get_storage();
                    break;
                case MemberType.Field:
                    storage = ((XplField)p_memberNode).get_storage();
                    break;
                default:
                    return false;
            }
            return storage == XplVarstorage_enum.EXTERN || storage == XplVarstorage_enum.STATIC_EXTERN;
        }
        /// <summary>
        /// Indica si los el miembro permite una lista variable de argumentos.
        /// </summary>
        public bool IsVariableArguments()
        {
            XplParameters parameters = get_Parameters();
            if (parameters != null)
            {
                if (parameters.Children().GetLength() > 0)
                    return ((XplParameter)parameters.Children().GetLastNode()).get_params();
            }
            return false;
        }
        public bool IsConstructor()
        {
            if (p_name == p_classType.get_Name() && p_type == MemberType.Method) return true;
            return false;
        }

        public bool IsDestructor()
        {
            if (p_name == "~" + p_classType.get_Name() && p_type == MemberType.Method) return true;
            return false;
        }

        public bool IsFinalizer()
        {
            if (p_name == "Finalize" && p_type == MemberType.Method && (get_Parameters() == null || get_Parameters() != null && get_Parameters().Children().GetLength() == 0))
                return true;
            return false;
        }

        public bool get_IsAccesible(Scope scope)
        {
            if (scope.get_FullClassName().StartsWith(p_declarationClassType.get_FullName(),StringComparison.InvariantCulture))
                return true;
            else
            {
                if (p_access == XplAccesstype_enum.PUBLIC) return true;
                if (p_access == XplAccesstype_enum.IPUBLIC && scope.get_IsInyectedCode()) return true;
                if (p_access == XplAccesstype_enum.PROTECTED || p_access == XplAccesstype_enum.IPROTECTED & scope.get_IsInyectedCode())
                {
                    //Aquí debo chequear si estoy en una clase derivada de la clase
                    //en la cual el miembro fue declarado
                    TypeInfo currentType = scope.get_CurrentType();
                    BaseInfo baseOf = currentType.get_BaseInfoCollection().get_DirectOrIndirectBase(p_declarationClassType.get_FullName());
                    return baseOf != null;
                }
                if (p_access == XplAccesstype_enum.PRIVATE || p_access == XplAccesstype_enum.IPRIVATE)
                    return false;
            }
            return false;
        }


        public static string ToString(MemberInfo[] members)
        {
            string retStr = "";
            foreach (MemberInfo member in members)
                retStr += member.ToString() + " . ";
            return retStr;
        }

        /// <summary>
        /// Returns the parameter at position index.
        /// If the index is out of range returns null.
        /// If the member doesnot have parameters returns null.
        /// If the index is out of range and the last parameter is params, returns the last parameter
        /// </summary>
        /// <param name="index">Zero based position of the parameter to retrieve</param>
        /// <param name="includeParams">Take into account params last parameter when index is out of range</param>
        /// <returns>A parameter or null</returns>
        public XplParameter get_Parameter(int index, bool includeParams)
        {
            if (index < 0) return null;
            XplParameters parameters = this.get_Parameters();
            if (parameters == null) return null;

            if (index >= parameters.Children().GetLength() && index > 0)
            {
                if (!includeParams) return null;
                XplParameter lastParam = (XplParameter)parameters.Children().GetNodeAt(parameters.Children().GetLength() - 1);
                if (lastParam.get_params())
                {
                    return lastParam;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return (XplParameter)parameters.Children().GetNodeAt(index);
            }
        }

        /// <summary>
        /// returns the index in formal parameters list for parameterName
        /// </summary>
        /// <param name="constructorParameterName">name of the parameter to get the index</param>
        /// <returns>Zero based index of the parameter with that name or -1 if not found</returns>
        public int get_IndexOfParameter(string parameterName)
        {
            XplParameters parameters = get_Parameters();
            if (parameters == null) return -1;

            for (int n = 0; n < parameters.Children().GetLength(); n++)
            {
                if (((XplParameter)parameters.Children().GetNodeAt(n)).get_name() == parameterName)
                {
                    return n;
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns if block (last parameter) requires to be evaluated.
        /// Result with members which last parameter is not a block will be indetermined.
        /// </summary>
        public bool RequireEvalBlock
        {
            get
            {
                var parameters = this.get_Parameters();
                if (parameters == null) return false;
                var lastParameter = (XplParameter)parameters.Children().GetNodeAt(parameters.Children().GetLength() - 1);
                return lastParameter.get_direction() == XplParameterdirection_enum.INOUT;
            }
        }

        /// <summary>
        /// Returns true if member is a function or function pointer with one parameter of type "params ^[]^_$OBJECT$"
        /// </summary>
        /// <returns>True if function has one parameter of type "params ^[]^_$OBJECT$"</returns>
        internal bool HasObjectVariableParameters()
        {
            var parameter = this.get_Parameter(0, false);
            if (parameter == null) return false;
            if (!parameter.get_params()) return false;
            var typeStr = parameter.get_type().get_typeStr();
            if (String.IsNullOrEmpty(typeStr) || typeStr != "^_[]^_" + NativeTypes.Object) return false;
            return true;
        }
    }
    #endregion

    #region Clase MemberInfoCollection
    public class MemberInfoCollection
    {
        Hashtable p_memberTable;
        ArrayList p_memberList;

        #region Interfaz Publica
        public MemberInfoCollection()
        {
            p_memberTable = new Hashtable();
            p_memberList = new ArrayList();
        }
        /// <summary>
        /// Obtiene una interfaz de coleccion al almacenamiento interno de
        /// MemberInfoCollection.
        /// </summary>
        public ArrayList get_MemberInfoList()
        {
            return p_memberList;
        }
        /// <summary>
        /// Agrega un nuevo MemberInfo a la colección.
        /// </summary>
        public void InsertMemberInfo(MemberInfo memberInfo)
        {
            int index = p_memberList.Add(memberInfo);            
            string memberName = memberInfo.get_MemberName();
            if (memberName != null && !p_memberTable.ContainsKey(memberName))
                p_memberTable.Add(memberName, index);
        }
        /// <summary>
        /// Obtiene una matriz con todos los miembros
        /// de nombre "name", no se incluyen nunca los
        /// miembros de expresion o permisos. Si no existen
        /// entradas con "name" devuelve "null".
        /// 
        /// Acepta "null" como nombre retornando "null".
        /// </summary>
        public MemberInfo[] get_MembersInfo(string name)
        {
            //PENDIENTE : Mejorar el almacenamiento interno para 
            //mejorar la performance de la busqueda realizada en
            //éste procedimiento.
            if (name == null) return null;
            if (!p_memberTable.ContainsKey(name))
                return null;
            else
            {
                int index = (int)p_memberTable[name];
                ArrayList retValue = new ArrayList();
                for (int n = index; n < p_memberList.Count; n++)
                {
                    if (((MemberInfo)p_memberList[n]).get_MemberName() == name)
                        retValue.Add((MemberInfo)p_memberList[n]);
                }
                return (MemberInfo[])retValue.ToArray(typeof(MemberInfo));
            }
        }
        /// <summary>
        /// Obtiene una matriz con todos los miembros
        /// de nombre "name" que pertenezcan a "className", 
        /// no se incluyen nunca los
        /// miembros de expresion o permisos. Si no existen
        /// entradas con "name" devuelve "null".
        /// 
        /// 'className' puede ser un nombre simple 
        /// o un nombre calificado, si es un nombre calificado
        /// debe tener un formato valido para uso interno.
        /// 
        /// Acepta "null" como nombre retornando "null".
        /// </summary>
        public MemberInfo[] get_MembersInfo(string name, string className)
        {
            //PENDIENTE : Mejorar el almacenamiento interno para 
            //mejorar la performance de la busqueda realizada en
            //éste procedimiento.
            if (name == null) return null;
            if (!p_memberTable.ContainsKey(name))
                return null;
            else
            {
                int index = (int)p_memberTable[name];
                ArrayList retValue = new ArrayList();
                MemberInfo member = null;
                bool isQualified = TypeString.IsQualifiedName(className);
                for (int n = index; n < p_memberList.Count; n++)
                {
                    member = (MemberInfo)p_memberList[n];
                    if (!isQualified)
                    {
                        if (member.get_MemberName() == name
                            && member.get_DeclarationClassType().get_Name() == className)
                            retValue.Add((MemberInfo)p_memberList[n]);
                    }
                    else
                    {
                        if (member.get_MemberName() == name
                            && member.get_DeclarationClassType().get_FullName() == className)
                            retValue.Add((MemberInfo)p_memberList[n]);
                    }
                }
                return (MemberInfo[])retValue.ToArray(typeof(MemberInfo));
            }
        }
        /// <summary>
        /// Obtiene una matriz con todos los miembros
        /// de nombre "name" que no sean heredados,
        /// no se incluyen nunca los miembros de expresion 
        /// o permisos. Si no existen entradas con "name" 
        /// devuelve "null".
        /// 
        /// Acepta "null" como nombre retornando "null".
        /// </summary>
        public MemberInfo[] get_MembersInfoOfType(string name)
        {
            //PENDIENTE : Mejorar el almacenamiento interno para 
            //mejorar la performance de la busqueda realizada en
            //éste procedimiento.
            if (name == null) return null;
            if (!p_memberTable.ContainsKey(name))
                return null;
            else
            {
                int index = (int)p_memberTable[name];
                ArrayList retValue = new ArrayList();
                MemberInfo member = null;
                for (int n = index; n < p_memberList.Count; n++)
                {
                    member = (MemberInfo)p_memberList[n];
                    if (member.get_MemberName() == name
                        && member.get_ClassType() == member.get_DeclarationClassType())
                        retValue.Add(member);
                }
                return (MemberInfo[])retValue.ToArray(typeof(MemberInfo));
            }
        }
        /// <summary>
        /// Devuelve el miembro con el nombre indicado interno, si no se encuentra
        /// devuelve nulo.
        /// </summary>
        public MemberInfo get_MembersInfoFromInternalName(string internalMemberName)
        {
            MemberInfo member = null;
            for (int n = 0; n < p_memberList.Count; n++)
            {
                member = (MemberInfo)p_memberList[n];
                if (member.get_MemberInternalName() == internalMemberName)
                    return member;
            }
            return null;
        }
        /// <summary>
        /// Indica si existe un miembro con el nombre "name" o no sin importar si es de la clase actual.
        /// </summary>
        public bool ExistAnyMemberInfoName(string name)
        {
            if (!p_memberTable.ContainsKey(name))
                return false;
            else
                return true;
        }
        /// <summary>
        /// Indica si existe un miembro con el nombre "name" o no en la clase actual.
        /// Es decir no es un miembro heredado.
        /// </summary>
        public bool ExistMemberInfoName(string name)
        {
            if (!p_memberTable.ContainsKey(name))
                return false;
            else
            {
                MemberInfo[] members = get_MembersInfo(name);
                foreach (MemberInfo member in members)
                    if (member.get_DeclarationClassType() == member.get_ClassType())
                        return true;
                return false;
            }
        }
        #endregion

        public MemberInfo get_MemberFromNode(XplNode memberNode)
        {
            //PENDIENTE : esto es REEE lento mejorarlo URGENTE!
            foreach (MemberInfo member in p_memberList)
                if (Object.ReferenceEquals(member.get_MemberNode(),memberNode)) return member;
            return null;
        }

        public int GetLenght()
        {
            return p_memberList.Count;
        }

        public string ExistAnyMemberInfoNameLike(string like)
        {
            string mname;
            like = like.ToLower(CultureInfo.InvariantCulture);
            double maxValue = 0;
            double currentValue=0;
            string currentMember = null;
            foreach (MemberInfo member in p_memberList)
            {
                mname = member.get_MemberName().ToLower(CultureInfo.InvariantCulture);                
                //if (mname.StartsWith(like) || like.StartsWith(mname)) return member.get_MemberName();
                //if (mname.Contains(like)) return member.get_MemberName();
                currentValue = IsSimilarString(mname, like);
                if (currentValue > 0 && currentValue > maxValue)
                {
                    maxValue = currentValue;
                    currentMember = member.get_MemberName();
                }

            }
            return currentMember;
        }
        public string ExistAnyMemberInfoNameLike(string like, double minLimit)
        {
            string mname;
            like = like.ToLower(CultureInfo.InvariantCulture);
            double currentValue = 0;
            string membersStr = null;
            foreach (MemberInfo member in p_memberList)
            {
                mname = member.get_MemberName().ToLower(CultureInfo.InvariantCulture);
                currentValue = IsSimilarString(mname, like);
                if (currentValue > minLimit)
                {
                    if (membersStr != null) membersStr += ", " + member.get_MemberName();
                    else membersStr = member.get_MemberName();
                }
            }
            return membersStr;
        }

        private static double IsSimilarString(string original, string similar)
        {
            int maxO = original.Length;
            int maxS = similar.Length;
            int current = 0;
            int sameLetters = 0;
            int changedLetters = 0;
            int differentLetters = 0;
            int extraLettersS = maxS - maxO;
            if (extraLettersS < 0) extraLettersS = 0;
            int extraLettersO = maxO - maxS;
            if (extraLettersO < 0) extraLettersO = 0;
            char o, s;
            while (current<maxO && current<maxS)
            {
                o = original[current];
                s = similar[current];
                if (o == s)
                    sameLetters++;
                else if (current + 1 < maxO && current + 1 < maxS)
                {
                    //letter
                    //lteter
                    if (o == similar[current + 1] &&
                        s == original[current + 1])
                    {
                        current++;
                        changedLetters++;
                    }
                }
                else
                    differentLetters++;
                current++;
            }
            //El calculo seria
            //%letrasIguales * 0,7 + %letrasCambiadas * 0,3 - %letrasIncorrectas * 0,25 - (%letrasSobrantesOriginal+%letrasSobrantesSimilar) * 0,1 
            return (sameLetters / (double)maxO) * 0.7d +
                (changedLetters / (double)maxO) * 0.3d -
                (differentLetters / (double)maxO) * 0.25d -
                (extraLettersS / (double)maxO + extraLettersO / (double)maxO) * 0.1d;
        }

    }
    #endregion
}