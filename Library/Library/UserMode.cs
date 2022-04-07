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

        LibraryUI UI = new LibraryUI();
        SelectionMode mode = new SelectionMode();
        const Boolean PROGRAM_ON = true;
        List<UserVO> userList = new List<UserVO>();
        Login login =new Login();
        Register register =new Register();  
        bool isLoggedIn;
        int menuNumber=1;

        public void StartUserMode()
        {

            UI.PrintMainUI();
            Console.SetWindowSize(125, 40);  //메인화면
            string idPassword;
            string name;
            int age;
            int phoneNumber;
            string address;
          

            while (PROGRAM_ON)
            {
                menuNumber = mode.SelectMode(LOGIN_REGISTER); // 로그인 . 회원가입 선택

                switch (menuNumber)
                {
                    case LOGIN_MODE: // 로그인
                        isLoggedIn = login.UserLogin(userList); // 로그인했으면 true, 안했으면 false
                        // 여기에 이제 로그인 후 메뉴들 나오는거 해야함 login함수 안에서 해도 되고
                        /*
                             if (isLoggedIn)
                            {

                            }
                            else
                            {
                             Console.Clear();
                                UI.PrintLoginFail(); // 로그인 실패 UI
                                return;
                                }

                         */
                        break;
                    case REGISTER_MODE: // 회원가입
                        register.UserRegister();
                        break;
                    case STOP:
                        return; // 뒤로가기
   

                }

            }

            

          
        } // 로그인을 했다면 UserMode 기능 출력, 선택
        
    }
}
