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
public class XplPlatformAlias:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_standardName;
	string p_standardVersion;
	string p_configAlias;
	#endregion

	#region Region de Constructores Publicos
	public XplPlatformAlias(){
		p_standardName = "";
		p_standardVersion = "";
		p_configAlias = "";
}
	public XplPlatformAlias(string n_standardName, string n_configAlias){
		p_standardName = "";
		p_standardVersion = "";
		p_configAlias = "";
		set_standardName(n_standardName);
		set_configAlias(n_configAlias);
	}
	public XplPlatformAlias(string n_standardName, string n_standardVersion, string n_configAlias){
		set_standardName(n_standardName);
		set_standardVersion(n_standardVersion);
		set_configAlias(n_configAlias);
	}
	#endregion

	#region Destructor
/*	public ~XplPlatformAlias(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplPlatformAlias copy = new XplPlatformAlias();
		copy.set_standardName(this.p_standardName);
		copy.set_standardVersion(this.p_standardVersion);
		copy.set_configAlias(this.p_configAlias);
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplPlatformAlias;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_standardName != "")
			writer.WriteAttributeString( "standardName" ,ZoeHelper .Att_ToString(p_standardName) );
		if(p_standardVersion != "")
			writer.WriteAttributeString( "standardVersion" ,ZoeHelper .Att_ToString(p_standardVersion) );
		if(p_configAlias != "")
			writer.WriteAttributeString( "configAlias" ,ZoeHelper .Att_ToString(p_configAlias) );
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
					case "standardName":
						this.set_standardName(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "standardVersion":
						this.set_standardVersion(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "configAlias":
						this.set_configAlias(ZoeHelper .StringAtt_To_STRING(reader.Value));
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
		writer.Write((int) 165 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_standardName );
		writer.Write( p_standardVersion );
		writer.Write( p_configAlias );
		//Escribo recursivamente cada elemento hijo
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_standardName = reader.ReadString();
		p_standardVersion = reader.ReadString();
		p_configAlias = reader.ReadString();
		//Lectura de Elementos
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplPlatformAlias operator +(XplPlatformAlias arg1, XplNode arg2)
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
public static XplPlatformAlias operator +(XplPlatformAlias arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_standardName(){
		return p_standardName;
	}
	public string get_standardVersion(){
		return p_standardVersion;
	}
	public string get_configAlias(){
		return p_configAlias;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[3];
		ret[0] = "standardName";
		ret[1] = "standardVersion";
		ret[2] = "configAlias";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="standardName") return p_standardName.ToString();
		if (attributeName=="standardVersion") return p_standardVersion.ToString();
		if (attributeName=="configAlias") return p_configAlias.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_standardName(string new_standardName){
		string back_standardName = p_standardName;
		p_standardName = new_standardName;
		return back_standardName;
	}
	public string set_standardVersion(string new_standardVersion){
		string back_standardVersion = p_standardVersion;
		p_standardVersion = new_standardVersion;
		return back_standardVersion;
	}
	public string set_configAlias(string new_configAlias){
		string back_configAlias = p_configAlias;
		p_configAlias = new_configAlias;
		return back_configAlias;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

