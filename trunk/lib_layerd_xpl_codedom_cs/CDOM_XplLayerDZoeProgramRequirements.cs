/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 8/11/2011 4:27:20 PM
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
public class XplLayerDZoeProgramRequirements:  XplNode{

	#region Variables privadas para atributos y elementos
	bool p_UseCaseSensitive;
	string p_SetDefaultSafeArrays;
	bool p_DisableArrayLimitsChecks;
	bool p_UseSinglePointAsNamespaceSeparator;
	bool p_UseSimpleMemberAccessAsNamespaceSeparator;
	bool p_UseInheritsAsImplements;
	string p_SetDefaultIdentifiersNamespace;
	string p_SetDefaultGarbageCollector;
	bool p_UseSingleInheritance;
	bool p_UseUniversalObjectBase;
	string p_SetUniversalObjectBase;
	bool p_DisableUnifiedTypeSystem;
	bool p_EnableIntegerOverflowExceptions;
	bool p_EnableFloatOperationsExceptions;
	bool p_RequiereFullDecimalImplementation;
	bool p_RequireASCIIChar;
	bool p_RequireASCIIString;
	string p_SetASCIIStringClass;
	string p_SetStringClass;
	bool p_DisableNullReferenceCheckOnMemberAccess;
	bool p_RequirePointerArithmetics;
	bool p_DisableUnsafePointerConversionsFromVoid;
	bool p_DisableAllPointerConversionsFromVoid;
	bool p_DisableAllPointerConversionsToVoid;
	bool p_DisableAllPointerConversionsFromIntegers;
	bool p_DisableAllPointerConversionsToIntegers;
	int p_SetNullIntegerValue;
	bool p_DisableBaseTypesArrayItemsInitialization;
	bool p_DisableStaticsVarsInitialization;
	bool p_DisableInstanceVarsInitialization;
	bool p_EnableLocalsVarsInitialization;
	bool p_IgnorePreviousAssingmentRules;
	bool p_EnablePointerAssingnationWarningsAsErrors;
	bool p_DisablePointerAssingnationWarnings;
	bool p_DisableAddressOfExpressionRequirementOnOutArguments;
	bool p_DisableForcingFinalizeAsDestructor;
	bool p_ForceNormalVirtualFunctionCallsOnConstructorsBody;
	bool p_DisableVirtualizationOfMembers;
	bool p_ForceLimitedGotos;
	bool p_UseRuntimeTypeInformation;
	bool p_UseRuntimeReflection;
	bool p_LimitRuntimeReflectionToModuleOnly;
	bool p_UseResumeExceptionModel;
	bool p_UseTerminationExceptionModel;
	//Variables para Elementos de Secuencia
	XplNodeList p_GarbageCollector;
	#endregion

	#region Region de Constructores Publicos
	public XplLayerDZoeProgramRequirements(){
		p_UseCaseSensitive = true;
		p_SetDefaultSafeArrays = "";
		p_DisableArrayLimitsChecks = false;
		p_UseSinglePointAsNamespaceSeparator = false;
		p_UseSimpleMemberAccessAsNamespaceSeparator = false;
		p_UseInheritsAsImplements = false;
		p_SetDefaultIdentifiersNamespace = "";
		p_SetDefaultGarbageCollector = "";
		p_UseSingleInheritance = true;
		p_UseUniversalObjectBase = true;
		p_SetUniversalObjectBase = "";
		p_DisableUnifiedTypeSystem = false;
		p_EnableIntegerOverflowExceptions = false;
		p_EnableFloatOperationsExceptions = false;
		p_RequiereFullDecimalImplementation = false;
		p_RequireASCIIChar = false;
		p_RequireASCIIString = false;
		p_SetASCIIStringClass = "";
		p_SetStringClass = "";
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
		p_GarbageCollector.set_Parent(this);
		p_GarbageCollector.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_GarbageCollector));
		p_GarbageCollector.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_GarbageCollector));
}
	public XplLayerDZoeProgramRequirements(bool n_UseCaseSensitive, bool n_DisableArrayLimitsChecks, bool n_UseSinglePointAsNamespaceSeparator, bool n_UseSimpleMemberAccessAsNamespaceSeparator, bool n_UseInheritsAsImplements, bool n_UseSingleInheritance, bool n_UseUniversalObjectBase, bool n_DisableUnifiedTypeSystem, bool n_EnableIntegerOverflowExceptions, bool n_EnableFloatOperationsExceptions, bool n_RequiereFullDecimalImplementation, bool n_RequireASCIIChar, bool n_RequireASCIIString, bool n_DisableNullReferenceCheckOnMemberAccess, bool n_RequirePointerArithmetics, bool n_DisableUnsafePointerConversionsFromVoid, bool n_DisableAllPointerConversionsFromVoid, bool n_DisableAllPointerConversionsToVoid, bool n_DisableAllPointerConversionsFromIntegers, bool n_DisableAllPointerConversionsToIntegers, bool n_DisableBaseTypesArrayItemsInitialization, bool n_DisableStaticsVarsInitialization, bool n_DisableInstanceVarsInitialization, bool n_EnableLocalsVarsInitialization, bool n_IgnorePreviousAssingmentRules, bool n_EnablePointerAssingnationWarningsAsErrors, bool n_DisablePointerAssingnationWarnings, bool n_DisableAddressOfExpressionRequirementOnOutArguments, bool n_DisableForcingFinalizeAsDestructor, bool n_ForceNormalVirtualFunctionCallsOnConstructorsBody, bool n_DisableVirtualizationOfMembers, bool n_ForceLimitedGotos, bool n_UseRuntimeTypeInformation, bool n_UseRuntimeReflection, bool n_LimitRuntimeReflectionToModuleOnly, bool n_UseResumeExceptionModel, bool n_UseTerminationExceptionModel){
		p_UseCaseSensitive = true;
		p_SetDefaultSafeArrays = "";
		p_DisableArrayLimitsChecks = false;
		p_UseSinglePointAsNamespaceSeparator = false;
		p_UseSimpleMemberAccessAsNamespaceSeparator = false;
		p_UseInheritsAsImplements = false;
		p_SetDefaultIdentifiersNamespace = "";
		p_SetDefaultGarbageCollector = "";
		p_UseSingleInheritance = true;
		p_UseUniversalObjectBase = true;
		p_SetUniversalObjectBase = "";
		p_DisableUnifiedTypeSystem = false;
		p_EnableIntegerOverflowExceptions = false;
		p_EnableFloatOperationsExceptions = false;
		p_RequiereFullDecimalImplementation = false;
		p_RequireASCIIChar = false;
		p_RequireASCIIString = false;
		p_SetASCIIStringClass = "";
		p_SetStringClass = "";
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
		p_GarbageCollector.set_Parent(this);
		p_GarbageCollector.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_GarbageCollector));
		p_GarbageCollector.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_GarbageCollector));
	}
	public XplLayerDZoeProgramRequirements(bool n_UseCaseSensitive, string n_SetDefaultSafeArrays, bool n_DisableArrayLimitsChecks, bool n_UseSinglePointAsNamespaceSeparator, bool n_UseSimpleMemberAccessAsNamespaceSeparator, bool n_UseInheritsAsImplements, string n_SetDefaultIdentifiersNamespace, string n_SetDefaultGarbageCollector, bool n_UseSingleInheritance, bool n_UseUniversalObjectBase, string n_SetUniversalObjectBase, bool n_DisableUnifiedTypeSystem, bool n_EnableIntegerOverflowExceptions, bool n_EnableFloatOperationsExceptions, bool n_RequiereFullDecimalImplementation, bool n_RequireASCIIChar, bool n_RequireASCIIString, string n_SetASCIIStringClass, string n_SetStringClass, bool n_DisableNullReferenceCheckOnMemberAccess, bool n_RequirePointerArithmetics, bool n_DisableUnsafePointerConversionsFromVoid, bool n_DisableAllPointerConversionsFromVoid, bool n_DisableAllPointerConversionsToVoid, bool n_DisableAllPointerConversionsFromIntegers, bool n_DisableAllPointerConversionsToIntegers, int n_SetNullIntegerValue, bool n_DisableBaseTypesArrayItemsInitialization, bool n_DisableStaticsVarsInitialization, bool n_DisableInstanceVarsInitialization, bool n_EnableLocalsVarsInitialization, bool n_IgnorePreviousAssingmentRules, bool n_EnablePointerAssingnationWarningsAsErrors, bool n_DisablePointerAssingnationWarnings, bool n_DisableAddressOfExpressionRequirementOnOutArguments, bool n_DisableForcingFinalizeAsDestructor, bool n_ForceNormalVirtualFunctionCallsOnConstructorsBody, bool n_DisableVirtualizationOfMembers, bool n_ForceLimitedGotos, bool n_UseRuntimeTypeInformation, bool n_UseRuntimeReflection, bool n_LimitRuntimeReflectionToModuleOnly, bool n_UseResumeExceptionModel, bool n_UseTerminationExceptionModel){
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
		p_GarbageCollector.set_Parent(this);
		p_GarbageCollector.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_GarbageCollector));
		p_GarbageCollector.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_GarbageCollector));
	}
	public XplLayerDZoeProgramRequirements(XplNodeList n_GarbageCollector){
		p_UseCaseSensitive = true;
		p_SetDefaultSafeArrays = "";
		p_DisableArrayLimitsChecks = false;
		p_UseSinglePointAsNamespaceSeparator = false;
		p_UseSimpleMemberAccessAsNamespaceSeparator = false;
		p_UseInheritsAsImplements = false;
		p_SetDefaultIdentifiersNamespace = "";
		p_SetDefaultGarbageCollector = "";
		p_UseSingleInheritance = true;
		p_UseUniversalObjectBase = true;
		p_SetUniversalObjectBase = "";
		p_DisableUnifiedTypeSystem = false;
		p_EnableIntegerOverflowExceptions = false;
		p_EnableFloatOperationsExceptions = false;
		p_RequiereFullDecimalImplementation = false;
		p_RequireASCIIChar = false;
		p_RequireASCIIString = false;
		p_SetASCIIStringClass = "";
		p_SetStringClass = "";
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
	public XplLayerDZoeProgramRequirements(bool n_UseCaseSensitive, bool n_DisableArrayLimitsChecks, bool n_UseSinglePointAsNamespaceSeparator, bool n_UseSimpleMemberAccessAsNamespaceSeparator, bool n_UseInheritsAsImplements, bool n_UseSingleInheritance, bool n_UseUniversalObjectBase, bool n_DisableUnifiedTypeSystem, bool n_EnableIntegerOverflowExceptions, bool n_EnableFloatOperationsExceptions, bool n_RequiereFullDecimalImplementation, bool n_RequireASCIIChar, bool n_RequireASCIIString, bool n_DisableNullReferenceCheckOnMemberAccess, bool n_RequirePointerArithmetics, bool n_DisableUnsafePointerConversionsFromVoid, bool n_DisableAllPointerConversionsFromVoid, bool n_DisableAllPointerConversionsToVoid, bool n_DisableAllPointerConversionsFromIntegers, bool n_DisableAllPointerConversionsToIntegers, bool n_DisableBaseTypesArrayItemsInitialization, bool n_DisableStaticsVarsInitialization, bool n_DisableInstanceVarsInitialization, bool n_EnableLocalsVarsInitialization, bool n_IgnorePreviousAssingmentRules, bool n_EnablePointerAssingnationWarningsAsErrors, bool n_DisablePointerAssingnationWarnings, bool n_DisableAddressOfExpressionRequirementOnOutArguments, bool n_DisableForcingFinalizeAsDestructor, bool n_ForceNormalVirtualFunctionCallsOnConstructorsBody, bool n_DisableVirtualizationOfMembers, bool n_ForceLimitedGotos, bool n_UseRuntimeTypeInformation, bool n_UseRuntimeReflection, bool n_LimitRuntimeReflectionToModuleOnly, bool n_UseResumeExceptionModel, bool n_UseTerminationExceptionModel, XplNodeList n_GarbageCollector){
		p_UseCaseSensitive = true;
		p_SetDefaultSafeArrays = "";
		p_DisableArrayLimitsChecks = false;
		p_UseSinglePointAsNamespaceSeparator = false;
		p_UseSimpleMemberAccessAsNamespaceSeparator = false;
		p_UseInheritsAsImplements = false;
		p_SetDefaultIdentifiersNamespace = "";
		p_SetDefaultGarbageCollector = "";
		p_UseSingleInheritance = true;
		p_UseUniversalObjectBase = true;
		p_SetUniversalObjectBase = "";
		p_DisableUnifiedTypeSystem = false;
		p_EnableIntegerOverflowExceptions = false;
		p_EnableFloatOperationsExceptions = false;
		p_RequiereFullDecimalImplementation = false;
		p_RequireASCIIChar = false;
		p_RequireASCIIString = false;
		p_SetASCIIStringClass = "";
		p_SetStringClass = "";
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
	public XplLayerDZoeProgramRequirements(bool n_UseCaseSensitive, string n_SetDefaultSafeArrays, bool n_DisableArrayLimitsChecks, bool n_UseSinglePointAsNamespaceSeparator, bool n_UseSimpleMemberAccessAsNamespaceSeparator, bool n_UseInheritsAsImplements, string n_SetDefaultIdentifiersNamespace, string n_SetDefaultGarbageCollector, bool n_UseSingleInheritance, bool n_UseUniversalObjectBase, string n_SetUniversalObjectBase, bool n_DisableUnifiedTypeSystem, bool n_EnableIntegerOverflowExceptions, bool n_EnableFloatOperationsExceptions, bool n_RequiereFullDecimalImplementation, bool n_RequireASCIIChar, bool n_RequireASCIIString, string n_SetASCIIStringClass, string n_SetStringClass, bool n_DisableNullReferenceCheckOnMemberAccess, bool n_RequirePointerArithmetics, bool n_DisableUnsafePointerConversionsFromVoid, bool n_DisableAllPointerConversionsFromVoid, bool n_DisableAllPointerConversionsToVoid, bool n_DisableAllPointerConversionsFromIntegers, bool n_DisableAllPointerConversionsToIntegers, int n_SetNullIntegerValue, bool n_DisableBaseTypesArrayItemsInitialization, bool n_DisableStaticsVarsInitialization, bool n_DisableInstanceVarsInitialization, bool n_EnableLocalsVarsInitialization, bool n_IgnorePreviousAssingmentRules, bool n_EnablePointerAssingnationWarningsAsErrors, bool n_DisablePointerAssingnationWarnings, bool n_DisableAddressOfExpressionRequirementOnOutArguments, bool n_DisableForcingFinalizeAsDestructor, bool n_ForceNormalVirtualFunctionCallsOnConstructorsBody, bool n_DisableVirtualizationOfMembers, bool n_ForceLimitedGotos, bool n_UseRuntimeTypeInformation, bool n_UseRuntimeReflection, bool n_LimitRuntimeReflectionToModuleOnly, bool n_UseResumeExceptionModel, bool n_UseTerminationExceptionModel, XplNodeList n_GarbageCollector){
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
/*	public ~XplLayerDZoeProgramRequirements(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplLayerDZoeProgramRequirements copy = new XplLayerDZoeProgramRequirements();
		copy.set_UseCaseSensitive(this.p_UseCaseSensitive);
		copy.set_SetDefaultSafeArrays(this.p_SetDefaultSafeArrays);
		copy.set_DisableArrayLimitsChecks(this.p_DisableArrayLimitsChecks);
		copy.set_UseSinglePointAsNamespaceSeparator(this.p_UseSinglePointAsNamespaceSeparator);
		copy.set_UseSimpleMemberAccessAsNamespaceSeparator(this.p_UseSimpleMemberAccessAsNamespaceSeparator);
		copy.set_UseInheritsAsImplements(this.p_UseInheritsAsImplements);
		copy.set_SetDefaultIdentifiersNamespace(this.p_SetDefaultIdentifiersNamespace);
		copy.set_SetDefaultGarbageCollector(this.p_SetDefaultGarbageCollector);
		copy.set_UseSingleInheritance(this.p_UseSingleInheritance);
		copy.set_UseUniversalObjectBase(this.p_UseUniversalObjectBase);
		copy.set_SetUniversalObjectBase(this.p_SetUniversalObjectBase);
		copy.set_DisableUnifiedTypeSystem(this.p_DisableUnifiedTypeSystem);
		copy.set_EnableIntegerOverflowExceptions(this.p_EnableIntegerOverflowExceptions);
		copy.set_EnableFloatOperationsExceptions(this.p_EnableFloatOperationsExceptions);
		copy.set_RequiereFullDecimalImplementation(this.p_RequiereFullDecimalImplementation);
		copy.set_RequireASCIIChar(this.p_RequireASCIIChar);
		copy.set_RequireASCIIString(this.p_RequireASCIIString);
		copy.set_SetASCIIStringClass(this.p_SetASCIIStringClass);
		copy.set_SetStringClass(this.p_SetStringClass);
		copy.set_DisableNullReferenceCheckOnMemberAccess(this.p_DisableNullReferenceCheckOnMemberAccess);
		copy.set_RequirePointerArithmetics(this.p_RequirePointerArithmetics);
		copy.set_DisableUnsafePointerConversionsFromVoid(this.p_DisableUnsafePointerConversionsFromVoid);
		copy.set_DisableAllPointerConversionsFromVoid(this.p_DisableAllPointerConversionsFromVoid);
		copy.set_DisableAllPointerConversionsToVoid(this.p_DisableAllPointerConversionsToVoid);
		copy.set_DisableAllPointerConversionsFromIntegers(this.p_DisableAllPointerConversionsFromIntegers);
		copy.set_DisableAllPointerConversionsToIntegers(this.p_DisableAllPointerConversionsToIntegers);
		copy.set_SetNullIntegerValue(this.p_SetNullIntegerValue);
		copy.set_DisableBaseTypesArrayItemsInitialization(this.p_DisableBaseTypesArrayItemsInitialization);
		copy.set_DisableStaticsVarsInitialization(this.p_DisableStaticsVarsInitialization);
		copy.set_DisableInstanceVarsInitialization(this.p_DisableInstanceVarsInitialization);
		copy.set_EnableLocalsVarsInitialization(this.p_EnableLocalsVarsInitialization);
		copy.set_IgnorePreviousAssingmentRules(this.p_IgnorePreviousAssingmentRules);
		copy.set_EnablePointerAssingnationWarningsAsErrors(this.p_EnablePointerAssingnationWarningsAsErrors);
		copy.set_DisablePointerAssingnationWarnings(this.p_DisablePointerAssingnationWarnings);
		copy.set_DisableAddressOfExpressionRequirementOnOutArguments(this.p_DisableAddressOfExpressionRequirementOnOutArguments);
		copy.set_DisableForcingFinalizeAsDestructor(this.p_DisableForcingFinalizeAsDestructor);
		copy.set_ForceNormalVirtualFunctionCallsOnConstructorsBody(this.p_ForceNormalVirtualFunctionCallsOnConstructorsBody);
		copy.set_DisableVirtualizationOfMembers(this.p_DisableVirtualizationOfMembers);
		copy.set_ForceLimitedGotos(this.p_ForceLimitedGotos);
		copy.set_UseRuntimeTypeInformation(this.p_UseRuntimeTypeInformation);
		copy.set_UseRuntimeReflection(this.p_UseRuntimeReflection);
		copy.set_LimitRuntimeReflectionToModuleOnly(this.p_LimitRuntimeReflectionToModuleOnly);
		copy.set_UseResumeExceptionModel(this.p_UseResumeExceptionModel);
		copy.set_UseTerminationExceptionModel(this.p_UseTerminationExceptionModel);
		for(XplNode node = p_GarbageCollector.FirstNode(); node != null ; node = p_GarbageCollector.NextNode()){
			copy.get_GarbageCollector().InsertAtEnd(node.Clone());
		}
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplLayerDZoeProgramRequirements;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_UseCaseSensitive != true)
			writer.WriteAttributeString( "UseCaseSensitive" ,ZoeHelper .Att_ToString(p_UseCaseSensitive) );
		if(p_SetDefaultSafeArrays != "")
			writer.WriteAttributeString( "SetDefaultSafeArrays" ,ZoeHelper .Att_ToString(p_SetDefaultSafeArrays) );
		if(p_DisableArrayLimitsChecks != false)
			writer.WriteAttributeString( "DisableArrayLimitsChecks" ,ZoeHelper .Att_ToString(p_DisableArrayLimitsChecks) );
		if(p_UseSinglePointAsNamespaceSeparator != false)
			writer.WriteAttributeString( "UseSinglePointAsNamespaceSeparator" ,ZoeHelper .Att_ToString(p_UseSinglePointAsNamespaceSeparator) );
		if(p_UseSimpleMemberAccessAsNamespaceSeparator != false)
			writer.WriteAttributeString( "UseSimpleMemberAccessAsNamespaceSeparator" ,ZoeHelper .Att_ToString(p_UseSimpleMemberAccessAsNamespaceSeparator) );
		if(p_UseInheritsAsImplements != false)
			writer.WriteAttributeString( "UseInheritsAsImplements" ,ZoeHelper .Att_ToString(p_UseInheritsAsImplements) );
		if(p_SetDefaultIdentifiersNamespace != "")
			writer.WriteAttributeString( "SetDefaultIdentifiersNamespace" ,ZoeHelper .Att_ToString(p_SetDefaultIdentifiersNamespace) );
		if(p_SetDefaultGarbageCollector != "")
			writer.WriteAttributeString( "SetDefaultGarbageCollector" ,ZoeHelper .Att_ToString(p_SetDefaultGarbageCollector) );
		if(p_UseSingleInheritance != true)
			writer.WriteAttributeString( "UseSingleInheritance" ,ZoeHelper .Att_ToString(p_UseSingleInheritance) );
		if(p_UseUniversalObjectBase != true)
			writer.WriteAttributeString( "UseUniversalObjectBase" ,ZoeHelper .Att_ToString(p_UseUniversalObjectBase) );
		if(p_SetUniversalObjectBase != "")
			writer.WriteAttributeString( "SetUniversalObjectBase" ,ZoeHelper .Att_ToString(p_SetUniversalObjectBase) );
		if(p_DisableUnifiedTypeSystem != false)
			writer.WriteAttributeString( "DisableUnifiedTypeSystem" ,ZoeHelper .Att_ToString(p_DisableUnifiedTypeSystem) );
		if(p_EnableIntegerOverflowExceptions != false)
			writer.WriteAttributeString( "EnableIntegerOverflowExceptions" ,ZoeHelper .Att_ToString(p_EnableIntegerOverflowExceptions) );
		if(p_EnableFloatOperationsExceptions != false)
			writer.WriteAttributeString( "EnableFloatOperationsExceptions" ,ZoeHelper .Att_ToString(p_EnableFloatOperationsExceptions) );
		if(p_RequiereFullDecimalImplementation != false)
			writer.WriteAttributeString( "RequiereFullDecimalImplementation" ,ZoeHelper .Att_ToString(p_RequiereFullDecimalImplementation) );
		if(p_RequireASCIIChar != false)
			writer.WriteAttributeString( "RequireASCIIChar" ,ZoeHelper .Att_ToString(p_RequireASCIIChar) );
		if(p_RequireASCIIString != false)
			writer.WriteAttributeString( "RequireASCIIString" ,ZoeHelper .Att_ToString(p_RequireASCIIString) );
		if(p_SetASCIIStringClass != "")
			writer.WriteAttributeString( "SetASCIIStringClass" ,ZoeHelper .Att_ToString(p_SetASCIIStringClass) );
		if(p_SetStringClass != "")
			writer.WriteAttributeString( "SetStringClass" ,ZoeHelper .Att_ToString(p_SetStringClass) );
		if(p_DisableNullReferenceCheckOnMemberAccess != false)
			writer.WriteAttributeString( "DisableNullReferenceCheckOnMemberAccess" ,ZoeHelper .Att_ToString(p_DisableNullReferenceCheckOnMemberAccess) );
		if(p_RequirePointerArithmetics != false)
			writer.WriteAttributeString( "RequirePointerArithmetics" ,ZoeHelper .Att_ToString(p_RequirePointerArithmetics) );
		if(p_DisableUnsafePointerConversionsFromVoid != false)
			writer.WriteAttributeString( "DisableUnsafePointerConversionsFromVoid" ,ZoeHelper .Att_ToString(p_DisableUnsafePointerConversionsFromVoid) );
		if(p_DisableAllPointerConversionsFromVoid != false)
			writer.WriteAttributeString( "DisableAllPointerConversionsFromVoid" ,ZoeHelper .Att_ToString(p_DisableAllPointerConversionsFromVoid) );
		if(p_DisableAllPointerConversionsToVoid != false)
			writer.WriteAttributeString( "DisableAllPointerConversionsToVoid" ,ZoeHelper .Att_ToString(p_DisableAllPointerConversionsToVoid) );
		if(p_DisableAllPointerConversionsFromIntegers != false)
			writer.WriteAttributeString( "DisableAllPointerConversionsFromIntegers" ,ZoeHelper .Att_ToString(p_DisableAllPointerConversionsFromIntegers) );
		if(p_DisableAllPointerConversionsToIntegers != false)
			writer.WriteAttributeString( "DisableAllPointerConversionsToIntegers" ,ZoeHelper .Att_ToString(p_DisableAllPointerConversionsToIntegers) );
		if(p_SetNullIntegerValue != 0)
			writer.WriteAttributeString( "SetNullIntegerValue" ,ZoeHelper .Att_ToString(p_SetNullIntegerValue) );
		if(p_DisableBaseTypesArrayItemsInitialization != false)
			writer.WriteAttributeString( "DisableBaseTypesArrayItemsInitialization" ,ZoeHelper .Att_ToString(p_DisableBaseTypesArrayItemsInitialization) );
		if(p_DisableStaticsVarsInitialization != false)
			writer.WriteAttributeString( "DisableStaticsVarsInitialization" ,ZoeHelper .Att_ToString(p_DisableStaticsVarsInitialization) );
		if(p_DisableInstanceVarsInitialization != false)
			writer.WriteAttributeString( "DisableInstanceVarsInitialization" ,ZoeHelper .Att_ToString(p_DisableInstanceVarsInitialization) );
		if(p_EnableLocalsVarsInitialization != false)
			writer.WriteAttributeString( "EnableLocalsVarsInitialization" ,ZoeHelper .Att_ToString(p_EnableLocalsVarsInitialization) );
		if(p_IgnorePreviousAssingmentRules != false)
			writer.WriteAttributeString( "IgnorePreviousAssingmentRules" ,ZoeHelper .Att_ToString(p_IgnorePreviousAssingmentRules) );
		if(p_EnablePointerAssingnationWarningsAsErrors != false)
			writer.WriteAttributeString( "EnablePointerAssingnationWarningsAsErrors" ,ZoeHelper .Att_ToString(p_EnablePointerAssingnationWarningsAsErrors) );
		if(p_DisablePointerAssingnationWarnings != false)
			writer.WriteAttributeString( "DisablePointerAssingnationWarnings" ,ZoeHelper .Att_ToString(p_DisablePointerAssingnationWarnings) );
		if(p_DisableAddressOfExpressionRequirementOnOutArguments != false)
			writer.WriteAttributeString( "DisableAddressOfExpressionRequirementOnOutArguments" ,ZoeHelper .Att_ToString(p_DisableAddressOfExpressionRequirementOnOutArguments) );
		if(p_DisableForcingFinalizeAsDestructor != false)
			writer.WriteAttributeString( "DisableForcingFinalizeAsDestructor" ,ZoeHelper .Att_ToString(p_DisableForcingFinalizeAsDestructor) );
		if(p_ForceNormalVirtualFunctionCallsOnConstructorsBody != false)
			writer.WriteAttributeString( "ForceNormalVirtualFunctionCallsOnConstructorsBody" ,ZoeHelper .Att_ToString(p_ForceNormalVirtualFunctionCallsOnConstructorsBody) );
		if(p_DisableVirtualizationOfMembers != false)
			writer.WriteAttributeString( "DisableVirtualizationOfMembers" ,ZoeHelper .Att_ToString(p_DisableVirtualizationOfMembers) );
		if(p_ForceLimitedGotos != false)
			writer.WriteAttributeString( "ForceLimitedGotos" ,ZoeHelper .Att_ToString(p_ForceLimitedGotos) );
		if(p_UseRuntimeTypeInformation != true)
			writer.WriteAttributeString( "UseRuntimeTypeInformation" ,ZoeHelper .Att_ToString(p_UseRuntimeTypeInformation) );
		if(p_UseRuntimeReflection != false)
			writer.WriteAttributeString( "UseRuntimeReflection" ,ZoeHelper .Att_ToString(p_UseRuntimeReflection) );
		if(p_LimitRuntimeReflectionToModuleOnly != false)
			writer.WriteAttributeString( "LimitRuntimeReflectionToModuleOnly" ,ZoeHelper .Att_ToString(p_LimitRuntimeReflectionToModuleOnly) );
		if(p_UseResumeExceptionModel != false)
			writer.WriteAttributeString( "UseResumeExceptionModel" ,ZoeHelper .Att_ToString(p_UseResumeExceptionModel) );
		if(p_UseTerminationExceptionModel != true)
			writer.WriteAttributeString( "UseTerminationExceptionModel" ,ZoeHelper .Att_ToString(p_UseTerminationExceptionModel) );
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
					case "UseCaseSensitive":
						this.set_UseCaseSensitive(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "SetDefaultSafeArrays":
						this.set_SetDefaultSafeArrays(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "DisableArrayLimitsChecks":
						this.set_DisableArrayLimitsChecks(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "UseSinglePointAsNamespaceSeparator":
						this.set_UseSinglePointAsNamespaceSeparator(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "UseSimpleMemberAccessAsNamespaceSeparator":
						this.set_UseSimpleMemberAccessAsNamespaceSeparator(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "UseInheritsAsImplements":
						this.set_UseInheritsAsImplements(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "SetDefaultIdentifiersNamespace":
						this.set_SetDefaultIdentifiersNamespace(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "SetDefaultGarbageCollector":
						this.set_SetDefaultGarbageCollector(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "UseSingleInheritance":
						this.set_UseSingleInheritance(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "UseUniversalObjectBase":
						this.set_UseUniversalObjectBase(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "SetUniversalObjectBase":
						this.set_SetUniversalObjectBase(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "DisableUnifiedTypeSystem":
						this.set_DisableUnifiedTypeSystem(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "EnableIntegerOverflowExceptions":
						this.set_EnableIntegerOverflowExceptions(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "EnableFloatOperationsExceptions":
						this.set_EnableFloatOperationsExceptions(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "RequiereFullDecimalImplementation":
						this.set_RequiereFullDecimalImplementation(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "RequireASCIIChar":
						this.set_RequireASCIIChar(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "RequireASCIIString":
						this.set_RequireASCIIString(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "SetASCIIStringClass":
						this.set_SetASCIIStringClass(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "SetStringClass":
						this.set_SetStringClass(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "DisableNullReferenceCheckOnMemberAccess":
						this.set_DisableNullReferenceCheckOnMemberAccess(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "RequirePointerArithmetics":
						this.set_RequirePointerArithmetics(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "DisableUnsafePointerConversionsFromVoid":
						this.set_DisableUnsafePointerConversionsFromVoid(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "DisableAllPointerConversionsFromVoid":
						this.set_DisableAllPointerConversionsFromVoid(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "DisableAllPointerConversionsToVoid":
						this.set_DisableAllPointerConversionsToVoid(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "DisableAllPointerConversionsFromIntegers":
						this.set_DisableAllPointerConversionsFromIntegers(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "DisableAllPointerConversionsToIntegers":
						this.set_DisableAllPointerConversionsToIntegers(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "SetNullIntegerValue":
						this.set_SetNullIntegerValue(ZoeHelper .StringAtt_To_INT(reader.Value));
						break;
					case "DisableBaseTypesArrayItemsInitialization":
						this.set_DisableBaseTypesArrayItemsInitialization(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "DisableStaticsVarsInitialization":
						this.set_DisableStaticsVarsInitialization(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "DisableInstanceVarsInitialization":
						this.set_DisableInstanceVarsInitialization(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "EnableLocalsVarsInitialization":
						this.set_EnableLocalsVarsInitialization(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "IgnorePreviousAssingmentRules":
						this.set_IgnorePreviousAssingmentRules(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "EnablePointerAssingnationWarningsAsErrors":
						this.set_EnablePointerAssingnationWarningsAsErrors(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "DisablePointerAssingnationWarnings":
						this.set_DisablePointerAssingnationWarnings(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "DisableAddressOfExpressionRequirementOnOutArguments":
						this.set_DisableAddressOfExpressionRequirementOnOutArguments(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "DisableForcingFinalizeAsDestructor":
						this.set_DisableForcingFinalizeAsDestructor(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "ForceNormalVirtualFunctionCallsOnConstructorsBody":
						this.set_ForceNormalVirtualFunctionCallsOnConstructorsBody(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "DisableVirtualizationOfMembers":
						this.set_DisableVirtualizationOfMembers(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "ForceLimitedGotos":
						this.set_ForceLimitedGotos(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "UseRuntimeTypeInformation":
						this.set_UseRuntimeTypeInformation(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "UseRuntimeReflection":
						this.set_UseRuntimeReflection(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "LimitRuntimeReflectionToModuleOnly":
						this.set_LimitRuntimeReflectionToModuleOnly(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "UseResumeExceptionModel":
						this.set_UseResumeExceptionModel(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "UseTerminationExceptionModel":
						this.set_UseTerminationExceptionModel(ZoeHelper .StringAtt_To_BOOL(reader.Value));
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
		writer.Write((int) 163 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_UseCaseSensitive );
		writer.Write( p_SetDefaultSafeArrays );
		writer.Write( p_DisableArrayLimitsChecks );
		writer.Write( p_UseSinglePointAsNamespaceSeparator );
		writer.Write( p_UseSimpleMemberAccessAsNamespaceSeparator );
		writer.Write( p_UseInheritsAsImplements );
		writer.Write( p_SetDefaultIdentifiersNamespace );
		writer.Write( p_SetDefaultGarbageCollector );
		writer.Write( p_UseSingleInheritance );
		writer.Write( p_UseUniversalObjectBase );
		writer.Write( p_SetUniversalObjectBase );
		writer.Write( p_DisableUnifiedTypeSystem );
		writer.Write( p_EnableIntegerOverflowExceptions );
		writer.Write( p_EnableFloatOperationsExceptions );
		writer.Write( p_RequiereFullDecimalImplementation );
		writer.Write( p_RequireASCIIChar );
		writer.Write( p_RequireASCIIString );
		writer.Write( p_SetASCIIStringClass );
		writer.Write( p_SetStringClass );
		writer.Write( p_DisableNullReferenceCheckOnMemberAccess );
		writer.Write( p_RequirePointerArithmetics );
		writer.Write( p_DisableUnsafePointerConversionsFromVoid );
		writer.Write( p_DisableAllPointerConversionsFromVoid );
		writer.Write( p_DisableAllPointerConversionsToVoid );
		writer.Write( p_DisableAllPointerConversionsFromIntegers );
		writer.Write( p_DisableAllPointerConversionsToIntegers );
		writer.Write( p_SetNullIntegerValue );
		writer.Write( p_DisableBaseTypesArrayItemsInitialization );
		writer.Write( p_DisableStaticsVarsInitialization );
		writer.Write( p_DisableInstanceVarsInitialization );
		writer.Write( p_EnableLocalsVarsInitialization );
		writer.Write( p_IgnorePreviousAssingmentRules );
		writer.Write( p_EnablePointerAssingnationWarningsAsErrors );
		writer.Write( p_DisablePointerAssingnationWarnings );
		writer.Write( p_DisableAddressOfExpressionRequirementOnOutArguments );
		writer.Write( p_DisableForcingFinalizeAsDestructor );
		writer.Write( p_ForceNormalVirtualFunctionCallsOnConstructorsBody );
		writer.Write( p_DisableVirtualizationOfMembers );
		writer.Write( p_ForceLimitedGotos );
		writer.Write( p_UseRuntimeTypeInformation );
		writer.Write( p_UseRuntimeReflection );
		writer.Write( p_LimitRuntimeReflectionToModuleOnly );
		writer.Write( p_UseResumeExceptionModel );
		writer.Write( p_UseTerminationExceptionModel );
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
		p_UseCaseSensitive = reader.ReadBoolean();
		p_SetDefaultSafeArrays = reader.ReadString();
		p_DisableArrayLimitsChecks = reader.ReadBoolean();
		p_UseSinglePointAsNamespaceSeparator = reader.ReadBoolean();
		p_UseSimpleMemberAccessAsNamespaceSeparator = reader.ReadBoolean();
		p_UseInheritsAsImplements = reader.ReadBoolean();
		p_SetDefaultIdentifiersNamespace = reader.ReadString();
		p_SetDefaultGarbageCollector = reader.ReadString();
		p_UseSingleInheritance = reader.ReadBoolean();
		p_UseUniversalObjectBase = reader.ReadBoolean();
		p_SetUniversalObjectBase = reader.ReadString();
		p_DisableUnifiedTypeSystem = reader.ReadBoolean();
		p_EnableIntegerOverflowExceptions = reader.ReadBoolean();
		p_EnableFloatOperationsExceptions = reader.ReadBoolean();
		p_RequiereFullDecimalImplementation = reader.ReadBoolean();
		p_RequireASCIIChar = reader.ReadBoolean();
		p_RequireASCIIString = reader.ReadBoolean();
		p_SetASCIIStringClass = reader.ReadString();
		p_SetStringClass = reader.ReadString();
		p_DisableNullReferenceCheckOnMemberAccess = reader.ReadBoolean();
		p_RequirePointerArithmetics = reader.ReadBoolean();
		p_DisableUnsafePointerConversionsFromVoid = reader.ReadBoolean();
		p_DisableAllPointerConversionsFromVoid = reader.ReadBoolean();
		p_DisableAllPointerConversionsToVoid = reader.ReadBoolean();
		p_DisableAllPointerConversionsFromIntegers = reader.ReadBoolean();
		p_DisableAllPointerConversionsToIntegers = reader.ReadBoolean();
		p_SetNullIntegerValue = reader.ReadInt32();
		p_DisableBaseTypesArrayItemsInitialization = reader.ReadBoolean();
		p_DisableStaticsVarsInitialization = reader.ReadBoolean();
		p_DisableInstanceVarsInitialization = reader.ReadBoolean();
		p_EnableLocalsVarsInitialization = reader.ReadBoolean();
		p_IgnorePreviousAssingmentRules = reader.ReadBoolean();
		p_EnablePointerAssingnationWarningsAsErrors = reader.ReadBoolean();
		p_DisablePointerAssingnationWarnings = reader.ReadBoolean();
		p_DisableAddressOfExpressionRequirementOnOutArguments = reader.ReadBoolean();
		p_DisableForcingFinalizeAsDestructor = reader.ReadBoolean();
		p_ForceNormalVirtualFunctionCallsOnConstructorsBody = reader.ReadBoolean();
		p_DisableVirtualizationOfMembers = reader.ReadBoolean();
		p_ForceLimitedGotos = reader.ReadBoolean();
		p_UseRuntimeTypeInformation = reader.ReadBoolean();
		p_UseRuntimeReflection = reader.ReadBoolean();
		p_LimitRuntimeReflectionToModuleOnly = reader.ReadBoolean();
		p_UseResumeExceptionModel = reader.ReadBoolean();
		p_UseTerminationExceptionModel = reader.ReadBoolean();
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
public static XplLayerDZoeProgramRequirements operator +(XplLayerDZoeProgramRequirements arg1, XplNode arg2)
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
public static XplLayerDZoeProgramRequirements operator +(XplLayerDZoeProgramRequirements arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public bool get_UseCaseSensitive(){
		return p_UseCaseSensitive;
	}
	public string get_SetDefaultSafeArrays(){
		return p_SetDefaultSafeArrays;
	}
	public bool get_DisableArrayLimitsChecks(){
		return p_DisableArrayLimitsChecks;
	}
	public bool get_UseSinglePointAsNamespaceSeparator(){
		return p_UseSinglePointAsNamespaceSeparator;
	}
	public bool get_UseSimpleMemberAccessAsNamespaceSeparator(){
		return p_UseSimpleMemberAccessAsNamespaceSeparator;
	}
	public bool get_UseInheritsAsImplements(){
		return p_UseInheritsAsImplements;
	}
	public string get_SetDefaultIdentifiersNamespace(){
		return p_SetDefaultIdentifiersNamespace;
	}
	public string get_SetDefaultGarbageCollector(){
		return p_SetDefaultGarbageCollector;
	}
	public bool get_UseSingleInheritance(){
		return p_UseSingleInheritance;
	}
	public bool get_UseUniversalObjectBase(){
		return p_UseUniversalObjectBase;
	}
	public string get_SetUniversalObjectBase(){
		return p_SetUniversalObjectBase;
	}
	public bool get_DisableUnifiedTypeSystem(){
		return p_DisableUnifiedTypeSystem;
	}
	public bool get_EnableIntegerOverflowExceptions(){
		return p_EnableIntegerOverflowExceptions;
	}
	public bool get_EnableFloatOperationsExceptions(){
		return p_EnableFloatOperationsExceptions;
	}
	public bool get_RequiereFullDecimalImplementation(){
		return p_RequiereFullDecimalImplementation;
	}
	public bool get_RequireASCIIChar(){
		return p_RequireASCIIChar;
	}
	public bool get_RequireASCIIString(){
		return p_RequireASCIIString;
	}
	public string get_SetASCIIStringClass(){
		return p_SetASCIIStringClass;
	}
	public string get_SetStringClass(){
		return p_SetStringClass;
	}
	public bool get_DisableNullReferenceCheckOnMemberAccess(){
		return p_DisableNullReferenceCheckOnMemberAccess;
	}
	public bool get_RequirePointerArithmetics(){
		return p_RequirePointerArithmetics;
	}
	public bool get_DisableUnsafePointerConversionsFromVoid(){
		return p_DisableUnsafePointerConversionsFromVoid;
	}
	public bool get_DisableAllPointerConversionsFromVoid(){
		return p_DisableAllPointerConversionsFromVoid;
	}
	public bool get_DisableAllPointerConversionsToVoid(){
		return p_DisableAllPointerConversionsToVoid;
	}
	public bool get_DisableAllPointerConversionsFromIntegers(){
		return p_DisableAllPointerConversionsFromIntegers;
	}
	public bool get_DisableAllPointerConversionsToIntegers(){
		return p_DisableAllPointerConversionsToIntegers;
	}
	public int get_SetNullIntegerValue(){
		return p_SetNullIntegerValue;
	}
	public bool get_DisableBaseTypesArrayItemsInitialization(){
		return p_DisableBaseTypesArrayItemsInitialization;
	}
	public bool get_DisableStaticsVarsInitialization(){
		return p_DisableStaticsVarsInitialization;
	}
	public bool get_DisableInstanceVarsInitialization(){
		return p_DisableInstanceVarsInitialization;
	}
	public bool get_EnableLocalsVarsInitialization(){
		return p_EnableLocalsVarsInitialization;
	}
	public bool get_IgnorePreviousAssingmentRules(){
		return p_IgnorePreviousAssingmentRules;
	}
	public bool get_EnablePointerAssingnationWarningsAsErrors(){
		return p_EnablePointerAssingnationWarningsAsErrors;
	}
	public bool get_DisablePointerAssingnationWarnings(){
		return p_DisablePointerAssingnationWarnings;
	}
	public bool get_DisableAddressOfExpressionRequirementOnOutArguments(){
		return p_DisableAddressOfExpressionRequirementOnOutArguments;
	}
	public bool get_DisableForcingFinalizeAsDestructor(){
		return p_DisableForcingFinalizeAsDestructor;
	}
	public bool get_ForceNormalVirtualFunctionCallsOnConstructorsBody(){
		return p_ForceNormalVirtualFunctionCallsOnConstructorsBody;
	}
	public bool get_DisableVirtualizationOfMembers(){
		return p_DisableVirtualizationOfMembers;
	}
	public bool get_ForceLimitedGotos(){
		return p_ForceLimitedGotos;
	}
	public bool get_UseRuntimeTypeInformation(){
		return p_UseRuntimeTypeInformation;
	}
	public bool get_UseRuntimeReflection(){
		return p_UseRuntimeReflection;
	}
	public bool get_LimitRuntimeReflectionToModuleOnly(){
		return p_LimitRuntimeReflectionToModuleOnly;
	}
	public bool get_UseResumeExceptionModel(){
		return p_UseResumeExceptionModel;
	}
	public bool get_UseTerminationExceptionModel(){
		return p_UseTerminationExceptionModel;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplNodeList get_GarbageCollector(){
		return p_GarbageCollector;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[44];
		ret[0] = "UseCaseSensitive";
		ret[1] = "SetDefaultSafeArrays";
		ret[2] = "DisableArrayLimitsChecks";
		ret[3] = "UseSinglePointAsNamespaceSeparator";
		ret[4] = "UseSimpleMemberAccessAsNamespaceSeparator";
		ret[5] = "UseInheritsAsImplements";
		ret[6] = "SetDefaultIdentifiersNamespace";
		ret[7] = "SetDefaultGarbageCollector";
		ret[8] = "UseSingleInheritance";
		ret[9] = "UseUniversalObjectBase";
		ret[10] = "SetUniversalObjectBase";
		ret[11] = "DisableUnifiedTypeSystem";
		ret[12] = "EnableIntegerOverflowExceptions";
		ret[13] = "EnableFloatOperationsExceptions";
		ret[14] = "RequiereFullDecimalImplementation";
		ret[15] = "RequireASCIIChar";
		ret[16] = "RequireASCIIString";
		ret[17] = "SetASCIIStringClass";
		ret[18] = "SetStringClass";
		ret[19] = "DisableNullReferenceCheckOnMemberAccess";
		ret[20] = "RequirePointerArithmetics";
		ret[21] = "DisableUnsafePointerConversionsFromVoid";
		ret[22] = "DisableAllPointerConversionsFromVoid";
		ret[23] = "DisableAllPointerConversionsToVoid";
		ret[24] = "DisableAllPointerConversionsFromIntegers";
		ret[25] = "DisableAllPointerConversionsToIntegers";
		ret[26] = "SetNullIntegerValue";
		ret[27] = "DisableBaseTypesArrayItemsInitialization";
		ret[28] = "DisableStaticsVarsInitialization";
		ret[29] = "DisableInstanceVarsInitialization";
		ret[30] = "EnableLocalsVarsInitialization";
		ret[31] = "IgnorePreviousAssingmentRules";
		ret[32] = "EnablePointerAssingnationWarningsAsErrors";
		ret[33] = "DisablePointerAssingnationWarnings";
		ret[34] = "DisableAddressOfExpressionRequirementOnOutArguments";
		ret[35] = "DisableForcingFinalizeAsDestructor";
		ret[36] = "ForceNormalVirtualFunctionCallsOnConstructorsBody";
		ret[37] = "DisableVirtualizationOfMembers";
		ret[38] = "ForceLimitedGotos";
		ret[39] = "UseRuntimeTypeInformation";
		ret[40] = "UseRuntimeReflection";
		ret[41] = "LimitRuntimeReflectionToModuleOnly";
		ret[42] = "UseResumeExceptionModel";
		ret[43] = "UseTerminationExceptionModel";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="UseCaseSensitive") return p_UseCaseSensitive.ToString();
		if (attributeName=="SetDefaultSafeArrays") return p_SetDefaultSafeArrays.ToString();
		if (attributeName=="DisableArrayLimitsChecks") return p_DisableArrayLimitsChecks.ToString();
		if (attributeName=="UseSinglePointAsNamespaceSeparator") return p_UseSinglePointAsNamespaceSeparator.ToString();
		if (attributeName=="UseSimpleMemberAccessAsNamespaceSeparator") return p_UseSimpleMemberAccessAsNamespaceSeparator.ToString();
		if (attributeName=="UseInheritsAsImplements") return p_UseInheritsAsImplements.ToString();
		if (attributeName=="SetDefaultIdentifiersNamespace") return p_SetDefaultIdentifiersNamespace.ToString();
		if (attributeName=="SetDefaultGarbageCollector") return p_SetDefaultGarbageCollector.ToString();
		if (attributeName=="UseSingleInheritance") return p_UseSingleInheritance.ToString();
		if (attributeName=="UseUniversalObjectBase") return p_UseUniversalObjectBase.ToString();
		if (attributeName=="SetUniversalObjectBase") return p_SetUniversalObjectBase.ToString();
		if (attributeName=="DisableUnifiedTypeSystem") return p_DisableUnifiedTypeSystem.ToString();
		if (attributeName=="EnableIntegerOverflowExceptions") return p_EnableIntegerOverflowExceptions.ToString();
		if (attributeName=="EnableFloatOperationsExceptions") return p_EnableFloatOperationsExceptions.ToString();
		if (attributeName=="RequiereFullDecimalImplementation") return p_RequiereFullDecimalImplementation.ToString();
		if (attributeName=="RequireASCIIChar") return p_RequireASCIIChar.ToString();
		if (attributeName=="RequireASCIIString") return p_RequireASCIIString.ToString();
		if (attributeName=="SetASCIIStringClass") return p_SetASCIIStringClass.ToString();
		if (attributeName=="SetStringClass") return p_SetStringClass.ToString();
		if (attributeName=="DisableNullReferenceCheckOnMemberAccess") return p_DisableNullReferenceCheckOnMemberAccess.ToString();
		if (attributeName=="RequirePointerArithmetics") return p_RequirePointerArithmetics.ToString();
		if (attributeName=="DisableUnsafePointerConversionsFromVoid") return p_DisableUnsafePointerConversionsFromVoid.ToString();
		if (attributeName=="DisableAllPointerConversionsFromVoid") return p_DisableAllPointerConversionsFromVoid.ToString();
		if (attributeName=="DisableAllPointerConversionsToVoid") return p_DisableAllPointerConversionsToVoid.ToString();
		if (attributeName=="DisableAllPointerConversionsFromIntegers") return p_DisableAllPointerConversionsFromIntegers.ToString();
		if (attributeName=="DisableAllPointerConversionsToIntegers") return p_DisableAllPointerConversionsToIntegers.ToString();
		if (attributeName=="SetNullIntegerValue") return p_SetNullIntegerValue.ToString();
		if (attributeName=="DisableBaseTypesArrayItemsInitialization") return p_DisableBaseTypesArrayItemsInitialization.ToString();
		if (attributeName=="DisableStaticsVarsInitialization") return p_DisableStaticsVarsInitialization.ToString();
		if (attributeName=="DisableInstanceVarsInitialization") return p_DisableInstanceVarsInitialization.ToString();
		if (attributeName=="EnableLocalsVarsInitialization") return p_EnableLocalsVarsInitialization.ToString();
		if (attributeName=="IgnorePreviousAssingmentRules") return p_IgnorePreviousAssingmentRules.ToString();
		if (attributeName=="EnablePointerAssingnationWarningsAsErrors") return p_EnablePointerAssingnationWarningsAsErrors.ToString();
		if (attributeName=="DisablePointerAssingnationWarnings") return p_DisablePointerAssingnationWarnings.ToString();
		if (attributeName=="DisableAddressOfExpressionRequirementOnOutArguments") return p_DisableAddressOfExpressionRequirementOnOutArguments.ToString();
		if (attributeName=="DisableForcingFinalizeAsDestructor") return p_DisableForcingFinalizeAsDestructor.ToString();
		if (attributeName=="ForceNormalVirtualFunctionCallsOnConstructorsBody") return p_ForceNormalVirtualFunctionCallsOnConstructorsBody.ToString();
		if (attributeName=="DisableVirtualizationOfMembers") return p_DisableVirtualizationOfMembers.ToString();
		if (attributeName=="ForceLimitedGotos") return p_ForceLimitedGotos.ToString();
		if (attributeName=="UseRuntimeTypeInformation") return p_UseRuntimeTypeInformation.ToString();
		if (attributeName=="UseRuntimeReflection") return p_UseRuntimeReflection.ToString();
		if (attributeName=="LimitRuntimeReflectionToModuleOnly") return p_LimitRuntimeReflectionToModuleOnly.ToString();
		if (attributeName=="UseResumeExceptionModel") return p_UseResumeExceptionModel.ToString();
		if (attributeName=="UseTerminationExceptionModel") return p_UseTerminationExceptionModel.ToString();
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
	public bool set_UseCaseSensitive(bool new_UseCaseSensitive){
		bool back_UseCaseSensitive = p_UseCaseSensitive;
		p_UseCaseSensitive = new_UseCaseSensitive;
		return back_UseCaseSensitive;
	}
	public string set_SetDefaultSafeArrays(string new_SetDefaultSafeArrays){
		string back_SetDefaultSafeArrays = p_SetDefaultSafeArrays;
		p_SetDefaultSafeArrays = new_SetDefaultSafeArrays;
		return back_SetDefaultSafeArrays;
	}
	public bool set_DisableArrayLimitsChecks(bool new_DisableArrayLimitsChecks){
		bool back_DisableArrayLimitsChecks = p_DisableArrayLimitsChecks;
		p_DisableArrayLimitsChecks = new_DisableArrayLimitsChecks;
		return back_DisableArrayLimitsChecks;
	}
	public bool set_UseSinglePointAsNamespaceSeparator(bool new_UseSinglePointAsNamespaceSeparator){
		bool back_UseSinglePointAsNamespaceSeparator = p_UseSinglePointAsNamespaceSeparator;
		p_UseSinglePointAsNamespaceSeparator = new_UseSinglePointAsNamespaceSeparator;
		return back_UseSinglePointAsNamespaceSeparator;
	}
	public bool set_UseSimpleMemberAccessAsNamespaceSeparator(bool new_UseSimpleMemberAccessAsNamespaceSeparator){
		bool back_UseSimpleMemberAccessAsNamespaceSeparator = p_UseSimpleMemberAccessAsNamespaceSeparator;
		p_UseSimpleMemberAccessAsNamespaceSeparator = new_UseSimpleMemberAccessAsNamespaceSeparator;
		return back_UseSimpleMemberAccessAsNamespaceSeparator;
	}
	public bool set_UseInheritsAsImplements(bool new_UseInheritsAsImplements){
		bool back_UseInheritsAsImplements = p_UseInheritsAsImplements;
		p_UseInheritsAsImplements = new_UseInheritsAsImplements;
		return back_UseInheritsAsImplements;
	}
	public string set_SetDefaultIdentifiersNamespace(string new_SetDefaultIdentifiersNamespace){
		string back_SetDefaultIdentifiersNamespace = p_SetDefaultIdentifiersNamespace;
		p_SetDefaultIdentifiersNamespace = new_SetDefaultIdentifiersNamespace;
		return back_SetDefaultIdentifiersNamespace;
	}
	public string set_SetDefaultGarbageCollector(string new_SetDefaultGarbageCollector){
		string back_SetDefaultGarbageCollector = p_SetDefaultGarbageCollector;
		p_SetDefaultGarbageCollector = new_SetDefaultGarbageCollector;
		return back_SetDefaultGarbageCollector;
	}
	public bool set_UseSingleInheritance(bool new_UseSingleInheritance){
		bool back_UseSingleInheritance = p_UseSingleInheritance;
		p_UseSingleInheritance = new_UseSingleInheritance;
		return back_UseSingleInheritance;
	}
	public bool set_UseUniversalObjectBase(bool new_UseUniversalObjectBase){
		bool back_UseUniversalObjectBase = p_UseUniversalObjectBase;
		p_UseUniversalObjectBase = new_UseUniversalObjectBase;
		return back_UseUniversalObjectBase;
	}
	public string set_SetUniversalObjectBase(string new_SetUniversalObjectBase){
		string back_SetUniversalObjectBase = p_SetUniversalObjectBase;
		p_SetUniversalObjectBase = new_SetUniversalObjectBase;
		return back_SetUniversalObjectBase;
	}
	public bool set_DisableUnifiedTypeSystem(bool new_DisableUnifiedTypeSystem){
		bool back_DisableUnifiedTypeSystem = p_DisableUnifiedTypeSystem;
		p_DisableUnifiedTypeSystem = new_DisableUnifiedTypeSystem;
		return back_DisableUnifiedTypeSystem;
	}
	public bool set_EnableIntegerOverflowExceptions(bool new_EnableIntegerOverflowExceptions){
		bool back_EnableIntegerOverflowExceptions = p_EnableIntegerOverflowExceptions;
		p_EnableIntegerOverflowExceptions = new_EnableIntegerOverflowExceptions;
		return back_EnableIntegerOverflowExceptions;
	}
	public bool set_EnableFloatOperationsExceptions(bool new_EnableFloatOperationsExceptions){
		bool back_EnableFloatOperationsExceptions = p_EnableFloatOperationsExceptions;
		p_EnableFloatOperationsExceptions = new_EnableFloatOperationsExceptions;
		return back_EnableFloatOperationsExceptions;
	}
	public bool set_RequiereFullDecimalImplementation(bool new_RequiereFullDecimalImplementation){
		bool back_RequiereFullDecimalImplementation = p_RequiereFullDecimalImplementation;
		p_RequiereFullDecimalImplementation = new_RequiereFullDecimalImplementation;
		return back_RequiereFullDecimalImplementation;
	}
	public bool set_RequireASCIIChar(bool new_RequireASCIIChar){
		bool back_RequireASCIIChar = p_RequireASCIIChar;
		p_RequireASCIIChar = new_RequireASCIIChar;
		return back_RequireASCIIChar;
	}
	public bool set_RequireASCIIString(bool new_RequireASCIIString){
		bool back_RequireASCIIString = p_RequireASCIIString;
		p_RequireASCIIString = new_RequireASCIIString;
		return back_RequireASCIIString;
	}
	public string set_SetASCIIStringClass(string new_SetASCIIStringClass){
		string back_SetASCIIStringClass = p_SetASCIIStringClass;
		p_SetASCIIStringClass = new_SetASCIIStringClass;
		return back_SetASCIIStringClass;
	}
	public string set_SetStringClass(string new_SetStringClass){
		string back_SetStringClass = p_SetStringClass;
		p_SetStringClass = new_SetStringClass;
		return back_SetStringClass;
	}
	public bool set_DisableNullReferenceCheckOnMemberAccess(bool new_DisableNullReferenceCheckOnMemberAccess){
		bool back_DisableNullReferenceCheckOnMemberAccess = p_DisableNullReferenceCheckOnMemberAccess;
		p_DisableNullReferenceCheckOnMemberAccess = new_DisableNullReferenceCheckOnMemberAccess;
		return back_DisableNullReferenceCheckOnMemberAccess;
	}
	public bool set_RequirePointerArithmetics(bool new_RequirePointerArithmetics){
		bool back_RequirePointerArithmetics = p_RequirePointerArithmetics;
		p_RequirePointerArithmetics = new_RequirePointerArithmetics;
		return back_RequirePointerArithmetics;
	}
	public bool set_DisableUnsafePointerConversionsFromVoid(bool new_DisableUnsafePointerConversionsFromVoid){
		bool back_DisableUnsafePointerConversionsFromVoid = p_DisableUnsafePointerConversionsFromVoid;
		p_DisableUnsafePointerConversionsFromVoid = new_DisableUnsafePointerConversionsFromVoid;
		return back_DisableUnsafePointerConversionsFromVoid;
	}
	public bool set_DisableAllPointerConversionsFromVoid(bool new_DisableAllPointerConversionsFromVoid){
		bool back_DisableAllPointerConversionsFromVoid = p_DisableAllPointerConversionsFromVoid;
		p_DisableAllPointerConversionsFromVoid = new_DisableAllPointerConversionsFromVoid;
		return back_DisableAllPointerConversionsFromVoid;
	}
	public bool set_DisableAllPointerConversionsToVoid(bool new_DisableAllPointerConversionsToVoid){
		bool back_DisableAllPointerConversionsToVoid = p_DisableAllPointerConversionsToVoid;
		p_DisableAllPointerConversionsToVoid = new_DisableAllPointerConversionsToVoid;
		return back_DisableAllPointerConversionsToVoid;
	}
	public bool set_DisableAllPointerConversionsFromIntegers(bool new_DisableAllPointerConversionsFromIntegers){
		bool back_DisableAllPointerConversionsFromIntegers = p_DisableAllPointerConversionsFromIntegers;
		p_DisableAllPointerConversionsFromIntegers = new_DisableAllPointerConversionsFromIntegers;
		return back_DisableAllPointerConversionsFromIntegers;
	}
	public bool set_DisableAllPointerConversionsToIntegers(bool new_DisableAllPointerConversionsToIntegers){
		bool back_DisableAllPointerConversionsToIntegers = p_DisableAllPointerConversionsToIntegers;
		p_DisableAllPointerConversionsToIntegers = new_DisableAllPointerConversionsToIntegers;
		return back_DisableAllPointerConversionsToIntegers;
	}
	public int set_SetNullIntegerValue(int new_SetNullIntegerValue){
		int back_SetNullIntegerValue = p_SetNullIntegerValue;
		p_SetNullIntegerValue = new_SetNullIntegerValue;
		return back_SetNullIntegerValue;
	}
	public bool set_DisableBaseTypesArrayItemsInitialization(bool new_DisableBaseTypesArrayItemsInitialization){
		bool back_DisableBaseTypesArrayItemsInitialization = p_DisableBaseTypesArrayItemsInitialization;
		p_DisableBaseTypesArrayItemsInitialization = new_DisableBaseTypesArrayItemsInitialization;
		return back_DisableBaseTypesArrayItemsInitialization;
	}
	public bool set_DisableStaticsVarsInitialization(bool new_DisableStaticsVarsInitialization){
		bool back_DisableStaticsVarsInitialization = p_DisableStaticsVarsInitialization;
		p_DisableStaticsVarsInitialization = new_DisableStaticsVarsInitialization;
		return back_DisableStaticsVarsInitialization;
	}
	public bool set_DisableInstanceVarsInitialization(bool new_DisableInstanceVarsInitialization){
		bool back_DisableInstanceVarsInitialization = p_DisableInstanceVarsInitialization;
		p_DisableInstanceVarsInitialization = new_DisableInstanceVarsInitialization;
		return back_DisableInstanceVarsInitialization;
	}
	public bool set_EnableLocalsVarsInitialization(bool new_EnableLocalsVarsInitialization){
		bool back_EnableLocalsVarsInitialization = p_EnableLocalsVarsInitialization;
		p_EnableLocalsVarsInitialization = new_EnableLocalsVarsInitialization;
		return back_EnableLocalsVarsInitialization;
	}
	public bool set_IgnorePreviousAssingmentRules(bool new_IgnorePreviousAssingmentRules){
		bool back_IgnorePreviousAssingmentRules = p_IgnorePreviousAssingmentRules;
		p_IgnorePreviousAssingmentRules = new_IgnorePreviousAssingmentRules;
		return back_IgnorePreviousAssingmentRules;
	}
	public bool set_EnablePointerAssingnationWarningsAsErrors(bool new_EnablePointerAssingnationWarningsAsErrors){
		bool back_EnablePointerAssingnationWarningsAsErrors = p_EnablePointerAssingnationWarningsAsErrors;
		p_EnablePointerAssingnationWarningsAsErrors = new_EnablePointerAssingnationWarningsAsErrors;
		return back_EnablePointerAssingnationWarningsAsErrors;
	}
	public bool set_DisablePointerAssingnationWarnings(bool new_DisablePointerAssingnationWarnings){
		bool back_DisablePointerAssingnationWarnings = p_DisablePointerAssingnationWarnings;
		p_DisablePointerAssingnationWarnings = new_DisablePointerAssingnationWarnings;
		return back_DisablePointerAssingnationWarnings;
	}
	public bool set_DisableAddressOfExpressionRequirementOnOutArguments(bool new_DisableAddressOfExpressionRequirementOnOutArguments){
		bool back_DisableAddressOfExpressionRequirementOnOutArguments = p_DisableAddressOfExpressionRequirementOnOutArguments;
		p_DisableAddressOfExpressionRequirementOnOutArguments = new_DisableAddressOfExpressionRequirementOnOutArguments;
		return back_DisableAddressOfExpressionRequirementOnOutArguments;
	}
	public bool set_DisableForcingFinalizeAsDestructor(bool new_DisableForcingFinalizeAsDestructor){
		bool back_DisableForcingFinalizeAsDestructor = p_DisableForcingFinalizeAsDestructor;
		p_DisableForcingFinalizeAsDestructor = new_DisableForcingFinalizeAsDestructor;
		return back_DisableForcingFinalizeAsDestructor;
	}
	public bool set_ForceNormalVirtualFunctionCallsOnConstructorsBody(bool new_ForceNormalVirtualFunctionCallsOnConstructorsBody){
		bool back_ForceNormalVirtualFunctionCallsOnConstructorsBody = p_ForceNormalVirtualFunctionCallsOnConstructorsBody;
		p_ForceNormalVirtualFunctionCallsOnConstructorsBody = new_ForceNormalVirtualFunctionCallsOnConstructorsBody;
		return back_ForceNormalVirtualFunctionCallsOnConstructorsBody;
	}
	public bool set_DisableVirtualizationOfMembers(bool new_DisableVirtualizationOfMembers){
		bool back_DisableVirtualizationOfMembers = p_DisableVirtualizationOfMembers;
		p_DisableVirtualizationOfMembers = new_DisableVirtualizationOfMembers;
		return back_DisableVirtualizationOfMembers;
	}
	public bool set_ForceLimitedGotos(bool new_ForceLimitedGotos){
		bool back_ForceLimitedGotos = p_ForceLimitedGotos;
		p_ForceLimitedGotos = new_ForceLimitedGotos;
		return back_ForceLimitedGotos;
	}
	public bool set_UseRuntimeTypeInformation(bool new_UseRuntimeTypeInformation){
		bool back_UseRuntimeTypeInformation = p_UseRuntimeTypeInformation;
		p_UseRuntimeTypeInformation = new_UseRuntimeTypeInformation;
		return back_UseRuntimeTypeInformation;
	}
	public bool set_UseRuntimeReflection(bool new_UseRuntimeReflection){
		bool back_UseRuntimeReflection = p_UseRuntimeReflection;
		p_UseRuntimeReflection = new_UseRuntimeReflection;
		return back_UseRuntimeReflection;
	}
	public bool set_LimitRuntimeReflectionToModuleOnly(bool new_LimitRuntimeReflectionToModuleOnly){
		bool back_LimitRuntimeReflectionToModuleOnly = p_LimitRuntimeReflectionToModuleOnly;
		p_LimitRuntimeReflectionToModuleOnly = new_LimitRuntimeReflectionToModuleOnly;
		return back_LimitRuntimeReflectionToModuleOnly;
	}
	public bool set_UseResumeExceptionModel(bool new_UseResumeExceptionModel){
		bool back_UseResumeExceptionModel = p_UseResumeExceptionModel;
		p_UseResumeExceptionModel = new_UseResumeExceptionModel;
		return back_UseResumeExceptionModel;
	}
	public bool set_UseTerminationExceptionModel(bool new_UseTerminationExceptionModel){
		bool back_UseTerminationExceptionModel = p_UseTerminationExceptionModel;
		p_UseTerminationExceptionModel = new_UseTerminationExceptionModel;
		return back_UseTerminationExceptionModel;
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

