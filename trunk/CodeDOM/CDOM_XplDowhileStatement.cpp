/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEDOWHILESTATEMENT_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEDOWHILESTATEMENT_V1_0_CPP
#include "CDOM_XplDowhileStatement.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplDowhileStatement::XplDowhileStatement(){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_boolean=NULL;
	p_dobk=NULL;
}
XplDowhileStatement::XplDowhileStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_boolean=NULL;
	p_dobk=NULL;
}
XplDowhileStatement::XplDowhileStatement(XplExpression* n_boolean, XplFunctionBody* n_dobk){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_boolean=NULL;
	p_dobk=NULL;
	set_boolean(n_boolean);
	set_dobk(n_dobk);
}
XplDowhileStatement::XplDowhileStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_boolean, XplFunctionBody* n_dobk){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_boolean=NULL;
	p_dobk=NULL;
	set_boolean(n_boolean);
	set_dobk(n_dobk);
}
//Destructor
XplDowhileStatement::~XplDowhileStatement(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplDowhileStatement'");
#endif
	//Variables para Elementos de Secuencia
	if(p_boolean!=NULL)delete p_boolean;
	if(p_dobk!=NULL)delete p_dobk;
}

//Funciones Sobreescritas de XplNode
XplNode* XplDowhileStatement::Clone(){
	XplDowhileStatement* copy = new XplDowhileStatement();
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_boolean!=NULL)copy->set_boolean((XplExpression*)p_boolean->Clone());
	if(p_dobk!=NULL)copy->set_dobk((XplFunctionBody*)p_dobk->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplDowhileStatement::Write(XplWriter* writer){
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
	if(p_boolean!=NULL)if(!p_boolean->Write(writer))result=false;
	if(p_dobk!=NULL)if(!p_dobk->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplDowhileStatement::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplDowhileStatement::get_doc(){
	return p_doc;
}
string XplDowhileStatement::get_helpURL(){
	return p_helpURL;
}
string XplDowhileStatement::get_ldsrc(){
	return p_ldsrc;
}
bool XplDowhileStatement::get_iny(){
	return p_iny;
}
string XplDowhileStatement::get_inydata(){
	return p_inydata;
}
string XplDowhileStatement::get_inyby(){
	return p_inyby;
}
string XplDowhileStatement::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplExpression* XplDowhileStatement::get_boolean(){
	return p_boolean;
}
XplFunctionBody* XplDowhileStatement::get_dobk(){
	return p_dobk;
}

//Funciones para setear Atributos
string XplDowhileStatement::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplDowhileStatement::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplDowhileStatement::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplDowhileStatement::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplDowhileStatement::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplDowhileStatement::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplDowhileStatement::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplExpression* XplDowhileStatement::set_boolean(XplExpression* new_boolean){
	XplExpression* back_boolean = p_boolean;
	p_boolean = new_boolean;
	if(p_boolean!=NULL){
		p_boolean->set_ElementName(DT("boolean"));
		p_boolean->set_Parent(this);
	}
	return back_boolean;
}
XplFunctionBody* XplDowhileStatement::set_dobk(XplFunctionBody* new_dobk){
	XplFunctionBody* back_dobk = p_dobk;
	p_dobk = new_dobk;
	if(p_dobk!=NULL){
		p_dobk->set_ElementName(DT("dobk"));
		p_dobk->set_Parent(this);
	}
	return back_dobk;
}
XplExpression* XplDowhileStatement::new_boolean(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("boolean"));
	return node;
}
XplFunctionBody* XplDowhileStatement::new_dobk(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("dobk"));
	return node;
}

}

#endif
