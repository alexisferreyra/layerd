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

public class XplBinaryoperator extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	int p_op;
	String p_targetClass;
	String p_targetMember;
	String p_targetClassExternalName;
	String p_targetMemberExternalName;
	boolean p_ignoreforsubprogram;
	String p_doc;
	String p_helpURL;
	String p_ldsrc;
	boolean p_iny;
	String p_inydata;
	String p_inyby;
	String p_lddata;
	//Variables para Elementos de Secuencia
	XplExpression p_l;
	XplExpression p_r;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplBinaryoperator(){
		p_op = 0;
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ignoreforsubprogram = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_l=null;
		p_r=null;
	}
	public XplBinaryoperator(int n_op, boolean n_ignoreforsubprogram){
		p_op = 0;
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ignoreforsubprogram = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_op(n_op);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		p_l=null;
		p_r=null;
	}
	public XplBinaryoperator(XplExpression n_l, XplExpression n_r){
		p_op = 0;
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ignoreforsubprogram = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_l=null;
		p_r=null;
		set_l(n_l);
		set_r(n_r);
	}
	public XplBinaryoperator(int n_op, boolean n_ignoreforsubprogram, XplExpression n_l, XplExpression n_r){
		p_op = 0;
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ignoreforsubprogram = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_op(n_op);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		p_l=null;
		p_r=null;
		set_l(n_l);
		set_r(n_r);
	}
	public XplBinaryoperator(int n_op, String n_targetClass, String n_targetMember, String n_targetClassExternalName, String n_targetMemberExternalName, boolean n_ignoreforsubprogram, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata){
		set_op(n_op);
		set_targetClass(n_targetClass);
		set_targetMember(n_targetMember);
		set_targetClassExternalName(n_targetClassExternalName);
		set_targetMemberExternalName(n_targetMemberExternalName);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_l=null;
		p_r=null;
	}
	public XplBinaryoperator(int n_op, String n_targetClass, String n_targetMember, String n_targetClassExternalName, String n_targetMemberExternalName, boolean n_ignoreforsubprogram, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplExpression n_l, XplExpression n_r){
		set_op(n_op);
		set_targetClass(n_targetClass);
		set_targetMember(n_targetMember);
		set_targetClassExternalName(n_targetClassExternalName);
		set_targetMemberExternalName(n_targetMemberExternalName);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_op(n_op);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		p_l=null;
		p_r=null;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplBinaryoperator copy = new XplBinaryoperator();
		copy.set_op(this.p_op);
		copy.set_targetClass(this.p_targetClass);
		copy.set_targetMember(this.p_targetMember);
		copy.set_targetClassExternalName(this.p_targetClassExternalName);
		copy.set_targetMemberExternalName(this.p_targetMemberExternalName);
		copy.set_ignoreforsubprogram(this.p_ignoreforsubprogram);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_l!=null)copy.set_l((XplExpression)p_l.Clone());
		if(p_r!=null)copy.set_r((XplExpression)p_r.Clone());
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplBinaryoperator;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_op != 0)
			writer.WriteAttributeString( "op" , CodeDOM_STV.XPLBINARYOPERATORS_ENUM[(int)p_op] );
		if(p_targetClass != "")
			writer.WriteAttributeString( "targetClass" ,CodeDOM_Utils.Att_ToString(p_targetClass) );
		if(p_targetMember != "")
			writer.WriteAttributeString( "targetMember" ,CodeDOM_Utils.Att_ToString(p_targetMember) );
		if(p_targetClassExternalName != "")
			writer.WriteAttributeString( "targetClassExternalName" ,CodeDOM_Utils.Att_ToString(p_targetClassExternalName) );
		if(p_targetMemberExternalName != "")
			writer.WriteAttributeString( "targetMemberExternalName" ,CodeDOM_Utils.Att_ToString(p_targetMemberExternalName) );
		if(p_ignoreforsubprogram != false)
			writer.WriteAttributeString( "ignoreforsubprogram" ,CodeDOM_Utils.Att_ToString(p_ignoreforsubprogram) );
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
		if(p_l!=null)if(!p_l.Write(writer))result=false;
		if(p_r!=null)if(!p_r.Write(writer))result=false;
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
				if(reader.Name().equals("op")){
					tmpStr=CodeDOM_Utils.StringAtt_To_STRING(reader.Value());
					count=0;flag=false;
					for(int n=0;n<CodeDOM_STV.XPLBINARYOPERATORS_ENUM.length;n++){
						String str = CodeDOM_STV.XPLBINARYOPERATORS_ENUM[n];
						if(str.equals(tmpStr)){this.set_op(count);flag=true;break;}
						count++;
					}
					// if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Valor invalido del atributo 'op' en elemento '"+this.get_Name()+"'.");
				}
				else if(reader.Name().equals("targetClass")){
					this.set_targetClass(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("targetMember")){
					this.set_targetMember(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("targetClassExternalName")){
					this.set_targetClassExternalName(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("targetMemberExternalName")){
					this.set_targetMemberExternalName(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("ignoreforsubprogram")){
					this.set_ignoreforsubprogram(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
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
		this.p_l=null;
		this.p_r=null;
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("l")){
						tempNode = new XplExpression();
						tempNode.Read(reader);
						if(this.get_l()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_l((XplExpression)tempNode);
					}
					else if(reader.Name().equals("r")){
						tempNode = new XplExpression();
						tempNode.Read(reader);
						if(this.get_r()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_r((XplExpression)tempNode);
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
	public int get_op(){
		return p_op;
	}
	public String get_targetClass(){
		return p_targetClass;
	}
	public String get_targetMember(){
		return p_targetMember;
	}
	public String get_targetClassExternalName(){
		return p_targetClassExternalName;
	}
	public String get_targetMemberExternalName(){
		return p_targetMemberExternalName;
	}
	public boolean get_ignoreforsubprogram(){
		return p_ignoreforsubprogram;
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
	public XplExpression get_l(){
		return p_l;
	}
	public XplExpression get_r(){
		return p_r;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public int set_op(int new_op){
		int back_op = p_op;
		p_op = new_op;
		return back_op;
	}
	public String set_targetClass(String new_targetClass){
		String back_targetClass = p_targetClass;
		p_targetClass = new_targetClass;
		return back_targetClass;
	}
	public String set_targetMember(String new_targetMember){
		String back_targetMember = p_targetMember;
		p_targetMember = new_targetMember;
		return back_targetMember;
	}
	public String set_targetClassExternalName(String new_targetClassExternalName){
		String back_targetClassExternalName = p_targetClassExternalName;
		p_targetClassExternalName = new_targetClassExternalName;
		return back_targetClassExternalName;
	}
	public String set_targetMemberExternalName(String new_targetMemberExternalName){
		String back_targetMemberExternalName = p_targetMemberExternalName;
		p_targetMemberExternalName = new_targetMemberExternalName;
		return back_targetMemberExternalName;
	}
	public boolean set_ignoreforsubprogram(boolean new_ignoreforsubprogram){
		boolean back_ignoreforsubprogram = p_ignoreforsubprogram;
		p_ignoreforsubprogram = new_ignoreforsubprogram;
		return back_ignoreforsubprogram;
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
	public XplExpression set_l(XplExpression new_l){
		XplExpression back_l = p_l;
		p_l = new_l;
		if(p_l!=null){
			p_l.set_Name("l");
			p_l.set_Parent(this);
		}
		return back_l;
	}
	public XplExpression set_r(XplExpression new_r){
		XplExpression back_r = p_r;
		p_r = new_r;
		if(p_r!=null){
			p_r.set_Name("r");
			p_r.set_Parent(this);
		}
		return back_r;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplExpression new_l(){
		XplExpression node = new XplExpression();
		node.set_Name("l");
		return node;
	}
	public static final XplExpression new_r(){
		XplExpression node = new XplExpression();
		node.set_Name("r");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

