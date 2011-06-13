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
public class XplCopyright:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_copyrightMessage;
	string p_company;
	string p_productName;
	string p_productVersion;
	string p_productLicense;
	string p_description;
	string p_contactInfo;
	#endregion

	#region Region de Constructores Publicos
	public XplCopyright(){
		p_copyrightMessage = "";
		p_company = "";
		p_productName = "";
		p_productVersion = "";
		p_productLicense = "";
		p_description = "";
		p_contactInfo = "";
}
	public XplCopyright(string n_copyrightMessage){
		p_copyrightMessage = "";
		p_company = "";
		p_productName = "";
		p_productVersion = "";
		p_productLicense = "";
		p_description = "";
		p_contactInfo = "";
		set_copyrightMessage(n_copyrightMessage);
	}
	public XplCopyright(string n_copyrightMessage, string n_company, string n_productName, string n_productVersion, string n_productLicense, string n_description, string n_contactInfo){
		set_copyrightMessage(n_copyrightMessage);
		set_company(n_company);
		set_productName(n_productName);
		set_productVersion(n_productVersion);
		set_productLicense(n_productLicense);
		set_description(n_description);
		set_contactInfo(n_contactInfo);
	}
	#endregion

	#region Destructor
/*	public ~XplCopyright(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplCopyright copy = new XplCopyright();
		copy.set_copyrightMessage(this.p_copyrightMessage);
		copy.set_company(this.p_company);
		copy.set_productName(this.p_productName);
		copy.set_productVersion(this.p_productVersion);
		copy.set_productLicense(this.p_productLicense);
		copy.set_description(this.p_description);
		copy.set_contactInfo(this.p_contactInfo);
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplCopyright;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_copyrightMessage != "")
			writer.WriteAttributeString( "copyrightMessage" ,ZoeHelper .Att_ToString(p_copyrightMessage) );
		if(p_company != "")
			writer.WriteAttributeString( "company" ,ZoeHelper .Att_ToString(p_company) );
		if(p_productName != "")
			writer.WriteAttributeString( "productName" ,ZoeHelper .Att_ToString(p_productName) );
		if(p_productVersion != "")
			writer.WriteAttributeString( "productVersion" ,ZoeHelper .Att_ToString(p_productVersion) );
		if(p_productLicense != "")
			writer.WriteAttributeString( "productLicense" ,ZoeHelper .Att_ToString(p_productLicense) );
		if(p_description != "")
			writer.WriteAttributeString( "description" ,ZoeHelper .Att_ToString(p_description) );
		if(p_contactInfo != "")
			writer.WriteAttributeString( "contactInfo" ,ZoeHelper .Att_ToString(p_contactInfo) );
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
					case "copyrightMessage":
						this.set_copyrightMessage(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "company":
						this.set_company(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "productName":
						this.set_productName(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "productVersion":
						this.set_productVersion(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "productLicense":
						this.set_productLicense(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "description":
						this.set_description(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "contactInfo":
						this.set_contactInfo(ZoeHelper .StringAtt_To_STRING(reader.Value));
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
		writer.Write((int) 149 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_copyrightMessage );
		writer.Write( p_company );
		writer.Write( p_productName );
		writer.Write( p_productVersion );
		writer.Write( p_productLicense );
		writer.Write( p_description );
		writer.Write( p_contactInfo );
		//Escribo recursivamente cada elemento hijo
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_copyrightMessage = reader.ReadString();
		p_company = reader.ReadString();
		p_productName = reader.ReadString();
		p_productVersion = reader.ReadString();
		p_productLicense = reader.ReadString();
		p_description = reader.ReadString();
		p_contactInfo = reader.ReadString();
		//Lectura de Elementos
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplCopyright operator +(XplCopyright arg1, XplNode arg2)
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
public static XplCopyright operator +(XplCopyright arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_copyrightMessage(){
		return p_copyrightMessage;
	}
	public string get_company(){
		return p_company;
	}
	public string get_productName(){
		return p_productName;
	}
	public string get_productVersion(){
		return p_productVersion;
	}
	public string get_productLicense(){
		return p_productLicense;
	}
	public string get_description(){
		return p_description;
	}
	public string get_contactInfo(){
		return p_contactInfo;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[7];
		ret[0] = "copyrightMessage";
		ret[1] = "company";
		ret[2] = "productName";
		ret[3] = "productVersion";
		ret[4] = "productLicense";
		ret[5] = "description";
		ret[6] = "contactInfo";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="copyrightMessage") return p_copyrightMessage.ToString();
		if (attributeName=="company") return p_company.ToString();
		if (attributeName=="productName") return p_productName.ToString();
		if (attributeName=="productVersion") return p_productVersion.ToString();
		if (attributeName=="productLicense") return p_productLicense.ToString();
		if (attributeName=="description") return p_description.ToString();
		if (attributeName=="contactInfo") return p_contactInfo.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_copyrightMessage(string new_copyrightMessage){
		string back_copyrightMessage = p_copyrightMessage;
		p_copyrightMessage = new_copyrightMessage;
		return back_copyrightMessage;
	}
	public string set_company(string new_company){
		string back_company = p_company;
		p_company = new_company;
		return back_company;
	}
	public string set_productName(string new_productName){
		string back_productName = p_productName;
		p_productName = new_productName;
		return back_productName;
	}
	public string set_productVersion(string new_productVersion){
		string back_productVersion = p_productVersion;
		p_productVersion = new_productVersion;
		return back_productVersion;
	}
	public string set_productLicense(string new_productLicense){
		string back_productLicense = p_productLicense;
		p_productLicense = new_productLicense;
		return back_productLicense;
	}
	public string set_description(string new_description){
		string back_description = p_description;
		p_description = new_description;
		return back_description;
	}
	public string set_contactInfo(string new_contactInfo){
		string back_contactInfo = p_contactInfo;
		p_contactInfo = new_contactInfo;
		return back_contactInfo;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

