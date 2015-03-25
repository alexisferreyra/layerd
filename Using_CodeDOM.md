## The CodeDOM ##
<p>In LayerD is called <code>CodeDOM</code> to all classes declared within the namespace <code>LayerD::CodeDOM</code> (depending the Zoe compiler implementation can be contained within another namespace <code>DotNET::LayerD::CodeDOM</code>, <code>Java::LayerD::CodeDOM</code>, etc.). </p>
<p>
Classes within <code>CodeDOM</code> represents portions of Zoe source code in memory, eg classes, functions, expressions, types, etc..<br>
All classes that represent some portion of source code are derived from <code>XplNode</code> which is the base class for all nodes that represent a Zoe source.  In memory a Zoe source is represented with a tree structure and the classes within the <code>CodeDOM</code> represent the branches and leaves in the tree. As the most important classes within the <code>CodeDOM</code> can be mention the followings:<br>
</p>
<p>You can find the CodeDOM documentation <a href='https://googledrive.com/host/0B6YUCBp4Z-wOOGZBdlVRTTQzNFk/d0/d7f/namespace_layer_d_1_1_code_d_o_m.html'>here</a>. Or generate the CodeDOM with LayerD's source.</p>

<br>
<table><thead><th> <b>Class</b> </th><th> <b>Description</b> </th></thead><tbody>
<tr><td> <a href='https://googledrive.com/host/0B6YUCBp4Z-wOOGZBdlVRTTQzNFk/d0/d09/class_layer_d_1_1_code_d_o_m_1_1_xpl_node.html'>XplNode</a> </td><td> It is the base class for all classes that are part of a Zoe document in memory. </td></tr>
<tr><td> <a href='https://googledrive.com/host/0B6YUCBp4Z-wOOGZBdlVRTTQzNFk/d2/da0/class_layer_d_1_1_code_d_o_m_1_1_xpl_document.html'>XplDocument</a> </td><td> Represents the initial node of a Zoe document in memory. Contains a <code>DocumentData</code> that contains metadata and configuration information. Another section <code>DocumentBody</code> where the functional part of the source code is located. </td></tr>
<tr><td> <a href='https://googledrive.com/host/0B6YUCBp4Z-wOOGZBdlVRTTQzNFk/db/dc6/class_layer_d_1_1_code_d_o_m_1_1_xpl_namespace.html'>XplNamespace</a> </td><td> Represents a Zoe namespace, to set or get the name is used <code>set_name</code> or <code>get_name</code>. </td></tr>
<tr><td> <a href='https://googledrive.com/host/0B6YUCBp4Z-wOOGZBdlVRTTQzNFk/de/dd4/class_layer_d_1_1_code_d_o_m_1_1_xpl_class.html'>XplClass</a> </td><td> Represents a class, interface, enumeration, or Zoe structure.  By default represents a class. </td></tr>
<tr><td> <a href='https://googledrive.com/host/0B6YUCBp4Z-wOOGZBdlVRTTQzNFk/da/d91/class_layer_d_1_1_code_d_o_m_1_1_xpl_function.html'>XplFunction</a> </td><td> Represents a member function of a Zoe class. </td></tr>
<tr><td> <a href='https://googledrive.com/host/0B6YUCBp4Z-wOOGZBdlVRTTQzNFk/da/d3b/class_layer_d_1_1_code_d_o_m_1_1_xpl_property.html'>XplProperty</a> </td><td> Represents a member property of a Zoe class. </td></tr>
<tr><td> <a href='https://googledrive.com/host/0B6YUCBp4Z-wOOGZBdlVRTTQzNFk/d9/dc6/class_layer_d_1_1_code_d_o_m_1_1_xpl_field.html'>XplField</a> </td><td> Represents a Zoe member field. </td></tr>
<tr><td> <a href='https://googledrive.com/host/0B6YUCBp4Z-wOOGZBdlVRTTQzNFk/d5/d02/class_layer_d_1_1_code_d_o_m_1_1_xpl_type.html'>XplType</a> </td><td>	Represents a type declaration, it is a recursive structure for derived types likes arrays and pointers. </td></tr>
<tr><td> <a href='https://googledrive.com/host/0B6YUCBp4Z-wOOGZBdlVRTTQzNFk/da/d5f/class_layer_d_1_1_code_d_o_m_1_1_xpl_function_body.html'>XplFunctionBody</a> </td><td> Represents a function body or any block of statements. A reference to this class is the type used by the intrinsic type <code>block</code>. </td></tr>
<tr><td> <a href='https://googledrive.com/host/0B6YUCBp4Z-wOOGZBdlVRTTQzNFk/d8/d0c/class_layer_d_1_1_code_d_o_m_1_1_xpl_i_name.html'>XplIName</a> </td><td> Represents an <code>iname</code> or identifier for the purpose of being used by the Zoe compiler, but is not itself a portion of source code. </td></tr>
<tr><td> <a href='https://googledrive.com/host/0B6YUCBp4Z-wOOGZBdlVRTTQzNFk/d6/d3c/class_layer_d_1_1_code_d_o_m_1_1_xpl_class_members_list.html'>XplClassMembersList</a> </td><td> Not used as part of a Zoe program, but to group class members in memory. </td></tr>
<tr><td> <a href='https://googledrive.com/host/0B6YUCBp4Z-wOOGZBdlVRTTQzNFk/d6/dfb/class_layer_d_1_1_code_d_o_m_1_1_xpl_expression.html'>XplExpression</a> </td><td>	This is the container for all kind of expressions. For example, can contain a literal expression, unary, binary, etc. It's the data type used to represent the variables with the type modifier <code>exp</code>. </td></tr>
<tr><td> <a href='https://googledrive.com/host/0B6YUCBp4Z-wOOGZBdlVRTTQzNFk/d7/d5e/class_layer_d_1_1_code_d_o_m_1_1_xpl_node_list.html'>XplNodeList</a> </td><td> This is a list of nodes used to store any type of node derived from <code>XplNode</code>. This type is used in every place in the CodeDOM where a list of nodes is needed. </td></tr></tbody></table>

<p>As <code>XplNode</code> is the base class of all nodes in the <code>CodeDOM</code> its functionality is shared with most of the data types within the <code>CodeDOM</code>. You can think an instance of <code>XplNode</code> as the representation of a xml node of the Zoe source, then every derived class represents a different portion of Zoe source code in memory. The core functionality of <code>XplNode</code> is detailed in the following table:</p>


<table><thead><th> <b>Member</b> </th><th> <b>Description</b> </th></thead><tbody>
<tr><td> <code>get_ElementName()</code> and <code>set_ElementName (string ^)</code> </td><td> Gets or sets the XML element name. </td></tr>
<tr><td> <code>Children()</code> </td><td> Returns a <code>XplNodeList</code> with the child nodes. Only for elements that might contains a variable list of child nodes as classes, blocks, etc. If the element can not contains a variable list of children as an expression, returns null. </td></tr>
<tr><td> <code>get_Parent()</code> </td><td> Returns the parent of the node, null if it doesn't has a parent. </td></tr>
<tr><td> <code>get_Content()</code> </td><td> Returns the content of the node for nodes that holds a content like <code>XplExpression</code> which returns the specific expression node. Null if node doesn't contains any element. </td></tr>
<tr><td> <code>set_Value(string^)</code> </td><td> Sets as content of the node the string passed as argument (only used for simple nodes of <code>XplNode</code> type). </td></tr>
<tr><td> <code>get_StringValue()</code> </td><td> Gets the string value stored in the node. Only serves for <code>XplNode</code> nodes that contain a string value (simple nodes can contain other types of values such as integers, floating or dates). </td></tr>
<tr><td> <code>FindNodes("/n")</code> </td><td> Returns a list of nodes (<code>XplNodeList</code>) that match the search string passed as argument. </td></tr>
<tr><td> <code>FindNode("/n(id)")</code> </td><td> Returns the first node found that matches with the pattern passed as an argument or null if it doesn't find a node. </td></tr>
<tr><td> <code>CurrentNamespace</code> </td><td> Returns the immediate namespace that contains the current node or null if the current node is not within a namespace. </td></tr>
<tr><td> <code>CurrentClass</code> </td><td> Returns the most immediate class that contains the current node or null if the current node is not found within a class. </td></tr>
<tr><td> <code>CurrentFunction</code> </td><td> Returns the most immediate function containing the current node or null if is not found  within a function. </td></tr>
<tr><td> <code>CurrentStatement</code> </td><td> Returns the most immediate statement or null if current node is not child of one statement. </td></tr>
<tr><td> <code>CurrentProperty</code> </td><td> Returns the most immediate property containing the current node or null if is not found within a property. </td></tr>
<tr><td> <code>CurrentBlock</code> </td><td> Returns the closest block that contains the current node or null if is not found within a block. </td></tr>
<tr><td> <code>CurrentExpression</code> </td><td> Returns the most immediate expression containing the current node or null if is not found within an expression. </td></tr>
<tr><td> <code>ZoeXmlString</code> </td><td> Return the XML representation of current node. </td></tr>
<tr><td> <code>ReadableString</code> </td><td> Returns an "human readable" string representation of current node. By default it renders to Meta D++ code. </td></tr>
<tr><td> <code>ChildNodes()</code> </td><td> Returns a collection with all child nodes. If the element has no child nodes returns an empty collection. </td></tr>
<tr><td> <code>string^[] Attributes()</code> </td><td> Returns an array with all XML attributes of the element type. </td></tr>
<tr><td> <code>string^ AttributeValue(string^)</code> </td><td> Returns the value of the attribute specified in the parameter converted to string as represented in XML when a Zoe document is stored . </td></tr>
<tr><td> <code>set_doc(string^)</code> and <code>get_doc()</code> </td><td> Sets and returns a simple comment associated with the element. </td></tr>
<tr><td> <code>string^ get_ldsrc()</code> </td><td> Returns a string that represents the lines/columns of beginning and/or ending  in the original source. Can returns an empty string. This means that the node does not have information about the origin source, in this case, the closer parents nodes should be examined. </td></tr>
<tr><td> <code>CodeDOMTypes get_TypeName()</code> </td><td> Returns an enumeration value containing the name of the node type, eg <code>XplNode</code>, <code>XplClass</code>, etc. You can optionally use the identification of types supported by the high-level language. </td></tr>
<tr><td> <code>IsA(CodeDOMTypes nodeType)</code> </td><td> Returns a boolean pointing out if the node is or not of the same type as the passed argument. </td></tr>
<tr><td> <code>XplNode^ Clone()</code> </td><td> Gets a deep copy of a node. </td></tr>
<tr><td> <code>Write(XplWriter^)</code> </td><td> Save the node and all its childrens using the instance of <code>XplWriter</code> received as an argument. </td></tr>
<tr><td> <code>XplNode^ Read(XplReader^)</code> </td><td> Load in Memory the node from the instance of <code>XplReader</code> received as an argument. </td></tr></tbody></table>

<code>XplNodeList</code> class is used by CodeDOM classes where you need a list nodes of any length and where in general that list can have several types of nodes of the CodeDOM. The most important members of <code>XplNodeList</code> are:<br>
<br>
<table><thead><th> <b>Member</b> </th><th> <b>Description</b> </th></thead><tbody>
<tr><td> <code>InsertAtEnd(XplNode^)</code> </td><td> Insert a node at the end of the list. There is also an overload method that accepts a XplNodeList as an argument, in which case inserts all nodes contained in the received list. </td></tr>
<tr><td> <code>InsertAtBegin(XplNode^)</code> </td><td> Insert a node at the beginning of the list. There is another overload method that accepts a XplNodeList. </td></tr>
<tr><td> <code>InsertBefore(XplNode^ newNode, XplNode^ reference)</code> </td><td> Insert newNode before the reference node. If the reference node does not exist newNode is not inserted. There is another overload method that accepts a <code>XplNodeList</code>. </td></tr>
<tr><td> <code>InsertAfter(XplNode^ newNode, XplNode^ reference)</code> </td><td> Insert newNode after the reference node. If the reference node does not exist newNode is not inserted. There is another overload method that accepts a <code>XplNodeList</code>. </td></tr>
<tr><td> <code>FirstNode()</code> </td><td> Returns the first node of the list and initializes the internal iterator on the list. </td></tr>
<tr><td> <code>NextNode()</code> </td><td> Gets the next node in the current iteration, if there are no more nodes (this at the end of the list) returns null. </td></tr>
<tr><td> <code>GetLength()</code> </td><td> Returns the number of nodes in the list. </td></tr>
<tr><td> <code>XplNodeList::CopyNodesAtEnd(XplNodeList^ source, XplNodeList^ target)</code> </td><td> Copy the nodes in the source list at the end of the target list. </td></tr></tbody></table>

<p>Using instances of <code>CodeDOM</code> classes is possible to create in memory portions of source code and even entire programs. Is necessary to clear that any Zoe code represented in memory as a document is implemented with <code>CodeDOM</code> classes, because of this it is very useful for all classfactories programmers know the <code>CodeDOM</code>.</p>

<h2>Classification of CodeDOM classes regarding the possibility of having children nodes</h2>
The CodeDOM classes can be classified regarding the possibility of having children nodes in the followings types:<br>
<br>
<ol><li>The ones that can have multiple children of different types. For example: <code>XplFunctionBody</code>, <code>XplExpressionlist</code>, <code>XplClass</code>, <code>XplNamespace</code>, <code>XplDocumentBody</code>, <code>XplParameters</code>, <code>XplInherits</code>. If <code>.Children()</code> method is invoked (the one which is inherited from <code>XplNode</code>) a list with the children nodes that the class has is returned. This is because is permitted to this kind of class to has a variable number of children nodes.<br>
</li><li>The ones that can have only one child-node of some specific types. For example: <code>XplExpression</code>, <code>XplCatchinit</code> that uses the <code>get_Content()</code> and <code>set_Content()</code> methods to get or set its content. For an expression, for example, there are specific types of nodes that are valid as content. If <code>.Children()</code> method is invoked a null value is returned. This is because for this kind of class that manages a <code>content</code> the methods get and set content are supposed to be used.<br>
</li><li>The ones that can have a limited number of children nodes of specific types. For example: <code>XplFunction</code> that uses the <code>get_Parameters()</code> and <code>get_FunctionBody()</code> for getting the parameters and function body of a function.If <code>.Children()</code> method is invoked, a null value is returned. This is because the special methods for handling the specific properties (as <code>arguments</code> or <code>body</code> in a function) are supposed to be used.</li></ol>

Of course that, in all the cases, the children nodes of every class must be coherent with the type of class and what it represents. Type 1, for example, can has a multiple number of children nodes of different types but not of any type. For example, a <code>if-statement</code> inside a <code>DocumentBody</code> won't work because is not a valid construction.<br>
<br>
<h2>Examples of Use</h2>
<h3>Checking if a Block of Code contains only a Try-Catch statement inside</h3>
Let's suppose we want to check if a certain block of code passed as an argument has or not only one try-catch statement inside. The method implemented in a classfactory should look like this:<br>
<br>
<pre><code><br>
/*Checks if a block contains only a "try-catch" statement inside*/<br>
static bool checkTryStatementOnly(XplFunctionBody^ tryBlock)<br>
{<br>
   /*#1: Let's obtain all the children nodes of the block of code. <br>
         This is valid for a block of code as it could has a variable quantity of children nodes.*/<br>
   XplNodeList^ childrensOfBlock = tryBlock.Children();<br>
      <br>
    /*#2: The block must contains only one child node and it must be "XplTryStatement" type.<br>
          Let's check this in a condition and we'll return a boolean to point out if it has or not a try-catch block*/<br>
        <br>
    bool hasTryCatch;<br>
    <br>
      if(childrensOfBlock.GetLength()!=1 || !childrensOfBlock.FirstNode().IsA(CodeDOMTypes::XplTryStatement))<br>
    {<br>
        hasTryCatch=false;<br>
    }<br>
    else<br>
    {<br>
      hasTryCatch=true;<br>
    }        <br>
    return hasTryCatch;        <br>
}<br>
<br>
</code></pre>

In this example we have used:<br>
<br>
<ul><li><code>XplFunctionBody</code> instead of <code>block</code> to deal with blocks of codes. (Let's remember it's the same)<br>
</li><li>The <code>.Children()</code> method that is common to all derived nodes from <code>XplNode</code>. Lets's remember that, however, this method is valid for nodes that could has a variable number of nodes inside, not valid for an expression node for example.<br>
</li><li>The <code>.GetLength()</code> method of <code>XplNodeList</code> to return the number of children nodes in the list.<br>
</li><li>The <code>.FirstNode()</code> which is a searching method to look for the first node of a list.<br>
</li><li>The <code>.IsA(CodeDOMType::SOME_TYPE)</code> which is a method for checking if a Node is of a certain type. This is another common method for all nodes as  it's a method of <code>XplNode</code>.