package controller.Command;

import java.awt.Window.Type;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;

import javax.swing.plaf.basic.BasicInternalFrameTitlePane.SystemMenuBar;

import controller.AddressProcessing;

import controller.CmdInput;
import controller.CmdStart;
import utility.ConstantsNumber;
import view.CopyText;
import view.ErrorText;

public class Copy {

	private CopyText copyText;
	private CmdInput cmdInput;
	private ErrorText errorText;
	private AddressProcessing addressChange;
	private int copyCount; 
	private boolean inputAll;
	
	public Copy() {
		copyText = new CopyText();
		cmdInput = new CmdInput();
		errorText = new ErrorText();
		addressChange = new AddressProcessing();
		copyCount=0;
		inputAll = false;
	}
	
	
	
	public void start(String inputText,CmdStart cmdStart) throws IOException { // copy 명령어 수행
		
		inputText = inputText.toLowerCase().stripLeading(); // 소문자, 앞 공백 삭제
		
		
		
		String[] commandList = inputText.split("\\s{1,}"); // 공백으로 자르기
		if(commandList.length == 2) { // 주소 1개 입력했을때
			runOneAddress(  addressChange.removeBlackAddress(commandList[1]),cmdStart);
		}
		else if(commandList.length == 3) { // 주소 2개 입력했을때
			runTwoAddress(addressChange.removeBlackAddress( commandList[1]),addressChange.removeBlackAddress(commandList[2]), cmdStart);
		}
		else
			errorText.showNonValidAddress();
	}

	
	//폴더 - > 파일
	private void copyFolerToFile(File firstAddressFile, File secondAdressFile) throws IOException {
		
		copyCount=0;
		inputAll =false;
		

		String files[] = firstAddressFile.list();
	
		if(files!=null) {	
			for (String file : files) {
				File copyFile = new File(firstAddressFile, file);
				if(secondAdressFile.exists())
					runProcessFromFolder(copyFile,firstAddressFile,secondAdressFile,file, ConstantsNumber.FolderToFile);
				else 
					runFolderOrFileCopy(copyFile,secondAdressFile ,file,ConstantsNumber.FolderToFile);
				
			}
		 }
		copyText.showCopyResult(copyCount);
	}

	//폴더 -> 폴더
	private void copyFolerToFolder(File firstAddressFile, File secondAdressFile) throws IOException {
		
		
		copyCount=0;
		inputAll =false;
		int inputResult = -1;
		
		String files[] = firstAddressFile.list();
		
		
		if(firstAddressFile.getPath() ==secondAdressFile.getPath()) { // 같은 폴더 복사하려고 할때
			errorText.showSameCopy();
		}
		else if(files!=null) {	
		
			
			for (String file : files) {
				File copyFile = new File(firstAddressFile, file);
				File copiedFile = new File( secondAdressFile.getPath()+ "\\" + copyFile.getName()  );
				
				
				if(copiedFile.exists())
					runProcessFromFolder( copyFile, firstAddressFile,  secondAdressFile ,file, ConstantsNumber.FolderToFolder);
				else {
					runFolderOrFileCopy(copyFile,secondAdressFile ,file,ConstantsNumber.FolderToFolder);
				}
			
			}
		 }
		copyText.showCopyResult(copyCount);
		
	}
	
	// 파일 -> 파일
	private void copyFileToFile(File firstAddressFile, File secondAdressFile) throws IOException {
		copyCount=0;
		
		
		if(firstAddressFile.getPath() ==secondAdressFile.getPath()) { // 같은 파일 복사하려고 할때
			errorText.showSameCopy();
		}
		else if(secondAdressFile.exists()) { // 폴더안에 중복되는것이 있을때
			if(enterOverWrite(firstAddressFile,secondAdressFile,ConstantsNumber.FileToFile) == ConstantsNumber.YES_INPUT ||enterOverWrite(firstAddressFile,secondAdressFile,ConstantsNumber.FileToFile) == ConstantsNumber.ALL_INPUT  ) 
				runFileCopy( firstAddressFile, secondAdressFile);	
		}
		else 
			runFileCopy( firstAddressFile, secondAdressFile);
		
		copyText.showCopyResult(copyCount);
		
	}
	
	
	//파일 -> 폴더
	private void copyFileToFolder(File firstAddressFile, File secondAdressFile) throws IOException {
		copyCount=0;
		
		File file = new File( secondAdressFile.getPath()+ "\\" + firstAddressFile.getName()  );
		
		
		if(file.exists()) { // 폴더안에 중복되는것이 있을때
			int select = enterOverWrite(firstAddressFile,secondAdressFile,ConstantsNumber.FileToFolder);
			if(select == ConstantsNumber.YES_INPUT ||select == ConstantsNumber.ALL_INPUT  ) 	
				runFileCopy( firstAddressFile, file);
		}
		else 
			runFileCopy( firstAddressFile, file);
	
		copyText.showCopyResult(copyCount);
		
	}
	
	//하나의 주소만 입력했을때
	private void runOneAddress(String firstAddress,CmdStart cmdStart) throws IOException { 
		
		firstAddress = addressChange.setCompletedAddress(firstAddress,cmdStart); //완성된 주소로 변경
		
		if(addressChange.checkValidAddress(firstAddress)) {
			if(new File(firstAddress).isFile()) // 파일 -> 폴더 복사
				copyFileToFolder(new File(firstAddress), new File(cmdStart.currentAddress));
			else if(new File(firstAddress).isDirectory()) // 폴더 -> 폴더 복사
				copyFolerToFolder(new File(firstAddress), new File(cmdStart.currentAddress));
		}
		else 
			errorText.showNonValidAddress();
		
	}
	
	// 두개의 주소 입력했을때
	private void runTwoAddress(String firstAddress, String secondAddress,CmdStart cmdStart) throws IOException { 
		
		
		firstAddress = addressChange.setCompletedAddress(firstAddress,cmdStart); 
		secondAddress = addressChange.setCompletedAddress(secondAddress,cmdStart); //완성된 주소로 변경
	
		
		if(addressChange.checkValidAddress(firstAddress)) {
			
			File firstFile = new File(firstAddress);
			File secondFile = new File(secondAddress);
			
			if(firstFile.isDirectory() && secondFile.getName().contains(".")) { // 폴더 -> 파일
				copyFolerToFile(firstFile, secondFile);
			}
			else if( firstFile.isDirectory() && !secondFile.getName().contains(".")) { // 폴더 -> 폴더
				copyFolerToFolder(firstFile, secondFile);
			}
			else if( firstFile.isFile() && secondFile.getName().contains(".")) { // 파일 -> 파일
				copyFileToFile(firstFile, secondFile);
			}
			else if( firstFile.isFile() && !secondFile.getName().contains(".")) { // 파일 -> 폴더
				copyFileToFolder(firstFile, secondFile);
			}
			else
				errorText.showNonValidAddress();
		}
		else 
			errorText.showNonValidAddress();
		
		
		
	}
	
	// 문구 출력 후 입력
	private int enterOverWrite(File firstAddressFile, File secondAdressFile,int type) { 
		
		while(ConstantsNumber.IS_CMD_ON) {
			
			//문구 출력
			if(type == ConstantsNumber.FileToFolder || type == ConstantsNumber.FolderToFolder)//파일 - 폴더 ,  폴더 - 폴더
				copyText.showOverwriteFileToFolder(secondAdressFile.getName(), firstAddressFile.getName());
			else if(type == ConstantsNumber.FileToFile || type == ConstantsNumber.FolderToFile) // 파일 - 파일  , 폴더 - 파일
				copyText.showOverwriteFileToFile(secondAdressFile.getName());
	
	
			// yes,no,all 입력
			int input = cmdInput.enterYesNoAll();
			if( input != ConstantsNumber.INVALID_INPUT) {
				return input;
			}
			
		}
		
	}
	
	//파일복사 실행
	private void runFileCopy(File firstAddressFile, File secondAddress) throws IOException {
		Files.copy(firstAddressFile.toPath(), secondAddress.toPath() , StandardCopyOption.REPLACE_EXISTING);
		copyCount++;
	}
	
	// 폴더 복사 실행
	private void runFolderCopy(  File copyFile,File secondAdressFile) throws IOException { 
		
		FileReader fileReader = new FileReader(copyFile);					
		FileWriter fileWriter = new FileWriter(secondAdressFile,true);
						
		int readData;      
	
		while ((readData = fileReader.read()) !=-1)  			
			fileWriter.write(readData);       			
				
		fileWriter.close();		
		fileReader.close();
		copyCount++;
	}
	
	// 폴더 -> 파일, 폴더-> 폴더  copy수행
	private void runProcessFromFolder(File copyFile,File firstAddressFile, File secondAdressFile ,String file,int copyType) throws IOException {
		
		int inputResult=-1;
		if(!copyFile.isDirectory()) {
			
			  //복사하는 폴더, 파일 이름 출력
		    copyText.showFolderFileName(firstAddressFile.getName(),copyFile.getName());
			
			if(!inputAll) 			
				inputResult = enterOverWrite(copyFile,secondAdressFile,copyType);
			 
			if(inputAll == true) 
				runFolderOrFileCopy(copyFile,secondAdressFile ,file,copyType);
				   
			else if( inputResult==ConstantsNumber.ALL_INPUT &&inputAll==false) {
				inputAll= true;
				runFolderOrFileCopy(copyFile,secondAdressFile ,file,copyType);
			}
			else if( inputResult==ConstantsNumber.YES_INPUT &&inputAll==false) 			
				runFolderOrFileCopy(copyFile,secondAdressFile ,file,copyType);
		  }
	}
	
	// copyType에 따라 폴더- 파일, 폴더-폴더 수행 구분
	private void runFolderOrFileCopy(File copyFile, File secondAdressFile ,String file,int copyType) throws IOException {
		
	
		if(copyType == ConstantsNumber.FolderToFile )
	
			runFolderCopy(copyFile,secondAdressFile);
		else 
			runFileCopy( copyFile, new File(secondAdressFile, file));
	   
	}
	


	
	
	
	
	
}
