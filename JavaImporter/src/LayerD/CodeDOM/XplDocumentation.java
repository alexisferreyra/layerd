/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 17/04/2009 10:26:34
 *
 *	Generado por Zoe CodeDOM Generator para Java.
 *	COPYRIGHT 2002,2005-2006.
 *
 *------------------------------------------------*/


package LayerD.CodeDOM;

import LayerD.CodeDOM.XplParser.ParseException;
import java.io.*;
import java.util.*;
import java.text.*;

public class XplDocumentation extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_short;
	String p_source;
	String p_key;
	int p_sourcetype;
	String p_ldsrc;
	boolean p_iny;
	String p_inydata;
	String p_inyby;
	String p_lddata;
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
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplDocumentation(){
		p_short = "";
		p_source = "";
		p_key = "";
		p_sourcetype = 0;
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
		p_sourcetype = 0;
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
	public XplDocumentation(String n_short, String n_source, String n_key, int n_sourcetype, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata){
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
	public XplDocumentation(String n_short, String n_source, String n_key, int n_sourcetype, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplNode n_heading, XplNode n_title, XplNode n_body, XplNode n_examples, XplNode n_seealso, XplNode n_footer, XplNode n_summary, XplNode n_params, XplNode n_returntype){
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
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
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
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplDocumentation;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_short != "")
			writer.WriteAttributeString( "short" ,CodeDOM_Utils.Att_ToString(p_short) );
		if(p_source != "")
			writer.WriteAttributeString( "source" ,CodeDOM_Utils.Att_ToString(p_source) );
		if(p_key != "")
			writer.WriteAttributeString( "key" ,CodeDOM_Utils.Att_ToString(p_key) );
		if(p_sourcetype != 0)
			writer.WriteAttributeString( "sourcetype" , CodeDOM_STV.XPLDOCSOURCETYPE_ENUM[(int)p_sourcetype] );
		if(p_ldsrc != "")
			writer.WriteAttributeString( "ldsrc" ,CodeDOM_Utils.Att_ToString(p_ldsrc) );
		if(p_iny != false)
			writer.WriteAttributeString( "iny" ,CodeDOM_Utils.Att_ToString(p_iny) );
		if(p_inydata != "")
			writer.WriteAttributeString( "inydata" ,CodeDOM_Utils.Att_ToString(p_inydata) );
		if(p_inyby != "")
			writer.WriteAttributeString( "inyby" ,CodeDOM_Utils.Att_ToString(p_inyby) );
		if(p_lddata != "")
			writer.WriteAttributeString( "lddata" ,CodeDOM_Utils.Att_ToString(p_lddata) );
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

	public XplNode Read(XplReader reader) throws ParseException, CodeDOM_Exception, IOException {
		this.set_Name( reader.Name() );
		//Lectura de Atributos
		if( reader.HasAttributes() ){
			String tmpStr="";boolean flag=false;int count=0;
			for(int i=1; i <= reader.AttributeCount() ; i++){
				reader.MoveToAttribute(i);
				if(reader.Name().equals("short")){
					this.set_short(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("source")){
					this.set_source(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("key")){
					this.set_key(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("sourcetype")){
					tmpStr=CodeDOM_Utils.StringAtt_To_STRING(reader.Value());
					count=0;flag=false;
					for(int n=0;n<CodeDOM_STV.XPLDOCSOURCETYPE_ENUM.length;n++){
						String str = CodeDOM_STV.XPLDOCSOURCETYPE_ENUM[n];
						if(str.equals(tmpStr)){this.set_sourcetype(count);flag=true;break;}
						count++;
					}
					// if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Valor invalido del atributo 'sourcetype' en elemento '"+this.get_Name()+"'.");
				}
				else if(reader.Name().equals("ldsrc")){
					this.set_ldsrc(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("iny")){
					this.set_iny(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("inydata")){
					this.set_inydata(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("inyby")){
					this.set_inyby(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("lddata")){
					this.set_lddata(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else{
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Atributo '"+reader.Name()+"' invalido en elemento '"+this.get_Name()+"'.");
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
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("heading")){
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_heading()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_heading(tempNode);
					}
					else if(reader.Name().equals("title")){
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_title()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_title(tempNode);
					}
					else if(reader.Name().equals("body")){
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_body()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_body(tempNode);
					}
					else if(reader.Name().equals("examples")){
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_examples()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_examples(tempNode);
					}
					else if(reader.Name().equals("seealso")){
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_seealso()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_seealso(tempNode);
					}
					else if(reader.Name().equals("footer")){
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_footer()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_footer(tempNode);
					}
					else if(reader.Name().equals("summary")){
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_summary()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_summary(tempNode);
					}
					else if(reader.Name().equals("params")){
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_params()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_params(tempNode);
					}
					else if(reader.Name().equals("returntype")){
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_returntype()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_returntype(tempNode);
					}
					else{
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nombre de nodo '"+reader.Name()+"' inesperado como hijo de elemento '"+this.get_Name()+"'.");
					}
					break;
				case XmlNodeType.ENDELEMENT:
					break;
				case XmlNodeType.TEXT:
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".No se esperaba texto en este nodo.");
				default:
					break;
			}
			reader.Read();
		}
		}
		return this;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para obtener Atributos y Elementos ">
	public String get_short(){
		return p_short;
	}
	public String get_source(){
		return p_source;
	}
	public String get_key(){
		return p_key;
	}
	public int get_sourcetype(){
		return p_sourcetype;
	}
	public String get_ldsrc(){
		return p_ldsrc;
	}
	public boolean get_iny(){
		return p_iny;
	}
	public String get_inydata(){
		return p_inydata;
	}
	public String get_inyby(){
		return p_inyby;
	}
	public String get_lddata(){
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
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_short(String new_short){
		String back_short = p_short;
		p_short = new_short;
		return back_short;
	}
	public String set_source(String new_source){
		String back_source = p_source;
		p_source = new_source;
		return back_source;
	}
	public String set_key(String new_key){
		String back_key = p_key;
		p_key = new_key;
		return back_key;
	}
	public int set_sourcetype(int new_sourcetype){
		int back_sourcetype = p_sourcetype;
		p_sourcetype = new_sourcetype;
		return back_sourcetype;
	}
	public String set_ldsrc(String new_ldsrc){
		String back_ldsrc = p_ldsrc;
		p_ldsrc = new_ldsrc;
		return back_ldsrc;
	}
	public boolean set_iny(boolean new_iny){
		boolean back_iny = p_iny;
		p_iny = new_iny;
		return back_iny;
	}
	public String set_inydata(String new_inydata){
		String back_inydata = p_inydata;
		p_inydata = new_inydata;
		return back_inydata;
	}
	public String set_inyby(String new_inyby){
		String back_inyby = p_inyby;
		p_inyby = new_inyby;
		return back_inyby;
	}
	public String set_lddata(String new_lddata){
		String back_lddata = p_lddata;
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
			p_heading.set_Name("heading");
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
			p_title.set_Name("title");
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
			p_body.set_Name("body");
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
			p_examples.set_Name("examples");
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
			p_seealso.set_Name("seealso");
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
			p_footer.set_Name("footer");
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
			p_summary.set_Name("summary");
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
			p_params.set_Name("params");
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
			p_returntype.set_Name("returntype");
		}
		return back_returntype;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplNode new_heading(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_Name("heading");
		return node;
	}
	public static final XplNode new_title(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_Name("title");
		return node;
	}
	public static final XplNode new_body(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_Name("body");
		return node;
	}
	public static final XplNode new_examples(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_Name("examples");
		return node;
	}
	public static final XplNode new_seealso(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_Name("seealso");
		return node;
	}
	public static final XplNode new_footer(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_Name("footer");
		return node;
	}
	public static final XplNode new_summary(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_Name("summary");
		return node;
	}
	public static final XplNode new_params(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_Name("params");
		return node;
	}
	public static final XplNode new_returntype(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_Name("returntype");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

