package LayerD.OutputModules.Importers;

/**
 *
 * @author Demián
 *
 */
public interface JIPackageBuilderStrategy {
	/**
	 * Build a JIPackage for the package indicated by "packaName" and located at "root" 
         *
	 * @param packageName
	 * @param root
	 * @return una instancia a un JIPackage con todas las clases del paquete y de los paquetes dentro de este.
	 * @throws JIPackageException
	 */
	public JIPackage build(String packageName, String root) throws JIPackageException;
}
