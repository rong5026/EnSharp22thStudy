import java.awt.*;
import javax.swing.*;

public class test {

	public static void main(String[] args) {
		
		JFrame f = new JFrame("Button");
		f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		f.setSize(320,240);
		f.setLayout(new FlowLayout());
		JButton button1 = new JButton();
		f.add(button1);
		f.add(new JButton("Ȯ��"));
		button1.setText("���̺�Ʈ");
		f.setVisible(true);
		
		
		
		
	}

}
