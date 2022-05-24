package controller;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Container;
import java.awt.GridBagConstraints;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

import javax.swing.JPanel;

import Utility.ConstantNumber;
import model.ResultDTO;
import view.ButtonPanel;
import view.CenterPanel;
import view.HistoryPanel;

public class HistoryButtonAction implements ActionListener{
	public HistoryPanel historyPanel;
	private CenterPanel centerPanel;
	private ArrayList<ResultDTO> resultList;
	private JPanel buttonPanel;
	private CalculatorStart calculatorStart;
	public boolean ishistoryOn;
	public HistoryButtonAction(CenterPanel centerPanel,ArrayList<ResultDTO> resultList,CalculatorStart calculatorStart) {
		this.centerPanel = centerPanel;
		this.resultList =resultList;
		this.calculatorStart = calculatorStart;
	
		ishistoryOn = calculatorStart.ishistoryOn;
	
	}
	
	@Override
	public void actionPerformed(ActionEvent e) {
		
		
		
		if(ishistoryOn ==ConstantNumber.isHISTORY_OFF && calculatorStart.mainFrame.getWidth()<550) {
		
			historyPanel =new HistoryPanel(resultList);
			
			
			centerPanel.buttonPanel.setVisible(false);
			
			GridBagConstraints grdBagConstraints =new GridBagConstraints();
			grdBagConstraints.fill = GridBagConstraints.BOTH;
			grdBagConstraints.weightx = 1;
			grdBagConstraints.weighty = 0.3;
			grdBagConstraints.gridx = 0;
			grdBagConstraints.gridy = 1;
			centerPanel.add(historyPanel.scroll,grdBagConstraints);
			ishistoryOn = ConstantNumber.isHISTORY_ON;
			
		}
		else if(ishistoryOn ==ConstantNumber.isHISTORY_ON&& calculatorStart.mainFrame.getWidth()<550){
			
			historyPanel.scroll.setVisible(false);
			centerPanel.buttonPanel.setVisible(true);
			ishistoryOn = ConstantNumber.isHISTORY_OFF;
		}
		
		

		CalculatorStart.mainFrame.revalidate();
		CalculatorStart.mainFrame.repaint();
	
		

	}
	
	
	

}
