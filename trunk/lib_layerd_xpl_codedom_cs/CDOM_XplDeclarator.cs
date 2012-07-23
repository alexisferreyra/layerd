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
public class XplDeclarator:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_name;
	string p_internalname;
	string p_externalname;
	bool p_donotrender;
	XplVarstorage_enum p_storage;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	string p_address;
	bool p_atomicwrite;
	bool p_atomicread;
	//Variables para Elementos de Secuencia
	XplType p_type;
	XplNode p_aliasref;
	XplInitializerList p_i;
	#endregion

	#region Region de Constructores Publicos
	public XplDeclarator(){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_donotrender = false;
		p_storage = XplVarstorage_enum.AUTO;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_address = "";
		p_atomicwrite = false;
		p_atomicread = false;
		p_type=null;
		p_aliasref=null;
		p_i=null;
}
	public XplDeclarator(string n_name, string n_internalname, string n_externalname, bool n_donotrender, XplVarstorage_enum n_storage, bool n_atomicwrite, bool n_atomicread){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_donotrender = false;
		p_storage = XplVarstorage_enum.AUTO;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_address = "";
		p_atomicwrite = false;
		p_atomicread = false;
		set_name(n_name);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_donotrender(n_donotrender);
		set_storage(n_storage);
		set_atomicwrite(n_atomicwrite);
		set_atomicread(n_atomicread);
		p_type=null;
		p_aliasref=null;
		p_i=null;
	}
	public XplDeclarator(string n_name, string n_internalname, string n_externalname, bool n_donotrender, XplVarstorage_enum n_storage, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, string n_address, bool n_atomicwrite, bool n_atomicread){
		set_name(n_name);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_donotrender(n_donotrender);
		set_storage(n_storage);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_address(n_address);
		set_atomicwrite(n_atomicwrite);
		set_atomicread(n_atomicread);
		p_type=null;
		p_aliasref=null;
		p_i=null;
	}
	public XplDeclarator(XplType n_type, XplNode n_aliasref, XplInitializerList n_i){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_donotrender = false;
		p_storage = XplVarstorage_enum.AUTO;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_address = "";
		p_atomicwrite = false;
		p_atomicread = false;
		p_type=null;
		p_aliasref=null;
		p_i=null;
		set_type(n_type);
		set_aliasref(n_aliasref);
		set_i(n_i);
	}
	public XplDeclarator(string n_name, string n_internalname, string n_externalname, bool n_donotrender, XplVarstorage_enum n_storage, bool n_atomicwrite, bool n_atomicread, XplType n_type, XplNode n_aliasref, XplInitializerList n_i){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_donotrender = false;
		p_storage = XplVarstorage_enum.AUTO;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_address = "";
		p_atomicwrite = false;
		p_atomicread = false;
		set_name(n_name);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_donotrender(n_donotrender);
		set_storage(n_storage);
		set_atomicwrite(n_atomicwrite);
		set_atomicread(n_atomicread);
		p_type=null;
		p_aliasref=null;
		p_i=null;
		set_type(n_type);
		set_aliasref(n_aliasref);
		set_i(n_i);
	}
	public XplDeclarator(string n_name, string n_internalname, string n_externalname, bool n_donotrender, XplVarstorage_enum n_storage, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, string n_address, bool n_atomicwrite, bool n_atomicread, XplType n_type, XplNode n_aliasref, XplInitializerList n_i){
		set_name(n_name);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_donotrender(n_donotrender);
		set_storage(n_storage);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_address(n_address);
		set_atomicwrite(n_atomicwrite);
		set_atomicread(n_atomicread);
		p_type=null;
		p_aliasref=null;
		p_i=null;
		set_type(n_type);
		set_aliasref(n_aliasref);
		set_i(n_i);
	}
	#endregion

	#region Destructor
/*	public ~XplDeclarator(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplDeclarator copy = new XplDeclarator();
		copy.set_name(this.p_name);
		copy.set_internalname(this.p_internalname);
		copy.set_externalname(this.p_externalname);
		copy.set_donotrender(this.p_donotrender);
		copy.set_storage(this.p_storage);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		copy.set_address(this.p_address);
		copy.set_atomicwrite(this.p_atomicwrite);
		copy.set_atomicread(this.p_atomicread);
		if(p_type!=null)copy.set_type((XplType)p_type.Clone());
		if(p_aliasref!=null)copy.set_aliasref(p_aliasref.Clone());
		if(p_i!=null)copy.set_i((XplInitializerList)p_i.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplDeclarator;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,ZoeHelper .Att_ToString(p_name) );
		if(p_internalname != "")
			writer.WriteAttributeString( "internalname" ,ZoeHelper .Att_ToString(p_internalname) );
		if(p_externalname != "")
			writer.WriteAttributeString( "externalname" ,ZoeHelper .Att_ToString(p_externalname) );
		if(p_donotrender != false)
			writer.WriteAttributeString( "donotrender" ,ZoeHelper .Att_ToString(p_donotrender) );
		if(p_storage != XplVarstorage_enum.AUTO)
			writer.WriteAttributeString( "storage" , CodeDOM_STV.XPLVARSTORAGE_ENUM[(int)p_storage] );
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
		if(p_address != "")
			writer.WriteAttributeString( "address" ,ZoeHelper .Att_ToString(p_address) );
		if(p_atomicwrite != false)
			writer.WriteAttributeString( "atomicwrite" ,ZoeHelper .Att_ToString(p_atomicwrite) );
		if(p_atomicread != false)
			writer.WriteAttributeString( "atomicread" ,ZoeHelper .Att_ToString(p_atomicread) );
		//Escribo recursivamente cada elemento hijo
		if(p_type!=null)if(!p_type.Write(writer))result=false;
		if(p_aliasref!=null)if(!p_aliasref.Write(writer))result=false;
		if(p_i!=null)if(!p_i.Write(writer))result=false;
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
					case "internalname":
						this.set_internalname(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "externalname":
						this.set_externalname(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "donotrender":
						this.set_donotrender(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "storage":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLVARSTORAGE_ENUM){
							if(str==tmpStr){this.set_storage((XplVarstorage_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'storage' en elemento '"+this.get_ElementName()+"'.");
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
					case "address":
						this.set_address(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "atomicwrite":
						this.set_atomicwrite(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "atomicread":
						this.set_atomicread(ZoeHelper .StringAtt_To_BOOL(reader.Value));
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
		this.p_aliasref=null;
		this.p_i=null;
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
					case "aliasref":
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_aliasref()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_aliasref(tempNode);
						break;
					case "i":
						tempNode = new XplInitializerList();
						tempNode.Read(reader);
						if(this.get_i()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_i((XplInitializerList)tempNode);
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
		writer.Write((int) 136 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_name );
		writer.Write( p_internalname );
		writer.Write( p_externalname );
		writer.Write( p_donotrender );
		writer.Write( (int)p_storage );
		writer.Write( p_doc );
		writer.Write( p_helpURL );
		writer.Write( p_ldsrc );
		writer.Write( p_iny );
		writer.Write( p_inydata );
		writer.Write( p_inyby );
		writer.Write( p_lddata );
		writer.Write( p_address );
		writer.Write( p_atomicwrite );
		writer.Write( p_atomicread );
		//Escribo recursivamente cada elemento hijo
		if(p_type!=null){
			writer.Write((int)1);
			if(!p_type.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_aliasref!=null){
			writer.Write((int)1);
			if(!p_aliasref.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_i!=null){
			writer.Write((int)1);
			if(!p_i.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_name = reader.ReadString();
		p_internalname = reader.ReadString();
		p_externalname = reader.ReadString();
		p_donotrender = reader.ReadBoolean();
		p_storage = (XplVarstorage_enum)reader.ReadInt32();
		p_doc = reader.ReadString();
		p_helpURL = reader.ReadString();
		p_ldsrc = reader.ReadString();
		p_iny = reader.ReadBoolean();
		p_inydata = reader.ReadString();
		p_inyby = reader.ReadString();
		p_lddata = reader.ReadString();
		p_address = reader.ReadString();
		p_atomicwrite = reader.ReadBoolean();
		p_atomicread = reader.ReadBoolean();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_type = (XplType)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_aliasref = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_i = (XplInitializerList)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplDeclarator operator +(XplDeclarator arg1, XplNode arg2)
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
public static XplDeclarator operator +(XplDeclarator arg1, XplNodeList arg2)
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
	public string get_internalname(){
		return p_internalname;
	}
	public string get_externalname(){
		return p_externalname;
	}
	public bool get_donotrender(){
		return p_donotrender;
	}
	public XplVarstorage_enum get_storage(){
		return p_storage;
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
	public string get_address(){
		return p_address;
	}
	public bool get_atomicwrite(){
		return p_atomicwrite;
	}
	public bool get_atomicread(){
		return p_atomicread;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplType get_type(){
		return p_type;
	}
	public XplNode get_aliasref(){
		return p_aliasref;
	}
	public XplInitializerList get_i(){
		return p_i;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[15];
		ret[0] = "name";
		ret[1] = "internalname";
		ret[2] = "externalname";
		ret[3] = "donotrender";
		ret[4] = "storage";
		ret[5] = "doc";
		ret[6] = "helpURL";
		ret[7] = "ldsrc";
		ret[8] = "iny";
		ret[9] = "inydata";
		ret[10] = "inyby";
		ret[11] = "lddata";
		ret[12] = "address";
		ret[13] = "atomicwrite";
		ret[14] = "atomicread";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="name") return p_name.ToString();
		if (attributeName=="internalname") return p_internalname.ToString();
		if (attributeName=="externalname") return p_externalname.ToString();
		if (attributeName=="donotrender") return p_donotrender.ToString();
		if (attributeName=="storage") return p_storage.ToString();
		if (attributeName=="doc") return p_doc.ToString();
		if (attributeName=="helpURL") return p_helpURL.ToString();
		if (attributeName=="ldsrc") return p_ldsrc.ToString();
		if (attributeName=="iny") return p_iny.ToString();
		if (attributeName=="inydata") return p_inydata.ToString();
		if (attributeName=="inyby") return p_inyby.ToString();
		if (attributeName=="lddata") return p_lddata.ToString();
		if (attributeName=="address") return p_address.ToString();
		if (attributeName=="atomicwrite") return p_atomicwrite.ToString();
		if (attributeName=="atomicread") return p_atomicread.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		list.InsertAtEnd(p_type);
		list.InsertAtEnd(p_aliasref);
		list.InsertAtEnd(p_i);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_name(string new_name){
		string back_name = p_name;
		p_name = new_name;
		return back_name;
	}
	public string set_internalname(string new_internalname){
		string back_internalname = p_internalname;
		p_internalname = new_internalname;
		return back_internalname;
	}
	public string set_externalname(string new_externalname){
		string back_externalname = p_externalname;
		p_externalname = new_externalname;
		return back_externalname;
	}
	public bool set_donotrender(bool new_donotrender){
		bool back_donotrender = p_donotrender;
		p_donotrender = new_donotrender;
		return back_donotrender;
	}
	public XplVarstorage_enum set_storage(XplVarstorage_enum new_storage){
		XplVarstorage_enum back_storage = p_storage;
		p_storage = new_storage;
		return back_storage;
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
	public string set_address(string new_address){
		string back_address = p_address;
		p_address = new_address;
		return back_address;
	}
	public bool set_atomicwrite(bool new_atomicwrite){
		bool back_atomicwrite = p_atomicwrite;
		p_atomicwrite = new_atomicwrite;
		return back_atomicwrite;
	}
	public bool set_atomicread(bool new_atomicread){
		bool back_atomicread = p_atomicread;
		p_atomicread = new_atomicread;
		return back_atomicread;
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
	public XplNode set_aliasref(XplNode new_aliasref){
		if(new_aliasref.get_ContentTypeName()!=CodeDOMTypes.String){
			this.set_ErrorString("El nodo que intenta asignar a la propiedad es de un tipo incorrecto.");
			return null;
		}
		XplNode back_aliasref = p_aliasref;
		p_aliasref = new_aliasref;
		if(p_aliasref!=null){
			p_aliasref.set_Parent(this);
			p_aliasref.set_ElementName("aliasref");
		}
		return back_aliasref;
	}
	public XplInitializerList set_i(XplInitializerList new_i){
		XplInitializerList back_i = p_i;
		p_i = new_i;
		if(p_i!=null){
			p_i.set_ElementName("i");
			p_i.set_Parent(this);
		}
		return back_i;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplType new_type(){
		XplType node = new XplType();
		node.set_ElementName("type");
		return node;
	}
	static public XplNode new_aliasref(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_ElementName("aliasref");
		return node;
	}
	static public XplInitializerList new_i(){
		XplInitializerList node = new XplInitializerList();
		node.set_ElementName("i");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

