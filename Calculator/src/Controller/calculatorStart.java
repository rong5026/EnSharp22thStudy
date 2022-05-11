package Controller;

import java.awt.BorderLayout;
import java.awt.Container;

import javax.swing.ImageIcon;
import javax.swing.JFrame;
import View.textPanel;
import View.buttonPanel;
import View.menuPanel;


public class calculatorStart extends JFrame{

	
	public calculatorStart() {
		ImageIcon img = new ImageIcon("이미지경로");
		this.setIconImage(img.getImage());
	
		this.setLayout(new BorderLayout());
		setLocationRelativeTo(null);
		setTitle("EN# 계산기");
		setResizable(false);
		setSize(500,700);
	}
	
	public void start() {
		
		Container container = getContentPane();
		
		container.add(new menuPanel(),BorderLayout.NORTH);
		
		
		setVisible(true);
	}
	
}
