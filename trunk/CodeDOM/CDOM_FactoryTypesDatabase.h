/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_FACTORYTYPESDATABASE_V1_0
#define __LAYERD_CODEDOM_FACTORYTYPESDATABASE_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class FactoryTypesDatabase: public  XplNode{
private:
	//Variables para Atributos
	int p_version;
	//Variables para Elementos de Secuencia
	XplNodeList* p_Childs;
public:
	//Region de Constructores Publicos
	FactoryTypesDatabase();
	FactoryTypesDatabase(int n_version);
	FactoryTypesDatabase(XplNodeList* n_Childs);
	FactoryTypesDatabase(int n_version, XplNodeList* n_Childs);
	//Destructor
	~FactoryTypesDatabase();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_FACTORYTYPESDATABASE;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	int get_version();
	//Funciones para obtener Elementos de Secuencia
	XplNodeList* Childs();
public:
	//Funciones para setear Atributos
	int set_version(int new_version);
	//Funciones para setear Elementos de Secuencia
protected:
	static bool acceptInsertNodeCallback_FactoryTypesDatabase(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_FactoryTypesDatabase(XplNode* node, string* errorMsg, XplNode* parent);
public:
	//Funciones para filtrado en Listas de Nodos
	XplNodeList* get_ClassfactoryNodeList();
	static ClassfactoryData* new_Classfactory();
};	//Fin declaración de Clase

}

#endif
