# Introduction #

Using compile time introspection infrastructure it's possible to design and implement your own textual Domain Specific Languages directly in Zoe that can be used from Meta D++ source code.
Following code shows a DSL to write Windows Forms user interfaces:

```
namespace T{

  // DSL to build GUIs
  // defines a window with a button that close the window
  // when the button is clicked
  GUI::Window(MiVentana3){
    Text = "A window with a LayerD DSL for Windows Forms";
    Controls{
      Button(CSalir){
        Text="Exit"; AutoSize=true;
        Click {
          this.Close(); 
        };
      };
    };
  };

  // can be directly mixed with other Meta D++ code
  class Run{
  public:
    static void Main(string^[] args){
      Application::EnableVisualStyles();
      Application::Run(new MiVentana2());
    }
  }

}
```

To define your own DSL you use compile time infrastructure from Zoe, and the ability of Meta D++ to take expressions and blocks of code as arguments of compile time functions. Additionally the is a special method call that allows additional freedom in defining your DSL.

The code to implement that Windows Form DSL is like this:

```
/*

  Meta D++ sample.

  Implementation of DSL for .NET Windows Forms.

  Visit http://layerd.net and http://layerd.blogspot.com to get updates of LayerD SDK and documentation.
  
*/
import "System", "platform=DotNET", "ns=DotNET", "assembly=mscorlib";
using DotNET::System;
using DotNET::System::IO;
using DotNET::System::Collections;
using DotNET::LayerD::CodeDOM;
using DotNET::LayerD::ZOECompiler;

namespace Zoe::DotNET::Utils{

  //
  // Classfactory that implements a DSL for Windows Forms in .NET.
  //
  public factory class GUI{
    static void RenderControl(XplNode^ controlDef, XplFunction^ constructor, XplExpression^ containerExp, XplClass^ containerClass)
    {
      if(controlDef.get_TypeName()!=CodeDOMTypes::XplExpression)return;

      XplExpression^ leftExp = null;
      XplExpression^ rigthExp = null;
      XplExpression^ resExp = null;
      XplType^ claseControl = new XplType();
      claseControl.set_typename(controlDef.FindNode("/n").get_StringValue());
      XplExpression^ nombreControl = (XplExpression^)controlDef.FindNode("/e/n");
      XplNodeList^ blockInfo = ((XplFunctioncall^)controlDef.get_Content()).get_bk().Children();
      
      // Declare field
      XplField^ fieldDecl = (XplField^)writecode{%
        $claseControl^ nombreControl = new $claseControl();
      %}.Children().FirstNode();
      fieldDecl.set_name(nombreControl.FindNode("/n").get_StringValue());
      containerClass.Children().InsertAtEnd(fieldDecl);
      
      // Add item to container
      resExp = writecode( $containerExp.Controls.Add($nombreControl) );
      constructor.get_FunctionBody().Children().InsertAtEnd(resExp);

      for(XplNode^ node in blockInfo)
      {
        if (node.get_Content() == null) continue;

        if (node.get_Content().get_TypeName() == CodeDOMTypes::XplAssing)
        {
          // It's a property
          leftExp = ((XplAssing^)node.get_Content()).get_l();
          rigthExp = ((XplAssing^)node.get_Content()).get_r();
          resExp = writecode( $nombreControl.$leftExp = $rigthExp );
          constructor.get_FunctionBody().Children().InsertAtEnd(resExp);
        }
        else 
        {
          if (node.get_ElementName() == "e" && node.get_Content().get_ElementName() == "fc" &&
              node.FindNode("/n").get_StringValue() == "Controls")
          {
            XplNodeList^ list = ((XplFunctioncall^)node.get_Content()).get_bk().Children();
            for(XplNode^ node2 in list)
            {
              RenderControl(node2, constructor, writecode( $nombreControl ), containerClass);
            }
          }
          else {
            if (node.get_ElementName() == "e" && node.get_Content().get_ElementName() == "fc")
            {
              // it's an event for the control 
              XplFunctionBody^ eventLogic = ((XplFunctioncall^)node.get_Content()).get_bk();
              XplExpression^ eventName = ((XplFunctioncall^)node.get_Content()).get_l();
              XplFunction^ eventFunction = (XplFunction^)writecode{%
                void eventFunc(object^ sender, EventArgs^ e)
                {
                  $eventLogic;
                }
              %}.Children().FirstNode();
              eventFunction.set_name(fieldDecl.get_name() + "_" + eventName.get_Content().get_StringValue());
              containerClass.Children().InsertAtEnd(eventFunction);
              XplExpression^ addEventFuncName = null;
              addEventFuncName = writecode( id );
              addEventFuncName.get_Content().set_Value("add_" + eventName.get_Content().get_StringValue());
              XplExpression^ addEvent = null;
              eventName.get_Content().set_Value(eventFunction.get_name());
              addEvent = writecode( $nombreControl.$addEventFuncName(new EventHandler(&this.$eventName)) );
              constructor.get_FunctionBody().Children().InsertAtEnd(addEvent);
            }
          }
        }
      }
    }
    
  public:
    static exp void Window(block info)
    {
      return Window(new XplIName(), info);
    }
    static exp void Window(iname void className, block info)
    {
      // get simple name
      className.Identifier = ZoeHelper::GetSimpleNameFromQualified(className.Identifier);
      
      XplExpression^ thisExp = null;
      thisExp = writecode( this );
      XplClass^ claseVentana = writecode{
        private class $className inherits Form{
        public:
          // Create the class for main window
          $className() { }
        }
      };
      
      for(XplNode^ node in info.Children())
      {
        XplExpression^ leftExp = null;
        XplExpression^ rigthExp = null;
        XplExpression^ resExp = null;
        if (node.get_ElementName() == "e" && node.get_Content().get_ElementName() == "a")
        {
          // it's a property
          leftExp = ((XplAssing^)node.get_Content()).get_l();
          rigthExp = ((XplAssing^)node.get_Content()).get_r();
          resExp = writecode( this.$leftExp = $rigthExp );
          constructor.get_FunctionBody().Children().InsertAtEnd(resExp);
        }
        if (node.get_ElementName() == "e" && node.get_Content().get_ElementName() == "fc" && 
            node.FindNode("/n").get_StringValue() == "Controls")
        {
          // process child controls
          XplNodeList^ list = ((XplFunctioncall^)node.get_Content()).get_bk().Children();
          for(XplNode^ node2 in list)
          {
            RenderControl(node2, constructor, thisExp, claseVentana);
          }
        }
      }
      
      // if class already exists, add members to existing class. Otherwise, add the new class
      XplClass^ backClass = (XplClass^)context.CurrentNamespace.FindNode("/@XplClass[name='" + claseVentana.get_name() + "']");
      if (backClass != null)
      {
        backClass.Children().InsertAtEnd( claseVentana.Children() );
      }
      else
      {
        context.CurrentNamespace.Children().InsertAtEnd(claseVentana);
      }
      // return null to remove compile time function call
      return null;
    }
  }
  
}

```

More complex DSL can be created using complex function calls

```

       str = Markup::XML(''
        table(id = "miClase", background = "black", comment = strA + "-" + strB):
          tr: td["Nombre"] td["Apellido"] ;
          tr: td[strA] td[strB] ;
          tr: td[strB] td[strA] ;
          tr: td["Juan"] td["Gonzalez"] ;
          tr: td["Gustavo"] td["Lopez"] ;
          tr: td["Daniel"] td["Perez"] ;
          tr: td["UTN"] td["FRC"] ;
        ; 
      '');  

      // complex function calls use a special syntax "foo('' arguments here '')"
      // where arguments is a sequence of expressions list and punctuators ; or : 
      // like: arg1 + arg2, arg3 : : : ; ; ; arg2: arg2(1,2) ;
      // because expressions can take normal function call form like "foo(arg1){blockArg;}"
      // it's possible to design complex DSL that are constructed from syntax primitives of
      // Meta D++ language

      var result = SQL::Query(''
        Select( name, address ), 
        From ( customers ), 
        Where {
           name="A*" && address="C*" ;
        }
      '');

      // because, all DSL are implemented by transformation and analysis done at 
      // compile time by ordinary classes, you can combine any number of DSL
      GUI::Window(QueryWindow){
        Text = "Results of query here";
        Width = 800; Height = 600;
        Controls{
          Label(queryResult){
            Top = 10; Left = 10;
            Width = 780; Height = 500;
          };
          Button(run){
            Top = 520; Left = 320;
            Text = "Query"; AutoSize = true;
            Click {
               Query^ result = SQL::Query(''
                 Select( name, address ), 
                 From ( customers ), 
                 Where {
                    name="A*" && address="C*" ;
                 }
               '');
               this.queryResult.Text = result.ToString();
            };
          };
        };
      };

```

Textual DSL are very powerful, allowing a perfect integration with standard engineering tools for version control, code revision, etc.
With the flexibility of running and checking DSL at compile time it's possible to follow useful programming paradigms like language oriented programming.