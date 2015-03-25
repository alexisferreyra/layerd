Here we'll show some examples of Compile Time Classes (CTC).

## EXAMPLE #1: Implementing an Aspect ##

Let's suppose we want to implement an "aspect" that adds a "try-catch" block to all the bodies of functions of all the classes of a namespace. We are going to create a CTC that will receive the "try-catch" block as a parameter and will add it to every body of every function of every class of a namespace. In this example we are going to see:

  * How to create a compile time class (CTC)
  * How to send a block of code as parameter
  * Special compile time objects such as "context" and "compiler"


**ORDINARY CLASS**

Here is the ordinary class (OC) programmed in MetaD++. As you can see, there's a function call to a CTC function just after the namespace declaration. Should be clarified that the target platform in this example is .NET. Now, look at the code and read the comments that will help you to understand:

```
//#1: These are the "import" directives needed if your target platform is .NET.
import "Microsoft", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";

//#2: Some "using" directives needed to use some .NET classes.
using DotNET::System;
using DotNET::System::IO;
using DotNET::System::Collections;

//#3: This "using" directive is very important because in this namespace is where the CTCs are. 
//(You'll see it better in the CTC declaration)
using Zoe::Tools;

namespace Sample{

//#4: Here's the function call to the CTC function
AOP::AddTry{
  try{
        //#5: Here is where we want to put the body of the functions of each class of this namespace
  }
  catch(Exception^ error){
    Console::WriteLine("Excepcion : " + error.ToString());
  }
};

//#6: These are the classes that we want to change
public class App{
  public:
    static int Main(string^[] args){
      
      A^ aa = new A();
      B^ bb = new B();
      
      aa.foo();
      aa.foo2();
            
      bb.foo();
                 
      return 0;
    }
  }
  
  public class A{
    int c = 0;
  public:
    void foo(){
      Console::WriteLine("A::foo");
      int a = 12 / c;
    }
    void foo2(){
      Console::WriteLine("A::foo2");
      int a = 12 / c;
    }
  }
  public class B{
    int c = 0;
  public:
    void foo(){
      Console::WriteLine("B::foo");
      int a = 12 / c;
    }
  }
}
```

Look that after the `AOP::AddTry` there aren't regular arguments sent as parameters, instead, there are braces containing a block of code. This way of calling a function, in this case a function of a CTC, is the way in which we send a "block of code" as parameter.


**COMPILE TIME CLASS**

Here is presented the Compile Time Class (CTC) that will make what we proposed to do. The important thing here is to see that here we are going to work mostly with the source code of the source files that called to this CTC.

```
import "Microsoft", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";

using DotNET::System;
using DotNET::System::IO;
using DotNET::System::Collections;
using DotNET::LayerD::CodeDOM;
using DotNET::LayerD::ZOECompiler;

/*#1: As you can see this CTC is declared in the "Zoe::Tools" namespace, for that reason we included it in the "using" directives on the OC.*/
namespace Zoe::Tools{

    /*#2: To discriminate that this class is a compile time class you must use the modifier "factory".*/
  public factory class AOP{
  public:
    static exp void AddTry(block tryBlock){
      
      /*#3: Here we are asking the special object "context" to bring us all 
                  the classes that are inside the "namespace".*/
      XplNodeList^ classesOfNameSpace=context.CurrentNamespace.get_ClassNodeList();       
      
            /*#4: Iterate each class...*/
      for(XplClass^ oneClass in classesOfNameSpace)
      {
        /*#5: Bring us all the functions of this Class.*/
        for(XplFunction^ oneFunction in oneClass.get_FunctionNodeList())
        {
          /*#6: There's no point to implement this aspect in the "Main" function.
              So here we omit the "Main" function asking for the "function name" and checking it's not the "Main" one*/
          if(oneFunction.get_name()!="Main")
          {
            /*#7: Save the body of the function in an appropriate variable. 
                (XplFunctionBody or "block", it's the same)*/
            XplFunctionBody^ body=oneFunction.get_FunctionBody();
            
            /*#8: I need to clone the tryBlock sent by parameter because I need to use it for every function of the class.*/            
            XplFunctionBody^ tryBlock2=(XplFunctionBody^)tryBlock.Clone();
            
            /*#9: The tryBlock2 has a "TryStatement" inside, so we need to look for it because we
                want to put "something" inside the "try". 
                Here we iterate over the nodes that the block has, looking for one that is a XplTryStatement.*/
            for(XplNode^ part in tryBlock2.Children())
            {
              if(part.get_TypeName()==CodeDOMTypes::XplTryStatement)
              {
                /*#10: We found the TryStatement, now we set to the "Try" it content.(The body of the function)*/
                ((XplTryStatement^)part).set_trybk(body);
                break;
              }
            }
                        
            /*#11: Finally we set a new "FunctionBody" to the function of the class.
                (The one where we have the try-catch block with the previous function body inside)*/
            oneFunction.set_FunctionBody(tryBlock2);
            
          }                    
        }
	  }	
          
      /*#12: What's this "null" doing here? Well, look at the return type of the function of this "compile time class".. 
          It's an expression (exp), this means that when the call of function ends,this expression will be returned 
          to the ordinary class and will be written in the line where the function was called. 
          This means that "nothing" will be in that line.*/

      return null;
    }  
  }
}
```

**COMPILATION OF CTC AND OC**

Once the OC is finished we must compile it!. Remember to save it as a ".dpp" file

To compile it, use MetaD++ compiler and do the following:

```
metadppc.exe myOC1.dpp
```

This will generate a ".zoe" file.

Once the CTC is finished we must compile it too. Remember to save it as a ".dpp" file

```
metadppc.exe myCTC.dpp
```

Now, that we have the ".zoe" file let's add it as an extension to the compiler:

```
zoec.exe myCTC.zoe -ae 
```

Because we want to show you the "code transformation" in this example we are going to generate only the ".cs" file (not the ".exe"). Once you have the ".zoe" file of the OC class, you can compile it without generating the executable, passing to the ZOE compiler the following option:

```
zoec.exe myOC1.zoe -ro
```

When ZOE compiler start doing it job on the class, after reading the heading and the namespace declaration, it reads the `AOP::AddTry` that's the call to the CTC function.


**THE RESULT: THE ".CS" FILE.**

As result of everything we've done, we should obtained a ".cs" file written in C# that should be like what we proposed at the beginning.
The generated C# file should look like this:

```
namespace Sample
{
  public class App
  {
    public static int Main(string[] args)
    {
      Sample.A aa = new Sample.A();
      Sample.B bb = new Sample.B();
      aa.foo();
      aa.foo2();
      bb.foo();
      return 0;
    } 

  } 
  public class A
  {
    private int c = 0; 
    public void foo()
    {
      try 
      {
        System.Console.WriteLine("A::foo");
        int a = 12 / c;
      }
      catch (System.Exception error)
      {
        System.Console.WriteLine("Excepcion : " + error.ToString());
      }
    } 

    public void foo2()
    {
      try 
      {
        System.Console.WriteLine("A::foo2");
        int a = 12 / c;
      }
      catch (System.Exception error)
      {
        System.Console.WriteLine("Excepcion : " + error.ToString());
      }
    } 

  } 
  public class B
  {
    private int c = 0; 
    public void foo()
    {
      try 
      {
        System.Console.WriteLine("B::foo");
        int a = 12 / c;
      }
      catch (System.Exception error)
      {
        System.Console.WriteLine("Excepcion : " + error.ToString());
      }
    } 

  } 
} 
```

I wish you had understood this because now we're going to advance to a next level...  If you didn't, please try reading slowly the example again or read documentation of MetaD++ to understand  things well before continuing.. :) Let's go step by step..

## EXAMPLE #2: "Improving EXAMPLE #1" ##

Let's move forward for improving "Example #1". Now we want to add the following functionality:
  * Check if the call to the function of the CTC is been made from a valid namespace.
  * Check if the block of code passed as parameter is a valid "try-catch" block.
  * Rename each function with "_" before the original name._

  * Create new functions that:
    1. will be named as the previous functions (without  "_"),
    1. will call the functions that have been renamed
    1. will contain the "try-catch" block inside (for controling exceptions)_

Concerning the function call, we must be warned in sending the same arguments to the original functions from the new functions, and in including the "return" statement in the new functions if neccesary!

**ORDINARY CLASS**

For doing this example we'll modify the OC functions adding new ones that accept parameters. Here's the new OC:

```
import "Microsoft", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";

using DotNET::System;
using DotNET::System::IO;
using DotNET::System::Collections;

using Zoe::Tools;

namespace Sample{

AOP::encapsulateFunctionsWithTry{
  try{
         /*#1: The new functions will call the original functions from here! (If necessary, it should have a "return")*/
  }
  catch(Exception^ error){
    Console::WriteLine("Excepcion : " + error.ToString());
  }
};

public class App{
  public:
    static int Main(string^[] args){
      
      A^ aa = new A();
      B^ bb = new B();
      
      aa.foo();
      
      //#2: Send parameters to foo2 of A class.
      aa.foo2(6,2);
      
      //#3: Send parameters to foo of B class.
      bb.foo(3,0);
      
      return 0;
    }
  }
  
  public class A{
  
    int c = 0;
  
  public:
    void foo(){
      Console::WriteLine("A::foo");
      int a = 12 / c;
    }
    //#4: foo2 now has an int as return type and accepts 2 parameters
    int foo2(int a, int b){
      Console::WriteLine("A::foo2");
      return a/b;
    }
  }
  
  public class B{
    int c = 0;
  
  public:
      //#5: foo now has an int as return type and accepts 2 parameters
    int foo(int d, int e){
      Console::WriteLine("B::foo");
      return d/e;
    }
  }
}
```


**COMPILE TIME CLASS**

We'll divide the logic of the solution in 3 functions. We're going to explain them one by one below.

The first function is the one that will be call from a OC, and will be the skeleton of the logic. The other 2 functions will work for this principal function. Another reason for dividing in 3 functions is to make things easier to understand (and of course, a little more modular)

  * The Principal Function

This function receive as parameter, like in the previous example, only the "try-catch" block. Look now the comments that will help you to understand the logic of the function.

```
static exp void encapsulateFunctionsWithTry(block tryBlock){
      
      /*#1: Check if the call to the classfactory is been made from a valid namespace*/
      if(context.CurrentNamespace==null)
      {
        compiler.AddError(new Error("The function call has not been done from a valid namespace",context) );
      }
      
      /*#2: Check if the "tryBlock" contains only one "TryStatement"*/
      if(!checkTryStatementOnly(tryBlock))
      {
        compiler.AddError(new Error("The block passed as parameter doesn't contains only a try-catch block",context) );
      }    
        
      /*#3: Ask to the namespace to bring us all the classes it has inside*/
      XplNodeList^ clases=context.CurrentNamespace.get_ClassNodeList(); 
            
      /*#4: If it hasn't classes (List Empty) then let's finish right now!*/
      if(clases.GetLength()==0){return null;}
      
      /*5: If there are classes, let's work on each one*/
      for(XplClass^ classNode in clases)
      {
        /*6: Ask to the class to bring us all the functions it has inside*/
        XplNodeList^ functions=classNode.get_FunctionNodeList();
        
        /*7: Now we work with every function*/
        for(XplFunction^ function in functions)
        {
          /*8: Remember we don't want to modify the "Main"*/
          if(function.get_name()!="Main")
          {
            /*9: Encapsulate the function in a new one.*/
            XplFunction^ functionEncapsulator=encapsulateOriginalFunction(function, tryBlock);
            
            /*#10: Add the new function to the class!*/            
            classNode.InsertAtEnd(functionEncapsulator);
              
            /*#11: Rename the original function.*/  
            function.set_name("_"+function.get_name());
          }
        }
      }
      return null;
    }
```

  * The try-catch checking function

For checking the try-catch block passed as parameter, a function named "checkTryStatementOnly"  is called. Let's see a little more about how it works:

```
static bool checkTryStatementOnly(block tryBlock)
    {
      //#1: Let's check if the "tryBlock" contains only a valid "TryStatement"
      XplNodeList^ childrenOfBlock=tryBlock.Children();
      
      //#2: The block must contains only one node and it must be a XplTryStatement.
      if(childrenOfBlock.GetLength()!=1 || !childrenOfBlock.FirstNode().IsA(CodeDOMTypes::XplTryStatement)){return false;}
        
      return true;        
    }
```

  * The encapsulator function

This function encapsulates an original function in a new one with the try-catch block inside. As you'll see the function receives as parameters the original function and the try-catch block (already verified) and returns the encapsulator function that will be add later. Here's the function, read carefully the comments on it:

```
    static XplFunction^ encapsulateOriginalFunction(XplFunction^ originalFunction, block tryblock)
    {
      /*#1: Copy the original function (It copies everything: the return type, arguments, etc).*/
      XplFunction^ encapsulator=(XplFunction^)originalFunction.Clone();
      
      /*#2: Here we create the line that the try-catch block will have inside.*/
      XplIName^ line=new XplIName("_"+encapsulator.get_name());
            
      /*#3: Is need to know if the function returns something, because if it does, the "return" must be consider in the encapsulator function
            Now we form the block that will be contained in the "try"*/
      XplFunctionBody^ bodyTry=new XplFunctionBody();
      
      /*#4: Here we ask if the return type of the encapsulator function is "void" or not, to know if we must return some value or not*/
      if(NativeTypes::IsNativeVoid(encapsulator.get_ReturnType().get_typename()))
      {
        /*#5: Look that here we don't use the same writecode instruction that in the other branch of this conditional. This is because 
        a "function call" in a writecode instruction with braces returns a "DocumentBody", not a "FunctionBody". 
        The "function call" could be valid in a "function body" or not (for example after a namespace declaration like we do in this example)
        and, for that reason, it returns a "DocumentBody". */
        XplExpression^ expre=writecode($line());
        bodyTry.InsertAtEnd(expre);
      }
      else
      {
        /*#6: Here we can see a regular use of the writecode instruction with braces. 
          In this case we're building the body of the try statement.
          In this case the "return statement" is needed, and, with the "return statement" there's no doubt that it is a 
          valid function body. We don't have "return" in a "DocumentBody"
        */
        bodyTry=writecode{
                           return $line();
                  };
      }
      
      /*#7: We have to look for the function call that is inside the block so we can set to it the arguments*/
      XplFunctioncall^ funcCall=(XplFunctioncall^)bodyTry.FindNode("@XplFunctioncall");
        
      XplExpressionlist^ arguments=XplFunctioncall::new_args();
      
      /*#8: Check if the function accepts parameters*/
      if(encapsulator.get_Parameters()!=null)
      {
        for(XplParameter^ parameter in encapsulator.get_Parameters().Children())
        {
          XplIName^ iP=new XplIName(parameter.get_name());
          arguments+=writecode($iP);
        }
      }
      
      funcCall.set_args(arguments);    
      
      /*#9: Clone the "try-catch" block like in the previous example*/
      XplFunctionBody^ tryBlock2=(XplFunctionBody^)tryblock.Clone();
        
      /*#10: Look for the Try Statement inside the block passed as parameter*/
      XplTryStatement^ trySt=(XplTryStatement^)tryBlock2.FindNode("/@XplTryStatement");
      
      /*#11: As we know, this block contains only one "try-catch" statement inside. (Verified in the function that calls this one)
             Thus, the only left is to assign the this "function body" to the "try".*/
      trySt.set_trybk(bodyTry);
                    
      /*#12: Finally we establish as function body of the encapsulator function the tryblock2 that contains
             the "try-catch" statement with the call to the original function. (That includes the return statement if neccesary)*/
      encapsulator.set_FunctionBody(tryBlock2);
      
      return encapsulator;
    }
```


**THE RESULT: THE ".CS" FILE**

Proceeding as in the previous example we should, in last instance, compile the OC class to obtain finally the class written in .NET (in this case).

```
namespace Sample
{
  public class App
  {
    public static int Main(string[] args)
    {
      Sample.A aa = new Sample.A();
      Sample.B bb = new Sample.B();
      aa.foo();
      aa.foo2(6, 2);
      bb.foo(3, 0);
      return 0;
    } 

  } 
  public class A
  {
    private int c = 0; 
    public void _foo()
    {
      System.Console.WriteLine("A::foo");
      int a = 12 / c;
    } 

    public int _foo2(int a, int b)
    {
      System.Console.WriteLine("A::foo2");
      return a / b;
    } 

    public void foo()
    {
      try 
      {
        _foo();
      }
      catch (System.Exception error)
      {
        System.Console.WriteLine("Excepcion : " + error.ToString());
      }
    } 

    public int foo2(int a, int b)
    {
      try 
      {
        return _foo2(a, b);
      }
      catch (System.Exception error)
      {
        System.Console.WriteLine("Excepcion : " + error.ToString());
      }
    } 

  } 
  public class B
  {
    private int c = 0; 
    
    public int _foo(int d, int e)
    {
      System.Console.WriteLine("B::foo");
      return d / e;
    } 

    public int foo(int d, int e)
    {
      try 
      {
        return _foo(d, e);
      }
      catch (System.Exception error)
      {
        System.Console.WriteLine("Excepcion : " + error.ToString());
      }
    } 

  } 
} 
```