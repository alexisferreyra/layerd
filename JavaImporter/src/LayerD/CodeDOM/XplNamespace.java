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

public class XplNamespace extends  XplNode implements XplNodeListCallbacks {

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_name;
	String p_internalname;
	String p_externalname;
	boolean p_external;
	boolean p_donotrender;
	String p_doc;
	String p_helpURL;
	String p_ldsrc;
	boolean p_iny;
	String p_inydata;
	String p_inyby;
	String p_lddata;
	//Variables para Elementos de Secuencia
	XplNodeList p_Childs;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplNamespace(){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_external = false;
		p_donotrender = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
	}
	public XplNamespace(String n_name, boolean n_external, boolean n_donotrender){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_external = false;
		p_donotrender = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_name(n_name);
		set_external(n_external);
		set_donotrender(n_donotrender);
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
	}
	public XplNamespace(String n_name, String n_internalname, String n_externalname, boolean n_external, boolean n_donotrender, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata){
		set_name(n_name);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_external(n_external);
		set_donotrender(n_donotrender);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
	}
	public XplNamespace(XplNodeList n_Childs){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_external = false;
		p_donotrender = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
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
	public XplNamespace(String n_name, boolean n_external, boolean n_donotrender, XplNodeList n_Childs){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_external = false;
		p_donotrender = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_name(n_name);
		set_external(n_external);
		set_donotrender(n_donotrender);
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
	public XplNamespace(String n_name, String n_internalname, String n_externalname, boolean n_external, boolean n_donotrender, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplNodeList n_Childs){
		set_name(n_name);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_external(n_external);
		set_donotrender(n_donotrender);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
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
		XplNamespace copy = new XplNamespace();
		copy.set_name(this.p_name);
		copy.set_internalname(this.p_internalname);
		copy.set_externalname(this.p_externalname);
		copy.set_external(this.p_external);
		copy.set_donotrender(this.p_donotrender);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		for(XplNode node = p_Childs.FirstNode(); node != null ; node = p_Childs.NextNode()){
			copy.Childs().InsertAtEnd(node.Clone());
		}
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplNamespace;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,CodeDOM_Utils.Att_ToString(p_name) );
		if(p_internalname != "")
			writer.WriteAttributeString( "internalname" ,CodeDOM_Utils.Att_ToString(p_internalname) );
		if(p_externalname != "")
			writer.WriteAttributeString( "externalname" ,CodeDOM_Utils.Att_ToString(p_externalname) );
		if(p_external != false)
			writer.WriteAttributeString( "external" ,CodeDOM_Utils.Att_ToString(p_external) );
		if(p_donotrender != false)
			writer.WriteAttributeString( "donotrender" ,CodeDOM_Utils.Att_ToString(p_donotrender) );
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
				if(reader.Name().equals("name")){
					this.set_name(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("internalname")){
					this.set_internalname(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("externalname")){
					this.set_externalname(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("external")){
					this.set_external(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("donotrender")){
					this.set_donotrender(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
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
		p_Childs.Clear(); //Borro todo posible hijo en memoria
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("Class")){
						tempNode = new XplClass();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Namespace")){
						tempNode = new XplNamespace();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Section")){
						tempNode = new XplNamespace();
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
					else if(reader.Name().equals("documentation")){
						tempNode = new XplDocumentation();
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
	public String get_name(){
		return p_name;
	}
	public String get_internalname(){
		return p_internalname;
	}
	public String get_externalname(){
		return p_externalname;
	}
	public boolean get_external(){
		return p_external;
	}
	public boolean get_donotrender(){
		return p_donotrender;
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
	public XplNodeList Childs(){
		return p_Childs;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_name(String new_name){
		String back_name = p_name;
		p_name = new_name;
		return back_name;
	}
	public String set_internalname(String new_internalname){
		String back_internalname = p_internalname;
		p_internalname = new_internalname;
		return back_internalname;
	}
	public String set_externalname(String new_externalname){
		String back_externalname = p_externalname;
		p_externalname = new_externalname;
		return back_externalname;
	}
	public boolean set_external(boolean new_external){
		boolean back_external = p_external;
		p_external = new_external;
		return back_external;
	}
	public boolean set_donotrender(boolean new_donotrender){
		boolean back_donotrender = p_donotrender;
		p_donotrender = new_donotrender;
		return back_donotrender;
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
	public boolean InsertCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		if(node==null)return false;
		if(node.get_Name().equals("Class")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplClass){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplNamespace'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Namespace")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplNamespace){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplNamespace'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Section")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplNamespace){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplNamespace'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("e")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplExpression){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplNamespace'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("BeginCFPermissions")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplClassfactorysPermissions){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplNamespace'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("EndCFPermissions")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplNode){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplNamespace'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("documentation")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplDocumentation){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplNamespace'.");
			}
			node.set_Parent(parent);
			return true;
		}
		//throw new CodeDOM_Exception("El elemento de nombre '"+node.get_Name()+"' no es valido como componente de 'XplNamespace'.");
		return false;
	}
	public boolean RemoveNodeCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		return true;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para filtrado en Listas de Nodos
	public XplNodeList get_ClassNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Class")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_NamespaceNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Namespace")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_SectionNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Section")){
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
	public XplNodeList get_documentationNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("documentation")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}


	//Funciones para obtener nuevos nodos hijos
	public static final XplClass new_Class(){
		XplClass node = new XplClass();
		node.set_Name("Class");
		return node;
	}
	public static final XplNamespace new_Namespace(){
		XplNamespace node = new XplNamespace();
		node.set_Name("Namespace");
		return node;
	}
	public static final XplNamespace new_Section(){
		XplNamespace node = new XplNamespace();
		node.set_Name("Section");
		return node;
	}
	public static final XplExpression new_e(){
		XplExpression node = new XplExpression();
		node.set_Name("e");
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
	public static final XplDocumentation new_documentation(){
		XplDocumentation node = new XplDocumentation();
		node.set_Name("documentation");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

