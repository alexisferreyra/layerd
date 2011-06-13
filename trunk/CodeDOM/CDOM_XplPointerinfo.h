/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEPOINTERINFO_V1_0
#define __LAYERD_CODEDOM_ZOEPOINTERINFO_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplPointerinfo: public  XplNode{
private:
	//Variables para Atributos
	string p_memberof;
	bool p_const;
	bool p_volatile;
	bool p_ref;
	bool p_removeonvalue;
public:
	//Region de Constructores Publicos
	XplPointerinfo();
	XplPointerinfo(bool n_const, bool n_volatile, bool n_ref, bool n_removeonvalue);
	XplPointerinfo(string n_memberof, bool n_const, bool n_volatile, bool n_ref, bool n_removeonvalue);
	//Destructor
	~XplPointerinfo();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEPOINTERINFO;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_memberof();
	bool get_const();
	bool get_volatile();
	bool get_ref();
	bool get_removeonvalue();
public:
	//Funciones para setear Atributos
	string set_memberof(string new_memberof);
	bool set_const(bool new_const);
	bool set_volatile(bool new_volatile);
	bool set_ref(bool new_ref);
	bool set_removeonvalue(bool new_removeonvalue);
};	//Fin declaración de Clase

}

#endif
