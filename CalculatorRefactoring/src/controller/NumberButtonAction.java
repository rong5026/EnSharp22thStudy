package controller;

import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.math.BigDecimal;

import javax.swing.JButton;
import javax.swing.plaf.basic.BasicInternalFrameTitlePane.SystemMenuBar;

import Utility.ConstantNumber;
import view.TextPanel;
import controller.CorrectTextFormat;

public class NumberButtonAction {

	private int index;
	private String input;
	private JButton pressedButton;
	private ArithmeticSign arithmeticSign;
	private CorrectTextFormat correctTextFormat;
	
	public NumberButtonAction(ArithmeticSign arithmeticSign) {
		this.arithmeticSign =arithmeticSign;
		correctTextFormat = new CorrectTextFormat();
	}
	public void setButtonAction(JButton [] button) {
		
		for(index =0 ; index<20 ; index++) {
			if( 3 <index && index<15 && index%4!=3) { //숫자 1~9
				button[index].addActionListener(new ActionListener() {	
					@Override
					public void actionPerformed(ActionEvent e) {
						pressedButton = (JButton)e.getSource();
						enterNumberAction(pressedButton.getText());
						
					}
				});
			}
			else if(index ==17) { // 숫자 0		
				button[index].addActionListener(new ActionListener() {
					@Override
					public void actionPerformed(ActionEvent e) {
						pressedButton = (JButton)e.getSource();
						enterZeroAction(pressedButton.getText());					
					}			
				});
			}
			else if(index ==18) { // 소수점 입력
				button[index].addActionListener(new ActionListener() {
					@Override
					public void actionPerformed(ActionEvent e) {	
						pressedButton = (JButton)e.getSource();
						enterDotAction(pressedButton.getText());
					}			
				});
			}
			else if(index == 0) { // CE 입력
				button[index].addActionListener(new ActionListener() {
					@Override
					public void actionPerformed(ActionEvent e) {				
						enterCEAction();
					}			
				});
			}
			else if(index == 1) { //C 입력
				button[index].addActionListener(new ActionListener() {
					@Override
					public void actionPerformed(ActionEvent e) {
						enterCAction();
						
					}			
				});
			}
		
			else if(index == 2) { //back 입력
				button[index].addActionListener(new ActionListener() {
					@Override
					public void actionPerformed(ActionEvent e) {
						enterBackAction();
					}			
				});
			}
			else if(index == 16) { //± 입력
				button[index].addActionListener(new ActionListener() {
					@Override
					public void actionPerformed(ActionEvent e) {				
						enterNegateAction();
					}			
				});
			}
			else if(index == 3 ||index == 7||index == 11||index == 15|| index ==19) { // 연산자
				button[index].addActionListener(new ActionListener() {
					@Override
					public void actionPerformed(ActionEvent e) {		
						pressedButton = (JButton)e.getSource();
						arithmeticSign.enterArithmeticSign(pressedButton.getText());
					}			
				});
				
			}
			
		}
	}
	
	
	public void enterNumberAction(String input) { // 1~9 버튼 입력
		
		if(CalculatorStart.errorType != ConstantNumber.NON_ERROR) {		
			 enterCAction();
		}
		else if(arithmeticSign.getArithmeticSignCount(TextPanel.previousJLabel.getText())>=2) {
			enterCEAction();
		}
	
		
		
		if(TextPanel.inputJLabel.getText() =="0") {						
			TextPanel.inputJLabel.setText("");
		}
		
		if(CalculatorStart.inputNumber=="")
			TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));
	
		if(  getNumberLength( CalculatorStart.inputNumber) <16) {
																									
			CalculatorStart.inputNumber = CalculatorStart.inputNumber+input;
			correctTextFormat.changeFontSize(CalculatorStart.inputNumber,"Down");
			TextPanel.inputJLabel.setText(correctTextFormat.setCorrectInputPanel(CalculatorStart.inputNumber));			
		}

			
	
		CalculatorStart.mainFrame.setFocusable(true);
		CalculatorStart.mainFrame.requestFocus();
					
	}
	public void enterZeroAction(String input) { // 0 버튼 입력
		
		if(CalculatorStart.errorType != ConstantNumber.NON_ERROR) {		
			 enterCAction();
		}
		else if(arithmeticSign.getArithmeticSignCount(TextPanel.previousJLabel.getText())>=2) {
			enterCEAction();
		}
		if(TextPanel.inputJLabel.getText()=="0")
			CalculatorStart.inputNumber ="";
		
		
		
		else if(TextPanel.inputJLabel.getText()!="0" &&CalculatorStart.inputNumber.length()<16) {
			
			CalculatorStart.inputNumber = CalculatorStart.inputNumber+input;
			correctTextFormat.changeFontSize(CalculatorStart.inputNumber,"Down");
			TextPanel.inputJLabel.setText(correctTextFormat.setCorrectInputPanel(CalculatorStart.inputNumber));
			
		}

			
		
		CalculatorStart.mainFrame.setFocusable(true);
		CalculatorStart.mainFrame.requestFocus();
	}
	public void enterDotAction(String input) { // . 소수점 입력

		if(CalculatorStart.errorType != ConstantNumber.NON_ERROR) {		
			 enterCAction();
		}
		else if(arithmeticSign.getArithmeticSignCount(TextPanel.previousJLabel.getText())>=2) {
			enterCEAction();
		}
		
		if(TextPanel.inputJLabel.getText()=="0" || CalculatorStart.inputNumber=="" ) {
			CalculatorStart.inputNumber = "0.";
			TextPanel.inputJLabel.setText(CalculatorStart.inputNumber);
		}
			// .을 쓴적이 없고, 최대길이 이전일때
		else if(TextPanel.inputJLabel.getText().contains(input) ==false &&CalculatorStart.inputNumber.length()<16) {
			
			CalculatorStart.inputNumber = CalculatorStart.inputNumber+input;
			correctTextFormat.changeFontSize(CalculatorStart.inputNumber,"Down");
			TextPanel.inputJLabel.setText(correctTextFormat.setCorrectInputPanel(CalculatorStart.inputNumber));
		}
		
		
			
		CalculatorStart.mainFrame.setFocusable(true);
		CalculatorStart.mainFrame.requestFocus();
	}
	public void enterCEAction() { //CE 입력
		if(CalculatorStart.errorType != ConstantNumber.NON_ERROR) {		
			 enterCAction();
		}
	
			
			if(arithmeticSign.getArithmeticSignCount(TextPanel.previousJLabel.getText())>=2) {
				TextPanel.previousJLabel.setText("");
			}
		
				
			CalculatorStart.inputNumber = "";				
			TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));						
			TextPanel.inputJLabel.setText("0");
			CalculatorStart.mainFrame.setFocusable(true);
			CalculatorStart.mainFrame.requestFocus();
	
	}
	public void enterCAction() { // C입력
		
		CalculatorStart.inputNumber = "";		
		CalculatorStart.previousNumber = "";		
	
		TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));		
		TextPanel.inputJLabel.setText("0");
		TextPanel.previousJLabel.setText("");
		CalculatorStart.mainFrame.setFocusable(true);
		CalculatorStart.mainFrame.requestFocus();
		CalculatorStart.errorType =ConstantNumber.NON_ERROR;
		this.arithmeticSign = new ArithmeticSign();
		
	}
	public void enterBackAction() { /// back 입력
	
		if(CalculatorStart.errorType != ConstantNumber.NON_ERROR) {		
			 enterCAction();
		}
		if( TextPanel.inputJLabel.getText().equals("-0.") )    {
			TextPanel.inputJLabel.setText("0");
			CalculatorStart.inputNumber ="";
		}
			
		if(arithmeticSign.getArithmeticSignCount(TextPanel.previousJLabel.getText())>=2) {
			TextPanel.previousJLabel.setText("");
			CalculatorStart.inputNumber = correctTextFormat.setCorrectPreviousPanel (TextPanel.inputJLabel.getText());  //수정
		}
			
		else {
			if(CalculatorStart.inputNumber.length()>0 && CalculatorStart.inputNumber!="") {
				
				//입력값 1개 삭제
				CalculatorStart.inputNumber = CalculatorStart.inputNumber.substring(0,CalculatorStart.inputNumber.length()-1);
							
				correctTextFormat.changeFontSize(CalculatorStart.inputNumber,"Up");
				
			
				TextPanel.inputJLabel.setText(correctTextFormat.setCorrectInputPanel(CalculatorStart.inputNumber));
			}	
			if(TextPanel.inputJLabel.getText().length() ==0) {
				CalculatorStart.inputNumber ="";
				TextPanel.inputJLabel.setText("0");
			}
		}
		
		CalculatorStart.mainFrame.setFocusable(true);
		CalculatorStart.mainFrame.requestFocus();
	}
	public void enterNegateAction() { //± 입력
		

		if(CalculatorStart.errorType != ConstantNumber.NON_ERROR) {		
			 enterCAction();
		}
		
		
		if(CalculatorStart.inputNumber!="" && TextPanel.inputJLabel.getText()!="0") {
			
			
			if( Double.parseDouble(CalculatorStart.inputNumber) <0 || CalculatorStart.inputNumber.contains("-")) 
				CalculatorStart.inputNumber = CalculatorStart.inputNumber.replace("-", "");
			
			else 		
				CalculatorStart.inputNumber = "-"+CalculatorStart.inputNumber;
			System.out.print(CalculatorStart.inputNumber );
			TextPanel.inputJLabel.setText(correctTextFormat.setCorrectInputPanel(CalculatorStart.inputNumber) );
			
		}	
		
		if(arithmeticSign.getArithmeticSignCount(TextPanel.previousJLabel.getText())>=1) {
			
			if(TextPanel.previousJLabel.getText().contains("＝")) {
				TextPanel.previousJLabel.setText(correctTextFormat.setNegate(  correctTextFormat.setCorrectInputPanel(TextPanel.inputJLabel.getText()) ));
			}
			else {
				
			}
		}
		
	
		CalculatorStart.mainFrame.setFocusable(true);
		CalculatorStart.mainFrame.requestFocus();
	}
	
	public int getNumberLength(String number) { // 입력받은 수의 숫자로만의 길이
		
		int count=0;
		
		for(int index = 0 ; index < number.length() ; index++) {
			
			if(number.charAt(index) >='0' && number.charAt(index )<='9' )
				count++;
			
			
		}
		
		return count;
	}
	
	
	
	
}
