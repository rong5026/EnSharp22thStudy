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
        ExcelData lectureData = new ExcelData();

        public static ExcelData excelData = new ExcelData(); // 엑셀데이터
        public static List<int> interestList = new List<int>();
        public static int applicationCredit = 0; // 동록가능학점
        // static 안쓰고 고쳐야함

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
