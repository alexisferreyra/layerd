## Introduction ##
The inheritance in Meta D++ is similar to the inheritance in C#. Classes can inherit from other classes and interfaces can inherit from other interfaces. To declare a class or interface that inherits from a base class or interface the keyword `inherits` must be used.

For example:
```
namespace Example
{
  public class A inherits B
  {
     ...
  }
  
  public interface C inherits D
  {
     ...
  }
}
```

Meta D++ supports both, simple and multiple inheritance.

Like C# inheritance, all inherited members are, by default, non-virtual unless you define it as `virtual` in base class (with `virtual` modifier). In order to override a member you need to declare it as `virtual` in base class and use the keyword `override` in the derived class.

To mark a member like a new implementation that can hide an inherited member use the keyword `new`.

To mark a member so it can't be overridden by derived classes use the keyword `final` in the member declaration.

You can define an instance method, property or indexer as abstract by using the keyword `abstract` and not providing implementation body.

**Note:** for platforms like Java where methods are by default virtual, a warning will be shown to point out that the method is going to be `virtual` anyway. In this case, you should use `non-virtual` modifier to force that the method won't be virtual and a compilation error will be issued if the Zoe Code Generation module can warranty non-virtuality of member.

## Inheritance between Classes ##
### Ordinary classes ###
Ordinary classes follow the logic of traditional inheritance that allows us (in OOP) to do `polimorfism`.

Example:

```
namespace Example{
  
  class Animal {
    
      string^ name;
    
    public:
      // method that can be overridden in derived class
      virtual string^ iDo(){
        return "Nothing";
      }
      final void NonOverridableMethod(){
         // do something
      }
  }
  
  public class Dog inherits Animal {
    
      bool IamSomeOnePet;
    
  public:
      Dog()
      {
        this.name = "";
        this.IamSomeOnePet = false;
      }
    
      Dog(string^ name)
      {
        this.name = name;
        IamSomeOnePet = true;
      }
    
      override string^ iDo(){
        return "My name is" + name + "and I do: Guau!";
      }
  }
}

```

### Compile Time classes ###

The inheritance between compile-time classes works identically as for the ordinary classes and means the same concept. However, inheritance of a ordinary class from a compile-time class means something different that the usual concept of `inheritance` we are used to manage. An inheritance between a ordinary class and a compile-time class means that at compile time the type constructor of the compile-time class will be called replacing the name of the compile-time class with the name of the type provided by the type constructor of the compile-time class .

Example:

```
factory class A {}
factory class B inherits A {}
```

In this case, the compile-time class B inherits from compile-time class A.

But, in this case:

```
class SimpleClass inherits A {}
```
Considering that `A` is the compile-time class that we defined before, this means that, at compile time the `Simple Class` will inherit from the type that the type constructor  of the compile-time class A returns.

The final version of `Simple Class` (after compile time) would look like this:

```
class SimpleClass inherits XNewType {}
```

XNewType is the type returned by the type constructor of the compile-time class.

Another consideration regarding inheritance between compile-time classes  is that ordinary compile-time classes can not inherit from interactive compile-time classes while interactive compile-time classes can inherit from the ordinary ones.

## Inheritance between Interfaces ##
As we saw above, interfaces can inherits from other interfaces. Something that must be take into account is that if a class implements an interface that inherits from other interface, then, the class must implements the methods of the implemented interface and its parent's methods too.

For example:

```
namespace Example{

  public interface Behaviour
  {
    string^ commonBehaviour();
  }
  
  public interface SpecificBehaviour inherits Behaviour
  {
    string^ mySpecificBehaviour();
  }
  
  public class MyClass implements SpecificBehaviour
  {
    public string^ commonBehaviour()
    {
      return "I do";
    }
    
    public string^ mySpecificBehaviour()
    {
      return "Some particular action";
    }
  }
}
```