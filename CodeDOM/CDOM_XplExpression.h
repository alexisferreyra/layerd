/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEEXPRESSION_V1_0
#define __LAYERD_CODEDOM_ZOEEXPRESSION_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplExpression: public  XplNode{
private:
	//Variables para Atributos
	string p_typeStr;
	string p_valueStr;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;

	//Variables para Elementos de Choice
	XplNode* p_texpression;
public:
	//Region de Constructores Publicos
	XplExpression();
	XplExpression(string n_typeStr, string n_valueStr, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplExpression(XplNode* n_texpression);
	XplExpression(string n_typeStr, string n_valueStr, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNode* n_texpression);
	//Destructor
	~XplExpression();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEEXPRESSION;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_typeStr();
	string get_valueStr();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();

	//Funciones para obtener Elementos de Choice
	XplNode* get_texpression();
public:
	//Funciones para setear Atributos
	string set_typeStr(string new_typeStr);
	string set_valueStr(string new_valueStr);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);

	//Funciones para setear Elementos de Choice
	XplNode* set_texpression(XplNode* new_texpression);
	static XplAssing* new_a();
	static XplNewExpression* new_new();
	static XplBinaryoperator* new_bo();
	static XplUnaryoperator* new_uo();
	static XplTernaryoperator* new_to();
	static XplFunctioncall* new_b();
	static XplNode* new_n();
	static XplLiteral* new_lit();
	static XplFunctioncall* new_fc();
	static XplComplexfunctioncall* new_cfc();
	static XplCastexpression* new_cast();
	static XplExpression* new_delete();
	static XplExpression* new_onpointer();
	static XplWriteCodeBody* new_writecode();
	static XplType* new_t();
	static XplType* new_toft();
	static XplCastexpression* new_is();
	static XplNode* new_empty();
};	//Fin declaración de Clase

}

#endif
