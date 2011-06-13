/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOETYPE_V1_0
#define __LAYERD_CODEDOM_ZOETYPE_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplType: public  XplNode{
private:
	//Variables para Atributos
	string p_typename;
	bool p_ispointer;
	bool p_isarray;
	XplPointertype_enum p_pointertype;
	XplFactorytype_enum p_ftype;
	bool p_volatile;
	bool p_const;
	bool p_exec;
	string p_typeStr;
	bool p_replaceParent;
	bool p_customTypeCheck;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplType* p_dt;
	XplExpression* p_ae;
	XplPointerinfo* p_pi;
	XplFunctioncall* p_fc;
public:
	//Region de Constructores Publicos
	XplType();
	XplType(bool n_ispointer, bool n_isarray, XplPointertype_enum n_pointertype, XplFactorytype_enum n_ftype, bool n_volatile, bool n_const, bool n_exec, bool n_replaceParent, bool n_customTypeCheck);
	XplType(string n_typename, bool n_ispointer, bool n_isarray, XplPointertype_enum n_pointertype, XplFactorytype_enum n_ftype, bool n_volatile, bool n_const, bool n_exec, string n_typeStr, bool n_replaceParent, bool n_customTypeCheck, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplType(XplType* n_dt, XplExpression* n_ae, XplPointerinfo* n_pi, XplFunctioncall* n_fc);
	XplType(bool n_ispointer, bool n_isarray, XplPointertype_enum n_pointertype, XplFactorytype_enum n_ftype, bool n_volatile, bool n_const, bool n_exec, bool n_replaceParent, bool n_customTypeCheck, XplType* n_dt, XplExpression* n_ae, XplPointerinfo* n_pi, XplFunctioncall* n_fc);
	XplType(string n_typename, bool n_ispointer, bool n_isarray, XplPointertype_enum n_pointertype, XplFactorytype_enum n_ftype, bool n_volatile, bool n_const, bool n_exec, string n_typeStr, bool n_replaceParent, bool n_customTypeCheck, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_dt, XplExpression* n_ae, XplPointerinfo* n_pi, XplFunctioncall* n_fc);
	//Destructor
	~XplType();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOETYPE;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_typename();
	bool get_ispointer();
	bool get_isarray();
	XplPointertype_enum get_pointertype();
	XplFactorytype_enum get_ftype();
	bool get_volatile();
	bool get_const();
	bool get_exec();
	string get_typeStr();
	bool get_replaceParent();
	bool get_customTypeCheck();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	//Funciones para obtener Elementos de Secuencia
	XplType* get_dt();
	XplExpression* get_ae();
	XplPointerinfo* get_pi();
	XplFunctioncall* get_fc();
public:
	//Funciones para setear Atributos
	string set_typename(string new_typename);
	bool set_ispointer(bool new_ispointer);
	bool set_isarray(bool new_isarray);
	XplPointertype_enum set_pointertype(XplPointertype_enum new_pointertype);
	XplFactorytype_enum set_ftype(XplFactorytype_enum new_ftype);
	bool set_volatile(bool new_volatile);
	bool set_const(bool new_const);
	bool set_exec(bool new_exec);
	string set_typeStr(string new_typeStr);
	bool set_replaceParent(bool new_replaceParent);
	bool set_customTypeCheck(bool new_customTypeCheck);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
	XplType* set_dt(XplType* new_dt);
	XplExpression* set_ae(XplExpression* new_ae);
	XplPointerinfo* set_pi(XplPointerinfo* new_pi);
	XplFunctioncall* set_fc(XplFunctioncall* new_fc);
	static XplType* new_dt();
	static XplExpression* new_ae();
	static XplPointerinfo* new_pi();
	static XplFunctioncall* new_fc();
};	//Fin declaración de Clase

}

#endif
