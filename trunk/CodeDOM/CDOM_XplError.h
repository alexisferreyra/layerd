/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEERROR_V1_0
#define __LAYERD_CODEDOM_ZOEERROR_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplError: public  XplNode{
private:
	//Variables para Atributos
	string p_str;
	int p_level;
	string p_sourcefile;
	string p_sourcepos;
	XplErrorsourcetype_enum p_sourceType;
public:
	//Region de Constructores Publicos
	XplError();
	XplError(string n_str, int n_level, XplErrorsourcetype_enum n_sourceType);
	XplError(string n_str, int n_level, string n_sourcefile, string n_sourcepos, XplErrorsourcetype_enum n_sourceType);
	//Destructor
	~XplError();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEERROR;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_str();
	int get_level();
	string get_sourcefile();
	string get_sourcepos();
	XplErrorsourcetype_enum get_sourceType();
public:
	//Funciones para setear Atributos
	string set_str(string new_str);
	int set_level(int new_level);
	string set_sourcefile(string new_sourcefile);
	string set_sourcepos(string new_sourcepos);
	XplErrorsourcetype_enum set_sourceType(XplErrorsourcetype_enum new_sourceType);
};	//Fin declaración de Clase

}

#endif
