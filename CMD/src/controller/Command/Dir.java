package controller.Command;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.attribute.BasicFileAttributes;
import java.nio.file.attribute.FileTime;
import java.sql.Date;
import java.text.DecimalFormat;
import java.text.SimpleDateFormat;

import javax.lang.model.element.NestingKind;
import javax.naming.spi.DirStateFactory.Result;

import view.ResultText;

public class Dir {

	private ResultText resultText;
	
	public Dir(ResultText resultText) {
		this.resultText = resultText;
	}
	public void startDir(String inputText) throws IOException  {
		
		File directory = new File(inputText);
		File []fileList = directory.listFiles();
		String date;
		String dir;
		String fileSize;
		String fileName;
		
		for (int index = 0; index < fileList.length; index++) {
			
			date = getCreationDate(fileList[index]);
			dir= getDIR(fileList[index]);
			fileSize = getFileByte(fileList[index]);
			fileName = fileList[index].getName();
			resultText.showDir(date, dir, fileSize, fileName);
		}
		
	}
	
	private String getCreationDate(File file) throws IOException { // 파일,폴더생성날짜
		
	
		BasicFileAttributes atrribute;
		FileTime time;
		String dateForm;
		SimpleDateFormat simpleDateFormat;
		String result;
			
		atrribute = Files.readAttributes(file.toPath(), BasicFileAttributes.class);
		time = atrribute.creationTime();
		dateForm = "yyyy-MM-dd  aa hh:mm";
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
	
	private String getFileByte(File file) { // 파일의 크기 
		if(file.isFile()) {
			DecimalFormat decFormat = new DecimalFormat("###,###");
			int fileByteSizeString = (int)file.length();
			return decFormat.format(fileByteSizeString);  
		}
		else 
			return "          ";
	}
	
	
}
