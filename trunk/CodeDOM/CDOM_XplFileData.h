/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEFILEDATA_V1_0
#define __LAYERD_CODEDOM_ZOEFILEDATA_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplFileData: public  XplNode{
private:
	//Variables para Atributos
	string p_Autor;
	DateTime p_Date;
	DateTime p_Time;
	string p_Description;
public:
	//Region de Constructores Publicos
	XplFileData();
	XplFileData(string n_Autor, DateTime n_Date, DateTime n_Time, string n_Description);
	//Destructor
	~XplFileData();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEFILEDATA;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_Autor();
	DateTime get_Date();
	DateTime get_Time();
	string get_Description();
public:
	//Funciones para setear Atributos
	string set_Autor(string new_Autor);
	DateTime set_Date(DateTime new_Date);
	DateTime set_Time(DateTime new_Time);
	string set_Description(string new_Description);
};	//Fin declaración de Clase

}

#endif
