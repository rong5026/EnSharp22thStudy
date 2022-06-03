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
import controller.listener.SwitchingPanelListener;
import utility.ConstantNumber;

public class MainFrame extends JFrame{
	
	private ComponentEdit componentEdit;
	
	private MainPanel mainPanel;
	private UserEditPanel userEditPanel;
	private LoginedPanel loginedPanel;
	private LogoutPanel logoutPanel;
	private DeletingPanel deletingPanel;

	private SwitchingPanelListener switchingPanelListener;
	
	
	public MainFrame() {
		
		this.componentEdit =new ComponentEdit();
		
		this.mainPanel = new MainPanel(componentEdit);
		
		this.userEditPanel = new UserEditPanel(componentEdit);
		
		this.loginedPanel = new LoginedPanel(componentEdit);
		
		this.logoutPanel = new LogoutPanel(componentEdit);
		
		this.deletingPanel = new DeletingPanel(componentEdit);
		
		this.switchingPanelListener = new SwitchingPanelListener();
		
		
		
		
		setMainFrame();// mainframe 초기화
		
		setListner(); // 버튼에 리스너 달기
		
	}
	
	
	public void startMainFrame() { // mainframe 초기화
		
		
		add(mainPanel); // mainFrame에 mainPanel 부착
		
		setVisible(true);
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);//JFrame이 정상적으로 종료되게
		
	}
	
	private void setListner() {
		
		Container container = getContentPane();
		
		//메인 -> 로그인 
		switchingPanelListener.changePanel(this.mainPanel.loginButton, container, loginedPanel);
		
		//로그아웃 패널로 이동
		switchingPanelListener.changePanel(this.loginedPanel.logOutButton, container, logoutPanel);
		
		//로그아웃 yes -> 메인
		switchingPanelListener.changePanel(this.logoutPanel.yesButton, container, mainPanel);
		
		//로그아웃 no -> 로그인
		switchingPanelListener.changePanel(this.logoutPanel.noButton, container, loginedPanel);
		
		//삭제 패널로 이동
		switchingPanelListener.changePanel(this.loginedPanel.idDeleteButton, container, deletingPanel);
		
		//삭제 Yes -> 메인 이동
		switchingPanelListener.changePanel(this.deletingPanel.yesButton, container, mainPanel);
		
		//삭제 No -> 로그인
		switchingPanelListener.changePanel(this.deletingPanel.noButton, container, loginedPanel);
		
		//로그인 -> 유저정보 수정
		switchingPanelListener.changePanel(this.loginedPanel.editButton, container, userEditPanel);
		
		//유저정보 수정 -> 로그인
		switchingPanelListener.changePanel(this.userEditPanel.backButton, container, loginedPanel);
		
		
		
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




