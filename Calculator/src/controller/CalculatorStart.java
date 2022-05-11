package controller;

import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.FlowLayout;
import java.awt.GridLayout;

import javax.swing.Box;
import javax.swing.ImageIcon;
import javax.swing.JFrame;

import model.Constants;
import view.ButtonPanel;
import view.MenuPanel;
import view.TextPanel;


public class CalculatorStart extends JFrame{
	private ImageIcon calculatorIcon;
	private Box box;
	
	public CalculatorStart() {
		//아이콘 설정
		ImageIcon img = new ImageIcon(Constants.CALCULATOR_ICON_IMAGE);
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
		
		container.add(new MenuPanel());
		container.add(new TextPanel());
		container.add(new ButtonPanel());
	
		setVisible(true);
	}
	
}
