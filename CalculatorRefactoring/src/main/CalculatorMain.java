package main;


import java.math.BigDecimal;

import controller.CalculatorStart;
import view.TextPanel;

public class CalculatorMain {

	public static void main(String[] args) {
		
		CalculatorStart calculator = new CalculatorStart();
		calculator.start();
		
		
		//String n = "222.34000020";
		//BigDecimal bigDecimal = new BigDecimal("3000");
		//BigDecimal bigDecimal2 = new BigDecimal(".000000");
		//if(bigDecimal.compareTo(new BigDecimal("0.0"))==0)
		//	System.out.println(bigDecimal);
		//System.out.println(bigDecimal.stripTrailingZeros());
		//System.out.println(bigDecimal2.stripTrailingZeros());
		//System.out.println(bigDecimal.toString());
		
		//System.out.println("1223.23122".indexOf("."));
		
		//System.out.println("1223.23122".substring(5,"1223.23122".length()));
	}
}
