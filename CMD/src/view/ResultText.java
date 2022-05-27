package view;

import java.io.File;

public class ResultText {

	public void showDir(String date, String dir, String fileSize, String fileName) {
		
		System.out.printf("%s%9s%11s %s \n",date, dir,fileSize,fileName);
		
	}
}
