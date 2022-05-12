package controller;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import view.ButtonPanel;
import view.TextPanel;

public class ButtonAction {
	private JButton pressedbutton;
	private String inpuText;
	
	
	public void setButtonAction(JButton [] button) {
		for(int index =0 ; index<20 ; index++) {
			
			//숫자버튼 엑션 1 ~ 9
			if( (3 <index && index<15 && index%4!=3)) {
				button[index].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						pressedbutton = (JButton)e.getSource();
						
						// 0밖에 없을때는 지우고 입력한 숫자표시
						if(TextPanel.inputJLabel.getText() =="0") {
							CalculatorStart.resultNumber = "";
							TextPanel.inputJLabel.setText("");
						}
					
						//최대길이 16개로 제한
						if(CalculatorStart.resultNumber.length()<16) {
							inpuText= pressedbutton.getText();
							
							//입력숫자값만 resultNumber에 넣기
							CalculatorStart.resultNumber = CalculatorStart.resultNumber+inpuText;
							
							//입력 수가 많아질수록 폰트 사이즈 감소
							changeFontSize(CalculatorStart.resultNumber);
							
							//입력숫자 + 콤마가 추가된 문자 textPanel에 출력
							TextPanel.inputJLabel.setText(setComma(CalculatorStart.resultNumber));
							
						}
					}
				});
			}
			// 숫자 0
			else if(index ==17) {
				button[index].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						pressedbutton = (JButton)e.getSource();
						// 0밖에 없을때 제외, 길이 16까지 제한
						
						
						if(TextPanel.inputJLabel.getText() !="0" &&CalculatorStart.resultNumber.length()<16) {
							inpuText= pressedbutton.getText();
							
							//입력숫자값만 resultNumber에 넣기
							CalculatorStart.resultNumber = CalculatorStart.resultNumber+inpuText;
							
							//입력 수가 많아질수록 폰트 사이즈 감소
							changeFontSize(CalculatorStart.resultNumber);
							
							//입력숫자 + 콤마가 추가된 문자 textPanel에 출력
							TextPanel.inputJLabel.setText(setComma(CalculatorStart.resultNumber));
						}
					}
				});
						
			}
			
			// . 소수점
			
			else if(index ==18) {
				button[index].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						pressedbutton = (JButton)e.getSource();
						
						// .을 쓴적이 없고, 최대길이 이전일때
						if(TextPanel.inputJLabel.getText().contains(pressedbutton.getText()) ==false &&CalculatorStart.resultNumber.length()<16) {
							inpuText= pressedbutton.getText();
							
							//입력숫자값만 resultNumber에 넣기
							CalculatorStart.resultNumber = CalculatorStart.resultNumber+inpuText;
							
							//입력 수가 많아질수록 폰트 사이즈 감소
							changeFontSize(CalculatorStart.resultNumber);
							
							//입력숫자 + 콤마가 추가된 문자 textPanel에 출력
							TextPanel.inputJLabel.setText(setComma(CalculatorStart.resultNumber));
						}
					
						
					}
				});
			}
			
			
		}
	
	}
	
	public String setComma(String resultNumber) { // 콤마찍어주기
		
		
		String resultText=resultNumber;
		Integer countNumber = resultNumber.length()/3;
		String firstText=null;
		String secondText = null;
		if(resultNumber.length()%3==0)
			countNumber--;
		
		for(int count = 0; count < countNumber ;count++) {
			
			firstText = resultText.substring(0,resultText.length()-3*(count+1)-count);
			secondText = resultText.substring(resultText.length()-3*(count+1)-count,resultText.length());

			resultText = firstText+ "," + secondText;
			
		}
		return resultText;
		
	}
	public void changeFontSize(String resultNumber) { // 글씨가 많아질수록 폰트사이즈 작아짐
		
		if(resultNumber.length() >=12) {
			TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55-(resultNumber.length()-11)*3 ));
		}
			
	}
	
}
