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
	public void moveFolerToFolder(File firstAddressFile, File secondAdressFile) throws IOException {
		moveCount=0;
		if(secondAdressFile.isDirectory()) {		
			//같은 폴더로 이동할때 에러 처리해야함
			File file = new File( secondAdressFile+ "\\" + firstAddressFile.getName()  );
			executeMoveProcess(firstAddressFile,file);
		}
		else 
			runMoveProcess(firstAddressFile,secondAdressFile);
		
		 moveText.showCopyResult(moveCount);
	}
		
	// 파일 -> 파일
	public void moveFileToFile(File firstAdressFile, File secondAdressFile) throws IOException {
		moveCount=0;
		executeMoveProcess(firstAdressFile,secondAdressFile);
		moveText.showCopyResult(moveCount);
	}
		
	
	//파일 -> 폴더
	public void moveFileToFolder(File firstAdressFile, File secondAdressFile) throws IOException  {
		moveCount=0;
		File file = new File( secondAdressFile+ "\\" + firstAdressFile.getName()  );	
		executeMoveProcess(firstAdressFile,file);
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
	// yes.no,all 을 받고 runMoveProcess을 수행
	private void executeMoveProcess(File firstAdressFile,File secondAdressFile) throws IOException {
		if(secondAdressFile.exists()) {
			int inputResult = enterOverWrite(secondAdressFile);
			if(inputResult==ConstantsNumber.YES_INPUT || inputResult == ConstantsNumber.ALL_INPUT)
				runMoveProcess(firstAdressFile,secondAdressFile);
		}
		else
			runMoveProcess(firstAdressFile,secondAdressFile);
	}

		

		
}
