package controller;

import java.sql.*;
import java.util.BitSet;

import javax.swing.JPanel;

import model.UserVO;
import utility.ConstantNumber;
import view.MainPanel;

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
    public boolean getLoginData(String id, char[] password,MainPanel mainPanel) throws SQLException { 
    	
    	String sql = "SELECT * FROM user_data";
    	
    	String inputPassword = new String(password); // 문자 배열 -> 문자열
    	
    	ResultSet resultSet = statement.executeQuery(sql);
    			

		
    	while(resultSet.next()) {
    		
    		String userId = resultSet.getString("id");
    		
    		String userPassword = resultSet.getString("password");
    	
    		
    		if(userId.equals(id)  && userPassword.equals(inputPassword)  && id.equals("")==false ) {
    			
    			mainPanel.loginedId = userId;
    			
    			return ConstantNumber.IS_LOGIN_SUCCESS;
    		}
    		
    	}
    	
		return ConstantNumber.IS_LOGIN_FAIL;
    	
    }
    
    //회원가입
    public void insertUserData(String name, String id, char[] password, String birth, String phone, String email, String address ) throws SQLException {
    	
    	String sql = "INSERT INTO user_data VALUES (?,?,?,?,?,?,?)";
    	
    	PreparedStatement statement = connection.prepareStatement(sql);
    	
    	if(checkSameId(id)) { // 중복이 있다면 수정이므로 삭제 후 다시 생성
    		deleteUserData(id);
    	}
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
    public void deleteUserData(String loginedId)   {
    	
    	String sql = "DELETE FROM user_data WHERE id=?";
    	
    	PreparedStatement prepareStatement;
		try {
			
			prepareStatement = connection.prepareStatement(sql);
			
			prepareStatement.setString(1, loginedId);
	    	
	    	prepareStatement.execute();
	    	
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
    	
    	
    	
    }
    
    
    //아이디 중복체크
    public boolean checkSameId(String id) throws SQLException {
    	
    	String sql = "SELECT * FROM user_data";
    
    	ResultSet resultSet = statement.executeQuery(sql);
    		
    	while(resultSet.next()) {
    		
    		String userId = resultSet.getString("id");
    		
    		if(id.equals(userId))
    			return ConstantNumber.IS_SAME_ID;
  
    	}
    	
    	return ConstantNumber.IS_NOT_SAME_ID;
    	
    }
    
    
    //id가 같은 유저의 정보를 반환
    public UserVO findUserData(MainPanel mainJPanel) throws SQLException {
    	
    	UserVO userVO;
    	
    	String sql = "SELECT * FROM user_data";
    	
    	ResultSet resultSet = statement.executeQuery(sql);
    			
    	while(resultSet.next()) {
    		
    		String id = resultSet.getString("id");
    		
    		if( mainJPanel.loginedId.equals(id)) {
    			
    			String name = resultSet.getString("name");
    			String password = resultSet.getString("password");
    			String birth = resultSet.getString("birth");
    			String email = resultSet.getString("email");
    			String phone = resultSet.getString("phone");
    			String address = resultSet.getString("address");
    			
    			userVO = new UserVO(name, id, password, birth, email, phone, address);
    			
    			return userVO;
    		}
    	}  	
    	
    	return null;
		
    }
    
    
    
    
  
    
    
    
}
