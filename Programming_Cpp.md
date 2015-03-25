# C++ code generator specific information #

# Import statement #

```
import "QString", "platform=C++", "ns=Cpp", "header=<QString>";
```

Import arguments:
  * The first argument is basically ignored in current implementation, but it is better to provide a descriptive information
  * "platform" argument must be set to "C++" in order to be processed by C++ code generator
  * "ns" argument is recommended to be set to "Cpp" and use that namespace for all C++ specific type information provided by using externs definitions
  * "header" argument allows the setup of "#include" directives in the generated .cpp files. If you include the signs "<>" that will be used in the generation of #include directives, otherwise double quotes will be used.

Import module is not implemented for C++ code generator. So, you will need to provide information about external types by using extern classes like:

```
namespace Cpp
{

public extern class QObject
{
   // interface definition here
}

}
```