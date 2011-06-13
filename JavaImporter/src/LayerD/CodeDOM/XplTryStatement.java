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

public class XplTryStatement extends  XplNode implements XplNodeListCallbacks {

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_doc;
	String p_helpURL;
	String p_ldsrc;
	boolean p_iny;
	String p_inydata;
	String p_inyby;
	String p_lddata;
	//Variables para Elementos de Secuencia
	XplFunctionBody p_trybk;
	XplNodeList p_catchbk;
	XplFunctionBody p_finallybk;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplTryStatement(){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_trybk=null;
		p_catchbk = new XplNodeList();
		p_catchbk.set_Parent(this);
		p_catchbk.set_CheckNodeCallback(this);
		p_finallybk=null;
	}
	public XplTryStatement(XplFunctionBody n_trybk, XplNodeList n_catchbk){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_trybk=null;
		p_catchbk = new XplNodeList();
		p_catchbk.set_Parent(this);
		p_catchbk.set_CheckNodeCallback(this);
		p_finallybk=null;
		set_trybk(n_trybk);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_catchbk!=null)
		for(XplNode node = n_catchbk.FirstNode(); node != null ; node = n_catchbk.NextNode()){
			p_catchbk.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
	}
	public XplTryStatement(String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_trybk=null;
		p_catchbk = new XplNodeList();
		p_catchbk.set_Parent(this);
		p_catchbk.set_CheckNodeCallback(this);
		p_finallybk=null;
	}
	public XplTryStatement(XplFunctionBody n_trybk, XplNodeList n_catchbk, XplFunctionBody n_finallybk){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_trybk=null;
		p_catchbk = new XplNodeList();
		p_catchbk.set_Parent(this);
		p_catchbk.set_CheckNodeCallback(this);
		p_finallybk=null;
		set_trybk(n_trybk);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_catchbk!=null)
		for(XplNode node = n_catchbk.FirstNode(); node != null ; node = n_catchbk.NextNode()){
			p_catchbk.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
		set_finallybk(n_finallybk);
	}
	public XplTryStatement(String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplFunctionBody n_trybk, XplNodeList n_catchbk){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_trybk=null;
		p_catchbk = new XplNodeList();
		p_catchbk.set_Parent(this);
		p_catchbk.set_CheckNodeCallback(this);
		p_finallybk=null;
	}
	public XplTryStatement(String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplFunctionBody n_trybk, XplNodeList n_catchbk, XplFunctionBody n_finallybk){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_trybk=null;
		p_catchbk = new XplNodeList();
		p_catchbk.set_Parent(this);
		p_catchbk.set_CheckNodeCallback(this);
		p_finallybk=null;
		set_trybk(n_trybk);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_catchbk!=null)
		for(XplNode node = n_catchbk.FirstNode(); node != null ; node = n_catchbk.NextNode()){
			p_catchbk.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
		set_finallybk(n_finallybk);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplTryStatement copy = new XplTryStatement();
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_trybk!=null)copy.set_trybk((XplFunctionBody)p_trybk.Clone());
		for(XplNode node = p_catchbk.FirstNode(); node != null ; node = p_catchbk.NextNode()){
			copy.get_catchbk().InsertAtEnd(node.Clone());
		}
		if(p_finallybk!=null)copy.set_finallybk((XplFunctionBody)p_finallybk.Clone());
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplTryStatement;}

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
		if(p_trybk!=null)if(!p_trybk.Write(writer))result=false;
		if(p_catchbk!=null)if(!p_catchbk.Write(writer))result=false;
		if(p_finallybk!=null)if(!p_finallybk.Write(writer))result=false;
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
		this.p_trybk=null;
		this.p_finallybk=null;
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("trybk")){
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						if(this.get_trybk()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_trybk((XplFunctionBody)tempNode);
					}
					else if(reader.Name().equals("catchbk")){
						tempNode = new XplCatchStatement();
						tempNode.Read(reader);
						this.get_catchbk().InsertAtEnd(tempNode);
					}
					else if(reader.Name().equals("finallybk")){
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						if(this.get_finallybk()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_finallybk((XplFunctionBody)tempNode);
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
	public XplFunctionBody get_trybk(){
		return p_trybk;
	}
	public XplNodeList get_catchbk(){
		return p_catchbk;
	}
	public XplFunctionBody get_finallybk(){
		return p_finallybk;
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
		if(nodeList==p_catchbk)return acceptInsertNodeCallback_catchbk(node, parent);
		return false;
	}
	public boolean RemoveNodeCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		return true;
	}
	public XplFunctionBody set_trybk(XplFunctionBody new_trybk){
		XplFunctionBody back_trybk = p_trybk;
		p_trybk = new_trybk;
		if(p_trybk!=null){
			p_trybk.set_Name("trybk");
			p_trybk.set_Parent(this);
		}
		return back_trybk;
	}
	public boolean acceptInsertNodeCallback_catchbk(XplNode node, XplNode parent){
		if(node==null)return false;
		if(node.get_Name().equals("catchbk")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplCatchStatement){
			this.set_ErrorString("El elemento de tipo '"+node.get_ContentTypeName()+"' no es valido como componente de 'XplCatchStatement'.");
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		this.set_ErrorString("El elemento de nombre '"+node.get_Name()+"' no es valido como componente de 'XplCatchStatement'.");
		return false;
	}
	public XplFunctionBody set_finallybk(XplFunctionBody new_finallybk){
		XplFunctionBody back_finallybk = p_finallybk;
		p_finallybk = new_finallybk;
		if(p_finallybk!=null){
			p_finallybk.set_Name("finallybk");
			p_finallybk.set_Parent(this);
		}
		return back_finallybk;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplFunctionBody new_trybk(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_Name("trybk");
		return node;
	}
	public static final XplCatchStatement new_catchbk(){
		XplCatchStatement node = new XplCatchStatement();
		node.set_Name("catchbk");
		return node;
	}
	public static final XplFunctionBody new_finallybk(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_Name("finallybk");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

