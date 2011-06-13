/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 3/2/2010 9:11:43 PM
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
public class XplTryStatement:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplFunctionBody p_trybk;
	XplNodeList p_catchbk;
	XplFunctionBody p_finallybk;
	#endregion

	#region Region de Constructores Publicos
	public XplTryStatement(){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_trybk=null;
		p_catchbk = new XplNodeList();
		p_catchbk.set_Parent(this);
		p_catchbk.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_catchbk));
		p_catchbk.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_catchbk));
		p_finallybk=null;
}
	public XplTryStatement(XplFunctionBody n_trybk, XplNodeList n_catchbk){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_trybk=null;
		p_catchbk = new XplNodeList();
		p_catchbk.set_Parent(this);
		p_catchbk.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_catchbk));
		p_catchbk.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_catchbk));
		p_finallybk=null;
		set_trybk(n_trybk);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_catchbk!=null)
		for(XplNode node = n_catchbk.FirstNode(); node != null ; node = n_catchbk.NextNode()){
			p_catchbk.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	public XplTryStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_trybk=null;
		p_catchbk = new XplNodeList();
		p_catchbk.set_Parent(this);
		p_catchbk.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_catchbk));
		p_catchbk.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_catchbk));
		p_finallybk=null;
	}
	public XplTryStatement(XplFunctionBody n_trybk, XplNodeList n_catchbk, XplFunctionBody n_finallybk){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_trybk=null;
		p_catchbk = new XplNodeList();
		p_catchbk.set_Parent(this);
		p_catchbk.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_catchbk));
		p_catchbk.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_catchbk));
		p_finallybk=null;
		set_trybk(n_trybk);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_catchbk!=null)
		for(XplNode node = n_catchbk.FirstNode(); node != null ; node = n_catchbk.NextNode()){
			p_catchbk.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		set_finallybk(n_finallybk);
	}
	public XplTryStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplFunctionBody n_trybk, XplNodeList n_catchbk){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_trybk=null;
		p_catchbk = new XplNodeList();
		p_catchbk.set_Parent(this);
		p_catchbk.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_catchbk));
		p_catchbk.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_catchbk));
		p_finallybk=null;
	}
	public XplTryStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplFunctionBody n_trybk, XplNodeList n_catchbk, XplFunctionBody n_finallybk){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_trybk=null;
		p_catchbk = new XplNodeList();
		p_catchbk.set_Parent(this);
		p_catchbk.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_catchbk));
		p_catchbk.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_catchbk));
		p_finallybk=null;
		set_trybk(n_trybk);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_catchbk!=null)
		for(XplNode node = n_catchbk.FirstNode(); node != null ; node = n_catchbk.NextNode()){
			p_catchbk.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		set_finallybk(n_finallybk);
	}
	#endregion

	#region Destructor
/*	public ~XplTryStatement(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplTryStatement copy = new XplTryStatement();
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_trybk!=null)copy.set_trybk((XplFunctionBody)p_trybk.Clone());
		for(XplNode node = p_catchbk.FirstNode(); node != null ; node = p_catchbk.NextNode()){
			copy.get_catchbk().InsertAtEnd(node.Clone());
		}
		if(p_finallybk!=null)copy.set_finallybk((XplFunctionBody)p_finallybk.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplTryStatement;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_doc != "")
			writer.WriteAttributeString( "doc" ,ZoeHelper .Att_ToString(p_doc) );
		if(p_helpURL != "")
			writer.WriteAttributeString( "helpURL" ,ZoeHelper .Att_ToString(p_helpURL) );
		if(p_ldsrc != "")
			writer.WriteAttributeString( "ldsrc" ,ZoeHelper .Att_ToString(p_ldsrc) );
		if(p_iny != false)
			writer.WriteAttributeString( "iny" ,ZoeHelper .Att_ToString(p_iny) );
		if(p_inydata != "")
			writer.WriteAttributeString( "inydata" ,ZoeHelper .Att_ToString(p_inydata) );
		if(p_inyby != "")
			writer.WriteAttributeString( "inyby" ,ZoeHelper .Att_ToString(p_inyby) );
		if(p_lddata != "")
			writer.WriteAttributeString( "lddata" ,ZoeHelper .Att_ToString(p_lddata) );
		//Escribo recursivamente cada elemento hijo
		if(p_trybk!=null)if(!p_trybk.Write(writer))result=false;
		if(p_catchbk!=null)if(!p_catchbk.Write(writer))result=false;
		if(p_finallybk!=null)if(!p_finallybk.Write(writer))result=false;
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
					case "doc":
						this.set_doc(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "helpURL":
						this.set_helpURL(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "ldsrc":
						this.set_ldsrc(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "iny":
						this.set_iny(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "inydata":
						this.set_inydata(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "inyby":
						this.set_inyby(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "lddata":
						this.set_lddata(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Atributo '"+reader.Name+"' invalido en elemento '"+this.get_ElementName()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		//Borro todo posible nodo en memoria
		this.p_trybk=null;
		this.p_finallybk=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "trybk":
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						if(this.get_trybk()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_trybk((XplFunctionBody)tempNode);
						break;
					case "catchbk":
						tempNode = new XplCatchStatement();
						tempNode.Read(reader);
						this.get_catchbk().InsertAtEnd(tempNode);
						break;
					case "finallybk":
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						if(this.get_finallybk()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_finallybk((XplFunctionBody)tempNode);
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
		writer.Write((int) 154 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_doc );
		writer.Write( p_helpURL );
		writer.Write( p_ldsrc );
		writer.Write( p_iny );
		writer.Write( p_inydata );
		writer.Write( p_inyby );
		writer.Write( p_lddata );
		//Escribo recursivamente cada elemento hijo
		if(p_trybk!=null){
			writer.Write((int)1);
			if(!p_trybk.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_catchbk!=null){
			writer.Write((int)1);
			if(!p_catchbk.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_finallybk!=null){
			writer.Write((int)1);
			if(!p_finallybk.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_doc = reader.ReadString();
		p_helpURL = reader.ReadString();
		p_ldsrc = reader.ReadString();
		p_iny = reader.ReadBoolean();
		p_inydata = reader.ReadString();
		p_inyby = reader.ReadString();
		p_lddata = reader.ReadString();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_trybk = (XplFunctionBody)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_catchbk.BinaryRead(reader);
		}
		if(reader.ReadInt32()==1){
			p_finallybk = (XplFunctionBody)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplTryStatement operator +(XplTryStatement arg1, XplNode arg2)
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
public static XplTryStatement operator +(XplTryStatement arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public override string get_doc(){
		return p_doc;
	}
	public override string get_helpURL(){
		return p_helpURL;
	}
	public override string get_ldsrc(){
		return p_ldsrc;
	}
	public override bool get_iny(){
		return p_iny;
	}
	public override string get_inydata(){
		return p_inydata;
	}
	public override string get_inyby(){
		return p_inyby;
	}
	public override string get_lddata(){
		return p_lddata;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplFunctionBody get_trybk(){
		return p_trybk;
	}
	public XplNodeList get_catchbk(){
		return p_catchbk;
	}
	public XplFunctionBody get_finallybk(){
		return p_finallybk;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[7];
		ret[0] = "doc";
		ret[1] = "helpURL";
		ret[2] = "ldsrc";
		ret[3] = "iny";
		ret[4] = "inydata";
		ret[5] = "inyby";
		ret[6] = "lddata";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="doc") return p_doc.ToString();
		if (attributeName=="helpURL") return p_helpURL.ToString();
		if (attributeName=="ldsrc") return p_ldsrc.ToString();
		if (attributeName=="iny") return p_iny.ToString();
		if (attributeName=="inydata") return p_inydata.ToString();
		if (attributeName=="inyby") return p_inyby.ToString();
		if (attributeName=="lddata") return p_lddata.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		list.InsertAtEnd(p_trybk);
		for(XplNode node=p_catchbk.FirstNode();node!=null;node=p_catchbk.NextNode())
			list.InsertAtEnd(node);
		list.InsertAtEnd(p_finallybk);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public override string set_doc(string new_doc){
		string back_doc = p_doc;
		p_doc = new_doc;
		return back_doc;
	}
	public override string set_helpURL(string new_helpURL){
		string back_helpURL = p_helpURL;
		p_helpURL = new_helpURL;
		return back_helpURL;
	}
	public override string set_ldsrc(string new_ldsrc){
		string back_ldsrc = p_ldsrc;
		p_ldsrc = new_ldsrc;
		return back_ldsrc;
	}
	public override bool set_iny(bool new_iny){
		bool back_iny = p_iny;
		p_iny = new_iny;
		return back_iny;
	}
	public override string set_inydata(string new_inydata){
		string back_inydata = p_inydata;
		p_inydata = new_inydata;
		return back_inydata;
	}
	public override string set_inyby(string new_inyby){
		string back_inyby = p_inyby;
		p_inyby = new_inyby;
		return back_inyby;
	}
	public override string set_lddata(string new_lddata){
		string back_lddata = p_lddata;
		p_lddata = new_lddata;
		return back_lddata;
	}

	//Funciones para setear Elementos de Secuencia
	public XplFunctionBody set_trybk(XplFunctionBody new_trybk){
		XplFunctionBody back_trybk = p_trybk;
		p_trybk = new_trybk;
		if(p_trybk!=null){
			p_trybk.set_ElementName("trybk");
			p_trybk.set_Parent(this);
		}
		return back_trybk;
	}
	protected bool acceptInsertNodeCallback_catchbk(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="catchbk"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplCatchStatement){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplCatchStatement'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplCatchStatement'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_catchbk(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	public XplFunctionBody set_finallybk(XplFunctionBody new_finallybk){
		XplFunctionBody back_finallybk = p_finallybk;
		p_finallybk = new_finallybk;
		if(p_finallybk!=null){
			p_finallybk.set_ElementName("finallybk");
			p_finallybk.set_Parent(this);
		}
		return back_finallybk;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplFunctionBody new_trybk(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_ElementName("trybk");
		return node;
	}
	static public XplCatchStatement new_catchbk(){
		XplCatchStatement node = new XplCatchStatement();
		node.set_ElementName("catchbk");
		return node;
	}
	static public XplFunctionBody new_finallybk(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_ElementName("finallybk");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

