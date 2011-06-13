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

public class XplLayerDErrorInterchangeConfig extends  XplNode implements XplNodeListCallbacks {

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	//Variables para Elementos de Secuencia
	XplNodeList p_Warning;
	XplNodeList p_Error;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplLayerDErrorInterchangeConfig(){
		p_Warning = new XplNodeList();
		p_Warning.set_Parent(this);
		p_Warning.set_CheckNodeCallback(this);
		p_Error = new XplNodeList();
		p_Error.set_Parent(this);
		p_Error.set_CheckNodeCallback(this);
	}
	public XplLayerDErrorInterchangeConfig(XplNodeList n_Warning, XplNodeList n_Error){
		p_Warning = new XplNodeList();
		p_Warning.set_Parent(this);
		p_Warning.set_CheckNodeCallback(this);
		p_Error = new XplNodeList();
		p_Error.set_Parent(this);
		p_Error.set_CheckNodeCallback(this);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Warning!=null)
		for(XplNode node = n_Warning.FirstNode(); node != null ; node = n_Warning.NextNode()){
			p_Warning.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Error!=null)
		for(XplNode node = n_Error.FirstNode(); node != null ; node = n_Error.NextNode()){
			p_Error.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplLayerDErrorInterchangeConfig copy = new XplLayerDErrorInterchangeConfig();
		for(XplNode node = p_Warning.FirstNode(); node != null ; node = p_Warning.NextNode()){
			copy.get_Warning().InsertAtEnd(node.Clone());
		}
		for(XplNode node = p_Error.FirstNode(); node != null ; node = p_Error.NextNode()){
			copy.get_Error().InsertAtEnd(node.Clone());
		}
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplLayerDErrorInterchangeConfig;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		//Escribo recursivamente cada elemento hijo
		if(p_Warning!=null)if(!p_Warning.Write(writer))result=false;
		if(p_Error!=null)if(!p_Error.Write(writer))result=false;
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
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		//Borro todo posible nodo en memoria
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("Warning")){
						tempNode = new XplError();
						tempNode.Read(reader);
						this.get_Warning().InsertAtEnd(tempNode);
					}
					else if(reader.Name().equals("Error")){
						tempNode = new XplError();
						tempNode.Read(reader);
						this.get_Error().InsertAtEnd(tempNode);
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
	//Funciones para obtener Elementos de Secuencia
	public XplNodeList get_Warning(){
		return p_Warning;
	}
	public XplNodeList get_Error(){
		return p_Error;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">

	//Funciones para setear Elementos de Secuencia
	public boolean InsertCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		if(nodeList==p_Warning)return acceptInsertNodeCallback_Warning(node, parent);
		if(nodeList==p_Error)return acceptInsertNodeCallback_Error(node, parent);
		return false;
	}
	public boolean RemoveNodeCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		return true;
	}
	public boolean acceptInsertNodeCallback_Warning(XplNode node, XplNode parent){
		if(node==null)return false;
		if(node.get_Name().equals("Warning")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplError){
			this.set_ErrorString("El elemento de tipo '"+node.get_ContentTypeName()+"' no es valido como componente de 'XplError'.");
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		this.set_ErrorString("El elemento de nombre '"+node.get_Name()+"' no es valido como componente de 'XplError'.");
		return false;
	}
	public boolean acceptInsertNodeCallback_Error(XplNode node, XplNode parent){
		if(node==null)return false;
		if(node.get_Name().equals("Error")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplError){
			this.set_ErrorString("El elemento de tipo '"+node.get_ContentTypeName()+"' no es valido como componente de 'XplError'.");
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		this.set_ErrorString("El elemento de nombre '"+node.get_Name()+"' no es valido como componente de 'XplError'.");
		return false;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplError new_Warning(){
		XplError node = new XplError();
		node.set_Name("Warning");
		return node;
	}
	public static final XplError new_Error(){
		XplError node = new XplError();
		node.set_Name("Error");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

