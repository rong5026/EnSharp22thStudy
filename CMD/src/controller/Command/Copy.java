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
		 String files[] = firstAdressFile.list();
		 if(files!=null) {		
			  for (String file : files)
				  if(!new File(firstAdressFile, file).isDirectory()) 
					  Files.copy(new File(firstAdressFile, file).toPath(), new File(secondAdressFile, file).toPath() , StandardCopyOption.REPLACE_EXISTING);
		  }
	}
	
	// 파일 -> 파일
	private void executeFileToFile(File firstAdressFile, File secondAdressFile) throws IOException {
		 Files.copy(firstAdressFile.toPath(), secondAdressFile.toPath() , StandardCopyOption.REPLACE_EXISTING);
	}
	
	
	//파일 -> 폴더
	private void executeFileToFolder(File firstAdressFile, File secondAdressFile) throws IOException {
		File file = new File( secondAdressFile+ "\\" + firstAdressFile.getName()  );
		
		if(file.exists()) {
			
			switch (enterOverWrite(firstAdressFile,secondAdressFile)) {
			case ConstantsNumber.YES_INPUT: 
				break;
			case ConstantsNumber.NO_INPUT: 
				break;
			case ConstantsNumber.ALL_INPUT: 
				break;
				
			default:
				
			}
			
			
		}
		
		Files.copy(firstAdressFile.toPath(), file.toPath() , StandardCopyOption.REPLACE_EXISTING);
	}
	
	
	// 문구 출력 후 yes,no,all 올바른 값을 받을 때까지 반복
	private int enterOverWrite(File firstAdressFile, File secondAdressFile) { 
		
		while(ConstantsNumber.IS_CMD_ON) {
			copyText.showOverwriteFileMessage(secondAdressFile.getName(), firstAdressFile.getName());
			
			if( cmdInput.enterYesNoAll() != ConstantsNumber.INVALID_INPUT)
				return cmdInput.enterYesNoAll();
		}
		
	}
	
	
	
	


	
	
	
	
	
}
