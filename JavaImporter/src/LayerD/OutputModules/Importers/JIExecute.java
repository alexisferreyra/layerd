package LayerD.OutputModules.Importers;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Iterator;

import LayerD.CodeDOM.CodeDOM_Exception;
import LayerD.CodeDOM.CodeDOM_STV;
import LayerD.CodeDOM.XplDocumentBody;
import LayerD.CodeDOM.XplDocumentData;
import LayerD.CodeDOM.XplDocumenttype_enum;
import LayerD.CodeDOM.XplError;
import LayerD.CodeDOM.XplImportProcessConfig;
import LayerD.CodeDOM.XplLayerDErrorInterchangeConfig;
import LayerD.CodeDOM.XplName;
import LayerD.CodeDOM.XplNamespace;
import LayerD.CodeDOM.XplNode;
import LayerD.CodeDOM.XplNodeList;
import LayerD.CodeDOM.XplReader;
import LayerD.CodeDOM.XplWriter;
import LayerD.CodeDOM.XplDocument;
import LayerD.CodeDOM.XplParser.ParseException;

public class JIExecute {
//	public static final int ABNORMAL_EXIT = 0; 
//	public static final int NORMAL_EXIT = 1;
//	
//	public static void main(String[] args) {
//		String errorFileName = null;
//		String outputFileName = null;
//		
//		if(args.length < 1 || args.length > 1) {
//			System.exit(ABNORMAL_EXIT);
//		}
//		
//		String []splitArg = args[0].split(":");
//		if(splitArg.length > 2 || splitArg[0].charAt(0) != '-') {
//			System.exit(ABNORMAL_EXIT);
//		}
//		
//		if(splitArg[0].substring(splitArg[0].indexOf("-") + 1, splitArg[0].length()).equalsIgnoreCase("processimport")) {
//			File f = new File(splitArg[1]);
//			if(!f.exists()) {
//				System.exit(ABNORMAL_EXIT);	
//			}
//			
//			XplXPLDocument doc = new XplXPLDocument();
//			try {
//				XplReader reader = new XplReader(splitArg[1]);
//				reader.Read();
//				doc.Read(reader);
//				XplDocumentData docData = doc.get_DocumentData();
//				if(docData == null) {
//					System.exit(ABNORMAL_EXIT);
//				}
//				
//				XplImportProcessConfig config = (XplImportProcessConfig)docData.get_Config().get_tConfig();
//				if(config == null) {
//					System.exit(ABNORMAL_EXIT);
//				}
//				
//				errorFileName = config.get_ErrorsFileName();
//				outputFileName = config.get_ImportedProgram();
//				
//				/*Si DocumentType no es import_process no es un documento valido */
//				if(!CodeDOM_STV.XPLDOCUMENTTYPE_ENUM[docData.get_DocumentType()].equalsIgnoreCase("import_process")) {
//					System.exit(ABNORMAL_EXIT);
//				}
//				
//				XplDocumentBody docBody = doc.get_DocumentBody();
//				if(docBody == null) {
//					System.exit(ABNORMAL_EXIT);
//				}
//				
//				XplNodeList importNodeList = docBody.get_ImportNodeList();
//				if(importNodeList == null) {
//					System.exit(ABNORMAL_EXIT);
//				}
//				
//				ArrayList argumentos = new ArrayList();
//				XplName tmpNode = (XplName)importNodeList.FirstNode();
//				for(;tmpNode != null;tmpNode = (XplName)importNodeList.NextNode()) {
//					XplNodeList nsNodeList = tmpNode.get_nsNodeList();
//					XplNode tmpNsNodeList = nsNodeList.FirstNode();
//					StringBuffer argI = new StringBuffer();
//					for(;tmpNsNodeList != null;tmpNsNodeList = nsNodeList.NextNode()) {
//						argI.append(tmpNsNodeList.get_stringValue()+";");
//					}
//					
//					argI.delete(argI.lastIndexOf(";"), argI.lastIndexOf(";")+1);
//					argumentos.add(argI.toString());
//					argI = null;
//				}
//				
//				JavaImporter ji = new JavaImporter();
//				
//				Object[] o = argumentos.toArray();
//				String[] a = new String[o.length];
//				for(int i = 0; i < o.length; i++) {
//					a[i] = (String)o[i];
//				}
//				argumentos = null;
//				
//				if(ji.processImport(a, false)) {
//					XplXPLDocument outDoc = new XplXPLDocument();
//					outDoc.set_Name("XPLDocument");
//					XplDocumentBody body = XplXPLDocument.new_DocumentBody();
//					
//					if(ji.getXplNamespaces() != null) {
//				        Iterator i = ji.getXplNamespaces().values().iterator();
//				        while(i.hasNext()) {
//				            XplNamespace tmp = (XplNamespace)i.next();
//				        	body.Childs().InsertAtEnd(tmp);
//				        }
//					}
//				
//					outDoc.set_DocumentBody(body);
//					XplWriter myWriter = new XplWriter(outputFileName);
//					outDoc.Write(myWriter);
//					myWriter.Close();
//
//					//falta sacar los errors y warnings a un documento	
//					XplLayerDErrorInterchangeConfig errorInterchange = new XplLayerDErrorInterchangeConfig();
//					XplError xplError = null;
//					
//					XplNodeList nodeList = new XplNodeList();
//					
//					for(Object error : ji.getErrors()) {
//						xplError = XplLayerDErrorInterchangeConfig.new_Error();
//						xplError.set_sourcefile("unknown");
//						xplError.set_sourceType(0);
//						xplError.set_sourcepos("unknown");
//						xplError.set_ErrorString((String)error);
//						nodeList.InsertAtEnd(xplError);
//					}
//				}
//			} catch (FileNotFoundException e) {
//				e.printStackTrace(); System.exit(ABNORMAL_EXIT);
//			} catch (ParseException e) {
//				e.printStackTrace(); System.exit(ABNORMAL_EXIT);
//			} catch (CodeDOM_Exception e) {
//				e.printStackTrace(); System.exit(ABNORMAL_EXIT);
//			} catch (IOException e) {
//				e.printStackTrace(); System.exit(ABNORMAL_EXIT);
//			}
//		}
//	}
}