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
public class XplSwitchStatement:  XplNode{

	#region Variables privadas para atributos y elementos
	bool p_autobreak;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplExpression p_e;
	XplNodeList p_case;
	#endregion

	#region Region de Constructores Publicos
	public XplSwitchStatement(){
		p_autobreak = true;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_e=null;
		p_case = new XplNodeList();
		p_case.set_Parent(this);
		p_case.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_case));
		p_case.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_case));
}
	public XplSwitchStatement(bool n_autobreak){
		p_autobreak = true;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_autobreak(n_autobreak);
		p_e=null;
		p_case = new XplNodeList();
		p_case.set_Parent(this);
		p_case.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_case));
		p_case.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_case));
	}
	public XplSwitchStatement(XplExpression n_e, XplNodeList n_case){
		p_autobreak = true;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_e=null;
		p_case = new XplNodeList();
		p_case.set_Parent(this);
		p_case.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_case));
		p_case.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_case));
		set_e(n_e);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_case!=null)
		for(XplNode node = n_case.FirstNode(); node != null ; node = n_case.NextNode()){
			p_case.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	public XplSwitchStatement(bool n_autobreak, XplExpression n_e, XplNodeList n_case){
		p_autobreak = true;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_autobreak(n_autobreak);
		p_e=null;
		p_case = new XplNodeList();
		p_case.set_Parent(this);
		p_case.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_case));
		p_case.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_case));
		set_e(n_e);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_case!=null)
		for(XplNode node = n_case.FirstNode(); node != null ; node = n_case.NextNode()){
			p_case.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	public XplSwitchStatement(bool n_autobreak, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
		set_autobreak(n_autobreak);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_e=null;
		p_case = new XplNodeList();
		p_case.set_Parent(this);
		p_case.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_case));
		p_case.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_case));
	}
	public XplSwitchStatement(bool n_autobreak, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression n_e, XplNodeList n_case){
		set_autobreak(n_autobreak);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_autobreak(n_autobreak);
		p_e=null;
		p_case = new XplNodeList();
		p_case.set_Parent(this);
		p_case.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_case));
		p_case.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_case));
	}
	#endregion

	#region Destructor
/*	public ~XplSwitchStatement(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplSwitchStatement copy = new XplSwitchStatement();
		copy.set_autobreak(this.p_autobreak);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_e!=null)copy.set_e((XplExpression)p_e.Clone());
		for(XplNode node = p_case.FirstNode(); node != null ; node = p_case.NextNode()){
			copy.get_case().InsertAtEnd(node.Clone());
		}
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplSwitchStatement;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_autobreak != true)
			writer.WriteAttributeString( "autobreak" ,ZoeHelper .Att_ToString(p_autobreak) );
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
		if(p_e!=null)if(!p_e.Write(writer))result=false;
		if(p_case!=null)if(!p_case.Write(writer))result=false;
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
					case "autobreak":
						this.set_autobreak(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
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
		this.p_e=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "e":
						tempNode = new XplExpression();
						tempNode.Read(reader);
						if(this.get_e()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_e((XplExpression)tempNode);
						break;
					case "case":
						tempNode = new XplCase();
						tempNode.Read(reader);
						this.get_case().InsertAtEnd(tempNode);
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
		writer.Write((int) 139 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_autobreak );
		writer.Write( p_doc );
		writer.Write( p_helpURL );
		writer.Write( p_ldsrc );
		writer.Write( p_iny );
		writer.Write( p_inydata );
		writer.Write( p_inyby );
		writer.Write( p_lddata );
		//Escribo recursivamente cada elemento hijo
		if(p_e!=null){
			writer.Write((int)1);
			if(!p_e.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_case!=null){
			writer.Write((int)1);
			if(!p_case.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_autobreak = reader.ReadBoolean();
		p_doc = reader.ReadString();
		p_helpURL = reader.ReadString();
		p_ldsrc = reader.ReadString();
		p_iny = reader.ReadBoolean();
		p_inydata = reader.ReadString();
		p_inyby = reader.ReadString();
		p_lddata = reader.ReadString();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_e = (XplExpression)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_case.BinaryRead(reader);
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplSwitchStatement operator +(XplSwitchStatement arg1, XplNode arg2)
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
public static XplSwitchStatement operator +(XplSwitchStatement arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public bool get_autobreak(){
		return p_autobreak;
	}
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
	public XplExpression get_e(){
		return p_e;
	}
	public XplNodeList get_case(){
		return p_case;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[8];
		ret[0] = "autobreak";
		ret[1] = "doc";
		ret[2] = "helpURL";
		ret[3] = "ldsrc";
		ret[4] = "iny";
		ret[5] = "inydata";
		ret[6] = "inyby";
		ret[7] = "lddata";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="autobreak") return p_autobreak.ToString();
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
		list.InsertAtEnd(p_e);
		for(XplNode node=p_case.FirstNode();node!=null;node=p_case.NextNode())
			list.InsertAtEnd(node);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public bool set_autobreak(bool new_autobreak){
		bool back_autobreak = p_autobreak;
		p_autobreak = new_autobreak;
		return back_autobreak;
	}
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
	public XplExpression set_e(XplExpression new_e){
		XplExpression back_e = p_e;
		p_e = new_e;
		if(p_e!=null){
			p_e.set_ElementName("e");
			p_e.set_Parent(this);
		}
		return back_e;
	}
	protected bool acceptInsertNodeCallback_case(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="case"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplCase){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplCase'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplCase'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_case(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplExpression new_e(){
		XplExpression node = new XplExpression();
		node.set_ElementName("e");
		return node;
	}
	static public XplCase new_case(){
		XplCase node = new XplCase();
		node.set_ElementName("case");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

