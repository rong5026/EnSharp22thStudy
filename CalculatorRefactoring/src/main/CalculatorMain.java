package main;
import controller.CorrectTextFormat;

import java.math.BigDecimal;

import controller.CalculatorStart;
import view.TextPanel;

public class CalculatorMain {
	
	public static void main(String[] args) {
	
		CalculatorStart calculator = new CalculatorStart();
		calculator.start();
		
		
	
		//String aString = "120.0002";
		
		
		//System.out.println(aString.substring(0,aString.length()));
		//System.out.println(aString.charAt(aString.length()-1));
		
		//if(new BigDecimal("159191591").compareTo(new BigDecimal("0"))==0) {
			//System.out.println("같다");
		//}
		/*
		String resultNumber = "-0.0001000";
		
		BigDecimal integer;
		BigDecimal decimal;
		String result = null;
		
		
	
		if(resultNumber.contains(".")) {
			integer  = new BigDecimal( resultNumber.substring(  0, resultNumber.indexOf(".")  ));
			decimal = new BigDecimal(resultNumber.substring( resultNumber.indexOf("."), resultNumber.length())).stripTrailingZeros();
					
			if(resultNumber.contains("-")) {
				System.out.println( "움수임" + "－"+integer.toString() + decimal.toString().substring(1));
			}
			else {
			System.out.println( integer.toString() + decimal.toString().substring(1));
			}
		}
		else
			System.out.println(resultNumber);
	*/
		
	
		
		
		
		
		
	}
	
	
}
