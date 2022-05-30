package controller.Command;

import java.io.File;

import javax.imageio.stream.ImageInputStreamImpl;

import controller.CmdStart;
import utility.ConstantsNumber;

public class Cd {

	
	public Cd() {
		
		
		
	}
	
	
	public void start(CmdStart cmdStart,String inputText) {//cd 명령어 수행
		
		inputText = inputText.toLowerCase().stripLeading(); // 소문자, 앞 공백 삭제
		
		if(inputText.replace(" ", "") == "cd\\" && checkVaildCd(inputText,"\\")) // cd\
			moveFirstAddress(cmdStart);
		else if(inputText.replace(" ", "") == "cd.." && checkVaildCd(inputText,"..")) // cd..
			moveBackOneAddress(cmdStart);
		else if(inputText.replace(" ", "") == "cd..\\.." && checkVaildCd(inputText,"..\\..")) // cd..\..
			moveBackTwoAddress(cmdStart);
		//else if(inputText.substring(2).contains("c:\\users")  &&)
		
		
		
	}
	
	// cd:\dfsdfsd  \sdfsdfsd\dsfsd \sdfsdfs
	private String removeBlackBeforeBackSlash(String inputAddress) {
		
		while(true) {
			
			//if(inputAddress.contains(" \\")))
		}
		
		
	}

	
	private boolean checkVaildCd(String inputText, String typeText) { // cd\ cd.. cd..\..가 유효한지 검사
		
		if(inputText.contains(typeText))
			return ConstantsNumber.IS_VALID_CDTYPE;
		else 
			return ConstantsNumber.IS_NON_VALID_CDTYPE;
	}
	
	private boolean checkValidAddress(String folderAddress) { //이동하려는 주소가 유효한지 검사
		
		File file = new File(folderAddress);
		if(file.isDirectory()) 
			return ConstantsNumber.IS_VALID_ADDRESS;
		else 
			return ConstantsNumber.IS_NON_VALID_ADDRESS;
	}
	
	
	public void moveFirstAddress(CmdStart cmdStart) { // cd\  처음위치로 이동
		cmdStart.currentAddress = "C:\\";
	}
	
	public void moveBackTwoAddress(CmdStart cmdStart) { // cd..\.. 상위 2단계 위로이동
		
		moveBackOneAddress(cmdStart);
		moveBackOneAddress(cmdStart);
	
	}
	public void moveBackOneAddress(CmdStart cmdStart) { // cd..  상위 1단계 이동
		
		int backSlashIndex = cmdStart.currentAddress.lastIndexOf("\\");
		
		if(countBackSlash(cmdStart.currentAddress)>=2) 
			 cmdStart.currentAddress = cmdStart.currentAddress.substring(0,backSlashIndex);
	}
	
	public void moveEnteredAddress(CmdStart cmdStart, String inputAddress) {//입력한 주소로 이동
		cmdStart.currentAddress = inputAddress;
	}
	/*
	public void moveSubFolderAddress(CmdStart cmdStart , String inputAddress) {// cd 하위폴더 
		
		File file = new File(cmdStart.currentAddress+inputAddress);
		// 하위폴더 있는지 확인 후
		if(file.isDirectory())
			cmdStart.currentAddress = cmdStart.currentAddress+inputAddress;
	}
	*/
	
	private int countBackSlash(String currentAddress) { // 역슬래쉬 수
		return currentAddress.length() - currentAddress.replace(String.valueOf("\\"), "").length();
	}
	
}
