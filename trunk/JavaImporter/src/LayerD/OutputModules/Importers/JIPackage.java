package LayerD.OutputModules.Importers;

import java.util.ArrayList;
import java.util.Arrays;

/**
 * Represente todas las calses de un paquete y las clases de un subpaquete del paquete.
 * 
 * @author Demián
 *
 */
public class JIPackage {
	private String name;
	private String shortName;
	private ArrayList classes;
	
	/**
	 * Construye un objeto JIPackage asginandole un nombre y una lista de clases que
	 * contiene el paquete.
	 * 
	 * @param nombre
	 * @param clases
	 */
	public JIPackage(String nombre, ArrayList clases) {
		clases.trimToSize();
		this.name = nombre;
		this.classes = clases;
		
		if(nombre.lastIndexOf(".") > 0) {
			this.shortName = nombre.substring(nombre.lastIndexOf(".") + 1, nombre.length());		
		} else {
			this.shortName = nombre;
		}		
	}
	
	/**
	 * @return Lista de 
	 */
	public ArrayList getClasses() {
		return classes;
	}

	/**
	 * 
	 * @param classes
	 */
	public void setClasses(ArrayList classes) {
		classes.trimToSize();
		this.classes = classes;
	}

	public String getName() {
		return name;
	}

	/**
	 * 
	 * @param name
	 */
	public void setName(String name) {
		this.name = name;
	}

	public String getShortName() {
		return shortName;
	}

	/**
	 * 
	 * @param shortName
	 */
	public void setShortName(String shortName) {
		this.shortName = shortName;
	}

	public boolean hasClasses() {
		return classes.isEmpty();
	}
	
	/**
	 * 
	 * @param className
	 * @return
	 */
	public boolean hasThisClass(String className) {
		JIAlphabeticComparator alpha = new JIAlphabeticComparator();
		Arrays.sort(this.classes.toArray(), alpha);
		return Arrays.binarySearch(this.classes.toArray(), className, alpha) >= 0 ? true : false;
	}
	
	/**
	 * 
	 * @return
	 */
	public int countClasses() {
		return classes.size();
	}
	
	/**
	 * Obtiene el nombre del paquete desde el nombre largo de una clase.
	 * Ej: java.lang.String regresa java.lang
	 * 
	 * @param fullClassName nombre largo de una clase.
	 * @return el nombre del paquete que contiene la clase.
	 */
	public static String getPackageNameFrom(String fullClassName) {
		if(fullClassName.lastIndexOf(".") > 0 ) {
			return fullClassName.substring(0, fullClassName.lastIndexOf("."));
		} else {
			return fullClassName;
		}
	}		
}
