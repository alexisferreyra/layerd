/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOELAYERDERRORINTERCHANGECONFIG_V1_0_CPP
#define __LAYERD_CODEDOM_ZOELAYERDERRORINTERCHANGECONFIG_V1_0_CPP
#include "CDOM_XplLayerDErrorInterchangeConfig.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplLayerDErrorInterchangeConfig::XplLayerDErrorInterchangeConfig(){
	p_Warning = new XplNodeList();
	p_Warning->set_Parent(this);
	p_Warning->set_InsertNodeCallback(&acceptInsertNodeCallback_Warning);
	p_Warning->set_RemoveNodeCallback(&acceptRemoveNodeCallback_Warning);
	p_Error = new XplNodeList();
	p_Error->set_Parent(this);
	p_Error->set_InsertNodeCallback(&acceptInsertNodeCallback_Error);
	p_Error->set_RemoveNodeCallback(&acceptRemoveNodeCallback_Error);
}
XplLayerDErrorInterchangeConfig::XplLayerDErrorInterchangeConfig(XplNodeList* n_Warning, XplNodeList* n_Error){
	p_Warning = new XplNodeList();
	p_Warning->set_Parent(this);
	p_Warning->set_InsertNodeCallback(&acceptInsertNodeCallback_Warning);
	p_Warning->set_RemoveNodeCallback(&acceptRemoveNodeCallback_Warning);
	p_Error = new XplNodeList();
	p_Error->set_Parent(this);
	p_Error->set_InsertNodeCallback(&acceptInsertNodeCallback_Error);
	p_Error->set_RemoveNodeCallback(&acceptRemoveNodeCallback_Error);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_Warning!=NULL)
	for(XplNode* node = n_Warning->FirstNode(); node != n_Warning->GetLastNode() ; node = n_Warning->NextNode()){
		p_Warning->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_Error!=NULL)
	for(XplNode* node = n_Error->FirstNode(); node != n_Error->GetLastNode() ; node = n_Error->NextNode()){
		p_Error->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
//Destructor
XplLayerDErrorInterchangeConfig::~XplLayerDErrorInterchangeConfig(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplLayerDErrorInterchangeConfig'");
#endif
	//Variables para Elementos de Secuencia
	if(p_Warning!=NULL)delete p_Warning;
	if(p_Error!=NULL)delete p_Error;
}

//Funciones Sobreescritas de XplNode
XplNode* XplLayerDErrorInterchangeConfig::Clone(){
	XplLayerDErrorInterchangeConfig* copy = new XplLayerDErrorInterchangeConfig();
	for(XplNode* node = p_Warning->FirstNode(); node != NULL ; node = p_Warning->NextNode()){
		copy->get_Warning()->InsertAtEnd(node->Clone());
	}
	for(XplNode* node = p_Error->FirstNode(); node != NULL ; node = p_Error->NextNode()){
		copy->get_Error()->InsertAtEnd(node->Clone());
	}
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplLayerDErrorInterchangeConfig::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_Warning!=NULL)if(!p_Warning->Write(writer))result=false;
	if(p_Error!=NULL)if(!p_Error->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplLayerDErrorInterchangeConfig::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos

//Funciones para obtener Elementos de Secuencia
XplNodeList* XplLayerDErrorInterchangeConfig::get_Warning(){
	return p_Warning;
}
XplNodeList* XplLayerDErrorInterchangeConfig::get_Error(){
	return p_Error;
}

//Funciones para setear Atributos

//Funciones para setear Elementos de Secuencia
	bool XplLayerDErrorInterchangeConfig::acceptInsertNodeCallback_Warning(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("Warning")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEERROR){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplError'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplError'."));
		return false;
	}
	bool XplLayerDErrorInterchangeConfig::acceptRemoveNodeCallback_Warning(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}
	bool XplLayerDErrorInterchangeConfig::acceptInsertNodeCallback_Error(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("Error")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEERROR){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplError'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplError'."));
		return false;
	}
	bool XplLayerDErrorInterchangeConfig::acceptRemoveNodeCallback_Error(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}
XplError* XplLayerDErrorInterchangeConfig::new_Warning(){
	XplError* node = new XplError();
	node->set_ElementName(DT("Warning"));
	return node;
}
XplError* XplLayerDErrorInterchangeConfig::new_Error(){
	XplError* node = new XplError();
	node->set_ElementName(DT("Error"));
	return node;
}

}

#endif
