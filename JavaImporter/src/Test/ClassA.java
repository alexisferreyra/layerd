package Test;

public abstract class ClassA {
	volatile ClassB claseB;
	
	public class ClassInternalToA extends Object implements InterfaceA {
		public ClassB claseBdeLaInterna;
		public InterfaceB interfaceBdeLaInterna;
		
		public ClassC returnClassC() {
			return new ClassC();
		}
		
		public int getSurName() {
			return 0;
		}

		public int getName() {
			return 0;
		}

		public int getStreet() {
			return 0;
		}
		
	}
	
	public ClassA() {
	}
	
	public abstract long metodoAbstract(char c);
	
	private char metodoPrivate(boolean a){ return 0; }
	
}
