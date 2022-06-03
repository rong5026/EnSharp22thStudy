package controller.listener;

import java.awt.Container;
import java.awt.Desktop;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.sql.SQLException;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

import controller.MySQLConnection;
import view.LogoutPanel;
import view.MainFrame;

public class SwitchingPanelListener {

	
	private Container container;
	
	
	
	public SwitchingPanelListener(Container container) {
		
		this.container = container;
	}
	
	
	
	
	// 패널 변경
	public void changePanel(JPanel switchingPanel) { 
		
		container.removeAll();
		
		container.add(switchingPanel);
		
		container.repaint();
		
		container.revalidate();
		
	}
	
	
	//버튼 누르면 mainFrame 패널 변경
	public void changeMainFramePanel(JButton button,JPanel switchingPanel) {
		
		button.addActionListener(new SwitchingMainPage(switchingPanel));
		
	}
	
	//로그인 버튼 리스너
	public void setLoginButtonListener(JButton loginButton,JPanel switchingPanel,JTextField id,JPasswordField password,String loginedId) {
		
		loginButton.addActionListener(new LoginButtonListener(switchingPanel, id, password,loginedId));
		
	
	}
	
	//회원가입하기 버튼 리스너
	public void setSignUpButtonListener(JButton signUpButton,JPanel switchingPanel,JTextField nameInput,JTextField idInput,JPasswordField passwordInput,JPasswordField repasswordInput,JTextField birthInput,JTextField phoneInput,JTextField emailInput,JTextField addressInput   ) {
		
		signUpButton.addActionListener(new SignUpButtonListener( switchingPanel, nameInput, idInput, passwordInput, repasswordInput, birthInput, phoneInput, emailInput, addressInput));
	}
	
	//회원탈퇴 yes버튼 리스너
	public void setDeleteButtonListener( JButton yesDeleteButton, JPanel switchingPanel ,String id) {
		
		yesDeleteButton.addActionListener(new DeleteButtonListener(switchingPanel, id));
	}

	////주소찾기버튼  리스너
	public void setFindingAddressButtonListener(JButton findingAddressButton) {
		
		findingAddressButton.addActionListener(new FindingAddressButtonListener());
	}
	
	
	// 아이디중복버튼 리스너
	public void setCheckingIdButtonListener(JButton checkingIdButton,JTextField id) {
		
		checkingIdButton.addActionListener(new CheckingIdButtonListener(id));
	}
	
	
	class CheckingIdButtonListener implements ActionListener{

		private JTextField id;
		
		public CheckingIdButtonListener(JTextField id) {
			
			this.id =id;
			
		}
		
		@Override
		public void actionPerformed(ActionEvent e) {
			
			try {
				
				System.out.println("입력된 아이디"+id.getText());
				if(MySQLConnection.getInstance().checkSameId(id.getText())) { // 중복일때
					
					System.out.println("중복이다 이놈아");
				}
				else { // 중복이 아닐때
					System.out.println("중복 아니다");
				}
				
			} catch (SQLException e1) {
				
				
				e1.printStackTrace();
			}
			
			
		}
		
		
	}
	
	
	//주소찾기버튼 리스너
	class FindingAddressButtonListener implements ActionListener{

		@Override
		public void actionPerformed(ActionEvent e) {
			String url = "https://www.juso.go.kr/openIndexPage.do";
			try {
				
				Desktop.getDesktop().browse(new URI(url));
				
			} catch (IOException | URISyntaxException e1) {
				
				System.out.println("웹페이지 불러오기 실패");
				e1.printStackTrace();
			}
			
			
		}
	}
	
	
	// 회원탈퇴 Yes버튼 리스너
	class DeleteButtonListener implements ActionListener{
	
		private JPanel switchingPanel;
		private String id;
		
		public DeleteButtonListener(JPanel switchingPanel ,String id ) {
			
			this.switchingPanel = switchingPanel;
			this.id = id;
			
		}

		@Override
		public void actionPerformed(ActionEvent e) {
			
			try {
				
				MySQLConnection.getInstance().deleteUserData(id);
				
			} catch (SQLException e1) {
				
				e1.printStackTrace();
			}
			changePanel(switchingPanel);
			
		}
	}
	
	// 회원가입버튼 리스너
	class SignUpButtonListener implements ActionListener{
		
	
		private JPanel switchingPanel;
		private JTextField nameInput;
		private JTextField idInput;
		private JPasswordField passwordInput;
		private JPasswordField repasswordInput;
		private JTextField birthInput;
		private JTextField phoneInput;
		private JTextField emailInput;
		private JTextField addressInput ;
		
		
		public SignUpButtonListener(JPanel switchingPanel,JTextField nameInput,JTextField idInput,JPasswordField passwordInput,JPasswordField repasswordInput,JTextField birthInput,JTextField phoneInput,JTextField emailInput,JTextField addressInput ) {
			
			this.switchingPanel = switchingPanel;
			this.nameInput = nameInput;
			this.idInput = idInput;
			this.passwordInput = passwordInput;
			this.repasswordInput = repasswordInput;
			this.birthInput = birthInput;
			this.phoneInput = phoneInput;
			this.emailInput = emailInput;
			this.addressInput = addressInput;
			
		}
		
		@Override
		public void actionPerformed(ActionEvent e) {
			
			//한개라도 입력이 안되어있다면 팝업창 발생
			
			// 모든 항목이 입력이 되어있다면
			try {
				
				MySQLConnection.getInstance().insertUserData(nameInput.getText(), idInput.getText(), passwordInput.getPassword(), birthInput.getText(), phoneInput.getText(), emailInput.getText(), addressInput.getText());
				changePanel(switchingPanel);
				
			} catch (SQLException e1) {
		
				e1.printStackTrace();
				
			}
			
		}
		
		
	}
	

	// 패널 변경하는 리스너
	class SwitchingMainPage implements ActionListener{

		private JPanel switchingPanel;
				
		public SwitchingMainPage(JPanel switchingPanel) {
		
			this.switchingPanel  = switchingPanel;
		}

		@Override
		public void actionPerformed(ActionEvent e) {

			changePanel(switchingPanel);
		}	
	}
	
	//로그인 버튼 리스너
	class LoginButtonListener implements ActionListener{
		
		private JPanel switchingPanel;
		private JTextField id;
		private JPasswordField password;
		private String loginedId;
		public LoginButtonListener(JPanel switchingPanel,JTextField id,JPasswordField password,String loginedId) {
			
			this.switchingPanel = switchingPanel;
			this.id = id;
			this.password = password;
			this.loginedId = loginedId;
			
		}
	
		 @Override
         public void actionPerformed(ActionEvent e) {
             
			 
         	try {
         		
					if(MySQLConnection.getInstance().getLoginData(id.getText(), password.getPassword(),loginedId)) {
				
						changePanel(switchingPanel); // 패널변경
					}
						
				} catch (SQLException e1) {
					
					System.out.println("로그인 하는 과정에서 오류가 생겼습니다");
					
					e1.printStackTrace();
				}
         	
         	id.setText("");
			password.setText("");
         }
	}
		

	
	
}




