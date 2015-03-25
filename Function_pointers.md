# Function Pointers #

To declare a function pointer value you must first declare a function pointer type.

Function pointer types defines the prototype that pointed function must conform.

Example function pointer declaration:

```
namespace T
{
  class C
  {
    // use the syntax for methods and add "fp" keyword
    //   here it declares the type Delegate
    //   a pointer to functions with the signature:
    //      void (*)(int,int) 
    fp void Delegate(int a, int b);

    // to declare a variable of Delegate type use that name:
    Delegate functionPointerField;
  }
}
```

Function pointers types can only be declared inside classes.

Function pointers can store address of static or instance functions.
When used with instance functions it also holds a pointer to an  instance and that instance is used to call the function.

Two function pointers types can be explicitly converted if the signature
of both pointed functions is the same (not supported on all output platforms, it can be an error for certain Zoe output modules used).

For example:

```
namespace T
{
  class C
  {
    fp void FP1(int a, int b);
    fp void FP2(int a, int b);
    fp void FP3(int a);

    void foo1(int a, int b)
    {
       FP1 var1 = &this.foo1;
       
       // valid conversion, FP1 and FP2 points to the same class of functions
       FP2 var2 = (FP2)var1;

       // invalid conversion
       // signatures of FP1 and FP3 are not the same
       FP3 var3 = (FP3)var1;
    }
  }
}
```



Sample that use functions pointers (that target .NET framework):

```
import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
import "System", "platform=DotNET", "ns=DotNET", "assembly=System";
using DotNET::System;
using DotNET::System::Collections;

namespace Test
{
	public class T 
	{
		static ArrayList^ _list = new ArrayList();

	public:
		// declare a function pointer type
		fp void Delegate(int a, int b);

		static void foo1(int a, int b)
		{
			Console::WriteLine("Foo1: " + a + " - " + b);
		}
		static void foo2(int a, int b)
		{
			Console::WriteLine("Foo2: " + a + " - " + b);
		}
		static void foo3(int a, int b)
		{
			Console::WriteLine("Foo3: " + a + " - " + b);
		}

		// recive a function pointer parameter
		static void Register(Delegate func)
		{
			_list.Add(func);
		}

		static void Run()
		{
			for(int n = 0; n< _list.Count; n++)
			{
				// call function pointers
				((Delegate)_list[n])(n, n+1);
			}
		}

		static int Main(string^[] args)
		{
			// hold pointers to function in the arraylist
			Register(&foo1);
			Register(&foo2);
			Register(&foo3);

			Run();

			Console::Read();
			return 0;
		}

	}

}

```