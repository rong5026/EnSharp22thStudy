package view;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.GridLayout;

import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.SwingConstants;

import controller.CalculatorStart;
import controller.ComponentAction;

public class TextPanel extends JPanel{

	public static JLabel inputJLabel;
	public static JLabel previousJLabel;
	
	private ComponentAction componentAction;
	
	public TextPanel() {
	
	
		setLayout(new GridBagLayout()); // 상하 3개로 나누기
		GridBagConstraints grdBagConstraints =new GridBagConstraints();
		grdBagConstraints.fill = GridBagConstraints.BOTH;
		
		setBackground(new Color(220,220,220));
	
		
		
		previousJLabel = new JLabel("");
		inputJLabel = new JLabel("0");
		
		//입력과거 정보
		previousJLabel.setFont(new Font("맑은 고딕", 0, 15 ));
		previousJLabel.setForeground(new Color(64,64,64));
		previousJLabel.setHorizontalAlignment(SwingConstants.RIGHT);
		
		//입력 값
		inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55));
		inputJLabel.setForeground(Color.BLACK);
		inputJLabel.setHorizontalAlignment(SwingConstants.RIGHT);
		inputJLabel.setPreferredSize(new Dimension(CalculatorStart.mainFrame.getWidth(),50));
		
		grdBagConstraints.weightx = 1;
		grdBagConstraints.weighty = 0.1;
		grdBagConstraints.gridx = 0;
		grdBagConstraints.gridy = 0;
		add(previousJLabel,grdBagConstraints);
		
		grdBagConstraints.weightx = 1;
		grdBagConstraints.weighty = 0.3;
		grdBagConstraints.gridx = 0;
		grdBagConstraints.gridy = 1;
		add(inputJLabel,grdBagConstraints);
		
		
		//componentAction = new ComponentAction(inputJLabel);
		
		
	}
	
	
	
	
}

