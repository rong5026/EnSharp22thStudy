package controller;

import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.FlowLayout;
import java.awt.GridLayout;

import javax.swing.Box;
import javax.swing.ImageIcon;
import javax.swing.JFrame;

import model.constants;
import view.buttonPanel;
import view.menuPanel;
import view.textPanel;


public class calculatorStart extends JFrame{
	private ImageIcon calculatorIcon;
	private Box box;
	
	public calculatorStart() {
		//아이콘 설정
		ImageIcon img = new ImageIcon(constants.CALCULATOR_ICON_IMAGE);
		this.setIconImage(img.getImage());
		
		this.setLayout(new GridLayout(3,1));
		//this.setLayout(new BorderLayout());
		setLocationRelativeTo(null);
		setTitle("EN# 계산기");
		setResizable(false);
		setSize(500,700);
	}
	
	public void start() {
		
		Container container = getContentPane();
		
		container.add(new menuPanel());
		container.add(new textPanel());
		container.add(new buttonPanel());
	
		setVisible(true);
	}
	
}
