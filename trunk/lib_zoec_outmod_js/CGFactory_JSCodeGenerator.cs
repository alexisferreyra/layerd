/*******************************************************************************
 * Copyright (c) 2012 Intel Corporation.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html
 *
 * Contributors:
 *    Alexis Ferreyra (Intel Corporation) - initial API and implementation and/or initial documentation
 *******************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace LayerD.OutputModules
{
    public class CGFactory_JSCodeGenerator
    {
        public CGFactory_JSCodeGenerator()
        {

        }

        public IEZOEOutputModuleServices GetServices()
        {
            return new JS_ZOE_Output_Module();
        }
    }
}
