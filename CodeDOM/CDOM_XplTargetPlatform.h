/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOETARGETPLATFORM_V1_0
#define __LAYERD_CODEDOM_ZOETARGETPLATFORM_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplTargetPlatform: public  XplNode{
private:
	//Variables para Atributos
	string p_uniqueName;
	string p_simpleName;
	string p_minVersion;
	string p_maxVersion;
	string p_description;
	XplPlatformsupportlevel_enum p_supportLevel;
	string p_operatingsystem;
	string p_aplication;
	string p_multitask;
	XplMemorymodel_enum p_memorymodel;
	XplBitorder_enum p_defaultbitorder;
	XplBitorder_enum p_defaultbyteorder;
	unsigned p_addresswidth;
	unsigned p_databus;
	unsigned p_commonregisterssize;
	unsigned p_segments;
	unsigned p_segmentsize;
	string p_threading;
public:
	//Region de Constructores Publicos
	XplTargetPlatform();
	XplTargetPlatform(string n_uniqueName, string n_simpleName, XplPlatformsupportlevel_enum n_supportLevel, string n_multitask, XplMemorymodel_enum n_memorymodel, XplBitorder_enum n_defaultbitorder, XplBitorder_enum n_defaultbyteorder, unsigned n_addresswidth, unsigned n_databus, unsigned n_commonregisterssize);
	XplTargetPlatform(string n_uniqueName, string n_simpleName, string n_minVersion, string n_maxVersion, string n_description, XplPlatformsupportlevel_enum n_supportLevel, string n_operatingsystem, string n_aplication, string n_multitask, XplMemorymodel_enum n_memorymodel, XplBitorder_enum n_defaultbitorder, XplBitorder_enum n_defaultbyteorder, unsigned n_addresswidth, unsigned n_databus, unsigned n_commonregisterssize, unsigned n_segments, unsigned n_segmentsize, string n_threading);
	//Destructor
	~XplTargetPlatform();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOETARGETPLATFORM;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	string get_uniqueName();
	string get_simpleName();
	string get_minVersion();
	string get_maxVersion();
	string get_description();
	XplPlatformsupportlevel_enum get_supportLevel();
	string get_operatingsystem();
	string get_aplication();
	string get_multitask();
	XplMemorymodel_enum get_memorymodel();
	XplBitorder_enum get_defaultbitorder();
	XplBitorder_enum get_defaultbyteorder();
	unsigned get_addresswidth();
	unsigned get_databus();
	unsigned get_commonregisterssize();
	unsigned get_segments();
	unsigned get_segmentsize();
	string get_threading();
public:
	//Funciones para setear Atributos
	string set_uniqueName(string new_uniqueName);
	string set_simpleName(string new_simpleName);
	string set_minVersion(string new_minVersion);
	string set_maxVersion(string new_maxVersion);
	string set_description(string new_description);
	XplPlatformsupportlevel_enum set_supportLevel(XplPlatformsupportlevel_enum new_supportLevel);
	string set_operatingsystem(string new_operatingsystem);
	string set_aplication(string new_aplication);
	string set_multitask(string new_multitask);
	XplMemorymodel_enum set_memorymodel(XplMemorymodel_enum new_memorymodel);
	XplBitorder_enum set_defaultbitorder(XplBitorder_enum new_defaultbitorder);
	XplBitorder_enum set_defaultbyteorder(XplBitorder_enum new_defaultbyteorder);
	unsigned set_addresswidth(unsigned new_addresswidth);
	unsigned set_databus(unsigned new_databus);
	unsigned set_commonregisterssize(unsigned new_commonregisterssize);
	unsigned set_segments(unsigned new_segments);
	unsigned set_segmentsize(unsigned new_segmentsize);
	string set_threading(string new_threading);
};	//Fin declaración de Clase

}

#endif
