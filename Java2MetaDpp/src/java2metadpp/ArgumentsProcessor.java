/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package java2metadpp;

import java.io.File;
import java.util.Hashtable;

/**
 * This class process comand line arguments and build an Arguments object
 * @author Alexis
 */
public class ArgumentsProcessor {
    static final String OUTPUT_PATH = "opath";
    static final String SILENT = "s";
    static final String CALLMETADPPC = "cdpp";
    static final String CALLZOEC = "czoe";
    static final String METADPPC_ARGUMENTS = "dppargs";
    static final String ZOEC_ARGUMENTS = "zoeargs";
    static final String REMOVE_DPP = "rdpp";
    static final String DONOT_GENERATE_IMPORTS = "dngi";
    static Hashtable<String,String> possibleArguments;

    static {
        // initialize hashtable of possible options
        possibleArguments = new Hashtable<String,String>();
        // command line option name , option key on Arguments object
        possibleArguments.put(ArgumentsProcessor.OUTPUT_PATH, Arguments.OUTPUT_PATH);
        possibleArguments.put(ArgumentsProcessor.SILENT, Arguments.SILENT);
        possibleArguments.put(ArgumentsProcessor.CALLMETADPPC, Arguments.CALLMETADPPC);
        possibleArguments.put(ArgumentsProcessor.CALLZOEC, Arguments.CALLZOEC);
        possibleArguments.put(ArgumentsProcessor.METADPPC_ARGUMENTS, Arguments.METADPPC_ARGUMENTS);
        possibleArguments.put(ArgumentsProcessor.ZOEC_ARGUMENTS, Arguments.ZOEC_ARGUMENTS);
        possibleArguments.put(ArgumentsProcessor.REMOVE_DPP, Arguments.REMOVE_DPP);
        possibleArguments.put(Arguments.GENERATE_CLASSPROPERTY, Arguments.GENERATE_CLASSPROPERTY);
        possibleArguments.put(Arguments.GENERATE_TOSTRING, Arguments.GENERATE_TOSTRING);
        possibleArguments.put(ArgumentsProcessor.DONOT_GENERATE_IMPORTS, Arguments.DONOT_GENERATE_IMPORTS);
    }
    /**
     * Process the array of string arguments and return processed arguments.
     * @param args
     * @return null if there are errors on the arguments, Arguments object otherwise
     */
    public static Arguments processArguments(String[] args){
        // default arguments
        Arguments arguments = new Arguments();
        processOption("-" + Arguments.GENERATE_CLASSPROPERTY + ":true", arguments);
        processOption("-" + Arguments.GENERATE_TOSTRING + ":true", arguments);
        // real arguments
        for(String arg : args){
            if(arg.startsWith("-")){
                processOption(arg, arguments);
            }
            else{
                processInputFilename(arg, arguments);
            }
        }
        return arguments;
    }

    private static void processInputFilename(String arg, Arguments arguments) {
        File file = new File(arg);
        if(file.exists()){
            arguments.getFileNames().add(arg);
        }
        else{
            Main.addError("File \"" + arg + "\" doesn't exists.");
        }
    }

    private static void processOption(String arg, Arguments arguments) {
        // remove -
        arg = arg.substring(1);
        // split option / values
        String argName, argValue;
        int index = arg.indexOf(':');
        boolean defaultArgValue = false;
        if(index>0){
            argName = arg.substring(0, index);
            argValue = arg.substring(index+1);
        }
        else{
            argName = arg;
            argValue = "true";
            defaultArgValue = true;
        }
        if(possibleArguments.containsKey(argName) ){
            if(argName.equals(OUTPUT_PATH)){
                if(!defaultArgValue){
                    arguments.setOutputPath(argValue);
                    System.out.println("Output path set to: " + arguments.getOutputPath());
                }
                else{
                    Main.addError("Option opath with invalid format");
                }
            }
            else{
                // generic option process
                arguments.addOption(possibleArguments.get(argName), argValue);
                System.out.println("Option \"" + argName + "\" added with value \"" + argValue + "\"");
            }
        }
        else{
            Main.addError("Invalid Option: " + arg);
        }
    }

}
