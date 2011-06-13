/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEEXPRESSION_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEEXPRESSION_V1_0_CPP
#include "CDOM_XplExpression.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplExpression::XplExpression(){
	p_typeStr = DT_EMPTY;
	p_valueStr = DT_EMPTY;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_texpression=NULL;
}
XplExpression::XplExpression(string n_typeStr, string n_valueStr, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_typeStr(n_typeStr);
	set_valueStr(n_valueStr);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_texpression=NULL;
}
XplExpression::XplExpression(XplNode* n_texpression){
	p_typeStr = DT_EMPTY;
	p_valueStr = DT_EMPTY;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_texpression=NULL;
	set_texpression(n_texpression);
}
XplExpression::XplExpression(string n_typeStr, string n_valueStr, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNode* n_texpression){
	set_typeStr(n_typeStr);
	set_valueStr(n_valueStr);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_texpression=NULL;
	set_texpression(n_texpression);
}
//Destructor
XplExpression::~XplExpression(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplExpression'");
#endif

	//Variables para Elementos de Choice
	if(p_texpression!=NULL)delete p_texpression;
}

//Funciones Sobreescritas de XplNode
XplNode* XplExpression::Clone(){
	XplExpression* copy = new XplExpression();
	copy->set_typeStr(this->p_typeStr);
	copy->set_valueStr(this->p_valueStr);
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);

	//Variables para Elementos de Choice
	if(p_texpression!=NULL)copy->set_texpression(p_texpression->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplExpression::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_typeStr != DT_EMPTY)
		writer->write(DT(" typeStr=\"")+CODEDOM_Att_ToString(p_typeStr)+DT("\""));
	if(p_valueStr != DT_EMPTY)
		writer->write(DT(" valueStr=\"")+CODEDOM_Att_ToString(p_valueStr)+DT("\""));
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
	if(p_texpression!=NULL)if(!p_texpression->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplExpression::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplExpression::get_typeStr(){
	return p_typeStr;
}
string XplExpression::get_valueStr(){
	return p_valueStr;
}
string XplExpression::get_doc(){
	return p_doc;
}
string XplExpression::get_helpURL(){
	return p_helpURL;
}
string XplExpression::get_ldsrc(){
	return p_ldsrc;
}
bool XplExpression::get_iny(){
	return p_iny;
}
string XplExpression::get_inydata(){
	return p_inydata;
}
string XplExpression::get_inyby(){
	return p_inyby;
}
string XplExpression::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Choice
XplNode* XplExpression::get_texpression(){
	return p_texpression;
}

//Funciones para setear Atributos
string XplExpression::set_typeStr(string new_typeStr){
	string back_typeStr = p_typeStr;
	p_typeStr = new_typeStr;
	return back_typeStr;
}
string XplExpression::set_valueStr(string new_valueStr){
	string back_valueStr = p_valueStr;
	p_valueStr = new_valueStr;
	return back_valueStr;
}
string XplExpression::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplExpression::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplExpression::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplExpression::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplExpression::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplExpression::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplExpression::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Choice
XplNode* XplExpression::set_texpression(XplNode* new_texpression){
	if(new_texpression==NULL)return p_texpression;
	XplNode* back_texpression = p_texpression;
	if(new_texpression->get_ElementName()==DT("a")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOEASSING){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("new")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOENEWEXPRESSION){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("bo")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOEBINARYOPERATOR){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("uo")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOEUNARYOPERATOR){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("to")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOETERNARYOPERATOR){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("b")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOEFUNCTIONCALL){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("n")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_STRING){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("lit")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOELITERAL){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("fc")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOEFUNCTIONCALL){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("cfc")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOECOMPLEXFUNCTIONCALL){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("cast")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOECASTEXPRESSION){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("delete")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOEEXPRESSION){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("onpointer")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOEEXPRESSION){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("writecode")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOEWRITECODEBODY){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("t")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOETYPE){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("toft")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOETYPE){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("is")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOECASTEXPRESSION){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	if(new_texpression->get_ElementName()==DT("empty")){
		if(new_texpression->get_ContentTypeName()!=CODEDOMTYPES_ZOENODE){
			this->set_ErrorString(DT("El elemento de tipo '")+new_texpression->get_ContentTypeNameString()+DT("' no es valido como componente de 'texpression'."));
			return NULL;
		}
		p_texpression = new_texpression;
		p_texpression->set_Parent(this);
		return back_texpression;
	}
	this->set_ErrorString(DT("El elemento de nombre '")+new_texpression->get_ElementName()+DT("' no es valido como componente de 'texpression'."));
	return NULL;
}
XplAssing* XplExpression::new_a(){
	XplAssing* node = new XplAssing();
	node->set_ElementName(DT("a"));
	return node;
}
XplNewExpression* XplExpression::new_new(){
	XplNewExpression* node = new XplNewExpression();
	node->set_ElementName(DT("new"));
	return node;
}
XplBinaryoperator* XplExpression::new_bo(){
	XplBinaryoperator* node = new XplBinaryoperator();
	node->set_ElementName(DT("bo"));
	return node;
}
XplUnaryoperator* XplExpression::new_uo(){
	XplUnaryoperator* node = new XplUnaryoperator();
	node->set_ElementName(DT("uo"));
	return node;
}
XplTernaryoperator* XplExpression::new_to(){
	XplTernaryoperator* node = new XplTernaryoperator();
	node->set_ElementName(DT("to"));
	return node;
}
XplFunctioncall* XplExpression::new_b(){
	XplFunctioncall* node = new XplFunctioncall();
	node->set_ElementName(DT("b"));
	return node;
}
XplNode* XplExpression::new_n(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("n"));
	return node;
}
XplLiteral* XplExpression::new_lit(){
	XplLiteral* node = new XplLiteral();
	node->set_ElementName(DT("lit"));
	return node;
}
XplFunctioncall* XplExpression::new_fc(){
	XplFunctioncall* node = new XplFunctioncall();
	node->set_ElementName(DT("fc"));
	return node;
}
XplComplexfunctioncall* XplExpression::new_cfc(){
	XplComplexfunctioncall* node = new XplComplexfunctioncall();
	node->set_ElementName(DT("cfc"));
	return node;
}
XplCastexpression* XplExpression::new_cast(){
	XplCastexpression* node = new XplCastexpression();
	node->set_ElementName(DT("cast"));
	return node;
}
XplExpression* XplExpression::new_delete(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("delete"));
	return node;
}
XplExpression* XplExpression::new_onpointer(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("onpointer"));
	return node;
}
XplWriteCodeBody* XplExpression::new_writecode(){
	XplWriteCodeBody* node = new XplWriteCodeBody();
	node->set_ElementName(DT("writecode"));
	return node;
}
XplType* XplExpression::new_t(){
	XplType* node = new XplType();
	node->set_ElementName(DT("t"));
	return node;
}
XplType* XplExpression::new_toft(){
	XplType* node = new XplType();
	node->set_ElementName(DT("toft"));
	return node;
}
XplCastexpression* XplExpression::new_is(){
	XplCastexpression* node = new XplCastexpression();
	node->set_ElementName(DT("is"));
	return node;
}
XplNode* XplExpression::new_empty(){
	XplNode* node = new XplNode(ZOENODETYPE_EMPTY);
	node->set_ElementName(DT("empty"));
	return node;
}

}

#endif
