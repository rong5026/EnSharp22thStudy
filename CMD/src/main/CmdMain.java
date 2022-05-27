package main;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.InetAddress;
import java.nio.file.Files;
import java.nio.file.attribute.BasicFileAttributes;
import java.nio.file.attribute.FileTime;
import java.sql.Date;
import java.text.SimpleDateFormat;

import controller.CmdStart;

public class CmdMain {

	public static void main(String[] args) throws IOException {

		CmdStart cmd = new CmdStart();
		cmd.start();
		/*
		File directory = new File("C:\\Users\\rong5");
		File []fileList = directory.listFiles();
		
		for (int index = 0; index < fileList.length; index++) {
			

			BasicFileAttributes atrribute;
			FileTime time;
			String dateForm;
			SimpleDateFormat simpleDateFormat;
			String result;
				
			atrribute = Files.readAttributes(fileList[index].toPath(), BasicFileAttributes.class);
			time = atrribute.creationTime();
			dateForm = "yyyy-MM-dd  aa hh:mm";
		    simpleDateFormat = new SimpleDateFormat(dateForm);
		    result = simpleDateFormat.format( new Date( time.toMillis() ) );

		    System.out.println(result);
		    System.out.println(Integer.toString((int)fileList[index].length()));
		}
		*/
	}
}

