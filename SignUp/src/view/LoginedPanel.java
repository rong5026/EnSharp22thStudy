package view;

import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.Graphics;
import java.awt.GridLayout;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JPanel;

import controller.ComponentEdit;
import utility.ConstantNumber;


public class LoginedPanel extends JPanel{
	
	private ImageIcon backgroundIcon;
	private Image background;
	public JButton editButton;
	public JButton logOutButton;
	public JButton idDeleteButton;
	private ComponentEdit componentEdit;
	
	
	
	public LoginedPanel(ComponentEdit componentEdit) {

		this.componentEdit = componentEdit;
		
		editButton = new JButton("Edit");
		logOutButton = new JButton("Logout");
		idDeleteButton = new JButton("Delete");
		
		setLayout(null);
		
		setLoginedPanelComponent();
	}
	

	private void setLoginedPanelComponent() {
		
		
		JPanel whitePanel = new JPanel();
		
		whitePanel.setLayout(new FlowLayout(FlowLayout.CENTER,6,50));
		
		whitePanel.setBackground(new Color(255,255,255,150)); // 불투명 패널색
	
		whitePanel.setBounds(200,300,400,500);  // 불투평 흰색 패널 
		
		
		
		Color buttonColor = new Color(255,102,102);  // 버튼 색 설정
		
		// 버튼 옵션 적용 (변경할 버튼, 폰트사이즈, 버튼색, 가로길이, 세로길이)
		componentEdit.setButtonOption(editButton,35,buttonColor,250,100);
		
		componentEdit.setButtonOption(logOutButton,35,buttonColor,250,100);
		
		componentEdit.setButtonOption(idDeleteButton,35,buttonColor,250,100);
		

		whitePanel.add(editButton);
		whitePanel.add(logOutButton);
		whitePanel.add(idDeleteButton);
		
		add(whitePanel);
		
	}
	
	public void paintComponent(Graphics graphic) {  // mainframe 배경화면 설정
		
		super.paintComponent(graphic); // frame의 크기를 받기 위해 super
		
		this.backgroundIcon = new ImageIcon(ConstantNumber.Logined_PANEL_IMAGE);
		
		this.background= backgroundIcon.getImage();   // mainframe 배경이미지
		
		graphic.drawImage(background, 0, 0,getWidth(),getHeight(),this); 
		
	}

	
	
}
