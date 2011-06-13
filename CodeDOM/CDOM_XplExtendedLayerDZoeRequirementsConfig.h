/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 09/04/2009 17:21:32
 *
 *	Generado por Zoe CodeDOM Generator.
 *	COPYRIGHT 2002. por Alexis Ferreyra.
 *
 *------------------------------------------------*/


#ifndef __LAYERD_CODEDOM_ZOEEXTENDEDLAYERDZOEREQUIREMENTSCONFIG_V1_0
#define __LAYERD_CODEDOM_ZOEEXTENDEDLAYERDZOEREQUIREMENTSCONFIG_V1_0
#include "CDOM_IncludeAll.h"

namespace CodeDOM{

class XplExtendedLayerDZoeRequirementsConfig: public  XplNode{
private:
	//Variables para Atributos
	bool p_ConvertUserTypesPointersToReferencies;
	bool p_MarkStructTypeNames;
	bool p_GuaranteeArgumentExpressionsExecutionOrder;
	bool p_ConvertSupportedOperatorsToMethods;
	bool p_ConvertAllExplicitOperatorsToMethods;
	bool p_ConvertAllImplicitOperatorsToMethods;
	bool p_ConvertIndexerCallsToMethodCalls;
	bool p_MarkIndexerCalls;
	bool p_ConvertPropertyCallsToMethodCalls;
	bool p_MarkPropertyCalls;
	bool p_UseDefaultForeachImplementation;
	bool p_MarkBoxingOperations;
	bool p_MarkUnboxingOperations;
	bool p_MarkCallMode;
	bool p_MarkObjectMembersFunctionCalls;
	bool p_MarkSimpleTypesMembersFunctionCalls;
	bool p_MarkArrayBaseMembersFunctionCalls;
	bool p_MarkStringBaseMembersFunctionCalls;
	bool p_IncludeCallTargets;
	bool p_IncludeParametersNamesInArguments;
	bool p_ConverEnumsToClasses;
	bool p_ImplementDefaultRuntimeInformation;
	bool p_ImplementDefaultReflectionCode;
	bool p_ConvertIncrementAndDecrementExpressions;
	bool p_GuaranteeLogicalOperatorsExecutionSemantic;
	bool p_DisableSourceInformation;
	bool p_IncludeDebugInformation;
	bool p_ImplementDefaultStackTraceInformation;
public:
	//Region de Constructores Publicos
	XplExtendedLayerDZoeRequirementsConfig();
	XplExtendedLayerDZoeRequirementsConfig(bool n_ConvertUserTypesPointersToReferencies, bool n_MarkStructTypeNames, bool n_GuaranteeArgumentExpressionsExecutionOrder, bool n_ConvertSupportedOperatorsToMethods, bool n_ConvertAllExplicitOperatorsToMethods, bool n_ConvertAllImplicitOperatorsToMethods, bool n_ConvertIndexerCallsToMethodCalls, bool n_MarkIndexerCalls, bool n_ConvertPropertyCallsToMethodCalls, bool n_MarkPropertyCalls, bool n_UseDefaultForeachImplementation, bool n_MarkBoxingOperations, bool n_MarkUnboxingOperations, bool n_MarkCallMode, bool n_MarkObjectMembersFunctionCalls, bool n_MarkSimpleTypesMembersFunctionCalls, bool n_MarkArrayBaseMembersFunctionCalls, bool n_MarkStringBaseMembersFunctionCalls, bool n_IncludeCallTargets, bool n_IncludeParametersNamesInArguments, bool n_ConverEnumsToClasses, bool n_ImplementDefaultRuntimeInformation, bool n_ImplementDefaultReflectionCode, bool n_ConvertIncrementAndDecrementExpressions, bool n_GuaranteeLogicalOperatorsExecutionSemantic, bool n_DisableSourceInformation, bool n_IncludeDebugInformation, bool n_ImplementDefaultStackTraceInformation);
	//Destructor
	~XplExtendedLayerDZoeRequirementsConfig();
public:
	//Funciones Sobreescritas de XplNode
	XplNode* Clone();
	int get_TypeName(){return CODEDOMTYPES_ZOEEXTENDEDLAYERDZOEREQUIREMENTSCONFIG;}
	bool Write(XplWriter* writer);
	XplNode* Read(XplReader* reader);
public:
	//Funciones para obtener Atributos
	bool get_ConvertUserTypesPointersToReferencies();
	bool get_MarkStructTypeNames();
	bool get_GuaranteeArgumentExpressionsExecutionOrder();
	bool get_ConvertSupportedOperatorsToMethods();
	bool get_ConvertAllExplicitOperatorsToMethods();
	bool get_ConvertAllImplicitOperatorsToMethods();
	bool get_ConvertIndexerCallsToMethodCalls();
	bool get_MarkIndexerCalls();
	bool get_ConvertPropertyCallsToMethodCalls();
	bool get_MarkPropertyCalls();
	bool get_UseDefaultForeachImplementation();
	bool get_MarkBoxingOperations();
	bool get_MarkUnboxingOperations();
	bool get_MarkCallMode();
	bool get_MarkObjectMembersFunctionCalls();
	bool get_MarkSimpleTypesMembersFunctionCalls();
	bool get_MarkArrayBaseMembersFunctionCalls();
	bool get_MarkStringBaseMembersFunctionCalls();
	bool get_IncludeCallTargets();
	bool get_IncludeParametersNamesInArguments();
	bool get_ConverEnumsToClasses();
	bool get_ImplementDefaultRuntimeInformation();
	bool get_ImplementDefaultReflectionCode();
	bool get_ConvertIncrementAndDecrementExpressions();
	bool get_GuaranteeLogicalOperatorsExecutionSemantic();
	bool get_DisableSourceInformation();
	bool get_IncludeDebugInformation();
	bool get_ImplementDefaultStackTraceInformation();
public:
	//Funciones para setear Atributos
	bool set_ConvertUserTypesPointersToReferencies(bool new_ConvertUserTypesPointersToReferencies);
	bool set_MarkStructTypeNames(bool new_MarkStructTypeNames);
	bool set_GuaranteeArgumentExpressionsExecutionOrder(bool new_GuaranteeArgumentExpressionsExecutionOrder);
	bool set_ConvertSupportedOperatorsToMethods(bool new_ConvertSupportedOperatorsToMethods);
	bool set_ConvertAllExplicitOperatorsToMethods(bool new_ConvertAllExplicitOperatorsToMethods);
	bool set_ConvertAllImplicitOperatorsToMethods(bool new_ConvertAllImplicitOperatorsToMethods);
	bool set_ConvertIndexerCallsToMethodCalls(bool new_ConvertIndexerCallsToMethodCalls);
	bool set_MarkIndexerCalls(bool new_MarkIndexerCalls);
	bool set_ConvertPropertyCallsToMethodCalls(bool new_ConvertPropertyCallsToMethodCalls);
	bool set_MarkPropertyCalls(bool new_MarkPropertyCalls);
	bool set_UseDefaultForeachImplementation(bool new_UseDefaultForeachImplementation);
	bool set_MarkBoxingOperations(bool new_MarkBoxingOperations);
	bool set_MarkUnboxingOperations(bool new_MarkUnboxingOperations);
	bool set_MarkCallMode(bool new_MarkCallMode);
	bool set_MarkObjectMembersFunctionCalls(bool new_MarkObjectMembersFunctionCalls);
	bool set_MarkSimpleTypesMembersFunctionCalls(bool new_MarkSimpleTypesMembersFunctionCalls);
	bool set_MarkArrayBaseMembersFunctionCalls(bool new_MarkArrayBaseMembersFunctionCalls);
	bool set_MarkStringBaseMembersFunctionCalls(bool new_MarkStringBaseMembersFunctionCalls);
	bool set_IncludeCallTargets(bool new_IncludeCallTargets);
	bool set_IncludeParametersNamesInArguments(bool new_IncludeParametersNamesInArguments);
	bool set_ConverEnumsToClasses(bool new_ConverEnumsToClasses);
	bool set_ImplementDefaultRuntimeInformation(bool new_ImplementDefaultRuntimeInformation);
	bool set_ImplementDefaultReflectionCode(bool new_ImplementDefaultReflectionCode);
	bool set_ConvertIncrementAndDecrementExpressions(bool new_ConvertIncrementAndDecrementExpressions);
	bool set_GuaranteeLogicalOperatorsExecutionSemantic(bool new_GuaranteeLogicalOperatorsExecutionSemantic);
	bool set_DisableSourceInformation(bool new_DisableSourceInformation);
	bool set_IncludeDebugInformation(bool new_IncludeDebugInformation);
	bool set_ImplementDefaultStackTraceInformation(bool new_ImplementDefaultStackTraceInformation);
};	//Fin declaración de Clase

}

#endif
