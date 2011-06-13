/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 17/04/2009 10:26:34
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

public class XplPlatformAlias extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_standardName;
	String p_standardVersion;
	String p_configAlias;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplPlatformAlias(){
		p_standardName = "";
		p_standardVersion = "";
		p_configAlias = "";
	}
	public XplPlatformAlias(String n_standardName, String n_configAlias){
		p_standardName = "";
		p_standardVersion = "";
		p_configAlias = "";
		set_standardName(n_standardName);
		set_configAlias(n_configAlias);
	}
	public XplPlatformAlias(String n_standardName, String n_standardVersion, String n_configAlias){
		set_standardName(n_standardName);
		set_standardVersion(n_standardVersion);
		set_configAlias(n_configAlias);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplPlatformAlias copy = new XplPlatformAlias();
		copy.set_standardName(this.p_standardName);
		copy.set_standardVersion(this.p_standardVersion);
		copy.set_configAlias(this.p_configAlias);
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplPlatformAlias;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_standardName != "")
			writer.WriteAttributeString( "standardName" ,CodeDOM_Utils.Att_ToString(p_standardName) );
		if(p_standardVersion != "")
			writer.WriteAttributeString( "standardVersion" ,CodeDOM_Utils.Att_ToString(p_standardVersion) );
		if(p_configAlias != "")
			writer.WriteAttributeString( "configAlias" ,CodeDOM_Utils.Att_ToString(p_configAlias) );
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
				if(reader.Name().equals("standardName")){
					this.set_standardName(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("standardVersion")){
					this.set_standardVersion(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("configAlias")){
					this.set_configAlias(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
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
	public String get_standardName(){
		return p_standardName;
	}
	public String get_standardVersion(){
		return p_standardVersion;
	}
	public String get_configAlias(){
		return p_configAlias;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_standardName(String new_standardName){
		String back_standardName = p_standardName;
		p_standardName = new_standardName;
		return back_standardName;
	}
	public String set_standardVersion(String new_standardVersion){
		String back_standardVersion = p_standardVersion;
		p_standardVersion = new_standardVersion;
		return back_standardVersion;
	}
	public String set_configAlias(String new_configAlias){
		String back_configAlias = p_configAlias;
		p_configAlias = new_configAlias;
		return back_configAlias;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

