package controller.Command;

import view.HelpText;

public class Help {

	private HelpText helpText;
	
	
	public Help() {
		
		helpText = new HelpText();
	}
	public void startHelp() { // 인자잡아서 그냥 help인지 아니면 뒤에 단어가 붙는지
		
		helpText.showHelp();
		
		
	}
	

	
	
}
