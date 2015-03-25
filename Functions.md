# Class members #

Following types of class members exists in Meta D++:

  * Fields
  * Methods
  * Properties
  * Indexers
  * Operators

## Fields ##

```
namespace T{
  class A{
    // fields are written inside classes and structs in similar way to C# or Java
    int privateField;
  protected:
    A* protectedPointerToA;
  public:
    // use static declaration modifier to mark a field as static (share values between instances)
    // to reference static fields you need to provide the full name with at least the class name like:
    // A::publicStaticField or T::A::publicStaticField
    static int publicStaticField;
  }
}
```

## Methods ##

```
namespace T{
  class A{
    // methods are written inside classes and structs in similar way to C# or Java
    int privateMethod(int a, int b){
      return a + b;
    }
  protected:
    // you need to mark methods as virtual if you want to override in derived classes
    virtual A* protectedMethod(int p1){
      return null;
    }
  public:
    void simpleVoidMethod(){
    }
    // constructors
    A(){
      // implementation code here
    }
    // overloaded constructor
    A(int a, int b){
    }
  }
}
```

### Parameters ###

Parameters are passed by value by default. But you can use references "^" and pointers "`*`".
You can use `in`, `out` or `outin` when declaring parameters. Those modifiers can render byref parameters in certain Zoe output modules (out or outin renders & in C++ output module).
To declare variable parameters you can use `params` keyword in the last parameter. It must be of array type.

## Properties ##

Properties work in similar way to .NET:

```
namespace T{
  class A{
    // field to hold the value of the property
    int privateField;
    static int counter;
  public:
    // properties are declared using [type] property [name] { [getter] [setter] }
    int property Index{
      // getter block
      get{
        return privateField;
      }
      // setter block, use "value" identifier to access new value
      set{
        privateField = value;
      }
    }
    // static property
    static int property Counter{
      get{
        return ++counter;
      }
    }
  }
}

```


## Indexers ##

Indexers allows the overloading of "[.md](.md)" operator. Indexers are written similar to C# operator "[.md](.md)" overloading.

```
namespace T
{

public class C1
{
public:
  // use the keyword "indexer" to declare an indexer
  // like properties, indexer has setter and getter
  // setter is optional
  int indexer(int index)
  {
    get
    {
      return _array[index];
    }
    set
    {
      // setter gets additional implicit parameter "value" with the type of indexer return type
      _array[index] = value;
    }
  }
}
```

}

## Operators ##

Meta D++ allows to overloading of binary, unary and conversions operators.
You can override following operators:
> `< > ! == <= >= != && || ++ -- * / & | % << >> new delete - +`

Operator new and delete can´t be overriden for all Zoe output modules.

```
namespace T
{

class OtherType
{
  int field1;
public:

  // use the keyword "operator" and the operator to declare a custom operator
  // binary operators are declared as static methods that takes two parameters
  // one of the parameters must be of the type of current class, reference to current class, or pointer to current class
  static bool operator==(OtherType^ a1, OtherType^ a2){
    return a1.field1 == a2.field1;
  }
  static bool operator!=(OtherType^ a1, OtherType^ a2){
    return a1.field1 != a2.field1;
  }

  // unary operators are declared as static methods that takes one parameter
  static OtherType operator!(OtherType^ a1){
    a1.field1 = !a2.field1;}
    return a1;
  }

  // conversion operator can be defined for implicit or explicit conversion
  // parameter type must be the type of current class, reference to current class or pointer to current class
  static bool operator implicit(OtherType^ arg1)
  {
    return arg1.field1 == 0;
  }

  static int operator explicit(OtherType^ arg1)
  {
    return arg1.field1;
  }

}

}

```

## Compile Time Classes members ##

In addition to standard class members, compile time classes can define special kinds of members:
  * Default type constructors
  * Parametrized type constructors

Also, compile time classes members can use special types in parameters declaration and return types:
  * `iname` parameters that represent individual identifiers
  * `exp` parameters that represent expression trees
  * `type` parameters that represent an XplType or a type returned by `gettype()` expression.
  * `block` parameter that represent a compound statement (block statement)
  * `iname`, type and exp modifiers can be used in return type

See [Introduction\_to\_Compile\_Time](Introduction_to_Compile_Time.md), [Writing\_compile\_time\_classes](Writing_compile_time_classes.md)