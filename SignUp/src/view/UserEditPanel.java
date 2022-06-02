package view;

import java.awt.Dimension;
import java.awt.Font;
import java.awt.Label;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;

import controller.ComponentEdit;

public class UserEditPanel extends JPanel {
	
	
	private JLabel nameLabel;
	private JLabel idLabel;
	private JLabel passwordLabel;
	private JLabel passwordCheckLabel;
	private JLabel birthLabel;
	private JLabel emailLabel;
	private JLabel phoneLabel;
	private JLabel addressCodeLabel;
	private JLabel addressLabel;
	
	private ComponentEdit componentEdit;
	
	public UserEditPanel(ComponentEdit componentEdit) {
		
		this.componentEdit = componentEdit;
		
		
		//label 생성
		nameLabel = setLabelOption("Name",5);
		idLabel = setLabelOption("ID",5);
		passwordLabel = setLabelOption("PW",5);
		passwordCheckLabel = setLabelOption("CheckPW",5);
		birthLabel = setLabelOption("Birth/Sex",5);
		emailLabel =setLabelOption("E-mail",5);
		phoneLabel = setLabelOption("Phone",5);
		addressCodeLabel = setLabelOption("Zip Code",5);
		addressLabel =setLabelOption("Address",5);
		
		setLayout(null);
		
	}
	
	
	public void setLabel() {
		
		
				
	
		
	}
	
	
	private JLabel setLabelOption( String labelText,int labelHeight ) { // 라벨 텍스트, 크기 설정
		
		JLabel label = new JLabel(labelText);
		
		Font labelFont = new Font("Stencil",Font.BOLD,25);
		
		label.setPreferredSize(new Dimension(70,labelHeight));
		
		label.setFont(labelFont);
		
		return label;
		
	}
	
	
	
	

	

	
	
}
