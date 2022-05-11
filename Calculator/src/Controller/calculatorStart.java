package Controller;

import java.awt.BorderLayout;
import java.awt.Container;

import javax.swing.JFrame;
import View.textPanel;
import View.buttonPanel;
import View.menuPanel;


public class calculatorStart extends JFrame{

	
	public calculatorStart() {
		
		this.setLayout(new BorderLayout());
		setLocationRelativeTo(null);
		setTitle("EN# °è»ê±â");
		setResizable(false);
		setSize(500,700);
	}
	
	public void start() {
		
		Container container = getContentPane();
		container.add(new textPanel());
		
		setVisible(true);
	}
	
}
