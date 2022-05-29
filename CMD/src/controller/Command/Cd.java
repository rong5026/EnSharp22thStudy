package controller.Command;

import controller.CmdStart;

public class Cd {

	
	public void moveFirstAddress(CmdStart cmdStart) { // cd\  처음위치로 이동
		cmdStart.currentAddress = "C:\\";
	}
	
	public void moveBackTwoAddress(CmdStart cmdStart) { // cd..\.. 상위 2단계 위로이동
		
		moveBackOneAddress(cmdStart);
		moveBackOneAddress(cmdStart);
	
	}
	public void moveBackOneAddress(CmdStart cmdStart) { // cd..  상위 1단계 이동
		
		int backSlashIndex = cmdStart.currentAddress.lastIndexOf("\\");
		
		//현재 주소에서 역슬래쉬가 2개 이상일때 상위 폴더로 이동
		if(countBackSlash(cmdStart.currentAddress)>=2) 
			 cmdStart.currentAddress = cmdStart.currentAddress.substring(0,backSlashIndex);
	}
	
	public void moveEnteredAddress(CmdStart cmdStart, String inputAddress) {Cd //입력한 주소로 이동
		
		cmdStart.currentAddress = inputAddress;
	}
	
	
	
	
	
	
	private int countBackSlash(String currentAddress) { // 역슬래쉬 수
		return currentAddress.length() - currentAddress.replace(String.valueOf("\\"), "").length();
	}
	
}
