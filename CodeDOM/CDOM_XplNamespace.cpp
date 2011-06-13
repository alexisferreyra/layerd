/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOENAMESPACE_V1_0_CPP
#define __LAYERD_CODEDOM_ZOENAMESPACE_V1_0_CPP
#include "CDOM_XplNamespace.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplNamespace::XplNamespace(){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_external = false;
	p_donotrender = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tNamespace);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tNamespace);
}
XplNamespace::XplNamespace(string n_name, bool n_external, bool n_donotrender){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_external = false;
	p_donotrender = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_name(n_name);
	set_external(n_external);
	set_donotrender(n_donotrender);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tNamespace);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tNamespace);
}
XplNamespace::XplNamespace(string n_name, string n_internalname, string n_externalname, bool n_external, bool n_donotrender, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_name(n_name);
	set_internalname(n_internalname);
	set_externalname(n_externalname);
	set_external(n_external);
	set_donotrender(n_donotrender);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tNamespace);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tNamespace);
}
XplNamespace::XplNamespace(XplNodeList* n_Childs){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_external = false;
	p_donotrender = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tNamespace);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tNamespace);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_Childs!=NULL)
	for(XplNode* node = n_Childs->FirstNode(); node != n_Childs->GetLastNode() ; node = n_Childs->NextNode()){
		p_Childs->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplNamespace::XplNamespace(string n_name, bool n_external, bool n_donotrender, XplNodeList* n_Childs){
	p_name = DT_EMPTY;
	p_internalname = DT_EMPTY;
	p_externalname = DT_EMPTY;
	p_external = false;
	p_donotrender = false;
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	set_name(n_name);
	set_external(n_external);
	set_donotrender(n_donotrender);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tNamespace);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tNamespace);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_Childs!=NULL)
	for(XplNode* node = n_Childs->FirstNode(); node != n_Childs->GetLastNode() ; node = n_Childs->NextNode()){
		p_Childs->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplNamespace::XplNamespace(string n_name, string n_internalname, string n_externalname, bool n_external, bool n_donotrender, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNodeList* n_Childs){
	set_name(n_name);
	set_internalname(n_internalname);
	set_externalname(n_externalname);
	set_external(n_external);
	set_donotrender(n_donotrender);
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tNamespace);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tNamespace);
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
XplNamespace::~XplNamespace(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplNamespace'");
#endif
	//Variables para Elementos de Secuencia
	if(p_Childs!=NULL)delete p_Childs;
}

//Funciones Sobreescritas de XplNode
XplNode* XplNamespace::Clone(){
	XplNamespace* copy = new XplNamespace();
	copy->set_name(this->p_name);
	copy->set_internalname(this->p_internalname);
	copy->set_externalname(this->p_externalname);
	copy->set_external(this->p_external);
	copy->set_donotrender(this->p_donotrender);
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
bool XplNamespace::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_name != DT_EMPTY)
		writer->write(DT(" name=\"")+CODEDOM_Att_ToString(p_name)+DT("\""));
	if(p_internalname != DT_EMPTY)
		writer->write(DT(" internalname=\"")+CODEDOM_Att_ToString(p_internalname)+DT("\""));
	if(p_externalname != DT_EMPTY)
		writer->write(DT(" externalname=\"")+CODEDOM_Att_ToString(p_externalname)+DT("\""));
	if(p_external != false)
		writer->write(DT(" external=\"")+CODEDOM_Att_ToString(p_external)+DT("\""));
	if(p_donotrender != false)
		writer->write(DT(" donotrender=\"")+CODEDOM_Att_ToString(p_donotrender)+DT("\""));
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
XplNode* XplNamespace::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplNamespace::get_name(){
	return p_name;
}
string XplNamespace::get_internalname(){
	return p_internalname;
}
string XplNamespace::get_externalname(){
	return p_externalname;
}
bool XplNamespace::get_external(){
	return p_external;
}
bool XplNamespace::get_donotrender(){
	return p_donotrender;
}
string XplNamespace::get_doc(){
	return p_doc;
}
string XplNamespace::get_helpURL(){
	return p_helpURL;
}
string XplNamespace::get_ldsrc(){
	return p_ldsrc;
}
bool XplNamespace::get_iny(){
	return p_iny;
}
string XplNamespace::get_inydata(){
	return p_inydata;
}
string XplNamespace::get_inyby(){
	return p_inyby;
}
string XplNamespace::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplNodeList* XplNamespace::Childs(){
	return p_Childs;
}

//Funciones para setear Atributos
string XplNamespace::set_name(string new_name){
	string back_name = p_name;
	p_name = new_name;
	return back_name;
}
string XplNamespace::set_internalname(string new_internalname){
	string back_internalname = p_internalname;
	p_internalname = new_internalname;
	return back_internalname;
}
string XplNamespace::set_externalname(string new_externalname){
	string back_externalname = p_externalname;
	p_externalname = new_externalname;
	return back_externalname;
}
bool XplNamespace::set_external(bool new_external){
	bool back_external = p_external;
	p_external = new_external;
	return back_external;
}
bool XplNamespace::set_donotrender(bool new_donotrender){
	bool back_donotrender = p_donotrender;
	p_donotrender = new_donotrender;
	return back_donotrender;
}
string XplNamespace::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplNamespace::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplNamespace::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplNamespace::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplNamespace::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplNamespace::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplNamespace::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
	bool XplNamespace::acceptInsertNodeCallback_tNamespace(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("Class")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOECLASS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplNamespace'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Namespace")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOENAMESPACE){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplNamespace'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Section")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOENAMESPACE){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplNamespace'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("e")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEEXPRESSION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplNamespace'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("BeginCFPermissions")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOECLASSFACTORYSPERMISSIONS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplNamespace'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("EndCFPermissions")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOENODE){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplNamespace'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("documentation")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEDOCUMENTATION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplNamespace'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplNamespace'."));
		return false;
	}
	bool XplNamespace::acceptRemoveNodeCallback_tNamespace(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}

//Funciones para filtrado en Listas de Nodos
XplNodeList* XplNamespace::get_ClassNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Class")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplNamespace::get_NamespaceNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Namespace")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplNamespace::get_SectionNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Section")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplNamespace::get_eNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("e")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplNamespace::get_BeginCFPermissionsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("BeginCFPermissions")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplNamespace::get_EndCFPermissionsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("EndCFPermissions")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplNamespace::get_documentationNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("documentation")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplClass* XplNamespace::new_Class(){
	XplClass* node = new XplClass();
	node->set_ElementName(DT("Class"));
	return node;
}
XplNamespace* XplNamespace::new_Namespace(){
	XplNamespace* node = new XplNamespace();
	node->set_ElementName(DT("Namespace"));
	return node;
}
XplNamespace* XplNamespace::new_Section(){
	XplNamespace* node = new XplNamespace();
	node->set_ElementName(DT("Section"));
	return node;
}
XplExpression* XplNamespace::new_e(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("e"));
	return node;
}
XplClassfactorysPermissions* XplNamespace::new_BeginCFPermissions(){
	XplClassfactorysPermissions* node = new XplClassfactorysPermissions();
	node->set_ElementName(DT("BeginCFPermissions"));
	return node;
}
XplNode* XplNamespace::new_EndCFPermissions(){
	XplNode* node = new XplNode(ZOENODETYPE_EMPTY);
	node->set_ElementName(DT("EndCFPermissions"));
	return node;
}
XplDocumentation* XplNamespace::new_documentation(){
	XplDocumentation* node = new XplDocumentation();
	node->set_ElementName(DT("documentation"));
	return node;
}

}

#endif
