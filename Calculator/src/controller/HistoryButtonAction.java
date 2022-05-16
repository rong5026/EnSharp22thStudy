package controller;

import java.awt.BorderLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import view.ButtonPanel;
import view.HistoryPanel;

public class HistoryButtonAction implements ActionListener{
	HistoryPanel historyPanel;
	@Override
	public void actionPerformed(ActionEvent e) {
		historyPanel =new HistoryPanel();
		CalculatorStart.buttonPanel.setVisible(false);
		CalculatorStart.mainFrame.add(historyPanel.scroll,BorderLayout.SOUTH);
		
	
		CalculatorStart.mainFrame.revalidate();
		CalculatorStart.mainFrame.repaint();
	}
	
	
	
	

}
