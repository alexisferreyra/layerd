# Compiler Usage #
This page shows how to use LayerD compilers.

## Meta D++ hello world programs ##
This is a hello world program for Meta D++ that targets the .NET framework:
```
import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
using DotNET::System;

namespace Test{
	public class App{
	public:
		static void Main(string^[] args){
			Console::WriteLine("Hola Mundo");
		}
	}
}
```
This is another hello world program for Meta D++ that use a compile time extension to implement the main for .NET:
```
Zoe::ConsoleProgram::New
{
	// Say hello!!
	Console::WriteLine("Hello world!!");
};
```

## Meta D++ compilation ##
To compile a Meta D++ program into a Zoe program use the "metadppc.exe" compiler:

```
C:\LayerD\bin\metadppc.exe helloworld.dpp
```

That will generate a file with the same name but with .zoe extension.<br>
To compile a program composed of more than one file call the compiler for each file:<br>
<br>
<pre><code>C:\LayerD\bin\metadppc.exe helloworld1.dpp<br>
C:\LayerD\bin\metadppc.exe helloworld2.dpp<br>
C:\LayerD\bin\metadppc.exe helloworld3.dpp<br>
</code></pre>

Take into account that this is possible because the program analysis and code generation is implemented in the Zoe compiler and not in the Meta D++ compiler.<br>
<br>
<h2>Zoe Compilation</h2>

When you have the .zoe files of your program you must compile them with "zoec.exe" compiler. If the program is composed of one file:<br>
<code>c:\layerd\bin&gt;zoec.exe HelloWorld.zoe</code>
That will generate an .exe file for .NET platform that is the default platform and module type.<br>
<br>
If the program is composed of more than one file:<br>
<pre><code>c:\layerd\bin&gt;zoec.exe HelloWorld_Source1.zoe HelloWorld_Source2.zoe –pn:HelloWorld<br>
</code></pre>

The parameter "-pn:HelloWorld" set the output filename for the generated module, this is required when more than one file is provided for compilation. If your program is composed of only one file and you don't provide the "-pn" parameter then the filename of the sourcefile will be used for the module name.<br>
<br>
<h2>All steps together</h2>

As you need to run Meta D++ compiler and Zoe compiler to get the executable/library these are all the steps together:<br>
For a program composed of one source file:<br>
<pre><code>c:\layerd\bin&gt;metadppc.exe HelloWorld.dpp<br>
c:\layerd\bin&gt;zoec.exe HelloWorld.zoe<br>
</code></pre>

For a program composed of more than one source file:<br>
<pre><code>c:\layerd\bin&gt;metadppc.exe HelloWorld_Source1.dpp<br>
c:\layerd\bin&gt;metadppc.exe HelloWorld_Source2.dpp<br>
c:\layerd\bin&gt;zoec.exe HelloWorld_Source1.zoe HelloWorld_Source2.zoe –pn:HelloWorld<br>
</code></pre>

Take into account that there will be more than one high level LayerD language (in addition to Meta D++), the Zoe compiler is always used in the same form.<br>
<br>
<h2>Generation of Dynamic libraries (.dll)</h2>

To compile dynamic libraries use the parameter "-lib":<br>
<pre><code>c:\layerd\bin&gt;metadppc.exe HelloWorldLib.dpp<br>
c:\layerd\bin&gt;zoec.exe HelloWorldLib.zoe –lib<br>
</code></pre>

<h2>Compilation of compile time extensions and clients</h2>
Here we show how to compile a classfactory (or what is the same a "compile time extension" or a "compile time class").<br>
First you need to write the classfactory in one or more files, take for example this code that implements a tool to run a block of instructions in parallel (for .NET):<br>
<br>
<pre><code>import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";<br>
using DotNET::System;<br>
using DotNET::System::IO;<br>
using DotNET::System::Collections;<br>
using DotNET::LayerD::CodeDOM;<br>
using DotNET::LayerD::ZOECompiler;<br>
<br>
namespace Zoe::DotNET::Utils{<br>
	// Classfactory to execute concurrent statements on .NET using simple threads<br>
	public factory class Concurrent{<br>
	public:<br>
		// Simple function to execute concurrent statements on .NET<br>
		static exp void ExecuteParallel(block parallelStatements){<br>
			int counter = 0;<br>
			// For each instruction on the argument block<br>
			for(XplNode^ sta in parallelStatements.Children()){<br>
				if(sta.get_TypeName()!=CodeDOMTypes::XplDocumentation){<br>
					counter++;<br>
					// create a random function name<br>
					XplIName^ funcName = new XplIName();<br>
					// create an empty function<br>
					XplFunction^ func = (XplFunction^)writecode{%<br>
					private:<br>
						static void $funcName(){<br>
						}<br>
					%}.Children().FirstNode();<br>
					// insert the statement into the new function<br>
					func.get_FunctionBody().Children().InsertAtEnd(sta);<br>
					// insert the function into current class<br>
					context.CurrentClass.Children().InsertAtEnd(func);<br>
					// create the initialization expression for the thread<br>
					XplExpression^ startExp = null;<br>
					startExp = writecode( new DotNET::System::Threading::Thread(<br>
                                                   new DotNET::System::Threading::ThreadStart( &amp; $funcName ) ).Start() );<br>
					// inject the initialization expression into the current context<br>
					context.CurrentBlock.Children().InsertBefore(startExp, context.CurrentExpression);<br>
				}<br>
			}<br>
			return null;<br>
		}<br>
	}<br>
}<br>
</code></pre>

To compile this file and to add it to the compiler as an extension:<br>
<pre><code>c:\layerd\bin&gt;metadppc.exe MyClassfactory.dpp<br>
c:\layerd\bin&gt;zoec.exe MyClassfactory.zoe –ae<br>
Extension Added: MyClassfactory<br>
</code></pre>
Now to use this new classfactory from a client program, simply write the client program and compile it. The client program:<br>
<pre><code>import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";<br>
using DotNET::System;<br>
// using for new classfactory<br>
using Zoe::DotNET::Utils;<br>
<br>
namespace Test{<br>
	public class App{<br>
	public:<br>
		static void Main(string^[] args){<br>
			// Say hello!!<br>
			Console::WriteLine("Welcome to new semantic structures with LayerD !!");<br>
<br>
			// Run instruction on separated threads<br>
			Concurrent::ExecuteParallel{<br>
				// Count things on one thread<br>
				for(int n=0;n&lt;40000001;n++) if(n%20000000==0)Console::WriteLine("I am on "+n+".");<br>
				// Count other thing on other thread<br>
				for(int n=0;n&lt;40000001;n++) if(n%2000000==0)Console::WriteLine("You are on "+n+".");<br>
			};<br>
<br>
			Console::Read();<br>
		}<br>
	}<br>
}<br>
</code></pre>

How to compile the client program:<br>
<pre><code>c:\layerd\bin&gt;metadppc.exe MyClassfactoryClient.dpp<br>
c:\layerd\bin&gt;zoec.exe MyClassfactoryClient.zoe<br>
</code></pre>

So you don't have to do anything special in order to compile and use compile time extensions (or compile time classes).<br>
<br>
<h2>List and Remove installed extensions on Zoe compiler</h2>
To see a list of installed extensions (classfactorys) on the zoe compiler:<br>
<br>
<pre><code>c:\layerd\bin&gt;zoec.exe –le<br>
ZOE Compiler - Console User Interface.<br>
Installed Extensions: 12<br>
<br>
Type Name, Module File, Interactive, Active<br>
-------------------------------------------------------<br>
Zoe.Utils, .\.\FactoriesLib\ZoeUtilsTemplates1.dll, False, True<br>
Zoe.iUtils, .\.\FactoriesLib\ZoeUtilsTemplates1.dll, True, True<br>
Zoe.Logger, .\.\FactoriesLib\ZoeUtilsTemplates1.dll, False, True<br>
DataSample.MyType, .\.\FactoriesLib\DataSampleTemplates1.dll, False, True<br>
DataSample.GUI, .\.\FactoriesLib\DataSampleTemplates1.dll, False, True<br>
DataSample.iASPNET, .\.\FactoriesLib\DataSampleTemplates1.dll, True, True<br>
DataSample.ASPNET, .\.\FactoriesLib\DataSampleTemplates1.dll, False, True<br>
DataSample.Concurrent, .\.\FactoriesLib\DataSampleTemplates1.dll, False, True<br>
DataSample.ClassGenerator, .\.\FactoriesLib\DataSampleTemplates1.dll, False, True<br>
DataSample.ProgramChecks, .\.\FactoriesLib\DataSampleTemplates1.dll, False, True<br>
DataModel2.Model, .\.\FactoriesLib\DataModelTemplatesPablo1.dll, True, True<br>
DataModel.Model, .\.\FactoriesLib\DataModelTemplates1.dll, False, True<br>
</code></pre>

To remove an installed extension:<br>
<br>
<pre><code>c:\layerd\bin&gt;zoec.exe –re:DataSampleTemplates<br>
Compilador ZOE - Interfaz de Usuario de Consola.<br>
Extension DataSampleTemplates eliminada. Classfactorys eliminadas: 7<br>
</code></pre>

<h2>Compilation for other target platforms (different to .NET)</h2>

If you have the following program that target Java platform:<br>
<br>
<pre><code>// sample import for standard JavaSE packages<br>
import "java.lang", "platform=java", "ns=Java";<br>
import "java.awt", "platform=java", "ns=Java";<br>
import "sun.awt.CausedFocusEvent", "platform=java", "ns=Java";<br>
import "javax.swing", "platform=java", "ns=Java";<br>
// sample import for custom jar files<br>
// import "com.mypackage", "platform=java", "ns=Java", "packagePath=c:/mypackage/dist/mypackage.jar";<br>
<br>
using Java::java::lang;<br>
using Java::java::awt;<br>
using Java::java::awt::event;<br>
using Java::javax::swing;<br>
<br>
namespace EjemploJava{<br>
	class Panel inherits JPanel implements ActionListener<br>
	{<br>
	public:<br>
		JButton^ salir = new JButton("JButton");<br>
		Panel()<br>
		{<br>
			add(new JLabel("Un Label en Meta D++"));<br>
			salir.addActionListener(this);<br>
			add(salir);<br>
			add(new JToggleButton("JToggleButton"));<br>
			add(new JCheckBox("JCheckBox"));<br>
			add(new JRadioButton("JRadioButton"));<br>
		}<br>
		static void Main(string^[] args)<br>
		{<br>
			Panel^ panel = new Panel();<br>
			JFrame^ ventana = new JFrame();<br>
			ventana.getContentPane().add(panel, BorderLayout::CENTER);<br>
			ventana.setSize(300, 200);<br>
			ventana.setTitle("Ejemplo de Java, Swing");<br>
			ventana.setVisible(true);<br>
		}<br>
		void actionPerformed(ActionEvent^ e)<br>
		{<br>
			System::exit(0);<br>
		}<br>
	}<br>
}<br>
</code></pre>

To compile this program write the following on the command line:<br>
<pre><code>c:\layerd\bin&gt;metadppc.exe SampleJava.dpp<br>
c:\layerd\bin&gt;zoec.exe SampleJava.zoe –p:java<br>
</code></pre>

As it's noted you must only add the parameter "-p:java" to the Zoe compiler.