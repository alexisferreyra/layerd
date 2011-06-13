/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 3/2/2010 9:11:44 PM
 *
 *	Generado por Zoe CodeDOM Generator para C#.
 *	COPYRIGHT 2002,2005-2006. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

using System;
using System.Xml;
using System.IO;

namespace LayerD.CodeDOM{

[Serializable]
public class XplGarbageCollector:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_name;
	string p_description;
	string p_sourceFile;
	string p_xplCompilerData;
	#endregion

	#region Region de Constructores Publicos
	public XplGarbageCollector(){
		p_name = "";
		p_description = "";
		p_sourceFile = "";
		p_xplCompilerData = "";
}
	public XplGarbageCollector(string n_name){
		p_name = "";
		p_description = "";
		p_sourceFile = "";
		p_xplCompilerData = "";
		set_name(n_name);
	}
	public XplGarbageCollector(string n_name, string n_description, string n_sourceFile, string n_xplCompilerData){
		set_name(n_name);
		set_description(n_description);
		set_sourceFile(n_sourceFile);
		set_xplCompilerData(n_xplCompilerData);
	}
	#endregion

	#region Destructor
/*	public ~XplGarbageCollector(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplGarbageCollector copy = new XplGarbageCollector();
		copy.set_name(this.p_name);
		copy.set_description(this.p_description);
		copy.set_sourceFile(this.p_sourceFile);
		copy.set_xplCompilerData(this.p_xplCompilerData);
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplGarbageCollector;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,ZoeHelper .Att_ToString(p_name) );
		if(p_description != "")
			writer.WriteAttributeString( "description" ,ZoeHelper .Att_ToString(p_description) );
		if(p_sourceFile != "")
			writer.WriteAttributeString( "sourceFile" ,ZoeHelper .Att_ToString(p_sourceFile) );
		if(p_xplCompilerData != "")
			writer.WriteAttributeString( "xplCompilerData" ,ZoeHelper .Att_ToString(p_xplCompilerData) );
		//Escribo recursivamente cada elemento hijo
		//Cierro el elemento
		writer.WriteEndElement();
		return result;
	}

	public override XplNode Read(XplReader reader){
		this.set_ElementName( reader.Name );
		//Lectura de Atributos
		if( reader.HasAttributes ){
			for(int i=0; i < reader.AttributeCount ; i++){
				reader.MoveToAttribute(i);
				switch(reader.Name){
					case "name":
						this.set_name(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "description":
						this.set_description(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "sourceFile":
						this.set_sourceFile(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "xplCompilerData":
						this.set_xplCompilerData(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Atributo '"+reader.Name+"' invalido en elemento '"+this.get_ElementName()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
				case XmlNodeType.Text:
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".No se esperaba texto o elemento hijo en este nodo.");
				case XmlNodeType.EndElement:
					break;
				default:
					break;
			}
			reader.Read();
		}
		}
		return this;
	}
	public override bool BinaryWrite(XplBinaryWriter writer){
		bool result=true;
		//Escribo el ID y el nombre del elemento
		writer.Write((int) 171 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_name );
		writer.Write( p_description );
		writer.Write( p_sourceFile );
		writer.Write( p_xplCompilerData );
		//Escribo recursivamente cada elemento hijo
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_name = reader.ReadString();
		p_description = reader.ReadString();
		p_sourceFile = reader.ReadString();
		p_xplCompilerData = reader.ReadString();
		//Lectura de Elementos
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplGarbageCollector operator +(XplGarbageCollector arg1, XplNode arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
/// <summary>
/// Adds arg2 nodes to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Nodes to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplGarbageCollector operator +(XplGarbageCollector arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_name(){
		return p_name;
	}
	public string get_description(){
		return p_description;
	}
	public string get_sourceFile(){
		return p_sourceFile;
	}
	public string get_xplCompilerData(){
		return p_xplCompilerData;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[4];
		ret[0] = "name";
		ret[1] = "description";
		ret[2] = "sourceFile";
		ret[3] = "xplCompilerData";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="name") return p_name.ToString();
		if (attributeName=="description") return p_description.ToString();
		if (attributeName=="sourceFile") return p_sourceFile.ToString();
		if (attributeName=="xplCompilerData") return p_xplCompilerData.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_name(string new_name){
		string back_name = p_name;
		p_name = new_name;
		return back_name;
	}
	public string set_description(string new_description){
		string back_description = p_description;
		p_description = new_description;
		return back_description;
	}
	public string set_sourceFile(string new_sourceFile){
		string back_sourceFile = p_sourceFile;
		p_sourceFile = new_sourceFile;
		return back_sourceFile;
	}
	public string set_xplCompilerData(string new_xplCompilerData){
		string back_xplCompilerData = p_xplCompilerData;
		p_xplCompilerData = new_xplCompilerData;
		return back_xplCompilerData;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

