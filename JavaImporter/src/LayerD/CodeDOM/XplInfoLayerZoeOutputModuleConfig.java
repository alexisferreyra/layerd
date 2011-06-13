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

public class XplInfoLayerZoeOutputModuleConfig extends  XplNode implements XplNodeListCallbacks {

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_name;
	String p_especifiedClass;
	String p_defaultPlatform;
	//Variables para Elementos de Secuencia
	XplNodeList p_SupportedPlatform;
	XplNodeList p_PlatformAlias;
	XplOutputModuleCapabilities p_Capabilities;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplInfoLayerZoeOutputModuleConfig(){
		p_name = "";
		p_especifiedClass = "";
		p_defaultPlatform = "";
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_CheckNodeCallback(this);
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_CheckNodeCallback(this);
		p_Capabilities=null;
	}
	public XplInfoLayerZoeOutputModuleConfig(String n_name){
		p_name = "";
		p_especifiedClass = "";
		p_defaultPlatform = "";
		set_name(n_name);
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_CheckNodeCallback(this);
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_CheckNodeCallback(this);
		p_Capabilities=null;
	}
	public XplInfoLayerZoeOutputModuleConfig(XplNodeList n_SupportedPlatform, XplOutputModuleCapabilities n_Capabilities){
		p_name = "";
		p_especifiedClass = "";
		p_defaultPlatform = "";
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_CheckNodeCallback(this);
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_CheckNodeCallback(this);
		p_Capabilities=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SupportedPlatform!=null)
		for(XplNode node = n_SupportedPlatform.FirstNode(); node != null ; node = n_SupportedPlatform.NextNode()){
			p_SupportedPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
		set_Capabilities(n_Capabilities);
	}
	public XplInfoLayerZoeOutputModuleConfig(String n_name, XplNodeList n_SupportedPlatform, XplOutputModuleCapabilities n_Capabilities){
		p_name = "";
		p_especifiedClass = "";
		p_defaultPlatform = "";
		set_name(n_name);
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_CheckNodeCallback(this);
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_CheckNodeCallback(this);
		p_Capabilities=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SupportedPlatform!=null)
		for(XplNode node = n_SupportedPlatform.FirstNode(); node != null ; node = n_SupportedPlatform.NextNode()){
			p_SupportedPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
		set_Capabilities(n_Capabilities);
	}
	public XplInfoLayerZoeOutputModuleConfig(String n_name, String n_especifiedClass, String n_defaultPlatform){
		set_name(n_name);
		set_especifiedClass(n_especifiedClass);
		set_defaultPlatform(n_defaultPlatform);
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_CheckNodeCallback(this);
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_CheckNodeCallback(this);
		p_Capabilities=null;
	}
	public XplInfoLayerZoeOutputModuleConfig(XplNodeList n_SupportedPlatform, XplNodeList n_PlatformAlias, XplOutputModuleCapabilities n_Capabilities){
		p_name = "";
		p_especifiedClass = "";
		p_defaultPlatform = "";
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_CheckNodeCallback(this);
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_CheckNodeCallback(this);
		p_Capabilities=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SupportedPlatform!=null)
		for(XplNode node = n_SupportedPlatform.FirstNode(); node != null ; node = n_SupportedPlatform.NextNode()){
			p_SupportedPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_PlatformAlias!=null)
		for(XplNode node = n_PlatformAlias.FirstNode(); node != null ; node = n_PlatformAlias.NextNode()){
			p_PlatformAlias.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
		set_Capabilities(n_Capabilities);
	}
	public XplInfoLayerZoeOutputModuleConfig(String n_name, String n_especifiedClass, String n_defaultPlatform, XplNodeList n_SupportedPlatform, XplOutputModuleCapabilities n_Capabilities){
		set_name(n_name);
		set_especifiedClass(n_especifiedClass);
		set_defaultPlatform(n_defaultPlatform);
		set_name(n_name);
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_CheckNodeCallback(this);
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_CheckNodeCallback(this);
		p_Capabilities=null;
	}
	public XplInfoLayerZoeOutputModuleConfig(String n_name, XplNodeList n_SupportedPlatform, XplNodeList n_PlatformAlias, XplOutputModuleCapabilities n_Capabilities){
		p_name = "";
		p_especifiedClass = "";
		p_defaultPlatform = "";
		set_name(n_name);
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_CheckNodeCallback(this);
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_CheckNodeCallback(this);
		p_Capabilities=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SupportedPlatform!=null)
		for(XplNode node = n_SupportedPlatform.FirstNode(); node != null ; node = n_SupportedPlatform.NextNode()){
			p_SupportedPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_PlatformAlias!=null)
		for(XplNode node = n_PlatformAlias.FirstNode(); node != null ; node = n_PlatformAlias.NextNode()){
			p_PlatformAlias.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
		set_Capabilities(n_Capabilities);
	}
	public XplInfoLayerZoeOutputModuleConfig(String n_name, String n_especifiedClass, String n_defaultPlatform, XplNodeList n_SupportedPlatform, XplNodeList n_PlatformAlias, XplOutputModuleCapabilities n_Capabilities){
		set_name(n_name);
		set_especifiedClass(n_especifiedClass);
		set_defaultPlatform(n_defaultPlatform);
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_CheckNodeCallback(this);
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_CheckNodeCallback(this);
		p_Capabilities=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SupportedPlatform!=null)
		for(XplNode node = n_SupportedPlatform.FirstNode(); node != null ; node = n_SupportedPlatform.NextNode()){
			p_SupportedPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_PlatformAlias!=null)
		for(XplNode node = n_PlatformAlias.FirstNode(); node != null ; node = n_PlatformAlias.NextNode()){
			p_PlatformAlias.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
		set_Capabilities(n_Capabilities);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplInfoLayerZoeOutputModuleConfig copy = new XplInfoLayerZoeOutputModuleConfig();
		copy.set_name(this.p_name);
		copy.set_especifiedClass(this.p_especifiedClass);
		copy.set_defaultPlatform(this.p_defaultPlatform);
		for(XplNode node = p_SupportedPlatform.FirstNode(); node != null ; node = p_SupportedPlatform.NextNode()){
			copy.get_SupportedPlatform().InsertAtEnd(node.Clone());
		}
		for(XplNode node = p_PlatformAlias.FirstNode(); node != null ; node = p_PlatformAlias.NextNode()){
			copy.get_PlatformAlias().InsertAtEnd(node.Clone());
		}
		if(p_Capabilities!=null)copy.set_Capabilities((XplOutputModuleCapabilities)p_Capabilities.Clone());
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplInfoLayerZoeOutputModuleConfig;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,CodeDOM_Utils.Att_ToString(p_name) );
		if(p_especifiedClass != "")
			writer.WriteAttributeString( "especifiedClass" ,CodeDOM_Utils.Att_ToString(p_especifiedClass) );
		if(p_defaultPlatform != "")
			writer.WriteAttributeString( "defaultPlatform" ,CodeDOM_Utils.Att_ToString(p_defaultPlatform) );
		//Escribo recursivamente cada elemento hijo
		if(p_SupportedPlatform!=null)if(!p_SupportedPlatform.Write(writer))result=false;
		if(p_PlatformAlias!=null)if(!p_PlatformAlias.Write(writer))result=false;
		if(p_Capabilities!=null)if(!p_Capabilities.Write(writer))result=false;
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
				else if(reader.Name().equals("especifiedClass")){
					this.set_especifiedClass(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("defaultPlatform")){
					this.set_defaultPlatform(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else{
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Atributo '"+reader.Name()+"' invalido en elemento '"+this.get_Name()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		//Borro todo posible nodo en memoria
		this.p_Capabilities=null;
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("SupportedPlatform")){
						tempNode = new XplTargetPlatform();
						tempNode.Read(reader);
						this.get_SupportedPlatform().InsertAtEnd(tempNode);
					}
					else if(reader.Name().equals("PlatformAlias")){
						tempNode = new XplPlatformAlias();
						tempNode.Read(reader);
						this.get_PlatformAlias().InsertAtEnd(tempNode);
					}
					else if(reader.Name().equals("Capabilities")){
						tempNode = new XplOutputModuleCapabilities();
						tempNode.Read(reader);
						if(this.get_Capabilities()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_Capabilities((XplOutputModuleCapabilities)tempNode);
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
	public String get_name(){
		return p_name;
	}
	public String get_especifiedClass(){
		return p_especifiedClass;
	}
	public String get_defaultPlatform(){
		return p_defaultPlatform;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplNodeList get_SupportedPlatform(){
		return p_SupportedPlatform;
	}
	public XplNodeList get_PlatformAlias(){
		return p_PlatformAlias;
	}
	public XplOutputModuleCapabilities get_Capabilities(){
		return p_Capabilities;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_name(String new_name){
		String back_name = p_name;
		p_name = new_name;
		return back_name;
	}
	public String set_especifiedClass(String new_especifiedClass){
		String back_especifiedClass = p_especifiedClass;
		p_especifiedClass = new_especifiedClass;
		return back_especifiedClass;
	}
	public String set_defaultPlatform(String new_defaultPlatform){
		String back_defaultPlatform = p_defaultPlatform;
		p_defaultPlatform = new_defaultPlatform;
		return back_defaultPlatform;
	}

	//Funciones para setear Elementos de Secuencia
	public boolean InsertCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		if(nodeList==p_SupportedPlatform)return acceptInsertNodeCallback_SupportedPlatform(node, parent);
		if(nodeList==p_PlatformAlias)return acceptInsertNodeCallback_PlatformAlias(node, parent);
		return false;
	}
	public boolean RemoveNodeCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		return true;
	}
	public boolean acceptInsertNodeCallback_SupportedPlatform(XplNode node, XplNode parent){
		if(node==null)return false;
		if(node.get_Name().equals("SupportedPlatform")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplTargetPlatform){
			this.set_ErrorString("El elemento de tipo '"+node.get_ContentTypeName()+"' no es valido como componente de 'XplTargetPlatform'.");
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		this.set_ErrorString("El elemento de nombre '"+node.get_Name()+"' no es valido como componente de 'XplTargetPlatform'.");
		return false;
	}
	public boolean acceptInsertNodeCallback_PlatformAlias(XplNode node, XplNode parent){
		if(node==null)return false;
		if(node.get_Name().equals("PlatformAlias")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplPlatformAlias){
			this.set_ErrorString("El elemento de tipo '"+node.get_ContentTypeName()+"' no es valido como componente de 'XplPlatformAlias'.");
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		this.set_ErrorString("El elemento de nombre '"+node.get_Name()+"' no es valido como componente de 'XplPlatformAlias'.");
		return false;
	}
	public XplOutputModuleCapabilities set_Capabilities(XplOutputModuleCapabilities new_Capabilities){
		XplOutputModuleCapabilities back_Capabilities = p_Capabilities;
		p_Capabilities = new_Capabilities;
		if(p_Capabilities!=null){
			p_Capabilities.set_Name("Capabilities");
			p_Capabilities.set_Parent(this);
		}
		return back_Capabilities;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplTargetPlatform new_SupportedPlatform(){
		XplTargetPlatform node = new XplTargetPlatform();
		node.set_Name("SupportedPlatform");
		return node;
	}
	public static final XplPlatformAlias new_PlatformAlias(){
		XplPlatformAlias node = new XplPlatformAlias();
		node.set_Name("PlatformAlias");
		return node;
	}
	public static final XplOutputModuleCapabilities new_Capabilities(){
		XplOutputModuleCapabilities node = new XplOutputModuleCapabilities();
		node.set_Name("Capabilities");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

