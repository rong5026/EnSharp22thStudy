package view;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.GridBagLayout;
import java.awt.GridLayout;

import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.JScrollBar;
import javax.swing.JScrollPane;
import javax.swing.ScrollPaneConstants;

public class HistoryPanel {

	public JScrollPane scroll;
	JPanel historyJPanel;
	
	public  HistoryPanel() {
		
		
		scroll = new JScrollPane(JScrollPane.VERTICAL_SCROLLBAR_ALWAYS,JScrollPane.HORIZONTAL_SCROLLBAR_NEVER);
		scroll.setPreferredSize(new Dimension(0,400));
		scroll.setBackground(new Color(255,250,250));
		
		historyJPanel = new JPanel();
		historyJPanel.setLayout(new GridLayout(5,1)); // 상하 3개로 나누기);
		
			
		
		for(int i = 0; i<5 ; i++) {
			JButton button = new JButton("i"+i);
			
			historyJPanel.add(button);
		}
		
		scroll.add(historyJPanel);
	}
	
		
}
