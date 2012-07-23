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
public class XplDocument:  XplNode{

	#region Variables privadas para atributos y elementos
	//Variables para Elementos de Secuencia
	XplDocumentData p_DocumentData;
	XplDocumentBody p_DocumentBody;
	#endregion

	#region Region de Constructores Publicos
	public XplDocument(){
		p_DocumentData=null;
		p_DocumentBody=null;
}
	public XplDocument(XplDocumentData n_DocumentData, XplDocumentBody n_DocumentBody){
		p_DocumentData=null;
		p_DocumentBody=null;
		set_DocumentData(n_DocumentData);
		set_DocumentBody(n_DocumentBody);
	}
	#endregion

	#region Destructor
/*	public ~XplDocument(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplDocument copy = new XplDocument();
		if(p_DocumentData!=null)copy.set_DocumentData((XplDocumentData)p_DocumentData.Clone());
		if(p_DocumentBody!=null)copy.set_DocumentBody((XplDocumentBody)p_DocumentBody.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplDocument;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		//Escribo recursivamente cada elemento hijo
		if(p_DocumentData!=null)if(!p_DocumentData.Write(writer))result=false;
		if(p_DocumentBody!=null)if(!p_DocumentBody.Write(writer))result=false;
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
		this.p_DocumentData=null;
		this.p_DocumentBody=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "DocumentData":
						tempNode = new XplDocumentData();
						tempNode.Read(reader);
						if(this.get_DocumentData()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_DocumentData((XplDocumentData)tempNode);
						break;
					case "DocumentBody":
						tempNode = new XplDocumentBody();
						tempNode.Read(reader);
						if(this.get_DocumentBody()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_DocumentBody((XplDocumentBody)tempNode);
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
		writer.Write((int) 159 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		//Escribo recursivamente cada elemento hijo
		if(p_DocumentData!=null){
			writer.Write((int)1);
			if(!p_DocumentData.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_DocumentBody!=null){
			writer.Write((int)1);
			if(!p_DocumentBody.BinaryWrite(writer))result=false;
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
			p_DocumentData = (XplDocumentData)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_DocumentBody = (XplDocumentBody)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplDocument operator +(XplDocument arg1, XplNode arg2)
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
public static XplDocument operator +(XplDocument arg1, XplNodeList arg2)
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
	public XplDocumentData get_DocumentData(){
		return p_DocumentData;
	}
	public XplDocumentBody get_DocumentBody(){
		return p_DocumentBody;
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
		list.InsertAtEnd(p_DocumentData);
		list.InsertAtEnd(p_DocumentBody);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos

	//Funciones para setear Elementos de Secuencia
	public XplDocumentData set_DocumentData(XplDocumentData new_DocumentData){
		XplDocumentData back_DocumentData = p_DocumentData;
		p_DocumentData = new_DocumentData;
		if(p_DocumentData!=null){
			p_DocumentData.set_ElementName("DocumentData");
			p_DocumentData.set_Parent(this);
		}
		return back_DocumentData;
	}
	public XplDocumentBody set_DocumentBody(XplDocumentBody new_DocumentBody){
		XplDocumentBody back_DocumentBody = p_DocumentBody;
		p_DocumentBody = new_DocumentBody;
		if(p_DocumentBody!=null){
			p_DocumentBody.set_ElementName("DocumentBody");
			p_DocumentBody.set_Parent(this);
		}
		return back_DocumentBody;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplDocumentData new_DocumentData(){
		XplDocumentData node = new XplDocumentData();
		node.set_ElementName("DocumentData");
		return node;
	}
	static public XplDocumentBody new_DocumentBody(){
		XplDocumentBody node = new XplDocumentBody();
		node.set_ElementName("DocumentBody");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

