package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.util.ArrayList;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.LayoutFocusTraversalPolicy;

import controller.ArithmeticSign;
import model.ResultDTO;

public class CenterPanel extends JPanel{

	public ButtonPanel buttonPanel;
	public TextPanel textPanel;
	
	public CenterPanel(ArithmeticSign arithmeticSign,ArrayList<ResultDTO> resultList, JLabel inputJLabel, JLabel previousJLabel) {
		
		setBackground(new Color(220,220,220));
		setLayout(new GridBagLayout());
		GridBagConstraints grdBagConstraints =new GridBagConstraints();
		grdBagConstraints.fill = GridBagConstraints.BOTH;
		grdBagConstraints.weightx = 1;
		grdBagConstraints.weighty = 0.1;
		grdBagConstraints.gridx = 0;
		grdBagConstraints.gridy = 0;
		textPanel = new TextPanel(inputJLabel,previousJLabel);
		add(textPanel,grdBagConstraints);
		
		grdBagConstraints.weightx = 1;
		grdBagConstraints.weighty = 0.5;
		grdBagConstraints.gridx = 0;
		grdBagConstraints.gridy = 1;
		
		buttonPanel = new ButtonPanel(arithmeticSign,resultList,inputJLabel,previousJLabel);
		add( buttonPanel,grdBagConstraints);
		
		

		
		
	
		
	
		
	}
}
