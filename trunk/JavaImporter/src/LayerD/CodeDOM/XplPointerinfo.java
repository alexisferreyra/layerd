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

public class XplPointerinfo extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_memberof;
	boolean p_const;
	boolean p_volatile;
	boolean p_ref;
	boolean p_removeonvalue;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplPointerinfo(){
		p_memberof = "";
		p_const = false;
		p_volatile = false;
		p_ref = false;
		p_removeonvalue = false;
	}
	public XplPointerinfo(boolean n_const, boolean n_volatile, boolean n_ref, boolean n_removeonvalue){
		p_memberof = "";
		p_const = false;
		p_volatile = false;
		p_ref = false;
		p_removeonvalue = false;
		set_const(n_const);
		set_volatile(n_volatile);
		set_ref(n_ref);
		set_removeonvalue(n_removeonvalue);
	}
	public XplPointerinfo(String n_memberof, boolean n_const, boolean n_volatile, boolean n_ref, boolean n_removeonvalue){
		set_memberof(n_memberof);
		set_const(n_const);
		set_volatile(n_volatile);
		set_ref(n_ref);
		set_removeonvalue(n_removeonvalue);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplPointerinfo copy = new XplPointerinfo();
		copy.set_memberof(this.p_memberof);
		copy.set_const(this.p_const);
		copy.set_volatile(this.p_volatile);
		copy.set_ref(this.p_ref);
		copy.set_removeonvalue(this.p_removeonvalue);
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplPointerinfo;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_memberof != "")
			writer.WriteAttributeString( "memberof" ,CodeDOM_Utils.Att_ToString(p_memberof) );
		if(p_const != false)
			writer.WriteAttributeString( "const" ,CodeDOM_Utils.Att_ToString(p_const) );
		if(p_volatile != false)
			writer.WriteAttributeString( "volatile" ,CodeDOM_Utils.Att_ToString(p_volatile) );
		if(p_ref != false)
			writer.WriteAttributeString( "ref" ,CodeDOM_Utils.Att_ToString(p_ref) );
		if(p_removeonvalue != false)
			writer.WriteAttributeString( "removeonvalue" ,CodeDOM_Utils.Att_ToString(p_removeonvalue) );
		//Escribo recursivamente cada elemento hijo
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
				if(reader.Name().equals("memberof")){
					this.set_memberof(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("const")){
					this.set_const(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("volatile")){
					this.set_volatile(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("ref")){
					this.set_ref(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("removeonvalue")){
					this.set_removeonvalue(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else{
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Atributo '"+reader.Name()+"' invalido en elemento '"+this.get_Name()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
				case XmlNodeType.TEXT:
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".No se esperaba texto o elemento hijo en este nodo.");
				case XmlNodeType.ENDELEMENT:
					break;
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
	public String get_memberof(){
		return p_memberof;
	}
	public boolean get_const(){
		return p_const;
	}
	public boolean get_volatile(){
		return p_volatile;
	}
	public boolean get_ref(){
		return p_ref;
	}
	public boolean get_removeonvalue(){
		return p_removeonvalue;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_memberof(String new_memberof){
		String back_memberof = p_memberof;
		p_memberof = new_memberof;
		return back_memberof;
	}
	public boolean set_const(boolean new_const){
		boolean back_const = p_const;
		p_const = new_const;
		return back_const;
	}
	public boolean set_volatile(boolean new_volatile){
		boolean back_volatile = p_volatile;
		p_volatile = new_volatile;
		return back_volatile;
	}
	public boolean set_ref(boolean new_ref){
		boolean back_ref = p_ref;
		p_ref = new_ref;
		return back_ref;
	}
	public boolean set_removeonvalue(boolean new_removeonvalue){
		boolean back_removeonvalue = p_removeonvalue;
		p_removeonvalue = new_removeonvalue;
		return back_removeonvalue;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

