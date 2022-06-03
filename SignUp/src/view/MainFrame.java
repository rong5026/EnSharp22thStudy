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
	private SignupPanel signupPanel;

	private SwitchingPanelListener listener;
	private Container container;
	
	public MainFrame() {
		
		
		container = getContentPane(); 
		
		this.listener = new SwitchingPanelListener(container);
		
		this.componentEdit =new ComponentEdit();
		
		this.mainPanel = new MainPanel(componentEdit,container);
		
		this.userEditPanel = new UserEditPanel(componentEdit);
		
		this.loginedPanel = new LoginedPanel(componentEdit);
		
		this.logoutPanel = new LogoutPanel(componentEdit);
		
		this.deletingPanel = new DeletingPanel(componentEdit);
		
		this.signupPanel = new SignupPanel(componentEdit);
	
		this.userEditPanel.idInput.setEditable(false);
		this.userEditPanel.idGuiding.setText("아이디는 변경 할 수 없습니다.");
		
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
		
		//메인 -> 로그인     로그인버튼에 바로 달아줌
		listener.setLoginButtonListener(mainPanel.loginButton,loginedPanel,mainPanel.idText,mainPanel.passwordText, mainPanel );
		
		//메인 -> 회원가입
		listener.changeMainFramePanel(this.mainPanel.signUpButton, signupPanel);
		
		//회원가입 (뒤로가기) -> 메인
		listener.changeMainFramePanel(this.signupPanel.backButton, mainPanel);
		
		//회원가입 (가입하기) -> 메인
		listener.setSignUpButtonListener(signupPanel.editButton, mainPanel,signupPanel.nameInput,signupPanel.idInput,signupPanel.passwordInput,signupPanel.repasswordInput,signupPanel.birthInput,signupPanel.phoneInput,signupPanel.emailInput,signupPanel.addressInput ,"Signup"   );
		
		//로그아웃 패널로 이동
		listener.changeMainFramePanel(this.loginedPanel.logOutButton, logoutPanel);
		
		//로그아웃 yes -> 메인
		listener.changeMainFramePanel(this.logoutPanel.yesButton, mainPanel);
		
		//로그아웃 no -> 로그인
		listener.changeMainFramePanel(this.logoutPanel.noButton, loginedPanel);
		
		//삭제 패널로 이동
		listener.changeMainFramePanel(this.loginedPanel.idDeleteButton, deletingPanel);
		
		//삭제 Yes -> 메인 이동      
		listener.setDeleteButtonListener(this.deletingPanel.yesButton, mainPanel, mainPanel );
		
		//삭제 No -> 로그인
		listener.changeMainFramePanel(this.deletingPanel.noButton, loginedPanel);
		
		//로그인 -> 유저정보 수정
		listener.setChangingEditUserButtonListener(this.loginedPanel.editButton, userEditPanel, mainPanel, userEditPanel.nameInput,userEditPanel.idInput,userEditPanel.passwordInput,userEditPanel.repasswordInput,userEditPanel.birthInput,userEditPanel.phoneInput,userEditPanel.emailInput,userEditPanel.addressInput);
		
		
		//유저정보 수정 (뒤로가기) -> 로그인
		listener.changeMainFramePanel(this.userEditPanel.backButton, loginedPanel);
	
		//유저정보 수정 (수정하기) -> 메인   
		listener.setSignUpButtonListener(userEditPanel.editButton, userEditPanel,userEditPanel.nameInput,userEditPanel.idInput,userEditPanel.passwordInput,userEditPanel.repasswordInput,userEditPanel.birthInput,userEditPanel.phoneInput,userEditPanel.emailInput,userEditPanel.addressInput,"Edit"   );
		
		
		//회원가입 아이디중복 버튼
		listener.setCheckingIdButtonListener(this.signupPanel.checkingIdButton, this.signupPanel.idInput);
		
		//회원가입 주소찾기 버튼
		listener.setFindingAddressButtonListener(this.signupPanel.findingAddressButton);
		
		
		
		
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




