package LayerD.CodeDOM;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

import LayerD.CodeDOM.XplParser.ParseException;

public class XplReader{
    private XplParser.Parser parser;
    private XplParser.Token token;
    private ArrayList atributos;
    private int atributoActual;
    private String nombreElemento;
    
    private class NodoLista {
	String nombreAtributo;
	String valor;
	
	public NodoLista(String nombreAtributo, String valor) {
	    this.nombreAtributo = nombreAtributo;
	    this.valor = valor;
	}
    }
        
    /**
     *
     * @param fileName: nombre el archivo XPL.
     * @throws FileNotFoundException
     */
    public XplReader(String fileName) throws FileNotFoundException {
	parser = new XplParser.Parser(fileName);
	parser.tokenizer.trackPosition(true);
	atributos = new ArrayList();
	atributoActual = -1;
    }
    
    /**
     * @return -1 si se llego al fin del archivo o 0 en caso contrario.
     * @throws ParseEsception, IOException
     */
    public int Read() throws  ParseException, IOException {
	atributoActual = -1;
	atributos.clear();
	nombreElemento = "";
	
	token = parser.next();
	if(token != null) {
	    if(token.type() == XplParser.TAG) {
		nombreElemento = token.text();
		
		if(!token.attributes().isEmpty()) {
		    String [] tmpAtrib = new String[token.attributes().keySet().size()];
		    String [] tmpValor = new String[token.attributes().keySet().size()];
		    token.attributes().keySet().toArray(tmpAtrib);
		    token.attributes().values().toArray(tmpValor);
		    
		    for(int i = tmpAtrib.length - 1; i >= 0; i--) {
			atributos.add(new NodoLista(tmpAtrib[i], tmpValor[i]));
			atributos.trimToSize();
		    }
		}
	    }
	    return 0;
	} else {
	    return -1;
	}
    }
    
    /**
     *
     * @return true: si el elemento actual leido por Read() tiene por
     * los menos un atributo definido. false: caso contrario.
     */
    public boolean HasAttributes() {
	return !atributos.isEmpty();
    }
    
    /**
     *
     * @return la cantidad de atributos del elemento actual leido por Read(). Un 0
     * indica que no tiene ningun atributo.
     */
    public int AttributeCount() {
	return atributos.size();
    }
    
    /**
     *
     * @param numeroDeAtributo: numero de atributo al cual deseo moverme
     * para luego obtener su nombre y valor. Su rango de valor debe ser
     * (0 ... cantidad de atributos]
     */
    public void MoveToAttribute(int numeroDeAtributo) {
	if(numeroDeAtributo > 0 && numeroDeAtributo <= atributos.size()) {
	    atributoActual = numeroDeAtributo - 1;
	} else {
	    atributoActual = -1;
	}
    }
    
    /**
     *
     * @return el nombre del ultimo elemento leido o del ultimo
     * atributo seleccionado con MoveToAttribute(). Si hubo
     * algun problema regresa null.
     */
    public String Name() {
	if(atributoActual >= 0) {
	    if(!atributos.isEmpty()) {
		return ((NodoLista)atributos.get(atributoActual)).nombreAtributo;
	    } else {
		return null;
	    }
	} else {
	    return token != null ? token.text() : null;
	}
    }
    
    /**
     * Muestra el valor del ultimo elemento leido o atributo seleccionado.
     *
     * @return el valor del ultimo elemento leido o atributo
     * seleccionado con MoveToAttribute(). Si hubo algun problema regresa null.
     */
    public String Value() {
	if(atributoActual >= 0) {
	    if(!atributos.isEmpty()) {
		return ((NodoLista)atributos.get(atributoActual)).valor;
	    } else {
		return null;
	    }
	} else {
	    return token != null ? token.text() : null;
	}
    }
    
    /**
     *
     *
     */
    public void MoveToElement() {
	atributoActual = -1;
    }
    
    /**
     * Muestra si el elemento actual es uno vacio segun el estandar XML,  es decir
     * tiene el cierre del elemento de la forma /&gt;
     *
     * @return true: si el ultimo elemento leido es un elemento vacio. false: cualquier otro caso.
     */
    public boolean IsEmptyElement() {
	return token.empty();
    }
    
    /**
     * Muestra en numero de linea del actual elemento.
     * @return el nro de lienea del elemento actual leido por Read(). Las
     * lienas son numeradas comenzando en 1. Este metodo regresa 0 si: no
     * se ha llamado nunca a Read() o si se llego a EOF.
     */
    public int LineNumber() {
	return parser.tokenizer.tokenLine();
    }
    
    /**
     * Muestra el numero de columna donde comienza un elemento.
     * @return la columna donde comienza el elemento actual leido por Read(). Las
     * columnas son numeradas comenzando en 1. Este metodo regresa 0 si: no se ha
     * llamado nunca a Read() o si se llego al EOF.
     */
    public int ColumnNumber() {
	return parser.tokenizer.tokenColumn();
    }
    
    /**
     * Muestra que tipo de elemento es el actual. Los tipos pueden ser:
     * ELEMENT (valor entero de 1), TEXT(valor entero de 2) o
     * ENDELEMENT (valor entero de 3).
     *
     * @return 1: si el elemento actual leido por Read() es del tipo ELEMENT.
     * 2: si el elemento actual leido por Read() es del tipo TEXT. 3: si el
     * elemento actual leido por Read() es del tipo ENDELEMENT.
     */
    public int NodeType() {
	if(token.type() == XplParser.TAG) return XmlNodeType.ELEMENT;
	else if(token.type() == XplParser.TEXT) return XmlNodeType.TEXT;
	else return XmlNodeType.ENDELEMENT;
    }
}
