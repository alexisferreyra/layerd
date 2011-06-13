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

public class XplClass extends  XplNode implements XplNodeListCallbacks {

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_name;
	String p_internalname;
	String p_externalname;
	int p_access;
	boolean p_isstruct;
	boolean p_isinterface;
	boolean p_isunion;
	boolean p_isenum;
	boolean p_isfactory;
	boolean p_isinteractive;
	boolean p_abstract;
	boolean p_extension;
	boolean p_external;
	boolean p_donotrender;
	boolean p_final;
	boolean p_new;
	String p_doc;
	String p_helpURL;
	String p_ldsrc;
	boolean p_iny;
	String p_inydata;
	String p_inyby;
	String p_lddata;
	int p_alignment;
	int p_bitorder;
	int p_byteorder;
	int p_sizeinbits;
	//Variables para Elementos de Secuencia
	XplNodeList p_Childs;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplClass(){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_access = XplAccesstype_enum.PRIVATE;
		p_isstruct = false;
		p_isinterface = false;
		p_isunion = false;
		p_isenum = false;
		p_isfactory = false;
		p_isinteractive = false;
		p_abstract = false;
		p_extension = false;
		p_external = false;
		p_donotrender = false;
		p_final = false;
		p_new = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_alignment = 0;
		p_bitorder = XplBitorder_enum.IGNORE;
		p_byteorder = XplBitorder_enum.IGNORE;
		p_sizeinbits = 0;
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
	}
	public XplClass(String n_name, int n_access, boolean n_isstruct, boolean n_isinterface, boolean n_isunion, boolean n_isenum, boolean n_isfactory, boolean n_isinteractive, boolean n_abstract, boolean n_extension, boolean n_external, boolean n_donotrender, boolean n_final, boolean n_new, int n_bitorder, int n_byteorder){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_access = XplAccesstype_enum.PRIVATE;
		p_isstruct = false;
		p_isinterface = false;
		p_isunion = false;
		p_isenum = false;
		p_isfactory = false;
		p_isinteractive = false;
		p_abstract = false;
		p_extension = false;
		p_external = false;
		p_donotrender = false;
		p_final = false;
		p_new = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_alignment = 0;
		p_bitorder = XplBitorder_enum.IGNORE;
		p_byteorder = XplBitorder_enum.IGNORE;
		p_sizeinbits = 0;
		set_name(n_name);
		set_access(n_access);
		set_isstruct(n_isstruct);
		set_isinterface(n_isinterface);
		set_isunion(n_isunion);
		set_isenum(n_isenum);
		set_isfactory(n_isfactory);
		set_isinteractive(n_isinteractive);
		set_abstract(n_abstract);
		set_extension(n_extension);
		set_external(n_external);
		set_donotrender(n_donotrender);
		set_final(n_final);
		set_new(n_new);
		set_bitorder(n_bitorder);
		set_byteorder(n_byteorder);
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
	}
	public XplClass(String n_name, String n_internalname, String n_externalname, int n_access, boolean n_isstruct, boolean n_isinterface, boolean n_isunion, boolean n_isenum, boolean n_isfactory, boolean n_isinteractive, boolean n_abstract, boolean n_extension, boolean n_external, boolean n_donotrender, boolean n_final, boolean n_new, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, int n_alignment, int n_bitorder, int n_byteorder, int n_sizeinbits){
		set_name(n_name);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_access(n_access);
		set_isstruct(n_isstruct);
		set_isinterface(n_isinterface);
		set_isunion(n_isunion);
		set_isenum(n_isenum);
		set_isfactory(n_isfactory);
		set_isinteractive(n_isinteractive);
		set_abstract(n_abstract);
		set_extension(n_extension);
		set_external(n_external);
		set_donotrender(n_donotrender);
		set_final(n_final);
		set_new(n_new);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_alignment(n_alignment);
		set_bitorder(n_bitorder);
		set_byteorder(n_byteorder);
		set_sizeinbits(n_sizeinbits);
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
	}
	public XplClass(XplNodeList n_Childs){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_access = XplAccesstype_enum.PRIVATE;
		p_isstruct = false;
		p_isinterface = false;
		p_isunion = false;
		p_isenum = false;
		p_isfactory = false;
		p_isinteractive = false;
		p_abstract = false;
		p_extension = false;
		p_external = false;
		p_donotrender = false;
		p_final = false;
		p_new = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_alignment = 0;
		p_bitorder = XplBitorder_enum.IGNORE;
		p_byteorder = XplBitorder_enum.IGNORE;
		p_sizeinbits = 0;
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Childs!=null)
		for(XplNode node = n_Childs.FirstNode(); node != null ; node = n_Childs.NextNode()){
			p_Childs.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
	}
	public XplClass(String n_name, int n_access, boolean n_isstruct, boolean n_isinterface, boolean n_isunion, boolean n_isenum, boolean n_isfactory, boolean n_isinteractive, boolean n_abstract, boolean n_extension, boolean n_external, boolean n_donotrender, boolean n_final, boolean n_new, int n_bitorder, int n_byteorder, XplNodeList n_Childs){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_access = XplAccesstype_enum.PRIVATE;
		p_isstruct = false;
		p_isinterface = false;
		p_isunion = false;
		p_isenum = false;
		p_isfactory = false;
		p_isinteractive = false;
		p_abstract = false;
		p_extension = false;
		p_external = false;
		p_donotrender = false;
		p_final = false;
		p_new = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_alignment = 0;
		p_bitorder = XplBitorder_enum.IGNORE;
		p_byteorder = XplBitorder_enum.IGNORE;
		p_sizeinbits = 0;
		set_name(n_name);
		set_access(n_access);
		set_isstruct(n_isstruct);
		set_isinterface(n_isinterface);
		set_isunion(n_isunion);
		set_isenum(n_isenum);
		set_isfactory(n_isfactory);
		set_isinteractive(n_isinteractive);
		set_abstract(n_abstract);
		set_extension(n_extension);
		set_external(n_external);
		set_donotrender(n_donotrender);
		set_final(n_final);
		set_new(n_new);
		set_bitorder(n_bitorder);
		set_byteorder(n_byteorder);
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Childs!=null)
		for(XplNode node = n_Childs.FirstNode(); node != null ; node = n_Childs.NextNode()){
			p_Childs.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
	}
	public XplClass(String n_name, String n_internalname, String n_externalname, int n_access, boolean n_isstruct, boolean n_isinterface, boolean n_isunion, boolean n_isenum, boolean n_isfactory, boolean n_isinteractive, boolean n_abstract, boolean n_extension, boolean n_external, boolean n_donotrender, boolean n_final, boolean n_new, String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, int n_alignment, int n_bitorder, int n_byteorder, int n_sizeinbits, XplNodeList n_Childs){
		set_name(n_name);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_access(n_access);
		set_isstruct(n_isstruct);
		set_isinterface(n_isinterface);
		set_isunion(n_isunion);
		set_isenum(n_isenum);
		set_isfactory(n_isfactory);
		set_isinteractive(n_isinteractive);
		set_abstract(n_abstract);
		set_extension(n_extension);
		set_external(n_external);
		set_donotrender(n_donotrender);
		set_final(n_final);
		set_new(n_new);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_alignment(n_alignment);
		set_bitorder(n_bitorder);
		set_byteorder(n_byteorder);
		set_sizeinbits(n_sizeinbits);
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Childs!=null)
		for(XplNode node = n_Childs.FirstNode(); node != null ; node = n_Childs.NextNode()){
			p_Childs.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplClass copy = new XplClass();
		copy.set_name(this.p_name);
		copy.set_internalname(this.p_internalname);
		copy.set_externalname(this.p_externalname);
		copy.set_access(this.p_access);
		copy.set_isstruct(this.p_isstruct);
		copy.set_isinterface(this.p_isinterface);
		copy.set_isunion(this.p_isunion);
		copy.set_isenum(this.p_isenum);
		copy.set_isfactory(this.p_isfactory);
		copy.set_isinteractive(this.p_isinteractive);
		copy.set_abstract(this.p_abstract);
		copy.set_extension(this.p_extension);
		copy.set_external(this.p_external);
		copy.set_donotrender(this.p_donotrender);
		copy.set_final(this.p_final);
		copy.set_new(this.p_new);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		copy.set_alignment(this.p_alignment);
		copy.set_bitorder(this.p_bitorder);
		copy.set_byteorder(this.p_byteorder);
		copy.set_sizeinbits(this.p_sizeinbits);
		for(XplNode node = p_Childs.FirstNode(); node != null ; node = p_Childs.NextNode()){
			copy.Childs().InsertAtEnd(node.Clone());
		}
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplClass;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,CodeDOM_Utils.Att_ToString(p_name) );
		if(p_internalname != "")
			writer.WriteAttributeString( "internalname" ,CodeDOM_Utils.Att_ToString(p_internalname) );
		if(p_externalname != "")
			writer.WriteAttributeString( "externalname" ,CodeDOM_Utils.Att_ToString(p_externalname) );
		if(p_access != XplAccesstype_enum.PRIVATE)
			writer.WriteAttributeString( "access" , CodeDOM_STV.XPLACCESSTYPE_ENUM[(int)p_access] );
		if(p_isstruct != false)
			writer.WriteAttributeString( "isstruct" ,CodeDOM_Utils.Att_ToString(p_isstruct) );
		if(p_isinterface != false)
			writer.WriteAttributeString( "isinterface" ,CodeDOM_Utils.Att_ToString(p_isinterface) );
		if(p_isunion != false)
			writer.WriteAttributeString( "isunion" ,CodeDOM_Utils.Att_ToString(p_isunion) );
		if(p_isenum != false)
			writer.WriteAttributeString( "isenum" ,CodeDOM_Utils.Att_ToString(p_isenum) );
		if(p_isfactory != false)
			writer.WriteAttributeString( "isfactory" ,CodeDOM_Utils.Att_ToString(p_isfactory) );
		if(p_isinteractive != false)
			writer.WriteAttributeString( "isinteractive" ,CodeDOM_Utils.Att_ToString(p_isinteractive) );
		if(p_abstract != false)
			writer.WriteAttributeString( "abstract" ,CodeDOM_Utils.Att_ToString(p_abstract) );
		if(p_extension != false)
			writer.WriteAttributeString( "extension" ,CodeDOM_Utils.Att_ToString(p_extension) );
		if(p_external != false)
			writer.WriteAttributeString( "external" ,CodeDOM_Utils.Att_ToString(p_external) );
		if(p_donotrender != false)
			writer.WriteAttributeString( "donotrender" ,CodeDOM_Utils.Att_ToString(p_donotrender) );
		if(p_final != false)
			writer.WriteAttributeString( "final" ,CodeDOM_Utils.Att_ToString(p_final) );
		if(p_new != false)
			writer.WriteAttributeString( "new" ,CodeDOM_Utils.Att_ToString(p_new) );
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
		if(p_alignment != 0)
			writer.WriteAttributeString( "alignment" ,CodeDOM_Utils.Att_ToString(p_alignment) );
		if(p_bitorder != XplBitorder_enum.IGNORE)
			writer.WriteAttributeString( "bitorder" , CodeDOM_STV.XPLBITORDER_ENUM[(int)p_bitorder] );
		if(p_byteorder != XplBitorder_enum.IGNORE)
			writer.WriteAttributeString( "byteorder" , CodeDOM_STV.XPLBITORDER_ENUM[(int)p_byteorder] );
		if(p_sizeinbits != 0)
			writer.WriteAttributeString( "sizeinbits" ,CodeDOM_Utils.Att_ToString(p_sizeinbits) );
		//Escribo recursivamente cada elemento hijo
		if(p_Childs!=null)if(!p_Childs.Write(writer))result=false;
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
				else if(reader.Name().equals("internalname")){
					this.set_internalname(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("externalname")){
					this.set_externalname(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
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
				else if(reader.Name().equals("isstruct")){
					this.set_isstruct(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("isinterface")){
					this.set_isinterface(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("isunion")){
					this.set_isunion(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("isenum")){
					this.set_isenum(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("isfactory")){
					this.set_isfactory(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("isinteractive")){
					this.set_isinteractive(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("abstract")){
					this.set_abstract(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("extension")){
					this.set_extension(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("external")){
					this.set_external(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("donotrender")){
					this.set_donotrender(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("final")){
					this.set_final(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("new")){
					this.set_new(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
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
				else if(reader.Name().equals("alignment")){
					this.set_alignment(CodeDOM_Utils.StringAtt_To_INT(reader.Value()));
				}
				else if(reader.Name().equals("bitorder")){
					tmpStr=CodeDOM_Utils.StringAtt_To_STRING(reader.Value());
					count=0;flag=false;
					for(int n=0;n<CodeDOM_STV.XPLBITORDER_ENUM.length;n++){
						String str = CodeDOM_STV.XPLBITORDER_ENUM[n];
						if(str.equals(tmpStr)){this.set_bitorder(count);flag=true;break;}
						count++;
					}
					// if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Valor invalido del atributo 'bitorder' en elemento '"+this.get_Name()+"'.");
				}
				else if(reader.Name().equals("byteorder")){
					tmpStr=CodeDOM_Utils.StringAtt_To_STRING(reader.Value());
					count=0;flag=false;
					for(int n=0;n<CodeDOM_STV.XPLBITORDER_ENUM.length;n++){
						String str = CodeDOM_STV.XPLBITORDER_ENUM[n];
						if(str.equals(tmpStr)){this.set_byteorder(count);flag=true;break;}
						count++;
					}
					// if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Valor invalido del atributo 'byteorder' en elemento '"+this.get_Name()+"'.");
				}
				else if(reader.Name().equals("sizeinbits")){
					this.set_sizeinbits(CodeDOM_Utils.StringAtt_To_INT(reader.Value()));
				}
				else{
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Atributo '"+reader.Name()+"' invalido en elemento '"+this.get_Name()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		p_Childs.Clear(); //Borro todo posible hijo en memoria
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("Inherits")){
						tempNode = new XplInherits();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Implements")){
						tempNode = new XplInherits();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Function")){
						tempNode = new XplFunction();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Operator")){
						tempNode = new XplFunction();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Indexer")){
						tempNode = new XplFunction();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Property")){
						tempNode = new XplProperty();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Field")){
						tempNode = new XplField();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("e")){
						tempNode = new XplExpression();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Class")){
						tempNode = new XplClass();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("documentation")){
						tempNode = new XplDocumentation();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("BeginCFPermissions")){
						tempNode = new XplClassfactorysPermissions();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("EndCFPermissions")){
						tempNode = new XplNode(XplNodeType_enum.EMPTY);
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("SetPlatforms")){
						tempNode = new XplSetPlatforms();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("AutoInstance")){
						tempNode = new XplAutoInstance();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else{
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nombre de nodo '"+reader.Name()+"' inesperado como hijo de elemento '"+this.get_Name()+"'.");
					}
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
	public String get_internalname(){
		return p_internalname;
	}
	public String get_externalname(){
		return p_externalname;
	}
	public int get_access(){
		return p_access;
	}
	public boolean get_isstruct(){
		return p_isstruct;
	}
	public boolean get_isinterface(){
		return p_isinterface;
	}
	public boolean get_isunion(){
		return p_isunion;
	}
	public boolean get_isenum(){
		return p_isenum;
	}
	public boolean get_isfactory(){
		return p_isfactory;
	}
	public boolean get_isinteractive(){
		return p_isinteractive;
	}
	public boolean get_abstract(){
		return p_abstract;
	}
	public boolean get_extension(){
		return p_extension;
	}
	public boolean get_external(){
		return p_external;
	}
	public boolean get_donotrender(){
		return p_donotrender;
	}
	public boolean get_final(){
		return p_final;
	}
	public boolean get_new(){
		return p_new;
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
	public int get_alignment(){
		return p_alignment;
	}
	public int get_bitorder(){
		return p_bitorder;
	}
	public int get_byteorder(){
		return p_byteorder;
	}
	public int get_sizeinbits(){
		return p_sizeinbits;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplNodeList Childs(){
		return p_Childs;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_name(String new_name){
		String back_name = p_name;
		p_name = new_name;
		return back_name;
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
	public int set_access(int new_access){
		int back_access = p_access;
		p_access = new_access;
		return back_access;
	}
	public boolean set_isstruct(boolean new_isstruct){
		boolean back_isstruct = p_isstruct;
		p_isstruct = new_isstruct;
		return back_isstruct;
	}
	public boolean set_isinterface(boolean new_isinterface){
		boolean back_isinterface = p_isinterface;
		p_isinterface = new_isinterface;
		return back_isinterface;
	}
	public boolean set_isunion(boolean new_isunion){
		boolean back_isunion = p_isunion;
		p_isunion = new_isunion;
		return back_isunion;
	}
	public boolean set_isenum(boolean new_isenum){
		boolean back_isenum = p_isenum;
		p_isenum = new_isenum;
		return back_isenum;
	}
	public boolean set_isfactory(boolean new_isfactory){
		boolean back_isfactory = p_isfactory;
		p_isfactory = new_isfactory;
		return back_isfactory;
	}
	public boolean set_isinteractive(boolean new_isinteractive){
		boolean back_isinteractive = p_isinteractive;
		p_isinteractive = new_isinteractive;
		return back_isinteractive;
	}
	public boolean set_abstract(boolean new_abstract){
		boolean back_abstract = p_abstract;
		p_abstract = new_abstract;
		return back_abstract;
	}
	public boolean set_extension(boolean new_extension){
		boolean back_extension = p_extension;
		p_extension = new_extension;
		return back_extension;
	}
	public boolean set_external(boolean new_external){
		boolean back_external = p_external;
		p_external = new_external;
		return back_external;
	}
	public boolean set_donotrender(boolean new_donotrender){
		boolean back_donotrender = p_donotrender;
		p_donotrender = new_donotrender;
		return back_donotrender;
	}
	public boolean set_final(boolean new_final){
		boolean back_final = p_final;
		p_final = new_final;
		return back_final;
	}
	public boolean set_new(boolean new_new){
		boolean back_new = p_new;
		p_new = new_new;
		return back_new;
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
	public int set_alignment(int new_alignment){
		int back_alignment = p_alignment;
		p_alignment = new_alignment;
		return back_alignment;
	}
	public int set_bitorder(int new_bitorder){
		int back_bitorder = p_bitorder;
		p_bitorder = new_bitorder;
		return back_bitorder;
	}
	public int set_byteorder(int new_byteorder){
		int back_byteorder = p_byteorder;
		p_byteorder = new_byteorder;
		return back_byteorder;
	}
	public int set_sizeinbits(int new_sizeinbits){
		int back_sizeinbits = p_sizeinbits;
		p_sizeinbits = new_sizeinbits;
		return back_sizeinbits;
	}

	//Funciones para setear Elementos de Secuencia
	public boolean InsertCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		if(node==null)return false;
		if(node.get_Name().equals("Inherits")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplInherits){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Implements")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplInherits){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Function")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunction){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Operator")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunction){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Indexer")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunction){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Property")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplProperty){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Field")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplField){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("e")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplExpression){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Class")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplClass){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("documentation")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplDocumentation){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("BeginCFPermissions")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplClassfactorysPermissions){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("EndCFPermissions")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplNode){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("SetPlatforms")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplSetPlatforms){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("AutoInstance")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplAutoInstance){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.");
			}
			node.set_Parent(parent);
			return true;
		}
		//throw new CodeDOM_Exception("El elemento de nombre '"+node.get_Name()+"' no es valido como componente de 'XplClass'.");
		return false;
	}
	public boolean RemoveNodeCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		return true;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para filtrado en Listas de Nodos
	public XplNodeList get_InheritsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Inherits")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_ImplementsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Implements")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_FunctionNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Function")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_OperatorNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Operator")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_IndexerNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Indexer")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_PropertyNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Property")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_FieldNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Field")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_eNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("e")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_ClassNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Class")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_documentationNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("documentation")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_BeginCFPermissionsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("BeginCFPermissions")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_EndCFPermissionsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("EndCFPermissions")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_SetPlatformsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("SetPlatforms")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_AutoInstanceNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("AutoInstance")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}


	//Funciones para obtener nuevos nodos hijos
	public static final XplInherits new_Inherits(){
		XplInherits node = new XplInherits();
		node.set_Name("Inherits");
		return node;
	}
	public static final XplInherits new_Implements(){
		XplInherits node = new XplInherits();
		node.set_Name("Implements");
		return node;
	}
	public static final XplFunction new_Function(){
		XplFunction node = new XplFunction();
		node.set_Name("Function");
		return node;
	}
	public static final XplFunction new_Operator(){
		XplFunction node = new XplFunction();
		node.set_Name("Operator");
		return node;
	}
	public static final XplFunction new_Indexer(){
		XplFunction node = new XplFunction();
		node.set_Name("Indexer");
		return node;
	}
	public static final XplProperty new_Property(){
		XplProperty node = new XplProperty();
		node.set_Name("Property");
		return node;
	}
	public static final XplField new_Field(){
		XplField node = new XplField();
		node.set_Name("Field");
		return node;
	}
	public static final XplExpression new_e(){
		XplExpression node = new XplExpression();
		node.set_Name("e");
		return node;
	}
	public static final XplClass new_Class(){
		XplClass node = new XplClass();
		node.set_Name("Class");
		return node;
	}
	public static final XplDocumentation new_documentation(){
		XplDocumentation node = new XplDocumentation();
		node.set_Name("documentation");
		return node;
	}
	public static final XplClassfactorysPermissions new_BeginCFPermissions(){
		XplClassfactorysPermissions node = new XplClassfactorysPermissions();
		node.set_Name("BeginCFPermissions");
		return node;
	}
	public static final XplNode new_EndCFPermissions(){
		XplNode node = new XplNode(XplNodeType_enum.EMPTY);
		node.set_Name("EndCFPermissions");
		return node;
	}
	public static final XplSetPlatforms new_SetPlatforms(){
		XplSetPlatforms node = new XplSetPlatforms();
		node.set_Name("SetPlatforms");
		return node;
	}
	public static final XplAutoInstance new_AutoInstance(){
		XplAutoInstance node = new XplAutoInstance();
		node.set_Name("AutoInstance");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

