package main;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.InetAddress;

import controller.CmdStart;

public class CmdMain {

	public static void main(String[] args) throws IOException {

		CmdStart cmd = new CmdStart();
		cmd.start();
	}
}

