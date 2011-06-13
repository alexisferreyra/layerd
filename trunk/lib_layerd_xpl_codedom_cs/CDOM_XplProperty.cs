/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 3/2/2010 9:11:42 PM
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
public class XplProperty:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_name;
	string p_getfunction;
	string p_setfunction;
	string p_internalname;
	string p_externalname;
	bool p_donotrender;
	XplAccesstype_enum p_access;
	XplVarstorage_enum p_storage;
	bool p_isfactory;
	bool p_isconst;
	bool p_isexec;
	bool p_virtual;
	bool p_nonvirtual;
	bool p_override;
	bool p_new;
	bool p_final;
	bool p_abstract;
	bool p_external;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplType p_type;
	XplFunctionBody p_body;
	XplDocumentation p_documentation;
	#endregion

	#region Region de Constructores Publicos
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
	public XplProperty(string n_name, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external){
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
	public XplProperty(string n_name, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, XplType n_type){
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
	public XplProperty(string n_name, string n_getfunction, string n_setfunction, string n_internalname, string n_externalname, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
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
	public XplProperty(string n_name, string n_getfunction, string n_setfunction, string n_internalname, string n_externalname, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType n_type){
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
	public XplProperty(string n_name, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, XplType n_type, XplFunctionBody n_body, XplDocumentation n_documentation){
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
	public XplProperty(string n_name, string n_getfunction, string n_setfunction, string n_internalname, string n_externalname, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType n_type, XplFunctionBody n_body, XplDocumentation n_documentation){
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
	#endregion

	#region Destructor
/*	public ~XplProperty(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
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
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplProperty;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,ZoeHelper .Att_ToString(p_name) );
		if(p_getfunction != "")
			writer.WriteAttributeString( "getfunction" ,ZoeHelper .Att_ToString(p_getfunction) );
		if(p_setfunction != "")
			writer.WriteAttributeString( "setfunction" ,ZoeHelper .Att_ToString(p_setfunction) );
		if(p_internalname != "")
			writer.WriteAttributeString( "internalname" ,ZoeHelper .Att_ToString(p_internalname) );
		if(p_externalname != "")
			writer.WriteAttributeString( "externalname" ,ZoeHelper .Att_ToString(p_externalname) );
		if(p_donotrender != false)
			writer.WriteAttributeString( "donotrender" ,ZoeHelper .Att_ToString(p_donotrender) );
		if(p_access != XplAccesstype_enum.PRIVATE)
			writer.WriteAttributeString( "access" , CodeDOM_STV.XPLACCESSTYPE_ENUM[(int)p_access] );
		if(p_storage != XplVarstorage_enum.AUTO)
			writer.WriteAttributeString( "storage" , CodeDOM_STV.XPLVARSTORAGE_ENUM[(int)p_storage] );
		if(p_isfactory != false)
			writer.WriteAttributeString( "isfactory" ,ZoeHelper .Att_ToString(p_isfactory) );
		if(p_isconst != false)
			writer.WriteAttributeString( "isconst" ,ZoeHelper .Att_ToString(p_isconst) );
		if(p_isexec != false)
			writer.WriteAttributeString( "isexec" ,ZoeHelper .Att_ToString(p_isexec) );
		if(p_virtual != false)
			writer.WriteAttributeString( "virtual" ,ZoeHelper .Att_ToString(p_virtual) );
		if(p_nonvirtual != false)
			writer.WriteAttributeString( "nonvirtual" ,ZoeHelper .Att_ToString(p_nonvirtual) );
		if(p_override != false)
			writer.WriteAttributeString( "override" ,ZoeHelper .Att_ToString(p_override) );
		if(p_new != false)
			writer.WriteAttributeString( "new" ,ZoeHelper .Att_ToString(p_new) );
		if(p_final != false)
			writer.WriteAttributeString( "final" ,ZoeHelper .Att_ToString(p_final) );
		if(p_abstract != false)
			writer.WriteAttributeString( "abstract" ,ZoeHelper .Att_ToString(p_abstract) );
		if(p_external != false)
			writer.WriteAttributeString( "external" ,ZoeHelper .Att_ToString(p_external) );
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
		//Escribo recursivamente cada elemento hijo
		if(p_type!=null)if(!p_type.Write(writer))result=false;
		if(p_body!=null)if(!p_body.Write(writer))result=false;
		if(p_documentation!=null)if(!p_documentation.Write(writer))result=false;
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
					case "getfunction":
						this.set_getfunction(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "setfunction":
						this.set_setfunction(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "internalname":
						this.set_internalname(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "externalname":
						this.set_externalname(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "donotrender":
						this.set_donotrender(ZoeHelper .StringAtt_To_BOOL(reader.Value));
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
					case "storage":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLVARSTORAGE_ENUM){
							if(str==tmpStr){this.set_storage((XplVarstorage_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'storage' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "isfactory":
						this.set_isfactory(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "isconst":
						this.set_isconst(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "isexec":
						this.set_isexec(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "virtual":
						this.set_virtual(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "nonvirtual":
						this.set_nonvirtual(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "override":
						this.set_override(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "new":
						this.set_new(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "final":
						this.set_final(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "abstract":
						this.set_abstract(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "external":
						this.set_external(ZoeHelper .StringAtt_To_BOOL(reader.Value));
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
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Atributo '"+reader.Name+"' invalido en elemento '"+this.get_ElementName()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		//Borro todo posible nodo en memoria
		this.p_type=null;
		this.p_body=null;
		this.p_documentation=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "type":
						tempNode = new XplType();
						tempNode.Read(reader);
						if(this.get_type()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_type((XplType)tempNode);
						break;
					case "body":
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						if(this.get_body()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_body((XplFunctionBody)tempNode);
						break;
					case "documentation":
						tempNode = new XplDocumentation();
						tempNode.Read(reader);
						if(this.get_documentation()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_documentation((XplDocumentation)tempNode);
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
		writer.Write((int) 121 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_name );
		writer.Write( p_getfunction );
		writer.Write( p_setfunction );
		writer.Write( p_internalname );
		writer.Write( p_externalname );
		writer.Write( p_donotrender );
		writer.Write( (int)p_access );
		writer.Write( (int)p_storage );
		writer.Write( p_isfactory );
		writer.Write( p_isconst );
		writer.Write( p_isexec );
		writer.Write( p_virtual );
		writer.Write( p_nonvirtual );
		writer.Write( p_override );
		writer.Write( p_new );
		writer.Write( p_final );
		writer.Write( p_abstract );
		writer.Write( p_external );
		writer.Write( p_doc );
		writer.Write( p_helpURL );
		writer.Write( p_ldsrc );
		writer.Write( p_iny );
		writer.Write( p_inydata );
		writer.Write( p_inyby );
		writer.Write( p_lddata );
		//Escribo recursivamente cada elemento hijo
		if(p_type!=null){
			writer.Write((int)1);
			if(!p_type.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_body!=null){
			writer.Write((int)1);
			if(!p_body.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_documentation!=null){
			writer.Write((int)1);
			if(!p_documentation.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_name = reader.ReadString();
		p_getfunction = reader.ReadString();
		p_setfunction = reader.ReadString();
		p_internalname = reader.ReadString();
		p_externalname = reader.ReadString();
		p_donotrender = reader.ReadBoolean();
		p_access = (XplAccesstype_enum)reader.ReadInt32();
		p_storage = (XplVarstorage_enum)reader.ReadInt32();
		p_isfactory = reader.ReadBoolean();
		p_isconst = reader.ReadBoolean();
		p_isexec = reader.ReadBoolean();
		p_virtual = reader.ReadBoolean();
		p_nonvirtual = reader.ReadBoolean();
		p_override = reader.ReadBoolean();
		p_new = reader.ReadBoolean();
		p_final = reader.ReadBoolean();
		p_abstract = reader.ReadBoolean();
		p_external = reader.ReadBoolean();
		p_doc = reader.ReadString();
		p_helpURL = reader.ReadString();
		p_ldsrc = reader.ReadString();
		p_iny = reader.ReadBoolean();
		p_inydata = reader.ReadString();
		p_inyby = reader.ReadString();
		p_lddata = reader.ReadString();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_type = (XplType)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_body = (XplFunctionBody)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_documentation = (XplDocumentation)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplProperty operator +(XplProperty arg1, XplNode arg2)
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
public static XplProperty operator +(XplProperty arg1, XplNodeList arg2)
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
	public string get_getfunction(){
		return p_getfunction;
	}
	public string get_setfunction(){
		return p_setfunction;
	}
	public string get_internalname(){
		return p_internalname;
	}
	public string get_externalname(){
		return p_externalname;
	}
	public bool get_donotrender(){
		return p_donotrender;
	}
	public XplAccesstype_enum get_access(){
		return p_access;
	}
	public XplVarstorage_enum get_storage(){
		return p_storage;
	}
	public bool get_isfactory(){
		return p_isfactory;
	}
	public bool get_isconst(){
		return p_isconst;
	}
	public bool get_isexec(){
		return p_isexec;
	}
	public bool get_virtual(){
		return p_virtual;
	}
	public bool get_nonvirtual(){
		return p_nonvirtual;
	}
	public bool get_override(){
		return p_override;
	}
	public bool get_new(){
		return p_new;
	}
	public bool get_final(){
		return p_final;
	}
	public bool get_abstract(){
		return p_abstract;
	}
	public bool get_external(){
		return p_external;
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
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[25];
		ret[0] = "name";
		ret[1] = "getfunction";
		ret[2] = "setfunction";
		ret[3] = "internalname";
		ret[4] = "externalname";
		ret[5] = "donotrender";
		ret[6] = "access";
		ret[7] = "storage";
		ret[8] = "isfactory";
		ret[9] = "isconst";
		ret[10] = "isexec";
		ret[11] = "virtual";
		ret[12] = "nonvirtual";
		ret[13] = "override";
		ret[14] = "new";
		ret[15] = "final";
		ret[16] = "abstract";
		ret[17] = "external";
		ret[18] = "doc";
		ret[19] = "helpURL";
		ret[20] = "ldsrc";
		ret[21] = "iny";
		ret[22] = "inydata";
		ret[23] = "inyby";
		ret[24] = "lddata";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="name") return p_name.ToString();
		if (attributeName=="getfunction") return p_getfunction.ToString();
		if (attributeName=="setfunction") return p_setfunction.ToString();
		if (attributeName=="internalname") return p_internalname.ToString();
		if (attributeName=="externalname") return p_externalname.ToString();
		if (attributeName=="donotrender") return p_donotrender.ToString();
		if (attributeName=="access") return p_access.ToString();
		if (attributeName=="storage") return p_storage.ToString();
		if (attributeName=="isfactory") return p_isfactory.ToString();
		if (attributeName=="isconst") return p_isconst.ToString();
		if (attributeName=="isexec") return p_isexec.ToString();
		if (attributeName=="virtual") return p_virtual.ToString();
		if (attributeName=="nonvirtual") return p_nonvirtual.ToString();
		if (attributeName=="override") return p_override.ToString();
		if (attributeName=="new") return p_new.ToString();
		if (attributeName=="final") return p_final.ToString();
		if (attributeName=="abstract") return p_abstract.ToString();
		if (attributeName=="external") return p_external.ToString();
		if (attributeName=="doc") return p_doc.ToString();
		if (attributeName=="helpURL") return p_helpURL.ToString();
		if (attributeName=="ldsrc") return p_ldsrc.ToString();
		if (attributeName=="iny") return p_iny.ToString();
		if (attributeName=="inydata") return p_inydata.ToString();
		if (attributeName=="inyby") return p_inyby.ToString();
		if (attributeName=="lddata") return p_lddata.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		list.InsertAtEnd(p_type);
		list.InsertAtEnd(p_body);
		list.InsertAtEnd(p_documentation);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_name(string new_name){
		string back_name = p_name;
		p_name = new_name;
		return back_name;
	}
	public string set_getfunction(string new_getfunction){
		string back_getfunction = p_getfunction;
		p_getfunction = new_getfunction;
		return back_getfunction;
	}
	public string set_setfunction(string new_setfunction){
		string back_setfunction = p_setfunction;
		p_setfunction = new_setfunction;
		return back_setfunction;
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
	public bool set_donotrender(bool new_donotrender){
		bool back_donotrender = p_donotrender;
		p_donotrender = new_donotrender;
		return back_donotrender;
	}
	public XplAccesstype_enum set_access(XplAccesstype_enum new_access){
		XplAccesstype_enum back_access = p_access;
		p_access = new_access;
		return back_access;
	}
	public XplVarstorage_enum set_storage(XplVarstorage_enum new_storage){
		XplVarstorage_enum back_storage = p_storage;
		p_storage = new_storage;
		return back_storage;
	}
	public bool set_isfactory(bool new_isfactory){
		bool back_isfactory = p_isfactory;
		p_isfactory = new_isfactory;
		return back_isfactory;
	}
	public bool set_isconst(bool new_isconst){
		bool back_isconst = p_isconst;
		p_isconst = new_isconst;
		return back_isconst;
	}
	public bool set_isexec(bool new_isexec){
		bool back_isexec = p_isexec;
		p_isexec = new_isexec;
		return back_isexec;
	}
	public bool set_virtual(bool new_virtual){
		bool back_virtual = p_virtual;
		p_virtual = new_virtual;
		return back_virtual;
	}
	public bool set_nonvirtual(bool new_nonvirtual){
		bool back_nonvirtual = p_nonvirtual;
		p_nonvirtual = new_nonvirtual;
		return back_nonvirtual;
	}
	public bool set_override(bool new_override){
		bool back_override = p_override;
		p_override = new_override;
		return back_override;
	}
	public bool set_new(bool new_new){
		bool back_new = p_new;
		p_new = new_new;
		return back_new;
	}
	public bool set_final(bool new_final){
		bool back_final = p_final;
		p_final = new_final;
		return back_final;
	}
	public bool set_abstract(bool new_abstract){
		bool back_abstract = p_abstract;
		p_abstract = new_abstract;
		return back_abstract;
	}
	public bool set_external(bool new_external){
		bool back_external = p_external;
		p_external = new_external;
		return back_external;
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

	//Funciones para setear Elementos de Secuencia
	public XplType set_type(XplType new_type){
		XplType back_type = p_type;
		p_type = new_type;
		if(p_type!=null){
			p_type.set_ElementName("type");
			p_type.set_Parent(this);
		}
		return back_type;
	}
	public XplFunctionBody set_body(XplFunctionBody new_body){
		XplFunctionBody back_body = p_body;
		p_body = new_body;
		if(p_body!=null){
			p_body.set_ElementName("body");
			p_body.set_Parent(this);
		}
		return back_body;
	}
	public XplDocumentation set_documentation(XplDocumentation new_documentation){
		XplDocumentation back_documentation = p_documentation;
		p_documentation = new_documentation;
		if(p_documentation!=null){
			p_documentation.set_ElementName("documentation");
			p_documentation.set_Parent(this);
		}
		return back_documentation;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplType new_type(){
		XplType node = new XplType();
		node.set_ElementName("type");
		return node;
	}
	static public XplFunctionBody new_body(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_ElementName("body");
		return node;
	}
	static public XplDocumentation new_documentation(){
		XplDocumentation node = new XplDocumentation();
		node.set_ElementName("documentation");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

