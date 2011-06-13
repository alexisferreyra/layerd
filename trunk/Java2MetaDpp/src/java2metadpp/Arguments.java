/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package java2metadpp;

import java.util.Hashtable;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

/**
 * This class represents command lines arguments passed to the tool
 * @author Alexis
 */
public class Arguments {

    public static final String OUTPUT_PATH = "output_path";
    public static final String SILENT = "silent";
    public static final String CALLMETADPPC = "call_metadppc";
    public static final String CALLZOEC = "call_zoec";
    public static final String METADPPC_ARGUMENTS = "metadppc_arguments";
    public static final String ZOEC_ARGUMENTS = "zoec_arguments";
    public static final String REMOVE_DPP = "remove_dpp";
    public static final String GENERATE_TOSTRING = "generate_tostring";
    public static final String GENERATE_CLASSPROPERTY = "generate_classproperty";
    public static final String DONOT_GENERATE_IMPORTS = "donot_generate_imports";

    private List<String> fileNames;
    private Map<String,String> options;

    public Arguments(){
        fileNames = new LinkedList<String>();
        options = new Hashtable<String,String>();
    }   
    
    /**
     * List of source filenames
     * @return a list of source file names
     */
    public List<String> getFileNames() {
        return fileNames;
    }
   
    /**
     * Return the string value for the option, null
     * if the option is not set
     * @param optionName
     * @return string value for the option or null if the option doesn't exists
     */
    public String getOption(String optionName){
        return options.containsKey(optionName) ? options.get(optionName) : null;
    }
    /**
     * Get setted output path
     * @return null if no path where set, the path otherwise
     */
    public String getOutputPath(){
        String outputPath = getOption(OUTPUT_PATH);
        return outputPath != null ? outputPath : "";
    }
    /**
     * Set output path into options collection
     * using OUTPUT_PATH as key
     * @param outputPath Path string value
     */
    public void setOutputPath(String outputPath){
        options.put(OUTPUT_PATH, outputPath);
    }

    void addOption(String argName, String argValue) {
        if(options.containsKey(argName)) options.remove(argName);
        options.put(argName, argValue);
    }

    /**
     * Returns if the option is "true"
     * @param optionName
     * @return true or false
     */
    boolean isOptionTrue(String optionName) {
        if(this.getOption(optionName)!=null)return this.getOption(optionName).equals("true");
        else return false;
    }
}
