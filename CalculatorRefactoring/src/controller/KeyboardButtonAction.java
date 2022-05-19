package controller;

import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.math.BigDecimal;
import java.math.MathContext;


import Utility.*;
import view.TextPanel;

public class KeyboardButtonAction implements KeyListener{

	private String inpuText;
	private NumberButtonAction numberButtonAction;
	private ArithmeticSign arithmeticSign;
	private CorrectTextFormat correctTextFormat;
	
	public KeyboardButtonAction() {
		numberButtonAction = new NumberButtonAction();
		arithmeticSign = new ArithmeticSign();
		correctTextFormat= new CorrectTextFormat();
	}
	@Override
	public void keyPressed(KeyEvent e) {

		int keyCode = e.getKeyCode(); 
		
		// 키패드 1~9
		if( ( (keyCode >=ConstantNumber.LEFT_KEY_NUMBER_1 && keyCode<=ConstantNumber.LEFT_KEY_NUMBER_9) ||  
				(keyCode >=ConstantNumber.RIGHT_KEY_NUMBER_1 && keyCode<=ConstantNumber.RIGHT_KEY_NUMBER_9) ) &&e.getModifiers()==ConstantNumber.KEY_SHIFT_OFF ) {

			numberButtonAction.enterNumberAction(Character.toString(e.getKeyChar()));
		}
		//숫자 0
		else if((keyCode == ConstantNumber.LEFT_KEY_NUMBER_0 || keyCode ==ConstantNumber.RIGHT_KEY_NUMBER_0) &&e.getModifiers()==0) {
			numberButtonAction.enterZeroAction(Character.toString(e.getKeyChar()));
		}
		//점 .
		else if((keyCode ==ConstantNumber.LEFT_KEY_DOT||keyCode ==ConstantNumber.RIGHT_KEY_DOT) &&e.getModifiers()==0) {
			numberButtonAction.enterDotAction(Character.toString(e.getKeyChar()));
		}//back
		else if(keyCode ==ConstantNumber.KEY_DELETE && e.getModifiers()==ConstantNumber.KEY_SHIFT_OFF ) {
			numberButtonAction.enterBackAction();
		}//ESC
		else if(keyCode ==  ConstantNumber.KEY_ESC )
			numberButtonAction.enterCAction();
		// 연산자
		else if((keyCode ==ConstantNumber.RIGTH_KEY_DIVIDE ||keyCode ==ConstantNumber.LEFT_KEY_DIVIDE||
				keyCode ==ConstantNumber.RIGTH_KEY_MINUS||keyCode ==ConstantNumber.LEFT_KEY_MINUS ||
				keyCode ==ConstantNumber.RIGTH_KEY_ENTER||keyCode ==ConstantNumber.LEFT_KEY_ENTER || 
				keyCode ==ConstantNumber.RIGTH_KEY_MULTIPLE ||
				keyCode ==ConstantNumber.RIGTH_KEY_PLUS) &&e.getModifiers()==ConstantNumber.KEY_SHIFT_OFF  || 
				(keyCode ==ConstantNumber.LEFT_KEY_MULTIPLE && e.getModifiers()==ConstantNumber.KEY_SHIFT_ON) || 
				(keyCode ==ConstantNumber.LEFT_KEY_PLUS && e.getModifiers()==ConstantNumber.KEY_SHIFT_ON) ){
			
			String mathSign;
			BigDecimal result = null;
			BigDecimal previusDouble;
			BigDecimal inputDoble;
			

			if(TextPanel.previousJLabel.getText()!="" && CalculatorStart.inputNumber!="") {
				
				mathSign = 	TextPanel.previousJLabel.getText().substring(TextPanel.previousJLabel.getText().length()-1);
				previusDouble =  new BigDecimal(CalculatorStart.previousNumber.replace("e", "E"));
				inputDoble = new BigDecimal(CalculatorStart.inputNumber.replace("e", "E"));
				
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
				if(keyCode ==ConstantNumber.RIGTH_KEY_DIVIDE ||keyCode ==ConstantNumber.LEFT_KEY_DIVIDE) { // 나누기
					
				}
				else if(keyCode ==ConstantNumber.RIGTH_KEY_MULTIPLE || keyCode ==ConstantNumber.LEFT_KEY_MULTIPLE) {//곱하기
					TextPanel.previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"×");	
				}
				else if(keyCode ==ConstantNumber.RIGTH_KEY_MINUS || keyCode ==ConstantNumber.LEFT_KEY_MINUS) { //뻬기
					TextPanel.previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"－");
				}
				else if(keyCode ==ConstantNumber.RIGTH_KEY_PLUS || ( keyCode ==ConstantNumber.LEFT_KEY_PLUS && e.getModifiers()==ConstantNumber.KEY_SHIFT_ON)){// 더하기
					TextPanel.previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"＋");	
				}
				else if(keyCode ==ConstantNumber.RIGTH_KEY_ENTER || keyCode ==ConstantNumber.LEFT_KEY_ENTER) //엔터
					TextPanel.previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(String.valueOf(previusDouble))  + mathSign  +inputDoble +"＝");	
				
				//결과값  inputlabel에 저장
				TextPanel.inputJLabel.setText( correctTextFormat.setCorrectInputPanel(String.valueOf(result)));
				//이전값에 결과값넣음
				CalculatorStart.previousNumber = String.valueOf(result).replace("E", "e");
			}
			else {
				
				if(keyCode ==ConstantNumber.RIGTH_KEY_DIVIDE ||keyCode ==ConstantNumber.LEFT_KEY_DIVIDE)  // 나누기
					arithmeticSign.setPreviousValue("÷");
				else if(keyCode ==ConstantNumber.RIGTH_KEY_MULTIPLE || keyCode ==ConstantNumber.LEFT_KEY_MULTIPLE) //곱하기
					arithmeticSign.setPreviousValue("×");
				else if(keyCode ==ConstantNumber.RIGTH_KEY_MINUS || keyCode ==ConstantNumber.LEFT_KEY_MINUS)  //뻬기
					arithmeticSign.setPreviousValue("－");
				else if(keyCode ==ConstantNumber.RIGTH_KEY_PLUS || ( keyCode ==ConstantNumber.LEFT_KEY_PLUS && e.getModifiers()==ConstantNumber.KEY_SHIFT_ON))// 더하기
					arithmeticSign.setPreviousValue("＋");
				else if(keyCode ==ConstantNumber.RIGTH_KEY_ENTER || keyCode ==ConstantNumber.LEFT_KEY_ENTER)  //엔터
					arithmeticSign.calculateEqual()	;	
							
			}
			//입력값초기화
			CalculatorStart.inputNumber ="";
			System.out.println(CalculatorStart.inputNumber);			
			System.out.println(CalculatorStart.previousNumber);	
			System.out.println(TextPanel.inputJLabel.getText());
			System.out.println(TextPanel.previousJLabel.getText());
			
		}
	}

	
	
	
	@Override
	public void keyTyped(KeyEvent e) {	}

	@Override
	public void keyReleased(KeyEvent e) {}

	
	
	
}
