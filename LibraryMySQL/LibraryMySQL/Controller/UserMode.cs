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

        LibraryUI UI;
        SelectionMode mode;

        UserMenu userMenu;
        Login login;
        Register register;
        UserModeUI userModeUI;

        int isLoggedIn;
        int menuNumber = 1;

        public UserMode(LibraryUI UI, SelectionMode mode)
        {
            register = new Register(userModeUI);
            userMenu = new UserMenu(UI, mode, userModeUI);
            userModeUI = new UserModeUI();
            login = new Login(userModeUI);
            this.UI = UI;
            this.mode = mode;

        }

      
        public void StartUserMode()
        {

            UI.PrintMainUI();
            Console.SetWindowSize(125, 60);  //메인화면



            while (Constants.PROGRAM_ON)
            {
                menuNumber =  mode.SelectMode(Constants.LOGIN_REGISTER); // 로그인 . 회원가입 선택

                switch (menuNumber)
                {
                    case Constants.LOGIN_MODE: // 로그인
                        isLoggedIn =  login.UserLogin(); // 로그인했으면 true, 안했으면 false
                                                               
                        if (isLoggedIn== Constants.LOGIN_SUCCESS)
                        {
                             userMenu.StartUserMenu(); // 로그인 성공 UI
                        }
                        else if(isLoggedIn== Constants.LOGIN_FAIL)
                        {
                            Console.Clear();
                            userModeUI.PrintLoginFail(); // 로그인 실패 UI
                                                                                                    
                            return;
                        }
                        return;                 
                    case Constants.REGISTER_MODE: // 회원가입
                         register.RegistUser();
                        break;
                    case Constants.STOP:
                        return; // 뒤로가기


                }

            

            }




        } // 로그인을 했다면 UserMode 기능 출력, 선택

    }
}