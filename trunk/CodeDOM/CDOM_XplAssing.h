/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEASSING_V1_0
#define __LAYERD_CODEDOM_ZOEASSING_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplAssing: public  XplNode{
private:
	//Variables para Atributos
	XplAssingop_enum p_operation;
	string p_targetClass;
	string p_targetMember;
	bool p_ignoreforsubprogram;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplExpression* p_l;
	XplExpression* p_r;
public:
	//Region de Constructores Publicos
	XplAssing();
	XplAssing(XplAssingop_enum n_operation, bool n_ignoreforsubprogram);
	XplAssing(XplExpression* n_l, XplExpression* n_r);
	XplAssing(XplAssingop_enum n_operation, bool n_ignoreforsubprogram, XplExpression* n_l, XplExpression* n_r);
	XplAssing(XplAssingop_enum n_operation, string n_targetClass, string n_targetMember, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplAssing(XplAssingop_enum n_operation, string n_targetClass, string n_targetMember, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_l, XplExpression* n_r);
	//Destructor
	~XplAssing();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEASSING;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	XplAssingop_enum get_operation();
	string get_targetClass();
	string get_targetMember();
	bool get_ignoreforsubprogram();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	//Funciones para obtener Elementos de Secuencia
	XplExpression* get_l();
	XplExpression* get_r();
public:
	//Funciones para setear Atributos
	XplAssingop_enum set_operation(XplAssingop_enum new_operation);
	string set_targetClass(string new_targetClass);
	string set_targetMember(string new_targetMember);
	bool set_ignoreforsubprogram(bool new_ignoreforsubprogram);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
	XplExpression* set_l(XplExpression* new_l);
	XplExpression* set_r(XplExpression* new_r);
	static XplExpression* new_l();
	static XplExpression* new_r();
};	//Fin declaración de Clase

}

#endif
