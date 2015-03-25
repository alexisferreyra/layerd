# Create your own semantic structures with LayerD #
This page show how to use compile time infrastructure and source code introspection to implement custom semantic structures for high level LayerD languages.

**Why create your own semantic structures?**

By taking advantage of Meta D++ syntax that allows to take blocks and expressions as arguments of compile time functions, plus Zoe infrastructure for introspection and program structure modification at compile time. It´s possible to add new constructs to high level LayerD languages like Meta D++ by writing compile time classes that encapsulate high level abstractions.

For example, suppose that we wan´t a new kind of statement not natively available in Meta D++ like this one:

```

ExecuteParallel{
  RunTask1();
  RunTask2();
  RunTask3();
}

```

This new statement takes a sequence of statements and execute each statement in the block in a separate thread.

To implement this kind of constructs we can abstract their behavior in a compile time class by providing the required transformation from the high level abstraction into the required low level code, just as a compiler do for common abstractions like `foreach` blocks for example.

So, the tasks needed to implement a new semantic structure are the following:

  1. Design semantic structure syntax by using as basic construction blocks expressions and blocks
  1. Design semantic structure static and runtime semantic
  1. Implement the compile time class that transform from our previously designed syntax structure into required low level constructs in order to implement desired semantic.

Let´s implement our sample structure.

## Execute Parallel Sample ##

### Design ###

**1. Syntax design**

Our semantic structure will have a very simple syntactic design. It´s going to be composed of a kind of "keyword" and will take a block of statements as argument (compound statement):

```

Concurrent::ExecuteParallel{
  // sequence of statements to execute in parallel
};

```

To process that kind of syntax structure we are going to need the following compile time function:

```
// a compile time function that returns an expression, and takes a block as argument
exp void ExecuteParallel(block arguments){
 // implementation
}
```

**2. Semantic design**

We wan´t the following behavior for our `ExecuteParallel` construct:

  * each executable statement in the block of statements will run in their own thread
  * all thread will run automatically in the sequence that were declared
  * we are not going to wait for threads to stop

In the sample, we are going to support only .NET platform. But in the real world you can provide implementations for more than one runtime. That is completely transparent to high level programmer because he is using our high level abstraction.

### Implementation of Execute Parallel extension ###

**3. Implement compile time class**

Here we show the code that implements our `ExecuteParallel` construct to run a statements in parallel (for .NET):

```
import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
using DotNET::System;
using DotNET::System::IO;
using DotNET::System::Collections;
using DotNET::LayerD::CodeDOM;
using DotNET::LayerD::ZOECompiler;

namespace Zoe::DotNET::Utils{
  // Classfactory to execute concurrent statements on .NET using simple threads
  public factory class Concurrent{
  public:
    // Simple function to execute concurrent statements on .NET
    static exp void ExecuteParallel(block parallelStatements){
      // For each instruction on the argument block (that´s not a comment)
      for(XplNode^ sta in parallelStatements.Children()){
        if(sta.get_TypeName() != CodeDOMTypes::XplDocumentation){

          // create a random function name
          XplIName^ funcName = new XplIName();
          
          // create an empty function
          XplFunction^ func = (XplFunction^)writecode{%
          private:
            static void $funcName(){
            }
          %}.Children().FirstNode();
          
          // insert the statement into the new function
          func.get_FunctionBody().Children().InsertAtEnd(sta);

          // insert the function into current class
          context.CurrentClass.Children().InsertAtEnd(func);

          // create the initialization expression for the thread
          XplExpression^ startExp = null;
          startExp = writecode( new DotNET::System::Threading::Thread(
                                      new DotNET::System::Threading::ThreadStart( & $funcName ) ).Start() );

          // inject the initialization expression into the current context
          context.CurrentBlock.Children().InsertBefore(startExp, context.CurrentExpression);

        }
      }
      
      // return null to remove ExecuteParallel call from client code
      return null;
    }
  }
}
```

To compile this file and to add it to the compiler as an extension:

```
c:\layerd\bin>metadppc.exe ExecuteParallel.dpp
c:\layerd\bin>zoec.exe ExecuteParallel.zoe –ae
Extension Added: ExecuteParallel
```

### Client program for Execute Parallel statement ###

Now to use this new classfactory from a client program, simply write the client program and compile it.
The client program:

```
import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
using DotNET::System;
// using for new classfactory
using Zoe::DotNET::Utils;

namespace Test{
  public class App{
  public:
    static void Main(string^[] args){
      // Say hello!!
      Console::WriteLine("Welcome to new semantic structures with LayerD !!");

      // Run instruction on separated threads
      Concurrent::ExecuteParallel{
        // Count things on one thread
        for(int n=0;n<40000001;n++) if(n%20000000==0)Console::WriteLine("I am on "+n+".");
        // Count other thing on other thread
        for(int n=0;n<40000001;n++) if(n%2000000==0)Console::WriteLine("You are on "+n+".");
      };

      Console::Read();
    }
  }
}
```

How to compile the client program:
```
c:\layerd\bin>metadppc.exe MyClassfactoryClient.dpp
c:\layerd\bin>zoec.exe MyClassfactoryClient.zoe
```

So you don't have to do anything special in order to compile and use compile time extensions (or compile time classes).

Programmers in any high level LayerD language can use our new created semantic structure like any other native construct.