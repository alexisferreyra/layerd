/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOECOPYRIGHT_V1_0
#define __LAYERD_CODEDOM_ZOECOPYRIGHT_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplCopyright: public  XplNode{
private:
	//Variables para Atributos
	string p_copyrightMessage;
	string p_company;
	string p_productName;
	string p_productVersion;
	string p_productLicense;
	string p_description;
	string p_contactInfo;
public:
	//Region de Constructores Publicos
	XplCopyright();
	XplCopyright(string n_copyrightMessage);
	XplCopyright(string n_copyrightMessage, string n_company, string n_productName, string n_productVersion, string n_productLicense, string n_description, string n_contactInfo);
	//Destructor
	~XplCopyright();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOECOPYRIGHT;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_copyrightMessage();
	string get_company();
	string get_productName();
	string get_productVersion();
	string get_productLicense();
	string get_description();
	string get_contactInfo();
public:
	//Funciones para setear Atributos
	string set_copyrightMessage(string new_copyrightMessage);
	string set_company(string new_company);
	string set_productName(string new_productName);
	string set_productVersion(string new_productVersion);
	string set_productLicense(string new_productLicense);
	string set_description(string new_description);
	string set_contactInfo(string new_contactInfo);
};	//Fin declaración de Clase

}

#endif
