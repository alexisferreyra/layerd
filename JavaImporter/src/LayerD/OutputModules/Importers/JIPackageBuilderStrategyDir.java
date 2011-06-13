package LayerD.OutputModules.Importers;

import java.io.File;
import java.util.ArrayList;

/**
 * Construye un JIPackage buscando las clases y paquetes que hay en un directorio. Este constructor
 * se utiliza cuando en el directorio hay clases y paquetes en forma de archivos .class y directorios.
 *
 * @author Demián
 *
 */
public class JIPackageBuilderStrategyDir implements JIPackageBuilderStrategy {
    public JIPackage build(String packageName, String rootDir) throws JIPackageException {
        String pkgNameToDir = packageName.replaceAll("\\.", "\\");
        ArrayList clases = lookForClasses("", rootDir + "\\" + pkgNameToDir);
        
        if(clases.size() > 0) {
            return new JIPackage(packageName, clases);
        } else {
            throw new JIPackageException("El paquete \"" + packageName + "\" no tiene clases en ninguno de sus niveles.");
        }
    }
    
    /**
     * Busca las clases dentro de un directorio recursivamente.
     *
     * @param superPkgName nombre largo del paquete principal.
     * @param dir directorio donde se encuentra el paquete principal.
     * @return una lista con el nombre largo de las clases que estan dentro del paquete
     * paquete principal y sus subpaquetes.
     */
    private ArrayList lookForClasses(String superPkgName, String dir) {
        ArrayList clases = new ArrayList();
        File pkgFile = new File(dir);
        
        if(pkgFile.exists() && pkgFile.isDirectory()) {
            File []files = pkgFile.listFiles();
            String actualPkgName =  new String();
            
            for(int i = 0; i < files.length; i++) {
                actualPkgName = superPkgName + pkgFile.getPath().substring(pkgFile.getPath().lastIndexOf("\\") + 1) + ".";
                
                if(files[i].isDirectory()) {
                    ArrayList tmpClases = lookForClasses(actualPkgName , files[i].getAbsolutePath());
                    if(!tmpClases.isEmpty()) {
                        clases.addAll(tmpClases);
                    }                                     
                } else if(files[i].getName().endsWith(".class")) {
                    clases.add(actualPkgName + files[i].getName().replaceAll(".class", ""));
                }
            }
        }
        
        return clases;
    }
}
