package Controller;
import java.awt.*;
import java.awt.event.*;
import java.net.URL;

import javax.swing.*;
import javax.swing.event.*;
import java.net.URL;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;



public class SearchList extends JFrame implements ActionListener{

	String count[] = {"10","20","30"};
	
	public SearchList() {
		setSize(1000,800);
		setLocationRelativeTo(null);
		setTitle("EN# 이미지 서치");
		setResizable(false);
		
	
	}
	
	public void StartSearchList(String dataString) {
		
		Container container = getContentPane();		
		container.setLayout(new BorderLayout());
		
		
		
		JPanel buttonPanel = new JPanel(new FlowLayout());
		
		TextField textField = new TextField(20);	
		textField.setText(dataString);
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
	
	public void Getimage() {
		
		try {
			
			String reqURL = "https://dapi.kakao.com/v2/search/image?sort=accuracy&page=1&size=3&query=python";
			URL url = new URL(reqURL);
			HttpURLConnection connection = (HttpURLConnection) url.openConnection();
			connection.setRequestMethod("GET");
			connection.setRequestProperty("Authorization", "KakaoAK 218c562ea0d8c58d03fc5b731d32838b");
			connection.setDoOutput(true);
			
			BufferedReader br = new BufferedReader (new InputStreamReader(connection.getInputStream()));
			
			String line = "";
			String result = "";

			while ((line = br.readLine()) != null) {
				result += line;
			}
			System.out.println("response body : " + result);
		
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		
	}
	@Override
	public void actionPerformed(ActionEvent e) {
		JButton button = (JButton)e.getSource();
		
		if(button.getText().equals("검색하기")) {
			Getimage();
		}
		else {
			setVisible(false);
			SearchImage a = new SearchImage();
			a.StartSearchImage();
		}
		
	}
	
	
	
}




