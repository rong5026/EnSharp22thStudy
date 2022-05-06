using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace LibraryMySQL
{

    internal class Login
    {

        UserModeUI userModeUI;
        ValidInput validInput;
        BookDAO mySQlData;
        UserDAO userDAO;
    
        private string id;
        private string passWord;
        
        
        public Login( UserModeUI userModeUI, ValidInput validInput)
        {                        
            this.validInput = validInput;          
            this.userModeUI = userModeUI;
            mySQlData = BookDAO.Instance();
            userDAO = new UserDAO();
        }
        public int LoginUser(string type)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
           
            userModeUI.PrintLogin(); // 위에 로그인 화면
                                                                        
            id = validInput.EnterInput(52, 34, ErrorMessage.ID, RegularExpression.ID );
            // id 입력
            if (id == Constants.INPUT_BACK)                      
                return Constants.BACK;
            
            passWord = validInput.EnterLoginPassWord(52, 35); 
            //password 입력
            if (passWord == Constants.INPUT_BACK)
                return Constants.BACK;
           
            if (type == "User")
            {
                if (CheckUser(id, passWord) == Constants.LOGIN_SUCCESS) // 유저 로그인
                {
                    Console.Clear();               
                    LibraryStart.loginedUser = id;   // 현재 로그인된 유저id
                    mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "유저", id, "로그인");
                    return Constants.USER_MODE;            
                }
                else // 로그인 실패
                    return LoginUser(type);
            }
            else
            {
                if(CheckAdmin(id,passWord) == Constants.LOGIN_SUCCESS) // 관리자 로그인
                {
                    Console.Clear();
                    mySQlData.InsertLogData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "관리자", "관리자", "로그인");
                    return Constants.ADMIN_MODE;
                }
                return LoginUser(type);
            }

            
            return Constants.BACK;

        }
        private int CheckUser(string id, string passWord)//유저 로그인확인
        {
            List<UserDTO> userList = new List<UserDTO>();

            userDAO.GetUserList(userList); // 회원정보를 다가져옴

            for (int index = 0; index < userList.Count; index++)
            {
                if (userList[index].Id == id && userList[index].Password == passWord)
                    return Constants.LOGIN_SUCCESS;
            }
            return Constants.LOGIN_FAIL;
        }
        private int CheckAdmin(string id, string passWord) // 관리자 로그인확인
        {
            List<UserDTO> adminList = new List<UserDTO>();

            userDAO.GetAdminList(adminList); // 회원정보를 다가져옴

            for (int index = 0; index < adminList.Count; index++)
            {
                if (adminList[index].Id == id && adminList[index].Password == passWord)
                    return Constants.LOGIN_SUCCESS;
            }
            return Constants.LOGIN_FAIL;
        }

    }
}
