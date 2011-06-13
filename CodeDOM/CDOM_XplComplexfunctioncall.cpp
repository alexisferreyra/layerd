/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOECOMPLEXFUNCTIONCALL_V1_0_CPP
#define __LAYERD_CODEDOM_ZOECOMPLEXFUNCTIONCALL_V1_0_CPP
#include "CDOM_XplComplexfunctioncall.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplComplexfunctioncall::XplComplexfunctioncall(){
	p_indexer = false;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_donotrender = false;
	p_evaluate = false;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_l=NULL;
	p_ce=NULL;
	p_fbk=NULL;
}
XplComplexfunctioncall::XplComplexfunctioncall(bool n_indexer, bool n_donotrender, bool n_evaluate, bool n_ignoreforsubprogram){
	p_indexer = false;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_donotrender = false;
	p_evaluate = false;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_indexer(n_indexer);
	set_donotrender(n_donotrender);
	set_evaluate(n_evaluate);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	p_l=NULL;
	p_ce=NULL;
	p_fbk=NULL;
}
XplComplexfunctioncall::XplComplexfunctioncall(XplExpression* n_l){
	p_indexer = false;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_donotrender = false;
	p_evaluate = false;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_l=NULL;
	p_ce=NULL;
	p_fbk=NULL;
	set_l(n_l);
}
XplComplexfunctioncall::XplComplexfunctioncall(bool n_indexer, bool n_donotrender, bool n_evaluate, bool n_ignoreforsubprogram, XplExpression* n_l){
	p_indexer = false;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_donotrender = false;
	p_evaluate = false;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_indexer(n_indexer);
	set_donotrender(n_donotrender);
	set_evaluate(n_evaluate);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	p_l=NULL;
	p_ce=NULL;
	p_fbk=NULL;
	set_l(n_l);
}
XplComplexfunctioncall::XplComplexfunctioncall(bool n_indexer, string n_targetClass, string n_targetMember, bool n_donotrender, bool n_evaluate, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_indexer(n_indexer);
	set_targetClass(n_targetClass);
	set_targetMember(n_targetMember);
	set_donotrender(n_donotrender);
	set_evaluate(n_evaluate);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_l=NULL;
	p_ce=NULL;
	p_fbk=NULL;
}
XplComplexfunctioncall::XplComplexfunctioncall(XplExpression* n_l, XplCexpression* n_ce, XplFunctionBody* n_fbk){
	p_indexer = false;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_donotrender = false;
	p_evaluate = false;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_l=NULL;
	p_ce=NULL;
	p_fbk=NULL;
	set_l(n_l);
	set_ce(n_ce);
	set_fbk(n_fbk);
}
XplComplexfunctioncall::XplComplexfunctioncall(bool n_indexer, string n_targetClass, string n_targetMember, bool n_donotrender, bool n_evaluate, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_l){
	set_indexer(n_indexer);
	set_targetClass(n_targetClass);
	set_targetMember(n_targetMember);
	set_donotrender(n_donotrender);
	set_evaluate(n_evaluate);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_indexer(n_indexer);
	set_donotrender(n_donotrender);
	set_evaluate(n_evaluate);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	p_l=NULL;
	p_ce=NULL;
	p_fbk=NULL;
}
XplComplexfunctioncall::XplComplexfunctioncall(bool n_indexer, bool n_donotrender, bool n_evaluate, bool n_ignoreforsubprogram, XplExpression* n_l, XplCexpression* n_ce, XplFunctionBody* n_fbk){
	p_indexer = false;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_donotrender = false;
	p_evaluate = false;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_indexer(n_indexer);
	set_donotrender(n_donotrender);
	set_evaluate(n_evaluate);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	p_l=NULL;
	p_ce=NULL;
	p_fbk=NULL;
	set_l(n_l);
	set_ce(n_ce);
	set_fbk(n_fbk);
}
XplComplexfunctioncall::XplComplexfunctioncall(bool n_indexer, string n_targetClass, string n_targetMember, bool n_donotrender, bool n_evaluate, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_l, XplCexpression* n_ce, XplFunctionBody* n_fbk){
	set_indexer(n_indexer);
	set_targetClass(n_targetClass);
	set_targetMember(n_targetMember);
	set_donotrender(n_donotrender);
	set_evaluate(n_evaluate);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_l=NULL;
	p_ce=NULL;
	p_fbk=NULL;
	set_l(n_l);
	set_ce(n_ce);
	set_fbk(n_fbk);
}
//Destructor
XplComplexfunctioncall::~XplComplexfunctioncall(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplComplexfunctioncall'");
#endif
	//Variables para Elementos de Secuencia
	if(p_l!=NULL)delete p_l;
	if(p_ce!=NULL)delete p_ce;
	if(p_fbk!=NULL)delete p_fbk;
}

//Funciones Sobreescritas de XplNode
XplNode* XplComplexfunctioncall::Clone(){
	XplComplexfunctioncall* copy = new XplComplexfunctioncall();
	copy->set_indexer(this->p_indexer);
	copy->set_targetClass(this->p_targetClass);
	copy->set_targetMember(this->p_targetMember);
	copy->set_donotrender(this->p_donotrender);
	copy->set_evaluate(this->p_evaluate);
	copy->set_ignoreforsubprogram(this->p_ignoreforsubprogram);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_l!=NULL)copy->set_l((XplExpression*)p_l->Clone());
	if(p_ce!=NULL)copy->set_ce((XplCexpression*)p_ce->Clone());
	if(p_fbk!=NULL)copy->set_fbk((XplFunctionBody*)p_fbk->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplComplexfunctioncall::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_indexer != false)
		writer->write(DT(" indexer=\"")+CODEDOM_Att_ToString(p_indexer)+DT("\""));
	if(p_targetClass != DT_EMPTY)
		writer->write(DT(" targetClass=\"")+CODEDOM_Att_ToString(p_targetClass)+DT("\""));
	if(p_targetMember != DT_EMPTY)
		writer->write(DT(" targetMember=\"")+CODEDOM_Att_ToString(p_targetMember)+DT("\""));
	if(p_donotrender != false)
		writer->write(DT(" donotrender=\"")+CODEDOM_Att_ToString(p_donotrender)+DT("\""));
	if(p_evaluate != false)
		writer->write(DT(" evaluate=\"")+CODEDOM_Att_ToString(p_evaluate)+DT("\""));
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
	if(p_ce!=NULL)if(!p_ce->Write(writer))result=false;
	if(p_fbk!=NULL)if(!p_fbk->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplComplexfunctioncall::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
bool XplComplexfunctioncall::get_indexer(){
	return p_indexer;
}
string XplComplexfunctioncall::get_targetClass(){
	return p_targetClass;
}
string XplComplexfunctioncall::get_targetMember(){
	return p_targetMember;
}
bool XplComplexfunctioncall::get_donotrender(){
	return p_donotrender;
}
bool XplComplexfunctioncall::get_evaluate(){
	return p_evaluate;
}
bool XplComplexfunctioncall::get_ignoreforsubprogram(){
	return p_ignoreforsubprogram;
}
string XplComplexfunctioncall::get_doc(){
	return p_doc;
}
string XplComplexfunctioncall::get_helpURL(){
	return p_helpURL;
}
string XplComplexfunctioncall::get_ldsrc(){
	return p_ldsrc;
}
bool XplComplexfunctioncall::get_iny(){
	return p_iny;
}
string XplComplexfunctioncall::get_inydata(){
	return p_inydata;
}
string XplComplexfunctioncall::get_inyby(){
	return p_inyby;
}
string XplComplexfunctioncall::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplExpression* XplComplexfunctioncall::get_l(){
	return p_l;
}
XplCexpression* XplComplexfunctioncall::get_ce(){
	return p_ce;
}
XplFunctionBody* XplComplexfunctioncall::get_fbk(){
	return p_fbk;
}

//Funciones para setear Atributos
bool XplComplexfunctioncall::set_indexer(bool new_indexer){
	bool back_indexer = p_indexer;
	p_indexer = new_indexer;
	return back_indexer;
}
string XplComplexfunctioncall::set_targetClass(string new_targetClass){
	string back_targetClass = p_targetClass;
	p_targetClass = new_targetClass;
	return back_targetClass;
}
string XplComplexfunctioncall::set_targetMember(string new_targetMember){
	string back_targetMember = p_targetMember;
	p_targetMember = new_targetMember;
	return back_targetMember;
}
bool XplComplexfunctioncall::set_donotrender(bool new_donotrender){
	bool back_donotrender = p_donotrender;
	p_donotrender = new_donotrender;
	return back_donotrender;
}
bool XplComplexfunctioncall::set_evaluate(bool new_evaluate){
	bool back_evaluate = p_evaluate;
	p_evaluate = new_evaluate;
	return back_evaluate;
}
bool XplComplexfunctioncall::set_ignoreforsubprogram(bool new_ignoreforsubprogram){
	bool back_ignoreforsubprogram = p_ignoreforsubprogram;
	p_ignoreforsubprogram = new_ignoreforsubprogram;
	return back_ignoreforsubprogram;
}
string XplComplexfunctioncall::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplComplexfunctioncall::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplComplexfunctioncall::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplComplexfunctioncall::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplComplexfunctioncall::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplComplexfunctioncall::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplComplexfunctioncall::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplExpression* XplComplexfunctioncall::set_l(XplExpression* new_l){
	XplExpression* back_l = p_l;
	p_l = new_l;
	if(p_l!=NULL){
		p_l->set_ElementName(DT("l"));
		p_l->set_Parent(this);
	}
	return back_l;
}
XplCexpression* XplComplexfunctioncall::set_ce(XplCexpression* new_ce){
	XplCexpression* back_ce = p_ce;
	p_ce = new_ce;
	if(p_ce!=NULL){
		p_ce->set_ElementName(DT("ce"));
		p_ce->set_Parent(this);
	}
	return back_ce;
}
XplFunctionBody* XplComplexfunctioncall::set_fbk(XplFunctionBody* new_fbk){
	XplFunctionBody* back_fbk = p_fbk;
	p_fbk = new_fbk;
	if(p_fbk!=NULL){
		p_fbk->set_ElementName(DT("fbk"));
		p_fbk->set_Parent(this);
	}
	return back_fbk;
}
XplExpression* XplComplexfunctioncall::new_l(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("l"));
	return node;
}
XplCexpression* XplComplexfunctioncall::new_ce(){
	XplCexpression* node = new XplCexpression();
	node->set_ElementName(DT("ce"));
	return node;
}
XplFunctionBody* XplComplexfunctioncall::new_fbk(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("fbk"));
	return node;
}

}

#endif
