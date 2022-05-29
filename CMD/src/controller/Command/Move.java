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
			 String files[] = firstAdressFile.list();
			 if(files!=null) {		
				  for (String file : files)
					  if(!new File(firstAdressFile, file).isDirectory()) 
						  Files.move(new File(firstAdressFile, file).toPath(), new File(secondAdressFile, file).toPath() , StandardCopyOption.REPLACE_EXISTING);
			  }
		}
		
		// 파일 -> 파일
		public void moveFileToFile(File firstAdressFile, File secondAdressFile) throws IOException {
			 Files.move(firstAdressFile.toPath(), secondAdressFile.toPath() , StandardCopyOption.REPLACE_EXISTING);
		}
		
		
		//파일 -> 폴더
		public void moveFileToFolder(File firstAdressFile, File secondAdressFile) throws IOException {
			File file = new File( secondAdressFile+ "\\" + firstAdressFile.getName()  );
			Files.move(firstAdressFile.toPath(), file.toPath() , StandardCopyOption.REPLACE_EXISTING);
		}
		

		
}
