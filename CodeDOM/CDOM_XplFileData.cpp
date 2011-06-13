/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEFILEDATA_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEFILEDATA_V1_0_CPP
#include "CDOM_XplFileData.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplFileData::XplFileData(){
	p_Autor = DT_EMPTY;
	p_Date = DT_EMPTY;
	p_Time = DT_EMPTY;
	p_Description = DT_EMPTY;
}
XplFileData::XplFileData(string n_Autor, DateTime n_Date, DateTime n_Time, string n_Description){
	set_Autor(n_Autor);
	set_Date(n_Date);
	set_Time(n_Time);
	set_Description(n_Description);
}
//Destructor
XplFileData::~XplFileData(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplFileData'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* XplFileData::Clone(){
	XplFileData* copy = new XplFileData();
	copy->set_Autor(this->p_Autor);
	copy->set_Date(this->p_Date);
	copy->set_Time(this->p_Time);
	copy->set_Description(this->p_Description);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplFileData::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_Autor != DT_EMPTY)
		writer->write(DT(" Autor=\"")+CODEDOM_Att_ToString(p_Autor)+DT("\""));
	if(p_Date != DT_EMPTY)
		writer->write(DT(" Date=\"")+CODEDOM_Att_ToString(p_Date)+DT("\""));
	if(p_Time != DT_EMPTY)
		writer->write(DT(" Time=\"")+CODEDOM_Att_ToString(p_Time)+DT("\""));
	if(p_Description != DT_EMPTY)
		writer->write(DT(" Description=\"")+CODEDOM_Att_ToString(p_Description)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplFileData::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplFileData::get_Autor(){
	return p_Autor;
}
DateTime XplFileData::get_Date(){
	return p_Date;
}
DateTime XplFileData::get_Time(){
	return p_Time;
}
string XplFileData::get_Description(){
	return p_Description;
}

//Funciones para setear Atributos
string XplFileData::set_Autor(string new_Autor){
	string back_Autor = p_Autor;
	p_Autor = new_Autor;
	return back_Autor;
}
DateTime XplFileData::set_Date(DateTime new_Date){
	DateTime back_Date = p_Date;
	p_Date = new_Date;
	return back_Date;
}
DateTime XplFileData::set_Time(DateTime new_Time){
	DateTime back_Time = p_Time;
	p_Time = new_Time;
	return back_Time;
}
string XplFileData::set_Description(string new_Description){
	string back_Description = p_Description;
	p_Description = new_Description;
	return back_Description;
}

}

#endif
