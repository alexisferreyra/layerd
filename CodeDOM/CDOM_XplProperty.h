/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEPROPERTY_V1_0
#define __LAYERD_CODEDOM_ZOEPROPERTY_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplProperty: public  XplNode{
private:
	//Variables para Atributos
	string p_name;
	string p_getfunction;
	string p_setfunction;
	string p_internalname;
	string p_externalname;
	bool p_donotrender;
	XplAccesstype_enum p_access;
	XplVarstorage_enum p_storage;
	bool p_isfactory;
	bool p_isconst;
	bool p_isexec;
	bool p_virtual;
	bool p_nonvirtual;
	bool p_override;
	bool p_new;
	bool p_final;
	bool p_abstract;
	bool p_external;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplType* p_type;
	XplFunctionBody* p_body;
	XplDocumentation* p_documentation;
public:
	//Region de Constructores Publicos
	XplProperty();
	XplProperty(string n_name, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external);
	XplProperty(XplType* n_type);
	XplProperty(string n_name, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, XplType* n_type);
	XplProperty(string n_name, string n_getfunction, string n_setfunction, string n_internalname, string n_externalname, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplProperty(XplType* n_type, XplFunctionBody* n_body, XplDocumentation* n_documentation);
	XplProperty(string n_name, string n_getfunction, string n_setfunction, string n_internalname, string n_externalname, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type);
	XplProperty(string n_name, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, XplType* n_type, XplFunctionBody* n_body, XplDocumentation* n_documentation);
	XplProperty(string n_name, string n_getfunction, string n_setfunction, string n_internalname, string n_externalname, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_abstract, bool n_external, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type, XplFunctionBody* n_body, XplDocumentation* n_documentation);
	//Destructor
	~XplProperty();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEPROPERTY;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_name();
	string get_getfunction();
	string get_setfunction();
	string get_internalname();
	string get_externalname();
	bool get_donotrender();
	XplAccesstype_enum get_access();
	XplVarstorage_enum get_storage();
	bool get_isfactory();
	bool get_isconst();
	bool get_isexec();
	bool get_virtual();
	bool get_nonvirtual();
	bool get_override();
	bool get_new();
	bool get_final();
	bool get_abstract();
	bool get_external();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	//Funciones para obtener Elementos de Secuencia
	XplType* get_type();
	XplFunctionBody* get_body();
	XplDocumentation* get_documentation();
public:
	//Funciones para setear Atributos
	string set_name(string new_name);
	string set_getfunction(string new_getfunction);
	string set_setfunction(string new_setfunction);
	string set_internalname(string new_internalname);
	string set_externalname(string new_externalname);
	bool set_donotrender(bool new_donotrender);
	XplAccesstype_enum set_access(XplAccesstype_enum new_access);
	XplVarstorage_enum set_storage(XplVarstorage_enum new_storage);
	bool set_isfactory(bool new_isfactory);
	bool set_isconst(bool new_isconst);
	bool set_isexec(bool new_isexec);
	bool set_virtual(bool new_virtual);
	bool set_nonvirtual(bool new_nonvirtual);
	bool set_override(bool new_override);
	bool set_new(bool new_new);
	bool set_final(bool new_final);
	bool set_abstract(bool new_abstract);
	bool set_external(bool new_external);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
	XplType* set_type(XplType* new_type);
	XplFunctionBody* set_body(XplFunctionBody* new_body);
	XplDocumentation* set_documentation(XplDocumentation* new_documentation);
	static XplType* new_type();
	static XplFunctionBody* new_body();
	static XplDocumentation* new_documentation();
};	//Fin declaración de Clase

}

#endif
