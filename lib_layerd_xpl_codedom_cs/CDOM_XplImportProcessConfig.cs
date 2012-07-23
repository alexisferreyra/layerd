/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 8/11/2011 4:27:20 PM
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
public class XplImportProcessConfig:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_OutputFolder;
	string p_OutputPrefix;
	string p_ErrorsFileName;
	#endregion

	#region Region de Constructores Publicos
	public XplImportProcessConfig(){
		p_OutputFolder = "";
		p_OutputPrefix = "";
		p_ErrorsFileName = "";
}
	public XplImportProcessConfig(string n_OutputFolder, string n_ErrorsFileName){
		p_OutputFolder = "";
		p_OutputPrefix = "";
		p_ErrorsFileName = "";
		set_OutputFolder(n_OutputFolder);
		set_ErrorsFileName(n_ErrorsFileName);
	}
	public XplImportProcessConfig(string n_OutputFolder, string n_OutputPrefix, string n_ErrorsFileName){
		set_OutputFolder(n_OutputFolder);
		set_OutputPrefix(n_OutputPrefix);
		set_ErrorsFileName(n_ErrorsFileName);
	}
	#endregion

	#region Destructor
/*	public ~XplImportProcessConfig(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplImportProcessConfig copy = new XplImportProcessConfig();
		copy.set_OutputFolder(this.p_OutputFolder);
		copy.set_OutputPrefix(this.p_OutputPrefix);
		copy.set_ErrorsFileName(this.p_ErrorsFileName);
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplImportProcessConfig;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_OutputFolder != "")
			writer.WriteAttributeString( "OutputFolder" ,ZoeHelper .Att_ToString(p_OutputFolder) );
		if(p_OutputPrefix != "")
			writer.WriteAttributeString( "OutputPrefix" ,ZoeHelper .Att_ToString(p_OutputPrefix) );
		if(p_ErrorsFileName != "")
			writer.WriteAttributeString( "ErrorsFileName" ,ZoeHelper .Att_ToString(p_ErrorsFileName) );
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
					case "OutputFolder":
						this.set_OutputFolder(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "OutputPrefix":
						this.set_OutputPrefix(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "ErrorsFileName":
						this.set_ErrorsFileName(ZoeHelper .StringAtt_To_STRING(reader.Value));
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
		writer.Write((int) 155 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_OutputFolder );
		writer.Write( p_OutputPrefix );
		writer.Write( p_ErrorsFileName );
		//Escribo recursivamente cada elemento hijo
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_OutputFolder = reader.ReadString();
		p_OutputPrefix = reader.ReadString();
		p_ErrorsFileName = reader.ReadString();
		//Lectura de Elementos
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplImportProcessConfig operator +(XplImportProcessConfig arg1, XplNode arg2)
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
public static XplImportProcessConfig operator +(XplImportProcessConfig arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_OutputFolder(){
		return p_OutputFolder;
	}
	public string get_OutputPrefix(){
		return p_OutputPrefix;
	}
	public string get_ErrorsFileName(){
		return p_ErrorsFileName;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[3];
		ret[0] = "OutputFolder";
		ret[1] = "OutputPrefix";
		ret[2] = "ErrorsFileName";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="OutputFolder") return p_OutputFolder.ToString();
		if (attributeName=="OutputPrefix") return p_OutputPrefix.ToString();
		if (attributeName=="ErrorsFileName") return p_ErrorsFileName.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_OutputFolder(string new_OutputFolder){
		string back_OutputFolder = p_OutputFolder;
		p_OutputFolder = new_OutputFolder;
		return back_OutputFolder;
	}
	public string set_OutputPrefix(string new_OutputPrefix){
		string back_OutputPrefix = p_OutputPrefix;
		p_OutputPrefix = new_OutputPrefix;
		return back_OutputPrefix;
	}
	public string set_ErrorsFileName(string new_ErrorsFileName){
		string back_ErrorsFileName = p_ErrorsFileName;
		p_ErrorsFileName = new_ErrorsFileName;
		return back_ErrorsFileName;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

