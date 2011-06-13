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

public class XplIfStatement extends  XplNode implements XplNodeListCallbacks {

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_doc;
	String p_helpURL;
	String p_ldsrc;
	boolean p_iny;
	String p_inydata;
	String p_inyby;
	String p_lddata;
	//Variables para Elementos de Secuencia
	XplExpression p_boolean;
	XplFunctionBody p_ifbk;
	XplNodeList p_elseif;
	XplFunctionBody p_else;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplIfStatement(){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_boolean=null;
		p_ifbk=null;
		p_elseif = new XplNodeList();
		p_elseif.set_Parent(this);
		p_elseif.set_CheckNodeCallback(this);
		p_else=null;
	}
	public XplIfStatement(XplExpression n_boolean){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_boolean=null;
		p_ifbk=null;
		p_elseif = new XplNodeList();
		p_elseif.set_Parent(this);
		p_elseif.set_CheckNodeCallback(this);
		p_else=null;
		set_boolean(n_boolean);
	}
	public XplIfStatement(String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_boolean=null;
		p_ifbk=null;
		p_elseif = new XplNodeList();
		p_elseif.set_Parent(this);
		p_elseif.set_CheckNodeCallback(this);
		p_else=null;
	}
	public XplIfStatement(XplExpression n_boolean, XplFunctionBody n_ifbk, XplNodeList n_elseif, XplFunctionBody n_else){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_boolean=null;
		p_ifbk=null;
		p_elseif = new XplNodeList();
		p_elseif.set_Parent(this);
		p_elseif.set_CheckNodeCallback(this);
		p_else=null;
		set_boolean(n_boolean);
		set_ifbk(n_ifbk);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_elseif!=null)
		for(XplNode node = n_elseif.FirstNode(); node != null ; node = n_elseif.NextNode()){
			p_elseif.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
		set_else(n_else);
	}
	public XplIfStatement(String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplExpression n_boolean){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_boolean=null;
		p_ifbk=null;
		p_elseif = new XplNodeList();
		p_elseif.set_Parent(this);
		p_elseif.set_CheckNodeCallback(this);
		p_else=null;
	}
	public XplIfStatement(String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplExpression n_boolean, XplFunctionBody n_ifbk, XplNodeList n_elseif, XplFunctionBody n_else){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_boolean=null;
		p_ifbk=null;
		p_elseif = new XplNodeList();
		p_elseif.set_Parent(this);
		p_elseif.set_CheckNodeCallback(this);
		p_else=null;
		set_boolean(n_boolean);
		set_ifbk(n_ifbk);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_elseif!=null)
		for(XplNode node = n_elseif.FirstNode(); node != null ; node = n_elseif.NextNode()){
			p_elseif.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
		set_else(n_else);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplIfStatement copy = new XplIfStatement();
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_boolean!=null)copy.set_boolean((XplExpression)p_boolean.Clone());
		if(p_ifbk!=null)copy.set_ifbk((XplFunctionBody)p_ifbk.Clone());
		for(XplNode node = p_elseif.FirstNode(); node != null ; node = p_elseif.NextNode()){
			copy.get_elseif().InsertAtEnd(node.Clone());
		}
		if(p_else!=null)copy.set_else((XplFunctionBody)p_else.Clone());
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplIfStatement;}

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
		if(p_boolean!=null)if(!p_boolean.Write(writer))result=false;
		if(p_ifbk!=null)if(!p_ifbk.Write(writer))result=false;
		if(p_elseif!=null)if(!p_elseif.Write(writer))result=false;
		if(p_else!=null)if(!p_else.Write(writer))result=false;
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
		//Borro todo posible nodo en memoria
		this.p_boolean=null;
		this.p_ifbk=null;
		this.p_else=null;
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("boolean")){
						tempNode = new XplExpression();
						tempNode.Read(reader);
						if(this.get_boolean()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_boolean((XplExpression)tempNode);
					}
					else if(reader.Name().equals("ifbk")){
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						if(this.get_ifbk()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_ifbk((XplFunctionBody)tempNode);
					}
					else if(reader.Name().equals("elseif")){
						tempNode = new XplIfStatement();
						tempNode.Read(reader);
						this.get_elseif().InsertAtEnd(tempNode);
					}
					else if(reader.Name().equals("else")){
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						if(this.get_else()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_else((XplFunctionBody)tempNode);
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
	public XplExpression get_boolean(){
		return p_boolean;
	}
	public XplFunctionBody get_ifbk(){
		return p_ifbk;
	}
	public XplNodeList get_elseif(){
		return p_elseif;
	}
	public XplFunctionBody get_else(){
		return p_else;
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

	//Funciones para setear Elementos de Secuencia
	public boolean InsertCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		if(nodeList==p_elseif)return acceptInsertNodeCallback_elseif(node, parent);
		return false;
	}
	public boolean RemoveNodeCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		return true;
	}
	public XplExpression set_boolean(XplExpression new_boolean){
		XplExpression back_boolean = p_boolean;
		p_boolean = new_boolean;
		if(p_boolean!=null){
			p_boolean.set_Name("boolean");
			p_boolean.set_Parent(this);
		}
		return back_boolean;
	}
	public XplFunctionBody set_ifbk(XplFunctionBody new_ifbk){
		XplFunctionBody back_ifbk = p_ifbk;
		p_ifbk = new_ifbk;
		if(p_ifbk!=null){
			p_ifbk.set_Name("ifbk");
			p_ifbk.set_Parent(this);
		}
		return back_ifbk;
	}
	public boolean acceptInsertNodeCallback_elseif(XplNode node, XplNode parent){
		if(node==null)return false;
		if(node.get_Name().equals("elseif")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplIfStatement){
			this.set_ErrorString("El elemento de tipo '"+node.get_ContentTypeName()+"' no es valido como componente de 'XplIfStatement'.");
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		this.set_ErrorString("El elemento de nombre '"+node.get_Name()+"' no es valido como componente de 'XplIfStatement'.");
		return false;
	}
	public XplFunctionBody set_else(XplFunctionBody new_else){
		XplFunctionBody back_else = p_else;
		p_else = new_else;
		if(p_else!=null){
			p_else.set_Name("else");
			p_else.set_Parent(this);
		}
		return back_else;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplExpression new_boolean(){
		XplExpression node = new XplExpression();
		node.set_Name("boolean");
		return node;
	}
	public static final XplFunctionBody new_ifbk(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_Name("ifbk");
		return node;
	}
	public static final XplIfStatement new_elseif(){
		XplIfStatement node = new XplIfStatement();
		node.set_Name("elseif");
		return node;
	}
	public static final XplFunctionBody new_else(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_Name("else");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

