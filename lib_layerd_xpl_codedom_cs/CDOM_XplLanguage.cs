/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 8/11/2011 4:27:19 PM
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
public class XplLanguage:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_Source;
	string p_StandardDefinitionFile;
	string p_SourceVersion;
	string p_Destination;
	#endregion

	#region Region de Constructores Publicos
	public XplLanguage(){
		p_Source = "";
		p_StandardDefinitionFile = "";
		p_SourceVersion = "";
		p_Destination = "";
}
	public XplLanguage(string n_Source){
		p_Source = "";
		p_StandardDefinitionFile = "";
		p_SourceVersion = "";
		p_Destination = "";
		set_Source(n_Source);
	}
	public XplLanguage(string n_Source, string n_StandardDefinitionFile, string n_SourceVersion, string n_Destination){
		set_Source(n_Source);
		set_StandardDefinitionFile(n_StandardDefinitionFile);
		set_SourceVersion(n_SourceVersion);
		set_Destination(n_Destination);
	}
	#endregion

	#region Destructor
/*	public ~XplLanguage(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplLanguage copy = new XplLanguage();
		copy.set_Source(this.p_Source);
		copy.set_StandardDefinitionFile(this.p_StandardDefinitionFile);
		copy.set_SourceVersion(this.p_SourceVersion);
		copy.set_Destination(this.p_Destination);
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplLanguage;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_Source != "")
			writer.WriteAttributeString( "Source" ,ZoeHelper .Att_ToString(p_Source) );
		if(p_StandardDefinitionFile != "")
			writer.WriteAttributeString( "StandardDefinitionFile" ,ZoeHelper .Att_ToString(p_StandardDefinitionFile) );
		if(p_SourceVersion != "")
			writer.WriteAttributeString( "SourceVersion" ,ZoeHelper .Att_ToString(p_SourceVersion) );
		if(p_Destination != "")
			writer.WriteAttributeString( "Destination" ,ZoeHelper .Att_ToString(p_Destination) );
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
					case "Source":
						this.set_Source(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "StandardDefinitionFile":
						this.set_StandardDefinitionFile(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "SourceVersion":
						this.set_SourceVersion(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "Destination":
						this.set_Destination(ZoeHelper .StringAtt_To_STRING(reader.Value));
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
		writer.Write((int) 106 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_Source );
		writer.Write( p_StandardDefinitionFile );
		writer.Write( p_SourceVersion );
		writer.Write( p_Destination );
		//Escribo recursivamente cada elemento hijo
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_Source = reader.ReadString();
		p_StandardDefinitionFile = reader.ReadString();
		p_SourceVersion = reader.ReadString();
		p_Destination = reader.ReadString();
		//Lectura de Elementos
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplLanguage operator +(XplLanguage arg1, XplNode arg2)
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
public static XplLanguage operator +(XplLanguage arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_Source(){
		return p_Source;
	}
	public string get_StandardDefinitionFile(){
		return p_StandardDefinitionFile;
	}
	public string get_SourceVersion(){
		return p_SourceVersion;
	}
	public string get_Destination(){
		return p_Destination;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[4];
		ret[0] = "Source";
		ret[1] = "StandardDefinitionFile";
		ret[2] = "SourceVersion";
		ret[3] = "Destination";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="Source") return p_Source.ToString();
		if (attributeName=="StandardDefinitionFile") return p_StandardDefinitionFile.ToString();
		if (attributeName=="SourceVersion") return p_SourceVersion.ToString();
		if (attributeName=="Destination") return p_Destination.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_Source(string new_Source){
		string back_Source = p_Source;
		p_Source = new_Source;
		return back_Source;
	}
	public string set_StandardDefinitionFile(string new_StandardDefinitionFile){
		string back_StandardDefinitionFile = p_StandardDefinitionFile;
		p_StandardDefinitionFile = new_StandardDefinitionFile;
		return back_StandardDefinitionFile;
	}
	public string set_SourceVersion(string new_SourceVersion){
		string back_SourceVersion = p_SourceVersion;
		p_SourceVersion = new_SourceVersion;
		return back_SourceVersion;
	}
	public string set_Destination(string new_Destination){
		string back_Destination = p_Destination;
		p_Destination = new_Destination;
		return back_Destination;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

