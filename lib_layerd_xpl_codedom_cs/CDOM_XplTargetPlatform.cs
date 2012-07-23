/*-------------------------------------------------
 *
 *	Este archivo fue generado automáticamente.
 *	Fecha: 8/11/2011 4:27:19 PM
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
public class XplTargetPlatform:  XplNode{

	#region Variables privadas para atributos y elementos
	string p_uniqueName;
	string p_simpleName;
	string p_minVersion;
	string p_maxVersion;
	string p_description;
	XplPlatformsupportlevel_enum p_supportLevel;
	string p_operatingsystem;
	string p_aplication;
	string p_multitask;
	XplMemorymodel_enum p_memorymodel;
	XplBitorder_enum p_defaultbitorder;
	XplBitorder_enum p_defaultbyteorder;
	uint p_addresswidth;
	uint p_databus;
	uint p_commonregisterssize;
	uint p_segments;
	uint p_segmentsize;
	string p_threading;
	#endregion

	#region Region de Constructores Publicos
	public XplTargetPlatform(){
		p_uniqueName = "";
		p_simpleName = "";
		p_minVersion = "";
		p_maxVersion = "";
		p_description = "";
		p_supportLevel = XplPlatformsupportlevel_enum.COMPLETE;
		p_operatingsystem = "";
		p_aplication = "";
		p_multitask = "Preemtive";
		p_memorymodel = XplMemorymodel_enum.LINEAL;
		p_defaultbitorder = XplBitorder_enum.IGNORE;
		p_defaultbyteorder = XplBitorder_enum.IGNORE;
		p_addresswidth = 32;
		p_databus = 32;
		p_commonregisterssize = 32;
		p_segments = 0;
		p_segmentsize = 0;
		p_threading = "";
}
	public XplTargetPlatform(string n_uniqueName, string n_simpleName, XplPlatformsupportlevel_enum n_supportLevel, string n_multitask, XplMemorymodel_enum n_memorymodel, XplBitorder_enum n_defaultbitorder, XplBitorder_enum n_defaultbyteorder, uint n_addresswidth, uint n_databus, uint n_commonregisterssize){
		p_uniqueName = "";
		p_simpleName = "";
		p_minVersion = "";
		p_maxVersion = "";
		p_description = "";
		p_supportLevel = XplPlatformsupportlevel_enum.COMPLETE;
		p_operatingsystem = "";
		p_aplication = "";
		p_multitask = "Preemtive";
		p_memorymodel = XplMemorymodel_enum.LINEAL;
		p_defaultbitorder = XplBitorder_enum.IGNORE;
		p_defaultbyteorder = XplBitorder_enum.IGNORE;
		p_addresswidth = 32;
		p_databus = 32;
		p_commonregisterssize = 32;
		p_segments = 0;
		p_segmentsize = 0;
		p_threading = "";
		set_uniqueName(n_uniqueName);
		set_simpleName(n_simpleName);
		set_supportLevel(n_supportLevel);
		set_multitask(n_multitask);
		set_memorymodel(n_memorymodel);
		set_defaultbitorder(n_defaultbitorder);
		set_defaultbyteorder(n_defaultbyteorder);
		set_addresswidth(n_addresswidth);
		set_databus(n_databus);
		set_commonregisterssize(n_commonregisterssize);
	}
	public XplTargetPlatform(string n_uniqueName, string n_simpleName, string n_minVersion, string n_maxVersion, string n_description, XplPlatformsupportlevel_enum n_supportLevel, string n_operatingsystem, string n_aplication, string n_multitask, XplMemorymodel_enum n_memorymodel, XplBitorder_enum n_defaultbitorder, XplBitorder_enum n_defaultbyteorder, uint n_addresswidth, uint n_databus, uint n_commonregisterssize, uint n_segments, uint n_segmentsize, string n_threading){
		set_uniqueName(n_uniqueName);
		set_simpleName(n_simpleName);
		set_minVersion(n_minVersion);
		set_maxVersion(n_maxVersion);
		set_description(n_description);
		set_supportLevel(n_supportLevel);
		set_operatingsystem(n_operatingsystem);
		set_aplication(n_aplication);
		set_multitask(n_multitask);
		set_memorymodel(n_memorymodel);
		set_defaultbitorder(n_defaultbitorder);
		set_defaultbyteorder(n_defaultbyteorder);
		set_addresswidth(n_addresswidth);
		set_databus(n_databus);
		set_commonregisterssize(n_commonregisterssize);
		set_segments(n_segments);
		set_segmentsize(n_segmentsize);
		set_threading(n_threading);
	}
	#endregion

	#region Destructor
/*	public ~XplTargetPlatform(){
		Se supone que .NET no necesita destructores sólo para liberar memoria	}*/
	#endregion

	#region Funciones Sobreescritas de XplNode
	public override XplNode Clone(){
		XplTargetPlatform copy = new XplTargetPlatform();
		copy.set_uniqueName(this.p_uniqueName);
		copy.set_simpleName(this.p_simpleName);
		copy.set_minVersion(this.p_minVersion);
		copy.set_maxVersion(this.p_maxVersion);
		copy.set_description(this.p_description);
		copy.set_supportLevel(this.p_supportLevel);
		copy.set_operatingsystem(this.p_operatingsystem);
		copy.set_aplication(this.p_aplication);
		copy.set_multitask(this.p_multitask);
		copy.set_memorymodel(this.p_memorymodel);
		copy.set_defaultbitorder(this.p_defaultbitorder);
		copy.set_defaultbyteorder(this.p_defaultbyteorder);
		copy.set_addresswidth(this.p_addresswidth);
		copy.set_databus(this.p_databus);
		copy.set_commonregisterssize(this.p_commonregisterssize);
		copy.set_segments(this.p_segments);
		copy.set_segmentsize(this.p_segmentsize);
		copy.set_threading(this.p_threading);
		copy.set_ElementName(this.get_ElementName());
		return (XplNode)copy;
	}

	public override CodeDOMTypes get_TypeName(){return CodeDOMTypes.XplTargetPlatform;}

	public override bool Write(XplWriter writer){
		bool result=true;
		//Escribo el encabezado del elemento
		writer.WriteStartElement( this.get_ElementName() );
		//Escribo los atributos del elemento
		if(p_uniqueName != "")
			writer.WriteAttributeString( "uniqueName" ,ZoeHelper .Att_ToString(p_uniqueName) );
		if(p_simpleName != "")
			writer.WriteAttributeString( "simpleName" ,ZoeHelper .Att_ToString(p_simpleName) );
		if(p_minVersion != "")
			writer.WriteAttributeString( "minVersion" ,ZoeHelper .Att_ToString(p_minVersion) );
		if(p_maxVersion != "")
			writer.WriteAttributeString( "maxVersion" ,ZoeHelper .Att_ToString(p_maxVersion) );
		if(p_description != "")
			writer.WriteAttributeString( "description" ,ZoeHelper .Att_ToString(p_description) );
		if(p_supportLevel != XplPlatformsupportlevel_enum.COMPLETE)
			writer.WriteAttributeString( "supportLevel" , CodeDOM_STV.XPLPLATFORMSUPPORTLEVEL_ENUM[(int)p_supportLevel] );
		if(p_operatingsystem != "")
			writer.WriteAttributeString( "operatingsystem" ,ZoeHelper .Att_ToString(p_operatingsystem) );
		if(p_aplication != "")
			writer.WriteAttributeString( "aplication" ,ZoeHelper .Att_ToString(p_aplication) );
		if(p_multitask != "Preemtive")
			writer.WriteAttributeString( "multitask" ,ZoeHelper .Att_ToString(p_multitask) );
		if(p_memorymodel != XplMemorymodel_enum.LINEAL)
			writer.WriteAttributeString( "memorymodel" , CodeDOM_STV.XPLMEMORYMODEL_ENUM[(int)p_memorymodel] );
		if(p_defaultbitorder != XplBitorder_enum.IGNORE)
			writer.WriteAttributeString( "defaultbitorder" , CodeDOM_STV.XPLBITORDER_ENUM[(int)p_defaultbitorder] );
		if(p_defaultbyteorder != XplBitorder_enum.IGNORE)
			writer.WriteAttributeString( "defaultbyteorder" , CodeDOM_STV.XPLBITORDER_ENUM[(int)p_defaultbyteorder] );
		if(p_addresswidth != 32)
			writer.WriteAttributeString( "addresswidth" ,ZoeHelper .Att_ToString(p_addresswidth) );
		if(p_databus != 32)
			writer.WriteAttributeString( "databus" ,ZoeHelper .Att_ToString(p_databus) );
		if(p_commonregisterssize != 32)
			writer.WriteAttributeString( "commonregisterssize" ,ZoeHelper .Att_ToString(p_commonregisterssize) );
		if(p_segments != 0)
			writer.WriteAttributeString( "segments" ,ZoeHelper .Att_ToString(p_segments) );
		if(p_segmentsize != 0)
			writer.WriteAttributeString( "segmentsize" ,ZoeHelper .Att_ToString(p_segmentsize) );
		if(p_threading != "")
			writer.WriteAttributeString( "threading" ,ZoeHelper .Att_ToString(p_threading) );
		//Escribo recursivamente cada elemento hijo
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
					case "uniqueName":
						this.set_uniqueName(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "simpleName":
						this.set_simpleName(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "minVersion":
						this.set_minVersion(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "maxVersion":
						this.set_maxVersion(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "description":
						this.set_description(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "supportLevel":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLPLATFORMSUPPORTLEVEL_ENUM){
							if(str==tmpStr){this.set_supportLevel((XplPlatformsupportlevel_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'supportLevel' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "operatingsystem":
						this.set_operatingsystem(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "aplication":
						this.set_aplication(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "multitask":
						this.set_multitask(ZoeHelper .StringAtt_To_STRING(reader.Value));
						break;
					case "memorymodel":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLMEMORYMODEL_ENUM){
							if(str==tmpStr){this.set_memorymodel((XplMemorymodel_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'memorymodel' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "defaultbitorder":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLBITORDER_ENUM){
							if(str==tmpStr){this.set_defaultbitorder((XplBitorder_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'defaultbitorder' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "defaultbyteorder":
						tmpStr=ZoeHelper .StringAtt_To_STRING(reader.Value);
						count=0;flag=false;
						foreach(string str in CodeDOM_STV.XPLBITORDER_ENUM){
							if(str==tmpStr){this.set_defaultbyteorder((XplBitorder_enum)count);flag=true;break;}
							count++;
						}
						if(!flag)throw new CodeDOM_Exception("Linea: "+reader.LineNumber+".Valor invalido del atributo 'defaultbyteorder' en elemento '"+this.get_ElementName()+"'.");
						break;
					case "addresswidth":
						this.set_addresswidth(ZoeHelper .StringAtt_To_UINT(reader.Value));
						break;
					case "databus":
						this.set_databus(ZoeHelper .StringAtt_To_UINT(reader.Value));
						break;
					case "commonregisterssize":
						this.set_commonregisterssize(ZoeHelper .StringAtt_To_UINT(reader.Value));
						break;
					case "segments":
						this.set_segments(ZoeHelper .StringAtt_To_UINT(reader.Value));
						break;
					case "segmentsize":
						this.set_segmentsize(ZoeHelper .StringAtt_To_UINT(reader.Value));
						break;
					case "threading":
						this.set_threading(ZoeHelper .StringAtt_To_STRING(reader.Value));
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
		writer.Write((int) 111 );
		writer.Write( this.get_ElementName() );
		//Escribo los atributos del elemento
		writer.Write( p_uniqueName );
		writer.Write( p_simpleName );
		writer.Write( p_minVersion );
		writer.Write( p_maxVersion );
		writer.Write( p_description );
		writer.Write( (int)p_supportLevel );
		writer.Write( p_operatingsystem );
		writer.Write( p_aplication );
		writer.Write( p_multitask );
		writer.Write( (int)p_memorymodel );
		writer.Write( (int)p_defaultbitorder );
		writer.Write( (int)p_defaultbyteorder );
		writer.Write( p_addresswidth );
		writer.Write( p_databus );
		writer.Write( p_commonregisterssize );
		writer.Write( p_segments );
		writer.Write( p_segmentsize );
		writer.Write( p_threading );
		//Escribo recursivamente cada elemento hijo
		return result;
	}

	public override XplNode BinaryRead(XplBinaryReader reader){
		this.set_ElementName( reader.ReadString() );
		//Lectura de Atributos
		p_uniqueName = reader.ReadString();
		p_simpleName = reader.ReadString();
		p_minVersion = reader.ReadString();
		p_maxVersion = reader.ReadString();
		p_description = reader.ReadString();
		p_supportLevel = (XplPlatformsupportlevel_enum)reader.ReadInt32();
		p_operatingsystem = reader.ReadString();
		p_aplication = reader.ReadString();
		p_multitask = reader.ReadString();
		p_memorymodel = (XplMemorymodel_enum)reader.ReadInt32();
		p_defaultbitorder = (XplBitorder_enum)reader.ReadInt32();
		p_defaultbyteorder = (XplBitorder_enum)reader.ReadInt32();
		p_addresswidth = reader.ReadUInt32();
		p_databus = reader.ReadUInt32();
		p_commonregisterssize = reader.ReadUInt32();
		p_segments = reader.ReadUInt32();
		p_segmentsize = reader.ReadUInt32();
		p_threading = reader.ReadString();
		//Lectura de Elementos
		return this;
	}
/// <summary>
/// Adds arg2 node to the end of the Children collection of arg1 node.
/// </summary>
/// <param name="arg1">Node to which arg2 will be added as children.</param>
/// <param name="arg2">Node to add to arg1 as children.</param>
/// <returns>arg1 node or CodeDOM_Exception if arg1 doesn't has children.</returns>
public static XplTargetPlatform operator +(XplTargetPlatform arg1, XplNode arg2)
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
public static XplTargetPlatform operator +(XplTargetPlatform arg1, XplNodeList arg2)
{
    if (arg1.Children() != null)
        arg1.Children().InsertAtEnd(arg2);
    else
        throw new CodeDOM_Exception("Node doesn't has children. Node can't be added.");
    return arg1;
}
	#endregion

	#region Funciones para obtener Atributos y Elementos
	public string get_uniqueName(){
		return p_uniqueName;
	}
	public string get_simpleName(){
		return p_simpleName;
	}
	public string get_minVersion(){
		return p_minVersion;
	}
	public string get_maxVersion(){
		return p_maxVersion;
	}
	public string get_description(){
		return p_description;
	}
	public XplPlatformsupportlevel_enum get_supportLevel(){
		return p_supportLevel;
	}
	public string get_operatingsystem(){
		return p_operatingsystem;
	}
	public string get_aplication(){
		return p_aplication;
	}
	public string get_multitask(){
		return p_multitask;
	}
	public XplMemorymodel_enum get_memorymodel(){
		return p_memorymodel;
	}
	public XplBitorder_enum get_defaultbitorder(){
		return p_defaultbitorder;
	}
	public XplBitorder_enum get_defaultbyteorder(){
		return p_defaultbyteorder;
	}
	public uint get_addresswidth(){
		return p_addresswidth;
	}
	public uint get_databus(){
		return p_databus;
	}
	public uint get_commonregisterssize(){
		return p_commonregisterssize;
	}
	public uint get_segments(){
		return p_segments;
	}
	public uint get_segmentsize(){
		return p_segmentsize;
	}
	public string get_threading(){
		return p_threading;
	}
	#endregion

	#region Funcion ChildNodes() y Attributes()
	public override string[] Attributes(){
		string[] ret = new string[18];
		ret[0] = "uniqueName";
		ret[1] = "simpleName";
		ret[2] = "minVersion";
		ret[3] = "maxVersion";
		ret[4] = "description";
		ret[5] = "supportLevel";
		ret[6] = "operatingsystem";
		ret[7] = "aplication";
		ret[8] = "multitask";
		ret[9] = "memorymodel";
		ret[10] = "defaultbitorder";
		ret[11] = "defaultbyteorder";
		ret[12] = "addresswidth";
		ret[13] = "databus";
		ret[14] = "commonregisterssize";
		ret[15] = "segments";
		ret[16] = "segmentsize";
		ret[17] = "threading";
		return ret;
	}
	public override string AttributeValue(string attributeName){
		if (attributeName=="uniqueName") return p_uniqueName.ToString();
		if (attributeName=="simpleName") return p_simpleName.ToString();
		if (attributeName=="minVersion") return p_minVersion.ToString();
		if (attributeName=="maxVersion") return p_maxVersion.ToString();
		if (attributeName=="description") return p_description.ToString();
		if (attributeName=="supportLevel") return p_supportLevel.ToString();
		if (attributeName=="operatingsystem") return p_operatingsystem.ToString();
		if (attributeName=="aplication") return p_aplication.ToString();
		if (attributeName=="multitask") return p_multitask.ToString();
		if (attributeName=="memorymodel") return p_memorymodel.ToString();
		if (attributeName=="defaultbitorder") return p_defaultbitorder.ToString();
		if (attributeName=="defaultbyteorder") return p_defaultbyteorder.ToString();
		if (attributeName=="addresswidth") return p_addresswidth.ToString();
		if (attributeName=="databus") return p_databus.ToString();
		if (attributeName=="commonregisterssize") return p_commonregisterssize.ToString();
		if (attributeName=="segments") return p_segments.ToString();
		if (attributeName=="segmentsize") return p_segmentsize.ToString();
		if (attributeName=="threading") return p_threading.ToString();
		return null;
	}
	public override XplNodeList ChildNodes(){
		XplNodeList list = new XplNodeList();
		return list;
	}
	#endregion

	#region Funciones para setear Atributos y Elementos
	public string set_uniqueName(string new_uniqueName){
		string back_uniqueName = p_uniqueName;
		p_uniqueName = new_uniqueName;
		return back_uniqueName;
	}
	public string set_simpleName(string new_simpleName){
		string back_simpleName = p_simpleName;
		p_simpleName = new_simpleName;
		return back_simpleName;
	}
	public string set_minVersion(string new_minVersion){
		string back_minVersion = p_minVersion;
		p_minVersion = new_minVersion;
		return back_minVersion;
	}
	public string set_maxVersion(string new_maxVersion){
		string back_maxVersion = p_maxVersion;
		p_maxVersion = new_maxVersion;
		return back_maxVersion;
	}
	public string set_description(string new_description){
		string back_description = p_description;
		p_description = new_description;
		return back_description;
	}
	public XplPlatformsupportlevel_enum set_supportLevel(XplPlatformsupportlevel_enum new_supportLevel){
		XplPlatformsupportlevel_enum back_supportLevel = p_supportLevel;
		p_supportLevel = new_supportLevel;
		return back_supportLevel;
	}
	public string set_operatingsystem(string new_operatingsystem){
		string back_operatingsystem = p_operatingsystem;
		p_operatingsystem = new_operatingsystem;
		return back_operatingsystem;
	}
	public string set_aplication(string new_aplication){
		string back_aplication = p_aplication;
		p_aplication = new_aplication;
		return back_aplication;
	}
	public string set_multitask(string new_multitask){
		string back_multitask = p_multitask;
		p_multitask = new_multitask;
		return back_multitask;
	}
	public XplMemorymodel_enum set_memorymodel(XplMemorymodel_enum new_memorymodel){
		XplMemorymodel_enum back_memorymodel = p_memorymodel;
		p_memorymodel = new_memorymodel;
		return back_memorymodel;
	}
	public XplBitorder_enum set_defaultbitorder(XplBitorder_enum new_defaultbitorder){
		XplBitorder_enum back_defaultbitorder = p_defaultbitorder;
		p_defaultbitorder = new_defaultbitorder;
		return back_defaultbitorder;
	}
	public XplBitorder_enum set_defaultbyteorder(XplBitorder_enum new_defaultbyteorder){
		XplBitorder_enum back_defaultbyteorder = p_defaultbyteorder;
		p_defaultbyteorder = new_defaultbyteorder;
		return back_defaultbyteorder;
	}
	public uint set_addresswidth(uint new_addresswidth){
		uint back_addresswidth = p_addresswidth;
		p_addresswidth = new_addresswidth;
		return back_addresswidth;
	}
	public uint set_databus(uint new_databus){
		uint back_databus = p_databus;
		p_databus = new_databus;
		return back_databus;
	}
	public uint set_commonregisterssize(uint new_commonregisterssize){
		uint back_commonregisterssize = p_commonregisterssize;
		p_commonregisterssize = new_commonregisterssize;
		return back_commonregisterssize;
	}
	public uint set_segments(uint new_segments){
		uint back_segments = p_segments;
		p_segments = new_segments;
		return back_segments;
	}
	public uint set_segmentsize(uint new_segmentsize){
		uint back_segmentsize = p_segmentsize;
		p_segmentsize = new_segmentsize;
		return back_segmentsize;
	}
	public string set_threading(string new_threading){
		string back_threading = p_threading;
		p_threading = new_threading;
		return back_threading;
	}
	#endregion

	#region Funciones para obtener nuevos nodos hijos
	#endregion

}	//Fin declaración de Clase

}

/*-------Fin de Archivo Generado------------------*/

