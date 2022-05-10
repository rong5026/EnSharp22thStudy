package Model;

import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;

import com.mysql.cj.protocol.Resultset;
import Model.historyDTO;;

public class HistoryDAO {

	 Connection connection = null;
	
	public HistoryDAO() {
		 try {
			Class.forName("com.mysql.jdbc.Driver");
			
			connection= DriverManager.getConnection(
                    "jdbc:mysql://localhost:3306/hongyeonghwan_imagesearch?serverTimezone=UTC", // DB URL
                    "root", "0000");  // USER_NAME�� PASSWORD
			
			System.out.println("Success");
			
		 }
		 catch (SQLException ex) {
			
			System.out.println("SQLException" + ex);
			ex.printStackTrace();
		}
		catch(Exception ex){ 
			 System.out.println("Exception:" + ex);
	            ex.printStackTrace();
	      
	    }
		
	}
	
	public void InsertSearchHistory(String SearchingText) { // �˻���� �����ͺ��̽� ����
		
		String sql = "INSERT INTO history VALUES (?)";
		PreparedStatement pstmt = null;
		
		try {
			SimpleDateFormat dateFormat = new SimpleDateFormat ( "yyyy-MM-dd HH:mm:ss");
			long time = System.currentTimeMillis();
			String wordString = SearchingText+dateFormat.format(time);
			pstmt = connection.prepareStatement(sql);	
			pstmt.setString(1, wordString);
			
			pstmt.executeUpdate();
			
			pstmt.close();
			connection.close();
			
		} catch (SQLException e) {
			e.printStackTrace();
		}
		
	}
	public ArrayList<historyDTO> SelectSearchHistory(ArrayList<historyDTO> wordlList) {
		String sql = "SELECT * FROM history";
		PreparedStatement pstmt = null;
		ResultSet resultset = null;
		
		ArrayList<historyDTO> list = new ArrayList<historyDTO>();
		historyDTO historyDTO = new 
		
		try {
			pstmt = connection.prepareStatement(sql);
			resultset = pstmt.executeQuery();
			
			
			while(resultset.next()) {
				
			}
		
		 
		} catch (SQLException e) {
			e.printStackTrace();
		}
		return list;
	}
}
