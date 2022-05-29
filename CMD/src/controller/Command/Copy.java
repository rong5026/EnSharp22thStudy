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

import controller.CmdStart;

public class Copy {

	
	
	public Copy() {
		
	}
	
	
	
	public void start(String firstAddress, String secondAddress ,String firstFileName, String secondFileName) {
		
	
		
		
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
		Files.copy(firstAdressFile.toPath(), file.toPath() , StandardCopyOption.REPLACE_EXISTING);
	}
	



	
	
	
	
	
}
