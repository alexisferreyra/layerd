# Introduction #

Although this guide is intended to show all topics related to LayerD programming, most of it is focused in one high level LayerD language that is Meta D++ programming language.

Meta D++ is mostly based in C++ and C# regarding syntax and semantic but extended with LayerD features like compile time classes, source code introspection, compiler interface at compile time, multiple compile time stages, etc.

Take into account that to have a working program in LayerD, using Meta D++, you must follow these steps:
  1. compile your Meta D++ source files with Meta D++ parser
  1. compile all resulting Zoe files with Zoe Compiler to generate the target artifact

Also, remember that Zoe compiler is modular and can generate native code for multiple platforms like .NET, Java or Native binary.
