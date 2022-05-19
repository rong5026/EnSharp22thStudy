package controller;

import java.awt.Font;

import view.TextPanel;

public class CorrectTextFormat {
	public String setCorrectInputPanel(String resultNumber) { // 콤마찍어주기. E -> e변경
		
		
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
			return "-"+integerPart.replace("E","e")+decimalPart.replace("E","e");
		
		return integerPart.replace("E","e")+decimalPart.replace("E","e");
		
	}
	
	
	public String setCorrectPreviousPanel(String resultNumber) { // 콤마 삭제 , E ->e
		
		String removeCommaString;
		
		removeCommaString = resultNumber.replace(",","");
		
		return removeCommaString.replace("E","e");
		
	}
	
	public void changeFontSize(String resultNumber,String type) { // 글자의 수에따라 폰트 변경
		
		if(resultNumber.length() >=12 && type =="Down") 
			TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , TextPanel.inputJLabel.getFont().getSize()-3 ));
		
		else if(resultNumber.length()>=11 && type =="Up")
			TextPanel.inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , TextPanel.inputJLabel.getFont().getSize()+3 ));
	}
	
}
