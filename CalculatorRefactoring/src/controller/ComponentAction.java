package controller;

import java.awt.Font;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;

import javax.swing.JFrame;
import javax.swing.JLabel;

public class ComponentAction {
	
	private JFrame mainFrame;
	
	public ComponentAction(JFrame mainFrame) {
		this.mainFrame = mainFrame;
		
	}
	
	
	private void setComponentAction() {
		
		
		mainFrame.addComponentListener(new ComponentAdapter() {
			
			@Override
			public void componentResized(ComponentEvent e) {
			
				if(mainFrame.getWidth() > 400) {
					
					
				}
				else {
					
				}
			
				
			}
			
		});
	}
	
	

}
