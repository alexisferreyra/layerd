using System;
using System.Collections.Generic;
using System.Text;
using LayerD.CodeDOM;
using System.IO;
using System.Diagnostics;

namespace LayerD
{
    /// <summary>
    /// Encapsula una interfaz al compilador Meta D++ utilizable
    /// desde .NET sin preocuparnos por iniciar procesos.
    /// 
    /// Internamente utiliza el compilador Meta D++ de linea de comandos.
    /// </summary>
    public class MetaDppCompiler
    {
        string[] p_lastCompiledFileNames;
        string COMPILER_FILE_NAME; 
        public MetaDppCompiler()
        {
            string path = Environment.GetEnvironmentVariable("METADPP_COMPILER_PATH");
            if (path == null) path = Environment.GetEnvironmentVariable("ZOE_COMPILER_PATH");
            if (path == null) path = ".";
            COMPILER_FILE_NAME = path + Path.DirectorySeparatorChar + "metadppc.exe";
        }
        public bool CompileFile(string fileName)
        {
            if (!File.Exists(fileName)) return false;
            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo(
                COMPILER_FILE_NAME, "\"" + fileName+"\"");
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            p.StartInfo = startInfo;

            try
            {
                p.Start();
                p.WaitForExit();
                p_lastCompiledFileNames = new string[] { fileName };
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CompileFiles(params string[] fileNames)
        {
            return false;
        }
        public XplDocument LastCompiledDocument
        {
            get {
                XplReader reader=null;
                XplDocument doc = null;
                try
                {
                    reader = new XplReader(Path.GetDirectoryName(p_lastCompiledFileNames[0]) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(p_lastCompiledFileNames[0]) + ".zoe");
                    reader.Read();
                    doc = new XplDocument();
                    doc.Read(reader);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (reader != null) reader.Close();
                }
                return doc; 
            }
        }
        public XplDocument[] LastCompiledDocuments
        {
            get { return null; }
        }

    }
}
