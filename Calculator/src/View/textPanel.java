package View;

import java.awt.Color;
import java.awt.GridLayout;

import javax.swing.JLabel;
import javax.swing.JPanel;

public class textPanel extends JPanel{

	JLabel inputJLabel;
	JLabel informationJLabel;
	String result;
	public textPanel() {
		result ="0";
		setBackground(Color.gray);
		setLayout(new GridLayout(3,1)); // 상하 3개로 나누기
		
		
		informationJLabel = new JLabel("");
		inputJLabel = new JLabel(result);
		
		
		
		
		
		
	}
	
	
}

