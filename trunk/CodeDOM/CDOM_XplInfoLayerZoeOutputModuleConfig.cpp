/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEINFOLAYERZOEOUTPUTMODULECONFIG_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEINFOLAYERZOEOUTPUTMODULECONFIG_V1_0_CPP
#include "CDOM_XplInfoLayerZoeOutputModuleConfig.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplInfoLayerZoeOutputModuleConfig::XplInfoLayerZoeOutputModuleConfig(){
	p_name = DT_EMPTY;
	p_especifiedClass = DT_EMPTY;
	p_defaultPlatform = DT_EMPTY;
	p_SupportedPlatform = new XplNodeList();
	p_SupportedPlatform->set_Parent(this);
	p_SupportedPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_SupportedPlatform);
	p_SupportedPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SupportedPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_Capabilities=NULL;
}
XplInfoLayerZoeOutputModuleConfig::XplInfoLayerZoeOutputModuleConfig(string n_name){
	p_name = DT_EMPTY;
	p_especifiedClass = DT_EMPTY;
	p_defaultPlatform = DT_EMPTY;
	set_name(n_name);
	p_SupportedPlatform = new XplNodeList();
	p_SupportedPlatform->set_Parent(this);
	p_SupportedPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_SupportedPlatform);
	p_SupportedPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SupportedPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_Capabilities=NULL;
}
XplInfoLayerZoeOutputModuleConfig::XplInfoLayerZoeOutputModuleConfig(XplNodeList* n_SupportedPlatform, XplOutputModuleCapabilities* n_Capabilities){
	p_name = DT_EMPTY;
	p_especifiedClass = DT_EMPTY;
	p_defaultPlatform = DT_EMPTY;
	p_SupportedPlatform = new XplNodeList();
	p_SupportedPlatform->set_Parent(this);
	p_SupportedPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_SupportedPlatform);
	p_SupportedPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SupportedPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_Capabilities=NULL;
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_SupportedPlatform!=NULL)
	for(XplNode* node = n_SupportedPlatform->FirstNode(); node != n_SupportedPlatform->GetLastNode() ; node = n_SupportedPlatform->NextNode()){
		p_SupportedPlatform->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
	set_Capabilities(n_Capabilities);
}
XplInfoLayerZoeOutputModuleConfig::XplInfoLayerZoeOutputModuleConfig(string n_name, XplNodeList* n_SupportedPlatform, XplOutputModuleCapabilities* n_Capabilities){
	p_name = DT_EMPTY;
	p_especifiedClass = DT_EMPTY;
	p_defaultPlatform = DT_EMPTY;
	set_name(n_name);
	p_SupportedPlatform = new XplNodeList();
	p_SupportedPlatform->set_Parent(this);
	p_SupportedPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_SupportedPlatform);
	p_SupportedPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SupportedPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_Capabilities=NULL;
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_SupportedPlatform!=NULL)
	for(XplNode* node = n_SupportedPlatform->FirstNode(); node != n_SupportedPlatform->GetLastNode() ; node = n_SupportedPlatform->NextNode()){
		p_SupportedPlatform->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
	set_Capabilities(n_Capabilities);
}
XplInfoLayerZoeOutputModuleConfig::XplInfoLayerZoeOutputModuleConfig(string n_name, string n_especifiedClass, string n_defaultPlatform){
	set_name(n_name);
	set_especifiedClass(n_especifiedClass);
	set_defaultPlatform(n_defaultPlatform);
	p_SupportedPlatform = new XplNodeList();
	p_SupportedPlatform->set_Parent(this);
	p_SupportedPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_SupportedPlatform);
	p_SupportedPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SupportedPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_Capabilities=NULL;
}
XplInfoLayerZoeOutputModuleConfig::XplInfoLayerZoeOutputModuleConfig(XplNodeList* n_SupportedPlatform, XplNodeList* n_PlatformAlias, XplOutputModuleCapabilities* n_Capabilities){
	p_name = DT_EMPTY;
	p_especifiedClass = DT_EMPTY;
	p_defaultPlatform = DT_EMPTY;
	p_SupportedPlatform = new XplNodeList();
	p_SupportedPlatform->set_Parent(this);
	p_SupportedPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_SupportedPlatform);
	p_SupportedPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SupportedPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_Capabilities=NULL;
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_SupportedPlatform!=NULL)
	for(XplNode* node = n_SupportedPlatform->FirstNode(); node != n_SupportedPlatform->GetLastNode() ; node = n_SupportedPlatform->NextNode()){
		p_SupportedPlatform->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_PlatformAlias!=NULL)
	for(XplNode* node = n_PlatformAlias->FirstNode(); node != n_PlatformAlias->GetLastNode() ; node = n_PlatformAlias->NextNode()){
		p_PlatformAlias->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
	set_Capabilities(n_Capabilities);
}
XplInfoLayerZoeOutputModuleConfig::XplInfoLayerZoeOutputModuleConfig(string n_name, string n_especifiedClass, string n_defaultPlatform, XplNodeList* n_SupportedPlatform, XplOutputModuleCapabilities* n_Capabilities){
	set_name(n_name);
	set_especifiedClass(n_especifiedClass);
	set_defaultPlatform(n_defaultPlatform);
	set_name(n_name);
	p_SupportedPlatform = new XplNodeList();
	p_SupportedPlatform->set_Parent(this);
	p_SupportedPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_SupportedPlatform);
	p_SupportedPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SupportedPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_Capabilities=NULL;
}
XplInfoLayerZoeOutputModuleConfig::XplInfoLayerZoeOutputModuleConfig(string n_name, XplNodeList* n_SupportedPlatform, XplNodeList* n_PlatformAlias, XplOutputModuleCapabilities* n_Capabilities){
	p_name = DT_EMPTY;
	p_especifiedClass = DT_EMPTY;
	p_defaultPlatform = DT_EMPTY;
	set_name(n_name);
	p_SupportedPlatform = new XplNodeList();
	p_SupportedPlatform->set_Parent(this);
	p_SupportedPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_SupportedPlatform);
	p_SupportedPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SupportedPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_Capabilities=NULL;
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_SupportedPlatform!=NULL)
	for(XplNode* node = n_SupportedPlatform->FirstNode(); node != n_SupportedPlatform->GetLastNode() ; node = n_SupportedPlatform->NextNode()){
		p_SupportedPlatform->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_PlatformAlias!=NULL)
	for(XplNode* node = n_PlatformAlias->FirstNode(); node != n_PlatformAlias->GetLastNode() ; node = n_PlatformAlias->NextNode()){
		p_PlatformAlias->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
	set_Capabilities(n_Capabilities);
}
XplInfoLayerZoeOutputModuleConfig::XplInfoLayerZoeOutputModuleConfig(string n_name, string n_especifiedClass, string n_defaultPlatform, XplNodeList* n_SupportedPlatform, XplNodeList* n_PlatformAlias, XplOutputModuleCapabilities* n_Capabilities){
	set_name(n_name);
	set_especifiedClass(n_especifiedClass);
	set_defaultPlatform(n_defaultPlatform);
	p_SupportedPlatform = new XplNodeList();
	p_SupportedPlatform->set_Parent(this);
	p_SupportedPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_SupportedPlatform);
	p_SupportedPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SupportedPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_Capabilities=NULL;
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_SupportedPlatform!=NULL)
	for(XplNode* node = n_SupportedPlatform->FirstNode(); node != n_SupportedPlatform->GetLastNode() ; node = n_SupportedPlatform->NextNode()){
		p_SupportedPlatform->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_PlatformAlias!=NULL)
	for(XplNode* node = n_PlatformAlias->FirstNode(); node != n_PlatformAlias->GetLastNode() ; node = n_PlatformAlias->NextNode()){
		p_PlatformAlias->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
	set_Capabilities(n_Capabilities);
}
//Destructor
XplInfoLayerZoeOutputModuleConfig::~XplInfoLayerZoeOutputModuleConfig(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplInfoLayerZoeOutputModuleConfig'");
#endif
	//Variables para Elementos de Secuencia
	if(p_SupportedPlatform!=NULL)delete p_SupportedPlatform;
	if(p_PlatformAlias!=NULL)delete p_PlatformAlias;
	if(p_Capabilities!=NULL)delete p_Capabilities;
}

//Funciones Sobreescritas de XplNode
XplNode* XplInfoLayerZoeOutputModuleConfig::Clone(){
	XplInfoLayerZoeOutputModuleConfig* copy = new XplInfoLayerZoeOutputModuleConfig();
	copy->set_name(this->p_name);
	copy->set_especifiedClass(this->p_especifiedClass);
	copy->set_defaultPlatform(this->p_defaultPlatform);
	for(XplNode* node = p_SupportedPlatform->FirstNode(); node != NULL ; node = p_SupportedPlatform->NextNode()){
		copy->get_SupportedPlatform()->InsertAtEnd(node->Clone());
	}
	for(XplNode* node = p_PlatformAlias->FirstNode(); node != NULL ; node = p_PlatformAlias->NextNode()){
		copy->get_PlatformAlias()->InsertAtEnd(node->Clone());
	}
	if(p_Capabilities!=NULL)copy->set_Capabilities((XplOutputModuleCapabilities*)p_Capabilities->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplInfoLayerZoeOutputModuleConfig::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_name != DT_EMPTY)
		writer->write(DT(" name=\"")+CODEDOM_Att_ToString(p_name)+DT("\""));
	if(p_especifiedClass != DT_EMPTY)
		writer->write(DT(" especifiedClass=\"")+CODEDOM_Att_ToString(p_especifiedClass)+DT("\""));
	if(p_defaultPlatform != DT_EMPTY)
		writer->write(DT(" defaultPlatform=\"")+CODEDOM_Att_ToString(p_defaultPlatform)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_SupportedPlatform!=NULL)if(!p_SupportedPlatform->Write(writer))result=false;
	if(p_PlatformAlias!=NULL)if(!p_PlatformAlias->Write(writer))result=false;
	if(p_Capabilities!=NULL)if(!p_Capabilities->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplInfoLayerZoeOutputModuleConfig::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplInfoLayerZoeOutputModuleConfig::get_name(){
	return p_name;
}
string XplInfoLayerZoeOutputModuleConfig::get_especifiedClass(){
	return p_especifiedClass;
}
string XplInfoLayerZoeOutputModuleConfig::get_defaultPlatform(){
	return p_defaultPlatform;
}

//Funciones para obtener Elementos de Secuencia
XplNodeList* XplInfoLayerZoeOutputModuleConfig::get_SupportedPlatform(){
	return p_SupportedPlatform;
}
XplNodeList* XplInfoLayerZoeOutputModuleConfig::get_PlatformAlias(){
	return p_PlatformAlias;
}
XplOutputModuleCapabilities* XplInfoLayerZoeOutputModuleConfig::get_Capabilities(){
	return p_Capabilities;
}

//Funciones para setear Atributos
string XplInfoLayerZoeOutputModuleConfig::set_name(string new_name){
	string back_name = p_name;
	p_name = new_name;
	return back_name;
}
string XplInfoLayerZoeOutputModuleConfig::set_especifiedClass(string new_especifiedClass){
	string back_especifiedClass = p_especifiedClass;
	p_especifiedClass = new_especifiedClass;
	return back_especifiedClass;
}
string XplInfoLayerZoeOutputModuleConfig::set_defaultPlatform(string new_defaultPlatform){
	string back_defaultPlatform = p_defaultPlatform;
	p_defaultPlatform = new_defaultPlatform;
	return back_defaultPlatform;
}

//Funciones para setear Elementos de Secuencia
	bool XplInfoLayerZoeOutputModuleConfig::acceptInsertNodeCallback_SupportedPlatform(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("SupportedPlatform")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOETARGETPLATFORM){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplTargetPlatform'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplTargetPlatform'."));
		return false;
	}
	bool XplInfoLayerZoeOutputModuleConfig::acceptRemoveNodeCallback_SupportedPlatform(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}
	bool XplInfoLayerZoeOutputModuleConfig::acceptInsertNodeCallback_PlatformAlias(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("PlatformAlias")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEPLATFORMALIAS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplPlatformAlias'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplPlatformAlias'."));
		return false;
	}
	bool XplInfoLayerZoeOutputModuleConfig::acceptRemoveNodeCallback_PlatformAlias(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}
XplOutputModuleCapabilities* XplInfoLayerZoeOutputModuleConfig::set_Capabilities(XplOutputModuleCapabilities* new_Capabilities){
	XplOutputModuleCapabilities* back_Capabilities = p_Capabilities;
	p_Capabilities = new_Capabilities;
	if(p_Capabilities!=NULL){
		p_Capabilities->set_ElementName(DT("Capabilities"));
		p_Capabilities->set_Parent(this);
	}
	return back_Capabilities;
}
XplTargetPlatform* XplInfoLayerZoeOutputModuleConfig::new_SupportedPlatform(){
	XplTargetPlatform* node = new XplTargetPlatform();
	node->set_ElementName(DT("SupportedPlatform"));
	return node;
}
XplPlatformAlias* XplInfoLayerZoeOutputModuleConfig::new_PlatformAlias(){
	XplPlatformAlias* node = new XplPlatformAlias();
	node->set_ElementName(DT("PlatformAlias"));
	return node;
}
XplOutputModuleCapabilities* XplInfoLayerZoeOutputModuleConfig::new_Capabilities(){
	XplOutputModuleCapabilities* node = new XplOutputModuleCapabilities();
	node->set_ElementName(DT("Capabilities"));
	return node;
}

}

#endif
