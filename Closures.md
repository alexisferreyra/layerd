# Closures #

Meta D++ support closures by using simple function call expressions, using the special name `Func`, with block parameters, like this one:

```
Func(a is int, b is int){
  return a + b;
};
```

That expression creates a closure that takes two integer as parameters and returns an integer value.
Types in parameters are optional, and if provided, you must use the expression "is". If the type for a parameter is not provided it implies a parameter of type `object*ref`.
Return type for closures is inferred from return statements.

```
// This closures creates an anonymous function with parameters a and b of type "object*ref" 
// and return type "string*ref" 
Func(a, b)
{
   return a.ToString() + b.ToString();
};
```

Closure expressions returns a function pointer, so you can storage closure references in any variable with a function pointer compatible with the signature of the closure.

```
namespace T
{

  class Sample
  {
  public:
    // function pointer type
    fp int F1(int a, int b);
  
    static int foo()
    {
      // create the closure
      F1 intIntFunctionPointer = Func(a is int, b is int){
        return a + b;
      };
    
      // call the closure using the function pointer
      return intIntFunctionPointer(2, 3);
    }
  }

}
```

Closures can capture local variables, and any other symbol in the scope, like in:

```
static int foo()
{
  int localVar = 5;
  return (Func(a1 is int){
    return a1 + localVar;
  })(3);
}
```

Calling foo() will return 8.

Actual implementation in generated code will depend on the Zoe code generator used. But most of the time, it will be mapped to native closures in the target platform.

At the time of writing, closures are supported only by Javascript and .NET code generators.

**Note:** if in a classfactory, you override the Func name with your own defined compile time function, it will hide the special name Func and won't be able to use closures in that scope.