package controller.Command;

import java.awt.Window.Type;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
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
	
	//파일 - 파일
	public void conductFileToFile(String firstAddress, String secondAddress ,String firstFileName, String secondFileName,CmdStart cmdStart) throws IOException { // 파일에서 파일 복사
		
		File firstFile = new File(firstAddress+"\\" +firstFileName  );
		File secondFile = new File(secondAddress+"\\" +secondFileName );	
		Files.copy(firstFile.toPath(), secondFile.toPath() , StandardCopyOption.REPLACE_EXISTING);
		
	}
	


	//  폴더 - 폴더
	//  파일 - 파일
	//  파일 - 폴더   2번째 주소에 첫번째 주소의 firstAdressFile.getName() == 텍스트 파일이름을 더해서 넣어주기
	public void executeSame(File firstAdressFile, File secondAdressFile) throws IOException
	{
		  String files[] = firstAdressFile.list();
		  
		  if(files!=null) {
		
			  for (String file : files)
				  if(!new File(firstAdressFile, file).isDirectory()) 
					  Files.copy(new File(firstAdressFile, file).toPath(), new File(secondAdressFile, file).toPath() , StandardCopyOption.REPLACE_EXISTING);
		  }
		  else {
			
			  Files.copy(firstAdressFile.toPath(), secondAdressFile.toPath() , StandardCopyOption.REPLACE_EXISTING);
		  }
	}
	



	
	
	
	
	
}
