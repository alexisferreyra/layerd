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
public class XplPlatform:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_name;
	string p_version;
	XplPlatformMatch_enum p_match;
	string p_customMatcher;
	#endregion

	#region Region de Constructores Publicos
	public XplPlatform(){
		p_name = "";
		p_version = "";
		p_match = XplPlatformMatch_enum.LIKE;
		p_customMatcher = "";
}
	public XplPlatform(string n_name, XplPlatformMatch_enum n_match){
		p_name = "";
		p_version = "";
		p_match = XplPlatformMatch_enum.LIKE;
		p_customMatcher = "";
		set_name(n_name);
		set_match(n_match);
	}
	public XplPlatform(string n_name, string n_version, XplPlatformMatch_enum n_match, string n_customMatcher){
		set_name(n_name);
		set_version(n_version);
		set_match(n_match);
		set_customMatcher(n_customMatcher);
	}
	#endregion

	#region Destructor
/*	public ~XplPlatform(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplPlatform copy = new XplPlatform();
		copy.set_name(this.p_name);
		copy.set_version(this.p_version);
		copy.set_match(this.p_match);
		copy.set_customMatcher(this.p_customMatcher);
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplPlatform;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,ZoeHelper .Att_ToString(p_name) );
		if(p_version != "")
			writer.WriteAttributeString( "version" ,ZoeHelper .Att_ToString(p_version) );
		if(p_match != XplPlatformMatch_enum.LIKE)
			writer.WriteAttributeString( "match" , CodeDOM_STV.XPLPLATFORMMATCH_ENUM[(int)p_match] );
		if(p_customMatcher != "")
			writer.WriteAttributeString( "customMatcher" ,ZoeHelper .Att_ToString(p_customMatcher) );
		//Escribo recursivamente cada elemento hijo
		//Cierro el elemento
		writer.WriteEndElement();
		return result;
	}

	public override XplNode Read(XplReader reader){
		this.set_ElementName( reader.Name );
		//Lectura de Atributos
		if( reader.HasAttributes ){
			string tmpStr="";bool flag=false;int count=0;
			for(int i=0; i < reader.AttributeCount ; i++){
				reader.MoveToAttribute(i);
				switch(reader.Name){
					case "name":
						this.set_name(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "version":
						this.set_version(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "match":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLPLATFORMMATCH_ENUM){
							if(str==tmpStr){this.set_match((XplPlatformMatch_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'match' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "customMatcher":
						this.set_customMatcher(ZoeHelper .StringAtt_To_STRING(reader.Value));
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
		writer.Write((int) 104 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_name );
		writer.Write( p_version );
		writer.Write( (int)p_match );
		writer.Write( p_customMatcher );
		//Escribo recursivamente cada elemento hijo
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_name = reader.ReadString();
		p_version = reader.ReadString();
		p_match = (XplPlatformMatch_enum)reader.ReadInt32();
		p_customMatcher = reader.ReadString();
		//Lectura de Elementos
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplPlatform operator +(XplPlatform arg1, XplNode arg2)
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
public static XplPlatform operator +(XplPlatform arg1, XplNodeList arg2)
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
	public XplPlatformMatch_enum get_match(){
		return p_match;
	}
	public string get_customMatcher(){
		return p_customMatcher;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[4];
		ret[0] = "name";
		ret[1] = "version";
		ret[2] = "match";
		ret[3] = "customMatcher";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="name") return p_name.ToString();
		if (attributeName=="version") return p_version.ToString();
		if (attributeName=="match") return p_match.ToString();
		if (attributeName=="customMatcher") return p_customMatcher.ToString();
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
	public XplPlatformMatch_enum set_match(XplPlatformMatch_enum new_match){
		XplPlatformMatch_enum back_match = p_match;
		p_match = new_match;
		return back_match;
	}
	public string set_customMatcher(string new_customMatcher){
		string back_customMatcher = p_customMatcher;
		p_customMatcher = new_customMatcher;
		return back_customMatcher;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

