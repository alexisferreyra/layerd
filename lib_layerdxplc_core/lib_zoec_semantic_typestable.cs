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
using LayerD.ZOEOutputModulesLibrary;

namespace LayerD.ZOECompiler{
    public class TypesTable: Hashtable
    {
        public delegate void AsyncTypeRead(XplNode node, string fullName);

        AsyncTypeRead p_asyncTypeRead;
        Hashtable p_cachedTypesIndex = new Hashtable();
        public TypesTable():base()
        {
        }

        #region Intefaz Publica
        public void set_AsyncTypeRead(AsyncTypeRead asyncTypeRead)
        {
            p_asyncTypeRead = asyncTypeRead;
        }
        public virtual new object this[object fullName]
        {
            get
            {
                object obj = base[fullName];
                if (obj != null)
                {
                    if (obj is string) obj = base[obj];
                }
                else if (obj == null)
                {
                    return ReturnCachedType((string)fullName);
                }
                return obj;
            }
        }

        private TypeInfo ReturnCachedType(string fullName)
        {            
            object node = (XplNode)p_cachedTypesIndex[ConvertToUseOnCache(fullName)];
            if (node != null)
            {
                XplAccesstype_enum access = XplAccesstype_enum.PUBLIC;
                if (((XplNode)node).get_TypeName() == CodeDOMTypes.XplClass)
                {
                    access = ((XplClass)node).get_access();
                }
                else
                {
                    InsertType(fullName, (XplNode)node, access, null);
                }
                p_asyncTypeRead((XplNode)node, fullName);
                return (TypeInfo)this[fullName];
            }
            else return null;
        }

        private string ConvertToUseOnCache(string fullName)
        {
            return fullName;
        }
        /// <summary>
        /// Agrega un nuevo tipo a la tabla de simbolos.
        /// </summary>
        /// <param name="fullName">El nombre completo del tipo.</param>
        /// <param name="typeNode">El nodo XplNode que declara el tipo.</param>
        public void InsertType(string fullName, XplNode typeNode, XplAccesstype_enum accessOfType, MemberInfo fpMember)
        {
            TypeInfo typeInfo = new TypeInfo(fullName,typeNode, accessOfType, fpMember);
            this.Add(fullName, typeInfo);
        }
        /// <summary>
        /// Agrega un nuevo tipo a la tabla de simbolos.
        /// </summary>
        /// <param name="partialName">El nombre parcial del tipo en relación alcance proporcionado.</param>
        /// <param name="typeNode">El nodo XplNode que declara el tipo.</param>
        /// <param name="currentScope">El alcance actual a partir del cual se puede determinar el nombre completo usando el nombre parcial proporcionado.</param>
        /// <param name="accessOfType">El nivel de acceso del tipo.</param>
        /// <param name="fpMemberInfo">El miembro que declara el tipo puntero, para tipos puntero a funcion.</param>
        public void InsertType(string partialName, XplNode typeNode, Scope currentScope, XplAccesstype_enum accessOfType, MemberInfo fpMemberInfo)
        {
            string fullName = currentScope.get_FullName(partialName);
            TypeInfo typeInfo = new TypeInfo(fullName, typeNode, accessOfType, fpMemberInfo);
            this.Add(fullName, typeInfo);
        }
        /// <summary>
        /// Devuelve el nodo XplNode que declara un tipo.
        /// </summary>
        /// <param name="fullName">El nombre completo del tipo.</param>
        /// <returns>El nodo que declara el tipo o nulo si no se encuentra el tipo.</returns>
        public XplNode get_TypeNode(string fullName)
        {
            if (this.ContainsKey(fullName))
            {
                return ((TypeInfo)this[fullName]).get_TypeNode();
            }
            else
            {
                object obj = ReturnCachedType((string)fullName);
                if (obj != null)
                {
                    return ((TypeInfo)obj).get_TypeNode();
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Obtiene un objeto TypeInfo que proporciona información del tipo solicitado.
        /// </summary>
        /// <param name="fullName">El nombre completo del tipo.</param>
        /// <returns>Un objeto TypeInfo o nulo si no se encuenta el tipo.</returns>
        public TypeInfo get_TypeInfo(string fullName)
        {
            if (this.ContainsKey(fullName))
            {
                return (TypeInfo)this[fullName];
            }
            else 
            {
                return ReturnCachedType((string)fullName);
            }
        }
        /// <summary>
        /// Determina si existe el tipo indicado.
        /// </summary>
        public bool Exists(string fullName)
        {
            if (this[fullName]!=null) return true;
            return p_cachedTypesIndex[ConvertToUseOnCache(fullName)] != null;
        }
        /// <summary>
        /// Indica si existe el tipo indicado a partir del nombre parcial y el alcance proporcionados.
        /// </summary>
        public bool Exists(string partialName, Scope currentScope)
        {            
            return this.Exists(currentScope.get_FullName(partialName));
        }
        /// <summary>
        /// Devuelve un nombre de tipos a partir de fullOrPartialName y
        /// currentScope que exista en la tabla de tipos.
        /// Si no existe un tipo a partir de fullOrPartialName devuelve null.
        /// 
        /// Primero intenta utilizar fullOrPartialName, luego fullOrPartialName
        /// más el alcance y luego intenta buscarlo en las directivas using en el alcance
        /// currentScope.
        /// </summary>
        /// <param name="fullOrPartialName">El nombre de tipo parcial, o completo a chequear.</param>
        /// <param name="currentScope">El alcance en el cual buscar si no es un nombre completo.</param>
        /// <returns>Nulo si no encuentra un tipo para fullOrPartialName o el nombre de tipo 
        /// completo si lo encuentra.</returns>
        public string get_ExistingTypeName(string fullOrPartialName, Scope currentScope)
        {
            //Si denota un nombre de tipo completo calificado existente
            if (this.Exists(fullOrPartialName)) return fullOrPartialName;
            //Si es el nombre simple de la clase actual
            if (currentScope.get_ClassName() == fullOrPartialName)
                return currentScope.get_FullClassName();
            //Si es un tipo interno
            string fullTypeName = currentScope.get_FullName(fullOrPartialName);
            if (this.Exists(fullTypeName)) return fullTypeName;
            //En el alcance del espacio de nombres actual:
            fullTypeName = currentScope.get_FullNameWithNamespace(fullOrPartialName);
            if (this.Exists(fullTypeName)) return fullTypeName;
            //Si esta en el alcance de los using actuales
            ArrayList usingDirectives = currentScope.get_UsingDirectives();
            if (usingDirectives == null) return null;
            foreach (string prefix in usingDirectives)
            {
                fullTypeName = prefix + Scope.ScopeSeparator + fullOrPartialName;
                if (this.Exists(fullTypeName)) return fullTypeName;
            }
            return null;
        }
        /// <summary>
        /// Determina si "fullName" existe en la tabla de tipos,
        /// si existe devuelve la misma cadena, de lo contrario
        /// devuelve null.
        /// </summary>
        public string get_ExistingTypeName(string fullName)
        {
            if (this.Exists(fullName)) return fullName;
            return null;
        }
        #endregion

        public void InsertTypeMapping(string typeNameAlias, string realTypeName)
        {
            this.Add(typeNameAlias, realTypeName);
        }
        /// <summary>
        /// Establece el indice de tipos en cache no procesados originalmente.
        /// 
        /// La tabla hash debe tener como indice el nombre de tipo completo y
        /// como valor el nodo XplClass o XplNamespace
        /// </summary>
        public void set_CachedTypesIndex(Hashtable hashtable)
        {
            p_cachedTypesIndex = hashtable;
        }
        /// <summary>
        /// No incluye tipos en la cache en el chequeo :-P
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public bool ExistsTypeInfo(string fullName)
        {
            if (this.ContainsKey(fullName)) return true;
            return false;
        }
    }
}
