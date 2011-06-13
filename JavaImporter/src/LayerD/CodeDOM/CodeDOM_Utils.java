package LayerD.CodeDOM;

import java.text.*;
import java.lang.*;
import java.io.*;
import java.util.*;

public class CodeDOM_Utils{
    private CodeDOM_Utils(){}
    public static String Att_ToString(String p){
	return p;
    }
    public static  String Att_ToString(int p){
	return ((Integer)p).toString();	
    }    
    public static String Att_ToString(boolean p){
	if(p)return "true";
	else return "false";
    }
    public static String Att_ToString(Date p){
	return p.toString();	
    }    
    public static int StringAtt_To_INT(String str){	
	return  Integer.parseInt(str);
    }
    public static boolean StringAtt_To_BOOLEAN(String str) {
	return Boolean.parseBoolean(str);
    }
    public static String StringAtt_To_STRING(String str){
	return str;
    }
    public static Date StringAtt_To_DATE(String str) {	
	DateFormat df = DateFormat.getDateInstance();
	try{
	    return df.parse(str);
	}
	catch(Exception e){
	    return null;
	}
    }
    public static Date GetDefaultDate(){
	try{
	    return DateFormat.getDateInstance().parse("01/01/1970");
	}
	catch(Exception e){
	}
	return null;
    }
}
