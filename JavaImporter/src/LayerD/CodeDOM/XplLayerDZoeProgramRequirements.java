/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 17/04/2009 10:26:34
 *
 *	Generado por Zoe CodeDOM Generator para Java.
 *	COPYRIGHT 2002,2005-2006.
 *
 *------------------------------------------------*/


package LayerD.CodeDOM;

import LayerD.CodeDOM.XplParser.ParseException;
import java.io.*;
import java.util.*;
import java.text.*;

public class XplLayerDZoeProgramRequirements extends  XplNode implements XplNodeListCallbacks {

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	boolean p_UseCaseSensitive;
	String p_SetDefaultSafeArrays;
	boolean p_DisableArrayLimitsChecks;
	boolean p_UseSinglePointAsNamespaceSeparator;
	boolean p_UseSimpleMemberAccessAsNamespaceSeparator;
	boolean p_UseInheritsAsImplements;
	String p_SetDefaultIdentifiersNamespace;
	String p_SetDefaultGarbageCollector;
	boolean p_UseSingleInheritance;
	boolean p_UseUniversalObjectBase;
	String p_SetUniversalObjectBase;
	boolean p_DisableUnifiedTypeSystem;
	boolean p_EnableIntegerOverflowExceptions;
	boolean p_EnableFloatOperationsExceptions;
	boolean p_RequiereFullDecimalImplementation;
	boolean p_RequireASCIIChar;
	boolean p_RequireASCIIString;
	String p_SetASCIIStringClass;
	String p_SetStringClass;
	boolean p_DisableNullReferenceCheckOnMemberAccess;
	boolean p_RequirePointerArithmetics;
	boolean p_DisableUnsafePointerConversionsFromVoid;
	boolean p_DisableAllPointerConversionsFromVoid;
	boolean p_DisableAllPointerConversionsToVoid;
	boolean p_DisableAllPointerConversionsFromIntegers;
	boolean p_DisableAllPointerConversionsToIntegers;
	int p_SetNullIntegerValue;
	boolean p_DisableBaseTypesArrayItemsInitialization;
	boolean p_DisableStaticsVarsInitialization;
	boolean p_DisableInstanceVarsInitialization;
	boolean p_EnableLocalsVarsInitialization;
	boolean p_IgnorePreviousAssingmentRules;
	boolean p_EnablePointerAssingnationWarningsAsErrors;
	boolean p_DisablePointerAssingnationWarnings;
	boolean p_DisableAddressOfExpressionRequirementOnOutArguments;
	boolean p_DisableForcingFinalizeAsDestructor;
	boolean p_ForceNormalVirtualFunctionCallsOnConstructorsBody;
	boolean p_DisableVirtualizationOfMembers;
	boolean p_ForceLimitedGotos;
	boolean p_UseRuntimeTypeInformation;
	boolean p_UseRuntimeReflection;
	boolean p_LimitRuntimeReflectionToModuleOnly;
	boolean p_UseResumeExceptionModel;
	boolean p_UseTerminationExceptionModel;
	//Variables para Elementos de Secuencia
	XplNodeList p_GarbageCollector;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
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
		p_GarbageCollector.set_CheckNodeCallback(this);
	}
	public XplLayerDZoeProgramRequirements(boolean n_UseCaseSensitive, boolean n_DisableArrayLimitsChecks, boolean n_UseSinglePointAsNamespaceSeparator, boolean n_UseSimpleMemberAccessAsNamespaceSeparator, boolean n_UseInheritsAsImplements, boolean n_UseSingleInheritance, boolean n_UseUniversalObjectBase, boolean n_DisableUnifiedTypeSystem, boolean n_EnableIntegerOverflowExceptions, boolean n_EnableFloatOperationsExceptions, boolean n_RequiereFullDecimalImplementation, boolean n_RequireASCIIChar, boolean n_RequireASCIIString, boolean n_DisableNullReferenceCheckOnMemberAccess, boolean n_RequirePointerArithmetics, boolean n_DisableUnsafePointerConversionsFromVoid, boolean n_DisableAllPointerConversionsFromVoid, boolean n_DisableAllPointerConversionsToVoid, boolean n_DisableAllPointerConversionsFromIntegers, boolean n_DisableAllPointerConversionsToIntegers, boolean n_DisableBaseTypesArrayItemsInitialization, boolean n_DisableStaticsVarsInitialization, boolean n_DisableInstanceVarsInitialization, boolean n_EnableLocalsVarsInitialization, boolean n_IgnorePreviousAssingmentRules, boolean n_EnablePointerAssingnationWarningsAsErrors, boolean n_DisablePointerAssingnationWarnings, boolean n_DisableAddressOfExpressionRequirementOnOutArguments, boolean n_DisableForcingFinalizeAsDestructor, boolean n_ForceNormalVirtualFunctionCallsOnConstructorsBody, boolean n_DisableVirtualizationOfMembers, boolean n_ForceLimitedGotos, boolean n_UseRuntimeTypeInformation, boolean n_UseRuntimeReflection, boolean n_LimitRuntimeReflectionToModuleOnly, boolean n_UseResumeExceptionModel, boolean n_UseTerminationExceptionModel){
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
		p_GarbageCollector.set_CheckNodeCallback(this);
	}
	public XplLayerDZoeProgramRequirements(boolean n_UseCaseSensitive, String n_SetDefaultSafeArrays, boolean n_DisableArrayLimitsChecks, boolean n_UseSinglePointAsNamespaceSeparator, boolean n_UseSimpleMemberAccessAsNamespaceSeparator, boolean n_UseInheritsAsImplements, String n_SetDefaultIdentifiersNamespace, String n_SetDefaultGarbageCollector, boolean n_UseSingleInheritance, boolean n_UseUniversalObjectBase, String n_SetUniversalObjectBase, boolean n_DisableUnifiedTypeSystem, boolean n_EnableIntegerOverflowExceptions, boolean n_EnableFloatOperationsExceptions, boolean n_RequiereFullDecimalImplementation, boolean n_RequireASCIIChar, boolean n_RequireASCIIString, String n_SetASCIIStringClass, String n_SetStringClass, boolean n_DisableNullReferenceCheckOnMemberAccess, boolean n_RequirePointerArithmetics, boolean n_DisableUnsafePointerConversionsFromVoid, boolean n_DisableAllPointerConversionsFromVoid, boolean n_DisableAllPointerConversionsToVoid, boolean n_DisableAllPointerConversionsFromIntegers, boolean n_DisableAllPointerConversionsToIntegers, int n_SetNullIntegerValue, boolean n_DisableBaseTypesArrayItemsInitialization, boolean n_DisableStaticsVarsInitialization, boolean n_DisableInstanceVarsInitialization, boolean n_EnableLocalsVarsInitialization, boolean n_IgnorePreviousAssingmentRules, boolean n_EnablePointerAssingnationWarningsAsErrors, boolean n_DisablePointerAssingnationWarnings, boolean n_DisableAddressOfExpressionRequirementOnOutArguments, boolean n_DisableForcingFinalizeAsDestructor, boolean n_ForceNormalVirtualFunctionCallsOnConstructorsBody, boolean n_DisableVirtualizationOfMembers, boolean n_ForceLimitedGotos, boolean n_UseRuntimeTypeInformation, boolean n_UseRuntimeReflection, boolean n_LimitRuntimeReflectionToModuleOnly, boolean n_UseResumeExceptionModel, boolean n_UseTerminationExceptionModel){
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
		p_GarbageCollector.set_CheckNodeCallback(this);
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
		p_GarbageCollector.set_CheckNodeCallback(this);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_GarbageCollector!=null)
		for(XplNode node = n_GarbageCollector.FirstNode(); node != null ; node = n_GarbageCollector.NextNode()){
			p_GarbageCollector.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
	}
	public XplLayerDZoeProgramRequirements(boolean n_UseCaseSensitive, boolean n_DisableArrayLimitsChecks, boolean n_UseSinglePointAsNamespaceSeparator, boolean n_UseSimpleMemberAccessAsNamespaceSeparator, boolean n_UseInheritsAsImplements, boolean n_UseSingleInheritance, boolean n_UseUniversalObjectBase, boolean n_DisableUnifiedTypeSystem, boolean n_EnableIntegerOverflowExceptions, boolean n_EnableFloatOperationsExceptions, boolean n_RequiereFullDecimalImplementation, boolean n_RequireASCIIChar, boolean n_RequireASCIIString, boolean n_DisableNullReferenceCheckOnMemberAccess, boolean n_RequirePointerArithmetics, boolean n_DisableUnsafePointerConversionsFromVoid, boolean n_DisableAllPointerConversionsFromVoid, boolean n_DisableAllPointerConversionsToVoid, boolean n_DisableAllPointerConversionsFromIntegers, boolean n_DisableAllPointerConversionsToIntegers, boolean n_DisableBaseTypesArrayItemsInitialization, boolean n_DisableStaticsVarsInitialization, boolean n_DisableInstanceVarsInitialization, boolean n_EnableLocalsVarsInitialization, boolean n_IgnorePreviousAssingmentRules, boolean n_EnablePointerAssingnationWarningsAsErrors, boolean n_DisablePointerAssingnationWarnings, boolean n_DisableAddressOfExpressionRequirementOnOutArguments, boolean n_DisableForcingFinalizeAsDestructor, boolean n_ForceNormalVirtualFunctionCallsOnConstructorsBody, boolean n_DisableVirtualizationOfMembers, boolean n_ForceLimitedGotos, boolean n_UseRuntimeTypeInformation, boolean n_UseRuntimeReflection, boolean n_LimitRuntimeReflectionToModuleOnly, boolean n_UseResumeExceptionModel, boolean n_UseTerminationExceptionModel, XplNodeList n_GarbageCollector){
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
		p_GarbageCollector.set_CheckNodeCallback(this);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_GarbageCollector!=null)
		for(XplNode node = n_GarbageCollector.FirstNode(); node != null ; node = n_GarbageCollector.NextNode()){
			p_GarbageCollector.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
	}
	public XplLayerDZoeProgramRequirements(boolean n_UseCaseSensitive, String n_SetDefaultSafeArrays, boolean n_DisableArrayLimitsChecks, boolean n_UseSinglePointAsNamespaceSeparator, boolean n_UseSimpleMemberAccessAsNamespaceSeparator, boolean n_UseInheritsAsImplements, String n_SetDefaultIdentifiersNamespace, String n_SetDefaultGarbageCollector, boolean n_UseSingleInheritance, boolean n_UseUniversalObjectBase, String n_SetUniversalObjectBase, boolean n_DisableUnifiedTypeSystem, boolean n_EnableIntegerOverflowExceptions, boolean n_EnableFloatOperationsExceptions, boolean n_RequiereFullDecimalImplementation, boolean n_RequireASCIIChar, boolean n_RequireASCIIString, String n_SetASCIIStringClass, String n_SetStringClass, boolean n_DisableNullReferenceCheckOnMemberAccess, boolean n_RequirePointerArithmetics, boolean n_DisableUnsafePointerConversionsFromVoid, boolean n_DisableAllPointerConversionsFromVoid, boolean n_DisableAllPointerConversionsToVoid, boolean n_DisableAllPointerConversionsFromIntegers, boolean n_DisableAllPointerConversionsToIntegers, int n_SetNullIntegerValue, boolean n_DisableBaseTypesArrayItemsInitialization, boolean n_DisableStaticsVarsInitialization, boolean n_DisableInstanceVarsInitialization, boolean n_EnableLocalsVarsInitialization, boolean n_IgnorePreviousAssingmentRules, boolean n_EnablePointerAssingnationWarningsAsErrors, boolean n_DisablePointerAssingnationWarnings, boolean n_DisableAddressOfExpressionRequirementOnOutArguments, boolean n_DisableForcingFinalizeAsDestructor, boolean n_ForceNormalVirtualFunctionCallsOnConstructorsBody, boolean n_DisableVirtualizationOfMembers, boolean n_ForceLimitedGotos, boolean n_UseRuntimeTypeInformation, boolean n_UseRuntimeReflection, boolean n_LimitRuntimeReflectionToModuleOnly, boolean n_UseResumeExceptionModel, boolean n_UseTerminationExceptionModel, XplNodeList n_GarbageCollector){
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
		p_GarbageCollector.set_CheckNodeCallback(this);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_GarbageCollector!=null)
		for(XplNode node = n_GarbageCollector.FirstNode(); node != null ; node = n_GarbageCollector.NextNode()){
			p_GarbageCollector.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
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
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplLayerDZoeProgramRequirements;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_UseCaseSensitive != true)
			writer.WriteAttributeString( "UseCaseSensitive" ,CodeDOM_Utils.Att_ToString(p_UseCaseSensitive) );
		if(p_SetDefaultSafeArrays != "")
			writer.WriteAttributeString( "SetDefaultSafeArrays" ,CodeDOM_Utils.Att_ToString(p_SetDefaultSafeArrays) );
		if(p_DisableArrayLimitsChecks != false)
			writer.WriteAttributeString( "DisableArrayLimitsChecks" ,CodeDOM_Utils.Att_ToString(p_DisableArrayLimitsChecks) );
		if(p_UseSinglePointAsNamespaceSeparator != false)
			writer.WriteAttributeString( "UseSinglePointAsNamespaceSeparator" ,CodeDOM_Utils.Att_ToString(p_UseSinglePointAsNamespaceSeparator) );
		if(p_UseSimpleMemberAccessAsNamespaceSeparator != false)
			writer.WriteAttributeString( "UseSimpleMemberAccessAsNamespaceSeparator" ,CodeDOM_Utils.Att_ToString(p_UseSimpleMemberAccessAsNamespaceSeparator) );
		if(p_UseInheritsAsImplements != false)
			writer.WriteAttributeString( "UseInheritsAsImplements" ,CodeDOM_Utils.Att_ToString(p_UseInheritsAsImplements) );
		if(p_SetDefaultIdentifiersNamespace != "")
			writer.WriteAttributeString( "SetDefaultIdentifiersNamespace" ,CodeDOM_Utils.Att_ToString(p_SetDefaultIdentifiersNamespace) );
		if(p_SetDefaultGarbageCollector != "")
			writer.WriteAttributeString( "SetDefaultGarbageCollector" ,CodeDOM_Utils.Att_ToString(p_SetDefaultGarbageCollector) );
		if(p_UseSingleInheritance != true)
			writer.WriteAttributeString( "UseSingleInheritance" ,CodeDOM_Utils.Att_ToString(p_UseSingleInheritance) );
		if(p_UseUniversalObjectBase != true)
			writer.WriteAttributeString( "UseUniversalObjectBase" ,CodeDOM_Utils.Att_ToString(p_UseUniversalObjectBase) );
		if(p_SetUniversalObjectBase != "")
			writer.WriteAttributeString( "SetUniversalObjectBase" ,CodeDOM_Utils.Att_ToString(p_SetUniversalObjectBase) );
		if(p_DisableUnifiedTypeSystem != false)
			writer.WriteAttributeString( "DisableUnifiedTypeSystem" ,CodeDOM_Utils.Att_ToString(p_DisableUnifiedTypeSystem) );
		if(p_EnableIntegerOverflowExceptions != false)
			writer.WriteAttributeString( "EnableIntegerOverflowExceptions" ,CodeDOM_Utils.Att_ToString(p_EnableIntegerOverflowExceptions) );
		if(p_EnableFloatOperationsExceptions != false)
			writer.WriteAttributeString( "EnableFloatOperationsExceptions" ,CodeDOM_Utils.Att_ToString(p_EnableFloatOperationsExceptions) );
		if(p_RequiereFullDecimalImplementation != false)
			writer.WriteAttributeString( "RequiereFullDecimalImplementation" ,CodeDOM_Utils.Att_ToString(p_RequiereFullDecimalImplementation) );
		if(p_RequireASCIIChar != false)
			writer.WriteAttributeString( "RequireASCIIChar" ,CodeDOM_Utils.Att_ToString(p_RequireASCIIChar) );
		if(p_RequireASCIIString != false)
			writer.WriteAttributeString( "RequireASCIIString" ,CodeDOM_Utils.Att_ToString(p_RequireASCIIString) );
		if(p_SetASCIIStringClass != "")
			writer.WriteAttributeString( "SetASCIIStringClass" ,CodeDOM_Utils.Att_ToString(p_SetASCIIStringClass) );
		if(p_SetStringClass != "")
			writer.WriteAttributeString( "SetStringClass" ,CodeDOM_Utils.Att_ToString(p_SetStringClass) );
		if(p_DisableNullReferenceCheckOnMemberAccess != false)
			writer.WriteAttributeString( "DisableNullReferenceCheckOnMemberAccess" ,CodeDOM_Utils.Att_ToString(p_DisableNullReferenceCheckOnMemberAccess) );
		if(p_RequirePointerArithmetics != false)
			writer.WriteAttributeString( "RequirePointerArithmetics" ,CodeDOM_Utils.Att_ToString(p_RequirePointerArithmetics) );
		if(p_DisableUnsafePointerConversionsFromVoid != false)
			writer.WriteAttributeString( "DisableUnsafePointerConversionsFromVoid" ,CodeDOM_Utils.Att_ToString(p_DisableUnsafePointerConversionsFromVoid) );
		if(p_DisableAllPointerConversionsFromVoid != false)
			writer.WriteAttributeString( "DisableAllPointerConversionsFromVoid" ,CodeDOM_Utils.Att_ToString(p_DisableAllPointerConversionsFromVoid) );
		if(p_DisableAllPointerConversionsToVoid != false)
			writer.WriteAttributeString( "DisableAllPointerConversionsToVoid" ,CodeDOM_Utils.Att_ToString(p_DisableAllPointerConversionsToVoid) );
		if(p_DisableAllPointerConversionsFromIntegers != false)
			writer.WriteAttributeString( "DisableAllPointerConversionsFromIntegers" ,CodeDOM_Utils.Att_ToString(p_DisableAllPointerConversionsFromIntegers) );
		if(p_DisableAllPointerConversionsToIntegers != false)
			writer.WriteAttributeString( "DisableAllPointerConversionsToIntegers" ,CodeDOM_Utils.Att_ToString(p_DisableAllPointerConversionsToIntegers) );
		if(p_SetNullIntegerValue != 0)
			writer.WriteAttributeString( "SetNullIntegerValue" ,CodeDOM_Utils.Att_ToString(p_SetNullIntegerValue) );
		if(p_DisableBaseTypesArrayItemsInitialization != false)
			writer.WriteAttributeString( "DisableBaseTypesArrayItemsInitialization" ,CodeDOM_Utils.Att_ToString(p_DisableBaseTypesArrayItemsInitialization) );
		if(p_DisableStaticsVarsInitialization != false)
			writer.WriteAttributeString( "DisableStaticsVarsInitialization" ,CodeDOM_Utils.Att_ToString(p_DisableStaticsVarsInitialization) );
		if(p_DisableInstanceVarsInitialization != false)
			writer.WriteAttributeString( "DisableInstanceVarsInitialization" ,CodeDOM_Utils.Att_ToString(p_DisableInstanceVarsInitialization) );
		if(p_EnableLocalsVarsInitialization != false)
			writer.WriteAttributeString( "EnableLocalsVarsInitialization" ,CodeDOM_Utils.Att_ToString(p_EnableLocalsVarsInitialization) );
		if(p_IgnorePreviousAssingmentRules != false)
			writer.WriteAttributeString( "IgnorePreviousAssingmentRules" ,CodeDOM_Utils.Att_ToString(p_IgnorePreviousAssingmentRules) );
		if(p_EnablePointerAssingnationWarningsAsErrors != false)
			writer.WriteAttributeString( "EnablePointerAssingnationWarningsAsErrors" ,CodeDOM_Utils.Att_ToString(p_EnablePointerAssingnationWarningsAsErrors) );
		if(p_DisablePointerAssingnationWarnings != false)
			writer.WriteAttributeString( "DisablePointerAssingnationWarnings" ,CodeDOM_Utils.Att_ToString(p_DisablePointerAssingnationWarnings) );
		if(p_DisableAddressOfExpressionRequirementOnOutArguments != false)
			writer.WriteAttributeString( "DisableAddressOfExpressionRequirementOnOutArguments" ,CodeDOM_Utils.Att_ToString(p_DisableAddressOfExpressionRequirementOnOutArguments) );
		if(p_DisableForcingFinalizeAsDestructor != false)
			writer.WriteAttributeString( "DisableForcingFinalizeAsDestructor" ,CodeDOM_Utils.Att_ToString(p_DisableForcingFinalizeAsDestructor) );
		if(p_ForceNormalVirtualFunctionCallsOnConstructorsBody != false)
			writer.WriteAttributeString( "ForceNormalVirtualFunctionCallsOnConstructorsBody" ,CodeDOM_Utils.Att_ToString(p_ForceNormalVirtualFunctionCallsOnConstructorsBody) );
		if(p_DisableVirtualizationOfMembers != false)
			writer.WriteAttributeString( "DisableVirtualizationOfMembers" ,CodeDOM_Utils.Att_ToString(p_DisableVirtualizationOfMembers) );
		if(p_ForceLimitedGotos != false)
			writer.WriteAttributeString( "ForceLimitedGotos" ,CodeDOM_Utils.Att_ToString(p_ForceLimitedGotos) );
		if(p_UseRuntimeTypeInformation != true)
			writer.WriteAttributeString( "UseRuntimeTypeInformation" ,CodeDOM_Utils.Att_ToString(p_UseRuntimeTypeInformation) );
		if(p_UseRuntimeReflection != false)
			writer.WriteAttributeString( "UseRuntimeReflection" ,CodeDOM_Utils.Att_ToString(p_UseRuntimeReflection) );
		if(p_LimitRuntimeReflectionToModuleOnly != false)
			writer.WriteAttributeString( "LimitRuntimeReflectionToModuleOnly" ,CodeDOM_Utils.Att_ToString(p_LimitRuntimeReflectionToModuleOnly) );
		if(p_UseResumeExceptionModel != false)
			writer.WriteAttributeString( "UseResumeExceptionModel" ,CodeDOM_Utils.Att_ToString(p_UseResumeExceptionModel) );
		if(p_UseTerminationExceptionModel != true)
			writer.WriteAttributeString( "UseTerminationExceptionModel" ,CodeDOM_Utils.Att_ToString(p_UseTerminationExceptionModel) );
		//Escribo recursivamente cada elemento hijo
		if(p_GarbageCollector!=null)if(!p_GarbageCollector.Write(writer))result=false;
		//Cierro el elemento
		writer.WriteEndElement();
		return result;
	}

	public XplNode Read(XplReader reader) throws ParseException, CodeDOM_Exception, IOException {
		this.set_Name( reader.Name() );
		//Lectura de Atributos
		if( reader.HasAttributes() ){
			for(int i=1; i <= reader.AttributeCount() ; i++){
				reader.MoveToAttribute(i);
				if(reader.Name().equals("UseCaseSensitive")){
					this.set_UseCaseSensitive(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("SetDefaultSafeArrays")){
					this.set_SetDefaultSafeArrays(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("DisableArrayLimitsChecks")){
					this.set_DisableArrayLimitsChecks(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("UseSinglePointAsNamespaceSeparator")){
					this.set_UseSinglePointAsNamespaceSeparator(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("UseSimpleMemberAccessAsNamespaceSeparator")){
					this.set_UseSimpleMemberAccessAsNamespaceSeparator(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("UseInheritsAsImplements")){
					this.set_UseInheritsAsImplements(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("SetDefaultIdentifiersNamespace")){
					this.set_SetDefaultIdentifiersNamespace(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("SetDefaultGarbageCollector")){
					this.set_SetDefaultGarbageCollector(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("UseSingleInheritance")){
					this.set_UseSingleInheritance(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("UseUniversalObjectBase")){
					this.set_UseUniversalObjectBase(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("SetUniversalObjectBase")){
					this.set_SetUniversalObjectBase(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("DisableUnifiedTypeSystem")){
					this.set_DisableUnifiedTypeSystem(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("EnableIntegerOverflowExceptions")){
					this.set_EnableIntegerOverflowExceptions(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("EnableFloatOperationsExceptions")){
					this.set_EnableFloatOperationsExceptions(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("RequiereFullDecimalImplementation")){
					this.set_RequiereFullDecimalImplementation(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("RequireASCIIChar")){
					this.set_RequireASCIIChar(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("RequireASCIIString")){
					this.set_RequireASCIIString(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("SetASCIIStringClass")){
					this.set_SetASCIIStringClass(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("SetStringClass")){
					this.set_SetStringClass(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("DisableNullReferenceCheckOnMemberAccess")){
					this.set_DisableNullReferenceCheckOnMemberAccess(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("RequirePointerArithmetics")){
					this.set_RequirePointerArithmetics(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("DisableUnsafePointerConversionsFromVoid")){
					this.set_DisableUnsafePointerConversionsFromVoid(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("DisableAllPointerConversionsFromVoid")){
					this.set_DisableAllPointerConversionsFromVoid(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("DisableAllPointerConversionsToVoid")){
					this.set_DisableAllPointerConversionsToVoid(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("DisableAllPointerConversionsFromIntegers")){
					this.set_DisableAllPointerConversionsFromIntegers(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("DisableAllPointerConversionsToIntegers")){
					this.set_DisableAllPointerConversionsToIntegers(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("SetNullIntegerValue")){
					this.set_SetNullIntegerValue(CodeDOM_Utils.StringAtt_To_INT(reader.Value()));
				}
				else if(reader.Name().equals("DisableBaseTypesArrayItemsInitialization")){
					this.set_DisableBaseTypesArrayItemsInitialization(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("DisableStaticsVarsInitialization")){
					this.set_DisableStaticsVarsInitialization(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("DisableInstanceVarsInitialization")){
					this.set_DisableInstanceVarsInitialization(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("EnableLocalsVarsInitialization")){
					this.set_EnableLocalsVarsInitialization(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("IgnorePreviousAssingmentRules")){
					this.set_IgnorePreviousAssingmentRules(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("EnablePointerAssingnationWarningsAsErrors")){
					this.set_EnablePointerAssingnationWarningsAsErrors(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("DisablePointerAssingnationWarnings")){
					this.set_DisablePointerAssingnationWarnings(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("DisableAddressOfExpressionRequirementOnOutArguments")){
					this.set_DisableAddressOfExpressionRequirementOnOutArguments(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("DisableForcingFinalizeAsDestructor")){
					this.set_DisableForcingFinalizeAsDestructor(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("ForceNormalVirtualFunctionCallsOnConstructorsBody")){
					this.set_ForceNormalVirtualFunctionCallsOnConstructorsBody(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("DisableVirtualizationOfMembers")){
					this.set_DisableVirtualizationOfMembers(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("ForceLimitedGotos")){
					this.set_ForceLimitedGotos(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("UseRuntimeTypeInformation")){
					this.set_UseRuntimeTypeInformation(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("UseRuntimeReflection")){
					this.set_UseRuntimeReflection(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("LimitRuntimeReflectionToModuleOnly")){
					this.set_LimitRuntimeReflectionToModuleOnly(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("UseResumeExceptionModel")){
					this.set_UseResumeExceptionModel(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("UseTerminationExceptionModel")){
					this.set_UseTerminationExceptionModel(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else{
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Atributo '"+reader.Name()+"' invalido en elemento '"+this.get_Name()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		//Borro todo posible nodo en memoria
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("GarbageCollector")){
						tempNode = new XplGarbageCollector();
						tempNode.Read(reader);
						this.get_GarbageCollector().InsertAtEnd(tempNode);
					}
					else{
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nombre de nodo '"+reader.Name()+"' inesperado como hijo de elemento '"+this.get_Name()+"'.");
					}
					break;
				case XmlNodeType.ENDELEMENT:
					break;
				case XmlNodeType.TEXT:
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".No se esperaba texto en este nodo.");
				default:
					break;
			}
			reader.Read();
		}
		}
		return this;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para obtener Atributos y Elementos ">
	public boolean get_UseCaseSensitive(){
		return p_UseCaseSensitive;
	}
	public String get_SetDefaultSafeArrays(){
		return p_SetDefaultSafeArrays;
	}
	public boolean get_DisableArrayLimitsChecks(){
		return p_DisableArrayLimitsChecks;
	}
	public boolean get_UseSinglePointAsNamespaceSeparator(){
		return p_UseSinglePointAsNamespaceSeparator;
	}
	public boolean get_UseSimpleMemberAccessAsNamespaceSeparator(){
		return p_UseSimpleMemberAccessAsNamespaceSeparator;
	}
	public boolean get_UseInheritsAsImplements(){
		return p_UseInheritsAsImplements;
	}
	public String get_SetDefaultIdentifiersNamespace(){
		return p_SetDefaultIdentifiersNamespace;
	}
	public String get_SetDefaultGarbageCollector(){
		return p_SetDefaultGarbageCollector;
	}
	public boolean get_UseSingleInheritance(){
		return p_UseSingleInheritance;
	}
	public boolean get_UseUniversalObjectBase(){
		return p_UseUniversalObjectBase;
	}
	public String get_SetUniversalObjectBase(){
		return p_SetUniversalObjectBase;
	}
	public boolean get_DisableUnifiedTypeSystem(){
		return p_DisableUnifiedTypeSystem;
	}
	public boolean get_EnableIntegerOverflowExceptions(){
		return p_EnableIntegerOverflowExceptions;
	}
	public boolean get_EnableFloatOperationsExceptions(){
		return p_EnableFloatOperationsExceptions;
	}
	public boolean get_RequiereFullDecimalImplementation(){
		return p_RequiereFullDecimalImplementation;
	}
	public boolean get_RequireASCIIChar(){
		return p_RequireASCIIChar;
	}
	public boolean get_RequireASCIIString(){
		return p_RequireASCIIString;
	}
	public String get_SetASCIIStringClass(){
		return p_SetASCIIStringClass;
	}
	public String get_SetStringClass(){
		return p_SetStringClass;
	}
	public boolean get_DisableNullReferenceCheckOnMemberAccess(){
		return p_DisableNullReferenceCheckOnMemberAccess;
	}
	public boolean get_RequirePointerArithmetics(){
		return p_RequirePointerArithmetics;
	}
	public boolean get_DisableUnsafePointerConversionsFromVoid(){
		return p_DisableUnsafePointerConversionsFromVoid;
	}
	public boolean get_DisableAllPointerConversionsFromVoid(){
		return p_DisableAllPointerConversionsFromVoid;
	}
	public boolean get_DisableAllPointerConversionsToVoid(){
		return p_DisableAllPointerConversionsToVoid;
	}
	public boolean get_DisableAllPointerConversionsFromIntegers(){
		return p_DisableAllPointerConversionsFromIntegers;
	}
	public boolean get_DisableAllPointerConversionsToIntegers(){
		return p_DisableAllPointerConversionsToIntegers;
	}
	public int get_SetNullIntegerValue(){
		return p_SetNullIntegerValue;
	}
	public boolean get_DisableBaseTypesArrayItemsInitialization(){
		return p_DisableBaseTypesArrayItemsInitialization;
	}
	public boolean get_DisableStaticsVarsInitialization(){
		return p_DisableStaticsVarsInitialization;
	}
	public boolean get_DisableInstanceVarsInitialization(){
		return p_DisableInstanceVarsInitialization;
	}
	public boolean get_EnableLocalsVarsInitialization(){
		return p_EnableLocalsVarsInitialization;
	}
	public boolean get_IgnorePreviousAssingmentRules(){
		return p_IgnorePreviousAssingmentRules;
	}
	public boolean get_EnablePointerAssingnationWarningsAsErrors(){
		return p_EnablePointerAssingnationWarningsAsErrors;
	}
	public boolean get_DisablePointerAssingnationWarnings(){
		return p_DisablePointerAssingnationWarnings;
	}
	public boolean get_DisableAddressOfExpressionRequirementOnOutArguments(){
		return p_DisableAddressOfExpressionRequirementOnOutArguments;
	}
	public boolean get_DisableForcingFinalizeAsDestructor(){
		return p_DisableForcingFinalizeAsDestructor;
	}
	public boolean get_ForceNormalVirtualFunctionCallsOnConstructorsBody(){
		return p_ForceNormalVirtualFunctionCallsOnConstructorsBody;
	}
	public boolean get_DisableVirtualizationOfMembers(){
		return p_DisableVirtualizationOfMembers;
	}
	public boolean get_ForceLimitedGotos(){
		return p_ForceLimitedGotos;
	}
	public boolean get_UseRuntimeTypeInformation(){
		return p_UseRuntimeTypeInformation;
	}
	public boolean get_UseRuntimeReflection(){
		return p_UseRuntimeReflection;
	}
	public boolean get_LimitRuntimeReflectionToModuleOnly(){
		return p_LimitRuntimeReflectionToModuleOnly;
	}
	public boolean get_UseResumeExceptionModel(){
		return p_UseResumeExceptionModel;
	}
	public boolean get_UseTerminationExceptionModel(){
		return p_UseTerminationExceptionModel;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplNodeList get_GarbageCollector(){
		return p_GarbageCollector;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public boolean set_UseCaseSensitive(boolean new_UseCaseSensitive){
		boolean back_UseCaseSensitive = p_UseCaseSensitive;
		p_UseCaseSensitive = new_UseCaseSensitive;
		return back_UseCaseSensitive;
	}
	public String set_SetDefaultSafeArrays(String new_SetDefaultSafeArrays){
		String back_SetDefaultSafeArrays = p_SetDefaultSafeArrays;
		p_SetDefaultSafeArrays = new_SetDefaultSafeArrays;
		return back_SetDefaultSafeArrays;
	}
	public boolean set_DisableArrayLimitsChecks(boolean new_DisableArrayLimitsChecks){
		boolean back_DisableArrayLimitsChecks = p_DisableArrayLimitsChecks;
		p_DisableArrayLimitsChecks = new_DisableArrayLimitsChecks;
		return back_DisableArrayLimitsChecks;
	}
	public boolean set_UseSinglePointAsNamespaceSeparator(boolean new_UseSinglePointAsNamespaceSeparator){
		boolean back_UseSinglePointAsNamespaceSeparator = p_UseSinglePointAsNamespaceSeparator;
		p_UseSinglePointAsNamespaceSeparator = new_UseSinglePointAsNamespaceSeparator;
		return back_UseSinglePointAsNamespaceSeparator;
	}
	public boolean set_UseSimpleMemberAccessAsNamespaceSeparator(boolean new_UseSimpleMemberAccessAsNamespaceSeparator){
		boolean back_UseSimpleMemberAccessAsNamespaceSeparator = p_UseSimpleMemberAccessAsNamespaceSeparator;
		p_UseSimpleMemberAccessAsNamespaceSeparator = new_UseSimpleMemberAccessAsNamespaceSeparator;
		return back_UseSimpleMemberAccessAsNamespaceSeparator;
	}
	public boolean set_UseInheritsAsImplements(boolean new_UseInheritsAsImplements){
		boolean back_UseInheritsAsImplements = p_UseInheritsAsImplements;
		p_UseInheritsAsImplements = new_UseInheritsAsImplements;
		return back_UseInheritsAsImplements;
	}
	public String set_SetDefaultIdentifiersNamespace(String new_SetDefaultIdentifiersNamespace){
		String back_SetDefaultIdentifiersNamespace = p_SetDefaultIdentifiersNamespace;
		p_SetDefaultIdentifiersNamespace = new_SetDefaultIdentifiersNamespace;
		return back_SetDefaultIdentifiersNamespace;
	}
	public String set_SetDefaultGarbageCollector(String new_SetDefaultGarbageCollector){
		String back_SetDefaultGarbageCollector = p_SetDefaultGarbageCollector;
		p_SetDefaultGarbageCollector = new_SetDefaultGarbageCollector;
		return back_SetDefaultGarbageCollector;
	}
	public boolean set_UseSingleInheritance(boolean new_UseSingleInheritance){
		boolean back_UseSingleInheritance = p_UseSingleInheritance;
		p_UseSingleInheritance = new_UseSingleInheritance;
		return back_UseSingleInheritance;
	}
	public boolean set_UseUniversalObjectBase(boolean new_UseUniversalObjectBase){
		boolean back_UseUniversalObjectBase = p_UseUniversalObjectBase;
		p_UseUniversalObjectBase = new_UseUniversalObjectBase;
		return back_UseUniversalObjectBase;
	}
	public String set_SetUniversalObjectBase(String new_SetUniversalObjectBase){
		String back_SetUniversalObjectBase = p_SetUniversalObjectBase;
		p_SetUniversalObjectBase = new_SetUniversalObjectBase;
		return back_SetUniversalObjectBase;
	}
	public boolean set_DisableUnifiedTypeSystem(boolean new_DisableUnifiedTypeSystem){
		boolean back_DisableUnifiedTypeSystem = p_DisableUnifiedTypeSystem;
		p_DisableUnifiedTypeSystem = new_DisableUnifiedTypeSystem;
		return back_DisableUnifiedTypeSystem;
	}
	public boolean set_EnableIntegerOverflowExceptions(boolean new_EnableIntegerOverflowExceptions){
		boolean back_EnableIntegerOverflowExceptions = p_EnableIntegerOverflowExceptions;
		p_EnableIntegerOverflowExceptions = new_EnableIntegerOverflowExceptions;
		return back_EnableIntegerOverflowExceptions;
	}
	public boolean set_EnableFloatOperationsExceptions(boolean new_EnableFloatOperationsExceptions){
		boolean back_EnableFloatOperationsExceptions = p_EnableFloatOperationsExceptions;
		p_EnableFloatOperationsExceptions = new_EnableFloatOperationsExceptions;
		return back_EnableFloatOperationsExceptions;
	}
	public boolean set_RequiereFullDecimalImplementation(boolean new_RequiereFullDecimalImplementation){
		boolean back_RequiereFullDecimalImplementation = p_RequiereFullDecimalImplementation;
		p_RequiereFullDecimalImplementation = new_RequiereFullDecimalImplementation;
		return back_RequiereFullDecimalImplementation;
	}
	public boolean set_RequireASCIIChar(boolean new_RequireASCIIChar){
		boolean back_RequireASCIIChar = p_RequireASCIIChar;
		p_RequireASCIIChar = new_RequireASCIIChar;
		return back_RequireASCIIChar;
	}
	public boolean set_RequireASCIIString(boolean new_RequireASCIIString){
		boolean back_RequireASCIIString = p_RequireASCIIString;
		p_RequireASCIIString = new_RequireASCIIString;
		return back_RequireASCIIString;
	}
	public String set_SetASCIIStringClass(String new_SetASCIIStringClass){
		String back_SetASCIIStringClass = p_SetASCIIStringClass;
		p_SetASCIIStringClass = new_SetASCIIStringClass;
		return back_SetASCIIStringClass;
	}
	public String set_SetStringClass(String new_SetStringClass){
		String back_SetStringClass = p_SetStringClass;
		p_SetStringClass = new_SetStringClass;
		return back_SetStringClass;
	}
	public boolean set_DisableNullReferenceCheckOnMemberAccess(boolean new_DisableNullReferenceCheckOnMemberAccess){
		boolean back_DisableNullReferenceCheckOnMemberAccess = p_DisableNullReferenceCheckOnMemberAccess;
		p_DisableNullReferenceCheckOnMemberAccess = new_DisableNullReferenceCheckOnMemberAccess;
		return back_DisableNullReferenceCheckOnMemberAccess;
	}
	public boolean set_RequirePointerArithmetics(boolean new_RequirePointerArithmetics){
		boolean back_RequirePointerArithmetics = p_RequirePointerArithmetics;
		p_RequirePointerArithmetics = new_RequirePointerArithmetics;
		return back_RequirePointerArithmetics;
	}
	public boolean set_DisableUnsafePointerConversionsFromVoid(boolean new_DisableUnsafePointerConversionsFromVoid){
		boolean back_DisableUnsafePointerConversionsFromVoid = p_DisableUnsafePointerConversionsFromVoid;
		p_DisableUnsafePointerConversionsFromVoid = new_DisableUnsafePointerConversionsFromVoid;
		return back_DisableUnsafePointerConversionsFromVoid;
	}
	public boolean set_DisableAllPointerConversionsFromVoid(boolean new_DisableAllPointerConversionsFromVoid){
		boolean back_DisableAllPointerConversionsFromVoid = p_DisableAllPointerConversionsFromVoid;
		p_DisableAllPointerConversionsFromVoid = new_DisableAllPointerConversionsFromVoid;
		return back_DisableAllPointerConversionsFromVoid;
	}
	public boolean set_DisableAllPointerConversionsToVoid(boolean new_DisableAllPointerConversionsToVoid){
		boolean back_DisableAllPointerConversionsToVoid = p_DisableAllPointerConversionsToVoid;
		p_DisableAllPointerConversionsToVoid = new_DisableAllPointerConversionsToVoid;
		return back_DisableAllPointerConversionsToVoid;
	}
	public boolean set_DisableAllPointerConversionsFromIntegers(boolean new_DisableAllPointerConversionsFromIntegers){
		boolean back_DisableAllPointerConversionsFromIntegers = p_DisableAllPointerConversionsFromIntegers;
		p_DisableAllPointerConversionsFromIntegers = new_DisableAllPointerConversionsFromIntegers;
		return back_DisableAllPointerConversionsFromIntegers;
	}
	public boolean set_DisableAllPointerConversionsToIntegers(boolean new_DisableAllPointerConversionsToIntegers){
		boolean back_DisableAllPointerConversionsToIntegers = p_DisableAllPointerConversionsToIntegers;
		p_DisableAllPointerConversionsToIntegers = new_DisableAllPointerConversionsToIntegers;
		return back_DisableAllPointerConversionsToIntegers;
	}
	public int set_SetNullIntegerValue(int new_SetNullIntegerValue){
		int back_SetNullIntegerValue = p_SetNullIntegerValue;
		p_SetNullIntegerValue = new_SetNullIntegerValue;
		return back_SetNullIntegerValue;
	}
	public boolean set_DisableBaseTypesArrayItemsInitialization(boolean new_DisableBaseTypesArrayItemsInitialization){
		boolean back_DisableBaseTypesArrayItemsInitialization = p_DisableBaseTypesArrayItemsInitialization;
		p_DisableBaseTypesArrayItemsInitialization = new_DisableBaseTypesArrayItemsInitialization;
		return back_DisableBaseTypesArrayItemsInitialization;
	}
	public boolean set_DisableStaticsVarsInitialization(boolean new_DisableStaticsVarsInitialization){
		boolean back_DisableStaticsVarsInitialization = p_DisableStaticsVarsInitialization;
		p_DisableStaticsVarsInitialization = new_DisableStaticsVarsInitialization;
		return back_DisableStaticsVarsInitialization;
	}
	public boolean set_DisableInstanceVarsInitialization(boolean new_DisableInstanceVarsInitialization){
		boolean back_DisableInstanceVarsInitialization = p_DisableInstanceVarsInitialization;
		p_DisableInstanceVarsInitialization = new_DisableInstanceVarsInitialization;
		return back_DisableInstanceVarsInitialization;
	}
	public boolean set_EnableLocalsVarsInitialization(boolean new_EnableLocalsVarsInitialization){
		boolean back_EnableLocalsVarsInitialization = p_EnableLocalsVarsInitialization;
		p_EnableLocalsVarsInitialization = new_EnableLocalsVarsInitialization;
		return back_EnableLocalsVarsInitialization;
	}
	public boolean set_IgnorePreviousAssingmentRules(boolean new_IgnorePreviousAssingmentRules){
		boolean back_IgnorePreviousAssingmentRules = p_IgnorePreviousAssingmentRules;
		p_IgnorePreviousAssingmentRules = new_IgnorePreviousAssingmentRules;
		return back_IgnorePreviousAssingmentRules;
	}
	public boolean set_EnablePointerAssingnationWarningsAsErrors(boolean new_EnablePointerAssingnationWarningsAsErrors){
		boolean back_EnablePointerAssingnationWarningsAsErrors = p_EnablePointerAssingnationWarningsAsErrors;
		p_EnablePointerAssingnationWarningsAsErrors = new_EnablePointerAssingnationWarningsAsErrors;
		return back_EnablePointerAssingnationWarningsAsErrors;
	}
	public boolean set_DisablePointerAssingnationWarnings(boolean new_DisablePointerAssingnationWarnings){
		boolean back_DisablePointerAssingnationWarnings = p_DisablePointerAssingnationWarnings;
		p_DisablePointerAssingnationWarnings = new_DisablePointerAssingnationWarnings;
		return back_DisablePointerAssingnationWarnings;
	}
	public boolean set_DisableAddressOfExpressionRequirementOnOutArguments(boolean new_DisableAddressOfExpressionRequirementOnOutArguments){
		boolean back_DisableAddressOfExpressionRequirementOnOutArguments = p_DisableAddressOfExpressionRequirementOnOutArguments;
		p_DisableAddressOfExpressionRequirementOnOutArguments = new_DisableAddressOfExpressionRequirementOnOutArguments;
		return back_DisableAddressOfExpressionRequirementOnOutArguments;
	}
	public boolean set_DisableForcingFinalizeAsDestructor(boolean new_DisableForcingFinalizeAsDestructor){
		boolean back_DisableForcingFinalizeAsDestructor = p_DisableForcingFinalizeAsDestructor;
		p_DisableForcingFinalizeAsDestructor = new_DisableForcingFinalizeAsDestructor;
		return back_DisableForcingFinalizeAsDestructor;
	}
	public boolean set_ForceNormalVirtualFunctionCallsOnConstructorsBody(boolean new_ForceNormalVirtualFunctionCallsOnConstructorsBody){
		boolean back_ForceNormalVirtualFunctionCallsOnConstructorsBody = p_ForceNormalVirtualFunctionCallsOnConstructorsBody;
		p_ForceNormalVirtualFunctionCallsOnConstructorsBody = new_ForceNormalVirtualFunctionCallsOnConstructorsBody;
		return back_ForceNormalVirtualFunctionCallsOnConstructorsBody;
	}
	public boolean set_DisableVirtualizationOfMembers(boolean new_DisableVirtualizationOfMembers){
		boolean back_DisableVirtualizationOfMembers = p_DisableVirtualizationOfMembers;
		p_DisableVirtualizationOfMembers = new_DisableVirtualizationOfMembers;
		return back_DisableVirtualizationOfMembers;
	}
	public boolean set_ForceLimitedGotos(boolean new_ForceLimitedGotos){
		boolean back_ForceLimitedGotos = p_ForceLimitedGotos;
		p_ForceLimitedGotos = new_ForceLimitedGotos;
		return back_ForceLimitedGotos;
	}
	public boolean set_UseRuntimeTypeInformation(boolean new_UseRuntimeTypeInformation){
		boolean back_UseRuntimeTypeInformation = p_UseRuntimeTypeInformation;
		p_UseRuntimeTypeInformation = new_UseRuntimeTypeInformation;
		return back_UseRuntimeTypeInformation;
	}
	public boolean set_UseRuntimeReflection(boolean new_UseRuntimeReflection){
		boolean back_UseRuntimeReflection = p_UseRuntimeReflection;
		p_UseRuntimeReflection = new_UseRuntimeReflection;
		return back_UseRuntimeReflection;
	}
	public boolean set_LimitRuntimeReflectionToModuleOnly(boolean new_LimitRuntimeReflectionToModuleOnly){
		boolean back_LimitRuntimeReflectionToModuleOnly = p_LimitRuntimeReflectionToModuleOnly;
		p_LimitRuntimeReflectionToModuleOnly = new_LimitRuntimeReflectionToModuleOnly;
		return back_LimitRuntimeReflectionToModuleOnly;
	}
	public boolean set_UseResumeExceptionModel(boolean new_UseResumeExceptionModel){
		boolean back_UseResumeExceptionModel = p_UseResumeExceptionModel;
		p_UseResumeExceptionModel = new_UseResumeExceptionModel;
		return back_UseResumeExceptionModel;
	}
	public boolean set_UseTerminationExceptionModel(boolean new_UseTerminationExceptionModel){
		boolean back_UseTerminationExceptionModel = p_UseTerminationExceptionModel;
		p_UseTerminationExceptionModel = new_UseTerminationExceptionModel;
		return back_UseTerminationExceptionModel;
	}

	//Funciones para setear Elementos de Secuencia
	public boolean InsertCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		if(nodeList==p_GarbageCollector)return acceptInsertNodeCallback_GarbageCollector(node, parent);
		return false;
	}
	public boolean RemoveNodeCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		return true;
	}
	public boolean acceptInsertNodeCallback_GarbageCollector(XplNode node, XplNode parent){
		if(node==null)return false;
		if(node.get_Name().equals("GarbageCollector")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplGarbageCollector){
			this.set_ErrorString("El elemento de tipo '"+node.get_ContentTypeName()+"' no es valido como componente de 'XplGarbageCollector'.");
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		this.set_ErrorString("El elemento de nombre '"+node.get_Name()+"' no es valido como componente de 'XplGarbageCollector'.");
		return false;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	public static final XplGarbageCollector new_GarbageCollector(){
		XplGarbageCollector node = new XplGarbageCollector();
		node.set_Name("GarbageCollector");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

