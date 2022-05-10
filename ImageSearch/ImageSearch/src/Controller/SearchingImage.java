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
				//container.add(historyJPanel);
				ShowHistory();
				container.revalidate();
				container.repaint();
				
				//historyJPanel.setVisible(true);
				
			}
		});
		
		container.add(mainPanel);
			
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		
		
	}
	
	private void ShowHistory() { // 검색기록 패널에 컴포넌트 삽입
		
		this.setLayout(new BorderLayout()); // 프레임 레이아웃변경
		
		JPanel northPanel = new JPanel();
	
		JLabel historyLabel =new JLabel("검색 기록");
		historyLabel.setForeground(Color.black); // 글자색
		historyLabel.setBackground(Color.yellow); // 배경 노랑
		historyLabel.setPreferredSize(new Dimension(100,100));
		
		northPanel.setBackground(Color.BLUE);
		
		northPanel.add(historyLabel);
		
		
		JPanel centerPanel = new JPanel();
		JTextArea textArea= new JTextArea();
		JScrollPane scrollPane = new JScrollPane(textArea);  //스크롤판 추가
		scrollPane.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS); // 수직스크롤바 생성
		
		centerPanel.add(scrollPane);
		scrollPane.setPreferredSize(new Dimension(500,500));
		centerPanel.setBackground(Color.RED);
		
		JPanel southPanel = new JPanel(new FlowLayout());
		southPanel.setPreferredSize(new Dimension(100,120));
		JButton deleteButton = new JButton("삭제하기");
		JButton backButton = new JButton("뒤로가기");
		southPanel.add(deleteButton);
		southPanel.add(backButton);
		
		
		//프레임에 패널 추가
		this.add(northPanel,BorderLayout.NORTH);
		this.add(centerPanel,BorderLayout.CENTER);
		this.add(southPanel, BorderLayout.SOUTH);
	
	}
	

}

