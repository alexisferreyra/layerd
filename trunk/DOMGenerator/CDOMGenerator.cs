/*-
 * Copyright (c) 2002-2008 Alexis Ferreyra
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
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml;
using System.Windows.Forms;
using System.IO;


namespace DOMGenerator {

	#region Clases SimpleType ComplexType Elemento Atributo
	public class SimpleType{
		public string nombre;
		public string tipo;
		public string tipoEnCodigo;
		public bool esEnum;
		public string defaultValue;
		public ArrayList enumValues;
        public int ID;
		public SimpleType(){
			enumValues=new ArrayList();
		}
	}

	public class ComplexType{
		public string nombre;
		public ArrayList secuencia;
		public ArrayList choice;
		public ArrayList atributos;
		public bool secuenciaOrdenada;
		public bool secuenciaBounded;
		public bool choiceBounded;
		public string choiceName;
		public string claseBaseChoice;
		public string claseBase;
		public string tipo;
		public string tipoEnCodigo;
        public int ID;
		public ComplexType(){
			secuencia=new ArrayList();
			choice=new ArrayList();
			atributos=new ArrayList();
		}
	}

	public class Elemento{
		public string nombre;
		public string nombreEnCodigo;
		public string tipo;
		public string tipoEnCodigo;
		public bool isSimpleType;
		public bool isComplexType;
		public SimpleType simpleType=null;
		public ComplexType complexType=null;
		public bool optional;
		public int minOccurs;
		public bool unbounded;
		public bool requiereOrden;
		public string defaultValue;
	}

	public class Atributo{
		public string nombre;
		public string tipo;
		public string tipoEnCodigo;
		public bool isSimpleType;
		public SimpleType simpleType=null;
		public bool optional;
		public string defaultValue;
	}
	class TreeNode{
		public Hashtable parents;
		public Hashtable childs;
		public int nivel;
		public string name;
		public TreeNode(){
			parents=new Hashtable();
			childs=new Hashtable();
			nivel=Int32.MinValue;
		}
	}	
	#endregion

    /// <summary>
    /// This class generates C# or C++ code for implementing Zoe CodeDOM from Zoe XML Schema.
    /// 
    /// WARNING:
    /// This class is crap, it must be reimplemented in Meta D++ from scratch :-). Please let me know
    /// if you can help me with that!
    /// </summary>
	public class CDOMGenerator{

		#region Variables Privadas
		Hashtable SimpleTypes=null;
		Hashtable ComplexTypes=null;
		private System.Xml.XmlDocument source=null;
		bool isCS=false;

		private string outputPath;
		StreamWriter sr,sf;
		#endregion

		#region Tree
		Hashtable Tree;
		private void GenerateTree(){
			TreeNode node=null,node2=null;
			Tree=new Hashtable();
			foreach(ComplexType cp in ComplexTypes.Values){
				if(Tree.ContainsKey(cp.tipo))
					node=(TreeNode)Tree[cp.tipo];
				else{
					node=new TreeNode();
					node.name=cp.tipo;
					Tree.Add(cp.tipo,node);
				}

				foreach(Elemento el in cp.secuencia){
					if(el.isComplexType && el.tipo != cp.tipo /*Para comprobar recursividad*/){
						if(Tree.ContainsKey(el.tipo))
							node2=(TreeNode)Tree[el.tipo];
						else{
							node2=new TreeNode();
							node2.name=el.tipo;
							Tree.Add(el.tipo,node2);
						}						
						if(!node.childs.ContainsKey(el.tipo))node.childs.Add(el.tipo,node2);
						if(!node2.parents.ContainsKey(el.tipo))node2.parents.Add(el.tipo,node);
					}
				}
				foreach(Elemento el in cp.choice){
					if(el.isComplexType && el.tipo != cp.tipo /*Para comprobar recursividad*/){
						if(Tree.ContainsKey(el.tipo))
							node2=(TreeNode)Tree[el.tipo];
						else{
							node2=new TreeNode();
							node2.name=el.tipo;
							Tree.Add(el.tipo,node2);
						}
						if(!node.childs.ContainsKey(el.tipo))node.childs.Add(el.tipo,node2);
						if(!node2.parents.ContainsKey(el.tipo))node2.parents.Add(el.tipo,node);
					}
				}

			}
			///Aca debo tener el arbol armado con las dependencias
		}

		int minLevel=Int32.MaxValue;
		int maxLevel=Int32.MinValue;
		Hashtable stack=null;
		private void RecorrerNodos(TreeNode node,int nivel){
			if(nivel<node.nivel)return;
			node.nivel=nivel;
			bool flag=false;
			if(!stack.ContainsKey(node.name)){
				stack.Add(node.name,node);
				flag=true;
			}
			if(nivel<minLevel)minLevel=nivel;
			if(nivel>maxLevel)maxLevel=nivel;
			foreach(TreeNode child in node.childs.Values){
				if(!stack.ContainsKey(child.name) && (child.nivel<nivel+1 || child.nivel==Int32.MinValue)){
					RecorrerNodos(child,nivel+1);
				}
			}
			/*
			foreach(TreeNode parent in node.parents.Values){
				if(!stack.ContainsKey(parent.name) && ( parent.nivel==Int32.MinValue))RecorrerNodos(parent,nivel-1);
			}
			*/
			if(flag)
				stack.Remove(node.name);
		}

		private void MakeLevels(){
			TreeNode node=(TreeNode)Tree["tDocument"];
			stack=new Hashtable();
			RecorrerNodos(node,0);
		}
		#endregion

		#region CDOMGenerator InitProcess
		public CDOMGenerator(){
			SimpleTypes=new Hashtable();
			ComplexTypes=new Hashtable();
		}
		public bool InitProcess(string sourcename,string targetname,bool generarCSCode) {
			System.Xml.XmlNodeList nodeList,nodeList2;
			System.Xml.XmlNode node1;
			outputPath=targetname;
			isCS=generarCSCode;

			source=new System.Xml.XmlDocument();
			source.Load(sourcename);
			nodeList=source.GetElementsByTagName( "xs:complexType");
			nodeList2=source.GetElementsByTagName("xs:simpleType");

			//Primero cargo los tipos simples
			for(int n=0;n<nodeList2.Count;n++){
				node1=nodeList2.Item(n).Attributes.GetNamedItem("name");
				if(node1!=null)
					LoadSimpleType(node1.Value,nodeList2.Item(n));
			}
			//Luego cargo los tipos complejos
			for(int n=0;n<nodeList.Count;n++){
				node1=nodeList.Item(n).Attributes.GetNamedItem("name");
				if(node1!=null)
					LoadComplexType(node1.Value,nodeList.Item(n));
			}
            //Cargo la numeracion de tipos complejos
            int counter = 100;
            foreach (ComplexType cp in ComplexTypes.Values)
            {
                cp.ID = counter;
                counter++;
            }
			//Luego genero los archivos
			if(!generarCSCode){ //Código C++
				sf=new StreamWriter(outputPath+"CDOM_SimpleTypes.h");
				//Primero el encabezado
				MakeHeaderST(true);
                // constants for types enumartion
                sf.WriteLine("enum CodeDOMTypes {");
                sf.WriteLine("\tCODEDOMTYPES_ZOENODELIST = 1000, ");
                sf.WriteLine("\tCODEDOMTYPES_EMPTY = 0, ");
                sf.WriteLine("\tCODEDOMTYPES_ZOENODE = 1, ");
                sf.WriteLine("\tCODEDOMTYPES_STRING = 2, ");
                sf.WriteLine("\tCODEDOMTYPES_INTEGER = 3, ");
                sf.WriteLine("\tCODEDOMTYPES_UNSIGNED = 4, ");
                sf.WriteLine("\tCODEDOMTYPES_DATETIME = 5, ");
                sf.WriteLine("\tCODEDOMTYPES_BOOLEAN = 6, ");

                foreach (ComplexType cp in ComplexTypes.Values) sf.WriteLine("\tCODEDOMTYPES_" + cp.tipoEnCodigo.ToUpper() + " = " + cp.ID.ToString() + ", ");
                sf.WriteLine("};");

				foreach(SimpleType sp in SimpleTypes.Values){
					GenerarEnum(sp,true);
				}
				MakeFooterST();
				//Luego el CPP
				sf=new StreamWriter(outputPath+"CDOM_SimpleTypes.cpp");
				MakeHeaderST(false);
				foreach(SimpleType sp in SimpleTypes.Values){
					GenerarEnum(sp,false);
				}
				MakeFooterST();

				foreach(ComplexType cp in ComplexTypes.Values){
					GenerarHeader(cp);
					GenerarBody(cp);
					GenerarDocumentacion(cp);
				}
				GeneratePreDeclHeader();
				GenerateIncludeAll();
				GenerarMakefile();
			}
			else{ //Código C#
				sf=new StreamWriter(outputPath+"CDOM_SimpleTypes.cs");
				//Primero el encabezado
				MakeHeaderST_CS();
                sf.WriteLine("\tpublic enum CodeDOMTypes {");
                sf.WriteLine("\t\tXplNodeList = 1000, ");
                sf.WriteLine("\t\tEmpty = 0, ");
                sf.WriteLine("\t\tXplNode = 1, ");
                sf.WriteLine("\t\tString = 2, ");
                sf.WriteLine("\t\tInteger = 3, ");
                sf.WriteLine("\t\tUnsigned = 4, ");
                sf.WriteLine("\t\tDateTime = 5, ");
                sf.WriteLine("\t\tBoolean = 6, ");

                foreach (ComplexType cp in ComplexTypes.Values) sf.WriteLine("\t\t" + cp.tipoEnCodigo + " = " + cp.ID.ToString() + ", ");
                sf.WriteLine("\t}");
				foreach(SimpleType sp in SimpleTypes.Values)GenerarEnum_CS(sp,false);
				sf.WriteLine("");
				sf.WriteLine("\tpublic class CodeDOM_STV{");
				sf.WriteLine("");
				foreach(SimpleType sp in SimpleTypes.Values)GenerarEnum_CS(sp,true);
				sf.WriteLine("");
				sf.WriteLine("\t}");
				MakeFooterST_CS();

				foreach(ComplexType cp in ComplexTypes.Values){
					GenerarBody_CS(cp);
					GenerarDocumentacion(cp);
				}
			}
			return true;
		}
		#endregion

		#region Ayudas para Enc y Pies para Codigo C#
		void MakeHeaderST_CS(){
			sf.WriteLine ("/*-------------------------------------------------");
			sf.WriteLine (" *");
			sf.WriteLine (" *	Este archivo fue generado automáticamente.");
			sf.WriteLine (" *	Fecha: " + System.DateTime.Now.ToString() );
			sf.WriteLine (" *");
			sf.WriteLine (" *	Generado por Zoe CodeDOM Generator para C#.");
			sf.WriteLine (" *	COPYRIGHT 2002,2005-2006. por Alexis Ferreyra.");
			sf.WriteLine (" *");
			sf.WriteLine (" *------------------------------------------------*/");
			sf.WriteLine ("");
			sf.WriteLine ("using System;");
			sf.WriteLine ("");
			sf.WriteLine ("namespace LayerD.CodeDOM{");
            sf.WriteLine("\tclass CDOM_BinaryNodeReader{");
            sf.WriteLine("\t\tpublic static XplNode Read(XplBinaryReader reader, XplNode parent){");

            sf.WriteLine("\t\t\tXplNode retNode = null;");
            sf.WriteLine("\t\t\tswitch(reader.ReadInt32()){");
            sf.WriteLine("\t\t\t\tcase 1: //XplNode");
            sf.WriteLine("\t\t\t\t\tretNode = new XplNode();");
            sf.WriteLine("\t\t\t\t\tbreak;");
            foreach (ComplexType cp in ComplexTypes.Values)
            {
                sf.WriteLine("\t\t\t\tcase " + cp.ID + ": //" + cp.tipoEnCodigo);
                sf.WriteLine("\t\t\t\t\tretNode = new " + cp.tipoEnCodigo + "();");
                sf.WriteLine("\t\t\t\t\tbreak;");
            }
            sf.WriteLine("\t\t\t}");
            sf.WriteLine("\t\t\tretNode.set_Parent(parent);");
            sf.WriteLine("\t\t\treturn retNode.BinaryRead(reader);");
            sf.WriteLine("\t\t}");
            sf.WriteLine("\t}");
			sf.WriteLine ("");
		}
		void MakeFooterST_CS(){
			sf.WriteLine ("");
			sf.WriteLine ("}");
			sf.WriteLine ("");
			sf.WriteLine ("/*-------Fin de Archivo Generado------------------*/");
			sf.WriteLine ("");
			sf.Close();
		}
		void MakeHeader_CS(string name){
			sr.WriteLine ("/*-------------------------------------------------");
			sr.WriteLine (" *");
			sr.WriteLine (" *	Este archivo fue generado automáticamente.");
			sr.WriteLine (" *	Fecha: " + System.DateTime.Now.ToString() );
			sr.WriteLine (" *");
			sr.WriteLine (" *	Generado por Zoe CodeDOM Generator para C#.");
			sr.WriteLine (" *	COPYRIGHT 2002,2005-2006. por Alexis Ferreyra.");
			sr.WriteLine (" *");
			sr.WriteLine (" *------------------------------------------------*/");
			sr.WriteLine ("");
			sr.WriteLine ("using System;");
			sr.WriteLine ("using System.Xml;");
            sr.WriteLine ("using System.IO;");
            sr.WriteLine("");
			sr.WriteLine ("namespace LayerD.CodeDOM{");
			sr.WriteLine ("");
		}
		void MakeFoot_CS(string name){
			sr.WriteLine ("}");
			sr.WriteLine ("");
			sr.WriteLine ("/*-------Fin de Archivo Generado------------------*/");
			sr.WriteLine ("");
		}
		#endregion

		#region Generar Enums para Código C#
		private void GenerarEnum_CS(SimpleType sp,bool values){
			string str=null,str2=null;

			if(!values){
                str2 += "\t[Serializable]\n\tpublic enum " + sp.tipoEnCodigo + ":int{";
				foreach(string aux in sp.enumValues) {
					str2+=aux.ToUpper()+",";
				}
				str2=str2.Substring(0,str2.Length-1)+"}";
				sf.WriteLine(str2);
			}
			else{
				str+="\t\tstatic public string []"+sp.tipoEnCodigo.ToUpper()+"={";
				foreach(string aux in sp.enumValues) {
					str+="\""+aux+"\",";
				}
				str=str.Substring(0,str.Length-1)+"};";
				sf.WriteLine(str);
			}
		}
		#endregion

		#region Generar ComplexTypes para C#
		private void GenerarBody_CS(ComplexType cp){
			string filename="CDOM_"+cp.tipoEnCodigo+".cs",str="",pointer="";
			string auxStr;
			sr = File.CreateText(outputPath+filename);
			MakeHeader_CS(cp.tipoEnCodigo);
			//Declaro la clase
            str += "[Serializable]\npublic class " + cp.tipoEnCodigo + ": " + ((cp.claseBase == null) ? " XplNode" : cp.claseBase) + "{\n";
			//Si existe un tipo con secuencia y con choice es un error con el presente diseño en mente
			if(cp.secuencia.Count>0 && cp.choice.Count>0)
				MessageBox.Show("Tipo con Secuencia y Choice:"+cp.nombre,"¡ATENCIÓN!");
			//Miembros dato privados
			#region Miembos Dato Privados
			str+="\n\t#region Variables privadas para atributos y elementos\n";
			foreach(Atributo at in cp.atributos){
				str+="\t"+at.tipoEnCodigo+pointer+" p_"+at.nombre+";\n";
			}
			if(cp.secuencia.Count>0){
				str+="\t//Variables para Elementos de Secuencia\n";
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					str+="\tXplNodeList p_Children;\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								str+="\tXplNodeList p_"+el.nombreEnCodigo+";\n";
							}
							else{
								//pointer="*";
								str+="\t"+el.tipoEnCodigo+pointer+" p_"+el.nombreEnCodigo+";\n";
							}
						}
						else{ //Es tipo simple
							str+="\tXplNode p_"+el.nombreEnCodigo+";\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				str+="\n\t//Variables para Elementos de Choice\n";
				//Primero compruebo si es un choice ordenada o de coleccion
				if(cp.choiceBounded){
					MessageBox.Show("ERROR: Choice Unbounded. "+cp.nombre+".");
				}
				else{
					if(cp.claseBaseChoice!=null){
						str+="\t"+cp.claseBaseChoice+" p_choiceContent;\n";
					}
					else{
						str+="\tXplNode p_choiceContent;\n";
					}
				}
			}
			str+="\t#endregion\n\n";
			#endregion
			//Constructores
			#region Constructores
			string dec_atributos=null, dec_atributos_req=null, dec_elementos=null, dec_elementos_req=null, dec_choice=null;
			string imp_atributos=null, imp_atributos_req=null, imp_elementos=null, imp_elementos_req=null, imp_choice=null,imp_atributos_def=null,imp_elementos_def=null;
			#region Armado de variables auxiliares
			foreach(Atributo at in cp.atributos){
				dec_atributos+=at.tipoEnCodigo+" n_"+at.nombre+", ";
				if(!at.optional || !at.optional && at.defaultValue!=null)dec_atributos_req+=at.tipoEnCodigo+" n_"+at.nombre+", ";
			}
			if(cp.secuencia.Count>0){
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					dec_elementos+="XplNodeList n_Children, ";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								dec_elementos+="XplNodeList n_"+el.nombreEnCodigo+", ";
								if(!el.optional)
									dec_elementos_req+="XplNodeList n_"+el.nombreEnCodigo+", ";
							}
							else{
								//pointer="*";
								dec_elementos+=el.tipoEnCodigo+pointer+" n_"+el.nombreEnCodigo+", ";
								if(!el.optional)
									dec_elementos_req+=el.tipoEnCodigo+pointer+" n_"+el.nombreEnCodigo+", ";
							}
						}
						else{ //Es tipo simple
							dec_elementos+="XplNode n_"+el.nombreEnCodigo+", ";
							if(!el.optional)
								dec_elementos_req+="XplNode n_"+el.nombreEnCodigo+", ";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				if(cp.claseBaseChoice!=null){
					dec_choice+=cp.claseBaseChoice+" n_choiceContent, ";
				}
				else{
                    dec_choice += "XplNode n_choiceContent, ";
				}
			}
			#endregion
			#region Armado de variables auxiliares impl
			foreach(Atributo at in cp.atributos){
				imp_atributos+="\t\tset_"+at.nombre+"(n_"+at.nombre+");\n";
				if(at.defaultValue!=null){
					imp_atributos_def+="\t\tp_"+at.nombre+" = "+ParseDefaultValue_CS(at)+";\n";
				}
				else{
					imp_atributos_def+="\t\tp_"+at.nombre+" = "+GetDefaultInitValue_CS(at)+";\n";
				}
				if(!at.optional || !at.optional && at.defaultValue!=null){
					imp_atributos_req+="\t\tset_"+at.nombre+"(n_"+at.nombre+");\n";
				}
			}
			if(cp.secuencia.Count>0){
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					imp_elementos_def+="\t\tp_Children = new XplNodeList();\n";
					imp_elementos_def+="\t\tp_Children.set_Parent(this);\n";
					imp_elementos_def+="\t\tp_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_"+cp.nombre+"));\n";
					imp_elementos_def+="\t\tp_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_"+cp.nombre+"));\n";
					imp_elementos+="\t\t//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS\n";
					imp_elementos+="\t\tif(n_Children!=null)\n";
					imp_elementos+="\t\tfor(XplNode node = n_Children.FirstNode(); node != null ; node = n_Children.NextNode()){\n";
					imp_elementos+="\t\t\tp_Children.InsertAtEnd(node);\n";
					imp_elementos+="\t\t}\n";
					//Esto debe ser opcional
					imp_elementos+="\t\t//#else\n";
					imp_elementos+="\t\t//p_Children = n_Children;\n";
					imp_elementos+="\t\t//#endif\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								imp_elementos_def+="\t\tp_"+el.nombreEnCodigo+" = new XplNodeList();\n";
								imp_elementos_def+="\t\tp_"+el.nombreEnCodigo+".set_Parent(this);\n";
								imp_elementos_def+="\t\tp_"+el.nombreEnCodigo+".set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_"+el.nombreEnCodigo+"));\n";
								imp_elementos_def+="\t\tp_"+el.nombreEnCodigo+".set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_"+el.nombreEnCodigo+"));\n";
								imp_elementos+="\t\t//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS\n";
								imp_elementos+="\t\tif(n_"+el.nombreEnCodigo+"!=null)\n";
								imp_elementos+="\t\tfor(XplNode node = n_"+el.nombreEnCodigo+".FirstNode(); node != null ; node = n_"+el.nombreEnCodigo+".NextNode()){\n";
								imp_elementos+="\t\t\tp_"+el.nombreEnCodigo+".InsertAtEnd(node);\n";
								imp_elementos+="\t\t}\n";
								//Esto debe ser opcional
								imp_elementos+="\t\t//#else\n";
								imp_elementos+="\t\t//p_Children = n_Children;\n";
								imp_elementos+="\t\t//#endif\n";
								if(!el.optional){
									imp_elementos_req+="\t\t//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS\n";
									imp_elementos_req+="\t\tif(n_"+el.nombreEnCodigo+"!=null)\n";
									imp_elementos_req+="\t\tfor(XplNode node = n_"+el.nombreEnCodigo+".FirstNode(); node != null ; node = n_"+el.nombreEnCodigo+".NextNode()){\n";
									imp_elementos_req+="\t\t\tp_"+el.nombreEnCodigo+".InsertAtEnd(node);\n";
									imp_elementos_req+="\t\t}\n";
									//Esto debe ser opcional
									imp_elementos_req+="\t\t//#else\n";
									imp_elementos_req+="\t\t//p_Children = n_Children;\n";
									imp_elementos_req+="\t\t//#endif\n";
								}
							}
							else{
								imp_elementos_def+="\t\tp_"+el.nombreEnCodigo+"=null;\n";
								imp_elementos+="\t\tset_"+el.nombreEnCodigo+"(n_"+el.nombreEnCodigo+");\n";
								if(!el.optional)
									imp_elementos_req+="\t\tset_"+el.nombreEnCodigo+"(n_"+el.nombreEnCodigo+");\n";
							}
						}
						else{ //Es tipo simple
							imp_elementos_def+="\t\tp_"+el.nombreEnCodigo+"=null;\n";
							imp_elementos+="\t\tset_"+el.nombreEnCodigo+"(n_"+el.nombreEnCodigo+");\n";
							if(!el.optional)
								imp_elementos_req+="\t\tset_"+el.nombreEnCodigo+"(n_"+el.nombreEnCodigo+");\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				if(cp.claseBaseChoice!=null){
					imp_elementos_def+="\t\tp_choiceContent=null;\n";
                    imp_choice += "\t\tset_Content(n_choiceContent);\n";
				}
				else{
                    imp_elementos_def += "\t\tp_choiceContent=null;\n";
                    imp_choice += "\t\tset_Content(n_choiceContent);\n";
				}
			}
			#endregion
			str+="\t#region Region de Constructores Publicos\n";
			str+="\tpublic "+cp.tipoEnCodigo+"(){\n";
			str+=imp_atributos_def+imp_elementos_def;
			str+="}\n";
			#region Todas las combinaciones de constructores
			if(dec_atributos_req==dec_atributos)dec_atributos=null;
			if(dec_elementos_req==dec_elementos)dec_elementos=null;
			if(dec_atributos_req!=null){
				#region Declaracion
				auxStr=dec_atributos_req;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\tpublic "+cp.tipoEnCodigo+"("+auxStr+"){\n";
				#endregion
				str+=imp_atributos_def+imp_atributos_req+imp_elementos_def;
				str+="\t}\n";
			}
			if(dec_elementos_req!=null){
				#region Declaracion
				auxStr=dec_elementos_req;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\tpublic "+cp.tipoEnCodigo+"("+auxStr+"){\n";
				#endregion
				str+=imp_atributos_def+imp_elementos_def+imp_elementos_req;
				str+="\t}\n";
			}
			if(dec_atributos_req!=null && dec_elementos_req!=null){
				#region Declaracion
				auxStr=dec_atributos_req+dec_elementos_req;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\tpublic "+cp.tipoEnCodigo+"("+auxStr+"){\n";
				#endregion
				str+=imp_atributos_def+imp_atributos_req+imp_elementos_def+imp_elementos_req;
				str+="\t}\n";
			}
			if(dec_atributos!=null){
				#region Declaracion
				auxStr=dec_atributos;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\tpublic "+cp.tipoEnCodigo+"("+auxStr+"){\n";
				#endregion
				str+=imp_atributos+imp_elementos_def;
				str+="\t}\n";
			}
			if(dec_elementos!=null){
				#region Declaracion
				auxStr=dec_elementos;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\tpublic "+cp.tipoEnCodigo+"("+auxStr+"){\n";
				#endregion
				str+=imp_atributos_def+imp_elementos_def+imp_elementos;
				str+="\t}\n";
			}
			if(dec_atributos!=null && dec_elementos_req!=null){
				#region Declaracion
				auxStr=dec_atributos+dec_elementos_req;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\tpublic "+cp.tipoEnCodigo+"("+auxStr+"){\n";
				#endregion
				str+=imp_atributos+imp_atributos_req+imp_elementos_def;
				str+="\t}\n";
			}
			if(dec_atributos_req!=null && dec_elementos!=null){
				#region Declaracion
				auxStr=dec_atributos_req+dec_elementos;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\tpublic "+cp.tipoEnCodigo+"("+auxStr+"){\n";
				#endregion
				str+=imp_atributos_def+imp_atributos_req+imp_elementos_def+imp_elementos;
				str+="\t}\n";
			}
			if(dec_atributos!=null && dec_elementos!=null){
				#region Declaracion
				auxStr=dec_atributos+dec_elementos;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\tpublic "+cp.tipoEnCodigo+"("+auxStr+"){\n";
				#endregion
				str+=imp_atributos+imp_elementos_def+imp_elementos;
				str+="\t}\n";
			}
			if(dec_choice!=null){
				#region Declaracion
				auxStr=dec_choice;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\tpublic "+cp.tipoEnCodigo+"("+auxStr+"){\n";
				#endregion
				str+=imp_atributos_def+imp_elementos_def+imp_choice;
				str+="\t}\n";
			}
			if(dec_atributos_req!=null && dec_choice!=null){
				#region Declaracion
				auxStr=dec_atributos_req+dec_choice;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\tpublic "+cp.tipoEnCodigo+"("+auxStr+"){\n";
				#endregion
				str+=imp_atributos_def+imp_atributos_req+imp_elementos_def+imp_choice;
				str+="\t}\n";
			}
			if(dec_atributos!=null && dec_choice!=null){
				#region Declaracion
				auxStr=dec_atributos+dec_choice;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\tpublic "+cp.tipoEnCodigo+"("+auxStr+"){\n";
				#endregion
				str+=imp_atributos+imp_elementos_def+imp_choice;
				str+="\t}\n";
			}
			#endregion
			str+="\t#endregion\n\n";
			#endregion
			//Destructores
			#region Destructores
			str+="\t#region Destructor\n/*\tpublic ~"+cp.tipoEnCodigo+"(){\n";
			str+="\t\tSe supone que .NET no necesita destructores sólo para liberar memoria";
			str+="\t}*/\n";
			str+="\t#endregion\n\n";
			#endregion
			//Sobreescritura de miembros de XplNode (Save, Load, Attach, operators)
			#region Sobreescritura de XplNode
			str+="\t#region Funciones Sobreescritas de XplNode\n";
			#region Clone
			str+="\tpublic override XplNode Clone(){\n";
			str+="\t\t"+cp.tipoEnCodigo+" copy = new "+cp.tipoEnCodigo+"();\n";
			//Copio los atributos
			foreach(Atributo at in cp.atributos){
				str+="\t\tcopy.set_"+at.nombre+"(this.p_"+at.nombre+");\n";
			}
			//Copio los elementos
			if(cp.secuencia.Count>0){
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					str+="\t\tfor(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){\n";
					str+="\t\t\tcopy.Children().InsertAtEnd(node.Clone());\n";
					str+="\t\t}\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								str+="\t\tfor(XplNode node = p_"+el.nombreEnCodigo+".FirstNode(); node != null ; node = p_"+el.nombreEnCodigo+".NextNode()){\n";
								str+="\t\t\tcopy.get_"+el.nombreEnCodigo+"().InsertAtEnd(node.Clone());\n";
								str+="\t\t}\n";
							}
							else{
                                str += "\t\tif(p_" + el.nombreEnCodigo + "!=null)copy.set_" + el.nombreEnCodigo + "((" + el.tipoEnCodigo + ")p_" + el.nombreEnCodigo + ".Clone());\n";
							}
						}
						else{ //Es tipo simple
                            str += "\t\tif(p_" + el.nombreEnCodigo + "!=null)copy.set_" + el.nombreEnCodigo + "(p_" + el.nombreEnCodigo + ".Clone());\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				str+="\n\t\t//Variables para Elementos de Choice\n";
				//Primero compruebo si es un choice ordenada o de coleccion
				if(cp.choiceBounded){
					MessageBox.Show("ERROR: Choice Unbounded. "+cp.nombre+".");
				}
				else{
					if(cp.claseBaseChoice!=null){
                        str += "\t\tif(p_choiceContent!=null)copy.set_Content(p_choiceContent.Clone());\n";
					}
					else{
                        str += "\t\tif(p_choiceContent!=null)copy.set_Content(p_choiceContent.Clone());\n";
					}
				}
			}
			str+="\t\tcopy.set_ElementName(this.get_ElementName());\n";
			str+="\t\treturn (XplNode)copy;\n";
			str+="\t}\n\n";
			#endregion
			str+="\tpublic override CodeDOMTypes get_TypeName(){return CodeDOMTypes."+cp.tipoEnCodigo+";}\n\n";
			#region Write
			str+="\tpublic override bool Write(XplWriter writer){\n";
			str+="\t\tbool result=true;\n";
			str+="\t\t//Escribo el encabezado del elemento\n";
			str+="\t\twriter.WriteStartElement( this.get_ElementName() );\n";
			str+="\t\t//Escribo los atributos del elemento\n";
			foreach(Atributo at in cp.atributos){
				if(!at.isSimpleType){
					if(at.tipo=="empty" && at.tipoEnCodigo=="bool"){
						str+="\t\tif(p_"+at.nombre+")writer.WriteAttributeString( \""+at.nombre+"\" , \"true\" );\n";
					}
					else{
						if(at.defaultValue!=null){
							str+="\t\tif(p_"+at.nombre+" != "+ParseDefaultValue_CS(at)+")\n";
						}
						else{
							str+="\t\tif(p_"+at.nombre+" != "+GetDefaultInitValue_CS(at)+")\n";
						}					
						str+="\t\t\twriter.WriteAttributeString( \""+at.nombre+"\" ,ZoeHelper .Att_ToString(p_"+at.nombre+") );\n";
					}
				}
				else{
					if(at.tipo=="empty" && at.tipoEnCodigo=="bool"){
						str+="\t\tif(p_"+at.nombre+")writer.WriteAttributeString( \""+at.nombre+"\" , \"true\" );\n";
					}
					else{
						if(at.defaultValue!=null){
							str+="\t\tif(p_"+at.nombre+" != "+ParseDefaultValue_CS(at)+")\n";
						}
						else{
							str+="\t\tif(p_"+at.nombre+" != "+GetDefaultInitValue_CS(at)+")\n";
						}
						str+="\t\t\twriter.WriteAttributeString( \""+at.nombre+"\" , CodeDOM_STV."+at.tipoEnCodigo.ToUpper()+"[(int)p_"+at.nombre+"] );\n";
						//str+="\t\t\twriter.write(\" "+at.nombre+"=\\\"\"+"+at.tipoEnCodigo.ToUpper()+"[p_"+at.nombre+"]+\"\\\"\");\n";
					}
				}
			}
			//str+="\t\twriter.write(\">\");\n";
			//Ahora proceso los elementos para que se escriban dentro recursivamente
			str+="\t\t//Escribo recursivamente cada elemento hijo\n";
			if(cp.secuencia.Count>0){
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					str+="\t\tif(p_Children!=null)if(!p_Children.Write(writer))result=false;\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								str+="\t\tif(p_"+el.nombreEnCodigo+"!=null)if(!p_"+el.nombreEnCodigo+".Write(writer))result=false;\n";
							}
							else{
								str+="\t\tif(p_"+el.nombreEnCodigo+"!=null)if(!p_"+el.nombreEnCodigo+".Write(writer))result=false;\n";
							}
						}
						else{ //Es tipo simple
							str+="\t\tif(p_"+el.nombreEnCodigo+"!=null)if(!p_"+el.nombreEnCodigo+".Write(writer))result=false;\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				//Primero compruebo si es un choice ordenada o de coleccion
				if(cp.choiceBounded){
					MessageBox.Show("ERROR: Choice Unbounded. "+cp.nombre+".");
				}
				else{
					if(cp.claseBaseChoice!=null){
                        str += "\t\tif(p_choiceContent!=null)if(!p_choiceContent.Write(writer))result=false;\n";
					}
					else{
                        str += "\t\tif(p_choiceContent!=null)if(!p_choiceContent.Write(writer))result=false;\n";
					}
				}
			}
			//Fin recursividad de elementos
			str+="\t\t//Cierro el elemento\n";
			str+="\t\twriter.WriteEndElement();\n";
			str+="\t\treturn result;\n";
			str+="\t}\n\n";
			#endregion
			#region Read
			str+="\tpublic override XplNode Read(XplReader reader){\n";
			str+="\t\tthis.set_ElementName( reader.Name );\n";
			#region lectura de atributos
			str+="\t\t//Lectura de Atributos\n";
			str+="\t\tif( reader.HasAttributes ){\n";
			foreach(Atributo at in cp.atributos){
				if(at.isSimpleType){
					str+="\t\t\tstring tmpStr=\"\";bool flag=false;int count=0;\n";
					break;
				}
			}
			str+="\t\t\tfor(int i=0; i < reader.AttributeCount ; i++){\n";
			str+="\t\t\t\treader.MoveToAttribute(i);\n";
			str+="\t\t\t\tswitch(reader.Name){\n";

			foreach(Atributo at in cp.atributos){
				str+="\t\t\t\t\tcase \""+at.nombre+"\":\n";
				if(!at.isSimpleType){
					str+="\t\t\t\t\t\tthis.set_"+at.nombre+"(ZoeHelper .StringAtt_To_"+at.tipoEnCodigo.ToUpper()+"(reader.Value));\n";
				}
				else{
					str+="\t\t\t\t\t\ttmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);\n";
					str+="\t\t\t\t\t\tcount=0;flag=false;\n";
					str+="\t\t\t\t\t\tforeach(string str in CodeDOM_STV."+at.tipoEnCodigo.ToUpper()+"){\n";
					str+="\t\t\t\t\t\t\tif(str==tmpStr){this.set_"+at.nombre+"(("+at.tipoEnCodigo+")count);flag=true;break;}\n";
					str+="\t\t\t\t\t\t\tcount++;\n";
					str+="\t\t\t\t\t\t}\n";
					str+="\t\t\t\t\t\tif(!flag)throw new CodeDOM_Exception(\"Linea: \"+reader.LineNumber+\".Valor invalido del atributo '"+at.nombre+"' en elemento '\"+this.get_ElementName()+\"'.\");\n";
				}
				str+="\t\t\t\t\t\tbreak;\n";
			}

			str+="\t\t\t\t\tdefault:\n";
			str+="\t\t\t\t\t\tthrow new CodeDOM_Exception(\"Linea: \"+reader.LineNumber+\".Atributo '\"+reader.Name+\"' invalido en elemento '\"+this.get_ElementName()+\"'.\");\n";
			str+="\t\t\t\t}\n"; //final switch
			str+="\t\t\t}\n"; //final for reader.AttributeCount
			str+="\t\t\treader.MoveToElement();\n";
			str+="\t\t}\n"; //final HasAttributes
			#endregion
			str+="\t\t//Lectura de Elementos\n";
			#region lectura de elementos
			if(cp.secuencia.Count>0){
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					#region lectura de secuencia ordenada
					//Secuencia de Coleccion
					str+="\t\tp_Children.Clear(); //Borro todo posible hijo en memoria\n";
					str+="\t\tif(!reader.IsEmptyElement){\n";
					str+="\t\treader.Read();\n";
					str+="\t\twhile(reader.NodeType!=XmlNodeType.EndElement){\n";
					str+="\t\t\tXplNode tempNode=null;\n";
					str+="\t\t\tswitch(reader.NodeType){\n";
					str+="\t\t\t\tcase XmlNodeType.Element:\n";
					str+="\t\t\t\t\tswitch(reader.Name){\n";
					foreach(Elemento el in cp.secuencia){
						str+="\t\t\t\t\tcase \""+el.nombre+"\":\n";
						if(el.isComplexType)
							str+="\t\t\t\t\t\ttempNode = new "+el.tipoEnCodigo+"();\n";
						else
							str+="\t\t\t\t\t\ttempNode = new XplNode("+GetBasicNodeType(el)+");\n";						
						str+="\t\t\t\t\t\ttempNode.Read(reader);\n";
						str+="\t\t\t\t\t\tp_Children.InsertAtEnd(tempNode);\n";
						str+="\t\t\t\t\t\tbreak;\n";
					}
					str+="\t\t\t\t\tdefault:\n";
					str+="\t\t\t\t\t\tthrow new CodeDOM_Exception(\"Linea: \"+reader.LineNumber+\".Nombre de nodo '\"+reader.Name+\"' inesperado como hijo de elemento '\"+this.get_ElementName()+\"'.\");\n";
					str+="\t\t\t\t\t}\n";
					str+="\t\t\t\t\tbreak;\n";
					str+="\t\t\t\tcase XmlNodeType.EndElement:\n";
					str+="\t\t\t\t\tbreak;\n";
					str+="\t\t\t\tcase XmlNodeType.Text:\n";
					str+="\t\t\t\t\tthrow new CodeDOM_Exception(\"Linea: \"+reader.LineNumber+\".No se esperaba texto en este nodo.\");\n";
					str+="\t\t\t\tdefault:\n";
					str+="\t\t\t\t\tbreak;\n";
					str+="\t\t\t}\n";//end switch node type
					str+="\t\t\treader.Read();\n";
					str+="\t\t}\n"; //End while
					str+="\t\t}\n"; //End If IsEmptyNode
					#endregion
				}
				else{
					#region lectura de secuencia no lista
					str+="\t\t//Borro todo posible nodo en memoria\n";
					foreach(Elemento el in cp.secuencia){
						if(!el.isComplexType || (el.isComplexType && !(el.requiereOrden||el.unbounded) ) )
						str+="\t\tthis.p_"+el.nombreEnCodigo+"=null;\n";
					}
					str+="\t\tif(!reader.IsEmptyElement){\n";
					str+="\t\treader.Read();\n";
					str+="\t\twhile(reader.NodeType!=XmlNodeType.EndElement){\n";
					str+="\t\t\tXplNode tempNode=null;\n";
					str+="\t\t\tswitch(reader.NodeType){\n";
					str+="\t\t\t\tcase XmlNodeType.Element:\n";
					str+="\t\t\t\t\tswitch(reader.Name){\n";
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						str+="\t\t\t\t\tcase \""+el.nombre+"\":\n";
						if(el.isComplexType)
							str+="\t\t\t\t\t\ttempNode = new "+el.tipoEnCodigo+"();\n";
						else
							str+="\t\t\t\t\t\ttempNode = new XplNode("+GetBasicNodeType(el)+");\n";						
						str+="\t\t\t\t\t\ttempNode.Read(reader);\n";
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								str+="\t\t\t\t\t\tthis.get_"+el.nombreEnCodigo+"().InsertAtEnd(tempNode);\n";
							}
							else{
								str+="\t\t\t\t\t\tif(this.get_"+el.nombreEnCodigo+"()!=null)throw new CodeDOM_Exception(\"Linea: \"+reader.LineNumber+\".Nodo '\"+reader.Name+\"' repetido como hijo de elemento '\"+this.get_ElementName()+\"'.\");\n";
								str+="\t\t\t\t\t\tthis.set_"+el.nombreEnCodigo+"(("+el.tipoEnCodigo+")tempNode);\n";
							}
						}
						else{
							str+="\t\t\t\t\t\tif(this.get_"+el.nombreEnCodigo+"()!=null)throw new CodeDOM_Exception(\"Linea: \"+reader.LineNumber+\".Nodo '\"+reader.Name+\"' repetido como hijo de elemento '\"+this.get_ElementName()+\"'.\");\n";
							str+="\t\t\t\t\t\tthis.set_"+el.nombreEnCodigo+"(tempNode);\n";						
						}
						str+="\t\t\t\t\t\tbreak;\n";
					}
					str+="\t\t\t\t\tdefault:\n";
					str+="\t\t\t\t\t\tthrow new CodeDOM_Exception(\"Linea: \"+reader.LineNumber+\".Nombre de nodo '\"+reader.Name+\"' inesperado como hijo de elemento '\"+this.get_ElementName()+\"'.\");\n";
					str+="\t\t\t\t\t}\n";
					str+="\t\t\t\t\tbreak;\n";
					str+="\t\t\t\tcase XmlNodeType.EndElement:\n";
					str+="\t\t\t\t\tbreak;\n";
					str+="\t\t\t\tcase XmlNodeType.Text:\n";
					str+="\t\t\t\t\tthrow new CodeDOM_Exception(\"Linea: \"+reader.LineNumber+\".No se esperaba texto en este nodo.\");\n";
					str+="\t\t\t\tdefault:\n";
					str+="\t\t\t\t\tbreak;\n";
					str+="\t\t\t}\n";//end switch node type
					str+="\t\t\treader.Read();\n";
					str+="\t\t}\n"; //End while
					str+="\t\t}\n"; //End If IsEmptyNode
					#endregion
				}
			}
			if(cp.choice.Count>0){
				#region lectura de choice
				//Primero compruebo si es un choice ordenada o de coleccion
				if(cp.choiceBounded){
					MessageBox.Show("ERROR: Choice Unbounded. "+cp.nombre+".");
				}
				else{
                    str += "\t\tthis.p_choiceContent=null;\n";
					str+="\t\tif(!reader.IsEmptyElement){\n";
					str+="\t\treader.Read();\n";
					str+="\t\twhile(reader.NodeType!=XmlNodeType.EndElement){\n";
					str+="\t\t\tXplNode tempNode=null;\n";
					str+="\t\t\tswitch(reader.NodeType){\n";
					str+="\t\t\t\tcase XmlNodeType.Element:\n";
					str+="\t\t\t\t\tswitch(reader.Name){\n";
					//Secuencia no Coleccion
					foreach(Elemento el in cp.choice){
						str+="\t\t\t\t\tcase \""+el.nombre+"\":\n";
						if(el.isComplexType)
							str+="\t\t\t\t\t\ttempNode = new "+el.tipoEnCodigo+"();\n";
						else
							str+="\t\t\t\t\t\ttempNode = new XplNode("+GetBasicNodeType(el)+");\n";						
						str+="\t\t\t\t\t\ttempNode.Read(reader);\n";
						str+="\t\t\t\t\t\tbreak;\n";
					}
					str+="\t\t\t\t\tdefault:\n";
					str+="\t\t\t\t\t\tthrow new CodeDOM_Exception(\"Linea: \"+reader.LineNumber+\".Nombre de nodo '\"+reader.Name+\"' inesperado como hijo de elemento '\"+this.get_ElementName()+\"'.\");\n";
					str+="\t\t\t\t\t}\n";
					str+="\t\t\t\t\tbreak;\n";
					str+="\t\t\t\tcase XmlNodeType.EndElement:\n";
					str+="\t\t\t\t\tbreak;\n";
					str+="\t\t\t\tcase XmlNodeType.Text:\n";
					str+="\t\t\t\t\tthrow new CodeDOM_Exception(\"Linea: \"+reader.LineNumber+\".No se esperaba texto en este nodo.\");\n";
					str+="\t\t\t\tdefault:\n";
					str+="\t\t\t\t\tbreak;\n";
					str+="\t\t\t}\n";//end switch node type
                    str += "\t\t\tif(this.get_Content()!=null && tempNode!=null)throw new CodeDOM_Exception(\"Linea: \"+reader.LineNumber+\".Nodo '\"+reader.Name+\"' incorrecto como hijo de elemento '\"+this.get_ElementName()+\"'.\");\n";
					str+="\t\t\telse if(tempNode!=null)this.set_Content(tempNode);\n";
					str+="\t\t\treader.Read();\n";
					str+="\t\t}\n"; //End while
					str+="\t\t}\n"; //End If IsEmptyNode
				}
				#endregion
			}
			if(cp.secuencia.Count==0 && cp.choice.Count==0){
				//Si no posee elementos hijos debo leer hasta el fin del elemento
				str+="\t\tif(!reader.IsEmptyElement){\n";
				str+="\t\treader.Read();\n";
				str+="\t\twhile(reader.NodeType!=XmlNodeType.EndElement){\n";
				str+="\t\t\tXplNode tempNode=null;\n";
				str+="\t\t\tswitch(reader.NodeType){\n";
				str+="\t\t\t\tcase XmlNodeType.Element:\n";
				str+="\t\t\t\tcase XmlNodeType.Text:\n";
				str+="\t\t\t\t\tthrow new CodeDOM_Exception(\"Linea: \"+reader.LineNumber+\".No se esperaba texto o elemento hijo en este nodo.\");\n";
				str+="\t\t\t\tcase XmlNodeType.EndElement:\n";
				str+="\t\t\t\t\tbreak;\n";
				str+="\t\t\t\tdefault:\n";
				str+="\t\t\t\t\tbreak;\n";
				str+="\t\t\t}\n";//end switch node type
				str+="\t\t\treader.Read();\n";
				str+="\t\t}\n"; //End while
				str+="\t\t}\n"; //End if
			}
			#endregion

			str+="\t\treturn this;\n";
			str+="\t}\n";
			#endregion

            #region BinaryWrite
            str += "\tpublic override bool BinaryWrite(XplBinaryWriter writer){\n";
            str += "\t\tbool result=true;\n";
            str += "\t\t//Escribo el ID y el nombre del elemento\n";
            str += "\t\twriter.Write((int) "+cp.ID+" );\n";
            str += "\t\twriter.Write( this.get_ElementName() );\n";
            str += "\t\t//Escribo los atributos del elemento\n";
            foreach (Atributo at in cp.atributos)
            {
                if (!at.isSimpleType)
                {
                    switch (at.tipoEnCodigo)
                    {
                        case "DateTime":
                            str += "\t\twriter.Write( p_" + at.nombre + ".ToBinary() );\n";
                            break;
                        default:
                            str += "\t\twriter.Write( p_" + at.nombre + " );\n";
                            break;
                    }
                }
                else
                {
                    str += "\t\twriter.Write( (int)p_" + at.nombre + " );\n";
                }
            }
            //str+="\t\twriter.write(\">\");\n";
            //Ahora proceso los elementos para que se escriban dentro recursivamente
            str += "\t\t//Escribo recursivamente cada elemento hijo\n";
            if (cp.secuencia.Count > 0)
            {
                if (cp.secuenciaBounded || cp.secuenciaOrdenada)
                {
                    //Secuencia de Coleccion
                    str += "\t\tif(!p_Children.BinaryWrite(writer))result=false;\n";
                }
                else
                {
                    //Secuencia no Coleccion
                    foreach (Elemento el in cp.secuencia)
                    {
                        str += "\t\tif(p_" + el.nombreEnCodigo + "!=null){\n\t\t\twriter.Write((int)1);\n\t\t\tif(!p_" + el.nombreEnCodigo + ".BinaryWrite(writer))result=false;\n\t\t}\n\t\telse {\n\t\t\twriter.Write((int)0);\n\t\t}\n";
                    }
                }
            }
            if (cp.choice.Count > 0)
            {
                //Primero compruebo si es un choice ordenada o de coleccion
                if (cp.choiceBounded)
                {
                    MessageBox.Show("ERROR: Choice Unbounded. " + cp.nombre + ".");
                }
                else
                {
                    if (cp.claseBaseChoice != null)
                    {
                        str += "\t\tif(p_choiceContent!=null){\n\t\t\twriter.Write((int)1);\n\t\t\tif(!p_choiceContent.BinaryWrite(writer))result=false;\n\t\t}\n\t\telse {\n\t\t\twriter.Write((int)0);\n\t\t}\n";
                    }
                    else
                    {
                        str += "\t\tif(p_choiceContent!=null){\n\t\t\twriter.Write((int)1);\n\t\t\tif(!p_choiceContent.BinaryWrite(writer))result=false;\n\t\t}\n\t\telse {\n\t\t\twriter.Write((int)0);\n\t\t}\n";
                    }
                }
            }
            //Fin recursividad de elementos
            //str += "\t\t//Cierro el elemento\n";
            //str += "\t\twriter.WriteEndElement();\n";
            str += "\t\treturn result;\n";
            str += "\t}\n\n";
            #endregion
            #region BinaryRead
            str += "\tpublic override XplNode BinaryRead(XplBinaryReader reader){\n";
            str += "\t\tthis.set_ElementName( reader.ReadString() );\n";
            #region lectura de atributos
            str += "\t\t//Lectura de Atributos\n";
            foreach (Atributo at in cp.atributos)
            {
                if (!at.isSimpleType)
                {
                    switch (at.tipoEnCodigo)
                    {
                        case "DateTime":
                            str += "\t\tp_" + at.nombre + " = DateTime.FromBinary(reader.ReadInt64());\n";
                            break;
                        case "bool":
                            str += "\t\tp_" + at.nombre + " = reader.ReadBoolean();\n";
                            break;
                        case "int":
                            str += "\t\tp_" + at.nombre + " = reader.ReadInt32();\n";
                            break;
                        case "uint":
                            str += "\t\tp_" + at.nombre + " = reader.ReadUInt32();\n";
                            break;
                        case "long":
                            str += "\t\tp_" + at.nombre + " = reader.ReadInt64();\n";
                            break;
                        case "string":
                            str += "\t\tp_" + at.nombre + " = reader.ReadString();\n";
                            break;
                        default:
                            str += "\t\tp_" + at.nombre + " = reader.ReadString();\n";
                            break;
                    }
                }
                else
                {
                    str += "\t\tp_"+at.nombre+" = ("+at.tipoEnCodigo+")reader.ReadInt32();\n";
                }
            }
            #endregion

            str += "\t\t//Lectura de Elementos\n";
            //str += "\t\tint ex = 0;\n";
            #region lectura de elementos
            if (cp.secuencia.Count > 0)
            {
                if (cp.secuenciaBounded || cp.secuenciaOrdenada)
                {
                    //Secuencia de Coleccion
                    str += "\t\tp_Children.BinaryRead(reader);\n";
                }
                else
                {
                    //Secuencia no Coleccion
                    foreach (Elemento el in cp.secuencia)
                    {
                        if (el.isComplexType)
                        {
                            if (el.requiereOrden || el.unbounded)
                            {
                                str += "\t\tif(reader.ReadInt32()==1){\n\t\t\tp_" + el.nombreEnCodigo + ".BinaryRead(reader);\n\t\t}\n";
                            }
                            else
                            {
                                str += "\t\tif(reader.ReadInt32()==1){\n\t\t\tp_" + el.nombreEnCodigo + " = ("+el.tipoEnCodigo+")CDOM_BinaryNodeReader.Read(reader, this.get_Parent());\n\t\t}\n";
                            }
                        }
                        else
                        { //Es tipo simple
                            str += "\t\tif(reader.ReadInt32()==1){\n\t\t\tp_" + el.nombreEnCodigo + " = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());\n\t\t}\n";
                        }
                    }
                }
            }
            if (cp.choice.Count > 0)
            {
                //Primero compruebo si es un choice ordenada o de coleccion
                if (cp.choiceBounded)
                {
                    MessageBox.Show("ERROR: Choice Unbounded. " + cp.nombre + ".");
                }
                else
                {
                    str += "\t\tif(reader.ReadInt32()==1){\n\t\t\tp_choiceContent = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());\n\t\t}\n";
                }
            }
            #endregion

            str += "\t\treturn this;\n";
            str += "\t}\n";
            #endregion

            str+="/// <summary>\n" +
            "/// Adds arg2 node to the end of the Children collection of arg1 node.\n" +
            "/// </summary>\n" +
            "/// <param name=\"arg1\">Node to which arg2 will be added as children.</param>\n" +
            "/// <param name=\"arg2\">Node to add to arg1 as children.</param>\n" +
            "/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>\n" +
            "public static " + cp.tipoEnCodigo + " operator +(" + cp.tipoEnCodigo + " arg1, XplNode arg2)\n" +
            "{\n" +
            "    if (arg1.Children() != null)\n" +
            "        arg1.Children().InsertAtEnd(arg2);\n" +
            "    else\n" +
            "        throw new CodeDOM_Exception(\"Node doesn't has children. Node can't be added.\");\n" +
            "    return arg1;\n" +
            "}\n" +

            "/// <summary>\n" +
            "/// Adds arg2 nodes to the end of the Children collection of arg1 node.\n" +
            "/// </summary>\n" +
            "/// <param name=\"arg1\">Node to which arg2 will be added as children.</param>\n" +
            "/// <param name=\"arg2\">Nodes to add to arg1 as children.</param>\n" +
            "/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>\n" +
            "public static " + cp.tipoEnCodigo + " operator +(" + cp.tipoEnCodigo + " arg1, XplNodeList arg2)\n" +
            "{\n" +
            "    if (arg1.Children() != null)\n" +
            "        arg1.Children().InsertAtEnd(arg2);\n" +
            "    else\n" +
            "        throw new CodeDOM_Exception(\"Node doesn't has children. Node can't be added.\");\n" +
            "    return arg1;\n" +
            "}\n";

			str+="\t#endregion\n\n";
			#endregion
			//Funciones miembro para obtener propiedades
			#region Funciones Get
			str+="\t#region Funciones para obtener Atributos y Elementos\n";
			foreach(Atributo at in cp.atributos){
				if(EsAtributoEspecial(at))
                   str+="\tpublic override "+at.tipoEnCodigo+" get_"+at.nombre+"(){\n";
                else
                   str += "\tpublic " + at.tipoEnCodigo + " get_" + at.nombre + "(){\n";
               str += "\t\treturn p_" + at.nombre + ";\n";
				str+="\t}\n";
			}
			if(cp.secuencia.Count>0){
				str+="\t//Funciones para obtener Elementos de Secuencia\n";
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					str+="\tpublic override XplNodeList Children(){\n";
					str+="\t\treturn p_Children;\n";
					str+="\t}\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								str+="\tpublic XplNodeList get_"+el.nombreEnCodigo+"(){\n";
								str+="\t\treturn p_"+el.nombreEnCodigo+";\n";
								str+="\t}\n";
							}
							else{
								//pointer="*";
								str+="\tpublic "+el.tipoEnCodigo+pointer+" get_"+el.nombreEnCodigo+"(){\n";
								str+="\t\treturn p_"+el.nombreEnCodigo+";\n";
								str+="\t}\n";
							}
						}
						else{ //Es tipo simple
							str+="\tpublic XplNode get_"+el.nombreEnCodigo+"(){\n";
							str+="\t\treturn p_"+el.nombreEnCodigo+";\n";
							str+="\t}\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				str+="\n\t//Funciones para obtener Elementos de Choice\n";
				//Primero compruebo si es un choice ordenada o de coleccion
				if(cp.choiceBounded){
					MessageBox.Show("ERROR: Choice Unbounded. "+cp.nombre+".");
				}
				else{
					if(cp.claseBaseChoice!=null){
						str+="\tpublic override "+cp.claseBaseChoice+" get_Content(){\n";
                        str += "\t\treturn p_choiceContent;\n";
						str+="\t}\n";
					}
					else{
						str+="\tpublic override XplNode get_Content(){\n";
                        str += "\t\treturn p_choiceContent;\n";
						str+="\t}\n";
					}
				}
			}
			str+="\t#endregion\n\n";
			#endregion
            //Funcion para obtener Todos los Elementos            
            #region Funciones ChildNodes()
            str += "\t#region Funcion ChildNodes() y Attributes()\n";

            str += "\tpublic override string[] Attributes(){\n";
            str += "\t\tstring[] ret = new string[" + cp.atributos.Count + "];\n";
            int n = 0;
            foreach (Atributo at in cp.atributos)
            {
                str += "\t\tret[" + n + "] = \"" + at.nombre + "\";\n";
                n++;
            }
            str += "\t\treturn ret;\n";
            str += "\t}\n";

            str += "\tpublic override string AttributeValue(string attributeName){\n";
            foreach (Atributo at in cp.atributos)
            {
                str += "\t\tif (attributeName==\"" + at.nombre + "\") return p_" + at.nombre + ".ToString();\n";
                n++;
            }
            str += "\t\treturn null;\n";
            str += "\t}\n";


            str += "\tpublic override XplNodeList ChildNodes(){\n";
            str += "\t\tXplNodeList list = new XplNodeList();\n";
            if (cp.secuencia.Count > 0)
            {
                //Primero compruebo si es una secuencia ordenada o de coleccion
                if (cp.secuenciaBounded || cp.secuenciaOrdenada)
                {
                    //Secuencia de Coleccion
                    str += "\t\tfor(XplNode node=p_Children.FirstNode();node!=null;node=p_Children.NextNode())\n";
                    str += "\t\t\tlist.InsertAtEnd(node);\n";
                }
                else
                {
                    //Secuencia no Coleccion
                    foreach (Elemento el in cp.secuencia)
                    {
                        if (el.isComplexType)
                        {
                            if (el.requiereOrden || el.unbounded)
                            {
                                str += "\t\tfor(XplNode node=p_" + el.nombreEnCodigo + ".FirstNode();node!=null;node=p_" + el.nombreEnCodigo + ".NextNode())\n";
                                str += "\t\t\tlist.InsertAtEnd(node);\n";
                            }
                            else
                            {
                                str += "\t\tlist.InsertAtEnd(p_" + el.nombreEnCodigo + ");\n";
                            }
                        }
                        else
                        { //Es tipo simple
                            str += "\t\tlist.InsertAtEnd(p_" + el.nombreEnCodigo + ");\n";
                        }
                    }
                }
            }
            if (cp.choice.Count > 0)
            {
                //Primero compruebo si es un choice ordenada o de coleccion
                if (cp.choiceBounded)
                {
                    MessageBox.Show("ERROR: Choice Unbounded. " + cp.nombre + ".");
                }
                else
                {
                    if (cp.claseBaseChoice != null)
                    {
                        str += "\t\tlist.InsertAtEnd(p_choiceContent);\n";
                    }
                    else
                    {
                        str += "\t\tlist.InsertAtEnd(p_choiceContent);\n";
                    }
                }
            }
            str += "\t\treturn list;\n";
            str += "\t}\n";
            str += "\t#endregion\n\n";
            #endregion
            //Funciones miembro para setear propiedades
			#region Funciones Set
			str+="\t#region Funciones para setear Atributos y Elementos\n";
			foreach(Atributo at in cp.atributos){
                if(EsAtributoEspecial(at))
				    str+="\tpublic override "+at.tipoEnCodigo+" set_"+at.nombre+"("+at.tipoEnCodigo+" new_"+at.nombre+"){\n";
                else
                    str += "\tpublic " + at.tipoEnCodigo + " set_" + at.nombre + "(" + at.tipoEnCodigo + " new_" + at.nombre + "){\n";
                str += "\t\t" + at.tipoEnCodigo + " back_" + at.nombre + " = p_" + at.nombre + ";\n";
				str+="\t\tp_"+at.nombre+" = new_"+at.nombre+";\n";
				str+="\t\treturn back_"+at.nombre+";\n";
				str+="\t}\n";
			}
			if(cp.secuencia.Count>0){
				str+="\n\t//Funciones para setear Elementos de Secuencia\n";
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					str+="\tprotected bool acceptInsertNodeCallback_"+cp.nombre+"(XplNode node, ref string errorMsg, XplNode parent){\n";
					str+="\t\tif(node==null)return false;\n";
					foreach(Elemento el in cp.secuencia){
						str+="\t\tif(node.get_ElementName()==\""+el.nombre+"\"){\n";
						str+="\t\t\tif(node.get_ContentTypeName()!=CodeDOMTypes."+ GetCodeDOMType(el.tipoEnCodigo)+"){\n";
						str+="\t\t\t\terrorMsg = \"El elemento de tipo '\"+node.get_ContentTypeNameString()+\"' no es valido como componente de '"+cp.tipoEnCodigo+"'.\";\n";
						str+="\t\t\t\treturn false;\n";
						str+="\t\t\t}\n";
						str+="\t\t\tnode.set_Parent(parent);\n";
						str+="\t\t\treturn true;\n";
						str+="\t\t}\n";
					}
					str+="\t\terrorMsg = \"El elemento de nombre '\"+node.get_ElementName()+\"' no es valido como componente de '"+cp.tipoEnCodigo+"'.\";\n";
					str+="\t\treturn false;\n";
					str+="\t}\n";
					str+="\tprotected bool acceptRemoveNodeCallback_"+cp.nombre+"(XplNode node, ref string errorMsg, XplNode parent){\n";
					str+="\t\treturn true;\n";
					str+="\t}\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								str+="\tprotected bool acceptInsertNodeCallback_"+el.nombreEnCodigo+"(XplNode node, ref string errorMsg, XplNode parent){\n";
								str+="\t\tif(node==null)return false;\n";
								str+="\t\tif(node.get_ElementName()==\""+el.nombre+"\"){\n";
								str+="\t\t\tif(node.get_ContentTypeName()!=CodeDOMTypes."+ GetCodeDOMType(el.tipoEnCodigo)+"){\n";
								str+="\t\t\t\terrorMsg = \"El elemento de tipo '\"+node.get_ContentTypeNameString()+\"' no es valido como componente de '"+el.tipoEnCodigo+"'.\";\n";
								str+="\t\t\t\treturn false;\n";
								str+="\t\t\t}\n";
								str+="\t\t\tnode.set_Parent(parent);\n";
								str+="\t\t\treturn true;\n";
								str+="\t\t}\n";
								str+="\t\terrorMsg = \"El elemento de nombre '\"+node.get_ElementName()+\"' no es valido como componente de '"+el.tipoEnCodigo+"'.\";\n";
								str+="\t\treturn false;\n";
								str+="\t}\n";
								str+="\tprotected bool acceptRemoveNodeCallback_"+el.nombreEnCodigo+"(XplNode node, ref string errorMsg, XplNode parent){\n";
								str+="\t\treturn true;\n";
								str+="\t}\n";
							}
							else{
								pointer="";
								str+="\tpublic "+el.tipoEnCodigo+pointer+" set_"+el.nombreEnCodigo+"("+el.tipoEnCodigo+" new_"+el.nombreEnCodigo+"){\n";
								str+="\t\t"+el.tipoEnCodigo+" back_"+el.nombreEnCodigo+" = p_"+el.nombreEnCodigo+";\n";
								str+="\t\tp_"+el.nombreEnCodigo+" = new_"+el.nombreEnCodigo+";\n";
								str+="\t\tif(p_"+el.nombreEnCodigo+"!=null){\n";
								str+="\t\t\tp_"+el.nombreEnCodigo+".set_ElementName(\""+el.nombre+"\");\n";
								str+="\t\t\tp_"+el.nombreEnCodigo+".set_Parent(this);\n";
								str+="\t\t}\n";
								str+="\t\treturn back_"+el.nombreEnCodigo+";\n";
								str+="\t}\n";
							}
						}
						else{ //Es tipo simple
							str+="\tpublic XplNode set_"+el.nombreEnCodigo+"(XplNode new_"+el.nombreEnCodigo+"){\n";
							str+="\t\tif(new_"+el.nombreEnCodigo+".get_ContentTypeName()!=CodeDOMTypes."+ GetCodeDOMType(el.tipoEnCodigo)+"){\n";
							str+="\t\t\tthis.set_ErrorString(\"El nodo que intenta asignar a la propiedad es de un tipo incorrecto.\");\n";
							str+="\t\t\treturn null;\n";
							str+="\t\t}\n";
							str+="\t\tXplNode back_"+el.nombreEnCodigo+" = p_"+el.nombreEnCodigo+";\n";
							str+="\t\tp_"+el.nombreEnCodigo+" = new_"+el.nombreEnCodigo+";\n";
							str+="\t\tif(p_"+el.nombreEnCodigo+"!=null){\n";
							str+="\t\t\tp_"+el.nombreEnCodigo+".set_Parent(this);\n";
							str+="\t\t\tp_"+el.nombreEnCodigo+".set_ElementName(\""+el.nombre+"\");\n";
							str+="\t\t}\n";
							str+="\t\treturn back_"+el.nombreEnCodigo+";\n";
							str+="\t}\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				str+="\n//Funciones para setear Elementos de Choice\n";
				//Primero compruebo si es un choice ordenada o de coleccion
				if(cp.choiceBounded){
					MessageBox.Show("ERROR: Choice Unbounded. "+cp.nombre+".");
				}
				else{
					if(cp.claseBaseChoice!=null){
						str+="\tpublic override "+cp.claseBaseChoice+" set_Content("+cp.claseBaseChoice+" new_"+cp.choiceName+"){\n";
                        str += "\t\tif(new_" + cp.choiceName + "==null)return p_choiceContent;\n";
                        str += "\t\t" + cp.claseBaseChoice + " back_" + cp.choiceName + " = p_choiceContent;\n";
						foreach(Elemento el in cp.choice){
							str+="\t\tif(new_"+cp.choiceName+".get_ElementName()==CodeDOMTypes."+el.nombre+"){\n";
							str+="\t\t\tif(new_"+cp.choiceName+".get_ContentTypeName()!=\""+el.tipoEnCodigo+"\"){\n";
							str+="\t\t\t\tthis.set_ErrorString(\"El elemento de tipo '\"+new_"+cp.choiceName+".get_ContentTypeNameString()+\"' no es valido como componente de '"+cp.choiceName+"'.\");\n";
							str+="\t\t\t\treturn null;\n";
							str+="\t\t\t}\n";
                            str += "\t\t\tp_choiceContent = new_" + cp.choiceName + ";\n";
                            str += "\t\t\tp_choiceContent.set_Parent(this);\n";
							str+="\t\t\treturn back_"+cp.choiceName+";\n";
							str+="\t\t}\n";
						}
						str+="\t\tthis.set_ErrorString(\"El elemento de nombre '\"+new_"+cp.choiceName+".get_ElementName()+\"' no es valido como componente de '"+cp.choiceName+"'.\");\n";
						str+="\t\treturn null;\n";
						str+="\t}\n";
					}
					else{
						str+="\tpublic override XplNode set_Content(XplNode new_"+cp.choiceName+"){\n";
                        str += "\t\tif(new_" + cp.choiceName + "==null)return p_choiceContent;\n";
                        str += "\t\tXplNode back_" + cp.choiceName + " = p_choiceContent;\n";
						foreach(Elemento el in cp.choice){
							str+="\t\tif(new_"+cp.choiceName+".get_ElementName()==\""+el.nombre+"\"){\n";
							str+="\t\t\tif(new_"+cp.choiceName+".get_ContentTypeName()!=CodeDOMTypes."+ GetCodeDOMType(el.tipoEnCodigo)+"){\n";
							str+="\t\t\t\tthis.set_ErrorString(\"El elemento de tipo '\"+new_"+cp.choiceName+".get_ContentTypeName()+\"' no es valido como componente de '"+cp.choiceName+"'.\");\n";
							str+="\t\t\t\treturn null;\n";
							str+="\t\t\t}\n";
                            str += "\t\t\tp_choiceContent = new_" + cp.choiceName + ";\n";
                            str += "\t\t\tp_choiceContent.set_Parent(this);\n";
							str+="\t\t\treturn back_"+cp.choiceName+";\n";
							str+="\t\t}\n";
						}
						str+="\t\tthis.set_ErrorString(\"El elemento de nombre '\"+new_"+cp.choiceName+".get_ElementName()+\"' no es valido como componente de '"+cp.choiceName+"'.\");\n";
						str+="\t\treturn null;\n";
						str+="\t}\n";
					}
				}
			}             
			str+="\t#endregion\n\n";
            
			#endregion
			//Otras Funciones Miembro Publicas
			#region Otras Funciones Miembro
			if(cp.secuencia.Count>0){
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					str+="\t#region Funciones para filtrado en Listas de Nodos\n";
					//Si la secuencia de coleccion
					foreach(Elemento el in cp.secuencia){
						str+="\tpublic XplNodeList get_"+el.nombreEnCodigo+"NodeList(){\n";
						str+="\t\tXplNodeList new_List = new XplNodeList();\n";
						str+="\t\tfor(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){\n";
						str+="\t\t\tif(node.get_ElementName()==\""+el.nombre+"\"){\n";
						str+="\t\t\t\tnew_List.InsertAtEnd(node);\n";
						str+="\t\t\t}\n";
						str+="\t\t}\n";
						str+="\t\treturn new_List;\n";
						str+="\t}\n";
					}
					str+="\t#endregion\n\n";
				}
				else{
					//Si la secuencia no es de coleccion
				}
			}
			str+="\t#region Funciones para obtener nuevos nodos hijos\n";
			//FUNCIONES PARA OBTENER NUEVOS NODOS HIJOS
			if(cp.secuencia.Count>0){
				//Secuencia no Coleccion
				foreach(Elemento el in cp.secuencia){
					if(el.isComplexType){
						str+="\tstatic public "+el.tipoEnCodigo+" new_"+el.nombreEnCodigo+"(){\n";
						str+="\t\t"+el.tipoEnCodigo+" node = new "+el.tipoEnCodigo+"();\n";
						str+="\t\tnode.set_ElementName(\""+el.nombre+"\");\n";
						str+="\t\treturn node;\n";
						str+="\t}\n";
					}
					else{ //Es tipo simple
						str+="\tstatic public XplNode new_"+el.nombreEnCodigo+"(){\n";
						str+="\t\tXplNode node = new XplNode("+GetBasicNodeType(el)+");\n";
						str+="\t\tnode.set_ElementName(\""+el.nombre+"\");\n";
						str+="\t\treturn node;\n";
						str+="\t}\n";
					}
				}
			}
			if(cp.choice.Count>0){
				foreach(Elemento el in cp.choice){
					if(el.isComplexType){
						str+="\tstatic public "+el.tipoEnCodigo+" new_"+el.nombreEnCodigo+"(){\n";
						str+="\t\t"+el.tipoEnCodigo+" node = new "+el.tipoEnCodigo+"();\n";
						str+="\t\tnode.set_ElementName(\""+el.nombre+"\");\n";
						str+="\t\treturn node;\n";
						str+="\t}\n";
					}
					else{ //Es tipo simple
						str+="\tstatic public XplNode new_"+el.nombreEnCodigo+"(){\n";
						str+="\t\tXplNode node = new XplNode("+GetBasicNodeType(el)+");\n";
						str+="\t\tnode.set_ElementName(\""+el.nombre+"\");\n";
						str+="\t\treturn node;\n";
						str+="\t}\n";
					}
				}
			}
			str+="\t#endregion\n\n";
			#endregion
			//Cierro la declaracion de la Clase
			str+="}\t//Fin declaración de Clase\n\n";
			//Finalmente Cierro el archivo
			sr.Write(str);
			MakeFoot_CS(cp.tipoEnCodigo);
			sr.Close();
		}

        private string GetCodeDOMType(string typeStr)
        {
            switch (typeStr)
            {
                case "string":
                    return "String";
                case "int":
                    return "Integer";
                case "uint":
                    return "Unsigned";
                case "bool":
                    return "Boolean";
            }
            return typeStr;
        }

        private bool EsAtributoEspecial(Atributo at)
        {
            switch (at.nombre)
            {
                case "doc":
                case "helpURL":
                case "ldsrc":
                case "iny":
                case "inydata":
                case "inyby":
                case "lddata":
                    return true;
            }
            return false;
        }
		#endregion

		#region Generar Predeclaraciones Header
		private void GeneratePreDeclHeader(){
			sf=new StreamWriter(outputPath+"CDOM_PreDecl.h");
			sf.WriteLine ("/*-------------------------------------------------");
			sf.WriteLine (" *");
			sf.WriteLine (" *	Este archivo fue generado automáticamente.");
			sf.WriteLine (" *	Fecha: " + System.DateTime.Now.ToString() );
			sf.WriteLine (" *");
			sf.WriteLine (" *	Generado por Zoe CodeDOM Generator.");
			sf.WriteLine (" *	COPYRIGHT 2002. por Alexis Ferreyra.");
			sf.WriteLine (" *");
			sf.WriteLine (" *------------------------------------------------*/");
			sf.WriteLine ("");
			sf.WriteLine ("#ifndef __LAYERD_CODEDOM_PREDECL_V1_0" );
			sf.WriteLine ("");
			sf.WriteLine ("namespace CodeDOM{");
			sf.WriteLine ("");
			
			sf.Write("class XplNode;\n");
			sf.Write("class XplNodeList;\n");
			foreach(ComplexType cp in ComplexTypes.Values){
				sf.Write("class "+cp.tipoEnCodigo+";\n");
			}

			sf.WriteLine ("");
			sf.WriteLine ("}");
			sf.WriteLine ("");
			sf.WriteLine ("#endif");
			sf.WriteLine ("#define __LAYERD_CODEDOM_PREDECL_V1_0");
			sf.WriteLine ("");
			sf.Close();
		}
		private void GenerateIncludeAll(){
			GenerateTree();
			MakeLevels();

			sf=new StreamWriter(outputPath+"CDOM_IncludeAll.h");
			sf.WriteLine ("/*-------------------------------------------------");
			sf.WriteLine (" *");
			sf.WriteLine (" *	Este archivo fue generado automáticamente.");
			sf.WriteLine (" *	Fecha: " + System.DateTime.Now.ToString() );
			sf.WriteLine (" *");
			sf.WriteLine (" *	Generado por Zoe CodeDOM Generator.");
			sf.WriteLine (" *	COPYRIGHT 2002. por Alexis Ferreyra.");
			sf.WriteLine (" *");
			sf.WriteLine (" *------------------------------------------------*/");
			sf.WriteLine ("");
			sf.WriteLine ("#ifndef __LAYERD_CODEDOM_INCLUDEALL_V1_0" );
			sf.WriteLine ("#define __LAYERD_CODEDOM_INCLUDEALL_V1_0");
			sf.WriteLine ("");
			//sf.WriteLine("#define __LAYERD_CODEDOM_HEADERSONLY");
			sf.WriteLine ("");
			sf.Write("#include \"CDOMBase.h\"\n");
			//sf.Write("#include \"CDOM_SimpleTypes.h\"\n");
			//sf.Write("#include \"CDOM_PreDecl.h\"\n");
			for(int n=maxLevel;n>=minLevel;n--){
				foreach(TreeNode tn in Tree.Values){
					if(tn.nivel==n)sf.Write("#include \"CDOM_"+ProcessTypeName(tn.name)+".h\"\n");
				}
			}
			sf.WriteLine ("");
			/*
			sf.WriteLine("#ifndef __LAYERD_CODEDOM_USING_LIBRARY");
			sf.WriteLine ("");
			for(int n=maxLevel;n>=minLevel;n--){
				foreach(TreeNode tn in Tree.Values){
					if(tn.nivel==n)sf.Write("#include \"CDOM_"+ProcessTypeName(tn.name)+".cpp\"\n");
				}
			}

			sf.WriteLine("");
			sf.WriteLine("#endif");
			*/
			sf.WriteLine ("");
			sf.WriteLine ("#endif");
			sf.WriteLine ("");
			sf.Close();
		}
		#endregion

		#region Generar Enums
		private void GenerarEnum(SimpleType sp,bool header){
			string str=null,str2=null;
			if(header){
				str+="\textern const DOM_CHARP __CODEDOM_"+sp.tipoEnCodigo.ToUpper()+"[];";
				str2+="\tenum "+sp.tipoEnCodigo+"{";
				foreach(string aux in sp.enumValues) {
					str2+=((string)(sp.tipoEnCodigo+"_"+aux)).ToUpper()+",";
				}
				str2=str2.Substring(0,str2.Length-1)+"};";
			}
			else{
				str+="\tconst DOM_CHARP __CODEDOM_"+sp.tipoEnCodigo.ToUpper()+"[]={";
				foreach(string aux in sp.enumValues) {
					str+="DT(\""+aux+"\"),";
				}
				str=str.Substring(0,str.Length-1)+"};";
			}
			sf.WriteLine(str);
			if(header)sf.WriteLine(str2);
		}
		#endregion

		#region GenerarHeaders y Makefile
		private void GenerarMakefile(){
			StreamWriter f;
			f=new StreamWriter(outputPath+"Makefile");
			string objs="CDOMBase.o CDOM_SimpleTypes.o ",
				sources="CDOMBase.cpp CDOM_SimpleTypes.cpp ",
				objsw="CDOMBase.obj CDOM_SimpleTypes.obj ";

			foreach(ComplexType cp in ComplexTypes.Values){
				objs+="CDOM_"+cp.tipoEnCodigo+".o ";
				objsw+="CDOM_"+cp.tipoEnCodigo+".obj ";
				sources+="CDOM_"+cp.tipoEnCodigo+".cpp ";
			}

			f.WriteLine("SOURCES:="+sources);
			f.WriteLine("OBJS:="+objs);
			f.WriteLine("OBJSWIN:="+objsw);
			f.Close();
		}

		private void GenerarHeader(ComplexType cp){
			string filename="CDOM_"+cp.tipoEnCodigo+".h",str="",pointer="";
			string auxStr;
			sr = File.CreateText(outputPath+filename);
			MakeHeaderHeader(cp.tipoEnCodigo);
			//Declaro la clase
			str+="class "+cp.tipoEnCodigo+": public "+((cp.claseBase==null)?" XplNode":cp.claseBase)+"{\n";
			//Si existe un tipo con secuencia y con choice es un error con el presente diseño en mente
			if(cp.secuencia.Count>0 && cp.choice.Count>0)
				MessageBox.Show("Tipo con Secuencia y Choice:"+cp.nombre,"¡ATENCIÓN!");
			//Miembros dato privados
			#region Miembos Dato Privados
			str+="private:\n\t//Variables para Atributos\n";
			foreach(Atributo at in cp.atributos){
				str+="\t"+at.tipoEnCodigo+pointer+" p_"+at.nombre+";\n";
			}
			if(cp.secuencia.Count>0){
				str+="\t//Variables para Elementos de Secuencia\n";
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					str+="\tXplNodeList* p_Childs;\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								str+="\tXplNodeList* p_"+el.nombreEnCodigo+";\n";
							}
							else{
								pointer="*";
								str+="\t"+el.tipoEnCodigo+pointer+" p_"+el.nombreEnCodigo+";\n";
							}
						}
						else{ //Es tipo simple
							str+="\tXplNode* p_"+el.nombreEnCodigo+";\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				str+="\n\t//Variables para Elementos de Choice\n";
				//Primero compruebo si es un choice ordenada o de coleccion
				if(cp.choiceBounded){
					MessageBox.Show("ERROR: Choice Unbounded. "+cp.nombre+".");
				}
				else{
					if(cp.claseBaseChoice!=null){
						str+="\t"+cp.claseBaseChoice+"* p_"+cp.choiceName+";\n";
					}
					else{
						str+="\tXplNode* p_"+cp.choiceName+";\n";
					}
				}
			}
			#endregion
			//Constructores
			#region Constructores
			string dec_atributos=null, dec_atributos_req=null, dec_elementos=null, dec_elementos_req=null, dec_choice=null;
			#region Armado de variables auxiliares
			foreach(Atributo at in cp.atributos){
				dec_atributos+=at.tipoEnCodigo+" n_"+at.nombre+", ";
				if(!at.optional || !at.optional && at.defaultValue!=null)dec_atributos_req+=at.tipoEnCodigo+" n_"+at.nombre+", ";
			}
			if(cp.secuencia.Count>0){
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					dec_elementos+="XplNodeList* n_Childs, ";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								dec_elementos+="XplNodeList* n_"+el.nombreEnCodigo+", ";
								if(!el.optional)
									dec_elementos_req+="XplNodeList* n_"+el.nombreEnCodigo+", ";
							}
							else{
								pointer="*";
								dec_elementos+=el.tipoEnCodigo+pointer+" n_"+el.nombreEnCodigo+", ";
								if(!el.optional)
									dec_elementos_req+=el.tipoEnCodigo+pointer+" n_"+el.nombreEnCodigo+", ";
							}
						}
						else{ //Es tipo simple
							dec_elementos+="XplNode* n_"+el.nombreEnCodigo+", ";
							if(!el.optional)
								dec_elementos_req+="XplNode* n_"+el.nombreEnCodigo+", ";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				if(cp.claseBaseChoice!=null){
					dec_choice+=cp.claseBaseChoice+"* n_"+cp.choiceName+", ";
				}
				else{
					dec_choice+="XplNode* n_"+cp.choiceName+", ";
				}
			}
			#endregion
			str+="public:\n\t//Region de Constructores Publicos\n";
			str+="\t"+cp.tipoEnCodigo+"();\n";
			#region Todas las combinaciones de constructores
			if(dec_atributos_req==dec_atributos)dec_atributos=null;
			if(dec_elementos_req==dec_elementos)dec_elementos=null;
			if(dec_atributos_req!=null){
				auxStr=dec_atributos_req;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\t"+cp.tipoEnCodigo+"("+auxStr+");\n";
			}
			if(dec_elementos_req!=null){
				auxStr=dec_elementos_req;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\t"+cp.tipoEnCodigo+"("+auxStr+");\n";
			}
			if(dec_atributos_req!=null && dec_elementos_req!=null){
				auxStr=dec_atributos_req+dec_elementos_req;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\t"+cp.tipoEnCodigo+"("+auxStr+");\n";
			}
			if(dec_atributos!=null){
				auxStr=dec_atributos;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\t"+cp.tipoEnCodigo+"("+auxStr+");\n";
			}
			if(dec_elementos!=null){
				auxStr=dec_elementos;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\t"+cp.tipoEnCodigo+"("+auxStr+");\n";
			}
			if(dec_atributos!=null && dec_elementos_req!=null){
				auxStr=dec_atributos+dec_elementos_req;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\t"+cp.tipoEnCodigo+"("+auxStr+");\n";
			}
			if(dec_atributos_req!=null && dec_elementos!=null){
				auxStr=dec_atributos_req+dec_elementos;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\t"+cp.tipoEnCodigo+"("+auxStr+");\n";
			}
			if(dec_atributos!=null && dec_elementos!=null){
				auxStr=dec_atributos+dec_elementos;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\t"+cp.tipoEnCodigo+"("+auxStr+");\n";
			}
			if(dec_choice!=null){
				auxStr=dec_choice;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\t"+cp.tipoEnCodigo+"("+auxStr+");\n";
			}
			if(dec_atributos_req!=null && dec_choice!=null){
				auxStr=dec_atributos_req+dec_choice;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\t"+cp.tipoEnCodigo+"("+auxStr+");\n";
			}
			if(dec_atributos!=null && dec_choice!=null){
				auxStr=dec_atributos+dec_choice;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+="\t"+cp.tipoEnCodigo+"("+auxStr+");\n";
			}
			#endregion
			#endregion
			//Destructores
			#region Destructores
			str+="\t//Destructor\n\t~"+cp.tipoEnCodigo+"();\n";
			#endregion
			//Sobreescritura de miembros de XplNode (Save, Load, Attach)
			#region Sobreescritura de XplNode
			str+="public:\n\t//Funciones Sobreescritas de XplNode\n";
			str+="\tXplNode* Clone();\n";
			str+="\tint get_TypeName(){return CODEDOMTYPES_"+cp.tipoEnCodigo.ToUpper()+";}\n";
			str+="\tbool Write(XplWriter* writer);\n";
			str+="\tXplNode* Read(XplReader* reader);\n";
			#endregion
			//Funciones miembro para obtener propiedades
			#region Funciones Get
			str+="public:\n\t//Funciones para obtener Atributos\n";
			foreach(Atributo at in cp.atributos){
				str+="\t"+at.tipoEnCodigo+" get_"+at.nombre+"();\n";
			}
			if(cp.secuencia.Count>0){
				str+="\t//Funciones para obtener Elementos de Secuencia\n";
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					str+="\tXplNodeList* Childs();\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								str+="\tXplNodeList* get_"+el.nombreEnCodigo+"();\n";
							}
							else{
								pointer="*";
								str+="\t"+el.tipoEnCodigo+pointer+" get_"+el.nombreEnCodigo+"();\n";
							}
						}
						else{ //Es tipo simple
							str+="\tXplNode* get_"+el.nombreEnCodigo+"();\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				str+="\n\t//Funciones para obtener Elementos de Choice\n";
				//Primero compruebo si es un choice ordenada o de coleccion
				if(cp.choiceBounded){
					MessageBox.Show("ERROR: Choice Unbounded. "+cp.nombre+".");
				}
				else{
					if(cp.claseBaseChoice!=null){
						str+="\t"+cp.claseBaseChoice+"* get_"+cp.choiceName+"();\n";
					}
					else{
						str+="\tXplNode* get_"+cp.choiceName+"();\n";
					}
				}
			}
			#endregion
			//Funciones miembro para setear propiedades
			#region Funciones Set
			str+="public:\n\t//Funciones para setear Atributos\n";
			foreach(Atributo at in cp.atributos){
				str+="\t"+at.tipoEnCodigo+" set_"+at.nombre+"("+at.tipoEnCodigo+" new_"+at.nombre+");\n";
			}
			if(cp.secuencia.Count>0){
				str+="\t//Funciones para setear Elementos de Secuencia\n";
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					//No tengo que hacer nada, lo hace la lista, o bien declarar la funcion privada
					str+="protected:\n\tstatic bool acceptInsertNodeCallback_"+cp.nombre+"(XplNode* node, string* errorMsg, XplNode* parent);\n";
					str+="\tstatic bool acceptRemoveNodeCallback_"+cp.nombre+"(XplNode* node, string* errorMsg, XplNode* parent);\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								//No tengo que hacer nada, mas que declarar la funcion que controle los tipos
								str+="protected:\n\tstatic bool acceptInsertNodeCallback_"+el.nombreEnCodigo+"(XplNode* node, string* errorMsg, XplNode* parent);\n";
								str+="\tstatic bool acceptRemoveNodeCallback_"+el.nombreEnCodigo+"(XplNode* node, string* errorMsg, XplNode* parent);\n"+"public:\n";
							}
							else{
								pointer="*";
								str+="\t"+el.tipoEnCodigo+pointer+" set_"+el.nombreEnCodigo+"("+el.tipoEnCodigo+"* new_"+el.nombreEnCodigo+");\n";
							}
						}
						else{ //Es tipo simple
							str+="\tXplNode* set_"+el.nombreEnCodigo+"(XplNode* new_"+el.nombreEnCodigo+");\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				str+="\n\t//Funciones para setear Elementos de Choice\n";
				//Primero compruebo si es un choice ordenada o de coleccion
				if(cp.choiceBounded){
					MessageBox.Show("ERROR: Choice Unbounded. "+cp.nombre+".");
				}
				else{
					if(cp.claseBaseChoice!=null){
						str+="\t"+cp.claseBaseChoice+"* set_"+cp.choiceName+"("+cp.claseBaseChoice+"* new_"+cp.choiceName+");\n";
					}
					else{
						str+="\tXplNode* set_"+cp.choiceName+"(XplNode* new_"+cp.choiceName+");\n";
					}
				}
			}
			#endregion
			//Otras Funciones Miembro Publicas
			#region Otras Funciones Miembro
			if(cp.secuencia.Count>0){
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					str+="public:\n\t//Funciones para filtrado en Listas de Nodos\n";
					//Si la secuencia de coleccion
					foreach(Elemento el in cp.secuencia){
						str+="\tXplNodeList* get_"+el.nombreEnCodigo+"NodeList();\n";
					}
				}
				else{
					//Si la secuencia no es de coleccion
				}
			}
			//FUNCIONES PARA OBTENER NUEVOS NODOS HIJOS
			if(cp.secuencia.Count>0){
				//Secuencia no Coleccion
				foreach(Elemento el in cp.secuencia){
					if(el.isComplexType){
						str+="\tstatic "+el.tipoEnCodigo+"* new_"+el.nombreEnCodigo+"();\n";
					}
					else{ //Es tipo simple
						str+="\tstatic XplNode* new_"+el.nombreEnCodigo+"();\n";
					}
				}
			}
			if(cp.choice.Count>0){
				foreach(Elemento el in cp.choice){
					if(el.isComplexType){
						str+="\tstatic "+el.tipoEnCodigo+"* new_"+el.nombreEnCodigo+"();\n";
					}
					else{ //Es tipo simple
						str+="\tstatic XplNode* new_"+el.nombreEnCodigo+"();\n";
					}
				}
			}
			#endregion
			//Cierro la declaracion de la Clase
			str+="};\t//Fin declaración de Clase\n\n";
			//Finalmente Cierro el archivo
			sr.Write(str);
			MakeFootHeader(cp.tipoEnCodigo);
			sr.Close();
		}
		#endregion

		#region GenerarBodys
		private void GenerarBody(ComplexType cp){
			string filename="CDOM_"+cp.tipoEnCodigo+".cpp",str="",pointer="";
			string auxStr;
			sr = File.CreateText(outputPath+filename);
			MakeHeaderBody(cp.tipoEnCodigo);
			//Si existe un tipo con secuencia y con choice es un error con el presente diseño en mente
			if(cp.secuencia.Count>0 && cp.choice.Count>0)
				MessageBox.Show("Tipo con Secuencia y Choice:"+cp.nombre,"¡ATENCIÓN!");
			//Constructores
			#region Constructores
			string dec_atributos=null, dec_atributos_req=null, dec_elementos=null, dec_elementos_req=null, dec_choice=null;
			string imp_atributos=null, imp_atributos_req=null, imp_elementos=null, imp_elementos_req=null, imp_choice=null,imp_atributos_def=null,imp_elementos_def=null;
			#region Armado de variables auxiliares decl
			foreach(Atributo at in cp.atributos){
				dec_atributos+=at.tipoEnCodigo+" n_"+at.nombre+", ";
				if(!at.optional || !at.optional && at.defaultValue!=null)dec_atributos_req+=at.tipoEnCodigo+" n_"+at.nombre+", ";
			}
			if(cp.secuencia.Count>0){
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					dec_elementos+="XplNodeList* n_Childs, ";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								dec_elementos+="XplNodeList* n_"+el.nombreEnCodigo+", ";
								if(!el.optional)
									dec_elementos_req+="XplNodeList* n_"+el.nombreEnCodigo+", ";
							}
							else{
								pointer="*";
								dec_elementos+=el.tipoEnCodigo+pointer+" n_"+el.nombreEnCodigo+", ";
								if(!el.optional)
									dec_elementos_req+=el.tipoEnCodigo+pointer+" n_"+el.nombreEnCodigo+", ";
							}
						}
						else{ //Es tipo simple
							dec_elementos+="XplNode* n_"+el.nombreEnCodigo+", ";
							if(!el.optional)
								dec_elementos_req+="XplNode* n_"+el.nombreEnCodigo+", ";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				if(cp.claseBaseChoice!=null){
					dec_choice+=cp.claseBaseChoice+"* n_"+cp.choiceName+", ";
				}
				else{
					dec_choice+="XplNode* n_"+cp.choiceName+", ";
				}
			}
			#endregion
			#region Armado de variables auxiliares impl
			foreach(Atributo at in cp.atributos){
				imp_atributos+="\tset_"+at.nombre+"(n_"+at.nombre+");\n";
				if(at.defaultValue!=null){
					imp_atributos_def+="\tp_"+at.nombre+" = "+ParseDefaultValue(at)+";\n";
				}
				else{
					imp_atributos_def+="\tp_"+at.nombre+" = "+GetDefaultInitValue(at)+";\n";
				}
				if(!at.optional || !at.optional && at.defaultValue!=null){
					imp_atributos_req+="\tset_"+at.nombre+"(n_"+at.nombre+");\n";
				}
			}
			if(cp.secuencia.Count>0){
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					imp_elementos_def+="\tp_Childs = new XplNodeList();\n";
					imp_elementos_def+="\tp_Childs->set_Parent(this);\n";
					imp_elementos_def+="\tp_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_"+cp.nombre+");\n";					
					imp_elementos_def+="\tp_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_"+cp.nombre+");\n";					
					imp_elementos+="#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS\n";
					imp_elementos+="\tif(n_Childs!=NULL)\n";
					imp_elementos+="\tfor(XplNode* node = n_Childs->FirstNode(); node != n_Childs->GetLastNode() ; node = n_Childs->NextNode()){\n";
					imp_elementos+="\t\tp_Childs->InsertAtEnd(node);\n";
					imp_elementos+="\t}\n";
					//Esto debe ser opcional
					imp_elementos+="#else\n";
					imp_elementos+="\tp_Childs = n_Childs;\n";
					imp_elementos+="#endif\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								imp_elementos_def+="\tp_"+el.nombreEnCodigo+" = new XplNodeList();\n";
								imp_elementos_def+="\tp_"+el.nombreEnCodigo+"->set_Parent(this);\n";
								imp_elementos_def+="\tp_"+el.nombreEnCodigo+"->set_InsertNodeCallback(&acceptInsertNodeCallback_"+el.nombreEnCodigo+");\n";					
								imp_elementos_def+="\tp_"+el.nombreEnCodigo+"->set_RemoveNodeCallback(&acceptRemoveNodeCallback_"+el.nombreEnCodigo+");\n";					
								imp_elementos+="#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS\n";
								imp_elementos+="\tif(n_"+el.nombreEnCodigo+"!=NULL)\n";
								imp_elementos+="\tfor(XplNode* node = n_"+el.nombreEnCodigo+"->FirstNode(); node != n_"+el.nombreEnCodigo+"->GetLastNode() ; node = n_"+el.nombreEnCodigo+"->NextNode()){\n";
								imp_elementos+="\t\tp_"+el.nombreEnCodigo+"->InsertAtEnd(node);\n";
								imp_elementos+="\t}\n";
								//Esto debe ser opcional
								imp_elementos+="#else\n";
								imp_elementos+="\tp_Childs = n_Childs;\n";
								imp_elementos+="#endif\n";
								if(!el.optional){
									imp_elementos_req+="#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS\n";
									imp_elementos_req+="\tif(n_"+el.nombreEnCodigo+"!=NULL)\n";
									imp_elementos_req+="\tfor(XplNode* node = n_"+el.nombreEnCodigo+"->FirstNode(); node != n_"+el.nombreEnCodigo+"->GetLastNode() ; node = n_"+el.nombreEnCodigo+"->NextNode()){\n";
									imp_elementos_req+="\t\tp_"+el.nombreEnCodigo+"->InsertAtEnd(node);\n";
									imp_elementos_req+="\t}\n";
									//Esto debe ser opcional
									imp_elementos_req+="#else\n";
									imp_elementos_req+="\tp_Childs = n_Childs;\n";
									imp_elementos_req+="#endif\n";
								}
							}
							else{
								imp_elementos_def+="\tp_"+el.nombreEnCodigo+"=NULL;\n";
								imp_elementos+="\tset_"+el.nombreEnCodigo+"(n_"+el.nombreEnCodigo+");\n";
								if(!el.optional)
									imp_elementos_req+="\tset_"+el.nombreEnCodigo+"(n_"+el.nombreEnCodigo+");\n";
							}
						}
						else{ //Es tipo simple
							imp_elementos_def+="\tp_"+el.nombreEnCodigo+"=NULL;\n";
							imp_elementos+="\tset_"+el.nombreEnCodigo+"(n_"+el.nombreEnCodigo+");\n";
							if(!el.optional)
								imp_elementos_req+="\tset_"+el.nombreEnCodigo+"(n_"+el.nombreEnCodigo+");\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				if(cp.claseBaseChoice!=null){
					imp_elementos_def+="\tp_"+cp.choiceName+"=NULL;\n";
					imp_choice+="\tset_"+cp.choiceName+"(n_"+cp.choiceName+");\n";
				}
				else{
					imp_elementos_def+="\tp_"+cp.choiceName+"=NULL;\n";
					imp_choice+="\tset_"+cp.choiceName+"(n_"+cp.choiceName+");\n";
				}
			}
			#endregion
			str+="//Region de Constructores Publicos\n";
			str+=cp.tipoEnCodigo+"::"+cp.tipoEnCodigo+"(){\n";
			str+=imp_atributos_def+imp_elementos_def;
			str+="}\n";
			#region Todas las combinaciones de constructores
			if(dec_atributos_req==dec_atributos)dec_atributos=null;
			if(dec_elementos_req==dec_elementos)dec_elementos=null;
			if(dec_atributos_req!=null){
				auxStr=dec_atributos_req;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+=cp.tipoEnCodigo+"::"+cp.tipoEnCodigo+"("+auxStr+"){\n";
				str+=imp_atributos_def+imp_atributos_req+imp_elementos_def;
				str+="}\n";
			}
			if(dec_elementos_req!=null){
				auxStr=dec_elementos_req;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+=cp.tipoEnCodigo+"::"+cp.tipoEnCodigo+"("+auxStr+"){\n";
				str+=imp_atributos_def+imp_elementos_def+imp_elementos_req;
				str+="}\n";
			}
			if(dec_atributos_req!=null && dec_elementos_req!=null){
				auxStr=dec_atributos_req+dec_elementos_req;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+=cp.tipoEnCodigo+"::"+cp.tipoEnCodigo+"("+auxStr+"){\n";
				str+=imp_atributos_def+imp_atributos_req+imp_elementos_def+imp_elementos_req;
				str+="}\n";
			}
			if(dec_atributos!=null){
				auxStr=dec_atributos;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+=cp.tipoEnCodigo+"::"+cp.tipoEnCodigo+"("+auxStr+"){\n";
				str+=imp_atributos+imp_elementos_def;
				str+="}\n";
			}
			if(dec_elementos!=null){
				auxStr=dec_elementos;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+=cp.tipoEnCodigo+"::"+cp.tipoEnCodigo+"("+auxStr+"){\n";
				str+=imp_atributos_def+imp_elementos_def+imp_elementos;
				str+="}\n";
			}
			if(dec_atributos!=null && dec_elementos_req!=null){
				auxStr=dec_atributos+dec_elementos_req;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+=cp.tipoEnCodigo+"::"+cp.tipoEnCodigo+"("+auxStr+"){\n";
				str+=imp_atributos+imp_atributos_req+imp_elementos_def;
				str+="}\n";
			}
			if(dec_atributos_req!=null && dec_elementos!=null){
				auxStr=dec_atributos_req+dec_elementos;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+=cp.tipoEnCodigo+"::"+cp.tipoEnCodigo+"("+auxStr+"){\n";
				str+=imp_atributos_def+imp_atributos_req+imp_elementos_def+imp_elementos;
				str+="}\n";
			}
			if(dec_atributos!=null && dec_elementos!=null){
				auxStr=dec_atributos+dec_elementos;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+=cp.tipoEnCodigo+"::"+cp.tipoEnCodigo+"("+auxStr+"){\n";
				str+=imp_atributos+imp_elementos_def+imp_elementos;
				str+="}\n";
			}
			if(dec_choice!=null){
				auxStr=dec_choice;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+=cp.tipoEnCodigo+"::"+cp.tipoEnCodigo+"("+auxStr+"){\n";
				str+=imp_atributos_def+imp_elementos_def+imp_choice;
				str+="}\n";
			}
			if(dec_atributos_req!=null && dec_choice!=null){
				auxStr=dec_atributos_req+dec_choice;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+=cp.tipoEnCodigo+"::"+cp.tipoEnCodigo+"("+auxStr+"){\n";
				str+=imp_atributos_def+imp_atributos_req+imp_elementos_def+imp_choice;
				str+="}\n";
			}
			if(dec_atributos!=null && dec_choice!=null){
				auxStr=dec_atributos+dec_choice;
				auxStr=auxStr.Substring(0,auxStr.Length-2);
				str+=cp.tipoEnCodigo+"::"+cp.tipoEnCodigo+"("+auxStr+"){\n";
				str+=imp_atributos+imp_elementos_def+imp_choice;
				str+="}\n";
			}
			#endregion
			#endregion
			//Destructores
			#region Destructores
			str+="//Destructor\n"+cp.tipoEnCodigo+"::~"+cp.tipoEnCodigo+"(){\n";
			str+="#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS\n";
			str+="\t__LAYERD_CODEDOM_DEBUG_OUTPUT(\"En el Destructor de '"+cp.tipoEnCodigo+"'\");\n";
			str+="#endif\n";
			if(cp.secuencia.Count>0){
				str+="\t//Variables para Elementos de Secuencia\n";
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					str+="\tif(p_Childs!=NULL)delete p_Childs;\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								str+="\tif(p_"+el.nombreEnCodigo+"!=NULL)delete p_"+el.nombreEnCodigo+";\n";
							}
							else{
								str+="\tif(p_"+el.nombreEnCodigo+"!=NULL)delete p_"+el.nombreEnCodigo+";\n";
							}
						}
						else{ //Es tipo simple
							str+="\tif(p_"+el.nombreEnCodigo+"!=NULL)delete p_"+el.nombreEnCodigo+";\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				str+="\n\t//Variables para Elementos de Choice\n";
				//Primero compruebo si es un choice ordenada o de coleccion
				if(cp.choiceBounded){
					MessageBox.Show("ERROR: Choice Unbounded. "+cp.nombre+".");
				}
				else{
					if(cp.claseBaseChoice!=null){
						str+="\tif(p_"+cp.choiceName+"!=NULL)delete p_"+cp.choiceName+";\n";
					}
					else{
						str+="\tif(p_"+cp.choiceName+"!=NULL)delete p_"+cp.choiceName+";\n";
					}
				}
			}			
			str+="}\n";
			#endregion
			//Sobreescritura de miembros de XplNode (Save, Load, Attach)
			#region Sobreescritura de XplNode
			str+="\n//Funciones Sobreescritas de XplNode\n";
			#region Clone
			str+="XplNode* "+cp.tipoEnCodigo+"::Clone(){\n";
			str+="\t"+cp.tipoEnCodigo+"* copy = new "+cp.tipoEnCodigo+"();\n";
			//Copio los atributos
			foreach(Atributo at in cp.atributos){
				str+="\tcopy->set_"+at.nombre+"(this->p_"+at.nombre+");\n";
			}
			//Copio los elementos
			if(cp.secuencia.Count>0){
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					str+="\tfor(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){\n";
					str+="\t\tcopy->Childs()->InsertAtEnd(node->Clone());\n";
					str+="\t}\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								str+="\tfor(XplNode* node = p_"+el.nombreEnCodigo+"->FirstNode(); node != NULL ; node = p_"+el.nombreEnCodigo+"->NextNode()){\n";
								str+="\t\tcopy->get_"+el.nombreEnCodigo+"()->InsertAtEnd(node->Clone());\n";
								str+="\t}\n";
							}
							else{
								str+="\tif(p_"+el.nombreEnCodigo+"!=NULL)copy->set_"+el.nombreEnCodigo+"(("+el.tipoEnCodigo+"*)p_"+el.nombreEnCodigo+"->Clone());\n";
							}
						}
						else{ //Es tipo simple
                            str += "\tif(p_" + el.nombreEnCodigo + "!=NULL)copy->set_" + el.nombreEnCodigo + "(p_" + el.nombreEnCodigo + "->Clone());\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				str+="\n\t//Variables para Elementos de Choice\n";
				//Primero compruebo si es un choice ordenada o de coleccion
				if(cp.choiceBounded){
					MessageBox.Show("ERROR: Choice Unbounded. "+cp.nombre+".");
				}
				else{
					if(cp.claseBaseChoice!=null){
                        str += "\tif(p_" + cp.choiceName + "!=NULL)copy->set_" + cp.choiceName + "(p_" + cp.choiceName + "->Clone());\n";
					}
					else{
                        str += "\tif(p_" + cp.choiceName + "!=NULL)copy->set_" + cp.choiceName + "(p_" + cp.choiceName + "->Clone());\n";
					}
				}
			}
			str+="\tcopy->set_ElementName(this->get_ElementName());\n";
			str+="\treturn (XplNode*)copy;\n";
			str+="}\n";
			#endregion
			#region Save
			str+="bool "+cp.tipoEnCodigo+"::Write(XplWriter* writer){\n";
			str+="\tbool result=true;\n";
			str+="\t//Escribo el encabezado del elemento\n";
			str+="\twriter->write(DT(\"<\")+this->get_ElementName());\n";
			str+="\t//Escribo los atributos del elemento\n";
			foreach(Atributo at in cp.atributos){
				if(!at.isSimpleType){
					if(at.tipo=="empty" && at.tipoEnCodigo=="bool"){
						str+="\tif(p_"+at.nombre+")writer->write(DT(\" "+at.nombre+"\"));\n";
					}
					else{
						if(at.defaultValue!=null){
							str+="\tif(p_"+at.nombre+" != "+ParseDefaultValue(at)+")\n";
						}
						else{
							str+="\tif(p_"+at.nombre+" != "+GetDefaultInitValue(at)+")\n";
						}					
						str+="\t\twriter->write(DT(\" "+at.nombre+"=\\\"\")+CODEDOM_Att_ToString(p_"+at.nombre+")+DT(\"\\\"\"));\n";
					}
				}
				else{
					if(at.tipo=="empty" && at.tipoEnCodigo=="bool"){
						str+="\tif(p_"+at.nombre+")writer->write(DT(\" "+at.nombre+"\"));\n";
					}
					else{
						if(at.defaultValue!=null){
							str+="\tif(p_"+at.nombre+" != "+ParseDefaultValue(at)+")\n";
						}
						else{
							str+="\tif(p_"+at.nombre+" != "+GetDefaultInitValue(at)+")\n";
						}
						str+="\t\twriter->write(DT(\" "+at.nombre+"=\\\"\")+(string)__CODEDOM_"+at.tipoEnCodigo.ToUpper()+"[p_"+at.nombre+"]+DT(\"\\\"\"));\n";
					}
				}
			}
			str+="\twriter->write(DT(\">\"));\n";
			//Ahora proceso los elementos para que se escriban dentro recursivamente
			str+="\t//Escribo recursivamente cada elemento hijo\n";
			if(cp.secuencia.Count>0){
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					str+="\tif(p_Childs!=NULL)if(!p_Childs->Write(writer))result=false;\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								str+="\tif(p_"+el.nombreEnCodigo+"!=NULL)if(!p_"+el.nombreEnCodigo+"->Write(writer))result=false;\n";
							}
							else{
								str+="\tif(p_"+el.nombreEnCodigo+"!=NULL)if(!p_"+el.nombreEnCodigo+"->Write(writer))result=false;\n";
							}
						}
						else{ //Es tipo simple
							str+="\tif(p_"+el.nombreEnCodigo+"!=NULL)if(!p_"+el.nombreEnCodigo+"->Write(writer))result=false;\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				//Primero compruebo si es un choice ordenada o de coleccion
				if(cp.choiceBounded){
					MessageBox.Show("ERROR: Choice Unbounded. "+cp.nombre+".");
				}
				else{
					if(cp.claseBaseChoice!=null){
						str+="\tif(p_"+cp.choiceName+"!=NULL)if(!p_"+cp.choiceName+"->Write(writer))result=false;\n";
					}
					else{
						str+="\tif(p_"+cp.choiceName+"!=NULL)if(!p_"+cp.choiceName+"->Write(writer))result=false;\n";
					}
				}
			}
			//Fin recursividad de elementos
			str+="\t//Cierro el elemento\n";
			str+="\twriter->write(DT(\"</\")+this->get_ElementName()+DT(\">\"));\n";
			str+="\treturn result;\n";
			str+="}\n";
			#endregion
			#region Load
			str+="XplNode* "+cp.tipoEnCodigo+"::Read(XplReader* reader){\n";
			str+="\tthrow new CodeDOM_NotImplementedException(DT(\"Read\"));\n";
			str+="}\n";
			#endregion
			#endregion
			//Funciones miembro para obtener propiedades
			#region Funciones Get
			str+="\n//Funciones para obtener Atributos\n";
			foreach(Atributo at in cp.atributos){
				str+=at.tipoEnCodigo+" "+cp.tipoEnCodigo+"::get_"+at.nombre+"(){\n";
				str+="\treturn p_"+at.nombre+";\n";
				str+="}\n";
			}
			if(cp.secuencia.Count>0){
				str+="\n//Funciones para obtener Elementos de Secuencia\n";
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					str+="XplNodeList* "+cp.tipoEnCodigo+"::Childs(){\n";
					str+="\treturn p_Childs;\n";
					str+="}\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								str+="XplNodeList* "+cp.tipoEnCodigo+"::get_"+el.nombreEnCodigo+"(){\n";
								str+="\treturn p_"+el.nombreEnCodigo+";\n";
								str+="}\n";
							}
							else{
								pointer="*";
								str+=el.tipoEnCodigo+pointer+" "+cp.tipoEnCodigo+"::get_"+el.nombreEnCodigo+"(){\n";
								str+="\treturn p_"+el.nombreEnCodigo+";\n";
								str+="}\n";
							}
						}
						else{ //Es tipo simple
							str+="XplNode* "+cp.tipoEnCodigo+"::get_"+el.nombreEnCodigo+"(){\n";
							str+="\treturn p_"+el.nombreEnCodigo+";\n";
							str+="}\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				str+="\n//Funciones para obtener Elementos de Choice\n";
				//Primero compruebo si es un choice ordenada o de coleccion
				if(cp.choiceBounded){
					MessageBox.Show("ERROR: Choice Unbounded. "+cp.nombre+".");
				}
				else{
					if(cp.claseBaseChoice!=null){
						str+=cp.claseBaseChoice+"* "+cp.tipoEnCodigo+"::get_"+cp.choiceName+"(){\n";
						str+="\treturn p_"+cp.choiceName+";\n";
						str+="}\n";
					}
					else{
						str+="XplNode* "+cp.tipoEnCodigo+"::get_"+cp.choiceName+"(){\n";
						str+="\treturn p_"+cp.choiceName+";\n";
						str+="}\n";
					}
				}
			}
			#endregion
			//Funciones miembro para setear propiedades
			#region Funciones Set
			str+="\n//Funciones para setear Atributos\n";
			foreach(Atributo at in cp.atributos){
				str+=at.tipoEnCodigo+" "+cp.tipoEnCodigo+"::set_"+at.nombre+"("+at.tipoEnCodigo+" new_"+at.nombre+"){\n";
				str+="\t"+at.tipoEnCodigo+" back_"+at.nombre+" = p_"+at.nombre+";\n";
				str+="\tp_"+at.nombre+" = new_"+at.nombre+";\n";
				str+="\treturn back_"+at.nombre+";\n";
				str+="}\n";
			}
			if(cp.secuencia.Count>0){
				str+="\n//Funciones para setear Elementos de Secuencia\n";
				//Primero compruebo si es una secuencia ordenada o de coleccion
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					//Secuencia de Coleccion
					str+="\tbool "+cp.tipoEnCodigo+"::acceptInsertNodeCallback_"+cp.nombre+"(XplNode* node, string* errorMsg, XplNode* parent){\n";
					str+="\t\tif(node==NULL)return false;\n";
					foreach(Elemento el in cp.secuencia){
						str+="\t\tif(node->get_ElementName()==DT(\""+el.nombre+"\")){\n";
						str+="\t\t\tif(node->get_ContentTypeName()!=CODEDOMTYPES_"+el.tipoEnCodigo.ToUpper()+"){\n";
						str+="\t\t\t\terrorMsg = new string(DT(\"El elemento de tipo '\")+node->get_ContentTypeNameString()+DT(\"' no es valido como componente de '"+cp.tipoEnCodigo+"'.\"));\n";
						str+="\t\t\t\treturn false;\n";
						str+="\t\t\t}\n";
						str+="\t\t\tnode->set_Parent(parent);\n";
						str+="\t\t\treturn true;\n";
						str+="\t\t}\n";
					}
					str+="\t\terrorMsg = new string(DT(\"El elemento de nombre '\")+node->get_ElementName()+DT(\"' no es valido como componente de '"+cp.tipoEnCodigo+"'.\"));\n";
					str+="\t\treturn false;\n";
					str+="\t}\n";
					str+="\tbool "+cp.tipoEnCodigo+"::acceptRemoveNodeCallback_"+cp.nombre+"(XplNode* node, string* errorMsg, XplNode* parent){\n";
					str+="\t\treturn true;\n";
					str+="\t}\n";
				}
				else{
					//Secuencia no Coleccion
					foreach(Elemento el in cp.secuencia){
						if(el.isComplexType){
							if(el.requiereOrden||el.unbounded){
								str+="\tbool "+cp.tipoEnCodigo+"::acceptInsertNodeCallback_"+el.nombreEnCodigo+"(XplNode* node, string* errorMsg, XplNode* parent){\n";
								str+="\t\tif(node==NULL)return false;\n";

								str+="\t\tif(node->get_ElementName()==DT(\""+el.nombre+"\")){\n";
								str+="\t\t\tif(node->get_ContentTypeName()!=CODEDOMTYPES_"+el.tipoEnCodigo.ToUpper()+"){\n";
								str+="\t\t\t\terrorMsg = new string(DT(\"El elemento de tipo '\")+node->get_ContentTypeNameString()+DT(\"' no es valido como componente de '"+el.tipoEnCodigo+"'.\"));\n";
								str+="\t\t\t\treturn false;\n";
								str+="\t\t\t}\n";
								str+="\t\t\tnode->set_Parent(parent);\n";
								str+="\t\t\treturn true;\n";
								str+="\t\t}\n";

								str+="\t\terrorMsg = new string(DT(\"El elemento de nombre '\")+node->get_ElementName()+DT(\"' no es valido como componente de '"+el.tipoEnCodigo+"'.\"));\n";
								str+="\t\treturn false;\n";
								str+="\t}\n";
								str+="\tbool "+cp.tipoEnCodigo+"::acceptRemoveNodeCallback_"+el.nombreEnCodigo+"(XplNode* node, string* errorMsg, XplNode* parent){\n";
								str+="\t\treturn true;\n";
								str+="\t}\n";
							}
							else{
								pointer="*";
								str+=el.tipoEnCodigo+pointer+" "+cp.tipoEnCodigo+"::set_"+el.nombreEnCodigo+"("+el.tipoEnCodigo+"* new_"+el.nombreEnCodigo+"){\n";
								str+="\t"+el.tipoEnCodigo+"* back_"+el.nombreEnCodigo+" = p_"+el.nombreEnCodigo+";\n";
								str+="\tp_"+el.nombreEnCodigo+" = new_"+el.nombreEnCodigo+";\n";
								str+="\tif(p_"+el.nombreEnCodigo+"!=NULL){\n";
								str+="\t\tp_"+el.nombreEnCodigo+"->set_ElementName(DT(\""+el.nombre+"\"));\n";
								str+="\t\tp_"+el.nombreEnCodigo+"->set_Parent(this);\n";
								str+="\t}\n";
								str+="\treturn back_"+el.nombreEnCodigo+";\n";
								str+="}\n";
							}
						}
						else{ //Es tipo simple
							str+="XplNode* "+cp.tipoEnCodigo+"::set_"+el.nombreEnCodigo+"(XplNode* new_"+el.nombreEnCodigo+"){\n";
                            str += "\tif(new_" + el.nombreEnCodigo + "->get_ContentTypeName()!=CODEDOMTYPES_" + el.tipoEnCodigo.ToUpper() + "){\n";
							str+="\t\tthis->set_ErrorString(DT(\"El nodo que intenta asignar a la propiedad es de un tipo incorrecto.\"));\n";
							str+="\t\treturn NULL;\n";
							str+="\t}\n";
							str+="\tXplNode* back_"+el.nombreEnCodigo+" = p_"+el.nombreEnCodigo+";\n";
							str+="\tp_"+el.nombreEnCodigo+" = new_"+el.nombreEnCodigo+";\n";
							str+="\tif(p_"+el.nombreEnCodigo+"!=NULL){\n";
							str+="\t\tp_"+el.nombreEnCodigo+"->set_Parent(this);\n";
							str+="\t\tp_"+el.nombreEnCodigo+"->set_ElementName(DT(\""+el.nombre+"\"));\n";
							str+="\t}\n";
							str+="\treturn back_"+el.nombreEnCodigo+";\n";
							str+="}\n";
						}
					}
				}
			}
			if(cp.choice.Count>0){
				str+="\n//Funciones para setear Elementos de Choice\n";
				//Primero compruebo si es un choice ordenada o de coleccion
				if(cp.choiceBounded){
					MessageBox.Show("ERROR: Choice Unbounded. "+cp.nombre+".");
				}
				else{
					if(cp.claseBaseChoice!=null){
						str+=cp.claseBaseChoice+"* "+cp.tipoEnCodigo+"::set_"+cp.choiceName+"("+cp.claseBaseChoice+"* new_"+cp.choiceName+"){\n";
						str+="\tif(new_"+cp.choiceName+"==NULL)return p_"+cp.choiceName+";\n";

						str+="\t"+cp.claseBaseChoice+"* back_"+cp.choiceName+" = p_"+cp.choiceName+";\n";
						foreach(Elemento el in cp.choice){
							str+="\tif(new_"+cp.choiceName+"->get_ElementName()==DT(\""+el.nombre+"\")){\n";
                            str += "\t\tif(new_" + cp.choiceName + "->get_ContentTypeName()!=CODEDOMTYPES_" + el.tipoEnCodigo.ToUpper() + "){\n";
							str+="\t\t\tthis->set_ErrorString(DT(\"El elemento de tipo '\")+new_"+cp.choiceName+"->get_ContentTypeNameString()+DT(\"' no es valido como componente de '"+cp.choiceName+"'.\"));\n";
							str+="\t\t\treturn NULL;\n";
							str+="\t\t}\n";
							str+="\t\tp_"+cp.choiceName+" = new_"+cp.choiceName+";\n";
							str+="\t\tp_"+cp.choiceName+"->set_Parent(this);\n";
							str+="\t\treturn back_"+cp.choiceName+";\n";
							str+="\t}\n";
						}
						str+="\tthis->set_ErrorString(DT(\"El elemento de nombre '\")+new_"+cp.choiceName+"->get_ElementName()+DT(\"' no es valido como componente de '"+cp.choiceName+"'.\"));\n";
						str+="\treturn NULL;\n";
						str+="}\n";
					}
					else{
						str+="XplNode* "+cp.tipoEnCodigo+"::set_"+cp.choiceName+"(XplNode* new_"+cp.choiceName+"){\n";
						str+="\tif(new_"+cp.choiceName+"==NULL)return p_"+cp.choiceName+";\n";
						str+="\tXplNode* back_"+cp.choiceName+" = p_"+cp.choiceName+";\n";
						foreach(Elemento el in cp.choice){
							str+="\tif(new_"+cp.choiceName+"->get_ElementName()==DT(\""+el.nombre+"\")){\n";
                            str += "\t\tif(new_" + cp.choiceName + "->get_ContentTypeName()!=CODEDOMTYPES_" + el.tipoEnCodigo.ToUpper() + "){\n";
							str+="\t\t\tthis->set_ErrorString(DT(\"El elemento de tipo '\")+new_"+cp.choiceName+"->get_ContentTypeNameString()+DT(\"' no es valido como componente de '"+cp.choiceName+"'.\"));\n";
							str+="\t\t\treturn NULL;\n";
							str+="\t\t}\n";
							str+="\t\tp_"+cp.choiceName+" = new_"+cp.choiceName+";\n";
							str+="\t\tp_"+cp.choiceName+"->set_Parent(this);\n";
							str+="\t\treturn back_"+cp.choiceName+";\n";
							str+="\t}\n";
						}
						str+="\tthis->set_ErrorString(DT(\"El elemento de nombre '\")+new_"+cp.choiceName+"->get_ElementName()+DT(\"' no es valido como componente de '"+cp.choiceName+"'.\"));\n";
						str+="\treturn NULL;\n";
						str+="}\n";
					}
				}
			}
			#endregion
			//Otras Funciones Miembro Publicas
			#region Otras Funciones Miembro
			//FUNCIONES PARA OBTENER TIPOS ESPECIFICOS DE UNA LISTA
			if(cp.secuencia.Count>0){
				if(cp.secuenciaBounded||cp.secuenciaOrdenada){
					str+="\n//Funciones para filtrado en Listas de Nodos\n";
					//Si la secuencia de coleccion
					foreach(Elemento el in cp.secuencia){
						str+="XplNodeList* "+cp.tipoEnCodigo+"::get_"+el.nombreEnCodigo+"NodeList(){\n";
						str+="\tXplNodeList* new_List = new XplNodeList();\n";
						str+="\tfor(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){\n";
						str+="\t\tif(node->get_ElementName()==DT(\""+el.nombre+"\")){\n";
						str+="\t\t\tnew_List->InsertAtEnd(node);\n";
						str+="\t\t}\n";
						str+="\t}\n";
						str+="\treturn new_List;\n";
						str+="}\n";
					}
				}
				else{
					//Si la secuencia no es de coleccion
				}
			}
			//FUNCIONES PARA OBTENER NUEVOS NODOS HIJOS
			if(cp.secuencia.Count>0){
				//Secuencia no Coleccion
				foreach(Elemento el in cp.secuencia){
					if(el.isComplexType){
						str+=el.tipoEnCodigo+"* "+cp.tipoEnCodigo+"::new_"+el.nombreEnCodigo+"(){\n";
						str+="\t"+el.tipoEnCodigo+"* node = new "+el.tipoEnCodigo+"();\n";
						str+="\tnode->set_ElementName(DT(\""+el.nombre+"\"));\n";
						str+="\treturn node;\n";
						str+="}\n";
					}
					else{ //Es tipo simple
						str+="XplNode* "+cp.tipoEnCodigo+"::new_"+el.nombreEnCodigo+"(){\n";
						str+="\tXplNode* node = new XplNode("+GetBasicNodeType(el)+");\n";
						str+="\tnode->set_ElementName(DT(\""+el.nombre+"\"));\n";
						str+="\treturn node;\n";
						str+="}\n";
					}
				}
			}
			if(cp.choice.Count>0){
				foreach(Elemento el in cp.choice){
					if(el.isComplexType){
						str+=el.tipoEnCodigo+"* "+cp.tipoEnCodigo+"::new_"+el.nombreEnCodigo+"(){\n";
						str+="\t"+el.tipoEnCodigo+"* node = new "+el.tipoEnCodigo+"();\n";
						str+="\tnode->set_ElementName(DT(\""+el.nombre+"\"));\n";
						str+="\treturn node;\n";
						str+="}\n";
					}
					else{ //Es tipo simple
						str+="XplNode* "+cp.tipoEnCodigo+"::new_"+el.nombreEnCodigo+"(){\n";
						str+="\tXplNode* node = new XplNode("+GetBasicNodeType(el)+");\n";
						str+="\tnode->set_ElementName(DT(\""+el.nombre+"\"));\n";
						str+="\treturn node;\n";
						str+="}\n";
					}
				}
			}
			#endregion
			//Finalmente Cierro el archivo
			sr.Write(str);
			sr.Write("\n");
			MakeFootBody(cp.tipoEnCodigo);
			sr.Close();
		}

		#region GetBasicNodeType
		string GetBasicNodeType(Elemento el){
			string ret="";
			if(!el.isComplexType){
				switch(el.tipo){
					case "xs:time":
					case "xs:date":
						if(!isCS)ret="ZOENODETYPE_DATETIME";
						else ret="XplNodeType_enum.DATETIME";
						break;
					case "xs:string":
						if(!isCS)ret="ZOENODETYPE_STRING";
						else ret="XplNodeType_enum.STRING";
						break;
					case "empty":
						if(!isCS)ret="ZOENODETYPE_EMPTY";
						else ret="XplNodeType_enum.EMPTY";
						break;
					case "xs:boolean":
						if(!isCS)ret="ZOENODETYPE_BOOL";
						else ret="XplNodeType_enum.BOOL";
						break;
					case "xs:integer":
						if(!isCS)ret="ZOENODETYPE_INT";
						else ret="XplNodeType_enum.INT";
						break;
					case "xs:nonNegativeInteger":
						if(!isCS)ret="ZOENODETYPE_UNSIGNED";
						else ret="XplNodeType_enum.UNSIGNED";
						break;
					default:
						MessageBox.Show(el.tipo);
						if(!isCS)ret="NULL";
						else ret="null";
						break;
				};
			}
			return ret;
		}
		#endregion
		#region ParseDefaultValue
		string GetDefaultInitValue(Atributo at){
			string ret="";
			if(at.isSimpleType){
				return "("+at.simpleType.tipoEnCodigo+")0";
			}
			switch(at.tipoEnCodigo){
				case "DateTime":
				case "string":
					ret="DT_EMPTY";
					break;
				case "bool":
					ret="false";
					break;
				case "int":
				case "uint":
				case "unsigned":
					ret="0";
					break;
				default:
					MessageBox.Show(at.tipoEnCodigo);
					ret="NULL";
					break;
			};
			return ret;
		}
		string GetDefaultInitValue_CS(Atributo at){
			string ret="";
			if(at.isSimpleType){
				return "("+at.simpleType.tipoEnCodigo+")0";
			}
			switch(at.tipoEnCodigo){
				case "DateTime":
					ret="DateTime.Parse(\"01/01/1970\")";
					break;
				case "string":
					ret="\"\"";
					break;
				case "bool":
					ret="false";
					break;
				case "int":
				case "uint":
				case "unsigned":
					ret="0";
					break;
				default:
					MessageBox.Show(at.tipoEnCodigo);
					ret="null";
					break;
			};
			return ret;
		}
		string ParseDefaultValue(Atributo at){
			string ret="";
			if(at.isSimpleType){
				return at.tipoEnCodigo.ToUpper()+"_"+at.defaultValue.ToUpper();
			}
			switch(at.tipoEnCodigo){
				case "DateTime":
				case "string":
					ret="DT(\""+at.defaultValue+"\")";
					break;
				case "bool":
					if(at.defaultValue!="")
						ret=at.defaultValue;
					else
						ret="false";
					break;
				case "int":
				case "uint":
				case "unsigned":
					ret=at.defaultValue;
					break;
				default:
					MessageBox.Show(at.tipoEnCodigo);
					break;
			};
			return ret;
		}
		string ParseDefaultValue_CS(Atributo at){
			string ret="";
			if(at.isSimpleType){
				return at.tipoEnCodigo+"."+at.defaultValue.ToUpper();
			}
			switch(at.tipoEnCodigo){
				case "DateTime":
					ret="DateTime.Parse(\"01/01/1970\")";
					break;
				case "string":
					ret="\""+at.defaultValue+"\"";
					break;
				case "bool":
					if(at.defaultValue!="")
						ret=at.defaultValue;
					else
						ret="false";
					break;
				case "int":
				case "uint":
				case "unsigned":
					ret=at.defaultValue;
					break;
				default:
					MessageBox.Show(at.tipoEnCodigo);
					break;
			};
			return ret;
		}
		#endregion
		#endregion

		#region GenerarDocumentacion
		private void GenerarDocumentacion(ComplexType cp){
		}
		#endregion

		#region Ayudas para Generar Enc y Pies
		void MakeHeaderST(bool header){
			sf.WriteLine ("/*-------------------------------------------------");
			sf.WriteLine (" *");
			sf.WriteLine (" *	Este archivo fue generado automáticamente.");
			sf.WriteLine (" *	Fecha: " + System.DateTime.Now.ToString() );
			sf.WriteLine (" *");
			sf.WriteLine (" *	Generado por Zoe CodeDOM Generator.");
			sf.WriteLine (" *	COPYRIGHT 2002. por Alexis Ferreyra.");
			sf.WriteLine (" *");
			sf.WriteLine (" *------------------------------------------------*/");
			sf.WriteLine ("");
			if(header){
				sf.WriteLine ("#ifndef __LAYERD_CODEDOM_SIMPLETYPES_V1_0" );
				sf.WriteLine ("#define __LAYERD_CODEDOM_SIMPLETYPES_V1_0");
				sf.WriteLine ("#include \"CDOMBase.h\"");
			}
			else{
				sf.WriteLine ("#ifndef __LAYERD_CODEDOM_SIMPLETYPES_V1_0_CPP" );
				sf.WriteLine ("#define __LAYERD_CODEDOM_SIMPLETYPES_V1_0_CPP");
				sf.WriteLine ("#include \"CDOM_SimpleTypes.h\"");
			}
			//sf.WriteLine ("#include \"CDOMBase.h\"");
			sf.WriteLine ("");
			sf.WriteLine ("namespace CodeDOM{");
			sf.WriteLine ("");
		}
		void MakeFooterST(){
			sf.WriteLine ("");
			sf.WriteLine ("}");
			sf.WriteLine ("");
			sf.WriteLine ("#endif");
			sf.WriteLine ("");
			sf.Close();
		}
		void MakeHeaderHeader(string name){
			sr.WriteLine ("/*-------------------------------------------------");
			sr.WriteLine (" *");
			sr.WriteLine (" *	Este archivo fue generado automáticamente.");
			sr.WriteLine (" *	Fecha: " + System.DateTime.Now.ToString() );
			sr.WriteLine (" *");
			sr.WriteLine (" *	Generado por Zoe CodeDOM Generator.");
			sr.WriteLine (" *	COPYRIGHT 2002. por Alexis Ferreyra.");
			sr.WriteLine (" *");
			sr.WriteLine (" *------------------------------------------------*/");
			sr.WriteLine ("");
			sr.WriteLine ("");
			sr.WriteLine ("#ifndef __LAYERD_CODEDOM_"+name.ToUpper()+"_V1_0" );
			sr.WriteLine ("#define __LAYERD_CODEDOM_"+name.ToUpper()+"_V1_0");
			sr.WriteLine ("#include \"CDOM_IncludeAll.h\"");
			sr.WriteLine ("");
			sr.WriteLine ("namespace CodeDOM{");
			sr.WriteLine ("");
		}
		void MakeFootHeader(string name){
			sr.WriteLine ("}");
			sr.WriteLine ("");
			//sr.WriteLine ("#ifndef __LAYERD_CODEDOM_HEADERSONLY");
			//sr.WriteLine ("#include \"CDOM_"+name+".cpp\"");
			//sr.WriteLine ("#endif");
			//sr.WriteLine ("");
			sr.WriteLine ("#endif");
		}
		void MakeHeaderBody(string name){
			sr.WriteLine ("/*-------------------------------------------------");
			sr.WriteLine (" *");
			sr.WriteLine (" *	Este archivo fue generado automáticamente.");
			sr.WriteLine (" *	Fecha: " + System.DateTime.Now.ToString() );
			sr.WriteLine (" *");
			sr.WriteLine (" *	Generado por Zoe CodeDOM Generator.");
			sr.WriteLine (" *	COPYRIGHT 2002. por Alexis Ferreyra.");
			sr.WriteLine (" *");
			sr.WriteLine (" *------------------------------------------------*/");
			sr.WriteLine ("");
			sr.WriteLine ("#ifndef __LAYERD_CODEDOM_"+name.ToUpper()+"_V1_0_CPP" );
			sr.WriteLine ("#define __LAYERD_CODEDOM_"+name.ToUpper()+"_V1_0_CPP");
			sr.WriteLine ("#include \"CDOM_"+name+".h\"" );
			sr.WriteLine ("");
			sr.WriteLine ("namespace CodeDOM{");
			sr.WriteLine ("");
		}
		void MakeFootBody(string name){
			sr.WriteLine ("}");
			sr.WriteLine ("");
			sr.WriteLine ("#endif");
		}

		void openSimpleTypesFile() {
			sf = File.CreateText(outputPath+"CDOM_XplSimpleTypes.cpp");
			sf.WriteLine ("/*-------------------------------------------------");
			sf.WriteLine (" *");
			sf.WriteLine (" *	Este archivo fue generado automáticamente.");
			sf.WriteLine (" *	Fecha: " + System.DateTime.Now.ToString() );
			sf.WriteLine (" *");
			sf.WriteLine (" *	Generado por Zoe CodeDOM Generator.");
			sf.WriteLine (" *	COPYRIGHT 2002. por Alexis Ferreyra.");
			sf.WriteLine (" *");
			sf.WriteLine (" *------------------------------------------------*/");
			sf.WriteLine ("");
			sf.WriteLine ("#include \"CDOMBase.h\"");
			sf.WriteLine ("");
			sf.WriteLine ("#ifndef __LAYERD_CODEDOM_SIMPLETYPES_V1.0" );
			sf.WriteLine ("");
			sf.WriteLine ("namespace CodeDOM{");
			sf.WriteLine ("");
		}

		void closeSimpleTypesFile() {
			sf.WriteLine ("");
			sf.WriteLine ("}");
			sf.WriteLine ("");
			sf.WriteLine ("#endif");
			sf.WriteLine ("#define __LAYERD_CODEDOM_SIMPLETYPES_V1.0");
			sf.WriteLine ("");
			sf.Close();
		}
		#endregion

		#region LoadSimpleType
		bool LoadSimpleType(string nombre, XmlNode nodo){
			XmlNode child,node1,node2;
			SimpleType type=new SimpleType();
			type.nombre=nombre;
			type.tipo=nombre;
			
			if(SimpleTypes.ContainsKey(nombre))return true;

			child=nodo.FirstChild;
			switch(child.Name) {
				case "xs:restriction":
					node1=child.Attributes.GetNamedItem("base");
					if(node1==null)return false;
					if(node1.Value=="xs:string"){
						type.esEnum=true;
						foreach(XmlNode nd in child.ChildNodes) {
							if(nd.Name=="xs:enumeration") {
								type.enumValues.Add(nd.Attributes.GetNamedItem("value").Value);
							}
						}
						type.tipoEnCodigo=ProcessTypeName(nombre);
					}
					else {
						type.tipoEnCodigo=ProcessTypeName(node1.Value);
					}
					break;
				case "xs:union":
					node1=child.FirstChild;
					if(node1.Name=="xs:simpleType"){
						node1=node1.FirstChild;
						node2=node1.Attributes.GetNamedItem("base");
						if(node2.Value=="xs:string") {
							type.esEnum=true;
							foreach(XmlNode nd in node1.ChildNodes) {
								if(nd.Name=="xs:enumeration") {
									type.enumValues.Add(nd.Attributes.GetNamedItem("value").Value);
								}
							}
							type.tipoEnCodigo=ProcessTypeName(nombre);
						}
						else {
							MessageBox.Show("No se encontro una union de tipo simple valida para procesar."+nombre);
						}
					}
					break;
			};
			//Finalmente lo agrego a la coleccion de tipos simples
			SimpleTypes.Add(type.tipo,type);
			return true;
		}
		#endregion

		#region LoadComplexType
		bool LoadComplexType(string nombre, XmlNode nodo){

			if(ComplexTypes.ContainsKey(nombre))return true;
			ComplexType type=new ComplexType();
			type.nombre=nombre;
			type.tipo=type.nombre;
			type.tipoEnCodigo=ProcessTypeName(type.tipo);

			try{
				ComplexTypes.Add(type.nombre,type);
				ProcessChildNodes(nodo,type);
			}
			catch(Exception e){
				MessageBox.Show(e.Message);
			}
			return true;
		}
		#endregion

		#region ProcessChildNodes
		private void ProcessChildNodes(XmlNode nodo, ComplexType type){
			XmlNode node1;
			XmlNamespaceManager context = new XmlNamespaceManager(source.NameTable);
			context.AddNamespace("xs","http://www.w3.org/2001/XMLSchema");

			foreach(XmlNode node in nodo.ChildNodes){
				switch(node.Name){
					case "xs:all":
					case "xs:sequence":
						ProcesarSecuencia(node,type);
						break;

					case "xs:choice":
						ProcesarChoice(node,type);
						break;

					case "xs:group":
						node1=source.SelectSingleNode("//xs:group[@name='"+node.Attributes.GetNamedItem("ref").Value+"']",context);
						if(node1==null){
							MessageBox.Show("No se encontro un grupo: "+node.Attributes.GetNamedItem("ref").Value);
						}
						else ProcessChildNodes(node1,type);
						break;

					case "xs:attribute":
						ProcesarAtributo(node,type);
						break;

					case "xs:attributeGroup":
						node1=source.SelectSingleNode("//xs:attributeGroup[@name='"+node.Attributes.GetNamedItem("ref").Value+"']",context);
						if(node1==null){
							MessageBox.Show("No se encontro un grupo de atributos: "+node.Attributes.GetNamedItem("ref").Value);
						}
						else{
							ProcessChildNodes(node1,type);
						}
						break;

					case "#comment":
						break;

					case "xs:annotation":
						foreach(XmlNode pn in node.ChildNodes){
							if(pn.FirstChild.Value.Length>10)
								if(pn.FirstChild.Value.Substring(0,10)=="ClaseBase:"){
									type.claseBase=pn.FirstChild.Value.Substring(10);
								}
							if(pn.FirstChild.Value=="RequiereOrden") type.secuenciaOrdenada=true;
						}
						break;

					default:
						MessageBox.Show("Un elemento no identificado:"+node.Name);
						break;
				};
			}
		}

		#endregion

		#region ProcesarAtributo, Choice y Secuencia
		private void ProcesarAtributo(XmlNode node, ComplexType type){
			XmlNode node1;
			Atributo atributo=new Atributo();
			//Nombre
			node1=node.Attributes.GetNamedItem("name");
			atributo.nombre=node1.Value;
			//Optional
			node1=node.Attributes.GetNamedItem("use");
			if(node1==null) atributo.optional=true;
			else {
				if(node1.Value=="required")atributo.optional=false;
				else atributo.optional=true;
			}
			//Default Value
			node1=node.Attributes.GetNamedItem("default");
			if(node1!=null) {
				atributo.defaultValue=node1.Value;
				atributo.optional=false;
			}
			//Tipo
			node1=node.Attributes.GetNamedItem("type");
			if(node1!=null){
				atributo.tipo=node1.Value;
				if(SimpleTypes.ContainsKey(atributo.tipo)){
					atributo.isSimpleType=true;
					atributo.simpleType=(SimpleType)SimpleTypes[atributo.tipo];
					atributo.tipoEnCodigo=atributo.simpleType.tipoEnCodigo;
				}
				else if(IsBaseType(atributo.tipo)!=""){
					atributo.tipoEnCodigo=IsBaseType(atributo.tipo);
				}
				else{
					//Si no es ni un tipo simple ni un tipo basico es un error
					MessageBox.Show("Error: El tipo de un atributo no se encuentra. "+atributo.nombre);
				}
			}
			else{ //No se encontro tipo
				atributo.tipo="empty";
				atributo.tipoEnCodigo="bool";
			}
			//Finalmente lo agrego a la coleccion de atributos del tipo
			type.atributos.Add(atributo);
		}
							  
		private void ProcesarChoice(XmlNode node, ComplexType type){
			XmlNode node1,searchNode=null; bool unbound;
			string tempStr;
			XmlNamespaceManager context = new XmlNamespaceManager(source.NameTable);
			context.AddNamespace("xs","http://www.w3.org/2001/XMLSchema");

			node1=node.Attributes.GetNamedItem("maxOccurs");
			if(node1==null) unbound=false;
			else{
				if(node1.Value=="unbounded") unbound=true;
				else unbound=false;
			}
			type.choiceBounded=unbound;
			type.choiceName=type.nombre;

			foreach(XmlNode nd in node.ChildNodes){
				switch(nd.Name) {
					case "#comment":
						break;
					case "xs:annotation":
						foreach(XmlNode pn in nd.ChildNodes){
							if(pn.FirstChild.Value.Length>10)
								if(pn.FirstChild.Value.Substring(0,10)=="ClaseBase:"){
									type.claseBaseChoice=pn.FirstChild.Value.Substring(10);
								}
							if(pn.FirstChild.Value.Length>7)
								if(pn.FirstChild.Value.Substring(0,7)=="Nombre:"){
									type.choiceName=pn.FirstChild.Value.Substring(7);
								}
						}
						break;
								
					case "xs:element":
						Elemento elemento=new Elemento();
						//Nombre
						node1=nd.Attributes.GetNamedItem("name");
						elemento.nombre=node1.Value;
						elemento.nombreEnCodigo=elemento.nombre;
						/*Averiguo si se desea utilizar otro nombre en Código*/
						searchNode=nd.SelectSingleNode(".//xs:appinfo",context);
						if(searchNode!=null){
							tempStr=searchNode.InnerText;
							if(tempStr.StartsWith("Nombre:")){
								elemento.nombreEnCodigo=tempStr.Remove(0,7);
							}
							searchNode=null;
						}
						//Optional
						node1=nd.Attributes.GetNamedItem("minOccurs");
						if(node1==null) elemento.optional=false;
						else {
							if(node1.Value=="0")elemento.optional=true;
							else elemento.optional=false;
						}
						//Default Value
						node1=nd.Attributes.GetNamedItem("default");
						if(node1!=null)elemento.defaultValue=node1.Value;
						//Tipo
						node1=nd.Attributes.GetNamedItem("type");
						if(node1!=null){
							elemento.tipo=node1.Value;
							if(SimpleTypes.ContainsKey(elemento.tipo)){
								elemento.isSimpleType=true;
								elemento.simpleType=(SimpleType)SimpleTypes[elemento.tipo];
								elemento.tipoEnCodigo=elemento.simpleType.tipoEnCodigo;
							}
							else if(ComplexTypes.ContainsKey(elemento.tipo)){
								elemento.isComplexType=true;
								elemento.complexType=(ComplexType)ComplexTypes[elemento.tipo];
								elemento.tipoEnCodigo=elemento.complexType.tipoEnCodigo;
							}
							else{
								if(IsBaseType(elemento.tipo)!=""){
									elemento.tipoEnCodigo=IsBaseType(elemento.tipo);
								}
								else{
									//debo procesar el tipo
									node1=source.SelectSingleNode("//xs:complexType[@name='"+elemento.tipo+"']",context);
									if(node1==null){
										MessageBox.Show("Error: no se encontro tipo complejo de nombre: "+elemento.tipo);
										return;
									}
									LoadComplexType(elemento.tipo,node1);
									elemento.isComplexType=true;
									elemento.complexType=(ComplexType)ComplexTypes[elemento.tipo];
									elemento.tipoEnCodigo=elemento.complexType.tipoEnCodigo;
								}
							}
						}
						else{ //No se encontro tipo
							elemento.tipo="empty";
							elemento.tipoEnCodigo="XplNode";
						}
						//finalmente agrego el elemento al choice
						type.choice.Add(elemento);
						break;
					default:
						MessageBox.Show("Error: elemento no identificado al procesar choice."+type.nombre);
						break;
				};
			}
		}

		private void ProcesarSecuencia(XmlNode node, ComplexType type){
			XmlNode node1,searchNode=null; bool unbound;
			string tempStr;
			XmlNamespaceManager context = new XmlNamespaceManager(source.NameTable);
			context.AddNamespace("xs","http://www.w3.org/2001/XMLSchema");

			node1=node.Attributes.GetNamedItem("maxOccurs");
			if(node1==null) unbound=false;
			else{
				if(node1.Value=="unbounded")unbound=true;
				else unbound=false;
			}
			type.secuenciaBounded=unbound;

			foreach(XmlNode nd in node.ChildNodes){						
				switch(nd.Name){
					case "#comment":
						break;
					case "xs:annotation":
						foreach(XmlNode pn in nd.ChildNodes){
							if(pn.FirstChild.Value.Length>10)
								if(pn.FirstChild.Value.Substring(0,10)=="ClaseBase:"){
									type.claseBase=pn.FirstChild.Value.Substring(10);
								}
						}
						break;
					case "xs:element":
						Elemento elemento=new Elemento();
						//Nombre
						node1=nd.Attributes.GetNamedItem("name");
						elemento.nombre=node1.Value;
						elemento.nombreEnCodigo=elemento.nombre;
						/*Averiguo si se desea utilizar otro nombre en Código*/
						searchNode=nd.SelectSingleNode(".//xs:appinfo",context);
						if(searchNode!=null){
							tempStr=searchNode.InnerText;
							if(tempStr.StartsWith("Nombre:")){
								elemento.nombreEnCodigo=tempStr.Remove(0,7);
							}
							searchNode=null;
						}
						//Optional
						node1=nd.Attributes.GetNamedItem("minOccurs");
						if(node1==null) elemento.optional=false;
						else {
							if(node1.Value=="0")elemento.optional=true;
							else elemento.optional=false;
						}
						//Unbounded
						node1=nd.Attributes.GetNamedItem("maxOccurs");
						if(node1==null) unbound=false;
						else{
							if(node1.Value=="unbounded")unbound=true;
							else unbound=false;
						}
						elemento.unbounded=unbound;
						if(elemento.unbounded){ //debo averiguar si requiere orden
							elemento.requiereOrden=RequiereOrden(nd);
						}
						//Default Value
						node1=nd.Attributes.GetNamedItem("default");
						if(node1!=null)	elemento.defaultValue=node1.Value;
						//Tipo
						node1=nd.Attributes.GetNamedItem("type");
						if(node1!=null){
							elemento.tipo=node1.Value;
							if(SimpleTypes.ContainsKey(elemento.tipo)){
								elemento.isSimpleType=true;
								elemento.simpleType=(SimpleType)SimpleTypes[elemento.tipo];
							}
							else if(ComplexTypes.ContainsKey(elemento.tipo)){
								elemento.isComplexType=true;
								elemento.complexType=(ComplexType)ComplexTypes[elemento.tipo];
								elemento.tipoEnCodigo=elemento.complexType.tipoEnCodigo;
							}
							else{
								if(IsBaseType(elemento.tipo)!=""){
									elemento.tipoEnCodigo=IsBaseType(elemento.tipo);
								}
								else{
									//debo procesar el tipo
									node1=source.SelectSingleNode("//xs:complexType[@name='"+elemento.tipo+"']",context);
									if(node1==null){
										MessageBox.Show("Error: no se encontro tipo complejo de nombre: "+elemento.tipo);
										return;
									}
									LoadComplexType(elemento.tipo,node1);
									elemento.isComplexType=true;
									elemento.complexType=(ComplexType)ComplexTypes[elemento.tipo];
									elemento.tipoEnCodigo=elemento.complexType.tipoEnCodigo;
								}
							}
						}
						else{ //No se encontro tipo
							elemento.tipo="empty";
							elemento.tipoEnCodigo="XplNode";
						}
						//Finalmente agrego el elemento a la secuencia
						type.secuencia.Add(elemento);
						break;
					default:
						MessageBox.Show("Error: se encontraron elementos hijos inesperados. "+type.tipo);
						break;
				};
			}
		}

		#endregion

		#region RequiereOrden, ProcessTypeName, IsBaseType
		//Busca una anotacion hija indicando que requiere orden
		private bool RequiereOrden(XmlNode node){
			foreach(XmlNode nd in node.ChildNodes){
				if(nd.Name=="xs:annotation")
					if(nd.ChildNodes.Item(0).Name=="xs:appinfo")
						if(nd.ChildNodes.Item(0).ChildNodes.Item(0).Value=="RequiereOrden")return true;
			}
			return false;
		}
	
		//Debe devolver un nombre de tipo para un tipo complejo
		private string ProcessTypeName(string tipo){
			string cad=tipo;
			if(cad[0]=='t')cad=cad.Substring(1);
			cad=cad.Substring(0,1).ToUpper()+cad.Substring(1);
			switch(cad) {
				case "New":
					cad="NewExpression";
					break;
				case "Try":
					cad="TryStatement";
					break;
				case "If":
					cad="IfStatement";
					break;
				case "Switch":
					cad="SwitchStatement";
					break;
				case "Dowhile":
					cad="DowhileStatement";
					break;
				case "For":
					cad="ForStatement";
					break;
				case "Catch":
					cad="CatchStatement";
					break;
				case "Break":
					cad="BreakStatement";
					break;
				case "Throw":
					cad="ThrowStatement";
					break;
			};
			//cad="CodeDOM"+cad;
            if (tipo[0] == 't') cad = "Xpl" + cad;
			if(cad.Length>6)
				if(cad.Substring(cad.Length-5)==".enum")cad=cad.Substring(0,cad.Length-5)+"_enum";
			return cad;
		}

		//Debe devolver el nombre de un tipo para un tipo basico o cadena nula
		private string IsBaseType(string tipo){
			string cad=tipo;
			switch(cad){
				case "xs:string":
					cad="string";
					break;
				case "xs:integer":
					cad="int";
					break;
				case "xs:nonNegativeInteger":
					if(!isCS)cad="unsigned";
					else cad="uint";
					break;
				case "xs:time":
				case "xs:date":
					cad="DateTime";
					break;
				case "xs:boolean":
				case "Set":
				case "Yesno":
					cad="bool";
					break;
				default:
					cad="";
					break;
			};
			return cad;
		}

		#endregion
	}	
}
