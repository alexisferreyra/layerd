/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEDOCUMENT_V1_0
#define __LAYERD_CODEDOM_ZOEDOCUMENT_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplDocument: public  XplNode{
private:
	//Variables para Atributos
	//Variables para Elementos de Secuencia
	XplDocumentData* p_DocumentData;
	XplDocumentBody* p_DocumentBody;
public:
	//Region de Constructores Publicos
	XplDocument();
	XplDocument(XplDocumentData* n_DocumentData, XplDocumentBody* n_DocumentBody);
	//Destructor
	~XplDocument();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEDOCUMENT;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	//Funciones para obtener Elementos de Secuencia
	XplDocumentData* get_DocumentData();
	XplDocumentBody* get_DocumentBody();
public:
	//Funciones para setear Atributos
	//Funciones para setear Elementos de Secuencia
	XplDocumentData* set_DocumentData(XplDocumentData* new_DocumentData);
	XplDocumentBody* set_DocumentBody(XplDocumentBody* new_DocumentBody);
	static XplDocumentData* new_DocumentData();
	static XplDocumentBody* new_DocumentBody();
};	//Fin declaración de Clase

}

#endif
