/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 3/2/2010 9:11:42 PM
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
public class XplClassMembersList:  XplNode{

	#region Variables privadas para atributos y elementos
	//Variables para Elementos de Secuencia
	XplNodeList p_Children;
	#endregion

	#region Region de Constructores Publicos
	public XplClassMembersList(){
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_tClassMembersList));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_tClassMembersList));
}
	public XplClassMembersList(XplNodeList n_Children){
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_tClassMembersList));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_tClassMembersList));
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Children!=null)
		for(XplNode node = n_Children.FirstNode(); node != null ; node = n_Children.NextNode()){
			p_Children.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	#endregion

	#region Destructor
/*	public ~XplClassMembersList(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplClassMembersList copy = new XplClassMembersList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			copy.Children().InsertAtEnd(node.Clone());
		}
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplClassMembersList;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		//Escribo recursivamente cada elemento hijo
		if(p_Children!=null)if(!p_Children.Write(writer))result=false;
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
		p_Children.Clear(); //Borro todo posible hijo en memoria
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "Inherits":
						tempNode = new XplInherits();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Implements":
						tempNode = new XplInherits();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Function":
						tempNode = new XplFunction();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Operator":
						tempNode = new XplFunction();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Indexer":
						tempNode = new XplFunction();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Property":
						tempNode = new XplProperty();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Field":
						tempNode = new XplField();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "e":
						tempNode = new XplExpression();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Class":
						tempNode = new XplClass();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "documentation":
						tempNode = new XplDocumentation();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "BeginCFPermissions":
						tempNode = new XplClassfactorysPermissions();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "EndCFPermissions":
						tempNode = new XplNode(XplNodeType_enum.EMPTY);
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "SetPlatforms":
						tempNode = new XplSetPlatforms();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "AutoInstance":
						tempNode = new XplAutoInstance();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
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
		writer.Write((int) 103 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		//Escribo recursivamente cada elemento hijo
		if(!p_Children.BinaryWrite(writer))result=false;
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		//Lectura de Elementos
		p_Children.BinaryRead(reader);
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplClassMembersList operator +(XplClassMembersList arg1, XplNode arg2)
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
public static XplClassMembersList operator +(XplClassMembersList arg1, XplNodeList arg2)
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
	public override XplNodeList Children(){
		return p_Children;
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
		for(XplNode node=p_Children.FirstNode();node!=null;node=p_Children.NextNode())
			list.InsertAtEnd(node);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos

	//Funciones para setear Elementos de Secuencia
	protected bool acceptInsertNodeCallback_tClassMembersList(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="Inherits"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplInherits){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Implements"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplInherits){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Function"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunction){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Operator"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunction){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Indexer"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunction){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Property"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplProperty){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Field"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplField){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="e"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplExpression){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Class"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplClass){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="documentation"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplDocumentation){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="BeginCFPermissions"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplClassfactorysPermissions){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="EndCFPermissions"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplNode){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="SetPlatforms"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplSetPlatforms){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="AutoInstance"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplAutoInstance){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClassMembersList'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplClassMembersList'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_tClassMembersList(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	#endregion

	#region Funciones para filtrado en Listas de Nodos
	public XplNodeList get_InheritsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Inherits"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_ImplementsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Implements"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_FunctionNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Function"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_OperatorNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Operator"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_IndexerNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Indexer"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_PropertyNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Property"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_FieldNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Field"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_eNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="e"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_ClassNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Class"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_documentationNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="documentation"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_BeginCFPermissionsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="BeginCFPermissions"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_EndCFPermissionsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="EndCFPermissions"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_SetPlatformsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="SetPlatforms"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_AutoInstanceNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="AutoInstance"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplInherits new_Inherits(){
		XplInherits node = new XplInherits();
		node.set_ElementName("Inherits");
		return node;
	}
	static public XplInherits new_Implements(){
		XplInherits node = new XplInherits();
		node.set_ElementName("Implements");
		return node;
	}
	static public XplFunction new_Function(){
		XplFunction node = new XplFunction();
		node.set_ElementName("Function");
		return node;
	}
	static public XplFunction new_Operator(){
		XplFunction node = new XplFunction();
		node.set_ElementName("Operator");
		return node;
	}
	static public XplFunction new_Indexer(){
		XplFunction node = new XplFunction();
		node.set_ElementName("Indexer");
		return node;
	}
	static public XplProperty new_Property(){
		XplProperty node = new XplProperty();
		node.set_ElementName("Property");
		return node;
	}
	static public XplField new_Field(){
		XplField node = new XplField();
		node.set_ElementName("Field");
		return node;
	}
	static public XplExpression new_e(){
		XplExpression node = new XplExpression();
		node.set_ElementName("e");
		return node;
	}
	static public XplClass new_Class(){
		XplClass node = new XplClass();
		node.set_ElementName("Class");
		return node;
	}
	static public XplDocumentation new_documentation(){
		XplDocumentation node = new XplDocumentation();
		node.set_ElementName("documentation");
		return node;
	}
	static public XplClassfactorysPermissions new_BeginCFPermissions(){
		XplClassfactorysPermissions node = new XplClassfactorysPermissions();
		node.set_ElementName("BeginCFPermissions");
		return node;
	}
	static public XplNode new_EndCFPermissions(){
		XplNode node = new XplNode(XplNodeType_enum.EMPTY);
		node.set_ElementName("EndCFPermissions");
		return node;
	}
	static public XplSetPlatforms new_SetPlatforms(){
		XplSetPlatforms node = new XplSetPlatforms();
		node.set_ElementName("SetPlatforms");
		return node;
	}
	static public XplAutoInstance new_AutoInstance(){
		XplAutoInstance node = new XplAutoInstance();
		node.set_ElementName("AutoInstance");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

