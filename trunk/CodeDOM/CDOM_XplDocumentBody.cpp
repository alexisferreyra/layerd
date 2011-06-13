/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEDOCUMENTBODY_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEDOCUMENTBODY_V1_0_CPP
#include "CDOM_XplDocumentBody.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplDocumentBody::XplDocumentBody(){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tDocumentBody);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tDocumentBody);
}
XplDocumentBody::XplDocumentBody(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tDocumentBody);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tDocumentBody);
}
XplDocumentBody::XplDocumentBody(XplNodeList* n_Childs){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tDocumentBody);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tDocumentBody);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_Childs!=NULL)
	for(XplNode* node = n_Childs->FirstNode(); node != n_Childs->GetLastNode() ; node = n_Childs->NextNode()){
		p_Childs->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplDocumentBody::XplDocumentBody(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNodeList* n_Childs){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tDocumentBody);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tDocumentBody);
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
XplDocumentBody::~XplDocumentBody(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplDocumentBody'");
#endif
	//Variables para Elementos de Secuencia
	if(p_Childs!=NULL)delete p_Childs;
}

//Funciones Sobreescritas de XplNode
XplNode* XplDocumentBody::Clone(){
	XplDocumentBody* copy = new XplDocumentBody();
	copy->set_doc(this->p_doc);
	copy->set_helpURL(this->p_helpURL);
	copy->set_ldsrc(this->p_ldsrc);
	copy->set_iny(this->p_iny);
	copy->set_inydata(this->p_inydata);
	copy->set_inyby(this->p_inyby);
	copy->set_lddata(this->p_lddata);
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		copy->Childs()->InsertAtEnd(node->Clone());
	}
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplDocumentBody::Write(XplWriter* writer){
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
	if(p_Childs!=NULL)if(!p_Childs->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplDocumentBody::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplDocumentBody::get_doc(){
	return p_doc;
}
string XplDocumentBody::get_helpURL(){
	return p_helpURL;
}
string XplDocumentBody::get_ldsrc(){
	return p_ldsrc;
}
bool XplDocumentBody::get_iny(){
	return p_iny;
}
string XplDocumentBody::get_inydata(){
	return p_inydata;
}
string XplDocumentBody::get_inyby(){
	return p_inyby;
}
string XplDocumentBody::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplNodeList* XplDocumentBody::Childs(){
	return p_Childs;
}

//Funciones para setear Atributos
string XplDocumentBody::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplDocumentBody::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplDocumentBody::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplDocumentBody::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplDocumentBody::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplDocumentBody::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplDocumentBody::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
	bool XplDocumentBody::acceptInsertNodeCallback_tDocumentBody(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("Namespace")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOENAMESPACE){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplDocumentBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Section")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOENAMESPACE){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplDocumentBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("IdentifiersNamespace")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_STRING){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplDocumentBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Using")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOENAME){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplDocumentBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("UsingIdentifiers")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOENAME){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplDocumentBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Import")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOENAME){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplDocumentBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("BeginCFPermissions")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOECLASSFACTORYSPERMISSIONS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplDocumentBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("EndCFPermissions")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOENODE){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplDocumentBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("e")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEEXPRESSION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplDocumentBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("documentation")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEDOCUMENTATION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplDocumentBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplDocumentBody'."));
		return false;
	}
	bool XplDocumentBody::acceptRemoveNodeCallback_tDocumentBody(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}

//Funciones para filtrado en Listas de Nodos
XplNodeList* XplDocumentBody::get_NamespaceNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Namespace")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplDocumentBody::get_SectionNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Section")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplDocumentBody::get_IdentifiersNamespaceNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("IdentifiersNamespace")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplDocumentBody::get_UsingNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Using")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplDocumentBody::get_UsingIdentifiersNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("UsingIdentifiers")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplDocumentBody::get_ImportNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Import")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplDocumentBody::get_BeginCFPermissionsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("BeginCFPermissions")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplDocumentBody::get_EndCFPermissionsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("EndCFPermissions")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplDocumentBody::get_eNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("e")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplDocumentBody::get_documentationNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("documentation")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNamespace* XplDocumentBody::new_Namespace(){
	XplNamespace* node = new XplNamespace();
	node->set_ElementName(DT("Namespace"));
	return node;
}
XplNamespace* XplDocumentBody::new_Section(){
	XplNamespace* node = new XplNamespace();
	node->set_ElementName(DT("Section"));
	return node;
}
XplNode* XplDocumentBody::new_IdentifiersNamespace(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("IdentifiersNamespace"));
	return node;
}
XplName* XplDocumentBody::new_Using(){
	XplName* node = new XplName();
	node->set_ElementName(DT("Using"));
	return node;
}
XplName* XplDocumentBody::new_UsingIdentifiers(){
	XplName* node = new XplName();
	node->set_ElementName(DT("UsingIdentifiers"));
	return node;
}
XplName* XplDocumentBody::new_Import(){
	XplName* node = new XplName();
	node->set_ElementName(DT("Import"));
	return node;
}
XplClassfactorysPermissions* XplDocumentBody::new_BeginCFPermissions(){
	XplClassfactorysPermissions* node = new XplClassfactorysPermissions();
	node->set_ElementName(DT("BeginCFPermissions"));
	return node;
}
XplNode* XplDocumentBody::new_EndCFPermissions(){
	XplNode* node = new XplNode(ZOENODETYPE_EMPTY);
	node->set_ElementName(DT("EndCFPermissions"));
	return node;
}
XplExpression* XplDocumentBody::new_e(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("e"));
	return node;
}
XplDocumentation* XplDocumentBody::new_documentation(){
	XplDocumentation* node = new XplDocumentation();
	node->set_ElementName(DT("documentation"));
	return node;
}

}

#endif
