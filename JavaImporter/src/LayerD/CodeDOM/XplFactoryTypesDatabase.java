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

public class XplFactoryTypesDatabase extends  XplNode implements XplNodeListCallbacks {

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	int p_version;
	//Variables para Elementos de Secuencia
	XplNodeList p_Childs;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplFactoryTypesDatabase(){
		p_version = 1;
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
	}
	public XplFactoryTypesDatabase(int n_version){
		p_version = 1;
		set_version(n_version);
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
	}
	public XplFactoryTypesDatabase(XplNodeList n_Childs){
		p_version = 1;
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Childs!=null)
		for(XplNode node = n_Childs.FirstNode(); node != null ; node = n_Childs.NextNode()){
			p_Childs.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
	}
	public XplFactoryTypesDatabase(int n_version, XplNodeList n_Childs){
		p_version = 1;
		set_version(n_version);
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Childs!=null)
		for(XplNode node = n_Childs.FirstNode(); node != null ; node = n_Childs.NextNode()){
			p_Childs.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplFactoryTypesDatabase copy = new XplFactoryTypesDatabase();
		copy.set_version(this.p_version);
		for(XplNode node = p_Childs.FirstNode(); node != null ; node = p_Childs.NextNode()){
			copy.Childs().InsertAtEnd(node.Clone());
		}
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplFactoryTypesDatabase;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_version != 1)
			writer.WriteAttributeString( "version" ,CodeDOM_Utils.Att_ToString(p_version) );
		//Escribo recursivamente cada elemento hijo
		if(p_Childs!=null)if(!p_Childs.Write(writer))result=false;
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
				if(reader.Name().equals("version")){
					this.set_version(CodeDOM_Utils.StringAtt_To_INT(reader.Value()));
				}
				else{
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Atributo '"+reader.Name()+"' invalido en elemento '"+this.get_Name()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		p_Childs.Clear(); //Borro todo posible hijo en memoria
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("Classfactory")){
						tempNode = new XplClassfactoryData();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else{
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nombre de nodo '"+reader.Name()+"' inesperado como hijo de elemento '"+this.get_Name()+"'.");
					}
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
	public int get_version(){
		return p_version;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplNodeList Childs(){
		return p_Childs;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public int set_version(int new_version){
		int back_version = p_version;
		p_version = new_version;
		return back_version;
	}

	//Funciones para setear Elementos de Secuencia
	public boolean InsertCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		if(node==null)return false;
		if(node.get_Name().equals("Classfactory")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplClassfactoryData){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFactoryTypesDatabase'.");
			}
			node.set_Parent(parent);
			return true;
		}
		//throw new CodeDOM_Exception("El elemento de nombre '"+node.get_Name()+"' no es valido como componente de 'XplFactoryTypesDatabase'.");
		return false;
	}
	public boolean RemoveNodeCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		return true;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para filtrado en Listas de Nodos
	public XplNodeList get_ClassfactoryNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Classfactory")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}


	//Funciones para obtener nuevos nodos hijos
	public static final XplClassfactoryData new_Classfactory(){
		XplClassfactoryData node = new XplClassfactoryData();
		node.set_Name("Classfactory");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

