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

import org.w3c.dom.html.HTMLIsIndexElement;

import view.DirText;

public class Dir {

	private DirText dirText;
	
	
	public Dir() {
		dirText = new DirText();
	}
	public void start(String inputText) throws IOException  { // dir기능 수행
		
		File directory;
		File []fileList;
		int fileCount;
		int fileByteTotal;
	
		directory = new File(inputText);
		fileList = directory.listFiles();

		for (int index = 0; index < fileList.length; index++) {
			
			if(!fileList[index].isHidden()) {
				String date = getCreationDate(fileList[index]);
				String dir= getDIR(fileList[index]);
				String fileSize = getFileByte(fileList[index]);
				String fileName = fileList[index].getName();
				
				dirText.showDir(date, dir, fileSize, fileName);// 출력
			
			}
		}

	
		fileCount =getFileCount(fileList);//파일의 수
		fileByteTotal = sumFileByte(fileList);//파일의 크기합
	
		dirText.showDirLastText(fileCount,fileByteTotal,fileList.length);
		
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
	
	private String getFileByte(File file ) { // 파일의 크기, 파일의 수 측정
		DecimalFormat decFormat;
		int fileByteSize;
		if(file.isFile()) {
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
			if(fileList[index].isFile())
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

	
	
}
