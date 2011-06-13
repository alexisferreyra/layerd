/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOECLASSMEMBERSLIST_V1_0_CPP
#define __LAYERD_CODEDOM_ZOECLASSMEMBERSLIST_V1_0_CPP
#include "CDOM_XplClassMembersList.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplClassMembersList::XplClassMembersList(){
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tClassMembersList);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tClassMembersList);
}
XplClassMembersList::XplClassMembersList(XplNodeList* n_Childs){
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tClassMembersList);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tClassMembersList);
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
XplClassMembersList::~XplClassMembersList(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplClassMembersList'");
#endif
	//Variables para Elementos de Secuencia
	if(p_Childs!=NULL)delete p_Childs;
}

//Funciones Sobreescritas de XplNode
XplNode* XplClassMembersList::Clone(){
	XplClassMembersList* copy = new XplClassMembersList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		copy->Childs()->InsertAtEnd(node->Clone());
	}
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplClassMembersList::Write(XplWriter* writer){
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
XplNode* XplClassMembersList::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos

//Funciones para obtener Elementos de Secuencia
XplNodeList* XplClassMembersList::Childs(){
	return p_Childs;
}

//Funciones para setear Atributos

//Funciones para setear Elementos de Secuencia
	bool XplClassMembersList::acceptInsertNodeCallback_tClassMembersList(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("Inherits")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEINHERITS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassMembersList'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Implements")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEINHERITS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassMembersList'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Function")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFUNCTION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassMembersList'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Operator")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFUNCTION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassMembersList'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Indexer")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFUNCTION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassMembersList'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Property")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEPROPERTY){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassMembersList'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Field")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFIELD){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassMembersList'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("e")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEEXPRESSION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassMembersList'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Class")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOECLASS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassMembersList'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("documentation")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEDOCUMENTATION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassMembersList'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("BeginCFPermissions")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOECLASSFACTORYSPERMISSIONS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassMembersList'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("EndCFPermissions")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOENODE){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassMembersList'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("SetPlatforms")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOESETPLATFORMS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassMembersList'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("AutoInstance")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEAUTOINSTANCE){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplClassMembersList'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplClassMembersList'."));
		return false;
	}
	bool XplClassMembersList::acceptRemoveNodeCallback_tClassMembersList(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}

//Funciones para filtrado en Listas de Nodos
XplNodeList* XplClassMembersList::get_InheritsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Inherits")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClassMembersList::get_ImplementsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Implements")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClassMembersList::get_FunctionNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Function")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClassMembersList::get_OperatorNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Operator")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClassMembersList::get_IndexerNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Indexer")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClassMembersList::get_PropertyNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Property")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClassMembersList::get_FieldNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Field")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClassMembersList::get_eNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("e")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClassMembersList::get_ClassNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Class")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClassMembersList::get_documentationNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("documentation")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClassMembersList::get_BeginCFPermissionsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("BeginCFPermissions")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClassMembersList::get_EndCFPermissionsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("EndCFPermissions")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClassMembersList::get_SetPlatformsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("SetPlatforms")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplClassMembersList::get_AutoInstanceNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("AutoInstance")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplInherits* XplClassMembersList::new_Inherits(){
	XplInherits* node = new XplInherits();
	node->set_ElementName(DT("Inherits"));
	return node;
}
XplInherits* XplClassMembersList::new_Implements(){
	XplInherits* node = new XplInherits();
	node->set_ElementName(DT("Implements"));
	return node;
}
XplFunction* XplClassMembersList::new_Function(){
	XplFunction* node = new XplFunction();
	node->set_ElementName(DT("Function"));
	return node;
}
XplFunction* XplClassMembersList::new_Operator(){
	XplFunction* node = new XplFunction();
	node->set_ElementName(DT("Operator"));
	return node;
}
XplFunction* XplClassMembersList::new_Indexer(){
	XplFunction* node = new XplFunction();
	node->set_ElementName(DT("Indexer"));
	return node;
}
XplProperty* XplClassMembersList::new_Property(){
	XplProperty* node = new XplProperty();
	node->set_ElementName(DT("Property"));
	return node;
}
XplField* XplClassMembersList::new_Field(){
	XplField* node = new XplField();
	node->set_ElementName(DT("Field"));
	return node;
}
XplExpression* XplClassMembersList::new_e(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("e"));
	return node;
}
XplClass* XplClassMembersList::new_Class(){
	XplClass* node = new XplClass();
	node->set_ElementName(DT("Class"));
	return node;
}
XplDocumentation* XplClassMembersList::new_documentation(){
	XplDocumentation* node = new XplDocumentation();
	node->set_ElementName(DT("documentation"));
	return node;
}
XplClassfactorysPermissions* XplClassMembersList::new_BeginCFPermissions(){
	XplClassfactorysPermissions* node = new XplClassfactorysPermissions();
	node->set_ElementName(DT("BeginCFPermissions"));
	return node;
}
XplNode* XplClassMembersList::new_EndCFPermissions(){
	XplNode* node = new XplNode(ZOENODETYPE_EMPTY);
	node->set_ElementName(DT("EndCFPermissions"));
	return node;
}
XplSetPlatforms* XplClassMembersList::new_SetPlatforms(){
	XplSetPlatforms* node = new XplSetPlatforms();
	node->set_ElementName(DT("SetPlatforms"));
	return node;
}
XplAutoInstance* XplClassMembersList::new_AutoInstance(){
	XplAutoInstance* node = new XplAutoInstance();
	node->set_ElementName(DT("AutoInstance"));
	return node;
}

}

#endif
