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

public class XplParameter extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_name;
	int p_number;
	int p_direction;
	boolean p_params;
	boolean p_donotrender;
	String p_doc;
	String p_helpURL;
	String p_ldsrc;
	boolean p_iny;
	String p_inydata;
	String p_inyby;
	String p_lddata;
	//Variables para Elementos de Secuencia
	XplType p_type;
	XplInitializerList p_i;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplParameter(){
		p_name = "";
		p_number = 0;
		p_direction = XplParameterdirection_enum.IN;
		p_params = false;
		p_donotrender = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_type=null;
		p_i=null;
	}
	public XplParameter(int n_number, int n_direction, boolean n_params, boolean n_donotrender){
		p_name = "";
		p_number = 0;
		p_direction = XplParameterdirection_enum.IN;
		p_params = false;
		p_donotrender = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_number(n_number);
		set_direction(n_direction);
		set_params(n_params);
		set_donotrender(n_donotrender);
		p_type=null;
		p_i=null;
	}
	public XplParameter(XplType n_type){
		p_name = "";
		p_number = 0;
		p_direction = XplParameterdirection_enum.IN;
		p_params = false;
		p_donotrender = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_type=null;
		p_i=null;
		set_type(n_type);
	}
	public XplParameter(int n_number, int n_direction, boolean n_params, boolean n_donotrender, XplType n_type){
		p_name = "";
		p_number = 0;
		p_direction = XplParameterdirection_enum.IN;
		p_params = false;
		p_donotrender = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_number(n_number);
		set_direction(n_direction);
		set_params(n_params);
		set_donotrender(n_donotrender);
		p_type=null;
		p_i=null;
		set_type(n_type);
	}
	public XplParameter(String n_name, int n_number, int n_direction, boolean n_params, boolean n_donotrender, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata){
		set_name(n_name);
		set_number(n_number);
		set_direction(n_direction);
		set_params(n_params);
		set_donotrender(n_donotrender);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_type=null;
		p_i=null;
	}
	public XplParameter(XplType n_type, XplInitializerList n_i){
		p_name = "";
		p_number = 0;
		p_direction = XplParameterdirection_enum.IN;
		p_params = false;
		p_donotrender = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_type=null;
		p_i=null;
		set_type(n_type);
		set_i(n_i);
	}
	public XplParameter(String n_name, int n_number, int n_direction, boolean n_params, boolean n_donotrender, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplType n_type){
		set_name(n_name);
		set_number(n_number);
		set_direction(n_direction);
		set_params(n_params);
		set_donotrender(n_donotrender);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_number(n_number);
		set_direction(n_direction);
		set_params(n_params);
		set_donotrender(n_donotrender);
		p_type=null;
		p_i=null;
	}
	public XplParameter(int n_number, int n_direction, boolean n_params, boolean n_donotrender, XplType n_type, XplInitializerList n_i){
		p_name = "";
		p_number = 0;
		p_direction = XplParameterdirection_enum.IN;
		p_params = false;
		p_donotrender = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_number(n_number);
		set_direction(n_direction);
		set_params(n_params);
		set_donotrender(n_donotrender);
		p_type=null;
		p_i=null;
		set_type(n_type);
		set_i(n_i);
	}
	public XplParameter(String n_name, int n_number, int n_direction, boolean n_params, boolean n_donotrender, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplType n_type, XplInitializerList n_i){
		set_name(n_name);
		set_number(n_number);
		set_direction(n_direction);
		set_params(n_params);
		set_donotrender(n_donotrender);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_type=null;
		p_i=null;
		set_type(n_type);
		set_i(n_i);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplParameter copy = new XplParameter();
		copy.set_name(this.p_name);
		copy.set_number(this.p_number);
		copy.set_direction(this.p_direction);
		copy.set_params(this.p_params);
		copy.set_donotrender(this.p_donotrender);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_type!=null)copy.set_type((XplType)p_type.Clone());
		if(p_i!=null)copy.set_i((XplInitializerList)p_i.Clone());
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplParameter;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,CodeDOM_Utils.Att_ToString(p_name) );
		if(p_number != 0)
			writer.WriteAttributeString( "number" ,CodeDOM_Utils.Att_ToString(p_number) );
		if(p_direction != XplParameterdirection_enum.IN)
			writer.WriteAttributeString( "direction" , CodeDOM_STV.XPLPARAMETERDIRECTION_ENUM[(int)p_direction] );
		if(p_params != false)
			writer.WriteAttributeString( "params" ,CodeDOM_Utils.Att_ToString(p_params) );
		if(p_donotrender != false)
			writer.WriteAttributeString( "donotrender" ,CodeDOM_Utils.Att_ToString(p_donotrender) );
		if(p_doc != "")
			writer.WriteAttributeString( "doc" ,CodeDOM_Utils.Att_ToString(p_doc) );
		if(p_helpURL != "")
			writer.WriteAttributeString( "helpURL" ,CodeDOM_Utils.Att_ToString(p_helpURL) );
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
		if(p_type!=null)if(!p_type.Write(writer))result=false;
		if(p_i!=null)if(!p_i.Write(writer))result=false;
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
				if(reader.Name().equals("name")){
					this.set_name(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("number")){
					this.set_number(CodeDOM_Utils.StringAtt_To_INT(reader.Value()));
				}
				else if(reader.Name().equals("direction")){
					tmpStr=CodeDOM_Utils.StringAtt_To_STRING(reader.Value());
					count=0;flag=false;
					for(int n=0;n<CodeDOM_STV.XPLPARAMETERDIRECTION_ENUM.length;n++){
						String str = CodeDOM_STV.XPLPARAMETERDIRECTION_ENUM[n];
						if(str.equals(tmpStr)){this.set_direction(count);flag=true;break;}
						count++;
					}
					// if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Valor invalido del atributo 'direction' en elemento '"+this.get_Name()+"'.");
				}
				else if(reader.Name().equals("params")){
					this.set_params(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("donotrender")){
					this.set_donotrender(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("doc")){
					this.set_doc(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("helpURL")){
					this.set_helpURL(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
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
		this.p_type=null;
		this.p_i=null;
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("type")){
						tempNode = new XplType();
						tempNode.Read(reader);
						if(this.get_type()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_type((XplType)tempNode);
					}
					else if(reader.Name().equals("i")){
						tempNode = new XplInitializerList();
						tempNode.Read(reader);
						if(this.get_i()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_i((XplInitializerList)tempNode);
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
	public String get_name(){
		return p_name;
	}
	public int get_number(){
		return p_number;
	}
	public int get_direction(){
		return p_direction;
	}
	public boolean get_params(){
		return p_params;
	}
	public boolean get_donotrender(){
		return p_donotrender;
	}
	public String get_doc(){
		return p_doc;
	}
	public String get_helpURL(){
		return p_helpURL;
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
	public XplType get_type(){
		return p_type;
	}
	public XplInitializerList get_i(){
		return p_i;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_name(String new_name){
		String back_name = p_name;
		p_name = new_name;
		return back_name;
	}
	public int set_number(int new_number){
		int back_number = p_number;
		p_number = new_number;
		return back_number;
	}
	public int set_direction(int new_direction){
		int back_direction = p_direction;
		p_direction = new_direction;
		return back_direction;
	}
	public boolean set_params(boolean new_params){
		boolean back_params = p_params;
		p_params = new_params;
		return back_params;
	}
	public boolean set_donotrender(boolean new_donotrender){
		boolean back_donotrender = p_donotrender;
		p_donotrender = new_donotrender;
		return back_donotrender;
	}
	public String set_doc(String new_doc){
		String back_doc = p_doc;
		p_doc = new_doc;
		return back_doc;
	}
	public String set_helpURL(String new_helpURL){
		String back_helpURL = p_helpURL;
		p_helpURL = new_helpURL;
		return back_helpURL;
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
	public XplType set_type(XplType new_type){
		XplType back_type = p_type;
		p_type = new_type;
		if(p_type!=null){
			p_type.set_Name("type");
			p_type.set_Parent(this);
		}
		return back_type;
	}
	public XplInitializerList set_i(XplInitializerList new_i){
		XplInitializerList back_i = p_i;
		p_i = new_i;
		if(p_i!=null){
			p_i.set_Name("i");
			p_i.set_Parent(this);
		}
		return back_i;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplType new_type(){
		XplType node = new XplType();
		node.set_Name("type");
		return node;
	}
	public static final XplInitializerList new_i(){
		XplInitializerList node = new XplInitializerList();
		node.set_Name("i");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

