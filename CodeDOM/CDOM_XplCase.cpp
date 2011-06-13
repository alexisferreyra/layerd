/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOECASE_V1_0_CPP
#define __LAYERD_CODEDOM_ZOECASE_V1_0_CPP
#include "CDOM_XplCase.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplCase::XplCase(){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_e=NULL;
	p_bk=NULL;
}
XplCase::XplCase(XplExpression* n_e, XplFunctionBody* n_bk){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_e=NULL;
	p_bk=NULL;
	set_e(n_e);
	set_bk(n_bk);
}
XplCase::XplCase(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_e=NULL;
	p_bk=NULL;
}
XplCase::XplCase(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_e, XplFunctionBody* n_bk){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_e=NULL;
	p_bk=NULL;
}
//Destructor
XplCase::~XplCase(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplCase'");
#endif
	//Variables para Elementos de Secuencia
	if(p_e!=NULL)delete p_e;
	if(p_bk!=NULL)delete p_bk;
}

//Funciones Sobreescritas de XplNode
XplNode* XplCase::Clone(){
	XplCase* copy = new XplCase();
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_e!=NULL)copy->set_e((XplExpression*)p_e->Clone());
	if(p_bk!=NULL)copy->set_bk((XplFunctionBody*)p_bk->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplCase::Write(XplWriter* writer){
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
	if(p_e!=NULL)if(!p_e->Write(writer))result=false;
	if(p_bk!=NULL)if(!p_bk->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplCase::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplCase::get_doc(){
	return p_doc;
}
string XplCase::get_helpURL(){
	return p_helpURL;
}
string XplCase::get_ldsrc(){
	return p_ldsrc;
}
bool XplCase::get_iny(){
	return p_iny;
}
string XplCase::get_inydata(){
	return p_inydata;
}
string XplCase::get_inyby(){
	return p_inyby;
}
string XplCase::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplExpression* XplCase::get_e(){
	return p_e;
}
XplFunctionBody* XplCase::get_bk(){
	return p_bk;
}

//Funciones para setear Atributos
string XplCase::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplCase::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplCase::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplCase::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplCase::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplCase::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplCase::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplExpression* XplCase::set_e(XplExpression* new_e){
	XplExpression* back_e = p_e;
	p_e = new_e;
	if(p_e!=NULL){
		p_e->set_ElementName(DT("e"));
		p_e->set_Parent(this);
	}
	return back_e;
}
XplFunctionBody* XplCase::set_bk(XplFunctionBody* new_bk){
	XplFunctionBody* back_bk = p_bk;
	p_bk = new_bk;
	if(p_bk!=NULL){
		p_bk->set_ElementName(DT("bk"));
		p_bk->set_Parent(this);
	}
	return back_bk;
}
XplExpression* XplCase::new_e(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("e"));
	return node;
}
XplFunctionBody* XplCase::new_bk(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("bk"));
	return node;
}

}

#endif
