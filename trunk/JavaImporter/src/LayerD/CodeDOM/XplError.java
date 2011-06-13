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

public class XplError extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_str;
	int p_level;
	String p_sourcefile;
	String p_sourcepos;
	int p_sourceType;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplError(){
		p_str = "";
		p_level = 1;
		p_sourcefile = "";
		p_sourcepos = "";
		p_sourceType = XplErrorsourcetype_enum.XPL_DOC;
	}
	public XplError(String n_str, int n_level, int n_sourceType){
		p_str = "";
		p_level = 1;
		p_sourcefile = "";
		p_sourcepos = "";
		p_sourceType = XplErrorsourcetype_enum.XPL_DOC;
		set_str(n_str);
		set_level(n_level);
		set_sourceType(n_sourceType);
	}
	public XplError(String n_str, int n_level, String n_sourcefile, String n_sourcepos, int n_sourceType){
		set_str(n_str);
		set_level(n_level);
		set_sourcefile(n_sourcefile);
		set_sourcepos(n_sourcepos);
		set_sourceType(n_sourceType);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplError copy = new XplError();
		copy.set_str(this.p_str);
		copy.set_level(this.p_level);
		copy.set_sourcefile(this.p_sourcefile);
		copy.set_sourcepos(this.p_sourcepos);
		copy.set_sourceType(this.p_sourceType);
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplError;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_str != "")
			writer.WriteAttributeString( "str" ,CodeDOM_Utils.Att_ToString(p_str) );
		if(p_level != 1)
			writer.WriteAttributeString( "level" ,CodeDOM_Utils.Att_ToString(p_level) );
		if(p_sourcefile != "")
			writer.WriteAttributeString( "sourcefile" ,CodeDOM_Utils.Att_ToString(p_sourcefile) );
		if(p_sourcepos != "")
			writer.WriteAttributeString( "sourcepos" ,CodeDOM_Utils.Att_ToString(p_sourcepos) );
		if(p_sourceType != XplErrorsourcetype_enum.XPL_DOC)
			writer.WriteAttributeString( "sourceType" , CodeDOM_STV.XPLERRORSOURCETYPE_ENUM[(int)p_sourceType] );
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
				if(reader.Name().equals("str")){
					this.set_str(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("level")){
					this.set_level(CodeDOM_Utils.StringAtt_To_INT(reader.Value()));
				}
				else if(reader.Name().equals("sourcefile")){
					this.set_sourcefile(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("sourcepos")){
					this.set_sourcepos(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("sourceType")){
					tmpStr=CodeDOM_Utils.StringAtt_To_STRING(reader.Value());
					count=0;flag=false;
					for(int n=0;n<CodeDOM_STV.XPLERRORSOURCETYPE_ENUM.length;n++){
						String str = CodeDOM_STV.XPLERRORSOURCETYPE_ENUM[n];
						if(str.equals(tmpStr)){this.set_sourceType(count);flag=true;break;}
						count++;
					}
					// if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Valor invalido del atributo 'sourceType' en elemento '"+this.get_Name()+"'.");
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
	public String get_str(){
		return p_str;
	}
	public int get_level(){
		return p_level;
	}
	public String get_sourcefile(){
		return p_sourcefile;
	}
	public String get_sourcepos(){
		return p_sourcepos;
	}
	public int get_sourceType(){
		return p_sourceType;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_str(String new_str){
		String back_str = p_str;
		p_str = new_str;
		return back_str;
	}
	public int set_level(int new_level){
		int back_level = p_level;
		p_level = new_level;
		return back_level;
	}
	public String set_sourcefile(String new_sourcefile){
		String back_sourcefile = p_sourcefile;
		p_sourcefile = new_sourcefile;
		return back_sourcefile;
	}
	public String set_sourcepos(String new_sourcepos){
		String back_sourcepos = p_sourcepos;
		p_sourcepos = new_sourcepos;
		return back_sourcepos;
	}
	public int set_sourceType(int new_sourceType){
		int back_sourceType = p_sourceType;
		p_sourceType = new_sourceType;
		return back_sourceType;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

