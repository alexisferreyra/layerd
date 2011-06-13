/*
 * Copyright 2009 - Alexis Ferreyra
 * Copyright 1999-2008 Sun Microsystems, Inc.  All Rights Reserved.
 * DO NOT ALTER OR REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
 *
 * This code is free software; you can redistribute it and/or modify it
 * under the terms of the GNU General Public License version 2 only, as
 * published by the Free Software Foundation.  Sun designates this
 * particular file as subject to the "Classpath" exception as provided
 * by Sun in the LICENSE file that accompanied this code.
 *
 * This code is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License
 * version 2 for more details (a copy is included in the LICENSE file that
 * accompanied this code).
 *
 * You should have received a copy of the GNU General Public License version
 * 2 along with this work; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301 USA.
 *
 * Please contact Sun Microsystems, Inc., 4150 Network Circle, Santa Clara,
 * CA 95054 USA or visit www.sun.com if you need additional information or
 * have any questions.
 */

package java2metadpp;

import java.io.*;
import java.util.*;

import com.sun.tools.javac.util.*;
import com.sun.tools.javac.util.List;
import com.sun.tools.javac.code.*;

import com.sun.tools.javac.code.Symbol.*;
import com.sun.tools.javac.tree.JCTree;
import com.sun.tools.javac.tree.JCTree.*;

import com.sun.tools.javac.tree.TreeInfo;
import com.sun.tools.javac.tree.TreeScanner;
import static com.sun.tools.javac.code.Flags.*;
import javax.lang.model.element.ElementVisitor;

/** Prints out a tree as an indented Java source program.
 *
 *  <p><b>This is NOT part of any API supported by Sun Microsystems.  If
 *  you write code that depends on this, you do so at your own risk.
 *  This code and its internal interfaces are subject to change or
 *  deletion without notice.</b>
 */
public class MetaDppPrinter extends JCTree.Visitor {

    public MetaDppPrinter(Writer out, boolean sourceOutput, Arguments arguments) {
        this.arguments = arguments;
        this.out = out;
        this.sourceOutput = sourceOutput;
    }

    /** Set when we are producing source output.  If we're not
     *  producing source output, we can sometimes give more detail in
     *  the output even though that detail would not be valid java
     *  soruce.
     */
    private final boolean sourceOutput;

    /** The output stream on which trees are printed.
     */
    Writer out;

    /** Indentation width (can be reassigned from outside).
     */
    public int width = 4;

    /** The current left margin.
     */
    int lmargin = 0;

    /** The enclosing class name.
     */
    Name enclClassName;

    /** A hashtable mapping trees to their documentation comments
     *  (can be null)
     */
    Map<JCTree, String> docComments = null;

    /** Align code to be indented to left margin.
     */
    void align() throws IOException {
        for (int i = 0; i < lmargin; i++) out.write(" ");
    }

    /** Increase left margin by indentation width.
     */
    void indent() {
        lmargin = lmargin + width;
    }

    /** Decrease left margin by indentation width.
     */
    void undent() {
        lmargin = lmargin - width;
    }

    Hashtable<String,String> currentUsings = new Hashtable<String,String>();
    static Hashtable<String, String> replaceTable;
    static LinkedList<String> valueTypes;
    Arguments arguments;
    
    static{
        initialize();
    }

    static void initialize(){
        // table for simple strings that are secure to direct replace
        replaceTable = new Hashtable<String, String>();
        replaceTable.put("String", "string");
        replaceTable.put("super", "base");
        
        // Meta D++ keywords
        replaceTable.put("NULL", "@NULL"); //NULL
        replaceTable.put("null", "@null"); //null
        replaceTable.put("FALSE", "@FALSE"); //FALSE
        replaceTable.put("false", "@false"); //false
        replaceTable.put("TRUE", "@TRUE"); //TRUE
        replaceTable.put("true", "@true"); //true
        replaceTable.put("import", "@import"); //import
        replaceTable.put("using", "@using"); //using
        replaceTable.put("identifiers", "@identifiers"); //identifiers
        replaceTable.put("alias", "@alias"); //alias
        replaceTable.put("namespace", "@namespace"); //namespace
        replaceTable.put("class", "@class"); //class
        replaceTable.put("enum", "@enum"); //enum
        replaceTable.put("union", "@union"); //union
        replaceTable.put("interface", "@interface"); //interface
        replaceTable.put("inherits", "@inherits"); //inherits
        replaceTable.put("implements", "@implements"); //implements
        replaceTable.put("virtual", "@virtual"); //virtual
        replaceTable.put("nonvirtual", "@nonvirtual"); //nonvirtual
        replaceTable.put("like", "@like"); //like
        replaceTable.put("setplatforms", "@setplatforms"); //setplatforms
        replaceTable.put("autoinstance", "@autoinstance"); //autoinstance
        replaceTable.put("bycall", "@bycall"); //bycall
        replaceTable.put("byclass", "@byclass"); //byclass
        replaceTable.put("bynamespace", "@bynamespace"); //bynamespace
        replaceTable.put("bycallto", "@bycallto"); //bycallto
        replaceTable.put("fp", "@fp"); //fp
        replaceTable.put("public", "@public"); //public
        replaceTable.put("protected", "@protected"); //protected
        replaceTable.put("private", "@private"); //private
        replaceTable.put("ipublic", "@ipublic"); //ipublic
        replaceTable.put("iprotected", "@iprotected"); //iprotected
        replaceTable.put("iprivate", "@iprivate"); //iprivate
        replaceTable.put("static", "@static"); //static
        replaceTable.put("const", "@const"); //const
        replaceTable.put("volatile", "@volatile"); //volatile
        replaceTable.put("extern", "@extern"); //extern
        replaceTable.put("force", "@force"); //force
        replaceTable.put("factory", "@factory"); //factory
        replaceTable.put("interactive", "@interactive"); //interactive
        replaceTable.put("keyword", "@keyword"); //keyword
        replaceTable.put("final", "@final"); //final
        replaceTable.put("new", "@new"); //new
        replaceTable.put("override", "@override"); //override
        replaceTable.put("abstract", "@abstract"); //abstract
        replaceTable.put("params", "@params"); //params
        replaceTable.put("in", "@in"); //in
        replaceTable.put("out", "@out"); //out
        replaceTable.put("inout", "@inout"); //inout
        replaceTable.put("ref", "@ref"); //ref
        replaceTable.put("extension", "@extension"); //extension
        replaceTable.put("ordinary", "@ordinary"); //ordinary
        replaceTable.put("struct", "@struct"); //struct
        replaceTable.put("operator", "@operator"); //operator
        replaceTable.put("indexer", "@indexer"); //indexer
        replaceTable.put("property", "@property"); //property
        replaceTable.put("get", "@get"); //get
        replaceTable.put("readonly", "@readonly"); //readonly
        replaceTable.put("blocktofactorys", "@blocktofactorys"); //blocktofactorys
        replaceTable.put("except", "@except"); //except
        replaceTable.put("set", "@set"); //set
        replaceTable.put("resume", "@resume"); //resume
        replaceTable.put("break", "@break"); //break
        replaceTable.put("continue", "@continue"); //continue
        replaceTable.put("writecode", "@writecode"); //writecode
        replaceTable.put("if", "@if"); //if
        replaceTable.put("else", "@else"); //else
        replaceTable.put("while", "@while"); //while
        replaceTable.put("do", "@do"); //do
        replaceTable.put("for", "@for"); //for
        replaceTable.put("foreach", "@foreach"); //foreach
        replaceTable.put("switch", "@switch"); //switch
        replaceTable.put("case", "@case"); //case
        replaceTable.put("default", "@default"); //default
        replaceTable.put("return", "@return"); //return
        replaceTable.put("throw", "@throw"); //throw
        replaceTable.put("try", "@try"); //try
        replaceTable.put("catch", "@catch"); //catch
        replaceTable.put("finally", "@finally"); //finally
        replaceTable.put("delete", "@delete"); //delete
        replaceTable.put("bool", "@bool"); //bool
        replaceTable.put("void", "@void"); //void
        replaceTable.put("object", "@object"); //object
        replaceTable.put("sbyte", "@sbyte"); //sbyte
        replaceTable.put("short", "@short"); //short
        replaceTable.put("int", "@int"); //int
        replaceTable.put("long", "@long"); //long
        replaceTable.put("unsigned", "@unsigned"); //unsigned
        replaceTable.put("byte", "@byte"); //byte
        replaceTable.put("ushort", "@ushort"); //ushort
        replaceTable.put("uint", "@uint"); //uint
        replaceTable.put("ulong", "@ulong"); //ulong
        replaceTable.put("float", "@float"); //float
        replaceTable.put("double", "@double"); //double
        replaceTable.put("decimal", "@decimal"); //decimal
        replaceTable.put("char", "@char"); //char
        replaceTable.put("ASCIIChar", "@ASCIIChar"); //ASCIIChar
        replaceTable.put("string", "@string"); //string
        replaceTable.put("ASCIIString", "@ASCIIString"); //ASCIIString
        replaceTable.put("type", "@type"); //type
        replaceTable.put("block", "@block"); //block
        replaceTable.put("expression", "@expression"); //expression
        replaceTable.put("exp", "@exp"); //exp
        replaceTable.put("expressionlist", "@expressionlist"); //expressionlist
        replaceTable.put("iname", "@iname"); //iname
        replaceTable.put("statement", "@statement"); //statement
        replaceTable.put("sizeof", "@sizeof"); //sizeof
        replaceTable.put("typeof", "@typeof"); //typeof
        replaceTable.put("gettype", "@gettype"); //gettype
        replaceTable.put("exec", "@exec"); //exec
        replaceTable.put("is", "@is"); //is
        
        // table of types that aren't references
        valueTypes = new LinkedList<String>();
        valueTypes.add("void");
        valueTypes.add("byte");
        valueTypes.add("short");
        valueTypes.add("int");
        valueTypes.add("long");
        valueTypes.add("float");
        valueTypes.add("double");
        valueTypes.add("boolean");
    }
    /** Enter a new precedence level. Emit a `(' if new precedence level
     *  is less than precedence level so far.
     *  @param contextPrec    The precedence level in force so far.
     *  @param ownPrec        The new precedence level.
     */
    void open(int contextPrec, int ownPrec) throws IOException {
        if (ownPrec < contextPrec) out.write("(");
    }

    /** Leave precedence level. Emit a `(' if inner precedence level
     *  is less than precedence level we revert to.
     *  @param contextPrec    The precedence level we revert to.
     *  @param ownPrec        The inner precedence level.
     */
    void close(int contextPrec, int ownPrec) throws IOException {
        if (ownPrec < contextPrec) out.write(")");
    }

    /** Print string, replacing all non-ascii character with unicode escapes.
     */
    public void print(Object s) throws IOException {
        out.write(Convert.escapeUnicode(s.toString()));
    }

    /** Print new line.
     */
    public void println() throws IOException {
        out.write(lineSep);
    }

    String lineSep = System.getProperty("line.separator");

    /**************************************************************************
     * Traversal methods
     *************************************************************************/

    /** Exception to propogate IOException through visitXXX methods */
    private static class UncheckedIOException extends Error {
        static final long serialVersionUID = -4032692679158424751L;
        UncheckedIOException(IOException e) {
            super(e.getMessage(), e);
        }
    }

    /** Visitor argument: the current precedence level.
     */
    int prec;

    /** Visitor method: print expression tree.
     *  @param prec  The current precedence level.
     */
    public void printExpr(JCTree tree, int prec) throws IOException {
        int prevPrec = this.prec;
        try {
            this.prec = prec;
            if (tree == null) print("/*missing*/");
            else {
                tree.accept(this);
            }
        } catch (UncheckedIOException ex) {
            IOException e = new IOException(ex.getMessage());
            e.initCause(ex);
            throw e;
        } finally {
            this.prec = prevPrec;
        }
    }

    /** Derived visitor method: print expression tree at minimum precedence level
     *  for expression.
     */
    public void printExpr(JCTree tree) throws IOException {
        printExpr(tree, TreeInfo.noPrec);
    }

    com.sun.tools.javac.code.Symbol dummySymbol = new com.sun.tools.javac.code.Symbol.VarSymbol(0, enclClassName, null, null);

    public void printTypeDefExpr(JCTree tree, int prec) throws IOException {
        if(tree instanceof JCFieldAccess){
            ((JCFieldAccess)tree).sym = dummySymbol;
        }
        printExpr(tree, prec);
    }
    public void printTypeDefExpr(JCTree tree) throws IOException {
        printTypeDefExpr(tree, TreeInfo.noPrec);
    }

    /** Derived visitor method: print statement tree.
     */
    public void printStat(JCTree tree) throws IOException {
        printExpr(tree, TreeInfo.notExpression);
    }

    /** Derived visitor method: print list of expression trees, separated by given string.
     *  @param sep the separator string
     */
    public <T extends JCTree> void printExprs(List<T> trees, String sep) throws IOException {
        if (trees.nonEmpty()) {
            printExpr(trees.head);
            for (List<T> l = trees.tail; l.nonEmpty(); l = l.tail) {
                print(sep);
                printExpr(l.head);
            }
        }
    }

    /** Derived visitor method: print list of expression trees, separated by commas.
     */
    public <T extends JCTree> void printExprs(List<T> trees) throws IOException {
        printExprs(trees, ", ");
    }

    public <T extends JCTree> void printTypeDefExprs(List<T> trees, String sep) throws IOException {
        if (trees.nonEmpty()) {
            printTypeDefExpr(trees.head);
            for (List<T> l = trees.tail; l.nonEmpty(); l = l.tail) {
                print(sep);
                printTypeDefExpr(l.head);
            }
        }
    }
    public <T extends JCTree> void printTypeDefExprs(List<T> trees) throws IOException {
        printTypeDefExprs(trees, ", ");
    }

    /** Derived visitor method: print list of statements, each on a separate line.
     */
    public void printStats(List<? extends JCTree> trees) throws IOException {
        for (List<? extends JCTree> l = trees; l.nonEmpty(); l = l.tail) {
            align();
            printStat(l.head);
            println();
        }
    }

    /** Print a set of modifiers.
     */
    public void printFlags(long flags) throws IOException {
        if ((flags & SYNTHETIC) != 0) print("/*synthetic*/ ");
        String flagsStr = getMetaDppFlag(flags);
        print(flagsStr);
        if ((flags & StandardFlags) != 0) print(" ");
        if ((flags & ANNOTATION) != 0) print("@");
    }

    static final long ISCLASS = 1<<50;
    private String getMetaDppFlag(long mask){
        String flagsStr = "";
        boolean accessMarked = false;
        if ((mask&PUBLIC) != 0 && (mask&ISCLASS) !=0){
            flagsStr += "PUBLIC ";
            accessMarked = true;
        }
        else if ((mask&PUBLIC) != 0) flagsStr += "PUBLIC: ";

        if ((mask&PRIVATE) != 0 && (mask&ISCLASS) !=0){
            flagsStr += "PRIVATE ";
            accessMarked = true;
        }
        else if ((mask&PRIVATE) != 0) flagsStr += "PRIVATE: ";

        if ((mask&PROTECTED) != 0 && (mask&ISCLASS) !=0){
            flagsStr += "PROTECTED ";
            accessMarked = true;
        }
        else if ((mask&PROTECTED) != 0 ) flagsStr += "PROTECTED: ";

        // if it's a class and access was not marked
        if(accessMarked==false && (mask&ISCLASS)== ISCLASS){
            flagsStr += "PUBLIC ";
        }
        
        if ((mask&STATIC) != 0) flagsStr += "STATIC ";
        if ((mask&FINAL) != 0 && (mask&ISCLASS) ==0) flagsStr += "CONST ";
        if ((mask&SYNCHRONIZED) != 0) flagsStr += "/*SYNCHRONIZED*/";
        if ((mask&VOLATILE) != 0) flagsStr += "VOLATILE ";
        if ((mask&TRANSIENT) != 0) flagsStr += "/*TRANSIENT*/";
        if ((mask&NATIVE) != 0) flagsStr += "/*NATIVE*/";
        if ((mask&INTERFACE) != 0) flagsStr += "INTERFACE ";
        if ((mask&ABSTRACT) != 0) flagsStr += "ABSTRACT ";
        if ((mask&STRICTFP) != 0) flagsStr += "/*STRICTFP*/";
        if ((mask&BRIDGE) != 0) flagsStr += "/*BRIDGE*/";
        if ((mask&SYNTHETIC) != 0) flagsStr += "/*SYNTHETIC*/";
        if ((mask&DEPRECATED) != 0) flagsStr += "/*DEPRECATED*/";
        //if ((mask&HASINIT) != 0) flagsStr += "/*HASINIT*/";
        if ((mask&ENUM) != 0) flagsStr += "ENUM ";
        if ((mask&IPROXY) != 0) flagsStr += "/*IPROXY*/";
        if ((mask&NOOUTERTHIS) != 0) flagsStr += "/*NOOUTERTHIS*/";
        if ((mask&EXISTS) != 0) flagsStr += "/*EXISTS*/";
        if ((mask&COMPOUND) != 0) flagsStr += "/*COMPOUND*/";
        if ((mask&CLASS_SEEN) != 0) flagsStr += "/*CLASS_SEEN*/";
        if ((mask&SOURCE_SEEN) != 0) flagsStr += "/*SOURCE_SEEN*/";
        if ((mask&LOCKED) != 0) flagsStr += "/*LOCKED*/";
        if ((mask&UNATTRIBUTED) != 0) flagsStr += "/*UNATTRIBUTED*/";
        if ((mask&ANONCONSTR) != 0) flagsStr += "/*ANONCONSTR*/";
        if ((mask&ACYCLIC) != 0) flagsStr += "/*ACYCLIC*/";
        //if ((mask&PARAMETER) != 0) flagsStr += "/*PARAMETER*/";
        if ((mask&VARARGS) != 0) flagsStr += "params ";
        if(flagsStr.length()>1 && flagsStr.charAt(flagsStr.length()-1)==' ')flagsStr = flagsStr.substring(0, flagsStr.length()-1);
        return flagsStr.toLowerCase(java.util.Locale.US);
    }

    public void printAnnotations(List<JCAnnotation> trees) throws IOException {
        for (List<JCAnnotation> l = trees; l.nonEmpty(); l = l.tail) {
            print("zoe::java::lang::Java::Annotation( ");
            printStat(l.head);
            print(" );");
            println();
            align();
        }
    }

    /** Print documentation comment, if it exists
     *  @param tree    The tree for which a documentation comment should be printed.
     */
    public void printDocComment(JCTree tree) throws IOException {
        if (docComments != null) {
            String dc = docComments.get(tree);
            if (dc != null) {
                print("/**"); println();
                int pos = 0;
                int endpos = lineEndPos(dc, pos);
                while (pos < dc.length()) {
                    align();
                    print(" *");
                    if (pos < dc.length() && dc.charAt(pos) > ' ') print(" ");
                    print(dc.substring(pos, endpos)); println();
                    pos = endpos + 1;
                    endpos = lineEndPos(dc, pos);
                }
                align(); print(" */"); println();
                align();
            }
        }
    }
//where
    static int lineEndPos(String s, int start) {
        int pos = s.indexOf('\n', start);
        if (pos < 0) pos = s.length();
        return pos;
    }

    /** If type parameter list is non-empty, print it enclosed in "<...>" brackets.
     */
    public void printTypeParameters(List<JCTypeParameter> trees) throws IOException {
        if (trees.nonEmpty()) {
            print("<");
            printExprsParameters(trees);
            print(">");
        }
    }
    public <T extends JCTree> void printExprsParameters(List<T> trees) throws IOException {
        printExprs(trees, ", ");
    }

    /** Print a block.
     */
    public void printBlock(List<? extends JCTree> stats, boolean isClass) throws IOException {
        print("{");
        println();
        indent();
        if(isClass){
            if(arguments.isOptionTrue(Arguments.GENERATE_CLASSPROPERTY)){
                this.align();
                print("extern static Java::java::lang::Class^ property @class{ get; }");
                println();
            }
            if(arguments.isOptionTrue(Arguments.GENERATE_TOSTRING)){
                this.align();
                print("extern string^ toString();");
                println();
            }
        }
        printStats(stats);
        undent();
        align();
        print("}");
    }

    /** Print a block.
     */
    public void printEnumBody(List<JCTree> stats) throws IOException {
        print("{");
        println();
        indent();
        boolean first = true;
        for (List<JCTree> l = stats; l.nonEmpty(); l = l.tail) {
            if (isEnumerator(l.head)) {
                if (!first) {
                    print(",");
                    println();
                }
                align();
                printStat(l.head);
                first = false;
            }
        }
        print(";");
        println();
        for (List<JCTree> l = stats; l.nonEmpty(); l = l.tail) {
            if (!isEnumerator(l.head)) {
                align();
                printStat(l.head);
                println();
            }
        }
        undent();
        align();
        print("}");
    }

    /** Is the given tree an enumerator definition? */
    boolean isEnumerator(JCTree t) {
        return t.getTag() == JCTree.VARDEF && (((JCVariableDecl) t).mods.flags & ENUM) != 0;
    }

    /** Print unit consisting of package clause and import statements in toplevel,
     *  followed by class definition. if class definition == null,
     *  print all definitions in toplevel.
     *  @param tree     The toplevel tree
     *  @param cdef     The class definition, which is assumed to be part of the
     *                  toplevel tree.
     */
    public void printUnit(JCCompilationUnit tree, JCClassDecl cdef) throws IOException {
        docComments = tree.docComments;
        printDocComment(tree);

//        if (tree.pid != null) {
//            print("package ");
//            printExpr(tree.pid);
//            print(";");
//            println();
//        }

        print("using zoe::java::lang;");
        println();
        print("using Java;");
        print("using Java::java::lang;");
        println();
        
        boolean firstImport = true;
        for (List<JCTree> l = tree.defs;
        l.nonEmpty() && (cdef == null || l.head.getTag() == JCTree.IMPORT);
        l = l.tail) {
            if (l.head.getTag() == JCTree.IMPORT) {
                JCImport imp = (JCImport)l.head;
                Name name = TreeInfo.name(imp.qualid);
                if (name == name.table.names.asterisk ||
                        cdef == null ||
                        isUsed(TreeInfo.symbol(imp.qualid), cdef)) {
                    if (firstImport) {
                        firstImport = false;
                        println();
                    }
                    printStat(imp);
                }
            } else {
                if(l.head.getTag() == JCTree.CLASSDEF){
                    println();
                    print("namespace Java::");
                    printTypeDefExpr(tree.pid);
                    print(" {");
                    println();
                    indent();
                    printStat(l.head);
                    undent();
                    println();
                    print("}");
                    println();
                }
                else{
                    printStat(l.head);
                }
            }
        }
        if (cdef != null) {
            printStat(cdef);
            println();
        }
    }
    // where
    boolean isUsed(final Symbol t, JCTree cdef) {
        class UsedVisitor extends TreeScanner {
            public void scan(JCTree tree) {
                if (tree!=null && !result) tree.accept(this);
            }
            boolean result = false;
            public void visitIdent(JCIdent tree) {
                if (tree.sym == t) result = true;
            }
        }
        UsedVisitor v = new UsedVisitor();
        v.scan(cdef);
        return v.result;
    }

    /**************************************************************************
     * Visitor methods
     *************************************************************************/

    public void visitTopLevel(JCCompilationUnit tree) {
        try {
            printUnit(tree, null);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitImport(JCImport tree) {
        try {
            if (tree.staticImport){
                print("/*static*/ ");
                Main.addWarning("Java static import not equivalent on Meta D++", tree);
            }
            // print import clause
            if(!this.arguments.isOptionTrue(Arguments.DONOT_GENERATE_IMPORTS)){
                print("import \"");
                printExpr(tree.qualid);
                print ("\", \"platform=Java\", \"ns=Java\";");
                println();
            }
            // print using
            String tempUsing = tree.getQualifiedIdentifier().toString().replace(".", "::");
            if(tempUsing.endsWith("*")){
                tempUsing = tempUsing.substring(0, tempUsing.length()-2);
                if(!this.currentUsings.containsKey(tempUsing)){
                    print("using Java::");
                    print(tempUsing);
                    print(";");
                    println();
                    this.currentUsings.put(tempUsing, tempUsing);
                }
            }
            else{
                int index = tempUsing.lastIndexOf(":");
                String originalTempUsing = tempUsing;
                if(index>0){
                    tempUsing = tempUsing.substring(0, index - 1);
                }
                if(!this.currentUsings.containsKey(tempUsing)){
                    // print("using Java::");
                    // print(originalTempUsing);
                    // print(";");
                    // println();
                    print("using Java::");
                    print(tempUsing);
                    print(";");
                    println();
                    this.currentUsings.put(tempUsing, tempUsing);
                }
            }
            // printTypeDefExpr(tree.getQualifiedIdentifier());
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitClassDef(JCClassDecl tree) {
        try {
            println(); align();
            printDocComment(tree);
            printAnnotations(tree.mods.annotations);
            tree.mods.flags = tree.mods.flags | ISCLASS;
            
            printFlags(tree.mods.flags & ~INTERFACE);
            Name enclClassNamePrev = enclClassName;
            enclClassName = tree.name;
            if ((tree.mods.flags & INTERFACE) != 0) {
                print("interface " + this.getIdentifier(tree.name));
                printTypeParameters(tree.typarams);
                if (tree.implementing.nonEmpty()) {
                    print(" inherits ");
                    printTypeDefExprs(tree.implementing);
                }
            } else {
                if ((tree.mods.flags & ENUM) != 0)
                    print("enum " + this.getIdentifier(tree.name));
                else
                    print("class " + this.getIdentifier(tree.name));
                printTypeParameters(tree.typarams);
                if (tree.extending != null) {
                    print(" inherits ");
                    printTypeDefExpr(tree.extending);
                }
                if (tree.implementing.nonEmpty()) {
                    print(" implements ");
                    printTypeDefExprs(tree.implementing);
                }
            }
            print(" ");
            if ((tree.mods.flags & ENUM) != 0) {
                printEnumBody(tree.defs);
            } else {
                printBlock(tree.defs, true);
            }
            enclClassName = enclClassNamePrev;
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitMethodDef(JCMethodDecl tree) {
        try {
            // when producing source output, omit anonymous constructors
            if (tree.name == tree.name.table.names.init &&
                    enclClassName == null &&
                    sourceOutput) return;
            println(); align();
            printDocComment(tree);
            printExpr(tree.mods);
            printTypeParameters(tree.typarams);
            if (tree.name == tree.name.table.names.init) {
                print(this.getIdentifier( enclClassName != null ? enclClassName : tree.name ) );
            } else {
                printTypeDefExpr(tree.restype);
                printReference(tree.restype);
                print(" " + this.getIdentifier(tree.name) );
            }
            print("(");
            printExprs(tree.params);
            print(")");
            if (tree.thrown.nonEmpty()) {
                print(" throws ");
                printExprs(tree.thrown);
            }
            if (tree.body != null) {
                print(" ");
                printStat(tree.body);
            } else {
                print(";");
            }
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitVarDef(JCVariableDecl tree) {
        try {
            if (docComments != null && docComments.get(tree) != null) {
                println(); align();
            }
            printDocComment(tree);
            if ((tree.mods.flags & ENUM) != 0) {
                print("/*public static final*/ ");
                print(tree.name);
                if (tree.init != null) {
                    print(" /* = ");
                    printExpr(tree.init);
                    print(" */");
                }
            } else {
                printExpr(tree.mods);
                if ((tree.mods.flags & VARARGS) != 0) {
                    printExpr(((JCArrayTypeTree) tree.vartype).elemtype);
                    print("... " + tree.name);
                } else {
                    printTypeDefExpr(tree.vartype);
                    printReference(tree.vartype);
                    print(" " + tree.name);
                }
                if (tree.init != null) {
                    print(" = ");
                    printExpr(tree.init);
                }
                if (prec == TreeInfo.notExpression) print(";");
            }
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitSkip(JCSkip tree) {
        try {
            print(";");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitBlock(JCBlock tree) {
        try {
            printFlags(tree.flags);
            if ((tree.flags&STATIC) != 0){
                // this is a static constructor
                this.printIdentifier(enclClassName);
                this.print("()");
            }
            printBlock(tree.stats, false);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitDoLoop(JCDoWhileLoop tree) {
        try {
            print("do ");
            printStat(tree.body);
            align();
            print(" while ");
            if (tree.cond.getTag() == JCTree.PARENS) {
                printExpr(tree.cond);
            } else {
                print("(");
                printExpr(tree.cond);
                print(")");
            }
            print(";");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitWhileLoop(JCWhileLoop tree) {
        try {
            print("while ");
            if (tree.cond.getTag() == JCTree.PARENS) {
                printExpr(tree.cond);
            } else {
                print("(");
                printExpr(tree.cond);
                print(")");
            }
            print(" ");
            printStat(tree.body);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitForLoop(JCForLoop tree) {
        try {
            print("for (");
            if (tree.init.nonEmpty()) {
                if (tree.init.head.getTag() == JCTree.VARDEF) {
                    printExpr(tree.init.head);
                    for (List<JCStatement> l = tree.init.tail; l.nonEmpty(); l = l.tail) {
                        JCVariableDecl vdef = (JCVariableDecl)l.head;
                        print(", " + vdef.name + " = ");
                        printExpr(vdef.init);
                    }
                } else {
                    printExprs(tree.init);
                }
            }
            print("; ");
            if (tree.cond != null) printExpr(tree.cond);
            print("; ");
            printExprs(tree.step);
            print(") ");
            printStat(tree.body);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitForeachLoop(JCEnhancedForLoop tree) {
        try {
            print("for (");
            printExpr(tree.var);
            print(" in ");
            printExpr(tree.expr);
            print(") ");
            printStat(tree.body);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitLabelled(JCLabeledStatement tree) {
        try {
            print(tree.label + ": ");
            printStat(tree.body);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitSwitch(JCSwitch tree) {
        try {
            print("switch ");
            if (tree.selector.getTag() == JCTree.PARENS) {
                printExpr(tree.selector);
            } else {
                print("(");
                printExpr(tree.selector);
                print(")");
            }
            print(" {");
            println();
            printStats(tree.cases);
            align();
            print("}");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitCase(JCCase tree) {
        try {
            if (tree.pat == null) {
                print("default");
            } else {
                print("case ");
                printExpr(tree.pat);
            }
            print(": ");
            println();
            indent();
            printStats(tree.stats);
            undent();
            align();
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitSynchronized(JCSynchronized tree) {
        try {
            print("synchronized ");
            if (tree.lock.getTag() == JCTree.PARENS) {
                printExpr(tree.lock);
            } else {
                print("(");
                printExpr(tree.lock);
                print(")");
            }
            print(" ");
            printStat(tree.body);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitTry(JCTry tree) {
        try {
            print("try ");
            printStat(tree.body);
            for (List<JCCatch> l = tree.catchers; l.nonEmpty(); l = l.tail) {
                printStat(l.head);
            }
            if (tree.finalizer != null) {
                print(" finally ");
                printStat(tree.finalizer);
            }
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitCatch(JCCatch tree) {
        try {
            print(" catch (");
            printExpr(tree.param);
            print(") ");
            printStat(tree.body);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitConditional(JCConditional tree) {
        try {
            open(prec, TreeInfo.condPrec);
            printExpr(tree.cond, TreeInfo.condPrec);
            print(" ? ");
            printExpr(tree.truepart, TreeInfo.condPrec);
            print(" : ");
            printExpr(tree.falsepart, TreeInfo.condPrec);
            close(prec, TreeInfo.condPrec);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitIf(JCIf tree) {
        try {
            print("if ");
            if (tree.cond.getTag() == JCTree.PARENS) {
                printExpr(tree.cond);
            } else {
                print("(");
                printExpr(tree.cond);
                print(")");
            }
            print(" ");
            printStat(tree.thenpart);
            if (tree.elsepart != null) {
                print(" else ");
                printStat(tree.elsepart);
            }
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitExec(JCExpressionStatement tree) {
        try {
            printExpr(tree.expr);
            if (prec == TreeInfo.notExpression) print(";");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitBreak(JCBreak tree) {
        try {
            print("break");
            if (tree.label != null) print(" " + tree.label);
            print(";");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitContinue(JCContinue tree) {
        try {
            print("continue");
            if (tree.label != null) print(" " + tree.label);
            print(";");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitReturn(JCReturn tree) {
        try {
            print("return");
            if (tree.expr != null) {
                print(" ");
                printExpr(tree.expr);
            }
            print(";");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitThrow(JCThrow tree) {
        try {
            print("throw ");
            printExpr(tree.expr);
            print(";");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitAssert(JCAssert tree) {
        try {
            print("// assert ");
            printExpr(tree.cond);
            if (tree.detail != null) {
                print(" : ");
                printExpr(tree.detail);
            }
            print(";");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitApply(JCMethodInvocation tree) {
        try {
            if (!tree.typeargs.isEmpty()) {
                if (tree.meth.getTag() == JCTree.SELECT) {
                    JCFieldAccess left = (JCFieldAccess)tree.meth;
                    printExpr(left.selected);
                    print(".<");
                    printExprs(tree.typeargs);
                    print(">" + left.name);
                } else {
                    print("<");
                    printExprs(tree.typeargs);
                    print(">");
                    printExpr(tree.meth);
                }
            } else {
                printExpr(tree.meth);
            }
            print("(");
            printExprs(tree.args);
            print(")");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitNewClass(JCNewClass tree) {
        try {
            if(tree.def!=null) print("zoe::java::lang::Java::AnnonimClass( ");

            if (tree.encl != null) {
                printExpr(tree.encl);
                print(".");
            }
            print("new ");
            if (!tree.typeargs.isEmpty()) {
                print("<");
                printExprs(tree.typeargs);
                print(">");
            }
            printTypeDefExpr(tree.clazz);
            print("(");
            printExprs(tree.args);
            print(")");
            if (tree.def != null) {
                Name enclClassNamePrev = enclClassName;
                enclClassName =
                        tree.def.name != null ? tree.def.name :
                            tree.type != null && tree.type.tsym.name != tree.type.tsym.name.table.names.empty
                                ? tree.type.tsym.name : null;
                if ((tree.def.mods.flags & Flags.ENUM) != 0) print("/*enum*/");
                print(", writecode{ class _Annonim ");
                printBlock(tree.def.defs, false);
                print(" }");
                enclClassName = enclClassNamePrev;
            }
            if(tree.def!=null) print(" )");

        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitNewArray(JCNewArray tree) {
        try {
            if (tree.elemtype != null) {
                print("new ");
                JCTree elem = tree.elemtype;
                if (elem instanceof JCArrayTypeTree)
                    printBaseElementType((JCArrayTypeTree) elem);
                else
                    printTypeDefExpr(elem);
                for (List<JCExpression> l = tree.dims; l.nonEmpty(); l = l.tail) {
                    print("[");
                    printExpr(l.head);
                    print("]");
                }
                if (elem instanceof JCArrayTypeTree)
                    printBrackets((JCArrayTypeTree) elem);
            }
            if (tree.elems != null) {
                if (tree.elemtype != null){
                    print("[] = ");
                }
                print("{");
                printExprs(tree.elems);
                print("}");
            }
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitParens(JCParens tree) {
        try {
            print("(");
            printExpr(tree.expr);
            print(")");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitAssign(JCAssign tree) {
        try {
            open(prec, TreeInfo.assignPrec);
            printExpr(tree.lhs, TreeInfo.assignPrec + 1);
            print(" = ");
            printExpr(tree.rhs, TreeInfo.assignPrec);
            close(prec, TreeInfo.assignPrec);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public String operatorName(int tag) {
        switch(tag) {
            case JCTree.POS:     return "+";
            case JCTree.NEG:     return "-";
            case JCTree.NOT:     return "!";
            case JCTree.COMPL:   return "~";
            case JCTree.PREINC:  return "++";
            case JCTree.PREDEC:  return "--";
            case JCTree.POSTINC: return "++";
            case JCTree.POSTDEC: return "--";
            case JCTree.NULLCHK: return "<*nullchk*>";
            case JCTree.OR:      return "||";
            case JCTree.AND:     return "&&";
            case JCTree.EQ:      return "==";
            case JCTree.NE:      return "!=";
            case JCTree.LT:      return "<";
            case JCTree.GT:      return ">";
            case JCTree.LE:      return "<=";
            case JCTree.GE:      return ">=";
            case JCTree.BITOR:   return "|";
            case JCTree.BITXOR:  return "^";
            case JCTree.BITAND:  return "&";
            case JCTree.SL:      return "<<";
            case JCTree.SR:      return ">>";
            case JCTree.USR:     return ">>>";
            case JCTree.PLUS:    return "+";
            case JCTree.MINUS:   return "-";
            case JCTree.MUL:     return "*";
            case JCTree.DIV:     return "/";
            case JCTree.MOD:     return "%";
            default: throw new Error();
        }
    }

    public void visitAssignop(JCAssignOp tree) {
        try {
            open(prec, TreeInfo.assignopPrec);
            printExpr(tree.lhs, TreeInfo.assignopPrec + 1);
            print(" " + operatorName(tree.getTag() - JCTree.ASGOffset) + "= ");
            printExpr(tree.rhs, TreeInfo.assignopPrec);
            close(prec, TreeInfo.assignopPrec);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitUnary(JCUnary tree) {
        try {
            int ownprec = TreeInfo.opPrec(tree.getTag());
            String opname = operatorName(tree.getTag());
            open(prec, ownprec);
            if (tree.getTag() <= JCTree.PREDEC) {
                print(opname);
                printExpr(tree.arg, ownprec);
            } else {
                printExpr(tree.arg, ownprec);
                print(opname);
            }
            close(prec, ownprec);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitBinary(JCBinary tree) {
        try {
            int ownprec = TreeInfo.opPrec(tree.getTag());
            String opname = operatorName(tree.getTag());
            open(prec, ownprec);
            printExpr(tree.lhs, ownprec);
            print(" " + opname + " ");
            printExpr(tree.rhs, ownprec + 1);
            close(prec, ownprec);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitTypeCast(JCTypeCast tree) {
        try {
            open(prec, TreeInfo.prefixPrec);
            print("(");
            printTypeDefExpr(tree.clazz);
            printReference(tree.clazz);
            print(")");
            printExpr(tree.expr, TreeInfo.prefixPrec);
            close(prec, TreeInfo.prefixPrec);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitTypeTest(JCInstanceOf tree) {
        try {
            open(prec, TreeInfo.ordPrec);
            printExpr(tree.expr, TreeInfo.ordPrec);
            print(" is ");
            printTypeDefExpr(tree.clazz, TreeInfo.ordPrec + 1);
            close(prec, TreeInfo.ordPrec);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitIndexed(JCArrayAccess tree) {
        try {
            printExpr(tree.indexed, TreeInfo.postfixPrec);
            print("[");
            printExpr(tree.index);
            print("]");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitSelect(JCFieldAccess tree) {
        try {
            if(tree.sym!=null){
                printTypeDefExpr(tree.selected, TreeInfo.postfixPrec);
                if(!tree.name.toString().equals("*")){
                    print("::");
                    printIdentifier(tree.name);
                }
            }
            else{
                printExpr(tree.selected, TreeInfo.postfixPrec);
                if(!tree.name.toString().equals("*")){
                    print(".");
                    printIdentifier(tree.name);
                }
            }
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    void printIdentifier(Name name) throws IOException{
        if(replaceTable.containsKey(name.toString())){
            print(replaceTable.get(name.toString()));
        }
        else{
            print(name);
        }    
    }
    private String getIdentifier(Object identifier){
        if(replaceTable.containsKey(identifier.toString())){
            return replaceTable.get(identifier.toString());
        }
        else{
            return identifier.toString();
        }            
    }
    public void visitIdent(JCIdent tree) {
        try {
            printIdentifier(tree.name);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitLiteral(JCLiteral tree) {
        try {
            switch (tree.typetag) {
                case TypeTags.INT:
                    print(tree.value.toString());
                    break;
                case TypeTags.LONG:
                    print(tree.value + "l");
                    break;
                case TypeTags.FLOAT:
                    print(tree.value + "f");
                    break;
                case TypeTags.DOUBLE:
                    print(tree.value.toString());
                    break;
                case TypeTags.CHAR:
                    print("\'" +
                            Convert.quote(
                            String.valueOf((char)((Number)tree.value).intValue())) +
                            "\'");
                    break;
                case TypeTags.BOOLEAN:
                    print(((Number)tree.value).intValue() == 1 ? "true" : "false");
                    break;
                case TypeTags.BOT:
                    print("null");
                    break;
                default:
                    print("\"" + Convert.quote(tree.value.toString()) + "\"");
                    break;
            }
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitTypeIdent(JCPrimitiveTypeTree tree) {
        try {
            switch(tree.typetag) {
                case TypeTags.BYTE:
                    print("byte");
                    break;
                case TypeTags.CHAR:
                    print("char");
                    break;
                case TypeTags.SHORT:
                    print("short");
                    break;
                case TypeTags.INT:
                    print("int");
                    break;
                case TypeTags.LONG:
                    print("long");
                    break;
                case TypeTags.FLOAT:
                    print("float");
                    break;
                case TypeTags.DOUBLE:
                    print("double");
                    break;
                case TypeTags.BOOLEAN:
                    print("bool");
                    break;
                case TypeTags.VOID:
                    print("void");
                    break;
                default:
                    print("__error__");
                    break;
            }
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitTypeArray(JCArrayTypeTree tree) {
        try {
            printBaseElementType(tree);
            printBrackets(tree);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }
    private void printReference(JCTree tree) throws IOException{
        String treeStr = tree.toString();
        if(!valueTypes.contains(treeStr) && treeStr.indexOf('[')<0){
            print("^");
        }
    }
    // Prints the inner element type of a nested array
    private void printBaseElementType(JCArrayTypeTree tree) throws IOException {
        JCTree elem = tree.elemtype;
        while (elem instanceof JCWildcard)
            elem = ((JCWildcard) elem).inner;
        if (elem instanceof JCArrayTypeTree)
            printBaseElementType((JCArrayTypeTree) elem);
        else
            printTypeDefExpr(elem);
        printReference(tree.elemtype);
    }

    // prints the brackets of a nested array in reverse order
    private void printBrackets(JCArrayTypeTree tree) throws IOException {
        JCTree elem;
        while (true) {
            elem = tree.elemtype;
            print("[]");
            if (!(elem instanceof JCArrayTypeTree)) break;
            tree = (JCArrayTypeTree) elem;
        }
    }

    public void visitTypeApply(JCTypeApply tree) {
        try {
            printTypeDefExpr(tree.clazz);
            print("<");
            //printExprs(tree.arguments);
            
            List<JCExpression> trees = tree.arguments;
            if (trees.nonEmpty()) {
                printTypeDefExpr(trees.head);
                this.printReference(trees.head);
                for (List<JCExpression> l = trees.tail; l.nonEmpty(); l = l.tail) {
                    print(", ");
                    printTypeDefExpr(l.head);
                    this.printReference(l.head);
                }
            }
            
            //this.printTypeDefExprs(tree.arguments);
            print(">");
            //this.printReference(tree);
            //print("^");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitTypeParameter(JCTypeParameter tree) {
        try {
            print(tree.name);
            if (tree.bounds.nonEmpty()) {
                print(" extends ");
                printExprs(tree.bounds, " & ");
            }
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    @Override
    public void visitWildcard(JCWildcard tree) {
        try {
            print(tree.kind);
            if (tree.kind.kind != BoundKind.UNBOUND)
                printExpr(tree.inner);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    @Override
    public void visitTypeBoundKind(TypeBoundKind tree) {
        try {
            print(String.valueOf(tree.kind));
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitErroneous(JCErroneous tree) {
        try {
            print("(ERROR)");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitLetExpr(LetExpr tree) {
        try {
            print("(let " + tree.defs + " in " + tree.expr + ")");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitModifiers(JCModifiers mods) {
        try {
            printAnnotations(mods.annotations);
            printFlags(mods.flags);
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitAnnotation(JCAnnotation tree) {
        try {
            print("@");
            printExpr(tree.annotationType);
            print("(");
            printExprs(tree.args);
            print(")");
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public void visitTree(JCTree tree) {
        try {
            print("(UNKNOWN: " + tree + ")");
            println();
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }
}
