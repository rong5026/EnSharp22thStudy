package controller;

import java.math.BigDecimal;
import java.math.MathContext;

import view.TextPanel;

public class ArithmeticSign {
	
	private String mathSign;
	private BigDecimal result = null;
	private BigDecimal previusDouble;
	private BigDecimal inputDoble;
	
	public void enterArithmeticSign(String input) {
		
		
		if(TextPanel.previousJLabel.getText()!="" && CalculatorStart.inputNumber!="") {
			
			mathSign = 	TextPanel.previousJLabel.getText().substring(TextPanel.previousJLabel.getText().length()-1);
			previusDouble =  new BigDecimal(CalculatorStart.previousNumber);
			inputDoble = new BigDecimal(CalculatorStart.inputNumber); 
			
			switch (mathSign) {
			
			case "÷":							
				result = previusDouble.divide(inputDoble,MathContext.DECIMAL64);				
				break;
			case "×":
				result = previusDouble.multiply(inputDoble,MathContext.DECIMAL64);				
				break;
			case "－":
				result = previusDouble.subtract(inputDoble,MathContext.DECIMAL64);				
				break;
			case "＋":
				result =previusDouble.add(inputDoble,MathContext.DECIMAL64);				
				break;
			case "＝":
						
				break;
		
			default:
				break;
			}
			switch (input) {
			case "÷":	//나누기										
				// 0 나누기 함수넣기
				break;
			case "×":	//곱하기			
				TextPanel.previousJLabel.setText(String.valueOf(result).replace("E","e")+"×");	
				break;
			case "－":	//빼기	
				TextPanel.previousJLabel.setText(String.valueOf(result).replace("E","e")+"－");
				break;
			case "＋":	//더하기
				TextPanel.previousJLabel.setText(String.valueOf(result).replace("E","e")+"＋");	
				break;	
			case "＝":
				// 함수 넣기
				break;
			default:
				break;
			}
			
			//결과값  inputlabel에 저장
			
			TextPanel.inputJLabel.setText((String.valueOf(result).replace("E","e")));
		}
		else {
			switch (input) {
			case "÷":	//나누기										
				TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText().replace("E","e")+"÷");		
				break;
			case "×":	//곱하기		
				TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText().replace("E","e")+"×");		
				break;
			case "－":	//빼기	
				TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText().replace("E","e")+"－");		
				break;
			case "＋":	//더하기
				TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText().replace("E","e")+"＋");		
				break;
			case "＝":							
				TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText().replace("E","e")+"＝");		
				break;
						
			default:
				break;
			}
			
			//이전값에 입력값 넣음  -23,223  ->-23223 을 넣음
			CalculatorStart.previousNumber =TextPanel.previousJLabel.getText().substring(0,TextPanel.previousJLabel.getText().length()-1).replace(",", "");
			
		}
		//입력값초기화
		CalculatorStart.inputNumber ="";
		
		

		System.out.println(CalculatorStart.inputNumber);			
		System.out.println(CalculatorStart.previousNumber);	
		System.out.println(TextPanel.inputJLabel.getText());
		System.out.println(TextPanel.previousJLabel.getText());
		
	}
	
	
	private void setPreviousLabel(String input) {
		
		switch (input) {
	
		case "×":	//곱하기		
			TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText().replace("E","e")+"×");		
			break;
		case "－":	//빼기	
			TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText().replace("E","e")+"－");		
			break;
		case "＋":	//더하기
			TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText().replace("E","e")+"＋");		
			break;
			
		default:
			break;
		}
		
	}
}
