# `JavaScript` Code Generator's Limitations #

You can write almost any kind of `JavaScript` in Meta D++. But, we have some limitations.
This is what you can't do in Meta D++:

  * **Implement global functions or objects**: because Meta D++ promotes the use of namespaces and classes, it avoids having global objects and functions. For now, you can't write code at `JavaScript's` global scope. If you really, really need to write global scope things, you can always write JS code and import that into Meta D++ by providing type definition for the external code and importing using import directive.

  * **Using dollar character in identifiers**: Meta D++ lexical definition does not allow to use $ in identifiers, so you can't use that in identifiers. Still, you can use the special static member "js::global::S" to access the global JS symbol "$" in external libraries. Still, it is recommended to use things like `jQuery` instead of `$` (that in Meta D++ will be `js::global::S`).

  * **Unions and pointer arithmetic**: those Meta D++ features are not supported by the code generator. So, avoid using them in programs that will target `JavaScript`. Simple pointers, used to pass by reference parameters are supported. But more complex interaction like pointer increment of additions are not.

  * **Enumeration, Properties and operator overloading**: Meta D++ enumerations, properties and operator overloading are not supported. But that will be added in the future.

  * **Meta D++ native classes like `zoe::lang::String` are not mapped**: the few native classes are not yet mapped to `JavaScript`. You can use native `JavaScript` classes like `js::String`, `js::Date`, etc. instead. Intrinsic types like `int` or `double` are supported. You can use Meta D++ native classes, but will need to provide the implementation in `JavaScript`.

# FAQ #

**I do not like the code generated for classes and inheritance, what can I do?**

You can always fork the Zoe `JavaScript` Code Generator. It's basically a pretty printer that you should be able to easily customize.
In the future, we may provide a standard way to customize the generated code.

**I want to use other `JavaScript` libraries. Is that possible?**

Yes off-course Sir!, you have to provide a file with external types definition and provide a simple import clause like the ones [here](https://code.google.com/p/layerd/wiki/Programming_Javascript).
Remember that you only need to provide type definition for the things that you use. It's not needed to have full types definition!

**What can I use to debug JS programs written in Meta D++?**

Any debugger like Chrome Tools or Mozilla will work. But take into account that you will be debugging the generated JS. Still, the generated code is really, really, readable.

You can help us implementing source mappings into the code generator!

**I want to add objects and types definition to special `js::global` class. But, I wan't to do that in a separate file from common externs.**

You can use Meta D++ `extension` classes for that. Provide a class like this one:
```
namespace js
{
   public extern extension class global
   {
   public:
      // .... additional definitions here ....
   }
}
```

**Which editor/IDE can I use to write Meta D++ programs?**

You can use anything you like like `vi`, `notepad++`, `eclipse` any text editor will work. We recommend using some text editor with syntax highlighting. And setup the syntax to C# or C++, that should work most of the time.

_TODO : write an IDE for Meta D++ and Zoe._