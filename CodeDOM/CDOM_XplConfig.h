/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOECONFIG_V1_0
#define __LAYERD_CODEDOM_ZOECONFIG_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplConfig: public  XplNode{
private:
	//Variables para Atributos

	//Variables para Elementos de Choice
	XplNode* p_tConfig;
public:
	//Region de Constructores Publicos
	XplConfig();
	XplConfig(XplNode* n_tConfig);
	//Destructor
	~XplConfig();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOECONFIG;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos

	//Funciones para obtener Elementos de Choice
	XplNode* get_tConfig();
public:
	//Funciones para setear Atributos

	//Funciones para setear Elementos de Choice
	XplNode* set_tConfig(XplNode* new_tConfig);
	static XplLayerDZoeDocumentConfig* new_LayerD_Zoe_Document_Config();
	static XplExtendedLayerDZoeDocumentConfig* new_Extended_LayerD_Zoe_Document_Config();
	static XplLayerDZoeProgramConfig* new_LayerD_Zoe_Program_Config();
	static XplImportProcessConfig* new_Import_Process_Config();
	static XplInfoLayerZoeOutputModuleConfig* new_Info_LayerD_Zoe_Output_Module();
	static XplExtendedLayerDZoeRequirementsConfig* new_Requirements_Extended_LayerD_Zoe();
	static XplLayerDErrorInterchangeConfig* new_LayerD_Error_Interchange_Config();
	static XplLayerDZoeDocumentConfig* new_LayerD_Zoe_Virutal_Subprogram_Config();
	static XplLayerDZoeDocumentConfig* new_LayerD_Zoe_Parameter_Document_Config();
};	//Fin declaración de Clase

}

#endif
