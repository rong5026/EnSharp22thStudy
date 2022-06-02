package view;

import java.awt.Font;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;

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
	

	
	public UserEditPanel() {
		
		
		setLayout(null);
		
		
	}
	
	
	public void setLabel() {
		
		Font labelFont = new Font("Stencil",Font.BOLD,25);
				
		nameLabel = new JLabel("Name");
		idLabel = new JLabel("ID");
		passwordLabel = new JLabel("PW");
		passwordCheckLabel = new JLabel("CheckPW");
		birthLabel = new JLabel("Birth/Sex");
		emailLabel = new JLabel("E-mail");
		phoneLabel = new JLabel("Phone");
		addressCodeLabel = new JLabel("Zip Code");
		addressLabel = new JLabel("Address");
		
	
	}
	
	
	
	

	

	
	
}
