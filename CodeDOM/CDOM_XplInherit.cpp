/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEINHERIT_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEINHERIT_V1_0_CPP
#include "CDOM_XplInherit.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplInherit::XplInherit(){
	p_access = ZOEACCESSTYPE_ENUM_PUBLIC;
	p_virtual = true;
	p_auto = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_type=NULL;
	p_originalType=NULL;
}
XplInherit::XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto){
	p_access = ZOEACCESSTYPE_ENUM_PUBLIC;
	p_virtual = true;
	p_auto = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_access(n_access);
	set_virtual(n_virtual);
	set_auto(n_auto);
	p_type=NULL;
	p_originalType=NULL;
}
XplInherit::XplInherit(XplType* n_type){
	p_access = ZOEACCESSTYPE_ENUM_PUBLIC;
	p_virtual = true;
	p_auto = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_type=NULL;
	p_originalType=NULL;
	set_type(n_type);
}
XplInherit::XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, XplType* n_type){
	p_access = ZOEACCESSTYPE_ENUM_PUBLIC;
	p_virtual = true;
	p_auto = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_access(n_access);
	set_virtual(n_virtual);
	set_auto(n_auto);
	p_type=NULL;
	p_originalType=NULL;
	set_type(n_type);
}
XplInherit::XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_access(n_access);
	set_virtual(n_virtual);
	set_auto(n_auto);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_type=NULL;
	p_originalType=NULL;
}
XplInherit::XplInherit(XplType* n_type, XplType* n_originalType){
	p_access = ZOEACCESSTYPE_ENUM_PUBLIC;
	p_virtual = true;
	p_auto = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_type=NULL;
	p_originalType=NULL;
	set_type(n_type);
	set_originalType(n_originalType);
}
XplInherit::XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type){
	set_access(n_access);
	set_virtual(n_virtual);
	set_auto(n_auto);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_access(n_access);
	set_virtual(n_virtual);
	set_auto(n_auto);
	p_type=NULL;
	p_originalType=NULL;
}
XplInherit::XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, XplType* n_type, XplType* n_originalType){
	p_access = ZOEACCESSTYPE_ENUM_PUBLIC;
	p_virtual = true;
	p_auto = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_access(n_access);
	set_virtual(n_virtual);
	set_auto(n_auto);
	p_type=NULL;
	p_originalType=NULL;
	set_type(n_type);
	set_originalType(n_originalType);
}
XplInherit::XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type, XplType* n_originalType){
	set_access(n_access);
	set_virtual(n_virtual);
	set_auto(n_auto);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_type=NULL;
	p_originalType=NULL;
	set_type(n_type);
	set_originalType(n_originalType);
}
//Destructor
XplInherit::~XplInherit(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplInherit'");
#endif
	//Variables para Elementos de Secuencia
	if(p_type!=NULL)delete p_type;
	if(p_originalType!=NULL)delete p_originalType;
}

//Funciones Sobreescritas de XplNode
XplNode* XplInherit::Clone(){
	XplInherit* copy = new XplInherit();
	copy->set_access(this->p_access);
	copy->set_virtual(this->p_virtual);
	copy->set_auto(this->p_auto);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_type!=NULL)copy->set_type((XplType*)p_type->Clone());
	if(p_originalType!=NULL)copy->set_originalType((XplType*)p_originalType->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplInherit::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_access != ZOEACCESSTYPE_ENUM_PUBLIC)
		writer->write(DT(" access=\"")+(string)__CODEDOM_ZOEACCESSTYPE_ENUM[p_access]+DT("\""));
	if(p_virtual != true)
		writer->write(DT(" virtual=\"")+CODEDOM_Att_ToString(p_virtual)+DT("\""));
	if(p_auto != false)
		writer->write(DT(" auto=\"")+CODEDOM_Att_ToString(p_auto)+DT("\""));
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
	if(p_originalType!=NULL)if(!p_originalType->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplInherit::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
XplAccesstype_enum XplInherit::get_access(){
	return p_access;
}
bool XplInherit::get_virtual(){
	return p_virtual;
}
bool XplInherit::get_auto(){
	return p_auto;
}
string XplInherit::get_doc(){
	return p_doc;
}
string XplInherit::get_helpURL(){
	return p_helpURL;
}
string XplInherit::get_ldsrc(){
	return p_ldsrc;
}
bool XplInherit::get_iny(){
	return p_iny;
}
string XplInherit::get_inydata(){
	return p_inydata;
}
string XplInherit::get_inyby(){
	return p_inyby;
}
string XplInherit::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplType* XplInherit::get_type(){
	return p_type;
}
XplType* XplInherit::get_originalType(){
	return p_originalType;
}

//Funciones para setear Atributos
XplAccesstype_enum XplInherit::set_access(XplAccesstype_enum new_access){
	XplAccesstype_enum back_access = p_access;
	p_access = new_access;
	return back_access;
}
bool XplInherit::set_virtual(bool new_virtual){
	bool back_virtual = p_virtual;
	p_virtual = new_virtual;
	return back_virtual;
}
bool XplInherit::set_auto(bool new_auto){
	bool back_auto = p_auto;
	p_auto = new_auto;
	return back_auto;
}
string XplInherit::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplInherit::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplInherit::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplInherit::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplInherit::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplInherit::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplInherit::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplType* XplInherit::set_type(XplType* new_type){
	XplType* back_type = p_type;
	p_type = new_type;
	if(p_type!=NULL){
		p_type->set_ElementName(DT("type"));
		p_type->set_Parent(this);
	}
	return back_type;
}
XplType* XplInherit::set_originalType(XplType* new_originalType){
	XplType* back_originalType = p_originalType;
	p_originalType = new_originalType;
	if(p_originalType!=NULL){
		p_originalType->set_ElementName(DT("originalType"));
		p_originalType->set_Parent(this);
	}
	return back_originalType;
}
XplType* XplInherit::new_type(){
	XplType* node = new XplType();
	node->set_ElementName(DT("type"));
	return node;
}
XplType* XplInherit::new_originalType(){
	XplType* node = new XplType();
	node->set_ElementName(DT("originalType"));
	return node;
}

}

#endif
