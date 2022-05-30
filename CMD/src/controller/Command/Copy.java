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

import controller.CmdInput;
import controller.CmdStart;
import utility.ConstantsNumber;
import view.CopyText;

public class Copy {

	private CopyText copyText;
	private CmdInput cmdInput;
	private int copyCount;
	public Copy() {
		copyText = new CopyText();
		cmdInput = new CmdInput();
		copyCount=0;
	}
	
	
	
	public void startCopy() {
		
		
	}
	
	//폴더 - > 파일
	public void executeFolerToFile(File firstAddressFile, File secondAdressFile) throws IOException {
		
		copyCount=0;
		boolean inputAll =false;
		int inputResult = -1;
		
		String files[] = firstAddressFile.list();
	
		if(files!=null) {		
			  for (String file : files) {
				  
				  File copyFile = new File(firstAddressFile, file);
				  
				  if(!copyFile.isDirectory()) {
					 
					  //복사하는 폴더, 파일 이름 출력
					 copyText.showFolderFileName(firstAddressFile.getName(),copyFile.getName());
					
					 if(!inputAll) 
						 inputResult = enterOverWrite(copyFile,secondAdressFile,ConstantsNumber.FolderToFile);
					 
					 if(inputAll == true) {	 
						 runFolderCopy(copyFile,secondAdressFile);
						 continue;
					 }
					 else if( inputResult==ConstantsNumber.ALL_INPUT &&inputAll==false) {
						 inputAll= true;
						 runFolderCopy(copyFile,secondAdressFile);
					 }
					 else if( inputResult==ConstantsNumber.YES_INPUT &&inputAll==false) 			
						 runFolderCopy(copyFile,secondAdressFile);
				  }
			  }
		 }
		copyText.showCopyResult(copyCount);
		
	
	}
	


	//폴더 -> 폴더
	public void executeFolerToFolder(File firstAddressFile, File secondAdressFile) throws IOException {
		
		copyCount=0;
		boolean inputAll =false;
		int inputResult = -1;
		
		String files[] = firstAddressFile.list();
		
		if(files!=null) {		
			  for (String file : files) {
				  
				  File copyFile = new File(firstAddressFile, file);
				  
				  if(!copyFile.isDirectory()) {
					 
					  //복사하는 폴더, 파일 이름 출력
					 copyText.showFolderFileName(firstAddressFile.getName(),copyFile.getName());
					
					 if(!inputAll) 
						 inputResult = enterOverWrite(copyFile,secondAdressFile,ConstantsNumber.FolderToFolder);
					 
					 if(inputAll == true) {	 
						 runFileCopy( copyFile, new File(secondAdressFile, file));	
						 continue;
					 }
					 else if( inputResult==ConstantsNumber.ALL_INPUT &&inputAll==false) {
						 inputAll= true;
						 runFileCopy( copyFile, new File(secondAdressFile, file));
					 }
					 else if( inputResult==ConstantsNumber.YES_INPUT &&inputAll==false) 			
						 runFileCopy( copyFile, new File(secondAdressFile, file));
				  }
			  }
		 }
		copyText.showCopyResult(copyCount);
	}
	
	// 파일 -> 파일
	public void executeFileToFile(File firstAddressFile, File secondAdressFile) throws IOException {
		copyCount=0;
		
	
		if(secondAdressFile.exists()) { // 폴더안에 중복되는것이 있을때
			if(enterOverWrite(firstAddressFile,secondAdressFile,ConstantsNumber.FileToFile) == ConstantsNumber.YES_INPUT ||enterOverWrite(firstAddressFile,secondAdressFile,ConstantsNumber.FileToFile) == ConstantsNumber.ALL_INPUT  ) 
				runFileCopy( firstAddressFile, secondAdressFile);	
		}
		else 
			runFileCopy( firstAddressFile, secondAdressFile);
		
		
		copyText.showCopyResult(copyCount);
		
	}
	
	
	//파일 -> 폴더
	public void executeFileToFolder(File firstAddressFile, File secondAdressFile) throws IOException {
		copyCount=0;
		
		File file = new File( secondAdressFile+ "\\" + firstAddressFile.getName()  );
		
		if(file.exists()) { // 폴더안에 중복되는것이 있을때
			if(enterOverWrite(firstAddressFile,secondAdressFile,ConstantsNumber.FileToFolder) == ConstantsNumber.YES_INPUT ||enterOverWrite(firstAddressFile,secondAdressFile,ConstantsNumber.FileToFolder) == ConstantsNumber.ALL_INPUT  ) 	
				runFileCopy( firstAddressFile, file);
		}
		else 
			runFileCopy( firstAddressFile, file);
	
		copyText.showCopyResult(copyCount);
		
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
	
	
	
	


	
	
	
	
	
}
