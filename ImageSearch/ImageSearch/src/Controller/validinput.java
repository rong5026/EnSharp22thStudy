package Controller;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;


public class validinput implements ActionListener {


	@Override
	public void actionPerformed(ActionEvent e) {
		JButton button = (JButton)e.getSource();
		
		if(button.getText().equals("�˻��ϱ�")) {
			
		}
		else {
			//setVisible(false);
			SearchingImage a = new SearchingImage();
			a.StartSearchImage();
		}
		
	}

	
	
}
