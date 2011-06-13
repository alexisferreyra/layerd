/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEOUTPUTMODULECAPABILITIES_V1_0
#define __LAYERD_CODEDOM_ZOEOUTPUTMODULECAPABILITIES_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplOutputModuleCapabilities: public  XplNode{
private:
	//Variables para Atributos
	bool p_IsCaseSensitive;
	bool p_AllowDefaultSafeArrays;
	bool p_AllowDisableArrayLimitsChecks;
	bool p_AllowUseSinglePointAsNamespaceSeparator;
	bool p_AllowUseSimpleMemberAccessAsNamespaceSeparator;
	bool p_AllowMultipleInheritance;
	bool p_UseUniversalObjectBase;
	bool p_AllowSetUniversalObjectBase;
	bool p_AllowDisableUnifiedTypeSystem;
	bool p_AllowEnableIntegerOverflowExceptions;
	bool p_AllowEnableFloatOperationsExceptions;
	bool p_RequireIntegerOverflowExceptions;
	bool p_RequireFloatOperationsExceptions;
	bool p_FullDecimalImplementation;
	bool p_SupportASCIIChar;
	bool p_SupportASCIIString;
	bool p_SupportUnsignedIntegers;
	bool p_SupportExtendedValueTypes;
	bool p_SupportExtendedReferenceTypes;
	bool p_SupportFunctionPointerTypes;
	bool p_SupportExtendedTypes;
	bool p_AllowSetASCIIStringClass;
	bool p_AllowSetStringClass;
	bool p_AllowDisableNullReferenceCheckOnMemberAccess;
	bool p_SupportPointerArithmetics;
	bool p_AllowSetNullIntegerValue;
	int p_NullIntegerValue;
	bool p_AllowDisableBaseTypesArrayItemsInitialization;
	bool p_AllowDisableStaticsVarsInitialization;
	bool p_AllowDisableInstanceVarsInitialization;
	bool p_AllowIgnorePreviousAssingmentRules;
	bool p_AllowDisableAddressOfExpressionRequirementOnOutArguments;
	bool p_AllowFinalizeMethod;
	bool p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody;
	bool p_AllowSelectiveVirtualMembers;
	bool p_AllowNonLimitedGotos;
	bool p_AllowSetRuntimeTypeInformation;
	bool p_AllowSetRuntimeReflection;
	bool p_AllowLimitRuntimeReflectionToModuleOnly;
	bool p_AllowResumeExceptionModel;
	bool p_AllowTerminationExceptionModel;
	bool p_AllowFinallyBlocks;
	bool p_AllowResumeNext;
	bool p_AllowMixedExceptionModel;
	bool p_AllowAnyTypeExceptions;
	bool p_AllowStackVarsAsExceptions;
	bool p_AllowRuntimeChecksFragmentedConfiguration;
	string p_SupportedOperators;
	//Variables para Elementos de Secuencia
	XplNodeList* p_GarbageCollector;
public:
	//Region de Constructores Publicos
	XplOutputModuleCapabilities();
	XplOutputModuleCapabilities(bool n_IsCaseSensitive, bool n_AllowDefaultSafeArrays, bool n_AllowDisableArrayLimitsChecks, bool n_AllowUseSinglePointAsNamespaceSeparator, bool n_AllowUseSimpleMemberAccessAsNamespaceSeparator, bool n_AllowMultipleInheritance, bool n_UseUniversalObjectBase, bool n_AllowSetUniversalObjectBase, bool n_AllowDisableUnifiedTypeSystem, bool n_AllowEnableIntegerOverflowExceptions, bool n_AllowEnableFloatOperationsExceptions, bool n_RequireIntegerOverflowExceptions, bool n_RequireFloatOperationsExceptions, bool n_FullDecimalImplementation, bool n_SupportASCIIChar, bool n_SupportASCIIString, bool n_SupportUnsignedIntegers, bool n_SupportExtendedValueTypes, bool n_SupportExtendedReferenceTypes, bool n_SupportFunctionPointerTypes, bool n_SupportExtendedTypes, bool n_AllowSetASCIIStringClass, bool n_AllowSetStringClass, bool n_AllowDisableNullReferenceCheckOnMemberAccess, bool n_SupportPointerArithmetics, bool n_AllowSetNullIntegerValue, bool n_AllowDisableBaseTypesArrayItemsInitialization, bool n_AllowDisableStaticsVarsInitialization, bool n_AllowDisableInstanceVarsInitialization, bool n_AllowIgnorePreviousAssingmentRules, bool n_AllowDisableAddressOfExpressionRequirementOnOutArguments, bool n_AllowFinalizeMethod, bool n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody, bool n_AllowSelectiveVirtualMembers, bool n_AllowNonLimitedGotos, bool n_AllowSetRuntimeTypeInformation, bool n_AllowSetRuntimeReflection, bool n_AllowLimitRuntimeReflectionToModuleOnly, bool n_AllowResumeExceptionModel, bool n_AllowTerminationExceptionModel, bool n_AllowFinallyBlocks, bool n_AllowResumeNext, bool n_AllowMixedExceptionModel, bool n_AllowAnyTypeExceptions, bool n_AllowStackVarsAsExceptions, bool n_AllowRuntimeChecksFragmentedConfiguration);
	XplOutputModuleCapabilities(bool n_IsCaseSensitive, bool n_AllowDefaultSafeArrays, bool n_AllowDisableArrayLimitsChecks, bool n_AllowUseSinglePointAsNamespaceSeparator, bool n_AllowUseSimpleMemberAccessAsNamespaceSeparator, bool n_AllowMultipleInheritance, bool n_UseUniversalObjectBase, bool n_AllowSetUniversalObjectBase, bool n_AllowDisableUnifiedTypeSystem, bool n_AllowEnableIntegerOverflowExceptions, bool n_AllowEnableFloatOperationsExceptions, bool n_RequireIntegerOverflowExceptions, bool n_RequireFloatOperationsExceptions, bool n_FullDecimalImplementation, bool n_SupportASCIIChar, bool n_SupportASCIIString, bool n_SupportUnsignedIntegers, bool n_SupportExtendedValueTypes, bool n_SupportExtendedReferenceTypes, bool n_SupportFunctionPointerTypes, bool n_SupportExtendedTypes, bool n_AllowSetASCIIStringClass, bool n_AllowSetStringClass, bool n_AllowDisableNullReferenceCheckOnMemberAccess, bool n_SupportPointerArithmetics, bool n_AllowSetNullIntegerValue, int n_NullIntegerValue, bool n_AllowDisableBaseTypesArrayItemsInitialization, bool n_AllowDisableStaticsVarsInitialization, bool n_AllowDisableInstanceVarsInitialization, bool n_AllowIgnorePreviousAssingmentRules, bool n_AllowDisableAddressOfExpressionRequirementOnOutArguments, bool n_AllowFinalizeMethod, bool n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody, bool n_AllowSelectiveVirtualMembers, bool n_AllowNonLimitedGotos, bool n_AllowSetRuntimeTypeInformation, bool n_AllowSetRuntimeReflection, bool n_AllowLimitRuntimeReflectionToModuleOnly, bool n_AllowResumeExceptionModel, bool n_AllowTerminationExceptionModel, bool n_AllowFinallyBlocks, bool n_AllowResumeNext, bool n_AllowMixedExceptionModel, bool n_AllowAnyTypeExceptions, bool n_AllowStackVarsAsExceptions, bool n_AllowRuntimeChecksFragmentedConfiguration, string n_SupportedOperators);
	XplOutputModuleCapabilities(XplNodeList* n_GarbageCollector);
	XplOutputModuleCapabilities(bool n_IsCaseSensitive, bool n_AllowDefaultSafeArrays, bool n_AllowDisableArrayLimitsChecks, bool n_AllowUseSinglePointAsNamespaceSeparator, bool n_AllowUseSimpleMemberAccessAsNamespaceSeparator, bool n_AllowMultipleInheritance, bool n_UseUniversalObjectBase, bool n_AllowSetUniversalObjectBase, bool n_AllowDisableUnifiedTypeSystem, bool n_AllowEnableIntegerOverflowExceptions, bool n_AllowEnableFloatOperationsExceptions, bool n_RequireIntegerOverflowExceptions, bool n_RequireFloatOperationsExceptions, bool n_FullDecimalImplementation, bool n_SupportASCIIChar, bool n_SupportASCIIString, bool n_SupportUnsignedIntegers, bool n_SupportExtendedValueTypes, bool n_SupportExtendedReferenceTypes, bool n_SupportFunctionPointerTypes, bool n_SupportExtendedTypes, bool n_AllowSetASCIIStringClass, bool n_AllowSetStringClass, bool n_AllowDisableNullReferenceCheckOnMemberAccess, bool n_SupportPointerArithmetics, bool n_AllowSetNullIntegerValue, bool n_AllowDisableBaseTypesArrayItemsInitialization, bool n_AllowDisableStaticsVarsInitialization, bool n_AllowDisableInstanceVarsInitialization, bool n_AllowIgnorePreviousAssingmentRules, bool n_AllowDisableAddressOfExpressionRequirementOnOutArguments, bool n_AllowFinalizeMethod, bool n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody, bool n_AllowSelectiveVirtualMembers, bool n_AllowNonLimitedGotos, bool n_AllowSetRuntimeTypeInformation, bool n_AllowSetRuntimeReflection, bool n_AllowLimitRuntimeReflectionToModuleOnly, bool n_AllowResumeExceptionModel, bool n_AllowTerminationExceptionModel, bool n_AllowFinallyBlocks, bool n_AllowResumeNext, bool n_AllowMixedExceptionModel, bool n_AllowAnyTypeExceptions, bool n_AllowStackVarsAsExceptions, bool n_AllowRuntimeChecksFragmentedConfiguration, XplNodeList* n_GarbageCollector);
	XplOutputModuleCapabilities(bool n_IsCaseSensitive, bool n_AllowDefaultSafeArrays, bool n_AllowDisableArrayLimitsChecks, bool n_AllowUseSinglePointAsNamespaceSeparator, bool n_AllowUseSimpleMemberAccessAsNamespaceSeparator, bool n_AllowMultipleInheritance, bool n_UseUniversalObjectBase, bool n_AllowSetUniversalObjectBase, bool n_AllowDisableUnifiedTypeSystem, bool n_AllowEnableIntegerOverflowExceptions, bool n_AllowEnableFloatOperationsExceptions, bool n_RequireIntegerOverflowExceptions, bool n_RequireFloatOperationsExceptions, bool n_FullDecimalImplementation, bool n_SupportASCIIChar, bool n_SupportASCIIString, bool n_SupportUnsignedIntegers, bool n_SupportExtendedValueTypes, bool n_SupportExtendedReferenceTypes, bool n_SupportFunctionPointerTypes, bool n_SupportExtendedTypes, bool n_AllowSetASCIIStringClass, bool n_AllowSetStringClass, bool n_AllowDisableNullReferenceCheckOnMemberAccess, bool n_SupportPointerArithmetics, bool n_AllowSetNullIntegerValue, int n_NullIntegerValue, bool n_AllowDisableBaseTypesArrayItemsInitialization, bool n_AllowDisableStaticsVarsInitialization, bool n_AllowDisableInstanceVarsInitialization, bool n_AllowIgnorePreviousAssingmentRules, bool n_AllowDisableAddressOfExpressionRequirementOnOutArguments, bool n_AllowFinalizeMethod, bool n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody, bool n_AllowSelectiveVirtualMembers, bool n_AllowNonLimitedGotos, bool n_AllowSetRuntimeTypeInformation, bool n_AllowSetRuntimeReflection, bool n_AllowLimitRuntimeReflectionToModuleOnly, bool n_AllowResumeExceptionModel, bool n_AllowTerminationExceptionModel, bool n_AllowFinallyBlocks, bool n_AllowResumeNext, bool n_AllowMixedExceptionModel, bool n_AllowAnyTypeExceptions, bool n_AllowStackVarsAsExceptions, bool n_AllowRuntimeChecksFragmentedConfiguration, string n_SupportedOperators, XplNodeList* n_GarbageCollector);
	//Destructor
	~XplOutputModuleCapabilities();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEOUTPUTMODULECAPABILITIES;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	bool get_IsCaseSensitive();
	bool get_AllowDefaultSafeArrays();
	bool get_AllowDisableArrayLimitsChecks();
	bool get_AllowUseSinglePointAsNamespaceSeparator();
	bool get_AllowUseSimpleMemberAccessAsNamespaceSeparator();
	bool get_AllowMultipleInheritance();
	bool get_UseUniversalObjectBase();
	bool get_AllowSetUniversalObjectBase();
	bool get_AllowDisableUnifiedTypeSystem();
	bool get_AllowEnableIntegerOverflowExceptions();
	bool get_AllowEnableFloatOperationsExceptions();
	bool get_RequireIntegerOverflowExceptions();
	bool get_RequireFloatOperationsExceptions();
	bool get_FullDecimalImplementation();
	bool get_SupportASCIIChar();
	bool get_SupportASCIIString();
	bool get_SupportUnsignedIntegers();
	bool get_SupportExtendedValueTypes();
	bool get_SupportExtendedReferenceTypes();
	bool get_SupportFunctionPointerTypes();
	bool get_SupportExtendedTypes();
	bool get_AllowSetASCIIStringClass();
	bool get_AllowSetStringClass();
	bool get_AllowDisableNullReferenceCheckOnMemberAccess();
	bool get_SupportPointerArithmetics();
	bool get_AllowSetNullIntegerValue();
	int get_NullIntegerValue();
	bool get_AllowDisableBaseTypesArrayItemsInitialization();
	bool get_AllowDisableStaticsVarsInitialization();
	bool get_AllowDisableInstanceVarsInitialization();
	bool get_AllowIgnorePreviousAssingmentRules();
	bool get_AllowDisableAddressOfExpressionRequirementOnOutArguments();
	bool get_AllowFinalizeMethod();
	bool get_AllowNonNormalVirtualFunctionCallsOnConstructorsBody();
	bool get_AllowSelectiveVirtualMembers();
	bool get_AllowNonLimitedGotos();
	bool get_AllowSetRuntimeTypeInformation();
	bool get_AllowSetRuntimeReflection();
	bool get_AllowLimitRuntimeReflectionToModuleOnly();
	bool get_AllowResumeExceptionModel();
	bool get_AllowTerminationExceptionModel();
	bool get_AllowFinallyBlocks();
	bool get_AllowResumeNext();
	bool get_AllowMixedExceptionModel();
	bool get_AllowAnyTypeExceptions();
	bool get_AllowStackVarsAsExceptions();
	bool get_AllowRuntimeChecksFragmentedConfiguration();
	string get_SupportedOperators();
	//Funciones para obtener Elementos de Secuencia
	XplNodeList* get_GarbageCollector();
public:
	//Funciones para setear Atributos
	bool set_IsCaseSensitive(bool new_IsCaseSensitive);
	bool set_AllowDefaultSafeArrays(bool new_AllowDefaultSafeArrays);
	bool set_AllowDisableArrayLimitsChecks(bool new_AllowDisableArrayLimitsChecks);
	bool set_AllowUseSinglePointAsNamespaceSeparator(bool new_AllowUseSinglePointAsNamespaceSeparator);
	bool set_AllowUseSimpleMemberAccessAsNamespaceSeparator(bool new_AllowUseSimpleMemberAccessAsNamespaceSeparator);
	bool set_AllowMultipleInheritance(bool new_AllowMultipleInheritance);
	bool set_UseUniversalObjectBase(bool new_UseUniversalObjectBase);
	bool set_AllowSetUniversalObjectBase(bool new_AllowSetUniversalObjectBase);
	bool set_AllowDisableUnifiedTypeSystem(bool new_AllowDisableUnifiedTypeSystem);
	bool set_AllowEnableIntegerOverflowExceptions(bool new_AllowEnableIntegerOverflowExceptions);
	bool set_AllowEnableFloatOperationsExceptions(bool new_AllowEnableFloatOperationsExceptions);
	bool set_RequireIntegerOverflowExceptions(bool new_RequireIntegerOverflowExceptions);
	bool set_RequireFloatOperationsExceptions(bool new_RequireFloatOperationsExceptions);
	bool set_FullDecimalImplementation(bool new_FullDecimalImplementation);
	bool set_SupportASCIIChar(bool new_SupportASCIIChar);
	bool set_SupportASCIIString(bool new_SupportASCIIString);
	bool set_SupportUnsignedIntegers(bool new_SupportUnsignedIntegers);
	bool set_SupportExtendedValueTypes(bool new_SupportExtendedValueTypes);
	bool set_SupportExtendedReferenceTypes(bool new_SupportExtendedReferenceTypes);
	bool set_SupportFunctionPointerTypes(bool new_SupportFunctionPointerTypes);
	bool set_SupportExtendedTypes(bool new_SupportExtendedTypes);
	bool set_AllowSetASCIIStringClass(bool new_AllowSetASCIIStringClass);
	bool set_AllowSetStringClass(bool new_AllowSetStringClass);
	bool set_AllowDisableNullReferenceCheckOnMemberAccess(bool new_AllowDisableNullReferenceCheckOnMemberAccess);
	bool set_SupportPointerArithmetics(bool new_SupportPointerArithmetics);
	bool set_AllowSetNullIntegerValue(bool new_AllowSetNullIntegerValue);
	int set_NullIntegerValue(int new_NullIntegerValue);
	bool set_AllowDisableBaseTypesArrayItemsInitialization(bool new_AllowDisableBaseTypesArrayItemsInitialization);
	bool set_AllowDisableStaticsVarsInitialization(bool new_AllowDisableStaticsVarsInitialization);
	bool set_AllowDisableInstanceVarsInitialization(bool new_AllowDisableInstanceVarsInitialization);
	bool set_AllowIgnorePreviousAssingmentRules(bool new_AllowIgnorePreviousAssingmentRules);
	bool set_AllowDisableAddressOfExpressionRequirementOnOutArguments(bool new_AllowDisableAddressOfExpressionRequirementOnOutArguments);
	bool set_AllowFinalizeMethod(bool new_AllowFinalizeMethod);
	bool set_AllowNonNormalVirtualFunctionCallsOnConstructorsBody(bool new_AllowNonNormalVirtualFunctionCallsOnConstructorsBody);
	bool set_AllowSelectiveVirtualMembers(bool new_AllowSelectiveVirtualMembers);
	bool set_AllowNonLimitedGotos(bool new_AllowNonLimitedGotos);
	bool set_AllowSetRuntimeTypeInformation(bool new_AllowSetRuntimeTypeInformation);
	bool set_AllowSetRuntimeReflection(bool new_AllowSetRuntimeReflection);
	bool set_AllowLimitRuntimeReflectionToModuleOnly(bool new_AllowLimitRuntimeReflectionToModuleOnly);
	bool set_AllowResumeExceptionModel(bool new_AllowResumeExceptionModel);
	bool set_AllowTerminationExceptionModel(bool new_AllowTerminationExceptionModel);
	bool set_AllowFinallyBlocks(bool new_AllowFinallyBlocks);
	bool set_AllowResumeNext(bool new_AllowResumeNext);
	bool set_AllowMixedExceptionModel(bool new_AllowMixedExceptionModel);
	bool set_AllowAnyTypeExceptions(bool new_AllowAnyTypeExceptions);
	bool set_AllowStackVarsAsExceptions(bool new_AllowStackVarsAsExceptions);
	bool set_AllowRuntimeChecksFragmentedConfiguration(bool new_AllowRuntimeChecksFragmentedConfiguration);
	string set_SupportedOperators(string new_SupportedOperators);
	//Funciones para setear Elementos de Secuencia
protected:
	static bool acceptInsertNodeCallback_GarbageCollector(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_GarbageCollector(XplNode* node, string* errorMsg, XplNode* parent);
public:
	static XplGarbageCollector* new_GarbageCollector();
};	//Fin declaración de Clase

}

#endif
