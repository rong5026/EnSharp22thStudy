package controller;

import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.util.ArrayList;

import javax.swing.Box;
import javax.swing.BoxLayout;
import javax.swing.ImageIcon;
import javax.swing.JFrame;

import Utility.ConstantNumber;
import model.ResultDTO;
import view.CenterPanel;
import view.MenuPanel;



public class CalculatorStart {
	private ImageIcon calculatorIcon;
	private Container container;
	private ImageIcon img;
	private ArithmeticSign arithmeticSign;
	private CenterPanel centerPanel;
	private MenuPanel menuPanel;
	private ArrayList<ResultDTO> resultList;
	public static String inputNumber; //현재 입력중인 값
	public static String previousNumber; //이전에 입력중인 값
	public static JFrame mainFrame;
	
	public static int errorType;
	

	
	
	public CalculatorStart() {
		
		inputNumber="";
		previousNumber=""; 
		errorType= ConstantNumber.NON_ERROR;
		mainFrame = new JFrame();
		resultList = new ArrayList<ResultDTO>();
		arithmeticSign = new ArithmeticSign(resultList);
		centerPanel = new CenterPanel(arithmeticSign,resultList);
		menuPanel = new MenuPanel(centerPanel,resultList );
	
		img = new ImageIcon(ConstantNumber.CALCULATOR_ICON_IMAGE);
		mainFrame.setIconImage(img.getImage());
		
		mainFrame.setLayout(new BorderLayout());
		mainFrame.setLocationRelativeTo(null);
		mainFrame.setTitle("EN# 계산기");
		mainFrame.setSize(450,600);
		mainFrame.setMinimumSize(new Dimension(330, 530));
	}
	
	public void start() {

		
		mainFrame.add(menuPanel.menuPanel,BorderLayout.NORTH);
		mainFrame.add(centerPanel,BorderLayout.CENTER);
		// 키보드값 입력 엑션달기
		
		mainFrame.addKeyListener(new KeyboardButtonAction(arithmeticSign,resultList));
		mainFrame.setFocusable(true);
		mainFrame.requestFocus();
		
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		mainFrame.setVisible(true);
	}
	
}
