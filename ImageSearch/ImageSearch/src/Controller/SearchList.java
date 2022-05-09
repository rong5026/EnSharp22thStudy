package Controller;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.event.*;
	



public class SearchList extends JFrame {


	public SearchList() {
		setSize(1000,800);
		setLocationRelativeTo(null);
		setTitle("EN# 이미지 서치");
		setResizable(false);
	
	}
	
	public void StartSearchList() {
		
		Container container = getContentPane();		
		container.setLayout(new BorderLayout());
		
		
		
		JPanel buttonPanel = new JPanel(new FlowLayout());
		
		TextField textField = new TextField(20);	
		JButton searchingButton = new JButton("검색하기");		
		JButton backButton = new JButton("뒤로가기");
		Choice countSelectionChoice = new Choice();
		countSelectionChoice.add("10");
		countSelectionChoice.add("20");
		countSelectionChoice.add("30");
		
		
		buttonPanel.add(textField);
		buttonPanel.add(searchingButton);
		buttonPanel.add(backButton);
		buttonPanel.add(countSelectionChoice);
		buttonPanel.setBounds(400,300,200,200);
		
		searchingButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				String dataString = textField.getText();
				System.out.println(dataString);
				
				setVisible(false);
				SearchList a = new SearchList();
				a.StartSearchList();
										
			}
		});
		container.add(buttonPanel);
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		
		
		
		
	}
	
	
	
}
