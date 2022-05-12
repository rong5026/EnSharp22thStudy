

import controller.CalculatorStart;

public class CalculatorMain {

	public static void main(String[] args) {
		
		CalculatorStart calculator = new CalculatorStart();
		calculator.start();

		for(int i = 1 ; i<=16 ;i++)
			System.out.println("수:"+i +"몇개" +i/3);
			
		
		
		
	}

}
