package controller;

import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;

import Utility.ConstantNumber;
import view.TextPanel;

public class NumberButtonAction {

	private int index;
	private String input;
	private JButton pressedButton;
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
			else if(index == 3 ||index == 7||index == 11||index == 15|| index ==19) { // 나누기 , 곱하기, 빼기 , 더하기, 등호 
				
				
			}
			// 키보드 포커싱 주기
			CalculatorStart.mainFrame.setFocusable(true);
			CalculatorStart.mainFrame.requestFocus();
		}
	}
	
	
	public void enterNumberAction(String input) { // 1~9 버튼 입력
		
		
		if(TextPanel.inputJLabel.getText() =="0") {							
			TextPanel.inputJLabel.setText("");
		}
		
		if(CalculatorStart.inputNumber=="")
			TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));
	
		if(CalculatorStart.inputNumber.length()<16) {
																									
			CalculatorStart.inputNumber = CalculatorStart.inputNumber+input;
			changeFontSize(CalculatorStart.inputNumber,"Down");
			TextPanel.inputJLabel.setText(setComma(CalculatorStart.inputNumber));
			
		}
	}
	public void enterZeroAction(String input) { // 0 버튼 입력
		if(TextPanel.inputJLabel.getText()=="0")
			CalculatorStart.inputNumber ="";
		
		else if(TextPanel.inputJLabel.getText()!="0" &&CalculatorStart.inputNumber.length()<16) {
			
			CalculatorStart.inputNumber = CalculatorStart.inputNumber+input;
			changeFontSize(CalculatorStart.inputNumber,"Down");
			TextPanel.inputJLabel.setText(setComma(CalculatorStart.inputNumber));
			
		}
	}
	public void enterDotAction(String input) { // . 소수점 입력
		if(TextPanel.inputJLabel.getText()=="0" || CalculatorStart.inputNumber=="" ) {
			CalculatorStart.inputNumber = "0.";
			TextPanel.inputJLabel.setText(CalculatorStart.inputNumber);
		}
		// .을 쓴적이 없고, 최대길이 이전일때
		else if(TextPanel.inputJLabel.getText().contains(input) ==false &&CalculatorStart.inputNumber.length()<16) {
		
			CalculatorStart.inputNumber = CalculatorStart.inputNumber+input;
			changeFontSize(CalculatorStart.inputNumber,"Down");
			TextPanel.inputJLabel.setText(setComma(CalculatorStart.inputNumber));
		}
	}
	public void enterCEAction() { //CE 입력
		CalculatorStart.inputNumber = "";				
		TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));						
		TextPanel.inputJLabel.setText("0");
		
	}
	public void enterCAction() { // C입력
		
		CalculatorStart.inputNumber = "";		
		CalculatorStart.previousNumber = "";		
		TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));		
		TextPanel.inputJLabel.setText("0");
		TextPanel.previousJLabel.setText("");
	}
	public void enterBackAction() {
		if(CalculatorStart.inputNumber.length()>0) {
			
			//입력값 1개 삭제
			CalculatorStart.inputNumber = CalculatorStart.inputNumber.substring(0,CalculatorStart.inputNumber.length()-1);
						
			changeFontSize(CalculatorStart.inputNumber,"Up");
			
		
			TextPanel.inputJLabel.setText(setComma(CalculatorStart.inputNumber));
			}	
			if(CalculatorStart.inputNumber.length() ==0) {
				CalculatorStart.inputNumber ="";
				TextPanel.inputJLabel.setText("0");
			}
	}
	public void enterNegateAction() { //± 입력
		if(CalculatorStart.inputNumber!="" && TextPanel.inputJLabel.getText()!="0") {
			
			
			if( Double.parseDouble(CalculatorStart.inputNumber) <0) 
				CalculatorStart.inputNumber = CalculatorStart.inputNumber.replace("-", "");
		
			else 		
				CalculatorStart.inputNumber = "-"+CalculatorStart.inputNumber;
				
			TextPanel.inputJLabel.setText(setComma(CalculatorStart.inputNumber) );
			
		}
	}
	public String setComma(String resultNumber) { // 콤마찍어주기
		
		
		Integer countNumber;
		String firstText=null;
		String secondText = null;
		
		String integerPart=null;
		String decimalPart=null;
		
		if(resultNumber.contains(".")) {
			String []part = resultNumber.split("\\.",2);
			
			integerPart =	part[0].toString();
			decimalPart = "."+part[1].toString();
		}
		
		else {
			integerPart = resultNumber;
			decimalPart="";
		}
		
		// 음수있을 때 - 제외시켜주시
		if(resultNumber.contains("-")) 
			integerPart = integerPart.replace("-", "");
	
		
		countNumber = integerPart.length()/3;
		if(integerPart.length()%3==0)
			countNumber--;
		
		for(int count = 0; count < countNumber ;count++) {
			
			firstText = integerPart.substring(0,integerPart.length()-3*(count+1)-count);
			secondText = integerPart.substring(integerPart.length()-3*(count+1)-count,integerPart.length());

			integerPart = firstText+ "," + secondText;
			
		}
		
		if(resultNumber.contains("-"))
			return "-"+integerPart+decimalPart;
		
		return integerPart+decimalPart;
		
	}
	
	
	public void changeFontSize(String resultNumber,String type) { // 글자의 수에따라 폰트 변경
		
		if(resultNumber.length() >=12 && type =="Down") 
			TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , TextPanel.inputJLabel.getFont().getSize()-3 ));
		
		else if(resultNumber.length()>=11 && type =="Up")
			TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , TextPanel.inputJLabel.getFont().getSize()+3 ));
	}
	public void setCorrectInputLabel() {
		
	}
	public void setCorrectPreviousLabel() {
		
	}
}
