package view;

public class CopyText {

	public void showOverwriteMessage(String secondFileName) { //카피할때 덮어쓸지 물어보는 메세지
		
		System.out.print(secondFileName + "을(를) 덮어쓰시겠습니까? (Yes/No/All):");
	}
	
	public void showCopyResult(int copyedCount) { //복사된 파일 수 
		
		System.out.println("        "+copyedCount+"개 파일이 복사되었습니다.");
		//ex)         0개 파일이 복사되었습니다.
	}
	
	public void showOverwriteFileMessage(String folderName,String secondFileName) { // 옮기고자하는 곳에 중복된 이름이 있을때
		System.out.print(folderName+"\\");showOverwriteMessage(secondFileName);
		//ex)   폴더이름\3.txt를 덮어쓰시겠습니까?(yes/no/all)
	}
	
	
}