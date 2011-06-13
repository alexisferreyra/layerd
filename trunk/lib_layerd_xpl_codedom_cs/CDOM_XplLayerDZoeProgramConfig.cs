/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 3/2/2010 9:11:43 PM
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
public class XplLayerDZoeProgramConfig:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_name;
	XplLayerDZoeProgramModuletype_enum p_moduleType;
	string p_defaultPlatform;
	string p_mainProcedureFileName;
	string p_defaultOutputFileName;
	//Variables para Elementos de Secuencia
	XplNodeList p_SourceFile;
	XplNodeList p_OutputPlatform;
	XplNodeList p_PlatformAlias;
	XplLayerDZoeProgramRequirements p_ProgramRequirements;
	#endregion

	#region Region de Constructores Publicos
	public XplLayerDZoeProgramConfig(){
		p_name = "";
		p_moduleType = XplLayerDZoeProgramModuletype_enum.EXECUTABLE;
		p_defaultPlatform = "";
		p_mainProcedureFileName = "";
		p_defaultOutputFileName = "";
		p_SourceFile = new XplNodeList();
		p_SourceFile.set_Parent(this);
		p_SourceFile.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SourceFile));
		p_SourceFile.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SourceFile));
		p_OutputPlatform = new XplNodeList();
		p_OutputPlatform.set_Parent(this);
		p_OutputPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_OutputPlatform));
		p_OutputPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_OutputPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_ProgramRequirements=null;
}
	public XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType){
		p_name = "";
		p_moduleType = XplLayerDZoeProgramModuletype_enum.EXECUTABLE;
		p_defaultPlatform = "";
		p_mainProcedureFileName = "";
		p_defaultOutputFileName = "";
		set_name(n_name);
		set_moduleType(n_moduleType);
		p_SourceFile = new XplNodeList();
		p_SourceFile.set_Parent(this);
		p_SourceFile.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SourceFile));
		p_SourceFile.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SourceFile));
		p_OutputPlatform = new XplNodeList();
		p_OutputPlatform.set_Parent(this);
		p_OutputPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_OutputPlatform));
		p_OutputPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_OutputPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_ProgramRequirements=null;
	}
	public XplLayerDZoeProgramConfig(XplNodeList n_SourceFile, XplNodeList n_OutputPlatform, XplLayerDZoeProgramRequirements n_ProgramRequirements){
		p_name = "";
		p_moduleType = XplLayerDZoeProgramModuletype_enum.EXECUTABLE;
		p_defaultPlatform = "";
		p_mainProcedureFileName = "";
		p_defaultOutputFileName = "";
		p_SourceFile = new XplNodeList();
		p_SourceFile.set_Parent(this);
		p_SourceFile.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SourceFile));
		p_SourceFile.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SourceFile));
		p_OutputPlatform = new XplNodeList();
		p_OutputPlatform.set_Parent(this);
		p_OutputPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_OutputPlatform));
		p_OutputPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_OutputPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_ProgramRequirements=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SourceFile!=null)
		for(XplNode node = n_SourceFile.FirstNode(); node != null ; node = n_SourceFile.NextNode()){
			p_SourceFile.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_OutputPlatform!=null)
		for(XplNode node = n_OutputPlatform.FirstNode(); node != null ; node = n_OutputPlatform.NextNode()){
			p_OutputPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		set_ProgramRequirements(n_ProgramRequirements);
	}
	public XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, XplNodeList n_SourceFile, XplNodeList n_OutputPlatform, XplLayerDZoeProgramRequirements n_ProgramRequirements){
		p_name = "";
		p_moduleType = XplLayerDZoeProgramModuletype_enum.EXECUTABLE;
		p_defaultPlatform = "";
		p_mainProcedureFileName = "";
		p_defaultOutputFileName = "";
		set_name(n_name);
		set_moduleType(n_moduleType);
		p_SourceFile = new XplNodeList();
		p_SourceFile.set_Parent(this);
		p_SourceFile.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SourceFile));
		p_SourceFile.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SourceFile));
		p_OutputPlatform = new XplNodeList();
		p_OutputPlatform.set_Parent(this);
		p_OutputPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_OutputPlatform));
		p_OutputPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_OutputPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_ProgramRequirements=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SourceFile!=null)
		for(XplNode node = n_SourceFile.FirstNode(); node != null ; node = n_SourceFile.NextNode()){
			p_SourceFile.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_OutputPlatform!=null)
		for(XplNode node = n_OutputPlatform.FirstNode(); node != null ; node = n_OutputPlatform.NextNode()){
			p_OutputPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		set_ProgramRequirements(n_ProgramRequirements);
	}
	public XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, string n_defaultPlatform, string n_mainProcedureFileName, string n_defaultOutputFileName){
		set_name(n_name);
		set_moduleType(n_moduleType);
		set_defaultPlatform(n_defaultPlatform);
		set_mainProcedureFileName(n_mainProcedureFileName);
		set_defaultOutputFileName(n_defaultOutputFileName);
		p_SourceFile = new XplNodeList();
		p_SourceFile.set_Parent(this);
		p_SourceFile.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SourceFile));
		p_SourceFile.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SourceFile));
		p_OutputPlatform = new XplNodeList();
		p_OutputPlatform.set_Parent(this);
		p_OutputPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_OutputPlatform));
		p_OutputPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_OutputPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_ProgramRequirements=null;
	}
	public XplLayerDZoeProgramConfig(XplNodeList n_SourceFile, XplNodeList n_OutputPlatform, XplNodeList n_PlatformAlias, XplLayerDZoeProgramRequirements n_ProgramRequirements){
		p_name = "";
		p_moduleType = XplLayerDZoeProgramModuletype_enum.EXECUTABLE;
		p_defaultPlatform = "";
		p_mainProcedureFileName = "";
		p_defaultOutputFileName = "";
		p_SourceFile = new XplNodeList();
		p_SourceFile.set_Parent(this);
		p_SourceFile.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SourceFile));
		p_SourceFile.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SourceFile));
		p_OutputPlatform = new XplNodeList();
		p_OutputPlatform.set_Parent(this);
		p_OutputPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_OutputPlatform));
		p_OutputPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_OutputPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_ProgramRequirements=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SourceFile!=null)
		for(XplNode node = n_SourceFile.FirstNode(); node != null ; node = n_SourceFile.NextNode()){
			p_SourceFile.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_OutputPlatform!=null)
		for(XplNode node = n_OutputPlatform.FirstNode(); node != null ; node = n_OutputPlatform.NextNode()){
			p_OutputPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_PlatformAlias!=null)
		for(XplNode node = n_PlatformAlias.FirstNode(); node != null ; node = n_PlatformAlias.NextNode()){
			p_PlatformAlias.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		set_ProgramRequirements(n_ProgramRequirements);
	}
	public XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, string n_defaultPlatform, string n_mainProcedureFileName, string n_defaultOutputFileName, XplNodeList n_SourceFile, XplNodeList n_OutputPlatform, XplLayerDZoeProgramRequirements n_ProgramRequirements){
		set_name(n_name);
		set_moduleType(n_moduleType);
		set_defaultPlatform(n_defaultPlatform);
		set_mainProcedureFileName(n_mainProcedureFileName);
		set_defaultOutputFileName(n_defaultOutputFileName);
		set_name(n_name);
		set_moduleType(n_moduleType);
		p_SourceFile = new XplNodeList();
		p_SourceFile.set_Parent(this);
		p_SourceFile.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SourceFile));
		p_SourceFile.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SourceFile));
		p_OutputPlatform = new XplNodeList();
		p_OutputPlatform.set_Parent(this);
		p_OutputPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_OutputPlatform));
		p_OutputPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_OutputPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_ProgramRequirements=null;
	}
	public XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, XplNodeList n_SourceFile, XplNodeList n_OutputPlatform, XplNodeList n_PlatformAlias, XplLayerDZoeProgramRequirements n_ProgramRequirements){
		p_name = "";
		p_moduleType = XplLayerDZoeProgramModuletype_enum.EXECUTABLE;
		p_defaultPlatform = "";
		p_mainProcedureFileName = "";
		p_defaultOutputFileName = "";
		set_name(n_name);
		set_moduleType(n_moduleType);
		p_SourceFile = new XplNodeList();
		p_SourceFile.set_Parent(this);
		p_SourceFile.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SourceFile));
		p_SourceFile.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SourceFile));
		p_OutputPlatform = new XplNodeList();
		p_OutputPlatform.set_Parent(this);
		p_OutputPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_OutputPlatform));
		p_OutputPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_OutputPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_ProgramRequirements=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SourceFile!=null)
		for(XplNode node = n_SourceFile.FirstNode(); node != null ; node = n_SourceFile.NextNode()){
			p_SourceFile.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_OutputPlatform!=null)
		for(XplNode node = n_OutputPlatform.FirstNode(); node != null ; node = n_OutputPlatform.NextNode()){
			p_OutputPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_PlatformAlias!=null)
		for(XplNode node = n_PlatformAlias.FirstNode(); node != null ; node = n_PlatformAlias.NextNode()){
			p_PlatformAlias.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		set_ProgramRequirements(n_ProgramRequirements);
	}
	public XplLayerDZoeProgramConfig(string n_name, XplLayerDZoeProgramModuletype_enum n_moduleType, string n_defaultPlatform, string n_mainProcedureFileName, string n_defaultOutputFileName, XplNodeList n_SourceFile, XplNodeList n_OutputPlatform, XplNodeList n_PlatformAlias, XplLayerDZoeProgramRequirements n_ProgramRequirements){
		set_name(n_name);
		set_moduleType(n_moduleType);
		set_defaultPlatform(n_defaultPlatform);
		set_mainProcedureFileName(n_mainProcedureFileName);
		set_defaultOutputFileName(n_defaultOutputFileName);
		p_SourceFile = new XplNodeList();
		p_SourceFile.set_Parent(this);
		p_SourceFile.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_SourceFile));
		p_SourceFile.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_SourceFile));
		p_OutputPlatform = new XplNodeList();
		p_OutputPlatform.set_Parent(this);
		p_OutputPlatform.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_OutputPlatform));
		p_OutputPlatform.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_OutputPlatform));
		p_PlatformAlias = new XplNodeList();
		p_PlatformAlias.set_Parent(this);
		p_PlatformAlias.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_PlatformAlias));
		p_PlatformAlias.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_PlatformAlias));
		p_ProgramRequirements=null;
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_SourceFile!=null)
		for(XplNode node = n_SourceFile.FirstNode(); node != null ; node = n_SourceFile.NextNode()){
			p_SourceFile.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_OutputPlatform!=null)
		for(XplNode node = n_OutputPlatform.FirstNode(); node != null ; node = n_OutputPlatform.NextNode()){
			p_OutputPlatform.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_PlatformAlias!=null)
		for(XplNode node = n_PlatformAlias.FirstNode(); node != null ; node = n_PlatformAlias.NextNode()){
			p_PlatformAlias.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
		set_ProgramRequirements(n_ProgramRequirements);
	}
	#endregion

	#region Destructor
/*	public ~XplLayerDZoeProgramConfig(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplLayerDZoeProgramConfig copy = new XplLayerDZoeProgramConfig();
		copy.set_name(this.p_name);
		copy.set_moduleType(this.p_moduleType);
		copy.set_defaultPlatform(this.p_defaultPlatform);
		copy.set_mainProcedureFileName(this.p_mainProcedureFileName);
		copy.set_defaultOutputFileName(this.p_defaultOutputFileName);
		for(XplNode node = p_SourceFile.FirstNode(); node != null ; node = p_SourceFile.NextNode()){
			copy.get_SourceFile().InsertAtEnd(node.Clone());
		}
		for(XplNode node = p_OutputPlatform.FirstNode(); node != null ; node = p_OutputPlatform.NextNode()){
			copy.get_OutputPlatform().InsertAtEnd(node.Clone());
		}
		for(XplNode node = p_PlatformAlias.FirstNode(); node != null ; node = p_PlatformAlias.NextNode()){
			copy.get_PlatformAlias().InsertAtEnd(node.Clone());
		}
		if(p_ProgramRequirements!=null)copy.set_ProgramRequirements((XplLayerDZoeProgramRequirements)p_ProgramRequirements.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplLayerDZoeProgramConfig;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,ZoeHelper .Att_ToString(p_name) );
		if(p_moduleType != XplLayerDZoeProgramModuletype_enum.EXECUTABLE)
			writer.WriteAttributeString( "moduleType" , CodeDOM_STV.XPLLAYERDZOEPROGRAMMODULETYPE_ENUM[(int)p_moduleType] );
		if(p_defaultPlatform != "")
			writer.WriteAttributeString( "defaultPlatform" ,ZoeHelper .Att_ToString(p_defaultPlatform) );
		if(p_mainProcedureFileName != "")
			writer.WriteAttributeString( "mainProcedureFileName" ,ZoeHelper .Att_ToString(p_mainProcedureFileName) );
		if(p_defaultOutputFileName != "")
			writer.WriteAttributeString( "defaultOutputFileName" ,ZoeHelper .Att_ToString(p_defaultOutputFileName) );
		//Escribo recursivamente cada elemento hijo
		if(p_SourceFile!=null)if(!p_SourceFile.Write(writer))result=false;
		if(p_OutputPlatform!=null)if(!p_OutputPlatform.Write(writer))result=false;
		if(p_PlatformAlias!=null)if(!p_PlatformAlias.Write(writer))result=false;
		if(p_ProgramRequirements!=null)if(!p_ProgramRequirements.Write(writer))result=false;
		//Cierro el elemento
		writer.WriteEndElement();
		return result;
	}

	public override XplNode Read(XplReader reader){
		this.set_ElementName( reader.Name );
		//Lectura de Atributos
		if( reader.HasAttributes ){
			string tmpStr="";bool flag=false;int count=0;
			for(int i=0; i < reader.AttributeCount ; i++){
				reader.MoveToAttribute(i);
				switch(reader.Name){
					case "name":
						this.set_name(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "moduleType":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLLAYERDZOEPROGRAMMODULETYPE_ENUM){
							if(str==tmpStr){this.set_moduleType((XplLayerDZoeProgramModuletype_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'moduleType' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "defaultPlatform":
						this.set_defaultPlatform(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "mainProcedureFileName":
						this.set_mainProcedureFileName(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "defaultOutputFileName":
						this.set_defaultOutputFileName(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Atributo '"+reader.Name+"' invalido en elemento '"+this.get_ElementName()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		//Borro todo posible nodo en memoria
		this.p_ProgramRequirements=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "SourceFile":
						tempNode = new XplSourceFile();
						tempNode.Read(reader);
						this.get_SourceFile().InsertAtEnd(tempNode);
						break;
					case "OutputPlatform":
						tempNode = new XplTargetPlatform();
						tempNode.Read(reader);
						this.get_OutputPlatform().InsertAtEnd(tempNode);
						break;
					case "PlatformAlias":
						tempNode = new XplPlatformAlias();
						tempNode.Read(reader);
						this.get_PlatformAlias().InsertAtEnd(tempNode);
						break;
					case "ProgramRequirements":
						tempNode = new XplLayerDZoeProgramRequirements();
						tempNode.Read(reader);
						if(this.get_ProgramRequirements()!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' repetido como hijo de elemento '"+this.get_ElementName()+"'.");
						this.set_ProgramRequirements((XplLayerDZoeProgramRequirements)tempNode);
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
		writer.Write((int) 159 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_name );
		writer.Write( (int)p_moduleType );
		writer.Write( p_defaultPlatform );
		writer.Write( p_mainProcedureFileName );
		writer.Write( p_defaultOutputFileName );
		//Escribo recursivamente cada elemento hijo
		if(p_SourceFile!=null){
			writer.Write((int)1);
			if(!p_SourceFile.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_OutputPlatform!=null){
			writer.Write((int)1);
			if(!p_OutputPlatform.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_PlatformAlias!=null){
			writer.Write((int)1);
			if(!p_PlatformAlias.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		if(p_ProgramRequirements!=null){
			writer.Write((int)1);
			if(!p_ProgramRequirements.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_name = reader.ReadString();
		p_moduleType = (XplLayerDZoeProgramModuletype_enum)reader.ReadInt32();
		p_defaultPlatform = reader.ReadString();
		p_mainProcedureFileName = reader.ReadString();
		p_defaultOutputFileName = reader.ReadString();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_SourceFile.BinaryRead(reader);
		}
		if(reader.ReadInt32()==1){
			p_OutputPlatform.BinaryRead(reader);
		}
		if(reader.ReadInt32()==1){
			p_PlatformAlias.BinaryRead(reader);
		}
		if(reader.ReadInt32()==1){
			p_ProgramRequirements = (XplLayerDZoeProgramRequirements)CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplLayerDZoeProgramConfig operator +(XplLayerDZoeProgramConfig arg1, XplNode arg2)
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
public static XplLayerDZoeProgramConfig operator +(XplLayerDZoeProgramConfig arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_name(){
		return p_name;
	}
	public XplLayerDZoeProgramModuletype_enum get_moduleType(){
		return p_moduleType;
	}
	public string get_defaultPlatform(){
		return p_defaultPlatform;
	}
	public string get_mainProcedureFileName(){
		return p_mainProcedureFileName;
	}
	public string get_defaultOutputFileName(){
		return p_defaultOutputFileName;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplNodeList get_SourceFile(){
		return p_SourceFile;
	}
	public XplNodeList get_OutputPlatform(){
		return p_OutputPlatform;
	}
	public XplNodeList get_PlatformAlias(){
		return p_PlatformAlias;
	}
	public XplLayerDZoeProgramRequirements get_ProgramRequirements(){
		return p_ProgramRequirements;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[5];
		ret[0] = "name";
		ret[1] = "moduleType";
		ret[2] = "defaultPlatform";
		ret[3] = "mainProcedureFileName";
		ret[4] = "defaultOutputFileName";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="name") return p_name.ToString();
		if (attributeName=="moduleType") return p_moduleType.ToString();
		if (attributeName=="defaultPlatform") return p_defaultPlatform.ToString();
		if (attributeName=="mainProcedureFileName") return p_mainProcedureFileName.ToString();
		if (attributeName=="defaultOutputFileName") return p_defaultOutputFileName.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		for(XplNode node=p_SourceFile.FirstNode();node!=null;node=p_SourceFile.NextNode())
			list.InsertAtEnd(node);
		for(XplNode node=p_OutputPlatform.FirstNode();node!=null;node=p_OutputPlatform.NextNode())
			list.InsertAtEnd(node);
		for(XplNode node=p_PlatformAlias.FirstNode();node!=null;node=p_PlatformAlias.NextNode())
			list.InsertAtEnd(node);
		list.InsertAtEnd(p_ProgramRequirements);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_name(string new_name){
		string back_name = p_name;
		p_name = new_name;
		return back_name;
	}
	public XplLayerDZoeProgramModuletype_enum set_moduleType(XplLayerDZoeProgramModuletype_enum new_moduleType){
		XplLayerDZoeProgramModuletype_enum back_moduleType = p_moduleType;
		p_moduleType = new_moduleType;
		return back_moduleType;
	}
	public string set_defaultPlatform(string new_defaultPlatform){
		string back_defaultPlatform = p_defaultPlatform;
		p_defaultPlatform = new_defaultPlatform;
		return back_defaultPlatform;
	}
	public string set_mainProcedureFileName(string new_mainProcedureFileName){
		string back_mainProcedureFileName = p_mainProcedureFileName;
		p_mainProcedureFileName = new_mainProcedureFileName;
		return back_mainProcedureFileName;
	}
	public string set_defaultOutputFileName(string new_defaultOutputFileName){
		string back_defaultOutputFileName = p_defaultOutputFileName;
		p_defaultOutputFileName = new_defaultOutputFileName;
		return back_defaultOutputFileName;
	}

	//Funciones para setear Elementos de Secuencia
	protected bool acceptInsertNodeCallback_SourceFile(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="SourceFile"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplSourceFile){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplSourceFile'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplSourceFile'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_SourceFile(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	protected bool acceptInsertNodeCallback_OutputPlatform(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="OutputPlatform"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplTargetPlatform){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplTargetPlatform'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplTargetPlatform'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_OutputPlatform(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	protected bool acceptInsertNodeCallback_PlatformAlias(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="PlatformAlias"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplPlatformAlias){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplPlatformAlias'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplPlatformAlias'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_PlatformAlias(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	public XplLayerDZoeProgramRequirements set_ProgramRequirements(XplLayerDZoeProgramRequirements new_ProgramRequirements){
		XplLayerDZoeProgramRequirements back_ProgramRequirements = p_ProgramRequirements;
		p_ProgramRequirements = new_ProgramRequirements;
		if(p_ProgramRequirements!=null){
			p_ProgramRequirements.set_ElementName("ProgramRequirements");
			p_ProgramRequirements.set_Parent(this);
		}
		return back_ProgramRequirements;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplSourceFile new_SourceFile(){
		XplSourceFile node = new XplSourceFile();
		node.set_ElementName("SourceFile");
		return node;
	}
	static public XplTargetPlatform new_OutputPlatform(){
		XplTargetPlatform node = new XplTargetPlatform();
		node.set_ElementName("OutputPlatform");
		return node;
	}
	static public XplPlatformAlias new_PlatformAlias(){
		XplPlatformAlias node = new XplPlatformAlias();
		node.set_ElementName("PlatformAlias");
		return node;
	}
	static public XplLayerDZoeProgramRequirements new_ProgramRequirements(){
		XplLayerDZoeProgramRequirements node = new XplLayerDZoeProgramRequirements();
		node.set_ElementName("ProgramRequirements");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

