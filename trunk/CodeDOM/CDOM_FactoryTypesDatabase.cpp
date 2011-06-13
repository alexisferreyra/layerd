/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_FACTORYTYPESDATABASE_V1_0_CPP
#define __LAYERD_CODEDOM_FACTORYTYPESDATABASE_V1_0_CPP
#include "CDOM_FactoryTypesDatabase.h"

namespace CodeDOM{

//Region de Constructores Publicos
FactoryTypesDatabase::FactoryTypesDatabase(){
	p_version = 1;
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_FactoryTypesDatabase);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_FactoryTypesDatabase);
}
FactoryTypesDatabase::FactoryTypesDatabase(int n_version){
	p_version = 1;
	set_version(n_version);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_FactoryTypesDatabase);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_FactoryTypesDatabase);
}
FactoryTypesDatabase::FactoryTypesDatabase(XplNodeList* n_Childs){
	p_version = 1;
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_FactoryTypesDatabase);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_FactoryTypesDatabase);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_Childs!=NULL)
	for(XplNode* node = n_Childs->FirstNode(); node != n_Childs->GetLastNode() ; node = n_Childs->NextNode()){
		p_Childs->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
FactoryTypesDatabase::FactoryTypesDatabase(int n_version, XplNodeList* n_Childs){
	p_version = 1;
	set_version(n_version);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_FactoryTypesDatabase);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_FactoryTypesDatabase);
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
FactoryTypesDatabase::~FactoryTypesDatabase(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'FactoryTypesDatabase'");
#endif
	//Variables para Elementos de Secuencia
	if(p_Childs!=NULL)delete p_Childs;
}

//Funciones Sobreescritas de XplNode
XplNode* FactoryTypesDatabase::Clone(){
	FactoryTypesDatabase* copy = new FactoryTypesDatabase();
	copy->set_version(this->p_version);
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		copy->Childs()->InsertAtEnd(node->Clone());
	}
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool FactoryTypesDatabase::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_version != 1)
		writer->write(DT(" version=\"")+CODEDOM_Att_ToString(p_version)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_Childs!=NULL)if(!p_Childs->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* FactoryTypesDatabase::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
int FactoryTypesDatabase::get_version(){
	return p_version;
}

//Funciones para obtener Elementos de Secuencia
XplNodeList* FactoryTypesDatabase::Childs(){
	return p_Childs;
}

//Funciones para setear Atributos
int FactoryTypesDatabase::set_version(int new_version){
	int back_version = p_version;
	p_version = new_version;
	return back_version;
}

//Funciones para setear Elementos de Secuencia
	bool FactoryTypesDatabase::acceptInsertNodeCallback_FactoryTypesDatabase(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("Classfactory")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_CLASSFACTORYDATA){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'FactoryTypesDatabase'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'FactoryTypesDatabase'."));
		return false;
	}
	bool FactoryTypesDatabase::acceptRemoveNodeCallback_FactoryTypesDatabase(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}

//Funciones para filtrado en Listas de Nodos
XplNodeList* FactoryTypesDatabase::get_ClassfactoryNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Classfactory")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
ClassfactoryData* FactoryTypesDatabase::new_Classfactory(){
	ClassfactoryData* node = new ClassfactoryData();
	node->set_ElementName(DT("Classfactory"));
	return node;
}

}

#endif
