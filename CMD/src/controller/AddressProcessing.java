package controller;

import java.io.File;

import controller.Command.Copy;
import utility.ConstantsNumber;

public class AddressProcessing {
	
	      
	

	public String removeBlackAddress(String inputAddress) { // 역슬래시앞에 공백 제거
		return inputAddress.replaceAll("\s{0,}\\\\", "\\\\");
	}
	
	public boolean checkValidAddress(String folderAddress) { //이동하려는 주소가 유효한지 검사
		
		File file = new File(folderAddress);
		
		if(file.exists()) 
			return ConstantsNumber.IS_VALID_ADDRESS;
		else 
			return ConstantsNumber.IS_NON_VALID_ADDRESS;
	}
	
	public int countBackSlash(String currentAddress) { // 역슬래쉬 수
		return currentAddress.length() - currentAddress.replace(String.valueOf("\\"), "").length();
	}
	
	public String setCompletedAddress(String inputAddress, CmdStart cmdStart) { // 완성된 주소 리턴
		
		if(!inputAddress.contains("c:\\users"))
			return cmdStart.currentAddress + "\\" + inputAddress;
		else 
			return inputAddress;
		
	}
	
}
