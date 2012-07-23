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
public class XplLayerDErrorInterchangeConfig:  XplNode{

	#region Variables privadas para atributos y elementos
	//Variables para Elementos de Secuencia
	XplNodeList p_Warning;
	XplNodeList p_Error;
	#endregion

	#region Region de Constructores Publicos
	public XplLayerDErrorInterchangeConfig(){
		p_Warning = new XplNodeList();
		p_Warning.set_Parent(this);
		p_Warning.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_Warning));
		p_Warning.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_Warning));
		p_Error = new XplNodeList();
		p_Error.set_Parent(this);
		p_Error.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_Error));
		p_Error.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_Error));
}
	public XplLayerDErrorInterchangeConfig(XplNodeList n_Warning, XplNodeList n_Error){
		p_Warning = new XplNodeList();
		p_Warning.set_Parent(this);
		p_Warning.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_Warning));
		p_Warning.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_Warning));
		p_Error = new XplNodeList();
		p_Error.set_Parent(this);
		p_Error.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_Error));
		p_Error.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_Error));
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Warning!=null)
		for(XplNode node = n_Warning.FirstNode(); node != null ; node = n_Warning.NextNode()){
			p_Warning.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Error!=null)
		for(XplNode node = n_Error.FirstNode(); node != null ; node = n_Error.NextNode()){
			p_Error.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	#endregion

	#region Destructor
/*	public ~XplLayerDErrorInterchangeConfig(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplLayerDErrorInterchangeConfig copy = new XplLayerDErrorInterchangeConfig();
		for(XplNode node = p_Warning.FirstNode(); node != null ; node = p_Warning.NextNode()){
			copy.get_Warning().InsertAtEnd(node.Clone());
		}
		for(XplNode node = p_Error.FirstNode(); node != null ; node = p_Error.NextNode()){
			copy.get_Error().InsertAtEnd(node.Clone());
		}
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplLayerDErrorInterchangeConfig;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		//Escribo recursivamente cada elemento hijo
		if(p_Warning!=null)if(!p_Warning.Write(writer))result=false;
		if(p_Error!=null)if(!p_Error.Write(writer))result=false;
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
		//Borro todo posible nodo en memoria
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "Warning":
						tempNode = new XplError();
						tempNode.Read(reader);
						this.get_Warning().InsertAtEnd(tempNode);
						break;
					case "Error":
						tempNode = new XplError();
						tempNode.Read(reader);
						this.get_Error().InsertAtEnd(tempNode);
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
			reader.Read();
		}
		}
		return this;
	}
	public override bool BinaryWrite(XplBinaryWriter writer){
		bool result=true;
		//Escribo el ID y el nombre del elemento
		writer.Write((int) 134 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		//Escribo recursivamente cada elemento hijo
		if(p_Warning!=null){
			writer.Write((int)1);
			if(!p_Warning.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_Error!=null){
			writer.Write((int)1);
			if(!p_Error.BinaryWrite(writer))result=false;
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
			p_Warning.BinaryRead(reader);
		}
		if(reader.ReadInt32()==1){
			p_Error.BinaryRead(reader);
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplLayerDErrorInterchangeConfig operator +(XplLayerDErrorInterchangeConfig arg1, XplNode arg2)
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
public static XplLayerDErrorInterchangeConfig operator +(XplLayerDErrorInterchangeConfig arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	//Funciones para obtener Elementos de Secuencia
	public XplNodeList get_Warning(){
		return p_Warning;
	}
	public XplNodeList get_Error(){
		return p_Error;
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
		for(XplNode node=p_Warning.FirstNode();node!=null;node=p_Warning.NextNode())
			list.InsertAtEnd(node);
		for(XplNode node=p_Error.FirstNode();node!=null;node=p_Error.NextNode())
			list.InsertAtEnd(node);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos

	//Funciones para setear Elementos de Secuencia
	protected bool acceptInsertNodeCallback_Warning(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="Warning"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplError){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplError'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplError'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_Warning(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	protected bool acceptInsertNodeCallback_Error(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="Error"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplError){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplError'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplError'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_Error(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplError new_Warning(){
		XplError node = new XplError();
		node.set_ElementName("Warning");
		return node;
	}
	static public XplError new_Error(){
		XplError node = new XplError();
		node.set_ElementName("Error");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

