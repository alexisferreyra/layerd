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
public class XplLayerDCompiler:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_name;
	string p_version;
	string p_companyName;
	string p_copyright;
	#endregion

	#region Region de Constructores Publicos
	public XplLayerDCompiler(){
		p_name = "";
		p_version = "";
		p_companyName = "";
		p_copyright = "";
}
	public XplLayerDCompiler(string n_name, string n_version){
		p_name = "";
		p_version = "";
		p_companyName = "";
		p_copyright = "";
		set_name(n_name);
		set_version(n_version);
	}
	public XplLayerDCompiler(string n_name, string n_version, string n_companyName, string n_copyright){
		set_name(n_name);
		set_version(n_version);
		set_companyName(n_companyName);
		set_copyright(n_copyright);
	}
	#endregion

	#region Destructor
/*	public ~XplLayerDCompiler(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplLayerDCompiler copy = new XplLayerDCompiler();
		copy.set_name(this.p_name);
		copy.set_version(this.p_version);
		copy.set_companyName(this.p_companyName);
		copy.set_copyright(this.p_copyright);
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplLayerDCompiler;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,ZoeHelper .Att_ToString(p_name) );
		if(p_version != "")
			writer.WriteAttributeString( "version" ,ZoeHelper .Att_ToString(p_version) );
		if(p_companyName != "")
			writer.WriteAttributeString( "companyName" ,ZoeHelper .Att_ToString(p_companyName) );
		if(p_copyright != "")
			writer.WriteAttributeString( "copyright" ,ZoeHelper .Att_ToString(p_copyright) );
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
					case "version":
						this.set_version(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "companyName":
						this.set_companyName(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "copyright":
						this.set_copyright(ZoeHelper .StringAtt_To_STRING(reader.Value));
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
		writer.Write((int) 172 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_name );
		writer.Write( p_version );
		writer.Write( p_companyName );
		writer.Write( p_copyright );
		//Escribo recursivamente cada elemento hijo
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_name = reader.ReadString();
		p_version = reader.ReadString();
		p_companyName = reader.ReadString();
		p_copyright = reader.ReadString();
		//Lectura de Elementos
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplLayerDCompiler operator +(XplLayerDCompiler arg1, XplNode arg2)
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
public static XplLayerDCompiler operator +(XplLayerDCompiler arg1, XplNodeList arg2)
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
	public string get_version(){
		return p_version;
	}
	public string get_companyName(){
		return p_companyName;
	}
	public string get_copyright(){
		return p_copyright;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[4];
		ret[0] = "name";
		ret[1] = "version";
		ret[2] = "companyName";
		ret[3] = "copyright";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="name") return p_name.ToString();
		if (attributeName=="version") return p_version.ToString();
		if (attributeName=="companyName") return p_companyName.ToString();
		if (attributeName=="copyright") return p_copyright.ToString();
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
	public string set_version(string new_version){
		string back_version = p_version;
		p_version = new_version;
		return back_version;
	}
	public string set_companyName(string new_companyName){
		string back_companyName = p_companyName;
		p_companyName = new_companyName;
		return back_companyName;
	}
	public string set_copyright(string new_copyright){
		string back_copyright = p_copyright;
		p_copyright = new_copyright;
		return back_copyright;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

