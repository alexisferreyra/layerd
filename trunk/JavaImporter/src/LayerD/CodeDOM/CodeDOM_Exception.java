package LayerD.CodeDOM;

import java.lang.*;
import java.io.*;
import java.util.*;

public class CodeDOM_Exception extends Exception{
    private String p_source;
    public CodeDOM_Exception(String new_error, String new_source){
	super(new_error);
	p_source=new_source;
    }
    public CodeDOM_Exception(String new_error){
	super(new_error);
    }
    public void set_error(String new_error){
	;//No se puede
    }
    public void set_source(String new_source){
	p_source=new_source;
    }
    public String get_error(){
	return super.getMessage();
    }
    public String get_source(){
	return p_source;
    }
}
