package LayerD.CodeDOM;

import java.io.*;

/**
 * This Tokenizer implementation extends AbstractTokenizer to tokenize a stream
 * of text read from a java.io.Reader.  It implements the createBuffer( ) and
 * fillBuffer( ) methods required by AbstractTokenizer.  See that class for
 * details on how these methods must behave.  Note that a buffer size may
 * be selected, and that this buffer size also determines the maximum token
 * length.  The Test class is a simple test that tokenizes a file and uses
 * the tokens to produce a copy of the file
 **/
public class XplReaderTokenizer extends XplAbstractTokenizer {
    Reader in;

    // Create a ReaderTokenizer with a default buffer size of 16K characters
    public XplReaderTokenizer(Reader in) { this(in, 16*1024); }

    public XplReaderTokenizer(Reader in, int bufferSize) {
        this.in = in;  // Remember the reader to read input from
        // Tell our superclass about the selected buffer size.
        // The superclass will pass this number to createBuffer( )
        maximumTokenLength(bufferSize);
    }

    // Create a buffer to tokenize.
    protected void createBuffer(int bufferSize) {
        // Make sure AbstractTokenizer only calls this method once
        if(text != null){
            System.out.println("Error, text no es null.");
            System.exit(1);
        }
        this.text = new char[bufferSize];  // the new buffer
        this.numChars = 0;                 // how much text it contains
    }

    // Fill or refill the buffer.
    // See AbstractTokenizer.fillBuffer( ) for what this method must do.
    protected boolean fillBuffer( ) throws IOException {
        // Make sure AbstractTokenizer is upholding its end of the bargain
        if(!(text!=null && 0 <= tokenStart && tokenStart <= tokenEnd &&
            tokenEnd <= p && p <= numChars && numChars <= text.length)){
            System.out.println("Estado de AbstractTokenizer invalido."+tokenLine()+","+tokenColumn());
            System.exit(1);
        }

        // First, shift already tokenized characters out of the buffer
        if (tokenStart > 0) {
            // Shift array contents
            System.arraycopy(text, tokenStart, text, 0, numChars-tokenStart);
            // And update buffer indexes
            tokenEnd -= tokenStart; 
            p -= tokenStart;
            numChars -= tokenStart;
            tokenStart = 0; 
        }

        // Now try to read more characters into the buffer
        int numread = in.read(text, numChars, text.length-numChars);
        // If there are no more characters, return false
        if (numread == -1) return false;
        // Otherwise, adjust the number of valid characters in the buffer
        numChars += numread;
        return true;  
    }
}