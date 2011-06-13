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

public class XplLayerDCompiler extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_name;
	String p_version;
	String p_companyName;
	String p_copyright;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplLayerDCompiler(){
		p_name = "";
		p_version = "";
		p_companyName = "";
		p_copyright = "";
	}
	public XplLayerDCompiler(String n_name, String n_version){
		p_name = "";
		p_version = "";
		p_companyName = "";
		p_copyright = "";
		set_name(n_name);
		set_version(n_version);
	}
	public XplLayerDCompiler(String n_name, String n_version, String n_companyName, String n_copyright){
		set_name(n_name);
		set_version(n_version);
		set_companyName(n_companyName);
		set_copyright(n_copyright);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplLayerDCompiler copy = new XplLayerDCompiler();
		copy.set_name(this.p_name);
		copy.set_version(this.p_version);
		copy.set_companyName(this.p_companyName);
		copy.set_copyright(this.p_copyright);
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplLayerDCompiler;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,CodeDOM_Utils.Att_ToString(p_name) );
		if(p_version != "")
			writer.WriteAttributeString( "version" ,CodeDOM_Utils.Att_ToString(p_version) );
		if(p_companyName != "")
			writer.WriteAttributeString( "companyName" ,CodeDOM_Utils.Att_ToString(p_companyName) );
		if(p_copyright != "")
			writer.WriteAttributeString( "copyright" ,CodeDOM_Utils.Att_ToString(p_copyright) );
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
				else if(reader.Name().equals("version")){
					this.set_version(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("companyName")){
					this.set_companyName(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("copyright")){
					this.set_copyright(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
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
	public String get_version(){
		return p_version;
	}
	public String get_companyName(){
		return p_companyName;
	}
	public String get_copyright(){
		return p_copyright;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_name(String new_name){
		String back_name = p_name;
		p_name = new_name;
		return back_name;
	}
	public String set_version(String new_version){
		String back_version = p_version;
		p_version = new_version;
		return back_version;
	}
	public String set_companyName(String new_companyName){
		String back_companyName = p_companyName;
		p_companyName = new_companyName;
		return back_companyName;
	}
	public String set_copyright(String new_copyright){
		String back_copyright = p_copyright;
		p_copyright = new_copyright;
		return back_copyright;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

