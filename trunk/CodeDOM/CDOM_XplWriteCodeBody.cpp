/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEWRITECODEBODY_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEWRITECODEBODY_V1_0_CPP
#include "CDOM_XplWriteCodeBody.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplWriteCodeBody::XplWriteCodeBody(){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_tWriteCodeBody=NULL;
}
XplWriteCodeBody::XplWriteCodeBody(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_tWriteCodeBody=NULL;
}
XplWriteCodeBody::XplWriteCodeBody(XplNode* n_tWriteCodeBody){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_tWriteCodeBody=NULL;
	set_tWriteCodeBody(n_tWriteCodeBody);
}
XplWriteCodeBody::XplWriteCodeBody(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNode* n_tWriteCodeBody){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_tWriteCodeBody=NULL;
	set_tWriteCodeBody(n_tWriteCodeBody);
}
//Destructor
XplWriteCodeBody::~XplWriteCodeBody(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplWriteCodeBody'");
#endif

	//Variables para Elementos de Choice
	if(p_tWriteCodeBody!=NULL)delete p_tWriteCodeBody;
}

//Funciones Sobreescritas de XplNode
XplNode* XplWriteCodeBody::Clone(){
	XplWriteCodeBody* copy = new XplWriteCodeBody();
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);

	//Variables para Elementos de Choice
	if(p_tWriteCodeBody!=NULL)copy->set_tWriteCodeBody(p_tWriteCodeBody->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplWriteCodeBody::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_doc != DT_EMPTY)
		writer->write(DT(" doc=\"")+CODEDOM_Att_ToString(p_doc)+DT("\""));
	if(p_helpURL != DT_EMPTY)
		writer->write(DT(" helpURL=\"")+CODEDOM_Att_ToString(p_helpURL)+DT("\""));
	if(p_ldsrc != DT_EMPTY)
		writer->write(DT(" ldsrc=\"")+CODEDOM_Att_ToString(p_ldsrc)+DT("\""));
	if(p_iny != false)
		writer->write(DT(" iny=\"")+CODEDOM_Att_ToString(p_iny)+DT("\""));
	if(p_inydata != DT_EMPTY)
		writer->write(DT(" inydata=\"")+CODEDOM_Att_ToString(p_inydata)+DT("\""));
	if(p_inyby != DT_EMPTY)
		writer->write(DT(" inyby=\"")+CODEDOM_Att_ToString(p_inyby)+DT("\""));
	if(p_lddata != DT_EMPTY)
		writer->write(DT(" lddata=\"")+CODEDOM_Att_ToString(p_lddata)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_tWriteCodeBody!=NULL)if(!p_tWriteCodeBody->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplWriteCodeBody::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplWriteCodeBody::get_doc(){
	return p_doc;
}
string XplWriteCodeBody::get_helpURL(){
	return p_helpURL;
}
string XplWriteCodeBody::get_ldsrc(){
	return p_ldsrc;
}
bool XplWriteCodeBody::get_iny(){
	return p_iny;
}
string XplWriteCodeBody::get_inydata(){
	return p_inydata;
}
string XplWriteCodeBody::get_inyby(){
	return p_inyby;
}
string XplWriteCodeBody::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Choice
XplNode* XplWriteCodeBody::get_tWriteCodeBody(){
	return p_tWriteCodeBody;
}

//Funciones para setear Atributos
string XplWriteCodeBody::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplWriteCodeBody::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplWriteCodeBody::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplWriteCodeBody::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplWriteCodeBody::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplWriteCodeBody::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplWriteCodeBody::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Choice
XplNode* XplWriteCodeBody::set_tWriteCodeBody(XplNode* new_tWriteCodeBody){
	if(new_tWriteCodeBody==NULL)return p_tWriteCodeBody;
	XplNode* back_tWriteCodeBody = p_tWriteCodeBody;
	if(new_tWriteCodeBody->get_ElementName()==DT("bk")){
		if(new_tWriteCodeBody->get_ContentTypeName()!=CODEDOMTYPES_ZOEFUNCTIONBODY){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tWriteCodeBody->get_ContentTypeNameString()+DT("' no es valido como componente de 'tWriteCodeBody'."));
			return NULL;
		}
		p_tWriteCodeBody = new_tWriteCodeBody;
		p_tWriteCodeBody->set_Parent(this);
		return back_tWriteCodeBody;
	}
	if(new_tWriteCodeBody->get_ElementName()==DT("progunit")){
		if(new_tWriteCodeBody->get_ContentTypeName()!=CODEDOMTYPES_ZOEDOCUMENTBODY){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tWriteCodeBody->get_ContentTypeNameString()+DT("' no es valido como componente de 'tWriteCodeBody'."));
			return NULL;
		}
		p_tWriteCodeBody = new_tWriteCodeBody;
		p_tWriteCodeBody->set_Parent(this);
		return back_tWriteCodeBody;
	}
	if(new_tWriteCodeBody->get_ElementName()==DT("namespace")){
		if(new_tWriteCodeBody->get_ContentTypeName()!=CODEDOMTYPES_ZOENAMESPACE){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tWriteCodeBody->get_ContentTypeNameString()+DT("' no es valido como componente de 'tWriteCodeBody'."));
			return NULL;
		}
		p_tWriteCodeBody = new_tWriteCodeBody;
		p_tWriteCodeBody->set_Parent(this);
		return back_tWriteCodeBody;
	}
	if(new_tWriteCodeBody->get_ElementName()==DT("classmembers")){
		if(new_tWriteCodeBody->get_ContentTypeName()!=CODEDOMTYPES_ZOECLASSMEMBERSLIST){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tWriteCodeBody->get_ContentTypeNameString()+DT("' no es valido como componente de 'tWriteCodeBody'."));
			return NULL;
		}
		p_tWriteCodeBody = new_tWriteCodeBody;
		p_tWriteCodeBody->set_Parent(this);
		return back_tWriteCodeBody;
	}
	if(new_tWriteCodeBody->get_ElementName()==DT("class")){
		if(new_tWriteCodeBody->get_ContentTypeName()!=CODEDOMTYPES_ZOECLASS){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tWriteCodeBody->get_ContentTypeNameString()+DT("' no es valido como componente de 'tWriteCodeBody'."));
			return NULL;
		}
		p_tWriteCodeBody = new_tWriteCodeBody;
		p_tWriteCodeBody->set_Parent(this);
		return back_tWriteCodeBody;
	}
	if(new_tWriteCodeBody->get_ElementName()==DT("e")){
		if(new_tWriteCodeBody->get_ContentTypeName()!=CODEDOMTYPES_ZOEEXPRESSION){
			this->set_ErrorString(DT("El elemento de tipo '")+new_tWriteCodeBody->get_ContentTypeNameString()+DT("' no es valido como componente de 'tWriteCodeBody'."));
			return NULL;
		}
		p_tWriteCodeBody = new_tWriteCodeBody;
		p_tWriteCodeBody->set_Parent(this);
		return back_tWriteCodeBody;
	}
	this->set_ErrorString(DT("El elemento de nombre '")+new_tWriteCodeBody->get_ElementName()+DT("' no es valido como componente de 'tWriteCodeBody'."));
	return NULL;
}
XplFunctionBody* XplWriteCodeBody::new_bk(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("bk"));
	return node;
}
XplDocumentBody* XplWriteCodeBody::new_progunit(){
	XplDocumentBody* node = new XplDocumentBody();
	node->set_ElementName(DT("progunit"));
	return node;
}
XplNamespace* XplWriteCodeBody::new_namespace(){
	XplNamespace* node = new XplNamespace();
	node->set_ElementName(DT("namespace"));
	return node;
}
XplClassMembersList* XplWriteCodeBody::new_classmembers(){
	XplClassMembersList* node = new XplClassMembersList();
	node->set_ElementName(DT("classmembers"));
	return node;
}
XplClass* XplWriteCodeBody::new_class(){
	XplClass* node = new XplClass();
	node->set_ElementName(DT("class"));
	return node;
}
XplExpression* XplWriteCodeBody::new_e(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("e"));
	return node;
}

}

#endif
