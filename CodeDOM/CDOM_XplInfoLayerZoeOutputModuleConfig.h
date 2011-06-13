/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEINFOLAYERZOEOUTPUTMODULECONFIG_V1_0
#define __LAYERD_CODEDOM_ZOEINFOLAYERZOEOUTPUTMODULECONFIG_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplInfoLayerZoeOutputModuleConfig: public  XplNode{
private:
	//Variables para Atributos
	string p_name;
	string p_especifiedClass;
	string p_defaultPlatform;
	//Variables para Elementos de Secuencia
	XplNodeList* p_SupportedPlatform;
	XplNodeList* p_PlatformAlias;
	XplOutputModuleCapabilities* p_Capabilities;
public:
	//Region de Constructores Publicos
	XplInfoLayerZoeOutputModuleConfig();
	XplInfoLayerZoeOutputModuleConfig(string n_name);
	XplInfoLayerZoeOutputModuleConfig(XplNodeList* n_SupportedPlatform, XplOutputModuleCapabilities* n_Capabilities);
	XplInfoLayerZoeOutputModuleConfig(string n_name, XplNodeList* n_SupportedPlatform, XplOutputModuleCapabilities* n_Capabilities);
	XplInfoLayerZoeOutputModuleConfig(string n_name, string n_especifiedClass, string n_defaultPlatform);
	XplInfoLayerZoeOutputModuleConfig(XplNodeList* n_SupportedPlatform, XplNodeList* n_PlatformAlias, XplOutputModuleCapabilities* n_Capabilities);
	XplInfoLayerZoeOutputModuleConfig(string n_name, string n_especifiedClass, string n_defaultPlatform, XplNodeList* n_SupportedPlatform, XplOutputModuleCapabilities* n_Capabilities);
	XplInfoLayerZoeOutputModuleConfig(string n_name, XplNodeList* n_SupportedPlatform, XplNodeList* n_PlatformAlias, XplOutputModuleCapabilities* n_Capabilities);
	XplInfoLayerZoeOutputModuleConfig(string n_name, string n_especifiedClass, string n_defaultPlatform, XplNodeList* n_SupportedPlatform, XplNodeList* n_PlatformAlias, XplOutputModuleCapabilities* n_Capabilities);
	//Destructor
	~XplInfoLayerZoeOutputModuleConfig();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEINFOLAYERZOEOUTPUTMODULECONFIG;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_name();
	string get_especifiedClass();
	string get_defaultPlatform();
	//Funciones para obtener Elementos de Secuencia
	XplNodeList* get_SupportedPlatform();
	XplNodeList* get_PlatformAlias();
	XplOutputModuleCapabilities* get_Capabilities();
public:
	//Funciones para setear Atributos
	string set_name(string new_name);
	string set_especifiedClass(string new_especifiedClass);
	string set_defaultPlatform(string new_defaultPlatform);
	//Funciones para setear Elementos de Secuencia
protected:
	static bool acceptInsertNodeCallback_SupportedPlatform(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_SupportedPlatform(XplNode* node, string* errorMsg, XplNode* parent);
public:
protected:
	static bool acceptInsertNodeCallback_PlatformAlias(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_PlatformAlias(XplNode* node, string* errorMsg, XplNode* parent);
public:
	XplOutputModuleCapabilities* set_Capabilities(XplOutputModuleCapabilities* new_Capabilities);
	static XplTargetPlatform* new_SupportedPlatform();
	static XplPlatformAlias* new_PlatformAlias();
	static XplOutputModuleCapabilities* new_Capabilities();
};	//Fin declaración de Clase

}

#endif
