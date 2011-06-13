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

public class XplProperty extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_name;
	String p_getfunction;
	String p_setfunction;
	String p_internalname;
	String p_externalname;
	boolean p_donotrender;
	int p_access;
	int p_storage;
	boolean p_isfactory;
	boolean p_isconst;
	boolean p_isexec;
	boolean p_virtual;
	boolean p_nonvirtual;
	boolean p_override;
	boolean p_new;
	boolean p_final;
	boolean p_abstract;
	boolean p_external;
	String p_doc;
	String p_helpURL;
	String p_ldsrc;
	boolean p_iny;
	String p_inydata;
	String p_inyby;
	String p_lddata;
	//Variables para Elementos de Secuencia
	XplType p_type;
	XplFunctionBody p_body;
	XplDocumentation p_documentation;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplProperty(){
		p_name = "";
		p_getfunction = "";
		p_setfunction = "";
		p_internalname = "";
		p_externalname = "";
		p_donotrender = false;
		p_access = XplAccesstype_enum.PRIVATE;
		p_storage = XplVarstorage_enum.AUTO;
		p_isfactory = false;
		p_isconst = false;
		p_isexec = false;
		p_virtual = false;
		p_nonvirtual = false;
		p_override = false;
		p_new = false;
		p_final = false;
		p_abstract = false;
		p_external = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_type=null;
		p_body=null;
		p_documentation=null;
	}
	public XplProperty(String n_name, boolean n_donotrender, int n_access, int n_storage, boolean n_isfactory, boolean n_isconst, boolean n_isexec, boolean n_virtual, boolean n_nonvirtual, boolean n_override, boolean n_new, boolean n_final, boolean n_abstract, boolean n_external){
		p_name = "";
		p_getfunction = "";
		p_setfunction = "";
		p_internalname = "";
		p_externalname = "";
		p_donotrender = false;
		p_access = XplAccesstype_enum.PRIVATE;
		p_storage = XplVarstorage_enum.AUTO;
		p_isfactory = false;
		p_isconst = false;
		p_isexec = false;
		p_virtual = false;
		p_nonvirtual = false;
		p_override = false;
		p_new = false;
		p_final = false;
		p_abstract = false;
		p_external = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_name(n_name);
		set_donotrender(n_donotrender);
		set_access(n_access);
		set_storage(n_storage);
		set_isfactory(n_isfactory);
		set_isconst(n_isconst);
		set_isexec(n_isexec);
		set_virtual(n_virtual);
		set_nonvirtual(n_nonvirtual);
		set_override(n_override);
		set_new(n_new);
		set_final(n_final);
		set_abstract(n_abstract);
		set_external(n_external);
		p_type=null;
		p_body=null;
		p_documentation=null;
	}
	public XplProperty(XplType n_type){
		p_name = "";
		p_getfunction = "";
		p_setfunction = "";
		p_internalname = "";
		p_externalname = "";
		p_donotrender = false;
		p_access = XplAccesstype_enum.PRIVATE;
		p_storage = XplVarstorage_enum.AUTO;
		p_isfactory = false;
		p_isconst = false;
		p_isexec = false;
		p_virtual = false;
		p_nonvirtual = false;
		p_override = false;
		p_new = false;
		p_final = false;
		p_abstract = false;
		p_external = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_type=null;
		p_body=null;
		p_documentation=null;
		set_type(n_type);
	}
	public XplProperty(String n_name, boolean n_donotrender, int n_access, int n_storage, boolean n_isfactory, boolean n_isconst, boolean n_isexec, boolean n_virtual, boolean n_nonvirtual, boolean n_override, boolean n_new, boolean n_final, boolean n_abstract, boolean n_external, XplType n_type){
		p_name = "";
		p_getfunction = "";
		p_setfunction = "";
		p_internalname = "";
		p_externalname = "";
		p_donotrender = false;
		p_access = XplAccesstype_enum.PRIVATE;
		p_storage = XplVarstorage_enum.AUTO;
		p_isfactory = false;
		p_isconst = false;
		p_isexec = false;
		p_virtual = false;
		p_nonvirtual = false;
		p_override = false;
		p_new = false;
		p_final = false;
		p_abstract = false;
		p_external = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_name(n_name);
		set_donotrender(n_donotrender);
		set_access(n_access);
		set_storage(n_storage);
		set_isfactory(n_isfactory);
		set_isconst(n_isconst);
		set_isexec(n_isexec);
		set_virtual(n_virtual);
		set_nonvirtual(n_nonvirtual);
		set_override(n_override);
		set_new(n_new);
		set_final(n_final);
		set_abstract(n_abstract);
		set_external(n_external);
		p_type=null;
		p_body=null;
		p_documentation=null;
		set_type(n_type);
	}
	public XplProperty(String n_name, String n_getfunction, String n_setfunction, String n_internalname, String n_externalname, boolean n_donotrender, int n_access, int n_storage, boolean n_isfactory, boolean n_isconst, boolean n_isexec, boolean n_virtual, boolean n_nonvirtual, boolean n_override, boolean n_new, boolean n_final, boolean n_abstract, boolean n_external, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata){
		set_name(n_name);
		set_getfunction(n_getfunction);
		set_setfunction(n_setfunction);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_donotrender(n_donotrender);
		set_access(n_access);
		set_storage(n_storage);
		set_isfactory(n_isfactory);
		set_isconst(n_isconst);
		set_isexec(n_isexec);
		set_virtual(n_virtual);
		set_nonvirtual(n_nonvirtual);
		set_override(n_override);
		set_new(n_new);
		set_final(n_final);
		set_abstract(n_abstract);
		set_external(n_external);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_type=null;
		p_body=null;
		p_documentation=null;
	}
	public XplProperty(XplType n_type, XplFunctionBody n_body, XplDocumentation n_documentation){
		p_name = "";
		p_getfunction = "";
		p_setfunction = "";
		p_internalname = "";
		p_externalname = "";
		p_donotrender = false;
		p_access = XplAccesstype_enum.PRIVATE;
		p_storage = XplVarstorage_enum.AUTO;
		p_isfactory = false;
		p_isconst = false;
		p_isexec = false;
		p_virtual = false;
		p_nonvirtual = false;
		p_override = false;
		p_new = false;
		p_final = false;
		p_abstract = false;
		p_external = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_type=null;
		p_body=null;
		p_documentation=null;
		set_type(n_type);
		set_body(n_body);
		set_documentation(n_documentation);
	}
	public XplProperty(String n_name, String n_getfunction, String n_setfunction, String n_internalname, String n_externalname, boolean n_donotrender, int n_access, int n_storage, boolean n_isfactory, boolean n_isconst, boolean n_isexec, boolean n_virtual, boolean n_nonvirtual, boolean n_override, boolean n_new, boolean n_final, boolean n_abstract, boolean n_external, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplType n_type){
		set_name(n_name);
		set_getfunction(n_getfunction);
		set_setfunction(n_setfunction);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_donotrender(n_donotrender);
		set_access(n_access);
		set_storage(n_storage);
		set_isfactory(n_isfactory);
		set_isconst(n_isconst);
		set_isexec(n_isexec);
		set_virtual(n_virtual);
		set_nonvirtual(n_nonvirtual);
		set_override(n_override);
		set_new(n_new);
		set_final(n_final);
		set_abstract(n_abstract);
		set_external(n_external);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_name(n_name);
		set_donotrender(n_donotrender);
		set_access(n_access);
		set_storage(n_storage);
		set_isfactory(n_isfactory);
		set_isconst(n_isconst);
		set_isexec(n_isexec);
		set_virtual(n_virtual);
		set_nonvirtual(n_nonvirtual);
		set_override(n_override);
		set_new(n_new);
		set_final(n_final);
		set_abstract(n_abstract);
		set_external(n_external);
		p_type=null;
		p_body=null;
		p_documentation=null;
	}
	public XplProperty(String n_name, boolean n_donotrender, int n_access, int n_storage, boolean n_isfactory, boolean n_isconst, boolean n_isexec, boolean n_virtual, boolean n_nonvirtual, boolean n_override, boolean n_new, boolean n_final, boolean n_abstract, boolean n_external, XplType n_type, XplFunctionBody n_body, XplDocumentation n_documentation){
		p_name = "";
		p_getfunction = "";
		p_setfunction = "";
		p_internalname = "";
		p_externalname = "";
		p_donotrender = false;
		p_access = XplAccesstype_enum.PRIVATE;
		p_storage = XplVarstorage_enum.AUTO;
		p_isfactory = false;
		p_isconst = false;
		p_isexec = false;
		p_virtual = false;
		p_nonvirtual = false;
		p_override = false;
		p_new = false;
		p_final = false;
		p_abstract = false;
		p_external = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_name(n_name);
		set_donotrender(n_donotrender);
		set_access(n_access);
		set_storage(n_storage);
		set_isfactory(n_isfactory);
		set_isconst(n_isconst);
		set_isexec(n_isexec);
		set_virtual(n_virtual);
		set_nonvirtual(n_nonvirtual);
		set_override(n_override);
		set_new(n_new);
		set_final(n_final);
		set_abstract(n_abstract);
		set_external(n_external);
		p_type=null;
		p_body=null;
		p_documentation=null;
		set_type(n_type);
		set_body(n_body);
		set_documentation(n_documentation);
	}
	public XplProperty(String n_name, String n_getfunction, String n_setfunction, String n_internalname, String n_externalname, boolean n_donotrender, int n_access, int n_storage, boolean n_isfactory, boolean n_isconst, boolean n_isexec, boolean n_virtual, boolean n_nonvirtual, boolean n_override, boolean n_new, boolean n_final, boolean n_abstract, boolean n_external, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplType n_type, XplFunctionBody n_body, XplDocumentation n_documentation){
		set_name(n_name);
		set_getfunction(n_getfunction);
		set_setfunction(n_setfunction);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_donotrender(n_donotrender);
		set_access(n_access);
		set_storage(n_storage);
		set_isfactory(n_isfactory);
		set_isconst(n_isconst);
		set_isexec(n_isexec);
		set_virtual(n_virtual);
		set_nonvirtual(n_nonvirtual);
		set_override(n_override);
		set_new(n_new);
		set_final(n_final);
		set_abstract(n_abstract);
		set_external(n_external);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_type=null;
		p_body=null;
		p_documentation=null;
		set_type(n_type);
		set_body(n_body);
		set_documentation(n_documentation);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplProperty copy = new XplProperty();
		copy.set_name(this.p_name);
		copy.set_getfunction(this.p_getfunction);
		copy.set_setfunction(this.p_setfunction);
		copy.set_internalname(this.p_internalname);
		copy.set_externalname(this.p_externalname);
		copy.set_donotrender(this.p_donotrender);
		copy.set_access(this.p_access);
		copy.set_storage(this.p_storage);
		copy.set_isfactory(this.p_isfactory);
		copy.set_isconst(this.p_isconst);
		copy.set_isexec(this.p_isexec);
		copy.set_virtual(this.p_virtual);
		copy.set_nonvirtual(this.p_nonvirtual);
		copy.set_override(this.p_override);
		copy.set_new(this.p_new);
		copy.set_final(this.p_final);
		copy.set_abstract(this.p_abstract);
		copy.set_external(this.p_external);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_type!=null)copy.set_type((XplType)p_type.Clone());
		if(p_body!=null)copy.set_body((XplFunctionBody)p_body.Clone());
		if(p_documentation!=null)copy.set_documentation((XplDocumentation)p_documentation.Clone());
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplProperty;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,CodeDOM_Utils.Att_ToString(p_name) );
		if(p_getfunction != "")
			writer.WriteAttributeString( "getfunction" ,CodeDOM_Utils.Att_ToString(p_getfunction) );
		if(p_setfunction != "")
			writer.WriteAttributeString( "setfunction" ,CodeDOM_Utils.Att_ToString(p_setfunction) );
		if(p_internalname != "")
			writer.WriteAttributeString( "internalname" ,CodeDOM_Utils.Att_ToString(p_internalname) );
		if(p_externalname != "")
			writer.WriteAttributeString( "externalname" ,CodeDOM_Utils.Att_ToString(p_externalname) );
		if(p_donotrender != false)
			writer.WriteAttributeString( "donotrender" ,CodeDOM_Utils.Att_ToString(p_donotrender) );
		if(p_access != XplAccesstype_enum.PRIVATE)
			writer.WriteAttributeString( "access" , CodeDOM_STV.XPLACCESSTYPE_ENUM[(int)p_access] );
		if(p_storage != XplVarstorage_enum.AUTO)
			writer.WriteAttributeString( "storage" , CodeDOM_STV.XPLVARSTORAGE_ENUM[(int)p_storage] );
		if(p_isfactory != false)
			writer.WriteAttributeString( "isfactory" ,CodeDOM_Utils.Att_ToString(p_isfactory) );
		if(p_isconst != false)
			writer.WriteAttributeString( "isconst" ,CodeDOM_Utils.Att_ToString(p_isconst) );
		if(p_isexec != false)
			writer.WriteAttributeString( "isexec" ,CodeDOM_Utils.Att_ToString(p_isexec) );
		if(p_virtual != false)
			writer.WriteAttributeString( "virtual" ,CodeDOM_Utils.Att_ToString(p_virtual) );
		if(p_nonvirtual != false)
			writer.WriteAttributeString( "nonvirtual" ,CodeDOM_Utils.Att_ToString(p_nonvirtual) );
		if(p_override != false)
			writer.WriteAttributeString( "override" ,CodeDOM_Utils.Att_ToString(p_override) );
		if(p_new != false)
			writer.WriteAttributeString( "new" ,CodeDOM_Utils.Att_ToString(p_new) );
		if(p_final != false)
			writer.WriteAttributeString( "final" ,CodeDOM_Utils.Att_ToString(p_final) );
		if(p_abstract != false)
			writer.WriteAttributeString( "abstract" ,CodeDOM_Utils.Att_ToString(p_abstract) );
		if(p_external != false)
			writer.WriteAttributeString( "external" ,CodeDOM_Utils.Att_ToString(p_external) );
		if(p_doc != "")
			writer.WriteAttributeString( "doc" ,CodeDOM_Utils.Att_ToString(p_doc) );
		if(p_helpURL != "")
			writer.WriteAttributeString( "helpURL" ,CodeDOM_Utils.Att_ToString(p_helpURL) );
		if(p_ldsrc != "")
			writer.WriteAttributeString( "ldsrc" ,CodeDOM_Utils.Att_ToString(p_ldsrc) );
		if(p_iny != false)
			writer.WriteAttributeString( "iny" ,CodeDOM_Utils.Att_ToString(p_iny) );
		if(p_inydata != "")
			writer.WriteAttributeString( "inydata" ,CodeDOM_Utils.Att_ToString(p_inydata) );
		if(p_inyby != "")
			writer.WriteAttributeString( "inyby" ,CodeDOM_Utils.Att_ToString(p_inyby) );
		if(p_lddata != "")
			writer.WriteAttributeString( "lddata" ,CodeDOM_Utils.Att_ToString(p_lddata) );
		//Escribo recursivamente cada elemento hijo
		if(p_type!=null)if(!p_type.Write(writer))result=false;
		if(p_body!=null)if(!p_body.Write(writer))result=false;
		if(p_documentation!=null)if(!p_documentation.Write(writer))result=false;
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
				else if(reader.Name().equals("getfunction")){
					this.set_getfunction(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("setfunction")){
					this.set_setfunction(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("internalname")){
					this.set_internalname(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("externalname")){
					this.set_externalname(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("donotrender")){
					this.set_donotrender(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("access")){
					tmpStr=CodeDOM_Utils.StringAtt_To_STRING(reader.Value());
					count=0;flag=false;
					for(int n=0;n<CodeDOM_STV.XPLACCESSTYPE_ENUM.length;n++){
						String str = CodeDOM_STV.XPLACCESSTYPE_ENUM[n];
						if(str.equals(tmpStr)){this.set_access(count);flag=true;break;}
						count++;
					}
					// if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Valor invalido del atributo 'access' en elemento '"+this.get_Name()+"'.");
				}
				else if(reader.Name().equals("storage")){
					tmpStr=CodeDOM_Utils.StringAtt_To_STRING(reader.Value());
					count=0;flag=false;
					for(int n=0;n<CodeDOM_STV.XPLVARSTORAGE_ENUM.length;n++){
						String str = CodeDOM_STV.XPLVARSTORAGE_ENUM[n];
						if(str.equals(tmpStr)){this.set_storage(count);flag=true;break;}
						count++;
					}
					// if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Valor invalido del atributo 'storage' en elemento '"+this.get_Name()+"'.");
				}
				else if(reader.Name().equals("isfactory")){
					this.set_isfactory(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("isconst")){
					this.set_isconst(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("isexec")){
					this.set_isexec(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("virtual")){
					this.set_virtual(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("nonvirtual")){
					this.set_nonvirtual(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("override")){
					this.set_override(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("new")){
					this.set_new(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("final")){
					this.set_final(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("abstract")){
					this.set_abstract(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("external")){
					this.set_external(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("doc")){
					this.set_doc(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("helpURL")){
					this.set_helpURL(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("ldsrc")){
					this.set_ldsrc(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("iny")){
					this.set_iny(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("inydata")){
					this.set_inydata(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("inyby")){
					this.set_inyby(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("lddata")){
					this.set_lddata(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else{
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Atributo '"+reader.Name()+"' invalido en elemento '"+this.get_Name()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		//Borro todo posible nodo en memoria
		this.p_type=null;
		this.p_body=null;
		this.p_documentation=null;
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("type")){
						tempNode = new XplType();
						tempNode.Read(reader);
						if(this.get_type()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_type((XplType)tempNode);
					}
					else if(reader.Name().equals("body")){
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						if(this.get_body()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_body((XplFunctionBody)tempNode);
					}
					else if(reader.Name().equals("documentation")){
						tempNode = new XplDocumentation();
						tempNode.Read(reader);
						if(this.get_documentation()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nodo '"+reader.Name()+"' repetido como hijo de elemento '"+this.get_Name()+"'.");
						this.set_documentation((XplDocumentation)tempNode);
					}
					else{
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nombre de nodo '"+reader.Name()+"' inesperado como hijo de elemento '"+this.get_Name()+"'.");
					}
					break;
				case XmlNodeType.ENDELEMENT:
					break;
				case XmlNodeType.TEXT:
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".No se esperaba texto en este nodo.");
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
	public String get_getfunction(){
		return p_getfunction;
	}
	public String get_setfunction(){
		return p_setfunction;
	}
	public String get_internalname(){
		return p_internalname;
	}
	public String get_externalname(){
		return p_externalname;
	}
	public boolean get_donotrender(){
		return p_donotrender;
	}
	public int get_access(){
		return p_access;
	}
	public int get_storage(){
		return p_storage;
	}
	public boolean get_isfactory(){
		return p_isfactory;
	}
	public boolean get_isconst(){
		return p_isconst;
	}
	public boolean get_isexec(){
		return p_isexec;
	}
	public boolean get_virtual(){
		return p_virtual;
	}
	public boolean get_nonvirtual(){
		return p_nonvirtual;
	}
	public boolean get_override(){
		return p_override;
	}
	public boolean get_new(){
		return p_new;
	}
	public boolean get_final(){
		return p_final;
	}
	public boolean get_abstract(){
		return p_abstract;
	}
	public boolean get_external(){
		return p_external;
	}
	public String get_doc(){
		return p_doc;
	}
	public String get_helpURL(){
		return p_helpURL;
	}
	public String get_ldsrc(){
		return p_ldsrc;
	}
	public boolean get_iny(){
		return p_iny;
	}
	public String get_inydata(){
		return p_inydata;
	}
	public String get_inyby(){
		return p_inyby;
	}
	public String get_lddata(){
		return p_lddata;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplType get_type(){
		return p_type;
	}
	public XplFunctionBody get_body(){
		return p_body;
	}
	public XplDocumentation get_documentation(){
		return p_documentation;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_name(String new_name){
		String back_name = p_name;
		p_name = new_name;
		return back_name;
	}
	public String set_getfunction(String new_getfunction){
		String back_getfunction = p_getfunction;
		p_getfunction = new_getfunction;
		return back_getfunction;
	}
	public String set_setfunction(String new_setfunction){
		String back_setfunction = p_setfunction;
		p_setfunction = new_setfunction;
		return back_setfunction;
	}
	public String set_internalname(String new_internalname){
		String back_internalname = p_internalname;
		p_internalname = new_internalname;
		return back_internalname;
	}
	public String set_externalname(String new_externalname){
		String back_externalname = p_externalname;
		p_externalname = new_externalname;
		return back_externalname;
	}
	public boolean set_donotrender(boolean new_donotrender){
		boolean back_donotrender = p_donotrender;
		p_donotrender = new_donotrender;
		return back_donotrender;
	}
	public int set_access(int new_access){
		int back_access = p_access;
		p_access = new_access;
		return back_access;
	}
	public int set_storage(int new_storage){
		int back_storage = p_storage;
		p_storage = new_storage;
		return back_storage;
	}
	public boolean set_isfactory(boolean new_isfactory){
		boolean back_isfactory = p_isfactory;
		p_isfactory = new_isfactory;
		return back_isfactory;
	}
	public boolean set_isconst(boolean new_isconst){
		boolean back_isconst = p_isconst;
		p_isconst = new_isconst;
		return back_isconst;
	}
	public boolean set_isexec(boolean new_isexec){
		boolean back_isexec = p_isexec;
		p_isexec = new_isexec;
		return back_isexec;
	}
	public boolean set_virtual(boolean new_virtual){
		boolean back_virtual = p_virtual;
		p_virtual = new_virtual;
		return back_virtual;
	}
	public boolean set_nonvirtual(boolean new_nonvirtual){
		boolean back_nonvirtual = p_nonvirtual;
		p_nonvirtual = new_nonvirtual;
		return back_nonvirtual;
	}
	public boolean set_override(boolean new_override){
		boolean back_override = p_override;
		p_override = new_override;
		return back_override;
	}
	public boolean set_new(boolean new_new){
		boolean back_new = p_new;
		p_new = new_new;
		return back_new;
	}
	public boolean set_final(boolean new_final){
		boolean back_final = p_final;
		p_final = new_final;
		return back_final;
	}
	public boolean set_abstract(boolean new_abstract){
		boolean back_abstract = p_abstract;
		p_abstract = new_abstract;
		return back_abstract;
	}
	public boolean set_external(boolean new_external){
		boolean back_external = p_external;
		p_external = new_external;
		return back_external;
	}
	public String set_doc(String new_doc){
		String back_doc = p_doc;
		p_doc = new_doc;
		return back_doc;
	}
	public String set_helpURL(String new_helpURL){
		String back_helpURL = p_helpURL;
		p_helpURL = new_helpURL;
		return back_helpURL;
	}
	public String set_ldsrc(String new_ldsrc){
		String back_ldsrc = p_ldsrc;
		p_ldsrc = new_ldsrc;
		return back_ldsrc;
	}
	public boolean set_iny(boolean new_iny){
		boolean back_iny = p_iny;
		p_iny = new_iny;
		return back_iny;
	}
	public String set_inydata(String new_inydata){
		String back_inydata = p_inydata;
		p_inydata = new_inydata;
		return back_inydata;
	}
	public String set_inyby(String new_inyby){
		String back_inyby = p_inyby;
		p_inyby = new_inyby;
		return back_inyby;
	}
	public String set_lddata(String new_lddata){
		String back_lddata = p_lddata;
		p_lddata = new_lddata;
		return back_lddata;
	}

	//Funciones para setear Elementos de Secuencia
	public XplType set_type(XplType new_type){
		XplType back_type = p_type;
		p_type = new_type;
		if(p_type!=null){
			p_type.set_Name("type");
			p_type.set_Parent(this);
		}
		return back_type;
	}
	public XplFunctionBody set_body(XplFunctionBody new_body){
		XplFunctionBody back_body = p_body;
		p_body = new_body;
		if(p_body!=null){
			p_body.set_Name("body");
			p_body.set_Parent(this);
		}
		return back_body;
	}
	public XplDocumentation set_documentation(XplDocumentation new_documentation){
		XplDocumentation back_documentation = p_documentation;
		p_documentation = new_documentation;
		if(p_documentation!=null){
			p_documentation.set_Name("documentation");
			p_documentation.set_Parent(this);
		}
		return back_documentation;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplType new_type(){
		XplType node = new XplType();
		node.set_Name("type");
		return node;
	}
	public static final XplFunctionBody new_body(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_Name("body");
		return node;
	}
	public static final XplDocumentation new_documentation(){
		XplDocumentation node = new XplDocumentation();
		node.set_Name("documentation");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

