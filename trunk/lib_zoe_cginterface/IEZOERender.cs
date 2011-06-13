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
using LayerD.ZOECompiler;

namespace LayerD.OutputModules
{
	/// <summary>
	/// Interfaz Estandar para la renderización de un archivo Zoe utilizando una implementación
	/// especifica, como ser CSZOERenderModule.
	/// </summary>
	public interface IEZOERender
	{
        /// <summary>
        /// Establece el nombre del Archivo ZOE Extendido de 
        /// entrada, en el caso de que no se proporcione el documento
        /// por la interfaz. En dicho caso el Renderizador de Código
        /// lo debe cargar desde la hubicación indicada.
        /// </summary>
        void SetEZOEInputFileName(string EZOEInputFileName);
        /// <summary>
        /// Establece el documento ZOE Extendido que se quiere
        /// renderizar y/o construir. Si se llama esta interfaz
        /// se anula la interfaz de nombre de archivo de entrada.
        /// </summary>
        void SetEZOEInputDocument(XplDocument EZOEInputDocument);
        /// <summary>
        /// Inicia el proceso de renderización y/o construcción.
        /// 
        /// "renderOnly" - Indica que no se debe construir el modulo, sólo generar el código intermedio.
        /// "buildArguments" - Una cadena con argumentos extra a pasar al proceso de construcción
        /// generalmente a un compilador.
        /// "renderArguments" - Una cadena con argumentos a ser porcesados por el renderizador
        /// de código. Ej: Indicarle que guarde el código ZOE recibido, etc. 
        /// </summary>
        bool StartParseDocument(bool renderOnly, string buildArguments, string renderArguments);
        /// <summary>
        /// Establece el Path de salida para el archivo a construir o la 
        /// representación intermedia cuando se llama a "StartParseDocument" con
        /// "renderOnly" en "true".
        /// Si no se llama a esta interfaz, se utilizará el path extraido
        /// del archivo de salida, si el archivo de salida no especifica
        /// ruta se usuara la ruta actual del proceso.
        /// </summary>
        void SetOutputPath(string outputPath);
        /// <summary>
        /// El archivo de salida a construir, si el Generador de Código 
        /// no soporta la generación de un componente único entonces puede
        /// ignorar esta interfaz y utilizar el "outputPath" como path
        /// para generar generar la salida.
        /// Si el archivo de salida especifica ruta, se deberá utilizar esta
        /// para construir el componente, y el path especificado
        /// en path de salida para la representación intermedia,
        /// si no se especifico path de salida se usara el path utilizado
        /// en el archivo de salida como ruta para la representación intermedia.
        /// </summary>
        void SetOutputFileName(string outputFileName);
        /// <summary>
        /// Establece el tipo de modulo a construir, en general
        /// un ejecutable, libreria dinamica o estática, script, etc.
        /// Si no se llama nunca a esta interfaz antes de llamar
        /// a "StartParseDocument" se debe asumir ejecutable.
        /// </summary>
        void SetOutputType(XplLayerDZoeProgramModuletype_enum moduleType);
        /// <summary>
        /// Debe devolver una matriz con los errores generadas durante la
        /// última llamada a "StartParseDocument".
        /// Puede devolver nulo.
        /// </summary>
        IErrorCollection GetLastParseErrors();
        /// <summary>
        /// Set if generation is for debug mode.
        /// </summary>
        /// <param name="isDebugMode">True for debug mode code generation.</param>
        void SetDebug(bool isDebugMode);
        /// <summary>
        /// Called by Zoe compiler with an error list when need the generation
        /// of debug intermediate render file.
        /// If the Zoe output module does not support this mode return false,
        /// otherwise return true and generate intermediate debug render file 
        /// and update error list adding one more error for each error in the 
        /// collection to match the generated output lines/columns numbers.
        /// </summary>
        /// <param name="zoeErrors">The collection of errors supplied by Zoe compiler.</param>
        /// <returns>True if the Zoe Output Module support the generation
        /// of intermediate debug file and mapping of errors to generated
        /// code. False if Zoe Output Module does not support this mode.
        /// </returns>
        bool SetZoeErrorListToMap(IErrorCollection zoeErrors);
	}
}
