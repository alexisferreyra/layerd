Here we'll show another example of Compile Time Classes (CTC). Particularly, a Logging Aspect through CTC.

## EXAMPLE: Implementing a Logging Aspect ##

We want to implement an "aspect" that adds _Logging_ messages in the body functions.
We are going to create a CTC that will add some lines of log to every body of every function of every class of a namespace. Then, the body of the functions after be processed by CTC will look like:
```
 Log.WriteLine("Entering function <functionName>");
 Log.WriteLine("- argument <var1> :" + <var1>);
 ....
 // function body
 ...
 Log.WriteLine("Exiting function <functionName>");
```

In another words, the lines will indicate that the start and the end of function and the arguments who receives with their values.

> In this example we are going to see:

  * How to create a compile time class (CTC)
  * How to compile and test CTC with an ordinary class as example.


**ORDINARY CLASS**

Here is the ordinary class (OC) programmed in MetaD++. As you can see, there's a function call to a CTC function just after the namespace declaration.

```
//#1: These are the "import" directives needed if your target platform is .NET.
import "Microsoft", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
//#2: Some "using" directives needed to use some .NET classes.
using DotNET::System;
using DotNET::System::IO;
using DotNET::System::Collections;
//#3: This "using" directive is very important because in this namespace is where the CTCs are. 
using Zoe::LoggingTool;

namespace Sample2{

//#4: Here's the function call to the CTC function
AOP::AddLog();


//#6: These are the classes that we want to change
public class App{
  public:
    static int Main(string^[] args){      
      A^ aa = new A();
	  B^ bb = new B();
	  aa.foo(2,3);    
	  bb.foo2();
      return 0;
    }
  }  
  public class A{    
	public:
	int foo(int arg1, int arg2){ 
	  int ret = arg1 + arg2;
	  return ret; 
	}  
  }
  public class B{
	public:
	void foo2(){
	  int a, b, c;
	  a = 1;
	  b = 0;
	  try{ 
	    c = a / b;
	  }
	  catch( Exception^ error){		
	    Console::WriteLine("Exception: "+ error.ToString());
	  }
	}
  }
}

```


Look that `AOP::AddLog` hasn't a block of code inside. It's because all lines will be generated by CTC.


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

/*#1: As you can see this CTC is declared in the "Zoe::Tools" namespace */
namespace Zoe::LoggingTool{
 /*#2: To discriminate that this class is a compile time class you must use the modifier "factory".*/
  public factory class AOP{
  public:
    /*#3: In this case, logBlock is empty, beacause de the call in OC doesn't contain anything*/
    static exp void AddLog(){
       /*#4: Here we are asking the special object "context" to bring us all 
                  the classes that are inside the "namespace".*/
      XplNodeList^ classesOfNameSpace=context.CurrentNamespace.get_ClassNodeList();       
      
            /*#5: Iterate each class...*/
      for(XplClass^ oneClass in classesOfNameSpace)
      {
        /*#6: Bring us all the functions of this Class.*/
        for(XplFunction^ oneFunction in oneClass.get_FunctionNodeList())
        {
          /*#7: There's no point to implement this aspect in the "Main" function.
              So here we omit the "Main" function asking for the "function name" and checking it's not the "Main" one*/
          if(oneFunction.get_name()!="Main")
          {  
			  /*#8: We'll create a new Function Body to replace the currentm, adding LogLines at the begining and the end */
		    XplFunctionBody^ newBody = new XplFunctionBody();
			
			/*#9: It's necessary to have functionName in a simple var because "writecode" function restrictions 
			Here we add Firsts LogLines at Begining of function */
			string^ functionName = oneFunction.get_name();
			newBody.Children(). InsertAtEnd( 
				writecode(Console::WriteLine("Entering function "+ $functionName))
			);
			
			/*#10: We'll add a LogLine for each parameter, if exists them*/
			if( oneFunction.get_Parameters() != null){
				for (XplParameter^ param in oneFunction.get_Parameters().Children())
				{  
					/*#11: Here, paramNameStr will be converted in a string when writecode will create a new tree of code */
				   string^ paramNameStr = param.AttributeValue("name");
				   /*#12: paramId will be converted in the name of var whitout quotes */
				   XplIName^ paramId = new XplIName(paramNameStr);				   	
				   /*#13: the result of writecode function is the equivalent tree of:
							Console::WriteLine("- argument " + "var1" + ":" + var1);*/
				   newBody.Children().InsertAtEnd( 
					   writecode(Console::WriteLine( "- argument " + $paramNameStr + ":" + $paramId ))
					);			  
				}
			}

			/*#14: Add all Content of Original Function */
			newBody.Children().InsertAtEnd(oneFunction.get_FunctionBody().Children());
			
			/*#15: Here we add a LogLine at the end of function */
			newBody.Children().InsertAtEnd(
				writecode(Console::WriteLine("Exiting function " + $functionName))
				);

			/*#16: We replace the Content of Original Function with the new one */
			oneFunction.set_FunctionBody(newBody);

          }                    
        }
      }               
  
      return null;
    }  
  }
}
```

**COMPILATION OF CTC AND OC**

Once the OC is finished we must compile it!. Remember to save it as a ".dpp" file

To compile it, use MetaD++ compiler and do the following:

```
metadppc.exe logOC.dpp
```

This will generate a ".zoe" file.

Once the CTC is finished we must compile it too. Remember to save it as a ".dpp" file

```
metadppc.exe logCTC.dpp
```

Now, that we have the ".zoe" file let's add it as an extension to the compiler:

```
zoec.exe logCTC.zoe -ae 
```

Because we want to show you the "code transformation" in this example we are going to generate only the ".cs" file (not the ".exe"). Once you have the ".zoe" file of the OC class, you can compile it without generating the executable, passing to the ZOE compiler the following option:

```
zoec.exe logOC1.zoe -ro
```

When ZOE compiler start doing it job on the class, after reading the heading and the namespace declaration, it reads the `AOP::AddLog` that's the call to the CTC function.


**THE RESULT: THE ".CS" FILE.**

As result of everything we've done, we should obtained a ".cs" file written in C# that should be like what we proposed at the beginning.
The generated C# file should look like this:

```

namespace Sample2
{	
	public class App
	{
		public static int Main(string[] args)
		{
			Sample2.A aa = new Sample2.A();
			Sample2.B bb = new Sample2.B();
			aa.foo(2, 3);
			bb.foo2();
			return 0;
		} 

	} 
	public class A
	{
		public int foo(int arg1, int arg2)
		{
			System.Console.WriteLine("Entering function " + "foo");
			System.Console.WriteLine("- argument " + "arg1" + ":" + arg1);
			System.Console.WriteLine("- argument " + "arg2" + ":" + arg2);
			int ret = arg1 + arg2;
			return ret;
			System.Console.WriteLine("Exiting function " + "foo");
		} 

	} 
	public class B
	{
		public void foo2()
		{
			System.Console.WriteLine("Entering function " + "foo2");
			int a;
			int b;
			int c;
			a = 1;
			b = 0;
			try 
			{
				c = a / b;
			}
			catch (System.Exception error)
			{
				System.Console.WriteLine("Exception: " + error.ToString());
			}
			System.Console.WriteLine("Exiting function " + "foo2");
		} 

	} 
} 

```

I expect it has been clear to understand how to create a CTC in MetaD++.