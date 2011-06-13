/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEPOINTERINFO_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEPOINTERINFO_V1_0_CPP
#include "CDOM_XplPointerinfo.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplPointerinfo::XplPointerinfo(){
	p_memberof = DT_EMPTY;
	p_const = false;
	p_volatile = false;
	p_ref = false;
	p_removeonvalue = false;
}
XplPointerinfo::XplPointerinfo(bool n_const, bool n_volatile, bool n_ref, bool n_removeonvalue){
	p_memberof = DT_EMPTY;
	p_const = false;
	p_volatile = false;
	p_ref = false;
	p_removeonvalue = false;
	set_const(n_const);
	set_volatile(n_volatile);
	set_ref(n_ref);
	set_removeonvalue(n_removeonvalue);
}
XplPointerinfo::XplPointerinfo(string n_memberof, bool n_const, bool n_volatile, bool n_ref, bool n_removeonvalue){
	set_memberof(n_memberof);
	set_const(n_const);
	set_volatile(n_volatile);
	set_ref(n_ref);
	set_removeonvalue(n_removeonvalue);
}
//Destructor
XplPointerinfo::~XplPointerinfo(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplPointerinfo'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* XplPointerinfo::Clone(){
	XplPointerinfo* copy = new XplPointerinfo();
	copy->set_memberof(this->p_memberof);
	copy->set_const(this->p_const);
	copy->set_volatile(this->p_volatile);
	copy->set_ref(this->p_ref);
	copy->set_removeonvalue(this->p_removeonvalue);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplPointerinfo::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_memberof != DT_EMPTY)
		writer->write(DT(" memberof=\"")+CODEDOM_Att_ToString(p_memberof)+DT("\""));
	if(p_const != false)
		writer->write(DT(" const=\"")+CODEDOM_Att_ToString(p_const)+DT("\""));
	if(p_volatile != false)
		writer->write(DT(" volatile=\"")+CODEDOM_Att_ToString(p_volatile)+DT("\""));
	if(p_ref != false)
		writer->write(DT(" ref=\"")+CODEDOM_Att_ToString(p_ref)+DT("\""));
	if(p_removeonvalue != false)
		writer->write(DT(" removeonvalue=\"")+CODEDOM_Att_ToString(p_removeonvalue)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplPointerinfo::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplPointerinfo::get_memberof(){
	return p_memberof;
}
bool XplPointerinfo::get_const(){
	return p_const;
}
bool XplPointerinfo::get_volatile(){
	return p_volatile;
}
bool XplPointerinfo::get_ref(){
	return p_ref;
}
bool XplPointerinfo::get_removeonvalue(){
	return p_removeonvalue;
}

//Funciones para setear Atributos
string XplPointerinfo::set_memberof(string new_memberof){
	string back_memberof = p_memberof;
	p_memberof = new_memberof;
	return back_memberof;
}
bool XplPointerinfo::set_const(bool new_const){
	bool back_const = p_const;
	p_const = new_const;
	return back_const;
}
bool XplPointerinfo::set_volatile(bool new_volatile){
	bool back_volatile = p_volatile;
	p_volatile = new_volatile;
	return back_volatile;
}
bool XplPointerinfo::set_ref(bool new_ref){
	bool back_ref = p_ref;
	p_ref = new_ref;
	return back_ref;
}
bool XplPointerinfo::set_removeonvalue(bool new_removeonvalue){
	bool back_removeonvalue = p_removeonvalue;
	p_removeonvalue = new_removeonvalue;
	return back_removeonvalue;
}

}

#endif
