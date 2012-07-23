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
using System;
using System.Collections.Generic;
using System.Text;

namespace LayerD.OutputModules
{
    /// <summary>
    /// NET Code Generator
    /// </summary>
    public class CGFactory_CPP1CodeGenerator_Beta
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CGFactory_CPP1CodeGenerator_Beta"/> class.
        /// </summary>
        public CGFactory_CPP1CodeGenerator_Beta()
        {
        }
        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <returns>A IEZOEOutputModuleServices value.</returns>
        public IEZOEOutputModuleServices GetServices()
        {
            return new CPP_ZOE_Output_Module();
        }
    }
}
