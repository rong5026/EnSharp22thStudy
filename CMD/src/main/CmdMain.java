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
import java.util.Arrays;

import controller.CmdStart;
import utility.ConstantsNumber;

public class CmdMain {

	public static void main(String[] args) throws IOException {

		//CmdStart cmd = new CmdStart();
		//cmd.start();
		
	
		File file = new File("C:\\Users\\rong5\\Desktop\\5");
		File file2 = new File("C:\\Users\\rong5\\Desktop\\5");
		
		if(file.getPath() == file2.getPath())
			System.out.println("같다");
		//String aString = "cd c:           \\users";
		
		//String[] liString = aString.split("\\s{1,}");
	
		//System.out.println(Arrays.toString(liString));
		//System.out.println(liString.length);
		//System.out.println("sdfsd"+liString[2]);
		//if(aString.contains(":\\"))
		//	System.out.println(aString);
		//aString = aString.replaceAll("\s{0,}\\\\", "\\\\");
		/*
		while(true) {
			System.out.println(aString);
			if(aString.contains(" \\")) {
				aString.replace(" \\", "\\");
			}
			else {
				break;
			}
		}
		*/
	
		//aString = aString.stripLeading();
		
		//System.out.println(aString.split(" ")[0]);
		//System.out.println(aString.substring(2));
		
	
		 
		
		
	}
}

