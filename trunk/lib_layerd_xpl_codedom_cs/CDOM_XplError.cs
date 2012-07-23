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
public class XplError:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_str;
	int p_level;
	string p_sourcefile;
	string p_sourcepos;
	XplErrorsourcetype_enum p_sourceType;
	#endregion

	#region Region de Constructores Publicos
	public XplError(){
		p_str = "";
		p_level = 1;
		p_sourcefile = "";
		p_sourcepos = "";
		p_sourceType = XplErrorsourcetype_enum.ZOE_DOC;
}
	public XplError(string n_str, int n_level, XplErrorsourcetype_enum n_sourceType){
		p_str = "";
		p_level = 1;
		p_sourcefile = "";
		p_sourcepos = "";
		p_sourceType = XplErrorsourcetype_enum.ZOE_DOC;
		set_str(n_str);
		set_level(n_level);
		set_sourceType(n_sourceType);
	}
	public XplError(string n_str, int n_level, string n_sourcefile, string n_sourcepos, XplErrorsourcetype_enum n_sourceType){
		set_str(n_str);
		set_level(n_level);
		set_sourcefile(n_sourcefile);
		set_sourcepos(n_sourcepos);
		set_sourceType(n_sourceType);
	}
	#endregion

	#region Destructor
/*	public ~XplError(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplError copy = new XplError();
		copy.set_str(this.p_str);
		copy.set_level(this.p_level);
		copy.set_sourcefile(this.p_sourcefile);
		copy.set_sourcepos(this.p_sourcepos);
		copy.set_sourceType(this.p_sourceType);
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplError;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_str != "")
			writer.WriteAttributeString( "str" ,ZoeHelper .Att_ToString(p_str) );
		if(p_level != 1)
			writer.WriteAttributeString( "level" ,ZoeHelper .Att_ToString(p_level) );
		if(p_sourcefile != "")
			writer.WriteAttributeString( "sourcefile" ,ZoeHelper .Att_ToString(p_sourcefile) );
		if(p_sourcepos != "")
			writer.WriteAttributeString( "sourcepos" ,ZoeHelper .Att_ToString(p_sourcepos) );
		if(p_sourceType != XplErrorsourcetype_enum.ZOE_DOC)
			writer.WriteAttributeString( "sourceType" , CodeDOM_STV.XPLERRORSOURCETYPE_ENUM[(int)p_sourceType] );
		//Escribo recursivamente cada elemento hijo
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
					case "str":
						this.set_str(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "level":
						this.set_level(ZoeHelper .StringAtt_To_INT(reader.Value));
						break;
					case "sourcefile":
						this.set_sourcefile(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "sourcepos":
						this.set_sourcepos(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "sourceType":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLERRORSOURCETYPE_ENUM){
							if(str==tmpStr){this.set_sourceType((XplErrorsourcetype_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'sourceType' en elemento '"+this.get_ElementName()+"'.");
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
		writer.Write((int) 143 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_str );
		writer.Write( p_level );
		writer.Write( p_sourcefile );
		writer.Write( p_sourcepos );
		writer.Write( (int)p_sourceType );
		//Escribo recursivamente cada elemento hijo
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_str = reader.ReadString();
		p_level = reader.ReadInt32();
		p_sourcefile = reader.ReadString();
		p_sourcepos = reader.ReadString();
		p_sourceType = (XplErrorsourcetype_enum)reader.ReadInt32();
		//Lectura de Elementos
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplError operator +(XplError arg1, XplNode arg2)
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
public static XplError operator +(XplError arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_str(){
		return p_str;
	}
	public int get_level(){
		return p_level;
	}
	public string get_sourcefile(){
		return p_sourcefile;
	}
	public string get_sourcepos(){
		return p_sourcepos;
	}
	public XplErrorsourcetype_enum get_sourceType(){
		return p_sourceType;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[5];
		ret[0] = "str";
		ret[1] = "level";
		ret[2] = "sourcefile";
		ret[3] = "sourcepos";
		ret[4] = "sourceType";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="str") return p_str.ToString();
		if (attributeName=="level") return p_level.ToString();
		if (attributeName=="sourcefile") return p_sourcefile.ToString();
		if (attributeName=="sourcepos") return p_sourcepos.ToString();
		if (attributeName=="sourceType") return p_sourceType.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_str(string new_str){
		string back_str = p_str;
		p_str = new_str;
		return back_str;
	}
	public int set_level(int new_level){
		int back_level = p_level;
		p_level = new_level;
		return back_level;
	}
	public string set_sourcefile(string new_sourcefile){
		string back_sourcefile = p_sourcefile;
		p_sourcefile = new_sourcefile;
		return back_sourcefile;
	}
	public string set_sourcepos(string new_sourcepos){
		string back_sourcepos = p_sourcepos;
		p_sourcepos = new_sourcepos;
		return back_sourcepos;
	}
	public XplErrorsourcetype_enum set_sourceType(XplErrorsourcetype_enum new_sourceType){
		XplErrorsourcetype_enum back_sourceType = p_sourceType;
		p_sourceType = new_sourceType;
		return back_sourceType;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

