/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEFORSTATEMENT_V1_0
#define __LAYERD_CODEDOM_ZOEFORSTATEMENT_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplForStatement: public  XplNode{
private:
	//Variables para Atributos
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplForinit* p_init;
	XplExpression* p_condition;
	XplExpressionlist* p_repeat;
	XplFunctionBody* p_forblock;
public:
	//Region de Constructores Publicos
	XplForStatement();
	XplForStatement(XplForinit* n_init, XplExpression* n_condition, XplExpressionlist* n_repeat, XplFunctionBody* n_forblock);
	XplForStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplForStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplForinit* n_init, XplExpression* n_condition, XplExpressionlist* n_repeat, XplFunctionBody* n_forblock);
	//Destructor
	~XplForStatement();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEFORSTATEMENT;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	//Funciones para obtener Elementos de Secuencia
	XplForinit* get_init();
	XplExpression* get_condition();
	XplExpressionlist* get_repeat();
	XplFunctionBody* get_forblock();
public:
	//Funciones para setear Atributos
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
	XplForinit* set_init(XplForinit* new_init);
	XplExpression* set_condition(XplExpression* new_condition);
	XplExpressionlist* set_repeat(XplExpressionlist* new_repeat);
	XplFunctionBody* set_forblock(XplFunctionBody* new_forblock);
	static XplForinit* new_init();
	static XplExpression* new_condition();
	static XplExpressionlist* new_repeat();
	static XplFunctionBody* new_forblock();
};	//Fin declaración de Clase

}

#endif
