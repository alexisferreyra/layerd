/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEPLATFORMALIAS_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEPLATFORMALIAS_V1_0_CPP
#include "CDOM_XplPlatformAlias.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplPlatformAlias::XplPlatformAlias(){
	p_standardName = DT_EMPTY;
	p_standardVersion = DT_EMPTY;
	p_configAlias = DT_EMPTY;
}
XplPlatformAlias::XplPlatformAlias(string n_standardName, string n_configAlias){
	p_standardName = DT_EMPTY;
	p_standardVersion = DT_EMPTY;
	p_configAlias = DT_EMPTY;
	set_standardName(n_standardName);
	set_configAlias(n_configAlias);
}
XplPlatformAlias::XplPlatformAlias(string n_standardName, string n_standardVersion, string n_configAlias){
	set_standardName(n_standardName);
	set_standardVersion(n_standardVersion);
	set_configAlias(n_configAlias);
}
//Destructor
XplPlatformAlias::~XplPlatformAlias(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplPlatformAlias'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* XplPlatformAlias::Clone(){
	XplPlatformAlias* copy = new XplPlatformAlias();
	copy->set_standardName(this->p_standardName);
	copy->set_standardVersion(this->p_standardVersion);
	copy->set_configAlias(this->p_configAlias);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplPlatformAlias::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_standardName != DT_EMPTY)
		writer->write(DT(" standardName=\"")+CODEDOM_Att_ToString(p_standardName)+DT("\""));
	if(p_standardVersion != DT_EMPTY)
		writer->write(DT(" standardVersion=\"")+CODEDOM_Att_ToString(p_standardVersion)+DT("\""));
	if(p_configAlias != DT_EMPTY)
		writer->write(DT(" configAlias=\"")+CODEDOM_Att_ToString(p_configAlias)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplPlatformAlias::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplPlatformAlias::get_standardName(){
	return p_standardName;
}
string XplPlatformAlias::get_standardVersion(){
	return p_standardVersion;
}
string XplPlatformAlias::get_configAlias(){
	return p_configAlias;
}

//Funciones para setear Atributos
string XplPlatformAlias::set_standardName(string new_standardName){
	string back_standardName = p_standardName;
	p_standardName = new_standardName;
	return back_standardName;
}
string XplPlatformAlias::set_standardVersion(string new_standardVersion){
	string back_standardVersion = p_standardVersion;
	p_standardVersion = new_standardVersion;
	return back_standardVersion;
}
string XplPlatformAlias::set_configAlias(string new_configAlias){
	string back_configAlias = p_configAlias;
	p_configAlias = new_configAlias;
	return back_configAlias;
}

}

#endif
