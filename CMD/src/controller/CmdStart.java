package controller;

import java.io.Console;
import java.util.Scanner;

import utility.ConstantsNumber;
import view.MainText;

public class CmdStart {
	
	private MainText mainText;
	private String currentAddress;
	private String inputText;
	
	
	public  CmdStart() {
		currentAddress = "C:\\Users\\"+System.getProperty("user.name");
		
		mainText= new MainText();
	}
	
	
	public void start() {
		
		mainText.showMain(); // 처음 문구
		
		while(ConstantsNumber.IS_CMD_ON) {
			mainText.showInput(currentAddress);
			inputText = new Scanner(System.in).nextLine();
			
		}
		
	}
	
	

	
}
