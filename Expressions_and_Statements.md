## Expressions ##
An expression is a construct made up of variables, operators, and method invocations, which are constructed according to the syntax of the language, that evaluates to a single value. The data type of the value returned by an expression depends on the elements used in the expression.
<br>
Meta D++ expressions are similar to C# and Java expressions.<br>
<br><br>
Some tipical expressions:<br>
<br>
<h3>Assignment</h3>
The assignment expression gives value to a certain variable.<br>
<pre><code>int a = 8;<br>
String^ name = ValidatorClass.getUserName(408);<br>
<br>
int b = 2;<br>
<br>
// assignment and arithmetic operation<br>
b += 2;<br>
b *= a;<br>
b /= 3;<br>
</code></pre>

<h3>Operations</h3>
You can do multiple kind of operations depending on the operators that you use. For example: a+b, b*c, or a<b.<br>
<br>
Some of the supported operators are:<br>
<br>
<pre><code>Simple Assignment Operator<br>
<br>
=	Simple assignment operator<br>
<br>
<br>
Arithmetic Operators<br>
<br>
+ 	Additive operator (also used for String concatenation)<br>
- 	Subtraction operator<br>
*	Multiplication operator<br>
/ 	Division operator<br>
%	Remainder operator<br>
<br>
<br>
Unary Operators<br>
<br>
+ 	Unary plus operator; indicates positive value (numbers are positive without this, however)<br>
- 	Unary minus operator; negates an expression<br>
++  	Increment operator; increments a value by 1 (Prefix or Postfix)<br>
--    	Decrement operator; decrements a value by 1 (Prefix or Postfix)<br>
!     	Logical compliment operator; inverts the value of a boolean<br>
sizeof  Returns the size in bytes of an specified variable<br>
<br>
<br>
Equality and Relational Operators<br>
<br>
==	Equal to<br>
!=	Not equal to<br>
&gt;	Greater than<br>
&gt;=	Greater than or equal to<br>
&lt;	Less than<br>
&lt;=	Less than or equal to<br>
<br>
<br>
Conditional Operators<br>
<br>
&amp;&amp; 	Conditional-AND<br>
|| 	Conditional-OR<br>
?:      Ternary (shorthand for if-then-else statement)<br>
<br>
<br>
Type Comparison Operator<br>
<br>
typeof	Returns an object that represents the type of the provided expression<br>
is      Evaluates if an object is of a specified type<br>
<br>
<br>
Bitwise and Bit Shift Operators<br>
<br>
~	Unary bitwise complement<br>
&lt;&lt;	Signed left shift<br>
&gt;&gt;	Signed right shift<br>
&amp;	Bitwise AND<br>
^	Bitwise exclusive OR<br>
|	Bitwise inclusive OR<br>
</code></pre>

The use of operators allows you to do "operations" like you do in other programming languages.<br>
<br>

<h3>Casting</h3>
Like in others programming languages it's possible to do casting too, as long as it's valid in the context where you're working.<br>
<br>
The casting is made with parentheses.<br>
<pre><code>XplClass^ oneClass = (XplClass^)context.CurrentNamespace.FindNode("/@XplClass");<br>
</code></pre>

<h3>Method Invocation (Function call)</h3>
For instance methods:<br>
<br>
<pre><code>//For values or references use "."<br>
MyClass object;<br>
object.method(arg1, arg2);<br>
<br>
MyOtherClass^ object2 = new MyOtherClass();<br>
object2.method(arg1, arg2);<br>
<br>
// for pointers use "-&gt;" like C/C++<br>
MyOtherClass* object3 = new MyOtherClass();<br>
object3-&gt;method(arg1, arg2);<br>
<br>
</code></pre>
For static methods use scope operator like C++:<br>
<pre><code>ClassX::method(arg1, arg2);<br>
</code></pre>

The method invocation would return a value or not. If it returns a value, you could save it in a variable. (if you need or want to do that)<br>
<br>
<h2>Statements</h2>
Statements are roughly equivalent to sentences in natural languages. A statement forms a complete unit of execution.<br>
<br>
Types of statements:<br>
<br>
<h3>Expression Statements</h3>
Expressions can be made into a statement by terminating the expression with a semicolon (;)<br>
<br>
For example:<br>
<pre><code>value = 8933.234;                       // assignment statement<br>
value++;                                // increment statement<br>
Console::WriteLine("Hello World!");     // method invocation statement<br>
String^ myStr = new String();           // object creation statement<br>
</code></pre>

<h3>Declaration Statements</h3>
A declaration statement declares a variable.<br>
<br>
An standar variable declaration:<br>
<pre><code>&lt;VariableType&gt; &lt;variableName&gt;;<br>
</code></pre>
Constant declaration:<br>
<pre><code>const &lt;typeOfConstant&gt; &lt;constantName&gt; = &lt;value&gt;;<br>
</code></pre>

Arrays:<br>
<br>
<pre><code>&lt;typeOfData&gt;[] &lt;matrixName&gt; = new &lt;typeOfData&gt; [&lt;number of elements&gt;];<br>
</code></pre>

It's possible to declare matrixes with a higher dimension adding a quantity of braces as dimension  are needed. For example for 2 dimension matrix you should declare with "<a href='.md'>.md</a><a href='.md'>.md</a>".<br>
<br>
Examples:<br>
<br>
<pre><code>//Single variable<br>
int xInt=15;<br>
//Matrix of One dimension. 10 elements. (Vector)<br>
int [] var=new int[10];<br>
// Matrix of Two dimensions (2x3)<br>
int [][] var2=new int[2][3];<br>
// Reference to a class.<br>
String^ myStr="Hola";<br>
// Declaration and initialization.<br>
int a, b, c=0;<br>
int [] b = {{1, 2}};<br>
</code></pre>

Arrays are by default stored in the heap and are implicitly declared as references to arrays.<br>
If you want a plain-old C array stored in the stack you must use this syntax:<br>
<br>
<pre><code><br>
// equivalent to C "int arrayOfTwoInt[2];", stored in the stack<br>
typeof [2]int arrayOfTwoInt;<br>
<br>
// equivalent to C# or Java "int[] array", stored in the heap need dynamic memory allocation<br>
int[] array;<br>
<br>
// in complex "typeof" syntax<br>
typeof ^[]array;<br>
<br>
/*<br>
To read a type declared with "typeof" read the type from left to right, for example:<br>
<br>
typeof ^[]^[]^string array2;<br>
<br>
It´s read "reference to an array with elements of type reference to array of references to string"<br>
<br>
That´s the same than:<br>
<br>
string^[][] array2;<br>
<br>
in common short syntax. This is because Meta D++ assume that most common type of arrays are allocated in the heap in modern programs and runtimes.<br>
*/<br>
<br>
</code></pre>

<h3>Control Flow Statements</h3>
Regulate the order in which statements get executed.<br>
<h4>The ''if'' statement</h4>
<pre><code>if(FIRST_CONDITION)<br>
{<br>
  //statement(s) if FIRST_CONDITION is true<br>
}<br>
else<br>
{<br>
  //statement(s) if FIRST_CONDITION is false<br>
  if(SECOND_CONDITION)<br>
  {<br>
     //statement(s) if SECOND_CONDITION is true<br>
  }<br>
  else<br>
  {<br>
     //statement(s) if SECOND_CONDITION is false<br>
     if(N_CONDITION)<br>
     {<br>
         //statement(s) if N_CONDITION is true<br>
     }<br>
     else<br>
     {<br>
         //statement(s) if N_CONDITION is false<br>
     }<br>
  }<br>
}<br>
</code></pre>
The ''else'' is optional and let you introduce new conditions, but you can also have a ''if'' without an ''else''<br>
<h4>The ''switch'' statement</h4>
The VALUE can be int or strings.<br>
<pre><code>switch(VALUE)<br>
{<br>
  case VALUE1:<br>
              //statement(s) for value1<br>
              break;<br>
  <br>
  case VALUE2:<br>
              //statement(s) for value2<br>
              break;<br>
<br>
. . . <br>
<br>
  default:<br>
              //statement(s) for default value (not one of the presented before)<br>
              break;<br>
}<br>
</code></pre>

<h4>The ''while'' statement</h4>
If the condition is at the first time false it never executes the while statement content.<br>
<pre><code>while(CONDITION)<br>
{<br>
 //statement(s) to execute while the condition is valid (true)<br>
}<br>
</code></pre>

<h4>The ''do-while'' statement</h4>
The do-while statement always executes it content at least one time<br>
<pre><code>do{<br>
 //statement(s) to execute while the condition is valid (true)<br>
} while (CONDITION);<br>
</code></pre>

<h4>The ''for'' statement</h4>
<pre><code>for (initialization; termination; increment) {<br>
    //statement(s)<br>
}<br>
</code></pre>
The ''initialization'' expression initializes the loop; it's executed once, as the loop begins.<br>
When the ''termination'' expression evaluates to false, the loop terminates.<br>
The ''increment'' expression is invoked after each iteration through the loop; it is perfectly acceptable for this expression to increment or decrement a value.<br>

<h4>The ''foreach'' statement</h4>
The foreach statement repeats a group of instructions in the loop for each element of an array or an object collection.<br>
<pre><code>foreach(X_OBJECT myObj in COLLECTION_OF__X__OBJECTS listOfObj)<br>
{<br>
  //statement(s)<br>
}<br>
</code></pre>

<h4>The ''break'' statement</h4>
You saw the break statement in the previous discussion of the switch statement to establish the end of an option. You can also use a break to terminate a for, while, or do-while loop.<br>
Examples:<br>
On a switch statement:<br>
<pre><code>switch(op)<br>
{<br>
  case 1:<br>
         Console::Write("1 selected");<br>
         break; //End of "case 1"<br>
  default:<br>
         Console::Write("Other selected");<br>
         break; //End of "default"<br>
}<br>
</code></pre>
Interrupting a for:<br>
<pre><code>int i;<br>
for(i=0; i&lt;myStr.length(); i++)<br>
{<br>
  if(myStr.getCharAt(i)=='A')  <br>
  {<br>
    break; //Ends for cycle<br>
  }<br>
}<br>
Console::Write("Char A founded at index"+i);<br>
</code></pre>

<h4>The ''continue'' statement</h4>
The continue statement skips the current iteration of a for, while , or do-while loop.<br>
Example:<br>
<pre><code>String^ searchMe = new String("peter piper picked a peck of pickled peppers");<br>
int max = searchMe.Length;<br>
int numPs = 0;<br>
<br>
for (int i = 0; i &lt; max; i++) {<br>
//interested only in p's<br>
    if (searchMe.ToCharArray[i] != 'p')<br>
    continue;<br>
    //process p's<br>
    numPs++;<br>
}<br>
Console::Write("Found " + numPs + " p's in the string.");<br>
</code></pre>

<h4>The ''return'' statement</h4>
The return statement exits from the current method, and control flow returns to where the method was invoked. The return statement has two forms: one that returns a value, and one that doesn't. To return a value, simply put the value (or an expression that calculates the value) after the return keyword.<br>
<pre><code>     return ++count;<br>
</code></pre>
The data type of the returned value must match the type of the method's declared return value. When a method is declared void, use the form of return that doesn't return a value.<br>
<pre><code>     return;<br>
</code></pre>