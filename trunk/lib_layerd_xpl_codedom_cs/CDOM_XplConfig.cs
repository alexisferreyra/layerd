/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 8/11/2011 4:27:20 PM
 *
 *	Generado por Zoe CodeDOM Generator para C#.
 *	COPYRIGHT 2002,2005-2006. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

using System;
using System.Xml;
using System.IO;

namespace LayerD.CodeDOM{

[Serializable]
public class XplConfig:  XplNode{

	#region Variables privadas para atributos y elementos

	//Variables para Elementos de Choice
	XplNode p_choiceContent;
	#endregion

	#region Region de Constructores Publicos
	public XplConfig(){
		p_choiceContent=null;
}
	public XplConfig(XplNode n_choiceContent){
		p_choiceContent=null;
		set_Content(n_choiceContent);
	}
	#endregion

	#region Destructor
/*	public ~XplConfig(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplConfig copy = new XplConfig();

		//Variables para Elementos de Choice
		if(p_choiceContent!=null)copy.set_Content(p_choiceContent.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplConfig;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		//Escribo recursivamente cada elemento hijo
		if(p_choiceContent!=null)if(!p_choiceContent.Write(writer))result=false;
		//Cierro el elemento
		writer.WriteEndElement();
		return result;
	}

	public override XplNode Read(XplReader reader){
		this.set_ElementName( reader.Name );
		//Lectura de Atributos
		if( reader.HasAttributes ){
			for(int i=0; i < reader.AttributeCount ; i++){
				reader.MoveToAttribute(i);
				switch(reader.Name){
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Atributo '"+reader.Name+"' invalido en elemento '"+this.get_ElementName()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		this.p_choiceContent=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "LayerD_Zoe_Document_Config":
						tempNode = new XplLayerDZoeDocumentConfig();
						tempNode.Read(reader);
						break;
					case "Extended_LayerD_Zoe_Document_Config":
						tempNode = new XplExtendedLayerDZoeDocumentConfig();
						tempNode.Read(reader);
						break;
					case "LayerD_Zoe_Program_Config":
						tempNode = new XplLayerDZoeProgramConfig();
						tempNode.Read(reader);
						break;
					case "Import_Process_Config":
						tempNode = new XplImportProcessConfig();
						tempNode.Read(reader);
						break;
					case "Info_LayerD_Zoe_Output_Module":
						tempNode = new XplInfoLayerZoeOutputModuleConfig();
						tempNode.Read(reader);
						break;
					case "Requirements_Extended_LayerD_Zoe":
						tempNode = new XplExtendedLayerDZoeRequirementsConfig();
						tempNode.Read(reader);
						break;
					case "LayerD_Error_Interchange_Config":
						tempNode = new XplLayerDErrorInterchangeConfig();
						tempNode.Read(reader);
						break;
					case "LayerD_Zoe_Virutal_Subprogram_Config":
						tempNode = new XplLayerDZoeDocumentConfig();
						tempNode.Read(reader);
						break;
					case "LayerD_Zoe_Parameter_Document_Config":
						tempNode = new XplLayerDZoeDocumentConfig();
						tempNode.Read(reader);
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nombre de nodo '"+reader.Name+"' inesperado como hijo de elemento '"+this.get_ElementName()+"'.");
					}
					break;
				case XmlNodeType.EndElement:
					break;
				case XmlNodeType.Text:
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".No se esperaba texto en este nodo.");
				default:
					break;
			}
			if(this.get_Content()!=null && tempNode!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' incorrecto como hijo de elemento '"+this.get_ElementName()+"'.");
			else if(tempNode!=null)this.set_Content(tempNode);
			reader.Read();
		}
		}
		return this;
	}
	public override bool BinaryWrite(XplBinaryWriter writer){
		bool result=true;
		//Escribo el ID y el nombre del elemento
		writer.Write((int) 127 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		//Escribo recursivamente cada elemento hijo
		if(p_choiceContent!=null){
			writer.Write((int)1);
			if(!p_choiceContent.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_choiceContent = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplConfig operator +(XplConfig arg1, XplNode arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
/// <summary>
/// Adds arg2 nodes to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Nodes to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplConfig operator +(XplConfig arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos

	//Funciones para obtener Elementos de Choice
	public override XplNode get_Content(){
		return p_choiceContent;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[0];
		return ret;
	}
	public override string AttributeValue(string attributeName){
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		list.InsertAtEnd(p_choiceContent);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos

//Funciones para setear Elementos de Choice
	public override XplNode set_Content(XplNode new_tConfig){
		if(new_tConfig==null)return p_choiceContent;
		XplNode back_tConfig = p_choiceContent;
		if(new_tConfig.get_ElementName()=="LayerD_Zoe_Document_Config"){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplLayerDZoeDocumentConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_choiceContent = new_tConfig;
			p_choiceContent.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_ElementName()=="Extended_LayerD_Zoe_Document_Config"){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplExtendedLayerDZoeDocumentConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_choiceContent = new_tConfig;
			p_choiceContent.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_ElementName()=="LayerD_Zoe_Program_Config"){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplLayerDZoeProgramConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_choiceContent = new_tConfig;
			p_choiceContent.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_ElementName()=="Import_Process_Config"){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplImportProcessConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_choiceContent = new_tConfig;
			p_choiceContent.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_ElementName()=="Info_LayerD_Zoe_Output_Module"){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplInfoLayerZoeOutputModuleConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_choiceContent = new_tConfig;
			p_choiceContent.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_ElementName()=="Requirements_Extended_LayerD_Zoe"){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplExtendedLayerDZoeRequirementsConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_choiceContent = new_tConfig;
			p_choiceContent.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_ElementName()=="LayerD_Error_Interchange_Config"){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplLayerDErrorInterchangeConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_choiceContent = new_tConfig;
			p_choiceContent.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_ElementName()=="LayerD_Zoe_Virutal_Subprogram_Config"){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplLayerDZoeDocumentConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_choiceContent = new_tConfig;
			p_choiceContent.set_Parent(this);
			return back_tConfig;
		}
		if(new_tConfig.get_ElementName()=="LayerD_Zoe_Parameter_Document_Config"){
			if(new_tConfig.get_ContentTypeName()!=CodeDOMTypes.XplLayerDZoeDocumentConfig){
				this.set_ErrorString("El elemento de tipo '"+new_tConfig.get_ContentTypeName()+"' no es valido como componente de 'tConfig'.");
				return null;
			}
			p_choiceContent = new_tConfig;
			p_choiceContent.set_Parent(this);
			return back_tConfig;
		}
		this.set_ErrorString("El elemento de nombre '"+new_tConfig.get_ElementName()+"' no es valido como componente de 'tConfig'.");
		return null;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplLayerDZoeDocumentConfig new_LayerD_Zoe_Document_Config(){
		XplLayerDZoeDocumentConfig node = new XplLayerDZoeDocumentConfig();
		node.set_ElementName("LayerD_Zoe_Document_Config");
		return node;
	}
	static public XplExtendedLayerDZoeDocumentConfig new_Extended_LayerD_Zoe_Document_Config(){
		XplExtendedLayerDZoeDocumentConfig node = new XplExtendedLayerDZoeDocumentConfig();
		node.set_ElementName("Extended_LayerD_Zoe_Document_Config");
		return node;
	}
	static public XplLayerDZoeProgramConfig new_LayerD_Zoe_Program_Config(){
		XplLayerDZoeProgramConfig node = new XplLayerDZoeProgramConfig();
		node.set_ElementName("LayerD_Zoe_Program_Config");
		return node;
	}
	static public XplImportProcessConfig new_Import_Process_Config(){
		XplImportProcessConfig node = new XplImportProcessConfig();
		node.set_ElementName("Import_Process_Config");
		return node;
	}
	static public XplInfoLayerZoeOutputModuleConfig new_Info_LayerD_Zoe_Output_Module(){
		XplInfoLayerZoeOutputModuleConfig node = new XplInfoLayerZoeOutputModuleConfig();
		node.set_ElementName("Info_LayerD_Zoe_Output_Module");
		return node;
	}
	static public XplExtendedLayerDZoeRequirementsConfig new_Requirements_Extended_LayerD_Zoe(){
		XplExtendedLayerDZoeRequirementsConfig node = new XplExtendedLayerDZoeRequirementsConfig();
		node.set_ElementName("Requirements_Extended_LayerD_Zoe");
		return node;
	}
	static public XplLayerDErrorInterchangeConfig new_LayerD_Error_Interchange_Config(){
		XplLayerDErrorInterchangeConfig node = new XplLayerDErrorInterchangeConfig();
		node.set_ElementName("LayerD_Error_Interchange_Config");
		return node;
	}
	static public XplLayerDZoeDocumentConfig new_LayerD_Zoe_Virutal_Subprogram_Config(){
		XplLayerDZoeDocumentConfig node = new XplLayerDZoeDocumentConfig();
		node.set_ElementName("LayerD_Zoe_Virutal_Subprogram_Config");
		return node;
	}
	static public XplLayerDZoeDocumentConfig new_LayerD_Zoe_Parameter_Document_Config(){
		XplLayerDZoeDocumentConfig node = new XplLayerDZoeDocumentConfig();
		node.set_ElementName("LayerD_Zoe_Parameter_Document_Config");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

