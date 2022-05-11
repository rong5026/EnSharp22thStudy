package View;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;

import javax.swing.Box;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JPanel;
import Model.constants;

public class menuPanel extends JPanel{

	private Dimension dimension ;
	private JButton historyButton;
	private JButton menuButton;
	private JButton zoomButton;
	private Box box;
	
	public menuPanel() {
		
	
		dimension = new Dimension(20,50);
		setLayout(new FlowLayout());
		setPreferredSize(new Dimension(100,45));
		setBackground(Color.blue);
		

		menuButton= new JButton(new ImageIcon(constants.MENU_BUTTON_IMAGE));
		historyButton= new JButton(new ImageIcon(constants.HISTORY_BUTTON_IMAGE));
		zoomButton= new JButton(new ImageIcon(constants.ZOOM_BUTTON_IMAGE));
		
		
		box = Box.createHorizontalBox();
		box.add(menuButton);
		box.add(zoomButton);
		box.add(Box.createHorizontalStrut(270));
		box.add(historyButton);
		add(box);
		
		
		
		
		//add(menuButton);
		//add(zoomButton);
		//add(historyButton);
		
	}
}
