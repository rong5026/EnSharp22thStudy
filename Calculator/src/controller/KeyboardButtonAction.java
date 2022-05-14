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
		int keyCode = e.getKeyCode(); 
		
	
		// 오른쪽 키패드 0~9  -> 96 ~ 105
		// 오른쪽 키패드 나누기 111 , 곱하기 106,  빼기 109 , 더하기 107 , 엔터 10, 점 . 110
		
		//  키패드 1~9 
		if( ( (keyCode >=97 && keyCode<=105) ||   (keyCode >=49 && keyCode<=57) ) &&e.getModifiers()==0) {
		
			
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
		else if((keyCode == 96 || keyCode ==48) &&e.getModifiers()==0) {
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
		else if((keyCode ==110||keyCode ==46) &&e.getModifiers()==0) {
			
			if(TextPanel.inputJLabel.getText()=="0" && CalculatorStart.inputNumber=="" ) {
				CalculatorStart.inputNumber = "0.";
				TextPanel.inputJLabel.setText(CalculatorStart.inputNumber);
			}
			
			// .을 쓴적이 없고, 최대길이 이전일때
			else if(TextPanel.inputJLabel.getText().contains(Character.toString(e.getKeyChar())) ==false &&CalculatorStart.inputNumber.length()<16) {
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
		else if(keyCode ==8 && e.getModifiers()==0) {
			//입력값이 1개이상 있을때 지우기 가능
			if(CalculatorStart.inputNumber.length()>0) {
				
				
			//입력값 1개 삭제
			CalculatorStart.inputNumber = CalculatorStart.inputNumber.substring(0,CalculatorStart.inputNumber.length()-1);
			
		
			//입력 수가 많아질수록 폰트 사이즈 증가
			numberButtonAction.changeFontSize(CalculatorStart.inputNumber,"Up");
			
			//입력숫자 + 콤마가 추가된 문자 inputPanel에 출력
			TextPanel.inputJLabel.setText(numberButtonAction.setComma(CalculatorStart.inputNumber));
			
			}											
			if(CalculatorStart.inputNumber.length() ==0) {
				CalculatorStart.inputNumber ="";
				TextPanel.inputJLabel.setText("0");
			}
		}
		//나누기 2개, 빼기 2개 = 2개
		else if((keyCode ==111 ||keyCode ==47||keyCode ==109||keyCode ==45 ||keyCode ==10||keyCode ==61 || keyCode ==106 ||keyCode ==107) &&e.getModifiers()==0  ||  (keyCode ==56 && e.getModifiers()==1) || (keyCode ==61 && e.getModifiers()==1) ){
			
			String mathSign;
			double result = 0;
			double previusDouble;
			double inputDoble;
		
		
			if(TextPanel.previousJLabel.getText()!="" && CalculatorStart.inputNumber!="") {
				mathSign = 	TextPanel.previousJLabel.getText().substring(TextPanel.previousJLabel.getText().length()-1);
				previusDouble = Double.parseDouble( CalculatorStart.previousNumber);
				inputDoble =  Double.parseDouble(CalculatorStart.inputNumber);
				
				
				switch (mathSign) {
				
				
				case "÷":						
					result = previusDouble/inputDoble;							
					break;
				case "×":
					result = previusDouble*inputDoble;							
					break;
				case "－":
					result = previusDouble-inputDoble;
					break;
				case "＋":
					result = previusDouble+inputDoble;
					break;
			
				default:
					break;
				}
				
				if(keyCode ==111 || keyCode ==47) { // 나누기
					result = previusDouble/inputDoble;		
					TextPanel.previousJLabel.setText(String.valueOf(result)+"÷");
				}
				else if(keyCode ==106 || keyCode ==56) {//곱하기
					result = previusDouble*inputDoble;			
					TextPanel.previousJLabel.setText(String.valueOf(result)+"×");
				}
				else if(keyCode ==109 || keyCode ==45) { //뻬기
					result = previusDouble-inputDoble;
					TextPanel.previousJLabel.setText(String.valueOf(result)+"－");
				}
				else if(keyCode ==107 || ( keyCode ==61 && e.getModifiers()==1)){// 더하기
					result = previusDouble+inputDoble;
					TextPanel.previousJLabel.setText(String.valueOf(result)+"＋");	
				}
				else if(keyCode ==10 || keyCode ==61) //엔터
					TextPanel.previousJLabel.setText(previusDouble + " " + mathSign + " " +inputDoble +"＝");	
			
			
			
				
				//결과값  inputlabel에 저장
				TextPanel.inputJLabel.setText(numberButtonAction.setComma(String.valueOf(result)));
				
				//이전값에 결과값넣음
				CalculatorStart.previousNumber = String.valueOf(result);
			}
			else {
				
				if(keyCode ==111 || keyCode ==47) // 나누기
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText()+"÷");		
				
				else if(keyCode ==106 || keyCode ==56) //곱하기
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText()+"×");		
				else if(keyCode ==109 || keyCode ==45) //뻬기
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText()+"－");		
				else if(keyCode ==107 || ( keyCode ==61 && e.getModifiers()==1))// 더하기
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText()+"＋");		
				else if(keyCode ==10 || keyCode ==61) //엔터
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText()+"＝");		
				
				
				//이전값에 입력값 넣음  
				CalculatorStart.previousNumber =TextPanel.previousJLabel.getText().substring(0,TextPanel.previousJLabel.getText().length()-1).replace(",", "");
						
			}
			//입력값초기화
			CalculatorStart.inputNumber ="";
			
			
			System.out.println(e.getKeyCode());
			//System.out.println(e.getKeyChar());
			//System.out.println("input : "+CalculatorStart.inputNumber);			
			//System.out.println("previ : "+CalculatorStart.previousNumber);	
			//System.out.println("inputpanel : "+TextPanel.inputJLabel.getText());
			//System.out.println("previpabel : "+TextPanel.previousJLabel.getText());
			
				
			 
		
			
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
