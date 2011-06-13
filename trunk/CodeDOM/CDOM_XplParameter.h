/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEPARAMETER_V1_0
#define __LAYERD_CODEDOM_ZOEPARAMETER_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplParameter: public  XplNode{
private:
	//Variables para Atributos
	string p_name;
	unsigned p_number;
	XplParameterdirection_enum p_direction;
	bool p_params;
	bool p_donotrender;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplType* p_type;
	XplInitializerList* p_i;
public:
	//Region de Constructores Publicos
	XplParameter();
	XplParameter(unsigned n_number, XplParameterdirection_enum n_direction, bool n_params, bool n_donotrender);
	XplParameter(XplType* n_type);
	XplParameter(unsigned n_number, XplParameterdirection_enum n_direction, bool n_params, bool n_donotrender, XplType* n_type);
	XplParameter(string n_name, unsigned n_number, XplParameterdirection_enum n_direction, bool n_params, bool n_donotrender, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplParameter(XplType* n_type, XplInitializerList* n_i);
	XplParameter(string n_name, unsigned n_number, XplParameterdirection_enum n_direction, bool n_params, bool n_donotrender, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type);
	XplParameter(unsigned n_number, XplParameterdirection_enum n_direction, bool n_params, bool n_donotrender, XplType* n_type, XplInitializerList* n_i);
	XplParameter(string n_name, unsigned n_number, XplParameterdirection_enum n_direction, bool n_params, bool n_donotrender, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type, XplInitializerList* n_i);
	//Destructor
	~XplParameter();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEPARAMETER;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_name();
	unsigned get_number();
	XplParameterdirection_enum get_direction();
	bool get_params();
	bool get_donotrender();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	//Funciones para obtener Elementos de Secuencia
	XplType* get_type();
	XplInitializerList* get_i();
public:
	//Funciones para setear Atributos
	string set_name(string new_name);
	unsigned set_number(unsigned new_number);
	XplParameterdirection_enum set_direction(XplParameterdirection_enum new_direction);
	bool set_params(bool new_params);
	bool set_donotrender(bool new_donotrender);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
	XplType* set_type(XplType* new_type);
	XplInitializerList* set_i(XplInitializerList* new_i);
	static XplType* new_type();
	static XplInitializerList* new_i();
};	//Fin declaración de Clase

}

#endif
