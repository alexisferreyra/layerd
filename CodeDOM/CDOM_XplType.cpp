/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOETYPE_V1_0_CPP
#define __LAYERD_CODEDOM_ZOETYPE_V1_0_CPP
#include "CDOM_XplType.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplType::XplType(){
	p_typename = DT_EMPTY;
	p_ispointer = false;
	p_isarray = false;
	p_pointertype = ZOEPOINTERTYPE_ENUM_DEFAULT;
	p_ftype = ZOEFACTORYTYPE_ENUM_NONE;
	p_volatile = false;
	p_const = false;
	p_exec = false;
	p_typeStr = DT_EMPTY;
	p_replaceParent = false;
	p_customTypeCheck = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_dt=NULL;
	p_ae=NULL;
	p_pi=NULL;
	p_fc=NULL;
}
XplType::XplType(bool n_ispointer, bool n_isarray, XplPointertype_enum n_pointertype, XplFactorytype_enum n_ftype, bool n_volatile, bool n_const, bool n_exec, bool n_replaceParent, bool n_customTypeCheck){
	p_typename = DT_EMPTY;
	p_ispointer = false;
	p_isarray = false;
	p_pointertype = ZOEPOINTERTYPE_ENUM_DEFAULT;
	p_ftype = ZOEFACTORYTYPE_ENUM_NONE;
	p_volatile = false;
	p_const = false;
	p_exec = false;
	p_typeStr = DT_EMPTY;
	p_replaceParent = false;
	p_customTypeCheck = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_ispointer(n_ispointer);
	set_isarray(n_isarray);
	set_pointertype(n_pointertype);
	set_ftype(n_ftype);
	set_volatile(n_volatile);
	set_const(n_const);
	set_exec(n_exec);
	set_replaceParent(n_replaceParent);
	set_customTypeCheck(n_customTypeCheck);
	p_dt=NULL;
	p_ae=NULL;
	p_pi=NULL;
	p_fc=NULL;
}
XplType::XplType(string n_typename, bool n_ispointer, bool n_isarray, XplPointertype_enum n_pointertype, XplFactorytype_enum n_ftype, bool n_volatile, bool n_const, bool n_exec, string n_typeStr, bool n_replaceParent, bool n_customTypeCheck, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_typename(n_typename);
	set_ispointer(n_ispointer);
	set_isarray(n_isarray);
	set_pointertype(n_pointertype);
	set_ftype(n_ftype);
	set_volatile(n_volatile);
	set_const(n_const);
	set_exec(n_exec);
	set_typeStr(n_typeStr);
	set_replaceParent(n_replaceParent);
	set_customTypeCheck(n_customTypeCheck);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_dt=NULL;
	p_ae=NULL;
	p_pi=NULL;
	p_fc=NULL;
}
XplType::XplType(XplType* n_dt, XplExpression* n_ae, XplPointerinfo* n_pi, XplFunctioncall* n_fc){
	p_typename = DT_EMPTY;
	p_ispointer = false;
	p_isarray = false;
	p_pointertype = ZOEPOINTERTYPE_ENUM_DEFAULT;
	p_ftype = ZOEFACTORYTYPE_ENUM_NONE;
	p_volatile = false;
	p_const = false;
	p_exec = false;
	p_typeStr = DT_EMPTY;
	p_replaceParent = false;
	p_customTypeCheck = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_dt=NULL;
	p_ae=NULL;
	p_pi=NULL;
	p_fc=NULL;
	set_dt(n_dt);
	set_ae(n_ae);
	set_pi(n_pi);
	set_fc(n_fc);
}
XplType::XplType(bool n_ispointer, bool n_isarray, XplPointertype_enum n_pointertype, XplFactorytype_enum n_ftype, bool n_volatile, bool n_const, bool n_exec, bool n_replaceParent, bool n_customTypeCheck, XplType* n_dt, XplExpression* n_ae, XplPointerinfo* n_pi, XplFunctioncall* n_fc){
	p_typename = DT_EMPTY;
	p_ispointer = false;
	p_isarray = false;
	p_pointertype = ZOEPOINTERTYPE_ENUM_DEFAULT;
	p_ftype = ZOEFACTORYTYPE_ENUM_NONE;
	p_volatile = false;
	p_const = false;
	p_exec = false;
	p_typeStr = DT_EMPTY;
	p_replaceParent = false;
	p_customTypeCheck = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_ispointer(n_ispointer);
	set_isarray(n_isarray);
	set_pointertype(n_pointertype);
	set_ftype(n_ftype);
	set_volatile(n_volatile);
	set_const(n_const);
	set_exec(n_exec);
	set_replaceParent(n_replaceParent);
	set_customTypeCheck(n_customTypeCheck);
	p_dt=NULL;
	p_ae=NULL;
	p_pi=NULL;
	p_fc=NULL;
	set_dt(n_dt);
	set_ae(n_ae);
	set_pi(n_pi);
	set_fc(n_fc);
}
XplType::XplType(string n_typename, bool n_ispointer, bool n_isarray, XplPointertype_enum n_pointertype, XplFactorytype_enum n_ftype, bool n_volatile, bool n_const, bool n_exec, string n_typeStr, bool n_replaceParent, bool n_customTypeCheck, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_dt, XplExpression* n_ae, XplPointerinfo* n_pi, XplFunctioncall* n_fc){
	set_typename(n_typename);
	set_ispointer(n_ispointer);
	set_isarray(n_isarray);
	set_pointertype(n_pointertype);
	set_ftype(n_ftype);
	set_volatile(n_volatile);
	set_const(n_const);
	set_exec(n_exec);
	set_typeStr(n_typeStr);
	set_replaceParent(n_replaceParent);
	set_customTypeCheck(n_customTypeCheck);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_dt=NULL;
	p_ae=NULL;
	p_pi=NULL;
	p_fc=NULL;
	set_dt(n_dt);
	set_ae(n_ae);
	set_pi(n_pi);
	set_fc(n_fc);
}
//Destructor
XplType::~XplType(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplType'");
#endif
	//Variables para Elementos de Secuencia
	if(p_dt!=NULL)delete p_dt;
	if(p_ae!=NULL)delete p_ae;
	if(p_pi!=NULL)delete p_pi;
	if(p_fc!=NULL)delete p_fc;
}

//Funciones Sobreescritas de XplNode
XplNode* XplType::Clone(){
	XplType* copy = new XplType();
	copy->set_typename(this->p_typename);
	copy->set_ispointer(this->p_ispointer);
	copy->set_isarray(this->p_isarray);
	copy->set_pointertype(this->p_pointertype);
	copy->set_ftype(this->p_ftype);
	copy->set_volatile(this->p_volatile);
	copy->set_const(this->p_const);
	copy->set_exec(this->p_exec);
	copy->set_typeStr(this->p_typeStr);
	copy->set_replaceParent(this->p_replaceParent);
	copy->set_customTypeCheck(this->p_customTypeCheck);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_dt!=NULL)copy->set_dt((XplType*)p_dt->Clone());
	if(p_ae!=NULL)copy->set_ae((XplExpression*)p_ae->Clone());
	if(p_pi!=NULL)copy->set_pi((XplPointerinfo*)p_pi->Clone());
	if(p_fc!=NULL)copy->set_fc((XplFunctioncall*)p_fc->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplType::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_typename != DT_EMPTY)
		writer->write(DT(" typename=\"")+CODEDOM_Att_ToString(p_typename)+DT("\""));
	if(p_ispointer != false)
		writer->write(DT(" ispointer=\"")+CODEDOM_Att_ToString(p_ispointer)+DT("\""));
	if(p_isarray != false)
		writer->write(DT(" isarray=\"")+CODEDOM_Att_ToString(p_isarray)+DT("\""));
	if(p_pointertype != ZOEPOINTERTYPE_ENUM_DEFAULT)
		writer->write(DT(" pointertype=\"")+(string)__CODEDOM_ZOEPOINTERTYPE_ENUM[p_pointertype]+DT("\""));
	if(p_ftype != ZOEFACTORYTYPE_ENUM_NONE)
		writer->write(DT(" ftype=\"")+(string)__CODEDOM_ZOEFACTORYTYPE_ENUM[p_ftype]+DT("\""));
	if(p_volatile != false)
		writer->write(DT(" volatile=\"")+CODEDOM_Att_ToString(p_volatile)+DT("\""));
	if(p_const != false)
		writer->write(DT(" const=\"")+CODEDOM_Att_ToString(p_const)+DT("\""));
	if(p_exec != false)
		writer->write(DT(" exec=\"")+CODEDOM_Att_ToString(p_exec)+DT("\""));
	if(p_typeStr != DT_EMPTY)
		writer->write(DT(" typeStr=\"")+CODEDOM_Att_ToString(p_typeStr)+DT("\""));
	if(p_replaceParent != false)
		writer->write(DT(" replaceParent=\"")+CODEDOM_Att_ToString(p_replaceParent)+DT("\""));
	if(p_customTypeCheck != false)
		writer->write(DT(" customTypeCheck=\"")+CODEDOM_Att_ToString(p_customTypeCheck)+DT("\""));
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
	if(p_dt!=NULL)if(!p_dt->Write(writer))result=false;
	if(p_ae!=NULL)if(!p_ae->Write(writer))result=false;
	if(p_pi!=NULL)if(!p_pi->Write(writer))result=false;
	if(p_fc!=NULL)if(!p_fc->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplType::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplType::get_typename(){
	return p_typename;
}
bool XplType::get_ispointer(){
	return p_ispointer;
}
bool XplType::get_isarray(){
	return p_isarray;
}
XplPointertype_enum XplType::get_pointertype(){
	return p_pointertype;
}
XplFactorytype_enum XplType::get_ftype(){
	return p_ftype;
}
bool XplType::get_volatile(){
	return p_volatile;
}
bool XplType::get_const(){
	return p_const;
}
bool XplType::get_exec(){
	return p_exec;
}
string XplType::get_typeStr(){
	return p_typeStr;
}
bool XplType::get_replaceParent(){
	return p_replaceParent;
}
bool XplType::get_customTypeCheck(){
	return p_customTypeCheck;
}
string XplType::get_doc(){
	return p_doc;
}
string XplType::get_helpURL(){
	return p_helpURL;
}
string XplType::get_ldsrc(){
	return p_ldsrc;
}
bool XplType::get_iny(){
	return p_iny;
}
string XplType::get_inydata(){
	return p_inydata;
}
string XplType::get_inyby(){
	return p_inyby;
}
string XplType::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplType* XplType::get_dt(){
	return p_dt;
}
XplExpression* XplType::get_ae(){
	return p_ae;
}
XplPointerinfo* XplType::get_pi(){
	return p_pi;
}
XplFunctioncall* XplType::get_fc(){
	return p_fc;
}

//Funciones para setear Atributos
string XplType::set_typename(string new_typename){
	string back_typename = p_typename;
	p_typename = new_typename;
	return back_typename;
}
bool XplType::set_ispointer(bool new_ispointer){
	bool back_ispointer = p_ispointer;
	p_ispointer = new_ispointer;
	return back_ispointer;
}
bool XplType::set_isarray(bool new_isarray){
	bool back_isarray = p_isarray;
	p_isarray = new_isarray;
	return back_isarray;
}
XplPointertype_enum XplType::set_pointertype(XplPointertype_enum new_pointertype){
	XplPointertype_enum back_pointertype = p_pointertype;
	p_pointertype = new_pointertype;
	return back_pointertype;
}
XplFactorytype_enum XplType::set_ftype(XplFactorytype_enum new_ftype){
	XplFactorytype_enum back_ftype = p_ftype;
	p_ftype = new_ftype;
	return back_ftype;
}
bool XplType::set_volatile(bool new_volatile){
	bool back_volatile = p_volatile;
	p_volatile = new_volatile;
	return back_volatile;
}
bool XplType::set_const(bool new_const){
	bool back_const = p_const;
	p_const = new_const;
	return back_const;
}
bool XplType::set_exec(bool new_exec){
	bool back_exec = p_exec;
	p_exec = new_exec;
	return back_exec;
}
string XplType::set_typeStr(string new_typeStr){
	string back_typeStr = p_typeStr;
	p_typeStr = new_typeStr;
	return back_typeStr;
}
bool XplType::set_replaceParent(bool new_replaceParent){
	bool back_replaceParent = p_replaceParent;
	p_replaceParent = new_replaceParent;
	return back_replaceParent;
}
bool XplType::set_customTypeCheck(bool new_customTypeCheck){
	bool back_customTypeCheck = p_customTypeCheck;
	p_customTypeCheck = new_customTypeCheck;
	return back_customTypeCheck;
}
string XplType::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplType::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplType::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplType::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplType::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplType::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplType::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplType* XplType::set_dt(XplType* new_dt){
	XplType* back_dt = p_dt;
	p_dt = new_dt;
	if(p_dt!=NULL){
		p_dt->set_ElementName(DT("dt"));
		p_dt->set_Parent(this);
	}
	return back_dt;
}
XplExpression* XplType::set_ae(XplExpression* new_ae){
	XplExpression* back_ae = p_ae;
	p_ae = new_ae;
	if(p_ae!=NULL){
		p_ae->set_ElementName(DT("ae"));
		p_ae->set_Parent(this);
	}
	return back_ae;
}
XplPointerinfo* XplType::set_pi(XplPointerinfo* new_pi){
	XplPointerinfo* back_pi = p_pi;
	p_pi = new_pi;
	if(p_pi!=NULL){
		p_pi->set_ElementName(DT("pi"));
		p_pi->set_Parent(this);
	}
	return back_pi;
}
XplFunctioncall* XplType::set_fc(XplFunctioncall* new_fc){
	XplFunctioncall* back_fc = p_fc;
	p_fc = new_fc;
	if(p_fc!=NULL){
		p_fc->set_ElementName(DT("fc"));
		p_fc->set_Parent(this);
	}
	return back_fc;
}
XplType* XplType::new_dt(){
	XplType* node = new XplType();
	node->set_ElementName(DT("dt"));
	return node;
}
XplExpression* XplType::new_ae(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("ae"));
	return node;
}
XplPointerinfo* XplType::new_pi(){
	XplPointerinfo* node = new XplPointerinfo();
	node->set_ElementName(DT("pi"));
	return node;
}
XplFunctioncall* XplType::new_fc(){
	XplFunctioncall* node = new XplFunctioncall();
	node->set_ElementName(DT("fc"));
	return node;
}

}

#endif
