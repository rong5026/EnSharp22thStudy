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
	
	public JLabel createLabelOption(String labelText ) { // 라벨 공통요소 적용 후 생성
		
		JLabel label  = setLabelOption( labelText,new Color(199,23,23),new Color(255,175,175,230), Color.red); // 라벨들의 옵션
		
		
		label.setHorizontalAlignment(JLabel.CENTER); // 라벨텍스트 가운데정렬
		
		return label;
		
	}
	
	
	public JLabel setLabelOption( String labelText,Color text, Color background, Color border) { //라벨들 다른 요소
		
		
		JLabel label = new JLabel(labelText);
		
		Font labelFont = new Font("Stencil",Font.BOLD,25);
		
		label.setForeground(text); // 텍스트 색상
		
		label.setOpaque(true); //Opaque값을 true로 미리 설정해 주어야 배경색이 적용
		
		label.setBackground(background);  // 라벨 배경색
	
		label.setBorder(new LineBorder(border)); // 라벨 테두리
		
		label.setHorizontalAlignment(JLabel.LEFT); // 라벨텍스트 가운데정렬
		
		label.setFont(labelFont); // 라벨 폰트
		
		return label;
		
	}


	
	
}
