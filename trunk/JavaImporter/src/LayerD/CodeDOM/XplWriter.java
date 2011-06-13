package LayerD.CodeDOM;

import java.io.FileWriter;
import java.io.BufferedWriter;
import java.io.IOException;
import java.util.Stack;

public class XplWriter {
    private String fileName;
    private BufferedWriter bw;
    private Stack pila;
    private boolean elementoAbierto;
    
    /**
     * Cosntructor por parametros.
     * @param fileName: Nombre del archivo donde escribir.
     * @throws IOException
     */
    public XplWriter(String fileName) throws IOException {
	bw = new BufferedWriter(new FileWriter(fileName));
	pila = new Stack();
	elementoAbierto = false;
    }
    
    /**
     * Obtiene el nombre del archivo donde se esta
     * escribiendo.
     * @return Nombre del archivo donde se esta escribiendo.
     */
    public String GetFileName() {
	return fileName;
    }
    
    /**
     * Setea el nombre del archivo donde se va a escribir.
     * @param fileName: Nombre del archivo donde escribir.
     */
    public void SetFileName(String fileName) {
	this.fileName = fileName;
    }
    
    /**
     * Escribe en el archivo una apertura de elemento XML en la forma
     * "&lt;nombreElemento ".
     * @param nombreElemento: Nombre del elemento a escribir.
     * @throws IOException
     */
    public void WriteStartElement(String nombreElemento) throws IOException {
	CerrarElemento();
	pila.push(nombreElemento);
	bw.write("<" + nombreElemento);
	elementoAbierto = true;
    }
    
    /**
     * Escribe en el archivo un atributo con su valor
     * para el ultimo elemento escrito en el archivo.
     * @param nombreAtributo: Nombre del atributo a escribir.
     * @param valorAtributo: Valor del atributo.
     * @throws IOException
     */
    public void WriteAttributeString(String nombreAtributo, String valorAtributo) throws IOException {
	bw.write(" " + nombreAtributo + "=\"" + Escapar(valorAtributo) + "\"");
    }
    
    /**
     * Escribe un elemento de terminacion XML de la forma
     * "&lt;/nombreElemento&gt;" asegurandose de que realemnte
     * haya un elemento creado para terminar. Si no lo hubiera
     * no se escribe nada en el archivo.
     * @throws IOException
     */
    public void WriteEndElement() throws IOException {
	CerrarElemento();
	if(!pila.isEmpty()) bw.write("</" + (String)pila.pop() + ">");
    }
    
    /**
     * Escribe un elemento en el archivo con la sigueinte forma
     * "&lt;nombreElemento&gt;valorElemnto&lt;/nombreElemnto&gt;".
     * @param nombreElemento: Nombre del elemento a escribir.
     * @param valorElemento: Valor del elemento a escribir.
     * @throws IOException
     */
    public void WriteElementString(String nombreElemento, String valorElemento) throws IOException {
	CerrarElemento();
	bw.write("<" + nombreElemento + ">" + Escapar(valorElemento) + "</" + nombreElemento + ">");
    }
    
    /**
     * Cierra este Stream y los subyacientes.
     * @throws IOException
     */
    public void Close() throws IOException {
	bw.close();
    }
    
    /**
     * Si el ultimo elemento abierto no fue cerrado,
     * lo cierra con "&gt;" y agregando un fin de liena
     * y escribiendolos en el archivo.
     * @throws IOException
     */
    private void CerrarElemento() throws IOException {
	if(elementoAbierto) {
	    bw.write(">");
	    elementoAbierto = false;
	}
    }
    
    /**
     * Reemplaza los caracteras &, ', ", &lt; y &gt; por las
     * entidades de escape de XML correspondientes.
     * @param valorAtributo: string a formatear.
     * @return string con los caracteres reemplazados por las
     * entidades de escape correspondientes.
     */
    private String Escapar(String valorAtributo) {
	String str = valorAtributo;
	
	str = valorAtributo.replaceAll("&", "&amp;");
	str = str.replaceAll("'", "&apos;");
	str = str.replaceAll("\"", "&quot;");
	str = str.replaceAll("<", "&lt;");
	str = str.replaceAll(">", "&gt;");
	
	return str;
    }
}
