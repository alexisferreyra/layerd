/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOECATCHINIT_V1_0_CPP
#define __LAYERD_CODEDOM_ZOECATCHINIT_V1_0_CPP
#include "CDOM_XplCatchinit.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplCatchinit::XplCatchinit(){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_tcatchinit=NULL;
}
XplCatchinit::XplCatchinit(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_tcatchinit=NULL;
}
XplCatchinit::XplCatchinit(XplNode* n_tcatchinit){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_tcatchinit=NULL;
	set_tcatchinit(n_tcatchinit);
}
XplCatchinit::XplCatchinit(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNode* n_tcatchinit){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_tcatchinit=NULL;
	set_tcatchinit(n_tcatchinit);
}
//Destructor
XplCatchinit::~XplCatchinit(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplCatchinit'");
#endif

	//Variables para Elementos de Choice
	if(p_tcatchinit!=NULL)delete p_tcatchinit;
}

//Funciones Sobreescritas de XplNode
XplNode* XplCatchinit::Clone(){
	XplCatchinit* copy = new XplCatchinit();
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);

	//Variables para Elementos de Choice
	if(p_tcatchinit!=NULL)copy->set_tcatchinit(p_tcatchinit->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplCatchinit::Write(XplWriter* writer){
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
	if(p_tcatchinit!=NULL)if(!p_tcatchinit->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplCatchinit::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplCatchinit::get_doc(){
	return p_doc;
}
string XplCatchinit::get_helpURL(){
	return p_helpURL;
}
string XplCatchinit::get_ldsrc(){
	return p_ldsrc;
}
bool XplCatchinit::get_iny(){
	return p_iny;
}
string XplCatchinit::get_inydata(){
	return p_inydata;
}
string XplCatchinit::get_inyby(){
	return p_inyby;
}
string XplCatchinit::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Choice
XplNode* XplCatchinit::get_tcatchinit(){
	return p_tcatchinit;
}

//Funciones para setear Atributos
string XplCatchinit::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplCatchinit::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplCatchinit::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplCatchinit::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplCatchinit::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplCatchinit::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplCatchinit::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Choice
XplNode* XplCatchinit::set_tcatchinit(XplNode* new_tcatchinit){
	if(new_tcatchinit==NULL)return p_tcatchinit;
	XplNode* back_tcatchinit = p_tcatchinit;
	if(new_tcatchinit->get_ElementName()==DT("d")){
		if(new_tcatchinit->get_ContentTypeName()!=CODEDOMTYPES_ZOEDECLARATOR){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tcatchinit->get_ContentTypeNameString()+DT("' no es valido como componente de 'tcatchinit'."));
			return NULL;
		}
		p_tcatchinit = new_tcatchinit;
		p_tcatchinit->set_Parent(this);
		return back_tcatchinit;
	}
	if(new_tcatchinit->get_ElementName()==DT("e")){
		if(new_tcatchinit->get_ContentTypeName()!=CODEDOMTYPES_ZOEEXPRESSION){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tcatchinit->get_ContentTypeNameString()+DT("' no es valido como componente de 'tcatchinit'."));
			return NULL;
		}
		p_tcatchinit = new_tcatchinit;
		p_tcatchinit->set_Parent(this);
		return back_tcatchinit;
	}
	this->set_ErrorString(DT("El elemento de nombre '")+new_tcatchinit->get_ElementName()+DT("' no es valido como componente de 'tcatchinit'."));
	return NULL;
}
XplDeclarator* XplCatchinit::new_d(){
	XplDeclarator* node = new XplDeclarator();
	node->set_ElementName(DT("d"));
	return node;
}
XplExpression* XplCatchinit::new_e(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("e"));
	return node;
}

}

#endif
