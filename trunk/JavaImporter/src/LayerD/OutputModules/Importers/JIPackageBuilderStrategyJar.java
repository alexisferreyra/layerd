package LayerD.OutputModules.Importers;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.ArrayList;
import java.util.jar.JarEntry;
import java.util.jar.JarInputStream;

/**
 * Construye un JIPackage buscando las clases y paquetes que hay en un archivo .jar.
 *
 * @author Demián
 *
 */
public class JIPackageBuilderStrategyJar implements JIPackageBuilderStrategy {
    public JIPackage build(String packageName, String jarFile) throws JIPackageException {
        ArrayList classes = new ArrayList();
        File file = new File(jarFile);
        String formatted = new String();
        String entryName = new String();
        
        try {
            JarEntry jEntry = null;
            JarInputStream jis = new JarInputStream(new FileInputStream(file), false);
            
            while((jEntry = jis.getNextJarEntry()) != null) {
                formatted = packageName.replaceAll("\\.","/" );
                entryName = jEntry.getName();
                if(entryName.endsWith(".class")) {
                    if(entryName.startsWith(formatted)) {
                        if(!classes.contains(entryName.replaceAll(".class", "").replaceAll("/", "\\."))) {
                            classes.add(entryName.replaceAll(".class", "").replaceAll("/", "\\."));
                        }
                    }
                }
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
            throw new JIPackageBuilderException("El archivo jar \"" + file + "\" no existe.");
        } catch (IOException e) {
            e.printStackTrace();
            throw new JIPackageBuilderException(e.getMessage());
        }
        
        return new JIPackage(packageName,  classes);
    }
}
