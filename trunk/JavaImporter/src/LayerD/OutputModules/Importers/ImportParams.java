package LayerD.OutputModules.Importers;

public class ImportParams{
	public String baseNamespace					= "default";
	public String globalsNamespace 				= "";
	public String constantsNamespace 			= "";
	public String platform 						= "";
	public boolean allTypesFinal				= false;	
	
	public String javaVersion 					= "1.4";	
	public String toImport 						= "";	
	public String extraPath 					= "";
	public String packagePath					= "";
	public String libPath						= "";
	public boolean includeBaseNamespace 		= true; // ?
	public boolean ignoreEnums 					= true;
	public boolean ignoreAttributes 			= true;
	public boolean ignoreGenerics 				= true;
	public boolean ignoreInheritedInterfaces	= true;
	public boolean mapToXplNativeClasses 		= true;
	public boolean importAnonymousClasses		= false;
	public String excludeClasses				= "";
	public String excludePackages				= "";
	
	public String toString() {
		String str = "";
		
		str += "Base namespace = " + baseNamespace;
		str += "\nPlatform = " + platform;
		str += "\nJava version = " + javaVersion;
		str += "\nTo import = " + toImport;
		str += "\nPackages paths = " + packagePath;
		str += "\nLibraries paths = " + libPath;
		str += "\nExclude classes = " + excludeClasses;
		str += "\nExclude packages = " + excludePackages;
		str += "\nImport all types as final = " + allTypesFinal;		
		str += "\nImport anonymous classes = " + importAnonymousClasses;
		str += "\nMap java classes to xpl native classes = " + mapToXplNativeClasses;
		str += "\nIgnore inherited interfaces = " + ignoreInheritedInterfaces;
		str += "\nIgnore generics types= " + ignoreGenerics;
		str += "\nIgnore attributes = " + ignoreAttributes;
		str += "\nIgnore enums = " + ignoreEnums;		
		return str;
	}

	public void reset() {
		baseNamespace				= "default";
		globalsNamespace 			= "";
		constantsNamespace 			= "";
		platform 					= "";
		allTypesFinal				= false;	
		
		javaVersion 				= "1.4";	
		toImport 					= "";	
		extraPath 					= "";
		packagePath					= "";
		libPath						= "";
		includeBaseNamespace 		= true; // ?
		ignoreEnums 				= true;
		ignoreAttributes 			= true;
		ignoreGenerics 				= true;
		ignoreInheritedInterfaces	= true;
		mapToXplNativeClasses 		= true;
		importAnonymousClasses		= false;
		excludeClasses				= "";
		excludePackages				= "";		
	}
}
