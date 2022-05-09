package Model;

import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.text.SimpleDateFormat;


public class historyDAO {

	 Connection connection = null;
	
	public historyDAO() {
		 try {
			Class.forName("com.mysql.jdbc.Driver");
			
			connection= DriverManager.getConnection(
                    "jdbc:mysql://localhost:3306/hongyeonghwan_imagesearch?serverTimezone=UTC", // DB URL
                    "root", "0000");  // USER_NAME과 PASSWORD
			
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
	
	public void InsertSearchHistory(String SearchingText) { // 검색기록 데이터베이스 저장
		
		String sql = "INSERT INTO history VALUES (?,?)";
		PreparedStatement pstmt = null;
		
		try {
			SimpleDateFormat dateFormat = new SimpleDateFormat ( "yyyy-MM-dd HH:mm:ss");
			long time = System.currentTimeMillis();
			String currentTime = dateFormat.format(time);
			
			pstmt = connection.prepareStatement(sql);
			
			pstmt.setString(1, SearchingText);
			pstmt.setString(2,currentTime);
			pstmt.executeUpdate();
			
			pstmt.close();
			connection.close();
			
		} catch (SQLException e) {
			e.printStackTrace();
		}
		
	}
}
