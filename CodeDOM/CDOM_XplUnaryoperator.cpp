/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEUNARYOPERATOR_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEUNARYOPERATOR_V1_0_CPP
#include "CDOM_XplUnaryoperator.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplUnaryoperator::XplUnaryoperator(){
	p_op = (XplUnaryoperators_enum)0;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_u=NULL;
}
XplUnaryoperator::XplUnaryoperator(XplUnaryoperators_enum n_op, bool n_ignoreforsubprogram){
	p_op = (XplUnaryoperators_enum)0;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
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
	p_u=NULL;
}
XplUnaryoperator::XplUnaryoperator(XplExpression* n_u){
	p_op = (XplUnaryoperators_enum)0;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_u=NULL;
	set_u(n_u);
}
XplUnaryoperator::XplUnaryoperator(XplUnaryoperators_enum n_op, bool n_ignoreforsubprogram, XplExpression* n_u){
	p_op = (XplUnaryoperators_enum)0;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
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
	p_u=NULL;
	set_u(n_u);
}
XplUnaryoperator::XplUnaryoperator(XplUnaryoperators_enum n_op, string n_targetClass, string n_targetMember, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_op(n_op);
	set_targetClass(n_targetClass);
	set_targetMember(n_targetMember);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_u=NULL;
}
XplUnaryoperator::XplUnaryoperator(XplUnaryoperators_enum n_op, string n_targetClass, string n_targetMember, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_u){
	set_op(n_op);
	set_targetClass(n_targetClass);
	set_targetMember(n_targetMember);
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
	p_u=NULL;
}
//Destructor
XplUnaryoperator::~XplUnaryoperator(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplUnaryoperator'");
#endif
	//Variables para Elementos de Secuencia
	if(p_u!=NULL)delete p_u;
}

//Funciones Sobreescritas de XplNode
XplNode* XplUnaryoperator::Clone(){
	XplUnaryoperator* copy = new XplUnaryoperator();
	copy->set_op(this->p_op);
	copy->set_targetClass(this->p_targetClass);
	copy->set_targetMember(this->p_targetMember);
	copy->set_ignoreforsubprogram(this->p_ignoreforsubprogram);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_u!=NULL)copy->set_u((XplExpression*)p_u->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplUnaryoperator::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_op != (XplUnaryoperators_enum)0)
		writer->write(DT(" op=\"")+(string)__CODEDOM_ZOEUNARYOPERATORS_ENUM[p_op]+DT("\""));
	if(p_targetClass != DT_EMPTY)
		writer->write(DT(" targetClass=\"")+CODEDOM_Att_ToString(p_targetClass)+DT("\""));
	if(p_targetMember != DT_EMPTY)
		writer->write(DT(" targetMember=\"")+CODEDOM_Att_ToString(p_targetMember)+DT("\""));
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
	if(p_u!=NULL)if(!p_u->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplUnaryoperator::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
XplUnaryoperators_enum XplUnaryoperator::get_op(){
	return p_op;
}
string XplUnaryoperator::get_targetClass(){
	return p_targetClass;
}
string XplUnaryoperator::get_targetMember(){
	return p_targetMember;
}
bool XplUnaryoperator::get_ignoreforsubprogram(){
	return p_ignoreforsubprogram;
}
string XplUnaryoperator::get_doc(){
	return p_doc;
}
string XplUnaryoperator::get_helpURL(){
	return p_helpURL;
}
string XplUnaryoperator::get_ldsrc(){
	return p_ldsrc;
}
bool XplUnaryoperator::get_iny(){
	return p_iny;
}
string XplUnaryoperator::get_inydata(){
	return p_inydata;
}
string XplUnaryoperator::get_inyby(){
	return p_inyby;
}
string XplUnaryoperator::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplExpression* XplUnaryoperator::get_u(){
	return p_u;
}

//Funciones para setear Atributos
XplUnaryoperators_enum XplUnaryoperator::set_op(XplUnaryoperators_enum new_op){
	XplUnaryoperators_enum back_op = p_op;
	p_op = new_op;
	return back_op;
}
string XplUnaryoperator::set_targetClass(string new_targetClass){
	string back_targetClass = p_targetClass;
	p_targetClass = new_targetClass;
	return back_targetClass;
}
string XplUnaryoperator::set_targetMember(string new_targetMember){
	string back_targetMember = p_targetMember;
	p_targetMember = new_targetMember;
	return back_targetMember;
}
bool XplUnaryoperator::set_ignoreforsubprogram(bool new_ignoreforsubprogram){
	bool back_ignoreforsubprogram = p_ignoreforsubprogram;
	p_ignoreforsubprogram = new_ignoreforsubprogram;
	return back_ignoreforsubprogram;
}
string XplUnaryoperator::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplUnaryoperator::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplUnaryoperator::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplUnaryoperator::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplUnaryoperator::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplUnaryoperator::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplUnaryoperator::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplExpression* XplUnaryoperator::set_u(XplExpression* new_u){
	XplExpression* back_u = p_u;
	p_u = new_u;
	if(p_u!=NULL){
		p_u->set_ElementName(DT("u"));
		p_u->set_Parent(this);
	}
	return back_u;
}
XplExpression* XplUnaryoperator::new_u(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("u"));
	return node;
}

}

#endif
