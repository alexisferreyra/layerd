/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOELITERAL_V1_0_CPP
#define __LAYERD_CODEDOM_ZOELITERAL_V1_0_CPP
#include "CDOM_XplLiteral.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplLiteral::XplLiteral(){
	p_str = DT_EMPTY;
	p_type = (XplLiteraltype_enum)0;
	p_subtype = DT("none");
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
}
XplLiteral::XplLiteral(string n_str, string n_subtype){
	p_str = DT_EMPTY;
	p_type = (XplLiteraltype_enum)0;
	p_subtype = DT("none");
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_str(n_str);
	set_subtype(n_subtype);
}
XplLiteral::XplLiteral(string n_str, XplLiteraltype_enum n_type, string n_subtype, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_str(n_str);
	set_type(n_type);
	set_subtype(n_subtype);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
}
//Destructor
XplLiteral::~XplLiteral(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplLiteral'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* XplLiteral::Clone(){
	XplLiteral* copy = new XplLiteral();
	copy->set_str(this->p_str);
	copy->set_type(this->p_type);
	copy->set_subtype(this->p_subtype);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplLiteral::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_str != DT_EMPTY)
		writer->write(DT(" str=\"")+CODEDOM_Att_ToString(p_str)+DT("\""));
	if(p_type != (XplLiteraltype_enum)0)
		writer->write(DT(" type=\"")+(string)__CODEDOM_ZOELITERALTYPE_ENUM[p_type]+DT("\""));
	if(p_subtype != DT("none"))
		writer->write(DT(" subtype=\"")+CODEDOM_Att_ToString(p_subtype)+DT("\""));
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
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplLiteral::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplLiteral::get_str(){
	return p_str;
}
XplLiteraltype_enum XplLiteral::get_type(){
	return p_type;
}
string XplLiteral::get_subtype(){
	return p_subtype;
}
string XplLiteral::get_doc(){
	return p_doc;
}
string XplLiteral::get_helpURL(){
	return p_helpURL;
}
string XplLiteral::get_ldsrc(){
	return p_ldsrc;
}
bool XplLiteral::get_iny(){
	return p_iny;
}
string XplLiteral::get_inydata(){
	return p_inydata;
}
string XplLiteral::get_inyby(){
	return p_inyby;
}
string XplLiteral::get_lddata(){
	return p_lddata;
}

//Funciones para setear Atributos
string XplLiteral::set_str(string new_str){
	string back_str = p_str;
	p_str = new_str;
	return back_str;
}
XplLiteraltype_enum XplLiteral::set_type(XplLiteraltype_enum new_type){
	XplLiteraltype_enum back_type = p_type;
	p_type = new_type;
	return back_type;
}
string XplLiteral::set_subtype(string new_subtype){
	string back_subtype = p_subtype;
	p_subtype = new_subtype;
	return back_subtype;
}
string XplLiteral::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplLiteral::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplLiteral::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplLiteral::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplLiteral::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplLiteral::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplLiteral::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

}

#endif
