/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEFUNCTIONCALL_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEFUNCTIONCALL_V1_0_CPP
#include "CDOM_XplFunctioncall.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplFunctioncall::XplFunctioncall(){
	p_name = DT_EMPTY;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_ldxplcMods = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_evaluateBlock = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_l=NULL;
	p_args=NULL;
	p_bk=NULL;
}
XplFunctioncall::XplFunctioncall(bool n_ignoreforsubprogram, bool n_evaluateBlock){
	p_name = DT_EMPTY;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_ldxplcMods = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_evaluateBlock = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_evaluateBlock(n_evaluateBlock);
	p_l=NULL;
	p_args=NULL;
	p_bk=NULL;
}
XplFunctioncall::XplFunctioncall(XplExpression* n_l, XplFunctionBody* n_bk){
	p_name = DT_EMPTY;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_ldxplcMods = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_evaluateBlock = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_l=NULL;
	p_args=NULL;
	p_bk=NULL;
	set_l(n_l);
	set_bk(n_bk);
}
XplFunctioncall::XplFunctioncall(bool n_ignoreforsubprogram, bool n_evaluateBlock, XplExpression* n_l, XplFunctionBody* n_bk){
	p_name = DT_EMPTY;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_ldxplcMods = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_evaluateBlock = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_evaluateBlock(n_evaluateBlock);
	p_l=NULL;
	p_args=NULL;
	p_bk=NULL;
	set_l(n_l);
	set_bk(n_bk);
}
XplFunctioncall::XplFunctioncall(string n_name, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, string n_ldxplcMods, bool n_ignoreforsubprogram, bool n_evaluateBlock, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_name(n_name);
	set_targetClass(n_targetClass);
	set_targetMember(n_targetMember);
	set_targetClassExternalName(n_targetClassExternalName);
	set_targetMemberExternalName(n_targetMemberExternalName);
	set_ldxplcMods(n_ldxplcMods);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_evaluateBlock(n_evaluateBlock);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_l=NULL;
	p_args=NULL;
	p_bk=NULL;
}
XplFunctioncall::XplFunctioncall(XplExpression* n_l, XplExpressionlist* n_args, XplFunctionBody* n_bk){
	p_name = DT_EMPTY;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_ldxplcMods = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_evaluateBlock = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_l=NULL;
	p_args=NULL;
	p_bk=NULL;
	set_l(n_l);
	set_args(n_args);
	set_bk(n_bk);
}
XplFunctioncall::XplFunctioncall(string n_name, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, string n_ldxplcMods, bool n_ignoreforsubprogram, bool n_evaluateBlock, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_l, XplFunctionBody* n_bk){
	set_name(n_name);
	set_targetClass(n_targetClass);
	set_targetMember(n_targetMember);
	set_targetClassExternalName(n_targetClassExternalName);
	set_targetMemberExternalName(n_targetMemberExternalName);
	set_ldxplcMods(n_ldxplcMods);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_evaluateBlock(n_evaluateBlock);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_evaluateBlock(n_evaluateBlock);
	p_l=NULL;
	p_args=NULL;
	p_bk=NULL;
}
XplFunctioncall::XplFunctioncall(bool n_ignoreforsubprogram, bool n_evaluateBlock, XplExpression* n_l, XplExpressionlist* n_args, XplFunctionBody* n_bk){
	p_name = DT_EMPTY;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_ldxplcMods = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_evaluateBlock = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_evaluateBlock(n_evaluateBlock);
	p_l=NULL;
	p_args=NULL;
	p_bk=NULL;
	set_l(n_l);
	set_args(n_args);
	set_bk(n_bk);
}
XplFunctioncall::XplFunctioncall(string n_name, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, string n_ldxplcMods, bool n_ignoreforsubprogram, bool n_evaluateBlock, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_l, XplExpressionlist* n_args, XplFunctionBody* n_bk){
	set_name(n_name);
	set_targetClass(n_targetClass);
	set_targetMember(n_targetMember);
	set_targetClassExternalName(n_targetClassExternalName);
	set_targetMemberExternalName(n_targetMemberExternalName);
	set_ldxplcMods(n_ldxplcMods);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_evaluateBlock(n_evaluateBlock);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_l=NULL;
	p_args=NULL;
	p_bk=NULL;
	set_l(n_l);
	set_args(n_args);
	set_bk(n_bk);
}
//Destructor
XplFunctioncall::~XplFunctioncall(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplFunctioncall'");
#endif
	//Variables para Elementos de Secuencia
	if(p_l!=NULL)delete p_l;
	if(p_args!=NULL)delete p_args;
	if(p_bk!=NULL)delete p_bk;
}

//Funciones Sobreescritas de XplNode
XplNode* XplFunctioncall::Clone(){
	XplFunctioncall* copy = new XplFunctioncall();
	copy->set_name(this->p_name);
	copy->set_targetClass(this->p_targetClass);
	copy->set_targetMember(this->p_targetMember);
	copy->set_targetClassExternalName(this->p_targetClassExternalName);
	copy->set_targetMemberExternalName(this->p_targetMemberExternalName);
	copy->set_ldxplcMods(this->p_ldxplcMods);
	copy->set_ignoreforsubprogram(this->p_ignoreforsubprogram);
	copy->set_evaluateBlock(this->p_evaluateBlock);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_l!=NULL)copy->set_l((XplExpression*)p_l->Clone());
	if(p_args!=NULL)copy->set_args((XplExpressionlist*)p_args->Clone());
	if(p_bk!=NULL)copy->set_bk((XplFunctionBody*)p_bk->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplFunctioncall::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_name != DT_EMPTY)
		writer->write(DT(" name=\"")+CODEDOM_Att_ToString(p_name)+DT("\""));
	if(p_targetClass != DT_EMPTY)
		writer->write(DT(" targetClass=\"")+CODEDOM_Att_ToString(p_targetClass)+DT("\""));
	if(p_targetMember != DT_EMPTY)
		writer->write(DT(" targetMember=\"")+CODEDOM_Att_ToString(p_targetMember)+DT("\""));
	if(p_targetClassExternalName != DT_EMPTY)
		writer->write(DT(" targetClassExternalName=\"")+CODEDOM_Att_ToString(p_targetClassExternalName)+DT("\""));
	if(p_targetMemberExternalName != DT_EMPTY)
		writer->write(DT(" targetMemberExternalName=\"")+CODEDOM_Att_ToString(p_targetMemberExternalName)+DT("\""));
	if(p_ldxplcMods != DT_EMPTY)
		writer->write(DT(" ldxplcMods=\"")+CODEDOM_Att_ToString(p_ldxplcMods)+DT("\""));
	if(p_ignoreforsubprogram != false)
		writer->write(DT(" ignoreforsubprogram=\"")+CODEDOM_Att_ToString(p_ignoreforsubprogram)+DT("\""));
	if(p_evaluateBlock != false)
		writer->write(DT(" evaluateBlock=\"")+CODEDOM_Att_ToString(p_evaluateBlock)+DT("\""));
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
	if(p_args!=NULL)if(!p_args->Write(writer))result=false;
	if(p_bk!=NULL)if(!p_bk->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplFunctioncall::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplFunctioncall::get_name(){
	return p_name;
}
string XplFunctioncall::get_targetClass(){
	return p_targetClass;
}
string XplFunctioncall::get_targetMember(){
	return p_targetMember;
}
string XplFunctioncall::get_targetClassExternalName(){
	return p_targetClassExternalName;
}
string XplFunctioncall::get_targetMemberExternalName(){
	return p_targetMemberExternalName;
}
string XplFunctioncall::get_ldxplcMods(){
	return p_ldxplcMods;
}
bool XplFunctioncall::get_ignoreforsubprogram(){
	return p_ignoreforsubprogram;
}
bool XplFunctioncall::get_evaluateBlock(){
	return p_evaluateBlock;
}
string XplFunctioncall::get_doc(){
	return p_doc;
}
string XplFunctioncall::get_helpURL(){
	return p_helpURL;
}
string XplFunctioncall::get_ldsrc(){
	return p_ldsrc;
}
bool XplFunctioncall::get_iny(){
	return p_iny;
}
string XplFunctioncall::get_inydata(){
	return p_inydata;
}
string XplFunctioncall::get_inyby(){
	return p_inyby;
}
string XplFunctioncall::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplExpression* XplFunctioncall::get_l(){
	return p_l;
}
XplExpressionlist* XplFunctioncall::get_args(){
	return p_args;
}
XplFunctionBody* XplFunctioncall::get_bk(){
	return p_bk;
}

//Funciones para setear Atributos
string XplFunctioncall::set_name(string new_name){
	string back_name = p_name;
	p_name = new_name;
	return back_name;
}
string XplFunctioncall::set_targetClass(string new_targetClass){
	string back_targetClass = p_targetClass;
	p_targetClass = new_targetClass;
	return back_targetClass;
}
string XplFunctioncall::set_targetMember(string new_targetMember){
	string back_targetMember = p_targetMember;
	p_targetMember = new_targetMember;
	return back_targetMember;
}
string XplFunctioncall::set_targetClassExternalName(string new_targetClassExternalName){
	string back_targetClassExternalName = p_targetClassExternalName;
	p_targetClassExternalName = new_targetClassExternalName;
	return back_targetClassExternalName;
}
string XplFunctioncall::set_targetMemberExternalName(string new_targetMemberExternalName){
	string back_targetMemberExternalName = p_targetMemberExternalName;
	p_targetMemberExternalName = new_targetMemberExternalName;
	return back_targetMemberExternalName;
}
string XplFunctioncall::set_ldxplcMods(string new_ldxplcMods){
	string back_ldxplcMods = p_ldxplcMods;
	p_ldxplcMods = new_ldxplcMods;
	return back_ldxplcMods;
}
bool XplFunctioncall::set_ignoreforsubprogram(bool new_ignoreforsubprogram){
	bool back_ignoreforsubprogram = p_ignoreforsubprogram;
	p_ignoreforsubprogram = new_ignoreforsubprogram;
	return back_ignoreforsubprogram;
}
bool XplFunctioncall::set_evaluateBlock(bool new_evaluateBlock){
	bool back_evaluateBlock = p_evaluateBlock;
	p_evaluateBlock = new_evaluateBlock;
	return back_evaluateBlock;
}
string XplFunctioncall::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplFunctioncall::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplFunctioncall::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplFunctioncall::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplFunctioncall::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplFunctioncall::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplFunctioncall::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplExpression* XplFunctioncall::set_l(XplExpression* new_l){
	XplExpression* back_l = p_l;
	p_l = new_l;
	if(p_l!=NULL){
		p_l->set_ElementName(DT("l"));
		p_l->set_Parent(this);
	}
	return back_l;
}
XplExpressionlist* XplFunctioncall::set_args(XplExpressionlist* new_args){
	XplExpressionlist* back_args = p_args;
	p_args = new_args;
	if(p_args!=NULL){
		p_args->set_ElementName(DT("args"));
		p_args->set_Parent(this);
	}
	return back_args;
}
XplFunctionBody* XplFunctioncall::set_bk(XplFunctionBody* new_bk){
	XplFunctionBody* back_bk = p_bk;
	p_bk = new_bk;
	if(p_bk!=NULL){
		p_bk->set_ElementName(DT("bk"));
		p_bk->set_Parent(this);
	}
	return back_bk;
}
XplExpression* XplFunctioncall::new_l(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("l"));
	return node;
}
XplExpressionlist* XplFunctioncall::new_args(){
	XplExpressionlist* node = new XplExpressionlist();
	node->set_ElementName(DT("args"));
	return node;
}
XplFunctionBody* XplFunctioncall::new_bk(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("bk"));
	return node;
}

}

#endif
