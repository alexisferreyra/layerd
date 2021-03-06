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
public class XplIfStatement:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplExpression p_boolean;
	XplFunctionBody p_ifbk;
	XplNodeList p_elseif;
	XplFunctionBody p_else;
	#endregion

	#region Region de Constructores Publicos
	public XplIfStatement(){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_boolean=null;
		p_ifbk=null;
		p_elseif = new XplNodeList();
		p_elseif.set_Parent(this);
		p_elseif.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_elseif));
		p_elseif.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_elseif));
		p_else=null;
}
	public XplIfStatement(XplExpression n_boolean){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_boolean=null;
		p_ifbk=null;
		p_elseif = new XplNodeList();
		p_elseif.set_Parent(this);
		p_elseif.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_elseif));
		p_elseif.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_elseif));
		p_else=null;
		set_boolean(n_boolean);
	}
	public XplIfStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_boolean=null;
		p_ifbk=null;
		p_elseif = new XplNodeList();
		p_elseif.set_Parent(this);
		p_elseif.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_elseif));
		p_elseif.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_elseif));
		p_else=null;
	}
	public XplIfStatement(XplExpression n_boolean, XplFunctionBody n_ifbk, XplNodeList n_elseif, XplFunctionBody n_else){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_boolean=null;
		p_ifbk=null;
		p_elseif = new XplNodeList();
		p_elseif.set_Parent(this);
		p_elseif.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_elseif));
		p_elseif.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_elseif));
		p_else=null;
		set_boolean(n_boolean);
		set_ifbk(n_ifbk);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_elseif!=null)
		for(XplNode node = n_elseif.FirstNode(); node != null ; node = n_elseif.NextNode()){
			p_elseif.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		set_else(n_else);
	}
	public XplIfStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression n_boolean){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_boolean=null;
		p_ifbk=null;
		p_elseif = new XplNodeList();
		p_elseif.set_Parent(this);
		p_elseif.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_elseif));
		p_elseif.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_elseif));
		p_else=null;
	}
	public XplIfStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression n_boolean, XplFunctionBody n_ifbk, XplNodeList n_elseif, XplFunctionBody n_else){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_boolean=null;
		p_ifbk=null;
		p_elseif = new XplNodeList();
		p_elseif.set_Parent(this);
		p_elseif.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_elseif));
		p_elseif.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_elseif));
		p_else=null;
		set_boolean(n_boolean);
		set_ifbk(n_ifbk);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_elseif!=null)
		for(XplNode node = n_elseif.FirstNode(); node != null ; node = n_elseif.NextNode()){
			p_elseif.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		set_else(n_else);
	}
	#endregion

	#region Destructor
/*	public ~XplIfStatement(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplIfStatement copy = new XplIfStatement();
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_boolean!=null)copy.set_boolean((XplExpression)p_boolean.Clone());
		if(p_ifbk!=null)copy.set_ifbk((XplFunctionBody)p_ifbk.Clone());
		for(XplNode node = p_elseif.FirstNode(); node != null ; node = p_elseif.NextNode()){
			copy.get_elseif().InsertAtEnd(node.Clone());
		}
		if(p_else!=null)copy.set_else((XplFunctionBody)p_else.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplIfStatement;}

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
		if(p_boolean!=null)if(!p_boolean.Write(writer))result=false;
		if(p_ifbk!=null)if(!p_ifbk.Write(writer))result=false;
		if(p_elseif!=null)if(!p_elseif.Write(writer))result=false;
		if(p_else!=null)if(!p_else.Write(writer))result=false;
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
		this.p_boolean=null;
		this.p_ifbk=null;
		this.p_else=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "boolean":
						tempNode = new XplExpression();
						tempNode.Read(reader);
						if(this.get_boolean()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_boolean((XplExpression)tempNode);
						break;
					case "ifbk":
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						if(this.get_ifbk()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_ifbk((XplFunctionBody)tempNode);
						break;
					case "elseif":
						tempNode = new XplIfStatement();
						tempNode.Read(reader);
						this.get_elseif().InsertAtEnd(tempNode);
						break;
					case "else":
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						if(this.get_else()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_else((XplFunctionBody)tempNode);
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
		writer.Write((int) 129 );
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
		if(p_boolean!=null){
			writer.Write((int)1);
			if(!p_boolean.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_ifbk!=null){
			writer.Write((int)1);
			if(!p_ifbk.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_elseif!=null){
			writer.Write((int)1);
			if(!p_elseif.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_else!=null){
			writer.Write((int)1);
			if(!p_else.BinaryWrite(writer))result=false;
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
			p_boolean = (XplExpression)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_ifbk = (XplFunctionBody)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_elseif.BinaryRead(reader);
		}
		if(reader.ReadInt32()==1){
			p_else = (XplFunctionBody)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplIfStatement operator +(XplIfStatement arg1, XplNode arg2)
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
public static XplIfStatement operator +(XplIfStatement arg1, XplNodeList arg2)
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
	public XplExpression get_boolean(){
		return p_boolean;
	}
	public XplFunctionBody get_ifbk(){
		return p_ifbk;
	}
	public XplNodeList get_elseif(){
		return p_elseif;
	}
	public XplFunctionBody get_else(){
		return p_else;
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
		list.InsertAtEnd(p_boolean);
		list.InsertAtEnd(p_ifbk);
		for(XplNode node=p_elseif.FirstNode();node!=null;node=p_elseif.NextNode())
			list.InsertAtEnd(node);
		list.InsertAtEnd(p_else);
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
	public XplExpression set_boolean(XplExpression new_boolean){
		XplExpression back_boolean = p_boolean;
		p_boolean = new_boolean;
		if(p_boolean!=null){
			p_boolean.set_ElementName("boolean");
			p_boolean.set_Parent(this);
		}
		return back_boolean;
	}
	public XplFunctionBody set_ifbk(XplFunctionBody new_ifbk){
		XplFunctionBody back_ifbk = p_ifbk;
		p_ifbk = new_ifbk;
		if(p_ifbk!=null){
			p_ifbk.set_ElementName("ifbk");
			p_ifbk.set_Parent(this);
		}
		return back_ifbk;
	}
	protected bool acceptInsertNodeCallback_elseif(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="elseif"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplIfStatement){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplIfStatement'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplIfStatement'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_elseif(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	public XplFunctionBody set_else(XplFunctionBody new_else){
		XplFunctionBody back_else = p_else;
		p_else = new_else;
		if(p_else!=null){
			p_else.set_ElementName("else");
			p_else.set_Parent(this);
		}
		return back_else;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplExpression new_boolean(){
		XplExpression node = new XplExpression();
		node.set_ElementName("boolean");
		return node;
	}
	static public XplFunctionBody new_ifbk(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_ElementName("ifbk");
		return node;
	}
	static public XplIfStatement new_elseif(){
		XplIfStatement node = new XplIfStatement();
		node.set_ElementName("elseif");
		return node;
	}
	static public XplFunctionBody new_else(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_ElementName("else");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

