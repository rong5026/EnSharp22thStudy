package view;

import java.text.DecimalFormat;

public class CommandText {

	
	//Main 기능 텍스트
	
	public void showMain() { // 메인 문구 출력
		
		System.out.println("Microsoft Windows [Version 10.0.19044.1706]\r\n"
				+ "(c) Microsoft Corporation. All rights reserved.\n");
	}
	
	public void showInput(String currentAddress) { //입력 문구 출력
		
		System.out.println();
		System.out.print(currentAddress + ">" );
	}
	
	
	public void showCls() {  //cls 실행
		
		System.out.println("\n\n\n\n\n\n\n\n\n\n\\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"
				+ "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
	}
	
	public void showCdAddress(String mainAddress) { // cd기능에서 그냥 cd만 눌렀을때 출력
		
		System.out.println(mainAddress );
	}
	
	
	//copy 기능 텍스트
	
	public void showOverwriteFileToFile(String secondFileName) { //카피할때 덮어쓸지 물어보는 메세지
		
		System.out.print(secondFileName + "을(를) 덮어쓰시겠습니까? (Yes/No/All):");
	}
	
	public void showCopyResult(int copyedCount) { //복사된 파일 수 
		
		System.out.println("        "+copyedCount+"개 파일이 복사되었습니다.");
		
	}
	
	public void showOverwriteFileToFolder(String folderName,String secondFileName) { // 옮기고자하는 곳에 중복된 이름이 있을때
		
		System.out.print(folderName+"\\");showOverwriteFileToFile(secondFileName);
		
	}
	
	public void showFolderFileName(String folderName, String fileName) {
		System.out.println(folderName+"\\"+fileName);
		
	}
	
	
	
	//Dir 기능 텍스트
	
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

	public void showDirStartText(String startText,String address) {
		
		System.out.println(startText+"\n");
		System.out.println(address +" 디렉터리\n");
		
	}
	
	
	//Move 기능 텍스트
	
	public void showOverwriteFile(String fileAddress) { //move할때 덮어쓸지 물어보는 메세지
		
		System.out.print(fileAddress + "을(를) 덮어쓰시겠습니까? (Yes/No/All):");
	}
	
	public void showMoveResult(int moveCount) { //복사된 파일 수 
		
		System.out.println("        "+moveCount+"개 파일을 이동했습니다.");
		//         0개 파일이 이동했습니다.
	}
	
	public void showError() {
		System.out.println("다른 프로세스가 파일을 사용 중이기 때문에 프로세스가 액세스 할 수 없습니다.");
	}
	
	
	
	
	
}
