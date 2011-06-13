/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOECLASS_V1_0
#define __LAYERD_CODEDOM_ZOECLASS_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplClass: public  XplNode{
private:
	//Variables para Atributos
	string p_name;
	string p_internalname;
	string p_externalname;
	XplAccesstype_enum p_access;
	bool p_isstruct;
	bool p_isinterface;
	bool p_isunion;
	bool p_isenum;
	bool p_isfactory;
	bool p_isinteractive;
	bool p_abstract;
	bool p_extension;
	bool p_external;
	bool p_donotrender;
	bool p_final;
	bool p_new;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	unsigned p_alignment;
	XplBitorder_enum p_bitorder;
	XplBitorder_enum p_byteorder;
	unsigned p_sizeinbits;
	//Variables para Elementos de Secuencia
	XplNodeList* p_Childs;
public:
	//Region de Constructores Publicos
	XplClass();
	XplClass(string n_name, XplAccesstype_enum n_access, bool n_isstruct, bool n_isinterface, bool n_isunion, bool n_isenum, bool n_isfactory, bool n_isinteractive, bool n_abstract, bool n_extension, bool n_external, bool n_donotrender, bool n_final, bool n_new, XplBitorder_enum n_bitorder, XplBitorder_enum n_byteorder);
	XplClass(string n_name, string n_internalname, string n_externalname, XplAccesstype_enum n_access, bool n_isstruct, bool n_isinterface, bool n_isunion, bool n_isenum, bool n_isfactory, bool n_isinteractive, bool n_abstract, bool n_extension, bool n_external, bool n_donotrender, bool n_final, bool n_new, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, unsigned n_alignment, XplBitorder_enum n_bitorder, XplBitorder_enum n_byteorder, unsigned n_sizeinbits);
	XplClass(XplNodeList* n_Childs);
	XplClass(string n_name, XplAccesstype_enum n_access, bool n_isstruct, bool n_isinterface, bool n_isunion, bool n_isenum, bool n_isfactory, bool n_isinteractive, bool n_abstract, bool n_extension, bool n_external, bool n_donotrender, bool n_final, bool n_new, XplBitorder_enum n_bitorder, XplBitorder_enum n_byteorder, XplNodeList* n_Childs);
	XplClass(string n_name, string n_internalname, string n_externalname, XplAccesstype_enum n_access, bool n_isstruct, bool n_isinterface, bool n_isunion, bool n_isenum, bool n_isfactory, bool n_isinteractive, bool n_abstract, bool n_extension, bool n_external, bool n_donotrender, bool n_final, bool n_new, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, unsigned n_alignment, XplBitorder_enum n_bitorder, XplBitorder_enum n_byteorder, unsigned n_sizeinbits, XplNodeList* n_Childs);
	//Destructor
	~XplClass();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOECLASS;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_name();
	string get_internalname();
	string get_externalname();
	XplAccesstype_enum get_access();
	bool get_isstruct();
	bool get_isinterface();
	bool get_isunion();
	bool get_isenum();
	bool get_isfactory();
	bool get_isinteractive();
	bool get_abstract();
	bool get_extension();
	bool get_external();
	bool get_donotrender();
	bool get_final();
	bool get_new();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
	unsigned get_alignment();
	XplBitorder_enum get_bitorder();
	XplBitorder_enum get_byteorder();
	unsigned get_sizeinbits();
	//Funciones para obtener Elementos de Secuencia
	XplNodeList* Childs();
public:
	//Funciones para setear Atributos
	string set_name(string new_name);
	string set_internalname(string new_internalname);
	string set_externalname(string new_externalname);
	XplAccesstype_enum set_access(XplAccesstype_enum new_access);
	bool set_isstruct(bool new_isstruct);
	bool set_isinterface(bool new_isinterface);
	bool set_isunion(bool new_isunion);
	bool set_isenum(bool new_isenum);
	bool set_isfactory(bool new_isfactory);
	bool set_isinteractive(bool new_isinteractive);
	bool set_abstract(bool new_abstract);
	bool set_extension(bool new_extension);
	bool set_external(bool new_external);
	bool set_donotrender(bool new_donotrender);
	bool set_final(bool new_final);
	bool set_new(bool new_new);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
	unsigned set_alignment(unsigned new_alignment);
	XplBitorder_enum set_bitorder(XplBitorder_enum new_bitorder);
	XplBitorder_enum set_byteorder(XplBitorder_enum new_byteorder);
	unsigned set_sizeinbits(unsigned new_sizeinbits);
	//Funciones para setear Elementos de Secuencia
protected:
	static bool acceptInsertNodeCallback_tClass(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_tClass(XplNode* node, string* errorMsg, XplNode* parent);
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
