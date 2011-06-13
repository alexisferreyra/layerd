/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_CLASSFACTORYDATA_V1_0_CPP
#define __LAYERD_CODEDOM_CLASSFACTORYDATA_V1_0_CPP
#include "CDOM_ClassfactoryData.h"

namespace CodeDOM{

//Region de Constructores Publicos
ClassfactoryData::ClassfactoryData(){
	p_typeFullName = DT_EMPTY;
	p_isInterface = false;
	p_isInteractive = false;
	p_active = true;
	p_moduleFileName = DT_EMPTY;
	p_platforms = DT_EMPTY;
	p_zoeDocFileName = DT_EMPTY;
}
ClassfactoryData::ClassfactoryData(string n_typeFullName, bool n_isInterface, bool n_isInteractive, bool n_active, string n_moduleFileName, string n_zoeDocFileName){
	p_typeFullName = DT_EMPTY;
	p_isInterface = false;
	p_isInteractive = false;
	p_active = true;
	p_moduleFileName = DT_EMPTY;
	p_platforms = DT_EMPTY;
	p_zoeDocFileName = DT_EMPTY;
	set_typeFullName(n_typeFullName);
	set_isInterface(n_isInterface);
	set_isInteractive(n_isInteractive);
	set_active(n_active);
	set_moduleFileName(n_moduleFileName);
	set_zoeDocFileName(n_zoeDocFileName);
}
ClassfactoryData::ClassfactoryData(string n_typeFullName, bool n_isInterface, bool n_isInteractive, bool n_active, string n_moduleFileName, string n_platforms, string n_zoeDocFileName){
	set_typeFullName(n_typeFullName);
	set_isInterface(n_isInterface);
	set_isInteractive(n_isInteractive);
	set_active(n_active);
	set_moduleFileName(n_moduleFileName);
	set_platforms(n_platforms);
	set_zoeDocFileName(n_zoeDocFileName);
}
//Destructor
ClassfactoryData::~ClassfactoryData(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'ClassfactoryData'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* ClassfactoryData::Clone(){
	ClassfactoryData* copy = new ClassfactoryData();
	copy->set_typeFullName(this->p_typeFullName);
	copy->set_isInterface(this->p_isInterface);
	copy->set_isInteractive(this->p_isInteractive);
	copy->set_active(this->p_active);
	copy->set_moduleFileName(this->p_moduleFileName);
	copy->set_platforms(this->p_platforms);
	copy->set_zoeDocFileName(this->p_zoeDocFileName);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool ClassfactoryData::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_typeFullName != DT_EMPTY)
		writer->write(DT(" typeFullName=\"")+CODEDOM_Att_ToString(p_typeFullName)+DT("\""));
	if(p_isInterface != false)
		writer->write(DT(" isInterface=\"")+CODEDOM_Att_ToString(p_isInterface)+DT("\""));
	if(p_isInteractive != false)
		writer->write(DT(" isInteractive=\"")+CODEDOM_Att_ToString(p_isInteractive)+DT("\""));
	if(p_active != true)
		writer->write(DT(" active=\"")+CODEDOM_Att_ToString(p_active)+DT("\""));
	if(p_moduleFileName != DT_EMPTY)
		writer->write(DT(" moduleFileName=\"")+CODEDOM_Att_ToString(p_moduleFileName)+DT("\""));
	if(p_platforms != DT_EMPTY)
		writer->write(DT(" platforms=\"")+CODEDOM_Att_ToString(p_platforms)+DT("\""));
	if(p_zoeDocFileName != DT_EMPTY)
		writer->write(DT(" zoeDocFileName=\"")+CODEDOM_Att_ToString(p_zoeDocFileName)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* ClassfactoryData::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string ClassfactoryData::get_typeFullName(){
	return p_typeFullName;
}
bool ClassfactoryData::get_isInterface(){
	return p_isInterface;
}
bool ClassfactoryData::get_isInteractive(){
	return p_isInteractive;
}
bool ClassfactoryData::get_active(){
	return p_active;
}
string ClassfactoryData::get_moduleFileName(){
	return p_moduleFileName;
}
string ClassfactoryData::get_platforms(){
	return p_platforms;
}
string ClassfactoryData::get_zoeDocFileName(){
	return p_zoeDocFileName;
}

//Funciones para setear Atributos
string ClassfactoryData::set_typeFullName(string new_typeFullName){
	string back_typeFullName = p_typeFullName;
	p_typeFullName = new_typeFullName;
	return back_typeFullName;
}
bool ClassfactoryData::set_isInterface(bool new_isInterface){
	bool back_isInterface = p_isInterface;
	p_isInterface = new_isInterface;
	return back_isInterface;
}
bool ClassfactoryData::set_isInteractive(bool new_isInteractive){
	bool back_isInteractive = p_isInteractive;
	p_isInteractive = new_isInteractive;
	return back_isInteractive;
}
bool ClassfactoryData::set_active(bool new_active){
	bool back_active = p_active;
	p_active = new_active;
	return back_active;
}
string ClassfactoryData::set_moduleFileName(string new_moduleFileName){
	string back_moduleFileName = p_moduleFileName;
	p_moduleFileName = new_moduleFileName;
	return back_moduleFileName;
}
string ClassfactoryData::set_platforms(string new_platforms){
	string back_platforms = p_platforms;
	p_platforms = new_platforms;
	return back_platforms;
}
string ClassfactoryData::set_zoeDocFileName(string new_zoeDocFileName){
	string back_zoeDocFileName = p_zoeDocFileName;
	p_zoeDocFileName = new_zoeDocFileName;
	return back_zoeDocFileName;
}

}

#endif
