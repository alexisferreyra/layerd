/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOETERNARYOPERATOR_V1_0_CPP
#define __LAYERD_CODEDOM_ZOETERNARYOPERATOR_V1_0_CPP
#include "CDOM_XplTernaryoperator.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplTernaryoperator::XplTernaryoperator(){
	p_op = (XplTernaryoperators_enum)0;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_o1=NULL;
	p_o2=NULL;
	p_o3=NULL;
}
XplTernaryoperator::XplTernaryoperator(XplTernaryoperators_enum n_op, bool n_ignoreforsubprogram){
	p_op = (XplTernaryoperators_enum)0;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_op(n_op);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	p_o1=NULL;
	p_o2=NULL;
	p_o3=NULL;
}
XplTernaryoperator::XplTernaryoperator(XplExpression* n_o1, XplExpression* n_o2, XplExpression* n_o3){
	p_op = (XplTernaryoperators_enum)0;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_o1=NULL;
	p_o2=NULL;
	p_o3=NULL;
	set_o1(n_o1);
	set_o2(n_o2);
	set_o3(n_o3);
}
XplTernaryoperator::XplTernaryoperator(XplTernaryoperators_enum n_op, bool n_ignoreforsubprogram, XplExpression* n_o1, XplExpression* n_o2, XplExpression* n_o3){
	p_op = (XplTernaryoperators_enum)0;
	p_targetClass = DT_EMPTY;
	p_targetMember = DT_EMPTY;
	p_targetClassExternalName = DT_EMPTY;
	p_targetMemberExternalName = DT_EMPTY;
	p_ignoreforsubprogram = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_op(n_op);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	p_o1=NULL;
	p_o2=NULL;
	p_o3=NULL;
	set_o1(n_o1);
	set_o2(n_o2);
	set_o3(n_o3);
}
XplTernaryoperator::XplTernaryoperator(XplTernaryoperators_enum n_op, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_op(n_op);
	set_targetClass(n_targetClass);
	set_targetMember(n_targetMember);
	set_targetClassExternalName(n_targetClassExternalName);
	set_targetMemberExternalName(n_targetMemberExternalName);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_o1=NULL;
	p_o2=NULL;
	p_o3=NULL;
}
XplTernaryoperator::XplTernaryoperator(XplTernaryoperators_enum n_op, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_o1, XplExpression* n_o2, XplExpression* n_o3){
	set_op(n_op);
	set_targetClass(n_targetClass);
	set_targetMember(n_targetMember);
	set_targetClassExternalName(n_targetClassExternalName);
	set_targetMemberExternalName(n_targetMemberExternalName);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_op(n_op);
	set_ignoreforsubprogram(n_ignoreforsubprogram);
	p_o1=NULL;
	p_o2=NULL;
	p_o3=NULL;
}
//Destructor
XplTernaryoperator::~XplTernaryoperator(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplTernaryoperator'");
#endif
	//Variables para Elementos de Secuencia
	if(p_o1!=NULL)delete p_o1;
	if(p_o2!=NULL)delete p_o2;
	if(p_o3!=NULL)delete p_o3;
}

//Funciones Sobreescritas de XplNode
XplNode* XplTernaryoperator::Clone(){
	XplTernaryoperator* copy = new XplTernaryoperator();
	copy->set_op(this->p_op);
	copy->set_targetClass(this->p_targetClass);
	copy->set_targetMember(this->p_targetMember);
	copy->set_targetClassExternalName(this->p_targetClassExternalName);
	copy->set_targetMemberExternalName(this->p_targetMemberExternalName);
	copy->set_ignoreforsubprogram(this->p_ignoreforsubprogram);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_o1!=NULL)copy->set_o1((XplExpression*)p_o1->Clone());
	if(p_o2!=NULL)copy->set_o2((XplExpression*)p_o2->Clone());
	if(p_o3!=NULL)copy->set_o3((XplExpression*)p_o3->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplTernaryoperator::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_op != (XplTernaryoperators_enum)0)
		writer->write(DT(" op=\"")+(string)__CODEDOM_ZOETERNARYOPERATORS_ENUM[p_op]+DT("\""));
	if(p_targetClass != DT_EMPTY)
		writer->write(DT(" targetClass=\"")+CODEDOM_Att_ToString(p_targetClass)+DT("\""));
	if(p_targetMember != DT_EMPTY)
		writer->write(DT(" targetMember=\"")+CODEDOM_Att_ToString(p_targetMember)+DT("\""));
	if(p_targetClassExternalName != DT_EMPTY)
		writer->write(DT(" targetClassExternalName=\"")+CODEDOM_Att_ToString(p_targetClassExternalName)+DT("\""));
	if(p_targetMemberExternalName != DT_EMPTY)
		writer->write(DT(" targetMemberExternalName=\"")+CODEDOM_Att_ToString(p_targetMemberExternalName)+DT("\""));
	if(p_ignoreforsubprogram != false)
		writer->write(DT(" ignoreforsubprogram=\"")+CODEDOM_Att_ToString(p_ignoreforsubprogram)+DT("\""));
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
	if(p_o1!=NULL)if(!p_o1->Write(writer))result=false;
	if(p_o2!=NULL)if(!p_o2->Write(writer))result=false;
	if(p_o3!=NULL)if(!p_o3->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplTernaryoperator::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
XplTernaryoperators_enum XplTernaryoperator::get_op(){
	return p_op;
}
string XplTernaryoperator::get_targetClass(){
	return p_targetClass;
}
string XplTernaryoperator::get_targetMember(){
	return p_targetMember;
}
string XplTernaryoperator::get_targetClassExternalName(){
	return p_targetClassExternalName;
}
string XplTernaryoperator::get_targetMemberExternalName(){
	return p_targetMemberExternalName;
}
bool XplTernaryoperator::get_ignoreforsubprogram(){
	return p_ignoreforsubprogram;
}
string XplTernaryoperator::get_doc(){
	return p_doc;
}
string XplTernaryoperator::get_helpURL(){
	return p_helpURL;
}
string XplTernaryoperator::get_ldsrc(){
	return p_ldsrc;
}
bool XplTernaryoperator::get_iny(){
	return p_iny;
}
string XplTernaryoperator::get_inydata(){
	return p_inydata;
}
string XplTernaryoperator::get_inyby(){
	return p_inyby;
}
string XplTernaryoperator::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplExpression* XplTernaryoperator::get_o1(){
	return p_o1;
}
XplExpression* XplTernaryoperator::get_o2(){
	return p_o2;
}
XplExpression* XplTernaryoperator::get_o3(){
	return p_o3;
}

//Funciones para setear Atributos
XplTernaryoperators_enum XplTernaryoperator::set_op(XplTernaryoperators_enum new_op){
	XplTernaryoperators_enum back_op = p_op;
	p_op = new_op;
	return back_op;
}
string XplTernaryoperator::set_targetClass(string new_targetClass){
	string back_targetClass = p_targetClass;
	p_targetClass = new_targetClass;
	return back_targetClass;
}
string XplTernaryoperator::set_targetMember(string new_targetMember){
	string back_targetMember = p_targetMember;
	p_targetMember = new_targetMember;
	return back_targetMember;
}
string XplTernaryoperator::set_targetClassExternalName(string new_targetClassExternalName){
	string back_targetClassExternalName = p_targetClassExternalName;
	p_targetClassExternalName = new_targetClassExternalName;
	return back_targetClassExternalName;
}
string XplTernaryoperator::set_targetMemberExternalName(string new_targetMemberExternalName){
	string back_targetMemberExternalName = p_targetMemberExternalName;
	p_targetMemberExternalName = new_targetMemberExternalName;
	return back_targetMemberExternalName;
}
bool XplTernaryoperator::set_ignoreforsubprogram(bool new_ignoreforsubprogram){
	bool back_ignoreforsubprogram = p_ignoreforsubprogram;
	p_ignoreforsubprogram = new_ignoreforsubprogram;
	return back_ignoreforsubprogram;
}
string XplTernaryoperator::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplTernaryoperator::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplTernaryoperator::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplTernaryoperator::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplTernaryoperator::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplTernaryoperator::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplTernaryoperator::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplExpression* XplTernaryoperator::set_o1(XplExpression* new_o1){
	XplExpression* back_o1 = p_o1;
	p_o1 = new_o1;
	if(p_o1!=NULL){
		p_o1->set_ElementName(DT("o1"));
		p_o1->set_Parent(this);
	}
	return back_o1;
}
XplExpression* XplTernaryoperator::set_o2(XplExpression* new_o2){
	XplExpression* back_o2 = p_o2;
	p_o2 = new_o2;
	if(p_o2!=NULL){
		p_o2->set_ElementName(DT("o2"));
		p_o2->set_Parent(this);
	}
	return back_o2;
}
XplExpression* XplTernaryoperator::set_o3(XplExpression* new_o3){
	XplExpression* back_o3 = p_o3;
	p_o3 = new_o3;
	if(p_o3!=NULL){
		p_o3->set_ElementName(DT("o3"));
		p_o3->set_Parent(this);
	}
	return back_o3;
}
XplExpression* XplTernaryoperator::new_o1(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("o1"));
	return node;
}
XplExpression* XplTernaryoperator::new_o2(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("o2"));
	return node;
}
XplExpression* XplTernaryoperator::new_o3(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("o3"));
	return node;
}

}

#endif
