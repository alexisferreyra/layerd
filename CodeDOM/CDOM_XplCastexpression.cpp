/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOECASTEXPRESSION_V1_0_CPP
#define __LAYERD_CODEDOM_ZOECASTEXPRESSION_V1_0_CPP
#include "CDOM_XplCastexpression.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplCastexpression::XplCastexpression(){
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_castType = ZOECASTTYPE_ENUM_STATIC;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_e=NULL;
	p_type=NULL;
}
XplCastexpression::XplCastexpression(XplCasttype_enum n_castType, bool n_ignoreforsubprogram){
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_castType = ZOECASTTYPE_ENUM_STATIC;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_castType(n_castType);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	p_e=NULL;
	p_type=NULL;
}
XplCastexpression::XplCastexpression(XplExpression* n_e, XplType* n_type){
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_castType = ZOECASTTYPE_ENUM_STATIC;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_e=NULL;
	p_type=NULL;
	set_e(n_e);
	set_type(n_type);
}
XplCastexpression::XplCastexpression(XplCasttype_enum n_castType, bool n_ignoreforsubprogram, XplExpression* n_e, XplType* n_type){
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_castType = ZOECASTTYPE_ENUM_STATIC;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_castType(n_castType);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	p_e=NULL;
	p_type=NULL;
	set_e(n_e);
	set_type(n_type);
}
XplCastexpression::XplCastexpression(string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, XplCasttype_enum n_castType, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_targetClass(n_targetClass);
	set_targetMember(n_targetMember);
	set_targetClassExternalName(n_targetClassExternalName);
	set_targetMemberExternalName(n_targetMemberExternalName);
	set_castType(n_castType);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_e=NULL;
	p_type=NULL;
}
XplCastexpression::XplCastexpression(string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, XplCasttype_enum n_castType, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_e, XplType* n_type){
	set_targetClass(n_targetClass);
	set_targetMember(n_targetMember);
	set_targetClassExternalName(n_targetClassExternalName);
	set_targetMemberExternalName(n_targetMemberExternalName);
	set_castType(n_castType);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_castType(n_castType);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	p_e=NULL;
	p_type=NULL;
}
//Destructor
XplCastexpression::~XplCastexpression(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplCastexpression'");
#endif
	//Variables para Elementos de Secuencia
	if(p_e!=NULL)delete p_e;
	if(p_type!=NULL)delete p_type;
}

//Funciones Sobreescritas de XplNode
XplNode* XplCastexpression::Clone(){
	XplCastexpression* copy = new XplCastexpression();
	copy->set_targetClass(this->p_targetClass);
	copy->set_targetMember(this->p_targetMember);
	copy->set_targetClassExternalName(this->p_targetClassExternalName);
	copy->set_targetMemberExternalName(this->p_targetMemberExternalName);
	copy->set_castType(this->p_castType);
	copy->set_ignoreforsubprogram(this->p_ignoreforsubprogram);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_e!=NULL)copy->set_e((XplExpression*)p_e->Clone());
	if(p_type!=NULL)copy->set_type((XplType*)p_type->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplCastexpression::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_targetClass != DT_EMPTY)
		writer->write(DT(" targetClass=\"")+CODEDOM_Att_ToString(p_targetClass)+DT("\""));
	if(p_targetMember != DT_EMPTY)
		writer->write(DT(" targetMember=\"")+CODEDOM_Att_ToString(p_targetMember)+DT("\""));
	if(p_targetClassExternalName != DT_EMPTY)
		writer->write(DT(" targetClassExternalName=\"")+CODEDOM_Att_ToString(p_targetClassExternalName)+DT("\""));
	if(p_targetMemberExternalName != DT_EMPTY)
		writer->write(DT(" targetMemberExternalName=\"")+CODEDOM_Att_ToString(p_targetMemberExternalName)+DT("\""));
	if(p_castType != ZOECASTTYPE_ENUM_STATIC)
		writer->write(DT(" castType=\"")+(string)__CODEDOM_ZOECASTTYPE_ENUM[p_castType]+DT("\""));
	if(p_ignoreforsubprogram != false)
		writer->write(DT(" ignoreforsubprogram=\"")+CODEDOM_Att_ToString(p_ignoreforsubprogram)+DT("\""));
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
	if(p_e!=NULL)if(!p_e->Write(writer))result=false;
	if(p_type!=NULL)if(!p_type->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplCastexpression::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplCastexpression::get_targetClass(){
	return p_targetClass;
}
string XplCastexpression::get_targetMember(){
	return p_targetMember;
}
string XplCastexpression::get_targetClassExternalName(){
	return p_targetClassExternalName;
}
string XplCastexpression::get_targetMemberExternalName(){
	return p_targetMemberExternalName;
}
XplCasttype_enum XplCastexpression::get_castType(){
	return p_castType;
}
bool XplCastexpression::get_ignoreforsubprogram(){
	return p_ignoreforsubprogram;
}
string XplCastexpression::get_doc(){
	return p_doc;
}
string XplCastexpression::get_helpURL(){
	return p_helpURL;
}
string XplCastexpression::get_ldsrc(){
	return p_ldsrc;
}
bool XplCastexpression::get_iny(){
	return p_iny;
}
string XplCastexpression::get_inydata(){
	return p_inydata;
}
string XplCastexpression::get_inyby(){
	return p_inyby;
}
string XplCastexpression::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplExpression* XplCastexpression::get_e(){
	return p_e;
}
XplType* XplCastexpression::get_type(){
	return p_type;
}

//Funciones para setear Atributos
string XplCastexpression::set_targetClass(string new_targetClass){
	string back_targetClass = p_targetClass;
	p_targetClass = new_targetClass;
	return back_targetClass;
}
string XplCastexpression::set_targetMember(string new_targetMember){
	string back_targetMember = p_targetMember;
	p_targetMember = new_targetMember;
	return back_targetMember;
}
string XplCastexpression::set_targetClassExternalName(string new_targetClassExternalName){
	string back_targetClassExternalName = p_targetClassExternalName;
	p_targetClassExternalName = new_targetClassExternalName;
	return back_targetClassExternalName;
}
string XplCastexpression::set_targetMemberExternalName(string new_targetMemberExternalName){
	string back_targetMemberExternalName = p_targetMemberExternalName;
	p_targetMemberExternalName = new_targetMemberExternalName;
	return back_targetMemberExternalName;
}
XplCasttype_enum XplCastexpression::set_castType(XplCasttype_enum new_castType){
	XplCasttype_enum back_castType = p_castType;
	p_castType = new_castType;
	return back_castType;
}
bool XplCastexpression::set_ignoreforsubprogram(bool new_ignoreforsubprogram){
	bool back_ignoreforsubprogram = p_ignoreforsubprogram;
	p_ignoreforsubprogram = new_ignoreforsubprogram;
	return back_ignoreforsubprogram;
}
string XplCastexpression::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplCastexpression::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplCastexpression::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplCastexpression::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplCastexpression::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplCastexpression::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplCastexpression::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplExpression* XplCastexpression::set_e(XplExpression* new_e){
	XplExpression* back_e = p_e;
	p_e = new_e;
	if(p_e!=NULL){
		p_e->set_ElementName(DT("e"));
		p_e->set_Parent(this);
	}
	return back_e;
}
XplType* XplCastexpression::set_type(XplType* new_type){
	XplType* back_type = p_type;
	p_type = new_type;
	if(p_type!=NULL){
		p_type->set_ElementName(DT("type"));
		p_type->set_Parent(this);
	}
	return back_type;
}
XplExpression* XplCastexpression::new_e(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("e"));
	return node;
}
XplType* XplCastexpression::new_type(){
	XplType* node = new XplType();
	node->set_ElementName(DT("type"));
	return node;
}

}

#endif
