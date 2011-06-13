/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:33
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOELAYERDZOEPROGRAMCONFIG_V1_0_CPP
#define __LAYERD_CODEDOM_ZOELAYERDZOEPROGRAMCONFIG_V1_0_CPP
#include "CDOM_XplLayerDZoeProgramConfig.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplLayerDZoeProgramConfig::XplLayerDZoeProgramConfig(){
	p_name = DT_EMPTY;
	p_moduleType = ZOELAYERDZOEPROGRAMMODULETYPE_ENUM_EXECUTABLE;
	p_defaultPlatform = DT_EMPTY;
	p_mainProcedureFileName = DT_EMPTY;
	p_defaultOutputFileName = DT_EMPTY;
	p_SourceFile = new XplNodeList();
	p_SourceFile->set_Parent(this);
	p_SourceFile->set_InsertNodeCallback(&acceptInsertNodeCallback_SourceFile);
	p_SourceFile->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SourceFile);
	p_OutputPlatform = new XplNodeList();
	p_OutputPlatform->set_Parent(this);
	p_OutputPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_OutputPlatform);
	p_OutputPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_OutputPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_ProgramRequirements=NULL;
}
XplLayerDZoeProgramConfig::XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType){
	p_name = DT_EMPTY;
	p_moduleType = ZOELAYERDZOEPROGRAMMODULETYPE_ENUM_EXECUTABLE;
	p_defaultPlatform = DT_EMPTY;
	p_mainProcedureFileName = DT_EMPTY;
	p_defaultOutputFileName = DT_EMPTY;
	set_name(n_name);
	set_moduleType(n_moduleType);
	p_SourceFile = new XplNodeList();
	p_SourceFile->set_Parent(this);
	p_SourceFile->set_InsertNodeCallback(&acceptInsertNodeCallback_SourceFile);
	p_SourceFile->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SourceFile);
	p_OutputPlatform = new XplNodeList();
	p_OutputPlatform->set_Parent(this);
	p_OutputPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_OutputPlatform);
	p_OutputPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_OutputPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_ProgramRequirements=NULL;
}
XplLayerDZoeProgramConfig::XplLayerDZoeProgramConfig(XplNodeList* n_SourceFile, XplNodeList* n_OutputPlatform, XplLayerDZoeProgramRequirements* n_ProgramRequirements){
	p_name = DT_EMPTY;
	p_moduleType = ZOELAYERDZOEPROGRAMMODULETYPE_ENUM_EXECUTABLE;
	p_defaultPlatform = DT_EMPTY;
	p_mainProcedureFileName = DT_EMPTY;
	p_defaultOutputFileName = DT_EMPTY;
	p_SourceFile = new XplNodeList();
	p_SourceFile->set_Parent(this);
	p_SourceFile->set_InsertNodeCallback(&acceptInsertNodeCallback_SourceFile);
	p_SourceFile->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SourceFile);
	p_OutputPlatform = new XplNodeList();
	p_OutputPlatform->set_Parent(this);
	p_OutputPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_OutputPlatform);
	p_OutputPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_OutputPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_ProgramRequirements=NULL;
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_SourceFile!=NULL)
	for(XplNode* node = n_SourceFile->FirstNode(); node != n_SourceFile->GetLastNode() ; node = n_SourceFile->NextNode()){
		p_SourceFile->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_OutputPlatform!=NULL)
	for(XplNode* node = n_OutputPlatform->FirstNode(); node != n_OutputPlatform->GetLastNode() ; node = n_OutputPlatform->NextNode()){
		p_OutputPlatform->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
	set_ProgramRequirements(n_ProgramRequirements);
}
XplLayerDZoeProgramConfig::XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, XplNodeList* n_SourceFile, XplNodeList* n_OutputPlatform, XplLayerDZoeProgramRequirements* n_ProgramRequirements){
	p_name = DT_EMPTY;
	p_moduleType = ZOELAYERDZOEPROGRAMMODULETYPE_ENUM_EXECUTABLE;
	p_defaultPlatform = DT_EMPTY;
	p_mainProcedureFileName = DT_EMPTY;
	p_defaultOutputFileName = DT_EMPTY;
	set_name(n_name);
	set_moduleType(n_moduleType);
	p_SourceFile = new XplNodeList();
	p_SourceFile->set_Parent(this);
	p_SourceFile->set_InsertNodeCallback(&acceptInsertNodeCallback_SourceFile);
	p_SourceFile->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SourceFile);
	p_OutputPlatform = new XplNodeList();
	p_OutputPlatform->set_Parent(this);
	p_OutputPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_OutputPlatform);
	p_OutputPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_OutputPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_ProgramRequirements=NULL;
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_SourceFile!=NULL)
	for(XplNode* node = n_SourceFile->FirstNode(); node != n_SourceFile->GetLastNode() ; node = n_SourceFile->NextNode()){
		p_SourceFile->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_OutputPlatform!=NULL)
	for(XplNode* node = n_OutputPlatform->FirstNode(); node != n_OutputPlatform->GetLastNode() ; node = n_OutputPlatform->NextNode()){
		p_OutputPlatform->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
	set_ProgramRequirements(n_ProgramRequirements);
}
XplLayerDZoeProgramConfig::XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, string n_defaultPlatform, string n_mainProcedureFileName, string n_defaultOutputFileName){
	set_name(n_name);
	set_moduleType(n_moduleType);
	set_defaultPlatform(n_defaultPlatform);
	set_mainProcedureFileName(n_mainProcedureFileName);
	set_defaultOutputFileName(n_defaultOutputFileName);
	p_SourceFile = new XplNodeList();
	p_SourceFile->set_Parent(this);
	p_SourceFile->set_InsertNodeCallback(&acceptInsertNodeCallback_SourceFile);
	p_SourceFile->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SourceFile);
	p_OutputPlatform = new XplNodeList();
	p_OutputPlatform->set_Parent(this);
	p_OutputPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_OutputPlatform);
	p_OutputPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_OutputPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_ProgramRequirements=NULL;
}
XplLayerDZoeProgramConfig::XplLayerDZoeProgramConfig(XplNodeList* n_SourceFile, XplNodeList* n_OutputPlatform, XplNodeList* n_PlatformAlias, XplLayerDZoeProgramRequirements* n_ProgramRequirements){
	p_name = DT_EMPTY;
	p_moduleType = ZOELAYERDZOEPROGRAMMODULETYPE_ENUM_EXECUTABLE;
	p_defaultPlatform = DT_EMPTY;
	p_mainProcedureFileName = DT_EMPTY;
	p_defaultOutputFileName = DT_EMPTY;
	p_SourceFile = new XplNodeList();
	p_SourceFile->set_Parent(this);
	p_SourceFile->set_InsertNodeCallback(&acceptInsertNodeCallback_SourceFile);
	p_SourceFile->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SourceFile);
	p_OutputPlatform = new XplNodeList();
	p_OutputPlatform->set_Parent(this);
	p_OutputPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_OutputPlatform);
	p_OutputPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_OutputPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_ProgramRequirements=NULL;
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_SourceFile!=NULL)
	for(XplNode* node = n_SourceFile->FirstNode(); node != n_SourceFile->GetLastNode() ; node = n_SourceFile->NextNode()){
		p_SourceFile->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_OutputPlatform!=NULL)
	for(XplNode* node = n_OutputPlatform->FirstNode(); node != n_OutputPlatform->GetLastNode() ; node = n_OutputPlatform->NextNode()){
		p_OutputPlatform->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_PlatformAlias!=NULL)
	for(XplNode* node = n_PlatformAlias->FirstNode(); node != n_PlatformAlias->GetLastNode() ; node = n_PlatformAlias->NextNode()){
		p_PlatformAlias->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
	set_ProgramRequirements(n_ProgramRequirements);
}
XplLayerDZoeProgramConfig::XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, string n_defaultPlatform, string n_mainProcedureFileName, string n_defaultOutputFileName, XplNodeList* n_SourceFile, XplNodeList* n_OutputPlatform, XplLayerDZoeProgramRequirements* n_ProgramRequirements){
	set_name(n_name);
	set_moduleType(n_moduleType);
	set_defaultPlatform(n_defaultPlatform);
	set_mainProcedureFileName(n_mainProcedureFileName);
	set_defaultOutputFileName(n_defaultOutputFileName);
	set_name(n_name);
	set_moduleType(n_moduleType);
	p_SourceFile = new XplNodeList();
	p_SourceFile->set_Parent(this);
	p_SourceFile->set_InsertNodeCallback(&acceptInsertNodeCallback_SourceFile);
	p_SourceFile->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SourceFile);
	p_OutputPlatform = new XplNodeList();
	p_OutputPlatform->set_Parent(this);
	p_OutputPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_OutputPlatform);
	p_OutputPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_OutputPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_ProgramRequirements=NULL;
}
XplLayerDZoeProgramConfig::XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, XplNodeList* n_SourceFile, XplNodeList* n_OutputPlatform, XplNodeList* n_PlatformAlias, XplLayerDZoeProgramRequirements* n_ProgramRequirements){
	p_name = DT_EMPTY;
	p_moduleType = ZOELAYERDZOEPROGRAMMODULETYPE_ENUM_EXECUTABLE;
	p_defaultPlatform = DT_EMPTY;
	p_mainProcedureFileName = DT_EMPTY;
	p_defaultOutputFileName = DT_EMPTY;
	set_name(n_name);
	set_moduleType(n_moduleType);
	p_SourceFile = new XplNodeList();
	p_SourceFile->set_Parent(this);
	p_SourceFile->set_InsertNodeCallback(&acceptInsertNodeCallback_SourceFile);
	p_SourceFile->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SourceFile);
	p_OutputPlatform = new XplNodeList();
	p_OutputPlatform->set_Parent(this);
	p_OutputPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_OutputPlatform);
	p_OutputPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_OutputPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_ProgramRequirements=NULL;
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_SourceFile!=NULL)
	for(XplNode* node = n_SourceFile->FirstNode(); node != n_SourceFile->GetLastNode() ; node = n_SourceFile->NextNode()){
		p_SourceFile->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_OutputPlatform!=NULL)
	for(XplNode* node = n_OutputPlatform->FirstNode(); node != n_OutputPlatform->GetLastNode() ; node = n_OutputPlatform->NextNode()){
		p_OutputPlatform->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_PlatformAlias!=NULL)
	for(XplNode* node = n_PlatformAlias->FirstNode(); node != n_PlatformAlias->GetLastNode() ; node = n_PlatformAlias->NextNode()){
		p_PlatformAlias->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
	set_ProgramRequirements(n_ProgramRequirements);
}
XplLayerDZoeProgramConfig::XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, string n_defaultPlatform, string n_mainProcedureFileName, string n_defaultOutputFileName, XplNodeList* n_SourceFile, XplNodeList* n_OutputPlatform, XplNodeList* n_PlatformAlias, XplLayerDZoeProgramRequirements* n_ProgramRequirements){
	set_name(n_name);
	set_moduleType(n_moduleType);
	set_defaultPlatform(n_defaultPlatform);
	set_mainProcedureFileName(n_mainProcedureFileName);
	set_defaultOutputFileName(n_defaultOutputFileName);
	p_SourceFile = new XplNodeList();
	p_SourceFile->set_Parent(this);
	p_SourceFile->set_InsertNodeCallback(&acceptInsertNodeCallback_SourceFile);
	p_SourceFile->set_RemoveNodeCallback(&acceptRemoveNodeCallback_SourceFile);
	p_OutputPlatform = new XplNodeList();
	p_OutputPlatform->set_Parent(this);
	p_OutputPlatform->set_InsertNodeCallback(&acceptInsertNodeCallback_OutputPlatform);
	p_OutputPlatform->set_RemoveNodeCallback(&acceptRemoveNodeCallback_OutputPlatform);
	p_PlatformAlias = new XplNodeList();
	p_PlatformAlias->set_Parent(this);
	p_PlatformAlias->set_InsertNodeCallback(&acceptInsertNodeCallback_PlatformAlias);
	p_PlatformAlias->set_RemoveNodeCallback(&acceptRemoveNodeCallback_PlatformAlias);
	p_ProgramRequirements=NULL;
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_SourceFile!=NULL)
	for(XplNode* node = n_SourceFile->FirstNode(); node != n_SourceFile->GetLastNode() ; node = n_SourceFile->NextNode()){
		p_SourceFile->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_OutputPlatform!=NULL)
	for(XplNode* node = n_OutputPlatform->FirstNode(); node != n_OutputPlatform->GetLastNode() ; node = n_OutputPlatform->NextNode()){
		p_OutputPlatform->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_PlatformAlias!=NULL)
	for(XplNode* node = n_PlatformAlias->FirstNode(); node != n_PlatformAlias->GetLastNode() ; node = n_PlatformAlias->NextNode()){
		p_PlatformAlias->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
	set_ProgramRequirements(n_ProgramRequirements);
}
//Destructor
XplLayerDZoeProgramConfig::~XplLayerDZoeProgramConfig(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplLayerDZoeProgramConfig'");
#endif
	//Variables para Elementos de Secuencia
	if(p_SourceFile!=NULL)delete p_SourceFile;
	if(p_OutputPlatform!=NULL)delete p_OutputPlatform;
	if(p_PlatformAlias!=NULL)delete p_PlatformAlias;
	if(p_ProgramRequirements!=NULL)delete p_ProgramRequirements;
}

//Funciones Sobreescritas de XplNode
XplNode* XplLayerDZoeProgramConfig::Clone(){
	XplLayerDZoeProgramConfig* copy = new XplLayerDZoeProgramConfig();
	copy->set_name(this->p_name);
	copy->set_moduleType(this->p_moduleType);
	copy->set_defaultPlatform(this->p_defaultPlatform);
	copy->set_mainProcedureFileName(this->p_mainProcedureFileName);
	copy->set_defaultOutputFileName(this->p_defaultOutputFileName);
	for(XplNode* node = p_SourceFile->FirstNode(); node != NULL ; node = p_SourceFile->NextNode()){
		copy->get_SourceFile()->InsertAtEnd(node->Clone());
	}
	for(XplNode* node = p_OutputPlatform->FirstNode(); node != NULL ; node = p_OutputPlatform->NextNode()){
		copy->get_OutputPlatform()->InsertAtEnd(node->Clone());
	}
	for(XplNode* node = p_PlatformAlias->FirstNode(); node != NULL ; node = p_PlatformAlias->NextNode()){
		copy->get_PlatformAlias()->InsertAtEnd(node->Clone());
	}
	if(p_ProgramRequirements!=NULL)copy->set_ProgramRequirements((XplLayerDZoeProgramRequirements*)p_ProgramRequirements->Clone());
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplLayerDZoeProgramConfig::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_name != DT_EMPTY)
		writer->write(DT(" name=\"")+CODEDOM_Att_ToString(p_name)+DT("\""));
	if(p_moduleType != ZOELAYERDZOEPROGRAMMODULETYPE_ENUM_EXECUTABLE)
		writer->write(DT(" moduleType=\"")+(string)__CODEDOM_ZOELAYERDZOEPROGRAMMODULETYPE_ENUM[p_moduleType]+DT("\""));
	if(p_defaultPlatform != DT_EMPTY)
		writer->write(DT(" defaultPlatform=\"")+CODEDOM_Att_ToString(p_defaultPlatform)+DT("\""));
	if(p_mainProcedureFileName != DT_EMPTY)
		writer->write(DT(" mainProcedureFileName=\"")+CODEDOM_Att_ToString(p_mainProcedureFileName)+DT("\""));
	if(p_defaultOutputFileName != DT_EMPTY)
		writer->write(DT(" defaultOutputFileName=\"")+CODEDOM_Att_ToString(p_defaultOutputFileName)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_SourceFile!=NULL)if(!p_SourceFile->Write(writer))result=false;
	if(p_OutputPlatform!=NULL)if(!p_OutputPlatform->Write(writer))result=false;
	if(p_PlatformAlias!=NULL)if(!p_PlatformAlias->Write(writer))result=false;
	if(p_ProgramRequirements!=NULL)if(!p_ProgramRequirements->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplLayerDZoeProgramConfig::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
string XplLayerDZoeProgramConfig::get_name(){
	return p_name;
}
XplLayerDZoeProgramModuletype_enum XplLayerDZoeProgramConfig::get_moduleType(){
	return p_moduleType;
}
string XplLayerDZoeProgramConfig::get_defaultPlatform(){
	return p_defaultPlatform;
}
string XplLayerDZoeProgramConfig::get_mainProcedureFileName(){
	return p_mainProcedureFileName;
}
string XplLayerDZoeProgramConfig::get_defaultOutputFileName(){
	return p_defaultOutputFileName;
}

//Funciones para obtener Elementos de Secuencia
XplNodeList* XplLayerDZoeProgramConfig::get_SourceFile(){
	return p_SourceFile;
}
XplNodeList* XplLayerDZoeProgramConfig::get_OutputPlatform(){
	return p_OutputPlatform;
}
XplNodeList* XplLayerDZoeProgramConfig::get_PlatformAlias(){
	return p_PlatformAlias;
}
XplLayerDZoeProgramRequirements* XplLayerDZoeProgramConfig::get_ProgramRequirements(){
	return p_ProgramRequirements;
}

//Funciones para setear Atributos
string XplLayerDZoeProgramConfig::set_name(string new_name){
	string back_name = p_name;
	p_name = new_name;
	return back_name;
}
XplLayerDZoeProgramModuletype_enum XplLayerDZoeProgramConfig::set_moduleType(XplLayerDZoeProgramModuletype_enum new_moduleType){
	XplLayerDZoeProgramModuletype_enum back_moduleType = p_moduleType;
	p_moduleType = new_moduleType;
	return back_moduleType;
}
string XplLayerDZoeProgramConfig::set_defaultPlatform(string new_defaultPlatform){
	string back_defaultPlatform = p_defaultPlatform;
	p_defaultPlatform = new_defaultPlatform;
	return back_defaultPlatform;
}
string XplLayerDZoeProgramConfig::set_mainProcedureFileName(string new_mainProcedureFileName){
	string back_mainProcedureFileName = p_mainProcedureFileName;
	p_mainProcedureFileName = new_mainProcedureFileName;
	return back_mainProcedureFileName;
}
string XplLayerDZoeProgramConfig::set_defaultOutputFileName(string new_defaultOutputFileName){
	string back_defaultOutputFileName = p_defaultOutputFileName;
	p_defaultOutputFileName = new_defaultOutputFileName;
	return back_defaultOutputFileName;
}

//Funciones para setear Elementos de Secuencia
	bool XplLayerDZoeProgramConfig::acceptInsertNodeCallback_SourceFile(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("SourceFile")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOESOURCEFILE){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplSourceFile'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplSourceFile'."));
		return false;
	}
	bool XplLayerDZoeProgramConfig::acceptRemoveNodeCallback_SourceFile(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}
	bool XplLayerDZoeProgramConfig::acceptInsertNodeCallback_OutputPlatform(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("OutputPlatform")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOETARGETPLATFORM){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplTargetPlatform'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplTargetPlatform'."));
		return false;
	}
	bool XplLayerDZoeProgramConfig::acceptRemoveNodeCallback_OutputPlatform(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}
	bool XplLayerDZoeProgramConfig::acceptInsertNodeCallback_PlatformAlias(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("PlatformAlias")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEPLATFORMALIAS){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplPlatformAlias'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplPlatformAlias'."));
		return false;
	}
	bool XplLayerDZoeProgramConfig::acceptRemoveNodeCallback_PlatformAlias(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}
XplLayerDZoeProgramRequirements* XplLayerDZoeProgramConfig::set_ProgramRequirements(XplLayerDZoeProgramRequirements* new_ProgramRequirements){
	XplLayerDZoeProgramRequirements* back_ProgramRequirements = p_ProgramRequirements;
	p_ProgramRequirements = new_ProgramRequirements;
	if(p_ProgramRequirements!=NULL){
		p_ProgramRequirements->set_ElementName(DT("ProgramRequirements"));
		p_ProgramRequirements->set_Parent(this);
	}
	return back_ProgramRequirements;
}
XplSourceFile* XplLayerDZoeProgramConfig::new_SourceFile(){
	XplSourceFile* node = new XplSourceFile();
	node->set_ElementName(DT("SourceFile"));
	return node;
}
XplTargetPlatform* XplLayerDZoeProgramConfig::new_OutputPlatform(){
	XplTargetPlatform* node = new XplTargetPlatform();
	node->set_ElementName(DT("OutputPlatform"));
	return node;
}
XplPlatformAlias* XplLayerDZoeProgramConfig::new_PlatformAlias(){
	XplPlatformAlias* node = new XplPlatformAlias();
	node->set_ElementName(DT("PlatformAlias"));
	return node;
}
XplLayerDZoeProgramRequirements* XplLayerDZoeProgramConfig::new_ProgramRequirements(){
	XplLayerDZoeProgramRequirements* node = new XplLayerDZoeProgramRequirements();
	node->set_ElementName(DT("ProgramRequirements"));
	return node;
}

}

#endif
