package controller;

import java.io.Console;
import java.io.File;
import java.io.IOException;
import java.util.Scanner;

import controller.Command.Dir;
import utility.ConstantsNumber;
import view.MainText;
import view.ResultText;

public class CmdStart {
	
	private MainText mainText;
	private String currentAddress;
	private String inputText;
	private ResultText resultText;
	private Dir dir;
	
	public  CmdStart() {
		currentAddress = "C:\\Users\\"+System.getProperty("user.name");
		
		mainText= new MainText();
		resultText = new ResultText();
		
		
		dir= new Dir(resultText);
	}
	
	
	public void start() throws IOException {
		
		mainText.showMain(); // 처음 문구
		
		while(ConstantsNumber.IS_CMD_ON) {
			mainText.showInput(currentAddress);
			inputText = new Scanner(System.in).nextLine();
			
			dir.startDir("C:\\Users\\rong5");
		
			
			
			
		}
		
	}
	
	

	
}
