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
public class XplFunctioncall:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_name;
	string p_targetClass;
	string p_targetMember;
	string p_targetClassExternalName;
	string p_targetMemberExternalName;
	string p_ldxplcMods;
	bool p_ignoreforsubprogram;
	bool p_evaluateBlock;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplExpression p_l;
	XplExpressionlist p_args;
	XplFunctionBody p_bk;
	#endregion

	#region Region de Constructores Publicos
	public XplFunctioncall(){
		p_name = "";
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ldxplcMods = "";
		p_ignoreforsubprogram = false;
		p_evaluateBlock = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_l=null;
		p_args=null;
		p_bk=null;
}
	public XplFunctioncall(bool n_ignoreforsubprogram, bool n_evaluateBlock){
		p_name = "";
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ldxplcMods = "";
		p_ignoreforsubprogram = false;
		p_evaluateBlock = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_evaluateBlock(n_evaluateBlock);
		p_l=null;
		p_args=null;
		p_bk=null;
	}
	public XplFunctioncall(XplExpression n_l, XplFunctionBody n_bk){
		p_name = "";
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ldxplcMods = "";
		p_ignoreforsubprogram = false;
		p_evaluateBlock = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_l=null;
		p_args=null;
		p_bk=null;
		set_l(n_l);
		set_bk(n_bk);
	}
	public XplFunctioncall(bool n_ignoreforsubprogram, bool n_evaluateBlock, XplExpression n_l, XplFunctionBody n_bk){
		p_name = "";
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ldxplcMods = "";
		p_ignoreforsubprogram = false;
		p_evaluateBlock = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_evaluateBlock(n_evaluateBlock);
		p_l=null;
		p_args=null;
		p_bk=null;
		set_l(n_l);
		set_bk(n_bk);
	}
	public XplFunctioncall(string n_name, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, string n_ldxplcMods, bool n_ignoreforsubprogram, bool n_evaluateBlock, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
		set_name(n_name);
		set_targetClass(n_targetClass);
		set_targetMember(n_targetMember);
		set_targetClassExternalName(n_targetClassExternalName);
		set_targetMemberExternalName(n_targetMemberExternalName);
		set_ldxplcMods(n_ldxplcMods);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_evaluateBlock(n_evaluateBlock);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_l=null;
		p_args=null;
		p_bk=null;
	}
	public XplFunctioncall(XplExpression n_l, XplExpressionlist n_args, XplFunctionBody n_bk){
		p_name = "";
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ldxplcMods = "";
		p_ignoreforsubprogram = false;
		p_evaluateBlock = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_l=null;
		p_args=null;
		p_bk=null;
		set_l(n_l);
		set_args(n_args);
		set_bk(n_bk);
	}
	public XplFunctioncall(string n_name, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, string n_ldxplcMods, bool n_ignoreforsubprogram, bool n_evaluateBlock, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression n_l, XplFunctionBody n_bk){
		set_name(n_name);
		set_targetClass(n_targetClass);
		set_targetMember(n_targetMember);
		set_targetClassExternalName(n_targetClassExternalName);
		set_targetMemberExternalName(n_targetMemberExternalName);
		set_ldxplcMods(n_ldxplcMods);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_evaluateBlock(n_evaluateBlock);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_evaluateBlock(n_evaluateBlock);
		p_l=null;
		p_args=null;
		p_bk=null;
	}
	public XplFunctioncall(bool n_ignoreforsubprogram, bool n_evaluateBlock, XplExpression n_l, XplExpressionlist n_args, XplFunctionBody n_bk){
		p_name = "";
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ldxplcMods = "";
		p_ignoreforsubprogram = false;
		p_evaluateBlock = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_evaluateBlock(n_evaluateBlock);
		p_l=null;
		p_args=null;
		p_bk=null;
		set_l(n_l);
		set_args(n_args);
		set_bk(n_bk);
	}
	public XplFunctioncall(string n_name, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, string n_ldxplcMods, bool n_ignoreforsubprogram, bool n_evaluateBlock, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression n_l, XplExpressionlist n_args, XplFunctionBody n_bk){
		set_name(n_name);
		set_targetClass(n_targetClass);
		set_targetMember(n_targetMember);
		set_targetClassExternalName(n_targetClassExternalName);
		set_targetMemberExternalName(n_targetMemberExternalName);
		set_ldxplcMods(n_ldxplcMods);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_evaluateBlock(n_evaluateBlock);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_l=null;
		p_args=null;
		p_bk=null;
		set_l(n_l);
		set_args(n_args);
		set_bk(n_bk);
	}
	#endregion

	#region Destructor
/*	public ~XplFunctioncall(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplFunctioncall copy = new XplFunctioncall();
		copy.set_name(this.p_name);
		copy.set_targetClass(this.p_targetClass);
		copy.set_targetMember(this.p_targetMember);
		copy.set_targetClassExternalName(this.p_targetClassExternalName);
		copy.set_targetMemberExternalName(this.p_targetMemberExternalName);
		copy.set_ldxplcMods(this.p_ldxplcMods);
		copy.set_ignoreforsubprogram(this.p_ignoreforsubprogram);
		copy.set_evaluateBlock(this.p_evaluateBlock);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_l!=null)copy.set_l((XplExpression)p_l.Clone());
		if(p_args!=null)copy.set_args((XplExpressionlist)p_args.Clone());
		if(p_bk!=null)copy.set_bk((XplFunctionBody)p_bk.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplFunctioncall;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,ZoeHelper .Att_ToString(p_name) );
		if(p_targetClass != "")
			writer.WriteAttributeString( "targetClass" ,ZoeHelper .Att_ToString(p_targetClass) );
		if(p_targetMember != "")
			writer.WriteAttributeString( "targetMember" ,ZoeHelper .Att_ToString(p_targetMember) );
		if(p_targetClassExternalName != "")
			writer.WriteAttributeString( "targetClassExternalName" ,ZoeHelper .Att_ToString(p_targetClassExternalName) );
		if(p_targetMemberExternalName != "")
			writer.WriteAttributeString( "targetMemberExternalName" ,ZoeHelper .Att_ToString(p_targetMemberExternalName) );
		if(p_ldxplcMods != "")
			writer.WriteAttributeString( "ldxplcMods" ,ZoeHelper .Att_ToString(p_ldxplcMods) );
		if(p_ignoreforsubprogram != false)
			writer.WriteAttributeString( "ignoreforsubprogram" ,ZoeHelper .Att_ToString(p_ignoreforsubprogram) );
		if(p_evaluateBlock != false)
			writer.WriteAttributeString( "evaluateBlock" ,ZoeHelper .Att_ToString(p_evaluateBlock) );
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
		if(p_l!=null)if(!p_l.Write(writer))result=false;
		if(p_args!=null)if(!p_args.Write(writer))result=false;
		if(p_bk!=null)if(!p_bk.Write(writer))result=false;
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
					case "targetClass":
						this.set_targetClass(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "targetMember":
						this.set_targetMember(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "targetClassExternalName":
						this.set_targetClassExternalName(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "targetMemberExternalName":
						this.set_targetMemberExternalName(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "ldxplcMods":
						this.set_ldxplcMods(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "ignoreforsubprogram":
						this.set_ignoreforsubprogram(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "evaluateBlock":
						this.set_evaluateBlock(ZoeHelper .StringAtt_To_BOOL(reader.Value));
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
		this.p_l=null;
		this.p_args=null;
		this.p_bk=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "l":
						tempNode = new XplExpression();
						tempNode.Read(reader);
						if(this.get_l()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_l((XplExpression)tempNode);
						break;
					case "args":
						tempNode = new XplExpressionlist();
						tempNode.Read(reader);
						if(this.get_args()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_args((XplExpressionlist)tempNode);
						break;
					case "bk":
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						if(this.get_bk()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_bk((XplFunctionBody)tempNode);
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
		writer.Write( p_name );
		writer.Write( p_targetClass );
		writer.Write( p_targetMember );
		writer.Write( p_targetClassExternalName );
		writer.Write( p_targetMemberExternalName );
		writer.Write( p_ldxplcMods );
		writer.Write( p_ignoreforsubprogram );
		writer.Write( p_evaluateBlock );
		writer.Write( p_doc );
		writer.Write( p_helpURL );
		writer.Write( p_ldsrc );
		writer.Write( p_iny );
		writer.Write( p_inydata );
		writer.Write( p_inyby );
		writer.Write( p_lddata );
		//Escribo recursivamente cada elemento hijo
		if(p_l!=null){
			writer.Write((int)1);
			if(!p_l.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_args!=null){
			writer.Write((int)1);
			if(!p_args.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_bk!=null){
			writer.Write((int)1);
			if(!p_bk.BinaryWrite(writer))result=false;
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
		p_targetClass = reader.ReadString();
		p_targetMember = reader.ReadString();
		p_targetClassExternalName = reader.ReadString();
		p_targetMemberExternalName = reader.ReadString();
		p_ldxplcMods = reader.ReadString();
		p_ignoreforsubprogram = reader.ReadBoolean();
		p_evaluateBlock = reader.ReadBoolean();
		p_doc = reader.ReadString();
		p_helpURL = reader.ReadString();
		p_ldsrc = reader.ReadString();
		p_iny = reader.ReadBoolean();
		p_inydata = reader.ReadString();
		p_inyby = reader.ReadString();
		p_lddata = reader.ReadString();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_l = (XplExpression)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_args = (XplExpressionlist)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_bk = (XplFunctionBody)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplFunctioncall operator +(XplFunctioncall arg1, XplNode arg2)
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
public static XplFunctioncall operator +(XplFunctioncall arg1, XplNodeList arg2)
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
	public string get_targetClass(){
		return p_targetClass;
	}
	public string get_targetMember(){
		return p_targetMember;
	}
	public string get_targetClassExternalName(){
		return p_targetClassExternalName;
	}
	public string get_targetMemberExternalName(){
		return p_targetMemberExternalName;
	}
	public string get_ldxplcMods(){
		return p_ldxplcMods;
	}
	public bool get_ignoreforsubprogram(){
		return p_ignoreforsubprogram;
	}
	public bool get_evaluateBlock(){
		return p_evaluateBlock;
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
	public XplExpression get_l(){
		return p_l;
	}
	public XplExpressionlist get_args(){
		return p_args;
	}
	public XplFunctionBody get_bk(){
		return p_bk;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[15];
		ret[0] = "name";
		ret[1] = "targetClass";
		ret[2] = "targetMember";
		ret[3] = "targetClassExternalName";
		ret[4] = "targetMemberExternalName";
		ret[5] = "ldxplcMods";
		ret[6] = "ignoreforsubprogram";
		ret[7] = "evaluateBlock";
		ret[8] = "doc";
		ret[9] = "helpURL";
		ret[10] = "ldsrc";
		ret[11] = "iny";
		ret[12] = "inydata";
		ret[13] = "inyby";
		ret[14] = "lddata";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="name") return p_name.ToString();
		if (attributeName=="targetClass") return p_targetClass.ToString();
		if (attributeName=="targetMember") return p_targetMember.ToString();
		if (attributeName=="targetClassExternalName") return p_targetClassExternalName.ToString();
		if (attributeName=="targetMemberExternalName") return p_targetMemberExternalName.ToString();
		if (attributeName=="ldxplcMods") return p_ldxplcMods.ToString();
		if (attributeName=="ignoreforsubprogram") return p_ignoreforsubprogram.ToString();
		if (attributeName=="evaluateBlock") return p_evaluateBlock.ToString();
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
		list.InsertAtEnd(p_l);
		list.InsertAtEnd(p_args);
		list.InsertAtEnd(p_bk);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_name(string new_name){
		string back_name = p_name;
		p_name = new_name;
		return back_name;
	}
	public string set_targetClass(string new_targetClass){
		string back_targetClass = p_targetClass;
		p_targetClass = new_targetClass;
		return back_targetClass;
	}
	public string set_targetMember(string new_targetMember){
		string back_targetMember = p_targetMember;
		p_targetMember = new_targetMember;
		return back_targetMember;
	}
	public string set_targetClassExternalName(string new_targetClassExternalName){
		string back_targetClassExternalName = p_targetClassExternalName;
		p_targetClassExternalName = new_targetClassExternalName;
		return back_targetClassExternalName;
	}
	public string set_targetMemberExternalName(string new_targetMemberExternalName){
		string back_targetMemberExternalName = p_targetMemberExternalName;
		p_targetMemberExternalName = new_targetMemberExternalName;
		return back_targetMemberExternalName;
	}
	public string set_ldxplcMods(string new_ldxplcMods){
		string back_ldxplcMods = p_ldxplcMods;
		p_ldxplcMods = new_ldxplcMods;
		return back_ldxplcMods;
	}
	public bool set_ignoreforsubprogram(bool new_ignoreforsubprogram){
		bool back_ignoreforsubprogram = p_ignoreforsubprogram;
		p_ignoreforsubprogram = new_ignoreforsubprogram;
		return back_ignoreforsubprogram;
	}
	public bool set_evaluateBlock(bool new_evaluateBlock){
		bool back_evaluateBlock = p_evaluateBlock;
		p_evaluateBlock = new_evaluateBlock;
		return back_evaluateBlock;
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
	public XplExpression set_l(XplExpression new_l){
		XplExpression back_l = p_l;
		p_l = new_l;
		if(p_l!=null){
			p_l.set_ElementName("l");
			p_l.set_Parent(this);
		}
		return back_l;
	}
	public XplExpressionlist set_args(XplExpressionlist new_args){
		XplExpressionlist back_args = p_args;
		p_args = new_args;
		if(p_args!=null){
			p_args.set_ElementName("args");
			p_args.set_Parent(this);
		}
		return back_args;
	}
	public XplFunctionBody set_bk(XplFunctionBody new_bk){
		XplFunctionBody back_bk = p_bk;
		p_bk = new_bk;
		if(p_bk!=null){
			p_bk.set_ElementName("bk");
			p_bk.set_Parent(this);
		}
		return back_bk;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplExpression new_l(){
		XplExpression node = new XplExpression();
		node.set_ElementName("l");
		return node;
	}
	static public XplExpressionlist new_args(){
		XplExpressionlist node = new XplExpressionlist();
		node.set_ElementName("args");
		return node;
	}
	static public XplFunctionBody new_bk(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_ElementName("bk");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

