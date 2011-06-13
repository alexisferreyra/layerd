/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOETERNARYOPERATOR_V1_0
#define __LAYERD_CODEDOM_ZOETERNARYOPERATOR_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplTernaryoperator: public  XplNode{
private:
	//Variables para Atributos
	XplTernaryoperators_enum p_op;
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
	XplExpression* p_o1;
	XplExpression* p_o2;
	XplExpression* p_o3;
public:
	//Region de Constructores Publicos
	XplTernaryoperator();
	XplTernaryoperator(XplTernaryoperators_enum n_op, bool n_ignoreforsubprogram);
	XplTernaryoperator(XplExpression* n_o1, XplExpression* n_o2, XplExpression* n_o3);
	XplTernaryoperator(XplTernaryoperators_enum n_op, bool n_ignoreforsubprogram, XplExpression* n_o1, XplExpression* n_o2, XplExpression* n_o3);
	XplTernaryoperator(XplTernaryoperators_enum n_op, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplTernaryoperator(XplTernaryoperators_enum n_op, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_o1, XplExpression* n_o2, XplExpression* n_o3);
	//Destructor
	~XplTernaryoperator();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOETERNARYOPERATOR;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	XplTernaryoperators_enum get_op();
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
	XplExpression* get_o1();
	XplExpression* get_o2();
	XplExpression* get_o3();
public:
	//Funciones para setear Atributos
	XplTernaryoperators_enum set_op(XplTernaryoperators_enum new_op);
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
	XplExpression* set_o1(XplExpression* new_o1);
	XplExpression* set_o2(XplExpression* new_o2);
	XplExpression* set_o3(XplExpression* new_o3);
	static XplExpression* new_o1();
	static XplExpression* new_o2();
	static XplExpression* new_o3();
};	//Fin declaración de Clase

}

#endif
