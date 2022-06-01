package controller.Command;

import java.awt.event.InputEvent;
import java.io.File;
import java.io.IOException;

import javax.imageio.stream.ImageInputStreamImpl;

import controller.AddressProcessing;
import controller.CmdStart;
import utility.ConstantsNumber;
import view.CommandText;
import view.ErrorText;


public class Cd {

	private ErrorText errorText;
	private AddressProcessing addressChange;
	private CommandText commandText;
	
	public Cd(CommandText commandText,ErrorText errorText) {
		
		this.addressChange = new AddressProcessing();
		this.errorText =errorText;
		this.commandText = commandText;
		
	}
	
	public void start(String inputText,CmdStart cmdStart) throws IOException {
		inputText = inputText.toLowerCase().stripLeading(); // 소문자, 앞 공백 삭제
		
		inputText = addressChange.unifyAddress(inputText); // 슬래시를 역슬래시로 변환
		
		inputText =  addressChange.removeBlackAddress(inputText.substring(2)).stripLeading(); // cd를 제외하고 자른문자에서 앞공백 삭제
		
		
		
		if(inputText.charAt(0)=='\\' ) { // cd문 다음에 \가 제일 먼저나올때, 첫주소로 옮겨주고 \ 다음부터 주소 확인
	
			cmdStart.currentAddress = "C:\\";
			inputText = inputText.substring(1);
		}
		
		inputText = addressChange.setCompletedAddress(inputText, cmdStart); // 완벽한 주소로 변경
		if(  checkAbsoluteAddress(inputText)  &&  addressChange.checkValidAddress(inputText )) // 절대주소 , 유효한 주소일때
			 moveEnteredAddress( cmdStart, inputText);	
		
		else if( !checkAbsoluteAddress(inputText)  && addressChange.checkValidAddress(  addressChange.setCompletedAddress(inputText, cmdStart))) //절대 주소가 아닐때
			moveEnteredAddress(cmdStart, addressChange.setCompletedAddress(inputText, cmdStart)); // setCompletedAddress로 절대주소로 바꾼값을 넣어줌
	
		else // 에러메시지 표시
			errorText.showNonValidAddress();
	}
	
	
	private boolean checkAbsoluteAddress(String inputText) { //절대경로입력인지 확인
		
		if( inputText.contains(":"))
			return ConstantsNumber.IS_ABSOLUTE_ADDRESS;
		
		return ConstantsNumber.IS_NON_ABSOLUTE_ADDRESS;
	}
	



	
	public void moveEnteredAddress(CmdStart cmdStart, String inputAddress) throws IOException {//입력한 주소로 이동
		
		inputAddress = addressChange.setCompletedAddress(inputAddress,cmdStart); // 완전한 주소로 변환
		
		inputAddress = new File(inputAddress).getCanonicalPath(); // cd가 적용된 주소
		
		if(new File(inputAddress).isFile())
			errorText.showNotCorrectDirectory();
		else 
			cmdStart.currentAddress = inputAddress; // 주소를 변경
		
	}
	
	
	
	
}
