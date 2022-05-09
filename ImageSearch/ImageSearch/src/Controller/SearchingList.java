package Controller;
import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import java.net.URL;

import javax.imageio.ImageIO;
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




public class SearchingList extends JFrame implements ActionListener,ItemListener{

	String count[] = {"10","20","30"};
	String comboboxNumber;
	String dataString;
	String apiResult;
	JComboBox<String> countCombobox;
	
	JPanel imagePanel;
	TextField textField;
	
	public SearchingList() {
		setSize(1000,800);
		setLocationRelativeTo(null);
		setTitle("EN# �̹��� ��ġ");
		setResizable(false);
		comboboxNumber = "10";
	
		
	}
	
	public void StartSearchList(String dataString) {
		
		
		this.dataString = dataString;
		Container container = getContentPane();		
		container.setLayout(new BorderLayout());
		
		
		//��ư ���� �г�
		JPanel buttonPanel = new JPanel(new FlowLayout(FlowLayout.CENTER));
		
		//�ؽ�Ʈ�ʵ�
		textField = new TextField(20);	
		textField.setText(dataString);
		textField.setColumns(40);
		//��ư
		JButton searchingButton = new JButton("�˻��ϱ�");		
		JButton backButton = new JButton("�ڷΰ���");
		//�޺��ڽ�
		countCombobox = new JComboBox(count);
		countCombobox.addItemListener(this);
		
		
		//�˻�,�ڷΰ���,�Է�ĭ,�޺��ڽ�
		buttonPanel.add(textField);
		buttonPanel.add(searchingButton);
		buttonPanel.add(backButton);
		buttonPanel.add(countCombobox);
		//buttonPanel.setBounds(400,300,200,200);
		
		//��ư ������
		searchingButton.addActionListener(this);
		backButton.addActionListener(this);
		
		container.add(buttonPanel,BorderLayout.NORTH);
		
		
		// �̹������� �г�
		imagePanel = new JPanel(new GridLayout(5,2));
		ShowImageList(imagePanel);
		container.add(imagePanel,BorderLayout.CENTER);
		//imagePanel.setBounds(400,300,200,200);
		
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		
		
		
	}
	
	public String Getimage() { // APi���ϰ� 
		String result = "";
		try {
			if(countCombobox == null)
				comboboxNumber = "10";
			else
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
				
			br.close();
			return result;
			
			
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return result;
		
		
		
	}
	
	public void ShowImageList(JPanel imagePanel) {
		
		imagePanel.removeAll();
		String result= Getimage();
		JSONParser jsonParser = new JSONParser();
		System.out.print(result);
		
		try {
			JSONObject jsonObject = (JSONObject)jsonParser.parse(result);
			JSONArray imageUrlArray =(JSONArray)jsonObject.get("documents");
			
			for(int i = 0; i< imageUrlArray.size() ; i++) {
				
				JSONObject imageObject = (JSONObject) imageUrlArray.get(i);
				// System.out.println("url : "+imageObject.get("image_url"));
				
				BufferedImage image = null;
				
				try {
					URL url = new URL((String) imageObject.get("thumbnail_url"));
					image = ImageIO.read(url);
				} catch (IOException  e) {
					e.printStackTrace();
				}
				
				JButton button = new JButton(new ImageIcon(image));
				button.setBorderPainted(false);
				button.setFocusPainted(false);
				button.setContentAreaFilled(false);
				button.setSize(50,50);
				imagePanel.add(button);
				
				imagePanel.revalidate();
				imagePanel.repaint();
			}
			
			
		} catch (ParseException e) {
			
			e.printStackTrace();
		}
	}
	@Override
	public void actionPerformed(ActionEvent event) {
		JButton button = (JButton)event.getSource();
		
		if(button.getText().equals("�˻��ϱ�")) {
			dataString = textField.getText();
			ShowImageList(imagePanel);
		}
		else {
			setVisible(false);
			SearchingImage a = new SearchingImage();
			a.StartSearchImage();
		}
		
	}
	
	public void itemStateChanged(ItemEvent e) {
		dataString = textField.getText();
		ShowImageList(imagePanel);
		
		
		

	}
	
}





