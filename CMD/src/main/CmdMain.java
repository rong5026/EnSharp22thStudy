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

		//CmdStart cmd = new CmdStart();
		//cmd.start();
		
	
		String aString = "cd ..\\..";
		
		aString = aString.stripLeading();
		
		//System.out.println(aString.split(" ")[0]);
		//System.out.println(aString.charAt(2));
		
		if(aString.contains(". . \\.."))
			System.out.println("있음");
		else {
			System.out.println("없음");
		}
		 
		
		
	}
}

