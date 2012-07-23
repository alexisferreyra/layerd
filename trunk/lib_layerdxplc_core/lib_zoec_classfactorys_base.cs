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
using LayerD.CodeDOM;

namespace LayerD.ZOECompiler{
	/*
	Clase Base para Classfactorys Ordinarias
	*/
	public class ClassfactoryBase{
        XplType _instanceType;
        public static ZOECompilerCore __compiler;
		public static XplDocument __currentDTE;
        public static XplDocument[] __program;
        public static XplNode __context;

		public static ZOECompilerCore compiler
        {
			get{return __compiler;}
		}
		public static XplDocument currentDTE
        {
			get{return __currentDTE;}
		}
        public static XplDocument[] program
        {
            get { return __program; }
        }
        public static XplNode context
        {
			get{return __context;}
			set{__context=value;}
		}

        /// <summary>
        /// returns an XplType with the instance type of this classfactory
        /// </summary>
        public XplType InstanceType
        {
            get
            {
                if (_instanceType == null)
                {
                    _instanceType = new XplType();
                    _instanceType.set_typename(this.GetType().FullName);
                }
                return _instanceType;
            }
        }

	}
	/*
	Clase Base para Classfactorys Interactivas
	*/
	public class ClassfactoryInteractiveBase{
        XplType _instanceType;
		public static ZOECompilerCore __compiler;
		public static XplDocument __currentDTE;
		public static XplDocument[] __program;
		public static XplNode __context;

		public static ZOECompilerCore compiler
        {
			get{return __compiler;}
		}
		public static XplDocument currentDTE
        {
			get{return __currentDTE;}
		}
		public static XplDocument[] program
        {
			get{return __program;}
		}
		public static XplNode context
        {
			get{return __context;}
			set{__context=value;}
		}

        /// <summary>
        /// returns an XplType with the instance type of this classfactory
        /// </summary>
        public XplType InstanceType
        {
            get
            {
                if (_instanceType == null)
                {
                    _instanceType = new XplType();
                    _instanceType.set_typename(this.GetType().FullName);
                }
                return _instanceType;
            }
        }
    }
}
