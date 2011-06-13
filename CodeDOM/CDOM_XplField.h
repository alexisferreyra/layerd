/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEFIELD_V1_0
#define __LAYERD_CODEDOM_ZOEFIELD_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplField: public  XplNode{
private:
	//Variables para Atributos
	string p_name;
	string p_internalname;
	string p_externalname;
	XplAccesstype_enum p_access;
	XplVarstorage_enum p_storage;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	bool p_donotrender;
	unsigned p_firstbit;
	unsigned p_lastbit;
	string p_address;
	bool p_atomicwrite;
	bool p_atomicread;
	bool p_isfactory;
	bool p_new;
	//Variables para Elementos de Secuencia
	XplType* p_type;
	XplInitializerList* p_i;
public:
	//Region de Constructores Publicos
	XplField();
	XplField(string n_name, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_donotrender, bool n_isfactory, bool n_new);
	XplField(XplType* n_type, XplInitializerList* n_i);
	XplField(string n_name, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_donotrender, bool n_isfactory, bool n_new, XplType* n_type, XplInitializerList* n_i);
	XplField(string n_name, string n_internalname, string n_externalname, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, bool n_donotrender, unsigned n_firstbit, unsigned n_lastbit, string n_address, bool n_atomicwrite, bool n_atomicread, bool n_isfactory, bool n_new);
	XplField(string n_name, string n_internalname, string n_externalname, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, bool n_donotrender, unsigned n_firstbit, unsigned n_lastbit, string n_address, bool n_atomicwrite, bool n_atomicread, bool n_isfactory, bool n_new, XplType* n_type, XplInitializerList* n_i);
	//Destructor
	~XplField();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEFIELD;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_name();
	string get_internalname();
	string get_externalname();
	XplAccesstype_enum get_access();
	XplVarstorage_enum get_storage();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	bool get_donotrender();
	unsigned get_firstbit();
	unsigned get_lastbit();
	string get_address();
	bool get_atomicwrite();
	bool get_atomicread();
	bool get_isfactory();
	bool get_new();
	//Funciones para obtener Elementos de Secuencia
	XplType* get_type();
	XplInitializerList* get_i();
public:
	//Funciones para setear Atributos
	string set_name(string new_name);
	string set_internalname(string new_internalname);
	string set_externalname(string new_externalname);
	XplAccesstype_enum set_access(XplAccesstype_enum new_access);
	XplVarstorage_enum set_storage(XplVarstorage_enum new_storage);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	bool set_donotrender(bool new_donotrender);
	unsigned set_firstbit(unsigned new_firstbit);
	unsigned set_lastbit(unsigned new_lastbit);
	string set_address(string new_address);
	bool set_atomicwrite(bool new_atomicwrite);
	bool set_atomicread(bool new_atomicread);
	bool set_isfactory(bool new_isfactory);
	bool set_new(bool new_new);
	//Funciones para setear Elementos de Secuencia
	XplType* set_type(XplType* new_type);
	XplInitializerList* set_i(XplInitializerList* new_i);
	static XplType* new_type();
	static XplInitializerList* new_i();
};	//Fin declaración de Clase

}

#endif
