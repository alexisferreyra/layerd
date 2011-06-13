/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOENEWEXPRESSION_V1_0_CPP
#define __LAYERD_CODEDOM_ZOENEWEXPRESSION_V1_0_CPP
#include "CDOM_XplNewExpression.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplNewExpression::XplNewExpression(){
	p_GCName = DT("default");
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_type=NULL;
	p_init=NULL;
	p_GCParams=NULL;
}
XplNewExpression::XplNewExpression(string n_GCName){
	p_GCName = DT("default");
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_GCName(n_GCName);
	p_type=NULL;
	p_init=NULL;
	p_GCParams=NULL;
}
XplNewExpression::XplNewExpression(XplType* n_type){
	p_GCName = DT("default");
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_type=NULL;
	p_init=NULL;
	p_GCParams=NULL;
	set_type(n_type);
}
XplNewExpression::XplNewExpression(string n_GCName, XplType* n_type){
	p_GCName = DT("default");
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_GCName(n_GCName);
	p_type=NULL;
	p_init=NULL;
	p_GCParams=NULL;
	set_type(n_type);
}
XplNewExpression::XplNewExpression(string n_GCName, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_GCName(n_GCName);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_type=NULL;
	p_init=NULL;
	p_GCParams=NULL;
}
XplNewExpression::XplNewExpression(XplType* n_type, XplInitializerList* n_init, XplExpressionlist* n_GCParams){
	p_GCName = DT("default");
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_type=NULL;
	p_init=NULL;
	p_GCParams=NULL;
	set_type(n_type);
	set_init(n_init);
	set_GCParams(n_GCParams);
}
XplNewExpression::XplNewExpression(string n_GCName, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type){
	set_GCName(n_GCName);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_GCName(n_GCName);
	p_type=NULL;
	p_init=NULL;
	p_GCParams=NULL;
}
XplNewExpression::XplNewExpression(string n_GCName, XplType* n_type, XplInitializerList* n_init, XplExpressionlist* n_GCParams){
	p_GCName = DT("default");
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_GCName(n_GCName);
	p_type=NULL;
	p_init=NULL;
	p_GCParams=NULL;
	set_type(n_type);
	set_init(n_init);
	set_GCParams(n_GCParams);
}
XplNewExpression::XplNewExpression(string n_GCName, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type, XplInitializerList* n_init, XplExpressionlist* n_GCParams){
	set_GCName(n_GCName);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_type=NULL;
	p_init=NULL;
	p_GCParams=NULL;
	set_type(n_type);
	set_init(n_init);
	set_GCParams(n_GCParams);
}
//Destructor
XplNewExpression::~XplNewExpression(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplNewExpression'");
#endif
	//Variables para Elementos de Secuencia
	if(p_type!=NULL)delete p_type;
	if(p_init!=NULL)delete p_init;
	if(p_GCParams!=NULL)delete p_GCParams;
}

//Funciones Sobreescritas de XplNode
XplNode* XplNewExpression::Clone(){
	XplNewExpression* copy = new XplNewExpression();
	copy->set_GCName(this->p_GCName);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_type!=NULL)copy->set_type((XplType*)p_type->Clone());
	if(p_init!=NULL)copy->set_init((XplInitializerList*)p_init->Clone());
	if(p_GCParams!=NULL)copy->set_GCParams((XplExpressionlist*)p_GCParams->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplNewExpression::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_GCName != DT("default"))
		writer->write(DT(" GCName=\"")+CODEDOM_Att_ToString(p_GCName)+DT("\""));
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
	if(p_type!=NULL)if(!p_type->Write(writer))result=false;
	if(p_init!=NULL)if(!p_init->Write(writer))result=false;
	if(p_GCParams!=NULL)if(!p_GCParams->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplNewExpression::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplNewExpression::get_GCName(){
	return p_GCName;
}
string XplNewExpression::get_doc(){
	return p_doc;
}
string XplNewExpression::get_helpURL(){
	return p_helpURL;
}
string XplNewExpression::get_ldsrc(){
	return p_ldsrc;
}
bool XplNewExpression::get_iny(){
	return p_iny;
}
string XplNewExpression::get_inydata(){
	return p_inydata;
}
string XplNewExpression::get_inyby(){
	return p_inyby;
}
string XplNewExpression::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplType* XplNewExpression::get_type(){
	return p_type;
}
XplInitializerList* XplNewExpression::get_init(){
	return p_init;
}
XplExpressionlist* XplNewExpression::get_GCParams(){
	return p_GCParams;
}

//Funciones para setear Atributos
string XplNewExpression::set_GCName(string new_GCName){
	string back_GCName = p_GCName;
	p_GCName = new_GCName;
	return back_GCName;
}
string XplNewExpression::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplNewExpression::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplNewExpression::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplNewExpression::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplNewExpression::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplNewExpression::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplNewExpression::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplType* XplNewExpression::set_type(XplType* new_type){
	XplType* back_type = p_type;
	p_type = new_type;
	if(p_type!=NULL){
		p_type->set_ElementName(DT("type"));
		p_type->set_Parent(this);
	}
	return back_type;
}
XplInitializerList* XplNewExpression::set_init(XplInitializerList* new_init){
	XplInitializerList* back_init = p_init;
	p_init = new_init;
	if(p_init!=NULL){
		p_init->set_ElementName(DT("init"));
		p_init->set_Parent(this);
	}
	return back_init;
}
XplExpressionlist* XplNewExpression::set_GCParams(XplExpressionlist* new_GCParams){
	XplExpressionlist* back_GCParams = p_GCParams;
	p_GCParams = new_GCParams;
	if(p_GCParams!=NULL){
		p_GCParams->set_ElementName(DT("GCParams"));
		p_GCParams->set_Parent(this);
	}
	return back_GCParams;
}
XplType* XplNewExpression::new_type(){
	XplType* node = new XplType();
	node->set_ElementName(DT("type"));
	return node;
}
XplInitializerList* XplNewExpression::new_init(){
	XplInitializerList* node = new XplInitializerList();
	node->set_ElementName(DT("init"));
	return node;
}
XplExpressionlist* XplNewExpression::new_GCParams(){
	XplExpressionlist* node = new XplExpressionlist();
	node->set_ElementName(DT("GCParams"));
	return node;
}

}

#endif
