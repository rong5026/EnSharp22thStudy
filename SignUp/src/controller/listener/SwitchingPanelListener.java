package controller.listener;

import java.awt.Container;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.SQLException;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

import controller.MySQLConnection;
import view.LogoutPanel;

public class SwitchingPanelListener {

	
	private Container container;
	private JPanel switchingPanel;
	
	
	public SwitchingPanelListener(Container container) {
		
		
		this.container = container;
		
	}
	
	
	//버튼 누르면 mainFrame 패널 변경
	public void changeMainFramePanel(JButton button,JPanel switchingPanel) {
		
		button.addActionListener(new SwitchingMainPage(switchingPanel));
		
	}
	
	//로그인 버튼 리스너
	public void setLoginButtonListener(JButton loginButton,JPanel switchingPanel,JTextField id,JPasswordField password) {
		
		loginButton.addActionListener(new LoginButtonListener(switchingPanel, id, password));
	
	}
	
	
	public void setSignUpButtonListener(JButton signUpButton,JPanel switchingPanel,JTextField nameInput,JTextField idInput,JPasswordField passwordInput,JPasswordField repasswordInput,JTextField birthInput,JTextField phoneInput,JTextField emailInput,JTextField addressInput   ) {
		
		
	}
	
	// 회원가입버튼 리스너
	
	
	// 패널 변경
	public void changePanel(JPanel switchingPanel) { 
		
		container.removeAll();
		
		container.add(switchingPanel);
		
		container.repaint();
		
		container.revalidate();
	}
	
	// 패널 변경하는 리스너
	class SwitchingMainPage implements ActionListener{

		//private Container container;
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
		
		
		public LoginButtonListener(JPanel switchingPanel,JTextField id,JPasswordField password) {
			
			this.switchingPanel = switchingPanel;
			this.id = id;
			this.password = password;
			
		}
		
		
		 @Override
         public void actionPerformed(ActionEvent e) {
             
         	try {
         		
					if(MySQLConnection.getInstance().getLoginData(id.getText(), password.getPassword())) {
				
						changePanel(switchingPanel); // 패널변경
					}
						
				} catch (SQLException e1) {
					
					System.out.println("로그인 하는 과정에서 오류가 생겼습니다");
					
					e1.printStackTrace();
				}
         }
		
	}
		

	
	
}




