/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEFUNCTIONBODY_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEFUNCTIONBODY_V1_0_CPP
#include "CDOM_XplFunctionBody.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplFunctionBody::XplFunctionBody(){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tFunctionBody);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tFunctionBody);
}
XplFunctionBody::XplFunctionBody(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tFunctionBody);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tFunctionBody);
}
XplFunctionBody::XplFunctionBody(XplNodeList* n_Childs){
	p_doc = DT_EMPTY;
	p_helpURL = DT_EMPTY;
	p_ldsrc = DT_EMPTY;
	p_iny = false;
	p_inydata = DT_EMPTY;
	p_inyby = DT_EMPTY;
	p_lddata = DT_EMPTY;
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tFunctionBody);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tFunctionBody);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_Childs!=NULL)
	for(XplNode* node = n_Childs->FirstNode(); node != n_Childs->GetLastNode() ; node = n_Childs->NextNode()){
		p_Childs->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplFunctionBody::XplFunctionBody(string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNodeList* n_Childs){
	set_doc(n_doc);
	set_helpURL(n_helpURL);
	set_ldsrc(n_ldsrc);
	set_iny(n_iny);
	set_inydata(n_inydata);
	set_inyby(n_inyby);
	set_lddata(n_lddata);
	p_Childs = new XplNodeList();
	p_Childs->set_Parent(this);
	p_Childs->set_InsertNodeCallback(&acceptInsertNodeCallback_tFunctionBody);
	p_Childs->set_RemoveNodeCallback(&acceptRemoveNodeCallback_tFunctionBody);
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
XplFunctionBody::~XplFunctionBody(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplFunctionBody'");
#endif
	//Variables para Elementos de Secuencia
	if(p_Childs!=NULL)delete p_Childs;
}

//Funciones Sobreescritas de XplNode
XplNode* XplFunctionBody::Clone(){
	XplFunctionBody* copy = new XplFunctionBody();
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
bool XplFunctionBody::Write(XplWriter* writer){
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
XplNode* XplFunctionBody::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplFunctionBody::get_doc(){
	return p_doc;
}
string XplFunctionBody::get_helpURL(){
	return p_helpURL;
}
string XplFunctionBody::get_ldsrc(){
	return p_ldsrc;
}
bool XplFunctionBody::get_iny(){
	return p_iny;
}
string XplFunctionBody::get_inydata(){
	return p_inydata;
}
string XplFunctionBody::get_inyby(){
	return p_inyby;
}
string XplFunctionBody::get_lddata(){
	return p_lddata;
}

//Funciones para obtener Elementos de Secuencia
XplNodeList* XplFunctionBody::Childs(){
	return p_Childs;
}

//Funciones para setear Atributos
string XplFunctionBody::set_doc(string new_doc){
	string back_doc = p_doc;
	p_doc = new_doc;
	return back_doc;
}
string XplFunctionBody::set_helpURL(string new_helpURL){
	string back_helpURL = p_helpURL;
	p_helpURL = new_helpURL;
	return back_helpURL;
}
string XplFunctionBody::set_ldsrc(string new_ldsrc){
	string back_ldsrc = p_ldsrc;
	p_ldsrc = new_ldsrc;
	return back_ldsrc;
}
bool XplFunctionBody::set_iny(bool new_iny){
	bool back_iny = p_iny;
	p_iny = new_iny;
	return back_iny;
}
string XplFunctionBody::set_inydata(string new_inydata){
	string back_inydata = p_inydata;
	p_inydata = new_inydata;
	return back_inydata;
}
string XplFunctionBody::set_inyby(string new_inyby){
	string back_inyby = p_inyby;
	p_inyby = new_inyby;
	return back_inyby;
}
string XplFunctionBody::set_lddata(string new_lddata){
	string back_lddata = p_lddata;
	p_lddata = new_lddata;
	return back_lddata;
}

//Funciones para setear Elementos de Secuencia
	bool XplFunctionBody::acceptInsertNodeCallback_tFunctionBody(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("label")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_STRING){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("setonerror")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOESETONERROR){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Decls")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEDECLARATORLIST){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("e")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEEXPRESSION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("switch")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOESWITCHSTATEMENT){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("if")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEIFSTATEMENT){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("for")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFORSTATEMENT){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("do")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEDOWHILESTATEMENT){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("while")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEDOWHILESTATEMENT){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("bk")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFUNCTIONBODY){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Get")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFUNCTIONBODY){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("Set")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFUNCTIONBODY){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("onpointer")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFUNCTIONBODY){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("try")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOETRYSTATEMENT){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("throw")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEEXPRESSION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("return")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEEXPRESSION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("jump")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEJUMP){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("directoutput")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEDIRECTOUTPUT){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("documentation")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEDOCUMENTATION){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("selectoutput")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEFUNCTIONCALL){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("BeginCFPermissions")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOECLASSFACTORYSPERMISSIONS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		if(node->get_ElementName()==DT("EndCFPermissions")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOENODE){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplFunctionBody'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplFunctionBody'."));
		return false;
	}
	bool XplFunctionBody::acceptRemoveNodeCallback_tFunctionBody(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}

//Funciones para filtrado en Listas de Nodos
XplNodeList* XplFunctionBody::get_labelNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("label")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_setonerrorNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("setonerror")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_DeclsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Decls")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_eNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("e")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_switchNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("switch")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_ifNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("if")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_forNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("for")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_doNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("do")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_whileNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("while")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_bkNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("bk")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_GetNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Get")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_SetNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("Set")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_onpointerNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("onpointer")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_tryNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("try")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_throwNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("throw")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_returnNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("return")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_jumpNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("jump")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_directoutputNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("directoutput")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_documentationNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("documentation")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_selectoutputNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("selectoutput")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_BeginCFPermissionsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("BeginCFPermissions")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNodeList* XplFunctionBody::get_EndCFPermissionsNodeList(){
	XplNodeList* new_List = new XplNodeList();
	for(XplNode* node = p_Childs->FirstNode(); node != NULL ; node = p_Childs->NextNode()){
		if(node->get_ElementName()==DT("EndCFPermissions")){
			new_List->InsertAtEnd(node);
		}
	}
	return new_List;
}
XplNode* XplFunctionBody::new_label(){
	XplNode* node = new XplNode(ZOENODETYPE_STRING);
	node->set_ElementName(DT("label"));
	return node;
}
XplSetonerror* XplFunctionBody::new_setonerror(){
	XplSetonerror* node = new XplSetonerror();
	node->set_ElementName(DT("setonerror"));
	return node;
}
XplDeclaratorlist* XplFunctionBody::new_Decls(){
	XplDeclaratorlist* node = new XplDeclaratorlist();
	node->set_ElementName(DT("Decls"));
	return node;
}
XplExpression* XplFunctionBody::new_e(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("e"));
	return node;
}
XplSwitchStatement* XplFunctionBody::new_switch(){
	XplSwitchStatement* node = new XplSwitchStatement();
	node->set_ElementName(DT("switch"));
	return node;
}
XplIfStatement* XplFunctionBody::new_if(){
	XplIfStatement* node = new XplIfStatement();
	node->set_ElementName(DT("if"));
	return node;
}
XplForStatement* XplFunctionBody::new_for(){
	XplForStatement* node = new XplForStatement();
	node->set_ElementName(DT("for"));
	return node;
}
XplDowhileStatement* XplFunctionBody::new_do(){
	XplDowhileStatement* node = new XplDowhileStatement();
	node->set_ElementName(DT("do"));
	return node;
}
XplDowhileStatement* XplFunctionBody::new_while(){
	XplDowhileStatement* node = new XplDowhileStatement();
	node->set_ElementName(DT("while"));
	return node;
}
XplFunctionBody* XplFunctionBody::new_bk(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("bk"));
	return node;
}
XplFunctionBody* XplFunctionBody::new_Get(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("Get"));
	return node;
}
XplFunctionBody* XplFunctionBody::new_Set(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("Set"));
	return node;
}
XplFunctionBody* XplFunctionBody::new_onpointer(){
	XplFunctionBody* node = new XplFunctionBody();
	node->set_ElementName(DT("onpointer"));
	return node;
}
XplTryStatement* XplFunctionBody::new_try(){
	XplTryStatement* node = new XplTryStatement();
	node->set_ElementName(DT("try"));
	return node;
}
XplExpression* XplFunctionBody::new_throw(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("throw"));
	return node;
}
XplExpression* XplFunctionBody::new_return(){
	XplExpression* node = new XplExpression();
	node->set_ElementName(DT("return"));
	return node;
}
XplJump* XplFunctionBody::new_jump(){
	XplJump* node = new XplJump();
	node->set_ElementName(DT("jump"));
	return node;
}
XplDirectoutput* XplFunctionBody::new_directoutput(){
	XplDirectoutput* node = new XplDirectoutput();
	node->set_ElementName(DT("directoutput"));
	return node;
}
XplDocumentation* XplFunctionBody::new_documentation(){
	XplDocumentation* node = new XplDocumentation();
	node->set_ElementName(DT("documentation"));
	return node;
}
XplFunctioncall* XplFunctionBody::new_selectoutput(){
	XplFunctioncall* node = new XplFunctioncall();
	node->set_ElementName(DT("selectoutput"));
	return node;
}
XplClassfactorysPermissions* XplFunctionBody::new_BeginCFPermissions(){
	XplClassfactorysPermissions* node = new XplClassfactorysPermissions();
	node->set_ElementName(DT("BeginCFPermissions"));
	return node;
}
XplNode* XplFunctionBody::new_EndCFPermissions(){
	XplNode* node = new XplNode(ZOENODETYPE_EMPTY);
	node->set_ElementName(DT("EndCFPermissions"));
	return node;
}

}

#endif
