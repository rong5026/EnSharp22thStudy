using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;
namespace LectureTimeTable
{
    internal class LTTStart
    {
        Login login = new Login();
        List<UserVO> userList = new List<UserVO>();
        LoginUI loginUI = new LoginUI();
        UserMenu userMenu = new UserMenu();
        LectureData lectureData = new LectureData();

        ConsoleKeyInfo keyInput;
        int loginStatus;


        UserVO user = new UserVO("19011617","mong5026"); // 고쳐야함
        public void LTT()

        {
            userList.Add(user);   //고쳐야함
            while (Constant.PROGRAM_ON)
            {
                
                loginStatus = login.StartUserLogin(userList);
                if (loginStatus == Constant.LOGIN_OFF) // 프로그램 종료
                {
                    loginUI.PrintProgramStop();
                    return;
                }

                else if (loginStatus == Constant.LOGIN_SUCCESS) // 로그인 성공
                {

                    userMenu.StartUserMenu();

                }

              
                

            }

        }
    }
}
