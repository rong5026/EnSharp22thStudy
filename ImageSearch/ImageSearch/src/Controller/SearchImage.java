package Controller;
import Controller.SearchList;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.event.*;
	
public class SearchImage extends JFrame{

	
	public SearchImage() {
		setSize(1000,800);
		setLocationRelativeTo(null);
		setTitle("EN# �̹��� ��ġ");
		setResizable(false);
	
	}
	
	public void StartSearchImage() {
		
		
		Container container = getContentPane();		
		container.setLayout(null);
		
		TextField textField = new TextField(20);
		textField.setBounds(250,250,500,30);
		container.add(textField);
		
		JPanel buttonPanel = new JPanel(new FlowLayout());
		JButton searchingButton = new JButton("�˻��ϱ�");		
		JButton recordButton = new JButton("��Ϻ���");
		
		
		buttonPanel.add(searchingButton);
		buttonPanel.add(recordButton);
		buttonPanel.setBounds(400,300,200,200);
		
		searchingButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				String dataString = textField.getText();
				System.out.println(dataString);
				
				setVisible(false);
				SearchList a =new SearchList();
				a.StartSearchList();
			
				
				
			}
		});
		container.add(buttonPanel);
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		
		
	}
	
	

}
