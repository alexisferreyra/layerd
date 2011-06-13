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

public class XplDocument extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	//Variables para Elementos de Secuencia
	XplDocumentData p_DocumentData;
	XplDocumentBody p_DocumentBody;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplDocument(){
		p_DocumentData=null;
		p_DocumentBody=null;
	}
	public XplDocument(XplDocumentData n_DocumentData, XplDocumentBody n_DocumentBody){
		p_DocumentData=null;
		p_DocumentBody=null;
		set_DocumentData(n_DocumentData);
		set_DocumentBody(n_DocumentBody);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplDocument copy = new XplDocument();
		if(p_DocumentData!=null)copy.set_DocumentData((XplDocumentData)p_DocumentData.Clone());
		if(p_DocumentBody!=null)copy.set_DocumentBody((XplDocumentBody)p_DocumentBody.Clone());
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplDocument;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		//Escribo recursivamente cada elemento hijo
		if(p_DocumentData!=null)if(!p_DocumentData.Write(writer))result=false;
		if(p_DocumentBody!=null)if(!p_DocumentBody.Write(writer))result=false;
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
		this.p_DocumentData=null;
		this.p_DocumentBody=null;
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("DocumentData")){
						tempNode = new XplDocumentData();
						tempNode.Read(reader);
						if(this.get_DocumentData()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_DocumentData((XplDocumentData)tempNode);
					}
					else if(reader.Name().equals("DocumentBody")){
						tempNode = new XplDocumentBody();
						tempNode.Read(reader);
						if(this.get_DocumentBody()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_DocumentBody((XplDocumentBody)tempNode);
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
	public XplDocumentData get_DocumentData(){
		return p_DocumentData;
	}
	public XplDocumentBody get_DocumentBody(){
		return p_DocumentBody;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">

	//Funciones para setear Elementos de Secuencia
	public XplDocumentData set_DocumentData(XplDocumentData new_DocumentData){
		XplDocumentData back_DocumentData = p_DocumentData;
		p_DocumentData = new_DocumentData;
		if(p_DocumentData!=null){
			p_DocumentData.set_Name("DocumentData");
			p_DocumentData.set_Parent(this);
		}
		return back_DocumentData;
	}
	public XplDocumentBody set_DocumentBody(XplDocumentBody new_DocumentBody){
		XplDocumentBody back_DocumentBody = p_DocumentBody;
		p_DocumentBody = new_DocumentBody;
		if(p_DocumentBody!=null){
			p_DocumentBody.set_Name("DocumentBody");
			p_DocumentBody.set_Parent(this);
		}
		return back_DocumentBody;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplDocumentData new_DocumentData(){
		XplDocumentData node = new XplDocumentData();
		node.set_Name("DocumentData");
		return node;
	}
	public static final XplDocumentBody new_DocumentBody(){
		XplDocumentBody node = new XplDocumentBody();
		node.set_Name("DocumentBody");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

