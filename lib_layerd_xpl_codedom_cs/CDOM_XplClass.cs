/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 3/2/2010 9:11:43 PM
 *
 *	Generado por Zoe CodeDOM Generator para C#.
 *	COPYRIGHT 2002,2005-2006. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

using System;
using System.Xml;
using System.IO;

namespace LayerD.CodeDOM{

[Serializable]
public class XplClass:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_name;
	string p_internalname;
	string p_externalname;
	XplAccesstype_enum p_access;
	bool p_isstruct;
	bool p_isinterface;
	bool p_isunion;
	bool p_isenum;
	bool p_isfactory;
	bool p_isinteractive;
	bool p_abstract;
	bool p_extension;
	bool p_external;
	bool p_donotrender;
	bool p_final;
	bool p_new;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	uint p_alignment;
	XplBitorder_enum p_bitorder;
	XplBitorder_enum p_byteorder;
	uint p_sizeinbits;
	//Variables para Elementos de Secuencia
	XplNodeList p_Children;
	#endregion

	#region Region de Constructores Publicos
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
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_tClass));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_tClass));
}
	public XplClass(string n_name, XplAccesstype_enum n_access, bool n_isstruct, bool n_isinterface, bool n_isunion, bool n_isenum, bool n_isfactory, bool n_isinteractive, bool n_abstract, bool n_extension, bool n_external, bool n_donotrender, bool n_final, bool n_new, XplBitorder_enum n_bitorder, XplBitorder_enum n_byteorder){
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
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_tClass));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_tClass));
	}
	public XplClass(string n_name, string n_internalname, string n_externalname, XplAccesstype_enum n_access, bool n_isstruct, bool n_isinterface, bool n_isunion, bool n_isenum, bool n_isfactory, bool n_isinteractive, bool n_abstract, bool n_extension, bool n_external, bool n_donotrender, bool n_final, bool n_new, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, uint n_alignment, XplBitorder_enum n_bitorder, XplBitorder_enum n_byteorder, uint n_sizeinbits){
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
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_tClass));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_tClass));
	}
	public XplClass(XplNodeList n_Children){
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
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_tClass));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_tClass));
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Children!=null)
		for(XplNode node = n_Children.FirstNode(); node != null ; node = n_Children.NextNode()){
			p_Children.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	public XplClass(string n_name, XplAccesstype_enum n_access, bool n_isstruct, bool n_isinterface, bool n_isunion, bool n_isenum, bool n_isfactory, bool n_isinteractive, bool n_abstract, bool n_extension, bool n_external, bool n_donotrender, bool n_final, bool n_new, XplBitorder_enum n_bitorder, XplBitorder_enum n_byteorder, XplNodeList n_Children){
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
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_tClass));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_tClass));
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Children!=null)
		for(XplNode node = n_Children.FirstNode(); node != null ; node = n_Children.NextNode()){
			p_Children.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	public XplClass(string n_name, string n_internalname, string n_externalname, XplAccesstype_enum n_access, bool n_isstruct, bool n_isinterface, bool n_isunion, bool n_isenum, bool n_isfactory, bool n_isinteractive, bool n_abstract, bool n_extension, bool n_external, bool n_donotrender, bool n_final, bool n_new, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, uint n_alignment, XplBitorder_enum n_bitorder, XplBitorder_enum n_byteorder, uint n_sizeinbits, XplNodeList n_Children){
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
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_tClass));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_tClass));
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Children!=null)
		for(XplNode node = n_Children.FirstNode(); node != null ; node = n_Children.NextNode()){
			p_Children.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	#endregion

	#region Destructor
/*	public ~XplClass(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
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
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			copy.Children().InsertAtEnd(node.Clone());
		}
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplClass;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,ZoeHelper .Att_ToString(p_name) );
		if(p_internalname != "")
			writer.WriteAttributeString( "internalname" ,ZoeHelper .Att_ToString(p_internalname) );
		if(p_externalname != "")
			writer.WriteAttributeString( "externalname" ,ZoeHelper .Att_ToString(p_externalname) );
		if(p_access != XplAccesstype_enum.PRIVATE)
			writer.WriteAttributeString( "access" , CodeDOM_STV.XPLACCESSTYPE_ENUM[(int)p_access] );
		if(p_isstruct != false)
			writer.WriteAttributeString( "isstruct" ,ZoeHelper .Att_ToString(p_isstruct) );
		if(p_isinterface != false)
			writer.WriteAttributeString( "isinterface" ,ZoeHelper .Att_ToString(p_isinterface) );
		if(p_isunion != false)
			writer.WriteAttributeString( "isunion" ,ZoeHelper .Att_ToString(p_isunion) );
		if(p_isenum != false)
			writer.WriteAttributeString( "isenum" ,ZoeHelper .Att_ToString(p_isenum) );
		if(p_isfactory != false)
			writer.WriteAttributeString( "isfactory" ,ZoeHelper .Att_ToString(p_isfactory) );
		if(p_isinteractive != false)
			writer.WriteAttributeString( "isinteractive" ,ZoeHelper .Att_ToString(p_isinteractive) );
		if(p_abstract != false)
			writer.WriteAttributeString( "abstract" ,ZoeHelper .Att_ToString(p_abstract) );
		if(p_extension != false)
			writer.WriteAttributeString( "extension" ,ZoeHelper .Att_ToString(p_extension) );
		if(p_external != false)
			writer.WriteAttributeString( "external" ,ZoeHelper .Att_ToString(p_external) );
		if(p_donotrender != false)
			writer.WriteAttributeString( "donotrender" ,ZoeHelper .Att_ToString(p_donotrender) );
		if(p_final != false)
			writer.WriteAttributeString( "final" ,ZoeHelper .Att_ToString(p_final) );
		if(p_new != false)
			writer.WriteAttributeString( "new" ,ZoeHelper .Att_ToString(p_new) );
		if(p_doc != "")
			writer.WriteAttributeString( "doc" ,ZoeHelper .Att_ToString(p_doc) );
		if(p_helpURL != "")
			writer.WriteAttributeString( "helpURL" ,ZoeHelper .Att_ToString(p_helpURL) );
		if(p_ldsrc != "")
			writer.WriteAttributeString( "ldsrc" ,ZoeHelper .Att_ToString(p_ldsrc) );
		if(p_iny != false)
			writer.WriteAttributeString( "iny" ,ZoeHelper .Att_ToString(p_iny) );
		if(p_inydata != "")
			writer.WriteAttributeString( "inydata" ,ZoeHelper .Att_ToString(p_inydata) );
		if(p_inyby != "")
			writer.WriteAttributeString( "inyby" ,ZoeHelper .Att_ToString(p_inyby) );
		if(p_lddata != "")
			writer.WriteAttributeString( "lddata" ,ZoeHelper .Att_ToString(p_lddata) );
		if(p_alignment != 0)
			writer.WriteAttributeString( "alignment" ,ZoeHelper .Att_ToString(p_alignment) );
		if(p_bitorder != XplBitorder_enum.IGNORE)
			writer.WriteAttributeString( "bitorder" , CodeDOM_STV.XPLBITORDER_ENUM[(int)p_bitorder] );
		if(p_byteorder != XplBitorder_enum.IGNORE)
			writer.WriteAttributeString( "byteorder" , CodeDOM_STV.XPLBITORDER_ENUM[(int)p_byteorder] );
		if(p_sizeinbits != 0)
			writer.WriteAttributeString( "sizeinbits" ,ZoeHelper .Att_ToString(p_sizeinbits) );
		//Escribo recursivamente cada elemento hijo
		if(p_Children!=null)if(!p_Children.Write(writer))result=false;
		//Cierro el elemento
		writer.WriteEndElement();
		return result;
	}

	public override XplNode Read(XplReader reader){
		this.set_ElementName( reader.Name );
		//Lectura de Atributos
		if( reader.HasAttributes ){
			string tmpStr="";bool flag=false;int count=0;
			for(int i=0; i < reader.AttributeCount ; i++){
				reader.MoveToAttribute(i);
				switch(reader.Name){
					case "name":
						this.set_name(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "internalname":
						this.set_internalname(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "externalname":
						this.set_externalname(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "access":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLACCESSTYPE_ENUM){
							if(str==tmpStr){this.set_access((XplAccesstype_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'access' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "isstruct":
						this.set_isstruct(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "isinterface":
						this.set_isinterface(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "isunion":
						this.set_isunion(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "isenum":
						this.set_isenum(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "isfactory":
						this.set_isfactory(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "isinteractive":
						this.set_isinteractive(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "abstract":
						this.set_abstract(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "extension":
						this.set_extension(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "external":
						this.set_external(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "donotrender":
						this.set_donotrender(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "final":
						this.set_final(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "new":
						this.set_new(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "doc":
						this.set_doc(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "helpURL":
						this.set_helpURL(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "ldsrc":
						this.set_ldsrc(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "iny":
						this.set_iny(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "inydata":
						this.set_inydata(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "inyby":
						this.set_inyby(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "lddata":
						this.set_lddata(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "alignment":
						this.set_alignment(ZoeHelper .StringAtt_To_UINT(reader.Value));
						break;
					case "bitorder":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLBITORDER_ENUM){
							if(str==tmpStr){this.set_bitorder((XplBitorder_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'bitorder' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "byteorder":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLBITORDER_ENUM){
							if(str==tmpStr){this.set_byteorder((XplBitorder_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'byteorder' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "sizeinbits":
						this.set_sizeinbits(ZoeHelper .StringAtt_To_UINT(reader.Value));
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Atributo '"+reader.Name+"' invalido en elemento '"+this.get_ElementName()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		p_Children.Clear(); //Borro todo posible hijo en memoria
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "Inherits":
						tempNode = new XplInherits();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Implements":
						tempNode = new XplInherits();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Function":
						tempNode = new XplFunction();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Operator":
						tempNode = new XplFunction();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Indexer":
						tempNode = new XplFunction();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Property":
						tempNode = new XplProperty();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Field":
						tempNode = new XplField();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "e":
						tempNode = new XplExpression();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Class":
						tempNode = new XplClass();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "documentation":
						tempNode = new XplDocumentation();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "BeginCFPermissions":
						tempNode = new XplClassfactorysPermissions();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "EndCFPermissions":
						tempNode = new XplNode(XplNodeType_enum.EMPTY);
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "SetPlatforms":
						tempNode = new XplSetPlatforms();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "AutoInstance":
						tempNode = new XplAutoInstance();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nombre de nodo '"+reader.Name+"' inesperado como hijo de elemento '"+this.get_ElementName()+"'.");
					}
					break;
				case XmlNodeType.EndElement:
					break;
				case XmlNodeType.Text:
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".No se esperaba texto en este nodo.");
				default:
					break;
			}
			reader.Read();
		}
		}
		return this;
	}
	public override bool BinaryWrite(XplBinaryWriter writer){
		bool result=true;
		//Escribo el ID y el nombre del elemento
		writer.Write((int) 164 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_name );
		writer.Write( p_internalname );
		writer.Write( p_externalname );
		writer.Write( (int)p_access );
		writer.Write( p_isstruct );
		writer.Write( p_isinterface );
		writer.Write( p_isunion );
		writer.Write( p_isenum );
		writer.Write( p_isfactory );
		writer.Write( p_isinteractive );
		writer.Write( p_abstract );
		writer.Write( p_extension );
		writer.Write( p_external );
		writer.Write( p_donotrender );
		writer.Write( p_final );
		writer.Write( p_new );
		writer.Write( p_doc );
		writer.Write( p_helpURL );
		writer.Write( p_ldsrc );
		writer.Write( p_iny );
		writer.Write( p_inydata );
		writer.Write( p_inyby );
		writer.Write( p_lddata );
		writer.Write( p_alignment );
		writer.Write( (int)p_bitorder );
		writer.Write( (int)p_byteorder );
		writer.Write( p_sizeinbits );
		//Escribo recursivamente cada elemento hijo
		if(!p_Children.BinaryWrite(writer))result=false;
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_name = reader.ReadString();
		p_internalname = reader.ReadString();
		p_externalname = reader.ReadString();
		p_access = (XplAccesstype_enum)reader.ReadInt32();
		p_isstruct = reader.ReadBoolean();
		p_isinterface = reader.ReadBoolean();
		p_isunion = reader.ReadBoolean();
		p_isenum = reader.ReadBoolean();
		p_isfactory = reader.ReadBoolean();
		p_isinteractive = reader.ReadBoolean();
		p_abstract = reader.ReadBoolean();
		p_extension = reader.ReadBoolean();
		p_external = reader.ReadBoolean();
		p_donotrender = reader.ReadBoolean();
		p_final = reader.ReadBoolean();
		p_new = reader.ReadBoolean();
		p_doc = reader.ReadString();
		p_helpURL = reader.ReadString();
		p_ldsrc = reader.ReadString();
		p_iny = reader.ReadBoolean();
		p_inydata = reader.ReadString();
		p_inyby = reader.ReadString();
		p_lddata = reader.ReadString();
		p_alignment = reader.ReadUInt32();
		p_bitorder = (XplBitorder_enum)reader.ReadInt32();
		p_byteorder = (XplBitorder_enum)reader.ReadInt32();
		p_sizeinbits = reader.ReadUInt32();
		//Lectura de Elementos
		p_Children.BinaryRead(reader);
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplClass operator +(XplClass arg1, XplNode arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
/// <summary>
/// Adds arg2 nodes to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Nodes to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplClass operator +(XplClass arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_name(){
		return p_name;
	}
	public string get_internalname(){
		return p_internalname;
	}
	public string get_externalname(){
		return p_externalname;
	}
	public XplAccesstype_enum get_access(){
		return p_access;
	}
	public bool get_isstruct(){
		return p_isstruct;
	}
	public bool get_isinterface(){
		return p_isinterface;
	}
	public bool get_isunion(){
		return p_isunion;
	}
	public bool get_isenum(){
		return p_isenum;
	}
	public bool get_isfactory(){
		return p_isfactory;
	}
	public bool get_isinteractive(){
		return p_isinteractive;
	}
	public bool get_abstract(){
		return p_abstract;
	}
	public bool get_extension(){
		return p_extension;
	}
	public bool get_external(){
		return p_external;
	}
	public bool get_donotrender(){
		return p_donotrender;
	}
	public bool get_final(){
		return p_final;
	}
	public bool get_new(){
		return p_new;
	}
	public override string get_doc(){
		return p_doc;
	}
	public override string get_helpURL(){
		return p_helpURL;
	}
	public override string get_ldsrc(){
		return p_ldsrc;
	}
	public override bool get_iny(){
		return p_iny;
	}
	public override string get_inydata(){
		return p_inydata;
	}
	public override string get_inyby(){
		return p_inyby;
	}
	public override string get_lddata(){
		return p_lddata;
	}
	public uint get_alignment(){
		return p_alignment;
	}
	public XplBitorder_enum get_bitorder(){
		return p_bitorder;
	}
	public XplBitorder_enum get_byteorder(){
		return p_byteorder;
	}
	public uint get_sizeinbits(){
		return p_sizeinbits;
	}
	//Funciones para obtener Elementos de Secuencia
	public override XplNodeList Children(){
		return p_Children;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[27];
		ret[0] = "name";
		ret[1] = "internalname";
		ret[2] = "externalname";
		ret[3] = "access";
		ret[4] = "isstruct";
		ret[5] = "isinterface";
		ret[6] = "isunion";
		ret[7] = "isenum";
		ret[8] = "isfactory";
		ret[9] = "isinteractive";
		ret[10] = "abstract";
		ret[11] = "extension";
		ret[12] = "external";
		ret[13] = "donotrender";
		ret[14] = "final";
		ret[15] = "new";
		ret[16] = "doc";
		ret[17] = "helpURL";
		ret[18] = "ldsrc";
		ret[19] = "iny";
		ret[20] = "inydata";
		ret[21] = "inyby";
		ret[22] = "lddata";
		ret[23] = "alignment";
		ret[24] = "bitorder";
		ret[25] = "byteorder";
		ret[26] = "sizeinbits";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="name") return p_name.ToString();
		if (attributeName=="internalname") return p_internalname.ToString();
		if (attributeName=="externalname") return p_externalname.ToString();
		if (attributeName=="access") return p_access.ToString();
		if (attributeName=="isstruct") return p_isstruct.ToString();
		if (attributeName=="isinterface") return p_isinterface.ToString();
		if (attributeName=="isunion") return p_isunion.ToString();
		if (attributeName=="isenum") return p_isenum.ToString();
		if (attributeName=="isfactory") return p_isfactory.ToString();
		if (attributeName=="isinteractive") return p_isinteractive.ToString();
		if (attributeName=="abstract") return p_abstract.ToString();
		if (attributeName=="extension") return p_extension.ToString();
		if (attributeName=="external") return p_external.ToString();
		if (attributeName=="donotrender") return p_donotrender.ToString();
		if (attributeName=="final") return p_final.ToString();
		if (attributeName=="new") return p_new.ToString();
		if (attributeName=="doc") return p_doc.ToString();
		if (attributeName=="helpURL") return p_helpURL.ToString();
		if (attributeName=="ldsrc") return p_ldsrc.ToString();
		if (attributeName=="iny") return p_iny.ToString();
		if (attributeName=="inydata") return p_inydata.ToString();
		if (attributeName=="inyby") return p_inyby.ToString();
		if (attributeName=="lddata") return p_lddata.ToString();
		if (attributeName=="alignment") return p_alignment.ToString();
		if (attributeName=="bitorder") return p_bitorder.ToString();
		if (attributeName=="byteorder") return p_byteorder.ToString();
		if (attributeName=="sizeinbits") return p_sizeinbits.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		for(XplNode node=p_Children.FirstNode();node!=null;node=p_Children.NextNode())
			list.InsertAtEnd(node);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_name(string new_name){
		string back_name = p_name;
		p_name = new_name;
		return back_name;
	}
	public string set_internalname(string new_internalname){
		string back_internalname = p_internalname;
		p_internalname = new_internalname;
		return back_internalname;
	}
	public string set_externalname(string new_externalname){
		string back_externalname = p_externalname;
		p_externalname = new_externalname;
		return back_externalname;
	}
	public XplAccesstype_enum set_access(XplAccesstype_enum new_access){
		XplAccesstype_enum back_access = p_access;
		p_access = new_access;
		return back_access;
	}
	public bool set_isstruct(bool new_isstruct){
		bool back_isstruct = p_isstruct;
		p_isstruct = new_isstruct;
		return back_isstruct;
	}
	public bool set_isinterface(bool new_isinterface){
		bool back_isinterface = p_isinterface;
		p_isinterface = new_isinterface;
		return back_isinterface;
	}
	public bool set_isunion(bool new_isunion){
		bool back_isunion = p_isunion;
		p_isunion = new_isunion;
		return back_isunion;
	}
	public bool set_isenum(bool new_isenum){
		bool back_isenum = p_isenum;
		p_isenum = new_isenum;
		return back_isenum;
	}
	public bool set_isfactory(bool new_isfactory){
		bool back_isfactory = p_isfactory;
		p_isfactory = new_isfactory;
		return back_isfactory;
	}
	public bool set_isinteractive(bool new_isinteractive){
		bool back_isinteractive = p_isinteractive;
		p_isinteractive = new_isinteractive;
		return back_isinteractive;
	}
	public bool set_abstract(bool new_abstract){
		bool back_abstract = p_abstract;
		p_abstract = new_abstract;
		return back_abstract;
	}
	public bool set_extension(bool new_extension){
		bool back_extension = p_extension;
		p_extension = new_extension;
		return back_extension;
	}
	public bool set_external(bool new_external){
		bool back_external = p_external;
		p_external = new_external;
		return back_external;
	}
	public bool set_donotrender(bool new_donotrender){
		bool back_donotrender = p_donotrender;
		p_donotrender = new_donotrender;
		return back_donotrender;
	}
	public bool set_final(bool new_final){
		bool back_final = p_final;
		p_final = new_final;
		return back_final;
	}
	public bool set_new(bool new_new){
		bool back_new = p_new;
		p_new = new_new;
		return back_new;
	}
	public override string set_doc(string new_doc){
		string back_doc = p_doc;
		p_doc = new_doc;
		return back_doc;
	}
	public override string set_helpURL(string new_helpURL){
		string back_helpURL = p_helpURL;
		p_helpURL = new_helpURL;
		return back_helpURL;
	}
	public override string set_ldsrc(string new_ldsrc){
		string back_ldsrc = p_ldsrc;
		p_ldsrc = new_ldsrc;
		return back_ldsrc;
	}
	public override bool set_iny(bool new_iny){
		bool back_iny = p_iny;
		p_iny = new_iny;
		return back_iny;
	}
	public override string set_inydata(string new_inydata){
		string back_inydata = p_inydata;
		p_inydata = new_inydata;
		return back_inydata;
	}
	public override string set_inyby(string new_inyby){
		string back_inyby = p_inyby;
		p_inyby = new_inyby;
		return back_inyby;
	}
	public override string set_lddata(string new_lddata){
		string back_lddata = p_lddata;
		p_lddata = new_lddata;
		return back_lddata;
	}
	public uint set_alignment(uint new_alignment){
		uint back_alignment = p_alignment;
		p_alignment = new_alignment;
		return back_alignment;
	}
	public XplBitorder_enum set_bitorder(XplBitorder_enum new_bitorder){
		XplBitorder_enum back_bitorder = p_bitorder;
		p_bitorder = new_bitorder;
		return back_bitorder;
	}
	public XplBitorder_enum set_byteorder(XplBitorder_enum new_byteorder){
		XplBitorder_enum back_byteorder = p_byteorder;
		p_byteorder = new_byteorder;
		return back_byteorder;
	}
	public uint set_sizeinbits(uint new_sizeinbits){
		uint back_sizeinbits = p_sizeinbits;
		p_sizeinbits = new_sizeinbits;
		return back_sizeinbits;
	}

	//Funciones para setear Elementos de Secuencia
	protected bool acceptInsertNodeCallback_tClass(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="Inherits"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplInherits){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Implements"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplInherits){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Function"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunction){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Operator"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunction){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Indexer"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunction){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Property"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplProperty){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Field"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplField){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="e"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplExpression){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Class"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplClass){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="documentation"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplDocumentation){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="BeginCFPermissions"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplClassfactorysPermissions){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="EndCFPermissions"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplNode){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="SetPlatforms"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplSetPlatforms){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="AutoInstance"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplAutoInstance){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplClass'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplClass'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_tClass(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	#endregion

	#region Funciones para filtrado en Listas de Nodos
	public XplNodeList get_InheritsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Inherits"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_ImplementsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Implements"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_FunctionNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Function"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_OperatorNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Operator"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_IndexerNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Indexer"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_PropertyNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Property"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_FieldNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Field"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_eNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="e"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_ClassNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Class"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_documentationNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="documentation"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_BeginCFPermissionsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="BeginCFPermissions"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_EndCFPermissionsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="EndCFPermissions"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_SetPlatformsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="SetPlatforms"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_AutoInstanceNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="AutoInstance"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplInherits new_Inherits(){
		XplInherits node = new XplInherits();
		node.set_ElementName("Inherits");
		return node;
	}
	static public XplInherits new_Implements(){
		XplInherits node = new XplInherits();
		node.set_ElementName("Implements");
		return node;
	}
	static public XplFunction new_Function(){
		XplFunction node = new XplFunction();
		node.set_ElementName("Function");
		return node;
	}
	static public XplFunction new_Operator(){
		XplFunction node = new XplFunction();
		node.set_ElementName("Operator");
		return node;
	}
	static public XplFunction new_Indexer(){
		XplFunction node = new XplFunction();
		node.set_ElementName("Indexer");
		return node;
	}
	static public XplProperty new_Property(){
		XplProperty node = new XplProperty();
		node.set_ElementName("Property");
		return node;
	}
	static public XplField new_Field(){
		XplField node = new XplField();
		node.set_ElementName("Field");
		return node;
	}
	static public XplExpression new_e(){
		XplExpression node = new XplExpression();
		node.set_ElementName("e");
		return node;
	}
	static public XplClass new_Class(){
		XplClass node = new XplClass();
		node.set_ElementName("Class");
		return node;
	}
	static public XplDocumentation new_documentation(){
		XplDocumentation node = new XplDocumentation();
		node.set_ElementName("documentation");
		return node;
	}
	static public XplClassfactorysPermissions new_BeginCFPermissions(){
		XplClassfactorysPermissions node = new XplClassfactorysPermissions();
		node.set_ElementName("BeginCFPermissions");
		return node;
	}
	static public XplNode new_EndCFPermissions(){
		XplNode node = new XplNode(XplNodeType_enum.EMPTY);
		node.set_ElementName("EndCFPermissions");
		return node;
	}
	static public XplSetPlatforms new_SetPlatforms(){
		XplSetPlatforms node = new XplSetPlatforms();
		node.set_ElementName("SetPlatforms");
		return node;
	}
	static public XplAutoInstance new_AutoInstance(){
		XplAutoInstance node = new XplAutoInstance();
		node.set_ElementName("AutoInstance");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

