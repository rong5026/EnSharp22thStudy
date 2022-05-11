package Controller;

import java.awt.BorderLayout;
import java.awt.Container;

import javax.swing.ImageIcon;
import javax.swing.JFrame;

import Model.constants;
import View.textPanel;
import View.buttonPanel;
import View.menuPanel;


public class calculatorStart extends JFrame{
	private ImageIcon calculatorIcon;
	
	public calculatorStart() {
		ImageIcon img = new ImageIcon(constants.CALCULATOR_ICON_IMAGE);
		this.setIconImage(img.getImage());
		
		this.setLayout(new BorderLayout());
		setLocationRelativeTo(null);
		setTitle("EN# °è»ê±â");
		setResizable(false);
		setSize(500,700);
	}
	
	public void start() {
		
		Container container = getContentPane();
		
		container.add(new menuPanel(),BorderLayout.NORTH);
		
		
		setVisible(true);
	}
	
}
