package controller;

import java.io.Console;
import java.io.File;
import java.io.IOException;
import java.util.Scanner;

import controller.Command.Cd;
import controller.Command.Dir;
import controller.Command.Help;
import utility.ConstantsNumber;
import view.MainText;
import view.DirText;

public class CmdStart {
	
	private MainText mainText;
	public String currentAddress;
	private String inputText;
	private Dir dir;
	private Help help;
	private Cd cd;
	
	public  CmdStart() {
		currentAddress = "C:\\Users\\"+System.getProperty("user.name");
		
		mainText= new MainText();
		dir= new Dir( );
		help = new Help();
		cd = new Cd();
	}
	
	
	public void start() throws IOException {
		
		mainText.showMain(); // 처음 문구
		
		while(ConstantsNumber.IS_CMD_ON) {
			mainText.showInput(currentAddress);
			inputText = new Scanner(System.in).nextLine();
			
			//dir.startDir("C:\\Users\\rong5");
			
			switch (inputText) {
			
			case "cd": 
				cd.backOneAddress(this);
				break;
			case "dir": 
				//dir.startDir(inputText);
				dir.startDir("C:\\Users\\rong5");
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
	private void setAddress(String currentAddress) {
		this.currentAddress = currentAddress;
	}
	
	

	
}
