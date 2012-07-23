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
public class XplDocumentData:  XplNode{

	#region Variables privadas para atributos y elementos
	XplDocumenttype_enum p_DocumentType;
	string p_DocumentVersion;
	string p_ExternConfig;
	//Variables para Elementos de Secuencia
	XplNode p_Title;
	XplFileData p_Original;
	XplCopyright p_Copyright;
	XplConfig p_Config;
	XplDocumentation p_Documentation;
	#endregion

	#region Region de Constructores Publicos
	public XplDocumentData(){
		p_DocumentType = XplDocumenttype_enum.LAYERD_ZOE_DOC;
		p_DocumentVersion = "";
		p_ExternConfig = "";
		p_Title=null;
		p_Original=null;
		p_Copyright=null;
		p_Config=null;
		p_Documentation=null;
}
	public XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion){
		p_DocumentType = XplDocumenttype_enum.LAYERD_ZOE_DOC;
		p_DocumentVersion = "";
		p_ExternConfig = "";
		set_DocumentType(n_DocumentType);
		set_DocumentVersion(n_DocumentVersion);
		p_Title=null;
		p_Original=null;
		p_Copyright=null;
		p_Config=null;
		p_Documentation=null;
	}
	public XplDocumentData(XplConfig n_Config){
		p_DocumentType = XplDocumenttype_enum.LAYERD_ZOE_DOC;
		p_DocumentVersion = "";
		p_ExternConfig = "";
		p_Title=null;
		p_Original=null;
		p_Copyright=null;
		p_Config=null;
		p_Documentation=null;
		set_Config(n_Config);
	}
	public XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, XplConfig n_Config){
		p_DocumentType = XplDocumenttype_enum.LAYERD_ZOE_DOC;
		p_DocumentVersion = "";
		p_ExternConfig = "";
		set_DocumentType(n_DocumentType);
		set_DocumentVersion(n_DocumentVersion);
		p_Title=null;
		p_Original=null;
		p_Copyright=null;
		p_Config=null;
		p_Documentation=null;
		set_Config(n_Config);
	}
	public XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, string n_ExternConfig){
		set_DocumentType(n_DocumentType);
		set_DocumentVersion(n_DocumentVersion);
		set_ExternConfig(n_ExternConfig);
		p_Title=null;
		p_Original=null;
		p_Copyright=null;
		p_Config=null;
		p_Documentation=null;
	}
	public XplDocumentData(XplNode n_Title, XplFileData n_Original, XplCopyright n_Copyright, XplConfig n_Config, XplDocumentation n_Documentation){
		p_DocumentType = XplDocumenttype_enum.LAYERD_ZOE_DOC;
		p_DocumentVersion = "";
		p_ExternConfig = "";
		p_Title=null;
		p_Original=null;
		p_Copyright=null;
		p_Config=null;
		p_Documentation=null;
		set_Title(n_Title);
		set_Original(n_Original);
		set_Copyright(n_Copyright);
		set_Config(n_Config);
		set_Documentation(n_Documentation);
	}
	public XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, string n_ExternConfig, XplConfig n_Config){
		set_DocumentType(n_DocumentType);
		set_DocumentVersion(n_DocumentVersion);
		set_ExternConfig(n_ExternConfig);
		set_DocumentType(n_DocumentType);
		set_DocumentVersion(n_DocumentVersion);
		p_Title=null;
		p_Original=null;
		p_Copyright=null;
		p_Config=null;
		p_Documentation=null;
	}
	public XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, XplNode n_Title, XplFileData n_Original, XplCopyright n_Copyright, XplConfig n_Config, XplDocumentation n_Documentation){
		p_DocumentType = XplDocumenttype_enum.LAYERD_ZOE_DOC;
		p_DocumentVersion = "";
		p_ExternConfig = "";
		set_DocumentType(n_DocumentType);
		set_DocumentVersion(n_DocumentVersion);
		p_Title=null;
		p_Original=null;
		p_Copyright=null;
		p_Config=null;
		p_Documentation=null;
		set_Title(n_Title);
		set_Original(n_Original);
		set_Copyright(n_Copyright);
		set_Config(n_Config);
		set_Documentation(n_Documentation);
	}
	public XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, string n_ExternConfig, XplNode n_Title, XplFileData n_Original, XplCopyright n_Copyright, XplConfig n_Config, XplDocumentation n_Documentation){
		set_DocumentType(n_DocumentType);
		set_DocumentVersion(n_DocumentVersion);
		set_ExternConfig(n_ExternConfig);
		p_Title=null;
		p_Original=null;
		p_Copyright=null;
		p_Config=null;
		p_Documentation=null;
		set_Title(n_Title);
		set_Original(n_Original);
		set_Copyright(n_Copyright);
		set_Config(n_Config);
		set_Documentation(n_Documentation);
	}
	#endregion

	#region Destructor
/*	public ~XplDocumentData(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplDocumentData copy = new XplDocumentData();
		copy.set_DocumentType(this.p_DocumentType);
		copy.set_DocumentVersion(this.p_DocumentVersion);
		copy.set_ExternConfig(this.p_ExternConfig);
		if(p_Title!=null)copy.set_Title(p_Title.Clone());
		if(p_Original!=null)copy.set_Original((XplFileData)p_Original.Clone());
		if(p_Copyright!=null)copy.set_Copyright((XplCopyright)p_Copyright.Clone());
		if(p_Config!=null)copy.set_Config((XplConfig)p_Config.Clone());
		if(p_Documentation!=null)copy.set_Documentation((XplDocumentation)p_Documentation.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplDocumentData;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_DocumentType != XplDocumenttype_enum.LAYERD_ZOE_DOC)
			writer.WriteAttributeString( "DocumentType" , CodeDOM_STV.XPLDOCUMENTTYPE_ENUM[(int)p_DocumentType] );
		if(p_DocumentVersion != "")
			writer.WriteAttributeString( "DocumentVersion" ,ZoeHelper .Att_ToString(p_DocumentVersion) );
		if(p_ExternConfig != "")
			writer.WriteAttributeString( "ExternConfig" ,ZoeHelper .Att_ToString(p_ExternConfig) );
		//Escribo recursivamente cada elemento hijo
		if(p_Title!=null)if(!p_Title.Write(writer))result=false;
		if(p_Original!=null)if(!p_Original.Write(writer))result=false;
		if(p_Copyright!=null)if(!p_Copyright.Write(writer))result=false;
		if(p_Config!=null)if(!p_Config.Write(writer))result=false;
		if(p_Documentation!=null)if(!p_Documentation.Write(writer))result=false;
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
					case "DocumentType":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLDOCUMENTTYPE_ENUM){
							if(str==tmpStr){this.set_DocumentType((XplDocumenttype_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'DocumentType' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "DocumentVersion":
						this.set_DocumentVersion(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "ExternConfig":
						this.set_ExternConfig(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Atributo '"+reader.Name+"' invalido en elemento '"+this.get_ElementName()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		//Borro todo posible nodo en memoria
		this.p_Title=null;
		this.p_Original=null;
		this.p_Copyright=null;
		this.p_Config=null;
		this.p_Documentation=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "Title":
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_Title()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_Title(tempNode);
						break;
					case "Original":
						tempNode = new XplFileData();
						tempNode.Read(reader);
						if(this.get_Original()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_Original((XplFileData)tempNode);
						break;
					case "Copyright":
						tempNode = new XplCopyright();
						tempNode.Read(reader);
						if(this.get_Copyright()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_Copyright((XplCopyright)tempNode);
						break;
					case "Config":
						tempNode = new XplConfig();
						tempNode.Read(reader);
						if(this.get_Config()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_Config((XplConfig)tempNode);
						break;
					case "Documentation":
						tempNode = new XplDocumentation();
						tempNode.Read(reader);
						if(this.get_Documentation()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_Documentation((XplDocumentation)tempNode);
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
		writer.Write((int) 145 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( (int)p_DocumentType );
		writer.Write( p_DocumentVersion );
		writer.Write( p_ExternConfig );
		//Escribo recursivamente cada elemento hijo
		if(p_Title!=null){
			writer.Write((int)1);
			if(!p_Title.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_Original!=null){
			writer.Write((int)1);
			if(!p_Original.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_Copyright!=null){
			writer.Write((int)1);
			if(!p_Copyright.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_Config!=null){
			writer.Write((int)1);
			if(!p_Config.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_Documentation!=null){
			writer.Write((int)1);
			if(!p_Documentation.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_DocumentType = (XplDocumenttype_enum)reader.ReadInt32();
		p_DocumentVersion = reader.ReadString();
		p_ExternConfig = reader.ReadString();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_Title = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_Original = (XplFileData)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_Copyright = (XplCopyright)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_Config = (XplConfig)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_Documentation = (XplDocumentation)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplDocumentData operator +(XplDocumentData arg1, XplNode arg2)
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
public static XplDocumentData operator +(XplDocumentData arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public XplDocumenttype_enum get_DocumentType(){
		return p_DocumentType;
	}
	public string get_DocumentVersion(){
		return p_DocumentVersion;
	}
	public string get_ExternConfig(){
		return p_ExternConfig;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplNode get_Title(){
		return p_Title;
	}
	public XplFileData get_Original(){
		return p_Original;
	}
	public XplCopyright get_Copyright(){
		return p_Copyright;
	}
	public XplConfig get_Config(){
		return p_Config;
	}
	public XplDocumentation get_Documentation(){
		return p_Documentation;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[3];
		ret[0] = "DocumentType";
		ret[1] = "DocumentVersion";
		ret[2] = "ExternConfig";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="DocumentType") return p_DocumentType.ToString();
		if (attributeName=="DocumentVersion") return p_DocumentVersion.ToString();
		if (attributeName=="ExternConfig") return p_ExternConfig.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		list.InsertAtEnd(p_Title);
		list.InsertAtEnd(p_Original);
		list.InsertAtEnd(p_Copyright);
		list.InsertAtEnd(p_Config);
		list.InsertAtEnd(p_Documentation);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public XplDocumenttype_enum set_DocumentType(XplDocumenttype_enum new_DocumentType){
		XplDocumenttype_enum back_DocumentType = p_DocumentType;
		p_DocumentType = new_DocumentType;
		return back_DocumentType;
	}
	public string set_DocumentVersion(string new_DocumentVersion){
		string back_DocumentVersion = p_DocumentVersion;
		p_DocumentVersion = new_DocumentVersion;
		return back_DocumentVersion;
	}
	public string set_ExternConfig(string new_ExternConfig){
		string back_ExternConfig = p_ExternConfig;
		p_ExternConfig = new_ExternConfig;
		return back_ExternConfig;
	}

	//Funciones para setear Elementos de Secuencia
	public XplNode set_Title(XplNode new_Title){
		if(new_Title.get_ContentTypeName()!=CodeDOMTypes.String){
			this.set_ErrorString("El nodo que intenta asignar a la propiedad es de un tipo incorrecto.");
			return null;
		}
		XplNode back_Title = p_Title;
		p_Title = new_Title;
		if(p_Title!=null){
			p_Title.set_Parent(this);
			p_Title.set_ElementName("Title");
		}
		return back_Title;
	}
	public XplFileData set_Original(XplFileData new_Original){
		XplFileData back_Original = p_Original;
		p_Original = new_Original;
		if(p_Original!=null){
			p_Original.set_ElementName("Original");
			p_Original.set_Parent(this);
		}
		return back_Original;
	}
	public XplCopyright set_Copyright(XplCopyright new_Copyright){
		XplCopyright back_Copyright = p_Copyright;
		p_Copyright = new_Copyright;
		if(p_Copyright!=null){
			p_Copyright.set_ElementName("Copyright");
			p_Copyright.set_Parent(this);
		}
		return back_Copyright;
	}
	public XplConfig set_Config(XplConfig new_Config){
		XplConfig back_Config = p_Config;
		p_Config = new_Config;
		if(p_Config!=null){
			p_Config.set_ElementName("Config");
			p_Config.set_Parent(this);
		}
		return back_Config;
	}
	public XplDocumentation set_Documentation(XplDocumentation new_Documentation){
		XplDocumentation back_Documentation = p_Documentation;
		p_Documentation = new_Documentation;
		if(p_Documentation!=null){
			p_Documentation.set_ElementName("Documentation");
			p_Documentation.set_Parent(this);
		}
		return back_Documentation;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplNode new_Title(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_ElementName("Title");
		return node;
	}
	static public XplFileData new_Original(){
		XplFileData node = new XplFileData();
		node.set_ElementName("Original");
		return node;
	}
	static public XplCopyright new_Copyright(){
		XplCopyright node = new XplCopyright();
		node.set_ElementName("Copyright");
		return node;
	}
	static public XplConfig new_Config(){
		XplConfig node = new XplConfig();
		node.set_ElementName("Config");
		return node;
	}
	static public XplDocumentation new_Documentation(){
		XplDocumentation node = new XplDocumentation();
		node.set_ElementName("Documentation");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

