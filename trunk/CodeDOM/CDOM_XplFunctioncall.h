/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEFUNCTIONCALL_V1_0
#define __LAYERD_CODEDOM_ZOEFUNCTIONCALL_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplFunctioncall: public  XplNode{
private:
	//Variables para Atributos
	string p_name;
	string p_targetClass;
	string p_targetMember;
	string p_targetClassExternalName;
	string p_targetMemberExternalName;
	string p_ldxplcMods;
	bool p_ignoreforsubprogram;
	bool p_evaluateBlock;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplExpression* p_l;
	XplExpressionlist* p_args;
	XplFunctionBody* p_bk;
public:
	//Region de Constructores Publicos
	XplFunctioncall();
	XplFunctioncall(bool n_ignoreforsubprogram, bool n_evaluateBlock);
	XplFunctioncall(XplExpression* n_l, XplFunctionBody* n_bk);
	XplFunctioncall(bool n_ignoreforsubprogram, bool n_evaluateBlock, XplExpression* n_l, XplFunctionBody* n_bk);
	XplFunctioncall(string n_name, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, string n_ldxplcMods, bool n_ignoreforsubprogram, bool n_evaluateBlock, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplFunctioncall(XplExpression* n_l, XplExpressionlist* n_args, XplFunctionBody* n_bk);
	XplFunctioncall(string n_name, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, string n_ldxplcMods, bool n_ignoreforsubprogram, bool n_evaluateBlock, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_l, XplFunctionBody* n_bk);
	XplFunctioncall(bool n_ignoreforsubprogram, bool n_evaluateBlock, XplExpression* n_l, XplExpressionlist* n_args, XplFunctionBody* n_bk);
	XplFunctioncall(string n_name, string n_targetClass, string n_targetMember, string n_targetClassExternalName, string n_targetMemberExternalName, string n_ldxplcMods, bool n_ignoreforsubprogram, bool n_evaluateBlock, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_l, XplExpressionlist* n_args, XplFunctionBody* n_bk);
	//Destructor
	~XplFunctioncall();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEFUNCTIONCALL;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_name();
	string get_targetClass();
	string get_targetMember();
	string get_targetClassExternalName();
	string get_targetMemberExternalName();
	string get_ldxplcMods();
	bool get_ignoreforsubprogram();
	bool get_evaluateBlock();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	//Funciones para obtener Elementos de Secuencia
	XplExpression* get_l();
	XplExpressionlist* get_args();
	XplFunctionBody* get_bk();
public:
	//Funciones para setear Atributos
	string set_name(string new_name);
	string set_targetClass(string new_targetClass);
	string set_targetMember(string new_targetMember);
	string set_targetClassExternalName(string new_targetClassExternalName);
	string set_targetMemberExternalName(string new_targetMemberExternalName);
	string set_ldxplcMods(string new_ldxplcMods);
	bool set_ignoreforsubprogram(bool new_ignoreforsubprogram);
	bool set_evaluateBlock(bool new_evaluateBlock);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
	XplExpression* set_l(XplExpression* new_l);
	XplExpressionlist* set_args(XplExpressionlist* new_args);
	XplFunctionBody* set_bk(XplFunctionBody* new_bk);
	static XplExpression* new_l();
	static XplExpressionlist* new_args();
	static XplFunctionBody* new_bk();
};	//Fin declaración de Clase

}

#endif
