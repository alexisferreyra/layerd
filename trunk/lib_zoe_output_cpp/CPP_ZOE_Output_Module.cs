/*******************************************************************************
* Copyright (c) 2009, 2012 Mateo Bengualid, Intel Corporation.
* All rights reserved. This program and the accompanying materials
* are made available under the terms of the Eclipse Public License v1.0
* which accompanies this distribution, and is available at
* http://www.eclipse.org/legal/epl-v10.html
*
* Contributors:
*       Mateo Bengualid - initial API and implementation
*       Julieta Alvarez (Intel Corporation)
*       Alexis Ferreyra (Intel Corporation)
*******************************************************************************/
/****************************************************************************
 
C++ Output Module for Zoe compiler (for interactive compiling)
  
Original Author: Mateo Bengualid
Contact: apoteoticos@gmail.com
  
Please visit http://layerd.net to get the last version
of the software and information about LayerD technology.

****************************************************************************/
/*-
 * Copyright (c) 2009 Mateo Bengualid
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
using LayerD.OutputModules.Importers;
using LayerD.CodeDOM;
using LayerD.ZOECompiler;

namespace LayerD.OutputModules
{
    public class CPP_ZOE_Output_Module: IEZOEOutputModuleServices
    {
        const string p_OutputModuleVersion = "1.0";
        const string p_DefaultPlatform = "C++";

        #region IEZOEOutputModuleServices Members

        public string GetOutputModuleDefaultPlatformString()
        {
            return p_DefaultPlatform;
        }

        public string GetLayerDOutputMouduleVersion()
        {
            return p_OutputModuleVersion;
        }

        public IEZOERender GetEZOERenderModuleInstance()
        {
            return new CPPZOERenderModule();
        }

        public IEZOERender GetEZOERenderModuleInstance(string platformName)
        {
            return new CPPZOERenderModule();
        }

        public IZOEImportsDirectiveProcessor GetZOEImportsDirectiveProcessorModuleInstance()
        {
            return new CPPImportDirectivesProcessor();
        }

        public IZOEImportsDirectiveProcessor GetZOEImportsDirectiveProcessorModuleInstance(string platformName)
        {
            return new CPPImportDirectivesProcessor();
        }

        public XplConfig GetOutputModuleInfo()
        {
            return null;
        }

        public XplConfig GetOutputModuleInfo(string platformName)
        {
            return null;
        }

        public XplConfig GetExtendedZOERequirements()
        {
            return null;
        }

        public XplConfig GetExtendedZOERequirements(string platformName)
        {
            return null;
        }

        public bool SetZOEProgramInfo(XplConfig programInfo)
        {
            return true;
        }

        #endregion
    }
}
