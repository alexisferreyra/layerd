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

public class XplClassMembersList extends  XplNode implements XplNodeListCallbacks {

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	//Variables para Elementos de Secuencia
	XplNodeList p_Childs;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplClassMembersList(){
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
	}
	public XplClassMembersList(XplNodeList n_Childs){
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
		XplClassMembersList copy = new XplClassMembersList();
		for(XplNode node = p_Childs.FirstNode(); node != null ; node = p_Childs.NextNode()){
			copy.Childs().InsertAtEnd(node.Clone());
		}
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplClassMembersList;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
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
					if(reader.Name().equals("Inherits")){
						tempNode = new XplInherits();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Implements")){
						tempNode = new XplInherits();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Function")){
						tempNode = new XplFunction();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Operator")){
						tempNode = new XplFunction();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Indexer")){
						tempNode = new XplFunction();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Property")){
						tempNode = new XplProperty();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Field")){
						tempNode = new XplField();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("e")){
						tempNode = new XplExpression();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Class")){
						tempNode = new XplClass();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("documentation")){
						tempNode = new XplDocumentation();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("BeginCFPermissions")){
						tempNode = new XplClassfactorysPermissions();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("EndCFPermissions")){
						tempNode = new XplNode(XplNodeType_enum.EMPTY);
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("SetPlatforms")){
						tempNode = new XplSetPlatforms();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("AutoInstance")){
						tempNode = new XplAutoInstance();
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
	//Funciones para obtener Elementos de Secuencia
	public XplNodeList Childs(){
		return p_Childs;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">

	//Funciones para setear Elementos de Secuencia
	public boolean InsertCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		if(node==null)return false;
		if(node.get_Name().equals("Inherits")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplInherits){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Implements")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplInherits){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Function")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunction){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Operator")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunction){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Indexer")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunction){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Property")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplProperty){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Field")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplField){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("e")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplExpression){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Class")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplClass){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("documentation")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplDocumentation){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("BeginCFPermissions")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplClassfactorysPermissions){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("EndCFPermissions")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplNode){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("SetPlatforms")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplSetPlatforms){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("AutoInstance")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplAutoInstance){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.");
			}
			node.set_Parent(parent);
			return true;
		}
		//throw new CodeDOM_Exception("El elemento de nombre '"+node.get_Name()+"' no es valido como componente de 'XplClassMembersList'.");
		return false;
	}
	public boolean RemoveNodeCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		return true;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para filtrado en Listas de Nodos
	public XplNodeList get_InheritsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Inherits")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_ImplementsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Implements")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_FunctionNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Function")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_OperatorNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Operator")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_IndexerNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Indexer")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_PropertyNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Property")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_FieldNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Field")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_eNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("e")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_ClassNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Class")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_documentationNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("documentation")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_BeginCFPermissionsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("BeginCFPermissions")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_EndCFPermissionsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("EndCFPermissions")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_SetPlatformsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("SetPlatforms")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_AutoInstanceNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("AutoInstance")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}


	//Funciones para obtener nuevos nodos hijos
	public static final XplInherits new_Inherits(){
		XplInherits node = new XplInherits();
		node.set_Name("Inherits");
		return node;
	}
	public static final XplInherits new_Implements(){
		XplInherits node = new XplInherits();
		node.set_Name("Implements");
		return node;
	}
	public static final XplFunction new_Function(){
		XplFunction node = new XplFunction();
		node.set_Name("Function");
		return node;
	}
	public static final XplFunction new_Operator(){
		XplFunction node = new XplFunction();
		node.set_Name("Operator");
		return node;
	}
	public static final XplFunction new_Indexer(){
		XplFunction node = new XplFunction();
		node.set_Name("Indexer");
		return node;
	}
	public static final XplProperty new_Property(){
		XplProperty node = new XplProperty();
		node.set_Name("Property");
		return node;
	}
	public static final XplField new_Field(){
		XplField node = new XplField();
		node.set_Name("Field");
		return node;
	}
	public static final XplExpression new_e(){
		XplExpression node = new XplExpression();
		node.set_Name("e");
		return node;
	}
	public static final XplClass new_Class(){
		XplClass node = new XplClass();
		node.set_Name("Class");
		return node;
	}
	public static final XplDocumentation new_documentation(){
		XplDocumentation node = new XplDocumentation();
		node.set_Name("documentation");
		return node;
	}
	public static final XplClassfactorysPermissions new_BeginCFPermissions(){
		XplClassfactorysPermissions node = new XplClassfactorysPermissions();
		node.set_Name("BeginCFPermissions");
		return node;
	}
	public static final XplNode new_EndCFPermissions(){
		XplNode node = new XplNode(XplNodeType_enum.EMPTY);
		node.set_Name("EndCFPermissions");
		return node;
	}
	public static final XplSetPlatforms new_SetPlatforms(){
		XplSetPlatforms node = new XplSetPlatforms();
		node.set_Name("SetPlatforms");
		return node;
	}
	public static final XplAutoInstance new_AutoInstance(){
		XplAutoInstance node = new XplAutoInstance();
		node.set_Name("AutoInstance");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

