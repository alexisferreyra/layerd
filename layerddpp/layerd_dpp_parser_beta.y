%{
/*-
 * Copyright (c) 2008 Alexis Ferreyra
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

/****************************************************************************
  layerd_dpp_parser_beta.y

  Parser for Meta D++ Compiler
  
  This file must be processed with BtYacc parser 
  generator. Yacc will not function because it 
  doesn't support ambiguous LR(1) grammars.

  Original Author: Alexis Ferreyra
  Contact: alexis.ferreyra@layerd.net
  
  Please visit http://layerd.net to get the last version
  of the software and information about LayerD technology.

****************************************************************************/

%define DPP
#define DPP

#ifdef __LAYERDDPP_DEBUG_CODEDOM_LIB
#define __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
#define __LAYERD_CODEDOM_DEBUG_OUTPUT(n) std::cout<<n<<endl
#define __LAYERD_CODEDOM_DEBUG_OUTPUT_W(n) std::wcout<<n<<endl
#endif
//CT(n) : Macro para constantes de texto en la interfaz del compilador, diferente de DT(n) que es la macro para constantes del CodeDOM.
#define CT(n) DT(n)
#define SINTAX_ERROR(N)	AddError(N)
#define WARNING_MESSAGE(N) AddWarning(N)
#define ASSING_COMMENT(node) if(lastCommentValid){lastCommentValid=false;node->set_doc(CodeDOM::string((const DOM_CHAR*)lastCommentBuffer) );}
#define LAYERD_COMPILER_VERSION				"Beta 0.98"
#define LAYERD_COMPILER_VERSION_DOM_CHAR	L"Beta 0.98"
#define NEW_ERROR_RESUME_ZOENODELIST		NewErrorResumeXplNodeList()

void AddError(const char*error);
void AddWarning(const char*error);

#include <iostream>
#include <wchar.h>
#ifdef WIN32
#include "..\\CodeDOM\\CDOM_IncludeAll.h"
#else
#include <layerd/CDOM_IncludeAll.h>
#endif

#include "layerd_dpp_parser_beta_tab.h"

using namespace std;

//#define	SM_AUTO				0x00000001 /* Obsoleto */
#define SM_STATIC			0x00000002
#define SM_CONST			0x00000004
#define SM_VOLATILE			0x00000008
#define SM_EXTERN			0x00000010
#define SM_EXTENSION		0x00000020
#define SM_FORCE    		0x00000040
#define SM_FACTORY			0x00000080
#define SM_INTERACTIVE		0x00000100
#define SM_KEYWORD			0x00000200
#define SM_PARAMS   		0x00000400
#define SM_FINAL			0x00000800
#define SM_NEW				0x00001000
#define SM_OVERRIDE			0x00002000
#define SM_VIRTUAL			0x00004000
#define SM_EXEC				0x00008000
#define SM_ABSTRACT			0x00010000
#define SM_FPOINTER			0x00020000
#define SM_IN				0x00040000
#define SM_OUT	 			0x00080000
#define SM_INOUT 			0x00100000
#define SM_REF	 			0x00200000
#define SM_NONVIRTUAL		0x00400000

#define SM_PUBLIC			0x00800000
#define SM_PROTECTED		0x01000000
#define SM_PRIVATE			0x02000000
#define SM_IPUBLIC			0x04000000
#define SM_IPROTECTED		0x08000000
#define SM_IPRIVATE			0x10000000

#define SM_INAME			0x20000000
#define	SM_EXPRESSION		0x40000000

CodeDOM::XplNode *rootNode=NULL, *tempNode=NULL;
CodeDOM::XplWriter *writer=NULL;
//CodeDOM::XplNodeList *tempList=NULL;

struct DppOptions{
	char filename[2048];
	char outputFilename[2048];
	char configFilename[2048];
	char layerdCompiler[2048];
	char platform[2048];
	bool printWarnings;
	bool printErrors;
	bool interactive;
	bool debug;
	bool showDebug;
	bool includeComments;
	bool includeSourceData;
	bool silent;
	bool fullCompile;
	bool addExtension;
	bool library;
	DppOptions(){
		filename[0]='\0';
		outputFilename[0]='\0';
		configFilename[0]='\0';
		layerdCompiler[0]='\0';
		platform[0]='\0';
		printWarnings=true;
		printErrors=true;
		interactive=false;
		debug=false;
		includeComments=true;
		includeSourceData=true;
		silent=false;
		fullCompile=false;
		addExtension=false;
		library=false;
	}
};

DppOptions command;

/* Para el almacenamiento de errores y warnings */
vector<std::string> pErrors;
vector<std::string> pWarnings;

void SetClassMembers(CodeDOM::XplNodeList *c, CodeDOM::XplNodeList *list);
void SetDeclaratorMod(CodeDOM::XplClass* c,unsigned int num);
void SetParameterModifiers(CodeDOM::XplParameter*p, unsigned int num);
void SetLocalVarsModifiers(CodeDOM::XplDeclarator*p, unsigned int num);
void SetNewTypeModifiers(CodeDOM::XplNewExpression*t, unsigned int num);
void SetFuncStorageMod(CodeDOM::XplFunction*f,unsigned int num);
void SetFieldStorage(CodeDOM::XplField*f,unsigned int num);
void SetPropertyStorage(CodeDOM::XplProperty*f,unsigned int num);
void SetDeclaratorStorage(CodeDOM::XplDeclarator*f,unsigned int num);
void SetEnumConstantTypes(CodeDOM::XplClass*clase,unsigned int tipo);
CodeDOM::string get_OperatorFunctionName(unsigned int num);
wchar_t* get_nativeType(unsigned int num);
CodeDOM::XplClass* CreateClass(CodeDOM::string nombre, CodeDOM::XplNodeList* classMembers, CodeDOM::XplNode* inherits, CodeDOM::XplNode* implements, unsigned int tipo, unsigned int modifiers);
CodeDOM::XplForStatement* CreateFor(CodeDOM::XplNode* p_forinit,CodeDOM::XplNode* p_condition,CodeDOM::XplNode* p_update,CodeDOM::XplNode* p_statement);
CodeDOM::XplFunction* CreateFunction(unsigned int p_storage /*Storage*/,
                        CodeDOM::XplType* p_type_declarator /*Type_Decl*/,                        
                        CodeDOM::XplFunction* p_declarator_f /*Decl_F*/,
                        CodeDOM::XplParameters* p_parameters /*Parameters*/,                        
                        CodeDOM::XplBaseInitializers * p_base_initializers /*Base_Init*/,
                        CodeDOM::XplFunctionBody* p_block /*Block*/);

/* Defines necesarios para BtYacc */
#define YYDELETEPOSN(v1,v2)
#define YYDELETEVAL(v1,v2)

/* Definiciones para el trace de los numeros de linea */
#define YYPOSN int
#define GET_PARSER_POS   (yyps->psp)
#define SET_SOURCE_DATA(node,token_min,token_max) if(command.includeSourceData)node->set_ldsrc( CodeDOM::CODEDOM_Att_ToString(GET_PARSER_POS[token_min]) + DT(",") + CodeDOM::CODEDOM_Att_ToString(GET_PARSER_POS[token_max]) )
#define SET_SOURCE_DATA_S(node,token_min) if(command.includeSourceData)node->set_ldsrc( CodeDOM::CODEDOM_Att_ToString(GET_PARSER_POS[token_min]) )
#define RET_POS yyps->pos

/* Funcion de reporte de errores para yacc */
void yyerror(char* str){
  //No hago nada porque se supone que capturo los errores en las reglas de produccion.
  //cout<<str<<endl;
}

/* Funciones externas definidas por lex */
int yylex();
extern int yylineno;

/* Controlador de archivo de flex */
extern FILE* yyin;

#define COMMENT_BUFFER 4096
extern wchar_t lastCommentBuffer[COMMENT_BUFFER];
extern bool lastCommentValid;

#ifndef TRUE
#define TRUE -1
#endif

%}

// parser name
//%name LayerD_DPP_Beta_Parser

// attribute type
%union {
	CodeDOM::XplNode* node;
	CodeDOM::XplExpression* exp;
	CodeDOM::XplNodeList* list;
	CodeDOM::XplNode* nodos[4];
	CodeDOM::XplLiteral* literal;
	unsigned int num;
	DOM_CHAR str[1024];
}

// place any declarations here
%start Compilation_Unit

/*	KEYWORDS	*/
%token PC_IMPORT
%token PC_USING
%token PC_IDENTIFIERS
%token PC_ALIAS
%token PC_NAMESPACE
%token PC_CLASS
%token PC_ENUM
%token PC_UNION
%token PC_INTERFACE
%token PC_INHERITS
%token PC_IMPLEMENTS
%token PC_VIRTUAL
%token PC_NONVIRTUAL
%token PC_SETPLATFORMS
%token PC_LIKE

%token PC_AUTOINSTANCE
%token PC_BYCALL
%token PC_BYCLASS
%token PC_BYNAMESPACE
%token PC_BYCALLTO
%token PC_FPOINTER
%token PC_CONSTRUCTOR
%token PC_PUBLIC
%token PC_PROTECTED
%token PC_PRIVATE
%token PC_IPUBLIC
%token PC_IPROTECTED
%token PC_IPRIVATE
%token PC_STATIC
%token PC_CONST
%token PC_VOLATILE
%token PC_EXTERN
%token PC_FORCE
%token PC_FACTORY
%token PC_INTERACTIVE
%token PC_KEYWORD
%token PC_FINAL
%token PC_NEW
%token PC_OVERRIDE
%token PC_ABSTRACT
%token PC_PARAMS
%token PC_IN
%token PC_OUT
%token PC_INOUT
%token PC_REF
%token PC_EXTENSION
%token PC_ORDINARY
%token PC_STRUCT
%token PC_OPERATOR
%token PC_INDEXER
%token PC_PROPERTY
%token PC_GET
%token PC_EZOEICIT
%token PC_READONLY
%token PC_BLOCKTOFACTORYS
%token PC_EXCEPT
%token PC_SET
//%token PC_ERROR
//%token PC_HANDLER
%token PC_RESUME
%token PC_BREAK
%token PC_CONTINUE
//%token PC_NEXT
%token PC_SELECTOUTPUT
%token PC_WRITECODE
%token PC_IF
%token PC_ELSE
%token PC_WHILE
%token PC_DO
%token PC_FOR
%token PC_SWITCH
%token PC_CASE
%token PC_DEFAULT
%token PC_RETURN
%token PC_THROW
%token PC_TRY
%token PC_CATCH
%token PC_FINALLY
%token PC_STATIC_CAST
%token PC_DYNAMIC_CAST
//%token PC_TEMPLATE /* Obsoleto */
%token PC_DELETE
//%token PC_THIS
//%token PC_ILEFT
//%token PC_LEFT
//%token PC_CODE
//%token PC_COMPILER
%token PC_BOOL
%token PC_VOID
%token PC_OBJECT
%token PC_SBYTE
%token PC_SHORT
%token PC_INT
%token PC_LONG
%token PC_UNSIGNED
%token PC_BYTE
%token PC_USHORT
%token PC_UINT
%token PC_ULONG
%token PC_FLOAT
%token PC_DOUBLE
%token PC_DECIMAL
%token PC_CHAR
%token PC_ASCII_CHAR
%token PC_STRING
%token PC_ASCII_STRING
//%token PC_UUID /* Obsoleto */
%token PC_TYPE
%token PC_BLOCK
%token PC_EXPRESSION
%token PC_EXPRESSIONLIST
%token PC_INAME
%token PC_STATEMENT
%token PC_SIZEOF
%token PC_TYPEOF
%token PC_GETTYPE
%token PC_EXEC
%token PC_IS

%token PC_EZOEICIT
%token PC_IMPLICIT

%token USER_TYPE_NAME

/* SEPARADORES O PUNCTUATORS */

%token OPEN_PARENTESIS
%token CLOSE_PARENTESIS
%token OPEN_LLAVE
%token CLOSE_LLAVE
%token OPEN_CORCHETE
%token CLOSE_CORCHETE
%token PUNTO_COMA
%token COMA
%token PUNTO


/* OPERADORES */
%token OP_COMILLA

%token OP_IGUAL
%token OP_MAYOR
%token OP_MENOR
%token OP_ADMIRACION
%token OP_CELDILLA
%token OP_PREGUNTA
%token OP_DOSPUNTOSDOBLE
%token OP_DOSPUNTOS
%token OP_IGUALIGUAL
%token OP_MENORIGUAL
%token OP_MAYORIGUAL
%token OP_ADMIRACIONIGUAL
%token OP_YY
%token OP_OO
%token OP_MASMAS
%token OP_MENOSMENOS
%token OP_MAS
%token OP_MENOS
%token OP_ASTERISCO
%token OP_DIVIDIDO
%token OP_Y
%token OP_O
%token OP_SOMBRERO
%token OP_PORCENTAJE
%token OP_SHIFTLEFT
%token OP_SHIFTRIGHT
%token OP_SHIFTRIGHT_JAVA
%token OP_MASIGUAL
%token OP_MENOSIGUAL
%token OP_ASTERISCOIGUAL
%token OP_DIVIDIDOIGUAL
%token OP_YIGUAL
%token OP_OIGUAL
%token OP_SOMBREROIGUAL
%token OP_PORCENTAJEIGUAL
%token OP_SHIFTLEFTIGUAL
%token OP_SHIFTRIGHTIGUAL
%token OP_SHIFTRIGHT_JAVA_IGUAL
%token OP_IGUALMAYOR
%token OP_MENOSMAYOR
%token OP_MENOSMAYORASTERISCO
%token OP_PUNTOASTERISCO

/*	LITERALES */
//%token <literal>NULL_LITERAL
//%token <literal>BOOLEAN_LITERAL_TRUE
//%token <literal>BOOLEAN_LITERAL_FALSE
//%token <literal>CHARACTER_LITERAL
//%token <literal>STRING_LITERAL
//%token <literal>INTEGER_LITERAL
//%token <literal>FLOAT_LITERAL

%token NULL_LITERAL
%token BOOLEAN_LITERAL_TRUE
%token BOOLEAN_LITERAL_FALSE
%token CHARACTER_LITERAL
%token STRING_LITERAL
%token INTEGER_LITERAL
%token FLOAT_LITERAL
%token DECIMAL_LITERAL

/*	COMENTARIOS	Y ESPACIO EN BLANCO	*/
%token WHITE_SPACE
%token COMENTARIO_LARGO
%token COMENTARIO

/*	IDENTIFICADORES	*/
//%token <str>IDENTIFICADOR
%token IDENTIFICADOR

/*	ERRORES	*/
%token ERROR_LEXICO
%token MAL_CARACTER
%token ERROR_COMILLA

%%

/////////////////////////////////////////////////////////////////////////////
// rules section

/****************************************************
	SECCION: COMPILATION UNIT Y NAMESPACES
*****************************************************/

Compilation_Unit
	:	Document_Body
				{//	Namespaces_And_Imports
					rootNode=$1.node;
					$$.node=$1.node;
				}
	;

Document_Body
	:	Document_Body_Member
				{//	Imports Namespaces
					CodeDOM::XplDocumentBody*db=new CodeDOM::XplDocumentBody();
					db->Childs()->InsertAtEnd($1.node);
					/*
					CodeDOM::XplNodeList*list=(CodeDOM::XplNodeList*)$2.node;
					for(CodeDOM::XplNode* m=list->FirstNode();m!=list->GetLastNode();m=list->NextNode()){
						db->Childs()->InsertAtEnd(m);
					}*/
					$$.node=db;
				}
	|	Document_Body Document_Body_Member
				{//	Imports Namespaces
					CodeDOM::XplDocumentBody*db= (CodeDOM::XplDocumentBody*)$1.node;
					db->Childs()->InsertAtEnd($2.node);
					$$.node=db;
				}
	;

Document_Body_Member
	:	Import				{$$=$1;}
	|	Using_Statement		{$$=$1;}
	|	Namespace_Decl		{$$=$1;}
	|	ClassFactory_Call	{$$=$1;}
	|	Comments			{$$=$1;}
	;

%ifdef DPP
Import
	:	PC_IMPORT Import_Parameters PUNTO_COMA
				{//	PC_IMPORT Import_Parameters PUNTO_COMA
					$$.node=$2.node;
				}
	|	PC_IMPORT error PUNTO_COMA
				{//	PC_IMPORT error PUNTO_COMA
					//yyerrok();
					SINTAX_ERROR("'import' directive invalid.");
					$$.node=CodeDOM::XplDocumentBody::new_Import();
				}
	;

Import_Parameters
	:	STRING_LITERAL
				{//	STRING_LITERAL
					CodeDOM::XplName*imp=CodeDOM::XplDocumentBody::new_Import();
					CodeDOM::XplNode*nd=CodeDOM::XplName::new_ns();
					nd->set_Value($1.literal->get_str());
					imp->Childs()->InsertAtEnd(nd);
					$$.node=imp;
					SET_SOURCE_DATA_S(imp,0);
				}
	|	Import_Parameters COMA STRING_LITERAL
				{//	Import_Parameters COMA STRING_LITERAL
					CodeDOM::XplName*imp=(CodeDOM::XplName*)$1.node;
					CodeDOM::XplNode*nd=CodeDOM::XplName::new_ns();
					nd->set_Value($3.literal->get_str());
					imp->Childs()->InsertAtEnd(nd);
					$$.node=imp;
				}
	;
%endif

Using_Statement
	:	PC_USING PC_IDENTIFIERS Complete_Class_Name PUNTO_COMA
				{//	PC_USING PC_IDENTIFIERS Complete_Class_Name PUNTO_COMA
					CodeDOM::XplName*us=CodeDOM::XplDocumentBody::new_UsingIdentifiers();
					CodeDOM::XplNode*n=CodeDOM::XplName::new_ns();
					us->Childs()->InsertAtEnd(n);
					n->set_Value($3.str);
					$$.node=us;
					SET_SOURCE_DATA_S(us,0);
				}
	|	PC_USING Complete_Class_Name PUNTO_COMA
				{//	PC_USING Complete_Class_Name PUNTO_COMA
					CodeDOM::XplName*us=CodeDOM::XplDocumentBody::new_Using();
					CodeDOM::XplNode*n=CodeDOM::XplName::new_ns();
					us->Childs()->InsertAtEnd(n);
					n->set_Value($2.str);
					$$.node=us;
					SET_SOURCE_DATA_S(us,0);
				}
	|	PC_USING error	PUNTO_COMA
				{//	PC_USING error	PUNTO_COMA
					//yyerrok();
					SINTAX_ERROR("'using' directive invalid.");
					CodeDOM::XplName*us=CodeDOM::XplDocumentBody::new_Using();
					$$.node=us;
					SET_SOURCE_DATA_S(us,0);
				}
	;

%ifdef DPP
/*Identifier_Namespace_Decl
	:	PC_IDENTIFIERS PC_NAMESPACE Complete_Class_Name PUNTO_COMA
				{//	PC_IDENTIFIERS PC_NAMESPACE IDENTIFICADOR PUNTO_COMA
					CodeDOM::XplNode*n=CodeDOM::XplDocumentBody::new_IdentifiersNamespace();
					n->set_Value($3.str);
					$$.node=n;
				}
	|	PC_IDENTIFIERS error PUNTO_COMA
				{//	PC_IDENTIFIERS PC_NAMESPACE error
					SINTAX_ERROR("instruccion 'identifiers namespace' incorrecta.");
					$$.node=CodeDOM::XplDocumentBody::new_IdentifiersNamespace();
				}
	;*/
%endif

Namespace_Decl
	:	PC_NAMESPACE Complete_Class_Name OPEN_LLAVE Namespace_Members CLOSE_LLAVE
				{//	PC_NAMESPACE IDENTIFICADOR OPEN_LLAVE NamespaceBlock CLOSE_LLAVE
					CodeDOM::XplNamespace *ns=new CodeDOM::XplNamespace($2.str,false,false,(CodeDOM::XplNodeList*)$4.node);
                    SET_SOURCE_DATA(ns,-4,0);
					ns->set_ElementName(L"Namespace");
					$$.node=ns;
				}
	|	PC_NAMESPACE Complete_Class_Name OPEN_LLAVE CLOSE_LLAVE
				{//	PC_NAMESPACE IDENTIFICADOR OPEN_LLAVE CLOSE_LLAVE
					CodeDOM::XplNamespace *ns=new CodeDOM::XplNamespace($2.str,false,false);
                    SET_SOURCE_DATA(ns,-3,0);
					ns->set_ElementName(L"Namespace");
					$$.node=ns;
				}
	|	PC_NAMESPACE error	OPEN_LLAVE
				{//	PC_NAMESPACE error	OPEN_LLAVE
					//yyerrok();
					SINTAX_ERROR("'namespace' declaration invalid.");
					$$.node=new CodeDOM::XplNamespace();
				}
//	|	PC_NAMESPACE Complete_Class_Name Block_Modifiers OPEN_LLAVE Namespace_Members CLOSE_LLAVE
//				{//	PC_NAMESPACE IDENTIFICADOR Block_Modifiers OPEN_LLAVE NamespaceBlock CLOSE_LLAVE
//					CodeDOM::XplNamespace *ns=new CodeDOM::XplNamespace($2.str,false,false,(CodeDOM::XplNodeList*)$5.node);
//                    SET_SOURCE_DATA(ns,-5,0);
//					ns->set_ElementName(L"Namespace");
//					$$.node=ns;
//					WARNING_MESSAGE("Interno: 'Block Modifiers' ignorado por el compilador D++.");
//				}
%ifdef DPP
//	|	PC_NAMESPACE Complete_Class_Name Block_Modifiers OPEN_LLAVE CLOSE_LLAVE
//				{//	PC_NAMESPACE IDENTIFICADOR Block_Modifiers OPEN_LLAVE CLOSE_LLAVE
//					CodeDOM::XplNamespace *ns=new CodeDOM::XplNamespace($2.str,false,false);
//                  SET_SOURCE_DATA(ns,-4,0);
//					ns->set_ElementName(L"Namespace");
//					$$.node=ns;
//					WARNING_MESSAGE("Interno: 'Block Modifiers' ignorado por el compilador D++.");
//				}
	|	PC_EXTENSION OPEN_LLAVE Namespace_Members CLOSE_LLAVE
				{//	PC_EXTENSION OPEN_LLAVE Namespace_Members CLOSE_LLAVE
					CodeDOM::XplNamespace *ns=new CodeDOM::XplNamespace(L"extension",false,false,(CodeDOM::XplNodeList*)$3.node);
					//ASSING_COMMENT(ns);
					SET_SOURCE_DATA(ns,-3,0);
					ns->set_ElementName(L"Section");
					$$.node=ns;
				}
	|	PC_ORDINARY OPEN_LLAVE Namespace_Members CLOSE_LLAVE
				{//	PC_ORDINARY OPEN_LLAVE Namespace_Members CLOSE_LLAVE
					CodeDOM::XplNamespace *ns=new CodeDOM::XplNamespace(L"ordinary",false,false,(CodeDOM::XplNodeList*)$3.node);
					//ASSING_COMMENT(ns);
                    SET_SOURCE_DATA(ns,-3,0);
					ns->set_ElementName(L"Section");
					$$.node=ns;
				}
%endif
	;


Namespace_Members
	:	Namespace_Member
				{//	Namespace_Member
					CodeDOM::XplNodeList*l=new CodeDOM::XplNodeList();
					l->InsertAtEnd($1.node);
					//ASSING_COMMENT($1.node);
					$$.list=l;
				}
	|	Namespace_Members Namespace_Member
				{//	NamespaceBlock Namespace_Member
					CodeDOM::XplNodeList*l=$1.list;
					//if(l==NULL)l=NEW_ERROR_RESUME_ZOENODELIST;
					//ASSING_COMMENT($2.node);
					if(l==NULL)l=new CodeDOM::XplNodeList();
					l->InsertAtEnd($2.node);
					$$.list=l;
				}
	;

Namespace_Member
	:	Namespace_Decl              {
										//ASSING_COMMENT($1.node);
										$$=$1;
									}
	|	Type_Decl                   {$$=$1;}
	|	Comments					{$$=$1;}
%ifdef DPP
	|	ClassFactory_Call           {$$=$1;}
//	|	Identifier_Namespace_Decl   {$$=$1;}
%endif
	|	error
				{
					SINTAX_ERROR("statements not valid inside a namespace body.");
					$$.node=new CodeDOM::XplClass();
				}
	;

//Block_Modifiers
/*	:	PC_READONLY PC_BLOCKTOFACTORYS PC_EXCEPT Factory_List
	|	PC_BLOCKTOFACTORYS PC_EXCEPT Factory_List
	|	PC_BLOCKTOFACTORYS Factory_List*/
//	:	PC_BLOCKTOFACTORYS
/*	|	PC_READONLY PC_BLOCKTOFACTORYS Factory_List
	|	PC_READONLY PC_BLOCKTOFACTORYS*/
//	;

Complete_Class_Name
	:	IDENTIFICADOR {$$=$1;RET_POS=GET_PARSER_POS[0];}
%ifdef DPP
	|	Complete_Class_Name OP_DOSPUNTOSDOBLE IDENTIFICADOR
			{//	Complete_Class_Name OP_DOSPUNTOSDOBLE IDENTIFICADOR
				wcscat($1.str,DT("::"));
				wcscat($1.str,$3.str);
				$$=$1;
                RET_POS=GET_PARSER_POS[0];
			}
%endif
%ifdef CSL
	|	Complete_Class_Name OP_PUNTO IDENTIFICADOR
			{//	Complete_Class_Name OP_DOSPUNTOSDOBLE IDENTIFICADOR
				wcscat($1.str,DT("."));
				wcscat($1.str,$3.str);
				$$=$1;
                RET_POS=GET_PARSER_POS[0];
			}
%endif
	;


/****************************************************
	SECCION: NAMESPACE MEMBERS
*****************************************************/

Type_Decl
	:	Class_Decl
				{//	Class_Decl
					//ASSING_COMMENT($1.node);
					$$.node=$1.node;
				}
	|   Enum_Decl
	            {
					//ASSING_COMMENT($1.node);
	                $$.node=$1.node;
	            }
	;

Enum_Decl
	:	Storage_Mod_List PC_ENUM IDENTIFICADOR OPEN_LLAVE Enum_Members CLOSE_LLAVE
				{//	Decl_Mod PC_ENUM IDENTIFICADOR OPEN_LLAVE Enum_Members CLOSE_LLAVE
					CodeDOM::XplClass*clase=
					CreateClass($3.str,(CodeDOM::XplNodeList*)$5.list,NULL,NULL,PC_ENUM,$1.num);
					SetEnumConstantTypes(clase,PC_INT);
					$$.node=clase;
                    SET_SOURCE_DATA(clase,-4,0);
				}
	|	Storage_Mod_List PC_ENUM IDENTIFICADOR OP_DOSPUNTOS Simple_Type_Name OPEN_LLAVE Enum_Members CLOSE_LLAVE
				{//	Decl_Mod PC_ENUM IDENTIFICADOR OPEN_LLAVE Enum_Members CLOSE_LLAVE
					CodeDOM::XplClass*clase=
					CreateClass($3.str,(CodeDOM::XplNodeList*)$7.list,NULL,NULL,PC_ENUM,$1.num);
					SetEnumConstantTypes(clase,$5.num);
					$$.node=clase;
                    SET_SOURCE_DATA(clase,-6,0);
				}
	|	PC_ENUM IDENTIFICADOR OPEN_LLAVE Enum_Members CLOSE_LLAVE
				{//	Decl_Mod PC_ENUM IDENTIFICADOR OPEN_LLAVE Enum_Members CLOSE_LLAVE
					CodeDOM::XplClass*clase=
					CreateClass($2.str,(CodeDOM::XplNodeList*)$4.list,NULL,NULL,PC_ENUM,0);
					SetEnumConstantTypes(clase,PC_INT);
					$$.node=clase;
                    SET_SOURCE_DATA(clase,-4,0);
				}
	|	PC_ENUM IDENTIFICADOR OP_DOSPUNTOS Simple_Type_Name OPEN_LLAVE Enum_Members CLOSE_LLAVE
				{//	Decl_Mod PC_ENUM IDENTIFICADOR OPEN_LLAVE Enum_Members CLOSE_LLAVE
					CodeDOM::XplClass*clase=
					CreateClass($2.str,(CodeDOM::XplNodeList*)$6.list,NULL,NULL,PC_ENUM,0);
					SetEnumConstantTypes(clase,$4.num);
					$$.node=clase;
                    SET_SOURCE_DATA(clase,-6,0);
				}
	;

Enum_Members
	:	Enum_Constant
				{//	Enum_Constant
					CodeDOM::XplNodeList*list=new CodeDOM::XplNodeList();
					//ASSING_COMMENT($1.node);
					list->InsertAtEnd($1.node);
					$$.list=list;
				}
	|	Enum_Members COMA Enum_Constant
				{//	Enum_Constants COMA Enum_Constant
					CodeDOM::XplNodeList*list=(CodeDOM::XplNodeList*)$1.list;
					if(list==NULL)list=new CodeDOM::XplNodeList();
					//ASSING_COMMENT($3.node);
					list->InsertAtEnd($3.node);
					$$.list=list;
				}
	|	Comments					{$$=$1;}
	;

Enum_Constant
	:	IDENTIFICADOR Enum_Initializer
				{//	IDENTIFICADOR Enum_Initializer
					CodeDOM::XplField*field=CodeDOM::XplClass::new_Field();
					field->set_name($1.str);
					field->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_STATIC);
					field->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC);
					field->set_i((CodeDOM::XplInitializerList*)$2.node);
					$$.node=field;
					SET_SOURCE_DATA_S(field,-1);
				}
	|	IDENTIFICADOR
				{//	IDENTIFICADOR
					CodeDOM::XplField*field=CodeDOM::XplClass::new_Field();
					field->set_name($1.str);
					field->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_STATIC);
					field->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC);
					$$.node=field;
					SET_SOURCE_DATA_S(field,0);
				}
%ifdef DPP
//	|	Enum_Decl
//				{//	Nested_Enum_Decl
//					CodeDOM::XplClass*clase=(CodeDOM::XplClass*)$1.node;
//					$$.node=clase;
                    /* Problema con enumeraciones:
                            Las enumeraciones anidadas las agrega al final de las
                            constantes ya que las constantes van dentro de un
                            XplClassMembers y las clases no.

                            PRESTAR ATENCION A ÉSTE DETALLE!
                    */
//				}
%endif
	;

Enum_Initializer
	:	OP_IGUAL Constant_Expression
				{//	OP_IGUAL Constant_Expression
                	CodeDOM::XplExpression*exp=CodeDOM::XplInitializerList::new_e();
                	exp->set_texpression($2.node);
					exp->set_ElementName(DT("e"));
                   	CodeDOM::XplInitializerList*list=CodeDOM::XplDeclarator::new_i();
                    list->Childs()->InsertAtEnd(exp);
                    $$.node=list;
				}
	;

Class_Type
    :   PC_CLASS        {$$.num=PC_CLASS;RET_POS=GET_PARSER_POS[0];}
    |   PC_INTERFACE    {$$.num=PC_INTERFACE;RET_POS=GET_PARSER_POS[0];}
    |   PC_STRUCT       {$$.num=PC_STRUCT;RET_POS=GET_PARSER_POS[0];}
%ifdef DPP
    |   PC_UNION        {$$.num=PC_UNION;RET_POS=GET_PARSER_POS[0];}
%endif
    ;

Class_Decl
%ifdef DPP
	:	Storage_Mod_List Class_Type IDENTIFICADOR PC_INHERITS Base_List PC_IMPLEMENTS Implement_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
				{//	Decl_Mod PC_CLASS IDENTIFICADOR PC_INHERITS Base_List PC_IMPLEMENTS Implement_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($3.str /*Nombre*/, $9.list /*ClassMembers*/, $5.node /*Inherits_List*/
					                   , $7.node /*Implement_List*/, $2.num /*Tipo*/,$1.num /*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-8,0);
				}
	|	Storage_Mod_List Class_Type IDENTIFICADOR PC_INHERITS Base_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
				{//	Decl_Mod PC_CLASS IDENTIFICADOR PC_INHERITS Base_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($3.str /*Nombre*/, $7.list /*ClassMembers*/, $5.node /*Inherits_List*/
					                   , NULL /*Implement_List*/, $2.num /*Tipo*/,$1.num /*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-6,0);
				}
	|	Storage_Mod_List Class_Type IDENTIFICADOR PC_IMPLEMENTS Implement_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
				{//	Decl_Mod PC_CLASS IDENTIFICADOR PC_IMPLEMENTS Implement_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($3.str /*Nombre*/, $7.list /*ClassMembers*/, NULL /*Inherits_List*/
					                   , $5.node /*Implement_List*/, $2.num /*Tipo*/,$1.num /*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-6,0);
				}
	|	Storage_Mod_List Class_Type IDENTIFICADOR OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
				{//	Decl_Mod PC_CLASS IDENTIFICADOR OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($3.str /*Nombre*/, $5.list /*ClassMembers*/, NULL /*Inherits_List*/
					                   , NULL /*Implement_List*/, $2.num /*Tipo*/,$1.num /*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-4,0);
				}
	|	Class_Type IDENTIFICADOR PC_INHERITS Base_List PC_IMPLEMENTS Implement_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
				{//	PC_CLASS IDENTIFICADOR PC_INHERITS Base_List PC_IMPLEMENTS Implement_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($2.str /*Nombre*/, $8.list /*ClassMembers*/, $4.node /*Inherits_List*/
					                   , $6.node /*Implement_List*/, $1.num /*Tipo*/,0/*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-8,0);
				}
	|	Class_Type IDENTIFICADOR PC_INHERITS Base_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
				{//	PC_CLASS IDENTIFICADOR PC_INHERITS Base_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($2.str /*Nombre*/, $6.list /*ClassMembers*/, $4.node /*Inherits_List*/
					                   , NULL /*Implement_List*/, $1.num /*Tipo*/, 0/*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-6,0);
				}
	|	Class_Type IDENTIFICADOR PC_IMPLEMENTS Implement_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
				{//	PC_CLASS IDENTIFICADOR PC_IMPLEMENTS Implement_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($2.str /*Nombre*/, $6.list /*ClassMembers*/, NULL /*Inherits_List*/
					                   , $4.node /*Implement_List*/, $1.num /*Tipo*/, 0/*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-6,0);
				}
	|	Class_Type IDENTIFICADOR OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
				{//	PC_CLASS IDENTIFICADOR OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($2.str /*Nombre*/, $4.list /*ClassMembers*/, NULL /*Inherits_List*/
					                   , NULL /*Implement_List*/, $1.num /*Tipo*/,0 /*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-4,0);
				}

	/*Clases sin bloques de implementacion*/
	|	Class_Type IDENTIFICADOR OPEN_LLAVE CLOSE_LLAVE
				{//	PC_CLASS IDENTIFICADOR OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($2.str /*Nombre*/, NULL /*ClassMembers*/, NULL /*Inherits_List*/
					                   , NULL /*Implement_List*/, $1.num /*Tipo*/,0 /*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-4,0);
				}
	|	Class_Type IDENTIFICADOR PC_INHERITS Base_List OPEN_LLAVE CLOSE_LLAVE
				{//	PC_CLASS IDENTIFICADOR PC_INHERITS Base_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($2.str /*Nombre*/, NULL /*ClassMembers*/, $4.node /*Inherits_List*/
					                   , NULL /*Implement_List*/, $1.num /*Tipo*/, 0/*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-6,0);
				}
	|	Class_Type IDENTIFICADOR PC_IMPLEMENTS Implement_List OPEN_LLAVE CLOSE_LLAVE
				{//	PC_CLASS IDENTIFICADOR PC_IMPLEMENTS Implement_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($2.str /*Nombre*/, NULL /*ClassMembers*/, NULL /*Inherits_List*/
					                   , $4.node /*Implement_List*/, $1.num /*Tipo*/, 0/*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-6,0);
				}
	|	Class_Type IDENTIFICADOR PC_INHERITS Base_List PC_IMPLEMENTS Implement_List OPEN_LLAVE CLOSE_LLAVE
				{//	PC_CLASS IDENTIFICADOR PC_INHERITS Base_List PC_IMPLEMENTS Implement_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($2.str /*Nombre*/, NULL /*ClassMembers*/, $4.node /*Inherits_List*/
					                   , $6.node /*Implement_List*/, $1.num /*Tipo*/,0/*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-8,0);
				}
	|	Storage_Mod_List Class_Type IDENTIFICADOR PC_INHERITS Base_List PC_IMPLEMENTS Implement_List OPEN_LLAVE CLOSE_LLAVE
				{//	Decl_Mod PC_CLASS IDENTIFICADOR PC_INHERITS Base_List PC_IMPLEMENTS Implement_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($3.str /*Nombre*/, NULL /*ClassMembers*/, $5.node /*Inherits_List*/
					                   , $7.node /*Implement_List*/, $2.num /*Tipo*/,$1.num /*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-8,0);
				}
	|	Storage_Mod_List Class_Type IDENTIFICADOR PC_INHERITS Base_List OPEN_LLAVE CLOSE_LLAVE
				{//	Decl_Mod PC_CLASS IDENTIFICADOR PC_INHERITS Base_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($3.str /*Nombre*/, NULL /*ClassMembers*/, $5.node /*Inherits_List*/
					                   , NULL /*Implement_List*/, $2.num /*Tipo*/,$1.num /*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-6,0);
				}
	|	Storage_Mod_List Class_Type IDENTIFICADOR PC_IMPLEMENTS Implement_List OPEN_LLAVE CLOSE_LLAVE
				{//	Decl_Mod PC_CLASS IDENTIFICADOR PC_IMPLEMENTS Implement_List OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($3.str /*Nombre*/, NULL /*ClassMembers*/, NULL /*Inherits_List*/
					                   , $5.node /*Implement_List*/, $2.num /*Tipo*/,$1.num /*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-6,0);
				}
	|	Storage_Mod_List Class_Type IDENTIFICADOR OPEN_LLAVE CLOSE_LLAVE
				{//	Decl_Mod PC_CLASS IDENTIFICADOR OPEN_LLAVE Class_Decl_Block CLOSE_LLAVE
					$$.node=CreateClass($3.str /*Nombre*/, NULL /*ClassMembers*/, NULL /*Inherits_List*/
					                   , NULL /*Implement_List*/, $2.num /*Tipo*/,$1.num /*Modifiers*/);
                    SET_SOURCE_DATA(((CodeDOM::XplClass*)$$.node),-4,0);
				}
%endif
%ifdef CSL
%endif
	;

Base_List
	:	Base_Specifier
				{//	Base_Specifier
					CodeDOM::XplInherits*inh=CodeDOM::XplClass::new_Inherits();
					inh->Childs()->InsertAtEnd($1.node);
					$$.node=inh;
				}
	|	Base_List COMA Base_Specifier
				{//	Base_List COMA Base_Specifier
					CodeDOM::XplInherits*inh=(CodeDOM::XplInherits*)$1.node;
					inh->Childs()->InsertAtEnd($3.node);
					$$.node=inh;
				}
	;


Base_Specifier
	:	PC_NONVIRTUAL Access_Modifier Complete_Class_Name
				{//	PC_VIRTUAL Access_Modifier Complete_Class_Name
					CodeDOM::XplInherit*c=CodeDOM::XplInherits::new_c();
					CodeDOM::XplType* classType = CodeDOM::XplInherit::new_type();
					classType->set_typename($3.str);
					c->set_type(classType);
					if($2.num==SM_PRIVATE)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PRIVATE);
					else if($2.num==SM_PUBLIC)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC);
					else if($2.num==SM_PROTECTED)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PROTECTED);
					else if($2.num==SM_IPRIVATE)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PRIVATE);
					else if($2.num==SM_IPUBLIC)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC);
					else if($2.num==SM_IPROTECTED)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PROTECTED);
					c->set_virtual(false);
					SET_SOURCE_DATA(c,-2,0);
					$$.node=c;
				}
	|	Access_Modifier PC_NONVIRTUAL Complete_Class_Name
				{//	Access_Modifier PC_VIRTUAL Complete_Class_Name
					CodeDOM::XplInherit*c=CodeDOM::XplInherits::new_c();
					CodeDOM::XplType* classType = CodeDOM::XplInherit::new_type();
					classType->set_typename($3.str);
					c->set_type(classType);
					if($1.num==SM_PRIVATE)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PRIVATE);
					else if($1.num==SM_PUBLIC)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC);
					else if($1.num==SM_PROTECTED)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PROTECTED);
					else if($1.num==SM_IPRIVATE)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PRIVATE);
					else if($1.num==SM_IPUBLIC)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC);
					else if($1.num==SM_IPROTECTED)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PROTECTED);
					c->set_virtual(false);
					SET_SOURCE_DATA(c,-1,0);
					$$.node=c;
				}
	|	PC_NONVIRTUAL Complete_Class_Name
				{//	PC_VIRTUAL Complete_Class_Name
					CodeDOM::XplInherit*c=CodeDOM::XplInherits::new_c();
					CodeDOM::XplType* classType = CodeDOM::XplInherit::new_type();
					classType->set_typename($2.str);
					c->set_type(classType);
					c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC);
					c->set_virtual(false);
					$$.node=c;
					SET_SOURCE_DATA(c,-1,0);
				}
	|	Access_Modifier Complete_Class_Name
				{//	Access_Modifier Complete_Class_Name
					CodeDOM::XplInherit*c=CodeDOM::XplInherits::new_c();
					CodeDOM::XplType* classType = CodeDOM::XplInherit::new_type();
					classType->set_typename($2.str);
					c->set_type(classType);
					if($1.num==SM_PRIVATE)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PRIVATE);
					else if($1.num==SM_PUBLIC)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC);
					else if($1.num==SM_PROTECTED)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PROTECTED);
					else if($1.num==SM_IPRIVATE)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PRIVATE);
					else if($1.num==SM_IPUBLIC)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC);
					else if($1.num==SM_IPROTECTED)
						c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PROTECTED);
					c->set_virtual(true);
					$$.node=c;
					SET_SOURCE_DATA_S(c,0);
				}
	|	Complete_Class_Name
				{//	Complete_Class_Name
					CodeDOM::XplInherit*c=CodeDOM::XplInherits::new_c();
					CodeDOM::XplType* classType = CodeDOM::XplInherit::new_type();
					classType->set_typename($1.str);
					c->set_type(classType);
					c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC);
					c->set_virtual(true);
					$$.node=c;
					SET_SOURCE_DATA_S(c,0);
				}
	;

%ifdef DPP
Implement_List
	:	Implement_Specifier
				{//	Implement_Specifier
					CodeDOM::XplInherits*imp=CodeDOM::XplClass::new_Implements();
					imp->Childs()->InsertAtEnd($1.node);
					$$.node=imp;
				}
	|	Implement_List COMA Implement_Specifier
				{//	Implement_List COMA Implement_Specifier
					CodeDOM::XplInherits*imp=(CodeDOM::XplInherits*)$1.node;
					imp->Childs()->InsertAtEnd($3.node);
					$$.node=imp;
				}
	;

Implement_Specifier
	:	Access_Modifier Complete_Class_Name
	 //ESTO EN REALIDAD NO ES NECESARIO EN LA ESPECIFICACION ACTUAL
				{//	Access_Modifier Complete_Class_Name
					CodeDOM::XplInherit*i=CodeDOM::XplInherits::new_c();
					CodeDOM::XplType* classType = CodeDOM::XplInherit::new_type();
					classType->set_typename($2.str);
					i->set_type(classType);
					if($1.num==SM_PRIVATE)
						i->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PRIVATE);
					else if($1.num==SM_PUBLIC)
						i->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC);
					else if($1.num==SM_PROTECTED)
						i->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PROTECTED);
					else if($1.num==SM_IPRIVATE)
						i->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PRIVATE);
					else if($1.num==SM_IPUBLIC)
						i->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC);
					else if($1.num==SM_IPROTECTED)
						i->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PROTECTED);
					$$.node=i;
					SET_SOURCE_DATA_S(i,0);
				}
	|	Complete_Class_Name
				{//	Complete_Class_Name
					CodeDOM::XplInherit*i=CodeDOM::XplInherits::new_c();
					CodeDOM::XplType* classType = CodeDOM::XplInherit::new_type();
					classType->set_typename($1.str);
					i->set_type(classType);
					i->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC);
					$$.node=i;
					SET_SOURCE_DATA_S(i,0);
				}
	;
%endif

Class_Decl_Block
	:	Class_Member_Decl
				{//	Class_Member_Decl
					CodeDOM::XplNodeList*l=new CodeDOM::XplNodeList();
					if($1.nodos[1]==0)
						l->InsertAtEnd($1.node);
					else{ ///Fields
						CodeDOM::XplNodeList* fields=(CodeDOM::XplNodeList*)$1.nodos[0];
						for(CodeDOM::XplNode* m2=fields->FirstNode();m2!=NULL;m2=fields->NextNode()){
							//ASSING_COMMENT(m2);
							l->InsertAtEnd(m2);
						}
						fields->Clear();
						delete fields;
					}
					$$.list=l;
				}
	|	Class_Decl_Block Class_Member_Decl
				{//	Class_Decl_Block Class_Member_Decl
					CodeDOM::XplNodeList*l=$1.list;
					if(l==NULL)l=new CodeDOM::XplNodeList();
					if($2.nodos[1]==0)
						l->InsertAtEnd($2.node);
					else{	///Fields
						CodeDOM::XplNodeList* fields=(CodeDOM::XplNodeList*)$2.nodos[0];
						for(CodeDOM::XplNode* m2=fields->FirstNode();m2!=NULL;m2=fields->NextNode()){
							//ASSING_COMMENT(m2);
							l->InsertAtEnd(m2);
						}
						fields->Clear();
						delete fields;
					}
					$$.list=l;
				}
	;

Class_Member_Decl
	:	Field_Decl 
				{
					$$.nodos[0]=$1.node;
					//Utilizo nodos[1]=1 como bandera para indicar fields en cuyo caso
					//nodos[0] es una lista de campos
					$$.nodos[1]=(CodeDOM::XplNode*)1; 
				}
	|	Function_Decl				{$$=$1;$$.nodos[1]=0;}
	|	Property_Decl				{$$=$1;$$.nodos[1]=0;}
	|	Type_Decl					{$$=$1;$$.nodos[1]=0;}
	|	Comments					{$$=$1;$$.nodos[1]=0;}
	|	error PUNTO_COMA
				{
					SINTAX_ERROR("statements not valid inside a class body.");
					$$.node=new CodeDOM::XplClass();$$.nodos[1]=0;
				}
%ifdef DPP
	|	ClassFactory_Call
				{//	ClassFactory_Call
					//ASSING_COMMENT($1.node);
					$1.node->set_ElementName(DT("e"));
					$$.node=$1.node;$$.nodos[1]=0;
				}
	|	Access_Modifier OP_DOSPUNTOS
				{//	Access_Modifier OP_DOSPUNTOS
					CodeDOM::XplNode*node=new CodeDOM::XplNode(DT("AM"),$1.num);
					$$.node=node;$$.nodos[1]=0;
				}
	|	Autoinstance_Decl {$$=$1;$$.nodos[1]=0;}
	|	SetPlatforms_Decl {$$=$1;$$.nodos[1]=0;}
%endif
	;

%ifdef DPP
SetPlatforms_Decl
	:	PC_SETPLATFORMS OP_DOSPUNTOS SetPlatformList PUNTO_COMA
				{//	PC_SETPLATAFORMS OP_DOSPUNTOS SetPlataform_Or PUNTO_COMA
					$3.node->set_ElementName(L"SetPlatforms");
					$$.node=$3.node;
					//SET_SOURCE_DATA(((CodeDOM::XplSetPlatforms*)$3.node),-3,0);
				}
	;

SetPlatformList
	:	SetPlatform
	|	SetPlatformList COMA SetPlatform
	;

SetPlatform
	:	STRING_LITERAL
				{//	STRING_LITERAL
					CodeDOM::XplPlatform*p=CodeDOM::XplSetPlatforms::new_P();
					p->set_match(CodeDOM::ZOEPLATFORMMATCH_ENUM_EXACTNAME);
					p->set_name($1.literal->get_str());
					$$.node=p;
				}
	|	PC_LIKE STRING_LITERAL
				{//	PC_LIKE STRING_LITERAL
					CodeDOM::XplPlatform*p=CodeDOM::XplSetPlatforms::new_P();
					p->set_match(CodeDOM::ZOEPLATFORMMATCH_ENUM_LIKE);
					p->set_name($2.literal->get_str());
					$$.node=p;
				}
	;

Autoinstance_Decl
	:	PC_AUTOINSTANCE OP_DOSPUNTOS Autoinstance_Type PUNTO_COMA
				{//	PC_AUTOINSTANCE OP_DOSPUNTOS Autoinstance_Type PUNTO_COMA
					$$.node=$3.node;
					//SET_SOURCE_DATA(((CodeDOM::XplAutoInstance*)$3.node),-3,0);
				}
	;

Autoinstance_Type
	:	PC_BYCALL
				{//	PC_BYCALL
					CodeDOM::XplAutoInstance*au=CodeDOM::XplClass::new_AutoInstance();
					au->set_by(CodeDOM::ZOEAUTOINSTACETYPES_ENUM_CALL);
					$$.node=au;
				}
	|	PC_BYCLASS
				{//	PC_BYCLASS
					CodeDOM::XplAutoInstance*au=CodeDOM::XplClass::new_AutoInstance();
					au->set_by(CodeDOM::ZOEAUTOINSTACETYPES_ENUM_CLASS);
					$$.node=au;
				}
	|	PC_BYNAMESPACE
				{//	PC_BYNAMESPACE
					CodeDOM::XplAutoInstance*au=CodeDOM::XplClass::new_AutoInstance();
					au->set_by(CodeDOM::ZOEAUTOINSTACETYPES_ENUM_NAMESPACE);
					$$.node=au;
				}
	|	PC_BYCALLTO Identifier_List
				{//	PC_BYCALLTO Identifier_List
					CodeDOM::XplAutoInstance*au=new CodeDOM::XplAutoInstance((CodeDOM::XplNodeList*)$2.node);
					au->set_ElementName(L"AutoInstance");
					au->set_by(CodeDOM::ZOEAUTOINSTACETYPES_ENUM_CALLTOFUNCTION);
					$$.node=au;
				}
	;

Identifier_List
	:	IDENTIFICADOR
				{//	IDENTIFICADOR
					CodeDOM::XplNodeList*l=new CodeDOM::XplNodeList();
					CodeDOM::XplNode*n=CodeDOM::XplAutoInstance::new_fn();
					n->set_Value($1.str);
					l->InsertAtEnd(n);
					$$.list=l;
				}
	|	Identifier_List COMA IDENTIFICADOR
				{//	Identifier_List COMA IDENTIFICADOR
					CodeDOM::XplNodeList*l=$1.list;
					//if(l==NULL)l=NEW_ERROR_RESUME_ZOENODELIST;
					if(l==NULL)l=new CodeDOM::XplNodeList();
					CodeDOM::XplNode*n=CodeDOM::XplAutoInstance::new_fn();
					n->set_Value($3.str);
					l->InsertAtEnd(n);
					$$.list=l;
				}
	;
%endif

Access_Modifier
	:	PC_PUBLIC		{$$.num=SM_PUBLIC;}
	|	PC_PROTECTED	{$$.num=SM_PROTECTED;}
	|	PC_PRIVATE		{$$.num=SM_PRIVATE;}
%ifdef DPP
	|	PC_IPUBLIC		{$$.num=SM_IPUBLIC;}
	|	PC_IPROTECTED	{$$.num=SM_IPROTECTED;}
	|	PC_IPRIVATE		{$$.num=SM_IPRIVATE;}
%endif
	;

/*AQUI IBA TYPE_DECLARATOR*/
Type_Declarator
	:	Type_Declarator2
				{
					$$.nodos[0]=$1.node;	//XplType
					$$.nodos[1]=NULL;		//Modificadores (unsigned)
					RET_POS=GET_PARSER_POS[0];
				}
	|	Storage_Mod_List Type_Declarator2 
				{
					$$.nodos[0]=$2.node;
					$$.nodos[1]=$1.node;
					RET_POS=GET_PARSER_POS[0];
				}
	;

Type_Declarator2
	:	Type_Declarator3
				{
					CodeDOM::XplType* t=new CodeDOM::XplType();					
					t->set_typename($1.str);
					$$.node=t;		
					RET_POS=GET_PARSER_POS[0];
				}
	|	Type_Declarator3 Pointer_And_Array_Mods
				{
					CodeDOM::XplType* t=(CodeDOM::XplType*)$2.node;
					SetInnerTypeName(t, $1.str);
					$$.node=t;
					RET_POS=GET_PARSER_POS[-1];
				}
%ifdef DPP
	|	Explicit_Type	
				{
					CodeDOM::XplType* t=(CodeDOM::XplType*)$1.node;
					t->set_lddata(DT(".")); ///Muy choto esto
					$$.node=$1.node;
					RET_POS=GET_PARSER_POS[0];
				}
%endif
	;

Type_Declarator3
	:	Simple_Type_Name
				{//	Simple_Type_Name
					wcscpy($$.str,get_nativeType($1.num));
					RET_POS=GET_PARSER_POS[0];
				}
	|	Complete_Class_Name
				{//	User_Type_Name
					wcscpy($$.str,$1.str);
					RET_POS=GET_PARSER_POS[0];
				}
	;

Pointer_And_Array_Mods
	:	Array_Mods		{$$.node=$1.node;}
	|	Pointer_Mods	{$$.node=$1.node;}
	|	Pointer_Mods Array_Mods
				{
					SetInnerType((CodeDOM::XplType*)$2.node, (CodeDOM::XplType*)$1.node);
					$$.node=$2.node;
				}
	;

Pointer_Mods
	:	Pointer_Mod
				{
					CodeDOM::XplType* t=new CodeDOM::XplType();
					t->set_pi((CodeDOM::XplPointerinfo*)$1.node);
					t->set_ispointer(true);
					$$.node=t;
				}
	|	Pointer_Mods Pointer_Mod
				{
					CodeDOM::XplType* t=new CodeDOM::XplType();
					t->set_pi((CodeDOM::XplPointerinfo*)$2.node);
					t->set_ispointer(true);

					CodeDOM::XplType* t2=(CodeDOM::XplType*)$1.node;
					t->set_dt(t2);
					$$.node=t;
				}
	;

Array_Mods
	:	Array_Mod
				{
					CodeDOM::XplType* t=CodeDOM::XplType::new_dt();
					t->set_isarray(true);
					if($1.node!=NULL)t->set_ae($1.exp);
					CodeDOM::XplType* tp=new CodeDOM::XplType();
					CodeDOM::XplPointerinfo* pi=CodeDOM::XplType::new_pi();
					pi->set_ref(true);
					tp->set_pi(pi);
					tp->set_ispointer(true);
					tp->set_dt(t);
					$$.node=tp;
				}
	|	Array_Mods Array_Mod
				{
					CodeDOM::XplType* t=CodeDOM::XplType::new_dt();
					t->set_isarray(true);
					if($2.node!=NULL)t->set_ae($2.exp);
					CodeDOM::XplType* tp=new CodeDOM::XplType();
					CodeDOM::XplPointerinfo* pi=CodeDOM::XplType::new_pi();
					pi->set_ref(true);
					tp->set_pi(pi);
					tp->set_ispointer(true);
					tp->set_dt(t);

					CodeDOM::XplType* t2=(CodeDOM::XplType*)$1.node;
					SetInnerType(t2,tp);
					$$.node=t2;
				}
	;

%ifdef DPP
Explicit_Type
	:	PC_TYPEOF Type_Declarator3
				{
					CodeDOM::XplType* t=new CodeDOM::XplType();
					t->set_typename($2.str);
					$$.node=t;
					RET_POS=GET_PARSER_POS[0];
				}
	|	PC_TYPEOF Derived_Type Type_Declarator3
				{
					CodeDOM::XplType* t=(CodeDOM::XplType*)$2.node;
					SetInnerTypeName(t, $3.str);
					$$.node=t;
					RET_POS=GET_PARSER_POS[0];
				}
	;
	
Derived_Type
	:	Array_Mod
				{
					CodeDOM::XplType* t=CodeDOM::XplType::new_dt();
					t->set_isarray(true);
					if($1.node!=NULL)t->set_ae($1.exp);
					$$.node=t;
				}
	|	Pointer_Mod
				{
					CodeDOM::XplType* t=new CodeDOM::XplType();
					t->set_pi((CodeDOM::XplPointerinfo*)$1.node);
					t->set_ispointer(true);
					$$.node=t;
				}
	|	Derived_Type Array_Mod
				{
					CodeDOM::XplType* t=new CodeDOM::XplType();
					t->set_isarray(true);
					if($2.node!=NULL)t->set_ae($2.exp);
										
					CodeDOM::XplType* t2=(CodeDOM::XplType*)$1.node;
					SetInnerType(t2,t);
					$$.node=t2;
				}
	|	Derived_Type Pointer_Mod
				{
					CodeDOM::XplType* t=new CodeDOM::XplType();
					t->set_pi((CodeDOM::XplPointerinfo*)$2.node);
					t->set_ispointer(true);

					CodeDOM::XplType* t2=(CodeDOM::XplType*)$1.node;
					SetInnerType(t2,t);
					$$.node=t2;
				}
	;
%endif

Declarator_F
	:	Complete_Class_Name
				{//	Complete_Class_Name
					CodeDOM::XplFunction*f=CodeDOM::XplClass::new_Function();
					f->set_name($1.str);
					CodeDOM::XplType*t=CodeDOM::XplFunction::new_ReturnType();
					f->set_ReturnType(t);
					$$.node=f;			//Funcion
					RET_POS=GET_PARSER_POS[0];
				}
	|	PC_OPERATOR Operator_Sym
				{//	PC_OPERATOR Operator_Sym
					CodeDOM::XplFunction*f=CodeDOM::XplClass::new_Operator();
					CodeDOM::string fname=L"none";
					fname=get_OperatorFunctionName($2.num);
					f->set_name(fname);
					CodeDOM::XplType*t=CodeDOM::XplFunction::new_ReturnType();
					f->set_ReturnType(t);
					$$.node=f;			//Funcion
					RET_POS=GET_PARSER_POS[-1];
				}
	|   PC_INDEXER
				{//   PC_INDEXER
					CodeDOM::XplFunction*f=CodeDOM::XplClass::new_Indexer();
					f->set_name(DT("%indexer%"));
					CodeDOM::XplType*t=CodeDOM::XplFunction::new_ReturnType();
					f->set_ReturnType(t);
					$$.node=f;			//Funcion
					RET_POS=GET_PARSER_POS[0];
				}
	|   Complete_Class_Name OP_DOSPUNTOSDOBLE PC_INDEXER
				{//   Complete_Class_Name OP_DOSPUNTOSDOBLE PC_INDEXER
					CodeDOM::XplFunction*f=CodeDOM::XplClass::new_Indexer();
					f->set_name($1.str);
					f->set_name(f->get_name()+DT("::%indexer%"));
					CodeDOM::XplType*t=CodeDOM::XplFunction::new_ReturnType();
					f->set_ReturnType(t);
					$$.node=f;			//Funcion
					RET_POS=GET_PARSER_POS[0];
				}
	|   OP_CELDILLA Complete_Class_Name
				{//   OP_CELDILLA Complete_Class_Name
					CodeDOM::XplFunction*f=CodeDOM::XplClass::new_Function();
					f->set_name($2.str);
					f->set_name(DT("~")+f->get_name());
					CodeDOM::XplType*t=CodeDOM::XplFunction::new_ReturnType();
					f->set_ReturnType(t);
					$$.node=f;			//Funcion
					RET_POS=GET_PARSER_POS[0];
				}
	;

Initializer
	:	OP_IGUAL Variable_Initializer
	            {//	OP_IGUAL Variable_Initializer
	                if($2.node->get_ElementName()==DT("e")){
	                    //Es una expresion
                       	CodeDOM::XplInitializerList*list=CodeDOM::XplDeclarator::new_i();
	                    list->Childs()->InsertAtEnd($2.node);
	                    $$.node=list;
						SET_SOURCE_DATA_S(list,-1);
                    }
	                else{
	                    //Es un lista
	                    $2.node->set_ElementName(DT("i"));
    	                $$.node=$2.node;
	                }
	            }
%ifdef DPP
	|	OPEN_PARENTESIS Expression_List CLOSE_PARENTESIS
	            {//	OPEN_PARENTESIS Expression_List CLOSE_PARENTESIS
                	CodeDOM::XplInitializerList*init=CodeDOM::XplDeclarator::new_i();
					CodeDOM::XplInitializerList*list=CodeDOM::XplInitializerList::new_list();
                	CodeDOM::XplNodeList*nlist=((CodeDOM::XplExpressionlist*)$2.node)->Childs();
                	for(CodeDOM::XplNode*node=nlist->FirstNode();node!=NULL;node=nlist->NextNode()){
                		list->Childs()->InsertAtEnd(node);
                	}
					init->Childs()->InsertAtEnd(list);
                	$$.node=init;
					SET_SOURCE_DATA_S(init,0);
	            }
%endif
	/*|	OPEN_PARENTESIS CLOSE_PARENTESIS
	            {//	OPEN_PARENTESIS CLOSE_PARENTESIS
                	CodeDOM::XplInitializerList*init=CodeDOM::XplDeclarator::new_i();
					CodeDOM::XplInitializerList*list=CodeDOM::XplInitializerList::new_list();
					init->Childs()->InsertAtEnd(list);
                	$$.node=init;
	            }*/
	;

Variable_Initializer
	:	Expression
	            {//	OPEN_PARENTESIS Expression_List CLOSE_PARENTESIS
                	CodeDOM::XplExpression*exp=CodeDOM::XplInitializerList::new_e();
                	exp->set_texpression($1.node);
                	$$.node=exp;
	            }
	|	Complex_Initializer
	            {//	Complex_Initializer
	                $$.node=$1.node;
	            }
	;

Complex_Initializer
	:	OPEN_LLAVE Initializer_List CLOSE_LLAVE
	            {//	OPEN_LLAVE Initializer_List CLOSE_LLAVE
                	CodeDOM::XplInitializerList*list=(CodeDOM::XplInitializerList*)$2.node;
                	list->set_array(true);
	                $$.node=list;
	            }
	|	OPEN_LLAVE Initializer_List COMA CLOSE_LLAVE
	            {//	OPEN_LLAVE Initializer_List COMA CLOSE_LLAVE
                	CodeDOM::XplInitializerList*list=(CodeDOM::XplInitializerList*)$2.node;
                	list->set_array(true);
	                $$.node=list;
	            }
	|	OPEN_LLAVE CLOSE_LLAVE
	            {//	OPEN_LLAVE CLOSE_LLAVE
                	CodeDOM::XplInitializerList*list=CodeDOM::XplInitializerList::new_list();
                	list->set_array(true);
	                $$.node=list;
	            }
	;

Initializer_List:
	|	Variable_Initializer
	            {
                	CodeDOM::XplInitializerList*list=CodeDOM::XplInitializerList::new_list();
                	list->Childs()->InsertAtEnd($1.node);
                	$$.node=list;
	            }
	|	Initializer_List COMA Variable_Initializer
	            {
                	CodeDOM::XplInitializerList*list=(CodeDOM::XplInitializerList*)$1.node;
                	list->Childs()->InsertAtEnd($3.node);
                	$$.node=list;
	            }
	;

Pointer_Mod
	:	OP_ASTERISCO
				{//	OP_ASTERISCO
					CodeDOM::XplPointerinfo*l=CodeDOM::XplType::new_pi();
					$$.node=l;
				}
	|	OP_SOMBRERO
				{//	OP_ASTERISCO
					CodeDOM::XplPointerinfo*l=CodeDOM::XplType::new_pi();
					l->set_ref(true);
					$$.node=l;
				}
	|	OP_ASTERISCO Pointer_Modifier_List
				{//	OP_ASTERISCO Pointer_Modifier_List
					CodeDOM::XplPointerinfo*l=CodeDOM::XplType::new_pi();
					if( ($2.num & SM_CONST)==SM_CONST)l->set_const(true);
					if( ($2.num & SM_VOLATILE)==SM_VOLATILE)l->set_volatile(true);
					if( ($2.num & SM_REF)==SM_REF)l->set_ref(true);
					$$.node=l;
				}
%ifdef DPP
	|	Complete_Class_Name OP_DOSPUNTOSDOBLE OP_ASTERISCO
				{//	Complete_Class_Name OP_DOSPUNTOSDOBLE OP_ASTERISCO
					CodeDOM::XplPointerinfo*l=CodeDOM::XplType::new_pi();
					l->set_memberof($1.str);
					$$.node=l;
				}
	|	Complete_Class_Name OP_DOSPUNTOSDOBLE OP_ASTERISCO Pointer_Modifier_List
				{//	Complete_Class_Name OP_DOSPUNTOSDOBLE OP_ASTERISCO Pointer_Modifier_List
					CodeDOM::XplPointerinfo*l=CodeDOM::XplType::new_pi();
					l->set_memberof($1.str);
					if( ($4.num & SM_CONST)==SM_CONST)l->set_const(true);
					if( ($4.num & SM_VOLATILE)==SM_VOLATILE)l->set_volatile(true);
					if( ($4.num & SM_REF)==SM_REF)l->set_ref(true);
					$$.node=l;
				}
	;
%endif

Pointer_Modifier_List
	:	Pointer_Modifier
				{//	Pointer_Modifier
					$$.num=$1.num;
				}
	|	Pointer_Modifier Pointer_Modifier_List
				{//	Pointer_Modifier Pointer_Modifier_List
					if( ($1.num & $2.num)==$2.num){
						SINTAX_ERROR("Pointer modifier duplicated.");
					}
					$$.num=$1.num|$2.num;
				}
	;

Pointer_Modifier
	:	PC_CONST        {$$.num=SM_CONST;}
	|	PC_VOLATILE		{$$.num=SM_VOLATILE;}
	|	PC_REF			{$$.num=SM_REF;}
	;

Array_Mod
	:	OPEN_CORCHETE CLOSE_CORCHETE
				{//	OPEN_CORCHETE CLOSE_CORCHETE
					$$.exp=NULL;
				}
	|	OPEN_CORCHETE Expression CLOSE_CORCHETE
				{//	OPEN_CORCHETE Expression CLOSE_CORCHETE
					CodeDOM::XplExpression *e=CodeDOM::XplType::new_ae();
					e->set_texpression($2.node);
					$$.exp=e;
				}
	;

Parameters_Declarator_List
	:	Parameter_Declarator
				{//	Parameter_Declarator
					CodeDOM::XplParameter* p=(CodeDOM::XplParameter*)$1.node;
					CodeDOM::XplParameters* ps=new CodeDOM::XplParameters();
					p->set_number(ps->Childs()->getLenght()+1);
					ps->Childs()->InsertAtEnd(p);
					$$.node=ps;
					//SET_SOURCE_DATA_S(p,0);
				}
	|	Parameters_Declarator_List COMA Parameter_Declarator
				{//	Argument_Declarator_List COMA Argument_Declarator
					CodeDOM::XplParameter* p=(CodeDOM::XplParameter*)$3.node;
					CodeDOM::XplParameters* ps=(CodeDOM::XplParameters*)$1.node;
					p->set_number(ps->Childs()->getLenght()+1);
					ps->Childs()->InsertAtEnd(p);
					$$.node=ps;
					//SET_SOURCE_DATA_S(p,0);
				}
	;

Parameter_Declarator
	:	Type_Declarator Declarator [YYVALID;]
				{//	Type_Declarator Declarator
					CodeDOM::XplType* t=(CodeDOM::XplType*)$1.nodos[0];
					CodeDOM::XplParameter* p=CodeDOM::XplParameters::new_P();
					p->set_direction(CodeDOM::ZOEPARAMETERDIRECTION_ENUM_IN);
					p->set_type(t);
					if($2.nodos[0]!=NULL){
						p->set_name(*(CodeDOM::string*)$2.nodos[0]);
						delete (CodeDOM::string*)$2.nodos[0];
					}
					if($2.nodos[2]!=NULL)p->set_i((CodeDOM::XplInitializerList*)$2.nodos[2]);
					SetParameterModifiers(p,(unsigned)$1.nodos[1]);
					$$.node=p;
					SET_SOURCE_DATA_S(t,-1);
				}
	;

Storage_Mod_List
	:	Storage_Mod
				{//	Storage_Mod
					$$.num=$1.num;
				}
	|	Storage_Mod_List Storage_Mod
				{//	Storage_Mod_List Storage_Mod
					if( ($1.num & $2.num)==$2.num){
						WARNING_MESSAGE("Storage modifier duplicated.");
					}
					$$.num=$1.num|$2.num;
				}
	;

Storage_Mod
	:	Access_Modifier     {$$.num=$1.num;}
	|	PC_STATIC			{$$.num=SM_STATIC;}
	|	PC_CONST			{$$.num=SM_CONST;}
	|	PC_VOLATILE 		{$$.num=SM_VOLATILE;}
	|	PC_EXTERN			{$$.num=SM_EXTERN;}
	|	PC_EXTENSION		{$$.num=SM_EXTENSION;}
	|	PC_FACTORY			{$$.num=SM_FACTORY;}
	|	PC_INTERACTIVE		{$$.num=SM_INTERACTIVE;}
	|	PC_KEYWORD			{$$.num=SM_KEYWORD;}
	|	PC_FINAL    		{$$.num=SM_FINAL;}
	|	PC_NEW  			{$$.num=SM_NEW;}
	|	PC_OVERRIDE			{$$.num=SM_OVERRIDE;}
	|	PC_VIRTUAL			{$$.num=SM_VIRTUAL;}
	|	PC_NONVIRTUAL		{$$.num=SM_NONVIRTUAL;}
	|	PC_EXEC 			{$$.num=SM_EXEC;}
	|	PC_FPOINTER			{$$.num=SM_FPOINTER;}
	|   PC_FORCE            {$$.num=SM_FORCE;}
	|   PC_ABSTRACT			{$$.num=SM_ABSTRACT;}
	|	PC_IN				{$$.num=SM_IN;}
	|	PC_OUT				{$$.num=SM_OUT;}
	|	PC_INOUT    		{$$.num=SM_INOUT;}
	|   PC_PARAMS			{$$.num=SM_PARAMS;}
	|	PC_INAME			{$$.num=SM_INAME;}
	|	PC_EXPRESSION		{$$.num=SM_EXPRESSION;}
	;

Block_Or_PC
    :   Block       {$$=$1;}
    |   PUNTO_COMA  {$$.node=NULL;}
    ;

Function_Decl
	:	Type_Declarator Declarator_F OPEN_PARENTESIS Parameters_Declarator_List CLOSE_PARENTESIS Block_Or_PC [YYVALID;]
	            {
					$$.node=CreateFunction((unsigned int)$1.nodos[1]/*Storage*/,(CodeDOM::XplType*)$1.nodos[0]/*Type_Decl*/,(CodeDOM::XplFunction*)$2.node/*Decl_F*/,(CodeDOM::XplParameters*)$4.node/*Parameters*/,(CodeDOM::XplBaseInitializers*)NULL/*Base_Init*/,(CodeDOM::XplFunctionBody*)$6.node/*Block*/);
					SET_SOURCE_DATA(((CodeDOM::XplFunction*)$$.node),-5,-1);
				}
	|	Type_Declarator Declarator_F OPEN_PARENTESIS CLOSE_PARENTESIS Block_Or_PC [YYVALID;]
	            {
					$$.node=CreateFunction((unsigned int)$1.nodos[1]/*Storage*/,(CodeDOM::XplType*)$1.nodos[0]/*Type_Decl*/,(CodeDOM::XplFunction*)$2.node/*Decl_F*/,(CodeDOM::XplParameters*)NULL/*Parameters*/,(CodeDOM::XplBaseInitializers*)NULL/*Base_Init*/,(CodeDOM::XplFunctionBody*)$5.node/*Block*/);
					SET_SOURCE_DATA(((CodeDOM::XplFunction*)$$.node),-4,-1);
				}
	|	Type_Declarator Declarator_F OPEN_PARENTESIS Parameters_Declarator_List CLOSE_PARENTESIS Base_Initializers Block_Or_PC [YYVALID;]
	            {
					$$.node=CreateFunction((unsigned int)$1.nodos[1]/*Storage*/,(CodeDOM::XplType*)$1.nodos[0]/*Type_Decl*/,(CodeDOM::XplFunction*)$2.node/*Decl_F*/,(CodeDOM::XplParameters*)$4.node/*Parameters*/,(CodeDOM::XplBaseInitializers*)$6.node/*Base_Init*/,(CodeDOM::XplFunctionBody*)$7.node/*Block*/);
					SET_SOURCE_DATA(((CodeDOM::XplFunction*)$$.node),-5,-2);
				}
	|	Type_Declarator Declarator_F OPEN_PARENTESIS CLOSE_PARENTESIS Base_Initializers Block_Or_PC [YYVALID;]
	            {
					$$.node=CreateFunction((unsigned int)$1.nodos[1]/*Storage*/,(CodeDOM::XplType*)$1.nodos[0]/*Type_Decl*/,(CodeDOM::XplFunction*)$2.node/*Decl_F*/,(CodeDOM::XplParameters*)NULL/*Parameters*/,(CodeDOM::XplBaseInitializers*)$5.node/*Base_Init*/,(CodeDOM::XplFunctionBody*)$6.node/*Block*/);
					SET_SOURCE_DATA(((CodeDOM::XplFunction*)$$.node),-5,-2);
				}

	/*Formatos para Constructores y Destructores*/
	|	Storage_Mod_List Declarator_F OPEN_PARENTESIS CLOSE_PARENTESIS Base_Initializers Block_Or_PC [YYVALID;]
	            {
					$$.node=CreateFunction($1.num/*Storage*/,(CodeDOM::XplType*)NULL/*Type_Decl*/,(CodeDOM::XplFunction*)$2.node/*Decl_F*/,(CodeDOM::XplParameters*)NULL/*Parameters*/,(CodeDOM::XplBaseInitializers*)$5.node/*Base_Init*/,(CodeDOM::XplFunctionBody*)$6.node/*Block*/);
					SET_SOURCE_DATA(((CodeDOM::XplFunction*)$$.node),-5,-3);
				}
	|	Storage_Mod_List Declarator_F OPEN_PARENTESIS Parameters_Declarator_List CLOSE_PARENTESIS Base_Initializers Block_Or_PC [YYVALID;]
	            {
					$$.node=CreateFunction($1.num/*Storage*/,(CodeDOM::XplType*)NULL/*Type_Decl*/,(CodeDOM::XplFunction*)$2.node/*Decl_F*/,(CodeDOM::XplParameters*)$4.node/*Parameters*/,(CodeDOM::XplBaseInitializers*)$6.node/*Base_Init*/,(CodeDOM::XplFunctionBody*)$7.node/*Block*/);
					SET_SOURCE_DATA(((CodeDOM::XplFunction*)$$.node),-5,-2);
				}
	|	Declarator_F OPEN_PARENTESIS CLOSE_PARENTESIS Base_Initializers Block_Or_PC [YYVALID;]
	            {
					$$.node=CreateFunction(0/*Storage*/,(CodeDOM::XplType*)NULL/*Type_Decl*/,(CodeDOM::XplFunction*)$1.node/*Decl_F*/,(CodeDOM::XplParameters*)NULL/*Parameters*/,(CodeDOM::XplBaseInitializers*)$4.node/*Base_Init*/,(CodeDOM::XplFunctionBody*)$5.node/*Block*/);
					SET_SOURCE_DATA(((CodeDOM::XplFunction*)$$.node),-4,-2);
				}
	|	Declarator_F OPEN_PARENTESIS Parameters_Declarator_List CLOSE_PARENTESIS Base_Initializers Block_Or_PC [YYVALID;]
	            {
					$$.node=CreateFunction(0/*Storage*/,(CodeDOM::XplType*)NULL/*Type_Decl*/,(CodeDOM::XplFunction*)$1.node/*Decl_F*/,(CodeDOM::XplParameters*)$3.node/*Parameters*/,(CodeDOM::XplBaseInitializers*)$5.node/*Base_Init*/,(CodeDOM::XplFunctionBody*)$6.node/*Block*/);
					SET_SOURCE_DATA(((CodeDOM::XplFunction*)$$.node),-5,-2);
				}

	|	Storage_Mod_List Declarator_F OPEN_PARENTESIS CLOSE_PARENTESIS Block_Or_PC [YYVALID;]
	            {
					$$.node=CreateFunction($1.num/*Storage*/,(CodeDOM::XplType*)NULL/*Type_Decl*/,(CodeDOM::XplFunction*)$2.node/*Decl_F*/,(CodeDOM::XplParameters*)NULL/*Parameters*/,(CodeDOM::XplBaseInitializers*)NULL/*Base_Init*/,(CodeDOM::XplFunctionBody*)$5.node/*Block*/);
					SET_SOURCE_DATA(((CodeDOM::XplFunction*)$$.node),-3,-1);
				}
	|	Storage_Mod_List Declarator_F OPEN_PARENTESIS Parameters_Declarator_List CLOSE_PARENTESIS Block_Or_PC [YYVALID;]
				{
					$$.node=CreateFunction($1.num/*Storage*/,(CodeDOM::XplType*)NULL/*Type_Decl*/,(CodeDOM::XplFunction*)$2.node/*Decl_F*/,(CodeDOM::XplParameters*)$4.node/*Parameters*/,(CodeDOM::XplBaseInitializers*)NULL/*Base_Init*/,(CodeDOM::XplFunctionBody*)$6.node/*Block*/);
					SET_SOURCE_DATA(((CodeDOM::XplFunction*)$$.node),-4,-1);
				}
	|	Declarator_F OPEN_PARENTESIS CLOSE_PARENTESIS Block_Or_PC [YYVALID;]
	            {
					$$.node=CreateFunction(0/*Storage*/,(CodeDOM::XplType*)NULL/*Type_Decl*/,(CodeDOM::XplFunction*)$1.node/*Decl_F*/,(CodeDOM::XplParameters*)NULL/*Parameters*/,(CodeDOM::XplBaseInitializers*)NULL/*Base_Init*/,(CodeDOM::XplFunctionBody*)$4.node/*Block*/);
					SET_SOURCE_DATA(((CodeDOM::XplFunction*)$$.node),-3,-1);
				}
	|	Declarator_F OPEN_PARENTESIS Parameters_Declarator_List CLOSE_PARENTESIS Block_Or_PC [YYVALID;]
	            {
					$$.node=CreateFunction(0/*Storage*/,(CodeDOM::XplType*)NULL/*Type_Decl*/,(CodeDOM::XplFunction*)$1.node/*Decl_F*/,(CodeDOM::XplParameters*)$3.node/*Parameters*/,(CodeDOM::XplBaseInitializers*)NULL/*Base_Init*/,(CodeDOM::XplFunctionBody*)$5.node/*Block*/);
					SET_SOURCE_DATA(((CodeDOM::XplFunction*)$$.node),-4,-1);
				}
    ;

Field_Decl
	:	Type_Declarator Declarator_List PUNTO_COMA [YYVALID;]
				{//	Type_Declarator Declarator_List PUNTO_COMA
					CodeDOM::XplDeclaratorlist* dl=(CodeDOM::XplDeclaratorlist*)$2.node;
					CodeDOM::XplDeclarator*d =NULL;
					CodeDOM::XplField* f=NULL;
					CodeDOM::XplType* t=NULL;
					CodeDOM::XplNodeList*cm=new CodeDOM::XplNodeList();
					for(d=(CodeDOM::XplDeclarator*)dl->Childs()->FirstNode();d!=NULL;d=(CodeDOM::XplDeclarator*)dl->Childs()->NextNode()){
						t=(CodeDOM::XplType*)$1.nodos[0]->Clone();
						t->set_ElementName(DT("type"));
						//Ahora creo el field y copio los datos del declarator
						f=CodeDOM::XplClass::new_Field();
						f->set_name(d->get_name());
						f->set_type(t);
						d->set_type(NULL);
						f->set_i(d->get_i());
						d->set_i(NULL);
						SetFieldStorage(f,(unsigned)$1.nodos[1]);
						cm->InsertAtEnd(f);
					}
					delete dl;
					$$.list=cm;
					SET_SOURCE_DATA(f,-2,0);
				}
	;

Base_Initializers
    :   OP_DOSPUNTOS Base_Initializers_2
                {$$=$2;}
    ;

Base_Initializers_2
	:	Base_Initializer
				{//	Base_Initializer
					CodeDOM::XplBaseInitializers *bi=CodeDOM::XplFunction::new_BaseInitializers();
					bi->Childs()->InsertAtEnd($1.node);
					$$.node=bi;
				}
	|	Base_Initializers_2 COMA Base_Initializer
				{//	Base_Initializers COMA Base_Initializer
					CodeDOM::XplBaseInitializers *bi=(CodeDOM::XplBaseInitializers*)$1.node;
					bi->Childs()->InsertAtEnd($3.node);
					$$.node=bi;
				}
	;

Base_Initializer
	:	Complete_Class_Name OPEN_PARENTESIS Expression_List CLOSE_PARENTESIS
				{//	Complete_Class_Name OPEN_PARENTESIS Expression_List CLOSE_PARENTESIS
					CodeDOM::XplBaseInitializer *i=CodeDOM::XplBaseInitializers::new_i();
					i->set_className($1.str);
					i->set_params((CodeDOM::XplExpressionlist*)$3.node);
					$$.node=i;
					SET_SOURCE_DATA(i,-3,0);
				}
	|	Complete_Class_Name OPEN_PARENTESIS CLOSE_PARENTESIS
				{//	Complete_Class_Name OPEN_PARENTESIS CLOSE_PARENTESIS
					CodeDOM::XplBaseInitializer *i=CodeDOM::XplBaseInitializers::new_i();
					i->set_className($1.str);
					i->set_params(CodeDOM::XplBaseInitializer::new_params());
					$$.node=i;
					SET_SOURCE_DATA(i,-2,0);
				}
	;

Property_Decl
	:	Type_Declarator PC_PROPERTY Complete_Class_Name Block [YYVALID;]
				{//	R_Type_Decl PC_PROPERTY Complete_Class_Name OPEN_LLAVE Block CLOSE_LLAVE
					CodeDOM::XplProperty*p=CodeDOM::XplClass::new_Property();

					p->set_type((CodeDOM::XplType*)$1.node);
					p->set_name($3.str);
					p->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_AUTO);
					if($4.node!=NULL)p->set_body((CodeDOM::XplFunctionBody*)$4.node);
					SetPropertyStorage(p,(unsigned)$1.nodos[1]);

					$$.node=p;
					SET_SOURCE_DATA_S(p,-2);
				}
	;

/*************************************************/
Declarator
	:	IDENTIFICADOR
				{//	DeclaratorA
					$$.nodos[0]=(CodeDOM::XplNode*)new CodeDOM::string($1.str);		//Identificador
					$$.nodos[1]=NULL;			//Inicializador
					$$.nodos[2]=NULL;
					RET_POS=GET_PARSER_POS[0];
				}
	|	IDENTIFICADOR Initializer
				{//	DeclaratorA Initializer
					$$.nodos[0]=(CodeDOM::XplNode*)new CodeDOM::string($1.str);		//Identificador
					$$.nodos[1]=$2.node;		//Inicializador
					$$.nodos[2]=NULL;
					RET_POS=GET_PARSER_POS[-1];
				}
	;

Declarator_List
	:	Declarator
				{//	Declarator
					CodeDOM::XplDeclaratorlist*l=new CodeDOM::XplDeclaratorlist();
					CodeDOM::XplDeclarator* d=CodeDOM::XplDeclaratorlist::new_d();
					if($1.nodos[0]!=NULL){
						d->set_name(*(CodeDOM::string*)$1.nodos[0]);
						delete (CodeDOM::string*)$1.nodos[0];
					}
					if($1.nodos[1]!=NULL)d->set_i((CodeDOM::XplInitializerList*)$1.nodos[1]);
					l->Childs()->InsertAtEnd(d);
					$$.node=l;
					SET_SOURCE_DATA_S(d,0);
				}
	|	Declarator_List COMA Declarator
				{//	Declarator_List COMA Declarator
					CodeDOM::XplDeclaratorlist*l=(CodeDOM::XplDeclaratorlist*)$1.node;
					CodeDOM::XplDeclarator* d=CodeDOM::XplDeclaratorlist::new_d();
					if($3.nodos[0]!=NULL){
						d->set_name(*(CodeDOM::string*)$3.nodos[0]);
						delete (CodeDOM::string*)$3.nodos[0];
					}
					if($3.nodos[1]!=NULL)d->set_i((CodeDOM::XplInitializerList*)$3.nodos[1]);
					l->Childs()->InsertAtEnd(d);
					$$.node=l;
					SET_SOURCE_DATA_S(d,0);
				}
	;

/****************************************************
	SECCION: INSTRUCCIONES
*****************************************************/

Block
    :	OPEN_LLAVE Block_Statements CLOSE_LLAVE
				{//	OPEN_LLAVE Block_Statements CLOSE_LLAVE
					$$.node=$2.node;
					SET_SOURCE_DATA(((CodeDOM::XplFunctionBody*)$2.node),-2,0);
				}
	|	OPEN_LLAVE CLOSE_LLAVE
				{//	OPEN_LLAVE CLOSE_LLAVE
					CodeDOM::XplFunctionBody *fb=new CodeDOM::XplFunctionBody();
					$$.node=fb;
					SET_SOURCE_DATA(fb,-1,0);
				}
	;

/*
Factory_List
	:	Complete_Class_Name
	|	Factory_List COMA Complete_Class_Name
	;
	*/

Get_Block
	:	PC_GET Block
				{//	PC_GET Block
					$2.node->set_ElementName(L"Get");
					$$.node=$2.node;
				}
	|	PC_GET PUNTO_COMA
				{//	PC_GET PUNTO_COMA
					CodeDOM::XplFunctionBody* bk=new CodeDOM::XplFunctionBody();
					bk->set_ElementName(L"Get");
					bk->set_lddata(L"%abstract%");
					$$.node=bk;
					SET_SOURCE_DATA(bk,-1,0);
				}
	;

Set_Block
	:	PC_SET Block
				{//	PC_PUT Block
					$2.node->set_ElementName(L"Set");
					$$.node=$2.node;
				}
	|	PC_SET PUNTO_COMA
				{//	PC_PUT PUNTO_COMA
					CodeDOM::XplFunctionBody* bk=new CodeDOM::XplFunctionBody();
					bk->set_ElementName(L"Set");
					bk->set_lddata(L"%abstract%");
					$$.node=bk;
					SET_SOURCE_DATA(bk,-1,0);
				}
	;

Block_Statements
	:	Block_Statement
				{//	Block_Statement
					//ASSING_COMMENT($1.node);
					CodeDOM::XplFunctionBody *fb=new CodeDOM::XplFunctionBody();
					fb->Childs()->InsertAtEnd($1.node);
					if($1.node->get_ElementName()==L"label"){
						fb->Childs()->InsertAtEnd($1.nodos[1]);
						$1.nodos[1]=NULL;
					}
					$$.node=fb;
				}
	|	Block_Statements Block_Statement
				{//	Block_Statements Block_Statement
					CodeDOM::XplFunctionBody *fb=(CodeDOM::XplFunctionBody*)$1.node;
					if(fb==NULL)fb=new CodeDOM::XplFunctionBody();
					//ASSING_COMMENT($2.node);
					fb->Childs()->InsertAtEnd($2.node);
					if($2.node->get_ElementName()==L"label"){
						fb->Childs()->InsertAtEnd($2.nodos[1]);
						$2.nodos[1]=NULL;
					}
					$$.node=fb;
				}
	;

Comments
	:	COMENTARIO
				{
					$$=$1;
				}
	|	Comments COMENTARIO
				{
					((CodeDOM::XplDocumentation*)$1.node)->set_short( ((CodeDOM::XplDocumentation*)$1.node)->get_short() + ((CodeDOM::XplDocumentation*)$2.node)->get_short() );
					$$=$1;
				}
	;

Block_Statement
	:	Local_Variable_Declaration_Statement [YYVALID;]{$$=$1;}
	|	Statement [YYVALID;]{$$=$1;}
	;

WC_Block
	:	OPEN_LLAVE WC_Block_Content CLOSE_LLAVE
				{//	OPEN_LLAVE WC_Block_Statements CLOSE_LLAVE
					$$.node=$2.node;
				}
	//|	OPEN_LLAVE COMENTARIO WC_Block_Content CLOSE_LLAVE
	//			{//	OPEN_LLAVE COMENTARIO WC_Block_Content CLOSE_LLAVE
	//				$$.node=$3.node;
	//			}
	|	OPEN_LLAVE CLOSE_LLAVE
				{//	OPEN_LLAVE CLOSE_LLAVE
					CodeDOM::XplFunctionBody *fb=new CodeDOM::XplFunctionBody();
					$$.node=fb;
					SET_SOURCE_DATA(fb,-1,0);
				}
	;

WC_Block2
	:	OPEN_LLAVE OP_PORCENTAJE WC_Block_Content2 OP_PORCENTAJE CLOSE_LLAVE
				{//	OPEN_LLAVE WC_Block_Statements CLOSE_LLAVE
					$$.node=$3.node;
				}
	;

//El bloque del Writecode puede contener cualquier cosa practicamente
WC_Block_Content
	:	Comments Type_Decl
				{//	WC_ClassInterfaceUnion_Decl
					$2.node->set_doc( ((CodeDOM::XplDocumentation*)$1.node)->get_short() );
					$2.node->set_ElementName(L"class");
					$$.node=$2.node;
				}
	|	Block_Statements
				{//	WC_Block_Statements
					$1.node->set_ElementName(L"bk");
					$$.node=$1.node;
				}
	|	Type_Decl
				{//	WC_ClassInterfaceUnion_Decl
					$1.node->set_ElementName(L"class");
					$$.node=$1.node;
				}
    |	Compilation_Unit
				{//	Compilation_Unit
					$1.node->set_ElementName(L"progunit");
					$$.node=$1.node;
				}
	;

WC_Block_Content2
	:	Class_Decl_Block
				{//	Class_Decl_Block
					CodeDOM::XplClassMembersList* list = CodeDOM::XplWriteCodeBody::new_classmembers();

					CodeDOM::XplNodeList* members=(CodeDOM::XplNodeList*)$1.nodos[0];
					SetClassMembers(list->Childs(), members, false);
					//for(CodeDOM::XplNode* m2=members->FirstNode();m2!=NULL;m2=members->NextNode()){
					//	list->Childs()->InsertAtEnd(m2);
					//}
					$$.node=list;
				}
	;

Local_Variable_Declaration_Statement
	:   Local_Variable_Declaration PUNTO_COMA [YYVALID;]
				{//	Local_Variable_Declaration PUNTO_COMA
					$1.node->set_ElementName(L"Decls");
					$$.node=$1.node;
				}
	;

Local_Variable_Declaration
	:	Type_Declarator Declarator_List
				{//	Type_Declarator Declarator_List
					CodeDOM::XplDeclaratorlist* dl=(CodeDOM::XplDeclaratorlist*)$2.node;
					CodeDOM::XplDeclarator*d =NULL;
					CodeDOM::XplType* t=NULL;
					for(d=(CodeDOM::XplDeclarator*)dl->Childs()->FirstNode();d!=NULL;d=(CodeDOM::XplDeclarator*)dl->Childs()->NextNode()){
						t=(CodeDOM::XplType*)$1.nodos[0];
						if(t==NULL){
							SINTAX_ERROR("invalid declaration.");
							t = new CodeDOM::XplType();
						}
						t=(CodeDOM::XplType*)t->Clone();
						t->set_ElementName(DT("type"));
						d->set_type(t);
						SetLocalVarsModifiers(d,(unsigned)$1.nodos[1]);
					}
					///Borro el tipo temporal en el nodo 1
					delete $1.nodos[0];
					$$.node=dl;
				}
	;

Statement
	:	Block
				{//	Block
					tempNode=$1.node;
					tempNode->set_ElementName(L"bk");
					$$.node=tempNode;
				}
	|	Empty_Statement							{$$=$1;}
	|	Expression_Statement					{$$=$1;}
	|	Switch_Statement						{$$=$1;}
	|	Do_Statement							{$$=$1;}
	|	Break_Statement							{$$=$1;}
	|	Continue_Statement						{$$=$1;}
	|	Return_Statement						{$$=$1;}
	|	Throw_Statement							{$$=$1;}
	|	Try_Statement							{$$=$1;}
	|	Labeled_Statement						{$$=$1;}
	|	If_Then_Statement						{$$=$1;}
	|	While_Statement							{$$=$1;}
	|	For_Statement							{$$=$1;}
	|	SetHandler_Statement					{$$=$1;}
	|	Resume_Statement						{$$=$1;}
	|   Get_Or_Set_Block						{$$=$1;}
	|	Comments								{$$=$1;}
	|	error PUNTO_COMA
				{//	error PUNTO_COMA
					SINTAX_ERROR("invalid instruction before semicolon (;).");
					CodeDOM::XplExpression *temp2=CodeDOM::XplFunctionBody::new_e();
					temp2->set_texpression(CodeDOM::XplExpression::new_empty());
					$$.node=temp2;
				}
	;

SetHandler_Statement
	:	PC_SET IDENTIFICADOR IDENTIFICADOR IDENTIFICADOR PUNTO_COMA
				{//	PC_SET PC_ERROR PC_HANDLER IDENTIFICADOR
					CodeDOM::string s1=$2.str,s2=$3.str;
					if(s1!=L"error" || s2!=L"handler"){
						SINTAX_ERROR("'set error' statement invalid. Use: set error handler LABEL ; ");
					}
					CodeDOM::XplSetonerror* se=CodeDOM::XplFunctionBody::new_setonerror();
					se->set_label($4.str);
					$$.node=se;
					SET_SOURCE_DATA(se,-4,0);
				}
	|	PC_SET	error PUNTO_COMA
				{//	PC_SET	error PUNTO_COMA
					SINTAX_ERROR("'set error' statement invalid. Use: set error handler LABEL ; ");
					CodeDOM::XplSetonerror* se=CodeDOM::XplFunctionBody::new_setonerror();
                    /*YYVALID;*/
                    yyps->errflag=1;
					$$.node=se;
				}
	;

Resume_Statement
	:	PC_RESUME PUNTO_COMA
				{//	PC_RESUME PUNTO_COMA
					CodeDOM::XplJump* j=CodeDOM::XplFunctionBody::new_jump();
					j->set_type(CodeDOM::ZOEJUMPTYPE_ENUM_RESUME);
					$$.node=j;
					SET_SOURCE_DATA(j,-1,0);
				}
	|	PC_RESUME IDENTIFICADOR PUNTO_COMA
				{//	PC_RESUME PC_NEXT PUNTO_COMA
					CodeDOM::string s1=$2.str;
					if(s1!=L"next"){
						SINTAX_ERROR("'resume' statement invalid. Use 'resume' o 'resume next'.");
					}
					CodeDOM::XplJump* j=CodeDOM::XplFunctionBody::new_jump();
					j->set_type(CodeDOM::ZOEJUMPTYPE_ENUM_RESUMENEXT);
					$$.node=j;
					SET_SOURCE_DATA(j,-2,0);
				}
	;

Get_Or_Set_Block
    :   Get_Block                   {$$=$1;}
    |   Set_Block                   {$$=$1;}
    |   Access_Modifier Get_Block   {$$=$2;}
    |   Access_Modifier Set_Block   {$$=$2;}
    ;

Expression_Statement
	:	Expression PUNTO_COMA
				{//	Expression PUNTO_COMA
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($1.node);
					temp2->set_ElementName(L"e");
					$$.node=temp2;
					SET_SOURCE_DATA_S(temp2,0);
				}
	;

If_Then_Statement
	:	PC_IF OPEN_PARENTESIS Expression CLOSE_PARENTESIS Statement
				{//	PC_IF OPEN_PARENTESIS Expression CLOSE_PARENTESIS Statement
					CodeDOM::XplIfStatement* pif=CodeDOM::XplFunctionBody::new_if();
					pif->set_boolean(new CodeDOM::XplExpression($3.node));
					CodeDOM::XplFunctionBody*ifbk=NULL;
					SET_SOURCE_DATA_S(pif,-4);
					if($5.node->get_TypeName()==CodeDOM::CODEDOMTYPES_ZOEFUNCTIONBODY){

						ifbk=(CodeDOM::XplFunctionBody*)$5.node;
						//ifbk->set_ElementName(L"ifbk");
					}
					else{
						ifbk=CodeDOM::XplIfStatement::new_ifbk();
						ifbk->Childs()->InsertAtEnd($5.node);
					}
					pif->set_ifbk(ifbk);

					$$.node=pif;
				}
	|	PC_IF OPEN_PARENTESIS Expression CLOSE_PARENTESIS Statement PC_ELSE Statement
				{//	PC_IF OPEN_PARENTESIS Expression CLOSE_PARENTESIS Statement_NoShort_If PC_ELSE Statement
					CodeDOM::XplIfStatement* pif=CodeDOM::XplFunctionBody::new_if();
					pif->set_boolean(new CodeDOM::XplExpression($3.node));
					CodeDOM::XplFunctionBody*ifbk=NULL;
					CodeDOM::XplNode*node=$5.node;
					SET_SOURCE_DATA_S(pif,-6);
					if($5.node!=NULL){
						if($5.node->get_TypeName()==CodeDOM::CODEDOMTYPES_ZOEFUNCTIONBODY){
							ifbk=(CodeDOM::XplFunctionBody*)$5.node;
							//ifbk->set_ElementName(L"ifbk");
						}
						else{
							ifbk=CodeDOM::XplIfStatement::new_ifbk();
							ifbk->Childs()->InsertAtEnd($5.node);
						}
					}
					else
						WARNING_MESSAGE("Error; invalid if statement.");
					pif->set_ifbk(ifbk);

					if($7.node!=NULL){
						if($7.node->get_TypeName()==CodeDOM::CODEDOMTYPES_ZOEFUNCTIONBODY){
							ifbk=(CodeDOM::XplFunctionBody*)$7.node;
							//ifbk->set_ElementName(L"else");
						}
						else{
							ifbk=CodeDOM::XplIfStatement::new_else();
							ifbk->Childs()->InsertAtEnd($7.node);
						}
					}
					else
						WARNING_MESSAGE("Error; invalid else statement.");
					SET_SOURCE_DATA_S(ifbk,-1);
					pif->set_else(ifbk);
					$$.node=pif;
				}
	;

While_Statement
	:	PC_WHILE OPEN_PARENTESIS Expression CLOSE_PARENTESIS Statement
				{//	PC_WHILE OPEN_PARENTESIS Expression CLOSE_PARENTESIS Statement
					CodeDOM::XplDowhileStatement* dw=CodeDOM::XplFunctionBody::new_while();
					dw->set_boolean(new CodeDOM::XplExpression($3.node));
					CodeDOM::XplFunctionBody*dbk=NULL;
					SET_SOURCE_DATA_S(dw,-4);

					if($5.node->get_TypeName()==CodeDOM::CODEDOMTYPES_ZOEFUNCTIONBODY){
						dbk=(CodeDOM::XplFunctionBody*)$5.node;
					}
					else{
						dbk=CodeDOM::XplDowhileStatement::new_dobk();
						dbk->Childs()->InsertAtEnd($5.node);
					}
					dw->set_dobk(dbk);

					$$.node=dw;
				}
	;


Do_Statement
	:	PC_DO Statement PC_WHILE OPEN_PARENTESIS Expression CLOSE_PARENTESIS PUNTO_COMA
				{//	PC_DO Statement PC_WHILE OPEN_PARENTESIS Expression CLOSE_PARENTESIS PUNTO_COMA
					CodeDOM::XplDowhileStatement* dw=CodeDOM::XplFunctionBody::new_do();
					dw->set_boolean(new CodeDOM::XplExpression($5.node));
					CodeDOM::XplFunctionBody*dbk=NULL;
					SET_SOURCE_DATA_S(dw,-6);

					if($2.node->get_TypeName()==CodeDOM::CODEDOMTYPES_ZOEFUNCTIONBODY){
						dbk=(CodeDOM::XplFunctionBody*)$2.node;
					}
					else{
						dbk=CodeDOM::XplDowhileStatement::new_dobk();
						dbk->Childs()->InsertAtEnd($2.node);
					}
					dw->set_dobk(dbk);

					$$.node=dw;
				}
	;

For_Statement
	:	PC_FOR OPEN_PARENTESIS For_Init PUNTO_COMA Expression PUNTO_COMA For_Update CLOSE_PARENTESIS Statement
				{//	PC_FOR OPEN_PARENTESIS For_Init PUNTO_COMA Expression PUNTO_COMA For_Update CLOSE_PARENTESIS Statement
					CodeDOM::XplForStatement*
					fs=CreateFor($3.node/*Init*/,$5.node/*Cond*/,$7.node/*Upd*/,$9.node/*Stat*/);
					$$.node=fs;
					SET_SOURCE_DATA(fs,-8,-1);
				}
	|	PC_FOR OPEN_PARENTESIS For_Init PC_IN Expression CLOSE_PARENTESIS Statement
				{//	PC_FOR OPEN_PARENTESIS For_Init PC_IN Expression CLOSE_PARENTESIS Statement

					CodeDOM::XplNode* foreachexp = CodeDOM::XplExpression::new_n();
					foreachexp->set_Value(L"_FOR_EACH_");
					CodeDOM::XplExpressionlist* fexp = CodeDOM::XplForStatement::new_repeat();
					CodeDOM::XplExpression* uexp = CodeDOM::XplExpressionlist::new_e();
					uexp->set_texpression(foreachexp);
					fexp->Childs()->InsertAtEnd(uexp);

					CodeDOM::XplForStatement*
					fs=CreateFor($3.node/*Init*/,$5.node/*Cond*/, fexp/*Upd*/,$7.node/*Stat*/);
					$$.node=fs;
					SET_SOURCE_DATA(fs,-6,-1);
				}
	|	PC_FOR OPEN_PARENTESIS PUNTO_COMA Expression PUNTO_COMA For_Update CLOSE_PARENTESIS Statement
				{//	PC_FOR OPEN_PARENTESIS PUNTO_COMA Expression PUNTO_COMA For_Update CLOSE_PARENTESIS Statement
					CodeDOM::XplForStatement*
					fs=CreateFor(NULL/*Init*/,$4.node/*Cond*/,$6.node/*Upd*/,$8.node/*Stat*/);
					$$.node=fs;
					SET_SOURCE_DATA(fs,-7,-1);
				}
	|	PC_FOR OPEN_PARENTESIS For_Init PUNTO_COMA PUNTO_COMA For_Update CLOSE_PARENTESIS Statement
				{//	PC_FOR OPEN_PARENTESIS For_Init PUNTO_COMA PUNTO_COMA For_Update CLOSE_PARENTESIS Statement
					CodeDOM::XplForStatement*
					fs=CreateFor($3.node/*Init*/,NULL/*Cond*/,$6.node/*Upd*/,$8.node/*Stat*/);
					$$.node=fs;
					SET_SOURCE_DATA(fs,-7,-1);
				}
	|	PC_FOR OPEN_PARENTESIS For_Init PUNTO_COMA Expression PUNTO_COMA CLOSE_PARENTESIS Statement
				{//	PC_FOR OPEN_PARENTESIS For_Init PUNTO_COMA Expression PUNTO_COMA CLOSE_PARENTESIS Statement
					CodeDOM::XplForStatement*
					fs=CreateFor($3.node/*Init*/,$5.node/*Cond*/,NULL/*Upd*/,$8.node/*Stat*/);
					$$.node=fs;
					SET_SOURCE_DATA(fs,-7,-1);
				}
	|	PC_FOR OPEN_PARENTESIS PUNTO_COMA Expression PUNTO_COMA CLOSE_PARENTESIS Statement
				{//	PC_FOR OPEN_PARENTESIS PUNTO_COMA Expression PUNTO_COMA CLOSE_PARENTESIS Statement
					CodeDOM::XplForStatement*
					fs=CreateFor(NULL/*Init*/,$4.node/*Cond*/,NULL/*Upd*/,$7.node/*Stat*/);
					$$.node=fs;
					SET_SOURCE_DATA(fs,-6,-1);
				}
	|	PC_FOR OPEN_PARENTESIS For_Init PUNTO_COMA PUNTO_COMA CLOSE_PARENTESIS Statement
				{//	PC_FOR OPEN_PARENTESIS For_Init PUNTO_COMA PUNTO_COMA CLOSE_PARENTESIS Statement
					CodeDOM::XplForStatement*
					fs=CreateFor($3.node/*Init*/,NULL/*Cond*/,NULL/*Upd*/,$7.node/*Stat*/);
					$$.node=fs;
					SET_SOURCE_DATA(fs,-6,-1);
				}
	|	PC_FOR OPEN_PARENTESIS PUNTO_COMA PUNTO_COMA For_Update CLOSE_PARENTESIS Statement
				{//	PC_FOR OPEN_PARENTESIS PUNTO_COMA PUNTO_COMA For_Update CLOSE_PARENTESIS Statement
					CodeDOM::XplForStatement*
					fs=CreateFor(NULL/*Init*/,NULL/*Cond*/,$5.node/*Upd*/,$7.node/*Stat*/);
					$$.node=fs;
					SET_SOURCE_DATA(fs,-6,-1);
				}
	|	PC_FOR OPEN_PARENTESIS PUNTO_COMA PUNTO_COMA CLOSE_PARENTESIS Statement
				{//	PC_FOR OPEN_PARENTESIS PUNTO_COMA PUNTO_COMA CLOSE_PARENTESIS Statement
					CodeDOM::XplForStatement*
					fs=CreateFor(NULL/*Init*/,NULL/*Cond*/,NULL/*Upd*/,$6.node/*Stat*/);
					$$.node=fs;
					SET_SOURCE_DATA(fs,-5,-1);
				}
	;

For_Init
	:	Expression_List
				{//	Expression_List
					CodeDOM::XplForinit*f=CodeDOM::XplForStatement::new_init();
					$1.node->set_ElementName(L"el");
					f->set_tforinit($1.node);
					$$.node=f;
				}
	|	Local_Variable_Declaration
				{//	Expression_List
					CodeDOM::XplForinit*f=CodeDOM::XplForStatement::new_init();
					$1.node->set_ElementName(L"dl");
					f->set_tforinit($1.node);
					$$.node=f;
				}
	;

For_Update
	:	Expression_List
				{//	Expression_List
					$$.node=$1.node;
				}
	;

Empty_Statement
	:	PUNTO_COMA
				{//	PUNTO_COMA
					CodeDOM::XplExpression* e=CodeDOM::XplFunctionBody::new_e();
					e->set_texpression(CodeDOM::XplExpression::new_empty());
					$$.node=e;
					SET_SOURCE_DATA_S(e,0);
				}
	;

Labeled_Statement
	:	IDENTIFICADOR OP_DOSPUNTOS Statement
				{//	IDENTIFICADOR OP_DOSPUNTOS Statement
					tempNode=CodeDOM::XplFunctionBody::new_label();
					tempNode->set_Value($1.str);
					$$.node=tempNode;
					$$.nodos[1]=$3.node;
				}
	;


Switch_Statement
	:	PC_SWITCH OPEN_PARENTESIS Expression CLOSE_PARENTESIS Switch_Block
				{//	PC_SWITCH OPEN_PARENTESIS Expression CLOSE_PARENTESIS Switch_Block
					CodeDOM::XplExpression*e=CodeDOM::XplSwitchStatement::new_e();
					e->set_texpression((CodeDOM::XplExpression*)$3.node);
					CodeDOM::XplSwitchStatement*s=new CodeDOM::XplSwitchStatement(e,(CodeDOM::XplNodeList*)$5.node);
					s->set_ElementName(L"switch");
					$$.node=s;
					SET_SOURCE_DATA_S(s,-4);
				}
	|	PC_SWITCH error
				{//	PC_SWITCH error
					SINTAX_ERROR("'switch' statement invalid. Use: switch( expression ) { options } ");
					CodeDOM::XplSwitchStatement*s=new CodeDOM::XplSwitchStatement();
					$$.node=s;
				}
	;

Switch_Block
	:	OPEN_LLAVE Switch_Block_Statement_Groups Switch_Labels CLOSE_LLAVE
				{//	OPEN_LLAVE Switch_Block_Statement_Groups Switch_Labels CLOSE_LLAVE
					$$.node=$2.node;
				}
	|	OPEN_LLAVE Switch_Block_Statement_Groups CLOSE_LLAVE
				{//	OPEN_LLAVE Switch_Block_Statement_Groups CLOSE_LLAVE
					$$.node=$2.node;
				}
	|	OPEN_LLAVE Switch_Labels CLOSE_LLAVE
				{//	OPEN_LLAVE Switch_Labels CLOSE_LLAVE
					$$.node=$2.node;
					WARNING_MESSAGE("'switch' statement without effect.");
				}
	|	OPEN_LLAVE CLOSE_LLAVE
				{//	OPEN_LLAVE CLOSE_LLAVE
					$$.node=NULL;
					WARNING_MESSAGE("'switch' statement empty.");
				}
	;

Switch_Block_Statement_Groups
	:	Switch_Block_Statement_Group
				{//	Switch_Block_Statement_Group
					$$.list=$1.list;
				}
	|	Switch_Block_Statement_Groups Switch_Block_Statement_Group
				{//	Switch_Block_Statement_Groups Switch_Block_Statement_Group
					CodeDOM::XplNodeList*list=$1.list;
					CodeDOM::XplNodeList*list2=$2.list;
					if(list!=NULL && list2!=NULL){
						for(CodeDOM::XplNode* node = list2->FirstNode(); node != list2->GetLastNode() ; node = list2->NextNode()){
							list->InsertAtEnd(node);
						}
						list2->Clear();
						delete list2;
					}
					else{
						WARNING_MESSAGE("Internal error on switch statement");
						list = new CodeDOM::XplNodeList();
					}
					$$.list=list;
				}
	;

Switch_Block_Statement_Group
	:	Switch_Labels Block_Statements
				{//	Switch_Labels Block_Statements
					CodeDOM::XplNodeList*list=$1.list;
					CodeDOM::XplCase*c=NULL;
					if(list!=NULL)
						c=(CodeDOM::XplCase*)list->LastNode();
					else
						c=new CodeDOM::XplCase();
					c->set_bk((CodeDOM::XplFunctionBody*)$2.node);
					$$.list=$1.list;
				}
	;

Switch_Labels
	:	Switch_Label
				{//	Switch_Label
					CodeDOM::XplNodeList*l=NULL;
					l=new CodeDOM::XplNodeList();
					l->InsertAtEnd($1.node);
					$$.list=l;
				}
	|	Switch_Labels Switch_Label
				{//	Switch_Labels Switch_Label
					CodeDOM::XplNodeList*l=$1.list;
					//if(l==NULL)l=NEW_ERROR_RESUME_ZOENODELIST;
					if(l==NULL)l=new CodeDOM::XplNodeList();
					l->InsertAtEnd($2.node);
					$$.list=l;
				}
	;

Switch_Label
	:	PC_CASE Expression OP_DOSPUNTOS
				{//	PC_CASE Expression OP_DOSPUNTOS
					CodeDOM::XplCase*c=CodeDOM::XplSwitchStatement::new_case();
					CodeDOM::XplExpression*e=CodeDOM::XplCase::new_e();
					e->set_texpression((CodeDOM::XplExpression*)$2.node);
					c->set_e(e);
					$$.node=c;
					SET_SOURCE_DATA_S(c,-2);
				}
	|	PC_DEFAULT OP_DOSPUNTOS
				{//	PC_DEFAULT OP_DOSPUNTOS
					CodeDOM::XplCase*c=CodeDOM::XplSwitchStatement::new_case();
					c->set_e((CodeDOM::XplExpression*)CodeDOM::XplFunctionBody::new_e());
					c->get_e()->set_texpression(CodeDOM::XplExpression::new_empty());
					$$.node=c;
					SET_SOURCE_DATA_S(c,-1);
				}
	;

Break_Statement
	:	PC_BREAK IDENTIFICADOR PUNTO_COMA
				{//	PC_BREAK Label PUNTO_COMA
					CodeDOM::XplJump* j=CodeDOM::XplFunctionBody::new_jump();
					j->set_type(CodeDOM::ZOEJUMPTYPE_ENUM_BREAK);
					j->set_label($2.str);
					$$.node=j;
					SET_SOURCE_DATA_S(j,-2);
				}
	|	PC_BREAK PUNTO_COMA
				{//	PC_BREAK PUNTO_COMA
					CodeDOM::XplJump* j=CodeDOM::XplFunctionBody::new_jump();
					j->set_type(CodeDOM::ZOEJUMPTYPE_ENUM_BREAK);
					$$.node=j;
					SET_SOURCE_DATA_S(j,-1);
				}
	;

Continue_Statement
	:	PC_CONTINUE IDENTIFICADOR PUNTO_COMA
				{//	PC_CONTINUE Label PUNTO_COMA
					CodeDOM::XplJump* j=CodeDOM::XplFunctionBody::new_jump();
					j->set_type(CodeDOM::ZOEJUMPTYPE_ENUM_CONTINUE);
					j->set_label($2.str);
					$$.node=j;
					SET_SOURCE_DATA_S(j,-2);
				}
	|	PC_CONTINUE PUNTO_COMA
				{//	PC_CONTINUE PUNTO_COMA
					CodeDOM::XplJump* j=CodeDOM::XplFunctionBody::new_jump();
					j->set_type(CodeDOM::ZOEJUMPTYPE_ENUM_CONTINUE);
					$$.node=j;
					SET_SOURCE_DATA_S(j,-1);
				}
	;

Return_Statement
	:	PC_RETURN Expression PUNTO_COMA
				{//	PC_RETURN Expression PUNTO_COMA
					CodeDOM::XplExpression* re=CodeDOM::XplFunctionBody::new_return();
					re->set_texpression($2.node);
					$$.node=re;
					SET_SOURCE_DATA(re,-2,0);
				}
	|	PC_RETURN PUNTO_COMA
				{//	PC_RETURN PUNTO_COMA
					CodeDOM::XplExpression* re=CodeDOM::XplFunctionBody::new_return();
					$$.node=re;
					SET_SOURCE_DATA_S(re,-1);
				}
	;

Throw_Statement
	:	PC_THROW PUNTO_COMA
				{//	PC_THROW PUNTO_COMA
					CodeDOM::XplExpression *t=CodeDOM::XplFunctionBody::new_throw();
					t->set_texpression(CodeDOM::XplExpression::new_empty());
					$$.node=t;
					SET_SOURCE_DATA(t,-1,0);
				}
	|	PC_THROW Expression PUNTO_COMA
				{//	PC_THROW Expression PUNTO_COMA
					CodeDOM::XplExpression *t=CodeDOM::XplFunctionBody::new_throw();
					t->set_texpression((CodeDOM::XplExpression*)$2.node);
					$$.node=t;
					SET_SOURCE_DATA(t,-2,0);
				}
	|	PC_THROW error
				{//	PC_THROW error
					SINTAX_ERROR("'throw' statement invalid. After 'throw' an expression is required.");
					CodeDOM::XplExpression *t=CodeDOM::XplFunctionBody::new_throw();
					t->set_texpression(CodeDOM::XplExpression::new_empty());
					$$.node=t;
				}
	;

Try_Statement
	:	PC_TRY Block Catches
				{//	PC_TRY Block Catches
					CodeDOM::XplTryStatement*tr=(CodeDOM::XplTryStatement*)$3.node;
					tr->set_trybk((CodeDOM::XplFunctionBody*)$2.node);
					$$.node=tr;
					SET_SOURCE_DATA_S(tr,-2);
				}
	|	PC_TRY Block Catches Finally
				{//	PC_TRY Block Catches Finally
					CodeDOM::XplTryStatement*tr=(CodeDOM::XplTryStatement*)$3.node;
					tr->set_trybk((CodeDOM::XplFunctionBody*)$2.node);
					tr->set_finallybk((CodeDOM::XplFunctionBody*)$4.node);
					$$.node=tr;
					SET_SOURCE_DATA_S(tr,-3);
				}
	|	PC_TRY Block Finally
				{//	PC_TRY Block Finally
					CodeDOM::XplTryStatement*tr=CodeDOM::XplFunctionBody::new_try();
					tr->set_trybk((CodeDOM::XplFunctionBody*)$2.node);
					tr->set_finallybk((CodeDOM::XplFunctionBody*)$3.node);
					$$.node=tr;
					SET_SOURCE_DATA_S(tr,-2);
				}
	|	PC_TRY	error
				{//	PC_TRY	error
					SINTAX_ERROR("'try' statement invalid.");
					CodeDOM::XplTryStatement*tr=CodeDOM::XplFunctionBody::new_try();
					$$.node=tr;
				}
	;

Catches
	:	Catch_Clause
				{//	Catch_Clause
					CodeDOM::XplTryStatement*tr=CodeDOM::XplFunctionBody::new_try();
					tr->get_catchbk()->InsertAtEnd($1.node);
					$$.node=tr;
				}
	|	Catches Catch_Clause
				{//	Catches Catch_Clause
					CodeDOM::XplTryStatement*tr=(CodeDOM::XplTryStatement*)$1.node;
					tr->get_catchbk()->InsertAtEnd($2.node);
					$$.node=tr;
				}
	;

Catch_Clause
	:	PC_CATCH OPEN_PARENTESIS For_Init CLOSE_PARENTESIS Block
				{//	PC_CATCH OPEN_PARENTESIS For_Init CLOSE_PARENTESIS Block
					CodeDOM::XplCatchinit*ci=CodeDOM::XplCatchStatement::new_init();
					SET_SOURCE_DATA_S(ci,-4);

					CodeDOM::XplForinit*f=(CodeDOM::XplForinit*)$3.node;
					//Primero veo que clase de nodo devuelve For_Init
					if(f->get_tforinit()->get_TypeName()==CodeDOM::CODEDOMTYPES_ZOEEXPRESSIONLIST){
						ci->set_tcatchinit(((CodeDOM::XplExpressionlist*)f->get_tforinit())->Childs()->FirstNode());
						if(((CodeDOM::XplExpressionlist*)f->get_tforinit())->Childs()->getLenght()>1){
							SINTAX_ERROR("Can't use more than one expression inside a catch block initializer.");
						}
					}
					else if(f->get_tforinit()->get_TypeName()==CodeDOM::CODEDOMTYPES_ZOEDECLARATORLIST){
						ci->set_tcatchinit(((CodeDOM::XplDeclaratorlist*)f->get_tforinit())->Childs()->FirstNode());
						if(((CodeDOM::XplDeclaratorlist*)f->get_tforinit())->Childs()->getLenght()>1){
							SINTAX_ERROR("Can't use more than one declaration inside a catch block initializer.");
						}
					}
					else{
						SINTAX_ERROR("Internal Meta D++ compiler error.");
					}

					CodeDOM::XplCatchStatement*c=CodeDOM::XplTryStatement::new_catchbk();
					c->set_init(ci);
					c->set_bk((CodeDOM::XplFunctionBody*)$5.node);
					$$.node=c;
				}
	|	PC_CATCH error
				{//	PC_CATCH error
					SINTAX_ERROR("'catch' statement invalid.");
					CodeDOM::XplCatchStatement*c=CodeDOM::XplTryStatement::new_catchbk();
					$$.node=c;
				}

	;

Finally
	:	PC_FINALLY Block
				{//	PC_FINALLY Block
					$$.node=$2.node;
				}
	;

/****************************************************
	SECCION: EXPRESIONES
*****************************************************/
Constant_Expression
	:	Expression {$$=$1;}
	;

Expression_List
	:	Expression
				{//	Expression
					CodeDOM::XplExpressionlist *el=new CodeDOM::XplExpressionlist();
					CodeDOM::XplExpression *e=el->new_e();
					e->set_texpression($1.node);
					el->set_ElementName(L"params");
					el->Childs()->InsertAtEnd(e);
					$$.node=el;
				}
	|	Expression_List COMA Expression
				{//	Expression_List COMA Expression
					CodeDOM::XplExpressionlist *el=(CodeDOM::XplExpressionlist*)$1.node;
					if(el==NULL){
						SINTAX_ERROR("invalid expression list.");
						el = new CodeDOM::XplExpressionlist();
					}
					CodeDOM::XplExpression *e=el->new_e();
					e->set_texpression($3.node);
					el->Childs()->InsertAtEnd(e);
					$$.node=el;
				}
	|	Expression_List error
				{
					SINTAX_ERROR("invalid expression list.");
					$$.node=new CodeDOM::XplExpressionlist();
				}
	|	Expression_List COMA error
				{
					SINTAX_ERROR("invalid expression list after comma.");
					$$.node=new CodeDOM::XplExpressionlist();
				}
	;


Parenthesized_Exp
	:	OPEN_PARENTESIS Expression CLOSE_PARENTESIS
				{//	OPEN_PARENTESIS Expression CLOSE_PARENTESIS
					$$=$2;
				}
	;

Complex_Expression_List
	:	Expression_Or_Punctuactor
				{//	Expression_Or_Punctuactor
					CodeDOM::XplCexpression *ce=CodeDOM::XplComplexfunctioncall::new_ce();
					ce->Childs()->InsertAtEnd($1.node);
					$$.node=ce;
				}
	|	Complex_Expression_List  Expression_Or_Punctuactor
				{//	Complex_Expression_List  Expression_Or_Punctuactor
					CodeDOM::XplCexpression *ce=(CodeDOM::XplCexpression*)$1.node;
					ce->Childs()->InsertAtEnd($2.node);
					$$.node=ce;
				}
	;

Expression_Or_Punctuactor
	:	Expression_List
				{//	Expression_List
					$1.node->set_ElementName(DT("l"));
					$$.node=$1.node;
				}
	|	PUNTO_COMA
				{//	PUNTO_COMA
					$$.node=CodeDOM::XplCexpression::new_ls();
				}
	|	OP_DOSPUNTOS
				{//	OP_DOSPUNTOS
					$$.node=CodeDOM::XplCexpression::new_lp();
				}
	;

Expression
	:	Argument_Exp {$$=$1;}
	;

Argument_Exp
	:	Assingment_Exp	{$$=$1;}
	|	Assingment_Exp OP_IGUALMAYOR Argument_Exp
				{//	Assingment_Exp OP_IGUALMAYOR Argument_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);
					temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);
					temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_IMP, false,temp,temp2);
					tempNode->set_ElementName(DT("bo"));
					$$.node=tempNode;
				}
	;

Assingment_Exp
	:	Conditional_Exp {$$=$1;}
	|	Unary_Exp Assing_Operator Assingment_Exp
				{//	Unary_Exp Assing_Operator Assingment_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					CodeDOM::XplAssingop_enum oper;
					switch($2.num){
						case OP_IGUAL:oper=CodeDOM::ZOEASSINGOP_ENUM_NONE;break;
						case OP_MASIGUAL:oper=CodeDOM::ZOEASSINGOP_ENUM_ADD;break;
						case OP_MENOSIGUAL:oper=CodeDOM::ZOEASSINGOP_ENUM_SUB;break;
						case OP_ASTERISCOIGUAL:oper=CodeDOM::ZOEASSINGOP_ENUM_MUL;break;
						case OP_DIVIDIDOIGUAL:oper=CodeDOM::ZOEASSINGOP_ENUM_DIV;break;
						case OP_YIGUAL:oper=CodeDOM::ZOEASSINGOP_ENUM_AND;break;
						case OP_OIGUAL:oper=CodeDOM::ZOEASSINGOP_ENUM_OR;break;
						case OP_SOMBREROIGUAL:oper=CodeDOM::ZOEASSINGOP_ENUM_XOR;break;
						case OP_PORCENTAJEIGUAL:oper=CodeDOM::ZOEASSINGOP_ENUM_MOD;break;
						case OP_SHIFTLEFTIGUAL:oper=CodeDOM::ZOEASSINGOP_ENUM_LSH;break;
						case OP_SHIFTRIGHTIGUAL:oper=CodeDOM::ZOEASSINGOP_ENUM_RSH;break;
						default:oper=CodeDOM::ZOEASSINGOP_ENUM_NONE;break;
					};
					CodeDOM::XplAssing* tempNode=new CodeDOM::XplAssing(oper,false,temp,temp2);
					tempNode->set_ElementName(L"a");
					$$.node=tempNode;
				}
	;

Conditional_Exp
	:	Logical_OR_Exp {$$=$1;}
	|	Logical_OR_Exp OP_PREGUNTA Expression OP_DOSPUNTOS Conditional_Exp
				{//	Logical_OR_Exp OP_PREGUNTA Expression OP_DOSPUNTOS Conditional_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("o1"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("o2"));
					CodeDOM::XplExpression *temp3=new CodeDOM::XplExpression($5.node);temp2->set_ElementName(DT("o3"));

					tempNode=new CodeDOM::XplTernaryoperator(CodeDOM::ZOETERNARYOPERATORS_ENUM_BOOLEAN,false,temp,temp2,temp3);
					tempNode->set_ElementName(L"to");
					$$.node=tempNode;
				}
	;

Logical_OR_Exp
	:	Logical_AND_Exp {$$=$1;}
	|	Logical_OR_Exp OP_OO Logical_AND_Exp
				{//	Logical_OR_Exp OP_OO Logical_AND_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_OR,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	;

Logical_AND_Exp
	:	Inclusive_OR_Exp {$$=$1;}
	|	Logical_AND_Exp OP_YY Inclusive_OR_Exp
				{//	Logical_AND_Exp OP_YY Inclusive_OR_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_AND,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	;

Inclusive_OR_Exp
	:	Exclusive_OR_Exp {$$=$1;}
	|	Inclusive_OR_Exp OP_O Exclusive_OR_Exp
				{//	Inclusive_OR_Exp OP_O Exclusive_OR_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_BOR,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	;

Exclusive_OR_Exp
	:	And_Expression {$$=$1;}
	|	Exclusive_OR_Exp OP_SOMBRERO And_Expression
				{//	Exclusive_OR_Exp OP_SOMBRERO And_Expression
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_XOR,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	;

And_Expression
	:	Equality_Exp {$$=$1;}
	|	And_Expression OP_Y Equality_Exp
				{//	And_Expression OP_Y Equality_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_BAND,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	;

Equality_Exp
	:	Relational_Exp {$$=$1;}
	|	Equality_Exp OP_IGUALIGUAL Relational_Exp
				{//	Equality_Exp OP_IGUALIGUAL Relational_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_EQ,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	|	Equality_Exp OP_ADMIRACIONIGUAL Relational_Exp
				{//	Equality_Exp OP_ADMIRACIONIGUAL Relational_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_NOTEQ,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	;

Relational_Exp
	:	Shift_Exp {$$=$1;}
	|	Relational_Exp OP_MENOR Shift_Exp
				{//	Relational_Exp OP_MENOR Shift_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_LS,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}

	|	Relational_Exp OP_MAYOR Shift_Exp
				{//	Relational_Exp OP_MAYOR Shift_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_GR,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	|	Relational_Exp OP_MENORIGUAL Shift_Exp
				{//	Relational_Exp OP_MENORIGUAL Shift_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_LSEQ,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	|	Relational_Exp OP_MAYORIGUAL Shift_Exp
				{//	Relational_Exp OP_MAYORIGUAL Shift_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_GREQ,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	|	Relational_Exp PC_IS Type_Declarator 
				{//	Cast_Exp PC_IS Type_Declarator 
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);
					tempNode=new CodeDOM::XplCastexpression(temp,(CodeDOM::XplType*)$3.node);
					tempNode->set_ElementName(L"is");
					$$.node=tempNode;
				}
	;

Shift_Exp
	:	Additive_Exp {$$=$1;}
	|	Shift_Exp OP_SHIFTLEFT Additive_Exp
				{//	Shift_Exp OP_SHIFTLEFT Additive_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_LSH,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	|	Shift_Exp OP_SHIFTRIGHT Additive_Exp
				{//	Shift_Exp OP_SHIFTRIGHT Additive_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_RSH,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	;

Additive_Exp
	:	Multiplicative_Exp {$$=$1;}
	|	Additive_Exp OP_MAS Multiplicative_Exp
				{//	Additive_Exp OP_MAS Multiplicative_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_ADD,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	|	Additive_Exp OP_MENOS Multiplicative_Exp
				{//	Additive_Exp OP_MENOS Multiplicative_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_MIN,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	;

Multiplicative_Exp
	:	PM_Access_Exp {$$=$1;}
	|	Multiplicative_Exp OP_ASTERISCO PM_Access_Exp
				{//	Multiplicative_Exp OP_ASTERISCO PM_Access_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_MUL,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	|	Multiplicative_Exp OP_DIVIDIDO PM_Access_Exp
				{//	Multiplicative_Exp OP_DIVIDIDO PM_Access_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_DIV,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	|	Multiplicative_Exp OP_PORCENTAJE PM_Access_Exp
				{//	Multiplicative_Exp OP_PORCENTAJE PM_Access_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_MOD,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	;

PM_Access_Exp
	:	Cast_Exp {$$=$1;}
	|	PM_Access_Exp OP_PUNTOASTERISCO Cast_Exp
				{//	PM_Access_Exp OP_PUNTOASTERISCO Cast_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_MP,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	|	PM_Access_Exp OP_MENOSMAYORASTERISCO Cast_Exp
				{//	PM_Access_Exp OP_MENOSMAYORASTERISCO Cast_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($1.node);temp->set_ElementName(DT("l"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression($3.node);temp2->set_ElementName(DT("r"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_PMP,false,temp,temp2);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	;

Cast_Exp
	:	Unary_Exp {$$=$1;}
	|	OPEN_PARENTESIS Type_Declarator CLOSE_PARENTESIS Cast_Exp
				{//	OPEN_PARENTESIS Type_Name CLOSE_PARENTESIS Cast_Exp
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression($4.node);
					tempNode=new CodeDOM::XplCastexpression(temp,(CodeDOM::XplType*)$2.node);
					tempNode->set_ElementName(L"cast");
					$$.node=tempNode;
				}
	;

Unary_Exp
	:	Postfix_Exp {$$=$1;}
	|	OP_MASMAS Unary_Exp
				{//	OP_MASMAS Unary_Exp
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression();
					temp2->set_texpression($2.node);temp2->set_ElementName(L"u");
					tempNode=new CodeDOM::XplUnaryoperator(CodeDOM::ZOEUNARYOPERATORS_ENUM_PREINC , false, temp2);
					tempNode->set_ElementName(L"uo");
					$$.node=tempNode;
				}
	|	OP_MENOSMENOS Unary_Exp
				{//	OP_MENOSMENOS Unary_Exp
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression();
					temp2->set_texpression($2.node);temp2->set_ElementName(L"u");
					tempNode=new CodeDOM::XplUnaryoperator(CodeDOM::ZOEUNARYOPERATORS_ENUM_PREDEC , false,temp2);
					tempNode->set_ElementName(L"uo");
					$$.node=tempNode;
				}
	|	Unary_Operator Cast_Exp
				{//	Unary_Operator Cast_Exp
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression();
					temp2->set_texpression($2.node);temp2->set_ElementName(L"u");
					CodeDOM::XplUnaryoperators_enum oper=CodeDOM::ZOEUNARYOPERATORS_ENUM_MIN;
					switch($1.num){
						case OP_MENOS:oper=CodeDOM::ZOEUNARYOPERATORS_ENUM_MIN;break;
						case OP_ADMIRACION:oper=CodeDOM::ZOEUNARYOPERATORS_ENUM_NOT;break;
						case OP_Y:oper=CodeDOM::ZOEUNARYOPERATORS_ENUM_AOF;break;
						case OP_ASTERISCO:oper=CodeDOM::ZOEUNARYOPERATORS_ENUM_IND;break;
						case OP_CELDILLA:oper=CodeDOM::ZOEUNARYOPERATORS_ENUM_ONECOMP;break;
					};
					tempNode=new CodeDOM::XplUnaryoperator(oper, false,temp2);
					tempNode->set_ElementName(L"uo");
					$$.node=tempNode;
				}
	|	PC_SIZEOF OPEN_PARENTESIS Unary_Exp CLOSE_PARENTESIS
				{//	PC_SIZEOF Unary_Exp
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression();
					temp2->set_texpression($3.node);temp2->set_ElementName(L"u");
					tempNode=new CodeDOM::XplUnaryoperator(CodeDOM::ZOEUNARYOPERATORS_ENUM_SIZEOF, false ,temp2);
					tempNode->set_ElementName(L"uo");
					$$.node=tempNode;
				}
	|	PC_SIZEOF OPEN_PARENTESIS Type_Declarator CLOSE_PARENTESIS
				{//	PC_SIZEOF OPEN_PARENTESIS R_Type_Decl CLOSE_PARENTESIS
					WARNING_MESSAGE("Internal: sizeof expression for types not implemented.");
					$$.node=CodeDOM::XplExpression::new_empty();
				}
	|	Deallocation_Exp {$$=$1;}
	|	PC_GETTYPE OPEN_PARENTESIS Type_Declarator CLOSE_PARENTESIS
				{//	PC_GETTYPE OPEN_PARENTESIS R_Type_Decl CLOSE_PARENTESIS
					CodeDOM::XplType *type = (CodeDOM::XplType*)$3.node;
					type->set_ElementName(L"t");
					$$.node=type;
				}
	|	PC_TYPEOF OPEN_PARENTESIS Expression CLOSE_PARENTESIS
				{//	PC_TYPEOF OPEN_PARENTESIS Expression CLOSE_PARENTESIS
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression();
					temp2->set_texpression($3.node);temp2->set_ElementName(L"u");
					tempNode=new CodeDOM::XplUnaryoperator(CodeDOM::ZOEUNARYOPERATORS_ENUM_TYPEOF, false ,temp2);
					tempNode->set_ElementName(L"uo");
					$$.node=tempNode;
				}
	|	PC_TYPEOF OPEN_PARENTESIS Type_Declarator CLOSE_PARENTESIS
				{//	PC_GETTYPE OPEN_PARENTESIS R_Type_Decl CLOSE_PARENTESIS
					CodeDOM::XplType *type = (CodeDOM::XplType*)$3.node;
					type->set_ElementName(L"toft");
					$$.node=type;
				}
	;

Writecode_Expression
	:	PC_WRITECODE WC_Block 
				{//	PC_WRITECODE WC_Block
					CodeDOM::XplWriteCodeBody*wb=CodeDOM::XplExpression::new_writecode();
					wb->set_tWriteCodeBody($2.node);
					$$.node=wb;
					SET_SOURCE_DATA_S(wb,-1);
				}
	|	PC_WRITECODE OPEN_PARENTESIS Expression CLOSE_PARENTESIS 
				{//	PC_WRITECODE OPEN_PARENTESIS Expression CLOSE_PARENTESIS PUNTO_COMA
					CodeDOM::XplWriteCodeBody*wb=CodeDOM::XplExpression::new_writecode();
					CodeDOM::XplExpression*e=CodeDOM::XplWriteCodeBody::new_e();
					e->set_texpression($3.node);
					wb->set_tWriteCodeBody(e);
					$$.node=wb;
					SET_SOURCE_DATA_S(wb,-3);
				}
	|	PC_WRITECODE WC_Block2
				{//	PC_WRITECODE WC_Block
					CodeDOM::XplWriteCodeBody*wb=CodeDOM::XplExpression::new_writecode();
					wb->set_tWriteCodeBody($2.node);
					$$.node=wb;
					SET_SOURCE_DATA_S(wb,-1);
				}
	|	PC_WRITECODE error 
				{//	PC_WRITECODE error
					SINTAX_ERROR("'writecode' expression invalid.");
					CodeDOM::XplWriteCodeBody*wb=CodeDOM::XplExpression::new_writecode();
					$$.node=wb;
				}
	;

Postfix_Exp
	:	Primary_Exp {$$=$1;}
	|	Writecode_Expression
				{
					$$.node=$1.node;
				}
	|	Postfix_Exp OPEN_PARENTESIS OP_COMILLA Complex_Expression_List OP_COMILLA CLOSE_PARENTESIS
				{
					CodeDOM::XplComplexfunctioncall *cfc=CodeDOM::XplExpression::new_cfc();
					CodeDOM::XplExpression*leftExp=CodeDOM::XplComplexfunctioncall::new_l();
					leftExp->set_texpression($1.node);
					cfc->set_l(leftExp);
					cfc->set_ce((CodeDOM::XplCexpression*)$4.node);
					$$.node=cfc;
				}
	|	Postfix_Exp OPEN_CORCHETE Expression_List CLOSE_CORCHETE
				{//	Postfix_Exp OPEN_CORCHETE Expression_List CLOSE_CORCHETE
					CodeDOM::XplExpression *temp2=CodeDOM::XplFunctioncall::new_l();
					temp2->set_texpression($1.node);
					CodeDOM::XplFunctioncall *br=new CodeDOM::XplFunctioncall(temp2,(CodeDOM::XplExpressionlist*)$3.node,NULL);
					br->set_ElementName(L"b");
					tempNode=br;
					$$.node=tempNode;
				}
	|	Postfix_Exp OPEN_PARENTESIS Expression_List CLOSE_PARENTESIS
				{//	Postfix_Exp OPEN_PARENTESIS Expression_List CLOSE_PARENTESIS
					CodeDOM::XplExpression *temp2=CodeDOM::XplFunctioncall::new_l();
					temp2->set_texpression($1.node);
					CodeDOM::XplFunctioncall *fc=new CodeDOM::XplFunctioncall();
					fc->set_ElementName(L"fc");
					fc->set_l(temp2);
					fc->set_args((CodeDOM::XplExpressionlist*)$3.node);
					tempNode=fc;
					$$.node=tempNode;
				}
	|	Postfix_Exp OPEN_PARENTESIS CLOSE_PARENTESIS
				{//	Postfix_Exp OPEN_PARENTESIS CLOSE_PARENTESIS
					CodeDOM::XplExpression *temp2=CodeDOM::XplFunctioncall::new_l();
					temp2->set_texpression($1.node);
					CodeDOM::XplFunctioncall *fc=new CodeDOM::XplFunctioncall();
					fc->set_ElementName(L"fc");
					fc->set_l(temp2);
					fc->set_args(CodeDOM::XplFunctioncall::new_args());
					tempNode=fc;
					$$.node=tempNode;
				}
	|	Postfix_Exp Block
				{//	Postfix_Exp Block
					CodeDOM::XplNode *postfix=$1.node;
					CodeDOM::XplFunctioncall *fc = NULL ;

					if(postfix==NULL){
						SINTAX_ERROR("Invalid postfix expression.");
						break;
					}
					if(postfix->get_ElementName()==L"fc"){
						fc=(CodeDOM::XplFunctioncall*)postfix;
						//postfix->set_texpression(NULL);
						//delete postfix;
					}
					else{
						fc = new CodeDOM::XplFunctioncall();
						CodeDOM::XplExpression *temp2=CodeDOM::XplFunctioncall::new_l();
						temp2->set_texpression($1.node);
						fc->set_ElementName(L"fc");
						fc->set_l(temp2);
						fc->set_args(NULL);
					}
					fc->set_bk((CodeDOM::XplFunctionBody*)$2.node);
					tempNode=fc;
					$$.node=tempNode;
				}
	|	Postfix_Exp PUNTO Complete_Class_Name
				{//	Postfix_Exp PUNTO Complete_Class_Name
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression();
					temp->set_texpression(temp->new_n());
					temp->get_texpression()->set_Value($3.str);
					temp->set_ElementName(DT("r"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression();
					temp2->set_texpression($1.node);
					temp2->set_ElementName(DT("l"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_M,false,temp2,temp);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	|	Postfix_Exp OP_MENOSMAYOR Complete_Class_Name
				{//	Postfix_Exp OP_MENOSMAYOR IDENTIFICADOR
					CodeDOM::XplExpression *temp=new CodeDOM::XplExpression();
					temp->set_texpression(temp->new_n());
					temp->get_texpression()->set_Value($3.str);
					temp->set_ElementName(DT("r"));
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression();
					temp2->set_texpression($1.node);
					temp2->set_ElementName(DT("l"));
					tempNode=new CodeDOM::XplBinaryoperator(CodeDOM::ZOEBINARYOPERATORS_ENUM_PM,false,temp2,temp);
					tempNode->set_ElementName(L"bo");
					$$.node=tempNode;
				}
	|	Postfix_Exp OP_MASMAS
				{//	Postfix_Exp OP_MASMAS
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression();
					temp2->set_texpression($1.node);
					temp2->set_ElementName(L"u");
					tempNode=new CodeDOM::XplUnaryoperator(CodeDOM::ZOEUNARYOPERATORS_ENUM_INC, false ,temp2);
					tempNode->set_ElementName(L"uo");
					$$.node=tempNode;
				}
	|	Postfix_Exp OP_MENOSMENOS
				{//	Postfix_Exp OP_MENOSMENOS
					CodeDOM::XplExpression *temp2=new CodeDOM::XplExpression();
					temp2->set_texpression($1.node);
					temp2->set_ElementName(L"u");
					tempNode=new CodeDOM::XplUnaryoperator(CodeDOM::ZOEUNARYOPERATORS_ENUM_DEC, false ,temp2);
					tempNode->set_ElementName(L"uo");
					$$.node=tempNode;
				}
	;

Allocation_Exp
	:	PC_NEW New_Placement Type_Declarator Initializer
				{//	PC_NEW New_Placement Type_Declarator Initializer
					CodeDOM::XplType* t=(CodeDOM::XplType*)$3.nodos[0];
					t->set_ElementName(DT("type"));
					CodeDOM::XplNewExpression* ne=CodeDOM::XplExpression::new_new();
					ne->set_type(t);
					SetNewTypeModifiers(ne,(unsigned)$3.nodos[1]);
					ne->set_GCParams((CodeDOM::XplExpressionlist*)$2.node);
					ne->set_init((CodeDOM::XplInitializerList*)$4.node);
					$$.node=ne;
				}
	|	PC_NEW Type_Declarator Initializer
				{//	PC_NEW Type_Declarator Initializer
					CodeDOM::XplType* t=(CodeDOM::XplType*)$2.nodos[0];
					t->set_ElementName(DT("type"));
					CodeDOM::XplNewExpression* ne=CodeDOM::XplExpression::new_new();
					ne->set_type(t);
					SetNewTypeModifiers(ne,(unsigned)$2.nodos[1]);
					ne->set_init((CodeDOM::XplInitializerList*)$3.node);
					$$.node=ne;
				}
	|	PC_NEW New_Placement Type_Declarator 
				{//	PC_NEW New_Placement Type_Declarator 
					CodeDOM::XplType* t=(CodeDOM::XplType*)$3.nodos[0];
					t->set_ElementName(DT("type"));
					CodeDOM::XplNewExpression* ne=CodeDOM::XplExpression::new_new();
					ne->set_type(t);
					SetNewTypeModifiers(ne,(unsigned)$3.nodos[1]);
					ne->set_GCParams((CodeDOM::XplExpressionlist*)$2.node);
					$$.node=ne;
				}
	|	PC_NEW Type_Declarator 
				{//	PC_NEW Type_Declarator 
					CodeDOM::XplType* t=(CodeDOM::XplType*)$2.nodos[0];
					t->set_ElementName(DT("type"));
					CodeDOM::XplNewExpression* ne=CodeDOM::XplExpression::new_new();
					ne->set_type(t);
					SetNewTypeModifiers(ne,(unsigned)$2.nodos[1]);
					$$.node=ne;
				}
	/*REPETIDOS PARA SOPORTAR new T() sin tener un inicializador T()*/
	|	PC_NEW New_Placement Type_Declarator OPEN_PARENTESIS CLOSE_PARENTESIS
				{//	PC_NEW New_Placement Type_Declarator 
					CodeDOM::XplType* t=(CodeDOM::XplType*)$3.nodos[0];
					t->set_ElementName(DT("type"));
					CodeDOM::XplNewExpression* ne=CodeDOM::XplExpression::new_new();
					ne->set_type(t);
					SetNewTypeModifiers(ne,(unsigned)$3.nodos[1]);
					ne->set_GCParams((CodeDOM::XplExpressionlist*)$2.node);
					$$.node=ne;
				}
	|	PC_NEW Type_Declarator OPEN_PARENTESIS CLOSE_PARENTESIS
				{//	PC_NEW Type_Declarator 
					CodeDOM::XplType* t=(CodeDOM::XplType*)$2.nodos[0];
					t->set_ElementName(DT("type"));
					CodeDOM::XplNewExpression* ne=CodeDOM::XplExpression::new_new();
					ne->set_type(t);
					SetNewTypeModifiers(ne,(unsigned)$2.nodos[1]);
					$$.node=ne;
				}
	;

New_Placement
	:	OPEN_PARENTESIS Expression_List CLOSE_PARENTESIS	{$$.node=$2.node;}
	;

Deallocation_Exp
	:	PC_DELETE Cast_Exp
				{//	PC_DELETE Cast_Exp
					CodeDOM::XplExpression*de=CodeDOM::XplExpression::new_delete();
					de->set_texpression($2.node);
					$$.node=de;
				}
	;

Primary_Exp
	:	Literal
				{//	Literal
					$1.literal->set_ElementName(L"lit");
					$$.node=$1.literal;
				}
	|	Allocation_Exp {$$=$1;}
/*	|	OP_DOSPUNTOSDOBLE Complete_Class_Name
				{//	OP_DOSPUNTOSDOBLE Complete_Class_Name
					tempNode=new CodeDOM::XplNode(CodeDOM::ZOENODETYPE_STRING);
					tempNode->set_ElementName(L"n");
					tempNode->set_Value($2.str);
					WARNING_MESSAGE("Interno: no se esta guardando los :: modificadores de acceso global.");
					$$.node=tempNode;
				}*/
	|	Complete_Class_Name
				{//	Complete_Class_Name
					tempNode=new CodeDOM::XplNode(CodeDOM::ZOENODETYPE_STRING);
					tempNode->set_ElementName(L"n");
					tempNode->set_Value($1.str);
					$$.node=tempNode;
				}
	|	Parenthesized_Exp {$$=$1;}
	;

Simple_Type_Name
    :   Simple_Type_Name_Word   {$$=$1;RET_POS=GET_PARSER_POS[0];}
    |   Simple_Type_Name_Word Simple_Type_Name_Word
                 {
					RET_POS=GET_PARSER_POS[0];
					unsigned check=0;
                    if($1.num==PC_UNSIGNED)check=$2.num;
                    else if($2.num==PC_UNSIGNED){
                        check=$2.num;
                        WARNING_MESSAGE("It's recommended to use 'unsigned T' instead of 'T unsigned'.");
                    }
                    else{
                        SINTAX_ERROR("Invalid combination of base types.");
                    }
                    switch(check){
                        case PC_SBYTE:$$.num=PC_BYTE;break;
                        case PC_SHORT:$$.num=PC_USHORT;break;
                        case PC_INT:$$.num=PC_UINT;break;
                        case PC_LONG:$$.num=PC_ULONG;break;
                        default:$$.num=PC_INT;SINTAX_ERROR("Invalid combination of base types.");break;
                    };
                 }
    ;

Simple_Type_Name_Word
	:	PC_VOID         {$$.num=PC_VOID;RET_POS=GET_PARSER_POS[0];}
	|   PC_SBYTE        {$$.num=PC_SBYTE;RET_POS=GET_PARSER_POS[0];}
	|	PC_SHORT        {$$.num=PC_SHORT;RET_POS=GET_PARSER_POS[0];}
	|	PC_INT          {$$.num=PC_INT;RET_POS=GET_PARSER_POS[0];}
	|	PC_LONG         {$$.num=PC_LONG;RET_POS=GET_PARSER_POS[0];}
	|	PC_UNSIGNED     {$$.num=PC_UNSIGNED;RET_POS=GET_PARSER_POS[0];}
	|   PC_BYTE         {$$.num=PC_BYTE;RET_POS=GET_PARSER_POS[0];}
	|   PC_USHORT       {$$.num=PC_USHORT;RET_POS=GET_PARSER_POS[0];}
	|   PC_ULONG        {$$.num=PC_ULONG;RET_POS=GET_PARSER_POS[0];}
	|	PC_FLOAT        {$$.num=PC_FLOAT;RET_POS=GET_PARSER_POS[0];}
	|	PC_DOUBLE       {$$.num=PC_DOUBLE;RET_POS=GET_PARSER_POS[0];}
	|   PC_DECIMAL      {$$.num=PC_DECIMAL;RET_POS=GET_PARSER_POS[0];}
	|	PC_CHAR         {$$.num=PC_CHAR;RET_POS=GET_PARSER_POS[0];}
	|	PC_ASCII_CHAR   {$$.num=PC_ASCII_CHAR;RET_POS=GET_PARSER_POS[0];}
	|	PC_STRING       {$$.num=PC_STRING;RET_POS=GET_PARSER_POS[0];}
	|	PC_ASCII_STRING {$$.num=PC_ASCII_STRING;RET_POS=GET_PARSER_POS[0];}
	|	PC_TYPE         {$$.num=PC_TYPE;RET_POS=GET_PARSER_POS[0];}
	|	PC_BLOCK        {$$.num=PC_BLOCK;RET_POS=GET_PARSER_POS[0];}
	|   PC_BOOL         {$$.num=PC_BOOL;RET_POS=GET_PARSER_POS[0];}
	|	PC_OBJECT		{$$.num=PC_OBJECT;RET_POS=GET_PARSER_POS[0];}
	;

Literal
	:	STRING_LITERAL          {$$=$1;}
	|	CHARACTER_LITERAL       {$$=$1;}
	|	BOOLEAN_LITERAL_TRUE    {$$=$1;}
	|	BOOLEAN_LITERAL_FALSE   {$$=$1;}
	|	INTEGER_LITERAL         {$$=$1;}
	|	FLOAT_LITERAL           {$$=$1;}
	|   DECIMAL_LITERAL         {$$=$1;}
	|	NULL_LITERAL            {$$=$1;}
//	|	ASCII_String_Literal
//	|	ASCII_Char_Literal
//	|	Real_Literal
//	|	Octal_Literal
//	|	Hex_Literal
//	|	DateTime_Literal
//	|	MaskedDateTime_Literal
//	|	UUID_Literal
//	|	TypeName_Literal
	;

/******************************************************************/
/******************************************************************/

Assing_Operator
	:	OP_IGUAL            {$$.num=OP_IGUAL;}
	|	OP_MASIGUAL			{$$.num=OP_MASIGUAL;}
	|	OP_MENOSIGUAL		{$$.num=OP_MENOSIGUAL;}
	|	OP_ASTERISCOIGUAL	{$$.num=OP_ASTERISCOIGUAL;}
	|	OP_DIVIDIDOIGUAL	{$$.num=OP_DIVIDIDOIGUAL;}
	|	OP_YIGUAL			{$$.num=OP_YIGUAL;}
	|	OP_OIGUAL			{$$.num=OP_OIGUAL;}
	|	OP_SOMBREROIGUAL	{$$.num=OP_SOMBREROIGUAL;}
	|	OP_PORCENTAJEIGUAL	{$$.num=OP_PORCENTAJEIGUAL;}
	|	OP_SHIFTLEFTIGUAL	{$$.num=OP_SHIFTLEFTIGUAL;}
	|	OP_SHIFTRIGHTIGUAL	{$$.num=OP_SHIFTRIGHTIGUAL;}
	;

Unary_Operator
	:	OP_MENOS    		{$$.num=OP_MENOS;}
	|	OP_ADMIRACION		{$$.num=OP_ADMIRACION;}
	|	OP_Y    			{$$.num=OP_Y;}
	|	OP_ASTERISCO		{$$.num=OP_ASTERISCO;}
	|	OP_CELDILLA			{$$.num=OP_CELDILLA;}
	;

Operator_Sym
	:	OP_IGUAL			{$$.num=OP_IGUAL;}
	|	OP_MAYOR			{$$.num=OP_MAYOR;}
	|	OP_MENOR			{$$.num=OP_MENOR;}
	|	OP_ADMIRACION		{$$.num=OP_ADMIRACION;}
	|	OP_CELDILLA			{$$.num=OP_CELDILLA;}
	|	OP_PREGUNTA			{$$.num=OP_PREGUNTA;}
	|	OP_IGUALIGUAL		{$$.num=OP_IGUALIGUAL;}
	|	OP_MENORIGUAL		{$$.num=OP_MENORIGUAL;}
	|	OP_MAYORIGUAL		{$$.num=OP_MAYORIGUAL;}
	|	OP_ADMIRACIONIGUAL	{$$.num=OP_ADMIRACIONIGUAL;}
	|	OP_YY				{$$.num=OP_YY;}
	|	OP_OO   			{$$.num=OP_OO;}
	|	OP_MASMAS			{$$.num=OP_MASMAS;}
	|	OP_MENOSMENOS		{$$.num=OP_MENOSMENOS;}
	|	OP_MAS				{$$.num=OP_MAS;}
	|	OP_MENOS			{$$.num=OP_MENOS;}
	|	OP_ASTERISCO		{$$.num=OP_ASTERISCO;}
	|	OP_DIVIDIDO			{$$.num=OP_DIVIDIDO;}
	|	OP_Y    			{$$.num=OP_Y;}
	|	OP_O				{$$.num=OP_O;}
	|	OP_SOMBRERO			{$$.num=OP_SOMBRERO;}
	|	OP_PORCENTAJE		{$$.num=OP_PORCENTAJE;}
	|	OP_SHIFTLEFT    	{$$.num=OP_SHIFTLEFT;}
	|	OP_SHIFTRIGHT		{$$.num=OP_SHIFTRIGHT;}
	|	OP_MASIGUAL			{$$.num=OP_MASIGUAL;}
	|	OP_MENOSIGUAL		{$$.num=OP_MENOSIGUAL;}
	|	OP_ASTERISCOIGUAL	{$$.num=OP_ASTERISCOIGUAL;}
	|	OP_DIVIDIDOIGUAL	{$$.num=OP_DIVIDIDOIGUAL;}
	|	OP_YIGUAL			{$$.num=OP_YIGUAL;}
	|	OP_OIGUAL			{$$.num=OP_OIGUAL;}
	|	OP_SOMBREROIGUAL	{$$.num=OP_SOMBREROIGUAL;}
	|	OP_PORCENTAJEIGUAL	{$$.num=OP_PORCENTAJEIGUAL;}
	|	OP_SHIFTLEFTIGUAL	{$$.num=OP_SHIFTLEFTIGUAL;}
	|	OP_SHIFTRIGHTIGUAL	{$$.num=OP_SHIFTRIGHTIGUAL;}
	|	OP_MENOSMAYOR		{$$.num=OP_MENOSMAYOR;}
	|	OP_MENOSMAYORASTERISCO	{$$.num=OP_MENOSMAYORASTERISCO;}
	|	PC_NEW				{$$.num=PC_NEW;}
	|	PC_DELETE			{$$.num=PC_DELETE;}
//	|   PC_EZOEICIT         {$$.num=PC_EZOEICIT;}
//	|   PC_IMPLICIT         {$$.num=PC_IMPLICIT;}*/
    |   IDENTIFICADOR       {
                                CodeDOM::string str($1.str);
                                if(str==(CodeDOM::string)L"implicit"){
                                    $$.num=PC_IMPLICIT;
                                }
                                else if(str==(CodeDOM::string)L"explicit"){
                                    $$.num=PC_EZOEICIT;
                                }
                                else{
                                    SINTAX_ERROR("Operator not valid on overloading declaration, 'implicit' or 'explicit' was expected. Using operator '+'.");
                                    $$.num=OP_MAS;
                                }
                            }
	;

ClassFactory_Call
	:	Postfix_Exp PUNTO_COMA
				{//	Postfix_Exp PUNTO_COMA
					CodeDOM::XplExpression* ne=new CodeDOM::XplExpression($1.node);
					//ASSING_COMMENT(ne);
					ne->set_ElementName(L"e");
					$$.node=ne;
					SET_SOURCE_DATA_S(ne,0);
				}
	|	OP_DOSPUNTOSDOBLE Postfix_Exp PUNTO_COMA
				{//	Postfix_Exp PUNTO_COMA
					CodeDOM::XplExpression* ne=new CodeDOM::XplExpression($2.node);
					//ASSING_COMMENT(ne);
					ne->set_ElementName(L"e");
					$$.node=ne;
					SET_SOURCE_DATA_S(ne,0);
				}
	;

/*****************************************************************************************************************/

%%

/////////////////////////////////////////////////////////////////////////////
// programs section

#include "layerd_dpp_parser_rutines.cpp"