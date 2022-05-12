package controller;

import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import view.ButtonPanel;
import view.TextPanel;

public class ButtonAction {
	private JButton button;
	private String inpuText;
	private String resultText;
	
	public void setButtonAction() {
		for(int index =0 ; index<20 ; index++) {
			
			if(3 <index && index<15 && index%4!=3) {
				ButtonPanel.button[index].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						button = (JButton)e.getSource();
						if(TextPanel.inputJLabel.getText() =="0")
							TextPanel.inputJLabel.setText("");
						inpuText= button.getText();
						resultText = TextPanel.inputJLabel.getText()+inpuText;
						
						TextPanel.inputJLabel.setText(resultText);
						
					}
				});
			}
		}
	
	
	}
}
