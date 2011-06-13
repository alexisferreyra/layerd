/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEWRITECODEBODY_V1_0
#define __LAYERD_CODEDOM_ZOEWRITECODEBODY_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplWriteCodeBody: public  XplNode{
private:
	//Variables para Atributos
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;

	//Variables para Elementos de Choice
	XplNode* p_tWriteCodeBody;
public:
	//Region de Constructores Publicos
	XplWriteCodeBody();
	XplWriteCodeBody(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplWriteCodeBody(XplNode* n_tWriteCodeBody);
	XplWriteCodeBody(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNode* n_tWriteCodeBody);
	//Destructor
	~XplWriteCodeBody();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEWRITECODEBODY;}
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

	//Funciones para obtener Elementos de Choice
	XplNode* get_tWriteCodeBody();
public:
	//Funciones para setear Atributos
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);

	//Funciones para setear Elementos de Choice
	XplNode* set_tWriteCodeBody(XplNode* new_tWriteCodeBody);
	static XplFunctionBody* new_bk();
	static XplDocumentBody* new_progunit();
	static XplNamespace* new_namespace();
	static XplClassMembersList* new_classmembers();
	static XplClass* new_class();
	static XplExpression* new_e();
};	//Fin declaración de Clase

}

#endif
