package utility;

public class ConstantNumber {
	
	// 아이콘 
	public final static String SIGNUP_ICON_IMAGE  = "./src/image/LegoIcon.png";
	
	// mainframe 이미지
	public final static String MAIN_FRAME_IMAGE  = "./src/image/MainFrame.jpg";
	
	public final static String MAIN_LEGO_IMAGE  = "./src/image/MainLegoIcon.png";

	public final static String USETEDIT_PANEL_IMAGE  = "./src/image/UserEditPanelImage.jpg";
	
	public final static String Logined_PANEL_IMAGE  = "./src/image/LoginedPanelImage.jpg";
	
	public final static String SIGNUP_PANEL_IMAGE  = "./src/image/SignUpPanelImage.jpg";


	//guide 라벨 문구
	public final static String NAME_GUIDE ="한글,영어 1~10자리 범위내에서 입력해주세요.";
	
	public final static String ID_GUIDE ="4~16 영어,숫자 범위내에서 입력해주세요";
	
	public final static String PASSWORD_GUIDE ="4~16 영어,숫자,특수기호(~!@#) 범위내에서 입력해주세요.";
	
	public final static String REPASSWORD_GUIDE ="비밀번호를 다시 입력해주세요.";
	
	public final static String BIRTH_GUIDE ="ex)000302";
	
	public final static String EMAIL_GUIDE ="영어,숫자1~16 + @ + 영어,숫자1~16 + . + 영어2~3";
	
	public final static String PHONE_GUIDE ="ex)010-8791-4859 , 011-530-4859";
	
	public final static String ADDRESS_GUIDE ="주소를 입력해주세요.";
	
	//정규식
	
	public final static String NAME_EXCEPTION = "^([a-zA-Z가-힣]{1,10})$"; 
	
	public final static String ID_EXCEPTION = "^([a-zA-Z0-9]{4,16})$"; 
	
	public final static String PASSWORD_EXCEPTION = "^([a-zA-Z0-9~!@#]{4,16})$"; 
	
	public final static String BIRTH_EXCEPTION = "^([0-9]{6})$"; 
	
	public final static String EMAIL_EXCEPTION = "^([a-zA-Z0-9]+@[a-zA-Z0-9]+\\.[a-z]{2,3}+)$"; 
	
	public final static String PHONE_EXCEPTION = "^(01(?:0|1|[6-9])-(?:\\d{3}|\\d{4})-\\d{4})$"; 
	

	
	
	
	
	
	
	
	// MySQL
	public final static String USERNAME = "root";
	
	public final static String PASSWORD = "0000";
	
	public final static String JDBCDRIVER = "com.mysql.cj.jdbc.Driver";
	
	public final static String URL = "jdbc:mysql://localhost:3306/login_user_data";
	
	
	//login
	public final static boolean IS_LOGIN_SUCCESS = true;
	
	public final static boolean IS_LOGIN_FAIL = false;
	
	//check Id
	
	public final static boolean IS_SAME_ID = true;
	
	public final static boolean IS_NOT_SAME_ID = false;
	
	
	

}
