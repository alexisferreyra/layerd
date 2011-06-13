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

public class XplFunctionBody extends  XplNode implements XplNodeListCallbacks {

	//<editor-fold defaultstate="collapsed" desc=" Variables privadas para atributos y elementos ">
	String p_doc;
	String p_helpURL;
	String p_ldsrc;
	boolean p_iny;
	String p_inydata;
	String p_inyby;
	String p_lddata;
	//Variables para Elementos de Secuencia
	XplNodeList p_Childs;
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Region Constructores Publicos ">
	public XplFunctionBody(){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
	}
	public XplFunctionBody(String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
	}
	public XplFunctionBody(XplNodeList n_Childs){
		p_doc = "";
		p_helpURL = "";
		p_ldsrc = "";
		p_iny = false;
		p_inydata = "";
		p_inyby = "";
		p_lddata = "";
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Childs!=null)
		for(XplNode node = n_Childs.FirstNode(); node != null ; node = n_Childs.NextNode()){
			p_Childs.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
	}
	public XplFunctionBody(String n_doc, String n_helpURL, String n_ldsrc, boolean n_iny, String n_inydata, String n_inyby, String n_lddata, XplNodeList n_Childs){
		set_doc(n_doc);
		set_helpURL(n_helpURL);
		set_ldsrc(n_ldsrc);
		set_iny(n_iny);
		set_inydata(n_inydata);
		set_inyby(n_inyby);
		set_lddata(n_lddata);
		p_Childs = new XplNodeList();
		p_Childs.set_Parent(this);
		p_Childs.set_CheckNodeCallback(this);
		//#ifndef __LAYERD_CODEDOM_DONTCOPY_NODELISTS
		if(n_Childs!=null)
		for(XplNode node = n_Childs.FirstNode(); node != null ; node = n_Childs.NextNode()){
			p_Childs.InsertAtEnd(node);
		}
		//#else
		//p_Childs = n_Childs;
		//#endif
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones Sobreescritas de XplNode ">
	public XplNode Clone(){
		XplFunctionBody copy = new XplFunctionBody();
		copy.set_doc(this.p_doc);
		copy.set_helpURL(this.p_helpURL);
		copy.set_ldsrc(this.p_ldsrc);
		copy.set_iny(this.p_iny);
		copy.set_inydata(this.p_inydata);
		copy.set_inyby(this.p_inyby);
		copy.set_lddata(this.p_lddata);
		for(XplNode node = p_Childs.FirstNode(); node != null ; node = p_Childs.NextNode()){
			copy.Childs().InsertAtEnd(node.Clone());
		}
		copy.set_Name(this.get_Name());
		return (XplNode)copy;
	}

	public int get_TypeName(){return CodeDOMTypes.XplFunctionBody;}

	public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception {
		boolean result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_Name() );
		//Escribo los atributos del elemento
		if(p_doc != "")
			writer.WriteAttributeString( "doc" ,CodeDOM_Utils.Att_ToString(p_doc) );
		if(p_helpURL != "")
			writer.WriteAttributeString( "helpURL" ,CodeDOM_Utils.Att_ToString(p_helpURL) );
		if(p_ldsrc != "")
			writer.WriteAttributeString( "ldsrc" ,CodeDOM_Utils.Att_ToString(p_ldsrc) );
		if(p_iny != false)
			writer.WriteAttributeString( "iny" ,CodeDOM_Utils.Att_ToString(p_iny) );
		if(p_inydata != "")
			writer.WriteAttributeString( "inydata" ,CodeDOM_Utils.Att_ToString(p_inydata) );
		if(p_inyby != "")
			writer.WriteAttributeString( "inyby" ,CodeDOM_Utils.Att_ToString(p_inyby) );
		if(p_lddata != "")
			writer.WriteAttributeString( "lddata" ,CodeDOM_Utils.Att_ToString(p_lddata) );
		//Escribo recursivamente cada elemento hijo
		if(p_Childs!=null)if(!p_Childs.Write(writer))result=false;
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
				if(reader.Name().equals("doc")){
					this.set_doc(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("helpURL")){
					this.set_helpURL(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("ldsrc")){
					this.set_ldsrc(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("iny")){
					this.set_iny(CodeDOM_Utils.StringAtt_To_BOOLEAN(reader.Value()));
				}
				else if(reader.Name().equals("inydata")){
					this.set_inydata(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("inyby")){
					this.set_inyby(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else if(reader.Name().equals("lddata")){
					this.set_lddata(CodeDOM_Utils.StringAtt_To_STRING(reader.Value()));
				}
				else{
					throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Atributo '"+reader.Name()+"' invalido en elemento '"+this.get_Name()+"'.");
				}
			}
			reader.MoveToElement();
		}
		//Lectura de Elementos
		p_Childs.Clear(); //Borro todo posible hijo en memoria
		if(!reader.IsEmptyElement()){
		reader.Read();
		while(reader.NodeType()!=XmlNodeType.ENDELEMENT){
			XplNode tempNode=null;
			switch(reader.NodeType()){
				case XmlNodeType.ELEMENT:
					if(reader.Name().equals("label")){
						tempNode = new XplNode(XplNodeType_enum.STRING);
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("setonerror")){
						tempNode = new XplSetonerror();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Decls")){
						tempNode = new XplDeclaratorlist();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("e")){
						tempNode = new XplExpression();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("switch")){
						tempNode = new XplSwitchStatement();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("if")){
						tempNode = new XplIfStatement();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("for")){
						tempNode = new XplForStatement();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("do")){
						tempNode = new XplDowhileStatement();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("while")){
						tempNode = new XplDowhileStatement();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("bk")){
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Get")){
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("Set")){
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("onpointer")){
						tempNode = new XplFunctionBody();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("try")){
						tempNode = new XplTryStatement();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("throw")){
						tempNode = new XplExpression();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("return")){
						tempNode = new XplExpression();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("jump")){
						tempNode = new XplJump();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("directoutput")){
						tempNode = new XplDirectoutput();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("documentation")){
						tempNode = new XplDocumentation();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("selectoutput")){
						tempNode = new XplFunctioncall();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("BeginCFPermissions")){
						tempNode = new XplClassfactorysPermissions();
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else if(reader.Name().equals("EndCFPermissions")){
						tempNode = new XplNode(XplNodeType_enum.EMPTY);
						tempNode.Read(reader);
						p_Childs.InsertAtEnd(tempNode);
						break;
					}
					else{
						throw new CodeDOM_Exception("Linea: "+reader.LineNumber()+".Nombre de nodo '"+reader.Name()+"' inesperado como hijo de elemento '"+this.get_Name()+"'.");
					}
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
	public String get_doc(){
		return p_doc;
	}
	public String get_helpURL(){
		return p_helpURL;
	}
	public String get_ldsrc(){
		return p_ldsrc;
	}
	public boolean get_iny(){
		return p_iny;
	}
	public String get_inydata(){
		return p_inydata;
	}
	public String get_inyby(){
		return p_inyby;
	}
	public String get_lddata(){
		return p_lddata;
	}
	//Funciones para obtener Elementos de Secuencia
	public XplNodeList Childs(){
		return p_Childs;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Funciones para setear Atributos y Elementos ">
	public String set_doc(String new_doc){
		String back_doc = p_doc;
		p_doc = new_doc;
		return back_doc;
	}
	public String set_helpURL(String new_helpURL){
		String back_helpURL = p_helpURL;
		p_helpURL = new_helpURL;
		return back_helpURL;
	}
	public String set_ldsrc(String new_ldsrc){
		String back_ldsrc = p_ldsrc;
		p_ldsrc = new_ldsrc;
		return back_ldsrc;
	}
	public boolean set_iny(boolean new_iny){
		boolean back_iny = p_iny;
		p_iny = new_iny;
		return back_iny;
	}
	public String set_inydata(String new_inydata){
		String back_inydata = p_inydata;
		p_inydata = new_inydata;
		return back_inydata;
	}
	public String set_inyby(String new_inyby){
		String back_inyby = p_inyby;
		p_inyby = new_inyby;
		return back_inyby;
	}
	public String set_lddata(String new_lddata){
		String back_lddata = p_lddata;
		p_lddata = new_lddata;
		return back_lddata;
	}

	//Funciones para setear Elementos de Secuencia
	public boolean InsertCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		if(node==null)return false;
		if(node.get_Name().equals("label")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.String){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("setonerror")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplSetonerror){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Decls")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplDeclaratorlist){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("e")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplExpression){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("switch")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplSwitchStatement){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("if")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplIfStatement){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("for")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplForStatement){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("do")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplDowhileStatement){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("while")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplDowhileStatement){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("bk")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunctionBody){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Get")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunctionBody){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("Set")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunctionBody){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("onpointer")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunctionBody){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("try")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplTryStatement){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("throw")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplExpression){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("return")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplExpression){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("jump")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplJump){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("directoutput")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplDirectoutput){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("documentation")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplDocumentation){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("selectoutput")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplFunctioncall){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("BeginCFPermissions")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplClassfactorysPermissions){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		if(node.get_Name().equals("EndCFPermissions")){
			if(node.get_ContentTypeName()!=CodeDOMTypes.XplNode){
				return false; //throw new CodeDOM_Exception("El elemento de tipo '"+node.get_ContentTypeNameString()+"' no es valido como componente de 'XplFunctionBody'.");
			}
			node.set_Parent(parent);
			return true;
		}
		//throw new CodeDOM_Exception("El elemento de nombre '"+node.get_Name()+"' no es valido como componente de 'XplFunctionBody'.");
		return false;
	}
	public boolean RemoveNodeCallback(XplNodeList nodeList, XplNode node, XplNode parent){
		return true;
	}
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc=" Otras Funciones Miembros ">
	//Funciones para filtrado en Listas de Nodos
	public XplNodeList get_labelNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("label")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_setonerrorNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("setonerror")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_DeclsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Decls")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_eNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("e")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_switchNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("switch")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_ifNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("if")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_forNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("for")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_doNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("do")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_whileNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("while")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_bkNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("bk")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_GetNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Get")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_SetNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("Set")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_onpointerNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("onpointer")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_tryNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("try")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_throwNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("throw")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_returnNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("return")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_jumpNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("jump")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_directoutputNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("directoutput")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_documentationNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("documentation")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_selectoutputNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("selectoutput")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_BeginCFPermissionsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("BeginCFPermissions")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}
	public XplNodeList get_EndCFPermissionsNodeList(){
		XplNodeList new_List = new XplNodeList();
		for(XplNode node = p_Childs.FirstNode(); node != null; node = p_Childs.NextNode()){
			if(node.get_Name().equals("EndCFPermissions")){
				new_List.InsertAtEnd(node);
			}
		}
		return new_List;
	}


	//Funciones para obtener nuevos nodos hijos
	public static final XplNode new_label(){
		XplNode node = new XplNode(XplNodeType_enum.STRING);
		node.set_Name("label");
		return node;
	}
	public static final XplSetonerror new_setonerror(){
		XplSetonerror node = new XplSetonerror();
		node.set_Name("setonerror");
		return node;
	}
	public static final XplDeclaratorlist new_Decls(){
		XplDeclaratorlist node = new XplDeclaratorlist();
		node.set_Name("Decls");
		return node;
	}
	public static final XplExpression new_e(){
		XplExpression node = new XplExpression();
		node.set_Name("e");
		return node;
	}
	public static final XplSwitchStatement new_switch(){
		XplSwitchStatement node = new XplSwitchStatement();
		node.set_Name("switch");
		return node;
	}
	public static final XplIfStatement new_if(){
		XplIfStatement node = new XplIfStatement();
		node.set_Name("if");
		return node;
	}
	public static final XplForStatement new_for(){
		XplForStatement node = new XplForStatement();
		node.set_Name("for");
		return node;
	}
	public static final XplDowhileStatement new_do(){
		XplDowhileStatement node = new XplDowhileStatement();
		node.set_Name("do");
		return node;
	}
	public static final XplDowhileStatement new_while(){
		XplDowhileStatement node = new XplDowhileStatement();
		node.set_Name("while");
		return node;
	}
	public static final XplFunctionBody new_bk(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_Name("bk");
		return node;
	}
	public static final XplFunctionBody new_Get(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_Name("Get");
		return node;
	}
	public static final XplFunctionBody new_Set(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_Name("Set");
		return node;
	}
	public static final XplFunctionBody new_onpointer(){
		XplFunctionBody node = new XplFunctionBody();
		node.set_Name("onpointer");
		return node;
	}
	public static final XplTryStatement new_try(){
		XplTryStatement node = new XplTryStatement();
		node.set_Name("try");
		return node;
	}
	public static final XplExpression new_throw(){
		XplExpression node = new XplExpression();
		node.set_Name("throw");
		return node;
	}
	public static final XplExpression new_return(){
		XplExpression node = new XplExpression();
		node.set_Name("return");
		return node;
	}
	public static final XplJump new_jump(){
		XplJump node = new XplJump();
		node.set_Name("jump");
		return node;
	}
	public static final XplDirectoutput new_directoutput(){
		XplDirectoutput node = new XplDirectoutput();
		node.set_Name("directoutput");
		return node;
	}
	public static final XplDocumentation new_documentation(){
		XplDocumentation node = new XplDocumentation();
		node.set_Name("documentation");
		return node;
	}
	public static final XplFunctioncall new_selectoutput(){
		XplFunctioncall node = new XplFunctioncall();
		node.set_Name("selectoutput");
		return node;
	}
	public static final XplClassfactorysPermissions new_BeginCFPermissions(){
		XplClassfactorysPermissions node = new XplClassfactorysPermissions();
		node.set_Name("BeginCFPermissions");
		return node;
	}
	public static final XplNode new_EndCFPermissions(){
		XplNode node = new XplNode(XplNodeType_enum.EMPTY);
		node.set_Name("EndCFPermissions");
		return node;
	}
	//</editor-fold>

}	//Fin declaración de Clase


/*-------Fin de Archivo Generado------------------*/

