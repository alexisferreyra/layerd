/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOELAYERDZOEPROGRAMREQUIREMENTS_V1_0
#define __LAYERD_CODEDOM_ZOELAYERDZOEPROGRAMREQUIREMENTS_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplLayerDZoeProgramRequirements: public  XplNode{
private:
	//Variables para Atributos
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
	XplNodeList* p_GarbageCollector;
public:
	//Region de Constructores Publicos
	XplLayerDZoeProgramRequirements();
	XplLayerDZoeProgramRequirements(bool n_UseCaseSensitive, bool n_DisableArrayLimitsChecks, bool n_UseSinglePointAsNamespaceSeparator, bool n_UseSimpleMemberAccessAsNamespaceSeparator, bool n_UseInheritsAsImplements, bool n_UseSingleInheritance, bool n_UseUniversalObjectBase, bool n_DisableUnifiedTypeSystem, bool n_EnableIntegerOverflowExceptions, bool n_EnableFloatOperationsExceptions, bool n_RequiereFullDecimalImplementation, bool n_RequireASCIIChar, bool n_RequireASCIIString, bool n_DisableNullReferenceCheckOnMemberAccess, bool n_RequirePointerArithmetics, bool n_DisableUnsafePointerConversionsFromVoid, bool n_DisableAllPointerConversionsFromVoid, bool n_DisableAllPointerConversionsToVoid, bool n_DisableAllPointerConversionsFromIntegers, bool n_DisableAllPointerConversionsToIntegers, bool n_DisableBaseTypesArrayItemsInitialization, bool n_DisableStaticsVarsInitialization, bool n_DisableInstanceVarsInitialization, bool n_EnableLocalsVarsInitialization, bool n_IgnorePreviousAssingmentRules, bool n_EnablePointerAssingnationWarningsAsErrors, bool n_DisablePointerAssingnationWarnings, bool n_DisableAddressOfExpressionRequirementOnOutArguments, bool n_DisableForcingFinalizeAsDestructor, bool n_ForceNormalVirtualFunctionCallsOnConstructorsBody, bool n_DisableVirtualizationOfMembers, bool n_ForceLimitedGotos, bool n_UseRuntimeTypeInformation, bool n_UseRuntimeReflection, bool n_LimitRuntimeReflectionToModuleOnly, bool n_UseResumeExceptionModel, bool n_UseTerminationExceptionModel);
	XplLayerDZoeProgramRequirements(bool n_UseCaseSensitive, string n_SetDefaultSafeArrays, bool n_DisableArrayLimitsChecks, bool n_UseSinglePointAsNamespaceSeparator, bool n_UseSimpleMemberAccessAsNamespaceSeparator, bool n_UseInheritsAsImplements, string n_SetDefaultIdentifiersNamespace, string n_SetDefaultGarbageCollector, bool n_UseSingleInheritance, bool n_UseUniversalObjectBase, string n_SetUniversalObjectBase, bool n_DisableUnifiedTypeSystem, bool n_EnableIntegerOverflowExceptions, bool n_EnableFloatOperationsExceptions, bool n_RequiereFullDecimalImplementation, bool n_RequireASCIIChar, bool n_RequireASCIIString, string n_SetASCIIStringClass, string n_SetStringClass, bool n_DisableNullReferenceCheckOnMemberAccess, bool n_RequirePointerArithmetics, bool n_DisableUnsafePointerConversionsFromVoid, bool n_DisableAllPointerConversionsFromVoid, bool n_DisableAllPointerConversionsToVoid, bool n_DisableAllPointerConversionsFromIntegers, bool n_DisableAllPointerConversionsToIntegers, int n_SetNullIntegerValue, bool n_DisableBaseTypesArrayItemsInitialization, bool n_DisableStaticsVarsInitialization, bool n_DisableInstanceVarsInitialization, bool n_EnableLocalsVarsInitialization, bool n_IgnorePreviousAssingmentRules, bool n_EnablePointerAssingnationWarningsAsErrors, bool n_DisablePointerAssingnationWarnings, bool n_DisableAddressOfExpressionRequirementOnOutArguments, bool n_DisableForcingFinalizeAsDestructor, bool n_ForceNormalVirtualFunctionCallsOnConstructorsBody, bool n_DisableVirtualizationOfMembers, bool n_ForceLimitedGotos, bool n_UseRuntimeTypeInformation, bool n_UseRuntimeReflection, bool n_LimitRuntimeReflectionToModuleOnly, bool n_UseResumeExceptionModel, bool n_UseTerminationExceptionModel);
	XplLayerDZoeProgramRequirements(XplNodeList* n_GarbageCollector);
	XplLayerDZoeProgramRequirements(bool n_UseCaseSensitive, bool n_DisableArrayLimitsChecks, bool n_UseSinglePointAsNamespaceSeparator, bool n_UseSimpleMemberAccessAsNamespaceSeparator, bool n_UseInheritsAsImplements, bool n_UseSingleInheritance, bool n_UseUniversalObjectBase, bool n_DisableUnifiedTypeSystem, bool n_EnableIntegerOverflowExceptions, bool n_EnableFloatOperationsExceptions, bool n_RequiereFullDecimalImplementation, bool n_RequireASCIIChar, bool n_RequireASCIIString, bool n_DisableNullReferenceCheckOnMemberAccess, bool n_RequirePointerArithmetics, bool n_DisableUnsafePointerConversionsFromVoid, bool n_DisableAllPointerConversionsFromVoid, bool n_DisableAllPointerConversionsToVoid, bool n_DisableAllPointerConversionsFromIntegers, bool n_DisableAllPointerConversionsToIntegers, bool n_DisableBaseTypesArrayItemsInitialization, bool n_DisableStaticsVarsInitialization, bool n_DisableInstanceVarsInitialization, bool n_EnableLocalsVarsInitialization, bool n_IgnorePreviousAssingmentRules, bool n_EnablePointerAssingnationWarningsAsErrors, bool n_DisablePointerAssingnationWarnings, bool n_DisableAddressOfExpressionRequirementOnOutArguments, bool n_DisableForcingFinalizeAsDestructor, bool n_ForceNormalVirtualFunctionCallsOnConstructorsBody, bool n_DisableVirtualizationOfMembers, bool n_ForceLimitedGotos, bool n_UseRuntimeTypeInformation, bool n_UseRuntimeReflection, bool n_LimitRuntimeReflectionToModuleOnly, bool n_UseResumeExceptionModel, bool n_UseTerminationExceptionModel, XplNodeList* n_GarbageCollector);
	XplLayerDZoeProgramRequirements(bool n_UseCaseSensitive, string n_SetDefaultSafeArrays, bool n_DisableArrayLimitsChecks, bool n_UseSinglePointAsNamespaceSeparator, bool n_UseSimpleMemberAccessAsNamespaceSeparator, bool n_UseInheritsAsImplements, string n_SetDefaultIdentifiersNamespace, string n_SetDefaultGarbageCollector, bool n_UseSingleInheritance, bool n_UseUniversalObjectBase, string n_SetUniversalObjectBase, bool n_DisableUnifiedTypeSystem, bool n_EnableIntegerOverflowExceptions, bool n_EnableFloatOperationsExceptions, bool n_RequiereFullDecimalImplementation, bool n_RequireASCIIChar, bool n_RequireASCIIString, string n_SetASCIIStringClass, string n_SetStringClass, bool n_DisableNullReferenceCheckOnMemberAccess, bool n_RequirePointerArithmetics, bool n_DisableUnsafePointerConversionsFromVoid, bool n_DisableAllPointerConversionsFromVoid, bool n_DisableAllPointerConversionsToVoid, bool n_DisableAllPointerConversionsFromIntegers, bool n_DisableAllPointerConversionsToIntegers, int n_SetNullIntegerValue, bool n_DisableBaseTypesArrayItemsInitialization, bool n_DisableStaticsVarsInitialization, bool n_DisableInstanceVarsInitialization, bool n_EnableLocalsVarsInitialization, bool n_IgnorePreviousAssingmentRules, bool n_EnablePointerAssingnationWarningsAsErrors, bool n_DisablePointerAssingnationWarnings, bool n_DisableAddressOfExpressionRequirementOnOutArguments, bool n_DisableForcingFinalizeAsDestructor, bool n_ForceNormalVirtualFunctionCallsOnConstructorsBody, bool n_DisableVirtualizationOfMembers, bool n_ForceLimitedGotos, bool n_UseRuntimeTypeInformation, bool n_UseRuntimeReflection, bool n_LimitRuntimeReflectionToModuleOnly, bool n_UseResumeExceptionModel, bool n_UseTerminationExceptionModel, XplNodeList* n_GarbageCollector);
	//Destructor
	~XplLayerDZoeProgramRequirements();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOELAYERDZOEPROGRAMREQUIREMENTS;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	bool get_UseCaseSensitive();
	string get_SetDefaultSafeArrays();
	bool get_DisableArrayLimitsChecks();
	bool get_UseSinglePointAsNamespaceSeparator();
	bool get_UseSimpleMemberAccessAsNamespaceSeparator();
	bool get_UseInheritsAsImplements();
	string get_SetDefaultIdentifiersNamespace();
	string get_SetDefaultGarbageCollector();
	bool get_UseSingleInheritance();
	bool get_UseUniversalObjectBase();
	string get_SetUniversalObjectBase();
	bool get_DisableUnifiedTypeSystem();
	bool get_EnableIntegerOverflowExceptions();
	bool get_EnableFloatOperationsExceptions();
	bool get_RequiereFullDecimalImplementation();
	bool get_RequireASCIIChar();
	bool get_RequireASCIIString();
	string get_SetASCIIStringClass();
	string get_SetStringClass();
	bool get_DisableNullReferenceCheckOnMemberAccess();
	bool get_RequirePointerArithmetics();
	bool get_DisableUnsafePointerConversionsFromVoid();
	bool get_DisableAllPointerConversionsFromVoid();
	bool get_DisableAllPointerConversionsToVoid();
	bool get_DisableAllPointerConversionsFromIntegers();
	bool get_DisableAllPointerConversionsToIntegers();
	int get_SetNullIntegerValue();
	bool get_DisableBaseTypesArrayItemsInitialization();
	bool get_DisableStaticsVarsInitialization();
	bool get_DisableInstanceVarsInitialization();
	bool get_EnableLocalsVarsInitialization();
	bool get_IgnorePreviousAssingmentRules();
	bool get_EnablePointerAssingnationWarningsAsErrors();
	bool get_DisablePointerAssingnationWarnings();
	bool get_DisableAddressOfExpressionRequirementOnOutArguments();
	bool get_DisableForcingFinalizeAsDestructor();
	bool get_ForceNormalVirtualFunctionCallsOnConstructorsBody();
	bool get_DisableVirtualizationOfMembers();
	bool get_ForceLimitedGotos();
	bool get_UseRuntimeTypeInformation();
	bool get_UseRuntimeReflection();
	bool get_LimitRuntimeReflectionToModuleOnly();
	bool get_UseResumeExceptionModel();
	bool get_UseTerminationExceptionModel();
	//Funciones para obtener Elementos de Secuencia
	XplNodeList* get_GarbageCollector();
public:
	//Funciones para setear Atributos
	bool set_UseCaseSensitive(bool new_UseCaseSensitive);
	string set_SetDefaultSafeArrays(string new_SetDefaultSafeArrays);
	bool set_DisableArrayLimitsChecks(bool new_DisableArrayLimitsChecks);
	bool set_UseSinglePointAsNamespaceSeparator(bool new_UseSinglePointAsNamespaceSeparator);
	bool set_UseSimpleMemberAccessAsNamespaceSeparator(bool new_UseSimpleMemberAccessAsNamespaceSeparator);
	bool set_UseInheritsAsImplements(bool new_UseInheritsAsImplements);
	string set_SetDefaultIdentifiersNamespace(string new_SetDefaultIdentifiersNamespace);
	string set_SetDefaultGarbageCollector(string new_SetDefaultGarbageCollector);
	bool set_UseSingleInheritance(bool new_UseSingleInheritance);
	bool set_UseUniversalObjectBase(bool new_UseUniversalObjectBase);
	string set_SetUniversalObjectBase(string new_SetUniversalObjectBase);
	bool set_DisableUnifiedTypeSystem(bool new_DisableUnifiedTypeSystem);
	bool set_EnableIntegerOverflowExceptions(bool new_EnableIntegerOverflowExceptions);
	bool set_EnableFloatOperationsExceptions(bool new_EnableFloatOperationsExceptions);
	bool set_RequiereFullDecimalImplementation(bool new_RequiereFullDecimalImplementation);
	bool set_RequireASCIIChar(bool new_RequireASCIIChar);
	bool set_RequireASCIIString(bool new_RequireASCIIString);
	string set_SetASCIIStringClass(string new_SetASCIIStringClass);
	string set_SetStringClass(string new_SetStringClass);
	bool set_DisableNullReferenceCheckOnMemberAccess(bool new_DisableNullReferenceCheckOnMemberAccess);
	bool set_RequirePointerArithmetics(bool new_RequirePointerArithmetics);
	bool set_DisableUnsafePointerConversionsFromVoid(bool new_DisableUnsafePointerConversionsFromVoid);
	bool set_DisableAllPointerConversionsFromVoid(bool new_DisableAllPointerConversionsFromVoid);
	bool set_DisableAllPointerConversionsToVoid(bool new_DisableAllPointerConversionsToVoid);
	bool set_DisableAllPointerConversionsFromIntegers(bool new_DisableAllPointerConversionsFromIntegers);
	bool set_DisableAllPointerConversionsToIntegers(bool new_DisableAllPointerConversionsToIntegers);
	int set_SetNullIntegerValue(int new_SetNullIntegerValue);
	bool set_DisableBaseTypesArrayItemsInitialization(bool new_DisableBaseTypesArrayItemsInitialization);
	bool set_DisableStaticsVarsInitialization(bool new_DisableStaticsVarsInitialization);
	bool set_DisableInstanceVarsInitialization(bool new_DisableInstanceVarsInitialization);
	bool set_EnableLocalsVarsInitialization(bool new_EnableLocalsVarsInitialization);
	bool set_IgnorePreviousAssingmentRules(bool new_IgnorePreviousAssingmentRules);
	bool set_EnablePointerAssingnationWarningsAsErrors(bool new_EnablePointerAssingnationWarningsAsErrors);
	bool set_DisablePointerAssingnationWarnings(bool new_DisablePointerAssingnationWarnings);
	bool set_DisableAddressOfExpressionRequirementOnOutArguments(bool new_DisableAddressOfExpressionRequirementOnOutArguments);
	bool set_DisableForcingFinalizeAsDestructor(bool new_DisableForcingFinalizeAsDestructor);
	bool set_ForceNormalVirtualFunctionCallsOnConstructorsBody(bool new_ForceNormalVirtualFunctionCallsOnConstructorsBody);
	bool set_DisableVirtualizationOfMembers(bool new_DisableVirtualizationOfMembers);
	bool set_ForceLimitedGotos(bool new_ForceLimitedGotos);
	bool set_UseRuntimeTypeInformation(bool new_UseRuntimeTypeInformation);
	bool set_UseRuntimeReflection(bool new_UseRuntimeReflection);
	bool set_LimitRuntimeReflectionToModuleOnly(bool new_LimitRuntimeReflectionToModuleOnly);
	bool set_UseResumeExceptionModel(bool new_UseResumeExceptionModel);
	bool set_UseTerminationExceptionModel(bool new_UseTerminationExceptionModel);
	//Funciones para setear Elementos de Secuencia
protected:
	static bool acceptInsertNodeCallback_GarbageCollector(XplNode* node, string* errorMsg, XplNode* parent);
	static bool acceptRemoveNodeCallback_GarbageCollector(XplNode* node, string* errorMsg, XplNode* parent);
public:
	static XplGarbageCollector* new_GarbageCollector();
};	//Fin declaración de Clase

}

#endif
