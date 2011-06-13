package Test;

import java.io.IOException;
import java.util.Iterator;

import LayerD.CodeDOM.CodeDOM_Exception;
import LayerD.CodeDOM.XplDocumentBody;
import LayerD.CodeDOM.XplNamespace;
import LayerD.CodeDOM.XplWriter;
import LayerD.CodeDOM.XplDocument;
import LayerD.OutputModules.Importers.JavaImporter;

public class TestImportersCSharp {
    public static void main(String[] args) throws IOException, CodeDOM_Exception {
        JavaImporter ji = new JavaImporter();
        /*String []arg = {
            "ns=zoe;Test;packagePath=C:\\Documents and Settings\\JavaOutputModule\\build\\classes;recursiveimport=false",
            "ns=zoe;java.lang;recursiveimport=false"};*/
        
        System.out.println("Ejecutando main de TestImportersCSharp.");
        
        for(int i = 0; i < args.length; i++) {
            System.out.println(args[i]);
        }
        
        /*if(args == null || args.length == 0) {
             System.out.println("Faltan los argumentos. Se usaran unos hardcodeados.");
             args = arg;
        }*/
        
        String outputFile = "java_imported_types.xml";
        
        if(ji.processImport(args, false)) {
            XplDocument doc = new XplDocument();
            doc.set_Name("XPLDocument");
            XplDocumentBody body = XplDocument.new_DocumentBody();
            
            if(ji.getXplNamespaces() != null) {
                Iterator i = ji.getXplNamespaces().values().iterator();
                while(i.hasNext()) {
                    XplNamespace tmp = (XplNamespace)i.next();
                    body.Childs().InsertAtEnd(tmp);
                }
            }
            
            doc.set_DocumentBody(body);
            XplWriter myWriter = new XplWriter(outputFile);
            doc.Write(myWriter);
            myWriter.Close();
        } else {
            System.out.println("Warnings: " + ji.getWarningsAsString());
            System.out.println("Errors: " + ji.getErrorsAsString());
        }
        
        System.out.println("Fin.");
    }
}

