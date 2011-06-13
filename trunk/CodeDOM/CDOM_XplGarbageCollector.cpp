/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEGARBAGECOLLECTOR_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEGARBAGECOLLECTOR_V1_0_CPP
#include "CDOM_XplGarbageCollector.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplGarbageCollector::XplGarbageCollector(){
	p_name = DT_EMPTY;
	p_description = DT_EMPTY;
	p_sourceFile = DT_EMPTY;
	p_xplCompilerData = DT_EMPTY;
}
XplGarbageCollector::XplGarbageCollector(string n_name){
	p_name = DT_EMPTY;
	p_description = DT_EMPTY;
	p_sourceFile = DT_EMPTY;
	p_xplCompilerData = DT_EMPTY;
	set_name(n_name);
}
XplGarbageCollector::XplGarbageCollector(string n_name, string n_description, string n_sourceFile, string n_xplCompilerData){
	set_name(n_name);
	set_description(n_description);
	set_sourceFile(n_sourceFile);
	set_xplCompilerData(n_xplCompilerData);
}
//Destructor
XplGarbageCollector::~XplGarbageCollector(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplGarbageCollector'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* XplGarbageCollector::Clone(){
	XplGarbageCollector* copy = new XplGarbageCollector();
	copy->set_name(this->p_name);
	copy->set_description(this->p_description);
	copy->set_sourceFile(this->p_sourceFile);
	copy->set_xplCompilerData(this->p_xplCompilerData);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplGarbageCollector::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_name != DT_EMPTY)
		writer->write(DT(" name=\"")+CODEDOM_Att_ToString(p_name)+DT("\""));
	if(p_description != DT_EMPTY)
		writer->write(DT(" description=\"")+CODEDOM_Att_ToString(p_description)+DT("\""));
	if(p_sourceFile != DT_EMPTY)
		writer->write(DT(" sourceFile=\"")+CODEDOM_Att_ToString(p_sourceFile)+DT("\""));
	if(p_xplCompilerData != DT_EMPTY)
		writer->write(DT(" xplCompilerData=\"")+CODEDOM_Att_ToString(p_xplCompilerData)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplGarbageCollector::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplGarbageCollector::get_name(){
	return p_name;
}
string XplGarbageCollector::get_description(){
	return p_description;
}
string XplGarbageCollector::get_sourceFile(){
	return p_sourceFile;
}
string XplGarbageCollector::get_xplCompilerData(){
	return p_xplCompilerData;
}

//Funciones para setear Atributos
string XplGarbageCollector::set_name(string new_name){
	string back_name = p_name;
	p_name = new_name;
	return back_name;
}
string XplGarbageCollector::set_description(string new_description){
	string back_description = p_description;
	p_description = new_description;
	return back_description;
}
string XplGarbageCollector::set_sourceFile(string new_sourceFile){
	string back_sourceFile = p_sourceFile;
	p_sourceFile = new_sourceFile;
	return back_sourceFile;
}
string XplGarbageCollector::set_xplCompilerData(string new_xplCompilerData){
	string back_xplCompilerData = p_xplCompilerData;
	p_xplCompilerData = new_xplCompilerData;
	return back_xplCompilerData;
}

}

#endif
