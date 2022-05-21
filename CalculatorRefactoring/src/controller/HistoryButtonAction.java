package controller;

import java.awt.BorderLayout;
import java.awt.GridBagConstraints;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import view.ButtonPanel;
import view.CenterPanel;
import view.HistoryPanel;

public class HistoryButtonAction implements ActionListener{
	private HistoryPanel historyPanel;
	private CenterPanel centerPanel;
	public HistoryButtonAction(CenterPanel centerPanel) {
		this.centerPanel = centerPanel;
	}
	@Override
	public void actionPerformed(ActionEvent e) {
		historyPanel =new HistoryPanel();
		centerPanel.buttonPanel.setVisible(false);
		
		
		GridBagConstraints grdBagConstraints =new GridBagConstraints();
		grdBagConstraints.fill = GridBagConstraints.BOTH;
		grdBagConstraints.weightx = 1;
		grdBagConstraints.weighty = 0.5;
		grdBagConstraints.gridx = 0;
		grdBagConstraints.gridy = 1;
		
		centerPanel.add(historyPanel.scroll,grdBagConstraints);
		
	
		CalculatorStart.mainFrame.revalidate();
		CalculatorStart.mainFrame.repaint();
	}
	
	
	
	

}
