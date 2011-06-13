package LayerD.CodeDOM;

import java.lang.*;
import java.io.*;
import java.util.*;

public class XplNodeList {
    ArrayList p_list=null;
    XplNode p_parent=null;
    XplNodeListCallbacks p_Callback=null;
    int p_counter=0;
    
    public XplNodeList(){
	p_list=new ArrayList();
    }
    public void set_Parent(XplNode new_parent){
	p_parent=new_parent;
    }
    public boolean Write(XplWriter writer) throws IOException, CodeDOM_Exception{
	XplNode node;
	for(int n=0;n<p_list.size();n++){
	    node=(XplNode)p_list.get(n);
	    if(!node.Write(writer))return false;
	}
	return true;
    }
    public void set_CheckNodeCallback(XplNodeListCallbacks callback){
	p_Callback=callback;
    }
    public XplNode  FirstNode() {
	p_counter=0;
	if(p_list.size()>0)
	    return (XplNode)p_list.get(p_counter);
	else
	    return null;
    }
    public XplNode NextNode(){
	p_counter++;
	if(p_counter<p_list.size())
	    return (XplNode)p_list.get(p_counter);
	return null;
    }
    public XplNode PreviousNode(){
	p_counter--;
	if(p_counter<0)p_counter=0;
	if(p_counter<p_list.size())
	    return (XplNode)p_list.get(p_counter);
	return null;
    }
    public XplNode LastNode(){
	if(p_list.size()>0)
	    return (XplNode)p_list.get(p_list.size()-1);
	else
	    return null;
    }
    public XplNode InsertAtEnd(XplNode newNode){
	if(p_Callback==null || p_Callback.InsertCallback(this, newNode, p_parent)){
	    p_list.add(newNode);
	    return newNode;
	} else return null;
    }
    public XplNode InsertAtBegin(XplNode newNode){
	if(p_Callback==null || p_Callback.InsertCallback(this, newNode, p_parent)){
	    p_list.add(0,newNode);
	    return newNode;
	} else return null;
    }
    public XplNode getNodeAt(int position){
	return (XplNode)p_list.get(position);
    }
    public int getLenght(){
	return p_list.size();
    }
    public XplNode InsertAt(XplNode newNode, int position){
	if(p_Callback==null || p_Callback.InsertCallback(this, newNode, p_parent)){
	    p_list.add(position,newNode);
	    return newNode;
	} else return null;
    }
    public XplNode InsertAfter(XplNode newNode, XplNode reference){
	if(p_Callback==null || p_Callback.InsertCallback(this, newNode, p_parent)){
	    int tmpIdx=p_list.indexOf(reference);
	    p_list.add(tmpIdx+1,newNode);
	    return newNode;
	} else return null;
    }
    public XplNode InsertBefore(XplNode newNode, XplNode reference){
	if(p_Callback==null || p_Callback.InsertCallback(this, newNode, p_parent)){
	    int tmpIdx=p_list.indexOf(reference);
	    p_list.add(tmpIdx,newNode);
	    return newNode;
	} else return null;
    }
    public XplNode Remove(int position){
	XplNode node=(XplNode)p_list.get(position);
	if(p_Callback==null || p_Callback.RemoveNodeCallback(this, node, p_parent)){
	    p_list.remove(node);
	    return node;
	} else return null;
    }
    public boolean Contains(XplNode Node){
	return p_list.contains(Node);
    }
    public boolean Clear(){
	p_list.clear();
	return true;
    }
    public String get_TypeName(){
	return "XplNodeList";
    }
}



