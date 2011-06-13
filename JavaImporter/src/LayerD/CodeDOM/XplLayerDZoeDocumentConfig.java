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

public class XplLayerDZoeDocumentConfig extends  XplNode implements XplNodeListCallbacks {

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_programName;
	String p_programConfig;
	//Variables para Elementos de Secuencia
	XplLanguage p_Language;
	XplLayerDCompiler p_LayerDCompiler;
	XplNodeList p_History;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplLayerDZoeDocumentConfig(){
		p_programName = "";
		p_programConfig = "";
		p_Language=null;
		p_LayerDCompiler=null;
		p_History = new XplNodeList();
		p_History.set_Parent(this);
		p_History.set_CheckNodeCallback(this);
	}
	public XplLayerDZoeDocumentConfig(XplLanguage n_Language, XplLayerDCompiler n_LayerDCompiler){
		p_programName = "";
		p_programConfig = "";
		p_Language=null;
		p_LayerDCompiler=null;
		p_History = new XplNodeList();
		p_History.set_Parent(this);
		p_History.set_CheckNodeCallback(this);
		set_Language(n_Language);
		set_LayerDCompiler(n_LayerDCompiler);
	}
	public XplLayerDZoeDocumentConfig(String n_programName, String n_programConfig){
		set_programName(n_programName);
		set_programConfig(n_programConfig);
		p_Language=null;
		p_LayerDCompiler=null;
		p_History = new XplNodeList();
		p_History.set_Parent(this);
		p_History.set_CheckNodeCallback(this);
	}
	public XplLayerDZoeDocumentConfig(XplLanguage n_Language, XplLayerDCompiler n_LayerDCompiler, XplNodeList n_History){
		p_programName = "";
		p_programConfig = "";
		p_Language=null;
		p_LayerDCompiler=null;
		p_History = new XplNodeList();
		p_History.set_Parent(this);
		p_History.set_CheckNodeCallback(this);
		set_Language(n_Language);
		set_LayerDCompiler(n_LayerDCompiler);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_History!=null)
		for(XplNode node = n_History.FirstNode(); node != null ; node = n_History.NextNode()){
			p_History.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
	}
	public XplLayerDZoeDocumentConfig(String n_programName, String n_programConfig, XplLanguage n_Language, XplLayerDCompiler n_LayerDCompiler){
		set_programName(n_programName);
		set_programConfig(n_programConfig);
		p_Language=null;
		p_LayerDCompiler=null;
		p_History = new XplNodeList();
		p_History.set_Parent(this);
		p_History.set_CheckNodeCallback(this);
	}
	public XplLayerDZoeDocumentConfig(String n_programName, String n_programConfig, XplLanguage n_Language, XplLayerDCompiler n_LayerDCompiler, XplNodeList n_History){
		set_programName(n_programName);
		set_programConfig(n_programConfig);
		p_Language=null;
		p_LayerDCompiler=null;
		p_History = new XplNodeList();
		p_History.set_Parent(this);
		p_History.set_CheckNodeCallback(this);
		set_Language(n_Language);
		set_LayerDCompiler(n_LayerDCompiler);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_History!=null)
		for(XplNode node = n_History.FirstNode(); node != null ; node = n_History.NextNode()){
			p_History.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplLayerDZoeDocumentConfig copy = new XplLayerDZoeDocumentConfig();
		copy.set_programName(this.p_programName);
		copy.set_programConfig(this.p_programConfig);
		if(p_Language!=null)copy.set_Language((XplLanguage)p_Language.Clone());
		if(p_LayerDCompiler!=null)copy.set_LayerDCompiler((XplLayerDCompiler)p_LayerDCompiler.Clone());
		for(XplNode node = p_History.FirstNode(); node != null ; node = p_History.NextNode()){
			copy.get_History().InsertAtEnd(node.Clone());
		}
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplLayerDZoeDocumentConfig;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_programName != "")
			writer.WriteAttributeString( "programName" ,CodeDOM_Utils.Att_ToString(p_programName) );
		if(p_programConfig != "")
			writer.WriteAttributeString( "programConfig" ,CodeDOM_Utils.Att_ToString(p_programConfig) );
		//Escribo recursivamente cada elemento hijo
		if(p_Language!=null)if(!p_Language.Write(writer))result=false;
		if(p_LayerDCompiler!=null)if(!p_LayerDCompiler.Write(writer))result=false;
		if(p_History!=null)if(!p_History.Write(writer))result=false;
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
				if(reader.Name().equals("programName")){
					this.set_programName(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("programConfig")){
					this.set_programConfig(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else{
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Atributo '"+reader.Name()+"' invalido en elemento '"+this.get_Name()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		//Borro todo posible nodo en memoria
		this.p_Language=null;
		this.p_LayerDCompiler=null;
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("Language")){
						tempNode = new XplLanguage();
						tempNode.Read(reader);
						if(this.get_Language()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_Language((XplLanguage)tempNode);
					}
					else if(reader.Name().equals("LayerDCompiler")){
						tempNode = new XplLayerDCompiler();
						tempNode.Read(reader);
						if(this.get_LayerDCompiler()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_LayerDCompiler((XplLayerDCompiler)tempNode);
					}
					else if(reader.Name().equals("History")){
						tempNode = new XplFileData();
						tempNode.Read(reader);
						this.get_History().InsertAtEnd(tempNode);
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
	public String get_programName(){
		return p_programName;
	}
	public String get_programConfig(){
		return p_programConfig;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplLanguage get_Language(){
		return p_Language;
	}
	public XplLayerDCompiler get_LayerDCompiler(){
		return p_LayerDCompiler;
	}
	public XplNodeList get_History(){
		return p_History;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_programName(String new_programName){
		String back_programName = p_programName;
		p_programName = new_programName;
		return back_programName;
	}
	public String set_programConfig(String new_programConfig){
		String back_programConfig = p_programConfig;
		p_programConfig = new_programConfig;
		return back_programConfig;
	}

	//Funciones para setear Elementos de Secuencia
	public boolean InsertCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		if(nodeList==p_History)return acceptInsertNodeCallback_History(node, parent);
		return false;
	}
	public boolean RemoveNodeCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		return true;
	}
	public XplLanguage set_Language(XplLanguage new_Language){
		XplLanguage back_Language = p_Language;
		p_Language = new_Language;
		if(p_Language!=null){
			p_Language.set_Name("Language");
			p_Language.set_Parent(this);
		}
		return back_Language;
	}
	public XplLayerDCompiler set_LayerDCompiler(XplLayerDCompiler new_LayerDCompiler){
		XplLayerDCompiler back_LayerDCompiler = p_LayerDCompiler;
		p_LayerDCompiler = new_LayerDCompiler;
		if(p_LayerDCompiler!=null){
			p_LayerDCompiler.set_Name("LayerDCompiler");
			p_LayerDCompiler.set_Parent(this);
		}
		return back_LayerDCompiler;
	}
	public boolean acceptInsertNodeCallback_History(XplNode node, XplNode parent){
		if(node==null)return false;
		if(node.get_Name().equals("History")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFileData){
			this.set_ErrorString("El elemento de tipo '"+node.get_ContentTypeName()+"' no es valido como componente de 'XplFileData'.");
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		this.set_ErrorString("El elemento de nombre '"+node.get_Name()+"' no es valido como componente de 'XplFileData'.");
		return false;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplLanguage new_Language(){
		XplLanguage node = new XplLanguage();
		node.set_Name("Language");
		return node;
	}
	public static final XplLayerDCompiler new_LayerDCompiler(){
		XplLayerDCompiler node = new XplLayerDCompiler();
		node.set_Name("LayerDCompiler");
		return node;
	}
	public static final XplFileData new_History(){
		XplFileData node = new XplFileData();
		node.set_Name("History");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

