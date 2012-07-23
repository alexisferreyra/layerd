/*-
 * Copyright (c) 2002-2008 Alexis Ferreyra
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 * 3. Neither the name of copyright holders nor the names of its
 *    contributors may be used to endorse or promote products derived
 *    from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
 * TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
 * PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL COPYRIGHT HOLDERS OR CONTRIBUTORS
 * BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 */

#ifndef __LAYERD_CODEDOM_BASE_V1_0_CPP
#define __LAYERD_CODEDOM_BASE_V1_0_CPP

#include <fstream>
#include <string>
#include <vector>
#include <stdlib.h>
#include <io.h>
#include "CDOMBase.h"

namespace CodeDOM{

	string CODEDOM_Att_ToString(string p){
		return p;
	}
	string CODEDOM_Att_ToString(const wchar_t* p){
		return p;
	}
	string CODEDOM_Att_ToString(unsigned int p){
		wchar_t buffer[40];
		_itow(p,buffer,10);
		return buffer;
	}
	string CODEDOM_Att_ToString(bool p){
		if(p)return L"true";
		else return L"false";
	}
	string CODEDOM_Att_ToString(int p){
		wchar_t buffer[40];
		_itow(p,buffer,10);
		return buffer;
	}

		CodeDOM_Exception::CodeDOM_Exception(string new_error, string new_source){
			error=new_error;
			source=new_source;
		}
		CodeDOM_Exception::CodeDOM_Exception(string new_error){
			CodeDOM_Exception(new_error,L"");
		}
		void CodeDOM_Exception::set_error(string new_error){
			error=new_error;
		}
		void CodeDOM_Exception::set_source(string new_source){
			source=new_source;
		}
		string CodeDOM_Exception::get_error(){return error;}
		string CodeDOM_Exception::get_source(){return source;}

		CodeDOM_NotImplementedException::CodeDOM_NotImplementedException(string source):CodeDOM_Exception(L"Método no Implementado.",source){
		}

		XplWriter::XplWriter(std::wiostream *new_writer){
			writer=new_writer;
			writer2=-1;
		}
		XplWriter::XplWriter(int new_writer){
			writer2=new_writer;
			writer=NULL;
		}
		bool XplWriter::write(string toWrite){
			if(writer!=NULL)
				(*writer).write((const wchar_t*)toWrite.c_str(),toWrite.length());
			else{
				const wchar_t *ptr1 = 0;
				ptr1= toWrite.data ( );
				_write(writer2,ptr1,wcslen ( ptr1)*sizeof(wchar_t) );
				//_write(writer2,(const wchar_t*)toWrite.c_str(),toWrite.length()*sizeof(wchar_t));
				//_write(writer2,(const wchar_t*)toWrite.c_str(),toWrite.length());
			}
			return true;
		}

		XplNode::XplNode(){
			p_Name=L"";
			p_errorString=L"";
			p_nodeType=ZOENODETYPE_COMPLEX;
			p_parent=NULL;
			p_value.intValue=0;
		}
		XplNode::XplNode(string new_Name){
			p_nodeType=ZOENODETYPE_COMPLEX;
			p_Name=new_Name;
			p_errorString=L"";
			p_parent=NULL;
			p_value.intValue=0;
		}
		XplNode::XplNode(XplNodeType_enum new_nodeType){
			p_Name=L"";
			p_errorString=L"";
			p_nodeType=new_nodeType;
			p_parent=NULL;
			p_value.intValue=0;
		}
		XplNode::XplNode(string new_Name, wchar_t* new_stringValue){
			XplNode(new_Name,(string)new_stringValue);
		}
		XplNode::XplNode(string new_Name, string new_stringValue){
			p_Name=new_Name;
			p_nodeType=ZOENODETYPE_STRING;
			p_value.stringValue=new wchar_t[new_stringValue.length()+1];
			wcscpy(p_value.stringValue,new_stringValue.c_str());
			p_errorString=L"";
			p_parent=NULL;
		}
		XplNode::XplNode(string new_Name, int new_intValue){
			p_Name=new_Name;
			p_nodeType=ZOENODETYPE_INT;
			p_value.intValue=new_intValue;
			p_errorString=L"";
			p_parent=NULL;
		}
		XplNode::XplNode(string new_Name, unsigned int new_unsignedValue){
			p_Name=new_Name;
			p_nodeType=ZOENODETYPE_UNSIGNED;
			p_value.unsignedValue=new_unsignedValue;
			p_errorString=L"";
			p_parent=NULL;
		}
		XplNode::XplNode(string new_Name, bool new_boolValue){
			p_Name=new_Name;
			p_nodeType=ZOENODETYPE_BOOL;
			p_value.boolValue=new_boolValue;
			p_errorString=L"";
			p_parent=NULL;
		}
		void XplNode::set_Parent(XplNode* new_Parent){
			p_parent=new_Parent;
		}
		XplNode* XplNode::Parent(){
			return p_parent;
		}
		void XplNode::set_Value(string new_stringValue){
			if(p_nodeType==ZOENODETYPE_STRING){
				p_value.stringValue=new wchar_t[new_stringValue.length()+1];
				wcscpy(p_value.stringValue,new_stringValue.c_str());
			}
		}
		void XplNode::set_Value(int new_value){
			p_value.intValue=new_value;
		}
		string XplNode::get_stringValue(){
			return p_value.stringValue;
		}
		int XplNode::get_intValue(){
			return p_value.intValue;
		}
		unsigned int XplNode::get_unsignedValue(){
			return p_value.unsignedValue;
		}
		bool XplNode::get_boolValue(){
			return p_value.boolValue;
		}
		DateTime XplNode::get_dateTimeValue(){
			return p_value.dateTimeValue;
		}
		XplNode::~XplNode(){
			if(p_nodeType==ZOENODETYPE_STRING){
				#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
					__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de XplNode. Nombre:");
					__LAYERD_CODEDOM_DEBUG_OUTPUT_W(p_Name);
				#endif
				if(p_value.stringValue!=NULL)delete p_value.stringValue;
			}
		}
		void XplNode::set_ElementName(string new_Name){
			p_Name=new_Name;
		}
		string XplNode::get_ElementName(){
			return p_Name;
		}
		string XplNode::get_ContentTypeNameString(){
			return DT("ZOENODE");
		}
		int XplNode::get_ContentTypeName(){
			if(p_nodeType==ZOENODETYPE_COMPLEX)return get_TypeName();
			switch(p_nodeType){
				case ZOENODETYPE_STRING:
					return CODEDOMTYPES_STRING;
				case ZOENODETYPE_INT:
					return CODEDOMTYPES_INTEGER;
				case ZOENODETYPE_UNSIGNED:
					return CODEDOMTYPES_UNSIGNED;
				case ZOENODETYPE_DATETIME:
					return CODEDOMTYPES_DATETIME;
				case ZOENODETYPE_BOOL:
					return CODEDOMTYPES_BOOLEAN;
				case ZOENODETYPE_EMPTY:
					return CODEDOMTYPES_EMPTY;
				default:
					return CODEDOMTYPES_EMPTY;
			};
		}
		XplNode* XplNode::Clone(){
			if(p_nodeType==ZOENODETYPE_COMPLEX) 
				throw new CodeDOM_NotImplementedException(L"Clone");
			else{
				XplNode* copy = NULL;
				switch(p_nodeType){
					case ZOENODETYPE_STRING:
						copy=new XplNode(p_Name,(string)p_value.stringValue);
						break;
					case ZOENODETYPE_INT:
						copy=new XplNode(p_Name,p_value.intValue);
						break;
					case ZOENODETYPE_UNSIGNED:
						copy=new XplNode(p_Name,p_value.unsignedValue);
						break;
					case ZOENODETYPE_DATETIME:
						copy=new XplNode(ZOENODETYPE_DATETIME);
						copy->set_ElementName(p_Name);
						copy->set_Value((string)p_value.dateTimeValue);
						break;
					case ZOENODETYPE_BOOL:
						copy=new XplNode(p_Name,p_value.boolValue);
						break;
					case ZOENODETYPE_EMPTY:
						copy=new XplNode(ZOENODETYPE_EMPTY);
						copy->set_ElementName(p_Name);
						break;
					default:
						break;
				};
				copy->set_ErrorString(p_errorString);
				return copy;
			}
		}
		string XplNode::get_ErrorString(){
			return p_errorString;
		}
		void XplNode::set_ErrorString(string new_errorString){
			p_errorString=new_errorString;
		}
		int XplNode::get_TypeName(){return CODEDOMTYPES_ZOENODE;}

		bool XplNode::Write(XplWriter* writer){
			bool result=true;
			//Escribo el encabezado del elemento
			writer->write(L"<"+p_Name+L">");
			switch(p_nodeType){
				case ZOENODETYPE_STRING:
					if(p_value.stringValue!=NULL)writer->write(CODEDOM_Att_ToString(p_value.stringValue));
					break;
				case ZOENODETYPE_INT:
					writer->write(CODEDOM_Att_ToString(p_value.intValue));
					break;
				case ZOENODETYPE_UNSIGNED:
					writer->write(CODEDOM_Att_ToString(p_value.unsignedValue));
					break;
				case ZOENODETYPE_DATETIME:
					writer->write(CODEDOM_Att_ToString(p_value.dateTimeValue));
					break;
				case ZOENODETYPE_BOOL:
					writer->write(CODEDOM_Att_ToString(p_value.boolValue));
					break;
				case ZOENODETYPE_EMPTY:
					//No escribo nada
					break;
				default:
					break;
			};
			//Cierro el elemento
			writer->write(L"</"+p_Name+L">");
			return result;
		}
		XplNode* XplNode::Read(XplReader* reader){
			throw new CodeDOM_NotImplementedException(L"Read");
		}
	
	/*	TIPO PARA EL CALLBACK DE LA LISTA DE NODOS	*/
	typedef bool (*InsertNodeCallback)(XplNode* , string*, XplNode* ) ;

		XplNodeList::XplNodeList(){
			p_insertCallback=NULL;
			p_removeCallback=NULL;
			p_parent=NULL;
		}
		XplNodeList::~XplNodeList(){
			#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
				__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de XplNodeList.");
			#endif
			ListIterator it;
			for(it=p_list.begin();it!=p_list.end();it++)
				if(((XplNode*)*it)!=NULL){
					delete *it;
				}
		}
		void XplNodeList::set_Parent(XplNode* new_parent){
			p_parent=new_parent;
		}
		bool XplNodeList::Write(XplWriter* writer){
			ListIterator it;
			for(it=p_list.begin();it!=p_list.end();it++)
				if(!((XplNode*)*it)->Write(writer)) return false;
			return true;
		}
		void XplNodeList::set_InsertNodeCallback(InsertNodeCallback callback){
			p_insertCallback=callback;
		}
		void XplNodeList::set_RemoveNodeCallback(InsertNodeCallback callback){
			p_removeCallback=callback;
		}
		XplNode *XplNodeList::FirstNode(){
			this->p_iterator=p_list.begin();
			if(p_iterator==p_list.end())return NULL;
			return *p_iterator;
		}
		XplNode *XplNodeList::NextNode(){
			p_iterator++;
			if(p_iterator==p_list.end())return NULL;
			return *p_iterator;
		}
		XplNode *XplNodeList::PreviousNode(){
			p_iterator--;
			return *p_iterator;
		}
		XplNode *XplNodeList::LastNode(){
			p_iterator=p_list.end();
			if(p_iterator!=p_list.begin())p_iterator--;
			return (XplNode*)*p_iterator;
		}
		XplNode *XplNodeList::GetLastNode(){
			return NULL;
		}
		XplNode *XplNodeList::InsertAtEnd(XplNode* newNode){
			string *error=NULL;
			if(p_insertCallback==NULL || p_insertCallback(newNode,error,p_parent)){
				p_list.push_back(newNode);
				return newNode;
			}
			else{
				if(error!=NULL)delete error;
				return NULL;
			}
		}
		XplNode *XplNodeList::InsertAtBegin(XplNode* newNode){
			string *error=NULL;
			if(p_insertCallback==NULL || p_insertCallback(newNode,error,p_parent)){
				p_list.insert(p_list.begin(),newNode);
				return newNode;
			}
			else{
				if(error!=NULL)delete error;
				return NULL;
			}
		}
		XplNode *XplNodeList::getNodeAt(unsigned int position){
			if(position<=p_list.size())
				return (XplNode*)p_list[position];
			else 
				return NULL;
		}
		unsigned int XplNodeList::getLenght(){
			//La cantidad de nodos en la lista.
			return (unsigned int)p_list.size();
		}
		XplNode *XplNodeList::InsertAt(XplNode* newNode, unsigned int position){
			string *error=NULL;
			if(p_insertCallback==NULL || p_insertCallback(newNode,error,p_parent)){
				ListIterator it=p_list.begin();
				it+=position;
				p_list.insert(it,newNode);
				return newNode;
			}
			else{
				if(error!=NULL)delete error;
				return NULL;
			}
		}
		XplNode *XplNodeList::InsertAfter(XplNode* newNode, XplNode* reference){
			return NULL;
		}
		XplNode *XplNodeList::InsertBefore(XplNode* newNode, XplNode* reference){
			return NULL;
		}
		XplNode *XplNodeList::Remove(long int position){
			XplNode* node=(XplNode*)p_list[position];
			ListIterator it=p_list.begin();
			it+=position;
			p_list.erase(it);
			return node;
		}
		int XplNodeList::get_TypeName(){return CODEDOMTYPES_ZOENODELIST;}

		bool XplNodeList::Contains(XplNode *Node){
			//Puede utilizar el valor del puntero para saber si existe en la coleccion
			return false;
		}
		bool XplNodeList::Clear(){
			p_list.clear();
			return true;
		}
}

#endif
