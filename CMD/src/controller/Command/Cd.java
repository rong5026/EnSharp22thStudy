package controller.Command;

import java.io.File;

import javax.imageio.stream.ImageInputStreamImpl;

import controller.AddressProcessing;
import controller.CmdStart;
import utility.ConstantsNumber;
import view.ErrorText;

public class Cd {

	private ErrorText errorText;
	private AddressProcessing addressChange;
	public Cd() {
		addressChange = new AddressProcessing();
		errorText = new ErrorText();
		
	}
	
	
	public void start(String inputText,CmdStart cmdStart) {//cd 명령어 수행
		
		inputText = inputText.toLowerCase().stripLeading(); // 소문자, 앞 공백 삭제
		
		
		
		
		if(inputText.replace(" ", "") == "cd\\" && checkVaildCd(inputText,"\\")) { // cd\
			moveFirstAddress(cmdStart);
			System.out.println("1번에 들어옴");
		}
		else if(inputText.replace(" ", "").equals("cd..") && checkVaildCd(inputText,"..")) { // cd..
			moveBackOneAddress(cmdStart);	
			System.out.println("2번에 들어옴");
		}
		else if(inputText.replace(" ", "").equals("cd..\\..") && checkVaildCd(inputText,"..\\..")) { // cd..\..
			moveBackTwoAddress(cmdStart);
			System.out.println("3번에 들어옴");
		}
		else if(addressChange.removeBlackAddress(inputText).substring(3).contains("c:\\users")  &&  addressChange.checkValidAddress( addressChange.removeBlackAddress(inputText))){// c:\\ 첫주소부터 입력했을때	
			moveEnteredAddress( cmdStart, addressChange.removeBlackAddress(inputText).substring(3));	
			System.out.println("4번에 들어옴");
		}
		else if( !addressChange.removeBlackAddress(inputText).substring(3).contains("c:\\users") && addressChange.checkValidAddress( addressChange.removeBlackAddress(cmdStart.currentAddress +"\\"+inputText.substring(3) )) ) {
			moveEnteredAddress(cmdStart,cmdStart.currentAddress +"\\"+addressChange.removeBlackAddress(inputText).substring(3));
			System.out.println("5번에 들어옴");
		}
		else // 에러메시지 표시
			errorText.showNonValidAddress();
			
	}
	
	

	
	private boolean checkVaildCd(String inputText, String typeText) { // cd\ cd.. cd..\..가 유효한지 검사
		
		if(inputText.contains(typeText))
			return ConstantsNumber.IS_VALID_CDTYPE;
		else 
			return ConstantsNumber.IS_NON_VALID_CDTYPE;
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
		
		if(addressChange.countBackSlash(cmdStart.currentAddress)>=2) 
			 cmdStart.currentAddress = cmdStart.currentAddress.substring(0,backSlashIndex);
		
		
	}
	
	public void moveEnteredAddress(CmdStart cmdStart, String inputAddress) {//입력한 주소로 이동
		
		
		if(new File(inputAddress).isFile())
			errorText.showNotCorrectDirectory();
		else 
			cmdStart.currentAddress = inputAddress;
		
	}
	
	
	
	
}
