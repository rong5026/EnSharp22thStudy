package controller.Command;

import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;

import controller.AddressProcessing;
import controller.CmdInput;
import controller.CmdStart;
import utility.ConstantsNumber;
import view.CommandText;
import view.ErrorText;


public class Move {
	

	private CmdInput cmdInput;
	private CommandText commandText;
	private ErrorText errorText;
	private AddressProcessing addressChange;
	private int moveCount; 
	
	public Move(CommandText commandText,ErrorText errorText){
		
		this.commandText =commandText;
		this.errorText= errorText;
		
		this.cmdInput = new CmdInput();
		this.addressChange = new AddressProcessing();
		this.moveCount = 0;
		
	}
	
	//시작
	public void start(String inputText, CmdStart cmdStart) throws IOException {
		
		inputText = inputText.toLowerCase().stripLeading(); // 소문자, 앞 공백 삭제
		
		String[] commandList = inputText.split("\\s{1,}"); // 공백으로 자르기
		
		if(commandList.length == 2) {  // 주소 1개 입력했을때
			runOneAddress(  addressChange.removeBlackAddress(commandList[1]) , cmdStart );
		}
		else if(commandList.length == 3) {  // 주소 2개 입력했을때
			runTwoAddress( addressChange.removeBlackAddress(commandList[1]),  addressChange.removeBlackAddress(commandList[2]), cmdStart); 
		}
		else { // 주소입력이 없을때
			errorText.showNonValidAddress();
		}
		
	}
	
	
	//폴더 -> 폴더
	private void moveFolerToFolder(File firstAddressFile, File secondAdressFile) throws IOException {
		moveCount=0;
		
		if(firstAddressFile.getPath()==secondAdressFile.getPath()) { // 주소가 같을때 오류
			errorText.showSameMove();
		}
		
		//second폴더가 있을때
		else if(secondAdressFile.isDirectory()) {
			File directory = new File( secondAdressFile+ "\\" + firstAddressFile.getName()  );
			runMoveProcess(firstAddressFile,directory);
			
		}
		//second폴더가 없을때
		else {
			runMoveProcess(firstAddressFile,secondAdressFile);
			commandText.showCopyResult(moveCount);
		}
		
	}
		
	
	// 파일 -> 파일
	private void moveFileToFile(File firstAdressFile, File secondAdressFile) throws IOException {
		
		moveCount=0;
		executeMoveProcess(firstAdressFile,secondAdressFile);
		commandText.showCopyResult(moveCount);
	}
		
	
	//파일 -> 폴더
	private void moveFileToFolder(File firstAdressFile, File secondAdressFile) throws IOException  {
		
		moveCount=0;
		File file = new File( secondAdressFile+ "\\" + firstAdressFile.getName()  );	
		executeMoveProcess(firstAdressFile,file);
		
		commandText.showCopyResult(moveCount);
	}
	
	
	// 주소 하나만 입력
	private void runOneAddress(String firstAddress,CmdStart cmdStart) throws IOException { 
		
		firstAddress = addressChange.setCompletedAddress(firstAddress,cmdStart); //완성된 주소로 변경
			
	
		if(addressChange.checkValidAddress(firstAddress)) {
			
			if(new File(firstAddress).isFile()) // 파일 -> 폴더 이동
				moveFileToFolder(new File(firstAddress), new File(cmdStart.currentAddress));
			
			else if(new File(firstAddress).isDirectory()) // 폴더 -> 폴더 이동
				moveFolerToFolder(new File(firstAddress), new File(cmdStart.currentAddress));
		}
		else 
			errorText.showNonValidFile();
	}
	
	
	// 두개의 주소 입력했을때
	private void runTwoAddress(String firstAddress, String secondAddress,CmdStart cmdStart) throws IOException { 
			
		firstAddress = addressChange.setCompletedAddress(firstAddress,cmdStart); 
		secondAddress = addressChange.setCompletedAddress(secondAddress,cmdStart); //완성된 주소로 변경
			
		if(addressChange.checkValidAddress(firstAddress)) {
				
			File firstFile = new File(firstAddress);
			File secondFile = new File(secondAddress);
				
				
			
			if( firstFile.isDirectory() && !secondFile.getName().contains(".")) { // 폴더 -> 폴더
				moveFolerToFolder(firstFile, secondFile);
			}
			else if( firstFile.isFile() && secondFile.getName().contains(".")) { // 파일 -> 파일
				moveFileToFile(firstFile, secondFile);
			}
			else if( firstFile.isFile() &&  !secondFile.getName().contains(".")) {// 파일 -> 폴더
				moveFileToFolder(firstFile, secondFile);
			}
			else {
				errorText.showNonValidAddress();
			}
		}
		
		else 
			errorText.showNonValidAddress();
			
	}
	
	
	// 문구 출력 후 입력
	private int enterOverWrite(File firstAddressFile) { 
		
		while(ConstantsNumber.IS_CMD_ON) {
			
			commandText.showOverwriteFile(firstAddressFile.getPath());//문구 출력
			
			int input = cmdInput.enterYesNoAll(); // yes,no,all 입력
			
			if( input != ConstantsNumber.INVALID_INPUT) 
				return input;
			
		}
	}
	
	
	//move 기능 수행
	private void runMoveProcess(File firstAdressFile,File file) throws IOException {
		
		Files.move(firstAdressFile.toPath(), file.toPath() , StandardCopyOption.REPLACE_EXISTING);
		moveCount++;
		
	}
	
	
	// yes.no,all 을 받고 runMoveProcess을 수행
	private void executeMoveProcess(File firstAdressFile,File secondAdressFile) throws IOException {
		
		if(secondAdressFile.exists()) {
			
			int inputResult = enterOverWrite(secondAdressFile);
			
			if(inputResult==ConstantsNumber.YES_INPUT || inputResult == ConstantsNumber.ALL_INPUT)
				runMoveProcess(firstAdressFile,secondAdressFile);
			
		}
		else
			runMoveProcess(firstAdressFile,secondAdressFile);
	}

		

		
}
