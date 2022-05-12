package view;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.GridLayout;

import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.SwingConstants;

import controller.CalculatorStart;

public class TextPanel extends JPanel{

	public static JLabel inputJLabel;
	public static JLabel previousJLabel;
	
	
	public TextPanel() {
	
		//setBackground(Color.gray);
		setLayout(new GridLayout(3,1)); // 상하 3개로 나누기
		setPreferredSize(new Dimension(500,180));
		setBackground(new Color(220,220,220));
		
		
		previousJLabel = new JLabel("");
		inputJLabel = new JLabel("0");
		
		
		//입력과거 정보
		previousJLabel.setFont(new Font("맑은 고딕", 0, 30));
		previousJLabel.setForeground(new Color(64,64,64));
		previousJLabel.setHorizontalAlignment(SwingConstants.RIGHT);
		
		
		//입력 값
		inputJLabel.setFont(new Font("맑은 고딕", Font.BOLD , 55));
		inputJLabel.setForeground(Color.BLACK);
		inputJLabel.setHorizontalAlignment(SwingConstants.RIGHT);
		
		
		/*
		// 나중에 삭제할것
		informationJLabel.setOpaque(true);
		informationJLabel.setBackground(Color.green);
		
		inputJLabel.setOpaque(true);
		inputJLabel.setBackground(Color.CYAN);
		//
		 */
		
		add(previousJLabel);
		add(inputJLabel);
	}
	
	
	
	
}

