package controller;

import java.awt.Font;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.math.BigDecimal;
import java.math.MathContext;

import javax.swing.JButton;

import Constants.ConstantNumber;
import view.TextPanel;

public class KeyboardButtonAction implements KeyListener{

	private String inpuText;
	NumberButtonAction numberButtonAction = new NumberButtonAction();
	@Override
	public void keyPressed(KeyEvent e) {
		int keyCode = e.getKeyCode(); 
		
	
		// 오른쪽 키패드 0~9  -> 96 ~ 105
		// 오른쪽 키패드 나누기 111 , 곱하기 106,  빼기 109 , 더하기 107 , 엔터 10, 점 . 110
		//왼쪽 0~9  -> 48 ~57
		//왼쪽 한개 지우기 8
		//왼쪽 엔터 10
		//왼쪽 나누기 47
		// 곱하기  16 누른채 56
		// 빼기  45
		// 더하기 16 누른채 61
		// 엔터 61
		// 점 46
		
		//  키패드 1~9 
		if( ( (keyCode >=ConstantNumber.LEFT_KEY_NUMBER_1 && keyCode<=ConstantNumber.LEFT_KEY_NUMBER_9) ||   (keyCode >=ConstantNumber.RIGHT_KEY_NUMBER_1 && keyCode<=ConstantNumber.RIGHT_KEY_NUMBER_9) ) &&e.getModifiers()==ConstantNumber.KEY_SHIFT_OFF ) {
		
			// 0밖에 없을때는 지우고 입력한 숫자표시
			if(TextPanel.inputJLabel.getText() =="0") {							
				TextPanel.inputJLabel.setText("");
			}
			
			if(CalculatorStart.inputNumber=="")
				TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));
			
			//0으로 나누는거 오류
			if(CalculatorStart.errorNumber == ConstantNumber.ZERO_ERROR) {
				TextPanel.inputJLabel.setText("");
				TextPanel.previousJLabel.setText("");
				CalculatorStart.errorNumber = ConstantNumber.NON_ERROR;
				
			}
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
		else if((keyCode == ConstantNumber.LEFT_KEY_NUMBER_0 || keyCode ==ConstantNumber.RIGHT_KEY_NUMBER_0) &&e.getModifiers()==0) {
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
		else if((keyCode ==ConstantNumber.LEFT_KEY_DOT||keyCode ==ConstantNumber.RIGHT_KEY_DOT) &&e.getModifiers()==0) {
			
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
		else if(keyCode ==ConstantNumber.KEY_DELETE && e.getModifiers()==ConstantNumber.KEY_SHIFT_OFF ) {
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
		// 수학기호 입력
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
				previusDouble =  new BigDecimal(CalculatorStart.previousNumber);
				inputDoble = new BigDecimal(CalculatorStart.inputNumber); 
				
				switch (mathSign) {
				
				case "÷":
					if( String.valueOf(inputDoble).equals("0")==false) 							
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
			
				default:
					break;
				}
				
				if(keyCode ==ConstantNumber.RIGTH_KEY_DIVIDE ||keyCode ==ConstantNumber.LEFT_KEY_DIVIDE) { // 나누기
					result = previusDouble.divide(inputDoble,MathContext.DECIMAL64);
					TextPanel.previousJLabel.setText(String.valueOf(result).replace("E","e")+"÷");
				}
				else if(keyCode ==ConstantNumber.RIGTH_KEY_MULTIPLE || keyCode ==ConstantNumber.LEFT_KEY_MULTIPLE) {//곱하기
					result = previusDouble.multiply(inputDoble,MathContext.DECIMAL64);					
					TextPanel.previousJLabel.setText(String.valueOf(result).replace("E","e")+"×");
				}
				else if(keyCode ==ConstantNumber.RIGTH_KEY_MINUS || keyCode ==ConstantNumber.LEFT_KEY_MINUS) { //뻬기
					result = previusDouble.subtract(inputDoble,MathContext.DECIMAL64);	
					TextPanel.previousJLabel.setText(String.valueOf(result).replace("E","e")+"－");
				}
				else if(keyCode ==ConstantNumber.RIGTH_KEY_PLUS || ( keyCode ==ConstantNumber.LEFT_KEY_PLUS && e.getModifiers()==ConstantNumber.KEY_SHIFT_ON)){// 더하기
					result =previusDouble.add(inputDoble,MathContext.DECIMAL64);	
					TextPanel.previousJLabel.setText(String.valueOf(result).replace("E","e")+"＋");	
				}
				else if(keyCode ==ConstantNumber.RIGTH_KEY_ENTER || keyCode ==ConstantNumber.LEFT_KEY_ENTER) //엔터
					TextPanel.previousJLabel.setText(String.valueOf(previusDouble).replace("E","e") + " " + mathSign + " " +inputDoble +"＝");	
			
				//결과값  inputlabel에 저장
				TextPanel.inputJLabel.setText(numberButtonAction.setComma(String.valueOf(result).replace("E","e")));
				//결과값도 16개 이상되면 폰트 줄어들게 설정
				numberButtonAction.changeResultFontSize(String.valueOf(result).replace("E","e"));
				//이전값에 결과값넣음
				CalculatorStart.previousNumber = String.valueOf(result);
			}
			else {
				
				if(keyCode ==ConstantNumber.RIGTH_KEY_DIVIDE ||keyCode ==ConstantNumber.LEFT_KEY_DIVIDE)  // 나누기
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText().replace("E","e")+"÷");				
				else if(keyCode ==ConstantNumber.RIGTH_KEY_MULTIPLE || keyCode ==ConstantNumber.LEFT_KEY_MULTIPLE) //곱하기
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText().replace("E","e")+"×");		
				else if(keyCode ==ConstantNumber.RIGTH_KEY_MINUS || keyCode ==ConstantNumber.LEFT_KEY_MINUS) //뻬기
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText().replace("E","e")+"－");		
				else if(keyCode ==ConstantNumber.RIGTH_KEY_PLUS || ( keyCode ==ConstantNumber.LEFT_KEY_PLUS && e.getModifiers()==ConstantNumber.KEY_SHIFT_ON))// 더하기
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText().replace("E","e")+"＋");		
				else if(keyCode ==ConstantNumber.RIGTH_KEY_ENTER || keyCode ==ConstantNumber.LEFT_KEY_ENTER)  //엔터
					TextPanel.previousJLabel.setText(TextPanel.inputJLabel.getText().replace("E","e")+"＝");		
				
				
				//이전값에 입력값 넣음  
				CalculatorStart.previousNumber =TextPanel.previousJLabel.getText().substring(0,TextPanel.previousJLabel.getText().length()-1).replace(",", "");
						
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
	public void keyTyped(KeyEvent e) {
		
			
	}



	@Override
	public void keyReleased(KeyEvent e) {	}
	
	
	
}
