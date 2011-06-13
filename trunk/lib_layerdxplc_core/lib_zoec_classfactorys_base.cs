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
using LayerD.CodeDOM;

namespace LayerD.ZOECompiler{
	/*
	Clase Base para Classfactorys Ordinarias
	*/
	public class ClassfactoryBase{
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

	}
	/*
	Clase Base para Classfactorys Interactivas
	*/
	public class ClassfactoryInteractiveBase{
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
	}
}
