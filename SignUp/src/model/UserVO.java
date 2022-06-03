package model;

public class UserVO {

	private String name;
	private String id;
	private String password;
	private String birth;
	private String email;
	private String phone;
	private String address;
	
	
	public UserVO(String name,String id, String password, String birth, String email, String phone,String address) {
		
		this.name = name;
		this.id = id;
		this.password = password;
		this.birth = birth;
		this.email = email;
		this.phone = phone;
		this.address = address;
		
	}
	
	public String getName(){
		
		return name;
    }
	public String getId(){
		
		return id;
    }
	public String getPassword(){
	
		return password;
	}
	public String getBirth(){
	
		return birth;
	}
	public String getEmail(){
	
		return email;
	}
	public String getPhone(){
	
		return phone;
	}
	public String getAddress(){
	
		return address;
	}
	
	 
}
