/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEDECLARATORLIST_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEDECLARATORLIST_V1_0_CPP
#include "CDOM_XplDeclaratorlist.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplDeclaratorlist::XplDeclaratorlist(){
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tdeclaratorlist);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tdeclaratorlist);
}
XplDeclaratorlist::XplDeclaratorlist(XplNodeList* n_Childs){
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tdeclaratorlist);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tdeclaratorlist);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_Childs!=NULL)
	for(XplNode* node = n_Childs->FirstNode(); node != n_Childs->GetLastNode() ; node = n_Childs->NextNode()){
		p_Childs->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
//Destructor
XplDeclaratorlist::~XplDeclaratorlist(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplDeclaratorlist'");
#endif
	//Variables para Elementos de Secuencia
	if(p_Childs!=NULL)delete p_Childs;
}

//Funciones Sobreescritas de XplNode
XplNode* XplDeclaratorlist::Clone(){
	XplDeclaratorlist* copy = new XplDeclaratorlist();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		copy->Childs()->InsertAtEnd(node->Clone());
	}
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplDeclaratorlist::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_Childs!=NULL)if(!p_Childs->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplDeclaratorlist::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos

//Funciones para obtener Elementos de Secuencia
XplNodeList* XplDeclaratorlist::Childs(){
	return p_Childs;
}

//Funciones para setear Atributos

//Funciones para setear Elementos de Secuencia
	bool XplDeclaratorlist::acceptInsertNodeCallback_tdeclaratorlist(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("d")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEDECLARATOR){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplDeclaratorlist'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplDeclaratorlist'."));
		return false;
	}
	bool XplDeclaratorlist::acceptRemoveNodeCallback_tdeclaratorlist(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}

//Funciones para filtrado en Listas de Nodos
XplNodeList* XplDeclaratorlist::get_dNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("d")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplDeclarator* XplDeclaratorlist::new_d(){
	XplDeclarator* node = new XplDeclarator();
	node->set_ElementName(DT("d"));
	return node;
}

}

#endif
