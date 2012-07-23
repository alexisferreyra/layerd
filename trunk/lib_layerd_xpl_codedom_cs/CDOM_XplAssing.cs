/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 8/11/2011 4:27:19 PM
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
public class XplAssing:  XplNode{

	#region Variables privadas para atributos y elementos
	XplAssingop_enum p_operation;
	string p_targetClass;
	string p_targetMember;
	bool p_ignoreforsubprogram;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplExpression p_l;
	XplExpression p_r;
	#endregion

	#region Region de Constructores Publicos
	public XplAssing(){
		p_operation = XplAssingop_enum.NONE;
		p_targetClass = "";
		p_targetMember = "";
		p_ignoreforsubprogram = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_l=null;
		p_r=null;
}
	public XplAssing(XplAssingop_enum n_operation, bool n_ignoreforsubprogram){
		p_operation = XplAssingop_enum.NONE;
		p_targetClass = "";
		p_targetMember = "";
		p_ignoreforsubprogram = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_operation(n_operation);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		p_l=null;
		p_r=null;
	}
	public XplAssing(XplExpression n_l, XplExpression n_r){
		p_operation = XplAssingop_enum.NONE;
		p_targetClass = "";
		p_targetMember = "";
		p_ignoreforsubprogram = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_l=null;
		p_r=null;
		set_l(n_l);
		set_r(n_r);
	}
	public XplAssing(XplAssingop_enum n_operation, bool n_ignoreforsubprogram, XplExpression n_l, XplExpression n_r){
		p_operation = XplAssingop_enum.NONE;
		p_targetClass = "";
		p_targetMember = "";
		p_ignoreforsubprogram = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_operation(n_operation);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		p_l=null;
		p_r=null;
		set_l(n_l);
		set_r(n_r);
	}
	public XplAssing(XplAssingop_enum n_operation, string n_targetClass, string n_targetMember, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
		set_operation(n_operation);
		set_targetClass(n_targetClass);
		set_targetMember(n_targetMember);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_l=null;
		p_r=null;
	}
	public XplAssing(XplAssingop_enum n_operation, string n_targetClass, string n_targetMember, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression n_l, XplExpression n_r){
		set_operation(n_operation);
		set_targetClass(n_targetClass);
		set_targetMember(n_targetMember);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_operation(n_operation);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		p_l=null;
		p_r=null;
	}
	#endregion

	#region Destructor
/*	public ~XplAssing(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplAssing copy = new XplAssing();
		copy.set_operation(this.p_operation);
		copy.set_targetClass(this.p_targetClass);
		copy.set_targetMember(this.p_targetMember);
		copy.set_ignoreforsubprogram(this.p_ignoreforsubprogram);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_l!=null)copy.set_l((XplExpression)p_l.Clone());
		if(p_r!=null)copy.set_r((XplExpression)p_r.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplAssing;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_operation != XplAssingop_enum.NONE)
			writer.WriteAttributeString( "operation" , CodeDOM_STV.XPLASSINGOP_ENUM[(int)p_operation] );
		if(p_targetClass != "")
			writer.WriteAttributeString( "targetClass" ,ZoeHelper .Att_ToString(p_targetClass) );
		if(p_targetMember != "")
			writer.WriteAttributeString( "targetMember" ,ZoeHelper .Att_ToString(p_targetMember) );
		if(p_ignoreforsubprogram != false)
			writer.WriteAttributeString( "ignoreforsubprogram" ,ZoeHelper .Att_ToString(p_ignoreforsubprogram) );
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
		if(p_r!=null)if(!p_r.Write(writer))result=false;
		//Cierro el elemento
		writer.WriteEndElement();
		return result;
	}

	public override XplNode Read(XplReader reader){
		this.set_ElementName( reader.Name );
		//Lectura de Atributos
		if( reader.HasAttributes ){
			string tmpStr="";bool flag=false;int count=0;
			for(int i=0; i < reader.AttributeCount ; i++){
				reader.MoveToAttribute(i);
				switch(reader.Name){
					case "operation":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLASSINGOP_ENUM){
							if(str==tmpStr){this.set_operation((XplAssingop_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'operation' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "targetClass":
						this.set_targetClass(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "targetMember":
						this.set_targetMember(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "ignoreforsubprogram":
						this.set_ignoreforsubprogram(ZoeHelper .StringAtt_To_BOOL(reader.Value));
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
		this.p_r=null;
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
					case "r":
						tempNode = new XplExpression();
						tempNode.Read(reader);
						if(this.get_r()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_r((XplExpression)tempNode);
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
		writer.Write((int) 109 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( (int)p_operation );
		writer.Write( p_targetClass );
		writer.Write( p_targetMember );
		writer.Write( p_ignoreforsubprogram );
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
		if(p_r!=null){
			writer.Write((int)1);
			if(!p_r.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_operation = (XplAssingop_enum)reader.ReadInt32();
		p_targetClass = reader.ReadString();
		p_targetMember = reader.ReadString();
		p_ignoreforsubprogram = reader.ReadBoolean();
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
			p_r = (XplExpression)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplAssing operator +(XplAssing arg1, XplNode arg2)
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
public static XplAssing operator +(XplAssing arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public XplAssingop_enum get_operation(){
		return p_operation;
	}
	public string get_targetClass(){
		return p_targetClass;
	}
	public string get_targetMember(){
		return p_targetMember;
	}
	public bool get_ignoreforsubprogram(){
		return p_ignoreforsubprogram;
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
	public XplExpression get_r(){
		return p_r;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[11];
		ret[0] = "operation";
		ret[1] = "targetClass";
		ret[2] = "targetMember";
		ret[3] = "ignoreforsubprogram";
		ret[4] = "doc";
		ret[5] = "helpURL";
		ret[6] = "ldsrc";
		ret[7] = "iny";
		ret[8] = "inydata";
		ret[9] = "inyby";
		ret[10] = "lddata";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="operation") return p_operation.ToString();
		if (attributeName=="targetClass") return p_targetClass.ToString();
		if (attributeName=="targetMember") return p_targetMember.ToString();
		if (attributeName=="ignoreforsubprogram") return p_ignoreforsubprogram.ToString();
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
		list.InsertAtEnd(p_r);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public XplAssingop_enum set_operation(XplAssingop_enum new_operation){
		XplAssingop_enum back_operation = p_operation;
		p_operation = new_operation;
		return back_operation;
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
	public bool set_ignoreforsubprogram(bool new_ignoreforsubprogram){
		bool back_ignoreforsubprogram = p_ignoreforsubprogram;
		p_ignoreforsubprogram = new_ignoreforsubprogram;
		return back_ignoreforsubprogram;
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
	public XplExpression set_r(XplExpression new_r){
		XplExpression back_r = p_r;
		p_r = new_r;
		if(p_r!=null){
			p_r.set_ElementName("r");
			p_r.set_Parent(this);
		}
		return back_r;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplExpression new_l(){
		XplExpression node = new XplExpression();
		node.set_ElementName("l");
		return node;
	}
	static public XplExpression new_r(){
		XplExpression node = new XplExpression();
		node.set_ElementName("r");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

