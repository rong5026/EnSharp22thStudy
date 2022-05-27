package controller.Command;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.attribute.BasicFileAttributes;
import java.nio.file.attribute.FileTime;
import java.sql.Date;
import java.text.SimpleDateFormat;

import javax.lang.model.element.NestingKind;
import javax.naming.spi.DirStateFactory.Result;

import view.ResultText;

public class Dir {

	private ResultText resultText;
	
	public void startDir(String inputText) {
		
		File directory = new File(inputText);
		File []fileList = directory.listFiles();
	
		
		for (int i = 0; i < fileList.length; i++) {
			
			resultText.showDir(inputText, inputText, inputText, inputText);
		}
		
	}
	
	private String getCreationDate(File file) throws IOException { // 파일,폴더생성날짜
		
	
		BasicFileAttributes attrs;
		FileTime time;
		String dateForm;
		SimpleDateFormat simpleDateFormat;
		String result;
			
		attrs = Files.readAttributes(file.toPath(), BasicFileAttributes.class);
		time = attrs.creationTime();
		dateForm = "yyyy-MM-dd aa hh:mm:ss";
	    simpleDateFormat = new SimpleDateFormat(dateForm);
	    result = simpleDateFormat.format( new Date( time.toMillis() ) );

	    return result;
		
	}
	
	private String discriminateDIR(File file) { // 폴더인지 파일인지 구분
		
		if(file.isFile())
			return "      ";
		else 
			return "<DIR>";
	}
	
	private String getFileByte(File file) { // 파일의 크기 
		if(file.isFile())
			return Integer.toString((int)file.length());
		else 
			return "           ";
	}
	
	
}
