/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOELAYERDZOEDOCUMENTCONFIG_V1_0
#define __LAYERD_CODEDOM_ZOELAYERDZOEDOCUMENTCONFIG_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplLayerDZoeDocumentConfig: public  XplNode{
private:
	//Variables para Atributos
	string p_programName;
	string p_programConfig;
	//Variables para Elementos de Secuencia
	XplLanguage* p_Language;
	XplLayerDCompiler* p_LayerDCompiler;
	XplNodeList* p_History;
public:
	//Region de Constructores Publicos
	XplLayerDZoeDocumentConfig();
	XplLayerDZoeDocumentConfig(XplLanguage* n_Language, XplLayerDCompiler* n_LayerDCompiler);
	XplLayerDZoeDocumentConfig(string n_programName, string n_programConfig);
	XplLayerDZoeDocumentConfig(XplLanguage* n_Language, XplLayerDCompiler* n_LayerDCompiler, XplNodeList* n_History);
	XplLayerDZoeDocumentConfig(string n_programName, string n_programConfig, XplLanguage* n_Language, XplLayerDCompiler* n_LayerDCompiler);
	XplLayerDZoeDocumentConfig(string n_programName, string n_programConfig, XplLanguage* n_Language, XplLayerDCompiler* n_LayerDCompiler, XplNodeList* n_History);
	//Destructor
	~XplLayerDZoeDocumentConfig();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOELAYERDZOEDOCUMENTCONFIG;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_programName();
	string get_programConfig();
	//Funciones para obtener Elementos de Secuencia
	XplLanguage* get_Language();
	XplLayerDCompiler* get_LayerDCompiler();
	XplNodeList* get_History();
public:
	//Funciones para setear Atributos
	string set_programName(string new_programName);
	string set_programConfig(string new_programConfig);
	//Funciones para setear Elementos de Secuencia
	XplLanguage* set_Language(XplLanguage* new_Language);
	XplLayerDCompiler* set_LayerDCompiler(XplLayerDCompiler* new_LayerDCompiler);
protected:
	static bool acceptInsertNodeCallback_History(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_History(XplNode* node, string* errorMsg, XplNode* parent);
public:
	static XplLanguage* new_Language();
	static XplLayerDCompiler* new_LayerDCompiler();
	static XplFileData* new_History();
};	//Fin declaración de Clase

}

#endif
