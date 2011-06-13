/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 3/2/2010 9:11:44 PM
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
public class ClassfactoryData:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_typeFullName;
	bool p_isInterface;
	bool p_isInteractive;
	bool p_active;
	string p_moduleFileName;
	string p_platforms;
	string p_zoeDocFileName;
	#endregion

	#region Region de Constructores Publicos
	public ClassfactoryData(){
		p_typeFullName = "";
		p_isInterface = false;
		p_isInteractive = false;
		p_active = true;
		p_moduleFileName = "";
		p_platforms = "";
		p_zoeDocFileName = "";
}
	public ClassfactoryData(string n_typeFullName, bool n_isInterface, bool n_isInteractive, bool n_active, string n_moduleFileName, string n_zoeDocFileName){
		p_typeFullName = "";
		p_isInterface = false;
		p_isInteractive = false;
		p_active = true;
		p_moduleFileName = "";
		p_platforms = "";
		p_zoeDocFileName = "";
		set_typeFullName(n_typeFullName);
		set_isInterface(n_isInterface);
		set_isInteractive(n_isInteractive);
		set_active(n_active);
		set_moduleFileName(n_moduleFileName);
		set_zoeDocFileName(n_zoeDocFileName);
	}
	public ClassfactoryData(string n_typeFullName, bool n_isInterface, bool n_isInteractive, bool n_active, string n_moduleFileName, string n_platforms, string n_zoeDocFileName){
		set_typeFullName(n_typeFullName);
		set_isInterface(n_isInterface);
		set_isInteractive(n_isInteractive);
		set_active(n_active);
		set_moduleFileName(n_moduleFileName);
		set_platforms(n_platforms);
		set_zoeDocFileName(n_zoeDocFileName);
	}
	#endregion

	#region Destructor
/*	public ~ClassfactoryData(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		ClassfactoryData copy = new ClassfactoryData();
		copy.set_typeFullName(this.p_typeFullName);
		copy.set_isInterface(this.p_isInterface);
		copy.set_isInteractive(this.p_isInteractive);
		copy.set_active(this.p_active);
		copy.set_moduleFileName(this.p_moduleFileName);
		copy.set_platforms(this.p_platforms);
		copy.set_zoeDocFileName(this.p_zoeDocFileName);
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.ClassfactoryData;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_typeFullName != "")
			writer.WriteAttributeString( "typeFullName" ,ZoeHelper .Att_ToString(p_typeFullName) );
		if(p_isInterface != false)
			writer.WriteAttributeString( "isInterface" ,ZoeHelper .Att_ToString(p_isInterface) );
		if(p_isInteractive != false)
			writer.WriteAttributeString( "isInteractive" ,ZoeHelper .Att_ToString(p_isInteractive) );
		if(p_active != true)
			writer.WriteAttributeString( "active" ,ZoeHelper .Att_ToString(p_active) );
		if(p_moduleFileName != "")
			writer.WriteAttributeString( "moduleFileName" ,ZoeHelper .Att_ToString(p_moduleFileName) );
		if(p_platforms != "")
			writer.WriteAttributeString( "platforms" ,ZoeHelper .Att_ToString(p_platforms) );
		if(p_zoeDocFileName != "")
			writer.WriteAttributeString( "zoeDocFileName" ,ZoeHelper .Att_ToString(p_zoeDocFileName) );
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
					case "typeFullName":
						this.set_typeFullName(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "isInterface":
						this.set_isInterface(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "isInteractive":
						this.set_isInteractive(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "active":
						this.set_active(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "moduleFileName":
						this.set_moduleFileName(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "platforms":
						this.set_platforms(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "zoeDocFileName":
						this.set_zoeDocFileName(ZoeHelper .StringAtt_To_STRING(reader.Value));
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
		writer.Write((int) 167 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_typeFullName );
		writer.Write( p_isInterface );
		writer.Write( p_isInteractive );
		writer.Write( p_active );
		writer.Write( p_moduleFileName );
		writer.Write( p_platforms );
		writer.Write( p_zoeDocFileName );
		//Escribo recursivamente cada elemento hijo
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_typeFullName = reader.ReadString();
		p_isInterface = reader.ReadBoolean();
		p_isInteractive = reader.ReadBoolean();
		p_active = reader.ReadBoolean();
		p_moduleFileName = reader.ReadString();
		p_platforms = reader.ReadString();
		p_zoeDocFileName = reader.ReadString();
		//Lectura de Elementos
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static ClassfactoryData operator +(ClassfactoryData arg1, XplNode arg2)
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
public static ClassfactoryData operator +(ClassfactoryData arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_typeFullName(){
		return p_typeFullName;
	}
	public bool get_isInterface(){
		return p_isInterface;
	}
	public bool get_isInteractive(){
		return p_isInteractive;
	}
	public bool get_active(){
		return p_active;
	}
	public string get_moduleFileName(){
		return p_moduleFileName;
	}
	public string get_platforms(){
		return p_platforms;
	}
	public string get_zoeDocFileName(){
		return p_zoeDocFileName;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[7];
		ret[0] = "typeFullName";
		ret[1] = "isInterface";
		ret[2] = "isInteractive";
		ret[3] = "active";
		ret[4] = "moduleFileName";
		ret[5] = "platforms";
		ret[6] = "zoeDocFileName";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="typeFullName") return p_typeFullName.ToString();
		if (attributeName=="isInterface") return p_isInterface.ToString();
		if (attributeName=="isInteractive") return p_isInteractive.ToString();
		if (attributeName=="active") return p_active.ToString();
		if (attributeName=="moduleFileName") return p_moduleFileName.ToString();
		if (attributeName=="platforms") return p_platforms.ToString();
		if (attributeName=="zoeDocFileName") return p_zoeDocFileName.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_typeFullName(string new_typeFullName){
		string back_typeFullName = p_typeFullName;
		p_typeFullName = new_typeFullName;
		return back_typeFullName;
	}
	public bool set_isInterface(bool new_isInterface){
		bool back_isInterface = p_isInterface;
		p_isInterface = new_isInterface;
		return back_isInterface;
	}
	public bool set_isInteractive(bool new_isInteractive){
		bool back_isInteractive = p_isInteractive;
		p_isInteractive = new_isInteractive;
		return back_isInteractive;
	}
	public bool set_active(bool new_active){
		bool back_active = p_active;
		p_active = new_active;
		return back_active;
	}
	public string set_moduleFileName(string new_moduleFileName){
		string back_moduleFileName = p_moduleFileName;
		p_moduleFileName = new_moduleFileName;
		return back_moduleFileName;
	}
	public string set_platforms(string new_platforms){
		string back_platforms = p_platforms;
		p_platforms = new_platforms;
		return back_platforms;
	}
	public string set_zoeDocFileName(string new_zoeDocFileName){
		string back_zoeDocFileName = p_zoeDocFileName;
		p_zoeDocFileName = new_zoeDocFileName;
		return back_zoeDocFileName;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

