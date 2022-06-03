package view;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.border.LineBorder;

import controller.ComponentEdit;
import utility.ConstantNumber;

public class DeletingPanel extends LogoutPanel{

	private ImageIcon backgroundIcon;
	private Image background;
	
	
	public DeletingPanel(ComponentEdit componentEdit) {
		
		super(componentEdit);
		
		
		this.logoutRequest.setText("Do you want to Delete the ID?");
		

		this.noButton.setBackground(new Color(204,204,255));
		this.yesButton.setBackground(new Color(204,204,255));
		
		this.logoutRequest.setBackground(new Color(204,204,255));
		
		this.logoutRequest.setForeground(new Color(51,51,255));  // 글자색
		
		this.logoutRequest.setBorder(new LineBorder(Color.blue)); // 라벨 테두리
		

		//Color color = new Color(ABORT)
		//this.logoutNoButton.set
		
	}
	
	

}
