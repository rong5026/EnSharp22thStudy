package controller;

import java.awt.Font;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import javax.swing.JButton;

import view.TextPanel;

public class KeyboardButtonAction implements KeyListener{

	private String inpuText;
	NumberButtonAction numberButtonAction = new NumberButtonAction();
	@Override
	public void keyPressed(KeyEvent e) {
		int keyChar = e.getKeyCode(); 
	
		// 오른쪽 키패드 0~9  -> 96 ~ 105
		// 오른쪽 키패드 나누기 111 , 곱하기 106,  빼기 109 , 더하기 107 , 엔터 10, 점 . 110
		
		//  키패드 1~9 
		if( ( (keyChar >=97 && keyChar<=105) ||   (keyChar >=49 && keyChar<=57) ) &&e.getModifiers()==0) {
		
			
			// 0밖에 없을때는 지우고 입력한 숫자표시
			if(TextPanel.inputJLabel.getText() =="0") {							
				TextPanel.inputJLabel.setText("");
			}
			
			if(CalculatorStart.inputNumber=="")
				TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));
			
			//최대길이 16개로 제한
			if(CalculatorStart.inputNumber.length()<16) {
																											
				inpuText= Character.toString(e.getKeyChar());
				
				//입력숫자값만 resultNumber에 넣기
				CalculatorStart.inputNumber = CalculatorStart.inputNumber+inpuText;
				
				//입력 수가 많아질수록 폰트 사이즈 감소
				numberButtonAction.changeFontSize(CalculatorStart.inputNumber,"Down");
				
				//입력숫자 + 콤마가 추가된 문자 inputPanel에 출력
				TextPanel.inputJLabel.setText(numberButtonAction.setComma(CalculatorStart.inputNumber));
				
			}
		}
		// 키패드 0
		else if((keyChar == 96 || keyChar ==48) &&e.getModifiers()==0) {
			if(TextPanel.inputJLabel.getText()=="0")
				CalculatorStart.inputNumber ="";
			
			else if(TextPanel.inputJLabel.getText()!="0" &&CalculatorStart.inputNumber.length()<16) {
				
				inpuText= Character.toString(e.getKeyChar());
				
				//입력숫자값만 resultNumber에 넣기
				CalculatorStart.inputNumber = CalculatorStart.inputNumber+inpuText;
				
				//입력 수가 많아질수록 폰트 사이즈 감소
				numberButtonAction.changeFontSize(CalculatorStart.inputNumber,"Down");
				
				//입력숫자 + 콤마가 추가된 문자 inputPanel에 출력
				TextPanel.inputJLabel.setText(numberButtonAction.setComma(CalculatorStart.inputNumber));
			}
			
		}
		
		//점 .
		else if((keyChar ==110||keyChar ==46) &&e.getModifiers()==0) {
			// .을 쓴적이 없고, 최대길이 이전일때
			if(TextPanel.inputJLabel.getText().contains(Character.toString(e.getKeyChar())) ==false &&CalculatorStart.inputNumber.length()<16) {
				inpuText=Character.toString(e.getKeyChar());
				
				//입력숫자 + 점 resultNumber에 넣기
				CalculatorStart.inputNumber = CalculatorStart.inputNumber+inpuText;
				
				//입력 수가 많아질수록 폰트 사이즈 감소
				numberButtonAction.changeFontSize(CalculatorStart.inputNumber,"Down");
				
				//입력숫자 + 콤마가 추가된 문자 inputPanel에 출력
				TextPanel.inputJLabel.setText(numberButtonAction.setComma(CalculatorStart.inputNumber));
			}							
		}
		
		//한개 지우기
		else if(keyChar ==8 && e.getModifiers()==0) {
			//입력값이 1개이상 있을때 지우기 가능
			if(CalculatorStart.inputNumber.length()>0) {
				
				
			//입력값 1개 삭제
			CalculatorStart.inputNumber = CalculatorStart.inputNumber.substring(0,CalculatorStart.inputNumber.length()-1);
			
			if(CalculatorStart.inputNumber.length() ==0) {
				CalculatorStart.inputNumber ="";
				TextPanel.inputJLabel.setText("0");
			}
			
			//입력 수가 많아질수록 폰트 사이즈 증가
			numberButtonAction.changeFontSize(CalculatorStart.inputNumber,"Up");
			
			//입력숫자 + 콤마가 추가된 문자 inputPanel에 출력
			TextPanel.inputJLabel.setText(numberButtonAction.setComma(CalculatorStart.inputNumber));
			}											
		}
		//나누기 2개, 빼기 2개 = 2개
		else if((keyChar ==111 ||keyChar ==47||keyChar ==109||keyChar ==45 ||keyChar ==10||keyChar ==61 || keyChar ==106 ||keyChar ==107) &&e.getModifiers()==0  ||  (keyChar ==56 && e.getModifiers()==1) || (keyChar ==61 && e.getModifiers()==1) ){
			
			String mathSign;
			double result = 0;
			double previusDouble;
			double inputDoble;
			if(TextPanel.previousJLabel.getText()!="" && CalculatorStart.inputNumber!="") {
				mathSign = 	TextPanel.previousJLabel.getText().substring(TextPanel.previousJLabel.getText().length()-1);
				previusDouble = Double.parseDouble( CalculatorStart.previousNumber);
				inputDoble =  Double.parseDouble(CalculatorStart.inputNumber);
				
				
				switch (keyChar) {
				
				case 111:case 47://나누기			
					result = previusDouble/inputDoble;							
					break;
				case 106: case 56://곱하기
					result = previusDouble*inputDoble;							
					break;
				case 109: case 45://빼기
					result = previusDouble-inputDoble;
					break;
				case 107: case 61:// 더하기
					result = previusDouble+inputDoble;
					break;
			
				default:
					break;
				}
				
				if(keyChar ==111 || keyChar ==47) // 나누기
					TextPanel.previousJLabel.setText(String.valueOf(result)+"÷");
				
				else if(keyChar ==106 || keyChar ==56) //곱하기
					TextPanel.previousJLabel.setText(String.valueOf(result)+"×");	
				else if(keyChar ==109 || keyChar ==45) //뻬기
					TextPanel.previousJLabel.setText(String.valueOf(result)+"－");
				else if(keyChar ==107 || ( keyChar ==61 && e.getModifiers()==1))// 더하기
					TextPanel.previousJLabel.setText(String.valueOf(result)+"＋");	
				else if(keyChar ==10 || keyChar ==61) //엔터
					TextPanel.previousJLabel.setText(previusDouble + " " + mathSign + " " +inputDoble +"＝");	
			
			
				
				//결과값  inputlabel에 저장
				TextPanel.inputJLabel.setText(numberButtonAction.setComma(String.valueOf(result)));
				
				//이전값에 결과값넣음
				CalculatorStart.previousNumber = String.valueOf(result);
			}
			else {
				
				switch (Character.toString(e.getKeyChar())) {
				case "÷":	//나누기										
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText()+"÷");		
					break;
				case "×":	//곱하기			
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText()+"×");		
					break;
				case "－":	//빼기	
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText()+"－");		
					break;
				case "＋":	//더하기
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText()+"＋");		
					break;
				case "＝":
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText()+"＝");		
					break;
							
				default:
					break;
				}
				
				//이전값에 입력값 넣음  -23,223  ->-23223 을 넣음
				CalculatorStart.previousNumber =TextPanel.previousJLabel.getText().substring(0,TextPanel.previousJLabel.getText().length()-1).replace(",", "");
						
			}
			//입력값초기화
			CalculatorStart.inputNumber ="";
			
			
			/*
			System.out.println(CalculatorStart.inputNumber);			
			System.out.println(CalculatorStart.previousNumber);	
			System.out.println(TextPanel.inputJLabel.getText());
			System.out.println(TextPanel.previousJLabel.getText());
			*/
				
			 
		
			
			//왼쪽 0~9  -> 48 ~57
			//왼쪽 한개 지우기 8
			//왼쪽 엔터 10
			
			//왼쪽 나누기 47
			// 곱하기  16 누른채 56
			// 빼기  45
			// 더하기 16 누른채 61
			// 엔터 61
			// 점 46
			
		}
			
	}
	
	
	@Override
	public void keyTyped(KeyEvent e) {
		
			
	}



	@Override
	public void keyReleased(KeyEvent e) {	}
	
	
	
}
