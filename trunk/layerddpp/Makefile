CC=g++
CFLAGS=-c -Wall
LDFLAGS=
SOURCES=layerd_dpp_lexer_beta.c \
layerd_dpp_parser_beta_tab.c \
../CodeDOM/CDOMBase.cpp \
../CodeDOM/CDOM_ClassfactoryData.cpp \
../CodeDOM/CDOM_FactoryTypesDatabase.cpp \
../CodeDOM/CDOM_SimpleTypes.cpp \
../CodeDOM/CDOM_XplAssing.cpp \
../CodeDOM/CDOM_XplAutoInstance.cpp \
../CodeDOM/CDOM_XplBaseInitializer.cpp \
../CodeDOM/CDOM_XplBaseInitializers.cpp \
../CodeDOM/CDOM_XplBinaryoperator.cpp \
../CodeDOM/CDOM_XplCase.cpp \
../CodeDOM/CDOM_XplCastexpression.cpp \
../CodeDOM/CDOM_XplCatchStatement.cpp \
../CodeDOM/CDOM_XplCatchinit.cpp \
../CodeDOM/CDOM_XplCexpression.cpp \
../CodeDOM/CDOM_XplClass.cpp \
../CodeDOM/CDOM_XplClassMembersList.cpp \
../CodeDOM/CDOM_XplClassfactorysPermissions.cpp \
../CodeDOM/CDOM_XplComplexfunctioncall.cpp \
../CodeDOM/CDOM_XplConfig.cpp \
../CodeDOM/CDOM_XplCopyright.cpp \
../CodeDOM/CDOM_XplDeclarator.cpp \
../CodeDOM/CDOM_XplDeclaratorlist.cpp \
../CodeDOM/CDOM_XplDirectoutput.cpp \
../CodeDOM/CDOM_XplDocument.cpp \
../CodeDOM/CDOM_XplDocumentBody.cpp \
../CodeDOM/CDOM_XplDocumentData.cpp \
../CodeDOM/CDOM_XplDocumentation.cpp \
../CodeDOM/CDOM_XplDowhileStatement.cpp \
../CodeDOM/CDOM_XplError.cpp \
../CodeDOM/CDOM_XplExpression.cpp \
../CodeDOM/CDOM_XplExpressionlist.cpp \
../CodeDOM/CDOM_XplExtendedLayerDZoeDocumentConfig.cpp \
../CodeDOM/CDOM_XplExtendedLayerDZoeRequirementsConfig.cpp \
../CodeDOM/CDOM_XplField.cpp \
../CodeDOM/CDOM_XplFileData.cpp \
../CodeDOM/CDOM_XplForStatement.cpp \
../CodeDOM/CDOM_XplForinit.cpp \
../CodeDOM/CDOM_XplFunction.cpp \
../CodeDOM/CDOM_XplFunctionBody.cpp \
../CodeDOM/CDOM_XplFunctioncall.cpp \
../CodeDOM/CDOM_XplGarbageCollector.cpp \
../CodeDOM/CDOM_XplIfStatement.cpp \
../CodeDOM/CDOM_XplImportProcessConfig.cpp \
../CodeDOM/CDOM_XplInfoLayerZoeOutputModuleConfig.cpp \
../CodeDOM/CDOM_XplInherit.cpp \
../CodeDOM/CDOM_XplInherits.cpp \
../CodeDOM/CDOM_XplInitializerList.cpp \
../CodeDOM/CDOM_XplJump.cpp \
../CodeDOM/CDOM_XplLanguage.cpp \
../CodeDOM/CDOM_XplLayerDCompiler.cpp \
../CodeDOM/CDOM_XplLayerDErrorInterchangeConfig.cpp \
../CodeDOM/CDOM_XplLayerDZoeDocumentConfig.cpp \
../CodeDOM/CDOM_XplLayerDZoeProgramConfig.cpp \
../CodeDOM/CDOM_XplLayerDZoeProgramRequirements.cpp \
../CodeDOM/CDOM_XplLiteral.cpp \
../CodeDOM/CDOM_XplName.cpp \
../CodeDOM/CDOM_XplNamespace.cpp \
../CodeDOM/CDOM_XplNewExpression.cpp \
../CodeDOM/CDOM_XplOutputModuleCapabilities.cpp \
../CodeDOM/CDOM_XplParameter.cpp \
../CodeDOM/CDOM_XplParameters.cpp \
../CodeDOM/CDOM_XplPlatform.cpp \
../CodeDOM/CDOM_XplPlatformAlias.cpp \
../CodeDOM/CDOM_XplPointerinfo.cpp \
../CodeDOM/CDOM_XplProperty.cpp \
../CodeDOM/CDOM_XplSetPlatforms.cpp \
../CodeDOM/CDOM_XplSetonerror.cpp \
../CodeDOM/CDOM_XplSourceFile.cpp \
../CodeDOM/CDOM_XplSwitchStatement.cpp \
../CodeDOM/CDOM_XplTargetPlatform.cpp \
../CodeDOM/CDOM_XplTernaryoperator.cpp \
../CodeDOM/CDOM_XplTryStatement.cpp \
../CodeDOM/CDOM_XplType.cpp \
../CodeDOM/CDOM_XplUnaryoperator.cpp \
../CodeDOM/CDOM_XplWriteCodeBody.cpp

OBJECTS=$(SOURCES:.cpp=.o)
EXECUTABLE=metadppc

all: $(SOURCES) $(EXECUTABLE)
	
$(EXECUTABLE): $(OBJECTS) 
	$(CC) $(LDFLAGS) $(OBJECTS) -o $@

.c.o:
.cpp.o:
	$(CC) $(CFLAGS) $< -o $@
	