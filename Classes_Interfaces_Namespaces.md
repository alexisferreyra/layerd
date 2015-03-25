## Namespaces ##
The declaration and use of namespaces is similar to C#.
```
namespace SampleNamespace
{
	public class A
	{
          int field1; // members are private by default
	public:
          void fooPublicFunction(int arg1, int arg2){
            // do something
          }
          int property Integer{
             get{ return this.field1; }
             set{ this.field1 = value; }
          }
        protected:
          void protectedFunction(){ }
        private:
          int otherPrivateField;
	}
	
	...
}
```

User-defined types such as classes, enums, interfaces, etc. must always be declared inside a namespace. It's not allowed to declare a class, struct, enum or function outside namespaces. You can have compile time function calls outside namespaces, like:

```

// call to compile time function outside namespaces, classes are allowed

MyClassfactory::MyFunc("Hello"){
  // this is a block argument to static function MyFunc
  // do something here
};

namespace T{
  class A{
  }
}

/* NOT ALLOWED CLASSES OUTSIDE NAMESPACES

class OutsideNamespace{
}

*/

```

## Classes ##
Classes in Meta D++ are declared similar to C# and Java.
Nevertheless, there are some special modifiers for MetaD++.
Let's see a generic definition of a class:

```
[Class_Decl_Mods_opt] class [Identifier] inherits [Base_List_opt] implements [Implement_List_opt]
{ 
   Class_Decl_Block_opt 
}
```

There can be more than one modifier defining the class, each one related to some aspect of the class.
<br><br>
<b>References:</b>
<table><thead><th> <b><code>[Class_Decl_Mods_opt]</code></b> </th><th> modifiers used to defined different aspects of the class. The order of the modifiers doesn't matter. </th></thead><tbody>
<tr><td> <b><code>[Identifier]</code></b> </td><td> the name of the class </td></tr>
<tr><td> <b><code>[Base_List_opt]</code></b> </td><td> the class or classes from which it inherit </td></tr>
<tr><td> <b>class</b> </td><td> the reserved word for defining a class </td></tr>
<tr><td> <b>inherits</b> </td><td> the reserved word for pointing out that the class inherits from other class </td></tr>
<tr><td> <b>implements</b> </td><td> the reserved word for pointing out that this class implements one or more interfaces. </td></tr></tbody></table>

<br>

<h3>Modifiers</h3>
<b>Access Level Modifiers</b>

MetaD++ supports the following access level modifiers<br>
<br>
<table><thead><th> <b>Modifier</b></th><th> <b>Description</b></th></thead><tbody>
<tr><td>public</td><td>Allow global and unlimited access to the class and can be used for high level classes as well as for nested classes.</td></tr>
<tr><td>private</td><td>As default if there's no access level modifier specified on the class definition. It's the more restrictive of all access level modifiers, for high level classes the access to the class  is restrict to the namespace that contains the class and for the nested classes the access to the class is limited to the container-class exclusively</td></tr>
<tr><td>protected</td><td>Only valid for nested classes and limits the access to the class to the container-class and its derivated classes.</td></tr></tbody></table>

<b>Compile Time Class Modifiers</b>

These modifiers determinate what kind of compile time class (CTC) a class is. Basically be can have two types of CTCs.<br>
<br>
<table><thead><th> <b>Modifier</b></th><th> <b>Description</b></th></thead><tbody>
<tr><td>factory</td><td>Used to specify that this class is a Compile Time Class</td></tr>
<tr><td>interactive</td><td>Used to specify that this class is an interactive Compile Time Class</td></tr></tbody></table>

<b>Abstract Modifier</b>

<table><thead><th> <b>Modifier</b></th><th> <b>Description</b></th></thead><tbody>
<tr><td>abstract</td><td>The abstract modifier establishes that a class can be only used as a base class for other classes or like a type of pointer but it can't be instantiated under any condition.</td></tr></tbody></table>

<b>Final Modifier</b>

<table><thead><th> <b>Modifier</b> </th><th> <b>Description</b></th></thead><tbody>
<tr><td>final</td><td>Classes marked as final can't be inherited in any model of inheritance.</td></tr></tbody></table>

<b>Extern Modifier</b>

<table><thead><th> <b>Modifier</b> </th><th> <b>Description</b></th></thead><tbody>
<tr><td>extern</td><td>Establishes that the method is implemented externally. It is an error to use the abstract and extern modifiers together to modify the same member. Using the extern modifier means that the method is implemented outside the Meta D++ code, while using the abstract modifier means that the method implementation is not provided in the class. Because an external method declaration provides no actual implementation, there is no method body; the method declaration simply ends with a semicolon and there are no braces ({ }) following the signature.</td></tr></tbody></table>

<b>Extension Modifier</b>

<table><thead><th> <b>Modifier</b> </th><th> <b>Description</b> </th></thead><tbody>
<tr><td>extension</td><td>Used to declare an extension of classfactory.</td></tr></tbody></table>

<b>New modifier</b>

<table><thead><th> <b>Modifier</b> </th><th> <b>Description</b> </th></thead><tbody>
<tr><td>new</td><td>In nested classes it is used to explicit a hiding of a member of a class and avoid compiler warnings.</td></tr></tbody></table>


<h3>Structs</h3>

It is possible to declare "structs" too, using the "struct" modifier instead of "class".<br>
<br>
For example:<br>
<pre><code>namespace Example{<br>
  public struct MyStruct<br>
  {<br>
     int x;<br>
     int y;<br>
     string^ name;<br>
  }<br>
}<br>
</code></pre>
Classes and structs are represented with the same CodeDOM class: XplClass.<br>
Structs represent classes that in certain runtimes can be stored in the stack and passed by value as in .NET runtime o native code.<br>
Use structs for types that you expect to be stored in the stack or passed by value in certain runtimes. An instance from a  class can't be passed as value or stored in the stack in some runtimes.<br>
<br>
<h2>Enums</h2>

Enums works the same than in C# language. To declare an enum use:<br>
<br>
<pre><code>namespace Example{<br>
<br>
  public enum Countries{<br>
    UnitedStates,<br>
    Mexico = 3,<br>
    Argentina,<br>
    Spain<br>
  }<br>
<br>
}<br>
</code></pre>

To use/reference an enum you can use the enum type for variable types and you use the qualified name to refer to enum constants like:<br>
<br>
<pre><code><br>
void foo(Countries arg){<br>
<br>
  if(arg == Countries::Argentina){<br>
    Console::WriteLine( "Hello Argentina!!" );<br>
  }<br>
<br>
}<br>
<br>
</code></pre>

You can cast an enum to an integer by using explicit casting <code>(int)Countries::Mexico</code>

<h2>Interfaces</h2>

The use of interfaces is similar to C# or Java.<br><br>
The reserved word for declaring is "interface"<br>
<br>
<pre><code>namespace Example{<br>
  public interface iBehaviour()<br>
  {<br>
    string^ responseToSomething();<br>
  }<br>
}<br>
</code></pre>

The reserved word for using it is "implements"<br>
<pre><code>namespace Example{<br>
  public class specificBehaviour implements iBehaviour<br>
  {<br>
    string^ responseToSomething(){<br>
      // specific implementation <br>
    }<br>
  }<br>
}<br>
</code></pre>

It's possible to implement multiple interfaces separating each implemented interface with comma. For example:<br>
<br>
<pre><code>namespace Example{<br>
  public class multipleBehaviour implements iBehaviour, iBehaviour2, iBehaviour3<br>
  {<br>
     //. . . -&gt; And here the specific implementation of the interfaces methods<br>
  }<br>
}<br>
<br>
</code></pre>

Classes that implement an interfaces must provide (by inheritance or by themselves) an implementation for each function and property declared in the interface. That is, must provide implementation for functions with the same signature than the ones declared in the interface (name, arguments and return types).