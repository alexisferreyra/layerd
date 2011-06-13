package LayerD.OutputModules.Importers;

import java.lang.reflect.Constructor;
import java.lang.reflect.Field;
import java.lang.reflect.Member;
import java.lang.reflect.Method;
import java.lang.reflect.Modifier;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Enumeration;
import java.util.Hashtable;
import java.util.Iterator;

import LayerD.CodeDOM.*;

/**
 *
 * @author Demián
 *
 */
public class JavaImporter implements IXPLImportsDirectiveProcessor {
    private Hashtable xplNamespaces;
    private Hashtable importedClasses;
    private Hashtable classesToImport;
    private Hashtable excludeClasses;
    private Hashtable excludePackages;
    private Hashtable packagesPaths;
    private ArrayList errors;
    private ArrayList warnings;
    private ImportParams importParams;
    private int typesCount;
    private boolean recursiveImportOn;
    private long totalTime;
    
    /**
     * Cosntructor por defecto con recursive import en false.
     */
    public JavaImporter() {
        System.setProperty("true", "true");
        
        xplNamespaces = new Hashtable();
        importedClasses = new Hashtable();
        classesToImport = new Hashtable();
        excludeClasses = new Hashtable();
        excludePackages = new Hashtable();
        packagesPaths = new Hashtable();
        importParams = new ImportParams();
        errors = new ArrayList();
        warnings = new ArrayList();
        recursiveImportOn = true;
    }
    
    /**
     * @param argAll: {"java.lang.String;ns=JavaString;platform=java","espresso3d;ns=Esspreso"}
     */
    @Override
    public boolean processImport(String[] argAll, boolean genereteOutputFile) {
        boolean result = false;
        
        for(int a = 0; a < argAll.length; a++) {
            String []args = argAll[a].split(";");
            importParams.reset();
            
            for(int i = 0; i < args.length; i++) {
                int indexOfEquals = args[i].indexOf("=");
                if(indexOfEquals == -1) {
                    //El args[i] trae lo que quiero importar
                    args[i] = args[i].trim();
                    importParams.toImport = args[i];
                } else {
                    //El args[i] es un parametro de configuracion "strIzq = strDer"
                    String strIzq = args[i].substring(0, indexOfEquals).toLowerCase().trim();
                    String strDer = args[i].substring(indexOfEquals + 1).trim();
                    if(strIzq.equalsIgnoreCase("ns")) {
                        importParams.baseNamespace = strDer;
                    } else if(strIzq.equalsIgnoreCase("platform")) {
                        ///Ignoro, asumo que LayerD-XPL lo proceso correctamente
                    } else if(strIzq.equalsIgnoreCase("blockinheritance")) {
                        importParams.allTypesFinal = Boolean.getBoolean(strDer);
                    } else if(strIzq.equalsIgnoreCase("methodsclass")) {
                        importParams.globalsNamespace = strDer;
                    } else if(strIzq.equalsIgnoreCase("constantsclass")) {
                        importParams.constantsNamespace = strDer;
                    } else if(strIzq.equalsIgnoreCase("path")) {
                        importParams.extraPath = strDer;
                    } else if(strIzq.equalsIgnoreCase("omitattributes")) {
                        importParams.ignoreAttributes = Boolean.getBoolean(strDer);
                    } else if(strIzq.equalsIgnoreCase("omitenums")) {
                        importParams.ignoreEnums = Boolean.getBoolean(strDer);
                    } else if(strIzq.equalsIgnoreCase("ignoregenerics")) {
                        importParams.ignoreGenerics = Boolean.getBoolean(strDer);
                    } else if(strIzq.equalsIgnoreCase("javaversion")) {
                        importParams.javaVersion = strDer;
                    } else if(strIzq.equalsIgnoreCase("xplnativeclasses")) {
                        importParams.mapToXplNativeClasses = Boolean.getBoolean(strDer);
                    } else if(strIzq.equalsIgnoreCase("importanonymousclasses")) {
                        importParams.importAnonymousClasses = Boolean.getBoolean(strDer);
                    } else if(strIzq.equalsIgnoreCase("excludeclasses")) {
                        importParams.excludeClasses = strDer;
                    } else if(strIzq.equalsIgnoreCase("excludepackages")) {
                        importParams.excludePackages = strDer;
                    } else if(strIzq.equalsIgnoreCase("packagePath")) {
                        importParams.packagePath = strDer;
                    } else if(strIzq.equalsIgnoreCase("recursiveimport")) {
                        recursiveImportOn = Boolean.getBoolean(strDer);
                    } else if(strIzq.equalsIgnoreCase("libpath")) {
                        importParams.libPath = strDer;
                    } else if(strIzq.equalsIgnoreCase("writelog")) {
                        JILog.getInstance().enable(Boolean.getBoolean(strDer));
                    } else {
                        addError("Argumento de importación desconocido. Argumento Nº " + (i + 1) + ".", ErrorType.Arguments);
                        JILog.getInstance().writeLine("processImport: I returned false. Reason: " + (String)this.errors.get(i + 1));
                        return false;
                    }
                }
            }
            
            JILog.getInstance().writeLine("*********************************************************************");
            JILog.getInstance().writeLine(Calendar.getInstance().getTime().toString());
            JILog.getInstance().writeLine(importParams.toString());
            JILog.getInstance().writeLine("Recursive import = " + this.recursiveImportOn);
            
            result = initImport();
        }
        
        if(result == false) {
            JILog.getInstance().writeLine("processImport: I returned false. Reason: unknown. Try adding packagePath to import list for each item to import if they are not java native.");
        }
        
        JILog.getInstance().close();
        return result;
    }
    
    @Override
    public XplDocument getLastImportDocument() {
        XplDocument doc = new XplDocument();
        XplDocumentData data = new XplDocumentData(XplDocumenttype_enum.LAYERD_XPL_DOC, "1.0");
        XplDocumentBody body = new XplDocumentBody();
        doc.set_DocumentData(data);
        doc.set_DocumentBody(body);
        
        Iterator i = xplNamespaces.values().iterator();
        while(i.hasNext()) {
            XplNamespace tmp = (XplNamespace)i.next();
            body.Childs().InsertAtEnd(tmp);
        }
        
        xplNamespaces = null;
        return doc;
    }
    
    public Hashtable getXplNamespaces() {
        return xplNamespaces;
    }
    
    @Override
    public String getLastImportFileName() {
        return null;
    }
    
    @Override
    public String[] getLastImportWarnings() {
        return null;
    }
    
    @Override
    public String[] getLastImportErrors() {
        return null;
    }
    
    public int  getCountTypesImported() {
        return typesCount;
    }
    
    public int  getCountNameSpacesImported() {
        return xplNamespaces.size();
    }
    
    public int  getCountExcludedClasses() {
        return excludeClasses.size();
    }
    
    public boolean isRecursiveImportOn() {
        return recursiveImportOn;
    }
    
    public ArrayList getErrors() {
        return errors;
    }
    
    public String getErrorsAsString() {
        return errors.toString();
    }
    
    public ArrayList getWarnings() {
        return warnings;
    }
    
    public String getWarningsAsString() {
        return warnings.toString();
    }
    
    @Override
    public String toString() {
        String str = new String("recursiveImportOn = " + this.recursiveImportOn);
        str += "\nName Spaces importados = " + this.xplNamespaces.size();
        str += "\n" + xplNamespaces.keySet().toString();
        str += "\nClases importadas = " + this.typesCount;
        str += "\n" + importedClasses.toString();
        str += "\nClases excluidas = " + this.excludeClasses.size();
        str += "\n" + excludeClasses.keySet().toString();
        str += "\nErrors = " + this.errors.size();
        str += "\n" + this.errors.toString();
        str += "\nWarnings = " + this.warnings.size();
        str += "\n" + this.warnings.toString();
        
        return str;
    }

    private void AddJavaSupportMembers(XplClass xplClass) {
        // create type for class property
        XplType property_type = XplProperty.new_type();
        property_type.set_dt(new XplType());
        property_type.set_ispointer(true);
        property_type.set_pi(new XplPointerinfo(false, false, true, false));
        property_type.get_dt().set_typename(importParams.baseNamespace + ".java.lang.Class");
        // create class property
        XplProperty property = XplClass.new_Property();
        property.set_name("class");
        property.set_storage(XplVarstorage_enum.STATIC_EXTERN);
        property.set_type(property_type);
        property.set_body(XplProperty.new_body());
        XplNode getBlock = XplFunctionBody.new_Get();
        getBlock.set_lddata("%abstract%");
        property.get_body().Childs().InsertAtEnd(getBlock);
        // add class property
        xplClass.Childs().InsertAtEnd(property);
    }
    
    /**
     *
     * @param args:
     * @return true: si la importación fue un exito. false: si no se pudo importar debido a que
     * no existia la clase o el paquete.
     */
    private boolean initImport() {
        boolean result = false;
        long initTime = System.currentTimeMillis();
        
        try {
            ArrayList listClasses = new ArrayList();
            Iterator iteratorListClasses = null;
            
            if(importParams.libPath.length() > 0) {
                JIUtils.loadLibClassPath(importParams.libPath);
            }
            
            if(importParams.packagePath.length() > 0) {
                JIUtils.loadPackageClassPath(importParams.packagePath);
            }
            
            String []paramsToImport = importParams.toImport.split(";");
            String []pkgPaths = null;
            if(importParams.packagePath.length() > 0) {
                pkgPaths = importParams.packagePath.split(";");
            }
            for(int i = 0; i < paramsToImport.length; i++) {
                try {
                    Class.forName(paramsToImport[i]);
                } catch (ClassNotFoundException e1) {
                    if(pkgPaths != null) {
                        if(i < pkgPaths.length) {
                            packagesPaths.put(paramsToImport[i], pkgPaths[i]);
                        }
                    } else {
                        packagesPaths.put(paramsToImport[i], JIPackageBuilder.JAVACLASSES);
                    }
                }
            }
            
            for(int i = 0; i < paramsToImport.length; i++) {
                try {
                    Class.forName(paramsToImport[i]);
                    listClasses.add(paramsToImport[i]);
                } catch (ClassNotFoundException e1) {
                    JIPackageBuilder b = new JIPackageBuilder(paramsToImport[i], (String)packagesPaths.get(paramsToImport[i]));
                    JIPackage p = b.build();
                    listClasses.addAll(p.getClasses());
                }
            }
            
            listClasses.trimToSize();
            iteratorListClasses = listClasses.iterator();
            
            if(importParams.excludeClasses.length() > 0) {
                excludeClasses(importParams.excludeClasses);
            }
            
            if(importParams.excludePackages.length() > 0) {
                excludePackages(importParams.excludePackages);
            }
            
            while(iteratorListClasses.hasNext()) {
                String fullClassName = (String)iteratorListClasses.next();
                try {
                    this.addClassToImport(Class.forName(fullClassName));
                } 
                catch (ClassNotFoundException e) 
                {
                    addWarning("El nombre \"" + fullClassName + "\" no es un nombre de clase valido.");
                }
                catch (java.lang.Throwable error){
                    addWarning("Undefined error while loading class \"" + fullClassName + "\". Java Exception: " + error.getMessage());
                }
            }
            
            result = run();
        } catch (JIUtilsException e) {
            e.printStackTrace();
            addError(e.getMessage(), ErrorType.Arguments);
            result = false;
        } catch (JIPackageException e) {
            addError(e.getMessage());
            e.printStackTrace();
            result = false;
        }
        
        totalTime = System.currentTimeMillis() - initTime;
        JILog.getInstance().writeLine("Total time (ms): " + totalTime);
        return result;
    }
    
    private boolean run() {
        Enumeration i = classesToImport.elements();
        String fullClassName;
        boolean result = false;
        long initTime = 0;
        
        while(i.hasMoreElements()) {
            fullClassName = (String)i.nextElement();
            XplNamespace ns = getNamespaceFor(importParams.baseNamespace + "." + fullClassName);
            XplNode node = importClass(fullClassName);
            
            classesToImport.remove(fullClassName);
            i = classesToImport.elements();
            
            if(node != null) {
                ns.Childs().InsertAtEnd(node);
                xplNamespaces.put(ns.get_name(), ns);
                typesCount++;
                result = true;
            }
        }
        
        return result;
    }
    
    /**
     * Crear o recuperar una instancia de XplNamespace segun la llave
     * indicada por el parametro "str".
     *
     * @param str: llave para obtener el XplNamespace
     * @return si la llave existe se regresa el XplNamespace asociado, sino existe se crea un XplNamespace
     * asociada a la llave indicada por el parametro "str".
     */
    private XplNamespace getNamespaceFor(String str) {
        String name = JIUtils.processTypeName(str.substring(0, str.lastIndexOf(".")));
        if(!xplNamespaces.containsKey(name)) {
            XplNamespace ns = XplDocumentBody.new_Namespace();
            ns.set_name(name);
            xplNamespaces.put(name, ns);
            return ns;
        } else {
            return (XplNamespace)xplNamespaces.get(name);
        }
    }
    
    /**
     * Importa una clase con sus constructores, metodos, atributos, interfaces que implementa y
     * clases que extiende.
     * @param fullClassName: nombre completo, respetando mayusculas y minusculas de la clase a
     * importar. El nombre completo es el nombre del paquete mas la clase. Ej: java.lang.String
     * @return
     */
    private XplNode importClass(String fullClassName) {
        try {
            if(!importedClasses.containsKey(fullClassName) && !excludeClasses.containsKey(fullClassName) &&
                    !excludePackages.containsKey(JIPackage.getPackageNameFrom(fullClassName))) {
                //La clase no esta importada.
                JILog.getInstance().writeLine("Start importing class = " + fullClassName);
                
                Class c = Class.forName(fullClassName); //Es la que tira ClassNotFoundException
                importedClasses.put(fullClassName, importParams.baseNamespace); //importParams.baseNamespace tienen el name space que se esta procesando
                
                String className = fullClassName.substring(fullClassName.lastIndexOf(".") + 1);
                XplClass xplClass = XplNamespace.new_Class();
                xplClass.set_name(className);
                
                if(c.isInterface()) {
                    xplClass.set_isinterface(true);
                }
                
                if(Modifier.isPublic(c.getModifiers())) {
                    xplClass.set_access(XplAccesstype_enum.PUBLIC);
                }
                
                if(Modifier.isAbstract(c.getModifiers())) {
                    xplClass.set_abstract(true);
                } else if(Modifier.isFinal(c.getModifiers()) || importParams.allTypesFinal) {
                    xplClass.set_final(true);
                }
                
                Class superClass = c.getSuperclass();
                if(superClass != null) {
                    importSuperClass(superClass, xplClass);
                }
                
                Class []interfaces = c.getInterfaces();
                if(interfaces != null && interfaces.length > 0) {
                    importInterfaces(interfaces, xplClass, c.isInterface() ? true : false);
                }
                
                Constructor []constructors = c.getDeclaredConstructors();
                if(constructors != null && constructors.length > 0) {
                    importMethodOrConstructor(constructors, xplClass);
                }
                
                Method []methods = c.getDeclaredMethods();
                if(methods != null && methods.length > 0) {
                    importMethodOrConstructor(methods, xplClass);
                }
                
                Field []fields = c.getDeclaredFields();
                if(fields != null && fields.length > 0) {
                    importFields(fields, xplClass);
                }
                
                Class []classes = c.getDeclaredClasses();
                if(classes != null && classes.length > 0) {
                    importInternalDeclaredClasses(classes, xplClass);
                }
                // add java specific properties and methods
                AddJavaSupportMembers(xplClass);
                
                JILog.getInstance().writeLine("End importing class = " + fullClassName);
                
                return xplClass;
            } else {
                //La clase ya fue importada.
                return null;
            }
        } catch (ClassNotFoundException e) {
            addError("El nombre \"" + fullClassName + "\" no corresponde a una clase.");
            return null;
        } catch (java.lang.NoClassDefFoundError e) {
            addError("El nombre \"" + fullClassName + "\" no corresponde a una clase.");
            return null;
        }
    }
    
    private void importSuperClass(Class superClass, XplClass xplClass) {
        XplInherits inherits = XplClass.new_Inherits();
        XplInherit inherit = XplInherits.new_c();
        inherit.set_access(XplAccesstype_enum.PUBLIC);
        XplType itype = new XplType();
        inherit.set_type(itype);
        
        if(importParams.mapToXplNativeClasses && superClass.getName().equalsIgnoreCase("java.lang.String")) {
            itype.set_typename(CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.STRING]);
        } else if(importParams.mapToXplNativeClasses && superClass.getName().equalsIgnoreCase("java.util.Date")) {
            itype.set_typename(CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.DATE]);
        } else if(importParams.mapToXplNativeClasses && superClass.getName().equalsIgnoreCase("java.lang.Object")) {
            itype.set_typename(CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.OBJECT]);
        } else {
            if(importedClasses.containsKey(superClass.getName())) {
                itype.set_typename(JIUtils.processTypeName(importedClasses.get(superClass.getName()) + "." + superClass.getName()));
            } else {
                itype.set_typename(JIUtils.processTypeName(importParams.baseNamespace + "." + superClass.getName()));
            }
            
            //inherit.set_name(JIUtils.processTypeName(importParams.baseNamespace + "." + superClass.getName()));
            if(recursiveImportOn) {
                addClassToImport(superClass);
            }
        }
        
        inherits.Childs().InsertAtEnd(inherit);
        xplClass.Childs().InsertAtEnd(inherits);
    }
    
    private void importInterfaces(Class []toImport, XplClass xplClass, boolean motherIsInterface) {
        XplInherits xplImplements = XplClass.new_Implements();
        XplInherit xplImplement = null;
        XplInherits xplInherits = null;
        
        for(int i = 0; i < toImport.length; i++) {
            if(motherIsInterface) {
                //El tipo madre es una interface que extiende otras interfaces
                if(xplInherits == null){
                    xplInherits = XplClass.new_Inherits();
                    xplClass.Childs().InsertAtEnd(xplInherits);
                }
                
                XplInherit inherit = XplInherits.new_c();
                inherit.set_access(XplAccesstype_enum.PUBLIC);
                XplType itype = new XplType();
                inherit.set_type(itype);
                //inherit.set_name(JIUtils.processTypeName(toImport[i].getName()));
                
                if(importedClasses.containsKey(toImport[i].getName())) {
                    itype.set_typename(JIUtils.processTypeName(importedClasses.get(toImport[i].getName()) + "." + toImport[i].getName()));
                } else {
                    itype.set_typename(JIUtils.processTypeName(importParams.baseNamespace + "." + toImport[i].getName()));
                }
                
                xplInherits.Childs().InsertAtEnd(inherit);
            } else if(importParams.ignoreInheritedInterfaces) {
                //El tipo madre ss una clase que implementa interfaces
                xplImplement = XplInherits.new_c();
                xplImplement.set_access(XplAccesstype_enum.PUBLIC);
                XplType itype = new XplType();
                xplImplement.set_type(itype);
                //xplImplement.set_name(JIUtils.processTypeName(importParams.baseNamespace + "." + toImport[i].getName()));
                
                if(importedClasses.containsKey(toImport[i].getName())) {
                    itype.set_typename(JIUtils.processTypeName(importedClasses.get(toImport[i].getName()) + "." + toImport[i].getName()));
                } else {
                    itype.set_typename(JIUtils.processTypeName(importParams.baseNamespace + "." + toImport[i].getName()));
                }
                
                xplImplements.Childs().InsertAtEnd(xplImplement);
            }
            
            if(recursiveImportOn) {
                addClassToImport(toImport[i]);
            }
        }
        
        xplClass.Childs().InsertAtEnd(xplImplements);
        return;
    }
    
    /**
     * Imports a method or a constructor to the xplClass instance.
     * Sets the modifiers, parameters, throws, return value. If a parameter o a return value
     * is a non primitive then is added to the import list.
     */
    private void importMethodOrConstructor(Member []toImport,  XplClass xplClass) {
        for(int i = 0; i < toImport.length; i++) {
            if(Modifier.isPrivate(toImport[i].getModifiers())) {
                continue;
            } else {
                XplFunction xplFunction = XplClass.new_Function();
                
                if(toImport[i] instanceof Constructor) {
                    xplFunction.set_name(xplClass.get_name());
                    xplFunction.set_Parameters(importParameters(((Constructor)toImport[i]).getParameterTypes()));
                } else {
                    xplFunction.set_name(((Method)toImport[i]).getName());
                    xplFunction.set_Parameters(importParameters(((Method)toImport[i]).getParameterTypes()));
                    
                    if(Modifier.isAbstract(((Method)toImport[i]).getModifiers())) {
                        xplFunction.set_abstract(true);
                    }
                    
                    if(Modifier.isFinal(((Method)toImport[i]).getModifiers())) {
                        xplFunction.set_final(true);
                    }
                    
                    if(Modifier.isStrict(((Method)toImport[i]).getModifiers())) {
                        addWarning("El metodo '" + ((Method)toImport[i]).getName()+ "' de '" + xplClass.get_name() 
                                   + "' tiene el modificador 'strictfp' que no esta implementado.");
                    }
                    
                    if(Modifier.isSynchronized(((Method)toImport[i]).getModifiers())) {
                        addWarning("El metodo '" + ((Method)toImport[i]).getName() + "' de '" + xplClass.get_name() 
                                   + "' tiene el modificador 'synchornized' que no esta implementado.");
                    }
                    
                    if(Modifier.isStatic(((Method)toImport[i]).getModifiers())) {
                        xplFunction.set_storage(XplVarstorage_enum.STATIC_EXTERN);
                    } else {
                        xplFunction.set_storage(XplVarstorage_enum.EXTERN);
                    }
                    
                    xplFunction.set_ReturnType(getXplType(((Method)toImport[i]).getReturnType(), true));
                    
                    if(recursiveImportOn) {
                        addClassToImport(((Method)toImport[i]).getReturnType());
                    }                                                   
                }
                
                //Modificadores de visibilidad
                if(Modifier.isPrivate(toImport[i].getModifiers())) {
                    xplFunction.set_access(XplAccesstype_enum.PRIVATE);
                } else if(Modifier.isPublic(toImport[i].getModifiers())) {
                    xplFunction.set_access(XplAccesstype_enum.PUBLIC);
                    //addMember(xplClass, xplFunction, XplAccesstype_enum.PUBLIC);
                } else {
                    xplFunction.set_access(XplAccesstype_enum.PROTECTED);
                    //addMember(xplClass, xplFunction, XplAccesstype_enum.PROTECTED);
                }
                addMember(xplClass, xplFunction, 0);
                
                importExceptions(toImport[i], null);                 
            }
        }
        
        return;
    }
    
    private void importFields(Field []toImport, XplClass xplClass) {
        for(int i = 0; i < toImport.length; i++) {
            if(Modifier.isPrivate(toImport[i].getModifiers())) {
                continue;
            } else {
                XplField xplField = XplClass.new_Field();
                xplField.set_name(toImport[i].getName());
                
                if(Modifier.isStatic(toImport[i].getModifiers())) {
                    xplField.set_storage(XplVarstorage_enum.STATIC_EXTERN);
                } else {
                    xplField.set_storage(XplVarstorage_enum.EXTERN);
                }
                
                if(Modifier.isVolatile(toImport[i].getModifiers())) {
                }
                
                if(Modifier.isFinal(toImport[i].getModifiers())) {
                }
                
                xplField.set_type(getXplType(toImport[i].getType(), false));
                
                if(Modifier.isPrivate(toImport[i].getModifiers())) {
                    xplField.set_access(XplAccesstype_enum.PROTECTED);
                    //addMember(xplClass,xplField,XplAccesstype_enum.PRIVATE);
                } else if(Modifier.isPublic(toImport[i].getModifiers())) {
                    xplField.set_access(XplAccesstype_enum.PUBLIC);
                    //addMember(xplClass,xplField,XplAccesstype_enum.PUBLIC);
                } else {
                    xplField.set_access(XplAccesstype_enum.PROTECTED);
                }
                addMember(xplClass,xplField,0);
                
                if(recursiveImportOn) {
                    addClassToImport(toImport[i].getType());
                }
            }
        }
    }
    
    /**
     * Importa una clase de java que esta definida dentro de otra clase de java. En
     * Xpl la importa dentro de la clase Xpl que corresponde a la clase que define
     * la clase interna a importar.
     *
     * @param toImport: clase interna a importar.
     * @param xplClass: clase que defina a la calse interna a importar.
     */
    private void importInternalDeclaredClasses(Class []toImport, XplClass xplClass) {
        for(int i = 0; i < toImport.length; i++) {
            if(Modifier.isPrivate(toImport[i].getModifiers())) {
                continue;
            } else {
                String str = toImport[i].getName();
                String internalClassName = str.substring(str.lastIndexOf("$") + 1, str.length());
                
                XplClass internal = xplClass.new_Class();
                internal.set_name(internalClassName);
                
                if(toImport[i].isInterface()) {
                    internal.set_isinterface(true);
                }
                
                if(Modifier.isPublic(toImport[i].getModifiers())) {
                    internal.set_access(XplAccesstype_enum.PUBLIC);
                }
                
                if(Modifier.isAbstract(toImport[i].getModifiers())) {
                    internal.set_abstract(true);
                } else if(Modifier.isFinal(toImport[i].getModifiers()) || importParams.allTypesFinal) {
                    internal.set_final(true);
                }
                
                Class superClass = toImport[i].getSuperclass();
                if(superClass != null) {
                    importSuperClass(superClass, internal);
                }
                
                Class []interfaces = toImport[i].getInterfaces();
                if(interfaces != null && interfaces.length > 0) {
                    importInterfaces(interfaces, internal, toImport[i].isInterface() ? true : false);
                }
                
                Constructor []constructors = toImport[i].getDeclaredConstructors();
                if(constructors != null && constructors.length > 0) {
                    importMethodOrConstructor(constructors, internal);
                }
                
                Method []methods = toImport[i].getDeclaredMethods();
                if(methods != null && methods.length > 0) {
                    importMethodOrConstructor(methods, internal);
                }
                
                Field []fields = toImport[i].getDeclaredFields();
                if(fields != null && fields.length > 0) {
                    importFields(fields, internal);
                }
                
                Class []classes = toImport[i].getDeclaredClasses();
                if(classes != null && classes.length > 0) {
                    importInternalDeclaredClasses(classes, internal);
                }
                
                xplClass.Childs().InsertAtEnd(internal);
            }
        }
    }
    
    /**
     * Importa los parametros de un metodo o constructor. Si el parametro
     * es un tipo no primitivo lo agrega a la lista de clases a importar.
     *
     * @param parameters: lista de parametros a importar.
     * @return una instancia de parametros XPL.
     */
    private XplParameters importParameters(Class []parameters) {
        XplParameters xplParams = XplFunction.new_Parameters();
        
        for(int i = 0, iParam = 1; i < parameters.length; i++, iParam++) {
            XplParameter xplParam = XplParameters.new_P();
            xplParam.set_name(parameters[i].getName().replace('.', '_'));
            xplParam.set_type(getXplType(parameters[i], true));
            xplParam.set_number(xplParams.Childs().getLenght() + 1);
            xplParams.Childs().InsertAtEnd(xplParam);
            
            if(recursiveImportOn) {
                addClassToImport(parameters[i]);
            }
        }
        
        return xplParams;
    }
    
    /**
     * Arma un XplType a partir de una clase, arreglo (de clases, interfaces o primitivos),
     * interface y si la flag de importParams.mapToXplNativeClasses es true importa
     * las clases de java java.lang.String como string, java.lang.Object como object y
     * java.util.Date como date.
     *
     * @param type
     * @param isParameter
     * @return
     */
    private XplType getXplType(Class type, boolean isParameter) {
        if(type.isPrimitive()) {
            return getXplTypeFromJavaPrimitive(type);
        }
        
        XplType rootType = new XplType();
        if(type.isArray()){
            //pointer info del array
            int arrayDim = JIUtils.getDimFromArray(type);
            
            XplType sonType = null, fatherType = rootType;
            for(int i = 0; i < arrayDim; i++) {
                sonType = new XplType();
                
                fatherType.set_ispointer(true);
                fatherType.set_pi(XplType.new_pi());
                fatherType.get_pi().set_ref(true);
                
                sonType.set_isarray(true);
                fatherType.set_dt(sonType);
                fatherType = sonType;
            }
            
            XplType dataType = getXplType(JIUtils.getClassFromArray(type), false);
            sonType.set_dt(dataType);
        } else {
            //No es primitivo, ni Array. Es Clase o Interfaz
            XplType classType = new XplType();
            
            if (importParams.mapToXplNativeClasses && type.getName().equalsIgnoreCase("java.lang.String")) {
                classType.set_typename("$"+CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.STRING].toUpperCase()+"$");
            } else if (importParams.mapToXplNativeClasses && type.getName().equalsIgnoreCase("java.util.Date")) {
                classType.set_typename("$"+CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.DATE].toUpperCase()+"$");
            } else if (importParams.mapToXplNativeClasses && type.getName().equalsIgnoreCase("java.lang.Object")) {
                classType.set_typename("$"+CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.OBJECT].toUpperCase()+"$");
            } else {
                if(importedClasses.containsKey(type.getName())) {
                    classType.set_typename(JIUtils.processTypeName(importedClasses.get(type.getName()) + "." + type.getName()));
                } else {
                    classType.set_typename(JIUtils.processTypeName(importParams.baseNamespace + "." + type.getName()));
                }
            }
            
            rootType.set_ispointer(true);
            rootType.set_pi(XplType.new_pi());
            rootType.get_pi().set_ref(true);
            rootType.set_dt(classType);
        }
        
        return rootType;
    }
    
    /**
     * Mapea los tipos primitivos de java a los tipos primitivos de XPl.
     *
     * @param type: tipo de java primitivo a mapear con tipo XPL.
     * @return un objeto XplType especificando que tipo primitivo es. Los tipos primitivos validos
     * son: boolean, byte, char, int, long, short, double y float. Si el parametro "type" no cae dentro
     * de esa categoria por defecto se setea al objeto XplType a integer y se añade un error
     * en la lista de errores.
     */
    private XplType getXplTypeFromJavaPrimitive(Class type) {
        
        XplType xplType = new XplType();
        
        if(type.getName().equalsIgnoreCase("boolean")) {
            xplType.set_typename("$"+CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.BOOLEAN].toUpperCase()+"$");
        } else if(type.getName().equalsIgnoreCase("byte")) {
            xplType.set_typename("$"+CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.BYTE].toUpperCase()+"$");
        } else if(type.getName().equalsIgnoreCase("char")) {
            xplType.set_typename("$"+CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.CHAR].toUpperCase()+"$");
        } else if(type.getName().equalsIgnoreCase("int")) {
            xplType.set_typename("$"+CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.INTEGER].toUpperCase()+"$");
        } else if(type.getName().equalsIgnoreCase("long")) {
            xplType.set_typename("$"+CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.LONG].toUpperCase()+"$");
        } else if(type.getName().equalsIgnoreCase("short")) {
            xplType.set_typename("$"+CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.SHORT].toUpperCase()+"$");
        } else if(type.getName().equalsIgnoreCase("float")) {
            xplType.set_typename("$"+CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.FLOAT].toUpperCase()+"$");
        } else if(type.getName().equalsIgnoreCase("double")) {
            xplType.set_typename("$"+CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.DOUBLE].toUpperCase()+"$");
        } else if(type.getName().equalsIgnoreCase("void")) {
            xplType.set_typename("$"+CodeDOM_STV.XPLTYPENAME_ENUM[XplTypename_enum.VOID].toUpperCase()+"$");
        } else {
            xplType.set_typename("$"+CodeDOM_STV.XPLLITERALTYPE_ENUM[XplTypename_enum.INTEGER].toUpperCase()+"$");
            addError("El tipo basico '" + type.getName() + "' no pudo ser procesado.", ErrorType.Unsupported);
        }
        
        return xplType;
    }
    
    /**
     * Importa a la instancia "xplClass" las exceptiones que tira el metodo o contructor.
     */
    private void importExceptions(Member miembro, XplClass xplClass) {
        Class []exceptions;
        exceptions = (miembro instanceof Method) ? ((Method)miembro).getExceptionTypes() : 
                                                   ((Constructor)miembro).getExceptionTypes();
              
        for(int i = 0; i < exceptions.length; i++) {
            JILog.getInstance().writeLine(miembro.getClass().getName() + " lanza excepcion: " + exceptions[i].getName());                        
        }        
    }
    
    /**
     * Agrega una clase o interfaz a la lista de importacion. Si el parametro "c"
     * fuese un tipo primitivo no lo agrera o si c es una clase anonima y la flag
     * importAnonymousClasses esta en false;
     *
     * @param c: clase a agregar.
     */
    private void addClassToImport(Class c) {
        if(!Modifier.isPrivate(c.getModifiers()) && !c.isPrimitive()) {
            if(c.isArray()) {
                Class tmp = JIUtils.getClassFromArray(c);

                if(!tmp.isPrimitive() && !JIUtils.isInternalClass(tmp)) {
                    if(JIUtils.isAnonymousClass(tmp)) {
                        if(importParams.importAnonymousClasses) {
                            classesToImport.put(tmp.getName(), tmp.getName());
                        }
                    } else {
                        classesToImport.put(tmp.getName(), tmp.getName());
                    }
                }
            } else {
                if(!JIUtils.isInternalClass(c)) {
                    if(JIUtils.isAnonymousClass(c)) {
                        if(importParams.importAnonymousClasses) {
                            classesToImport.put(c.getName(), c.getName());
                        }
                    } else {
                        classesToImport.put(c.getName(), c.getName());
                    }
                }
            }
        }
    }
    
    /**
     *
     * @param strDer
     */
    private void excludeClasses(String strDer) {
        String []classes = strDer.split(";");
        for(int i = 0; i < classes.length; i++) {
            classes[i] = classes[i].trim();
            if(!classes[i].equalsIgnoreCase("")) {
                try {
                    Class c = Class.forName(classes[i]);
                    excludeClasses.put(c.getName(), c.getName());
                } catch (ClassNotFoundException e) {
                    addWarning("Clase '" + classes[i] + "' en la lista de exclusion no es un nombre de clase valida.");
                }
            }
        }  
    }
    
    /**
     *
     * @param strDer
     */
    private void excludePackages(String strDer) {
        String []pkgs = strDer.split(";");
        for(int i = 0; i < pkgs.length; i++) {
            pkgs[i] = pkgs[i].trim();
            if(!pkgs[i].equalsIgnoreCase("")) {
                excludePackages.put(pkgs[i], pkgs[i]);
                //AddWarning("El paquete '" + pkgs[i] + "' en la lista de exclusion no es un nombre de paquete valido.");
            }
        }
    }
    
    /**
     * Agrega a la lista de hijos de "xplClass" a "member" indicando
     * su tipo de acceso.
     *
     * @param xplClass: a donde agregar como hijo a "member"
     * @param member: miembro a agregar como hio en "xplClass"
     * @param accessType: tipo de acceso de "member" enumerados
     * en la clase XplAccesstype_enum.
     */
    private void addMember(XplClass xplClass, XplNode member, int accessType) {
        xplClass.Childs().InsertAtEnd(member);
    }
    
    private void addError(String str) {
        this.errors.add(str);
        JILog.getInstance().writeLine("<Error " + this.errors.size() + "> " + str);
    }
    
    private void addError(String str, int tipo) {
        this.errors.add(str + " Tipo: " + tipo);
        JILog.getInstance().writeLine("<Error " + this.errors.size() + "> " + str + " Tipo: " + tipo);
    }
    
    private void addWarning(String str) {
        this.warnings.add(str);
        JILog.getInstance().writeLine("<Warning " + this.warnings.size() + "> " + str);
    }
}
