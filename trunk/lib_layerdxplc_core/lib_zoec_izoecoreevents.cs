using System;
using LayerD.CodeDOM;

namespace LayerD.ZOECompiler
{
    /// <summary>
    /// Expose Zoe Compiler Core events
    /// </summary>
    public interface IZoeCoreEvents
    {
        void BeforeInitCompilation(ZOECompilerCore core);

        void BeforeCompileExtension(ZOECompilerCore core, XplDocument extension);

        void AfterCompileExtension(ZOECompilerCore core, XplDocument extension);

        void BeforeCompileCycle(ZOECompilerCore core, int compileCycleNumber);

        void AfterCompileCycle(ZOECompilerCore core, int compileCycleNumber);

        void BeforeRender(ZOECompilerCore core);

        void AfterEndsCompilation(ZOECompilerCore core);
    }
}
