The interactive compilation let you access to the current Meta D++ program source code for analyzing or modifying it. The result of a interactive compilation is that the original source code is being modified.

The known as `interactive` classfactorys are executed when we compile a client program in `interactive mode`, the `interactive` compilation mode for a LayerD program works as follows:

  * The Zoe compiler compiles the program normally and runs at compile time all calls to interactive classfactorys.

  * To the result of the first compilation time it transforms it to the LayerD source code of high-level overwriting the original source code.

The utility and application of interactive classfactorys is varied. It allows to program very complex programs behaviour that are normally found in IDEs such as refactoring, code analysis, use of code snippets, examples, wizards, visual designers, etc.

An interactive classFactory is practically identical to an ordinary classFactory, simply it must be changed in the declaration the modifier `factory` by `interactive`, for example:

```
using Zoe;
using DotNET::LayerD::ZoeCompiler;
using DotNET::LayerD::CodeDOM;
namespace Test{
  public interactive class HelloWorld{
    public:
      static exp string^ SayHello(){
        return writecode("Hello World");
      }
  }
}
```

Later, the extension is compiled as any other classfactory, such instance:

```
c:\layerd\bin>metadppc.exe TestTemplates.dpp
c:\layerd\bin>zoec.exe TestTemplates.zoe –ae
```

In the client programs it is used identically to a ordinary classfactory:
```
import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
using DotNET::System;
namespace Test 
{
  public class App{
    public:
      static void Main(string^[] args){
        Console::WriteLine( HelloWorld::SayHello() );
      }
    }
}
```

Then we just have to run the Zoe compiler in "interactive mode" - using the "-i" option - to compile the client program:

```
c:\layerd\bin>metadppc.exe Test.dpp
c:\layerd\bin>zoec.exe Test.zoe –i
```

As a result of the execution of the interactive classFactory our client program will be modified as follows:

```
import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
using DotNET::System;
namespace Test {
  public class App{
    public:
      static void Main(string^[] args){
        Console::WriteLine( "Hello World" );
      }
    }
}
```

As a reminder it is important to understand that it is not a good programming practice abusing the use of interactive classfactorys for injecting code that later we'll modify by hand, precisely the role of the classfactories (ordinary, not interactive) is to encapsulate code and allow to the high-level programmer abstract from the complexities of implementation. Therefore, it is recommended to use interactive classfactories only for developing useful RAD components, such as: examples of the use of libraries, classes assistants, code refactoring, visual designers and similar tools that normally would be linked and dependent on a particular IDE.