/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOETRYSTATEMENT_V1_0
#define __LAYERD_CODEDOM_ZOETRYSTATEMENT_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplTryStatement: public  XplNode{
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
	XplFunctionBody* p_trybk;
	XplNodeList* p_catchbk;
	XplFunctionBody* p_finallybk;
public:
	//Region de Constructores Publicos
	XplTryStatement();
	XplTryStatement(XplFunctionBody* n_trybk, XplNodeList* n_catchbk);
	XplTryStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplTryStatement(XplFunctionBody* n_trybk, XplNodeList* n_catchbk, XplFunctionBody* n_finallybk);
	XplTryStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplFunctionBody* n_trybk, XplNodeList* n_catchbk);
	XplTryStatement(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplFunctionBody* n_trybk, XplNodeList* n_catchbk, XplFunctionBody* n_finallybk);
	//Destructor
	~XplTryStatement();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOETRYSTATEMENT;}
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
	XplFunctionBody* get_trybk();
	XplNodeList* get_catchbk();
	XplFunctionBody* get_finallybk();
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
	XplFunctionBody* set_trybk(XplFunctionBody* new_trybk);
protected:
	static bool acceptInsertNodeCallback_catchbk(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_catchbk(XplNode* node, string* errorMsg, XplNode* parent);
public:
	XplFunctionBody* set_finallybk(XplFunctionBody* new_finallybk);
	static XplFunctionBody* new_trybk();
	static XplCatchStatement* new_catchbk();
	static XplFunctionBody* new_finallybk();
};	//Fin declaración de Clase

}

#endif
