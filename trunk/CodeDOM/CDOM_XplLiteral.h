/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOELITERAL_V1_0
#define __LAYERD_CODEDOM_ZOELITERAL_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplLiteral: public  XplNode{
private:
	//Variables para Atributos
	string p_str;
	XplLiteraltype_enum p_type;
	string p_subtype;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
public:
	//Region de Constructores Publicos
	XplLiteral();
	XplLiteral(string n_str, string n_subtype);
	XplLiteral(string n_str, XplLiteraltype_enum n_type, string n_subtype, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	//Destructor
	~XplLiteral();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOELITERAL;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_str();
	XplLiteraltype_enum get_type();
	string get_subtype();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
public:
	//Funciones para setear Atributos
	string set_str(string new_str);
	XplLiteraltype_enum set_type(XplLiteraltype_enum new_type);
	string set_subtype(string new_subtype);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
};	//Fin declaración de Clase

}

#endif
