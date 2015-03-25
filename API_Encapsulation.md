## Compile Time API Encapsulation ##

LayerD provides the required infrastructure to encapsulate libraries and frameworks (APIs). In particular, Zoe language natively support these important features:

  * Automatic pattern matching for API usages
  * Required infrastructure for substitution and refactoring of client source code at compile time

## Why is compile type API encapsulation useful? ##
When we want to develop multi-platform software we can follow a couple of paths:
  * Use a languages that runs over a standard runtime and that use standard libraries that are available on more than one platform. This is the case of Java language and platform and .NET for a more restricted set of APIs.
  * Use a language that can be compiled for multiple platforms and can be linked with multiple libraries and make wrappers for our "common API" around "native API". This approach is followed by multiple "multi-platform libraries" like Qt, GTK, Boost, etc.

The problem with these approach is that they don't really solve the problem of compiling one program for multiple platforms, libraries and runtimes. If we want to have one main source code base for our software and be able to compile this source for multiple runtimes and libraries like, say for example, if we want to run our software on Java, .NET, native code linked with GTK, native code linked with Qt, native code linked against native Windows API, etc. We are going to easily found that it's not possible using any mainstream programming language.

That is because every major programming language was designed with a specific runtime and/or library in mind. That is not necessarily bad, but it implies a major limitation on the portability and long term value of our source code. It's common to take for granted that it's not possible to have one base of source code for two or more diverse runtimes/framework like say Java, .NET, and native code for multiple OSs.

LayerD and more specifically Zoe language provides the required infrastructure to do exactly that:
  * Write most of your source code one time and run it on diverse runtimes/frameworks. And by "diverse" we mean considerably different runtimes like Java SE and native code + Qt or something else.

## API encapsulation example for basic IO ##
Now, we are going to show a simple example that shows how to encapsulate basic IO operations using compile time classes. For the example we are going to write one client source code that is able to compile to .NET and Java without changes.
Or client code looks like this:

```
 import "Microsoft", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
 import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
 import "java.lang.*", "platform=Java", "ns=Java";
 import "java.io.*", "platform=Java", "ns=Java";
 using LayerD::IO;
 
 namespace FileIOTest{
  public class TestIO{
  public:
    static void Main(string^[] args){
      Console::WriteLine("Multiplatform sample for IO to text files.");
      char[] buffer = new char[1024];
      try{
        // write somethings to a file
        FileWriter^ wvar = new FileWriter("test.txt");
        wvar.Write("Uno\n");
        wvar.Write("Dos\n");
        wvar.Write("Tres\n");
        wvar.Write("Cuatro\n");
        wvar.Write("Cinco\n");
        wvar.Close();
        // read the file that was recently written
        FileReader^ var = new FileReader("test.txt");
        while(!var.Eof()){
          var.Read( buffer );
          Console::Write( buffer );
        }
        var.Close();
      }
      catch(UniversalException^ error){
        Console::WriteLine("Error: " + error.GetMessage());
      }
      Console::WriteLine();
      Console::WriteLine("End multiplatform IO sample.");
    }
  }
 }
```

If you look at our sample client we use the following classes (from the point of view of a library): `Console`, `FileWriter`, `FileReader` and `UniversalException`.
So, we are going to need "something" to encapsulate that **Abstract Interface** against the diverse possible implementations - .NET and Java in this sample.

By using a compile time class we can encapsulate `Console` writing the following code:

```
  public factory class Console {
    Console(){
      // You can't create instances
    }
  public:
    static exp void WriteLine(exp void toWrite){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(DotNET::System::Console::WriteLine($toWrite));
      }
      else{
        return writecode(Java::java::lang::System::@out.println($toWrite));
      }
    }
    static exp void WriteLine(){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(DotNET::System::Console::WriteLine());
      }
      else{
        return writecode(Java::java::lang::System::@out.println());
      }
    }
  }
```

Let's explain the implementation of `WriteLine`:

```
  //#1: take expressions as parameters instead of values
  //#2: return expressions instead of values
  static exp void WriteLine(exp void toWrite){
      //#3: use the compiler object to know for which platform we are compiling
      //#4: return a different expression for each supported platform
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(DotNET::System::Console::WriteLine($toWrite));
      }
      else{
        return writecode(Java::java::lang::System::@out.println($toWrite));
      }
  }
```

As you can see, if you need to encapsulate a static function, required steps are very easy:
  1. In your "abstract interface" take expressions instead of values as parameters, and return expressions instead of values
  1. Use the compiler object to know for which platform we are compiling and return a new expression according to the platform
For example, if when the user of this compile time function calls it using:

```
Console::WriteLine("Hello World " + myName); 
```

That line will be transformed at compile time into:

```
Console::WriteLine("Hello World " + myName); 
```

When we compile the client for .NET. In this case the generated code won't have changes because our abstract interface it's the same that the one used on .NET. For Java the client call will be transformed into this:

```
System::@out.println("Hello World " + myName);
```

Ok, this is a trivial example. But even with this trivial example remember that this is not possible to do with mainstream languages, and that is simply because for even this simple case you need modular code generators and an unified semantic.
The first is provided by Zoe Code Generator modules, and the later by the Zoe language and compiler that helps warranty that your code is compilable and valid for multiple runtimes.

Now, we need some kind of compile time encapsulation for `FileWriter` and `FileReader` classes. To implement these classes we need to introduce the following concepts:

  1. Type constructors
  1. Compile time classes instance methods

### Type constructors ###
The same abstract concept for a specific framework is declared with different types in different libraries. For example, for reading text files in .NET we have the class **System.IO.StreamReader** , and in Java we have the class  **java.io.FileReader** .

If we want to provide an unified abstract interface for reading text files we will need a means to translate, at compile time, variable declarations, inheritance, field declarations, etc. For example, if our high level programmer declares the following variable:

```
GenericFileReader^ myFileReader = new GenericFileReader();
```

We will need something to inform to Zoe compile time classes that `GenericFileReader` must be converted into `StreamReader` when compiling for .NET and into `FileReader` when compiling for Java.

These compile time conversion are handled by a special kind of constructors called **type constructors**.

The following sample shows the type constructor for our abstract class `FileReader`:

```
    // Type constructor for FileReader compile time class
    //
    type FileReader(){
      // return a different type for .NET than for Java
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return ZoeHelper::MakeTypeFromString("DotNET.System.IO.StreamReader");
      }
      else{
        return ZoeHelper::MakeTypeFromString("Java.java.io.FileReader");
      }
    }
```

Type constructors are declared as methods that have the same name as the compile time class and with a return type of type `type` or `exp void`.
A type constructor of return type `type` doesn't take arguments and must return an instance of `XplType`. For that, you can use gettype expression, use the helper method `ZoeHelper::MakeTypeFromString`, create the instance of `XplType` yourself or use some available instance of `XplType`. These type constructors are called **default type constructors**.

Type constructors of type `exp void` can take parameters and must return a new expression, that is an expression which content is an `XplNewexpression` node. These type constructors are called **non-default type constructors**.
For example:

```
  public factory class ComponentName{
  public:
    type ComponentName(){
      return gettype(string);
    }
    exp void ComponentName(exp void arg1, exp void arg2){
      return writecode(new string($arg2.toString()));
    }
  }  
```

That sample class show both type constructors, the **default type constructor** is called every time that in the client code the typename of the class is named with the exception of new expressions - that's only because there is a type constructor that takes parameters. The sample **non-default type constructor** is called when the client code use the class type name in a new expression that takes two parameters, for example in the expression `new ComponentName( "hello", "world")`.

With these two special kind of constructors you can easily encapsulate types at compile time. Take into account, that while type constructors are running you have access to all special objects accessible by compile time classes like `context`, `compiler`, `currentDTE`, etc. With these objects you can, for example, detect when the type constructor was called in an inheritance declaration, field declaration, etc. and execute accordingly.

### Compile time classes instance methods ###
Our sample class Console only used static methods. When you try to encapsulate an API at compile time you will also have to take into account instance methods for classes more complex than Console.
For that purpose, you can use instance methods of compile time classes. For example, our abstract `FileReader` class declares the following instance method:

```
    exp int Read(exp char[] buffer){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(ileft.Read($buffer, 0, (int)$buffer.Length));
      }
      else{
        return writecode(ileft.read($buffer));
      }      
    }
```

To write instance methods for API encapsulation you follow the same rules than for static methods:
  1. In your "abstract interface" take expressions instead of values as parameters, and return expressions instead of values
  1. Use the compiler object to know for which platform we are compiling and return a new expression according to the platform

The main difference with static methods is that in writecode expressions you will need to use the special Meta D++ keyword `ileft`. This keyword represent **what is at the left of the function call expression**.

For example, in the call:

```
myVar.Read( buffer );
```

The keyword `ileft` inside `writecode` expressions represents `myVar`. Also, you always use a dot '.' to access members without taking into account if the caller is a pointer, a reference or a value. The implementation of writecode will take care of that and will use '.' or '->' when needed.

## Returning back to our sample ##
Returning back to our sample for reading and writing to text files, the compile time classes will be as follow:

```
 using DotNET::System;
 using DotNET::System::Collections;
 using DotNET::LayerD::CodeDOM;
 using DotNET::LayerD::ZOECompiler;
 
 namespace LayerD::IO{
 
  // Provides encapsulation for general exceptions
  // Compatible with .NET and Java
  public factory class UniversalException{
  public:
    type UniversalException(){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return ZoeHelper::MakeTypeFromString("DotNET.System.Exception");
      }
      else{
        return ZoeHelper::MakeTypeFromString("Java.java.lang.Exception");
      }
    }
    exp string^ GetMessage(){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(ileft.Message);
      }
      else{
        return writecode(ileft.getMessage());
      }
    }
  }
 
  // Provides encapsulation for basic consule input/output
  // Compatible with .NET and Java
  public factory class Console {
    Console(){
      // You can't create instances
    }
  public:
    static exp void Write(exp void toWrite){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(DotNET::System::Console::Write($toWrite));
      }
      else{
        return writecode(Java::java::lang::System::@out.print($toWrite));
      }
    }
    static exp void WriteLine(exp void toWrite){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(DotNET::System::Console::WriteLine($toWrite));
      }
      else{
        return writecode(Java::java::lang::System::@out.println($toWrite));
      }
    }
    static exp void WriteLine(){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(DotNET::System::Console::WriteLine());
      }
      else{
        return writecode(Java::java::lang::System::@out.println());
      }
    }
  }
 
  // Provides encapsulation for reading text files
  // Compatible with .NET and Java
  public factory class FileReader {
  public:
    type FileReader(){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return ZoeHelper::MakeTypeFromString("DotNET.System.IO.StreamReader");
      }
      else{
        return ZoeHelper::MakeTypeFromString("Java.java.io.FileReader");
      }
    }
    exp void FileReader(exp string^ fileName){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(new DotNET::System::IO::StreamReader($fileName));
      }
      else{
        return writecode(new Java::java::io::FileReader($fileName));
      }
    }
    exp int Read(exp char[] buffer){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(ileft.Read($buffer, 0, (int)$buffer.Length));
      }
      else{
        return writecode(ileft.read($buffer));
      }      
    }
    exp bool Eof(){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(ileft.EndOfStream);
      }
      else{
        return writecode(!ileft.ready());
      }      
    }
    exp void Close(){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(ileft.Close());
      }
      else{
        return writecode(ileft.close());
      }
    }
  }
 
  // Provides encapsulation for writing text files
  // Compatible with .NET and Java
  public factory class FileWriter {
  public:
    type FileWriter(){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return ZoeHelper::MakeTypeFromString("DotNET.System.IO.StreamWriter");
      }
      else{
        return ZoeHelper::MakeTypeFromString("Java.java.io.FileWriter");
      }
    }
    exp void FileWriter(exp string^ fileName){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(new DotNET::System::IO::StreamWriter($fileName));
      }
      else{
        return writecode(new Java::java::io::FileWriter($fileName));
      }
    }
    exp int Write(exp string^ buffer){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(ileft.Write($buffer));
      }
      else{
        return writecode(ileft.write($buffer));
      }      
    }
    exp void Close(){
      if(compiler.get_OutputPlatform().Contains("DotNET")){
        return writecode(ileft.Close());
      }
      else{
        return writecode(ileft.close());
      }      
    }
  }
 }
```

Now, save the client code at the beginning as `FileIOSample.dpp` and the compile time code as `FileIOSampleTemplate.dpp` and compile the compile time classes with the following commands:

```
metadppc.exe FileIOSampleTemplate.dpp

zoec.exe -ae FileIOSampleTemplate.zoe
```

That will add the compile time classes to the Zoe compiler.

### Compile the client for .NET ###
Now you can compile the client to .NET platform with these commands:

```
metadppc.exe FileIOSample.dpp

zoec.exe FileIOSample.zoe
```

If you want to see how the Zoe client code is transformed at compile time run the compilation with the following command:

```
zoec.exe -sid FileIOSample.zoe
```

And you will see that the client code is transformed at compile time into this code:

```
 namespace FileIOTest{
  public class TestIO{
  public:
    static void Main(string^[] args){
      DotNET::System::Console::WriteLine("Multiplatform sample for IO to text files.");
      char[] buffer = new char[1024];
      try {
        // write somethings to a file
        DotNET::System::IO::StreamWriter^ wvar = new DotNET::System::IO::StreamWriter("test.txt");
        wvar.Write("Uno\n");
        wvar.Write("Dos\n");
        wvar.Write("Tres\n");
        wvar.Write("Cuatro\n");
        wvar.Write("Cinco\n");
        wvar.Close();
        // read the file that was recently written
        DotNET::System::IO::StreamReader^ var = new DotNET::System::IO::StreamReader("test.txt");
        while (!var.EndOfStream){
          var.Read(buffer, 0, (int)buffer.Length);
          DotNET::System::Console::Write(buffer);
        }
        var.Close();
      }
      catch (DotNET::System::Exception^ error){
        DotNET::System::Console::WriteLine("Error: " + error.Message);
      }
      DotNET::System::Console::WriteLine();
      DotNET::System::Console::WriteLine("End multiplatform IO sample.");
    }
  }
 }
```

### Compile the client for Java ###
To compile the client for Java platform with these commands:

```
metadppc.exe FileIOSample.dpp

zoec.exe -p:java FileIOSample.zoe
```

If you want to see how the Zoe client code is transformed at compile time run the compilation with the following command:

```
zoec.exe -sid -p:java FileIOSample.zoe
```

And you will see that the client code is transformed at compile time into this code:

```
 namespace FileIOTest{
  public class TestIO{
  public:
    static void Main(string^[] args){
      Java::java::lang::System::@out.println("Multiplatform sample for IO to text files.");
      char[] buffer = new char[1024];
      try {
        // write somethings to a file
        Java::java::io::FileWriter^ wvar = new Java::java::io::FileWriter("test.txt");
        wvar.write("Uno\n");
        wvar.write("Dos\n");
        wvar.write("Tres\n");
        wvar.write("Cuatro\n");
        wvar.write("Cinco\n");
        wvar.close();
        // read the file that was recently written
        Java::java::io::FileReader^ var = new Java::java::io::FileReader("test.txt");
        while (!!var.ready()){
          var.read(buffer);
          Java::java::lang::System::@out.print(buffer);
        }
        var.close();
      }
      catch (Java::java::lang::Exception^ error){
        Java::java::lang::System::@out.println("Error: " + error.getMessage());
      }
      Java::java::lang::System::@out.println();
      Java::java::lang::System::@out.println("End multiplatform IO sample.");
    }
  }
 }
```

## More on API encapsulation at compile time ##

As shown in this example LayerD provides the required infrastructure to, if necessary, encapsulate particular APIs, Frameworks and libraries behind abstract interfaces that are transformed at compile time.

There are multiple strategies to implement API encapsulation with LayerD. The one used will depend on your requirements and which API are you abstracting behind compile time classes.

In general terms, you can follow these techniques:
  1. **When target API are considerable similar:**  you can directly translate from your abstract interface to target API at compile time. This is the best in terms of performance but sometimes it's hard to achieve for multiple APIs because transformations becomes too complex, in that case you can follow the 2 or 3 approach.
  1. **When target API are considerable different:**  start defining an abstract interface, implement light native wrappers around native APIs that expose a similar semantic to your abstract interface and finally implement the API compile time abstraction transforming from abstract types to concrete types implemented by your native wrappers. This options is not as efficient as the first one but because the wrappers that you will need will be very light, in general, and native to the target runtime that won't impose costly performance penalties.
  1. **When target API are similar but portions are different or require complex transformations:**  use the 1 and 2 techniques mixed. For methods that work similarly on all target APIs use direct compile time transformations, and for functionality that are managed differently by target APIs use light native runtime wrappers and make transformations to those wrappers.

## Implementation techniques to encapsulate API for multiple frameworks or runtimes ##

TODO : write this section

## Other uses for API encapsulation at compile time ##
The infrastructure provided by LayerD for API encapsulation is also useful to implement interesting techniques like:
  1. **Client code API refactoring:**  by implementing interactive compile time classes you can refactor client code of certain API to adapt the client code to a new library. You can see a sample API refactoring here [API refactoring using compile time classes](API_refactoring.md).
  1. **API evolution:**  with compile time classes you can encapsulate at compile time the changes between older and newer version of a specific library or framework. For example, if you provide to your clients a new version of your library, you can provide compile time classes that mirror older interface of the library but transform that older interface to the newer one at compile time. With that, your clients don't need to manually update their client source code. Also, you can provide interactive version of those compile time classes to permanently refactorize the client source code to the newer version of the library. You can see a sample API evolution here [API evolution using compile time classes](API_Evolution_with_ctc.md).
  1. **Active libraries:**  With simple compile time classes that follow the interface of specific runtime classes you can easily learn about the context in which your library is used in client code and make advices to the programmer or even discover possible errors. You can see a sample Active library here [Active libraries using compile time classes](Active_libraries.md).

## Inheritance and polymorphism ##
Inheritance and polymorphism relations are automatically managed by compile time classes for method calls but you must take into account the relationship between classes when designing complex abstract API and take care of refactorization of concrete interface implementation by client classes.

For example, if you have a compile time class "IEvent" that encapsulates a runtime interface for certain framework, in the type constructor of "IEvent" you will wan't to make the required refactorization of client classes when you detect that the type is used as base class or interface implementation.