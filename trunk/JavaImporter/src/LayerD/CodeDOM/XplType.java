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

public class XplType extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_typename;
	boolean p_ispointer;
	boolean p_isarray;
	int p_pointertype;
	int p_ftype;
	boolean p_volatile;
	boolean p_const;
	boolean p_exec;
	String p_typeStr;
	boolean p_replaceParent;
	boolean p_customTypeCheck;
	String p_doc;
	String p_helpURL;
	String p_ldsrc;
	boolean p_iny;
	String p_inydata;
	String p_inyby;
	String p_lddata;
	//Variables para Elementos de Secuencia
	XplType p_dt;
	XplExpression p_ae;
	XplPointerinfo p_pi;
	XplFunctioncall p_fc;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
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
	public XplType(boolean n_ispointer, boolean n_isarray, int n_pointertype, int n_ftype, boolean n_volatile, boolean n_const, boolean n_exec, boolean n_replaceParent, boolean n_customTypeCheck){
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
	public XplType(String n_typename, boolean n_ispointer, boolean n_isarray, int n_pointertype, int n_ftype, boolean n_volatile, boolean n_const, boolean n_exec, String n_typeStr, boolean n_replaceParent, boolean n_customTypeCheck, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata){
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
	public XplType(boolean n_ispointer, boolean n_isarray, int n_pointertype, int n_ftype, boolean n_volatile, boolean n_const, boolean n_exec, boolean n_replaceParent, boolean n_customTypeCheck, XplType n_dt, XplExpression n_ae, XplPointerinfo n_pi, XplFunctioncall n_fc){
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
	public XplType(String n_typename, boolean n_ispointer, boolean n_isarray, int n_pointertype, int n_ftype, boolean n_volatile, boolean n_const, boolean n_exec, String n_typeStr, boolean n_replaceParent, boolean n_customTypeCheck, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplType n_dt, XplExpression n_ae, XplPointerinfo n_pi, XplFunctioncall n_fc){
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
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
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
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplType;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_typename != "")
			writer.WriteAttributeString( "typename" ,CodeDOM_Utils.Att_ToString(p_typename) );
		if(p_ispointer != false)
			writer.WriteAttributeString( "ispointer" ,CodeDOM_Utils.Att_ToString(p_ispointer) );
		if(p_isarray != false)
			writer.WriteAttributeString( "isarray" ,CodeDOM_Utils.Att_ToString(p_isarray) );
		if(p_pointertype != XplPointertype_enum.DEFAULT)
			writer.WriteAttributeString( "pointertype" , CodeDOM_STV.XPLPOINTERTYPE_ENUM[(int)p_pointertype] );
		if(p_ftype != XplFactorytype_enum.NONE)
			writer.WriteAttributeString( "ftype" , CodeDOM_STV.XPLFACTORYTYPE_ENUM[(int)p_ftype] );
		if(p_volatile != false)
			writer.WriteAttributeString( "volatile" ,CodeDOM_Utils.Att_ToString(p_volatile) );
		if(p_const != false)
			writer.WriteAttributeString( "const" ,CodeDOM_Utils.Att_ToString(p_const) );
		if(p_exec != false)
			writer.WriteAttributeString( "exec" ,CodeDOM_Utils.Att_ToString(p_exec) );
		if(p_typeStr != "")
			writer.WriteAttributeString( "typeStr" ,CodeDOM_Utils.Att_ToString(p_typeStr) );
		if(p_replaceParent != false)
			writer.WriteAttributeString( "replaceParent" ,CodeDOM_Utils.Att_ToString(p_replaceParent) );
		if(p_customTypeCheck != false)
			writer.WriteAttributeString( "customTypeCheck" ,CodeDOM_Utils.Att_ToString(p_customTypeCheck) );
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
		if(p_dt!=null)if(!p_dt.Write(writer))result=false;
		if(p_ae!=null)if(!p_ae.Write(writer))result=false;
		if(p_pi!=null)if(!p_pi.Write(writer))result=false;
		if(p_fc!=null)if(!p_fc.Write(writer))result=false;
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
				if(reader.Name().equals("typename")){
					this.set_typename(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("ispointer")){
					this.set_ispointer(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("isarray")){
					this.set_isarray(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("pointertype")){
					tmpStr=CodeDOM_Utils.StringAtt_To_STRING(reader.Value());
					count=0;flag=false;
					for(int n=0;n<CodeDOM_STV.XPLPOINTERTYPE_ENUM.length;n++){
						String str = CodeDOM_STV.XPLPOINTERTYPE_ENUM[n];
						if(str.equals(tmpStr)){this.set_pointertype(count);flag=true;break;}
						count++;
					}
					// if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Valor invalido del atributo 'pointertype' en elemento '"+this.get_Name()+"'.");
				}
				else if(reader.Name().equals("ftype")){
					tmpStr=CodeDOM_Utils.StringAtt_To_STRING(reader.Value());
					count=0;flag=false;
					for(int n=0;n<CodeDOM_STV.XPLFACTORYTYPE_ENUM.length;n++){
						String str = CodeDOM_STV.XPLFACTORYTYPE_ENUM[n];
						if(str.equals(tmpStr)){this.set_ftype(count);flag=true;break;}
						count++;
					}
					// if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Valor invalido del atributo 'ftype' en elemento '"+this.get_Name()+"'.");
				}
				else if(reader.Name().equals("volatile")){
					this.set_volatile(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("const")){
					this.set_const(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("exec")){
					this.set_exec(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("typeStr")){
					this.set_typeStr(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("replaceParent")){
					this.set_replaceParent(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("customTypeCheck")){
					this.set_customTypeCheck(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
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
		this.p_dt=null;
		this.p_ae=null;
		this.p_pi=null;
		this.p_fc=null;
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("dt")){
						tempNode = new XplType();
						tempNode.Read(reader);
						if(this.get_dt()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_dt((XplType)tempNode);
					}
					else if(reader.Name().equals("ae")){
						tempNode = new XplExpression();
						tempNode.Read(reader);
						if(this.get_ae()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_ae((XplExpression)tempNode);
					}
					else if(reader.Name().equals("pi")){
						tempNode = new XplPointerinfo();
						tempNode.Read(reader);
						if(this.get_pi()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_pi((XplPointerinfo)tempNode);
					}
					else if(reader.Name().equals("fc")){
						tempNode = new XplFunctioncall();
						tempNode.Read(reader);
						if(this.get_fc()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_fc((XplFunctioncall)tempNode);
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
	public String get_typename(){
		return p_typename;
	}
	public boolean get_ispointer(){
		return p_ispointer;
	}
	public boolean get_isarray(){
		return p_isarray;
	}
	public int get_pointertype(){
		return p_pointertype;
	}
	public int get_ftype(){
		return p_ftype;
	}
	public boolean get_volatile(){
		return p_volatile;
	}
	public boolean get_const(){
		return p_const;
	}
	public boolean get_exec(){
		return p_exec;
	}
	public String get_typeStr(){
		return p_typeStr;
	}
	public boolean get_replaceParent(){
		return p_replaceParent;
	}
	public boolean get_customTypeCheck(){
		return p_customTypeCheck;
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
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_typename(String new_typename){
		String back_typename = p_typename;
		p_typename = new_typename;
		return back_typename;
	}
	public boolean set_ispointer(boolean new_ispointer){
		boolean back_ispointer = p_ispointer;
		p_ispointer = new_ispointer;
		return back_ispointer;
	}
	public boolean set_isarray(boolean new_isarray){
		boolean back_isarray = p_isarray;
		p_isarray = new_isarray;
		return back_isarray;
	}
	public int set_pointertype(int new_pointertype){
		int back_pointertype = p_pointertype;
		p_pointertype = new_pointertype;
		return back_pointertype;
	}
	public int set_ftype(int new_ftype){
		int back_ftype = p_ftype;
		p_ftype = new_ftype;
		return back_ftype;
	}
	public boolean set_volatile(boolean new_volatile){
		boolean back_volatile = p_volatile;
		p_volatile = new_volatile;
		return back_volatile;
	}
	public boolean set_const(boolean new_const){
		boolean back_const = p_const;
		p_const = new_const;
		return back_const;
	}
	public boolean set_exec(boolean new_exec){
		boolean back_exec = p_exec;
		p_exec = new_exec;
		return back_exec;
	}
	public String set_typeStr(String new_typeStr){
		String back_typeStr = p_typeStr;
		p_typeStr = new_typeStr;
		return back_typeStr;
	}
	public boolean set_replaceParent(boolean new_replaceParent){
		boolean back_replaceParent = p_replaceParent;
		p_replaceParent = new_replaceParent;
		return back_replaceParent;
	}
	public boolean set_customTypeCheck(boolean new_customTypeCheck){
		boolean back_customTypeCheck = p_customTypeCheck;
		p_customTypeCheck = new_customTypeCheck;
		return back_customTypeCheck;
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
	public XplType set_dt(XplType new_dt){
		XplType back_dt = p_dt;
		p_dt = new_dt;
		if(p_dt!=null){
			p_dt.set_Name("dt");
			p_dt.set_Parent(this);
		}
		return back_dt;
	}
	public XplExpression set_ae(XplExpression new_ae){
		XplExpression back_ae = p_ae;
		p_ae = new_ae;
		if(p_ae!=null){
			p_ae.set_Name("ae");
			p_ae.set_Parent(this);
		}
		return back_ae;
	}
	public XplPointerinfo set_pi(XplPointerinfo new_pi){
		XplPointerinfo back_pi = p_pi;
		p_pi = new_pi;
		if(p_pi!=null){
			p_pi.set_Name("pi");
			p_pi.set_Parent(this);
		}
		return back_pi;
	}
	public XplFunctioncall set_fc(XplFunctioncall new_fc){
		XplFunctioncall back_fc = p_fc;
		p_fc = new_fc;
		if(p_fc!=null){
			p_fc.set_Name("fc");
			p_fc.set_Parent(this);
		}
		return back_fc;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplType new_dt(){
		XplType node = new XplType();
		node.set_Name("dt");
		return node;
	}
	public static final XplExpression new_ae(){
		XplExpression node = new XplExpression();
		node.set_Name("ae");
		return node;
	}
	public static final XplPointerinfo new_pi(){
		XplPointerinfo node = new XplPointerinfo();
		node.set_Name("pi");
		return node;
	}
	public static final XplFunctioncall new_fc(){
		XplFunctioncall node = new XplFunctioncall();
		node.set_Name("fc");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

