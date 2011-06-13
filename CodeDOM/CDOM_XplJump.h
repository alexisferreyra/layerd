/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEJUMP_V1_0
#define __LAYERD_CODEDOM_ZOEJUMP_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplJump: public  XplNode{
private:
	//Variables para Atributos
	XplJumptype_enum p_type;
	string p_label;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
public:
	//Region de Constructores Publicos
	XplJump();
	XplJump(XplJumptype_enum n_type);
	XplJump(XplJumptype_enum n_type, string n_label, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	//Destructor
	~XplJump();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEJUMP;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	XplJumptype_enum get_type();
	string get_label();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
public:
	//Funciones para setear Atributos
	XplJumptype_enum set_type(XplJumptype_enum new_type);
	string set_label(string new_label);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
};	//Fin declaración de Clase

}

#endif
