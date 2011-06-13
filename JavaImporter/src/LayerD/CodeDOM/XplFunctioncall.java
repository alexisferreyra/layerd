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

public class XplFunctioncall extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_name;
	String p_targetClass;
	String p_targetMember;
	String p_targetClassExternalName;
	String p_targetMemberExternalName;
	String p_ldxplcMods;
	boolean p_ignoreforsubprogram;
	boolean p_evaluateBlock;
	String p_doc;
	String p_helpURL;
	String p_ldsrc;
	boolean p_iny;
	String p_inydata;
	String p_inyby;
	String p_lddata;
	//Variables para Elementos de Secuencia
	XplExpression p_l;
	XplExpressionlist p_args;
	XplFunctionBody p_bk;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplFunctioncall(){
		p_name = "";
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ldxplcMods = "";
		p_ignoreforsubprogram = false;
		p_evaluateBlock = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_l=null;
		p_args=null;
		p_bk=null;
	}
	public XplFunctioncall(boolean n_ignoreforsubprogram, boolean n_evaluateBlock){
		p_name = "";
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ldxplcMods = "";
		p_ignoreforsubprogram = false;
		p_evaluateBlock = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_evaluateBlock(n_evaluateBlock);
		p_l=null;
		p_args=null;
		p_bk=null;
	}
	public XplFunctioncall(XplExpression n_l, XplFunctionBody n_bk){
		p_name = "";
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ldxplcMods = "";
		p_ignoreforsubprogram = false;
		p_evaluateBlock = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_l=null;
		p_args=null;
		p_bk=null;
		set_l(n_l);
		set_bk(n_bk);
	}
	public XplFunctioncall(boolean n_ignoreforsubprogram, boolean n_evaluateBlock, XplExpression n_l, XplFunctionBody n_bk){
		p_name = "";
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ldxplcMods = "";
		p_ignoreforsubprogram = false;
		p_evaluateBlock = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_evaluateBlock(n_evaluateBlock);
		p_l=null;
		p_args=null;
		p_bk=null;
		set_l(n_l);
		set_bk(n_bk);
	}
	public XplFunctioncall(String n_name, String n_targetClass, String n_targetMember, String n_targetClassExternalName, String n_targetMemberExternalName, String n_ldxplcMods, boolean n_ignoreforsubprogram, boolean n_evaluateBlock, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata){
		set_name(n_name);
		set_targetClass(n_targetClass);
		set_targetMember(n_targetMember);
		set_targetClassExternalName(n_targetClassExternalName);
		set_targetMemberExternalName(n_targetMemberExternalName);
		set_ldxplcMods(n_ldxplcMods);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_evaluateBlock(n_evaluateBlock);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_l=null;
		p_args=null;
		p_bk=null;
	}
	public XplFunctioncall(XplExpression n_l, XplExpressionlist n_args, XplFunctionBody n_bk){
		p_name = "";
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ldxplcMods = "";
		p_ignoreforsubprogram = false;
		p_evaluateBlock = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_l=null;
		p_args=null;
		p_bk=null;
		set_l(n_l);
		set_args(n_args);
		set_bk(n_bk);
	}
	public XplFunctioncall(String n_name, String n_targetClass, String n_targetMember, String n_targetClassExternalName, String n_targetMemberExternalName, String n_ldxplcMods, boolean n_ignoreforsubprogram, boolean n_evaluateBlock, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplExpression n_l, XplFunctionBody n_bk){
		set_name(n_name);
		set_targetClass(n_targetClass);
		set_targetMember(n_targetMember);
		set_targetClassExternalName(n_targetClassExternalName);
		set_targetMemberExternalName(n_targetMemberExternalName);
		set_ldxplcMods(n_ldxplcMods);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_evaluateBlock(n_evaluateBlock);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_evaluateBlock(n_evaluateBlock);
		p_l=null;
		p_args=null;
		p_bk=null;
	}
	public XplFunctioncall(boolean n_ignoreforsubprogram, boolean n_evaluateBlock, XplExpression n_l, XplExpressionlist n_args, XplFunctionBody n_bk){
		p_name = "";
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ldxplcMods = "";
		p_ignoreforsubprogram = false;
		p_evaluateBlock = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_evaluateBlock(n_evaluateBlock);
		p_l=null;
		p_args=null;
		p_bk=null;
		set_l(n_l);
		set_args(n_args);
		set_bk(n_bk);
	}
	public XplFunctioncall(String n_name, String n_targetClass, String n_targetMember, String n_targetClassExternalName, String n_targetMemberExternalName, String n_ldxplcMods, boolean n_ignoreforsubprogram, boolean n_evaluateBlock, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplExpression n_l, XplExpressionlist n_args, XplFunctionBody n_bk){
		set_name(n_name);
		set_targetClass(n_targetClass);
		set_targetMember(n_targetMember);
		set_targetClassExternalName(n_targetClassExternalName);
		set_targetMemberExternalName(n_targetMemberExternalName);
		set_ldxplcMods(n_ldxplcMods);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_evaluateBlock(n_evaluateBlock);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_l=null;
		p_args=null;
		p_bk=null;
		set_l(n_l);
		set_args(n_args);
		set_bk(n_bk);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplFunctioncall copy = new XplFunctioncall();
		copy.set_name(this.p_name);
		copy.set_targetClass(this.p_targetClass);
		copy.set_targetMember(this.p_targetMember);
		copy.set_targetClassExternalName(this.p_targetClassExternalName);
		copy.set_targetMemberExternalName(this.p_targetMemberExternalName);
		copy.set_ldxplcMods(this.p_ldxplcMods);
		copy.set_ignoreforsubprogram(this.p_ignoreforsubprogram);
		copy.set_evaluateBlock(this.p_evaluateBlock);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_l!=null)copy.set_l((XplExpression)p_l.Clone());
		if(p_args!=null)copy.set_args((XplExpressionlist)p_args.Clone());
		if(p_bk!=null)copy.set_bk((XplFunctionBody)p_bk.Clone());
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplFunctioncall;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,CodeDOM_Utils.Att_ToString(p_name) );
		if(p_targetClass != "")
			writer.WriteAttributeString( "targetClass" ,CodeDOM_Utils.Att_ToString(p_targetClass) );
		if(p_targetMember != "")
			writer.WriteAttributeString( "targetMember" ,CodeDOM_Utils.Att_ToString(p_targetMember) );
		if(p_targetClassExternalName != "")
			writer.WriteAttributeString( "targetClassExternalName" ,CodeDOM_Utils.Att_ToString(p_targetClassExternalName) );
		if(p_targetMemberExternalName != "")
			writer.WriteAttributeString( "targetMemberExternalName" ,CodeDOM_Utils.Att_ToString(p_targetMemberExternalName) );
		if(p_ldxplcMods != "")
			writer.WriteAttributeString( "ldxplcMods" ,CodeDOM_Utils.Att_ToString(p_ldxplcMods) );
		if(p_ignoreforsubprogram != false)
			writer.WriteAttributeString( "ignoreforsubprogram" ,CodeDOM_Utils.Att_ToString(p_ignoreforsubprogram) );
		if(p_evaluateBlock != false)
			writer.WriteAttributeString( "evaluateBlock" ,CodeDOM_Utils.Att_ToString(p_evaluateBlock) );
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
		if(p_args!=null)if(!p_args.Write(writer))result=false;
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
				if(reader.Name().equals("name")){
					this.set_name(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
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
				else if(reader.Name().equals("ldxplcMods")){
					this.set_ldxplcMods(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("ignoreforsubprogram")){
					this.set_ignoreforsubprogram(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("evaluateBlock")){
					this.set_evaluateBlock(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
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
		this.p_args=null;
		this.p_bk=null;
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
					else if(reader.Name().equals("args")){
						tempNode = new XplExpressionlist();
						tempNode.Read(reader);
						if(this.get_args()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_args((XplExpressionlist)tempNode);
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
	public String get_name(){
		return p_name;
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
	public String get_ldxplcMods(){
		return p_ldxplcMods;
	}
	public boolean get_ignoreforsubprogram(){
		return p_ignoreforsubprogram;
	}
	public boolean get_evaluateBlock(){
		return p_evaluateBlock;
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
	public XplExpressionlist get_args(){
		return p_args;
	}
	public XplFunctionBody get_bk(){
		return p_bk;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_name(String new_name){
		String back_name = p_name;
		p_name = new_name;
		return back_name;
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
	public String set_ldxplcMods(String new_ldxplcMods){
		String back_ldxplcMods = p_ldxplcMods;
		p_ldxplcMods = new_ldxplcMods;
		return back_ldxplcMods;
	}
	public boolean set_ignoreforsubprogram(boolean new_ignoreforsubprogram){
		boolean back_ignoreforsubprogram = p_ignoreforsubprogram;
		p_ignoreforsubprogram = new_ignoreforsubprogram;
		return back_ignoreforsubprogram;
	}
	public boolean set_evaluateBlock(boolean new_evaluateBlock){
		boolean back_evaluateBlock = p_evaluateBlock;
		p_evaluateBlock = new_evaluateBlock;
		return back_evaluateBlock;
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
	public XplExpressionlist set_args(XplExpressionlist new_args){
		XplExpressionlist back_args = p_args;
		p_args = new_args;
		if(p_args!=null){
			p_args.set_Name("args");
			p_args.set_Parent(this);
		}
		return back_args;
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
	public static final XplExpression new_l(){
		XplExpression node = new XplExpression();
		node.set_Name("l");
		return node;
	}
	public static final XplExpressionlist new_args(){
		XplExpressionlist node = new XplExpressionlist();
		node.set_Name("args");
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

