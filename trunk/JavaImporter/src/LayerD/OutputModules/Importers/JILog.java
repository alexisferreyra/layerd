package LayerD.OutputModules.Importers;

import java.io.FileWriter;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

/**
 * Singleton que permite escribir un log en el archivo especificado por la
 * constante JILog.FILENAME.
 *
 * @author Demián
 *
 */
public class JILog {
    private static JILog instance = new JILog();
    private static final String FILENAME = "JavaImporter";
    private FileWriter writer;
    private boolean enabled = true;
    
    private JILog() {
        try {
            Calendar c = Calendar.getInstance();
            DateFormat date = new SimpleDateFormat("dd_MM_yyyy_kk_mm_ss");
            writer = new FileWriter(FILENAME + "_" + date.format(c.getTime()) + ".log");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    
    /**
     * Obtiene la unica instancia posible.
     * @return la instancia de JILog.
     */
    public static JILog getInstance() {
        return instance;
    }
    
    public void enable(boolean enable) {
        enabled = enable;
    }
    
    public void write(String str) {
        if(enabled) {
            try {
                writer.write(str);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
    
    public void writeLine(String str) {
        if(enabled) {
            try {
                writer.write(str + "\n");
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
    
    public void close() {
        try {
            writer.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
