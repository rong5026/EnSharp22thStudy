package View;

import java.awt.Color;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.FlowLayout;

import javax.swing.Box;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JPanel;

public class textPanel extends JPanel{
	private Dimension dimension ;
	private JButton historyButton;
	private JButton menuButton;
	private JButton zoomButton;
	private Box box;
	
	public textPanel() {
		
	
		dimension = new Dimension(20,50);
		setLayout(new FlowLayout());
		setPreferredSize(new Dimension(100,45));
		setBackground(Color.blue);
		
		//버튼생성
		menuButton= new JButton(new ImageIcon("src/Image/menu.png"));
		historyButton= new JButton(new ImageIcon("src/Image/history.png"));
		zoomButton= new JButton(new ImageIcon("src/Image/zoom.png"));
		
		
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
