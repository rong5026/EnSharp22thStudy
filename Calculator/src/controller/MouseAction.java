package controller;

import java.awt.Color;

import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.JButton;

public class MouseAction implements MouseListener {

	private JButton button;
	private Color priorColor;
	

	
	

	@Override
	public void mouseClicked(MouseEvent e) {
		
		
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
