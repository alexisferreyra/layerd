/*******************************************************************************
* Copyright (c) 2002-2008, 2012 Alexis Ferreyra, Intel Corporation.
* All rights reserved. This program and the accompanying materials
* are made available under the terms of the Eclipse Public License v1.0
* which accompanies this distribution, and is available at
* http://www.eclipse.org/legal/epl-v10.html
*
* Contributors:
*       Alexis Ferreyra - initial API and implementation
*       Alexis Ferreyra (Intel Corporation) - bug fixing and improvements
*******************************************************************************/
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
using System.Collections;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;

namespace LayerD.CodeDOM{

    public static class TypeString
    {
        /// <summary>
        /// Determina si el nombre proporcionado es un nombre calificado.
        /// No analiza semántica. No valida la corrección sintactica del nombre.
        /// 
        /// Busca ":" o "."
        /// </summary>
        public static bool IsQualifiedName(string name)
        {
            for (int n = 0; n < name.Length; n++)
            {
                if (name[n] == ':' || name[n] == '.') return true;
            }
            return false;
        }
        /// <summary>
        /// returns a simple name from qualified one. for example a.b.c returns c.
        /// If the name is not qualified returns the same name
        /// </summary>
        /// <param name="fullName">A qualified fullname or a simple name</param>
        /// <returns>most external simple name like c in a.b.c or d in d</returns>
        public static string GetSimpleNameFromQualified(string fullName)
        {
            int index1 = fullName.LastIndexOf('.'),
                index2 = fullName.LastIndexOf(':');
            index1 = index1 > index2 ? index1 : index2;
            if (index1 < 0) return fullName;
            return fullName.Substring(index1 + 1);
        }

        /// <summary>
        /// removes simple name from a qualified name. for example a.b.c returns a.b
        /// If the name is not qualified returns the same name
        /// </summary>
        /// <param name="fullName">A qualified fullname or a simple name</param>
        /// <returns>internal name like a.b in a.b.c or d in d</returns>
        public static string GetTypeNameFromQualified(string fullName)
        {
            int index1 = fullName.LastIndexOf('.'),
                index2 = fullName.LastIndexOf(':');
            index1 = index1 > index2 ? index1 : index2;
            if (index1 < 0) return fullName;
            if (fullName[index1] == ':')
            {
                return fullName.Substring(0, index1 - 1);
            }
            else
            {
                return fullName.Substring(0, index1);
            }
        }

        /// <summary>
        /// Convierte una referencia a un tipo puntero.
        /// 
        /// No llamar con tipos no referencia o valores nulos o vacios.
        /// </summary>
        public static string ChangeReferenceToPointer(string typeStr)
        {
            return '*' + typeStr.Substring(1);
        }
        /// <summary>
        /// Crea una referencia al tipo 'typeStr'.
        /// 
        /// No llamar con valores nulos o vacios.
        /// </summary>
        public static string MakeReferenceTypeTo(string typeStr)
        {
            return "^_" + typeStr;
        }
        /// <summary>
        /// Devuelve la cantidad de dimensiones de un tipo Array.
        /// 
        /// Indeterminado si no se llama con un tipo matriz.
        /// </summary>
        public static int GetArrayDimensions(string arrayTypeStr)
        {
            int count = 0, pos = 0;
            while (arrayTypeStr[pos] == '[')
            {
                //PENDIENTE : Considerar cuando se tiene dimensiones fijas como
                //en "[2][3][5]MiTipo"
                count++; pos += 2;
            }
            return count;
        }
        /// <summary>
        /// Determina si el tipo es un puntero de un nivel a un Array.
        /// O una referencia de un nivel a un Array.
        /// 
        /// Si el tipo no es un puntero el resultado es indeterminado.
        /// </summary>
        public static bool IsPointerToArrayType(string typeStr)
        {
            //Para ser un puntero a un Array debe tener la forma:
            //     *_[]tipoElemento
            //     ^_[]tipoElemento
            return typeStr[2] == '[';
        }
        /// <summary>
        /// Elimina todas las dimensiones de un tipo y retorna el tipo
        /// de elementos del array más interno.
        /// 
        /// Ej: [][][]$CHAR$ --> $CHAR$
        /// 
        /// Indeterminado si no se llama con una cadena que no sea un array.
        /// </summary>
        public static string RemoveAllDimensionsFromArrayType(string typeStr)
        {
            do
                typeStr = RemoveArrayTypeFromType(typeStr);
            while (IsArrayType(typeStr));
            return typeStr;
        }
        /// <summary>
        /// Crea una cadena designando un "Puntero al tipo typeStr".
        /// Admite punteros con semantica de referencia.
        /// 
        /// NO LLAMAR CON NULL
        /// </summary>
        public static string MakePointerTypeTo(string typeStr)
        {
            //PENDIENTE : revisar cuando se tenga en cuenta los modificadores
            //const y volatile.
            //Revisar punteros a miembro de clases.
            //
            if (typeStr[0] == '^') typeStr = '*' + typeStr.Substring(1);
            return "*_" + typeStr;
        }
        /// <summary>
        /// Indica si el tipo identificado por "typeStr" es un tipo puntero o no.
        /// También devuelve verdadero si es un puntero con semántica de referencia.
        /// 
        /// NO LLAMAR CON NULL
        /// </summary>
        public static bool IsPointerType(string typeStr)
        {
            return typeStr[0] == '*' || typeStr[0] == '^';
        }
        /// <summary>
        /// Indica si el tipo identificado por "typeStr" es un tipo puntero
        /// con semantica de referencia o no.
        /// 
        /// NO LLAMAR CON NULL
        /// </summary>
        public static bool IsReferencePointerType(string typeStr)
        {
            if (typeStr[0] == '^') return true;
            else if (typeStr[0] == '*')
            {
                if (typeStr[2] == ':')
                {
                    int endIndex = typeStr.IndexOf(':', 3);
                    return IsReferencePointerType(typeStr.Substring(endIndex + 1));
                }
                else
                {
                    return IsReferencePointerType(typeStr.Substring(2));
                }
            }
            else return false;
        }
        /// <summary>
        /// Indica si el tipo identificado por "typeStr" es un tipo
        /// matriz o no.
        /// 
        /// NO LLAMAR CON NULL
        /// </summary>
        public static bool IsArrayType(string typeStr)
        {
            return typeStr[0] == '[';
        }
        public enum RemoveReferenciesType
        {
            ExtractType,
            SimpleExpression,
            MemberAccess,
            ArrayAccess,
            IndirectionOperator
        }
        /// <summary>
        /// Calcula el tipo obtenido a partir de "typeStr" luego
        /// de aplicar las indirecciones automaticas en un tipo puntero
        /// con semantica de referencia.
        /// 
        /// NO LLAMAR CON NULL
        /// "TYPESTR" DEBE SER UN TIPO DE REFERENCIA; DE LO CONTRARIO
        /// EL RESULTADO ES INDETERMINADO.
        /// </summary>
        public static string RemoveReferencesFromType(string typeStr, RemoveReferenciesType type)
        {
            switch (type)
            {
                case RemoveReferenciesType.SimpleExpression:
                    while (IsPointerType(RemovePointerIndirectionsFromType(typeStr, 1))) typeStr = RemovePointerIndirectionsFromType(typeStr, 1);
                    Debug.Assert(typeStr[0] == '^' || typeStr[0] == '*', "Internal error while dereferencing.");
                    typeStr = '^' + typeStr.Substring(1);
                    break;
                case RemoveReferenciesType.ExtractType:
                    while (IsPointerType(typeStr)) typeStr = RemovePointerIndirectionsFromType(typeStr, 1);
                    break;
                case RemoveReferenciesType.ArrayAccess:
                case RemoveReferenciesType.MemberAccess:
                    typeStr = RemovePointerIndirectionsFromType(typeStr, 1);
                    break;
                case RemoveReferenciesType.IndirectionOperator:
                    typeStr = RemovePointerIndirectionsFromType(typeStr, 1);
                    break;
                default:
                    break;
            }
            return typeStr;
        }
        /// <summary>
        /// Realiza "count" indirecciones en "typeStr" y retorna la 
        /// cadena de tipo obtenida.
        /// Se puede utilizar con referencias en dicho caso elimina la referencia.
        /// 
        /// Si la cantidad de indirecciones es mayor a la indirección del tipo
        /// puntero el resultado es indeterminado.
        /// Si el tipo no es un tipo puntero el resultado es indeterminado.
        /// Si se llama con "count" menor a "1" el resultado es indeterminado.
        /// </summary>
        public static string RemovePointerIndirectionsFromType(string typeStr, int count)
        {
            if (typeStr[2] != ':')
            {
                typeStr = typeStr.Substring(2);
            }
            else
            {
                int index = typeStr.IndexOf(':', 3);
                typeStr = typeStr.Substring(index + 1);
            }
            //typeStr = typeStr.Remove(0, 2);
            if (count <= 1) return typeStr;
            else return RemovePointerIndirectionsFromType(typeStr, count - 1);
        }
        /// <summary>
        /// Elmina el tipo Array de una cadena de identificadora de tipo y devuelve
        /// el tipo de los elementos.
        /// 
        /// No llamar con una cadena que no sea un tipo matriz, nula o vacia.
        /// </summary>
        public static string RemoveArrayTypeFromType(string paramTypeStr)
        {
            if (paramTypeStr[1] == ']') return paramTypeStr.Substring(2);
            else return paramTypeStr.Substring(paramTypeStr.IndexOf(']') + 1);
        }
    }

	public class ZoeHelper{
		private ZoeHelper(){}

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
                if (writer != null) writer.Close();
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

		static public string Att_ToString(string p){
            return p;
        }
		static public string Att_ToString(long p){
			return p.ToString(CultureInfo.InvariantCulture);
		}
		static public string Att_ToString(ulong p){
            return p.ToString(CultureInfo.InvariantCulture);
		}
		static public string Att_ToString(bool p){
			if(p)return "true";
			else return "false";
		}
		static public string Att_ToString(DateTime p){
            return p.ToUniversalTime().ToString(CultureInfo.InvariantCulture);
		}
		static public uint StringAtt_To_UINT(string str){
            return Convert.ToUInt32(str, CultureInfo.InvariantCulture);
		}
		static public int StringAtt_To_INT(string str){
            return Convert.ToInt32(str, CultureInfo.InvariantCulture);
		}
		static public bool StringAtt_To_BOOL(string str){
			return str == "true";
		}
		static public string StringAtt_To_STRING(string str){
            return str;
		}
		static public DateTime StringAtt_To_DATETIME(string str){
            return Convert.ToDateTime(str, CultureInfo.InvariantCulture);
		}

        /// <summary>
        /// Busca la primera información de fuente LayerD que encuentre empezando
        /// por el nodo "node" y subiendo en el árbol hasta encontrar la info
        /// de origen de fuente, si no encuentra la info devuelve una cadena vacia.
        /// 
        /// Devuelve una cadena completa con numeros de linea y nombre del fuente con el formato:
        /// "lnInicio,lnFin,srcFileName"
        /// ó
        /// "lnInicio,clInicio,lnFin,clFin,srcFileName"
        /// donde "ln" por "line" y "cl" por columna.
        /// 
        /// Asume que el formato de los "ldsrc" en los nodos es correcto.
        /// </summary>
        public static string GetFirstLayerDFullSourceData(XplNode node)
        {
            string retStr = String.Empty;
            string[] strArray = null;
            string lineNoInfo = String.Empty;
            XplNode previous = null;
            XplNodeList currentList = null;
            int currentIndex = -1;

            while (node != null)
            {
                retStr = node.get_ldsrc();
                if (retStr != null && retStr!=String.Empty)
                {
                    strArray = retStr.Split(',');
                    if (strArray.Length == 3 || strArray.Length == 5)
                    {
                        if (lineNoInfo == String.Empty) break;
                        retStr = lineNoInfo + "," + strArray[strArray.Length - 1];
                        break;
                    }
                    else if (lineNoInfo == String.Empty)
                    {
                        lineNoInfo = retStr;
                        if (strArray.Length == 1) lineNoInfo += "," + lineNoInfo;
                    }
                }
                //previous = node.PreviousSibling;
                //node = previous != null ? previous : node.get_Parent();
                if (currentList == null)
                {
                    previous = node.get_Parent();
                    if (previous != null)
                    {
                        currentList = previous.Children();
                        if (currentList != null) currentIndex = currentList.GetIndexOf(node);
                        if (currentIndex > 0)
                        {
                            currentIndex--;
                            node = currentList.GetNodeAt(currentIndex);
                        }
                        else
                        {
                            node = previous;
                        }
                    }
                    else
                    {
                        node = previous;
                    }
                }
                else
                {
                    if (currentIndex > 0)
                    {
                        currentIndex--;
                        node = currentList.GetNodeAt(currentIndex);
                    }
                    else
                    {
                        node = node.get_Parent();
                        currentIndex = -1;
                        currentList = null;
                    }
                }
            }
            return retStr;
        }
        /// <summary>
        /// Busca la primera información de fuente LayerD que encuentre empezando
        /// por el nodo "node" y subiendo en el árbol hasta encontrar la info
        /// de origen de fuente, si no encuentra la info devuelve una cadena vacia.
        /// 
        /// Devuelve una cadena completa con numeros de linea y sin o con el fuente con el formato:
        /// "lnInicio,lnFin,srcFileName", "lnInicio,lnFin"
        /// ó
        /// "lnInicio,clInicio,lnFin,clFin,srcFileName", "lnInicio,clInicio,lnFin,clFin"
        /// donde "ln" por "line" y "cl" por columna.
        /// 
        /// Asume que el formato de los "ldsrc" en los nodos es correcto.
        /// </summary>
        public static string GetFirstLayerDSourceData(XplNode node)
        {
            string retStr = String.Empty;
            //string lineNoInfo = String.Empty;
            while (node != null)
            {
                //MethodInfo method = node.GetType().GetMethod("get_ldsrc");
                //if (method != null)
                //{
                    retStr = node.get_ldsrc();
                    if (retStr != String.Empty) break;
                //}
                node = node.get_Parent();
            }
            return retStr;
        }
        /// <summary>
        /// Crea un XplType a partir de una cadena de tipos con el formato:
        /// [Tipos Derivados][Tipo Base]
        /// 
        /// Usando "*_" para punteros, "^_" para referencias donde "_" puede
        /// ser "v", "c", "w" para modificadores volatile, const y ambos
        /// respectivamente, finalmente "[]" para matrices,
        /// y el resto para el nombre de tipo base.
        /// </summary>
        public static XplType MakeTypeFromString(string typeString)
        {
            if (typeString == null || typeString == String.Empty) return null;
            XplType retType = new XplType();
            retType.set_typeStr(typeString);
            if (typeString[0] == '*')
            {
                retType.set_ispointer(true);
                XplPointerinfo pi = new XplPointerinfo();
                switch(typeString[1])
                {
                    case 'v':
                        pi.set_volatile(true);
                        break;
                    case 'c':
                        pi.set_const(true);
                        break;
                    case 'w':
                        pi.set_volatile(true);
                        pi.set_const(true);
                        break;
                    case '_':
                    default:
                        break;
                }
                retType.set_pi(pi);
                retType.set_dt(MakeTypeFromString(typeString.Substring(2)));
            }
            else if (typeString[0] == '^')
            {
                retType.set_ispointer(true);
                XplPointerinfo pi = new XplPointerinfo();
                pi.set_ref(true);
                switch (typeString[1])
                {
                    case 'v':
                        pi.set_volatile(true);
                        break;
                    case 'c':
                        pi.set_const(true);
                        break;
                    case 'w':
                        pi.set_volatile(true);
                        pi.set_const(true);
                        break;
                    case '_':
                    default:
                        break;
                }
                retType.set_pi(pi);
                retType.set_dt(MakeTypeFromString(typeString.Substring(2)));
            }
            else if (typeString[0] == '[')
            {
                retType.set_isarray(true);
                retType.set_dt(MakeTypeFromString(typeString.Substring(2)));
            }
            else
            {
                if (typeString.EndsWith("_LIT$", StringComparison.InvariantCulture)) typeString = typeString.Substring(0, typeString.LastIndexOf("_LIT$", StringComparison.InvariantCulture)) + "$";
                retType.set_typename(typeString);
            }
            return retType;
        }
        /// <summary>
        /// Arma una expresion ZOE de nombre simple de la forma:
        ///     <e><n>nombreSimple</n></e>
        /// </summary>
        public static XplExpression MakeSimpleNameExpression(string simpleName)
        {
            XplNode nexp = new XplNode("n", simpleName);
            XplExpression exp = new XplExpression(nexp);
            exp.set_ElementName("e");
            return exp;
        }
        /// <summary>
        /// Escribe el nodo a un string.
        /// </summary>
        public static string WriteToString(XplNode node)
        {
            StringBuilder sb = new StringBuilder();
            TextWriter tw=new StringWriter(sb,CultureInfo.InvariantCulture);
            XplWriter writer = new XplWriter(tw);
            if (node.Write(writer))
            {
                return sb.ToString();
            }
            return String.Empty;
        }
        /// <summary>
        /// Writes the node to an indented XML string.
        /// </summary>
        public static string WriteToIndentedString(XplNode node)
        {
            StringBuilder sb = new StringBuilder();
            TextWriter tw = new StringWriter(sb,CultureInfo.InvariantCulture);
            XplWriter writer = new XplWriter(tw);
            writer.Formatting = Formatting.Indented;
            if (node.Write(writer))
            {
                return sb.ToString();
            }
            return String.Empty;
        }
        /// <summary>
        /// Lee node desde la cadena fromString creada
        /// con la función WriteToString.
        /// Requiere que el node posea memoria asignada del tipo adecuado al que vamos a leer,
        /// por ejemplo: ReadFromString("<n>id</n>", node) "node" debe ser inicializado con
        /// "new XplNode()".
        /// </summary>
        public static bool ReadFromString(string fromString, XplNode node)
        {
            try
            {
                TextReader tw = new StringReader(fromString);
                XplReader reader = new XplReader(tw);
                reader.Read();
                node.Read(reader);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static XplNode InternalWritecodeImpl(string wcstr, object[] args)
        {
            return InternalWritecodeImpl(wcstr, args, null);
        }

        /// <summary>
        /// returns a simple name from qualified one. for example a.b.c returns c.
        /// If the name is not qualified returns the same name
        /// </summary>
        /// <param name="fullName">A qualified fullname or a simple name</param>
        /// <returns>most external simple name like c in a.b.c or d in d</returns>
        [Obsolete]
        public static string GetSimpleNameFromQualified(string fullName)
        {
            return TypeString.GetSimpleNameFromQualified(fullName);
        }

        /// <summary>
        /// Internal implementation of writecode expression from Zoe language.
        /// 
        /// DO NOT MODIFY!!!
        /// 
        /// TODO : extract this to a class, method to long!!
        /// </summary>
        public static XplNode InternalWritecodeImpl(string wcstr, object[] args, XplNode contextNode)
        {

            XplWriteCodeBody wcnode = new XplWriteCodeBody();
            ZoeHelper.ReadFromString(wcstr, wcnode);
            XplNode template = wcnode.get_Content();

            ///Por ahora no hago todo igual siempre sin importar
            ///q tipo de bloque argumento contenga el writecode
            switch (template.get_ElementName())
            {
                case "bk":              //XplFunctionBody
                    break;
                case "progunit":        //XplDocumentBody
                    break;
                case "namespace":       //XplNamespace
                    template.set_ElementName("Namespace");
                    break;
                case "classmembers":    //XplClassMembersList
                    break;
                case "class":           //XplClass
                    template.set_ElementName("Class");
                    break;
                case "e":               //XplExpression
                    break;
            }

            XplNodeList ilefts = null;
            if (args.Length == 0)
            {
                ilefts = _FindExpression("ileft", template);
                //ilefts = template.FindNodes("/n(ileft)");
                if (ilefts.GetLength() == 0)
                {
                    return template;
                }
            }
            else
            {
                //Los objetos validos en los argumentos son:
                //- XplExpression
                //- IName
                //- XplType
                //- XplFunctionBody
                //- Tipos Nativos: enteros, flotantes, cadena y caracter
                //1º)Calculo las expresiones, inames, tipos y bloques a reemplazar.
                ArrayList expressions = new ArrayList(),
                    inames = new ArrayList(),
                    types = new ArrayList(),
                    blocks = new ArrayList(),
                    natives = new ArrayList();

                for (int n = 0; n < args.Length; n += 2)
                {
                    object value = args[n + 1];
                    if (value is XplExpression)
                    {
                        expressions.Add(args[n]);
                        expressions.Add(value);
                    }
                    else if (value is XplIName)
                    {
                        inames.Add(args[n]);
                        inames.Add(value);
                    }
                    else if (value is XplType)
                    {
                        types.Add(args[n]);
                        types.Add(value);
                    }
                    else if (value is XplFunctionBody)
                    {
                        blocks.Add(args[n]);
                        blocks.Add(value);
                    }
                    else if (
                       value is short ||
                       value is int ||
                       value is long ||
                       value is ushort ||
                       value is uint ||
                       value is ulong ||
                       value is float ||
                       value is double ||
                       value is char ||
                       value is string ||
                       value is bool
                        )
                    {
                        natives.Add(args[n]);
                        natives.Add(value);
                    }
                }

                XplNodeList[] matchedExpressions = new XplNodeList[expressions.Count / 2];
                XplNodeList[] matchedINames = new XplNodeList[inames.Count / 2];
                XplNodeList[] matchedTypes = new XplNodeList[types.Count / 2];
                XplNodeList[] matchedBlocks = new XplNodeList[blocks.Count / 2];
                XplNodeList[] matchedNatives = new XplNodeList[natives.Count / 2];

                //1º)Busco todas las coincidencias
                _InternalWritecodeImplFindMatches(template, expressions, inames, types, blocks, natives, matchedExpressions, matchedINames, matchedTypes, matchedBlocks, matchedNatives);

                //2º)Ahora reemplazo todo junto
                _InternalWritecodeImplReplaceMatches(expressions, inames, types, blocks, natives, matchedExpressions, matchedINames, matchedTypes, matchedBlocks, matchedNatives);
            }

            // replace ileft
            _InternalWritecodeImplReplaceIleft(contextNode, template, ilefts);

            return template;
        }

        private static void _InternalWritecodeImplReplaceMatches(ArrayList expressions, ArrayList inames, ArrayList types, ArrayList blocks, ArrayList natives, XplNodeList[] matchedExpressions, XplNodeList[] matchedINames, XplNodeList[] matchedTypes, XplNodeList[] matchedBlocks, XplNodeList[] matchedNatives)
        {
            //Expressions
            for (int n = 0; n < expressions.Count / 2; n++)
            {
                if (matchedExpressions[n] != null)
                    foreach (XplNode match in matchedExpressions[n])
                        match.set_Content(
                            ((XplNode)expressions[n * 2 + 1]).get_Content().Clone()
                            );
            }
            //INames
            for (int n = 0; n < inames.Count / 2; n++)
            {
                if (matchedINames[n] != null)
                    foreach (XplNode match in matchedINames[n])
                    {
                        string inameString = ((XplIName)inames[n * 2 + 1]).FullIdentifier;
                        string simpleName = GetSimpleNameFromQualified(inameString);
                        switch (match.get_TypeName())
                        {
                            case CodeDOMTypes.XplExpression:
                                match.get_Content().set_Value(
                                    match.get_Content().get_StringValue().Replace(
                                    (string)inames[n * 2], inameString)
                                );
                                //match.get_Content().set_Value(inameString);
                                break;
                            case CodeDOMTypes.XplDeclarator:
                                ((XplDeclarator)match).set_name(simpleName);
                                break;
                            case CodeDOMTypes.XplParameter:
                                ((XplParameter)match).set_name(simpleName);
                                break;
                            case CodeDOMTypes.XplField:
                                ((XplField)match).set_name(simpleName);
                                break;
                            case CodeDOMTypes.XplProperty:
                                ((XplProperty)match).set_name(simpleName);
                                break;
                            case CodeDOMTypes.XplClass:
                                ((XplClass)match).set_name(simpleName);
                                break;
                            case CodeDOMTypes.XplFunction:
                                ((XplFunction)match).set_name(inameString);
                                break;
                            case CodeDOMTypes.XplNamespace:
                                ((XplNamespace)match).set_name(inameString);
                                break;
                            case CodeDOMTypes.XplType:
                                ((XplType)match).set_typename(inameString);
                                break;
                            case CodeDOMTypes.XplInherit:
                                ((XplInherit)match).get_type().set_typename(inameString);
                                break;
                        }
                    }
            }
            //Types
            for (int n = 0; n < types.Count / 2; n++)
            {
                if (matchedTypes[n] != null)
                {
                    XplType typeArgument = (XplType)types[n * 2 + 1];
                    foreach (XplType match in matchedTypes[n])
                    {
                        if (match.get_Parent() is XplType)
                        {
                            ((XplType)match.get_Parent()).set_dt((XplType)typeArgument.Clone());
                        }
                        else
                        {
                            #region Copio el tipo Argumento en el destino
                            if (typeArgument.get_ae() != null)
                                match.set_ae((XplExpression)typeArgument.get_ae().Clone());
                            else
                                match.set_ae(null);
                            match.set_const(typeArgument.get_const());
                            match.set_customTypeCheck(typeArgument.get_customTypeCheck());
                            if (typeArgument.get_dt() != null)
                                match.set_dt((XplType)typeArgument.get_dt().Clone());
                            else
                                match.set_dt(null);
                            match.set_exec(typeArgument.get_exec());
                            match.set_ftype(typeArgument.get_ftype());
                            match.set_isarray(typeArgument.get_isarray());
                            match.set_ispointer(typeArgument.get_ispointer());
                            if (typeArgument.get_pi() != null)
                                match.set_pi((XplPointerinfo)typeArgument.get_pi().Clone());
                            else
                                match.set_pi(null);
                            match.set_pointertype(typeArgument.get_pointertype());
                            match.set_typename(typeArgument.get_typename());
                            match.set_typeStr(typeArgument.get_typeStr());
                            match.set_volatile(typeArgument.get_volatile());
                            #endregion
                        }
                    }
                }
            }
            //Blocks
            //
            for (int n = 0; n < blocks.Count / 2; n++)
            {
                if (matchedBlocks[n] != null)
                    foreach (XplNode match in matchedBlocks[n])
                    {
                        if (match.get_Parent() is XplFunctionBody)
                        {
                            XplFunctionBody parent = (XplFunctionBody)match.get_Parent();
                            XplFunctionBody toInsert = (XplFunctionBody)((XplNode)blocks[n * 2 + 1]).Clone();
                            toInsert.set_ElementName("bk");
                            if (parent.Children().GetLength() > 1)
                            {
                                parent.Children().InsertBefore(toInsert, match);
                                parent.Children().Remove(match);
                            }
                            else
                            {
                                //Si el bloque en el cual inserto sólo existe una instrucción copio la lista
                                parent.Children().Clear();
                                parent.Children().InsertAtEnd(toInsert.Children());
                            }
                        }
                    }
            }
            //Natives
            for (int n = 0; n < natives.Count / 2; n++)
            {
                if (matchedNatives[n] != null)
                    foreach (XplNode match in matchedNatives[n])
                    {
                        XplLiteral literal = XplExpression.new_lit();
                        //PENDIENTE : Aqui la conversión del valor a string debe realizarse correctamente
                        //para el caso de flotantes tambien, esto sólo funcionara para enteros...
                        object value = natives[n * 2 + 1];
                        string stringValue = null;

                        if (value is short)
                        {
                            stringValue = ((short)value).ToString(CultureInfo.InvariantCulture);
                            literal.set_type(XplLiteraltype_enum.INTEGER);
                        }
                        else if (value is int)
                        {
                            stringValue = ((int)value).ToString(CultureInfo.InvariantCulture);
                            literal.set_type(XplLiteraltype_enum.INTEGER);
                        }
                        else if (value is long)
                        {
                            stringValue = ((long)value).ToString(CultureInfo.InvariantCulture);
                            literal.set_type(XplLiteraltype_enum.INTEGER);
                        }
                        else if (value is ushort)
                        {
                            stringValue = ((ushort)value).ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
                            literal.set_type(XplLiteraltype_enum.INTEGER);
                        }
                        else if (value is uint)
                        {
                            stringValue = ((uint)value).ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
                            literal.set_type(XplLiteraltype_enum.INTEGER);
                        }
                        else if (value is ulong)
                        {
                            stringValue = ((ulong)value).ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
                            literal.set_type(XplLiteraltype_enum.INTEGER);
                        }
                        else if (value is float)
                        {
                            stringValue = ((float)value).ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
                            literal.set_type(XplLiteraltype_enum.FLOAT);
                        }
                        else if (value is double)
                        {
                            stringValue = ((double)value).ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
                            literal.set_type(XplLiteraltype_enum.DOUBLE);
                        }
                        else if (value is char)
                        {
                            stringValue = value.ToString();
                            literal.set_type(XplLiteraltype_enum.CHAR);
                        }
                        else if (value is string)
                        {
                            stringValue = (string)value;
                            literal.set_type(XplLiteraltype_enum.STRING);
                        }
                        else if (value is bool)
                        {
                            stringValue = ((bool)value) ? "true" : "false";
                            literal.set_type(XplLiteraltype_enum.BOOL);
                        }

                        literal.set_str(stringValue);
                        match.set_Content(literal);
                    }
            }
        }

        private static void _InternalWritecodeImplFindMatches(XplNode template, ArrayList expressions, ArrayList inames, ArrayList types, ArrayList blocks, ArrayList natives, XplNodeList[] matchedExpressions, XplNodeList[] matchedINames, XplNodeList[] matchedTypes, XplNodeList[] matchedBlocks, XplNodeList[] matchedNatives)
        {
            //Expresiones
            if (expressions.Count > 0)
                for (int n = 0; n < matchedExpressions.Length; n++)
                {
                    //matchedExpressions[n] = template.FindNodes("/@XplExpression/n(" + expressions[n * 2] + ")");
                    matchedExpressions[n] = _FindExpression((string)expressions[n * 2], template);
                }
            //INames
            //Para los inames debo buscar:
            //- XplNode n=iname
            //- XplDeclarator name=iname
            //- XplParameter name=iname
            //- XplField name=iname
            //- XplProperty name=iname
            //- XplClass name=iname
            //- XplFunction name=iname
            //- XplNamespace name=iname
            //- XplInherit name=iname -- Esto no deberia ser con Type?
            //- XplImplement name=iname -- Esto no deberia ser con Type?
            //- XplDocumentation
            if (inames.Count > 0)
                for (int n = 0; n < matchedINames.Length; n++)
                {
                    //PENDIENTE : optimizar esto es una pasta, cero performance :-)
                    string inameName = (string)inames[n * 2];
                    matchedINames[n] = _FindINames(inameName, template, ((XplIName)inames[n * 2 + 1]).Identifier);
                }

            //Types
            //No deberia tambien buscar?
            //- XplInherit 
            //- XplImplement 
            if (types.Count > 0)
                for (int n = 0; n < matchedTypes.Length; n++)
                {
                    //matchedTypes[n] = template.FindNodes("/@XplType[typename='" + types[n * 2] + "']");
                    XplType _type = (XplType)types[n * 2 + 1];
                    matchedTypes[n] = _FindTypes((string)types[n * 2], template, String.IsNullOrEmpty(_type.get_typeStr()) ? _type.get_typename() : _type.get_typeStr());
                }
            //Blocks
            if (blocks.Count > 0)
                for (int n = 0; n < matchedBlocks.Length; n++)
                {
                    //matchedBlocks[n] = template.FindNodes("/@XplExpression/n(" + blocks[n * 2] + ")");
                    matchedBlocks[n] = _FindBlocks((string)blocks[n * 2], template);
                }
            //Natives
            if (natives.Count > 0)
                for (int n = 0; n < matchedNatives.Length; n++)
                {
                    //matchedNatives[n] = template.FindNodes("/@XplExpression/n(" + natives[n * 2] + ")");
                    matchedNatives[n] = _FindNativeTypes((string)natives[n * 2], template);
                }
        }

        private static void _InternalWritecodeImplReplaceIleft(XplNode contextNode, XplNode template, XplNodeList ilefts)
        {
            // 3º)Reemplazo el nombre especial "ileft"
            if (contextNode != null)
            {
                CodeDOMTypes contextType = contextNode.get_TypeName();
                if (contextType == CodeDOMTypes.XplFunctioncall ||
                    contextType == CodeDOMTypes.XplAssing ||
                    contextType == CodeDOMTypes.XplBinaryoperator)
                {
                    if (ilefts == null) ilefts = _FindExpression("ileft", template);

                    if (ilefts.GetLength() > 0)
                    {
                        XplNode reemplazo = null;
                        if (contextType == CodeDOMTypes.XplFunctioncall)
                        {
                            reemplazo = ((XplFunctioncall)contextNode).get_l().get_Content();
                        }
                        else if (contextType == CodeDOMTypes.XplBinaryoperator)
                        {
                            reemplazo = ((XplBinaryoperator)contextNode).get_l().get_Content();
                        }
                        else if (contextType == CodeDOMTypes.XplAssing)
                        {
                            reemplazo = ((XplAssing)contextNode).get_l().get_Content();
                        }

                        foreach (XplNode ileft in ilefts)
                        {
                            if (reemplazo.get_TypeName() == CodeDOMTypes.XplBinaryoperator)
                            {
                                var binop = ((XplBinaryoperator)reemplazo).get_op();
                                if (binop == XplBinaryoperators_enum.M ||
                                    binop == XplBinaryoperators_enum.PM ||
                                    binop == XplBinaryoperators_enum.PMP ||
                                    binop == XplBinaryoperators_enum.RM)
                                {
                                    XplNode temp = ((XplBinaryoperator)reemplazo).get_l();
                                    //ileft.get_Parent().set_Content(reemplazo.get_Content());
                                    ileft.set_Content(temp.get_Content().Clone());
                                    if (ileft.get_Parent().IsA(CodeDOMTypes.XplBinaryoperator))
                                    {
                                        ((XplBinaryoperator)ileft.get_Parent()).set_op(XplBinaryoperators_enum.RM);
                                    }
                                }
                            }
                            else
                            {
                                if (contextType == CodeDOMTypes.XplFunctioncall || contextType == CodeDOMTypes.XplNode)
                                    // Context node isn't a.b() form, but b() what is the same that this.b()
                                    // assume that content of ileft it's a XplNode
                                    ileft.get_Content().set_Value("this");
                                else
                                    ileft.set_Content(reemplazo.Clone());
                            }
                        }
                    }
                }
            }
        }

        private static XplNodeList _FindINames(string inameName, XplNode template, string currentINameValue)
        {
            return _FindINames(inameName, template, new XplNodeList(), currentINameValue);
        }
        private static XplNodeList _FindINames(string searchFor, XplNode currentNode, XplNodeList list, string currentINameValue)
        {
            /*
            matchedINames[n] = template.FindNodes("/@XplExpression/n(" + inameName + ")");
                template.FindNodes("/@XplDeclarator[name='" + inameName + "']"),
                template.FindNodes("/@XplParameter[name='" + inameName + "']"),
                template.FindNodes("/@XplField[name='" + inameName + "']"),
                template.FindNodes("/@XplProperty[name='" + inameName + "']"),
                template.FindNodes("/@XplClass[name='" + inameName + "']"),
                template.FindNodes("/@XplFunction[name='" + inameName + "']"),
                template.FindNodes("/@XplNamespace[name='" + inameName + "']"),
                template.FindNodes("/@XplType[typename='" + inameName + "']"),
             */
            if (currentNode == null) return list;
            XplNode content = null;
            switch (currentNode.get_TypeName())
            {
                case CodeDOMTypes.XplExpression:
                    content = currentNode.get_Content();
                    if (content != null && content.get_ElementName() == "n")
                    {
                        string contentStr = content.get_StringValue();
                        //if (contentStr == searchFor)
                        //{
                        //    list.InsertAtEnd(currentNode);
                        //}
                        //break;
                        //int index = contentStr.IndexOf(searchFor + ".");
                        if (contentStr == searchFor) list.InsertAtEnd(currentNode);
                        else if (contentStr.Contains(searchFor + ".")) list.InsertAtEnd(currentNode);
                        else if (contentStr.Contains(searchFor + ":")) list.InsertAtEnd(currentNode);
                        else if (contentStr.EndsWith(searchFor, StringComparison.InvariantCulture)) list.InsertAtEnd(currentNode);
                        
                        /*if (index >= 0)
                        {
                            index = index + searchFor.Length + 1;
                            if (index >= contentStr.Length)
                            {
                                list.InsertAtEnd(currentNode);
                            }
                            else if (contentStr[index] == '.' || contentStr[index] == ':')
                            {
                                list.InsertAtEnd(currentNode);
                            }
                        }*/
                    }
                    break;
                case CodeDOMTypes.XplDeclarator:
                    if (((XplDeclarator)currentNode).get_name() == searchFor)
                    {
                        list.InsertAtEnd(currentNode);
                        if (currentNode.get_doc().Contains(searchFor + "$"))
                            currentNode.set_doc(currentNode.get_doc().Replace(searchFor + "$", currentINameValue));
                        //return list;
                    }
                    break;
                case CodeDOMTypes.XplParameter:
                    if (((XplParameter)currentNode).get_name() == searchFor)
                    {
                        list.InsertAtEnd(currentNode);
                        //return list;
                    }
                    break;
                case CodeDOMTypes.XplField:
                    if (((XplField)currentNode).get_name() == searchFor)
                    {
                        list.InsertAtEnd(currentNode);
                        if (currentNode.get_doc().Contains(searchFor + "$"))
                            currentNode.set_doc(currentNode.get_doc().Replace(searchFor + "$", currentINameValue));
                        //return list;
                    }
                    break;
                case CodeDOMTypes.XplProperty:
                    if (((XplProperty)currentNode).get_name() == searchFor)
                    {
                        list.InsertAtEnd(currentNode);
                        if (currentNode.get_doc().Contains(searchFor + "$"))
                            currentNode.set_doc(currentNode.get_doc().Replace(searchFor + "$", currentINameValue));
                        //return list;
                    }
                    break;
                case CodeDOMTypes.XplClass:
                    if (((XplClass)currentNode).get_name() == searchFor)
                    {
                        list.InsertAtEnd(currentNode);
                        if (currentNode.get_doc().Contains(searchFor + "$"))
                            currentNode.set_doc(currentNode.get_doc().Replace(searchFor + "$", currentINameValue));
                        //return list;
                    }
                    break;
                case CodeDOMTypes.XplFunction:
                    if (((XplFunction)currentNode).get_name() == searchFor)
                    {
                        list.InsertAtEnd(currentNode);
                        if (currentNode.get_doc().Contains(searchFor + "$"))
                            currentNode.set_doc(currentNode.get_doc().Replace(searchFor + "$", currentINameValue));
                        //return list;
                    }
                    break;
                case CodeDOMTypes.XplInherit:
                    if (((XplInherit)currentNode).get_type().get_typename() == searchFor)
                    {
                        list.InsertAtEnd(currentNode);
                        //return list;
                    }
                    break;
                case CodeDOMTypes.XplNamespace:
                    if (((XplNamespace)currentNode).get_name() == searchFor)
                    {
                        list.InsertAtEnd(currentNode);
                        if (currentNode.get_doc().Contains(searchFor + "$"))
                            currentNode.set_doc(currentNode.get_doc().Replace(searchFor + "$", currentINameValue));
                        //return list;
                    }
                    break;
                case CodeDOMTypes.XplType:
                    if (((XplType)currentNode).get_typename() == searchFor)
                    {
                        list.InsertAtEnd(currentNode);
                        //return list;
                    }
                    break;
                case CodeDOMTypes.XplDocumentation:
                    XplDocumentation documentation = (XplDocumentation)currentNode;
                    string docStr = null, searchForDoc = searchFor + "$";
                    //title
                    if (documentation.get_title() != null)
                    {
                        docStr = documentation.get_title().get_StringValue();
                        if (docStr.Contains(searchForDoc))
                        {
                            documentation.get_title().set_Value(docStr.Replace(searchForDoc, currentINameValue));
                        }
                    }
                    //summary
                    if (documentation.get_summary()!=null)
                    {
                        docStr = documentation.get_summary().get_StringValue();
                        if (docStr.Contains(searchForDoc))
                        {
                            documentation.get_summary().set_Value(docStr.Replace(searchForDoc, currentINameValue));
                        }
                    }
                    //short
                    docStr = documentation.get_short();
                    if (docStr.Contains(searchForDoc))
                    {
                        documentation.set_short(docStr.Replace(searchForDoc, currentINameValue));
                    }
                    // PENDIENTE : completar cambios en XplDocumentation!!
                    break;
                default:
                    break;
            }
            XplNodeList children = currentNode.ChildNodes();
            if (children.GetLength() > 0)
                foreach (XplNode child in children)
                    if (child != null)
                        _FindINames(searchFor, child, list, currentINameValue);
            return list;
        }

        private static XplNodeList _FindNativeTypes(string searchFor, XplNode currentNode)
        {
            return _FindExpression(searchFor, currentNode, new XplNodeList());
        }

        private static XplNodeList _FindBlocks(string searchFor, XplNode currentNode)
        {
            return _FindExpression(searchFor, currentNode, new XplNodeList());
        }

        private static XplNodeList _FindTypes(string searchFor, XplNode currentNode, string currentTypeValue)
        {
            return _FindTypes(searchFor, currentNode, new XplNodeList(), currentTypeValue);
        }
        private static XplNodeList _FindTypes(string searchFor, XplNode currentNode, XplNodeList list, string currentTypeValue)
        {
            if (currentNode == null) return list;
            if (currentNode.get_TypeName() == CodeDOMTypes.XplType && ((XplType)currentNode).get_typename() == searchFor)
            {                
                list.InsertAtEnd(currentNode);
                //return list;
            }
            else if (currentNode.get_TypeName() == CodeDOMTypes.XplDocumentation)
            {
                //case CodeDOMTypes.XplDocumentation:
                XplDocumentation documentation = (XplDocumentation)currentNode;
                string docStr = null, searchForDoc = searchFor + "$";
                //title
                if (documentation.get_title() != null)
                {
                    docStr = documentation.get_title().get_StringValue();
                    if (docStr.Contains(searchForDoc))
                    {
                        documentation.get_title().set_Value(docStr.Replace(searchForDoc, currentTypeValue));
                    }
                }
                //summary
                if (documentation.get_summary() != null)
                {
                    docStr = documentation.get_summary().get_StringValue();
                    if (docStr.Contains(searchForDoc))
                    {
                        documentation.get_summary().set_Value(docStr.Replace(searchForDoc, currentTypeValue));
                    }
                }
                //short
                docStr = documentation.get_short();
                if (docStr.Contains(searchForDoc))
                {
                    documentation.set_short(docStr.Replace(searchForDoc, currentTypeValue));
                }
                // PENDIENTE : completar cambios en XplDocumentation!!
                //break;
            }
            else
            {
                if (currentNode.get_TypeName() == CodeDOMTypes.XplClass)
                {
                    if (!String.IsNullOrEmpty(currentNode.get_doc()) && currentNode.get_doc().Contains(searchFor + "$"))
                        currentNode.set_doc(currentNode.get_doc().Replace(searchFor + "$", currentTypeValue));
                }
                XplNodeList children = currentNode.ChildNodes();
                if (children.GetLength() > 0)
                    foreach (XplNode child in children)
                        if (child != null)
                            _FindTypes(searchFor, child, list, currentTypeValue);
            }
            return list;
        }

        private static XplNodeList _FindExpression(string searchFor, XplNode currentNode)
        {
            return _FindExpression(searchFor, currentNode, new XplNodeList());
        }
        private static XplNodeList _FindExpression(string searchFor, XplNode currentNode, XplNodeList list)
        {
            if (currentNode == null) return list;
            XplNode content = null;
            if (currentNode.get_TypeName() == CodeDOMTypes.XplExpression)
            {
                content = currentNode.get_Content();
                if (content != null && content.get_ElementName() == "n")
                {
                    if (content.get_StringValue() == searchFor)
                    {
                        list.InsertAtEnd(currentNode);
                        return list;
                    }
                }
            }
            XplNodeList children = currentNode.ChildNodes();
            if (children.GetLength() > 0)
                foreach (XplNode child in children)
                    if(child!=null)
                        _FindExpression(searchFor, child, list);
            return list;
        }
        //Fin InternalWriteCode2
    }

	/*
	Clase que representa un IName
	*/
	public class XplIName{
		string p_identifier;
		XplType p_type;
        /// <summary>
        /// Crea un iname con un nombre de identificador aleatorio (unico basado en la fecha y hora)
        /// y de tipo void
        /// </summary>
        public XplIName()
        {
            p_identifier = MakeUniqueIdentifier();
            p_type = ZoeHelper.MakeTypeFromString("$VOID$");
        }
        /// <summary>
        /// Crea un iname con un nombre de identificador aleatorio (unico basado en la fecha y hora)
        /// y con el tipo recibido como parametro
        /// </summary>
        public XplIName(XplType ptype)
        {
            p_identifier = MakeUniqueIdentifier();
            p_type = ptype;
        }

        /// <summary>
        /// Crea una cadena con un nombre de identificador aleatorio construido a 
        /// partir de la fecha y hora actual, esta implementacion puede cambiar con
        /// el tiempo, por tanto no suponer resultados.
        /// 
        /// Existe una posibilidad de duplicar identificadores si se cambia la fecha u hora 
        /// durante la compilación :-).
        /// </summary>
        public static string MakeUniqueIdentifier()
        {
            DateTime now = DateTime.Now;
            return "__iuicdom_" + Path.GetFileNameWithoutExtension( Path.GetRandomFileName() ) + now.Ticks.ToString(CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Crea un iname con un nombre de identificador especificado
        /// y de tipo void
        /// </summary>
        public XplIName(string identifier)
        {
            p_identifier = identifier;
            p_type = ZoeHelper.MakeTypeFromString("$VOID$");
        }
        /// <summary>
        /// Crea un iname con un nombre de identificador especificado
        /// y con el tipo recibido como parametro
        /// </summary>
        public XplIName(string identifier, XplType ptype)
        {
			p_identifier=identifier;
			p_type=ptype;
		}
        /// <summary>
        /// Crea un iname con un nombre de identificador especificado
        /// y con el tipo recibido como string, el tipo se construira
        /// con la funcion utilitaria en CDOM_Utils
        /// </summary>
        public XplIName(string identifier, string typeStr)
        {
            p_identifier = identifier;
            p_type = ZoeHelper.MakeTypeFromString(typeStr);
        }
        /// <summary>
        /// Gets the simple identifier of the XplIName.
        /// </summary>
        /// <value>The identifier.</value>
        public string Identifier
        {
			get
            {
                if (p_identifier == null) return null;
                return ZoeHelper.GetSimpleNameFromQualified(p_identifier);
            }
		}
        /// <summary>
        /// Gets or Sets full qualified name for iname
        /// </summary>
        public string FullIdentifier
        {
            get
            {
                return p_identifier;
            }
            set
            {
                p_identifier = value;
            }
        }
        /// <summary>
        /// Gets or sets the type of the XplIName.
        /// </summary>
        /// <value>The type.</value>
		public XplType Type{
			get{return p_type;}
			set{p_type=value;}
		}
        /// <summary>
        /// Create a new XplIName that have the same type that identifier and adds the
        /// identifierPart to identifier
        /// </summary>
        /// <param name="identifierPart">The string to add</param>
        /// <param name="identifier">The XplIName to add</param>
        /// <returns>A new XplIName</returns>
        public static XplIName operator +(string identifierPart, XplIName identifier)
        {
            return new XplIName(identifierPart + identifier.Identifier, identifier.Type);
        }
        /// <summary>
        /// Create a new XplIName that have the same type that identifier and adds the
        /// identifierPart to identifier
        /// </summary>
        /// <param name="identifier">The XplIName to add</param>
        /// <param name="identifierPart">The string to add</param>
        /// <returns>A new XplIName</returns>
        public static XplIName operator +(XplIName identifier, string identifierPart)
        {
            return new XplIName(identifier.Identifier + identifierPart, identifier.Type);
        }
    }
    
	public class CodeDOM_Exception:Exception{
		string p_source = String.Empty;
		public CodeDOM_Exception(string new_error, string new_source):base(new_error){
			this.p_source=new_source;
		}
		public CodeDOM_Exception(string new_error):base(new_error){
		}
		public void set_error(string new_error){
			;//No se puede
		}
		public void set_source(string new_source){
			this.p_source=new_source;
		}
		public string get_error(){
			return this.Message;
		}
		public string get_source(){
			return this.p_source;
		}
	}

	public class CodeDOM_NotImplementedException: CodeDOM_Exception{
		public CodeDOM_NotImplementedException(string source):base("Funcion no implementada en esta versión del CodeDOM de LayerD-Zoe.",source){
		}
	}

	public class XplWriter:System.Xml.XmlTextWriter{
		public XplWriter(string url):base(url,System.Text.Encoding.UTF8){}
		public XplWriter(string url, System.Text.Encoding enc):base(url,enc){}
        public XplWriter(Stream stream) : base(stream, System.Text.Encoding.UTF8) { }
        public XplWriter(TextWriter textWriter) : base(textWriter) { }
    }

	public class XplReader: System.Xml.XmlTextReader {
		public XplReader(string url):base(url){}
        public XplReader(Stream stream) : base(stream) { }
        public XplReader(TextReader textReader) : base(textReader) { }
	}

	public enum XplNodeType_enum{
		COMPLEX,
		STRING,
		INT,
		UNSIGNED,
		DATETIME,
		BOOL,
		EMPTY
	};

    public class XplBinaryWriter : BinaryWriter
    {
        public XplBinaryWriter(Stream w)
            : base(w)
        {
        }
    }
    public class XplBinaryReader : BinaryReader
    {
        public XplBinaryReader(Stream w)
            : base(w)
        {
        }
    }

    [Serializable]
	public class XplNode{

        static object _renderModule;
        static bool _renderModuleLoaded;

        //string p_elementName;
		string p_errorString;
		XplNodeType_enum p_nodeType;
		object p_value;
		XplNode p_parent;
        private int _elementName;
        private static Dictionary<int, string> _elementNames = new Dictionary<int, string>(100);

        const int BINARY_NODE_CODE = 1;

		public XplNode(){
			p_nodeType=XplNodeType_enum.COMPLEX;
		}
		public XplNode(string new_Name){
			p_nodeType=XplNodeType_enum.COMPLEX;
			set_ElementName(new_Name);
		}
		public XplNode(XplNodeType_enum new_nodeType){
			p_nodeType=new_nodeType;
		}
		public XplNode(string new_Name, string new_stringValue){
			set_ElementName(new_Name);
			p_value=new_stringValue;
			p_nodeType=XplNodeType_enum.STRING;
		}
		public XplNode(string new_Name, int new_intValue){
			set_ElementName(new_Name);
			p_value=new_intValue;
			p_nodeType=XplNodeType_enum.INT;
		}
		public XplNode(string new_Name, uint new_unsignedValue){
			set_ElementName(new_Name);
			p_value=new_unsignedValue;
			p_nodeType=XplNodeType_enum.UNSIGNED;
		}
		public XplNode(string new_Name, bool new_boolValue){
			set_ElementName(new_Name);
			p_value=new_boolValue;
			p_nodeType=XplNodeType_enum.BOOL;
		}
		public void set_Parent(XplNode new_Parent){
			p_parent=new_Parent;
		}
		public XplNode get_Parent(){
			return p_parent;
		}
		public void set_Value(string new_stringValue){
			if(p_nodeType==XplNodeType_enum.STRING){
				p_value=new_stringValue;
			}
		}
		public void set_Value(int new_value){
			if(p_nodeType==XplNodeType_enum.INT){
				p_value=new_value;
			}
		}
		/// <summary>
		/// Funcion para establecer valor generica, es obsoleta
		/// deberia chequear el tipo del objeto pasado. Usar
		/// con cuidado.
		/// </summary>
		public void set_Value(object new_value){
			p_value=new_value;
		}
		public string get_StringValue(){
			return (string)p_value;
		}
		public int get_IntValue(){
			return (int)p_value;
		}
		public uint get_UnsignedValue(){
			return (uint)p_value;
		}
		public bool get_BoolValue(){
			return (bool)p_value;
		}
		public DateTime get_DateTimeValue(){
			return (DateTime)p_value;
		}
        /// <summary>
        /// Set the XML element name for this node.
        /// </summary>
        public void set_ElementName(string new_Name)
        {
            if (new_Name == null) return;
            _elementName = new_Name.GetHashCode();
            if (_elementNames.ContainsKey(_elementName)) return;
            _elementNames.Add(_elementName, new_Name);
            return;
		}
        /// <summary>
        /// Obtiene el nombre del elemento XML del nodo.
        /// </summary>
        public string get_ElementName()
        {
            if (_elementName == 0) return null;
            return _elementNames[_elementName];
		}
		public string get_ErrorString(){
			return p_errorString;
		}
		public void set_ErrorString(string new_errorString){
			p_errorString=new_errorString;
		}
        /// <summary>
        /// Devuelve todos los nodos hijos sólo para elementos 
        /// que puedan contener una cantidad variable de nodos hijos.
        /// 
        /// De lo contrario de vuelve null;
        /// </summary>
        public virtual XplNodeList Children() { return null; }

        /// <summary>
        /// Updates current node source file information taking the information from argument node
        /// </summary>
        /// <param name="node">Node from which to take source file information</param>
        public void UpdateSourceInfoFrom(XplNode node)
        {
            this.set_ldsrc(ZoeHelper.GetFirstLayerDFullSourceData(node));
        }

        /// <summary>
        /// Gets full source information for current node
        /// </summary>
        public string FullSourceFileInfo
        {
            get
            {
                return ZoeHelper.GetFirstLayerDFullSourceData(this);
            }
        }

        /// <summary>
        /// Calculate and persist full source info into current node
        /// </summary>
        public void PersistFullSourceFileInfo()
        {
            this.set_ldsrc(ZoeHelper.GetFirstLayerDFullSourceData(this));
        }

        /// <summary>
        /// Devuelve una lista con todos los nodos hijos, si el 
        /// elemento no posee nodos hijos devuelve una lista vacia.
        /// </summary>
        public virtual XplNodeList ChildNodes() { return new XplNodeList(); }
        /// <summary>
        /// Devuelve el contenido de un elemento de tipo "choice".
        /// Si el elemento no es de tipo "choice" devuelve nulo.
        /// </summary>
        public virtual XplNode get_Content() { return null; }
        /// <summary>
        /// Establece el contenido de un elemento de tipo "choice".
        /// Si el elemento no es de tipo "choice" devuelve nulo.
        /// </summary>
        public virtual XplNode set_Content(XplNode p_content) { return null; }
        /// <summary>
        /// Devuelve una matriz con los nombres de todos los atributos del
        /// tipo de elemento.
        /// </summary>
        public virtual string[] Attributes()
        {
            return new string[0];
        }
        /// <summary>
        /// Devuelve el valor, convertido a string, del atributo
        /// de nombre "attributeName".
        /// 
        /// ¡¡Para convertir el valor del atributo a string se utiliza
        /// la función de conversion nativa del lenguaje!!
        /// </summary>
        public virtual string AttributeValue(string attributeName) { return null; }

        public virtual string set_doc(string new_doc) { return String.Empty; }
        public virtual string set_helpURL(string new_helpURL) { return String.Empty; }
        public virtual string set_ldsrc(string new_ldsrc) { return String.Empty; }
        public virtual bool set_iny(bool new_iny) { return false; }
        public virtual string set_inydata(string new_inydata) { return String.Empty; }
        public virtual string set_inyby(string new_inyby) { return String.Empty; }
        public virtual string set_lddata(string new_lddata) { return String.Empty; }

        public virtual string get_doc() { return String.Empty; }
        public virtual string get_helpURL() { return String.Empty; }
        public virtual string get_ldsrc() { return String.Empty; }
        public virtual bool get_iny() { return false; }
        public virtual string get_inydata() { return String.Empty; }
        public virtual string get_inyby() { return String.Empty; }
        public virtual string get_lddata() { return String.Empty; }
        /// <summary>
        /// Devuelve un string con el nombre de tipo del nodo.
        /// </summary>
		public virtual CodeDOMTypes get_TypeName(){
			return CodeDOMTypes.XplNode;
		}

        /// <summary>
        /// Returns if this node is the same type that provided argument.
        /// </summary>
        /// <param name="nodeType">CodeDOM type to compare with the type of this node</param>
        /// <returns>True if the type of the node is the same that provided argument.</returns>
        public bool IsA(CodeDOMTypes nodeType)
        {
            return this.get_TypeName() == nodeType;
        }

        /// <summary>
        /// Returns a user friendly typename
        /// </summary>
        /// <returns>Typename string</returns>
        public string get_ContentTypeNameString()
        {
            return get_ContentTypeName().ToString();
        }
        /// <summary>
        /// Devuelve un string con el nombre de tipo del contenido del nodo.
        /// Solo sirve para nodos simples XplNode, para nodos complejos 
        /// devuelve el nombre del tipo del nodo.
        /// </summary>
		public virtual CodeDOMTypes get_ContentTypeName(){
			if(p_nodeType==XplNodeType_enum.COMPLEX)return get_TypeName();
			switch(p_nodeType){
				case XplNodeType_enum.STRING:
					return CodeDOMTypes.String;
				case XplNodeType_enum.INT:
					return CodeDOMTypes.Integer;
				case XplNodeType_enum.UNSIGNED:
					return CodeDOMTypes.Unsigned;
				case XplNodeType_enum.DATETIME:
					return CodeDOMTypes.DateTime;
				case XplNodeType_enum.BOOL:
					return CodeDOMTypes.Boolean;
				case XplNodeType_enum.EMPTY:
					return CodeDOMTypes.XplNode;
				default:
					return CodeDOMTypes.Empty;
			};
		}
        /// <summary>
        /// Deep copy of the node
        /// </summary>
		public virtual XplNode Clone(){
			return (XplNode)base.MemberwiseClone();
		}
        /// <summary>
        /// Escribe el nodo y su contenido usando "writer".
        /// </summary>
		public virtual bool Write(XplWriter writer){
			switch(p_nodeType){
				case XplNodeType_enum.STRING:
					writer.WriteElementString(_elementNames[_elementName],ZoeHelper.Att_ToString((string)p_value));break;
				case XplNodeType_enum.INT:
					writer.WriteElementString(_elementNames[_elementName],ZoeHelper.Att_ToString((int)p_value));break;
				case XplNodeType_enum.UNSIGNED:
					writer.WriteElementString(_elementNames[_elementName],ZoeHelper.Att_ToString((uint)p_value));break;
				case XplNodeType_enum.DATETIME:
					writer.WriteElementString(_elementNames[_elementName],ZoeHelper.Att_ToString((DateTime)p_value));break;
				case XplNodeType_enum.BOOL:
					writer.WriteElementString(_elementNames[_elementName],ZoeHelper.Att_ToString((bool)p_value));break;
				case XplNodeType_enum.EMPTY:
					writer.WriteElementString(_elementNames[_elementName],String.Empty);break;
				default:
					throw new CodeDOM_Exception("Error grabando un nodo basico");
			};
			//Cierro el elemento
			//writer.WriteEndElement();
			return true;
		}
        public virtual bool BinaryWrite(XplBinaryWriter writer)
        {
            writer.Write(BINARY_NODE_CODE);
            writer.Write(_elementNames[_elementName]);
            writer.Write((int)p_nodeType);
            switch (p_nodeType)
            {
                case XplNodeType_enum.STRING:
                    writer.Write((string)p_value); break;
                case XplNodeType_enum.INT:
                    writer.Write((int)p_value); break;
                case XplNodeType_enum.UNSIGNED:
                    writer.Write((uint)p_value); break;
                case XplNodeType_enum.DATETIME:
                    writer.Write(((DateTime)p_value).ToBinary()); break;
                case XplNodeType_enum.BOOL:
                    writer.Write((bool)p_value); break;
                case XplNodeType_enum.EMPTY:
                    break;
                default:
                    throw new CodeDOM_Exception("Error writing a basic node.");
            };
            return true;
        }
        public virtual XplNode BinaryRead(XplBinaryReader reader)
        {
            set_ElementName( reader.ReadString() );
            p_nodeType = (XplNodeType_enum)reader.ReadInt32();
            switch (p_nodeType)
            {
                case XplNodeType_enum.STRING:
                    p_value = reader.ReadString(); break;
                case XplNodeType_enum.INT:
                    p_value = reader.ReadInt32(); break;
                case XplNodeType_enum.UNSIGNED:
                    p_value = reader.ReadUInt32(); break;
                case XplNodeType_enum.DATETIME:
                    p_value = DateTime.FromBinary(reader.ReadInt64());
                    break;
                case XplNodeType_enum.BOOL:
                    p_value = reader.ReadBoolean(); break;
                case XplNodeType_enum.EMPTY:
                    break;
                default:
                    throw new CodeDOM_Exception("Error reading a basic node.");
            };
            return this;
        }
        /// <summary>
        /// Lee el nodo y su contenido usando "reader".
        /// El "reader" debe esta parado en el elemento a leer,
        /// de lo contrario producira un error.
        /// </summary>
		public virtual XplNode Read(XplReader reader){
			set_ElementName(reader.Name);
            if (!reader.IsEmptyElement)
            {
                reader.Read();
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                        case XmlNodeType.EndElement:
                            throw new CodeDOM_Exception("Line, Row: " + reader.LineNumber  + "," + reader.LinePosition + ". Child node was not expected as content of this node.");
                        case XmlNodeType.Text:
                            switch (p_nodeType)
                            {
                                case XplNodeType_enum.STRING:
                                    p_value = reader.Value; break;
                                case XplNodeType_enum.INT:
                                    p_value = Convert.ToInt32(reader.Value,CultureInfo.InvariantCulture); break;
                                case XplNodeType_enum.UNSIGNED:
                                    p_value = Convert.ToUInt32(reader.Value,CultureInfo.InvariantCulture); break;
                                case XplNodeType_enum.DATETIME:
                                    p_value = Convert.ToDateTime(reader.Value,CultureInfo.InvariantCulture); break;
                                case XplNodeType_enum.BOOL:
                                    p_value = Convert.ToBoolean(reader.Value,CultureInfo.InvariantCulture); break;
                                case XplNodeType_enum.EMPTY:
                                    break;
                            };
                            break;
                        default:
                            break;
                    }
                    reader.Read();
                }
            }
			return this;
		}

        /// <summary>
        /// Returns first parent expression node or null if it isn't inside a expression node.
        /// </summary>
        public XplExpression CurrentExpression
        {
			get{
				XplNode next=this;
				while(next!=null && next.get_TypeName()!=CodeDOMTypes.XplExpression)
					next=next.get_Parent();
				return (XplExpression)next;
			}
		}
        /// <summary>
        /// Returns first parent namespace node or null if it isn't inside a namespace node.
        /// </summary>
        public XplNamespace CurrentNamespace
        {
			get{
				XplNode next=this;
				while(next!=null && next.get_TypeName()!=CodeDOMTypes.XplNamespace)
					next=next.get_Parent();
				return (XplNamespace)next;
			}
            set
            {
                // empty setter to allow the use of operator += to add nodes
            }
        }

        /// <summary>
        /// Returns current statement or null if the node is not a subnode of an statement
        /// </summary>
        public XplNode CurrentStatement
        {
            get
            {
                XplNode next = this;
                while (next.get_Parent() != null && next.get_Parent().get_TypeName() != CodeDOMTypes.XplFunctionBody) next = next.get_Parent();
                return next.get_Parent() == null ? null : next;
            }
        }

        /// <summary>
        /// Returns current DocumentBody node or null if it isn't inside a DocumentNode node.
        /// </summary>
        public XplDocumentBody CurrentDocumentBody
        {
            get
            {
                XplNode next = this;
                while (next != null && next.get_TypeName() != CodeDOMTypes.XplDocumentBody)
                    next = next.get_Parent();
                return (XplDocumentBody)next;
            }
            set
            {
                // empty setter to allow the use of operator += to add nodes
            }
        }
        /// <summary>
        /// Returns first parent class node or null if it isn't inside a class node.
        /// </summary>
        public XplClass CurrentClass
        {
			get{
				XplNode next=this;
				while(next!=null && next.get_TypeName()!=CodeDOMTypes.XplClass)
					next=next.get_Parent();
				return (XplClass)next;
			}
            set
            {
                // empty setter to allow the use of operator += to add nodes
            }
        }
        /// <summary>
        /// Returns first parent -block- node or null if it isn't inside a -block- node.
        /// </summary>
        public XplFunctionBody CurrentBlock
        {
			get{
				XplNode next=this;
				while(next!=null && next.get_TypeName()!=CodeDOMTypes.XplFunctionBody)
					next=next.get_Parent();
				return (XplFunctionBody)next;
			}
            set 
            { 
                // empty setter to allow the use of operator += to add nodes
            }
		}
        /// <summary>
        /// Returns first parent function node or null if it isn't inside a function node.
        /// </summary>
        public XplFunction CurrentFunction
        {
			get{
				XplNode next=this;
				while(next!=null && next.get_TypeName()!=CodeDOMTypes.XplFunction)
					next=next.get_Parent();
				return (XplFunction)next;
			}
		}
        /// <summary>
        /// Returns first parent property node or null if it isn't inside a property node.
        /// </summary>
        public XplProperty CurrentProperty
        {
			get{
				XplNode next=this;
				while(next!=null && next.get_TypeName()!=CodeDOMTypes.XplProperty)
					next=next.get_Parent();
				return (XplProperty)next;
			}
		}

        /// <summary>
        /// returns zoe representation of the node
        /// </summary>
        public string ZoeXmlString
        {
            get
            {
                return ZoeHelper.WriteToIndentedString(this);
            }
        }

        /// <summary>
        /// returns Meta D++ string representation for current node
        /// </summary>
        public string ReadableString
        {
            get
            {
                if (!_renderModuleLoaded) LoadMetaDppRenderModule();
                if (_renderModule == null) return "## Can't find Meta D++ render module";
                return RenderToString();
            }
        }

        /// <summary>
        /// Internal method, try to call "ConvertToString" method on render module
        /// </summary>
        /// <returns>Renderized string or error</returns>
        private string RenderToString()
        {
            return (string)_renderModule.GetType().InvokeMember(
                "ConvertToString",
                BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance, 
                null, 
                _renderModule, 
                new object[]{ this }, 
                CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Sets the render module used by ReadableString property.
        /// </summary>
        /// <param name="renderModule">An object with "string ConvertToString(XplNode node)" instance method which is able to render XplNodes.</param>
        static public void SetStringRenderModule(object renderModule)
        {
            _renderModule = renderModule;
            _renderModuleLoaded = true;
        }

        static private void LoadMetaDppRenderModule()
        {
            _renderModuleLoaded = true;
            Assembly metaDppModule = null;
            string filename = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/lib_zoe_outmod_dpp.dll";
            if (!File.Exists(filename)) filename = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/outputmodules/lib_zoe_outmod_dpp.dll"; ;
            try
            {
                metaDppModule = Assembly.LoadFrom(filename);
            }
            catch (FileNotFoundException)
            {
                return;
            }
            if (metaDppModule != null)
            {
                Type metaDppModuleType = metaDppModule.GetType("LayerD.OutputModules.DPPZOERenderModule");
                _renderModule = Activator.CreateInstance(metaDppModuleType);
            }
        }

        public override string ToString()
        {
            var tempStr = this.ReadableString;
            if (tempStr.StartsWith("##", StringComparison.InvariantCulture)) return this.ZoeXmlString;
            return tempStr;
        }

        /// <summary>
        /// Adds a node to the end of Children collection.
        /// If Children collection is null exception is thrown
        /// </summary>
        /// <param name="node">Node to add</param>
        /// <returns>Node added</returns>
        public virtual XplNode InsertAtEnd(XplNode node)
        {
            return this.Children().InsertAtEnd(node);
        }

        /// <summary>
        /// Adds a list to the end of Children collection.
        /// If Children collection is null exception is thrown
        /// </summary>
        /// <param name="list">Nodes to add</param>
        /// <returns>Node added</returns>
        public virtual XplNode InsertAtEnd(XplNodeList list)
        {
            return this.Children().InsertAtEnd(list);
        }

        /// <summary>
        /// Adds arg2 node to the end of the Children collection of arg1 node.
        /// </summary>
        /// <param name="arg1">Node to which arg2 will be added as children.</param>
        /// <param name="arg2">Node to add to arg1 as children.</param>
        /// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
        public static XplNode operator +(XplNode arg1, XplNode arg2)
        {
            if (arg1.Children() != null)
            {
                arg1.Children().InsertAtEnd(arg2);
            }
            else
            {
                throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
            }
            return arg1;
        }

        /// <summary>
        /// Adds arg2 nodes to the end of the Children collection of arg1 node.
        /// </summary>
        /// <param name="arg1">Node to which arg2 will be added as children.</param>
        /// <param name="arg2">Nodes to add to arg1 as children.</param>
        /// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
        public static XplNode operator +(XplNode arg1, XplNodeList arg2)
        {
            if (arg1.Children() != null)
            {
                arg1.Children().InsertAtEnd(arg2);
            }
            else
            {
                throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
            }
            return arg1;
        }

        /// <summary>
        /// Busca nodos de acuerdo a la cadena patron "matchString".
        /// 
        /// Comienza en el nodo actual.
        /// Si no encuentra nada devuelve una lista vacia.
        /// 
        /// Las cadenas de patrón deben tener la forma:
        /// 
        /// (/nodeName[(attributeName='attributeValue',)*])*
        /// 
        /// Si la cadena es nula o vacia no realzia busqueda.
        /// </summary>
        public XplNodeList FindNodes(string matchString)
        {
            if (matchString == null || matchString == String.Empty) return null;
            XplNodeList matchedNodes = new XplNodeList();
            //PENDIENTE : implementar una función de split propia
            //de manera q se pueda tener caracter de escape para '/'
            string[] pattern = matchString.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (pattern == null) return matchedNodes;
            __FindNodes(pattern, matchedNodes);
            return matchedNodes;
        }
        /// <summary>
        /// Igual que FindNodes pero usa "list" para almacenar los nodos coincidentes.
        /// Devuelve la propia lista.
        /// Si la lista o la cadena es nula no realiza busqueda.
        /// </summary>
        public XplNodeList FindNodes(string matchString, XplNodeList list)
        {
            if (list == null || matchString == null || matchString == String.Empty) return list;
            //PENDIENTE : implementar una función de split propia
            //de manera q se pueda tener caracter de escape para '/'
            string[] pattern = matchString.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (pattern == null) return list;
            __FindNodes(pattern, list);
            return list;
        }
        /// <summary>
        /// Devuelve el primer nodo encontrado recorriendo en profundidad desde el nodo actual.
        /// Si la cadena es nula no realiza busqueda.
        /// </summary>
        public XplNode FindNode(string matchString)
        {
            if (matchString == null || matchString == String.Empty) return null;
            //PENDIENTE : implementar una función de split propia
            //de manera q se pueda tener caracter de escape para '/'
            string[] pattern = matchString.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (pattern == null) return null;
            return __FindNode(pattern);
        }
        /// <summary>
        /// Implementación interna de la busqueda de nodos.
        /// </summary>
        private XplNode __FindNode(string[] pattern)
        {
            if (_MatchPattern(pattern, 0))
                return this;
            XplNodeList children = this.ChildNodes();
            foreach (XplNode child in children)
                if (child != null)
                {
                    XplNode temp = child.__FindNode(pattern);
                    if (temp != null) return temp;
                }
            return null;
        }

        /// <summary>
        /// Implementación interna de la busqueda de nodos.
        /// </summary>
        private void __FindNodes(string[] pattern, XplNodeList currentList)
        {
            if (_MatchPattern(pattern, 0))
                currentList.InsertAtEnd(this);
            XplNodeList children = this.ChildNodes();
            foreach (XplNode child in children)
                if(child!=null)child.__FindNodes(pattern, currentList);
        }
        private bool _MatchPattern(string[] patern, int myIndex)
        {
            string myPattern = patern[myIndex];
            string nodeNameOrTypeName;
            string valuePattern;
            string attributesPattern = null;
            int attFilterIndex=myPattern.IndexOf('[');
            int valueFilterIndex=myPattern.IndexOf('(');
            bool matchMe = false;
            if(attFilterIndex>0){
                if (valueFilterIndex > 0)
                {
                    //ESTO ES UN ERROR EN LA CADENA DE BUSQUEDA.
                    //ya que nunca voy ha tener un nodo con valor
                    //y atributos pq solo los nodos simples tienen
                    //valor y estos no tienen atributos.
                    return false;
                }
                else
                {
                    nodeNameOrTypeName = myPattern.Substring(0, attFilterIndex );
                    attributesPattern = myPattern.Substring(attFilterIndex + 1, myPattern.Length - attFilterIndex - 2);
                    matchMe = _MatchAttributes(attributesPattern) && _MatchNodeNameOrTypeName(nodeNameOrTypeName);
                }
            }
            else{
                if (valueFilterIndex > 0)
                {
                    nodeNameOrTypeName = myPattern.Substring(0, valueFilterIndex );
                    valuePattern = myPattern.Substring(valueFilterIndex + 1, myPattern.Length - valueFilterIndex - 2);
                    matchMe = _MatchNodeValue(valuePattern) && _MatchNodeNameOrTypeName(nodeNameOrTypeName);
                }
                else
                {
                    nodeNameOrTypeName = myPattern;
                    matchMe = _MatchNodeNameOrTypeName(nodeNameOrTypeName);
                }
            }
            if (!matchMe) return false;
            if(myIndex+1<patern.Length){
                foreach(XplNode child in this.ChildNodes())
                    if(child != null && child._MatchPattern(patern,myIndex+1))return true;
                return false;
            }
            return true;
        }
        private bool _MatchNodeValue(string value)
        {
            return p_value == null ? false : p_value.ToString() == value;
        }
        private bool _MatchAttributes(string attributesPatern)
        {
            ///PENDIENTE : Usar mi propia funcion de split
            string[] allPatterns = attributesPatern.Split(new char[';'], StringSplitOptions.RemoveEmptyEntries);
            if (allPatterns != null) 
                foreach (string atPattern in allPatterns)
                    if (!_MatchIndividualAttribute(atPattern)) return false;
            return true;
        }
        private bool _MatchIndividualAttribute(string atPattern)
        {
            atPattern = atPattern.Trim();
            int indexOfEqual = atPattern.IndexOf('=');
            if (indexOfEqual < 0) return false; //Es un error en la cadena de patron
            string attName = atPattern.Substring(0, indexOfEqual);
            string attValue = atPattern.Substring(indexOfEqual + 2, atPattern.Length - indexOfEqual - 3);
            return _MatchAttributePattern(attName, attValue);
        }
        private bool _MatchAttributePattern(string attName, string attValue)
        {
            string currentAttValue = AttributeValue(attName);
            if (currentAttValue == null) return false; //No se encontro el atributo
            else return currentAttValue == attValue;
        }
        private bool _MatchNodeNameOrTypeName(string nodeNameOrTypeName)
        {
            if (nodeNameOrTypeName[0] == '@') return nodeNameOrTypeName == "@" + get_TypeName();
            else return nodeNameOrTypeName == _elementNames[_elementName];
        }
	}
	
	
	/*	TIPO PARA EL CALLBACK DE LA LISTA DE NODOS	*/
	public delegate bool InsertNodeCallback(XplNode node, ref string errorMsg, XplNode parent);

    [Serializable]
	public class XplNodeList: IEnumerable{
        List<XplNode> p_list = new List<XplNode>();
		XplNode p_parent=null;
		InsertNodeCallback p_insertCallback=null;
		InsertNodeCallback p_removeCallback=null;
		int p_counter = 0;
		string p_errorMsg = String.Empty;

        public XplNodeList(){
		}
		public void set_Parent(XplNode new_parent){
			p_parent = new_parent;
		}
        public XplNode get_Parent()
        {
            return p_parent;
        }
        /// <summary>
        /// Returns the index of child in the list.
        /// If the item is not in the list -1 is returned.
        /// </summary>
        /// <param name="child">Child to find</param>
        /// <returns>Zero based index of child or -1 if not found</returns>
        public int IndexOf(XplNode child)
        {
            return p_list.IndexOf(child);
        }
		public virtual bool Write(XplWriter writer){
			foreach(XplNode node in this){
				if(!node.Write(writer))return false;
			}
			return true;
		}
        public virtual bool BinaryWrite(XplBinaryWriter writer)
        {
            writer.Write(p_list.Count);
            foreach (XplNode node in this)
            {
                if (!node.BinaryWrite(writer)) return false;
            }
            return true;
        }
        public virtual XplNodeList BinaryRead(XplBinaryReader reader)
        {
            this.Clear();
            int count = reader.ReadInt32();
            for (int n = 0; n < count; n++)
            {
                XplNode temp = CDOM_BinaryNodeReader.Read(reader, this.p_parent);
                p_list.Add(temp);
            }
            return this;
        }

        public void set_InsertNodeCallback(InsertNodeCallback callback)
        {
			p_insertCallback=callback;
		}
		public void set_RemoveNodeCallback(InsertNodeCallback callback){
			p_removeCallback=callback;
		}
		public XplNode FirstNode(){
			p_counter=0;
			if(p_list.Count>0)
				return p_list[p_counter];
			else
				return null;
		}
		public XplNode NextNode(){
			p_counter++;
			if(p_counter<p_list.Count)
                return p_list[p_counter];
			return null;
		}
		public XplNode PreviousNode(){
			p_counter--;
			if(p_counter<0)p_counter=0;
            if (p_counter < p_list.Count)
                return p_list[p_counter];
			return null;
		}
		public XplNode LastNode(){
            if (p_list.Count > 0)
                return p_list[p_list.Count - 1];
			else
				return null;
		}
        [Obsolete]
		public XplNode GetLastNode(){
			return null;
		}
		public XplNode GetNodeAt(int position){
            return p_list[position];
		}
		public int GetLength(){
            return p_list.Count;
		}


        public XplNode InsertAtEnd(XplNode newNode)
        {
            if (newNode == null) return null;
            if (p_insertCallback == null || p_insertCallback(newNode, ref p_errorMsg, p_parent))
            {
                p_list.Add(newNode);
                return newNode;
            }
            else throw new CodeDOM_Exception(p_errorMsg, "Inside InsertAtEnd() in XplNodeList.");
        }
        public XplNode InsertAtBegin(XplNode newNode)
        {
            if (p_insertCallback == null || p_insertCallback(newNode, ref p_errorMsg, p_parent))
            {
                if (p_list.Count == 0)
                    p_list.Add(newNode);
                else
                    p_list.Insert(0, newNode);
                return newNode;
            }
            else throw new CodeDOM_Exception(p_errorMsg, "Inside InsertAtBegin() in XplNodeList."); ;
        }
        public XplNode InsertAt(XplNode newNode, int position)
        {
			if(p_insertCallback==null || p_insertCallback(newNode,ref p_errorMsg,p_parent)){
                p_list.Insert(position, newNode);
				return newNode;
			}
			else throw new CodeDOM_Exception(p_errorMsg, "Inside InsertAt() in XplNodeList.");;
		}
		public XplNode InsertAfter(XplNode newNode, XplNode reference){
			if(p_insertCallback==null || p_insertCallback(newNode,ref p_errorMsg,p_parent)){
                int tmpIdx = p_list.IndexOf(reference);
                if (tmpIdx < 0) return null;
                p_list.Insert(tmpIdx + 1, newNode);
				return newNode;
			}
            else throw new CodeDOM_Exception(p_errorMsg, "Inside InsertAtAfter() in XplNodeList."); ;
		}
		public XplNode InsertBefore(XplNode newNode, XplNode reference){
			if(p_insertCallback==null || p_insertCallback(newNode,ref p_errorMsg,p_parent)){
                int tmpIdx = p_list.IndexOf(reference);
                if (tmpIdx < 0) return null;
                p_list.Insert(tmpIdx, newNode);
				return newNode;
			}
            else throw new CodeDOM_Exception(p_errorMsg, "Inside InsertBefore() in XplNodeList."); ;
		}


        public XplNode InsertAtEnd(XplNodeList newNodeList)
        {
            if (newNodeList == null || newNodeList == this) return null;
            foreach (XplNode newNode in newNodeList)
                InsertAtEnd(newNode);
            return null;
        }

        public XplNode InsertAtBegin(XplNodeList newNodeList)
        {
            if (newNodeList == null || newNodeList == this) return null;
            int length = newNodeList.GetLength();
            if (length > 0)
            {
                for (int n = length - 1; n >= 0; n--)
                    InsertAtBegin(newNodeList.GetNodeAt(n));
            }
            return null;
        }
        public XplNode InsertAfter(XplNodeList newNodeList, XplNode reference)
        {
            if (newNodeList == null || newNodeList == this) return null;
            foreach (XplNode newNode in newNodeList)
            {
                InsertAfter(newNode, reference);
                reference = newNode;
            }
            return null;
        }
        public XplNode InsertBefore(XplNodeList newNodeList, XplNode reference)
        {
            if (newNodeList == null || newNodeList == this) return null;
            foreach (XplNode newNode in newNodeList)
                InsertBefore(newNode, reference);
            return null;
        }

		public XplNode Remove(int position){
            XplNode node = p_list[position];
			if(p_insertCallback==null || p_removeCallback(node,ref p_errorMsg,p_parent)){
                p_list.Remove(node);
				return node;
			}
            else throw new CodeDOM_Exception(p_errorMsg, "Inside Remove() in XplNodeList.");
		}
        public XplNode Remove(XplNode node)
        {
            if (p_insertCallback == null || p_removeCallback(node, ref p_errorMsg, p_parent))
            {
                p_list.Remove(node);
                return node;
            }
            else throw new CodeDOM_Exception(p_errorMsg, "Inside Remove() in XplNodeList.");
        }
        public bool Contains(XplNode Node) {
            return p_list.Contains(Node);
		}
		public bool Clear(){
            p_list.Clear();
			return true;
		}
		public CodeDOMTypes get_TypeName(){
			return CodeDOMTypes.XplNodeList;
		}
        public static void CopyNodesAtEnd(XplNodeList source, XplNodeList target)
        {
            foreach (XplNode sourceNode in source)
                target.InsertAtEnd(sourceNode);
        }

        #region operators
        /// <summary>
        /// Adds arg2 node to the end of the arg1 list.
        /// </summary>
        /// <param name="arg1">List to which arg2 will be added as children.</param>
        /// <param name="arg2">Node to add to arg1 list.</param>
        /// <returns>arg1 list or ArgumentNullException if arg1 is null.</returns>
        public static XplNodeList operator +(XplNodeList arg1, XplNode arg2)
        {
            if (arg1 != null)
            {
                arg1.InsertAtEnd(arg2);
            }
            else
            {
                throw new CodeDOM_Exception("List is null. Node can't be added.");
            }
            return arg1;
        }

        /// <summary>
        /// Adds arg2 nodes to the end of arg1 list.
        /// </summary>
        /// <param name="arg1">List to which arg2 will be added as children.</param>
        /// <param name="arg2">List to add to arg1 as children.</param>
        /// <returns>arg1 node or ArgumentNullException if arg1 is null.</returns>
        public static XplNodeList operator +(XplNodeList arg1, XplNodeList arg2)
        {
            if (arg1 != null)
            {
                arg1.InsertAtEnd(arg2);
            }
            else
            {
                throw new CodeDOM_Exception("List is null. Nodes can't be added.");
            }
            return arg1;
        }
        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return p_list.GetEnumerator();
        }

        #endregion

        /// <summary>
        /// Get previous node in the list
        /// </summary>
        /// <param name="node">Relative node to which obtain previous node</param>
        /// <returns>Previous node or null if node is the first node or if node is not in the list.</returns>
        public XplNode PreviousSibling(XplNode node)
        {
            int index = this.p_list.IndexOf(node);
            if (index <= 0) return null;
            return this.p_list[index - 1];
        }

        /// <summary>
        /// Get next node in the list
        /// </summary>
        /// <param name="node">Relative node to which obtain next node</param>
        /// <returns>Next node or null if node is the last node or if node is not in the list.</returns>
        public XplNode NextSibling(XplNode node)
        {
            int index = this.p_list.IndexOf(node);
            if (index < 0 || index == this.p_list.Count - 1) return null;
            return this.p_list[index + 1];
        }

        public int GetIndexOf(XplNode node)
        {
            return this.p_list.IndexOf(node);
        }
    }
	
}
