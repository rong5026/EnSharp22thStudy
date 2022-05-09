package Controller;
import Controller.SearchingList;
import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.awt.Image;
import javax.imageio.ImageIO;
import javax.swing.*;
import javax.swing.event.*;
	
public class SearchingImage extends JFrame{

	
	
	public SearchingImage() {
		setSize(1000,800);
		setLocationRelativeTo(null);
		setTitle("EN# 이미지 서치");
		setResizable(false);
	
	}
	
	public void StartSearchImage() {
		
		
		Container container = getContentPane();		
		container.setLayout(null);
			

		
		TextField textField = new TextField(20);
		textField.setBounds(250,250,500,30);
		container.add(textField);
		
		JPanel buttonPanel = new JPanel(new FlowLayout());
		JButton searchingButton = new JButton("검색하기");		
		JButton recordButton = new JButton("기록보기");
		
		
		
		buttonPanel.add(searchingButton);
		buttonPanel.add(recordButton);
		buttonPanel.setBounds(400,300,200,200);
		
		searchingButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				String dataString = textField.getText();
			
				setVisible(false);
				SearchingList a  = new SearchingList();
				a.StartSearchList(dataString);
			
				
			}
		});
		container.add(buttonPanel);
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		
		
	}
	
	

}
