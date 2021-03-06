/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEBINARYOPERATOR_V1_0
#define __LAYERD_CODEDOM_ZOEBINARYOPERATOR_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplBinaryoperator: public  XplNode{
private:
	//Variables para Atributos
	XplBinaryoperators_enum p_op;
	string p_targetClass;
	string p_targetMember;
	string p_targetClassExternalName;
	string p_targetMemberExternalName;
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
	XplBinaryoperator();
	XplBinaryoperator(XplBinaryoperators_enum n_op, bool n_ignoreforsubprogram);
	XplBinaryoperator(XplExpression* n_l, XplExpression* n_r);
	XplBinaryoperator(XplBinaryoperators_enum n_op, bool n_ignoreforsubprogram, XplExpression* n_l, XplExpression* n_r);
	XplBinaryoperator(XplBinaryoperators_enum n_op, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplBinaryoperator(XplBinaryoperators_enum n_op, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_l, XplExpression* n_r);
	//Destructor
	~XplBinaryoperator();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEBINARYOPERATOR;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	XplBinaryoperators_enum get_op();
	string get_targetClass();
	string get_targetMember();
	string get_targetClassExternalName();
	string get_targetMemberExternalName();
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
	XplBinaryoperators_enum set_op(XplBinaryoperators_enum new_op);
	string set_targetClass(string new_targetClass);
	string set_targetMember(string new_targetMember);
	string set_targetClassExternalName(string new_targetClassExternalName);
	string set_targetMemberExternalName(string new_targetMemberExternalName);
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
