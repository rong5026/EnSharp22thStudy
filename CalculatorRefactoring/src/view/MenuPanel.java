package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Font;
import java.util.ArrayList;

import javax.swing.Box;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;

import Utility.ConstantNumber;
import controller.CalculatorStart;
import controller.ComponentAction;
import controller.HistoryButtonAction;
import controller.MouseAction;
import model.ResultDTO;




public class MenuPanel {

	public JPanel menuPanel;
	private JButton historyButton;
	private JButton menuButton;
	private JButton zoomButton;
	private JLabel information;
	private Box box;
	private HistoryButtonAction historyButtonAction;
	
	public MenuPanel(CenterPanel centerPanel ,ArrayList<ResultDTO> resultList,JFrame mainFrame,CalculatorStart calculatorStart) {
		
		menuPanel = new JPanel();
	
		menuPanel.setLayout(new BorderLayout());
		menuPanel.setPreferredSize(new Dimension(0,40));
		menuPanel.setBackground(new Color(220,220,220));
		
		
		menuButton= new JButton(new ImageIcon(ConstantNumber.MENU_BUTTON_IMAGE));
		zoomButton= new JButton(new ImageIcon(ConstantNumber.ZOOM_BUTTON_IMAGE));
		historyButton= new JButton(new ImageIcon(ConstantNumber.HISTORY_BUTTON_IMAGE));
		information = new JLabel("표준");
		
		//버튼 배경색 설정
		menuButton.setBackground(menuPanel.getBackground());
		zoomButton.setBackground(menuPanel.getBackground());
		historyButton.setBackground(menuPanel.getBackground());
		
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
		menuPanel.add(box,BorderLayout.WEST);
		
		menuPanel.add(historyButton,BorderLayout.EAST);
	
		// 버튼에 마우스 리스너달기
		menuButton.addMouseListener(new MouseAction());
		zoomButton.addMouseListener(new MouseAction());
		historyButton.addMouseListener(new MouseAction());
		
		historyButtonAction = new HistoryButtonAction(centerPanel,resultList,calculatorStart);
		historyButton.addActionListener(historyButtonAction);
		
		new ComponentAction(centerPanel,resultList,calculatorStart,mainFrame,historyButtonAction);
		
		
		
		
		
		

		
	}
}
