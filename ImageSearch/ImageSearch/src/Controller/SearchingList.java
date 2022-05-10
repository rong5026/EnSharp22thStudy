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

import Model.historyDAO;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;




public class SearchingList extends JFrame implements ActionListener,ItemListener{

	String count[] = {"10","20","30"};
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
	
	public void ShowImageList(JPanel imagePanel) { // �̹����� �гο� �� ���̱�
		
		imagePanel.removeAll();
		String result= Getimage();
		JSONParser jsonParser = new JSONParser();
		
		
		try {
			JSONObject jsonObject = (JSONObject)jsonParser.parse(result);
			JSONArray imageUrlArray =(JSONArray)jsonObject.get("documents");
			
			for(int i = 0; i< imageUrlArray.size() ; i++) {
				
				JSONObject imageObject = (JSONObject) imageUrlArray.get(i);
			
				// System.out.println("url : "+imageObject.get("image_url"));
				
				
				// �̹��� ��������
				BufferedImage image = null;
				BufferedImage bigImage = null;
		
				URL url = new URL((String) imageObject.get("thumbnail_url"));		
				bigImageUrl = new URL((String) imageObject.get("image_url"));
				bigImage = ImageIO.read(bigImageUrl);
				
				System.out.println(bigImageUrl);
				image = ImageIO.read(url);
					
				 
				//��ư�� �̹��� �־��ֱ�
				JButton button = new JButton(new ImageIcon(image));
				button.setBorderPainted(false);
				button.setFocusPainted(false);
				button.setContentAreaFilled(false);
				button.setSize(50,50);
				
				//��ư �̺�Ʈ �޾��ֱ�
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
		}catch (IOException  e) {
			e.printStackTrace();
		}
		
	}
	public void CreateBigImageFrame(URL bigImageUrl) {
		
		JFrame frame = new JFrame();
	
		BufferedImage image = null;

		try {
			image = ImageIO.read(bigImageUrl);
			JLabel label =new JLabel(new ImageIcon(image));

			frame.add(label);
			frame.pack();
			frame.setVisible(true);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
	
	}


	@Override
	public void actionPerformed(ActionEvent event) { //��ư����
		JButton button = (JButton)event.getSource();
		
		if(button.getText().equals("�˻��ϱ�")) {
			dataString = textField.getText();
			ShowImageList(imagePanel);
			historyDAO dao = new historyDAO();	
			dao.InsertSearchHistory(dataString);
		}
		else {
			setVisible(false);
			SearchingImage a = new SearchingImage();
			a.StartSearchImage();
		}
		
		
	}
	
	public void itemStateChanged(ItemEvent e) { // �޺��ڽ� ����
		dataString = textField.getText();
		ShowImageList(imagePanel);
	}

	
	
	
	

	
	
}




