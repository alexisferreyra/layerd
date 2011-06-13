/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEIMPORTPROCESSCONFIG_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEIMPORTPROCESSCONFIG_V1_0_CPP
#include "CDOM_XplImportProcessConfig.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplImportProcessConfig::XplImportProcessConfig(){
	p_OutputFolder = DT_EMPTY;
	p_OutputPrefix = DT_EMPTY;
	p_ErrorsFileName = DT_EMPTY;
}
XplImportProcessConfig::XplImportProcessConfig(string n_OutputFolder, string n_ErrorsFileName){
	p_OutputFolder = DT_EMPTY;
	p_OutputPrefix = DT_EMPTY;
	p_ErrorsFileName = DT_EMPTY;
	set_OutputFolder(n_OutputFolder);
	set_ErrorsFileName(n_ErrorsFileName);
}
XplImportProcessConfig::XplImportProcessConfig(string n_OutputFolder, string n_OutputPrefix, string n_ErrorsFileName){
	set_OutputFolder(n_OutputFolder);
	set_OutputPrefix(n_OutputPrefix);
	set_ErrorsFileName(n_ErrorsFileName);
}
//Destructor
XplImportProcessConfig::~XplImportProcessConfig(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplImportProcessConfig'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* XplImportProcessConfig::Clone(){
	XplImportProcessConfig* copy = new XplImportProcessConfig();
	copy->set_OutputFolder(this->p_OutputFolder);
	copy->set_OutputPrefix(this->p_OutputPrefix);
	copy->set_ErrorsFileName(this->p_ErrorsFileName);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplImportProcessConfig::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_OutputFolder != DT_EMPTY)
		writer->write(DT(" OutputFolder=\"")+CODEDOM_Att_ToString(p_OutputFolder)+DT("\""));
	if(p_OutputPrefix != DT_EMPTY)
		writer->write(DT(" OutputPrefix=\"")+CODEDOM_Att_ToString(p_OutputPrefix)+DT("\""));
	if(p_ErrorsFileName != DT_EMPTY)
		writer->write(DT(" ErrorsFileName=\"")+CODEDOM_Att_ToString(p_ErrorsFileName)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplImportProcessConfig::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplImportProcessConfig::get_OutputFolder(){
	return p_OutputFolder;
}
string XplImportProcessConfig::get_OutputPrefix(){
	return p_OutputPrefix;
}
string XplImportProcessConfig::get_ErrorsFileName(){
	return p_ErrorsFileName;
}

//Funciones para setear Atributos
string XplImportProcessConfig::set_OutputFolder(string new_OutputFolder){
	string back_OutputFolder = p_OutputFolder;
	p_OutputFolder = new_OutputFolder;
	return back_OutputFolder;
}
string XplImportProcessConfig::set_OutputPrefix(string new_OutputPrefix){
	string back_OutputPrefix = p_OutputPrefix;
	p_OutputPrefix = new_OutputPrefix;
	return back_OutputPrefix;
}
string XplImportProcessConfig::set_ErrorsFileName(string new_ErrorsFileName){
	string back_ErrorsFileName = p_ErrorsFileName;
	p_ErrorsFileName = new_ErrorsFileName;
	return back_ErrorsFileName;
}

}

#endif
