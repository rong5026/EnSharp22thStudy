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

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;




public class SearchingList extends JFrame implements ActionListener,ItemListener,MouseListener{

	String count[] = {"10","20","30"};
	String comboboxNumber;
	String dataString;
	String apiResult;
	JComboBox<String> countCombobox;
	
	JPanel imagePanel;
	TextField textField;
	JSONObject imageObject;
	BufferedImage bigImage;
	
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
		//buttonPanel.setBounds(400,300,200,200);
		
		//버튼 리스너
		searchingButton.addActionListener(this);
		backButton.addActionListener(this);
		
		container.add(buttonPanel,BorderLayout.NORTH);
		
		
		// 이미지붙일 패널
		imagePanel = new JPanel(new GridLayout(5,2));
		ShowImageList(imagePanel);
		container.add(imagePanel,BorderLayout.CENTER);
		//imagePanel.setBounds(400,300,200,200);
		
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		
		
		
	}
	
	public String Getimage() { // APi리턴값 
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
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return result;
		
		
		
	}
	
	public void ShowImageList(JPanel imagePanel) { // 이미지를 패널에 다 붙이기
		
		imagePanel.removeAll();
		String result= Getimage();
		JSONParser jsonParser = new JSONParser();
		
		
		try {
			JSONObject jsonObject = (JSONObject)jsonParser.parse(result);
			JSONArray imageUrlArray =(JSONArray)jsonObject.get("documents");
			
			for(int i = 0; i< imageUrlArray.size() ; i++) {
				
				imageObject = (JSONObject) imageUrlArray.get(i);
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
				
				button.addMouseListener(this);
			
				imagePanel.add(button);
				
				imagePanel.revalidate();
				imagePanel.repaint();
			}
			
			
		} catch (ParseException e) {
			
			e.printStackTrace();
		}
	}

	public void ShowBigImage(JSONObject imageObject) {
		
		JFrame bigImageFrame = new JFrame();
		bigImage = null;
		int x;
		int y;
		try {
			URL imageUrl = new URL((String) imageObject.get("image_url"));
			//x = (int) imageObject.get("width");
			//y = (int) imageObject.get("height");

			bigImage = ImageIO.read(imageUrl);
		
			BigImagePanel panel = new BigImagePanel();
			
			bigImageFrame.add(panel);
			
			bigImageFrame.setVisible(true);
			
			
		} catch (IOException  e) {
			e.printStackTrace();
		}
		
		
		
	}
	class BigImagePanel extends JPanel{
		public void paint(Graphics g) {
			g.drawImage(bigImage,0,0,null);
		}
	}
	@Override
	public void actionPerformed(ActionEvent event) { //버튼엑션
		JButton button = (JButton)event.getSource();
		
		if(button.getText().equals("검색하기")) {
			dataString = textField.getText();
			ShowImageList(imagePanel);
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
	
	public void mouseClicked(MouseEvent e) {
		if(e.getClickCount()==2) {
			if(e.getClickCount()==2) {
				ShowBigImage(imageObject);
			}
			
		}
	}

	@Override
	public void mousePressed(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mouseReleased(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mouseEntered(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mouseExited(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}
	
}





