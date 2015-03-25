# Meta D++ #


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

Save the file as HelloWorld.dpp and compile:

```
c:\layerd\bin>metadppc.exe HelloWorld.dpp
c:\layerd\bin>zoec.exe HelloWorld.zoe
```

## Java ##

Sample hello world program in Meta D++ language targeting Java SE runtime.

Meta D++ source code:
```
// sample import for standard JavaSE packages
import "java.lang", "platform=java", "ns=Java";
import "java.awt", "platform=java", "ns=Java";
import "sun.awt.CausedFocusEvent", "platform=java", "ns=Java";
import "javax.swing", "platform=java", "ns=Java";
// sample import for custom jar files
// import "com.mypackage", "platform=java", "ns=Java", "packagePath=c:/mypackage/dist/mypackage.jar";

using Java::java::lang;
using Java::java::awt;
using Java::java::awt::event;
using Java::javax::swing;

namespace EjemploJava{
    class Panel inherits JPanel implements ActionListener
    {
    public:
        JButton^ salir = new JButton("JButton");
        Panel()
        {
            add(new JLabel("Hello World from Meta D++"));
            salir.addActionListener(this);
            add(salir);
            add(new JToggleButton("JToggleButton"));
            add(new JCheckBox("JCheckBox"));
            add(new JRadioButton("JRadioButton"));
        }
        static void Main(string^[] args)
        {
            Panel^ panel = new Panel();
            JFrame^ ventana = new JFrame();
            ventana.getContentPane().add(panel, BorderLayout::CENTER);
            ventana.setSize(300, 200);
            ventana.setTitle("Java sample with Swing");
            ventana.setVisible(true);
        }
        void actionPerformed(ActionEvent^ e)
        {
            System::exit(0);
        }
    }
}
```

Save as "SampleJava.dpp" and compile this program write the following on the command line:

```
c:\layerd\bin>metadppc.exe SampleJava.dpp
c:\layerd\bin>zoec.exe SampleJava.zoe –p:java
```