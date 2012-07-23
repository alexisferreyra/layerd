/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 8/11/2011 4:27:19 PM
 *
 *	Generado por Zoe CodeDOM Generator para C#.
 *	COPYRIGHT 2002,2005-2006. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

using System;

namespace LayerD.CodeDOM{
	class CDOM_BinaryNodeReader{
		public static XplNode Read(XplBinaryReader reader, XplNode parent){
			XplNode retNode = null;
			switch(reader.ReadInt32()){
				case 1: //XplNode
					retNode = new XplNode();
					break;
				case 100: //XplField
					retNode = new XplField();
					break;
				case 101: //XplSetPlatforms
					retNode = new XplSetPlatforms();
					break;
				case 102: //XplFunctioncall
					retNode = new XplFunctioncall();
					break;
				case 103: //XplInherits
					retNode = new XplInherits();
					break;
				case 104: //XplPlatform
					retNode = new XplPlatform();
					break;
				case 105: //XplLayerDCompiler
					retNode = new XplLayerDCompiler();
					break;
				case 106: //XplLanguage
					retNode = new XplLanguage();
					break;
				case 107: //XplOutputModuleCapabilities
					retNode = new XplOutputModuleCapabilities();
					break;
				case 108: //XplBaseInitializer
					retNode = new XplBaseInitializer();
					break;
				case 109: //XplAssing
					retNode = new XplAssing();
					break;
				case 110: //XplInitializerList
					retNode = new XplInitializerList();
					break;
				case 111: //XplTargetPlatform
					retNode = new XplTargetPlatform();
					break;
				case 112: //XplType
					retNode = new XplType();
					break;
				case 113: //XplTryStatement
					retNode = new XplTryStatement();
					break;
				case 114: //XplUnaryoperator
					retNode = new XplUnaryoperator();
					break;
				case 115: //XplTernaryoperator
					retNode = new XplTernaryoperator();
					break;
				case 116: //XplDirectoutput
					retNode = new XplDirectoutput();
					break;
				case 117: //XplCatchStatement
					retNode = new XplCatchStatement();
					break;
				case 118: //XplExpressionlist
					retNode = new XplExpressionlist();
					break;
				case 119: //XplDeclaratorlist
					retNode = new XplDeclaratorlist();
					break;
				case 120: //XplFileData
					retNode = new XplFileData();
					break;
				case 121: //XplNamespace
					retNode = new XplNamespace();
					break;
				case 122: //XplExtendedLayerDZoeRequirementsConfig
					retNode = new XplExtendedLayerDZoeRequirementsConfig();
					break;
				case 123: //XplDocumentation
					retNode = new XplDocumentation();
					break;
				case 124: //XplPointerinfo
					retNode = new XplPointerinfo();
					break;
				case 125: //XplLayerDZoeProgramConfig
					retNode = new XplLayerDZoeProgramConfig();
					break;
				case 126: //XplCatchinit
					retNode = new XplCatchinit();
					break;
				case 127: //XplConfig
					retNode = new XplConfig();
					break;
				case 128: //XplDocumentBody
					retNode = new XplDocumentBody();
					break;
				case 129: //XplIfStatement
					retNode = new XplIfStatement();
					break;
				case 130: //XplClassfactorysPermissions
					retNode = new XplClassfactorysPermissions();
					break;
				case 131: //XplJump
					retNode = new XplJump();
					break;
				case 132: //XplSetonerror
					retNode = new XplSetonerror();
					break;
				case 133: //XplExpression
					retNode = new XplExpression();
					break;
				case 134: //XplLayerDErrorInterchangeConfig
					retNode = new XplLayerDErrorInterchangeConfig();
					break;
				case 135: //XplBinaryoperator
					retNode = new XplBinaryoperator();
					break;
				case 136: //XplDeclarator
					retNode = new XplDeclarator();
					break;
				case 137: //XplCastexpression
					retNode = new XplCastexpression();
					break;
				case 138: //XplInherit
					retNode = new XplInherit();
					break;
				case 139: //XplSwitchStatement
					retNode = new XplSwitchStatement();
					break;
				case 140: //XplFunction
					retNode = new XplFunction();
					break;
				case 141: //FactoryTypesDatabase
					retNode = new FactoryTypesDatabase();
					break;
				case 142: //XplExtendedLayerDZoeDocumentConfig
					retNode = new XplExtendedLayerDZoeDocumentConfig();
					break;
				case 143: //XplError
					retNode = new XplError();
					break;
				case 144: //XplForinit
					retNode = new XplForinit();
					break;
				case 145: //XplDocumentData
					retNode = new XplDocumentData();
					break;
				case 146: //XplParameters
					retNode = new XplParameters();
					break;
				case 147: //XplWriteCodeBody
					retNode = new XplWriteCodeBody();
					break;
				case 148: //XplCexpression
					retNode = new XplCexpression();
					break;
				case 149: //XplComplexfunctioncall
					retNode = new XplComplexfunctioncall();
					break;
				case 150: //XplNewExpression
					retNode = new XplNewExpression();
					break;
				case 151: //XplName
					retNode = new XplName();
					break;
				case 152: //XplForStatement
					retNode = new XplForStatement();
					break;
				case 153: //XplClassMembersList
					retNode = new XplClassMembersList();
					break;
				case 154: //XplFunctionBody
					retNode = new XplFunctionBody();
					break;
				case 155: //XplImportProcessConfig
					retNode = new XplImportProcessConfig();
					break;
				case 156: //XplLayerDZoeDocumentConfig
					retNode = new XplLayerDZoeDocumentConfig();
					break;
				case 157: //XplSourceFile
					retNode = new XplSourceFile();
					break;
				case 158: //XplCopyright
					retNode = new XplCopyright();
					break;
				case 159: //XplDocument
					retNode = new XplDocument();
					break;
				case 160: //XplClass
					retNode = new XplClass();
					break;
				case 161: //XplProperty
					retNode = new XplProperty();
					break;
				case 162: //XplCase
					retNode = new XplCase();
					break;
				case 163: //XplLayerDZoeProgramRequirements
					retNode = new XplLayerDZoeProgramRequirements();
					break;
				case 164: //XplGarbageCollector
					retNode = new XplGarbageCollector();
					break;
				case 165: //XplPlatformAlias
					retNode = new XplPlatformAlias();
					break;
				case 166: //XplLiteral
					retNode = new XplLiteral();
					break;
				case 167: //ClassfactoryData
					retNode = new ClassfactoryData();
					break;
				case 168: //XplInfoLayerZoeOutputModuleConfig
					retNode = new XplInfoLayerZoeOutputModuleConfig();
					break;
				case 169: //XplParameter
					retNode = new XplParameter();
					break;
				case 170: //XplAutoInstance
					retNode = new XplAutoInstance();
					break;
				case 171: //XplDowhileStatement
					retNode = new XplDowhileStatement();
					break;
				case 172: //XplBaseInitializers
					retNode = new XplBaseInitializers();
					break;
			}
			retNode.set_Parent(parent);
			return retNode.BinaryRead(reader);
		}
	}

	public enum CodeDOMTypes {
		XplNodeList = 1000, 
		Empty = 0, 
		XplNode = 1, 
		String = 2, 
		Integer = 3, 
		Unsigned = 4, 
		DateTime = 5, 
		Boolean = 6, 
		XplField = 100, 
		XplSetPlatforms = 101, 
		XplFunctioncall = 102, 
		XplInherits = 103, 
		XplPlatform = 104, 
		XplLayerDCompiler = 105, 
		XplLanguage = 106, 
		XplOutputModuleCapabilities = 107, 
		XplBaseInitializer = 108, 
		XplAssing = 109, 
		XplInitializerList = 110, 
		XplTargetPlatform = 111, 
		XplType = 112, 
		XplTryStatement = 113, 
		XplUnaryoperator = 114, 
		XplTernaryoperator = 115, 
		XplDirectoutput = 116, 
		XplCatchStatement = 117, 
		XplExpressionlist = 118, 
		XplDeclaratorlist = 119, 
		XplFileData = 120, 
		XplNamespace = 121, 
		XplExtendedLayerDZoeRequirementsConfig = 122, 
		XplDocumentation = 123, 
		XplPointerinfo = 124, 
		XplLayerDZoeProgramConfig = 125, 
		XplCatchinit = 126, 
		XplConfig = 127, 
		XplDocumentBody = 128, 
		XplIfStatement = 129, 
		XplClassfactorysPermissions = 130, 
		XplJump = 131, 
		XplSetonerror = 132, 
		XplExpression = 133, 
		XplLayerDErrorInterchangeConfig = 134, 
		XplBinaryoperator = 135, 
		XplDeclarator = 136, 
		XplCastexpression = 137, 
		XplInherit = 138, 
		XplSwitchStatement = 139, 
		XplFunction = 140, 
		FactoryTypesDatabase = 141, 
		XplExtendedLayerDZoeDocumentConfig = 142, 
		XplError = 143, 
		XplForinit = 144, 
		XplDocumentData = 145, 
		XplParameters = 146, 
		XplWriteCodeBody = 147, 
		XplCexpression = 148, 
		XplComplexfunctioncall = 149, 
		XplNewExpression = 150, 
		XplName = 151, 
		XplForStatement = 152, 
		XplClassMembersList = 153, 
		XplFunctionBody = 154, 
		XplImportProcessConfig = 155, 
		XplLayerDZoeDocumentConfig = 156, 
		XplSourceFile = 157, 
		XplCopyright = 158, 
		XplDocument = 159, 
		XplClass = 160, 
		XplProperty = 161, 
		XplCase = 162, 
		XplLayerDZoeProgramRequirements = 163, 
		XplGarbageCollector = 164, 
		XplPlatformAlias = 165, 
		XplLiteral = 166, 
		ClassfactoryData = 167, 
		XplInfoLayerZoeOutputModuleConfig = 168, 
		XplParameter = 169, 
		XplAutoInstance = 170, 
		XplDowhileStatement = 171, 
		XplBaseInitializers = 172, 
	}
	[Serializable]
	public enum XplDocumenttype_enum:int{LAYERD_ZOE_DOC,LAYERD_EZOE_DOC,LAYERD_ZOE_PROG,IMPORT_PROCESS,INFOLDZOE_OUTPUTMODULE,REQUIREMENTS_EZOE,ERRORS_INTERCHANGE_DOC,VIRTUAL_SUBPROGRAM_LAYERD_ZOE,PARAMETER_DOCUMENT_LAYERD_ZOE}
	[Serializable]
	public enum XplErrorsourcetype_enum:int{ZOE_DOC,LAYERD_DOC,OUTPUTMODULE_IMPORT,OUTPUTMODULE_RENDER,OUTPUTMOUDLE_COMPILE,ZOE_EZOE_GENERATION,OTHER}
	[Serializable]
	public enum XplPlatformMatch_enum:int{LIKE,EXACTNAME,EXACTNAMEANDVERSION,LIKENAMEANDEXACTVERSION,CUSTOMMATCH}
	[Serializable]
	public enum XplCasttype_enum:int{STATIC,DYNAMIC,CONST,REINTERPRET,OTHER}
	[Serializable]
	public enum XplFactorytype_enum:int{NONE,INAME,EXPRESSION,EXPRESSIONLIST,STATEMENT}
	[Serializable]
	public enum XplJumptype_enum:int{BREAK,CONTINUE,RESUME,RESUMENEXT,GOTO}
	[Serializable]
	public enum XplBitorder_enum:int{LITTLE_ENDIAN,BIG_ENDIAN,IGNORE}
	[Serializable]
	public enum XplTernaryoperators_enum:int{BOOLEAN,RESERVED}
	[Serializable]
	public enum XplDocsourcetype_enum:int{XML,HTML,ZOE,TEXT,OTHER}
	[Serializable]
	public enum XplTypename_enum:int{INTEGER,UNSIGNED,LONG,ULONG,SHORT,USHORT,SBYTE,BYTE,FLOAT,DOUBLE,LDOUBLE,DECIMAL,FIXED,BOOLEAN,CHAR,STRING,ASCIICHAR,ASCIISTRING,DATE,UUID,VOID,OBJECT,TYPE,BLOCK}
	[Serializable]
	public enum XplLiteraltype_enum:int{STRING,ASCIISTRING,CHAR,ASCIICHAR,BOOL,INTEGER,REAL,FLOAT,DOUBLE,DECIMAL,OCT,HEX,DATETIME,UUID,NULL,OTHER}
	[Serializable]
	public enum XplAssingop_enum:int{NONE,ADD,SUB,MUL,DIV,MOD,LSH,RSH,AND,XOR,OR}
	[Serializable]
	public enum XplAccesstype_enum:int{INTERNAL,PUBLIC,PROTECTED,PRIVATE,IINTERNAL,IPUBLIC,IPROTECTED,IPRIVATE}
	[Serializable]
	public enum XplLayerDZoeProgramModuletype_enum:int{EXECUTABLE,STATIC_LIB,DYNAMIC_LIB,SCRIPT,OTHER}
	[Serializable]
	public enum XplPointertype_enum:int{C_NATIVE,DEFAULT,SAFECLASS}
	[Serializable]
	public enum XplBinaryoperators_enum:int{ADD,MIN,MUL,DIV,MOD,EXP,LSH,RSH,AND,OR,EQ,NOTEQ,GR,LS,GREQ,LSEQ,BAND,BOR,XOR,M,PM,MP,PMP,MS,MSM,RM,IMP,COMMA}
	[Serializable]
	public enum XplUnaryoperators_enum:int{MIN,INC,DEC,PREINC,PREDEC,IND,AOF,RAOF,SIZEOF,TYPEOF,ONECOMP,NOT}
	[Serializable]
	public enum XplAutoInstaceTypes_enum:int{CALL,BLOCK,CALLTOFUNCTION,CLASS,NAMESPACE,VIRTUALSECTION}
	[Serializable]
	public enum XplPlatformsupportlevel_enum:int{COMPLETE,COMPLETE_BETA,COMPLETE_ALPHA,INCOMPLETE,INCOMPLETE_BETA,INCOMPLETE_ALPHA,EXPERIMENTAL,EXPERIMENTAL_BETA,EXPERIMENTAL_ALPHA,POSSIBLY_TESTED,POSSIBLY_NONTESTED,EXPLICITLY_UNSUPPORTED}
	[Serializable]
	public enum XplVarstorage_enum:int{AUTO,STATIC,EXTERN,STATIC_EXTERN}
	[Serializable]
	public enum XplParameterdirection_enum:int{IN,OUT,INOUT}
	[Serializable]
	public enum XplMemorymodel_enum:int{LINEAL,SEGMENTED,OTHER}

	public class CodeDOM_STV{

		static public string []XPLDOCUMENTTYPE_ENUM={"layerd_zoe_doc","layerd_ezoe_doc","layerd_zoe_prog","import_process","infoldzoe_outputmodule","requirements_ezoe","errors_interchange_doc","virtual_subprogram_layerd_zoe","parameter_document_layerd_zoe"};
		static public string []XPLERRORSOURCETYPE_ENUM={"zoe_doc","layerd_doc","outputmodule_import","outputmodule_render","outputmoudle_compile","zoe_ezoe_generation","other"};
		static public string []XPLPLATFORMMATCH_ENUM={"like","exactName","exactNameAndVersion","likeNameAndExactVersion","customMatch"};
		static public string []XPLCASTTYPE_ENUM={"static","dynamic","const","reinterpret","other"};
		static public string []XPLFACTORYTYPE_ENUM={"none","iname","expression","expressionlist","statement"};
		static public string []XPLJUMPTYPE_ENUM={"break","continue","resume","resumenext","goto"};
		static public string []XPLBITORDER_ENUM={"little_endian","big_endian","ignore"};
		static public string []XPLTERNARYOPERATORS_ENUM={"boolean","reserved"};
		static public string []XPLDOCSOURCETYPE_ENUM={"XML","HTML","ZOE","TEXT","OTHER"};
		static public string []XPLTYPENAME_ENUM={"integer","unsigned","long","ulong","short","ushort","sbyte","byte","float","double","ldouble","decimal","fixed","boolean","char","string","ASCIIchar","ASCIIstring","date","uuid","void","object","type","block"};
		static public string []XPLLITERALTYPE_ENUM={"string","ASCIIstring","char","ASCIIchar","bool","integer","real","float","double","decimal","oct","hex","datetime","UUID","null","other"};
		static public string []XPLASSINGOP_ENUM={"none","add","sub","mul","div","mod","lsh","rsh","and","xor","or"};
		static public string []XPLACCESSTYPE_ENUM={"internal","public","protected","private","iinternal","ipublic","iprotected","iprivate"};
		static public string []XPLLAYERDZOEPROGRAMMODULETYPE_ENUM={"executable","static_lib","dynamic_lib","script","other"};
		static public string []XPLPOINTERTYPE_ENUM={"c_native","default","safeclass"};
		static public string []XPLBINARYOPERATORS_ENUM={"add","min","mul","div","mod","exp","lsh","rsh","AND","OR","EQ","NOTEQ","GR","LS","GREQ","LSEQ","BAND","BOR","XOR","m","pm","mp","pmp","ms","msm","rm","imp","comma"};
		static public string []XPLUNARYOPERATORS_ENUM={"min","inc","dec","preinc","predec","ind","aof","raof","sizeof","typeof","onecomp","not"};
		static public string []XPLAUTOINSTACETYPES_ENUM={"call","block","callToFunction","class","namespace","virtualSection"};
		static public string []XPLPLATFORMSUPPORTLEVEL_ENUM={"complete","complete_beta","complete_alpha","incomplete","incomplete_beta","incomplete_alpha","experimental","experimental_beta","experimental_alpha","possibly_tested","possibly_nontested","explicitly_unsupported"};
		static public string []XPLVARSTORAGE_ENUM={"auto","static","extern","static_extern"};
		static public string []XPLPARAMETERDIRECTION_ENUM={"in","out","inout"};
		static public string []XPLMEMORYMODEL_ENUM={"lineal","segmented","other"};

	}

}

/*-------Fin de Archivo Generado------------------*/

