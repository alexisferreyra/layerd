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
public class XplExpression:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_targetClass;
	string p_targetMember;
	string p_typeStr;
	string p_valueStr;
	string p_doc;
	string p_helpURL;
	string p_ldsrc;
	bool p_iny;
	string p_inydata;
	string p_inyby;
	string p_lddata;

	//Variables para Elementos de Choice
	XplNode p_choiceContent;
	#endregion

	#region Region de Constructores Publicos
	public XplExpression(){
		p_targetClass = "";
		p_targetMember = "";
		p_typeStr = "";
		p_valueStr = "";
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_choiceContent=null;
}
	public XplExpression(string n_targetClass, string n_targetMember, string n_typeStr, string n_valueStr, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata){
		set_targetClass(n_targetClass);
		set_targetMember(n_targetMember);
		set_typeStr(n_typeStr);
		set_valueStr(n_valueStr);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_choiceContent=null;
	}
	public XplExpression(XplNode n_choiceContent){
		p_targetClass = "";
		p_targetMember = "";
		p_typeStr = "";
		p_valueStr = "";
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_choiceContent=null;
		set_Content(n_choiceContent);
	}
	public XplExpression(string n_targetClass, string n_targetMember, string n_typeStr, string n_valueStr, string n_doc, string n_helpURL, string n_ldsrc, bool n_iny, string n_inydata, string n_inyby, string n_lddata, XplNode n_choiceContent){
		set_targetClass(n_targetClass);
		set_targetMember(n_targetMember);
		set_typeStr(n_typeStr);
		set_valueStr(n_valueStr);
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_choiceContent=null;
		set_Content(n_choiceContent);
	}
	#endregion

	#region Destructor
/*	public ~XplExpression(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplExpression copy = new XplExpression();
		copy.set_targetClass(this.p_targetClass);
		copy.set_targetMember(this.p_targetMember);
		copy.set_typeStr(this.p_typeStr);
		copy.set_valueStr(this.p_valueStr);
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);

		//Variables para Elementos de Choice
		if(p_choiceContent!=null)copy.set_Content(p_choiceContent.Clone());
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplExpression;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_targetClass != "")
			writer.WriteAttributeString( "targetClass" ,ZoeHelper .Att_ToString(p_targetClass) );
		if(p_targetMember != "")
			writer.WriteAttributeString( "targetMember" ,ZoeHelper .Att_ToString(p_targetMember) );
		if(p_typeStr != "")
			writer.WriteAttributeString( "typeStr" ,ZoeHelper .Att_ToString(p_typeStr) );
		if(p_valueStr != "")
			writer.WriteAttributeString( "valueStr" ,ZoeHelper .Att_ToString(p_valueStr) );
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
		if(p_choiceContent!=null)if(!p_choiceContent.Write(writer))result=false;
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
					case "targetClass":
						this.set_targetClass(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "targetMember":
						this.set_targetMember(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "typeStr":
						this.set_typeStr(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "valueStr":
						this.set_valueStr(ZoeHelper .StringAtt_To_STRING(reader.Value));
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
		this.p_choiceContent=null;
		if(!reader.IsEmptyElement){
		reader.Read();
		while(reader.NodeType!=XmlNodeType.EndElement){
			XplNode tempNode=null;
			switch(reader.NodeType){
				case XmlNodeType.Element:
					switch(reader.Name){
					case "a":
						tempNode = new XplAssing();
						tempNode.Read(reader);
						break;
					case "new":
						tempNode = new XplNewExpression();
						tempNode.Read(reader);
						break;
					case "bo":
						tempNode = new XplBinaryoperator();
						tempNode.Read(reader);
						break;
					case "uo":
						tempNode = new XplUnaryoperator();
						tempNode.Read(reader);
						break;
					case "to":
						tempNode = new XplTernaryoperator();
						tempNode.Read(reader);
						break;
					case "b":
						tempNode = new XplFunctioncall();
						tempNode.Read(reader);
						break;
					case "n":
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						break;
					case "lit":
						tempNode = new XplLiteral();
						tempNode.Read(reader);
						break;
					case "fc":
						tempNode = new XplFunctioncall();
						tempNode.Read(reader);
						break;
					case "cfc":
						tempNode = new XplComplexfunctioncall();
						tempNode.Read(reader);
						break;
					case "cast":
						tempNode = new XplCastexpression();
						tempNode.Read(reader);
						break;
					case "delete":
						tempNode = new XplExpression();
						tempNode.Read(reader);
						break;
					case "onpointer":
						tempNode = new XplExpression();
						tempNode.Read(reader);
						break;
					case "writecode":
						tempNode = new XplWriteCodeBody();
						tempNode.Read(reader);
						break;
					case "t":
						tempNode = new XplType();
						tempNode.Read(reader);
						break;
					case "toft":
						tempNode = new XplType();
						tempNode.Read(reader);
						break;
					case "sizeof":
						tempNode = new XplType();
						tempNode.Read(reader);
						break;
					case "is":
						tempNode = new XplCastexpression();
						tempNode.Read(reader);
						break;
					case "empty":
						tempNode = new XplNode(XplNodeType_enum.EMPTY);
						tempNode.Read(reader);
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
			if(this.get_Content()!=null && tempNode!=null)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Nodo '"+reader.Name+"' incorrecto como hijo de elemento '"+this.get_ElementName()+"'.");
			else if(tempNode!=null)this.set_Content(tempNode);
			reader.Read();
		}
		}
		return this;
	}
	public override bool BinaryWrite(XplBinaryWriter writer){
		bool result=true;
		//Escribo el ID y el nombre del elemento
		writer.Write((int) 133 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_targetClass );
		writer.Write( p_targetMember );
		writer.Write( p_typeStr );
		writer.Write( p_valueStr );
		writer.Write( p_doc );
		writer.Write( p_helpURL );
		writer.Write( p_ldsrc );
		writer.Write( p_iny );
		writer.Write( p_inydata );
		writer.Write( p_inyby );
		writer.Write( p_lddata );
		//Escribo recursivamente cada elemento hijo
		if(p_choiceContent!=null){
			writer.Write((int)1);
			if(!p_choiceContent.BinaryWrite(writer))result=false;
		}
		else {
			writer.Write((int)0);
		}
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_targetClass = reader.ReadString();
		p_targetMember = reader.ReadString();
		p_typeStr = reader.ReadString();
		p_valueStr = reader.ReadString();
		p_doc = reader.ReadString();
		p_helpURL = reader.ReadString();
		p_ldsrc = reader.ReadString();
		p_iny = reader.ReadBoolean();
		p_inydata = reader.ReadString();
		p_inyby = reader.ReadString();
		p_lddata = reader.ReadString();
		//Lectura de Elementos
		if(reader.ReadInt32()==1){
			p_choiceContent = CDOM_BinaryNodeReader.Read(reader, this.get_Parent());
		}
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplExpression operator +(XplExpression arg1, XplNode arg2)
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
public static XplExpression operator +(XplExpression arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_targetClass(){
		return p_targetClass;
	}
	public string get_targetMember(){
		return p_targetMember;
	}
	public string get_typeStr(){
		return p_typeStr;
	}
	public string get_valueStr(){
		return p_valueStr;
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

	//Funciones para obtener Elementos de Choice
	public override XplNode get_Content(){
		return p_choiceContent;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[11];
		ret[0] = "targetClass";
		ret[1] = "targetMember";
		ret[2] = "typeStr";
		ret[3] = "valueStr";
		ret[4] = "doc";
		ret[5] = "helpURL";
		ret[6] = "ldsrc";
		ret[7] = "iny";
		ret[8] = "inydata";
		ret[9] = "inyby";
		ret[10] = "lddata";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="targetClass") return p_targetClass.ToString();
		if (attributeName=="targetMember") return p_targetMember.ToString();
		if (attributeName=="typeStr") return p_typeStr.ToString();
		if (attributeName=="valueStr") return p_valueStr.ToString();
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
		list.InsertAtEnd(p_choiceContent);
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_targetClass(string new_targetClass){
		string back_targetClass = p_targetClass;
		p_targetClass = new_targetClass;
		return back_targetClass;
	}
	public string set_targetMember(string new_targetMember){
		string back_targetMember = p_targetMember;
		p_targetMember = new_targetMember;
		return back_targetMember;
	}
	public string set_typeStr(string new_typeStr){
		string back_typeStr = p_typeStr;
		p_typeStr = new_typeStr;
		return back_typeStr;
	}
	public string set_valueStr(string new_valueStr){
		string back_valueStr = p_valueStr;
		p_valueStr = new_valueStr;
		return back_valueStr;
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

//Funciones para setear Elementos de Choice
	public override XplNode set_Content(XplNode new_texpression){
		if(new_texpression==null)return p_choiceContent;
		XplNode back_texpression = p_choiceContent;
		if(new_texpression.get_ElementName()=="a"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplAssing){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="new"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplNewExpression){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="bo"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplBinaryoperator){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="uo"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplUnaryoperator){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="to"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplTernaryoperator){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="b"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplFunctioncall){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="n"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.String){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="lit"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplLiteral){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="fc"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplFunctioncall){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="cfc"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplComplexfunctioncall){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="cast"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplCastexpression){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="delete"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplExpression){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="onpointer"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplExpression){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="writecode"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplWriteCodeBody){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="t"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplType){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="toft"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplType){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="sizeof"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplType){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="is"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplCastexpression){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		if(new_texpression.get_ElementName()=="empty"){
			if(new_texpression.get_ContentTypeName()!=CodeDOMTypes.XplNode){
				this.set_ErrorString("El elemento de tipo '"+new_texpression.get_ContentTypeName()+"' no es valido como componente de 'texpression'.");
				return null;
			}
			p_choiceContent = new_texpression;
			p_choiceContent.set_Parent(this);
			return back_texpression;
		}
		this.set_ErrorString("El elemento de nombre '"+new_texpression.get_ElementName()+"' no es valido como componente de 'texpression'.");
		return null;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	static public XplAssing new_a(){
		XplAssing node = new XplAssing();
		node.set_ElementName("a");
		return node;
	}
	static public XplNewExpression new_new(){
		XplNewExpression node = new XplNewExpression();
		node.set_ElementName("new");
		return node;
	}
	static public XplBinaryoperator new_bo(){
		XplBinaryoperator node = new XplBinaryoperator();
		node.set_ElementName("bo");
		return node;
	}
	static public XplUnaryoperator new_uo(){
		XplUnaryoperator node = new XplUnaryoperator();
		node.set_ElementName("uo");
		return node;
	}
	static public XplTernaryoperator new_to(){
		XplTernaryoperator node = new XplTernaryoperator();
		node.set_ElementName("to");
		return node;
	}
	static public XplFunctioncall new_b(){
		XplFunctioncall node = new XplFunctioncall();
		node.set_ElementName("b");
		return node;
	}
	static public XplNode new_n(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_ElementName("n");
		return node;
	}
	static public XplLiteral new_lit(){
		XplLiteral node = new XplLiteral();
		node.set_ElementName("lit");
		return node;
	}
	static public XplFunctioncall new_fc(){
		XplFunctioncall node = new XplFunctioncall();
		node.set_ElementName("fc");
		return node;
	}
	static public XplComplexfunctioncall new_cfc(){
		XplComplexfunctioncall node = new XplComplexfunctioncall();
		node.set_ElementName("cfc");
		return node;
	}
	static public XplCastexpression new_cast(){
		XplCastexpression node = new XplCastexpression();
		node.set_ElementName("cast");
		return node;
	}
	static public XplExpression new_delete(){
		XplExpression node = new XplExpression();
		node.set_ElementName("delete");
		return node;
	}
	static public XplExpression new_onpointer(){
		XplExpression node = new XplExpression();
		node.set_ElementName("onpointer");
		return node;
	}
	static public XplWriteCodeBody new_writecode(){
		XplWriteCodeBody node = new XplWriteCodeBody();
		node.set_ElementName("writecode");
		return node;
	}
	static public XplType new_t(){
		XplType node = new XplType();
		node.set_ElementName("t");
		return node;
	}
	static public XplType new_toft(){
		XplType node = new XplType();
		node.set_ElementName("toft");
		return node;
	}
	static public XplType new_sizeof(){
		XplType node = new XplType();
		node.set_ElementName("sizeof");
		return node;
	}
	static public XplCastexpression new_is(){
		XplCastexpression node = new XplCastexpression();
		node.set_ElementName("is");
		return node;
	}
	static public XplNode new_empty(){
		XplNode node = new XplNode(XplNodeType_enum.EMPTY);
		node.set_ElementName("empty");
		return node;
	}
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

