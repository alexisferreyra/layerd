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
using LayerD.ZOEOutputModulesLibrary;

namespace LayerD.ZOECompiler
{
    public enum ScopeType
    {
        Namespace,
        Class,
        Block,
        Global
    }
    public enum SymbolClass
    {
        Parameter,
        Var
    }
    public class Symbol
    {
        string p_symbolName;
        XplNode p_symbolNode;
        SymbolClass p_symbolClass;
        bool p_isBadSymbol;
        object p_constantValue;


        public Symbol(XplDeclarator symbolNode, string symbolName)
        {
            p_symbolClass = SymbolClass.Var;
            p_symbolName = symbolName;
            p_symbolNode = symbolNode;
        }
        public Symbol(XplParameter symbolNode, string symbolName)
        {
            p_symbolClass = SymbolClass.Parameter;
            p_symbolName = symbolName;
            p_symbolNode = symbolNode;
        }
        public Symbol(string symbolTypeStr, string symbolName)
        {
            p_symbolName = symbolName;
        }

        /// <summary>
        /// Devuelve el nombre del simbolo
        /// </summary>
        public string get_SymbolName()
        {
            return p_symbolName;
        }
        /// <summary>
        /// Devuelve el XplType del simbolo.
        /// </summary>
        public XplType get_SymbolType()
        {
            if(p_symbolClass==SymbolClass.Var)
                return ((XplDeclarator)p_symbolNode).get_type();
            else
                return ((XplParameter)p_symbolNode).get_type();
        }
        /// <summary>
        /// Retorna el XplInitializerList del simbolo, si se
        /// incluyo uno en su declaracion, puede ser nulo.
        /// </summary>
        public XplInitializerList get_SymbolInitializer()
        {
            if (p_symbolClass == SymbolClass.Parameter)
                return ((XplParameter)p_symbolNode).get_i();
            else
                return ((XplDeclarator)p_symbolNode).get_i();
        }
        public SymbolClass get_SymbolClass()
        {
            return p_symbolClass;
        }
        /// <summary>
        /// Obtiene el valor constante del simbolo, si es constante
        /// de lo contrario nulo.
        /// </summary>
        public object get_ConstantValue()
        {
            return p_constantValue;
        }
        /// <summary>
        /// Establece el valor constante del simbolo, para simbolos constantes
        /// </summary>
        public void set_ConstantValue(object constantValue)
        {
            p_constantValue = constantValue;
        }
        /// <summary>
        /// Indica si se incluyo el modificador "exec" en la declaracion
        /// del simbolo.
        /// </summary>
        public bool IsExec()
        {
            if (p_symbolClass == SymbolClass.Parameter)
                return ((XplParameter)p_symbolNode).get_type().get_exec();
            else
                return ((XplDeclarator)p_symbolNode).get_type().get_exec();
        }
        /// <summary>
        /// Indica si el simbolo, en caso de ser un puntero, se declaro
        /// con el modificador "ref", es decir si posee semántica
        /// de referencia.
        /// 
        /// Si el simbolo no es un puntero devuelve false.
        /// </summary>
        public bool IsRef()
        {
            XplType symbolType = null;
            if (p_symbolClass == SymbolClass.Parameter)
                symbolType = ((XplParameter)p_symbolNode).get_type();
            else
                symbolType = ((XplDeclarator)p_symbolNode).get_type();
            if (symbolType.get_ispointer())
            {
                return symbolType.get_pi().get_ref();
            }
            return false;
        }
        /// <summary>
        /// Indica si el simbolo se declaro como constante.
        /// </summary>
        public bool IsConst()
        {
            if (p_symbolClass == SymbolClass.Parameter)
                return ((XplParameter)p_symbolNode).get_type().get_const();
            else
                return ((XplDeclarator)p_symbolNode).get_type().get_const();
        }
        /// <summary>
        /// Retorna el valor de IsBadSymbol, bandera
        /// establecida por el usuario para 
        /// indicar que la declaracion del simbolo tiene
        /// errores y no debe utilizarse.
        /// </summary>
        public bool get_IsBadSymbol()
        {
            return p_isBadSymbol;
        }
        /// <summary>
        /// Establece la bandera para indicar si el simbolo
        /// fue incorrecto en su declaracion.
        /// </summary>
        public void set_IsBadSymbol(bool isBadSymbol)
        {
            p_isBadSymbol = isBadSymbol;
        }
        public override string ToString()
        {
            return p_symbolName + " " + get_SymbolType().get_typeStr();
        }
    }

    public class Scope : ICloneable
    {
        #region ScopeLevel
        private class ScopeLevel : ICloneable
        {
            ScopeType p_type;
            string p_levelName;
            ArrayList p_symbolsList;

            public ScopeLevel(ScopeType type, string name)
            {
                p_type = type;
                p_levelName = name;
                p_symbolsList = new ArrayList();
            }
            public ScopeType get_LevelType()
            {
                return p_type;
            }
            public string get_LevelName()
            {
                return p_levelName;
            }
            public void AddSymbolName(string newSymbolName)
            {
                p_symbolsList.Add(newSymbolName);
            }
            public void RemoveSymbolName(string symbolName)
            {
                if (p_symbolsList == null) return;
                p_symbolsList.Remove(symbolName);
            }
            public ArrayList get_SymbolsNames()
            {
                return p_symbolsList;
            }

            #region ICloneable Members

            public object Clone()
            {
                ScopeLevel clone = new ScopeLevel(p_type, p_levelName);
                clone.p_symbolsList = (ArrayList)this.p_symbolsList.Clone();
                return clone;
            }

            #endregion
        }
        #endregion
        // Aqui va lo nuevo, el rediseño de la clase Scope

        int p_scopeLevel = 0;
        int p_lastNamespaceLevel = 0;
        int p_lastClassLevel = 0;
        ScopeLevel p_currentLevel;
        TypesTable p_typesTable;
        string p_currentFullNamespaceName = String.Empty;
        string p_currentFullClassName = String.Empty;
        string p_currentClassName = String.Empty;

        Stack p_scopeList = null;
        ArrayList p_usingList = null;
        bool p_isOnPointerScope = false;
        bool p_isOnBucleStatement = false;
        bool p_isInyectedCode = false;
        bool p_isInsideFunctionCallBlockArgument = false;
        const char p_scopeSeparator = '.';

        Hashtable p_symbols = null;

        #region Constructores
        public Scope(TypesTable typesTable)
        {
            p_typesTable = typesTable;
            p_symbols = new Hashtable();
            p_scopeList = new Stack();
        }
        #endregion

        public ICollection get_AllSymbols()
        {            
            return p_symbols.Values;
        }
        /// <summary>
        /// Obtiene "OnPointerScope", indicando ignorar referencias y
        /// operadores definidos por el usuario en valores de tipo puntero
        /// al analizar expresiones.
        /// </summary>
        public bool get_IsOnPointerScope()
        {
            return p_isOnPointerScope;
        }
        /// <summary>
        /// Establece "OnPointerScope", indicando ignorar referencias y
        /// operadores definidos por el usuario en valores de tipo puntero
        /// al analizar expresiones.
        /// </summary>
        public void set_IsOnPointerScope(bool isOnPointerScope)
        {
            p_isOnPointerScope = isOnPointerScope;
        }
        /// <summary>
        /// Devuelve el nombre completo del espacio de nombres
        /// en el nivel de alcance actual.
        /// </summary>
        public string get_FullNamespaceName()
        {
            return p_currentFullNamespaceName;
        }
        /// <summary>
        /// Devuelve el nombre completo de la clase en
        /// el nivel de alcance actual.
        /// </summary>
        public string get_FullClassName()
        {
            return p_currentFullClassName;
        }
        /// <summary>
        /// Indica si el nivel actual es un Espacio de Nombres
        /// </summary>
        public bool IsNamespace()
        {
            if (p_scopeLevel == 0) return false;
            return p_currentLevel.get_LevelType() == ScopeType.Namespace;
        }
        /// <summary>
        /// Indica si el nivel actual es una clase
        /// </summary>
        public bool IsClass()
        {
            if (p_scopeLevel == 0) return false;
            return p_currentLevel.get_LevelType() == ScopeType.Class;
        }
        /// <summary>
        /// Indica si el nivel actual es una clase anidada
        /// </summary>
        public bool IsNestedClass()
        {
            //if (p_lastClassLevel == 0) return false;
            //if (p_lastClassLevel - p_lastNamespaceLevel > 1) return true;
            return p_lastClassLevel > 1;
        }
        /// <summary>
        /// Indica si el nivel de alcance actual es un bloque
        /// </summary>
        public bool IsBlock()
        {
            if (p_scopeLevel == 0) return false;
            return p_currentLevel.get_LevelType() == ScopeType.Block;
        }
        /// <summary>
        /// Retorna el tipo del alcance actual
        /// </summary>
        public ScopeType get_ScopeType()
        {
            if (p_scopeLevel == 0) return ScopeType.Global;
            return p_currentLevel.get_LevelType();
        }
        /// <summary>
        /// Retorna el nivel de anidacion de alcance actual.
        /// </summary>
        public int get_ScopeLevel()
        {
            return p_scopeLevel;
        }
        /// <summary>
        /// Indica si se encuentra dentro de un bucle.
        /// </summary>
        public bool get_IsOnBucleStatement()
        {
            return p_isOnBucleStatement;
        }
        /// <summary>
        /// Establece la entrada o salida de un bucle.
        /// </summary>
        public void set_IsOnBucleStatement(bool value)
        {
            p_isOnBucleStatement = value;
        }
        /// <summary>
        /// Indica si nos encontramos en código inyectado.
        /// </summary>
        public bool get_IsInyectedCode()
        {
            return p_isInyectedCode;
        }
        /// <summary>
        /// Establece si es código inyectado el alcance actual.
        /// </summary>
        public void set_IsInyectedCode(bool isInyectedCode)
        {
            p_isInyectedCode = isInyectedCode;
        }
        /// <summary>
        /// Devuelve el tipo de la clase en el alcance actual.
        /// </summary>
        public TypeInfo get_CurrentType()
        {
            return (TypeInfo)p_typesTable[get_FullClassName()];
        }

        #region Manejo de Simbolos
        /// <summary>
        /// Inserta el simbolo "newSymbol" en la tabla de 
        /// simbolos del nivel actual, si ya existe un simbolo
        /// con el mismo nombre retorna false y no lo inserta,
        /// de lo contrario lo inserta y retorna true.
        /// </summary>
        public bool InsertSymbol(Symbol newSymbol)
        {
            if (p_symbols.ContainsKey(newSymbol.get_SymbolName()))
                return false;
            p_symbols.Add(newSymbol.get_SymbolName(), newSymbol);
            //tengo que agregar al listado del nivel actual
            p_currentLevel.AddSymbolName(newSymbol.get_SymbolName());
            return true;
        }
        /// <summary>
        /// Retorna true si el simbolo de nombre "symbolName" existe,
        /// false de lo contrario.
        /// </summary>
        public bool ExistsSymbol(string symbolName)
        {
            return p_symbols.ContainsKey(symbolName);
        }
        /// <summary>
        /// Elimina el simbolo de nombre "symbolName", si existe
        /// retorna true, si no existe retorna false.
        /// </summary>
        public bool RemoveSymbol(string symbolName)
        {
            if (!p_symbols.ContainsKey(symbolName))
                return false;
            p_symbols.Remove(symbolName);
            p_currentLevel.RemoveSymbolName(symbolName);
            return true;
        }
        /// <summary>
        /// Retorna el simbolo de nombre "symbolName",
        /// si no lo encuentra retorna null.
        /// 
        /// Si se llama con null o String.Empty retorna null.
        /// </summary>
        public Symbol get_Symbol(string symbolName)
        {
            if (symbolName == null || symbolName == String.Empty) return null;
            return (Symbol)p_symbols[symbolName];
        }
        #endregion

        /// <summary>
        /// Inserta un nuevo nivel de alcance, de tipo "newScopeType" y 
        /// de nombre "newScopeName". 
        /// El nombre es requerido para un alcance de tipo espacio
        /// de nombres o de tipo de clase, para tipo de bloque no
        /// se requiere bloque y se proporciona es ignorado.
        /// 
        /// Retorna true si se agrego el nivel de alcance, false
        /// si no se agrego.
        /// </summary>
        public bool EnterScope(ScopeType newScopeType, string newScopeName)
        {
            //Primero chequeo que el tipo sea valido            
            if (p_scopeLevel == 0 && newScopeType != ScopeType.Namespace) return false;
            if (IsClass() && newScopeType == ScopeType.Namespace) return false;
            if (newScopeType == ScopeType.Global) return false;
            //Si el tipo es clase o namespace se requiere un scopeName
            if ((newScopeType == ScopeType.Namespace || newScopeType == ScopeType.Class) && (newScopeName == null || newScopeName == String.Empty)) return false;
            if (newScopeType == ScopeType.Namespace)
                if (p_scopeLevel > 0) p_currentFullNamespaceName += p_scopeSeparator + newScopeName;
                else p_currentFullNamespaceName = newScopeName;
            if (newScopeType == ScopeType.Namespace || newScopeType == ScopeType.Class)
                if (p_scopeLevel > 0) p_currentFullClassName += p_scopeSeparator + newScopeName;
                else p_currentFullClassName = newScopeName;
            ScopeLevel newScopeLevel = new ScopeLevel(newScopeType, newScopeName);
            p_scopeList.Push(newScopeLevel);
            p_scopeLevel++;
            if (newScopeType == ScopeType.Namespace) p_lastNamespaceLevel++;
            else if (newScopeType == ScopeType.Class)
            {
                p_currentClassName = newScopeName;
                p_lastClassLevel++;
            }
            p_currentLevel = newScopeLevel;
            return true;
        }
        /// <summary>
        /// Sale del ultimo nivel de alcance entrado, si no 
        /// hay niveles no hace nada y retorna false,
        /// elimina todos los simbolos del nivel del cual se salio.
        /// </summary>
        public bool LeaveScope()
        {
            if (p_scopeLevel == 0) return false;
            int offSet = p_scopeLevel == 1 ? 0 : 1;
            if (p_currentLevel.get_LevelType() == ScopeType.Namespace)
            {
                p_currentFullNamespaceName = p_currentFullNamespaceName.Substring(0, p_currentFullNamespaceName.Length - p_currentLevel.get_LevelName().Length - offSet);
                p_currentFullClassName = p_currentFullClassName.Substring(0, p_currentFullClassName.Length - p_currentLevel.get_LevelName().Length - offSet);
                p_lastNamespaceLevel--;
            }
            if (p_currentLevel.get_LevelType() == ScopeType.Class)
            {
                p_currentFullClassName = p_currentFullClassName.Substring(0, p_currentFullClassName.Length - p_currentLevel.get_LevelName().Length - offSet);
                p_lastClassLevel--;
            }
            //Elimino los simbolos
            foreach (string symbolName in p_currentLevel.get_SymbolsNames())
                p_symbols.Remove(symbolName);
            //Fin eliminacion de simbolos
            p_scopeList.Pop();
            p_scopeLevel--;
            if (p_scopeList.Count > 0)
            {
                p_currentLevel = (ScopeLevel)p_scopeList.Peek();
                if (p_currentLevel.get_LevelType() == ScopeType.Class)
                    p_currentClassName = p_currentLevel.get_LevelName();
                else if (p_currentLevel.get_LevelType() == ScopeType.Namespace)
                    p_currentClassName = String.Empty;
            }
            else p_currentLevel = null;
            return true;
        }
        

        public static char ScopeSeparator
        {
            get { return p_scopeSeparator; }
        }

        /// <summary>
        /// Dado un nombre simple, como "MiTipo" devuelve
        /// el nombre completo de acuerdo al alcance actual, como
        /// "M1.M2.MiTipo".
        /// 
        /// Utiliza el nombre de clase completo en alcance actual.
        /// </summary>
        /// <param name="partialName">Un nombre simple o parcial.</param>
        /// <returns>El nombre completo a partir del nombre simple</returns>
        public string get_FullName(string partialName)
        {
            if (p_scopeLevel == 0) return partialName;
            else
                return p_currentFullClassName + p_scopeSeparator + partialName;
        }
        /// <summary>
        /// Returns the current scope level name, for example de current single class name
        /// </summary>
        /// <returns>The current level name.</returns>
        public string get_ClassName()
        {
            return p_currentClassName;
        }
        /// <summary>
        /// Dado un nombre simple, como "MiTipo" devuelve
        /// el nombre completo de acuerdo al alcance actual, como
        /// "M1.M2.MiTipo".
        /// 
        /// Utiliza el nombre del espacio de nombres completo en alcance actual.
        /// </summary>
        /// <param name="partialName">Un nombre simple o parcial.</param>
        /// <returns>El nombre completo a partir del nombre simple</returns>
        public string get_FullNameWithNamespace(string partialName)
        {
            if (p_scopeLevel == 0) return partialName;
            else
                return p_currentFullNamespaceName + p_scopeSeparator + partialName;
        }

        #region Variables Privadas

        #endregion

        #region ICloneable Members
        /// <summary>
        /// Crea una "Copia" del alcance.
        /// </summary>
        /// <returns>Un objeto Scope identico al actual.</returns>
        public object Clone()
        {
            Scope newScope = (Scope)this.MemberwiseClone();
            if (p_scopeList != null) newScope.p_scopeList = (Stack)this.p_scopeList.Clone();
            if (p_usingList != null) newScope.p_usingList = (ArrayList)this.p_usingList.Clone();
            if (p_currentLevel != null) newScope.p_currentLevel = (ScopeLevel)this.p_currentLevel.Clone();
            if (p_symbols != null) newScope.p_symbols = (Hashtable)this.p_symbols.Clone();
            return newScope;
        }
        #endregion

        /// <summary>
        /// Adds an using clause into the scope.
        /// </summary>
        /// <param name="namespaceName">A qualified name that identifies a namespace or class that is added to scope.</param>
        public void AddUsingDirective(string namespaceName)
        {
            if (p_usingList == null) p_usingList = new ArrayList();
            p_usingList.Add(namespaceName);
        }
        /// <summary>
        /// Elimina todas las clausulas using dentro del alcance.
        /// </summary>
        public void ClearUsingDirectives()
        {
            p_usingList = null;
        }
        public ArrayList get_UsingDirectives()
        {
            return p_usingList;
        }
        /// <summary>
        /// Devuelve un string con un nombre "completo" a partir
        /// de "partialName" + "simpleName" que sea adecuado para
        /// su utilización interna.
        /// </summary>
        public static string MakeFullTypeName(string partialName, string simpleName)
        {
            return partialName + ScopeSeparator + simpleName;
        }


        internal void set_IsInsideFunctionCallBlockArgument(bool flag)
        {
            p_isInsideFunctionCallBlockArgument = true;
        }

        internal bool IsInsideFunctionCallBlockArgument()
        {
            return p_isInsideFunctionCallBlockArgument;
        }
    }
}
