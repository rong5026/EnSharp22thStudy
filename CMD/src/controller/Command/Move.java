package controller.Command;

import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;

public class Move {

	
	
	

		//폴더 -> 폴더
		public void moveFolerToFolder(File firstAdressFile, File secondAdressFile) throws IOException {
			
			//second폴더가 있을때
			if(secondAdressFile.isDirectory()) {
				File file = new File( secondAdressFile+ "\\" + firstAdressFile.getName()  );
				Files.move(firstAdressFile.toPath(), file.toPath() , StandardCopyOption.REPLACE_EXISTING);
			}
			//second폴더가 없을때
			else {
				Files.move(firstAdressFile.toPath(), secondAdressFile.toPath() , StandardCopyOption.REPLACE_EXISTING);
			}
			
		}
		
		// 파일 -> 파일
		//없는파일도 자동으로 바뀜
		public void moveFileToFile(File firstAdressFile, File secondAdressFile) throws IOException {
			 Files.move(firstAdressFile.toPath(), secondAdressFile.toPath() , StandardCopyOption.REPLACE_EXISTING);
		}
		
		
		//파일 -> 폴더
		public void moveFileToFolder(File firstAdressFile, File secondAdressFile) throws IOException {
			File file = new File( secondAdressFile+ "\\" + firstAdressFile.getName()  );
			Files.move(firstAdressFile.toPath(), file.toPath() , StandardCopyOption.REPLACE_EXISTING);
		}
		

		
}
