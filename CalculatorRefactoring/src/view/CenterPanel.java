package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;

import javax.swing.JPanel;

import controller.ArithmeticSign;

public class CenterPanel extends JPanel{

	public ButtonPanel buttonPanel;
	
	public CenterPanel(ArithmeticSign arithmeticSign) {
		
		setBackground(new Color(220,220,220));
		setLayout(new GridBagLayout());
		GridBagConstraints grdBagConstraints =new GridBagConstraints();
		grdBagConstraints.fill = GridBagConstraints.BOTH;
		grdBagConstraints.weightx = 1;
		grdBagConstraints.weighty = 0.1;
		grdBagConstraints.gridx = 0;
		grdBagConstraints.gridy = 0;
		add(new TextPanel(),grdBagConstraints);
		
		grdBagConstraints.weightx = 1;
		grdBagConstraints.weighty = 0.5;
		grdBagConstraints.gridx = 0;
		grdBagConstraints.gridy = 1;
		
		buttonPanel = new ButtonPanel(arithmeticSign);
		add( buttonPanel,grdBagConstraints);
		
	
		
	
		
	}
}
