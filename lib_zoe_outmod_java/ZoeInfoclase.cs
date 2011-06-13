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
using System.IO;
using System.Text;
using System.Collections;

namespace LayerD.OutputModules
{
    /// <summary>
    /// Guarda temporariamente en memoria la información
    /// de una clase de nivel superior.
    /// </summary>
    public class ZoeInfoclase
    {
        System.Text.Encoding p_outputEncoding = System.Text.Encoding.UTF8;
        TextWriter p_currentClase = null;
        //El nombre de la clase
        public string NameClass;
        //Aca guardamos las lineas del archivo
        public ArrayList Contenido = new ArrayList();

        //El nombre del archivo
        public string Filename;
        //El nombre del paquete de la clase
        public string Paquete;

        public void ZoeInfoClase()
        {
            //Constructor de la clase
        }
        public bool SaveFile()
        {

            // p_outputEncoding
            p_currentClase = new StreamWriter(Filename, false, Encoding.Default);
            foreach (string Lineasclase in Contenido)
            {
                p_currentClase.Write(Lineasclase);
            }
            p_currentClase.Close();
            // Ver como usamos paquete??
            if (File.Exists(Filename))
            {
                return true;
            }

            else return false;

            ///Aca habria:
            ///- Crear el archivo
            ///- Iterar en Contenido y mandar los string al archivo
            ///- Cerrar y devolver true si tuvo exito
        }

    }


    class InfoFuncion
    {
        public string NombreFuncionCompleto;
        public ZoeInfoclase Class;
        public int IndiceDeclaracion;
        public Hashtable Dependencias = new Hashtable();
        //Adentro de la dependencia tendria:
        //Clave: NombreCompleto de la funcion de la cual depende
        //Valor: No hace falta mucho
    }
}