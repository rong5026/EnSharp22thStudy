using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT
{
    internal class LTTStart
    {
        Login login = new Login();
        List<UserVO> userList = new List<UserVO>();
        LoginUI LoginUI = new LoginUI();

        ConsoleKeyInfo keyInput;
        int loginStatus;


        public void LTT()

        {
            while (Constant.PROGRAM_ON)
            {
                
                loginStatus = login.UserLogin(userList);
                if (loginStatus == Constant.LOGIN_OFF) // 프로그램 종료
                {
                    LoginUI.PrintProgramStop();
                    return;
                }

                else if (loginStatus == Constant.LOGIN_SUCCESS) // 로그인 성공
                {
                    // 다음 메뉴 페이지로 넘어가면 됨
                
                }
                else
                {
                    LoginUI.PrintReLogin();
                    keyInput = Console.ReadKey(true);

                    if (keyInput.Key == ConsoleKey.Escape)
                    {
                        LoginUI.PrintProgramStop();
                        return;
                    }

                }

            }

        }
    }
}
