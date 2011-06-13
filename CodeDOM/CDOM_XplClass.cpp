/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOECLASS_V1_0_CPP
#define __LAYERD_CODEDOM_ZOECLASS_V1_0_CPP
#include "CDOM_XplClass.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplClass::XplClass(){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_isstruct = false;
	p_isinterface = false;
	p_isunion = false;
	p_isenum = false;
	p_isfactory = false;
	p_isinteractive = false;
	p_abstract = false;
	p_extension = false;
	p_external = false;
	p_donotrender = false;
	p_final = false;
	p_new = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_alignment = 0;
	p_bitorder = ZOEBITORDER_ENUM_IGNORE;
	p_byteorder = ZOEBITORDER_ENUM_IGNORE;
	p_sizeinbits = 0;
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tClass);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tClass);
}
XplClass::XplClass(string n_name, XplAccesstype_enum n_access, bool n_isstruct, bool n_isinterface, bool n_isunion, bool n_isenum, bool n_isfactory, bool n_isinteractive, bool n_abstract, bool n_extension, bool n_external, bool n_donotrender, bool n_final, bool n_new, XplBitorder_enum n_bitorder, XplBitorder_enum n_byteorder){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_isstruct = false;
	p_isinterface = false;
	p_isunion = false;
	p_isenum = false;
	p_isfactory = false;
	p_isinteractive = false;
	p_abstract = false;
	p_extension = false;
	p_external = false;
	p_donotrender = false;
	p_final = false;
	p_new = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_alignment = 0;
	p_bitorder = ZOEBITORDER_ENUM_IGNORE;
	p_byteorder = ZOEBITORDER_ENUM_IGNORE;
	p_sizeinbits = 0;
	set_name(n_name);
	set_access(n_access);
	set_isstruct(n_isstruct);
	set_isinterface(n_isinterface);
	set_isunion(n_isunion);
	set_isenum(n_isenum);
	set_isfactory(n_isfactory);
	set_isinteractive(n_isinteractive);
	set_abstract(n_abstract);
	set_extension(n_extension);
	set_external(n_external);
	set_donotrender(n_donotrender);
	set_final(n_final);
	set_new(n_new);
	set_bitorder(n_bitorder);
	set_byteorder(n_byteorder);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tClass);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tClass);
}
XplClass::XplClass(string n_name, string n_internalname, string n_externalname, XplAccesstype_enum n_access, bool n_isstruct, bool n_isinterface, bool n_isunion, bool n_isenum, bool n_isfactory, bool n_isinteractive, bool n_abstract, bool n_extension, bool n_external, bool n_donotrender, bool n_final, bool n_new, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, unsigned n_alignment, XplBitorder_enum n_bitorder, XplBitorder_enum n_byteorder, unsigned n_sizeinbits){
	set_name(n_name);
	set_internalname(n_internalname);
	set_externalname(n_externalname);
	set_access(n_access);
	set_isstruct(n_isstruct);
	set_isinterface(n_isinterface);
	set_isunion(n_isunion);
	set_isenum(n_isenum);
	set_isfactory(n_isfactory);
	set_isinteractive(n_isinteractive);
	set_abstract(n_abstract);
	set_extension(n_extension);
	set_external(n_external);
	set_donotrender(n_donotrender);
	set_final(n_final);
	set_new(n_new);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_alignment(n_alignment);
	set_bitorder(n_bitorder);
	set_byteorder(n_byteorder);
	set_sizeinbits(n_sizeinbits);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tClass);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tClass);
}
XplClass::XplClass(XplNodeList* n_Childs){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_isstruct = false;
	p_isinterface = false;
	p_isunion = false;
	p_isenum = false;
	p_isfactory = false;
	p_isinteractive = false;
	p_abstract = false;
	p_extension = false;
	p_external = false;
	p_donotrender = false;
	p_final = false;
	p_new = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_alignment = 0;
	p_bitorder = ZOEBITORDER_ENUM_IGNORE;
	p_byteorder = ZOEBITORDER_ENUM_IGNORE;
	p_sizeinbits = 0;
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tClass);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tClass);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_Childs!=NULL)
	for(XplNode* node = n_Childs->FirstNode(); node != n_Childs->GetLastNode() ; node = n_Childs->NextNode()){
		p_Childs->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplClass::XplClass(string n_name, XplAccesstype_enum n_access, bool n_isstruct, bool n_isinterface, bool n_isunion, bool n_isenum, bool n_isfactory, bool n_isinteractive, bool n_abstract, bool n_extension, bool n_external, bool n_donotrender, bool n_final, bool n_new, XplBitorder_enum n_bitorder, XplBitorder_enum n_byteorder, XplNodeList* n_Childs){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_access = ZOEACCESSTYPE_ENUM_PRIVATE;
	p_isstruct = false;
	p_isinterface = false;
	p_isunion = false;
	p_isenum = false;
	p_isfactory = false;
	p_isinteractive = false;
	p_abstract = false;
	p_extension = false;
	p_external = false;
	p_donotrender = false;
	p_final = false;
	p_new = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_alignment = 0;
	p_bitorder = ZOEBITORDER_ENUM_IGNORE;
	p_byteorder = ZOEBITORDER_ENUM_IGNORE;
	p_sizeinbits = 0;
	set_name(n_name);
	set_access(n_access);
	set_isstruct(n_isstruct);
	set_isinterface(n_isinterface);
	set_isunion(n_isunion);
	set_isenum(n_isenum);
	set_isfactory(n_isfactory);
	set_isinteractive(n_isinteractive);
	set_abstract(n_abstract);
	set_extension(n_extension);
	set_external(n_external);
	set_donotrender(n_donotrender);
	set_final(n_final);
	set_new(n_new);
	set_bitorder(n_bitorder);
	set_byteorder(n_byteorder);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tClass);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tClass);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_Childs!=NULL)
	for(XplNode* node = n_Childs->FirstNode(); node != n_Childs->GetLastNode() ; node = n_Childs->NextNode()){
		p_Childs->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplClass::XplClass(string n_name, string n_internalname, string n_externalname, XplAccesstype_enum n_access, bool n_isstruct, bool n_isinterface, bool n_isunion, bool n_isenum, bool n_isfactory, bool n_isinteractive, bool n_abstract, bool n_extension, bool n_external, bool n_donotrender, bool n_final, bool n_new, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, unsigned n_alignment, XplBitorder_enum n_bitorder, XplBitorder_enum n_byteorder, unsigned n_sizeinbits, XplNodeList* n_Childs){
	set_name(n_name);
	set_internalname(n_internalname);
	set_externalname(n_externalname);
	set_access(n_access);
	set_isstruct(n_isstruct);
	set_isinterface(n_isinterface);
	set_isunion(n_isunion);
	set_isenum(n_isenum);
	set_isfactory(n_isfactory);
	set_isinteractive(n_isinteractive);
	set_abstract(n_abstract);
	set_extension(n_extension);
	set_external(n_external);
	set_donotrender(n_donotrender);
	set_final(n_final);
	set_new(n_new);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_alignment(n_alignment);
	set_bitorder(n_bitorder);
	set_byteorder(n_byteorder);
	set_sizeinbits(n_sizeinbits);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tClass);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tClass);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_Childs!=NULL)
	for(XplNode* node = n_Childs->FirstNode(); node != n_Childs->GetLastNode() ; node = n_Childs->NextNode()){
		p_Childs->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
//Destructor
XplClass::~XplClass(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplClass'");
#endif
	//Variables para Elementos de Secuencia
	if(p_Childs!=NULL)delete p_Childs;
}

//Funciones Sobreescritas de XplNode
XplNode* XplClass::Clone(){
	XplClass* copy = new XplClass();
	copy->set_name(this->p_name);
	copy->set_internalname(this->p_internalname);
	copy->set_externalname(this->p_externalname);
	copy->set_access(this->p_access);
	copy->set_isstruct(this->p_isstruct);
	copy->set_isinterface(this->p_isinterface);
	copy->set_isunion(this->p_isunion);
	copy->set_isenum(this->p_isenum);
	copy->set_isfactory(this->p_isfactory);
	copy->set_isinteractive(this->p_isinteractive);
	copy->set_abstract(this->p_abstract);
	copy->set_extension(this->p_extension);
	copy->set_external(this->p_external);
	copy->set_donotrender(this->p_donotrender);
	copy->set_final(this->p_final);
	copy->set_new(this->p_new);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	copy->set_alignment(this->p_alignment);
	copy->set_bitorder(this->p_bitorder);
	copy->set_byteorder(this->p_byteorder);
	copy->set_sizeinbits(this->p_sizeinbits);
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		copy->Childs()->InsertAtEnd(node->Clone());
	}
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplClass::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_name != DT_EMPTY)
		writer->write(DT(" name=\"")+CODEDOM_Att_ToString(p_name)+DT("\""));
	if(p_internalname != DT_EMPTY)
		writer->write(DT(" internalname=\"")+CODEDOM_Att_ToString(p_internalname)+DT("\""));
	if(p_externalname != DT_EMPTY)
		writer->write(DT(" externalname=\"")+CODEDOM_Att_ToString(p_externalname)+DT("\""));
	if(p_access != ZOEACCESSTYPE_ENUM_PRIVATE)
		writer->write(DT(" access=\"")+(string)__CODEDOM_ZOEACCESSTYPE_ENUM[p_access]+DT("\""));
	if(p_isstruct != false)
		writer->write(DT(" isstruct=\"")+CODEDOM_Att_ToString(p_isstruct)+DT("\""));
	if(p_isinterface != false)
		writer->write(DT(" isinterface=\"")+CODEDOM_Att_ToString(p_isinterface)+DT("\""));
	if(p_isunion != false)
		writer->write(DT(" isunion=\"")+CODEDOM_Att_ToString(p_isunion)+DT("\""));
	if(p_isenum != false)
		writer->write(DT(" isenum=\"")+CODEDOM_Att_ToString(p_isenum)+DT("\""));
	if(p_isfactory != false)
		writer->write(DT(" isfactory=\"")+CODEDOM_Att_ToString(p_isfactory)+DT("\""));
	if(p_isinteractive != false)
		writer->write(DT(" isinteractive=\"")+CODEDOM_Att_ToString(p_isinteractive)+DT("\""));
	if(p_abstract != false)
		writer->write(DT(" abstract=\"")+CODEDOM_Att_ToString(p_abstract)+DT("\""));
	if(p_extension != false)
		writer->write(DT(" extension=\"")+CODEDOM_Att_ToString(p_extension)+DT("\""));
	if(p_external != false)
		writer->write(DT(" external=\"")+CODEDOM_Att_ToString(p_external)+DT("\""));
	if(p_donotrender != false)
		writer->write(DT(" donotrender=\"")+CODEDOM_Att_ToString(p_donotrender)+DT("\""));
	if(p_final != false)
		writer->write(DT(" final=\"")+CODEDOM_Att_ToString(p_final)+DT("\""));
	if(p_new != false)
		writer->write(DT(" new=\"")+CODEDOM_Att_ToString(p_new)+DT("\""));
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
	if(p_alignment != 0)
		writer->write(DT(" alignment=\"")+CODEDOM_Att_ToString(p_alignment)+DT("\""));
	if(p_bitorder != ZOEBITORDER_ENUM_IGNORE)
		writer->write(DT(" bitorder=\"")+(string)__CODEDOM_ZOEBITORDER_ENUM[p_bitorder]+DT("\""));
	if(p_byteorder != ZOEBITORDER_ENUM_IGNORE)
		writer->write(DT(" byteorder=\"")+(string)__CODEDOM_ZOEBITORDER_ENUM[p_byteorder]+DT("\""));
	if(p_sizeinbits != 0)
		writer->write(DT(" sizeinbits=\"")+CODEDOM_Att_ToString(p_sizeinbits)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_Childs!=NULL)if(!p_Childs->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplClass::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplClass::get_name(){
	return p_name;
}
string XplClass::get_internalname(){
	return p_internalname;
}
string XplClass::get_externalname(){
	return p_externalname;
}
XplAccesstype_enum XplClass::get_access(){
	return p_access;
}
bool XplClass::get_isstruct(){
	return p_isstruct;
}
bool XplClass::get_isinterface(){
	return p_isinterface;
}
bool XplClass::get_isunion(){
	return p_isunion;
}
bool XplClass::get_isenum(){
	return p_isenum;
}
bool XplClass::get_isfactory(){
	return p_isfactory;
}
bool XplClass::get_isinteractive(){
	return p_isinteractive;
}
bool XplClass::get_abstract(){
	return p_abstract;
}
bool XplClass::get_extension(){
	return p_extension;
}
bool XplClass::get_external(){
	return p_external;
}
bool XplClass::get_donotrender(){
	return p_donotrender;
}
bool XplClass::get_final(){
	return p_final;
}
bool XplClass::get_new(){
	return p_new;
}
string XplClass::get_doc(){
	return p_doc;
}
string XplClass::get_helpURL(){
	return p_helpURL;
}
string XplClass::get_ldsrc(){
	return p_ldsrc;
}
bool XplClass::get_iny(){
	return p_iny;
}
string XplClass::get_inydata(){
	return p_inydata;
}
string XplClass::get_inyby(){
	return p_inyby;
}
string XplClass::get_lddata(){
	return p_lddata;
}
unsigned XplClass::get_alignment(){
	return p_alignment;
}
XplBitorder_enum XplClass::get_bitorder(){
	return p_bitorder;
}
XplBitorder_enum XplClass::get_byteorder(){
	return p_byteorder;
}
unsigned XplClass::get_sizeinbits(){
	return p_sizeinbits;
}

//Funciones para obtener Elementos de Secuencia
XplNodeList* XplClass::Childs(){
	return p_Childs;
}

//Funciones para setear Atributos
string XplClass::set_name(string new_name){
	string back_name = p_name;
	p_name = new_name;
	return back_name;
}
string XplClass::set_internalname(string new_internalname){
	string back_internalname = p_internalname;
	p_internalname = new_internalname;
	return back_internalname;
}
string XplClass::set_externalname(string new_externalname){
	string back_externalname = p_externalname;
	p_externalname = new_externalname;
	return back_externalname;
}
XplAccesstype_enum XplClass::set_access(XplAccesstype_enum new_access){
	XplAccesstype_enum back_access = p_access;
	p_access = new_access;
	return back_access;
}
bool XplClass::set_isstruct(bool new_isstruct){
	bool back_isstruct = p_isstruct;
	p_isstruct = new_isstruct;
	return back_isstruct;
}
bool XplClass::set_isinterface(bool new_isinterface){
	bool back_isinterface = p_isinterface;
	p_isinterface = new_isinterface;
	return back_isinterface;
}
bool XplClass::set_isunion(bool new_isunion){
	bool back_isunion = p_isunion;
	p_isunion = new_isunion;
	return back_isunion;
}
bool XplClass::set_isenum(bool new_isenum){
	bool back_isenum = p_isenum;
	p_isenum = new_isenum;
	return back_isenum;
}
bool XplClass::set_isfactory(bool new_isfactory){
	bool back_isfactory = p_isfactory;
	p_isfactory = new_isfactory;
	return back_isfactory;
}
bool XplClass::set_isinteractive(bool new_isinteractive){
	bool back_isinteractive = p_isinteractive;
	p_isinteractive = new_isinteractive;
	return back_isinteractive;
}
bool XplClass::set_abstract(bool new_abstract){
	bool back_abstract = p_abstract;
	p_abstract = new_abstract;
	return back_abstract;
}
bool XplClass::set_extension(bool new_extension){
	bool back_extension = p_extension;
	p_extension = new_extension;
	return back_extension;
}
bool XplClass::set_external(bool new_external){
	bool back_external = p_external;
	p_external = new_external;
	return back_external;
}
bool XplClass::set_donotrender(bool new_donotrender){
	bool back_donotrender = p_donotrender;
	p_donotrender = new_donotrender;
	return back_donotrender;
}
bool XplClass::set_final(bool new_final){
	bool back_final = p_final;
	p_final = new_final;
	return back_final;
}
bool XplClass::set_new(bool new_new){
	bool back_new = p_new;
	p_new = new_new;
	return back_new;
}
string XplClass::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplClass::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplClass::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplClass::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplClass::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplClass::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplClass::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}
unsigned XplClass::set_alignment(unsigned new_alignment){
	unsigned back_alignment = p_alignment;
	p_alignment = new_alignment;
	return back_alignment;
}
XplBitorder_enum XplClass::set_bitorder(XplBitorder_enum new_bitorder){
	XplBitorder_enum back_bitorder = p_bitorder;
	p_bitorder = new_bitorder;
	return back_bitorder;
}
XplBitorder_enum XplClass::set_byteorder(XplBitorder_enum new_byteorder){
	XplBitorder_enum back_byteorder = p_byteorder;
	p_byteorder = new_byteorder;
	return back_byteorder;
}
unsigned XplClass::set_sizeinbits(unsigned new_sizeinbits){
	unsigned back_sizeinbits = p_sizeinbits;
	p_sizeinbits = new_sizeinbits;
	return back_sizeinbits;
}

//Funciones para setear Elementos de Secuencia
	bool XplClass::acceptInsertNodeCallback_tClass(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("Inherits")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEINHERITS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClass'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Implements")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEINHERITS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClass'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Function")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFUNCTION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClass'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Operator")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFUNCTION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClass'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Indexer")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFUNCTION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClass'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Property")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEPROPERTY){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClass'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Field")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFIELD){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClass'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("e")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEEXPRESSION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClass'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Class")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOECLASS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClass'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("documentation")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEDOCUMENTATION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClass'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("BeginCFPermissions")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOECLASSFACTORYSPERMISSIONS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClass'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("EndCFPermissions")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOENODE){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClass'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("SetPlatforms")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOESETPLATFORMS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClass'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("AutoInstance")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEAUTOINSTANCE){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClass'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplClass'."));
		return false;
	}
	bool XplClass::acceptRemoveNodeCallback_tClass(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}

//Funciones para filtrado en Listas de Nodos
XplNodeList* XplClass::get_InheritsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Inherits")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClass::get_ImplementsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Implements")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClass::get_FunctionNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Function")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClass::get_OperatorNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Operator")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClass::get_IndexerNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Indexer")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClass::get_PropertyNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Property")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClass::get_FieldNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Field")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClass::get_eNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("e")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClass::get_ClassNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Class")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClass::get_documentationNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("documentation")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClass::get_BeginCFPermissionsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("BeginCFPermissions")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClass::get_EndCFPermissionsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("EndCFPermissions")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClass::get_SetPlatformsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("SetPlatforms")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClass::get_AutoInstanceNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("AutoInstance")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplInherits* XplClass::new_Inherits(){
	XplInherits* node = new XplInherits();
	node->set_ElementName(DT("Inherits"));
	return node;
}
XplInherits* XplClass::new_Implements(){
	XplInherits* node = new XplInherits();
	node->set_ElementName(DT("Implements"));
	return node;
}
XplFunction* XplClass::new_Function(){
	XplFunction* node = new XplFunction();
	node->set_ElementName(DT("Function"));
	return node;
}
XplFunction* XplClass::new_Operator(){
	XplFunction* node = new XplFunction();
	node->set_ElementName(DT("Operator"));
	return node;
}
XplFunction* XplClass::new_Indexer(){
	XplFunction* node = new XplFunction();
	node->set_ElementName(DT("Indexer"));
	return node;
}
XplProperty* XplClass::new_Property(){
	XplProperty* node = new XplProperty();
	node->set_ElementName(DT("Property"));
	return node;
}
XplField* XplClass::new_Field(){
	XplField* node = new XplField();
	node->set_ElementName(DT("Field"));
	return node;
}
XplExpression* XplClass::new_e(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("e"));
	return node;
}
XplClass* XplClass::new_Class(){
	XplClass* node = new XplClass();
	node->set_ElementName(DT("Class"));
	return node;
}
XplDocumentation* XplClass::new_documentation(){
	XplDocumentation* node = new XplDocumentation();
	node->set_ElementName(DT("documentation"));
	return node;
}
XplClassfactorysPermissions* XplClass::new_BeginCFPermissions(){
	XplClassfactorysPermissions* node = new XplClassfactorysPermissions();
	node->set_ElementName(DT("BeginCFPermissions"));
	return node;
}
XplNode* XplClass::new_EndCFPermissions(){
	XplNode* node = new XplNode(ZOENODETYPE_EMPTY);
	node->set_ElementName(DT("EndCFPermissions"));
	return node;
}
XplSetPlatforms* XplClass::new_SetPlatforms(){
	XplSetPlatforms* node = new XplSetPlatforms();
	node->set_ElementName(DT("SetPlatforms"));
	return node;
}
XplAutoInstance* XplClass::new_AutoInstance(){
	XplAutoInstance* node = new XplAutoInstance();
	node->set_ElementName(DT("AutoInstance"));
	return node;
}

}

#endif
