Instead of creating source code in memory using CodeDOM classes it is possible to use the "writecode" expression. Writecode expression takes as argument an expression or a block of code, depending on the form used, and generates in memory the code passed as an argument using CodeDOM classes, summing up the expression writecode performs automatically  work that we should do by "hand" using CodeDOM classes. Additionally writecode expression performs changes on the block passed as argument replacing identifiers marked with "$" for the content of the named variable.

<table border='1'>
<tr>
<th>Form</th>
<th>Description</th>
<th>Example</th>
</tr>
<tr>
<td>
Expression<br>
</td>
<td>In the form of expression writecode instruction always returns an object of type <code>XplExpression^</code>.</td>
<td>
<pre><code>//Returns a XplExpression object&lt;br&gt; <br>
writecode($argumentExp + 5 * var)<br>
</code></pre>
</td>
</tr>
<tr>
<td>
Simple Block of code<br>
</td>
<td>In simple block form, writecode expression returns an object of type:<br>
<ul><li><code>XplClass^</code>
</li><li><code>XplFunctionBody^</code>
</li><li><code>XplDocumentBody^</code>
depending on the content of the block passed as argument.</td>
<td>
<pre><code>//Returns a XplClass object <br>
writecode{ <br>
  class $className{<br>
      void func () <br>
      { <br>
      } <br>
  } <br>
}<br>
<br>
//Returns a XplDocumentBody object <br>
writecode{ <br>
  using Zoe; <br>
  namespace test{<br>
  <br>
  }<br>
}<br>
<br>
//Returns a XplFunctionBody object <br>
writecode{ <br>
  int localvar = 0; <br>
  for(int n=0; n&lt;$arg.Count; n++)<br>
  { <br>
    localvar++; <br>
  } <br>
}<br>
</code></pre>
</td>
</li></ul><blockquote></tr>
<tr>
<blockquote><td>Block of code of Class members</td>
<td>This writecode syntactic expression returns an object of type <code>XplClassMembersList^</code> which contains a list of class members.</td>
<blockquote><td>
<pre><code>// Returns a XplClassMembersList object <br>
// Note that the use of “{%” y “%}” is required in this case<br>
// for generating the members of the class <br>
writecode{% <br>
  int field1; <br>
  float field2; <br>
  void func($t1 arg1, int arg2) <br>
  { <br>
  <br>
  } <br>
%}<br>
</code></pre>
</td>
</blockquote></blockquote></tr>
</table></blockquote>

To tell writecode expression we want to replace an identifier for the content of a variable we must mark the identifier with the dollar sign at the beginning, for example '$myVariable'. Below is an example:

```
members = writecode 
{%
  private: 
    $fieldType $internalFieldName; 
  public: 
    $fieldType property $fieldName
    {
        get
        { 
          return $internalFieldName; 
        } 
        set
        { 
          $internalFieldName = value; 
        } 
    } 
%};
```

In the above example "FieldType", "internalFieldName" and "fieldName" are variables in the scope of the writecode expression. The types that can replace inside a writecode  expression are: type or `XplType^`, block or `XplFunctionBody^`,  `XplExpression^` or `exp` types, `XplIName^` or `iname` types and constants.