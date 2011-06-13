/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEBINARYOPERATOR_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEBINARYOPERATOR_V1_0_CPP
#include "CDOM_XplBinaryoperator.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplBinaryoperator::XplBinaryoperator(){
	p_op = (XplBinaryoperators_enum)0;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_l=NULL;
	p_r=NULL;
}
XplBinaryoperator::XplBinaryoperator(XplBinaryoperators_enum n_op, bool n_ignoreforsubprogram){
	p_op = (XplBinaryoperators_enum)0;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_op(n_op);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	p_l=NULL;
	p_r=NULL;
}
XplBinaryoperator::XplBinaryoperator(XplExpression* n_l, XplExpression* n_r){
	p_op = (XplBinaryoperators_enum)0;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_l=NULL;
	p_r=NULL;
	set_l(n_l);
	set_r(n_r);
}
XplBinaryoperator::XplBinaryoperator(XplBinaryoperators_enum n_op, bool n_ignoreforsubprogram, XplExpression* n_l, XplExpression* n_r){
	p_op = (XplBinaryoperators_enum)0;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_op(n_op);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	p_l=NULL;
	p_r=NULL;
	set_l(n_l);
	set_r(n_r);
}
XplBinaryoperator::XplBinaryoperator(XplBinaryoperators_enum n_op, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_op(n_op);
	set_targetClass(n_targetClass);
	set_targetMember(n_targetMember);
	set_targetClassExternalName(n_targetClassExternalName);
	set_targetMemberExternalName(n_targetMemberExternalName);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_l=NULL;
	p_r=NULL;
}
XplBinaryoperator::XplBinaryoperator(XplBinaryoperators_enum n_op, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_l, XplExpression* n_r){
	set_op(n_op);
	set_targetClass(n_targetClass);
	set_targetMember(n_targetMember);
	set_targetClassExternalName(n_targetClassExternalName);
	set_targetMemberExternalName(n_targetMemberExternalName);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_op(n_op);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	p_l=NULL;
	p_r=NULL;
}
//Destructor
XplBinaryoperator::~XplBinaryoperator(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplBinaryoperator'");
#endif
	//Variables para Elementos de Secuencia
	if(p_l!=NULL)delete p_l;
	if(p_r!=NULL)delete p_r;
}

//Funciones Sobreescritas de XplNode
XplNode* XplBinaryoperator::Clone(){
	XplBinaryoperator* copy = new XplBinaryoperator();
	copy->set_op(this->p_op);
	copy->set_targetClass(this->p_targetClass);
	copy->set_targetMember(this->p_targetMember);
	copy->set_targetClassExternalName(this->p_targetClassExternalName);
	copy->set_targetMemberExternalName(this->p_targetMemberExternalName);
	copy->set_ignoreforsubprogram(this->p_ignoreforsubprogram);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_l!=NULL)copy->set_l((XplExpression*)p_l->Clone());
	if(p_r!=NULL)copy->set_r((XplExpression*)p_r->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplBinaryoperator::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_op != (XplBinaryoperators_enum)0)
		writer->write(DT(" op=\"")+(string)__CODEDOM_ZOEBINARYOPERATORS_ENUM[p_op]+DT("\""));
	if(p_targetClass != DT_EMPTY)
		writer->write(DT(" targetClass=\"")+CODEDOM_Att_ToString(p_targetClass)+DT("\""));
	if(p_targetMember != DT_EMPTY)
		writer->write(DT(" targetMember=\"")+CODEDOM_Att_ToString(p_targetMember)+DT("\""));
	if(p_targetClassExternalName != DT_EMPTY)
		writer->write(DT(" targetClassExternalName=\"")+CODEDOM_Att_ToString(p_targetClassExternalName)+DT("\""));
	if(p_targetMemberExternalName != DT_EMPTY)
		writer->write(DT(" targetMemberExternalName=\"")+CODEDOM_Att_ToString(p_targetMemberExternalName)+DT("\""));
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
	if(p_l!=NULL)if(!p_l->Write(writer))result=false;
	if(p_r!=NULL)if(!p_r->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplBinaryoperator::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
XplBinaryoperators_enum XplBinaryoperator::get_op(){
	return p_op;
}
string XplBinaryoperator::get_targetClass(){
	return p_targetClass;
}
string XplBinaryoperator::get_targetMember(){
	return p_targetMember;
}
string XplBinaryoperator::get_targetClassExternalName(){
	return p_targetClassExternalName;
}
string XplBinaryoperator::get_targetMemberExternalName(){
	return p_targetMemberExternalName;
}
bool XplBinaryoperator::get_ignoreforsubprogram(){
	return p_ignoreforsubprogram;
}
string XplBinaryoperator::get_doc(){
	return p_doc;
}
string XplBinaryoperator::get_helpURL(){
	return p_helpURL;
}
string XplBinaryoperator::get_ldsrc(){
	return p_ldsrc;
}
bool XplBinaryoperator::get_iny(){
	return p_iny;
}
string XplBinaryoperator::get_inydata(){
	return p_inydata;
}
string XplBinaryoperator::get_inyby(){
	return p_inyby;
}
string XplBinaryoperator::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplExpression* XplBinaryoperator::get_l(){
	return p_l;
}
XplExpression* XplBinaryoperator::get_r(){
	return p_r;
}

//Funciones para setear Atributos
XplBinaryoperators_enum XplBinaryoperator::set_op(XplBinaryoperators_enum new_op){
	XplBinaryoperators_enum back_op = p_op;
	p_op = new_op;
	return back_op;
}
string XplBinaryoperator::set_targetClass(string new_targetClass){
	string back_targetClass = p_targetClass;
	p_targetClass = new_targetClass;
	return back_targetClass;
}
string XplBinaryoperator::set_targetMember(string new_targetMember){
	string back_targetMember = p_targetMember;
	p_targetMember = new_targetMember;
	return back_targetMember;
}
string XplBinaryoperator::set_targetClassExternalName(string new_targetClassExternalName){
	string back_targetClassExternalName = p_targetClassExternalName;
	p_targetClassExternalName = new_targetClassExternalName;
	return back_targetClassExternalName;
}
string XplBinaryoperator::set_targetMemberExternalName(string new_targetMemberExternalName){
	string back_targetMemberExternalName = p_targetMemberExternalName;
	p_targetMemberExternalName = new_targetMemberExternalName;
	return back_targetMemberExternalName;
}
bool XplBinaryoperator::set_ignoreforsubprogram(bool new_ignoreforsubprogram){
	bool back_ignoreforsubprogram = p_ignoreforsubprogram;
	p_ignoreforsubprogram = new_ignoreforsubprogram;
	return back_ignoreforsubprogram;
}
string XplBinaryoperator::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplBinaryoperator::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplBinaryoperator::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplBinaryoperator::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplBinaryoperator::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplBinaryoperator::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplBinaryoperator::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplExpression* XplBinaryoperator::set_l(XplExpression* new_l){
	XplExpression* back_l = p_l;
	p_l = new_l;
	if(p_l!=NULL){
		p_l->set_ElementName(DT("l"));
		p_l->set_Parent(this);
	}
	return back_l;
}
XplExpression* XplBinaryoperator::set_r(XplExpression* new_r){
	XplExpression* back_r = p_r;
	p_r = new_r;
	if(p_r!=NULL){
		p_r->set_ElementName(DT("r"));
		p_r->set_Parent(this);
	}
	return back_r;
}
XplExpression* XplBinaryoperator::new_l(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("l"));
	return node;
}
XplExpression* XplBinaryoperator::new_r(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("r"));
	return node;
}

}

#endif
