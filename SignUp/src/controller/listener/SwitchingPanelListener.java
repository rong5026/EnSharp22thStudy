package controller.listener;

import java.awt.Container;
import java.awt.Desktop;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.sql.SQLException;
import java.util.regex.Pattern;

import javax.lang.model.element.NestingKind;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

import controller.MySQLConnection;
import model.UserVO;
import utility.ConstantNumber;
import view.LogoutPanel;
import view.MainFrame;
import view.MainPanel;

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
	public void setLoginButtonListener(JButton loginButton,JPanel switchingPanel,JTextField id,JPasswordField password,MainPanel mainPanel) {
		
		loginButton.addActionListener(new LoginButtonListener(switchingPanel, id, password,mainPanel));
		
	
	}
	
	//회원가입하기 버튼 리스너
	public void setSignUpButtonListener(JButton signUpButton,JPanel switchingPanel,JTextField nameInput,JTextField idInput,JPasswordField passwordInput,JPasswordField repasswordInput,JTextField birthInput,JTextField phoneInput,JTextField emailInput,JTextField addressInput ,String type  ) {
		
		signUpButton.addActionListener(new SignUpButtonListener( switchingPanel, nameInput, idInput, passwordInput, repasswordInput, birthInput, phoneInput, emailInput, addressInput,type));
	}
	
	//회원탈퇴 yes버튼 리스너
	public void setDeleteButtonListener( JButton yesDeleteButton, JPanel switchingPanel ,MainPanel mainPanel) {
		
		yesDeleteButton.addActionListener(new DeleteButtonListener(switchingPanel, mainPanel));
	}

	////주소찾기버튼  리스너
	public void setFindingAddressButtonListener(JButton findingAddressButton) {
		
		findingAddressButton.addActionListener(new FindingAddressButtonListener());
	}
	
	
	// 아이디중복버튼 리스너
	public void setCheckingIdButtonListener(JButton checkingIdButton,JTextField id) {
		
		checkingIdButton.addActionListener(new CheckingIdButtonListener(id));
	}
	
	//유저정보패널로 가는 버튼 리스너
	public void setChangingEditUserButtonListener(JButton editButton,JPanel switchingPanel,MainPanel mainPanel,JTextField nameInput,JTextField idInput,JPasswordField passwordInput,JPasswordField repasswordInput,JTextField birthInput,JTextField phoneInput,JTextField emailInput,JTextField addressInput) {
		
		editButton.addActionListener(new ChangingEditUserButtonListener(switchingPanel, mainPanel,nameInput, idInput, passwordInput, repasswordInput, birthInput, phoneInput, emailInput, addressInput) );
	}
	
	
	//유저정보패널로 가는 버튼 리스너
	class ChangingEditUserButtonListener implements ActionListener{

		private MainPanel mainJPanel;
		private JPanel userEditPanel;
		
		private JTextField nameInput;
		private JTextField idInput;
		private JPasswordField passwordInput;
		private JPasswordField repasswordInput;
		private JTextField birthInput;
		private JTextField phoneInput;
		private JTextField emailInput;
		private JTextField addressInput;
		
		public ChangingEditUserButtonListener(JPanel userEditPanel,MainPanel mainJPanel,JTextField nameInput,JTextField idInput,JPasswordField passwordInput,JPasswordField repasswordInput,JTextField birthInput,JTextField phoneInput,JTextField emailInput,JTextField addressInput) {
			
			this.userEditPanel = userEditPanel;
			this.mainJPanel = mainJPanel;
			
			this.nameInput = nameInput;
			this.idInput = idInput;
			this.passwordInput = passwordInput;
			this.repasswordInput = repasswordInput;
			this.birthInput = birthInput;
			this.phoneInput = phoneInput;
			this.emailInput = emailInput;
			this.addressInput =addressInput;
			
		}
		
		@Override
		public void actionPerformed(ActionEvent e) {
			
			try {
				
				UserVO loginedUserVO = MySQLConnection.getInstance().findUserData(mainJPanel);
				
				changePanel(userEditPanel); // 패널 전환
				
				// 사용자 입력칸에 사용자 정보 삽입
				nameInput.setText(loginedUserVO.getName());
				idInput.setText(loginedUserVO.getId());
				passwordInput.setText(loginedUserVO.getPassword());
				repasswordInput.setText(loginedUserVO.getPassword());
				birthInput.setText(loginedUserVO.getBirth());
				phoneInput.setText(loginedUserVO.getPhone());
				emailInput.setText(loginedUserVO.getEmail());
				addressInput.setText(loginedUserVO.getAddress());
				
				
			} catch (SQLException e1) {
				
				System.out.println("로그인된 유저의 정보를 받아오지 못했습니다.");
				e1.printStackTrace();
			}
			
		}
		
		
	}
	
	
	// ID중복 버튼 리스너
	class CheckingIdButtonListener implements ActionListener{

		private JTextField id;
		
		public CheckingIdButtonListener(JTextField id) {
			
			this.id =id;
			
		}
		
		@Override
		public void actionPerformed(ActionEvent e) {
			
			try {
				
				if(id.getText().equals("")) {
					
					JOptionPane.showMessageDialog(null, "ID를 입력해주세요.");
					
				}
				else if(MySQLConnection.getInstance().checkSameId(id.getText())) { // 중복일때
					
					JOptionPane.showMessageDialog(null, "이미 존재하는 ID입니다.");
					
					id.setText("");
					
				}
				else { // 중복이 아닐때
					
					int answer = JOptionPane.showConfirmDialog(null, "ID를 사용하시겠습니까?", "confirm",JOptionPane.YES_NO_OPTION );
					
					if(answer==JOptionPane.NO_OPTION){  //사용자가 yes를 눌렀을 경우
						
						id.setText("");
					} 
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
		private MainPanel mainPanel;
		
		public DeleteButtonListener(JPanel switchingPanel ,MainPanel mainPanel ) {
			
			this.switchingPanel = switchingPanel;
			this.mainPanel = mainPanel;
			
		}

		@Override
		public void actionPerformed(ActionEvent e) {
			
		
			MySQLConnection.getInstance().deleteUserData(mainPanel.loginedId);
				
			
			changePanel(switchingPanel); // 패널전환
			
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
		private JTextField addressInput;
		private Pattern pattern;
		private String type;
		
		
		public SignUpButtonListener(JPanel switchingPanel,JTextField nameInput,JTextField idInput,JPasswordField passwordInput,JPasswordField repasswordInput,JTextField birthInput,JTextField phoneInput,JTextField emailInput,JTextField addressInput,String type ) {
			
			this.switchingPanel = switchingPanel;
			this.nameInput = nameInput;
			this.idInput = idInput;
			this.passwordInput = passwordInput;
			this.repasswordInput = repasswordInput;
			this.birthInput = birthInput;
			this.phoneInput = phoneInput;
			this.emailInput = emailInput;
			this.addressInput = addressInput;
			this.type = type;
			
		}
		
		
		
		@Override
		public void actionPerformed(ActionEvent e) {
			
			//한개라도 입력이 안되어있다면 팝업창 발생
			
			String name = nameInput.getText();
			String id = idInput.getText();
			String password = String.valueOf(passwordInput.getPassword());
			String rePassword = String.valueOf(repasswordInput.getPassword());
			String birth = birthInput.getText();
			String phone = phoneInput.getText();
			String email = emailInput.getText();
			String address = addressInput.getText();
			
			
			try {
				
				if(name.equals("")) {
					
					JOptionPane.showMessageDialog(null, "이름을 입력해주세요.");
				}
				else if(id.equals("")) {
					
					JOptionPane.showMessageDialog(null, "ID를 입력해주세요.");
				}
				else if(password.equals("")) {
					
					JOptionPane.showMessageDialog(null, "Password를 입력해주세요.");
				}
				else if(rePassword.equals("")) {
					
					JOptionPane.showMessageDialog(null, "RePassword를 입력해주세요.");
				}
				else if(birth.equals("")) {
					
					JOptionPane.showMessageDialog(null, "Birth를 입력해주세요.");
				}
				else if(phone.equals("")) {
					
					JOptionPane.showMessageDialog(null, "PhoneNumber를 입력해주세요.");
				}
				else if(email.equals("")) {
					
					JOptionPane.showMessageDialog(null, "Email를 입력해주세요.");
				}
				else if(address.equals("")) {
					
					JOptionPane.showMessageDialog(null, "Address를 입력해주세요.");
				}
				
				
				else if(!checkValidInput(name,ConstantNumber.NAME_EXCEPTION)) {
					
					showPopUp("이름");
				}
				else if(!checkValidInput(id,ConstantNumber.ID_EXCEPTION)) {
					
					showPopUp("ID");
				}
				else if(!checkValidInput(password,ConstantNumber.PASSWORD_EXCEPTION)) {
	
					showPopUp("Password");
				}
				else if(!checkValidInput(rePassword,ConstantNumber.PASSWORD_EXCEPTION) || !rePassword.equals(password)) {
	
					JOptionPane.showMessageDialog(null, "Password와 일치하지 않습니다.");
				}
				else if(!checkValidInput(birth,ConstantNumber.BIRTH_EXCEPTION)) {
	
					showPopUp("Birth");
				}
				else if(!checkValidInput(phone,ConstantNumber.PHONE_EXCEPTION)) {

					showPopUp("Phone");
	
				}
				else if(!checkValidInput(email,ConstantNumber.EMAIL_EXCEPTION)) {
					
					showPopUp("Email");
				}
				
				else { // 값이 다 들어가있다면 회원가입
					
					JOptionPane.showConfirmDialog(null,nameInput.getText()+ "님 환영합니다.", "confirm",JOptionPane.DEFAULT_OPTION );
				
					MySQLConnection.getInstance().insertUserData(nameInput.getText(), idInput.getText(), passwordInput.getPassword(), birthInput.getText(), phoneInput.getText(), emailInput.getText(), addressInput.getText());
					
					changePanel(switchingPanel);
					
					
					if(type.equals("Signup")) {

						nameInput.setText("");
						idInput.setText("");
						passwordInput.setText("");
						repasswordInput.setText("");
						birthInput.setText("");
						phoneInput.setText("");
						emailInput.setText("");
						addressInput.setText("");
					}
	
					
				}
				
			} catch (SQLException e1) {
		
				e1.printStackTrace();
				
			}
			
		}
		
		//정규식 적용해서 올바른 입력인지 확인
		private boolean checkValidInput(String text,String exceptionText ) {
			
			pattern = Pattern.compile(exceptionText);
			
			return pattern.matcher(text).matches();
		}
		
		private void showPopUp(String text) {
			JOptionPane.showMessageDialog(null, "올바른  "+text+"을(를)  입력해주세요.");
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
		private MainPanel mainPanel;
		
		public LoginButtonListener(JPanel switchingPanel,JTextField id,JPasswordField password,MainPanel mainPanel) {
			
			this.switchingPanel = switchingPanel;
			this.id = id;
			this.password = password;
			this.mainPanel = mainPanel;
			
		}
	
		 @Override
         public void actionPerformed(ActionEvent e) {
             
			 
         	try {
         		
				if(MySQLConnection.getInstance().getLoginData(id.getText(), password.getPassword(),mainPanel)) {
				
					
					mainPanel.loginedId = id.getText(); // 현재 로그인된 유저의 id를 넣음
					
					changePanel(switchingPanel); // 패널변경
					
					
				}
				else {
					
					if(id.getText().equals("")) {
						
						JOptionPane.showConfirmDialog(null,"ID를 입력해주세요.", "Fail",JOptionPane.DEFAULT_OPTION );
					}
					else if(String.valueOf(password.getPassword()).equals("") ){
						
						JOptionPane.showConfirmDialog(null,"Password를 입력해주세요.", "Fail",JOptionPane.DEFAULT_OPTION );
					}
					else {
						
						JOptionPane.showConfirmDialog(null,"로그인 실패하였습니다.", "Fail",JOptionPane.DEFAULT_OPTION );
					}
					
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



