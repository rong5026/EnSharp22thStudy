package view;

import java.io.File;
import java.text.DecimalFormat;

public class ResultText {

	public void showDir(String date, String dir, String fileSize, String fileName) { // Dir 결과 출력
		System.out.printf("%s%9s%11s %s \n",date, dir,fileSize,fileName);
	}
	
	
	public void showDirLastText(int fileCount, int fileByteTotal,int directoryFileSum) { // Dir 마지막 문구인 파일의수, 바이트 수 출력
		DecimalFormat decFormat;
		long directoryByteTotal = 313238241280L - Long.valueOf(fileCount);
		
		decFormat = new DecimalFormat("###,###");
		String fileCountString =  decFormat.format(fileCount);  
		String fileByteTotalString = decFormat.format(fileByteTotal);  
		
		String directoryCountString =  decFormat.format(directoryFileSum-fileCount);  
		String directoryByteTotalString = decFormat.format(directoryByteTotal);  
		

		System.out.printf("              %s %10s  \n",fileCountString+"개 파일", fileByteTotalString+" 바이트");
		System.out.printf("              %s %10s  \n",directoryCountString+"개 디렉터리",directoryByteTotalString+" 바이트 남음");
		
		
	}
}
