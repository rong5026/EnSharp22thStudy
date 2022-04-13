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

      
        int isLoggedIn;
        int menuNumber = 1;

      
        public void StartUserMode()
        {

            VariableData.UI.PrintMainUI();
            Console.SetWindowSize(125, 60);  //메인화면



            while (Const.PROGRAM_ON)
            {
                menuNumber = VariableData.mode.SelectMode(Const.LOGIN_REGISTER); // 로그인 . 회원가입 선택

                switch (menuNumber)
                {
                    case Const.LOGIN_MODE: // 로그인
                        isLoggedIn = VariableData.login.UserLogin(); // 로그인했으면 true, 안했으면 false
                                                               
                        if (isLoggedIn== Const.LOGIN_SUCCESS)
                        {
                            VariableData.userMenu.StartUserMenu(); // 로그인 성공 UI
                        }
                        else if(isLoggedIn== Const.LOGIN_FAIL)
                        {
                            Console.Clear();
                            VariableData.UserUI.PrintLoginFail(); // 로그인 실패 UI
                            Thread.Sleep(1000);                                                                              
                            return;
                        }
                        return;                 
                    case Const.REGISTER_MODE: // 회원가입
                        VariableData.register.RegistUser();
                        break;
                    case Const.STOP:
                        return; // 뒤로가기


                }

            

            }




        } // 로그인을 했다면 UserMode 기능 출력, 선택

    }
}