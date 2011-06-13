/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEINHERIT_V1_0
#define __LAYERD_CODEDOM_ZOEINHERIT_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplInherit: public  XplNode{
private:
	//Variables para Atributos
	XplAccesstype_enum p_access;
	bool p_virtual;
	bool p_auto;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplType* p_type;
	XplType* p_originalType;
public:
	//Region de Constructores Publicos
	XplInherit();
	XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto);
	XplInherit(XplType* n_type);
	XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, XplType* n_type);
	XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplInherit(XplType* n_type, XplType* n_originalType);
	XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type);
	XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, XplType* n_type, XplType* n_originalType);
	XplInherit(XplAccesstype_enum n_access, bool n_virtual, bool n_auto, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type, XplType* n_originalType);
	//Destructor
	~XplInherit();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEINHERIT;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	XplAccesstype_enum get_access();
	bool get_virtual();
	bool get_auto();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	//Funciones para obtener Elementos de Secuencia
	XplType* get_type();
	XplType* get_originalType();
public:
	//Funciones para setear Atributos
	XplAccesstype_enum set_access(XplAccesstype_enum new_access);
	bool set_virtual(bool new_virtual);
	bool set_auto(bool new_auto);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
	XplType* set_type(XplType* new_type);
	XplType* set_originalType(XplType* new_originalType);
	static XplType* new_type();
	static XplType* new_originalType();
};	//Fin declaración de Clase

}

#endif
