package controller.Command;

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
		
		
		inputText = addressChange.setCompletedAddress(inputText, cmdStart); // 완벽한 주소로 변경
		
		if(  checkAbsoluteAddress(inputText)  &&  addressChange.checkValidAddress(inputText ))
			 moveEnteredAddress( cmdStart, inputText);	
		
		else if( !checkAbsoluteAddress(inputText)  && addressChange.checkValidAddress(  addressChange.setCompletedAddress(inputText, cmdStart))) 
			moveEnteredAddress(cmdStart, addressChange.setCompletedAddress(inputText, cmdStart));
	
		else // 에러메시지 표시
			errorText.showNonValidAddress();
	}
	
	
	private boolean checkAbsoluteAddress(String inputText) { //절대경로입력인지 확인
		
		if( inputText.contains(":"))
			return ConstantsNumber.IS_ABSOLUTE_ADDRESS;
		
		return ConstantsNumber.IS_NON_ABSOLUTE_ADDRESS;
	}
	



	
	public void moveEnteredAddress(CmdStart cmdStart, String inputAddress) throws IOException {//입력한 주소로 이동
		
		inputAddress = addressChange.setCompletedAddress(inputAddress,cmdStart);
		
		inputAddress = new File(inputAddress).getCanonicalPath();
		
		if(new File(inputAddress).isFile())
			errorText.showNotCorrectDirectory();
		else 
			cmdStart.currentAddress = inputAddress;
		
	}
	
	
	
	
}
