package controller;

import java.sql.*;
import java.util.BitSet;

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
        	
            System.out.println("MySql 로딩 실패 ");
            
        }
        
    }
    
    // 로그인 확인 
    public boolean getLoginData(String id, char[] password,String loginedId) throws SQLException { 
    	
    	String sql = "SELECT * FROM user_data";
    	
    	String inputPassword = new String(password); // 문자 배열 -> 문자열
    	
    	ResultSet resultSet = statement.executeQuery(sql);
    			
    	while(resultSet.next()) {
    		
    		String userId = resultSet.getString("id");
    		
    		String userPassword = resultSet.getString("password");
    	
    		if(userId.equals(id) && userPassword.equals(inputPassword) ) {
    			
    			loginedId = userId;
    			
    			return ConstantNumber.IS_LOGIN_SUCCESS;
    		}
    		
    	}
    	
		return ConstantNumber.IS_LOGIN_FAIL;
    	
    }
    
    //회원가입
    public void insertUserData(String name, String id, char[] password, String birth, String phone, String email, String address ) throws SQLException {
    	
    	String sql = "INSERT INTO user_data VALUES (?,?,?,?,?,?,?)";
    	
    	PreparedStatement statement = connection.prepareStatement(sql);
    	
    	String inputPassword = new String(password); // 문자 배열 -> 문자열
    	
    	statement.setString(1, name);
    	statement.setString(2, id);
    	statement.setString(3, inputPassword);
    	statement.setString(4, birth);
    	statement.setString(5, phone);
    	statement.setString(6, email);
    	statement.setString(7, address);
    	
    	if(statement.executeUpdate() == 0) {
    		
    		System.out.println("회원가입 실패");
    	}
    	
    }
    
    //회원탈퇴
    public void deleteUserData(String loginedId) throws SQLException {
    	
    	String sql = "DELETE FROM user_data WHERE id=?";
    	
    	PreparedStatement statement = connection.prepareStatement(sql);
    	
    	statement.setString(1, loginedId);
    	
    	statement.executeUpdate(sql);
    	
    	
    }
    
    
    
    
  
    
    
    
}
