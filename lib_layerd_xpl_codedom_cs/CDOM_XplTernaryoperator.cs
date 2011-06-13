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
public class XplTernaryoperator:  XplNode{

	#region Variables privadas para atributos y elementos
	XplTernaryoperators_enum p_op;
	string p_targetClass;
	string p_targetMember;
	string p_targetClassExternalName;
	string p_targetMemberExternalName;
	bool p_ignoreforsubprogram;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplExpression p_o1;
	XplExpression p_o2;
	XplExpression p_o3;
	#endregion

	#region Region de Constructores Publicos
	public XplTernaryoperator(){
		p_op = (XplTernaryoperators_enum)0;
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ignoreforsubprogram = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_o1=null;
		p_o2=null;
		p_o3=null;
}
	public XplTernaryoperator(XplTernaryoperators_enum n_op, bool n_ignoreforsubprogram){
		p_op = (XplTernaryoperators_enum)0;
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ignoreforsubprogram = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_op(n_op);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		p_o1=null;
		p_o2=null;
		p_o3=null;
	}
	public XplTernaryoperator(XplExpression n_o1, XplExpression n_o2, XplExpression n_o3){
		p_op = (XplTernaryoperators_enum)0;
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ignoreforsubprogram = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_o1=null;
		p_o2=null;
		p_o3=null;
		set_o1(n_o1);
		set_o2(n_o2);
		set_o3(n_o3);
	}
	public XplTernaryoperator(XplTernaryoperators_enum n_op, bool n_ignoreforsubprogram, XplExpression n_o1, XplExpression n_o2, XplExpression n_o3){
		p_op = (XplTernaryoperators_enum)0;
		p_targetClass = "";
		p_targetMember = "";
		p_targetClassExternalName = "";
		p_targetMemberExternalName = "";
		p_ignoreforsubprogram = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_op(n_op);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		p_o1=null;
		p_o2=null;
		p_o3=null;
		set_o1(n_o1);
		set_o2(n_o2);
		set_o3(n_o3);
	}
	public XplTernaryoperator(XplTernaryoperators_enum n_op, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
		set_op(n_op);
		set_targetClass(n_targetClass);
		set_targetMember(n_targetMember);
		set_targetClassExternalName(n_targetClassExternalName);
		set_targetMemberExternalName(n_targetMemberExternalName);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_o1=null;
		p_o2=null;
		p_o3=null;
	}
	public XplTernaryoperator(XplTernaryoperators_enum n_op, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression n_o1, XplExpression n_o2, XplExpression n_o3){
		set_op(n_op);
		set_targetClass(n_targetClass);
		set_targetMember(n_targetMember);
		set_targetClassExternalName(n_targetClassExternalName);
		set_targetMemberExternalName(n_targetMemberExternalName);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_op(n_op);
		set_ignoreforsubprogram(n_ignoreforsubprogram);
		p_o1=null;
		p_o2=null;
		p_o3=null;
	}
	#endregion

	#region Destructor
/*	public ~XplTernaryoperator(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplTernaryoperator copy = new XplTernaryoperator();
		copy.set_op(this.p_op);
		copy.set_targetClass(this.p_targetClass);
		copy.set_targetMember(this.p_targetMember);
		copy.set_targetClassExternalName(this.p_targetClassExternalName);
		copy.set_targetMemberExternalName(this.p_targetMemberExternalName);
		copy.set_ignoreforsubprogram(this.p_ignoreforsubprogram);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_o1!=null)copy.set_o1((XplExpression)p_o1.Clone());
		if(p_o2!=null)copy.set_o2((XplExpression)p_o2.Clone());
		if(p_o3!=null)copy.set_o3((XplExpression)p_o3.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplTernaryoperator;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_op != (XplTernaryoperators_enum)0)
			writer.WriteAttributeString( "op" , CodeDOM_STV.XPLTERNARYOPERATORS_ENUM[(int)p_op] );
		if(p_targetClass != "")
			writer.WriteAttributeString( "targetClass" ,ZoeHelper .Att_ToString(p_targetClass) );
		if(p_targetMember != "")
			writer.WriteAttributeString( "targetMember" ,ZoeHelper .Att_ToString(p_targetMember) );
		if(p_targetClassExternalName != "")
			writer.WriteAttributeString( "targetClassExternalName" ,ZoeHelper .Att_ToString(p_targetClassExternalName) );
		if(p_targetMemberExternalName != "")
			writer.WriteAttributeString( "targetMemberExternalName" ,ZoeHelper .Att_ToString(p_targetMemberExternalName) );
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
		if(p_o1!=null)if(!p_o1.Write(writer))result=false;
		if(p_o2!=null)if(!p_o2.Write(writer))result=false;
		if(p_o3!=null)if(!p_o3.Write(writer))result=false;
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
					case "op":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLTERNARYOPERATORS_ENUM){
							if(str==tmpStr){this.set_op((XplTernaryoperators_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'op' en elemento '"+this.get_ElementName()+"'.");
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
		this.p_o1=null;
		this.p_o2=null;
		this.p_o3=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "o1":
						tempNode = new XplExpression();
						tempNode.Read(reader);
						if(this.get_o1()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_o1((XplExpression)tempNode);
						break;
					case "o2":
						tempNode = new XplExpression();
						tempNode.Read(reader);
						if(this.get_o2()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_o2((XplExpression)tempNode);
						break;
					case "o3":
						tempNode = new XplExpression();
						tempNode.Read(reader);
						if(this.get_o3()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_o3((XplExpression)tempNode);
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
		writer.Write((int) 116 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( (int)p_op );
		writer.Write( p_targetClass );
		writer.Write( p_targetMember );
		writer.Write( p_targetClassExternalName );
		writer.Write( p_targetMemberExternalName );
		writer.Write( p_ignoreforsubprogram );
		writer.Write( p_doc );
		writer.Write( p_helpURL );
		writer.Write( p_ldsrc );
		writer.Write( p_iny );
		writer.Write( p_inydata );
		writer.Write( p_inyby );
		writer.Write( p_lddata );
		//Escribo recursivamente cada elemento hijo
		if(p_o1!=null){
			writer.Write((int)1);
			if(!p_o1.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_o2!=null){
			writer.Write((int)1);
			if(!p_o2.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_o3!=null){
			writer.Write((int)1);
			if(!p_o3.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_op = (XplTernaryoperators_enum)reader.ReadInt32();
		p_targetClass = reader.ReadString();
		p_targetMember = reader.ReadString();
		p_targetClassExternalName = reader.ReadString();
		p_targetMemberExternalName = reader.ReadString();
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
			p_o1 = (XplExpression)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_o2 = (XplExpression)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_o3 = (XplExpression)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplTernaryoperator operator +(XplTernaryoperator arg1, XplNode arg2)
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
public static XplTernaryoperator operator +(XplTernaryoperator arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public XplTernaryoperators_enum get_op(){
		return p_op;
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
	public XplExpression get_o1(){
		return p_o1;
	}
	public XplExpression get_o2(){
		return p_o2;
	}
	public XplExpression get_o3(){
		return p_o3;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[13];
		ret[0] = "op";
		ret[1] = "targetClass";
		ret[2] = "targetMember";
		ret[3] = "targetClassExternalName";
		ret[4] = "targetMemberExternalName";
		ret[5] = "ignoreforsubprogram";
		ret[6] = "doc";
		ret[7] = "helpURL";
		ret[8] = "ldsrc";
		ret[9] = "iny";
		ret[10] = "inydata";
		ret[11] = "inyby";
		ret[12] = "lddata";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="op") return p_op.ToString();
		if (attributeName=="targetClass") return p_targetClass.ToString();
		if (attributeName=="targetMember") return p_targetMember.ToString();
		if (attributeName=="targetClassExternalName") return p_targetClassExternalName.ToString();
		if (attributeName=="targetMemberExternalName") return p_targetMemberExternalName.ToString();
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
		list.InsertAtEnd(p_o1);
		list.InsertAtEnd(p_o2);
		list.InsertAtEnd(p_o3);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public XplTernaryoperators_enum set_op(XplTernaryoperators_enum new_op){
		XplTernaryoperators_enum back_op = p_op;
		p_op = new_op;
		return back_op;
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
	public XplExpression set_o1(XplExpression new_o1){
		XplExpression back_o1 = p_o1;
		p_o1 = new_o1;
		if(p_o1!=null){
			p_o1.set_ElementName("o1");
			p_o1.set_Parent(this);
		}
		return back_o1;
	}
	public XplExpression set_o2(XplExpression new_o2){
		XplExpression back_o2 = p_o2;
		p_o2 = new_o2;
		if(p_o2!=null){
			p_o2.set_ElementName("o2");
			p_o2.set_Parent(this);
		}
		return back_o2;
	}
	public XplExpression set_o3(XplExpression new_o3){
		XplExpression back_o3 = p_o3;
		p_o3 = new_o3;
		if(p_o3!=null){
			p_o3.set_ElementName("o3");
			p_o3.set_Parent(this);
		}
		return back_o3;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplExpression new_o1(){
		XplExpression node = new XplExpression();
		node.set_ElementName("o1");
		return node;
	}
	static public XplExpression new_o2(){
		XplExpression node = new XplExpression();
		node.set_ElementName("o2");
		return node;
	}
	static public XplExpression new_o3(){
		XplExpression node = new XplExpression();
		node.set_ElementName("o3");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

