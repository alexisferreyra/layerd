/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_CLASSFACTORYDATA_V1_0
#define __LAYERD_CODEDOM_CLASSFACTORYDATA_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class ClassfactoryData: public  XplNode{
private:
	//Variables para Atributos
	string p_typeFullName;
	bool p_isInterface;
	bool p_isInteractive;
	bool p_active;
	string p_moduleFileName;
	string p_platforms;
	string p_zoeDocFileName;
public:
	//Region de Constructores Publicos
	ClassfactoryData();
	ClassfactoryData(string n_typeFullName, bool n_isInterface, bool n_isInteractive, bool n_active, string n_moduleFileName, string n_zoeDocFileName);
	ClassfactoryData(string n_typeFullName, bool n_isInterface, bool n_isInteractive, bool n_active, string n_moduleFileName, string n_platforms, string n_zoeDocFileName);
	//Destructor
	~ClassfactoryData();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_CLASSFACTORYDATA;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_typeFullName();
	bool get_isInterface();
	bool get_isInteractive();
	bool get_active();
	string get_moduleFileName();
	string get_platforms();
	string get_zoeDocFileName();
public:
	//Funciones para setear Atributos
	string set_typeFullName(string new_typeFullName);
	bool set_isInterface(bool new_isInterface);
	bool set_isInteractive(bool new_isInteractive);
	bool set_active(bool new_active);
	string set_moduleFileName(string new_moduleFileName);
	string set_platforms(string new_platforms);
	string set_zoeDocFileName(string new_zoeDocFileName);
};	//Fin declaración de Clase

}

#endif
