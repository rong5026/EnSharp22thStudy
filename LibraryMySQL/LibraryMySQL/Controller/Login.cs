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
                                     // 
            id = validInput.EnterLoginID(52, 34); // id 입력
            if (id == Constants.INPUT_EMPTY)                      
                return Constants.BACK;
            
            passWord = validInput.EnterLoginPassWord(52, 35); // password입력
            if (passWord == Constants.INPUT_EMPTY)
                return Constants.BACK;

            if (mySQlData.CheckLogin(id, passWord) == Constants.LOGIN_SUCCESS)
            {
                Console.Clear();
                userMenu.StartUserMenu(); // 유저메뉴 입장
            }
            else
                return LoginUser();


            
            return Constants.BACK;

        }

    }
}
