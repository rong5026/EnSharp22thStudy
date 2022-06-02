package view;

import java.awt.BorderLayout;
import java.awt.Button;
import java.awt.Container;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.TextField;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
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
		
		setSize(800,900);			//프레임의 크기
		
		setResizable(false);           //창 크기 고정
		
		setLocationRelativeTo(null);   //창 가운데 배치
		
		setLayout(new BorderLayout()); // 창 레이아웃 
		 
	}
	
}


class MainPanel extends JPanel{  
	
	private ImageIcon backgroundIcon;
	private Image background;
	private JTextField idText;
	private JPasswordField passwordText;
	private JButton login;
	private JButton signUp;
	private JButton idFinding;
	private JButton passwordFinding;

	public MainPanel() {

		idText = new JTextField();
		
		passwordText = new JPasswordField();
		
		
		login = new JButton("Login");
		
		signUp = new JButton("Sign Up");
		
		idFinding = new JButton("Find ID");
		
		passwordFinding = new JButton("Find PW");
		
		
		setMainInput(); // id, password TextField 설정
		
		setMainButton();
		
		
		add(idText);
		
		add(passwordText);
		
		
		
		
		
		setLayout(null);
		
	}
	
	
	private void setMainPanelComponent() { // mainPanel에 textfield, button 배치
		
		setMainInput(); 
		 
		 
		add(idText);
		
		add(passwordText);
		
		
	}
	
	
	private void setMainInput() {  // id, password TextField 설정
		
		Font font = new Font("맑은고딕",Font.PLAIN,25);
		
		idText.setFont(font);
		
		passwordText.setFont(font); // 폰트 설정
		
		
		idText.setHorizontalAlignment(JTextField.CENTER); 
		
		passwordText.setHorizontalAlignment(JTextField.CENTER); // 입력 가운데 정렬

		
		idText.setBounds(250,500,300,40);
		
		passwordText.setBounds(250,550,300,40); // 위치설정
		
		
		idText.requestFocus(); // 키보드 포커스 가져오기

		 //JFormattedTextField
		
		
	}
	
	private void setMainButton() {
		
		Font buttonFont = new Font("Stencil",Font.BOLD,30);
		
		
		setButtonOption(login,buttonFont);
		
		setButtonOption(signUp,buttonFont);
		
		setButtonOption(idFinding,buttonFont);
		
		setButtonOption(passwordFinding,buttonFont);
		
		
		
		add(idFinding);
		
		idFinding.setBounds(50,50,300,100);
		
		
		
	}
	
	private void setButtonOption(JButton button,Font font) { //버튼 폰트적용
		
		button.setBorderPainted(false); //테두리 제거
		
		button.setFocusPainted(false); //선택시 사각형생기는거 제거
		
		
		button.setFont(font);
		
		
	}
	
	
	public void paintComponent(Graphics graphic) {  // mainframe 배경화면 설정
		
		super.paintComponent(graphic); // frame의 크기를 받기 위해 super
		
		backgroundIcon = new ImageIcon(ConstantNumber.MAIN_FRAME_IMAGE);
		
		background= backgroundIcon.getImage();   // mainframe 배경이미지
		
		graphic.drawImage(background, 0, 0,getWidth(),getHeight(),this); 
		
	}
	
}
