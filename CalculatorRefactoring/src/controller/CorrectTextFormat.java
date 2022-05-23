package controller;

import java.awt.Font;
import java.math.BigDecimal;
import java.time.zone.ZoneOffsetTransitionRule;

import javax.swing.JLabel;

import view.TextPanel;

public class CorrectTextFormat {
	
	
	private JLabel inputJLabel;
	private JLabel previousJLabel;
	 
	public CorrectTextFormat(JLabel inputJLabel, JLabel previousJLabel) {
		this.inputJLabel = inputJLabel;
		this.previousJLabel = previousJLabel;
	}
	public String setCorrectInputPanel(String resultNumber) { // 콤마찍어주기. E -> e변경
		
		String result;
		BigDecimal bigDecimal;
		
		//result = addComma(resultNumber);
	
		result = resultNumber;
		result = changeEtoe(result);
		return result;
	}
	public String setCorrectPreviousPanel(String resultNumber) { // 콤마 삭제 , E ->e , 2.000 ->2
		
		String result;
		BigDecimal bigDecimal;
		
		if(new BigDecimal( removeComma(resultNumber)).compareTo(new BigDecimal("0"))==0)
			return "0";
		
		result = removeComma(resultNumber);
		
		
		result = removeDecimalPoint(result);
		result = changeEtoe(result);
		return result;
		
	}

	
	public String addComma(String resultNumber) { // 콤마찍기
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
		if(resultNumber.charAt(0)=='-') 
			integerPart = integerPart.replace("-", "");
	
		
		countNumber = integerPart.length()/3;
		if(integerPart.length()%3==0)
			countNumber--;
		
		for(int count = 0; count < countNumber ;count++) {
			
			firstText = integerPart.substring(0,integerPart.length()-3*(count+1)-count);
			secondText = integerPart.substring(integerPart.length()-3*(count+1)-count,integerPart.length());

			integerPart = firstText+ "," + secondText;
			
		}
		
		if(resultNumber.charAt(0)=='-')
			return "-"+integerPart+decimalPart;
		
		return integerPart+decimalPart;
	}
	// 콤마 삭제
	public String removeComma(String resultNumber) {
		return resultNumber.replace(",", "");
	}
	 // E ->e
	public String changeEtoe(String resultNumber) { 
		return resultNumber.replace("E", "e");
	}
	// e -> E
	public String changeetoE(String resultNumber) { 
		return resultNumber.replace("e", "E");
	}
	 // bigdecimal값에 소수점이 있으면 .000 없애기
	public String removeDecimalPoint(String resultNumber) {
		int zeroCount=0;
		String result;
		if(resultNumber.contains(".")) {
			
			for(int index = resultNumber.length()-1 ; index >=0 ; index--) {	
				if(resultNumber.charAt(index)=='0' ) {
					zeroCount++;
					continue;
				}
				break;
			}
			
			
			if(resultNumber.contains("E") || resultNumber.contains("e") )
				zeroCount = 0;
			result = resultNumber.substring(0, resultNumber.length()- zeroCount);
			if(result.charAt(result.length()-1) =='.')
				return result.substring(0,result.length()-1);
			return result;
		}
		return resultNumber;
	}

	
	public void changeFontSize(String resultNumber,String type) { // 글자의 수에따라 폰트 변경
		
		if(resultNumber.length() >=12 && type =="Down") 
			inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , inputJLabel.getFont().getSize()-3 ));
		
		else if(resultNumber.length()>=11 && type =="Up")
			inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , inputJLabel.getFont().getSize()+3 ));
	}
	
	public void changeResultFontSize(String resultNumber) {
		
		
		if(resultNumber.length()>=10)
			inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD ,55 - (resultNumber.length()-12 )*3));
		
	}
	
	public String setNegate(String inputValue) { //negate 설정
		
		return "negate(" + inputValue + ")";
	}
	
	
}
