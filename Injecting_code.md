There are two ways of injecting code at compile time:
  * Returning expressions and types from a member function of a compile time class.
  * Using special objects of Zoe Compiler to access to the source code of the client which calls the compile time class.

## Returning expressions and types from a member function of a compile time class ##
To return expressions from a member of a compile time class is possible to use the ordinary instruction "return" as in any other function.

Examples:

```
factory class Example{ 
  public: 
    static exp string^ Add(exp int arg1, exp int arg2){ 
      return writecode( "Result: " + ($arg1 + $arg2).ToString() ); 
    } 
}
```

To use the previous function in a client program we do as if it were any other function:

```
Console::WriteLine( Example::Add(5, 1024) );
```

It is also possible to return expressions using variables of type `XplExpression^`. For example:

```
factory class Example{ 
  public: 
    exp string^ Add(exp int arg1, exp int arg2){
      XplExpression^ resExp = null; 
      resExp = writecode( "Result: " + ($arg1 + $arg2).ToString() ); 
      return resExp; 
    } 
}
```

The example above shows how the types declared with the "exp" are equivalent to a reference to the type `XplExpression`.
For returning to the client-code `types`, `types constructors` must be used. The type constructors are written as ordinary constructors but it must be specify that the return is a `type`, as follows:

```
factory class MyString{ 
  public: 
    type MyString(){ 
      return gettype(string^) 
    } 
}
```

By using the MyString type in a client program the result is that every occurrence of a statement such as `MyString` is replaced with the type `string^`, eg:

```
MyString myVar = "Hola Mundo"; 
MyString[] myArray = new MyString[] = { "Zoe", "Meta D++" };
```

The above example is equivalent to write the following lines:

```
string^ myVar = "Hola Mundo"; 
string^[] myArray = new string^[] = { "Zoe", "Meta D++" };
```

The type constructors are used to develop compile time classes that encapsulate the difference between different platforms and execution environments. There is also a variant that allows type constructors take arguments, for more information please refer to Meta D ++ and Zoe manuals.
The type "type" is equivalent to type "XpType^", as shown below:

```
factory class MyType{ 
  
  static XplType^ refType; 
  
  public: 
    static exp void SetType(type argType){
      refType = argType; return null; 
    } 
    type MyType(){ 
      if(refType==null) 
        return gettype(int); 
      else 
        return refType; 
    } 
}
```
The above example returns integer if a type called SetType  is not set, otherwise returns the type specified in SetType.

## Using special objects of Zoe Compiler ##
To access to the source code of the client, which calls the compile-time class, for modifying, is possible to use special Zoe compiler objects.
Let's see each one.

### The context object ###
The context object represents the context of the actual call in a member of a compile time class. The context object is of XplNode type, for that reason is possible to access to all the members of that class.

Example:

Compile Time Class:
```
namespace Zoe::Examples{ 
  factory class ContextSensitive{ 
    public: 
      exp void WhereAmI(){
        if(context.CurrentNamespace != null && context.CurrentClass == null) 
          Console::WriteLine( “You are on a namespace body.” ); 
        if(context.CurrentClass != null && context.CurrentFunction == null && context.CurrentProperty == null) 
          Console::WriteLine( “You are on a class body.” ); 
        if(context.CurrentBlock != null) 
          Console::WriteLine( “You are on a block.” ); 
        return null; 
      } 
  } 
}
```

The client:

```
using Zoe::Examples; 

namespace N{ 
  ContextSensitive::WhereAmI(); 
  class A{ 
    ContextSensitive::WhereAmI(); 
    void Func(){ 
      ContextSensitive::WhereAmI(); 
    } 
  } 
}
```

### The currentDTE object ###
The currentDTE object represents the actual source and references to the "Execution-Time document" of the current compile-time. The content of the currentDTE object is the conjuction of all the source files that compones the program being compiled, for that reason, when performing analysis o searches on that object you are in fact performing actions in the whole program code, nevertheless this doesn't include the imported documents by the Zoe code generators (such as the types imported with the "import" directive)

### The compiler object ###
The compiler object represents the current instance of Zoe compiler. With the compiler object is possible to consult errors and warnings of the current compilation process. It's possible to add new error and warnings and consult the information of types taken during the semantic analysis.
Example:

```
// add persistent compilation error 
Error^ newError = new Error("Error processing xml file. " + error.Message,context); 
newError.set_PersistentError(true); 
compiler.Errors.AddError(newError);
```