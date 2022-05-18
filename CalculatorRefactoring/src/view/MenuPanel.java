package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Font;

import javax.swing.Box;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;

import constants.ConstantNumber;
import controller.CalculatorStart;
import controller.MouseAction;



public class MenuPanel extends JPanel{


	private JButton historyButton;
	private JButton menuButton;
	private JButton zoomButton;
	private JLabel information;
	private Box box;
	
	public MenuPanel() {
		
	
		setLayout(new BorderLayout());
		setPreferredSize(new Dimension(0,40));
		setBackground(new Color(220,220,220));
		
		
		menuButton= new JButton(new ImageIcon(ConstantNumber.MENU_BUTTON_IMAGE));
		zoomButton= new JButton(new ImageIcon(ConstantNumber.ZOOM_BUTTON_IMAGE));
		historyButton= new JButton(new ImageIcon(ConstantNumber.HISTORY_BUTTON_IMAGE));
		information = new JLabel("표준");
		
		//버튼 배경색 설정
		menuButton.setBackground(getBackground());
		zoomButton.setBackground(getBackground());
		historyButton.setBackground(getBackground());
		
		menuButton.setBorderPainted(false);
		menuButton.setFocusPainted(false);
		historyButton.setBorderPainted(false);
		historyButton.setFocusPainted(false);
		zoomButton.setBorderPainted(false);
		zoomButton.setFocusPainted(false);
		
		// 라벨 폰트설정
		information.setFont(new Font("맑은 고딕", Font.BOLD, 20));
		
		box = Box.createHorizontalBox();
		box.add(menuButton);
		box.add(information);
		box.add(zoomButton);
		add(box,BorderLayout.WEST);
		
		add(historyButton,BorderLayout.EAST);
		//historyButton.setBounds(CalculatorStart.mainFrame.getWidth()-40, getHeight(), 100, 40);
		
		System.out.println(getWidth());
		// 버튼에 마우스 리스너달기
		menuButton.addMouseListener(new MouseAction());
		zoomButton.addMouseListener(new MouseAction());
		historyButton.addMouseListener(new MouseAction());
		
		
		
		
		
		
		

		
	}
}
