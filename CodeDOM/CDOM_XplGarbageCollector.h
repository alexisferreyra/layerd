/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEGARBAGECOLLECTOR_V1_0
#define __LAYERD_CODEDOM_ZOEGARBAGECOLLECTOR_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplGarbageCollector: public  XplNode{
private:
	//Variables para Atributos
	string p_name;
	string p_description;
	string p_sourceFile;
	string p_xplCompilerData;
public:
	//Region de Constructores Publicos
	XplGarbageCollector();
	XplGarbageCollector(string n_name);
	XplGarbageCollector(string n_name, string n_description, string n_sourceFile, string n_xplCompilerData);
	//Destructor
	~XplGarbageCollector();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEGARBAGECOLLECTOR;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_name();
	string get_description();
	string get_sourceFile();
	string get_xplCompilerData();
public:
	//Funciones para setear Atributos
	string set_name(string new_name);
	string set_description(string new_description);
	string set_sourceFile(string new_sourceFile);
	string set_xplCompilerData(string new_xplCompilerData);
};	//Fin declaración de Clase

}

#endif
