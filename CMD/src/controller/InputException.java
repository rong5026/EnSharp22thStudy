package controller;

import java.util.StringTokenizer;

import utility.ConstantsNumber;

public class InputException {
	
	
	/*
	public int distinguishCommand(String inputText) {
		
		inputText = inputText.toLowerCase().stripLeading(); // 소문자로 변환, 앞 공백 삭제
	
		String command = inputText.split(" ")[0];
		switch (command) {
		
		case "cd": 
			return ConstantsNumber.CD;
		case "dir":
			return ConstantsNumber.DIR;
		case "cls":
			return ConstantsNumber.CLS;
		case "help":
			return ConstantsNumber.HELP;
		case "copy":
			return ConstantsNumber.COPY;
		case "move":
			return ConstantsNumber.MOVE;

		default:
			throw new IllegalArgumentException("Unexpected value: " + key);
		}
	}
	*/
	private boolean distinguishCd(String inputText) { // cd인지 확인
		String input;
		
		if(inputText.substring(0, 2).equals("cd")) {
			input = inputText.replace(" ", "");
			
			if(input.charAt(2)=='.' ||input.charAt(2)=='\\' )
				return ConstantsNumber.IS_CD;
		}
		
		input = inputText.split(" ")[0]; // 앞 공백없고 공백으로 자른 첫단어
		
		if(input.equals("cd"))
			return  ConstantsNumber.IS_CD;
		
		return ConstantsNumber.IS_NON_CD;
		
	}
	
	//private boolean distinguishDir(String inputText) {
		
	//}
	

}
