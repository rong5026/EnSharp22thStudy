package view;

import java.awt.BorderLayout;
import java.awt.Button;
import java.awt.Color;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.GridLayout;
import java.awt.Image;
import java.awt.TextField;

import javax.swing.Box;
import javax.swing.Icon;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
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
	private JButton loginButton;
	private JButton signUpButton;
	private JButton idFindingButton;
	private JButton passwordFindingButton;

	private JPanel textFieldPanel;
	private JPanel buttonPanel;
	private ImageIcon icon;
	
	public MainPanel() {

		idText = new JTextField();
		passwordText = new JPasswordField();
		
		loginButton = new JButton("Login");
		signUpButton = new JButton("Sign Up");
		idFindingButton = new JButton("Find ID");
		passwordFindingButton = new JButton("Find PW");
		
	
		
	
		setMainPanelComponent();
		
		setLayout(null);
		
	}
	
	
	private void setMainPanelComponent() { // mainPanel에 textfield, button 배치
		
		JPanel whitePanel = new JPanel();
		
		whitePanel.setLayout(new FlowLayout(FlowLayout.CENTER,6,6));
		
		whitePanel.setBackground(new Color(255,255,255,150)); // 불투명 패널색
	
		whitePanel.setBounds(200,300,400,500);  // 흰색
		
		ImageIcon icon = new ImageIcon(ConstantNumber.MAIN_LEGO_IMAGE);
		JLabel label = new JLabel(icon);
		label.setIcon(icon);
		label.setPreferredSize(new Dimension(200,200));
		
		
		
		setMainInputOption();  //TextField 옵션적용
		
		setMainButtonOption(); //Button 옵션적용
		
		
	
		whitePanel.add(label);
		whitePanel.add(idText);
		whitePanel.add(passwordText);
		whitePanel.add(loginButton);
		whitePanel.add(signUpButton);
		whitePanel.add(idFindingButton);
		whitePanel.add(passwordFindingButton);

		
		add(whitePanel);
		
		
		
		
	}
	
	
	private void setMainInputOption() {  // 메인 TextField 옵션
		
		Font font = new Font("맑은고딕",Font.PLAIN,25);
		
		
		idText.setFont(font);
		passwordText.setFont(font); // 폰트 설정
		
		idText.setHorizontalAlignment(JTextField.CENTER); 
		passwordText.setHorizontalAlignment(JTextField.CENTER); // 입력 가운데 정렬

		idText.setPreferredSize(new Dimension(300,40));
		passwordText.setPreferredSize(new Dimension(300,40));
		
		idText.requestFocus(); // 키보드 포커스 가져오기
		
		
	
		
		
		
		
		//idText.setBounds(250,500,300,40);
		//passwordText.setBounds(250,550,300,40); // 위치설정
		

		 //JFormattedTextField
		
		
	}
	
	private void setMainButtonOption() { // 메인버튼 옵션
		
		Font buttonFont = new Font("Stencil",Font.BOLD,35);
		
		Font findingFont = new Font("Stencil",Font.BOLD,20);
		
		// 버튼 옵션 적용
		setButtonOption(loginButton,buttonFont);
		
		setButtonOption(signUpButton,buttonFont);
		
		setButtonOption(idFindingButton,findingFont);
		
		setButtonOption(passwordFindingButton,findingFont);
		
		
		// 버튼 크기 지정
		loginButton.setPreferredSize(new Dimension(300,50));
		
		signUpButton.setPreferredSize(new Dimension(300,50));

		idFindingButton.setPreferredSize(new Dimension(147,50));
		
		passwordFindingButton.setPreferredSize(new Dimension(147,50));
		
		
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
