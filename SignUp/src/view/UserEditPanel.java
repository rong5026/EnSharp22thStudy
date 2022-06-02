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
import javax.swing.border.LineBorder;

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
	
	private JButton backButton;
	private JButton editButton;
	
	private String[] labelName;
	private Color buttonColor;
	
	private int buttonWidth;
	private int buttonHeight;
	
	public UserEditPanel(ComponentEdit componentEdit) {
		
		this.componentEdit = componentEdit;
		
		this.labelName = new String[] {"Name","ID", "PW", "CheckPW","Birth/Sex", "E-mail", "Phone","Zip Code","Address" };
		
		this.buttonWidth = 250;
		this.buttonHeight = 50;
		setLabel(); // 라벨만들어서 배치
		
		setButton();
		
		
		
		setLayout(null);
		
	}
	
	
	private void setButton() { //버튼 배치
		
		createButton(); //버튼 생성
		
		backButton.setBounds(30,700,buttonWidth,buttonHeight);
		
		editButton.setBounds(300,700,buttonWidth,buttonHeight);
		
		add(backButton);
		
		add(editButton);
		
		
		
	}
	
	
	private void createButton() { // 버튼 생성
		
		buttonColor =new Color(255,102,102);	
		
		backButton = new JButton("Go Back");
		
		editButton = new JButton("Edit");
		
		componentEdit.setButtonOption(backButton,35,buttonColor,buttonWidth,buttonHeight); // 버튼 옵션 적용 (변경할 버튼, 폰트사이즈, 버튼색, 가로길이, 세로길이)
		
		componentEdit.setButtonOption(editButton,35,buttonColor,buttonWidth,buttonHeight);
	}

	
	private void setLabel() { // 라벨만들어서 배치
		
		int width = 150;
		int height = 70;
		
		for(int index = 0 ; index < labelName.length ; index++) {
			
			JLabel label = createLabelOption(labelName[index]);
		
			label.setBounds(30,10+ index*height+10, width, height );
			
			add(label); 
			
		}
		
	}
	
	
	private JLabel createLabelOption( String labelText ) { // 라벨 생성 후 옵션
		
		
		JLabel label = new JLabel(labelText);
		
		Font labelFont = new Font("Stencil",Font.BOLD,25);
		
		label.setForeground(new Color(199,23,23)); // 텍스트 색상
		
		label.setOpaque(true); //Opaque값을 true로 미리 설정해 주어야 배경색이 적용
		
		label.setBackground(new Color(255,175,175,230));  // 라벨 배경색
	
		label.setBorder(new LineBorder(Color.red)); // 라벨 테두리
		
		label.setFont(labelFont); // 라벨 폰트
		

		return label;
		
	}
	
	
	public void paintComponent(Graphics graphic) {  // mainframe 배경화면 설정
		
		
		super.paintComponent(graphic); // frame의 크기를 받기 위해 super
		
		this.backgroundIcon = new ImageIcon(ConstantNumber.USETEDIT_PANEL_IMAGE);
		
		this.background= backgroundIcon.getImage();   // mainframe 배경이미지
		
		graphic.drawImage(background, 0, 0,getWidth(),getHeight(),this); 
		
	}
	

	

	
	
}
