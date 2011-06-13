/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOETRYSTATEMENT_V1_0_CPP
#define __LAYERD_CODEDOM_ZOETRYSTATEMENT_V1_0_CPP
#include "CDOM_XplTryStatement.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplTryStatement::XplTryStatement(){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_trybk=NULL;
	p_catchbk = new XplNodeList();
	p_catchbk->set_Parent(this);
	p_catchbk->set_InsertNodeCallback(&acceptInsertNodeCallback_catchbk);
	p_catchbk->set_RemoveNodeCallback(&acceptRemoveNodeCallback_catchbk);
	p_finallybk=NULL;
}
XplTryStatement::XplTryStatement(XplFunctionBody* n_trybk, XplNodeList* n_catchbk){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_trybk=NULL;
	p_catchbk = new XplNodeList();
	p_catchbk->set_Parent(this);
	p_catchbk->set_InsertNodeCallback(&acceptInsertNodeCallback_catchbk);
	p_catchbk->set_RemoveNodeCallback(&acceptRemoveNodeCallback_catchbk);
	p_finallybk=NULL;
	set_trybk(n_trybk);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_catchbk!=NULL)
	for(XplNode* node = n_catchbk->FirstNode(); node != n_catchbk->GetLastNode() ; node = n_catchbk->NextNode()){
		p_catchbk->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplTryStatement::XplTryStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_trybk=NULL;
	p_catchbk = new XplNodeList();
	p_catchbk->set_Parent(this);
	p_catchbk->set_InsertNodeCallback(&acceptInsertNodeCallback_catchbk);
	p_catchbk->set_RemoveNodeCallback(&acceptRemoveNodeCallback_catchbk);
	p_finallybk=NULL;
}
XplTryStatement::XplTryStatement(XplFunctionBody* n_trybk, XplNodeList* n_catchbk, XplFunctionBody* n_finallybk){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_trybk=NULL;
	p_catchbk = new XplNodeList();
	p_catchbk->set_Parent(this);
	p_catchbk->set_InsertNodeCallback(&acceptInsertNodeCallback_catchbk);
	p_catchbk->set_RemoveNodeCallback(&acceptRemoveNodeCallback_catchbk);
	p_finallybk=NULL;
	set_trybk(n_trybk);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_catchbk!=NULL)
	for(XplNode* node = n_catchbk->FirstNode(); node != n_catchbk->GetLastNode() ; node = n_catchbk->NextNode()){
		p_catchbk->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
	set_finallybk(n_finallybk);
}
XplTryStatement::XplTryStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplFunctionBody* n_trybk, XplNodeList* n_catchbk){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_trybk=NULL;
	p_catchbk = new XplNodeList();
	p_catchbk->set_Parent(this);
	p_catchbk->set_InsertNodeCallback(&acceptInsertNodeCallback_catchbk);
	p_catchbk->set_RemoveNodeCallback(&acceptRemoveNodeCallback_catchbk);
	p_finallybk=NULL;
}
XplTryStatement::XplTryStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplFunctionBody* n_trybk, XplNodeList* n_catchbk, XplFunctionBody* n_finallybk){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_trybk=NULL;
	p_catchbk = new XplNodeList();
	p_catchbk->set_Parent(this);
	p_catchbk->set_InsertNodeCallback(&acceptInsertNodeCallback_catchbk);
	p_catchbk->set_RemoveNodeCallback(&acceptRemoveNodeCallback_catchbk);
	p_finallybk=NULL;
	set_trybk(n_trybk);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_catchbk!=NULL)
	for(XplNode* node = n_catchbk->FirstNode(); node != n_catchbk->GetLastNode() ; node = n_catchbk->NextNode()){
		p_catchbk->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
	set_finallybk(n_finallybk);
}
//Destructor
XplTryStatement::~XplTryStatement(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplTryStatement'");
#endif
	//Variables para Elementos de Secuencia
	if(p_trybk!=NULL)delete p_trybk;
	if(p_catchbk!=NULL)delete p_catchbk;
	if(p_finallybk!=NULL)delete p_finallybk;
}

//Funciones Sobreescritas de XplNode
XplNode* XplTryStatement::Clone(){
	XplTryStatement* copy = new XplTryStatement();
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_trybk!=NULL)copy->set_trybk((XplFunctionBody*)p_trybk->Clone());
	for(XplNode* node = p_catchbk->FirstNode(); node != NULL ; node = p_catchbk->NextNode()){
		copy->get_catchbk()->InsertAtEnd(node->Clone());
	}
	if(p_finallybk!=NULL)copy->set_finallybk((XplFunctionBody*)p_finallybk->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplTryStatement::Write(XplWriter* writer){
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
	if(p_trybk!=NULL)if(!p_trybk->Write(writer))result=false;
	if(p_catchbk!=NULL)if(!p_catchbk->Write(writer))result=false;
	if(p_finallybk!=NULL)if(!p_finallybk->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplTryStatement::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplTryStatement::get_doc(){
	return p_doc;
}
string XplTryStatement::get_helpURL(){
	return p_helpURL;
}
string XplTryStatement::get_ldsrc(){
	return p_ldsrc;
}
bool XplTryStatement::get_iny(){
	return p_iny;
}
string XplTryStatement::get_inydata(){
	return p_inydata;
}
string XplTryStatement::get_inyby(){
	return p_inyby;
}
string XplTryStatement::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplFunctionBody* XplTryStatement::get_trybk(){
	return p_trybk;
}
XplNodeList* XplTryStatement::get_catchbk(){
	return p_catchbk;
}
XplFunctionBody* XplTryStatement::get_finallybk(){
	return p_finallybk;
}

//Funciones para setear Atributos
string XplTryStatement::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplTryStatement::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplTryStatement::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplTryStatement::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplTryStatement::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplTryStatement::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplTryStatement::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplFunctionBody* XplTryStatement::set_trybk(XplFunctionBody* new_trybk){
	XplFunctionBody* back_trybk = p_trybk;
	p_trybk = new_trybk;
	if(p_trybk!=NULL){
		p_trybk->set_ElementName(DT("trybk"));
		p_trybk->set_Parent(this);
	}
	return back_trybk;
}
	bool XplTryStatement::acceptInsertNodeCallback_catchbk(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("catchbk")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOECATCHSTATEMENT){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplCatchStatement'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplCatchStatement'."));
		return false;
	}
	bool XplTryStatement::acceptRemoveNodeCallback_catchbk(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}
XplFunctionBody* XplTryStatement::set_finallybk(XplFunctionBody* new_finallybk){
	XplFunctionBody* back_finallybk = p_finallybk;
	p_finallybk = new_finallybk;
	if(p_finallybk!=NULL){
		p_finallybk->set_ElementName(DT("finallybk"));
		p_finallybk->set_Parent(this);
	}
	return back_finallybk;
}
XplFunctionBody* XplTryStatement::new_trybk(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("trybk"));
	return node;
}
XplCatchStatement* XplTryStatement::new_catchbk(){
	XplCatchStatement* node = new XplCatchStatement();
	node->set_ElementName(DT("catchbk"));
	return node;
}
XplFunctionBody* XplTryStatement::new_finallybk(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("finallybk"));
	return node;
}

}

#endif
