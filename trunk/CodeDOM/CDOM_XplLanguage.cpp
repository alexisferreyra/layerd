/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOELANGUAGE_V1_0_CPP
#define __LAYERD_CODEDOM_ZOELANGUAGE_V1_0_CPP
#include "CDOM_XplLanguage.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplLanguage::XplLanguage(){
	p_Source = DT_EMPTY;
	p_StandardDefinitionFile = DT_EMPTY;
	p_SourceVersion = DT_EMPTY;
	p_Destination = DT_EMPTY;
}
XplLanguage::XplLanguage(string n_Source){
	p_Source = DT_EMPTY;
	p_StandardDefinitionFile = DT_EMPTY;
	p_SourceVersion = DT_EMPTY;
	p_Destination = DT_EMPTY;
	set_Source(n_Source);
}
XplLanguage::XplLanguage(string n_Source, string n_StandardDefinitionFile, string n_SourceVersion, string n_Destination){
	set_Source(n_Source);
	set_StandardDefinitionFile(n_StandardDefinitionFile);
	set_SourceVersion(n_SourceVersion);
	set_Destination(n_Destination);
}
//Destructor
XplLanguage::~XplLanguage(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplLanguage'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* XplLanguage::Clone(){
	XplLanguage* copy = new XplLanguage();
	copy->set_Source(this->p_Source);
	copy->set_StandardDefinitionFile(this->p_StandardDefinitionFile);
	copy->set_SourceVersion(this->p_SourceVersion);
	copy->set_Destination(this->p_Destination);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplLanguage::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_Source != DT_EMPTY)
		writer->write(DT(" Source=\"")+CODEDOM_Att_ToString(p_Source)+DT("\""));
	if(p_StandardDefinitionFile != DT_EMPTY)
		writer->write(DT(" StandardDefinitionFile=\"")+CODEDOM_Att_ToString(p_StandardDefinitionFile)+DT("\""));
	if(p_SourceVersion != DT_EMPTY)
		writer->write(DT(" SourceVersion=\"")+CODEDOM_Att_ToString(p_SourceVersion)+DT("\""));
	if(p_Destination != DT_EMPTY)
		writer->write(DT(" Destination=\"")+CODEDOM_Att_ToString(p_Destination)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplLanguage::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplLanguage::get_Source(){
	return p_Source;
}
string XplLanguage::get_StandardDefinitionFile(){
	return p_StandardDefinitionFile;
}
string XplLanguage::get_SourceVersion(){
	return p_SourceVersion;
}
string XplLanguage::get_Destination(){
	return p_Destination;
}

//Funciones para setear Atributos
string XplLanguage::set_Source(string new_Source){
	string back_Source = p_Source;
	p_Source = new_Source;
	return back_Source;
}
string XplLanguage::set_StandardDefinitionFile(string new_StandardDefinitionFile){
	string back_StandardDefinitionFile = p_StandardDefinitionFile;
	p_StandardDefinitionFile = new_StandardDefinitionFile;
	return back_StandardDefinitionFile;
}
string XplLanguage::set_SourceVersion(string new_SourceVersion){
	string back_SourceVersion = p_SourceVersion;
	p_SourceVersion = new_SourceVersion;
	return back_SourceVersion;
}
string XplLanguage::set_Destination(string new_Destination){
	string back_Destination = p_Destination;
	p_Destination = new_Destination;
	return back_Destination;
}

}

#endif
