/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/

#ifndef __LAYERD_CODEDOM_ZOELAYERDZOEPROGRAMREQUIREMENTS_V1_0_CPP
#define __LAYERD_CODEDOM_ZOELAYERDZOEPROGRAMREQUIREMENTS_V1_0_CPP
#include "CDOM_XplLayerDZoeProgramRequirements.h"

namespace CodeDOM{

//Region de Constructores Publicos
XplLayerDZoeProgramRequirements::XplLayerDZoeProgramRequirements(){
	p_UseCaseSensitive = true;
	p_SetDefaultSafeArrays = DT_EMPTY;
	p_DisableArrayLimitsChecks = false;
	p_UseSinglePointAsNamespaceSeparator = false;
	p_UseSimpleMemberAccessAsNamespaceSeparator = false;
	p_UseInheritsAsImplements = false;
	p_SetDefaultIdentifiersNamespace = DT_EMPTY;
	p_SetDefaultGarbageCollector = DT_EMPTY;
	p_UseSingleInheritance = true;
	p_UseUniversalObjectBase = true;
	p_SetUniversalObjectBase = DT_EMPTY;
	p_DisableUnifiedTypeSystem = false;
	p_EnableIntegerOverflowExceptions = false;
	p_EnableFloatOperationsExceptions = false;
	p_RequiereFullDecimalImplementation = false;
	p_RequireASCIIChar = false;
	p_RequireASCIIString = false;
	p_SetASCIIStringClass = DT_EMPTY;
	p_SetStringClass = DT_EMPTY;
	p_DisableNullReferenceCheckOnMemberAccess = false;
	p_RequirePointerArithmetics = false;
	p_DisableUnsafePointerConversionsFromVoid = false;
	p_DisableAllPointerConversionsFromVoid = false;
	p_DisableAllPointerConversionsToVoid = false;
	p_DisableAllPointerConversionsFromIntegers = false;
	p_DisableAllPointerConversionsToIntegers = false;
	p_SetNullIntegerValue = 0;
	p_DisableBaseTypesArrayItemsInitialization = false;
	p_DisableStaticsVarsInitialization = false;
	p_DisableInstanceVarsInitialization = false;
	p_EnableLocalsVarsInitialization = false;
	p_IgnorePreviousAssingmentRules = false;
	p_EnablePointerAssingnationWarningsAsErrors = false;
	p_DisablePointerAssingnationWarnings = false;
	p_DisableAddressOfExpressionRequirementOnOutArguments = false;
	p_DisableForcingFinalizeAsDestructor = false;
	p_ForceNormalVirtualFunctionCallsOnConstructorsBody = false;
	p_DisableVirtualizationOfMembers = false;
	p_ForceLimitedGotos = false;
	p_UseRuntimeTypeInformation = true;
	p_UseRuntimeReflection = false;
	p_LimitRuntimeReflectionToModuleOnly = false;
	p_UseResumeExceptionModel = false;
	p_UseTerminationExceptionModel = true;
	p_GarbageCollector = new XplNodeList();
	p_GarbageCollector->set_Parent(this);
	p_GarbageCollector->set_InsertNodeCallback(&acceptInsertNodeCallback_GarbageCollector);
	p_GarbageCollector->set_RemoveNodeCallback(&acceptRemoveNodeCallback_GarbageCollector);
}
XplLayerDZoeProgramRequirements::XplLayerDZoeProgramRequirements(bool n_UseCaseSensitive, bool n_DisableArrayLimitsChecks, bool n_UseSinglePointAsNamespaceSeparator, bool n_UseSimpleMemberAccessAsNamespaceSeparator, bool n_UseInheritsAsImplements, bool n_UseSingleInheritance, bool n_UseUniversalObjectBase, bool n_DisableUnifiedTypeSystem, bool n_EnableIntegerOverflowExceptions, bool n_EnableFloatOperationsExceptions, bool n_RequiereFullDecimalImplementation, bool n_RequireASCIIChar, bool n_RequireASCIIString, bool n_DisableNullReferenceCheckOnMemberAccess, bool n_RequirePointerArithmetics, bool n_DisableUnsafePointerConversionsFromVoid, bool n_DisableAllPointerConversionsFromVoid, bool n_DisableAllPointerConversionsToVoid, bool n_DisableAllPointerConversionsFromIntegers, bool n_DisableAllPointerConversionsToIntegers, bool n_DisableBaseTypesArrayItemsInitialization, bool n_DisableStaticsVarsInitialization, bool n_DisableInstanceVarsInitialization, bool n_EnableLocalsVarsInitialization, bool n_IgnorePreviousAssingmentRules, bool n_EnablePointerAssingnationWarningsAsErrors, bool n_DisablePointerAssingnationWarnings, bool n_DisableAddressOfExpressionRequirementOnOutArguments, bool n_DisableForcingFinalizeAsDestructor, bool n_ForceNormalVirtualFunctionCallsOnConstructorsBody, bool n_DisableVirtualizationOfMembers, bool n_ForceLimitedGotos, bool n_UseRuntimeTypeInformation, bool n_UseRuntimeReflection, bool n_LimitRuntimeReflectionToModuleOnly, bool n_UseResumeExceptionModel, bool n_UseTerminationExceptionModel){
	p_UseCaseSensitive = true;
	p_SetDefaultSafeArrays = DT_EMPTY;
	p_DisableArrayLimitsChecks = false;
	p_UseSinglePointAsNamespaceSeparator = false;
	p_UseSimpleMemberAccessAsNamespaceSeparator = false;
	p_UseInheritsAsImplements = false;
	p_SetDefaultIdentifiersNamespace = DT_EMPTY;
	p_SetDefaultGarbageCollector = DT_EMPTY;
	p_UseSingleInheritance = true;
	p_UseUniversalObjectBase = true;
	p_SetUniversalObjectBase = DT_EMPTY;
	p_DisableUnifiedTypeSystem = false;
	p_EnableIntegerOverflowExceptions = false;
	p_EnableFloatOperationsExceptions = false;
	p_RequiereFullDecimalImplementation = false;
	p_RequireASCIIChar = false;
	p_RequireASCIIString = false;
	p_SetASCIIStringClass = DT_EMPTY;
	p_SetStringClass = DT_EMPTY;
	p_DisableNullReferenceCheckOnMemberAccess = false;
	p_RequirePointerArithmetics = false;
	p_DisableUnsafePointerConversionsFromVoid = false;
	p_DisableAllPointerConversionsFromVoid = false;
	p_DisableAllPointerConversionsToVoid = false;
	p_DisableAllPointerConversionsFromIntegers = false;
	p_DisableAllPointerConversionsToIntegers = false;
	p_SetNullIntegerValue = 0;
	p_DisableBaseTypesArrayItemsInitialization = false;
	p_DisableStaticsVarsInitialization = false;
	p_DisableInstanceVarsInitialization = false;
	p_EnableLocalsVarsInitialization = false;
	p_IgnorePreviousAssingmentRules = false;
	p_EnablePointerAssingnationWarningsAsErrors = false;
	p_DisablePointerAssingnationWarnings = false;
	p_DisableAddressOfExpressionRequirementOnOutArguments = false;
	p_DisableForcingFinalizeAsDestructor = false;
	p_ForceNormalVirtualFunctionCallsOnConstructorsBody = false;
	p_DisableVirtualizationOfMembers = false;
	p_ForceLimitedGotos = false;
	p_UseRuntimeTypeInformation = true;
	p_UseRuntimeReflection = false;
	p_LimitRuntimeReflectionToModuleOnly = false;
	p_UseResumeExceptionModel = false;
	p_UseTerminationExceptionModel = true;
	set_UseCaseSensitive(n_UseCaseSensitive);
	set_DisableArrayLimitsChecks(n_DisableArrayLimitsChecks);
	set_UseSinglePointAsNamespaceSeparator(n_UseSinglePointAsNamespaceSeparator);
	set_UseSimpleMemberAccessAsNamespaceSeparator(n_UseSimpleMemberAccessAsNamespaceSeparator);
	set_UseInheritsAsImplements(n_UseInheritsAsImplements);
	set_UseSingleInheritance(n_UseSingleInheritance);
	set_UseUniversalObjectBase(n_UseUniversalObjectBase);
	set_DisableUnifiedTypeSystem(n_DisableUnifiedTypeSystem);
	set_EnableIntegerOverflowExceptions(n_EnableIntegerOverflowExceptions);
	set_EnableFloatOperationsExceptions(n_EnableFloatOperationsExceptions);
	set_RequiereFullDecimalImplementation(n_RequiereFullDecimalImplementation);
	set_RequireASCIIChar(n_RequireASCIIChar);
	set_RequireASCIIString(n_RequireASCIIString);
	set_DisableNullReferenceCheckOnMemberAccess(n_DisableNullReferenceCheckOnMemberAccess);
	set_RequirePointerArithmetics(n_RequirePointerArithmetics);
	set_DisableUnsafePointerConversionsFromVoid(n_DisableUnsafePointerConversionsFromVoid);
	set_DisableAllPointerConversionsFromVoid(n_DisableAllPointerConversionsFromVoid);
	set_DisableAllPointerConversionsToVoid(n_DisableAllPointerConversionsToVoid);
	set_DisableAllPointerConversionsFromIntegers(n_DisableAllPointerConversionsFromIntegers);
	set_DisableAllPointerConversionsToIntegers(n_DisableAllPointerConversionsToIntegers);
	set_DisableBaseTypesArrayItemsInitialization(n_DisableBaseTypesArrayItemsInitialization);
	set_DisableStaticsVarsInitialization(n_DisableStaticsVarsInitialization);
	set_DisableInstanceVarsInitialization(n_DisableInstanceVarsInitialization);
	set_EnableLocalsVarsInitialization(n_EnableLocalsVarsInitialization);
	set_IgnorePreviousAssingmentRules(n_IgnorePreviousAssingmentRules);
	set_EnablePointerAssingnationWarningsAsErrors(n_EnablePointerAssingnationWarningsAsErrors);
	set_DisablePointerAssingnationWarnings(n_DisablePointerAssingnationWarnings);
	set_DisableAddressOfExpressionRequirementOnOutArguments(n_DisableAddressOfExpressionRequirementOnOutArguments);
	set_DisableForcingFinalizeAsDestructor(n_DisableForcingFinalizeAsDestructor);
	set_ForceNormalVirtualFunctionCallsOnConstructorsBody(n_ForceNormalVirtualFunctionCallsOnConstructorsBody);
	set_DisableVirtualizationOfMembers(n_DisableVirtualizationOfMembers);
	set_ForceLimitedGotos(n_ForceLimitedGotos);
	set_UseRuntimeTypeInformation(n_UseRuntimeTypeInformation);
	set_UseRuntimeReflection(n_UseRuntimeReflection);
	set_LimitRuntimeReflectionToModuleOnly(n_LimitRuntimeReflectionToModuleOnly);
	set_UseResumeExceptionModel(n_UseResumeExceptionModel);
	set_UseTerminationExceptionModel(n_UseTerminationExceptionModel);
	p_GarbageCollector = new XplNodeList();
	p_GarbageCollector->set_Parent(this);
	p_GarbageCollector->set_InsertNodeCallback(&acceptInsertNodeCallback_GarbageCollector);
	p_GarbageCollector->set_RemoveNodeCallback(&acceptRemoveNodeCallback_GarbageCollector);
}
XplLayerDZoeProgramRequirements::XplLayerDZoeProgramRequirements(bool n_UseCaseSensitive, string n_SetDefaultSafeArrays, bool n_DisableArrayLimitsChecks, bool n_UseSinglePointAsNamespaceSeparator, bool n_UseSimpleMemberAccessAsNamespaceSeparator, bool n_UseInheritsAsImplements, string n_SetDefaultIdentifiersNamespace, string n_SetDefaultGarbageCollector, bool n_UseSingleInheritance, bool n_UseUniversalObjectBase, string n_SetUniversalObjectBase, bool n_DisableUnifiedTypeSystem, bool n_EnableIntegerOverflowExceptions, bool n_EnableFloatOperationsExceptions, bool n_RequiereFullDecimalImplementation, bool n_RequireASCIIChar, bool n_RequireASCIIString, string n_SetASCIIStringClass, string n_SetStringClass, bool n_DisableNullReferenceCheckOnMemberAccess, bool n_RequirePointerArithmetics, bool n_DisableUnsafePointerConversionsFromVoid, bool n_DisableAllPointerConversionsFromVoid, bool n_DisableAllPointerConversionsToVoid, bool n_DisableAllPointerConversionsFromIntegers, bool n_DisableAllPointerConversionsToIntegers, int n_SetNullIntegerValue, bool n_DisableBaseTypesArrayItemsInitialization, bool n_DisableStaticsVarsInitialization, bool n_DisableInstanceVarsInitialization, bool n_EnableLocalsVarsInitialization, bool n_IgnorePreviousAssingmentRules, bool n_EnablePointerAssingnationWarningsAsErrors, bool n_DisablePointerAssingnationWarnings, bool n_DisableAddressOfExpressionRequirementOnOutArguments, bool n_DisableForcingFinalizeAsDestructor, bool n_ForceNormalVirtualFunctionCallsOnConstructorsBody, bool n_DisableVirtualizationOfMembers, bool n_ForceLimitedGotos, bool n_UseRuntimeTypeInformation, bool n_UseRuntimeReflection, bool n_LimitRuntimeReflectionToModuleOnly, bool n_UseResumeExceptionModel, bool n_UseTerminationExceptionModel){
	set_UseCaseSensitive(n_UseCaseSensitive);
	set_SetDefaultSafeArrays(n_SetDefaultSafeArrays);
	set_DisableArrayLimitsChecks(n_DisableArrayLimitsChecks);
	set_UseSinglePointAsNamespaceSeparator(n_UseSinglePointAsNamespaceSeparator);
	set_UseSimpleMemberAccessAsNamespaceSeparator(n_UseSimpleMemberAccessAsNamespaceSeparator);
	set_UseInheritsAsImplements(n_UseInheritsAsImplements);
	set_SetDefaultIdentifiersNamespace(n_SetDefaultIdentifiersNamespace);
	set_SetDefaultGarbageCollector(n_SetDefaultGarbageCollector);
	set_UseSingleInheritance(n_UseSingleInheritance);
	set_UseUniversalObjectBase(n_UseUniversalObjectBase);
	set_SetUniversalObjectBase(n_SetUniversalObjectBase);
	set_DisableUnifiedTypeSystem(n_DisableUnifiedTypeSystem);
	set_EnableIntegerOverflowExceptions(n_EnableIntegerOverflowExceptions);
	set_EnableFloatOperationsExceptions(n_EnableFloatOperationsExceptions);
	set_RequiereFullDecimalImplementation(n_RequiereFullDecimalImplementation);
	set_RequireASCIIChar(n_RequireASCIIChar);
	set_RequireASCIIString(n_RequireASCIIString);
	set_SetASCIIStringClass(n_SetASCIIStringClass);
	set_SetStringClass(n_SetStringClass);
	set_DisableNullReferenceCheckOnMemberAccess(n_DisableNullReferenceCheckOnMemberAccess);
	set_RequirePointerArithmetics(n_RequirePointerArithmetics);
	set_DisableUnsafePointerConversionsFromVoid(n_DisableUnsafePointerConversionsFromVoid);
	set_DisableAllPointerConversionsFromVoid(n_DisableAllPointerConversionsFromVoid);
	set_DisableAllPointerConversionsToVoid(n_DisableAllPointerConversionsToVoid);
	set_DisableAllPointerConversionsFromIntegers(n_DisableAllPointerConversionsFromIntegers);
	set_DisableAllPointerConversionsToIntegers(n_DisableAllPointerConversionsToIntegers);
	set_SetNullIntegerValue(n_SetNullIntegerValue);
	set_DisableBaseTypesArrayItemsInitialization(n_DisableBaseTypesArrayItemsInitialization);
	set_DisableStaticsVarsInitialization(n_DisableStaticsVarsInitialization);
	set_DisableInstanceVarsInitialization(n_DisableInstanceVarsInitialization);
	set_EnableLocalsVarsInitialization(n_EnableLocalsVarsInitialization);
	set_IgnorePreviousAssingmentRules(n_IgnorePreviousAssingmentRules);
	set_EnablePointerAssingnationWarningsAsErrors(n_EnablePointerAssingnationWarningsAsErrors);
	set_DisablePointerAssingnationWarnings(n_DisablePointerAssingnationWarnings);
	set_DisableAddressOfExpressionRequirementOnOutArguments(n_DisableAddressOfExpressionRequirementOnOutArguments);
	set_DisableForcingFinalizeAsDestructor(n_DisableForcingFinalizeAsDestructor);
	set_ForceNormalVirtualFunctionCallsOnConstructorsBody(n_ForceNormalVirtualFunctionCallsOnConstructorsBody);
	set_DisableVirtualizationOfMembers(n_DisableVirtualizationOfMembers);
	set_ForceLimitedGotos(n_ForceLimitedGotos);
	set_UseRuntimeTypeInformation(n_UseRuntimeTypeInformation);
	set_UseRuntimeReflection(n_UseRuntimeReflection);
	set_LimitRuntimeReflectionToModuleOnly(n_LimitRuntimeReflectionToModuleOnly);
	set_UseResumeExceptionModel(n_UseResumeExceptionModel);
	set_UseTerminationExceptionModel(n_UseTerminationExceptionModel);
	p_GarbageCollector = new XplNodeList();
	p_GarbageCollector->set_Parent(this);
	p_GarbageCollector->set_InsertNodeCallback(&acceptInsertNodeCallback_GarbageCollector);
	p_GarbageCollector->set_RemoveNodeCallback(&acceptRemoveNodeCallback_GarbageCollector);
}
XplLayerDZoeProgramRequirements::XplLayerDZoeProgramRequirements(XplNodeList* n_GarbageCollector){
	p_UseCaseSensitive = true;
	p_SetDefaultSafeArrays = DT_EMPTY;
	p_DisableArrayLimitsChecks = false;
	p_UseSinglePointAsNamespaceSeparator = false;
	p_UseSimpleMemberAccessAsNamespaceSeparator = false;
	p_UseInheritsAsImplements = false;
	p_SetDefaultIdentifiersNamespace = DT_EMPTY;
	p_SetDefaultGarbageCollector = DT_EMPTY;
	p_UseSingleInheritance = true;
	p_UseUniversalObjectBase = true;
	p_SetUniversalObjectBase = DT_EMPTY;
	p_DisableUnifiedTypeSystem = false;
	p_EnableIntegerOverflowExceptions = false;
	p_EnableFloatOperationsExceptions = false;
	p_RequiereFullDecimalImplementation = false;
	p_RequireASCIIChar = false;
	p_RequireASCIIString = false;
	p_SetASCIIStringClass = DT_EMPTY;
	p_SetStringClass = DT_EMPTY;
	p_DisableNullReferenceCheckOnMemberAccess = false;
	p_RequirePointerArithmetics = false;
	p_DisableUnsafePointerConversionsFromVoid = false;
	p_DisableAllPointerConversionsFromVoid = false;
	p_DisableAllPointerConversionsToVoid = false;
	p_DisableAllPointerConversionsFromIntegers = false;
	p_DisableAllPointerConversionsToIntegers = false;
	p_SetNullIntegerValue = 0;
	p_DisableBaseTypesArrayItemsInitialization = false;
	p_DisableStaticsVarsInitialization = false;
	p_DisableInstanceVarsInitialization = false;
	p_EnableLocalsVarsInitialization = false;
	p_IgnorePreviousAssingmentRules = false;
	p_EnablePointerAssingnationWarningsAsErrors = false;
	p_DisablePointerAssingnationWarnings = false;
	p_DisableAddressOfExpressionRequirementOnOutArguments = false;
	p_DisableForcingFinalizeAsDestructor = false;
	p_ForceNormalVirtualFunctionCallsOnConstructorsBody = false;
	p_DisableVirtualizationOfMembers = false;
	p_ForceLimitedGotos = false;
	p_UseRuntimeTypeInformation = true;
	p_UseRuntimeReflection = false;
	p_LimitRuntimeReflectionToModuleOnly = false;
	p_UseResumeExceptionModel = false;
	p_UseTerminationExceptionModel = true;
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
XplLayerDZoeProgramRequirements::XplLayerDZoeProgramRequirements(bool n_UseCaseSensitive, bool n_DisableArrayLimitsChecks, bool n_UseSinglePointAsNamespaceSeparator, bool n_UseSimpleMemberAccessAsNamespaceSeparator, bool n_UseInheritsAsImplements, bool n_UseSingleInheritance, bool n_UseUniversalObjectBase, bool n_DisableUnifiedTypeSystem, bool n_EnableIntegerOverflowExceptions, bool n_EnableFloatOperationsExceptions, bool n_RequiereFullDecimalImplementation, bool n_RequireASCIIChar, bool n_RequireASCIIString, bool n_DisableNullReferenceCheckOnMemberAccess, bool n_RequirePointerArithmetics, bool n_DisableUnsafePointerConversionsFromVoid, bool n_DisableAllPointerConversionsFromVoid, bool n_DisableAllPointerConversionsToVoid, bool n_DisableAllPointerConversionsFromIntegers, bool n_DisableAllPointerConversionsToIntegers, bool n_DisableBaseTypesArrayItemsInitialization, bool n_DisableStaticsVarsInitialization, bool n_DisableInstanceVarsInitialization, bool n_EnableLocalsVarsInitialization, bool n_IgnorePreviousAssingmentRules, bool n_EnablePointerAssingnationWarningsAsErrors, bool n_DisablePointerAssingnationWarnings, bool n_DisableAddressOfExpressionRequirementOnOutArguments, bool n_DisableForcingFinalizeAsDestructor, bool n_ForceNormalVirtualFunctionCallsOnConstructorsBody, bool n_DisableVirtualizationOfMembers, bool n_ForceLimitedGotos, bool n_UseRuntimeTypeInformation, bool n_UseRuntimeReflection, bool n_LimitRuntimeReflectionToModuleOnly, bool n_UseResumeExceptionModel, bool n_UseTerminationExceptionModel, XplNodeList* n_GarbageCollector){
	p_UseCaseSensitive = true;
	p_SetDefaultSafeArrays = DT_EMPTY;
	p_DisableArrayLimitsChecks = false;
	p_UseSinglePointAsNamespaceSeparator = false;
	p_UseSimpleMemberAccessAsNamespaceSeparator = false;
	p_UseInheritsAsImplements = false;
	p_SetDefaultIdentifiersNamespace = DT_EMPTY;
	p_SetDefaultGarbageCollector = DT_EMPTY;
	p_UseSingleInheritance = true;
	p_UseUniversalObjectBase = true;
	p_SetUniversalObjectBase = DT_EMPTY;
	p_DisableUnifiedTypeSystem = false;
	p_EnableIntegerOverflowExceptions = false;
	p_EnableFloatOperationsExceptions = false;
	p_RequiereFullDecimalImplementation = false;
	p_RequireASCIIChar = false;
	p_RequireASCIIString = false;
	p_SetASCIIStringClass = DT_EMPTY;
	p_SetStringClass = DT_EMPTY;
	p_DisableNullReferenceCheckOnMemberAccess = false;
	p_RequirePointerArithmetics = false;
	p_DisableUnsafePointerConversionsFromVoid = false;
	p_DisableAllPointerConversionsFromVoid = false;
	p_DisableAllPointerConversionsToVoid = false;
	p_DisableAllPointerConversionsFromIntegers = false;
	p_DisableAllPointerConversionsToIntegers = false;
	p_SetNullIntegerValue = 0;
	p_DisableBaseTypesArrayItemsInitialization = false;
	p_DisableStaticsVarsInitialization = false;
	p_DisableInstanceVarsInitialization = false;
	p_EnableLocalsVarsInitialization = false;
	p_IgnorePreviousAssingmentRules = false;
	p_EnablePointerAssingnationWarningsAsErrors = false;
	p_DisablePointerAssingnationWarnings = false;
	p_DisableAddressOfExpressionRequirementOnOutArguments = false;
	p_DisableForcingFinalizeAsDestructor = false;
	p_ForceNormalVirtualFunctionCallsOnConstructorsBody = false;
	p_DisableVirtualizationOfMembers = false;
	p_ForceLimitedGotos = false;
	p_UseRuntimeTypeInformation = true;
	p_UseRuntimeReflection = false;
	p_LimitRuntimeReflectionToModuleOnly = false;
	p_UseResumeExceptionModel = false;
	p_UseTerminationExceptionModel = true;
	set_UseCaseSensitive(n_UseCaseSensitive);
	set_DisableArrayLimitsChecks(n_DisableArrayLimitsChecks);
	set_UseSinglePointAsNamespaceSeparator(n_UseSinglePointAsNamespaceSeparator);
	set_UseSimpleMemberAccessAsNamespaceSeparator(n_UseSimpleMemberAccessAsNamespaceSeparator);
	set_UseInheritsAsImplements(n_UseInheritsAsImplements);
	set_UseSingleInheritance(n_UseSingleInheritance);
	set_UseUniversalObjectBase(n_UseUniversalObjectBase);
	set_DisableUnifiedTypeSystem(n_DisableUnifiedTypeSystem);
	set_EnableIntegerOverflowExceptions(n_EnableIntegerOverflowExceptions);
	set_EnableFloatOperationsExceptions(n_EnableFloatOperationsExceptions);
	set_RequiereFullDecimalImplementation(n_RequiereFullDecimalImplementation);
	set_RequireASCIIChar(n_RequireASCIIChar);
	set_RequireASCIIString(n_RequireASCIIString);
	set_DisableNullReferenceCheckOnMemberAccess(n_DisableNullReferenceCheckOnMemberAccess);
	set_RequirePointerArithmetics(n_RequirePointerArithmetics);
	set_DisableUnsafePointerConversionsFromVoid(n_DisableUnsafePointerConversionsFromVoid);
	set_DisableAllPointerConversionsFromVoid(n_DisableAllPointerConversionsFromVoid);
	set_DisableAllPointerConversionsToVoid(n_DisableAllPointerConversionsToVoid);
	set_DisableAllPointerConversionsFromIntegers(n_DisableAllPointerConversionsFromIntegers);
	set_DisableAllPointerConversionsToIntegers(n_DisableAllPointerConversionsToIntegers);
	set_DisableBaseTypesArrayItemsInitialization(n_DisableBaseTypesArrayItemsInitialization);
	set_DisableStaticsVarsInitialization(n_DisableStaticsVarsInitialization);
	set_DisableInstanceVarsInitialization(n_DisableInstanceVarsInitialization);
	set_EnableLocalsVarsInitialization(n_EnableLocalsVarsInitialization);
	set_IgnorePreviousAssingmentRules(n_IgnorePreviousAssingmentRules);
	set_EnablePointerAssingnationWarningsAsErrors(n_EnablePointerAssingnationWarningsAsErrors);
	set_DisablePointerAssingnationWarnings(n_DisablePointerAssingnationWarnings);
	set_DisableAddressOfExpressionRequirementOnOutArguments(n_DisableAddressOfExpressionRequirementOnOutArguments);
	set_DisableForcingFinalizeAsDestructor(n_DisableForcingFinalizeAsDestructor);
	set_ForceNormalVirtualFunctionCallsOnConstructorsBody(n_ForceNormalVirtualFunctionCallsOnConstructorsBody);
	set_DisableVirtualizationOfMembers(n_DisableVirtualizationOfMembers);
	set_ForceLimitedGotos(n_ForceLimitedGotos);
	set_UseRuntimeTypeInformation(n_UseRuntimeTypeInformation);
	set_UseRuntimeReflection(n_UseRuntimeReflection);
	set_LimitRuntimeReflectionToModuleOnly(n_LimitRuntimeReflectionToModuleOnly);
	set_UseResumeExceptionModel(n_UseResumeExceptionModel);
	set_UseTerminationExceptionModel(n_UseTerminationExceptionModel);
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
XplLayerDZoeProgramRequirements::XplLayerDZoeProgramRequirements(bool n_UseCaseSensitive, string n_SetDefaultSafeArrays, bool n_DisableArrayLimitsChecks, bool n_UseSinglePointAsNamespaceSeparator, bool n_UseSimpleMemberAccessAsNamespaceSeparator, bool n_UseInheritsAsImplements, string n_SetDefaultIdentifiersNamespace, string n_SetDefaultGarbageCollector, bool n_UseSingleInheritance, bool n_UseUniversalObjectBase, string n_SetUniversalObjectBase, bool n_DisableUnifiedTypeSystem, bool n_EnableIntegerOverflowExceptions, bool n_EnableFloatOperationsExceptions, bool n_RequiereFullDecimalImplementation, bool n_RequireASCIIChar, bool n_RequireASCIIString, string n_SetASCIIStringClass, string n_SetStringClass, bool n_DisableNullReferenceCheckOnMemberAccess, bool n_RequirePointerArithmetics, bool n_DisableUnsafePointerConversionsFromVoid, bool n_DisableAllPointerConversionsFromVoid, bool n_DisableAllPointerConversionsToVoid, bool n_DisableAllPointerConversionsFromIntegers, bool n_DisableAllPointerConversionsToIntegers, int n_SetNullIntegerValue, bool n_DisableBaseTypesArrayItemsInitialization, bool n_DisableStaticsVarsInitialization, bool n_DisableInstanceVarsInitialization, bool n_EnableLocalsVarsInitialization, bool n_IgnorePreviousAssingmentRules, bool n_EnablePointerAssingnationWarningsAsErrors, bool n_DisablePointerAssingnationWarnings, bool n_DisableAddressOfExpressionRequirementOnOutArguments, bool n_DisableForcingFinalizeAsDestructor, bool n_ForceNormalVirtualFunctionCallsOnConstructorsBody, bool n_DisableVirtualizationOfMembers, bool n_ForceLimitedGotos, bool n_UseRuntimeTypeInformation, bool n_UseRuntimeReflection, bool n_LimitRuntimeReflectionToModuleOnly, bool n_UseResumeExceptionModel, bool n_UseTerminationExceptionModel, XplNodeList* n_GarbageCollector){
	set_UseCaseSensitive(n_UseCaseSensitive);
	set_SetDefaultSafeArrays(n_SetDefaultSafeArrays);
	set_DisableArrayLimitsChecks(n_DisableArrayLimitsChecks);
	set_UseSinglePointAsNamespaceSeparator(n_UseSinglePointAsNamespaceSeparator);
	set_UseSimpleMemberAccessAsNamespaceSeparator(n_UseSimpleMemberAccessAsNamespaceSeparator);
	set_UseInheritsAsImplements(n_UseInheritsAsImplements);
	set_SetDefaultIdentifiersNamespace(n_SetDefaultIdentifiersNamespace);
	set_SetDefaultGarbageCollector(n_SetDefaultGarbageCollector);
	set_UseSingleInheritance(n_UseSingleInheritance);
	set_UseUniversalObjectBase(n_UseUniversalObjectBase);
	set_SetUniversalObjectBase(n_SetUniversalObjectBase);
	set_DisableUnifiedTypeSystem(n_DisableUnifiedTypeSystem);
	set_EnableIntegerOverflowExceptions(n_EnableIntegerOverflowExceptions);
	set_EnableFloatOperationsExceptions(n_EnableFloatOperationsExceptions);
	set_RequiereFullDecimalImplementation(n_RequiereFullDecimalImplementation);
	set_RequireASCIIChar(n_RequireASCIIChar);
	set_RequireASCIIString(n_RequireASCIIString);
	set_SetASCIIStringClass(n_SetASCIIStringClass);
	set_SetStringClass(n_SetStringClass);
	set_DisableNullReferenceCheckOnMemberAccess(n_DisableNullReferenceCheckOnMemberAccess);
	set_RequirePointerArithmetics(n_RequirePointerArithmetics);
	set_DisableUnsafePointerConversionsFromVoid(n_DisableUnsafePointerConversionsFromVoid);
	set_DisableAllPointerConversionsFromVoid(n_DisableAllPointerConversionsFromVoid);
	set_DisableAllPointerConversionsToVoid(n_DisableAllPointerConversionsToVoid);
	set_DisableAllPointerConversionsFromIntegers(n_DisableAllPointerConversionsFromIntegers);
	set_DisableAllPointerConversionsToIntegers(n_DisableAllPointerConversionsToIntegers);
	set_SetNullIntegerValue(n_SetNullIntegerValue);
	set_DisableBaseTypesArrayItemsInitialization(n_DisableBaseTypesArrayItemsInitialization);
	set_DisableStaticsVarsInitialization(n_DisableStaticsVarsInitialization);
	set_DisableInstanceVarsInitialization(n_DisableInstanceVarsInitialization);
	set_EnableLocalsVarsInitialization(n_EnableLocalsVarsInitialization);
	set_IgnorePreviousAssingmentRules(n_IgnorePreviousAssingmentRules);
	set_EnablePointerAssingnationWarningsAsErrors(n_EnablePointerAssingnationWarningsAsErrors);
	set_DisablePointerAssingnationWarnings(n_DisablePointerAssingnationWarnings);
	set_DisableAddressOfExpressionRequirementOnOutArguments(n_DisableAddressOfExpressionRequirementOnOutArguments);
	set_DisableForcingFinalizeAsDestructor(n_DisableForcingFinalizeAsDestructor);
	set_ForceNormalVirtualFunctionCallsOnConstructorsBody(n_ForceNormalVirtualFunctionCallsOnConstructorsBody);
	set_DisableVirtualizationOfMembers(n_DisableVirtualizationOfMembers);
	set_ForceLimitedGotos(n_ForceLimitedGotos);
	set_UseRuntimeTypeInformation(n_UseRuntimeTypeInformation);
	set_UseRuntimeReflection(n_UseRuntimeReflection);
	set_LimitRuntimeReflectionToModuleOnly(n_LimitRuntimeReflectionToModuleOnly);
	set_UseResumeExceptionModel(n_UseResumeExceptionModel);
	set_UseTerminationExceptionModel(n_UseTerminationExceptionModel);
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
XplLayerDZoeProgramRequirements::~XplLayerDZoeProgramRequirements(){
#ifdef __LAYERD_CODEDOM_DEBUG_DESTRUCTORS
	__LAYERD_CODEDOM_DEBUG_OUTPUT("En el Destructor de 'XplLayerDZoeProgramRequirements'");
#endif
	//Variables para Elementos de Secuencia
	if(p_GarbageCollector!=NULL)delete p_GarbageCollector;
}

//Funciones Sobreescritas de XplNode
XplNode* XplLayerDZoeProgramRequirements::Clone(){
	XplLayerDZoeProgramRequirements* copy = new XplLayerDZoeProgramRequirements();
	copy->set_UseCaseSensitive(this->p_UseCaseSensitive);
	copy->set_SetDefaultSafeArrays(this->p_SetDefaultSafeArrays);
	copy->set_DisableArrayLimitsChecks(this->p_DisableArrayLimitsChecks);
	copy->set_UseSinglePointAsNamespaceSeparator(this->p_UseSinglePointAsNamespaceSeparator);
	copy->set_UseSimpleMemberAccessAsNamespaceSeparator(this->p_UseSimpleMemberAccessAsNamespaceSeparator);
	copy->set_UseInheritsAsImplements(this->p_UseInheritsAsImplements);
	copy->set_SetDefaultIdentifiersNamespace(this->p_SetDefaultIdentifiersNamespace);
	copy->set_SetDefaultGarbageCollector(this->p_SetDefaultGarbageCollector);
	copy->set_UseSingleInheritance(this->p_UseSingleInheritance);
	copy->set_UseUniversalObjectBase(this->p_UseUniversalObjectBase);
	copy->set_SetUniversalObjectBase(this->p_SetUniversalObjectBase);
	copy->set_DisableUnifiedTypeSystem(this->p_DisableUnifiedTypeSystem);
	copy->set_EnableIntegerOverflowExceptions(this->p_EnableIntegerOverflowExceptions);
	copy->set_EnableFloatOperationsExceptions(this->p_EnableFloatOperationsExceptions);
	copy->set_RequiereFullDecimalImplementation(this->p_RequiereFullDecimalImplementation);
	copy->set_RequireASCIIChar(this->p_RequireASCIIChar);
	copy->set_RequireASCIIString(this->p_RequireASCIIString);
	copy->set_SetASCIIStringClass(this->p_SetASCIIStringClass);
	copy->set_SetStringClass(this->p_SetStringClass);
	copy->set_DisableNullReferenceCheckOnMemberAccess(this->p_DisableNullReferenceCheckOnMemberAccess);
	copy->set_RequirePointerArithmetics(this->p_RequirePointerArithmetics);
	copy->set_DisableUnsafePointerConversionsFromVoid(this->p_DisableUnsafePointerConversionsFromVoid);
	copy->set_DisableAllPointerConversionsFromVoid(this->p_DisableAllPointerConversionsFromVoid);
	copy->set_DisableAllPointerConversionsToVoid(this->p_DisableAllPointerConversionsToVoid);
	copy->set_DisableAllPointerConversionsFromIntegers(this->p_DisableAllPointerConversionsFromIntegers);
	copy->set_DisableAllPointerConversionsToIntegers(this->p_DisableAllPointerConversionsToIntegers);
	copy->set_SetNullIntegerValue(this->p_SetNullIntegerValue);
	copy->set_DisableBaseTypesArrayItemsInitialization(this->p_DisableBaseTypesArrayItemsInitialization);
	copy->set_DisableStaticsVarsInitialization(this->p_DisableStaticsVarsInitialization);
	copy->set_DisableInstanceVarsInitialization(this->p_DisableInstanceVarsInitialization);
	copy->set_EnableLocalsVarsInitialization(this->p_EnableLocalsVarsInitialization);
	copy->set_IgnorePreviousAssingmentRules(this->p_IgnorePreviousAssingmentRules);
	copy->set_EnablePointerAssingnationWarningsAsErrors(this->p_EnablePointerAssingnationWarningsAsErrors);
	copy->set_DisablePointerAssingnationWarnings(this->p_DisablePointerAssingnationWarnings);
	copy->set_DisableAddressOfExpressionRequirementOnOutArguments(this->p_DisableAddressOfExpressionRequirementOnOutArguments);
	copy->set_DisableForcingFinalizeAsDestructor(this->p_DisableForcingFinalizeAsDestructor);
	copy->set_ForceNormalVirtualFunctionCallsOnConstructorsBody(this->p_ForceNormalVirtualFunctionCallsOnConstructorsBody);
	copy->set_DisableVirtualizationOfMembers(this->p_DisableVirtualizationOfMembers);
	copy->set_ForceLimitedGotos(this->p_ForceLimitedGotos);
	copy->set_UseRuntimeTypeInformation(this->p_UseRuntimeTypeInformation);
	copy->set_UseRuntimeReflection(this->p_UseRuntimeReflection);
	copy->set_LimitRuntimeReflectionToModuleOnly(this->p_LimitRuntimeReflectionToModuleOnly);
	copy->set_UseResumeExceptionModel(this->p_UseResumeExceptionModel);
	copy->set_UseTerminationExceptionModel(this->p_UseTerminationExceptionModel);
	for(XplNode* node = p_GarbageCollector->FirstNode(); node != NULL ; node = p_GarbageCollector->NextNode()){
		copy->get_GarbageCollector()->InsertAtEnd(node->Clone());
	}
	copy->set_ElementName(this->get_ElementName());
	return (XplNode*)copy;
}
bool XplLayerDZoeProgramRequirements::Write(XplWriter* writer){
	bool result=true;
	//Escribo el encabezado del elemento
	writer->write(DT("<")+this->get_ElementName());
	//Escribo los atributos del elemento
	if(p_UseCaseSensitive != true)
		writer->write(DT(" UseCaseSensitive=\"")+CODEDOM_Att_ToString(p_UseCaseSensitive)+DT("\""));
	if(p_SetDefaultSafeArrays != DT_EMPTY)
		writer->write(DT(" SetDefaultSafeArrays=\"")+CODEDOM_Att_ToString(p_SetDefaultSafeArrays)+DT("\""));
	if(p_DisableArrayLimitsChecks != false)
		writer->write(DT(" DisableArrayLimitsChecks=\"")+CODEDOM_Att_ToString(p_DisableArrayLimitsChecks)+DT("\""));
	if(p_UseSinglePointAsNamespaceSeparator != false)
		writer->write(DT(" UseSinglePointAsNamespaceSeparator=\"")+CODEDOM_Att_ToString(p_UseSinglePointAsNamespaceSeparator)+DT("\""));
	if(p_UseSimpleMemberAccessAsNamespaceSeparator != false)
		writer->write(DT(" UseSimpleMemberAccessAsNamespaceSeparator=\"")+CODEDOM_Att_ToString(p_UseSimpleMemberAccessAsNamespaceSeparator)+DT("\""));
	if(p_UseInheritsAsImplements != false)
		writer->write(DT(" UseInheritsAsImplements=\"")+CODEDOM_Att_ToString(p_UseInheritsAsImplements)+DT("\""));
	if(p_SetDefaultIdentifiersNamespace != DT_EMPTY)
		writer->write(DT(" SetDefaultIdentifiersNamespace=\"")+CODEDOM_Att_ToString(p_SetDefaultIdentifiersNamespace)+DT("\""));
	if(p_SetDefaultGarbageCollector != DT_EMPTY)
		writer->write(DT(" SetDefaultGarbageCollector=\"")+CODEDOM_Att_ToString(p_SetDefaultGarbageCollector)+DT("\""));
	if(p_UseSingleInheritance != true)
		writer->write(DT(" UseSingleInheritance=\"")+CODEDOM_Att_ToString(p_UseSingleInheritance)+DT("\""));
	if(p_UseUniversalObjectBase != true)
		writer->write(DT(" UseUniversalObjectBase=\"")+CODEDOM_Att_ToString(p_UseUniversalObjectBase)+DT("\""));
	if(p_SetUniversalObjectBase != DT_EMPTY)
		writer->write(DT(" SetUniversalObjectBase=\"")+CODEDOM_Att_ToString(p_SetUniversalObjectBase)+DT("\""));
	if(p_DisableUnifiedTypeSystem != false)
		writer->write(DT(" DisableUnifiedTypeSystem=\"")+CODEDOM_Att_ToString(p_DisableUnifiedTypeSystem)+DT("\""));
	if(p_EnableIntegerOverflowExceptions != false)
		writer->write(DT(" EnableIntegerOverflowExceptions=\"")+CODEDOM_Att_ToString(p_EnableIntegerOverflowExceptions)+DT("\""));
	if(p_EnableFloatOperationsExceptions != false)
		writer->write(DT(" EnableFloatOperationsExceptions=\"")+CODEDOM_Att_ToString(p_EnableFloatOperationsExceptions)+DT("\""));
	if(p_RequiereFullDecimalImplementation != false)
		writer->write(DT(" RequiereFullDecimalImplementation=\"")+CODEDOM_Att_ToString(p_RequiereFullDecimalImplementation)+DT("\""));
	if(p_RequireASCIIChar != false)
		writer->write(DT(" RequireASCIIChar=\"")+CODEDOM_Att_ToString(p_RequireASCIIChar)+DT("\""));
	if(p_RequireASCIIString != false)
		writer->write(DT(" RequireASCIIString=\"")+CODEDOM_Att_ToString(p_RequireASCIIString)+DT("\""));
	if(p_SetASCIIStringClass != DT_EMPTY)
		writer->write(DT(" SetASCIIStringClass=\"")+CODEDOM_Att_ToString(p_SetASCIIStringClass)+DT("\""));
	if(p_SetStringClass != DT_EMPTY)
		writer->write(DT(" SetStringClass=\"")+CODEDOM_Att_ToString(p_SetStringClass)+DT("\""));
	if(p_DisableNullReferenceCheckOnMemberAccess != false)
		writer->write(DT(" DisableNullReferenceCheckOnMemberAccess=\"")+CODEDOM_Att_ToString(p_DisableNullReferenceCheckOnMemberAccess)+DT("\""));
	if(p_RequirePointerArithmetics != false)
		writer->write(DT(" RequirePointerArithmetics=\"")+CODEDOM_Att_ToString(p_RequirePointerArithmetics)+DT("\""));
	if(p_DisableUnsafePointerConversionsFromVoid != false)
		writer->write(DT(" DisableUnsafePointerConversionsFromVoid=\"")+CODEDOM_Att_ToString(p_DisableUnsafePointerConversionsFromVoid)+DT("\""));
	if(p_DisableAllPointerConversionsFromVoid != false)
		writer->write(DT(" DisableAllPointerConversionsFromVoid=\"")+CODEDOM_Att_ToString(p_DisableAllPointerConversionsFromVoid)+DT("\""));
	if(p_DisableAllPointerConversionsToVoid != false)
		writer->write(DT(" DisableAllPointerConversionsToVoid=\"")+CODEDOM_Att_ToString(p_DisableAllPointerConversionsToVoid)+DT("\""));
	if(p_DisableAllPointerConversionsFromIntegers != false)
		writer->write(DT(" DisableAllPointerConversionsFromIntegers=\"")+CODEDOM_Att_ToString(p_DisableAllPointerConversionsFromIntegers)+DT("\""));
	if(p_DisableAllPointerConversionsToIntegers != false)
		writer->write(DT(" DisableAllPointerConversionsToIntegers=\"")+CODEDOM_Att_ToString(p_DisableAllPointerConversionsToIntegers)+DT("\""));
	if(p_SetNullIntegerValue != 0)
		writer->write(DT(" SetNullIntegerValue=\"")+CODEDOM_Att_ToString(p_SetNullIntegerValue)+DT("\""));
	if(p_DisableBaseTypesArrayItemsInitialization != false)
		writer->write(DT(" DisableBaseTypesArrayItemsInitialization=\"")+CODEDOM_Att_ToString(p_DisableBaseTypesArrayItemsInitialization)+DT("\""));
	if(p_DisableStaticsVarsInitialization != false)
		writer->write(DT(" DisableStaticsVarsInitialization=\"")+CODEDOM_Att_ToString(p_DisableStaticsVarsInitialization)+DT("\""));
	if(p_DisableInstanceVarsInitialization != false)
		writer->write(DT(" DisableInstanceVarsInitialization=\"")+CODEDOM_Att_ToString(p_DisableInstanceVarsInitialization)+DT("\""));
	if(p_EnableLocalsVarsInitialization != false)
		writer->write(DT(" EnableLocalsVarsInitialization=\"")+CODEDOM_Att_ToString(p_EnableLocalsVarsInitialization)+DT("\""));
	if(p_IgnorePreviousAssingmentRules != false)
		writer->write(DT(" IgnorePreviousAssingmentRules=\"")+CODEDOM_Att_ToString(p_IgnorePreviousAssingmentRules)+DT("\""));
	if(p_EnablePointerAssingnationWarningsAsErrors != false)
		writer->write(DT(" EnablePointerAssingnationWarningsAsErrors=\"")+CODEDOM_Att_ToString(p_EnablePointerAssingnationWarningsAsErrors)+DT("\""));
	if(p_DisablePointerAssingnationWarnings != false)
		writer->write(DT(" DisablePointerAssingnationWarnings=\"")+CODEDOM_Att_ToString(p_DisablePointerAssingnationWarnings)+DT("\""));
	if(p_DisableAddressOfExpressionRequirementOnOutArguments != false)
		writer->write(DT(" DisableAddressOfExpressionRequirementOnOutArguments=\"")+CODEDOM_Att_ToString(p_DisableAddressOfExpressionRequirementOnOutArguments)+DT("\""));
	if(p_DisableForcingFinalizeAsDestructor != false)
		writer->write(DT(" DisableForcingFinalizeAsDestructor=\"")+CODEDOM_Att_ToString(p_DisableForcingFinalizeAsDestructor)+DT("\""));
	if(p_ForceNormalVirtualFunctionCallsOnConstructorsBody != false)
		writer->write(DT(" ForceNormalVirtualFunctionCallsOnConstructorsBody=\"")+CODEDOM_Att_ToString(p_ForceNormalVirtualFunctionCallsOnConstructorsBody)+DT("\""));
	if(p_DisableVirtualizationOfMembers != false)
		writer->write(DT(" DisableVirtualizationOfMembers=\"")+CODEDOM_Att_ToString(p_DisableVirtualizationOfMembers)+DT("\""));
	if(p_ForceLimitedGotos != false)
		writer->write(DT(" ForceLimitedGotos=\"")+CODEDOM_Att_ToString(p_ForceLimitedGotos)+DT("\""));
	if(p_UseRuntimeTypeInformation != true)
		writer->write(DT(" UseRuntimeTypeInformation=\"")+CODEDOM_Att_ToString(p_UseRuntimeTypeInformation)+DT("\""));
	if(p_UseRuntimeReflection != false)
		writer->write(DT(" UseRuntimeReflection=\"")+CODEDOM_Att_ToString(p_UseRuntimeReflection)+DT("\""));
	if(p_LimitRuntimeReflectionToModuleOnly != false)
		writer->write(DT(" LimitRuntimeReflectionToModuleOnly=\"")+CODEDOM_Att_ToString(p_LimitRuntimeReflectionToModuleOnly)+DT("\""));
	if(p_UseResumeExceptionModel != false)
		writer->write(DT(" UseResumeExceptionModel=\"")+CODEDOM_Att_ToString(p_UseResumeExceptionModel)+DT("\""));
	if(p_UseTerminationExceptionModel != true)
		writer->write(DT(" UseTerminationExceptionModel=\"")+CODEDOM_Att_ToString(p_UseTerminationExceptionModel)+DT("\""));
	writer->write(DT(">"));
	//Escribo recursivamente cada elemento hijo
	if(p_GarbageCollector!=NULL)if(!p_GarbageCollector->Write(writer))result=false;
	//Cierro el elemento
	writer->write(DT("</")+this->get_ElementName()+DT(">"));
	return result;
}
XplNode* XplLayerDZoeProgramRequirements::Read(XplReader* reader){
	throw new CodeDOM_NotImplementedException(DT("Read"));
}

//Funciones para obtener Atributos
bool XplLayerDZoeProgramRequirements::get_UseCaseSensitive(){
	return p_UseCaseSensitive;
}
string XplLayerDZoeProgramRequirements::get_SetDefaultSafeArrays(){
	return p_SetDefaultSafeArrays;
}
bool XplLayerDZoeProgramRequirements::get_DisableArrayLimitsChecks(){
	return p_DisableArrayLimitsChecks;
}
bool XplLayerDZoeProgramRequirements::get_UseSinglePointAsNamespaceSeparator(){
	return p_UseSinglePointAsNamespaceSeparator;
}
bool XplLayerDZoeProgramRequirements::get_UseSimpleMemberAccessAsNamespaceSeparator(){
	return p_UseSimpleMemberAccessAsNamespaceSeparator;
}
bool XplLayerDZoeProgramRequirements::get_UseInheritsAsImplements(){
	return p_UseInheritsAsImplements;
}
string XplLayerDZoeProgramRequirements::get_SetDefaultIdentifiersNamespace(){
	return p_SetDefaultIdentifiersNamespace;
}
string XplLayerDZoeProgramRequirements::get_SetDefaultGarbageCollector(){
	return p_SetDefaultGarbageCollector;
}
bool XplLayerDZoeProgramRequirements::get_UseSingleInheritance(){
	return p_UseSingleInheritance;
}
bool XplLayerDZoeProgramRequirements::get_UseUniversalObjectBase(){
	return p_UseUniversalObjectBase;
}
string XplLayerDZoeProgramRequirements::get_SetUniversalObjectBase(){
	return p_SetUniversalObjectBase;
}
bool XplLayerDZoeProgramRequirements::get_DisableUnifiedTypeSystem(){
	return p_DisableUnifiedTypeSystem;
}
bool XplLayerDZoeProgramRequirements::get_EnableIntegerOverflowExceptions(){
	return p_EnableIntegerOverflowExceptions;
}
bool XplLayerDZoeProgramRequirements::get_EnableFloatOperationsExceptions(){
	return p_EnableFloatOperationsExceptions;
}
bool XplLayerDZoeProgramRequirements::get_RequiereFullDecimalImplementation(){
	return p_RequiereFullDecimalImplementation;
}
bool XplLayerDZoeProgramRequirements::get_RequireASCIIChar(){
	return p_RequireASCIIChar;
}
bool XplLayerDZoeProgramRequirements::get_RequireASCIIString(){
	return p_RequireASCIIString;
}
string XplLayerDZoeProgramRequirements::get_SetASCIIStringClass(){
	return p_SetASCIIStringClass;
}
string XplLayerDZoeProgramRequirements::get_SetStringClass(){
	return p_SetStringClass;
}
bool XplLayerDZoeProgramRequirements::get_DisableNullReferenceCheckOnMemberAccess(){
	return p_DisableNullReferenceCheckOnMemberAccess;
}
bool XplLayerDZoeProgramRequirements::get_RequirePointerArithmetics(){
	return p_RequirePointerArithmetics;
}
bool XplLayerDZoeProgramRequirements::get_DisableUnsafePointerConversionsFromVoid(){
	return p_DisableUnsafePointerConversionsFromVoid;
}
bool XplLayerDZoeProgramRequirements::get_DisableAllPointerConversionsFromVoid(){
	return p_DisableAllPointerConversionsFromVoid;
}
bool XplLayerDZoeProgramRequirements::get_DisableAllPointerConversionsToVoid(){
	return p_DisableAllPointerConversionsToVoid;
}
bool XplLayerDZoeProgramRequirements::get_DisableAllPointerConversionsFromIntegers(){
	return p_DisableAllPointerConversionsFromIntegers;
}
bool XplLayerDZoeProgramRequirements::get_DisableAllPointerConversionsToIntegers(){
	return p_DisableAllPointerConversionsToIntegers;
}
int XplLayerDZoeProgramRequirements::get_SetNullIntegerValue(){
	return p_SetNullIntegerValue;
}
bool XplLayerDZoeProgramRequirements::get_DisableBaseTypesArrayItemsInitialization(){
	return p_DisableBaseTypesArrayItemsInitialization;
}
bool XplLayerDZoeProgramRequirements::get_DisableStaticsVarsInitialization(){
	return p_DisableStaticsVarsInitialization;
}
bool XplLayerDZoeProgramRequirements::get_DisableInstanceVarsInitialization(){
	return p_DisableInstanceVarsInitialization;
}
bool XplLayerDZoeProgramRequirements::get_EnableLocalsVarsInitialization(){
	return p_EnableLocalsVarsInitialization;
}
bool XplLayerDZoeProgramRequirements::get_IgnorePreviousAssingmentRules(){
	return p_IgnorePreviousAssingmentRules;
}
bool XplLayerDZoeProgramRequirements::get_EnablePointerAssingnationWarningsAsErrors(){
	return p_EnablePointerAssingnationWarningsAsErrors;
}
bool XplLayerDZoeProgramRequirements::get_DisablePointerAssingnationWarnings(){
	return p_DisablePointerAssingnationWarnings;
}
bool XplLayerDZoeProgramRequirements::get_DisableAddressOfExpressionRequirementOnOutArguments(){
	return p_DisableAddressOfExpressionRequirementOnOutArguments;
}
bool XplLayerDZoeProgramRequirements::get_DisableForcingFinalizeAsDestructor(){
	return p_DisableForcingFinalizeAsDestructor;
}
bool XplLayerDZoeProgramRequirements::get_ForceNormalVirtualFunctionCallsOnConstructorsBody(){
	return p_ForceNormalVirtualFunctionCallsOnConstructorsBody;
}
bool XplLayerDZoeProgramRequirements::get_DisableVirtualizationOfMembers(){
	return p_DisableVirtualizationOfMembers;
}
bool XplLayerDZoeProgramRequirements::get_ForceLimitedGotos(){
	return p_ForceLimitedGotos;
}
bool XplLayerDZoeProgramRequirements::get_UseRuntimeTypeInformation(){
	return p_UseRuntimeTypeInformation;
}
bool XplLayerDZoeProgramRequirements::get_UseRuntimeReflection(){
	return p_UseRuntimeReflection;
}
bool XplLayerDZoeProgramRequirements::get_LimitRuntimeReflectionToModuleOnly(){
	return p_LimitRuntimeReflectionToModuleOnly;
}
bool XplLayerDZoeProgramRequirements::get_UseResumeExceptionModel(){
	return p_UseResumeExceptionModel;
}
bool XplLayerDZoeProgramRequirements::get_UseTerminationExceptionModel(){
	return p_UseTerminationExceptionModel;
}

//Funciones para obtener Elementos de Secuencia
XplNodeList* XplLayerDZoeProgramRequirements::get_GarbageCollector(){
	return p_GarbageCollector;
}

//Funciones para setear Atributos
bool XplLayerDZoeProgramRequirements::set_UseCaseSensitive(bool new_UseCaseSensitive){
	bool back_UseCaseSensitive = p_UseCaseSensitive;
	p_UseCaseSensitive = new_UseCaseSensitive;
	return back_UseCaseSensitive;
}
string XplLayerDZoeProgramRequirements::set_SetDefaultSafeArrays(string new_SetDefaultSafeArrays){
	string back_SetDefaultSafeArrays = p_SetDefaultSafeArrays;
	p_SetDefaultSafeArrays = new_SetDefaultSafeArrays;
	return back_SetDefaultSafeArrays;
}
bool XplLayerDZoeProgramRequirements::set_DisableArrayLimitsChecks(bool new_DisableArrayLimitsChecks){
	bool back_DisableArrayLimitsChecks = p_DisableArrayLimitsChecks;
	p_DisableArrayLimitsChecks = new_DisableArrayLimitsChecks;
	return back_DisableArrayLimitsChecks;
}
bool XplLayerDZoeProgramRequirements::set_UseSinglePointAsNamespaceSeparator(bool new_UseSinglePointAsNamespaceSeparator){
	bool back_UseSinglePointAsNamespaceSeparator = p_UseSinglePointAsNamespaceSeparator;
	p_UseSinglePointAsNamespaceSeparator = new_UseSinglePointAsNamespaceSeparator;
	return back_UseSinglePointAsNamespaceSeparator;
}
bool XplLayerDZoeProgramRequirements::set_UseSimpleMemberAccessAsNamespaceSeparator(bool new_UseSimpleMemberAccessAsNamespaceSeparator){
	bool back_UseSimpleMemberAccessAsNamespaceSeparator = p_UseSimpleMemberAccessAsNamespaceSeparator;
	p_UseSimpleMemberAccessAsNamespaceSeparator = new_UseSimpleMemberAccessAsNamespaceSeparator;
	return back_UseSimpleMemberAccessAsNamespaceSeparator;
}
bool XplLayerDZoeProgramRequirements::set_UseInheritsAsImplements(bool new_UseInheritsAsImplements){
	bool back_UseInheritsAsImplements = p_UseInheritsAsImplements;
	p_UseInheritsAsImplements = new_UseInheritsAsImplements;
	return back_UseInheritsAsImplements;
}
string XplLayerDZoeProgramRequirements::set_SetDefaultIdentifiersNamespace(string new_SetDefaultIdentifiersNamespace){
	string back_SetDefaultIdentifiersNamespace = p_SetDefaultIdentifiersNamespace;
	p_SetDefaultIdentifiersNamespace = new_SetDefaultIdentifiersNamespace;
	return back_SetDefaultIdentifiersNamespace;
}
string XplLayerDZoeProgramRequirements::set_SetDefaultGarbageCollector(string new_SetDefaultGarbageCollector){
	string back_SetDefaultGarbageCollector = p_SetDefaultGarbageCollector;
	p_SetDefaultGarbageCollector = new_SetDefaultGarbageCollector;
	return back_SetDefaultGarbageCollector;
}
bool XplLayerDZoeProgramRequirements::set_UseSingleInheritance(bool new_UseSingleInheritance){
	bool back_UseSingleInheritance = p_UseSingleInheritance;
	p_UseSingleInheritance = new_UseSingleInheritance;
	return back_UseSingleInheritance;
}
bool XplLayerDZoeProgramRequirements::set_UseUniversalObjectBase(bool new_UseUniversalObjectBase){
	bool back_UseUniversalObjectBase = p_UseUniversalObjectBase;
	p_UseUniversalObjectBase = new_UseUniversalObjectBase;
	return back_UseUniversalObjectBase;
}
string XplLayerDZoeProgramRequirements::set_SetUniversalObjectBase(string new_SetUniversalObjectBase){
	string back_SetUniversalObjectBase = p_SetUniversalObjectBase;
	p_SetUniversalObjectBase = new_SetUniversalObjectBase;
	return back_SetUniversalObjectBase;
}
bool XplLayerDZoeProgramRequirements::set_DisableUnifiedTypeSystem(bool new_DisableUnifiedTypeSystem){
	bool back_DisableUnifiedTypeSystem = p_DisableUnifiedTypeSystem;
	p_DisableUnifiedTypeSystem = new_DisableUnifiedTypeSystem;
	return back_DisableUnifiedTypeSystem;
}
bool XplLayerDZoeProgramRequirements::set_EnableIntegerOverflowExceptions(bool new_EnableIntegerOverflowExceptions){
	bool back_EnableIntegerOverflowExceptions = p_EnableIntegerOverflowExceptions;
	p_EnableIntegerOverflowExceptions = new_EnableIntegerOverflowExceptions;
	return back_EnableIntegerOverflowExceptions;
}
bool XplLayerDZoeProgramRequirements::set_EnableFloatOperationsExceptions(bool new_EnableFloatOperationsExceptions){
	bool back_EnableFloatOperationsExceptions = p_EnableFloatOperationsExceptions;
	p_EnableFloatOperationsExceptions = new_EnableFloatOperationsExceptions;
	return back_EnableFloatOperationsExceptions;
}
bool XplLayerDZoeProgramRequirements::set_RequiereFullDecimalImplementation(bool new_RequiereFullDecimalImplementation){
	bool back_RequiereFullDecimalImplementation = p_RequiereFullDecimalImplementation;
	p_RequiereFullDecimalImplementation = new_RequiereFullDecimalImplementation;
	return back_RequiereFullDecimalImplementation;
}
bool XplLayerDZoeProgramRequirements::set_RequireASCIIChar(bool new_RequireASCIIChar){
	bool back_RequireASCIIChar = p_RequireASCIIChar;
	p_RequireASCIIChar = new_RequireASCIIChar;
	return back_RequireASCIIChar;
}
bool XplLayerDZoeProgramRequirements::set_RequireASCIIString(bool new_RequireASCIIString){
	bool back_RequireASCIIString = p_RequireASCIIString;
	p_RequireASCIIString = new_RequireASCIIString;
	return back_RequireASCIIString;
}
string XplLayerDZoeProgramRequirements::set_SetASCIIStringClass(string new_SetASCIIStringClass){
	string back_SetASCIIStringClass = p_SetASCIIStringClass;
	p_SetASCIIStringClass = new_SetASCIIStringClass;
	return back_SetASCIIStringClass;
}
string XplLayerDZoeProgramRequirements::set_SetStringClass(string new_SetStringClass){
	string back_SetStringClass = p_SetStringClass;
	p_SetStringClass = new_SetStringClass;
	return back_SetStringClass;
}
bool XplLayerDZoeProgramRequirements::set_DisableNullReferenceCheckOnMemberAccess(bool new_DisableNullReferenceCheckOnMemberAccess){
	bool back_DisableNullReferenceCheckOnMemberAccess = p_DisableNullReferenceCheckOnMemberAccess;
	p_DisableNullReferenceCheckOnMemberAccess = new_DisableNullReferenceCheckOnMemberAccess;
	return back_DisableNullReferenceCheckOnMemberAccess;
}
bool XplLayerDZoeProgramRequirements::set_RequirePointerArithmetics(bool new_RequirePointerArithmetics){
	bool back_RequirePointerArithmetics = p_RequirePointerArithmetics;
	p_RequirePointerArithmetics = new_RequirePointerArithmetics;
	return back_RequirePointerArithmetics;
}
bool XplLayerDZoeProgramRequirements::set_DisableUnsafePointerConversionsFromVoid(bool new_DisableUnsafePointerConversionsFromVoid){
	bool back_DisableUnsafePointerConversionsFromVoid = p_DisableUnsafePointerConversionsFromVoid;
	p_DisableUnsafePointerConversionsFromVoid = new_DisableUnsafePointerConversionsFromVoid;
	return back_DisableUnsafePointerConversionsFromVoid;
}
bool XplLayerDZoeProgramRequirements::set_DisableAllPointerConversionsFromVoid(bool new_DisableAllPointerConversionsFromVoid){
	bool back_DisableAllPointerConversionsFromVoid = p_DisableAllPointerConversionsFromVoid;
	p_DisableAllPointerConversionsFromVoid = new_DisableAllPointerConversionsFromVoid;
	return back_DisableAllPointerConversionsFromVoid;
}
bool XplLayerDZoeProgramRequirements::set_DisableAllPointerConversionsToVoid(bool new_DisableAllPointerConversionsToVoid){
	bool back_DisableAllPointerConversionsToVoid = p_DisableAllPointerConversionsToVoid;
	p_DisableAllPointerConversionsToVoid = new_DisableAllPointerConversionsToVoid;
	return back_DisableAllPointerConversionsToVoid;
}
bool XplLayerDZoeProgramRequirements::set_DisableAllPointerConversionsFromIntegers(bool new_DisableAllPointerConversionsFromIntegers){
	bool back_DisableAllPointerConversionsFromIntegers = p_DisableAllPointerConversionsFromIntegers;
	p_DisableAllPointerConversionsFromIntegers = new_DisableAllPointerConversionsFromIntegers;
	return back_DisableAllPointerConversionsFromIntegers;
}
bool XplLayerDZoeProgramRequirements::set_DisableAllPointerConversionsToIntegers(bool new_DisableAllPointerConversionsToIntegers){
	bool back_DisableAllPointerConversionsToIntegers = p_DisableAllPointerConversionsToIntegers;
	p_DisableAllPointerConversionsToIntegers = new_DisableAllPointerConversionsToIntegers;
	return back_DisableAllPointerConversionsToIntegers;
}
int XplLayerDZoeProgramRequirements::set_SetNullIntegerValue(int new_SetNullIntegerValue){
	int back_SetNullIntegerValue = p_SetNullIntegerValue;
	p_SetNullIntegerValue = new_SetNullIntegerValue;
	return back_SetNullIntegerValue;
}
bool XplLayerDZoeProgramRequirements::set_DisableBaseTypesArrayItemsInitialization(bool new_DisableBaseTypesArrayItemsInitialization){
	bool back_DisableBaseTypesArrayItemsInitialization = p_DisableBaseTypesArrayItemsInitialization;
	p_DisableBaseTypesArrayItemsInitialization = new_DisableBaseTypesArrayItemsInitialization;
	return back_DisableBaseTypesArrayItemsInitialization;
}
bool XplLayerDZoeProgramRequirements::set_DisableStaticsVarsInitialization(bool new_DisableStaticsVarsInitialization){
	bool back_DisableStaticsVarsInitialization = p_DisableStaticsVarsInitialization;
	p_DisableStaticsVarsInitialization = new_DisableStaticsVarsInitialization;
	return back_DisableStaticsVarsInitialization;
}
bool XplLayerDZoeProgramRequirements::set_DisableInstanceVarsInitialization(bool new_DisableInstanceVarsInitialization){
	bool back_DisableInstanceVarsInitialization = p_DisableInstanceVarsInitialization;
	p_DisableInstanceVarsInitialization = new_DisableInstanceVarsInitialization;
	return back_DisableInstanceVarsInitialization;
}
bool XplLayerDZoeProgramRequirements::set_EnableLocalsVarsInitialization(bool new_EnableLocalsVarsInitialization){
	bool back_EnableLocalsVarsInitialization = p_EnableLocalsVarsInitialization;
	p_EnableLocalsVarsInitialization = new_EnableLocalsVarsInitialization;
	return back_EnableLocalsVarsInitialization;
}
bool XplLayerDZoeProgramRequirements::set_IgnorePreviousAssingmentRules(bool new_IgnorePreviousAssingmentRules){
	bool back_IgnorePreviousAssingmentRules = p_IgnorePreviousAssingmentRules;
	p_IgnorePreviousAssingmentRules = new_IgnorePreviousAssingmentRules;
	return back_IgnorePreviousAssingmentRules;
}
bool XplLayerDZoeProgramRequirements::set_EnablePointerAssingnationWarningsAsErrors(bool new_EnablePointerAssingnationWarningsAsErrors){
	bool back_EnablePointerAssingnationWarningsAsErrors = p_EnablePointerAssingnationWarningsAsErrors;
	p_EnablePointerAssingnationWarningsAsErrors = new_EnablePointerAssingnationWarningsAsErrors;
	return back_EnablePointerAssingnationWarningsAsErrors;
}
bool XplLayerDZoeProgramRequirements::set_DisablePointerAssingnationWarnings(bool new_DisablePointerAssingnationWarnings){
	bool back_DisablePointerAssingnationWarnings = p_DisablePointerAssingnationWarnings;
	p_DisablePointerAssingnationWarnings = new_DisablePointerAssingnationWarnings;
	return back_DisablePointerAssingnationWarnings;
}
bool XplLayerDZoeProgramRequirements::set_DisableAddressOfExpressionRequirementOnOutArguments(bool new_DisableAddressOfExpressionRequirementOnOutArguments){
	bool back_DisableAddressOfExpressionRequirementOnOutArguments = p_DisableAddressOfExpressionRequirementOnOutArguments;
	p_DisableAddressOfExpressionRequirementOnOutArguments = new_DisableAddressOfExpressionRequirementOnOutArguments;
	return back_DisableAddressOfExpressionRequirementOnOutArguments;
}
bool XplLayerDZoeProgramRequirements::set_DisableForcingFinalizeAsDestructor(bool new_DisableForcingFinalizeAsDestructor){
	bool back_DisableForcingFinalizeAsDestructor = p_DisableForcingFinalizeAsDestructor;
	p_DisableForcingFinalizeAsDestructor = new_DisableForcingFinalizeAsDestructor;
	return back_DisableForcingFinalizeAsDestructor;
}
bool XplLayerDZoeProgramRequirements::set_ForceNormalVirtualFunctionCallsOnConstructorsBody(bool new_ForceNormalVirtualFunctionCallsOnConstructorsBody){
	bool back_ForceNormalVirtualFunctionCallsOnConstructorsBody = p_ForceNormalVirtualFunctionCallsOnConstructorsBody;
	p_ForceNormalVirtualFunctionCallsOnConstructorsBody = new_ForceNormalVirtualFunctionCallsOnConstructorsBody;
	return back_ForceNormalVirtualFunctionCallsOnConstructorsBody;
}
bool XplLayerDZoeProgramRequirements::set_DisableVirtualizationOfMembers(bool new_DisableVirtualizationOfMembers){
	bool back_DisableVirtualizationOfMembers = p_DisableVirtualizationOfMembers;
	p_DisableVirtualizationOfMembers = new_DisableVirtualizationOfMembers;
	return back_DisableVirtualizationOfMembers;
}
bool XplLayerDZoeProgramRequirements::set_ForceLimitedGotos(bool new_ForceLimitedGotos){
	bool back_ForceLimitedGotos = p_ForceLimitedGotos;
	p_ForceLimitedGotos = new_ForceLimitedGotos;
	return back_ForceLimitedGotos;
}
bool XplLayerDZoeProgramRequirements::set_UseRuntimeTypeInformation(bool new_UseRuntimeTypeInformation){
	bool back_UseRuntimeTypeInformation = p_UseRuntimeTypeInformation;
	p_UseRuntimeTypeInformation = new_UseRuntimeTypeInformation;
	return back_UseRuntimeTypeInformation;
}
bool XplLayerDZoeProgramRequirements::set_UseRuntimeReflection(bool new_UseRuntimeReflection){
	bool back_UseRuntimeReflection = p_UseRuntimeReflection;
	p_UseRuntimeReflection = new_UseRuntimeReflection;
	return back_UseRuntimeReflection;
}
bool XplLayerDZoeProgramRequirements::set_LimitRuntimeReflectionToModuleOnly(bool new_LimitRuntimeReflectionToModuleOnly){
	bool back_LimitRuntimeReflectionToModuleOnly = p_LimitRuntimeReflectionToModuleOnly;
	p_LimitRuntimeReflectionToModuleOnly = new_LimitRuntimeReflectionToModuleOnly;
	return back_LimitRuntimeReflectionToModuleOnly;
}
bool XplLayerDZoeProgramRequirements::set_UseResumeExceptionModel(bool new_UseResumeExceptionModel){
	bool back_UseResumeExceptionModel = p_UseResumeExceptionModel;
	p_UseResumeExceptionModel = new_UseResumeExceptionModel;
	return back_UseResumeExceptionModel;
}
bool XplLayerDZoeProgramRequirements::set_UseTerminationExceptionModel(bool new_UseTerminationExceptionModel){
	bool back_UseTerminationExceptionModel = p_UseTerminationExceptionModel;
	p_UseTerminationExceptionModel = new_UseTerminationExceptionModel;
	return back_UseTerminationExceptionModel;
}

//Funciones para setear Elementos de Secuencia
	bool XplLayerDZoeProgramRequirements::acceptInsertNodeCallback_GarbageCollector(XplNode* node, string* errorMsg, XplNode* parent){
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
	bool XplLayerDZoeProgramRequirements::acceptRemoveNodeCallback_GarbageCollector(XplNode* node, string* errorMsg, XplNode* parent){
		return true;
	}
XplGarbageCollector* XplLayerDZoeProgramRequirements::new_GarbageCollector(){
	XplGarbageCollector* node = new XplGarbageCollector();
	node->set_ElementName(DT("GarbageCollector"));
	return node;
}

}

#endif
