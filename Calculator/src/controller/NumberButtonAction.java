package controller;


import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import view.TextPanel;

public class NumberButtonAction {
	private JButton pressedbutton;
	private String inpuText;
	private int index;
	
	public void setButtonAction(JButton [] button) {
		for(index =0 ; index<20 ; index++) {
			
			//숫자버튼 엑션 1 ~ 9
			if( (3 <index && index<15 && index%4!=3)) {
				button[index].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						pressedbutton = (JButton)e.getSource();
						
						// 0밖에 없을때는 지우고 입력한 숫자표시
						if(TextPanel.inputJLabel.getText() =="0") {							
							TextPanel.inputJLabel.setText("");
						}
					
						//최대길이 16개로 제한
						if(CalculatorStart.inputNumber.length()<16) {
																														
							inpuText= pressedbutton.getText();
							
							//입력숫자값만 resultNumber에 넣기
							CalculatorStart.inputNumber = CalculatorStart.inputNumber+inpuText;
							
							//입력 수가 많아질수록 폰트 사이즈 감소
							changeFontSize(CalculatorStart.inputNumber,"Down");
							
							//입력숫자 + 콤마가 추가된 문자 inputPanel에 출력
							TextPanel.inputJLabel.setText(setComma(CalculatorStart.inputNumber));
							
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
						
						if(TextPanel.inputJLabel.getText()=="0")
							CalculatorStart.inputNumber ="0";
						
						else if(TextPanel.inputJLabel.getText()!="0" &&CalculatorStart.inputNumber.length()<16) {
							
							inpuText= pressedbutton.getText();
							
							//입력숫자값만 resultNumber에 넣기
							CalculatorStart.inputNumber = CalculatorStart.inputNumber+inpuText;
							
							//입력 수가 많아질수록 폰트 사이즈 감소
							changeFontSize(CalculatorStart.inputNumber,"Down");
							
							//입력숫자 + 콤마가 추가된 문자 inputPanel에 출력
							TextPanel.inputJLabel.setText(setComma(CalculatorStart.inputNumber));
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
						if(TextPanel.inputJLabel.getText().contains(pressedbutton.getText()) ==false &&CalculatorStart.inputNumber.length()<16) {
							inpuText= pressedbutton.getText();
							
							//입력숫자 + 점 resultNumber에 넣기
							CalculatorStart.inputNumber = CalculatorStart.inputNumber+inpuText;
							
							//입력 수가 많아질수록 폰트 사이즈 감소
							changeFontSize(CalculatorStart.inputNumber,"Down");
							
							//입력숫자 + 콤마가 추가된 문자 inputPanel에 출력
							TextPanel.inputJLabel.setText(setComma(CalculatorStart.inputNumber));
						}
					
						
					}
				});
			}
			
			// CE 입력한걸 지움
			
			else if(index == 0) {
				button[index].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						
						// 입력값 초기화
						CalculatorStart.inputNumber = "";				
						// 폰트 초기화
						TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));						
						//입력숫자 + 콤마가 추가된 문자 inputPanel에 출력
						TextPanel.inputJLabel.setText("0");
														
					}
				});
			}
			
			// C 모든내용을 지움
			
			else if(index == 1) {
				button[index].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						
						// 입력값 초기화 , 미리 입력한값 초기화
						CalculatorStart.inputNumber = "";		
						
						
						// 폰트 초기화
						TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));		
						
						//입력숫자 + 콤마가 추가된 문자 inputPanel에 출력
						TextPanel.inputJLabel.setText("0");
						
						//숫자 + 소수점이 추가된 문자 previousPanel 초기화
						TextPanel.previousJLabel.setText("");
					
					}
				});
			}
			
			// back 입력값 1개 지우기
			
			else if(index == 2) {
				button[index].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						//입력값이 1개이상 있을때 지우기 가능
						if(CalculatorStart.inputNumber.length()>0) {
							
						//입력값 1개 삭제
						CalculatorStart.inputNumber = CalculatorStart.inputNumber.substring(0,CalculatorStart.inputNumber.length()-1);
						
						if(CalculatorStart.inputNumber.length() ==0) {
							CalculatorStart.inputNumber ="";
							TextPanel.inputJLabel.setText("0");
						}
						
						//입력 수가 많아질수록 폰트 사이즈 증가
						changeFontSize(CalculatorStart.inputNumber,"Up");
						
						//입력숫자 + 콤마가 추가된 문자 inputPanel에 출력
						TextPanel.inputJLabel.setText(setComma(CalculatorStart.inputNumber));
						}		
					}
				});
			}
			
			////////////////////////////////////////////////  수학 기호 버튼 
			
			// 나누기 , 곱하기, 빼기 , 더하기, 등호 =
			else if(index == 3 ||index == 7||index == 11||index == 15) {
				button[index].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
					
						String mathSign;
						double result = 0;
						double previusDouble;
						double inputDoble;
						pressedbutton = (JButton)e.getSource();
						
						if(TextPanel.previousJLabel.getText()!="" && CalculatorStart.inputNumber!="") {
							
							//마지막 문자 가져와서 ÷,×,－,＋,＝ 확인
							mathSign = 	TextPanel.previousJLabel.getText().substring(TextPanel.previousJLabel.getText().length()-1);
							previusDouble = Double.parseDouble( TextPanel.previousJLabel.getText().substring(0,TextPanel.previousJLabel.getText().length()-1));
							inputDoble =  Double.parseDouble(CalculatorStart.inputNumber);
							
							System.out.println(mathSign);
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
							switch (pressedbutton.getText()) {
							case "÷":	//나누기										
								TextPanel.previousJLabel.setText(String.valueOf(result)+"÷");
								break;
							case "×":	//곱하기			
								TextPanel.previousJLabel.setText(String.valueOf(result)+"×");	
								break;
							case "－":	//빼기	
								TextPanel.previousJLabel.setText(String.valueOf(result)+"－");
								break;
							case "＋":	//더하기
								TextPanel.previousJLabel.setText(String.valueOf(result)+"＋");	
								break;										
							default:
								break;
							}
							// 미리입력한 값에 입력값 저장
							//CalculatorStart.previousNumber = String.valueOf(result);
							
							//결과값  inputlabel에 저장
							TextPanel.inputJLabel.setText(String.valueOf(result));
							
						
							
						}
						else {
							
							switch (pressedbutton.getText()) {
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
										
							default:
								break;
							}
							

						
						}
						

					
						//입력값초기화
						CalculatorStart.inputNumber ="";
						
						
						System.out.println(CalculatorStart.inputNumber);
						System.out.println(TextPanel.inputJLabel.getText());
						System.out.println(TextPanel.previousJLabel.getText());
						
					}
				});
			}
			
			// 등호 =
			else if(index == 19 ) {
				button[index].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						
						
					
					}
				});
			}
			
			
			
			
			
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
		
		countNumber = integerPart.length()/3;
		if(integerPart.length()%3==0)
			countNumber--;
		
		for(int count = 0; count < countNumber ;count++) {
			
			firstText = integerPart.substring(0,integerPart.length()-3*(count+1)-count);
			secondText = integerPart.substring(integerPart.length()-3*(count+1)-count,integerPart.length());

			integerPart = firstText+ "," + secondText;
			
		}
		return integerPart+decimalPart;
		
	}
	public void changeFontSize(String resultNumber,String type) { // 글자의 수에따라 폰트 변경
		
		if(resultNumber.length() >=12 && type =="Down") 
			TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , TextPanel.inputJLabel.getFont().getSize()-3 ));
		
		else if(resultNumber.length()>=11 && type =="Up")
			TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , TextPanel.inputJLabel.getFont().getSize()+3 ));
	}
	
	
}
