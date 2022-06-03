package controller.listener;

import java.awt.Container;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class SwitchingPanelListener {

	
	private Container container;
	private JPanel switchingPanel;
	
	
	public SwitchingPanelListener() {
		
		
		
		
	}
	
	public void changePanel(JButton button,  Container container,JPanel switchingPanel) {
		
		button.addActionListener(new SwitchingMainPage(container,switchingPanel));
		
		
	}
	
	
	
	

}


class SwitchingMainPage implements ActionListener{

	private Container container;
	private JPanel switchingPanel;
	
	public SwitchingMainPage(Container container,JPanel switchingPanel) {
		
		this.container = container;
		this.switchingPanel  = switchingPanel;
		
	}
	
	
	@Override
	public void actionPerformed(ActionEvent e) {

		mainFrame.setContentPane(switchingPanel);
		
	}
	
	
	
}