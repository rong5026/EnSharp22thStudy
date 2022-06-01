package controller.Command;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.nio.file.Files;
import java.nio.file.attribute.BasicFileAttributes;
import java.nio.file.attribute.FileTime;
import java.sql.Date;
import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;

import javax.lang.model.element.NestingKind;
import javax.naming.spi.DirStateFactory.Result;

import org.w3c.dom.html.HTMLIsIndexElement;

import controller.AddressProcessing;
import controller.CmdStart;
import view.CommandText;
import view.ErrorText;

public class Dir {

	private CommandText commandText;
	private AddressProcessing addressProcessing;
	private ErrorText errorText;
	
	
	public Dir(CommandText commandText,ErrorText errorText) {
		
		this.commandText = commandText;
		this.errorText = errorText;
		this.addressProcessing= new AddressProcessing();
	
		
	}
	
	public void start(String inputText,CmdStart cmdStart) throws IOException { // dir기능 수행
		
	
		
		inputText = inputText.toLowerCase().stripLeading(); // 소문자, 앞 공백 삭제
		String[] commandList = inputText.split("\\s{1,}"); // 공백으로 자르기
		
		commandText.showDirStartText(getCmdNumber(), cmdStart.currentAddress);  // C 드라이브의 볼륨에는 이름이 없습니다.볼륨 일련 번호: 6C68-809A
		
		
		
		if(commandList.length == 1) { // dir만 입력했을때
			
			runDir(cmdStart.currentAddress,cmdStart); // dir 수행
		}
		if(commandList.length == 2) { // dir, 주소 입력했을때	
		
			String address =addressProcessing.removeBlackAddress(addressProcessing.setCompletedAddress(commandList[1], cmdStart));
			
			
			if(new File(address).isDirectory())
				runDir(address,cmdStart);
			else {
				errorText.showNonValidDir();
			}
		}
		else 
			errorText.showNonValidDir();	
		
	}
	
	private void runDir(String inputText,CmdStart cmdStart) throws IOException  {
		File directory;
		File []fileList;
		int fileCount;
		int fileByteTotal;
		int count = 0;
		directory = new File(inputText);
		fileList = directory.listFiles();
		
		
		for (int index = 0; index < fileList.length; index++) {
			
			if(!fileList[index].isHidden()) {
				String date = getModifiedDate(fileList[index]); // 폴더마지막수정 날짜
				String dir= getDIR(fileList[index]);            // <DIR> 표시
				String fileSize = getFileByte(fileList[index]); // 파일 크기
				String fileName = fileList[index].getName();    // 파일 이름
				count++;
				commandText.showDir(date, dir, fileSize, fileName);// 출력
			
			}
		}

	
		fileCount =getFileCount(fileList);//파일의 수
		fileByteTotal = sumFileByte(fileList);//파일의 크기합
	
		commandText.showDirLastText(fileCount,fileByteTotal,count); // DIR 결과 출력
		
		
	}
	private String getModifiedDate(File file) throws IOException { // 파일,폴더수정날짜
		
	
		BasicFileAttributes atrribute;
		FileTime time;
		String dateForm;
		SimpleDateFormat simpleDateFormat;
		String result;
		
	
		atrribute = Files.readAttributes(file.toPath(), BasicFileAttributes.class);
		time = atrribute.lastModifiedTime();
		dateForm = "yyyy-MM-dd  aa hh:mm";       		     //날짜 형식
	    simpleDateFormat = new SimpleDateFormat(dateForm);
	    result = simpleDateFormat.format( new Date( time.toMillis() ) );

	    return result;
		
	}
	
	private String getDIR(File file) { // 폴더인지 파일인지 구분
		
		if(file.isFile())
			return "         ";
		else 
			return "    <DIR>";
	}
	
	private String getFileByte(File file ) { // 파일의 크기, 파일의 수 측정
		DecimalFormat decFormat;
		int fileByteSize;
		if(file.isFile() && !file.isHidden()) {
			decFormat = new DecimalFormat("###,###");
			fileByteSize = (int)file.length();
			return decFormat.format(fileByteSize);  
		}
		else 
			return "          ";
	}
	
	private int getFileCount(File []fileList) { // 폴더안 파일의 수 
		int count=0;
		for (int index = 0; index < fileList.length; index++) {
			if(fileList[index].isFile() &&  !fileList[index].isHidden())
				count++;
		}
		return count;
	}
	
	private int sumFileByte(File []fileList ) { // 폴더안 파일의 크기의 총합
		
		int sum = 0;
		for (int index = 0; index < fileList.length; index++) {
			sum+=(int)fileList[index].length();
		}
		
		return sum;
	}
	
	private  String getCmdNumber() throws IOException { // 볼륨 번호
		
		 Process process = Runtime.getRuntime().exec("cmd /c " + "dir");
	        BufferedReader reader = new BufferedReader(
	                new InputStreamReader(process.getInputStream(),"MS949"));
	      
	        StringBuffer sb = new StringBuffer();
	     
	        String cDirveName = reader.readLine();
	        String volumneNumber= reader.readLine();
	        sb.append(cDirveName);
	        sb.append("\n");
	        sb.append(volumneNumber);
	        
	   
	        return sb.toString();
	  
	   
	 
	}
	
	
	
}
