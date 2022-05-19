package controller;

import java.math.BigDecimal;
import java.math.MathContext;

import view.TextPanel;

public class ArithmeticSign {
	
	private String mathSign;
	private BigDecimal result = null;
	private BigDecimal previusDouble;
	private BigDecimal inputDoble;
	private CorrectTextFormat correctTextFormat;
	
	public ArithmeticSign() {
		correctTextFormat = new CorrectTextFormat();
	}
	
	
	public void enterArithmeticSign(String input) {
		
		
		if(TextPanel.previousJLabel.getText()!="" && CalculatorStart.inputNumber!="") {
			
			mathSign = 	TextPanel.previousJLabel.getText().substring(TextPanel.previousJLabel.getText().length()-1);
			previusDouble =  new BigDecimal(CalculatorStart.previousNumber);
			inputDoble = new BigDecimal(CalculatorStart.inputNumber); 
			
			calculateArithmeticSign(input);
		}
		else {
			switch (input) {
			case "÷":	//나누기										
				TextPanel.previousJLabel.setText(  correctTextFormat.setCorrectPreviousPanel( TextPanel.inputJLabel.getText())+"÷");		
				CalculatorStart.previousNumber =TextPanel.previousJLabel.getText().substring(0,TextPanel.previousJLabel.getText().length()-1);
				break;
			case "×":	//곱하기		
				TextPanel.previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel( TextPanel.inputJLabel.getText())+"×");		
				CalculatorStart.previousNumber =TextPanel.previousJLabel.getText().substring(0,TextPanel.previousJLabel.getText().length()-1).replace(",", "");
				break;
			case "－":	//빼기	
				TextPanel.previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel( TextPanel.inputJLabel.getText())+"－");		
				CalculatorStart.previousNumber =TextPanel.previousJLabel.getText().substring(0,TextPanel.previousJLabel.getText().length()-1).replace(",", "");
				break;
			case "＋":	//더하기
				TextPanel.previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel( TextPanel.inputJLabel.getText())+"＋");		
				CalculatorStart.previousNumber =TextPanel.previousJLabel.getText().substring(0,TextPanel.previousJLabel.getText().length()-1).replace(",", "");
				break;
			case "＝":	
				calculateEqual();
				
				break;
						
			default:
				break;
			}
			

		}
		//입력값초기화
		CalculatorStart.inputNumber ="";
		
		
		System.out.println(CalculatorStart.inputNumber);			
		System.out.println(CalculatorStart.previousNumber);	
		System.out.println(TextPanel.inputJLabel.getText());
		System.out.println(TextPanel.previousJLabel.getText());
		
	}
	
	private void calculateEqual() { // = 계산
		
	
		String previousJLabelText;
		previousJLabelText = TextPanel.previousJLabel.getText();
		
		if(previousJLabelText.contains("÷")==false &&previousJLabelText.contains("×")==false && previousJLabelText.contains("－")==false&&previousJLabelText.contains("＋")==false) {
			TextPanel.previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel( TextPanel.inputJLabel.getText())+"＝");		
			CalculatorStart.previousNumber =TextPanel.previousJLabel.getText().substring(0,TextPanel.previousJLabel.getText().length()-1).replace(",", "");
		}
	
		else {
			previusDouble =  new BigDecimal(correctTextFormat.setCorrectPreviousPanel(TextPanel.inputJLabel.getText()).replace("e", "E") );
			
	
			if( getArithmeticSignCount( TextPanel.previousJLabel.getText()) == 1) { // 9X 처럼 연산자가 1개있을때는 처음으로 시작
				mathSign = 	TextPanel.previousJLabel.getText().substring(TextPanel.previousJLabel.getText().length()-1);		
				inputDoble =  new BigDecimal(correctTextFormat.setCorrectPreviousPanel(TextPanel.inputJLabel.getText()).replace("e", "E")  ); 
					
			}
			else {
			
				
				if(previousJLabelText.contains("÷")) {
					mathSign  ="÷";
					
					inputDoble = new BigDecimal(TextPanel.previousJLabel.getText().replace("e", "E").substring( TextPanel.previousJLabel.getText().lastIndexOf("÷")+1 , TextPanel.previousJLabel.getText().length()-1)); 
				}
				else if( previousJLabelText.contains("×") ) {
					mathSign  ="×";
					inputDoble = new BigDecimal(TextPanel.previousJLabel.getText().replace("e", "E").substring( TextPanel.previousJLabel.getText().lastIndexOf("×")+1 ,TextPanel.previousJLabel.getText().length()-1)); 
				}
				else if( previousJLabelText.contains("－") ) {
					mathSign  ="－";
					inputDoble = new BigDecimal(TextPanel.previousJLabel.getText().replace("e", "E").substring( TextPanel.previousJLabel.getText().lastIndexOf("－")+1 ,TextPanel.previousJLabel.getText().length()-1)); 
				}
				else if(previousJLabelText.contains("＋")) {
					mathSign  ="＋";
					inputDoble = new BigDecimal(TextPanel.previousJLabel.getText().replace("e", "E").substring( TextPanel.previousJLabel.getText().lastIndexOf("＋")+1 , TextPanel.previousJLabel.getText().length()-1)); 
				}
				
	
			}
			
		
		
			calculateArithmeticSign("＝");	
		}		
	}
	
	
	
	private BigDecimal calculateArithmeticSign(String input) { // 연산자 계산
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
			TextPanel.previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"×");	
			break;
		case "－":	//빼기	
			TextPanel.previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"－");
			break;
		case "＋":	//더하기
			TextPanel.previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"＋");	
			break;	
		case "＝":
			TextPanel.previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(String.valueOf(previusDouble))  + mathSign  +inputDoble +"＝");	
			break;
		default:
			break;
		}
		
		//결과값  inputlabel에 저장
		
		TextPanel.inputJLabel.setText( correctTextFormat.setCorrectInputPanel(String.valueOf(result)));
		//이전값에 결과값넣음
		CalculatorStart.previousNumber = String.valueOf(result);
		return result;
	}
	
	private int getArithmeticSignCount(String previousLabelText) { // 패널에 연산자가 몇개있는지 확인
		
		int count = 0;
		
		if(previousLabelText.contains("×"))
			count++;
		if(previousLabelText.contains("－"))
			count++;
		if(previousLabelText.contains("＋"))
			count++;
		if(previousLabelText.contains("÷"))
			count++;
		if(previousLabelText.contains("＝"))
			count++;
		
		return count;
	}
}
