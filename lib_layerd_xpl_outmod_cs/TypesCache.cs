/*******************************************************************************
* Copyright (c) 2008, 2012 Alexis Ferreyra, Intel Corporation.
* All rights reserved. This program and the accompanying materials
* are made available under the terms of the Eclipse Public License v1.0
* which accompanies this distribution, and is available at
* http://www.eclipse.org/legal/epl-v10.html
*
* Contributors:
*       Alexis Ferreyra - initial API and implementation
*       Alexis Ferreyra (Intel Corporation)
*******************************************************************************/
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
#undef ZIP_SERIALIZATION
using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Reflection;
using LayerD.CodeDOM;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
using System.Globalization;

namespace LayerD.OutputModules
{
    /// <summary>
    /// Administra la cache de tipos importados de .NET
    /// 
    /// PENDIENTES : 
    /// - SOLO FUNCIONA SI SE USA SIEMPRE EL MISMO ESPACIO DE NOMBRES DE IMPORTACION!!!,
    /// DE LO CONTRARIO SE ROMPEN LOS TIPOS!!
    /// - Mejorar la performance, ya sea no indizando al principio o modificando
    /// el codedom para poder por ejemplo armar el indice a medida que leo el archivo y no
    /// tener que iterar de nuevo.
    /// - Hacer que compruebe si el tipo que se solicita corresponde al mismo assembly, etc.
    /// </summary>
    class TypesCache
    {
        //XplDocument p_cacheDocument = null;
        const int BUFFER_SIZE = 64000;
#if ZIP_SERIALIZATION
        static string p_cacheFileName = "net_importer_cached_types.zip";
#else
        //static string p_cacheFileName = "net_importer_cached_types.bin";
#endif
        bool p_cacheUpdated = false;
        string p_errorStr = null;
        string NAMESPACE_PREFIX = "DotNET";

        Hashtable p_types = new Hashtable();
        Hashtable p_assemblys = new Hashtable();

        public void LoadCache(Assembly assembly)
        {
            XplBinaryReader reader = null;
            GZipStream stream = null;
            XplDocument cacheDocument = new XplDocument();
            //Si se encuentra en la tabla hash el assembly ya se cargo
            string assemblyKey = GetAssemblyKey(assembly);
            string cacheFileName = GetFileNameFor(assemblyKey);
            if (p_assemblys[assemblyKey] != null) return;
            try
            {
                if (File.Exists(cacheFileName))
                {
#if ZIP_SERIALIZATION
                    reader = new BinaryReader(new DeflateStream(File.Open(p_cacheFileName, FileMode.Open),CompressionMode.Decompress));
                    //reader = new XplReader(new DeflateStream(new FileStream(p_cacheFileName,FileMode.Open),CompressionMode.Decompress));
#else
                    reader = new XplBinaryReader(new BufferedStream(File.Open(cacheFileName, FileMode.Open),BUFFER_SIZE));
#endif
                    //reader.Read();
                    int mark = reader.ReadInt32();
                    cacheDocument.BinaryRead(reader);
                    IndexTypes(cacheDocument.get_DocumentBody().get_NamespaceNodeList(), null);
                }
                else
                {
                    cacheDocument.set_ElementName("ZOEDocument");
                    cacheDocument.set_DocumentBody(XplDocument.new_DocumentBody());
                }
            }
            catch (Exception error)
            {
                p_errorStr = error.Message;
                cacheDocument.set_ElementName("ZOEDocument");
                cacheDocument.set_DocumentBody(XplDocument.new_DocumentBody());
            }
            finally
            {
                p_assemblys.Add(assemblyKey, cacheDocument);
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
            }
        }

        private string GetFileNameFor(string assemblyName)
        {
            return Path.GetTempPath() + Path.DirectorySeparatorChar + "zoenetimporter_" + ((string)(typeof(TypesCache).Assembly.FullName.Replace(' ', '_') + assemblyName)).GetHashCode().ToString(CultureInfo.InvariantCulture) + ".cache";
        }
        private void IndexTypes(XplNodeList list, string baseName)
        {
            if (list == null) return;
            string fullName = null;
            foreach (XplNode node in list)
                switch (node.get_TypeName())
                {
                    case CodeDOMTypes.XplNamespace:
                        //if (baseName != null) fullName = baseName + "." + ((XplNamespace)node).get_name();
                        //else 
                        fullName = ((XplNamespace)node).get_name();
                        if(!p_types.ContainsKey(fullName))
                            p_types.Add(fullName, node);
                        IndexTypes(node.Children(), fullName);
                        break;
                    case CodeDOMTypes.XplClass:
                        if (baseName != null) fullName = baseName + "." + ((XplClass)node).get_name();
                        else fullName = ((XplClass)node).get_name();
                        if (!p_types.ContainsKey(fullName))
                        {
                            p_types.Add(fullName, node);
                            IndexTypes(node.Children(), fullName);
                        }
                        break;
                }
        }
        public void ClearCacheFiles()
        {
            foreach (string cacheFileName in p_assemblys.Keys)
            {
                string cacheFileName2 = GetFileNameFor(cacheFileName);
                ClearCacheFile(cacheFileName2);
            }
        }

        private void ClearCacheFile(string cacheFileName2)
        {
            try
            {
                if (File.Exists(cacheFileName2))
                    File.Delete(cacheFileName2);
            }
            catch (Exception error)
            {
                p_errorStr = error.Message;
            }
        }
        private void SaveCacheFile(XplDocument cacheDocument,string cacheFileName)
        {
            if (p_cacheUpdated)
            {
                ClearCacheFile(cacheFileName);
#if ZIP_SERIALIZATION
                DeflateStream stream = null;
#endif
                XplBinaryWriter writer = null;
                try
                {
#if ZIP_SERIALIZATION
                    //stream = new DeflateStream(new FileStream(p_cacheFileName, FileMode.CreateNew), CompressionMode.Compress);
                    writer = new BinaryWriter(new DeflateStream(File.Open(p_cacheFileName, FileMode.Create), CompressionMode.Compress));
                    //writer = new XplWriter(stream);
#else
                    writer = new XplBinaryWriter(new BufferedStream(File.Open(cacheFileName,FileMode.Create),BUFFER_SIZE));
#endif
                    cacheDocument.BinaryWrite(writer);
                }
                finally
                {
                    if (writer != null) writer.Close();
                }
            }
        }
        public XplNode GetType(Type dotNetType)
        {
            XplNode retType = (XplNode)p_types[ProcessTypeName(dotNetType.FullName)];
            return retType;
        }
        /// <summary>
        /// Devuelve la cache de tipos
        /// </summary>
        public Hashtable GetCacheIndex()
        {
            return p_types;
        }
        public void AddType(Type dotNetType, XplNode newZoeType, bool isNamespace)
        {
            // PENDIENTE : cuando se agregan nuevos tipos en un espacio de nombre
            // existente se utiliza un nodo que es del primer assembly que contenga
            // el espacio de nombres, por lo tanto no se logra tener modularidad entre
            // archivos de cache cuando se comparten los espacios de nombres, cosa comun 
            // en toda la libreria de clases de .NET por tanto terminamos teniendo
            // un solo archivo grande, lo cual no es el objetivo.
            // Al cambiarlo se podría aprovechar a indizar los tipos y cargarlos sólo
            // cuando nos los pidan.
            string fullName = ProcessTypeName(isNamespace ? dotNetType.Namespace : dotNetType.FullName);
            if (p_types[fullName] != null) return;
            p_types.Add(fullName, newZoeType);
            string parentFullName = RemoveInternalName(fullName);
            if (parentFullName != fullName && p_types[parentFullName]!=null)
            {
                XplNode parentType = (XplNode)p_types[parentFullName];
                if (parentType.get_TypeName() == CodeDOMTypes.XplNamespace)
                {
                    ((XplNamespace)parentType).Children().InsertAtEnd(newZoeType);
                    p_cacheUpdated = true;
                }
                else
                {
                    ((XplClass)parentType).Children().InsertAtEnd(newZoeType);
                    p_cacheUpdated = true;
                }
            }
            else
            {
                if (newZoeType.get_TypeName() == CodeDOMTypes.XplNamespace)
                {
                    ((XplDocument)p_assemblys[GetAssemblyKey(dotNetType.Assembly)]).get_DocumentBody().Children().InsertAtEnd(newZoeType);
                    p_cacheUpdated = true;
                }
            }
        }

        private string GetAssemblyKey(Assembly assembly)
        {
            return assembly.FullName;// +File.GetCreationTimeUtc(assembly.Location).ToFileTimeUtc().ToString();
        }

        string RemoveInternalName(string fullName)
        {
            int index = fullName.LastIndexOf('.');
            if (index > 0) return fullName.Remove(index);
            return fullName;
        }
        string ProcessTypeName(string typeName)
        {
            //typeName = typeName.Replace(".", "::");
            return NAMESPACE_PREFIX + "." + typeName.Replace("+", "."); //Esto para los tipos anidados
        }

        public void SaveCacheFiles()
        {
            foreach (string assemblyName in p_assemblys.Keys)
            {
                SaveCacheFile((XplDocument)p_assemblys[assemblyName], GetFileNameFor(assemblyName));
            }
            p_cacheUpdated = false;
        }
    }
}
