package controller;

import java.awt.Font;
import java.awt.geom.RoundRectangle2D;
import java.math.BigDecimal;
import java.math.MathContext;
import java.math.RoundingMode;
import java.text.DecimalFormat;
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
			//연산할때
			if(previousJLabel.getText()!="" && CalculatorStart.inputNumber!="" && previousJLabel.getText().charAt(previousJLabel.getText().length()-1) != '＝') {
				
				mathSign = 	previousJLabel.getText().substring(previousJLabel.getText().length()-1);
				previusDouble =  new BigDecimal(CalculatorStart.previousNumber.replace("e", "E"));
				inputDoble = new BigDecimal(CalculatorStart.inputNumber.replace("e", "E"));
				
				calculateArithmeticSign(input);
			}
			else 
				// 연산안할때
				setPreviousText(input); 
				
			//입력값초기화
			CalculatorStart.inputNumber ="";
		
		}
		else {
			CalculatorStart.inputNumber = "";				
			inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55 ));						
			inputJLabel.setText("0");
			CalculatorStart.errorType =ConstantNumber.NON_ERROR;
		}
		
		
		CalculatorStart.mainFrame.setFocusable(true);
		CalculatorStart.mainFrame.requestFocus();
		} catch (NumberFormatException e) {
			
		}
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
		
	
		if(mathSign!=null && inputDoble!=null && previusDouble!=null) {
			
			
			switch (mathSign) {
			
			case "÷":				
				result = previusDouble.divide(inputDoble,MathContext.DECIMAL64);
				CalculatorStart.previousNumber = previusDouble.divide(inputDoble,MathContext.DECIMAL128).toPlainString();
				break;
			case "×":
				result = previusDouble.multiply(inputDoble,MathContext.DECIMAL64);
				CalculatorStart.previousNumber =   previusDouble.multiply(inputDoble,MathContext.DECIMAL128).setScale(16,RoundingMode.HALF_EVEN).toEngineeringString().replace("E", "e");
				break;
			case "－":
				result = previusDouble.subtract(inputDoble,MathContext.DECIMAL64);				
				CalculatorStart.previousNumber =  result.toEngineeringString().replace("E", "e");
				break;
			case "＋":
				result =previusDouble.add(inputDoble,MathContext.DECIMAL64);
				CalculatorStart.previousNumber =  result.toEngineeringString().replace("E", "e");
			
			default:
				break;
			}
			
			//오류인지 판별
			if(isOverFlowError(result,mathSign))
				return;
			
			// 연산결과리스트에 넣기
			resultList.add(new ResultDTO(  correctTextFormat.removeDecimalPoint(previusDouble.toEngineeringString())+mathSign+inputDoble.toEngineeringString()+"=" ,correctTextFormat.removeDecimalPoint(result.toEngineeringString())  ));
		
			
		
			
		}
		
		
		switch (input) {
		case "÷":	//나누기										
			previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel(String.valueOf(result.setScale(16,RoundingMode.HALF_UP)))+"÷");	
			break;
		case "×":	//곱하기			
			previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel(String.valueOf(result.setScale(16,RoundingMode.HALF_UP)))+"×");	
			break;
		case "－":	//빼기	
			previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"－");
			break;
		case "＋":	//더하기
			previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(String.valueOf(result))+"＋");	
			break;	
		case "＝":
			setDivisionNull(result,inputDoble);
			
		default:
			break;
		}
		
		setLogOfDivision(result);

	}
	
	
	private boolean isOverFlowError(BigDecimal result,String mathSign) { // 0나누기 에러, 오버플로 에러
		
		if(result.compareTo(new BigDecimal("9.999999999999375E+9999"))>0 && mathSign.equals("×")) {
			calculateOverFlow();
			return ConstantNumber.isERROR_ON;
		}
		
		if(inputDoble.compareTo(new BigDecimal("0"))==0 && mathSign.equals("÷")) {
			calculateDivision();
			return ConstantNumber.isERROR_ON;
		}
		
		return ConstantNumber.isERROR_OFF;
		
	}
	
	private void setDivisionNull(BigDecimal result, BigDecimal inputDouble ) { // 연산하는 =인지 숫자만옥 = 인지 
		if(result==null && inputDoble==null) {
			previousJLabel.setText( correctTextFormat.setCorrectPreviousPanel( CalculatorStart.inputNumber)+"＝");		
			CalculatorStart.previousNumber =previousJLabel.getText().substring(0,previousJLabel.getText().length()-1).replace(",", "");
		}
		else
			previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(previusDouble.setScale(16,RoundingMode.HALF_EVEN).toEngineeringString())  + mathSign  +correctTextFormat.removeDecimalPoint(inputDoble.toString()) +"＝");
		
	}
	
	
	private void setPreviousText(String input) {
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
	
	private void setLogOfDivision(BigDecimal result) {// 나누기일때 inputlable, previouslabel 

		if(result!=null && mathSign != "÷") {
			
			
		
			inputJLabel.setText(   correctTextFormat.setCorrectInputPanel(  correctTextFormat.removeDecimalPoint( String.valueOf(result) )) ) ;
			correctTextFormat.changeFont();
		}
		else if(result!=null && mathSign == "÷") {
			
			
			if(getDecimalNumberCount(  result.toPlainString() ) > 16) {
				inputJLabel.setText(   correctTextFormat.setCorrectInputPanel(correctTextFormat.removeDecimalPoint (   result.toString()))) ;
				previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(String.valueOf(previusDouble.setScale(16,RoundingMode.HALF_EVEN)))  + mathSign  +correctTextFormat.removeDecimalPoint(inputDoble.toString()) +"＝");
				
			}
			else {
				inputJLabel.setText(   correctTextFormat.setCorrectInputPanel(  correctTextFormat.removeDecimalPoint(    result.toPlainString()   ))) ;
				previousJLabel.setText(correctTextFormat.setCorrectPreviousPanel(previusDouble.setScale(16,RoundingMode.HALF_EVEN).toPlainString())  + mathSign  +correctTextFormat.removeDecimalPoint(inputDoble.toString()) +"＝");
			}
			correctTextFormat.changeFont();
			
		}
		
	}
	
	private int getDecimalNumberCount(String resultNumber) { // 소수점 몇번째 자리인지
		
		int count = 0;
		boolean isDot = false;
		
		for(int index = resultNumber.length()-1 ; index>=0; index--) {
			if(resultNumber.charAt(index)=='.')
				break;
			count++;
		}
		
		return count;
		
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
	
	private void calculateOverFlow() { //오버플로우 오류
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
	public void setPreviousValue(String mathSign) {
		
		previousJLabel.setText(  correctTextFormat.setCorrectPreviousPanel( inputJLabel.getText())+mathSign);		
		CalculatorStart.previousNumber = correctTextFormat.setCorrectPreviousPanel(inputJLabel.getText());
	}
	
	

}