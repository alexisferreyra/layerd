/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEPROPERTY_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEPROPERTY_V1_0_CPP
#include "CDOM_XplProperty.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplProperty::XplProperty(){
	p_name = DT_EMPTY;
	p_getfunction = DT_EMPTY;
	p_setfunction = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_donotrender = false;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
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
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_type=NULL;
	p_body=NULL;
	p_documentation=NULL;
}
XplProperty::XplProperty(string n_name, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external){
	p_name = DT_EMPTY;
	p_getfunction = DT_EMPTY;
	p_setfunction = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_donotrender = false;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
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
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
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
	p_type=NULL;
	p_body=NULL;
	p_documentation=NULL;
}
XplProperty::XplProperty(XplType* n_type){
	p_name = DT_EMPTY;
	p_getfunction = DT_EMPTY;
	p_setfunction = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_donotrender = false;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
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
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_type=NULL;
	p_body=NULL;
	p_documentation=NULL;
	set_type(n_type);
}
XplProperty::XplProperty(string n_name, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, XplType* n_type){
	p_name = DT_EMPTY;
	p_getfunction = DT_EMPTY;
	p_setfunction = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_donotrender = false;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
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
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
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
	p_type=NULL;
	p_body=NULL;
	p_documentation=NULL;
	set_type(n_type);
}
XplProperty::XplProperty(string n_name, string n_getfunction, string n_setfunction, string n_internalname, string n_externalname, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
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
	p_type=NULL;
	p_body=NULL;
	p_documentation=NULL;
}
XplProperty::XplProperty(XplType* n_type, XplFunctionBody* n_body, XplDocumentation* n_documentation){
	p_name = DT_EMPTY;
	p_getfunction = DT_EMPTY;
	p_setfunction = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_donotrender = false;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
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
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_type=NULL;
	p_body=NULL;
	p_documentation=NULL;
	set_type(n_type);
	set_body(n_body);
	set_documentation(n_documentation);
}
XplProperty::XplProperty(string n_name, string n_getfunction, string n_setfunction, string n_internalname, string n_externalname, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type){
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
	p_type=NULL;
	p_body=NULL;
	p_documentation=NULL;
}
XplProperty::XplProperty(string n_name, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, XplType* n_type, XplFunctionBody* n_body, XplDocumentation* n_documentation){
	p_name = DT_EMPTY;
	p_getfunction = DT_EMPTY;
	p_setfunction = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_donotrender = false;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
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
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
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
	p_type=NULL;
	p_body=NULL;
	p_documentation=NULL;
	set_type(n_type);
	set_body(n_body);
	set_documentation(n_documentation);
}
XplProperty::XplProperty(string n_name, string n_getfunction, string n_setfunction, string n_internalname, string n_externalname, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type, XplFunctionBody* n_body, XplDocumentation* n_documentation){
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
	p_type=NULL;
	p_body=NULL;
	p_documentation=NULL;
	set_type(n_type);
	set_body(n_body);
	set_documentation(n_documentation);
}
//Destructor
XplProperty::~XplProperty(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplProperty'");
#endif
	//Variables para Elementos de Secuencia
	if(p_type!=NULL)delete p_type;
	if(p_body!=NULL)delete p_body;
	if(p_documentation!=NULL)delete p_documentation;
}

//Funciones Sobreescritas de XplNode
XplNode* XplProperty::Clone(){
	XplProperty* copy = new XplProperty();
	copy->set_name(this->p_name);
	copy->set_getfunction(this->p_getfunction);
	copy->set_setfunction(this->p_setfunction);
	copy->set_internalname(this->p_internalname);
	copy->set_externalname(this->p_externalname);
	copy->set_donotrender(this->p_donotrender);
	copy->set_access(this->p_access);
	copy->set_storage(this->p_storage);
	copy->set_isfactory(this->p_isfactory);
	copy->set_isconst(this->p_isconst);
	copy->set_isexec(this->p_isexec);
	copy->set_virtual(this->p_virtual);
	copy->set_nonvirtual(this->p_nonvirtual);
	copy->set_override(this->p_override);
	copy->set_new(this->p_new);
	copy->set_final(this->p_final);
	copy->set_abstract(this->p_abstract);
	copy->set_external(this->p_external);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_type!=NULL)copy->set_type((XplType*)p_type->Clone());
	if(p_body!=NULL)copy->set_body((XplFunctionBody*)p_body->Clone());
	if(p_documentation!=NULL)copy->set_documentation((XplDocumentation*)p_documentation->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplProperty::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_name != DT_EMPTY)
		writer->write(DT(" name=\"")+CODEDOM_Att_ToString(p_name)+DT("\""));
	if(p_getfunction != DT_EMPTY)
		writer->write(DT(" getfunction=\"")+CODEDOM_Att_ToString(p_getfunction)+DT("\""));
	if(p_setfunction != DT_EMPTY)
		writer->write(DT(" setfunction=\"")+CODEDOM_Att_ToString(p_setfunction)+DT("\""));
	if(p_internalname != DT_EMPTY)
		writer->write(DT(" internalname=\"")+CODEDOM_Att_ToString(p_internalname)+DT("\""));
	if(p_externalname != DT_EMPTY)
		writer->write(DT(" externalname=\"")+CODEDOM_Att_ToString(p_externalname)+DT("\""));
	if(p_donotrender != false)
		writer->write(DT(" donotrender=\"")+CODEDOM_Att_ToString(p_donotrender)+DT("\""));
	if(p_access != ZOEACCESSTYPE_ENUM_PRIVATE)
		writer->write(DT(" access=\"")+(string)__CODEDOM_ZOEACCESSTYPE_ENUM[p_access]+DT("\""));
	if(p_storage != ZOEVARSTORAGE_ENUM_AUTO)
		writer->write(DT(" storage=\"")+(string)__CODEDOM_ZOEVARSTORAGE_ENUM[p_storage]+DT("\""));
	if(p_isfactory != false)
		writer->write(DT(" isfactory=\"")+CODEDOM_Att_ToString(p_isfactory)+DT("\""));
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
	if(p_abstract != false)
		writer->write(DT(" abstract=\"")+CODEDOM_Att_ToString(p_abstract)+DT("\""));
	if(p_external != false)
		writer->write(DT(" external=\"")+CODEDOM_Att_ToString(p_external)+DT("\""));
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
	if(p_type!=NULL)if(!p_type->Write(writer))result=false;
	if(p_body!=NULL)if(!p_body->Write(writer))result=false;
	if(p_documentation!=NULL)if(!p_documentation->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplProperty::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplProperty::get_name(){
	return p_name;
}
string XplProperty::get_getfunction(){
	return p_getfunction;
}
string XplProperty::get_setfunction(){
	return p_setfunction;
}
string XplProperty::get_internalname(){
	return p_internalname;
}
string XplProperty::get_externalname(){
	return p_externalname;
}
bool XplProperty::get_donotrender(){
	return p_donotrender;
}
XplAccesstype_enum XplProperty::get_access(){
	return p_access;
}
XplVarstorage_enum XplProperty::get_storage(){
	return p_storage;
}
bool XplProperty::get_isfactory(){
	return p_isfactory;
}
bool XplProperty::get_isconst(){
	return p_isconst;
}
bool XplProperty::get_isexec(){
	return p_isexec;
}
bool XplProperty::get_virtual(){
	return p_virtual;
}
bool XplProperty::get_nonvirtual(){
	return p_nonvirtual;
}
bool XplProperty::get_override(){
	return p_override;
}
bool XplProperty::get_new(){
	return p_new;
}
bool XplProperty::get_final(){
	return p_final;
}
bool XplProperty::get_abstract(){
	return p_abstract;
}
bool XplProperty::get_external(){
	return p_external;
}
string XplProperty::get_doc(){
	return p_doc;
}
string XplProperty::get_helpURL(){
	return p_helpURL;
}
string XplProperty::get_ldsrc(){
	return p_ldsrc;
}
bool XplProperty::get_iny(){
	return p_iny;
}
string XplProperty::get_inydata(){
	return p_inydata;
}
string XplProperty::get_inyby(){
	return p_inyby;
}
string XplProperty::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplType* XplProperty::get_type(){
	return p_type;
}
XplFunctionBody* XplProperty::get_body(){
	return p_body;
}
XplDocumentation* XplProperty::get_documentation(){
	return p_documentation;
}

//Funciones para setear Atributos
string XplProperty::set_name(string new_name){
	string back_name = p_name;
	p_name = new_name;
	return back_name;
}
string XplProperty::set_getfunction(string new_getfunction){
	string back_getfunction = p_getfunction;
	p_getfunction = new_getfunction;
	return back_getfunction;
}
string XplProperty::set_setfunction(string new_setfunction){
	string back_setfunction = p_setfunction;
	p_setfunction = new_setfunction;
	return back_setfunction;
}
string XplProperty::set_internalname(string new_internalname){
	string back_internalname = p_internalname;
	p_internalname = new_internalname;
	return back_internalname;
}
string XplProperty::set_externalname(string new_externalname){
	string back_externalname = p_externalname;
	p_externalname = new_externalname;
	return back_externalname;
}
bool XplProperty::set_donotrender(bool new_donotrender){
	bool back_donotrender = p_donotrender;
	p_donotrender = new_donotrender;
	return back_donotrender;
}
XplAccesstype_enum XplProperty::set_access(XplAccesstype_enum new_access){
	XplAccesstype_enum back_access = p_access;
	p_access = new_access;
	return back_access;
}
XplVarstorage_enum XplProperty::set_storage(XplVarstorage_enum new_storage){
	XplVarstorage_enum back_storage = p_storage;
	p_storage = new_storage;
	return back_storage;
}
bool XplProperty::set_isfactory(bool new_isfactory){
	bool back_isfactory = p_isfactory;
	p_isfactory = new_isfactory;
	return back_isfactory;
}
bool XplProperty::set_isconst(bool new_isconst){
	bool back_isconst = p_isconst;
	p_isconst = new_isconst;
	return back_isconst;
}
bool XplProperty::set_isexec(bool new_isexec){
	bool back_isexec = p_isexec;
	p_isexec = new_isexec;
	return back_isexec;
}
bool XplProperty::set_virtual(bool new_virtual){
	bool back_virtual = p_virtual;
	p_virtual = new_virtual;
	return back_virtual;
}
bool XplProperty::set_nonvirtual(bool new_nonvirtual){
	bool back_nonvirtual = p_nonvirtual;
	p_nonvirtual = new_nonvirtual;
	return back_nonvirtual;
}
bool XplProperty::set_override(bool new_override){
	bool back_override = p_override;
	p_override = new_override;
	return back_override;
}
bool XplProperty::set_new(bool new_new){
	bool back_new = p_new;
	p_new = new_new;
	return back_new;
}
bool XplProperty::set_final(bool new_final){
	bool back_final = p_final;
	p_final = new_final;
	return back_final;
}
bool XplProperty::set_abstract(bool new_abstract){
	bool back_abstract = p_abstract;
	p_abstract = new_abstract;
	return back_abstract;
}
bool XplProperty::set_external(bool new_external){
	bool back_external = p_external;
	p_external = new_external;
	return back_external;
}
string XplProperty::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplProperty::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplProperty::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplProperty::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplProperty::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplProperty::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplProperty::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplType* XplProperty::set_type(XplType* new_type){
	XplType* back_type = p_type;
	p_type = new_type;
	if(p_type!=NULL){
		p_type->set_ElementName(DT("type"));
		p_type->set_Parent(this);
	}
	return back_type;
}
XplFunctionBody* XplProperty::set_body(XplFunctionBody* new_body){
	XplFunctionBody* back_body = p_body;
	p_body = new_body;
	if(p_body!=NULL){
		p_body->set_ElementName(DT("body"));
		p_body->set_Parent(this);
	}
	return back_body;
}
XplDocumentation* XplProperty::set_documentation(XplDocumentation* new_documentation){
	XplDocumentation* back_documentation = p_documentation;
	p_documentation = new_documentation;
	if(p_documentation!=NULL){
		p_documentation->set_ElementName(DT("documentation"));
		p_documentation->set_Parent(this);
	}
	return back_documentation;
}
XplType* XplProperty::new_type(){
	XplType* node = new XplType();
	node->set_ElementName(DT("type"));
	return node;
}
XplFunctionBody* XplProperty::new_body(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("body"));
	return node;
}
XplDocumentation* XplProperty::new_documentation(){
	XplDocumentation* node = new XplDocumentation();
	node->set_ElementName(DT("documentation"));
	return node;
}

}

#endif
