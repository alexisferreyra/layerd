package LayerD.OutputModules.Importers;

import LayerD.CodeDOM.XplDocument;

/**
 La interfaz IXPLImportsDirectiveProcessor. 
 Define un metodo estandar para procesar directivas import.
 Debe ser implementada por Modulos de Salida para poder
 procesar directivas import.
*/
public interface IXPLImportsDirectiveProcessor
{
    /**
     Procesa una directiva "Import" con los argumentos "args".
     "generateOutputFile" indica si se guarda un archivo en disco
     con el documento XPL de importaci�n o no.
     @param args: . 
     @param generateOutputFile: .
     @return True si se proceso con exito, False si no pudo ser procesada la directiva.
     */
	boolean processImport(String []args, boolean generateOutputFile);
	
    /**
     Devuelve un XplDocument con los datos de la �ltima directiva "Import" procesada.
     Retorna null si la �ltima directiva no se proceso con exito.
    */
    XplDocument getLastImportDocument();
    
    /**
     Devuelve el nombre y path del archivo que se genero con el procesamiento de la
     �ltima directiva "Import".
     @return Null si la �ltima directiva no genero un archivo.
    */
    String getLastImportFileName();
    
    /**
     Devuelve una matriz con mensajes de advertencia emitidos al procesar
     la �ltima directiva "Import".
     @return Nulo si no se producieron advertencias.
    */
	String[] getLastImportWarnings();
	
    /**
     Devuelve una matriz con mensajes de Errores producidos al
     procesar la �ltima directiva "Import".
     @return
    */
	String[] getLastImportErrors();
}


