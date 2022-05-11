package view;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.GridLayout;

import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.SwingConstants;

public class TextPanel extends JPanel{

	private JLabel inputJLabel;
	private JLabel informationJLabel;
	private String result;
	public TextPanel() {
		result ="0";
		//setBackground(Color.gray);
		setLayout(new GridLayout(3,1)); // 상하 3개로 나누기
		setPreferredSize(new Dimension(500,180));
		
		informationJLabel = new JLabel("");
		inputJLabel = new JLabel(result);
		
		
		//입력 정보
		informationJLabel.setFont(new Font("���� ���", 0, 40));
		informationJLabel.setForeground(Color.BLACK);
		informationJLabel.setHorizontalAlignment(SwingConstants.RIGHT);
		
		
		//입력 값
		inputJLabel.setFont(new Font("���� ���", Font.BOLD , 55));
		inputJLabel.setForeground(Color.BLACK);
		inputJLabel.setHorizontalAlignment(SwingConstants.RIGHT);
		
		
		// 나중에 삭제할것
		informationJLabel.setOpaque(true);
		informationJLabel.setBackground(Color.green);
		
		inputJLabel.setOpaque(true);
		inputJLabel.setBackground(Color.CYAN);
		//
		
		
		add(informationJLabel);
		add(inputJLabel);
		
		
	}
	
	
}

