/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOECASE_V1_0
#define __LAYERD_CODEDOM_ZOECASE_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplCase: public  XplNode{
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
	XplExpression* p_e;
	XplFunctionBody* p_bk;
public:
	//Region de Constructores Publicos
	XplCase();
	XplCase(XplExpression* n_e, XplFunctionBody* n_bk);
	XplCase(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplCase(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_e, XplFunctionBody* n_bk);
	//Destructor
	~XplCase();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOECASE;}
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
	XplExpression* get_e();
	XplFunctionBody* get_bk();
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
	XplExpression* set_e(XplExpression* new_e);
	XplFunctionBody* set_bk(XplFunctionBody* new_bk);
	static XplExpression* new_e();
	static XplFunctionBody* new_bk();
};	//Fin declaración de Clase

}

#endif
