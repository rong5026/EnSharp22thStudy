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

            id = exceuption.EnterId(Constants.WIDTH - 83, 16);
            if (id == "")  
                return Constants.LOGIN_OFF;//ESC 누르면 프로그램 종료     
            password = exceuption.EnterPassword(Constants.WIDTH-82, 18);
            if (password == "") 
                return Constants.LOGIN_OFF; //ESC 누르면 프로그램 종료   


            for (int index = 0; index < userList.Count; index++)
            {
                if (userList[index].Id == id && userList[index].Password == password)
                {
                    return Constants.LOGIN_SUCCESS;  // 로그인 성공
                }
            }

            // 로그인 실패

            loginUI.PrintReLogin();
           


            while (Constants.PROGRAM_ON) // 다시 로그인할건지, 프로그램종료할건지 입력
            {
                keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Escape)
                {                  
                    return Constants.LOGIN_OFF;
                }
                else if (keyInput.Key == ConsoleKey.Enter)
                    return Constants.LOGIN_FAIL; // ENTER은 다시 로그인
            }



        }
    }
}
