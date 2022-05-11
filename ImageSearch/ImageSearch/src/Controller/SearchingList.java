package Controller;
import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import java.net.URL;
import java.net.URLEncoder;

import javax.imageio.ImageIO;
import javax.swing.*;
import javax.swing.event.*;
import javax.swing.text.html.HTMLEditorKit.Parser;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

import Model.HistoryDAO;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;


public class SearchingList extends JFrame implements ActionListener,ItemListener{

	String count[] = {"10","20","30"}; //접근제한자
	String comboboxNumber;
	String dataString;
	String apiResult;
	JComboBox<String> countCombobox;
	
	JPanel imagePanel;
	TextField textField;

	
	URL bigImageUrl;
	
	public SearchingList() {
		setSize(1000,800);
		setLocationRelativeTo(null);
		setTitle("EN# 이미지 서치");
		setResizable(false);
		comboboxNumber = "10";
	
		
	}
	
	public void StartSearchList(String dataString) {
		
		
		this.dataString = dataString;
		Container container = getContentPane();		
		container.setLayout(new BorderLayout());
		
		
		//버튼 붙일 패널
		JPanel buttonPanel = new JPanel(new FlowLayout(FlowLayout.CENTER));
		
		//텍스트필드
		textField = new TextField(20);	
		textField.setText(dataString);
		textField.setColumns(40);
		//버튼
		JButton searchingButton = new JButton("검색하기");		
		JButton backButton = new JButton("뒤로가기");
		//콤보박스
		countCombobox = new JComboBox(count);
		countCombobox.addItemListener(this);
		
		
		//검색,뒤로가기,입력칸,콤보박스
		buttonPanel.add(textField);
		buttonPanel.add(searchingButton);
		buttonPanel.add(backButton);
		buttonPanel.add(countCombobox);
		
		
		
		//버튼 리스너
		searchingButton.addActionListener(this);
		backButton.addActionListener(this);
		
		container.add(buttonPanel,BorderLayout.NORTH);
		
		
		// 이미지붙일 패널
		imagePanel = new JPanel(new GridLayout(5,2));
		ShowImageList(imagePanel);
		container.add(imagePanel,BorderLayout.CENTER);
	
		
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		
		
		
	}
	
	public String GetAPIDate() { // APi받아온 문자 리턴
		String result = "";
		try {
			if(countCombobox == null)
				comboboxNumber = "10";
			else
				comboboxNumber = countCombobox.getSelectedItem().toString(); 
			
			dataString = URLEncoder.encode(dataString,"UTF-8");
			String reqURL = "https://dapi.kakao.com/v2/search/image?sort=accuracy&page=1&size="+comboboxNumber+"&query="+dataString;
						
			URL url = new URL(reqURL);
			
			HttpURLConnection connection = (HttpURLConnection) url.openConnection();
			connection.setRequestMethod("GET");
			connection.setRequestProperty("Authorization", "KakaoAK 218c562ea0d8c58d03fc5b731d32838b");
			connection.setDoOutput(true);
			
			BufferedReader br = new BufferedReader (new InputStreamReader(connection.getInputStream(),"UTF-8"));
			
			String line = "";
		

			while ((line = br.readLine()) != null) {
				result += line;
			}
				
			br.close();
			return result;
			
			
		} catch (IOException e) {
			
			e.printStackTrace();
		}
		return result;
		
		
		
	}
	
	public void ShowImageList(JPanel imagePanel) { // 이미지를 패널에 다 붙이기
		
		imagePanel.removeAll();
		String result= GetAPIDate();
		JSONParser jsonParser = new JSONParser();
		
		
		try {
			JSONObject jsonObject = (JSONObject)jsonParser.parse(result);
			JSONArray imageUrlArray =(JSONArray)jsonObject.get("documents");
			
			for(int i = 0; i< imageUrlArray.size() ; i++) {
				
				JSONObject imageObject = (JSONObject) imageUrlArray.get(i);
			
		
				// 이미지 가져오기
				BufferedImage image = null;
				BufferedImage bigImage = null;
		
				try {
					URL url = new URL((String) imageObject.get("thumbnail_url"));		
					bigImageUrl = new URL((String) imageObject.get("image_url"));
					bigImage = ImageIO.read(bigImageUrl);
					
					image = ImageIO.read(url);
				} catch (IOException  e) {
					
					continue;
				}
				
						 
				//버튼에 이미지 넣어주기
				JButton button = new JButton(new ImageIcon(image));
				button.setBorderPainted(false);
				button.setFocusPainted(false);
				button.setContentAreaFilled(false);
				button.setSize(50,50);
				
				//버튼 이벤트 달아주기
				button.addMouseListener(new MouseListener() {
					
					@Override
					public void mouseReleased(MouseEvent e) {}
					
					@Override
					public void mousePressed(MouseEvent e){}
					
					@Override
					public void mouseExited(MouseEvent e) {}
					
					@Override
					public void mouseEntered(MouseEvent e) {}
					
					@Override
					public void mouseClicked(MouseEvent e) {
						if(e.getClickCount()==2) {
							CreateBigImageFrame(bigImageUrl);
						}
						
					}
				});
					
					
				imagePanel.add(button);
				
				imagePanel.revalidate();
				imagePanel.repaint();
			}
			
			
		} catch (ParseException e) {
			
			e.printStackTrace();
		}
		
	}
	public void CreateBigImageFrame(URL bigImageUrl) { // 원본이미지를 포함한 프레임 만들기
		
		JFrame frame = new JFrame();
		frame.setLocation(100,100); // 원본이미지 띄울 좌표
		BufferedImage image = null;

		try {
			image = ImageIO.read(bigImageUrl);
			JLabel label =new JLabel(new ImageIcon(image));

			frame.add(label);
			frame.pack();
			frame.setVisible(true);
		} catch (IOException e) {
			
			e.printStackTrace();
		}
		
	
	}


	@Override
	public void actionPerformed(ActionEvent event) { //버튼엑션
		JButton button = (JButton)event.getSource();
		
		if(button.getText().equals("검색하기")) {
			dataString = textField.getText();
			ShowImageList(imagePanel);
			HistoryDAO dao = new HistoryDAO();	
			dao.InsertSearchHistory(dataString);
		}
		else {
			setVisible(false);
			SearchingImage a = new SearchingImage();
			a.StartSearchImage();
		}
		
		
	}
	
	public void itemStateChanged(ItemEvent e) { // 콤보박스 엑션
		dataString = textField.getText();
		ShowImageList(imagePanel);
	}

	
	
	
	

	
	
}





