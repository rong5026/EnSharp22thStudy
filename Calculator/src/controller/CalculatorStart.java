package controller;

import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.GridLayout;

import javax.swing.Box;
import javax.swing.BoxLayout;
import javax.swing.ImageIcon;
import javax.swing.JFrame;

import Constants.ConstantNumber;
import view.ButtonPanel;
import view.MenuPanel;
import view.TextPanel;


public class CalculatorStart {
	private ImageIcon calculatorIcon;
	private Container container;
	private ImageIcon img;
	
	public static String inputNumber=""; //현재 입력중인 값
	public static String previousNumber=""; //이전에 입력중인 값
	public static JFrame mainFrame;
	public static ButtonPanel buttonPanel;
	public static int errorNumber;
	
	public CalculatorStart() {
		buttonPanel = new ButtonPanel();
		mainFrame = new JFrame();
		img = new ImageIcon(ConstantNumber.CALCULATOR_ICON_IMAGE);
		mainFrame.setIconImage(img.getImage());
		
		mainFrame.setLayout(new BorderLayout());
		mainFrame.setLocationRelativeTo(null);
		mainFrame.setTitle("EN# 계산기");
	
		
		mainFrame.setSize(450,700);
		
		mainFrame.setMinimumSize(new Dimension(330, 530));
	}
	
	public void start() {
		
		
		mainFrame.add(new MenuPanel(),BorderLayout.NORTH);
		mainFrame.add(new TextPanel(),BorderLayout.CENTER);
		mainFrame.add(buttonPanel,BorderLayout.SOUTH);
		
		// 키보드값 입력 엑션달기
		mainFrame.addKeyListener(new KeyboardButtonAction());
		mainFrame.setFocusable(true);
		mainFrame.requestFocus();
		
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		mainFrame.setVisible(true);
	}
	
}
