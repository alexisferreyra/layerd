/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOESOURCEFILE_V1_0
#define __LAYERD_CODEDOM_ZOESOURCEFILE_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplSourceFile: public  XplNode{
private:
	//Variables para Atributos
	string p_fileName;
public:
	//Region de Constructores Publicos
	XplSourceFile();
	XplSourceFile(string n_fileName);
	//Destructor
	~XplSourceFile();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOESOURCEFILE;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_fileName();
public:
	//Funciones para setear Atributos
	string set_fileName(string new_fileName);
};	//Fin declaración de Clase

}

#endif
