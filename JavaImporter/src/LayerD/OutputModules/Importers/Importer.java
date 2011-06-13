/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package LayerD.OutputModules.Importers;

import java.io.IOException;
import java.util.Iterator;

import LayerD.CodeDOM.CodeDOM_Exception;
import LayerD.CodeDOM.XplDocumentBody;
import LayerD.CodeDOM.XplNamespace;
import LayerD.CodeDOM.XplWriter;
import LayerD.CodeDOM.XplDocument;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Importer {
    public static void main(String[] args) {               
        String outputFile = "java_imported_types.xml";
        
        JavaImporter ji = new JavaImporter();
        
        // Disable the log :-P
        JILog.getInstance().enable(false);
        
        if(ji.processImport(args, false)) {
            try {
                XplDocument doc = new XplDocument();
                doc.set_Name("XPLDocument");
                XplDocumentBody body = XplDocument.new_DocumentBody();

                if (ji.getXplNamespaces() != null) {
                    Iterator i = ji.getXplNamespaces().values().iterator();
                    while (i.hasNext()) {
                        XplNamespace tmp = (XplNamespace) i.next();
                        body.Childs().InsertAtEnd(tmp);
                    }
                }

                doc.set_DocumentBody(body);
                XplWriter myWriter = new XplWriter(outputFile);
                doc.Write(myWriter);
                myWriter.Close();

                System.out.println("End importing types.");
            } catch (IOException ex) {
                Logger.getLogger(Importer.class.getName()).log(Level.SEVERE, null, ex);
            } catch (CodeDOM_Exception ex) {
                Logger.getLogger(Importer.class.getName()).log(Level.SEVERE, null, ex);
            }
        } else {
            System.out.println("Warnings: " + ji.getWarningsAsString());
            System.out.println("Errors: " + ji.getErrorsAsString());
        }        
    }
}
