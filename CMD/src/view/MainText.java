package view;

public class MainText {

	
	public void showMain() { // 메인 문구 출력
		
		System.out.println("Microsoft Windows [Version 10.0.19044.1706]\r\n"
				+ "(c) Microsoft Corporation. All rights reserved.\n");
		
	}
	
	public void showInput(String currentAddress) { //입력 문구 출력
		System.out.print(currentAddress + ">" );
	}
	
}