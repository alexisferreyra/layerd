/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEFORSTATEMENT_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEFORSTATEMENT_V1_0_CPP
#include "CDOM_XplForStatement.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplForStatement::XplForStatement(){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_init=NULL;
	p_condition=NULL;
	p_repeat=NULL;
	p_forblock=NULL;
}
XplForStatement::XplForStatement(XplForinit* n_init, XplExpression* n_condition, XplExpressionlist* n_repeat, XplFunctionBody* n_forblock){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_init=NULL;
	p_condition=NULL;
	p_repeat=NULL;
	p_forblock=NULL;
	set_init(n_init);
	set_condition(n_condition);
	set_repeat(n_repeat);
	set_forblock(n_forblock);
}
XplForStatement::XplForStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_init=NULL;
	p_condition=NULL;
	p_repeat=NULL;
	p_forblock=NULL;
}
XplForStatement::XplForStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplForinit* n_init, XplExpression* n_condition, XplExpressionlist* n_repeat, XplFunctionBody* n_forblock){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_init=NULL;
	p_condition=NULL;
	p_repeat=NULL;
	p_forblock=NULL;
}
//Destructor
XplForStatement::~XplForStatement(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplForStatement'");
#endif
	//Variables para Elementos de Secuencia
	if(p_init!=NULL)delete p_init;
	if(p_condition!=NULL)delete p_condition;
	if(p_repeat!=NULL)delete p_repeat;
	if(p_forblock!=NULL)delete p_forblock;
}

//Funciones Sobreescritas de XplNode
XplNode* XplForStatement::Clone(){
	XplForStatement* copy = new XplForStatement();
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_init!=NULL)copy->set_init((XplForinit*)p_init->Clone());
	if(p_condition!=NULL)copy->set_condition((XplExpression*)p_condition->Clone());
	if(p_repeat!=NULL)copy->set_repeat((XplExpressionlist*)p_repeat->Clone());
	if(p_forblock!=NULL)copy->set_forblock((XplFunctionBody*)p_forblock->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplForStatement::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
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
	if(p_init!=NULL)if(!p_init->Write(writer))result=false;
	if(p_condition!=NULL)if(!p_condition->Write(writer))result=false;
	if(p_repeat!=NULL)if(!p_repeat->Write(writer))result=false;
	if(p_forblock!=NULL)if(!p_forblock->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplForStatement::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplForStatement::get_doc(){
	return p_doc;
}
string XplForStatement::get_helpURL(){
	return p_helpURL;
}
string XplForStatement::get_ldsrc(){
	return p_ldsrc;
}
bool XplForStatement::get_iny(){
	return p_iny;
}
string XplForStatement::get_inydata(){
	return p_inydata;
}
string XplForStatement::get_inyby(){
	return p_inyby;
}
string XplForStatement::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplForinit* XplForStatement::get_init(){
	return p_init;
}
XplExpression* XplForStatement::get_condition(){
	return p_condition;
}
XplExpressionlist* XplForStatement::get_repeat(){
	return p_repeat;
}
XplFunctionBody* XplForStatement::get_forblock(){
	return p_forblock;
}

//Funciones para setear Atributos
string XplForStatement::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplForStatement::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplForStatement::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplForStatement::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplForStatement::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplForStatement::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplForStatement::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplForinit* XplForStatement::set_init(XplForinit* new_init){
	XplForinit* back_init = p_init;
	p_init = new_init;
	if(p_init!=NULL){
		p_init->set_ElementName(DT("init"));
		p_init->set_Parent(this);
	}
	return back_init;
}
XplExpression* XplForStatement::set_condition(XplExpression* new_condition){
	XplExpression* back_condition = p_condition;
	p_condition = new_condition;
	if(p_condition!=NULL){
		p_condition->set_ElementName(DT("condition"));
		p_condition->set_Parent(this);
	}
	return back_condition;
}
XplExpressionlist* XplForStatement::set_repeat(XplExpressionlist* new_repeat){
	XplExpressionlist* back_repeat = p_repeat;
	p_repeat = new_repeat;
	if(p_repeat!=NULL){
		p_repeat->set_ElementName(DT("repeat"));
		p_repeat->set_Parent(this);
	}
	return back_repeat;
}
XplFunctionBody* XplForStatement::set_forblock(XplFunctionBody* new_forblock){
	XplFunctionBody* back_forblock = p_forblock;
	p_forblock = new_forblock;
	if(p_forblock!=NULL){
		p_forblock->set_ElementName(DT("forblock"));
		p_forblock->set_Parent(this);
	}
	return back_forblock;
}
XplForinit* XplForStatement::new_init(){
	XplForinit* node = new XplForinit();
	node->set_ElementName(DT("init"));
	return node;
}
XplExpression* XplForStatement::new_condition(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("condition"));
	return node;
}
XplExpressionlist* XplForStatement::new_repeat(){
	XplExpressionlist* node = new XplExpressionlist();
	node->set_ElementName(DT("repeat"));
	return node;
}
XplFunctionBody* XplForStatement::new_forblock(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("forblock"));
	return node;
}

}

#endif
