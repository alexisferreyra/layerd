/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEPARAMETER_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEPARAMETER_V1_0_CPP
#include "CDOM_XplParameter.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplParameter::XplParameter(){
	p_name = DT_EMPTY;
	p_number = 0;
	p_direction = ZOEPARAMETERDIRECTION_ENUM_IN;
	p_params = false;
	p_donotrender = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_type=NULL;
	p_i=NULL;
}
XplParameter::XplParameter(unsigned n_number, XplParameterdirection_enum n_direction, bool n_params, bool n_donotrender){
	p_name = DT_EMPTY;
	p_number = 0;
	p_direction = ZOEPARAMETERDIRECTION_ENUM_IN;
	p_params = false;
	p_donotrender = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_number(n_number);
	set_direction(n_direction);
	set_params(n_params);
	set_donotrender(n_donotrender);
	p_type=NULL;
	p_i=NULL;
}
XplParameter::XplParameter(XplType* n_type){
	p_name = DT_EMPTY;
	p_number = 0;
	p_direction = ZOEPARAMETERDIRECTION_ENUM_IN;
	p_params = false;
	p_donotrender = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_type=NULL;
	p_i=NULL;
	set_type(n_type);
}
XplParameter::XplParameter(unsigned n_number, XplParameterdirection_enum n_direction, bool n_params, bool n_donotrender, XplType* n_type){
	p_name = DT_EMPTY;
	p_number = 0;
	p_direction = ZOEPARAMETERDIRECTION_ENUM_IN;
	p_params = false;
	p_donotrender = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_number(n_number);
	set_direction(n_direction);
	set_params(n_params);
	set_donotrender(n_donotrender);
	p_type=NULL;
	p_i=NULL;
	set_type(n_type);
}
XplParameter::XplParameter(string n_name, unsigned n_number, XplParameterdirection_enum n_direction, bool n_params, bool n_donotrender, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_name(n_name);
	set_number(n_number);
	set_direction(n_direction);
	set_params(n_params);
	set_donotrender(n_donotrender);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_type=NULL;
	p_i=NULL;
}
XplParameter::XplParameter(XplType* n_type, XplInitializerList* n_i){
	p_name = DT_EMPTY;
	p_number = 0;
	p_direction = ZOEPARAMETERDIRECTION_ENUM_IN;
	p_params = false;
	p_donotrender = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_type=NULL;
	p_i=NULL;
	set_type(n_type);
	set_i(n_i);
}
XplParameter::XplParameter(string n_name, unsigned n_number, XplParameterdirection_enum n_direction, bool n_params, bool n_donotrender, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type){
	set_name(n_name);
	set_number(n_number);
	set_direction(n_direction);
	set_params(n_params);
	set_donotrender(n_donotrender);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_number(n_number);
	set_direction(n_direction);
	set_params(n_params);
	set_donotrender(n_donotrender);
	p_type=NULL;
	p_i=NULL;
}
XplParameter::XplParameter(unsigned n_number, XplParameterdirection_enum n_direction, bool n_params, bool n_donotrender, XplType* n_type, XplInitializerList* n_i){
	p_name = DT_EMPTY;
	p_number = 0;
	p_direction = ZOEPARAMETERDIRECTION_ENUM_IN;
	p_params = false;
	p_donotrender = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_number(n_number);
	set_direction(n_direction);
	set_params(n_params);
	set_donotrender(n_donotrender);
	p_type=NULL;
	p_i=NULL;
	set_type(n_type);
	set_i(n_i);
}
XplParameter::XplParameter(string n_name, unsigned n_number, XplParameterdirection_enum n_direction, bool n_params, bool n_donotrender, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type, XplInitializerList* n_i){
	set_name(n_name);
	set_number(n_number);
	set_direction(n_direction);
	set_params(n_params);
	set_donotrender(n_donotrender);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_type=NULL;
	p_i=NULL;
	set_type(n_type);
	set_i(n_i);
}
//Destructor
XplParameter::~XplParameter(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplParameter'");
#endif
	//Variables para Elementos de Secuencia
	if(p_type!=NULL)delete p_type;
	if(p_i!=NULL)delete p_i;
}

//Funciones Sobreescritas de XplNode
XplNode* XplParameter::Clone(){
	XplParameter* copy = new XplParameter();
	copy->set_name(this->p_name);
	copy->set_number(this->p_number);
	copy->set_direction(this->p_direction);
	copy->set_params(this->p_params);
	copy->set_donotrender(this->p_donotrender);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_type!=NULL)copy->set_type((XplType*)p_type->Clone());
	if(p_i!=NULL)copy->set_i((XplInitializerList*)p_i->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplParameter::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_name != DT_EMPTY)
		writer->write(DT(" name=\"")+CODEDOM_Att_ToString(p_name)+DT("\""));
	if(p_number != 0)
		writer->write(DT(" number=\"")+CODEDOM_Att_ToString(p_number)+DT("\""));
	if(p_direction != ZOEPARAMETERDIRECTION_ENUM_IN)
		writer->write(DT(" direction=\"")+(string)__CODEDOM_ZOEPARAMETERDIRECTION_ENUM[p_direction]+DT("\""));
	if(p_params != false)
		writer->write(DT(" params=\"")+CODEDOM_Att_ToString(p_params)+DT("\""));
	if(p_donotrender != false)
		writer->write(DT(" donotrender=\"")+CODEDOM_Att_ToString(p_donotrender)+DT("\""));
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
	if(p_i!=NULL)if(!p_i->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplParameter::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplParameter::get_name(){
	return p_name;
}
unsigned XplParameter::get_number(){
	return p_number;
}
XplParameterdirection_enum XplParameter::get_direction(){
	return p_direction;
}
bool XplParameter::get_params(){
	return p_params;
}
bool XplParameter::get_donotrender(){
	return p_donotrender;
}
string XplParameter::get_doc(){
	return p_doc;
}
string XplParameter::get_helpURL(){
	return p_helpURL;
}
string XplParameter::get_ldsrc(){
	return p_ldsrc;
}
bool XplParameter::get_iny(){
	return p_iny;
}
string XplParameter::get_inydata(){
	return p_inydata;
}
string XplParameter::get_inyby(){
	return p_inyby;
}
string XplParameter::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplType* XplParameter::get_type(){
	return p_type;
}
XplInitializerList* XplParameter::get_i(){
	return p_i;
}

//Funciones para setear Atributos
string XplParameter::set_name(string new_name){
	string back_name = p_name;
	p_name = new_name;
	return back_name;
}
unsigned XplParameter::set_number(unsigned new_number){
	unsigned back_number = p_number;
	p_number = new_number;
	return back_number;
}
XplParameterdirection_enum XplParameter::set_direction(XplParameterdirection_enum new_direction){
	XplParameterdirection_enum back_direction = p_direction;
	p_direction = new_direction;
	return back_direction;
}
bool XplParameter::set_params(bool new_params){
	bool back_params = p_params;
	p_params = new_params;
	return back_params;
}
bool XplParameter::set_donotrender(bool new_donotrender){
	bool back_donotrender = p_donotrender;
	p_donotrender = new_donotrender;
	return back_donotrender;
}
string XplParameter::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplParameter::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplParameter::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplParameter::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplParameter::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplParameter::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplParameter::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplType* XplParameter::set_type(XplType* new_type){
	XplType* back_type = p_type;
	p_type = new_type;
	if(p_type!=NULL){
		p_type->set_ElementName(DT("type"));
		p_type->set_Parent(this);
	}
	return back_type;
}
XplInitializerList* XplParameter::set_i(XplInitializerList* new_i){
	XplInitializerList* back_i = p_i;
	p_i = new_i;
	if(p_i!=NULL){
		p_i->set_ElementName(DT("i"));
		p_i->set_Parent(this);
	}
	return back_i;
}
XplType* XplParameter::new_type(){
	XplType* node = new XplType();
	node->set_ElementName(DT("type"));
	return node;
}
XplInitializerList* XplParameter::new_i(){
	XplInitializerList* node = new XplInitializerList();
	node->set_ElementName(DT("i"));
	return node;
}

}

#endif
