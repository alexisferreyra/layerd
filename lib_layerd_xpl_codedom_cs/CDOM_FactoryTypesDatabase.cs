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
public class FactoryTypesDatabase:  XplNode{

	#region Variables privadas para atributos y elementos
	int p_version;
	//Variables para Elementos de Secuencia
	XplNodeList p_Children;
	#endregion

	#region Region de Constructores Publicos
	public FactoryTypesDatabase(){
		p_version = 1;
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_FactoryTypesDatabase));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_FactoryTypesDatabase));
}
	public FactoryTypesDatabase(int n_version){
		p_version = 1;
		set_version(n_version);
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_FactoryTypesDatabase));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_FactoryTypesDatabase));
	}
	public FactoryTypesDatabase(XplNodeList n_Children){
		p_version = 1;
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_FactoryTypesDatabase));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_FactoryTypesDatabase));
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Children!=null)
		for(XplNode node = n_Children.FirstNode(); node != null ; node = n_Children.NextNode()){
			p_Children.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	public FactoryTypesDatabase(int n_version, XplNodeList n_Children){
		p_version = 1;
		set_version(n_version);
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_FactoryTypesDatabase));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_FactoryTypesDatabase));
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
/*	public ~FactoryTypesDatabase(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		FactoryTypesDatabase copy = new FactoryTypesDatabase();
		copy.set_version(this.p_version);
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			copy.Children().InsertAtEnd(node.Clone());
		}
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.FactoryTypesDatabase;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_version != 1)
			writer.WriteAttributeString( "version" ,ZoeHelper .Att_ToString(p_version) );
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
					case "version":
						this.set_version(ZoeHelper .StringAtt_To_INT(reader.Value));
						break;
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
					case "Classfactory":
						tempNode = new ClassfactoryData();
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
		writer.Write((int) 120 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_version );
		//Escribo recursivamente cada elemento hijo
		if(!p_Children.BinaryWrite(writer))result=false;
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_version = reader.ReadInt32();
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
public static FactoryTypesDatabase operator +(FactoryTypesDatabase arg1, XplNode arg2)
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
public static FactoryTypesDatabase operator +(FactoryTypesDatabase arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public int get_version(){
		return p_version;
	}
	//Funciones para obtener Elementos de Secuencia
	public override XplNodeList Children(){
		return p_Children;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[1];
		ret[0] = "version";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="version") return p_version.ToString();
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
	public int set_version(int new_version){
		int back_version = p_version;
		p_version = new_version;
		return back_version;
	}

	//Funciones para setear Elementos de Secuencia
	protected bool acceptInsertNodeCallback_FactoryTypesDatabase(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="Classfactory"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.ClassfactoryData){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'FactoryTypesDatabase'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'FactoryTypesDatabase'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_FactoryTypesDatabase(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	#endregion

	#region Funciones para filtrado en Listas de Nodos
	public XplNodeList get_ClassfactoryNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Classfactory"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public ClassfactoryData new_Classfactory(){
		ClassfactoryData node = new ClassfactoryData();
		node.set_ElementName("Classfactory");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

