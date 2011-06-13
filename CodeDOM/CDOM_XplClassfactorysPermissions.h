/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOECLASSFACTORYSPERMISSIONS_V1_0
#define __LAYERD_CODEDOM_ZOECLASSFACTORYSPERMISSIONS_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplClassfactorysPermissions: public  XplNode{
private:
	//Variables para Atributos
	bool p_allowRead;
	bool p_allowAppend;
	bool p_allowChange;
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
	XplClassfactorysPermissions();
	XplClassfactorysPermissions(bool n_allowRead, bool n_allowAppend, bool n_allowChange);
	XplClassfactorysPermissions(bool n_allowRead, bool n_allowAppend, bool n_allowChange, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	XplClassfactorysPermissions(XplNodeList* n_Childs);
	XplClassfactorysPermissions(bool n_allowRead, bool n_allowAppend, bool n_allowChange, XplNodeList* n_Childs);
	XplClassfactorysPermissions(bool n_allowRead, bool n_allowAppend, bool n_allowChange, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNodeList* n_Childs);
	//Destructor
	~XplClassfactorysPermissions();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOECLASSFACTORYSPERMISSIONS;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	bool get_allowRead();
	bool get_allowAppend();
	bool get_allowChange();
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
	bool set_allowRead(bool new_allowRead);
	bool set_allowAppend(bool new_allowAppend);
	bool set_allowChange(bool new_allowChange);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	//Funciones para setear Elementos de Secuencia
protected:
	static bool acceptInsertNodeCallback_tClassfactorysPermissions(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_tClassfactorysPermissions(XplNode* node, string* errorMsg, XplNode* parent);
public:
	//Funciones para filtrado en Listas de Nodos
	XplNodeList* get_cfNodeList();
	static XplNode* new_cf();
};	//Fin declaración de Clase

}

#endif
