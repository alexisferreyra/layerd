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
public class XplNamespace:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_name;
	string p_internalname;
	string p_externalname;
	bool p_external;
	bool p_donotrender;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;
	//Variables para Elementos de Secuencia
	XplNodeList p_Children;
	#endregion

	#region Region de Constructores Publicos
	public XplNamespace(){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_external = false;
		p_donotrender = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_tNamespace));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_tNamespace));
}
	public XplNamespace(string n_name, bool n_external, bool n_donotrender){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_external = false;
		p_donotrender = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_name(n_name);
		set_external(n_external);
		set_donotrender(n_donotrender);
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_tNamespace));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_tNamespace));
	}
	public XplNamespace(string n_name, string n_internalname, string n_externalname, bool n_external, bool n_donotrender, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
		set_name(n_name);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_external(n_external);
		set_donotrender(n_donotrender);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_tNamespace));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_tNamespace));
	}
	public XplNamespace(XplNodeList n_Children){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_external = false;
		p_donotrender = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_tNamespace));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_tNamespace));
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Children!=null)
		for(XplNode node = n_Children.FirstNode(); node != null ; node = n_Children.NextNode()){
			p_Children.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	public XplNamespace(string n_name, bool n_external, bool n_donotrender, XplNodeList n_Children){
		p_name = "";
		p_internalname = "";
		p_externalname = "";
		p_external = false;
		p_donotrender = false;
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		set_name(n_name);
		set_external(n_external);
		set_donotrender(n_donotrender);
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_tNamespace));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_tNamespace));
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Children!=null)
		for(XplNode node = n_Children.FirstNode(); node != null ; node = n_Children.NextNode()){
			p_Children.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	public XplNamespace(string n_name, string n_internalname, string n_externalname, bool n_external, bool n_donotrender, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNodeList n_Children){
		set_name(n_name);
		set_internalname(n_internalname);
		set_externalname(n_externalname);
		set_external(n_external);
		set_donotrender(n_donotrender);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_Children = new XplNodeList();
		p_Children.set_Parent(this);
		p_Children.set_InsertNodeCallback(new InsertNodeCallback(acceptInsertNodeCallback_tNamespace));
		p_Children.set_RemoveNodeCallback(new InsertNodeCallback(acceptRemoveNodeCallback_tNamespace));
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Children!=null)
		for(XplNode node = n_Children.FirstNode(); node != null ; node = n_Children.NextNode()){
			p_Children.InsertAtEnd(node);
		}
		//#else
		//p_Children = n_Children;
		//#endif
	}
	#endregion

	#region Destructor
/*	public ~XplNamespace(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplNamespace copy = new XplNamespace();
		copy.set_name(this.p_name);
		copy.set_internalname(this.p_internalname);
		copy.set_externalname(this.p_externalname);
		copy.set_external(this.p_external);
		copy.set_donotrender(this.p_donotrender);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			copy.Children().InsertAtEnd(node.Clone());
		}
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplNamespace;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_name != "")
			writer.WriteAttributeString( "name" ,ZoeHelper .Att_ToString(p_name) );
		if(p_internalname != "")
			writer.WriteAttributeString( "internalname" ,ZoeHelper .Att_ToString(p_internalname) );
		if(p_externalname != "")
			writer.WriteAttributeString( "externalname" ,ZoeHelper .Att_ToString(p_externalname) );
		if(p_external != false)
			writer.WriteAttributeString( "external" ,ZoeHelper .Att_ToString(p_external) );
		if(p_donotrender != false)
			writer.WriteAttributeString( "donotrender" ,ZoeHelper .Att_ToString(p_donotrender) );
		if(p_doc != "")
			writer.WriteAttributeString( "doc" ,ZoeHelper .Att_ToString(p_doc) );
		if(p_helpURL != "")
			writer.WriteAttributeString( "helpURL" ,ZoeHelper .Att_ToString(p_helpURL) );
		if(p_ldsrc != "")
			writer.WriteAttributeString( "ldsrc" ,ZoeHelper .Att_ToString(p_ldsrc) );
		if(p_iny != false)
			writer.WriteAttributeString( "iny" ,ZoeHelper .Att_ToString(p_iny) );
		if(p_inydata != "")
			writer.WriteAttributeString( "inydata" ,ZoeHelper .Att_ToString(p_inydata) );
		if(p_inyby != "")
			writer.WriteAttributeString( "inyby" ,ZoeHelper .Att_ToString(p_inyby) );
		if(p_lddata != "")
			writer.WriteAttributeString( "lddata" ,ZoeHelper .Att_ToString(p_lddata) );
		//Escribo recursivamente cada elemento hijo
		if(p_Children!=null)if(!p_Children.Write(writer))result=false;
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
					case "name":
						this.set_name(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "internalname":
						this.set_internalname(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "externalname":
						this.set_externalname(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "external":
						this.set_external(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "donotrender":
						this.set_donotrender(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "doc":
						this.set_doc(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "helpURL":
						this.set_helpURL(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "ldsrc":
						this.set_ldsrc(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "iny":
						this.set_iny(ZoeHelper .StringAtt_To_BOOL(reader.Value));
						break;
					case "inydata":
						this.set_inydata(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "inyby":
						this.set_inyby(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "lddata":
						this.set_lddata(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					default:
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Atributo '"+reader.Name+"' invalido en elemento '"+this.get_ElementName()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		p_Children.Clear(); //Borro todo posible hijo en memoria
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "Class":
						tempNode = new XplClass();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Namespace":
						tempNode = new XplNamespace();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "Section":
						tempNode = new XplNamespace();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "e":
						tempNode = new XplExpression();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "BeginCFPermissions":
						tempNode = new XplClassfactorysPermissions();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "EndCFPermissions":
						tempNode = new XplNode(XplNodeType_enum.EMPTY);
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
						break;
					case "documentation":
						tempNode = new XplDocumentation();
						tempNode.Read(reader);
						p_Children.InsertAtEnd(tempNode);
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
		writer.Write((int) 121 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_name );
		writer.Write( p_internalname );
		writer.Write( p_externalname );
		writer.Write( p_external );
		writer.Write( p_donotrender );
		writer.Write( p_doc );
		writer.Write( p_helpURL );
		writer.Write( p_ldsrc );
		writer.Write( p_iny );
		writer.Write( p_inydata );
		writer.Write( p_inyby );
		writer.Write( p_lddata );
		//Escribo recursivamente cada elemento hijo
		if(!p_Children.BinaryWrite(writer))result=false;
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_name = reader.ReadString();
		p_internalname = reader.ReadString();
		p_externalname = reader.ReadString();
		p_external = reader.ReadBoolean();
		p_donotrender = reader.ReadBoolean();
		p_doc = reader.ReadString();
		p_helpURL = reader.ReadString();
		p_ldsrc = reader.ReadString();
		p_iny = reader.ReadBoolean();
		p_inydata = reader.ReadString();
		p_inyby = reader.ReadString();
		p_lddata = reader.ReadString();
		//Lectura de Elementos
		p_Children.BinaryRead(reader);
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplNamespace operator +(XplNamespace arg1, XplNode arg2)
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
public static XplNamespace operator +(XplNamespace arg1, XplNodeList arg2)
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
	public string get_internalname(){
		return p_internalname;
	}
	public string get_externalname(){
		return p_externalname;
	}
	public bool get_external(){
		return p_external;
	}
	public bool get_donotrender(){
		return p_donotrender;
	}
	public override string get_doc(){
		return p_doc;
	}
	public override string get_helpURL(){
		return p_helpURL;
	}
	public override string get_ldsrc(){
		return p_ldsrc;
	}
	public override bool get_iny(){
		return p_iny;
	}
	public override string get_inydata(){
		return p_inydata;
	}
	public override string get_inyby(){
		return p_inyby;
	}
	public override string get_lddata(){
		return p_lddata;
	}
	//Funciones para obtener Elementos de Secuencia
	public override XplNodeList Children(){
		return p_Children;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[12];
		ret[0] = "name";
		ret[1] = "internalname";
		ret[2] = "externalname";
		ret[3] = "external";
		ret[4] = "donotrender";
		ret[5] = "doc";
		ret[6] = "helpURL";
		ret[7] = "ldsrc";
		ret[8] = "iny";
		ret[9] = "inydata";
		ret[10] = "inyby";
		ret[11] = "lddata";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="name") return p_name.ToString();
		if (attributeName=="internalname") return p_internalname.ToString();
		if (attributeName=="externalname") return p_externalname.ToString();
		if (attributeName=="external") return p_external.ToString();
		if (attributeName=="donotrender") return p_donotrender.ToString();
		if (attributeName=="doc") return p_doc.ToString();
		if (attributeName=="helpURL") return p_helpURL.ToString();
		if (attributeName=="ldsrc") return p_ldsrc.ToString();
		if (attributeName=="iny") return p_iny.ToString();
		if (attributeName=="inydata") return p_inydata.ToString();
		if (attributeName=="inyby") return p_inyby.ToString();
		if (attributeName=="lddata") return p_lddata.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		for(XplNode node=p_Children.FirstNode();node!=null;node=p_Children.NextNode())
			list.InsertAtEnd(node);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_name(string new_name){
		string back_name = p_name;
		p_name = new_name;
		return back_name;
	}
	public string set_internalname(string new_internalname){
		string back_internalname = p_internalname;
		p_internalname = new_internalname;
		return back_internalname;
	}
	public string set_externalname(string new_externalname){
		string back_externalname = p_externalname;
		p_externalname = new_externalname;
		return back_externalname;
	}
	public bool set_external(bool new_external){
		bool back_external = p_external;
		p_external = new_external;
		return back_external;
	}
	public bool set_donotrender(bool new_donotrender){
		bool back_donotrender = p_donotrender;
		p_donotrender = new_donotrender;
		return back_donotrender;
	}
	public override string set_doc(string new_doc){
		string back_doc = p_doc;
		p_doc = new_doc;
		return back_doc;
	}
	public override string set_helpURL(string new_helpURL){
		string back_helpURL = p_helpURL;
		p_helpURL = new_helpURL;
		return back_helpURL;
	}
	public override string set_ldsrc(string new_ldsrc){
		string back_ldsrc = p_ldsrc;
		p_ldsrc = new_ldsrc;
		return back_ldsrc;
	}
	public override bool set_iny(bool new_iny){
		bool back_iny = p_iny;
		p_iny = new_iny;
		return back_iny;
	}
	public override string set_inydata(string new_inydata){
		string back_inydata = p_inydata;
		p_inydata = new_inydata;
		return back_inydata;
	}
	public override string set_inyby(string new_inyby){
		string back_inyby = p_inyby;
		p_inyby = new_inyby;
		return back_inyby;
	}
	public override string set_lddata(string new_lddata){
		string back_lddata = p_lddata;
		p_lddata = new_lddata;
		return back_lddata;
	}

	//Funciones para setear Elementos de Secuencia
	protected bool acceptInsertNodeCallback_tNamespace(XplNode node, ref string errorMsg, XplNode parent){
		if(node==null)return false;
		if(node.get_ElementName()=="Class"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplClass){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplNamespace'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Namespace"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplNamespace){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplNamespace'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="Section"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplNamespace){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplNamespace'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="e"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplExpression){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplNamespace'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="BeginCFPermissions"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplClassfactorysPermissions){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplNamespace'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="EndCFPermissions"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplNode){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplNamespace'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_ElementName()=="documentation"){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplDocumentation){
				errorMsg = "El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplNamespace'.";
				return false;
			}
			node.set_Parent(parent);
			return true;
		}
		errorMsg = "El elemento de nombre '"+node.get_ElementName()+"' no es valido como componente de 'XplNamespace'.";
		return false;
	}
	protected bool acceptRemoveNodeCallback_tNamespace(XplNode node, ref string errorMsg, XplNode parent){
		return true;
	}
	#endregion

	#region Funciones para filtrado en Listas de Nodos
	public XplNodeList get_ClassNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Class"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_NamespaceNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Namespace"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_SectionNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="Section"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_eNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="e"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_BeginCFPermissionsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="BeginCFPermissions"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_EndCFPermissionsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="EndCFPermissions"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_documentationNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Children.FirstNode(); node != null ; node = p_Children.NextNode()){
			if(node.get_ElementName()=="documentation"){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplClass new_Class(){
		XplClass node = new XplClass();
		node.set_ElementName("Class");
		return node;
	}
	static public XplNamespace new_Namespace(){
		XplNamespace node = new XplNamespace();
		node.set_ElementName("Namespace");
		return node;
	}
	static public XplNamespace new_Section(){
		XplNamespace node = new XplNamespace();
		node.set_ElementName("Section");
		return node;
	}
	static public XplExpression new_e(){
		XplExpression node = new XplExpression();
		node.set_ElementName("e");
		return node;
	}
	static public XplClassfactorysPermissions new_BeginCFPermissions(){
		XplClassfactorysPermissions node = new XplClassfactorysPermissions();
		node.set_ElementName("BeginCFPermissions");
		return node;
	}
	static public XplNode new_EndCFPermissions(){
		XplNode node = new XplNode(XplNodeType_enum.EMPTY);
		node.set_ElementName("EndCFPermissions");
		return node;
	}
	static public XplDocumentation new_documentation(){
		XplDocumentation node = new XplDocumentation();
		node.set_ElementName("documentation");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

