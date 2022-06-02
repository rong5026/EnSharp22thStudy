package view;

import javax.swing.JFrame;

public class MainFrame {
	
	
	private JFrame mainFrame;
	
	public MainFrame() {
		
		
	}
	
	public void startMainFrame() {
		
		mainFrame = new JFrame();
		
		mainFrame.setTitle("EN# SignUp");     //타이틀 이름 
		
		mainFrame.setSize(1400,900);//프레임의 크기
		
		mainFrame.setResizable(false);        //창 크기 고정
		
		mainFrame.setLocationRelativeTo(null);//창 가운데 배치
		
		mainFrame.setVisible(true);
		
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);//JFrame이 정상적으로 종료되게
		
		 
	}

}
