package controller;

import java.awt.Color;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.JButton;
import view.ButtonPanel;
import view.TextPanel;
public class MouseAction implements MouseListener {

	private JButton button;
	private Color priorColor;
	
	@Override
	public void mouseClicked(MouseEvent e) {
		
		
	
		for(int index =0; index<20;index++) {
			
			if(3 <index && index<15 && index%4!=3) {
				
				if(TextPanel.informationJLabel.getText() =="0")
					TextPanel.informationJLabel.setText("");
				
				button = (JButton)e.getSource();
				System.out.println(button.getText());
				
				
			}
			
			
		}
		
		
	}

	@Override
	public void mousePressed(MouseEvent e) {
		
		
	}

	@Override
	public void mouseReleased(MouseEvent e) {
		
		
	}

	@Override
	public void mouseEntered(MouseEvent e) {
		button = (JButton)e.getSource();
		priorColor = button.getBackground();
		button.setBackground(new Color(192,192,192));
		
	}
	
	@Override
	public void mouseExited(MouseEvent e) {
		button = (JButton)e.getSource();
		button.setBackground(priorColor);
		
	}
	
	
	
	

}
