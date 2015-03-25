# Getting the binaries #

## Windows ##
Follow these steps:

  1. Checkout the source code
  1. Open the LayerD.sln solution file with Visual Studio 2010
  1. Build the solution

You will find the binaries for Meta D++, Zoe Compiler and all supported code generators in the folder `trunk\layerdxplc_net\bin` in debug or release folder depending the configuration used to build.

## Linux ##

To build LayerD in Linux you will need to install Mono.
Current version is not fully tested under Linux but it should work with a bit of effort.

  1. Compile metadppc parser using make (folder `trunk\layerddpp`)
  1. Build Zoe compiler using mono build system

# LayerD CodeDOM Documentation #

CodeDOM documentation is an in-progress work. But it will be needed to write compile time classes that transform the AST or interact with Zoe Core.

To create the CodeDOM doc use doxygen

  1. Move into the trunk folder
  1. Call `doxygen` in the command line

The CodeDOM documentation will be accessible in `trunk\doc\html\index.html`