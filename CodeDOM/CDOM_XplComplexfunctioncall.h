/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOECOMPLEXFUNCTIONCALL_V1_0
#define __LAYERD_CODEDOM_ZOECOMPLEXFUNCTIONCALL_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplComplexfunctioncall: public  XplNode{
private:
	//Variables para Atributos
	bool p_indexer;
	string p_targetClass;
	string p_targetMember;
	bool p_donotrender;
	bool p_evaluate;
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
	XplCexpression* p_ce;
	XplFunctionBody* p_fbk;
public:
	//Region de Constructores Publicos
	XplComplexfunctioncall();
	XplComplexfunctioncall(bool n_indexer, bool n_donotrender, bool n_evaluate, bool n_ignoreforsubprogram);
	XplComplexfunctioncall(XplExpression* n_l);
	XplComplexfunctioncall(bool n_indexer, bool n_donotrender, bool n_evaluate, bool n_ignoreforsubprogram, XplExpression* n_l);
	XplComplexfunctioncall(bool n_indexer, string n_targetClass, string n_targetMember, bool n_donotrender, bool n_evaluate, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplComplexfunctioncall(XplExpression* n_l, XplCexpression* n_ce, XplFunctionBody* n_fbk);
	XplComplexfunctioncall(bool n_indexer, string n_targetClass, string n_targetMember, bool n_donotrender, bool n_evaluate, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_l);
	XplComplexfunctioncall(bool n_indexer, bool n_donotrender, bool n_evaluate, bool n_ignoreforsubprogram, XplExpression* n_l, XplCexpression* n_ce, XplFunctionBody* n_fbk);
	XplComplexfunctioncall(bool n_indexer, string n_targetClass, string n_targetMember, bool n_donotrender, bool n_evaluate, bool n_ignoreforsubprogram, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_l, XplCexpression* n_ce, XplFunctionBody* n_fbk);
	//Destructor
	~XplComplexfunctioncall();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOECOMPLEXFUNCTIONCALL;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	bool get_indexer();
	string get_targetClass();
	string get_targetMember();
	bool get_donotrender();
	bool get_evaluate();
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
	XplCexpression* get_ce();
	XplFunctionBody* get_fbk();
public:
	//Funciones para setear Atributos
	bool set_indexer(bool new_indexer);
	string set_targetClass(string new_targetClass);
	string set_targetMember(string new_targetMember);
	bool set_donotrender(bool new_donotrender);
	bool set_evaluate(bool new_evaluate);
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
	XplCexpression* set_ce(XplCexpression* new_ce);
	XplFunctionBody* set_fbk(XplFunctionBody* new_fbk);
	static XplExpression* new_l();
	static XplCexpression* new_ce();
	static XplFunctionBody* new_fbk();
};	//Fin declaración de Clase

}

#endif
