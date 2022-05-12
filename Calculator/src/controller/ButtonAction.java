package controller;

import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import view.ButtonPanel;
import view.TextPanel;

public class ButtonAction {
	private JButton pressedbutton;
	private String inpuText;
	private String resultText;
	
	public void setButtonAction(JButton [] button) {
		for(int index =0 ; index<20 ; index++) {
			
			//숫자버튼 엑션 1 ~ 9
			if(3 <index && index<15 && index%4!=3) {
				button[index].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						pressedbutton = (JButton)e.getSource();
						// 0밖에 없을때는 지우고 입력한 숫자표시
						if(TextPanel.inputJLabel.getText() =="0")
							TextPanel.inputJLabel.setText("");
						
						//최대길이 16개로 제한
						if(TextPanel.inputJLabel.getText().length()<16) {
							inpuText= pressedbutton.getText();
							resultText = TextPanel.inputJLabel.getText()+inpuText;
							
							TextPanel.inputJLabel.setText(resultText);
						
						}
					}
				});
			}
			// 숫자 0
			else if(index ==17) {
				button[index].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						pressedbutton = (JButton)e.getSource();
						// 0밖에 없을때 제외, 길이 16까지 제한
						if(TextPanel.inputJLabel.getText() !="0" &&TextPanel.inputJLabel.getText().length()<16) {
							inpuText= pressedbutton.getText();
							resultText = TextPanel.inputJLabel.getText()+inpuText;
							
							TextPanel.inputJLabel.setText(resultText);
						}
						
						
						
						
					}
				});
				
					
			}
			
			
		}
	
	
	}
}
