using System;
using System.Collections.Generic;
using System.Text;

namespace LayerD.OutputModules
{
    public class CGFactory_SIFTAL1CodeGenerator_Beta
    {
        public CGFactory_SIFTAL1CodeGenerator_Beta()
        {
        }
        public IEZOEOutputModuleServices GetServices()
        {
            return new SIFTAL_ZOE_Output_Module();
        }
    }
}
