package view;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.GridBagLayout;
import java.awt.GridLayout;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JPanel;

import model.Constants;
import controller.MouseClick;

public class ButtonPanel extends JPanel{
	
	private JButton [] button;
	
	public ButtonPanel() {
		
		setLayout(new GridLayout(5,4,1,1));
		button = new JButton[20];
		setPreferredSize(new Dimension(0,400));
		
		button[0] = new JButton("CE");
		button[1] = new JButton("C");
		button[2] = new JButton(new ImageIcon(Constants.BACK_BUTTON_ICON));
		button[3] = new JButton(new ImageIcon(Constants.DIVISION_BUTTON_ICON));
		
		button[4] = new JButton("7");
		button[5] = new JButton("8");
		button[6] = new JButton("9");
		button[7] = new JButton(new ImageIcon(Constants.MULTIPLE_BUTTON_ICON));
		
		button[8] = new JButton("4");
		button[9] = new JButton("5");
		button[10] = new JButton("6");
		button[11] = new JButton(new ImageIcon(Constants.MINUS_BUTTON_ICON));
		
		button[12] = new JButton("1");
		button[13] = new JButton("2");
		button[14] = new JButton("3");
		button[15] = new JButton(new ImageIcon(Constants.PLUS_BUTTON_ICON));
		
		button[16] = new JButton(new ImageIcon(Constants.PLUSMINUS_BUTTON_ICON));
		button[17] = new JButton("0");
		button[18] = new JButton(".");
		button[19] = new JButton(new ImageIcon(Constants.EQUAL_BUTTON_ICON));
		
		
		
		for(int index = 0 ; index <20 ; index++) {
			
			add(button[index]);
			setFont(button[index]);
			
			if( 0<= index && index <=3) 
				button[index].setBackground(new Color(232,232,232));			
			else 
				button[index].setBackground(new Color(252,252,252));
			
			button[7].setBackground(new Color(232,232,232));			
			button[11].setBackground(new Color(232,232,232));		
			button[15].setBackground(new Color(232,232,232));		
			button[19].setBackground(new Color(153,204,255));		
			
			button[index].addMouseListener(new MouseClick());
					
		}
		
	}
	public void setFont(JButton button) { // 버튼 폰트 변경
		
		Font font;
		
		font = new Font("맑은 고딕", Font.BOLD, 20);
		button.setFont(font);
	}
	
	

}