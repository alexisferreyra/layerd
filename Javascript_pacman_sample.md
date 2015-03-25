# Pacman Mini-Game Using Canvas #

Here we describe a simple mini-game implemented 100% using Meta D++.

You can download the code and `JavaScript` compilation of this sample from `trunk\samples\pacman`.

Try the mini-game here https://googledrive.com/host/0B6YUCBp4Z-wOdXBzeWcyZU1mb00/pacman.html

<img src='https://layerd.googlecode.com/svn/wiki/img/pacman-screen.png' />

## Project structure ##
The project is composed of following files:

| **File** | **Description** |
|:---------|:----------------|
| `lib\classy.js` | This file contains the implementation of classes and inheritance handling in `JavaScript`. You can find this file in the binaries inside `outputmodules\js_lib`. |
| `lib\zoe.base.js` | This file contains the minimal dependencies required by the `JavaScript` code generator. You can find this file in the binaries inside `outputmodules\js_lib` or use your own implementation for the few functions here. |
| `Makefile` | Makefile to automate building. Not really required, but will make your life easier. Meta D++ and Zoe intermediate language do not provide custom build systems. You can use any build system you want. |
| `pacman.css` | Simple CSS code to remove margins and setup of background color. |
| `pacman.dpp` | This file is used to "include" all other files and isolate import directives. |
| `pacman.controller.dpp` | The controller object for the mini game. It contains the main function. |
| `pacman.map.dpp` | Class for map handling and drawing. |
| `pacman.actor.dpp` | Base class for actors in the mini game. |
| `pacman.soul.dpp` | Base class for pacman actors. |
| `pacman.bad.dpp` | Implementation for "bad" pacman. It provides a function to automatically moves the pacman. |
| `pacman.good.dpp` | Simple class to implement a custom moved pacman |

## `JavaScript` dependencies and main imports ##
Code generated for `JavaScript` depends with only two files:
  * lib\classy.js
  * lib\zoe.base.js

These are the only dependencies introduced by the code generator. All code generated is standard `JavaScript` and do not include other dependencies besides those two small files.

You can even customize the content of `zoe.base.js` or provide your own implementation for functions that are used to declare `namespaces`, special start-up function `$$main` and `truncate` function.
If you don't like Classy implementation of inheritance and classes you can provide your own. As long as it respect the interface used by the code generator.

Inside `pacman.dpp` you will find these two imports that are needed in all Meta D++ projects that aims to generate `JavaScript` code:
```
import "./lib/classy.js", "platform=JavaScript", "type=script", "outputsubfolder=lib", "copy=true";
import "./lib/zoe.base.js", "platform=JavaScript", "type=script", "outputsubfolder=lib", "copy=true";
```

You can find more information about imports specific to `JavaScript` target platform [here](https://code.google.com/p/layerd/wiki/Programming_Javascript).

Following the `JavaScript` specific imports you will find the following import:

```
import "default.externs.zoe";
```

That is include to provide type information for `JavaScript` objects and functions. You can use any .zoe file (generated from any Meta D++ file).

You can find more information about writing external types [here](https://code.google.com/p/layerd/wiki/Programming_Javascript).

Finally, we have the imports related to our mini-game:
```
// my project imports
import "./pacman.css", "platform=JavaScript", "type=stylesheet", "copy=true";
import "pacman.controller.zoe";
import "pacman.map.zoe";
import "pacman.actor.zoe";
import "pacman.soul.zoe";
import "pacman.bad.zoe";
import "pacman.good.zoe";
```

The first one, is to generate a `<link />` element in the generated `index.html`. The following imports are the program. It's a common practice to use one .dpp file to include all the import directives, related to importing types from the target platform, or setting code generator parameters. That's is useful because import directives are global to the program.

## Main function ##
The entry point for the program is in `pacman.controller.dpp`.
The relevant code is:
```
using js;
using js::global;

namespace game
{    
    class Controller
    {
        HTMLCanvas^ _canvas;
        HTMLCanvasContext^ _context;
        PacmanSoul^ _pacman;
        PacmanSoul^ _badPacman;
        
    public:
        static int Main()
        {
            new game::Controller().run();
            console::log("HTML5 Pacman Started!");
        }
        void run()
        {
        /* ... more code here ... */
    }
}
```

All external types from `JavaScript` runtime must be declared inside `js` namespace. So, it's common to include a few using directives to avoid writing the prefix every time.
In the main function, we just create a Controller object and call `run` method.

## Setting timers for events and drawing ##
To handle the state update and drawing of the mini game we use the `setInterval` function.
It is called in `run` method in `pacman.controller.dpp` like here:
```
// render timer
global::window.setInterval(Func{
    map.renderAround(this._pacman.row(), this._pacman.column());
    map.renderAround(this._badPacman.row(), this._badPacman.column());
    
    this._pacman.updateAnimation();
    this._pacman.render();
    this._badPacman.updateAnimation();
    this._badPacman.render();
}, 1000 / 60);
```

Note that to call JS global objects you have to use `global::OBJECT`. The same is true for global functions in JS. Also, remember that you must provide the type definitions so Meta D++ can check the types at compile time. Type information for this project is provided in `default.externs.dpp` but you can use any .dpp file, even the same file with your code, but it is recommended to handle external definitions in a separated file.

Note the `Func` used to provide the closure. You can read more about closures [here](https://code.google.com/p/layerd/wiki/Closures). Closures using `Func` are translated into native `JavasScript` closures.


## Using `JavaScript` DOM ##
To use `JavaScript` DOM you just use the same classes and object that you will use in JS. The main difference is that you will need to write the type information in the extern file.
For example, lets take a look to function `renderBody` in `pacman.controller.dpp`:
```
void renderBody()
{
    this._canvas = (HTMLCanvas^)global::document.createElement("canvas");
    this._canvas.width = global::window.innerWidth;
    this._canvas.height = global::window.innerHeight;
    
    this._context = this._canvas.getContext("2d");
    HTMLElement^ mainDiv = global::document.getElementById("main-page");
    mainDiv.appendChild(this._canvas);
    
    this._context.setFillColor("#000");
    this._context.fillRect(0 , 0, this._canvas.width, this._canvas.height);
}
```

We use global `document` object and standard functions as you will in JS. In order to use the predefined types and functions in certain JS runtime you must declare the extern types like in `default.externs.dpp`. Sample extern type definitions:
```
public extern class HTMLElement inherits js::Object
{
public:
    js::String*ref innerHTML;
    js::Function*ref onclick;
    /* .... */

    double offsetWidth;
    double offsetHeight;
    js::String*ref className;

    js::String*ref getAttribute(js::String*ref key);
    void setAttribute(js::String*ref key, js::String*ref value);
    js::CSSStyleDeclaration*ref style;
    void appendChild(HTMLElement*ref arg1);
    /* .... */
}
```
Fortunately, you just have to write these definitions only once. And only types used in your program are needed. If you do not use something, then you don't need to provide with declarations. Also, you can borrow some extern definition from the Internet.

## Handling events ##
Events in `JavaScript` are handled just using callbacks by providing functions references or closures. In Meta D++ is the same.
Take a look at the code in `run` method inside `pacman.controller.dpp`. To handle `keyup` event:
```
global::window.onkeyup = Func(event is DOMEvent^){
    // up
    if(event.keyCode == 38)
    {
        this._pacman.changeDirection(Actor::Up);
        event.preventDefault();
    }
    // ...
};
```
You just assign the `onkeyup` property with a closure. Note that you have to provide the type information for the arguments in order to use the methods of event.

## Using `JavaScript` native Object and Array ##
To use native JS arrays and objects you just can use the external classes `js::Object` and `js::Array`.
In typical extern definitions you will have something like:
```
extern public class Object
{
public:
    Object(params object*ref[] args);

    js::Object*ref indexer(object*ref name)
    { 
        get;
        set;
    }
    // ....
}
extern public class Array inherits js::Object
{
public:
    // Constructors
    Array(params object*ref[] args);
    // properties & methods
    int length;
    js::Array*ref concat(js::Array*ref[] args);
    js::Array*ref concat(params js::Array*ref args);
    js::String*ref join(js::Object*ref separator);
    js::Object*ref pop();
    int push(js::Object*ref arg1, params object*ref[] args);
    void reverse();
    js::Object*ref shift();
    js::Array*ref slice();
    js::Array*ref slice(int start);

    // ....
}

```
We recommend starting the extern definition from the one provided with the binaries.

When you use `js::Object` and `js::Array` constructors the code generator will generate special code, as you will in native JS.

For example, take a look at the code in `pacman.map.dpp`, function `fillMap`:
```
virtual void fillMap()
{
    this._map = new Array(
        new Array( W, W, W, W ),
        new Array( W, F, B, W ),
        new Array( W, B, F, W ),
        new Array( W, W, W, W ),
    );
}
```

The call to `new Array` - `js::Array` if you don't provide the using directive - will be compiled in `JavaScript` into:
```
fillMap: function(){
   this._map = [
        [ W, W, W, W ],
        [ W, F, B, W ],
        [ W, B, F, W ],
        [ W, W, W, W ],
    ];
}
```

The same is true for `js::Object` special class. Example, if you write Meta D++ code:
```
   a = new js::Object( "key1", "value1", "key2", "value2" );
```
Will generate JS:
```
  a = { "key1": "value1", "key2": "value2" };
```

And it support recursive inclusion of `Object` and `Arrays`.

## And that's all ##
This is more or less all that you need to know in order to program in Meta D++ and target `JavaScript` runtimes.

Because, it's Meta D++, you can take advantage of all of the compile time capabilities of the language like introspection, code refactoring and transformation, compile time API encapsulation, program your own DSL, etc.