/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEDOCUMENTDATA_V1_0
#define __LAYERD_CODEDOM_ZOEDOCUMENTDATA_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplDocumentData: public  XplNode{
private:
	//Variables para Atributos
	XplDocumenttype_enum p_DocumentType;
	string p_DocumentVersion;
	string p_ExternConfig;
	//Variables para Elementos de Secuencia
	XplNode* p_Title;
	XplFileData* p_Original;
	XplCopyright* p_Copyright;
	XplConfig* p_Config;
	XplDocumentation* p_Documentation;
public:
	//Region de Constructores Publicos
	XplDocumentData();
	XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion);
	XplDocumentData(XplConfig* n_Config);
	XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, XplConfig* n_Config);
	XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, string n_ExternConfig);
	XplDocumentData(XplNode* n_Title, XplFileData* n_Original, XplCopyright* n_Copyright, XplConfig* n_Config, XplDocumentation* n_Documentation);
	XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, string n_ExternConfig, XplConfig* n_Config);
	XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, XplNode* n_Title, XplFileData* n_Original, XplCopyright* n_Copyright, XplConfig* n_Config, XplDocumentation* n_Documentation);
	XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, string n_ExternConfig, XplNode* n_Title, XplFileData* n_Original, XplCopyright* n_Copyright, XplConfig* n_Config, XplDocumentation* n_Documentation);
	//Destructor
	~XplDocumentData();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEDOCUMENTDATA;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	XplDocumenttype_enum get_DocumentType();
	string get_DocumentVersion();
	string get_ExternConfig();
	//Funciones para obtener Elementos de Secuencia
	XplNode* get_Title();
	XplFileData* get_Original();
	XplCopyright* get_Copyright();
	XplConfig* get_Config();
	XplDocumentation* get_Documentation();
public:
	//Funciones para setear Atributos
	XplDocumenttype_enum set_DocumentType(XplDocumenttype_enum new_DocumentType);
	string set_DocumentVersion(string new_DocumentVersion);
	string set_ExternConfig(string new_ExternConfig);
	//Funciones para setear Elementos de Secuencia
	XplNode* set_Title(XplNode* new_Title);
	XplFileData* set_Original(XplFileData* new_Original);
	XplCopyright* set_Copyright(XplCopyright* new_Copyright);
	XplConfig* set_Config(XplConfig* new_Config);
	XplDocumentation* set_Documentation(XplDocumentation* new_Documentation);
	static XplNode* new_Title();
	static XplFileData* new_Original();
	static XplCopyright* new_Copyright();
	static XplConfig* new_Config();
	static XplDocumentation* new_Documentation();
};	//Fin declaración de Clase

}

#endif
