/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOECOPYRIGHT_V1_0_CPP
#define __LAYERD_CODEDOM_ZOECOPYRIGHT_V1_0_CPP
#include "CDOM_XplCopyright.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplCopyright::XplCopyright(){
	p_copyrightMessage = DT_EMPTY;
	p_company = DT_EMPTY;
	p_productName = DT_EMPTY;
	p_productVersion = DT_EMPTY;
	p_productLicense = DT_EMPTY;
	p_description = DT_EMPTY;
	p_contactInfo = DT_EMPTY;
}
XplCopyright::XplCopyright(string n_copyrightMessage){
	p_copyrightMessage = DT_EMPTY;
	p_company = DT_EMPTY;
	p_productName = DT_EMPTY;
	p_productVersion = DT_EMPTY;
	p_productLicense = DT_EMPTY;
	p_description = DT_EMPTY;
	p_contactInfo = DT_EMPTY;
	set_copyrightMessage(n_copyrightMessage);
}
XplCopyright::XplCopyright(string n_copyrightMessage, string n_company, string n_productName, string n_productVersion, string n_productLicense, string n_description, string n_contactInfo){
	set_copyrightMessage(n_copyrightMessage);
	set_company(n_company);
	set_productName(n_productName);
	set_productVersion(n_productVersion);
	set_productLicense(n_productLicense);
	set_description(n_description);
	set_contactInfo(n_contactInfo);
}
//Destructor
XplCopyright::~XplCopyright(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplCopyright'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* XplCopyright::Clone(){
	XplCopyright* copy = new XplCopyright();
	copy->set_copyrightMessage(this->p_copyrightMessage);
	copy->set_company(this->p_company);
	copy->set_productName(this->p_productName);
	copy->set_productVersion(this->p_productVersion);
	copy->set_productLicense(this->p_productLicense);
	copy->set_description(this->p_description);
	copy->set_contactInfo(this->p_contactInfo);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplCopyright::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_copyrightMessage != DT_EMPTY)
		writer->write(DT(" copyrightMessage=\"")+CODEDOM_Att_ToString(p_copyrightMessage)+DT("\""));
	if(p_company != DT_EMPTY)
		writer->write(DT(" company=\"")+CODEDOM_Att_ToString(p_company)+DT("\""));
	if(p_productName != DT_EMPTY)
		writer->write(DT(" productName=\"")+CODEDOM_Att_ToString(p_productName)+DT("\""));
	if(p_productVersion != DT_EMPTY)
		writer->write(DT(" productVersion=\"")+CODEDOM_Att_ToString(p_productVersion)+DT("\""));
	if(p_productLicense != DT_EMPTY)
		writer->write(DT(" productLicense=\"")+CODEDOM_Att_ToString(p_productLicense)+DT("\""));
	if(p_description != DT_EMPTY)
		writer->write(DT(" description=\"")+CODEDOM_Att_ToString(p_description)+DT("\""));
	if(p_contactInfo != DT_EMPTY)
		writer->write(DT(" contactInfo=\"")+CODEDOM_Att_ToString(p_contactInfo)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplCopyright::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplCopyright::get_copyrightMessage(){
	return p_copyrightMessage;
}
string XplCopyright::get_company(){
	return p_company;
}
string XplCopyright::get_productName(){
	return p_productName;
}
string XplCopyright::get_productVersion(){
	return p_productVersion;
}
string XplCopyright::get_productLicense(){
	return p_productLicense;
}
string XplCopyright::get_description(){
	return p_description;
}
string XplCopyright::get_contactInfo(){
	return p_contactInfo;
}

//Funciones para setear Atributos
string XplCopyright::set_copyrightMessage(string new_copyrightMessage){
	string back_copyrightMessage = p_copyrightMessage;
	p_copyrightMessage = new_copyrightMessage;
	return back_copyrightMessage;
}
string XplCopyright::set_company(string new_company){
	string back_company = p_company;
	p_company = new_company;
	return back_company;
}
string XplCopyright::set_productName(string new_productName){
	string back_productName = p_productName;
	p_productName = new_productName;
	return back_productName;
}
string XplCopyright::set_productVersion(string new_productVersion){
	string back_productVersion = p_productVersion;
	p_productVersion = new_productVersion;
	return back_productVersion;
}
string XplCopyright::set_productLicense(string new_productLicense){
	string back_productLicense = p_productLicense;
	p_productLicense = new_productLicense;
	return back_productLicense;
}
string XplCopyright::set_description(string new_description){
	string back_description = p_description;
	p_description = new_description;
	return back_description;
}
string XplCopyright::set_contactInfo(string new_contactInfo){
	string back_contactInfo = p_contactInfo;
	p_contactInfo = new_contactInfo;
	return back_contactInfo;
}

}

#endif
