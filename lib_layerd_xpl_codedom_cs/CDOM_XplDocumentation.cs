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
public class XplDocumentation:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_short;
	string p_source;
	string p_key;
	XplDocsourcetype_enum p_sourcetype;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplNode p_heading;
	XplNode p_title;
	XplNode p_body;
	XplNode p_examples;
	XplNode p_seealso;
	XplNode p_footer;
	XplNode p_summary;
	XplNode p_params;
	XplNode p_returntype;
	#endregion

	#region Region de Constructores Publicos
	public XplDocumentation(){
		p_short = "";
		p_source = "";
		p_key = "";
		p_sourcetype = (XplDocsourcetype_enum)0;
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_heading=null;
		p_title=null;
		p_body=null;
		p_examples=null;
		p_seealso=null;
		p_footer=null;
		p_summary=null;
		p_params=null;
		p_returntype=null;
}
	public XplDocumentation(XplNode n_heading, XplNode n_title, XplNode n_body, XplNode n_examples, XplNode n_seealso, XplNode n_footer, XplNode n_summary, XplNode n_params, XplNode n_returntype){
		p_short = "";
		p_source = "";
		p_key = "";
		p_sourcetype = (XplDocsourcetype_enum)0;
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_heading=null;
		p_title=null;
		p_body=null;
		p_examples=null;
		p_seealso=null;
		p_footer=null;
		p_summary=null;
		p_params=null;
		p_returntype=null;
		set_heading(n_heading);
		set_title(n_title);
		set_body(n_body);
		set_examples(n_examples);
		set_seealso(n_seealso);
		set_footer(n_footer);
		set_summary(n_summary);
		set_params(n_params);
		set_returntype(n_returntype);
	}
	public XplDocumentation(string n_short, string n_source, string n_key, XplDocsourcetype_enum n_sourcetype, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
		set_short(n_short);
		set_source(n_source);
		set_key(n_key);
		set_sourcetype(n_sourcetype);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_heading=null;
		p_title=null;
		p_body=null;
		p_examples=null;
		p_seealso=null;
		p_footer=null;
		p_summary=null;
		p_params=null;
		p_returntype=null;
	}
	public XplDocumentation(string n_short, string n_source, string n_key, XplDocsourcetype_enum n_sourcetype, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNode n_heading, XplNode n_title, XplNode n_body, XplNode n_examples, XplNode n_seealso, XplNode n_footer, XplNode n_summary, XplNode n_params, XplNode n_returntype){
		set_short(n_short);
		set_source(n_source);
		set_key(n_key);
		set_sourcetype(n_sourcetype);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_heading=null;
		p_title=null;
		p_body=null;
		p_examples=null;
		p_seealso=null;
		p_footer=null;
		p_summary=null;
		p_params=null;
		p_returntype=null;
	}
	#endregion

	#region Destructor
/*	public ~XplDocumentation(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplDocumentation copy = new XplDocumentation();
		copy.set_short(this.p_short);
		copy.set_source(this.p_source);
		copy.set_key(this.p_key);
		copy.set_sourcetype(this.p_sourcetype);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_heading!=null)copy.set_heading(p_heading.Clone());
		if(p_title!=null)copy.set_title(p_title.Clone());
		if(p_body!=null)copy.set_body(p_body.Clone());
		if(p_examples!=null)copy.set_examples(p_examples.Clone());
		if(p_seealso!=null)copy.set_seealso(p_seealso.Clone());
		if(p_footer!=null)copy.set_footer(p_footer.Clone());
		if(p_summary!=null)copy.set_summary(p_summary.Clone());
		if(p_params!=null)copy.set_params(p_params.Clone());
		if(p_returntype!=null)copy.set_returntype(p_returntype.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplDocumentation;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_short != "")
			writer.WriteAttributeString( "short" ,ZoeHelper .Att_ToString(p_short) );
		if(p_source != "")
			writer.WriteAttributeString( "source" ,ZoeHelper .Att_ToString(p_source) );
		if(p_key != "")
			writer.WriteAttributeString( "key" ,ZoeHelper .Att_ToString(p_key) );
		if(p_sourcetype != (XplDocsourcetype_enum)0)
			writer.WriteAttributeString( "sourcetype" , CodeDOM_STV.XPLDOCSOURCETYPE_ENUM[(int)p_sourcetype] );
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
		if(p_heading!=null)if(!p_heading.Write(writer))result=false;
		if(p_title!=null)if(!p_title.Write(writer))result=false;
		if(p_body!=null)if(!p_body.Write(writer))result=false;
		if(p_examples!=null)if(!p_examples.Write(writer))result=false;
		if(p_seealso!=null)if(!p_seealso.Write(writer))result=false;
		if(p_footer!=null)if(!p_footer.Write(writer))result=false;
		if(p_summary!=null)if(!p_summary.Write(writer))result=false;
		if(p_params!=null)if(!p_params.Write(writer))result=false;
		if(p_returntype!=null)if(!p_returntype.Write(writer))result=false;
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
					case "short":
						this.set_short(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "source":
						this.set_source(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "key":
						this.set_key(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "sourcetype":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLDOCSOURCETYPE_ENUM){
							if(str==tmpStr){this.set_sourcetype((XplDocsourcetype_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'sourcetype' en elemento '"+this.get_ElementName()+"'.");
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
		this.p_heading=null;
		this.p_title=null;
		this.p_body=null;
		this.p_examples=null;
		this.p_seealso=null;
		this.p_footer=null;
		this.p_summary=null;
		this.p_params=null;
		this.p_returntype=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "heading":
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_heading()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_heading(tempNode);
						break;
					case "title":
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_title()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_title(tempNode);
						break;
					case "body":
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_body()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_body(tempNode);
						break;
					case "examples":
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_examples()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_examples(tempNode);
						break;
					case "seealso":
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_seealso()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_seealso(tempNode);
						break;
					case "footer":
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_footer()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_footer(tempNode);
						break;
					case "summary":
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_summary()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_summary(tempNode);
						break;
					case "params":
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_params()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_params(tempNode);
						break;
					case "returntype":
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_returntype()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_returntype(tempNode);
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
		writer.Write((int) 123 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_short );
		writer.Write( p_source );
		writer.Write( p_key );
		writer.Write( (int)p_sourcetype );
		writer.Write( p_ldsrc );
		writer.Write( p_iny );
		writer.Write( p_inydata );
		writer.Write( p_inyby );
		writer.Write( p_lddata );
		//Escribo recursivamente cada elemento hijo
		if(p_heading!=null){
			writer.Write((int)1);
			if(!p_heading.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_title!=null){
			writer.Write((int)1);
			if(!p_title.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_body!=null){
			writer.Write((int)1);
			if(!p_body.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_examples!=null){
			writer.Write((int)1);
			if(!p_examples.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_seealso!=null){
			writer.Write((int)1);
			if(!p_seealso.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_footer!=null){
			writer.Write((int)1);
			if(!p_footer.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_summary!=null){
			writer.Write((int)1);
			if(!p_summary.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_params!=null){
			writer.Write((int)1);
			if(!p_params.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_returntype!=null){
			writer.Write((int)1);
			if(!p_returntype.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_short = reader.ReadString();
		p_source = reader.ReadString();
		p_key = reader.ReadString();
		p_sourcetype = (XplDocsourcetype_enum)reader.ReadInt32();
		p_ldsrc = reader.ReadString();
		p_iny = reader.ReadBoolean();
		p_inydata = reader.ReadString();
		p_inyby = reader.ReadString();
		p_lddata = reader.ReadString();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_heading = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_title = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_body = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_examples = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_seealso = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_footer = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_summary = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_params = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_returntype = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplDocumentation operator +(XplDocumentation arg1, XplNode arg2)
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
public static XplDocumentation operator +(XplDocumentation arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_short(){
		return p_short;
	}
	public string get_source(){
		return p_source;
	}
	public string get_key(){
		return p_key;
	}
	public XplDocsourcetype_enum get_sourcetype(){
		return p_sourcetype;
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
	public XplNode get_heading(){
		return p_heading;
	}
	public XplNode get_title(){
		return p_title;
	}
	public XplNode get_body(){
		return p_body;
	}
	public XplNode get_examples(){
		return p_examples;
	}
	public XplNode get_seealso(){
		return p_seealso;
	}
	public XplNode get_footer(){
		return p_footer;
	}
	public XplNode get_summary(){
		return p_summary;
	}
	public XplNode get_params(){
		return p_params;
	}
	public XplNode get_returntype(){
		return p_returntype;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[9];
		ret[0] = "short";
		ret[1] = "source";
		ret[2] = "key";
		ret[3] = "sourcetype";
		ret[4] = "ldsrc";
		ret[5] = "iny";
		ret[6] = "inydata";
		ret[7] = "inyby";
		ret[8] = "lddata";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="short") return p_short.ToString();
		if (attributeName=="source") return p_source.ToString();
		if (attributeName=="key") return p_key.ToString();
		if (attributeName=="sourcetype") return p_sourcetype.ToString();
		if (attributeName=="ldsrc") return p_ldsrc.ToString();
		if (attributeName=="iny") return p_iny.ToString();
		if (attributeName=="inydata") return p_inydata.ToString();
		if (attributeName=="inyby") return p_inyby.ToString();
		if (attributeName=="lddata") return p_lddata.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		list.InsertAtEnd(p_heading);
		list.InsertAtEnd(p_title);
		list.InsertAtEnd(p_body);
		list.InsertAtEnd(p_examples);
		list.InsertAtEnd(p_seealso);
		list.InsertAtEnd(p_footer);
		list.InsertAtEnd(p_summary);
		list.InsertAtEnd(p_params);
		list.InsertAtEnd(p_returntype);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_short(string new_short){
		string back_short = p_short;
		p_short = new_short;
		return back_short;
	}
	public string set_source(string new_source){
		string back_source = p_source;
		p_source = new_source;
		return back_source;
	}
	public string set_key(string new_key){
		string back_key = p_key;
		p_key = new_key;
		return back_key;
	}
	public XplDocsourcetype_enum set_sourcetype(XplDocsourcetype_enum new_sourcetype){
		XplDocsourcetype_enum back_sourcetype = p_sourcetype;
		p_sourcetype = new_sourcetype;
		return back_sourcetype;
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
	public XplNode set_heading(XplNode new_heading){
		if(new_heading.get_ContentTypeName()!=CodeDOMTypes.String){
			this.set_ErrorString("El nodo que intenta asignar a la propiedad es de un tipo incorrecto.");
			return null;
		}
		XplNode back_heading = p_heading;
		p_heading = new_heading;
		if(p_heading!=null){
			p_heading.set_Parent(this);
			p_heading.set_ElementName("heading");
		}
		return back_heading;
	}
	public XplNode set_title(XplNode new_title){
		if(new_title.get_ContentTypeName()!=CodeDOMTypes.String){
			this.set_ErrorString("El nodo que intenta asignar a la propiedad es de un tipo incorrecto.");
			return null;
		}
		XplNode back_title = p_title;
		p_title = new_title;
		if(p_title!=null){
			p_title.set_Parent(this);
			p_title.set_ElementName("title");
		}
		return back_title;
	}
	public XplNode set_body(XplNode new_body){
		if(new_body.get_ContentTypeName()!=CodeDOMTypes.String){
			this.set_ErrorString("El nodo que intenta asignar a la propiedad es de un tipo incorrecto.");
			return null;
		}
		XplNode back_body = p_body;
		p_body = new_body;
		if(p_body!=null){
			p_body.set_Parent(this);
			p_body.set_ElementName("body");
		}
		return back_body;
	}
	public XplNode set_examples(XplNode new_examples){
		if(new_examples.get_ContentTypeName()!=CodeDOMTypes.String){
			this.set_ErrorString("El nodo que intenta asignar a la propiedad es de un tipo incorrecto.");
			return null;
		}
		XplNode back_examples = p_examples;
		p_examples = new_examples;
		if(p_examples!=null){
			p_examples.set_Parent(this);
			p_examples.set_ElementName("examples");
		}
		return back_examples;
	}
	public XplNode set_seealso(XplNode new_seealso){
		if(new_seealso.get_ContentTypeName()!=CodeDOMTypes.String){
			this.set_ErrorString("El nodo que intenta asignar a la propiedad es de un tipo incorrecto.");
			return null;
		}
		XplNode back_seealso = p_seealso;
		p_seealso = new_seealso;
		if(p_seealso!=null){
			p_seealso.set_Parent(this);
			p_seealso.set_ElementName("seealso");
		}
		return back_seealso;
	}
	public XplNode set_footer(XplNode new_footer){
		if(new_footer.get_ContentTypeName()!=CodeDOMTypes.String){
			this.set_ErrorString("El nodo que intenta asignar a la propiedad es de un tipo incorrecto.");
			return null;
		}
		XplNode back_footer = p_footer;
		p_footer = new_footer;
		if(p_footer!=null){
			p_footer.set_Parent(this);
			p_footer.set_ElementName("footer");
		}
		return back_footer;
	}
	public XplNode set_summary(XplNode new_summary){
		if(new_summary.get_ContentTypeName()!=CodeDOMTypes.String){
			this.set_ErrorString("El nodo que intenta asignar a la propiedad es de un tipo incorrecto.");
			return null;
		}
		XplNode back_summary = p_summary;
		p_summary = new_summary;
		if(p_summary!=null){
			p_summary.set_Parent(this);
			p_summary.set_ElementName("summary");
		}
		return back_summary;
	}
	public XplNode set_params(XplNode new_params){
		if(new_params.get_ContentTypeName()!=CodeDOMTypes.String){
			this.set_ErrorString("El nodo que intenta asignar a la propiedad es de un tipo incorrecto.");
			return null;
		}
		XplNode back_params = p_params;
		p_params = new_params;
		if(p_params!=null){
			p_params.set_Parent(this);
			p_params.set_ElementName("params");
		}
		return back_params;
	}
	public XplNode set_returntype(XplNode new_returntype){
		if(new_returntype.get_ContentTypeName()!=CodeDOMTypes.String){
			this.set_ErrorString("El nodo que intenta asignar a la propiedad es de un tipo incorrecto.");
			return null;
		}
		XplNode back_returntype = p_returntype;
		p_returntype = new_returntype;
		if(p_returntype!=null){
			p_returntype.set_Parent(this);
			p_returntype.set_ElementName("returntype");
		}
		return back_returntype;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplNode new_heading(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_ElementName("heading");
		return node;
	}
	static public XplNode new_title(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_ElementName("title");
		return node;
	}
	static public XplNode new_body(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_ElementName("body");
		return node;
	}
	static public XplNode new_examples(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_ElementName("examples");
		return node;
	}
	static public XplNode new_seealso(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_ElementName("seealso");
		return node;
	}
	static public XplNode new_footer(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_ElementName("footer");
		return node;
	}
	static public XplNode new_summary(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_ElementName("summary");
		return node;
	}
	static public XplNode new_params(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_ElementName("params");
		return node;
	}
	static public XplNode new_returntype(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_ElementName("returntype");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

