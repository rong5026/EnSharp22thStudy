package controller;

import java.sql.*;

import utility.ConstantNumber;

public class MySQLConnection {
	
	private static MySQLConnection mySQLConnection =null;

	private Connection connection; //DB 커넥션 연결 객체
	private Statement statement;
   
	public static MySQLConnection getInstance() { // 싱글톤 적용
		
		if(mySQLConnection == null) {
			
			mySQLConnection = new MySQLConnection();
			
		}
		
		return mySQLConnection;
	}
	
    private MySQLConnection() {
    	
        try {
           
            Class.forName(ConstantNumber.JDBCDRIVER);
            
            connection = DriverManager.getConnection(ConstantNumber.URL, ConstantNumber.USERNAME, ConstantNumber.PASSWORD);
            
            statement = connection.createStatement();
           
        } catch (Exception e) {
        	
            System.out.println("드라이버 로딩 실패 ");
            
        }
        
    }
    
    // 로그인 확인 
    public boolean getLoginData(String id, char[] password) throws SQLException { 
    	
    	String sql = "SELECT * FROM user_data";
    	
    	String inputPassword = new String(password); // 문자 배열 -> 문자열
    	
    	
    	ResultSet resultSet = statement.executeQuery(sql);
    			
    	while(resultSet.next()) {
    		
    		String userId = resultSet.getString("id");
    		
    		String userPassword = resultSet.getString("password");
    	
    		if(userId.equals(id) && userPassword.equals(inputPassword) ) 
    			return ConstantNumber.IS_LOGIN_SUCCESS;
    		
    	}
    	
		return ConstantNumber.IS_LOGIN_FAIL;
    	
    }
    
    
    
    
  
    
    
    
}
