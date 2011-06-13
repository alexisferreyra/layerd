/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEERROR_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEERROR_V1_0_CPP
#include "CDOM_XplError.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplError::XplError(){
	p_str = DT_EMPTY;
	p_level = 1;
	p_sourcefile = DT_EMPTY;
	p_sourcepos = DT_EMPTY;
	p_sourceType = ZOEERRORSOURCETYPE_ENUM_ZOE_DOC;
}
XplError::XplError(string n_str, int n_level, XplErrorsourcetype_enum n_sourceType){
	p_str = DT_EMPTY;
	p_level = 1;
	p_sourcefile = DT_EMPTY;
	p_sourcepos = DT_EMPTY;
	p_sourceType = ZOEERRORSOURCETYPE_ENUM_ZOE_DOC;
	set_str(n_str);
	set_level(n_level);
	set_sourceType(n_sourceType);
}
XplError::XplError(string n_str, int n_level, string n_sourcefile, string n_sourcepos, XplErrorsourcetype_enum n_sourceType){
	set_str(n_str);
	set_level(n_level);
	set_sourcefile(n_sourcefile);
	set_sourcepos(n_sourcepos);
	set_sourceType(n_sourceType);
}
//Destructor
XplError::~XplError(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplError'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* XplError::Clone(){
	XplError* copy = new XplError();
	copy->set_str(this->p_str);
	copy->set_level(this->p_level);
	copy->set_sourcefile(this->p_sourcefile);
	copy->set_sourcepos(this->p_sourcepos);
	copy->set_sourceType(this->p_sourceType);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplError::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_str != DT_EMPTY)
		writer->write(DT(" str=\"")+CODEDOM_Att_ToString(p_str)+DT("\""));
	if(p_level != 1)
		writer->write(DT(" level=\"")+CODEDOM_Att_ToString(p_level)+DT("\""));
	if(p_sourcefile != DT_EMPTY)
		writer->write(DT(" sourcefile=\"")+CODEDOM_Att_ToString(p_sourcefile)+DT("\""));
	if(p_sourcepos != DT_EMPTY)
		writer->write(DT(" sourcepos=\"")+CODEDOM_Att_ToString(p_sourcepos)+DT("\""));
	if(p_sourceType != ZOEERRORSOURCETYPE_ENUM_ZOE_DOC)
		writer->write(DT(" sourceType=\"")+(string)__CODEDOM_ZOEERRORSOURCETYPE_ENUM[p_sourceType]+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplError::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplError::get_str(){
	return p_str;
}
int XplError::get_level(){
	return p_level;
}
string XplError::get_sourcefile(){
	return p_sourcefile;
}
string XplError::get_sourcepos(){
	return p_sourcepos;
}
XplErrorsourcetype_enum XplError::get_sourceType(){
	return p_sourceType;
}

//Funciones para setear Atributos
string XplError::set_str(string new_str){
	string back_str = p_str;
	p_str = new_str;
	return back_str;
}
int XplError::set_level(int new_level){
	int back_level = p_level;
	p_level = new_level;
	return back_level;
}
string XplError::set_sourcefile(string new_sourcefile){
	string back_sourcefile = p_sourcefile;
	p_sourcefile = new_sourcefile;
	return back_sourcefile;
}
string XplError::set_sourcepos(string new_sourcepos){
	string back_sourcepos = p_sourcepos;
	p_sourcepos = new_sourcepos;
	return back_sourcepos;
}
XplErrorsourcetype_enum XplError::set_sourceType(XplErrorsourcetype_enum new_sourceType){
	XplErrorsourcetype_enum back_sourceType = p_sourceType;
	p_sourceType = new_sourceType;
	return back_sourceType;
}

}

#endif
