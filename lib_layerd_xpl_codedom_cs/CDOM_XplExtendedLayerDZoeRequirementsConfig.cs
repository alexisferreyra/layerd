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
public class XplExtendedLayerDZoeRequirementsConfig:  XplNode{

	#region Variables privadas para atributos y elementos
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
	#endregion

	#region Region de Constructores Publicos
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
	public XplExtendedLayerDZoeRequirementsConfig(bool n_ConvertUserTypesPointersToReferencies, bool n_MarkStructTypeNames, bool n_GuaranteeArgumentExpressionsExecutionOrder, bool n_ConvertSupportedOperatorsToMethods, bool n_ConvertAllExplicitOperatorsToMethods, bool n_ConvertAllImplicitOperatorsToMethods, bool n_ConvertIndexerCallsToMethodCalls, bool n_MarkIndexerCalls, bool n_ConvertPropertyCallsToMethodCalls, bool n_MarkPropertyCalls, bool n_UseDefaultForeachImplementation, bool n_MarkBoxingOperations, bool n_MarkUnboxingOperations, bool n_MarkCallMode, bool n_MarkObjectMembersFunctionCalls, bool n_MarkSimpleTypesMembersFunctionCalls, bool n_MarkArrayBaseMembersFunctionCalls, bool n_MarkStringBaseMembersFunctionCalls, bool n_IncludeCallTargets, bool n_IncludeParametersNamesInArguments, bool n_ConverEnumsToClasses, bool n_ImplementDefaultRuntimeInformation, bool n_ImplementDefaultReflectionCode, bool n_ConvertIncrementAndDecrementExpressions, bool n_GuaranteeLogicalOperatorsExecutionSemantic, bool n_DisableSourceInformation, bool n_IncludeDebugInformation, bool n_ImplementDefaultStackTraceInformation){
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
	#endregion

	#region Destructor
/*	public ~XplExtendedLayerDZoeRequirementsConfig(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
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
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplExtendedLayerDZoeRequirementsConfig;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_ConvertUserTypesPointersToReferencies != false)
			writer.WriteAttributeString( "ConvertUserTypesPointersToReferencies" ,ZoeHelper .Att_ToString(p_ConvertUserTypesPointersToReferencies) );
		if(p_MarkStructTypeNames != false)
			writer.WriteAttributeString( "MarkStructTypeNames" ,ZoeHelper .Att_ToString(p_MarkStructTypeNames) );
		if(p_GuaranteeArgumentExpressionsExecutionOrder != false)
			writer.WriteAttributeString( "GuaranteeArgumentExpressionsExecutionOrder" ,ZoeHelper .Att_ToString(p_GuaranteeArgumentExpressionsExecutionOrder) );
		if(p_ConvertSupportedOperatorsToMethods != false)
			writer.WriteAttributeString( "ConvertSupportedOperatorsToMethods" ,ZoeHelper .Att_ToString(p_ConvertSupportedOperatorsToMethods) );
		if(p_ConvertAllExplicitOperatorsToMethods != false)
			writer.WriteAttributeString( "ConvertAllExplicitOperatorsToMethods" ,ZoeHelper .Att_ToString(p_ConvertAllExplicitOperatorsToMethods) );
		if(p_ConvertAllImplicitOperatorsToMethods != false)
			writer.WriteAttributeString( "ConvertAllImplicitOperatorsToMethods" ,ZoeHelper .Att_ToString(p_ConvertAllImplicitOperatorsToMethods) );
		if(p_ConvertIndexerCallsToMethodCalls != false)
			writer.WriteAttributeString( "ConvertIndexerCallsToMethodCalls" ,ZoeHelper .Att_ToString(p_ConvertIndexerCallsToMethodCalls) );
		if(p_MarkIndexerCalls != false)
			writer.WriteAttributeString( "MarkIndexerCalls" ,ZoeHelper .Att_ToString(p_MarkIndexerCalls) );
		if(p_ConvertPropertyCallsToMethodCalls != false)
			writer.WriteAttributeString( "ConvertPropertyCallsToMethodCalls" ,ZoeHelper .Att_ToString(p_ConvertPropertyCallsToMethodCalls) );
		if(p_MarkPropertyCalls != false)
			writer.WriteAttributeString( "MarkPropertyCalls" ,ZoeHelper .Att_ToString(p_MarkPropertyCalls) );
		if(p_UseDefaultForeachImplementation != false)
			writer.WriteAttributeString( "UseDefaultForeachImplementation" ,ZoeHelper .Att_ToString(p_UseDefaultForeachImplementation) );
		if(p_MarkBoxingOperations != false)
			writer.WriteAttributeString( "MarkBoxingOperations" ,ZoeHelper .Att_ToString(p_MarkBoxingOperations) );
		if(p_MarkUnboxingOperations != false)
			writer.WriteAttributeString( "MarkUnboxingOperations" ,ZoeHelper .Att_ToString(p_MarkUnboxingOperations) );
		if(p_MarkCallMode != false)
			writer.WriteAttributeString( "MarkCallMode" ,ZoeHelper .Att_ToString(p_MarkCallMode) );
		if(p_MarkObjectMembersFunctionCalls != false)
			writer.WriteAttributeString( "MarkObjectMembersFunctionCalls" ,ZoeHelper .Att_ToString(p_MarkObjectMembersFunctionCalls) );
		if(p_MarkSimpleTypesMembersFunctionCalls != false)
			writer.WriteAttributeString( "MarkSimpleTypesMembersFunctionCalls" ,ZoeHelper .Att_ToString(p_MarkSimpleTypesMembersFunctionCalls) );
		if(p_MarkArrayBaseMembersFunctionCalls != false)
			writer.WriteAttributeString( "MarkArrayBaseMembersFunctionCalls" ,ZoeHelper .Att_ToString(p_MarkArrayBaseMembersFunctionCalls) );
		if(p_MarkStringBaseMembersFunctionCalls != false)
			writer.WriteAttributeString( "MarkStringBaseMembersFunctionCalls" ,ZoeHelper .Att_ToString(p_MarkStringBaseMembersFunctionCalls) );
		if(p_IncludeCallTargets != false)
			writer.WriteAttributeString( "IncludeCallTargets" ,ZoeHelper .Att_ToString(p_IncludeCallTargets) );
		if(p_IncludeParametersNamesInArguments != false)
			writer.WriteAttributeString( "IncludeParametersNamesInArguments" ,ZoeHelper .Att_ToString(p_IncludeParametersNamesInArguments) );
		if(p_ConverEnumsToClasses != false)
			writer.WriteAttributeString( "ConverEnumsToClasses" ,ZoeHelper .Att_ToString(p_ConverEnumsToClasses) );
		if(p_ImplementDefaultRuntimeInformation != true)
			writer.WriteAttributeString( "ImplementDefaultRuntimeInformation" ,ZoeHelper .Att_ToString(p_ImplementDefaultRuntimeInformation) );
		if(p_ImplementDefaultReflectionCode != true)
			writer.WriteAttributeString( "ImplementDefaultReflectionCode" ,ZoeHelper .Att_ToString(p_ImplementDefaultReflectionCode) );
		if(p_ConvertIncrementAndDecrementExpressions != false)
			writer.WriteAttributeString( "ConvertIncrementAndDecrementExpressions" ,ZoeHelper .Att_ToString(p_ConvertIncrementAndDecrementExpressions) );
		if(p_GuaranteeLogicalOperatorsExecutionSemantic != false)
			writer.WriteAttributeString( "GuaranteeLogicalOperatorsExecutionSemantic" ,ZoeHelper .Att_ToString(p_GuaranteeLogicalOperatorsExecutionSemantic) );
		if(p_DisableSourceInformation != false)
			writer.WriteAttributeString( "DisableSourceInformation" ,ZoeHelper .Att_ToString(p_DisableSourceInformation) );
		if(p_IncludeDebugInformation != true)
			writer.WriteAttributeString( "IncludeDebugInformation" ,ZoeHelper .Att_ToString(p_IncludeDebugInformation) );
		if(p_ImplementDefaultStackTraceInformation != false)
			writer.WriteAttributeString( "ImplementDefaultStackTraceInformation" ,ZoeHelper .Att_ToString(p_ImplementDefaultStackTraceInformation) );
		//Escribo recursivamente cada elemento hijo
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
					case "ConvertUserTypesPointersToReferencies":
						this.set_ConvertUserTypesPointersToReferencies(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "MarkStructTypeNames":
						this.set_MarkStructTypeNames(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "GuaranteeArgumentExpressionsExecutionOrder":
						this.set_GuaranteeArgumentExpressionsExecutionOrder(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "ConvertSupportedOperatorsToMethods":
						this.set_ConvertSupportedOperatorsToMethods(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "ConvertAllExplicitOperatorsToMethods":
						this.set_ConvertAllExplicitOperatorsToMethods(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "ConvertAllImplicitOperatorsToMethods":
						this.set_ConvertAllImplicitOperatorsToMethods(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "ConvertIndexerCallsToMethodCalls":
						this.set_ConvertIndexerCallsToMethodCalls(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "MarkIndexerCalls":
						this.set_MarkIndexerCalls(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "ConvertPropertyCallsToMethodCalls":
						this.set_ConvertPropertyCallsToMethodCalls(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "MarkPropertyCalls":
						this.set_MarkPropertyCalls(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "UseDefaultForeachImplementation":
						this.set_UseDefaultForeachImplementation(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "MarkBoxingOperations":
						this.set_MarkBoxingOperations(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "MarkUnboxingOperations":
						this.set_MarkUnboxingOperations(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "MarkCallMode":
						this.set_MarkCallMode(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "MarkObjectMembersFunctionCalls":
						this.set_MarkObjectMembersFunctionCalls(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "MarkSimpleTypesMembersFunctionCalls":
						this.set_MarkSimpleTypesMembersFunctionCalls(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "MarkArrayBaseMembersFunctionCalls":
						this.set_MarkArrayBaseMembersFunctionCalls(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "MarkStringBaseMembersFunctionCalls":
						this.set_MarkStringBaseMembersFunctionCalls(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "IncludeCallTargets":
						this.set_IncludeCallTargets(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "IncludeParametersNamesInArguments":
						this.set_IncludeParametersNamesInArguments(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "ConverEnumsToClasses":
						this.set_ConverEnumsToClasses(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "ImplementDefaultRuntimeInformation":
						this.set_ImplementDefaultRuntimeInformation(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "ImplementDefaultReflectionCode":
						this.set_ImplementDefaultReflectionCode(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "ConvertIncrementAndDecrementExpressions":
						this.set_ConvertIncrementAndDecrementExpressions(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "GuaranteeLogicalOperatorsExecutionSemantic":
						this.set_GuaranteeLogicalOperatorsExecutionSemantic(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "DisableSourceInformation":
						this.set_DisableSourceInformation(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "IncludeDebugInformation":
						this.set_IncludeDebugInformation(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "ImplementDefaultStackTraceInformation":
						this.set_ImplementDefaultStackTraceInformation(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Atributo '"+reader.Name+"' invalido en elemento '"+this.get_ElementName()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
				case XmlNodeType.Text:
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".No se esperaba texto o elemento hijo en este nodo.");
				case XmlNodeType.EndElement:
					break;
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
		writer.Write((int) 122 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_ConvertUserTypesPointersToReferencies );
		writer.Write( p_MarkStructTypeNames );
		writer.Write( p_GuaranteeArgumentExpressionsExecutionOrder );
		writer.Write( p_ConvertSupportedOperatorsToMethods );
		writer.Write( p_ConvertAllExplicitOperatorsToMethods );
		writer.Write( p_ConvertAllImplicitOperatorsToMethods );
		writer.Write( p_ConvertIndexerCallsToMethodCalls );
		writer.Write( p_MarkIndexerCalls );
		writer.Write( p_ConvertPropertyCallsToMethodCalls );
		writer.Write( p_MarkPropertyCalls );
		writer.Write( p_UseDefaultForeachImplementation );
		writer.Write( p_MarkBoxingOperations );
		writer.Write( p_MarkUnboxingOperations );
		writer.Write( p_MarkCallMode );
		writer.Write( p_MarkObjectMembersFunctionCalls );
		writer.Write( p_MarkSimpleTypesMembersFunctionCalls );
		writer.Write( p_MarkArrayBaseMembersFunctionCalls );
		writer.Write( p_MarkStringBaseMembersFunctionCalls );
		writer.Write( p_IncludeCallTargets );
		writer.Write( p_IncludeParametersNamesInArguments );
		writer.Write( p_ConverEnumsToClasses );
		writer.Write( p_ImplementDefaultRuntimeInformation );
		writer.Write( p_ImplementDefaultReflectionCode );
		writer.Write( p_ConvertIncrementAndDecrementExpressions );
		writer.Write( p_GuaranteeLogicalOperatorsExecutionSemantic );
		writer.Write( p_DisableSourceInformation );
		writer.Write( p_IncludeDebugInformation );
		writer.Write( p_ImplementDefaultStackTraceInformation );
		//Escribo recursivamente cada elemento hijo
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_ConvertUserTypesPointersToReferencies = reader.ReadBoolean();
		p_MarkStructTypeNames = reader.ReadBoolean();
		p_GuaranteeArgumentExpressionsExecutionOrder = reader.ReadBoolean();
		p_ConvertSupportedOperatorsToMethods = reader.ReadBoolean();
		p_ConvertAllExplicitOperatorsToMethods = reader.ReadBoolean();
		p_ConvertAllImplicitOperatorsToMethods = reader.ReadBoolean();
		p_ConvertIndexerCallsToMethodCalls = reader.ReadBoolean();
		p_MarkIndexerCalls = reader.ReadBoolean();
		p_ConvertPropertyCallsToMethodCalls = reader.ReadBoolean();
		p_MarkPropertyCalls = reader.ReadBoolean();
		p_UseDefaultForeachImplementation = reader.ReadBoolean();
		p_MarkBoxingOperations = reader.ReadBoolean();
		p_MarkUnboxingOperations = reader.ReadBoolean();
		p_MarkCallMode = reader.ReadBoolean();
		p_MarkObjectMembersFunctionCalls = reader.ReadBoolean();
		p_MarkSimpleTypesMembersFunctionCalls = reader.ReadBoolean();
		p_MarkArrayBaseMembersFunctionCalls = reader.ReadBoolean();
		p_MarkStringBaseMembersFunctionCalls = reader.ReadBoolean();
		p_IncludeCallTargets = reader.ReadBoolean();
		p_IncludeParametersNamesInArguments = reader.ReadBoolean();
		p_ConverEnumsToClasses = reader.ReadBoolean();
		p_ImplementDefaultRuntimeInformation = reader.ReadBoolean();
		p_ImplementDefaultReflectionCode = reader.ReadBoolean();
		p_ConvertIncrementAndDecrementExpressions = reader.ReadBoolean();
		p_GuaranteeLogicalOperatorsExecutionSemantic = reader.ReadBoolean();
		p_DisableSourceInformation = reader.ReadBoolean();
		p_IncludeDebugInformation = reader.ReadBoolean();
		p_ImplementDefaultStackTraceInformation = reader.ReadBoolean();
		//Lectura de Elementos
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplExtendedLayerDZoeRequirementsConfig operator +(XplExtendedLayerDZoeRequirementsConfig arg1, XplNode arg2)
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
public static XplExtendedLayerDZoeRequirementsConfig operator +(XplExtendedLayerDZoeRequirementsConfig arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public bool get_ConvertUserTypesPointersToReferencies(){
		return p_ConvertUserTypesPointersToReferencies;
	}
	public bool get_MarkStructTypeNames(){
		return p_MarkStructTypeNames;
	}
	public bool get_GuaranteeArgumentExpressionsExecutionOrder(){
		return p_GuaranteeArgumentExpressionsExecutionOrder;
	}
	public bool get_ConvertSupportedOperatorsToMethods(){
		return p_ConvertSupportedOperatorsToMethods;
	}
	public bool get_ConvertAllExplicitOperatorsToMethods(){
		return p_ConvertAllExplicitOperatorsToMethods;
	}
	public bool get_ConvertAllImplicitOperatorsToMethods(){
		return p_ConvertAllImplicitOperatorsToMethods;
	}
	public bool get_ConvertIndexerCallsToMethodCalls(){
		return p_ConvertIndexerCallsToMethodCalls;
	}
	public bool get_MarkIndexerCalls(){
		return p_MarkIndexerCalls;
	}
	public bool get_ConvertPropertyCallsToMethodCalls(){
		return p_ConvertPropertyCallsToMethodCalls;
	}
	public bool get_MarkPropertyCalls(){
		return p_MarkPropertyCalls;
	}
	public bool get_UseDefaultForeachImplementation(){
		return p_UseDefaultForeachImplementation;
	}
	public bool get_MarkBoxingOperations(){
		return p_MarkBoxingOperations;
	}
	public bool get_MarkUnboxingOperations(){
		return p_MarkUnboxingOperations;
	}
	public bool get_MarkCallMode(){
		return p_MarkCallMode;
	}
	public bool get_MarkObjectMembersFunctionCalls(){
		return p_MarkObjectMembersFunctionCalls;
	}
	public bool get_MarkSimpleTypesMembersFunctionCalls(){
		return p_MarkSimpleTypesMembersFunctionCalls;
	}
	public bool get_MarkArrayBaseMembersFunctionCalls(){
		return p_MarkArrayBaseMembersFunctionCalls;
	}
	public bool get_MarkStringBaseMembersFunctionCalls(){
		return p_MarkStringBaseMembersFunctionCalls;
	}
	public bool get_IncludeCallTargets(){
		return p_IncludeCallTargets;
	}
	public bool get_IncludeParametersNamesInArguments(){
		return p_IncludeParametersNamesInArguments;
	}
	public bool get_ConverEnumsToClasses(){
		return p_ConverEnumsToClasses;
	}
	public bool get_ImplementDefaultRuntimeInformation(){
		return p_ImplementDefaultRuntimeInformation;
	}
	public bool get_ImplementDefaultReflectionCode(){
		return p_ImplementDefaultReflectionCode;
	}
	public bool get_ConvertIncrementAndDecrementExpressions(){
		return p_ConvertIncrementAndDecrementExpressions;
	}
	public bool get_GuaranteeLogicalOperatorsExecutionSemantic(){
		return p_GuaranteeLogicalOperatorsExecutionSemantic;
	}
	public bool get_DisableSourceInformation(){
		return p_DisableSourceInformation;
	}
	public bool get_IncludeDebugInformation(){
		return p_IncludeDebugInformation;
	}
	public bool get_ImplementDefaultStackTraceInformation(){
		return p_ImplementDefaultStackTraceInformation;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[28];
		ret[0] = "ConvertUserTypesPointersToReferencies";
		ret[1] = "MarkStructTypeNames";
		ret[2] = "GuaranteeArgumentExpressionsExecutionOrder";
		ret[3] = "ConvertSupportedOperatorsToMethods";
		ret[4] = "ConvertAllExplicitOperatorsToMethods";
		ret[5] = "ConvertAllImplicitOperatorsToMethods";
		ret[6] = "ConvertIndexerCallsToMethodCalls";
		ret[7] = "MarkIndexerCalls";
		ret[8] = "ConvertPropertyCallsToMethodCalls";
		ret[9] = "MarkPropertyCalls";
		ret[10] = "UseDefaultForeachImplementation";
		ret[11] = "MarkBoxingOperations";
		ret[12] = "MarkUnboxingOperations";
		ret[13] = "MarkCallMode";
		ret[14] = "MarkObjectMembersFunctionCalls";
		ret[15] = "MarkSimpleTypesMembersFunctionCalls";
		ret[16] = "MarkArrayBaseMembersFunctionCalls";
		ret[17] = "MarkStringBaseMembersFunctionCalls";
		ret[18] = "IncludeCallTargets";
		ret[19] = "IncludeParametersNamesInArguments";
		ret[20] = "ConverEnumsToClasses";
		ret[21] = "ImplementDefaultRuntimeInformation";
		ret[22] = "ImplementDefaultReflectionCode";
		ret[23] = "ConvertIncrementAndDecrementExpressions";
		ret[24] = "GuaranteeLogicalOperatorsExecutionSemantic";
		ret[25] = "DisableSourceInformation";
		ret[26] = "IncludeDebugInformation";
		ret[27] = "ImplementDefaultStackTraceInformation";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="ConvertUserTypesPointersToReferencies") return p_ConvertUserTypesPointersToReferencies.ToString();
		if (attributeName=="MarkStructTypeNames") return p_MarkStructTypeNames.ToString();
		if (attributeName=="GuaranteeArgumentExpressionsExecutionOrder") return p_GuaranteeArgumentExpressionsExecutionOrder.ToString();
		if (attributeName=="ConvertSupportedOperatorsToMethods") return p_ConvertSupportedOperatorsToMethods.ToString();
		if (attributeName=="ConvertAllExplicitOperatorsToMethods") return p_ConvertAllExplicitOperatorsToMethods.ToString();
		if (attributeName=="ConvertAllImplicitOperatorsToMethods") return p_ConvertAllImplicitOperatorsToMethods.ToString();
		if (attributeName=="ConvertIndexerCallsToMethodCalls") return p_ConvertIndexerCallsToMethodCalls.ToString();
		if (attributeName=="MarkIndexerCalls") return p_MarkIndexerCalls.ToString();
		if (attributeName=="ConvertPropertyCallsToMethodCalls") return p_ConvertPropertyCallsToMethodCalls.ToString();
		if (attributeName=="MarkPropertyCalls") return p_MarkPropertyCalls.ToString();
		if (attributeName=="UseDefaultForeachImplementation") return p_UseDefaultForeachImplementation.ToString();
		if (attributeName=="MarkBoxingOperations") return p_MarkBoxingOperations.ToString();
		if (attributeName=="MarkUnboxingOperations") return p_MarkUnboxingOperations.ToString();
		if (attributeName=="MarkCallMode") return p_MarkCallMode.ToString();
		if (attributeName=="MarkObjectMembersFunctionCalls") return p_MarkObjectMembersFunctionCalls.ToString();
		if (attributeName=="MarkSimpleTypesMembersFunctionCalls") return p_MarkSimpleTypesMembersFunctionCalls.ToString();
		if (attributeName=="MarkArrayBaseMembersFunctionCalls") return p_MarkArrayBaseMembersFunctionCalls.ToString();
		if (attributeName=="MarkStringBaseMembersFunctionCalls") return p_MarkStringBaseMembersFunctionCalls.ToString();
		if (attributeName=="IncludeCallTargets") return p_IncludeCallTargets.ToString();
		if (attributeName=="IncludeParametersNamesInArguments") return p_IncludeParametersNamesInArguments.ToString();
		if (attributeName=="ConverEnumsToClasses") return p_ConverEnumsToClasses.ToString();
		if (attributeName=="ImplementDefaultRuntimeInformation") return p_ImplementDefaultRuntimeInformation.ToString();
		if (attributeName=="ImplementDefaultReflectionCode") return p_ImplementDefaultReflectionCode.ToString();
		if (attributeName=="ConvertIncrementAndDecrementExpressions") return p_ConvertIncrementAndDecrementExpressions.ToString();
		if (attributeName=="GuaranteeLogicalOperatorsExecutionSemantic") return p_GuaranteeLogicalOperatorsExecutionSemantic.ToString();
		if (attributeName=="DisableSourceInformation") return p_DisableSourceInformation.ToString();
		if (attributeName=="IncludeDebugInformation") return p_IncludeDebugInformation.ToString();
		if (attributeName=="ImplementDefaultStackTraceInformation") return p_ImplementDefaultStackTraceInformation.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public bool set_ConvertUserTypesPointersToReferencies(bool new_ConvertUserTypesPointersToReferencies){
		bool back_ConvertUserTypesPointersToReferencies = p_ConvertUserTypesPointersToReferencies;
		p_ConvertUserTypesPointersToReferencies = new_ConvertUserTypesPointersToReferencies;
		return back_ConvertUserTypesPointersToReferencies;
	}
	public bool set_MarkStructTypeNames(bool new_MarkStructTypeNames){
		bool back_MarkStructTypeNames = p_MarkStructTypeNames;
		p_MarkStructTypeNames = new_MarkStructTypeNames;
		return back_MarkStructTypeNames;
	}
	public bool set_GuaranteeArgumentExpressionsExecutionOrder(bool new_GuaranteeArgumentExpressionsExecutionOrder){
		bool back_GuaranteeArgumentExpressionsExecutionOrder = p_GuaranteeArgumentExpressionsExecutionOrder;
		p_GuaranteeArgumentExpressionsExecutionOrder = new_GuaranteeArgumentExpressionsExecutionOrder;
		return back_GuaranteeArgumentExpressionsExecutionOrder;
	}
	public bool set_ConvertSupportedOperatorsToMethods(bool new_ConvertSupportedOperatorsToMethods){
		bool back_ConvertSupportedOperatorsToMethods = p_ConvertSupportedOperatorsToMethods;
		p_ConvertSupportedOperatorsToMethods = new_ConvertSupportedOperatorsToMethods;
		return back_ConvertSupportedOperatorsToMethods;
	}
	public bool set_ConvertAllExplicitOperatorsToMethods(bool new_ConvertAllExplicitOperatorsToMethods){
		bool back_ConvertAllExplicitOperatorsToMethods = p_ConvertAllExplicitOperatorsToMethods;
		p_ConvertAllExplicitOperatorsToMethods = new_ConvertAllExplicitOperatorsToMethods;
		return back_ConvertAllExplicitOperatorsToMethods;
	}
	public bool set_ConvertAllImplicitOperatorsToMethods(bool new_ConvertAllImplicitOperatorsToMethods){
		bool back_ConvertAllImplicitOperatorsToMethods = p_ConvertAllImplicitOperatorsToMethods;
		p_ConvertAllImplicitOperatorsToMethods = new_ConvertAllImplicitOperatorsToMethods;
		return back_ConvertAllImplicitOperatorsToMethods;
	}
	public bool set_ConvertIndexerCallsToMethodCalls(bool new_ConvertIndexerCallsToMethodCalls){
		bool back_ConvertIndexerCallsToMethodCalls = p_ConvertIndexerCallsToMethodCalls;
		p_ConvertIndexerCallsToMethodCalls = new_ConvertIndexerCallsToMethodCalls;
		return back_ConvertIndexerCallsToMethodCalls;
	}
	public bool set_MarkIndexerCalls(bool new_MarkIndexerCalls){
		bool back_MarkIndexerCalls = p_MarkIndexerCalls;
		p_MarkIndexerCalls = new_MarkIndexerCalls;
		return back_MarkIndexerCalls;
	}
	public bool set_ConvertPropertyCallsToMethodCalls(bool new_ConvertPropertyCallsToMethodCalls){
		bool back_ConvertPropertyCallsToMethodCalls = p_ConvertPropertyCallsToMethodCalls;
		p_ConvertPropertyCallsToMethodCalls = new_ConvertPropertyCallsToMethodCalls;
		return back_ConvertPropertyCallsToMethodCalls;
	}
	public bool set_MarkPropertyCalls(bool new_MarkPropertyCalls){
		bool back_MarkPropertyCalls = p_MarkPropertyCalls;
		p_MarkPropertyCalls = new_MarkPropertyCalls;
		return back_MarkPropertyCalls;
	}
	public bool set_UseDefaultForeachImplementation(bool new_UseDefaultForeachImplementation){
		bool back_UseDefaultForeachImplementation = p_UseDefaultForeachImplementation;
		p_UseDefaultForeachImplementation = new_UseDefaultForeachImplementation;
		return back_UseDefaultForeachImplementation;
	}
	public bool set_MarkBoxingOperations(bool new_MarkBoxingOperations){
		bool back_MarkBoxingOperations = p_MarkBoxingOperations;
		p_MarkBoxingOperations = new_MarkBoxingOperations;
		return back_MarkBoxingOperations;
	}
	public bool set_MarkUnboxingOperations(bool new_MarkUnboxingOperations){
		bool back_MarkUnboxingOperations = p_MarkUnboxingOperations;
		p_MarkUnboxingOperations = new_MarkUnboxingOperations;
		return back_MarkUnboxingOperations;
	}
	public bool set_MarkCallMode(bool new_MarkCallMode){
		bool back_MarkCallMode = p_MarkCallMode;
		p_MarkCallMode = new_MarkCallMode;
		return back_MarkCallMode;
	}
	public bool set_MarkObjectMembersFunctionCalls(bool new_MarkObjectMembersFunctionCalls){
		bool back_MarkObjectMembersFunctionCalls = p_MarkObjectMembersFunctionCalls;
		p_MarkObjectMembersFunctionCalls = new_MarkObjectMembersFunctionCalls;
		return back_MarkObjectMembersFunctionCalls;
	}
	public bool set_MarkSimpleTypesMembersFunctionCalls(bool new_MarkSimpleTypesMembersFunctionCalls){
		bool back_MarkSimpleTypesMembersFunctionCalls = p_MarkSimpleTypesMembersFunctionCalls;
		p_MarkSimpleTypesMembersFunctionCalls = new_MarkSimpleTypesMembersFunctionCalls;
		return back_MarkSimpleTypesMembersFunctionCalls;
	}
	public bool set_MarkArrayBaseMembersFunctionCalls(bool new_MarkArrayBaseMembersFunctionCalls){
		bool back_MarkArrayBaseMembersFunctionCalls = p_MarkArrayBaseMembersFunctionCalls;
		p_MarkArrayBaseMembersFunctionCalls = new_MarkArrayBaseMembersFunctionCalls;
		return back_MarkArrayBaseMembersFunctionCalls;
	}
	public bool set_MarkStringBaseMembersFunctionCalls(bool new_MarkStringBaseMembersFunctionCalls){
		bool back_MarkStringBaseMembersFunctionCalls = p_MarkStringBaseMembersFunctionCalls;
		p_MarkStringBaseMembersFunctionCalls = new_MarkStringBaseMembersFunctionCalls;
		return back_MarkStringBaseMembersFunctionCalls;
	}
	public bool set_IncludeCallTargets(bool new_IncludeCallTargets){
		bool back_IncludeCallTargets = p_IncludeCallTargets;
		p_IncludeCallTargets = new_IncludeCallTargets;
		return back_IncludeCallTargets;
	}
	public bool set_IncludeParametersNamesInArguments(bool new_IncludeParametersNamesInArguments){
		bool back_IncludeParametersNamesInArguments = p_IncludeParametersNamesInArguments;
		p_IncludeParametersNamesInArguments = new_IncludeParametersNamesInArguments;
		return back_IncludeParametersNamesInArguments;
	}
	public bool set_ConverEnumsToClasses(bool new_ConverEnumsToClasses){
		bool back_ConverEnumsToClasses = p_ConverEnumsToClasses;
		p_ConverEnumsToClasses = new_ConverEnumsToClasses;
		return back_ConverEnumsToClasses;
	}
	public bool set_ImplementDefaultRuntimeInformation(bool new_ImplementDefaultRuntimeInformation){
		bool back_ImplementDefaultRuntimeInformation = p_ImplementDefaultRuntimeInformation;
		p_ImplementDefaultRuntimeInformation = new_ImplementDefaultRuntimeInformation;
		return back_ImplementDefaultRuntimeInformation;
	}
	public bool set_ImplementDefaultReflectionCode(bool new_ImplementDefaultReflectionCode){
		bool back_ImplementDefaultReflectionCode = p_ImplementDefaultReflectionCode;
		p_ImplementDefaultReflectionCode = new_ImplementDefaultReflectionCode;
		return back_ImplementDefaultReflectionCode;
	}
	public bool set_ConvertIncrementAndDecrementExpressions(bool new_ConvertIncrementAndDecrementExpressions){
		bool back_ConvertIncrementAndDecrementExpressions = p_ConvertIncrementAndDecrementExpressions;
		p_ConvertIncrementAndDecrementExpressions = new_ConvertIncrementAndDecrementExpressions;
		return back_ConvertIncrementAndDecrementExpressions;
	}
	public bool set_GuaranteeLogicalOperatorsExecutionSemantic(bool new_GuaranteeLogicalOperatorsExecutionSemantic){
		bool back_GuaranteeLogicalOperatorsExecutionSemantic = p_GuaranteeLogicalOperatorsExecutionSemantic;
		p_GuaranteeLogicalOperatorsExecutionSemantic = new_GuaranteeLogicalOperatorsExecutionSemantic;
		return back_GuaranteeLogicalOperatorsExecutionSemantic;
	}
	public bool set_DisableSourceInformation(bool new_DisableSourceInformation){
		bool back_DisableSourceInformation = p_DisableSourceInformation;
		p_DisableSourceInformation = new_DisableSourceInformation;
		return back_DisableSourceInformation;
	}
	public bool set_IncludeDebugInformation(bool new_IncludeDebugInformation){
		bool back_IncludeDebugInformation = p_IncludeDebugInformation;
		p_IncludeDebugInformation = new_IncludeDebugInformation;
		return back_IncludeDebugInformation;
	}
	public bool set_ImplementDefaultStackTraceInformation(bool new_ImplementDefaultStackTraceInformation){
		bool back_ImplementDefaultStackTraceInformation = p_ImplementDefaultStackTraceInformation;
		p_ImplementDefaultStackTraceInformation = new_ImplementDefaultStackTraceInformation;
		return back_ImplementDefaultStackTraceInformation;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

