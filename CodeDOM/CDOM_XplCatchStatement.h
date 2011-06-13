/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOECATCHSTATEMENT_V1_0
#define __LAYERD_CODEDOM_ZOECATCHSTATEMENT_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplCatchStatement: public  XplNode{
private:
	//Variables para Atributos
	bool p_default;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplCatchinit* p_init;
	XplFunctionBody* p_bk;
public:
	//Region de Constructores Publicos
	XplCatchStatement();
	XplCatchStatement(bool n_default);
	XplCatchStatement(XplCatchinit* n_init, XplFunctionBody* n_bk);
	XplCatchStatement(bool n_default, XplCatchinit* n_init, XplFunctionBody* n_bk);
	XplCatchStatement(bool n_default, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplCatchStatement(bool n_default, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplCatchinit* n_init, XplFunctionBody* n_bk);
	//Destructor
	~XplCatchStatement();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOECATCHSTATEMENT;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	bool get_default();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	//Funciones para obtener Elementos de Secuencia
	XplCatchinit* get_init();
	XplFunctionBody* get_bk();
public:
	//Funciones para setear Atributos
	bool set_default(bool new_default);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
	XplCatchinit* set_init(XplCatchinit* new_init);
	XplFunctionBody* set_bk(XplFunctionBody* new_bk);
	static XplCatchinit* new_init();
	static XplFunctionBody* new_bk();
};	//Fin declaración de Clase

}

#endif
