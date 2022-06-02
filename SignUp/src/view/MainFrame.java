package view;

import java.awt.BorderLayout;
import java.awt.Button;
import java.awt.Container;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.TextField;

import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTextField;

import utility.ConstantNumber;

public class MainFrame extends JFrame{
	
	
	private MainPanel mainPanel;
	
	
	public MainFrame() {
		
		setMainFrame();// mainframe 초기화
		
		mainPanel = new MainPanel();
		
	}
	
	
	public void startMainFrame() {
		
		
		setContentPane(mainPanel); // frame에 mainpanel로 변경
		
		setVisible(true);
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);//JFrame이 정상적으로 종료되게
		
		
	}
	
	

	
	private void setMainFrame() { // mainframe 초기화
		
		ImageIcon icon = new ImageIcon(ConstantNumber.SIGNUP_ICON_IMAGE);
		
		setIconImage(icon.getImage()); // 아이콘 설정
		
		setTitle("EN# SignUp");       //타이틀 이름 
		
		setSize(900,1100);			//프레임의 크기
		
		setResizable(false);           //창 크기 고정
		
		setLocationRelativeTo(null);   //창 가운데 배치
		
		setLayout(new BorderLayout()); // 창 레이아웃 
		 
	}
	
}


class MainPanel extends JPanel{  
	
	private ImageIcon backgroundIcon;
	private Image background;
	private TextField idText;
	private TextField passwordText;

	public MainPanel() {

		idText = new TextField();
		passwordText = new TextField();
		
		
		setMainPanelComponent();
		setLayout(null);
	}
	
	
	private void setMainPanelComponent() { // mainPanel에 textfield, button 배치
		
		passwordText.setEchoChar('*'); // 비밀번호 입력시 *처리

		add(idText);
		add(passwordText);
		
		
		
	}
	
	private void setInputTextFile() {  // 입력 TextField 설정
		
		Font font = new Font("맑은고딕",Font.PLAIN,30);
		
		passwordText.setEchoChar('*'); // 비밀번호 입력시 *처리
		passwordText.setFont(font);
		passwordText.setBounds(10,20,12,12);
		
		
		idText.setFont(font);
		
	}
	
	
	public void paintComponent(Graphics graphic) {  // mainframe 배경화면 설정
		
		super.paintComponent(graphic); // frame의 크기를 받기 위해 super
		
		backgroundIcon = new ImageIcon(ConstantNumber.MAIN_FRAME_IMAGE);
		
		background= backgroundIcon.getImage();   // mainframe 배경이미지
		
		graphic.drawImage(background, 0, 0,getWidth(),getHeight(),this); 
		
	}
	
}
