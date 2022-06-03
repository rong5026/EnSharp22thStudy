package view;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.border.LineBorder;

import controller.ComponentEdit;
import utility.ConstantNumber;

public class SignupPanel extends UserEditPanel{

	private ImageIcon backgroundIcon;
	private Image background;
	protected ComponentEdit componentEdit;
	public JButton checkingIdButton;
	public JButton findingAddressButton;
	
	
	public SignupPanel(ComponentEdit componentEdit) {
		
		super(componentEdit);
		
		this.componentEdit = componentEdit;
				
		this.editButton.setText("Sign Up"); //버튼 문구변경
		
		 // 아이디 중복 버튼
		checkingIdButton = new JButton("Double-Check");
	
		setButtonOption(checkingIdButton); // 아이디 중복 버튼 옵션
		
		checkingIdButton.setBounds(470,135,170,30);
		
		// 주소찾기 버튼
		findingAddressButton = new JButton("Search");
		
		setButtonOption(findingAddressButton); // 아이디 중복 버튼 옵션
		
		findingAddressButton.setBounds(630,585,120,30);
		
		
		 // 아이디중복, 주소찾기 버튼 추가
		add(checkingIdButton); 
		
		add(findingAddressButton); 
		
		
	}
	
	private void setButtonOption(JButton button) { // 버튼 색상, 크기 변경
		
	
		Color buttonColor =new Color(255,102,102);	
		
		componentEdit.setButtonOption(button, 15, buttonColor, 200, 20);
		
	}


	public void paintComponent(Graphics graphic) {  // mainframe 배경화면 설정
		
		
		super.paintComponent(graphic); // frame의 크기를 받기 위해 super
		
		this.backgroundIcon = new ImageIcon(ConstantNumber.SIGNUP_PANEL_IMAGE);
		
		this.background= backgroundIcon.getImage();   // mainframe 배경이미지
		
		graphic.drawImage(background, 0, 0,getWidth(),getHeight(),this); 
		
	}
}
