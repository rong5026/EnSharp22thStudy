package controller;

import java.awt.Color;import java.awt.Dimension;
import java.awt.Font;

import javax.swing.JButton;
import javax.swing.JTextField;

public class ComponentEdit {

	
	//ButtonField 옵션 적용
	public void setButtonOption(JButton button,int fontSize,Color color,int width,int height) { 
		
		Font findingFont = new Font("Stencil",Font.BOLD,fontSize);
		
		
		button.setBorderPainted(false); //테두리 제거
		
		button.setFocusPainted(false); //선택시 사각형생기는거 제거
		
		button.setFont(findingFont); 
		
		button.setBackground(color);   //버튼 배경변경
		
		button.setPreferredSize(new Dimension(width,height)); //버튼크기 변경
		
	}
	
	// TextField 옵션 적용
	public void setTextFieldOption(JTextField jTextField,int fontSize, int width, int height ) {
		
		Font textFieldFont = new Font("맑은고딕",Font.PLAIN,fontSize);
		
		jTextField.setFont(textFieldFont);
		
		jTextField.setPreferredSize(new Dimension(width,height));
		
	}

	
	
}
