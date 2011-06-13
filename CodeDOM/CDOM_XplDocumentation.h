/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEDOCUMENTATION_V1_0
#define __LAYERD_CODEDOM_ZOEDOCUMENTATION_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplDocumentation: public  XplNode{
private:
	//Variables para Atributos
	string p_short;
	string p_source;
	string p_key;
	XplDocsourcetype_enum p_sourcetype;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplNode* p_heading;
	XplNode* p_title;
	XplNode* p_body;
	XplNode* p_examples;
	XplNode* p_seealso;
	XplNode* p_footer;
	XplNode* p_summary;
	XplNode* p_params;
	XplNode* p_returntype;
public:
	//Region de Constructores Publicos
	XplDocumentation();
	XplDocumentation(XplNode* n_heading, XplNode* n_title, XplNode* n_body, XplNode* n_examples, XplNode* n_seealso, XplNode* n_footer, XplNode* n_summary, XplNode* n_params, XplNode* n_returntype);
	XplDocumentation(string n_short, string n_source, string n_key, XplDocsourcetype_enum n_sourcetype, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplDocumentation(string n_short, string n_source, string n_key, XplDocsourcetype_enum n_sourcetype, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNode* n_heading, XplNode* n_title, XplNode* n_body, XplNode* n_examples, XplNode* n_seealso, XplNode* n_footer, XplNode* n_summary, XplNode* n_params, XplNode* n_returntype);
	//Destructor
	~XplDocumentation();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEDOCUMENTATION;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_short();
	string get_source();
	string get_key();
	XplDocsourcetype_enum get_sourcetype();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	//Funciones para obtener Elementos de Secuencia
	XplNode* get_heading();
	XplNode* get_title();
	XplNode* get_body();
	XplNode* get_examples();
	XplNode* get_seealso();
	XplNode* get_footer();
	XplNode* get_summary();
	XplNode* get_params();
	XplNode* get_returntype();
public:
	//Funciones para setear Atributos
	string set_short(string new_short);
	string set_source(string new_source);
	string set_key(string new_key);
	XplDocsourcetype_enum set_sourcetype(XplDocsourcetype_enum new_sourcetype);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
	XplNode* set_heading(XplNode* new_heading);
	XplNode* set_title(XplNode* new_title);
	XplNode* set_body(XplNode* new_body);
	XplNode* set_examples(XplNode* new_examples);
	XplNode* set_seealso(XplNode* new_seealso);
	XplNode* set_footer(XplNode* new_footer);
	XplNode* set_summary(XplNode* new_summary);
	XplNode* set_params(XplNode* new_params);
	XplNode* set_returntype(XplNode* new_returntype);
	static XplNode* new_heading();
	static XplNode* new_title();
	static XplNode* new_body();
	static XplNode* new_examples();
	static XplNode* new_seealso();
	static XplNode* new_footer();
	static XplNode* new_summary();
	static XplNode* new_params();
	static XplNode* new_returntype();
};	//Fin declaración de Clase

}

#endif
