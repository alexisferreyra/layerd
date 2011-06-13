/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEIFSTATEMENT_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEIFSTATEMENT_V1_0_CPP
#include "CDOM_XplIfStatement.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplIfStatement::XplIfStatement(){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_boolean=NULL;
	p_ifbk=NULL;
	p_elseif = new XplNodeList();
	p_elseif->set_Parent(this);
	p_elseif->set_InsertNodeCallback(&acceptInsertNodeCallback_elseif);
	p_elseif->set_RemoveNodeCallback(&acceptRemoveNodeCallback_elseif);
	p_else=NULL;
}
XplIfStatement::XplIfStatement(XplExpression* n_boolean){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_boolean=NULL;
	p_ifbk=NULL;
	p_elseif = new XplNodeList();
	p_elseif->set_Parent(this);
	p_elseif->set_InsertNodeCallback(&acceptInsertNodeCallback_elseif);
	p_elseif->set_RemoveNodeCallback(&acceptRemoveNodeCallback_elseif);
	p_else=NULL;
	set_boolean(n_boolean);
}
XplIfStatement::XplIfStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_boolean=NULL;
	p_ifbk=NULL;
	p_elseif = new XplNodeList();
	p_elseif->set_Parent(this);
	p_elseif->set_InsertNodeCallback(&acceptInsertNodeCallback_elseif);
	p_elseif->set_RemoveNodeCallback(&acceptRemoveNodeCallback_elseif);
	p_else=NULL;
}
XplIfStatement::XplIfStatement(XplExpression* n_boolean, XplFunctionBody* n_ifbk, XplNodeList* n_elseif, XplFunctionBody* n_else){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_boolean=NULL;
	p_ifbk=NULL;
	p_elseif = new XplNodeList();
	p_elseif->set_Parent(this);
	p_elseif->set_InsertNodeCallback(&acceptInsertNodeCallback_elseif);
	p_elseif->set_RemoveNodeCallback(&acceptRemoveNodeCallback_elseif);
	p_else=NULL;
	set_boolean(n_boolean);
	set_ifbk(n_ifbk);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_elseif!=NULL)
	for(XplNode* node = n_elseif->FirstNode(); node != n_elseif->GetLastNode() ; node = n_elseif->NextNode()){
		p_elseif->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
	set_else(n_else);
}
XplIfStatement::XplIfStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_boolean){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_boolean=NULL;
	p_ifbk=NULL;
	p_elseif = new XplNodeList();
	p_elseif->set_Parent(this);
	p_elseif->set_InsertNodeCallback(&acceptInsertNodeCallback_elseif);
	p_elseif->set_RemoveNodeCallback(&acceptRemoveNodeCallback_elseif);
	p_else=NULL;
}
XplIfStatement::XplIfStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_boolean, XplFunctionBody* n_ifbk, XplNodeList* n_elseif, XplFunctionBody* n_else){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_boolean=NULL;
	p_ifbk=NULL;
	p_elseif = new XplNodeList();
	p_elseif->set_Parent(this);
	p_elseif->set_InsertNodeCallback(&acceptInsertNodeCallback_elseif);
	p_elseif->set_RemoveNodeCallback(&acceptRemoveNodeCallback_elseif);
	p_else=NULL;
	set_boolean(n_boolean);
	set_ifbk(n_ifbk);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_elseif!=NULL)
	for(XplNode* node = n_elseif->FirstNode(); node != n_elseif->GetLastNode() ; node = n_elseif->NextNode()){
		p_elseif->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
	set_else(n_else);
}
//Destructor
XplIfStatement::~XplIfStatement(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplIfStatement'");
#endif
	//Variables para Elementos de Secuencia
	if(p_boolean!=NULL)delete p_boolean;
	if(p_ifbk!=NULL)delete p_ifbk;
	if(p_elseif!=NULL)delete p_elseif;
	if(p_else!=NULL)delete p_else;
}

//Funciones Sobreescritas de XplNode
XplNode* XplIfStatement::Clone(){
	XplIfStatement* copy = new XplIfStatement();
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_boolean!=NULL)copy->set_boolean((XplExpression*)p_boolean->Clone());
	if(p_ifbk!=NULL)copy->set_ifbk((XplFunctionBody*)p_ifbk->Clone());
	for(XplNode* node = p_elseif->FirstNode(); node != NULL ; node = p_elseif->NextNode()){
		copy->get_elseif()->InsertAtEnd(node->Clone());
	}
	if(p_else!=NULL)copy->set_else((XplFunctionBody*)p_else->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplIfStatement::Write(XplWriter* writer){
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
	if(p_boolean!=NULL)if(!p_boolean->Write(writer))result=false;
	if(p_ifbk!=NULL)if(!p_ifbk->Write(writer))result=false;
	if(p_elseif!=NULL)if(!p_elseif->Write(writer))result=false;
	if(p_else!=NULL)if(!p_else->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplIfStatement::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplIfStatement::get_doc(){
	return p_doc;
}
string XplIfStatement::get_helpURL(){
	return p_helpURL;
}
string XplIfStatement::get_ldsrc(){
	return p_ldsrc;
}
bool XplIfStatement::get_iny(){
	return p_iny;
}
string XplIfStatement::get_inydata(){
	return p_inydata;
}
string XplIfStatement::get_inyby(){
	return p_inyby;
}
string XplIfStatement::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplExpression* XplIfStatement::get_boolean(){
	return p_boolean;
}
XplFunctionBody* XplIfStatement::get_ifbk(){
	return p_ifbk;
}
XplNodeList* XplIfStatement::get_elseif(){
	return p_elseif;
}
XplFunctionBody* XplIfStatement::get_else(){
	return p_else;
}

//Funciones para setear Atributos
string XplIfStatement::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplIfStatement::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplIfStatement::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplIfStatement::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplIfStatement::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplIfStatement::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplIfStatement::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplExpression* XplIfStatement::set_boolean(XplExpression* new_boolean){
	XplExpression* back_boolean = p_boolean;
	p_boolean = new_boolean;
	if(p_boolean!=NULL){
		p_boolean->set_ElementName(DT("boolean"));
		p_boolean->set_Parent(this);
	}
	return back_boolean;
}
XplFunctionBody* XplIfStatement::set_ifbk(XplFunctionBody* new_ifbk){
	XplFunctionBody* back_ifbk = p_ifbk;
	p_ifbk = new_ifbk;
	if(p_ifbk!=NULL){
		p_ifbk->set_ElementName(DT("ifbk"));
		p_ifbk->set_Parent(this);
	}
	return back_ifbk;
}
	bool XplIfStatement::acceptInsertNodeCallback_elseif(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("elseif")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEIFSTATEMENT){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplIfStatement'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplIfStatement'."));
		return false;
	}
	bool XplIfStatement::acceptRemoveNodeCallback_elseif(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}
XplFunctionBody* XplIfStatement::set_else(XplFunctionBody* new_else){
	XplFunctionBody* back_else = p_else;
	p_else = new_else;
	if(p_else!=NULL){
		p_else->set_ElementName(DT("else"));
		p_else->set_Parent(this);
	}
	return back_else;
}
XplExpression* XplIfStatement::new_boolean(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("boolean"));
	return node;
}
XplFunctionBody* XplIfStatement::new_ifbk(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("ifbk"));
	return node;
}
XplIfStatement* XplIfStatement::new_elseif(){
	XplIfStatement* node = new XplIfStatement();
	node->set_ElementName(DT("elseif"));
	return node;
}
XplFunctionBody* XplIfStatement::new_else(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("else"));
	return node;
}

}

#endif
