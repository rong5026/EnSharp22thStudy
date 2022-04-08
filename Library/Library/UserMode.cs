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

        const int LOGIN_REGISTER = 2;
        const int LOGIN_MODE = 1;
        const int REGISTER_MODE = 2;
        const int STOP = -1;
        const int BACK = -1;
        const int LOGIN_FAIL = 0;
        const int LOGIN_SUCCESS = 1;
        LibraryUI UI = new LibraryUI();
        SelectionMode mode = new SelectionMode();
        const Boolean PROGRAM_ON = true;
        
        Login login = new Login();
        Register register = new Register();

        int isLoggedIn;
        int menuNumber = 1;

        UserMenu userMenu = new UserMenu();
        public void StartUserMode(List<UserVO> userList)
        {

            UI.PrintMainUI();
            Console.SetWindowSize(125, 60);  //메인화면
           

            while (PROGRAM_ON)
            {
                menuNumber = mode.SelectMode(LOGIN_REGISTER); // 로그인 . 회원가입 선택

                switch (menuNumber)
                {
                    case LOGIN_MODE: // 로그인
                        isLoggedIn = login.UserLogin(userList); // 로그인했으면 true, 안했으면 false
                                                                // 여기에 이제 로그인 후 메뉴들 나오는거 해야함 login함수 안에서 해도 되고
                        if (isLoggedIn== LOGIN_SUCCESS)
                        {
                           userMenu.StartUserMenu(); // 
                        }
                        else if(isLoggedIn== LOGIN_FAIL)
                        {
                            Console.Clear();
                            UI.PrintLoginFail(); // 로그인 실패 UI
                            ConsoleKeyInfo keyInput;

                            keyInput = Console.ReadKey(true);
                            if (keyInput.Key == ConsoleKey.Enter)
                                return;
                            return;
                        }
                        return;                 
                    case REGISTER_MODE: // 회원가입
                        register.RegistUser(userList);
                        break;
                    case STOP:
                        return; // 뒤로가기


                }

            

            }




        } // 로그인을 했다면 UserMode 기능 출력, 선택

    }
}