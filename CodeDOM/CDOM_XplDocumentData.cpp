/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEDOCUMENTDATA_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEDOCUMENTDATA_V1_0_CPP
#include "CDOM_XplDocumentData.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplDocumentData::XplDocumentData(){
	p_DocumentType = ZOEDOCUMENTTYPE_ENUM_LAYERD_ZOE_DOC;
	p_DocumentVersion = DT_EMPTY;
	p_ExternConfig = DT_EMPTY;
	p_Title=NULL;
	p_Original=NULL;
	p_Copyright=NULL;
	p_Config=NULL;
	p_Documentation=NULL;
}
XplDocumentData::XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion){
	p_DocumentType = ZOEDOCUMENTTYPE_ENUM_LAYERD_ZOE_DOC;
	p_DocumentVersion = DT_EMPTY;
	p_ExternConfig = DT_EMPTY;
	set_DocumentType(n_DocumentType);
	set_DocumentVersion(n_DocumentVersion);
	p_Title=NULL;
	p_Original=NULL;
	p_Copyright=NULL;
	p_Config=NULL;
	p_Documentation=NULL;
}
XplDocumentData::XplDocumentData(XplConfig* n_Config){
	p_DocumentType = ZOEDOCUMENTTYPE_ENUM_LAYERD_ZOE_DOC;
	p_DocumentVersion = DT_EMPTY;
	p_ExternConfig = DT_EMPTY;
	p_Title=NULL;
	p_Original=NULL;
	p_Copyright=NULL;
	p_Config=NULL;
	p_Documentation=NULL;
	set_Config(n_Config);
}
XplDocumentData::XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, XplConfig* n_Config){
	p_DocumentType = ZOEDOCUMENTTYPE_ENUM_LAYERD_ZOE_DOC;
	p_DocumentVersion = DT_EMPTY;
	p_ExternConfig = DT_EMPTY;
	set_DocumentType(n_DocumentType);
	set_DocumentVersion(n_DocumentVersion);
	p_Title=NULL;
	p_Original=NULL;
	p_Copyright=NULL;
	p_Config=NULL;
	p_Documentation=NULL;
	set_Config(n_Config);
}
XplDocumentData::XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, string n_ExternConfig){
	set_DocumentType(n_DocumentType);
	set_DocumentVersion(n_DocumentVersion);
	set_ExternConfig(n_ExternConfig);
	p_Title=NULL;
	p_Original=NULL;
	p_Copyright=NULL;
	p_Config=NULL;
	p_Documentation=NULL;
}
XplDocumentData::XplDocumentData(XplNode* n_Title, XplFileData* n_Original, XplCopyright* n_Copyright, XplConfig* n_Config, XplDocumentation* n_Documentation){
	p_DocumentType = ZOEDOCUMENTTYPE_ENUM_LAYERD_ZOE_DOC;
	p_DocumentVersion = DT_EMPTY;
	p_ExternConfig = DT_EMPTY;
	p_Title=NULL;
	p_Original=NULL;
	p_Copyright=NULL;
	p_Config=NULL;
	p_Documentation=NULL;
	set_Title(n_Title);
	set_Original(n_Original);
	set_Copyright(n_Copyright);
	set_Config(n_Config);
	set_Documentation(n_Documentation);
}
XplDocumentData::XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, string n_ExternConfig, XplConfig* n_Config){
	set_DocumentType(n_DocumentType);
	set_DocumentVersion(n_DocumentVersion);
	set_ExternConfig(n_ExternConfig);
	set_DocumentType(n_DocumentType);
	set_DocumentVersion(n_DocumentVersion);
	p_Title=NULL;
	p_Original=NULL;
	p_Copyright=NULL;
	p_Config=NULL;
	p_Documentation=NULL;
}
XplDocumentData::XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, XplNode* n_Title, XplFileData* n_Original, XplCopyright* n_Copyright, XplConfig* n_Config, XplDocumentation* n_Documentation){
	p_DocumentType = ZOEDOCUMENTTYPE_ENUM_LAYERD_ZOE_DOC;
	p_DocumentVersion = DT_EMPTY;
	p_ExternConfig = DT_EMPTY;
	set_DocumentType(n_DocumentType);
	set_DocumentVersion(n_DocumentVersion);
	p_Title=NULL;
	p_Original=NULL;
	p_Copyright=NULL;
	p_Config=NULL;
	p_Documentation=NULL;
	set_Title(n_Title);
	set_Original(n_Original);
	set_Copyright(n_Copyright);
	set_Config(n_Config);
	set_Documentation(n_Documentation);
}
XplDocumentData::XplDocumentData(XplDocumenttype_enum n_DocumentType, string n_DocumentVersion, string n_ExternConfig, XplNode* n_Title, XplFileData* n_Original, XplCopyright* n_Copyright, XplConfig* n_Config, XplDocumentation* n_Documentation){
	set_DocumentType(n_DocumentType);
	set_DocumentVersion(n_DocumentVersion);
	set_ExternConfig(n_ExternConfig);
	p_Title=NULL;
	p_Original=NULL;
	p_Copyright=NULL;
	p_Config=NULL;
	p_Documentation=NULL;
	set_Title(n_Title);
	set_Original(n_Original);
	set_Copyright(n_Copyright);
	set_Config(n_Config);
	set_Documentation(n_Documentation);
}
//Destructor
XplDocumentData::~XplDocumentData(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplDocumentData'");
#endif
	//Variables para Elementos de Secuencia
	if(p_Title!=NULL)delete p_Title;
	if(p_Original!=NULL)delete p_Original;
	if(p_Copyright!=NULL)delete p_Copyright;
	if(p_Config!=NULL)delete p_Config;
	if(p_Documentation!=NULL)delete p_Documentation;
}

//Funciones Sobreescritas de XplNode
XplNode* XplDocumentData::Clone(){
	XplDocumentData* copy = new XplDocumentData();
	copy->set_DocumentType(this->p_DocumentType);
	copy->set_DocumentVersion(this->p_DocumentVersion);
	copy->set_ExternConfig(this->p_ExternConfig);
	if(p_Title!=NULL)copy->set_Title(p_Title->Clone());
	if(p_Original!=NULL)copy->set_Original((XplFileData*)p_Original->Clone());
	if(p_Copyright!=NULL)copy->set_Copyright((XplCopyright*)p_Copyright->Clone());
	if(p_Config!=NULL)copy->set_Config((XplConfig*)p_Config->Clone());
	if(p_Documentation!=NULL)copy->set_Documentation((XplDocumentation*)p_Documentation->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplDocumentData::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_DocumentType != ZOEDOCUMENTTYPE_ENUM_LAYERD_ZOE_DOC)
		writer->write(DT(" DocumentType=\"")+(string)__CODEDOM_ZOEDOCUMENTTYPE_ENUM[p_DocumentType]+DT("\""));
	if(p_DocumentVersion != DT_EMPTY)
		writer->write(DT(" DocumentVersion=\"")+CODEDOM_Att_ToString(p_DocumentVersion)+DT("\""));
	if(p_ExternConfig != DT_EMPTY)
		writer->write(DT(" ExternConfig=\"")+CODEDOM_Att_ToString(p_ExternConfig)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_Title!=NULL)if(!p_Title->Write(writer))result=false;
	if(p_Original!=NULL)if(!p_Original->Write(writer))result=false;
	if(p_Copyright!=NULL)if(!p_Copyright->Write(writer))result=false;
	if(p_Config!=NULL)if(!p_Config->Write(writer))result=false;
	if(p_Documentation!=NULL)if(!p_Documentation->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplDocumentData::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
XplDocumenttype_enum XplDocumentData::get_DocumentType(){
	return p_DocumentType;
}
string XplDocumentData::get_DocumentVersion(){
	return p_DocumentVersion;
}
string XplDocumentData::get_ExternConfig(){
	return p_ExternConfig;
}

//Funciones para obtener Elementos de Secuencia
XplNode* XplDocumentData::get_Title(){
	return p_Title;
}
XplFileData* XplDocumentData::get_Original(){
	return p_Original;
}
XplCopyright* XplDocumentData::get_Copyright(){
	return p_Copyright;
}
XplConfig* XplDocumentData::get_Config(){
	return p_Config;
}
XplDocumentation* XplDocumentData::get_Documentation(){
	return p_Documentation;
}

//Funciones para setear Atributos
XplDocumenttype_enum XplDocumentData::set_DocumentType(XplDocumenttype_enum new_DocumentType){
	XplDocumenttype_enum back_DocumentType = p_DocumentType;
	p_DocumentType = new_DocumentType;
	return back_DocumentType;
}
string XplDocumentData::set_DocumentVersion(string new_DocumentVersion){
	string back_DocumentVersion = p_DocumentVersion;
	p_DocumentVersion = new_DocumentVersion;
	return back_DocumentVersion;
}
string XplDocumentData::set_ExternConfig(string new_ExternConfig){
	string back_ExternConfig = p_ExternConfig;
	p_ExternConfig = new_ExternConfig;
	return back_ExternConfig;
}

//Funciones para setear Elementos de Secuencia
XplNode* XplDocumentData::set_Title(XplNode* new_Title){
	if(new_Title->get_ContentTypeName()!=CODEDOMTYPES_STRING){
		this->set_ErrorString(DT("El nodo que intenta asignar a la propiedad es de un tipo incorrecto."));
		return NULL;
	}
	XplNode* back_Title = p_Title;
	p_Title = new_Title;
	if(p_Title!=NULL){
		p_Title->set_Parent(this);
		p_Title->set_ElementName(DT("Title"));
	}
	return back_Title;
}
XplFileData* XplDocumentData::set_Original(XplFileData* new_Original){
	XplFileData* back_Original = p_Original;
	p_Original = new_Original;
	if(p_Original!=NULL){
		p_Original->set_ElementName(DT("Original"));
		p_Original->set_Parent(this);
	}
	return back_Original;
}
XplCopyright* XplDocumentData::set_Copyright(XplCopyright* new_Copyright){
	XplCopyright* back_Copyright = p_Copyright;
	p_Copyright = new_Copyright;
	if(p_Copyright!=NULL){
		p_Copyright->set_ElementName(DT("Copyright"));
		p_Copyright->set_Parent(this);
	}
	return back_Copyright;
}
XplConfig* XplDocumentData::set_Config(XplConfig* new_Config){
	XplConfig* back_Config = p_Config;
	p_Config = new_Config;
	if(p_Config!=NULL){
		p_Config->set_ElementName(DT("Config"));
		p_Config->set_Parent(this);
	}
	return back_Config;
}
XplDocumentation* XplDocumentData::set_Documentation(XplDocumentation* new_Documentation){
	XplDocumentation* back_Documentation = p_Documentation;
	p_Documentation = new_Documentation;
	if(p_Documentation!=NULL){
		p_Documentation->set_ElementName(DT("Documentation"));
		p_Documentation->set_Parent(this);
	}
	return back_Documentation;
}
XplNode* XplDocumentData::new_Title(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("Title"));
	return node;
}
XplFileData* XplDocumentData::new_Original(){
	XplFileData* node = new XplFileData();
	node->set_ElementName(DT("Original"));
	return node;
}
XplCopyright* XplDocumentData::new_Copyright(){
	XplCopyright* node = new XplCopyright();
	node->set_ElementName(DT("Copyright"));
	return node;
}
XplConfig* XplDocumentData::new_Config(){
	XplConfig* node = new XplConfig();
	node->set_ElementName(DT("Config"));
	return node;
}
XplDocumentation* XplDocumentData::new_Documentation(){
	XplDocumentation* node = new XplDocumentation();
	node->set_ElementName(DT("Documentation"));
	return node;
}

}

#endif
