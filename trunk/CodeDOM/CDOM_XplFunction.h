/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEFUNCTION_V1_0
#define __LAYERD_CODEDOM_ZOEFUNCTION_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplFunction: public  XplNode{
private:
	//Variables para Atributos
	string p_name;
	string p_internalname;
	string p_externalname;
	bool p_allowoptimize;
	bool p_donotrender;
	XplAccesstype_enum p_access;
	XplVarstorage_enum p_storage;
	bool p_isfactory;
	bool p_iskeyword;
	bool p_isconst;
	bool p_isexec;
	bool p_virtual;
	bool p_nonvirtual;
	bool p_override;
	bool p_new;
	bool p_final;
	bool p_force;
	bool p_abstract;
	bool p_fp;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplParameters* p_Parameters;
	XplType* p_ReturnType;
	XplFunctionBody* p_FunctionBody;
	XplBaseInitializers* p_BaseInitializers;
	XplDocumentation* p_documentation;
public:
	//Region de Constructores Publicos
	XplFunction();
	XplFunction(string n_name, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp);
	XplFunction(XplParameters* n_Parameters);
	XplFunction(string n_name, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, XplParameters* n_Parameters);
	XplFunction(string n_name, string n_internalname, string n_externalname, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplFunction(XplParameters* n_Parameters, XplType* n_ReturnType, XplFunctionBody* n_FunctionBody, XplBaseInitializers* n_BaseInitializers, XplDocumentation* n_documentation);
	XplFunction(string n_name, string n_internalname, string n_externalname, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplParameters* n_Parameters);
	XplFunction(string n_name, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, XplParameters* n_Parameters, XplType* n_ReturnType, XplFunctionBody* n_FunctionBody, XplBaseInitializers* n_BaseInitializers, XplDocumentation* n_documentation);
	XplFunction(string n_name, string n_internalname, string n_externalname, bool n_allowoptimize, bool n_donotrender, XplAccesstype_enum n_access, XplVarstorage_enum n_storage, bool n_isfactory, bool n_iskeyword, bool n_isconst, bool n_isexec, bool n_virtual, bool n_nonvirtual, bool n_override, bool n_new, bool n_final, bool n_force, bool n_abstract, bool n_fp, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplParameters* n_Parameters, XplType* n_ReturnType, XplFunctionBody* n_FunctionBody, XplBaseInitializers* n_BaseInitializers, XplDocumentation* n_documentation);
	//Destructor
	~XplFunction();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEFUNCTION;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_name();
	string get_internalname();
	string get_externalname();
	bool get_allowoptimize();
	bool get_donotrender();
	XplAccesstype_enum get_access();
	XplVarstorage_enum get_storage();
	bool get_isfactory();
	bool get_iskeyword();
	bool get_isconst();
	bool get_isexec();
	bool get_virtual();
	bool get_nonvirtual();
	bool get_override();
	bool get_new();
	bool get_final();
	bool get_force();
	bool get_abstract();
	bool get_fp();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	//Funciones para obtener Elementos de Secuencia
	XplParameters* get_Parameters();
	XplType* get_ReturnType();
	XplFunctionBody* get_FunctionBody();
	XplBaseInitializers* get_BaseInitializers();
	XplDocumentation* get_documentation();
public:
	//Funciones para setear Atributos
	string set_name(string new_name);
	string set_internalname(string new_internalname);
	string set_externalname(string new_externalname);
	bool set_allowoptimize(bool new_allowoptimize);
	bool set_donotrender(bool new_donotrender);
	XplAccesstype_enum set_access(XplAccesstype_enum new_access);
	XplVarstorage_enum set_storage(XplVarstorage_enum new_storage);
	bool set_isfactory(bool new_isfactory);
	bool set_iskeyword(bool new_iskeyword);
	bool set_isconst(bool new_isconst);
	bool set_isexec(bool new_isexec);
	bool set_virtual(bool new_virtual);
	bool set_nonvirtual(bool new_nonvirtual);
	bool set_override(bool new_override);
	bool set_new(bool new_new);
	bool set_final(bool new_final);
	bool set_force(bool new_force);
	bool set_abstract(bool new_abstract);
	bool set_fp(bool new_fp);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
	XplParameters* set_Parameters(XplParameters* new_Parameters);
	XplType* set_ReturnType(XplType* new_ReturnType);
	XplFunctionBody* set_FunctionBody(XplFunctionBody* new_FunctionBody);
	XplBaseInitializers* set_BaseInitializers(XplBaseInitializers* new_BaseInitializers);
	XplDocumentation* set_documentation(XplDocumentation* new_documentation);
	static XplParameters* new_Parameters();
	static XplType* new_ReturnType();
	static XplFunctionBody* new_FunctionBody();
	static XplBaseInitializers* new_BaseInitializers();
	static XplDocumentation* new_documentation();
};	//Fin declaración de Clase

}

#endif
