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
		setTitle("EN# �̹��� ��ġ");
		setResizable(false);
	
	}
	
	public void StartSearchImage() {
		
		
		Container container = getContentPane();		
		container.setLayout(null);
			

		
		TextField textField = new TextField(20);
		textField.setBounds(250,250,500,30);
		container.add(textField);
		
		JPanel mainPanel = new JPanel(new FlowLayout());
		JButton searchingButton = new JButton("�˻��ϱ�");		
		JButton recordButton = new JButton("��Ϻ���");
		
		
		
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
		
	

		
		JLabel historyLabel =new JLabel("�˻� ���");
		historyJPanel.add(historyLabel);
		
		JTextArea text= new JTextArea();
		JScrollPane scrollPane = new JScrollPane(text);  //��ũ���� �߰�
		text.setLineWrap(true); // �ڵ� �ٹٲ�
		scrollPane.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS); // ������ũ�ѹ� ����
		historyJPanel.add(scrollPane); 
		
		
		text.append("������������������������������");  // ��·α� JTextArea ���
		//area.setCaretPosition(txtLog.getDocument().getLength());


		
	
		
		
	}
	

}

