package Test;

import LayerD.OutputModules.Importers.JIPackage;
import LayerD.OutputModules.Importers.JIPackageBuilder;
import LayerD.OutputModules.Importers.JIPackageException;

import java.util.jar.*;

public class TestPaquete {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		//Paquete p = new Paquete("LayerD", "D:\\Codigos\\Eclipse\\LayerD");
		//Paquete p = new Paquete("LayerD.CodeDom", "D:\\Codigos\\Eclipse\\LayerD");
		//Paquete p = new Paquete("LayerD.OutputModules", "D:\\Codigos\\Eclipse\\LayerD");
		//Paquete p = new Paquete("LayerD.OutputModules.Importers", "D:\\Codigos\\Eclipse\\LayerD");
		//Paquete p = new Paquete("App", "D:\\Codigos\\Eclipse\\e3d");
		
		//JIPackageBuilder b = new JIPackageBuilder("LayerD", "D:\\Codigos\\Eclipse\\LayerD");

		JIPackageBuilder b = new JIPackageBuilder("espresso3d.engine.world", "D:\\Codigos\\espresso3d\\espresso3d.jar");
		try {
			JIPackage p;
			p = b.build();
			p.countClasses();
		} catch (JIPackageException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return;
	}
}
