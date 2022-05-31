package view;

import javax.swing.plaf.basic.BasicInternalFrameTitlePane.SystemMenuBar;

public class ErrorText {

	public void showNonCommand(String nonCommandInput) { //유효한 명령어가 아닐때 
		System.out.println("'"+nonCommandInput+"'은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는\n배치 파일이 아닙니다.\n");
	}
	
	
	public void showNonValidAddress() {
		System.out.println("지정된 경로를 찾을 수 없습니다.\n");
	}
	public void showNonValidFile() {
		System.out.println("지정된 파일을 찾을 수 없습니다.\n");
		
	}
	
	public void showNotCorrectDirectory() {
		System.out.println("디렉터리 이름이 올바르지 않습니다.\n");
	}
	
	public void showSameCopy() {
		System.out.println("같은 파일로 복사할 수 없습니다.\n");
	}
	
	public void showSameMove() {
		System.out.println("다른 프로세스가 파일을 사용 중이기 때문에 프로세스가 액세스 할 수 없습니다.\n");
	}
	
	public void showSameFolderMove() {
		System.out.println("액세스가 거부되었습니다.\n");
	}
	public void showNonValidDir() {
		System.out.println("파일을 찾을 수 없습니다.");
	}
	
}
