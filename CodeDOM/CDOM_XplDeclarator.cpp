/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEDECLARATOR_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEDECLARATOR_V1_0_CPP
#include "CDOM_XplDeclarator.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplDeclarator::XplDeclarator(){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_donotrender = false;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_address = DT_EMPTY;
	p_atomicwrite = false;
	p_atomicread = false;
	p_type=NULL;
	p_aliasref=NULL;
	p_i=NULL;
}
XplDeclarator::XplDeclarator(string n_name, string n_internalname, string n_externalname, bool n_donotrender, XplVarstorage_enum n_storage, bool n_atomicwrite, bool n_atomicread){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_donotrender = false;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_address = DT_EMPTY;
	p_atomicwrite = false;
	p_atomicread = false;
	set_name(n_name);
	set_internalname(n_internalname);
	set_externalname(n_externalname);
	set_donotrender(n_donotrender);
	set_storage(n_storage);
	set_atomicwrite(n_atomicwrite);
	set_atomicread(n_atomicread);
	p_type=NULL;
	p_aliasref=NULL;
	p_i=NULL;
}
XplDeclarator::XplDeclarator(string n_name, string n_internalname, string n_externalname, bool n_donotrender, XplVarstorage_enum n_storage, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, string n_address, bool n_atomicwrite, bool n_atomicread){
	set_name(n_name);
	set_internalname(n_internalname);
	set_externalname(n_externalname);
	set_donotrender(n_donotrender);
	set_storage(n_storage);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_address(n_address);
	set_atomicwrite(n_atomicwrite);
	set_atomicread(n_atomicread);
	p_type=NULL;
	p_aliasref=NULL;
	p_i=NULL;
}
XplDeclarator::XplDeclarator(XplType* n_type, XplNode* n_aliasref, XplInitializerList* n_i){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_donotrender = false;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_address = DT_EMPTY;
	p_atomicwrite = false;
	p_atomicread = false;
	p_type=NULL;
	p_aliasref=NULL;
	p_i=NULL;
	set_type(n_type);
	set_aliasref(n_aliasref);
	set_i(n_i);
}
XplDeclarator::XplDeclarator(string n_name, string n_internalname, string n_externalname, bool n_donotrender, XplVarstorage_enum n_storage, bool n_atomicwrite, bool n_atomicread, XplType* n_type, XplNode* n_aliasref, XplInitializerList* n_i){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_donotrender = false;
	p_storage = ZOEVARSTORAGE_ENUM_AUTO;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_address = DT_EMPTY;
	p_atomicwrite = false;
	p_atomicread = false;
	set_name(n_name);
	set_internalname(n_internalname);
	set_externalname(n_externalname);
	set_donotrender(n_donotrender);
	set_storage(n_storage);
	set_atomicwrite(n_atomicwrite);
	set_atomicread(n_atomicread);
	p_type=NULL;
	p_aliasref=NULL;
	p_i=NULL;
	set_type(n_type);
	set_aliasref(n_aliasref);
	set_i(n_i);
}
XplDeclarator::XplDeclarator(string n_name, string n_internalname, string n_externalname, bool n_donotrender, XplVarstorage_enum n_storage, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, string n_address, bool n_atomicwrite, bool n_atomicread, XplType* n_type, XplNode* n_aliasref, XplInitializerList* n_i){
	set_name(n_name);
	set_internalname(n_internalname);
	set_externalname(n_externalname);
	set_donotrender(n_donotrender);
	set_storage(n_storage);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_address(n_address);
	set_atomicwrite(n_atomicwrite);
	set_atomicread(n_atomicread);
	p_type=NULL;
	p_aliasref=NULL;
	p_i=NULL;
	set_type(n_type);
	set_aliasref(n_aliasref);
	set_i(n_i);
}
//Destructor
XplDeclarator::~XplDeclarator(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplDeclarator'");
#endif
	//Variables para Elementos de Secuencia
	if(p_type!=NULL)delete p_type;
	if(p_aliasref!=NULL)delete p_aliasref;
	if(p_i!=NULL)delete p_i;
}

//Funciones Sobreescritas de XplNode
XplNode* XplDeclarator::Clone(){
	XplDeclarator* copy = new XplDeclarator();
	copy->set_name(this->p_name);
	copy->set_internalname(this->p_internalname);
	copy->set_externalname(this->p_externalname);
	copy->set_donotrender(this->p_donotrender);
	copy->set_storage(this->p_storage);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	copy->set_address(this->p_address);
	copy->set_atomicwrite(this->p_atomicwrite);
	copy->set_atomicread(this->p_atomicread);
	if(p_type!=NULL)copy->set_type((XplType*)p_type->Clone());
	if(p_aliasref!=NULL)copy->set_aliasref(p_aliasref->Clone());
	if(p_i!=NULL)copy->set_i((XplInitializerList*)p_i->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplDeclarator::Write(XplWriter* writer){
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
	if(p_donotrender != false)
		writer->write(DT(" donotrender=\"")+CODEDOM_Att_ToString(p_donotrender)+DT("\""));
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
	if(p_address != DT_EMPTY)
		writer->write(DT(" address=\"")+CODEDOM_Att_ToString(p_address)+DT("\""));
	if(p_atomicwrite != false)
		writer->write(DT(" atomicwrite=\"")+CODEDOM_Att_ToString(p_atomicwrite)+DT("\""));
	if(p_atomicread != false)
		writer->write(DT(" atomicread=\"")+CODEDOM_Att_ToString(p_atomicread)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_type!=NULL)if(!p_type->Write(writer))result=false;
	if(p_aliasref!=NULL)if(!p_aliasref->Write(writer))result=false;
	if(p_i!=NULL)if(!p_i->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplDeclarator::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplDeclarator::get_name(){
	return p_name;
}
string XplDeclarator::get_internalname(){
	return p_internalname;
}
string XplDeclarator::get_externalname(){
	return p_externalname;
}
bool XplDeclarator::get_donotrender(){
	return p_donotrender;
}
XplVarstorage_enum XplDeclarator::get_storage(){
	return p_storage;
}
string XplDeclarator::get_doc(){
	return p_doc;
}
string XplDeclarator::get_helpURL(){
	return p_helpURL;
}
string XplDeclarator::get_ldsrc(){
	return p_ldsrc;
}
bool XplDeclarator::get_iny(){
	return p_iny;
}
string XplDeclarator::get_inydata(){
	return p_inydata;
}
string XplDeclarator::get_inyby(){
	return p_inyby;
}
string XplDeclarator::get_lddata(){
	return p_lddata;
}
string XplDeclarator::get_address(){
	return p_address;
}
bool XplDeclarator::get_atomicwrite(){
	return p_atomicwrite;
}
bool XplDeclarator::get_atomicread(){
	return p_atomicread;
}

//Funciones para obtener Elementos de Secuencia
XplType* XplDeclarator::get_type(){
	return p_type;
}
XplNode* XplDeclarator::get_aliasref(){
	return p_aliasref;
}
XplInitializerList* XplDeclarator::get_i(){
	return p_i;
}

//Funciones para setear Atributos
string XplDeclarator::set_name(string new_name){
	string back_name = p_name;
	p_name = new_name;
	return back_name;
}
string XplDeclarator::set_internalname(string new_internalname){
	string back_internalname = p_internalname;
	p_internalname = new_internalname;
	return back_internalname;
}
string XplDeclarator::set_externalname(string new_externalname){
	string back_externalname = p_externalname;
	p_externalname = new_externalname;
	return back_externalname;
}
bool XplDeclarator::set_donotrender(bool new_donotrender){
	bool back_donotrender = p_donotrender;
	p_donotrender = new_donotrender;
	return back_donotrender;
}
XplVarstorage_enum XplDeclarator::set_storage(XplVarstorage_enum new_storage){
	XplVarstorage_enum back_storage = p_storage;
	p_storage = new_storage;
	return back_storage;
}
string XplDeclarator::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplDeclarator::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplDeclarator::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplDeclarator::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplDeclarator::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplDeclarator::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplDeclarator::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}
string XplDeclarator::set_address(string new_address){
	string back_address = p_address;
	p_address = new_address;
	return back_address;
}
bool XplDeclarator::set_atomicwrite(bool new_atomicwrite){
	bool back_atomicwrite = p_atomicwrite;
	p_atomicwrite = new_atomicwrite;
	return back_atomicwrite;
}
bool XplDeclarator::set_atomicread(bool new_atomicread){
	bool back_atomicread = p_atomicread;
	p_atomicread = new_atomicread;
	return back_atomicread;
}

//Funciones para setear Elementos de Secuencia
XplType* XplDeclarator::set_type(XplType* new_type){
	XplType* back_type = p_type;
	p_type = new_type;
	if(p_type!=NULL){
		p_type->set_ElementName(DT("type"));
		p_type->set_Parent(this);
	}
	return back_type;
}
XplNode* XplDeclarator::set_aliasref(XplNode* new_aliasref){
	if(new_aliasref->get_ContentTypeName()!=CODEDOMTYPES_STRING){
		this->set_ErrorString(DT("El nodo que intenta asignar a la propiedad es de un tipo incorrecto."));
		return NULL;
	}
	XplNode* back_aliasref = p_aliasref;
	p_aliasref = new_aliasref;
	if(p_aliasref!=NULL){
		p_aliasref->set_Parent(this);
		p_aliasref->set_ElementName(DT("aliasref"));
	}
	return back_aliasref;
}
XplInitializerList* XplDeclarator::set_i(XplInitializerList* new_i){
	XplInitializerList* back_i = p_i;
	p_i = new_i;
	if(p_i!=NULL){
		p_i->set_ElementName(DT("i"));
		p_i->set_Parent(this);
	}
	return back_i;
}
XplType* XplDeclarator::new_type(){
	XplType* node = new XplType();
	node->set_ElementName(DT("type"));
	return node;
}
XplNode* XplDeclarator::new_aliasref(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("aliasref"));
	return node;
}
XplInitializerList* XplDeclarator::new_i(){
	XplInitializerList* node = new XplInitializerList();
	node->set_ElementName(DT("i"));
	return node;
}

}

#endif
