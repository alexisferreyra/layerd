/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOELAYERDCOMPILER_V1_0_CPP
#define __LAYERD_CODEDOM_ZOELAYERDCOMPILER_V1_0_CPP
#include "CDOM_XplLayerDCompiler.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplLayerDCompiler::XplLayerDCompiler(){
	p_name = DT_EMPTY;
	p_version = DT_EMPTY;
	p_companyName = DT_EMPTY;
	p_copyright = DT_EMPTY;
}
XplLayerDCompiler::XplLayerDCompiler(string n_name, string n_version){
	p_name = DT_EMPTY;
	p_version = DT_EMPTY;
	p_companyName = DT_EMPTY;
	p_copyright = DT_EMPTY;
	set_name(n_name);
	set_version(n_version);
}
XplLayerDCompiler::XplLayerDCompiler(string n_name, string n_version, string n_companyName, string n_copyright){
	set_name(n_name);
	set_version(n_version);
	set_companyName(n_companyName);
	set_copyright(n_copyright);
}
//Destructor
XplLayerDCompiler::~XplLayerDCompiler(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplLayerDCompiler'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* XplLayerDCompiler::Clone(){
	XplLayerDCompiler* copy = new XplLayerDCompiler();
	copy->set_name(this->p_name);
	copy->set_version(this->p_version);
	copy->set_companyName(this->p_companyName);
	copy->set_copyright(this->p_copyright);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplLayerDCompiler::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_name != DT_EMPTY)
		writer->write(DT(" name=\"")+CODEDOM_Att_ToString(p_name)+DT("\""));
	if(p_version != DT_EMPTY)
		writer->write(DT(" version=\"")+CODEDOM_Att_ToString(p_version)+DT("\""));
	if(p_companyName != DT_EMPTY)
		writer->write(DT(" companyName=\"")+CODEDOM_Att_ToString(p_companyName)+DT("\""));
	if(p_copyright != DT_EMPTY)
		writer->write(DT(" copyright=\"")+CODEDOM_Att_ToString(p_copyright)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplLayerDCompiler::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplLayerDCompiler::get_name(){
	return p_name;
}
string XplLayerDCompiler::get_version(){
	return p_version;
}
string XplLayerDCompiler::get_companyName(){
	return p_companyName;
}
string XplLayerDCompiler::get_copyright(){
	return p_copyright;
}

//Funciones para setear Atributos
string XplLayerDCompiler::set_name(string new_name){
	string back_name = p_name;
	p_name = new_name;
	return back_name;
}
string XplLayerDCompiler::set_version(string new_version){
	string back_version = p_version;
	p_version = new_version;
	return back_version;
}
string XplLayerDCompiler::set_companyName(string new_companyName){
	string back_companyName = p_companyName;
	p_companyName = new_companyName;
	return back_companyName;
}
string XplLayerDCompiler::set_copyright(string new_copyright){
	string back_copyright = p_copyright;
	p_copyright = new_copyright;
	return back_copyright;
}

}

#endif
