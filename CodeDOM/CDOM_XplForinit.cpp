/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEFORINIT_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEFORINIT_V1_0_CPP
#include "CDOM_XplForinit.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplForinit::XplForinit(){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_tforinit=NULL;
}
XplForinit::XplForinit(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_tforinit=NULL;
}
XplForinit::XplForinit(XplNode* n_tforinit){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_tforinit=NULL;
	set_tforinit(n_tforinit);
}
XplForinit::XplForinit(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNode* n_tforinit){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_tforinit=NULL;
	set_tforinit(n_tforinit);
}
//Destructor
XplForinit::~XplForinit(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplForinit'");
#endif

	//Variables para Elementos de Choice
	if(p_tforinit!=NULL)delete p_tforinit;
}

//Funciones Sobreescritas de XplNode
XplNode* XplForinit::Clone(){
	XplForinit* copy = new XplForinit();
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);

	//Variables para Elementos de Choice
	if(p_tforinit!=NULL)copy->set_tforinit(p_tforinit->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplForinit::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
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
	if(p_tforinit!=NULL)if(!p_tforinit->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplForinit::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplForinit::get_doc(){
	return p_doc;
}
string XplForinit::get_helpURL(){
	return p_helpURL;
}
string XplForinit::get_ldsrc(){
	return p_ldsrc;
}
bool XplForinit::get_iny(){
	return p_iny;
}
string XplForinit::get_inydata(){
	return p_inydata;
}
string XplForinit::get_inyby(){
	return p_inyby;
}
string XplForinit::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Choice
XplNode* XplForinit::get_tforinit(){
	return p_tforinit;
}

//Funciones para setear Atributos
string XplForinit::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplForinit::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplForinit::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplForinit::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplForinit::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplForinit::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplForinit::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Choice
XplNode* XplForinit::set_tforinit(XplNode* new_tforinit){
	if(new_tforinit==NULL)return p_tforinit;
	XplNode* back_tforinit = p_tforinit;
	if(new_tforinit->get_ElementName()==DT("dl")){
		if(new_tforinit->get_ContentTypeName()!=CODEDOMTYPES_ZOEDECLARATORLIST){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tforinit->get_ContentTypeNameString()+DT("' no es valido como componente de 'tforinit'."));
			return NULL;
		}
		p_tforinit = new_tforinit;
		p_tforinit->set_Parent(this);
		return back_tforinit;
	}
	if(new_tforinit->get_ElementName()==DT("el")){
		if(new_tforinit->get_ContentTypeName()!=CODEDOMTYPES_ZOEEXPRESSIONLIST){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tforinit->get_ContentTypeNameString()+DT("' no es valido como componente de 'tforinit'."));
			return NULL;
		}
		p_tforinit = new_tforinit;
		p_tforinit->set_Parent(this);
		return back_tforinit;
	}
	this->set_ErrorString(DT("El elemento de nombre '")+new_tforinit->get_ElementName()+DT("' no es valido como componente de 'tforinit'."));
	return NULL;
}
XplDeclaratorlist* XplForinit::new_dl(){
	XplDeclaratorlist* node = new XplDeclaratorlist();
	node->set_ElementName(DT("dl"));
	return node;
}
XplExpressionlist* XplForinit::new_el(){
	XplExpressionlist* node = new XplExpressionlist();
	node->set_ElementName(DT("el"));
	return node;
}

}

#endif
