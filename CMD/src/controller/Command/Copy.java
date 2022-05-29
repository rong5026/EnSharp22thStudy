package controller.Command;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;

public class Copy {

	
	
	public Copy() {
		
	}
	
	
	
	public void start(String firstAddress, String secondAddress ,String firstFileName, String secondFileName) {
		
		//첫 주소 경로 있는지 확인
		//첫 파일 존재하는지 확인
		
		//두번째 주소 있는지 확인
		//두번째 파일 있는지 확인 - 1.없으면 생성,   2. 있으면 덮어쓰기
		
	}
	
	public void copyFileToFile(String firstAddress, String secondAddress) throws IOException { // 파일에서 파일 복사
		
		File firstFile = new File(firstAddress);
		File secondFile = new File(secondAddress);	
		Files.copy(firstFile.toPath(), secondFile.toPath() , StandardCopyOption.REPLACE_EXISTING);
		
	}
	
	
	
	
	
	
}
