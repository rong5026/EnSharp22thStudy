package Controller;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.event.*;
	
public class SearchImage extends JFrame{

	
	public SearchImage() {
		setSize(1000,800);
		setLocationRelativeTo(null);
		
		setResizable(false);
	}
	
	public void StartSearchImage() {
		setTitle("EN# 이미지 서치");
		
		
		Container container = getContentPane();		
		container.setLayout(new BorderLayout());
	
			
		
		JPanel imagePanel = new JPanel();
		imagePanel.setBackground(Color.LIGHT_GRAY);
		container.add(imagePanel,BorderLayout.NORTH);
	
		
		JPanel searchinPanel = new JPanel();
		searchinPanel.setBackground(Color.green);
		container.add(searchinPanel,BorderLayout.CENTER);
		
		
		JPanel buttonPanel = new JPanel(new FlowLayout(FlowLayout.CENTER,30,40));
		JButton searchingButton = new JButton("검색하기");		
		JButton backButton = new JButton("뒤로가기");
		buttonPanel.add(searchingButton);
		buttonPanel.add(backButton);
		
		container.add(buttonPanel,BorderLayout.SOUTH);
		
		
		
		
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		
		
	}

}
