﻿/*******************************************************************************
 * Copyright (c) 2012 Intel Corporation, Alexis Ferreyra.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html
 *
 * Contributors:
 *    Alexis Ferreyra (Intel Corporation) - initial API and implementation and/or initial documentation
 *    Alexis Ferreyra  - initial branch from Javascript code generator into new Python code generator
 *******************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace LayerD.OutputModules
{
	public class Python_ZOE_Output_Module: IEZOEOutputModuleServices
	{
        const string _outputModuleVersion = "1.0 Beta";
        const string _defaultPlatform = "python";

        #region IEZOEOutputModuleServices Members

        public string GetOutputModuleDefaultPlatformString()
        {
            return _defaultPlatform;
        }

        public string GetLayerDOutputMouduleVersion()
        {
            return _outputModuleVersion;
        }

        public IEZOERender GetEZOERenderModuleInstance()
        {
            return new PythonZoeRender();
        }

        public IEZOERender GetEZOERenderModuleInstance(string platformName)
        {
            return new PythonZoeRender();
        }

        public LayerD.OutputModules.Importers.IZOEImportsDirectiveProcessor GetZOEImportsDirectiveProcessorModuleInstance()
        {
            return new PythonZoeImporter();
        }

        public LayerD.OutputModules.Importers.IZOEImportsDirectiveProcessor GetZOEImportsDirectiveProcessorModuleInstance(string platformName)
        {
            return new PythonZoeImporter();
        }

        public LayerD.CodeDOM.XplConfig GetOutputModuleInfo()
        {
            return null;
        }

        public LayerD.CodeDOM.XplConfig GetOutputModuleInfo(string platformName)
        {
            return null;
        }

        public LayerD.CodeDOM.XplConfig GetExtendedZOERequirements()
        {
            return null;
        }

        public LayerD.CodeDOM.XplConfig GetExtendedZOERequirements(string platformName)
        {
            return null;
        }

        public bool SetZOEProgramInfo(LayerD.CodeDOM.XplConfig programInfo)
        {
            return true;
        }

        #endregion

        internal static bool IsSupportedPlatform(string platformName)
        {
            if (String.IsNullOrEmpty(platformName)) return false;

            return platformName.ToLowerInvariant().StartsWith(_defaultPlatform.ToLowerInvariant());
        }
    }

}
