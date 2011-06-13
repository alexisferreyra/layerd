/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEIMPORTPROCESSCONFIG_V1_0
#define __LAYERD_CODEDOM_ZOEIMPORTPROCESSCONFIG_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplImportProcessConfig: public  XplNode{
private:
	//Variables para Atributos
	string p_OutputFolder;
	string p_OutputPrefix;
	string p_ErrorsFileName;
public:
	//Region de Constructores Publicos
	XplImportProcessConfig();
	XplImportProcessConfig(string n_OutputFolder, string n_ErrorsFileName);
	XplImportProcessConfig(string n_OutputFolder, string n_OutputPrefix, string n_ErrorsFileName);
	//Destructor
	~XplImportProcessConfig();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEIMPORTPROCESSCONFIG;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_OutputFolder();
	string get_OutputPrefix();
	string get_ErrorsFileName();
public:
	//Funciones para setear Atributos
	string set_OutputFolder(string new_OutputFolder);
	string set_OutputPrefix(string new_OutputPrefix);
	string set_ErrorsFileName(string new_ErrorsFileName);
};	//Fin declaración de Clase

}

#endif
