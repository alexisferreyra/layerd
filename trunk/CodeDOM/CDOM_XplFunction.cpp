/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEFUNCTION_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEFUNCTION_V1_0_CPP
#include "CDOM_XplFunction.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplFunction::XplFunction(){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_allowoptimize = false;
	p_donotrender = false;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
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
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_Parameters=NULL;
	p_ReturnType=NULL;
	p_FunctionBody=NULL;
	p_BaseInitializers=NULL;
	p_documentation=NULL;
}
XplFunction::XplFunction(string n_name, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_allowoptimize = false;
	p_donotrender = false;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
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
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
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
	p_Parameters=NULL;
	p_ReturnType=NULL;
	p_FunctionBody=NULL;
	p_BaseInitializers=NULL;
	p_documentation=NULL;
}
XplFunction::XplFunction(XplParameters* n_Parameters){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_allowoptimize = false;
	p_donotrender = false;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
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
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_Parameters=NULL;
	p_ReturnType=NULL;
	p_FunctionBody=NULL;
	p_BaseInitializers=NULL;
	p_documentation=NULL;
	set_Parameters(n_Parameters);
}
XplFunction::XplFunction(string n_name, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, XplParameters* n_Parameters){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_allowoptimize = false;
	p_donotrender = false;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
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
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
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
	p_Parameters=NULL;
	p_ReturnType=NULL;
	p_FunctionBody=NULL;
	p_BaseInitializers=NULL;
	p_documentation=NULL;
	set_Parameters(n_Parameters);
}
XplFunction::XplFunction(string n_name, string n_internalname, string n_externalname, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
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
	p_Parameters=NULL;
	p_ReturnType=NULL;
	p_FunctionBody=NULL;
	p_BaseInitializers=NULL;
	p_documentation=NULL;
}
XplFunction::XplFunction(XplParameters* n_Parameters, XplType* n_ReturnType, XplFunctionBody* n_FunctionBody, XplBaseInitializers* n_BaseInitializers, XplDocumentation* n_documentation){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_allowoptimize = false;
	p_donotrender = false;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
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
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_Parameters=NULL;
	p_ReturnType=NULL;
	p_FunctionBody=NULL;
	p_BaseInitializers=NULL;
	p_documentation=NULL;
	set_Parameters(n_Parameters);
	set_ReturnType(n_ReturnType);
	set_FunctionBody(n_FunctionBody);
	set_BaseInitializers(n_BaseInitializers);
	set_documentation(n_documentation);
}
XplFunction::XplFunction(string n_name, string n_internalname, string n_externalname, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplParameters* n_Parameters){
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
	p_Parameters=NULL;
	p_ReturnType=NULL;
	p_FunctionBody=NULL;
	p_BaseInitializers=NULL;
	p_documentation=NULL;
}
XplFunction::XplFunction(string n_name, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, XplParameters* n_Parameters, XplType* n_ReturnType, XplFunctionBody* n_FunctionBody, XplBaseInitializers* n_BaseInitializers, XplDocumentation* n_documentation){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_allowoptimize = false;
	p_donotrender = false;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
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
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
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
	p_Parameters=NULL;
	p_ReturnType=NULL;
	p_FunctionBody=NULL;
	p_BaseInitializers=NULL;
	p_documentation=NULL;
	set_Parameters(n_Parameters);
	set_ReturnType(n_ReturnType);
	set_FunctionBody(n_FunctionBody);
	set_BaseInitializers(n_BaseInitializers);
	set_documentation(n_documentation);
}
XplFunction::XplFunction(string n_name, string n_internalname, string n_externalname, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplParameters* n_Parameters, XplType* n_ReturnType, XplFunctionBody* n_FunctionBody, XplBaseInitializers* n_BaseInitializers, XplDocumentation* n_documentation){
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
	p_Parameters=NULL;
	p_ReturnType=NULL;
	p_FunctionBody=NULL;
	p_BaseInitializers=NULL;
	p_documentation=NULL;
	set_Parameters(n_Parameters);
	set_ReturnType(n_ReturnType);
	set_FunctionBody(n_FunctionBody);
	set_BaseInitializers(n_BaseInitializers);
	set_documentation(n_documentation);
}
//Destructor
XplFunction::~XplFunction(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplFunction'");
#endif
	//Variables para Elementos de Secuencia
	if(p_Parameters!=NULL)delete p_Parameters;
	if(p_ReturnType!=NULL)delete p_ReturnType;
	if(p_FunctionBody!=NULL)delete p_FunctionBody;
	if(p_BaseInitializers!=NULL)delete p_BaseInitializers;
	if(p_documentation!=NULL)delete p_documentation;
}

//Funciones Sobreescritas de XplNode
XplNode* XplFunction::Clone(){
	XplFunction* copy = new XplFunction();
	copy->set_name(this->p_name);
	copy->set_internalname(this->p_internalname);
	copy->set_externalname(this->p_externalname);
	copy->set_allowoptimize(this->p_allowoptimize);
	copy->set_donotrender(this->p_donotrender);
	copy->set_access(this->p_access);
	copy->set_storage(this->p_storage);
	copy->set_isfactory(this->p_isfactory);
	copy->set_iskeyword(this->p_iskeyword);
	copy->set_isconst(this->p_isconst);
	copy->set_isexec(this->p_isexec);
	copy->set_virtual(this->p_virtual);
	copy->set_nonvirtual(this->p_nonvirtual);
	copy->set_override(this->p_override);
	copy->set_new(this->p_new);
	copy->set_final(this->p_final);
	copy->set_force(this->p_force);
	copy->set_abstract(this->p_abstract);
	copy->set_fp(this->p_fp);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_Parameters!=NULL)copy->set_Parameters((XplParameters*)p_Parameters->Clone());
	if(p_ReturnType!=NULL)copy->set_ReturnType((XplType*)p_ReturnType->Clone());
	if(p_FunctionBody!=NULL)copy->set_FunctionBody((XplFunctionBody*)p_FunctionBody->Clone());
	if(p_BaseInitializers!=NULL)copy->set_BaseInitializers((XplBaseInitializers*)p_BaseInitializers->Clone());
	if(p_documentation!=NULL)copy->set_documentation((XplDocumentation*)p_documentation->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplFunction::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_name != DT_EMPTY)
		writer->write(DT(" name=\"")+CODEDOM_Att_ToString(p_name)+DT("\""));
	if(p_internalname != DT_EMPTY)
		writer->write(DT(" internalname=\"")+CODEDOM_Att_ToString(p_internalname)+DT("\""));
	if(p_externalname != DT_EMPTY)
		writer->write(DT(" externalname=\"")+CODEDOM_Att_ToString(p_externalname)+DT("\""));
	if(p_allowoptimize != false)
		writer->write(DT(" allowoptimize=\"")+CODEDOM_Att_ToString(p_allowoptimize)+DT("\""));
	if(p_donotrender != false)
		writer->write(DT(" donotrender=\"")+CODEDOM_Att_ToString(p_donotrender)+DT("\""));
	if(p_access != ZOEACCESSTYPE_ENUM_PRIVATE)
		writer->write(DT(" access=\"")+(string)__CODEDOM_ZOEACCESSTYPE_ENUM[p_access]+DT("\""));
	if(p_storage != ZOEVARSTORAGE_ENUM_AUTO)
		writer->write(DT(" storage=\"")+(string)__CODEDOM_ZOEVARSTORAGE_ENUM[p_storage]+DT("\""));
	if(p_isfactory != false)
		writer->write(DT(" isfactory=\"")+CODEDOM_Att_ToString(p_isfactory)+DT("\""));
	if(p_iskeyword != false)
		writer->write(DT(" iskeyword=\"")+CODEDOM_Att_ToString(p_iskeyword)+DT("\""));
	if(p_isconst != false)
		writer->write(DT(" isconst=\"")+CODEDOM_Att_ToString(p_isconst)+DT("\""));
	if(p_isexec != false)
		writer->write(DT(" isexec=\"")+CODEDOM_Att_ToString(p_isexec)+DT("\""));
	if(p_virtual != false)
		writer->write(DT(" virtual=\"")+CODEDOM_Att_ToString(p_virtual)+DT("\""));
	if(p_nonvirtual != false)
		writer->write(DT(" nonvirtual=\"")+CODEDOM_Att_ToString(p_nonvirtual)+DT("\""));
	if(p_override != false)
		writer->write(DT(" override=\"")+CODEDOM_Att_ToString(p_override)+DT("\""));
	if(p_new != false)
		writer->write(DT(" new=\"")+CODEDOM_Att_ToString(p_new)+DT("\""));
	if(p_final != false)
		writer->write(DT(" final=\"")+CODEDOM_Att_ToString(p_final)+DT("\""));
	if(p_force != false)
		writer->write(DT(" force=\"")+CODEDOM_Att_ToString(p_force)+DT("\""));
	if(p_abstract != false)
		writer->write(DT(" abstract=\"")+CODEDOM_Att_ToString(p_abstract)+DT("\""));
	if(p_fp != false)
		writer->write(DT(" fp=\"")+CODEDOM_Att_ToString(p_fp)+DT("\""));
	if(p_doc != DT_EMPTY)
		writer->write(DT(" doc=\"")+CODEDOM_Att_ToString(p_doc)+DT("\""));
	if(p_helpURL != DT_EMPTY)
		writer->write(DT(" helpURL=\"")+CODEDOM_Att_ToString(p_helpURL)+DT("\""));
	if(p_ldsrc != DT_EMPTY)
		writer->write(DT(" ldsrc=\"")+CODEDOM_Att_ToString(p_ldsrc)+DT("\""));
	if(p_iny != false)
		writer->write(DT(" iny=\"")+CODEDOM_Att_ToString(p_iny)+DT("\""));
	if(p_inydata != DT_EMPTY)
		writer->write(DT(" inydata=\"")+CODEDOM_Att_ToString(p_inydata)+DT("\""));
	if(p_inyby != DT_EMPTY)
		writer->write(DT(" inyby=\"")+CODEDOM_Att_ToString(p_inyby)+DT("\""));
	if(p_lddata != DT_EMPTY)
		writer->write(DT(" lddata=\"")+CODEDOM_Att_ToString(p_lddata)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_Parameters!=NULL)if(!p_Parameters->Write(writer))result=false;
	if(p_ReturnType!=NULL)if(!p_ReturnType->Write(writer))result=false;
	if(p_FunctionBody!=NULL)if(!p_FunctionBody->Write(writer))result=false;
	if(p_BaseInitializers!=NULL)if(!p_BaseInitializers->Write(writer))result=false;
	if(p_documentation!=NULL)if(!p_documentation->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplFunction::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplFunction::get_name(){
	return p_name;
}
string XplFunction::get_internalname(){
	return p_internalname;
}
string XplFunction::get_externalname(){
	return p_externalname;
}
bool XplFunction::get_allowoptimize(){
	return p_allowoptimize;
}
bool XplFunction::get_donotrender(){
	return p_donotrender;
}
XplAccesstype_enum XplFunction::get_access(){
	return p_access;
}
XplVarstorage_enum XplFunction::get_storage(){
	return p_storage;
}
bool XplFunction::get_isfactory(){
	return p_isfactory;
}
bool XplFunction::get_iskeyword(){
	return p_iskeyword;
}
bool XplFunction::get_isconst(){
	return p_isconst;
}
bool XplFunction::get_isexec(){
	return p_isexec;
}
bool XplFunction::get_virtual(){
	return p_virtual;
}
bool XplFunction::get_nonvirtual(){
	return p_nonvirtual;
}
bool XplFunction::get_override(){
	return p_override;
}
bool XplFunction::get_new(){
	return p_new;
}
bool XplFunction::get_final(){
	return p_final;
}
bool XplFunction::get_force(){
	return p_force;
}
bool XplFunction::get_abstract(){
	return p_abstract;
}
bool XplFunction::get_fp(){
	return p_fp;
}
string XplFunction::get_doc(){
	return p_doc;
}
string XplFunction::get_helpURL(){
	return p_helpURL;
}
string XplFunction::get_ldsrc(){
	return p_ldsrc;
}
bool XplFunction::get_iny(){
	return p_iny;
}
string XplFunction::get_inydata(){
	return p_inydata;
}
string XplFunction::get_inyby(){
	return p_inyby;
}
string XplFunction::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplParameters* XplFunction::get_Parameters(){
	return p_Parameters;
}
XplType* XplFunction::get_ReturnType(){
	return p_ReturnType;
}
XplFunctionBody* XplFunction::get_FunctionBody(){
	return p_FunctionBody;
}
XplBaseInitializers* XplFunction::get_BaseInitializers(){
	return p_BaseInitializers;
}
XplDocumentation* XplFunction::get_documentation(){
	return p_documentation;
}

//Funciones para setear Atributos
string XplFunction::set_name(string new_name){
	string back_name = p_name;
	p_name = new_name;
	return back_name;
}
string XplFunction::set_internalname(string new_internalname){
	string back_internalname = p_internalname;
	p_internalname = new_internalname;
	return back_internalname;
}
string XplFunction::set_externalname(string new_externalname){
	string back_externalname = p_externalname;
	p_externalname = new_externalname;
	return back_externalname;
}
bool XplFunction::set_allowoptimize(bool new_allowoptimize){
	bool back_allowoptimize = p_allowoptimize;
	p_allowoptimize = new_allowoptimize;
	return back_allowoptimize;
}
bool XplFunction::set_donotrender(bool new_donotrender){
	bool back_donotrender = p_donotrender;
	p_donotrender = new_donotrender;
	return back_donotrender;
}
XplAccesstype_enum XplFunction::set_access(XplAccesstype_enum new_access){
	XplAccesstype_enum back_access = p_access;
	p_access = new_access;
	return back_access;
}
XplVarstorage_enum XplFunction::set_storage(XplVarstorage_enum new_storage){
	XplVarstorage_enum back_storage = p_storage;
	p_storage = new_storage;
	return back_storage;
}
bool XplFunction::set_isfactory(bool new_isfactory){
	bool back_isfactory = p_isfactory;
	p_isfactory = new_isfactory;
	return back_isfactory;
}
bool XplFunction::set_iskeyword(bool new_iskeyword){
	bool back_iskeyword = p_iskeyword;
	p_iskeyword = new_iskeyword;
	return back_iskeyword;
}
bool XplFunction::set_isconst(bool new_isconst){
	bool back_isconst = p_isconst;
	p_isconst = new_isconst;
	return back_isconst;
}
bool XplFunction::set_isexec(bool new_isexec){
	bool back_isexec = p_isexec;
	p_isexec = new_isexec;
	return back_isexec;
}
bool XplFunction::set_virtual(bool new_virtual){
	bool back_virtual = p_virtual;
	p_virtual = new_virtual;
	return back_virtual;
}
bool XplFunction::set_nonvirtual(bool new_nonvirtual){
	bool back_nonvirtual = p_nonvirtual;
	p_nonvirtual = new_nonvirtual;
	return back_nonvirtual;
}
bool XplFunction::set_override(bool new_override){
	bool back_override = p_override;
	p_override = new_override;
	return back_override;
}
bool XplFunction::set_new(bool new_new){
	bool back_new = p_new;
	p_new = new_new;
	return back_new;
}
bool XplFunction::set_final(bool new_final){
	bool back_final = p_final;
	p_final = new_final;
	return back_final;
}
bool XplFunction::set_force(bool new_force){
	bool back_force = p_force;
	p_force = new_force;
	return back_force;
}
bool XplFunction::set_abstract(bool new_abstract){
	bool back_abstract = p_abstract;
	p_abstract = new_abstract;
	return back_abstract;
}
bool XplFunction::set_fp(bool new_fp){
	bool back_fp = p_fp;
	p_fp = new_fp;
	return back_fp;
}
string XplFunction::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplFunction::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplFunction::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplFunction::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplFunction::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplFunction::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplFunction::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplParameters* XplFunction::set_Parameters(XplParameters* new_Parameters){
	XplParameters* back_Parameters = p_Parameters;
	p_Parameters = new_Parameters;
	if(p_Parameters!=NULL){
		p_Parameters->set_ElementName(DT("Parameters"));
		p_Parameters->set_Parent(this);
	}
	return back_Parameters;
}
XplType* XplFunction::set_ReturnType(XplType* new_ReturnType){
	XplType* back_ReturnType = p_ReturnType;
	p_ReturnType = new_ReturnType;
	if(p_ReturnType!=NULL){
		p_ReturnType->set_ElementName(DT("ReturnType"));
		p_ReturnType->set_Parent(this);
	}
	return back_ReturnType;
}
XplFunctionBody* XplFunction::set_FunctionBody(XplFunctionBody* new_FunctionBody){
	XplFunctionBody* back_FunctionBody = p_FunctionBody;
	p_FunctionBody = new_FunctionBody;
	if(p_FunctionBody!=NULL){
		p_FunctionBody->set_ElementName(DT("FunctionBody"));
		p_FunctionBody->set_Parent(this);
	}
	return back_FunctionBody;
}
XplBaseInitializers* XplFunction::set_BaseInitializers(XplBaseInitializers* new_BaseInitializers){
	XplBaseInitializers* back_BaseInitializers = p_BaseInitializers;
	p_BaseInitializers = new_BaseInitializers;
	if(p_BaseInitializers!=NULL){
		p_BaseInitializers->set_ElementName(DT("BaseInitializers"));
		p_BaseInitializers->set_Parent(this);
	}
	return back_BaseInitializers;
}
XplDocumentation* XplFunction::set_documentation(XplDocumentation* new_documentation){
	XplDocumentation* back_documentation = p_documentation;
	p_documentation = new_documentation;
	if(p_documentation!=NULL){
		p_documentation->set_ElementName(DT("documentation"));
		p_documentation->set_Parent(this);
	}
	return back_documentation;
}
XplParameters* XplFunction::new_Parameters(){
	XplParameters* node = new XplParameters();
	node->set_ElementName(DT("Parameters"));
	return node;
}
XplType* XplFunction::new_ReturnType(){
	XplType* node = new XplType();
	node->set_ElementName(DT("ReturnType"));
	return node;
}
XplFunctionBody* XplFunction::new_FunctionBody(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("FunctionBody"));
	return node;
}
XplBaseInitializers* XplFunction::new_BaseInitializers(){
	XplBaseInitializers* node = new XplBaseInitializers();
	node->set_ElementName(DT("BaseInitializers"));
	return node;
}
XplDocumentation* XplFunction::new_documentation(){
	XplDocumentation* node = new XplDocumentation();
	node->set_ElementName(DT("documentation"));
	return node;
}

}

#endif
