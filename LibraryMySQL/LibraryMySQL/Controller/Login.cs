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
        MySQlData mySQlData;
        UserMenu userMenu;

        private string id;
        private string passWord;
        public Login( UserModeUI userModeUI, ValidInput validInput)
        {
                  
            userMenu = new UserMenu();
            this.validInput = validInput;
            mySQlData= MySQlData.Instance();
            this.userModeUI = userModeUI;
        }
        public int LoginUser()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0);

           
            userModeUI.PrintLogin(); // 위에 로그인 화면
                                                                        
            id = validInput.EnterInput(52, 34, ErrorMessage.ID, RegularExpression.ID );
            // id 입력
            if (id == Constants.INPUT_BACK)                      
                return Constants.BACK;
            
            passWord = validInput.EnterLoginPassWprd(52, 35); 
            //password 입력
            if (passWord == Constants.INPUT_BACK)
                return Constants.BACK;


            if (CheckUser(id,passWord) == Constants.LOGIN_SUCCESS) // 로그인 성공
            {
                Console.Clear();
                userMenu.StartUserMenu(); // 유저메뉴 입장
            }
            else // 로그인 실패
                return LoginUser();


            
            return Constants.BACK;

        }
        private int CheckUser(string id, string passWord)
        {
            List <UserVO> userList = new List <UserVO>();

            mySQlData.SendUserList(userList); // 회원정보를 다가져옴

            for(int index = 0; index < userList.Count; index++)
            {
                if(userList[index].Id == id && userList[index].Password == passWord)
                    return Constants.LOGIN_SUCCESS;
            }
            return Constants.LOGIN_FAIL;
        }

    }
}
