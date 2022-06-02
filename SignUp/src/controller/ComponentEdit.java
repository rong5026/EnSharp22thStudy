package controller;

import java.awt.Color;
import java.awt.Font;

import javax.swing.JButton;

public class ComponentEdit {

	
	
	public void setButtonOption(JButton button,Font font,Color color) { //버튼 폰트적용
		
		button.setBorderPainted(false); //테두리 제거
		
		button.setFocusPainted(false); //선택시 사각형생기는거 제거
		
		button.setFont(font); 
		
		button.setBackground(color);
		
	}
	
}
