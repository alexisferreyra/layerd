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
using System.Collections.Generic;
using System.Text;

namespace LayerD.OutputModules
{
    /// <summary>
    /// NET Code Generator
    /// </summary>
    public class CGFactory_NET1CodeGenerator_Beta
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CGFactory_NET1CodeGenerator_Beta"/> class.
        /// </summary>
        public CGFactory_NET1CodeGenerator_Beta()
        {
        }
        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <returns>A IEZOEOutputModuleServices value.</returns>
        public IEZOEOutputModuleServices GetServices()
        {
            return new DotNET_ZOE_Output_Module();
        }
    }
}
