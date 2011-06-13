/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEDOCUMENT_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEDOCUMENT_V1_0_CPP
#include "CDOM_XplDocument.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplDocument::XplDocument(){
	p_DocumentData=NULL;
	p_DocumentBody=NULL;
}
XplDocument::XplDocument(XplDocumentData* n_DocumentData, XplDocumentBody* n_DocumentBody){
	p_DocumentData=NULL;
	p_DocumentBody=NULL;
	set_DocumentData(n_DocumentData);
	set_DocumentBody(n_DocumentBody);
}
//Destructor
XplDocument::~XplDocument(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplDocument'");
#endif
	//Variables para Elementos de Secuencia
	if(p_DocumentData!=NULL)delete p_DocumentData;
	if(p_DocumentBody!=NULL)delete p_DocumentBody;
}

//Funciones Sobreescritas de XplNode
XplNode* XplDocument::Clone(){
	XplDocument* copy = new XplDocument();
	if(p_DocumentData!=NULL)copy->set_DocumentData((XplDocumentData*)p_DocumentData->Clone());
	if(p_DocumentBody!=NULL)copy->set_DocumentBody((XplDocumentBody*)p_DocumentBody->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplDocument::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_DocumentData!=NULL)if(!p_DocumentData->Write(writer))result=false;
	if(p_DocumentBody!=NULL)if(!p_DocumentBody->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplDocument::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos

//Funciones para obtener Elementos de Secuencia
XplDocumentData* XplDocument::get_DocumentData(){
	return p_DocumentData;
}
XplDocumentBody* XplDocument::get_DocumentBody(){
	return p_DocumentBody;
}

//Funciones para setear Atributos

//Funciones para setear Elementos de Secuencia
XplDocumentData* XplDocument::set_DocumentData(XplDocumentData* new_DocumentData){
	XplDocumentData* back_DocumentData = p_DocumentData;
	p_DocumentData = new_DocumentData;
	if(p_DocumentData!=NULL){
		p_DocumentData->set_ElementName(DT("DocumentData"));
		p_DocumentData->set_Parent(this);
	}
	return back_DocumentData;
}
XplDocumentBody* XplDocument::set_DocumentBody(XplDocumentBody* new_DocumentBody){
	XplDocumentBody* back_DocumentBody = p_DocumentBody;
	p_DocumentBody = new_DocumentBody;
	if(p_DocumentBody!=NULL){
		p_DocumentBody->set_ElementName(DT("DocumentBody"));
		p_DocumentBody->set_Parent(this);
	}
	return back_DocumentBody;
}
XplDocumentData* XplDocument::new_DocumentData(){
	XplDocumentData* node = new XplDocumentData();
	node->set_ElementName(DT("DocumentData"));
	return node;
}
XplDocumentBody* XplDocument::new_DocumentBody(){
	XplDocumentBody* node = new XplDocumentBody();
	node->set_ElementName(DT("DocumentBody"));
	return node;
}

}

#endif
