package view;

import java.io.File;
import java.text.DecimalFormat;

public class DirText {

	public void showDir(String date, String dir, String fileSize, String fileName) { // Dir 결과 출력
		System.out.printf("%s%9s%11s %s \n",date, dir,fileSize,fileName);
	}
	
	
	public void showDirLastText(int fileCount, int fileByteTotal,int directoryFileSum) { // Dir 마지막 문구인 파일의수, 바이트 수 출력
		DecimalFormat decFormat;
		long directoryByteTotal = 313238241280L - Long.valueOf(fileCount);
		decFormat = new DecimalFormat("###,###");
	
		System.out.printf("              %s %10s  \n",decFormat.format(fileCount)+"개 파일", decFormat.format(fileByteTotal)+" 바이트");
		System.out.printf("              %s %10s  \n",decFormat.format(directoryFileSum-fileCount)+"개 디렉터리",decFormat.format(directoryByteTotal)+" 바이트 남음");
		
	}
	
	
	
	
	

	
	
	
	
}
