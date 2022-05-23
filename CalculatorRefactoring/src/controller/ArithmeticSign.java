package controller;

import java.awt.Font;
import java.awt.geom.RoundRectangle2D;
import java.math.BigDecimal;
import java.math.MathContext;
import java.math.RoundingMode;
import java.util.ArrayList;

import javax.swing.JLabel;

import Utility.ConstantNumber;
import model.ResultDTO;
import view.TextPanel;

public class ArithmeticSign {
	
	public String mathSign;
	private BigDecimal result = null;
	public BigDecimal previusDouble;
	public BigDecimal inputDoble;
	private CorrectTextFormat correctTextFormat;
	private ArrayList<ResultDTO> resultList;
	private JLabel inputJLabel;
	private JLabel previousJLabel;
	
	public ArithmeticSign(ArrayList<ResultDTO> resultList,JLabel inputJLabel, JLabel previousJLabel) {
		correctTextFormat = new CorrectTextFormat(inputJLabel,previousJLabel);
		this.resultList = resultList;
		this.inputJLabel = inputJLabel;
		this.previousJLabel = previousJLabel;
	}
	
	
	public void enterArithmeticSign(String input) {
		try {
		
	
		if(CalculatorStart.errorType == ConstantNumber.NON_ERROR) {
			if(previousJLabel.getText()!="" && CalculatorStart.inputNumber!="" && previousJLabel.getText().charAt(previousJLabel.getText().length()-1) != '＝') {
				
				mathSign = 	previousJLabel.getText().substring(previousJLabel.getText().length()-1);
				previusDouble =  new BigDecimal(CalculatorStart.previousNumber.replace("e", "E"));
				inputDoble = new BigDecimal(CalculatorStart.inputNumber.replace("e", "E"));
				
				calculateArithmeticSign(input);
			}
			else {
						
				switch (input) {
				case "÷":	//나누기										
					setPreviousValue("÷");
					break;
				case "×":	//곱하기		
					setPreviousValue("×");
					break;
				case "－":	//빼기	
					setPreviousValue("－");
					break;
				case "＋":	//더하기
					setPreviousValue("＋");
					break;
				case "＝":	
					calculateEqual();
					calculateArithmeticSign("＝");	
					break;
							
				default:
					break;
				}
				

			}
			//입력값초기화
		
			CalculatorStart.inputNumber ="";
		
		}
		else {
			CalculatorStart.inputNumber = "";				
			inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));						
			inputJLabel.setText("0");
			CalculatorStart.errorType =ConstantNumber.NON_ERROR;
		}
		
		
			
		System.out.println("inputnumber:"+CalculatorStart.inputNumber);			
		System.out.println("previousNumber:"+CalculatorStart.previousNumber);	
		System.out.println("inputJLabel:"+inputJLabel.getText());
		System.out.println("previousJLabel:"+previousJLabel.getText());
		
	
		
		CalculatorStart.mainFrame.setFocusable(true);
		CalculatorStart.mainFrame.requestFocus();
		} catch (NumberFormatException e) {
			
		}
	}
	
	
	public void setPreviousValue(String mathSign) {
		
		previousJLabel.setText(  correctTextFormat.setCorrectPreviousPanel( inputJLabel.getText())+mathSign);		
		CalculatorStart.previousNumber = correctTextFormat.setCorrectPreviousPanel(inputJLabel.getText());
	}
	
	 // = 계산
	public void calculateEqual() { 
		try {
			String previousJLabelText;
			previousJLabelText = previousJLabel.getText();
			
			if(CalculatorStart.inputNumber!="") {
				previusDouble =  new BigDecimal(correctTextFormat.setCorrectPreviousPanel(CalculatorStart.inputNumber).replace("e", "E"));
			}
			
			if(inputJLabel.getText().equals("0"))
				previusDouble = new BigDecimal("0");
			
			if((previousJLabelText.contains("÷")==false &&previousJLabelText.contains("×")==false && previousJLabelText.contains("－")==false&&previousJLabelText.contains("＋")==false) ) {
				previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel( CalculatorStart.inputNumber)+"＝");		
				CalculatorStart.previousNumber =previousJLabel.getText().substring(0,previousJLabel.getText().length()-1).replace(",", "");
				resultList.add(new ResultDTO(previousJLabel.getText() ,inputJLabel.getText() ));
			
			}
		
			else {
				previusDouble =  new BigDecimal(correctTextFormat.setCorrectPreviousPanel(inputJLabel.getText()).replace("e", "E"));
				
		
				if( getArithmeticSignCount( previousJLabel.getText()) == 1) { // 9X 처럼 연산자가 1개있을때는 처음으로 시작
					mathSign = 	previousJLabel.getText().substring(previousJLabel.getText().length()-1);		
					inputDoble =  new BigDecimal(correctTextFormat.setCorrectPreviousPanel(inputJLabel.getText()).replace("e", "E")  ); 
				
				}
				else {
			
					if(previousJLabelText.contains("÷")) {
						mathSign  ="÷";
						inputDoble = new BigDecimal(previousJLabel.getText().replace("e", "E").substring( previousJLabel.getText().lastIndexOf("÷")+1 , previousJLabel.getText().length()-1)); 
					}
					else if( previousJLabelText.contains("×") ) {
						mathSign  ="×";
						inputDoble = new BigDecimal(previousJLabel.getText().replace("e", "E").substring( previousJLabel.getText().lastIndexOf("×")+1 ,previousJLabel.getText().length()-1)); 
					}
					else if( previousJLabelText.contains("－") ) {
						mathSign  ="－";
						inputDoble =new BigDecimal(previousJLabel.getText().replace("e", "E").substring( previousJLabel.getText().lastIndexOf("－")+1 ,previousJLabel.getText().length()-1)); 
					}
					else if(previousJLabelText.contains("＋")) {
						mathSign  ="＋";
						inputDoble =new BigDecimal(previousJLabel.getText().replace("e", "E").substring( previousJLabel.getText().lastIndexOf("＋")+1 , previousJLabel.getText().length()-1)); 
					}
				}
			}
				
		} 
		catch (NumberFormatException e) {
				
		}
		
	}
	
	
	
	public void calculateArithmeticSign(String input) { // 연산자 계산
		
	try {
		if(mathSign!=null && inputDoble!=null && previusDouble!=null) {
			
			
			switch (mathSign) {
			
			case "÷":		
				
				if(inputDoble.compareTo(new BigDecimal("0"))==0) {
					calculateDivision();
					return;
				}
				else {
					result = previusDouble.divide(inputDoble,15,BigDecimal.ROUND_HALF_EVEN);	
					CalculatorStart.previousNumber = previusDouble.divide(inputDoble,16,BigDecimal.ROUND_HALF_EVEN).toString().replace("E", "e");	
				}
				break;
			case "×":
				result = previusDouble.multiply(inputDoble,MathContext.DECIMAL64);
			
				if(result.compareTo(new BigDecimal("9.999999999999375E+9999"))>0) {
					cakculateOverFlow();
					return;
				}
				else {
					CalculatorStart.previousNumber =  String.valueOf( previusDouble.multiply(inputDoble,MathContext.DECIMAL128).setScale(16,RoundingMode.HALF_EVEN)  ).replace("E", "e");
				}
			
				break;
			case "－":
				result = previusDouble.subtract(inputDoble,MathContext.DECIMAL64);				
				CalculatorStart.previousNumber =  String.valueOf(result).replace("E", "e");
				break;
			case "＋":
				result =previusDouble.add(inputDoble,MathContext.DECIMAL64);
				CalculatorStart.previousNumber =  String.valueOf(result).replace("E", "e");
			
			default:
				break;
			}
			
			resultList.add(new ResultDTO(  correctTextFormat.removeDecimalPoint(previusDouble.toString())+mathSign+inputDoble.toString()+"=" ,correctTextFormat.removeDecimalPoint(String.valueOf(result))  ));
		
		}
		
		
		switch (input) {
		case "÷":	//나누기										
			previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"÷");	
			break;
		case "×":	//곱하기			
			previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"×");	
			break;
		case "－":	//빼기	
			previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"－");
			break;
		case "＋":	//더하기
			previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"＋");	
			break;	
		case "＝":
		
			if(result==null && inputDoble==null) {
				previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel( CalculatorStart.inputNumber)+"＝");		
				CalculatorStart.previousNumber =previousJLabel.getText().substring(0,previousJLabel.getText().length()-1).replace(",", "");
			}
			else
				previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(String.valueOf(previusDouble))  + mathSign  +correctTextFormat.removeDecimalPoint(inputDoble.toString()) +"＝");
			if(result!=null) {
				System.out.println("result = "+result.toString());
				System.out.println("pre = "+previusDouble);
				System.out.println("--------------");
				//System.out.println("input = "+inputDoble);
				//System.out.println("pre = "+previusDouble);
			}
			break;
		default:
			break;
		}
		

		if(result!=null ) {
			correctTextFormat.changeResultFontSize( correctTextFormat.removeDecimalPoint(String.valueOf(result)));
			inputJLabel.setText(   correctTextFormat.setCorrectInputPanel(  correctTextFormat.removeDecimalPoint(String.valueOf(result))) ) ;
			
	
		}
	 } catch (NumberFormatException e) {
		}
		
	}
	
	private void calculateDivision() { // 0나누기 오류
		
		if(inputDoble.compareTo(new BigDecimal("0"))==0) {
			inputJLabel.setText("0으로 나눌 수 없습니다");
			CalculatorStart.inputNumber="";
			CalculatorStart.previousNumber="";
			CalculatorStart.errorType = ConstantNumber.ZERO_ERROR;
		}
		else {
			previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"÷");	
		}
	}
	
	private void cakculateOverFlow() { //오버플로우 오류
		inputJLabel.setText("오버플로");
		previousJLabel.setText("");
		CalculatorStart.inputNumber="";
		CalculatorStart.previousNumber="";
		CalculatorStart.errorType = ConstantNumber.OVERFLOW_ERROR;
	}
	
	public int getArithmeticSignCount(String previousLabelText) { // 패널에 연산자가 몇개있는지 확인
		
		int count = 0;
		
		if(previousLabelText.contains("×"))
			count++;
		if(previousLabelText.contains("－"))
			count++;
		if(previousLabelText.contains("＋"))
			count++;
		if(previousLabelText.contains("÷"))
			count++;
		if(previousLabelText.contains("＝"))
			count++;
		
		return count;
	}
	

}
