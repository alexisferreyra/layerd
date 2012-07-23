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
public class XplInherit:  XplNode{

	#region Variables privadas para atributos y elementos
	XplAccesstype_enum p_access;
	bool p_virtual;
	bool p_auto;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplType p_type;
	XplType p_originalType;
	#endregion

	#region Region de Constructores Publicos
	public XplInherit(){
		p_access = XplAccesstype_enum.PUBLIC;
		p_virtual = true;
		p_auto = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_type=null;
		p_originalType=null;
}
	public XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto){
		p_access = XplAccesstype_enum.PUBLIC;
		p_virtual = true;
		p_auto = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_access(n_access);
		set_virtual(n_virtual);
		set_auto(n_auto);
		p_type=null;
		p_originalType=null;
	}
	public XplInherit(XplType n_type){
		p_access = XplAccesstype_enum.PUBLIC;
		p_virtual = true;
		p_auto = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_type=null;
		p_originalType=null;
		set_type(n_type);
	}
	public XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, XplType n_type){
		p_access = XplAccesstype_enum.PUBLIC;
		p_virtual = true;
		p_auto = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_access(n_access);
		set_virtual(n_virtual);
		set_auto(n_auto);
		p_type=null;
		p_originalType=null;
		set_type(n_type);
	}
	public XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
		set_access(n_access);
		set_virtual(n_virtual);
		set_auto(n_auto);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_type=null;
		p_originalType=null;
	}
	public XplInherit(XplType n_type, XplType n_originalType){
		p_access = XplAccesstype_enum.PUBLIC;
		p_virtual = true;
		p_auto = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_type=null;
		p_originalType=null;
		set_type(n_type);
		set_originalType(n_originalType);
	}
	public XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType n_type){
		set_access(n_access);
		set_virtual(n_virtual);
		set_auto(n_auto);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_access(n_access);
		set_virtual(n_virtual);
		set_auto(n_auto);
		p_type=null;
		p_originalType=null;
	}
	public XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, XplType n_type, XplType n_originalType){
		p_access = XplAccesstype_enum.PUBLIC;
		p_virtual = true;
		p_auto = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_access(n_access);
		set_virtual(n_virtual);
		set_auto(n_auto);
		p_type=null;
		p_originalType=null;
		set_type(n_type);
		set_originalType(n_originalType);
	}
	public XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType n_type, XplType n_originalType){
		set_access(n_access);
		set_virtual(n_virtual);
		set_auto(n_auto);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_type=null;
		p_originalType=null;
		set_type(n_type);
		set_originalType(n_originalType);
	}
	#endregion

	#region Destructor
/*	public ~XplInherit(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplInherit copy = new XplInherit();
		copy.set_access(this.p_access);
		copy.set_virtual(this.p_virtual);
		copy.set_auto(this.p_auto);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_type!=null)copy.set_type((XplType)p_type.Clone());
		if(p_originalType!=null)copy.set_originalType((XplType)p_originalType.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplInherit;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_access != XplAccesstype_enum.PUBLIC)
			writer.WriteAttributeString( "access" , CodeDOM_STV.XPLACCESSTYPE_ENUM[(int)p_access] );
		if(p_virtual != true)
			writer.WriteAttributeString( "virtual" ,ZoeHelper .Att_ToString(p_virtual) );
		if(p_auto != false)
			writer.WriteAttributeString( "auto" ,ZoeHelper .Att_ToString(p_auto) );
		if(p_doc != "")
			writer.WriteAttributeString( "doc" ,ZoeHelper .Att_ToString(p_doc) );
		if(p_helpURL != "")
			writer.WriteAttributeString( "helpURL" ,ZoeHelper .Att_ToString(p_helpURL) );
		if(p_ldsrc != "")
			writer.WriteAttributeString( "ldsrc" ,ZoeHelper .Att_ToString(p_ldsrc) );
		if(p_iny != false)
			writer.WriteAttributeString( "iny" ,ZoeHelper .Att_ToString(p_iny) );
		if(p_inydata != "")
			writer.WriteAttributeString( "inydata" ,ZoeHelper .Att_ToString(p_inydata) );
		if(p_inyby != "")
			writer.WriteAttributeString( "inyby" ,ZoeHelper .Att_ToString(p_inyby) );
		if(p_lddata != "")
			writer.WriteAttributeString( "lddata" ,ZoeHelper .Att_ToString(p_lddata) );
		//Escribo recursivamente cada elemento hijo
		if(p_type!=null)if(!p_type.Write(writer))result=false;
		if(p_originalType!=null)if(!p_originalType.Write(writer))result=false;
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
					case "access":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLACCESSTYPE_ENUM){
							if(str==tmpStr){this.set_access((XplAccesstype_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'access' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "virtual":
						this.set_virtual(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "auto":
						this.set_auto(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "doc":
						this.set_doc(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "helpURL":
						this.set_helpURL(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "ldsrc":
						this.set_ldsrc(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "iny":
						this.set_iny(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "inydata":
						this.set_inydata(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "inyby":
						this.set_inyby(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "lddata":
						this.set_lddata(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Atributo '"+reader.Name+"' invalido en elemento '"+this.get_ElementName()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		//Borro todo posible nodo en memoria
		this.p_type=null;
		this.p_originalType=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "type":
						tempNode = new XplType();
						tempNode.Read(reader);
						if(this.get_type()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_type((XplType)tempNode);
						break;
					case "originalType":
						tempNode = new XplType();
						tempNode.Read(reader);
						if(this.get_originalType()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_originalType((XplType)tempNode);
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nombre de nodo '"+reader.Name+"' inesperado como hijo de elemento '"+this.get_ElementName()+"'.");
					}
					break;
				case XmlNodeType.EndElement:
					break;
				case XmlNodeType.Text:
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".No se esperaba texto en este nodo.");
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
		writer.Write((int) 138 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( (int)p_access );
		writer.Write( p_virtual );
		writer.Write( p_auto );
		writer.Write( p_doc );
		writer.Write( p_helpURL );
		writer.Write( p_ldsrc );
		writer.Write( p_iny );
		writer.Write( p_inydata );
		writer.Write( p_inyby );
		writer.Write( p_lddata );
		//Escribo recursivamente cada elemento hijo
		if(p_type!=null){
			writer.Write((int)1);
			if(!p_type.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_originalType!=null){
			writer.Write((int)1);
			if(!p_originalType.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_access = (XplAccesstype_enum)reader.ReadInt32();
		p_virtual = reader.ReadBoolean();
		p_auto = reader.ReadBoolean();
		p_doc = reader.ReadString();
		p_helpURL = reader.ReadString();
		p_ldsrc = reader.ReadString();
		p_iny = reader.ReadBoolean();
		p_inydata = reader.ReadString();
		p_inyby = reader.ReadString();
		p_lddata = reader.ReadString();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_type = (XplType)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_originalType = (XplType)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplInherit operator +(XplInherit arg1, XplNode arg2)
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
public static XplInherit operator +(XplInherit arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public XplAccesstype_enum get_access(){
		return p_access;
	}
	public bool get_virtual(){
		return p_virtual;
	}
	public bool get_auto(){
		return p_auto;
	}
	public override string get_doc(){
		return p_doc;
	}
	public override string get_helpURL(){
		return p_helpURL;
	}
	public override string get_ldsrc(){
		return p_ldsrc;
	}
	public override bool get_iny(){
		return p_iny;
	}
	public override string get_inydata(){
		return p_inydata;
	}
	public override string get_inyby(){
		return p_inyby;
	}
	public override string get_lddata(){
		return p_lddata;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplType get_type(){
		return p_type;
	}
	public XplType get_originalType(){
		return p_originalType;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[10];
		ret[0] = "access";
		ret[1] = "virtual";
		ret[2] = "auto";
		ret[3] = "doc";
		ret[4] = "helpURL";
		ret[5] = "ldsrc";
		ret[6] = "iny";
		ret[7] = "inydata";
		ret[8] = "inyby";
		ret[9] = "lddata";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="access") return p_access.ToString();
		if (attributeName=="virtual") return p_virtual.ToString();
		if (attributeName=="auto") return p_auto.ToString();
		if (attributeName=="doc") return p_doc.ToString();
		if (attributeName=="helpURL") return p_helpURL.ToString();
		if (attributeName=="ldsrc") return p_ldsrc.ToString();
		if (attributeName=="iny") return p_iny.ToString();
		if (attributeName=="inydata") return p_inydata.ToString();
		if (attributeName=="inyby") return p_inyby.ToString();
		if (attributeName=="lddata") return p_lddata.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		list.InsertAtEnd(p_type);
		list.InsertAtEnd(p_originalType);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public XplAccesstype_enum set_access(XplAccesstype_enum new_access){
		XplAccesstype_enum back_access = p_access;
		p_access = new_access;
		return back_access;
	}
	public bool set_virtual(bool new_virtual){
		bool back_virtual = p_virtual;
		p_virtual = new_virtual;
		return back_virtual;
	}
	public bool set_auto(bool new_auto){
		bool back_auto = p_auto;
		p_auto = new_auto;
		return back_auto;
	}
	public override string set_doc(string new_doc){
		string back_doc = p_doc;
		p_doc = new_doc;
		return back_doc;
	}
	public override string set_helpURL(string new_helpURL){
		string back_helpURL = p_helpURL;
		p_helpURL = new_helpURL;
		return back_helpURL;
	}
	public override string set_ldsrc(string new_ldsrc){
		string back_ldsrc = p_ldsrc;
		p_ldsrc = new_ldsrc;
		return back_ldsrc;
	}
	public override bool set_iny(bool new_iny){
		bool back_iny = p_iny;
		p_iny = new_iny;
		return back_iny;
	}
	public override string set_inydata(string new_inydata){
		string back_inydata = p_inydata;
		p_inydata = new_inydata;
		return back_inydata;
	}
	public override string set_inyby(string new_inyby){
		string back_inyby = p_inyby;
		p_inyby = new_inyby;
		return back_inyby;
	}
	public override string set_lddata(string new_lddata){
		string back_lddata = p_lddata;
		p_lddata = new_lddata;
		return back_lddata;
	}

	//Funciones para setear Elementos de Secuencia
	public XplType set_type(XplType new_type){
		XplType back_type = p_type;
		p_type = new_type;
		if(p_type!=null){
			p_type.set_ElementName("type");
			p_type.set_Parent(this);
		}
		return back_type;
	}
	public XplType set_originalType(XplType new_originalType){
		XplType back_originalType = p_originalType;
		p_originalType = new_originalType;
		if(p_originalType!=null){
			p_originalType.set_ElementName("originalType");
			p_originalType.set_Parent(this);
		}
		return back_originalType;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplType new_type(){
		XplType node = new XplType();
		node.set_ElementName("type");
		return node;
	}
	static public XplType new_originalType(){
		XplType node = new XplType();
		node.set_ElementName("originalType");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

