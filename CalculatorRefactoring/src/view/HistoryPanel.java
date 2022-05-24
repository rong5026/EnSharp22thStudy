package view;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.GridBagLayout;
import java.awt.GridLayout;
import java.util.ArrayList;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollBar;
import javax.swing.JScrollPane;
import javax.swing.ScrollPaneConstants;
import javax.swing.SwingConstants;

import controller.MouseAction;
import model.ResultDTO;

public class HistoryPanel {

	public JScrollPane scroll;
	private JPanel historyJPanel;
	private JButton button;
	private String topString;
	private String bottomString;
	public  HistoryPanel(ArrayList<ResultDTO> resultList) {
		
		

		
		historyJPanel = new JPanel();
		historyJPanel.setLayout(new GridLayout(resultList.size(),1)); // 세로로
		
		
		if(resultList.size() ==0) {
			
			button = createButton("아직 기록이 없음");
			
			historyJPanel.add(button);
		}
		
		
		for(int index = 0; index<resultList.size() ; index++) {
			topString = resultList.get(index).getFormula() ;
			bottomString =  resultList.get(index).getResult();

			button = createButton("<html><body style='text-align:right;'>" + topString+"<br>" +bottomString + "</body></html>" );
			button.setHorizontalAlignment(SwingConstants.RIGHT);
	
			historyJPanel.add(button);
			button.addMouseListener(new MouseAction());
			
		}
		
	
		
		scroll = new JScrollPane(historyJPanel,JScrollPane.VERTICAL_SCROLLBAR_ALWAYS,JScrollPane.HORIZONTAL_SCROLLBAR_NEVER);
		scroll.setPreferredSize(new Dimension(300,500));
		scroll.setBackground(new Color(255,250,250));
		
		
	}
	
	private JButton createButton(String buttonText) {
		button = new JButton();
		button.setText(buttonText);
		
		
		button.setFont(new Font("맑은 고딕", Font.BOLD , 24));
		button.setPreferredSize(new Dimension(0,120));
		button.setBorder(null);
		button.setBackground(new Color(232,232,232));		
		
		return button;
	}
		
}
