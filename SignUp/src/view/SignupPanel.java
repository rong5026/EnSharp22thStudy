package view;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.border.LineBorder;

import controller.ComponentEdit;
import utility.ConstantNumber;

public class SignupPanel extends UserEditPanel{

	private ImageIcon backgroundIcon;
	private Image background;
	
	public SignupPanel(ComponentEdit componentEdit) {
		
		super(componentEdit);
		
		
		
		this.backButton.setBackground(new Color(204,204,255));
		
		this.editButton.setBackground(new Color(204,204,255)); // 버튼 색 변경
				
		this.editButton.setText("Sign Up"); //버튼 문구변경
		
		
	}


	public void paintComponent(Graphics graphic) {  // mainframe 배경화면 설정
		
		
		super.paintComponent(graphic); // frame의 크기를 받기 위해 super
		
		this.backgroundIcon = new ImageIcon(ConstantNumber.SIGNUP_PANEL_IMAGE);
		
		this.background= backgroundIcon.getImage();   // mainframe 배경이미지
		
		graphic.drawImage(background, 0, 0,getWidth(),getHeight(),this); 
		
	}
}
