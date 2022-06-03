package controller.listener;

import java.awt.Container;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

import controller.MySQLConnection;
import view.LogoutPanel;

public class SwitchingPanelListener {

	
	private Container container;
	private JPanel switchingPanel;
	
	
	private static SwitchingPanelListener listener =null;


	public static SwitchingPanelListener getInstance() { // 싱글톤 적용
		
		if(listener == null) {
			
			listener = new SwitchingPanelListener();
			
		}
		
		return listener;
	}
	
	
	private SwitchingPanelListener(Container container) {
		
		
		this.container = container;
		
	}
	

	
	//버튼 누르면 mainFrame 패널 변경
	public void changeMainFramePanel(JButton button,JPanel switchingPanel) {
		
		button.addActionListener(new SwitchingMainPage(switchingPanel));
		
	}
	
	//로그인버튼 누르면 확인 후 로그인화면으로 이동
	public void setLoginButtonListener(JButton button,JPanel switchingPanel,String id,char[] password) {
		
		button.addActionListener(new ActionListener() {
 
            @Override
            public void actionPerformed(ActionEvent e) {
                
            	try {
            		
					if(MySQLConnection.getInstance().getLoginData(id, password)) {
						
						changePanel(switchingPanel); // 패널변경
					}
						
				} catch (SQLException e1) {
					
					System.out.println("로그인 하는 과정에서 오류가 생겼습니다");
					
					e1.printStackTrace();
				}
            }
        });
	}
	
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
		

	
	
}




