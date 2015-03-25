# Javascript code generator #

Sample import directives that can be used with Javascript code generator:

```
// include a Javascript file in the generated .html (by using an <script> element) and copy the .js file to the output
import "classy.js", "platform=JavaScript", "type=script", "copy=true";

// include a Javascript file in the generated .html and copy the .js file to the output
// and import a Zoe file with externs definitions with type information
import "jquery-1.7.2.js", "platform=JavaScript", "type=script", "copy=true", "extern=jquery-1.7.2.externs.zoe";

// include a stylesheet in the generated .html and copy it to the output
import "jquery.mobile-1.2.0.css", "platform=JavaScript", "type=stylesheet", "copy=true";

// copy a resource (any file) into the output
import "images/ajax-loader.gif", "platform=JavaScript", "type=resource";

// copy a javascript file into a subfolder 
import "lib/classy.js", "platform=JavaScript", "type=script", "outputsubfolder=lib", "copy=true";

// change create namespace and truncate functions with the ones provided in mylib.js
import "mylib.js", "platform=JavaScript", "type=script", "extern=mylib.zoe", "createNamespaceFunction=MyLib.createNamespace", "truncateFunction=MyLib.truncate";
```


# Import parameters #

All paths used in import directives are relative to current working directory of the Zoe compiler.

  * First parameter is the name of the resource that is referenced (.js, .css, image, etc)
  * **"platform"** parameter must be set to "JavaScript"
  * **"type"** parameter is one of: "script", "stylesheet" or "resource"
    * **"script"** a .js file that can be copied to the output and will generate a `<script>` element in the generated .html file
    * **"stylesheet"** a .css file that can be copied to the output and will generate a `<link>` element in the generated .html file
    * **"resource"** any file that will be copied to the output
  * **"copy"** parameter is either true or false. Set if the resource will copied to the output with the rest of generated code or not.
  * **"extern"** optional parameter that signal the code generator to load that Zoe file during compilation (when the target is Javascript) to be used as external types definitions. Because current implementation does not provide an automatic type importer. You must provide all type information for external types that lives in the target Javascript runtime.
  * **"outputsubfolder"** an optional subfolder that will be used to copy the resources/scripts and css files. If not provided, files are copied in the root of the output directory.
  * **"createNamespaceFunction"** allows to change the default function "Zoe.createNamespace" used to declare namespaces.
  * **"truncateFunction"** allows to change the default function "Zoe.truncate" used to truncate numbers.

Note that parameters to change namespace or truncate functions are global settings. The last processed import directive, that includes these parameters, will be used. By default, you don't need to setup any special functions if you are OK using the ones provided by default.

# External type information #
Because current implementation does not provide an automatic type importer. You must provide all type information for external types that lives in the target Javascript runtime.
When providing external type information to Javascript code generator use the namespace **"js"** for all external definitions and the special class **"js::global"** to provide global definitions like global functions like **alert** or objects like **window**.
The following is a sample extern definitions of common objects and functions defined in most Javascript runtimes.

```
namespace js
{
  extern public class global
  {
  public:
    static js::Object*ref undefined;        
    static js::DOMWindow*ref window;  
    static js::DomDocument*ref document;
    static js::Navigator*ref navigator;
    static string*ref decodeURI(string*ref uri);
    static string*ref decodeURIComponent(string*ref uri);
    static string*ref encodeURI(string*ref uri);
    static string*ref encodeURIComponent(string*ref uri);
    static string*ref escape(string*ref str);
    static bool isFinite(js::Object*ref element);
    static bool isNan(js::Object*ref element);
    static Number*ref Number(js::Object*ref obj);
    static float parseFloat(object*ref arg);
    static int parseInt(object*ref arg);
    static int parseInt(js::Object*ref arg, int radix);
    static string*ref String(js::Object*ref obj);    
    static string*ref unescape(string*ref str);
    static js::Array*ref arguments;
    static js::Object*ref NaN;
    static void alert(string*ref msg);
    static js::String*ref @typeof(object*ref obj);

    extern public class console
    {
    public:
      static void log(string*ref text);
    }

    // Special function "$()"
    static js::JQObject*ref S(params object*ref []args);  
    static js::JQObject*ref jQuery(params object*ref []args);

    // Dummy object to represent closure this 
    static js::Object*ref @this;
  }

  extern public class DOMWindow inherits js::Object
  {
  public:
    int setInterval(js::Function*ref callback, js::Number*ref interval);
    void clearInterval(js::Number*ref handler);
    int setTimeout(js::Function*ref callback, js::Number*ref interval);
    void clearTimeout(js::Number*ref handler);
    void open(js::String*ref url);
    void onblur(js::Function*ref callback);
    void onload(js::Function*ref callback);
    void onunload(js::Function*ref callback);
    void onclose(js::Function*ref callback);
    js::String*ref innerHeight;
    js::String*ref innerWidth;
    js::Object*ref location;
  }

  extern public class Function inherits js::Object
  {
  public:
    Function(params object*ref[] args);
    js::Object*ref call(params object*ref[] args);
    js::Object*ref apply(params object*ref[] args);
    js::Object*ref bind(params object*ref[] args);
        
    // Special function that mimic "()" usage
    js::Object*ref CALL(params object*ref[] args);
  }

  extern public class Math
  {
  public:    
    static double random();
    static double PI;
    static double RAND_MAX;

    static double sqrt(object*ref arg);
    static double pow(object*ref arg1, object*ref arg2);
    static double cos(object*ref arg);
    static double sin(object*ref arg);
    static double tan(object*ref arg);
    static double acos(object*ref arg);
    static double asin(object*ref arg);
    static double atan(object*ref arg);
    static double atan2(object*ref arg1, object*ref arg2);
    static double abs(object*ref arg);
    static int abs(int arg);
    static int ceil(object*ref arg);
    static int floor(object*ref arg);
    static int round(object*ref arg);
    static double log(object*ref arg);
    static double @exp(object*ref arg);
    static double min(object*ref arg1, object*ref arg2);
    static double max(object*ref arg1, object*ref arg2);  
  }

  extern public class Object
  {
  public:
    Object(params object*ref[] args);

    extern js::Object*ref indexer(object*ref name)
    { 
      get;
      set;
    }

    js::Object*ref constructor;
    js::Object*ref prototype;
    js::String*ref toString();
    js::String*ref toString(int base);

    static js::Array*ref keys(js::Object*ref arg);
    static js::Function*ref create(js::Object*ref arg);

    static bool operator && (object*ref argLeft, object*ref argRigth);
    static bool operator || (object*ref argLeft, object*ref argRigth);
  }

  extern public class String inherits js::Object
  {
  public:
    String();
    String(js::Object*ref arg);
    String(char* str);
    int length;

    char charAt(int arg);
    js::Object*ref charCodeAt(int arg); 
    js::String*ref concat(params js::String*ref[] args);
    js::String*ref fromCharCode(Object*ref[] args);
    int indexOf(js::String*ref searchStr);
    int indexOf(js::String*ref searchStr, int start);
    int lastIndexOf(js::String*ref searchStr);
    int lastIndexOf(js::String*ref searchStr, int start);
    js::Object*ref[] match(js::Object*ref pattern);
    js::String*ref replace(js::String*ref substring, js::String*ref newString);
    js::String*ref replace(js::RegExp*ref substring, js::String*ref newString);
    int search (js::Object*ref regexp);
    js::String*ref slice(int start);
    js::String*ref slice(int start, int end);
    js::String*ref split();
    js::String*ref split(char separator);
    js::String*ref split(char separator, int limit);
    js::Array*ref split(js::String*ref separator);
    js::String*ref split(js::String*ref separator, int limit);
    js::String*ref substr(int startIndex);
    js::String*ref substr(int startIndex, int length);
    js::String*ref substring(int from);
    js::String*ref substring(int from, int to);
    js::String*ref toLowerCase();
    js::String*ref toUpperCase();
        js::String*ref trim();
    string*ref valueOf();
    static js::String*ref fromCharCode(char aCharacter);
    
    static js::String*ref operator + (js::String*ref op1, js::String*ref op2);
    static js::String*ref operator + (js::String*ref op1, string*ref op2);
    static js::String*ref operator + (string*ref op1, js::String*ref op2);
    static bool operator == (js::String*ref op1, js::String*ref op2);
    static bool operator != (js::String*ref op1, js::String*ref op2);
  }
  
  extern public class Array inherits js::Object
  {
  public:
    Array(params object*ref[] args);    
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
    js::Array*ref slice(int start, int end);
    void sort(js::Object*ref sortfunc); 
    js::Array*ref splice(int index, int howmany, params object*ref[] args);
    js::String*ref toString();
    int unshift(params object*ref[] args);
    js::Object*ref valueOf();
    int indexOf(js::Object*ref arg);
    bool every(js::Function*ref aFunction);
    bool every(js::Function*ref aFunction, js::Object*ref thisObject);
    extern js::Object*ref indexer(int index)
    { 
      get;
      set;
    }    
  }

  extern public class Boolean inherits js::Object
  {
  public:
    bool valueOf();
    static bool operator!(js::Boolean*ref arg1);
  }
  
  extern public class Number inherits js::Object
  {
  public:
    Number();
    Number(int arg);
    Number(bool arg);
    Number(double arg);
    int valueOf(); 
    js::String*ref toString();
    static double POSITIVE_INFINITY;
    static double NEGATIVE_INFINITY;
  }
  
  extern public class Date inherits js::Object
  {
  public:
    Date();
    Date(double miliseconds);
    Date(js::String*ref dateString);
    Date(int year, int month, int day, int hour, int minute, int second, int millisecond);
    Date(int year, int month, int day);
    static long now();

    int getDate();    
    int getDay();
    int getFullYear();
    int getHours();
    int getMilliseconds();
    int getMinutes();
    int getMonth();
    int getSeconds();
    long getTime();
    int getTimezoneOffset();
    int getUTCDate();
    int getUTCDay();
    int getUTCFullYear();
    int getUTCHours();
    int getUTCMilliseconds();
    int getUTCMinutes();
    int getUTCMonth();
    int getUTCSeconds();
    js::String*ref toString();
    void setDate(int arg);
    void setMonth(int arg);
    void setFullYear(int arg);
    void setHours(int arg);
    void setMinutes(int arg);
    void setSeconds(int arg);    
  }

}
```