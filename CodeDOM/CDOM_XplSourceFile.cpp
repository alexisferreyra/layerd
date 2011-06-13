/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOESOURCEFILE_V1_0_CPP
#define __LAYERD_CODEDOM_ZOESOURCEFILE_V1_0_CPP
#include "CDOM_XplSourceFile.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplSourceFile::XplSourceFile(){
	p_fileName = DT_EMPTY;
}
XplSourceFile::XplSourceFile(string n_fileName){
	p_fileName = DT_EMPTY;
	set_fileName(n_fileName);
}
//Destructor
XplSourceFile::~XplSourceFile(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplSourceFile'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* XplSourceFile::Clone(){
	XplSourceFile* copy = new XplSourceFile();
	copy->set_fileName(this->p_fileName);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplSourceFile::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_fileName != DT_EMPTY)
		writer->write(DT(" fileName=\"")+CODEDOM_Att_ToString(p_fileName)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplSourceFile::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplSourceFile::get_fileName(){
	return p_fileName;
}

//Funciones para setear Atributos
string XplSourceFile::set_fileName(string new_fileName){
	string back_fileName = p_fileName;
	p_fileName = new_fileName;
	return back_fileName;
}

}

#endif
