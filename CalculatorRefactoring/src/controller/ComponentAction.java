package controller;

import java.awt.BorderLayout;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;
import java.util.ArrayList;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.border.Border;

import Utility.ConstantNumber;
import model.ResultDTO;
import view.CenterPanel;
import view.HistoryPanel;

public class ComponentAction {

	private boolean isBigSize;
	public ComponentAction(CenterPanel centerPanel,ArrayList<ResultDTO> resultList,CalculatorStart calculatorStart,JFrame mainFrame,HistoryButtonAction historyButtonAction) {
	
		isBigSize =false;
	
		mainFrame.addComponentListener(new ComponentAdapter() {
			
			@Override
			public void componentResized(ComponentEvent e) {
				
				
				if(mainFrame.getWidth() > 550 && isBigSize ==false) {
					
					// 로그페이지 없애고
					if(historyButtonAction.ishistoryOn ==ConstantNumber.isHISTORY_ON) {
						mainFrame.remove(historyButtonAction.historyPanel.scroll);
						historyButtonAction.historyPanel.scroll.setVisible(false);
						centerPanel.buttonPanel.setVisible(true);
					}
					
					historyButtonAction.historyPanel =new HistoryPanel(resultList);
					mainFrame.add(historyButtonAction.historyPanel.scroll,BorderLayout.EAST);
					historyButtonAction.historyPanel.scroll.setVisible(true);
					mainFrame.setVisible(true);
					
					isBigSize = true;
					
				}
				else if(mainFrame.getWidth() <= 550 &&isBigSize ==true ) {
					
					mainFrame.remove(historyButtonAction.historyPanel.scroll);
					
					if(historyButtonAction.ishistoryOn ==ConstantNumber.isHISTORY_ON) {
						
						
						historyButtonAction.historyPanel =new HistoryPanel(resultList);
						centerPanel.buttonPanel.setVisible(false);
						GridBagConstraints grdBagConstraints =new GridBagConstraints();
						grdBagConstraints.fill = GridBagConstraints.BOTH;
						grdBagConstraints.weightx = 1;
						grdBagConstraints.weighty = 0.3;
						grdBagConstraints.gridx = 0;
						grdBagConstraints.gridy = 1;
						centerPanel.add(historyButtonAction.historyPanel.scroll,grdBagConstraints);
								
					}
					else {
						historyButtonAction.historyPanel.scroll.setVisible(false);
					}
					
					isBigSize = false;
						
				}
				CalculatorStart.mainFrame.repaint();
				mainFrame.revalidate();
				
			}
			
		});
		
	}
	
	

	

}
