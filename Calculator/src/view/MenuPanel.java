package view;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;

import javax.swing.Box;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JPanel;

import controller.MouseClick;
import model.Constants;

public class MenuPanel extends JPanel{


	private JButton historyButton;
	private JButton menuButton;
	private JButton zoomButton;
	private Box box;
	
	public MenuPanel() {
		
	
		setLayout(new FlowLayout(FlowLayout.LEFT));
		setPreferredSize(new Dimension(0,50));
		setBackground(new Color(220,220,220));
		
		
		menuButton= new JButton(new ImageIcon(Constants.MENU_BUTTON_IMAGE));
		zoomButton= new JButton(new ImageIcon(Constants.ZOOM_BUTTON_IMAGE));
		historyButton= new JButton(new ImageIcon(Constants.HISTORY_BUTTON_IMAGE));
		
		//버튼 배경색 설정
		menuButton.setBackground(getBackground());
		zoomButton.setBackground(getBackground());
		historyButton.setBackground(getBackground());
		
		menuButton.setBorderPainted(false);
		//menuButton.setFocusPainted(false);
		//menuButton.setContentAreaFilled(false);
		
		historyButton.setBorderPainted(false);
		//historyButton.setFocusPainted(false);
		//historyButton.setContentAreaFilled(false);
		
		zoomButton.setBorderPainted(false);
		//zoomButton.setFocusPainted(false);
		//zoomButton.setContentAreaFilled(false);
		
		
		box = Box.createHorizontalBox();
		box.add(menuButton);
		box.add(zoomButton);
		box.add(Box.createHorizontalStrut(300));
		box.add(historyButton);
		
		// 버튼에 리스너달기
		menuButton.addMouseListener(new MouseClick());
		zoomButton.addMouseListener(new MouseClick());
		historyButton.addMouseListener(new MouseClick());
		add(box);
		
		
		

		
	}
}
