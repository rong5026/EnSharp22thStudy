package view;

public class MainText {

	
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
		System.out.println(mainAddress + "\n");
	}
	
}
