/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEDIRECTOUTPUT_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEDIRECTOUTPUT_V1_0_CPP
#include "CDOM_XplDirectoutput.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplDirectoutput::XplDirectoutput(){
	p_TargetPlatform = DT_EMPTY;
	p_TargetPlatformDetail = DT_EMPTY;
	p_output = DT_EMPTY;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
}
XplDirectoutput::XplDirectoutput(string n_TargetPlatform, string n_TargetPlatformDetail, string n_output){
	p_TargetPlatform = DT_EMPTY;
	p_TargetPlatformDetail = DT_EMPTY;
	p_output = DT_EMPTY;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_TargetPlatform(n_TargetPlatform);
	set_TargetPlatformDetail(n_TargetPlatformDetail);
	set_output(n_output);
}
XplDirectoutput::XplDirectoutput(string n_TargetPlatform, string n_TargetPlatformDetail, string n_output, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_TargetPlatform(n_TargetPlatform);
	set_TargetPlatformDetail(n_TargetPlatformDetail);
	set_output(n_output);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
}
//Destructor
XplDirectoutput::~XplDirectoutput(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplDirectoutput'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* XplDirectoutput::Clone(){
	XplDirectoutput* copy = new XplDirectoutput();
	copy->set_TargetPlatform(this->p_TargetPlatform);
	copy->set_TargetPlatformDetail(this->p_TargetPlatformDetail);
	copy->set_output(this->p_output);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplDirectoutput::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_TargetPlatform != DT_EMPTY)
		writer->write(DT(" TargetPlatform=\"")+CODEDOM_Att_ToString(p_TargetPlatform)+DT("\""));
	if(p_TargetPlatformDetail != DT_EMPTY)
		writer->write(DT(" TargetPlatformDetail=\"")+CODEDOM_Att_ToString(p_TargetPlatformDetail)+DT("\""));
	if(p_output != DT_EMPTY)
		writer->write(DT(" output=\"")+CODEDOM_Att_ToString(p_output)+DT("\""));
	if(p_doc != DT_EMPTY)
		writer->write(DT(" doc=\"")+CODEDOM_Att_ToString(p_doc)+DT("\""));
	if(p_helpURL != DT_EMPTY)
		writer->write(DT(" helpURL=\"")+CODEDOM_Att_ToString(p_helpURL)+DT("\""));
	if(p_ldsrc != DT_EMPTY)
		writer->write(DT(" ldsrc=\"")+CODEDOM_Att_ToString(p_ldsrc)+DT("\""));
	if(p_iny != false)
		writer->write(DT(" iny=\"")+CODEDOM_Att_ToString(p_iny)+DT("\""));
	if(p_inydata != DT_EMPTY)
		writer->write(DT(" inydata=\"")+CODEDOM_Att_ToString(p_inydata)+DT("\""));
	if(p_inyby != DT_EMPTY)
		writer->write(DT(" inyby=\"")+CODEDOM_Att_ToString(p_inyby)+DT("\""));
	if(p_lddata != DT_EMPTY)
		writer->write(DT(" lddata=\"")+CODEDOM_Att_ToString(p_lddata)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplDirectoutput::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplDirectoutput::get_TargetPlatform(){
	return p_TargetPlatform;
}
string XplDirectoutput::get_TargetPlatformDetail(){
	return p_TargetPlatformDetail;
}
string XplDirectoutput::get_output(){
	return p_output;
}
string XplDirectoutput::get_doc(){
	return p_doc;
}
string XplDirectoutput::get_helpURL(){
	return p_helpURL;
}
string XplDirectoutput::get_ldsrc(){
	return p_ldsrc;
}
bool XplDirectoutput::get_iny(){
	return p_iny;
}
string XplDirectoutput::get_inydata(){
	return p_inydata;
}
string XplDirectoutput::get_inyby(){
	return p_inyby;
}
string XplDirectoutput::get_lddata(){
	return p_lddata;
}

//Funciones para setear Atributos
string XplDirectoutput::set_TargetPlatform(string new_TargetPlatform){
	string back_TargetPlatform = p_TargetPlatform;
	p_TargetPlatform = new_TargetPlatform;
	return back_TargetPlatform;
}
string XplDirectoutput::set_TargetPlatformDetail(string new_TargetPlatformDetail){
	string back_TargetPlatformDetail = p_TargetPlatformDetail;
	p_TargetPlatformDetail = new_TargetPlatformDetail;
	return back_TargetPlatformDetail;
}
string XplDirectoutput::set_output(string new_output){
	string back_output = p_output;
	p_output = new_output;
	return back_output;
}
string XplDirectoutput::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplDirectoutput::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplDirectoutput::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplDirectoutput::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplDirectoutput::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplDirectoutput::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplDirectoutput::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

}

#endif
