using System;
using System.Collections.Generic;
using System.Linq;
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
