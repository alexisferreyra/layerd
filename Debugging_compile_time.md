## Debugging ##

There are 2 ways of debugging a Meta D++ program:
  * Using the internal debbuger of the Zoe compiler
  * Attaching the Zoe compiler process to the IDE you're using, for example, Visual Studio.

Let's see each way separated:

## Using the Zoe Internal Debbuger ##
The internal debbuger can be used passing to the Zoe compiler the following option:

```
sid: show internal debugger
```

Example:

```
zoec.exe -sid myZoeFile.zoe
```

### A little of theory: "Compile-Cycle" ###
The Zoe Internal Debugger works with the concept of "compile-cycle". One Meta D++ program without calls to classfactories methods has only one compile-cycle. If you have calls to methods of different classfactories that returns "new code" that doesn't have more calls to another classfactories, so the program has 2 compile-cycles. To sum up, a compile-cycle is related to the possibility of having methods of classfactories calling methods of other classfactories. The compile-cycles ends when you have all Meta D++ code without calls to methods of classfactories.
<br>

<h3>The Zoe Internal Debbuger Console</h3>
The Zoe Internal Debugger is a visual console that looks like this:<br>
<br>
<br><br>
[[File:ZoeInternalDebbuger_1.jpg]]<br>
<br><br>

Let's see each section of this visual console:<br>
<br><br>
1. It's the search bar where you can look for words in the Meta D++ program code.<br>
<br>
2. The "Find" button looks for the first appearance of the searched word . "Find Next" looks for the followings appearances of the searched word.<br>
<br>
3. It's a common area where you can see the content of tabs #4 and #5.<br>
<br>
4. Tab that shows the Meta D++ program code of the zoe file being debugged in a certain compile-cycle.<br>
<br>
5. Tab that shows the DTE of the zoe file (as a tree structure) in a certain compile-cycle.<br>
<br>
6. It's a common area where you can see the content of tabs #7, #8 and #9.<br>
<br>
7. Tab that shows the different "types of data" involved in the Meta D++ program  in a certain compile-cycle.<br>
<br>
8. Tab that shows compilation errors in a certain compile-cycle.<br>
<br>
9. Tab that shows compilation "warnings"  in a certain compile-cycle.<br>
<br>
10. Update the content of areas #3 and #6.<br>
<br>
11. Continue to the following compile-cycle. When you continue to the next compile-cycle, areas #3 and #6 are updated with the new code of the new cycle.<br>
<br><br>

Look carefully the previously presented image . Look that there's a call to a method of a classfactory and at this moment the Zoe Internal Debugger is at the first compilation-cycle. The method of this classfactory is supposed to implement an aspect that encapsulates the body of every function of every class with a try-catch block.<br>
<br>
<br>
<bR><br>
<br>
<br>
<br>
<bR><br>
<br>
<br>
Let's see how the "Zoe Compiler Debugger" looks when you select the "DTE" tab (#5)<br>
<br>
<br>
<bR><br>
<br>
<br>
[[File:ZoeInternalDebbuger_2.jpg]]<br>
<br>

<bR>

<br>
12. The same area as #3 that now shows the DTE of the zoe file being compile. (presented as a tree structure). Of course it always depends on the current compile-cycle.<br>
<br>
13. This button updates #12 with the full DTE of the zoe file.<br>
<br>
14. It's an area that shows the results of searches made to the DTE from the search bar #15.<br>
<br>
<br>
<bR><br>
<br>
<br>
15. It's a search bar where you can look for expressions inside the DTE of the zoe file.<br>
<br>
<br>
<bR><br>
<br>
<br>
16. "Find" looks for an expression on #12 where the DTE of the zoe file is showed. It presents the results on #14.<br>
<br>
17. "Find in result" looks for an expression in the result of a previous search. The results of previous searches were showed in #14.<br>
<br><br>
Let's see what happens when we press the "Continue" button.<br>
<br>
<br>
<bR><br>
<br>
<br>
<br>
<bR><br>
<br>
<br>
[[File:ZoeInternalDebbuger_3.jpg]]<br>
<br>

<bR>

<br>
As you can see, now we are in the second compile-cycle (the last one for this example). The new code shows the application of the functionality of the method of the classfactory over the code of the client. Now, the call to the classfactory has dissapeared and the code of the client has changed. Now every body of every function of every class has a try-catch block (as we proposed to do).<br>
<br>
<h2>Attaching Zoe Compiler process to the IDE</h2>

Supposing you are working with a classfactory (in Visual Studio, for example) and want to debug its use, we are going to see step by step how to perform the debugging process:<br>
<br>

1. In your IDE, insert all the breakpoints you need to the classfactory. Note that here we're working with the ".dpp file" of the classfactory.<br>
<br><br>
[[File:IP_1.jpg]]<br>
<br><br>
2. Open a new system console and compile the zoe file of a client of the classfactory passing to the Zoe compiler the following option.<br>
<pre><code>zoec.exe -wfd classfactoryClient.zoe<br>
</code></pre>
At this time you'll see in the console: "Waiting for a debbuger to connect. Press CTRL+C to finish."<br>
<br><br>
[[File:IP_2.jpg]]<br>
<br><br>
3. Attach the zoe compiler process to your IDE to do the debbuging of the classfactory. In Visual Studio you can do this going to the menu "Debug"->"Attach process" and selecting the "zoec.exe" process.<br>
<br><br>
[[File:IP_3.jpg]]<br>
<br><br>
At this time in the console you'll see "Debugger connected" and now you can debug the classfactory as you typically use to do in your IDE.<br>
<br><br>
[[File:IP_4.jpg]]