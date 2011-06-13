/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEPLATFORM_V1_0
#define __LAYERD_CODEDOM_ZOEPLATFORM_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplPlatform: public  XplNode{
private:
	//Variables para Atributos
	string p_name;
	string p_version;
	XplPlatformMatch_enum p_match;
	string p_customMatcher;
public:
	//Region de Constructores Publicos
	XplPlatform();
	XplPlatform(string n_name, XplPlatformMatch_enum n_match);
	XplPlatform(string n_name, string n_version, XplPlatformMatch_enum n_match, string n_customMatcher);
	//Destructor
	~XplPlatform();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEPLATFORM;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_name();
	string get_version();
	XplPlatformMatch_enum get_match();
	string get_customMatcher();
public:
	//Funciones para setear Atributos
	string set_name(string new_name);
	string set_version(string new_version);
	XplPlatformMatch_enum set_match(XplPlatformMatch_enum new_match);
	string set_customMatcher(string new_customMatcher);
};	//Fin declaración de Clase

}

#endif
