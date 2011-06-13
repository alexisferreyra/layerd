/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 3/2/2010 9:11:42 PM
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
				case 100: //XplExtendedLayerDZoeRequirementsConfig
					retNode = new XplExtendedLayerDZoeRequirementsConfig();
					break;
				case 101: //XplCastexpression
					retNode = new XplCastexpression();
					break;
				case 102: //XplOutputModuleCapabilities
					retNode = new XplOutputModuleCapabilities();
					break;
				case 103: //XplClassMembersList
					retNode = new XplClassMembersList();
					break;
				case 104: //XplCase
					retNode = new XplCase();
					break;
				case 105: //XplWriteCodeBody
					retNode = new XplWriteCodeBody();
					break;
				case 106: //XplInherits
					retNode = new XplInherits();
					break;
				case 107: //XplTargetPlatform
					retNode = new XplTargetPlatform();
					break;
				case 108: //XplDocument
					retNode = new XplDocument();
					break;
				case 109: //XplFunctionBody
					retNode = new XplFunctionBody();
					break;
				case 110: //XplCatchStatement
					retNode = new XplCatchStatement();
					break;
				case 111: //XplType
					retNode = new XplType();
					break;
				case 112: //XplPlatform
					retNode = new XplPlatform();
					break;
				case 113: //XplSourceFile
					retNode = new XplSourceFile();
					break;
				case 114: //XplExpressionlist
					retNode = new XplExpressionlist();
					break;
				case 115: //XplAssing
					retNode = new XplAssing();
					break;
				case 116: //XplTernaryoperator
					retNode = new XplTernaryoperator();
					break;
				case 117: //XplParameter
					retNode = new XplParameter();
					break;
				case 118: //XplCatchinit
					retNode = new XplCatchinit();
					break;
				case 119: //XplPlatformAlias
					retNode = new XplPlatformAlias();
					break;
				case 120: //FactoryTypesDatabase
					retNode = new FactoryTypesDatabase();
					break;
				case 121: //XplProperty
					retNode = new XplProperty();
					break;
				case 122: //XplDeclarator
					retNode = new XplDeclarator();
					break;
				case 123: //XplFileData
					retNode = new XplFileData();
					break;
				case 124: //XplCexpression
					retNode = new XplCexpression();
					break;
				case 125: //XplName
					retNode = new XplName();
					break;
				case 126: //XplPointerinfo
					retNode = new XplPointerinfo();
					break;
				case 127: //XplSwitchStatement
					retNode = new XplSwitchStatement();
					break;
				case 128: //XplClassfactorysPermissions
					retNode = new XplClassfactorysPermissions();
					break;
				case 129: //XplParameters
					retNode = new XplParameters();
					break;
				case 130: //XplLayerDZoeProgramRequirements
					retNode = new XplLayerDZoeProgramRequirements();
					break;
				case 131: //XplAutoInstance
					retNode = new XplAutoInstance();
					break;
				case 132: //XplLayerDZoeDocumentConfig
					retNode = new XplLayerDZoeDocumentConfig();
					break;
				case 133: //XplSetPlatforms
					retNode = new XplSetPlatforms();
					break;
				case 134: //XplFunctioncall
					retNode = new XplFunctioncall();
					break;
				case 135: //XplForStatement
					retNode = new XplForStatement();
					break;
				case 136: //XplDocumentBody
					retNode = new XplDocumentBody();
					break;
				case 137: //XplDocumentation
					retNode = new XplDocumentation();
					break;
				case 138: //XplBinaryoperator
					retNode = new XplBinaryoperator();
					break;
				case 139: //XplConfig
					retNode = new XplConfig();
					break;
				case 140: //XplDeclaratorlist
					retNode = new XplDeclaratorlist();
					break;
				case 141: //XplExtendedLayerDZoeDocumentConfig
					retNode = new XplExtendedLayerDZoeDocumentConfig();
					break;
				case 142: //XplImportProcessConfig
					retNode = new XplImportProcessConfig();
					break;
				case 143: //XplExpression
					retNode = new XplExpression();
					break;
				case 144: //XplInherit
					retNode = new XplInherit();
					break;
				case 145: //XplInfoLayerZoeOutputModuleConfig
					retNode = new XplInfoLayerZoeOutputModuleConfig();
					break;
				case 146: //XplSetonerror
					retNode = new XplSetonerror();
					break;
				case 147: //XplInitializerList
					retNode = new XplInitializerList();
					break;
				case 148: //XplJump
					retNode = new XplJump();
					break;
				case 149: //XplCopyright
					retNode = new XplCopyright();
					break;
				case 150: //XplNamespace
					retNode = new XplNamespace();
					break;
				case 151: //XplNewExpression
					retNode = new XplNewExpression();
					break;
				case 152: //XplForinit
					retNode = new XplForinit();
					break;
				case 153: //XplLayerDErrorInterchangeConfig
					retNode = new XplLayerDErrorInterchangeConfig();
					break;
				case 154: //XplTryStatement
					retNode = new XplTryStatement();
					break;
				case 155: //XplLanguage
					retNode = new XplLanguage();
					break;
				case 156: //XplDowhileStatement
					retNode = new XplDowhileStatement();
					break;
				case 157: //XplDocumentData
					retNode = new XplDocumentData();
					break;
				case 158: //XplDirectoutput
					retNode = new XplDirectoutput();
					break;
				case 159: //XplLayerDZoeProgramConfig
					retNode = new XplLayerDZoeProgramConfig();
					break;
				case 160: //XplIfStatement
					retNode = new XplIfStatement();
					break;
				case 161: //XplFunction
					retNode = new XplFunction();
					break;
				case 162: //XplField
					retNode = new XplField();
					break;
				case 163: //XplBaseInitializers
					retNode = new XplBaseInitializers();
					break;
				case 164: //XplClass
					retNode = new XplClass();
					break;
				case 165: //XplUnaryoperator
					retNode = new XplUnaryoperator();
					break;
				case 166: //XplLiteral
					retNode = new XplLiteral();
					break;
				case 167: //ClassfactoryData
					retNode = new ClassfactoryData();
					break;
				case 168: //XplBaseInitializer
					retNode = new XplBaseInitializer();
					break;
				case 169: //XplError
					retNode = new XplError();
					break;
				case 170: //XplComplexfunctioncall
					retNode = new XplComplexfunctioncall();
					break;
				case 171: //XplGarbageCollector
					retNode = new XplGarbageCollector();
					break;
				case 172: //XplLayerDCompiler
					retNode = new XplLayerDCompiler();
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
		XplExtendedLayerDZoeRequirementsConfig = 100, 
		XplCastexpression = 101, 
		XplOutputModuleCapabilities = 102, 
		XplClassMembersList = 103, 
		XplCase = 104, 
		XplWriteCodeBody = 105, 
		XplInherits = 106, 
		XplTargetPlatform = 107, 
		XplDocument = 108, 
		XplFunctionBody = 109, 
		XplCatchStatement = 110, 
		XplType = 111, 
		XplPlatform = 112, 
		XplSourceFile = 113, 
		XplExpressionlist = 114, 
		XplAssing = 115, 
		XplTernaryoperator = 116, 
		XplParameter = 117, 
		XplCatchinit = 118, 
		XplPlatformAlias = 119, 
		FactoryTypesDatabase = 120, 
		XplProperty = 121, 
		XplDeclarator = 122, 
		XplFileData = 123, 
		XplCexpression = 124, 
		XplName = 125, 
		XplPointerinfo = 126, 
		XplSwitchStatement = 127, 
		XplClassfactorysPermissions = 128, 
		XplParameters = 129, 
		XplLayerDZoeProgramRequirements = 130, 
		XplAutoInstance = 131, 
		XplLayerDZoeDocumentConfig = 132, 
		XplSetPlatforms = 133, 
		XplFunctioncall = 134, 
		XplForStatement = 135, 
		XplDocumentBody = 136, 
		XplDocumentation = 137, 
		XplBinaryoperator = 138, 
		XplConfig = 139, 
		XplDeclaratorlist = 140, 
		XplExtendedLayerDZoeDocumentConfig = 141, 
		XplImportProcessConfig = 142, 
		XplExpression = 143, 
		XplInherit = 144, 
		XplInfoLayerZoeOutputModuleConfig = 145, 
		XplSetonerror = 146, 
		XplInitializerList = 147, 
		XplJump = 148, 
		XplCopyright = 149, 
		XplNamespace = 150, 
		XplNewExpression = 151, 
		XplForinit = 152, 
		XplLayerDErrorInterchangeConfig = 153, 
		XplTryStatement = 154, 
		XplLanguage = 155, 
		XplDowhileStatement = 156, 
		XplDocumentData = 157, 
		XplDirectoutput = 158, 
		XplLayerDZoeProgramConfig = 159, 
		XplIfStatement = 160, 
		XplFunction = 161, 
		XplField = 162, 
		XplBaseInitializers = 163, 
		XplClass = 164, 
		XplUnaryoperator = 165, 
		XplLiteral = 166, 
		ClassfactoryData = 167, 
		XplBaseInitializer = 168, 
		XplError = 169, 
		XplComplexfunctioncall = 170, 
		XplGarbageCollector = 171, 
		XplLayerDCompiler = 172, 
	}
	[Serializable]
	public enum XplPlatformsupportlevel_enum:int{COMPLETE,COMPLETE_BETA,COMPLETE_ALPHA,INCOMPLETE,INCOMPLETE_BETA,INCOMPLETE_ALPHA,EXPERIMENTAL,EXPERIMENTAL_BETA,EXPERIMENTAL_ALPHA,POSSIBLY_TESTED,POSSIBLY_NONTESTED,EXPLICITLY_UNSUPPORTED}
	[Serializable]
	public enum XplDocsourcetype_enum:int{XML,HTML,ZOE,TEXT,OTHER}
	[Serializable]
	public enum XplFactorytype_enum:int{NONE,INAME,EXPRESSION,EXPRESSIONLIST,STATEMENT}
	[Serializable]
	public enum XplBitorder_enum:int{LITTLE_ENDIAN,BIG_ENDIAN,IGNORE}
	[Serializable]
	public enum XplMemorymodel_enum:int{LINEAL,SEGMENTED,OTHER}
	[Serializable]
	public enum XplLiteraltype_enum:int{STRING,ASCIISTRING,CHAR,ASCIICHAR,BOOL,INTEGER,REAL,FLOAT,DOUBLE,DECIMAL,OCT,HEX,DATETIME,UUID,NULL,OTHER}
	[Serializable]
	public enum XplDocumenttype_enum:int{LAYERD_ZOE_DOC,LAYERD_EZOE_DOC,LAYERD_ZOE_PROG,IMPORT_PROCESS,INFOLDZOE_OUTPUTMODULE,REQUIREMENTS_EZOE,ERRORS_INTERCHANGE_DOC,VIRTUAL_SUBPROGRAM_LAYERD_ZOE,PARAMETER_DOCUMENT_LAYERD_ZOE}
	[Serializable]
	public enum XplJumptype_enum:int{BREAK,CONTINUE,RESUME,RESUMENEXT,GOTO}
	[Serializable]
	public enum XplPointertype_enum:int{C_NATIVE,DEFAULT,SAFECLASS}
	[Serializable]
	public enum XplUnaryoperators_enum:int{MIN,INC,DEC,PREINC,PREDEC,IND,AOF,RAOF,SIZEOF,TYPEOF,ONECOMP,NOT}
	[Serializable]
	public enum XplErrorsourcetype_enum:int{ZOE_DOC,LAYERD_DOC,OUTPUTMODULE_IMPORT,OUTPUTMODULE_RENDER,OUTPUTMOUDLE_COMPILE,ZOE_EZOE_GENERATION,OTHER}
	[Serializable]
	public enum XplTypename_enum:int{INTEGER,UNSIGNED,LONG,ULONG,SHORT,USHORT,SBYTE,BYTE,FLOAT,DOUBLE,LDOUBLE,DECIMAL,FIXED,BOOLEAN,CHAR,STRING,ASCIICHAR,ASCIISTRING,DATE,UUID,VOID,OBJECT,TYPE,BLOCK}
	[Serializable]
	public enum XplVarstorage_enum:int{AUTO,STATIC,EXTERN,STATIC_EXTERN}
	[Serializable]
	public enum XplTernaryoperators_enum:int{BOOLEAN,RESERVED}
	[Serializable]
	public enum XplAccesstype_enum:int{INTERNAL,PUBLIC,PROTECTED,PRIVATE,IINTERNAL,IPUBLIC,IPROTECTED,IPRIVATE}
	[Serializable]
	public enum XplLayerDZoeProgramModuletype_enum:int{EXECUTABLE,STATIC_LIB,DYNAMIC_LIB,SCRIPT,OTHER}
	[Serializable]
	public enum XplBinaryoperators_enum:int{ADD,MIN,MUL,DIV,MOD,EXP,LSH,RSH,AND,OR,EQ,NOTEQ,GR,LS,GREQ,LSEQ,BAND,BOR,XOR,M,PM,MP,PMP,MS,MSM,RM,IMP}
	[Serializable]
	public enum XplCasttype_enum:int{STATIC,DYNAMIC,CONST,REINTERPRET,OTHER}
	[Serializable]
	public enum XplParameterdirection_enum:int{IN,OUT,INOUT}
	[Serializable]
	public enum XplPlatformMatch_enum:int{LIKE,EXACTNAME,EXACTNAMEANDVERSION,LIKENAMEANDEXACTVERSION,CUSTOMMATCH}
	[Serializable]
	public enum XplAutoInstaceTypes_enum:int{CALL,BLOCK,CALLTOFUNCTION,CLASS,NAMESPACE,VIRTUALSECTION}
	[Serializable]
	public enum XplAssingop_enum:int{NONE,ADD,SUB,MUL,DIV,MOD,LSH,RSH,AND,XOR,OR}

	public class CodeDOM_STV{

		static public string []XPLPLATFORMSUPPORTLEVEL_ENUM={"complete","complete_beta","complete_alpha","incomplete","incomplete_beta","incomplete_alpha","experimental","experimental_beta","experimental_alpha","possibly_tested","possibly_nontested","explicitly_unsupported"};
		static public string []XPLDOCSOURCETYPE_ENUM={"XML","HTML","ZOE","TEXT","OTHER"};
		static public string []XPLFACTORYTYPE_ENUM={"none","iname","expression","expressionlist","statement"};
		static public string []XPLBITORDER_ENUM={"little_endian","big_endian","ignore"};
		static public string []XPLMEMORYMODEL_ENUM={"lineal","segmented","other"};
		static public string []XPLLITERALTYPE_ENUM={"string","ASCIIstring","char","ASCIIchar","bool","integer","real","float","double","decimal","oct","hex","datetime","UUID","null","other"};
		static public string []XPLDOCUMENTTYPE_ENUM={"layerd_zoe_doc","layerd_ezoe_doc","layerd_zoe_prog","import_process","infoldzoe_outputmodule","requirements_ezoe","errors_interchange_doc","virtual_subprogram_layerd_zoe","parameter_document_layerd_zoe"};
		static public string []XPLJUMPTYPE_ENUM={"break","continue","resume","resumenext","goto"};
		static public string []XPLPOINTERTYPE_ENUM={"c_native","default","safeclass"};
		static public string []XPLUNARYOPERATORS_ENUM={"min","inc","dec","preinc","predec","ind","aof","raof","sizeof","typeof","onecomp","not"};
		static public string []XPLERRORSOURCETYPE_ENUM={"zoe_doc","layerd_doc","outputmodule_import","outputmodule_render","outputmoudle_compile","zoe_ezoe_generation","other"};
		static public string []XPLTYPENAME_ENUM={"integer","unsigned","long","ulong","short","ushort","sbyte","byte","float","double","ldouble","decimal","fixed","boolean","char","string","ASCIIchar","ASCIIstring","date","uuid","void","object","type","block"};
		static public string []XPLVARSTORAGE_ENUM={"auto","static","extern","static_extern"};
		static public string []XPLTERNARYOPERATORS_ENUM={"boolean","reserved"};
		static public string []XPLACCESSTYPE_ENUM={"internal","public","protected","private","iinternal","ipublic","iprotected","iprivate"};
		static public string []XPLLAYERDZOEPROGRAMMODULETYPE_ENUM={"executable","static_lib","dynamic_lib","script","other"};
		static public string []XPLBINARYOPERATORS_ENUM={"add","min","mul","div","mod","exp","lsh","rsh","AND","OR","EQ","NOTEQ","GR","LS","GREQ","LSEQ","BAND","BOR","XOR","m","pm","mp","pmp","ms","msm","rm","imp"};
		static public string []XPLCASTTYPE_ENUM={"static","dynamic","const","reinterpret","other"};
		static public string []XPLPARAMETERDIRECTION_ENUM={"in","out","inout"};
		static public string []XPLPLATFORMMATCH_ENUM={"like","exactName","exactNameAndVersion","likeNameAndExactVersion","customMatch"};
		static public string []XPLAUTOINSTACETYPES_ENUM={"call","block","callToFunction","class","namespace","virtualSection"};
		static public string []XPLASSINGOP_ENUM={"none","add","sub","mul","div","mod","lsh","rsh","and","xor","or"};

	}

}

/*-------Fin de Archivo Generado------------------*/

