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
public class XplType:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_typename;
	bool p_ispointer;
	bool p_isarray;
	XplPointertype_enum p_pointertype;
	XplFactorytype_enum p_ftype;
	bool p_volatile;
	bool p_const;
	bool p_exec;
	string p_typeStr;
	bool p_replaceParent;
	bool p_customTypeCheck;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplType p_dt;
	XplExpression p_ae;
	XplPointerinfo p_pi;
	XplFunctioncall p_fc;
	#endregion

	#region Region de Constructores Publicos
	public XplType(){
		p_typename = "";
		p_ispointer = false;
		p_isarray = false;
		p_pointertype = XplPointertype_enum.DEFAULT;
		p_ftype = XplFactorytype_enum.NONE;
		p_volatile = false;
		p_const = false;
		p_exec = false;
		p_typeStr = "";
		p_replaceParent = false;
		p_customTypeCheck = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_dt=null;
		p_ae=null;
		p_pi=null;
		p_fc=null;
}
	public XplType(bool n_ispointer, bool n_isarray, XplPointertype_enum n_pointertype, XplFactorytype_enum n_ftype, bool n_volatile, bool n_const, bool n_exec, bool n_replaceParent, bool n_customTypeCheck){
		p_typename = "";
		p_ispointer = false;
		p_isarray = false;
		p_pointertype = XplPointertype_enum.DEFAULT;
		p_ftype = XplFactorytype_enum.NONE;
		p_volatile = false;
		p_const = false;
		p_exec = false;
		p_typeStr = "";
		p_replaceParent = false;
		p_customTypeCheck = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_ispointer(n_ispointer);
		set_isarray(n_isarray);
		set_pointertype(n_pointertype);
		set_ftype(n_ftype);
		set_volatile(n_volatile);
		set_const(n_const);
		set_exec(n_exec);
		set_replaceParent(n_replaceParent);
		set_customTypeCheck(n_customTypeCheck);
		p_dt=null;
		p_ae=null;
		p_pi=null;
		p_fc=null;
	}
	public XplType(string n_typename, bool n_ispointer, bool n_isarray, XplPointertype_enum n_pointertype, XplFactorytype_enum n_ftype, bool n_volatile, bool n_const, bool n_exec, string n_typeStr, bool n_replaceParent, bool n_customTypeCheck, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
		set_typename(n_typename);
		set_ispointer(n_ispointer);
		set_isarray(n_isarray);
		set_pointertype(n_pointertype);
		set_ftype(n_ftype);
		set_volatile(n_volatile);
		set_const(n_const);
		set_exec(n_exec);
		set_typeStr(n_typeStr);
		set_replaceParent(n_replaceParent);
		set_customTypeCheck(n_customTypeCheck);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_dt=null;
		p_ae=null;
		p_pi=null;
		p_fc=null;
	}
	public XplType(XplType n_dt, XplExpression n_ae, XplPointerinfo n_pi, XplFunctioncall n_fc){
		p_typename = "";
		p_ispointer = false;
		p_isarray = false;
		p_pointertype = XplPointertype_enum.DEFAULT;
		p_ftype = XplFactorytype_enum.NONE;
		p_volatile = false;
		p_const = false;
		p_exec = false;
		p_typeStr = "";
		p_replaceParent = false;
		p_customTypeCheck = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_dt=null;
		p_ae=null;
		p_pi=null;
		p_fc=null;
		set_dt(n_dt);
		set_ae(n_ae);
		set_pi(n_pi);
		set_fc(n_fc);
	}
	public XplType(bool n_ispointer, bool n_isarray, XplPointertype_enum n_pointertype, XplFactorytype_enum n_ftype, bool n_volatile, bool n_const, bool n_exec, bool n_replaceParent, bool n_customTypeCheck, XplType n_dt, XplExpression n_ae, XplPointerinfo n_pi, XplFunctioncall n_fc){
		p_typename = "";
		p_ispointer = false;
		p_isarray = false;
		p_pointertype = XplPointertype_enum.DEFAULT;
		p_ftype = XplFactorytype_enum.NONE;
		p_volatile = false;
		p_const = false;
		p_exec = false;
		p_typeStr = "";
		p_replaceParent = false;
		p_customTypeCheck = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_ispointer(n_ispointer);
		set_isarray(n_isarray);
		set_pointertype(n_pointertype);
		set_ftype(n_ftype);
		set_volatile(n_volatile);
		set_const(n_const);
		set_exec(n_exec);
		set_replaceParent(n_replaceParent);
		set_customTypeCheck(n_customTypeCheck);
		p_dt=null;
		p_ae=null;
		p_pi=null;
		p_fc=null;
		set_dt(n_dt);
		set_ae(n_ae);
		set_pi(n_pi);
		set_fc(n_fc);
	}
	public XplType(string n_typename, bool n_ispointer, bool n_isarray, XplPointertype_enum n_pointertype, XplFactorytype_enum n_ftype, bool n_volatile, bool n_const, bool n_exec, string n_typeStr, bool n_replaceParent, bool n_customTypeCheck, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType n_dt, XplExpression n_ae, XplPointerinfo n_pi, XplFunctioncall n_fc){
		set_typename(n_typename);
		set_ispointer(n_ispointer);
		set_isarray(n_isarray);
		set_pointertype(n_pointertype);
		set_ftype(n_ftype);
		set_volatile(n_volatile);
		set_const(n_const);
		set_exec(n_exec);
		set_typeStr(n_typeStr);
		set_replaceParent(n_replaceParent);
		set_customTypeCheck(n_customTypeCheck);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_dt=null;
		p_ae=null;
		p_pi=null;
		p_fc=null;
		set_dt(n_dt);
		set_ae(n_ae);
		set_pi(n_pi);
		set_fc(n_fc);
	}
	#endregion

	#region Destructor
/*	public ~XplType(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplType copy = new XplType();
		copy.set_typename(this.p_typename);
		copy.set_ispointer(this.p_ispointer);
		copy.set_isarray(this.p_isarray);
		copy.set_pointertype(this.p_pointertype);
		copy.set_ftype(this.p_ftype);
		copy.set_volatile(this.p_volatile);
		copy.set_const(this.p_const);
		copy.set_exec(this.p_exec);
		copy.set_typeStr(this.p_typeStr);
		copy.set_replaceParent(this.p_replaceParent);
		copy.set_customTypeCheck(this.p_customTypeCheck);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_dt!=null)copy.set_dt((XplType)p_dt.Clone());
		if(p_ae!=null)copy.set_ae((XplExpression)p_ae.Clone());
		if(p_pi!=null)copy.set_pi((XplPointerinfo)p_pi.Clone());
		if(p_fc!=null)copy.set_fc((XplFunctioncall)p_fc.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplType;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_typename != "")
			writer.WriteAttributeString( "typename" ,ZoeHelper .Att_ToString(p_typename) );
		if(p_ispointer != false)
			writer.WriteAttributeString( "ispointer" ,ZoeHelper .Att_ToString(p_ispointer) );
		if(p_isarray != false)
			writer.WriteAttributeString( "isarray" ,ZoeHelper .Att_ToString(p_isarray) );
		if(p_pointertype != XplPointertype_enum.DEFAULT)
			writer.WriteAttributeString( "pointertype" , CodeDOM_STV.XPLPOINTERTYPE_ENUM[(int)p_pointertype] );
		if(p_ftype != XplFactorytype_enum.NONE)
			writer.WriteAttributeString( "ftype" , CodeDOM_STV.XPLFACTORYTYPE_ENUM[(int)p_ftype] );
		if(p_volatile != false)
			writer.WriteAttributeString( "volatile" ,ZoeHelper .Att_ToString(p_volatile) );
		if(p_const != false)
			writer.WriteAttributeString( "const" ,ZoeHelper .Att_ToString(p_const) );
		if(p_exec != false)
			writer.WriteAttributeString( "exec" ,ZoeHelper .Att_ToString(p_exec) );
		if(p_typeStr != "")
			writer.WriteAttributeString( "typeStr" ,ZoeHelper .Att_ToString(p_typeStr) );
		if(p_replaceParent != false)
			writer.WriteAttributeString( "replaceParent" ,ZoeHelper .Att_ToString(p_replaceParent) );
		if(p_customTypeCheck != false)
			writer.WriteAttributeString( "customTypeCheck" ,ZoeHelper .Att_ToString(p_customTypeCheck) );
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
		if(p_dt!=null)if(!p_dt.Write(writer))result=false;
		if(p_ae!=null)if(!p_ae.Write(writer))result=false;
		if(p_pi!=null)if(!p_pi.Write(writer))result=false;
		if(p_fc!=null)if(!p_fc.Write(writer))result=false;
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
					case "typename":
						this.set_typename(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "ispointer":
						this.set_ispointer(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "isarray":
						this.set_isarray(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "pointertype":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLPOINTERTYPE_ENUM){
							if(str==tmpStr){this.set_pointertype((XplPointertype_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'pointertype' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "ftype":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLFACTORYTYPE_ENUM){
							if(str==tmpStr){this.set_ftype((XplFactorytype_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'ftype' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "volatile":
						this.set_volatile(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "const":
						this.set_const(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "exec":
						this.set_exec(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "typeStr":
						this.set_typeStr(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "replaceParent":
						this.set_replaceParent(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "customTypeCheck":
						this.set_customTypeCheck(ZoeHelper .StringAtt_To_BOOL(reader.Value));
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
		this.p_dt=null;
		this.p_ae=null;
		this.p_pi=null;
		this.p_fc=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "dt":
						tempNode = new XplType();
						tempNode.Read(reader);
						if(this.get_dt()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_dt((XplType)tempNode);
						break;
					case "ae":
						tempNode = new XplExpression();
						tempNode.Read(reader);
						if(this.get_ae()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_ae((XplExpression)tempNode);
						break;
					case "pi":
						tempNode = new XplPointerinfo();
						tempNode.Read(reader);
						if(this.get_pi()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_pi((XplPointerinfo)tempNode);
						break;
					case "fc":
						tempNode = new XplFunctioncall();
						tempNode.Read(reader);
						if(this.get_fc()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_fc((XplFunctioncall)tempNode);
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
		writer.Write((int) 112 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_typename );
		writer.Write( p_ispointer );
		writer.Write( p_isarray );
		writer.Write( (int)p_pointertype );
		writer.Write( (int)p_ftype );
		writer.Write( p_volatile );
		writer.Write( p_const );
		writer.Write( p_exec );
		writer.Write( p_typeStr );
		writer.Write( p_replaceParent );
		writer.Write( p_customTypeCheck );
		writer.Write( p_doc );
		writer.Write( p_helpURL );
		writer.Write( p_ldsrc );
		writer.Write( p_iny );
		writer.Write( p_inydata );
		writer.Write( p_inyby );
		writer.Write( p_lddata );
		//Escribo recursivamente cada elemento hijo
		if(p_dt!=null){
			writer.Write((int)1);
			if(!p_dt.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_ae!=null){
			writer.Write((int)1);
			if(!p_ae.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_pi!=null){
			writer.Write((int)1);
			if(!p_pi.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_fc!=null){
			writer.Write((int)1);
			if(!p_fc.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_typename = reader.ReadString();
		p_ispointer = reader.ReadBoolean();
		p_isarray = reader.ReadBoolean();
		p_pointertype = (XplPointertype_enum)reader.ReadInt32();
		p_ftype = (XplFactorytype_enum)reader.ReadInt32();
		p_volatile = reader.ReadBoolean();
		p_const = reader.ReadBoolean();
		p_exec = reader.ReadBoolean();
		p_typeStr = reader.ReadString();
		p_replaceParent = reader.ReadBoolean();
		p_customTypeCheck = reader.ReadBoolean();
		p_doc = reader.ReadString();
		p_helpURL = reader.ReadString();
		p_ldsrc = reader.ReadString();
		p_iny = reader.ReadBoolean();
		p_inydata = reader.ReadString();
		p_inyby = reader.ReadString();
		p_lddata = reader.ReadString();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_dt = (XplType)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_ae = (XplExpression)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_pi = (XplPointerinfo)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_fc = (XplFunctioncall)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplType operator +(XplType arg1, XplNode arg2)
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
public static XplType operator +(XplType arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_typename(){
		return p_typename;
	}
	public bool get_ispointer(){
		return p_ispointer;
	}
	public bool get_isarray(){
		return p_isarray;
	}
	public XplPointertype_enum get_pointertype(){
		return p_pointertype;
	}
	public XplFactorytype_enum get_ftype(){
		return p_ftype;
	}
	public bool get_volatile(){
		return p_volatile;
	}
	public bool get_const(){
		return p_const;
	}
	public bool get_exec(){
		return p_exec;
	}
	public string get_typeStr(){
		return p_typeStr;
	}
	public bool get_replaceParent(){
		return p_replaceParent;
	}
	public bool get_customTypeCheck(){
		return p_customTypeCheck;
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
	public XplType get_dt(){
		return p_dt;
	}
	public XplExpression get_ae(){
		return p_ae;
	}
	public XplPointerinfo get_pi(){
		return p_pi;
	}
	public XplFunctioncall get_fc(){
		return p_fc;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[18];
		ret[0] = "typename";
		ret[1] = "ispointer";
		ret[2] = "isarray";
		ret[3] = "pointertype";
		ret[4] = "ftype";
		ret[5] = "volatile";
		ret[6] = "const";
		ret[7] = "exec";
		ret[8] = "typeStr";
		ret[9] = "replaceParent";
		ret[10] = "customTypeCheck";
		ret[11] = "doc";
		ret[12] = "helpURL";
		ret[13] = "ldsrc";
		ret[14] = "iny";
		ret[15] = "inydata";
		ret[16] = "inyby";
		ret[17] = "lddata";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="typename") return p_typename.ToString();
		if (attributeName=="ispointer") return p_ispointer.ToString();
		if (attributeName=="isarray") return p_isarray.ToString();
		if (attributeName=="pointertype") return p_pointertype.ToString();
		if (attributeName=="ftype") return p_ftype.ToString();
		if (attributeName=="volatile") return p_volatile.ToString();
		if (attributeName=="const") return p_const.ToString();
		if (attributeName=="exec") return p_exec.ToString();
		if (attributeName=="typeStr") return p_typeStr.ToString();
		if (attributeName=="replaceParent") return p_replaceParent.ToString();
		if (attributeName=="customTypeCheck") return p_customTypeCheck.ToString();
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
		list.InsertAtEnd(p_dt);
		list.InsertAtEnd(p_ae);
		list.InsertAtEnd(p_pi);
		list.InsertAtEnd(p_fc);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_typename(string new_typename){
		string back_typename = p_typename;
		p_typename = new_typename;
		return back_typename;
	}
	public bool set_ispointer(bool new_ispointer){
		bool back_ispointer = p_ispointer;
		p_ispointer = new_ispointer;
		return back_ispointer;
	}
	public bool set_isarray(bool new_isarray){
		bool back_isarray = p_isarray;
		p_isarray = new_isarray;
		return back_isarray;
	}
	public XplPointertype_enum set_pointertype(XplPointertype_enum new_pointertype){
		XplPointertype_enum back_pointertype = p_pointertype;
		p_pointertype = new_pointertype;
		return back_pointertype;
	}
	public XplFactorytype_enum set_ftype(XplFactorytype_enum new_ftype){
		XplFactorytype_enum back_ftype = p_ftype;
		p_ftype = new_ftype;
		return back_ftype;
	}
	public bool set_volatile(bool new_volatile){
		bool back_volatile = p_volatile;
		p_volatile = new_volatile;
		return back_volatile;
	}
	public bool set_const(bool new_const){
		bool back_const = p_const;
		p_const = new_const;
		return back_const;
	}
	public bool set_exec(bool new_exec){
		bool back_exec = p_exec;
		p_exec = new_exec;
		return back_exec;
	}
	public string set_typeStr(string new_typeStr){
		string back_typeStr = p_typeStr;
		p_typeStr = new_typeStr;
		return back_typeStr;
	}
	public bool set_replaceParent(bool new_replaceParent){
		bool back_replaceParent = p_replaceParent;
		p_replaceParent = new_replaceParent;
		return back_replaceParent;
	}
	public bool set_customTypeCheck(bool new_customTypeCheck){
		bool back_customTypeCheck = p_customTypeCheck;
		p_customTypeCheck = new_customTypeCheck;
		return back_customTypeCheck;
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
	public XplType set_dt(XplType new_dt){
		XplType back_dt = p_dt;
		p_dt = new_dt;
		if(p_dt!=null){
			p_dt.set_ElementName("dt");
			p_dt.set_Parent(this);
		}
		return back_dt;
	}
	public XplExpression set_ae(XplExpression new_ae){
		XplExpression back_ae = p_ae;
		p_ae = new_ae;
		if(p_ae!=null){
			p_ae.set_ElementName("ae");
			p_ae.set_Parent(this);
		}
		return back_ae;
	}
	public XplPointerinfo set_pi(XplPointerinfo new_pi){
		XplPointerinfo back_pi = p_pi;
		p_pi = new_pi;
		if(p_pi!=null){
			p_pi.set_ElementName("pi");
			p_pi.set_Parent(this);
		}
		return back_pi;
	}
	public XplFunctioncall set_fc(XplFunctioncall new_fc){
		XplFunctioncall back_fc = p_fc;
		p_fc = new_fc;
		if(p_fc!=null){
			p_fc.set_ElementName("fc");
			p_fc.set_Parent(this);
		}
		return back_fc;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplType new_dt(){
		XplType node = new XplType();
		node.set_ElementName("dt");
		return node;
	}
	static public XplExpression new_ae(){
		XplExpression node = new XplExpression();
		node.set_ElementName("ae");
		return node;
	}
	static public XplPointerinfo new_pi(){
		XplPointerinfo node = new XplPointerinfo();
		node.set_ElementName("pi");
		return node;
	}
	static public XplFunctioncall new_fc(){
		XplFunctioncall node = new XplFunctioncall();
		node.set_ElementName("fc");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

