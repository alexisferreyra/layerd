/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEFUNCTIONBODY_V1_0
#define __LAYERD_CODEDOM_ZOEFUNCTIONBODY_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplFunctionBody: public  XplNode{
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
	XplNodeList* p_Childs;
public:
	//Region de Constructores Publicos
	XplFunctionBody();
	XplFunctionBody(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplFunctionBody(XplNodeList* n_Childs);
	XplFunctionBody(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNodeList* n_Childs);
	//Destructor
	~XplFunctionBody();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEFUNCTIONBODY;}
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
	XplNodeList* Childs();
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
protected:
	static bool acceptInsertNodeCallback_tFunctionBody(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_tFunctionBody(XplNode* node, string* errorMsg, XplNode* parent);
public:
	//Funciones para filtrado en Listas de Nodos
	XplNodeList* get_labelNodeList();
	XplNodeList* get_setonerrorNodeList();
	XplNodeList* get_DeclsNodeList();
	XplNodeList* get_eNodeList();
	XplNodeList* get_switchNodeList();
	XplNodeList* get_ifNodeList();
	XplNodeList* get_forNodeList();
	XplNodeList* get_doNodeList();
	XplNodeList* get_whileNodeList();
	XplNodeList* get_bkNodeList();
	XplNodeList* get_GetNodeList();
	XplNodeList* get_SetNodeList();
	XplNodeList* get_onpointerNodeList();
	XplNodeList* get_tryNodeList();
	XplNodeList* get_throwNodeList();
	XplNodeList* get_returnNodeList();
	XplNodeList* get_jumpNodeList();
	XplNodeList* get_directoutputNodeList();
	XplNodeList* get_documentationNodeList();
	XplNodeList* get_selectoutputNodeList();
	XplNodeList* get_BeginCFPermissionsNodeList();
	XplNodeList* get_EndCFPermissionsNodeList();
	static XplNode* new_label();
	static XplSetonerror* new_setonerror();
	static XplDeclaratorlist* new_Decls();
	static XplExpression* new_e();
	static XplSwitchStatement* new_switch();
	static XplIfStatement* new_if();
	static XplForStatement* new_for();
	static XplDowhileStatement* new_do();
	static XplDowhileStatement* new_while();
	static XplFunctionBody* new_bk();
	static XplFunctionBody* new_Get();
	static XplFunctionBody* new_Set();
	static XplFunctionBody* new_onpointer();
	static XplTryStatement* new_try();
	static XplExpression* new_throw();
	static XplExpression* new_return();
	static XplJump* new_jump();
	static XplDirectoutput* new_directoutput();
	static XplDocumentation* new_documentation();
	static XplFunctioncall* new_selectoutput();
	static XplClassfactorysPermissions* new_BeginCFPermissions();
	static XplNode* new_EndCFPermissions();
};	//Fin declaración de Clase

}

#endif
