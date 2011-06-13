/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEEXTENDEDLAYERDZOEDOCUMENTCONFIG_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEEXTENDEDLAYERDZOEDOCUMENTCONFIG_V1_0_CPP
#include "CDOM_XplExtendedLayerDZoeDocumentConfig.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplExtendedLayerDZoeDocumentConfig::XplExtendedLayerDZoeDocumentConfig(){
	p_platform = DT_EMPTY;
	p_outputFileName = DT_EMPTY;
	p_partNumber = 0;
	p_programName = DT_EMPTY;
	p_programConfig = DT_EMPTY;
	p_Language=NULL;
	p_LayerDCompiler=NULL;
	p_LayerDZoeCompiler=NULL;
	p_History = new XplNodeList();
	p_History->set_Parent(this);
	p_History->set_InsertNodeCallback(&acceptInsertNodeCallback_History);
	p_History->set_RemoveNodeCallback(&acceptRemoveNodeCallback_History);
}
XplExtendedLayerDZoeDocumentConfig::XplExtendedLayerDZoeDocumentConfig(string n_platform){
	p_platform = DT_EMPTY;
	p_outputFileName = DT_EMPTY;
	p_partNumber = 0;
	p_programName = DT_EMPTY;
	p_programConfig = DT_EMPTY;
	set_platform(n_platform);
	p_Language=NULL;
	p_LayerDCompiler=NULL;
	p_LayerDZoeCompiler=NULL;
	p_History = new XplNodeList();
	p_History->set_Parent(this);
	p_History->set_InsertNodeCallback(&acceptInsertNodeCallback_History);
	p_History->set_RemoveNodeCallback(&acceptRemoveNodeCallback_History);
}
XplExtendedLayerDZoeDocumentConfig::XplExtendedLayerDZoeDocumentConfig(string n_platform, string n_outputFileName, int n_partNumber, string n_programName, string n_programConfig){
	set_platform(n_platform);
	set_outputFileName(n_outputFileName);
	set_partNumber(n_partNumber);
	set_programName(n_programName);
	set_programConfig(n_programConfig);
	p_Language=NULL;
	p_LayerDCompiler=NULL;
	p_LayerDZoeCompiler=NULL;
	p_History = new XplNodeList();
	p_History->set_Parent(this);
	p_History->set_InsertNodeCallback(&acceptInsertNodeCallback_History);
	p_History->set_RemoveNodeCallback(&acceptRemoveNodeCallback_History);
}
XplExtendedLayerDZoeDocumentConfig::XplExtendedLayerDZoeDocumentConfig(XplLanguage* n_Language, XplLayerDCompiler* n_LayerDCompiler, XplLayerDCompiler* n_LayerDZoeCompiler, XplNodeList* n_History){
	p_platform = DT_EMPTY;
	p_outputFileName = DT_EMPTY;
	p_partNumber = 0;
	p_programName = DT_EMPTY;
	p_programConfig = DT_EMPTY;
	p_Language=NULL;
	p_LayerDCompiler=NULL;
	p_LayerDZoeCompiler=NULL;
	p_History = new XplNodeList();
	p_History->set_Parent(this);
	p_History->set_InsertNodeCallback(&acceptInsertNodeCallback_History);
	p_History->set_RemoveNodeCallback(&acceptRemoveNodeCallback_History);
	set_Language(n_Language);
	set_LayerDCompiler(n_LayerDCompiler);
	set_LayerDZoeCompiler(n_LayerDZoeCompiler);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_History!=NULL)
	for(XplNode* node = n_History->FirstNode(); node != n_History->GetLastNode() ; node = n_History->NextNode()){
		p_History->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplExtendedLayerDZoeDocumentConfig::XplExtendedLayerDZoeDocumentConfig(string n_platform, XplLanguage* n_Language, XplLayerDCompiler* n_LayerDCompiler, XplLayerDCompiler* n_LayerDZoeCompiler, XplNodeList* n_History){
	p_platform = DT_EMPTY;
	p_outputFileName = DT_EMPTY;
	p_partNumber = 0;
	p_programName = DT_EMPTY;
	p_programConfig = DT_EMPTY;
	set_platform(n_platform);
	p_Language=NULL;
	p_LayerDCompiler=NULL;
	p_LayerDZoeCompiler=NULL;
	p_History = new XplNodeList();
	p_History->set_Parent(this);
	p_History->set_InsertNodeCallback(&acceptInsertNodeCallback_History);
	p_History->set_RemoveNodeCallback(&acceptRemoveNodeCallback_History);
	set_Language(n_Language);
	set_LayerDCompiler(n_LayerDCompiler);
	set_LayerDZoeCompiler(n_LayerDZoeCompiler);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_History!=NULL)
	for(XplNode* node = n_History->FirstNode(); node != n_History->GetLastNode() ; node = n_History->NextNode()){
		p_History->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplExtendedLayerDZoeDocumentConfig::XplExtendedLayerDZoeDocumentConfig(string n_platform, string n_outputFileName, int n_partNumber, string n_programName, string n_programConfig, XplLanguage* n_Language, XplLayerDCompiler* n_LayerDCompiler, XplLayerDCompiler* n_LayerDZoeCompiler, XplNodeList* n_History){
	set_platform(n_platform);
	set_outputFileName(n_outputFileName);
	set_partNumber(n_partNumber);
	set_programName(n_programName);
	set_programConfig(n_programConfig);
	p_Language=NULL;
	p_LayerDCompiler=NULL;
	p_LayerDZoeCompiler=NULL;
	p_History = new XplNodeList();
	p_History->set_Parent(this);
	p_History->set_InsertNodeCallback(&acceptInsertNodeCallback_History);
	p_History->set_RemoveNodeCallback(&acceptRemoveNodeCallback_History);
	set_Language(n_Language);
	set_LayerDCompiler(n_LayerDCompiler);
	set_LayerDZoeCompiler(n_LayerDZoeCompiler);
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
XplExtendedLayerDZoeDocumentConfig::~XplExtendedLayerDZoeDocumentConfig(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplExtendedLayerDZoeDocumentConfig'");
#endif
	//Variables para Elementos de Secuencia
	if(p_Language!=NULL)delete p_Language;
	if(p_LayerDCompiler!=NULL)delete p_LayerDCompiler;
	if(p_LayerDZoeCompiler!=NULL)delete p_LayerDZoeCompiler;
	if(p_History!=NULL)delete p_History;
}

//Funciones Sobreescritas de XplNode
XplNode* XplExtendedLayerDZoeDocumentConfig::Clone(){
	XplExtendedLayerDZoeDocumentConfig* copy = new XplExtendedLayerDZoeDocumentConfig();
	copy->set_platform(this->p_platform);
	copy->set_outputFileName(this->p_outputFileName);
	copy->set_partNumber(this->p_partNumber);
	copy->set_programName(this->p_programName);
	copy->set_programConfig(this->p_programConfig);
	if(p_Language!=NULL)copy->set_Language((XplLanguage*)p_Language->Clone());
	if(p_LayerDCompiler!=NULL)copy->set_LayerDCompiler((XplLayerDCompiler*)p_LayerDCompiler->Clone());
	if(p_LayerDZoeCompiler!=NULL)copy->set_LayerDZoeCompiler((XplLayerDCompiler*)p_LayerDZoeCompiler->Clone());
	for(XplNode* node = p_History->FirstNode(); node != NULL ; node = p_History->NextNode()){
		copy->get_History()->InsertAtEnd(node->Clone());
	}
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplExtendedLayerDZoeDocumentConfig::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_platform != DT_EMPTY)
		writer->write(DT(" platform=\"")+CODEDOM_Att_ToString(p_platform)+DT("\""));
	if(p_outputFileName != DT_EMPTY)
		writer->write(DT(" outputFileName=\"")+CODEDOM_Att_ToString(p_outputFileName)+DT("\""));
	if(p_partNumber != 0)
		writer->write(DT(" partNumber=\"")+CODEDOM_Att_ToString(p_partNumber)+DT("\""));
	if(p_programName != DT_EMPTY)
		writer->write(DT(" programName=\"")+CODEDOM_Att_ToString(p_programName)+DT("\""));
	if(p_programConfig != DT_EMPTY)
		writer->write(DT(" programConfig=\"")+CODEDOM_Att_ToString(p_programConfig)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_Language!=NULL)if(!p_Language->Write(writer))result=false;
	if(p_LayerDCompiler!=NULL)if(!p_LayerDCompiler->Write(writer))result=false;
	if(p_LayerDZoeCompiler!=NULL)if(!p_LayerDZoeCompiler->Write(writer))result=false;
	if(p_History!=NULL)if(!p_History->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplExtendedLayerDZoeDocumentConfig::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplExtendedLayerDZoeDocumentConfig::get_platform(){
	return p_platform;
}
string XplExtendedLayerDZoeDocumentConfig::get_outputFileName(){
	return p_outputFileName;
}
int XplExtendedLayerDZoeDocumentConfig::get_partNumber(){
	return p_partNumber;
}
string XplExtendedLayerDZoeDocumentConfig::get_programName(){
	return p_programName;
}
string XplExtendedLayerDZoeDocumentConfig::get_programConfig(){
	return p_programConfig;
}

//Funciones para obtener Elementos de Secuencia
XplLanguage* XplExtendedLayerDZoeDocumentConfig::get_Language(){
	return p_Language;
}
XplLayerDCompiler* XplExtendedLayerDZoeDocumentConfig::get_LayerDCompiler(){
	return p_LayerDCompiler;
}
XplLayerDCompiler* XplExtendedLayerDZoeDocumentConfig::get_LayerDZoeCompiler(){
	return p_LayerDZoeCompiler;
}
XplNodeList* XplExtendedLayerDZoeDocumentConfig::get_History(){
	return p_History;
}

//Funciones para setear Atributos
string XplExtendedLayerDZoeDocumentConfig::set_platform(string new_platform){
	string back_platform = p_platform;
	p_platform = new_platform;
	return back_platform;
}
string XplExtendedLayerDZoeDocumentConfig::set_outputFileName(string new_outputFileName){
	string back_outputFileName = p_outputFileName;
	p_outputFileName = new_outputFileName;
	return back_outputFileName;
}
int XplExtendedLayerDZoeDocumentConfig::set_partNumber(int new_partNumber){
	int back_partNumber = p_partNumber;
	p_partNumber = new_partNumber;
	return back_partNumber;
}
string XplExtendedLayerDZoeDocumentConfig::set_programName(string new_programName){
	string back_programName = p_programName;
	p_programName = new_programName;
	return back_programName;
}
string XplExtendedLayerDZoeDocumentConfig::set_programConfig(string new_programConfig){
	string back_programConfig = p_programConfig;
	p_programConfig = new_programConfig;
	return back_programConfig;
}

//Funciones para setear Elementos de Secuencia
XplLanguage* XplExtendedLayerDZoeDocumentConfig::set_Language(XplLanguage* new_Language){
	XplLanguage* back_Language = p_Language;
	p_Language = new_Language;
	if(p_Language!=NULL){
		p_Language->set_ElementName(DT("Language"));
		p_Language->set_Parent(this);
	}
	return back_Language;
}
XplLayerDCompiler* XplExtendedLayerDZoeDocumentConfig::set_LayerDCompiler(XplLayerDCompiler* new_LayerDCompiler){
	XplLayerDCompiler* back_LayerDCompiler = p_LayerDCompiler;
	p_LayerDCompiler = new_LayerDCompiler;
	if(p_LayerDCompiler!=NULL){
		p_LayerDCompiler->set_ElementName(DT("LayerDCompiler"));
		p_LayerDCompiler->set_Parent(this);
	}
	return back_LayerDCompiler;
}
XplLayerDCompiler* XplExtendedLayerDZoeDocumentConfig::set_LayerDZoeCompiler(XplLayerDCompiler* new_LayerDZoeCompiler){
	XplLayerDCompiler* back_LayerDZoeCompiler = p_LayerDZoeCompiler;
	p_LayerDZoeCompiler = new_LayerDZoeCompiler;
	if(p_LayerDZoeCompiler!=NULL){
		p_LayerDZoeCompiler->set_ElementName(DT("LayerDZoeCompiler"));
		p_LayerDZoeCompiler->set_Parent(this);
	}
	return back_LayerDZoeCompiler;
}
	bool XplExtendedLayerDZoeDocumentConfig::acceptInsertNodeCallback_History(XplNode* node, string* errorMsg, XplNode* parent){
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
	bool XplExtendedLayerDZoeDocumentConfig::acceptRemoveNodeCallback_History(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}
XplLanguage* XplExtendedLayerDZoeDocumentConfig::new_Language(){
	XplLanguage* node = new XplLanguage();
	node->set_ElementName(DT("Language"));
	return node;
}
XplLayerDCompiler* XplExtendedLayerDZoeDocumentConfig::new_LayerDCompiler(){
	XplLayerDCompiler* node = new XplLayerDCompiler();
	node->set_ElementName(DT("LayerDCompiler"));
	return node;
}
XplLayerDCompiler* XplExtendedLayerDZoeDocumentConfig::new_LayerDZoeCompiler(){
	XplLayerDCompiler* node = new XplLayerDCompiler();
	node->set_ElementName(DT("LayerDZoeCompiler"));
	return node;
}
XplFileData* XplExtendedLayerDZoeDocumentConfig::new_History(){
	XplFileData* node = new XplFileData();
	node->set_ElementName(DT("History"));
	return node;
}

}

#endif
