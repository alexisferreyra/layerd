/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEEXTENDEDLAYERDZOEDOCUMENTCONFIG_V1_0
#define __LAYERD_CODEDOM_ZOEEXTENDEDLAYERDZOEDOCUMENTCONFIG_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplExtendedLayerDZoeDocumentConfig: public  XplNode{
private:
	//Variables para Atributos
	string p_platform;
	string p_outputFileName;
	int p_partNumber;
	string p_programName;
	string p_programConfig;
	//Variables para Elementos de Secuencia
	XplLanguage* p_Language;
	XplLayerDCompiler* p_LayerDCompiler;
	XplLayerDCompiler* p_LayerDZoeCompiler;
	XplNodeList* p_History;
public:
	//Region de Constructores Publicos
	XplExtendedLayerDZoeDocumentConfig();
	XplExtendedLayerDZoeDocumentConfig(string n_platform);
	XplExtendedLayerDZoeDocumentConfig(string n_platform, string n_outputFileName, int n_partNumber, string n_programName, string n_programConfig);
	XplExtendedLayerDZoeDocumentConfig(XplLanguage* n_Language, XplLayerDCompiler* n_LayerDCompiler, XplLayerDCompiler* n_LayerDZoeCompiler, XplNodeList* n_History);
	XplExtendedLayerDZoeDocumentConfig(string n_platform, XplLanguage* n_Language, XplLayerDCompiler* n_LayerDCompiler, XplLayerDCompiler* n_LayerDZoeCompiler, XplNodeList* n_History);
	XplExtendedLayerDZoeDocumentConfig(string n_platform, string n_outputFileName, int n_partNumber, string n_programName, string n_programConfig, XplLanguage* n_Language, XplLayerDCompiler* n_LayerDCompiler, XplLayerDCompiler* n_LayerDZoeCompiler, XplNodeList* n_History);
	//Destructor
	~XplExtendedLayerDZoeDocumentConfig();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEEXTENDEDLAYERDZOEDOCUMENTCONFIG;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_platform();
	string get_outputFileName();
	int get_partNumber();
	string get_programName();
	string get_programConfig();
	//Funciones para obtener Elementos de Secuencia
	XplLanguage* get_Language();
	XplLayerDCompiler* get_LayerDCompiler();
	XplLayerDCompiler* get_LayerDZoeCompiler();
	XplNodeList* get_History();
public:
	//Funciones para setear Atributos
	string set_platform(string new_platform);
	string set_outputFileName(string new_outputFileName);
	int set_partNumber(int new_partNumber);
	string set_programName(string new_programName);
	string set_programConfig(string new_programConfig);
	//Funciones para setear Elementos de Secuencia
	XplLanguage* set_Language(XplLanguage* new_Language);
	XplLayerDCompiler* set_LayerDCompiler(XplLayerDCompiler* new_LayerDCompiler);
	XplLayerDCompiler* set_LayerDZoeCompiler(XplLayerDCompiler* new_LayerDZoeCompiler);
protected:
	static bool acceptInsertNodeCallback_History(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_History(XplNode* node, string* errorMsg, XplNode* parent);
public:
	static XplLanguage* new_Language();
	static XplLayerDCompiler* new_LayerDCompiler();
	static XplLayerDCompiler* new_LayerDZoeCompiler();
	static XplFileData* new_History();
};	//Fin declaración de Clase

}

#endif
