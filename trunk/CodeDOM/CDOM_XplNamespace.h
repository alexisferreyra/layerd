/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOENAMESPACE_V1_0
#define __LAYERD_CODEDOM_ZOENAMESPACE_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplNamespace: public  XplNode{
private:
	//Variables para Atributos
	string p_name;
	string p_internalname;
	string p_externalname;
	bool p_external;
	bool p_donotrender;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplNodeList* p_Childs;
public:
	//Region de Constructores Publicos
	XplNamespace();
	XplNamespace(string n_name, bool n_external, bool n_donotrender);
	XplNamespace(string n_name, string n_internalname, string n_externalname, bool n_external, bool n_donotrender, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplNamespace(XplNodeList* n_Childs);
	XplNamespace(string n_name, bool n_external, bool n_donotrender, XplNodeList* n_Childs);
	XplNamespace(string n_name, string n_internalname, string n_externalname, bool n_external, bool n_donotrender, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNodeList* n_Childs);
	//Destructor
	~XplNamespace();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOENAMESPACE;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_name();
	string get_internalname();
	string get_externalname();
	bool get_external();
	bool get_donotrender();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	//Funciones para obtener Elementos de Secuencia
	XplNodeList* Childs();
public:
	//Funciones para setear Atributos
	string set_name(string new_name);
	string set_internalname(string new_internalname);
	string set_externalname(string new_externalname);
	bool set_external(bool new_external);
	bool set_donotrender(bool new_donotrender);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
protected:
	static bool acceptInsertNodeCallback_tNamespace(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_tNamespace(XplNode* node, string* errorMsg, XplNode* parent);
public:
	//Funciones para filtrado en Listas de Nodos
	XplNodeList* get_ClassNodeList();
	XplNodeList* get_NamespaceNodeList();
	XplNodeList* get_SectionNodeList();
	XplNodeList* get_eNodeList();
	XplNodeList* get_BeginCFPermissionsNodeList();
	XplNodeList* get_EndCFPermissionsNodeList();
	XplNodeList* get_documentationNodeList();
	static XplClass* new_Class();
	static XplNamespace* new_Namespace();
	static XplNamespace* new_Section();
	static XplExpression* new_e();
	static XplClassfactorysPermissions* new_BeginCFPermissions();
	static XplNode* new_EndCFPermissions();
	static XplDocumentation* new_documentation();
};	//Fin declaración de Clase

}

#endif
