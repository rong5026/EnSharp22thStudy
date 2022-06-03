package controller;

import java.sql.*;

import utility.ConstantNumber;

public class MySQLConnection {

	private Connection connection; //DB 커넥션 연결 객체
	private Statement statement;
   
    
    public MySQLConnection() {
    	
        try {
           
            Class.forName(ConstantNumber.JDBCDRIVER);
            
            connection = DriverManager.getConnection(ConstantNumber.URL, ConstantNumber.USERNAME, ConstantNumber.PASSWORD);
            
            statement = connection.createStatement();
           
        } catch (Exception e) {
        	
            System.out.println("드라이버 로딩 실패 ");
            
        }
        
    }
    
    // 로그인 확인 
    public boolean getLoginData(String id, String password) throws SQLException { 
    	
    	String sql = "SELECT * FROM user_data";
    	
    	ResultSet resultSet = statement.executeQuery(sql);
    			
    	while(resultSet.next()) {
    		
    		String userId = resultSet.getString("id");
    		
    		String userPassword = resultSet.getString("password");
    		
    		if(userId == id && password == password) 
    			return true;
    		
    	}
    	
		return false;
    	
    }
    
    
    
    
  
    
    
    
}
