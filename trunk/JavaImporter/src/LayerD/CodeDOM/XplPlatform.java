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

public class XplPlatform extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_name;
	String p_version;
	int p_match;
	String p_customMatcher;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplPlatform(){
		p_name = "";
		p_version = "";
		p_match = XplPlatformMatch_enum.LIKE;
		p_customMatcher = "";
	}
	public XplPlatform(String n_name, int n_match){
		p_name = "";
		p_version = "";
		p_match = XplPlatformMatch_enum.LIKE;
		p_customMatcher = "";
		set_name(n_name);
		set_match(n_match);
	}
	public XplPlatform(String n_name, String n_version, int n_match, String n_customMatcher){
		set_name(n_name);
		set_version(n_version);
		set_match(n_match);
		set_customMatcher(n_customMatcher);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplPlatform copy = new XplPlatform();
		copy.set_name(this.p_name);
		copy.set_version(this.p_version);
		copy.set_match(this.p_match);
		copy.set_customMatcher(this.p_customMatcher);
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplPlatform;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,CodeDOM_Utils.Att_ToString(p_name) );
		if(p_version != "")
			writer.WriteAttributeString( "version" ,CodeDOM_Utils.Att_ToString(p_version) );
		if(p_match != XplPlatformMatch_enum.LIKE)
			writer.WriteAttributeString( "match" , CodeDOM_STV.XPLPLATFORMMATCH_ENUM[(int)p_match] );
		if(p_customMatcher != "")
			writer.WriteAttributeString( "customMatcher" ,CodeDOM_Utils.Att_ToString(p_customMatcher) );
		//Escribo recursivamente cada elemento hijo
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
				if(reader.Name().equals("name")){
					this.set_name(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("version")){
					this.set_version(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("match")){
					tmpStr=CodeDOM_Utils.StringAtt_To_STRING(reader.Value());
					count=0;flag=false;
					for(int n=0;n<CodeDOM_STV.XPLPLATFORMMATCH_ENUM.length;n++){
						String str = CodeDOM_STV.XPLPLATFORMMATCH_ENUM[n];
						if(str.equals(tmpStr)){this.set_match(count);flag=true;break;}
						count++;
					}
					// if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Valor invalido del atributo 'match' en elemento '"+this.get_Name()+"'.");
				}
				else if(reader.Name().equals("customMatcher")){
					this.set_customMatcher(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
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
	public int get_match(){
		return p_match;
	}
	public String get_customMatcher(){
		return p_customMatcher;
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
	public int set_match(int new_match){
		int back_match = p_match;
		p_match = new_match;
		return back_match;
	}
	public String set_customMatcher(String new_customMatcher){
		String back_customMatcher = p_customMatcher;
		p_customMatcher = new_customMatcher;
		return back_customMatcher;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

