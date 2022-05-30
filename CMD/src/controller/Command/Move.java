package controller.Command;

import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;

import controller.CmdInput;
import utility.ConstantsNumber;
import view.MoveText;

public class Move {
	

	private CmdInput cmdInput;
	private MoveText moveText;
	private int moveCount; 
	
	public Move(){
		moveText = new MoveText();
		cmdInput = new CmdInput();
		moveCount = 0;
	}
	
	

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
		
		System.out.println(file.getPath());
		System.out.println(file.getName());
		
		if(file.exists()) {
				
		}
		Files.move(firstAdressFile.toPath(), file.toPath() , StandardCopyOption.REPLACE_EXISTING);
	}
	
	
	// 문구 출력 후 입력
	private int enterOverWrite(File firstAddressFile, File secondAdressFile,int type) { 
		
		while(ConstantsNumber.IS_CMD_ON) {
			
			//문구 출력
			if(type == ConstantsNumber.FileToFolder || type == ConstantsNumber.FolderToFolder){//파일 - 폴더 ,  폴더 - 폴더
			}
			else if(type == ConstantsNumber.FileToFile || type == ConstantsNumber.FolderToFile) { // 파일 - 파일  , 폴더 - 파일
			
			}
			
			// yes,no,all 입력
			int input = cmdInput.enterYesNoAll();
			if( input != ConstantsNumber.INVALID_INPUT) {
				return input;
			}
			
		}
		
	}
		

		
}
