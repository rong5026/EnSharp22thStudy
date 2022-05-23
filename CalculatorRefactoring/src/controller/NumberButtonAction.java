package controller;

import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.math.BigDecimal;
import java.util.ArrayList;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.plaf.basic.BasicInternalFrameTitlePane.SystemMenuBar;

import Utility.ConstantNumber;
import view.TextPanel;
import controller.CorrectTextFormat;
import model.ResultDTO;

public class NumberButtonAction {

	private int index;
	private String input;
	private JButton pressedButton;
	private ArithmeticSign arithmeticSign;
	private CorrectTextFormat correctTextFormat;
	private  ArrayList<ResultDTO> resultList;
	private JLabel inputJLabel;
	private JLabel previousJLabel;
	
	public NumberButtonAction(ArithmeticSign arithmeticSign, ArrayList<ResultDTO> resultList,JLabel inputJLabel, JLabel previousJLabel) {
		this.arithmeticSign =arithmeticSign;
		this.resultList = resultList;
		this.inputJLabel = inputJLabel;
		this.previousJLabel=previousJLabel;
		correctTextFormat = new CorrectTextFormat(inputJLabel,previousJLabel);
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
		else if(arithmeticSign.getArithmeticSignCount(previousJLabel.getText())>=2) {
			enterCEAction();
		}
	
		
		
		if(inputJLabel.getText() =="0") {						
			inputJLabel.setText("");
		}
		
		if(CalculatorStart.inputNumber=="")
			inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));
	
		if(  getNumberLength( CalculatorStart.inputNumber) <16) {
																									
			CalculatorStart.inputNumber = CalculatorStart.inputNumber+input;
			correctTextFormat.changeFontSize(CalculatorStart.inputNumber,"Down");
			inputJLabel.setText(correctTextFormat.setCorrectInputPanel(CalculatorStart.inputNumber));			
		}

		
		setFocusMainFrame();
					
	}
	public void enterZeroAction(String input) { // 0 버튼 입력
		
		if(CalculatorStart.errorType != ConstantNumber.NON_ERROR) {		
			 enterCAction();
		}
		else if(arithmeticSign.getArithmeticSignCount(previousJLabel.getText())>=2) {
			enterCEAction();
		}
		if(inputJLabel.getText()=="0")
			CalculatorStart.inputNumber ="";
		
		
		else if(inputJLabel.getText()!="0" &&CalculatorStart.inputNumber.length()<16) {
			
			CalculatorStart.inputNumber = CalculatorStart.inputNumber+input;
			correctTextFormat.changeFontSize(CalculatorStart.inputNumber,"Down");
			inputJLabel.setText(correctTextFormat.setCorrectInputPanel(CalculatorStart.inputNumber));
			
		}


		setFocusMainFrame();
	}
	public void enterDotAction(String input) { // . 소수점 입력

		if(CalculatorStart.errorType != ConstantNumber.NON_ERROR) {		
			 enterCAction();
		}
		else if(arithmeticSign.getArithmeticSignCount(previousJLabel.getText())>=2) {
			enterCEAction();
		}
		
		if(inputJLabel.getText()=="0" || CalculatorStart.inputNumber=="" ) {
			CalculatorStart.inputNumber = "0.";
			inputJLabel.setText(CalculatorStart.inputNumber);
		}
			// .을 쓴적이 없고, 최대길이 이전일때
		else if(inputJLabel.getText().contains(input) ==false &&CalculatorStart.inputNumber.length()<16) {
			
			CalculatorStart.inputNumber = CalculatorStart.inputNumber+input;
			correctTextFormat.changeFontSize(CalculatorStart.inputNumber,"Down");
			inputJLabel.setText(correctTextFormat.setCorrectInputPanel(CalculatorStart.inputNumber));
		}
		
			
		setFocusMainFrame();
	}
	public void enterCEAction() { //CE 입력
		if(CalculatorStart.errorType != ConstantNumber.NON_ERROR) {		
			 enterCAction();
		}
	
			
			if(arithmeticSign.getArithmeticSignCount(previousJLabel.getText())>=2) {
				previousJLabel.setText("");
			}
		
				
			CalculatorStart.inputNumber = "";				
			inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));						
			inputJLabel.setText("0");
			setFocusMainFrame();
	
	}
	public void enterCAction() { // C입력
		
		CalculatorStart.inputNumber = "";		
		CalculatorStart.previousNumber = "";		
	
		inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));		
		inputJLabel.setText("0");
		previousJLabel.setText("");
		
		CalculatorStart.errorType =ConstantNumber.NON_ERROR;
		this.arithmeticSign = new ArithmeticSign(resultList,inputJLabel,previousJLabel);
		setFocusMainFrame();
		
	}
	public void enterBackAction() { /// back 입력
	
		if(CalculatorStart.errorType != ConstantNumber.NON_ERROR) {		
			 enterCAction();
		}
		if( inputJLabel.getText().equals("-0.") )    {
			inputJLabel.setText("0");
			CalculatorStart.inputNumber ="";
		}
			
		if(arithmeticSign.getArithmeticSignCount(previousJLabel.getText())>=2) {
			previousJLabel.setText("");
			CalculatorStart.inputNumber = correctTextFormat.setCorrectPreviousPanel (inputJLabel.getText());  //수정
		} 
			
		else {
			if(CalculatorStart.inputNumber.length()>0 && CalculatorStart.inputNumber!="") {
				
				//입력값 1개 삭제
				CalculatorStart.inputNumber = CalculatorStart.inputNumber.substring(0,CalculatorStart.inputNumber.length()-1);
							
				correctTextFormat.changeFontSize(CalculatorStart.inputNumber,"Up");
				
			
				inputJLabel.setText(correctTextFormat.setCorrectInputPanel(CalculatorStart.inputNumber));
			}	
			if(inputJLabel.getText().length() ==0) {
				CalculatorStart.inputNumber ="";
				inputJLabel.setText("0");
			}
		}
		
		setFocusMainFrame();
	}
	public void enterNegateAction() { //± 입력
		

		if(CalculatorStart.errorType != ConstantNumber.NON_ERROR) {		
			 enterCAction();
		}
		
		if(arithmeticSign.getArithmeticSignCount(previousJLabel.getText())>=1 ) {
			
			if(previousJLabel.getText().contains("＝")) {
				previousJLabel.setText(correctTextFormat.setNegate(  correctTextFormat.setCorrectInputPanel(inputJLabel.getText()) ));
			}
			else {
				previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel(inputJLabel.getText())+ previousJLabel.getText().charAt(previousJLabel.getText().length()-1) +  correctTextFormat.setNegate(  correctTextFormat.setCorrectInputPanel(inputJLabel.getText()) ));
			}
		}
		
		if( inputJLabel.getText()!="0") {
			
			if(CalculatorStart.inputNumber=="")
				CalculatorStart.inputNumber =correctTextFormat.setCorrectPreviousPanel( inputJLabel.getText());
			
			if( Double.parseDouble(CalculatorStart.inputNumber) <0 || CalculatorStart.inputNumber.contains("-") ) 
				CalculatorStart.inputNumber = CalculatorStart.inputNumber.replace("-", "");
			
			else 		
				CalculatorStart.inputNumber = "-"+CalculatorStart.inputNumber;
			
			
			
			inputJLabel.setText(correctTextFormat.setCorrectInputPanel(CalculatorStart.inputNumber) );
			
		}	
		
		setFocusMainFrame();
	}
	
	public int getNumberLength(String number) { // 입력받은 수의 숫자로만의 길이
		
		int count=0;
		
		for(int index = 0 ; index < number.length() ; index++) {
			
			if(number.charAt(index) >='0' && number.charAt(index )<='9' )
				count++;
			
		}
		
		return count;
	}
	
	
	private void setFocusMainFrame() { // 메인에 포커스
		CalculatorStart.mainFrame.setFocusable(true);
		CalculatorStart.mainFrame.requestFocus();
	}
	
}
