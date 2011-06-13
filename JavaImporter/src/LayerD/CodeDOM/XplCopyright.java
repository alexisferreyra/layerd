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

public class XplCopyright extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_copyrightMessage;
	String p_company;
	String p_productName;
	String p_productVersion;
	String p_productLicense;
	String p_description;
	String p_contactInfo;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplCopyright(){
		p_copyrightMessage = "";
		p_company = "";
		p_productName = "";
		p_productVersion = "";
		p_productLicense = "";
		p_description = "";
		p_contactInfo = "";
	}
	public XplCopyright(String n_copyrightMessage){
		p_copyrightMessage = "";
		p_company = "";
		p_productName = "";
		p_productVersion = "";
		p_productLicense = "";
		p_description = "";
		p_contactInfo = "";
		set_copyrightMessage(n_copyrightMessage);
	}
	public XplCopyright(String n_copyrightMessage, String n_company, String n_productName, String n_productVersion, String n_productLicense, String n_description, String n_contactInfo){
		set_copyrightMessage(n_copyrightMessage);
		set_company(n_company);
		set_productName(n_productName);
		set_productVersion(n_productVersion);
		set_productLicense(n_productLicense);
		set_description(n_description);
		set_contactInfo(n_contactInfo);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplCopyright copy = new XplCopyright();
		copy.set_copyrightMessage(this.p_copyrightMessage);
		copy.set_company(this.p_company);
		copy.set_productName(this.p_productName);
		copy.set_productVersion(this.p_productVersion);
		copy.set_productLicense(this.p_productLicense);
		copy.set_description(this.p_description);
		copy.set_contactInfo(this.p_contactInfo);
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplCopyright;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_copyrightMessage != "")
			writer.WriteAttributeString( "copyrightMessage" ,CodeDOM_Utils.Att_ToString(p_copyrightMessage) );
		if(p_company != "")
			writer.WriteAttributeString( "company" ,CodeDOM_Utils.Att_ToString(p_company) );
		if(p_productName != "")
			writer.WriteAttributeString( "productName" ,CodeDOM_Utils.Att_ToString(p_productName) );
		if(p_productVersion != "")
			writer.WriteAttributeString( "productVersion" ,CodeDOM_Utils.Att_ToString(p_productVersion) );
		if(p_productLicense != "")
			writer.WriteAttributeString( "productLicense" ,CodeDOM_Utils.Att_ToString(p_productLicense) );
		if(p_description != "")
			writer.WriteAttributeString( "description" ,CodeDOM_Utils.Att_ToString(p_description) );
		if(p_contactInfo != "")
			writer.WriteAttributeString( "contactInfo" ,CodeDOM_Utils.Att_ToString(p_contactInfo) );
		//Escribo recursivamente cada elemento hijo
		//Cierro el elemento
		writer.WriteEndElement();
		return result;
	}

	public XplNode Read(XplReader reader) throws ParseException, CodeDOM_Exception, IOException {
		this.set_Name( reader.Name() );
		//Lectura de Atributos
		if( reader.HasAttributes() ){
			for(int i=1; i <= reader.AttributeCount() ; i++){
				reader.MoveToAttribute(i);
				if(reader.Name().equals("copyrightMessage")){
					this.set_copyrightMessage(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("company")){
					this.set_company(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("productName")){
					this.set_productName(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("productVersion")){
					this.set_productVersion(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("productLicense")){
					this.set_productLicense(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("description")){
					this.set_description(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("contactInfo")){
					this.set_contactInfo(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else{
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Atributo '"+reader.Name()+"' invalido en elemento '"+this.get_Name()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
				case XmlNodeType.TEXT:
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".No se esperaba texto o elemento hijo en este nodo.");
				case XmlNodeType.ENDELEMENT:
					break;
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
	public String get_copyrightMessage(){
		return p_copyrightMessage;
	}
	public String get_company(){
		return p_company;
	}
	public String get_productName(){
		return p_productName;
	}
	public String get_productVersion(){
		return p_productVersion;
	}
	public String get_productLicense(){
		return p_productLicense;
	}
	public String get_description(){
		return p_description;
	}
	public String get_contactInfo(){
		return p_contactInfo;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_copyrightMessage(String new_copyrightMessage){
		String back_copyrightMessage = p_copyrightMessage;
		p_copyrightMessage = new_copyrightMessage;
		return back_copyrightMessage;
	}
	public String set_company(String new_company){
		String back_company = p_company;
		p_company = new_company;
		return back_company;
	}
	public String set_productName(String new_productName){
		String back_productName = p_productName;
		p_productName = new_productName;
		return back_productName;
	}
	public String set_productVersion(String new_productVersion){
		String back_productVersion = p_productVersion;
		p_productVersion = new_productVersion;
		return back_productVersion;
	}
	public String set_productLicense(String new_productLicense){
		String back_productLicense = p_productLicense;
		p_productLicense = new_productLicense;
		return back_productLicense;
	}
	public String set_description(String new_description){
		String back_description = p_description;
		p_description = new_description;
		return back_description;
	}
	public String set_contactInfo(String new_contactInfo){
		String back_contactInfo = p_contactInfo;
		p_contactInfo = new_contactInfo;
		return back_contactInfo;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

