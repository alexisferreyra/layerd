/*******************************************************************************
* Copyright (c) 20011, 2012 Intel Corporation.
* All rights reserved. This program and the accompanying materials
* are made available under the terms of the Eclipse Public License v1.0
* which accompanies this distribution, and is available at
* http://www.eclipse.org/legal/epl-v10.html
*
* Contributors:
*       Alexis Ferreyra (Intel Corporation) - bug fixing
*******************************************************************************/
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

  Parser support file for Meta D++ Compiler
  
  Original Author: Alexis Ferreyra
  Contact: alexis.ferreyra@layerd.net
  
  Please visit http://layerd.net to get the last version
  of the software and information about LayerD technology.

****************************************************************************/

#line 1 "layerd_dpp_parser_rutines.cpp"

#include <io.h>
#include <fcntl.h>
#include <sys/types.h>
#include <sys/stat.h>, 
//CD_OUT: Macro para el "ostream" de salida de mensajes
#define CD_COUT cout
//CT(n) : Macro para constantes de texto en la interfaz del compilador, diferente de DT(n) que es la macro para constantes del CodeDOM.
#define CT(n) n 

#define FALSE 1
#define TRUE 0

void OutFooter(){
	CD_COUT<<endl<<CT("Meta D++ Compiler (Version ")<<LAYERD_COMPILER_VERSION<<CT(") 2005(R).")<<endl;
	wcout<<CT("Using: ZOE CodeDOM Version ")<<LAYERD_ZOE_CODEDOM_VERSION<<CT(".")<<endl;
	CD_COUT<<CT("Please visit  http://layerd.net to obtain the last available version.")<<endl;
}

void PrintHelp(){
	CD_COUT<<endl<<CT("Use:")<<endl<<endl;
	CD_COUT<<CT("\tlddppc.exe \tFile_to_Compile [-o Output_File] \n\t\t\t[-c ZOE_Configuration] [-l LayerD_ZOE_Compiler] \n\t\t\t[-p Platform] [-f] [-i] [-g] [-v] [-s] [-dFLAG]")<<endl<<endl;
	CD_COUT<<CT("\tFile_to_Compile\t\tLayerD D++ Source File.")<<endl;
	CD_COUT<<CT("\tOutput_File\t\tThe output filename, by default\n\t\t\t\tFile_to_Compile.zoe .")<<endl;
	CD_COUT<<CT("\tZOE_Configuration\tXML File with ZOE configuration.")<<endl;
	CD_COUT<<CT("\tLayerD_ZOE_Compiler\tExecutable file of ZOE compiler,\n\t\t\t\tby default zoec.exe .")<<endl;

	CD_COUT<<CT("\tPlatform\t\tTarget Platform, by default 'default'.")<<endl;
	CD_COUT<<CT("\t-f\t\t\tCompile .zoe when finished.")<<endl;
	CD_COUT<<CT("\t-i\t\t\tCompile Interactive Classfactorys.")<<endl;
	CD_COUT<<CT("\t-g\t\t\tCompile debug version.")<<endl;
	CD_COUT<<CT("\t-v\t\t\tPrint debug information.")<<endl;
	CD_COUT<<CT("\t-s\t\t\tDo not print lot of messages.")<<endl;
	CD_COUT<<CT("\t-dFLAG\t\t\tFLAG: w, e, s, c")<<endl;
	CD_COUT<<CT("\t\t\t\tw Do not print Warnings")<<endl;
	CD_COUT<<CT("\t\t\t\te Do not print Errores")<<endl;
	CD_COUT<<CT("\t\t\t\ts Do not include source information in Zoe file.")<<endl;
	CD_COUT<<CT("\t\t\t\tc Do not include comments in Zoe file.")<<endl;
	CD_COUT<<endl;
}

void ExitWithHelp(){
	PrintHelp();
	OutFooter();
	exit(0);
}

void ProccessCommandLine(int count, char* args[],DppOptions*options){
	char* cad=NULL;
	bool flag=false;
	for(int n=1;n<count;n++){
		cad=args[n];
		if(strlen(cad)>2048){ //chequeo de seguridad
			CD_COUT<<CT("There are errors in program arguments, a string seems to be larger than 2048 characteres.")<<endl<<CT("We are closing.")<<endl;
			OutFooter();
			exit(0);
		}
		if(cad[0]=='-'){
			switch(cad[1]){	//Opciones
				case 's':	//Silent mode
					options->silent=true;
					break;
				case 'v':	//Debug
					options->showDebug=true;
					break;
				case 'o':	//Output Filename
					n++;cad=args[n];
					strcpy(options->outputFilename,cad);
					break;
				case 'c':	//Config Filename
					n++;cad=args[n];
					strcpy(options->configFilename,cad);
					break;
				case 'l':	//ZOE Compiler
					n++;cad=args[n];
					strcpy(options->layerdCompiler,cad);
					break;
				case 'p':	//Plataforma
					n++;cad=args[n];
					strcpy(options->platform,cad);
					break;
				case 'i':	//Compilar Interactive Classfactorys
					options->interactive=true;
					break;
				case 'g':	//Debug
					options->debug=true;
					break;
				case 'f':
					options->fullCompile=true;
					break;
				case 'e':
					options->addExtension=true;
					break;
				case 'b':
					options->library=true;
					break;
				case '@':
					CD_COUT<<endl<<CT("Meta D++ - Developed by Alexis A. Ferreyra (R)2005.")<<endl<<endl;
					break;
				case 'd':
					switch(cad[2]){
						case 'w':	//No imprimir Warnings
							options->printWarnings=false;
							break;
						case 'e':	//No imprimir Errores
							options->printErrors=false;
							break;
						case 's':	//No incluir Source Data
							options->includeSourceData=false;
							break;
						case 'c':	//No incluir Comentarios
							options->includeComments=false;
							break;
					};
					break;
				default:
					CD_COUT<<CT("Invalid option: ")<<cad[1]<<endl;
					ExitWithHelp();
					break;
			};
		}
		else{	//es el nombre del archivo de entrada
			if(flag){
					CD_COUT<<CT("Invalid options")<<endl;
					ExitWithHelp();
			}
			else{
				strcpy(options->filename,cad);
				flag=true;
			}
		}

	}
}

CodeDOM::XplDocumentData* GetDefaultDocumentData(DppOptions* options){
	CodeDOM::XplDocumentData*data=CodeDOM::XplDocument::new_DocumentData();
	//DocumentData
	data->set_DocumentType(CodeDOM::ZOEDOCUMENTTYPE_ENUM_LAYERD_ZOE_DOC);
	data->set_DocumentVersion(DT("1.0"));

	CodeDOM::XplConfig*config=CodeDOM::XplDocumentData::new_Config(); 
	data->set_Config(config);
	CodeDOM::XplLayerDZoeDocumentConfig*xplconfig=CodeDOM::XplConfig::new_LayerD_Zoe_Document_Config();
	config->set_tConfig(xplconfig);
	//Document Config
	CodeDOM::XplLanguage*language=CodeDOM::XplLayerDZoeDocumentConfig::new_Language();
	CodeDOM::XplLayerDCompiler*compiler=CodeDOM::XplLayerDZoeDocumentConfig::new_LayerDCompiler();
	xplconfig->set_Language(language);
	xplconfig->set_LayerDCompiler(compiler);
	//Compiler
	compiler->set_companyName(DT("LayerD.net"));
	compiler->set_copyright(DT("Copyright 2005-2007(R) LayerD.net"));
	compiler->set_name(DT("Meta D++ Compiler"));
	compiler->set_version(LAYERD_COMPILER_VERSION_DOM_CHAR);
	//Lenguaje
	language->set_Source(DT("Meta D++"));
	language->set_SourceVersion(DT("0.9"));
	language->set_StandardDefinitionFile(DT("http://layerd.net/standards/metadpp/metadpp_standard_0_9.xml"));

	//Finalizo devolviendo el DocumentData
	return data;
}

CodeDOM::XplDocumentData* GetFromFileDocumentData(DppOptions* options){
	CD_COUT<<endl<<CT("Zoe configuration file not supported in this version of Meta D++ compiler.")<<endl<<CT("Using default configuration program for Meta D++.")<<endl<<endl;
	return GetDefaultDocumentData(options);
}

void printErrors(){
	if(!command.silent)CD_COUT<<endl<<CT("Errors: ")<<pErrors.capacity()<<endl;
	for(vector<std::string>::iterator it=pErrors.begin();it!=pErrors.end();it++){
		CD_COUT<<*it<<endl;
	}
	if(!command.silent)CD_COUT<<endl<<CT("Warnings: ")<<pWarnings.capacity()<<endl;
	for(vector<std::string>::iterator it=pWarnings.begin();it!=pWarnings.end();it++){
		CD_COUT<<*it<<endl;
	}
}
void AddError(const char*error){
	char buf[10];
	itoa(yylineno,buf,10);
	pErrors.push_back((std::string)command.filename+(std::string)"("+(std::string)buf+(std::string)") : error : "+(std::string)error);
}
void AddWarning(const char*error){
	char buf[10];
	itoa(yylineno,buf,10);
	pWarnings.push_back((std::string)command.filename+(std::string)"("+(std::string)buf+(std::string)") : warning : "+(std::string)error);
}

/*
	Funciones para recuperarse de errores varios durante el parseo usando una lista
	que no acepta ningun nodo como hijo.
*/
bool BadListNodeCallback(CodeDOM::XplNode* node, CodeDOM::string* errorMsg, CodeDOM::XplNode* parent){
	return false;
}
CodeDOM::XplNodeList* NewErrorResumeXplNodeList(){
	CodeDOM::XplNodeList* tempList=new CodeDOM::XplNodeList();
	tempList->set_InsertNodeCallback(&BadListNodeCallback);	
	tempList->set_RemoveNodeCallback(&BadListNodeCallback);	
	return tempList;
}


int main(int argc, char*argv[])
{
	int n = 1;
	if(argc==1){
		CD_COUT<<CT("Use at least one argument.")<<endl<<endl;
		CD_COUT<<CT("Example:")<<endl;
		CD_COUT<<CT("\tmetadppc.exe test.dpp\t\tTo compile the file 'test.dpp'.")<<endl;
		ExitWithHelp();
		return FALSE;
	}
	else{
		ProccessCommandLine(argc,argv,&command);
		if(strlen(command.filename)<=0){
			CD_COUT<<CT("Insert the filename to compile.")<<endl;
			ExitWithHelp();
		}
		std::wfstream outFile;
		int outFile2=0;
		//Tengo que usar la libreria estandar de C para el archivo de entrada por flex!
		FILE* inFile;
		inFile=fopen(command.filename,"r");
		if(inFile==NULL){
			CD_COUT<<CT("ERROR: Filename: \"")<<command.filename<<CT("\" couldn't be opened or it was not found.")<<endl;
			OutFooter();
			return FALSE;
		}
		//Asigno el archivo de entrada al scanner (flex)
		yyin=inFile;

		//Asigno el archivo de salida
		if(strlen(command.outputFilename)<=3){
			strcpy(command.outputFilename ,command.filename);
			strcpy( &command.outputFilename[strlen(command.filename)-4],".zoe\0" );
		}
		if(!command.silent)CD_COUT<<CT("Meta D++ Compiler. Compiling \"")<<command.filename<<CT("\" ...")<<endl<<endl;
		else CD_COUT<<command.filename<<CT("...")<<endl;
		//Ejecuto el parser
		n = yyparse();
		if(n==0 && rootNode!=NULL){
			if(!command.silent)CD_COUT<<endl<<CT("Building file \"")<<command.outputFilename<<CT("\" ...")<<endl;
			//Variables de documento
			CodeDOM::XplDocument*doc=new CodeDOM::XplDocument();
			CodeDOM::XplDocumentData*data=NULL;

			CodeDOM::XplDocumentBody*body=(CodeDOM::XplDocumentBody*)rootNode;
			if(strlen(command.configFilename)>3){
				//Configuracion de Zoe especificada por el usuario
				data=GetFromFileDocumentData(&command);
			}
			else{
				//Configuracion de Zoe por defecto
				data=GetDefaultDocumentData(&command);
			}
			doc->set_DocumentData(data);
			doc->set_DocumentBody(body);
			doc->set_ElementName(DT("ZOEDocument"));

			wchar_t fileNameBuffer[2048];
			mbstowcs(fileNameBuffer,command.filename,strlen(command.filename)+1);
			body->set_ldsrc( (CodeDOM::string)DT("1,1,")+(CodeDOM::string)fileNameBuffer );
			
			outFile2=_open( command.outputFilename, _O_WRONLY | _O_CREAT | _O_U8TEXT | _O_TRUNC, _S_IWRITE ); 
			//outFile.open(command.outputFilename,ios_base::trunc | ios_base::out );
			//if(outFile.fail() || !outFile.is_open()){
			if(outFile2==-1){
				CD_COUT<<CT("ERROR: Output file: \"")<<command.outputFilename<<CT("\" couldn't be opened.")<<endl;
				OutFooter();
				return FALSE;
			}

			if(!command.silent)CD_COUT<<endl<<CT("Saving file \"")<<command.outputFilename<<CT("\" ...")<<endl;
			if(command.showDebug){
				CD_COUT<<endl<<CT("Zoe document saved:")<<endl<<endl;
				//Esto sólo funcionará si CDOM_CHAR es wchar_t
				//writer=new CodeDOM::XplWriter((std::wiostream*)&wcout);
				writer=new CodeDOM::XplWriter((std::wiostream*)&wcout);
				doc->Write(writer);
				CD_COUT<<endl<<endl;
			}
       		writer=new CodeDOM::XplWriter(outFile2);
       		//writer=new CodeDOM::XplWriter((std::wiostream*)&outFile);
			doc->Write(writer);
			//Elimino el documento de la memoria
			delete doc;
			//Llamo al compilador zoe si fue especificado
			if(command.fullCompile){
				
			}
		}
		else{
			if(n==1) AddError("Unexpected token near the end of the file was found.");
			if(tempNode!=NULL) delete tempNode;
		}
		//Cierro los archivos
		fclose(inFile);
		//outFile.close();
		_close(outFile2);
		delete writer;
		if(!command.silent)CD_COUT<<endl<<CT("Finalized.")<<endl;
	} // argc>1
	//Me voy....
	printErrors();
	if(!command.silent)OutFooter();
	if(command.showDebug){
		CD_COUT<<endl<<CT("Press any key to end.")<<endl;
		cin.get();
	}	
	if(pErrors.capacity()==0)return TRUE;
	else return FALSE;
}

/*****************************************************************************
*
*   PARSER HELPER FUNCTIONS
*
******************************************************************************/

void SetClassMembers(CodeDOM::XplNodeList *c, CodeDOM::XplNodeList *list, bool allMembersPublic){
	CodeDOM::XplAccesstype_enum lastAccess = CodeDOM::ZOEACCESSTYPE_ENUM_PRIVATE;
	if(allMembersPublic){
		lastAccess = CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC;
	}
	CodeDOM::XplNodeList*list2=NULL;
	if(list==NULL)return;
	for(CodeDOM::XplNode* m=list->FirstNode();m!=NULL;m=list->NextNode()){
		int temp=m->get_ContentTypeName();
		if(	temp==CodeDOM::CODEDOMTYPES_ZOEINHERITS						||
			temp==CodeDOM::CODEDOMTYPES_ZOECLASS						||
			temp==CodeDOM::CODEDOMTYPES_ZOEDOCUMENTATION				||
			temp==CodeDOM::CODEDOMTYPES_ZOECLASSFACTORYSPERMISSIONS		||
			temp==CodeDOM::CODEDOMTYPES_ZOENODE							||
			temp==CodeDOM::CODEDOMTYPES_ZOEEXPRESSION					||
			temp==CodeDOM::CODEDOMTYPES_ZOESETPLATFORMS				||
			temp==CodeDOM::CODEDOMTYPES_ZOEAUTOINSTANCE				){
			c->InsertAtEnd(m);
		}
		else if(temp==CodeDOM::CODEDOMTYPES_ZOEFUNCTION){
			((CodeDOM::XplFunction*)m)->set_access(lastAccess);
			c->InsertAtEnd(m);
		}
		else if(temp==CodeDOM::CODEDOMTYPES_ZOEPROPERTY){
			((CodeDOM::XplProperty*)m)->set_access(lastAccess);
			c->InsertAtEnd(m);
		}
		else if(temp==CodeDOM::CODEDOMTYPES_ZOEFIELD){	//El caso de fields decl
			((CodeDOM::XplField*)m)->set_access(lastAccess);
			c->InsertAtEnd(m);			
		}
		else if(temp==CodeDOM::CODEDOMTYPES_UNSIGNED){
			lastAccess=(CodeDOM::XplAccesstype_enum)m->get_unsignedValue();
			switch(lastAccess){
				case SM_PUBLIC:
					lastAccess=CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC;
					break;
				case SM_PROTECTED:
					lastAccess=CodeDOM::ZOEACCESSTYPE_ENUM_PROTECTED;
					break;
				case SM_PRIVATE:
					lastAccess=CodeDOM::ZOEACCESSTYPE_ENUM_PRIVATE;
					break;
				case SM_IPUBLIC:
					lastAccess=CodeDOM::ZOEACCESSTYPE_ENUM_IPUBLIC;
					break;
				case SM_IPROTECTED:
					lastAccess=CodeDOM::ZOEACCESSTYPE_ENUM_IPROTECTED;
					break;
				case SM_IPRIVATE:
					lastAccess=CodeDOM::ZOEACCESSTYPE_ENUM_IPRIVATE;
					break;
			}
			delete m;
		}
		else{
			//Error
		}

	}//for
}

CodeDOM::string get_OperatorFunctionName(unsigned int num){
	CodeDOM::string name=DT("%op_");
	switch(num){
		case OP_IGUAL:
			SINTAX_ERROR("It's not possible to overload the operator '='.");
			name+=DT("error%");
			break;
		case OP_MAYOR:
			name+=DT("gtr%");
			break;
		case OP_MENOR:
			name+=DT("lst%");
			break;
		case OP_ADMIRACION:
			name+=DT("bneg%");
			break;
		case OP_CELDILLA:
			name+=DT("comp%");
			break;
		case OP_PREGUNTA:
			SINTAX_ERROR("Operator '?' can't be overloaded.");
			name+=DT("error%");
			break;
		case OP_IGUALIGUAL:
			name+=DT("eq%");
			break;
		case OP_MENORIGUAL:
			name+=DT("lseq%");
			break;
		case OP_MAYORIGUAL:
			name+=DT("greq%");
			break;
		case OP_ADMIRACIONIGUAL:
			name+=DT("noteq%");
			break;
		case OP_YY:
			name+=DT("and%");
			break;
		case OP_OO:
			name+=DT("or%");
			break;
		case OP_MASMAS:
			name+=DT("inc%");
			break;
		case OP_MENOSMENOS:
			name+=DT("dec%");
			break;
		case OP_MAS:
			name+=DT("add%");
			break;
		case OP_MENOS:
			name+=DT("min%");
			break;
		case OP_ASTERISCO:
			name+=DT("mul%");
			break;
		case OP_DIVIDIDO:
			name+=DT("div%");
			break;
		case OP_Y:
			name+=DT("band%");
			break;
		case OP_O:
			name+=DT("bor%");
			break;
		case OP_SOMBRERO:
			name+=DT("xor%");
			break;
		case OP_PORCENTAJE:
			name+=DT("mod%");
			break;
		case OP_SHIFTLEFT:
			name+=DT("lsh%");
			break;
		case OP_SHIFTRIGHT:
			name+=DT("rsh%");
			break;
		case OP_MASIGUAL:
			SINTAX_ERROR("Operator '+=' can't be overloaded. Implement the operator '+' and the clonning interface.");
			name+=DT("error%");
			break;
		case OP_MENOSIGUAL:
			SINTAX_ERROR("Operator '-=' can't be overloaded. Implement the operator '-' and the clonning interface.");
			name+=DT("error%");
			break;
		case OP_ASTERISCOIGUAL:
			SINTAX_ERROR("Operator '*=' can't be overloaded. Implement the operator '*' and the clonning interface.");
			name+=DT("error%");
			break;
		case OP_DIVIDIDOIGUAL:
			SINTAX_ERROR("Operator '/=' can't be overloaded. Implement the operator '/' and the clonning interface.");
			name+=DT("error%");
			break;
		case OP_YIGUAL:
			SINTAX_ERROR("Operator '&=' can't be overloaded. Implement the operator '&' and the clonning interface.");
			name+=DT("error%");
			break;
		case OP_OIGUAL:
			SINTAX_ERROR("Operator '|=' can't be overloaded. Implement the operator '|' and the clonning interface.");
			name+=DT("error%");
			break;
		case OP_SOMBREROIGUAL:
			SINTAX_ERROR("Operator '^=' can't be overloaded. Implement the operator '^' and the clonning interface.");
			name+=DT("error%");
			break;
		case OP_PORCENTAJEIGUAL:
			SINTAX_ERROR("Operator '%=' can't be overloaded. Implement the operator '%' and the clonning interface.");
			name+=DT("error%");
			break;
		case OP_SHIFTLEFTIGUAL:
			SINTAX_ERROR("Operator '>>=' can't be overloaded. Implement the operator '>>' and the clonning interface.");
			name+=DT("error%");
			break;
		case OP_SHIFTRIGHTIGUAL:
			SINTAX_ERROR("Operator '<<=' can't be overloaded. Implement the operator '<<' and the clonning interface.");
			name+=DT("error%");
			break;
		case OP_MENOSMAYOR:
			SINTAX_ERROR("Operator '->' can't be overloaded.");
			name+=DT("error%");
			break;
		case OP_MENOSMAYORASTERISCO:
			SINTAX_ERROR("Operator '->*' can't be overloaded.");
			name+=DT("error%");
			break;
		case PC_NEW:
			name+=DT("new%");
			break;
		case PC_DELETE:
			name+=DT("delete%");
			break;
		case PC_EZOEICIT:
			name+=DT("explicit%");
			break;
		case PC_IMPLICIT:
			name+=DT("implicit%");
			break;
		default:
			name+=DT("add%");
			std::cerr<<endl<<"WARNING: Internal error detected on metadppc. Invalid operator. Please, report the bug."<<endl;
			break;
	};
	return name;
}

CodeDOM::XplFunction* CreateFunction(unsigned int p_storage /*Storage*/,
                        CodeDOM::XplType* p_type /*Type_Decl*/,                        
                        CodeDOM::XplFunction* p_declarator_f /*Decl_F*/,
                        CodeDOM::XplParameters* p_parameters /*Parameters*/,                        
                        CodeDOM::XplBaseInitializers * p_base_initializers /*Base_Init*/,
						CodeDOM::XplFunctionBody* p_block /*Block*/){

    if(p_declarator_f==NULL)return CodeDOM::XplClass::new_Function();
	CodeDOM::XplFunction*f=p_declarator_f;

	if(p_type!=NULL){
		p_type->set_ElementName(DT("ReturnType"));
		f->set_ReturnType(p_type);
	}
	else{
		///Chequear que si no proporciono modificadores sea algo valido.
	}
	f->set_FunctionBody(p_block);
	f->set_Parameters(p_parameters);
	SetFuncStorageMod(f,p_storage);
	f->set_BaseInitializers(p_base_initializers);
	return f;
}

void SetDeclaratorMod(CodeDOM::XplClass* c,unsigned int num){
	unsigned int flags=0;
	if(c==NULL)return;
	if((num&SM_PRIVATE)==SM_PRIVATE){
		flags|=SM_PRIVATE;
		c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PRIVATE);
	}
	else if((num&SM_PUBLIC)==SM_PUBLIC){
		flags|=SM_PUBLIC;
		c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PUBLIC);
	}
	else if((num&SM_PROTECTED)==SM_PROTECTED){
		flags|=SM_PROTECTED;
		c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PROTECTED);
	}
	else if((num&SM_IPRIVATE)==SM_IPRIVATE){
		flags|=SM_IPRIVATE;
		c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_IPRIVATE);
	}
	else if((num&SM_IPUBLIC)==SM_IPUBLIC){
		flags|=SM_IPUBLIC;
		c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_IPUBLIC);
	}
	else if((num&SM_IPROTECTED)==SM_IPROTECTED){
		flags|=SM_IPROTECTED;
		c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_IPROTECTED);
	}
	else{ //Por defecto privado
		c->set_access(CodeDOM::ZOEACCESSTYPE_ENUM_PRIVATE);
	}

	if((num & SM_EXTENSION) == SM_EXTENSION){
		flags|=SM_EXTENSION;
		c->set_extension(true);
	}
	if((num & SM_FACTORY) == SM_FACTORY ){
		flags|=SM_FACTORY;
		c->set_isfactory(true);
	}
	if((num & SM_INTERACTIVE) == SM_INTERACTIVE ){
		flags|=SM_INTERACTIVE;
		c->set_isinteractive(true);
	}
	if((num & SM_FINAL) == SM_FINAL ){
		c->set_final(true);
		flags|=SM_FINAL;
	}
	if((num & SM_ABSTRACT)== SM_ABSTRACT){
		c->set_abstract(true);
		flags|=SM_ABSTRACT;
	}
	if((num & SM_NEW)== SM_NEW){
		c->set_new(true);
		flags|=SM_NEW;
	}
	if((num & SM_EXTERN)== SM_EXTERN){
		c->set_external(true);
		flags|=SM_EXTERN;
	}
	if((num & flags) != num ){//Hay storage modifiers de mas
		SINTAX_ERROR("invalid storage modifiers on class declaration. Valid declaration modifiers are: 'public', 'protected', 'private', 'ipublic', 'iprotected', 'iprivate', 'factory', 'interactive', 'extension', 'final', 'new', 'abstract'.");
	}
}

void SetFuncStorageMod(CodeDOM::XplFunction*f,unsigned int num){
	unsigned int flags=0;
	if(f==NULL)return;
	if( (num & SM_FACTORY) == SM_FACTORY ){
		flags|=SM_FACTORY;
		f->set_isfactory(true);
	}
	if((num & SM_VIRTUAL ) == SM_VIRTUAL ){
		flags|=SM_VIRTUAL;
		f->set_virtual(true);
	}
	if((num & SM_ABSTRACT ) == SM_ABSTRACT ){
		flags|=SM_ABSTRACT;
		f->set_abstract(true);
	}
	if((num & SM_FPOINTER) == SM_FPOINTER){
		flags|=SM_FPOINTER;
		f->set_fp(true);
	}
	if((num & SM_NONVIRTUAL ) == SM_NONVIRTUAL ){
		flags|=SM_NONVIRTUAL;
		f->set_nonvirtual(true);
	}
	if((num & SM_FORCE ) == SM_FORCE ){
		flags|=SM_FORCE;
		f->set_virtual(true);
	}
	if((num & SM_OVERRIDE) == SM_OVERRIDE){
		flags|=SM_OVERRIDE;
		f->set_override(true);
	}
	if((num & SM_NEW) == SM_NEW){
		flags|=SM_NEW;
		f->set_new(true);
	}
	if( (num & SM_INTERACTIVE) == SM_INTERACTIVE ){
		flags|=SM_INTERACTIVE;
		SINTAX_ERROR("'interactive' modifier only valid on class declaration.");
	}
	if( (num & SM_FINAL) == SM_FINAL ){
		flags|=SM_FINAL;
		f->set_final(true);
	}
	if( (num & SM_ABSTRACT) == SM_ABSTRACT){
		flags|=SM_ABSTRACT;
		f->set_abstract(true);
	}
	if( (num & SM_KEYWORD) == SM_KEYWORD){
		flags|=SM_KEYWORD;
		f->set_iskeyword(true);
	}
	if( (num & SM_STATIC) == SM_STATIC && (num & SM_EXTERN) == SM_EXTERN){
		flags|=SM_STATIC|SM_EXTERN;
		f->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_STATIC_EXTERN);
	}
	else if( (num & SM_STATIC) == SM_STATIC ){
		flags|=SM_STATIC;
		f->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_STATIC);
	}
	else if( (num & SM_EXTERN) == SM_EXTERN){
		flags|=SM_EXTERN;
		f->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_EXTERN);
	}
	if((num & SM_CONST) == SM_CONST){
		flags|=SM_CONST;
		f->get_ReturnType()->set_const(true);
	}
	if((num & SM_EXEC) == SM_EXEC){
		flags|=SM_EXEC;
		f->get_ReturnType()->set_exec(true);
	}
	if((num & SM_VOLATILE) == SM_VOLATILE){
		flags|=SM_VOLATILE;
		f->get_ReturnType()->set_volatile(true);
	}
	if((num & SM_INAME) == SM_INAME){
		flags|=SM_INAME;
		f->get_ReturnType()->set_ftype(CodeDOM::ZOEFACTORYTYPE_ENUM_INAME);
	}
	if((num & SM_EXPRESSION) == SM_EXPRESSION){
		flags|=SM_EXPRESSION;
		f->get_ReturnType()->set_ftype(CodeDOM::ZOEFACTORYTYPE_ENUM_EXPRESSION);
	}
	if( (num & flags) != num ){//Hay storage modifiers de mas
		SINTAX_ERROR("invalid declaration modifiers on function declaration.");
	}
}


void SetFieldStorage(CodeDOM::XplField*f,unsigned int num){
	unsigned int flags=0;
	if(f==NULL)return;
	if((num & SM_VIRTUAL ) == SM_VIRTUAL ){
		flags|=SM_VIRTUAL;
		SINTAX_ERROR("'virtual' modifier not valid on field declaration.");
	}
	if((num & SM_OVERRIDE) == SM_OVERRIDE){
		flags|=SM_OVERRIDE;
		SINTAX_ERROR("'override' modifier not valid on field declaration.");
	}
	if((num & SM_NEW) == SM_NEW){
		flags|=SM_NEW;
		f->set_new(true);
	}
	if( (num & SM_FINAL) == SM_FINAL ){
		flags|=SM_FINAL;
		SINTAX_ERROR("'final' modifier not valid on field declaration.");
	}
	if((num & SM_ABSTRACT ) == SM_ABSTRACT ){
		flags|=SM_ABSTRACT;
		SINTAX_ERROR("'abstract' modifier not valid on field declaration.");
	}
	if( (num & SM_VOLATILE) == SM_VOLATILE){
		flags|=SM_VOLATILE;
		f->get_type()->set_volatile(true);
	}
	if( (num & SM_CONST) == SM_CONST){
		flags|=SM_CONST;
		f->get_type()->set_const(true);
	}
	if( (num & SM_EXEC) == SM_EXEC){
		flags|=SM_EXEC;
		f->get_type()->set_exec(true);
	}
	if((num & SM_INAME) == SM_INAME){
		flags|=SM_INAME;
		f->get_type()->set_ftype(CodeDOM::ZOEFACTORYTYPE_ENUM_INAME);
	}
	if((num & SM_EXPRESSION) == SM_EXPRESSION){
		flags|=SM_EXPRESSION;
		f->get_type()->set_ftype(CodeDOM::ZOEFACTORYTYPE_ENUM_EXPRESSION);
	}
	if( (num & SM_STATIC) == SM_STATIC && (num & SM_EXTERN) == SM_EXTERN){
		flags|=SM_STATIC|SM_EXTERN;
		f->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_STATIC_EXTERN);
	}
	else if( (num & SM_STATIC) == SM_STATIC ){
		flags|=SM_STATIC;
		f->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_STATIC);
	}
	else if( (num & SM_EXTERN) == SM_EXTERN){
		flags|=SM_EXTERN;
		f->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_EXTERN);
	}
	if( (num & flags) != num ){//Hay storage modifiers de mas
		SINTAX_ERROR("invalid declaration modifiers on field declaration. Use: 'static', 'extern', 'volatile', 'const', 'exec', 'new'.");
	}
}

void SetPropertyStorage(CodeDOM::XplProperty*f,unsigned int num){
	unsigned int flags=0;
	if(f==NULL)return;
	if( (num & SM_FACTORY) == SM_FACTORY ){
		flags|=SM_FACTORY;
		f->set_isfactory(true);
	}
	if((num & SM_VIRTUAL ) == SM_VIRTUAL ){
		flags|=SM_VIRTUAL;
		f->set_virtual(true);
	}
	if((num & SM_ABSTRACT ) == SM_ABSTRACT ){
		flags|=SM_ABSTRACT;
		f->set_abstract(true);
	}
	if((num & SM_NONVIRTUAL ) == SM_NONVIRTUAL ){
		flags|=SM_NONVIRTUAL;
		f->set_nonvirtual(true);
	}
	if((num & SM_OVERRIDE) == SM_OVERRIDE){
		flags|=SM_OVERRIDE;
		f->set_override(true);
	}
	if((num & SM_NEW) == SM_NEW){
		flags|=SM_NEW;
		f->set_new(true);
	}
	if( (num & SM_INTERACTIVE) == SM_INTERACTIVE ){
		flags|=SM_INTERACTIVE;
		SINTAX_ERROR("'interactive' modifier only valid on class declarations.");
	}
	if( (num & SM_FINAL) == SM_FINAL ){
		flags|=SM_FINAL;
		f->set_final(true);
	}
	if( (num & SM_ABSTRACT) == SM_ABSTRACT){
		flags|=SM_ABSTRACT;
		f->set_abstract(true);
	}
	if( (num & SM_KEYWORD) == SM_KEYWORD){
		flags|=SM_KEYWORD;
		SINTAX_ERROR("'keyword' modifier only valid on function declarations.");
	}
	if((num & SM_CONST) == SM_CONST){
		flags|=SM_CONST;
		f->get_type()->set_const(true);
	}
	if((num & SM_EXEC) == SM_EXEC){
		flags|=SM_EXEC;
		f->get_type()->set_exec(true);
	}
	if((num & SM_INAME) == SM_INAME){
		flags|=SM_INAME;
		f->get_type()->set_ftype(CodeDOM::ZOEFACTORYTYPE_ENUM_INAME);
	}
	if((num & SM_EXPRESSION) == SM_EXPRESSION){
		flags|=SM_EXPRESSION;
		f->get_type()->set_ftype(CodeDOM::ZOEFACTORYTYPE_ENUM_EXPRESSION);
	}
	if( (num & SM_STATIC) == SM_STATIC && (num & SM_EXTERN) == SM_EXTERN){
		flags|=SM_STATIC|SM_EXTERN;
		f->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_STATIC_EXTERN);
	}
	else if( (num & SM_STATIC) == SM_STATIC ){
		flags|=SM_STATIC;
		f->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_STATIC);
	}
	else if( (num & SM_EXTERN) == SM_EXTERN){
		flags|=SM_EXTERN;
		f->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_EXTERN);
	}
	if( (num & flags) != num ){//Hay storage modifiers de mas
		SINTAX_ERROR("invalid declaration modifiers on property declaration.");
	}
}
void SetParameterModifiers(CodeDOM::XplParameter*f, unsigned int num){
	unsigned int flags=0;
	if(f==NULL)return;
	if((num & SM_IN) == SM_IN){
		flags|=SM_IN;
		f->set_direction(CodeDOM::ZOEPARAMETERDIRECTION_ENUM_IN);
	}
	else if((num & SM_INOUT) == SM_INOUT){
		flags|=SM_INOUT;
		f->set_direction(CodeDOM::ZOEPARAMETERDIRECTION_ENUM_INOUT);
		//PENDIENTE :
		//Le agrego nivel de puntero de referencia al tipo
		//si no fue declarado explicitamente
	}
	else if((num & SM_OUT) == SM_OUT){
		flags|=SM_OUT;
		f->set_direction(CodeDOM::ZOEPARAMETERDIRECTION_ENUM_OUT);
		//Le agrego un nivel de puntero de referencia al tipo, si
		//no fue declarado explicitamente.
	}
	if((num & SM_PARAMS) == SM_PARAMS){
		flags|=SM_PARAMS;
		f->set_params(true);
	}
	if((num & SM_CONST) == SM_CONST){
		flags|=SM_CONST;
		f->get_type()->set_const(true);
	}
	if((num & SM_EXEC) == SM_EXEC){
		flags|=SM_EXEC;
		f->get_type()->set_exec(true);
	}
	if((num & SM_VOLATILE) == SM_VOLATILE){
		flags|=SM_VOLATILE;
		f->get_type()->set_volatile(true);
	}
	if((num & SM_INAME) == SM_INAME){
		flags|=SM_INAME;
		f->get_type()->set_ftype(CodeDOM::ZOEFACTORYTYPE_ENUM_INAME);
	}
	if((num & SM_EXPRESSION) == SM_EXPRESSION){
		flags|=SM_EXPRESSION;
		f->get_type()->set_ftype(CodeDOM::ZOEFACTORYTYPE_ENUM_EXPRESSION);
	}
	if( (num & flags) != num ){//Hay storage modifiers de mas
		SINTAX_ERROR("invalid declaration modifiers on parameter declaration.");
	}
}
void SetLocalVarsModifiers(CodeDOM::XplDeclarator*f, unsigned int num){
	SetDeclaratorStorage(f,num);
}
void SetNewTypeModifiers(CodeDOM::XplNewExpression*ne, unsigned int num){
	unsigned int flags=0;
	if(ne==NULL)return;
	CodeDOM::XplType*f=ne->get_type();
	if(f==NULL)return;
	/*Elimino el puntero de array en expresiones new*/
	if(f->get_ispointer() && f->get_lddata().empty() && f->get_dt()!=NULL && f->get_dt()->get_isarray()){
		CodeDOM::XplType*old=f;
		ne->set_type(f->get_dt());
		f->set_dt(NULL);		
		delete f;
	}
	if(num==NULL)return;

	if( (num & SM_VOLATILE) == SM_VOLATILE){
		flags|=SM_VOLATILE;
		f->set_volatile(true);
	}
	if( (num & SM_EXEC) == SM_EXEC){
		flags|=SM_EXEC;
		f->set_exec(true);
	}
	if( (num & flags) != num ){//Hay storage modifiers de mas
		SINTAX_ERROR("invalid declaration modifiers on new expression.");
	}
}
void SetDeclaratorStorage(CodeDOM::XplDeclarator*f,unsigned int num){
	unsigned int flags=0;
	if(f==NULL)return;
	/* ESTO DE STATICO Y EXTERNO NO DEBERIA SER VALIDO PARA DECLARACIONES */
	if( (num & SM_STATIC) == SM_STATIC && (num & SM_EXTERN) == SM_EXTERN){
		flags|=SM_STATIC|SM_EXTERN;
		f->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_STATIC_EXTERN);
	}
	else if( (num & SM_STATIC) == SM_STATIC ){
		flags|=SM_STATIC;
		f->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_STATIC);
	}
	else if( (num & SM_EXTERN) == SM_EXTERN){
		flags|=SM_EXTERN;
		f->set_storage(CodeDOM::ZOEVARSTORAGE_ENUM_EXTERN);
	}

	if( (num & SM_VOLATILE) == SM_VOLATILE){
		flags|=SM_VOLATILE;
		f->get_type()->set_volatile(true);
	}
	if( (num & SM_EXEC) == SM_EXEC){
		flags|=SM_EXEC;
		f->get_type()->set_exec(true);
	}
	if( (num & SM_CONST) == SM_CONST){
		flags|=SM_CONST;
		f->get_type()->set_const(true);
	}
	if((num & SM_INAME) == SM_INAME){
		flags|=SM_INAME;
		f->get_type()->set_ftype(CodeDOM::ZOEFACTORYTYPE_ENUM_INAME);
	}
	if((num & SM_EXPRESSION) == SM_EXPRESSION){
		flags|=SM_EXPRESSION;
		f->get_type()->set_ftype(CodeDOM::ZOEFACTORYTYPE_ENUM_EXPRESSION);
	}
	if( (num & flags) != num ){//Hay storage modifiers de mas
		SINTAX_ERROR("invalid declaration modifiers on local declaration.");
	}
}

CodeDOM::XplClass* CreateClass(
	CodeDOM::string nombre, CodeDOM::XplNodeList* classMembers,
	CodeDOM::XplNode* inherits, CodeDOM::XplNode* implements,
	unsigned int tipo, unsigned int modifiers)
{
	CodeDOM::XplClass*c=CodeDOM::XplNamespace::new_Class();
	CodeDOM::XplNodeList*list=classMembers;
	c->set_name(nombre);
	c->Childs()->InsertAtEnd(inherits);
	c->Childs()->InsertAtEnd(implements);
	
	CodeDOM::XplType* typeOfEnum = NULL;
	
	switch(tipo){
		case PC_CLASS:
			break;
		case PC_STRUCT:
			c->set_isstruct(true);
			break;
		case PC_INTERFACE:
			c->set_isinterface(true);
			break;
		case PC_UNION:
			c->set_isunion(true);
			break;
		case PC_ENUM:
			c->set_isenum(true);
			break;
	}

	if(list!=NULL){
		SetClassMembers(c->Childs(),list,c->get_isinterface());
		list->Clear();
		delete list;
	}

	SetDeclaratorMod(c,modifiers);
	return c;
}

CodeDOM::XplForStatement* CreateFor(CodeDOM::XplNode* p_forinit,CodeDOM::XplNode* p_condition,CodeDOM::XplNode* p_update,CodeDOM::XplNode* p_statement){
	CodeDOM::XplForStatement* fs=CodeDOM::XplFunctionBody::new_for();
	CodeDOM::XplFunctionBody*fbk=NULL;
	if(p_statement!=NULL){
		if(p_statement->get_TypeName()==CodeDOM::CODEDOMTYPES_ZOEFUNCTIONBODY){
			fbk=(CodeDOM::XplFunctionBody*)p_statement;
		}
		else{
			fbk=CodeDOM::XplForStatement::new_forblock();
			fbk->Childs()->InsertAtEnd(p_statement);
		}
		fs->set_forblock((CodeDOM::XplFunctionBody*)fbk);
	}
	if(p_forinit!=NULL)fs->set_init((CodeDOM::XplForinit*)p_forinit);
	if(p_condition!=NULL){
		fs->set_condition(CodeDOM::XplForStatement::new_condition());
		fs->get_condition()->set_texpression(p_condition);
	}
	if(p_update!=NULL)fs->set_repeat((CodeDOM::XplExpressionlist*)p_update);
	return fs;
}

wchar_t* get_nativeType(unsigned num){
	switch(num){
		case PC_VOID:
			return DT("$VOID$");
		case PC_OBJECT:
			return DT("$OBJECT$");
		case PC_INT:
			return DT("$INTEGER$");
		case PC_SHORT:
			return DT("$SHORT$");
		case PC_LONG:
			return DT("$LONG$");
		case PC_UINT:
		case PC_UNSIGNED:
			return DT("$UNSIGNED$");
		case PC_FLOAT:
			return DT("$FLOAT$");
		case PC_DOUBLE:
			return DT("$DOUBLE$");
		case PC_CHAR:
			return DT("$CHAR$");
		case PC_ASCII_CHAR:
			return DT("$ASCIICHAR$");
		case PC_STRING:
			return DT("$STRING$");
		case PC_ASCII_STRING:
			return DT("$ASCIISTRING$");
		case PC_TYPE:
			return DT("$TYPE$");
		case PC_USHORT:
			return DT("$USHORT$");
		case PC_ULONG:
			return DT("$ULONG$");
		case PC_SBYTE:
			return DT("$SBYTE$");
		case PC_BYTE:
			return DT("$BYTE$");
		case PC_DECIMAL:
			return DT("$DECIMAL$");
		case PC_BOOL:
			return DT("$BOOLEAN$");
		case PC_BLOCK:
			return DT("$BLOCK$");
		default:
			WARNING_MESSAGE("Internal: base type unknow. Using 'int'.");
			return DT("$INTEGER$");
	};
}

void SetEnumConstantTypes(CodeDOM::XplClass*clase,unsigned int tipo){
	if(NULL!=clase->Childs()){
		for(CodeDOM::XplNode*n=clase->Childs()->FirstNode();n!=NULL;n=clase->Childs()->NextNode()){
			if(n->get_ElementName()==DT("Field")){
				CodeDOM::XplField*field=(CodeDOM::XplField*)n;
				CodeDOM::XplType*type=CodeDOM::XplField::new_type();
				field->set_type(type);
				type->set_const(true);
				switch(tipo){
					case PC_INT:
						type->set_typename(get_nativeType(PC_INT));
						break;
					case PC_UINT:
					case PC_UNSIGNED:
						type->set_typename(get_nativeType(PC_UNSIGNED));
						break;
					case PC_LONG:
						type->set_typename(get_nativeType(PC_LONG));
						break;
					case PC_ULONG:
						type->set_typename(get_nativeType(PC_ULONG));
						break;
					case PC_SHORT:
						type->set_typename(get_nativeType(PC_SHORT));
						break;
					case PC_USHORT:
						type->set_typename(get_nativeType(PC_USHORT));
						break;
				}
			}
		} //for
	} //if
}
/*
Inserta "typeToInsert" como tipo derivado más profundo en type;

No llamar con tipos nulos!!
*/
void SetInnerType(CodeDOM::XplType* type, CodeDOM::XplType* typeToInsert){
	if(type->get_dt()==NULL){
		type->set_dt(typeToInsert);
	}
	else{
		SetInnerType(type->get_dt(), typeToInsert);
	}
}
/*
Inserta "typeName" como nombre de tipo en el tipo mas profundo;

No llamar con tipos nulos!!
*/
void SetInnerTypeName(CodeDOM::XplType* type, wchar_t* typeName){
	if(type->get_dt()==NULL){
		CodeDOM::XplType* innerType=CodeDOM::XplType::new_dt();		
		innerType->set_typename(typeName);
		type->set_dt(innerType);
	}
	else{
		SetInnerTypeName(type->get_dt(), typeName);
	}
}
/******************************************************************************
*     FUNCION BASURA PARA PRUEBA DEL CODEDOM
*******************************************************************************/

void CodeDOM_Test(){
	CodeDOM::XplNode* node=new CodeDOM::XplNode();

}
