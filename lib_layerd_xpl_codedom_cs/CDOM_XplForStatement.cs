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
public class XplForStatement:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplForinit p_init;
	XplExpression p_condition;
	XplExpressionlist p_repeat;
	XplFunctionBody p_forblock;
	#endregion

	#region Region de Constructores Publicos
	public XplForStatement(){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_init=null;
		p_condition=null;
		p_repeat=null;
		p_forblock=null;
}
	public XplForStatement(XplForinit n_init, XplExpression n_condition, XplExpressionlist n_repeat, XplFunctionBody n_forblock){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_init=null;
		p_condition=null;
		p_repeat=null;
		p_forblock=null;
		set_init(n_init);
		set_condition(n_condition);
		set_repeat(n_repeat);
		set_forblock(n_forblock);
	}
	public XplForStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_init=null;
		p_condition=null;
		p_repeat=null;
		p_forblock=null;
	}
	public XplForStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplForinit n_init, XplExpression n_condition, XplExpressionlist n_repeat, XplFunctionBody n_forblock){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_init=null;
		p_condition=null;
		p_repeat=null;
		p_forblock=null;
	}
	#endregion

	#region Destructor
/*	public ~XplForStatement(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplForStatement copy = new XplForStatement();
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_init!=null)copy.set_init((XplForinit)p_init.Clone());
		if(p_condition!=null)copy.set_condition((XplExpression)p_condition.Clone());
		if(p_repeat!=null)copy.set_repeat((XplExpressionlist)p_repeat.Clone());
		if(p_forblock!=null)copy.set_forblock((XplFunctionBody)p_forblock.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplForStatement;}

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
		if(p_init!=null)if(!p_init.Write(writer))result=false;
		if(p_condition!=null)if(!p_condition.Write(writer))result=false;
		if(p_repeat!=null)if(!p_repeat.Write(writer))result=false;
		if(p_forblock!=null)if(!p_forblock.Write(writer))result=false;
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
		this.p_init=null;
		this.p_condition=null;
		this.p_repeat=null;
		this.p_forblock=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "init":
						tempNode = new XplForinit();
						tempNode.Read(reader);
						if(this.get_init()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_init((XplForinit)tempNode);
						break;
					case "condition":
						tempNode = new XplExpression();
						tempNode.Read(reader);
						if(this.get_condition()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_condition((XplExpression)tempNode);
						break;
					case "repeat":
						tempNode = new XplExpressionlist();
						tempNode.Read(reader);
						if(this.get_repeat()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_repeat((XplExpressionlist)tempNode);
						break;
					case "forblock":
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						if(this.get_forblock()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_forblock((XplFunctionBody)tempNode);
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
		writer.Write((int) 135 );
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
		if(p_init!=null){
			writer.Write((int)1);
			if(!p_init.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_condition!=null){
			writer.Write((int)1);
			if(!p_condition.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_repeat!=null){
			writer.Write((int)1);
			if(!p_repeat.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_forblock!=null){
			writer.Write((int)1);
			if(!p_forblock.BinaryWrite(writer))result=false;
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
			p_init = (XplForinit)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_condition = (XplExpression)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_repeat = (XplExpressionlist)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_forblock = (XplFunctionBody)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplForStatement operator +(XplForStatement arg1, XplNode arg2)
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
public static XplForStatement operator +(XplForStatement arg1, XplNodeList arg2)
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
	public XplForinit get_init(){
		return p_init;
	}
	public XplExpression get_condition(){
		return p_condition;
	}
	public XplExpressionlist get_repeat(){
		return p_repeat;
	}
	public XplFunctionBody get_forblock(){
		return p_forblock;
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
		list.InsertAtEnd(p_init);
		list.InsertAtEnd(p_condition);
		list.InsertAtEnd(p_repeat);
		list.InsertAtEnd(p_forblock);
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
	public XplForinit set_init(XplForinit new_init){
		XplForinit back_init = p_init;
		p_init = new_init;
		if(p_init!=null){
			p_init.set_ElementName("init");
			p_init.set_Parent(this);
		}
		return back_init;
	}
	public XplExpression set_condition(XplExpression new_condition){
		XplExpression back_condition = p_condition;
		p_condition = new_condition;
		if(p_condition!=null){
			p_condition.set_ElementName("condition");
			p_condition.set_Parent(this);
		}
		return back_condition;
	}
	public XplExpressionlist set_repeat(XplExpressionlist new_repeat){
		XplExpressionlist back_repeat = p_repeat;
		p_repeat = new_repeat;
		if(p_repeat!=null){
			p_repeat.set_ElementName("repeat");
			p_repeat.set_Parent(this);
		}
		return back_repeat;
	}
	public XplFunctionBody set_forblock(XplFunctionBody new_forblock){
		XplFunctionBody back_forblock = p_forblock;
		p_forblock = new_forblock;
		if(p_forblock!=null){
			p_forblock.set_ElementName("forblock");
			p_forblock.set_Parent(this);
		}
		return back_forblock;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplForinit new_init(){
		XplForinit node = new XplForinit();
		node.set_ElementName("init");
		return node;
	}
	static public XplExpression new_condition(){
		XplExpression node = new XplExpression();
		node.set_ElementName("condition");
		return node;
	}
	static public XplExpressionlist new_repeat(){
		XplExpressionlist node = new XplExpressionlist();
		node.set_ElementName("repeat");
		return node;
	}
	static public XplFunctionBody new_forblock(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_ElementName("forblock");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

