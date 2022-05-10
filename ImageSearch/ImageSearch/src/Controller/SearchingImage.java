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
		
		JPanel historyJPanel = new JPanel(new BorderLayout()); // �˻���� �г� ����
		
		JLabel historyLabel =new JLabel("�˻� ���");
		historyLabel.setForeground(Color.black); // ���ڻ�
		historyLabel.setBackground(Color.yellow); // ��� ���
		historyJPanel.add(historyLabel);
		historyJPanel.setBounds(450,50,500,30);
		
		JTextArea text= new JTextArea();
		JScrollPane scrollPane = new JScrollPane(text);  //��ũ���� �߰�
		text.setLineWrap(true); // �ڵ� �ٹٲ�
		scrollPane.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS); // ������ũ�ѹ� ����
		
		
		
		//�гο� ���̱�
		historyJPanel.add(scrollPane); 
		historyJPanel.add(historyLabel);
		
		
		searchingButton.addActionListener(new ActionListener() { // �˻��ϱ� ��ư �̺�Ʈ
			
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
		recordButton.addActionListener(new ActionListener() { // �˻���� ��ư �̺�Ʈ
			
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
	
	private void ShowHistory(JPanel historyJPanel) { // �˻���� �гο� ������Ʈ ����
		
	
		JLabel historyLabel =new JLabel("�˻� ���");
		historyLabel.setForeground(Color.black); // ���ڻ�
		historyLabel.setBackground(Color.yellow); // ��� ���
		
		JTextArea text= new JTextArea();
		JScrollPane scrollPane = new JScrollPane(text);  //��ũ���� �߰�
		text.setLineWrap(true); // �ڵ� �ٹٲ�
		scrollPane.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS); // ������ũ�ѹ� ����
		
		//�гο� ���̱�
	
		historyJPanel.add(scrollPane); 
		historyJPanel.add(historyLabel);
		
	


		
		
		
	}
	

}

