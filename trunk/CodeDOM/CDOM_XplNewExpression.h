/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOENEWEXPRESSION_V1_0
#define __LAYERD_CODEDOM_ZOENEWEXPRESSION_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplNewExpression: public  XplNode{
private:
	//Variables para Atributos
	string p_GCName;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplType* p_type;
	XplInitializerList* p_init;
	XplExpressionlist* p_GCParams;
public:
	//Region de Constructores Publicos
	XplNewExpression();
	XplNewExpression(string n_GCName);
	XplNewExpression(XplType* n_type);
	XplNewExpression(string n_GCName, XplType* n_type);
	XplNewExpression(string n_GCName, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplNewExpression(XplType* n_type, XplInitializerList* n_init, XplExpressionlist* n_GCParams);
	XplNewExpression(string n_GCName, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type);
	XplNewExpression(string n_GCName, XplType* n_type, XplInitializerList* n_init, XplExpressionlist* n_GCParams);
	XplNewExpression(string n_GCName, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplType* n_type, XplInitializerList* n_init, XplExpressionlist* n_GCParams);
	//Destructor
	~XplNewExpression();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOENEWEXPRESSION;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_GCName();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	//Funciones para obtener Elementos de Secuencia
	XplType* get_type();
	XplInitializerList* get_init();
	XplExpressionlist* get_GCParams();
public:
	//Funciones para setear Atributos
	string set_GCName(string new_GCName);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
	XplType* set_type(XplType* new_type);
	XplInitializerList* set_init(XplInitializerList* new_init);
	XplExpressionlist* set_GCParams(XplExpressionlist* new_GCParams);
	static XplType* new_type();
	static XplInitializerList* new_init();
	static XplExpressionlist* new_GCParams();
};	//Fin declaración de Clase

}

#endif
