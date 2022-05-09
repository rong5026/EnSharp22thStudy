package Model;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class histortDAO {

	 Connection connection = null;
	
	public histortDAO() {
		 try {
			Class.forName("com.mysql.jdbc.Driver");
			
			connection= DriverManager.getConnection(
                    "jdbc:mysql://localhost:3306/hongyeonghwan_imagesearch?serverTimezone=UTC", // DB URL
                    "root", "0000");  // USER_NAME°ú PASSWORD
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
}
