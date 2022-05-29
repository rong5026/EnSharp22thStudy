package controller.Command;

import java.awt.Window.Type;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
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
		
		//첫 주소 경로 있는지 확인
		//첫 파일 존재하는지 확인
		
		//두번째 주소 있는지 확인
		//두번째 파일 있는지 확인 - 1.없으면 생성,   2. 있으면 덮어쓰기
		
		
		
	}
	



	
	//폴더 - > 파일
	public void executeFolerToFile(File firstAdressFile, File secondAdressFile) throws IOException {
		 String files[] = firstAdressFile.list();
		 if(files!=null) {	
			 for (String file : files) {
				 File copyFile = new File(firstAdressFile, file);
				 if(!copyFile.isDirectory()) {
					 
					 FileInputStream input = new FileInputStream(file);        
					 FileOutputStream output = new FileOutputStream(secondAdressFile);
					 
					 byte[] buf = new byte[1024];
					
					 int readData;      
					 while ((readData = input.read(buf)) > 0) {    
						 output.write(buf, 0, readData);       
					 }
					
					  input.close();     
					  output.close();
					 
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
