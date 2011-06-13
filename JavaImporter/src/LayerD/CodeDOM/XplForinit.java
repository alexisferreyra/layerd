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

public class XplForinit extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_doc;
	String p_helpURL;
	String p_ldsrc;
	boolean p_iny;
	String p_inydata;
	String p_inyby;
	String p_lddata;

	//Variables para Elementos de Choice
	XplNode p_tforinit;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplForinit(){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_tforinit=null;
	}
	public XplForinit(String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_tforinit=null;
	}
	public XplForinit(XplNode n_tforinit){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_tforinit=null;
		set_tforinit(n_tforinit);
	}
	public XplForinit(String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplNode n_tforinit){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_tforinit=null;
		set_tforinit(n_tforinit);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplForinit copy = new XplForinit();
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);

		//Variables para Elementos de Choice
		if(p_tforinit!=null)copy.set_tforinit(p_tforinit.Clone());
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplForinit;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
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
		if(p_tforinit!=null)if(!p_tforinit.Write(writer))result=false;
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
				if(reader.Name().equals("doc")){
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
		this.p_tforinit=null;
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("dl")){
						tempNode = new XplDeclaratorlist();
						tempNode.Read(reader);
					}
					else if(reader.Name().equals("el")){
						tempNode = new XplExpressionlist();
						tempNode.Read(reader);
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
			if(this.get_tforinit()!=null && tempNode!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' incorrecto como hijo de elemento '"+this.get_Name()+"'.");
			else if(tempNode!=null)this.set_tforinit(tempNode);
			reader.Read();
		}
		}
		return this;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para obtener Atributos y Elementos ">
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

	//Funciones para obtener Elementos de Choice
	public XplNode get_tforinit(){
		return p_tforinit;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
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

//Funciones para setear Elementos de Choice
	public XplNode set_tforinit(XplNode new_tforinit){
		if(new_tforinit==null)return p_tforinit;
		XplNode back_tforinit = p_tforinit;
		if(new_tforinit.get_Name().equals("dl")){
			if(new_tforinit.get_ContentTypeName()!=CodeDOMTypes.XplDeclaratorlist){
				this.set_ErrorString("El elemento de tipo '"+new_tforinit.get_ContentTypeName()+"' no es valido como componente de 'tforinit'.");
				return null;
			}
			p_tforinit = new_tforinit;
			p_tforinit.set_Parent(this);
			return back_tforinit;
		}
		if(new_tforinit.get_Name().equals("el")){
			if(new_tforinit.get_ContentTypeName()!=CodeDOMTypes.XplExpressionlist){
				this.set_ErrorString("El elemento de tipo '"+new_tforinit.get_ContentTypeName()+"' no es valido como componente de 'tforinit'.");
				return null;
			}
			p_tforinit = new_tforinit;
			p_tforinit.set_Parent(this);
			return back_tforinit;
		}
		this.set_ErrorString("El elemento de nombre '"+new_tforinit.get_Name()+"' no es valido como componente de 'tforinit'.");
		return null;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplDeclaratorlist new_dl(){
		XplDeclaratorlist node = new XplDeclaratorlist();
		node.set_Name("dl");
		return node;
	}
	public static final XplExpressionlist new_el(){
		XplExpressionlist node = new XplExpressionlist();
		node.set_Name("el");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

