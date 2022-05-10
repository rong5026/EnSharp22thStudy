package Controller;
import Controller.SearchingList;
import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.net.URL;

import javax.imageio.ImageIO;
import javax.swing.*;
import javax.swing.event.*;
import Model.HistoryDAO;
import javax.swing.Box;
import javax.swing.BoxLayout;


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
		
		JPanel mainPanel = new JPanel(new FlowLayout());
		JButton searchingButton = new JButton("검색하기");		
		JButton recordButton = new JButton("기록보기");
		
		
		
		mainPanel.add(searchingButton);
		mainPanel.add(recordButton);
		mainPanel.setBounds(400,300,200,200);
		
		JPanel historyJPanel = new JPanel(new BorderLayout()); // 검색기록 패널 생성
		
		JLabel historyLabel =new JLabel("검색 기록");
		historyLabel.setForeground(Color.black); // 글자색
		historyLabel.setBackground(Color.yellow); // 배경 노랑
		historyJPanel.add(historyLabel);
		historyJPanel.setBounds(450,50,500,30);
		
		JTextArea text= new JTextArea();
		JScrollPane scrollPane = new JScrollPane(text);  //스크롤판 추가
		text.setLineWrap(true); // 자동 줄바꿈
		scrollPane.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS); // 수직스크롤바 생성
		
		
		
		//패널에 붙이기
		historyJPanel.add(scrollPane); 
		historyJPanel.add(historyLabel);
		
		
		searchingButton.addActionListener(new ActionListener() { // 검색하기 버튼 이벤트
			
			@Override
			public void actionPerformed(ActionEvent e) {
				String dataString = textField.getText();
			
				setVisible(false);
				SearchingList a  = new SearchingList();
				a.StartSearchList(dataString);
				
				HistoryDAO dao = new HistoryDAO();	
				dao.InsertSearchHistory(dataString);
			
				
			}
		});
		recordButton.addActionListener(new ActionListener() { // 검색기록 버튼 이벤트
			
			@Override
			public void actionPerformed(ActionEvent e) {
				
				container.removeAll();
				container.add(historyJPanel);
				container.revalidate();
				container.repaint();
				
				//historyJPanel.setVisible(true);
				
			}
		});
		
		container.add(mainPanel);
			
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		
		
	}
	
	private void ShowHistory(JPanel historyJPanel) { // 검색기록 패널에 컴포넌트 삽입
		
	
		JLabel historyLabel =new JLabel("검색 기록");
		historyLabel.setForeground(Color.black); // 글자색
		historyLabel.setBackground(Color.yellow); // 배경 노랑
		
		JTextArea text= new JTextArea();
		JScrollPane scrollPane = new JScrollPane(text);  //스크롤판 추가
		text.setLineWrap(true); // 자동 줄바꿈
		scrollPane.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS); // 수직스크롤바 생성
		
		//패널에 붙이기
	
		historyJPanel.add(scrollPane); 
		historyJPanel.add(historyLabel);
		
	


		
		
		
	}
	

}