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

public class XplFileData extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_Autor;
	Date p_Date;
	Date p_Time;
	String p_Description;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplFileData(){
		p_Autor = "";
		p_Date = CodeDOM_Utils.GetDefaultDate();
		p_Time = CodeDOM_Utils.GetDefaultDate();
		p_Description = "";
	}
	public XplFileData(String n_Autor, Date n_Date, Date n_Time, String n_Description){
		set_Autor(n_Autor);
		set_Date(n_Date);
		set_Time(n_Time);
		set_Description(n_Description);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplFileData copy = new XplFileData();
		copy.set_Autor(this.p_Autor);
		copy.set_Date(this.p_Date);
		copy.set_Time(this.p_Time);
		copy.set_Description(this.p_Description);
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplFileData;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_Autor != "")
			writer.WriteAttributeString( "Autor" ,CodeDOM_Utils.Att_ToString(p_Autor) );
		if(p_Date != CodeDOM_Utils.GetDefaultDate())
			writer.WriteAttributeString( "Date" ,CodeDOM_Utils.Att_ToString(p_Date) );
		if(p_Time != CodeDOM_Utils.GetDefaultDate())
			writer.WriteAttributeString( "Time" ,CodeDOM_Utils.Att_ToString(p_Time) );
		if(p_Description != "")
			writer.WriteAttributeString( "Description" ,CodeDOM_Utils.Att_ToString(p_Description) );
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
				if(reader.Name().equals("Autor")){
					this.set_Autor(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("Date")){
					this.set_Date(CodeDOM_Utils.StringAtt_To_DATE(reader.Value()));
				}
				else if(reader.Name().equals("Time")){
					this.set_Time(CodeDOM_Utils.StringAtt_To_DATE(reader.Value()));
				}
				else if(reader.Name().equals("Description")){
					this.set_Description(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
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
	public String get_Autor(){
		return p_Autor;
	}
	public Date get_Date(){
		return p_Date;
	}
	public Date get_Time(){
		return p_Time;
	}
	public String get_Description(){
		return p_Description;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_Autor(String new_Autor){
		String back_Autor = p_Autor;
		p_Autor = new_Autor;
		return back_Autor;
	}
	public Date set_Date(Date new_Date){
		Date back_Date = p_Date;
		p_Date = new_Date;
		return back_Date;
	}
	public Date set_Time(Date new_Time){
		Date back_Time = p_Time;
		p_Time = new_Time;
		return back_Time;
	}
	public String set_Description(String new_Description){
		String back_Description = p_Description;
		p_Description = new_Description;
		return back_Description;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

