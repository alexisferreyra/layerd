/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 8/11/2011 4:27:20 PM
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
public class XplFunction:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_name;
	string p_internalname;
	string p_externalname;
	bool p_allowoptimize;
	bool p_donotrender;
	XplAccesstype_enum p_access;
	XplVarstorage_enum p_storage;
	bool p_isfactory;
	bool p_iskeyword;
	bool p_isconst;
	bool p_isexec;
	bool p_virtual;
	bool p_nonvirtual;
	bool p_override;
	bool p_new;
	bool p_final;
	bool p_force;
	bool p_abstract;
	bool p_fp;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplParameters p_Parameters;
	XplType p_ReturnType;
	XplFunctionBody p_FunctionBody;
	XplBaseInitializers p_BaseInitializers;
	XplDocumentation p_documentation;
	#endregion

	#region Region de Constructores Publicos
	public XplFunction(){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_allowoptimize = false;
		p_donotrender = false;
		p_access = XplAccesstype_enum.PRIVATE;
		p_storage = XplVarstorage_enum.AUTO;
		p_isfactory = false;
		p_iskeyword = false;
		p_isconst = false;
		p_isexec = false;
		p_virtual = false;
		p_nonvirtual = false;
		p_override = false;
		p_new = false;
		p_final = false;
		p_force = false;
		p_abstract = false;
		p_fp = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_Parameters=null;
		p_ReturnType=null;
		p_FunctionBody=null;
		p_BaseInitializers=null;
		p_documentation=null;
}
	public XplFunction(string n_name, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_allowoptimize = false;
		p_donotrender = false;
		p_access = XplAccesstype_enum.PRIVATE;
		p_storage = XplVarstorage_enum.AUTO;
		p_isfactory = false;
		p_iskeyword = false;
		p_isconst = false;
		p_isexec = false;
		p_virtual = false;
		p_nonvirtual = false;
		p_override = false;
		p_new = false;
		p_final = false;
		p_force = false;
		p_abstract = false;
		p_fp = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_name(n_name);
		set_allowoptimize(n_allowoptimize);
		set_donotrender(n_donotrender);
		set_access(n_access);
		set_storage(n_storage);
		set_isfactory(n_isfactory);
		set_iskeyword(n_iskeyword);
		set_isconst(n_isconst);
		set_isexec(n_isexec);
		set_virtual(n_virtual);
		set_nonvirtual(n_nonvirtual);
		set_override(n_override);
		set_new(n_new);
		set_final(n_final);
		set_force(n_force);
		set_abstract(n_abstract);
		set_fp(n_fp);
		p_Parameters=null;
		p_ReturnType=null;
		p_FunctionBody=null;
		p_BaseInitializers=null;
		p_documentation=null;
	}
	public XplFunction(XplParameters n_Parameters){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_allowoptimize = false;
		p_donotrender = false;
		p_access = XplAccesstype_enum.PRIVATE;
		p_storage = XplVarstorage_enum.AUTO;
		p_isfactory = false;
		p_iskeyword = false;
		p_isconst = false;
		p_isexec = false;
		p_virtual = false;
		p_nonvirtual = false;
		p_override = false;
		p_new = false;
		p_final = false;
		p_force = false;
		p_abstract = false;
		p_fp = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_Parameters=null;
		p_ReturnType=null;
		p_FunctionBody=null;
		p_BaseInitializers=null;
		p_documentation=null;
		set_Parameters(n_Parameters);
	}
	public XplFunction(string n_name, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, XplParameters n_Parameters){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_allowoptimize = false;
		p_donotrender = false;
		p_access = XplAccesstype_enum.PRIVATE;
		p_storage = XplVarstorage_enum.AUTO;
		p_isfactory = false;
		p_iskeyword = false;
		p_isconst = false;
		p_isexec = false;
		p_virtual = false;
		p_nonvirtual = false;
		p_override = false;
		p_new = false;
		p_final = false;
		p_force = false;
		p_abstract = false;
		p_fp = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_name(n_name);
		set_allowoptimize(n_allowoptimize);
		set_donotrender(n_donotrender);
		set_access(n_access);
		set_storage(n_storage);
		set_isfactory(n_isfactory);
		set_iskeyword(n_iskeyword);
		set_isconst(n_isconst);
		set_isexec(n_isexec);
		set_virtual(n_virtual);
		set_nonvirtual(n_nonvirtual);
		set_override(n_override);
		set_new(n_new);
		set_final(n_final);
		set_force(n_force);
		set_abstract(n_abstract);
		set_fp(n_fp);
		p_Parameters=null;
		p_ReturnType=null;
		p_FunctionBody=null;
		p_BaseInitializers=null;
		p_documentation=null;
		set_Parameters(n_Parameters);
	}
	public XplFunction(string n_name, string n_internalname, string n_externalname, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
		set_name(n_name);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_allowoptimize(n_allowoptimize);
		set_donotrender(n_donotrender);
		set_access(n_access);
		set_storage(n_storage);
		set_isfactory(n_isfactory);
		set_iskeyword(n_iskeyword);
		set_isconst(n_isconst);
		set_isexec(n_isexec);
		set_virtual(n_virtual);
		set_nonvirtual(n_nonvirtual);
		set_override(n_override);
		set_new(n_new);
		set_final(n_final);
		set_force(n_force);
		set_abstract(n_abstract);
		set_fp(n_fp);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_Parameters=null;
		p_ReturnType=null;
		p_FunctionBody=null;
		p_BaseInitializers=null;
		p_documentation=null;
	}
	public XplFunction(XplParameters n_Parameters, XplType n_ReturnType, XplFunctionBody n_FunctionBody, XplBaseInitializers n_BaseInitializers, XplDocumentation n_documentation){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_allowoptimize = false;
		p_donotrender = false;
		p_access = XplAccesstype_enum.PRIVATE;
		p_storage = XplVarstorage_enum.AUTO;
		p_isfactory = false;
		p_iskeyword = false;
		p_isconst = false;
		p_isexec = false;
		p_virtual = false;
		p_nonvirtual = false;
		p_override = false;
		p_new = false;
		p_final = false;
		p_force = false;
		p_abstract = false;
		p_fp = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_Parameters=null;
		p_ReturnType=null;
		p_FunctionBody=null;
		p_BaseInitializers=null;
		p_documentation=null;
		set_Parameters(n_Parameters);
		set_ReturnType(n_ReturnType);
		set_FunctionBody(n_FunctionBody);
		set_BaseInitializers(n_BaseInitializers);
		set_documentation(n_documentation);
	}
	public XplFunction(string n_name, string n_internalname, string n_externalname, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplParameters n_Parameters){
		set_name(n_name);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_allowoptimize(n_allowoptimize);
		set_donotrender(n_donotrender);
		set_access(n_access);
		set_storage(n_storage);
		set_isfactory(n_isfactory);
		set_iskeyword(n_iskeyword);
		set_isconst(n_isconst);
		set_isexec(n_isexec);
		set_virtual(n_virtual);
		set_nonvirtual(n_nonvirtual);
		set_override(n_override);
		set_new(n_new);
		set_final(n_final);
		set_force(n_force);
		set_abstract(n_abstract);
		set_fp(n_fp);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		set_name(n_name);
		set_allowoptimize(n_allowoptimize);
		set_donotrender(n_donotrender);
		set_access(n_access);
		set_storage(n_storage);
		set_isfactory(n_isfactory);
		set_iskeyword(n_iskeyword);
		set_isconst(n_isconst);
		set_isexec(n_isexec);
		set_virtual(n_virtual);
		set_nonvirtual(n_nonvirtual);
		set_override(n_override);
		set_new(n_new);
		set_final(n_final);
		set_force(n_force);
		set_abstract(n_abstract);
		set_fp(n_fp);
		p_Parameters=null;
		p_ReturnType=null;
		p_FunctionBody=null;
		p_BaseInitializers=null;
		p_documentation=null;
	}
	public XplFunction(string n_name, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, XplParameters n_Parameters, XplType n_ReturnType, XplFunctionBody n_FunctionBody, XplBaseInitializers n_BaseInitializers, XplDocumentation n_documentation){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_allowoptimize = false;
		p_donotrender = false;
		p_access = XplAccesstype_enum.PRIVATE;
		p_storage = XplVarstorage_enum.AUTO;
		p_isfactory = false;
		p_iskeyword = false;
		p_isconst = false;
		p_isexec = false;
		p_virtual = false;
		p_nonvirtual = false;
		p_override = false;
		p_new = false;
		p_final = false;
		p_force = false;
		p_abstract = false;
		p_fp = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_name(n_name);
		set_allowoptimize(n_allowoptimize);
		set_donotrender(n_donotrender);
		set_access(n_access);
		set_storage(n_storage);
		set_isfactory(n_isfactory);
		set_iskeyword(n_iskeyword);
		set_isconst(n_isconst);
		set_isexec(n_isexec);
		set_virtual(n_virtual);
		set_nonvirtual(n_nonvirtual);
		set_override(n_override);
		set_new(n_new);
		set_final(n_final);
		set_force(n_force);
		set_abstract(n_abstract);
		set_fp(n_fp);
		p_Parameters=null;
		p_ReturnType=null;
		p_FunctionBody=null;
		p_BaseInitializers=null;
		p_documentation=null;
		set_Parameters(n_Parameters);
		set_ReturnType(n_ReturnType);
		set_FunctionBody(n_FunctionBody);
		set_BaseInitializers(n_BaseInitializers);
		set_documentation(n_documentation);
	}
	public XplFunction(string n_name, string n_internalname, string n_externalname, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplParameters n_Parameters, XplType n_ReturnType, XplFunctionBody n_FunctionBody, XplBaseInitializers n_BaseInitializers, XplDocumentation n_documentation){
		set_name(n_name);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_allowoptimize(n_allowoptimize);
		set_donotrender(n_donotrender);
		set_access(n_access);
		set_storage(n_storage);
		set_isfactory(n_isfactory);
		set_iskeyword(n_iskeyword);
		set_isconst(n_isconst);
		set_isexec(n_isexec);
		set_virtual(n_virtual);
		set_nonvirtual(n_nonvirtual);
		set_override(n_override);
		set_new(n_new);
		set_final(n_final);
		set_force(n_force);
		set_abstract(n_abstract);
		set_fp(n_fp);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_Parameters=null;
		p_ReturnType=null;
		p_FunctionBody=null;
		p_BaseInitializers=null;
		p_documentation=null;
		set_Parameters(n_Parameters);
		set_ReturnType(n_ReturnType);
		set_FunctionBody(n_FunctionBody);
		set_BaseInitializers(n_BaseInitializers);
		set_documentation(n_documentation);
	}
	#endregion

	#region Destructor
/*	public ~XplFunction(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplFunction copy = new XplFunction();
		copy.set_name(this.p_name);
		copy.set_internalname(this.p_internalname);
		copy.set_externalname(this.p_externalname);
		copy.set_allowoptimize(this.p_allowoptimize);
		copy.set_donotrender(this.p_donotrender);
		copy.set_access(this.p_access);
		copy.set_storage(this.p_storage);
		copy.set_isfactory(this.p_isfactory);
		copy.set_iskeyword(this.p_iskeyword);
		copy.set_isconst(this.p_isconst);
		copy.set_isexec(this.p_isexec);
		copy.set_virtual(this.p_virtual);
		copy.set_nonvirtual(this.p_nonvirtual);
		copy.set_override(this.p_override);
		copy.set_new(this.p_new);
		copy.set_final(this.p_final);
		copy.set_force(this.p_force);
		copy.set_abstract(this.p_abstract);
		copy.set_fp(this.p_fp);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		if(p_Parameters!=null)copy.set_Parameters((XplParameters)p_Parameters.Clone());
		if(p_ReturnType!=null)copy.set_ReturnType((XplType)p_ReturnType.Clone());
		if(p_FunctionBody!=null)copy.set_FunctionBody((XplFunctionBody)p_FunctionBody.Clone());
		if(p_BaseInitializers!=null)copy.set_BaseInitializers((XplBaseInitializers)p_BaseInitializers.Clone());
		if(p_documentation!=null)copy.set_documentation((XplDocumentation)p_documentation.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplFunction;}

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
		if(p_allowoptimize != false)
			writer.WriteAttributeString( "allowoptimize" ,ZoeHelper .Att_ToString(p_allowoptimize) );
		if(p_donotrender != false)
			writer.WriteAttributeString( "donotrender" ,ZoeHelper .Att_ToString(p_donotrender) );
		if(p_access != XplAccesstype_enum.PRIVATE)
			writer.WriteAttributeString( "access" , CodeDOM_STV.XPLACCESSTYPE_ENUM[(int)p_access] );
		if(p_storage != XplVarstorage_enum.AUTO)
			writer.WriteAttributeString( "storage" , CodeDOM_STV.XPLVARSTORAGE_ENUM[(int)p_storage] );
		if(p_isfactory != false)
			writer.WriteAttributeString( "isfactory" ,ZoeHelper .Att_ToString(p_isfactory) );
		if(p_iskeyword != false)
			writer.WriteAttributeString( "iskeyword" ,ZoeHelper .Att_ToString(p_iskeyword) );
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
		if(p_force != false)
			writer.WriteAttributeString( "force" ,ZoeHelper .Att_ToString(p_force) );
		if(p_abstract != false)
			writer.WriteAttributeString( "abstract" ,ZoeHelper .Att_ToString(p_abstract) );
		if(p_fp != false)
			writer.WriteAttributeString( "fp" ,ZoeHelper .Att_ToString(p_fp) );
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
		if(p_Parameters!=null)if(!p_Parameters.Write(writer))result=false;
		if(p_ReturnType!=null)if(!p_ReturnType.Write(writer))result=false;
		if(p_FunctionBody!=null)if(!p_FunctionBody.Write(writer))result=false;
		if(p_BaseInitializers!=null)if(!p_BaseInitializers.Write(writer))result=false;
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
					case "internalname":
						this.set_internalname(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "externalname":
						this.set_externalname(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "allowoptimize":
						this.set_allowoptimize(ZoeHelper .StringAtt_To_BOOL(reader.Value));
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
					case "iskeyword":
						this.set_iskeyword(ZoeHelper .StringAtt_To_BOOL(reader.Value));
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
					case "force":
						this.set_force(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "abstract":
						this.set_abstract(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "fp":
						this.set_fp(ZoeHelper .StringAtt_To_BOOL(reader.Value));
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
		this.p_Parameters=null;
		this.p_ReturnType=null;
		this.p_FunctionBody=null;
		this.p_BaseInitializers=null;
		this.p_documentation=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "Parameters":
						tempNode = new XplParameters();
						tempNode.Read(reader);
						if(this.get_Parameters()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_Parameters((XplParameters)tempNode);
						break;
					case "ReturnType":
						tempNode = new XplType();
						tempNode.Read(reader);
						if(this.get_ReturnType()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_ReturnType((XplType)tempNode);
						break;
					case "FunctionBody":
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						if(this.get_FunctionBody()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_FunctionBody((XplFunctionBody)tempNode);
						break;
					case "BaseInitializers":
						tempNode = new XplBaseInitializers();
						tempNode.Read(reader);
						if(this.get_BaseInitializers()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_BaseInitializers((XplBaseInitializers)tempNode);
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
		writer.Write((int) 140 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_name );
		writer.Write( p_internalname );
		writer.Write( p_externalname );
		writer.Write( p_allowoptimize );
		writer.Write( p_donotrender );
		writer.Write( (int)p_access );
		writer.Write( (int)p_storage );
		writer.Write( p_isfactory );
		writer.Write( p_iskeyword );
		writer.Write( p_isconst );
		writer.Write( p_isexec );
		writer.Write( p_virtual );
		writer.Write( p_nonvirtual );
		writer.Write( p_override );
		writer.Write( p_new );
		writer.Write( p_final );
		writer.Write( p_force );
		writer.Write( p_abstract );
		writer.Write( p_fp );
		writer.Write( p_doc );
		writer.Write( p_helpURL );
		writer.Write( p_ldsrc );
		writer.Write( p_iny );
		writer.Write( p_inydata );
		writer.Write( p_inyby );
		writer.Write( p_lddata );
		//Escribo recursivamente cada elemento hijo
		if(p_Parameters!=null){
			writer.Write((int)1);
			if(!p_Parameters.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_ReturnType!=null){
			writer.Write((int)1);
			if(!p_ReturnType.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_FunctionBody!=null){
			writer.Write((int)1);
			if(!p_FunctionBody.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_BaseInitializers!=null){
			writer.Write((int)1);
			if(!p_BaseInitializers.BinaryWrite(writer))result=false;
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
		p_internalname = reader.ReadString();
		p_externalname = reader.ReadString();
		p_allowoptimize = reader.ReadBoolean();
		p_donotrender = reader.ReadBoolean();
		p_access = (XplAccesstype_enum)reader.ReadInt32();
		p_storage = (XplVarstorage_enum)reader.ReadInt32();
		p_isfactory = reader.ReadBoolean();
		p_iskeyword = reader.ReadBoolean();
		p_isconst = reader.ReadBoolean();
		p_isexec = reader.ReadBoolean();
		p_virtual = reader.ReadBoolean();
		p_nonvirtual = reader.ReadBoolean();
		p_override = reader.ReadBoolean();
		p_new = reader.ReadBoolean();
		p_final = reader.ReadBoolean();
		p_force = reader.ReadBoolean();
		p_abstract = reader.ReadBoolean();
		p_fp = reader.ReadBoolean();
		p_doc = reader.ReadString();
		p_helpURL = reader.ReadString();
		p_ldsrc = reader.ReadString();
		p_iny = reader.ReadBoolean();
		p_inydata = reader.ReadString();
		p_inyby = reader.ReadString();
		p_lddata = reader.ReadString();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_Parameters = (XplParameters)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_ReturnType = (XplType)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_FunctionBody = (XplFunctionBody)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		if(reader.ReadInt32()==1){
			p_BaseInitializers = (XplBaseInitializers)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
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
public static XplFunction operator +(XplFunction arg1, XplNode arg2)
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
public static XplFunction operator +(XplFunction arg1, XplNodeList arg2)
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
	public bool get_allowoptimize(){
		return p_allowoptimize;
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
	public bool get_iskeyword(){
		return p_iskeyword;
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
	public bool get_force(){
		return p_force;
	}
	public bool get_abstract(){
		return p_abstract;
	}
	public bool get_fp(){
		return p_fp;
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
	public XplParameters get_Parameters(){
		return p_Parameters;
	}
	public XplType get_ReturnType(){
		return p_ReturnType;
	}
	public XplFunctionBody get_FunctionBody(){
		return p_FunctionBody;
	}
	public XplBaseInitializers get_BaseInitializers(){
		return p_BaseInitializers;
	}
	public XplDocumentation get_documentation(){
		return p_documentation;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[26];
		ret[0] = "name";
		ret[1] = "internalname";
		ret[2] = "externalname";
		ret[3] = "allowoptimize";
		ret[4] = "donotrender";
		ret[5] = "access";
		ret[6] = "storage";
		ret[7] = "isfactory";
		ret[8] = "iskeyword";
		ret[9] = "isconst";
		ret[10] = "isexec";
		ret[11] = "virtual";
		ret[12] = "nonvirtual";
		ret[13] = "override";
		ret[14] = "new";
		ret[15] = "final";
		ret[16] = "force";
		ret[17] = "abstract";
		ret[18] = "fp";
		ret[19] = "doc";
		ret[20] = "helpURL";
		ret[21] = "ldsrc";
		ret[22] = "iny";
		ret[23] = "inydata";
		ret[24] = "inyby";
		ret[25] = "lddata";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="name") return p_name.ToString();
		if (attributeName=="internalname") return p_internalname.ToString();
		if (attributeName=="externalname") return p_externalname.ToString();
		if (attributeName=="allowoptimize") return p_allowoptimize.ToString();
		if (attributeName=="donotrender") return p_donotrender.ToString();
		if (attributeName=="access") return p_access.ToString();
		if (attributeName=="storage") return p_storage.ToString();
		if (attributeName=="isfactory") return p_isfactory.ToString();
		if (attributeName=="iskeyword") return p_iskeyword.ToString();
		if (attributeName=="isconst") return p_isconst.ToString();
		if (attributeName=="isexec") return p_isexec.ToString();
		if (attributeName=="virtual") return p_virtual.ToString();
		if (attributeName=="nonvirtual") return p_nonvirtual.ToString();
		if (attributeName=="override") return p_override.ToString();
		if (attributeName=="new") return p_new.ToString();
		if (attributeName=="final") return p_final.ToString();
		if (attributeName=="force") return p_force.ToString();
		if (attributeName=="abstract") return p_abstract.ToString();
		if (attributeName=="fp") return p_fp.ToString();
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
		list.InsertAtEnd(p_Parameters);
		list.InsertAtEnd(p_ReturnType);
		list.InsertAtEnd(p_FunctionBody);
		list.InsertAtEnd(p_BaseInitializers);
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
	public bool set_allowoptimize(bool new_allowoptimize){
		bool back_allowoptimize = p_allowoptimize;
		p_allowoptimize = new_allowoptimize;
		return back_allowoptimize;
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
	public bool set_iskeyword(bool new_iskeyword){
		bool back_iskeyword = p_iskeyword;
		p_iskeyword = new_iskeyword;
		return back_iskeyword;
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
	public bool set_force(bool new_force){
		bool back_force = p_force;
		p_force = new_force;
		return back_force;
	}
	public bool set_abstract(bool new_abstract){
		bool back_abstract = p_abstract;
		p_abstract = new_abstract;
		return back_abstract;
	}
	public bool set_fp(bool new_fp){
		bool back_fp = p_fp;
		p_fp = new_fp;
		return back_fp;
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
	public XplParameters set_Parameters(XplParameters new_Parameters){
		XplParameters back_Parameters = p_Parameters;
		p_Parameters = new_Parameters;
		if(p_Parameters!=null){
			p_Parameters.set_ElementName("Parameters");
			p_Parameters.set_Parent(this);
		}
		return back_Parameters;
	}
	public XplType set_ReturnType(XplType new_ReturnType){
		XplType back_ReturnType = p_ReturnType;
		p_ReturnType = new_ReturnType;
		if(p_ReturnType!=null){
			p_ReturnType.set_ElementName("ReturnType");
			p_ReturnType.set_Parent(this);
		}
		return back_ReturnType;
	}
	public XplFunctionBody set_FunctionBody(XplFunctionBody new_FunctionBody){
		XplFunctionBody back_FunctionBody = p_FunctionBody;
		p_FunctionBody = new_FunctionBody;
		if(p_FunctionBody!=null){
			p_FunctionBody.set_ElementName("FunctionBody");
			p_FunctionBody.set_Parent(this);
		}
		return back_FunctionBody;
	}
	public XplBaseInitializers set_BaseInitializers(XplBaseInitializers new_BaseInitializers){
		XplBaseInitializers back_BaseInitializers = p_BaseInitializers;
		p_BaseInitializers = new_BaseInitializers;
		if(p_BaseInitializers!=null){
			p_BaseInitializers.set_ElementName("BaseInitializers");
			p_BaseInitializers.set_Parent(this);
		}
		return back_BaseInitializers;
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
	static public XplParameters new_Parameters(){
		XplParameters node = new XplParameters();
		node.set_ElementName("Parameters");
		return node;
	}
	static public XplType new_ReturnType(){
		XplType node = new XplType();
		node.set_ElementName("ReturnType");
		return node;
	}
	static public XplFunctionBody new_FunctionBody(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_ElementName("FunctionBody");
		return node;
	}
	static public XplBaseInitializers new_BaseInitializers(){
		XplBaseInitializers node = new XplBaseInitializers();
		node.set_ElementName("BaseInitializers");
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

