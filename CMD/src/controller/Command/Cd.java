package controller.Command;

import java.io.File;

import controller.CmdStart;

public class Cd {

	
	public Cd() {
		
		
	}
	
	
	public void startCd() {
		
		
		
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
	
	public void moveSubFolderAddress(CmdStart cmdStart , String inputAddress) {// cd 하위폴더 
		
		File file = new File(cmdStart.currentAddress+inputAddress);
		// 하위폴더 있는지 확인 후
		if(file.isDirectory())
			cmdStart.currentAddress = cmdStart.currentAddress+inputAddress;
	}
	private int countBackSlash(String currentAddress) { // 역슬래쉬 수
		return currentAddress.length() - currentAddress.replace(String.valueOf("\\"), "").length();
	}
	
}
