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
			if(file.exists()) {
				int inputResult = enterOverWrite(file);
				if(inputResult==ConstantsNumber.YES_INPUT || inputResult == ConstantsNumber.ALL_INPUT)
					runMoveProcess(firstAdressFile,file);
			}
			runMoveProcess(firstAdressFile,file);
		}
		//second폴더가 없을때
		else 
			runMoveProcess(firstAdressFile,secondAdressFile);
		
		 moveText.showCopyResult(moveCount);
	}
		
	// 파일 -> 파일
	//없는파일도 자동으로 바뀜
	public void moveFileToFile(File firstAdressFile, File secondAdressFile) throws IOException {
		
		if(secondAdressFile.exists()) {
			int inputResult = enterOverWrite(secondAdressFile);
			if(inputResult==ConstantsNumber.YES_INPUT || inputResult == ConstantsNumber.ALL_INPUT)
				runMoveProcess(firstAdressFile,secondAdressFile);
		}
		else 
			runMoveProcess(firstAdressFile,secondAdressFile);
		 
		 moveText.showCopyResult(moveCount);
	}
		
	
	//파일 -> 폴더
	public void moveFileToFolder(File firstAdressFile, File secondAdressFile) throws IOException  {
		File file = new File( secondAdressFile+ "\\" + firstAdressFile.getName()  );	
		
		if(file.exists()) {
			int inputResult = enterOverWrite(file);
			if(inputResult==ConstantsNumber.YES_INPUT || inputResult == ConstantsNumber.ALL_INPUT)
				runMoveProcess(firstAdressFile,file);
		}
		else 
			runMoveProcess(firstAdressFile,file);
		
		moveText.showCopyResult(moveCount);
	}
	
	
	// 문구 출력 후 입력
	private int enterOverWrite(File firstAddressFile) { 
		
		while(ConstantsNumber.IS_CMD_ON) {
			
			//문구 출력
			moveText.showOverwriteFile(firstAddressFile.getPath());
		
			// yes,no,all 입력
			int input = cmdInput.enterYesNoAll();
			if( input != ConstantsNumber.INVALID_INPUT) {
				return input;
			}
			
		}
		
	}
	
	//move 기능 수행
	private void runMoveProcess(File firstAdressFile,File file) throws IOException {
		Files.move(firstAdressFile.toPath(), file.toPath() , StandardCopyOption.REPLACE_EXISTING);
		moveCount++;
	}
		

		

		
}
