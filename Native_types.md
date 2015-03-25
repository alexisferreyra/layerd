## Signed Integers ##
  * sbyte
  * int
  * short
  * long

The types of "signed integer" sorted by range of supported values are: "sbyte", "int", "short", "long".
The "sbyte" type represents an 8-bit signed integer and it is the only type of signed integer of equal length regardless of the deployment platform.
The integer types "short", "integer", and "long" have a maximum length that depends on the used implementation of Zoe output module. The "integer" type represents a typical integer in the destination platform, eg: 32bit for a 32bits platform and 64bit for a 64bit platform. The type "short" is an integer smaller than "integer" and "long" represents an integer of greater range than an "integer"

## Unsigned Integers ##
  * byte
  * unsigned short (or ushort)
  * unsigned (or unsigned int)
  * unsigned long (or ulong)

The unsigned integer types sorted by range of supported values are: "byte", "unsigned", "unsigned short" or "ushort", "unsigned long" or "ulong".
The unsigned integer types are not required to be supported by all target platforms, but is recommended.
The type "byte" represents an unsigned integer of 8-bit length and supports decimal range from 0 to 255.

## Real Numbers ##
  * float
  * double
  * long double
  * decimal

The types of real numbers with floating point available on Meta D + + are "float", "double" and "long double."
The type  "float" must correspond to a specific deployment platform with single-precision format (32bits).
The type "double" must correspond to a specific deployment platform with double-precision format (64bits). If the platform provides greater precision for type "float" , the precision of the type "double" must always be greater than the precision of the implemented type "float" .
The type "long double" is optional to be implemented in a specific deployment platform by an output module. If it is implemented is required to have a higher degree of accuracy than the type "double", if it is not implemented it must use the same precision as the type "double" and emit "warnings" for pointing out the decrease of precision.
The type "decimal" is a real number that is recommended to duplicate the precision of the floating-point type "double", but is left to each output module the implementation decision on using floating or fixed point.
In case of not implementing a special type, the output module must provide for the  type "decimal" the same implementation than "double" and emit a "warning" to the user.

## Chars ##
  * char

The types of char data that are available in Zoe are "char."
The type "char" represents a single character and has a default implementation of 16 bits. The binary operator "+" between two operands of type "char" returns a type "string" with the concatenation of both operands.
It is represented by the class `zoe::lang::Char`.

## Strings ##
  * string

Zoe defines "string" as the standard data type for strings , which corresponds to the class 'zoe::lang::String'
The type "string" represents an immutable sequence of characters, so any operation on a string returns a new value.
In addition to other functions, the different classes of expression should provide an implementation for the binary operator "+" that works as follows:
<br>
• If the two operators are of type "string" the result is the concatenation of two chains also type "string".<br>
<br>
• Relational operators return the type "bool".<br>
<br>
<h2>Others</h2>
<ul><li>void<br>
</li><li>object<br>
</li><li>bool</li></ul>

The types "void", "object", "bool" of Zoe are defined below.<br>
<br>
<b>void</b>

The type "void" represents the type "not specified" or "any type" and it can be used as return type in functions to mark that the function returns no value or it can be used as a pointer to a variable of any type.<br>
<br>
<b>object</b>

The type "object" is an abbreviation for the class 'zoe::lang::Object'. By default all data types explicitly or implicitly are derived from the type "object". The type "object" is the base class of all types in the default configuration of Zoe's code.<br>
<br>
Optionally you can specify that this is not fulfilled in the configuration section of a document Zoe, for details see the specification of Zoe. Meta D++ has no syntax for disabling the system of unified typing , however it can be done by writing a Zoe configuration file and passing it as  parameter to a implementation of a Zoe compiler at the compilation time of the program.<br>
<br>
By default the type "object" has an interface defined by the Zoe language. Meta D++ does not define a syntax to change the implementation of the class <code>zoe::lang::Object</code>, but it can be done by hand writing a Zoe configuration file.<br>
<br>
To type <code>object^</code> (reference to object) can hold any value, and all values are implicitly convertible to <code>object^</code>. For value types that will generate an underlying boxing conversion in the target runtime. This conversion is transparent to the programmer but must be taken into account because of performance penalties.<br>
<br>
<b>bool</b>

The type bool represents a logical value <code>true</code> or <code>false</code>.<br>
The allowed values for <code>bool</code> are <code>true</code> and <code>false</code>.<br>
No standard conversions are defined between the type <code>bool</code> and other types like integer types.<br>
The size of the type <code>bool</code> depends on the target platform.<br>
The type <code>bool</code> can not be used in place of an integer or vice versa.<br>
<br>
<h2>Special types to be used by classfactorys</h2>

Compile time classes (Classfactories) can access to special types of data. Below are shortly explained:<br>
<br>
<table border='1'>
<blockquote><tr>
<blockquote><th>
Type<br>
</th>
<th>
Description<br>
</th>
</blockquote></tr>
<tr>
<blockquote><td>
iname<br>
</td>
<td>
Variables of type "iname" represent an identifier in the source code.<br>
<blockquote></td>
</blockquote></blockquote></tr>
<tr>
<blockquote><td>
expression<br>
</td>
<td>
Variables of type "expression" represent an expression in the source code.<br>
</td>
</blockquote></tr>
<tr>
<blockquote><td>
block<br>
</td>
<td>
Variables of type "block" allow us to take as an argument in functions, blocks of source code to be processed.<br>
</td>
</blockquote></tr>
<tr>
<blockquote><td>
type<br>
</td>
<td>
Variables of type "type" represent a data type.<br>
</td>
</blockquote></tr>
</table>