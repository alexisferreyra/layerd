/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOELAYERDZOEDOCUMENTCONFIG_V1_0_CPP
#define __LAYERD_CODEDOM_ZOELAYERDZOEDOCUMENTCONFIG_V1_0_CPP
#include "CDOM_XplLayerDZoeDocumentConfig.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplLayerDZoeDocumentConfig::XplLayerDZoeDocumentConfig(){
	p_programName = DT_EMPTY;
	p_programConfig = DT_EMPTY;
	p_Language=NULL;
	p_LayerDCompiler=NULL;
	p_History = new XplNodeList();
	p_History->set_Parent(this);
	p_History->set_InsertNodeCallback(&acceptInsertNodeCallback_History);
	p_History->set_RemoveNodeCallback(&acceptRemoveNodeCallback_History);
}
XplLayerDZoeDocumentConfig::XplLayerDZoeDocumentConfig(XplLanguage* n_Language, XplLayerDCompiler* n_LayerDCompiler){
	p_programName = DT_EMPTY;
	p_programConfig = DT_EMPTY;
	p_Language=NULL;
	p_LayerDCompiler=NULL;
	p_History = new XplNodeList();
	p_History->set_Parent(this);
	p_History->set_InsertNodeCallback(&acceptInsertNodeCallback_History);
	p_History->set_RemoveNodeCallback(&acceptRemoveNodeCallback_History);
	set_Language(n_Language);
	set_LayerDCompiler(n_LayerDCompiler);
}
XplLayerDZoeDocumentConfig::XplLayerDZoeDocumentConfig(string n_programName, string n_programConfig){
	set_programName(n_programName);
	set_programConfig(n_programConfig);
	p_Language=NULL;
	p_LayerDCompiler=NULL;
	p_History = new XplNodeList();
	p_History->set_Parent(this);
	p_History->set_InsertNodeCallback(&acceptInsertNodeCallback_History);
	p_History->set_RemoveNodeCallback(&acceptRemoveNodeCallback_History);
}
XplLayerDZoeDocumentConfig::XplLayerDZoeDocumentConfig(XplLanguage* n_Language, XplLayerDCompiler* n_LayerDCompiler, XplNodeList* n_History){
	p_programName = DT_EMPTY;
	p_programConfig = DT_EMPTY;
	p_Language=NULL;
	p_LayerDCompiler=NULL;
	p_History = new XplNodeList();
	p_History->set_Parent(this);
	p_History->set_InsertNodeCallback(&acceptInsertNodeCallback_History);
	p_History->set_RemoveNodeCallback(&acceptRemoveNodeCallback_History);
	set_Language(n_Language);
	set_LayerDCompiler(n_LayerDCompiler);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_History!=NULL)
	for(XplNode* node = n_History->FirstNode(); node != n_History->GetLastNode() ; node = n_History->NextNode()){
		p_History->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplLayerDZoeDocumentConfig::XplLayerDZoeDocumentConfig(string n_programName, string n_programConfig, XplLanguage* n_Language, XplLayerDCompiler* n_LayerDCompiler){
	set_programName(n_programName);
	set_programConfig(n_programConfig);
	p_Language=NULL;
	p_LayerDCompiler=NULL;
	p_History = new XplNodeList();
	p_History->set_Parent(this);
	p_History->set_InsertNodeCallback(&acceptInsertNodeCallback_History);
	p_History->set_RemoveNodeCallback(&acceptRemoveNodeCallback_History);
}
XplLayerDZoeDocumentConfig::XplLayerDZoeDocumentConfig(string n_programName, string n_programConfig, XplLanguage* n_Language, XplLayerDCompiler* n_LayerDCompiler, XplNodeList* n_History){
	set_programName(n_programName);
	set_programConfig(n_programConfig);
	p_Language=NULL;
	p_LayerDCompiler=NULL;
	p_History = new XplNodeList();
	p_History->set_Parent(this);
	p_History->set_InsertNodeCallback(&acceptInsertNodeCallback_History);
	p_History->set_RemoveNodeCallback(&acceptRemoveNodeCallback_History);
	set_Language(n_Language);
	set_LayerDCompiler(n_LayerDCompiler);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_History!=NULL)
	for(XplNode* node = n_History->FirstNode(); node != n_History->GetLastNode() ; node = n_History->NextNode()){
		p_History->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
//Destructor
XplLayerDZoeDocumentConfig::~XplLayerDZoeDocumentConfig(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplLayerDZoeDocumentConfig'");
#endif
	//Variables para Elementos de Secuencia
	if(p_Language!=NULL)delete p_Language;
	if(p_LayerDCompiler!=NULL)delete p_LayerDCompiler;
	if(p_History!=NULL)delete p_History;
}

//Funciones Sobreescritas de XplNode
XplNode* XplLayerDZoeDocumentConfig::Clone(){
	XplLayerDZoeDocumentConfig* copy = new XplLayerDZoeDocumentConfig();
	copy->set_programName(this->p_programName);
	copy->set_programConfig(this->p_programConfig);
	if(p_Language!=NULL)copy->set_Language((XplLanguage*)p_Language->Clone());
	if(p_LayerDCompiler!=NULL)copy->set_LayerDCompiler((XplLayerDCompiler*)p_LayerDCompiler->Clone());
	for(XplNode* node = p_History->FirstNode(); node != NULL ; node = p_History->NextNode()){
		copy->get_History()->InsertAtEnd(node->Clone());
	}
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplLayerDZoeDocumentConfig::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_programName != DT_EMPTY)
		writer->write(DT(" programName=\"")+CODEDOM_Att_ToString(p_programName)+DT("\""));
	if(p_programConfig != DT_EMPTY)
		writer->write(DT(" programConfig=\"")+CODEDOM_Att_ToString(p_programConfig)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_Language!=NULL)if(!p_Language->Write(writer))result=false;
	if(p_LayerDCompiler!=NULL)if(!p_LayerDCompiler->Write(writer))result=false;
	if(p_History!=NULL)if(!p_History->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplLayerDZoeDocumentConfig::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplLayerDZoeDocumentConfig::get_programName(){
	return p_programName;
}
string XplLayerDZoeDocumentConfig::get_programConfig(){
	return p_programConfig;
}

//Funciones para obtener Elementos de Secuencia
XplLanguage* XplLayerDZoeDocumentConfig::get_Language(){
	return p_Language;
}
XplLayerDCompiler* XplLayerDZoeDocumentConfig::get_LayerDCompiler(){
	return p_LayerDCompiler;
}
XplNodeList* XplLayerDZoeDocumentConfig::get_History(){
	return p_History;
}

//Funciones para setear Atributos
string XplLayerDZoeDocumentConfig::set_programName(string new_programName){
	string back_programName = p_programName;
	p_programName = new_programName;
	return back_programName;
}
string XplLayerDZoeDocumentConfig::set_programConfig(string new_programConfig){
	string back_programConfig = p_programConfig;
	p_programConfig = new_programConfig;
	return back_programConfig;
}

//Funciones para setear Elementos de Secuencia
XplLanguage* XplLayerDZoeDocumentConfig::set_Language(XplLanguage* new_Language){
	XplLanguage* back_Language = p_Language;
	p_Language = new_Language;
	if(p_Language!=NULL){
		p_Language->set_ElementName(DT("Language"));
		p_Language->set_Parent(this);
	}
	return back_Language;
}
XplLayerDCompiler* XplLayerDZoeDocumentConfig::set_LayerDCompiler(XplLayerDCompiler* new_LayerDCompiler){
	XplLayerDCompiler* back_LayerDCompiler = p_LayerDCompiler;
	p_LayerDCompiler = new_LayerDCompiler;
	if(p_LayerDCompiler!=NULL){
		p_LayerDCompiler->set_ElementName(DT("LayerDCompiler"));
		p_LayerDCompiler->set_Parent(this);
	}
	return back_LayerDCompiler;
}
	bool XplLayerDZoeDocumentConfig::acceptInsertNodeCallback_History(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("History")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFILEDATA){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFileData'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplFileData'."));
		return false;
	}
	bool XplLayerDZoeDocumentConfig::acceptRemoveNodeCallback_History(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}
XplLanguage* XplLayerDZoeDocumentConfig::new_Language(){
	XplLanguage* node = new XplLanguage();
	node->set_ElementName(DT("Language"));
	return node;
}
XplLayerDCompiler* XplLayerDZoeDocumentConfig::new_LayerDCompiler(){
	XplLayerDCompiler* node = new XplLayerDCompiler();
	node->set_ElementName(DT("LayerDCompiler"));
	return node;
}
XplFileData* XplLayerDZoeDocumentConfig::new_History(){
	XplFileData* node = new XplFileData();
	node->set_ElementName(DT("History"));
	return node;
}

}

#endif
