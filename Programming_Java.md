In this section we're going to explain some platform-specific concepts for Java

## The import directive for Java ##
To indicate that you want to use Java platform, you must include the following `import` directive in one of the source files with which you proposes to work:

```
import "java.lang.*", "platform=Java", "ns=Java";
```

LayerD needs the Java SDK installed in your PC to work properly with Java platform. It must be registered in your SO path.

Another parameter in the import directive:

`"packagePath=C:\\MiPath\\here"` for indicating the location of a specific jar file which contains classes that want to be imported.

In Java ME platform some JAR files doesn't work properly yet.

## Compiling to Java platform ##
By default, Zoe compiler compiles to .NET platform. If your target platform is Java you need to indicate to Zoe compiler using the "-p:Java" option. Example:

```
c:\layerd\bin>zoec.exe SampleJava.zoe –p:java
```

## Inheritance ##
All inherited methods are, by default, non-virtual in LayerD unless you define it as "virtual" (with "virtual" modifier). Nevertheless, for platforms like Java where methods are by default virtual, a warning will be shown for point out that the method is going to be "virtual" anyway. In this case if what you want is a non-virtual method, you should use non-virtual modifier so that the method won't be virtual.