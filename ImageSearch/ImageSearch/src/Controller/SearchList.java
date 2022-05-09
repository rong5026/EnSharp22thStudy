package Controller;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.event.*;
	



public class SearchList extends JFrame implements ActionListener{

	String count[] = {"10","20","30"};
	
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
		JComboBox<String> countCombobox = new JComboBox(count);

		
		buttonPanel.add(textField);
		buttonPanel.add(searchingButton);
		buttonPanel.add(backButton);
		buttonPanel.add(countCombobox);
		buttonPanel.setBounds(400,300,200,200);
		
		searchingButton.addActionListener(this);
		backButton.addActionListener(this);
		
		
		container.add(buttonPanel);
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		
		
		
	}
	


	@Override
	public void actionPerformed(ActionEvent e) {
		JButton button = (JButton)e.getSource();
		
		if(button.getText().equals("검색하기")) {
			
		}
		else {
			setVisible(false);
			SearchImage a = new SearchImage();
			a.StartSearchImage();
		}
		
	}
	
	
	
}
