/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOECONFIG_V1_0_CPP
#define __LAYERD_CODEDOM_ZOECONFIG_V1_0_CPP
#include "CDOM_XplConfig.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplConfig::XplConfig(){
	p_tConfig=NULL;
}
XplConfig::XplConfig(XplNode* n_tConfig){
	p_tConfig=NULL;
	set_tConfig(n_tConfig);
}
//Destructor
XplConfig::~XplConfig(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplConfig'");
#endif

	//Variables para Elementos de Choice
	if(p_tConfig!=NULL)delete p_tConfig;
}

//Funciones Sobreescritas de XplNode
XplNode* XplConfig::Clone(){
	XplConfig* copy = new XplConfig();

	//Variables para Elementos de Choice
	if(p_tConfig!=NULL)copy->set_tConfig(p_tConfig->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplConfig::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_tConfig!=NULL)if(!p_tConfig->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplConfig::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos

//Funciones para obtener Elementos de Choice
XplNode* XplConfig::get_tConfig(){
	return p_tConfig;
}

//Funciones para setear Atributos

//Funciones para setear Elementos de Choice
XplNode* XplConfig::set_tConfig(XplNode* new_tConfig){
	if(new_tConfig==NULL)return p_tConfig;
	XplNode* back_tConfig = p_tConfig;
	if(new_tConfig->get_ElementName()==DT("LayerD_Zoe_Document_Config")){
		if(new_tConfig->get_ContentTypeName()!=CODEDOMTYPES_ZOELAYERDZOEDOCUMENTCONFIG){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tConfig->get_ContentTypeNameString()+DT("' no es valido como componente de 'tConfig'."));
			return NULL;
		}
		p_tConfig = new_tConfig;
		p_tConfig->set_Parent(this);
		return back_tConfig;
	}
	if(new_tConfig->get_ElementName()==DT("Extended_LayerD_Zoe_Document_Config")){
		if(new_tConfig->get_ContentTypeName()!=CODEDOMTYPES_ZOEEXTENDEDLAYERDZOEDOCUMENTCONFIG){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tConfig->get_ContentTypeNameString()+DT("' no es valido como componente de 'tConfig'."));
			return NULL;
		}
		p_tConfig = new_tConfig;
		p_tConfig->set_Parent(this);
		return back_tConfig;
	}
	if(new_tConfig->get_ElementName()==DT("LayerD_Zoe_Program_Config")){
		if(new_tConfig->get_ContentTypeName()!=CODEDOMTYPES_ZOELAYERDZOEPROGRAMCONFIG){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tConfig->get_ContentTypeNameString()+DT("' no es valido como componente de 'tConfig'."));
			return NULL;
		}
		p_tConfig = new_tConfig;
		p_tConfig->set_Parent(this);
		return back_tConfig;
	}
	if(new_tConfig->get_ElementName()==DT("Import_Process_Config")){
		if(new_tConfig->get_ContentTypeName()!=CODEDOMTYPES_ZOEIMPORTPROCESSCONFIG){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tConfig->get_ContentTypeNameString()+DT("' no es valido como componente de 'tConfig'."));
			return NULL;
		}
		p_tConfig = new_tConfig;
		p_tConfig->set_Parent(this);
		return back_tConfig;
	}
	if(new_tConfig->get_ElementName()==DT("Info_LayerD_Zoe_Output_Module")){
		if(new_tConfig->get_ContentTypeName()!=CODEDOMTYPES_ZOEINFOLAYERZOEOUTPUTMODULECONFIG){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tConfig->get_ContentTypeNameString()+DT("' no es valido como componente de 'tConfig'."));
			return NULL;
		}
		p_tConfig = new_tConfig;
		p_tConfig->set_Parent(this);
		return back_tConfig;
	}
	if(new_tConfig->get_ElementName()==DT("Requirements_Extended_LayerD_Zoe")){
		if(new_tConfig->get_ContentTypeName()!=CODEDOMTYPES_ZOEEXTENDEDLAYERDZOEREQUIREMENTSCONFIG){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tConfig->get_ContentTypeNameString()+DT("' no es valido como componente de 'tConfig'."));
			return NULL;
		}
		p_tConfig = new_tConfig;
		p_tConfig->set_Parent(this);
		return back_tConfig;
	}
	if(new_tConfig->get_ElementName()==DT("LayerD_Error_Interchange_Config")){
		if(new_tConfig->get_ContentTypeName()!=CODEDOMTYPES_ZOELAYERDERRORINTERCHANGECONFIG){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tConfig->get_ContentTypeNameString()+DT("' no es valido como componente de 'tConfig'."));
			return NULL;
		}
		p_tConfig = new_tConfig;
		p_tConfig->set_Parent(this);
		return back_tConfig;
	}
	if(new_tConfig->get_ElementName()==DT("LayerD_Zoe_Virutal_Subprogram_Config")){
		if(new_tConfig->get_ContentTypeName()!=CODEDOMTYPES_ZOELAYERDZOEDOCUMENTCONFIG){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tConfig->get_ContentTypeNameString()+DT("' no es valido como componente de 'tConfig'."));
			return NULL;
		}
		p_tConfig = new_tConfig;
		p_tConfig->set_Parent(this);
		return back_tConfig;
	}
	if(new_tConfig->get_ElementName()==DT("LayerD_Zoe_Parameter_Document_Config")){
		if(new_tConfig->get_ContentTypeName()!=CODEDOMTYPES_ZOELAYERDZOEDOCUMENTCONFIG){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tConfig->get_ContentTypeNameString()+DT("' no es valido como componente de 'tConfig'."));
			return NULL;
		}
		p_tConfig = new_tConfig;
		p_tConfig->set_Parent(this);
		return back_tConfig;
	}
	this->set_ErrorString(DT("El elemento de nombre '")+new_tConfig->get_ElementName()+DT("' no es valido como componente de 'tConfig'."));
	return NULL;
}
XplLayerDZoeDocumentConfig* XplConfig::new_LayerD_Zoe_Document_Config(){
	XplLayerDZoeDocumentConfig* node = new XplLayerDZoeDocumentConfig();
	node->set_ElementName(DT("LayerD_Zoe_Document_Config"));
	return node;
}
XplExtendedLayerDZoeDocumentConfig* XplConfig::new_Extended_LayerD_Zoe_Document_Config(){
	XplExtendedLayerDZoeDocumentConfig* node = new XplExtendedLayerDZoeDocumentConfig();
	node->set_ElementName(DT("Extended_LayerD_Zoe_Document_Config"));
	return node;
}
XplLayerDZoeProgramConfig* XplConfig::new_LayerD_Zoe_Program_Config(){
	XplLayerDZoeProgramConfig* node = new XplLayerDZoeProgramConfig();
	node->set_ElementName(DT("LayerD_Zoe_Program_Config"));
	return node;
}
XplImportProcessConfig* XplConfig::new_Import_Process_Config(){
	XplImportProcessConfig* node = new XplImportProcessConfig();
	node->set_ElementName(DT("Import_Process_Config"));
	return node;
}
XplInfoLayerZoeOutputModuleConfig* XplConfig::new_Info_LayerD_Zoe_Output_Module(){
	XplInfoLayerZoeOutputModuleConfig* node = new XplInfoLayerZoeOutputModuleConfig();
	node->set_ElementName(DT("Info_LayerD_Zoe_Output_Module"));
	return node;
}
XplExtendedLayerDZoeRequirementsConfig* XplConfig::new_Requirements_Extended_LayerD_Zoe(){
	XplExtendedLayerDZoeRequirementsConfig* node = new XplExtendedLayerDZoeRequirementsConfig();
	node->set_ElementName(DT("Requirements_Extended_LayerD_Zoe"));
	return node;
}
XplLayerDErrorInterchangeConfig* XplConfig::new_LayerD_Error_Interchange_Config(){
	XplLayerDErrorInterchangeConfig* node = new XplLayerDErrorInterchangeConfig();
	node->set_ElementName(DT("LayerD_Error_Interchange_Config"));
	return node;
}
XplLayerDZoeDocumentConfig* XplConfig::new_LayerD_Zoe_Virutal_Subprogram_Config(){
	XplLayerDZoeDocumentConfig* node = new XplLayerDZoeDocumentConfig();
	node->set_ElementName(DT("LayerD_Zoe_Virutal_Subprogram_Config"));
	return node;
}
XplLayerDZoeDocumentConfig* XplConfig::new_LayerD_Zoe_Parameter_Document_Config(){
	XplLayerDZoeDocumentConfig* node = new XplLayerDZoeDocumentConfig();
	node->set_ElementName(DT("LayerD_Zoe_Parameter_Document_Config"));
	return node;
}

}

#endif
