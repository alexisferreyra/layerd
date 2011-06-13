/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOELANGUAGE_V1_0
#define __LAYERD_CODEDOM_ZOELANGUAGE_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplLanguage: public  XplNode{
private:
	//Variables para Atributos
	string p_Source;
	string p_StandardDefinitionFile;
	string p_SourceVersion;
	string p_Destination;
public:
	//Region de Constructores Publicos
	XplLanguage();
	XplLanguage(string n_Source);
	XplLanguage(string n_Source, string n_StandardDefinitionFile, string n_SourceVersion, string n_Destination);
	//Destructor
	~XplLanguage();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOELANGUAGE;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_Source();
	string get_StandardDefinitionFile();
	string get_SourceVersion();
	string get_Destination();
public:
	//Funciones para setear Atributos
	string set_Source(string new_Source);
	string set_StandardDefinitionFile(string new_StandardDefinitionFile);
	string set_SourceVersion(string new_SourceVersion);
	string set_Destination(string new_Destination);
};	//Fin declaración de Clase

}

#endif
