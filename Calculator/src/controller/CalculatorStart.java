package controller;

import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.FlowLayout;
import java.awt.GridLayout;

import javax.swing.Box;
import javax.swing.BoxLayout;
import javax.swing.ImageIcon;
import javax.swing.JFrame;

import model.Constants;
import view.ButtonPanel;
import view.MenuPanel;
import view.TextPanel;


public class CalculatorStart extends JFrame{
	private ImageIcon calculatorIcon;
	private Container container;
	private ImageIcon img;
	
	public static String resultString;
	public CalculatorStart() {
		
		img = new ImageIcon(Constants.CALCULATOR_ICON_IMAGE);
		this.setIconImage(img.getImage());
		
		this.setLayout(new BorderLayout());
		setLocationRelativeTo(null);
		setTitle("EN# 계산기");
		setResizable(false);
		setSize(500,700);
	}
	
	public void start() {
		
		container = getContentPane();
		
		container.add(new MenuPanel(),BorderLayout.NORTH);
		container.add(new TextPanel(),BorderLayout.CENTER);
		container.add(new ButtonPanel(),BorderLayout.SOUTH);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
	}
	
}
