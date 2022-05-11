package view;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.GridLayout;

import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.SwingConstants;

public class TextPanel extends JPanel{

	JLabel inputJLabel;
	JLabel informationJLabel;
	String result;
	public TextPanel() {
		result ="0";
		setBackground(Color.gray);
		setLayout(new GridLayout(3,1)); // ���� 3���� ������
		setPreferredSize(new Dimension(100,80));
		
		informationJLabel = new JLabel("");
		inputJLabel = new JLabel(result);
		
		//�Է� ����
		informationJLabel.setFont(new Font("���� ���", 0, 40));
		informationJLabel.setForeground(Color.BLACK);
		informationJLabel.setHorizontalAlignment(SwingConstants.RIGHT);
		
		//�Է� ��
		inputJLabel.setFont(new Font("���� ���", Font.BOLD , 55));
		inputJLabel.setForeground(Color.BLACK);
		inputJLabel.setHorizontalAlignment(SwingConstants.RIGHT);
		
		
		add(informationJLabel);
		add(inputJLabel);
		
		
	}
	
	
}

