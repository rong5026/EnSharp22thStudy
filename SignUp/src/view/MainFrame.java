package view;

import java.awt.BorderLayout;
import java.awt.Button;
import java.awt.Color;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.GridLayout;
import java.awt.Image;
import java.awt.TextField;

import javax.swing.Box;
import javax.swing.Icon;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

import controller.ComponentEdit;
import utility.ConstantNumber;

public class MainFrame extends JFrame{
	
	
	private MainPanel mainPanel;
	private UserEditPanel userEditPanel;
	private ComponentEdit componentEdit;
	
	
	public MainFrame() {
		
		componentEdit =new ComponentEdit();
		
		mainPanel = new MainPanel(componentEdit);
		
		userEditPanel = new UserEditPanel();
		
		setMainFrame();// mainframe 초기화
		
	}
	
	
	public void startMainFrame() {
		
		
		setContentPane(mainPanel); // frame에 mainpanel로 변경
		
		setVisible(true);
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);//JFrame이 정상적으로 종료되게
		
	}
	
	
	private void setMainFrame() { // mainframe 초기화
		
		ImageIcon icon = new ImageIcon(ConstantNumber.SIGNUP_ICON_IMAGE);
		
		setIconImage(icon.getImage()); // 아이콘 설정
		
		setTitle("EN# SignUp");       //타이틀 이름 
		
		setSize(800,900);			//프레임의 크기
		
		setResizable(false);           //창 크기 고정
		
		setLocationRelativeTo(null);   //창 가운데 배치
		
		setLayout(new BorderLayout()); // 창 레이아웃 
		 
	}
	
}




