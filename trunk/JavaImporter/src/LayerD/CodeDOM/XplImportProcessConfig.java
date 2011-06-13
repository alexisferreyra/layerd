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

public class XplImportProcessConfig extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_OutputFolder;
	String p_OutputPrefix;
	String p_ErrorsFileName;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplImportProcessConfig(){
		p_OutputFolder = "";
		p_OutputPrefix = "";
		p_ErrorsFileName = "";
	}
	public XplImportProcessConfig(String n_OutputFolder, String n_ErrorsFileName){
		p_OutputFolder = "";
		p_OutputPrefix = "";
		p_ErrorsFileName = "";
		set_OutputFolder(n_OutputFolder);
		set_ErrorsFileName(n_ErrorsFileName);
	}
	public XplImportProcessConfig(String n_OutputFolder, String n_OutputPrefix, String n_ErrorsFileName){
		set_OutputFolder(n_OutputFolder);
		set_OutputPrefix(n_OutputPrefix);
		set_ErrorsFileName(n_ErrorsFileName);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplImportProcessConfig copy = new XplImportProcessConfig();
		copy.set_OutputFolder(this.p_OutputFolder);
		copy.set_OutputPrefix(this.p_OutputPrefix);
		copy.set_ErrorsFileName(this.p_ErrorsFileName);
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplImportProcessConfig;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_OutputFolder != "")
			writer.WriteAttributeString( "OutputFolder" ,CodeDOM_Utils.Att_ToString(p_OutputFolder) );
		if(p_OutputPrefix != "")
			writer.WriteAttributeString( "OutputPrefix" ,CodeDOM_Utils.Att_ToString(p_OutputPrefix) );
		if(p_ErrorsFileName != "")
			writer.WriteAttributeString( "ErrorsFileName" ,CodeDOM_Utils.Att_ToString(p_ErrorsFileName) );
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
				if(reader.Name().equals("OutputFolder")){
					this.set_OutputFolder(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("OutputPrefix")){
					this.set_OutputPrefix(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("ErrorsFileName")){
					this.set_ErrorsFileName(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
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
	public String get_OutputFolder(){
		return p_OutputFolder;
	}
	public String get_OutputPrefix(){
		return p_OutputPrefix;
	}
	public String get_ErrorsFileName(){
		return p_ErrorsFileName;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_OutputFolder(String new_OutputFolder){
		String back_OutputFolder = p_OutputFolder;
		p_OutputFolder = new_OutputFolder;
		return back_OutputFolder;
	}
	public String set_OutputPrefix(String new_OutputPrefix){
		String back_OutputPrefix = p_OutputPrefix;
		p_OutputPrefix = new_OutputPrefix;
		return back_OutputPrefix;
	}
	public String set_ErrorsFileName(String new_ErrorsFileName){
		String back_ErrorsFileName = p_ErrorsFileName;
		p_ErrorsFileName = new_ErrorsFileName;
		return back_ErrorsFileName;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

