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


public class CalculatorStart {
	private ImageIcon calculatorIcon;
	private Container container;
	private ImageIcon img;
	
	public static String inputNumber=""; //현재 입력중인 값
	public static String previousNumber=""; //이전에 입력중인 값
	public static JFrame minaFrame;
	
	public CalculatorStart() {
		
		minaFrame = new JFrame();
		img = new ImageIcon(Constants.CALCULATOR_ICON_IMAGE);
		minaFrame.setIconImage(img.getImage());
		
		minaFrame.setLayout(new BorderLayout());
		minaFrame.setLocationRelativeTo(null);
		minaFrame.setTitle("EN# 계산기");
		minaFrame.setResizable(false);
		minaFrame.setSize(450,700);
	}
	
	public void start() {
		
		
		minaFrame.add(new MenuPanel(),BorderLayout.NORTH);
		minaFrame.add(new TextPanel(),BorderLayout.CENTER);
		minaFrame.add(new ButtonPanel(),BorderLayout.SOUTH);
		
		// 키보드값 입력 엑션달기
		minaFrame.addKeyListener(new KeyboardButtonAction());
		minaFrame.setFocusable(true);
		minaFrame.requestFocus();
		
		minaFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		minaFrame.setVisible(true);
	}
	
}
