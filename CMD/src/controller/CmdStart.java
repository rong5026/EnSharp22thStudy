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
import controller.Command.Help;
import controller.Command.Move;
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
	private Copy copy;
	private Move move;
	private InputException inputException;
	
	
	public  CmdStart() {
		currentAddress ="C:\\Users\\"+System.getProperty("user.name");
		
		mainText= new MainText();
		dir= new Dir( );
		help = new Help();
		cd = new Cd();
		copy = new Copy();
		move = new Move();
		
		inputException = new InputException();
	}
	
	
	public void start() throws IOException {
		int commandType;
		mainText.showMain(); // 처음 문구
		
		while(ConstantsNumber.IS_CMD_ON) {
			
			mainText.showInput(currentAddress);
			
			inputText = new Scanner(System.in).nextLine();
			commandType = inputException.distinguishCommand(inputText);
			
			switch (commandType) {
			
			case  ConstantsNumber.CD:  
				cd.start(this,inputText);
				break;
			case ConstantsNumber.DIR: 
				dir.start("C:\\Users\\rong5");
				break;
			case ConstantsNumber.CLS: 
				mainText.showCls();
				break;
			case ConstantsNumber.HELP: 
				help.start();
				break;
			case ConstantsNumber.COPY: 
				copy.copyFolerToFile(new File("C:\\Users\\rong5\\Desktop\\3"),new File("C:\\Users\\rong5\\Desktop\\65.txt") );
				break;
			case  ConstantsNumber.MOVE: 
				move.moveFolerToFolder(new File("C:\\Users\\rong5\\Desktop\\11"),new File("C:\\Users\\rong5\\Desktop\\11"));
				break;
				
			default:
				
			}
		}
	}
	
	
	

	
}
