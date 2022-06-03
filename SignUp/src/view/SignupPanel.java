package view;

import java.awt.Color;

import javax.swing.border.LineBorder;

import controller.ComponentEdit;

public class SignupPanel extends UserEditPanel{

	public SignupPanel(ComponentEdit componentEdit) {
		
		super(componentEdit);
		
		
		
		this.backButton.setBackground(new Color(204,204,255));
		
		this.editButton.setBackground(new Color(204,204,255)); // 버튼 색 변경
				
		this.editButton.setText("Sign Up"); //버튼 문구변경
		
	
		
	
		
		
		
	}

}
