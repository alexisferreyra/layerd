/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEDOCUMENTATION_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEDOCUMENTATION_V1_0_CPP
#include "CDOM_XplDocumentation.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplDocumentation::XplDocumentation(){
	p_short = DT_EMPTY;
	p_source = DT_EMPTY;
	p_key = DT_EMPTY;
	p_sourcetype = (XplDocsourcetype_enum)0;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_heading=NULL;
	p_title=NULL;
	p_body=NULL;
	p_examples=NULL;
	p_seealso=NULL;
	p_footer=NULL;
	p_summary=NULL;
	p_params=NULL;
	p_returntype=NULL;
}
XplDocumentation::XplDocumentation(XplNode* n_heading, XplNode* n_title, XplNode* n_body, XplNode* n_examples, XplNode* n_seealso, XplNode* n_footer, XplNode* n_summary, XplNode* n_params, XplNode* n_returntype){
	p_short = DT_EMPTY;
	p_source = DT_EMPTY;
	p_key = DT_EMPTY;
	p_sourcetype = (XplDocsourcetype_enum)0;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_heading=NULL;
	p_title=NULL;
	p_body=NULL;
	p_examples=NULL;
	p_seealso=NULL;
	p_footer=NULL;
	p_summary=NULL;
	p_params=NULL;
	p_returntype=NULL;
	set_heading(n_heading);
	set_title(n_title);
	set_body(n_body);
	set_examples(n_examples);
	set_seealso(n_seealso);
	set_footer(n_footer);
	set_summary(n_summary);
	set_params(n_params);
	set_returntype(n_returntype);
}
XplDocumentation::XplDocumentation(string n_short, string n_source, string n_key, XplDocsourcetype_enum n_sourcetype, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_short(n_short);
	set_source(n_source);
	set_key(n_key);
	set_sourcetype(n_sourcetype);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_heading=NULL;
	p_title=NULL;
	p_body=NULL;
	p_examples=NULL;
	p_seealso=NULL;
	p_footer=NULL;
	p_summary=NULL;
	p_params=NULL;
	p_returntype=NULL;
}
XplDocumentation::XplDocumentation(string n_short, string n_source, string n_key, XplDocsourcetype_enum n_sourcetype, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNode* n_heading, XplNode* n_title, XplNode* n_body, XplNode* n_examples, XplNode* n_seealso, XplNode* n_footer, XplNode* n_summary, XplNode* n_params, XplNode* n_returntype){
	set_short(n_short);
	set_source(n_source);
	set_key(n_key);
	set_sourcetype(n_sourcetype);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_heading=NULL;
	p_title=NULL;
	p_body=NULL;
	p_examples=NULL;
	p_seealso=NULL;
	p_footer=NULL;
	p_summary=NULL;
	p_params=NULL;
	p_returntype=NULL;
}
//Destructor
XplDocumentation::~XplDocumentation(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplDocumentation'");
#endif
	//Variables para Elementos de Secuencia
	if(p_heading!=NULL)delete p_heading;
	if(p_title!=NULL)delete p_title;
	if(p_body!=NULL)delete p_body;
	if(p_examples!=NULL)delete p_examples;
	if(p_seealso!=NULL)delete p_seealso;
	if(p_footer!=NULL)delete p_footer;
	if(p_summary!=NULL)delete p_summary;
	if(p_params!=NULL)delete p_params;
	if(p_returntype!=NULL)delete p_returntype;
}

//Funciones Sobreescritas de XplNode
XplNode* XplDocumentation::Clone(){
	XplDocumentation* copy = new XplDocumentation();
	copy->set_short(this->p_short);
	copy->set_source(this->p_source);
	copy->set_key(this->p_key);
	copy->set_sourcetype(this->p_sourcetype);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	if(p_heading!=NULL)copy->set_heading(p_heading->Clone());
	if(p_title!=NULL)copy->set_title(p_title->Clone());
	if(p_body!=NULL)copy->set_body(p_body->Clone());
	if(p_examples!=NULL)copy->set_examples(p_examples->Clone());
	if(p_seealso!=NULL)copy->set_seealso(p_seealso->Clone());
	if(p_footer!=NULL)copy->set_footer(p_footer->Clone());
	if(p_summary!=NULL)copy->set_summary(p_summary->Clone());
	if(p_params!=NULL)copy->set_params(p_params->Clone());
	if(p_returntype!=NULL)copy->set_returntype(p_returntype->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplDocumentation::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_short != DT_EMPTY)
		writer->write(DT(" short=\"")+CODEDOM_Att_ToString(p_short)+DT("\""));
	if(p_source != DT_EMPTY)
		writer->write(DT(" source=\"")+CODEDOM_Att_ToString(p_source)+DT("\""));
	if(p_key != DT_EMPTY)
		writer->write(DT(" key=\"")+CODEDOM_Att_ToString(p_key)+DT("\""));
	if(p_sourcetype != (XplDocsourcetype_enum)0)
		writer->write(DT(" sourcetype=\"")+(string)__CODEDOM_ZOEDOCSOURCETYPE_ENUM[p_sourcetype]+DT("\""));
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
	if(p_heading!=NULL)if(!p_heading->Write(writer))result=false;
	if(p_title!=NULL)if(!p_title->Write(writer))result=false;
	if(p_body!=NULL)if(!p_body->Write(writer))result=false;
	if(p_examples!=NULL)if(!p_examples->Write(writer))result=false;
	if(p_seealso!=NULL)if(!p_seealso->Write(writer))result=false;
	if(p_footer!=NULL)if(!p_footer->Write(writer))result=false;
	if(p_summary!=NULL)if(!p_summary->Write(writer))result=false;
	if(p_params!=NULL)if(!p_params->Write(writer))result=false;
	if(p_returntype!=NULL)if(!p_returntype->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplDocumentation::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplDocumentation::get_short(){
	return p_short;
}
string XplDocumentation::get_source(){
	return p_source;
}
string XplDocumentation::get_key(){
	return p_key;
}
XplDocsourcetype_enum XplDocumentation::get_sourcetype(){
	return p_sourcetype;
}
string XplDocumentation::get_ldsrc(){
	return p_ldsrc;
}
bool XplDocumentation::get_iny(){
	return p_iny;
}
string XplDocumentation::get_inydata(){
	return p_inydata;
}
string XplDocumentation::get_inyby(){
	return p_inyby;
}
string XplDocumentation::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplNode* XplDocumentation::get_heading(){
	return p_heading;
}
XplNode* XplDocumentation::get_title(){
	return p_title;
}
XplNode* XplDocumentation::get_body(){
	return p_body;
}
XplNode* XplDocumentation::get_examples(){
	return p_examples;
}
XplNode* XplDocumentation::get_seealso(){
	return p_seealso;
}
XplNode* XplDocumentation::get_footer(){
	return p_footer;
}
XplNode* XplDocumentation::get_summary(){
	return p_summary;
}
XplNode* XplDocumentation::get_params(){
	return p_params;
}
XplNode* XplDocumentation::get_returntype(){
	return p_returntype;
}

//Funciones para setear Atributos
string XplDocumentation::set_short(string new_short){
	string back_short = p_short;
	p_short = new_short;
	return back_short;
}
string XplDocumentation::set_source(string new_source){
	string back_source = p_source;
	p_source = new_source;
	return back_source;
}
string XplDocumentation::set_key(string new_key){
	string back_key = p_key;
	p_key = new_key;
	return back_key;
}
XplDocsourcetype_enum XplDocumentation::set_sourcetype(XplDocsourcetype_enum new_sourcetype){
	XplDocsourcetype_enum back_sourcetype = p_sourcetype;
	p_sourcetype = new_sourcetype;
	return back_sourcetype;
}
string XplDocumentation::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplDocumentation::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplDocumentation::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplDocumentation::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplDocumentation::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
XplNode* XplDocumentation::set_heading(XplNode* new_heading){
	if(new_heading->get_ContentTypeName()!=CODEDOMTYPES_STRING){
		this->set_ErrorString(DT("El nodo que intenta asignar a la propiedad es de un tipo incorrecto."));
		return NULL;
	}
	XplNode* back_heading = p_heading;
	p_heading = new_heading;
	if(p_heading!=NULL){
		p_heading->set_Parent(this);
		p_heading->set_ElementName(DT("heading"));
	}
	return back_heading;
}
XplNode* XplDocumentation::set_title(XplNode* new_title){
	if(new_title->get_ContentTypeName()!=CODEDOMTYPES_STRING){
		this->set_ErrorString(DT("El nodo que intenta asignar a la propiedad es de un tipo incorrecto."));
		return NULL;
	}
	XplNode* back_title = p_title;
	p_title = new_title;
	if(p_title!=NULL){
		p_title->set_Parent(this);
		p_title->set_ElementName(DT("title"));
	}
	return back_title;
}
XplNode* XplDocumentation::set_body(XplNode* new_body){
	if(new_body->get_ContentTypeName()!=CODEDOMTYPES_STRING){
		this->set_ErrorString(DT("El nodo que intenta asignar a la propiedad es de un tipo incorrecto."));
		return NULL;
	}
	XplNode* back_body = p_body;
	p_body = new_body;
	if(p_body!=NULL){
		p_body->set_Parent(this);
		p_body->set_ElementName(DT("body"));
	}
	return back_body;
}
XplNode* XplDocumentation::set_examples(XplNode* new_examples){
	if(new_examples->get_ContentTypeName()!=CODEDOMTYPES_STRING){
		this->set_ErrorString(DT("El nodo que intenta asignar a la propiedad es de un tipo incorrecto."));
		return NULL;
	}
	XplNode* back_examples = p_examples;
	p_examples = new_examples;
	if(p_examples!=NULL){
		p_examples->set_Parent(this);
		p_examples->set_ElementName(DT("examples"));
	}
	return back_examples;
}
XplNode* XplDocumentation::set_seealso(XplNode* new_seealso){
	if(new_seealso->get_ContentTypeName()!=CODEDOMTYPES_STRING){
		this->set_ErrorString(DT("El nodo que intenta asignar a la propiedad es de un tipo incorrecto."));
		return NULL;
	}
	XplNode* back_seealso = p_seealso;
	p_seealso = new_seealso;
	if(p_seealso!=NULL){
		p_seealso->set_Parent(this);
		p_seealso->set_ElementName(DT("seealso"));
	}
	return back_seealso;
}
XplNode* XplDocumentation::set_footer(XplNode* new_footer){
	if(new_footer->get_ContentTypeName()!=CODEDOMTYPES_STRING){
		this->set_ErrorString(DT("El nodo que intenta asignar a la propiedad es de un tipo incorrecto."));
		return NULL;
	}
	XplNode* back_footer = p_footer;
	p_footer = new_footer;
	if(p_footer!=NULL){
		p_footer->set_Parent(this);
		p_footer->set_ElementName(DT("footer"));
	}
	return back_footer;
}
XplNode* XplDocumentation::set_summary(XplNode* new_summary){
	if(new_summary->get_ContentTypeName()!=CODEDOMTYPES_STRING){
		this->set_ErrorString(DT("El nodo que intenta asignar a la propiedad es de un tipo incorrecto."));
		return NULL;
	}
	XplNode* back_summary = p_summary;
	p_summary = new_summary;
	if(p_summary!=NULL){
		p_summary->set_Parent(this);
		p_summary->set_ElementName(DT("summary"));
	}
	return back_summary;
}
XplNode* XplDocumentation::set_params(XplNode* new_params){
	if(new_params->get_ContentTypeName()!=CODEDOMTYPES_STRING){
		this->set_ErrorString(DT("El nodo que intenta asignar a la propiedad es de un tipo incorrecto."));
		return NULL;
	}
	XplNode* back_params = p_params;
	p_params = new_params;
	if(p_params!=NULL){
		p_params->set_Parent(this);
		p_params->set_ElementName(DT("params"));
	}
	return back_params;
}
XplNode* XplDocumentation::set_returntype(XplNode* new_returntype){
	if(new_returntype->get_ContentTypeName()!=CODEDOMTYPES_STRING){
		this->set_ErrorString(DT("El nodo que intenta asignar a la propiedad es de un tipo incorrecto."));
		return NULL;
	}
	XplNode* back_returntype = p_returntype;
	p_returntype = new_returntype;
	if(p_returntype!=NULL){
		p_returntype->set_Parent(this);
		p_returntype->set_ElementName(DT("returntype"));
	}
	return back_returntype;
}
XplNode* XplDocumentation::new_heading(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("heading"));
	return node;
}
XplNode* XplDocumentation::new_title(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("title"));
	return node;
}
XplNode* XplDocumentation::new_body(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("body"));
	return node;
}
XplNode* XplDocumentation::new_examples(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("examples"));
	return node;
}
XplNode* XplDocumentation::new_seealso(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("seealso"));
	return node;
}
XplNode* XplDocumentation::new_footer(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("footer"));
	return node;
}
XplNode* XplDocumentation::new_summary(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("summary"));
	return node;
}
XplNode* XplDocumentation::new_params(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("params"));
	return node;
}
XplNode* XplDocumentation::new_returntype(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("returntype"));
	return node;
}

}

#endif
