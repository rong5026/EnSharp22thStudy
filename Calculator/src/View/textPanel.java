package View;

import java.awt.Container;
import java.awt.FlowLayout;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JPanel;

public class textPanel extends JPanel{

	
	public textPanel() {
		
		
		setLayout(new FlowLayout());
		
		JButton historyButton= new JButton(new ImageIcon("./Image/history.png"));
		JButton menuButton= new JButton(new ImageIcon("./Image/menu.png"));
		JButton zoomButton= new JButton(new ImageIcon("./Image/zoom.png"));
		
		
		
		add(menuButton);
		add(zoomButton);
		add(historyButton);
		
		
	
	}

	
}
