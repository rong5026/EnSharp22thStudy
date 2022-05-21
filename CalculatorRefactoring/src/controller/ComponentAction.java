package controller;

import java.awt.Font;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;

import javax.swing.JLabel;

public class ComponentAction {
	
	
	public ComponentAction(JLabel inputJLabel) {
		
		inputJLabel.addComponentListener(new ComponentAdapter() {
			
			@Override
			public void componentResized(ComponentEvent e) {
			
				 int i=0;
			        while(true) {
			            Font before = inputJLabel.getFont();
			            Font font = new Font(before.getName(), before.getStyle(),i);
			            inputJLabel. setFont(font);
			            if(CalculatorStart.mainFrame.getWidth()>inputJLabel.getWidth() || CalculatorStart.mainFrame.getHeight()>inputJLabel.getHeight()) {
			                font = new Font(before.getName(), before.getStyle(), i-1);
			                inputJLabel.setFont(font);
			                break;
			            }
			            i++;    
			            
			        
			        }
				
				
			}
			
		});
	}
	
	

}
