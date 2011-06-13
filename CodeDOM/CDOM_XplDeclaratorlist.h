/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEDECLARATORLIST_V1_0
#define __LAYERD_CODEDOM_ZOEDECLARATORLIST_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplDeclaratorlist: public  XplNode{
private:
	//Variables para Atributos
	//Variables para Elementos de Secuencia
	XplNodeList* p_Childs;
public:
	//Region de Constructores Publicos
	XplDeclaratorlist();
	XplDeclaratorlist(XplNodeList* n_Childs);
	//Destructor
	~XplDeclaratorlist();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEDECLARATORLIST;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	//Funciones para obtener Elementos de Secuencia
	XplNodeList* Childs();
public:
	//Funciones para setear Atributos
	//Funciones para setear Elementos de Secuencia
protected:
	static bool acceptInsertNodeCallback_tdeclaratorlist(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_tdeclaratorlist(XplNode* node, string* errorMsg, XplNode* parent);
public:
	//Funciones para filtrado en Listas de Nodos
	XplNodeList* get_dNodeList();
	static XplDeclarator* new_d();
};	//Fin declaración de Clase

}

#endif
