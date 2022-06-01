package controller;

import java.io.Console;
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
import java.util.Scanner;

import controller.Command.Cd;
import controller.Command.Copy;
import controller.Command.Dir;
import controller.Command.Move;
import utility.ConstantsNumber;
import view.MainText;
import view.DirText;
import view.HelpText;

public class CmdStart {
	
	private MainText mainText;
	public String currentAddress;
	private String inputText;
	private Dir dir;
	private Cd cd;
	private Copy copy;
	private Move move;
	private InputException inputException;
	private HelpText helpText;
	
	
	public  CmdStart() {
		currentAddress ="C:\\Users\\"+System.getProperty("user.name");
		
		mainText= new MainText();
		dir= new Dir( );
		
		cd = new Cd();
		copy = new Copy();
		move = new Move();
		helpText = new HelpText();
		
		inputException = new InputException();
	}
	
	
	public void start() throws IOException {
		int commandType;
		mainText.showMain(); // 처음 문구
		
		while(ConstantsNumber.IS_CMD_ON) {
			
			mainText.showInput(currentAddress);
			
			inputText = new Scanner(System.in).nextLine();
			if(inputText!=null) {
			commandType = inputException.distinguishCommand(inputText);
			
			switch (commandType) {
			
			case ConstantsNumber.CD:  
				cd.start(inputText,this);
				break;
			case ConstantsNumber.DIR: 
				dir.start(inputText,this);
				break;
			case ConstantsNumber.CLS: 
				mainText.showCls();
				break;
			case ConstantsNumber.HELP: 
				helpText.showHelp();
				break;
			case ConstantsNumber.COPY: 
				copy.start(inputText, this);
				break;
			case  ConstantsNumber.MOVE: 
				move.start(inputText, this);
				break;
				
			default:
				
			}
			}
		}
	}
	
	
	

	
}
