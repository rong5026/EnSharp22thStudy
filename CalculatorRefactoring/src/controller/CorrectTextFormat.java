package controller;

import java.awt.Font;
import java.math.BigDecimal;

import view.TextPanel;

public class CorrectTextFormat {
	public String setCorrectInputPanel(String resultNumber) { // 콤마찍어주기. E -> e변경
		
		String result;
		BigDecimal bigDecimal;
		
		result = addComma(resultNumber);
	
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
	public String removeComma(String resultNumber) { // 콤마 삭제
		
		return resultNumber.replace(",", "");
	}
	public String changeEtoe(String resultNumber) { // E ->e
		
		return resultNumber.replace("E", "e");
	}
	public String changeetoE(String resultNumber) { // e -> E
		return resultNumber.replace("e", "E");
	}
	public String removeDecimalPoint(String resultNumber) { // bigdecimal값에 소수점이 있으면 .000 없애기
		
	
		
		int zeroCount=0;
		String result;
		if(resultNumber.contains(".")) {
			
			for(int index = resultNumber.length()-1 ; index >=0 ; index--) {
				
				if(resultNumber.charAt(index)=='0' )
					zeroCount++;
				else {
					break;
				}
			}
			
			
			result = resultNumber.substring(0, resultNumber.length()- zeroCount);
			
			if(result.charAt(result.length()-1) =='.')
				return result.substring(0,result.length()-1);
			
			return result;
			
		}
		
		return resultNumber;
		
		
	}

	/*
	public void changeFontSize(String resultNumber,String type) { // 글자의 수에따라 폰트 변경
		
		if(resultNumber.length() >=12 && type =="Down") 
			TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , TextPanel.inputJLabel.getFont().getSize()-3 ));
		
		else if(resultNumber.length()>=11 && type =="Up")
			TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , TextPanel.inputJLabel.getFont().getSize()+3 ));
	}
	*/
	
}
