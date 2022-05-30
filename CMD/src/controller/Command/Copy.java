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
	public Copy() {
		copyText = new CopyText();
		cmdInput = new CmdInput();
	}
	
	
	
	public void startCopy() {
		
		
	}
	
	//폴더 - > 파일
	public void executeFolerToFile(File firstAdressFile, File secondAdressFile) throws IOException {
		
		 String files[] = firstAdressFile.list();
	
		 if(files!=null) {	
			 for (String file : files) {
				 File copyFile = new File(firstAdressFile, file);

				 if(!copyFile.isDirectory()) {
					 
		 
					 FileReader filereader = new FileReader(copyFile);
					 FileWriter fileWriter = new FileWriter(secondAdressFile,true);
					
					 int readData;      
					 while ((readData = filereader.read()) !=-1) {    
						 fileWriter.write(readData);       
					 }

					 fileWriter.close();
					 filereader.close();
				 }		 
			 }			
		 }
	}

	//폴더 -> 폴더
	public void executeFolerToFolder(File firstAdressFile, File secondAdressFile) throws IOException {
		int copyCount=0;
		boolean inputAll =false;
		int inputResult = -1;
		 String files[] = firstAdressFile.list();
		 if(files!=null) {		
			  for (String file : files) {
				  
				  File copyFile = new File(firstAdressFile, file);
				  
				
				  if(!copyFile.isDirectory()) {
					 
					  //복사하는 폴더, 파일 이름 출력
					 copyText.showOverWriteFolderToFolder(firstAdressFile.getName(),copyFile.getName());
					
					 if(!inputAll) 
						 inputResult = enterOverWrite(copyFile,secondAdressFile,ConstantsNumber.FolderToFolder);
					 
					 if(inputAll == true) {
						 Files.copy(copyFile.toPath(), new File(secondAdressFile, file).toPath() , StandardCopyOption.REPLACE_EXISTING);					
						  copyCount++;
						  continue;
					 }
					 else if( inputResult==ConstantsNumber.YES_INPUT &&inputAll==false) {
						  Files.copy(copyFile.toPath(), new File(secondAdressFile, file).toPath() , StandardCopyOption.REPLACE_EXISTING);					
						  copyCount++;
					 }
					 else if( inputResult==ConstantsNumber.ALL_INPUT &&inputAll==false) {
						 inputAll= true;
						  Files.copy(copyFile.toPath(), new File(secondAdressFile, file).toPath() , StandardCopyOption.REPLACE_EXISTING);					
						  copyCount++;

					 }
				  }
			  }
		 }
		copyText.showCopyResult(copyCount);
	}
	
	// 파일 -> 파일
	public void executeFileToFile(File firstAdressFile, File secondAdressFile) throws IOException {
		int copyCount=0;
		
	
	
		if(secondAdressFile.exists()) { // 폴더안에 중복되는것이 있을때
			
			if(enterOverWrite(firstAdressFile,secondAdressFile,ConstantsNumber.FileToFile) == ConstantsNumber.YES_INPUT ||
					enterOverWrite(firstAdressFile,secondAdressFile,ConstantsNumber.FileToFile) == ConstantsNumber.ALL_INPUT  ) {
				 Files.copy(firstAdressFile.toPath(), secondAdressFile.toPath() , StandardCopyOption.REPLACE_EXISTING);
				copyCount++;
			}
		}
		else {
			 Files.copy(firstAdressFile.toPath(), secondAdressFile.toPath() , StandardCopyOption.REPLACE_EXISTING);
			copyCount++;
		}
		
		copyText.showCopyResult(copyCount);
		
	}
	
	
	//파일 -> 폴더
	public void executeFileToFolder(File firstAdressFile, File secondAdressFile) throws IOException {
		int copyCount=0;
		
		File file = new File( secondAdressFile+ "\\" + firstAdressFile.getName()  );
		
		if(file.exists()) { // 폴더안에 중복되는것이 있을때
			
			if(enterOverWrite(firstAdressFile,secondAdressFile,ConstantsNumber.FileToFolder) == ConstantsNumber.YES_INPUT ||
					enterOverWrite(firstAdressFile,secondAdressFile,ConstantsNumber.FileToFolder) == ConstantsNumber.ALL_INPUT  ) {
				Files.copy(firstAdressFile.toPath(), file.toPath() , StandardCopyOption.REPLACE_EXISTING);
				copyCount++;
			}
		}
		else {
			Files.copy(firstAdressFile.toPath(), file.toPath() , StandardCopyOption.REPLACE_EXISTING);
			copyCount++;
		}
		
		copyText.showCopyResult(copyCount);
		
	}
	
	
	// 문구 출력 후 입력
	private int enterOverWrite(File firstAdressFile, File secondAdressFile,int type) { 
		
		while(ConstantsNumber.IS_CMD_ON) {
			
			//문구 출력
			if(type == ConstantsNumber.FileToFolder)//파일 - 폴더
				copyText.showOverwriteFileToFolder(secondAdressFile.getName(), firstAdressFile.getName());
			else if(type == ConstantsNumber.FileToFile) // 파일 - 파일
				copyText.showOverwriteFileToFile(secondAdressFile.getName());
			else if(type == ConstantsNumber.FolderToFolder)  // 폴더 - 폴더
				copyText.showOverwriteFileToFolder(secondAdressFile.getName(), firstAdressFile.getName());
			//else // 폴더 - 파일
			
			// yes,no,all 입력
			int input = cmdInput.enterYesNoAll();
			if( input != ConstantsNumber.INVALID_INPUT) {
				return input;
			}
			
		}
		
	}
	
	
	
	


	
	
	
	
	
}
