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
public class XplInfoLayerZoeOutputModuleConfig:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_name;
	string p_especifiedClass;
	string p_defaultPlatform;
	//Variables para Elementos de Secuencia
	XplNodeList p_SupportedPlatform;
	XplNodeList p_PlatformAlias;
	XplOutputModuleCapabilities p_Capabilities;
	#endregion

	#region Region de Constructores Publicos
	public XplInfoLayerZoeOutputModuleConfig(){
		p_name = "";
		p_especifiedClass = "";
		p_defaultPlatform = "";
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SupportedPlatform));
		p_SupportedPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SupportedPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_Capabilities=null;
}
	public XplInfoLayerZoeOutputModuleConfig(string n_name){
		p_name = "";
		p_especifiedClass = "";
		p_defaultPlatform = "";
		set_name(n_name);
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SupportedPlatform));
		p_SupportedPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SupportedPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_Capabilities=null;
	}
	public XplInfoLayerZoeOutputModuleConfig(XplNodeList n_SupportedPlatform, XplOutputModuleCapabilities n_Capabilities){
		p_name = "";
		p_especifiedClass = "";
		p_defaultPlatform = "";
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SupportedPlatform));
		p_SupportedPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SupportedPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_Capabilities=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SupportedPlatform!=null)
		for(XplNode node = n_SupportedPlatform.FirstNode(); node != null ; node = n_SupportedPlatform.NextNode()){
			p_SupportedPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		set_Capabilities(n_Capabilities);
	}
	public XplInfoLayerZoeOutputModuleConfig(string n_name, XplNodeList n_SupportedPlatform, XplOutputModuleCapabilities n_Capabilities){
		p_name = "";
		p_especifiedClass = "";
		p_defaultPlatform = "";
		set_name(n_name);
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SupportedPlatform));
		p_SupportedPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SupportedPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_Capabilities=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SupportedPlatform!=null)
		for(XplNode node = n_SupportedPlatform.FirstNode(); node != null ; node = n_SupportedPlatform.NextNode()){
			p_SupportedPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		set_Capabilities(n_Capabilities);
	}
	public XplInfoLayerZoeOutputModuleConfig(string n_name, string n_especifiedClass, string n_defaultPlatform){
		set_name(n_name);
		set_especifiedClass(n_especifiedClass);
		set_defaultPlatform(n_defaultPlatform);
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SupportedPlatform));
		p_SupportedPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SupportedPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_Capabilities=null;
	}
	public XplInfoLayerZoeOutputModuleConfig(XplNodeList n_SupportedPlatform, XplNodeList n_PlatformAlias, XplOutputModuleCapabilities n_Capabilities){
		p_name = "";
		p_especifiedClass = "";
		p_defaultPlatform = "";
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SupportedPlatform));
		p_SupportedPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SupportedPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_Capabilities=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SupportedPlatform!=null)
		for(XplNode node = n_SupportedPlatform.FirstNode(); node != null ; node = n_SupportedPlatform.NextNode()){
			p_SupportedPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_PlatformAlias!=null)
		for(XplNode node = n_PlatformAlias.FirstNode(); node != null ; node = n_PlatformAlias.NextNode()){
			p_PlatformAlias.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		set_Capabilities(n_Capabilities);
	}
	public XplInfoLayerZoeOutputModuleConfig(string n_name, string n_especifiedClass, string n_defaultPlatform, XplNodeList n_SupportedPlatform, XplOutputModuleCapabilities n_Capabilities){
		set_name(n_name);
		set_especifiedClass(n_especifiedClass);
		set_defaultPlatform(n_defaultPlatform);
		set_name(n_name);
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SupportedPlatform));
		p_SupportedPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SupportedPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_Capabilities=null;
	}
	public XplInfoLayerZoeOutputModuleConfig(string n_name, XplNodeList n_SupportedPlatform, XplNodeList n_PlatformAlias, XplOutputModuleCapabilities n_Capabilities){
		p_name = "";
		p_especifiedClass = "";
		p_defaultPlatform = "";
		set_name(n_name);
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SupportedPlatform));
		p_SupportedPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SupportedPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_Capabilities=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SupportedPlatform!=null)
		for(XplNode node = n_SupportedPlatform.FirstNode(); node != null ; node = n_SupportedPlatform.NextNode()){
			p_SupportedPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_PlatformAlias!=null)
		for(XplNode node = n_PlatformAlias.FirstNode(); node != null ; node = n_PlatformAlias.NextNode()){
			p_PlatformAlias.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		set_Capabilities(n_Capabilities);
	}
	public XplInfoLayerZoeOutputModuleConfig(string n_name, string n_especifiedClass, string n_defaultPlatform, XplNodeList n_SupportedPlatform, XplNodeList n_PlatformAlias, XplOutputModuleCapabilities n_Capabilities){
		set_name(n_name);
		set_especifiedClass(n_especifiedClass);
		set_defaultPlatform(n_defaultPlatform);
		p_SupportedPlatform = new XplNodeList();
		p_SupportedPlatform.set_Parent(this);
		p_SupportedPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SupportedPlatform));
		p_SupportedPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SupportedPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_Capabilities=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SupportedPlatform!=null)
		for(XplNode node = n_SupportedPlatform.FirstNode(); node != null ; node = n_SupportedPlatform.NextNode()){
			p_SupportedPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_PlatformAlias!=null)
		for(XplNode node = n_PlatformAlias.FirstNode(); node != null ; node = n_PlatformAlias.NextNode()){
			p_PlatformAlias.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		set_Capabilities(n_Capabilities);
	}
	#endregion

	#region Destructor
/*	public ~XplInfoLayerZoeOutputModuleConfig(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
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
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplInfoLayerZoeOutputModuleConfig;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,ZoeHelper .Att_ToString(p_name) );
		if(p_especifiedClass != "")
			writer.WriteAttributeString( "especifiedClass" ,ZoeHelper .Att_ToString(p_especifiedClass) );
		if(p_defaultPlatform != "")
			writer.WriteAttributeString( "defaultPlatform" ,ZoeHelper .Att_ToString(p_defaultPlatform) );
		//Escribo recursivamente cada elemento hijo
		if(p_SupportedPlatform!=null)if(!p_SupportedPlatform.Write(writer))result=false;
		if(p_PlatformAlias!=null)if(!p_PlatformAlias.Write(writer))result=false;
		if(p_Capabilities!=null)if(!p_Capabilities.Write(writer))result=false;
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
					case "name":
						this.set_name(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "especifiedClass":
						this.set_especifiedClass(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "defaultPlatform":
						this.set_defaultPlatform(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Atributo '"+reader.Name+"' invalido en elemento '"+this.get_ElementName()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		//Borro todo posible nodo en memoria
		this.p_Capabilities=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "SupportedPlatform":
						tempNode = new XplTargetPlatform();
						tempNode.Read(reader);
						this.get_SupportedPlatform().InsertAtEnd(tempNode);
						break;
					case "PlatformAlias":
						tempNode = new XplPlatformAlias();
						tempNode.Read(reader);
						this.get_PlatformAlias().InsertAtEnd(tempNode);
						break;
					case "Capabilities":
						tempNode = new XplOutputModuleCapabilities();
						tempNode.Read(reader);
						if(this.get_Capabilities()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_Capabilities((XplOutputModuleCapabilities)tempNode);
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
		writer.Write((int) 168 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_name );
		writer.Write( p_especifiedClass );
		writer.Write( p_defaultPlatform );
		//Escribo recursivamente cada elemento hijo
		if(p_SupportedPlatform!=null){
			writer.Write((int)1);
			if(!p_SupportedPlatform.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_PlatformAlias!=null){
			writer.Write((int)1);
			if(!p_PlatformAlias.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_Capabilities!=null){
			writer.Write((int)1);
			if(!p_Capabilities.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_name = reader.ReadString();
		p_especifiedClass = reader.ReadString();
		p_defaultPlatform = reader.ReadString();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_SupportedPlatform.BinaryRead(reader);
		}
		if(reader.ReadInt32()==1){
			p_PlatformAlias.BinaryRead(reader);
		}
		if(reader.ReadInt32()==1){
			p_Capabilities = (XplOutputModuleCapabilities)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplInfoLayerZoeOutputModuleConfig operator +(XplInfoLayerZoeOutputModuleConfig arg1, XplNode arg2)
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
public static XplInfoLayerZoeOutputModuleConfig operator +(XplInfoLayerZoeOutputModuleConfig arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_name(){
		return p_name;
	}
	public string get_especifiedClass(){
		return p_especifiedClass;
	}
	public string get_defaultPlatform(){
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
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[3];
		ret[0] = "name";
		ret[1] = "especifiedClass";
		ret[2] = "defaultPlatform";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="name") return p_name.ToString();
		if (attributeName=="especifiedClass") return p_especifiedClass.ToString();
		if (attributeName=="defaultPlatform") return p_defaultPlatform.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		for(XplNode node=p_SupportedPlatform.FirstNode();node!=null;node=p_SupportedPlatform.NextNode())
			list.InsertAtEnd(node);
		for(XplNode node=p_PlatformAlias.FirstNode();node!=null;node=p_PlatformAlias.NextNode())
			list.InsertAtEnd(node);
		list.InsertAtEnd(p_Capabilities);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_name(string new_name){
		string back_name = p_name;
		p_name = new_name;
		return back_name;
	}
	public string set_especifiedClass(string new_especifiedClass){
		string back_especifiedClass = p_especifiedClass;
		p_especifiedClass = new_especifiedClass;
		return back_especifiedClass;
	}
	public string set_defaultPlatform(string new_defaultPlatform){
		string back_defaultPlatform = p_defaultPlatform;
		p_defaultPlatform = new_defaultPlatform;
		return back_defaultPlatform;
	}

	//Funciones para setear Elementos de Secuencia
	protected bool acceptInsertNodeCallback_SupportedPlatform(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="SupportedPlatform"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplTargetPlatform){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplTargetPlatform'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplTargetPlatform'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_SupportedPlatform(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	protected bool acceptInsertNodeCallback_PlatformAlias(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="PlatformAlias"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplPlatformAlias){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplPlatformAlias'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplPlatformAlias'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_PlatformAlias(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	public XplOutputModuleCapabilities set_Capabilities(XplOutputModuleCapabilities new_Capabilities){
		XplOutputModuleCapabilities back_Capabilities = p_Capabilities;
		p_Capabilities = new_Capabilities;
		if(p_Capabilities!=null){
			p_Capabilities.set_ElementName("Capabilities");
			p_Capabilities.set_Parent(this);
		}
		return back_Capabilities;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplTargetPlatform new_SupportedPlatform(){
		XplTargetPlatform node = new XplTargetPlatform();
		node.set_ElementName("SupportedPlatform");
		return node;
	}
	static public XplPlatformAlias new_PlatformAlias(){
		XplPlatformAlias node = new XplPlatformAlias();
		node.set_ElementName("PlatformAlias");
		return node;
	}
	static public XplOutputModuleCapabilities new_Capabilities(){
		XplOutputModuleCapabilities node = new XplOutputModuleCapabilities();
		node.set_ElementName("Capabilities");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

