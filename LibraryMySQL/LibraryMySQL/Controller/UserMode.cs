using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace LibraryMySQL
{
    internal class UserMode
    {

      
        int isLoggedIn;
        int menuNumber = 1;
        LibraryUI UI;
        SelectionMode mode = new SelectionMode();
        Register register;
        Login login;
        MySQlData mysqlData;
        public UserMode(MySQlData mysqlData)
        {
            UI = new LibraryUI(mysqlData);
            register = new Register(mysqlData);
            this.mysqlData = mysqlData;
           login= new Login(mysqlData);
        }
        public void StartUserMode()
        {

            UI.PrintMainUI();
            Console.SetWindowSize(125, 60);  //메인화면
            Console.CursorVisible = false;


            while (Constants.PROGRAM_ON)
            {
                menuNumber = mode.SelectMode(Constants.LOGIN_REGISTER); // 로그인 . 회원가입 선택

                switch (menuNumber)
                {
                    case Constants.LOGIN_MODE: // 로그인
                        login.LoginUser(); //
                        Console.Clear(); 
                        break;                
                    case Constants.REGISTER_MODE: // 회원가입
                        register.RegistUser();
                        Console.Clear();
                        break;
                    case Constants.STOP:
                        return; // 뒤로가기


                }

            

            }




        } // 로그인을 했다면 UserMode 기능 출력, 선택

      
    }
}