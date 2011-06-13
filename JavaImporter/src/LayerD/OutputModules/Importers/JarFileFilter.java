package LayerD.OutputModules.Importers;

import java.io.File;
import java.io.FilenameFilter;

public class JarFileFilter implements FilenameFilter {
	public boolean accept(File dir, String name) {
		if(name.toLowerCase().endsWith(".jar")) {
			return true;
		}
		
		return false;
	}	
}

