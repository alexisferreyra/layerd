package LayerD.OutputModules.Importers;

/**
 *
 * @author Demián
 *
 */
public class JIPackageBuilder {
    public static final String JAVACLASSES = "default";
    
    private JIPackageBuilderStrategy strategy;
    private String packageName;
    private String root;
    
    /**
     * Constructor que setea la estrategia a utilizar para construir un JIPackage segun
     * el parametro root. Si root tiene una ruta de un archivo .jar la estrategia
     * es construir un JIPackage desde un .jar. Si root tiene una ruta de directorio
     * la estrategia es construir un JIPackage desde las clases y paquetes que hay
     * en ese directorio. Si root es la cadena "" o la cadena indicada por la
     * constante JIPackageBuilder.JAVACLASSES la estrategia es construir un JIPackage desde el jre.
     *
     * @param packageName nombre del paquete que se quiere obtener todos las clases. Debe
     * respetar el "nombre largo". Ej: java, java.lang, java.utils
     * @param root indica una ruta de archivo jar o una ruta de directorio o una cadena "" o la
     * constante JIPackageBuilder.JAVACLASSES.
     */
    public JIPackageBuilder(String packageName, String root) {
        if(root.equalsIgnoreCase(JAVACLASSES) || root.equals("\"\"")) {
            strategy = new JIPackageBuilderStrategyDef();
        }else if(root.toLowerCase().endsWith(".jar")) {
            strategy = new JIPackageBuilderStrategyJar();
        } else {
            strategy = new JIPackageBuilderStrategyDir();
        }
        
        this.packageName = packageName;
        this.root = root;
    }
    
    /**
     * Setea la estrategia a utilizar para armar un JIPackage.
     *
     * @param strategy una estrategia valida. La estrategia debe implementar la
     * interfaz JIPackageBuilderStrategy.
     */
    public void setBuilderStrategy(JIPackageBuilderStrategy strategy) {
        this.strategy = strategy;
    }
    
    /**
     * Inicia el proceso de construccion de un JIPackage.
     *
     * @return una instancia JIPackage con todoas las clases del paquete y las
     * clases de los subpaquetes.
     * @throws JIPackageException
     */
    public JIPackage build() throws JIPackageException {
        return strategy.build(packageName, root);
    }
}
