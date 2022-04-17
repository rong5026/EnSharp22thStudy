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
       
        List<UserVO> userList;
        LoginUI loginUI;
        Login login;
        UserMenu userMenu = new UserMenu();    

        public static ExcelData excelData = new ExcelData(); // 엑셀데이터
        public static List<int> interestList;// 관심과목 리스트
        public static List<int> registerList;
        public static int interestNumber; // 관심과목담은 학점
        public static int registerNumber; // 수강신청한 학점
    
        int loginStatus;
        UserVO user;
        public LTTStart()
        {
            user = new UserVO("19011617", "11111111"); // 고쳐야함
            loginUI = new LoginUI();
            login = new Login(loginUI);
            userList = new List<UserVO>();
            interestList = new List<int>();
            registerList = new List<int>();
            interestNumber = 0;
            registerNumber = 0;
        }
        public void StartLectureTimeTable()

        {
            interestList.Add(1); // 관심과목 리스트에서 위에 테마 추가
            registerList.Add(1);

           

            userList.Add(user);  
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
