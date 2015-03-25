In this section we're going to explain some platform-specific concepts for .NET

## The import directive for .NET ##
To indicate that you want to use .NET platform, you must include the following "import" directive in one of the source files with which you proposes to work:

```
import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib"; 
import "System", "platform=DotNET", "ns=DotNET", "assembly=System";
```

LayerD works for all .NET versions known but it doesn't imports generic types.

Regarding the used parameters:

`import "StringValue"` = the string value following the import directive indicates that everything that's inside "System" will be imported.

`"platform=DotNET"` -> indicates to Zoe compiler that you want to work with .NET platform

`"ns=DotNET"` -> name of the namespace where the importation will be done.

`"assembly=System"` -> indicates the assembly which contains the classes that you need to import. Zoe Compiler uses the GAC friendly-name for locating the "assembly". Other alternative is to use:

`"assemblyfilename=C:\\MIPATH\\system"` which indicates the full path to the required assembly.

## Compiling to .NET platform ##
By default Zoe compiler compiles for .NET platform, so the "p-parameter" is not needed. Nevertheless, it is possible to use it indicating "-p:DotNET"