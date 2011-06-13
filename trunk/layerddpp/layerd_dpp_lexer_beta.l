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
  layerd_dpp_parser_beta.l

  Scanner for Meta D++ Compiler

  This file must be processed with flex.

  Original Author: Alexis Ferreyra
  Contact: alexis.ferreyra@layerd.net
  
  Please visit http://layerd.net to get the last version
  of the software and information about LayerD technology.

****************************************************************************/
#include <iostream>
#include <wchar.h>
#ifdef WIN32
#include "..\\CodeDOM\\CDOM_IncludeAll.h"
#else
#include <layerd/CDOM_IncludeAll.h>
#endif
#include "layerd_dpp_parser_beta_tab.h"

#define LEXER_RETURN( N ) counter=0;yyposn=yylineno;return N;
#define LEXER_RETURN_VAL( N ) counter=0;yyposn=yylineno;return N;
#define CHAR_TYPE char
#define STR_CPY(N,M) wcscpy (N,M)
#define CONVERT_TO_DOM_CHAR(N) Convert_To_wchar(N)
#define CONVERT_TO_DOM_CHAR_XMLENCODED(N) Convert_To_wchar_XmlEncoded(N)

/* Definiciones para el control de posicion en BtYacc */
#define YYPOSN int
extern YYPOSN yyposn;

const CHAR_TYPE* GetLexerText();

wchar_t *wcharbuffer=NULL;
int current_wcharbuffer_lenght=0;
const wchar_t* Convert_To_wchar(const char* text);
const wchar_t* Convert_To_wchar_XmlEncoded(const char* text);
CodeDOM::XplDocumentation* CreateDocumentNode(const char* text);
#define COMMENT_BUFFER 64000
char lastCommentBuffer[COMMENT_BUFFER];
bool lastCommentValid = false;
int counter=0;

%}

/*/////////////////////////////////////////////////////////////////////////////
// declarations section*/

%option yylineno
%option never-interactive

%start COMMENT
%start COMILLA

%%

 /*/////////////////////////////////////////////////////////////////////////////
 // rules section*/


 /*	STRING LITERAL (DEBE ESTAR PRIMERO)	*/
<COMILLA>\n					{LEXER_RETURN(ERROR_COMILLA);BEGIN(0);}

 /*	LITERALES NULL Y BOOLEAN */
"null"|"NULL"				{//NULL_LITERAL
								yylval.literal=new CodeDOM::XplLiteral();
								yylval.literal->set_type(CodeDOM::ZOELITERALTYPE_ENUM_NULL);
								yylval.literal->set_str(DT("0"));
								yyposn=yylineno;
								LEXER_RETURN(NULL_LITERAL);
							}
"TRUE"|"true"				{//BOOLEAN_LITERAL_TRUE
								yylval.literal=new CodeDOM::XplLiteral();
								yylval.literal->set_type(CodeDOM::ZOELITERALTYPE_ENUM_BOOL);
								yylval.literal->set_str(DT("true"));
								yyposn=yylineno;
								LEXER_RETURN(BOOLEAN_LITERAL_TRUE);
							}
"FALSE"|"false"				{//BOOLEAN_LITERAL_FALSE
								yylval.literal=new CodeDOM::XplLiteral();
								yylval.literal->set_type(CodeDOM::ZOELITERALTYPE_ENUM_BOOL);
								yylval.literal->set_str(DT("false"));
								yyposn=yylineno;
								LEXER_RETURN(BOOLEAN_LITERAL_FALSE);
							}


 /*	COMENTARIOS	*/

"/*"        {
                register int c;
                for ( ; ; ){
					while ( (c = yyinput()) != '*' &&
						c != EOF ){
						/* eat up text of comment */
						if(counter<COMMENT_BUFFER+5){
							switch(c){
								case '\"':
									lastCommentBuffer[counter]='&';
									lastCommentBuffer[counter+1]='q';
									lastCommentBuffer[counter+2]='u';
									lastCommentBuffer[counter+3]='o';
									lastCommentBuffer[counter+4]='t';
									lastCommentBuffer[counter+5]=';';
									counter+=6;
									break;
								case '&':
									lastCommentBuffer[counter]='&';
									lastCommentBuffer[counter+1]='a';
									lastCommentBuffer[counter+2]='m';
									lastCommentBuffer[counter+3]='p';
									lastCommentBuffer[counter+4]=';';
									counter+=5;
									break;
								case '<':
									lastCommentBuffer[counter]='&';
									lastCommentBuffer[counter+1]='l';
									lastCommentBuffer[counter+2]='t';
									lastCommentBuffer[counter+3]=';';
									counter+=4;
									break;
								case '>':
									lastCommentBuffer[counter]='&';
									lastCommentBuffer[counter+1]='g';
									lastCommentBuffer[counter+2]='t';
									lastCommentBuffer[counter+3]=';';
									counter+=4;
									break;
								default:
									lastCommentBuffer[counter]=c;
									counter++;
							}
						}
					}
					if ( c == '*' )
						{
						while ( (c = yyinput()) == '*' )
							;
						if ( c == '/' )
							break;    /* found the end */
						}
					if ( c == EOF )
						{
							//yyerror( "EOF in comment" );
							break;
						}
                }
				lastCommentBuffer[counter]=0;
				lastCommentValid = true;
				//Agregado para incluir comentarios como tokens
				CodeDOM::XplDocumentation* doc = CreateDocumentNode(lastCommentBuffer);
				yylval.node = doc;
				LEXER_RETURN_VAL(COMENTARIO);
            }


"//"			{
					register int c;
					bool ignoreBarra=true;
					if(counter!=0){
						lastCommentBuffer[counter]='\n';
						counter++;
					}
					while ( true ){
						c = yyinput();
						if(counter<COMMENT_BUFFER+5 && c!='\n'){
							if(!(ignoreBarra && c=='/')){
								ignoreBarra=false;
								switch(c){
									case '\"':
										lastCommentBuffer[counter]='&';
										lastCommentBuffer[counter+1]='q';
										lastCommentBuffer[counter+2]='u';
										lastCommentBuffer[counter+3]='o';
										lastCommentBuffer[counter+4]='t';
										lastCommentBuffer[counter+5]=';';
										counter+=6;
										break;
									case '&':
										lastCommentBuffer[counter]='&';
										lastCommentBuffer[counter+1]='a';
										lastCommentBuffer[counter+2]='m';
										lastCommentBuffer[counter+3]='p';
										lastCommentBuffer[counter+4]=';';
										counter+=5;
										break;
									case '<':
										lastCommentBuffer[counter]='&';
										lastCommentBuffer[counter+1]='l';
										lastCommentBuffer[counter+2]='t';
										lastCommentBuffer[counter+3]=';';
										counter+=4;
										break;
									case '>':
										lastCommentBuffer[counter]='&';
										lastCommentBuffer[counter+1]='g';
										lastCommentBuffer[counter+2]='t';
										lastCommentBuffer[counter+3]=';';
										counter+=4;
										break;
									default:
										lastCommentBuffer[counter]=c;
										counter++;
								}
							}
						}
						if(c=='\n'){
							lastCommentBuffer[counter]='\n';
							counter++;
							break;
						}
					}
					lastCommentBuffer[counter] = 0;
					lastCommentValid = true;
					//Agregado para incluir comentarios como tokens
					CodeDOM::XplDocumentation* doc = CreateDocumentNode(lastCommentBuffer);
					yylval.node = doc;
					LEXER_RETURN_VAL(COMENTARIO);
				}

 /* ESPACIO EN BLANCO */

[ \t\n\b]+					;//LEXER_RETURN(WHITE_SPACE);


 /* SEPARADORES O PUNCTUATORS */

"("							LEXER_RETURN(OPEN_PARENTESIS);
")"							LEXER_RETURN(CLOSE_PARENTESIS);
"{"							LEXER_RETURN(OPEN_LLAVE);
"}"							LEXER_RETURN(CLOSE_LLAVE);
"["							LEXER_RETURN(OPEN_CORCHETE);
"]"							LEXER_RETURN(CLOSE_CORCHETE);
";"							LEXER_RETURN(PUNTO_COMA);
","							LEXER_RETURN(COMA);
"."							LEXER_RETURN(PUNTO);

 /* OPERADORES */

"="							LEXER_RETURN(OP_IGUAL);
">"							LEXER_RETURN(OP_MAYOR);
"<"							LEXER_RETURN(OP_MENOR);
"!"							LEXER_RETURN(OP_ADMIRACION);
"~"							LEXER_RETURN(OP_CELDILLA);
"?"							LEXER_RETURN(OP_PREGUNTA);
"::"						LEXER_RETURN(OP_DOSPUNTOSDOBLE);
":"							LEXER_RETURN(OP_DOSPUNTOS);
"'"							LEXER_RETURN(OP_COMILLA);
"=="						LEXER_RETURN(OP_IGUALIGUAL);

"<="						LEXER_RETURN(OP_MENORIGUAL);
">="						LEXER_RETURN(OP_MAYORIGUAL);
"!="						LEXER_RETURN(OP_ADMIRACIONIGUAL);
"&&"						LEXER_RETURN(OP_YY);
"||"						LEXER_RETURN(OP_OO);
"++"						LEXER_RETURN(OP_MASMAS);
"--"						LEXER_RETURN(OP_MENOSMENOS);
"+"							LEXER_RETURN(OP_MAS);
"-"							LEXER_RETURN(OP_MENOS);
"*"							LEXER_RETURN(OP_ASTERISCO);
"/"							LEXER_RETURN(OP_DIVIDIDO);
"&"							LEXER_RETURN(OP_Y);
"|"							LEXER_RETURN(OP_O);
"^"							LEXER_RETURN(OP_SOMBRERO);
"%"							LEXER_RETURN(OP_PORCENTAJE);
"<<"						LEXER_RETURN(OP_SHIFTLEFT);
">>"						LEXER_RETURN(OP_SHIFTRIGHT);
">>>"						LEXER_RETURN(OP_SHIFTRIGHT_JAVA);
"+="						LEXER_RETURN(OP_MASIGUAL);
"-="						LEXER_RETURN(OP_MENOSIGUAL);
"*="						LEXER_RETURN(OP_ASTERISCOIGUAL);
"/="						LEXER_RETURN(OP_DIVIDIDOIGUAL);
"&="						LEXER_RETURN(OP_YIGUAL);
"|="						LEXER_RETURN(OP_OIGUAL);
"^="						LEXER_RETURN(OP_SOMBREROIGUAL);
"%="						LEXER_RETURN(OP_PORCENTAJEIGUAL);
"<<="						LEXER_RETURN(OP_SHIFTLEFTIGUAL);
">>="						LEXER_RETURN(OP_SHIFTRIGHTIGUAL);
">>>="						LEXER_RETURN(OP_SHIFTRIGHT_JAVA_IGUAL);
"=>"						LEXER_RETURN(OP_IGUALMAYOR);
"->"						LEXER_RETURN(OP_MENOSMAYOR);
"->*"						LEXER_RETURN(OP_MENOSMAYORASTERISCO);
".*"						LEXER_RETURN(OP_PUNTOASTERISCO);


 /*	PALABRAS CLAVE */

"import"					LEXER_RETURN(PC_IMPORT);
"using"						LEXER_RETURN(PC_USING);
"identifiers"				LEXER_RETURN(PC_IDENTIFIERS);
"alias"						LEXER_RETURN(PC_ALIAS);
"namespace"					LEXER_RETURN(PC_NAMESPACE);
"class"						LEXER_RETURN(PC_CLASS);
"enum"						LEXER_RETURN(PC_ENUM);
"union"						LEXER_RETURN(PC_UNION);
"interface"					LEXER_RETURN(PC_INTERFACE);
"inherits"					LEXER_RETURN(PC_INHERITS);
"implements"				LEXER_RETURN(PC_IMPLEMENTS);
"virtual"					LEXER_RETURN(PC_VIRTUAL);
"nonvirtual"				LEXER_RETURN(PC_NONVIRTUAL);
"like"						LEXER_RETURN(PC_LIKE);
"setplatforms"				LEXER_RETURN(PC_SETPLATFORMS);
"autoinstance"				LEXER_RETURN(PC_AUTOINSTANCE);
"bycall"					LEXER_RETURN(PC_BYCALL);
"byclass"					LEXER_RETURN(PC_BYCLASS);
"bynamespace"				LEXER_RETURN(PC_BYNAMESPACE);
"bycallto"					LEXER_RETURN(PC_BYCALLTO);
"fp"						LEXER_RETURN(PC_FPOINTER);

"public"					LEXER_RETURN(PC_PUBLIC);
"protected"					LEXER_RETURN(PC_PROTECTED);
"private"					LEXER_RETURN(PC_PRIVATE);
"ipublic"					LEXER_RETURN(PC_IPUBLIC);
"iprotected"				LEXER_RETURN(PC_IPROTECTED);
"iprivate"					LEXER_RETURN(PC_IPRIVATE);

"static"					LEXER_RETURN(PC_STATIC);
"const"						LEXER_RETURN(PC_CONST);
"volatile"					LEXER_RETURN(PC_VOLATILE);
"extern"					LEXER_RETURN(PC_EXTERN);

"force"					    LEXER_RETURN(PC_FORCE);
"factory"					LEXER_RETURN(PC_FACTORY);
"interactive"				LEXER_RETURN(PC_INTERACTIVE);
"keyword"					LEXER_RETURN(PC_KEYWORD);

"final"						LEXER_RETURN(PC_FINAL);
"new"						LEXER_RETURN(PC_NEW);
"override"					LEXER_RETURN(PC_OVERRIDE);
"abstract"					LEXER_RETURN(PC_ABSTRACT);
"params"					LEXER_RETURN(PC_PARAMS);
"in"						LEXER_RETURN(PC_IN);
"out"						LEXER_RETURN(PC_OUT);
"inout"						LEXER_RETURN(PC_INOUT);
"ref"						LEXER_RETURN(PC_REF);
"extension"					LEXER_RETURN(PC_EXTENSION);
"ordinary"					LEXER_RETURN(PC_ORDINARY);
"struct"					LEXER_RETURN(PC_STRUCT);
"operator"					LEXER_RETURN(PC_OPERATOR);
"indexer"					LEXER_RETURN(PC_INDEXER);
"property"					LEXER_RETURN(PC_PROPERTY);
"get"						LEXER_RETURN(PC_GET);

"readonly"					LEXER_RETURN(PC_READONLY);
"blocktofactorys"			LEXER_RETURN(PC_BLOCKTOFACTORYS);
"except"					LEXER_RETURN(PC_EXCEPT);
"set"						LEXER_RETURN(PC_SET);
"resume"					LEXER_RETURN(PC_RESUME);
"break"						LEXER_RETURN(PC_BREAK);
"continue"					LEXER_RETURN(PC_CONTINUE);
"writecode"					LEXER_RETURN(PC_WRITECODE);
"if"						LEXER_RETURN(PC_IF);
"else"						LEXER_RETURN(PC_ELSE);
"while"						LEXER_RETURN(PC_WHILE);
"do"						LEXER_RETURN(PC_DO);
"for"						LEXER_RETURN(PC_FOR);
"foreach"					LEXER_RETURN(PC_FOR);
"switch"					LEXER_RETURN(PC_SWITCH);
"case"						LEXER_RETURN(PC_CASE);
"default"					LEXER_RETURN(PC_DEFAULT);
"return"					LEXER_RETURN(PC_RETURN);
"throw"						LEXER_RETURN(PC_THROW);
"try"						LEXER_RETURN(PC_TRY);
"catch"						LEXER_RETURN(PC_CATCH);
"finally"					LEXER_RETURN(PC_FINALLY);
"delete"					LEXER_RETURN(PC_DELETE);
"bool"                      LEXER_RETURN(PC_BOOL);
"void"						LEXER_RETURN(PC_VOID);
"object"					LEXER_RETURN(PC_OBJECT);
"sbyte"                     LEXER_RETURN(PC_SBYTE);
"short"						LEXER_RETURN(PC_SHORT);
"int"						LEXER_RETURN(PC_INT);
"long"						LEXER_RETURN(PC_LONG);
"unsigned"					LEXER_RETURN(PC_UNSIGNED);
"byte"                      LEXER_RETURN(PC_BYTE);
"ushort"                    LEXER_RETURN(PC_USHORT);
"uint"                      LEXER_RETURN(PC_UINT);
"ulong"                     LEXER_RETURN(PC_ULONG);
"float"						LEXER_RETURN(PC_FLOAT);
"double"					LEXER_RETURN(PC_DOUBLE);
"decimal"                   LEXER_RETURN(PC_DECIMAL);
"char"						LEXER_RETURN(PC_CHAR);
"ASCIIChar"					LEXER_RETURN(PC_ASCII_CHAR);
"string"					LEXER_RETURN(PC_STRING);
"ASCIIString"				LEXER_RETURN(PC_ASCII_STRING);
"type"						LEXER_RETURN(PC_TYPE);
"block"						LEXER_RETURN(PC_BLOCK);
"expression"				LEXER_RETURN(PC_EXPRESSION);
"exp"             	        LEXER_RETURN(PC_EXPRESSION);
"expressionlist"			LEXER_RETURN(PC_EXPRESSIONLIST);
"iname"						LEXER_RETURN(PC_INAME);
"statement"					LEXER_RETURN(PC_STATEMENT);
"sizeof"					LEXER_RETURN(PC_SIZEOF);
"typeof"					LEXER_RETURN(PC_TYPEOF);
"gettype"                   LEXER_RETURN(PC_GETTYPE);
"exec"						LEXER_RETURN(PC_EXEC);
"is"						LEXER_RETURN(PC_IS);

 /*	STRING LITERALS	*/

"'"(([^"\"""\\""\n""\r"])|("\\"(["n""t""b""r""f""\\""'""\""]|[0-7]([0-7])?|[0-3][0-7][0-7])))"'" {//CHAR_LITERAL
								yylval.literal=new CodeDOM::XplLiteral();
								yylval.literal->set_type(CodeDOM::ZOELITERALTYPE_ENUM_CHAR);
								yylval.literal->set_str(CONVERT_TO_DOM_CHAR_XMLENCODED(GetLexerText()));
								yyposn=yylineno;
								LEXER_RETURN_VAL(CHARACTER_LITERAL);
							}


"\""(([^"\"""\\""\n""\r"])|("\\"(["n""t""b""r""f""\\""'""\""]|[0-7]([0-7])?|[0-3][0-7][0-7])))*"\""	{//STRING_LITERAL
							yylval.literal=new CodeDOM::XplLiteral();
							yylval.literal->set_type(CodeDOM::ZOELITERALTYPE_ENUM_STRING);
							yylval.literal->set_str(CONVERT_TO_DOM_CHAR_XMLENCODED(GetLexerText()));
							yyposn=yylineno;
							LEXER_RETURN_VAL(STRING_LITERAL);
		                }

 /*	LITERALES NUMERICAS */

([0-9]+)(u|U|l|L)?			{//INTEGER_LITERAL
									yylval.literal=new CodeDOM::XplLiteral();
									yylval.literal->set_type(CodeDOM::ZOELITERALTYPE_ENUM_INTEGER);
									yylval.literal->set_str(CONVERT_TO_DOM_CHAR(GetLexerText()));
    								yyposn=yylineno;
									LEXER_RETURN_VAL(INTEGER_LITERAL);
							}

[0-9]+("."[0-9]+)((e|E)("+"|"-")?[0-9]+)?(F|f|D|d|M|m|X|x)?		{//REAL_LITERAL
									yylval.literal=new CodeDOM::XplLiteral();
									yylval.literal->set_type(CodeDOM::ZOELITERALTYPE_ENUM_REAL);
									yylval.literal->set_str(CONVERT_TO_DOM_CHAR(GetLexerText()));
    								yyposn=yylineno;
									LEXER_RETURN_VAL(FLOAT_LITERAL);
							}

[0-9]+((e|E)("+"|"-")?[0-9]+)?(F|f|D|d|M|m|X|x)?				{//REAL_LITERAL
									yylval.literal=new CodeDOM::XplLiteral();
									yylval.literal->set_type(CodeDOM::ZOELITERALTYPE_ENUM_REAL);
									yylval.literal->set_str(CONVERT_TO_DOM_CHAR(GetLexerText()));
    								yyposn=yylineno;
									LEXER_RETURN_VAL(FLOAT_LITERAL);
							}

"0"["x""X"]([0-9a-fA-F])+	{//HEX_LITERAL
									yylval.literal=new CodeDOM::XplLiteral();
									yylval.literal->set_type(CodeDOM::ZOELITERALTYPE_ENUM_HEX);
									yylval.literal->set_str(CONVERT_TO_DOM_CHAR(GetLexerText()));
    								yyposn=yylineno;
									LEXER_RETURN_VAL(INTEGER_LITERAL);
							}

 /*	IDENTIFICADORES	*/
("@"|"$")?[A-Za-z_][A-Za-z0-9_]*	{//IDENTIFICADORES
								if(YY_START!=0){
									switch(YY_START){
										case COMILLA:
											LEXER_RETURN_VAL(ERROR_COMILLA);BEGIN(0);
											break;
										default:
											LEXER_RETURN_VAL(ERROR_LEXICO);BEGIN(0);
									};
								}
								else {
									if(GetLexerText()[0]=='@')
										STR_CPY(yylval.str,CONVERT_TO_DOM_CHAR(GetLexerText()+1));
									else
										STR_CPY(yylval.str,CONVERT_TO_DOM_CHAR(GetLexerText()));
    								yyposn=yylineno;
									LEXER_RETURN_VAL(IDENTIFICADOR);
								}
							}

 /*	CAULQUIER OTRO CARACTER ES UN ERROR	*/
.							{LEXER_RETURN(MAL_CARACTER);BEGIN(0);}

%%


/*/////////////////////////////////////////////////////////////////////////////
// Rutinas Basicas */

int yywrap(){
  return -1;
}

CodeDOM::XplDocumentation* CreateDocumentNode(const char* text){
	CodeDOM::XplDocumentation* document = new CodeDOM::XplDocumentation();
	document->set_ElementName(L"documentation");
	document->set_short( Convert_To_wchar(text) );
	return document;
}

const CHAR_TYPE* GetLexerText(){
	if(yytext[0]=='\"' || yytext[0]=='\''){
		yytext[yyleng-1]='\0';
		return yytext+1;
	}
	else{
		return yytext;
	}
}

const wchar_t* Convert_To_wchar(const char* text){
  int length = strlen(text);
  if(wcharbuffer==NULL || current_wcharbuffer_lenght<length){
      //Asigno memoria al buffer temporal
      wcharbuffer = new wchar_t[length+1];
  }
  mbstowcs(wcharbuffer,text,length);
  wcharbuffer[length]=L'\0';
  return wcharbuffer;
}

void move_chars(wchar_t* wcharbuffer,int from, int to, int offset){
	for(;to>=from;to--)
		wcharbuffer[to+offset]=wcharbuffer[to];
}
void my_strcpy(wchar_t*target, wchar_t*source){
	int max=wcslen(source)-1;
	for(;max>-1;max--)
		target[max]=source[max];
}
const wchar_t* Convert_To_wchar_XmlEncoded(const char* text){
  //Primero cuento los caracteres a convertir: " < > &
  int count=0;
  for(int n=0;n<strlen(text);n++){
    if(text[n]=='\"')count+=5;
    else if(text[n]=='&')count+=4;
    else if(text[n]=='<')count+=3;
    else if(text[n]=='>')count+=3;
  }

  if(count==0)return Convert_To_wchar(text);
  //Almaceno el buffer
  if(wcharbuffer==NULL || current_wcharbuffer_lenght<yyleng+count){
      //Asigno memoria al buffer temporal
      wcharbuffer=new wchar_t[yyleng+count+1];
  }
  mbstowcs(wcharbuffer,text,yyleng);
  wcharbuffer[yyleng]=L'\0';
  count=0;
  for(int n=0;wcharbuffer[n]!=0;n++){
    if(wcharbuffer[n]=='\"'){
        //Primero muevo la cadena y luego inserto
		move_chars(wcharbuffer,n+1,yyleng+count,5);
        my_strcpy(&wcharbuffer[n],L"&quot;");
		count+=5;n+=5;
    }
    else if(wcharbuffer[n]=='&'){
        //Primero muevo la cadena y luego inserto
		move_chars(wcharbuffer,n+1,yyleng+count,4);
        my_strcpy(&wcharbuffer[n],L"&amp;");
		count+=4;n+=4;
    }
    else if(wcharbuffer[n]=='<'){
        //Primero muevo la cadena y luego inserto
		move_chars(wcharbuffer,n+1,yyleng+count,3);
		my_strcpy(&wcharbuffer[n],L"&lt;");
		count+=3;n+=3;
    }
    else if(wcharbuffer[n]=='>'){
        //Primero muevo la cadena y luego inserto
		move_chars(wcharbuffer,n+1,yyleng+count,3);
        my_strcpy(&wcharbuffer[n],L"&gt;");
		count+=3;n+=3;
    }
  }

  return wcharbuffer;
}
