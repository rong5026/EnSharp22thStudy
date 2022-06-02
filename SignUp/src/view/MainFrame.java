package view;

import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.Graphics;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JPanel;

import utility.ConstantNumber;

public class MainFrame extends JFrame{
	
	
	private MainPanel mainPanel;
	
	
	public MainFrame() {
		
		setMainFrame();// mainframe 초기화
		
		mainPanel = new MainPanel();
		
	}
	
	
	public void startMainFrame() {
		
		
		setContentPane(mainPanel); // frame에 mainpanel로 변경
		
	
		
	}
	
	
	private void setMainFrame() { // mainframe 초기화
		
		ImageIcon icon = new ImageIcon(ConstantNumber.SIGNUP_ICON_IMAGE);
		
		setIconImage(icon.getImage()); // 아이콘 설정
		
		setTitle("EN# SignUp");       //타이틀 이름 
		
		setSize(1400,900);			//프레임의 크기
		
		setResizable(false);           //창 크기 고정
		
		setLocationRelativeTo(null);   //창 가운데 배치
		
		setLayout(new BorderLayout()); // 창 레이아웃 
		
		setVisible(true);
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);//JFrame이 정상적으로 종료되게
		 
	}
	

	class MainPanel extends JPanel{
		
		private ImageIcon backgroundIcon = new ImageIcon(ConstantNumber.MAIN_FRAME_IMAGE); 
		private Image background= backgroundIcon.getImage();    //배경이미지
		
		
		public void paintComponent(Graphics graphic) {
			
			super.paintComponent(graphic);
			
			graphic.drawImage(background, 0, 0,getWidth(),getHeight(),this);
			
		}
	}
	
	
	
	

}
