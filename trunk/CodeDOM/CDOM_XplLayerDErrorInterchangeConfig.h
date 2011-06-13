/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOELAYERDERRORINTERCHANGECONFIG_V1_0
#define __LAYERD_CODEDOM_ZOELAYERDERRORINTERCHANGECONFIG_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplLayerDErrorInterchangeConfig: public  XplNode{
private:
	//Variables para Atributos
	//Variables para Elementos de Secuencia
	XplNodeList* p_Warning;
	XplNodeList* p_Error;
public:
	//Region de Constructores Publicos
	XplLayerDErrorInterchangeConfig();
	XplLayerDErrorInterchangeConfig(XplNodeList* n_Warning, XplNodeList* n_Error);
	//Destructor
	~XplLayerDErrorInterchangeConfig();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOELAYERDERRORINTERCHANGECONFIG;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	//Funciones para obtener Elementos de Secuencia
	XplNodeList* get_Warning();
	XplNodeList* get_Error();
public:
	//Funciones para setear Atributos
	//Funciones para setear Elementos de Secuencia
protected:
	static bool acceptInsertNodeCallback_Warning(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_Warning(XplNode* node, string* errorMsg, XplNode* parent);
public:
protected:
	static bool acceptInsertNodeCallback_Error(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_Error(XplNode* node, string* errorMsg, XplNode* parent);
public:
	static XplError* new_Warning();
	static XplError* new_Error();
};	//Fin declaración de Clase

}

#endif
