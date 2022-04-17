using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    internal class Login
    {
        LoginUI loginUI;
        Exception exceuption =new Exception();
        ConsoleKeyInfo keyInput;

        private string id;
        private string password;
        
        public Login(LoginUI loginUI)
        {
            this.loginUI = loginUI;
        }
        public int StartUserLogin(List<UserVO> userList)
        {

            Console.Clear();
            Console.CursorVisible = true;
            loginUI.PrintLoginUI();

            id = exceuption.EnterId(Constant.WIDTH - 83, 16);
            if (id == "")  
                return Constant.LOGIN_OFF;//ESC 누르면 프로그램 종료     
            password = exceuption.EnterPassword(Constant.WIDTH-82, 18);
            if (password == "") 
                return Constant.LOGIN_OFF; //ESC 누르면 프로그램 종료   


            for (int index = 0; index < userList.Count; index++)
            {
                if (userList[index].Id == id && userList[index].Password == password)
                {
                    return Constant.LOGIN_SUCCESS;  // 로그인 성공
                }
            }

            // 로그인 실패

            loginUI.PrintReLogin();
           


            while (Constant.PROGRAM_ON) // 다시 로그인할건지, 프로그램종료할건지 입력
            {
                keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Escape)
                {                  
                    return Constant.LOGIN_OFF;
                }
                else if (keyInput.Key == ConsoleKey.Enter)
                    return Constant.LOGIN_FAIL; // ENTER은 다시 로그인
            }



        }
    }
}
