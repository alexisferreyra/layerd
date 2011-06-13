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

public class XplExtendedLayerDZoeRequirementsConfig extends  XplNode{

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	boolean p_ConvertUserTypesPointersToReferencies;
	boolean p_MarkStructTypeNames;
	boolean p_GuaranteeArgumentExpressionsExecutionOrder;
	boolean p_ConvertSupportedOperatorsToMethods;
	boolean p_ConvertAllExplicitOperatorsToMethods;
	boolean p_ConvertAllImplicitOperatorsToMethods;
	boolean p_ConvertIndexerCallsToMethodCalls;
	boolean p_MarkIndexerCalls;
	boolean p_ConvertPropertyCallsToMethodCalls;
	boolean p_MarkPropertyCalls;
	boolean p_UseDefaultForeachImplementation;
	boolean p_MarkBoxingOperations;
	boolean p_MarkUnboxingOperations;
	boolean p_MarkCallMode;
	boolean p_MarkObjectMembersFunctionCalls;
	boolean p_MarkSimpleTypesMembersFunctionCalls;
	boolean p_MarkArrayBaseMembersFunctionCalls;
	boolean p_MarkStringBaseMembersFunctionCalls;
	boolean p_IncludeCallTargets;
	boolean p_IncludeParametersNamesInArguments;
	boolean p_ConverEnumsToClasses;
	boolean p_ImplementDefaultRuntimeInformation;
	boolean p_ImplementDefaultReflectionCode;
	boolean p_ConvertIncrementAndDecrementExpressions;
	boolean p_GuaranteeLogicalOperatorsExecutionSemantic;
	boolean p_DisableSourceInformation;
	boolean p_IncludeDebugInformation;
	boolean p_ImplementDefaultStackTraceInformation;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplExtendedLayerDZoeRequirementsConfig(){
		p_ConvertUserTypesPointersToReferencies = false;
		p_MarkStructTypeNames = false;
		p_GuaranteeArgumentExpressionsExecutionOrder = false;
		p_ConvertSupportedOperatorsToMethods = false;
		p_ConvertAllExplicitOperatorsToMethods = false;
		p_ConvertAllImplicitOperatorsToMethods = false;
		p_ConvertIndexerCallsToMethodCalls = false;
		p_MarkIndexerCalls = false;
		p_ConvertPropertyCallsToMethodCalls = false;
		p_MarkPropertyCalls = false;
		p_UseDefaultForeachImplementation = false;
		p_MarkBoxingOperations = false;
		p_MarkUnboxingOperations = false;
		p_MarkCallMode = false;
		p_MarkObjectMembersFunctionCalls = false;
		p_MarkSimpleTypesMembersFunctionCalls = false;
		p_MarkArrayBaseMembersFunctionCalls = false;
		p_MarkStringBaseMembersFunctionCalls = false;
		p_IncludeCallTargets = false;
		p_IncludeParametersNamesInArguments = false;
		p_ConverEnumsToClasses = false;
		p_ImplementDefaultRuntimeInformation = true;
		p_ImplementDefaultReflectionCode = true;
		p_ConvertIncrementAndDecrementExpressions = false;
		p_GuaranteeLogicalOperatorsExecutionSemantic = false;
		p_DisableSourceInformation = false;
		p_IncludeDebugInformation = true;
		p_ImplementDefaultStackTraceInformation = false;
	}
	public XplExtendedLayerDZoeRequirementsConfig(boolean n_ConvertUserTypesPointersToReferencies, boolean n_MarkStructTypeNames, boolean n_GuaranteeArgumentExpressionsExecutionOrder, boolean n_ConvertSupportedOperatorsToMethods, boolean n_ConvertAllExplicitOperatorsToMethods, boolean n_ConvertAllImplicitOperatorsToMethods, boolean n_ConvertIndexerCallsToMethodCalls, boolean n_MarkIndexerCalls, boolean n_ConvertPropertyCallsToMethodCalls, boolean n_MarkPropertyCalls, boolean n_UseDefaultForeachImplementation, boolean n_MarkBoxingOperations, boolean n_MarkUnboxingOperations, boolean n_MarkCallMode, boolean n_MarkObjectMembersFunctionCalls, boolean n_MarkSimpleTypesMembersFunctionCalls, boolean n_MarkArrayBaseMembersFunctionCalls, boolean n_MarkStringBaseMembersFunctionCalls, boolean n_IncludeCallTargets, boolean n_IncludeParametersNamesInArguments, boolean n_ConverEnumsToClasses, boolean n_ImplementDefaultRuntimeInformation, boolean n_ImplementDefaultReflectionCode, boolean n_ConvertIncrementAndDecrementExpressions, boolean n_GuaranteeLogicalOperatorsExecutionSemantic, boolean n_DisableSourceInformation, boolean n_IncludeDebugInformation, boolean n_ImplementDefaultStackTraceInformation){
		p_ConvertUserTypesPointersToReferencies = false;
		p_MarkStructTypeNames = false;
		p_GuaranteeArgumentExpressionsExecutionOrder = false;
		p_ConvertSupportedOperatorsToMethods = false;
		p_ConvertAllExplicitOperatorsToMethods = false;
		p_ConvertAllImplicitOperatorsToMethods = false;
		p_ConvertIndexerCallsToMethodCalls = false;
		p_MarkIndexerCalls = false;
		p_ConvertPropertyCallsToMethodCalls = false;
		p_MarkPropertyCalls = false;
		p_UseDefaultForeachImplementation = false;
		p_MarkBoxingOperations = false;
		p_MarkUnboxingOperations = false;
		p_MarkCallMode = false;
		p_MarkObjectMembersFunctionCalls = false;
		p_MarkSimpleTypesMembersFunctionCalls = false;
		p_MarkArrayBaseMembersFunctionCalls = false;
		p_MarkStringBaseMembersFunctionCalls = false;
		p_IncludeCallTargets = false;
		p_IncludeParametersNamesInArguments = false;
		p_ConverEnumsToClasses = false;
		p_ImplementDefaultRuntimeInformation = true;
		p_ImplementDefaultReflectionCode = true;
		p_ConvertIncrementAndDecrementExpressions = false;
		p_GuaranteeLogicalOperatorsExecutionSemantic = false;
		p_DisableSourceInformation = false;
		p_IncludeDebugInformation = true;
		p_ImplementDefaultStackTraceInformation = false;
		set_ConvertUserTypesPointersToReferencies(n_ConvertUserTypesPointersToReferencies);
		set_MarkStructTypeNames(n_MarkStructTypeNames);
		set_GuaranteeArgumentExpressionsExecutionOrder(n_GuaranteeArgumentExpressionsExecutionOrder);
		set_ConvertSupportedOperatorsToMethods(n_ConvertSupportedOperatorsToMethods);
		set_ConvertAllExplicitOperatorsToMethods(n_ConvertAllExplicitOperatorsToMethods);
		set_ConvertAllImplicitOperatorsToMethods(n_ConvertAllImplicitOperatorsToMethods);
		set_ConvertIndexerCallsToMethodCalls(n_ConvertIndexerCallsToMethodCalls);
		set_MarkIndexerCalls(n_MarkIndexerCalls);
		set_ConvertPropertyCallsToMethodCalls(n_ConvertPropertyCallsToMethodCalls);
		set_MarkPropertyCalls(n_MarkPropertyCalls);
		set_UseDefaultForeachImplementation(n_UseDefaultForeachImplementation);
		set_MarkBoxingOperations(n_MarkBoxingOperations);
		set_MarkUnboxingOperations(n_MarkUnboxingOperations);
		set_MarkCallMode(n_MarkCallMode);
		set_MarkObjectMembersFunctionCalls(n_MarkObjectMembersFunctionCalls);
		set_MarkSimpleTypesMembersFunctionCalls(n_MarkSimpleTypesMembersFunctionCalls);
		set_MarkArrayBaseMembersFunctionCalls(n_MarkArrayBaseMembersFunctionCalls);
		set_MarkStringBaseMembersFunctionCalls(n_MarkStringBaseMembersFunctionCalls);
		set_IncludeCallTargets(n_IncludeCallTargets);
		set_IncludeParametersNamesInArguments(n_IncludeParametersNamesInArguments);
		set_ConverEnumsToClasses(n_ConverEnumsToClasses);
		set_ImplementDefaultRuntimeInformation(n_ImplementDefaultRuntimeInformation);
		set_ImplementDefaultReflectionCode(n_ImplementDefaultReflectionCode);
		set_ConvertIncrementAndDecrementExpressions(n_ConvertIncrementAndDecrementExpressions);
		set_GuaranteeLogicalOperatorsExecutionSemantic(n_GuaranteeLogicalOperatorsExecutionSemantic);
		set_DisableSourceInformation(n_DisableSourceInformation);
		set_IncludeDebugInformation(n_IncludeDebugInformation);
		set_ImplementDefaultStackTraceInformation(n_ImplementDefaultStackTraceInformation);
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplExtendedLayerDZoeRequirementsConfig copy = new XplExtendedLayerDZoeRequirementsConfig();
		copy.set_ConvertUserTypesPointersToReferencies(this.p_ConvertUserTypesPointersToReferencies);
		copy.set_MarkStructTypeNames(this.p_MarkStructTypeNames);
		copy.set_GuaranteeArgumentExpressionsExecutionOrder(this.p_GuaranteeArgumentExpressionsExecutionOrder);
		copy.set_ConvertSupportedOperatorsToMethods(this.p_ConvertSupportedOperatorsToMethods);
		copy.set_ConvertAllExplicitOperatorsToMethods(this.p_ConvertAllExplicitOperatorsToMethods);
		copy.set_ConvertAllImplicitOperatorsToMethods(this.p_ConvertAllImplicitOperatorsToMethods);
		copy.set_ConvertIndexerCallsToMethodCalls(this.p_ConvertIndexerCallsToMethodCalls);
		copy.set_MarkIndexerCalls(this.p_MarkIndexerCalls);
		copy.set_ConvertPropertyCallsToMethodCalls(this.p_ConvertPropertyCallsToMethodCalls);
		copy.set_MarkPropertyCalls(this.p_MarkPropertyCalls);
		copy.set_UseDefaultForeachImplementation(this.p_UseDefaultForeachImplementation);
		copy.set_MarkBoxingOperations(this.p_MarkBoxingOperations);
		copy.set_MarkUnboxingOperations(this.p_MarkUnboxingOperations);
		copy.set_MarkCallMode(this.p_MarkCallMode);
		copy.set_MarkObjectMembersFunctionCalls(this.p_MarkObjectMembersFunctionCalls);
		copy.set_MarkSimpleTypesMembersFunctionCalls(this.p_MarkSimpleTypesMembersFunctionCalls);
		copy.set_MarkArrayBaseMembersFunctionCalls(this.p_MarkArrayBaseMembersFunctionCalls);
		copy.set_MarkStringBaseMembersFunctionCalls(this.p_MarkStringBaseMembersFunctionCalls);
		copy.set_IncludeCallTargets(this.p_IncludeCallTargets);
		copy.set_IncludeParametersNamesInArguments(this.p_IncludeParametersNamesInArguments);
		copy.set_ConverEnumsToClasses(this.p_ConverEnumsToClasses);
		copy.set_ImplementDefaultRuntimeInformation(this.p_ImplementDefaultRuntimeInformation);
		copy.set_ImplementDefaultReflectionCode(this.p_ImplementDefaultReflectionCode);
		copy.set_ConvertIncrementAndDecrementExpressions(this.p_ConvertIncrementAndDecrementExpressions);
		copy.set_GuaranteeLogicalOperatorsExecutionSemantic(this.p_GuaranteeLogicalOperatorsExecutionSemantic);
		copy.set_DisableSourceInformation(this.p_DisableSourceInformation);
		copy.set_IncludeDebugInformation(this.p_IncludeDebugInformation);
		copy.set_ImplementDefaultStackTraceInformation(this.p_ImplementDefaultStackTraceInformation);
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplExtendedLayerDZoeRequirementsConfig;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_ConvertUserTypesPointersToReferencies != false)
			writer.WriteAttributeString( "ConvertUserTypesPointersToReferencies" ,CodeDOM_Utils.Att_ToString(p_ConvertUserTypesPointersToReferencies) );
		if(p_MarkStructTypeNames != false)
			writer.WriteAttributeString( "MarkStructTypeNames" ,CodeDOM_Utils.Att_ToString(p_MarkStructTypeNames) );
		if(p_GuaranteeArgumentExpressionsExecutionOrder != false)
			writer.WriteAttributeString( "GuaranteeArgumentExpressionsExecutionOrder" ,CodeDOM_Utils.Att_ToString(p_GuaranteeArgumentExpressionsExecutionOrder) );
		if(p_ConvertSupportedOperatorsToMethods != false)
			writer.WriteAttributeString( "ConvertSupportedOperatorsToMethods" ,CodeDOM_Utils.Att_ToString(p_ConvertSupportedOperatorsToMethods) );
		if(p_ConvertAllExplicitOperatorsToMethods != false)
			writer.WriteAttributeString( "ConvertAllExplicitOperatorsToMethods" ,CodeDOM_Utils.Att_ToString(p_ConvertAllExplicitOperatorsToMethods) );
		if(p_ConvertAllImplicitOperatorsToMethods != false)
			writer.WriteAttributeString( "ConvertAllImplicitOperatorsToMethods" ,CodeDOM_Utils.Att_ToString(p_ConvertAllImplicitOperatorsToMethods) );
		if(p_ConvertIndexerCallsToMethodCalls != false)
			writer.WriteAttributeString( "ConvertIndexerCallsToMethodCalls" ,CodeDOM_Utils.Att_ToString(p_ConvertIndexerCallsToMethodCalls) );
		if(p_MarkIndexerCalls != false)
			writer.WriteAttributeString( "MarkIndexerCalls" ,CodeDOM_Utils.Att_ToString(p_MarkIndexerCalls) );
		if(p_ConvertPropertyCallsToMethodCalls != false)
			writer.WriteAttributeString( "ConvertPropertyCallsToMethodCalls" ,CodeDOM_Utils.Att_ToString(p_ConvertPropertyCallsToMethodCalls) );
		if(p_MarkPropertyCalls != false)
			writer.WriteAttributeString( "MarkPropertyCalls" ,CodeDOM_Utils.Att_ToString(p_MarkPropertyCalls) );
		if(p_UseDefaultForeachImplementation != false)
			writer.WriteAttributeString( "UseDefaultForeachImplementation" ,CodeDOM_Utils.Att_ToString(p_UseDefaultForeachImplementation) );
		if(p_MarkBoxingOperations != false)
			writer.WriteAttributeString( "MarkBoxingOperations" ,CodeDOM_Utils.Att_ToString(p_MarkBoxingOperations) );
		if(p_MarkUnboxingOperations != false)
			writer.WriteAttributeString( "MarkUnboxingOperations" ,CodeDOM_Utils.Att_ToString(p_MarkUnboxingOperations) );
		if(p_MarkCallMode != false)
			writer.WriteAttributeString( "MarkCallMode" ,CodeDOM_Utils.Att_ToString(p_MarkCallMode) );
		if(p_MarkObjectMembersFunctionCalls != false)
			writer.WriteAttributeString( "MarkObjectMembersFunctionCalls" ,CodeDOM_Utils.Att_ToString(p_MarkObjectMembersFunctionCalls) );
		if(p_MarkSimpleTypesMembersFunctionCalls != false)
			writer.WriteAttributeString( "MarkSimpleTypesMembersFunctionCalls" ,CodeDOM_Utils.Att_ToString(p_MarkSimpleTypesMembersFunctionCalls) );
		if(p_MarkArrayBaseMembersFunctionCalls != false)
			writer.WriteAttributeString( "MarkArrayBaseMembersFunctionCalls" ,CodeDOM_Utils.Att_ToString(p_MarkArrayBaseMembersFunctionCalls) );
		if(p_MarkStringBaseMembersFunctionCalls != false)
			writer.WriteAttributeString( "MarkStringBaseMembersFunctionCalls" ,CodeDOM_Utils.Att_ToString(p_MarkStringBaseMembersFunctionCalls) );
		if(p_IncludeCallTargets != false)
			writer.WriteAttributeString( "IncludeCallTargets" ,CodeDOM_Utils.Att_ToString(p_IncludeCallTargets) );
		if(p_IncludeParametersNamesInArguments != false)
			writer.WriteAttributeString( "IncludeParametersNamesInArguments" ,CodeDOM_Utils.Att_ToString(p_IncludeParametersNamesInArguments) );
		if(p_ConverEnumsToClasses != false)
			writer.WriteAttributeString( "ConverEnumsToClasses" ,CodeDOM_Utils.Att_ToString(p_ConverEnumsToClasses) );
		if(p_ImplementDefaultRuntimeInformation != true)
			writer.WriteAttributeString( "ImplementDefaultRuntimeInformation" ,CodeDOM_Utils.Att_ToString(p_ImplementDefaultRuntimeInformation) );
		if(p_ImplementDefaultReflectionCode != true)
			writer.WriteAttributeString( "ImplementDefaultReflectionCode" ,CodeDOM_Utils.Att_ToString(p_ImplementDefaultReflectionCode) );
		if(p_ConvertIncrementAndDecrementExpressions != false)
			writer.WriteAttributeString( "ConvertIncrementAndDecrementExpressions" ,CodeDOM_Utils.Att_ToString(p_ConvertIncrementAndDecrementExpressions) );
		if(p_GuaranteeLogicalOperatorsExecutionSemantic != false)
			writer.WriteAttributeString( "GuaranteeLogicalOperatorsExecutionSemantic" ,CodeDOM_Utils.Att_ToString(p_GuaranteeLogicalOperatorsExecutionSemantic) );
		if(p_DisableSourceInformation != false)
			writer.WriteAttributeString( "DisableSourceInformation" ,CodeDOM_Utils.Att_ToString(p_DisableSourceInformation) );
		if(p_IncludeDebugInformation != true)
			writer.WriteAttributeString( "IncludeDebugInformation" ,CodeDOM_Utils.Att_ToString(p_IncludeDebugInformation) );
		if(p_ImplementDefaultStackTraceInformation != false)
			writer.WriteAttributeString( "ImplementDefaultStackTraceInformation" ,CodeDOM_Utils.Att_ToString(p_ImplementDefaultStackTraceInformation) );
		//Escribo recursivamente cada elemento hijo
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
				if(reader.Name().equals("ConvertUserTypesPointersToReferencies")){
					this.set_ConvertUserTypesPointersToReferencies(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("MarkStructTypeNames")){
					this.set_MarkStructTypeNames(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("GuaranteeArgumentExpressionsExecutionOrder")){
					this.set_GuaranteeArgumentExpressionsExecutionOrder(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("ConvertSupportedOperatorsToMethods")){
					this.set_ConvertSupportedOperatorsToMethods(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("ConvertAllExplicitOperatorsToMethods")){
					this.set_ConvertAllExplicitOperatorsToMethods(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("ConvertAllImplicitOperatorsToMethods")){
					this.set_ConvertAllImplicitOperatorsToMethods(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("ConvertIndexerCallsToMethodCalls")){
					this.set_ConvertIndexerCallsToMethodCalls(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("MarkIndexerCalls")){
					this.set_MarkIndexerCalls(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("ConvertPropertyCallsToMethodCalls")){
					this.set_ConvertPropertyCallsToMethodCalls(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("MarkPropertyCalls")){
					this.set_MarkPropertyCalls(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("UseDefaultForeachImplementation")){
					this.set_UseDefaultForeachImplementation(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("MarkBoxingOperations")){
					this.set_MarkBoxingOperations(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("MarkUnboxingOperations")){
					this.set_MarkUnboxingOperations(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("MarkCallMode")){
					this.set_MarkCallMode(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("MarkObjectMembersFunctionCalls")){
					this.set_MarkObjectMembersFunctionCalls(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("MarkSimpleTypesMembersFunctionCalls")){
					this.set_MarkSimpleTypesMembersFunctionCalls(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("MarkArrayBaseMembersFunctionCalls")){
					this.set_MarkArrayBaseMembersFunctionCalls(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("MarkStringBaseMembersFunctionCalls")){
					this.set_MarkStringBaseMembersFunctionCalls(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("IncludeCallTargets")){
					this.set_IncludeCallTargets(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("IncludeParametersNamesInArguments")){
					this.set_IncludeParametersNamesInArguments(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("ConverEnumsToClasses")){
					this.set_ConverEnumsToClasses(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("ImplementDefaultRuntimeInformation")){
					this.set_ImplementDefaultRuntimeInformation(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("ImplementDefaultReflectionCode")){
					this.set_ImplementDefaultReflectionCode(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("ConvertIncrementAndDecrementExpressions")){
					this.set_ConvertIncrementAndDecrementExpressions(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("GuaranteeLogicalOperatorsExecutionSemantic")){
					this.set_GuaranteeLogicalOperatorsExecutionSemantic(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("DisableSourceInformation")){
					this.set_DisableSourceInformation(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("IncludeDebugInformation")){
					this.set_IncludeDebugInformation(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("ImplementDefaultStackTraceInformation")){
					this.set_ImplementDefaultStackTraceInformation(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else{
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Atributo '"+reader.Name()+"' invalido en elemento '"+this.get_Name()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
				case XmlNodeType.TEXT:
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".No se esperaba texto o elemento hijo en este nodo.");
				case XmlNodeType.ENDELEMENT:
					break;
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
	public boolean get_ConvertUserTypesPointersToReferencies(){
		return p_ConvertUserTypesPointersToReferencies;
	}
	public boolean get_MarkStructTypeNames(){
		return p_MarkStructTypeNames;
	}
	public boolean get_GuaranteeArgumentExpressionsExecutionOrder(){
		return p_GuaranteeArgumentExpressionsExecutionOrder;
	}
	public boolean get_ConvertSupportedOperatorsToMethods(){
		return p_ConvertSupportedOperatorsToMethods;
	}
	public boolean get_ConvertAllExplicitOperatorsToMethods(){
		return p_ConvertAllExplicitOperatorsToMethods;
	}
	public boolean get_ConvertAllImplicitOperatorsToMethods(){
		return p_ConvertAllImplicitOperatorsToMethods;
	}
	public boolean get_ConvertIndexerCallsToMethodCalls(){
		return p_ConvertIndexerCallsToMethodCalls;
	}
	public boolean get_MarkIndexerCalls(){
		return p_MarkIndexerCalls;
	}
	public boolean get_ConvertPropertyCallsToMethodCalls(){
		return p_ConvertPropertyCallsToMethodCalls;
	}
	public boolean get_MarkPropertyCalls(){
		return p_MarkPropertyCalls;
	}
	public boolean get_UseDefaultForeachImplementation(){
		return p_UseDefaultForeachImplementation;
	}
	public boolean get_MarkBoxingOperations(){
		return p_MarkBoxingOperations;
	}
	public boolean get_MarkUnboxingOperations(){
		return p_MarkUnboxingOperations;
	}
	public boolean get_MarkCallMode(){
		return p_MarkCallMode;
	}
	public boolean get_MarkObjectMembersFunctionCalls(){
		return p_MarkObjectMembersFunctionCalls;
	}
	public boolean get_MarkSimpleTypesMembersFunctionCalls(){
		return p_MarkSimpleTypesMembersFunctionCalls;
	}
	public boolean get_MarkArrayBaseMembersFunctionCalls(){
		return p_MarkArrayBaseMembersFunctionCalls;
	}
	public boolean get_MarkStringBaseMembersFunctionCalls(){
		return p_MarkStringBaseMembersFunctionCalls;
	}
	public boolean get_IncludeCallTargets(){
		return p_IncludeCallTargets;
	}
	public boolean get_IncludeParametersNamesInArguments(){
		return p_IncludeParametersNamesInArguments;
	}
	public boolean get_ConverEnumsToClasses(){
		return p_ConverEnumsToClasses;
	}
	public boolean get_ImplementDefaultRuntimeInformation(){
		return p_ImplementDefaultRuntimeInformation;
	}
	public boolean get_ImplementDefaultReflectionCode(){
		return p_ImplementDefaultReflectionCode;
	}
	public boolean get_ConvertIncrementAndDecrementExpressions(){
		return p_ConvertIncrementAndDecrementExpressions;
	}
	public boolean get_GuaranteeLogicalOperatorsExecutionSemantic(){
		return p_GuaranteeLogicalOperatorsExecutionSemantic;
	}
	public boolean get_DisableSourceInformation(){
		return p_DisableSourceInformation;
	}
	public boolean get_IncludeDebugInformation(){
		return p_IncludeDebugInformation;
	}
	public boolean get_ImplementDefaultStackTraceInformation(){
		return p_ImplementDefaultStackTraceInformation;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public boolean set_ConvertUserTypesPointersToReferencies(boolean new_ConvertUserTypesPointersToReferencies){
		boolean back_ConvertUserTypesPointersToReferencies = p_ConvertUserTypesPointersToReferencies;
		p_ConvertUserTypesPointersToReferencies = new_ConvertUserTypesPointersToReferencies;
		return back_ConvertUserTypesPointersToReferencies;
	}
	public boolean set_MarkStructTypeNames(boolean new_MarkStructTypeNames){
		boolean back_MarkStructTypeNames = p_MarkStructTypeNames;
		p_MarkStructTypeNames = new_MarkStructTypeNames;
		return back_MarkStructTypeNames;
	}
	public boolean set_GuaranteeArgumentExpressionsExecutionOrder(boolean new_GuaranteeArgumentExpressionsExecutionOrder){
		boolean back_GuaranteeArgumentExpressionsExecutionOrder = p_GuaranteeArgumentExpressionsExecutionOrder;
		p_GuaranteeArgumentExpressionsExecutionOrder = new_GuaranteeArgumentExpressionsExecutionOrder;
		return back_GuaranteeArgumentExpressionsExecutionOrder;
	}
	public boolean set_ConvertSupportedOperatorsToMethods(boolean new_ConvertSupportedOperatorsToMethods){
		boolean back_ConvertSupportedOperatorsToMethods = p_ConvertSupportedOperatorsToMethods;
		p_ConvertSupportedOperatorsToMethods = new_ConvertSupportedOperatorsToMethods;
		return back_ConvertSupportedOperatorsToMethods;
	}
	public boolean set_ConvertAllExplicitOperatorsToMethods(boolean new_ConvertAllExplicitOperatorsToMethods){
		boolean back_ConvertAllExplicitOperatorsToMethods = p_ConvertAllExplicitOperatorsToMethods;
		p_ConvertAllExplicitOperatorsToMethods = new_ConvertAllExplicitOperatorsToMethods;
		return back_ConvertAllExplicitOperatorsToMethods;
	}
	public boolean set_ConvertAllImplicitOperatorsToMethods(boolean new_ConvertAllImplicitOperatorsToMethods){
		boolean back_ConvertAllImplicitOperatorsToMethods = p_ConvertAllImplicitOperatorsToMethods;
		p_ConvertAllImplicitOperatorsToMethods = new_ConvertAllImplicitOperatorsToMethods;
		return back_ConvertAllImplicitOperatorsToMethods;
	}
	public boolean set_ConvertIndexerCallsToMethodCalls(boolean new_ConvertIndexerCallsToMethodCalls){
		boolean back_ConvertIndexerCallsToMethodCalls = p_ConvertIndexerCallsToMethodCalls;
		p_ConvertIndexerCallsToMethodCalls = new_ConvertIndexerCallsToMethodCalls;
		return back_ConvertIndexerCallsToMethodCalls;
	}
	public boolean set_MarkIndexerCalls(boolean new_MarkIndexerCalls){
		boolean back_MarkIndexerCalls = p_MarkIndexerCalls;
		p_MarkIndexerCalls = new_MarkIndexerCalls;
		return back_MarkIndexerCalls;
	}
	public boolean set_ConvertPropertyCallsToMethodCalls(boolean new_ConvertPropertyCallsToMethodCalls){
		boolean back_ConvertPropertyCallsToMethodCalls = p_ConvertPropertyCallsToMethodCalls;
		p_ConvertPropertyCallsToMethodCalls = new_ConvertPropertyCallsToMethodCalls;
		return back_ConvertPropertyCallsToMethodCalls;
	}
	public boolean set_MarkPropertyCalls(boolean new_MarkPropertyCalls){
		boolean back_MarkPropertyCalls = p_MarkPropertyCalls;
		p_MarkPropertyCalls = new_MarkPropertyCalls;
		return back_MarkPropertyCalls;
	}
	public boolean set_UseDefaultForeachImplementation(boolean new_UseDefaultForeachImplementation){
		boolean back_UseDefaultForeachImplementation = p_UseDefaultForeachImplementation;
		p_UseDefaultForeachImplementation = new_UseDefaultForeachImplementation;
		return back_UseDefaultForeachImplementation;
	}
	public boolean set_MarkBoxingOperations(boolean new_MarkBoxingOperations){
		boolean back_MarkBoxingOperations = p_MarkBoxingOperations;
		p_MarkBoxingOperations = new_MarkBoxingOperations;
		return back_MarkBoxingOperations;
	}
	public boolean set_MarkUnboxingOperations(boolean new_MarkUnboxingOperations){
		boolean back_MarkUnboxingOperations = p_MarkUnboxingOperations;
		p_MarkUnboxingOperations = new_MarkUnboxingOperations;
		return back_MarkUnboxingOperations;
	}
	public boolean set_MarkCallMode(boolean new_MarkCallMode){
		boolean back_MarkCallMode = p_MarkCallMode;
		p_MarkCallMode = new_MarkCallMode;
		return back_MarkCallMode;
	}
	public boolean set_MarkObjectMembersFunctionCalls(boolean new_MarkObjectMembersFunctionCalls){
		boolean back_MarkObjectMembersFunctionCalls = p_MarkObjectMembersFunctionCalls;
		p_MarkObjectMembersFunctionCalls = new_MarkObjectMembersFunctionCalls;
		return back_MarkObjectMembersFunctionCalls;
	}
	public boolean set_MarkSimpleTypesMembersFunctionCalls(boolean new_MarkSimpleTypesMembersFunctionCalls){
		boolean back_MarkSimpleTypesMembersFunctionCalls = p_MarkSimpleTypesMembersFunctionCalls;
		p_MarkSimpleTypesMembersFunctionCalls = new_MarkSimpleTypesMembersFunctionCalls;
		return back_MarkSimpleTypesMembersFunctionCalls;
	}
	public boolean set_MarkArrayBaseMembersFunctionCalls(boolean new_MarkArrayBaseMembersFunctionCalls){
		boolean back_MarkArrayBaseMembersFunctionCalls = p_MarkArrayBaseMembersFunctionCalls;
		p_MarkArrayBaseMembersFunctionCalls = new_MarkArrayBaseMembersFunctionCalls;
		return back_MarkArrayBaseMembersFunctionCalls;
	}
	public boolean set_MarkStringBaseMembersFunctionCalls(boolean new_MarkStringBaseMembersFunctionCalls){
		boolean back_MarkStringBaseMembersFunctionCalls = p_MarkStringBaseMembersFunctionCalls;
		p_MarkStringBaseMembersFunctionCalls = new_MarkStringBaseMembersFunctionCalls;
		return back_MarkStringBaseMembersFunctionCalls;
	}
	public boolean set_IncludeCallTargets(boolean new_IncludeCallTargets){
		boolean back_IncludeCallTargets = p_IncludeCallTargets;
		p_IncludeCallTargets = new_IncludeCallTargets;
		return back_IncludeCallTargets;
	}
	public boolean set_IncludeParametersNamesInArguments(boolean new_IncludeParametersNamesInArguments){
		boolean back_IncludeParametersNamesInArguments = p_IncludeParametersNamesInArguments;
		p_IncludeParametersNamesInArguments = new_IncludeParametersNamesInArguments;
		return back_IncludeParametersNamesInArguments;
	}
	public boolean set_ConverEnumsToClasses(boolean new_ConverEnumsToClasses){
		boolean back_ConverEnumsToClasses = p_ConverEnumsToClasses;
		p_ConverEnumsToClasses = new_ConverEnumsToClasses;
		return back_ConverEnumsToClasses;
	}
	public boolean set_ImplementDefaultRuntimeInformation(boolean new_ImplementDefaultRuntimeInformation){
		boolean back_ImplementDefaultRuntimeInformation = p_ImplementDefaultRuntimeInformation;
		p_ImplementDefaultRuntimeInformation = new_ImplementDefaultRuntimeInformation;
		return back_ImplementDefaultRuntimeInformation;
	}
	public boolean set_ImplementDefaultReflectionCode(boolean new_ImplementDefaultReflectionCode){
		boolean back_ImplementDefaultReflectionCode = p_ImplementDefaultReflectionCode;
		p_ImplementDefaultReflectionCode = new_ImplementDefaultReflectionCode;
		return back_ImplementDefaultReflectionCode;
	}
	public boolean set_ConvertIncrementAndDecrementExpressions(boolean new_ConvertIncrementAndDecrementExpressions){
		boolean back_ConvertIncrementAndDecrementExpressions = p_ConvertIncrementAndDecrementExpressions;
		p_ConvertIncrementAndDecrementExpressions = new_ConvertIncrementAndDecrementExpressions;
		return back_ConvertIncrementAndDecrementExpressions;
	}
	public boolean set_GuaranteeLogicalOperatorsExecutionSemantic(boolean new_GuaranteeLogicalOperatorsExecutionSemantic){
		boolean back_GuaranteeLogicalOperatorsExecutionSemantic = p_GuaranteeLogicalOperatorsExecutionSemantic;
		p_GuaranteeLogicalOperatorsExecutionSemantic = new_GuaranteeLogicalOperatorsExecutionSemantic;
		return back_GuaranteeLogicalOperatorsExecutionSemantic;
	}
	public boolean set_DisableSourceInformation(boolean new_DisableSourceInformation){
		boolean back_DisableSourceInformation = p_DisableSourceInformation;
		p_DisableSourceInformation = new_DisableSourceInformation;
		return back_DisableSourceInformation;
	}
	public boolean set_IncludeDebugInformation(boolean new_IncludeDebugInformation){
		boolean back_IncludeDebugInformation = p_IncludeDebugInformation;
		p_IncludeDebugInformation = new_IncludeDebugInformation;
		return back_IncludeDebugInformation;
	}
	public boolean set_ImplementDefaultStackTraceInformation(boolean new_ImplementDefaultStackTraceInformation){
		boolean back_ImplementDefaultStackTraceInformation = p_ImplementDefaultStackTraceInformation;
		p_ImplementDefaultStackTraceInformation = new_ImplementDefaultStackTraceInformation;
		return back_ImplementDefaultStackTraceInformation;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para obtener nuevos nodos hijos
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

