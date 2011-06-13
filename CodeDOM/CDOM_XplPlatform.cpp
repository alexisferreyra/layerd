/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEPLATFORM_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEPLATFORM_V1_0_CPP
#include "CDOM_XplPlatform.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplPlatform::XplPlatform(){
	p_name = DT_EMPTY;
	p_version = DT_EMPTY;
	p_match = ZOEPLATFORMMATCH_ENUM_LIKE;
	p_customMatcher = DT_EMPTY;
}
XplPlatform::XplPlatform(string n_name, XplPlatformMatch_enum n_match){
	p_name = DT_EMPTY;
	p_version = DT_EMPTY;
	p_match = ZOEPLATFORMMATCH_ENUM_LIKE;
	p_customMatcher = DT_EMPTY;
	set_name(n_name);
	set_match(n_match);
}
XplPlatform::XplPlatform(string n_name, string n_version, XplPlatformMatch_enum n_match, string n_customMatcher){
	set_name(n_name);
	set_version(n_version);
	set_match(n_match);
	set_customMatcher(n_customMatcher);
}
//Destructor
XplPlatform::~XplPlatform(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplPlatform'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* XplPlatform::Clone(){
	XplPlatform* copy = new XplPlatform();
	copy->set_name(this->p_name);
	copy->set_version(this->p_version);
	copy->set_match(this->p_match);
	copy->set_customMatcher(this->p_customMatcher);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplPlatform::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_name != DT_EMPTY)
		writer->write(DT(" name=\"")+CODEDOM_Att_ToString(p_name)+DT("\""));
	if(p_version != DT_EMPTY)
		writer->write(DT(" version=\"")+CODEDOM_Att_ToString(p_version)+DT("\""));
	if(p_match != ZOEPLATFORMMATCH_ENUM_LIKE)
		writer->write(DT(" match=\"")+(string)__CODEDOM_ZOEPLATFORMMATCH_ENUM[p_match]+DT("\""));
	if(p_customMatcher != DT_EMPTY)
		writer->write(DT(" customMatcher=\"")+CODEDOM_Att_ToString(p_customMatcher)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplPlatform::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplPlatform::get_name(){
	return p_name;
}
string XplPlatform::get_version(){
	return p_version;
}
XplPlatformMatch_enum XplPlatform::get_match(){
	return p_match;
}
string XplPlatform::get_customMatcher(){
	return p_customMatcher;
}

//Funciones para setear Atributos
string XplPlatform::set_name(string new_name){
	string back_name = p_name;
	p_name = new_name;
	return back_name;
}
string XplPlatform::set_version(string new_version){
	string back_version = p_version;
	p_version = new_version;
	return back_version;
}
XplPlatformMatch_enum XplPlatform::set_match(XplPlatformMatch_enum new_match){
	XplPlatformMatch_enum back_match = p_match;
	p_match = new_match;
	return back_match;
}
string XplPlatform::set_customMatcher(string new_customMatcher){
	string back_customMatcher = p_customMatcher;
	p_customMatcher = new_customMatcher;
	return back_customMatcher;
}

}

#endif
