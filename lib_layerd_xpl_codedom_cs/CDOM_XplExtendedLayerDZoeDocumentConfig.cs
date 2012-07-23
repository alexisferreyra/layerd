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
public class XplExtendedLayerDZoeDocumentConfig:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_platform;
	string p_outputFileName;
	int p_partNumber;
	string p_programName;
	string p_programConfig;
	//Variables para Elementos de Secuencia
	XplLanguage p_Language;
	XplLayerDCompiler p_LayerDCompiler;
	XplLayerDCompiler p_LayerDZoeCompiler;
	XplNodeList p_History;
	#endregion

	#region Region de Constructores Publicos
	public XplExtendedLayerDZoeDocumentConfig(){
		p_platform = "";
		p_outputFileName = "";
		p_partNumber = 0;
		p_programName = "";
		p_programConfig = "";
		p_Language=null;
		p_LayerDCompiler=null;
		p_LayerDZoeCompiler=null;
		p_History = new XplNodeList();
		p_History.set_Parent(this);
		p_History.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_History));
		p_History.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_History));
}
	public XplExtendedLayerDZoeDocumentConfig(string n_platform){
		p_platform = "";
		p_outputFileName = "";
		p_partNumber = 0;
		p_programName = "";
		p_programConfig = "";
		set_platform(n_platform);
		p_Language=null;
		p_LayerDCompiler=null;
		p_LayerDZoeCompiler=null;
		p_History = new XplNodeList();
		p_History.set_Parent(this);
		p_History.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_History));
		p_History.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_History));
	}
	public XplExtendedLayerDZoeDocumentConfig(string n_platform, string n_outputFileName, int n_partNumber, string n_programName, string n_programConfig){
		set_platform(n_platform);
		set_outputFileName(n_outputFileName);
		set_partNumber(n_partNumber);
		set_programName(n_programName);
		set_programConfig(n_programConfig);
		p_Language=null;
		p_LayerDCompiler=null;
		p_LayerDZoeCompiler=null;
		p_History = new XplNodeList();
		p_History.set_Parent(this);
		p_History.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_History));
		p_History.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_History));
	}
	public XplExtendedLayerDZoeDocumentConfig(XplLanguage n_Language, XplLayerDCompiler n_LayerDCompiler, XplLayerDCompiler n_LayerDZoeCompiler, XplNodeList n_History){
		p_platform = "";
		p_outputFileName = "";
		p_partNumber = 0;
		p_programName = "";
		p_programConfig = "";
		p_Language=null;
		p_LayerDCompiler=null;
		p_LayerDZoeCompiler=null;
		p_History = new XplNodeList();
		p_History.set_Parent(this);
		p_History.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_History));
		p_History.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_History));
		set_Language(n_Language);
		set_LayerDCompiler(n_LayerDCompiler);
		set_LayerDZoeCompiler(n_LayerDZoeCompiler);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_History!=null)
		for(XplNode node = n_History.FirstNode(); node != null ; node = n_History.NextNode()){
			p_History.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	public XplExtendedLayerDZoeDocumentConfig(string n_platform, XplLanguage n_Language, XplLayerDCompiler n_LayerDCompiler, XplLayerDCompiler n_LayerDZoeCompiler, XplNodeList n_History){
		p_platform = "";
		p_outputFileName = "";
		p_partNumber = 0;
		p_programName = "";
		p_programConfig = "";
		set_platform(n_platform);
		p_Language=null;
		p_LayerDCompiler=null;
		p_LayerDZoeCompiler=null;
		p_History = new XplNodeList();
		p_History.set_Parent(this);
		p_History.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_History));
		p_History.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_History));
		set_Language(n_Language);
		set_LayerDCompiler(n_LayerDCompiler);
		set_LayerDZoeCompiler(n_LayerDZoeCompiler);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_History!=null)
		for(XplNode node = n_History.FirstNode(); node != null ; node = n_History.NextNode()){
			p_History.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	public XplExtendedLayerDZoeDocumentConfig(string n_platform, string n_outputFileName, int n_partNumber, string n_programName, string n_programConfig, XplLanguage n_Language, XplLayerDCompiler n_LayerDCompiler, XplLayerDCompiler n_LayerDZoeCompiler, XplNodeList n_History){
		set_platform(n_platform);
		set_outputFileName(n_outputFileName);
		set_partNumber(n_partNumber);
		set_programName(n_programName);
		set_programConfig(n_programConfig);
		p_Language=null;
		p_LayerDCompiler=null;
		p_LayerDZoeCompiler=null;
		p_History = new XplNodeList();
		p_History.set_Parent(this);
		p_History.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_History));
		p_History.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_History));
		set_Language(n_Language);
		set_LayerDCompiler(n_LayerDCompiler);
		set_LayerDZoeCompiler(n_LayerDZoeCompiler);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_History!=null)
		for(XplNode node = n_History.FirstNode(); node != null ; node = n_History.NextNode()){
			p_History.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	#endregion

	#region Destructor
/*	public ~XplExtendedLayerDZoeDocumentConfig(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplExtendedLayerDZoeDocumentConfig copy = new XplExtendedLayerDZoeDocumentConfig();
		copy.set_platform(this.p_platform);
		copy.set_outputFileName(this.p_outputFileName);
		copy.set_partNumber(this.p_partNumber);
		copy.set_programName(this.p_programName);
		copy.set_programConfig(this.p_programConfig);
		if(p_Language!=null)copy.set_Language((XplLanguage)p_Language.Clone());
		if(p_LayerDCompiler!=null)copy.set_LayerDCompiler((XplLayerDCompiler)p_LayerDCompiler.Clone());
		if(p_LayerDZoeCompiler!=null)copy.set_LayerDZoeCompiler((XplLayerDCompiler)p_LayerDZoeCompiler.Clone());
		for(XplNode node = p_History.FirstNode(); node != null ; node = p_History.NextNode()){
			copy.get_History().InsertAtEnd(node.Clone());
		}
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplExtendedLayerDZoeDocumentConfig;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_platform != "")
			writer.WriteAttributeString( "platform" ,ZoeHelper .Att_ToString(p_platform) );
		if(p_outputFileName != "")
			writer.WriteAttributeString( "outputFileName" ,ZoeHelper .Att_ToString(p_outputFileName) );
		if(p_partNumber != 0)
			writer.WriteAttributeString( "partNumber" ,ZoeHelper .Att_ToString(p_partNumber) );
		if(p_programName != "")
			writer.WriteAttributeString( "programName" ,ZoeHelper .Att_ToString(p_programName) );
		if(p_programConfig != "")
			writer.WriteAttributeString( "programConfig" ,ZoeHelper .Att_ToString(p_programConfig) );
		//Escribo recursivamente cada elemento hijo
		if(p_Language!=null)if(!p_Language.Write(writer))result=false;
		if(p_LayerDCompiler!=null)if(!p_LayerDCompiler.Write(writer))result=false;
		if(p_LayerDZoeCompiler!=null)if(!p_LayerDZoeCompiler.Write(writer))result=false;
		if(p_History!=null)if(!p_History.Write(writer))result=false;
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
					case "platform":
						this.set_platform(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "outputFileName":
						this.set_outputFileName(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "partNumber":
						this.set_partNumber(ZoeHelper .StringAtt_To_INT(reader.Value));
						break;
					case "programName":
						this.set_programName(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "programConfig":
						this.set_programConfig(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Atributo '"+reader.Name+"' invalido en elemento '"+this.get_ElementName()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		//Borro todo posible nodo en memoria
		this.p_Language=null;
		this.p_LayerDCompiler=null;
		this.p_LayerDZoeCompiler=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "Language":
						tempNode = new XplLanguage();
						tempNode.Read(reader);
						if(this.get_Language()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_Language((XplLanguage)tempNode);
						break;
					case "LayerDCompiler":
						tempNode = new XplLayerDCompiler();
						tempNode.Read(reader);
						if(this.get_LayerDCompiler()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_LayerDCompiler((XplLayerDCompiler)tempNode);
						break;
					case "LayerDZoeCompiler":
						tempNode = new XplLayerDCompiler();
						tempNode.Read(reader);
						if(this.get_LayerDZoeCompiler()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_LayerDZoeCompiler((XplLayerDCompiler)tempNode);
						break;
					case "History":
						tempNode = new XplFileData();
						tempNode.Read(reader);
						this.get_History().InsertAtEnd(tempNode);
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
		writer.Write((int) 142 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_platform );
		writer.Write( p_outputFileName );
		writer.Write( p_partNumber );
		writer.Write( p_programName );
		writer.Write( p_programConfig );
		//Escribo recursivamente cada elemento hijo
		if(p_Language!=null){
			writer.Write((int)1);
			if(!p_Language.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_LayerDCompiler!=null){
			writer.Write((int)1);
			if(!p_LayerDCompiler.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_LayerDZoeCompiler!=null){
			writer.Write((int)1);
			if(!p_LayerDZoeCompiler.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_History!=null){
			writer.Write((int)1);
			if(!p_History.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_platform = reader.ReadString();
		p_outputFileName = reader.ReadString();
		p_partNumber = reader.ReadInt32();
		p_programName = reader.ReadString();
		p_programConfig = reader.ReadString();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_Language = (XplLanguage)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_LayerDCompiler = (XplLayerDCompiler)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_LayerDZoeCompiler = (XplLayerDCompiler)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_History.BinaryRead(reader);
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplExtendedLayerDZoeDocumentConfig operator +(XplExtendedLayerDZoeDocumentConfig arg1, XplNode arg2)
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
public static XplExtendedLayerDZoeDocumentConfig operator +(XplExtendedLayerDZoeDocumentConfig arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_platform(){
		return p_platform;
	}
	public string get_outputFileName(){
		return p_outputFileName;
	}
	public int get_partNumber(){
		return p_partNumber;
	}
	public string get_programName(){
		return p_programName;
	}
	public string get_programConfig(){
		return p_programConfig;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplLanguage get_Language(){
		return p_Language;
	}
	public XplLayerDCompiler get_LayerDCompiler(){
		return p_LayerDCompiler;
	}
	public XplLayerDCompiler get_LayerDZoeCompiler(){
		return p_LayerDZoeCompiler;
	}
	public XplNodeList get_History(){
		return p_History;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[5];
		ret[0] = "platform";
		ret[1] = "outputFileName";
		ret[2] = "partNumber";
		ret[3] = "programName";
		ret[4] = "programConfig";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="platform") return p_platform.ToString();
		if (attributeName=="outputFileName") return p_outputFileName.ToString();
		if (attributeName=="partNumber") return p_partNumber.ToString();
		if (attributeName=="programName") return p_programName.ToString();
		if (attributeName=="programConfig") return p_programConfig.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		list.InsertAtEnd(p_Language);
		list.InsertAtEnd(p_LayerDCompiler);
		list.InsertAtEnd(p_LayerDZoeCompiler);
		for(XplNode node=p_History.FirstNode();node!=null;node=p_History.NextNode())
			list.InsertAtEnd(node);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_platform(string new_platform){
		string back_platform = p_platform;
		p_platform = new_platform;
		return back_platform;
	}
	public string set_outputFileName(string new_outputFileName){
		string back_outputFileName = p_outputFileName;
		p_outputFileName = new_outputFileName;
		return back_outputFileName;
	}
	public int set_partNumber(int new_partNumber){
		int back_partNumber = p_partNumber;
		p_partNumber = new_partNumber;
		return back_partNumber;
	}
	public string set_programName(string new_programName){
		string back_programName = p_programName;
		p_programName = new_programName;
		return back_programName;
	}
	public string set_programConfig(string new_programConfig){
		string back_programConfig = p_programConfig;
		p_programConfig = new_programConfig;
		return back_programConfig;
	}

	//Funciones para setear Elementos de Secuencia
	public XplLanguage set_Language(XplLanguage new_Language){
		XplLanguage back_Language = p_Language;
		p_Language = new_Language;
		if(p_Language!=null){
			p_Language.set_ElementName("Language");
			p_Language.set_Parent(this);
		}
		return back_Language;
	}
	public XplLayerDCompiler set_LayerDCompiler(XplLayerDCompiler new_LayerDCompiler){
		XplLayerDCompiler back_LayerDCompiler = p_LayerDCompiler;
		p_LayerDCompiler = new_LayerDCompiler;
		if(p_LayerDCompiler!=null){
			p_LayerDCompiler.set_ElementName("LayerDCompiler");
			p_LayerDCompiler.set_Parent(this);
		}
		return back_LayerDCompiler;
	}
	public XplLayerDCompiler set_LayerDZoeCompiler(XplLayerDCompiler new_LayerDZoeCompiler){
		XplLayerDCompiler back_LayerDZoeCompiler = p_LayerDZoeCompiler;
		p_LayerDZoeCompiler = new_LayerDZoeCompiler;
		if(p_LayerDZoeCompiler!=null){
			p_LayerDZoeCompiler.set_ElementName("LayerDZoeCompiler");
			p_LayerDZoeCompiler.set_Parent(this);
		}
		return back_LayerDZoeCompiler;
	}
	protected bool acceptInsertNodeCallback_History(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="History"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFileData){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFileData'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplFileData'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_History(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplLanguage new_Language(){
		XplLanguage node = new XplLanguage();
		node.set_ElementName("Language");
		return node;
	}
	static public XplLayerDCompiler new_LayerDCompiler(){
		XplLayerDCompiler node = new XplLayerDCompiler();
		node.set_ElementName("LayerDCompiler");
		return node;
	}
	static public XplLayerDCompiler new_LayerDZoeCompiler(){
		XplLayerDCompiler node = new XplLayerDCompiler();
		node.set_ElementName("LayerDZoeCompiler");
		return node;
	}
	static public XplFileData new_History(){
		XplFileData node = new XplFileData();
		node.set_ElementName("History");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

