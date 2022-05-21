package controller;

import java.awt.Font;
import java.awt.geom.RoundRectangle2D;
import java.math.BigDecimal;
import java.math.MathContext;
import java.math.RoundingMode;

import Utility.ConstantNumber;
import view.TextPanel;

public class ArithmeticSign {
	
	public String mathSign;
	private BigDecimal result = null;
	public BigDecimal previusDouble;
	public BigDecimal inputDoble;
	private CorrectTextFormat correctTextFormat;
	
	public ArithmeticSign() {
		correctTextFormat = new CorrectTextFormat();
	}
	
	
	public void enterArithmeticSign(String input) {
	
		if(CalculatorStart.errorType == ConstantNumber.NON_ERROR) {
			if(TextPanel.previousJLabel.getText()!="" && CalculatorStart.inputNumber!="" && TextPanel.previousJLabel.getText().charAt(TextPanel.previousJLabel.getText().length()-1) != '＝') {
				
				mathSign = 	TextPanel.previousJLabel.getText().substring(TextPanel.previousJLabel.getText().length()-1);
				previusDouble =  new BigDecimal(CalculatorStart.previousNumber.replace("e", "E"));
				inputDoble = new BigDecimal(CalculatorStart.inputNumber.replace("e", "E"));
				
				calculateArithmeticSign(input);
			}
			else {
			
			
				switch (input) {
				case "÷":	//나누기										
					setPreviousValue("÷");
					break;
				case "×":	//곱하기		
					setPreviousValue("×");
					break;
				case "－":	//빼기	
					setPreviousValue("－");
					break;
				case "＋":	//더하기
					setPreviousValue("＋");
					break;
				case "＝":	
					calculateEqual();
					calculateArithmeticSign("＝");	
					break;
							
				default:
					break;
				}
				

			}
			//입력값초기화
		
			CalculatorStart.inputNumber ="";
		
		}
		else {
			CalculatorStart.inputNumber = "";				
			TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));						
			TextPanel.inputJLabel.setText("0");
			CalculatorStart.errorType =ConstantNumber.NON_ERROR;
		}
		
		
			
		System.out.println(CalculatorStart.inputNumber);			
		System.out.println(CalculatorStart.previousNumber);	
		System.out.println(TextPanel.inputJLabel.getText());
		System.out.println(TextPanel.previousJLabel.getText());
		System.out.println(inputDoble);	
		
		CalculatorStart.mainFrame.setFocusable(true);
		CalculatorStart.mainFrame.requestFocus();
		
	}
	
	
	public void setPreviousValue(String mathSign) {
		
		TextPanel.previousJLabel.setText(  correctTextFormat.setCorrectPreviousPanel( TextPanel.inputJLabel.getText())+mathSign);		
		CalculatorStart.previousNumber = correctTextFormat.setCorrectPreviousPanel(TextPanel.inputJLabel.getText());
	}
	
	 // = 계산
	public void calculateEqual() { 
		
	
		String previousJLabelText;
		previousJLabelText = TextPanel.previousJLabel.getText();
		
		if(CalculatorStart.inputNumber!="") {
			previusDouble =  new BigDecimal(correctTextFormat.setCorrectPreviousPanel(CalculatorStart.inputNumber).replace("e", "E"));
		}
		
		if(TextPanel.inputJLabel.getText().equals("0"))
			previusDouble = new BigDecimal("0");
		
		if((previousJLabelText.contains("÷")==false &&previousJLabelText.contains("×")==false && previousJLabelText.contains("－")==false&&previousJLabelText.contains("＋")==false) ) {
			TextPanel.previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel( CalculatorStart.inputNumber)+"＝");		
			CalculatorStart.previousNumber =TextPanel.previousJLabel.getText().substring(0,TextPanel.previousJLabel.getText().length()-1).replace(",", "");

			
		}
	
		else {
			previusDouble =  new BigDecimal(correctTextFormat.setCorrectPreviousPanel(TextPanel.inputJLabel.getText()).replace("e", "E"));
			
	
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
					inputDoble =new BigDecimal(TextPanel.previousJLabel.getText().replace("e", "E").substring( TextPanel.previousJLabel.getText().lastIndexOf("－")+1 ,TextPanel.previousJLabel.getText().length()-1)); 
				}
				else if(previousJLabelText.contains("＋")) {
					mathSign  ="＋";
					inputDoble =new BigDecimal(TextPanel.previousJLabel.getText().replace("e", "E").substring( TextPanel.previousJLabel.getText().lastIndexOf("＋")+1 , TextPanel.previousJLabel.getText().length()-1)); 
				}
				
				
			}
			
			
		}		
		
		
	}
	
	
	
	public void calculateArithmeticSign(String input) { // 연산자 계산
		
		
		if(mathSign!=null && inputDoble!=null && previusDouble!=null) {
			
			
			switch (mathSign) {
			
			case "÷":		
				
				if(inputDoble.compareTo(new BigDecimal("0"))==0) {
					calculateDivision();
					return;
				}
				else {
					result = previusDouble.divide(inputDoble,15,BigDecimal.ROUND_HALF_EVEN);	
					CalculatorStart.previousNumber = previusDouble.divide(inputDoble,16,BigDecimal.ROUND_HALF_EVEN).toString().replace("E", "e");	
				}
				break;
			case "×":
				result = previusDouble.multiply(inputDoble,MathContext.DECIMAL64);//previusDouble.multiply(inputDoble,MathContext.DECIMAL64).setScale(15,RoundingMode.HALF_EVEN);
				CalculatorStart.previousNumber =  String.valueOf( previusDouble.multiply(inputDoble,MathContext.DECIMAL128).setScale(16,RoundingMode.HALF_EVEN)  ).replace("E", "e");
				break;
			case "－":
				result = previusDouble.subtract(inputDoble,MathContext.DECIMAL64);				
				CalculatorStart.previousNumber =  String.valueOf(result).replace("E", "e");
				break;
			case "＋":
				result =previusDouble.add(inputDoble,MathContext.DECIMAL64);
				CalculatorStart.previousNumber =  String.valueOf(result).replace("E", "e");
			
			default:
				break;
			}
		
		}
	
		switch (input) {
		case "÷":	//나누기										
			TextPanel.previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"÷");	
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
			
			if(result==null && inputDoble==null) {
				TextPanel.previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel( CalculatorStart.inputNumber)+"＝");		
				CalculatorStart.previousNumber =TextPanel.previousJLabel.getText().substring(0,TextPanel.previousJLabel.getText().length()-1).replace(",", "");
			}
			else
				TextPanel.previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(String.valueOf(previusDouble))  + mathSign  +correctTextFormat.removeDecimalPoint(inputDoble.toString()) +"＝");
			if(result!=null) {
				System.out.println("result = "+result.toString());
				System.out.println("input = "+inputDoble);
				System.out.println("pre = "+previusDouble);
			}
			break;
		default:
			break;
		}
		

		if(result!=null )
			TextPanel.inputJLabel.setText(   correctTextFormat.setCorrectInputPanel(  correctTextFormat.removeDecimalPoint(String.valueOf(result)))  );
	
		
		
	}
	
	private void calculateDivision() { // 0나누기 오류
		
		if(inputDoble.compareTo(new BigDecimal("0"))==0) {
			TextPanel.inputJLabel.setText("0으로 나눌 수 없습니다");
			CalculatorStart.inputNumber="";
			CalculatorStart.previousNumber="";
			CalculatorStart.errorType = ConstantNumber.ZERO_ERROR;
		}
		else {
			TextPanel.previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"÷");	
		}
	}
	
	public int getArithmeticSignCount(String previousLabelText) { // 패널에 연산자가 몇개있는지 확인
		
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
