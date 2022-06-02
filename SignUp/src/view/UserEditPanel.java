package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Label;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

import controller.ComponentEdit;
import utility.ConstantNumber;

public class UserEditPanel extends JPanel {
	
	private ComponentEdit componentEdit;
	
	private ImageIcon backgroundIcon;
	private Image background;
	private JLabel nameLabel;
	private JLabel idLabel;
	private JLabel passwordLabel;
	private JLabel passwordCheckLabel;
	private JLabel birthLabel;
	private JLabel emailLabel;
	private JLabel phoneLabel;
	private JLabel addressCodeLabel;
	private JLabel addressLabel;
	
	private String[] labelName;
	
	
	
	public UserEditPanel(ComponentEdit componentEdit) {
		
		this.componentEdit = componentEdit;
		
		this.labelName = new String[] {"Name","ID", "PW", "CheckPW","Birth/Sex", "E-mail", "Phone","Zip Code","Address" };
		
		
		/*
		//label 생성
		nameLabel = setLabelOption("Name");
		idLabel = setLabelOption("ID");
		passwordLabel = setLabelOption("PW");
		passwordCheckLabel = setLabelOption("CheckPW");
		birthLabel = setLabelOption("Birth/Sex");
		emailLabel =setLabelOption("E-mail");
		phoneLabel = setLabelOption("Phone");
		addressCodeLabel = setLabelOption("Zip Code");
		addressLabel =setLabelOption("Address");
		*/
	
		createLabel();
		
		setLayout(null);
		
	}
	
	

	private void createLabel() {
		
		int width = 30;
		int height = 70;
		
		for(int index = 0 ; index < labelName.length ; index++) {
			
			JLabel label = setLabelOption(labelName[index]);
			
			label.setPreferredSize(new Dimension(200,60));
			
			label.setBackground(Color.red);
			
			label.setBounds(10,10+ index*height+3, height, width );
			
			add(label);
			
		}
		
		
	}
	private JLabel setLabelOption( String labelText ) { // 라벨 텍스트, 크기 설정
		
		JLabel label = new JLabel(labelText);
		
		
		
		Font labelFont = new Font("Stencil",Font.BOLD,25);
		
		label.setFont(labelFont);
		
		
		
		return label;
		
	}
	
	
	public void paintComponent(Graphics graphic) {  // mainframe 배경화면 설정
		
		super.paintComponent(graphic); // frame의 크기를 받기 위해 super
		
		this.backgroundIcon = new ImageIcon(ConstantNumber.USETEDIT_PANEL_IMAGE);
		
		this.background= backgroundIcon.getImage();   // mainframe 배경이미지
		
		graphic.drawImage(background, 0, 0,getWidth(),getHeight(),this); 
		
	}
	

	

	
	
}
