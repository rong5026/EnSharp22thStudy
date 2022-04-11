using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Library
{
    internal class UserMode
    {

    
        LibraryUI UI = new LibraryUI();
        UserModeUI UserUI = new UserModeUI();
        SelectionMode mode = new SelectionMode();
        UserMenu userMenu = new UserMenu();            
        Login login = new Login();
        Register register = new Register();
        ConsoleKeyInfo keyInput;
        int isLoggedIn;
        int menuNumber = 1;

      
        public void StartUserMode()
        {

            UI.PrintMainUI();
            Console.SetWindowSize(125, 60);  //메인화면



            while (Const.PROGRAM_ON)
            {
                menuNumber = mode.SelectMode(Const.LOGIN_REGISTER); // 로그인 . 회원가입 선택

                switch (menuNumber)
                {
                    case Const.LOGIN_MODE: // 로그인
                        isLoggedIn = login.UserLogin(); // 로그인했으면 true, 안했으면 false
                                                               
                        if (isLoggedIn== Const.LOGIN_SUCCESS)
                        {
                           userMenu.StartUserMenu(); // 로그인 성공 UI
                        }
                        else if(isLoggedIn== Const.LOGIN_FAIL)
                        {
                            Console.Clear();
                            UserUI.PrintLoginFail(); // 로그인 실패 UI
                         
                            keyInput = Console.ReadKey(true);                                                       
                            return;
                        }
                        return;                 
                    case Const.REGISTER_MODE: // 회원가입
                        register.RegistUser();
                        break;
                    case Const.STOP:
                        return; // 뒤로가기


                }

            

            }




        } // 로그인을 했다면 UserMode 기능 출력, 선택

    }
}