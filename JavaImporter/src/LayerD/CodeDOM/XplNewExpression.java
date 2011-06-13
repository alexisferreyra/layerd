/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 17/04/2009 10:26:35
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

public class XplNewExpression extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_GCName;
	String p_doc;
	String p_helpURL;
	String p_ldsrc;
	boolean p_iny;
	String p_inydata;
	String p_inyby;
	String p_lddata;
	//Variables para Elementos de Secuencia
	XplType p_type;
	XplInitializerList p_init;
	XplExpressionlist p_GCParams;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplNewExpression(){
		p_GCName = "default";
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_type=null;
		p_init=null;
		p_GCParams=null;
	}
	public XplNewExpression(String n_GCName){
		p_GCName = "default";
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_GCName(n_GCName);
		p_type=null;
		p_init=null;
		p_GCParams=null;
	}
	public XplNewExpression(XplType n_type){
		p_GCName = "default";
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_type=null;
		p_init=null;
		p_GCParams=null;
		set_type(n_type);
	}
	public XplNewExpression(String n_GCName, XplType n_type){
		p_GCName = "default";
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_GCName(n_GCName);
		p_type=null;
		p_init=null;
		p_GCParams=null;
		set_type(n_type);
	}
	public XplNewExpression(String n_GCName, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata){
		set_GCName(n_GCName);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_type=null;
		p_init=null;
		p_GCParams=null;
	}
	public XplNewExpression(XplType n_type, XplInitializerList n_init, XplExpressionlist n_GCParams){
		p_GCName = "default";
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_type=null;
		p_init=null;
		p_GCParams=null;
		set_type(n_type);
		set_init(n_init);
		set_GCParams(n_GCParams);
	}
	public XplNewExpression(String n_GCName, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplType n_type){
		set_GCName(n_GCName);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_GCName(n_GCName);
		p_type=null;
		p_init=null;
		p_GCParams=null;
	}
	public XplNewExpression(String n_GCName, XplType n_type, XplInitializerList n_init, XplExpressionlist n_GCParams){
		p_GCName = "default";
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_GCName(n_GCName);
		p_type=null;
		p_init=null;
		p_GCParams=null;
		set_type(n_type);
		set_init(n_init);
		set_GCParams(n_GCParams);
	}
	public XplNewExpression(String n_GCName, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplType n_type, XplInitializerList n_init, XplExpressionlist n_GCParams){
		set_GCName(n_GCName);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_type=null;
		p_init=null;
		p_GCParams=null;
		set_type(n_type);
		set_init(n_init);
		set_GCParams(n_GCParams);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplNewExpression copy = new XplNewExpression();
		copy.set_GCName(this.p_GCName);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_type!=null)copy.set_type((XplType)p_type.Clone());
		if(p_init!=null)copy.set_init((XplInitializerList)p_init.Clone());
		if(p_GCParams!=null)copy.set_GCParams((XplExpressionlist)p_GCParams.Clone());
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplNewExpression;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_GCName != "default")
			writer.WriteAttributeString( "GCName" ,CodeDOM_Utils.Att_ToString(p_GCName) );
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
		if(p_init!=null)if(!p_init.Write(writer))result=false;
		if(p_GCParams!=null)if(!p_GCParams.Write(writer))result=false;
		//Cierro el elemento
		writer.WriteEndElement();
		return result;
	}

	public XplNode Read(XplReader reader) throws ParseException, CodeDOM_Exception, IOException {
		this.set_Name( reader.Name() );
		//Lectura de Atributos
		if( reader.HasAttributes() ){
			for(int i=1; i <= reader.AttributeCount() ; i++){
				reader.MoveToAttribute(i);
				if(reader.Name().equals("GCName")){
					this.set_GCName(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
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
		this.p_init=null;
		this.p_GCParams=null;
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
					else if(reader.Name().equals("init")){
						tempNode = new XplInitializerList();
						tempNode.Read(reader);
						if(this.get_init()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_init((XplInitializerList)tempNode);
					}
					else if(reader.Name().equals("GCParams")){
						tempNode = new XplExpressionlist();
						tempNode.Read(reader);
						if(this.get_GCParams()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_GCParams((XplExpressionlist)tempNode);
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
	public String get_GCName(){
		return p_GCName;
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
	public XplInitializerList get_init(){
		return p_init;
	}
	public XplExpressionlist get_GCParams(){
		return p_GCParams;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_GCName(String new_GCName){
		String back_GCName = p_GCName;
		p_GCName = new_GCName;
		return back_GCName;
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
	public XplInitializerList set_init(XplInitializerList new_init){
		XplInitializerList back_init = p_init;
		p_init = new_init;
		if(p_init!=null){
			p_init.set_Name("init");
			p_init.set_Parent(this);
		}
		return back_init;
	}
	public XplExpressionlist set_GCParams(XplExpressionlist new_GCParams){
		XplExpressionlist back_GCParams = p_GCParams;
		p_GCParams = new_GCParams;
		if(p_GCParams!=null){
			p_GCParams.set_Name("GCParams");
			p_GCParams.set_Parent(this);
		}
		return back_GCParams;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplType new_type(){
		XplType node = new XplType();
		node.set_Name("type");
		return node;
	}
	public static final XplInitializerList new_init(){
		XplInitializerList node = new XplInitializerList();
		node.set_Name("init");
		return node;
	}
	public static final XplExpressionlist new_GCParams(){
		XplExpressionlist node = new XplExpressionlist();
		node.set_Name("GCParams");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

