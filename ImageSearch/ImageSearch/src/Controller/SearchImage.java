package Controller;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.event.*;
	
public class SearchImage extends JFrame{

	public void StartSearchImage() {
		setTitle("EN# �̹��� ��ġ");
		setSize(600,600);
		setVisible(true);
		
		Container container = getContentPane();
		
		container.setLayout(new BorderLayout());
		
		JPanel imagePanel = new JPanel();
		imagePanel.setBackground(Color.LIGHT_GRAY);

	
		JPanel searchinPanel = new JPanel();
		searchinPanel.setBackground(Color.YELLOW);
	
		
		JPanel buttonPanel = new JPanel();
		
		JButton searchingButton = new JButton("�˻��ϱ�");		
		JButton backButton = new JButton("�ڷΰ���");
		buttonPanel.add(searchingButton);
		buttonPanel.add(backButton);
		
		
		
		
	}

}
