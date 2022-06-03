package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;

import controller.ComponentEdit;
import utility.ConstantNumber;

public class LogoutPanel extends JPanel{

	private ImageIcon backgroundIcon;
	private Image background;
	private ComponentEdit componentEdit;
	protected JLabel logoutRequest;
	protected JButton yesButton;
	protected JButton noButton;
	
	
	public LogoutPanel(ComponentEdit componentEdit) {
		
		this.componentEdit = componentEdit;
		
		
		this.yesButton = new JButton("Yes");
		
		this.noButton = new JButton("No"); // 버튼 생성
		
		logoutRequest = componentEdit.createLabelOption("Do you want to logout?"); // 라벨생성
		
		setLayout(null);
		
		
		logoutRequest.setBounds(150,200,500,70);
		
		logoutRequest.setBackground(new Color(255,175,175)); // 라벨 옵션
		
		setButton();// 버튼 옵션 적용
		
		yesButton.setBounds(300,400,200,60);
		
		noButton.setBounds(300,500,200,60);
		
		add(logoutRequest); 
		add(yesButton);
		add(noButton); // 라벨, 버튼 추가
		
		
		
	}
	
	public void setButton() {
		
		Color buttonColor = new Color(255,102,102);
		
		componentEdit.setButtonOption(yesButton, 35, buttonColor, 300, 50);
		
		componentEdit.setButtonOption(noButton, 35, buttonColor, 300, 50);
		
	}
	
	public void paintComponent(Graphics graphic) {  // mainframe 배경화면 설정
		
		super.paintComponent(graphic); // frame의 크기를 받기 위해 super
		
		this.backgroundIcon = new ImageIcon(ConstantNumber.Logined_PANEL_IMAGE);
		
		this.background= backgroundIcon.getImage();   // mainframe 배경이미지
		
		graphic.drawImage(background, 0, 0,getWidth(),getHeight(),this); 
		
	}
	
}
