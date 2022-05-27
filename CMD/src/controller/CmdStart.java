package controller;

import java.io.Console;
import java.io.File;
import java.io.IOException;
import java.util.Scanner;

import controller.Command.Dir;
import controller.Command.Help;
import utility.ConstantsNumber;
import view.MainText;
import view.DirText;

public class CmdStart {
	
	private MainText mainText;
	private String currentAddress;
	private String inputText;
	private Dir dir;
	private Help help;
	
	public  CmdStart() {
		currentAddress = "C:\\Users\\"+System.getProperty("user.name");
		
		mainText= new MainText();
		
		dir= new Dir( );
		help = new Help();
	}
	
	
	public void start() throws IOException {
		
		mainText.showMain(); // 처음 문구
		
		while(ConstantsNumber.IS_CMD_ON) {
			mainText.showInput(currentAddress);
			inputText = new Scanner(System.in).nextLine();
			
			//dir.startDir("C:\\Users\\rong5");
			
			switch (inputText) {
			
			case "cd": 
				
				break;
			case "dir": 
				dir.startDir(inputText);
				break;
			case "cls": 
				mainText.showCls();
				break;
			case "help": 
				help.startHelp();
				break;
			case "copy": 
				
				break;
			case "move": 
	
				break;
				
			
			default:
				
			}
		
			
			
			
		}
		
	}
	
	

	
}
