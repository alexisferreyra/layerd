package LayerD.OutputModules.Importers;

import java.io.File;
import java.io.FilenameFilter;

/**
 * Clase que implementa FilenameFilter para filtrar archivos .class.
 * 
 * Ej: 
 * 
 * @author Demián
 *
 */

public class ClassFileFilter implements FilenameFilter {
	public boolean accept(File dir, String name) {
		if(name.toLowerCase().endsWith(".class")) {
			return true;
		}
		
		return false;
	}	
}
