/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOECATCHSTATEMENT_V1_0_CPP
#define __LAYERD_CODEDOM_ZOECATCHSTATEMENT_V1_0_CPP
#include "CDOM_XplCatchStatement.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplCatchStatement::XplCatchStatement(){
	p_default = true;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_init=NULL;
	p_bk=NULL;
}
XplCatchStatement::XplCatchStatement(bool n_default){
	p_default = true;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_default(n_default);
	p_init=NULL;
	p_bk=NULL;
}
XplCatchStatement::XplCatchStatement(XplCatchinit* n_init, XplFunctionBody* n_bk){
	p_default = true;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_init=NULL;
	p_bk=NULL;
	set_init(n_init);
	set_bk(n_bk);
}
XplCatchStatement::XplCatchStatement(bool n_default, XplCatchinit* n_init, XplFunctionBody* n_bk){
	p_default = true;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_default(n_default);
	p_init=NULL;
	p_bk=NULL;
	set_init(n_init);
	set_bk(n_bk);
}
XplCatchStatement::XplCatchStatement(bool n_default, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_default(n_default);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_init=NULL;
	p_bk=NULL;
}
XplCatchStatement::XplCatchStatement(bool n_default, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplCatchinit* n_init, XplFunctionBody* n_bk){
	set_default(n_default);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_default(n_default);
	p_init=NULL;
	p_bk=NULL;
}
//Destructor
XplCatchStatement::~XplCatchStatement(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplCatchStatement'");
#endif
	//Variables para Elementos de Secuencia
	if(p_init!=NULL)delete p_init;
	if(p_bk!=NULL)delete p_bk;
}

//Funciones Sobreescritas de XplNode
XplNode* XplCatchStatement::Clone(){
	XplCatchStatement* copy = new XplCatchStatement();
	copy->set_default(this->p_default);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_init!=NULL)copy->set_init((XplCatchinit*)p_init->Clone());
	if(p_bk!=NULL)copy->set_bk((XplFunctionBody*)p_bk->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplCatchStatement::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_default != true)
		writer->write(DT(" default=\"")+CODEDOM_Att_ToString(p_default)+DT("\""));
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
	if(p_bk!=NULL)if(!p_bk->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplCatchStatement::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
bool XplCatchStatement::get_default(){
	return p_default;
}
string XplCatchStatement::get_doc(){
	return p_doc;
}
string XplCatchStatement::get_helpURL(){
	return p_helpURL;
}
string XplCatchStatement::get_ldsrc(){
	return p_ldsrc;
}
bool XplCatchStatement::get_iny(){
	return p_iny;
}
string XplCatchStatement::get_inydata(){
	return p_inydata;
}
string XplCatchStatement::get_inyby(){
	return p_inyby;
}
string XplCatchStatement::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplCatchinit* XplCatchStatement::get_init(){
	return p_init;
}
XplFunctionBody* XplCatchStatement::get_bk(){
	return p_bk;
}

//Funciones para setear Atributos
bool XplCatchStatement::set_default(bool new_default){
	bool back_default = p_default;
	p_default = new_default;
	return back_default;
}
string XplCatchStatement::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplCatchStatement::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplCatchStatement::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplCatchStatement::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplCatchStatement::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplCatchStatement::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplCatchStatement::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplCatchinit* XplCatchStatement::set_init(XplCatchinit* new_init){
	XplCatchinit* back_init = p_init;
	p_init = new_init;
	if(p_init!=NULL){
		p_init->set_ElementName(DT("init"));
		p_init->set_Parent(this);
	}
	return back_init;
}
XplFunctionBody* XplCatchStatement::set_bk(XplFunctionBody* new_bk){
	XplFunctionBody* back_bk = p_bk;
	p_bk = new_bk;
	if(p_bk!=NULL){
		p_bk->set_ElementName(DT("bk"));
		p_bk->set_Parent(this);
	}
	return back_bk;
}
XplCatchinit* XplCatchStatement::new_init(){
	XplCatchinit* node = new XplCatchinit();
	node->set_ElementName(DT("init"));
	return node;
}
XplFunctionBody* XplCatchStatement::new_bk(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("bk"));
	return node;
}

}

#endif
