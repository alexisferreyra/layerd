/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOECASTEXPRESSION_V1_0
#define __LAYERD_CODEDOM_ZOECASTEXPRESSION_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplCastexpression: public  XplNode{
private:
	//Variables para Atributos
	string p_targetClass;
	string p_targetMember;
	string p_targetClassExternalName;
	string p_targetMemberExternalName;
	XplCasttype_enum p_castType;
	bool p_ignoreforsubprogram;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplExpression* p_e;
	XplType* p_type;
public:
	//Region de Constructores Publicos
	XplCastexpression();
	XplCastexpression(XplCasttype_enum n_castType, bool n_ignoreforsubprogram);
	XplCastexpression(XplExpression* n_e, XplType* n_type);
	XplCastexpression(XplCasttype_enum n_castType, bool n_ignoreforsubprogram, XplExpression* n_e, XplType* n_type);
	XplCastexpression(string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, XplCasttype_enum n_castType, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplCastexpression(string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, XplCasttype_enum n_castType, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_e, XplType* n_type);
	//Destructor
	~XplCastexpression();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOECASTEXPRESSION;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_targetClass();
	string get_targetMember();
	string get_targetClassExternalName();
	string get_targetMemberExternalName();
	XplCasttype_enum get_castType();
	bool get_ignoreforsubprogram();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	//Funciones para obtener Elementos de Secuencia
	XplExpression* get_e();
	XplType* get_type();
public:
	//Funciones para setear Atributos
	string set_targetClass(string new_targetClass);
	string set_targetMember(string new_targetMember);
	string set_targetClassExternalName(string new_targetClassExternalName);
	string set_targetMemberExternalName(string new_targetMemberExternalName);
	XplCasttype_enum set_castType(XplCasttype_enum new_castType);
	bool set_ignoreforsubprogram(bool new_ignoreforsubprogram);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
	XplExpression* set_e(XplExpression* new_e);
	XplType* set_type(XplType* new_type);
	static XplExpression* new_e();
	static XplType* new_type();
};	//Fin declaración de Clase

}

#endif
