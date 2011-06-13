/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOECLASSFACTORYSPERMISSIONS_V1_0_CPP
#define __LAYERD_CODEDOM_ZOECLASSFACTORYSPERMISSIONS_V1_0_CPP
#include "CDOM_XplClassfactorysPermissions.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplClassfactorysPermissions::XplClassfactorysPermissions(){
	p_allowRead = true;
	p_allowAppend = true;
	p_allowChange = true;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tClassfactorysPermissions);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tClassfactorysPermissions);
}
XplClassfactorysPermissions::XplClassfactorysPermissions(bool n_allowRead, bool n_allowAppend, bool n_allowChange){
	p_allowRead = true;
	p_allowAppend = true;
	p_allowChange = true;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_allowRead(n_allowRead);
	set_allowAppend(n_allowAppend);
	set_allowChange(n_allowChange);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tClassfactorysPermissions);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tClassfactorysPermissions);
}
XplClassfactorysPermissions::XplClassfactorysPermissions(bool n_allowRead, bool n_allowAppend, bool n_allowChange, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_allowRead(n_allowRead);
	set_allowAppend(n_allowAppend);
	set_allowChange(n_allowChange);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tClassfactorysPermissions);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tClassfactorysPermissions);
}
XplClassfactorysPermissions::XplClassfactorysPermissions(XplNodeList* n_Childs){
	p_allowRead = true;
	p_allowAppend = true;
	p_allowChange = true;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tClassfactorysPermissions);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tClassfactorysPermissions);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_Childs!=NULL)
	for(XplNode* node = n_Childs->FirstNode(); node != n_Childs->GetLastNode() ; node = n_Childs->NextNode()){
		p_Childs->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplClassfactorysPermissions::XplClassfactorysPermissions(bool n_allowRead, bool n_allowAppend, bool n_allowChange, XplNodeList* n_Childs){
	p_allowRead = true;
	p_allowAppend = true;
	p_allowChange = true;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_allowRead(n_allowRead);
	set_allowAppend(n_allowAppend);
	set_allowChange(n_allowChange);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tClassfactorysPermissions);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tClassfactorysPermissions);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_Childs!=NULL)
	for(XplNode* node = n_Childs->FirstNode(); node != n_Childs->GetLastNode() ; node = n_Childs->NextNode()){
		p_Childs->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplClassfactorysPermissions::XplClassfactorysPermissions(bool n_allowRead, bool n_allowAppend, bool n_allowChange, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNodeList* n_Childs){
	set_allowRead(n_allowRead);
	set_allowAppend(n_allowAppend);
	set_allowChange(n_allowChange);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tClassfactorysPermissions);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tClassfactorysPermissions);
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
XplClassfactorysPermissions::~XplClassfactorysPermissions(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplClassfactorysPermissions'");
#endif
	//Variables para Elementos de Secuencia
	if(p_Childs!=NULL)delete p_Childs;
}

//Funciones Sobreescritas de XplNode
XplNode* XplClassfactorysPermissions::Clone(){
	XplClassfactorysPermissions* copy = new XplClassfactorysPermissions();
	copy->set_allowRead(this->p_allowRead);
	copy->set_allowAppend(this->p_allowAppend);
	copy->set_allowChange(this->p_allowChange);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		copy->Childs()->InsertAtEnd(node->Clone());
	}
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplClassfactorysPermissions::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_allowRead != true)
		writer->write(DT(" allowRead=\"")+CODEDOM_Att_ToString(p_allowRead)+DT("\""));
	if(p_allowAppend != true)
		writer->write(DT(" allowAppend=\"")+CODEDOM_Att_ToString(p_allowAppend)+DT("\""));
	if(p_allowChange != true)
		writer->write(DT(" allowChange=\"")+CODEDOM_Att_ToString(p_allowChange)+DT("\""));
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
	if(p_Childs!=NULL)if(!p_Childs->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplClassfactorysPermissions::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
bool XplClassfactorysPermissions::get_allowRead(){
	return p_allowRead;
}
bool XplClassfactorysPermissions::get_allowAppend(){
	return p_allowAppend;
}
bool XplClassfactorysPermissions::get_allowChange(){
	return p_allowChange;
}
string XplClassfactorysPermissions::get_doc(){
	return p_doc;
}
string XplClassfactorysPermissions::get_helpURL(){
	return p_helpURL;
}
string XplClassfactorysPermissions::get_ldsrc(){
	return p_ldsrc;
}
bool XplClassfactorysPermissions::get_iny(){
	return p_iny;
}
string XplClassfactorysPermissions::get_inydata(){
	return p_inydata;
}
string XplClassfactorysPermissions::get_inyby(){
	return p_inyby;
}
string XplClassfactorysPermissions::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplNodeList* XplClassfactorysPermissions::Childs(){
	return p_Childs;
}

//Funciones para setear Atributos
bool XplClassfactorysPermissions::set_allowRead(bool new_allowRead){
	bool back_allowRead = p_allowRead;
	p_allowRead = new_allowRead;
	return back_allowRead;
}
bool XplClassfactorysPermissions::set_allowAppend(bool new_allowAppend){
	bool back_allowAppend = p_allowAppend;
	p_allowAppend = new_allowAppend;
	return back_allowAppend;
}
bool XplClassfactorysPermissions::set_allowChange(bool new_allowChange){
	bool back_allowChange = p_allowChange;
	p_allowChange = new_allowChange;
	return back_allowChange;
}
string XplClassfactorysPermissions::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplClassfactorysPermissions::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplClassfactorysPermissions::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplClassfactorysPermissions::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplClassfactorysPermissions::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplClassfactorysPermissions::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplClassfactorysPermissions::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
	bool XplClassfactorysPermissions::acceptInsertNodeCallback_tClassfactorysPermissions(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("cf")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_STRING){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassfactorysPermissions'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplClassfactorysPermissions'."));
		return false;
	}
	bool XplClassfactorysPermissions::acceptRemoveNodeCallback_tClassfactorysPermissions(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}

//Funciones para filtrado en Listas de Nodos
XplNodeList* XplClassfactorysPermissions::get_cfNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("cf")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNode* XplClassfactorysPermissions::new_cf(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("cf"));
	return node;
}

}

#endif
