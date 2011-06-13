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

public class XplClassfactoryData extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_typeFullName;
	boolean p_isInterface;
	boolean p_isInteractive;
	boolean p_active;
	String p_moduleFileName;
	String p_platforms;
	String p_zoeDocFileName;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplClassfactoryData(){
		p_typeFullName = "";
		p_isInterface = false;
		p_isInteractive = false;
		p_active = true;
		p_moduleFileName = "";
		p_platforms = "";
		p_zoeDocFileName = "";
	}
	public XplClassfactoryData(String n_typeFullName, boolean n_isInterface, boolean n_isInteractive, boolean n_active, String n_moduleFileName, String n_zoeDocFileName){
		p_typeFullName = "";
		p_isInterface = false;
		p_isInteractive = false;
		p_active = true;
		p_moduleFileName = "";
		p_platforms = "";
		p_zoeDocFileName = "";
		set_typeFullName(n_typeFullName);
		set_isInterface(n_isInterface);
		set_isInteractive(n_isInteractive);
		set_active(n_active);
		set_moduleFileName(n_moduleFileName);
		set_zoeDocFileName(n_zoeDocFileName);
	}
	public XplClassfactoryData(String n_typeFullName, boolean n_isInterface, boolean n_isInteractive, boolean n_active, String n_moduleFileName, String n_platforms, String n_zoeDocFileName){
		set_typeFullName(n_typeFullName);
		set_isInterface(n_isInterface);
		set_isInteractive(n_isInteractive);
		set_active(n_active);
		set_moduleFileName(n_moduleFileName);
		set_platforms(n_platforms);
		set_zoeDocFileName(n_zoeDocFileName);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplClassfactoryData copy = new XplClassfactoryData();
		copy.set_typeFullName(this.p_typeFullName);
		copy.set_isInterface(this.p_isInterface);
		copy.set_isInteractive(this.p_isInteractive);
		copy.set_active(this.p_active);
		copy.set_moduleFileName(this.p_moduleFileName);
		copy.set_platforms(this.p_platforms);
		copy.set_zoeDocFileName(this.p_zoeDocFileName);
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplClassfactoryData;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_typeFullName != "")
			writer.WriteAttributeString( "typeFullName" ,CodeDOM_Utils.Att_ToString(p_typeFullName) );
		if(p_isInterface != false)
			writer.WriteAttributeString( "isInterface" ,CodeDOM_Utils.Att_ToString(p_isInterface) );
		if(p_isInteractive != false)
			writer.WriteAttributeString( "isInteractive" ,CodeDOM_Utils.Att_ToString(p_isInteractive) );
		if(p_active != true)
			writer.WriteAttributeString( "active" ,CodeDOM_Utils.Att_ToString(p_active) );
		if(p_moduleFileName != "")
			writer.WriteAttributeString( "moduleFileName" ,CodeDOM_Utils.Att_ToString(p_moduleFileName) );
		if(p_platforms != "")
			writer.WriteAttributeString( "platforms" ,CodeDOM_Utils.Att_ToString(p_platforms) );
		if(p_zoeDocFileName != "")
			writer.WriteAttributeString( "zoeDocFileName" ,CodeDOM_Utils.Att_ToString(p_zoeDocFileName) );
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
				if(reader.Name().equals("typeFullName")){
					this.set_typeFullName(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("isInterface")){
					this.set_isInterface(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("isInteractive")){
					this.set_isInteractive(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("active")){
					this.set_active(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("moduleFileName")){
					this.set_moduleFileName(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("platforms")){
					this.set_platforms(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("zoeDocFileName")){
					this.set_zoeDocFileName(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
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
	public String get_typeFullName(){
		return p_typeFullName;
	}
	public boolean get_isInterface(){
		return p_isInterface;
	}
	public boolean get_isInteractive(){
		return p_isInteractive;
	}
	public boolean get_active(){
		return p_active;
	}
	public String get_moduleFileName(){
		return p_moduleFileName;
	}
	public String get_platforms(){
		return p_platforms;
	}
	public String get_zoeDocFileName(){
		return p_zoeDocFileName;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_typeFullName(String new_typeFullName){
		String back_typeFullName = p_typeFullName;
		p_typeFullName = new_typeFullName;
		return back_typeFullName;
	}
	public boolean set_isInterface(boolean new_isInterface){
		boolean back_isInterface = p_isInterface;
		p_isInterface = new_isInterface;
		return back_isInterface;
	}
	public boolean set_isInteractive(boolean new_isInteractive){
		boolean back_isInteractive = p_isInteractive;
		p_isInteractive = new_isInteractive;
		return back_isInteractive;
	}
	public boolean set_active(boolean new_active){
		boolean back_active = p_active;
		p_active = new_active;
		return back_active;
	}
	public String set_moduleFileName(String new_moduleFileName){
		String back_moduleFileName = p_moduleFileName;
		p_moduleFileName = new_moduleFileName;
		return back_moduleFileName;
	}
	public String set_platforms(String new_platforms){
		String back_platforms = p_platforms;
		p_platforms = new_platforms;
		return back_platforms;
	}
	public String set_zoeDocFileName(String new_zoeDocFileName){
		String back_zoeDocFileName = p_zoeDocFileName;
		p_zoeDocFileName = new_zoeDocFileName;
		return back_zoeDocFileName;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

