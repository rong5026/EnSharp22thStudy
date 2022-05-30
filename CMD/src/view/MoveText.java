package view;

public class MoveText {
	
	public void showOverwriteFile(String fileAddress) { //move할때 덮어쓸지 물어보는 메세지
		
		System.out.print(fileAddress + "을(를) 덮어쓰시겠습니까? (Yes/No/All):");
	}
	
	public void showCopyResult(int moveCount) { //복사된 파일 수 
		
		System.out.println("        "+moveCount+"개 파일을 이동했습니다.");
		//         0개 파일이 이동했습니다.
	}
	
	public void showError() {
		System.out.println("다른 프로세스가 파일을 사용 중이기 때문에 프로세스가 액세스 할 수 없습니다.");
	}
	
	
}
