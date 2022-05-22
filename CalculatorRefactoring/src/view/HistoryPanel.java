package view;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.GridBagLayout;
import java.awt.GridLayout;
import java.util.ArrayList;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollBar;
import javax.swing.JScrollPane;
import javax.swing.ScrollPaneConstants;
import javax.swing.SwingConstants;

import controller.MouseAction;
import model.ResultDTO;

public class HistoryPanel {

	public JScrollPane scroll;
	JPanel historyJPanel;
	
	public  HistoryPanel(ArrayList<ResultDTO> resultList) {
		
		

		
		historyJPanel = new JPanel();
		historyJPanel.setLayout(new GridLayout(resultList.size(),1)); // 세로로
		
		
		/*
		for(int index = 0; index<resultList.size() ; index++) {
			String top = resultList.get(index).getFormula();
			String bottom = resultList.get(index).getResult();
			JPanel panel = new JPanel();
			panel.setLayout(new GridLayout(2,1));
			panel.setPreferredSize(new Dimension(0,120));
			JLabel topJLabel = new JLabel(top);
			JLabel bottomJLabel = new JLabel(bottom);
			panel.add(topJLabel);
			panel.add(bottomJLabel);
			
			historyJPanel.add(panel);
			
			
			
			
		}
		*/
		
		
		for(int index = 0; index<resultList.size() ; index++) {
			String buttonString = resultList.get(index).getFormula() +"<html><br></html>"+ resultList.get(index).getResult();
			JButton button = new JButton( );
			button.setText("<html>" + resultList.get(index).getFormula() +"<br>" +resultList.get(index).getResult() + "</html>"  );
			button.setHorizontalAlignment(SwingConstants.RIGHT);
			
			button.setPreferredSize(new Dimension(0,120));
			button.setBorder(null);
			button.setBackground(new Color(232,232,232));		
			historyJPanel.add(button);
			button.addMouseListener(new MouseAction());
			
		}
		
		scroll = new JScrollPane(historyJPanel,JScrollPane.VERTICAL_SCROLLBAR_ALWAYS,JScrollPane.HORIZONTAL_SCROLLBAR_NEVER);
		scroll.setPreferredSize(new Dimension(0,400));
		scroll.setBackground(new Color(255,250,250));
		
	}
	
		
}
