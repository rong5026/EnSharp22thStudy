using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT
{
    internal class Login
    {
        LoginUI loginUI = new LoginUI();
        Exception exceuption =new Exception();
        ConsoleKeyInfo keyInput;

        string id;
        string password;

       

        public int UserLogin(List<UserVO> userList)
        {

            Console.Clear();
            Console.CursorVisible = true;
            loginUI.PrintLoginUI();

            id = exceuption.EnterId(77, 16);
            if (id == "")  
                return Constant.LOGIN_OFF;//ESC 누르면 프로그램 종료     
            password = exceuption.EnterPassword(78, 18);
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
           


            while (Constant.PROGRAM_ON)
            {
                keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.Escape)
                {
                    loginUI.PrintProgramStop();
                    return Constant.LOGIN_OFF;
                }
                else if (keyInput.Key == ConsoleKey.Enter)
                    return Constant.LOGIN_FAIL;
            }



        }
    }
}
