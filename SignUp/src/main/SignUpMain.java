package main;

import java.util.Scanner;
import java.util.regex.Pattern;

import controller.SignUpStart;
import utility.ConstantNumber;

public class SignUpMain {

	
	public static void main(String[] args) {
		
		//SignUpStart signUp = new SignUpStart();
		//signUp.start();
		Scanner sc = new Scanner(System.in);
		
		while(true) {
			
			String name = sc.next();
			
			Pattern pattern = Pattern.compile(ConstantNumber.ID_EXCEPTION);
			
			System.out.println(pattern.matcher(name).matches());
			
		}
		
		
	

	}

}
