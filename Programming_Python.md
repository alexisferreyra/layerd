# Python code generator #

Sample import directive for Python code generator:

```
import "os", "platform=python", "extern=python.os.externs.zoe";
```

Parameters:
  * The first parameter is the package to be imported. The name used in the first parameter will be pasted in the import directive like `import os`
  * **"platform"** must be set to "python"
  * **"extern"** is an optional parameter. When used, the code generator will load the .zoe file an will be used for extern type definitions. You can provide more than one extern in the same import by using multiple "extern" items.

# Type information using externs #

Python code generator does not include an automatic type importer. You will need to provide external type information by using externs (for using Python libraries).

Rules to be used when writing extern type information:
  * Use the namespace **py** for all extern types
  * Use the class **py::global** to define all global objects

The following is a sample of an externs definition:

```
namespace py
{
  extern public class global
  {
  public:
    static void print(object*ref arg1);
    static py::os::File*ref open(string*ref file, string*ref mode);
    static int len(object*ref arg1);
    static string*ref str(object*ref arg1);
  }
  extern public class os
  {
  public:
    static string*ref getcwd();
        
    public class File
    {
    public:
      bool next();
      char[] read(long bytes);
      void write(string*ref str);
      void close();
    }
  }
  
  extern public class Exception
  {
  public:
    string*ref value;
  }
}
```