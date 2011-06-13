/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEDIRECTOUTPUT_V1_0
#define __LAYERD_CODEDOM_ZOEDIRECTOUTPUT_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplDirectoutput: public  XplNode{
private:
	//Variables para Atributos
	string p_TargetPlatform;
	string p_TargetPlatformDetail;
	string p_output;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
public:
	//Region de Constructores Publicos
	XplDirectoutput();
	XplDirectoutput(string n_TargetPlatform, string n_TargetPlatformDetail, string n_output);
	XplDirectoutput(string n_TargetPlatform, string n_TargetPlatformDetail, string n_output, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata);
	//Destructor
	~XplDirectoutput();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEDIRECTOUTPUT;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_TargetPlatform();
	string get_TargetPlatformDetail();
	string get_output();
	string get_doc();
	string get_helpURL();
	string get_ldsrc();
	bool get_iny();
	string get_inydata();
	string get_inyby();
	string get_lddata();
public:
	//Funciones para setear Atributos
	string set_TargetPlatform(string new_TargetPlatform);
	string set_TargetPlatformDetail(string new_TargetPlatformDetail);
	string set_output(string new_output);
	string set_doc(string new_doc);
	string set_helpURL(string new_helpURL);
	string set_ldsrc(string new_ldsrc);
	bool set_iny(bool new_iny);
	string set_inydata(string new_inydata);
	string set_inyby(string new_inyby);
	string set_lddata(string new_lddata);
};	//Fin declaración de Clase

}

#endif
