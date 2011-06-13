/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOECLASSMEMBERSLIST_V1_0
#define __LAYERD_CODEDOM_ZOECLASSMEMBERSLIST_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplClassMembersList: public  XplNode{
private:
	//Variables para Atributos
	//Variables para Elementos de Secuencia
	XplNodeList* p_Childs;
public:
	//Region de Constructores Publicos
	XplClassMembersList();
	XplClassMembersList(XplNodeList* n_Childs);
	//Destructor
	~XplClassMembersList();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOECLASSMEMBERSLIST;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	//Funciones para obtener Elementos de Secuencia
	XplNodeList* Childs();
public:
	//Funciones para setear Atributos
	//Funciones para setear Elementos de Secuencia
protected:
	static bool acceptInsertNodeCallback_tClassMembersList(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_tClassMembersList(XplNode* node, string* errorMsg, XplNode* parent);
public:
	//Funciones para filtrado en Listas de Nodos
	XplNodeList* get_InheritsNodeList();
	XplNodeList* get_ImplementsNodeList();
	XplNodeList* get_FunctionNodeList();
	XplNodeList* get_OperatorNodeList();
	XplNodeList* get_IndexerNodeList();
	XplNodeList* get_PropertyNodeList();
	XplNodeList* get_FieldNodeList();
	XplNodeList* get_eNodeList();
	XplNodeList* get_ClassNodeList();
	XplNodeList* get_documentationNodeList();
	XplNodeList* get_BeginCFPermissionsNodeList();
	XplNodeList* get_EndCFPermissionsNodeList();
	XplNodeList* get_SetPlatformsNodeList();
	XplNodeList* get_AutoInstanceNodeList();
	static XplInherits* new_Inherits();
	static XplInherits* new_Implements();
	static XplFunction* new_Function();
	static XplFunction* new_Operator();
	static XplFunction* new_Indexer();
	static XplProperty* new_Property();
	static XplField* new_Field();
	static XplExpression* new_e();
	static XplClass* new_Class();
	static XplDocumentation* new_documentation();
	static XplClassfactorysPermissions* new_BeginCFPermissions();
	static XplNode* new_EndCFPermissions();
	static XplSetPlatforms* new_SetPlatforms();
	static XplAutoInstance* new_AutoInstance();
};	//Fin declaración de Clase

}

#endif
