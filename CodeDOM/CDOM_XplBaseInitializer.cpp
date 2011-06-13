/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEBASEINITIALIZER_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEBASEINITIALIZER_V1_0_CPP
#include "CDOM_XplBaseInitializer.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplBaseInitializer::XplBaseInitializer(){
	p_className = DT_EMPTY;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_params=NULL;
}
XplBaseInitializer::XplBaseInitializer(XplExpressionlist* n_params){
	p_className = DT_EMPTY;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_params=NULL;
	set_params(n_params);
}
XplBaseInitializer::XplBaseInitializer(string n_className, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_className(n_className);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_params=NULL;
}
XplBaseInitializer::XplBaseInitializer(string n_className, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpressionlist* n_params){
	set_className(n_className);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_params=NULL;
}
//Destructor
XplBaseInitializer::~XplBaseInitializer(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplBaseInitializer'");
#endif
	//Variables para Elementos de Secuencia
	if(p_params!=NULL)delete p_params;
}

//Funciones Sobreescritas de XplNode
XplNode* XplBaseInitializer::Clone(){
	XplBaseInitializer* copy = new XplBaseInitializer();
	copy->set_className(this->p_className);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_params!=NULL)copy->set_params((XplExpressionlist*)p_params->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplBaseInitializer::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_className != DT_EMPTY)
		writer->write(DT(" className=\"")+CODEDOM_Att_ToString(p_className)+DT("\""));
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
	if(p_params!=NULL)if(!p_params->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplBaseInitializer::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplBaseInitializer::get_className(){
	return p_className;
}
string XplBaseInitializer::get_doc(){
	return p_doc;
}
string XplBaseInitializer::get_helpURL(){
	return p_helpURL;
}
string XplBaseInitializer::get_ldsrc(){
	return p_ldsrc;
}
bool XplBaseInitializer::get_iny(){
	return p_iny;
}
string XplBaseInitializer::get_inydata(){
	return p_inydata;
}
string XplBaseInitializer::get_inyby(){
	return p_inyby;
}
string XplBaseInitializer::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplExpressionlist* XplBaseInitializer::get_params(){
	return p_params;
}

//Funciones para setear Atributos
string XplBaseInitializer::set_className(string new_className){
	string back_className = p_className;
	p_className = new_className;
	return back_className;
}
string XplBaseInitializer::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplBaseInitializer::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplBaseInitializer::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplBaseInitializer::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplBaseInitializer::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplBaseInitializer::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplBaseInitializer::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplExpressionlist* XplBaseInitializer::set_params(XplExpressionlist* new_params){
	XplExpressionlist* back_params = p_params;
	p_params = new_params;
	if(p_params!=NULL){
		p_params->set_ElementName(DT("params"));
		p_params->set_Parent(this);
	}
	return back_params;
}
XplExpressionlist* XplBaseInitializer::new_params(){
	XplExpressionlist* node = new XplExpressionlist();
	node->set_ElementName(DT("params"));
	return node;
}

}

#endif
