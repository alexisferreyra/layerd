package LayerD.OutputModules.Importers;

import java.io.File;
import java.lang.reflect.Method;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLClassLoader;
import java.util.ArrayList;
import java.util.Iterator;

/**
 * Clase de utilerias para dar soporte al importador java.
 *
 * @author Demián
 *
 */
public final class JIUtils {
    private static final class JIClassPath {
        private static final Class[] parameters = new Class[] {URL.class};
        
        public static void addFile(String file) throws JIUtilsException {
            File f = new File(file);
            addFile(f);
        }
        
        public static void addFile(File file) throws JIUtilsException {
            try {
                addURL(file.toURL());
            } catch (MalformedURLException e) {
                throw new JIUtilsException(e.getMessage());
            }
        }
        
        public static void addURL(URL url) throws JIUtilsException {
            URLClassLoader sysLoader = (URLClassLoader)ClassLoader.getSystemClassLoader();
            Class sysClass = URLClassLoader.class;
            
            try {
                Method method = sysClass.getDeclaredMethod("addURL", parameters);
                method.setAccessible(true);
                method.invoke(sysLoader, new Object []{url});
            } catch(Throwable t) {
                throw new JIUtilsException("No se pudo agregar el url \"" + url.toString() + "\"al URLClassLoader del sistema. "
                        + t.getMessage());
            }
        }
    }
    
    /**
     * Cambia la ocurrencia de caracteres de "." y "$" a ":".
     * Ej: "java.lang.String$Char" --> "java:lang:String:Char"
     *
     * @param str: string a procesar.
     * @return un string donde los "." en el parametro "str" se cambiaron a ":". Si el parametro
     * "str" no tiene "." regresa una copia de "str".
     */
    public static String processTypeName(String str) {
        //return str.replaceAll("\\.", ":").replaceAll("\\$", ":");
        return str.replaceAll("\\$", ".");
    }
    
    /**
     * Obtiene el tipo (clase, interfaz o tipo primitivo) del array. Maneja casos de
     * arrays multidimensionales.
     *
     * @param c: array.
     * @return El tipo (clase, interfaz o tipo primitivo) del array. Si "c" no es un
     * array regresa null.
     */
    public static Class getClassFromArray(Class c) {
        Class i = c.getComponentType();
        Class lastI = null;
        
        if(c.isArray()) {
            while(i != null) {
                //Si es un array multidimensional
                lastI = i;
                i = i.getComponentType();
            }
        }
        
        return lastI;
    }
    
    /**
     * Obtiene la dimension del array. String []a -> dim = 1 String [][]a -> dim = 2
     *
     * @param c: array.
     * @return la dimension del array..
     */
    public static int getDimFromArray(Class c) {
        Class i = c.getComponentType();
        //Class lastI = null;
        int dim = 0;
        
        if(c.isArray()) {
            while(i != null) {
                //Si es un array multidimensional
                //lastI = i;
                i = i.getComponentType();
                ++dim;
            }
        }
        
        return dim;
    }
    
    /**
     * Indica si una clase es anonima chequeando el formato
     * del nombre de la clase. Una clase es anonima segun su nombre
     * si dicho nombre es de la forma "nombre_clase$0..9" Ej: String$1
     * En este ejemple $1 esta indicando una clase anonima.
     *
     * @param c: clase a chequear si es anonima.
     * @return true se el parametro "c" representa una clase anonima, false
     * en caso contrario.
     */
    public static boolean isAnonymousClass(Class c) {
        String name = c.getName();
        int idx = name.lastIndexOf("$");
        
        if(idx > 0) {
            name = name.substring(idx + 1);
            if(name.matches("[0-9]")) {
                return true;
            }
        }
        
        return false;
    }
    
    /**
     * Indica si una clase es interna chequeando el formato
     * de su nombre. Ej: Attributes$Name, Name es una clase interna
     * de la clase Attributes.
     *
     * @param c
     * @return
     */
    public static boolean isInternalClass(Class c) {
        if(c.getDeclaringClass() != null) {
            return true;
        }
        
        return false;
    }
    
    /**
     * Carga en el system class loader librerias o las librerias en un directorio.
     * Ej: args: "d:\codigos\eclipse\libs" --> carga todas las librerias que
     * haya en el directorio.
     *     args. "d:\codigos\eclipse\layerd\layerd.jar;d:\codigos\eclipse\layerd\codedom.jar" -->
     * carga solo las librerias layerd.jar y codedom.jar
     *
     * @param args lista de librerias o directorio separados por ";"
     * @throws JIUtilsException
     */
    public static final void loadLibClassPath(String args) throws JIUtilsException {
        String []paths = args.split(";");
        ArrayList tmpLibPaths = new ArrayList();
        
        for(int i = 0; i < paths.length; i++) {
            if(!tmpLibPaths.contains(paths[i])) {
                tmpLibPaths.add(paths[i]);
            }
        }
        
        Iterator iterator = tmpLibPaths.iterator();
        while(iterator.hasNext()) {
            String path = (String)iterator.next();
            File tmpFile = new File(path);
            
            if(tmpFile.isDirectory()) {
                String []list = tmpFile.list(new JarFileFilter());
                for(int ii = 0; ii < list.length; ii++) {
                    JIClassPath.addFile(tmpFile.getAbsolutePath() + File.separator + list[ii]);
                }
            } else {
                String tmpFileName = tmpFile.getAbsolutePath();
                if(tmpFileName.endsWith(".jar")) {
                    JIClassPath.addFile(tmpFile.getAbsolutePath() + File.separator + tmpFileName);
                }
            }
        }
    }
    
    /**
     * Carga en el system class loader el directorio de un paquete.
     *
     * @param path Directorio/s donde se encuentra un paquete java.
     * @throws JIUtilsException
     */
    public static final void loadPackageClassPath(String path) throws JIUtilsException {
        String []paths = path.split(";");
        
        ArrayList tmpPkgPaths = new ArrayList();
        for(int i = 0; i < paths.length; i++) {
            if(!tmpPkgPaths.contains(paths[i]) &&
                    !paths[i].equalsIgnoreCase(JIPackageBuilder.JAVACLASSES) &&
                    !paths[i].equals("\"\"") && paths[i].length() > 0) {
                tmpPkgPaths.add(paths[i]);
            }
        }
        
        Iterator iterator = tmpPkgPaths.iterator();
        while(iterator.hasNext()) {
            String tmpPath = (String)iterator.next();
            JIClassPath.addFile(tmpPath);
        };
    }
}
