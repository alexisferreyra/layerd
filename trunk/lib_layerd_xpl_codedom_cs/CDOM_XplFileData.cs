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
public class XplFileData:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_Autor;
	DateTime p_Date;
	DateTime p_Time;
	string p_Description;
	#endregion

	#region Region de Constructores Publicos
	public XplFileData(){
		p_Autor = "";
		p_Date = DateTime.Parse("01/01/1970");
		p_Time = DateTime.Parse("01/01/1970");
		p_Description = "";
}
	public XplFileData(string n_Autor, DateTime n_Date, DateTime n_Time, string n_Description){
		set_Autor(n_Autor);
		set_Date(n_Date);
		set_Time(n_Time);
		set_Description(n_Description);
	}
	#endregion

	#region Destructor
/*	public ~XplFileData(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplFileData copy = new XplFileData();
		copy.set_Autor(this.p_Autor);
		copy.set_Date(this.p_Date);
		copy.set_Time(this.p_Time);
		copy.set_Description(this.p_Description);
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplFileData;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_Autor != "")
			writer.WriteAttributeString( "Autor" ,ZoeHelper .Att_ToString(p_Autor) );
		if(p_Date != DateTime.Parse("01/01/1970"))
			writer.WriteAttributeString( "Date" ,ZoeHelper .Att_ToString(p_Date) );
		if(p_Time != DateTime.Parse("01/01/1970"))
			writer.WriteAttributeString( "Time" ,ZoeHelper .Att_ToString(p_Time) );
		if(p_Description != "")
			writer.WriteAttributeString( "Description" ,ZoeHelper .Att_ToString(p_Description) );
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
					case "Autor":
						this.set_Autor(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "Date":
						this.set_Date(ZoeHelper .StringAtt_To_DATETIME(reader.Value));
						break;
					case "Time":
						this.set_Time(ZoeHelper .StringAtt_To_DATETIME(reader.Value));
						break;
					case "Description":
						this.set_Description(ZoeHelper .StringAtt_To_STRING(reader.Value));
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
		writer.Write((int) 123 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_Autor );
		writer.Write( p_Date.ToBinary() );
		writer.Write( p_Time.ToBinary() );
		writer.Write( p_Description );
		//Escribo recursivamente cada elemento hijo
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_Autor = reader.ReadString();
		p_Date = DateTime.FromBinary(reader.ReadInt64());
		p_Time = DateTime.FromBinary(reader.ReadInt64());
		p_Description = reader.ReadString();
		//Lectura de Elementos
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplFileData operator +(XplFileData arg1, XplNode arg2)
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
public static XplFileData operator +(XplFileData arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_Autor(){
		return p_Autor;
	}
	public DateTime get_Date(){
		return p_Date;
	}
	public DateTime get_Time(){
		return p_Time;
	}
	public string get_Description(){
		return p_Description;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[4];
		ret[0] = "Autor";
		ret[1] = "Date";
		ret[2] = "Time";
		ret[3] = "Description";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="Autor") return p_Autor.ToString();
		if (attributeName=="Date") return p_Date.ToString();
		if (attributeName=="Time") return p_Time.ToString();
		if (attributeName=="Description") return p_Description.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_Autor(string new_Autor){
		string back_Autor = p_Autor;
		p_Autor = new_Autor;
		return back_Autor;
	}
	public DateTime set_Date(DateTime new_Date){
		DateTime back_Date = p_Date;
		p_Date = new_Date;
		return back_Date;
	}
	public DateTime set_Time(DateTime new_Time){
		DateTime back_Time = p_Time;
		p_Time = new_Time;
		return back_Time;
	}
	public string set_Description(string new_Description){
		string back_Description = p_Description;
		p_Description = new_Description;
		return back_Description;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

