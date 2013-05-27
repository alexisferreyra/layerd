/*******************************************************************************
* Copyright (c) 2012 Intel Corporation.
* All rights reserved. This program and the accompanying materials
* are made available under the terms of the Eclipse Public License v1.0
* which accompanies this distribution, and is available at
* http://www.eclipse.org/legal/epl-v10.html
*
* Contributors:
*       Alexis Ferreyra (Intel Corporation)
*******************************************************************************/
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
