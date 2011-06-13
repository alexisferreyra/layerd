/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOESWITCHSTATEMENT_V1_0
#define __LAYERD_CODEDOM_ZOESWITCHSTATEMENT_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplSwitchStatement: public  XplNode{
private:
	//Variables para Atributos
	bool p_autobreak;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplExpression* p_e;
	XplNodeList* p_case;
public:
	//Region de Constructores Publicos
	XplSwitchStatement();
	XplSwitchStatement(bool n_autobreak);
	XplSwitchStatement(XplExpression* n_e, XplNodeList* n_case);
	XplSwitchStatement(bool n_autobreak, XplExpression* n_e, XplNodeList* n_case);
	XplSwitchStatement(bool n_autobreak, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplSwitchStatement(bool n_autobreak, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplExpression* n_e, XplNodeList* n_case);
	//Destructor
	~XplSwitchStatement();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOESWITCHSTATEMENT;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	bool get_autobreak();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	//Funciones para obtener Elementos de Secuencia
	XplExpression* get_e();
	XplNodeList* get_case();
public:
	//Funciones para setear Atributos
	bool set_autobreak(bool new_autobreak);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
	XplExpression* set_e(XplExpression* new_e);
protected:
	static bool acceptInsertNodeCallback_case(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_case(XplNode* node, string* errorMsg, XplNode* parent);
public:
	static XplExpression* new_e();
	static XplCase* new_case();
};	//Fin declaración de Clase

}

#endif
