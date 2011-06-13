/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEDECLARATOR_V1_0
#define __LAYERD_CODEDOM_ZOEDECLARATOR_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplDeclarator: public  XplNode{
private:
	//Variables para Atributos
	string p_name;
	string p_internalname;
	string p_externalname;
	bool p_donotrender;
	XplVarstorage_enum p_storage;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	string p_address;
	bool p_atomicwrite;
	bool p_atomicread;
	//Variables para Elementos de Secuencia
	XplType* p_type;
	XplNode* p_aliasref;
	XplInitializerList* p_i;
public:
	//Region de Constructores Publicos
	XplDeclarator();
	XplDeclarator(string n_name, string n_internalname, string n_externalname, bool n_donotrender, XplVarstorage_enum n_storage, bool n_atomicwrite, bool n_atomicread);
	XplDeclarator(string n_name, string n_internalname, string n_externalname, bool n_donotrender, XplVarstorage_enum n_storage, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, string n_address, bool n_atomicwrite, bool n_atomicread);
	XplDeclarator(XplType* n_type, XplNode* n_aliasref, XplInitializerList* n_i);
	XplDeclarator(string n_name, string n_internalname, string n_externalname, bool n_donotrender, XplVarstorage_enum n_storage, bool n_atomicwrite, bool n_atomicread, XplType* n_type, XplNode* n_aliasref, XplInitializerList* n_i);
	XplDeclarator(string n_name, string n_internalname, string n_externalname, bool n_donotrender, XplVarstorage_enum n_storage, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, string n_address, bool n_atomicwrite, bool n_atomicread, XplType* n_type, XplNode* n_aliasref, XplInitializerList* n_i);
	//Destructor
	~XplDeclarator();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEDECLARATOR;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_name();
	string get_internalname();
	string get_externalname();
	bool get_donotrender();
	XplVarstorage_enum get_storage();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	string get_address();
	bool get_atomicwrite();
	bool get_atomicread();
	//Funciones para obtener Elementos de Secuencia
	XplType* get_type();
	XplNode* get_aliasref();
	XplInitializerList* get_i();
public:
	//Funciones para setear Atributos
	string set_name(string new_name);
	string set_internalname(string new_internalname);
	string set_externalname(string new_externalname);
	bool set_donotrender(bool new_donotrender);
	XplVarstorage_enum set_storage(XplVarstorage_enum new_storage);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	string set_address(string new_address);
	bool set_atomicwrite(bool new_atomicwrite);
	bool set_atomicread(bool new_atomicread);
	//Funciones para setear Elementos de Secuencia
	XplType* set_type(XplType* new_type);
	XplNode* set_aliasref(XplNode* new_aliasref);
	XplInitializerList* set_i(XplInitializerList* new_i);
	static XplType* new_type();
	static XplNode* new_aliasref();
	static XplInitializerList* new_i();
};	//Fin declaración de Clase

}

#endif
