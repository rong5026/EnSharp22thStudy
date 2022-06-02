package view;

import java.awt.BorderLayout;

import javax.swing.ImageIcon;
import javax.swing.JFrame;

import utility.ConstantNumber;

public class MainFrame {
	
	
	private JFrame mainFrame;
	
	public MainFrame() {
		
		
	}
	
	public void startMainFrame() {
		
		mainFrame = new JFrame();
		
		setMainFrame(); // main frame 초기설정
		
		mainFrame.setLayout(new BorderLayout()); // 창 레이아웃 
		
		
		mainFrame.setVisible(true);
		
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);//JFrame이 정상적으로 종료되게
		
		 
	}
	
	
	private void setMainFrame() { // mainframe 초기설정
		
		ImageIcon icon = new ImageIcon(ConstantNumber.SIGNUP_ICON_IMAGE);
		mainFrame.setIconImage(icon.getImage());
		
		mainFrame.setTitle("EN# SignUp");       //타이틀 이름 
		
		mainFrame.setSize(1400,900);			//프레임의 크기
		
		mainFrame.setResizable(false);           //창 크기 고정
		
		mainFrame.setLocationRelativeTo(null);   //창 가운데 배치
	}

}
