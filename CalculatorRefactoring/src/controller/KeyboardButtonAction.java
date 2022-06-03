package controller;

import java.awt.Font;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.math.BigDecimal;
import java.math.MathContext;
import java.util.ArrayList;

import javax.swing.JLabel;

import Utility.*;
import model.ResultDTO;
import view.TextPanel;

public class KeyboardButtonAction implements KeyListener{

	private String inpuText;
	private NumberButtonAction numberButtonAction;
	private ArithmeticSign arithmeticSign;
	private CorrectTextFormat correctTextFormat;
	private ArrayList<ResultDTO> resultList;
	private JLabel inputJLabel;
	private JLabel previousJLabel;
	
	public KeyboardButtonAction(ArithmeticSign arithmeticSign,ArrayList<ResultDTO> resultList,JLabel inputJLabel, JLabel previousJLabel) {
		numberButtonAction = new NumberButtonAction(arithmeticSign,resultList,inputJLabel,previousJLabel);
		this.arithmeticSign = arithmeticSign;
		this.resultList =resultList;
		this.inputJLabel = inputJLabel;
		this.previousJLabel = previousJLabel;
		correctTextFormat= new CorrectTextFormat(inputJLabel,previousJLabel);
	}
	
	@Override
	public void keyPressed(KeyEvent e) {

		int keyCode = e.getKeyCode(); 
		System.out.println(e.getKeyChar());
		
		// 키패드 1~9
		if( ( (keyCode >=ConstantNumber.LEFT_KEY_NUMBER_1 && keyCode<=ConstantNumber.LEFT_KEY_NUMBER_9) ||  	(keyCode >=ConstantNumber.RIGHT_KEY_NUMBER_1 && keyCode<=ConstantNumber.RIGHT_KEY_NUMBER_9) ) &&e.getModifiers()==ConstantNumber.KEY_SHIFT_OFF ) 
			numberButtonAction.enterNumberAction(Character.toString(e.getKeyChar()));
		//숫자 0
		else if((keyCode == ConstantNumber.LEFT_KEY_NUMBER_0 || keyCode ==ConstantNumber.RIGHT_KEY_NUMBER_0) &&e.getModifiers()==0) 
			numberButtonAction.enterZeroAction(Character.toString(e.getKeyChar()));
		//점 .
		else if((keyCode ==ConstantNumber.LEFT_KEY_DOT||keyCode ==ConstantNumber.RIGHT_KEY_DOT) &&e.getModifiers()==0) 
			numberButtonAction.enterDotAction(Character.toString(e.getKeyChar()));
		//back
		else if(keyCode ==ConstantNumber.KEY_DELETE && e.getModifiers()==ConstantNumber.KEY_SHIFT_OFF ) 
			numberButtonAction.enterBackAction();
		//ESC
		else if(keyCode ==  ConstantNumber.KEY_ESC ) {
			numberButtonAction.enterCAction();
			this.arithmeticSign =new ArithmeticSign(resultList,inputJLabel,previousJLabel);
		}
		// 연산자
		else if((keyCode ==ConstantNumber.RIGTH_KEY_DIVIDE ||keyCode ==ConstantNumber.LEFT_KEY_DIVIDE||keyCode ==ConstantNumber.RIGTH_KEY_MINUS||keyCode ==ConstantNumber.LEFT_KEY_MINUS ||keyCode ==ConstantNumber.RIGTH_KEY_ENTER||keyCode ==ConstantNumber.LEFT_KEY_ENTER || keyCode ==ConstantNumber.RIGTH_KEY_MULTIPLE ||keyCode ==ConstantNumber.RIGTH_KEY_PLUS) &&e.getModifiers()==ConstantNumber.KEY_SHIFT_OFF  || (keyCode ==ConstantNumber.LEFT_KEY_MULTIPLE && e.getModifiers()==ConstantNumber.KEY_SHIFT_ON) || (keyCode ==ConstantNumber.LEFT_KEY_PLUS && e.getModifiers()==ConstantNumber.KEY_SHIFT_ON) ){
			
			if(CalculatorStart.errorType == ConstantNumber.NON_ERROR) { // 에러가 없을때
			
				if(previousJLabel.getText()!="" && CalculatorStart.inputNumber!=""&& previousJLabel.getText().charAt(previousJLabel.getText().length()-1) != '＝') {
					
					arithmeticSign.mathSign = 	previousJLabel.getText().substring(previousJLabel.getText().length()-1);
					arithmeticSign.previusDouble =  new BigDecimal(CalculatorStart.previousNumber.replace("e", "E"));
					arithmeticSign.inputDoble = new BigDecimal(CalculatorStart.inputNumber.replace("e", "E"));
					
					arithmeticSign.calculateArithmeticSign(getCorrectMathSign(keyCode,e));
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
					else if(keyCode ==ConstantNumber.RIGTH_KEY_ENTER || keyCode ==ConstantNumber.LEFT_KEY_ENTER) {  //엔터
						arithmeticSign.calculateEqual();
						arithmeticSign.calculateArithmeticSign("＝");	
					}		
				}
				CalculatorStart.inputNumber ="";
				
			}// 에러가 있을 때
			else {
				CalculatorStart.inputNumber = "";				
				inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));						
				inputJLabel.setText("0");
				CalculatorStart.errorType =ConstantNumber.NON_ERROR;
			}
			
		}
	}

	
	// 키보드 입력받은 수학기호 판별 후 리턴
	private String getCorrectMathSign(int keyCode,KeyEvent e) { 
		
		if(keyCode ==ConstantNumber.RIGTH_KEY_DIVIDE ||keyCode ==ConstantNumber.LEFT_KEY_DIVIDE)  // 나누기
			return "÷";
		else if(keyCode ==ConstantNumber.RIGTH_KEY_MULTIPLE || keyCode ==ConstantNumber.LEFT_KEY_MULTIPLE) //곱하기
			return "×";		
		else if(keyCode ==ConstantNumber.RIGTH_KEY_MINUS || keyCode ==ConstantNumber.LEFT_KEY_MINUS)  //뻬기
			return "－";	
		else if(keyCode ==ConstantNumber.RIGTH_KEY_PLUS || ( keyCode ==ConstantNumber.LEFT_KEY_PLUS && e.getModifiers()==ConstantNumber.KEY_SHIFT_ON))// 더하기
			return "＋";		
		else if(keyCode ==ConstantNumber.RIGTH_KEY_ENTER || keyCode ==ConstantNumber.LEFT_KEY_ENTER) {  //엔터
			return "＝";	
		}
		return inpuText;
	}
	@Override
	public void keyTyped(KeyEvent e) {	}

	@Override
	public void keyReleased(KeyEvent e) {}

	
	
	
}


