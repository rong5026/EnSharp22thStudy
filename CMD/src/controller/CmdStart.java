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

import view.CommandText;
import view.ErrorText;
import view.HelpText;

public class CmdStart {
	
	private CommandText commandText;
	public String currentAddress;
	private String inputText;
	private Dir dir;
	private Cd cd;
	private Copy copy;
	private Move move;
	private HelpText helpText;
	private ErrorText errorText;
	
	
	public  CmdStart() {
		
		currentAddress ="C:\\Users\\"+System.getProperty("user.name");
		
		commandText= new CommandText();
		errorText = new ErrorText();
		
		dir= new Dir(commandText,errorText);
		
		cd = new Cd(commandText,errorText);
		copy = new Copy(commandText,errorText);
		move = new Move(commandText,errorText,copy);
		helpText = new HelpText();

		
	}
	
	
	public void start() throws IOException {
		
		int commandType;
		commandText.showMain(); // 처음 문구
		
		while(ConstantsNumber.IS_CMD_ON) {
			
			commandText.showInput(currentAddress); // 현재 주소
			
			inputText = new Scanner(System.in).nextLine();
			
			if(inputText!=null) {
				
				commandType = distinguishCommand(inputText); // 입력
				
				switch (commandType) {
				
				case ConstantsNumber.CD:  //CD로 이동
					cd.start(inputText,this);
					break;
				case ConstantsNumber.DIR: //DIR로 이동
					dir.start(inputText,this);
					break;
				case ConstantsNumber.CLS: //CLS로 이동
					commandText.showCls();
					break;
				case ConstantsNumber.HELP: //Help로 이동
					helpText.showHelp();
					break;
				case ConstantsNumber.COPY: //Copy로 이동
					copy.start(inputText, this);
					break;
				case  ConstantsNumber.MOVE: // Move로 이동
					move.start(inputText, this);
					break;
					
				default:
					
				}
			
			}
		}
	}
	

	public int distinguishCommand(String inputText) { // 명령어 구분
		
		inputText = inputText.toLowerCase().stripLeading(); // 소문자로 변환, 앞 공백 삭제
	
		
		if(confirmCommandType(inputText,"cd"))
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
	

	private boolean confirmCommandType(String inputText, String type) { //  cls, help,copy,move인지 확인
		String input = inputText.substring(0, type.length());
		if(input.equals(type))
			return ConstantsNumber.IS_COMMAND;
		else 
			return ConstantsNumber.IS_NON_COMMAND;
	}
	
	
	
	

	
}
