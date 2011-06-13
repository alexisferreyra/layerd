/****************************************************************************
 
  Base library for Zoe Output Modules
  
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
using LayerD.CodeDOM;
using System.Collections;
using LayerD.ZOECompiler;

namespace LayerD.OutputModules.Importers
{
	/// <summary>
	/// La interfaz IZOEImportsDirectiveProcessor.
	/// 
	/// Define un metodo estandar para procesar directivas import.
	/// Debe ser implementada por Modulos de Salida para poder
	/// procesar directivas import.
	/// </summary>
	public interface IZOEImportsDirectiveProcessor
	{
        /// <summary>
        /// Establece el conjunto de paths de busqueda de modulos a importar,
        /// procesamiento dependiente del modulo de salida.
        /// </summary>
        /// <param name="searchPaths"></param>
        void SetModulesSearchPath(string[] searchPaths);
        /// <summary>
        /// Procesa un conjunto de directivas "Import" con pasadas en el
        /// argumento "imports".
        /// "generateOutputFiles" indica si se guardan los archivos en disco o no.
        /// </summary>
        /// <returns>True si se proceso con exito, False si no pudo ser procesada la directiva.</returns>
        bool ProcessImports(XplName[] imports, bool genereteOutputFiles);
        /// <summary>
        /// Devuelve un conjunto de XplDocument con los datos de las últimas directivas "Import" procesada.
        /// Retorna null si las últimas directivas no se procesaron con exito.
        /// </summary>
        XplDocument[] GetLastImportProcessDocuments();
        /// <summary>
        /// Devuelve el nombre y path del archivo que se genero con el procesamiento de la
        /// última directiva "Import".
        /// </summary>
        /// <returns>Null si la última directiva no genero un archivo.</returns>
        string GetLastImportFileName();
        /// <summary>
        /// Devuelve una colección con mensajes de Errores/Warnings producidos al
        /// procesar el último conjunto de directivas "Import".
        /// </summary>
        /// <returns>A collection of errors</returns>
		IErrorCollection GetLastImportErrors();
        /// <summary>
        /// El cliente indica al importador de tipos si debe utilizar la cache de tipos o no.
        /// </summary>
        void UseTypesCache(bool useTypesCache);
        /// <summary>
        /// Debe retornar verdadero si soporta Indice de tipos en cache, 
        /// funcionalidad con la cual el compilador Zoe puede optimizar la 
        /// lectura de tipos importados.
        /// </summary>
        bool SupportCachedTypesIndex();
        /// <summary>
        /// Devuelve el Indice de tipos en cache.
        /// </summary>
        Hashtable GetCachedTypesIndex();
    }
}
