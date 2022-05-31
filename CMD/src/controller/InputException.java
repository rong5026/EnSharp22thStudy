package controller;

import java.util.StringTokenizer;

import utility.ConstantsNumber;
import view.ErrorText;

public class InputException {
	private ErrorText errorText;
	
	public InputException() {
		errorText = new ErrorText();
	}
	
	
	public int distinguishCommand(String inputText) {
		
		inputText = inputText.toLowerCase().stripLeading(); // 소문자로 변환, 앞 공백 삭제
	
		if(distinguishCd(inputText))
			return ConstantsNumber.CD;
		else if(confirmCommandType(inputText,"dir"))
			return ConstantsNumber.DIR;
		else if(confirmCommandType(inputText,"cls"))
			return ConstantsNumber.CLS;
		else if(confirmCommandType(inputText,"help"))
			return ConstantsNumber.HELP;
		else if(confirmCommandType(inputText,"copy"))
			return ConstantsNumber.COPY;
		else if(confirmCommandType(inputText,"move"))
			return ConstantsNumber.MOVE;
		else {
			errorText.showNonCommand(inputText.split(" ")[0]);
			return ConstantsNumber.NON_VALUE;
		}
		

	
	}
	
	private boolean distinguishCd(String inputText) { // cd인지 확인
		String input;
		

		if(inputText.equals("cd"))
			return ConstantsNumber.IS_CD;
		else if(inputText.substring(0, 2).equals("cd")) {
			input = inputText.replace(" ", "");
			
			if(input.charAt(2)=='.' ||input.charAt(2)=='\\' )
				return ConstantsNumber.IS_CD;
		}
		input = inputText.split(" ")[0]; 
		
		return confirmCommandType(inputText,"cd");

	}
	

	private boolean confirmCommandType(String inputText, String type) { // cd, dir, cls, help,copy,move인지 확인
		String input = inputText.split(" ")[0];
		
		if(input.equals(type))
			return ConstantsNumber.IS_COMMAND;
		else 
			return ConstantsNumber.IS_NON_COMMAND;
	}
	
	
	

}
