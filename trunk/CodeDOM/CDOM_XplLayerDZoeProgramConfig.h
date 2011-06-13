/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOELAYERDZOEPROGRAMCONFIG_V1_0
#define __LAYERD_CODEDOM_ZOELAYERDZOEPROGRAMCONFIG_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplLayerDZoeProgramConfig: public  XplNode{
private:
	//Variables para Atributos
	string p_name;
	XplLayerDZoeProgramModuletype_enum p_moduleType;
	string p_defaultPlatform;
	string p_mainProcedureFileName;
	string p_defaultOutputFileName;
	//Variables para Elementos de Secuencia
	XplNodeList* p_SourceFile;
	XplNodeList* p_OutputPlatform;
	XplNodeList* p_PlatformAlias;
	XplLayerDZoeProgramRequirements* p_ProgramRequirements;
public:
	//Region de Constructores Publicos
	XplLayerDZoeProgramConfig();
	XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType);
	XplLayerDZoeProgramConfig(XplNodeList* n_SourceFile, XplNodeList* n_OutputPlatform, XplLayerDZoeProgramRequirements* n_ProgramRequirements);
	XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, XplNodeList* n_SourceFile, XplNodeList* n_OutputPlatform, XplLayerDZoeProgramRequirements* n_ProgramRequirements);
	XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, string n_defaultPlatform, string n_mainProcedureFileName, string n_defaultOutputFileName);
	XplLayerDZoeProgramConfig(XplNodeList* n_SourceFile, XplNodeList* n_OutputPlatform, XplNodeList* n_PlatformAlias, XplLayerDZoeProgramRequirements* n_ProgramRequirements);
	XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, string n_defaultPlatform, string n_mainProcedureFileName, string n_defaultOutputFileName, XplNodeList* n_SourceFile, XplNodeList* n_OutputPlatform, XplLayerDZoeProgramRequirements* n_ProgramRequirements);
	XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, XplNodeList* n_SourceFile, XplNodeList* n_OutputPlatform, XplNodeList* n_PlatformAlias, XplLayerDZoeProgramRequirements* n_ProgramRequirements);
	XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, string n_defaultPlatform, string n_mainProcedureFileName, string n_defaultOutputFileName, XplNodeList* n_SourceFile, XplNodeList* n_OutputPlatform, XplNodeList* n_PlatformAlias, XplLayerDZoeProgramRequirements* n_ProgramRequirements);
	//Destructor
	~XplLayerDZoeProgramConfig();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOELAYERDZOEPROGRAMCONFIG;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_name();
	XplLayerDZoeProgramModuletype_enum get_moduleType();
	string get_defaultPlatform();
	string get_mainProcedureFileName();
	string get_defaultOutputFileName();
	//Funciones para obtener Elementos de Secuencia
	XplNodeList* get_SourceFile();
	XplNodeList* get_OutputPlatform();
	XplNodeList* get_PlatformAlias();
	XplLayerDZoeProgramRequirements* get_ProgramRequirements();
public:
	//Funciones para setear Atributos
	string set_name(string new_name);
	XplLayerDZoeProgramModuletype_enum set_moduleType(XplLayerDZoeProgramModuletype_enum new_moduleType);
	string set_defaultPlatform(string new_defaultPlatform);
	string set_mainProcedureFileName(string new_mainProcedureFileName);
	string set_defaultOutputFileName(string new_defaultOutputFileName);
	//Funciones para setear Elementos de Secuencia
protected:
	static bool acceptInsertNodeCallback_SourceFile(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_SourceFile(XplNode* node, string* errorMsg, XplNode* parent);
public:
protected:
	static bool acceptInsertNodeCallback_OutputPlatform(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_OutputPlatform(XplNode* node, string* errorMsg, XplNode* parent);
public:
protected:
	static bool acceptInsertNodeCallback_PlatformAlias(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_PlatformAlias(XplNode* node, string* errorMsg, XplNode* parent);
public:
	XplLayerDZoeProgramRequirements* set_ProgramRequirements(XplLayerDZoeProgramRequirements* new_ProgramRequirements);
	static XplSourceFile* new_SourceFile();
	static XplTargetPlatform* new_OutputPlatform();
	static XplPlatformAlias* new_PlatformAlias();
	static XplLayerDZoeProgramRequirements* new_ProgramRequirements();
};	//Fin declaración de Clase

}

#endif
