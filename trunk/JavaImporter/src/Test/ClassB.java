package Test;

public class ClassB {
	volatile char atribCharVolatile;
	static long atribLongStatic;
	final int atribIntFinal = 0;
	static final short atribShortStaticFinal = 0;
	boolean atribBoolean;
	long []atribLongArrayUnaDimension;
	InterfaceA []atribArrayInterfaceA;
	ClassC claseC;
	
	public class internalClass {
		public int attribInternalClass;
		
		public void internalCalss(){
		}
	}
	
	public ClassB() {
	}
	
	private ClassB(long i) {
	}	

	public final InterfaceA metodoFinal()
	{
		ClassC c = new ClassC();
		return c;
	}
	
	public static String metodoStatic(){return null;}
	
	public static final long metodoStaticFinal(){return 0;}
}
