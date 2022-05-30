package controller;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Scanner;

import utility.ConstantsNumber;

public class CmdInput {

	public int enterYesNoAll() { // yes, or, all중 선택
		String inputText = new Scanner(System.in).nextLine();
		
		inputText = inputText.toLowerCase();
		
		if(inputText=="" || inputText ==null)
			return ConstantsNumber.INVALID_INPUT;
		
		switch (inputText.charAt(0)){
		
		case 'y': 	
			return ConstantsNumber.YES_INPUT;
		
		case 'n':
			return ConstantsNumber.NO_INPUT;
			
		case 'a':
			return ConstantsNumber.ALL_INPUT;

		default:
			return ConstantsNumber.INVALID_INPUT;
		
		}
	}
	
	
	
	
}

