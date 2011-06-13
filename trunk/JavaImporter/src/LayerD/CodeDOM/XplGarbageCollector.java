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

public class XplGarbageCollector extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_name;
	String p_description;
	String p_sourceFile;
	String p_xplCompilerData;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplGarbageCollector(){
		p_name = "";
		p_description = "";
		p_sourceFile = "";
		p_xplCompilerData = "";
	}
	public XplGarbageCollector(String n_name){
		p_name = "";
		p_description = "";
		p_sourceFile = "";
		p_xplCompilerData = "";
		set_name(n_name);
	}
	public XplGarbageCollector(String n_name, String n_description, String n_sourceFile, String n_xplCompilerData){
		set_name(n_name);
		set_description(n_description);
		set_sourceFile(n_sourceFile);
		set_xplCompilerData(n_xplCompilerData);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplGarbageCollector copy = new XplGarbageCollector();
		copy.set_name(this.p_name);
		copy.set_description(this.p_description);
		copy.set_sourceFile(this.p_sourceFile);
		copy.set_xplCompilerData(this.p_xplCompilerData);
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplGarbageCollector;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,CodeDOM_Utils.Att_ToString(p_name) );
		if(p_description != "")
			writer.WriteAttributeString( "description" ,CodeDOM_Utils.Att_ToString(p_description) );
		if(p_sourceFile != "")
			writer.WriteAttributeString( "sourceFile" ,CodeDOM_Utils.Att_ToString(p_sourceFile) );
		if(p_xplCompilerData != "")
			writer.WriteAttributeString( "xplCompilerData" ,CodeDOM_Utils.Att_ToString(p_xplCompilerData) );
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
				if(reader.Name().equals("name")){
					this.set_name(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("description")){
					this.set_description(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("sourceFile")){
					this.set_sourceFile(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("xplCompilerData")){
					this.set_xplCompilerData(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
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
	public String get_name(){
		return p_name;
	}
	public String get_description(){
		return p_description;
	}
	public String get_sourceFile(){
		return p_sourceFile;
	}
	public String get_xplCompilerData(){
		return p_xplCompilerData;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_name(String new_name){
		String back_name = p_name;
		p_name = new_name;
		return back_name;
	}
	public String set_description(String new_description){
		String back_description = p_description;
		p_description = new_description;
		return back_description;
	}
	public String set_sourceFile(String new_sourceFile){
		String back_sourceFile = p_sourceFile;
		p_sourceFile = new_sourceFile;
		return back_sourceFile;
	}
	public String set_xplCompilerData(String new_xplCompilerData){
		String back_xplCompilerData = p_xplCompilerData;
		p_xplCompilerData = new_xplCompilerData;
		return back_xplCompilerData;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

