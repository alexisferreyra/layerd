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
