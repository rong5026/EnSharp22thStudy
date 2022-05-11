package view;

import java.awt.Dimension;
import java.awt.GridBagLayout;
import java.awt.GridLayout;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JPanel;

import model.constants;

public class buttonPanel extends JPanel{
	
	private JButton [] button;
	private String [] buttonString;
	public buttonPanel() {
		
		setLayout(new GridLayout(5,4,1,1));
		button = new JButton[20];
		setPreferredSize(new Dimension(100,200));
		
		button[0] = new JButton("CE");
		button[1] = new JButton("C");
		button[2] = new JButton(new ImageIcon(constants.BACK_BUTTON_ICON));
		button[3] = new JButton(new ImageIcon(constants.DIVISION_BUTTON_ICON));
		
		button[4] = new JButton("7");
		button[5] = new JButton("8");
		button[6] = new JButton("9");
		button[7] = new JButton(new ImageIcon(constants.MULTIPLE_BUTTON_ICON));
		
		button[8] = new JButton("4");
		button[9] = new JButton("5");
		button[10] = new JButton("6");
		button[11] = new JButton(new ImageIcon(constants.MINUS_BUTTON_ICON));
		
		button[12] = new JButton("1");
		button[13] = new JButton("2");
		button[14] = new JButton("3");
		button[15] = new JButton(new ImageIcon(constants.PLUS_BUTTON_ICON));
		
		button[16] = new JButton(new ImageIcon(constants.PLUSMINUS_BUTTON_ICON));
		button[17] = new JButton("0");
		button[18] = new JButton(".");
		button[19] = new JButton(new ImageIcon(constants.EQUAL_BUTTON_ICON));
		
		for(int index = 0 ; index <20 ; index++) {
			
			add(button[index]);
		}
		
		
		
	}
	

}
