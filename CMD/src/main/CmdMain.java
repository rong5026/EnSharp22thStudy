package main;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.InetAddress;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
import java.nio.file.attribute.BasicFileAttributes;
import java.nio.file.attribute.FileTime;
import java.sql.Date;
import java.text.SimpleDateFormat;
import java.util.Arrays;

import controller.CmdStart;
import utility.ConstantsNumber;

public class CmdMain {

	public static void main(String[] args) throws IOException {

		CmdStart cmd = new CmdStart();
		cmd.start();
		
	}
}

