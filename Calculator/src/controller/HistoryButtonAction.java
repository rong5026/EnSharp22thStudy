package controller;

import java.awt.BorderLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import view.ButtonPanel;
import view.HistoryPanel;

public class HistoryButtonAction implements ActionListener{

	@Override
	public void actionPerformed(ActionEvent e) {
		
		CalculatorStart.buttonPanel.setVisible(false);
		CalculatorStart.mainFrame.add(new HistoryPanel(),BorderLayout.SOUTH);
		
	
		CalculatorStart.mainFrame.revalidate();
		CalculatorStart.mainFrame.repaint();
	}
	
	
	
	

}
