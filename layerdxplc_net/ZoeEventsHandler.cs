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
using LayerD.ZOECompiler;
using System.IO;

namespace LayerD.ZOECompilerUI
{
    class ZoeEventsHandler : IZoeCoreEvents
    {
        ArgumentsData p_arguments;

        public ZoeEventsHandler(ArgumentsData arguments)
        {
            p_arguments = arguments;
        }

        public void BeforeInitCompilation(ZOECompilerCore core)
        {
            // Do nothing
        }

        public void BeforeCompileExtension(ZOECompilerCore core, XplDocument extension)
        {
            // Do nothing
        }

        public void AfterCompileExtension(ZOECompilerCore core, XplDocument extension)
        {
            // Do nothing
        }

        public void BeforeCompileCycle(ZOECompilerCore core, int compileCycleNumber)
        {
            // Do nothing
        }

        public void AfterCompileCycle(ZOECompilerCore core, int compileCycleNumber)
        {
            if (p_arguments.DumpAllCompileCyclesZoe)
                DumpZoe(core, compileCycleNumber);
            if (p_arguments.DumpAllCompileCyclesDpp)
                DumpDpp(core, compileCycleNumber);
            if (p_arguments.DumpAllCompileCyclesErrors)
                DumpErrors(core, compileCycleNumber);
            if (p_arguments.DumpAllCompileCyclesTypesTable)
                DumpTypesTable(core, compileCycleNumber);
        }

        public void BeforeRender(ZOECompilerCore core)
        {
            // Do nothing
        }

        public void AfterEndsCompilation(ZOECompilerCore core)
        {
            // Do nothing
        }

        private void DumpTypesTable(ZOECompilerCore core, int compileCycleNumber)
        {
            if (core.LastTypesTable == null) return;

            StreamWriter writer = File.CreateText("dump_zoec_typestable_" + compileCycleNumber + ".txt");

            using (writer)
            {
                foreach (object item in core.LastTypesTable.Values)
                {
                    TypeInfo typeInfo = item as TypeInfo;
                    if (typeInfo != null)
                    {
                        writer.WriteLine(typeInfo.get_FullName());
                        foreach (MemberInfo member in typeInfo.get_MemberInfoCollection().get_MemberInfoList())
                        {
                            writer.WriteLine("\t" + member.ToString());
                        }
                    }
                    else
                    {
                        string typeAlias = item as string;
                        writer.WriteLine(typeAlias);
                    }
                }
            }
        }

        private void DumpErrors(ZOECompilerCore core, int compileCycleNumber)
        {
            Util.Write("==========================================================================");
            Util.Write(" Errors Dump for Compile Cycle " + compileCycleNumber);
            Util.Write("==========================================================================");
            ZOECConsoleUI.ShowErrors(p_arguments, core);
            Util.Write("==========================================================================");
            Util.Write(" End Errors Dump for Compile Cycle " + compileCycleNumber);
            Util.Write("==========================================================================");
        }

        private void DumpDpp(ZOECompilerCore core, int compileCycleNumber)
        {
            XplDocument doc = core.get_LastResultDocument();
            if (doc == null) return;
            File.WriteAllText("zoec_dump_dpp_cycle_" + compileCycleNumber + ".dpp", doc.get_DocumentBody().ReadableString, System.Text.Encoding.ASCII);
        }

        private void DumpZoe(ZOECompilerCore core, int compileCycleNumber)
        {
            XplDocument doc = core.get_LastResultDocument();
            if (doc == null) return;
            File.WriteAllText("zoec_dump_zoe_cycle_" + compileCycleNumber + ".zoe", doc.ZoeXmlString, System.Text.Encoding.UTF8);
        }
    }
}