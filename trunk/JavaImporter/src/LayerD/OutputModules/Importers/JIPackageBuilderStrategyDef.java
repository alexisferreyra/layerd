package LayerD.OutputModules.Importers;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.ArrayList;
import java.util.StringTokenizer;
import java.util.jar.JarEntry;
import java.util.jar.JarInputStream;

/**
 * Build a JIPackage searching for classes anda packages of the jre.
 *
 * @author Demián
 *
 */
public class JIPackageBuilderStrategyDef implements JIPackageBuilderStrategy {
    private String runTimeJar;
    private String javaHomeLib;
    private String sunBootClassPath;
    
    public JIPackageBuilderStrategyDef() {
        runTimeJar = "rt.jar";
        javaHomeLib = System.getProperty("java.home") + File.separator + "lib"; 
        sunBootClassPath = System.getProperty("sun.boot.class.path");
    }
    
    public JIPackageBuilderStrategyDef(String runTimeJarFileName, String javaHomeLibPath, String sunBootClassPath) {
        this.runTimeJar = runTimeJarFileName;
        this.javaHomeLib = javaHomeLibPath; 
        this.sunBootClassPath = sunBootClassPath;
    }    
    
    public JIPackage build(String packageName, String root) throws JIPackageException {
        ArrayList classes = new ArrayList();
        boolean existPackage = false;
        boolean existRunTimeJar = false;
        StringTokenizer tokenizer = new StringTokenizer(sunBootClassPath, File.pathSeparator);

        String token = null;
        while(tokenizer.hasMoreTokens()) {
            token = tokenizer.nextToken();
            if(token.equals(javaHomeLib + File.separator + runTimeJar)) {
                existRunTimeJar = true;
                break;
            }
        }
        
        if(existRunTimeJar) {
            File file = new File(token);
            String formatedPackageName = new String();
            String entryName = new String();
            String formatedEntryName = new String();

            try {
                JarEntry jEntry = null;
                JarInputStream jis = new JarInputStream(new FileInputStream(file), false);

                while((jEntry = jis.getNextJarEntry()) != null) {
                    formatedPackageName = packageName.replaceAll("\\.","/" );                    
                    entryName = jEntry.getName();

                    if(entryName.endsWith(".class")) {
                        if(entryName.startsWith(formatedPackageName)) {
                            existPackage = true;
                            formatedEntryName = entryName.replaceAll(".class", "").replaceAll("/", "\\.");
                            if(!classes.contains(formatedEntryName)) {
                                classes.add(formatedEntryName);
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

            if(!existPackage) {
                throw new JIPackageBuilderException("El paquete \"" + packageName + "\" no existe.");
            }
        } else {
            throw new JIPackageBuilderException("El archivo runtime de java \"" + runTimeJar + "\" no existe.");            
        }
        
        return new JIPackage(packageName,  classes);
    }
}
