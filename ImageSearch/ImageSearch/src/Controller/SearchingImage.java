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
import Model.historyDAO;
import javax.swing.Box;
import javax.swing.BoxLayout;


public class SearchingImage extends JFrame{

	
	JPanel historyJPanel = new JPanel();
	
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
		
		JPanel mainPanel = new JPanel(new FlowLayout());
		JButton searchingButton = new JButton("검색하기");		
		JButton recordButton = new JButton("기록보기");
		
		
		
		mainPanel.add(searchingButton);
		mainPanel.add(recordButton);
		mainPanel.setBounds(400,300,200,200);
		
		searchingButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				String dataString = textField.getText();
			
				setVisible(false);
				SearchingList a  = new SearchingList();
				a.StartSearchList(dataString);
				
				historyDAO dao = new historyDAO();	
				dao.InsertSearchHistory(dataString);
			
				
			}
		});
		recordButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				ShowHistory();
				
				container.removeAll();
				//mainPanel.setVisible(false);
				
				container.add(historyJPanel);
				historyJPanel.setVisible(true);
				//container.repaint();
				
				
				
			}
		});
		
		container.add(mainPanel);
			
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		
		
	}
	
	private void ShowHistory() {
		
	

		
		JLabel historyLabel =new JLabel("검색 기록");
		historyJPanel.add(historyLabel);
		
		JTextArea text= new JTextArea();
		JScrollPane scrollPane = new JScrollPane(text);  //스크롤판 추가
		text.setLineWrap(true); // 자동 줄바꿈
		scrollPane.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS); // 수직스크롤바 생성
		historyJPanel.add(scrollPane); 
		
		
		text.append("ㅁㄴㅇㄻㄴㅇㄻㄴㅇㄻㄴㅇㄻㄴㅇ");  // 출력로그 JTextArea 출력
		//area.setCaretPosition(txtLog.getDocument().getLength());


		
	
		
		
	}
	

}

