package main;
import controller.CorrectTextFormat;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.text.DecimalFormat;

import controller.CalculatorStart;
import view.TextPanel;

public class CalculatorMain {
	
	public static void main(String[] args) {
	
		CalculatorStart calculator = new CalculatorStart();
		calculator.start();
		
		DecimalFormat formatter = new DecimalFormat("#.#");

	
		//BigDecimal a =new BigDecimal("99999999999999988").setScale(15,RoundingMode.HALF_UP);
		
		//System.out.println(a);

	}
	
	
}
