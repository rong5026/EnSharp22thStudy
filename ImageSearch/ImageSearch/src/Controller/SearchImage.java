package Controller;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.event.*;
	
public class SearchImage extends JFrame{

	public void StartSearchImage() {
		setTitle("EN# 이미지 서치");
		setSize(600,600);
		setVisible(true);
		
		Container container = getContentPane();
		
		container.setLayout(new BorderLayout());
		
		JPanel imagePanel = new JPanel();
		imagePanel.setBackground(Color.LIGHT_GRAY);

	
		JPanel searchinPanel = new JPanel();
		searchinPanel.setBackground(Color.YELLOW);
	
		
		JPanel buttonPanel = new JPanel();
		
		JButton searchingButton = new JButton("검색하기");		
		JButton backButton = new JButton("뒤로가기");
		buttonPanel.add(searchingButton);
		buttonPanel.add(backButton);
		
		
		
		
	}

}
