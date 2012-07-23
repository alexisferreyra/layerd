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
using System.Xml;
using System.IO;

namespace LayerD.CodeDOM{

[Serializable]
public class XplOutputModuleCapabilities:  XplNode{

	#region Variables privadas para atributos y elementos
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
	XplNodeList p_GarbageCollector;
	#endregion

	#region Region de Constructores Publicos
	public XplOutputModuleCapabilities(){
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
		p_SupportedOperators = "";
		p_GarbageCollector = new XplNodeList();
		p_GarbageCollector.set_Parent(this);
		p_GarbageCollector.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_GarbageCollector));
		p_GarbageCollector.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_GarbageCollector));
}
	public XplOutputModuleCapabilities(bool n_IsCaseSensitive, bool n_AllowDefaultSafeArrays, bool n_AllowDisableArrayLimitsChecks, bool n_AllowUseSinglePointAsNamespaceSeparator, bool n_AllowUseSimpleMemberAccessAsNamespaceSeparator, bool n_AllowMultipleInheritance, bool n_UseUniversalObjectBase, bool n_AllowSetUniversalObjectBase, bool n_AllowDisableUnifiedTypeSystem, bool n_AllowEnableIntegerOverflowExceptions, bool n_AllowEnableFloatOperationsExceptions, bool n_RequireIntegerOverflowExceptions, bool n_RequireFloatOperationsExceptions, bool n_FullDecimalImplementation, bool n_SupportASCIIChar, bool n_SupportASCIIString, bool n_SupportUnsignedIntegers, bool n_SupportExtendedValueTypes, bool n_SupportExtendedReferenceTypes, bool n_SupportFunctionPointerTypes, bool n_SupportExtendedTypes, bool n_AllowSetASCIIStringClass, bool n_AllowSetStringClass, bool n_AllowDisableNullReferenceCheckOnMemberAccess, bool n_SupportPointerArithmetics, bool n_AllowSetNullIntegerValue, bool n_AllowDisableBaseTypesArrayItemsInitialization, bool n_AllowDisableStaticsVarsInitialization, bool n_AllowDisableInstanceVarsInitialization, bool n_AllowIgnorePreviousAssingmentRules, bool n_AllowDisableAddressOfExpressionRequirementOnOutArguments, bool n_AllowFinalizeMethod, bool n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody, bool n_AllowSelectiveVirtualMembers, bool n_AllowNonLimitedGotos, bool n_AllowSetRuntimeTypeInformation, bool n_AllowSetRuntimeReflection, bool n_AllowLimitRuntimeReflectionToModuleOnly, bool n_AllowResumeExceptionModel, bool n_AllowTerminationExceptionModel, bool n_AllowFinallyBlocks, bool n_AllowResumeNext, bool n_AllowMixedExceptionModel, bool n_AllowAnyTypeExceptions, bool n_AllowStackVarsAsExceptions, bool n_AllowRuntimeChecksFragmentedConfiguration){
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
		p_SupportedOperators = "";
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
		p_GarbageCollector.set_Parent(this);
		p_GarbageCollector.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_GarbageCollector));
		p_GarbageCollector.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_GarbageCollector));
	}
	public XplOutputModuleCapabilities(bool n_IsCaseSensitive, bool n_AllowDefaultSafeArrays, bool n_AllowDisableArrayLimitsChecks, bool n_AllowUseSinglePointAsNamespaceSeparator, bool n_AllowUseSimpleMemberAccessAsNamespaceSeparator, bool n_AllowMultipleInheritance, bool n_UseUniversalObjectBase, bool n_AllowSetUniversalObjectBase, bool n_AllowDisableUnifiedTypeSystem, bool n_AllowEnableIntegerOverflowExceptions, bool n_AllowEnableFloatOperationsExceptions, bool n_RequireIntegerOverflowExceptions, bool n_RequireFloatOperationsExceptions, bool n_FullDecimalImplementation, bool n_SupportASCIIChar, bool n_SupportASCIIString, bool n_SupportUnsignedIntegers, bool n_SupportExtendedValueTypes, bool n_SupportExtendedReferenceTypes, bool n_SupportFunctionPointerTypes, bool n_SupportExtendedTypes, bool n_AllowSetASCIIStringClass, bool n_AllowSetStringClass, bool n_AllowDisableNullReferenceCheckOnMemberAccess, bool n_SupportPointerArithmetics, bool n_AllowSetNullIntegerValue, int n_NullIntegerValue, bool n_AllowDisableBaseTypesArrayItemsInitialization, bool n_AllowDisableStaticsVarsInitialization, bool n_AllowDisableInstanceVarsInitialization, bool n_AllowIgnorePreviousAssingmentRules, bool n_AllowDisableAddressOfExpressionRequirementOnOutArguments, bool n_AllowFinalizeMethod, bool n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody, bool n_AllowSelectiveVirtualMembers, bool n_AllowNonLimitedGotos, bool n_AllowSetRuntimeTypeInformation, bool n_AllowSetRuntimeReflection, bool n_AllowLimitRuntimeReflectionToModuleOnly, bool n_AllowResumeExceptionModel, bool n_AllowTerminationExceptionModel, bool n_AllowFinallyBlocks, bool n_AllowResumeNext, bool n_AllowMixedExceptionModel, bool n_AllowAnyTypeExceptions, bool n_AllowStackVarsAsExceptions, bool n_AllowRuntimeChecksFragmentedConfiguration, string n_SupportedOperators){
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
		p_GarbageCollector.set_Parent(this);
		p_GarbageCollector.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_GarbageCollector));
		p_GarbageCollector.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_GarbageCollector));
	}
	public XplOutputModuleCapabilities(XplNodeList n_GarbageCollector){
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
		p_SupportedOperators = "";
		p_GarbageCollector = new XplNodeList();
		p_GarbageCollector.set_Parent(this);
		p_GarbageCollector.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_GarbageCollector));
		p_GarbageCollector.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_GarbageCollector));
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_GarbageCollector!=null)
		for(XplNode node = n_GarbageCollector.FirstNode(); node != null ; node = n_GarbageCollector.NextNode()){
			p_GarbageCollector.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	public XplOutputModuleCapabilities(bool n_IsCaseSensitive, bool n_AllowDefaultSafeArrays, bool n_AllowDisableArrayLimitsChecks, bool n_AllowUseSinglePointAsNamespaceSeparator, bool n_AllowUseSimpleMemberAccessAsNamespaceSeparator, bool n_AllowMultipleInheritance, bool n_UseUniversalObjectBase, bool n_AllowSetUniversalObjectBase, bool n_AllowDisableUnifiedTypeSystem, bool n_AllowEnableIntegerOverflowExceptions, bool n_AllowEnableFloatOperationsExceptions, bool n_RequireIntegerOverflowExceptions, bool n_RequireFloatOperationsExceptions, bool n_FullDecimalImplementation, bool n_SupportASCIIChar, bool n_SupportASCIIString, bool n_SupportUnsignedIntegers, bool n_SupportExtendedValueTypes, bool n_SupportExtendedReferenceTypes, bool n_SupportFunctionPointerTypes, bool n_SupportExtendedTypes, bool n_AllowSetASCIIStringClass, bool n_AllowSetStringClass, bool n_AllowDisableNullReferenceCheckOnMemberAccess, bool n_SupportPointerArithmetics, bool n_AllowSetNullIntegerValue, bool n_AllowDisableBaseTypesArrayItemsInitialization, bool n_AllowDisableStaticsVarsInitialization, bool n_AllowDisableInstanceVarsInitialization, bool n_AllowIgnorePreviousAssingmentRules, bool n_AllowDisableAddressOfExpressionRequirementOnOutArguments, bool n_AllowFinalizeMethod, bool n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody, bool n_AllowSelectiveVirtualMembers, bool n_AllowNonLimitedGotos, bool n_AllowSetRuntimeTypeInformation, bool n_AllowSetRuntimeReflection, bool n_AllowLimitRuntimeReflectionToModuleOnly, bool n_AllowResumeExceptionModel, bool n_AllowTerminationExceptionModel, bool n_AllowFinallyBlocks, bool n_AllowResumeNext, bool n_AllowMixedExceptionModel, bool n_AllowAnyTypeExceptions, bool n_AllowStackVarsAsExceptions, bool n_AllowRuntimeChecksFragmentedConfiguration, XplNodeList n_GarbageCollector){
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
		p_SupportedOperators = "";
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
		p_GarbageCollector.set_Parent(this);
		p_GarbageCollector.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_GarbageCollector));
		p_GarbageCollector.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_GarbageCollector));
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_GarbageCollector!=null)
		for(XplNode node = n_GarbageCollector.FirstNode(); node != null ; node = n_GarbageCollector.NextNode()){
			p_GarbageCollector.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	public XplOutputModuleCapabilities(bool n_IsCaseSensitive, bool n_AllowDefaultSafeArrays, bool n_AllowDisableArrayLimitsChecks, bool n_AllowUseSinglePointAsNamespaceSeparator, bool n_AllowUseSimpleMemberAccessAsNamespaceSeparator, bool n_AllowMultipleInheritance, bool n_UseUniversalObjectBase, bool n_AllowSetUniversalObjectBase, bool n_AllowDisableUnifiedTypeSystem, bool n_AllowEnableIntegerOverflowExceptions, bool n_AllowEnableFloatOperationsExceptions, bool n_RequireIntegerOverflowExceptions, bool n_RequireFloatOperationsExceptions, bool n_FullDecimalImplementation, bool n_SupportASCIIChar, bool n_SupportASCIIString, bool n_SupportUnsignedIntegers, bool n_SupportExtendedValueTypes, bool n_SupportExtendedReferenceTypes, bool n_SupportFunctionPointerTypes, bool n_SupportExtendedTypes, bool n_AllowSetASCIIStringClass, bool n_AllowSetStringClass, bool n_AllowDisableNullReferenceCheckOnMemberAccess, bool n_SupportPointerArithmetics, bool n_AllowSetNullIntegerValue, int n_NullIntegerValue, bool n_AllowDisableBaseTypesArrayItemsInitialization, bool n_AllowDisableStaticsVarsInitialization, bool n_AllowDisableInstanceVarsInitialization, bool n_AllowIgnorePreviousAssingmentRules, bool n_AllowDisableAddressOfExpressionRequirementOnOutArguments, bool n_AllowFinalizeMethod, bool n_AllowNonNormalVirtualFunctionCallsOnConstructorsBody, bool n_AllowSelectiveVirtualMembers, bool n_AllowNonLimitedGotos, bool n_AllowSetRuntimeTypeInformation, bool n_AllowSetRuntimeReflection, bool n_AllowLimitRuntimeReflectionToModuleOnly, bool n_AllowResumeExceptionModel, bool n_AllowTerminationExceptionModel, bool n_AllowFinallyBlocks, bool n_AllowResumeNext, bool n_AllowMixedExceptionModel, bool n_AllowAnyTypeExceptions, bool n_AllowStackVarsAsExceptions, bool n_AllowRuntimeChecksFragmentedConfiguration, string n_SupportedOperators, XplNodeList n_GarbageCollector){
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
		p_GarbageCollector.set_Parent(this);
		p_GarbageCollector.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_GarbageCollector));
		p_GarbageCollector.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_GarbageCollector));
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_GarbageCollector!=null)
		for(XplNode node = n_GarbageCollector.FirstNode(); node != null ; node = n_GarbageCollector.NextNode()){
			p_GarbageCollector.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	#endregion

	#region Destructor
/*	public ~XplOutputModuleCapabilities(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplOutputModuleCapabilities copy = new XplOutputModuleCapabilities();
		copy.set_IsCaseSensitive(this.p_IsCaseSensitive);
		copy.set_AllowDefaultSafeArrays(this.p_AllowDefaultSafeArrays);
		copy.set_AllowDisableArrayLimitsChecks(this.p_AllowDisableArrayLimitsChecks);
		copy.set_AllowUseSinglePointAsNamespaceSeparator(this.p_AllowUseSinglePointAsNamespaceSeparator);
		copy.set_AllowUseSimpleMemberAccessAsNamespaceSeparator(this.p_AllowUseSimpleMemberAccessAsNamespaceSeparator);
		copy.set_AllowMultipleInheritance(this.p_AllowMultipleInheritance);
		copy.set_UseUniversalObjectBase(this.p_UseUniversalObjectBase);
		copy.set_AllowSetUniversalObjectBase(this.p_AllowSetUniversalObjectBase);
		copy.set_AllowDisableUnifiedTypeSystem(this.p_AllowDisableUnifiedTypeSystem);
		copy.set_AllowEnableIntegerOverflowExceptions(this.p_AllowEnableIntegerOverflowExceptions);
		copy.set_AllowEnableFloatOperationsExceptions(this.p_AllowEnableFloatOperationsExceptions);
		copy.set_RequireIntegerOverflowExceptions(this.p_RequireIntegerOverflowExceptions);
		copy.set_RequireFloatOperationsExceptions(this.p_RequireFloatOperationsExceptions);
		copy.set_FullDecimalImplementation(this.p_FullDecimalImplementation);
		copy.set_SupportASCIIChar(this.p_SupportASCIIChar);
		copy.set_SupportASCIIString(this.p_SupportASCIIString);
		copy.set_SupportUnsignedIntegers(this.p_SupportUnsignedIntegers);
		copy.set_SupportExtendedValueTypes(this.p_SupportExtendedValueTypes);
		copy.set_SupportExtendedReferenceTypes(this.p_SupportExtendedReferenceTypes);
		copy.set_SupportFunctionPointerTypes(this.p_SupportFunctionPointerTypes);
		copy.set_SupportExtendedTypes(this.p_SupportExtendedTypes);
		copy.set_AllowSetASCIIStringClass(this.p_AllowSetASCIIStringClass);
		copy.set_AllowSetStringClass(this.p_AllowSetStringClass);
		copy.set_AllowDisableNullReferenceCheckOnMemberAccess(this.p_AllowDisableNullReferenceCheckOnMemberAccess);
		copy.set_SupportPointerArithmetics(this.p_SupportPointerArithmetics);
		copy.set_AllowSetNullIntegerValue(this.p_AllowSetNullIntegerValue);
		copy.set_NullIntegerValue(this.p_NullIntegerValue);
		copy.set_AllowDisableBaseTypesArrayItemsInitialization(this.p_AllowDisableBaseTypesArrayItemsInitialization);
		copy.set_AllowDisableStaticsVarsInitialization(this.p_AllowDisableStaticsVarsInitialization);
		copy.set_AllowDisableInstanceVarsInitialization(this.p_AllowDisableInstanceVarsInitialization);
		copy.set_AllowIgnorePreviousAssingmentRules(this.p_AllowIgnorePreviousAssingmentRules);
		copy.set_AllowDisableAddressOfExpressionRequirementOnOutArguments(this.p_AllowDisableAddressOfExpressionRequirementOnOutArguments);
		copy.set_AllowFinalizeMethod(this.p_AllowFinalizeMethod);
		copy.set_AllowNonNormalVirtualFunctionCallsOnConstructorsBody(this.p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody);
		copy.set_AllowSelectiveVirtualMembers(this.p_AllowSelectiveVirtualMembers);
		copy.set_AllowNonLimitedGotos(this.p_AllowNonLimitedGotos);
		copy.set_AllowSetRuntimeTypeInformation(this.p_AllowSetRuntimeTypeInformation);
		copy.set_AllowSetRuntimeReflection(this.p_AllowSetRuntimeReflection);
		copy.set_AllowLimitRuntimeReflectionToModuleOnly(this.p_AllowLimitRuntimeReflectionToModuleOnly);
		copy.set_AllowResumeExceptionModel(this.p_AllowResumeExceptionModel);
		copy.set_AllowTerminationExceptionModel(this.p_AllowTerminationExceptionModel);
		copy.set_AllowFinallyBlocks(this.p_AllowFinallyBlocks);
		copy.set_AllowResumeNext(this.p_AllowResumeNext);
		copy.set_AllowMixedExceptionModel(this.p_AllowMixedExceptionModel);
		copy.set_AllowAnyTypeExceptions(this.p_AllowAnyTypeExceptions);
		copy.set_AllowStackVarsAsExceptions(this.p_AllowStackVarsAsExceptions);
		copy.set_AllowRuntimeChecksFragmentedConfiguration(this.p_AllowRuntimeChecksFragmentedConfiguration);
		copy.set_SupportedOperators(this.p_SupportedOperators);
		for(XplNode node = p_GarbageCollector.FirstNode(); node != null ; node = p_GarbageCollector.NextNode()){
			copy.get_GarbageCollector().InsertAtEnd(node.Clone());
		}
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplOutputModuleCapabilities;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_IsCaseSensitive != true)
			writer.WriteAttributeString( "IsCaseSensitive" ,ZoeHelper .Att_ToString(p_IsCaseSensitive) );
		if(p_AllowDefaultSafeArrays != false)
			writer.WriteAttributeString( "AllowDefaultSafeArrays" ,ZoeHelper .Att_ToString(p_AllowDefaultSafeArrays) );
		if(p_AllowDisableArrayLimitsChecks != false)
			writer.WriteAttributeString( "AllowDisableArrayLimitsChecks" ,ZoeHelper .Att_ToString(p_AllowDisableArrayLimitsChecks) );
		if(p_AllowUseSinglePointAsNamespaceSeparator != false)
			writer.WriteAttributeString( "AllowUseSinglePointAsNamespaceSeparator" ,ZoeHelper .Att_ToString(p_AllowUseSinglePointAsNamespaceSeparator) );
		if(p_AllowUseSimpleMemberAccessAsNamespaceSeparator != false)
			writer.WriteAttributeString( "AllowUseSimpleMemberAccessAsNamespaceSeparator" ,ZoeHelper .Att_ToString(p_AllowUseSimpleMemberAccessAsNamespaceSeparator) );
		if(p_AllowMultipleInheritance != false)
			writer.WriteAttributeString( "AllowMultipleInheritance" ,ZoeHelper .Att_ToString(p_AllowMultipleInheritance) );
		if(p_UseUniversalObjectBase != true)
			writer.WriteAttributeString( "UseUniversalObjectBase" ,ZoeHelper .Att_ToString(p_UseUniversalObjectBase) );
		if(p_AllowSetUniversalObjectBase != false)
			writer.WriteAttributeString( "AllowSetUniversalObjectBase" ,ZoeHelper .Att_ToString(p_AllowSetUniversalObjectBase) );
		if(p_AllowDisableUnifiedTypeSystem != false)
			writer.WriteAttributeString( "AllowDisableUnifiedTypeSystem" ,ZoeHelper .Att_ToString(p_AllowDisableUnifiedTypeSystem) );
		if(p_AllowEnableIntegerOverflowExceptions != false)
			writer.WriteAttributeString( "AllowEnableIntegerOverflowExceptions" ,ZoeHelper .Att_ToString(p_AllowEnableIntegerOverflowExceptions) );
		if(p_AllowEnableFloatOperationsExceptions != false)
			writer.WriteAttributeString( "AllowEnableFloatOperationsExceptions" ,ZoeHelper .Att_ToString(p_AllowEnableFloatOperationsExceptions) );
		if(p_RequireIntegerOverflowExceptions != false)
			writer.WriteAttributeString( "RequireIntegerOverflowExceptions" ,ZoeHelper .Att_ToString(p_RequireIntegerOverflowExceptions) );
		if(p_RequireFloatOperationsExceptions != false)
			writer.WriteAttributeString( "RequireFloatOperationsExceptions" ,ZoeHelper .Att_ToString(p_RequireFloatOperationsExceptions) );
		if(p_FullDecimalImplementation != true)
			writer.WriteAttributeString( "FullDecimalImplementation" ,ZoeHelper .Att_ToString(p_FullDecimalImplementation) );
		if(p_SupportASCIIChar != false)
			writer.WriteAttributeString( "SupportASCIIChar" ,ZoeHelper .Att_ToString(p_SupportASCIIChar) );
		if(p_SupportASCIIString != false)
			writer.WriteAttributeString( "SupportASCIIString" ,ZoeHelper .Att_ToString(p_SupportASCIIString) );
		if(p_SupportUnsignedIntegers != true)
			writer.WriteAttributeString( "SupportUnsignedIntegers" ,ZoeHelper .Att_ToString(p_SupportUnsignedIntegers) );
		if(p_SupportExtendedValueTypes != true)
			writer.WriteAttributeString( "SupportExtendedValueTypes" ,ZoeHelper .Att_ToString(p_SupportExtendedValueTypes) );
		if(p_SupportExtendedReferenceTypes != true)
			writer.WriteAttributeString( "SupportExtendedReferenceTypes" ,ZoeHelper .Att_ToString(p_SupportExtendedReferenceTypes) );
		if(p_SupportFunctionPointerTypes != true)
			writer.WriteAttributeString( "SupportFunctionPointerTypes" ,ZoeHelper .Att_ToString(p_SupportFunctionPointerTypes) );
		if(p_SupportExtendedTypes != true)
			writer.WriteAttributeString( "SupportExtendedTypes" ,ZoeHelper .Att_ToString(p_SupportExtendedTypes) );
		if(p_AllowSetASCIIStringClass != false)
			writer.WriteAttributeString( "AllowSetASCIIStringClass" ,ZoeHelper .Att_ToString(p_AllowSetASCIIStringClass) );
		if(p_AllowSetStringClass != false)
			writer.WriteAttributeString( "AllowSetStringClass" ,ZoeHelper .Att_ToString(p_AllowSetStringClass) );
		if(p_AllowDisableNullReferenceCheckOnMemberAccess != false)
			writer.WriteAttributeString( "AllowDisableNullReferenceCheckOnMemberAccess" ,ZoeHelper .Att_ToString(p_AllowDisableNullReferenceCheckOnMemberAccess) );
		if(p_SupportPointerArithmetics != false)
			writer.WriteAttributeString( "SupportPointerArithmetics" ,ZoeHelper .Att_ToString(p_SupportPointerArithmetics) );
		if(p_AllowSetNullIntegerValue != false)
			writer.WriteAttributeString( "AllowSetNullIntegerValue" ,ZoeHelper .Att_ToString(p_AllowSetNullIntegerValue) );
		if(p_NullIntegerValue != 0)
			writer.WriteAttributeString( "NullIntegerValue" ,ZoeHelper .Att_ToString(p_NullIntegerValue) );
		if(p_AllowDisableBaseTypesArrayItemsInitialization != false)
			writer.WriteAttributeString( "AllowDisableBaseTypesArrayItemsInitialization" ,ZoeHelper .Att_ToString(p_AllowDisableBaseTypesArrayItemsInitialization) );
		if(p_AllowDisableStaticsVarsInitialization != false)
			writer.WriteAttributeString( "AllowDisableStaticsVarsInitialization" ,ZoeHelper .Att_ToString(p_AllowDisableStaticsVarsInitialization) );
		if(p_AllowDisableInstanceVarsInitialization != false)
			writer.WriteAttributeString( "AllowDisableInstanceVarsInitialization" ,ZoeHelper .Att_ToString(p_AllowDisableInstanceVarsInitialization) );
		if(p_AllowIgnorePreviousAssingmentRules != true)
			writer.WriteAttributeString( "AllowIgnorePreviousAssingmentRules" ,ZoeHelper .Att_ToString(p_AllowIgnorePreviousAssingmentRules) );
		if(p_AllowDisableAddressOfExpressionRequirementOnOutArguments != false)
			writer.WriteAttributeString( "AllowDisableAddressOfExpressionRequirementOnOutArguments" ,ZoeHelper .Att_ToString(p_AllowDisableAddressOfExpressionRequirementOnOutArguments) );
		if(p_AllowFinalizeMethod != true)
			writer.WriteAttributeString( "AllowFinalizeMethod" ,ZoeHelper .Att_ToString(p_AllowFinalizeMethod) );
		if(p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody != false)
			writer.WriteAttributeString( "AllowNonNormalVirtualFunctionCallsOnConstructorsBody" ,ZoeHelper .Att_ToString(p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody) );
		if(p_AllowSelectiveVirtualMembers != true)
			writer.WriteAttributeString( "AllowSelectiveVirtualMembers" ,ZoeHelper .Att_ToString(p_AllowSelectiveVirtualMembers) );
		if(p_AllowNonLimitedGotos != false)
			writer.WriteAttributeString( "AllowNonLimitedGotos" ,ZoeHelper .Att_ToString(p_AllowNonLimitedGotos) );
		if(p_AllowSetRuntimeTypeInformation != true)
			writer.WriteAttributeString( "AllowSetRuntimeTypeInformation" ,ZoeHelper .Att_ToString(p_AllowSetRuntimeTypeInformation) );
		if(p_AllowSetRuntimeReflection != false)
			writer.WriteAttributeString( "AllowSetRuntimeReflection" ,ZoeHelper .Att_ToString(p_AllowSetRuntimeReflection) );
		if(p_AllowLimitRuntimeReflectionToModuleOnly != false)
			writer.WriteAttributeString( "AllowLimitRuntimeReflectionToModuleOnly" ,ZoeHelper .Att_ToString(p_AllowLimitRuntimeReflectionToModuleOnly) );
		if(p_AllowResumeExceptionModel != false)
			writer.WriteAttributeString( "AllowResumeExceptionModel" ,ZoeHelper .Att_ToString(p_AllowResumeExceptionModel) );
		if(p_AllowTerminationExceptionModel != true)
			writer.WriteAttributeString( "AllowTerminationExceptionModel" ,ZoeHelper .Att_ToString(p_AllowTerminationExceptionModel) );
		if(p_AllowFinallyBlocks != true)
			writer.WriteAttributeString( "AllowFinallyBlocks" ,ZoeHelper .Att_ToString(p_AllowFinallyBlocks) );
		if(p_AllowResumeNext != true)
			writer.WriteAttributeString( "AllowResumeNext" ,ZoeHelper .Att_ToString(p_AllowResumeNext) );
		if(p_AllowMixedExceptionModel != false)
			writer.WriteAttributeString( "AllowMixedExceptionModel" ,ZoeHelper .Att_ToString(p_AllowMixedExceptionModel) );
		if(p_AllowAnyTypeExceptions != false)
			writer.WriteAttributeString( "AllowAnyTypeExceptions" ,ZoeHelper .Att_ToString(p_AllowAnyTypeExceptions) );
		if(p_AllowStackVarsAsExceptions != true)
			writer.WriteAttributeString( "AllowStackVarsAsExceptions" ,ZoeHelper .Att_ToString(p_AllowStackVarsAsExceptions) );
		if(p_AllowRuntimeChecksFragmentedConfiguration != false)
			writer.WriteAttributeString( "AllowRuntimeChecksFragmentedConfiguration" ,ZoeHelper .Att_ToString(p_AllowRuntimeChecksFragmentedConfiguration) );
		if(p_SupportedOperators != "")
			writer.WriteAttributeString( "SupportedOperators" ,ZoeHelper .Att_ToString(p_SupportedOperators) );
		//Escribo recursivamente cada elemento hijo
		if(p_GarbageCollector!=null)if(!p_GarbageCollector.Write(writer))result=false;
		//Cierro el elemento
		writer.WriteEndElement();
		return result;
	}

	public override XplNode Read(XplReader reader){
		this.set_ElementName( reader.Name );
		//Lectura de Atributos
		if( reader.HasAttributes ){
			for(int i=0; i < reader.AttributeCount ; i++){
				reader.MoveToAttribute(i);
				switch(reader.Name){
					case "IsCaseSensitive":
						this.set_IsCaseSensitive(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowDefaultSafeArrays":
						this.set_AllowDefaultSafeArrays(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowDisableArrayLimitsChecks":
						this.set_AllowDisableArrayLimitsChecks(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowUseSinglePointAsNamespaceSeparator":
						this.set_AllowUseSinglePointAsNamespaceSeparator(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowUseSimpleMemberAccessAsNamespaceSeparator":
						this.set_AllowUseSimpleMemberAccessAsNamespaceSeparator(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowMultipleInheritance":
						this.set_AllowMultipleInheritance(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "UseUniversalObjectBase":
						this.set_UseUniversalObjectBase(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowSetUniversalObjectBase":
						this.set_AllowSetUniversalObjectBase(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowDisableUnifiedTypeSystem":
						this.set_AllowDisableUnifiedTypeSystem(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowEnableIntegerOverflowExceptions":
						this.set_AllowEnableIntegerOverflowExceptions(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowEnableFloatOperationsExceptions":
						this.set_AllowEnableFloatOperationsExceptions(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "RequireIntegerOverflowExceptions":
						this.set_RequireIntegerOverflowExceptions(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "RequireFloatOperationsExceptions":
						this.set_RequireFloatOperationsExceptions(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "FullDecimalImplementation":
						this.set_FullDecimalImplementation(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "SupportASCIIChar":
						this.set_SupportASCIIChar(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "SupportASCIIString":
						this.set_SupportASCIIString(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "SupportUnsignedIntegers":
						this.set_SupportUnsignedIntegers(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "SupportExtendedValueTypes":
						this.set_SupportExtendedValueTypes(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "SupportExtendedReferenceTypes":
						this.set_SupportExtendedReferenceTypes(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "SupportFunctionPointerTypes":
						this.set_SupportFunctionPointerTypes(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "SupportExtendedTypes":
						this.set_SupportExtendedTypes(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowSetASCIIStringClass":
						this.set_AllowSetASCIIStringClass(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowSetStringClass":
						this.set_AllowSetStringClass(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowDisableNullReferenceCheckOnMemberAccess":
						this.set_AllowDisableNullReferenceCheckOnMemberAccess(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "SupportPointerArithmetics":
						this.set_SupportPointerArithmetics(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowSetNullIntegerValue":
						this.set_AllowSetNullIntegerValue(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "NullIntegerValue":
						this.set_NullIntegerValue(ZoeHelper .StringAtt_To_INT(reader.Value));
						break;
					case "AllowDisableBaseTypesArrayItemsInitialization":
						this.set_AllowDisableBaseTypesArrayItemsInitialization(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowDisableStaticsVarsInitialization":
						this.set_AllowDisableStaticsVarsInitialization(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowDisableInstanceVarsInitialization":
						this.set_AllowDisableInstanceVarsInitialization(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowIgnorePreviousAssingmentRules":
						this.set_AllowIgnorePreviousAssingmentRules(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowDisableAddressOfExpressionRequirementOnOutArguments":
						this.set_AllowDisableAddressOfExpressionRequirementOnOutArguments(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowFinalizeMethod":
						this.set_AllowFinalizeMethod(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowNonNormalVirtualFunctionCallsOnConstructorsBody":
						this.set_AllowNonNormalVirtualFunctionCallsOnConstructorsBody(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowSelectiveVirtualMembers":
						this.set_AllowSelectiveVirtualMembers(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowNonLimitedGotos":
						this.set_AllowNonLimitedGotos(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowSetRuntimeTypeInformation":
						this.set_AllowSetRuntimeTypeInformation(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowSetRuntimeReflection":
						this.set_AllowSetRuntimeReflection(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowLimitRuntimeReflectionToModuleOnly":
						this.set_AllowLimitRuntimeReflectionToModuleOnly(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowResumeExceptionModel":
						this.set_AllowResumeExceptionModel(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowTerminationExceptionModel":
						this.set_AllowTerminationExceptionModel(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowFinallyBlocks":
						this.set_AllowFinallyBlocks(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowResumeNext":
						this.set_AllowResumeNext(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowMixedExceptionModel":
						this.set_AllowMixedExceptionModel(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowAnyTypeExceptions":
						this.set_AllowAnyTypeExceptions(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowStackVarsAsExceptions":
						this.set_AllowStackVarsAsExceptions(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "AllowRuntimeChecksFragmentedConfiguration":
						this.set_AllowRuntimeChecksFragmentedConfiguration(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "SupportedOperators":
						this.set_SupportedOperators(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Atributo '"+reader.Name+"' invalido en elemento '"+this.get_ElementName()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		//Borro todo posible nodo en memoria
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "GarbageCollector":
						tempNode = new XplGarbageCollector();
						tempNode.Read(reader);
						this.get_GarbageCollector().InsertAtEnd(tempNode);
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nombre de nodo '"+reader.Name+"' inesperado como hijo de elemento '"+this.get_ElementName()+"'.");
					}
					break;
				case XmlNodeType.EndElement:
					break;
				case XmlNodeType.Text:
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".No se esperaba texto en este nodo.");
				default:
					break;
			}
			reader.Read();
		}
		}
		return this;
	}
	public override bool BinaryWrite(XplBinaryWriter writer){
		bool result=true;
		//Escribo el ID y el nombre del elemento
		writer.Write((int) 107 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_IsCaseSensitive );
		writer.Write( p_AllowDefaultSafeArrays );
		writer.Write( p_AllowDisableArrayLimitsChecks );
		writer.Write( p_AllowUseSinglePointAsNamespaceSeparator );
		writer.Write( p_AllowUseSimpleMemberAccessAsNamespaceSeparator );
		writer.Write( p_AllowMultipleInheritance );
		writer.Write( p_UseUniversalObjectBase );
		writer.Write( p_AllowSetUniversalObjectBase );
		writer.Write( p_AllowDisableUnifiedTypeSystem );
		writer.Write( p_AllowEnableIntegerOverflowExceptions );
		writer.Write( p_AllowEnableFloatOperationsExceptions );
		writer.Write( p_RequireIntegerOverflowExceptions );
		writer.Write( p_RequireFloatOperationsExceptions );
		writer.Write( p_FullDecimalImplementation );
		writer.Write( p_SupportASCIIChar );
		writer.Write( p_SupportASCIIString );
		writer.Write( p_SupportUnsignedIntegers );
		writer.Write( p_SupportExtendedValueTypes );
		writer.Write( p_SupportExtendedReferenceTypes );
		writer.Write( p_SupportFunctionPointerTypes );
		writer.Write( p_SupportExtendedTypes );
		writer.Write( p_AllowSetASCIIStringClass );
		writer.Write( p_AllowSetStringClass );
		writer.Write( p_AllowDisableNullReferenceCheckOnMemberAccess );
		writer.Write( p_SupportPointerArithmetics );
		writer.Write( p_AllowSetNullIntegerValue );
		writer.Write( p_NullIntegerValue );
		writer.Write( p_AllowDisableBaseTypesArrayItemsInitialization );
		writer.Write( p_AllowDisableStaticsVarsInitialization );
		writer.Write( p_AllowDisableInstanceVarsInitialization );
		writer.Write( p_AllowIgnorePreviousAssingmentRules );
		writer.Write( p_AllowDisableAddressOfExpressionRequirementOnOutArguments );
		writer.Write( p_AllowFinalizeMethod );
		writer.Write( p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody );
		writer.Write( p_AllowSelectiveVirtualMembers );
		writer.Write( p_AllowNonLimitedGotos );
		writer.Write( p_AllowSetRuntimeTypeInformation );
		writer.Write( p_AllowSetRuntimeReflection );
		writer.Write( p_AllowLimitRuntimeReflectionToModuleOnly );
		writer.Write( p_AllowResumeExceptionModel );
		writer.Write( p_AllowTerminationExceptionModel );
		writer.Write( p_AllowFinallyBlocks );
		writer.Write( p_AllowResumeNext );
		writer.Write( p_AllowMixedExceptionModel );
		writer.Write( p_AllowAnyTypeExceptions );
		writer.Write( p_AllowStackVarsAsExceptions );
		writer.Write( p_AllowRuntimeChecksFragmentedConfiguration );
		writer.Write( p_SupportedOperators );
		//Escribo recursivamente cada elemento hijo
		if(p_GarbageCollector!=null){
			writer.Write((int)1);
			if(!p_GarbageCollector.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_IsCaseSensitive = reader.ReadBoolean();
		p_AllowDefaultSafeArrays = reader.ReadBoolean();
		p_AllowDisableArrayLimitsChecks = reader.ReadBoolean();
		p_AllowUseSinglePointAsNamespaceSeparator = reader.ReadBoolean();
		p_AllowUseSimpleMemberAccessAsNamespaceSeparator = reader.ReadBoolean();
		p_AllowMultipleInheritance = reader.ReadBoolean();
		p_UseUniversalObjectBase = reader.ReadBoolean();
		p_AllowSetUniversalObjectBase = reader.ReadBoolean();
		p_AllowDisableUnifiedTypeSystem = reader.ReadBoolean();
		p_AllowEnableIntegerOverflowExceptions = reader.ReadBoolean();
		p_AllowEnableFloatOperationsExceptions = reader.ReadBoolean();
		p_RequireIntegerOverflowExceptions = reader.ReadBoolean();
		p_RequireFloatOperationsExceptions = reader.ReadBoolean();
		p_FullDecimalImplementation = reader.ReadBoolean();
		p_SupportASCIIChar = reader.ReadBoolean();
		p_SupportASCIIString = reader.ReadBoolean();
		p_SupportUnsignedIntegers = reader.ReadBoolean();
		p_SupportExtendedValueTypes = reader.ReadBoolean();
		p_SupportExtendedReferenceTypes = reader.ReadBoolean();
		p_SupportFunctionPointerTypes = reader.ReadBoolean();
		p_SupportExtendedTypes = reader.ReadBoolean();
		p_AllowSetASCIIStringClass = reader.ReadBoolean();
		p_AllowSetStringClass = reader.ReadBoolean();
		p_AllowDisableNullReferenceCheckOnMemberAccess = reader.ReadBoolean();
		p_SupportPointerArithmetics = reader.ReadBoolean();
		p_AllowSetNullIntegerValue = reader.ReadBoolean();
		p_NullIntegerValue = reader.ReadInt32();
		p_AllowDisableBaseTypesArrayItemsInitialization = reader.ReadBoolean();
		p_AllowDisableStaticsVarsInitialization = reader.ReadBoolean();
		p_AllowDisableInstanceVarsInitialization = reader.ReadBoolean();
		p_AllowIgnorePreviousAssingmentRules = reader.ReadBoolean();
		p_AllowDisableAddressOfExpressionRequirementOnOutArguments = reader.ReadBoolean();
		p_AllowFinalizeMethod = reader.ReadBoolean();
		p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody = reader.ReadBoolean();
		p_AllowSelectiveVirtualMembers = reader.ReadBoolean();
		p_AllowNonLimitedGotos = reader.ReadBoolean();
		p_AllowSetRuntimeTypeInformation = reader.ReadBoolean();
		p_AllowSetRuntimeReflection = reader.ReadBoolean();
		p_AllowLimitRuntimeReflectionToModuleOnly = reader.ReadBoolean();
		p_AllowResumeExceptionModel = reader.ReadBoolean();
		p_AllowTerminationExceptionModel = reader.ReadBoolean();
		p_AllowFinallyBlocks = reader.ReadBoolean();
		p_AllowResumeNext = reader.ReadBoolean();
		p_AllowMixedExceptionModel = reader.ReadBoolean();
		p_AllowAnyTypeExceptions = reader.ReadBoolean();
		p_AllowStackVarsAsExceptions = reader.ReadBoolean();
		p_AllowRuntimeChecksFragmentedConfiguration = reader.ReadBoolean();
		p_SupportedOperators = reader.ReadString();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_GarbageCollector.BinaryRead(reader);
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplOutputModuleCapabilities operator +(XplOutputModuleCapabilities arg1, XplNode arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
/// <summary>
/// Adds arg2 nodes to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Nodes to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplOutputModuleCapabilities operator +(XplOutputModuleCapabilities arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public bool get_IsCaseSensitive(){
		return p_IsCaseSensitive;
	}
	public bool get_AllowDefaultSafeArrays(){
		return p_AllowDefaultSafeArrays;
	}
	public bool get_AllowDisableArrayLimitsChecks(){
		return p_AllowDisableArrayLimitsChecks;
	}
	public bool get_AllowUseSinglePointAsNamespaceSeparator(){
		return p_AllowUseSinglePointAsNamespaceSeparator;
	}
	public bool get_AllowUseSimpleMemberAccessAsNamespaceSeparator(){
		return p_AllowUseSimpleMemberAccessAsNamespaceSeparator;
	}
	public bool get_AllowMultipleInheritance(){
		return p_AllowMultipleInheritance;
	}
	public bool get_UseUniversalObjectBase(){
		return p_UseUniversalObjectBase;
	}
	public bool get_AllowSetUniversalObjectBase(){
		return p_AllowSetUniversalObjectBase;
	}
	public bool get_AllowDisableUnifiedTypeSystem(){
		return p_AllowDisableUnifiedTypeSystem;
	}
	public bool get_AllowEnableIntegerOverflowExceptions(){
		return p_AllowEnableIntegerOverflowExceptions;
	}
	public bool get_AllowEnableFloatOperationsExceptions(){
		return p_AllowEnableFloatOperationsExceptions;
	}
	public bool get_RequireIntegerOverflowExceptions(){
		return p_RequireIntegerOverflowExceptions;
	}
	public bool get_RequireFloatOperationsExceptions(){
		return p_RequireFloatOperationsExceptions;
	}
	public bool get_FullDecimalImplementation(){
		return p_FullDecimalImplementation;
	}
	public bool get_SupportASCIIChar(){
		return p_SupportASCIIChar;
	}
	public bool get_SupportASCIIString(){
		return p_SupportASCIIString;
	}
	public bool get_SupportUnsignedIntegers(){
		return p_SupportUnsignedIntegers;
	}
	public bool get_SupportExtendedValueTypes(){
		return p_SupportExtendedValueTypes;
	}
	public bool get_SupportExtendedReferenceTypes(){
		return p_SupportExtendedReferenceTypes;
	}
	public bool get_SupportFunctionPointerTypes(){
		return p_SupportFunctionPointerTypes;
	}
	public bool get_SupportExtendedTypes(){
		return p_SupportExtendedTypes;
	}
	public bool get_AllowSetASCIIStringClass(){
		return p_AllowSetASCIIStringClass;
	}
	public bool get_AllowSetStringClass(){
		return p_AllowSetStringClass;
	}
	public bool get_AllowDisableNullReferenceCheckOnMemberAccess(){
		return p_AllowDisableNullReferenceCheckOnMemberAccess;
	}
	public bool get_SupportPointerArithmetics(){
		return p_SupportPointerArithmetics;
	}
	public bool get_AllowSetNullIntegerValue(){
		return p_AllowSetNullIntegerValue;
	}
	public int get_NullIntegerValue(){
		return p_NullIntegerValue;
	}
	public bool get_AllowDisableBaseTypesArrayItemsInitialization(){
		return p_AllowDisableBaseTypesArrayItemsInitialization;
	}
	public bool get_AllowDisableStaticsVarsInitialization(){
		return p_AllowDisableStaticsVarsInitialization;
	}
	public bool get_AllowDisableInstanceVarsInitialization(){
		return p_AllowDisableInstanceVarsInitialization;
	}
	public bool get_AllowIgnorePreviousAssingmentRules(){
		return p_AllowIgnorePreviousAssingmentRules;
	}
	public bool get_AllowDisableAddressOfExpressionRequirementOnOutArguments(){
		return p_AllowDisableAddressOfExpressionRequirementOnOutArguments;
	}
	public bool get_AllowFinalizeMethod(){
		return p_AllowFinalizeMethod;
	}
	public bool get_AllowNonNormalVirtualFunctionCallsOnConstructorsBody(){
		return p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody;
	}
	public bool get_AllowSelectiveVirtualMembers(){
		return p_AllowSelectiveVirtualMembers;
	}
	public bool get_AllowNonLimitedGotos(){
		return p_AllowNonLimitedGotos;
	}
	public bool get_AllowSetRuntimeTypeInformation(){
		return p_AllowSetRuntimeTypeInformation;
	}
	public bool get_AllowSetRuntimeReflection(){
		return p_AllowSetRuntimeReflection;
	}
	public bool get_AllowLimitRuntimeReflectionToModuleOnly(){
		return p_AllowLimitRuntimeReflectionToModuleOnly;
	}
	public bool get_AllowResumeExceptionModel(){
		return p_AllowResumeExceptionModel;
	}
	public bool get_AllowTerminationExceptionModel(){
		return p_AllowTerminationExceptionModel;
	}
	public bool get_AllowFinallyBlocks(){
		return p_AllowFinallyBlocks;
	}
	public bool get_AllowResumeNext(){
		return p_AllowResumeNext;
	}
	public bool get_AllowMixedExceptionModel(){
		return p_AllowMixedExceptionModel;
	}
	public bool get_AllowAnyTypeExceptions(){
		return p_AllowAnyTypeExceptions;
	}
	public bool get_AllowStackVarsAsExceptions(){
		return p_AllowStackVarsAsExceptions;
	}
	public bool get_AllowRuntimeChecksFragmentedConfiguration(){
		return p_AllowRuntimeChecksFragmentedConfiguration;
	}
	public string get_SupportedOperators(){
		return p_SupportedOperators;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplNodeList get_GarbageCollector(){
		return p_GarbageCollector;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[48];
		ret[0] = "IsCaseSensitive";
		ret[1] = "AllowDefaultSafeArrays";
		ret[2] = "AllowDisableArrayLimitsChecks";
		ret[3] = "AllowUseSinglePointAsNamespaceSeparator";
		ret[4] = "AllowUseSimpleMemberAccessAsNamespaceSeparator";
		ret[5] = "AllowMultipleInheritance";
		ret[6] = "UseUniversalObjectBase";
		ret[7] = "AllowSetUniversalObjectBase";
		ret[8] = "AllowDisableUnifiedTypeSystem";
		ret[9] = "AllowEnableIntegerOverflowExceptions";
		ret[10] = "AllowEnableFloatOperationsExceptions";
		ret[11] = "RequireIntegerOverflowExceptions";
		ret[12] = "RequireFloatOperationsExceptions";
		ret[13] = "FullDecimalImplementation";
		ret[14] = "SupportASCIIChar";
		ret[15] = "SupportASCIIString";
		ret[16] = "SupportUnsignedIntegers";
		ret[17] = "SupportExtendedValueTypes";
		ret[18] = "SupportExtendedReferenceTypes";
		ret[19] = "SupportFunctionPointerTypes";
		ret[20] = "SupportExtendedTypes";
		ret[21] = "AllowSetASCIIStringClass";
		ret[22] = "AllowSetStringClass";
		ret[23] = "AllowDisableNullReferenceCheckOnMemberAccess";
		ret[24] = "SupportPointerArithmetics";
		ret[25] = "AllowSetNullIntegerValue";
		ret[26] = "NullIntegerValue";
		ret[27] = "AllowDisableBaseTypesArrayItemsInitialization";
		ret[28] = "AllowDisableStaticsVarsInitialization";
		ret[29] = "AllowDisableInstanceVarsInitialization";
		ret[30] = "AllowIgnorePreviousAssingmentRules";
		ret[31] = "AllowDisableAddressOfExpressionRequirementOnOutArguments";
		ret[32] = "AllowFinalizeMethod";
		ret[33] = "AllowNonNormalVirtualFunctionCallsOnConstructorsBody";
		ret[34] = "AllowSelectiveVirtualMembers";
		ret[35] = "AllowNonLimitedGotos";
		ret[36] = "AllowSetRuntimeTypeInformation";
		ret[37] = "AllowSetRuntimeReflection";
		ret[38] = "AllowLimitRuntimeReflectionToModuleOnly";
		ret[39] = "AllowResumeExceptionModel";
		ret[40] = "AllowTerminationExceptionModel";
		ret[41] = "AllowFinallyBlocks";
		ret[42] = "AllowResumeNext";
		ret[43] = "AllowMixedExceptionModel";
		ret[44] = "AllowAnyTypeExceptions";
		ret[45] = "AllowStackVarsAsExceptions";
		ret[46] = "AllowRuntimeChecksFragmentedConfiguration";
		ret[47] = "SupportedOperators";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="IsCaseSensitive") return p_IsCaseSensitive.ToString();
		if (attributeName=="AllowDefaultSafeArrays") return p_AllowDefaultSafeArrays.ToString();
		if (attributeName=="AllowDisableArrayLimitsChecks") return p_AllowDisableArrayLimitsChecks.ToString();
		if (attributeName=="AllowUseSinglePointAsNamespaceSeparator") return p_AllowUseSinglePointAsNamespaceSeparator.ToString();
		if (attributeName=="AllowUseSimpleMemberAccessAsNamespaceSeparator") return p_AllowUseSimpleMemberAccessAsNamespaceSeparator.ToString();
		if (attributeName=="AllowMultipleInheritance") return p_AllowMultipleInheritance.ToString();
		if (attributeName=="UseUniversalObjectBase") return p_UseUniversalObjectBase.ToString();
		if (attributeName=="AllowSetUniversalObjectBase") return p_AllowSetUniversalObjectBase.ToString();
		if (attributeName=="AllowDisableUnifiedTypeSystem") return p_AllowDisableUnifiedTypeSystem.ToString();
		if (attributeName=="AllowEnableIntegerOverflowExceptions") return p_AllowEnableIntegerOverflowExceptions.ToString();
		if (attributeName=="AllowEnableFloatOperationsExceptions") return p_AllowEnableFloatOperationsExceptions.ToString();
		if (attributeName=="RequireIntegerOverflowExceptions") return p_RequireIntegerOverflowExceptions.ToString();
		if (attributeName=="RequireFloatOperationsExceptions") return p_RequireFloatOperationsExceptions.ToString();
		if (attributeName=="FullDecimalImplementation") return p_FullDecimalImplementation.ToString();
		if (attributeName=="SupportASCIIChar") return p_SupportASCIIChar.ToString();
		if (attributeName=="SupportASCIIString") return p_SupportASCIIString.ToString();
		if (attributeName=="SupportUnsignedIntegers") return p_SupportUnsignedIntegers.ToString();
		if (attributeName=="SupportExtendedValueTypes") return p_SupportExtendedValueTypes.ToString();
		if (attributeName=="SupportExtendedReferenceTypes") return p_SupportExtendedReferenceTypes.ToString();
		if (attributeName=="SupportFunctionPointerTypes") return p_SupportFunctionPointerTypes.ToString();
		if (attributeName=="SupportExtendedTypes") return p_SupportExtendedTypes.ToString();
		if (attributeName=="AllowSetASCIIStringClass") return p_AllowSetASCIIStringClass.ToString();
		if (attributeName=="AllowSetStringClass") return p_AllowSetStringClass.ToString();
		if (attributeName=="AllowDisableNullReferenceCheckOnMemberAccess") return p_AllowDisableNullReferenceCheckOnMemberAccess.ToString();
		if (attributeName=="SupportPointerArithmetics") return p_SupportPointerArithmetics.ToString();
		if (attributeName=="AllowSetNullIntegerValue") return p_AllowSetNullIntegerValue.ToString();
		if (attributeName=="NullIntegerValue") return p_NullIntegerValue.ToString();
		if (attributeName=="AllowDisableBaseTypesArrayItemsInitialization") return p_AllowDisableBaseTypesArrayItemsInitialization.ToString();
		if (attributeName=="AllowDisableStaticsVarsInitialization") return p_AllowDisableStaticsVarsInitialization.ToString();
		if (attributeName=="AllowDisableInstanceVarsInitialization") return p_AllowDisableInstanceVarsInitialization.ToString();
		if (attributeName=="AllowIgnorePreviousAssingmentRules") return p_AllowIgnorePreviousAssingmentRules.ToString();
		if (attributeName=="AllowDisableAddressOfExpressionRequirementOnOutArguments") return p_AllowDisableAddressOfExpressionRequirementOnOutArguments.ToString();
		if (attributeName=="AllowFinalizeMethod") return p_AllowFinalizeMethod.ToString();
		if (attributeName=="AllowNonNormalVirtualFunctionCallsOnConstructorsBody") return p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody.ToString();
		if (attributeName=="AllowSelectiveVirtualMembers") return p_AllowSelectiveVirtualMembers.ToString();
		if (attributeName=="AllowNonLimitedGotos") return p_AllowNonLimitedGotos.ToString();
		if (attributeName=="AllowSetRuntimeTypeInformation") return p_AllowSetRuntimeTypeInformation.ToString();
		if (attributeName=="AllowSetRuntimeReflection") return p_AllowSetRuntimeReflection.ToString();
		if (attributeName=="AllowLimitRuntimeReflectionToModuleOnly") return p_AllowLimitRuntimeReflectionToModuleOnly.ToString();
		if (attributeName=="AllowResumeExceptionModel") return p_AllowResumeExceptionModel.ToString();
		if (attributeName=="AllowTerminationExceptionModel") return p_AllowTerminationExceptionModel.ToString();
		if (attributeName=="AllowFinallyBlocks") return p_AllowFinallyBlocks.ToString();
		if (attributeName=="AllowResumeNext") return p_AllowResumeNext.ToString();
		if (attributeName=="AllowMixedExceptionModel") return p_AllowMixedExceptionModel.ToString();
		if (attributeName=="AllowAnyTypeExceptions") return p_AllowAnyTypeExceptions.ToString();
		if (attributeName=="AllowStackVarsAsExceptions") return p_AllowStackVarsAsExceptions.ToString();
		if (attributeName=="AllowRuntimeChecksFragmentedConfiguration") return p_AllowRuntimeChecksFragmentedConfiguration.ToString();
		if (attributeName=="SupportedOperators") return p_SupportedOperators.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		for(XplNode node=p_GarbageCollector.FirstNode();node!=null;node=p_GarbageCollector.NextNode())
			list.InsertAtEnd(node);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public bool set_IsCaseSensitive(bool new_IsCaseSensitive){
		bool back_IsCaseSensitive = p_IsCaseSensitive;
		p_IsCaseSensitive = new_IsCaseSensitive;
		return back_IsCaseSensitive;
	}
	public bool set_AllowDefaultSafeArrays(bool new_AllowDefaultSafeArrays){
		bool back_AllowDefaultSafeArrays = p_AllowDefaultSafeArrays;
		p_AllowDefaultSafeArrays = new_AllowDefaultSafeArrays;
		return back_AllowDefaultSafeArrays;
	}
	public bool set_AllowDisableArrayLimitsChecks(bool new_AllowDisableArrayLimitsChecks){
		bool back_AllowDisableArrayLimitsChecks = p_AllowDisableArrayLimitsChecks;
		p_AllowDisableArrayLimitsChecks = new_AllowDisableArrayLimitsChecks;
		return back_AllowDisableArrayLimitsChecks;
	}
	public bool set_AllowUseSinglePointAsNamespaceSeparator(bool new_AllowUseSinglePointAsNamespaceSeparator){
		bool back_AllowUseSinglePointAsNamespaceSeparator = p_AllowUseSinglePointAsNamespaceSeparator;
		p_AllowUseSinglePointAsNamespaceSeparator = new_AllowUseSinglePointAsNamespaceSeparator;
		return back_AllowUseSinglePointAsNamespaceSeparator;
	}
	public bool set_AllowUseSimpleMemberAccessAsNamespaceSeparator(bool new_AllowUseSimpleMemberAccessAsNamespaceSeparator){
		bool back_AllowUseSimpleMemberAccessAsNamespaceSeparator = p_AllowUseSimpleMemberAccessAsNamespaceSeparator;
		p_AllowUseSimpleMemberAccessAsNamespaceSeparator = new_AllowUseSimpleMemberAccessAsNamespaceSeparator;
		return back_AllowUseSimpleMemberAccessAsNamespaceSeparator;
	}
	public bool set_AllowMultipleInheritance(bool new_AllowMultipleInheritance){
		bool back_AllowMultipleInheritance = p_AllowMultipleInheritance;
		p_AllowMultipleInheritance = new_AllowMultipleInheritance;
		return back_AllowMultipleInheritance;
	}
	public bool set_UseUniversalObjectBase(bool new_UseUniversalObjectBase){
		bool back_UseUniversalObjectBase = p_UseUniversalObjectBase;
		p_UseUniversalObjectBase = new_UseUniversalObjectBase;
		return back_UseUniversalObjectBase;
	}
	public bool set_AllowSetUniversalObjectBase(bool new_AllowSetUniversalObjectBase){
		bool back_AllowSetUniversalObjectBase = p_AllowSetUniversalObjectBase;
		p_AllowSetUniversalObjectBase = new_AllowSetUniversalObjectBase;
		return back_AllowSetUniversalObjectBase;
	}
	public bool set_AllowDisableUnifiedTypeSystem(bool new_AllowDisableUnifiedTypeSystem){
		bool back_AllowDisableUnifiedTypeSystem = p_AllowDisableUnifiedTypeSystem;
		p_AllowDisableUnifiedTypeSystem = new_AllowDisableUnifiedTypeSystem;
		return back_AllowDisableUnifiedTypeSystem;
	}
	public bool set_AllowEnableIntegerOverflowExceptions(bool new_AllowEnableIntegerOverflowExceptions){
		bool back_AllowEnableIntegerOverflowExceptions = p_AllowEnableIntegerOverflowExceptions;
		p_AllowEnableIntegerOverflowExceptions = new_AllowEnableIntegerOverflowExceptions;
		return back_AllowEnableIntegerOverflowExceptions;
	}
	public bool set_AllowEnableFloatOperationsExceptions(bool new_AllowEnableFloatOperationsExceptions){
		bool back_AllowEnableFloatOperationsExceptions = p_AllowEnableFloatOperationsExceptions;
		p_AllowEnableFloatOperationsExceptions = new_AllowEnableFloatOperationsExceptions;
		return back_AllowEnableFloatOperationsExceptions;
	}
	public bool set_RequireIntegerOverflowExceptions(bool new_RequireIntegerOverflowExceptions){
		bool back_RequireIntegerOverflowExceptions = p_RequireIntegerOverflowExceptions;
		p_RequireIntegerOverflowExceptions = new_RequireIntegerOverflowExceptions;
		return back_RequireIntegerOverflowExceptions;
	}
	public bool set_RequireFloatOperationsExceptions(bool new_RequireFloatOperationsExceptions){
		bool back_RequireFloatOperationsExceptions = p_RequireFloatOperationsExceptions;
		p_RequireFloatOperationsExceptions = new_RequireFloatOperationsExceptions;
		return back_RequireFloatOperationsExceptions;
	}
	public bool set_FullDecimalImplementation(bool new_FullDecimalImplementation){
		bool back_FullDecimalImplementation = p_FullDecimalImplementation;
		p_FullDecimalImplementation = new_FullDecimalImplementation;
		return back_FullDecimalImplementation;
	}
	public bool set_SupportASCIIChar(bool new_SupportASCIIChar){
		bool back_SupportASCIIChar = p_SupportASCIIChar;
		p_SupportASCIIChar = new_SupportASCIIChar;
		return back_SupportASCIIChar;
	}
	public bool set_SupportASCIIString(bool new_SupportASCIIString){
		bool back_SupportASCIIString = p_SupportASCIIString;
		p_SupportASCIIString = new_SupportASCIIString;
		return back_SupportASCIIString;
	}
	public bool set_SupportUnsignedIntegers(bool new_SupportUnsignedIntegers){
		bool back_SupportUnsignedIntegers = p_SupportUnsignedIntegers;
		p_SupportUnsignedIntegers = new_SupportUnsignedIntegers;
		return back_SupportUnsignedIntegers;
	}
	public bool set_SupportExtendedValueTypes(bool new_SupportExtendedValueTypes){
		bool back_SupportExtendedValueTypes = p_SupportExtendedValueTypes;
		p_SupportExtendedValueTypes = new_SupportExtendedValueTypes;
		return back_SupportExtendedValueTypes;
	}
	public bool set_SupportExtendedReferenceTypes(bool new_SupportExtendedReferenceTypes){
		bool back_SupportExtendedReferenceTypes = p_SupportExtendedReferenceTypes;
		p_SupportExtendedReferenceTypes = new_SupportExtendedReferenceTypes;
		return back_SupportExtendedReferenceTypes;
	}
	public bool set_SupportFunctionPointerTypes(bool new_SupportFunctionPointerTypes){
		bool back_SupportFunctionPointerTypes = p_SupportFunctionPointerTypes;
		p_SupportFunctionPointerTypes = new_SupportFunctionPointerTypes;
		return back_SupportFunctionPointerTypes;
	}
	public bool set_SupportExtendedTypes(bool new_SupportExtendedTypes){
		bool back_SupportExtendedTypes = p_SupportExtendedTypes;
		p_SupportExtendedTypes = new_SupportExtendedTypes;
		return back_SupportExtendedTypes;
	}
	public bool set_AllowSetASCIIStringClass(bool new_AllowSetASCIIStringClass){
		bool back_AllowSetASCIIStringClass = p_AllowSetASCIIStringClass;
		p_AllowSetASCIIStringClass = new_AllowSetASCIIStringClass;
		return back_AllowSetASCIIStringClass;
	}
	public bool set_AllowSetStringClass(bool new_AllowSetStringClass){
		bool back_AllowSetStringClass = p_AllowSetStringClass;
		p_AllowSetStringClass = new_AllowSetStringClass;
		return back_AllowSetStringClass;
	}
	public bool set_AllowDisableNullReferenceCheckOnMemberAccess(bool new_AllowDisableNullReferenceCheckOnMemberAccess){
		bool back_AllowDisableNullReferenceCheckOnMemberAccess = p_AllowDisableNullReferenceCheckOnMemberAccess;
		p_AllowDisableNullReferenceCheckOnMemberAccess = new_AllowDisableNullReferenceCheckOnMemberAccess;
		return back_AllowDisableNullReferenceCheckOnMemberAccess;
	}
	public bool set_SupportPointerArithmetics(bool new_SupportPointerArithmetics){
		bool back_SupportPointerArithmetics = p_SupportPointerArithmetics;
		p_SupportPointerArithmetics = new_SupportPointerArithmetics;
		return back_SupportPointerArithmetics;
	}
	public bool set_AllowSetNullIntegerValue(bool new_AllowSetNullIntegerValue){
		bool back_AllowSetNullIntegerValue = p_AllowSetNullIntegerValue;
		p_AllowSetNullIntegerValue = new_AllowSetNullIntegerValue;
		return back_AllowSetNullIntegerValue;
	}
	public int set_NullIntegerValue(int new_NullIntegerValue){
		int back_NullIntegerValue = p_NullIntegerValue;
		p_NullIntegerValue = new_NullIntegerValue;
		return back_NullIntegerValue;
	}
	public bool set_AllowDisableBaseTypesArrayItemsInitialization(bool new_AllowDisableBaseTypesArrayItemsInitialization){
		bool back_AllowDisableBaseTypesArrayItemsInitialization = p_AllowDisableBaseTypesArrayItemsInitialization;
		p_AllowDisableBaseTypesArrayItemsInitialization = new_AllowDisableBaseTypesArrayItemsInitialization;
		return back_AllowDisableBaseTypesArrayItemsInitialization;
	}
	public bool set_AllowDisableStaticsVarsInitialization(bool new_AllowDisableStaticsVarsInitialization){
		bool back_AllowDisableStaticsVarsInitialization = p_AllowDisableStaticsVarsInitialization;
		p_AllowDisableStaticsVarsInitialization = new_AllowDisableStaticsVarsInitialization;
		return back_AllowDisableStaticsVarsInitialization;
	}
	public bool set_AllowDisableInstanceVarsInitialization(bool new_AllowDisableInstanceVarsInitialization){
		bool back_AllowDisableInstanceVarsInitialization = p_AllowDisableInstanceVarsInitialization;
		p_AllowDisableInstanceVarsInitialization = new_AllowDisableInstanceVarsInitialization;
		return back_AllowDisableInstanceVarsInitialization;
	}
	public bool set_AllowIgnorePreviousAssingmentRules(bool new_AllowIgnorePreviousAssingmentRules){
		bool back_AllowIgnorePreviousAssingmentRules = p_AllowIgnorePreviousAssingmentRules;
		p_AllowIgnorePreviousAssingmentRules = new_AllowIgnorePreviousAssingmentRules;
		return back_AllowIgnorePreviousAssingmentRules;
	}
	public bool set_AllowDisableAddressOfExpressionRequirementOnOutArguments(bool new_AllowDisableAddressOfExpressionRequirementOnOutArguments){
		bool back_AllowDisableAddressOfExpressionRequirementOnOutArguments = p_AllowDisableAddressOfExpressionRequirementOnOutArguments;
		p_AllowDisableAddressOfExpressionRequirementOnOutArguments = new_AllowDisableAddressOfExpressionRequirementOnOutArguments;
		return back_AllowDisableAddressOfExpressionRequirementOnOutArguments;
	}
	public bool set_AllowFinalizeMethod(bool new_AllowFinalizeMethod){
		bool back_AllowFinalizeMethod = p_AllowFinalizeMethod;
		p_AllowFinalizeMethod = new_AllowFinalizeMethod;
		return back_AllowFinalizeMethod;
	}
	public bool set_AllowNonNormalVirtualFunctionCallsOnConstructorsBody(bool new_AllowNonNormalVirtualFunctionCallsOnConstructorsBody){
		bool back_AllowNonNormalVirtualFunctionCallsOnConstructorsBody = p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody;
		p_AllowNonNormalVirtualFunctionCallsOnConstructorsBody = new_AllowNonNormalVirtualFunctionCallsOnConstructorsBody;
		return back_AllowNonNormalVirtualFunctionCallsOnConstructorsBody;
	}
	public bool set_AllowSelectiveVirtualMembers(bool new_AllowSelectiveVirtualMembers){
		bool back_AllowSelectiveVirtualMembers = p_AllowSelectiveVirtualMembers;
		p_AllowSelectiveVirtualMembers = new_AllowSelectiveVirtualMembers;
		return back_AllowSelectiveVirtualMembers;
	}
	public bool set_AllowNonLimitedGotos(bool new_AllowNonLimitedGotos){
		bool back_AllowNonLimitedGotos = p_AllowNonLimitedGotos;
		p_AllowNonLimitedGotos = new_AllowNonLimitedGotos;
		return back_AllowNonLimitedGotos;
	}
	public bool set_AllowSetRuntimeTypeInformation(bool new_AllowSetRuntimeTypeInformation){
		bool back_AllowSetRuntimeTypeInformation = p_AllowSetRuntimeTypeInformation;
		p_AllowSetRuntimeTypeInformation = new_AllowSetRuntimeTypeInformation;
		return back_AllowSetRuntimeTypeInformation;
	}
	public bool set_AllowSetRuntimeReflection(bool new_AllowSetRuntimeReflection){
		bool back_AllowSetRuntimeReflection = p_AllowSetRuntimeReflection;
		p_AllowSetRuntimeReflection = new_AllowSetRuntimeReflection;
		return back_AllowSetRuntimeReflection;
	}
	public bool set_AllowLimitRuntimeReflectionToModuleOnly(bool new_AllowLimitRuntimeReflectionToModuleOnly){
		bool back_AllowLimitRuntimeReflectionToModuleOnly = p_AllowLimitRuntimeReflectionToModuleOnly;
		p_AllowLimitRuntimeReflectionToModuleOnly = new_AllowLimitRuntimeReflectionToModuleOnly;
		return back_AllowLimitRuntimeReflectionToModuleOnly;
	}
	public bool set_AllowResumeExceptionModel(bool new_AllowResumeExceptionModel){
		bool back_AllowResumeExceptionModel = p_AllowResumeExceptionModel;
		p_AllowResumeExceptionModel = new_AllowResumeExceptionModel;
		return back_AllowResumeExceptionModel;
	}
	public bool set_AllowTerminationExceptionModel(bool new_AllowTerminationExceptionModel){
		bool back_AllowTerminationExceptionModel = p_AllowTerminationExceptionModel;
		p_AllowTerminationExceptionModel = new_AllowTerminationExceptionModel;
		return back_AllowTerminationExceptionModel;
	}
	public bool set_AllowFinallyBlocks(bool new_AllowFinallyBlocks){
		bool back_AllowFinallyBlocks = p_AllowFinallyBlocks;
		p_AllowFinallyBlocks = new_AllowFinallyBlocks;
		return back_AllowFinallyBlocks;
	}
	public bool set_AllowResumeNext(bool new_AllowResumeNext){
		bool back_AllowResumeNext = p_AllowResumeNext;
		p_AllowResumeNext = new_AllowResumeNext;
		return back_AllowResumeNext;
	}
	public bool set_AllowMixedExceptionModel(bool new_AllowMixedExceptionModel){
		bool back_AllowMixedExceptionModel = p_AllowMixedExceptionModel;
		p_AllowMixedExceptionModel = new_AllowMixedExceptionModel;
		return back_AllowMixedExceptionModel;
	}
	public bool set_AllowAnyTypeExceptions(bool new_AllowAnyTypeExceptions){
		bool back_AllowAnyTypeExceptions = p_AllowAnyTypeExceptions;
		p_AllowAnyTypeExceptions = new_AllowAnyTypeExceptions;
		return back_AllowAnyTypeExceptions;
	}
	public bool set_AllowStackVarsAsExceptions(bool new_AllowStackVarsAsExceptions){
		bool back_AllowStackVarsAsExceptions = p_AllowStackVarsAsExceptions;
		p_AllowStackVarsAsExceptions = new_AllowStackVarsAsExceptions;
		return back_AllowStackVarsAsExceptions;
	}
	public bool set_AllowRuntimeChecksFragmentedConfiguration(bool new_AllowRuntimeChecksFragmentedConfiguration){
		bool back_AllowRuntimeChecksFragmentedConfiguration = p_AllowRuntimeChecksFragmentedConfiguration;
		p_AllowRuntimeChecksFragmentedConfiguration = new_AllowRuntimeChecksFragmentedConfiguration;
		return back_AllowRuntimeChecksFragmentedConfiguration;
	}
	public string set_SupportedOperators(string new_SupportedOperators){
		string back_SupportedOperators = p_SupportedOperators;
		p_SupportedOperators = new_SupportedOperators;
		return back_SupportedOperators;
	}

	//Funciones para setear Elementos de Secuencia
	protected bool acceptInsertNodeCallback_GarbageCollector(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="GarbageCollector"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplGarbageCollector){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplGarbageCollector'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplGarbageCollector'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_GarbageCollector(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplGarbageCollector new_GarbageCollector(){
		XplGarbageCollector node = new XplGarbageCollector();
		node.set_ElementName("GarbageCollector");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

