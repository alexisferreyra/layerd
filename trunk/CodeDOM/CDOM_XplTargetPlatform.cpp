/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOETARGETPLATFORM_V1_0_CPP
#define __LAYERD_CODEDOM_ZOETARGETPLATFORM_V1_0_CPP
#include "CDOM_XplTargetPlatform.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplTargetPlatform::XplTargetPlatform(){
	p_uniqueName = DT_EMPTY;
	p_simpleName = DT_EMPTY;
	p_minVersion = DT_EMPTY;
	p_maxVersion = DT_EMPTY;
	p_description = DT_EMPTY;
	p_supportLevel = ZOEPLATFORMSUPPORTLEVEL_ENUM_COMPLETE;
	p_operatingsystem = DT_EMPTY;
	p_aplication = DT_EMPTY;
	p_multitask = DT("Preemtive");
	p_memorymodel = ZOEMEMORYMODEL_ENUM_LINEAL;
	p_defaultbitorder = ZOEBITORDER_ENUM_IGNORE;
	p_defaultbyteorder = ZOEBITORDER_ENUM_IGNORE;
	p_addresswidth = 32;
	p_databus = 32;
	p_commonregisterssize = 32;
	p_segments = 0;
	p_segmentsize = 0;
	p_threading = DT_EMPTY;
}
XplTargetPlatform::XplTargetPlatform(string n_uniqueName, string n_simpleName, XplPlatformsupportlevel_enum n_supportLevel, string n_multitask, XplMemorymodel_enum n_memorymodel, XplBitorder_enum n_defaultbitorder, XplBitorder_enum n_defaultbyteorder, unsigned n_addresswidth, unsigned n_databus, unsigned n_commonregisterssize){
	p_uniqueName = DT_EMPTY;
	p_simpleName = DT_EMPTY;
	p_minVersion = DT_EMPTY;
	p_maxVersion = DT_EMPTY;
	p_description = DT_EMPTY;
	p_supportLevel = ZOEPLATFORMSUPPORTLEVEL_ENUM_COMPLETE;
	p_operatingsystem = DT_EMPTY;
	p_aplication = DT_EMPTY;
	p_multitask = DT("Preemtive");
	p_memorymodel = ZOEMEMORYMODEL_ENUM_LINEAL;
	p_defaultbitorder = ZOEBITORDER_ENUM_IGNORE;
	p_defaultbyteorder = ZOEBITORDER_ENUM_IGNORE;
	p_addresswidth = 32;
	p_databus = 32;
	p_commonregisterssize = 32;
	p_segments = 0;
	p_segmentsize = 0;
	p_threading = DT_EMPTY;
	set_uniqueName(n_uniqueName);
	set_simpleName(n_simpleName);
	set_supportLevel(n_supportLevel);
	set_multitask(n_multitask);
	set_memorymodel(n_memorymodel);
	set_defaultbitorder(n_defaultbitorder);
	set_defaultbyteorder(n_defaultbyteorder);
	set_addresswidth(n_addresswidth);
	set_databus(n_databus);
	set_commonregisterssize(n_commonregisterssize);
}
XplTargetPlatform::XplTargetPlatform(string n_uniqueName, string n_simpleName, string n_minVersion, string n_maxVersion, string n_description, XplPlatformsupportlevel_enum n_supportLevel, string n_operatingsystem, string n_aplication, string n_multitask, XplMemorymodel_enum n_memorymodel, XplBitorder_enum n_defaultbitorder, XplBitorder_enum n_defaultbyteorder, unsigned n_addresswidth, unsigned n_databus, unsigned n_commonregisterssize, unsigned n_segments, unsigned n_segmentsize, string n_threading){
	set_uniqueName(n_uniqueName);
	set_simpleName(n_simpleName);
	set_minVersion(n_minVersion);
	set_maxVersion(n_maxVersion);
	set_description(n_description);
	set_supportLevel(n_supportLevel);
	set_operatingsystem(n_operatingsystem);
	set_aplication(n_aplication);
	set_multitask(n_multitask);
	set_memorymodel(n_memorymodel);
	set_defaultbitorder(n_defaultbitorder);
	set_defaultbyteorder(n_defaultbyteorder);
	set_addresswidth(n_addresswidth);
	set_databus(n_databus);
	set_commonregisterssize(n_commonregisterssize);
	set_segments(n_segments);
	set_segmentsize(n_segmentsize);
	set_threading(n_threading);
}
//Destructor
XplTargetPlatform::~XplTargetPlatform(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplTargetPlatform'");
#endif
}

//Funciones Sobreescritas de XplNode
XplNode* XplTargetPlatform::Clone(){
	XplTargetPlatform* copy = new XplTargetPlatform();
	copy->set_uniqueName(this->p_uniqueName);
	copy->set_simpleName(this->p_simpleName);
	copy->set_minVersion(this->p_minVersion);
	copy->set_maxVersion(this->p_maxVersion);
	copy->set_description(this->p_description);
	copy->set_supportLevel(this->p_supportLevel);
	copy->set_operatingsystem(this->p_operatingsystem);
	copy->set_aplication(this->p_aplication);
	copy->set_multitask(this->p_multitask);
	copy->set_memorymodel(this->p_memorymodel);
	copy->set_defaultbitorder(this->p_defaultbitorder);
	copy->set_defaultbyteorder(this->p_defaultbyteorder);
	copy->set_addresswidth(this->p_addresswidth);
	copy->set_databus(this->p_databus);
	copy->set_commonregisterssize(this->p_commonregisterssize);
	copy->set_segments(this->p_segments);
	copy->set_segmentsize(this->p_segmentsize);
	copy->set_threading(this->p_threading);
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplTargetPlatform::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_uniqueName != DT_EMPTY)
		writer->write(DT(" uniqueName=\"")+CODEDOM_Att_ToString(p_uniqueName)+DT("\""));
	if(p_simpleName != DT_EMPTY)
		writer->write(DT(" simpleName=\"")+CODEDOM_Att_ToString(p_simpleName)+DT("\""));
	if(p_minVersion != DT_EMPTY)
		writer->write(DT(" minVersion=\"")+CODEDOM_Att_ToString(p_minVersion)+DT("\""));
	if(p_maxVersion != DT_EMPTY)
		writer->write(DT(" maxVersion=\"")+CODEDOM_Att_ToString(p_maxVersion)+DT("\""));
	if(p_description != DT_EMPTY)
		writer->write(DT(" description=\"")+CODEDOM_Att_ToString(p_description)+DT("\""));
	if(p_supportLevel != ZOEPLATFORMSUPPORTLEVEL_ENUM_COMPLETE)
		writer->write(DT(" supportLevel=\"")+(string)__CODEDOM_ZOEPLATFORMSUPPORTLEVEL_ENUM[p_supportLevel]+DT("\""));
	if(p_operatingsystem != DT_EMPTY)
		writer->write(DT(" operatingsystem=\"")+CODEDOM_Att_ToString(p_operatingsystem)+DT("\""));
	if(p_aplication != DT_EMPTY)
		writer->write(DT(" aplication=\"")+CODEDOM_Att_ToString(p_aplication)+DT("\""));
	if(p_multitask != DT("Preemtive"))
		writer->write(DT(" multitask=\"")+CODEDOM_Att_ToString(p_multitask)+DT("\""));
	if(p_memorymodel != ZOEMEMORYMODEL_ENUM_LINEAL)
		writer->write(DT(" memorymodel=\"")+(string)__CODEDOM_ZOEMEMORYMODEL_ENUM[p_memorymodel]+DT("\""));
	if(p_defaultbitorder != ZOEBITORDER_ENUM_IGNORE)
		writer->write(DT(" defaultbitorder=\"")+(string)__CODEDOM_ZOEBITORDER_ENUM[p_defaultbitorder]+DT("\""));
	if(p_defaultbyteorder != ZOEBITORDER_ENUM_IGNORE)
		writer->write(DT(" defaultbyteorder=\"")+(string)__CODEDOM_ZOEBITORDER_ENUM[p_defaultbyteorder]+DT("\""));
	if(p_addresswidth != 32)
		writer->write(DT(" addresswidth=\"")+CODEDOM_Att_ToString(p_addresswidth)+DT("\""));
	if(p_databus != 32)
		writer->write(DT(" databus=\"")+CODEDOM_Att_ToString(p_databus)+DT("\""));
	if(p_commonregisterssize != 32)
		writer->write(DT(" commonregisterssize=\"")+CODEDOM_Att_ToString(p_commonregisterssize)+DT("\""));
	if(p_segments != 0)
		writer->write(DT(" segments=\"")+CODEDOM_Att_ToString(p_segments)+DT("\""));
	if(p_segmentsize != 0)
		writer->write(DT(" segmentsize=\"")+CODEDOM_Att_ToString(p_segmentsize)+DT("\""));
	if(p_threading != DT_EMPTY)
		writer->write(DT(" threading=\"")+CODEDOM_Att_ToString(p_threading)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplTargetPlatform::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplTargetPlatform::get_uniqueName(){
	return p_uniqueName;
}
string XplTargetPlatform::get_simpleName(){
	return p_simpleName;
}
string XplTargetPlatform::get_minVersion(){
	return p_minVersion;
}
string XplTargetPlatform::get_maxVersion(){
	return p_maxVersion;
}
string XplTargetPlatform::get_description(){
	return p_description;
}
XplPlatformsupportlevel_enum XplTargetPlatform::get_supportLevel(){
	return p_supportLevel;
}
string XplTargetPlatform::get_operatingsystem(){
	return p_operatingsystem;
}
string XplTargetPlatform::get_aplication(){
	return p_aplication;
}
string XplTargetPlatform::get_multitask(){
	return p_multitask;
}
XplMemorymodel_enum XplTargetPlatform::get_memorymodel(){
	return p_memorymodel;
}
XplBitorder_enum XplTargetPlatform::get_defaultbitorder(){
	return p_defaultbitorder;
}
XplBitorder_enum XplTargetPlatform::get_defaultbyteorder(){
	return p_defaultbyteorder;
}
unsigned XplTargetPlatform::get_addresswidth(){
	return p_addresswidth;
}
unsigned XplTargetPlatform::get_databus(){
	return p_databus;
}
unsigned XplTargetPlatform::get_commonregisterssize(){
	return p_commonregisterssize;
}
unsigned XplTargetPlatform::get_segments(){
	return p_segments;
}
unsigned XplTargetPlatform::get_segmentsize(){
	return p_segmentsize;
}
string XplTargetPlatform::get_threading(){
	return p_threading;
}

//Funciones para setear Atributos
string XplTargetPlatform::set_uniqueName(string new_uniqueName){
	string back_uniqueName = p_uniqueName;
	p_uniqueName = new_uniqueName;
	return back_uniqueName;
}
string XplTargetPlatform::set_simpleName(string new_simpleName){
	string back_simpleName = p_simpleName;
	p_simpleName = new_simpleName;
	return back_simpleName;
}
string XplTargetPlatform::set_minVersion(string new_minVersion){
	string back_minVersion = p_minVersion;
	p_minVersion = new_minVersion;
	return back_minVersion;
}
string XplTargetPlatform::set_maxVersion(string new_maxVersion){
	string back_maxVersion = p_maxVersion;
	p_maxVersion = new_maxVersion;
	return back_maxVersion;
}
string XplTargetPlatform::set_description(string new_description){
	string back_description = p_description;
	p_description = new_description;
	return back_description;
}
XplPlatformsupportlevel_enum XplTargetPlatform::set_supportLevel(XplPlatformsupportlevel_enum new_supportLevel){
	XplPlatformsupportlevel_enum back_supportLevel = p_supportLevel;
	p_supportLevel = new_supportLevel;
	return back_supportLevel;
}
string XplTargetPlatform::set_operatingsystem(string new_operatingsystem){
	string back_operatingsystem = p_operatingsystem;
	p_operatingsystem = new_operatingsystem;
	return back_operatingsystem;
}
string XplTargetPlatform::set_aplication(string new_aplication){
	string back_aplication = p_aplication;
	p_aplication = new_aplication;
	return back_aplication;
}
string XplTargetPlatform::set_multitask(string new_multitask){
	string back_multitask = p_multitask;
	p_multitask = new_multitask;
	return back_multitask;
}
XplMemorymodel_enum XplTargetPlatform::set_memorymodel(XplMemorymodel_enum new_memorymodel){
	XplMemorymodel_enum back_memorymodel = p_memorymodel;
	p_memorymodel = new_memorymodel;
	return back_memorymodel;
}
XplBitorder_enum XplTargetPlatform::set_defaultbitorder(XplBitorder_enum new_defaultbitorder){
	XplBitorder_enum back_defaultbitorder = p_defaultbitorder;
	p_defaultbitorder = new_defaultbitorder;
	return back_defaultbitorder;
}
XplBitorder_enum XplTargetPlatform::set_defaultbyteorder(XplBitorder_enum new_defaultbyteorder){
	XplBitorder_enum back_defaultbyteorder = p_defaultbyteorder;
	p_defaultbyteorder = new_defaultbyteorder;
	return back_defaultbyteorder;
}
unsigned XplTargetPlatform::set_addresswidth(unsigned new_addresswidth){
	unsigned back_addresswidth = p_addresswidth;
	p_addresswidth = new_addresswidth;
	return back_addresswidth;
}
unsigned XplTargetPlatform::set_databus(unsigned new_databus){
	unsigned back_databus = p_databus;
	p_databus = new_databus;
	return back_databus;
}
unsigned XplTargetPlatform::set_commonregisterssize(unsigned new_commonregisterssize){
	unsigned back_commonregisterssize = p_commonregisterssize;
	p_commonregisterssize = new_commonregisterssize;
	return back_commonregisterssize;
}
unsigned XplTargetPlatform::set_segments(unsigned new_segments){
	unsigned back_segments = p_segments;
	p_segments = new_segments;
	return back_segments;
}
unsigned XplTargetPlatform::set_segmentsize(unsigned new_segmentsize){
	unsigned back_segmentsize = p_segmentsize;
	p_segmentsize = new_segmentsize;
	return back_segmentsize;
}
string XplTargetPlatform::set_threading(string new_threading){
	string back_threading = p_threading;
	p_threading = new_threading;
	return back_threading;
}

}

#endif
