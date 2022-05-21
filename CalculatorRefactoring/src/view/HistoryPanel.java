package view;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.GridBagLayout;
import java.awt.GridLayout;
import java.util.ArrayList;

import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.JScrollBar;
import javax.swing.JScrollPane;
import javax.swing.ScrollPaneConstants;

import controller.MouseAction;
import model.ResultDTO;

public class HistoryPanel {

	public JScrollPane scroll;
	JPanel historyJPanel;
	
	public  HistoryPanel(ArrayList<ResultDTO> resultList) {
		
		

		
		historyJPanel = new JPanel();
		historyJPanel.setLayout(new GridLayout(resultList.size(),1)); // 세로로
		
		
		for(int index = 0; index<resultList.size() ; index++) {
			String buttonString = resultList.get(index).getFormula() + resultList.get(index).getResult();
			JButton button = new JButton(buttonString );
			button.setPreferredSize(new Dimension(0,100));
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
