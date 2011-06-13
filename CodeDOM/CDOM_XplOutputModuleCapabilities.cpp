/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOEOUTPUTMODULECAPABILITIES_V1_0_CPP
#define __LAYERD_CODEDOM_ZOEOUTPUTMODULECAPABILITIES_V1_0_CPP
#include "CDOM_XplOutputModuleCapabilities.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplOutputModuleCapabilities::XplOutputModuleCapabilities(){
	p_IsCaseSensitive = true;
	p_AllowDefaultSafeArrays = false;
	p_AllowDisableArrayLimitsChecks = false;
	p_AllowUseSinglePointAsNamespaceSeparator = false;
	p_AllowUseSimpleMemberAccessAsNamespaceSeparator = false;
	p_AllowMultipleInheritance = false;
	p_UseUniversalObjectBase = true;
	p_AllowSetUniversalObjectBase = false;
	p_AllowDisableUnifiedTypeSystem = false;
	p_AllowEnableIntegerOverflowExceptions = false;
	p_AllowEnableFloatOperationsExceptions = false;
	p_RequireIntegerOverflowExceptions = false;
	p_RequireFloatOperationsExceptions = false;
	p_FullDecimalImplementation = true;
	p_SupportASCIIChar = false;
	p_SupportASCIIString = false;
	p_SupportUnsignedIntegers = true;
	p_SupportExtendedValueTypes = true;
	p_SupportExtendedReferenceTypes = true;
	p_SupportFunctionPointerTypes = true;
	p_SupportExtendedTypes = true;
	p_AllowSetASCIIStringClass = false;
	p_AllowSetStringClass = false;
	p_AllowDisableNullReferenceCheckOnMemberAccess = false;
	p_SupportPointerArithmetics = false;
	p_AllowSetNullIntegerValue = false;
	p_NullIntegerValue = 0;
	p_AllowDisableBaseTypesArrayItemsInitialization = false;
	p_AllowDisableStaticsVarsInitialization = false;
	p_AllowDisableInstanceVarsInitialization = false;
	p_AllowIgnorePreviousAssingmentRules = true;
	p_AllowDisableAddressOfExpressionRequirementOnOutArguments = false;
	p_AllowFinalizeMethod = true;
	p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody = false;
	p_AllowSelectiveVirtualMembers = true;
	p_AllowNonLimitedGotos = false;
	p_AllowSetRuntimeTypeInformation = true;
	p_AllowSetRuntimeReflection = false;
	p_AllowLimitRuntimeReflectionToModuleOnly = false;
	p_AllowResumeExceptionModel = false;
	p_AllowTerminationExceptionModel = true;
	p_AllowFinallyBlocks = true;
	p_AllowResumeNext = true;
	p_AllowMixedExceptionModel = false;
	p_AllowAnyTypeExceptions = false;
	p_AllowStackVarsAsExceptions = true;
	p_AllowRuntimeChecksFragmentedConfiguration = false;
	p_SupportedOperators = DT_EMPTY;
	p_GarbageCollector = new XplNodeList();
	p_GarbageCollector->set_Parent(this);
	p_GarbageCollector->set_InsertNodeCallback(&acceptInsertNodeCallback_GarbageCollector);
	p_GarbageCollector->set_RemoveNodeCallback(&acceptRemoveNodeCallback_GarbageCollector);
}
XplOutputModuleCapabilities::XplOutputModuleCapabilities(bool n_IsCaseSensitive, bool n_AllowDefaultSafeArrays, bool n_AllowDisableArrayLimitsChecks, bool n_AllowUseSinglePointAsNamespaceSeparator, bool n_AllowUseSimpleMemberAccessAsNamespaceSeparator, bool n_AllowMultipleInheritance, bool n_UseUniversalObjectBase, bool n_AllowSetUniversalObjectBase, bool n_AllowDisableUnifiedTypeSystem, bool n_AllowEnableIntegerOverflowExceptions, bool n_AllowEnableFloatOperationsExceptions, bool n_RequireIntegerOverflowExceptions, bool n_RequireFloatOperationsExceptions, bool n_FullDecimalImplementation, bool n_SupportASCIIChar, bool n_SupportASCIIString, bool n_SupportUnsignedIntegers, bool n_SupportExtendedValueTypes, bool n_SupportExtendedReferenceTypes, bool n_SupportFunctionPointerTypes, bool n_SupportExtendedTypes, bool n_AllowSetASCIIStringClass, bool n_AllowSetStringClass, bool n_AllowDisableNullReferenceCheckOnMemberAccess, bool n_SupportPointerArithmetics, bool n_AllowSetNullIntegerValue, bool n_AllowDisableBaseTypesArrayItemsInitialization, bool n_AllowDisableStaticsVarsInitialization, bool n_AllowDisableInstanceVarsInitialization, bool n_AllowIgnorePreviousAssingmentRules, bool n_AllowDisableAddressOfExpressionRequirementOnOutArguments, bool n_AllowFinalizeMethod, bool n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody, bool n_AllowSelectiveVirtualMembers, bool n_AllowNonLimitedGotos, bool n_AllowSetRuntimeTypeInformation, bool n_AllowSetRuntimeReflection, bool n_AllowLimitRuntimeReflectionToModuleOnly, bool n_AllowResumeExceptionModel, bool n_AllowTerminationExceptionModel, bool n_AllowFinallyBlocks, bool n_AllowResumeNext, bool n_AllowMixedExceptionModel, bool n_AllowAnyTypeExceptions, bool n_AllowStackVarsAsExceptions, bool n_AllowRuntimeChecksFragmentedConfiguration){
	p_IsCaseSensitive = true;
	p_AllowDefaultSafeArrays = false;
	p_AllowDisableArrayLimitsChecks = false;
	p_AllowUseSinglePointAsNamespaceSeparator = false;
	p_AllowUseSimpleMemberAccessAsNamespaceSeparator = false;
	p_AllowMultipleInheritance = false;
	p_UseUniversalObjectBase = true;
	p_AllowSetUniversalObjectBase = false;
	p_AllowDisableUnifiedTypeSystem = false;
	p_AllowEnableIntegerOverflowExceptions = false;
	p_AllowEnableFloatOperationsExceptions = false;
	p_RequireIntegerOverflowExceptions = false;
	p_RequireFloatOperationsExceptions = false;
	p_FullDecimalImplementation = true;
	p_SupportASCIIChar = false;
	p_SupportASCIIString = false;
	p_SupportUnsignedIntegers = true;
	p_SupportExtendedValueTypes = true;
	p_SupportExtendedReferenceTypes = true;
	p_SupportFunctionPointerTypes = true;
	p_SupportExtendedTypes = true;
	p_AllowSetASCIIStringClass = false;
	p_AllowSetStringClass = false;
	p_AllowDisableNullReferenceCheckOnMemberAccess = false;
	p_SupportPointerArithmetics = false;
	p_AllowSetNullIntegerValue = false;
	p_NullIntegerValue = 0;
	p_AllowDisableBaseTypesArrayItemsInitialization = false;
	p_AllowDisableStaticsVarsInitialization = false;
	p_AllowDisableInstanceVarsInitialization = false;
	p_AllowIgnorePreviousAssingmentRules = true;
	p_AllowDisableAddressOfExpressionRequirementOnOutArguments = false;
	p_AllowFinalizeMethod = true;
	p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody = false;
	p_AllowSelectiveVirtualMembers = true;
	p_AllowNonLimitedGotos = false;
	p_AllowSetRuntimeTypeInformation = true;
	p_AllowSetRuntimeReflection = false;
	p_AllowLimitRuntimeReflectionToModuleOnly = false;
	p_AllowResumeExceptionModel = false;
	p_AllowTerminationExceptionModel = true;
	p_AllowFinallyBlocks = true;
	p_AllowResumeNext = true;
	p_AllowMixedExceptionModel = false;
	p_AllowAnyTypeExceptions = false;
	p_AllowStackVarsAsExceptions = true;
	p_AllowRuntimeChecksFragmentedConfiguration = false;
	p_SupportedOperators = DT_EMPTY;
	set_IsCaseSensitive(n_IsCaseSensitive);
	set_AllowDefaultSafeArrays(n_AllowDefaultSafeArrays);
	set_AllowDisableArrayLimitsChecks(n_AllowDisableArrayLimitsChecks);
	set_AllowUseSinglePointAsNamespaceSeparator(n_AllowUseSinglePointAsNamespaceSeparator);
	set_AllowUseSimpleMemberAccessAsNamespaceSeparator(n_AllowUseSimpleMemberAccessAsNamespaceSeparator);
	set_AllowMultipleInheritance(n_AllowMultipleInheritance);
	set_UseUniversalObjectBase(n_UseUniversalObjectBase);
	set_AllowSetUniversalObjectBase(n_AllowSetUniversalObjectBase);
	set_AllowDisableUnifiedTypeSystem(n_AllowDisableUnifiedTypeSystem);
	set_AllowEnableIntegerOverflowExceptions(n_AllowEnableIntegerOverflowExceptions);
	set_AllowEnableFloatOperationsExceptions(n_AllowEnableFloatOperationsExceptions);
	set_RequireIntegerOverflowExceptions(n_RequireIntegerOverflowExceptions);
	set_RequireFloatOperationsExceptions(n_RequireFloatOperationsExceptions);
	set_FullDecimalImplementation(n_FullDecimalImplementation);
	set_SupportASCIIChar(n_SupportASCIIChar);
	set_SupportASCIIString(n_SupportASCIIString);
	set_SupportUnsignedIntegers(n_SupportUnsignedIntegers);
	set_SupportExtendedValueTypes(n_SupportExtendedValueTypes);
	set_SupportExtendedReferenceTypes(n_SupportExtendedReferenceTypes);
	set_SupportFunctionPointerTypes(n_SupportFunctionPointerTypes);
	set_SupportExtendedTypes(n_SupportExtendedTypes);
	set_AllowSetASCIIStringClass(n_AllowSetASCIIStringClass);
	set_AllowSetStringClass(n_AllowSetStringClass);
	set_AllowDisableNullReferenceCheckOnMemberAccess(n_AllowDisableNullReferenceCheckOnMemberAccess);
	set_SupportPointerArithmetics(n_SupportPointerArithmetics);
	set_AllowSetNullIntegerValue(n_AllowSetNullIntegerValue);
	set_AllowDisableBaseTypesArrayItemsInitialization(n_AllowDisableBaseTypesArrayItemsInitialization);
	set_AllowDisableStaticsVarsInitialization(n_AllowDisableStaticsVarsInitialization);
	set_AllowDisableInstanceVarsInitialization(n_AllowDisableInstanceVarsInitialization);
	set_AllowIgnorePreviousAssingmentRules(n_AllowIgnorePreviousAssingmentRules);
	set_AllowDisableAddressOfExpressionRequirementOnOutArguments(n_AllowDisableAddressOfExpressionRequirementOnOutArguments);
	set_AllowFinalizeMethod(n_AllowFinalizeMethod);
	set_AllowNonNormalVirtualFunctionCallsOnConstructorsBody(n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody);
	set_AllowSelectiveVirtualMembers(n_AllowSelectiveVirtualMembers);
	set_AllowNonLimitedGotos(n_AllowNonLimitedGotos);
	set_AllowSetRuntimeTypeInformation(n_AllowSetRuntimeTypeInformation);
	set_AllowSetRuntimeReflection(n_AllowSetRuntimeReflection);
	set_AllowLimitRuntimeReflectionToModuleOnly(n_AllowLimitRuntimeReflectionToModuleOnly);
	set_AllowResumeExceptionModel(n_AllowResumeExceptionModel);
	set_AllowTerminationExceptionModel(n_AllowTerminationExceptionModel);
	set_AllowFinallyBlocks(n_AllowFinallyBlocks);
	set_AllowResumeNext(n_AllowResumeNext);
	set_AllowMixedExceptionModel(n_AllowMixedExceptionModel);
	set_AllowAnyTypeExceptions(n_AllowAnyTypeExceptions);
	set_AllowStackVarsAsExceptions(n_AllowStackVarsAsExceptions);
	set_AllowRuntimeChecksFragmentedConfiguration(n_AllowRuntimeChecksFragmentedConfiguration);
	p_GarbageCollector = new XplNodeList();
	p_GarbageCollector->set_Parent(this);
	p_GarbageCollector->set_InsertNodeCallback(&acceptInsertNodeCallback_GarbageCollector);
	p_GarbageCollector->set_RemoveNodeCallback(&acceptRemoveNodeCallback_GarbageCollector);
}
XplOutputModuleCapabilities::XplOutputModuleCapabilities(bool n_IsCaseSensitive, bool n_AllowDefaultSafeArrays, bool n_AllowDisableArrayLimitsChecks, bool n_AllowUseSinglePointAsNamespaceSeparator, bool n_AllowUseSimpleMemberAccessAsNamespaceSeparator, bool n_AllowMultipleInheritance, bool n_UseUniversalObjectBase, bool n_AllowSetUniversalObjectBase, bool n_AllowDisableUnifiedTypeSystem, bool n_AllowEnableIntegerOverflowExceptions, bool n_AllowEnableFloatOperationsExceptions, bool n_RequireIntegerOverflowExceptions, bool n_RequireFloatOperationsExceptions, bool n_FullDecimalImplementation, bool n_SupportASCIIChar, bool n_SupportASCIIString, bool n_SupportUnsignedIntegers, bool n_SupportExtendedValueTypes, bool n_SupportExtendedReferenceTypes, bool n_SupportFunctionPointerTypes, bool n_SupportExtendedTypes, bool n_AllowSetASCIIStringClass, bool n_AllowSetStringClass, bool n_AllowDisableNullReferenceCheckOnMemberAccess, bool n_SupportPointerArithmetics, bool n_AllowSetNullIntegerValue, int n_NullIntegerValue, bool n_AllowDisableBaseTypesArrayItemsInitialization, bool n_AllowDisableStaticsVarsInitialization, bool n_AllowDisableInstanceVarsInitialization, bool n_AllowIgnorePreviousAssingmentRules, bool n_AllowDisableAddressOfExpressionRequirementOnOutArguments, bool n_AllowFinalizeMethod, bool n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody, bool n_AllowSelectiveVirtualMembers, bool n_AllowNonLimitedGotos, bool n_AllowSetRuntimeTypeInformation, bool n_AllowSetRuntimeReflection, bool n_AllowLimitRuntimeReflectionToModuleOnly, bool n_AllowResumeExceptionModel, bool n_AllowTerminationExceptionModel, bool n_AllowFinallyBlocks, bool n_AllowResumeNext, bool n_AllowMixedExceptionModel, bool n_AllowAnyTypeExceptions, bool n_AllowStackVarsAsExceptions, bool n_AllowRuntimeChecksFragmentedConfiguration, string n_SupportedOperators){
	set_IsCaseSensitive(n_IsCaseSensitive);
	set_AllowDefaultSafeArrays(n_AllowDefaultSafeArrays);
	set_AllowDisableArrayLimitsChecks(n_AllowDisableArrayLimitsChecks);
	set_AllowUseSinglePointAsNamespaceSeparator(n_AllowUseSinglePointAsNamespaceSeparator);
	set_AllowUseSimpleMemberAccessAsNamespaceSeparator(n_AllowUseSimpleMemberAccessAsNamespaceSeparator);
	set_AllowMultipleInheritance(n_AllowMultipleInheritance);
	set_UseUniversalObjectBase(n_UseUniversalObjectBase);
	set_AllowSetUniversalObjectBase(n_AllowSetUniversalObjectBase);
	set_AllowDisableUnifiedTypeSystem(n_AllowDisableUnifiedTypeSystem);
	set_AllowEnableIntegerOverflowExceptions(n_AllowEnableIntegerOverflowExceptions);
	set_AllowEnableFloatOperationsExceptions(n_AllowEnableFloatOperationsExceptions);
	set_RequireIntegerOverflowExceptions(n_RequireIntegerOverflowExceptions);
	set_RequireFloatOperationsExceptions(n_RequireFloatOperationsExceptions);
	set_FullDecimalImplementation(n_FullDecimalImplementation);
	set_SupportASCIIChar(n_SupportASCIIChar);
	set_SupportASCIIString(n_SupportASCIIString);
	set_SupportUnsignedIntegers(n_SupportUnsignedIntegers);
	set_SupportExtendedValueTypes(n_SupportExtendedValueTypes);
	set_SupportExtendedReferenceTypes(n_SupportExtendedReferenceTypes);
	set_SupportFunctionPointerTypes(n_SupportFunctionPointerTypes);
	set_SupportExtendedTypes(n_SupportExtendedTypes);
	set_AllowSetASCIIStringClass(n_AllowSetASCIIStringClass);
	set_AllowSetStringClass(n_AllowSetStringClass);
	set_AllowDisableNullReferenceCheckOnMemberAccess(n_AllowDisableNullReferenceCheckOnMemberAccess);
	set_SupportPointerArithmetics(n_SupportPointerArithmetics);
	set_AllowSetNullIntegerValue(n_AllowSetNullIntegerValue);
	set_NullIntegerValue(n_NullIntegerValue);
	set_AllowDisableBaseTypesArrayItemsInitialization(n_AllowDisableBaseTypesArrayItemsInitialization);
	set_AllowDisableStaticsVarsInitialization(n_AllowDisableStaticsVarsInitialization);
	set_AllowDisableInstanceVarsInitialization(n_AllowDisableInstanceVarsInitialization);
	set_AllowIgnorePreviousAssingmentRules(n_AllowIgnorePreviousAssingmentRules);
	set_AllowDisableAddressOfExpressionRequirementOnOutArguments(n_AllowDisableAddressOfExpressionRequirementOnOutArguments);
	set_AllowFinalizeMethod(n_AllowFinalizeMethod);
	set_AllowNonNormalVirtualFunctionCallsOnConstructorsBody(n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody);
	set_AllowSelectiveVirtualMembers(n_AllowSelectiveVirtualMembers);
	set_AllowNonLimitedGotos(n_AllowNonLimitedGotos);
	set_AllowSetRuntimeTypeInformation(n_AllowSetRuntimeTypeInformation);
	set_AllowSetRuntimeReflection(n_AllowSetRuntimeReflection);
	set_AllowLimitRuntimeReflectionToModuleOnly(n_AllowLimitRuntimeReflectionToModuleOnly);
	set_AllowResumeExceptionModel(n_AllowResumeExceptionModel);
	set_AllowTerminationExceptionModel(n_AllowTerminationExceptionModel);
	set_AllowFinallyBlocks(n_AllowFinallyBlocks);
	set_AllowResumeNext(n_AllowResumeNext);
	set_AllowMixedExceptionModel(n_AllowMixedExceptionModel);
	set_AllowAnyTypeExceptions(n_AllowAnyTypeExceptions);
	set_AllowStackVarsAsExceptions(n_AllowStackVarsAsExceptions);
	set_AllowRuntimeChecksFragmentedConfiguration(n_AllowRuntimeChecksFragmentedConfiguration);
	set_SupportedOperators(n_SupportedOperators);
	p_GarbageCollector = new XplNodeList();
	p_GarbageCollector->set_Parent(this);
	p_GarbageCollector->set_InsertNodeCallback(&acceptInsertNodeCallback_GarbageCollector);
	p_GarbageCollector->set_RemoveNodeCallback(&acceptRemoveNodeCallback_GarbageCollector);
}
XplOutputModuleCapabilities::XplOutputModuleCapabilities(XplNodeList* n_GarbageCollector){
	p_IsCaseSensitive = true;
	p_AllowDefaultSafeArrays = false;
	p_AllowDisableArrayLimitsChecks = false;
	p_AllowUseSinglePointAsNamespaceSeparator = false;
	p_AllowUseSimpleMemberAccessAsNamespaceSeparator = false;
	p_AllowMultipleInheritance = false;
	p_UseUniversalObjectBase = true;
	p_AllowSetUniversalObjectBase = false;
	p_AllowDisableUnifiedTypeSystem = false;
	p_AllowEnableIntegerOverflowExceptions = false;
	p_AllowEnableFloatOperationsExceptions = false;
	p_RequireIntegerOverflowExceptions = false;
	p_RequireFloatOperationsExceptions = false;
	p_FullDecimalImplementation = true;
	p_SupportASCIIChar = false;
	p_SupportASCIIString = false;
	p_SupportUnsignedIntegers = true;
	p_SupportExtendedValueTypes = true;
	p_SupportExtendedReferenceTypes = true;
	p_SupportFunctionPointerTypes = true;
	p_SupportExtendedTypes = true;
	p_AllowSetASCIIStringClass = false;
	p_AllowSetStringClass = false;
	p_AllowDisableNullReferenceCheckOnMemberAccess = false;
	p_SupportPointerArithmetics = false;
	p_AllowSetNullIntegerValue = false;
	p_NullIntegerValue = 0;
	p_AllowDisableBaseTypesArrayItemsInitialization = false;
	p_AllowDisableStaticsVarsInitialization = false;
	p_AllowDisableInstanceVarsInitialization = false;
	p_AllowIgnorePreviousAssingmentRules = true;
	p_AllowDisableAddressOfExpressionRequirementOnOutArguments = false;
	p_AllowFinalizeMethod = true;
	p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody = false;
	p_AllowSelectiveVirtualMembers = true;
	p_AllowNonLimitedGotos = false;
	p_AllowSetRuntimeTypeInformation = true;
	p_AllowSetRuntimeReflection = false;
	p_AllowLimitRuntimeReflectionToModuleOnly = false;
	p_AllowResumeExceptionModel = false;
	p_AllowTerminationExceptionModel = true;
	p_AllowFinallyBlocks = true;
	p_AllowResumeNext = true;
	p_AllowMixedExceptionModel = false;
	p_AllowAnyTypeExceptions = false;
	p_AllowStackVarsAsExceptions = true;
	p_AllowRuntimeChecksFragmentedConfiguration = false;
	p_SupportedOperators = DT_EMPTY;
	p_GarbageCollector = new XplNodeList();
	p_GarbageCollector->set_Parent(this);
	p_GarbageCollector->set_InsertNodeCallback(&acceptInsertNodeCallback_GarbageCollector);
	p_GarbageCollector->set_RemoveNodeCallback(&acceptRemoveNodeCallback_GarbageCollector);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_GarbageCollector!=NULL)
	for(XplNode* node = n_GarbageCollector->FirstNode(); node != n_GarbageCollector->GetLastNode() ; node = n_GarbageCollector->NextNode()){
		p_GarbageCollector->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplOutputModuleCapabilities::XplOutputModuleCapabilities(bool n_IsCaseSensitive, bool n_AllowDefaultSafeArrays, bool n_AllowDisableArrayLimitsChecks, bool n_AllowUseSinglePointAsNamespaceSeparator, bool n_AllowUseSimpleMemberAccessAsNamespaceSeparator, bool n_AllowMultipleInheritance, bool n_UseUniversalObjectBase, bool n_AllowSetUniversalObjectBase, bool n_AllowDisableUnifiedTypeSystem, bool n_AllowEnableIntegerOverflowExceptions, bool n_AllowEnableFloatOperationsExceptions, bool n_RequireIntegerOverflowExceptions, bool n_RequireFloatOperationsExceptions, bool n_FullDecimalImplementation, bool n_SupportASCIIChar, bool n_SupportASCIIString, bool n_SupportUnsignedIntegers, bool n_SupportExtendedValueTypes, bool n_SupportExtendedReferenceTypes, bool n_SupportFunctionPointerTypes, bool n_SupportExtendedTypes, bool n_AllowSetASCIIStringClass, bool n_AllowSetStringClass, bool n_AllowDisableNullReferenceCheckOnMemberAccess, bool n_SupportPointerArithmetics, bool n_AllowSetNullIntegerValue, bool n_AllowDisableBaseTypesArrayItemsInitialization, bool n_AllowDisableStaticsVarsInitialization, bool n_AllowDisableInstanceVarsInitialization, bool n_AllowIgnorePreviousAssingmentRules, bool n_AllowDisableAddressOfExpressionRequirementOnOutArguments, bool n_AllowFinalizeMethod, bool n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody, bool n_AllowSelectiveVirtualMembers, bool n_AllowNonLimitedGotos, bool n_AllowSetRuntimeTypeInformation, bool n_AllowSetRuntimeReflection, bool n_AllowLimitRuntimeReflectionToModuleOnly, bool n_AllowResumeExceptionModel, bool n_AllowTerminationExceptionModel, bool n_AllowFinallyBlocks, bool n_AllowResumeNext, bool n_AllowMixedExceptionModel, bool n_AllowAnyTypeExceptions, bool n_AllowStackVarsAsExceptions, bool n_AllowRuntimeChecksFragmentedConfiguration, XplNodeList* n_GarbageCollector){
	p_IsCaseSensitive = true;
	p_AllowDefaultSafeArrays = false;
	p_AllowDisableArrayLimitsChecks = false;
	p_AllowUseSinglePointAsNamespaceSeparator = false;
	p_AllowUseSimpleMemberAccessAsNamespaceSeparator = false;
	p_AllowMultipleInheritance = false;
	p_UseUniversalObjectBase = true;
	p_AllowSetUniversalObjectBase = false;
	p_AllowDisableUnifiedTypeSystem = false;
	p_AllowEnableIntegerOverflowExceptions = false;
	p_AllowEnableFloatOperationsExceptions = false;
	p_RequireIntegerOverflowExceptions = false;
	p_RequireFloatOperationsExceptions = false;
	p_FullDecimalImplementation = true;
	p_SupportASCIIChar = false;
	p_SupportASCIIString = false;
	p_SupportUnsignedIntegers = true;
	p_SupportExtendedValueTypes = true;
	p_SupportExtendedReferenceTypes = true;
	p_SupportFunctionPointerTypes = true;
	p_SupportExtendedTypes = true;
	p_AllowSetASCIIStringClass = false;
	p_AllowSetStringClass = false;
	p_AllowDisableNullReferenceCheckOnMemberAccess = false;
	p_SupportPointerArithmetics = false;
	p_AllowSetNullIntegerValue = false;
	p_NullIntegerValue = 0;
	p_AllowDisableBaseTypesArrayItemsInitialization = false;
	p_AllowDisableStaticsVarsInitialization = false;
	p_AllowDisableInstanceVarsInitialization = false;
	p_AllowIgnorePreviousAssingmentRules = true;
	p_AllowDisableAddressOfExpressionRequirementOnOutArguments = false;
	p_AllowFinalizeMethod = true;
	p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody = false;
	p_AllowSelectiveVirtualMembers = true;
	p_AllowNonLimitedGotos = false;
	p_AllowSetRuntimeTypeInformation = true;
	p_AllowSetRuntimeReflection = false;
	p_AllowLimitRuntimeReflectionToModuleOnly = false;
	p_AllowResumeExceptionModel = false;
	p_AllowTerminationExceptionModel = true;
	p_AllowFinallyBlocks = true;
	p_AllowResumeNext = true;
	p_AllowMixedExceptionModel = false;
	p_AllowAnyTypeExceptions = false;
	p_AllowStackVarsAsExceptions = true;
	p_AllowRuntimeChecksFragmentedConfiguration = false;
	p_SupportedOperators = DT_EMPTY;
	set_IsCaseSensitive(n_IsCaseSensitive);
	set_AllowDefaultSafeArrays(n_AllowDefaultSafeArrays);
	set_AllowDisableArrayLimitsChecks(n_AllowDisableArrayLimitsChecks);
	set_AllowUseSinglePointAsNamespaceSeparator(n_AllowUseSinglePointAsNamespaceSeparator);
	set_AllowUseSimpleMemberAccessAsNamespaceSeparator(n_AllowUseSimpleMemberAccessAsNamespaceSeparator);
	set_AllowMultipleInheritance(n_AllowMultipleInheritance);
	set_UseUniversalObjectBase(n_UseUniversalObjectBase);
	set_AllowSetUniversalObjectBase(n_AllowSetUniversalObjectBase);
	set_AllowDisableUnifiedTypeSystem(n_AllowDisableUnifiedTypeSystem);
	set_AllowEnableIntegerOverflowExceptions(n_AllowEnableIntegerOverflowExceptions);
	set_AllowEnableFloatOperationsExceptions(n_AllowEnableFloatOperationsExceptions);
	set_RequireIntegerOverflowExceptions(n_RequireIntegerOverflowExceptions);
	set_RequireFloatOperationsExceptions(n_RequireFloatOperationsExceptions);
	set_FullDecimalImplementation(n_FullDecimalImplementation);
	set_SupportASCIIChar(n_SupportASCIIChar);
	set_SupportASCIIString(n_SupportASCIIString);
	set_SupportUnsignedIntegers(n_SupportUnsignedIntegers);
	set_SupportExtendedValueTypes(n_SupportExtendedValueTypes);
	set_SupportExtendedReferenceTypes(n_SupportExtendedReferenceTypes);
	set_SupportFunctionPointerTypes(n_SupportFunctionPointerTypes);
	set_SupportExtendedTypes(n_SupportExtendedTypes);
	set_AllowSetASCIIStringClass(n_AllowSetASCIIStringClass);
	set_AllowSetStringClass(n_AllowSetStringClass);
	set_AllowDisableNullReferenceCheckOnMemberAccess(n_AllowDisableNullReferenceCheckOnMemberAccess);
	set_SupportPointerArithmetics(n_SupportPointerArithmetics);
	set_AllowSetNullIntegerValue(n_AllowSetNullIntegerValue);
	set_AllowDisableBaseTypesArrayItemsInitialization(n_AllowDisableBaseTypesArrayItemsInitialization);
	set_AllowDisableStaticsVarsInitialization(n_AllowDisableStaticsVarsInitialization);
	set_AllowDisableInstanceVarsInitialization(n_AllowDisableInstanceVarsInitialization);
	set_AllowIgnorePreviousAssingmentRules(n_AllowIgnorePreviousAssingmentRules);
	set_AllowDisableAddressOfExpressionRequirementOnOutArguments(n_AllowDisableAddressOfExpressionRequirementOnOutArguments);
	set_AllowFinalizeMethod(n_AllowFinalizeMethod);
	set_AllowNonNormalVirtualFunctionCallsOnConstructorsBody(n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody);
	set_AllowSelectiveVirtualMembers(n_AllowSelectiveVirtualMembers);
	set_AllowNonLimitedGotos(n_AllowNonLimitedGotos);
	set_AllowSetRuntimeTypeInformation(n_AllowSetRuntimeTypeInformation);
	set_AllowSetRuntimeReflection(n_AllowSetRuntimeReflection);
	set_AllowLimitRuntimeReflectionToModuleOnly(n_AllowLimitRuntimeReflectionToModuleOnly);
	set_AllowResumeExceptionModel(n_AllowResumeExceptionModel);
	set_AllowTerminationExceptionModel(n_AllowTerminationExceptionModel);
	set_AllowFinallyBlocks(n_AllowFinallyBlocks);
	set_AllowResumeNext(n_AllowResumeNext);
	set_AllowMixedExceptionModel(n_AllowMixedExceptionModel);
	set_AllowAnyTypeExceptions(n_AllowAnyTypeExceptions);
	set_AllowStackVarsAsExceptions(n_AllowStackVarsAsExceptions);
	set_AllowRuntimeChecksFragmentedConfiguration(n_AllowRuntimeChecksFragmentedConfiguration);
	p_GarbageCollector = new XplNodeList();
	p_GarbageCollector->set_Parent(this);
	p_GarbageCollector->set_InsertNodeCallback(&acceptInsertNodeCallback_GarbageCollector);
	p_GarbageCollector->set_RemoveNodeCallback(&acceptRemoveNodeCallback_GarbageCollector);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_GarbageCollector!=NULL)
	for(XplNode* node = n_GarbageCollector->FirstNode(); node != n_GarbageCollector->GetLastNode() ; node = n_GarbageCollector->NextNode()){
		p_GarbageCollector->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
XplOutputModuleCapabilities::XplOutputModuleCapabilities(bool n_IsCaseSensitive, bool n_AllowDefaultSafeArrays, bool n_AllowDisableArrayLimitsChecks, bool n_AllowUseSinglePointAsNamespaceSeparator, bool n_AllowUseSimpleMemberAccessAsNamespaceSeparator, bool n_AllowMultipleInheritance, bool n_UseUniversalObjectBase, bool n_AllowSetUniversalObjectBase, bool n_AllowDisableUnifiedTypeSystem, bool n_AllowEnableIntegerOverflowExceptions, bool n_AllowEnableFloatOperationsExceptions, bool n_RequireIntegerOverflowExceptions, bool n_RequireFloatOperationsExceptions, bool n_FullDecimalImplementation, bool n_SupportASCIIChar, bool n_SupportASCIIString, bool n_SupportUnsignedIntegers, bool n_SupportExtendedValueTypes, bool n_SupportExtendedReferenceTypes, bool n_SupportFunctionPointerTypes, bool n_SupportExtendedTypes, bool n_AllowSetASCIIStringClass, bool n_AllowSetStringClass, bool n_AllowDisableNullReferenceCheckOnMemberAccess, bool n_SupportPointerArithmetics, bool n_AllowSetNullIntegerValue, int n_NullIntegerValue, bool n_AllowDisableBaseTypesArrayItemsInitialization, bool n_AllowDisableStaticsVarsInitialization, bool n_AllowDisableInstanceVarsInitialization, bool n_AllowIgnorePreviousAssingmentRules, bool n_AllowDisableAddressOfExpressionRequirementOnOutArguments, bool n_AllowFinalizeMethod, bool n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody, bool n_AllowSelectiveVirtualMembers, bool n_AllowNonLimitedGotos, bool n_AllowSetRuntimeTypeInformation, bool n_AllowSetRuntimeReflection, bool n_AllowLimitRuntimeReflectionToModuleOnly, bool n_AllowResumeExceptionModel, bool n_AllowTerminationExceptionModel, bool n_AllowFinallyBlocks, bool n_AllowResumeNext, bool n_AllowMixedExceptionModel, bool n_AllowAnyTypeExceptions, bool n_AllowStackVarsAsExceptions, bool n_AllowRuntimeChecksFragmentedConfiguration, string n_SupportedOperators, XplNodeList* n_GarbageCollector){
	set_IsCaseSensitive(n_IsCaseSensitive);
	set_AllowDefaultSafeArrays(n_AllowDefaultSafeArrays);
	set_AllowDisableArrayLimitsChecks(n_AllowDisableArrayLimitsChecks);
	set_AllowUseSinglePointAsNamespaceSeparator(n_AllowUseSinglePointAsNamespaceSeparator);
	set_AllowUseSimpleMemberAccessAsNamespaceSeparator(n_AllowUseSimpleMemberAccessAsNamespaceSeparator);
	set_AllowMultipleInheritance(n_AllowMultipleInheritance);
	set_UseUniversalObjectBase(n_UseUniversalObjectBase);
	set_AllowSetUniversalObjectBase(n_AllowSetUniversalObjectBase);
	set_AllowDisableUnifiedTypeSystem(n_AllowDisableUnifiedTypeSystem);
	set_AllowEnableIntegerOverflowExceptions(n_AllowEnableIntegerOverflowExceptions);
	set_AllowEnableFloatOperationsExceptions(n_AllowEnableFloatOperationsExceptions);
	set_RequireIntegerOverflowExceptions(n_RequireIntegerOverflowExceptions);
	set_RequireFloatOperationsExceptions(n_RequireFloatOperationsExceptions);
	set_FullDecimalImplementation(n_FullDecimalImplementation);
	set_SupportASCIIChar(n_SupportASCIIChar);
	set_SupportASCIIString(n_SupportASCIIString);
	set_SupportUnsignedIntegers(n_SupportUnsignedIntegers);
	set_SupportExtendedValueTypes(n_SupportExtendedValueTypes);
	set_SupportExtendedReferenceTypes(n_SupportExtendedReferenceTypes);
	set_SupportFunctionPointerTypes(n_SupportFunctionPointerTypes);
	set_SupportExtendedTypes(n_SupportExtendedTypes);
	set_AllowSetASCIIStringClass(n_AllowSetASCIIStringClass);
	set_AllowSetStringClass(n_AllowSetStringClass);
	set_AllowDisableNullReferenceCheckOnMemberAccess(n_AllowDisableNullReferenceCheckOnMemberAccess);
	set_SupportPointerArithmetics(n_SupportPointerArithmetics);
	set_AllowSetNullIntegerValue(n_AllowSetNullIntegerValue);
	set_NullIntegerValue(n_NullIntegerValue);
	set_AllowDisableBaseTypesArrayItemsInitialization(n_AllowDisableBaseTypesArrayItemsInitialization);
	set_AllowDisableStaticsVarsInitialization(n_AllowDisableStaticsVarsInitialization);
	set_AllowDisableInstanceVarsInitialization(n_AllowDisableInstanceVarsInitialization);
	set_AllowIgnorePreviousAssingmentRules(n_AllowIgnorePreviousAssingmentRules);
	set_AllowDisableAddressOfExpressionRequirementOnOutArguments(n_AllowDisableAddressOfExpressionRequirementOnOutArguments);
	set_AllowFinalizeMethod(n_AllowFinalizeMethod);
	set_AllowNonNormalVirtualFunctionCallsOnConstructorsBody(n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody);
	set_AllowSelectiveVirtualMembers(n_AllowSelectiveVirtualMembers);
	set_AllowNonLimitedGotos(n_AllowNonLimitedGotos);
	set_AllowSetRuntimeTypeInformation(n_AllowSetRuntimeTypeInformation);
	set_AllowSetRuntimeReflection(n_AllowSetRuntimeReflection);
	set_AllowLimitRuntimeReflectionToModuleOnly(n_AllowLimitRuntimeReflectionToModuleOnly);
	set_AllowResumeExceptionModel(n_AllowResumeExceptionModel);
	set_AllowTerminationExceptionModel(n_AllowTerminationExceptionModel);
	set_AllowFinallyBlocks(n_AllowFinallyBlocks);
	set_AllowResumeNext(n_AllowResumeNext);
	set_AllowMixedExceptionModel(n_AllowMixedExceptionModel);
	set_AllowAnyTypeExceptions(n_AllowAnyTypeExceptions);
	set_AllowStackVarsAsExceptions(n_AllowStackVarsAsExceptions);
	set_AllowRuntimeChecksFragmentedConfiguration(n_AllowRuntimeChecksFragmentedConfiguration);
	set_SupportedOperators(n_SupportedOperators);
	p_GarbageCollector = new XplNodeList();
	p_GarbageCollector->set_Parent(this);
	p_GarbageCollector->set_InsertNodeCallback(&acceptInsertNodeCallback_GarbageCollector);
	p_GarbageCollector->set_RemoveNodeCallback(&acceptRemoveNodeCallback_GarbageCollector);
#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
	if(n_GarbageCollector!=NULL)
	for(XplNode* node = n_GarbageCollector->FirstNode(); node != n_GarbageCollector->GetLastNode() ; node = n_GarbageCollector->NextNode()){
		p_GarbageCollector->InsertAtEnd(node);
	}
#else
	p_Childs = n_Childs;
#endif
}
//Destructor
XplOutputModuleCapabilities::~XplOutputModuleCapabilities(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplOutputModuleCapabilities'");
#endif
	//Variables para Elementos de Secuencia
	if(p_GarbageCollector!=NULL)delete p_GarbageCollector;
}

//Funciones Sobreescritas de XplNode
XplNode* XplOutputModuleCapabilities::Clone(){
	XplOutputModuleCapabilities* copy = new XplOutputModuleCapabilities();
	copy->set_IsCaseSensitive(this->p_IsCaseSensitive);
	copy->set_AllowDefaultSafeArrays(this->p_AllowDefaultSafeArrays);
	copy->set_AllowDisableArrayLimitsChecks(this->p_AllowDisableArrayLimitsChecks);
	copy->set_AllowUseSinglePointAsNamespaceSeparator(this->p_AllowUseSinglePointAsNamespaceSeparator);
	copy->set_AllowUseSimpleMemberAccessAsNamespaceSeparator(this->p_AllowUseSimpleMemberAccessAsNamespaceSeparator);
	copy->set_AllowMultipleInheritance(this->p_AllowMultipleInheritance);
	copy->set_UseUniversalObjectBase(this->p_UseUniversalObjectBase);
	copy->set_AllowSetUniversalObjectBase(this->p_AllowSetUniversalObjectBase);
	copy->set_AllowDisableUnifiedTypeSystem(this->p_AllowDisableUnifiedTypeSystem);
	copy->set_AllowEnableIntegerOverflowExceptions(this->p_AllowEnableIntegerOverflowExceptions);
	copy->set_AllowEnableFloatOperationsExceptions(this->p_AllowEnableFloatOperationsExceptions);
	copy->set_RequireIntegerOverflowExceptions(this->p_RequireIntegerOverflowExceptions);
	copy->set_RequireFloatOperationsExceptions(this->p_RequireFloatOperationsExceptions);
	copy->set_FullDecimalImplementation(this->p_FullDecimalImplementation);
	copy->set_SupportASCIIChar(this->p_SupportASCIIChar);
	copy->set_SupportASCIIString(this->p_SupportASCIIString);
	copy->set_SupportUnsignedIntegers(this->p_SupportUnsignedIntegers);
	copy->set_SupportExtendedValueTypes(this->p_SupportExtendedValueTypes);
	copy->set_SupportExtendedReferenceTypes(this->p_SupportExtendedReferenceTypes);
	copy->set_SupportFunctionPointerTypes(this->p_SupportFunctionPointerTypes);
	copy->set_SupportExtendedTypes(this->p_SupportExtendedTypes);
	copy->set_AllowSetASCIIStringClass(this->p_AllowSetASCIIStringClass);
	copy->set_AllowSetStringClass(this->p_AllowSetStringClass);
	copy->set_AllowDisableNullReferenceCheckOnMemberAccess(this->p_AllowDisableNullReferenceCheckOnMemberAccess);
	copy->set_SupportPointerArithmetics(this->p_SupportPointerArithmetics);
	copy->set_AllowSetNullIntegerValue(this->p_AllowSetNullIntegerValue);
	copy->set_NullIntegerValue(this->p_NullIntegerValue);
	copy->set_AllowDisableBaseTypesArrayItemsInitialization(this->p_AllowDisableBaseTypesArrayItemsInitialization);
	copy->set_AllowDisableStaticsVarsInitialization(this->p_AllowDisableStaticsVarsInitialization);
	copy->set_AllowDisableInstanceVarsInitialization(this->p_AllowDisableInstanceVarsInitialization);
	copy->set_AllowIgnorePreviousAssingmentRules(this->p_AllowIgnorePreviousAssingmentRules);
	copy->set_AllowDisableAddressOfExpressionRequirementOnOutArguments(this->p_AllowDisableAddressOfExpressionRequirementOnOutArguments);
	copy->set_AllowFinalizeMethod(this->p_AllowFinalizeMethod);
	copy->set_AllowNonNormalVirtualFunctionCallsOnConstructorsBody(this->p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody);
	copy->set_AllowSelectiveVirtualMembers(this->p_AllowSelectiveVirtualMembers);
	copy->set_AllowNonLimitedGotos(this->p_AllowNonLimitedGotos);
	copy->set_AllowSetRuntimeTypeInformation(this->p_AllowSetRuntimeTypeInformation);
	copy->set_AllowSetRuntimeReflection(this->p_AllowSetRuntimeReflection);
	copy->set_AllowLimitRuntimeReflectionToModuleOnly(this->p_AllowLimitRuntimeReflectionToModuleOnly);
	copy->set_AllowResumeExceptionModel(this->p_AllowResumeExceptionModel);
	copy->set_AllowTerminationExceptionModel(this->p_AllowTerminationExceptionModel);
	copy->set_AllowFinallyBlocks(this->p_AllowFinallyBlocks);
	copy->set_AllowResumeNext(this->p_AllowResumeNext);
	copy->set_AllowMixedExceptionModel(this->p_AllowMixedExceptionModel);
	copy->set_AllowAnyTypeExceptions(this->p_AllowAnyTypeExceptions);
	copy->set_AllowStackVarsAsExceptions(this->p_AllowStackVarsAsExceptions);
	copy->set_AllowRuntimeChecksFragmentedConfiguration(this->p_AllowRuntimeChecksFragmentedConfiguration);
	copy->set_SupportedOperators(this->p_SupportedOperators);
	for(XplNode* node = p_GarbageCollector->FirstNode(); node != NULL ; node = p_GarbageCollector->NextNode()){
		copy->get_GarbageCollector()->InsertAtEnd(node->Clone());
	}
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplOutputModuleCapabilities::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_IsCaseSensitive != true)
		writer->write(DT(" IsCaseSensitive=\"")+CODEDOM_Att_ToString(p_IsCaseSensitive)+DT("\""));
	if(p_AllowDefaultSafeArrays != false)
		writer->write(DT(" AllowDefaultSafeArrays=\"")+CODEDOM_Att_ToString(p_AllowDefaultSafeArrays)+DT("\""));
	if(p_AllowDisableArrayLimitsChecks != false)
		writer->write(DT(" AllowDisableArrayLimitsChecks=\"")+CODEDOM_Att_ToString(p_AllowDisableArrayLimitsChecks)+DT("\""));
	if(p_AllowUseSinglePointAsNamespaceSeparator != false)
		writer->write(DT(" AllowUseSinglePointAsNamespaceSeparator=\"")+CODEDOM_Att_ToString(p_AllowUseSinglePointAsNamespaceSeparator)+DT("\""));
	if(p_AllowUseSimpleMemberAccessAsNamespaceSeparator != false)
		writer->write(DT(" AllowUseSimpleMemberAccessAsNamespaceSeparator=\"")+CODEDOM_Att_ToString(p_AllowUseSimpleMemberAccessAsNamespaceSeparator)+DT("\""));
	if(p_AllowMultipleInheritance != false)
		writer->write(DT(" AllowMultipleInheritance=\"")+CODEDOM_Att_ToString(p_AllowMultipleInheritance)+DT("\""));
	if(p_UseUniversalObjectBase != true)
		writer->write(DT(" UseUniversalObjectBase=\"")+CODEDOM_Att_ToString(p_UseUniversalObjectBase)+DT("\""));
	if(p_AllowSetUniversalObjectBase != false)
		writer->write(DT(" AllowSetUniversalObjectBase=\"")+CODEDOM_Att_ToString(p_AllowSetUniversalObjectBase)+DT("\""));
	if(p_AllowDisableUnifiedTypeSystem != false)
		writer->write(DT(" AllowDisableUnifiedTypeSystem=\"")+CODEDOM_Att_ToString(p_AllowDisableUnifiedTypeSystem)+DT("\""));
	if(p_AllowEnableIntegerOverflowExceptions != false)
		writer->write(DT(" AllowEnableIntegerOverflowExceptions=\"")+CODEDOM_Att_ToString(p_AllowEnableIntegerOverflowExceptions)+DT("\""));
	if(p_AllowEnableFloatOperationsExceptions != false)
		writer->write(DT(" AllowEnableFloatOperationsExceptions=\"")+CODEDOM_Att_ToString(p_AllowEnableFloatOperationsExceptions)+DT("\""));
	if(p_RequireIntegerOverflowExceptions != false)
		writer->write(DT(" RequireIntegerOverflowExceptions=\"")+CODEDOM_Att_ToString(p_RequireIntegerOverflowExceptions)+DT("\""));
	if(p_RequireFloatOperationsExceptions != false)
		writer->write(DT(" RequireFloatOperationsExceptions=\"")+CODEDOM_Att_ToString(p_RequireFloatOperationsExceptions)+DT("\""));
	if(p_FullDecimalImplementation != true)
		writer->write(DT(" FullDecimalImplementation=\"")+CODEDOM_Att_ToString(p_FullDecimalImplementation)+DT("\""));
	if(p_SupportASCIIChar != false)
		writer->write(DT(" SupportASCIIChar=\"")+CODEDOM_Att_ToString(p_SupportASCIIChar)+DT("\""));
	if(p_SupportASCIIString != false)
		writer->write(DT(" SupportASCIIString=\"")+CODEDOM_Att_ToString(p_SupportASCIIString)+DT("\""));
	if(p_SupportUnsignedIntegers != true)
		writer->write(DT(" SupportUnsignedIntegers=\"")+CODEDOM_Att_ToString(p_SupportUnsignedIntegers)+DT("\""));
	if(p_SupportExtendedValueTypes != true)
		writer->write(DT(" SupportExtendedValueTypes=\"")+CODEDOM_Att_ToString(p_SupportExtendedValueTypes)+DT("\""));
	if(p_SupportExtendedReferenceTypes != true)
		writer->write(DT(" SupportExtendedReferenceTypes=\"")+CODEDOM_Att_ToString(p_SupportExtendedReferenceTypes)+DT("\""));
	if(p_SupportFunctionPointerTypes != true)
		writer->write(DT(" SupportFunctionPointerTypes=\"")+CODEDOM_Att_ToString(p_SupportFunctionPointerTypes)+DT("\""));
	if(p_SupportExtendedTypes != true)
		writer->write(DT(" SupportExtendedTypes=\"")+CODEDOM_Att_ToString(p_SupportExtendedTypes)+DT("\""));
	if(p_AllowSetASCIIStringClass != false)
		writer->write(DT(" AllowSetASCIIStringClass=\"")+CODEDOM_Att_ToString(p_AllowSetASCIIStringClass)+DT("\""));
	if(p_AllowSetStringClass != false)
		writer->write(DT(" AllowSetStringClass=\"")+CODEDOM_Att_ToString(p_AllowSetStringClass)+DT("\""));
	if(p_AllowDisableNullReferenceCheckOnMemberAccess != false)
		writer->write(DT(" AllowDisableNullReferenceCheckOnMemberAccess=\"")+CODEDOM_Att_ToString(p_AllowDisableNullReferenceCheckOnMemberAccess)+DT("\""));
	if(p_SupportPointerArithmetics != false)
		writer->write(DT(" SupportPointerArithmetics=\"")+CODEDOM_Att_ToString(p_SupportPointerArithmetics)+DT("\""));
	if(p_AllowSetNullIntegerValue != false)
		writer->write(DT(" AllowSetNullIntegerValue=\"")+CODEDOM_Att_ToString(p_AllowSetNullIntegerValue)+DT("\""));
	if(p_NullIntegerValue != 0)
		writer->write(DT(" NullIntegerValue=\"")+CODEDOM_Att_ToString(p_NullIntegerValue)+DT("\""));
	if(p_AllowDisableBaseTypesArrayItemsInitialization != false)
		writer->write(DT(" AllowDisableBaseTypesArrayItemsInitialization=\"")+CODEDOM_Att_ToString(p_AllowDisableBaseTypesArrayItemsInitialization)+DT("\""));
	if(p_AllowDisableStaticsVarsInitialization != false)
		writer->write(DT(" AllowDisableStaticsVarsInitialization=\"")+CODEDOM_Att_ToString(p_AllowDisableStaticsVarsInitialization)+DT("\""));
	if(p_AllowDisableInstanceVarsInitialization != false)
		writer->write(DT(" AllowDisableInstanceVarsInitialization=\"")+CODEDOM_Att_ToString(p_AllowDisableInstanceVarsInitialization)+DT("\""));
	if(p_AllowIgnorePreviousAssingmentRules != true)
		writer->write(DT(" AllowIgnorePreviousAssingmentRules=\"")+CODEDOM_Att_ToString(p_AllowIgnorePreviousAssingmentRules)+DT("\""));
	if(p_AllowDisableAddressOfExpressionRequirementOnOutArguments != false)
		writer->write(DT(" AllowDisableAddressOfExpressionRequirementOnOutArguments=\"")+CODEDOM_Att_ToString(p_AllowDisableAddressOfExpressionRequirementOnOutArguments)+DT("\""));
	if(p_AllowFinalizeMethod != true)
		writer->write(DT(" AllowFinalizeMethod=\"")+CODEDOM_Att_ToString(p_AllowFinalizeMethod)+DT("\""));
	if(p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody != false)
		writer->write(DT(" AllowNonNormalVirtualFunctionCallsOnConstructorsBody=\"")+CODEDOM_Att_ToString(p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody)+DT("\""));
	if(p_AllowSelectiveVirtualMembers != true)
		writer->write(DT(" AllowSelectiveVirtualMembers=\"")+CODEDOM_Att_ToString(p_AllowSelectiveVirtualMembers)+DT("\""));
	if(p_AllowNonLimitedGotos != false)
		writer->write(DT(" AllowNonLimitedGotos=\"")+CODEDOM_Att_ToString(p_AllowNonLimitedGotos)+DT("\""));
	if(p_AllowSetRuntimeTypeInformation != true)
		writer->write(DT(" AllowSetRuntimeTypeInformation=\"")+CODEDOM_Att_ToString(p_AllowSetRuntimeTypeInformation)+DT("\""));
	if(p_AllowSetRuntimeReflection != false)
		writer->write(DT(" AllowSetRuntimeReflection=\"")+CODEDOM_Att_ToString(p_AllowSetRuntimeReflection)+DT("\""));
	if(p_AllowLimitRuntimeReflectionToModuleOnly != false)
		writer->write(DT(" AllowLimitRuntimeReflectionToModuleOnly=\"")+CODEDOM_Att_ToString(p_AllowLimitRuntimeReflectionToModuleOnly)+DT("\""));
	if(p_AllowResumeExceptionModel != false)
		writer->write(DT(" AllowResumeExceptionModel=\"")+CODEDOM_Att_ToString(p_AllowResumeExceptionModel)+DT("\""));
	if(p_AllowTerminationExceptionModel != true)
		writer->write(DT(" AllowTerminationExceptionModel=\"")+CODEDOM_Att_ToString(p_AllowTerminationExceptionModel)+DT("\""));
	if(p_AllowFinallyBlocks != true)
		writer->write(DT(" AllowFinallyBlocks=\"")+CODEDOM_Att_ToString(p_AllowFinallyBlocks)+DT("\""));
	if(p_AllowResumeNext != true)
		writer->write(DT(" AllowResumeNext=\"")+CODEDOM_Att_ToString(p_AllowResumeNext)+DT("\""));
	if(p_AllowMixedExceptionModel != false)
		writer->write(DT(" AllowMixedExceptionModel=\"")+CODEDOM_Att_ToString(p_AllowMixedExceptionModel)+DT("\""));
	if(p_AllowAnyTypeExceptions != false)
		writer->write(DT(" AllowAnyTypeExceptions=\"")+CODEDOM_Att_ToString(p_AllowAnyTypeExceptions)+DT("\""));
	if(p_AllowStackVarsAsExceptions != true)
		writer->write(DT(" AllowStackVarsAsExceptions=\"")+CODEDOM_Att_ToString(p_AllowStackVarsAsExceptions)+DT("\""));
	if(p_AllowRuntimeChecksFragmentedConfiguration != false)
		writer->write(DT(" AllowRuntimeChecksFragmentedConfiguration=\"")+CODEDOM_Att_ToString(p_AllowRuntimeChecksFragmentedConfiguration)+DT("\""));
	if(p_SupportedOperators != DT_EMPTY)
		writer->write(DT(" SupportedOperators=\"")+CODEDOM_Att_ToString(p_SupportedOperators)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_GarbageCollector!=NULL)if(!p_GarbageCollector->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplOutputModuleCapabilities::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
bool XplOutputModuleCapabilities::get_IsCaseSensitive(){
	return p_IsCaseSensitive;
}
bool XplOutputModuleCapabilities::get_AllowDefaultSafeArrays(){
	return p_AllowDefaultSafeArrays;
}
bool XplOutputModuleCapabilities::get_AllowDisableArrayLimitsChecks(){
	return p_AllowDisableArrayLimitsChecks;
}
bool XplOutputModuleCapabilities::get_AllowUseSinglePointAsNamespaceSeparator(){
	return p_AllowUseSinglePointAsNamespaceSeparator;
}
bool XplOutputModuleCapabilities::get_AllowUseSimpleMemberAccessAsNamespaceSeparator(){
	return p_AllowUseSimpleMemberAccessAsNamespaceSeparator;
}
bool XplOutputModuleCapabilities::get_AllowMultipleInheritance(){
	return p_AllowMultipleInheritance;
}
bool XplOutputModuleCapabilities::get_UseUniversalObjectBase(){
	return p_UseUniversalObjectBase;
}
bool XplOutputModuleCapabilities::get_AllowSetUniversalObjectBase(){
	return p_AllowSetUniversalObjectBase;
}
bool XplOutputModuleCapabilities::get_AllowDisableUnifiedTypeSystem(){
	return p_AllowDisableUnifiedTypeSystem;
}
bool XplOutputModuleCapabilities::get_AllowEnableIntegerOverflowExceptions(){
	return p_AllowEnableIntegerOverflowExceptions;
}
bool XplOutputModuleCapabilities::get_AllowEnableFloatOperationsExceptions(){
	return p_AllowEnableFloatOperationsExceptions;
}
bool XplOutputModuleCapabilities::get_RequireIntegerOverflowExceptions(){
	return p_RequireIntegerOverflowExceptions;
}
bool XplOutputModuleCapabilities::get_RequireFloatOperationsExceptions(){
	return p_RequireFloatOperationsExceptions;
}
bool XplOutputModuleCapabilities::get_FullDecimalImplementation(){
	return p_FullDecimalImplementation;
}
bool XplOutputModuleCapabilities::get_SupportASCIIChar(){
	return p_SupportASCIIChar;
}
bool XplOutputModuleCapabilities::get_SupportASCIIString(){
	return p_SupportASCIIString;
}
bool XplOutputModuleCapabilities::get_SupportUnsignedIntegers(){
	return p_SupportUnsignedIntegers;
}
bool XplOutputModuleCapabilities::get_SupportExtendedValueTypes(){
	return p_SupportExtendedValueTypes;
}
bool XplOutputModuleCapabilities::get_SupportExtendedReferenceTypes(){
	return p_SupportExtendedReferenceTypes;
}
bool XplOutputModuleCapabilities::get_SupportFunctionPointerTypes(){
	return p_SupportFunctionPointerTypes;
}
bool XplOutputModuleCapabilities::get_SupportExtendedTypes(){
	return p_SupportExtendedTypes;
}
bool XplOutputModuleCapabilities::get_AllowSetASCIIStringClass(){
	return p_AllowSetASCIIStringClass;
}
bool XplOutputModuleCapabilities::get_AllowSetStringClass(){
	return p_AllowSetStringClass;
}
bool XplOutputModuleCapabilities::get_AllowDisableNullReferenceCheckOnMemberAccess(){
	return p_AllowDisableNullReferenceCheckOnMemberAccess;
}
bool XplOutputModuleCapabilities::get_SupportPointerArithmetics(){
	return p_SupportPointerArithmetics;
}
bool XplOutputModuleCapabilities::get_AllowSetNullIntegerValue(){
	return p_AllowSetNullIntegerValue;
}
int XplOutputModuleCapabilities::get_NullIntegerValue(){
	return p_NullIntegerValue;
}
bool XplOutputModuleCapabilities::get_AllowDisableBaseTypesArrayItemsInitialization(){
	return p_AllowDisableBaseTypesArrayItemsInitialization;
}
bool XplOutputModuleCapabilities::get_AllowDisableStaticsVarsInitialization(){
	return p_AllowDisableStaticsVarsInitialization;
}
bool XplOutputModuleCapabilities::get_AllowDisableInstanceVarsInitialization(){
	return p_AllowDisableInstanceVarsInitialization;
}
bool XplOutputModuleCapabilities::get_AllowIgnorePreviousAssingmentRules(){
	return p_AllowIgnorePreviousAssingmentRules;
}
bool XplOutputModuleCapabilities::get_AllowDisableAddressOfExpressionRequirementOnOutArguments(){
	return p_AllowDisableAddressOfExpressionRequirementOnOutArguments;
}
bool XplOutputModuleCapabilities::get_AllowFinalizeMethod(){
	return p_AllowFinalizeMethod;
}
bool XplOutputModuleCapabilities::get_AllowNonNormalVirtualFunctionCallsOnConstructorsBody(){
	return p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody;
}
bool XplOutputModuleCapabilities::get_AllowSelectiveVirtualMembers(){
	return p_AllowSelectiveVirtualMembers;
}
bool XplOutputModuleCapabilities::get_AllowNonLimitedGotos(){
	return p_AllowNonLimitedGotos;
}
bool XplOutputModuleCapabilities::get_AllowSetRuntimeTypeInformation(){
	return p_AllowSetRuntimeTypeInformation;
}
bool XplOutputModuleCapabilities::get_AllowSetRuntimeReflection(){
	return p_AllowSetRuntimeReflection;
}
bool XplOutputModuleCapabilities::get_AllowLimitRuntimeReflectionToModuleOnly(){
	return p_AllowLimitRuntimeReflectionToModuleOnly;
}
bool XplOutputModuleCapabilities::get_AllowResumeExceptionModel(){
	return p_AllowResumeExceptionModel;
}
bool XplOutputModuleCapabilities::get_AllowTerminationExceptionModel(){
	return p_AllowTerminationExceptionModel;
}
bool XplOutputModuleCapabilities::get_AllowFinallyBlocks(){
	return p_AllowFinallyBlocks;
}
bool XplOutputModuleCapabilities::get_AllowResumeNext(){
	return p_AllowResumeNext;
}
bool XplOutputModuleCapabilities::get_AllowMixedExceptionModel(){
	return p_AllowMixedExceptionModel;
}
bool XplOutputModuleCapabilities::get_AllowAnyTypeExceptions(){
	return p_AllowAnyTypeExceptions;
}
bool XplOutputModuleCapabilities::get_AllowStackVarsAsExceptions(){
	return p_AllowStackVarsAsExceptions;
}
bool XplOutputModuleCapabilities::get_AllowRuntimeChecksFragmentedConfiguration(){
	return p_AllowRuntimeChecksFragmentedConfiguration;
}
string XplOutputModuleCapabilities::get_SupportedOperators(){
	return p_SupportedOperators;
}

//Funciones para obtener Elementos de Secuencia
XplNodeList* XplOutputModuleCapabilities::get_GarbageCollector(){
	return p_GarbageCollector;
}

//Funciones para setear Atributos
bool XplOutputModuleCapabilities::set_IsCaseSensitive(bool new_IsCaseSensitive){
	bool back_IsCaseSensitive = p_IsCaseSensitive;
	p_IsCaseSensitive = new_IsCaseSensitive;
	return back_IsCaseSensitive;
}
bool XplOutputModuleCapabilities::set_AllowDefaultSafeArrays(bool new_AllowDefaultSafeArrays){
	bool back_AllowDefaultSafeArrays = p_AllowDefaultSafeArrays;
	p_AllowDefaultSafeArrays = new_AllowDefaultSafeArrays;
	return back_AllowDefaultSafeArrays;
}
bool XplOutputModuleCapabilities::set_AllowDisableArrayLimitsChecks(bool new_AllowDisableArrayLimitsChecks){
	bool back_AllowDisableArrayLimitsChecks = p_AllowDisableArrayLimitsChecks;
	p_AllowDisableArrayLimitsChecks = new_AllowDisableArrayLimitsChecks;
	return back_AllowDisableArrayLimitsChecks;
}
bool XplOutputModuleCapabilities::set_AllowUseSinglePointAsNamespaceSeparator(bool new_AllowUseSinglePointAsNamespaceSeparator){
	bool back_AllowUseSinglePointAsNamespaceSeparator = p_AllowUseSinglePointAsNamespaceSeparator;
	p_AllowUseSinglePointAsNamespaceSeparator = new_AllowUseSinglePointAsNamespaceSeparator;
	return back_AllowUseSinglePointAsNamespaceSeparator;
}
bool XplOutputModuleCapabilities::set_AllowUseSimpleMemberAccessAsNamespaceSeparator(bool new_AllowUseSimpleMemberAccessAsNamespaceSeparator){
	bool back_AllowUseSimpleMemberAccessAsNamespaceSeparator = p_AllowUseSimpleMemberAccessAsNamespaceSeparator;
	p_AllowUseSimpleMemberAccessAsNamespaceSeparator = new_AllowUseSimpleMemberAccessAsNamespaceSeparator;
	return back_AllowUseSimpleMemberAccessAsNamespaceSeparator;
}
bool XplOutputModuleCapabilities::set_AllowMultipleInheritance(bool new_AllowMultipleInheritance){
	bool back_AllowMultipleInheritance = p_AllowMultipleInheritance;
	p_AllowMultipleInheritance = new_AllowMultipleInheritance;
	return back_AllowMultipleInheritance;
}
bool XplOutputModuleCapabilities::set_UseUniversalObjectBase(bool new_UseUniversalObjectBase){
	bool back_UseUniversalObjectBase = p_UseUniversalObjectBase;
	p_UseUniversalObjectBase = new_UseUniversalObjectBase;
	return back_UseUniversalObjectBase;
}
bool XplOutputModuleCapabilities::set_AllowSetUniversalObjectBase(bool new_AllowSetUniversalObjectBase){
	bool back_AllowSetUniversalObjectBase = p_AllowSetUniversalObjectBase;
	p_AllowSetUniversalObjectBase = new_AllowSetUniversalObjectBase;
	return back_AllowSetUniversalObjectBase;
}
bool XplOutputModuleCapabilities::set_AllowDisableUnifiedTypeSystem(bool new_AllowDisableUnifiedTypeSystem){
	bool back_AllowDisableUnifiedTypeSystem = p_AllowDisableUnifiedTypeSystem;
	p_AllowDisableUnifiedTypeSystem = new_AllowDisableUnifiedTypeSystem;
	return back_AllowDisableUnifiedTypeSystem;
}
bool XplOutputModuleCapabilities::set_AllowEnableIntegerOverflowExceptions(bool new_AllowEnableIntegerOverflowExceptions){
	bool back_AllowEnableIntegerOverflowExceptions = p_AllowEnableIntegerOverflowExceptions;
	p_AllowEnableIntegerOverflowExceptions = new_AllowEnableIntegerOverflowExceptions;
	return back_AllowEnableIntegerOverflowExceptions;
}
bool XplOutputModuleCapabilities::set_AllowEnableFloatOperationsExceptions(bool new_AllowEnableFloatOperationsExceptions){
	bool back_AllowEnableFloatOperationsExceptions = p_AllowEnableFloatOperationsExceptions;
	p_AllowEnableFloatOperationsExceptions = new_AllowEnableFloatOperationsExceptions;
	return back_AllowEnableFloatOperationsExceptions;
}
bool XplOutputModuleCapabilities::set_RequireIntegerOverflowExceptions(bool new_RequireIntegerOverflowExceptions){
	bool back_RequireIntegerOverflowExceptions = p_RequireIntegerOverflowExceptions;
	p_RequireIntegerOverflowExceptions = new_RequireIntegerOverflowExceptions;
	return back_RequireIntegerOverflowExceptions;
}
bool XplOutputModuleCapabilities::set_RequireFloatOperationsExceptions(bool new_RequireFloatOperationsExceptions){
	bool back_RequireFloatOperationsExceptions = p_RequireFloatOperationsExceptions;
	p_RequireFloatOperationsExceptions = new_RequireFloatOperationsExceptions;
	return back_RequireFloatOperationsExceptions;
}
bool XplOutputModuleCapabilities::set_FullDecimalImplementation(bool new_FullDecimalImplementation){
	bool back_FullDecimalImplementation = p_FullDecimalImplementation;
	p_FullDecimalImplementation = new_FullDecimalImplementation;
	return back_FullDecimalImplementation;
}
bool XplOutputModuleCapabilities::set_SupportASCIIChar(bool new_SupportASCIIChar){
	bool back_SupportASCIIChar = p_SupportASCIIChar;
	p_SupportASCIIChar = new_SupportASCIIChar;
	return back_SupportASCIIChar;
}
bool XplOutputModuleCapabilities::set_SupportASCIIString(bool new_SupportASCIIString){
	bool back_SupportASCIIString = p_SupportASCIIString;
	p_SupportASCIIString = new_SupportASCIIString;
	return back_SupportASCIIString;
}
bool XplOutputModuleCapabilities::set_SupportUnsignedIntegers(bool new_SupportUnsignedIntegers){
	bool back_SupportUnsignedIntegers = p_SupportUnsignedIntegers;
	p_SupportUnsignedIntegers = new_SupportUnsignedIntegers;
	return back_SupportUnsignedIntegers;
}
bool XplOutputModuleCapabilities::set_SupportExtendedValueTypes(bool new_SupportExtendedValueTypes){
	bool back_SupportExtendedValueTypes = p_SupportExtendedValueTypes;
	p_SupportExtendedValueTypes = new_SupportExtendedValueTypes;
	return back_SupportExtendedValueTypes;
}
bool XplOutputModuleCapabilities::set_SupportExtendedReferenceTypes(bool new_SupportExtendedReferenceTypes){
	bool back_SupportExtendedReferenceTypes = p_SupportExtendedReferenceTypes;
	p_SupportExtendedReferenceTypes = new_SupportExtendedReferenceTypes;
	return back_SupportExtendedReferenceTypes;
}
bool XplOutputModuleCapabilities::set_SupportFunctionPointerTypes(bool new_SupportFunctionPointerTypes){
	bool back_SupportFunctionPointerTypes = p_SupportFunctionPointerTypes;
	p_SupportFunctionPointerTypes = new_SupportFunctionPointerTypes;
	return back_SupportFunctionPointerTypes;
}
bool XplOutputModuleCapabilities::set_SupportExtendedTypes(bool new_SupportExtendedTypes){
	bool back_SupportExtendedTypes = p_SupportExtendedTypes;
	p_SupportExtendedTypes = new_SupportExtendedTypes;
	return back_SupportExtendedTypes;
}
bool XplOutputModuleCapabilities::set_AllowSetASCIIStringClass(bool new_AllowSetASCIIStringClass){
	bool back_AllowSetASCIIStringClass = p_AllowSetASCIIStringClass;
	p_AllowSetASCIIStringClass = new_AllowSetASCIIStringClass;
	return back_AllowSetASCIIStringClass;
}
bool XplOutputModuleCapabilities::set_AllowSetStringClass(bool new_AllowSetStringClass){
	bool back_AllowSetStringClass = p_AllowSetStringClass;
	p_AllowSetStringClass = new_AllowSetStringClass;
	return back_AllowSetStringClass;
}
bool XplOutputModuleCapabilities::set_AllowDisableNullReferenceCheckOnMemberAccess(bool new_AllowDisableNullReferenceCheckOnMemberAccess){
	bool back_AllowDisableNullReferenceCheckOnMemberAccess = p_AllowDisableNullReferenceCheckOnMemberAccess;
	p_AllowDisableNullReferenceCheckOnMemberAccess = new_AllowDisableNullReferenceCheckOnMemberAccess;
	return back_AllowDisableNullReferenceCheckOnMemberAccess;
}
bool XplOutputModuleCapabilities::set_SupportPointerArithmetics(bool new_SupportPointerArithmetics){
	bool back_SupportPointerArithmetics = p_SupportPointerArithmetics;
	p_SupportPointerArithmetics = new_SupportPointerArithmetics;
	return back_SupportPointerArithmetics;
}
bool XplOutputModuleCapabilities::set_AllowSetNullIntegerValue(bool new_AllowSetNullIntegerValue){
	bool back_AllowSetNullIntegerValue = p_AllowSetNullIntegerValue;
	p_AllowSetNullIntegerValue = new_AllowSetNullIntegerValue;
	return back_AllowSetNullIntegerValue;
}
int XplOutputModuleCapabilities::set_NullIntegerValue(int new_NullIntegerValue){
	int back_NullIntegerValue = p_NullIntegerValue;
	p_NullIntegerValue = new_NullIntegerValue;
	return back_NullIntegerValue;
}
bool XplOutputModuleCapabilities::set_AllowDisableBaseTypesArrayItemsInitialization(bool new_AllowDisableBaseTypesArrayItemsInitialization){
	bool back_AllowDisableBaseTypesArrayItemsInitialization = p_AllowDisableBaseTypesArrayItemsInitialization;
	p_AllowDisableBaseTypesArrayItemsInitialization = new_AllowDisableBaseTypesArrayItemsInitialization;
	return back_AllowDisableBaseTypesArrayItemsInitialization;
}
bool XplOutputModuleCapabilities::set_AllowDisableStaticsVarsInitialization(bool new_AllowDisableStaticsVarsInitialization){
	bool back_AllowDisableStaticsVarsInitialization = p_AllowDisableStaticsVarsInitialization;
	p_AllowDisableStaticsVarsInitialization = new_AllowDisableStaticsVarsInitialization;
	return back_AllowDisableStaticsVarsInitialization;
}
bool XplOutputModuleCapabilities::set_AllowDisableInstanceVarsInitialization(bool new_AllowDisableInstanceVarsInitialization){
	bool back_AllowDisableInstanceVarsInitialization = p_AllowDisableInstanceVarsInitialization;
	p_AllowDisableInstanceVarsInitialization = new_AllowDisableInstanceVarsInitialization;
	return back_AllowDisableInstanceVarsInitialization;
}
bool XplOutputModuleCapabilities::set_AllowIgnorePreviousAssingmentRules(bool new_AllowIgnorePreviousAssingmentRules){
	bool back_AllowIgnorePreviousAssingmentRules = p_AllowIgnorePreviousAssingmentRules;
	p_AllowIgnorePreviousAssingmentRules = new_AllowIgnorePreviousAssingmentRules;
	return back_AllowIgnorePreviousAssingmentRules;
}
bool XplOutputModuleCapabilities::set_AllowDisableAddressOfExpressionRequirementOnOutArguments(bool new_AllowDisableAddressOfExpressionRequirementOnOutArguments){
	bool back_AllowDisableAddressOfExpressionRequirementOnOutArguments = p_AllowDisableAddressOfExpressionRequirementOnOutArguments;
	p_AllowDisableAddressOfExpressionRequirementOnOutArguments = new_AllowDisableAddressOfExpressionRequirementOnOutArguments;
	return back_AllowDisableAddressOfExpressionRequirementOnOutArguments;
}
bool XplOutputModuleCapabilities::set_AllowFinalizeMethod(bool new_AllowFinalizeMethod){
	bool back_AllowFinalizeMethod = p_AllowFinalizeMethod;
	p_AllowFinalizeMethod = new_AllowFinalizeMethod;
	return back_AllowFinalizeMethod;
}
bool XplOutputModuleCapabilities::set_AllowNonNormalVirtualFunctionCallsOnConstructorsBody(bool new_AllowNonNormalVirtualFunctionCallsOnConstructorsBody){
	bool back_AllowNonNormalVirtualFunctionCallsOnConstructorsBody = p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody;
	p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody = new_AllowNonNormalVirtualFunctionCallsOnConstructorsBody;
	return back_AllowNonNormalVirtualFunctionCallsOnConstructorsBody;
}
bool XplOutputModuleCapabilities::set_AllowSelectiveVirtualMembers(bool new_AllowSelectiveVirtualMembers){
	bool back_AllowSelectiveVirtualMembers = p_AllowSelectiveVirtualMembers;
	p_AllowSelectiveVirtualMembers = new_AllowSelectiveVirtualMembers;
	return back_AllowSelectiveVirtualMembers;
}
bool XplOutputModuleCapabilities::set_AllowNonLimitedGotos(bool new_AllowNonLimitedGotos){
	bool back_AllowNonLimitedGotos = p_AllowNonLimitedGotos;
	p_AllowNonLimitedGotos = new_AllowNonLimitedGotos;
	return back_AllowNonLimitedGotos;
}
bool XplOutputModuleCapabilities::set_AllowSetRuntimeTypeInformation(bool new_AllowSetRuntimeTypeInformation){
	bool back_AllowSetRuntimeTypeInformation = p_AllowSetRuntimeTypeInformation;
	p_AllowSetRuntimeTypeInformation = new_AllowSetRuntimeTypeInformation;
	return back_AllowSetRuntimeTypeInformation;
}
bool XplOutputModuleCapabilities::set_AllowSetRuntimeReflection(bool new_AllowSetRuntimeReflection){
	bool back_AllowSetRuntimeReflection = p_AllowSetRuntimeReflection;
	p_AllowSetRuntimeReflection = new_AllowSetRuntimeReflection;
	return back_AllowSetRuntimeReflection;
}
bool XplOutputModuleCapabilities::set_AllowLimitRuntimeReflectionToModuleOnly(bool new_AllowLimitRuntimeReflectionToModuleOnly){
	bool back_AllowLimitRuntimeReflectionToModuleOnly = p_AllowLimitRuntimeReflectionToModuleOnly;
	p_AllowLimitRuntimeReflectionToModuleOnly = new_AllowLimitRuntimeReflectionToModuleOnly;
	return back_AllowLimitRuntimeReflectionToModuleOnly;
}
bool XplOutputModuleCapabilities::set_AllowResumeExceptionModel(bool new_AllowResumeExceptionModel){
	bool back_AllowResumeExceptionModel = p_AllowResumeExceptionModel;
	p_AllowResumeExceptionModel = new_AllowResumeExceptionModel;
	return back_AllowResumeExceptionModel;
}
bool XplOutputModuleCapabilities::set_AllowTerminationExceptionModel(bool new_AllowTerminationExceptionModel){
	bool back_AllowTerminationExceptionModel = p_AllowTerminationExceptionModel;
	p_AllowTerminationExceptionModel = new_AllowTerminationExceptionModel;
	return back_AllowTerminationExceptionModel;
}
bool XplOutputModuleCapabilities::set_AllowFinallyBlocks(bool new_AllowFinallyBlocks){
	bool back_AllowFinallyBlocks = p_AllowFinallyBlocks;
	p_AllowFinallyBlocks = new_AllowFinallyBlocks;
	return back_AllowFinallyBlocks;
}
bool XplOutputModuleCapabilities::set_AllowResumeNext(bool new_AllowResumeNext){
	bool back_AllowResumeNext = p_AllowResumeNext;
	p_AllowResumeNext = new_AllowResumeNext;
	return back_AllowResumeNext;
}
bool XplOutputModuleCapabilities::set_AllowMixedExceptionModel(bool new_AllowMixedExceptionModel){
	bool back_AllowMixedExceptionModel = p_AllowMixedExceptionModel;
	p_AllowMixedExceptionModel = new_AllowMixedExceptionModel;
	return back_AllowMixedExceptionModel;
}
bool XplOutputModuleCapabilities::set_AllowAnyTypeExceptions(bool new_AllowAnyTypeExceptions){
	bool back_AllowAnyTypeExceptions = p_AllowAnyTypeExceptions;
	p_AllowAnyTypeExceptions = new_AllowAnyTypeExceptions;
	return back_AllowAnyTypeExceptions;
}
bool XplOutputModuleCapabilities::set_AllowStackVarsAsExceptions(bool new_AllowStackVarsAsExceptions){
	bool back_AllowStackVarsAsExceptions = p_AllowStackVarsAsExceptions;
	p_AllowStackVarsAsExceptions = new_AllowStackVarsAsExceptions;
	return back_AllowStackVarsAsExceptions;
}
bool XplOutputModuleCapabilities::set_AllowRuntimeChecksFragmentedConfiguration(bool new_AllowRuntimeChecksFragmentedConfiguration){
	bool back_AllowRuntimeChecksFragmentedConfiguration = p_AllowRuntimeChecksFragmentedConfiguration;
	p_AllowRuntimeChecksFragmentedConfiguration = new_AllowRuntimeChecksFragmentedConfiguration;
	return back_AllowRuntimeChecksFragmentedConfiguration;
}
string XplOutputModuleCapabilities::set_SupportedOperators(string new_SupportedOperators){
	string back_SupportedOperators = p_SupportedOperators;
	p_SupportedOperators = new_SupportedOperators;
	return back_SupportedOperators;
}

//Funciones para setear Elementos de Secuencia
	bool XplOutputModuleCapabilities::acceptInsertNodeCallback_GarbageCollector(XplNode* node, string* errorMsg, XplNode* parent){
		if(node==NULL)return false;
		if(node->get_ElementName()==DT("GarbageCollector")){
			if(node->get_ContentTypeName()!=CODEDOMTYPES_ZOEGARBAGECOLLECTOR){
				errorMsg = new string(DT("El elemento de tipo '")+node->get_ContentTypeNameString()+DT("' no es valido como componente de 'XplGarbageCollector'."));
				return false;
			}
			node->set_Parent(parent);
			return true;
		}
		errorMsg = new string(DT("El elemento de nombre '")+node->get_ElementName()+DT("' no es valido como componente de 'XplGarbageCollector'."));
		return false;
	}
	bool XplOutputModuleCapabilities::acceptRemoveNodeCallback_GarbageCollector(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}
XplGarbageCollector* XplOutputModuleCapabilities::new_GarbageCollector(){
	XplGarbageCollector* node = new XplGarbageCollector();
	node->set_ElementName(DT("GarbageCollector"));
	return node;
}

}

#endif
