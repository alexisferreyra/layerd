Here we'll show another example of Compile Time Classes (CTC). This version is based in [Implementing Logging through CTC](writing_compile_time_classes_2.md)


## EXAMPLE: Implementing a Logging Aspect v.2 ##

Here, we're going to implement next features:

  * Creation of new functions with the same name of originals which call original functions renamed.
  * The logging also print the return value of the functions.
  * The method that prints log messages can be setted by user in OC.


The modifications by CTC will produce any code similar to the next:

```
function(int a){
 LOG("Begining of function");
 LOG("- param a with value:" + a);
 _function(a);
 LOG("Exiting of function");
}
```


**ORDINARY CLASS**

The Original Class (OC) is the next. Observe that are three functions in two class wich receives and return different things.
Comments are ommited. See in [Writing CTC](Writing_compile_time_classes.md)

```
import "Microsoft", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";

using DotNET::System;
using DotNET::System::IO;
using DotNET::System::Collections;

using Zoe::LoggingTool;

// call to compile time logging aspect function
AOP::AddLog(Console::WriteLine);

namespace Sample{
public class App{
  public:
    static int Main(string^[] args){
      
      A^ aa = new A();
      B^ bb = new B();      
      aa.foo();    
      aa.foo2(6,2);
      bb.foo(3,1);
      return 0;
    }
  }
  
  public class A{
  
    int c = 2;
  
  public:
    void foo(){
      Console::WriteLine("A::foo");
      int a = 12 / c;
    }
    int foo2(int a, int b){
      Console::WriteLine("A::foo2");
      return a/b;
    }
  }
  
  public class B{
    int c = 3;  
    public:
    int foo(int d, int e){
      Console::WriteLine("B::foo");
      return d/e;
    }
  }
}
```

**COMPILE TIME CLASS**

The Compile Time class consist of the main function _AddLog_ and three helper functions.

```
/*#3: AddLog receives the Log Function wich will be added to code. It brings flexibility to programmer*/
static exp void AddLog( iname void logMethod ){
   
  XplNodeList^ classesOfNameSpace=context.CurrentNamespace.get_ClassNodeList();       
  
  if (classesOfNameSpace.GetLength() == 0){ return null;}
  
  for(XplClass^ oneClass in classesOfNameSpace)
  {
    /*#6: Bring us all the functions of this Class.*/
    for(XplFunction^ originalFunction in oneClass.get_FunctionNodeList())
    {
    /*#7: There's no point to implement this aspect in the "Main" function.
      So here we omit the "Main" function asking for the "function name" and checking it's not the "Main" one*/
      if(originalFunction.get_name()!="Main")
      {       

        /*#8: We'll make a new one equals function, but with a different body: Some Loggings and a call to renamed original function */
        XplFunction^ encapsulatorFunction = (XplFunction^)originalFunction.Clone();
        XplFunctionBody^ encapsulatorFunctionBody = new XplFunctionBody();

        /*#9: The new log function is composed by four main parts: Begin ("entering...",  "starting...", etc), Params, Original Function Call and End. 
        Here we'll insert the four parts grouped in three functions */
        encapsulatorFunctionBody += BeginLogNodes(encapsulatorFunction, logMethod);
        encapsulatorFunctionBody += ParamsLogNodes(encapsulatorFunction, logMethod);
        encapsulatorFunctionBody += FunctionCallAndExitNodes(encapsulatorFunction, logMethod, "retValue");
        
        /*#10: Here the body of function is changed for de new one, which calls to older that has an underscore before (_nameFunction) */
        encapsulatorFunction.set_FunctionBody(encapsulatorFunctionBody);

        /*#11: Changing name of original function */
        originalFunction.set_name("_" + originalFunction.get_name());

        /*#12: Add the new function to class */
        oneClass.Children().InsertAtEnd(encapsulatorFunction);

      }
    }
  }

}
```


After Comment #9, it calls to three different functions which return a list of nodes.

The first function return first lines of logging:
```
static XplNodeList^ BeginLogNodes(XplFunction^ function, iname void logMethod)
{		  
  XplExpressionlist^ expressionList = new XplExpressionlist();

  /*#13 This lines prints the name of function */
  string^ functionNameStr = function.get_name();
  expressionList.InsertAtEnd(writecode($logMethod("Entering function "+ $functionNameStr)));

  /*#14 the Return value are nodes that will be added to encapsulator function */
  return expressionList.Children();
}
```

The second function return the logging of parameter wich are received
```
static XplNodeList^ ParamsLogNodes(XplFunction^ function, iname void logMethod)
{
  XplExpressionlist^ expressionList = new XplExpressionlist();
  /*#15: If function doesn't receive params, there aren't logging of them */
  if( function.get_Parameters() == null){ return null;}
		  
  /*#16: for each param ... */
  for (XplParameter^ param in function.get_Parameters().Children())
  {  
    string^ paramNameStr = param.AttributeValue("name");				  
    XplIName^ paramId = new XplIName(paramNameStr);
    expressionList.InsertAtEnd( writecode($logMethod( "- argument " + $paramNameStr + ":" + $paramId )));			  
  }
  return expressionList.Children();
}
```


The last function, make the call to original function and add the logging of exit of function.

```
static XplNodeList^ FunctionCallAndExitNodes(XplFunction^ function, iname void logMethod, string^ retName)
{
  XplIName^ retValue = new XplIName(retName);
  XplType^ typeReturn = null;      
  XplFunctionBody^ funcCallAndExitLines = new XplFunctionBody();
  XplIName^ functionId = new XplIName("_"+function.get_name());    
  
  string^ functionNameStr = function.get_name();

  /*#17: If function call doesn't return anything, the call is:
	call();
	and the exit logging doesn't print the return value.
  */
  if(NativeTypes::IsNativeVoid(function.get_ReturnType().get_typename()))
  {        
	XplExpression^ e = writecode($functionId());
	funcCallAndExitLines.InsertAtEnd( e );      
	funcCallAndExitLines.InsertAtEnd(
	  writecode($logMethod("Exiting function " + $functionNameStr )));
  }      
  else
  {
	/*#18: Else, if function call returns a value, the call is:
	     type var = call();
	  and the exit logging prints the "var" value
        */
	typeReturn = (XplType^)function.get_ReturnType().Clone();    
	funcCallAndExitLines = writecode {
	  $typeReturn $retValue = $functionId();
	  $logMethod("Exiting function " + $functionNameStr + "with " + $retValue + " value");
	  return $retValue;
	};
  }

  /*19: The function call is incomleted, because this hasn't the arguments passed. If function call receives arguments, here are added */                 
  if(function.get_Parameters()!=null)
  {
	XplFunctioncall^ funcCall = (XplFunctioncall^)funcCallAndExitLines.FindNode("@XplFunctioncall");
	XplExpressionlist^ arguments = XplFunctioncall::new_args();   

	/*#20: For each parameter who receives, we put the names in internall call */
	for(XplParameter^ parameter in function.get_Parameters().Children())
	{
	  XplIName^ paramId = new XplIName(parameter.get_name());
	  arguments+=writecode($paramId);
	}
	funcCall.set_args(arguments);    
  }      
  
  return funcCallAndExitLines.Children();
}   
```


**THE RESULT: THE ".CS" FILE**

After Compile OC with CTC, we obtain the next result (the example compile producing a ".cs" file:

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
      bb.foo(3, 1);
      return 0;
    } 

  } 
  public class A
  {
    private int c = 2; 
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
      System.Console.WriteLine("Entering function " + "foo");
      _foo();
      System.Console.WriteLine("Exiting function " + "foo");
    } 

    public int foo2(int a, int b)
    {
      System.Console.WriteLine("Entering function " + "foo2");
      System.Console.WriteLine("- argument " + "a" + ":" + a);
      System.Console.WriteLine("- argument " + "b" + ":" + b);
      int retValue = _foo2(a, b);
      System.Console.WriteLine("Exiting function " + "foo2" + "with " + retValue + " value");
      return retValue;
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
      System.Console.WriteLine("Entering function " + "foo");
      System.Console.WriteLine("- argument " + "d" + ":" + d);
      System.Console.WriteLine("- argument " + "e" + ":" + e);
      int retValue = _foo(d, e);
      System.Console.WriteLine("Exiting function " + "foo" + "with " + retValue + " value");
      return retValue;
    } 

  } 
} 
```