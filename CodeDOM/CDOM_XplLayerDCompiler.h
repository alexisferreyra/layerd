/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOELAYERDCOMPILER_V1_0
#define __LAYERD_CODEDOM_ZOELAYERDCOMPILER_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplLayerDCompiler: public  XplNode{
private:
	//Variables para Atributos
	string p_name;
	string p_version;
	string p_companyName;
	string p_copyright;
public:
	//Region de Constructores Publicos
	XplLayerDCompiler();
	XplLayerDCompiler(string n_name, string n_version);
	XplLayerDCompiler(string n_name, string n_version, string n_companyName, string n_copyright);
	//Destructor
	~XplLayerDCompiler();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOELAYERDCOMPILER;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_name();
	string get_version();
	string get_companyName();
	string get_copyright();
public:
	//Funciones para setear Atributos
	string set_name(string new_name);
	string set_version(string new_version);
	string set_companyName(string new_companyName);
	string set_copyright(string new_copyright);
};	//Fin declaración de Clase

}

#endif
