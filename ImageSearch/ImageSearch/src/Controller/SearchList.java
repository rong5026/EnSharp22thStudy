package Controller;
import java.awt.*;
import java.awt.event.*;
import java.net.URL;

import javax.swing.*;
import javax.swing.event.*;
import javax.swing.text.html.HTMLEditorKit.Parser;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;




public class SearchList extends JFrame implements ActionListener{

	String count[] = {"10","20","30"};
	String comboboxNumber;
	String dataString;
	JComboBox<String> countCombobox;
	public SearchList() {
		setSize(1000,800);
		setLocationRelativeTo(null);
		setTitle("EN# �̹��� ��ġ");
		setResizable(false);
		
	
	}
	
	public void StartSearchList(String dataString) {
		
	
		
		Container container = getContentPane();		
		container.setLayout(new BorderLayout());
		
		
		
		JPanel buttonPanel = new JPanel(new FlowLayout());
		
		TextField textField = new TextField(20);	
		textField.setText(dataString);
		JButton searchingButton = new JButton("�˻��ϱ�");		
		JButton backButton = new JButton("�ڷΰ���");
		countCombobox = new JComboBox(count);
		
		
	

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
	
	public String Getimage() { // APi���ϰ� ������
		String result = "";
		try {
			comboboxNumber = countCombobox.getSelectedItem().toString(); 

			String reqURL = "https://dapi.kakao.com/v2/search/image?sort=accuracy&page=1&size="+comboboxNumber+"&query="+dataString;
			URL url = new URL(reqURL);
			HttpURLConnection connection = (HttpURLConnection) url.openConnection();
			connection.setRequestMethod("GET");
			connection.setRequestProperty("Authorization", "KakaoAK 218c562ea0d8c58d03fc5b731d32838b");
			connection.setDoOutput(true);
			
			BufferedReader br = new BufferedReader (new InputStreamReader(connection.getInputStream()));
			
			String line = "";
		

			while ((line = br.readLine()) != null) {
				result += line;
			}
			//System.out.println("response body : " + result);
				
			br.close();
			return result;
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return result;
		
		
		
	}
	@Override
	public void actionPerformed(ActionEvent event) {
		JButton button = (JButton)event.getSource();
		
		if(button.getText().equals("�˻��ϱ�")) {
			String result= Getimage();
			
			JSONParser jsonParser = new JSONParser();
			System.out.print(result);
			
		
			try {
				JSONObject jsonObject = (JSONObject)jsonParser.parse(result);
				JSONArray imageUrlArray =(JSONArray)jsonObject.get("documents");
				
				for(int i = 0; i< imageUrlArray.size() ; i++) {
					 JSONObject imageObject = (JSONObject) imageUrlArray.get(i);
					 
					 System.out.println("url : "+imageObject.get("image_url"));
				}
			} catch (ParseException e) {
				
				e.printStackTrace();
			}
			
		}
		else {
			setVisible(false);
			SearchImage a = new SearchImage();
			a.StartSearchImage();
		}
		
	}
	
	
	
}




