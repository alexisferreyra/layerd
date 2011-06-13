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

public class XplLanguage extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_Source;
	String p_StandardDefinitionFile;
	String p_SourceVersion;
	String p_Destination;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplLanguage(){
		p_Source = "";
		p_StandardDefinitionFile = "";
		p_SourceVersion = "";
		p_Destination = "";
	}
	public XplLanguage(String n_Source){
		p_Source = "";
		p_StandardDefinitionFile = "";
		p_SourceVersion = "";
		p_Destination = "";
		set_Source(n_Source);
	}
	public XplLanguage(String n_Source, String n_StandardDefinitionFile, String n_SourceVersion, String n_Destination){
		set_Source(n_Source);
		set_StandardDefinitionFile(n_StandardDefinitionFile);
		set_SourceVersion(n_SourceVersion);
		set_Destination(n_Destination);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplLanguage copy = new XplLanguage();
		copy.set_Source(this.p_Source);
		copy.set_StandardDefinitionFile(this.p_StandardDefinitionFile);
		copy.set_SourceVersion(this.p_SourceVersion);
		copy.set_Destination(this.p_Destination);
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplLanguage;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_Source != "")
			writer.WriteAttributeString( "Source" ,CodeDOM_Utils.Att_ToString(p_Source) );
		if(p_StandardDefinitionFile != "")
			writer.WriteAttributeString( "StandardDefinitionFile" ,CodeDOM_Utils.Att_ToString(p_StandardDefinitionFile) );
		if(p_SourceVersion != "")
			writer.WriteAttributeString( "SourceVersion" ,CodeDOM_Utils.Att_ToString(p_SourceVersion) );
		if(p_Destination != "")
			writer.WriteAttributeString( "Destination" ,CodeDOM_Utils.Att_ToString(p_Destination) );
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
				if(reader.Name().equals("Source")){
					this.set_Source(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("StandardDefinitionFile")){
					this.set_StandardDefinitionFile(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("SourceVersion")){
					this.set_SourceVersion(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("Destination")){
					this.set_Destination(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
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
	public String get_Source(){
		return p_Source;
	}
	public String get_StandardDefinitionFile(){
		return p_StandardDefinitionFile;
	}
	public String get_SourceVersion(){
		return p_SourceVersion;
	}
	public String get_Destination(){
		return p_Destination;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_Source(String new_Source){
		String back_Source = p_Source;
		p_Source = new_Source;
		return back_Source;
	}
	public String set_StandardDefinitionFile(String new_StandardDefinitionFile){
		String back_StandardDefinitionFile = p_StandardDefinitionFile;
		p_StandardDefinitionFile = new_StandardDefinitionFile;
		return back_StandardDefinitionFile;
	}
	public String set_SourceVersion(String new_SourceVersion){
		String back_SourceVersion = p_SourceVersion;
		p_SourceVersion = new_SourceVersion;
		return back_SourceVersion;
	}
	public String set_Destination(String new_Destination){
		String back_Destination = p_Destination;
		p_Destination = new_Destination;
		return back_Destination;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

