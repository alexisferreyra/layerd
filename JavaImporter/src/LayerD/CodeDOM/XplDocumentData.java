/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 17/04/2009 10:26:35
 *
 *	Generado por Zoe CodeDOM Generator para Java.
 *	COPYRIGHT 2002,2005-2006.
 *
 *------------------------------------------------*/


package LayerD.CodeDOM;

import LayerD.CodeDOM.XplParser.ParseException;
import java.io.*;
import java.util.*;
import java.text.*;

public class XplDocumentData extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	int p_DocumentType;
	String p_DocumentVersion;
	String p_ExternConfig;
	//Variables para Elementos de Secuencia
	XplNode p_Title;
	XplFileData p_Original;
	XplCopyright p_Copyright;
	XplConfig p_Config;
	XplDocumentation p_Documentation;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplDocumentData(){
		p_DocumentType = XplDocumenttype_enum.LAYERD_XPL_DOC;
		p_DocumentVersion = "";
		p_ExternConfig = "";
		p_Title=null;
		p_Original=null;
		p_Copyright=null;
		p_Config=null;
		p_Documentation=null;
	}
	public XplDocumentData(int n_DocumentType, String n_DocumentVersion){
		p_DocumentType = XplDocumenttype_enum.LAYERD_XPL_DOC;
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
		p_DocumentType = XplDocumenttype_enum.LAYERD_XPL_DOC;
		p_DocumentVersion = "";
		p_ExternConfig = "";
		p_Title=null;
		p_Original=null;
		p_Copyright=null;
		p_Config=null;
		p_Documentation=null;
		set_Config(n_Config);
	}
	public XplDocumentData(int n_DocumentType, String n_DocumentVersion, XplConfig n_Config){
		p_DocumentType = XplDocumenttype_enum.LAYERD_XPL_DOC;
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
	public XplDocumentData(int n_DocumentType, String n_DocumentVersion, String n_ExternConfig){
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
		p_DocumentType = XplDocumenttype_enum.LAYERD_XPL_DOC;
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
	public XplDocumentData(int n_DocumentType, String n_DocumentVersion, String n_ExternConfig, XplConfig n_Config){
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
	public XplDocumentData(int n_DocumentType, String n_DocumentVersion, XplNode n_Title, XplFileData n_Original, XplCopyright n_Copyright, XplConfig n_Config, XplDocumentation n_Documentation){
		p_DocumentType = XplDocumenttype_enum.LAYERD_XPL_DOC;
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
	public XplDocumentData(int n_DocumentType, String n_DocumentVersion, String n_ExternConfig, XplNode n_Title, XplFileData n_Original, XplCopyright n_Copyright, XplConfig n_Config, XplDocumentation n_Documentation){
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
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplDocumentData copy = new XplDocumentData();
		copy.set_DocumentType(this.p_DocumentType);
		copy.set_DocumentVersion(this.p_DocumentVersion);
		copy.set_ExternConfig(this.p_ExternConfig);
		if(p_Title!=null)copy.set_Title(p_Title.Clone());
		if(p_Original!=null)copy.set_Original((XplFileData)p_Original.Clone());
		if(p_Copyright!=null)copy.set_Copyright((XplCopyright)p_Copyright.Clone());
		if(p_Config!=null)copy.set_Config((XplConfig)p_Config.Clone());
		if(p_Documentation!=null)copy.set_Documentation((XplDocumentation)p_Documentation.Clone());
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplDocumentData;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_DocumentType != XplDocumenttype_enum.LAYERD_XPL_DOC)
			writer.WriteAttributeString( "DocumentType" , CodeDOM_STV.XPLDOCUMENTTYPE_ENUM[(int)p_DocumentType] );
		if(p_DocumentVersion != "")
			writer.WriteAttributeString( "DocumentVersion" ,CodeDOM_Utils.Att_ToString(p_DocumentVersion) );
		if(p_ExternConfig != "")
			writer.WriteAttributeString( "ExternConfig" ,CodeDOM_Utils.Att_ToString(p_ExternConfig) );
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

	public XplNode Read(XplReader reader) throws ParseException, CodeDOM_Exception, IOException {
		this.set_Name( reader.Name() );
		//Lectura de Atributos
		if( reader.HasAttributes() ){
			String tmpStr="";boolean flag=false;int count=0;
			for(int i=1; i <= reader.AttributeCount() ; i++){
				reader.MoveToAttribute(i);
				if(reader.Name().equals("DocumentType")){
					tmpStr=CodeDOM_Utils.StringAtt_To_STRING(reader.Value());
					count=0;flag=false;
					for(int n=0;n<CodeDOM_STV.XPLDOCUMENTTYPE_ENUM.length;n++){
						String str = CodeDOM_STV.XPLDOCUMENTTYPE_ENUM[n];
						if(str.equals(tmpStr)){this.set_DocumentType(count);flag=true;break;}
						count++;
					}
					// if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Valor invalido del atributo 'DocumentType' en elemento '"+this.get_Name()+"'.");
				}
				else if(reader.Name().equals("DocumentVersion")){
					this.set_DocumentVersion(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("ExternConfig")){
					this.set_ExternConfig(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else{
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Atributo '"+reader.Name()+"' invalido en elemento '"+this.get_Name()+"'.");
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
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("Title")){
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						if(this.get_Title()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_Title(tempNode);
					}
					else if(reader.Name().equals("Original")){
						tempNode = new XplFileData();
						tempNode.Read(reader);
						if(this.get_Original()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_Original((XplFileData)tempNode);
					}
					else if(reader.Name().equals("Copyright")){
						tempNode = new XplCopyright();
						tempNode.Read(reader);
						if(this.get_Copyright()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_Copyright((XplCopyright)tempNode);
					}
					else if(reader.Name().equals("Config")){
						tempNode = new XplConfig();
						tempNode.Read(reader);
						if(this.get_Config()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_Config((XplConfig)tempNode);
					}
					else if(reader.Name().equals("Documentation")){
						tempNode = new XplDocumentation();
						tempNode.Read(reader);
						if(this.get_Documentation()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_Documentation((XplDocumentation)tempNode);
					}
					else{
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nombre de nodo '"+reader.Name()+"' inesperado como hijo de elemento '"+this.get_Name()+"'.");
					}
					break;
				case XmlNodeType.ENDELEMENT:
					break;
				case XmlNodeType.TEXT:
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".No se esperaba texto en este nodo.");
				default:
					break;
			}
			reader.Read();
		}
		}
		return this;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para obtener Atributos y Elementos ">
	public int get_DocumentType(){
		return p_DocumentType;
	}
	public String get_DocumentVersion(){
		return p_DocumentVersion;
	}
	public String get_ExternConfig(){
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
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public int set_DocumentType(int new_DocumentType){
		int back_DocumentType = p_DocumentType;
		p_DocumentType = new_DocumentType;
		return back_DocumentType;
	}
	public String set_DocumentVersion(String new_DocumentVersion){
		String back_DocumentVersion = p_DocumentVersion;
		p_DocumentVersion = new_DocumentVersion;
		return back_DocumentVersion;
	}
	public String set_ExternConfig(String new_ExternConfig){
		String back_ExternConfig = p_ExternConfig;
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
			p_Title.set_Name("Title");
		}
		return back_Title;
	}
	public XplFileData set_Original(XplFileData new_Original){
		XplFileData back_Original = p_Original;
		p_Original = new_Original;
		if(p_Original!=null){
			p_Original.set_Name("Original");
			p_Original.set_Parent(this);
		}
		return back_Original;
	}
	public XplCopyright set_Copyright(XplCopyright new_Copyright){
		XplCopyright back_Copyright = p_Copyright;
		p_Copyright = new_Copyright;
		if(p_Copyright!=null){
			p_Copyright.set_Name("Copyright");
			p_Copyright.set_Parent(this);
		}
		return back_Copyright;
	}
	public XplConfig set_Config(XplConfig new_Config){
		XplConfig back_Config = p_Config;
		p_Config = new_Config;
		if(p_Config!=null){
			p_Config.set_Name("Config");
			p_Config.set_Parent(this);
		}
		return back_Config;
	}
	public XplDocumentation set_Documentation(XplDocumentation new_Documentation){
		XplDocumentation back_Documentation = p_Documentation;
		p_Documentation = new_Documentation;
		if(p_Documentation!=null){
			p_Documentation.set_Name("Documentation");
			p_Documentation.set_Parent(this);
		}
		return back_Documentation;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplNode new_Title(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_Name("Title");
		return node;
	}
	public static final XplFileData new_Original(){
		XplFileData node = new XplFileData();
		node.set_Name("Original");
		return node;
	}
	public static final XplCopyright new_Copyright(){
		XplCopyright node = new XplCopyright();
		node.set_Name("Copyright");
		return node;
	}
	public static final XplConfig new_Config(){
		XplConfig node = new XplConfig();
		node.set_Name("Config");
		return node;
	}
	public static final XplDocumentation new_Documentation(){
		XplDocumentation node = new XplDocumentation();
		node.set_Name("Documentation");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

