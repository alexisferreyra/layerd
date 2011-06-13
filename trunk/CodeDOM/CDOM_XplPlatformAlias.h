/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEPLATFORMALIAS_V1_0
#define __LAYERD_CODEDOM_ZOEPLATFORMALIAS_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplPlatformAlias: public  XplNode{
private:
	//Variables para Atributos
	string p_standardName;
	string p_standardVersion;
	string p_configAlias;
public:
	//Region de Constructores Publicos
	XplPlatformAlias();
	XplPlatformAlias(string n_standardName, string n_configAlias);
	XplPlatformAlias(string n_standardName, string n_standardVersion, string n_configAlias);
	//Destructor
	~XplPlatformAlias();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEPLATFORMALIAS;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_standardName();
	string get_standardVersion();
	string get_configAlias();
public:
	//Funciones para setear Atributos
	string set_standardName(string new_standardName);
	string set_standardVersion(string new_standardVersion);
	string set_configAlias(string new_configAlias);
};	//Fin declaración de Clase

}

#endif
