package view;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;

import javax.swing.Box;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JPanel;

import model.constants;

public class menuPanel extends JPanel{

	private Dimension dimension ;
	private JButton historyButton;
	private JButton menuButton;
	private JButton zoomButton;
	private Box box;
	
	public menuPanel() {
		
		dimension = new Dimension(20,50);
		setLayout(new FlowLayout(FlowLayout.LEFT));
		setPreferredSize(new Dimension(100,20));
		setBackground(Color.yellow);
		
		
		menuButton= new JButton(new ImageIcon(constants.MENU_BUTTON_IMAGE));
		zoomButton= new JButton(new ImageIcon(constants.ZOOM_BUTTON_IMAGE));
		historyButton= new JButton(new ImageIcon(constants.HISTORY_BUTTON_IMAGE));
	
		
		//menuButton.setBorderPainted(false);
		menuButton.setFocusPainted(false);
		menuButton.setContentAreaFilled(false);
		
		//historyButton.setBorderPainted(false);
		historyButton.setFocusPainted(false);
		historyButton.setContentAreaFilled(false);
		
		//zoomButton.setBorderPainted(false);
		zoomButton.setFocusPainted(false);
		zoomButton.setContentAreaFilled(false);
		
		
		box = Box.createHorizontalBox();
		box.add(menuButton);
		box.add(zoomButton);
		box.add(Box.createHorizontalStrut(300));
		box.add(historyButton);
		add(box);
		
		
		

		
	}
}
