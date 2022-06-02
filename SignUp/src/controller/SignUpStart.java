package controller;

import view.MainFrame;

public class SignUpStart {
	
	
	private MainFrame mainFrame;
	
	
	public SignUpStart() {
		
		this.mainFrame = new MainFrame();  //메인프레임 생성

	}
	
	
	public void start() {
		
		mainFrame.startMainFrame();
		
	}

}
