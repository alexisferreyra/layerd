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

public class XplConfig extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">

	//Variables para Elementos de Choice
	XplNode p_tConfig;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplConfig(){
		p_tConfig=null;
	}
	public XplConfig(XplNode n_tConfig){
		p_tConfig=null;
		set_tConfig(n_tConfig);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplConfig copy = new XplConfig();

		//Variables para Elementos de Choice
		if(p_tConfig!=null)copy.set_tConfig(p_tConfig.Clone());
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplConfig;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		//Escribo recursivamente cada elemento hijo
		if(p_tConfig!=null)if(!p_tConfig.Write(writer))result=false;
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
		this.p_tConfig=null;
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("LayerD_Zoe_Document_Config")){
						tempNode = new XplLayerDZoeDocumentConfig();
						tempNode.Read(reader);
					}
					else if(reader.Name().equals("Extended_LayerD_Zoe_Document_Config")){
						tempNode = new XplExtendedLayerDZoeDocumentConfig();
						tempNode.Read(reader);
					}
					else if(reader.Name().equals("LayerD_Zoe_Program_Config")){
						tempNode = new XplLayerDZoeProgramConfig();
						tempNode.Read(reader);
					}
					else if(reader.Name().equals("Import_Process_Config")){
						tempNode = new XplImportProcessConfig();
						tempNode.Read(reader);
					}
					else if(reader.Name().equals("Info_LayerD_Zoe_Output_Module")){
						tempNode = new XplInfoLayerZoeOutputModuleConfig();
						tempNode.Read(reader);
					}
					else if(reader.Name().equals("Requirements_Extended_LayerD_Zoe")){
						tempNode = new XplExtendedLayerDZoeRequirementsConfig();
						tempNode.Read(reader);
					}
					else if(reader.Name().equals("LayerD_Error_Interchange_Config")){
						tempNode = new XplLayerDErrorInterchangeConfig();
						tempNode.Read(reader);
					}
					else if(reader.Name().equals("LayerD_Zoe_Virutal_Subprogram_Config")){
						tempNode = new XplLayerDZoeDocumentConfig();
						tempNode.Read(reader);
					}
					else if(reader.Name().equals("LayerD_Zoe_Parameter_Document_Config")){
						tempNode = new XplLayerDZoeDocumentConfig();
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
			if(this.get_tConfig()!=null && tempNode!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' incorrecto como hijo de elemento '"+this.get_Name()+"'.");
			else if(tempNode!=null)this.set_tConfig(tempNode);
			reader.Read();
		}
		}
		return this;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para obtener Atributos y Elementos ">

	//Funciones para obtener Elementos de Choice
	public XplNode get_tConfig(){
		return p_tConfig;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">

//Funciones para setear Elementos de Choice
	public XplNode set_tConfig(XplNode new_tConfig){
		if(new_tConfig==null)return p_tConfig;
		XplNode back_tConfig = p_tConfig;
		if(new_tConfig.get_Name().equals("LayerD_Zoe_Document_Config")){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplLayerDZoeDocumentConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_tConfig = new_tConfig;
			p_tConfig.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_Name().equals("Extended_LayerD_Zoe_Document_Config")){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplExtendedLayerDZoeDocumentConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_tConfig = new_tConfig;
			p_tConfig.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_Name().equals("LayerD_Zoe_Program_Config")){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplLayerDZoeProgramConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_tConfig = new_tConfig;
			p_tConfig.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_Name().equals("Import_Process_Config")){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplImportProcessConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_tConfig = new_tConfig;
			p_tConfig.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_Name().equals("Info_LayerD_Zoe_Output_Module")){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplInfoLayerZoeOutputModuleConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_tConfig = new_tConfig;
			p_tConfig.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_Name().equals("Requirements_Extended_LayerD_Zoe")){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplExtendedLayerDZoeRequirementsConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_tConfig = new_tConfig;
			p_tConfig.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_Name().equals("LayerD_Error_Interchange_Config")){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplLayerDErrorInterchangeConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_tConfig = new_tConfig;
			p_tConfig.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_Name().equals("LayerD_Zoe_Virutal_Subprogram_Config")){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplLayerDZoeDocumentConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_tConfig = new_tConfig;
			p_tConfig.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_Name().equals("LayerD_Zoe_Parameter_Document_Config")){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplLayerDZoeDocumentConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_tConfig = new_tConfig;
			p_tConfig.set_Parent(this);
			return back_tConfig;
		}
		this.set_ErrorString("El elemento de nombre '"+new_tConfig.get_Name()+"' no es valido como componente de 'tConfig'.");
		return null;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplLayerDZoeDocumentConfig new_LayerD_Zoe_Document_Config(){
		XplLayerDZoeDocumentConfig node = new XplLayerDZoeDocumentConfig();
		node.set_Name("LayerD_Zoe_Document_Config");
		return node;
	}
	public static final XplExtendedLayerDZoeDocumentConfig new_Extended_LayerD_Zoe_Document_Config(){
		XplExtendedLayerDZoeDocumentConfig node = new XplExtendedLayerDZoeDocumentConfig();
		node.set_Name("Extended_LayerD_Zoe_Document_Config");
		return node;
	}
	public static final XplLayerDZoeProgramConfig new_LayerD_Zoe_Program_Config(){
		XplLayerDZoeProgramConfig node = new XplLayerDZoeProgramConfig();
		node.set_Name("LayerD_Zoe_Program_Config");
		return node;
	}
	public static final XplImportProcessConfig new_Import_Process_Config(){
		XplImportProcessConfig node = new XplImportProcessConfig();
		node.set_Name("Import_Process_Config");
		return node;
	}
	public static final XplInfoLayerZoeOutputModuleConfig new_Info_LayerD_Zoe_Output_Module(){
		XplInfoLayerZoeOutputModuleConfig node = new XplInfoLayerZoeOutputModuleConfig();
		node.set_Name("Info_LayerD_Zoe_Output_Module");
		return node;
	}
	public static final XplExtendedLayerDZoeRequirementsConfig new_Requirements_Extended_LayerD_Zoe(){
		XplExtendedLayerDZoeRequirementsConfig node = new XplExtendedLayerDZoeRequirementsConfig();
		node.set_Name("Requirements_Extended_LayerD_Zoe");
		return node;
	}
	public static final XplLayerDErrorInterchangeConfig new_LayerD_Error_Interchange_Config(){
		XplLayerDErrorInterchangeConfig node = new XplLayerDErrorInterchangeConfig();
		node.set_Name("LayerD_Error_Interchange_Config");
		return node;
	}
	public static final XplLayerDZoeDocumentConfig new_LayerD_Zoe_Virutal_Subprogram_Config(){
		XplLayerDZoeDocumentConfig node = new XplLayerDZoeDocumentConfig();
		node.set_Name("LayerD_Zoe_Virutal_Subprogram_Config");
		return node;
	}
	public static final XplLayerDZoeDocumentConfig new_LayerD_Zoe_Parameter_Document_Config(){
		XplLayerDZoeDocumentConfig node = new XplLayerDZoeDocumentConfig();
		node.set_Name("LayerD_Zoe_Parameter_Document_Config");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

