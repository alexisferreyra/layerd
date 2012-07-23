/*******************************************************************************
* Copyright (c) 2007, 2012 Alexis Ferreyra, Intel Corporation.
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
* 
*  Zoe Compiler Core
*  
*  Original Author: Alexis Ferreyra
*  Contact: alexis.ferreyra@layerd.net
*  
*  Please visit http://layerd.net to get the last version
*  of the software and information about LayerD technology.
*
****************************************************************************/

//Archivo: lib_layerdxplc_loader.cs 
//
//Cargador de programas LayerD-Zoe utilizado por
//los restantes modulos del compilador LayerD-Zoe para
//obtener una copia en memoria de un programa LayerD-Zoe o un
//Documento a partir de nombres de archivo.
//

//import "System", "ns=DotNET", "platform=DotNET";
//import "System.Collections", "ns=DotNET", "platform=DotNET";
//import "LayerD.CodeDOM", "ns=DotNET", "platform=DotNET";

using System;
using System.IO;
using System.Xml;
using System.Collections;
using LayerD.CodeDOM;

namespace LayerD.ZOECompiler{

    public class ZoeLoaderException : ApplicationException
    {
        public ZoeLoaderException(string message)
            : base(message)
        {
        }
    }
    class ZOEProgramLoader
    {
        const string LIBRARY_PATH = "programslib";
        /// <summary>
        /// Dado un programa ZOE cargado en memoria, "program", carga
        /// los fuentes de dicho programa en memoria y devuelve una matriz
        /// con el programa y los fuentes.
        /// El primer elemento de la matriz será el programa.
        /// </summary>
        static public XplDocument[] LoadSourceFiles(XplDocument zoeProgram)
        {
            XplReader reader = null;
            XplDocument temp = zoeProgram;
            XplDocument[] program = null;
            try
            {
                if (temp.get_DocumentData().get_DocumentType() != XplDocumenttype_enum.LAYERD_ZOE_PROG)
                {
                    throw new Exception("El programa no es un Documento de Programa ZOE.");
                }
                XplLayerDZoeProgramConfig config = (XplLayerDZoeProgramConfig)temp.get_DocumentData().get_Config().get_Content();
                XplNodeList sourceFiles = config.get_SourceFile();
                //Creo el array para almacenar el programa
                program = new XplDocument[sourceFiles.GetLength() + 1];
                //Asigno el documento de programa al primer elemento
                program[0] = temp;
                int current = 0;
                foreach (XplSourceFile sourceFile in config.get_SourceFile())
                {
                    //PENDIENTE : Falta detectar si hay fuentes duplicados en el listado
                    //y verificar que sucede cuando se proporciona un path completo
                    //y no relativo al archivo de programa.
                    current++;
                    temp = new XplDocument();
                    string sourceFileStr = GetRelativePath(".", sourceFile.get_fileName());
                    reader = new XplReader(sourceFileStr);
                    reader.Read();
                    //Con esto soporto que el archivo incluya la declaracion inicial
                    if (reader.NodeType == XmlNodeType.XmlDeclaration) do reader.Read(); while (reader.NodeType != XmlNodeType.Element);
                    temp.Read(reader);
                    reader.Close();
                    program[current] = temp;
                }
                return program;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null && reader.ReadState != ReadState.Closed) reader.Close();
            }
        }
        /// <summary>
        /// Dado el nombre de archivo de un programa ZOE "ZOEProgramFileName"
        /// carga en memoria el archivo de programa y los fuentes en una matriz.
        /// El primer elemento de la matriz será el documento de programa.
        /// 
        /// No chequea que el archivo exista, si no existe devuelve emite una excepción.
        /// </summary>
        static public XplDocument[] LoadProgram(string ZOEProgramFileName)
        {
            XplReader reader = null;
            XplDocument temp = null;
            XplDocument []program=null;
            try
            {
                reader = new XplReader(ZOEProgramFileName);
                temp = new XplDocument();
                reader.Read();
                //Con esto soporto que el archivo incluya la declaracion inicial
                if (reader.NodeType == XmlNodeType.XmlDeclaration) do reader.Read(); while(reader.NodeType!=XmlNodeType.Element);
                temp.Read(reader);
                reader.Close();
                if (temp.get_DocumentData().get_DocumentType() != XplDocumenttype_enum.LAYERD_ZOE_PROG)
                {
                    throw new ZoeLoaderException("The file " + ZOEProgramFileName + " is not a Zoe Program.");
                }
                XplLayerDZoeProgramConfig config=(XplLayerDZoeProgramConfig)temp.get_DocumentData().get_Config().get_Content();
                XplNodeList sourceFiles = config.get_SourceFile();
                //Creo el array para almacenar el programa
                program = new XplDocument[sourceFiles.GetLength() + 1];
                //Asigno el documento de programa al primer elemento
                program[0] = temp;
                int current = 0;
                foreach (XplSourceFile sourceFile in config.get_SourceFile())
                {
                    //OJO: Falta detectar si hay fuentes duplicados en el listado
                    //y verificar que sucede cuando se proporciona un path completo
                    //y no relativo al archivo de programa.
                    current++;
                    temp = new XplDocument();
                    string sourceFileStr = GetRelativePath(ZOEProgramFileName, sourceFile.get_fileName());
                    reader = new XplReader(sourceFileStr);
                    reader.Read();
                    //Con esto soporto que el archivo incluya la declaracion inicial
                    if (reader.NodeType == XmlNodeType.XmlDeclaration) do reader.Read(); while (reader.NodeType != XmlNodeType.Element);
                    temp.Read(reader);
                    reader.Close();
                    program[current] = temp;
                }
                return program;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null && reader.ReadState != ReadState.Closed) reader.Close();
            }
        }
        /// <summary>
        /// Intenta cargar en memoria el archivo "sourceFile" desde la carpeta de libreria
        /// de fuentes ZOE.
        /// </summary>
        public static XplDocument LoadLibrarySource(string sourceFile)
        {
            XplReader reader = null;
            XplDocument temp = null;
            try
            {
                temp = new XplDocument();
                string sourceFileStr = LIBRARY_PATH + Path.DirectorySeparatorChar + sourceFile;
                reader = new XplReader(sourceFileStr);
                reader.Read();
                //Con esto soporto que el archivo incluya la declaracion inicial
                if (reader.NodeType == XmlNodeType.XmlDeclaration) do reader.Read(); while (reader.NodeType != XmlNodeType.Element);
                temp.Read(reader);
                reader.Close();
                return temp;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null && reader.ReadState != ReadState.Closed) reader.Close();
            }
        }

        private static string GetRelativePath(string originalFileName, string relativeFileName)
        {
            string pathOri = Path.GetDirectoryName(originalFileName);
            string pathRel = Path.GetDirectoryName(relativeFileName);
            string retPath = Path.Combine(pathOri, pathRel);
            return Path.Combine(retPath , Path.GetFileName(relativeFileName) );
        }

        public static void SaveCDOMFile(XplNode node, string fileName)
        {
            XplWriter writer = null;
            try
            {
                writer = new XplWriter(fileName);
                node.Write(writer);
            }
            finally
            {
                if (writer != null)writer.Close();
            }
        }
        public static void LoadCDOMFile(XplNode node, string fileName)
        {
            XplReader reader = null;
            try
            {
                reader = new XplReader(fileName);
                reader.Read();
                node.Read(reader);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }

        public static XplDocument LoadSingleSource(string fileName)
        {
            XplDocument doc = new XplDocument();
            LoadCDOMFile(doc, fileName);
            return doc;
        }
    }
}
