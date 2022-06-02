package view;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

import controller.ComponentEdit;
import utility.ConstantNumber;



public class MainPanel extends JPanel{  
	
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
	
	private ComponentEdit componentEdit;
	
	public MainPanel(ComponentEdit componentEdit) {

		idText = new JTextField();
		passwordText = new JPasswordField();
		
		loginButton = new JButton("Login");
		signUpButton = new JButton("Sign Up");
		idFindingButton = new JButton("Find ID");
		passwordFindingButton = new JButton("Find PW"); 
		
		this.componentEdit = componentEdit; // 컴포넌트 옵션 적용클래스
		
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
		
		label.setPreferredSize(new Dimension(200,200)); // 메인 레고아이콘
		
		
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
		
		
		 //JFormattedTextField
		
		
	}
	
	private void setMainButtonOption() { // 메인버튼 옵션
		
		Font buttonFont = new Font("Stencil",Font.BOLD,35);
		
		Font findingFont = new Font("Stencil",Font.BOLD,20);
		
		Color buttonColor = new Color(255,102,102);
		
		// 버튼 옵션 적용
		componentEdit.setButtonOption(loginButton,buttonFont,buttonColor);
		
		componentEdit.setButtonOption(signUpButton,buttonFont,buttonColor);
		
		componentEdit.setButtonOption(idFindingButton,findingFont,buttonColor);
		
		componentEdit.setButtonOption(passwordFindingButton,findingFont,buttonColor);
		
		
		// 버튼 크기 지정
		loginButton.setPreferredSize(new Dimension(300,50));
		
		signUpButton.setPreferredSize(new Dimension(300,50));

		idFindingButton.setPreferredSize(new Dimension(147,50));
		
		passwordFindingButton.setPreferredSize(new Dimension(147,50));
		
		
	}
	
	
	

	public void paintComponent(Graphics graphic) {  // mainframe 배경화면 설정
		
		super.paintComponent(graphic); // frame의 크기를 받기 위해 super
		
		this.backgroundIcon = new ImageIcon(ConstantNumber.MAIN_FRAME_IMAGE);
		
		this.background= backgroundIcon.getImage();   // mainframe 배경이미지
		
		graphic.drawImage(background, 0, 0,getWidth(),getHeight(),this); 
		
	}
	
}