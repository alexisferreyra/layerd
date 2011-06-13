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

#ifndef __LAYERD_CODEDOM_BASE_V1_0_H
#define __LAYERD_CODEDOM_BASE_V1_0_H

#define LAYERD_ZOE_CODEDOM_VERSION L"Alpha 0.990"

#include <fstream>
#include <string>
#include <vector>

/* MACROS */
#define DT(n) L##n
#define DOM_CHAR wchar_t
#define DOM_CHARP wchar_t*
#define DT_EMPTY L""

#include "CDOM_SimpleTypes.h"
#include "CDOM_PreDecl.h"

/*	TAREAS PENDIENTES EN RELACION AL CODEDOM:

		-IMPLEMENTAR LOS METODOS "READ"
		-IMPLEMENTAR METODOS EN CADA ELEMENTO PARA OBTENER UN NUEVO ELEMENTO HIJO,
		COMO "XplTryStatement* get_newTry()", ESTARIA BUENO QUE HUBIERA VERSIONES
		QUE TOMARAN COMO PARAMETRO LOS ATRIBUTOS REQUERIDOS DEL ELEMENTO A AGREGAR
		Y LOS ELEMENTOS REQUERIDOS Y AMBAS COSAS JUNTAS.
		-CAPACIDAD PARA CHEQUEAR LA CORRECCIÓN DE UN ELEMENTO SELECTIVAMENTE,
		ES DECIR SI ESTA LEVANTADA LA BANDERA PARA HACER ESO
		-MEJORAR EL WRITE DE LOS ELEMENTOS PARA QUE TENGAN LA CAPACIDAD DE IDENTARSE
		DE ACUERDO AL ESTADO DE UNA BANDERA GLOBAL.
		-QUE CADA NODO PUEDA SABER CUAL ES SU DOCUMENTO PADRE, DONDE SE GUARDE
		INFO GENERAL DEL DOCUMENTO.
		-TERMINAR DE IMPLEMENTAR LA COLECCION "ZOENODELIST"
*/

namespace CodeDOM{
	/*
		DEFINICIONES DE TIPOS BASICOS A UTILIZAR
	*/
	typedef std::basic_string<wchar_t> string;
	typedef wchar_t* DateTime;

	string CODEDOM_Att_ToString(string p);
	string CODEDOM_Att_ToString(const wchar_t* p);
	string CODEDOM_Att_ToString(unsigned int p);
	string CODEDOM_Att_ToString(bool p);
	string CODEDOM_Att_ToString(int p);

	class CodeDOM_Exception{
	private:
		string error;
		string source;
	public:
		CodeDOM_Exception(string new_error, string new_source);
		CodeDOM_Exception(string new_error);
		void set_error(string new_error);
		void set_source(string new_source);
		string get_error();
		string get_source();
	};
	class CodeDOM_NotImplementedException:public CodeDOM_Exception{
	public:
		CodeDOM_NotImplementedException(string source);
	};
	class XplWriter{
		std::wiostream* writer;
		int writer2;
	public:
		XplWriter(std::wiostream *new_writer);
		XplWriter(int new_writer);
		bool write(string toWrite);
	};
	class XplReader{
	};
	enum XplNodeType_enum{
		ZOENODETYPE_COMPLEX,
		ZOENODETYPE_STRING,
		ZOENODETYPE_INT,
		ZOENODETYPE_UNSIGNED,
		ZOENODETYPE_DATETIME,
		ZOENODETYPE_BOOL,
		ZOENODETYPE_EMPTY
	};
	union XplNodeValueType{
		wchar_t* stringValue;
		int intValue;
		unsigned int unsignedValue;
		DateTime dateTimeValue;
		bool boolValue;
	};
	class XplNode{
		string p_Name;
		string p_errorString;
		XplNodeType_enum p_nodeType;
		XplNodeValueType p_value;
		XplNode* p_parent;
	public:
		XplNode();
		XplNode(string new_Name);
		XplNode(XplNodeType_enum new_nodeType);
		XplNode(string new_Name, string new_stringValue);
		XplNode(string new_Name, wchar_t* new_stringValue);
		XplNode(string new_Name, int new_intValue);
		XplNode(string new_Name, unsigned int new_unsignedValue);
		XplNode(string new_Name, bool new_boolValue);

		virtual ~XplNode();

		void set_Parent(XplNode* new_Parent);
		XplNode* Parent();

		void set_Value(string new_stringValue);
		void set_Value(int new_value);
		string get_stringValue();
		int get_intValue();
		unsigned int get_unsignedValue();
		bool get_boolValue();
		DateTime get_dateTimeValue();
		void set_ElementName(string new_Name);
		string get_ElementName();
		string get_ErrorString();
		void set_ErrorString(string new_errorString);

		virtual int get_ContentTypeName();
		string get_ContentTypeNameString();
		virtual int get_TypeName();
		virtual XplNode* Clone();
		virtual bool Write(XplWriter* writer);
		virtual XplNode* Read(XplReader* reader);

		virtual XplNodeList* Childs(){return NULL;}

		virtual string set_doc(string new_doc){return L"";}
		virtual string set_helpURL(string new_helpURL){return L"";}
		virtual string set_ldsrc(string new_ldsrc){return L"";}
		virtual bool set_iny(bool new_iny){return false;}
		virtual string set_inydata(string new_inydata){return L"";}
		virtual string set_inyby(string new_inyby){return L"";}
		virtual string set_lddata(string new_lddata){return L"";}
		
		virtual string get_doc(){return L"";}
		virtual string get_helpURL(){return L"";}
		virtual string get_ldsrc(){return L"";}
		virtual bool get_iny(){return false;}
		virtual string get_inydata(){return L"";}
		virtual string get_inyby(){return L"";}
		virtual string get_lddata(){return L"";}

	};
	
	/*	TIPO PARA EL CALLBACK DE LA LISTA DE NODOS	*/
	typedef bool (*InsertNodeCallback)(XplNode* , string*, XplNode* ) ;

	class XplNodeList{
		InsertNodeCallback p_insertCallback;
		InsertNodeCallback p_removeCallback;
		typedef std::vector<XplNode*>::iterator ListIterator;
		std::vector<XplNode*> p_list;
		ListIterator p_iterator;
		XplNode* p_parent;
	public:
		XplNodeList();
		~XplNodeList();
		void set_Parent(XplNode* new_parent);
		virtual bool Write(XplWriter* writer);
		void set_InsertNodeCallback(InsertNodeCallback callback);
		void set_RemoveNodeCallback(InsertNodeCallback callback);
		XplNode *FirstNode();
		XplNode *NextNode();
		XplNode *PreviousNode();
		XplNode *LastNode();
		XplNode *GetLastNode();
		XplNode *InsertAtEnd(XplNode* newNode);
		XplNode *InsertAtBegin(XplNode* newNode);
		XplNode *getNodeAt(unsigned int position);
		unsigned int getLenght();
		XplNode *InsertAt(XplNode* newNode, unsigned int position);
		XplNode *InsertAfter(XplNode* newNode, XplNode* reference);
		XplNode *InsertBefore(XplNode* newNode, XplNode* reference);
		XplNode *Remove(long int position);
		bool Contains(XplNode *Node);
		bool Clear();
		int get_TypeName();
	};
}

#endif
