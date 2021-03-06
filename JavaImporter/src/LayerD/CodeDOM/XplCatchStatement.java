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

public class XplCatchStatement extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	boolean p_default;
	String p_doc;
	String p_helpURL;
	String p_ldsrc;
	boolean p_iny;
	String p_inydata;
	String p_inyby;
	String p_lddata;
	//Variables para Elementos de Secuencia
	XplCatchinit p_init;
	XplFunctionBody p_bk;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplCatchStatement(){
		p_default = true;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_init=null;
		p_bk=null;
	}
	public XplCatchStatement(boolean n_default){
		p_default = true;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_default(n_default);
		p_init=null;
		p_bk=null;
	}
	public XplCatchStatement(XplCatchinit n_init, XplFunctionBody n_bk){
		p_default = true;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_init=null;
		p_bk=null;
		set_init(n_init);
		set_bk(n_bk);
	}
	public XplCatchStatement(boolean n_default, XplCatchinit n_init, XplFunctionBody n_bk){
		p_default = true;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_default(n_default);
		p_init=null;
		p_bk=null;
		set_init(n_init);
		set_bk(n_bk);
	}
	public XplCatchStatement(boolean n_default, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata){
		set_default(n_default);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_init=null;
		p_bk=null;
	}
	public XplCatchStatement(boolean n_default, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplCatchinit n_init, XplFunctionBody n_bk){
		set_default(n_default);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_default(n_default);
		p_init=null;
		p_bk=null;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplCatchStatement copy = new XplCatchStatement();
		copy.set_default(this.p_default);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_init!=null)copy.set_init((XplCatchinit)p_init.Clone());
		if(p_bk!=null)copy.set_bk((XplFunctionBody)p_bk.Clone());
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplCatchStatement;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_default != true)
			writer.WriteAttributeString( "default" ,CodeDOM_Utils.Att_ToString(p_default) );
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
		if(p_init!=null)if(!p_init.Write(writer))result=false;
		if(p_bk!=null)if(!p_bk.Write(writer))result=false;
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
				if(reader.Name().equals("default")){
					this.set_default(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
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
		this.p_init=null;
		this.p_bk=null;
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("init")){
						tempNode = new XplCatchinit();
						tempNode.Read(reader);
						if(this.get_init()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_init((XplCatchinit)tempNode);
					}
					else if(reader.Name().equals("bk")){
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						if(this.get_bk()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_bk((XplFunctionBody)tempNode);
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
	public boolean get_default(){
		return p_default;
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
	public XplCatchinit get_init(){
		return p_init;
	}
	public XplFunctionBody get_bk(){
		return p_bk;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public boolean set_default(boolean new_default){
		boolean back_default = p_default;
		p_default = new_default;
		return back_default;
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
	public XplCatchinit set_init(XplCatchinit new_init){
		XplCatchinit back_init = p_init;
		p_init = new_init;
		if(p_init!=null){
			p_init.set_Name("init");
			p_init.set_Parent(this);
		}
		return back_init;
	}
	public XplFunctionBody set_bk(XplFunctionBody new_bk){
		XplFunctionBody back_bk = p_bk;
		p_bk = new_bk;
		if(p_bk!=null){
			p_bk.set_Name("bk");
			p_bk.set_Parent(this);
		}
		return back_bk;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplCatchinit new_init(){
		XplCatchinit node = new XplCatchinit();
		node.set_Name("init");
		return node;
	}
	public static final XplFunctionBody new_bk(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_Name("bk");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

