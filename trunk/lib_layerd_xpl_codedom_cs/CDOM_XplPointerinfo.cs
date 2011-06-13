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
public class XplPointerinfo:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_memberof;
	bool p_const;
	bool p_volatile;
	bool p_ref;
	bool p_removeonvalue;
	#endregion

	#region Region de Constructores Publicos
	public XplPointerinfo(){
		p_memberof = "";
		p_const = false;
		p_volatile = false;
		p_ref = false;
		p_removeonvalue = false;
}
	public XplPointerinfo(bool n_const, bool n_volatile, bool n_ref, bool n_removeonvalue){
		p_memberof = "";
		p_const = false;
		p_volatile = false;
		p_ref = false;
		p_removeonvalue = false;
		set_const(n_const);
		set_volatile(n_volatile);
		set_ref(n_ref);
		set_removeonvalue(n_removeonvalue);
	}
	public XplPointerinfo(string n_memberof, bool n_const, bool n_volatile, bool n_ref, bool n_removeonvalue){
		set_memberof(n_memberof);
		set_const(n_const);
		set_volatile(n_volatile);
		set_ref(n_ref);
		set_removeonvalue(n_removeonvalue);
	}
	#endregion

	#region Destructor
/*	public ~XplPointerinfo(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplPointerinfo copy = new XplPointerinfo();
		copy.set_memberof(this.p_memberof);
		copy.set_const(this.p_const);
		copy.set_volatile(this.p_volatile);
		copy.set_ref(this.p_ref);
		copy.set_removeonvalue(this.p_removeonvalue);
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplPointerinfo;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_memberof != "")
			writer.WriteAttributeString( "memberof" ,ZoeHelper .Att_ToString(p_memberof) );
		if(p_const != false)
			writer.WriteAttributeString( "const" ,ZoeHelper .Att_ToString(p_const) );
		if(p_volatile != false)
			writer.WriteAttributeString( "volatile" ,ZoeHelper .Att_ToString(p_volatile) );
		if(p_ref != false)
			writer.WriteAttributeString( "ref" ,ZoeHelper .Att_ToString(p_ref) );
		if(p_removeonvalue != false)
			writer.WriteAttributeString( "removeonvalue" ,ZoeHelper .Att_ToString(p_removeonvalue) );
		//Escribo recursivamente cada elemento hijo
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
					case "memberof":
						this.set_memberof(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "const":
						this.set_const(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "volatile":
						this.set_volatile(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "ref":
						this.set_ref(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "removeonvalue":
						this.set_removeonvalue(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Atributo '"+reader.Name+"' invalido en elemento '"+this.get_ElementName()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
				case XmlNodeType.Text:
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".No se esperaba texto o elemento hijo en este nodo.");
				case XmlNodeType.EndElement:
					break;
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
		writer.Write((int) 126 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_memberof );
		writer.Write( p_const );
		writer.Write( p_volatile );
		writer.Write( p_ref );
		writer.Write( p_removeonvalue );
		//Escribo recursivamente cada elemento hijo
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_memberof = reader.ReadString();
		p_const = reader.ReadBoolean();
		p_volatile = reader.ReadBoolean();
		p_ref = reader.ReadBoolean();
		p_removeonvalue = reader.ReadBoolean();
		//Lectura de Elementos
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplPointerinfo operator +(XplPointerinfo arg1, XplNode arg2)
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
public static XplPointerinfo operator +(XplPointerinfo arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_memberof(){
		return p_memberof;
	}
	public bool get_const(){
		return p_const;
	}
	public bool get_volatile(){
		return p_volatile;
	}
	public bool get_ref(){
		return p_ref;
	}
	public bool get_removeonvalue(){
		return p_removeonvalue;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[5];
		ret[0] = "memberof";
		ret[1] = "const";
		ret[2] = "volatile";
		ret[3] = "ref";
		ret[4] = "removeonvalue";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="memberof") return p_memberof.ToString();
		if (attributeName=="const") return p_const.ToString();
		if (attributeName=="volatile") return p_volatile.ToString();
		if (attributeName=="ref") return p_ref.ToString();
		if (attributeName=="removeonvalue") return p_removeonvalue.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_memberof(string new_memberof){
		string back_memberof = p_memberof;
		p_memberof = new_memberof;
		return back_memberof;
	}
	public bool set_const(bool new_const){
		bool back_const = p_const;
		p_const = new_const;
		return back_const;
	}
	public bool set_volatile(bool new_volatile){
		bool back_volatile = p_volatile;
		p_volatile = new_volatile;
		return back_volatile;
	}
	public bool set_ref(bool new_ref){
		bool back_ref = p_ref;
		p_ref = new_ref;
		return back_ref;
	}
	public bool set_removeonvalue(bool new_removeonvalue){
		bool back_removeonvalue = p_removeonvalue;
		p_removeonvalue = new_removeonvalue;
		return back_removeonvalue;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

