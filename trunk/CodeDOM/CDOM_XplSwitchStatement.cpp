/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOESWITCHSTATEMENT_V1_0_CPP
#define __LAYERD_CODEDOM_ZOESWITCHSTATEMENT_V1_0_CPP
#include "CDOM_XplSwitchStatement.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplSwitchStatement::XplSwitchStatement(){
	p_autobreak = true;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_e=NULL;
	p_case = new XplNodeList();
	p_case->set_Parent(this);
	p_case->set_InsertNodeCallback(&acceptInsertNodeCallback_case);
	p_case->set_RemoveNodeCallback(&acceptRemoveNodeCallback_case);
}
XplSwitchStatement::XplSwitchStatement(bool n_autobreak){
	p_autobreak = true;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_autobreak(n_autobreak);
	p_e=NULL;
	p_case = new XplNodeList();
	p_case->set_Parent(this);
	p_case->set_InsertNodeCallback(&acceptInsertNodeCallback_case);
	p_case->set_RemoveNodeCallback(&acceptRemoveNodeCallback_case);
}
XplSwitchStatement::XplSwitchStatement(XplExpression* n_e, XplNodeList* n_case){
	p_autobreak = true;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_e=NULL;
	p_case = new XplNodeList();
	p_case->set_Parent(this);
	p_case->set_InsertNodeCallback(&acceptInsertNodeCallback_case);
	p_case->set_RemoveNodeCallback(&acceptRemoveNodeCallback_case);
	set_e(n_e);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_case!=NULL)
	for(XplNode* node = n_case->FirstNode(); node != n_case->GetLastNode() ; node = n_case->NextNode()){
		p_case->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplSwitchStatement::XplSwitchStatement(bool n_autobreak, XplExpression* n_e, XplNodeList* n_case){
	p_autobreak = true;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_autobreak(n_autobreak);
	p_e=NULL;
	p_case = new XplNodeList();
	p_case->set_Parent(this);
	p_case->set_InsertNodeCallback(&acceptInsertNodeCallback_case);
	p_case->set_RemoveNodeCallback(&acceptRemoveNodeCallback_case);
	set_e(n_e);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_case!=NULL)
	for(XplNode* node = n_case->FirstNode(); node != n_case->GetLastNode() ; node = n_case->NextNode()){
		p_case->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplSwitchStatement::XplSwitchStatement(bool n_autobreak, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_autobreak(n_autobreak);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_e=NULL;
	p_case = new XplNodeList();
	p_case->set_Parent(this);
	p_case->set_InsertNodeCallback(&acceptInsertNodeCallback_case);
	p_case->set_RemoveNodeCallback(&acceptRemoveNodeCallback_case);
}
XplSwitchStatement::XplSwitchStatement(bool n_autobreak, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_e, XplNodeList* n_case){
	set_autobreak(n_autobreak);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	set_autobreak(n_autobreak);
	p_e=NULL;
	p_case = new XplNodeList();
	p_case->set_Parent(this);
	p_case->set_InsertNodeCallback(&acceptInsertNodeCallback_case);
	p_case->set_RemoveNodeCallback(&acceptRemoveNodeCallback_case);
}
//Destructor
XplSwitchStatement::~XplSwitchStatement(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplSwitchStatement'");
#endif
	//Variables para Elementos de Secuencia
	if(p_e!=NULL)delete p_e;
	if(p_case!=NULL)delete p_case;
}

//Funciones Sobreescritas de XplNode
XplNode* XplSwitchStatement::Clone(){
	XplSwitchStatement* copy = new XplSwitchStatement();
	copy->set_autobreak(this->p_autobreak);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_e!=NULL)copy->set_e((XplExpression*)p_e->Clone());
	for(XplNode* node = p_case->FirstNode(); node != NULL ; node = p_case->NextNode()){
		copy->get_case()->InsertAtEnd(node->Clone());
	}
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplSwitchStatement::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_autobreak != true)
		writer->write(DT(" autobreak=\"")+CODEDOM_Att_ToString(p_autobreak)+DT("\""));
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
	if(p_e!=NULL)if(!p_e->Write(writer))result=false;
	if(p_case!=NULL)if(!p_case->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplSwitchStatement::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
bool XplSwitchStatement::get_autobreak(){
	return p_autobreak;
}
string XplSwitchStatement::get_doc(){
	return p_doc;
}
string XplSwitchStatement::get_helpURL(){
	return p_helpURL;
}
string XplSwitchStatement::get_ldsrc(){
	return p_ldsrc;
}
bool XplSwitchStatement::get_iny(){
	return p_iny;
}
string XplSwitchStatement::get_inydata(){
	return p_inydata;
}
string XplSwitchStatement::get_inyby(){
	return p_inyby;
}
string XplSwitchStatement::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplExpression* XplSwitchStatement::get_e(){
	return p_e;
}
XplNodeList* XplSwitchStatement::get_case(){
	return p_case;
}

//Funciones para setear Atributos
bool XplSwitchStatement::set_autobreak(bool new_autobreak){
	bool back_autobreak = p_autobreak;
	p_autobreak = new_autobreak;
	return back_autobreak;
}
string XplSwitchStatement::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplSwitchStatement::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplSwitchStatement::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplSwitchStatement::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplSwitchStatement::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplSwitchStatement::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplSwitchStatement::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplExpression* XplSwitchStatement::set_e(XplExpression* new_e){
	XplExpression* back_e = p_e;
	p_e = new_e;
	if(p_e!=NULL){
		p_e->set_ElementName(DT("e"));
		p_e->set_Parent(this);
	}
	return back_e;
}
	bool XplSwitchStatement::acceptInsertNodeCallback_case(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("case")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOECASE){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplCase'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplCase'."));
		return false;
	}
	bool XplSwitchStatement::acceptRemoveNodeCallback_case(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}
XplExpression* XplSwitchStatement::new_e(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("e"));
	return node;
}
XplCase* XplSwitchStatement::new_case(){
	XplCase* node = new XplCase();
	node->set_ElementName(DT("case"));
	return node;
}

}

#endif
