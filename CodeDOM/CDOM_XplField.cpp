/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEFIELD_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEFIELD_V1_0_CPP
#include "CDOM_XplField.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplField::XplField(){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_donotrender = false;
	p_firstbit = 0;
	p_lastbit = 0;
	p_address = DT_EMPTY;
	p_atomicwrite = false;
	p_atomicread = false;
	p_isfactory = false;
	p_new = false;
	p_type=NULL;
	p_i=NULL;
}
XplField::XplField(string n_name, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_donotrender, bool n_isfactory, bool n_new){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_donotrender = false;
	p_firstbit = 0;
	p_lastbit = 0;
	p_address = DT_EMPTY;
	p_atomicwrite = false;
	p_atomicread = false;
	p_isfactory = false;
	p_new = false;
	set_name(n_name);
	set_access(n_access);
	set_storage(n_storage);
	set_donotrender(n_donotrender);
	set_isfactory(n_isfactory);
	set_new(n_new);
	p_type=NULL;
	p_i=NULL;
}
XplField::XplField(XplType* n_type, XplInitializerList* n_i){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_donotrender = false;
	p_firstbit = 0;
	p_lastbit = 0;
	p_address = DT_EMPTY;
	p_atomicwrite = false;
	p_atomicread = false;
	p_isfactory = false;
	p_new = false;
	p_type=NULL;
	p_i=NULL;
	set_type(n_type);
	set_i(n_i);
}
XplField::XplField(string n_name, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_donotrender, bool n_isfactory, bool n_new, XplType* n_type, XplInitializerList* n_i){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_donotrender = false;
	p_firstbit = 0;
	p_lastbit = 0;
	p_address = DT_EMPTY;
	p_atomicwrite = false;
	p_atomicread = false;
	p_isfactory = false;
	p_new = false;
	set_name(n_name);
	set_access(n_access);
	set_storage(n_storage);
	set_donotrender(n_donotrender);
	set_isfactory(n_isfactory);
	set_new(n_new);
	p_type=NULL;
	p_i=NULL;
	set_type(n_type);
	set_i(n_i);
}
XplField::XplField(string n_name, string n_internalname, string n_externalname, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, bool n_donotrender, unsigned n_firstbit, unsigned n_lastbit, string n_address, bool n_atomicwrite, bool n_atomicread, bool n_isfactory, bool n_new){
	set_name(n_name);
	set_internalname(n_internalname);
	set_externalname(n_externalname);
	set_access(n_access);
	set_storage(n_storage);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_donotrender(n_donotrender);
	set_firstbit(n_firstbit);
	set_lastbit(n_lastbit);
	set_address(n_address);
	set_atomicwrite(n_atomicwrite);
	set_atomicread(n_atomicread);
	set_isfactory(n_isfactory);
	set_new(n_new);
	p_type=NULL;
	p_i=NULL;
}
XplField::XplField(string n_name, string n_internalname, string n_externalname, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, bool n_donotrender, unsigned n_firstbit, unsigned n_lastbit, string n_address, bool n_atomicwrite, bool n_atomicread, bool n_isfactory, bool n_new, XplType* n_type, XplInitializerList* n_i){
	set_name(n_name);
	set_internalname(n_internalname);
	set_externalname(n_externalname);
	set_access(n_access);
	set_storage(n_storage);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_donotrender(n_donotrender);
	set_firstbit(n_firstbit);
	set_lastbit(n_lastbit);
	set_address(n_address);
	set_atomicwrite(n_atomicwrite);
	set_atomicread(n_atomicread);
	set_isfactory(n_isfactory);
	set_new(n_new);
	set_name(n_name);
	set_access(n_access);
	set_storage(n_storage);
	set_donotrender(n_donotrender);
	set_isfactory(n_isfactory);
	set_new(n_new);
	p_type=NULL;
	p_i=NULL;
}
//Destructor
XplField::~XplField(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplField'");
#endif
	//Variables para Elementos de Secuencia
	if(p_type!=NULL)delete p_type;
	if(p_i!=NULL)delete p_i;
}

//Funciones Sobreescritas de XplNode
XplNode* XplField::Clone(){
	XplField* copy = new XplField();
	copy->set_name(this->p_name);
	copy->set_internalname(this->p_internalname);
	copy->set_externalname(this->p_externalname);
	copy->set_access(this->p_access);
	copy->set_storage(this->p_storage);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	copy->set_donotrender(this->p_donotrender);
	copy->set_firstbit(this->p_firstbit);
	copy->set_lastbit(this->p_lastbit);
	copy->set_address(this->p_address);
	copy->set_atomicwrite(this->p_atomicwrite);
	copy->set_atomicread(this->p_atomicread);
	copy->set_isfactory(this->p_isfactory);
	copy->set_new(this->p_new);
	if(p_type!=NULL)copy->set_type((XplType*)p_type->Clone());
	if(p_i!=NULL)copy->set_i((XplInitializerList*)p_i->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplField::Write(XplWriter* writer){
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
	if(p_access != ZOEACCESSTYPE_ENUM_PRIVATE)
		writer->write(DT(" access=\"")+(string)__CODEDOM_ZOEACCESSTYPE_ENUM[p_access]+DT("\""));
	if(p_storage != ZOEVARSTORAGE_ENUM_AUTO)
		writer->write(DT(" storage=\"")+(string)__CODEDOM_ZOEVARSTORAGE_ENUM[p_storage]+DT("\""));
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
	if(p_donotrender != false)
		writer->write(DT(" donotrender=\"")+CODEDOM_Att_ToString(p_donotrender)+DT("\""));
	if(p_firstbit != 0)
		writer->write(DT(" firstbit=\"")+CODEDOM_Att_ToString(p_firstbit)+DT("\""));
	if(p_lastbit != 0)
		writer->write(DT(" lastbit=\"")+CODEDOM_Att_ToString(p_lastbit)+DT("\""));
	if(p_address != DT_EMPTY)
		writer->write(DT(" address=\"")+CODEDOM_Att_ToString(p_address)+DT("\""));
	if(p_atomicwrite != false)
		writer->write(DT(" atomicwrite=\"")+CODEDOM_Att_ToString(p_atomicwrite)+DT("\""));
	if(p_atomicread != false)
		writer->write(DT(" atomicread=\"")+CODEDOM_Att_ToString(p_atomicread)+DT("\""));
	if(p_isfactory != false)
		writer->write(DT(" isfactory=\"")+CODEDOM_Att_ToString(p_isfactory)+DT("\""));
	if(p_new != false)
		writer->write(DT(" new=\"")+CODEDOM_Att_ToString(p_new)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_type!=NULL)if(!p_type->Write(writer))result=false;
	if(p_i!=NULL)if(!p_i->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplField::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplField::get_name(){
	return p_name;
}
string XplField::get_internalname(){
	return p_internalname;
}
string XplField::get_externalname(){
	return p_externalname;
}
XplAccesstype_enum XplField::get_access(){
	return p_access;
}
XplVarstorage_enum XplField::get_storage(){
	return p_storage;
}
string XplField::get_doc(){
	return p_doc;
}
string XplField::get_helpURL(){
	return p_helpURL;
}
string XplField::get_ldsrc(){
	return p_ldsrc;
}
bool XplField::get_iny(){
	return p_iny;
}
string XplField::get_inydata(){
	return p_inydata;
}
string XplField::get_inyby(){
	return p_inyby;
}
string XplField::get_lddata(){
	return p_lddata;
}
bool XplField::get_donotrender(){
	return p_donotrender;
}
unsigned XplField::get_firstbit(){
	return p_firstbit;
}
unsigned XplField::get_lastbit(){
	return p_lastbit;
}
string XplField::get_address(){
	return p_address;
}
bool XplField::get_atomicwrite(){
	return p_atomicwrite;
}
bool XplField::get_atomicread(){
	return p_atomicread;
}
bool XplField::get_isfactory(){
	return p_isfactory;
}
bool XplField::get_new(){
	return p_new;
}

//Funciones para obtener Elementos de Secuencia
XplType* XplField::get_type(){
	return p_type;
}
XplInitializerList* XplField::get_i(){
	return p_i;
}

//Funciones para setear Atributos
string XplField::set_name(string new_name){
	string back_name = p_name;
	p_name = new_name;
	return back_name;
}
string XplField::set_internalname(string new_internalname){
	string back_internalname = p_internalname;
	p_internalname = new_internalname;
	return back_internalname;
}
string XplField::set_externalname(string new_externalname){
	string back_externalname = p_externalname;
	p_externalname = new_externalname;
	return back_externalname;
}
XplAccesstype_enum XplField::set_access(XplAccesstype_enum new_access){
	XplAccesstype_enum back_access = p_access;
	p_access = new_access;
	return back_access;
}
XplVarstorage_enum XplField::set_storage(XplVarstorage_enum new_storage){
	XplVarstorage_enum back_storage = p_storage;
	p_storage = new_storage;
	return back_storage;
}
string XplField::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplField::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplField::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplField::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplField::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplField::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplField::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}
bool XplField::set_donotrender(bool new_donotrender){
	bool back_donotrender = p_donotrender;
	p_donotrender = new_donotrender;
	return back_donotrender;
}
unsigned XplField::set_firstbit(unsigned new_firstbit){
	unsigned back_firstbit = p_firstbit;
	p_firstbit = new_firstbit;
	return back_firstbit;
}
unsigned XplField::set_lastbit(unsigned new_lastbit){
	unsigned back_lastbit = p_lastbit;
	p_lastbit = new_lastbit;
	return back_lastbit;
}
string XplField::set_address(string new_address){
	string back_address = p_address;
	p_address = new_address;
	return back_address;
}
bool XplField::set_atomicwrite(bool new_atomicwrite){
	bool back_atomicwrite = p_atomicwrite;
	p_atomicwrite = new_atomicwrite;
	return back_atomicwrite;
}
bool XplField::set_atomicread(bool new_atomicread){
	bool back_atomicread = p_atomicread;
	p_atomicread = new_atomicread;
	return back_atomicread;
}
bool XplField::set_isfactory(bool new_isfactory){
	bool back_isfactory = p_isfactory;
	p_isfactory = new_isfactory;
	return back_isfactory;
}
bool XplField::set_new(bool new_new){
	bool back_new = p_new;
	p_new = new_new;
	return back_new;
}

//Funciones para setear Elementos de Secuencia
XplType* XplField::set_type(XplType* new_type){
	XplType* back_type = p_type;
	p_type = new_type;
	if(p_type!=NULL){
		p_type->set_ElementName(DT("type"));
		p_type->set_Parent(this);
	}
	return back_type;
}
XplInitializerList* XplField::set_i(XplInitializerList* new_i){
	XplInitializerList* back_i = p_i;
	p_i = new_i;
	if(p_i!=NULL){
		p_i->set_ElementName(DT("i"));
		p_i->set_Parent(this);
	}
	return back_i;
}
XplType* XplField::new_type(){
	XplType* node = new XplType();
	node->set_ElementName(DT("type"));
	return node;
}
XplInitializerList* XplField::new_i(){
	XplInitializerList* node = new XplInitializerList();
	node->set_ElementName(DT("i"));
	return node;
}

}

#endif
