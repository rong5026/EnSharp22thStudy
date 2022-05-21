package controller;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.GridBagConstraints;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

import javax.swing.JPanel;import model.ResultDTO;
import view.ButtonPanel;
import view.CenterPanel;
import view.HistoryPanel;

public class HistoryButtonAction implements ActionListener{
	private HistoryPanel historyPanel;
	private CenterPanel centerPanel;
	private ArrayList<ResultDTO> resultList;
	public HistoryButtonAction(CenterPanel centerPanel,JPanel menupanel,ArrayList<ResultDTO> resultList) {
		this.centerPanel = centerPanel;
		this.resultList =resultList;
	}
	@Override
	public void actionPerformed(ActionEvent e) {
		historyPanel =new HistoryPanel(resultList);
		
		
		centerPanel.buttonPanel.setVisible(false);
		
		GridBagConstraints grdBagConstraints =new GridBagConstraints();
		grdBagConstraints.fill = GridBagConstraints.BOTH;
		grdBagConstraints.weightx = 1;
		grdBagConstraints.weighty = 0.3;
		grdBagConstraints.gridx = 0;
		grdBagConstraints.gridy = 1;
		centerPanel.add(historyPanel.scroll,grdBagConstraints);
		
		//centerPanel.textPanel.setBackground(Color.red);
		
		CalculatorStart.mainFrame.revalidate();
		CalculatorStart.mainFrame.repaint();
	}
	
	
	
	

}
