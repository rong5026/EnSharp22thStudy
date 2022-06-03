package controller;

import java.awt.Color;import java.awt.Dimension;
import java.awt.Font;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JTextField;
import javax.swing.border.LineBorder;

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
	public void setTextFieldOption(JTextField jTextField,int fontSize ) {
		
		Font textFieldFont = new Font("맑은고딕",Font.PLAIN,fontSize);
		
		jTextField.setFont(textFieldFont);
		
	}
	
	public JLabel createLabelOption(String labelText ) { // 라벨 생성 후 옵션
		
		
		JLabel label = new JLabel(labelText);
		
		Font labelFont = new Font("Stencil",Font.BOLD,25);
			
		label.setForeground(new Color(199,23,23)); // 텍스트 색상
		
		label.setOpaque(true); //Opaque값을 true로 미리 설정해 주어야 배경색이 적용
		
		label.setBackground(new Color(255,175,175,230));  // 라벨 배경색
	
		label.setBorder(new LineBorder(Color.red)); // 라벨 테두리
		
		label.setFont(labelFont); // 라벨 폰트
		
		
		label.setHorizontalAlignment(JLabel.CENTER); // 라벨텍스트 가운데정렬
		

		return label;
		
	}


	
	
}
