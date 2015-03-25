## What is a Compile Time Class? ##
A Compile Time Class (CTC) is a special kind of class that can be added to the compiler like a "plug-in". Then, the compiler when you compile an ordinary class (OC) will take the logic of the CTC into account to produce the final code of the OC. But, of course, to do this you need to make a call to the CTC in the ordinary one. During the compilation of a program is possible to access to the program's code that is being compiled (reflection at compile time ) either to modify or analyse it (if the CTC has the needed permissions). For this reason, the CTCs can use special types of data and objects.

## Utility of CTCs ##

The CTCs can be used for:

  * Generating real cross-platform software without incurring in loss of performance. For example, you can build programs that compile without changes for .NET, Java and other platforms that are available. This can be done using CTCs for API Encapsulation.
  * Creating new semantic structures: using compile-time and special accessible types is possible to implement new semantic structures for high-level languages without relying on language designers or manufacturers of compilers.
  * Programming natively RAD tools: is possible to program RAD tools that can run in the compiler and are applicable to more than one high-level language. Running these tools inside the intermediate Zoe compiler made them independent of the programming environment used.
  * Extending dynamically the compiler: the intermediate Zoe compiler, being programmable its 'compile-time' and having full reflection of the code being compiled, allows to programme extension modules to add new functionality to the compiler, from new semantic structures to the incorporation of domain specific languages, or the massive generation of code.

Examples of thing you can do with CTCc: code generators, domain-specific languages, code snippets, active libraries, API encapsulation, static code analysis, code refactoring, etc. To sum up, is possible to do whatever you would imagine, considering the possibility of analysing and modifying source code at compile-time.

## Working with CTCs ##
CTCs are used for analyse, generate and modify source code of a client class which uses it services.

For analyzing the source code, the CodeDOM classes are used combined with a certain logic to determinate if the code is correct regarding a condition that wants to be proved.

There are three ways of generating the code in memory:

  1. Using the classes within the namespace LayerD::CodeDOM (or DotNET::LayerD::CodeDOM for current implementation of Zoe compiler)
  1. Using the "writecode" expression
  1. Using a combination of the above.

Usually you'll find useful to combine the first two ways of generating code. It is common to mostly use the expression "writecode" to generate the bulk of the code and CodeDOM classes to complement.

For modifying code at compile-time these two simple steps must be followed:

  1. Generate in memory the code that you wants to inject.
  1. Insert the code into the memory at the desired location within the program code being compiled.

For modifying code you need to inject the generated code in the source code which with you're working. Or you can modify it returning expressions from a CTC function call.

For this to be done, you must master special objects used by Zoe compiler that we'll see further.